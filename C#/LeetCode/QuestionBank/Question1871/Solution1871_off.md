### [跳跃游戏 VII](https://leetcode.cn/problems/jump-game-vii/solutions/791378/tiao-yue-you-xi-vii-by-leetcode-solution-rsyv/)

#### 方法一：动态规划 + 前缀和优化

**提示 1**

我们用 $f(i)$ 表示能否从位置 $0$ 按照给定的规则跳到位置 $i$。

如果 $s[i]$ 为 $1$，我们无法跳到位置 $i$，此时 $f(i)=False$。

如果 $s[i]$ 为 $0$，我们可以枚举位置 $j$，表示最后一步是从位置 $j$ 跳到位置 $i$ 的。位置 $j$ 需要满足 $j\in [i-maxJump,i-minJump]$ 并且 $j\ge 0$，只要存在一个 $j$ 满足 $f(j)=True$，那么 $f(i)$ 就为 $True$。因此我们可以写出状态转移方程：

$$f(i)=any(f(j)),其中 j\in [i-maxJump,i-minJump] 并且 j\ge 0$$

如果字符串 $s$ 的长度为 $n$，我们按照上述状态转移方程进行动态规划后，最终的答案即为 $f(n-1)$。

然而该状态转移方程的转移时间为 $O(n)$，即动态规划的总时间复杂度为 $O(n^2)$，会超出时间限制，因此我们需要进行优化。

**提示 2**

为了叙述方便，我们用 $left_i$ 和 $right_i$ 表示位置 $i$ 在状态转移中对应的 $j$ 的区间。在大部分情况下，有：

$$[left_i,right_i]=[i-maxJump,i-minJump]$$

但由于有 $j\ge 0$ 的限制，可能需要对该区间进行一些处理，具体的处理方法可以参考代码部分。

根据提示 $1$，f(i) 的值为 $True$，当且仅当 $s[i]$ 为 $0$，并且区间 $[left_i,right_i]$ 中存在一个位置作为下标对应的 $f$ 值也为 $True$。如果我们将 $True$ 看成 $1$，False 看成 $0$，那么其等价于：

- $f(i)$ 的值为 $True$，当且仅当 $s[i]$ 为 $0$，并且 $j=\sum\limits_{left_i}^{right_i}f(j)$ 的值不为 $0$。

由于 $j=\sum\limits_{left_i}^{right_i}f(j)$ 是数组 $f$ 的一段连续区间的求和，因此我们可以在动态规划的同时维护数组 $f$ 的前缀和数组 $pre$，其中：

$$pre(i)=\sum\limits_{j=0}^{i}f(i)$$

这样就可以通过：

$$\sum\limits_{j=left_i}^{right_i}f(j)=pre(right_i)-pre(left_i-1)$$

在 $O(1)$ 的时间快速地进行状态转移了，使得动态规划的总时间减少为 $O(n)$。这里同样需要注意处理 $left_i\le 0$ 的情况，可以参考代码部分。

**细节**

动态规划的边界条件为 $f(0)=True$。在进行状态转移时，我们可以从 $i=minJump$ 开始，保证 $right_i$ 恒大于等于 $0$，这样就只需要特殊处理 $left_i$ 了。

**代码**

```C++
class Solution {
public:
    bool canReach(string s, int minJump, int maxJump) {
        int n = s.size();
        vector<int> f(n), pre(n);
        f[0] = 1;
        // 由于我们从 i=minJump 开始动态规划，因此需要将 [0,minJump) 这部分的前缀和预处理出来
        for (int i = 0; i < minJump; ++i) {
            pre[i] = 1;
        }
        for (int i = minJump; i < n; ++i) {
            int left = i - maxJump, right = i - minJump;
            if (s[i] == '0') {
                int total = pre[right] - (left <= 0 ? 0 : pre[left - 1]);
                f[i] = (total != 0);
            }
            pre[i] = pre[i - 1] + f[i];
        }
        return f[n - 1];
    }
};
```

```Python
class Solution:
    def canReach(self, s: str, minJump: int, maxJump: int) -> bool:
        n = len(s)
        f, pre = [0] * n, [0] * n
        f[0] = 1
        # 由于我们从 i=minJump 开始动态规划，因此需要将 [0,minJump) 这部分的前缀和预处理出来
        for i in range(minJump):
            pre[i] = 1
        for i in range(minJump, n):
            left, right = i - maxJump, i - minJump
            if s[i] == "0":
                total = pre[right] - (0 if left <= 0 else pre[left - 1])
                f[i] = int(total != 0)
            pre[i] = pre[i - 1] + f[i]

        return bool(f[n - 1])
```

```Java
class Solution {
    public boolean canReach(String s, int minJump, int maxJump) {
        int n = s.length();
        int[] f = new int[n];
        int[] pre = new int[n];
        f[0] = 1;
        // 由于我们从 i=minJump 开始动态规划，因此需要将 [0,minJump) 这部分的前缀和预处理出来
        for (int i = 0; i < minJump; i++) {
            pre[i] = 1;
        }
        for (int i = minJump; i < n; i++) {
            int left = i - maxJump;
            int right = i - minJump;
            if (s.charAt(i) == '0') {
                int total = pre[right] - (left <= 0 ? 0 : pre[left - 1]);
                f[i] = total != 0 ? 1 : 0;
            }
            pre[i] = pre[i - 1] + f[i];
        }
        return f[n - 1] == 1;
    }
}
```

