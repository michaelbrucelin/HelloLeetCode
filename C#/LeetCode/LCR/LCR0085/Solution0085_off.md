### [生成匹配的括号](https://leetcode.cn/problems/IDBivT/solutions/1412108/sheng-cheng-pi-pei-de-gua-hao-by-leetcod-ro96/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：暴力法

**思路**

我们可以生成所有 $2^{2n}$ 个 $'('$ 和 $')'$ 字符构成的序列，然后我们检查每一个是否有效即可。

**算法**

为了生成所有序列，我们可以使用递归。长度为 $n$ 的序列就是在长度为 $n-1$ 的序列前加一个 $'('$ 或 $')'$。

为了检查序列是否有效，我们遍历这个序列，并使用一个变量 $balance$ 表示左括号的数量减去右括号的数量。如果在遍历过程中 $balance$ 的值小于零，或者结束时 $balance$ 的值不为零，那么该序列就是无效的，否则它是有效的。

```Java
class Solution {
    public List<String> generateParenthesis(int n) {
        List<String> combinations = new ArrayList<String>();
        generateAll(new char[2 * n], 0, combinations);
        return combinations;
    }

    public void generateAll(char[] current, int pos, List<String> result) {
        if (pos == current.length) {
            if (valid(current)) {
                result.add(new String(current));
            }
        } else {
            current[pos] = '(';
            generateAll(current, pos + 1, result);
            current[pos] = ')';
            generateAll(current, pos + 1, result);
        }
    }

    public boolean valid(char[] current) {
        int balance = 0;
        for (char c: current) {
            if (c == '(') {
                ++balance;
            } else {
                --balance;
            }
            if (balance < 0) {
                return false;
            }
        }
        return balance == 0;
    }
}
```

```Python
class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        def generate(A):
            if len(A) == 2*n:
                if valid(A):
                    ans.append("".join(A))
            else:
                A.append('(')
                generate(A)
                A.pop()
                A.append(')')
                generate(A)
                A.pop()

        def valid(A):
            bal = 0
            for c in A:
                if c == '(': bal += 1
                else: bal -= 1
                if bal < 0: return False
            return bal == 0

        ans = []
        generate([])
        return ans
```

```C++
class Solution {
    bool valid(const string& str) {
        int balance = 0;
        for (char c : str) {
            if (c == '(') {
                ++balance;
            } else {
                --balance;
            }
            if (balance < 0) {
                return false;
            }
        }
        return balance == 0;
    }

    void generate_all(string& current, int n, vector<string>& result) {
        if (n == current.size()) {
            if (valid(current)) {
                result.push_back(current);
            }
            return;
        }
        current += '(';
        generate_all(current, n, result);
        current.pop_back();
        current += ')';
        generate_all(current, n, result);
        current.pop_back();
    }
public:
    vector<string> generateParenthesis(int n) {
        vector<string> result;
        string current;
        generate_all(current, n * 2, result);
        return result;
    }
};
```

**复杂度分析**

- 时间复杂度：$O(2^{2n}n)$，对于 $2^{2n}$ 个序列中的每一个，我们用于建立和验证该序列的复杂度为 $O(n)$。
- 空间复杂度：$O(n)$，除了答案数组之外，我们所需要的空间取决于递归栈的深度，每一层递归函数需要 $O(1)$ 的空间，最多递归 $2n$ 层，因此空间复杂度为 $O(n)$。

#### 方法二：回溯法

**思路和算法**

