### [阈值距离内邻居最少的城市](https://leetcode.cn/problems/find-the-city-with-the-smallest-number-of-neighbors-at-a-threshold-distance/solutions/2524814/yu-zhi-ju-chi-nei-lin-ju-zui-shao-de-che-i73c/)

#### 概述

我们需要找到 $n$ 个节点中，拥有距离在 $distanceThreshold$ 以内的邻居数量最小、且编号最大的节点。

#### 方法一：Floyd 算法

**思路与算法**

我们可以求出每一个节点 $p$ 到其它节点的最短路，然后查看与 $p$ 距离在 $distanceThreshold$ 以内的邻居数量最小的节点。

我们可以使用 Floyd 算法得到任意两点之间的最短路，然后统计满足条件的邻居数量。

**代码**

```c++
class Solution {
public:
    int findTheCity(int n, vector<vector<int>> &edges, int distanceThreshold) {
        pair<int, int> ans(INT_MAX / 2, -1);
        vector<vector<int>> mp(n, vector<int>(n, INT_MAX / 2));
        for (auto &eg: edges) {
            int from = eg[0], to = eg[1], weight = eg[2];
            mp[from][to] = mp[to][from] = weight;
        }
        for (int k = 0; k < n; ++k) {
            mp[k][k] = 0;
            for (int i = 0; i < n; ++i) {
                for (int j = 0; j < n; ++j) {
                    mp[i][j] = min(mp[i][j], mp[i][k] + mp[k][j]);
                }
            }
        }
        for (int i = 0; i < n; ++i) {
            int cnt = 0;
            for (int j = 0; j < n; ++j) {
                if (mp[i][j] <= distanceThreshold) {
                    cnt++;
                }
            }
            if (cnt <= ans.first) {
                ans = {cnt, i};
            }
        }
        return ans.second;
    }
};
```

```java
class Solution {
    public int findTheCity(int n, int[][] edges, int distanceThreshold) {
        int[] ans = {Integer.MAX_VALUE / 2, -1};
        int[][] mp = new int[n][n];
        for (int i = 0; i < n; ++i) {
            Arrays.fill(mp[i], Integer.MAX_VALUE / 2);
        }
        for (int[] eg : edges) {
            int from = eg[0], to = eg[1], weight = eg[2];
            mp[from][to] = mp[to][from] = weight;
        }
        for (int k = 0; k < n; ++k) {
            mp[k][k] = 0;
            for (int i = 0; i < n; ++i) {
                for (int j = 0; j < n; ++j) {
                    mp[i][j] = Math.min(mp[i][j], mp[i][k] + mp[k][j]);
                }
            }
        }
        for (int i = 0; i < n; ++i) {
            int cnt = 0;
            for (int j = 0; j < n; ++j) {
                if (mp[i][j] <= distanceThreshold) {
                    cnt++;
                }
            }
            if (cnt <= ans[0]) {
                ans[0] = cnt;
                ans[1] = i;
            }
        }
        return ans[1];
    }
}
```

```csharp
public class Solution {
    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        int[] ans = {int.MaxValue / 2, -1};
        int[][] mp = new int[n][];
        for (int i = 0; i < n; ++i) {
            mp[i] = new int[n];
            Array.Fill(mp[i], int.MaxValue / 2);
        }
        foreach (int[] eg in edges) {
            int from = eg[0], to = eg[1], weight = eg[2];
            mp[from][to] = mp[to][from] = weight;
        }
        for (int k = 0; k < n; ++k) {
            mp[k][k] = 0;
            for (int i = 0; i < n; ++i) {
                for (int j = 0; j < n; ++j) {
                    mp[i][j] = Math.Min(mp[i][j], mp[i][k] + mp[k][j]);
                }
            }
        }
        for (int i = 0; i < n; ++i) {
            int cnt = 0;
            for (int j = 0; j < n; ++j) {
                if (mp[i][j] <= distanceThreshold) {
                    cnt++;
                }
            }
            if (cnt <= ans[0]) {
                ans[0] = cnt;
                ans[1] = i;
            }
        }
        return ans[1];
    }
}
```

```python
class Solution:
    def findTheCity(self, n: int, edges: List[List[int]], distanceThreshold: int) -> int:
        ans = (inf, -1)
        mp = [[inf] * n for _ in range(n)]

        for fr, to, weight in edges:
            mp[fr][to], mp[to][fr] = weight, weight
        for k in range(n):
            mp[k][k] = 0
            for i in range(n):
                for j in range(n):
                    mp[i][j] = min(mp[i][j], mp[i][k] + mp[k][j])
        for i in range(n):
            cnt = sum(mp[i][j] <= distanceThreshold for j in range(n))
            if cnt <= ans[0]:
                ans = (cnt, i)
        return ans[1]
```

