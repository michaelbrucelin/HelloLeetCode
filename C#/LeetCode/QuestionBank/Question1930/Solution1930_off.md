### [长度为 3 的不同回文子序列](https://leetcode.cn/problems/unique-length-3-palindromic-subsequences/solutions/870024/chang-du-wei-3-de-bu-tong-hui-wen-zi-xu-21trj/)

#### 方法一：枚举两侧的字符

**思路与算法**

我们可以枚举回文序列两侧的字符**种类**。对于每种字符，如果它在字符串 $s$ 中出现，我们记录它**第一次**出现的下标 $l$ 与**最后一次**出现的下标 $r$。那么，以该字符为两侧的回文子序列，它中间的字符只可能在 $s[l+1..r-1]$ 中选取；且以该字符为两侧的回文子序列的种数即为 $s[l+1..r-1]$ 中的字符种数。

我们遍历 $s[l+1..r-1]$ 子串计算该子串中的字符种数。在遍历时，我们可以使用哈希集合来维护该子串中的字符种类；当遍历完成后，哈希集合内元素的数目即为该子串中的字符总数。

在枚举两侧字符种类时，我们维护这些回文子序列种数之和，并最终作为答案返回。

**代码**

```C++
class Solution {
public:
    int countPalindromicSubsequence(string s) {
        int n = s.size();
        int res = 0;
        // 枚举两侧字符
        for (char ch = 'a'; ch <= 'z'; ++ch){
            int l = 0, r = n - 1;
            // 寻找该字符第一次出现的下标
            while (l < n && s[l] != ch){
                ++l;
            }
            // 寻找该字符最后一次出现的下标
            while (r >= 0 && s[r] != ch){
                --r;
            }
            if (r - l < 2){
                // 该字符未出现，或两下标中间的子串不存在
                continue;
            }
            // 利用哈希集合统计 s[l+1..r-1] 子串的字符总数，并更新答案
            unordered_set<char> charset;
            for (int k = l + 1; k < r; ++k){
                charset.insert(s[k]);
            }
            res += charset.size();
        }
        return res;
    }
};
```

```Python
class Solution:
    def countPalindromicSubsequence(self, s: str) -> int:
        n = len(s)
        res = 0
        # 枚举两侧字符
        for i in range(26):
            l, r = 0, n - 1
            # 寻找该字符第一次出现的下标
            while l < n and ord(s[l]) - ord('a') != i:
                l += 1
            # 寻找该字符最后一次出现的下标
            while r >= 0 and ord(s[r]) - ord('a') != i:
                r -= 1
            if r - l < 2:
                # 该字符未出现，或两下标中间的子串不存在
                continue
            # 利用哈希集合统计 s[l+1..r-1] 子串的字符总数，并更新答案
            charset = set()
            for k in range(l + 1, r):
                charset.add(s[k])
            res += len(charset)
        return res
```

```Java
class Solution {
    public int countPalindromicSubsequence(String s) {
        int n = s.length();
        int res = 0;
        // 枚举两侧字符
        for (char ch = 'a'; ch <= 'z'; ++ch) {
            int l = 0, r = n - 1;
            // 寻找该字符第一次出现的下标
            while (l < n && s.charAt(l) != ch) {
                ++l;
            }
            // 寻找该字符最后一次出现的下标
            while (r >= 0 && s.charAt(r) != ch) {
                --r;
            }
            if (r - l < 2) {
                // 该字符未出现，或两下标中间的子串不存在
                continue;
            }
            // 利用哈希集合统计 s[l+1..r-1] 子串的字符总数，并更新答案
            Set<Character> charset = new HashSet<>();
            for (int k = l + 1; k < r; ++k) {
                charset.add(s.charAt(k));
            }
            res += charset.size();
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int CountPalindromicSubsequence(string s) {
        int n = s.Length;
        int res = 0;
        // 枚举两侧字符
        for (char ch = 'a'; ch <= 'z'; ++ch) {
            int l = 0, r = n - 1;
            // 寻找该字符第一次出现的下标
            while (l < n && s[l] != ch) {
                ++l;
            }
            // 寻找该字符最后一次出现的下标
            while (r >= 0 && s[r] != ch) {
                --r;
            }
            if (r - l < 2) {
                // 该字符未出现，或两下标中间的子串不存在
                continue;
            }
            // 利用哈希集合统计 s[l+1..r-1] 子串的字符总数，并更新答案
            HashSet<char> charset = new HashSet<char>();
            for (int k = l + 1; k < r; ++k) {
                charset.Add(s[k]);
            }
            res += charset.Count;
        }
        return res;
    }
}
```

