### [生成不含相邻零的二进制字符串](https://leetcode.cn/problems/generate-binary-strings-without-adjacent-zeros/solutions/2963030/sheng-cheng-bu-han-xiang-lin-ling-de-er-ci0wf/)

#### 方法一：回溯

**思路**

字符串所有长度为 $2$ 的子字符串都包含至少一个 $‘1’$，则要求字符串不能有连续的 $‘0’$。

设计递归函数 $dfs$，输入是表示当前的字符串，如果当前字符串长度为 $n$，那么将当前字符串加入结果数组中。否则需要考虑当前字符串末尾元素，如果末尾元素为 $‘0’$，则在末尾添加一个 $‘1’$，并继续递归；其他情况下（字符串为空，或者末尾元素为 $‘1’$），则可以在末尾添加一个 $‘0’$ 或者 $‘1’$，并继续递归；递归的起点为空字符串。递归结束后，返回结果数组即可。在实现上，可以用数组代替递归函数输入的字符串，数组的元素是单个字符。要将字符串加入结果数组时，可以将输入的数组的元素进行连接后加入数组。需要在字符串末尾添加元素时，则需要在数组末尾添加元素，并在递归结束后删除末尾元素。递归的起点为空数组。

接下来讨论下时间复杂度。宽松地估计，时间复杂度是 $O(n \times 2^n)$，因为字符串每一位可以为 $‘0’$ 或 $‘1’$，最后拼接字符串需要消耗 $O(n)$。不过我们可以有更准确地估计。

考虑输入较小时，结果数组的长度。当 $n$ 分别为 $1，2，3，4，5$ 时，结果的长度分别为 $2，3，5，8，13$，可以猜测数组的长度呈现斐波那契数列的规律。假设 $n-2$ 时，结果中，末尾为 $‘0’$ 的字符串有 $a$ 个，末尾为 $‘1’$ 的字符串有 $b$ 个；$n-1$ 时，结果中，末尾为 $‘0’$ 的字符串有 $c$ 个，末尾为 $‘1’$ 的字符串有 $d$ 个。那么 $n$ 时，结果中就会有 $c+2 \times d$ 个字符串，而 $d=a+b$，因此结果中会有 $a+b+c+d$ 个字符串，正好是 $n-2$ 时结果中字符串个数与 $n-1$ 时结果中字符串个数之和。因此，类似于斐波那契数列的通项公式，我们可以得到结果中字符串的个数为 $\dfrac{(\frac{1+\sqrt{5}}{2})^{n+2}-(\frac{1-\sqrt{5}}{2})^{n+2}}{\sqrt{5}}$​。这样的情况下，我们可以得到时间复杂度为 $O(n \times (\frac{1+\sqrt{5}}{n})^n)$。

**代码**

```Python
class Solution:
    def validStrings(self, n: int) -> List[str]:
        res = []
        def dfs(arr: List[str]) -> None:
            if len(arr) == n:
                res.append(''.join(arr))
            else:
                if arr == [] or arr[-1] == '1':
                    arr.append('0')
                    dfs(arr)
                    arr.pop()
                arr.append('1')
                dfs(arr)
                arr.pop()
        dfs([])
        return res
```

```Java
class Solution {
    List<String> res = new ArrayList<String>();
    int n;

    public List<String> validStrings(int n) {
        this.n = n;
        dfs(new StringBuilder());
        return res;
    }

    public void dfs(StringBuilder sb) {
        if (sb.length() == n) {
            res.add(sb.toString());
        } else {
            if (sb.isEmpty() || sb.charAt(sb.length() - 1) == '1') {
                sb.append('0');
                dfs(sb);
                sb.setLength(sb.length() - 1);
            }
            sb.append('1');
            dfs(sb);
            sb.setLength(sb.length() - 1);
        }
    }
}
```

```CSharp
public class Solution {
    IList<string> res = new List<string>();
    int n;

    public IList<string> ValidStrings(int n) {
        this.n = n;
        DFS(new StringBuilder());
        return res;
    }

    public void DFS(StringBuilder sb) {
        if (sb.Length == n) {
            res.Add(sb.ToString());
        } else {
            if (sb.Length == 0 || sb[sb.Length - 1] == '1') {
                sb.Append('0');
                DFS(sb);
                sb.Length--;
            }
            sb.Append('1');
            DFS(sb);
            sb.Length--;
        }
    }
}
```

```C++
class Solution {
public:
    vector<string> validStrings(int n) {
        vector<string> res;
        string str;

        function<void(string &)> dfs = [&](string& str) {
            if (str.size() == n) {
                res.push_back(str);
                return;
            }
            if (str.empty() || str.back() == '1') {
                str.push_back('0');
                dfs(str);
                str.pop_back();
            }
            str.push_back('1');
            dfs(str);
            str.pop_back();
        };
        
        dfs(str);
        return res;
    }
};
```

