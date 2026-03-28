### [找出对应 LCP 矩阵的字符串](https://leetcode.cn/problems/find-the-string-with-lcp/solutions/3929439/zhao-chu-dui-ying-lcp-ju-zhen-de-zi-fu-c-riwy/)

#### 方法一：贪心构造

**思路与算法**

根据题目要求找到字典序最小的字符串，我们尝试从前往后构造字符串，这样每次填入字典序尽可能小的字符，就能使得构造生成的字符串字典序最小，然后我们验证构造的字符串是否满足 $lcp$ 的要求。

根据 $lcp$ 的定义可知，$lcp[i][j]$ 为两个子字符串 $word[i,\dots ,n-1]$ 与 $word[j,\dots ,n-1]$ 之间的「[最长公共前缀](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fstring%2Fsa%2F%23lcp%E6%9C%80%E9%95%BF%E5%85%AC%E5%85%B1%E5%89%8D%E7%BC%80)」的长度，因此当 $lcp[i][j]>0$ 时，此时 一定满足 $word[i]=word[j]$，我们可以利用这一性质来构造字符串 $word$。

构造过程如下：

- 顺序遍历字符串的每个位置 $i$，如果该位置为空，则我们直接写上最小的字符 $current$，根据 $lcp$ 的值，如果满足 $lcp[i][j]>0$，则在位置 $j$ 填上一样的字符。如果当前最小的字符超过小写字母的最大值，则直接返回空字符串。本次填充完毕将 $current$ 加 $1$，然后考虑下一个为空的字符。

此时构造的字符串合理性建立在考虑了所有或矛盾或不矛盾的字符相等的条件下，得出的是唯一可能为答案的字符串。接下来，我们需要判断构造的字符串是否满足对应的 $lcp$ 矩阵。我们知道 $lcp$ 矩阵可以通过动态规划直接得到，递推公式如下：

$$\begin{cases}lcp[i][j]=lcp[i+1][j+1]+1 & if word[i]=word[j] \\ lcp[i][j]=0 & if word[i]\ne word[j]\end{cases}$$

我们分别枚举 $(i,j)$，验证字符串 $word$ 是否满足 $lcp$ 矩阵，此时需要满足以下条件：

- 当 $word[i]=word[j]$ 时，此时两个字符串的最长公共前缀长度大于 $0$，此时一定满足 $lcp[i][j]>0$。当 $i=n-1$ 或者 $j=n-1$ 时，由于此时 $word[i]$ 或者 $word[j]$ 为字符串的结尾，因此最长公共前缀长度一定为 $1$；当 $i<n-1$ 并且 $j<n-1$ 时，根据动态规划递推公式可知，此时需要满足 $lcp[i][j]=lcp[i+1][j+1]+1$；
- 当 $word[i]\ne word[j]$ 时，此时两个字符串的最长公共前缀长度为 $0$，此时 $lcp[i][j]$ 一定等于 $0$；

我们验证当前构造的字符串是否满足以上条件，如果不满足则返回空字符串，否则返回构造的字符串 $word$。

**代码**

```C++
class Solution {
public:
    string findTheString(vector<vector<int>>& lcp) {
        int n = lcp.size();
        string word(n, '\0');
        char current = 'a';

        // 依次从 'a' 到 'z' 开始构造字符串
        for (int i = 0; i < n; i++) {
            if (word[i] == '\0') {
                if (current > 'z') {
                    return "";
                }
                word[i] = current;
                for (int j = i + 1; j < n; j++) {
                    if (lcp[i][j] > 0) {
                        word[j] = word[i];
                    }
                }
                current++;
            }
        }

        // 验证构造的字符串是否满足 LCP 矩阵要求
        for (int i = n - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                if (word[i] != word[j]) {
                    if (lcp[i][j]) {
                        return "";
                    }
                } else {
                    if (i == n - 1 || j == n - 1) {
                        if (lcp[i][j] != 1) {
                            return "";
                        }
                    } else {
                        if (lcp[i][j] != lcp[i + 1][j + 1] + 1) {
                            return "";
                        }
                    }
                }
            }
        }

        return word;
    }
};
```

