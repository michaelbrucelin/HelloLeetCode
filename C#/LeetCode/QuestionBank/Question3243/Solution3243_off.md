### [新增道路查询后的最短距离 I](https://leetcode.cn/problems/shortest-distance-after-road-addition-queries-i/solutions/2984418/xin-zeng-dao-lu-cha-xun-hou-de-zui-duan-9smce/)

#### 方法一：广度优先搜索

因为城市之间的道路的长度都是 $1$，即边权相同，所以我们可以使用广度优先搜索算法来获取两个城市之间的最短路径。

具体地，我们首先构造一个图 $neighbors$，$neighbors[i]$ 表示城市 $i$ 可以通往的其他城市集合。那么初始时，对于 $0 \le i < n-1$，有 $neighbors[i]={i+1}$，表示从城市 $i$ 有一条单向道路通往城市 $i+1$。然后我们遍历查询数组 $queries$，令当前遍历的查询值为 $[u,v]$，我们将 $v$ 加入到 $neighbors[u]$ 中，然后对新的图 $neighbors$ 执行广度优先搜索算法，获取城市 $0$ 到城市 $n-1$ 的最短路径长度。遍历结束后，返回最终结果。

```C++
class Solution {
public:
    vector<int> shortestDistanceAfterQueries(int n, vector<vector<int>> &queries) {
        vector<vector<int>> neighbors(n);
        for (int i = 0; i < n - 1; i++) {
            neighbors[i].push_back(i + 1);
        }
        vector<int> res;
        for (auto &query : queries) {
            neighbors[query[0]].push_back(query[1]);
            res.push_back(bfs(n, neighbors));
        }
        return res;
    }

    int bfs(int n, const vector<vector<int>> &neighbors) {
        vector<int> dist(n, -1);
        queue<int> q;
        q.push(0);
        dist[0] = 0;
        while (!q.empty()) {
            int x = q.front();
            q.pop();
            for (int y : neighbors[x]) {
                if (dist[y] >= 0) {
                    continue;
                }
                q.push(y);
                dist[y] = dist[x] + 1;
            }
        }
        return dist[n - 1];
    }
};
```

```C
typedef struct Node {
    int val;
    struct Node *next;
} Node;

typedef struct List {
    Node *node;
} List;

void push(List *list, int val) {
    Node *node = (Node *)malloc(sizeof(Node));
    node->next = list->node;
    node->val = val;
    list->node = node;
}

void freeList(List *list) {
    for (Node *node = list->node; node != NULL;) {
        Node *tmp = node;
        node = node->next;
        free(tmp);
    }
}

int bfs(int n, List *neighbors) {
    int *dist = (int *)malloc(n * sizeof(int));
    memset(dist, 0xff, n * sizeof(int));
    dist[0] = 0;
    int *q = (int *)malloc(n * sizeof(int));
    int front = 0, back = 0;
    q[back++] = 0;
    while (front < back) {
        int x = q[front++];
        for (Node *node = neighbors[x].node; node != NULL; node = node->next) {
            if (dist[node->val] >= 0) {
                continue;
            }
            q[back++] = node->val;
            dist[node->val] = dist[x] + 1;
        }
    }
    int ret = dist[n - 1];
    free(dist);
    free(q);
    return ret;
}

int *shortestDistanceAfterQueries(int n, int **queries, int queriesSize, int *queriesColSize, int *returnSize) {
    List *neighbors = (List *)malloc(n * sizeof(List));
    memset(neighbors, 0, n * sizeof(List));
    for (int i = 0; i < n - 1; i++) {
        push(&neighbors[i], i + 1);
    }
    int* res = (int*)malloc(queriesSize * sizeof(int));
    *returnSize = queriesSize;
    for (int i = 0; i < queriesSize; i++) {
        push(&neighbors[queries[i][0]], queries[i][1]);
        res[i] = bfs(n, neighbors);
    }
    for (int i = 0; i < n; i++) {
        freeList(&neighbors[i]);
    }
    free(neighbors);
    return res;
}
```

```Go
func shortestDistanceAfterQueries(n int, queries [][]int) []int {
    neighbors := make([][]int, n)
    for i := 0; i < n - 1; i++ {
        neighbors[i] = append(neighbors[i], i + 1)
    }
    var res []int
    for _, query := range queries {
        neighbors[query[0]] = append(neighbors[query[0]], query[1])
        res = append(res, bfs(n, neighbors))
    }
    return res
}

func bfs(n int, neighbors [][]int) int {
    dist := make([]int, n)
    for i := 1; i < n; i++ {
        dist[i] = -1
    }
    q := []int{0}
    for len(q) > 0 {
        x := q[0]
        q = q[1:]
        for _, y := range neighbors[x] {
            if dist[y] >= 0 {
                continue
            }
            q = append(q, y)
            dist[y] = dist[x] + 1
        }
    }
    return dist[n - 1]
}
```

