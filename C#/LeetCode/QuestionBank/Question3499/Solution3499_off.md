### [操作后最大活跃区段数 I](https://leetcode.cn/problems/maximize-active-section-with-trade-i/solutions/3992719/cao-zuo-hou-zui-da-huo-yue-qu-duan-shu-i-t7j2/)

#### 方法一：贪心

题目要求我们最大化字符串 $s$ 中 $1$ 的数量。

我们先分析进行一次操作会对字符串 $s$ 产生什么影响。

按照题目要求，我们首先在 $s$ 两侧加上 $1$ 形成一个新的字符串 $t:$

$$t=1+s+1$$

不失一般性，假设当前字符串 $t$ 中存在如下结构：

$$\dots 1\underbrace{000}_{a}\underbrace{111}_{b}\underbrace{00}_{c}1\dots$$

其中：

- 中间的 `111` 是一个长度为 $b$ 的被 $0$ 包围的连续 $1$ 区块
- 左右两侧分别是长度为 $a,c$ 的连续 $0$ 区块

第一步，我们先将这段 `111` 变为 `000`：

$$\dots 1\underbrace{000}_{a}\underbrace{000}_{b}\underbrace{00}_{c}1\dots$$

此时，中间三段 $0$ 会直接连成一个更长的连续 $0$ 区块：

$$\dots 1\underbrace{00000000}_{a+b+c}1\dots$$

接着，根据题意，我们可以将这整个连续 $0$ 区块全部变为 $1$：

$$\dots 1\underbrace{11111111}_{a+b+c}1\dots$$

观察整个过程：

- 原本中间那段长度为 $b$ 的 $1$ 仍然保持不变
- 左右两段长度分别为 $a,c$ 的 $0$ 被改变为 $1$

因此最终字符串中 $1$ 的数量**增量**为：

$$(a+b+c)-b=a+c$$

也就是说，**进行一次操作的收益，等于字符串 $t$ 中被某一段连续 $1$ 区块隔开的两个连续 $0$ 区块长度之和**，而中间那段连续 $1$ 的长度并不重要。

因此，我们只需要提取 $t$ 中所有连续 $0$ 区块的长度。设得到一个长为 $m$ 的数组 $zeroBlocks$：

$$[z_0,z_1,\dots ,z_{m-1}]$$

我们枚举相邻两个连续 $0$ 区块的长度 $zi$ 和 $z_{i+1}$，最终答案即为：

$$cnt_1+\mathop{max}\limits_{0\le i<m-1}(z_i+z_{i+1})$$

其中 $cnt_1$ 为操作前原字符串 $s$ 中 $1$ 的数量。$ $
如果字符串中连续 $0$ 区块不足两段，那么无法进行操作，此时答案为 $cnt_1$。
注意，由于两侧新增的辅助字符不会影响字符串中 $0$ 区块的情况，所以也可以直接遍历原字符串 $s$。

**附注**

> 通过第一步将某个连续 $1$ 区块变为 $0$ 之后，这个区块是否有可能没有被外侧的连续 $1$ 区块包围，进而无法对新的连续 $0$ 区块执行第二步操作？

这是不可能的。这意味着字符串 $t$ 将以 $0$ 开头或结尾，然而 $t$ 的第一个字符和最后一个字符是我们额外添加的辅助字符 $1$，并且这两个字符无法被改变。因此，一定可以对新的连续 $0$ 区块执行第二步操作。

> 在第一步把某段 $1$ 变成 $0$ 后，第二步能否不选择这个新形成的连续 $0$ 区块，而去选择别的 $0$ 区块？

这种做法不能获得最优答案。

假设：

- 第一段被删除的 $1$ 长度为 $b$
- 第二步选择了另一段长度为 $z_i$ 的 连续 $0$ 区块

那么最终收益为：

$$z_i-b$$

而任意一个连续 $0$ 区块 $zi$，都一定与某个相邻连续 $0$ 区块组成一次合法操作，因此我们总能得到：

$$z_i+z_{i-1} or z_i+z_{i+1}$$

显然：

$$z_i+z_{i\pm 1}>z_i-b$$

因此最优策略一定是：第二步选择第一步形成的新的连续 $0$ 区块。

**代码**

```C++
class Solution {
public:
    int maxActiveSectionsAfterTrade(string s) {
        int n = s.size();
        int cnt1 = count(s.begin(), s.end(), '1');

        vector<int> zeroBlocks;
        int i = 0;
        while (i < n) {
            int start = i;

            while (i < n && s[i] == s[start]) {
                ++i;
            }

            if (s[start] == '0') {
                zeroBlocks.push_back(i - start);
            }
        }

        int m = zeroBlocks.size();

        if (m < 2) {
            return cnt1;
        }

        int bestGain = 0; // 最优增量
        for (int i = 0; i < m - 1; ++i) {
            bestGain = max(bestGain, zeroBlocks[i] + zeroBlocks[i + 1]);
        }

        return cnt1 + bestGain;
    }
};
```

```Python
class Solution:
    def maxActiveSectionsAfterTrade(self, s: str) -> int:
        n = len(s)
        cnt1 = s.count('1')

        zeroBlocks = []
        i = 0
        while i < n:
            start = i

            while i < n and s[i] == s[start]:
                i += 1

            if s[start] == '0':
                zeroBlocks.append(i - start)

        m = len(zeroBlocks)

        if m < 2:
            return cnt1

        bestGain = 0 # 最优增量
        for i in range(m - 1):
            bestGain = max(bestGain, zeroBlocks[i] + zeroBlocks[i + 1])
        return cnt1 + bestGain

```

```Java
class Solution {
    public int maxActiveSectionsAfterTrade(String s) {
        int n = s.length();
        int cnt1 = 0;
        for (char c : s.toCharArray()) {
            if (c == '1') cnt1++;
        }

        List<Integer> zeroBlocks = new ArrayList<>();
        int i = 0;
        while (i < n) {
            int start = i;
            while (i < n && s.charAt(i) == s.charAt(start)) {
                i++;
            }
            if (s.charAt(start) == '0') {
                zeroBlocks.add(i - start);
            }
        }

        int m = zeroBlocks.size();
        if (m < 2) {
            return cnt1;
        }
        int bestGain = 0; // 最优增量
        for (int j = 0; j < m - 1; j++) {
            bestGain = Math.max(bestGain, zeroBlocks.get(j) + zeroBlocks.get(j + 1));
        }

        return cnt1 + bestGain;
    }
}
```

```CSharp
public class Solution {
    public int MaxActiveSectionsAfterTrade(string s) {
        int n = s.Length;
        int cnt1 = 0;
        foreach (char c in s) {
            if (c == '1') cnt1++;
        }

        List<int> zeroBlocks = new List<int>();
        int i = 0;
        while (i < n) {
            int start = i;
            while (i < n && s[i] == s[start]) {
                i++;
            }
            if (s[start] == '0') {
                zeroBlocks.Add(i - start);
            }
        }

        int m = zeroBlocks.Count;
        if (m < 2) {
            return cnt1;
        }
        int bestGain = 0; // 最优增量
        for (int j = 0; j < m - 1; j++) {
            bestGain = Math.Max(bestGain, zeroBlocks[j] + zeroBlocks[j + 1]);
        }

        return cnt1 + bestGain;
    }
}
```

```Go
func maxActiveSectionsAfterTrade(s string) int {
    n := len(s)
    cnt1 := 0
    for _, c := range s {
        if c == '1' {
            cnt1++
        }
    }

    zeroBlocks := []int{}
    i := 0
    for i < n {
        start := i
        for i < n && s[i] == s[start] {
            i++
        }
        if s[start] == '0' {
            zeroBlocks = append(zeroBlocks, i-start)
        }
    }

    m := len(zeroBlocks)
    if m < 2 {
        return cnt1
    }

    bestGain := 0 // 最优增量
    for j := 0; j < m-1; j++ {
        bestGain = max(bestGain, zeroBlocks[j]+zeroBlocks[j+1])
    }

    return cnt1 + bestGain
}
```

```C
int maxActiveSectionsAfterTrade(char* s) {
    int n = strlen(s);
    int cnt1 = 0;
    for (int i = 0; i < n; i++) {
        if (s[i] == '1') cnt1++;
    }

    int* zeroBlocks = (int*)malloc(n * sizeof(int));
    int m = 0;
    int i = 0;
    while (i < n) {
        int start = i;
        while (i < n && s[i] == s[start]) {
            i++;
        }
        if (s[start] == '0') {
            zeroBlocks[m++] = i - start;
        }
    }

    if (m < 2) {
        free(zeroBlocks);
        return cnt1;
    }

    int bestGain = 0; // 最优增量
    for (int j = 0; j < m - 1; j++) {
        int gain = zeroBlocks[j] + zeroBlocks[j + 1];
        if (gain > bestGain) {
            bestGain = gain;
        }
    }

    free(zeroBlocks);
    return cnt1 + bestGain;
}
```

