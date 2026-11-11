### [采购的最小花费](https://leetcode.cn/problems/minimum-cost-to-acquire-required-items/solutions/4050331/cai-gou-de-zui-xiao-hua-fei-by-leetcode-r7frt/)

#### 方法一：贪心

**思路与算法**

假设我们通过购买物品后，满足的类型 $1$ 和类型 $2$ 的需求数量分别为 $cnt_1$ 和 $cnt_2$。购买商品前，$cnt_1=cnt_2=0$。

我们有 $3$ 种类型的物品可以购买：

- 物品 $1$：花费 $cost_1$，使得 $cnt_1$ 增加 $1$。
- 物品 $2$：花费 $cost_2$，使得 $cnt_2$ 增加 $1$。
- 物品 $3$：花费 $costBoth$，使得 $cnt_1$ 和 $cnt_2$ 均增加 $1$。

我们需要通过购买物品，使得 $cnt_1\ge need_1$，并且 $cnt_2\ge need_2$。在满足该条件的情况下，还需使得总花费 $totalCost$ 最小。

当 $cost_1+cost_2\le costBoth$ 时，存在一个**不购买物品 $3$ 的最优解**。此时，只需购买 $need_1$ 件物品 $1$ 和 $need_2$ 件物品 $2$，即可获得最小总花费：

$$totalCost=need_1\times cost_1+need_2\times cost_2$$

> 假如我们购买了至少一件物品 $3$，总花费为 $totalCost$，那么我们可以选择放弃购买一件物品 $3$，换为购买一件物品 $1$ 和物品 $2$，并且满足的需求数量不会改变。更换购买方案后的总花费将变为 $totalCost^′=totalCost-costBoth+cost_1+cost_2\le totalCost$。也就是说，将所有的物品 $3$ 更换为物品 $1$ 和 物品 $2$ 后，总花费不会更大。

反之，当 $cost_1+cost_2>costBoth$ 时，在最优解中，**不可能同时存在物品 $1$ 和物品 2**。

> 假如我们至少购买了一件物品 $1$ 和一件物品 $2$，总花费为 $totalCost$，那么我们可以选择放弃购买一件物品 $1$ 和物品 $2$，换为购买一件物品 $3$，并且满足的需求数量不会改变。更换购买方案后的总花费将变为 $totalCost^′=totalCost-cost_1-cost_2+costBoth<totalCost$。也就是说，尽可能将物品 $1$ 和物品 $2$ 更换为物品 $3$ 后，总花费更小。

因此，在最优解中，如果两种类型的需求都尚未满足，就应当继续购买物品 $3$。由于每购买一件物品 $3$，可以同时使 $cnt_1$ 和 $cnt_2$ 增加 $1$，所以在购买 $min(need_1,need_2)$ 件物品 $3$ 后，至少有一种类型的需求已经满足。

- 如果类型 $1$ 的需求仍未被满足，我们只需考虑以最小花费增加 $cnt_1$ 至 $need_1$，而不需再考虑类型 $2$ 的需求。此时继续购买物品 $1$ 或物品 $3$ 都将使得 $cnt_1$ 增加 $1$，两者在剩余需求上作用相同，因此只需选择花费较小的物品来达成题目条件即可。
- 同理，如果类型 $2$ 的需求仍未被满足，我们只需考虑以最小花费增加 $cnt_2$ 至 $need_2$，而不需再考虑类型 $1$ 的需求。此时继续购买物品 $2$ 或物品 $3$ 都将使得 $cnt_2$ 增加 $1$，只需选择花费较小的物品来达成题目条件即可。

**代码**

```C++
class Solution {
public:
    long long minimumCost(int cost1, int cost2, int costBoth, int need1, int need2) {
        long long totalCost = 0;

        // 分别购买更便宜，不需要物品 3
        if (cost1 + cost2 <= costBoth) {
            totalCost = 1LL * cost1 * need1 + 1LL * cost2 * need2;
        }
        else {
            // 优先购买物品 3，直到一种需求满足
            int cnt_3 = min(need1, need2);
            totalCost = 1LL * cnt_3 * costBoth;

            need1 -= cnt_3;
            need2 -= cnt_3;

            // 类型 1 的需求还未被满足，选择物品 1 或物品 3 中更便宜的
            if (need1 > 0) {
                totalCost += 1LL * need1 * min(cost1, costBoth);
            }

            // 类型 2 的需求还未被满足，选择物品 2 或物品 3 中更便宜的
            else if (need2 > 0) {
                totalCost += 1LL * need2 * min(cost2, costBoth);
            }
        }

        return totalCost;
    }
};
```

```Python
class Solution:
    def minimumCost(self, cost1: int, cost2: int, costBoth: int, need1: int, need2: int) -> int:
        # 分别购买更便宜，不需要物品 3
        if cost1 + cost2 <= costBoth:
            totalCost = cost1 * need1 + cost2 * need2
        else:
            # 优先购买物品 3，直到一种需求满足
            cnt_3 = min(need1, need2)
            totalCost = cnt_3 * costBoth

            need1 -= cnt_3
            need2 -= cnt_3

            # 类型 1 的需求还未被满足，选择物品 1 或物品 3 中更便宜的
            if need1 > 0:
                totalCost += need1 * min(cost1, costBoth)

            # 类型 2 的需求还未被满足，选择物品 2 或物品 3 中更便宜的
            elif need2 > 0:
                totalCost += need2 * min(cost2, costBoth)

        return totalCost
```

```Java
class Solution {
    public long minimumCost(int cost1, int cost2, int costBoth, int need1, int need2) {
        long totalCost = 0;

        // 分别购买更便宜，不需要物品 3
        if (cost1 + cost2 <= costBoth) {
            totalCost = 1L * cost1 * need1 + 1L * cost2 * need2;
        } else {
            // 优先购买物品 3，直到一种需求满足
            int cnt_3 = Math.min(need1, need2);
            totalCost = 1L * cnt_3 * costBoth;

            need1 -= cnt_3;
            need2 -= cnt_3;

            // 类型 1 的需求还未被满足，选择物品 1 或物品 3 中更便宜的
            if (need1 > 0) {
                totalCost += 1L * need1 * Math.min(cost1, costBoth);
            // 类型 2 的需求还未被满足，选择物品 2 或物品 3 中更便宜的
            } else if (need2 > 0) {
                totalCost += 1L * need2 * Math.min(cost2, costBoth);
            }
        }

        return totalCost;
    }
}
```

```CSharp
public class Solution {
    public long MinimumCost(int cost1, int cost2, int costBoth, int need1, int need2) {
        long totalCost = 0;

        // 分别购买更便宜，不需要物品 3
        if (cost1 + cost2 <= costBoth) {
            totalCost = 1L * cost1 * need1 + 1L * cost2 * need2;
        } else {
            // 优先购买物品 3，直到一种需求满足
            int cnt_3 = Math.Min(need1, need2);
            totalCost = 1L * cnt_3 * costBoth;

            need1 -= cnt_3;
            need2 -= cnt_3;

            // 类型 1 的需求还未被满足，选择物品 1 或物品 3 中更便宜的
            if (need1 > 0) {
                totalCost += 1L * need1 * Math.Min(cost1, costBoth);
            // 类型 2 的需求还未被满足，选择物品 2 或物品 3 中更便宜的
            } else if (need2 > 0) {
                totalCost += 1L * need2 * Math.Min(cost2, costBoth);
            }
        }

        return totalCost;
    }
}
```

```Go
func minimumCost(cost1 int, cost2 int, costBoth int, need1 int, need2 int) int64 {
    var totalCost int64 = 0

    // 分别购买更便宜，不需要物品 3
    if cost1+cost2 <= costBoth {
        totalCost = int64(cost1)*int64(need1) + int64(cost2)*int64(need2)
    } else {
        // 优先购买物品 3，直到一种需求满足
        cnt3 := min(need1, need2)
        totalCost = int64(cnt3) * int64(costBoth)

        need1 -= cnt3
        need2 -= cnt3

        // 类型 1 的需求还未被满足，选择物品 1 或物品 3 中更便宜的
        if need1 > 0 {
            totalCost += int64(need1) * int64(min(cost1, costBoth))
        } else if need2 > 0 {
            // 类型 2 的需求还未被满足，选择物品 2 或物品 3 中更便宜的
            totalCost += int64(need2) * int64(min(cost2, costBoth))
        }
    }

    return totalCost
}
```