```Python
class Solution:
    def shortestDistanceAfterQueries(self, n: int, queries: List[List[int]]) -> List[int]:
        neighbors = [[i + 1] for i in range(n)]
        neighbors[-1] = []
        res = []
        for (u, v) in queries:
            neighbors[u].append(v)
            res.append(self.bfs(n, neighbors))
        return res

    def bfs(self, n: int, neighbors: List[List[int]]) -> int:
        dist = [-1 for _ in range(n)]
        dist[0] = 0
        q = deque([0])
        while len(q) > 0:
            x = q.popleft()
            for y in neighbors[x]:
                if dist[y] >= 0:
                    continue
                q.append(y)
                dist[y] = dist[x] + 1
        return dist[n - 1]
```

```Java
class Solution {
    public int[] shortestDistanceAfterQueries(int n, int[][] queries) {
        List<List<Integer>> neighbors = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            neighbors.add(new ArrayList<>());
        }
        for (int i = 0; i < n - 1; i++) {
            neighbors.get(i).add(i + 1);
        }
        int[] res = new int[queries.length];
        for (int i = 0; i < queries.length; i++) {
            neighbors.get(queries[i][0]).add(queries[i][1]);
            res[i] = bfs(n, neighbors);
        }
        return res;
    }
    private int bfs(int n, List<List<Integer>> neighbors) {
        int[] dist = new int[n];
        for (int i = 1; i < n; i++) {
            dist[i] = -1;
        }
        Queue<Integer> q = new LinkedList<>();
        q.add(0);
        while (!q.isEmpty()) {
            int x = q.poll();
            for (int y : neighbors.get(x)) {
                if (dist[y] >= 0) {
                    continue;
                }
                q.add(y);
                dist[y] = dist[x] + 1;
            }
        }
        return dist[n - 1];
    }
}
```

```CSharp
public class Solution {
    public int[] ShortestDistanceAfterQueries(int n, int[][] queries) {
        List<List<int>> neighbors = new List<List<int>>();
        for (int i = 0; i < n; i++) {
            neighbors.Add(new List<int>());
        }
        for (int i = 0; i < n - 1; i++) {
            neighbors[i].Add(i + 1);
        }
        int[] res = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            neighbors[queries[i][0]].Add(queries[i][1]);
            res[i] = Bfs(n, neighbors);
        }
        return res;
    }

    private int Bfs(int n, List<List<int>> neighbors) {
        int[] dist = new int[n];
        for (int i = 1; i < n; i++) {
            dist[i] = -1;
        }
        Queue<int> q = new Queue<int>();
        q.Enqueue(0);
        dist[0] = 0;
        while (q.Count > 0) {
            int x = q.Dequeue();
            foreach (int y in neighbors[x]) {
                if (dist[y] >= 0) {
                    continue;
                }
                q.Enqueue(y);
                dist[y] = dist[x] + 1;
            }
        }
        return dist[n - 1];
    }
}
```

```JavaScript
var shortestDistanceAfterQueries = function(n, queries) {
    let neighbors = new Array(n).fill().map(() => []);
    for (let i = 0; i < n - 1; i++) {
        neighbors[i].push(i + 1);
    }
    let res = [];
    for (let i = 0; i < queries.length; i++) {
        neighbors[queries[i][0]].push(queries[i][1]);
        res.push(bfs(n, neighbors));
    }
    return res;
};

var bfs = function(n, neighbors) {
    let dist = new Array(n).fill(-1);
    dist[0] = 0;
    let q = [0];
    while (q.length > 0) {
        let x = q.shift();
        for (let y of neighbors[x]) {
            if (dist[y] >= 0) {
                continue;
            }
            q.push(y);
            dist[y] = dist[x] + 1;
        }
    }
    return dist[n - 1];
};
```

```TypeScript
function shortestDistanceAfterQueries(n: number, queries: number[][]): number[] {
    let neighbors: number[][] = new Array(n).fill([]).map(() => []);
    for (let i = 0; i < n - 1; i++) {
        neighbors[i].push(i + 1);
    }
    let res = [];
    for (let i = 0; i < queries.length; i++) {
        neighbors[queries[i][0]].push(queries[i][1]);
        res.push(bfs(n, neighbors));
    }
    return res;
};

function bfs(n: number, neighbors: number[][]): number {
    let dist = new Array(n).fill(-1);
    dist[0] = 0;
    let q = [0];
    while (q.length > 0) {
        let x = q.shift();
        for (let y of neighbors[x]) {
            if (dist[y] >= 0) {
                continue;
            }
            q.push(y);
            dist[y] = dist[x] + 1;
        }
    }
    return dist[n - 1];
};
```

