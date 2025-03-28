### [使所有字符相等的最小成本](https://leetcode.cn/problems/minimum-cost-to-make-all-characters-equal/solutions/3615254/shi-suo-you-zi-fu-xiang-deng-de-zui-xiao-367q/)

#### 方法一：动态规划

**思路与算法**

我们可以维护一个前缀全部变成 $0$ 或 $1$ 的最小成本，同时维护后缀全部变成 $0$ 和 $1$ 的最小成本来求解答案。

定义 $suf[i][0]$ 表示从第 $i$ 个字符开始的后缀全部变成 $0$ 所需要的最小成本，定义 $suf[i][1]$ 表示从第 $i$ 个字符的后缀全部变成 $1$ 所需的最小成本，转移方程为：

1. 若 $s[i]$ 为 $1$，则：
    - $suf[i][1]=suf[i+1][1]$
    - $suf[i][0]=suf[i+1][0]+(n-i)$
2. 若 $s[i]$ 为 $0$，则：
    - $suf[i][1]=suf[i+1][0]+(n-i)$
    - $suf[i][0]=suf[i+1][0]$

前缀的状态 $pre[i][0]$ 和 $pre[i][1]$ 的定义和转移过程类似，遍历所有的 $i$，求解 $min(pre[i][0]+suf[i+1][0],pre[i][1]+suf[i+1][1])$ 的最小值即可。

**代码**

```C++
class Solution {
public:
    using ll = long long;
    ll minimumCost(string s) {
        int n = s.size();
        vector<vector<ll>> suf(n + 1, vector<ll>(2, 0));
        for (int i = n - 1; i >= 0; i--) {
            if (s[i] == '1') {
                suf[i][1] = suf[i + 1][1];
                suf[i][0] = suf[i + 1][1] + (n - i);
            } else {
                suf[i][1] = suf[i + 1][0] + (n - i);
                suf[i][0] = suf[i + 1][0];
            }
        }

        vector<ll> pre(2);
        ll res = 1e18;
        for (int i = 0; i < n; i++) {
            if (s[i] == '1') {
                pre[0] = pre[1] + i + 1;
            } else {
                pre[1] = pre[0] + i + 1;
            }
            res = min(res, min(pre[0] + suf[i + 1][0], pre[1] + suf[i + 1][1]));
        }
        return res;
    }
};
```

```Java
class Solution {
    public long minimumCost(String s) {
        int n = s.length();
        long[][] suf = new long[n + 1][2];
        for (int i = n - 1; i >= 0; i--) {
            if (s.charAt(i) == '1') {
                suf[i][1] = suf[i + 1][1];
                suf[i][0] = suf[i + 1][1] + (n - i);
            } else {
                suf[i][1] = suf[i + 1][0] + (n - i);
                suf[i][0] = suf[i + 1][0];
            }
        }

        long[] pre = new long[2];
        long res = Long.MAX_VALUE;
        for (int i = 0; i < n; i++) {
            if (s.charAt(i) == '1') {
                pre[0] = pre[1] + i + 1;
            } else {
                pre[1] = pre[0] + i + 1;
            }
            res = Math.min(res, Math.min(pre[0] + suf[i + 1][0], pre[1] + suf[i + 1][1]));
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public long MinimumCost(string s) {
        int n = s.Length;
        long[,] suf = new long[n + 1, 2];
        for (int i = n - 1; i >= 0; i--) {
            if (s[i] == '1') {
                suf[i, 1] = suf[i + 1, 1];
                suf[i, 0] = suf[i + 1, 1] + (n - i);
            } else {
                suf[i, 1] = suf[i + 1, 0] + (n - i);
                suf[i, 0] = suf[i + 1, 0];
            }
        }

        long[] pre = new long[2];
        long res = long.MaxValue;
        for (int i = 0; i < n; i++) {
            if (s[i] == '1') {
                pre[0] = pre[1] + i + 1;
            } else {
                pre[1] = pre[0] + i + 1;
            }
            res = Math.Min(res, Math.Min(pre[0] + suf[i + 1, 0], pre[1] + suf[i + 1, 1]));
        }
        return res;
    }
}
```

