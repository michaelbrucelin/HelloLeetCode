#### [前言](https://leetcode.cn/problems/modify-graph-edge-weights/solutions/2300101/xiu-gai-tu-zhong-de-bian-quan-by-leetcod-66bg/)

本题难度较大。读者需要首先掌握朴素的 [Dijkstra 算法](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgraph%2Fshortest-path%2F%23dijkstra-%E7%AE%97%E6%B3%95)，时间复杂度为 $O(n^2)$，其中 $n$ 是图中的节点数量。如果使用优先队列进行优化，时间复杂度为 $O(m \log m)$，其中 $m$ 是图中的边的数量，而本题中 $m$ 的范围可以达到 $O(n^2)$ 的级别，因此使用朴素的版本，时间复杂度更低。

下面会介绍两种方法，第一种方法只需要使用不修改的朴素 Dijkstra 算法，但时间复杂度较高。第二种方法需要在 Dijkstra 算法的基础上进行修改，且有较高的思维难度，但时间复杂度较低。

为了叙述方便，下文用 $s, t, D$ 分别表示题目中的起点 $source$，终点 $destiation$ 和目标的最短距离 $target$。

#### [方法一：二分查找 + 最短路](https://leetcode.cn/problems/modify-graph-edge-weights/solutions/2300101/xiu-gai-tu-zhong-de-bian-quan-by-leetcod-66bg/)

**提示 $1$**

给定任意一个图，如果节点 $s$ 到 $t$ 的最短路长度为 $d_{\min}(s, t)$，那么如果我们给图中的任意一条边的长度增加 $1$，那么新的最短路长度要么仍然为 $d_{\min}(s, t)$，要么为 $d_{\min}(s, t) + 1$。

**提示 $1$ 证明**

如果**所有**的 $s-t$ 最短路都经过了修改的边，那么最短路的长度会增加 $1$。否则，存在一条 $s-t$ 最短路没有任何改动，最短路的长度不变。

**思路与算法**

根据题目的描述，我们可以得到下面的结论：

-   当所有可以修改的边的长度为 $1$ 时，$s-t$ 最短路的长度达到最小值；
-   当所有可以修改的边的长度为 $2 \times 10^9$ 时，$s-t$ 的最短路长度达到最大值。

然而，把一条边的长度定为 $D$ 以上的值是没有意义的，因为：

-   如果我们希望这条边出现在最短路中，那么它的长度一定不可能大于 $D$；
-   如果我们不希望这条边出现在最短路中，那么将它的值定为 $D$，加上任意一条路径上的边，就会得到大于 $D$ 的路径长度，这样就是合理的。

因此，每一条可以修改的边的长度范围为 $[1, D]$。此时，我们就可以构造出下面 $k \times (D-1) + 1$ 种不同的边权情况，其中 kkk 是可以修改的边的数量：

-   $[1, 1, 1, \cdots, 1]$
-   $[2, 1, 1, \cdots, 1]$
-   $[3, 1, 1, \cdots, 1]$
-   $\cdots$
-   $[D, 1, 1, \cdots, 1]$
-   $[D, 2, 1, \cdots, 1]$
-   $[D, 3, 1, \cdots, 1]$
-   $\cdots$
-   $[D, D, D, \cdots, D]$

即每次将第一条可以修改的并且长度没有到达 $D$ 的边的长度增加 $1$。根据提示 $1$，相邻两种边权情况对应的最短路长度要么相同，要么增加 $1$。因此：

> 这 $k \times (D-1) + 1$ 种不同的边权情况，包含了最短路长度的最小值到最大值之间的**所有**可能的最短路值，并且上面构造的边权情况的序列，其最短路的长度是满足**单调性**的。

这样一来，我们就可以设计出如下的算法：

-   我们对边权情况为 $[1, 1, 1, \cdots, 1]$ 计算一次最短路。如果最短路的长度大于 $D$，那么无解；
-   我们对边权情况为 $[D, D, D, \cdots, D]$ 计算一次最短路。如果最短路的长度小于 $D$，那么无解；
-   此时，**答案一定存在**。我们可以在 $k \times (D-1) + 1$ 种不同的边权情况中进行二分查找。

