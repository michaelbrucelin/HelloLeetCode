### [统计完全连通分量的数量](https://leetcode.cn/problems/count-the-number-of-complete-components/solutions/3992716/tong-ji-wan-quan-lian-tong-fen-liang-de-bvhtu/)

#### 方法一：深度优先搜索

**思路与算法**

假设一个完全连通分量有 $E$ 条边，$V$ 个点，其具有如下性质：

$$E=\dfrac{V\times (V-1)}{2}$$

因此我们只需要统计一个连通分量中边和点的数量即可判断这个连通分量是不是完全连通分量。

方法一使用深度优先搜索，首先根据 $edges$ 建图，使用临时变量 $V$ 和 $E$ 来分别统计一个连通分量中点和边的数量，在深度优先搜索的过程中，每遍历到一个点，便将 $V$ 加一，并且把连接到这个点的所有边的数目添加到 $E$ 中，由于在一个连通分量中每条边都统计了两遍，因此遍历完一个连通分量后如果有：$E=V\times (V-1)$，答案加一。

**代码**

```C++
class Solution {
public:
    int countCompleteComponents(int n, vector<vector<int>>& edges) {
        vector<int> visit(n, 0);
        vector<vector<int>> g(n);
        for (auto &e : edges) {
            int u = e[0];
            int v = e[1];
            g[u].push_back(v);
            g[v].push_back(u);
        }
        int ans = 0, V, E;
        auto dfs = [&](this auto&& dfs, int u) -> void{
            visit[u] = 1;
            V++;
            E += g[u].size();
            for (int v : g[u]) {
                if (!visit[v]) {
                    dfs(v);
                }
            }
        };
        for (int i = 0; i < n; i++) {
            if (!visit[i]) {
                V = 0;
                E = 0;
                dfs(i);
                ans += E == V * (V - 1);
            }
        }
        return ans;
    }
};
```

```Go
func countCompleteComponents(n int, edges [][]int) int {
    graph := make([][]int, n)
    for i := range graph {
        graph[i] = make([]int, 0)
    }
    for _, e := range edges {
        u, v := e[0], e[1]
        graph[u] = append(graph[u], v)
        graph[v] = append(graph[v], u)
    }

    visited := make([]bool, n)
    ans := 0
    var V, E int
    var dfs func(int)
    dfs = func(u int) {
        visited[u] = true
        V++
        E += len(graph[u])
        for _, v := range graph[u] {
            if !visited[v] {
                dfs(v)
            }
        }
    }

    for i := 0; i < n; i++ {
        if !visited[i] {
            V, E = 0, 0
            dfs(i)
            if E == V*(V-1) {
                ans++
            }
        }
    }
    return ans
}
```

```Python
class Solution:
    def countCompleteComponents(self, n, edges):
        graph = [[] for _ in range(n)]
        for u, v in edges:
            graph[u].append(v)
            graph[v].append(u)

        visited = [False] * n
        ans = 0

        for i in range(n):
            if not visited[i]:
                stack = [i]
                visited[i] = True
                V = 0
                E = 0
                while stack:
                    u = stack.pop()
                    V += 1
                    E += len(graph[u])
                    for v in graph[u]:
                        if not visited[v]:
                            visited[v] = True
                            stack.append(v)
                if E == V * (V - 1):
                    ans += 1

        return ans
```

```Java
class Solution {
    public int countCompleteComponents(int n, int[][] edges) {
        List<List<Integer>> graph = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            graph.add(new ArrayList<>());
        }
        for (int[] e : edges) {
            int u = e[0], v = e[1];
            graph.get(u).add(v);
            graph.get(v).add(u);
        }

        boolean[] visited = new boolean[n];
        int ans = 0;

        for (int i = 0; i < n; i++) {
            if (!visited[i]) {
                int[] cnt = new int[2];
                dfs(i, graph, visited, cnt);
                if (cnt[1] == cnt[0] * (cnt[0] - 1)) {
                    ans++;
                }
            }
        }
        return ans;
    }

    private void dfs(int u, List<List<Integer>> graph, boolean[] visited, int[] cnt) {
        visited[u] = true;
        cnt[0]++;
        cnt[1] += graph.get(u).size();
        for (int v : graph.get(u)) {
            if (!visited[v]) {
                dfs(v, graph, visited, cnt);
            }
        }
    }
}
```

```CSharp
public class Solution {
    public int CountCompleteComponents(int n, int[][] edges) {
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++) {
            graph[i] = new List<int>();
        }
        foreach (var e in edges) {
            int u = e[0], v = e[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }

        var visited = new bool[n];
        int ans = 0;

        for (int i = 0; i < n; i++) {
            if (!visited[i]) {
                int vCount = 0, eCount = 0;
                Dfs(i, graph, visited, ref vCount, ref eCount);
                if (eCount == vCount * (vCount - 1)) {
                    ans++;
                }
            }
        }

        return ans;
    }

    private void Dfs(int u, List<int>[] graph, bool[] visited, ref int vCount, ref int eCount) {
        visited[u] = true;
        vCount++;
        eCount += graph[u].Count;
        foreach (int v in graph[u]) {
            if (!visited[v]) {
                Dfs(v, graph, visited, ref vCount, ref eCount);
            }
        }
    }
}
```

```C
int countCompleteComponents(int n, int** edges, int edgesSize, int* edgesColSize) {
    int** graph = (int**)malloc(n * sizeof(int*));
    int* degree = (int*)malloc(n * sizeof(int));
    int* visited = (int*)calloc(n, sizeof(int));
    for (int i = 0; i < n; i++) {
        graph[i] = (int*)malloc(n * sizeof(int));
        memset(graph[i], 0, n * sizeof(int));
        degree[i] = 0;
    }

    for (int i = 0; i < edgesSize; i++) {
        int u = edges[i][0];
        int v = edges[i][1];
        graph[u][degree[u]++] = v;
        graph[v][degree[v]++] = u;
    }

    int ans = 0;
    for (int i = 0; i < n; i++) {
        if (!visited[i]) {
            int* stack = (int*)malloc(n * sizeof(int));
            int top = 0;
            int V = 0, E = 0;
            stack[top++] = i;
            visited[i] = 1;
            while (top > 0) {
                int u = stack[--top];
                V++;
                E += degree[u];
                for (int j = 0; j < degree[u]; j++) {
                    int v = graph[u][j];
                    if (!visited[v]) {
                        visited[v] = 1;
                        stack[top++] = v;
                    }
                }
            }
            free(stack);
            if (E == V * (V - 1)) {
                ans++;
            }
        }
    }

    for (int i = 0; i < n; i++) {
        free(graph[i]);
    }
    free(graph);
    free(degree);
    free(visited);
    return ans;
}
```

```JavaScript
function countCompleteComponents(n, edges) {
    const graph = Array.from({ length: n }, () => []);
    for (const [u, v] of edges) {
        graph[u].push(v);
        graph[v].push(u);
    }

    const visited = Array(n).fill(false);
    let ans = 0;

    for (let i = 0; i < n; i++) {
        if (!visited[i]) {
            let V = 0, E = 0;
            const stack = [i];
            visited[i] = true;
            while (stack.length > 0) {
                const u = stack.pop();
                V++;
                E += graph[u].length;
                for (const v of graph[u]) {
                    if (!visited[v]) {
                        visited[v] = true;
                        stack.push(v);
                    }
                }
            }
            if (E === V * (V - 1)) {
                ans++;
            }
        }
    }
    return ans;
}
```