```Go
func minimumCost(s string) int64 {
    n := len(s)
    suf := make([][2]int64, n + 1)
    for i := n - 1; i >= 0; i-- {
        if s[i] == '1' {
            suf[i][1] = suf[i+1][1]
            suf[i][0] = suf[i+1][1] + int64(n - i)
        } else {
            suf[i][1] = suf[i+1][0] + int64(n - i)
            suf[i][0] = suf[i+1][0]
        }
    }

    pre := [2]int64{0, 0}
    res := int64(math.MaxInt64)
    for i := 0; i < n; i++ {
        if s[i] == '1' {
            pre[0] = pre[1] + int64(i + 1)
        } else {
            pre[1] = pre[0] + int64(i + 1)
        }
        res = min(res, min(pre[0] + suf[i + 1][0], pre[1] + suf[i + 1][1]))
    }
    return res
}
```

```Python
class Solution:
    def minimumCost(self, s: str) -> int:
        n = len(s)
        suf = [[0] * 2 for _ in range(n + 1)]
        for i in range(n - 1, -1, -1):
            if s[i] == '1':
                suf[i][1] = suf[i + 1][1]
                suf[i][0] = suf[i + 1][1] + (n - i)
            else:
                suf[i][1] = suf[i + 1][0] + (n - i)
                suf[i][0] = suf[i + 1][0]
        
        pre = [0] * 2
        res = float('inf')
        for i in range(n):
            if s[i] == '1':
                pre[0] = pre[1] + i + 1
            else:
                pre[1] = pre[0] + i + 1

            res = min([res, pre[0] + suf[i + 1][0], pre[1] + suf[i + 1][1]])
        return res
```

```C
long long minimumCost(char* s) {
    int n = strlen(s);
    long long suf[n + 1][2];
    memset(suf, 0, sizeof(suf));
    for (int i = n - 1; i >= 0; i--) {
        if (s[i] == '1') {
            suf[i][1] = suf[i + 1][1];
            suf[i][0] = suf[i + 1][1] + (n - i);
        } else {
            suf[i][1] = suf[i + 1][0] + (n - i);
            suf[i][0] = suf[i + 1][0];
        }
    }

    long long pre[2] = {0, 0};
    long long res = LLONG_MAX;
    for (int i = 0; i < n; i++) {
        if (s[i] == '1') {
            pre[0] = pre[1] + i + 1;
        } else {
            pre[1] = pre[0] + i + 1;
        }
        res = fmin(res, fmin(pre[0] + suf[i + 1][0], pre[1] + suf[i + 1][1]));
    }
    return res;
}
```

```JavaScript
var minimumCost = function(s) {
    const n = s.length;
    const suf = Array.from({ length: n + 1 }, () => [0, 0]);
    for (let i = n - 1; i >= 0; i--) {
        if (s[i] === '1') {
            suf[i][1] = suf[i + 1][1];
            suf[i][0] = suf[i + 1][1] + (n - i);
        } else {
            suf[i][1] = suf[i + 1][0] + (n - i);
            suf[i][0] = suf[i + 1][0];
        }
    }

    let pre = [0, 0];
    let res = Infinity;
    for (let i = 0; i < n; i++) {
        if (s[i] === '1') {
            pre[0] = pre[1] + i + 1;
        } else {
            pre[1] = pre[0] + i + 1;
        }
        res = Math.min(res, Math.min(pre[0] + suf[i + 1][0], pre[1] + suf[i + 1][1]));
    }
    return res;
};
```

