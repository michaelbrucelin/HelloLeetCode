### [边权重均等查询](https://leetcode.cn/problems/minimum-edge-weight-equilibrium-queries-in-a-tree/solutions/2614609/bian-quan-zhong-jun-deng-cha-xun-by-leet-yunc/)

#### 方法一：最近公共祖先

以节点 $0$ 为根节点，使用数组 $\textit{count}[i]$ 记录节点 $i$ 到根节点 $0$ 的路径上边权重的数量，即 $\textit{count}[i][j]$ 表示节点 $i$ 到根节点 $0$ 的路径上权重为 $j$ 的边数量。对于查询 $\textit{queries}[i] = [a_i, b_i]$，记节点 $\textit{lca}_i$ 为节点 $a_i$ 与 $b_i$ 的最近公共祖先，那么从节点 $a_i$ 到节点 $b_i$ 的路径上，权重为 $j$ 的边数量 $t_j$ 的计算如下：

$$t_j = \textit{count}[a_i][j] + \textit{count}[b_i][j] - 2 \times \textit{count}[\textit{lca}_i][j]$$

为了让节点 $a_i$ 到节点 $b_i$ 路径上每条边的权重都相等，贪心地将路径上所有的边都更改为边数量最多的权重即可，即从节点 $a_i$ 到节点 $b_i$ 路径上每条边的权重都相等所需的最小操作次数 $\textit{res}_i$ 的计算如下：

$$\textit{res}_i = \sum_{j=1}^{W}t_j - \max_{1 \le j \le W}t_j$$

其中 $W = 26$ 表示权重的最大值。

> 最近公共祖先节点的求解可以采用 $\text{Tarjan}$ 算法，不在面试考察范围，感兴趣的读者可以参考 OIWiki. 最近公共祖先。

```c++
const int W = 26;

class Solution {
public:
    int find(vector<int> &uf, int i) {
        if (uf[i] == i) {
            return i;
        }
        uf[i] = find(uf, uf[i]);
        return uf[i];
    }

    vector<int> minOperationsQueries(int n, vector<vector<int>>& edges, vector<vector<int>>& queries) {
        int m = queries.size();
        vector<unordered_map<int, int>> neighbors(n);
        for (auto &edge : edges) {
            neighbors[edge[0]][edge[1]] = edge[2];
            neighbors[edge[1]][edge[0]] = edge[2];
        }
        vector<vector<pair<int, int>>> queryArr(n);
        for (int i = 0; i < m; i++) {
            queryArr[queries[i][0]].push_back({queries[i][1], i});
            queryArr[queries[i][1]].push_back({queries[i][0], i});
        }

        vector<vector<int>> count(n, vector<int>(W + 1));
        vector<int> visited(n), uf(n), lca(m);
        function<void(int, int)> tarjan = [&](int node, int parent) {
            if (parent != -1) {
                count[node] = count[parent];
                count[node][neighbors[node][parent]]++;
            }
            uf[node] = node;
            for (auto [child, _] : neighbors[node]) {
                if (child == parent) {
                    continue;
                }
                tarjan(child, node);
                uf[child] = node;
            }
            for (auto [node1, index] : queryArr[node]) {
                if (node != node1 && !visited[node1]) {
                    continue;
                }
                lca[index] = find(uf, node1);
            }
            visited[node] = 1;
        };
        tarjan(0, -1);
        vector<int> res(m);
        for (int i = 0; i < m; i++) {
            int totalCount = 0, maxCount = 0;
            for (int j = 1; j <= W; j++) {
                int t = count[queries[i][0]][j] + count[queries[i][1]][j] - 2 * count[lca[i]][j];
                maxCount = max(maxCount, t);
                totalCount += t;
            }
            res[i] = totalCount - maxCount;
        }
        return res;
    }
};
```