**代码**

```cpp
class Solution {
public:
    vector<vector<int>> modifiedGraphEdges(int n, vector<vector<int>>& edges, int source, int destination, int target) {
        int k = 0;
        for (const auto& e: edges) {
            if (e[2] == -1) {
                ++k;
            }
        }

        if (dijkstra(source, destination, construct(n, edges, 0, target)) > target) {
            return {};
        }
        if (dijkstra(source, destination, construct(n, edges, static_cast<long long>(k) * (target - 1), target)) < target) {
            return {};
        }

        long long left = 0, right = static_cast<long long>(k) * (target - 1), ans = 0;
        while (left <= right) {
            long long mid = (left + right) / 2;
            if (dijkstra(source, destination, construct(n, edges, mid, target)) >= target) {
                ans = mid;
                right = mid - 1;
            }
            else {
                left = mid + 1;
            }
        }

        for (auto& e: edges) {
            if (e[2] == -1) {
                if (ans >= target - 1) {
                    e[2] = target;
                    ans -= (target - 1);
                }
                else {
                    e[2] = 1 + ans;
                    ans = 0;
                }
            }
        }

        return edges;
    }

    long long dijkstra(int source, int destination, const vector<vector<int>>& adj_matrix) {
        // 朴素的 dijkstra 算法
        // adj_matrix 是一个邻接矩阵
        int n = adj_matrix.size();
        vector<long long> dist(n, INT_MAX / 2);
        vector<int> used(n);
        dist[source] = 0;

        for (int round = 0; round < n - 1; ++round) {
            int u = -1;
            for (int i = 0; i < n; ++i) {
                if (!used[i] && (u == -1 || dist[i] < dist[u])) {
                    u = i;
                }
            }
            used[u] = true;
            for (int v = 0; v < n; ++v) {
                if (!used[v] && adj_matrix[u][v] != -1) {
                    dist[v] = min(dist[v], dist[u] + adj_matrix[u][v]);
                }
            }
        }

        return dist[destination];
    }

    vector<vector<int>> construct(int n, const vector<vector<int>>& edges, long long idx, int target) {
        // 需要构造出第 idx 种不同的边权情况，返回一个邻接矩阵
        vector<vector<int>> adj_matrix(n, vector<int>(n, -1));
        for (const auto& e: edges) {
            int u = e[0], v = e[1], w = e[2];
            if (w != -1) {
                adj_matrix[u][v] = adj_matrix[v][u] = w;
            }
            else {
                if (idx >= target - 1) {
                    adj_matrix[u][v] = adj_matrix[v][u] = target;
                    idx -= (target - 1);
                }
                else {
                    adj_matrix[u][v] = adj_matrix[v][u] = 1 + idx;
                    idx = 0;
                }
            }
        }
        return adj_matrix;
    }
};
```