```TypeScript
function minimumCost(s: string): number {
    const n = s.length;
    const suf: number[][] = Array.from({ length: n + 1 }, () => [0, 0]);
    for (let i = n - 1; i >= 0; i--) {
        if (s[i] === '1') {
            suf[i][1] = suf[i + 1][1];
            suf[i][0] = suf[i + 1][1] + (n - i);
        } else {
            suf[i][1] = suf[i + 1][0] + (n - i);
            suf[i][0] = suf[i + 1][0];
        }
    }

    let pre: number[] = [0, 0];
    let res: number = Infinity;
    for (let i = 0; i < n; i++) {
        if (s[i] === '1') {
            pre[0] = pre[1] + i + 1;
        } else {
            pre[1] = pre[0] + i + 1;
        }
        res = Math.min(res, Math.min(pre[0] + suf[i + 1][0], pre[1] + suf[i + 1][1]));
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn minimum_cost(s: String) -> i64 {
        let s: Vec<_> = s.chars().collect();
        let n = s.len();
        let mut suf = vec![vec![0; 2]; n + 1];
        for i in (0..n).rev() {
            if s[i] == '1' {
                suf[i][1] = suf[i + 1][1];
                suf[i][0] = suf[i + 1][1] + (n - i) as i64;
            } else {
                suf[i][1] = suf[i + 1][0] + (n - i) as i64;
                suf[i][0] = suf[i + 1][0];
            }
        }
        let mut pre = vec![0;2];
        let mut res = i64::max_value();
        for i in (0..n) {
            if s[i] == '1' {
                pre[0] = pre[1] + (i + 1) as i64;
            } else {
                pre[1] = pre[0] + (i + 1) as i64;
            }
            res = res.min(std::cmp::min(pre[0] + suf[i + 1][0], pre[1] + suf[i + 1][1]))
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。状态转移的时间复杂度为 $O(1)$，共有 $O(n)$ 个状态，因此总体时间复杂度为 $O(n)$。
- 空间复杂度：$O(n)$。存储后缀状态的空间复杂度为 $O(n)$。

#### 方法二：一次遍历

**思路与算法**

我们并不关心字符最终会变成 $0$ 还是 $1$，只要它们相等即可。因此需要关注每对相邻字符的相等关系。一次操作有如下性质：

- 一次操作可以且一定改变一对相邻字符的关系。
- 对于两个相邻且不相等的字符，必须经过一次操作才能使它们相等。
- 对某两个相邻字符操作结束后，左侧和右侧所有的相邻字符的相等关系不变。

因此，我们只需枚举所有的相邻字符，对不同的进行操作。操作时选择成本更小的一侧，其总和就是答案。

**代码**

```C++
class Solution {
public:
    using ll = long long;
    long long minimumCost(string s) {
        int n = s.size();
        ll res = 0;
        for (int i = 1; i < n; i++) {
            if (s[i] != s[i - 1]) {
                res += min(i, n - i);
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public long minimumCost(String s) {
        int n = s.length();
        long res = 0;
        for (int i = 1; i < n; i++) {
            if (s.charAt(i) != s.charAt(i - 1)) {
                res += Math.min(i, n - i);
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public long MinimumCost(string s) {
        int n = s.Length;
        long res = 0;
        for (int i = 1; i < n; i++) {
            if (s[i] != s[i - 1]) {
                res += Math.Min(i, n - i);
            }
        }
        return res;
    }
}
```

```Go
func minimumCost(s string) int64 {
    n := len(s)
    var res int64 = 0
    for i := 1; i < n; i++ {
        if s[i] != s[i - 1] {
            res += int64(min(i, n - i))
        }
    }
    return res
}
```

```Pyhton
class Solution:
    def minimumCost(self, s: str) -> int:
        return sum(min(i, len(s) - i) for i, (x, y) in enumerate(pairwise(s), 1) if x != y)
```

```JavaScript
var minimumCost = function(s) {
    const n = s.length;
    let res = 0;
    for (let i = 1; i < n; i++) {
        if (s[i] !== s[i - 1]) {
            res += Math.min(i, n - i);
        }
    }
    return res;
};
```

```TypeScript
function minimumCost(s: string): number {
    const n = s.length;
    let res = 0;
    for (let i = 1; i < n; i++) {
        if (s[i] !== s[i - 1]) {
            res += Math.min(i, n - i);
        }
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn minimum_cost(s: String) -> i64 {
        s.chars()
            .collect::<Vec<_>>()
            .windows(2)
            .enumerate()
            .filter(|&(_, w)| w[0] != w[1])
            .map(|(i, _)| (i + 1).min(s.len() - (i + 1)) as i64)
            .sum()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。
- 空间复杂度：$O(1)$。