```java
class Solution {
    static final int W = 26;

    public int[] minOperationsQueries(int n, int[][] edges, int[][] queries) {
        int m = queries.length;
        Map<Integer, Integer>[] neighbors = new Map[n];
        for (int i = 0; i < n; i++) {
            neighbors[i] = new HashMap<Integer, Integer>();
        }
        for (int[] edge : edges) {
            neighbors[edge[0]].put(edge[1], edge[2]);
            neighbors[edge[1]].put(edge[0], edge[2]);
        }
        List<int[]>[] queryArr = new List[n];
        for (int i = 0; i < n; i++) {
            queryArr[i] = new ArrayList<int[]>();
        }
        for (int i = 0; i < m; i++) {
            queryArr[queries[i][0]].add(new int[]{queries[i][1], i});
            queryArr[queries[i][1]].add(new int[]{queries[i][0], i});
        }

        int[][] count = new int[n][W + 1];
        boolean[] visited = new boolean[n];
        int[] uf = new int[n];
        int[] lca = new int[m];
        tarjan(0, -1, neighbors, queryArr, count, visited, uf, lca);
        int[] res = new int[m];
        for (int i = 0; i < m; i++) {
            int totalCount = 0, maxCount = 0;
            for (int j = 1; j <= W; j++) {
                int t = count[queries[i][0]][j] + count[queries[i][1]][j] - 2 * count[lca[i]][j];
                maxCount = Math.max(maxCount, t);
                totalCount += t;
            }
            res[i] = totalCount - maxCount;
        }
        return res;
    }

    public void tarjan(int node, int parent, Map<Integer, Integer>[] neighbors, List<int[]>[] queryArr, int[][] count, boolean[] visited, int[] uf, int[] lca) {
        if (parent != -1) {
            System.arraycopy(count[parent], 0, count[node], 0, W + 1);
            count[node][neighbors[node].get(parent)]++;
        }
        uf[node] = node;
        for (int child : neighbors[node].keySet()) {
            if (child == parent) {
                continue;
            }
            tarjan(child, node, neighbors, queryArr, count, visited, uf, lca);
            uf[child] = node;
        }
        for (int[] pair : queryArr[node]) {
            int node1 = pair[0], index = pair[1];
            if (node != node1 && !visited[node1]) {
                continue;
            }
            lca[index] = find(uf, node1);
        }
        visited[node] = true;
    }

    public int find(int[] uf, int i) {
        if (uf[i] == i) {
            return i;
        }
        uf[i] = find(uf, uf[i]);
        return uf[i];
    }
}
```

```csharp
public class Solution {
    const int W = 26;

    public int[] MinOperationsQueries(int n, int[][] edges, int[][] queries) {
        int m = queries.Length;
        IDictionary<int, int>[] neighbors = new IDictionary<int, int>[n];
        for (int i = 0; i < n; i++) {
            neighbors[i] = new Dictionary<int, int>();
        }
        foreach (int[] edge in edges) {
            neighbors[edge[0]].Add(edge[1], edge[2]);
            neighbors[edge[1]].Add(edge[0], edge[2]);
        }
        IList<int[]>[] queryArr = new IList<int[]>[n];
        for (int i = 0; i < n; i++) {
            queryArr[i] = new List<int[]>();
        }
        for (int i = 0; i < m; i++) {
            queryArr[queries[i][0]].Add(new int[]{queries[i][1], i});
            queryArr[queries[i][1]].Add(new int[]{queries[i][0], i});
        }

        int[][] count = new int[n][];
        for (int i = 0; i < n; i++) {
            count[i] = new int[W + 1];
        }
        bool[] visited = new bool[n];
        int[] uf = new int[n];
        int[] lca = new int[m];
        Tarjan(0, -1, neighbors, queryArr, count, visited, uf, lca);
        int[] res = new int[m];
        for (int i = 0; i < m; i++) {
            int totalCount = 0, maxCount = 0;
            for (int j = 1; j <= W; j++) {
                int t = count[queries[i][0]][j] + count[queries[i][1]][j] - 2 * count[lca[i]][j];
                maxCount = Math.Max(maxCount, t);
                totalCount += t;
            }
            res[i] = totalCount - maxCount;
        }
        return res;
    }

    public void Tarjan(int node, int parent, IDictionary<int, int>[] neighbors, IList<int[]>[] queryArr, int[][] count, bool[] visited, int[] uf, int[] lca) {
        if (parent != -1) {
            Array.Copy(count[parent], 0, count[node], 0, W + 1);
            count[node][neighbors[node][parent]]++;
        }
        uf[node] = node;
        foreach (int child in neighbors[node].Keys) {
            if (child == parent) {
                continue;
            }
            Tarjan(child, node, neighbors, queryArr, count, visited, uf, lca);
            uf[child] = node;
        }
        foreach (int[] pair in queryArr[node]) {
            int node1 = pair[0], index = pair[1];
            if (node != node1 && !visited[node1]) {
                continue;
            }
            lca[index] = Find(uf, node1);
        }
        visited[node] = true;
    }

    public int Find(int[] uf, int i) {
        if (uf[i] == i) {
            return i;
        }
        uf[i] = Find(uf, uf[i]);
        return uf[i];
    }
}
```