```Go
func validStrings(n int) []string {
    res := []string{}
    var dfs func(arr []rune)
    dfs = func(arr []rune) {
        if len(arr) == n {
            res = append(res, string(arr))
            return
        }
        if len(arr) == 0 || arr[len(arr) - 1] == '1' {
            arr = append(arr, '0')
            dfs(arr)
            arr = arr[:len(arr)-1]
        }
        arr = append(arr, '1')
        dfs(arr)
        arr = arr[:len(arr)-1]
    }
    dfs([]rune{})
    return res
}
```

```C
void dfs(char *arr, int index, int n, char **res, int *count) {
    if (index == n) {
        res[*count] = strdup(arr);
        (*count)++;
        return;
    }
    if (index == 0 || arr[index - 1] == '1') {
        arr[index] = '0';
        dfs(arr, index + 1, n, res, count);
    }
    arr[index] = '1';
    dfs(arr, index + 1, n, res, count);
}

char** validStrings(int n, int* returnSize) {
    char **res = malloc((1 << n) * sizeof(char *));
    char *arr = malloc((n + 1) * sizeof(char));
    arr[n] = '\0';
    int count = 0;
    dfs(arr, 0, n, res, &count);
    free(arr);
    *returnSize = count;
    return res;
}
```

```JavaScript
var validStrings = function(n) {
    const res = [];
    function dfs(arr) {
        if (arr.length === n) {
            res.push(arr.join(''));
            return;
        }
        if (arr.length === 0 || arr[arr.length - 1] === '1') {
            arr.push('0');
            dfs(arr);
            arr.pop();
        }
        arr.push('1');
        dfs(arr);
        arr.pop();
    }
    dfs([]);
    return res;
};
```

```TypeScript
function validStrings(n: number): string[] {
    const res: string[] = [];
    const dfs = (arr: string[]) => {
        if (arr.length === n) {
            res.push(arr.join(''));
            return;
        }
        if (arr.length === 0 || arr[arr.length - 1] === '1') {
            arr.push('0');
            dfs(arr);
            arr.pop();
        }
        arr.push('1');
        dfs(arr);
        arr.pop();
    };
    dfs([]);
    return res;
};
```

```Rust
impl Solution {
    pub fn valid_strings(n: i32) -> Vec<String> {
        let mut res = Vec::new();
        let mut arr = Vec::new();
        Self::dfs(&mut arr, n, &mut res);
        res
    }

    fn dfs(arr: &mut Vec<char>, n: i32, res: &mut Vec<String>) {
        if arr.len() == n as usize {
            res.push(arr.iter().collect());
            return;
        }
        if arr.is_empty() || arr[arr.len() - 1] == '1' {
            arr.push('0');
            Self::dfs(arr, n, res);
            arr.pop();
        }
        arr.push('1');
        Self::dfs(arr, n, res);
        arr.pop();
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \times (\frac{1+\sqrt{5}}{2})^n)$。
- 空间复杂度：$O(n)$。

#### 方法二：位运算

**思路**

用一个 $0$ 到 $2n-1$ 之间的数字的二进制形式代表字符串，如果这个二进制没有相邻的 $0$，则代表是一个有效字符串。那么怎么判断是否有相邻的 $0$ 呢？首先将数字按位取反，记为 $t$。如果 $t \& (t>>1)$ 为 0，则 $t$ 中没有相邻的 $1$。

**代码**

```Python
class Solution:
    def validStrings(self, n: int) -> List[str]:
        res = []
        mask = (1 << n) - 1
        for i in range(1<<n):
            t = mask ^ i
            if not (t >> 1 & t):
                res.append(f"{i:0{n}b}")
        return res
```

```Java
class Solution {
    public List<String> validStrings(int n) {
        List<String> res = new ArrayList<String>();
        int mask = (1 << n) - 1;
        for (int i = 0; i < 1 << n; i++) {
            int t = mask ^ i;
            if (((t >> 1) & t) == 0) {
                String str = Integer.toBinaryString(i);
                StringBuilder sb = new StringBuilder();
                for (int j = n - str.length(); j > 0; j--) {
                    sb.append('0');
                }
                sb.append(str);
                res.add(sb.toString());
            }
        }
        return res;
    }
}
```

```C++
class Solution {
public:
    vector<string> validStrings(int n) {
        vector<string> res;
        int mask = (1 << n) - 1;
        for (int i = 0; i < (1 << n); i++) {
            int t = mask ^ i;
            if (!(t >> 1 & t)) {
                res.push_back(intToBinaryString(i, n));
            }
        }
        return res;
    }

    string intToBinaryString(int num, int n) {
        string binary(n, '0');
        for (int j = 0; j < n; j++) {
            binary[n - 1 - j] = (num & (1 << j)) ? '1' : '0';
        }
        return binary;
    }
};
```

**复杂度分析**

- 时间复杂度：$O(2^n)$。
- 空间复杂度：$O(1)$。
