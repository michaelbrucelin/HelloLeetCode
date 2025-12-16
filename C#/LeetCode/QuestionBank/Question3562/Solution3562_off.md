### [折扣价交易股票的最大利润](https://leetcode.cn/problems/maximum-profit-from-trading-stocks-with-discounts/solutions/3851959/zhe-kou-jie-jiao-yi-gu-piao-de-zui-da-li-c7l9/)

#### 方法一：树形动态规划

**思路与算法**

该方法假设读者已经掌握 「[0\-1 背包问题](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fdp%2Fknapsack%2F)」的思路和解法。

首先证明在题设条件下，输入必定为**一颗树**。

因为输入的图保证无环，且员工 $1$ 是所有员工的**直接或间接上司**，故该图不仅是**连通图**，而且一定是以员工 $1$ 为**单一起点**的（唯一入度为 $0$ 的点）**有向无环图**。

又因为该图不存在自环（$u_i\ne v_i$）和重边，且边数等于节点数减一，由树的性质易证该图就是一棵树。

观察到题设问题对于子树成立，且当前节点信息可以由子树的信息进行转移，故考虑使用树形动态规划求解。

对于当前节点 $u$，设状态 $dp(u,state,b)$：

1. $state=0$：代表折扣不可用（不购买父节点）的情况下，预算为 $b$ 时以 $u$ 为根节点的子树的最大利润。
2. $state=1$：代表折扣可用（必须购买父节点）的情况下，预算为 $b$ 时以 $u$ 为根节点的子树的最大利润。

状态转移可以使用 $0-1$ 背包问题的思路来求解，我们可以将节点 $u$ 代表的子树拆分为 $u$ 本身和它的子节点两个部分，分别求解它们对整个子树的贡献：

- 计算 $u$ 的所有子节点在预算 $b$ 下的最优利润。
- 计算节点 $u$ 自己在预算 $b$ 下对子树的贡献。

下面首先求解 $u$ 的所有子节点在预算 $b$ 下的最优利润，这里需要先计算一个辅助状态 $subProfit(state,b)$，由于我们在求解以子节点 $v$ 为根的子树的最优利润，因此这里 $state$ 的含义并不代表 $u$ 自身折扣是否可用，而是代表 **u 的购买状态对子节点 $v$ 的状态转移的影响**：

1. $state=0$：表示不购买节点 $u$ 的情况。此时所有子节点 $v$ 无法享受折扣，根据 $dp(v,0,\dots )$ 进行转移。
2. $state=1$：表示购买节点 $u$ 的情况。此时所有子节点 $v$ 可以享受折扣，根据 $dp(v,1,\dots )$ 进行转移。

将每个子节点 $v$ 所代表的子树看作一件可以放入背包的物品。具体而言，对于每一个子树节点 $v$，我们枚举子树预算 $sub$ 作为重量，$dp(v,state,sub)$ 即为子树价值，这样就能将 $v$ 看作一个物品，进行背包问题的求解。

或者也可以将每个子节点 $v$ 看作一个“组”，该组内包含了花费不同预算 $sub$ 所能获得的最大价值。我们在遍历子节点时，本质上是在做**分组背包**的状态转移：

$$subProfit(state,i)=\max\limits_{0\le sub\le i}\{subProfit(state,i-sub)+dp(v,state,sub)\}$$

合并完所有子节点的信息后，再根据节点 $u$ 自身的购买情况来计算 $dp(u,state,b)$。这里还是使用了背包问题的求解思路，将节点 $u$ 自身作为一件物品来处理，注意此时的 $state$ 代表的是 $u$ 的父节点是否必须购买，和 $subProfit$ 中的 $state$ 含义不同：

1. 决策一：不购买当前节点 $u$，此时 $u$ 的子节点都无法享受折扣，整个子树的利润为 $subProfit(0,b)$。
2. 决策二：购买当前节点 $u$：
    - 若 $state=0$，即折扣不可用，此时整个子树的利润为 $subProfit(1,b-present_u)+future_u-present_u$。
    - 若 $state=1$，即折扣可用，此时整个子树的利润为 $subProfit(1,b-\lfloor\frac{present_u}{2}\rfloor)+future_u-\lfloor\frac{present_u}{2}\rfloor$。

上述两种情况取最大值即可。

最后，根节点的 $dp(0,0,budget)$ 即为在预算范围内能获得的最大利润。其中因为根节点没有父节点，所以只能选择折扣不可用的状态。

此外，在代码实现时，还有一些可以优化时空复杂度的点：

- 由于状态数组 $dp$ 在父子节点之间转移，故可以使用类似滚动数组的方式，不再全局存储第一维节点信息，而是在递归时由子节点向父节点传递。
- 子树的预算 $sub$ 上界可能比当前总预算 $b$ 更低，此时增加子树预算并不会带来更优的结果。例如，一个简单的上界估计方法是计算子树节点的 $present$ 总和，后续遍历时取较小的上界即可。

**代码**

```C++
class Solution {
public:
    int maxProfit(int n, vector<int>& present, vector<int>& future, vector<vector<int>>& hierarchy, int budget) {
        vector<vector<int>> g(n);

        for (auto& e : hierarchy) {
            g[e[0] - 1].push_back(e[1] - 1);
        }

        auto dfs = [&](auto&& self, int u) -> tuple<vector<int>, vector<int>, int>  {
            int cost = present[u];
            int dCost = present[u] / 2; // discounted cost

            // dp[u][state][budget]
            // state = 0: 不购买父节点, state = 1: 必须购买父节点
            auto dp0 = vector(budget + 1, 0);
            auto dp1 = vector(budget + 1, 0);

            // subProfit[state][budget]
            // state = 0: 优惠不可用, state = 1: 优惠可用
            auto subProfit0 = vector(budget + 1, 0);
            auto subProfit1 = vector(budget + 1, 0);

            int uSize = cost;

            for (auto v : g[u]) {
                auto [subDp0, subDp1, vSize] = self(self, v);
                uSize += vSize;
                for (int i = budget; i >= 0; i--) {
                    for (int sub = 0; sub <= min(vSize, i); sub++) {
                        subProfit0[i] = max(subProfit0[i], subProfit0[i - sub] + subDp0[sub]);
                        subProfit1[i] = max(subProfit1[i], subProfit1[i - sub] + subDp1[sub]);
                    }
                }
            }

            for (int i = 0; i <= budget; i++) {
                dp0[i] = dp1[i] = subProfit0[i];

                if (i >= dCost) {
                    dp1[i] = max(subProfit0[i], subProfit1[i - dCost] + future[u] - dCost);
                }

                if (i >= cost) {
                    dp0[i] = max(subProfit0[i], subProfit1[i - cost] + future[u] - cost);
                }
            }

            return {dp0, dp1, uSize};
        };

        return std::get<0>(dfs(dfs, 0))[budget];
    }
};
```

```JavaScript
var maxProfit = function (n, present, future, hierarchy, budget) {
    const g = Array.from({ length: n }, () => []);

    for (const e of hierarchy) {
        g[e[0] - 1].push(e[1] - 1);
    }

    const dfs = (u) => {
        const cost = present[u];
        const dCost = Math.floor(present[u] / 2); // discounted cost

        // dp[u][state][budget]
        // state: 0 = 不购买父节点, 1 = 购买父节点
        const dp0 = new Array(budget + 1).fill(0);
        const dp1 = new Array(budget + 1).fill(0);

        // subProfit[state][budget]
        // state = 0: 优惠不可用, state = 1: 优惠可用
        const subProfit0 = Array(budget + 1).fill(0);
        const subProfit1 = Array(budget + 1).fill(0);

        let uSize = cost;

        for (const v of g[u]) {
            const [subDp0, subDp1, vSize] = dfs(v);
            uSize += vSize;

            for (let i = budget; i >= 0; i--) {
                for (let sub = 0; sub <= Math.min(vSize, i); sub++) {
                    subProfit0[i] = Math.max(subProfit0[i], subProfit0[i - sub] + subDp0[sub]);
                    subProfit1[i] = Math.max(subProfit1[i], subProfit1[i - sub] + subDp1[sub]);
                }
            }
        }

        for (let i = 0; i <= budget; i++) {
            dp0[i] = dp1[i] = subProfit0[i];

            if (i >= dCost) {
                dp1[i] = Math.max(subProfit0[i], subProfit1[i - dCost] + future[u] - dCost);
            }

            if (i >= cost) {
                dp0[i] = Math.max(subProfit0[i], subProfit1[i - cost] + future[u] - cost);
            }
        }

        return [dp0, dp1, uSize];
    };

    return dfs(0)[0][budget];
};
```