方法一还有改进的余地：我们可以只在序列仍然保持有效时才添加 $'('$ 或 $')'$，而不是像 [方法一](https://leetcode.cn/problems/IDBivT/solutions/1412108/sheng-cheng-pi-pei-de-gua-hao-by-leetcod-ro96/?envType=problem-list-v2&envId=ySsxoJfz#%E6%96%B9%E6%B3%95%E4%B8%80%EF%BC%9A%E6%9A%B4%E5%8A%9B%E6%B3%95) 那样每次添加。我们可以通过跟踪到目前为止放置的左括号和右括号的数目来做到这一点，

如果左括号数量不大于 $n$，我们可以放一个左括号。如果右括号数量小于左括号的数量，我们可以放一个右括号。

```Java
class Solution {
    public List<String> generateParenthesis(int n) {
        List<String> ans = new ArrayList<String>();
        backtrack(ans, new StringBuilder(), 0, 0, n);
        return ans;
    }

    public void backtrack(List<String> ans, StringBuilder cur, int open, int close, int max) {
        if (cur.length() == max * 2) {
            ans.add(cur.toString());
            return;
        }
        if (open < max) {
            cur.append('(');
            backtrack(ans, cur, open + 1, close, max);
            cur.deleteCharAt(cur.length() - 1);
        }
        if (close < open) {
            cur.append(')');
            backtrack(ans, cur, open, close + 1, max);
            cur.deleteCharAt(cur.length() - 1);
        }
    }
}
```

```Python
class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        ans = []
        def backtrack(S, left, right):
            if len(S) == 2 * n:
                ans.append(''.join(S))
                return
            if left < n:
                S.append('(')
                backtrack(S, left+1, right)
                S.pop()
            if right < left:
                S.append(')')
                backtrack(S, left, right+1)
                S.pop()

        backtrack([], 0, 0)
        return ans
```

```C++
class Solution {
    void backtrack(vector<string>& ans, string& cur, int open, int close, int n) {
        if (cur.size() == n * 2) {
            ans.push_back(cur);
            return;
        }
        if (open < n) {
            cur.push_back('(');
            backtrack(ans, cur, open + 1, close, n);
            cur.pop_back();
        }
        if (close < open) {
            cur.push_back(')');
            backtrack(ans, cur, open, close + 1, n);
            cur.pop_back();
        }
    }
public:
    vector<string> generateParenthesis(int n) {
        vector<string> result;
        string current;
        backtrack(result, current, 0, 0, n);
        return result;
    }
};
```

**复杂度分析**

我们的复杂度分析依赖于理解 $generateParenthesis(n)$ 中有多少个元素。这个分析超出了本文的范畴，但事实证明这是第 $n$ 个卡特兰数 $\dfrac{1}{n+1}\begin{pmatrix}2n \\ n\end{pmatrix}$，这是由 $\dfrac{4^n}{n\sqrt{n}}$ 渐近界定的。

- 时间复杂度：$O(\dfrac{4^n}{\sqrt{n}})$，在回溯过程中，每个答案需要 $O(n)$ 的时间复制到答案数组中。
- 空间复杂度：$O(n)$，除了答案数组之外，我们所需要的空间取决于递归栈的深度，每一层递归函数需要 $O(1)$ 的空间，最多递归 $2n$ 层，因此空间复杂度为 $O(n)$。

#### 方法三：按括号序列的长度递归

**思路与算法**

任何一个括号序列都一定是由 $'('$ 开头，并且第一个 $'('$ 一定有一个唯一与之对应的 $')'$。这样一来，每一个括号序列可以用 $(a)b$ 来表示，其中 $a$ 与 $b$ 分别是一个合法的括号序列（可以为空）。

那么，要生成所有长度为 $2n$ 的括号序列，我们定义一个函数 $generate(n)$ 来返回所有可能的括号序列。那么在函数 $generate(n)$ 的过程中：

- 我们需要枚举与第一个 $'('$ 对应的 $')'$ 的位置 $2i+1$；
- 递归调用 $generate(i)$ 即可计算 $a$ 的所有可能性；
- 递归调用 $generate(n-i-1)$ 即可计算 $b$ 的所有可能性；
- 遍历 $a$ 与 $b$ 的所有可能性并拼接，即可得到所有长度为 $2n$ 的括号序列。

为了节省计算时间，我们在每次 $generate(i)$ 函数返回之前，把返回值存储起来，下次再调用 $generate(i)$ 时可以直接返回，不需要再递归计算。

```Java
class Solution {
    ArrayList[] cache = new ArrayList[100];

    public List<String> generate(int n) {
        if (cache[n] != null) {
            return cache[n];
        }
        ArrayList<String> ans = new ArrayList<String>();
        if (n == 0) {
            ans.add("");
        } else {
            for (int c = 0; c < n; ++c) {
                for (String left: generate(c)) {
                    for (String right: generate(n - 1 - c)) {
                        ans.add("(" + left + ")" + right);
                    }
                }
            }
        }
        cache[n] = ans;
        return ans;
    }

    public List<String> generateParenthesis(int n) {
        return generate(n);
    }
}
```

```Python
class Solution:
    @lru_cache(None)
    def generateParenthesis(self, n: int) -> List[str]:
        if n == 0:
            return ['']
        ans = []
        for c in range(n):
            for left in self.generateParenthesis(c):
                for right in self.generateParenthesis(n-1-c):
                    ans.append('({}){}'.format(left, right))
        return ans
```

```C++
class Solution {
    shared_ptr<vector<string>> cache[100] = {nullptr};
public:
    shared_ptr<vector<string>> generate(int n) {
        if (cache[n] != nullptr)
            return cache[n];
        if (n == 0) {
            cache[0] = shared_ptr<vector<string>>(new vector<string>{""});
        } else {
            auto result = shared_ptr<vector<string>>(new vector<string>);
            for (int i = 0; i != n; ++i) {
                auto lefts = generate(i);
                auto rights = generate(n - i - 1);
                for (const string& left : *lefts)
                    for (const string& right : *rights)
                        result -> push_back("(" + left + ")" + right);
            }
            cache[n] = result;
        }
        return cache[n];
    }
    vector<string> generateParenthesis(int n) {
        return *generate(n);
    }
};
```

**复杂度分析**

- 时间复杂度：$O(\dfrac{4^n}{\sqrt{n}})$，该分析与 [方法二](https://leetcode.cn/problems/IDBivT/solutions/1412108/sheng-cheng-pi-pei-de-gua-hao-by-leetcod-ro96/?envType=problem-list-v2&envId=ySsxoJfz#%E6%96%B9%E6%B3%95%E4%BA%8C%EF%BC%9A%E5%9B%9E%E6%BA%AF%E6%B3%95) 类似。
- 空间复杂度：$O(\dfrac{4^n}{\sqrt{n}})$，此方法除答案数组外，中间过程中会存储与答案数组同样数量级的临时数组，是我们所需要的空间复杂度。