```TypeScript
function countCompleteComponents(n: number, edges: number[][]): number {
    const graph: number[][] = Array.from({ length: n }, () => []);
    for (const [u, v] of edges) {
        graph[u].push(v);
        graph[v].push(u);
    }

    const visited = Array<boolean>(n).fill(false);
    let ans = 0;

    for (let i = 0; i < n; i++) {
        if (!visited[i]) {
            let V = 0, E = 0;
            const stack = [i];
            visited[i] = true;
            while (stack.length > 0) {
                const u = stack.pop()!;
                V++;
                E += graph[u].length;
                for (const v of graph[u]) {
                    if (!visited[v]) {
                        visited[v] = true;
                        stack.push(v);
                    }
                }
            }
            if (E === V * (V - 1)) {
                ans++;
            }
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn count_complete_components(n: i32, edges: Vec<Vec<i32>>) -> i32 {
        let n = n as usize;
        let mut graph = vec![vec![]; n];
        for edge in edges {
            let u = edge[0] as usize;
            let v = edge[1] as usize;
            graph[u].push(v as i32);
            graph[v].push(u as i32);
        }

        let mut visited = vec![false; n];
        let mut ans = 0;

        for i in 0..n {
            if !visited[i] {
                let mut stack = vec![i];
                visited[i] = true;
                let mut v_count = 0;
                let mut e_count = 0;

                while let Some(u) = stack.pop() {
                    v_count += 1;
                    e_count += graph[u].len();
                    for &v in &graph[u] {
                        let v = v as usize;
                        if !visited[v] {
                            visited[v] = true;
                            stack.push(v);
                        }
                    }
                }

                if e_count == v_count * (v_count - 1) {
                    ans += 1;
                }
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(V+E)$，其中 $V$ 为图中点的数量，$E$ 为图中边的数量。建图遍历所有边 $O(E)$，dfs 为 $O(V+E)$，外层循环为 $O(V)$。
- 空间复杂度：$O(V+E)$，其中 $V$ 为图中点的数量，$E$ 为图中边的数量。邻接表存图 $O(V+E)$，点访问数组 $vis$ 为 $O(V)$，dfs 递归栈深度最坏情况下为 $O(V)$。

#### 方法二：广度优先搜索

**思路与算法**

方法二使用广度优先搜索，具体思路与深度优先搜索无异，还是首先根据 $edges$ 建图，从 $0$ 开始寻找连通分量，并在 $bfs$ 寻找连通分量的过程中统计该连通分量中点和边的数量，然后对于每个连通分量根据是否满足 $E=V\times (V-1)$ 来判断其是不是完全连通分量。

**代码**

```C++
class Solution {
public:
    int countCompleteComponents(int n, vector<vector<int>>& edges) {
        vector<vector<int>> g(n);
        vector<int> vis(n, 0);
        int ans = 0, V, E;
        for (auto edge : edges) {
            int u = edge[0];
            int v = edge[1];
            g[u].push_back(v);
            g[v].push_back(u);
        }
        auto bfs = [&](int s) -> bool {
            queue<int> q;
            q.push(s);
            while (!q.empty()) {
                int u = q.front();
                q.pop();
                if (vis[u]) {
                    continue;
                }
                vis[u] = 1;
                V++;
                E += g[u].size();
                for (auto v : g[u]) {
                    q.push(v);
                }
            }
            return E == V * (V - 1);
        };
        for (int i = 0; i < n; i++) {
            if (!vis[i]) {
                V = 0;
                E = 0;
                if (bfs(i)) {
                    ans++;
                }
            }
        }
        return ans;
    }
};
```

```Go
func countCompleteComponents(n int, edges [][]int) int {
    graph := make([][]int, n)
    for i := range graph {
        graph[i] = make([]int, 0)
    }
    for _, e := range edges {
        u, v := e[0], e[1]
        graph[u] = append(graph[u], v)
        graph[v] = append(graph[v], u)
    }

    visited := make([]bool, n)
    ans := 0

    for i := 0; i < n; i++ {
        if !visited[i] {
            V, E := 0, 0
            queue := []int{i}
            visited[i] = true
            head := 0
            for head < len(queue) {
                u := queue[head]
                head++
                V++
                E += len(graph[u])
                for _, v := range graph[u] {
                    if !visited[v] {
                        visited[v] = true
                        queue = append(queue, v)
                    }
                }
            }
            if E == V*(V-1) {
                ans++
            }
        }
    }
    return ans
}
```

```Python
class Solution:
    def countCompleteComponents(self, n, edges):
        graph = [[] for _ in range(n)]
        for u, v in edges:
            graph[u].append(v)
            graph[v].append(u)

        visited = [False] * n
        ans = 0

        for i in range(n):
            if not visited[i]:
                queue = [i]
                visited[i] = True
                head = 0
                V = 0
                E = 0
                while head < len(queue):
                    u = queue[head]
                    head += 1
                    V += 1
                    E += len(graph[u])
                    for v in graph[u]:
                        if not visited[v]:
                            visited[v] = True
                            queue.append(v)
                if E == V * (V - 1):
                    ans += 1

        return ans
```

```Java
class Solution {
    public int countCompleteComponents(int n, int[][] edges) {
        List<List<Integer>> graph = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            graph.add(new ArrayList<>());
        }
        for (int[] e : edges) {
            int u = e[0], v = e[1];
            graph.get(u).add(v);
            graph.get(v).add(u);
        }