```JavaScript
var maxActiveSectionsAfterTrade = function(s) {
    const n = s.length;
    let cnt1 = 0;
    for (let c of s) {
        if (c === '1') cnt1++;
    }

    const zeroBlocks = [];
    let i = 0;
    while (i < n) {
        const start = i;
        while (i < n && s[i] === s[start]) {
            i++;
        }
        if (s[start] === '0') {
            zeroBlocks.push(i - start);
        }
    }

    const m = zeroBlocks.length;
    if (m < 2) {
        return cnt1;
    }

    let bestGain = 0; // 最优增量
    for (let j = 0; j < m - 1; j++) {
        bestGain = Math.max(bestGain, zeroBlocks[j] + zeroBlocks[j + 1]);
    }

    return cnt1 + bestGain;
};
```

```TypeScript
function maxActiveSectionsAfterTrade(s: string): number {
    const n = s.length;
    let cnt1 = 0;
    for (const c of s) {
        if (c === '1') cnt1++;
    }

    const zeroBlocks: number[] = [];
    let i = 0;
    while (i < n) {
        const start = i;
        while (i < n && s[i] === s[start]) {
            i++;
        }
        if (s[start] === '0') {
            zeroBlocks.push(i - start);
        }
    }

    const m = zeroBlocks.length;
    if (m < 2) {
        return cnt1;
    }

    let bestGain = 0; // 最优增量
    for (let j = 0; j < m - 1; j++) {
        bestGain = Math.max(bestGain, zeroBlocks[j] + zeroBlocks[j + 1]);
    }

    return cnt1 + bestGain;
}
```

```Rust
impl Solution {
    pub fn max_active_sections_after_trade(s: String) -> i32 {
        let n = s.len();
        let cnt1 = s.chars().filter(|&c| c == '1').count() as i32;

        let mut zero_blocks = Vec::new();
        let mut i = 0;
        let bytes = s.as_bytes();

        while i < n {
            let start = i;
            while i < n && bytes[i] == bytes[start] {
                i += 1;
            }
            if bytes[start] == b'0' {
                zero_blocks.push((i - start) as i32);
            }
        }

        let m = zero_blocks.len();
        if m < 2 {
            return cnt1;
        }

        let mut best_gain = 0; // 最优增量
        for j in 0..m - 1 {
            best_gain = best_gain.max(zero_blocks[j] + zero_blocks[j + 1]);
        }

        cnt1 + best_gain
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。
- 空间复杂度：$O(k)$。其中 $k$ 为连续 $0$ 区块的数量，额外空间来自存储这些区块长度的数组 $zeroBlocks$。

#### 方法二：空间优化

在方法一中，我们额外需要一个数组 $zeroBlocks$ 来记录所有连续 $0$ 区块的长度。

实际上，我们只关心相邻两段连续 $0$ 区块长度之和的最大值，因此没有必要保存完整数组，只需要维护：

- $prev$：上一段连续 $0$ 区块长度
- $cur$：当前连续 $0$ 区块长度
- $bestGain$：目前得到的最大答案增量

当扫描到新的连续 $0$ 区块时，立即用：

$$bestGain=max(bestGain,prev+cur)$$

更新答案，然后令：

$$prev=cur$$

继续扫描即可。

这样可以将额外空间复杂度从 $O(k)$ 优化到 $O(1)$。由于每个字符只会被遍历一次，因此时间复杂度仍然是 $O(n)$。

**代码**

```C++
class Solution {
public:
    int maxActiveSectionsAfterTrade(string s) {
        int n = s.size();
        int cnt1 = count(s.begin(), s.end(), '1');

        int i = 0;
        int bestGain = 0;
        int prev = INT_MIN, cur = 0;

        while (i < n) {
            int start = i;

            while (i < n && s[i] == s[start]) {
                ++i;
            }
            if (s[start] == '0'){
                cur = i - start;
                bestGain = max(bestGain, prev + cur);
                prev = cur;
            }

        }

        return cnt1 + bestGain;
    }
};
```

```Python
class Solution:
    def maxActiveSectionsAfterTrade(self, s: str) -> int:
        cnt1 = s.count('1')

        n = len(s)
        i = 0

        bestGain = 0
        prev = -inf

        while i < n:
            start = i

            while i < n and s[i] == s[start]:
                i += 1

            if s[start] == '0':
                cur = i - start
                bestGain = max(bestGain, prev + cur)
                prev = cur

        return cnt1 + bestGain
