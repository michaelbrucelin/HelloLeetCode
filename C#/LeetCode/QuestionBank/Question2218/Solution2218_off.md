### [从栈中取出 K 个硬币的最大面值和](https://leetcode.cn/problems/maximum-value-of-k-coins-from-piles/solutions/3047590/cong-zhan-zhong-qu-chu-k-ge-ying-bi-de-z-4hua/)

#### 方法一：转化为背包问题

**思路与算法**

我们可以使用背包型的动态规划解决本题。

记 $f[i]$ 表示进行 $i$ 次操作可以得到的最大面值之和。对于第 $j$ 个栈而言，我们对它进行 $t$ 次操作，就可以得到栈顶的 $t$ 个硬币，因此就可以得到状态转移方程：

$$f[i] \leftarrow f[i-t]+ \sum\limits_{p=0}^{t-1}​piles[j][p]$$

如果把右侧的 $\sum_{p=0}^{t-1}​piles[j][p]$ 看成一个重量为 $t$，价值为 $\sum_{p=0}^{t-1}​piles[j][p]$ 的物品，那么我们就将原问题转化为了一个经典的背包问题，可以使用动态规划进行解决。

需要注意的是，对于第 $j$ 个栈，我们实际上只能选择一个物品：如果先枚举 $t$，再进行状态转移，那么我们会有重复选择。因此我们需要对状态转移的顺序略微进行修改：先按照逆序枚举操作次数（重量）$i$，再枚举 $t$，这样可以保证在计算 $f[i]$ 时，$f[i-t]$ 都没有用到第 $j$ 个栈对应的任何物品，这样就保证了正确性。

**代码**

```C++
class Solution {
public:
    int maxValueOfCoins(vector<vector<int>>& piles, int k) {
        vector<int> f(k + 1, -1);
        f[0] = 0;
        for (const auto& pile: piles) {
            for (int i = k; i > 0; --i) {
                int value = 0;
                for (int t = 1; t <= pile.size(); ++t) {
                    value += pile[t - 1];
                    if (i >= t && f[i - t] != -1) {
                        f[i] = max(f[i], f[i - t] + value);
                    }
                }
            }
        }
        return f[k];
    }
};
```

```Java
class Solution {
    public int maxValueOfCoins(List<List<Integer>> piles, int k) {
        int[] f = new int[k + 1];
        Arrays.fill(f, -1);
        f[0] = 0;
        for (List<Integer> pile : piles) {
            for (int i = k; i > 0; --i) {
                int value = 0;
                for (int t = 1; t <= pile.size(); ++t) {
                    value += pile.get(t - 1);
                    if (i >= t && f[i - t] != -1) {
                        f[i] = Math.max(f[i], f[i - t] + value);
                    }
                }
            }
        }
        return f[k];
    }
}
```

```CSharp
public class Solution {
    public int MaxValueOfCoins(IList<IList<int>> piles, int k) {
        int[] f = new int[k + 1];
        Array.Fill(f, -1);
        f[0] = 0;
        foreach (IList<int> pile in piles) {
            for (int i = k; i > 0; --i) {
                int value = 0;
                for (int t = 1; t <= pile.Count; ++t) {
                    value += pile[t - 1];
                    if (i >= t && f[i - t] != -1) {
                        f[i] = Math.Max(f[i], f[i - t] + value);
                    }
                }
            }
        }
        return f[k];
    }
}
```

```Python
class Solution:
    def maxValueOfCoins(self, piles: List[List[int]], k: int) -> int:
        f = [0] + [-1] * k
        for pile in piles:
            for i in range(k, 0, -1):
                value = 0
                for t in range(1, len(pile) + 1):
                    value += pile[t - 1]
                    if i >= t and f[i - t] != -1:
                        f[i] = max(f[i], f[i - t] + value)
        return f[k]
```

```Go
func maxValueOfCoins(piles [][]int, k int) int {
    f := make([]int, k+1)
    for i := range f {
        f[i] = -1
    }
    f[0] = 0
    for _, pile := range piles {
        for i := k; i > 0; i-- {
            value := 0
            for t := 1; t <= len(pile); t++ {
                value += pile[t - 1]
                if i >= t && f[i - t] != -1 {
                    f[i] = max(f[i], f[i - t] + value)
                }
            }
        }
    }
    return f[k]
}
```

```C
int maxValueOfCoins(int** piles, int pilesSize, int* pilesColSize, int k) {
    int f[k + 1];
    for (int i = 0; i <= k; i++) {
        f[i] = -1;
    }
    f[0] = 0;
    for (int p = 0; p < pilesSize; p++) {
        for (int i = k; i > 0; i--) {
            int value = 0;
            for (int t = 1; t <= pilesColSize[p]; t++) {
                value += piles[p][t - 1];
                if (i >= t && f[i - t] != -1) {
                    f[i] = fmax(f[i], f[i - t] + value);
                }
            }
        }
    }
    return f[k];
}
```

```JavaScript
var maxValueOfCoins = function(piles, k) {
    let f = new Array(k + 1).fill(-1);
    f[0] = 0;
    for (let pile of piles) {
        for (let i = k; i > 0; i--) {
            let value = 0;
            for (let t = 1; t <= pile.length; t++) {
                value += pile[t - 1];
                if (i >= t && f[i - t] !== -1) {
                    f[i] = Math.max(f[i], f[i - t] + value);
                }
            }
        }
    }
    return f[k];
};
```

```TypeScript
function maxValueOfCoins(piles: number[][], k: number): number {
    let f: number[] = new Array(k + 1).fill(-1);
    f[0] = 0;
    for (let pile of piles) {
        for (let i = k; i > 0; i--) {
            let value: number = 0;
            for (let t = 1; t <= pile.length; t++) {
                value += pile[t - 1];
                if (i >= t && f[i - t] !== -1) {
                    f[i] = Math.max(f[i], f[i - t] + value);
                }
            }
        }
    }
    return f[k];
};
```

```Rust
impl Solution {
    pub fn max_value_of_coins(piles: Vec<Vec<i32>>, k: i32) -> i32 {
        let mut f = vec![-1; (k + 1) as usize];
        f[0] = 0;
        for pile in piles {
            for i in (1..= k as usize).rev() {
                let mut value = 0;
                for t in 1..=pile.len() {
                    value += pile[t - 1];
                    if i >= t && f[i - t] != -1 {
                        f[i] = f[i].max(f[i - t] + value);
                    }
                }
            }
        }
        f[k as usize]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nkl)$，其中 $l$ 是数组 $piles$ 中栈的平均大小，根据题目描述，本题中 $nl$ 的值不超过 $2000$。
- 空间复杂度：$O(k)$，即为动态规划中数组需要使用的空间。
