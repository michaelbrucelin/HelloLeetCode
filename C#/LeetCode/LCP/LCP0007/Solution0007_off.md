### [传递信息](https://leetcode.cn/problems/chuan-di-xin-xi/solutions/212912/chuan-di-xin-xi-by-leetcode-solution/)

#### 方法一：深度优先搜索

可以把传信息的关系看成有向图，每个玩家对应一个节点，每个传信息的关系对应一条有向边。如果 $x$ 可以向 $y$ 传信息，则对应从节点 $x$ 到节点 $y$ 的一条**有向**边。寻找从编号 $0$ 的玩家经过 $k$ 轮传递到编号 $n-1$ 的玩家处的方案数，等价于在有向图中寻找从节点 $0$ 到节点 $n-1$ 的长度为 $k$ 的路径数，同一条路径可以重复经过同一个节点。

可以使用深度优先搜索计算方案数。从节点 $0$ 出发做深度优先搜索，每一步记录当前所在的节点以及经过的轮数，当经过 $k$ 轮时，如果位于节点 $n-1$，则将方案数加 $1$。搜索结束之后，即可得到总的方案数。

具体实现方面，可以对传信息的关系进行预处理，使用列表存储有向边的关系，即可在 $O(1)$ 的时间内得到特定节点的相邻节点（即可以沿着有向边一步到达的节点）。

```java
class Solution {
    int ways, n, k;
    List<List<Integer>> edges;

    public int numWays(int n, int[][] relation, int k) {
        ways = 0;
        this.n = n;
        this.k = k;
        edges = new ArrayList<List<Integer>>();
        for (int i = 0; i < n; i++) {
            edges.add(new ArrayList<Integer>());
        }
        for (int[] edge : relation) {
            int src = edge[0], dst = edge[1];
            edges.get(src).add(dst);
        }
        dfs(0, 0);
        return ways;
    }

    public void dfs(int index, int steps) {
        if (steps == k) {
            if (index == n - 1) {
                ways++;
            }
            return;
        }
        List<Integer> list = edges.get(index);
        for (int nextIndex : list) {
            dfs(nextIndex, steps + 1);
        }
    }
}
```

```csharp
public class Solution {
    int ways, n, k;
    IList<IList<int>> edges;

    public int NumWays(int n, int[][] relation, int k) {
        ways = 0;
        this.n = n;
        this.k = k;
        edges = new List<IList<int>>();
        for (int i = 0; i < n; i++) {
            edges.Add(new List<int>());
        }
        foreach (int[] edge in relation) {
            int src = edge[0], dst = edge[1];
            edges[src].Add(dst);
        }
        DFS(0, 0);
        return ways;
    }

    public void DFS(int index, int steps) {
        if (steps == k) {
            if (index == n - 1) {
                ways++;
            }
            return;
        }
        IList<int> list = edges[index];
        foreach (int nextIndex in list) {
            DFS(nextIndex, steps + 1);
        }
    }
}
```

```c++
class Solution {
public:
    int numWays(int n, vector<vector<int>> &relation, int k) {
        vector<vector<int>> edges(n);
        for (auto &edge : relation) {
            int src = edge[0], dst = edge[1];
            edges[src].push_back(dst);
        }

        int ways = 0;
        function<void(int, int)> dfs = [&](int index, int steps) {
            if (steps == k) {
                if (index == n - 1) {
                    ++ways;
                }
                return;
            }
            for (int to : edges[index]) {
                dfs(to, steps + 1);
            }
        };
        dfs(0, 0);
        return ways;
    }
};
```

```javascript
var numWays = function(n, relation, k) {
    let ways = 0;
    const edges = new Array(n).fill(0).map(() => new Array());

    for (const [src, dst] of relation) {
        edges[src].push(dst);
    }

    const dfs = (index, steps) => {
        if (steps === k) {
            if (index === n - 1) {
                ways++;
            }
            return;
        }
        const list = edges[index];
        for (const nextIndex of list) {
            dfs(nextIndex, steps + 1);
        }
    }
    
    dfs(0, 0);
    return ways;
}
```

```go
func numWays(n int, relation [][]int, k int) (ans int) {
    edges := make([][]int, n)
    for _, r := range relation {
        src, dst := r[0], r[1]
        edges[src] = append(edges[src], dst)
    }
    var dfs func(int, int)
    dfs = func(x, step int) {
        if step == k {
            if x == n-1 {
                ans++
            }
            return
        }
        for _, y := range edges[x] {
            dfs(y, step+1)
        }
    }
    dfs(0, 0)
    return
}
```

