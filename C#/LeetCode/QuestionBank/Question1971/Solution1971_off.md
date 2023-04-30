#### [ǰ��](https://leetcode.cn/problems/find-if-path-exists-in-graph/solutions/2024085/xun-zhao-tu-zhong-shi-fou-cun-zai-lu-jin-d0q0/)

��ĿҪ���ж��Ƿ���ڴ���� $source$ ���յ� $destination$ ����Ч·�����ȼ�����ͼ���������� $source, destination$ �Ƿ���ͨ��������ͨ������Ϊ�������⣬һ�����ǿ���ʹ�ù��������������������������Լ����鼯�������

#### [����һ�������������](https://leetcode.cn/problems/find-if-path-exists-in-graph/solutions/2024085/xun-zhao-tu-zhong-shi-fou-cun-zai-lu-jin-d0q0/)

**˼·���㷨**

ʹ�ù�����������ж϶��� $source$ ������ $destination$ ����ͨ�ԣ���Ҫ���ǴӶ��� $source$ ��ʼ���ղ�����α���ÿһ��Ķ��㣬����Ƿ���Ե��ﶥ�� $destination$��������������ʹ�ö��д洢������ʹ��Ķ��㣬ͬʱ��¼ÿ������ķ���״̬��ÿ�δӶ�����ȡ������ $vertex$ ʱ������δ���ʹ����ڽӶ�������С�

��ʼʱ������ $source$ ��Ϊ�ѷ��ʣ�����������С�ÿ�ν������еĽڵ� $vertex$ �����У������� $vertex$ ������δ���ʵĶ��� $next$ ����У����� $next$ ��Ϊ�ѷ��ʡ�������Ϊ�ջ���ʵ����� $destination$ ʱ�������������ض��� $destination$ �ķ���״̬���ɡ�

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n + m)$������ $n$ ��ʾͼ�ж������Ŀ��$m$ ��ʾͼ�бߵ���Ŀ������ͼ�е�ÿ���������ÿ���ߣ��������ֻ�����һ�Σ����ʱ�临�Ӷ�Ϊ $O(n + m)$��
-   �ռ临�Ӷȣ�$O(n + m)$������ $n$ ��ʾͼ�ж������Ŀ��$m$ ��ʾͼ�бߵ���Ŀ���ռ临�Ӷ���Ҫȡ�����ڽӶ����б���¼ÿ���������״̬������Ͷ��У��ڽӶ����б���Ҫ�Ŀռ�Ϊ $O(n + m)$����¼����״̬��Ҫ $O(n)$ �Ŀռ䣬���й����������ʱ���������ֻ�� $n$ ��Ԫ�أ�����ܵĿռ临�Ӷ�Ϊ $O(n + m)$��
