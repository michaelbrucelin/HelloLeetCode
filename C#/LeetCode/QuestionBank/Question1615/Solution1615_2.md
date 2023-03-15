#### [方法一：枚举](https://leetcode.cn/problems/maximal-network-rank/solutions/2167846/zui-da-wang-luo-zhi-by-leetcode-solution-x4gx/)

**思路与算法**

根据题意可知，两座不同城市构成的城市对的网络秩定义为：与这两座城市直接相连的道路总数，这两座城市之间的道路只计算一次。假设城市 $x$ 的度数为 $degree[x]$，则此时我们可以知道城市对 $(i,j)$ 的网络秩为如下：

-   如果 $i$ 与 $j$ 之间没有道路连接，则此时 $(i,j)$ 的网络秩为 $degree[i] + degree[j]$；
-   如果 $i$ 与 $j$ 之间存在道路连接，则此时 $(i,j)$ 的网络秩为 $degree[i] + degree[j] - 1$；

根据以上求网络秩的方法，我们首先求出所有城市在图中的度数，然后枚举所有可能的城市对 $(i,j)$，求出城市对 $(i,j)$ 的网络秩，即可找到最大的网络秩。

**代码**

```python
class Solution:
    def maximalNetworkRank(self, n: int, roads: List[List[int]]) -> int:
        connect = [[False] * n for _ in range(n)]
        degree = [0] * n
        for a, b in roads:
            connect[a][b] = True
            connect[b][a] = True
            degree[a] += 1
            degree[b] += 1

        maxRank = 0
        for i in range(n):
            for j in range(i + 1, n):
                rank = degree[i] + degree[j] - connect[i][j]
                maxRank = max(maxRank, rank)
        return maxRank
```

```cpp
class Solution {
public:
    int maximalNetworkRank(int n, vector<vector<int>>& roads) {
        vector<vector<bool>> connect(n, vector<bool>(n, false));
        vector<int> degree(n, 0);
        for (auto v : roads) {
            connect[v[0]][v[1]] = true;
            connect[v[1]][v[0]] = true;
            degree[v[0]]++;
            degree[v[1]]++;
        }

        int maxRank = 0;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int rank = degree[i] + degree[j] - (connect[i][j] ? 1 : 0);
                maxRank = max(maxRank, rank);
            }
        }
        return maxRank;
    }
};
```

```java
class Solution {
    public int maximalNetworkRank(int n, int[][] roads) {
        boolean[][] connect = new boolean[n][n];
        int[] degree = new int[n];
        for (int[] v : roads) {
            connect[v[0]][v[1]] = true;
            connect[v[1]][v[0]] = true;
            degree[v[0]]++;
            degree[v[1]]++;
        }

        int maxRank = 0;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int rank = degree[i] + degree[j] - (connect[i][j] ? 1 : 0);
                maxRank = Math.max(maxRank, rank);
            }
        }
        return maxRank;
    }
}
```

```csharp
public class Solution {
    public int MaximalNetworkRank(int n, int[][] roads) {
        bool[][] connect = new bool[n][];
        for (int i = 0; i < n; i++) {
            connect[i] = new bool[n];
        }
        int[] degree = new int[n];
        foreach (int[] v in roads) {
            connect[v[0]][v[1]] = true;
            connect[v[1]][v[0]] = true;
            degree[v[0]]++;
            degree[v[1]]++;
        }

        int maxRank = 0;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int rank = degree[i] + degree[j] - (connect[i][j] ? 1 : 0);
                maxRank = Math.Max(maxRank, rank);
            }
        }
        return maxRank;
    }
}
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int maximalNetworkRank(int n, int** roads, int roadsSize, int* roadsColSize) {
    bool connect[n][n];
    int degree[n];
    memset(connect, 0, sizeof(connect));
    memset(degree, 0, sizeof(degree));
    for (int i = 0; i < roadsSize; i++) {
        int x = roads[i][0], y = roads[i][1];
        connect[x][y] = true;
        connect[y][x] = true;
        degree[x]++;
        degree[y]++;
    }

    int maxRank = 0;
    for (int i = 0; i < n; i++) {
        for (int j = i + 1; j < n; j++) {
            int rank = degree[i] + degree[j] - (connect[i][j] ? 1 : 0);
            maxRank = MAX(maxRank, rank);
        }
    }
    return maxRank;
}
```

```javascript
var maximalNetworkRank = function(n, roads) {
    const connect = new Array(n).fill(0).map(() => new Array(n).fill(0));
    const degree = new Array(n).fill(0);
    for (const v of roads) {
        connect[v[0]][v[1]] = true;
        connect[v[1]][v[0]] = true;
        degree[v[0]]++;
        degree[v[1]]++;
    }

    let maxRank = 0;
    for (let i = 0; i < n; i++) {
        for (let j = i + 1; j < n; j++) {
            let rank = degree[i] + degree[j] - (connect[i][j] ? 1 : 0);
            maxRank = Math.max(maxRank, rank);
        }
    }
    return maxRank;
};
```

```go
func maximalNetworkRank(n int, roads [][]int) int {
    connect := make([][]int, n)
    for i := range connect {
        connect[i] = make([]int, n)
    }
    degree := make([]int, n)
    for _, v := range roads {
        connect[v[0]][v[1]] = 1
        connect[v[1]][v[0]] = 1
        degree[v[0]]++
        degree[v[1]]++
    }

    maxRank := 0
    for i := 0; i < n; i++ {
        for j := i + 1; j < n; j++ {
            rank := degree[i] + degree[j] - connect[i][j]
            maxRank = max(maxRank, rank)
        }
    }
    return maxRank
}

func max(a, b int) int {
    if b > a {
        return b
    }
    return a
}
```

**复杂度分析**

-   时间复杂度：$O(n^2)$，其中 $n$ 表示给城市的数目。我们需要枚举所有可能的城市对，最多有 $n^2$ 个城市对。
-   空间复杂度：$O(n^2)$。需要记录图中所有的城市之间的连通关系，需要的空间为 $O(n^2)$。如果用邻接表存储连通关系，空间复杂度可以优化到 $O(n + m)$，其中 $m$ 表示 $roads$ 的长度。