```Rust
use std::collections::VecDeque;

impl Solution {
    pub fn shortest_distance_after_queries(n: i32, queries: Vec<Vec<i32>>) -> Vec<i32> {
        let mut neighbors: Vec<Vec<i32>> = vec![Vec::new(); n as usize];
        for i in 0..n-1 {
            neighbors[i as usize].push(i + 1);
        }
        let mut res: Vec<i32> = Vec::new();
        for query in queries {
            neighbors[query[0] as usize].push(query[1]);
            res.push(Self::bfs(n as usize, &neighbors));
        }
        res
    }

    fn bfs(n: usize, neighbors: &Vec<Vec<i32>>) -> i32 {
        let mut dist = vec![-1; n];
        let mut q = VecDeque::new();
        q.push_back(0);
        dist[0] = 0;
        while let Some(x) = q.pop_front() {
            for &y in &neighbors[x] {
                if dist[y as usize] >= 0 {
                    continue;
                }
                q.push_back(y as usize);
                dist[y as usize] = dist[x] + 1;
            }
        }
        dist[n - 1]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(q \times (n+q))$，其中 $n$ 是城市数目，$q$ 是查询次数。每次广度优先搜索需要 $O(n+q)$，总共有 $q$ 次。
- 空间复杂度：$O(n+q)$。

#### 方法二：动态规划

根据题意，对于任一单向道路的起始点 $u$，终止点 $v$，都有 $u<v$，那么从城市 $0$ 到任一城市的路径上，所经过的城市编号是单调递增的。令 $dp[i]$ 表示城市 $0$ 到城市 $i$ 的最短路径，同时使用 $prev[i]$ 记录通往城市 $i$ 的所有单向道路的起始城市集合，那么对于 $i>0$，有 $dp[i]=\min_{j \in prev[i]​}dp[j]+1$。

根据以上推论，我们可以遍历 $queries$，在每次查询时，更新 $prev$ 数组，然后更新 $dp$ 数组。注意到，每次新建一条从城市 $u$ 到城市 $v$ 的单向道路时，只有 $i \ge v$ 的 $dp[i]$ 会发生变化，因此更新 $dp$ 可以从 $v$ 开始更新。

```C++
class Solution {
public:
    vector<int> shortestDistanceAfterQueries(int n, vector<vector<int>> &queries) {
        vector<vector<int>> prev(n);
        vector<int> dp(n);
        for (int i = 1; i < n; i++) {
            prev[i].push_back(i - 1);
            dp[i] = i;
        }
        vector<int> res;
        for (auto &query : queries) {
            prev[query[1]].push_back(query[0]);
            for (int v = query[1]; v < n; v++) {
                for (int u : prev[v]) {
                    dp[v] = min(dp[v], dp[u] + 1);
                }
            }
            res.push_back(dp[n - 1]);
        }
        return res;
    }
};
```

```C
typedef struct Node {
    int val;
    struct Node *next;
} Node;

typedef struct List {
    Node *node;
} List;

void push(List *list, int val) {
    Node *node = (Node *)malloc(sizeof(Node));
    node->next = list->node;
    node->val = val;
    list->node = node;
}

void freeList(List *list) {
    for (Node *node = list->node; node != NULL;) {
        Node *tmp = node;
        node = node->next;
        free(tmp);
    }
}

int *shortestDistanceAfterQueries(int n, int **queries, int queriesSize, int *queriesColSize, int *returnSize) {
    List *prev = (List *)malloc(n * sizeof(List));
    memset(prev, 0, n * sizeof(List));
    int *dp = (int *)malloc(n * sizeof(int));
    memset(dp, 0, n * sizeof(int));
    for (int i = 1; i < n; i++) {
        push(&prev[i], i - 1);
        dp[i] = i;
    }
    int *res = (int *)malloc(queriesSize * sizeof(int));
    for (int i = 0; i < queriesSize; i++) {
        push(&prev[queries[i][1]], queries[i][0]);
        for (int v = queries[i][1]; v < n; v++) {
            for (Node *node = prev[v].node; node != NULL; node = node->next) {
                dp[v] = fmin(dp[v], dp[node->val] + 1);
            }
        }
        res[i] = dp[n - 1];
    }
    for (int i = 0; i < n; i++) {
        freeList(&prev[i]);
    }
    free(prev);
    free(dp);
    *returnSize = queriesSize;
    return res;
}
```

```Go
func shortestDistanceAfterQueries(n int, queries [][]int) []int {
    prev := make([][]int, n)
    dp := make([]int, n)
    for i := 1; i < n; i++ {
        prev[i] = append(prev[i], i - 1)
        dp[i] = i
    }
    var res []int
    for _, query := range queries {
        prev[query[1]] = append(prev[query[1]], query[0])
        for v := query[1]; v < n; v++ {
            for _, u := range prev[v] {
                dp[v] = min(dp[v], dp[u] + 1)
            }
        }
        res = append(res, dp[n - 1])
    }
    return res
}
```

```Python
class Solution:
    def shortestDistanceAfterQueries(self, n: int, queries: List[List[int]]) -> List[int]:
        prev = [[i - 1] for i in range(n)]
        prev[0] = []
        dp = [i for i in range(n)]
        res = []
        for (x, y) in queries:
            prev[y].append(x)
            for v in range(y, n):
                for u in prev[v]:
                    dp[v] = min(dp[v], dp[u] + 1)
            res.append(dp[-1])
        return res
