### [爬楼梯 II](https://leetcode.cn/problems/climbing-stairs-ii/solutions/4050907/pa-lou-ti-ii-by-leetcode-solution-7kcl/)

#### 方法一：动态规划

**思路与算法**

记 $f[i]$ 为到达第 $i$ 级台阶所需的最小总成本。初始时我们位于第 $0$ 级台阶，总成本为 $0$，即 $f[0]=0$。

要到达第 $i$ 级台阶（$i\ge 1$），最后一步只能从第 $i-1$、$i-2$ 或 $i-3$ 级台阶跳上来，跳跃距离分别为 $1$、$2$、$3$，代价为距离的平方，即 $1$、$4$、$9$，此外还需支付第 $i$ 级台阶的成本 $costs[i]$。取三者中的最小值，状态转移方程为：

$$f[i]=min(f[i-1]+1, f[i-2]+4, f[i-3]+9)+costs[i]$$

当 $i<3$ 时，部分起跳台阶不存在，忽略对应的项即可。最终答案为 $f[n]$。

直接按上式递推，需要 $O(n)$ 的空间存储数组 $f$。注意到 $f[i]$ 只与 $f[i-1]$、$f[i-2]$、$f[i-3]$ 有关，更早的状态不会再被用到，因此我们可以只保留最近的三个状态，用三个变量滚动维护，每计算出一个新状态就将它们向后移动一位，空间复杂度降为 $O(1)$。

在代码实现中，我们用变量 $a$、$b$、$c$ 滚动维护最近的三个状态。遍历 $costs$ 时，第 $i$ 次迭代按转移方程计算出 $f[i+1]$，随后三个变量整体向后移动一位，遍历结束时 $c$ 即为 $f[n]$。初始时令 $a=b=c=0$，相当于把下标小于 $0$ 的状态也设为 $0$；这些状态与 $f[0]$ 的取值相同，但从这些不存在的台阶起跳的距离更远、平方代价更大，对应项不会成为最小值，因此不影响计算结果。

**代码**

```C++
class Solution {
public:
    int climbStairs(int n, vector<int>& costs) {
        int a = 0, b = 0, c = 0;
        for (int i = 0; i < n; ++i) {
            int nxt = min({a + 9, b + 4, c + 1}) + costs[i];
            a = b;
            b = c;
            c = nxt;
        }
        return c;
    }
};
```

```Python
class Solution:
    def climbStairs(self, n: int, costs: List[int]) -> int:
        a = b = c = 0
        for i in range(n):
            a, b, c = b, c, min(a + 9, b + 4, c + 1) + costs[i]
        return c
```

```Java
class Solution {
    public int climbStairs(int n, int[] costs) {
        int a = 0, b = 0, c = 0;
        for (int i = 0; i < n; ++i) {
            int nxt = Math.min(Math.min(a + 9, b + 4), c + 1) + costs[i];
            a = b;
            b = c;
            c = nxt;
        }
        return c;
    }
}
```

```CSharp
public class Solution {
    public int ClimbStairs(int n, int[] costs) {
        int a = 0, b = 0, c = 0;
        for (int i = 0; i < n; ++i) {
            int nxt = Math.Min(Math.Min(a + 9, b + 4), c + 1) + costs[i];
            a = b;
            b = c;
            c = nxt;
        }
        return c;
    }
}
```

```Go
func climbStairs(n int, costs []int) int {
    a, b, c := 0, 0, 0
    for i := 0; i < n; i++ {
        nxt := min(min(a+9, b+4), c+1) + costs[i]
        a, b, c = b, c, nxt
    }
    return c
}
```

```C
int climbStairs(int n, int* costs, int costsSize) {
    int a = 0, b = 0, c = 0;
    for (int i = 0; i < n; ++i) {
        int nxt = fmin(fmin(a + 9, b + 4), c + 1) + costs[i];
        a = b;
        b = c;
        c = nxt;
    }
    return c;
}
```

```JavaScript
var climbStairs = function(n, costs) {
    let a = 0, b = 0, c = 0;
    for (let i = 0; i < n; ++i) {
        const nxt = Math.min(a + 9, b + 4, c + 1) + costs[i];
        a = b;
        b = c;
        c = nxt;
    }
    return c;
};
```

```TypeScript
function climbStairs(n: number, costs: number[]): number {
    let a = 0, b = 0, c = 0;
    for (let i = 0; i < n; ++i) {
        const nxt = Math.min(a + 9, b + 4, c + 1) + costs[i];
        a = b;
        b = c;
        c = nxt;
    }
    return c;
};
```

```Rust
impl Solution {
    pub fn climb_stairs(n: i32, costs: Vec<i32>) -> i32 {
        let (mut a, mut b, mut c) = (0, 0, 0);
        for i in 0..n as usize {
            let nxt = (a + 9).min(b + 4).min(c + 1) + costs[i];
            a = b;
            b = c;
            c = nxt;
        }
        c
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$。