```Go
func countPalindromicSubsequence(s string) int {
    n := len(s)
    res := 0
    // 枚举两侧字符
    for ch := 'a'; ch <= 'z'; ch++ {
        l, r := 0, n-1
        // 寻找该字符第一次出现的下标
        for l < n && rune(s[l]) != ch {
            l++
        }
        // 寻找该字符最后一次出现的下标
        for r >= 0 && rune(s[r]) != ch {
            r--
        }
        if r-l < 2 {
            // 该字符未出现，或两下标中间的子串不存在
            continue
        }
        // 利用哈希集合统计 s[l+1..r-1] 子串的字符总数，并更新答案
        charset := make(map[rune]bool)
        for _, c := range s[l+1:r] {
            charset[c] = true
        }
        res += len(charset)
    }
    return res
}
```

```C
int countPalindromicSubsequence(char* s) {
    int n = strlen(s);
    int res = 0;
    // 枚举两侧字符
    for (char ch = 'a'; ch <= 'z'; ++ch) {
        int l = 0, r = n - 1;
        // 寻找该字符第一次出现的下标
        while (l < n && s[l] != ch) {
            ++l;
        }
        // 寻找该字符最后一次出现的下标
        while (r >= 0 && s[r] != ch) {
            --r;
        }
        if (r - l < 2) {
            // 该字符未出现，或两下标中间的子串不存在
            continue;
        }
        // 利用哈希集合统计 s[l+1..r-1] 子串的字符总数，并更新答案
        bool charset[26] = {false};
        for (int k = l + 1; k < r; ++k) {
            charset[s[k] - 'a'] = true;
        }
        int count = 0;
        for (int i = 0; i < 26; ++i) {
            if (charset[i]) {
                count++;
            }
        }
        res += count;
    }
    return res;
}
```

```JavaScript
var countPalindromicSubsequence = function(s) {
    const n = s.length;
    let res = 0;
    // 枚举两侧字符
    for (let ch = 'a'.charCodeAt(0); ch <= 'z'.charCodeAt(0); ch++) {
        const c = String.fromCharCode(ch);
        let l = 0, r = n - 1;
        // 寻找该字符第一次出现的下标
        while (l < n && s[l] !== c) {
            ++l;
        }
        // 寻找该字符最后一次出现的下标
        while (r >= 0 && s[r] !== c) {
            --r;
        }
        if (r - l < 2) {
            // 该字符未出现，或两下标中间的子串不存在
            continue;
        }
        // 利用哈希集合统计 s[l+1..r-1] 子串的字符总数，并更新答案
        const charset = new Set();
        for (let k = l + 1; k < r; k++) {
            charset.add(s[k]);
        }
        res += charset.size;
    }
    return res;
};
```