```Java
class Solution {
    public String findTheString(int[][] lcp) {
        int n = lcp.length;
        char[] word = new char[n];
        char current = 'a';

        // 依次从 'a' 到 'z' 开始构造字符串
        for (int i = 0; i < n; i++) {
            if (word[i] == 0) {
                if (current > 'z') {
                    return "";
                }
                word[i] = current;
                for (int j = i + 1; j < n; j++) {
                    if (lcp[i][j] > 0) {
                        word[j] = word[i];
                    }
                }
                current++;
            }
        }

        // 验证构造的字符串是否满足 LCP 矩阵要求
        for (int i = n - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                if (word[i] != word[j]) {
                    if (lcp[i][j] != 0) {
                        return "";
                    }
                } else {
                    if (i == n - 1 || j == n - 1) {
                        if (lcp[i][j] != 1) {
                            return "";
                        }
                    } else {
                        if (lcp[i][j] != lcp[i + 1][j + 1] + 1) {
                            return "";
                        }
                    }
                }
            }
        }

        return new String(word);
    }
}
```

```CSharp
public class Solution {
    public string FindTheString(int[][] lcp) {
        int n = lcp.Length;
        char[] word = new char[n];
        char current = 'a';

        // 依次从 'a' 到 'z' 开始构造字符串
        for (int i = 0; i < n; i++) {
            if (word[i] == '\0') {
                if (current > 'z') {
                    return "";
                }
                word[i] = current;
                for (int j = i + 1; j < n; j++) {
                    if (lcp[i][j] > 0) {
                        word[j] = word[i];
                    }
                }
                current++;
            }
        }

        // 验证构造的字符串是否满足 LCP 矩阵要求
        for (int i = n - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                if (word[i] != word[j]) {
                    if (lcp[i][j] != 0) {
                        return "";
                    }
                } else {
                    if (i == n - 1 || j == n - 1) {
                        if (lcp[i][j] != 1) {
                            return "";
                        }
                    } else {
                        if (lcp[i][j] != lcp[i + 1][j + 1] + 1) {
                            return "";
                        }
                    }
                }
            }
        }

        return new string(word);
    }
}
```

```Go
func findTheString(lcp [][]int) string {
    n := len(lcp)
    word := make([]byte, n)
    current := byte('a')

    // 依次从 'a' 到 'z' 开始构造字符串
    for i := 0; i < n; i++ {
        if word[i] == 0 {
            if current > 'z' {
                return ""
            }
            word[i] = current
            for j := i + 1; j < n; j++ {
                if lcp[i][j] > 0 {
                    word[j] = word[i]
                }
            }
            current++
        }
    }

     // 验证构造的字符串是否满足 LCP 矩阵要求
    for i := n - 1; i >= 0; i-- {
        for j := n - 1; j >= 0; j-- {
            if word[i] != word[j] {
                if lcp[i][j] != 0 {
                    return ""
                }
            } else {
                if i == n-1 || j == n-1 {
                    if lcp[i][j] != 1 {
                        return ""
                    }
                } else {
                    if lcp[i][j] != lcp[i+1][j+1]+1 {
                        return ""
                    }
                }
            }
        }
    }

    return string(word)
}
```

```Python
class Solution:
    def findTheString(self, lcp: List[List[int]]) -> str:
        n = len(lcp)
        word = [''] * n
        current = ord('a')

        # 依次从 'a' 到 'z' 开始构造字符串
        for i in range(n):
            if not word[i]:
                if current > ord('z'):
                    return ""
                word[i] = chr(current)
                for j in range(i + 1, n):
                    if lcp[i][j]:
                        word[j] = word[i]
                current += 1

        # 验证构造的字符串是否满足 LCP 矩阵要求
        for i in range(n - 1, -1, -1):
            for j in range(n - 1, -1, -1):
                if word[i] != word[j]:
                    if lcp[i][j]:
                        return ""
                else:
                    if i == n - 1 or j == n - 1:
                        if lcp[i][j] != 1:
                            return ""
                    else:
                        if lcp[i][j] != lcp[i + 1][j + 1] + 1:
                            return ""

        return ''.join(word)
```

```C
char* findTheString(int** lcp, int lcpSize, int* lcpColSize) {
    int n = lcpSize;
    char* word = (char*)malloc((n + 1) * sizeof(char));
    memset(word, 0, sizeof(char) * (n + 1));
    char current = 'a';

    // 依次从 'a' 到 'z' 开始构造字符串
    for (int i = 0; i < n; i++) {
        if (word[i] == '\0') {
            if (current > 'z') {
                word[0] = '\0';
                return word;
            }
            word[i] = current;
            for (int j = i + 1; j < n; j++) {
                if (lcp[i][j] > 0) {
                    word[j] = word[i];
                }
            }
            current++;
        }
    }

    // 验证构造的字符串是否满足 LCP 矩阵要求
    for (int i = n - 1; i >= 0; i--) {
        for (int j = n - 1; j >= 0; j--) {
            if (word[i] != word[j]) {
                if (lcp[i][j] != 0) {
                    word[0] = '\0';
                    return word;
                }
            } else {
                if (i == n - 1 || j == n - 1) {
                    if (lcp[i][j] != 1) {
                        word[0] = '\0';
                        return word;
                    }
                } else {
                    if (lcp[i][j] != lcp[i + 1][j + 1] + 1) {
                        word[0] = '\0';
                        return word;
                    }
                }
            }
        }
    }

    return word;
}
```

