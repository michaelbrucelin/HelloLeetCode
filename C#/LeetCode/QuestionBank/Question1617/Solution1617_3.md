#### [方法二：深度优先搜索](https://leetcode.cn/problems/count-subtrees-with-max-distance-between-cities/solutions/2161714/tong-ji-zi-shu-zhong-cheng-shi-zhi-jian-duoq1/)

**思路与算法**

方法二与方法一一样通过状态压缩，来枚举子树，并计算连通子树的直径，计算直径的方法采用深度优先搜索。

-   首先我们利用广度优先搜索或者深度优先搜索检测子树的连通性，并从任意节点 $x$ 开始找到距离 $x$ 的最远节点 $y$；
-   找到以节点 $y$ 为根节点的子树的最大深度即为该子树的直径。

**代码**

```cpp
class Solution {
public:      
    vector<int> countSubgraphsForEachDiameter(int n, vector<vector<int>>& edges) {
        vector<vector<int>> adj(n);        
        for (auto &edge : edges) {
            int x = edge[0] - 1;
            int y = edge[1] - 1;
            adj[x].emplace_back(y);
            adj[y].emplace_back(x);
        }

        function<int(int, int, int)> dfs = [&](int parent, int u, int mask)->int {
            int depth = 0;
            for (int v : adj[u]) {
                if (v != parent && mask & (1 << v)) {
                    depth = max(depth, 1 + dfs(u, v, mask));
                }
            }
            return depth;
        };

        vector<int> ans(n - 1);
        for (int i = 1; i < (1 << n); i++) {
            int x = 32 - __builtin_clz(i) - 1;
            int mask = i;
            int y = -1;
            queue<int> qu;
            qu.emplace(x);
            mask &= ~(1 << x);
            while (!qu.empty()) {
                y = qu.front();
                qu.pop();
                for (int vertex : adj[y]) {
                    if (mask & (1 << vertex)) {
                        mask &= ~(1 << vertex);
                        qu.emplace(vertex);
                    }
                }
            }
            if (mask == 0) {
                int diameter = dfs(-1, y, i);
                if (diameter > 0) {
                    ans[diameter - 1]++;
                }
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    int mask;
    int diameter;

    public int[] countSubgraphsForEachDiameter(int n, int[][] edges) {
        List<Integer>[] adj = new List[n];
        for (int i = 0; i < n; i++) {
            adj[i] = new ArrayList<Integer>();
        }
        for (int[] edge : edges) {
            int x = edge[0] - 1;
            int y = edge[1] - 1;
            adj[x].add(y);
            adj[y].add(x);
        }

        int[] ans = new int[n - 1];
        for (int i = 1; i < (1 << n); i++) {
            int x = 32 - Integer.numberOfLeadingZeros(i) - 1;
            int mask = i;
            int y = -1;
            Queue<Integer> queue = new ArrayDeque<Integer>();
            queue.offer(x);
            mask &= ~(1 << x);
            while (!queue.isEmpty()) {
                y = queue.poll();
                for (int vertex : adj[y]) {
                    if ((mask & (1 << vertex)) != 0) {
                        mask &= ~(1 << vertex);
                        queue.offer(vertex);
                    }
                }
            }
            if (mask == 0) {
                int diameter = dfs(adj, -1, y, i);
                if (diameter > 0) {
                    ans[diameter - 1]++;
                }
            }
        }
        return ans;
    }

    public int dfs(List<Integer>[] adj, int parent, int u, int mask) {
        int depth = 0;
        for (int v : adj[u]) {
            if (v != parent && (mask & (1 << v)) != 0) {
                depth = Math.max(depth, 1 + dfs(adj, u, v, mask));
            }
        }
        return depth;
    }
}
```

