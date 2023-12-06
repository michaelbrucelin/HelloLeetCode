### [最小化旅行的价格总和](https://leetcode.cn/problems/minimize-the-total-price-of-the-trips/solutions/2553222/zui-xiao-hua-lu-xing-de-jie-ge-zong-he-b-6al2/)

#### 方法一：深度优先搜索 + 动态规划

为了使旅行的价格总和最小，那么每次旅行的路径必定是最短路径。根据题意，每次旅行 $trips[i]$ 都是独立的，因此我们可以依次开始旅行 $trips[i]$，并且用数组 $count$ 记录节点在旅行中被经过的次数。记旅行 $trips[i]$ 的起点和终点分别为 $start_i$ 和 $end_i$，那么我们以 $start_i$ 为树的根节点，对树进行深度优先搜索，对于如果节点 $node$ 的子树（包含它本身）包含节点 $end_i$，那么我们将 $count[node]$ 加一。

获取节点在所有旅行中被经过的次数 $count$ 后，执行所有旅行的价格总和的计算为：

$$priceTotal = \sum price[node] \times count[node]$$

以节点 $0$ 为树的根节点，令 $dp[node][0]$ 和 $dp[node][1]$ 为以 $node$ 为根节点的子树，分别对 $node$ 的价格保持和减半时的最小价格总和，那么转移方程为：

$$\begin{align} dp[node][0] &= \sum_{child \in T(node)} \min(dp[child][0], dp[child][1]) \\ dp[node][1] &= \sum_{child \in T(node)} dp[child][0] \end{align}$$

其中 $T(node)$ 表示节点 $node$ 的子节点集合，根据转移方程对树进行深度优先搜索，$\min(dp[node][0], dp[node][1])$ 即为所求。

```c++
class Solution {
public:
    int minimumTotalPrice(int n, vector<vector<int>> &edges, vector<int> &price, vector<vector<int>> &trips) {
        vector<vector<int>> next(n);
        for (auto &edge : edges) {
            next[edge[0]].push_back(edge[1]);
            next[edge[1]].push_back(edge[0]);
        }

        vector<int> count(n);
        function<bool(int, int, int)> dfs = [&](int node, int parent, int end) -> bool {
            if (node == end) {
                count[node]++;
                return true;
            }
            for (int child : next[node]) {
                if (child == parent) {
                    continue;
                }
                if (dfs(child, node, end)) {
                    count[node]++;
                    return true;
                }
            }
            return false;
        };
        for (auto &trip: trips) {
            dfs(trip[0], -1, trip[1]);
        }

        function<pair<int, int>(int, int)> dp = [&](int node, int parent) -> pair<int, int> {
            pair<int, int> res = {
                price[node] * count[node], price[node] * count[node] / 2
            };
            for (int child : next[node]) {
                if (child == parent) {
                    continue;
                }
                auto [x, y] = dp(child, node);
                res.first += min(x, y); // node 没有减半，因此可以取子树的两种情况的最小值
                res.second += x; // node 减半，只能取子树没有减半的情况
            }
            return res;
        };
        auto [x, y] = dp(0, -1);
        return min(x, y);
    }
};
```