```CSharp
public class Solution {
    public bool CanReach(string s, int minJump, int maxJump) {
        int n = s.Length;
        int[] f = new int[n];
        int[] pre = new int[n];
        f[0] = 1;
        // 由于我们从 i=minJump 开始动态规划，因此需要将 [0,minJump) 这部分的前缀和预处理出来
        for (int i = 0; i < minJump; i++) {
            pre[i] = 1;
        }
        for (int i = minJump; i < n; i++) {
            int left = i - maxJump;
            int right = i - minJump;
            if (s[i] == '0') {
                int total = pre[right] - (left <= 0 ? 0 : pre[left - 1]);
                f[i] = total != 0 ? 1 : 0;
            }
            pre[i] = pre[i - 1] + f[i];
        }
        return f[n - 1] == 1;
    }
}
```

```Go
func canReach(s string, minJump int, maxJump int) bool {
    n := len(s)
    f := make([]int, n)
    pre := make([]int, n)
    f[0] = 1
    // 由于我们从 i=minJump 开始动态规划，因此需要将 [0,minJump) 这部分的前缀和预处理出来
    for i := 0; i < minJump; i++ {
        pre[i] = 1
    }
    for i := minJump; i < n; i++ {
        left := i - maxJump
        right := i - minJump
        if s[i] == '0' {
            total := pre[right]
            if left > 0 {
                total -= pre[left-1]
            }
            if total != 0 {
                f[i] = 1
            } else {
                f[i] = 0
            }
        }
        pre[i] = pre[i-1] + f[i]
    }
    return f[n-1] == 1
}
```

```C
bool canReach(char* s, int minJump, int maxJump) {
    int n = strlen(s);
    int* f = (int*)calloc(n, sizeof(int));
    int* pre = (int*)malloc(n * sizeof(int));
    f[0] = 1;
    // 由于我们从 i=minJump 开始动态规划，因此需要将 [0,minJump) 这部分的前缀和预处理出来
    for (int i = 0; i < minJump; i++) {
        pre[i] = 1;
    }
    for (int i = minJump; i < n; i++) {
        int left = i - maxJump;
        int right = i - minJump;
        if (s[i] == '0') {
            int total = pre[right];
            if (left > 0) {
                total -= pre[left - 1];
            }
            f[i] = total != 0 ? 1 : 0;
        }
        pre[i] = pre[i - 1] + f[i];
    }
    bool result = (f[n - 1] == 1);
    free(f);
    free(pre);
    return result;
}
```

```JavaScript
var canReach = function(s, minJump, maxJump) {
    const n = s.length;
    const f = new Array(n).fill(0);
    const pre = new Array(n).fill(0);
    f[0] = 1;
    // 由于我们从 i=minJump 开始动态规划，因此需要将 [0,minJump) 这部分的前缀和预处理出来
    for (let i = 0; i < minJump; i++) {
        pre[i] = 1;
    }
    for (let i = minJump; i < n; i++) {
        const left = i - maxJump;
        const right = i - minJump;
        if (s[i] === '0') {
            const total = pre[right] - (left <= 0 ? 0 : pre[left - 1]);
            f[i] = total !== 0 ? 1 : 0;
        }
        pre[i] = pre[i - 1] + f[i];
    }
    return f[n - 1] === 1;
};
```

```TypeScript
function canReach(s: string, minJump: number, maxJump: number): boolean {
    const n: number = s.length;
    const f: number[] = new Array(n).fill(0);
    const pre: number[] = new Array(n).fill(0);
    f[0] = 1;
    // 由于我们从 i=minJump 开始动态规划，因此需要将 [0,minJump) 这部分的前缀和预处理出来
    for (let i = 0; i < minJump; i++) {
        pre[i] = 1;
    }
    for (let i = minJump; i < n; i++) {
        const left: number = i - maxJump;
        const right: number = i - minJump;
        if (s[i] === '0') {
            const total: number = pre[right] - (left <= 0 ? 0 : pre[left - 1]);
            f[i] = total !== 0 ? 1 : 0;
        }
        pre[i] = pre[i - 1] + f[i];
    }
    return f[n - 1] === 1;
}
```

```Rust
impl Solution {
    pub fn can_reach(s: String, min_jump: i32, max_jump: i32) -> bool {
        let n = s.len();
        let min_jump = min_jump as usize;
        let max_jump = max_jump as usize;
        let mut f = vec![0; n];
        let mut pre = vec![0; n];
        f[0] = 1;
        // 由于我们从 i=minJump 开始动态规划，因此需要将 [0,minJump) 这部分的前缀和预处理出来
        for i in 0..min_jump {
            pre[i] = 1;
        }
        let s_chars: Vec<char> = s.chars().collect();
        for i in min_jump..n {
            let left = i as i32 - max_jump as i32;
            let right = i - min_jump;
            if s_chars[i] == '0' {
                let total = if left <= 0 {
                    pre[right]
                } else {
                    pre[right] - pre[left as usize - 1]
                };
                f[i] = if total != 0 { 1 } else { 0 };
            }
            pre[i] = pre[i - 1] + f[i];
        }
        f[n - 1] == 1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。
- 空间复杂度：$O(n)$，即为数组 $f$ 和 $pre$ 需要使用的空间。