```TypeScript
function maxProfit(n: number, present: number[], future: number[], hierarchy: number[][], budget: number): number {
    const g = Array.from({ length: n }, () => [] as number[]);

    for (const e of hierarchy) {
        g[e[0] - 1].push(e[1] - 1);
    }

    const dfs = (u: number) => {
        const cost = present[u];
        const dCost = Math.floor(present[u] / 2); // discounted cost

        // dp[u][state][budget]
        // state: 0 = 不购买父节点, 1 = 购买父节点
        const dp0: number[] = new Array(budget + 1).fill(0);
        const dp1: number[] = new Array(budget + 1).fill(0);

        // subProfit[state][budget]
        // state = 0: 优惠不可用, state = 1: 优惠可用
        const subProfit0: number[] = Array(budget + 1).fill(0);
        const subProfit1: number[] = Array(budget + 1).fill(0);

        let uSize = cost;

        for (const v of g[u]) {
            const [subDp0, subDp1, vSize] = dfs(v);
            uSize += vSize;

            for (let i = budget; i >= 0; i--) {
                for (let sub = 0; sub <= Math.min(vSize, i); sub++) {
                    subProfit0[i] = Math.max(subProfit0[i], subProfit0[i - sub] + subDp0[sub]);
                    subProfit1[i] = Math.max(subProfit1[i], subProfit1[i - sub] + subDp1[sub]);
                }
            }
        }

        for (let i = 0; i <= budget; i++) {
            dp0[i] = dp1[i] = subProfit0[i];

            if (i >= dCost) {
                dp1[i] = Math.max(subProfit0[i], subProfit1[i - dCost] + future[u] - dCost);
            }

            if (i >= cost) {
                dp0[i] = Math.max(subProfit0[i], subProfit1[i - cost] + future[u] - cost);
            }
        }

        return [dp0, dp1, uSize] as const;
    };

    return dfs(0)[0][budget];
};
```

```Java
class Result {
    int[] dp0;
    int[] dp1;
    int size;
    
    Result(int[] dp0, int[] dp1, int size) {
        this.dp0 = dp0;
        this.dp1 = dp1;
        this.size = size;
    }
}

class Solution {
    public int maxProfit(int n, int[] present, int[] future, int[][] hierarchy, int budget) {
        List<Integer>[] g = new ArrayList[n];
        for (int i = 0; i < n; i++) {
            g[i] = new ArrayList<>();
        }
        for (int[] e : hierarchy) {
            g[e[0] - 1].add(e[1] - 1);
        }
        
        return dfs(0, present, future, g, budget).dp0[budget];
    }

    private Result dfs(int u, int[] present, int[] future, List<Integer>[] g, int budget) {
        int cost = present[u];
        int dCost = present[u] / 2;
        // dp[u][state][budget]
        // state = 0: 不购买父节点, state = 1: 必须购买父节点
        int[] dp0 = new int[budget + 1];
        int[] dp1 = new int[budget + 1];

        // subProfit[state][budget]
        // state = 0: 优惠不可用, state = 1: 优惠可用
        int[] subProfit0 = new int[budget + 1];
        int[] subProfit1 = new int[budget + 1];
        int uSize = cost;
        
        for (int v : g[u]) {
            Result childResult = dfs(v, present, future, g, budget);
            uSize += childResult.size;

            for (int i = budget; i >= 0; i--) {
                for (int sub = 0; sub <= Math.min(childResult.size, i); sub++) {
                    if (i - sub >= 0) {
                        subProfit0[i] = Math.max(subProfit0[i], subProfit0[i - sub] + childResult.dp0[sub]);
                        subProfit1[i] = Math.max(subProfit1[i], subProfit1[i - sub] + childResult.dp1[sub]);
                    }
                }
            }
        }
        
        for (int i = 0; i <= budget; i++) {
            dp0[i] = subProfit0[i];
            dp1[i] = subProfit0[i];
            if (i >= dCost) {
                dp1[i] = Math.max(subProfit0[i], subProfit1[i - dCost] + future[u] - dCost);
            }
            if (i >= cost) {
                dp0[i] = Math.max(subProfit0[i], subProfit1[i - cost] + future[u] - cost);
            }
        }
        
        return new Result(dp0, dp1, uSize);
    }
}
```

```CSharp
public class Solution {
    public int MaxProfit(int n, int[] present, int[] future, int[][] hierarchy, int budget) {
        List<int>[] g = new List<int>[n];
        for (int i = 0; i < n; i++) {
            g[i] = new List<int>();
        }
        foreach (var e in hierarchy) {
            g[e[0] - 1].Add(e[1] - 1);
        }
        
        (int[] dp0, int[] dp1, int size) Dfs(int u) {
            int cost = present[u];
            int dCost = present[u] / 2; // discounted cost
            
            // dp[u][state][budget]
            // state = 0: 不购买父节点, state = 1: 必须购买父节点
            int[] dp0 = new int[budget + 1];
            int[] dp1 = new int[budget + 1];
            // subProfit[state][budget]
            // state = 0: 优惠不可用, state = 1: 优惠可用
            int[] subProfit0 = new int[budget + 1];
            int[] subProfit1 = new int[budget + 1];
            int uSize = cost;
            
            foreach (int v in g[u]) {
                var (childDp0, childDp1, vSize) = Dfs(v);
                uSize += vSize;
                for (int i = budget; i >= 0; i--) {
                    for (int sub = 0; sub <= Math.Min(vSize, i); sub++) {
                        if (i - sub >= 0) {
                            subProfit0[i] = Math.Max(subProfit0[i], subProfit0[i - sub] + childDp0[sub]);
                            subProfit1[i] = Math.Max(subProfit1[i], subProfit1[i - sub] + childDp1[sub]);
                        }
                    }
                }
            }
            
            for (int i = 0; i <= budget; i++) {
                dp0[i] = subProfit0[i];
                dp1[i] = subProfit0[i];
                if (i >= dCost) {
                    dp1[i] = Math.Max(subProfit0[i], subProfit1[i - dCost] + future[u] - dCost);
                }
                if (i >= cost) {
                    dp0[i] = Math.Max(subProfit0[i], subProfit1[i - cost] + future[u] - cost);
                }
            }
            
            return (dp0, dp1, uSize);
        }
        
        return Dfs(0).dp0[budget];
    }
}
```

```Go
func maxProfit(n int, present []int, future []int, hierarchy [][]int, budget int) int {
    // 构建邻接表
    g := make([][]int, n)
    for i := range g {
        g[i] = make([]int, 0)
    }
    for _, e := range hierarchy {
        g[e[0] - 1] = append(g[e[0] - 1], e[1] - 1)
    }
    
    var dfs func(int) result
    dfs = func(u int) result {
        cost := present[u]
        dCost := present[u] / 2
        // dp[u][state][budget]
        // state = 0: 不购买父节点, state = 1: 必须购买父节点
        dp0 := make([]int, budget + 1)
        dp1 := make([]int, budget + 1)
        // subProfit[state][budget]
        // state = 0: 优惠不可用, state = 1: 优惠可用
        subProfit0 := make([]int, budget + 1)
        subProfit1 := make([]int, budget + 1)
        
        uSize := cost
        for _, v := range g[u] {
            childResult := dfs(v)
            uSize += childResult.size
            for i := budget; i >= 0; i-- {
                for sub := 0; sub <= min(childResult.size, i); sub++ {
                    if i-sub >= 0 {
                        subProfit0[i] = max(subProfit0[i], subProfit0[i-sub] + childResult.dp0[sub])
                        subProfit1[i] = max(subProfit1[i], subProfit1[i-sub] + childResult.dp1[sub])
                    }
                }
            }
        }
        
        for i := 0; i <= budget; i++ {
            dp0[i] = subProfit0[i]
            dp1[i] = subProfit0[i]
            if i >= dCost {
                dp1[i] = max(subProfit0[i], subProfit1[i-dCost] + future[u] - dCost)
            }
            if i >= cost {
                dp0[i] = max(subProfit0[i], subProfit1[i-cost] + future[u] - cost)
            }
        }
        
        return result{dp0, dp1, uSize}
    }
    
    return dfs(0).dp0[budget]
}

type result struct {
    dp0  []int
    dp1  []int
    size int
}
```

```Python
class Solution:
    def maxProfit(self, n: int, present: List[int], future: List[int], 
                 hierarchy: List[List[int]], budget: int) -> int:
        g = [[] for _ in range(n)]
        for e in hierarchy:
            g[e[0] - 1].append(e[1] - 1)
        
        def dfs(u: int):
            cost = present[u]
            dCost = present[u] // 2

            # dp[u][state][budget]
            # state = 0: 不购买父节点, state = 1: 必须购买父节点
            dp0 = [0] * (budget + 1)
            dp1 = [0] * (budget + 1)

            # subProfit[state][budget]
            # state = 0: 优惠不可用, state = 1: 优惠可用
            subProfit0 = [0] * (budget + 1)
            subProfit1 = [0] * (budget + 1)
            uSize = cost
            
            for v in g[u]:
                child_dp0, child_dp1, vSize = dfs(v)
                uSize += vSize
                for i in range(budget, -1, -1):
                    for sub in range(min(vSize, i) + 1):
                        if i - sub >= 0:
                            subProfit0[i] = max(subProfit0[i], subProfit0[i - sub] + child_dp0[sub])
                            subProfit1[i] = max(subProfit1[i], subProfit1[i - sub] + child_dp1[sub])
            
            for i in range(budget + 1):
                dp0[i] = subProfit0[i]
                dp1[i] = subProfit0[i]
                if i >= dCost:
                    dp1[i] = max(subProfit0[i], subProfit1[i - dCost] + future[u] - dCost)
                if i >= cost:
                    dp0[i] = max(subProfit0[i], subProfit1[i - cost] + future[u] - cost)
            
            return dp0, dp1, uSize
        
        return dfs(0)[0][budget]
```

```C
typedef struct {
    int* dp0;
    int* dp1;
    int size;
} Result;

struct ListNode *creatListNode(int val) {
    struct ListNode *obj = (struct ListNode*)malloc(sizeof(struct ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

void freeList(struct ListNode *list) {
    while (list) {
        struct ListNode *p = list;
        list = list->next;
        free(p);
    }
}

void dfs(int u, int n, int* present, int* future, struct ListNode ** g, int budget, Result* result, int* visited) {
    if (visited[u]) {
        return;
    }

    visited[u] = 1;
    int cost = present[u];
    int dCost = present[u] / 2;
    // dp[u][state][budget]
    // state = 0: 不购买父节点, state = 1: 必须购买父节点
    int* dp0 = (int*)calloc(budget + 1, sizeof(int));
    int* dp1 = (int*)calloc(budget + 1, sizeof(int));
    // subProfit[state][budget]
    // state = 0: 优惠不可用, state = 1: 优惠可用
    int* subProfit0 = (int*)calloc(budget + 1, sizeof(int));
    int* subProfit1 = (int*)calloc(budget + 1, sizeof(int));
    int uSize = cost;
    
    for (struct ListNode *p = g[u]; p; p = p->next) {
        int v = p->val;
        Result childResult;
        childResult.dp0 = NULL;
        childResult.dp1 = NULL;
        childResult.size = 0;
        dfs(v, n, present, future, g, budget, &childResult, visited);
        
        uSize += childResult.size;
        for (int j = budget; j >= 0; j--) {
            for (int sub = 0; sub <= fmin(childResult.size, j); sub++) {
                if (j - sub >= 0) {
                    subProfit0[j] = fmax(subProfit0[j], subProfit0[j - sub] + childResult.dp0[sub]);
                    subProfit1[j] = fmax(subProfit1[j], subProfit1[j - sub] + childResult.dp1[sub]);
                }
            }
        }
        
        free(childResult.dp0);
        free(childResult.dp1);
    }
    
    for (int i = 0; i <= budget; i++) {
        dp0[i] = subProfit0[i];
        dp1[i] = subProfit0[i];
        if (i >= dCost) {
            dp1[i] = fmax(subProfit0[i], subProfit1[i - dCost] + future[u] - dCost);
        }
        if (i >= cost) {
            dp0[i] = fmax(subProfit0[i], subProfit1[i - cost] + future[u] - cost);
        }
    }
    
    result->dp0 = dp0;
    result->dp1 = dp1;
    result->size = uSize;
    
    free(subProfit0);
    free(subProfit1);
}

int maxProfit(int n, int* present, int presentSize, int* future, int futureSize,int** hierarchy, int hierarchySize, int* hierarchyColSize, int budget) {
    
    struct ListNode **g = (struct ListNode**)malloc(n * sizeof(struct ListNode*));
    for (int i = 0; i < n; i++) {
        g[i] = NULL;
    }
    for (int i = 0; i < hierarchySize; i++) {
        int u = hierarchy[i][0] - 1;
        int v = hierarchy[i][1] - 1;
        struct ListNode *p = creatListNode(v);
        p->next = g[u];
        g[u] = p;
    }

    int* visited = (int*)calloc(n, sizeof(int));
    Result result;
    result.dp0 = NULL;
    result.dp1 = NULL;
    result.size = 0;
    dfs(0, n, present, future, g, budget, &result, visited);

    int ret = result.dp0[budget];
    free(result.dp0);
    free(result.dp1);
    free(visited);
    for (int i = 0; i < n; i++) {
        freeList(g[i]);
    }
    free(g);
    
    return ret;
}
```