```java
class Solution {
    public int minimumTotalPrice(int n, int[][] edges, int[] price, int[][] trips) {
        List<Integer>[] next = new List[n];
        for (int i = 0; i < n; i++) {
            next[i] = new ArrayList<Integer>();
        }
        for (int[] edge : edges) {
            next[edge[0]].add(edge[1]);
            next[edge[1]].add(edge[0]);
        }

        int[] count = new int[n];
        for (int[] trip : trips) {
            dfs(trip[0], -1, trip[1], next, count);
        }

        int[] pair = dp(0, -1, price, next, count);
        return Math.min(pair[0], pair[1]);
    }

    public boolean dfs(int node, int parent, int end, List<Integer>[] next, int[] count) {
        if (node == end) {
            count[node]++;
            return true;
        }
        for (int child : next[node]) {
            if (child == parent) {
                continue;
            }
            if (dfs(child, node, end, next, count)) {
                count[node]++;
                return true;
            }
        }
        return false;
    }

    public int[] dp(int node, int parent, int[] price, List<Integer>[] next, int[] count) {
        int[] res = {price[node] * count[node], price[node] * count[node] / 2};
        for (int child : next[node]) {
            if (child == parent) {
                continue;
            }
            int[] pair = dp(child, node, price, next, count);
            res[0] += Math.min(pair[0], pair[1]); // node 没有减半，因此可以取子树的两种情况的最小值
            res[1] += pair[0]; // node 减半，只能取子树没有减半的情况
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int MinimumTotalPrice(int n, int[][] edges, int[] price, int[][] trips) {
        IList<int>[] next = new IList<int>[n];
        for (int i = 0; i < n; i++) {
            next[i] = new List<int>();
        }
        foreach (int[] edge in edges) {
            next[edge[0]].Add(edge[1]);
            next[edge[1]].Add(edge[0]);
        }

        int[] count = new int[n];
        foreach (int[] trip in trips) {
            DFS(trip[0], -1, trip[1], next, count);
        }

        int[] pair = DP(0, -1, price, next, count);
        return Math.Min(pair[0], pair[1]);
    }

    public bool DFS(int node, int parent, int end, IList<int>[] next, int[] count) {
        if (node == end) {
            count[node]++;
            return true;
        }
        foreach (int child in next[node]) {
            if (child == parent) {
                continue;
            }
            if (DFS(child, node, end, next, count)) {
                count[node]++;
                return true;
            }
        }
        return false;
    }

    public int[] DP(int node, int parent, int[] price, IList<int>[] next, int[] count) {
        int[] res = {price[node] * count[node], price[node] * count[node] / 2};
        foreach (int child in next[node]) {
            if (child == parent) {
                continue;
            }
            int[] pair = DP(child, node, price, next, count);
            res[0] += Math.Min(pair[0], pair[1]); // node 没有减半，因此可以取子树的两种情况的最小值
            res[1] += pair[0]; // node 减半，只能取子树没有减半的情况
        }
        return res;
    }
}
```

```go
func minimumTotalPrice(n int, edges [][]int, price []int, trips [][]int) int {
    next := make([][]int, n)
    for _, edge := range edges {
        next[edge[0]] = append(next[edge[0]], edge[1])
        next[edge[1]] = append(next[edge[1]], edge[0])
    }

    count := make([]int, n)
    var dfs func(int, int, int) bool
    dfs = func(node, parent, end int) bool {
        if node == end {
            count[node]++
            return true
        }
        for _, child := range next[node] {
            if child == parent {
                continue
            }
            if dfs(child, node, end) {
                count[node]++
                return true
            }
        }
        return false
    }
    for _, trip := range trips {
        dfs(trip[0], -1, trip[1])
    }

    var dp func(int, int) []int
    dp = func(node, parent int) []int {
        res := []int{
            price[node] * count[node], price[node] * count[node] / 2,
        }
        for _, child := range next[node] {
            if child == parent {
                continue
            }
            v := dp(child, node)
            // node 没有减半，因此可以取子树的两种情况的最小值
            // node 减半，只能取子树没有减半的情况
            res[0], res[1] = res[0] + min(v[0], v[1]), res[1] + v[0] 
        }
        return res
    }
    res := dp(0, -1)
    return min(res[0], res[1])
}
```

```python
class Solution:
    def minimumTotalPrice(self, n: int, edges: List[List[int]], price: List[int], trips: List[List[int]]) -> int:
        children = [[] for _ in range(n)]
        for edge in edges:
            children[edge[0]].append(edge[1])
            children[edge[1]].append(edge[0])
        
        count = [0] * n
        def dfs(node: int, parent: int, end: int) -> bool:
            if node == end:
                count[node] += 1
                return True
            for child in children[node]:
                if child == parent:
                    continue
                if dfs(child, node, end):
                    count[node] += 1
                    return True
            return False
        
        for [x, y] in trips:
            dfs(x, -1, y)
        
        def dp(node: int, parent: int) -> List[int]:
            res = [
                price[node] * count[node], price[node] * count[node] // 2
            ]
            for child in children[node]:
                if child == parent:
                    continue
                [x, y] = dp(child, node)
                # node 没有减半，因此可以取子树的两种情况的最小值
                # node 减半，只能取子树没有减半的情况
                res[0], res[1] = res[0] + min(x, y), res[1] + x
            return res

        return min(dp(0, -1))
```

```javascript
var minimumTotalPrice = function(n, edges, price, trips) {
    const next = new Array(n).fill(0).map(() => new Array());
    for (const edge of edges) {
        next[edge[0]].push(edge[1]);
        next[edge[1]].push(edge[0]);
    }

    const count = new Array(n).fill(0);
    const dfs = function(node, parent, end) {
        if (node == end) {
            count[node]++;
            return true;
        }
        for (const child of next[node]) {
            if (child == parent) {
                continue;
            }
            if (dfs(child, node, end)) {
                count[node]++;
                return true;
            }
        }
        return false;
    };

    const dp = function(node, parent) {
            let res = [price[node] * count[node], Math.floor(price[node] * count[node] / 2)];
            for (const child of next[node]) {
                if (child == parent) {
                    continue;
                }
                const [x, y] = dp(child, node);
                res[0] += Math.min(x, y); // node 没有减半，因此可以取子树的两种情况的最小值
                res[1] += x; // node 减半，只能取子树没有减半的情况
            }
            return res;
        };

        for (const trip of trips) {
            dfs(trip[0], -1, trip[1]);
        }
        return Math.min(...dp(0, -1));
};
```

```c
typedef struct ListNode ListNode;

ListNode *createListNode(int val) {
    ListNode *obj = (ListNode *)malloc(sizeof(ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

bool freeList(ListNode *list) {
    while (list) {
        ListNode *cur = list;
        list = list->next;
        free(cur);
    }
    return true;
}

bool dfs(int node, int parent, int end, ListNode **next, int *count) {
    if (node == end) {
        count[node]++;
        return true;
    }
    for (ListNode *cur = next[node]; cur; cur = cur->next) {
        int child = cur->val;
        if (child == parent) {
            continue;
        }
        if (dfs(child, node, end, next, count)) {
            count[node]++;
            return true;
        }
    }
    return false;
};

long long dp(int node, int parent, int *count, int *price, ListNode **next) {
    int first = price[node] * count[node];
    int second = price[node] * count[node] / 2;
    for (ListNode *cur = next[node]; cur; cur = cur->next) {
        int child = cur->val;
        if (child == parent) {
            continue;
        }
        long long ret = dp(child, node, count, price, next);
        int x = ret >> 32;
        int y = ret & 0xFFFFFFFF;
        first += fmin(x, y); // node 没有减半，因此可以取子树的两种情况的最小值
        second += x; // node 减半，只能取子树没有减半的情况
    }
    return ((long long)first << 32) + second;
};

int minimumTotalPrice(int n, int** edges, int edgesSize, int* edgesColSize, int* price, int priceSize, int** trips, int tripsSize, int* tripsColSize) {
    ListNode *next[n];
    memset(next, 0, sizeof(next));
    for (int i = 0; i < edgesSize; i++) {
        int x = edges[i][0];
        int y = edges[i][1];
        ListNode *nodex = createListNode(x);
        ListNode *nodey = createListNode(y);
        nodex->next = next[y];
        next[y] = nodex;
        nodey->next = next[x];
        next[x] = nodey;
    }

    int count[n];
    memset(count, 0, sizeof(count));
    for (int i = 0; i < tripsSize; i++) {
        int *trip = trips[i];
        dfs(trip[0], -1, trip[1], next, count);
    }
    long long ret = dp(0, -1, count, price, next);
    for (int i = 0; i < n; i++) {
        freeList(next[i]);
    }
    return fmin(ret >> 32, ret & 0xFFFFFFFF);
}
```

**复杂度分析**

-   时间复杂度：$O(mn)$，其中 $n$ 是节点数目，$m$ 是数组 $trips$ 的长度。计算 $count$ 需要 $O(mn)$。
-   空间复杂度：$O(n)$。

#### 方法二：Tarjan + DP

以节点 $0$ 为树的根节点，考虑节点 $start_i$ 到节点 $end_i$ 的最短路径，假设 $lca_i$ 为节点 $start_i$ 和节点 $end_i$ 的最近公共祖先节点，$lca_i'$ 为靠近 $start_i$ 一侧的节点，且路径 $start_i \to end_i$ 可以拆分为路径 $start_i \to lca_i'$ 和路径 $lca_i \to end_i$（对于 $lca_i = start_i$ 的情况在后面进行讨论）。显然这两个路径的起点和终点是祖先关系，我们可以利用树上差分来快速计算方法一中的 $count$ 数组，令差分数组为 $diff$，那么：

1.  对于路径 $start_i \to lca_i'$，将 $diff[start_i]$ 加一，$diff[lca_i]$ 减一。
2.  对于路径 $lca_i \to end_i$，将 $diff[end_i]$ 加一，如果 $lca_i$ 不是根结点，将 $diff[parent_{lca_i}]$ 减一（其中 $parent_{lca_i}$ 表示 $lca_i$ 的父节点。

当 $lca_i = start_i$ 时，实际上只有一条路径，即 $lca_i \to end_i$，此时步骤 $1$ 会将 $diff[start_i]$ 加一，$diff[lca_i]$ 减一，对结果不影响，因此为了程序简洁性，我们在代码中不作额外处理。

对根节点 $0$ 执行深度优先搜索，那么节点 $node$ 的 $count[node]$ 为以 $node$ 为根节点的子树（包含 $node$ 节点）的 $diff$ 值之和。计算 $count$ 值后，同方法一的求解。

