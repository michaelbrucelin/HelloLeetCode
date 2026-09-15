### [不重叠回文子字符串的最大数目](https://leetcode.cn/problems/maximum-number-of-non-overlapping-palindrome-substrings/solutions/4022616/bu-zhong-die-hui-wen-zi-zi-fu-chuan-de-z-ryml/)

#### 方法一：动态规划

**思路与算法**

我们先预处理字符串中的所有回文子字符串。用二维数组 $isPalindrome[i][j]$ 表示子字符串 $s[i\dots j]$ 是否为回文串。根据回文串的性质，有如下状态转移方程：

$$isPalindrome[i][j]=(s[i]=s[j])\wedge (j-i\le 1\vee isPalindrome[i+1][j-1])$$

由于计算一个区间时需要用到它内部的区间，因此按照区间长度从小到大的顺序进行枚举。

接下来用 $dp[i]$ 表示在前 $i$ 个字符 $s[0\dots i-1]$ 中，最多可以选择多少个长度不小于 $k$ 且互不重叠的回文子字符串。

对于前 $i$ 个字符，有两种选择：

- 不选择以 $i-1$ 结尾的回文子字符串，此时 $dp[i]=dp[i-1]$；
- 选择以 $i-1$ 为结尾的回文子字符串，枚举回文子字符串的起点 $j$。如果 $i-j\ge k$ 且 $s[j\dots i-1]$ 是回文串，那么可以在前 $j$ 个字符的最优方案后选择该子字符串，此时用 $dp[j]+1$ 更新 $dp[i]$。

最终 $dp[n]$ 即为答案。

**代码**

```C++
class Solution {
public:
    int maxPalindromes(string s, int k) {
        int n = s.size();
        vector<vector<bool>> isPalindrome(n, vector<bool>(n));

        for (int len = 1; len <= n; ++len) {
            for (int left = 0; left + len <= n; ++left) {
                int right = left + len - 1;
                isPalindrome[left][right] = s[left] == s[right] &&
                    (len <= 2 || isPalindrome[left + 1][right - 1]);
            }
        }

        vector<int> dp(n + 1);
        for (int i = 1; i <= n; ++i) {
            dp[i] = dp[i - 1];
            for (int j = 0; j + k <= i; ++j) {
                if (isPalindrome[j][i - 1]) {
                    dp[i] = max(dp[i], dp[j] + 1);
                }
            }
        }

        return dp[n];
    }
};
```

```Python
class Solution:
    def maxPalindromes(self, s: str, k: int) -> int:
        n = len(s)
        is_palindrome = [[False] * n for _ in range(n)]

        for length in range(1, n + 1):
            for left in range(n - length + 1):
                right = left + length - 1
                is_palindrome[left][right] = (
                    s[left] == s[right]
                    and (length <= 2 or is_palindrome[left + 1][right - 1])
                )

        dp = [0] * (n + 1)
        for i in range(1, n + 1):
            dp[i] = dp[i - 1]
            for j in range(i - k + 1):
                if is_palindrome[j][i - 1]:
                    dp[i] = max(dp[i], dp[j] + 1)

        return dp[n]
```

```Rust
impl Solution {
    pub fn max_palindromes(s: String, k: i32) -> i32 {
        let s = s.as_bytes();
        let n = s.len();
        let k = k as usize;
        let mut is_palindrome = vec![vec![false; n]; n];

        for len in 1..=n {
            for left in 0..=n - len {
                let right = left + len - 1;
                is_palindrome[left][right] = s[left] == s[right]
                    && (len <= 2 || is_palindrome[left + 1][right - 1]);
            }
        }

        let mut dp = vec![0; n + 1];
        for i in 1..=n {
            dp[i] = dp[i - 1];
            if i >= k {
                for j in 0..=i - k {
                    if is_palindrome[j][i - 1] {
                        dp[i] = dp[i].max(dp[j] + 1);
                    }
                }
            }
        }

        dp[n]
    }
}
```