```java
class Solution {
    public int[][] modifiedGraphEdges(int n, int[][] edges, int source, int destination, int target) {
        int k = 0;
        for (int[] e : edges) {
            if (e[2] == -1) {
                ++k;
            }
        }

        if (dijkstra(source, destination, construct(n, edges, 0, target)) > target) {
            return new int[0][];
        }
        if (dijkstra(source, destination, construct(n, edges, (long) k * (target - 1), target)) < target) {
            return new int[0][];
        }

        long left = 0, right = (long) k * (target - 1), ans = 0;
        while (left <= right) {
            long mid = (left + right) / 2;
            if (dijkstra(source, destination, construct(n, edges, mid, target)) >= target) {
                ans = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }

        for (int[] e : edges) {
            if (e[2] == -1) {
                if (ans >= target - 1) {
                    e[2] = target;
                    ans -= target - 1;
                } else {
                    e[2] = (int) (1 + ans);
                    ans = 0;
                }
            }
        }

        return edges;
    }

    public long dijkstra(int source, int destination, int[][] adjMatrix) {
        // 朴素的 dijkstra 算法
        // adjMatrix 是一个邻接矩阵
        int n = adjMatrix.length;
        long[] dist = new long[n];
        Arrays.fill(dist, Integer.MAX_VALUE / 2);
        boolean[] used = new boolean[n];
        dist[source] = 0;

        for (int round = 0; round < n - 1; ++round) {
            int u = -1;
            for (int i = 0; i < n; ++i) {
                if (!used[i] && (u == -1 || dist[i] < dist[u])) {
                    u = i;
                }
            }
            used[u] = true;
            for (int v = 0; v < n; ++v) {
                if (!used[v] && adjMatrix[u][v] != -1) {
                    dist[v] = Math.min(dist[v], dist[u] + adjMatrix[u][v]);
                }
            }
        }

        return dist[destination];
    }

    public int[][] construct(int n, int[][] edges, long idx, int target) {
        // 需要构造出第 idx 种不同的边权情况，返回一个邻接矩阵
        int[][] adjMatrix = new int[n][n];
        for (int i = 0; i < n; ++i) {
            Arrays.fill(adjMatrix[i], -1);
        }
        for (int[] e : edges) {
            int u = e[0], v = e[1], w = e[2];
            if (w != -1) {
                adjMatrix[u][v] = adjMatrix[v][u] = w;
            } else {
                if (idx >= target - 1) {
                    adjMatrix[u][v] = adjMatrix[v][u] = target;
                    idx -= (target - 1);
                } else {
                    adjMatrix[u][v] = adjMatrix[v][u] = (int) (1 + idx);
                    idx = 0;
                }
            }
        }
        return adjMatrix;
    }
}
```

```csharp
public class Solution {
    public int[][] ModifiedGraphEdges(int n, int[][] edges, int source, int destination, int target) {
        int k = 0;
        foreach (int[] e in edges) {
            if (e[2] == -1) {
                ++k;
            }
        }

        if (Dijkstra(source, destination, Construct(n, edges, 0, target)) > target) {
            return new int[0][];
        }
        if (Dijkstra(source, destination, Construct(n, edges, (long) k * (target - 1), target)) < target) {
            return new int[0][];
        }

        long left = 0, right = (long) k * (target - 1), ans = 0;
        while (left <= right) {
            long mid = (left + right) / 2;
            if (Dijkstra(source, destination, Construct(n, edges, mid, target)) >= target) {
                ans = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }

        foreach (int[] e in edges) {
            if (e[2] == -1) {
                if (ans >= target - 1) {
                    e[2] = target;
                    ans -= target - 1;
                } else {
                    e[2] = (int) (1 + ans);
                    ans = 0;
                }
            }
        }

        return edges;
    }

    public long Dijkstra(int source, int destination, int[][] adjMatrix) {
        // 朴素的 dijkstra 算法
        // adjMatrix 是一个邻接矩阵
        int n = adjMatrix.Length;
        long[] dist = new long[n];
        Array.Fill(dist, int.MaxValue / 2);
        bool[] used = new bool[n];
        dist[source] = 0;

        for (int round = 0; round < n - 1; ++round) {
            int u = -1;
            for (int i = 0; i < n; ++i) {
                if (!used[i] && (u == -1 || dist[i] < dist[u])) {
                    u = i;
                }
            }
            used[u] = true;
            for (int v = 0; v < n; ++v) {
                if (!used[v] && adjMatrix[u][v] != -1) {
                    dist[v] = Math.Min(dist[v], dist[u] + adjMatrix[u][v]);
                }
            }
        }

        return dist[destination];
    }

    public int[][] Construct(int n, int[][] edges, long idx, int target) {
        // 需要构造出第 idx 种不同的边权情况，返回一个邻接矩阵
        int[][] adjMatrix = new int[n][];
        for (int i = 0; i < n; ++i) {
            adjMatrix[i] = new int[n];
            Array.Fill(adjMatrix[i], -1);
        }
        foreach (int[] e in edges) {
            int u = e[0], v = e[1], w = e[2];
            if (w != -1) {
                adjMatrix[u][v] = adjMatrix[v][u] = w;
            } else {
                if (idx >= target - 1) {
                    adjMatrix[u][v] = adjMatrix[v][u] = target;
                    idx -= (target - 1);
                } else {
                    adjMatrix[u][v] = adjMatrix[v][u] = (int) (1 + idx);
                    idx = 0;
                }
            }
        }
        return adjMatrix;
    }
}
```

```python
class Solution:
    def modifiedGraphEdges(self, n: int, edges: List[List[int]], source: int, destination: int, target: int) -> List[List[int]]:
        def dijkstra(adj_matrix: List[List[int]]) -> int:
            # 朴素的 dijkstra 算法
            # adj_matrix 是一个邻接矩阵
            dist = [float("inf")] * n
            used = set()
            dist[source] = 0

            for round in range(n - 1):
                u = -1
                for i in range(n):
                    if i not in used and (u == -1 or dist[i] < dist[u]):
                        u = i
                used.add(u)
                for v in range(n):
                    if v not in used and adj_matrix[u][v] != -1:
                        dist[v] = min(dist[v], dist[u] + adj_matrix[u][v])
            
            return dist[destination]

        def construct(idx: int) -> List[List[int]]:
            # 需要构造出第 idx 种不同的边权情况，返回一个邻接矩阵
            adj_matrix = [[-1] * n for _ in range(n)]
            for u, v, w in edges:
                if w != -1:
                    adj_matrix[u][v] = adj_matrix[v][u] = w
                else:
                    if idx >= target - 1:
                        adj_matrix[u][v] = adj_matrix[v][u] = target
                        idx -= (target - 1)
                    else:
                        adj_matrix[u][v] = adj_matrix[v][u] = 1 + idx
                        idx = 0
            return adj_matrix
        
        k = sum(1 for e in edges if e[2] == -1)
        if dijkstra(construct(0)) > target:
            return []
        if dijkstra(construct(k * (target - 1))) < target:
            return []

        left, right, ans = 0, k * (target - 1), 0
        while left <= right:
            mid = (left + right) // 2
            if dijkstra(construct(mid)) >= target:
                ans = mid
                right = mid - 1
            else:
                left = mid + 1

        for i, e in enumerate(edges):
            if e[2] == -1:
                if ans >= target - 1:
                    edges[i][2] = target
                    ans -= (target - 1)
                else:
                    edges[i][2] = 1 + ans
                    ans = 0

        return edges
```

```go
func modifiedGraphEdges(n int, edges [][]int, source int, destination int, target int) [][]int {
    k := 0
    for _, e := range edges {
        if e[2] == -1 {
            k++
        }
    }
    if dijkstra(source, destination, construct(n, edges, 0, target)) > int64(target) {
        return nil
    }
    if dijkstra(source, destination, construct(n, edges, int64(k) * int64(target - 1), target)) < int64(target) {
        return nil
    }

    left, right, ans := int64(0), int64(k) * int64(target - 1), int64(0)
    for left <= right {
        mid := int64(left + right) / 2
        if dijkstra(source, destination, construct(n, edges, mid, target)) >= int64(target) {
            ans, right = mid, mid - 1
        } else {
            left = mid + 1
        }
    }
    for _, e := range edges {
        if e[2] == -1 {
            if ans >= int64(target - 1) {
                e[2] = target
                ans -= int64(target - 1)
            } else {
                e[2] = int(1 + ans)
                ans = 0
            }
        }
    }
    return edges
}

func dijkstra(source, destination int, adjMatrix [][]int) int64 {
    // 朴素的 dijistra 算法
    // adjMatrix 是一个邻接矩阵
    n := len(adjMatrix)
    dist, used := make([]int64, n), make([]bool, n)
    for i := 0; i < n; i++ {
        dist[i] = 0x3f3f3f3f3f
    }
    dist[source] = 0
    for round := 0; round < n - 1; round++ {
        u := -1
        for i := 0; i < n; i++ {
            if !used[i] && (u == -1 || dist[i] < dist[u]) {
                u = i
            }
        }
        used[u] = true
        for v := 0; v < n; v++ {
            if !used[v] && adjMatrix[u][v] != -1 && dist[v] > dist[u] + int64(adjMatrix[u][v]) {
                dist[v] = dist[u] + int64(adjMatrix[u][v])
            }
        }
    }
    return dist[destination]
}

func construct(n int, edges [][]int, idx int64, target int) [][]int {
    // 需要构造出第 idx 种不同的边权情况，返回一个邻接矩阵
    adjMatrix := make([][]int, n)
    for i := 0; i < n; i++ {
        adjMatrix[i] = make([]int, n)
        for j := 0; j < n; j++ {
            adjMatrix[i][j] = -1
        }
    }
    for _, e := range edges {
        u, v, w := e[0], e[1], e[2]
        if w != -1 {
            adjMatrix[u][v], adjMatrix[v][u] = w, w
        } else {
            if idx >= int64(target - 1) {
                adjMatrix[u][v], adjMatrix[v][u] = target, target
                idx -= int64(target - 1)
            } else {
                adjMatrix[u][v], adjMatrix[v][u] = int(1 + idx), int(1 + idx)
                idx = 0
            }
        }
    }
    return adjMatrix
}
```