```Rust
impl Solution {
    pub fn max_profit(n: i32, present: Vec<i32>, future: Vec<i32>, 
                     hierarchy: Vec<Vec<i32>>, budget: i32) -> i32 {
        let n = n as usize;
        let budget = budget as usize;
        let mut g: Vec<Vec<usize>> = vec![vec![]; n];
        for e in hierarchy {
            g[(e[0] - 1) as usize].push((e[1] - 1) as usize);
        }
        
        fn dfs(u: usize, present: &[i32], future: &[i32], g: &[Vec<usize>], budget: usize) -> (Vec<i32>, Vec<i32>, usize) {
            let cost = present[u] as usize;
            let d_cost = present[u] as usize / 2;
            
            // dp[u][state][budget]
            // state = 0: 不购买父节点, state = 1: 必须购买父节点
            let mut dp0 = vec![0; budget + 1];
            let mut dp1 = vec![0; budget + 1];
            
            // subProfit[state][budget]
            // state = 0: 优惠不可用, state = 1: 优惠可用
            let mut sub_profit0 = vec![0; budget + 1];
            let mut sub_profit1 = vec![0; budget + 1];
            let mut u_size = cost;
            
            for &v in &g[u] {
                let (child_dp0, child_dp1, v_size) = dfs(v, present, future, g, budget);
                u_size += v_size;
                
                for i in (0..=budget).rev() {
                    for sub in 0..=v_size.min(i) {
                        if i >= sub {
                            sub_profit0[i] = sub_profit0[i].max(sub_profit0[i - sub] + child_dp0[sub]);
                            sub_profit1[i] = sub_profit1[i].max(sub_profit1[i - sub] + child_dp1[sub]);
                        }
                    }
                }
            }
            
            for i in 0..=budget {
                dp0[i] = sub_profit0[i];
                dp1[i] = sub_profit0[i];
                if i >= d_cost {
                    dp1[i] = dp1[i].max(sub_profit1[i - d_cost] + future[u] - d_cost as i32);
                }
                if i >= cost {
                    dp0[i] = dp0[i].max(sub_profit1[i - cost] + future[u] - cost as i32);
                }
            }
            
            (dp0, dp1, u_size)
        }
        
        let (dp0, _, _) = dfs(0, &present, &future, &g, budget);
        dp0[budget]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\times budget^2)$。遍历节点需要 $O(n)$，每个节点的状态转移需要 $O(budget^2)$。
- 空间复杂度：$O(n\times budget)$。遍历节点需要 $O(n\times budget)$，存储状态也需要 $O(n\times budget)$。
