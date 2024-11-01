### [超级饮料的最大强化能量](https://leetcode.cn/problems/maximum-energy-boost-from-two-drinks/solutions/2969563/chao-ji-yin-liao-de-zui-da-qiang-hua-nen-7s2a/)

#### 方法一：动态规划

**思路与算法**

题目给定了两个长度为 $n$ 的数组 $energyDrinkA$ 和 $energyDrinkB$（我们这里简称 $A$ 和 $B$），你需要从左到右依次取 $n$ 个数字，每次可以从 $A$ 取或者从 $B$ 取，但如果上一次（第 $i-1$ 次）是从 $A$ 取的，那么第 $i$ 次要切换就必须暂停一次，接着在第 $i+1$ 次可以从 $B$ 取。求可以取得的数字之和的最大值。

可以发现每次取数所得的和只与前面一步怎么决策有关，如果上一步切换，那么计算和的时候从上两步计算，否则从上一步计算，因此我们设计 $d[i][0/1]$ 分别表示第 $i$ 步从 $A$ 或者从 $B$ 取数时，可以获得的最大值。这样一来，我们可以得到相应的转移方程：

$d[i][0]=max(d[i-1][0],d[i-2][1])+A[i]$
$d[i][1]=max(d[i-1][1],d[i-2][0])+B[i]$

注意 $i$ 在 $1$ 和 $2$ 时的特殊情况（起始下标设置为 $1$）。
最终我们选择 $max(d[n][0],d[n][1])$ 作为答案。

**代码**

```C++
class Solution {
public:
    using ll = long long;
    long long maxEnergyBoost(vector<int>& energyDrinkA, vector<int>& energyDrinkB) {
        int n = energyDrinkA.size();
        vector<vector<ll>> d(n + 1, vector<ll>(2, 0));
        for (int i = 1; i <= n; i++) {
            d[i][0] = d[i - 1][0] + energyDrinkA[i - 1];
            d[i][1] = d[i - 1][1] + energyDrinkB[i - 1];
            if (i >= 2) {
                d[i][0] = max(d[i][0], d[i - 2][1] + energyDrinkA[i - 1]);
                d[i][1] = max(d[i][1], d[i - 2][0] + energyDrinkB[i - 1]);
            }
        }
        return max(d[n][0], d[n][1]);
    }
};
```

```Python
class Solution:
    def maxEnergyBoost(self, energyDrinkA: List[int], energyDrinkB: List[int]) -> int:
        n = len(energyDrinkA)
        d = [[0, 0] for _ in range(n + 1)]
        for i in range(1, n + 1):
            d[i][0] = d[i - 1][0] + energyDrinkA[i - 1];
            d[i][1] = d[i - 1][1] + energyDrinkB[i - 1];
            if i >= 2:
                d[i][0] = max(d[i][0], d[i - 2][1] + energyDrinkA[i - 1]);
                d[i][1] = max(d[i][1], d[i - 2][0] + energyDrinkB[i - 1]);
        return max(d[n][0], d[n][1])
```

```Java
class Solution {
    public long maxEnergyBoost(int[] energyDrinkA, int[] energyDrinkB) {
        int n = energyDrinkA.length;
        long[][] d = new long[n + 1][2];
        for (int i = 1; i <= n; i++) {
            d[i][0] = d[i - 1][0] + energyDrinkA[i - 1];
            d[i][1] = d[i - 1][1] + energyDrinkB[i - 1];
            if (i >= 2) {
                d[i][0] = Math.max(d[i][0], d[i - 2][1] + energyDrinkA[i - 1]);
                d[i][1] = Math.max(d[i][1], d[i - 2][0] + energyDrinkB[i - 1]);
            }
        }
        return Math.max(d[n][0], d[n][1]);
    }
}
```

```CSharp
public class Solution {
    public long MaxEnergyBoost(int[] energyDrinkA, int[] energyDrinkB) {
        int n = energyDrinkA.Length;
        long[,] d = new long[n + 1, 2];
        for (int i = 1; i <= n; i++) {
            d[i, 0] = d[i - 1, 0] + energyDrinkA[i - 1];
            d[i, 1] = d[i - 1, 1] + energyDrinkB[i - 1];
            if (i >= 2) {
                d[i, 0] = Math.Max(d[i, 0], d[i - 2, 1] + energyDrinkA[i - 1]);
                d[i, 1] = Math.Max(d[i, 1], d[i - 2, 0] + energyDrinkB[i - 1]);
            }
        }
        return Math.Max(d[n, 0], d[n, 1]);
    }
}
```