```Java
class Solution {
    public int maxPalindromes(String s, int k) {
        int n = s.length();
        boolean[][] isPalindrome = new boolean[n][n];

        for (int len = 1; len <= n; ++len) {
            for (int left = 0; left + len <= n; ++left) {
                int right = left + len - 1;
                isPalindrome[left][right] = s.charAt(left) == s.charAt(right) &&
                    (len <= 2 || isPalindrome[left + 1][right - 1]);
            }
        }

        int[] dp = new int[n + 1];
        for (int i = 1; i <= n; ++i) {
            dp[i] = dp[i - 1];
            for (int j = 0; j + k <= i; ++j) {
                if (isPalindrome[j][i - 1]) {
                    dp[i] = Math.max(dp[i], dp[j] + 1);
                }
            }
        }

        return dp[n];
    }
}
```

```CSharp
public class Solution {
    public int MaxPalindromes(string s, int k) {
        int n = s.Length;
        bool[,] isPalindrome = new bool[n, n];

        for (int len = 1; len <= n; ++len) {
            for (int left = 0; left + len <= n; ++left) {
                int right = left + len - 1;
                isPalindrome[left, right] = s[left] == s[right] &&
                    (len <= 2 || isPalindrome[left + 1, right - 1]);
            }
        }

        int[] dp = new int[n + 1];
        for (int i = 1; i <= n; ++i) {
            dp[i] = dp[i - 1];
            for (int j = 0; j + k <= i; ++j) {
                if (isPalindrome[j, i - 1]) {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        return dp[n];
    }
}
```

```Go
func maxPalindromes(s string, k int) int {
    n := len(s)
    isPalindrome := make([][]bool, n)
    for i := range isPalindrome {
        isPalindrome[i] = make([]bool, n)
    }

    for length := 1; length <= n; length++ {
        for left := 0; left+length <= n; left++ {
            right := left + length - 1
            isPalindrome[left][right] = s[left] == s[right] &&
                (length <= 2 || isPalindrome[left+1][right-1])
        }
    }

    dp := make([]int, n+1)
    for i := 1; i <= n; i++ {
        dp[i] = dp[i-1]
        for j := 0; j+k <= i; j++ {
            if isPalindrome[j][i-1] {
                dp[i] = max(dp[i], dp[j]+1)
            }
        }
    }

    return dp[n]
}
```

```C
int maxPalindromes(char* s, int k) {
    int n = strlen(s);
    bool** isPalindrome = (bool**)malloc(n * sizeof(bool*));
    for (int i = 0; i < n; i++) {
        isPalindrome[i] = (bool*)calloc(n, sizeof(bool));
    }

    for (int len = 1; len <= n; ++len) {
        for (int left = 0; left + len <= n; ++left) {
            int right = left + len - 1;
            isPalindrome[left][right] = (s[left] == s[right]) &&
                (len <= 2 || isPalindrome[left + 1][right - 1]);
        }
    }

    int* dp = (int*)calloc(n + 1, sizeof(int));
    for (int i = 1; i <= n; ++i) {
        dp[i] = dp[i - 1];
        for (int j = 0; j + k <= i; ++j) {
            if (isPalindrome[j][i - 1]) {
                dp[i] = dp[i] > dp[j] + 1 ? dp[i] : dp[j] + 1;
            }
        }
    }

    int result = dp[n];

    for (int i = 0; i < n; i++) {
        free(isPalindrome[i]);
    }
    free(isPalindrome);
    free(dp);

    return result;
}
```

```JavaScript
var maxPalindromes = function(s, k) {
    const n = s.length;
    const isPalindrome = Array.from({ length: n }, () => Array(n).fill(false));

    for (let len = 1; len <= n; ++len) {
        for (let left = 0; left + len <= n; ++left) {
            const right = left + len - 1;
            isPalindrome[left][right] = s[left] === s[right] &&
                (len <= 2 || isPalindrome[left + 1][right - 1]);
        }
    }

    const dp = Array(n + 1).fill(0);
    for (let i = 1; i <= n; ++i) {
        dp[i] = dp[i - 1];
        for (let j = 0; j + k <= i; ++j) {
            if (isPalindrome[j][i - 1]) {
                dp[i] = Math.max(dp[i], dp[j] + 1);
            }
        }
    }

    return dp[n];
};
```