```python
class Solution:
    def numWays(self, n: int, relation: List[int], k: int) -> int:
        self.ways, self.n, self.k = 0, n, k
        self.edges = collections.defaultdict(list)
        for src, dst in relation:
            self.edges[src].append(dst)

        self.dfs(0,0)
        return self.ways 

    def dfs(self, index, steps):
        if steps == self.k:
            if index == self.n-1:
                self.ways += 1
            return
        for to in self.edges[index]:
            self.dfs(to, steps+1)
```

#### 复杂度分析

- 时间复杂度：$O(n^k)$。最多需要遍历 $k$ 层，每层遍历最多有 $O(n)$ 个分支。
- 空间复杂度：$O(n+m+k)$。其中 $m$ 为 $\textit{relation}$ 数组的长度。空间复杂度主要取决于图的大小和递归调用栈的深度，保存有向图信息所需空间为 $O(n+m)$，递归调用栈的深度不会超过 $k$。

#### 方法二：广度优先搜索

也可以使用广度优先搜索计算方案数。从节点 $0$ 出发做广度优先搜索，当遍历到 $k$ 层时，如果位于节点 $n-1$，则将方案数加 $1$。搜索结束之后，即可得到总的方案数。

```java
class Solution {
    public int numWays(int n, int[][] relation, int k) {
        List<List<Integer>> edges = new ArrayList<List<Integer>>();
        for (int i = 0; i < n; i++) {
            edges.add(new ArrayList<Integer>());
        }
        for (int[] edge : relation) {
            int src = edge[0], dst = edge[1];
            edges.get(src).add(dst);
        }

        int steps = 0;
        Queue<Integer> queue = new LinkedList<Integer>();
        queue.offer(0);
        while (!queue.isEmpty() && steps < k) {
            steps++;
            int size = queue.size();
            for (int i = 0; i < size; i++) {
                int index = queue.poll();
                List<Integer> list = edges.get(index);
                for (int nextIndex : list) {
                    queue.offer(nextIndex);
                }
            }
        }

        int ways = 0;
        if (steps == k) {
            while (!queue.isEmpty()) {
                if (queue.poll() == n - 1) {
                    ways++;
                }
            }
        }
        return ways;
    }
}
```

```csharp
public class Solution {
    public int NumWays(int n, int[][] relation, int k) {
        IList<IList<int>> edges = new List<IList<int>>();
        for (int i = 0; i < n; i++) {
            edges.Add(new List<int>());
        }
        foreach (int[] edge in relation) {
            int src = edge[0], dst = edge[1];
            edges[src].Add(dst);
        }

        int steps = 0;
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(0);
        while (queue.Count > 0 && steps < k) {
            steps++;
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                int index = queue.Dequeue();
                IList<int> list = edges[index];
                foreach (int nextIndex in list) {
                    queue.Enqueue(nextIndex);
                }
            }
        }

        int ways = 0;
        if (steps == k) {
            while (queue.Count > 0) {
                if (queue.Dequeue() == n - 1) {
                    ways++;
                }
            }
        }
        return ways;
    }
}
```

```c++
class Solution {
public:
    int numWays(int n, vector<vector<int>> &relation, int k) {
        vector<vector<int>> edges(n);
        for (auto &edge : relation) {
            int src = edge[0], dst = edge[1];
            edges[src].push_back(dst);
        }

        int steps = 0;
        queue<int> que;
        que.push(0);
        while (!que.empty() && steps < k) {
            steps++;
            int size = que.size();
            for (int i = 0; i < size; i++) {
                int index = que.front();
                que.pop();
                for (auto &nextIndex : edges[index]) {
                    que.push(nextIndex);
                }
            }
        }

        int ways = 0;
        if (steps == k) {
            while (!que.empty()) {
                if (que.front() == n - 1) {
                    ways++;
                }
                que.pop();
            }
        }
        return ways;
    }
};
```

```javascript
var numWays = function(n, relation, k) {
    const edges = new Array(n).fill(0).map(() => new Array());
    for (const[src, dst] of relation) {
        edges[src].push(dst);
    }

    let steps = 0;
    const queue = [0];
    while (queue.length && steps < k) {
        steps++;
        const size = queue.length;
        for (let i = 0; i < size; i++) {
            const index = queue.shift();
            const list = edges[index];
            for (const nextIndex of list) {
                queue.push(nextIndex);
            }
        }
    }

    let ways = 0;
    if (steps === k) {
        while (queue.length) {
            if (queue.shift() === n - 1) {
                ways++;
            }
        }
    }
    return ways;
};
```