```c
int findTheCity(int n, int** edges, int edgesSize, int* edgesColSize, int distanceThreshold) {
    int ans[2] = {INT_MAX >> 1, -1};
    int mp[n][n];
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            mp[i][j] = INT_MAX >> 1;
        }
    }
    
    for (int i = 0; i < edgesSize; i++) {
        int from = edges[i][0], to = edges[i][1], weight = edges[i][2];
        mp[from][to] = mp[to][from] = weight;
    }
    for (int k = 0; k < n; ++k) {
        mp[k][k] = 0;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                mp[i][j] = fmin(mp[i][j], mp[i][k] + mp[k][j]);
            }
        }
    }
    for (int i = 0; i < n; ++i) {
        int cnt = 0;
        for (int j = 0; j < n; ++j) {
            if (mp[i][j] <= distanceThreshold) {
                cnt++;
            }
        }
        if (cnt <= ans[0]) {
            ans[0] = cnt;
            ans[1] = i;
        }
    }
    return ans[1];
}
```

```go
func findTheCity(n int, edges [][]int, distanceThreshold int) int {
    ans := []int{math.MaxInt32 / 2, -1}
    mp := make([][]int, n)
    for i := 0; i < n; i++ {
        mp[i] = make([]int, n);
        for j := 0; j < n; j++ {
            mp[i][j] = math.MaxInt32 / 2
        }
    }
    
    for _, eg := range edges {
        from, to, weight := eg[0], eg[1], eg[2]
        mp[from][to], mp[to][from] = weight, weight
    }
    for k := 0; k < n; k++ {
        mp[k][k] = 0;
        for i := 0; i < n; i++ {
            for j := 0; j < n; j++ {
                mp[i][j] = min(mp[i][j], mp[i][k] + mp[k][j])
            }
        }
    }
    for i := 0; i < n; i++ {
        cnt := 0
        for j := 0; j < n; j++ {
            if mp[i][j] <= distanceThreshold {
                cnt++
            }
        }
        if cnt <= ans[0] {
            ans[0], ans[1] = cnt, i
        }
    }
    return ans[1]
}
```

```javascript
var findTheCity = function(n, edges, distanceThreshold) {
    let ans = [Infinity, -1]
    const mp = new Array(n).fill(0).map(() => new Array(n).fill(Infinity));

    for (const [from, to, weight] of edges) {
        mp[from][to] = mp[to][from] = weight;
    }
    for (let k = 0; k < n; k++) {
        mp[k][k] = 0;
        for (let i = 0; i < n; i++) {
            for (let j = 0; j < n; j++) {
                mp[i][j] = Math.min(mp[i][j], mp[i][k] + mp[k][j]);
            }
        }
    }
    for (let i = 0; i < n; i++) {
        let cnt = 0;
        for (let j = 0; j < n; j++) {
            if (mp[i][j] <= distanceThreshold) {
                cnt++;
            }
        }
        if (cnt <= ans[0]) {
            ans = [cnt, i];
        }
    }
    return ans[1];
};
```

**复杂度分析**

- 时间复杂度：$O(n^3)$。Floyd 算法使用每一个节点对任意两个节点进行松弛操作。
- 空间复杂度：$O(n^2)$。使用邻接矩阵存储任意两点之间的距离。

#### 方法二：Dijkstra 算法

**思路与算法**

我们可以对每一个节点求解**单源最短路**，即某一个节点到其它所有节点的最短距离。

朴素的 Dijkstra 算法不断使用距离最近的节点来松弛到其它节点的距离。

**代码**

```c++
class Solution {
public:
    int findTheCity(int n, vector<vector<int>> &edges, int distanceThreshold) {
        pair<int, int> ans(INT_MAX / 2, -1);
        vector<vector<int>> dis(n, vector<int>(n, INT_MAX / 2));
        vector<vector<int>> vis(n, vector<int>(n, false));
        vector<vector<int>> mp(n, vector<int>(n, INT_MAX / 2));
        for (auto &eg: edges) {
            int from = eg[0], to = eg[1], weight = eg[2];
            mp[from][to] = mp[to][from] = weight;
        }
        for (int i = 0; i < n; ++i) {
            dis[i][i] = 0;
            for (int j = 0; j < n; ++j) {
                int t = -1;
                for (int k = 0; k < n; ++k) {
                    if (!vis[i][k] && (t == -1 || dis[i][k] < dis[i][t])) {
                        t = k;
                    }
                }
                for (int k = 0; k < n; ++k) {
                    dis[i][k] = min(dis[i][k], dis[i][t] + mp[t][k]);
                }
                vis[i][t] = true;
            }
        }
        for (int i = 0; i < n; ++i) {
            int cnt = 0;
            for (int j = 0; j < n; ++j) {
                if (dis[i][j] <= distanceThreshold) {
                    cnt++;
                }
            }
            if (cnt <= ans.first) {
                ans = {cnt, i};
            }
        }
        return ans.second;
    }
};
```