```

```Java
class Solution {
    public int maxActiveSectionsAfterTrade(String s) {
        int n = s.length();
        int cnt1 = 0;
        for (char c : s.toCharArray()) {
            if (c == '1') cnt1++;
        }

        int i = 0;
        int bestGain = 0;
        int prev = Integer.MIN_VALUE;
        int cur = 0;

        while (i < n) {
            int start = i;
            while (i < n && s.charAt(i) == s.charAt(start)) {
                i++;
            }
            if (s.charAt(start) == '0') {
                cur = i - start;
                if (prev != Integer.MIN_VALUE) {
                    bestGain = Math.max(bestGain, prev + cur);
                }
                prev = cur;
            }
        }

        return cnt1 + bestGain;
    }
}
```

```CSharp
public class Solution {
    public int MaxActiveSectionsAfterTrade(string s) {
        int n = s.Length;
        int cnt1 = 0;
        foreach (char c in s) {
            if (c == '1') cnt1++;
        }

        int i = 0;
        int bestGain = 0;
        int prev = int.MinValue;
        int cur = 0;
        while (i < n) {
            int start = i;
            while (i < n && s[i] == s[start]) {
                i++;
            }
            if (s[start] == '0') {
                cur = i - start;
                if (prev != int.MinValue) {
                    bestGain = Math.Max(bestGain, prev + cur);
                }
                prev = cur;
            }
        }

        return cnt1 + bestGain;
    }
}
```

```Go
func maxActiveSectionsAfterTrade(s string) int {
    n := len(s)
    cnt1 := 0
    for _, c := range s {
        if c == '1' {
            cnt1++
        }
    }

    i := 0
    bestGain := 0
    prev := -1 << 31
    cur := 0

    for i < n {
        start := i
        for i < n && s[i] == s[start] {
            i++
        }
        if s[start] == '0' {
            cur = i - start
            if prev != -1<<31 {
                bestGain = max(bestGain, prev+cur)
            }
            prev = cur
        }
    }

    return cnt1 + bestGain
}
```

```C
int maxActiveSectionsAfterTrade(char* s) {
    int n = strlen(s);
    int cnt1 = 0;
    for (int i = 0; i < n; i++) {
        if (s[i] == '1') {
            cnt1++;
        }
    }

    int i = 0;
    int bestGain = 0;
    int prev = INT_MIN;
    int cur = 0;

    while (i < n) {
        int start = i;
        while (i < n && s[i] == s[start]) {
            i++;
        }
        if (s[start] == '0') {
            cur = i - start;
            if (prev != INT_MIN) {
                bestGain = (prev + cur > bestGain) ? prev + cur : bestGain;
            }
            prev = cur;
        }
    }

    return cnt1 + bestGain;
}
```

```JavaScript
var maxActiveSectionsAfterTrade = function(s) {
    const n = s.length;
    let cnt1 = 0;
    for (let c of s) {
        if (c === '1') cnt1++;
    }

    let i = 0;
    let bestGain = 0;
    let prev = -Infinity;
    let cur = 0;

    while (i < n) {
        const start = i;
        while (i < n && s[i] === s[start]) {
            i++;
        }
        if (s[start] === '0') {
            cur = i - start;
            if (prev !== -Infinity) {
                bestGain = Math.max(bestGain, prev + cur);
            }
            prev = cur;
        }
    }

    return cnt1 + bestGain;
};
```

```TypeScript
function maxActiveSectionsAfterTrade(s: string): number {
    const n = s.length;
    let cnt1 = 0;
    for (const c of s) {
        if (c === '1') cnt1++;
    }

    let i = 0;
    let bestGain = 0;
    let prev = -Infinity;
    let cur = 0;

    while (i < n) {
        const start = i;
        while (i < n && s[i] === s[start]) {
            i++;
        }
        if (s[start] === '0') {
            cur = i - start;
            if (prev !== -Infinity) {
                bestGain = Math.max(bestGain, prev + cur);
            }
            prev = cur;
        }
    }

    return cnt1 + bestGain;
}
```

```Rust
impl Solution {
    pub fn max_active_sections_after_trade(s: String) -> i32 {
        let n = s.len();
        let cnt1 = s.chars().filter(|&c| c == '1').count() as i32;

        let mut i = 0;
        let mut best_gain = 0;
        let mut prev = i32::MIN;
        let mut cur = 0;
        let bytes = s.as_bytes();

        while i < n {
            let start = i;
            while i < n && bytes[i] == bytes[start] {
                i += 1;
            }
            if bytes[start] == b'0' {
                cur = (i - start) as i32;
                if prev != i32::MIN {
                    best_gain = best_gain.max(prev + cur);
                }
                prev = cur;
            }
        }

        cnt1 + best_gain
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。
- 空间复杂度：$O(1)$。
