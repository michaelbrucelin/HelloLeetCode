### [最大合金数](https://leetcode.cn/problems/maximum-number-of-alloys/solutions/2617781/zui-da-he-jin-shu-by-leetcode-solution-uwll/?envType=daily-question&envId=2024-01-27)

#### 方法一：二分查找

##### 思路与算法

如果我们可以制造 $x$ 块合金，那么一定也可以制造 $x-1$ 块合金。因此存在 $x_{\max}$ ，使得我们可以制造数量小于等于 $x_{\max}$  的合金，但无法制造数量大于 $x_{\max}$  的合金。我们可以使用二分查找求出这个 $x_{\max}$ ，它也是最终的答案。

当我们二分到 $x$ 时，如何判断是否可以制造 $x$ 块合金呢？题目中有一条重要的要求是「所有合金都需要由同一台机器制造」，因此我们可以枚举使用哪一台机器。对于第 $i$ 台机器以及第 $j$ 种金属，它需要的数量为 $\textit{composition}[i][j] \times x$，当前已拥有的数量为 $\textit{stock}[j]$，因此需要：

$$\max \big\{ \textit{composition}[i][j] \times x - \textit{stock}[j], 0 \} \times \textit{cost}[j]$$

的价格补齐缺少的部分。我们将所有的金属需要的价格相加，如果不超过给定的 $\textit{budget}$，那么可以制造 $x$ 块合金，并修改二分查找的左边界。如果所有的机器都需要超过 $\textit{budget}$ 的价格，那么无法制造 $x$ 块合金，并修改二分查找的右边界。

二分查找的下界可以设置为 $0$ 或 $1$，取决于实现的方式。二分查找的上界可以设置为 $2 \times 10^8$，这是因为 $\textit{budget}$ 和每一个 $\textit{stock}[j]$ 都不超过 $10^8$ ，因此最多每一种金属最多只能补到 $2 \times 10^8$ 个。

代码

```c++
class Solution {
public:
    int maxNumberOfAlloys(int n, int k, int budget, vector<vector<int>>& composition, vector<int>& stock, vector<int>& cost) {
        int left = 1, right = 2e8, ans = 0;
        while (left <= right) {
            int mid = (left + right) / 2;
            bool valid = false;
            for (int i = 0; i < k; ++i) {
                long long spend = 0;
                for (int j = 0; j < n; ++j) {
                    spend += max(static_cast<long long>(composition[i][j]) * mid - stock[j], 0LL) * cost[j];
                }
                if (spend <= budget) {
                    valid = true;
                    break;
                }
            }
            if (valid) {
                ans = mid;
                left = mid + 1;
            }
            else {
                right = mid - 1;
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int maxNumberOfAlloys(int n, int k, int budget, List<List<Integer>> composition, List<Integer> stock, List<Integer> cost) {
        int left = 1, right = 200000000, ans = 0;
        while (left <= right) {
            int mid = (left + right) / 2;
            boolean valid = false;
            for (int i = 0; i < k; ++i) {
                long spend = 0;
                for (int j = 0; j < n; ++j) {
                    spend += Math.max((long) composition.get(i).get(j) * mid - stock.get(j), 0) * cost.get(j);
                }
                if (spend <= budget) {
                    valid = true;
                    break;
                }
            }
            if (valid) {
                ans = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int MaxNumberOfAlloys(int n, int k, int budget, IList<IList<int>> composition, IList<int> stock, IList<int> cost) {
        int left = 1, right = 200000000, ans = 0;
        while (left <= right) {
            int mid = (left + right) / 2;
            bool valid = false;
            for (int i = 0; i < k; ++i) {
                long spend = 0;
                for (int j = 0; j < n; ++j) {
                    spend += Math.Max((long) composition[i][j] * mid - stock[j], 0) * cost[j];
                }
                if (spend <= budget) {
                    valid = true;
                    break;
                }
            }
            if (valid) {
                ans = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return ans;
    }
}
```

```python
class Solution:
    def maxNumberOfAlloys(self, n: int, k: int, budget: int, composition: List[List[int]], stock: List[int], cost: List[int]) -> int:
        left, right, ans = 1, 2 * 10**8, 0
        while left <= right:
            mid = (left + right) // 2
            valid = False
            for i in range(k):
                spend = 0
                for j, (composition_j, stock_j, cost_j) in enumerate(zip(composition[i], stock, cost)):
                    spend += max(composition_j * mid - stock_j, 0) * cost_j
                if spend <= budget:
                    valid = True
                    break
            if valid:
                ans = mid
                left = mid + 1
            else:
                right = mid - 1
        return ans
```

```go
func maxNumberOfAlloys(n int, k int, budget int, composition [][]int, stock []int, cost []int) int {
    left, right, ans := 1, int(2e8), 0
    for left <= right {
        mid := (left + right) / 2
        var valid bool
        for i := 0; i < k; i++ {
            var spend int64
            for j := 0; j < n; j++ {
                spend += max(int64(composition[i][j]) * int64(mid) - int64(stock[j]), int64(0)) * int64(cost[j])
            }
            if spend <= int64(budget) {
                valid = true
                break
            }
        }
        if valid {
            ans, left = mid, mid + 1
        } else {
            right = mid - 1
        }
    }
    return ans
}
```

```c
int maxNumberOfAlloys(int n, int k, int budget, int** composition, int compositionSize, int* compositionColSize, int* stock, int stockSize, int* cost, int costSize){
    int left = 1, right = 2e8, ans = 0;
    while (left <= right) {
        int mid = (left + right) / 2;
        bool valid = false;
        for (int i = 0; i < k; ++i) {
            long long spend = 0;
            for (int j = 0; j < n; ++j) {
                long long t = (long long)composition[i][j] * mid - stock[j];
                if (t > 0) {
                    spend += t * cost[j];
                }
            }
            if (spend <= budget) {
                valid = true;
                break;
            }
        }
        if (valid) {
            ans = mid;
            left = mid + 1;
        }
        else {
            right = mid - 1;
        }
    }
    return ans;
}
```

```javascript
var maxNumberOfAlloys = function(n, k, budget, composition, stock, cost) {
    let left = 1, right = 2e8, ans = 0;
    while (left <= right) {
        let mid = (left + right) >> 1;
        let valid = false;
        for (let i = 0; i < k; ++i) {
            let spend = 0;
            for (let j = 0; j < n; ++j) {
                spend += Math.max(composition[i][j] * mid - stock[j], 0) * cost[j];
            }
            if (spend <= budget) {
                valid = true;
                break;
            }
        }
        if (valid) {
            ans = mid;
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    return ans;
};
```

```typescript
function maxNumberOfAlloys(n: number, k: number, budget: number, composition: number[][], stock: number[], cost: number[]): number {
    let left: number = 1, right: number = 2e8, ans: number = 0;

    while (left <= right) {
        let mid: number = (left + right) >> 1;
        let valid: boolean = false;
        for (let i: number = 0; i < k; ++i) {
            let spend: number = 0;
            for (let j: number = 0; j < n; ++j) {
                spend += Math.max(composition[i][j] * mid - stock[j], 0) * cost[j];
            }
            if (spend <= budget) {
                valid = true;
                break;
            }
        }

        if (valid) {
            ans = mid;
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    return ans;
};
```

#### 复杂度分析

- 时间复杂度：$O(nk\log C)$，其中 $C$ 是答案的范围。二分查找需要的次数为 $O(\log C)$，每一次需要 $O(nk)$ 的时间进行判断。
- 空间复杂度：$O(1)$。
