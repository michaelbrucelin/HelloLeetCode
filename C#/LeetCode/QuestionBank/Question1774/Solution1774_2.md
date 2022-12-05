#### [����һ������](https://leetcode.cn/problems/closest-dessert-cost/solutions/2004210/zui-jie-jin-mu-biao-jie-ge-de-tian-dian-2ck06/)

**˼·���㷨**

������Ŀ�������ȷֱ�Ϊ n �ı���ܻ������� baseCosts �ͳ���Ϊ m ���������� toppingCosts������ baseCosts[i] ��ʾ�� i �ֱ���ܻ��ϵļ۸�toppingCosts[j] ��ʾһ�ݵ� j �ֱ�������ϵļ۸��Լ�һ������ target ��ʾ������Ҫ��������Ŀ��۸�������������Ʒ��������Ҫ����������������

-   ����ѡ��**һ��**����ܻ��ϣ�
-   �������**һ�ֻ����**���ϣ�Ҳ���Բ�����κ����ϣ�
-   ÿ������**�������**��

����ϣ����������ܳɱ������ܽӽ�Ŀ��۸� target����ô�������ڰ��չ������ÿһ�ֱ���ܻ����û��ݵķ�ʽ�������������Ʒ����������Ϊÿһ�����϶����������������ڻ��ݵĹ������ܿ���ֻ��ֻ�������������ݹ����е�ǰ��������Ŀ��۸� target �󣬼�����������ֻ��ʹ������ target �Ĳ�ֵ�������������ʱ��ֵ�Ѿ����ڵ��������������ŷ����Ĳ�ֵ�����ǿ���ֹͣ����������������ʱ���ݡ�

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n \times 3^m)$������ n��m �ֱ�Ϊ���� $baseCosts$��$toppingCosts$ �ĳ��ȡ�
-   �ռ临�Ӷȣ�$O(m)$����ҪΪ���ݵݹ�Ŀռ俪����
