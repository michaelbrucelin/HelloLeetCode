### [字符串转换后的长度 I](https://leetcode.cn/problems/total-characters-in-string-after-transformations-i/solutions/3674706/zi-fu-chuan-zhuan-huan-hou-de-chang-du-i-rw3x/)

#### 方法一：递推

**思路与算法**

我们用 $f(i,c)$ 表示在进行了 $i$ 次转换后，字符串中包含字符 $c$ 的数量。为了叙述方便，这里 $c$ 的取值范围是 $[0,26)$，依次对应从 $a$ 到 $z$ 的 $26$ 个字符。

初始时，所有的 $f(0,c)$ 即为 $c$ 在给定的字符串 $s$ 中出现的次数。当我们从 $f(i-1,\dots)$ 递推到 $f(i,\dots)$ 时：

- 如果 $c=0$，对应 $a$，它可以从 $z$ 转换而来，因此有：
    $f(i,0)=f(i-1,25)$
- 如果 $c=1$，对应 $b$，它可以从 $z$ 或 $a$ 转换而来，因此有：
    $f(i,1)=f(i-1,25)+f(i-1,0)$
- 如果 $c \ge 2$，它可以从上一次字符转换而来，因此有：
    $f(i,c)=f(i-1,c-1)$

这样我们就得到了递推公式，可以从 $f(1,\dots)$ 一直计算到 $f(t,\dots)$。最终所有 $f(t,c)$ 的和即为答案。

**优化**

注意到在递推公式中，$f(i,\dots)$ 的计算只依赖 $f(i-1,\dots)$ 的值，因此我们可以使用两个一维数组代替整个二维数组 $f$ 进行递推，可以参考下面代码中的数组 $cnt$ 和 $nxt$。

**代码**

```C++
class Solution {
public:
    int lengthAfterTransformations(string s, int t) {
        vector<int> cnt(26);
        for (char ch: s) {
            ++cnt[ch - 'a'];
        }
        for (int round = 0; round < t; ++round) {
            vector<int> nxt(26);
            nxt[0] = cnt[25];
            nxt[1] = (cnt[25] + cnt[0]) % mod;
            for (int i = 2; i < 26; ++i) {
                nxt[i] = cnt[i - 1];
            }
            cnt = move(nxt);
        }
        int ans = 0;
        for (int i = 0; i < 26; ++i) {
            ans = (ans + cnt[i]) % mod;
        }
        return ans;
    }

private:
    static constexpr int mod = 1000000007;
};
```

```Python
class Solution:
    def lengthAfterTransformations(self, s: str, t: int) -> int:
        mod = 10**9 + 7
        cnt = [0] * 26
        for ch in s:
            cnt[ord(ch) - ord("a")] += 1
        for round in range(t):
            nxt = [0] * 26
            nxt[0] = cnt[25]
            nxt[1] = (cnt[25] + cnt[0]) % mod
            for i in range(2, 26):
                nxt[i] = cnt[i - 1]
            cnt = nxt
        ans = sum(cnt) % mod
        return ans
```

```Java
class Solution {
    private static final int MOD = 1000000007;

    public int lengthAfterTransformations(String s, int t) {
        int[] cnt = new int[26];
        for (char ch : s.toCharArray()) {
            ++cnt[ch - 'a'];
        }
        for (int round = 0; round < t; ++round) {
            int[] nxt = new int[26];
            nxt[0] = cnt[25];
            nxt[1] = (cnt[25] + cnt[0]) % MOD;
            for (int i = 2; i < 26; ++i) {
                nxt[i] = cnt[i - 1];
            }
            cnt = nxt;
        }
        int ans = 0;
        for (int i = 0; i < 26; ++i) {
            ans = (ans + cnt[i]) % MOD;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    private const int MOD = 1000000007;

    public int LengthAfterTransformations(string s, int t) {
        int[] cnt = new int[26];
        foreach (char ch in s) {
            ++cnt[ch - 'a'];
        }
        for (int round = 0; round < t; ++round) {
            int[] nxt = new int[26];
            nxt[0] = cnt[25];
            nxt[1] = (cnt[25] + cnt[0]) % MOD;
            for (int i = 2; i < 26; ++i) {
                nxt[i] = cnt[i - 1];
            }
            cnt = nxt;
        }
        int ans = 0;
        for (int i = 0; i < 26; ++i) {
            ans = (ans + cnt[i]) % MOD;
        }
        return ans;
    }
}
```

```Go
const mod = 1000000007

func lengthAfterTransformations(s string, t int) int {
    cnt := make([]int, 26)
    for _, ch := range s {
        cnt[ch-'a']++
    }
    for round := 0; round < t; round++ {
        nxt := make([]int, 26)
        nxt[0] = cnt[25]
        nxt[1] = (cnt[25] + cnt[0]) % mod
        for i := 2; i < 26; i++ {
            nxt[i] = cnt[i-1]
        }
        cnt = nxt
    }
    ans := 0
    for i := 0; i < 26; i++ {
        ans = (ans + cnt[i]) % mod
    }
    return ans
}
```

```C
#define MOD 1000000007

int lengthAfterTransformations(char* s, int t) {
    int cnt[26] = {0};
    for (int i = 0; s[i]; i++) {
        cnt[s[i] - 'a']++;
    }
    for (int round = 0; round < t; round++) {
        int nxt[26] = {0};
        nxt[0] = cnt[25];
        nxt[1] = (cnt[25] + cnt[0]) % MOD;
        for (int i = 2; i < 26; i++) {
            nxt[i] = cnt[i - 1];
        }
        memcpy(cnt, nxt, sizeof(cnt));
    }
    int ans = 0;
    for (int i = 0; i < 26; i++) {
        ans = (ans + cnt[i]) % MOD;
    }
    return ans;
}
```

```JavaScript
var lengthAfterTransformations = function(s, t) {
    const MOD = 1000000007;
    let cnt = new Array(26).fill(0);
    for (const ch of s) {
        cnt[ch.charCodeAt(0) - 'a'.charCodeAt(0)]++;
    }
    for (let round = 0; round < t; round++) {
        let nxt = new Array(26).fill(0);
        nxt[0] = cnt[25];
        nxt[1] = (cnt[25] + cnt[0]) % MOD;
        for (let i = 2; i < 26; i++) {
            nxt[i] = cnt[i - 1];
        }
        cnt = nxt;
    }
    let ans = 0;
    for (let i = 0; i < 26; i++) {
        ans = (ans + cnt[i]) % MOD;
    }
    return ans;
};
```

```TypeScript
function lengthAfterTransformations(s: string, t: number): number {
    const MOD = 1000000007;
    let cnt: number[] = new Array(26).fill(0);
    for (const ch of s) {
        cnt[ch.charCodeAt(0) - 'a'.charCodeAt(0)]++;
    }
    for (let round = 0; round < t; round++) {
        let nxt: number[] = new Array(26).fill(0);
        nxt[0] = cnt[25];
        nxt[1] = (cnt[25] + cnt[0]) % MOD;
        for (let i = 2; i < 26; i++) {
            nxt[i] = cnt[i - 1];
        }
        cnt = nxt;
    }
    let ans = 0;
    for (let i = 0; i < 26; i++) {
        ans = (ans + cnt[i]) % MOD;
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn length_after_transformations(s: String, t: i32) -> i32 {
        const MOD: i32 = 1_000_000_007;
        let mut cnt = [0; 26];
        for ch in s.chars() {
            cnt[(ch as u8 - b'a') as usize] += 1;
        }
        for _ in 0..t {
            let mut nxt = [0; 26];
            nxt[0] = cnt[25];
            nxt[1] = (cnt[25] + cnt[0]) % MOD;
            for i in 2..26 {
                nxt[i] = cnt[i - 1];
            }
            cnt = nxt;
        }
        let mut ans = 0;
        for &num in cnt.iter() {
            ans = (ans + num) % MOD;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+t \vert \sum \vert)$，其中 $n$ 是字符串 $s$ 的长度，$\vert \sum \vert$ 是字符集大小，在本题中 $\vert \sum \vert =26$。
- 空间复杂度：$O(\vert \sum \vert)$，即为递推中两个一维数组需要使用的空间。