```TypeScript
function countPalindromicSubsequence(s: string): number {
    const n = s.length;
    let res = 0;
    // 枚举两侧字符
    for (let ch = 'a'.charCodeAt(0); ch <= 'z'.charCodeAt(0); ch++) {
        const c = String.fromCharCode(ch);
        let l = 0, r = n - 1;
        // 寻找该字符第一次出现的下标
        while (l < n && s[l] !== c) {
            ++l;
        }
        // 寻找该字符最后一次出现的下标
        while (r >= 0 && s[r] !== c) {
            --r;
        }
        if (r - l < 2) {
            // 该字符未出现，或两下标中间的子串不存在
            continue;
        }
        // 利用哈希集合统计 s[l+1..r-1] 子串的字符总数，并更新答案
        const charset = new Set<string>();
        for (let k = l + 1; k < r; k++) {
            charset.add(s[k]);
        }
        res += charset.size;
    }
    return res;
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn count_palindromic_subsequence(s: String) -> i32 {
        let mut res = 0;
        // 枚举两侧字符
        for ch in 'a'..='z' {
            // 使用迭代器找到第一个和最后一个出现位置
            let mut chars = s.chars();
            let l = chars.position(|c| c == ch);
            let r = chars.rev().position(|c| c == ch).map(|pos| s.len() - 1 - pos);
            if let (Some(l), Some(r)) = (l, r) {
                if r > l + 1 {
                    // 收集中间字符
                    let unique_chars: HashSet<_> = s[l+1..r].chars().collect();
                    res += unique_chars.len() as i32;
                }
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\vert \sum \vert +\vert \sum \vert^2)$，其中 $n$ 为 $s$ 的长度，$\vert \sum \vert $ 为字符集的大小。我们总共需要枚举 $\vert \sum \vert $ 种字符，每次枚举至多需要遍历一次字符串 $s$ 与哈希集合，时间复杂度分别为 $O(n)$ 与 $O(\vert \sum \vert )$。
- 空间复杂度：$O(\vert \sum \vert )$，即为哈希集合的空间开销。

#### 方法二：枚举中间的字符

**思路与算法**

我们也可以遍历字符串 $s$ 枚举回文子序列中间的字符。假设 $s$ 的长度为 $n$，当我们遍历到 $s[i]$ 时，以 $s[i]$ 为中间字符的回文子序列种数即为前缀 $s[0..i-1]$ 与后缀 $s[i+1..n-1]$ 的公共字符种数。

对于一个任意的子串，由于其仅由小写英文字母组成，我们可以用一个 $32$ 位整数来表示该子串含有哪些字符。如果该整数从低到高第 $i$ 个二进制位为 $1$，那么代表该子串含有字典序为 $i$ 的小写英文字母。在遍历该子串时，我们需要用**按位或**来维护该整数。

为了简化计算，我们可以参照前文所述的对应关系，用两个 $32$ 位整数的数组 $pre,suf$ 分别维护 $s$ 中前缀与后缀包含的字符。其中，$pre[i]$ 代表前缀 $s[0..i-1]$ 包含的字符种类，$suf[i]$ 代表后缀 $s[i+1..n-1]$ 包含的字符种类。那么，以 $s[i]$ 为中间字符的回文子序列中，两侧字符的种类对应的状态即为 $pre[i] \& suf[i]$，其中 $\&$ 为**按位与**运算符。

为了避免重复计算，我们需要在遍历的同时使用**按位或**来维护**每种**字符为中间字符的回文子序列种数。最终，我们将不同种类字符对应的回文子序列总数求和作为答案返回。

**代码**

```C++
class Solution {
public:
    int countPalindromicSubsequence(string s) {
        int n = s.size();
        int res = 0;
        // 前缀/后缀字符状态数组
        vector<int> pre(n), suf(n);
        for (int i = 0; i < n; ++i) {
            // 前缀 s[0..i-1] 包含的字符种类
            pre[i] = (i ? pre[i - 1] : 0) | (1 << (s[i] - 'a'));
        }
        for (int i = n - 1; i >= 0; --i) {
            // 后缀 s[i+1..n-1] 包含的字符种类
            suf[i] = (i != n - 1 ? suf[i + 1] : 0) | (1 << (s[i] - 'a'));
        }
        // 每种中间字符的回文子序列状态数组
        vector<int> ans(26);
        for (int i = 1; i < n - 1; ++i) {
            ans[s[i]-'a'] |= (pre[i - 1] & suf[i + 1]);
        }
        // 更新答案
        for (int i = 0; i < 26; ++i) {
            res += __builtin_popcount(ans[i]);
        }
        return res;
    }
};
```

```Python
class Solution:
    def countPalindromicSubsequence(self, s: str) -> int:
        n = len(s)
        res = 0
        # 前缀/后缀字符状态数组
        pre = [0] * n
        suf = [0] * n
        for i in range(n):
            # 前缀 s[0..i-1] 包含的字符种类
            pre[i] = (pre[i - 1] if i else 0) | (1 << (ord(s[i]) - ord('a')))
        for i in range(n - 1, -1, -1):
            # 后缀 s[i+1..n-1] 包含的字符种类
            suf[i] = (suf[i + 1] if i != n - 1 else 0) | (1 << (ord(s[i]) - ord('a')))
        # 每种中间字符的回文子序列状态数组
        ans = [0] * 26
        for i in range(1, n - 1):
            ans[ord(s[i]) - ord('a')] |= pre[i - 1] & suf[i + 1]
        # 更新答案
        for i in range(26):
            res += bin(ans[i]).count("1")
        return res
