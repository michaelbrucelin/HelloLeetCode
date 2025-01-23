### [收集所有金币可获得的最大积分](https://leetcode.cn/problems/maximum-points-after-collecting-coins-from-all-nodes/solutions/3047557/shou-ji-suo-you-jin-bi-ke-huo-de-de-zui-d6zuo/)

#### 方法一：记忆化搜索

根据题意，如果节点 $node$ 的所有祖先节点总共做了 $f$ 次除二操作，那么节点 $node$ 的值变成 $\lfloor \dfrac{coins[node]}{2^f} \rfloor$。令 $dfs(node,f)$ 表示所有祖先节点总共做了 $f$ 次除二操作，以节点 $node$ 为根节点的子树可以获得的最大积分，$U$ 为节点 $node$ 的子节点集合：

- 当 $node$ 进行操作一时，有 $dfs(node,f)= \sum_{child \in U}dfs(child,f)+\lfloor \dfrac{coins[node]}{2^f} \rfloor-k$
- 当 $node$ 进行操作二时，有 $dfs(node,f)= \sum_{child \in U}dfs(child,f+1)+\lfloor \dfrac{coins[node]}{2^{f+1}} \rfloor$

那么 $dfs(node,f)$ 取以上两种情况的最大值。基于以上递推公式，答案可以通过深度优先搜索求解，同时为了不重复计算，使用 $memo$ 来记录求解过程的中间值。

按照以上方法，$f$ 的取值范围取决于树的高度，最坏情况下可能有 $f=n-1$。考虑到当一个子树的所有节点的金币数量都等于 $0$ 时，它可以获得的最大积分为 $0$，而当 $f \ge 14$ 时，由于题目范围的 $coins$ 小于等于 $10^4$，而 $2^{14} > 10^4$，所以此时 $coins$ 都等于 $0$。那么，在记忆化搜索过程中，当 $f+1 \ge 14$ 时，可以直接计算 $\sum_{child \in U}dfs(child,f+1)=0$，不需要再进行搜索。

```C++
class Solution {
private:
    vector<vector<int>> memo;
    vector<vector<int>> children;

public:
    int dfs(int node, int parent, int f, vector<int> &coins, int k) {
        if (memo[node][f] >= 0) {
            return memo[node][f];
        }
        int res0 = (coins[node] >> f) - k, res1 = coins[node] >> (f + 1);
        for (int child : children[node]) {
            if (child == parent) {
                continue;
            }
            res0 += dfs(child, node, f, coins, k);
            if (f + 1 < 14) {
                res1 += dfs(child, node, f + 1, coins, k);
            }
        }
        return memo[node][f] = max(res0, res1);
    }

    int maximumPoints(vector<vector<int>>& edges, vector<int>& coins, int k) {
        int n = coins.size();
        children = vector<vector<int>>(n);
        for (const auto &edge : edges) {
            children[edge[0]].push_back(edge[1]);
            children[edge[1]].push_back(edge[0]);
        }
        memo = vector<vector<int>>(n, vector<int>(14, -1));
        return dfs(0, -1, 0, coins, k);
    }
};
```

```Go
func maximumPoints(edges [][]int, coins []int, k int) int {
    n := len(coins)
    children := make([][]int, n)
    for _, edge := range edges {
        u, v := edge[0], edge[1]
        children[u] = append(children[u], v)
        children[v] = append(children[v], u)
    }

    memo := make([][]int, n)
    for i := range memo {
        memo[i] = make([]int, 14)
        for j := range memo[i] {
            memo[i][j] = -1
        }
    }

    var dfs func(node, parent, f int) int
    dfs = func(node, parent, f int) int {
        if memo[node][f] >= 0 {
            return memo[node][f]
        }
        res0, res1 := (coins[node] >> f) - k, coins[node] >> (f + 1)
        for _, child := range children[node] {
            if child == parent {
                continue
            }
            res0 += dfs(child, node, f)
            if f+1 < 14 {
                res1 += dfs(child, node, f+1)
            }
        }
        memo[node][f] = max(res0, res1)
        return memo[node][f]
    }

    return dfs(0, -1, 0)
}
```