```

```Java
class Solution {
    public int[] shortestDistanceAfterQueries(int n, int[][] queries) {
        List<List<Integer>> prev = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            prev.add(new ArrayList<>());
        }
        int[] dp = new int[n];
        for (int i = 1; i < n; i++) {
            prev.get(i).add(i - 1);
            dp[i] = i;
        }
        int [] res = new int[queries.length];
        for (int i = 0; i < queries.length; i++) {
            prev.get(queries[i][1]).add(queries[i][0]);
            for (int v = queries[i][1]; v < n; v++) {
                for (int u : prev.get(v)) {
                    dp[v] = Math.min(dp[v], dp[u] + 1);
                }
            }
            res[i] = dp[n - 1];
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int[] ShortestDistanceAfterQueries(int n, int[][] queries) {
        List<List<int>> prev = new List<List<int>>(n);
        for (int i = 0; i < n; i++) {
            prev.Add(new List<int>());
        }
        int[] dp = new int[n];
        for (int i = 1; i < n; i++) {
            prev[i].Add(i - 1);
            dp[i] = i;
        }
        int[] res = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            prev[queries[i][1]].Add(queries[i][0]);
            for (int v = queries[i][1]; v < n; v++) {
                foreach (int u in prev[v]) {
                    dp[v] = Math.Min(dp[v], dp[u] + 1);
                }
            }
            res[i] = dp[n - 1];
        }
        return res;
    }
}
```

```JavaScript
var shortestDistanceAfterQueries = function(n, queries) {
    let prev = new Array(n).fill().map(() => []);
    for (let i = 1; i < n; i++) {
        prev[i].push(i - 1);
    }
    let dp = new Array(n).fill(0).map((_, i) => i);
    let res = new Array(queries.length);
    for (let i = 0; i < queries.length; i++) {
        prev[queries[i][1]].push(queries[i][0]);
        for (let v = queries[i][1]; v < n; v++) {
            for (let u of prev[v]) {
                dp[v] = Math.min(dp[v], dp[u] + 1);
            }
        }
        res[i] = dp[n - 1];
    }
    return res;
};
```

```TypeScript
function shortestDistanceAfterQueries(n: number, queries: number[][]): number[] {
    let prev: number[][] = new Array(n).fill([]).map(() => []);
    for (let i = 1; i < n; i++) {
        prev[i].push(i - 1);
    }
    let dp = new Array(n).fill(0).map((_, i) => i);
    let res = new Array(queries.length);
    for (let i = 0; i < queries.length; i++) {
        prev[queries[i][1]].push(queries[i][0]);
        for (let v = queries[i][1]; v < n; v++) {
            for (let u of prev[v]) {
                dp[v] = Math.min(dp[v], dp[u] + 1);
            }
        }
        res[i] = dp[n - 1];
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn shortest_distance_after_queries(n: i32, queries: Vec<Vec<i32>>) -> Vec<i32> {
        let mut prev: Vec<Vec<i32>> = vec![Vec::new(); n as usize];
        let mut dp: Vec<i32> = vec![0; n as usize];
        for i in 1..n {
            prev[i as usize].push(i - 1);
            dp[i as usize] = i;
        }
        let mut res: Vec<i32> = Vec::new();
        for query in queries {
            prev[query[1] as usize].push(query[0]);
            for v in query[1] as usize..n as usize {
                for &u in &prev[v] {
                    dp[v] = dp[v].min(dp[u as usize] + 1);
                }
            }
            res.push(dp[(n - 1) as usize]);
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(q \times (n+q))$，其中 $n$ 是城市数目，$q$ 是查询次数。
- 空间复杂度：$O(n+q)$。