```C
long long minimumCost(int cost1, int cost2, int costBoth, int need1, int need2) {
    long long totalCost = 0;

    // 分别购买更便宜，不需要物品 3
    if (cost1 + cost2 <= costBoth) {
        totalCost = 1LL * cost1 * need1 + 1LL * cost2 * need2;
    } else {
        // 优先购买物品 3，直到一种需求满足
        int cnt_3 = need1 < need2 ? need1 : need2;
        totalCost = 1LL * cnt_3 * costBoth;

        need1 -= cnt_3;
        need2 -= cnt_3;

        // 类型 1 的需求还未被满足，选择物品 1 或物品 3 中更便宜的
        if (need1 > 0) {
            totalCost += 1LL * need1 * (cost1 < costBoth ? cost1 : costBoth);
        // 类型 2 的需求还未被满足，选择物品 2 或物品 3 中更便宜的
        } else if (need2 > 0) {
            totalCost += 1LL * need2 * (cost2 < costBoth ? cost2 : costBoth);
        }
    }

    return totalCost;
}
```

```JavaScript
var minimumCost = function(cost1, cost2, costBoth, need1, need2) {
    let totalCost = 0;

    // 分别购买更便宜，不需要物品 3
    if (cost1 + cost2 <= costBoth) {
        totalCost = cost1 * need1 + cost2 * need2;
    } else {
        // 优先购买物品 3，直到一种需求满足
        let cnt_3 = Math.min(need1, need2);
        totalCost = cnt_3 * costBoth;

        need1 -= cnt_3;
        need2 -= cnt_3;

        // 类型 1 的需求还未被满足，选择物品 1 或物品 3 中更便宜的
        if (need1 > 0) {
            totalCost += need1 * Math.min(cost1, costBoth);
        // 类型 2 的需求还未被满足，选择物品 2 或物品 3 中更便宜的
        } else if (need2 > 0) {
            totalCost += need2 * Math.min(cost2, costBoth);
        }
    }

    return totalCost;
};
```

```TypeScript
function minimumCost(cost1: number, cost2: number, costBoth: number, need1: number, need2: number): number {
    let totalCost = 0;

    // 分别购买更便宜，不需要物品 3
    if (cost1 + cost2 <= costBoth) {
        totalCost = cost1 * need1 + cost2 * need2;
    } else {
        // 优先购买物品 3，直到一种需求满足
        const cnt_3 = Math.min(need1, need2);
        totalCost = cnt_3 * costBoth;

        need1 -= cnt_3;
        need2 -= cnt_3;

        // 类型 1 的需求还未被满足，选择物品 1 或物品 3 中更便宜的
        if (need1 > 0) {
            totalCost += need1 * Math.min(cost1, costBoth);
        // 类型 2 的需求还未被满足，选择物品 2 或物品 3 中更便宜的
        } else if (need2 > 0) {
            totalCost += need2 * Math.min(cost2, costBoth);
        }
    }

    return totalCost;
}
```

```Rust
impl Solution {
    pub fn minimum_cost(cost1: i32, cost2: i32, cost_both: i32, need1: i32, need2: i32) -> i64 {
        let mut total_cost: i64 = 0;
        let mut need1 = need1;
        let mut need2 = need2;

        // 分别购买更便宜，不需要物品 3
        if cost1 + cost2 <= cost_both {
            total_cost = cost1 as i64 * need1 as i64 + cost2 as i64 * need2 as i64;
        } else {
            // 优先购买物品 3，直到一种需求满足
            let cnt_3 = need1.min(need2);
            total_cost = cnt_3 as i64 * cost_both as i64;

            need1 -= cnt_3;
            need2 -= cnt_3;

            // 类型 1 的需求还未被满足，选择物品 1 或物品 3 中更便宜的
            if need1 > 0 {
                total_cost += need1 as i64 * cost1.min(cost_both) as i64;
            }
            // 类型 2 的需求还未被满足，选择物品 2 或物品 3 中更便宜的
            else if need2 > 0 {
                total_cost += need2 as i64 * cost2.min(cost_both) as i64;
            }
        }

        total_cost
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$，只使用了常数个变量。