```c
static inline int max(int a, int b) {
    return a > b ? a : b;
}

int dfs(int parent, int u, int mask, int **adj, int *adjColSize) {
    int depth = 0;
    for (int i = 0; i < adjColSize[u]; i++) {
        int vertex = adj[u][i];
        if (vertex != parent && mask & (1 << vertex)) {
            depth = max(depth, 1 + dfs(u, vertex, mask, adj, adjColSize));
        }
    }
    return depth;
}

int* countSubgraphsForEachDiameter(int n, int** edges, int edgesSize, int* edgesColSize, int* returnSize) {
    int *adj[n];
    int adjColSize[n];
    for (int i = 0; i < n; i++) {
        adj[i] = (int*)calloc(n, sizeof(int));;
    }
    memset(adjColSize, 0, sizeof(adjColSize));
    for (int i = 0; i < edgesSize; i++) {
        int x = edges[i][0] - 1;
        int y = edges[i][1] - 1;
        adj[x][adjColSize[x]++] = y;
        adj[y][adjColSize[y]++] = x;
    }

    int *ans = (int *)calloc(n - 1, sizeof(int));
    for (int i = 1; i < (1 << n); i++) {
        int root = 32 - __builtin_clz(i) - 1, mask = i;
        int queue[n];
        int head = 0, tail = 0;
        int node = -1;
        queue[tail++] = root;
        mask &= ~(1 << root);
        while (head != tail) {
            node = queue[head++];
            for (int j = 0; j < adjColSize[node]; j++) {
                int vertex = adj[node][j];
                if (mask & (1 << vertex)) {
                    mask &= ~(1 << vertex);
                    queue[tail++] = vertex;
                }
            }
        }
        if (mask == 0) {
            int diameter = dfs(-1, node, i, adj, adjColSize);
            if (diameter > 0) {
                ans[diameter - 1]++;
            }
        }
    }
    for (int i = 0; i < n; i++) {
        free(adj[i]);
    }
    *returnSize = n - 1;
    return ans;
}
```

```javascript
var countSubgraphsForEachDiameter = function(n, edges) {
    const adj = new Array(n).fill(0);
    for (let i = 0; i < n; i++) {
        adj[i] = [];
    }
    for (const edge of edges) {
        const x = edge[0] - 1;
        const y = edge[1] - 1;
        adj[x].push(y);
        adj[y].push(x);
    }

    const ans = new Array(n - 1).fill(0);
    for (let i = 1; i < (1 << n); i++) {
        const x = 32 - numberOfLeadingZeros(i) - 1;
        let mask = i;
        let y = -1;
        const queue = [x];
        mask &= ~(1 << x);
        while (queue.length) {
            y = queue.shift();
            for (const vertex of adj[y]) {
                if ((mask & (1 << vertex)) !== 0) {
                    mask &= ~(1 << vertex);
                    queue.push(vertex);
                }
            }
        }
        if (mask === 0) {
            const diameter = dfs(adj, -1, y, i);
            if (diameter > 0) {
                ans[diameter - 1]++;
            }
        }
    }
    return ans;
}

const dfs = (adj, parent, u, mask) => {
    let depth = 0;
    for (const v of adj[u]) {
        if (v !== parent && (mask & (1 << v)) !== 0) {
            depth = Math.max(depth, 1 + dfs(adj, u, v, mask));
        }
    }
    return depth;
}
const numberOfLeadingZeros = (i) => {
    if (i === 0)
        return 32;
    let n = 1;
    if (i >>> 16 === 0) { n += 16; i <<= 16; }
    if (i >>> 24 === 0) { n +=  8; i <<=  8; }
    if (i >>> 28 === 0) { n +=  4; i <<=  4; }
    if (i >>> 30 === 0) { n +=  2; i <<=  2; }
    n -= i >>> 31;
    return n;
}
```

**复杂度分析**

-   时间复杂度：$O(n \times 2^n)$，其中 $n$ 表示给定的城市的数目。我们枚举图中所有可能的子树，一共最多有 $2^n$ 个子树，检测子树的连通性与计算子树的直径需要的时间为 $O(n)$，因此总的时间复杂度为 $O(n \times 2^n)$。
-   空间复杂度：$O(n)$，其中 $n$ 表示给定的城市的数目。我们需要存储图的邻接关系，由于图中只有 $n-1$ 条边，存储图的邻接关系需要的空间为 $O(n)$，每次递归求树的直径中递归的最大深度为 $n$，因此总的空间复杂度为 $O(n)$。