```go
const (
    W = 26
)

func find(uf []int, i int) int {
    if uf[i] == i {
        return i
    }
    uf[i] = find(uf, uf[i])
    return uf[i]
}

func minOperationsQueries(n int, edges [][]int, queries [][]int) []int {
    m := len(queries)
    neighbors := make([]map[int]int, n)
    for i := 0; i < n; i++ {
        neighbors[i] = map[int]int{}
    }
    for _, edge := range edges {
        neighbors[edge[0]][edge[1]] = edge[2]
        neighbors[edge[1]][edge[0]] = edge[2]
    }
    queryArr := make([][][2]int, n)
    for i := 0; i < m; i++ {
        queryArr[queries[i][0]] = append(queryArr[queries[i][0]], [2]int{queries[i][1], i})
        queryArr[queries[i][1]] = append(queryArr[queries[i][1]], [2]int{queries[i][0], i})
    }

    count := make([][]int, n)
    for i := 0; i < n; i++ {
        count[i] = make([]int, W + 1)
    }
    visited, uf, lca := make([]int, n), make([]int, n), make([]int, n)
    var tarjan func(int, int)
    tarjan = func(node, parent int) {
        if parent != -1 {
            copy(count[node], count[parent])
            count[node][neighbors[node][parent]]++
        }
        uf[node] = node
        for child, _ := range neighbors[node] {
            if child == parent {
                continue
            }
            tarjan(child, node)
            uf[child] = node
        }
        for _, query := range queryArr[node] {
            node1, index := query[0], query[1]
            if node != node1 && visited[node1] == 0 {
                continue
            }
            lca[index] = find(uf, node1)
        }
        visited[node] = 1
    }
    tarjan(0, -1)
    res := make([]int, m)
    for i := 0; i < m; i++ {
        totalCount, maxCount := 0, 0
        for j := 1; j <= W; j++ {
            t := count[queries[i][0]][j] + count[queries[i][1]][j] - 2 * count[lca[i]][j]
            maxCount, totalCount = max(maxCount, t), totalCount + t
        }
        res[i] = totalCount - maxCount
    }
    return res
}
```

```python
class Solution:
    def find(self, uf: List[int], i: int) -> int:
        if uf[i] == i:
            return i
        uf[i] = self.find(uf, uf[i])
        return uf[i]

    def minOperationsQueries(self, n: int, edges: List[List[int]], queries: List[List[int]]) -> List[int]: 
        m, W = len(queries), 26
        neighbors = [dict() for i in range(n)]
        for edge in edges:
            neighbors[edge[0]][edge[1]] = edge[2]
            neighbors[edge[1]][edge[0]] = edge[2]
        queryArr = [[] for i in range(n)]
        for i in range(m):
            queryArr[queries[i][0]].append([queries[i][1], i])
            queryArr[queries[i][1]].append([queries[i][0], i])

        count = [[0 for j in range(W + 1)] for i in range(n)]
        visited, uf, lca = [0 for i in range(n)], [0 for i in range(n)], [0 for i in range(m)]
        def tarjan(node: int, parent: int):
            if parent != -1:
                count[node] = count[parent].copy()
                count[node][neighbors[node][parent]] += 1
            uf[node] = node
            for child in neighbors[node].keys():
                if child == parent:
                    continue
                tarjan(child, node)
                uf[child] = node
            for [node1, index] in queryArr[node]:
                if node != node1 and not visited[node1]:
                    continue
                lca[index] = self.find(uf, node1)
            visited[node] = 1

        tarjan(0, -1)
        res = [0 for i in range(m)]
        for i in range(m):
            totalCount, maxCount = 0, 0
            for j in range(1, W+1):
                t = count[queries[i][0]][j] + count[queries[i][1]][j] - 2 * count[lca[i]][j]
                maxCount = max(maxCount, t)
                totalCount += t
            res[i] = totalCount - maxCount
        return res
```

