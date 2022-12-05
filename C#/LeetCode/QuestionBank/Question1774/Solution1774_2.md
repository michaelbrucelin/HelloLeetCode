#### [方法一：回溯](https://leetcode.cn/problems/closest-dessert-cost/solutions/2004210/zui-jie-jin-mu-biao-jie-ge-de-tian-dian-2ck06/)

**思路与算法**

首先题目给出长度分别为 n 的冰淇淋基料数组 baseCosts 和长度为 m 的配料数组 toppingCosts，其中 baseCosts[i] 表示第 i 种冰淇淋基料的价格，toppingCosts[j] 表示一份第 j 种冰淇淋配料的价格，以及一个整数 target 表示我们需要制作甜点的目标价格。现在在制作甜品上我们需要遵守以下三条规则：

-   必须选择**一种**冰淇淋基料；
-   可以添加**一种或多种**配料，也可以不添加任何配料；
-   每种配料**最多两份**。

我们希望做的甜点总成本尽可能接近目标价格 target，那么我们现在按照规则对于每一种冰淇淋基料用回溯的方式来针对它进行甜品制作。又因为每一种配料都是正整数，所以在回溯的过程中总开销只能只增不减，当回溯过程中当前开销大于目标价格 target 后，继续往下搜索只能使开销与 target 的差值更大，所以如果此时差值已经大于等于我们已有最优方案的差值，我们可以停止继续往下搜索，及时回溯。

**代码**

```python
class Solution:
    def closestCost(self, baseCosts: List[int], toppingCosts: List[int], target: int) -> int:
        ans = min(baseCosts)
        def dfs(p: int, cur_cost: int) -> None:
            nonlocal ans
            if abs(ans - target) < cur_cost - target:
                return
            if abs(ans - target) >= abs(cur_cost - target):
                if abs(ans - target) > abs(cur_cost - target):
                    ans = cur_cost
                else:
                    ans = min(ans, cur_cost)
            if p == len(toppingCosts):
                return
            dfs(p + 1, cur_cost + toppingCosts[p] * 2)
            dfs(p + 1, cur_cost + toppingCosts[p])
            dfs(p + 1, cur_cost)
        for c in baseCosts:
            dfs(0, c)
        return ans
```

```cpp
class Solution {
public:
    void dfs(const vector<int>& toppingCosts, int p, int curCost, int& res, const int& target) {
        if (abs(res - target) < curCost - target) {
            return;
        } else if (abs(res - target) >= abs(curCost - target)) {
            if (abs(res - target) > abs(curCost - target)) {
                res = curCost;
            } else {
                res = min(res, curCost);
            }
        }
        if (p == toppingCosts.size()) {
            return;
        }
        dfs(toppingCosts, p + 1, curCost + toppingCosts[p] * 2, res, target);
        dfs(toppingCosts, p + 1, curCost + toppingCosts[p], res, target);
        dfs(toppingCosts, p + 1, curCost, res, target);
    }

    int closestCost(vector<int>& baseCosts, vector<int>& toppingCosts, int target) {
        int res = *min_element(baseCosts.begin(), baseCosts.end());
        for (auto& b : baseCosts) {
            dfs(toppingCosts, 0, b, res, target);
        }
        return res;
    }
};
```

```java
class Solution {
    int res;

    public int closestCost(int[] baseCosts, int[] toppingCosts, int target) {
        res = Arrays.stream(baseCosts).min().getAsInt();
        for (int b : baseCosts) {
            dfs(toppingCosts, 0, b, target);
        }
        return res;
    }

    public void dfs(int[] toppingCosts, int p, int curCost, int target) {
        if (Math.abs(res - target) < curCost - target) {
            return;
        } else if (Math.abs(res - target) >= Math.abs(curCost - target)) {
            if (Math.abs(res - target) > Math.abs(curCost - target)) {
                res = curCost;
            } else {
                res = Math.min(res, curCost);
            }
        }
        if (p == toppingCosts.length) {
            return;
        }
        dfs(toppingCosts, p + 1, curCost + toppingCosts[p] * 2, target);
        dfs(toppingCosts, p + 1, curCost + toppingCosts[p], target);
        dfs(toppingCosts, p + 1, curCost, target);
    }
}
```