```c
long long dijkstra(int source, int destination, int **adj_matrix, int n) {
    // 朴素的 dijkstra 算法
    // adj_matrix 是一个邻接矩阵
    long long dist[n];
    int used[n];
    memset(used, 0, sizeof(used));
    for (int i = 0; i < n; i++) {
        dist[i] = INT_MAX / 2;
    }
    dist[source] = 0;

    for (int round = 0; round < n - 1; ++round) {
        int u = -1;
        for (int i = 0; i < n; ++i) {
            if (!used[i] && (u == -1 || dist[i] < dist[u])) {
                u = i;
            }
        }
        used[u] = true;
        for (int v = 0; v < n; ++v) {
            if (!used[v] && adj_matrix[u][v] != -1) {
                dist[v] = fmin(dist[v], dist[u] + adj_matrix[u][v]);
            }
        }
    }

    return dist[destination];
}

int** construct(int** edges, int edgesSize, long long idx, int target, int **adj_matrix) {
    // 需要构造出第 idx 种不同的边权情况，返回一个邻接矩阵
    for (int i = 0; i < edgesSize; i++) {
        int u = edges[i][0], v = edges[i][1], w = edges[i][2];
        if (w != -1) {
            adj_matrix[u][v] = adj_matrix[v][u] = w;
        } else {
            if (idx >= target - 1) {
                adj_matrix[u][v] = adj_matrix[v][u] = target;
                idx -= (target - 1);
            } else {
                adj_matrix[u][v] = adj_matrix[v][u] = 1 + idx;
                idx = 0;
            }
        }
    }
    return adj_matrix;
}

int** modifiedGraphEdges(int n, int** edges, int edgesSize, int* edgesColSize, int source, int destination, int target, int* returnSize, int** returnColumnSizes) {
    int k = 0;
    for (int i = 0; i < edgesSize; i++) {
        if (edges[i][2] == -1) {
            ++k;
        }
    }

    int **adj_matrix = (int **)malloc(sizeof(int *) * n);
    for (int i = 0; i < n; i++) {
        adj_matrix[i] = (int *)malloc(sizeof(int) * n);
        memset(adj_matrix[i], 0xff, sizeof(int) * n);
    }
    if (dijkstra(source, destination, construct(edges, edgesSize, 0, target, adj_matrix), n) > target) {
        for (int i = 0; i < n; i++) {
            free(adj_matrix[i]);
        }
        free(adj_matrix);
        *returnSize = 0;
        return NULL;
    }
    if (dijkstra(source, destination, construct(edges, edgesSize, (long long) k * (target - 1), target, adj_matrix), n) < target) {
        for (int i = 0; i < n; i++) {
            free(adj_matrix[i]);
        }
        free(adj_matrix);
        *returnSize = 0;
        return NULL;
    }

    long long left = 0, right = (long long) k * (target - 1), ans = 0;
    while (left <= right) {
        long long mid = (left + right) / 2;
        if (dijkstra(source, destination, construct(edges, edgesSize, mid, target, adj_matrix), n) >= target) {
            ans = mid;
            right = mid - 1;
        } else {
            left = mid + 1;
        }
    }

    for (int i = 0; i < edgesSize; i++) {
        if (edges[i][2] == -1) {
            if (ans >= target - 1) {
                edges[i][2] = target;
                ans -= (target - 1);
            } else {
                edges[i][2] = 1 + ans;
                ans = 0;
            }
        }
    }
    *returnSize = edgesSize;
    *returnColumnSizes = edgesColSize;
    for (int i = 0; i < n; i++) {
        free(adj_matrix[i]);
    }
    free(adj_matrix);
    return edges;
}
```

```javascript
var modifiedGraphEdges = function(n, edges, source, destination, target) {
    let k = 0;
    for (const e of edges) {
        if (e[2] === -1) {
            ++k;
        }
    }

    if (dijkstra(source, destination, construct(n, edges, 0, target)) > target) {
        return [];
    }
    if (dijkstra(source, destination, construct(n, edges, k * (target - 1), target)) < target) {
        return [];
    }

    let left = 0, right = k * (target - 1), ans = 0;
    while (left <= right) {
        const mid = Math.floor((left + right) / 2);
        if (dijkstra(source, destination, construct(n, edges, mid, target)) >= target) {
            ans = mid;
            right = mid - 1;
        } else {
            left = mid + 1;
        }
    }

    for (const e of edges) {
        if (e[2] === -1) {
            if (ans >= target - 1) {
                e[2] = target;
                ans -= target - 1;
            } else {
                e[2] = 1 + ans;
                ans = 0;
            }
        }
    }

    return edges;
}

const dijkstra = (source, destination, adjMatrix) => {
    // 朴素的 dijkstra 算法
    // adjMatrix 是一个邻接矩阵
    const n = adjMatrix.length;
    const dist = new Array(n).fill(Number.MAX_VALUE);
    const used = new Array(n).fill(false);
    dist[source] = 0;

    for (let round = 0; round < n - 1; ++round) {
        let u = -1;
        for (let i = 0; i < n; ++i) {
            if (!used[i] && (u === -1 || dist[i] < dist[u])) {
                u = i;
            }
        }
        used[u] = true;
        for (let v = 0; v < n; ++v) {
            if (!used[v] && adjMatrix[u][v] != -1) {
                dist[v] = Math.min(dist[v], dist[u] + adjMatrix[u][v]);
            }
        }
    }

    return dist[destination];
}

const construct = (n, edges, idx, target) => {
    // 需要构造出第 idx 种不同的边权情况，返回一个邻接矩阵
    const adjMatrix = new Array(n).fill(0).map(() => new Array(n).fill(-1));
    for (const e of edges) {
        let u = e[0], v = e[1], w = e[2];
        if (w !== -1) {
            adjMatrix[u][v] = adjMatrix[v][u] = w;
        } else {
            if (idx >= target - 1) {
                adjMatrix[u][v] = adjMatrix[v][u] = target;
                idx -= (target - 1);
            } else {
                adjMatrix[u][v] = adjMatrix[v][u] = (1 + idx);
                idx = 0;
            }
        }
    }
    return adjMatrix;
};
```

**复杂度分析**

-   时间复杂度：$O((n^2 + m)(\log m + \log target))$，其中 $m$ 是图中边的数量。二分查找需要进行 $O(\log(k \times (target - 1)))$ 次，在最坏情况下，所有的边都是可以修改的边，即 $O(\log m + \log target)$。每一次二分查找中需要 $O(n^2+m)$ 的时间构造邻接矩阵，以及 $O(n^2)$ 的时间使用朴素的 Dijkstra 算法计算最短路。
-   空间复杂度：$O(n^2)$，即为朴素的 Dijkstra 算法中邻接矩阵需要的空间。返回的答案可以直接在给定的数组 $edges$ 上进行修改得到，省去 $O(m)$ 的空间。
