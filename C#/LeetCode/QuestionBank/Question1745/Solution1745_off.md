### [分割回文串 IV](https://leetcode.cn/problems/palindrome-partitioning-iv/solutions/3088632/fen-ge-hui-wen-chuan-iv-by-leetcode-solu-0cvy/)

#### 方法一：动态规划

**思路**

设字符串的长度为 $n$，首先我们用动态规划算出 $s$ 的任意一个子字符串是否为回文串，并将结果保存在二维数组中。这一步中，我们使用双重循环来计算，第一层循环遍历长度 $length$，从短到长；第二层循环遍历子字符串的起始位置。判断某个子字符串是否为回文时，如果长度为 $1$，则一定为回文；如果长度为 $2$，则判断这两个字符是否相同；如果长度为 $3$，则需要首尾两个字符相同并且剩余的字符串也为回文。每次判断长串时，直接查询已存储的短串状态，避免了重复计算。遍历完成后，所有子串的回文状态均已确定，可在常数时间内查询任意子串是否为回文。

接下来需要判断是否存在三个非空回文子串，拼接起来可以构成完整的 $s$。我们只需要遍历中间子字符串的起始位置和终点位置，这两个位置确定后，三个子串都确定了。如果三个子串都是回文，则返回 $true$，否则返回 $false$。

**代码**

```Java
class Solution {
    public boolean checkPartitioning(String s) {
        int n = s.length();
        boolean[][] isPalindrome = new boolean[n][n];
        for (int length = 1; length < n; length++) {
            for (int start = 0; start <= n - length; start++) {
                int end = start + length - 1;
                if (length == 1) {
                    isPalindrome[start][end] = true;
                }
                else if (length == 2) {
                    isPalindrome[start][end] = (s.charAt(start) == s.charAt(end));
                }
                else {
                    isPalindrome[start][end] = ((s.charAt(start) == s.charAt(end)) && (isPalindrome[start+1][end-1]));
                }
            }
        }
        for (int start = 1; start < n - 1; start ++) {
            if (!isPalindrome[0][start - 1]) {
                continue;
            }
            for (int end = start; end < n - 1; end ++) {
                if (isPalindrome[start][end] && isPalindrome[end + 1][n - 1]) {
                    return true;
                }
            }
        }
        return false;
    }
}
```

```CSharp
public class Solution {
    public bool CheckPartitioning(string s) {
        int n = s.Length;
        bool[,] isPalindrome = new bool[n, n];
        for (int length = 1; length < n; length++) {
            for (int start = 0; start <= n - length; start++) {
                int end = start + length - 1;
                if (length == 1) {
                    isPalindrome[start, end] = true;
                } else if (length == 2) {
                    isPalindrome[start, end] = (s[start] == s[end]);
                } else {
                    isPalindrome[start, end] = (s[start] == s[end]) && isPalindrome[start + 1, end - 1];
                }
            }
        }

        for (int start = 1; start < n - 1; start++) {
            if (!isPalindrome[0, start - 1]) {
                continue;
            }
            for (int end = start; end < n - 1; end++) {
                if (isPalindrome[start, end] && isPalindrome[end + 1, n - 1]) {
                    return true;
                }
            }
        }
        return false;
    }
}
```

```C++
class Solution {
public:
    bool checkPartitioning(string s) {
        int n = s.size();
        vector<vector<bool>> isPalindrome(n, vector<bool>(n));
        for (int length = 1; length < n; length++) {
            for (int start = 0; start <= n - length; start++) {
                int end = start + length - 1;
                if (length == 1) {
                    isPalindrome[start][end] = true;
                } else if (length == 2) {
                    isPalindrome[start][end] = s[start] == s[end];
                } else {
                    isPalindrome[start][end] = s[start] == s[end] && isPalindrome[start + 1][end - 1];
                }
            }
        }
        for (int start = 1; start < n - 1; start++) {
            if (!isPalindrome[0][start - 1]) {
                continue;
            }
            for (int end = start; end < n - 1; end++) {
                if (isPalindrome[start][end] && isPalindrome[end + 1][n - 1]) {
                    return true;
                }
            }
        }
        return false;
    }
};
```

```Go
func checkPartitioning(s string) bool {
    n := len(s)
    isPalindrome := make([][]bool, n)
    for i := 0; i < n; i++ {
        isPalindrome[i] = make([]bool, n)
    }
    for length := 1; length < n; length++ {
        for start := 0; start <= n - length; start++ {
            end := start + length - 1
            if length == 1 {
                isPalindrome[start][end] = true
            } else if length == 2 {
                isPalindrome[start][end] = s[start] == s[end]
            } else {
                isPalindrome[start][end] = s[start] == s[end] && isPalindrome[start + 1][end - 1]
            }
        }
    }
    for start := 1; start < n - 1; start++ {
        if !isPalindrome[0][start - 1] {
            continue
        }
        for end := start; end < n - 1; end++ {
            if isPalindrome[start][end] && isPalindrome[end + 1][n - 1] {
                return true
            }
        }
    }
    return false
}
```