        boolean[] visited = new boolean[n];
        int ans = 0;

        for (int i = 0; i < n; i++) {
            if (!visited[i]) {
                int V = 0, E = 0;
                Queue<Integer> queue = new LinkedList<>();
                queue.offer(i);
                visited[i] = true;
                while (!queue.isEmpty()) {
                    int u = queue.poll();
                    V++;
                    E += graph.get(u).size();
                    for (int v : graph.get(u)) {
                        if (!visited[v]) {
                            visited[v] = true;
                            queue.offer(v);
                        }
                    }
                }
                if (E == V * (V - 1)) {
                    ans++;
                }
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int CountCompleteComponents(int n, int[][] edges) {
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++) {
            graph[i] = new List<int>();
        }
        foreach (var e in edges) {
            int u = e[0], v = e[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }

        var visited = new bool[n];
        int ans = 0;

        for (int i = 0; i < n; i++) {
            if (!visited[i]) {
                int V = 0, E = 0;
                var queue = new Queue<int>();
                queue.Enqueue(i);
                visited[i] = true;
                while (queue.Count > 0) {
                    int u = queue.Dequeue();
                    V++;
                    E += graph[u].Count;
                    foreach (int v in graph[u]) {
                        if (!visited[v]) {
                            visited[v] = true;
                            queue.Enqueue(v);
                        }
                    }
                }
                if (E == V * (V - 1)) {
                    ans++;
                }
            }
        }
        return ans;
    }
}
```

```C
int countCompleteComponents(int n, int** edges, int edgesSize, int* edgesColSize) {
    int** graph = (int**)malloc(n * sizeof(int*));
    int* degree = (int*)malloc(n * sizeof(int));
    int* visited = (int*)calloc(n, sizeof(int));
    for (int i = 0; i < n; i++) {
        graph[i] = (int*)malloc(n * sizeof(int));
        memset(graph[i], 0, n * sizeof(int));
        degree[i] = 0;
    }

    for (int i = 0; i < edgesSize; i++) {
        int u = edges[i][0];
        int v = edges[i][1];
        graph[u][degree[u]++] = v;
        graph[v][degree[v]++] = u;
    }

    int ans = 0;
    for (int i = 0; i < n; i++) {
        if (!visited[i]) {
            int* queue = (int*)malloc(n * sizeof(int));
            int front = 0, rear = 0;
            int V = 0, E = 0;
            queue[rear++] = i;
            visited[i] = 1;
            while (front < rear) {
                int u = queue[front++];
                V++;
                E += degree[u];
                for (int j = 0; j < degree[u]; j++) {
                    int v = graph[u][j];
                    if (!visited[v]) {
                        visited[v] = 1;
                        queue[rear++] = v;
                    }
                }
            }
            free(queue);
            if (E == V * (V - 1)) {
                ans++;
            }
        }
    }

    for (int i = 0; i < n; i++) {
        free(graph[i]);
    }
    free(graph);
    free(degree);
    free(visited);
    return ans;
}
```

```JavaScript
function countCompleteComponents(n, edges) {
    const graph = Array.from({ length: n }, () => []);
    for (const [u, v] of edges) {
        graph[u].push(v);
        graph[v].push(u);
    }

    const visited = Array(n).fill(false);
    let ans = 0;

    for (let i = 0; i < n; i++) {
        if (!visited[i]) {
            let V = 0, E = 0;
            const queue = [i];
            let head = 0;
            visited[i] = true;
            while (head < queue.length) {
                const u = queue[head++];
                V++;
                E += graph[u].length;
                for (const v of graph[u]) {
                    if (!visited[v]) {
                        visited[v] = true;
                        queue.push(v);
                    }
                }
            }
            if (E === V * (V - 1)) {
                ans++;
            }
        }
    }
    return ans;
}
```

```TypeScript
function countCompleteComponents(n: number, edges: number[][]): number {
    const graph: number[][] = Array.from({ length: n }, () => []);
    for (const [u, v] of edges) {
        graph[u].push(v);
        graph[v].push(u);
    }

    const visited = Array<boolean>(n).fill(false);
    let ans = 0;

    for (let i = 0; i < n; i++) {
        if (!visited[i]) {
            let V = 0, E = 0;
            const queue = [i];
            let head = 0;
            visited[i] = true;
            while (head < queue.length) {
                const u = queue[head++];
                V++;
                E += graph[u].length;
                for (const v of graph[u]) {
                    if (!visited[v]) {
                        visited[v] = true;
                        queue.push(v);
                    }
                }
            }
            if (E === V * (V - 1)) {
                ans++;
            }
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn count_complete_components(n: i32, edges: Vec<Vec<i32>>) -> i32 {
        let n = n as usize;
        let mut graph = vec![vec![]; n];
        for edge in edges {
            let u = edge[0] as usize;
            let v = edge[1] as usize;
            graph[u].push(v as i32);
            graph[v].push(u as i32);
        }

        let mut visited = vec![false; n];
        let mut ans = 0;

        for i in 0..n {
            if !visited[i] {
                let mut queue = vec![i];
                let mut head = 0;
                visited[i] = true;
                let mut v_count = 0;
                let mut e_count = 0;

                while head < queue.len() {
                    let u = queue[head];
                    head += 1;
                    v_count += 1;
                    e_count += graph[u].len();
                    for &v in &graph[u] {
                        let v = v as usize;
                        if !visited[v] {
                            visited[v] = true;
                            queue.push(v);
                        }
                    }
                }

                if e_count == v_count * (v_count - 1) {
                    ans += 1;
                }
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(V+E)$，其中 $V$ 为图中点的数量，$E$ 为图中边的数量。建图遍历所有边 $O(E)$，bfs 为 $O(V+E)$，外层循环为 $O(V)$。
- 空间复杂度：$O(V+E)$，其中 $V$ 为图中点的数量，$E$ 为图中边的数量。邻接表存图 $O(V+E)$，点访问数组 $vis$ 为 $O(V)$，bfs 队列最坏情况下为 $O(V)$。

#### 方法三：并查集

方法三使用并查集，定义 $fa$ 数组为每个节点的父亲节点，也就是其所属的集合，定义 $numV$ 和 $numE$ 来记录每个集合中包含的点与边的数量。

首先初始化每个节点的父亲节点为自己，即每个节点相互隔离，在遍历 $edges$ 的过程中将相连的节点放入同一个集合中。

在预处理结束后，从 $0$ 到 $n-1$ 遍历所有节点，用 $Find$ 函数找到节点 $i$ 所属的集合 $x$，那么集合 $x$ 中节点数量加一，对应 $numV[Find(i)]+1$；

再遍历所有的边，用 $Find$ 函数找到边 $edge$ 所属的集合 $x$，那么集合 $x$ 中边的数量加一，对应 $numE[Find(edge[0])]+1;$

最后对于每个集合，用 $E=V\times (V-1)/2$ 来判断其是不是完全连通分量即可，其中 $E$ 是该集合中边的数量，$V$ 是该集合中节点的数量。

```C++
class DSU {
public:
    DSU(int n) : parent(n), rank(n, 1) {
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
    }

    int find(int x) {
        if (parent[x] != x) {
            parent[x] = find(parent[x]);
        }
        return parent[x];
    }

    void unionSet(int x, int y) {
        x = find(x);
        y = find(y);
        if (x == y) {
            return;
        }
        if (rank[x] > rank[y]) {
            parent[y] = x;
        } else if (rank[y] > rank[x]) {
            parent[x] = y;
        } else {
            parent[x] = y;
            rank[y]++;
        }
    }

private:
    vector<int> parent;
    vector<int> rank;
};

class Solution {
public:
    int countCompleteComponents(int n, vector<vector<int>>& edges) {
        DSU dsu(n);
        for (auto& edge : edges) {
            dsu.unionSet(edge[0], edge[1]);
        }

        vector<int> numV(n, 0);
        vector<int> numE(n, 0);
        for (int i = 0; i < n; i++) {
            numV[dsu.find(i)]++;
        }
        for (auto& edge : edges) {
            numE[dsu.find(edge[0])]++;
        }

        int ans = 0;
        for (int i = 0; i < n; i++) {
            if (dsu.find(i) == i) {
                ans += numE[i] == (numV[i] * (numV[i] - 1) / 2);
            }
        }
        return ans;
    }
};
```

```Go
type DSU struct {
    parent []int
    rank   []int
}

func NewDSU(n int) *DSU {
    parent := make([]int, n)
    rank := make([]int, n)
    for i := 0; i < n; i++ {
        parent[i] = i
        rank[i] = 1
    }
    return &DSU{parent: parent, rank: rank}
}

func (d *DSU) Find(x int) int {
    if d.parent[x] != x {
        d.parent[x] = d.Find(d.parent[x])
    }
    return d.parent[x]
}

func (d *DSU) Union(x, y int) {
    rx, ry := d.Find(x), d.Find(y)
    if rx == ry {
        return
    }
    if d.rank[rx] > d.rank[ry] {
        d.parent[ry] = rx
    } else if d.rank[ry] > d.rank[rx] {
        d.parent[rx] = ry
    } else {
        d.parent[rx] = ry
        d.rank[ry]++
    }
}

func countCompleteComponents(n int, edges [][]int) int {
    dsu := NewDSU(n)
    for _, e := range edges {
        dsu.Union(e[0], e[1])
    }

    numV := make([]int, n)
    numE := make([]int, n)
    for i := 0; i < n; i++ {
        numV[dsu.Find(i)]++
    }
    for _, e := range edges {
        numE[dsu.Find(e[0])]++
    }

    ans := 0
    for i := 0; i < n; i++ {
        if dsu.Find(i) == i && numE[i] == numV[i]*(numV[i]-1)/2 {
            ans++
        }
    }
    return ans
}
```

```Python
class DSU:
    def __init__(self, n: int):
        self.parent = list(range(n))
        self.rank = [1] * n

    def find(self, x: int) -> int:
        if self.parent[x] != x:
            self.parent[x] = self.find(self.parent[x])
        return self.parent[x]

    def union(self, x: int, y: int) -> None:
        rx, ry = self.find(x), self.find(y)
        if rx == ry:
            return
        if self.rank[rx] > self.rank[ry]:
            self.parent[ry] = rx
        elif self.rank[ry] > self.rank[rx]:
            self.parent[rx] = ry
        else:
            self.parent[rx] = ry
            self.rank[ry] += 1

class Solution:
    def countCompleteComponents(self, n: int, edges: list[list[int]]) -> int:
        dsu = DSU(n)
        for u, v in edges:
            dsu.union(u, v)

        numV = [0] * n
        numE = [0] * n
        for i in range(n):
            numV[dsu.find(i)] += 1
        for u, v in edges:
            numE[dsu.find(u)] += 1

        ans = 0
        for i in range(n):
            if dsu.find(i) == i and numE[i] == numV[i] * (numV[i] - 1) // 2:
                ans += 1
        return ans
```

```Java
class DSU {
    private int[] parent;
    private int[] rank;

    public DSU(int n) {
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
            rank[i] = 1;
        }
    }

    public int find(int x) {
        if (parent[x] != x) {
            parent[x] = find(parent[x]);
        }
        return parent[x];
    }

    public void union(int x, int y) {
        int rx = find(x);
        int ry = find(y);
        if (rx == ry) {
            return;
        }
        if (rank[rx] > rank[ry]) {
            parent[ry] = rx;
        } else if (rank[ry] > rank[rx]) {
            parent[rx] = ry;
        } else {
            parent[rx] = ry;
            rank[ry]++;
        }
    }
}

class Solution {
    public int countCompleteComponents(int n, int[][] edges) {
        DSU dsu = new DSU(n);
        for (int[] e : edges) {
            dsu.union(e[0], e[1]);
        }

        int[] numV = new int[n];
        int[] numE = new int[n];
        for (int i = 0; i < n; i++) {
            numV[dsu.find(i)]++;
        }
        for (int[] e : edges) {
            numE[dsu.find(e[0])]++;
        }

        int ans = 0;
        for (int i = 0; i < n; i++) {
            if (dsu.find(i) == i && numE[i] == numV[i] * (numV[i] - 1) / 2) {
                ans++;
            }
        }
        return ans;
    }
}
```

```CSharp
public class DSU {
    private int[] parent;
    private int[] rank;

    public DSU(int n) {
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
            rank[i] = 1;
        }
    }

    public int Find(int x) {
        if (parent[x] != x) {
            parent[x] = Find(parent[x]);
        }
        return parent[x];
    }

    public void Union(int x, int y) {
        int rx = Find(x);
        int ry = Find(y);
        if (rx == ry) {
            return;
        }
        if (rank[rx] > rank[ry]) {
            parent[ry] = rx;
        } else if (rank[ry] > rank[rx]) {
            parent[rx] = ry;
        } else {
            parent[rx] = ry;
            rank[ry]++;
        }
    }
}

public class Solution {
    public int CountCompleteComponents(int n, int[][] edges) {
        DSU dsu = new DSU(n);
        foreach (var e in edges) {
            dsu.Union(e[0], e[1]);
        }

        int[] numV = new int[n];
        int[] numE = new int[n];
        for (int i = 0; i < n; i++) {
            numV[dsu.Find(i)]++;
        }
        foreach (var e in edges) {
            numE[dsu.Find(e[0])]++;
        }

        int ans = 0;
        for (int i = 0; i < n; i++) {
            if (dsu.Find(i) == i && numE[i] == numV[i] * (numV[i] - 1) / 2) {
                ans++;
            }
        }
        return ans;
    }
}
```

```C
typedef struct {
    int* parent;
    int* rank;
    int size;
} DSU;

static void dsuInit(DSU* dsu, int n) {
    dsu->parent = (int*)malloc(n * sizeof(int));
    dsu->rank = (int*)malloc(n * sizeof(int));
    dsu->size = n;
    for (int i = 0; i < n; i++) {
        dsu->parent[i] = i;
        dsu->rank[i] = 1;
    }
}

static void dsuFree(DSU* dsu) {
    free(dsu->parent);
    free(dsu->rank);
}

static int dsuFind(DSU* dsu, int x) {
    if (dsu->parent[x] != x) {
        dsu->parent[x] = dsuFind(dsu, dsu->parent[x]);
    }
    return dsu->parent[x];
}

static void dsuUnion(DSU* dsu, int x, int y) {
    int rx = dsuFind(dsu, x);
    int ry = dsuFind(dsu, y);
    if (rx == ry) {
        return;
    }
    if (dsu->rank[rx] > dsu->rank[ry]) {
        dsu->parent[ry] = rx;
    } else if (dsu->rank[ry] > dsu->rank[rx]) {
        dsu->parent[rx] = ry;
    } else {
        dsu->parent[rx] = ry;
        dsu->rank[ry]++;
    }
}

int countCompleteComponents(int n, int** edges, int edgesSize, int* edgesColSize) {
    DSU dsu;
    dsuInit(&dsu, n);

    for (int i = 0; i < edgesSize; i++) {
        dsuUnion(&dsu, edges[i][0], edges[i][1]);
    }

    int* numV = (int*)calloc(n, sizeof(int));
    int* numE = (int*)calloc(n, sizeof(int));
    for (int i = 0; i < n; i++) {
        numV[dsuFind(&dsu, i)]++;
    }
    for (int i = 0; i < edgesSize; i++) {
        numE[dsuFind(&dsu, edges[i][0])]++;
    }

    int ans = 0;
    for (int i = 0; i < n; i++) {
        if (dsuFind(&dsu, i) == i && numE[i] == numV[i] * (numV[i] - 1) / 2) {
            ans++;
        }
    }

    free(numV);
    free(numE);
    dsuFree(&dsu);
    return ans;
}
```

```JavaScript
class DSU {
    constructor(n) {
        this.parent = Array.from({ length: n }, (_, i) => i);
        this.rank = Array(n).fill(1);
    }

    find(x) {
        if (this.parent[x] !== x) {
            this.parent[x] = this.find(this.parent[x]);
        }
        return this.parent[x];
    }

    union(x, y) {
        const rx = this.find(x);
        const ry = this.find(y);
        if (rx === ry) {
            return;
        }
        if (this.rank[rx] > this.rank[ry]) {
            this.parent[ry] = rx;
        } else if (this.rank[ry] > this.rank[rx]) {
            this.parent[rx] = ry;
        } else {
            this.parent[rx] = ry;
            this.rank[ry]++;
        }
    }
}

function countCompleteComponents(n, edges) {
    const dsu = new DSU(n);
    for (const [u, v] of edges) {
        dsu.union(u, v);
    }

    const numV = Array(n).fill(0);
    const numE = Array(n).fill(0);
    for (let i = 0; i < n; i++) {
        numV[dsu.find(i)]++;
    }
    for (const [u] of edges) {
        numE[dsu.find(u)]++;
    }

    let ans = 0;
    for (let i = 0; i < n; i++) {
        if (dsu.find(i) === i && numE[i] === numV[i] * (numV[i] - 1) / 2) {
            ans++;
        }
    }
    return ans;
}
```

```TypeScript
class DSU {
    private parent: number[];
    private rank: number[];

    constructor(n: number) {
        this.parent = Array.from({ length: n }, (_, i) => i);
        this.rank = Array<number>(n).fill(1);
    }

    find(x: number): number {
        if (this.parent[x] !== x) {
            this.parent[x] = this.find(this.parent[x]);
        }
        return this.parent[x];
    }

    union(x: number, y: number): void {
        const rx = this.find(x);
        const ry = this.find(y);
        if (rx === ry) {
            return;
        }
        if (this.rank[rx] > this.rank[ry]) {
            this.parent[ry] = rx;
        } else if (this.rank[ry] > this.rank[rx]) {
            this.parent[rx] = ry;
        } else {
            this.parent[rx] = ry;
            this.rank[ry]++;
        }
    }
}

function countCompleteComponents(n: number, edges: number[][]): number {
    const dsu = new DSU(n);
    for (const [u, v] of edges) {
        dsu.union(u, v);
    }

    const numV = Array<number>(n).fill(0);
    const numE = Array<number>(n).fill(0);
    for (let i = 0; i < n; i++) {
        numV[dsu.find(i)]++;
    }
    for (const [u] of edges) {
        numE[dsu.find(u)]++;
    }

    let ans = 0;
    for (let i = 0; i < n; i++) {
        if (dsu.find(i) === i && numE[i] === numV[i] * (numV[i] - 1) / 2) {
            ans++;
        }
    }
    return ans;
}
```

```Rust
struct DSU {
    parent: Vec<usize>,
    rank: Vec<usize>,
}

impl DSU {
    fn new(n: usize) -> Self {
        let mut parent = vec![0; n];
        let mut rank = vec![1; n];
        for i in 0..n {
            parent[i] = i;
        }
        Self { parent, rank }
    }

    fn find(&mut self, x: usize) -> usize {
        if self.parent[x] != x {
            let p = self.parent[x];
            self.parent[x] = self.find(p);
        }
        self.parent[x]
    }

    fn union(&mut self, x: usize, y: usize) {
        let rx = self.find(x);
        let ry = self.find(y);
        if rx == ry {
            return;
        }
        if self.rank[rx] > self.rank[ry] {
            self.parent[ry] = rx;
        } else if self.rank[ry] > self.rank[rx] {
            self.parent[rx] = ry;
        } else {
            self.parent[rx] = ry;
            self.rank[ry] += 1;
        }
    }
}

impl Solution {
    pub fn count_complete_components(n: i32, edges: Vec<Vec<i32>>) -> i32 {
        let n = n as usize;
        let mut dsu = DSU::new(n);

        for edge in &edges {
            dsu.union(edge[0] as usize, edge[1] as usize);
        }

        let mut num_v = vec![0; n];
        let mut num_e = vec![0; n];
        for i in 0..n {
            num_v[dsu.find(i)] += 1;
        }
        for edge in &edges {
            num_e[dsu.find(edge[0] as usize)] += 1;
        }

        let mut ans = 0;
        for i in 0..n {
            if dsu.find(i) == i && num_e[i] == num_v[i] * (num_v[i] - 1) / 2 {
                ans += 1;
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：总体时间复杂度为 $O((V+E)\times \alpha (V))$，其中 $V$ 为图中点的数量，$E$ 为图中边的数量，$\alpha (V)$ 为反阿克曼函数。初始化并查集 $O(V)$，合并所有边 $O(E\times \alpha (V))$，统计每个连通分量的顶点数 $O(V\times \alpha (V))$，统计每个连通分量的边数 $O(E\times \alpha (V))$，统计答案 $O(V)$。
- 空间复杂度：总计空间复杂度为 $O(V)$，其中 $V$ 为图中点的数量。$fa$ 数组、rk 数组、numV 数组、numE 数组的空间复杂度均为 $O(V)$。