```TypeScript
function maxPalindromes(s: string, k: number): number {
    const n = s.length;
    const isPalindrome: boolean[][] = Array.from({ length: n }, () => Array(n).fill(false));

    for (let len = 1; len <= n; ++len) {
        for (let left = 0; left + len <= n; ++left) {
            const right = left + len - 1;
            isPalindrome[left][right] = s[left] === s[right] &&
                (len <= 2 || isPalindrome[left + 1][right - 1]);
        }
    }

    const dp: number[] = Array(n + 1).fill(0);
    for (let i = 1; i <= n; ++i) {
        dp[i] = dp[i - 1];
        for (let j = 0; j + k <= i; ++j) {
            if (isPalindrome[j][i - 1]) {
                dp[i] = Math.max(dp[i], dp[j] + 1);
            }
        }
    }

    return dp[n];
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是字符串 $s$ 的长度。预处理回文区间和计算 $dp$ 均需要 $O(n^2)$ 的时间。
- 空间复杂度：$O(n^2)$，二维数组 $isPalindrome$ 需要 $O(n^2)$ 的空间，$dp$ 数组需要 $O(n)$ 的空间。

#### 方法二：贪心

**思路与算法**

为了选出尽可能多的不重叠子字符串，对于当前还未使用的后缀，应当优先选择**结束位置最早**的合法回文子字符串。选择它之后，剩余后缀不会比选择其他结束位置更晚的回文子字符串短，因此这种贪心选择不会使答案变差。

接下来说明为什么只需要检查长度为 $k$ 和 $k+1$ 的回文子字符串。

如果存在一个长度大于 $k+1$ 的回文子字符串，删除它的首尾字符后仍然是回文串。重复这一过程，一定可以得到长度为 $k$ 或 $k+1$ 的回文子字符串。这个更短的回文子字符串位于原串内部，其结束位置还会更早。因此在寻找最早结束的合法回文子字符串时，只检查长度为 $k$ 和 $k+1$ 的情况即可。

我们从左到右枚举结束位置 $i$，并用 $start$ 表示下一个被选择的子字符串可以使用的最小下标。对于每个 $i$，依次检查：

- $s[i-k+1\dots i]$ 是否为回文串；
- $s[i-k\dots i]$ 是否为回文串。

如果其中一个子字符串合法且没有越过 $start$，就选择它，将答案加一，并令 $start=i+1$。这样之后选择的子字符串一定不会与它重叠。

**代码**

```C++
class Solution {
public:
    int maxPalindromes(string s, int k) {
        int n = s.size();
        int ans = 0, start = 0;

        auto check = [&](int l, int r) {
            while (l < r) {
                if (s[l++] != s[r--]) {
                    return false;
                }
            }
            return true;
        };

        for (int r = k - 1; r < n; ++r) {
            int l = r - k + 1;
            if (l >= start && check(l, r)) {
                ++ans;
                start = r + 1;
                continue;
            }

            l = r - k;
            if (l >= start && check(l, r)) {
                ++ans;
                start = r + 1;
            }
        }

        return ans;
    }
};
```

```Python
class Solution:
    def maxPalindromes(self, s: str, k: int) -> int:
        def check(l: int, r: int) -> bool:
            while l < r:
                if s[l] != s[r]:
                    return False
                l += 1
                r -= 1
            return True

        n = len(s)
        ans = 0
        start = 0

        for r in range(k - 1, n):
            l = r - k + 1
            if l >= start and check(l, r):
                ans += 1
                start = r + 1
                continue

            l = r - k
            if l >= start and check(l, r):
                ans += 1
                start = r + 1

        return ans
```

```Rust
impl Solution {
    pub fn max_palindromes(s: String, k: i32) -> i32 {
        fn check(s: &[u8], mut l: usize, mut r: usize) -> bool {
            while l < r {
                if s[l] != s[r] {
                    return false;
                }
                l += 1;
                r -= 1;
            }
            true
        }

        let s = s.as_bytes();
        let n = s.len();
        let k = k as usize;
        let mut ans = 0;
        let mut start = 0;

        for r in k - 1..n {
            let mut l = r + 1 - k;
            if l >= start && check(s, l, r) {
                ans += 1;
                start = r + 1;
                continue;
            }

            if r >= k {
                l = r - k;
                if l >= start && check(s, l, r) {
                    ans += 1;
                    start = r + 1;
                }
            }
        }

        ans
    }
}
```

```Java
class Solution {
    public int maxPalindromes(String s, int k) {
        int n = s.length();
        int ans = 0, start = 0;

        for (int r = k - 1; r < n; ++r) {
            int l = r - k + 1;
            if (l >= start && check(s, l, r)) {
                ++ans;
                start = r + 1;
                continue;
            }

            l = r - k;
            if (l >= start && check(s, l, r)) {
                ++ans;
                start = r + 1;
            }
        }

        return ans;
    }

    private boolean check(String s, int l, int r) {
        while (l < r) {
            if (s.charAt(l++) != s.charAt(r--)) {
                return false;
            }
        }
        return true;
    }
}
```

```CSharp
public class Solution {
    public int MaxPalindromes(string s, int k) {
        int n = s.Length;
        int ans = 0, start = 0;

        for (int r = k - 1; r < n; ++r) {
            int l = r - k + 1;
            if (l >= start && Check(s, l, r)) {
                ++ans;
                start = r + 1;
                continue;
            }

            l = r - k;
            if (l >= start && Check(s, l, r)) {
                ++ans;
                start = r + 1;
            }
        }

        return ans;
    }

    private bool Check(string s, int l, int r) {
        while (l < r) {
            if (s[l++] != s[r--]) {
                return false;
            }
        }
        return true;
    }
}
```

```Go
func maxPalindromes(s string, k int) int {
    n := len(s)
    ans, start := 0, 0

    check := func(l, r int) bool {
        for l < r {
            if s[l] != s[r] {
                return false
            }
            l++
            r--
        }
        return true
    }

    for r := k - 1; r < n; r++ {
        l := r - k + 1
        if l >= start && check(l, r) {
            ans++
            start = r + 1
            continue
        }

        l = r - k
        if l >= start && check(l, r) {
            ans++
            start = r + 1
        }
    }

    return ans
}
```

```C
bool check(char* s, int l, int r) {
    while (l < r) {
        if (s[l++] != s[r--]) {
            return false;
        }
    }
    return true;
}

int maxPalindromes(char* s, int k) {
    int n = strlen(s);
    int ans = 0, start = 0;

    for (int r = k - 1; r < n; ++r) {
        int l = r - k + 1;
        if (l >= start && check(s, l, r)) {
            ++ans;
            start = r + 1;
            continue;
        }

        l = r - k;
        if (l >= start && check(s, l, r)) {
            ++ans;
            start = r + 1;
        }
    }

    return ans;
}
```

```JavaScript
var maxPalindromes = function(s, k) {
    const n = s.length;
    let ans = 0, start = 0;

    const check = (l, r) => {
        while (l < r) {
            if (s[l++] !== s[r--]) {
                return false;
            }
        }
        return true;
    };

    for (let r = k - 1; r < n; ++r) {
        let l = r - k + 1;
        if (l >= start && check(l, r)) {
            ++ans;
            start = r + 1;
            continue;
        }

        l = r - k;
        if (l >= start && check(l, r)) {
            ++ans;
            start = r + 1;
        }
    }

    return ans;
};
```

```TypeScript
function maxPalindromes(s: string, k: number): number {
    const n = s.length;
    let ans = 0, start = 0;

    const check = (l: number, r: number): boolean => {
        while (l < r) {
            if (s[l++] !== s[r--]) {
                return false;
            }
        }
        return true;
    };

    for (let r = k - 1; r < n; ++r) {
        let l = r - k + 1;
        if (l >= start && check(l, r)) {
            ++ans;
            start = r + 1;
            continue;
        }

        l = r - k;
        if (l >= start && check(l, r)) {
            ++ans;
            start = r + 1;
        }
    }

    return ans;
}
```

**复杂度分析**

- 时间复杂度：$O(nk)$，其中 $n$ 是字符串 $s$ 的长度。每个结束位置至多检查两个长度不超过 $k+1$ 的子字符串。
- 空间复杂度：$O(1)$，仅使用常数个额外变量。