```java
class Solution {
    public int findTheCity(int n, int[][] edges, int distanceThreshold) {
        int[] ans = {Integer.MAX_VALUE / 2, -1};
        int[][] dis = new int[n][n];
        boolean[][] vis = new boolean[n][n];
        int[][] mp = new int[n][n];
        for (int i = 0; i < n; ++i) {
            Arrays.fill(dis[i], Integer.MAX_VALUE / 2);
            Arrays.fill(mp[i], Integer.MAX_VALUE / 2);
        }
        for (int[] eg : edges) {
            int from = eg[0], to = eg[1], weight = eg[2];
            mp[from][to] = mp[to][from] = weight;
        }
        for (int i = 0; i < n; ++i) {
            dis[i][i] = 0;
            for (int j = 0; j < n; ++j) {
                int t = -1;
                for (int k = 0; k < n; ++k) {
                    if (!vis[i][k] && (t == -1 || dis[i][k] < dis[i][t])) {
                        t = k;
                    }
                }
                for (int k = 0; k < n; ++k) {
                    dis[i][k] = Math.min(dis[i][k], dis[i][t] + mp[t][k]);
                }
                vis[i][t] = true;
            }
        }
        for (int i = 0; i < n; ++i) {
            int cnt = 0;
            for (int j = 0; j < n; ++j) {
                if (dis[i][j] <= distanceThreshold) {
                    cnt++;
                }
            }
            if (cnt <= ans[0]) {
                ans[0] = cnt;
                ans[1] = i;
            }
        }
        return ans[1];
    }
}
```

```csharp
public class Solution {
    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        int[] ans = {int.MaxValue / 2, -1};
        int[][] dis = new int[n][];
        bool[][] vis = new bool[n][];
        int[][] mp = new int[n][];
        for (int i = 0; i < n; ++i) {
            dis[i] = new int[n];
            vis[i] = new bool[n];
            mp[i] = new int[n];
            Array.Fill(dis[i], int.MaxValue / 2);
            Array.Fill(mp[i], int.MaxValue / 2);
        }
        foreach (int[] eg in edges) {
            int from = eg[0], to = eg[1], weight = eg[2];
            mp[from][to] = mp[to][from] = weight;
        }
        for (int i = 0; i < n; ++i) {
            dis[i][i] = 0;
            for (int j = 0; j < n; ++j) {
                int t = -1;
                for (int k = 0; k < n; ++k) {
                    if (!vis[i][k] && (t == -1 || dis[i][k] < dis[i][t])) {
                        t = k;
                    }
                }
                for (int k = 0; k < n; ++k) {
                    dis[i][k] = Math.Min(dis[i][k], dis[i][t] + mp[t][k]);
                }
                vis[i][t] = true;
            }
        }
        for (int i = 0; i < n; ++i) {
            int cnt = 0;
            for (int j = 0; j < n; ++j) {
                if (dis[i][j] <= distanceThreshold) {
                    cnt++;
                }
            }
            if (cnt <= ans[0]) {
                ans[0] = cnt;
                ans[1] = i;
            }
        }
        return ans[1];
    }
}
```

```python
class Solution:
    def findTheCity(self, n: int, edges: List[List[int]], distanceThreshold: int) -> int:
        ans = (inf, -1)
        mp = [[inf] * n for _ in range(n)]
        dis = [[inf] * n for _ in range(n)]
        vis = [[False] * n for _ in range(n)]
        
        for fr, to, weight in edges:
            mp[fr][to], mp[to][fr] = weight, weight

        for k in range(n):
            mp[k][k] = 0
            for i in range(n):
                for j in range(n):
                    mp[i][j] = min(mp[i][j], mp[i][k] + mp[k][j])
        for i in range(n):
            dis[i][i] = 0
            for j in range(n):
                t = -1
                for k in range(n):
                    if not vis[i][k] and (t == -1 or dis[i][k] < dis[i][t]):
                        t = k
                for k in range(n):
                    dis[i][k] = min(dis[i][k], dis[i][t] + mp[t][k])
                vis[i][t] = True
        for i in range(n):
            cnt = sum(dis[i][j] <= distanceThreshold for j in range(n))
            if cnt <= ans[0]:
                ans = (cnt, i)
        return ans[1]
```