```

```Java
class Solution {
    public int countPalindromicSubsequence(String s) {
        int n = s.length();
        int res = 0;
        // 前缀/后缀字符状态数组
        int[] pre = new int[n];
        int[] suf = new int[n];
        for (int i = 0; i < n; ++i) {
            // 前缀 s[0..i-1] 包含的字符种类
            pre[i] = (i > 0 ? pre[i - 1] : 0) | (1 << (s.charAt(i) - 'a'));
        }
        for (int i = n - 1; i >= 0; --i) {
            // 后缀 s[i+1..n-1] 包含的字符种类
            suf[i] = (i != n - 1 ? suf[i + 1] : 0) | (1 << (s.charAt(i) - 'a'));
        }
        // 每种中间字符的回文子序列状态数组
        int[] ans = new int[26];
        for (int i = 1; i < n - 1; ++i) {
            ans[s.charAt(i) - 'a'] |= (pre[i - 1] & suf[i + 1]);
        }
        // 更新答案
        for (int i = 0; i < 26; ++i) {
            res += Integer.bitCount(ans[i]);
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int CountPalindromicSubsequence(string s) {
        int n = s.Length;
        int res = 0;
        // 前缀/后缀字符状态数组
        int[] pre = new int[n];
        int[] suf = new int[n];
        for (int i = 0; i < n; ++i) {
            // 前缀 s[0..i-1] 包含的字符种类
            pre[i] = (i > 0 ? pre[i - 1] : 0) | (1 << (s[i] - 'a'));
        }
        for (int i = n - 1; i >= 0; --i) {
            // 后缀 s[i+1..n-1] 包含的字符种类
            suf[i] = (i != n - 1 ? suf[i + 1] : 0) | (1 << (s[i] - 'a'));
        }
        // 每种中间字符的回文子序列状态数组
        int[] ans = new int[26];
        for (int i = 1; i < n - 1; ++i) {
            ans[s[i] - 'a'] |= (pre[i - 1] & suf[i + 1]);
        }
        // 更新答案
        for (int i = 0; i < 26; ++i) {
            res += BitOperations.PopCount((uint)ans[i]);
        }
        return res;
    }
}
```

```Go
func countPalindromicSubsequence(s string) int {
    n := len(s)
    res := 0
    // 前缀/后缀字符状态数组
    pre := make([]int, n)
    suf := make([]int, n)
    for i := 0; i < n; i++ {
        // 前缀 s[0..i-1] 包含的字符种类
        if i > 0 {
            pre[i] = pre[i-1]
        }
        pre[i] |= 1 << (s[i] - 'a')
    }
    for i := n - 1; i >= 0; i-- {
        // 后缀 s[i+1..n-1] 包含的字符种类
        if i != n - 1 {
            suf[i] = suf[i + 1]
        }
        suf[i] |= 1 << (s[i] - 'a')
    }
    // 每种中间字符的回文子序列状态数组
    ans := make([]int, 26)
    for i := 1; i < n - 1; i++ {
        ans[s[i] - 'a'] |= (pre[i - 1] & suf[i + 1])
    }
    // 更新答案
    for i := 0; i < 26; i++ {
        res += bits.OnesCount(uint(ans[i]))
    }
    return res
}
```

```C
int countPalindromicSubsequence(char* s) {
    int n = strlen(s);
    int res = 0;
    // 前缀/后缀字符状态数组
    int pre[n], suf[n];
    for (int i = 0; i < n; ++i) {
        // 前缀 s[0..i-1] 包含的字符种类
        pre[i] = (i ? pre[i - 1] : 0) | (1 << (s[i] - 'a'));
    }
    for (int i = n - 1; i >= 0; --i) {
        // 后缀 s[i+1..n-1] 包含的字符种类
        suf[i] = (i != n - 1 ? suf[i + 1] : 0) | (1 << (s[i] - 'a'));
    }
    // 每种中间字符的回文子序列状态数组
    int ans[26] = {0};
    for (int i = 1; i < n - 1; ++i) {
        ans[s[i] - 'a'] |= (pre[i - 1] & suf[i + 1]);
    }
    // 更新答案
    for (int i = 0; i < 26; ++i) {
        res += __builtin_popcount(ans[i]);
    }
    return res;
}
```

```JavaScript
var countPalindromicSubsequence = function(s) {
    const n = s.length;
    let res = 0;
    // 前缀/后缀字符状态数组
    const pre = new Array(n).fill(0);
    const suf = new Array(n).fill(0);
    for (let i = 0; i < n; ++i) {
        // 前缀 s[0..i-1] 包含的字符种类
        pre[i] = (i > 0 ? pre[i - 1] : 0) | (1 << (s.charCodeAt(i) - 97));
    }
    for (let i = n - 1; i >= 0; --i) {
        // 后缀 s[i+1..n-1] 包含的字符种类
        suf[i] = (i !== n - 1 ? suf[i + 1] : 0) | (1 << (s.charCodeAt(i) - 97));
    }
    // 每种中间字符的回文子序列状态数组
    const ans = new Array(26).fill(0);
    for (let i = 1; i < n - 1; ++i) {
        ans[s.charCodeAt(i) - 97] |= (pre[i-1] & suf[i + 1]);
    }
    // 更新答案
    for (let i = 0; i < 26; ++i) {
        res += ans[i].toString(2).split('1').length - 1;
    }
    return res;
};
```

```TypeScript
function countPalindromicSubsequence(s: string): number {
    const n = s.length;
    let res = 0;
    // 前缀/后缀字符状态数组
    const pre: number[] = new Array(n).fill(0);
    const suf: number[] = new Array(n).fill(0);
    for (let i = 0; i < n; ++i) {
        // 前缀 s[0..i-1] 包含的字符种类
        pre[i] = (i > 0 ? pre[i - 1] : 0) | (1 << (s.charCodeAt(i) - 97));
    }
    for (let i = n - 1; i >= 0; --i) {
        // 后缀 s[i+1..n-1] 包含的字符种类
        suf[i] = (i !== n - 1 ? suf[i + 1] : 0) | (1 << (s.charCodeAt(i) - 97));
    }
    // 每种中间字符的回文子序列状态数组
    const ans: number[] = new Array(26).fill(0);
    for (let i = 1; i < n - 1; ++i) {
        ans[s.charCodeAt(i) - 97] |= (pre[i - 1] & suf[i + 1]);
    }
    // 更新答案
    for (let i = 0; i < 26; ++i) {
        res += ans[i].toString(2).split('1').length - 1;
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn count_palindromic_subsequence(s: String) -> i32 {
        let n = s.len();
        let mut res = 0;
        // 前缀/后缀字符状态数组
        let mut pre = vec![0u32; n];
        let mut suf = vec![0u32; n];
        
        for (i, c) in s.chars().enumerate() {
            // 前缀 s[0..i-1] 包含的字符种类
            pre[i] = if i > 0 { pre[i-1] } else { 0 } | (1 << (c as u8 - b'a'));
        }
        for (i, c) in s.chars().rev().enumerate() {
            let i = n - 1 - i;
            // 后缀 s[i+1..n-1] 包含的字符种类
            suf[i] = if i != n - 1 { suf[i+1] } else { 0 } | (1 << (c as u8 - b'a'));
        }
        
        // 每种中间字符的回文子序列状态数组
        let mut ans = vec![0u32; 26];
        for (i, c) in s.chars().enumerate() {
            if i > 0 && i < n - 1 {
                ans[(c as u8 - b'a') as usize] |= pre[i-1] & suf[i+1];
            }
        }
        
        // 更新答案
        for &count in &ans {
            res += count.count_ones() as i32;
        } 
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+\vert \sum \vert )$，其中 $n$ 为 $s$ 的长度，$\vert \sum \vert $ 为字符集的大小。预处理前后缀状态数组与遍历 $s$ 更新每种字符状态数组的时间复杂度均为 $O(n)$，初始化每种字符状态数组与更新答案的时间复杂度均为 $O(\vert \sum \vert )$。
- 空间复杂度：$O(\vert \sum \vert )$，即为每种字符状态数组的空间开销。