```Go
func maxEnergyBoost(energyDrinkA []int, energyDrinkB []int) int64 {
    n := len(energyDrinkA)
    d := make([][2]int64, n + 1)
    for i := 1; i <= n; i++ {
        d[i][0] = d[i-1][0] + int64(energyDrinkA[i-1])
        d[i][1] = d[i-1][1] + int64(energyDrinkB[i-1])
        if i >= 2 {
            d[i][0] = max(d[i][0], d[i - 2][1] + int64(energyDrinkA[i - 1]))
            d[i][1] = max(d[i][1], d[i - 2][0] + int64(energyDrinkB[i - 1]))
        }
    }
    return max(d[n][0], d[n][1])
}
```

```C
long long maxEnergyBoost(int* energyDrinkA, int energyDrinkASize, int* energyDrinkB, int energyDrinkBSize) {
    int n = energyDrinkASize;
    long long d[n + 1][2];
    for (int i = 0; i <= n; i++) {
        d[i][0] = 0;
        d[i][1] = 0;
    }
    for (int i = 1; i <= n; i++) {
        d[i][0] = d[i - 1][0] + energyDrinkA[i - 1];
        d[i][1] = d[i - 1][1] + energyDrinkB[i - 1];
        if (i >= 2) {
            d[i][0] = fmax(d[i][0], d[i - 2][1] + energyDrinkA[i - 1]);
            d[i][1] = fmax(d[i][1], d[i - 2][0] + energyDrinkB[i - 1]);
        }
    }
    return fmax(d[n][0], d[n][1]);
}
```

```JavaScript
var maxEnergyBoost = function(energyDrinkA, energyDrinkB) {
    const n = energyDrinkA.length;
    const d = Array.from({ length: n + 1 }, () => [0, 0]);
    for (let i = 1; i <= n; i++) {
        d[i][0] = d[i - 1][0] + energyDrinkA[i - 1];
        d[i][1] = d[i - 1][1] + energyDrinkB[i - 1];
        if (i >= 2) {
            d[i][0] = Math.max(d[i][0], d[i - 2][1] + energyDrinkA[i - 1]);
            d[i][1] = Math.max(d[i][1], d[i - 2][0] + energyDrinkB[i - 1]);
        }
    }
    return Math.max(d[n][0], d[n][1]);
};
```

```TypeScript
function maxEnergyBoost(energyDrinkA: number[], energyDrinkB: number[]): number {
    const n = energyDrinkA.length;
    const d: number[][] = Array.from({ length: n + 1 }, () => [0, 0]);
    for (let i = 1; i <= n; i++) {
        d[i][0] = d[i - 1][0] + energyDrinkA[i - 1];
        d[i][1] = d[i - 1][1] + energyDrinkB[i - 1];
        if (i >= 2) {
            d[i][0] = Math.max(d[i][0], d[i - 2][1] + energyDrinkA[i - 1]);
            d[i][1] = Math.max(d[i][1], d[i - 2][0] + energyDrinkB[i - 1]);
        }
    }
    return Math.max(d[n][0], d[n][1]);
};
```

```Rust
impl Solution {
    pub fn max_energy_boost(energy_drink_a: Vec<i32>, energy_drink_b: Vec<i32>) -> i64 {
        let n = energy_drink_a.len();
        let mut d = vec![vec![0; 2]; n + 1];
        for i in 1..=n {
            d[i][0] = d[i - 1][0] + energy_drink_a[i - 1] as i64;
            d[i][1] = d[i - 1][1] + energy_drink_b[i - 1] as i64;
            if i >= 2 {
                d[i][0] = d[i][0].max(d[i - 2][1] + energy_drink_a[i - 1] as i64);
                d[i][1] = d[i][1].max(d[i - 2][0] + energy_drink_b[i - 1] as i64);
            }
        }
        d[n][0].max(d[n][1])
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $energyDrinkA$ 的长度。我们共有 $O(n)$ 个状态，每个状态的转移复杂度为 $O(1)$，因此总的时间复杂度为 $O(n)$。
- 空间复杂度：$O(n)$，其中 $n$ 为 $energyDrinkA$ 的长度。维护状态的数组空间复杂度为 $O(n)$。