```c#
public class Solution {
    int res;

    public int ClosestCost(int[] baseCosts, int[] toppingCosts, int target) {
        res = baseCosts.Min();
        foreach (int b in baseCosts) {
            DFS(toppingCosts, 0, b, target);
        }
        return res;
    }

    public void DFS(int[] toppingCosts, int p, int curCost, int target) {
        if (Math.Abs(res - target) < curCost - target) {
            return;
        } else if (Math.Abs(res - target) >= Math.Abs(curCost - target)) {
            if (Math.Abs(res - target) > Math.Abs(curCost - target)) {
                res = curCost;
            } else {
                res = Math.Min(res, curCost);
            }
        }
        if (p == toppingCosts.Length) {
            return;
        }
        DFS(toppingCosts, p + 1, curCost + toppingCosts[p] * 2, target);
        DFS(toppingCosts, p + 1, curCost + toppingCosts[p], target);
        DFS(toppingCosts, p + 1, curCost, target);
    }
}
```

```c
#define MIN(a, b) ((a) < (b) ? (a) : (b))

void dfs(const int *toppingCosts, int toppingCostsSize, int p, int curCost, int *res, const int target) {
    if (abs(*res - target) < curCost - target) {
        return;
    } else if (abs(*res - target) >= abs(curCost - target)) {
        if (abs(*res - target) > abs(curCost - target)) {
            *res = curCost;
        } else {
            *res = MIN(*res, curCost);
        }
    }
    if (p == toppingCostsSize) {
        return;
    }
    dfs(toppingCosts, toppingCostsSize, p + 1, curCost + toppingCosts[p] * 2, res, target);
    dfs(toppingCosts, toppingCostsSize, p + 1, curCost + toppingCosts[p], res, target);
    dfs(toppingCosts, toppingCostsSize, p + 1, curCost, res, target);
}

int closestCost(int* baseCosts, int baseCostsSize, int* toppingCosts, int toppingCostsSize, int target) {
    int res = INT_MAX;
    for (int i = 0; i < baseCostsSize; i++) {
        res = MIN(res, baseCosts[i]);
    }
    for (int i = 0; i < baseCostsSize; i++) {
        dfs(toppingCosts, toppingCostsSize, 0, baseCosts[i], &res, target);
    }
    return res;
}
```

```javascript
var closestCost = function(baseCosts, toppingCosts, target) {
    let res = _.min(baseCosts);
    const dfs = (toppingCosts, p, curCost, target) => {
        if (Math.abs(res - target) < curCost - target) {
            return;
        } else if (Math.abs(res - target) >= Math.abs(curCost - target)) {
            if (Math.abs(res - target) > Math.abs(curCost - target)) {
                res = curCost;
            } else {
                res = Math.min(res, curCost);
            }
        }
        if (p === toppingCosts.length) {
            return;
        }
        dfs(toppingCosts, p + 1, curCost + toppingCosts[p] * 2, target);
        dfs(toppingCosts, p + 1, curCost + toppingCosts[p], target);
        dfs(toppingCosts, p + 1, curCost, target);
    };
    for (const b of baseCosts) {
        dfs(toppingCosts, 0, b, target);
    }
    return res;
}
```

```go
func closestCost(baseCosts []int, toppingCosts []int, target int) int {
    ans := baseCosts[0]
    for _, c := range baseCosts {
        ans = min(ans, c)
    }
    var dfs func(int, int)
    dfs = func(p, curCost int) {
        if abs(ans-target) < curCost-target {
            return
        } else if abs(ans-target) >= abs(curCost-target) {
            if abs(ans-target) > abs(curCost-target) {
                ans = curCost
            } else {
                ans = min(ans, curCost)
            }
        }
        if p == len(toppingCosts) {
            return
        }
        dfs(p+1, curCost+toppingCosts[p]*2)
        dfs(p+1, curCost+toppingCosts[p])
        dfs(p+1, curCost)
    }
    for _, c := range baseCosts {
        dfs(0, c)
    }
    return ans
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}
```

**复杂度分析**

-   时间复杂度：$O(n \times 3^m)$，其中 n，m 分别为数组 $baseCosts$，$toppingCosts$ 的长度。
-   空间复杂度：$O(m)$，主要为回溯递归的空间开销。