> 最近公共祖先节点的求解可以采用 $Tarjan$ 算法，不在面试考察范围，感兴趣的读者可以参考 [OIWiki. 最近公共祖先](https://leetcode.cn/link/?target=https%3A%2F%2Foi.wiki%2Fgraph%2Flca%2F)。

```c++
class Solution {
public:
    int find(vector<int> &uf, int i) {
        if (uf[i] == i) {
            return i;
        }
        uf[i] = find(uf, uf[i]);
        return uf[i];
    }

    int minimumTotalPrice(int n, vector<vector<int>> &edges, vector<int> &price, vector<vector<int>> &trips) {
        vector<vector<int>> next(n);
        for (auto &edge : edges) {
            next[edge[0]].push_back(edge[1]);
            next[edge[1]].push_back(edge[0]);
        }

        vector<vector<int>> query(n);
        for (auto &trip : trips) {
            query[trip[0]].push_back(trip[1]);
            if (trip[0] != trip[1]) {
                query[trip[1]].push_back(trip[0]);
            }
        }

        vector<int> uf(n), visited(n), diff(n), parent(n);
        function<void(int, int)> tarjan = [&](int node, int p) {
            parent[node] = p;
            uf[node] = node;
            for (int child : next[node]) {
                if (child == p) {
                    continue;
                }
                tarjan(child, node);
                uf[child] = node;
            }
            for (int node1 : query[node]) {
                if (node != node1 && !visited[node1]) {
                    continue;
                }
                int lca = find(uf, node1);
                diff[node]++;
                diff[node1]++;
                diff[lca]--;
                if (parent[lca] >= 0) {
                    diff[parent[lca]]--;
                }
            }
            visited[node] = 1;
        };
        tarjan(0, -1);

        vector<int> count(n);
        function<int(int, int)> dfs = [&](int node, int p) -> int {
            count[node] = diff[node];
            for (int child : next[node]) {
                if (child == p) {
                    continue;
                }
                count[node] += dfs(child, node);
            }
            return count[node];
        };
        dfs(0, -1);

        function<pair<int, int>(int, int)> dp = [&](int node, int p) -> pair<int, int> {
            pair<int, int> res = {
                price[node] * count[node], price[node] * count[node] / 2
            };
            for (int child : next[node]) {
                if (child == p) {
                    continue;
                }
                auto [x, y] = dp(child, node);
                res.first += min(x, y); // node 没有减半，因此可以取子树的两种情况的最小值
                res.second += x; // node 减半，只能取子树没有减半的情况
            }
            return res;
        };
        auto [x, y] = dp(0, -1);
        return min(x, y);
    }
};
```

```go
func find(uf []int, i int) int {
    if uf[i] == i {
        return i
    }
    uf[i] = find(uf, uf[i])
    return uf[i]
}

func minimumTotalPrice(n int, edges [][]int, price []int, trips [][]int) int {
    next := make([][]int, n)
    for _, edge := range edges {
        next[edge[0]] = append(next[edge[0]], edge[1])
        next[edge[1]] = append(next[edge[1]], edge[0])
    }

    query := make([][]int, n)
    for _, trip := range trips {
        query[trip[0]] = append(query[trip[0]], trip[1]);
        if trip[0] != trip[1] {
            query[trip[1]] = append(query[trip[1]], trip[0]);
        }
    }

    uf, visited, diff, parent := make([]int, n), make([]bool, n), make([]int, n), make([]int, n)
    var tarjan func(int, int)
    tarjan = func(node, p int) {
        parent[node], uf[node] = p, node
        for _, child := range next[node] {
            if child == p {
                continue
            }
            tarjan(child, node)
            uf[child] = node
        }
        for _, node1 := range query[node] {
            if node != node1 && !visited[node1] {
                continue
            }
            lca := find(uf, node1)
            diff[node]++
            diff[node1]++
            diff[lca]--
            if parent[lca] >= 0 {
                diff[parent[lca]]--
            }
        }
        visited[node] = true
    }
    tarjan(0, -1)

    count := make([]int, n)
    var dfs func(int, int) int
    dfs = func(node, p int) int {
        count[node] = diff[node]
        for _, child := range next[node] {
            if child == p {
                continue
            }
            count[node] += dfs(child, node)
        }
        return count[node]
    }
    dfs(0, -1)

    var dp func(int, int) []int
    dp = func(node, p int) []int {
        res := []int{
            price[node] * count[node], price[node] * count[node] / 2,
        }
        for _, child := range next[node] {
            if child == p {
                continue
            }
            v := dp(child, node)
            // node 没有减半，因此可以取子树的两种情况的最小值
            // node 减半，只能取子树没有减半的情况
            res[0], res[1] = res[0] + min(v[0], v[1]), res[1] + v[0] 
        }
        return res
    }
    res := dp(0, -1)
    return min(res[0], res[1])
}
```

```python
class Solution:
    def find(self, uf: List[int], i: int) -> int:
        if uf[i] == i:
            return i
        uf[i] = self.find(uf, uf[i])
        return uf[i]

    def minimumTotalPrice(self, n: int, edges: List[List[int]], price: List[int], trips: List[List[int]]) -> int:
        children = [[] for _ in range(n)]
        for edge in edges:
            children[edge[0]].append(edge[1])
            children[edge[1]].append(edge[0])
        
        query = [[] for _ in range(n)]
        for trip in trips:
            query[trip[0]].append(trip[1])
            if trip[0] != trip[1]:
                query[trip[1]].append(trip[0])
        
        uf, visited, diff, parent = [0 for _ in range(n)], [False for _ in range(n)], [0 for _ in range(n)], [0 for _ in range(n)]
        def tarjan(node: int, p: int):
            parent[node], uf[node] = p, node
            for child in children[node]:
                if child == p:
                    continue
                tarjan(child, node)
                uf[child] = node
            for node1 in query[node]:
                if node != node1 and not visited[node1]:
                    continue
                lca = self.find(uf, node1)
                diff[node] += 1
                diff[node1] += 1
                diff[lca] -= 1
                if parent[lca] >= 0:
                    diff[parent[lca]] -= 1
            visited[node] = True
        tarjan(0, -1)

        count = [0] * n
        def dfs(node: int, p: int) -> int:
            count[node] = diff[node]
            for child in children[node]:
                if child == p:
                    continue
                count[node] += dfs(child, node)
            return count[node]
        dfs(0, -1)

        def dp(node: int, p: int) -> List[int]:
            res = [
                price[node] * count[node], price[node] * count[node] // 2
            ]
            for child in children[node]:
                if child == p:
                    continue
                [x, y] = dp(child, node)
                # node 没有减半，因此可以取子树的两种情况的最小值
                # node 减半，只能取子树没有减半的情况
                res[0], res[1] = res[0] + min(x, y), res[1] + x
            return res

        return min(dp(0, -1))
```

```javascript
var find = function(uf, i) {
    if (uf[i] == i) {
        return i;
    }
    uf[i] = find(uf, uf[i]);
    return uf[i];
}

var minimumTotalPrice = function(n, edges, price, trips) {
    const next = new Array(n).fill(0).map(() => new Array());
    for (const edge of edges) {
        next[edge[0]].push(edge[1]);
        next[edge[1]].push(edge[0]);
    }

    const query = new Array(n).fill(0).map(() => new Array());
    for (const trip of trips) {
        query[trip[0]].push(trip[1]);
        if (trip[0] != trip[1]) {
            query[trip[1]].push(trip[0]);
        }
    }

    const uf = new Array(n).fill(0);
    const visited = new Array(n).fill(0);
    const diff = new Array(n).fill(0);
    const parent = new Array(n).fill(0);
    const tarjan = function(node, p) {
        parent[node] = p;
        uf[node] = node;
        for (const child of next[node]) {
            if (child == p) {
                continue;
            }
            tarjan(child, node);
            uf[child] = node;
        }
        for (const node1 of query[node]) {
            if (node != node1 && !visited[node1]) {
                continue;
            }
            const lca = find(uf, node1);
            diff[node]++;
            diff[node1]++;
            diff[lca]--;
            if (parent[lca] >= 0) {
                diff[parent[lca]]--;
            }
        }
        visited[node] = 1;
    };
    tarjan(0, -1);

    const count = new Array(n).fill(0);
    const dfs = function(node, p) {
        count[node] = diff[node];
        for (const child of next[node]) {
            if (child == p) {
                continue;
            }
            count[node] += dfs(child, node);
        }
        return count[node];
    };
    dfs(0, -1);

    const dp = function(node, p) {
        let res = [price[node] * count[node], Math.floor(price[node] * count[node] / 2)];
        for (const child of next[node]) {
            if (child == p) {
                continue;
            }
            const [x, y] = dp(child, node);
            res[0] += Math.min(x, y); // node 没有减半，因此可以取子树的两种情况的最小值
            res[1] += x; // node 减半，只能取子树没有减半的情况
        }
        return res;
    };
    return Math.min(...dp(0, -1));
};
```

```c
typedef struct ListNode ListNode;

ListNode *createListNode(int val) {
    ListNode *obj = (ListNode *)malloc(sizeof(ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

bool freeList(ListNode *list) {
    while (list) {
        ListNode *cur = list;
        list = list->next;
        free(cur);
    }
    return true;
}

int find(int *uf, int i) {
    if (uf[i] == i) {
        return i;
    }
    uf[i] = find(uf, uf[i]);
    return uf[i];
}

int dfs(int node, int p, int *count, int *diff, ListNode **next) {
    count[node] = diff[node];
    for (ListNode *cur = next[node]; cur; cur = cur->next) {
        int child = cur->val;
        if (child == p) {
            continue;
        }
        count[node] += dfs(child, node, count, diff, next);
    }
    return count[node];
};

long long dp(int node, int parent, int *count, int *price, ListNode **next) {
    int first = price[node] * count[node];
    int second = price[node] * count[node] / 2;
    for (ListNode *cur = next[node]; cur; cur = cur->next) {
        int child = cur->val;
        if (child == parent) {
            continue;
        }
        long long ret = dp(child, node, count, price, next);
        int x = ret >> 32;
        int y = ret & 0xFFFFFFFF;
        first += fmin(x, y); // node 没有减半，因此可以取子树的两种情况的最小值
        second += x; // node 减半，只能取子树没有减半的情况
    }
    return ((long long)first << 32) + second;
}

void tarjan(int node, int p, int *parent, int *uf, int *diff, int *visited,ListNode **next, ListNode **query) {
    parent[node] = p;
    uf[node] = node;
    for (ListNode *cur = next[node]; cur; cur = cur->next) {
        int child = cur->val;
        if (child == p) {
            continue;
        }
        tarjan(child, node, parent, uf, diff, visited, next, query);
        uf[child] = node;
    }
    for (ListNode *cur = query[node]; cur; cur = cur->next) {
        int node1 = cur->val;
        if (node != node1 && !visited[node1]) {
            continue;
        }
        int lca = find(uf, node1);
        diff[node]++;
        diff[node1]++;
        diff[lca]--;
        if (parent[lca] >= 0) {
            diff[parent[lca]]--;
        }
    }
    visited[node] = 1;
}

int minimumTotalPrice(int n, int** edges, int edgesSize, int* edgesColSize, int* price, int priceSize, int** trips, int tripsSize, int* tripsColSize) {
    ListNode *next[n];
    ListNode *query[n];
    memset(next, 0, sizeof(next));
    memset(query, 0, sizeof(query));
    for (int i = 0; i < edgesSize; i++) {
        int x = edges[i][0];
        int y = edges[i][1];
        ListNode *nodex = createListNode(x);
        ListNode *nodey = createListNode(y);
        nodex->next = next[y];
        next[y] = nodex;
        nodey->next = next[x];
        next[x] = nodey;
    }
    for (int i = 0; i < tripsSize; i++) {
        int *trip = trips[i];
        ListNode *node = createListNode(trip[1]);
        node->next = query[trip[0]];
        query[trip[0]] = node;
        if (trip[0] != trip[1]) {
            node = createListNode(trip[0]);
            node->next = query[trip[1]];
            query[trip[1]] = node; 
        }
    }

    int uf[n], visited[n];
    int diff[n], parent[n];
    memset(uf, 0, sizeof(uf));
    memset(visited, 0, sizeof(visited));
    memset(diff, 0, sizeof(diff));
    memset(parent, 0, sizeof(parent));
    tarjan(0, -1, parent, uf, diff, visited, next, query);

    int count[n];
    memset(count, 0, sizeof(count));
    dfs(0, -1, count, diff, next);

    long long ret = dp(0, -1, count, price, next);
    for (int i = 0; i < n; i++) {
        freeList(next[i]);
        freeList(query[i]);
    }
    return fmin(ret >> 32, ret & 0xFFFFFFFF);
}
```

**复杂度分析**

-   时间复杂度：$O(n + m \log n)$，其中 $n$ 是节点数目，$m$ 是数组 $trips$ 的长度。$Tarjan$ 算法需要 $O(m \log n)$，计算 $count$ 需要 $O(n)$，树上 $DP$ 需要 $O(n)$。
-   空间复杂度：$O(m + n)$。
