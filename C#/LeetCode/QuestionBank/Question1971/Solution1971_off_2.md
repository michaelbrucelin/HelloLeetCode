#### [方法二：深度优先搜索](https://leetcode.cn/problems/find-if-path-exists-in-graph/solutions/2024085/xun-zhao-tu-zhong-shi-fou-cun-zai-lu-jin-d0q0/)

**思路与算法**

我们使用深度优先搜索检测顶点 $source, destination$ 的连通性，需要从顶点 $source$ 开始依次遍历每一条可能的路径，判断可以到达顶点 $destination$，同时还需要记录每个顶点的访问状态防止重复访问。

首先从顶点 $source$ 开始遍历并进行递归搜索。搜索时每次访问一个顶点 $vertex$ 时，如果 $vertex$ 等于 $destination$ 则直接返回，否则将该顶点设为已访问，并递归访问与 $vertex$ 相邻且未访问的顶点 $next$。如果通过 $next$ 的路径可以访问到 $destination$，此时直接返回 $true$，当访问完所有的邻接节点仍然没有访问到 $destination$，此时返回 $false$。

**代码**

```cpp
class Solution {
public:
    bool dfs(int source, int destination, vector<vector<int>> &adj, vector<bool> &visited) {
        if (source == destination) {
            return true;
        }
        visited[source] = true;
        for (int next : adj[source]) {
            if (!visited[next] && dfs(next, destination, adj, visited)) {
                return true;
            }
        }
        return false;
    }

    bool validPath(int n, vector<vector<int>>& edges, int source, int destination) {
        vector<vector<int>> adj(n);
        for (auto &edge : edges) {
            int x = edge[0], y = edge[1];
            adj[x].emplace_back(y);
            adj[y].emplace_back(x);
        }
        vector<bool> visited(n, false);
        return dfs(source, destination, adj, visited);
    }
};
```

```java
class Solution {
    public boolean validPath(int n, int[][] edges, int source, int destination) {
        List<Integer>[] adj = new List[n];
        for (int i = 0; i < n; i++) {
            adj[i] = new ArrayList<Integer>();
        }
        for (int[] edge : edges) {
            int x = edge[0], y = edge[1];
            adj[x].add(y);
            adj[y].add(x);
        }
        boolean[] visited = new boolean[n];
        return dfs(source, destination, adj, visited);
    }

    public boolean dfs(int source, int destination, List<Integer>[] adj, boolean[] visited) {
        if (source == destination) {
            return true;
        }
        visited[source] = true;
        for (int next : adj[source]) {
            if (!visited[next] && dfs(next, destination, adj, visited)) {
                return true;
            }
        }
        return false;
    }
}
```

```csharp
public class Solution {
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        IList<int>[] adj = new IList<int>[n];
        for (int i = 0; i < n; i++) {
            adj[i] = new List<int>();
        }
        foreach (int[] edge in edges) {
            int x = edge[0], y = edge[1];
            adj[x].Add(y);
            adj[y].Add(x);
        }
        bool[] visited = new bool[n];
        return DFS(source, destination, adj, visited);
    }

    public bool DFS(int source, int destination, IList<int>[] adj, bool[] visited) {
        if (source == destination) {
            return true;
        }
        visited[source] = true;
        foreach (int next in adj[source]) {
            if (!visited[next] && DFS(next, destination, adj, visited)) {
                return true;
            }
        }
        return false;
    }
}
```

```c
struct ListNode *creatListNode(int val) {
    struct ListNode *node = (struct ListNode *)malloc(sizeof(struct ListNode));
    node->val = val;
    node->next = NULL;
    return node;
}

bool dfs(int source, int destination, const struct ListNode **adj, bool *visited) {
    if (source == destination) {
        return true;
    }
    visited[source] = true;
    if (!visited[destination]) {
        for (struct ListNode *p = adj[source]; p != NULL; p = p->next) {
            if (!visited[p->val] && dfs(p->val, destination, adj, visited)) {
                return true;
            }
        }
    }
    return false;
}

bool validPath(int n, int** edges, int edgesSize, int* edgesColSize, int source, int destination){
    struct ListNode * adj[n];
    bool visited[n];
    for (int i = 0; i < n; i++) {
        adj[i] = NULL;
        visited[i] = false;
    }
    for (int i = 0; i < edgesSize; i++) {
        int x = edges[i][0], y = edges[i][1];
        struct ListNode *nodex = creatListNode(x);
        nodex->next = adj[y];
        adj[y] = nodex;
        struct ListNode *nodey = creatListNode(y);
        nodey->next = adj[x];
        adj[x] = nodey;
    }
    bool ret = dfs(source, destination, adj, visited);
    for (int i = 0; i < n; i++) {
        for (struct ListNode *p = adj[i]; p != NULL;) {
            struct ListNode *cur = p;
            p = p->next;
            free(cur);
        }
    }
    return ret;
}
```

```javascript
var validPath = function(n, edges, source, destination) {
    const adj = new Array(n).fill(0).map(() => new Array());
    for (const edge of edges) {
        const x = edge[0], y = edge[1];
        adj[x].push(y);
        adj[y].push(x);
    }
    const visited = new Array(n).fill(0);
    return dfs(source, destination, adj, visited);
}

const dfs = (source, destination, adj, visited) => {
    if (source === destination) {
        return true;
    }
    visited[source] = true;
    for (const next of adj[source]) {
        if (!visited[next] && dfs(next, destination, adj, visited)) {
            return true;
        }
    }
    return false;
};
```

**复杂度分析**

-   时间复杂度：$O(n + m)$，其中 $n$ 表示图中顶点的数目，$m$ 表示图中边的数目。对于图中的每个顶点或者每条边，我们最多只需访问一次，对于每个顶因此时间复杂度为 $O(n + m)$。
-   空间复杂度：$O(n + m)$，其中 $n$ 表示图中顶点的数目，$m$ 表示图中边的数目。空间复杂度主要取决于邻接顶点列表、记录每个顶点访问状态的数组和递归调用栈，邻接顶点列表需要 $O(m + n)$ 的存储空间，记录每个顶点访问状态的数组和递归调用栈分别需要 $O(n)$ 的空间，因此总的空间复杂度为 $O(m + n)$。
