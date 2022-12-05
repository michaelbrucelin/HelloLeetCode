#### [方法二：动态规划](https://leetcode.cn/problems/closest-dessert-cost/solutions/2004210/zui-jie-jin-mu-biao-jie-ge-de-tian-dian-2ck06/)

**思路与算法**

我们可以将问题转化为对于某一个开销是否存在甜品制作方案问题，然后我们选择与目标价格最接近的合法甜品制作方案即可，那么问题就转化为了「01 背包」问题（关于「01 背包」的概念可见 [百度百科](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F01%E8%83%8C%E5%8C%85%2F4301245)）。这样我们就可以把问题求解从指数级别降到多项式级别了。对于「01 背包」的求解我们可以用「动态规划」来解决。

设最小的基料开销为 x。若 $x \ge target$，则无论我们是否添加配料都不会使甜品制作的开销与目标价格 target 的距离缩小，所以此时直接返回此最小的基料开销即可。当最小的基料开销小于 target 时，我们可以对超过 target 的制作开销方案只保存其最小的一份即可，并可以初始化为 $2 \times target - x$，因为大于该开销的方案与目标价格 target 的距离一定大于仅选最小基料的情况，所以一定不会是最优解。将背包的容量 MAXC 设置为 target。然后我们按「01 背包」的方法来依次枚举配料来进行放置。

我们设 can[i] 表示对于甜品制作开销为 i 是否存在合法方案，如果存在则其等于 true，否则为 false，初始为 false。因为单独选择一种基料的情况是合法的，所以我们对 can 进行初始化：

$can[x] = true, \forall x \in baseCosts \And x < MAXC$

然后我们按「01 背包」的方法来依次枚举配料来进行放置，因为每种配料我们最多只能选两份，所以我们可以直接将每种配料变为两个，然后对于两个配料都进行放置即可。因为任意一个合法方案加上一份配料一定也为合法制作方案。所以当要放置的配料开销为 y 时，对于开销为 $c, c > y$ 的转移方程为：

$can[c] = can[c - y] ~|~ can[c], c > y$

因为每一个状态的求解只和前面的状态有关，所以我们可以从后往前来更新每一个状态。然后当配料全部放置后，我们可以从目标价格 target 往左搜索找到最接近 target 的合法方案并与大于 target 的方案做比较返回与 target 更接近的方案即可。

**代码**

```python
class Solution:
    def closestCost(self, baseCosts: List[int], toppingCosts: List[int], target: int) -> int:
        x = min(baseCosts)
        if x > target:
            return x
        can = [False] * (target + 1)
        ans = 2 * target - x
        for c in baseCosts:
            if c <= target:
                can[c] = True
            else:
                ans = min(ans, c)
        for c in toppingCosts:
            for count in range(2):
                for i in range(target, 0, -1):
                    if can[i] and i + c > target:
                        ans = min(ans, i + c)
                    if i - c > 0 and not can[i]:
                        can[i] = can[i - c]
        for i in range(ans - target + 1):
            if can[target - i]:
                return target - i
        return ans
```

```cpp
class Solution {
public:
    int closestCost(vector<int>& baseCosts, vector<int>& toppingCosts, int target) {
        int x = *min_element(baseCosts.begin(), baseCosts.end());
        if (x >= target) {
            return x;
        }
        vector<bool> can(target + 1, false);
        int res = 2 * target - x;
        for (auto& b : baseCosts) {
            if (b <= target) {
                can[b] = true;
            } else {
                res = min(res, b);
            }
        }
        for (auto& t : toppingCosts) {
            for (int count = 0; count < 2; ++count) {
                for (int i = target; i; --i) {
                    if (can[i] && i + t > target) {
                        res = min(res, i + t);
                    }
                    if (i - t > 0) {
                        can[i] = can[i] | can[i - t];
                    }
                }
            }
        }
        for (int i = 0; i <= res - target; ++i) {
            if (can[target - i]) {
                return target - i;
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int closestCost(int[] baseCosts, int[] toppingCosts, int target) {
        int x = Arrays.stream(baseCosts).min().getAsInt();
        if (x >= target) {
            return x;
        }
        boolean[] can = new boolean[target + 1];
        int res = 2 * target - x;
        for (int b : baseCosts) {
            if (b <= target) {
                can[b] = true;
            } else {
                res = Math.min(res, b);
            }
        }
        for (int t : toppingCosts) {
            for (int count = 0; count < 2; ++count) {
                for (int i = target; i > 0; --i) {
                    if (can[i] && i + t > target) {
                        res = Math.min(res, i + t);
                    }
                    if (i - t > 0) {
                        can[i] = can[i] | can[i - t];
                    }
                }
            }
        }
        for (int i = 0; i <= res - target; ++i) {
            if (can[target - i]) {
                return target - i;
            }
        }
        return res;
    }
}
```

```c#
public class Solution {
    public int ClosestCost(int[] baseCosts, int[] toppingCosts, int target) {
        int x = baseCosts.Min();
        if (x >= target) {
            return x;
        }
        bool[] can = new bool[target + 1];
        int res = 2 * target - x;
        foreach (int b in baseCosts) {
            if (b <= target) {
                can[b] = true;
            } else {
                res = Math.Min(res, b);
            }
        }
        foreach (int t in toppingCosts) {
            for (int count = 0; count < 2; ++count) {
                for (int i = target; i > 0; --i) {
                    if (can[i] && i + t > target) {
                        res = Math.Min(res, i + t);
                    }
                    if (i - t > 0) {
                        can[i] = can[i] | can[i - t];
                    }
                }
            }
        }
        for (int i = 0; i <= res - target; ++i) {
            if (can[target - i]) {
                return target - i;
            }
        }
        return res;
    }
}
```

```c
#define MIN(a, b) ((a) < (b) ? (a) : (b))

int closestCost(int* baseCosts, int baseCostsSize, int* toppingCosts, int toppingCostsSize, int target) {
    int x = INT_MAX;
    for (int i = 0; i < baseCostsSize; i++) {
        x = MIN(x, baseCosts[i]);
    }
    if (x >= target) {
        return x;
    }
    bool can[target + 1];
    memset(can, 0, sizeof(can));
    int res = 2 * target - x;
    for (int i = 0; i < baseCostsSize; i++) {
        if (baseCosts[i] <= target) {
            can[baseCosts[i]] = true;
        } else {
            res = MIN(res, baseCosts[i]);
        }
    }
    for (int j = 0; j < toppingCostsSize; j++) {
        for (int count = 0; count < 2; ++count) {
            for (int i = target; i > 0; --i) {
                if (can[i] && i + toppingCosts[j] > target) {
                    res = MIN(res, i + toppingCosts[j]);
                }
                if (i - toppingCosts[j] > 0) {
                    can[i] = can[i] | can[i - toppingCosts[j]];
                }
            }
        }
    }
    for (int i = 0; i <= res - target; ++i) {
        if (can[target - i]) {
            return target - i;
        }
    }
    return res;
}
```

```javascript
var closestCost = function(baseCosts, toppingCosts, target) {
    const x = _.min(baseCosts);
    if (x >= target) {
        return x;
    }
    const can = new Array(target + 1).fill(0);
    let res = 2 * target - x;
    for (const b of baseCosts) {
        if (b <= target) {
            can[b] = true;
        } else {
            res = Math.min(res, b);
        }
    }
    for (const t of toppingCosts) {
        for (let count = 0; count < 2; ++count) {
            for (let i = target; i > 0; --i) {
                if (can[i] && i + t > target) {
                    res = Math.min(res, i + t);
                }
                if (i - t > 0) {
                    can[i] = can[i] | can[i - t];
                }
            }
        }
    }
    for (let i = 0; i <= res - target; ++i) {
        if (can[target - i]) {
            return target - i;
        }
    }
    return res;
}
```

```go
func closestCost(baseCosts []int, toppingCosts []int, target int) int {
    x := baseCosts[0]
    for _, c := range baseCosts {
        x = min(x, c)
    }
    if x > target {
        return x
    }
    can := make([]bool, target+1)
    ans := 2*target - x
    for _, c := range baseCosts {
        if c <= target {
            can[c] = true
        } else {
            ans = min(ans, c)
        }
    }
    for _, c := range toppingCosts {
        for count := 0; count < 2; count++ {
            for i := target; i > 0; i-- {
                if can[i] && i+c > target {
                    ans = min(ans, i+c)
                }
                if i-c > 0 {
                    can[i] = can[i] || can[i-c]
                }
            }
        }
    }
    for i := 0; i <= ans-target; i++ {
        if can[target-i] {
            return target - i
        }
    }
    return ans
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}
```

**复杂度分析**

-   时间复杂度：$O(target \times m)$，其中 $m$ 为数组 $toppingCosts$ 的长度，$target$ 为目标值。动态规划的时间复杂度是 $O(MAXC \times m)$，由于 $MAXC = target$，因此时间复杂度是 $O(target \times m)$。
-   空间复杂度：$O(target)$，其中 $target$ 为目标值。需要创建长度为 $target+1$ 的数组 $can$。