```JavaScript
var findTheString = function(lcp) {
    const n = lcp.length;
    const word = new Array(n).fill('');
    let current = 'a'.charCodeAt(0);

    // 依次从 'a' 到 'z' 开始构造字符串
    for (let i = 0; i < n; i++) {
        if (!word[i]) {
            if (current > 'z'.charCodeAt(0)) {
                return "";
            }
            word[i] = String.fromCharCode(current);
            for (let j = i + 1; j < n; j++) {
                if (lcp[i][j] > 0) {
                    word[j] = word[i];
                }
            }
            current++;
        }
    }

    // 验证构造的字符串是否满足 LCP 矩阵要求
    for (let i = n - 1; i >= 0; i--) {
        for (let j = n - 1; j >= 0; j--) {
            if (word[i] !== word[j]) {
                if (lcp[i][j] !== 0) {
                    return "";
                }
            } else {
                if (i === n - 1 || j === n - 1) {
                    if (lcp[i][j] !== 1) {
                        return "";
                    }
                } else {
                    if (lcp[i][j] !== lcp[i + 1][j + 1] + 1) {
                        return "";
                    }
                }
            }
        }
    }

    return word.join('');
};
```

```TypeScript
function findTheString(lcp: number[][]): string {
    const n = lcp.length;
    const word: string[] = new Array(n).fill('');
    let current = 'a'.charCodeAt(0);

    // 依次从 'a' 到 'z' 开始构造字符串
    for (let i = 0; i < n; i++) {
        if (!word[i]) {
            if (current > 'z'.charCodeAt(0)) {
                return "";
            }
            word[i] = String.fromCharCode(current);
            for (let j = i + 1; j < n; j++) {
                if (lcp[i][j] > 0) {
                    word[j] = word[i];
                }
            }
            current++;
        }
    }

    // 验证构造的字符串是否满足 LCP 矩阵要求
    for (let i = n - 1; i >= 0; i--) {
        for (let j = n - 1; j >= 0; j--) {
            if (word[i] !== word[j]) {
                if (lcp[i][j] !== 0) {
                    return "";
                }
            } else {
                if (i === n - 1 || j === n - 1) {
                    if (lcp[i][j] !== 1) {
                        return "";
                    }
                } else {
                    if (lcp[i][j] !== lcp[i + 1][j + 1] + 1) {
                        return "";
                    }
                }
            }
        }
    }

    return word.join('');
}
```

```Rust
impl Solution {
    pub fn find_the_string(lcp: Vec<Vec<i32>>) -> String {
        let n = lcp.len();
        let mut word = vec!['\0'; n];
        let mut current = b'a';

        // 依次从 'a' 到 'z' 开始构造字符串
        for i in 0..n {
            if word[i] == '\0' {
                if current > b'z' {
                    return String::new();
                }
                word[i] = current as char;
                for j in i + 1..n {
                    if lcp[i][j] > 0 {
                        word[j] = word[i];
                    }
                }
                current += 1;
            }
        }

        // 验证构造的字符串是否满足 LCP 矩阵要求
        for i in (0..n).rev() {
            for j in (0..n).rev() {
                if word[i] != word[j] {
                    if lcp[i][j] != 0 {
                        return String::new();
                    }
                } else {
                    if i == n - 1 || j == n - 1 {
                        if lcp[i][j] != 1 {
                            return String::new();
                        }
                    } else {
                        if lcp[i][j] != lcp[i + 1][j + 1] + 1 {
                            return String::new();
                        }
                    }
                }
            }
        }

        word.iter().collect()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 表示矩阵 $lcp$ 的行数与列数。构造字符串需要的时间为 $O(n^2)$，验证构造的字符串是否满足 $lcp$ 需要的时间为 $O(n^2)$，因此总的时间复杂度为 $O(n^2)$。
- 空间复杂度：$O(1)$。除返回值外，不需要额外的空间。