```go
func numWays(n int, relation [][]int, k int) (ans int) {
    edges := make([][]int, n)
    for _, r := range relation {
        src, dst := r[0], r[1]
        edges[src] = append(edges[src], dst)
    }

    step := 0
    q := []int{0}
    for ; len(q) > 0 && step < k; step++ {
        tmp := q
        q = nil
        for _, x := range tmp {
            for _, y := range edges[x] {
                q = append(q, y)
            }
        }
    }

    if step == k {
        for _, x := range q {
            if x == n-1 {
                ans++
            }
        }
    }
    return
}
```

```python
class Solution:
    def numWays(self, n: int, relation: List[int], k: int) -> int:
        edges = collections.defaultdict(list)
        for edge in relation:
            src = edge[0] 
            dst = edge[1]
            edges[src].append(dst)
        steps = 0
        queue = collections.deque([0])
        while queue and steps < k:
            steps += 1
            size = len(queue)
            for i in range(size):
                index = queue.popleft()
                to = edges[index]
                for nextIndex in to:
                    queue.append(nextIndex)
        ways = 0
        if steps == k:
            while queue:
                if queue.popleft() == n - 1:
                    ways += 1    
        return ways 
```

#### 复杂度分析

- 时间复杂度：$O(n^k)$。最多需要遍历 $k$ 层，每层遍历最多有 $O(n)$ 个分支。
- 空间复杂度：$O(n+m+n^k)$。其中 $m$ 为 $\textit{relation}$ 数组的长度。空间复杂度主要取决于图的大小和队列的大小，保存有向图信息所需空间为 $O(n+m)$，由于每层遍历最多有 $O(n)$ 个分支，因此遍历到 $k$ 层时，队列的大小为 $O(n^k)$。

#### 方法三：动态规划

前两种方法都是通过在图中搜索计算方案数。可以换一个思路，这道题是计数问题，可以使用动态规划的方法解决。

定义动态规划的状态 $\textit{dp}[i][j]$ 为经过 $i$ 轮传递到编号 $j$ 的玩家的方案数，其中 $0 \le i \le k$，$0 \le j < n$。

由于从编号 $0$ 的玩家开始传递，当 $i=0$ 时，一定位于编号 $0$ 的玩家，不会传递到其他玩家，因此动态规划的边界情况如下：

$$\textit{dp}[0][j]= \begin{cases} 1, & j=0 \\ 0, & j \ne 0 \end{cases}$$

对于传信息的关系 $[\textit{src},\textit{dst}]$，如果第 $i$ 轮传递到编号 $\textit{src}$ 的玩家，则第 $i+1$ 轮可以从编号 $\textit{src}$ 的玩家传递到编号 $\textit{dst}$ 的玩家。因此在计算 $\textit{dp}[i+1][\textit{dst}]$ 时，需要考虑可以传递到编号 $\textit{dst}$ 的所有玩家。由此可以得到动态规划的状态转移方程，其中 $0 \le i < k$：

$$\textit{dp}[i+1][\textit{dst}]=\sum_{[\textit{src},\textit{dst}] \in \textit{relation}} \textit{dp}[i][\textit{src}]$$

最终得到 $\textit{dp}[k][n-1]$ 即为总的方案数。

```java
class Solution {
    public int numWays(int n, int[][] relation, int k) {
        int[][] dp = new int[k + 1][n];
        dp[0][0] = 1;
        for (int i = 0; i < k; i++) {
            for (int[] edge : relation) {
                int src = edge[0], dst = edge[1];
                dp[i + 1][dst] += dp[i][src];
            }
        }
        return dp[k][n - 1];
    }
}
```

```csharp
public class Solution {
    public int NumWays(int n, int[][] relation, int k) {
        int[,] dp = new int[k + 1, n];
        dp[0, 0] = 1;
        for (int i = 0; i < k; i++) {
            foreach (int[] edge in relation) {
                int src = edge[0], dst = edge[1];
                dp[i + 1, dst] += dp[i, src];
            }
        }
        return dp[k, n - 1];
    }
}
```

```c++
class Solution {
public:
    int numWays(int n, vector<vector<int>>& relation, int k) {
        vector<vector<int>> dp(k + 1, vector<int>(n));
        dp[0][0] = 1;
        for (int i = 0; i < k; i++) {
            for (auto& edge : relation) {
                int src = edge[0], dst = edge[1];
                dp[i + 1][dst] += dp[i][src];
            }
        }
        return dp[k][n - 1];
    }
};
```

```c
int numWays(int n, int** relation, int relationSize, int* relationColSize, int k) {
    int dp[k + 1][n];
    memset(dp, 0, sizeof(dp));
    dp[0][0] = 1;
    for (int i = 0; i < k; i++) {
        for (int j = 0; j < relationSize; j++) {
            int src = relation[j][0], dst = relation[j][1];
            dp[i + 1][dst] += dp[i][src];
        }
    }
    return dp[k][n - 1];
}
```