```Python
class Solution:
    def maximumPoints(self, edges: List[List[int]], coins: List[int], k: int) -> int:
        n = len(coins)
        children = [[] for _ in range(n)]
        for u, v in edges:
            children[u].append(v)
            children[v].append(u)

        @cache
        def dfs(node, parent, f):
            res0 = (coins[node] >> f) - k
            res1 = coins[node] >> (f + 1) if f + 1 < 14 else 0
            for child in children[node]:
                if child == parent:
                    continue
                res0 += dfs(child, node, f)
                if f + 1 < 14:
                    res1 += dfs(child, node, f + 1)
            return max(res0, res1)

        return dfs(0, -1, 0)
```

```Java
class Solution {
    public int maximumPoints(int[][] edges, int[] coins, int k) {
        int n = coins.length;
        List<List<Integer>> children = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            children.add(new ArrayList<>());
        }
        for (int[] edge : edges) {
            children.get(edge[0]).add(edge[1]);
            children.get(edge[1]).add(edge[0]);
        }
        int[][] memo = new int[n][14];
        for (int i = 0; i < n; i++) {
            Arrays.fill(memo[i], -1);
        }
        return dfs(0, -1, 0, coins, k, children, memo);
    }

    private int dfs(int node, int parent, int f, int[] coins, int k, List<List<Integer>> children, int[][] memo) {
        if (memo[node][f] != -1) {
            return memo[node][f];
        }
        int res0 = (coins[node] >> f) - k;
        int res1 = coins[node] >> (f + 1);
        for (int child : children.get(node)) {
            if (child == parent) {
                continue;
            }
            res0 += dfs(child, node, f, coins, k, children, memo);
            if (f + 1 < 14) {
                res1 += dfs(child, node, f + 1, coins, k, children, memo);
            }
        }
        memo[node][f] = Math.max(res0, res1);
        return memo[node][f];
    }
}
```

```CSharp
public class Solution {
    public int MaximumPoints(int[][] edges, int[] coins, int k) {
        int n = coins.Length;
        var children = new List<List<int>>();
        for (int i = 0; i < n; i++) {
            children.Add(new List<int>());
        }
        foreach (var edge in edges) {
            children[edge[0]].Add(edge[1]);
            children[edge[1]].Add(edge[0]);
        }
        var memo = new int[n, 14];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < 14; j++) {
                memo[i, j] = -1;
            }
        }
        return Dfs(0, -1, 0, coins, k, children, memo);
    }

    private int Dfs(int node, int parent, int f, int[] coins, int k, List<List<int>> children, int[,] memo) {
        if (memo[node, f] != -1) {
            return memo[node, f];
        }
        int res0 = (coins[node] >> f) - k;
        int res1 = coins[node] >> (f + 1);
        foreach (int child in children[node]) {
            if (child == parent) {
                continue;
            }
            res0 += Dfs(child, node, f, coins, k, children, memo);
            if (f + 1 < 14) {
                res1 += Dfs(child, node, f + 1, coins, k, children, memo);
            }
        }
        memo[node, f] = Math.Max(res0, res1);
        return memo[node, f];
    }
}
```

```JavaScript
var maximumPoints = function(edges, coins, k) {
    const n = coins.length;
    const children = Array.from({ length: n }, () => []);
    for (const edge of edges) {
        children[edge[0]].push(edge[1]);
        children[edge[1]].push(edge[0]);
    }
    const memo = Array.from({ length: n }, () => Array(14).fill(-1));

    const dfs = (node, parent, f) => {
        if (memo[node][f] >= 0) {
            return memo[node][f];
        }
        let res0 = (coins[node] >> f) - k, res1 = coins[node] >> (f + 1);
        for (const child of children[node]) {
            if (child === parent) {
                continue;
            }
            res0 += dfs(child, node, f);
            if (f + 1 < 14) {
                res1 += dfs(child, node, f + 1);
            }
        }
        return memo[node][f] = Math.max(res0, res1);
    };

    return dfs(0, -1, 0);
};
```

```TypeScript
function maximumPoints(edges: number[][], coins: number[], k: number): number {
    const n = coins.length;
    const children: number[][] = Array.from({ length: n }, () => []);
    for (const edge of edges) {
        children[edge[0]].push(edge[1]);
        children[edge[1]].push(edge[0]);
    }
    const memo: number[][] = Array.from({ length: n }, () => Array(14).fill(-1));

    const dfs = (node: number, parent: number, f: number): number => {
        if (memo[node][f] >= 0) {
            return memo[node][f];
        }
        let res0 = (coins[node] >> f) - k;
        let res1 = coins[node] >> (f + 1);
        for (const child of children[node]) {
            if (child === parent) {
                continue;
            }
            res0 += dfs(child, node, f);
            if (f + 1 < 14) {
                res1 += dfs(child, node, f + 1);
            }
        }
        return memo[node][f] = Math.max(res0, res1);
    };

    return dfs(0, -1, 0);
}
```

```C
int dfs(int node, int parent, int f, int* coins, int k, int **children, int *childCount, int **memo) {
    if (memo[node][f] != -1) {
        return memo[node][f];
    }
    int res0 = (coins[node] >> f) - k;
    int res1 = coins[node] >> (f + 1);
    for (int i = 0; i < childCount[node]; ++i) {
        int child = children[node][i];
        if (child == parent) {
            continue;
        }
        res0 += dfs(child, node, f, coins, k, children, childCount, memo);
        if (f + 1 < 14) {
            res1 += dfs(child, node, f + 1, coins, k, children, childCount, memo);
        }
    }
    return memo[node][f] = fmax(res0, res1);
}

int maximumPoints(int **edges, int edgesSize, int *edgesColSize, int *coins, int coinsSize, int k) {
    int* childCount = (int*)malloc(coinsSize * sizeof(int));
    memset(childCount, 0, coinsSize * sizeof(int));
    for (int i = 0; i < edgesSize; ++i) {
        int u = edges[i][0];
        int v = edges[i][1];
        childCount[u]++;
        childCount[v]++;
    }

    int** children = (int**)malloc(coinsSize * sizeof(int*));
    for (int i = 0; i < coinsSize; ++i) {
        children[i] = (int*)malloc(childCount[i] * sizeof(int));
    }
    memset(childCount, 0, coinsSize * sizeof(int));
    for (int i = 0; i < edgesSize; ++i) {
        int u = edges[i][0];
        int v = edges[i][1];
        children[u][childCount[u]++] = v;
        children[v][childCount[v]++] = u;
    }

    int **memo = (int **)malloc(coinsSize * sizeof(int *));
    for (int i = 0; i < coinsSize; i++) {
        memo[i] = (int *)malloc(14 * sizeof(int));
        memset(memo[i], -1, 14 * sizeof(int));
    }
    int result = dfs(0, -1, 0, coins, k, children, childCount, memo);
    for (int i = 0; i < coinsSize; ++i) {
        free(children[i]);
        free(memo[i]);
    }
    free(children);
    free(memo);
    free(childCount);
    return result;
}
```

```Rust
impl Solution {
    fn dfs(node: usize, parent: Option<usize>, f: usize, coins: &Vec<i32>, k: i32, children: &Vec<Vec<usize>>, memo: &mut Vec<Vec<i32>>) -> i32 {
        if memo[node][f] >= 0 {
            return memo[node][f];
        }
        let mut res0 = (coins[node] >> f) - k;
        let mut res1 = coins[node] >> (f + 1);
        for &child in &children[node] {
            if Some(child) == parent {
                continue;
            }
            res0 += Solution::dfs(child, Some(node), f, coins, k, children, memo);
            if f + 1 < 14 {
                res1 += Solution::dfs(child, Some(node), f + 1, coins, k, children, memo);
            }
        }
        memo[node][f] = res0.max(res1);
        memo[node][f]
    }

    pub fn maximum_points(edges: Vec<Vec<i32>>, coins: Vec<i32>, k: i32) -> i32 {
        let n = coins.len();
        let mut children = vec![vec![]; n];
        for edge in edges {
            children[edge[0] as usize].push(edge[1] as usize);
            children[edge[1] as usize].push(edge[0] as usize);
        }
        let mut memo = vec![vec![-1; 14]; n];
        Solution::dfs(0, None, 0, &coins, k, &children, &mut memo)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \times C)$，其中 $n$ 是节点的数目，$C=14$ 取决于 $coins$ 的取值范围。
- 空间复杂度：$O(n \times C)$。
