### [三种方法：DP / 贪心 / Manacher 优化（Python/Java/C++/Go）](https://leetcode.cn/problems/maximum-number-of-non-overlapping-palindrome-substrings/solutions/1965456/zhong-xin-kuo-zhan-dppythonjavacgo-by-en-1yt1/)

#### 方法一：划分型 DP

按照 [动态规划题单](https://leetcode.cn/discuss/post/3581838/fen-xiang-gun-ti-dan-dong-tai-gui-hua-ru-007o/)「§5.2 最优划分」的套路，定义 $f[i]$ 表示从 $s$ 的前缀 $[0,i-1]$ 中选出的回文子串的最大数目。

- 如果不选 $s[i-1]$，子问题为从 $s$ 的前缀 $[0,i-2]$ 中选出的回文子串的最大数目，即 $f[i-1]$。
- 如果选 $s[i-1]$，枚举子串的左端点 $L$，必须满足子串长度 $i-L\ge k$ 且子串 $[L,i-1]$ 是回文的。子问题为从 $s$ 的前缀 $[0,L-1]$ 中选出的回文子串的最大数目，即 $f[L]$。把 $f[L]$ 加上 $1$，更新 $f[i]$ 的最大值。

初始值：$f[0]=f[1]=\dots =f[k-1]=0$。前缀长度不足 $k$，无法选出任何回文子串。

答案：$f[n]$。

##### 优化

对于一个长为 $m$ 的回文串，去掉其最左边和最右边的字母，剩下的长为 $m-2$ 的字符串仍然是回文串。例如 $abcba$ 包含 $bcb$，$abccba$ 包含 $bccb$。

如果我们选择了长为 $k+2,k+4,\dots$ 的回文子串，那么其内部更短的长为 $k$ 的回文子串也可以选，且这样做，**剩余的前缀长度更长，可以选出更多（或相等）的回文子串**。同理，如果我们选择了长为 $k+3,k+5,\dots$ 的回文子串，那么其内部更短的长为 $k+1$ 的回文子串也可以选。

所以只需考虑长为 $k$ 或者 $k+1$ 的回文子串。

```Python
class Solution:
    def maxPalindromes(self, s: str, k: int) -> int:
        n = len(s)
        # f[i] 表示从 s[:i] 中选出的回文子串的最大数目
        f = [0] * (n + 1)
        for i in range(k, n + 1):
            f[i] = f[i - 1]  # 不考虑 s[i-1]
            if s[i - k: i] == s[i - k: i][::-1]:
                f[i] = max(f[i], f[i - k] + 1)
            if i > k and s[i - k - 1: i] == s[i - k - 1: i][::-1]:
                f[i] = max(f[i], f[i - k - 1] + 1)
        return f[n]
```

```Python
# 记忆化搜索
class Solution:
    def maxPalindromes(self, s: str, k: int) -> int:
        # 返回从 s[:i] 中选出的回文子串的最大数目
        @cache
        def dfs(i: int) -> int:
            if i < k:
                return 0
            res = dfs(i - 1)  # 不考虑 s[i-1]
            if s[i - k: i] == s[i - k: i][::-1]:
                res = max(res, dfs(i - k) + 1)
            if i > k and s[i - k - 1: i] == s[i - k - 1: i][::-1]:
                res = max(res, dfs(i - k - 1) + 1)
            return res

        return dfs(len(s))
```

```Java
class Solution {
    public int maxPalindromes(String S, int k) {
        char[] s = S.toCharArray();
        int n = s.length;
        // f[i] 表示从 s[0,i-1] 中选出的回文子串的最大数目
        int[] f = new int[n + 1];
        for (int i = k; i <= n; i++) {
            f[i] = f[i - 1]; // 不考虑 s[i-1]
            if (isPalindrome(s, i - k, i - 1)) {
                f[i] = Math.max(f[i], f[i - k] + 1);
            }
            if (i > k && isPalindrome(s, i - k - 1, i - 1)) {
                f[i] = Math.max(f[i], f[i - k - 1] + 1);
            }
        }
        return f[n];
    }

    private boolean isPalindrome(char[] s, int l, int r) {
        while (l < r) {
            if (s[l] != s[r]) {
                return false;
            }
            l++;
            r--;
        }
        return true;
    }
}
```

```C++
class Solution {
    bool is_palindrome(string_view s) {
        int n = s.size();
        for (int i = 0; i < n / 2; i++) {
            if (s[i] != s[n - 1 - i]) {
                return false;
            }
        }
        return true;
    }

public:
    int maxPalindromes(string S, int k) {
        string_view s(S);
        int n = s.size();
        // f[i] 表示从 s[0,i-1] 中选出的回文子串的最大数目
        vector<int> f(n + 1);
        for (int i = k; i <= n; i++) {
            f[i] = f[i - 1]; // 不考虑 s[i-1]
            if (is_palindrome(s.substr(i - k, k))) {
                f[i] = max(f[i], f[i - k] + 1);
            }
            if (i > k && is_palindrome(s.substr(i - k - 1, k + 1))) {
                f[i] = max(f[i], f[i - k - 1] + 1);
            }
        }
        return f[n];
    }
};
```

```Go
func isPalindrome(s string) bool {
    n := len(s)
    for i := range n / 2 {
        if s[i] != s[n-1-i] {
            return false
        }
    }
    return true
}

func maxPalindromes(s string, k int) int {
    n := len(s)
    // f[i] 表示从 s[:i] 中选出的回文子串的最大数目
    f := make([]int, n+1)
    for i := k; i <= n; i++ {
        f[i] = f[i-1] // 不考虑 s[i-1]
        if isPalindrome(s[i-k : i]) {
            f[i] = max(f[i], f[i-k]+1)
        }
        if i > k && isPalindrome(s[i-k-1:i]) {
            f[i] = max(f[i], f[i-k-1]+1)
        }
    }
    return f[n]
}
```

#### 复杂度分析

- 时间复杂度：$O((n-k)k)$，其中 $n$ 是 $s$ 的长度。
- 空间复杂度：$O(n)$。

#### 方法二：划分型贪心

贪心地，第一个回文子串的右端点 $r$ 越小越好，这样剩下的后缀 $[r+1,n-1]$ 更长，能从中选出更多的回文子串。

从 $i=0$ 开始思考：

- 如果长为 $k$ 的子串 $[i,i+k-1]$ 是回文串，那么根据上文的贪心策略，一定要选。问题变成在 $[i+k,n-1]$ 中最多能选出多少个回文子串。把 $i$ 更新为 $i+k$。
- 否则，如果长为 $k+1$ 的子串 $[i,i+k]$ 是回文串，那么根据上文的贪心策略，一定要选。问题变成在 $[i+k+1,n-1]$ 中最多能选出多少个回文子串。把 $i$ 更新为 $i+k+1$。注：如果跳过不选，即使 $[i+1,i+k]$ 是回文串，剩余后缀仍然是 $[i+k+1,n-1]$，并不会更优，所以不需要考虑跳过 $[i,i+k]$ 的情况。
- 否则，问题变成在 $[i+1,n-1]$ 中最多能选出多少个回文子串。把 $i$ 更新为 $i+1$。

```Python
class Solution:
    def maxPalindromes(self, s: str, k: int) -> int:
        n = len(s)
        ans = i = 0
        while i <= n - k:
            if s[i: i + k] == s[i: i + k][::-1]:
                ans += 1
                i += k  # 计算 s[i+k:] 中的最优方案
            elif i < n - k and s[i: i + k + 1] == s[i: i + k + 1][::-1]:
                # 如果跳过不选，即使 s[i+1:i+1+k] 是回文串，剩余内容仍然是 s[i+k+1:]，并不会更优
                # 所以不需要考虑跳过 s[i:i+k+1] 的情况
                ans += 1
                i += k + 1  # 计算 s[i+k+1:] 中的最优方案
            else:
                i += 1  # 计算 s[i+1:] 中的最优方案
        return ans
```

```Python
# 不用切片
class Solution:
    def is_palindrome(self, s: str, l: int, r: int) -> bool:
        while l < r:
            if s[l] != s[r]:
                return False
            l += 1
            r -= 1
        return True

    def maxPalindromes(self, s: str, k: int) -> int:
        n = len(s)
        ans = i = 0
        while i <= n - k:
            if self.is_palindrome(s, i, i + k - 1):
                ans += 1
                i += k  # 计算 s[i+k:] 中的最优方案
            elif i < n - k and self.is_palindrome(s, i, i + k):
                # 如果跳过不选，即使 s[i+1:i+1+k] 是回文串，剩余内容仍然是 s[i+k+1:]，并不会更优
                # 所以不需要考虑跳过 s[i:i+k+1] 的情况
                ans += 1
                i += k + 1  # 计算 s[i+k+1:] 中的最优方案
            else:
                i += 1  # 计算 s[i+1:] 中的最优方案
        return ans
```

```Java
class Solution {
    public int maxPalindromes(String S, int k) {
        char[] s = S.toCharArray();
        int n = s.length;
        int ans = 0;
        for (int i = 0; i <= n - k;) {
            if (isPalindrome(s, i, i + k - 1)) {
                ans++;
                i += k; // 计算 s[i+k,n-1] 中的最优方案
            } else if (i < n - k && isPalindrome(s, i, i + k)) {
                // 如果跳过不选，即使 s[i+1,i+k] 是回文串，剩余内容仍然是 s[i+k+1,n-1]，并不会更优
                // 所以不需要考虑跳过 s[i,i+k] 的情况
                ans++;
                i += k + 1; // 计算 s[i+k+1,n-1] 中的最优方案
            } else {
                i++; // 计算 s[i+1,n-1] 中的最优方案
            }
        }
        return ans;
    }

    private boolean isPalindrome(char[] s, int l, int r) {
        while (l < r) {
            if (s[l] != s[r]) {
                return false;
            }
            l++;
            r--;
        }
        return true;
    }
}
```

```C++
class Solution {
    bool is_palindrome(string_view s) {
        int n = s.size();
        for (int i = 0; i < n / 2; i++) {
            if (s[i] != s[n - 1 - i]) {
                return false;
            }
        }
        return true;
    }

public:
    int maxPalindromes(string S, int k) {
        string_view s(S);
        int n = s.size();
        int ans = 0;
        for (int i = 0; i <= n - k;) {
            if (is_palindrome(s.substr(i, k))) {
                ans++;
                i += k; // 计算 s[i+k,n-1] 中的最优方案
            } else if (i < n - k && is_palindrome(s.substr(i, k + 1))) {
                // 如果跳过不选，即使 s[i+1,i+k] 是回文串，剩余内容仍然是 s[i+k+1,n-1]，并不会更优
                // 所以不需要考虑跳过 s[i,i+k] 的情况
                ans++;
                i += k + 1; // 计算 s[i+k+1,n-1] 中的最优方案
            } else {
                i++; // 计算 s[i+1,n-1] 中的最优方案
            }
        }
        return ans;
    }
};
```

```Go
func isPalindrome(s string) bool {
    n := len(s)
    for i := range n / 2 {
        if s[i] != s[n-1-i] {
            return false
        }
    }
    return true
}

func maxPalindromes(s string, k int) (ans int) {
    n := len(s)
    for i := 0; i <= n-k; {
        if isPalindrome(s[i : i+k]) {
            ans++
            i += k // 计算 s[i+k:] 中的最优方案
        } else if i < n-k && isPalindrome(s[i:i+k+1]) {
            // 如果跳过不选，即使 s[i+1:i+1+k] 是回文串，剩余内容仍然是 s[i+k+1:]，并不会更优
            // 所以不需要考虑跳过 s[i:i+k+1] 的情况
            ans++
            i += k + 1 // 计算 s[i+k+1:] 中的最优方案
        } else {
            i++ // 计算 s[i+1:] 中的最优方案
        }
    }
    return
}
```

#### 复杂度分析

- 时间复杂度：$O((n-k)k)$，其中 $n$ 是 $s$ 的长度。
- 空间复杂度：$O(1)$。

## 方法三：用 $Manacher$ 算法优化

[Manacher 算法原理](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1UcyYY4EnQ%2F)

用 $Manacher$ 算法预处理后，可以 $O(1)$ 判断 $s$ 的任意子串是否为回文串。

```Python
class Solution:
    def maxPalindromes(self, s: str, k: int) -> int:
        # Manacher 模板
        # 将 s 改造为 t，这样就不需要讨论 len(s) 的奇偶性，因为新串 t 的每个回文子串都是奇回文串（都有回文中心）
        # s 和 t 的下标转换关系：
        # (si+1)*2 = ti
        # ti/2-1 = si
        # ti 为偶数，对应奇回文串（从 2 开始）
        # ti 为奇数，对应偶回文串（从 3 开始）
        t = "#".join("^" + s + "$")

        # 定义一个奇回文串的回文半径=(长度+1)/2，即保留回文中心，去掉一侧后的剩余字符串的长度
        # half_len[i] 表示在 t 上的以 t[i] 为回文中心的最长回文子串的回文半径
        # 即 [i-half_len[i]+1, i+half_len[i]-1] 是 t 上的一个回文子串
        half_len = [0] * (len(t) - 2)
        half_len[1] = 1

        # box_r 表示当前右边界下标最大的回文子串的右边界下标+1
        # box_m 为该回文子串的中心位置
        # 二者的关系为 box_r = box_m + half_len[box_m]
        box_m = box_r = 0
        for i in range(2, len(half_len)):
            hl = 1
            if i < box_r:
                # 记 i 关于 box_m 的对称位置 i'=box_m*2-i
                # 若以 i' 为中心的最长回文子串范围超出了以 box_m 为中心的回文串的范围
                # 则 half_len[i] 应先初始化为已知的回文半径 box_r-i，然后再继续暴力匹配
                # 否则 half_len[i] 与 half_len[i'] 相等
                hl = min(box_r - i, half_len[box_m * 2 - i])

            # 暴力扩展
            # 算法的复杂度取决于这部分执行的次数
            # 由于扩展之后 box_r 必然会更新（右移），且扩展的的次数就是 box_r 右移的次数
            # 因此算法的复杂度 = O(len(t)) = O(n)
            while t[i - hl] == t[i + hl]:
                hl += 1
                box_m, box_r = i, i + hl

            half_len[i] = hl

        # 判断子串 s[l:r]（左闭右开）是否为回文串
        def is_palindrome(l: int, r: int) -> bool:
            # 根据下标转换关系得到子串 s[l:r] 在 t 中对应的回文中心下标为 l+r+1
            # t 中回文子串的长度为 hl*2-1
            # 由于其中 '#' 的数量总是比字母的数量多 1
            # 因此其在 s 中对应的回文子串的长度为 hl-1
            return half_len[l + r + 1] > r - l  # half_len[l+r+1]-1 >= r-l

        n = len(s)
        ans = i = 0
        while i <= n - k:
            if is_palindrome(i, i + k):
                ans += 1
                i += k  # 计算 s[i+k:] 中的最优方案
            elif i < n - k and is_palindrome(i, i + k + 1):
                # 如果跳过不选，即使 s[i+1:i+1+k] 是回文串，剩余内容仍然是 s[i+k+1:]，并不会更优
                # 所以不需要考虑跳过 s[i:i+k+1] 的情况
                ans += 1
                i += k + 1  # 计算 s[i+k+1:] 中的最优方案
            else:
                i += 1  # 计算 s[i+1:] 中的最优方案
        return ans
```

```Java
class Solution {
    public int maxPalindromes(String s, int k) {
        // Manacher 模板
        // 将 s 改造为 t，这样就不需要讨论 s.length() 的奇偶性，因为新串 t 的每个回文子串都是奇回文串（都有回文中心）
        // s 和 t 的下标转换关系：
        // (si+1)*2 = ti
        // ti/2-1 = si
        // ti 为偶数，对应奇回文串（从 2 开始）
        // ti 为奇数，对应偶回文串（从 3 开始）
        int n = s.length();
        char[] t = new char[n * 2 + 3];
        Arrays.fill(t, '#');
        t[0] = '^';
        for (int i = 0; i < n; i++) {
            t[i * 2 + 2] = s.charAt(i);
        }
        t[n * 2 + 2] = '$';

        // 定义一个奇回文串的回文半径=(长度+1)/2，即保留回文中心，去掉一侧后的剩余字符串的长度
        // halfLen[i] 表示在 t 上的以 t[i] 为回文中心的最长回文子串的回文半径
        // 即 [i-halfLen[i]+1, i+halfLen[i]-1] 是 t 上的一个回文子串
        int[] halfLen = new int[t.length - 2];
        halfLen[1] = 1;

        // boxR 表示当前右边界下标最大的回文子串的右边界下标+1
        // boxM 为该回文子串的中心位置
        // 二者的关系为 boxR = boxM + halfLen[boxM]
        int boxM = 0;
        int boxR = 0;
        for (int i = 2; i < halfLen.length; i++) {
            int hl = 1;
            if (i < boxR) {
                // 记 i 关于 boxM 的对称位置 i'=boxM*2-i
                // 若以 i' 为中心的最长回文子串范围超出了以 boxM 为中心的回文串的范围
                // 则 halfLen[i] 应先初始化为已知的回文半径 boxR-i，然后再继续暴力匹配
                // 否则 halfLen[i] 与 halfLen[i'] 相等
                hl = Math.min(boxR - i, halfLen[boxM * 2 - i]);
            }

            // 暴力扩展
            // 算法的复杂度取决于这部分执行的次数
            // 由于扩展之后 boxR 必然会更新（右移），且扩展的的次数就是 boxR 右移的次数
            // 因此算法的复杂度 = O(t.length) = O(n)
            while (t[i - hl] == t[i + hl]) {
                hl++;
                boxM = i;
                boxR = i + hl;
            }

            halfLen[i] = hl;
        }

        int ans = 0;
        for (int i = 0; i <= n - k;) {
            if (isPalindrome(halfLen, i, i + k - 1)) {
                ans++;
                i += k; // 计算 s[i+k,n-1] 中的最优方案
            } else if (i < n - k && isPalindrome(halfLen, i, i + k)) {
                // 如果跳过不选，即使 s[i+1,i+k] 是回文串，剩余内容仍然是 s[i+k+1,n-1]，并不会更优
                // 所以不需要考虑跳过 s[i,i+k] 的情况
                ans++;
                i += k + 1; // 计算 s[i+k+1,n-1] 中的最优方案
            } else {
                i++; // 计算 s[i+1,n-1] 中的最优方案
            }
        }
        return ans;
    }

    // 判断 s 的子串 [l,r] 是否为回文串
    private boolean isPalindrome(int[] halfLen, int l, int r) {
        // 根据下标转换关系得到子串 s[l,r] 在 t 中对应的回文中心下标为 l+r+2
        // t 中回文子串的长度为 hl*2-1
        // 由于其中 '#' 的数量总是比字母的数量多 1
        // 因此其在 s 中对应的回文子串的长度为 hl-1
        return halfLen[l + r + 2] > r - l + 1; // halfLen[l+r+2]-1 >= r-l+1
    }
}
```

```C++
class Solution {
public:
    int maxPalindromes(string s, int k) {
        // Manacher 模板
        // 将 s 改造为 t，这样就不需要讨论 s.size() 的奇偶性，因为新串 t 的每个回文子串都是奇回文串（都有回文中心）
        // s 和 t 的下标转换关系：
        // (si+1)*2 = ti
        // ti/2-1 = si
        // ti 为偶数，对应奇回文串（从 2 开始）
        // ti 为奇数，对应偶回文串（从 3 开始）
        string t = "^";
        for (char c : s) {
            t += '#';
            t += c;
        }
        t += "#$";

        // 定义一个奇回文串的回文半径=(长度+1)/2，即保留回文中心，去掉一侧后的剩余字符串的长度
        // half_len[i] 表示在 t 上的以 t[i] 为回文中心的最长回文子串的回文半径
        // 即 [i-half_len[i]+1, i+half_len[i]-1] 是 t 上的一个回文子串
        vector<int> half_len(t.size() - 2);
        half_len[1] = 1;

        // box_r 表示当前右边界下标最大的回文子串的右边界下标+1
        // box_m 为该回文子串的中心位置
        // 二者的关系为 box_r = box_m + half_len[box_m]
        int box_m = 0, box_r = 0;
        for (int i = 2; i < half_len.size(); i++) {
            int hl = 1;
            if (i < box_r) {
                // 记 i 关于 box_m 的对称位置 i'=box_m*2-i
                // 若以 i' 为中心的最长回文子串范围超出了以 box_m 为中心的回文串的范围
                // 则 half_len[i] 应先初始化为已知的回文半径 box_r-i，然后再继续暴力匹配
                // 否则 half_len[i] 与 half_len[i'] 相等
                hl = min(box_r - i, half_len[box_m * 2 - i]);
            }

            // 暴力扩展
            // 算法的复杂度取决于这部分执行的次数
            // 由于扩展之后 box_r 必然会更新（右移），且扩展的的次数就是 box_r 右移的次数
            // 因此算法的复杂度 = O(t.size()) = O(n)
            while (t[i - hl] == t[i + hl]) {
                hl++;
                box_m = i;
                box_r = i + hl;
            }

            half_len[i] = hl;
        }

        // 判断 s 的子串 [l,r] 是否为回文串
        auto is_palindrome = [&](int l, int r) -> bool {
            // 根据下标转换关系得到子串 [l,r] 在 t 中对应的回文中心下标为 l+r+2
            // t 中回文子串的长度为 hl*2-1
            // 由于其中 '#' 的数量总是比字母的数量多 1
            // 因此其在 s 中对应的回文子串的长度为 hl-1
            return half_len[l + r + 2] > r - l + 1; // half_len[l+r+2]-1 >= r-l+1
        };

        int n = s.size();
        int ans = 0;
        for (int i = 0; i <= n - k;) {
            if (is_palindrome(i, i + k - 1)) {
                ans++;
                i += k; // 计算 s[i+k,n-1] 中的最优方案
            } else if (i < n - k && is_palindrome(i, i + k)) {
                // 如果跳过不选，即使 s[i+1,i+k] 是回文串，剩余内容仍然是 s[i+k+1,n-1]，并不会更优
                // 所以不需要考虑跳过 s[i,i+k] 的情况
                ans++;
                i += k + 1; // 计算 s[i+k+1,n-1] 中的最优方案
            } else {
                i++; // 计算 s[i+1,n-1] 中的最优方案
            }
        }
        return ans;
    }
};
```

```Go
func maxPalindromes(s string, k int) (ans int) {
    // Manacher 模板
    // 将 s 改造为 t，这样就不需要讨论 len(s) 的奇偶性，因为新串 t 的每个回文子串都是奇回文串（都有回文中心）
    // s 和 t 的下标转换关系：
    // (si+1)*2 = ti
    // ti/2-1 = si
    // ti 为偶数，对应奇回文串（从 2 开始）
    // ti 为奇数，对应偶回文串（从 3 开始）
    n := len(s)
    t := append(make([]byte, 0, n*2+3), '^')
    for _, c := range s {
        t = append(t, '#', byte(c))
    }
    t = append(t, '#', '$')

    // 定义一个奇回文串的回文半径=(长度+1)/2，即保留回文中心，去掉一侧后的剩余字符串的长度
    // halfLen[i] 表示在 t 上的以 t[i] 为回文中心的最长回文子串的回文半径
    // 即 [i-halfLen[i]+1, i+halfLen[i]-1] 是 t 上的一个回文子串
    halfLen := make([]int, len(t)-2)
    halfLen[1] = 1

    // boxR 表示当前右边界下标最大的回文子串的右边界下标+1
    // boxM 为该回文子串的中心位置
    // 二者的关系为 boxR = boxM + halfLen[boxM]
    boxM, boxR := 0, 0
    for i := 2; i < len(halfLen); i++ {
        hl := 1
        if i < boxR {
            // 记 i 关于 boxM 的对称位置 i'=boxM*2-i
            // 若以 i' 为中心的最长回文子串范围超出了以 boxM 为中心的回文串的范围
            // 则 halfLen[i] 应先初始化为已知的回文半径 boxR-i，然后再继续暴力匹配
            // 否则 halfLen[i] 与 halfLen[i'] 相等
            hl = min(boxR-i, halfLen[boxM*2-i])
        }

        // 暴力扩展
        for t[i-hl] == t[i+hl] {
            hl++
            boxM, boxR = i, i+hl
        }

        halfLen[i] = hl
    }

    // 判断子串 s[l:r]（左闭右开）是否为回文串
    isPalindrome := func(l, r int) bool {
        // 根据下标转换关系得到子串 s[l:r] 在 t 中对应的回文中心下标为 l+r+1
        // t 中回文子串的长度为 hl*2-1
        // 由于其中 '#' 的数量总是比字母的数量多 1
        // 因此其在 s 中对应的回文子串的长度为 hl-1
        return halfLen[l+r+1] > r-l // halfLen[l+r+1]-1 >= r-l
    }

    for i := 0; i <= n-k; {
        if isPalindrome(i, i+k) {
            ans++
            i += k // 计算 s[i+k:] 中的最优方案
        } else if i < n-k && isPalindrome(i, i+k+1) {
            // 如果跳过不选，即使 s[i+1:i+1+k] 是回文串，剩余内容仍然是 s[i+k+1:]，并不会更优
            // 所以不需要考虑跳过 s[i:i+k+1] 的情况
            ans++
            i += k + 1 // 计算 s[i+k+1:] 中的最优方案
        } else {
            i++ // 计算 s[i+1:] 中的最优方案
        }
    }
    return
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是 $s$ 的长度。
- 空间复杂度：$O(n)$。

#### 专题训练

1. 动态规划题单的「**§5.2 最优划分**」。
2. 贪心题单的「**§1.5 划分型贪心**」。
3. 字符串题单的「**三、Manacher 算法**」。

#### 分类题单

[如何科学刷题？](https://leetcode.cn/discuss/post/3141566/ru-he-ke-xue-shua-ti-by-endlesscheng-q3yd/)

1. [滑动窗口与双指针（定长/不定长/单序列/双序列/三指针/分组循环）](https://leetcode.cn/discuss/post/3578981/ti-dan-hua-dong-chuang-kou-ding-chang-bu-rzz7/)
2. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/discuss/post/3579164/ti-dan-er-fen-suan-fa-er-fen-da-an-zui-x-3rqn/)
3. [单调栈（基础/矩形面积/贡献法/最小字典序）](https://leetcode.cn/discuss/post/3579480/ti-dan-dan-diao-zhan-ju-xing-xi-lie-zi-d-u4hk/)
4. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/discuss/post/3580195/fen-xiang-gun-ti-dan-wang-ge-tu-dfsbfszo-l3pa/)
5. [位运算（基础/性质/拆位/试填/恒等式/思维）](https://leetcode.cn/discuss/post/3580371/fen-xiang-gun-ti-dan-wei-yun-suan-ji-chu-nth4/)
6. [图论算法（DFS/BFS/拓扑排序/基环树/最短路/最小生成树/网络流）](https://leetcode.cn/discuss/post/3581143/fen-xiang-gun-ti-dan-tu-lun-suan-fa-dfsb-qyux/)
7. [动态规划（入门/背包/划分/状态机/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/discuss/post/3581838/fen-xiang-gun-ti-dan-dong-tai-gui-hua-ru-007o/)
8. [常用数据结构（前缀和/差分/栈/队列/堆/字典树/并查集/树状数组/线段树）](https://leetcode.cn/discuss/post/3583665/fen-xiang-gun-ti-dan-chang-yong-shu-ju-j-bvmv/)
9. [数学算法（数论/组合/概率期望/博弈/计算几何/随机算法）](https://leetcode.cn/discuss/post/3584388/fen-xiang-gun-ti-dan-shu-xue-suan-fa-shu-gcai/)
10. [贪心与思维（基本贪心策略/反悔/区间/字典序/数学/思维/脑筋急转弯/构造）](https://leetcode.cn/discuss/post/3091107/fen-xiang-gun-ti-dan-tan-xin-ji-ben-tan-k58yb/)
11. [链表、树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA）](https://leetcode.cn/discuss/post/3142882/fen-xiang-gun-ti-dan-lian-biao-er-cha-sh-6srp/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/discuss/post/3144832/fen-xiang-gun-ti-dan-zi-fu-chuan-kmpzhan-ugt4/)
