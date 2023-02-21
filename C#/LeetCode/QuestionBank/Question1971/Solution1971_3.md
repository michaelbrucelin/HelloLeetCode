#### [前言](https://leetcode.cn/problems/find-if-path-exists-in-graph/solutions/2024085/xun-zhao-tu-zhong-shi-fou-cun-zai-lu-jin-d0q0/)

题目要求判断是否存在从起点 $source$ 到终点 $destination$ 的有效路径，等价于求图中两个顶点 $source, destination$ 是否连通。两点连通性问题为经典问题，一般我们可以使用广度优先搜索或深度优先搜索，以及并查集来解决。

#### [方法一：广度优先搜索](https://leetcode.cn/problems/find-if-path-exists-in-graph/solutions/2024085/xun-zhao-tu-zhong-shi-fou-cun-zai-lu-jin-d0q0/)

**思路与算法**

使用广度优先搜索判断顶点 $source$ 到顶点 $destination$ 的连通性，需要我们从顶点 $source$ 开始按照层次依次遍历每一层的顶点，检测是否可以到达顶点 $destination$。遍历过程我们使用队列存储最近访问过的顶点，同时记录每个顶点的访问状态，每次从队列中取出顶点 $vertex$ 时，将其未访问过的邻接顶点入队列。

初始时将顶点 $source$ 设为已访问，并将其入队列。每次将队列中的节点 $vertex$ 出队列，并将与 $vertex$ 相邻且未访问的顶点 $next$ 入队列，并将 $next$ 设为已访问。当队列为空或访问到顶点 $destination$ 时遍历结束，返回顶点 $destination$ 的访问状态即可。

**代码**

```cpp
class Solution {
public:
    bool validPath(int n, vector<vector<int>>& edges, int source, int destination) {
        vector<vector<int>> adj(n);
        for (auto &&edge : edges) {
            int x = edge[0], y = edge[1];
            adj[x].emplace_back(y);
            adj[y].emplace_back(x);
        }
        vector<bool> visited(n, false);
        queue<int> qu;
        qu.emplace(source);
        visited[source] = true;
        while (!qu.empty()) {
            int vertex = qu.front();
            qu.pop();
            if (vertex == destination) {
                break;
            }
            for (int next: adj[vertex]) {
                if (!visited[next]) {
                    qu.emplace(next);
                    visited[next] = true;
                }
            }
        }
        return visited[destination];
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
        Queue<Integer> queue = new ArrayDeque<Integer>();
        queue.offer(source);
        visited[source] = true;
        while (!queue.isEmpty()) {
            int vertex = queue.poll();
            if (vertex == destination) {
                break;
            }
            for (int next : adj[vertex]) {
                if (!visited[next]) {
                    queue.offer(next);
                    visited[next] = true;
                }
            }
        }
        return visited[destination];
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
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(source);
        visited[source] = true;
        while (queue.Count > 0) {
            int vertex = queue.Dequeue();
            if (vertex == destination) {
                break;
            }
            foreach (int next in adj[vertex]) {
                if (!visited[next]) {
                    queue.Enqueue(next);
                    visited[next] = true;
                }
            }
        }
        return visited[destination];
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
    int queue[n];
    int head = 0, tail = 0;
    queue[tail++] = source;
    visited[source] = true;
    while (head != tail) {
        int vertex = queue[head++];
        if (vertex == destination) {
            break;
        }
        for (struct ListNode *p = adj[vertex]; p != NULL; p = p->next) {
            int next = p->val;
            if (!visited[next]) {
                queue[tail++] = next;
                visited[next] = true;
            }
        }
    }
    for (int i = 0; i < n; i++) {
        for (struct ListNode *p = adj[i]; p != NULL;) {
            struct ListNode *cur = p;
            p = p->next;
            free(cur);
        }
    }
    return visited[destination];
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
    const visited = new Array(n).fill(false);
    const queue = [source];
    visited[source] = true;
    while (queue.length) {
        const vertex = queue.shift();
        if (vertex === destination) {
            break;
        }
        for (const next of adj[vertex]) {
            if (!visited[next]) {
                queue.push(next);
                visited[next] = true;
            }
        }
    }
    return visited[destination];
};
```

**复杂度分析**

-   时间复杂度：$O(n + m)$，其中 $n$ 表示图中顶点的数目，$m$ 表示图中边的数目。对于图中的每个顶点或者每条边，我们最多只需访问一次，因此时间复杂度为 $O(n + m)$。
-   空间复杂度：$O(n + m)$，其中 $n$ 表示图中顶点的数目，$m$ 表示图中边的数目。空间复杂度主要取决于邻接顶点列表、记录每个顶点访问状态的数组和队列，邻接顶点列表需要的空间为 $O(n + m)$，记录访问状态需要 $O(n)$ 的空间，进行广度优先搜索时队列中最多只有 $n$ 个元素，因此总的空间复杂度为 $O(n + m)$。