```Python
class Solution:
    def checkPartitioning(self, s: str) -> bool:
        n = len(s)
        isPalindrome = [[False] * n for _ in range(n)]
        for length in range(1, n):
            for start in range(n - length + 1):
                end = start + length - 1
                if length == 1:
                    isPalindrome[start][end] = True
                elif length == 2:
                    isPalindrome[start][end] = s[start] == s[end]
                else:
                    isPalindrome[start][end] = s[start] == s[end] and isPalindrome[start + 1][end - 1]
        for start in range(1, n - 1):
            if not isPalindrome[0][start - 1]:
                continue
            for end in range(start, n - 1):
                if isPalindrome[start][end] and isPalindrome[end + 1][n - 1]:
                    return True
        return False
```

```C
bool checkPartitioning(char* s) {
    int n = strlen(s);
    int **isPalindrome = (int **)malloc(n * sizeof(int *));
    for (int i = 0; i < n; i++) {
        isPalindrome[i] = (int *)malloc(n * sizeof(int));
        memset(isPalindrome[i], 0, n * sizeof(int));
    }
    for (int length = 1; length < n; length++) {
        for (int start = 0; start <= n - length; start++) {
            int end = start + length - 1;
            if (length == 1) {
                isPalindrome[start][end] = true;
            } else if (length == 2) {
                isPalindrome[start][end] = s[start] == s[end];
            } else {
                isPalindrome[start][end] = s[start] == s[end] && isPalindrome[start + 1][end - 1];
            }
        }
    }
    for (int start = 1; start < n - 1; start++) {
        if (!isPalindrome[0][start - 1]) {
            continue;
        }
        for (int end = start; end < n - 1; end++) {
            if (isPalindrome[start][end] && isPalindrome[end + 1][n - 1]) {
                return true;
            }
        }
    }
    for (int i = 0; i < n; i++) {
        free(isPalindrome[i]);
    }
    free(isPalindrome);
    return false;
}
```

```JavaScript
var checkPartitioning = function(s) {
    const n = s.length;
    const isPalindrome = Array.from({ length: n }, () => new Array(n).fill(false));
    for (let length = 1; length < n; length++) {
        for (let start = 0; start <= n - length; start++) {
            const end = start + length - 1;
            if (length === 1) {
                isPalindrome[start][end] = true;
            } else if (length === 2) {
                isPalindrome[start][end] = (s[start] === s[end]);
            } else {
                isPalindrome[start][end] = (s[start] === s[end]) && isPalindrome[start + 1][end - 1];
            }
        }
    }

    for (let start = 1; start < n - 1; start++) {
        if (!isPalindrome[0][start - 1]) {
            continue;
        }
        for (let end = start; end < n - 1; end++) {
            if (isPalindrome[start][end] && isPalindrome[end + 1][n - 1]) {
                return true;
            }
        }
    }
    return false;
}
```

```TypeScript
function checkPartitioning(s: string): boolean {
    const n = s.length;
    const isPalindrome: boolean[][] = Array.from({ length: n }, () => new Array(n).fill(false));
    for (let length = 1; length < n; length++) {
        for (let start = 0; start <= n - length; start++) {
            const end = start + length - 1;
            if (length === 1) {
                isPalindrome[start][end] = true;
            } else if (length === 2) {
                isPalindrome[start][end] = (s[start] === s[end]);
            } else {
                isPalindrome[start][end] = (s[start] === s[end]) && isPalindrome[start + 1][end - 1];
            }
        }
    }

    for (let start = 1; start < n - 1; start++) {
        if (!isPalindrome[0][start - 1]) continue;
        for (let end = start; end < n - 1; end++) {
            if (isPalindrome[start][end] && isPalindrome[end + 1][n - 1]) {
                return true;
            }
        }
    }
    return false;
}
```

```Rust
impl Solution {
    pub fn check_partitioning(s: String) -> bool {
        let n = s.len();
        let chars: Vec<char> = s.chars().collect();
        let mut is_palindrome = vec![vec![false; n]; n];
        for length in 1..n {
            for start in 0..=(n - length) {
                let end = start + length - 1;
                if length == 1 {
                    is_palindrome[start][end] = true;
                } else if length == 2 {
                    is_palindrome[start][end] = chars[start] == chars[end];
                } else {
                    is_palindrome[start][end] = chars[start] == chars[end] && is_palindrome[start + 1][end - 1];
                }
            }
        }

        for start in 1..n - 1 {
            if !is_palindrome[0][start - 1] {
                continue;
            }
            for end in start..n - 1 {
                if is_palindrome[start][end] && is_palindrome[end + 1][n - 1] {
                    return true;
                }
            }
        }
        false
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是字符串 $s$ 的长度。
- 空间复杂度：$O(n^2)$。