```c
const int W = 26;

typedef struct Node {
    int node;
    int index;
    struct Node *next;
} Node;

typedef struct {
    int key;
    int val;
    UT_hash_handle hh;
} HashItem; 

Node *creatNode(int node, int index) {
    Node *obj = (Node *)malloc(sizeof(Node));
    obj->node = node;
    obj->index = index;
    obj->next = NULL;
    return obj;
}

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetItem(HashItem **obj, int key, int defaultVal) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

void freeList(Node *list) {
    while (list) {
        Node *cur = list;
        list = list->next;
        free(cur);
    }
}

int find(int* uf, int i) {
    if (uf[i] == i) {
        return i;
    }
    uf[i] = find(uf, uf[i]);
    return uf[i];
}

void tarjan(int node, int parent, HashItem **neighbors, int **count, int *uf, int *visited, int *lca, Node **queryArr) {
    if (parent != -1) {
        memcpy(count[node], count[parent], sizeof(int) * (W + 1));
        count[node][hashGetItem(&neighbors[node], parent, 0)]++;
    }
    uf[node] = node;
    for (HashItem *pEntry = neighbors[node]; pEntry; pEntry = pEntry->hh.next) {
        int child = pEntry->key;
        if (child == parent) {
            continue;
        }
        tarjan(child, node, neighbors, count, uf, visited, lca, queryArr);
        uf[child] = node;
    }
    for (Node *p = queryArr[node]; p; p = p->next) {
        int node1 = p->node;
        int index = p->index;
        if (node != node1 && !visited[node1]) {
            continue;
        }
        lca[index] = find(uf, node1);
    }
    visited[node] = 1;
};

int* minOperationsQueries(int n, int** edges, int edgesSize, int* edgesColSize, int** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    int m = queriesSize;
    HashItem *neighbors[n];
    Node *queryArr[n];
    for (int i = 0; i < n; i++) {
        neighbors[i] = NULL;
        queryArr[i] = NULL;
    }
    for (int i = 0; i < edgesSize; i++) {
        int u = edges[i][0];
        int v = edges[i][1];
        int w = edges[i][2];
        hashAddItem(&neighbors[u], v, w);
        hashAddItem(&neighbors[v], u, w);
    }
    
    for (int i = 0; i < m; i++) {
        int a = queries[i][0];
        int b = queries[i][1];
        Node *node1 = creatNode(b, i);
        node1->next = queryArr[a];
        queryArr[a] = node1;
        Node *node2 = creatNode(a, i);
        node2->next = queryArr[b];
        queryArr[b] = node2;
    }

    int *count[n];
    int visited[n], uf[n], lca[m];
    memset(visited, 0, sizeof(visited));
    memset(uf, 0, sizeof(uf));
    memset(lca, 0, sizeof(lca));
    for (int i = 0; i < n; i++) {
        count[i] = (int *)malloc(sizeof(int) * (W + 1));
        memset(count[i], 0, sizeof(int) * (W + 1));
    }
    
    tarjan(0, -1, neighbors, count, uf, visited, lca, queryArr);
    int *res = (int *)malloc(sizeof(int) * m);
    for (int i = 0; i < m; i++) {
        int totalCount = 0, maxCount = 0;
        for (int j = 1; j <= W; j++) {
            int t = count[queries[i][0]][j] + count[queries[i][1]][j] - 2 * count[lca[i]][j];
            maxCount = fmax(maxCount, t);
            totalCount += t;
        }
        res[i] = totalCount - maxCount;
    }
    *returnSize = m;
    for (int i = 0; i < n; i++) {
        free(count[i]);
        freeList(queryArr[i]);
        hashFree(&neighbors[i]);
    }
    return res;
}
```

```javascript
var find = function(uf, i) {
    if (uf[i] === i) {
        return i;
    }
    uf[i] = find(uf, uf[i]);
    return uf[i];
}

var minOperationsQueries = function(n, edges, queries) {
    const m = queries.length;
    const W = 26;
    const neighbors = new Array(n).fill(null).map(() => new Map());

    for (const edge of edges) {
        neighbors[edge[0]].set(edge[1], edge[2]);
        neighbors[edge[1]].set(edge[0], edge[2]);
    }

    const queryArr = new Array(n).fill(null).map(() => []);
    for (let i = 0; i < m; i++) {
        queryArr[queries[i][0]].push([queries[i][1], i]);
        queryArr[queries[i][1]].push([queries[i][0], i]);
    }

    const count = new Array(n).fill(null).map(() => new Array(W + 1).fill(0));
    const visited = new Array(n).fill(0);
    const uf = new Array(n).fill(0);
    const lca = new Array(m).fill(0);

    const tarjan = (node, parent) => {
        if (parent !== -1) {
            count[node] = [...count[parent]];
            count[node][neighbors[node].get(parent)] += 1;
        }
        uf[node] = node;

        for (const [child, weight] of neighbors[node]) {
            if (child == parent) {
                continue;
            }
            tarjan(child, node);
            uf[child] = node;
        }

        for (const [node1, index] of queryArr[node]) {
            if (node !== node1 && !visited[node1]) {
                continue;
            }
            lca[index] = find(uf, node1);
        }
        visited[node] = 1;
    };

    tarjan(0, -1);
    const res = new Array(m).fill(0);
    for (let i = 0; i < m; i++) {
        let totalCount = 0;
        let maxCount = 0;
        for (let j = 1; j <= W; j++) {
            const t = count[queries[i][0]][j] + count[queries[i][1]][j] - 2 * count[lca[i]][j];
            maxCount = Math.max(maxCount, t);
            totalCount += t;
        }
        res[i] = totalCount - maxCount;
    }

    return res;
};
```

```typescript
const find = (uf: number[], i: number): number => {
    if (uf[i] === i) {
        return i;
    }
    uf[i] = find(uf, uf[i]);
    return uf[i];
};

function minOperationsQueries(n: number, edges: number[][], queries: number[][]): number[] {
    const m = queries.length;
    const W = 26;
    const neighbors: Map<number, number>[] = new Array(n).fill(null).map(() => new Map());

    for (const edge of edges) {
        neighbors[edge[0]].set(edge[1], edge[2]);
        neighbors[edge[1]].set(edge[0], edge[2]);
    }

    const queryArr: [number, number][][] = new Array(n).fill(null).map(() => []);
    for (let i = 0; i < m; i++) {
        queryArr[queries[i][0]].push([queries[i][1], i]);
        queryArr[queries[i][1]].push([queries[i][0], i]);
    }

    const count: number[][] = new Array(n).fill(null).map(() => new Array(W + 1).fill(0));
    const visited: number[] = new Array(n).fill(0);
    const uf: number[] = new Array(n).fill(0);
    const lca: number[] = new Array(m).fill(0);

    const tarjan = (node: number, parent: number) => {
        if (parent !== -1) {
            count[node] = [...count[parent]];
            count[node][neighbors[node].get(parent)] += 1;
        }
        uf[node] = node;

        for (const [child, weight] of neighbors[node]) {
            if (child == parent) {
                continue;
            }
            tarjan(child, node);
            uf[child] = node;
        }

        for (const [node1, index] of queryArr[node]) {
            if (node !== node1 && !visited[node1]) {
                continue;
            }
            lca[index] = find(uf, node1);
        }
        visited[node] = 1;
    };

    tarjan(0, -1);
    const res: number[] = new Array(m).fill(0);
    for (let i = 0; i < m; i++) {
        let totalCount = 0;
        let maxCount = 0;
        for (let j = 1; j <= W; j++) {
            const t = count[queries[i][0]][j] + count[queries[i][1]][j] - 2 * count[lca[i]][j];
            maxCount = Math.max(maxCount, t);
            totalCount += t;
        }
        res[i] = totalCount - maxCount;
    }

    return res;
};
```

#### 复杂度分析

- 时间复杂度：$O((m + n) \times W + m \times \log n)$，其中 $n$ 是节点数目，$m$ 是查询数目，$W$ 是权重的可能取值数目。
- 空间复杂度：$O(n \times W + m)$。