```c
int findTheCity(int n, int** edges, int edgesSize, int* edgesColSize, int distanceThreshold) {
    int ans[2] = {INT_MAX / 2, -1};
    int dis[n][n], vis[n][n], mp[n][n];
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            dis[i][j] = mp[i][j] = INT_MAX / 2;
            vis[i][j] = false;
        }
    }

    for (int i = 0; i < edgesSize; i++) {
        int from = edges[i][0], to = edges[i][1], weight = edges[i][2];
        mp[from][to] = mp[to][from] = weight;
    }
    for (int i = 0; i < n; ++i) {
        dis[i][i] = 0;
        for (int j = 0; j < n; ++j) {
            int t = -1;
            for (int k = 0; k < n; ++k) {
                if (!vis[i][k] && (t == -1 || dis[i][k] < dis[i][t])) {
                    t = k;
                }
            }
            for (int k = 0; k < n; ++k) {
                dis[i][k] = fmin(dis[i][k], dis[i][t] + mp[t][k]);
            }
            vis[i][t] = true;
        }
    }
    for (int i = 0; i < n; ++i) {
        int cnt = 0;
        for (int j = 0; j < n; ++j) {
            if (dis[i][j] <= distanceThreshold) {
                cnt++;
            }
        }
        if (cnt <= ans[0]) {
            ans[0] = cnt;
            ans[1] = i;
        }
    }
    return ans[1];
}
```

```go
func findTheCity(n int, edges [][]int, distanceThreshold int) int {
    ans := []int{math.MaxInt32 / 2, -1}
    mp := make([][]int, n)
    dis := make([][]int, n)
    vis := make([][]bool, n)
    for i := 0; i < n; i++ {
        mp[i] = make([]int, n);
        dis[i] = make([]int, n);
        vis[i] = make([]bool, n);
        for j := 0; j < n; j++ {
            mp[i][j] = math.MaxInt32 / 2
            dis[i][j] = math.MaxInt32 / 2
            vis[i][j] = false
        }
    }
    
    for _, eg := range edges {
        from, to, weight := eg[0], eg[1], eg[2]
        mp[from][to], mp[to][from] = weight, weight
    }
    for i := 0; i < n; i++ {
        dis[i][i] = 0
        for j := 0; j < n; j++ {
            t := -1
            for k := 0; k < n; k++ {
                if !vis[i][k] && (t == -1 || dis[i][k] < dis[i][t]) {
                    t = k
                }
            }
            for k := 0; k < n; k++ {
                dis[i][k] = min(dis[i][k], dis[i][t] + mp[t][k])
            }
            vis[i][t] = true
        }
    }
    for i := 0; i < n; i++ {
        cnt := 0
        for j := 0; j < n; j++ {
            if dis[i][j] <= distanceThreshold {
                cnt++
            }
        }
        if cnt <= ans[0] {
            ans[0] = cnt
            ans[1] = i
        }
    }
    return ans[1]
}
```

```javascript
var findTheCity = function(n, edges, distanceThreshold) {
    let ans = [Infinity, -1];
    const dis = new Array(n).fill(0).map(() => new Array(n).fill(Infinity)); 
    const mp = new Array(n).fill(0).map(() => new Array(n).fill(Infinity)); 
    const vis = new Array(n).fill(0).map(() => new Array(n).fill(false)); 

    for (const [from, to, weight] of edges) {
        mp[from][to] = mp[to][from] = weight;
    }
    for (let i = 0; i < n; i++) {
        dis[i][i] = 0;
        for (let j = 0; j < n; j++) {
            let t = -1;
            for (let k = 0; k < n; ++k) {
                if (!vis[i][k] && (t == -1 || dis[i][k] < dis[i][t])) {
                    t = k;
                }
            }
            for (let k = 0; k < n; ++k) {
                dis[i][k] = Math.min(dis[i][k], dis[i][t] + mp[t][k]);
            }
            vis[i][t] = true;
        }
    }
    for (let i = 0; i < n; i++) {
        let cnt = 0;
        for (let j = 0; j < n; j++) {
            if (dis[i][j] <= distanceThreshold) {
                cnt++;
            }
        }
        if (cnt <= ans[0]) {
            ans = [cnt, i];
        }
    }
    return ans[1];
};
```

**复杂度分析**

- 时间复杂度：$O(n^3)$。对图中的每一个节点执行 Dijkstra 算法。Dijkstra 算法使用每一个顶点对当前节点到其它节点之间的距离进行松弛。
- 空间复杂度：$O(n^2)$。使用邻接矩阵存储任意两点之间的距离。