```javascript
var numWays = function(n, relation, k) {
    const dp = new Array(k + 1).fill(0).map(() => new Array(n).fill(0));
    dp[0][0] = 1;
    for (let i = 0; i < k; i++) {
        for (const [src, dst] of relation) {
            dp[i + 1][dst] += dp[i][src];
        }
    }
    return dp[k][n - 1];
};
```

```go
func numWays(n int, relation [][]int, k int) int {
    dp := make([][]int, k+1)
    for i := range dp {
        dp[i] = make([]int, n)
    }
    dp[0][0] = 1
    for i := 0; i < k; i++ {
        for _, r := range relation {
            src, dst := r[0], r[1]
            dp[i+1][dst] += dp[i][src]
        }
    }
    return dp[k][n-1]
}
```

```python
class Solution:
    def numWays(self, n: int, relation: List[List[int]], k: int) -> int:
        dp = [[0] * (n + 1) for _ in range(k + 1)]
        dp[0][0] = 1
        for i in range(k):
            for edge in relation:
                src = edge[0]
                dst = edge[1]
                dp[i + 1][dst] += dp[i][src]
        return dp[k][n - 1]
```

上述实现的空间复杂度是 $O(kn)$。由于当 $i>0$ 时，$\textit{dp}[i][]$ 的值只和 $\textit{dp}[i-1][]$ 的值有关，因此可以将二维数组变成一维数组，将空间复杂度优化到 $O(n)$。

```java
class Solution {
    public int numWays(int n, int[][] relation, int k) {
        int[] dp = new int[n];
        dp[0] = 1;
        for (int i = 0; i < k; i++) {
            int[] next = new int[n];
            for (int[] edge : relation) {
                int src = edge[0], dst = edge[1];
                next[dst] += dp[src];
            }
            dp = next;
        }
        return dp[n - 1];
    }
}
```

```csharp
public class Solution {
    public int NumWays(int n, int[][] relation, int k) {
        int[] dp = new int[n];
        dp[0] = 1;
        for (int i = 0; i < k; i++) {
            int[] next = new int[n];
            foreach (int[] edge in relation) {
                int src = edge[0], dst = edge[1];
                next[dst] += dp[src];
            }
            dp = next;
        }
        return dp[n - 1];
    }
}
```

```c++
class Solution {
public:
    int numWays(int n, vector<vector<int>>& relation, int k) {
        vector<int> dp(n);
        dp[0] = 1;
        for (int i = 0; i < k; i++) {
            vector<int> next(n);
            for (auto& edge : relation) {
                int src = edge[0], dst = edge[1];
                next[dst] += dp[src];
            }
            dp = next;
        }
        return dp[n - 1];
    }
};
```

```c
int numWays(int n, int** relation, int relationSize, int* relationColSize, int k) {
    int dp[n];
    memset(dp, 0, sizeof(dp));
    dp[0] = 1;
    for (int i = 0; i < k; i++) {
        int next[n];
        memset(next, 0, sizeof(next));
        for (int j = 0; j < relationSize; j++) {
            int src = relation[j][0], dst = relation[j][1];
            next[dst] += dp[src];
        }
        memcpy(dp, next, sizeof(int) * n);
    }
    return dp[n - 1];
}
```

```javascript
var numWays = function(n, relation, k) {
    let dp = new Array(n).fill(0);
    dp[0] = 1;
    for (let i = 0; i < k; i++) {
        const next = new Array(n).fill(0);
        for (const [src, dst] of relation) {
            next[dst] += dp[src];
        }
        dp = next;
    }
    return dp[n - 1];
};
```

```go
func numWays(n int, relation [][]int, k int) int {
    dp := make([]int, n)
    dp[0] = 1
    for i := 0; i < k; i++ {
        next := make([]int, n)
        for _, r := range relation {
            src, dst := r[0], r[1]
            next[dst] += dp[src]
        }
        dp = next
    }
    return dp[n-1]
}
```

```python
class Solution:
    def numWays(self, n: int, relation: List[List[int]], k: int) -> int:
        dp = [0 for _ in range(n + 1)]
        dp[0] = 1
        for i in range(k):
            next = [0 for _ in range(n + 1)]
            for edge in relation:
                src = edge[0]
                dst = edge[1]
                next[dst] += dp[src]
            dp = next
        return dp[n - 1]
```

#### 复杂度分析

- 时间复杂度：$O(km)$。其中 $m$ 为 $\textit{relation}$ 数组的长度。
- 空间复杂度：$O(n)$。
