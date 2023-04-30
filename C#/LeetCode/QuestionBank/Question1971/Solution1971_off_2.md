#### [�������������������](https://leetcode.cn/problems/find-if-path-exists-in-graph/solutions/2024085/xun-zhao-tu-zhong-shi-fou-cun-zai-lu-jin-d0q0/)

**˼·���㷨**

����ʹ���������������ⶥ�� $source, destination$ ����ͨ�ԣ���Ҫ�Ӷ��� $source$ ��ʼ���α���ÿһ�����ܵ�·�����жϿ��Ե��ﶥ�� $destination$��ͬʱ����Ҫ��¼ÿ������ķ���״̬��ֹ�ظ����ʡ�

���ȴӶ��� $source$ ��ʼ���������еݹ�����������ʱÿ�η���һ������ $vertex$ ʱ����� $vertex$ ���� $destination$ ��ֱ�ӷ��أ����򽫸ö�����Ϊ�ѷ��ʣ����ݹ������ $vertex$ ������δ���ʵĶ��� $next$�����ͨ�� $next$ ��·�����Է��ʵ� $destination$����ʱֱ�ӷ��� $true$�������������е��ڽӽڵ���Ȼû�з��ʵ� $destination$����ʱ���� $false$��

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n + m)$������ $n$ ��ʾͼ�ж������Ŀ��$m$ ��ʾͼ�бߵ���Ŀ������ͼ�е�ÿ���������ÿ���ߣ��������ֻ�����һ�Σ�����ÿ�������ʱ�临�Ӷ�Ϊ $O(n + m)$��
-   �ռ临�Ӷȣ�$O(n + m)$������ $n$ ��ʾͼ�ж������Ŀ��$m$ ��ʾͼ�бߵ���Ŀ���ռ临�Ӷ���Ҫȡ�����ڽӶ����б���¼ÿ���������״̬������͵ݹ����ջ���ڽӶ����б���Ҫ $O(m + n)$ �Ĵ洢�ռ䣬��¼ÿ���������״̬������͵ݹ����ջ�ֱ���Ҫ $O(n)$ �Ŀռ䣬����ܵĿռ临�Ӷ�Ϊ $O(m + n)$��
