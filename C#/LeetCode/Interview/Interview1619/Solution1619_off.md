#### [方法一：深度优先搜索](https://leetcode.cn/problems/pond-sizes-lcci/solutions/2313908/shui-yu-da-xiao-by-leetcode-solution-zztm/)

遍历矩阵 $land$，如果当前遍历的点 $(i, j)$ 满足 $land[i][j] = 0$，那么对 $(i, j)$ 进行深度优先搜索，深度优先搜索的过程如下：

1.  如果 $(i, j)$ 越界或 $land[i][j] \ne 0$，直接返回 $0$。
2.  令 $land[i][j] = -1$，表示该点已经被搜索过，然后对该点的八个相邻点执行深度优先搜索。
3.  返回值为执行的深度优先搜索的结果和加 $1$。

将所有结果放入一个数组内，然后从小到大进行排序，返回结果。

```cpp
class Solution {
public:
    vector<int> pondSizes(vector<vector<int>>& land) {
        int m = land.size(), n = land[0].size();
        function<int(int, int)> dfs = [&](int x, int y) -> int {
            if (x < 0 || x >= m || y < 0 || y >= n || land[x][y] != 0) {
                return 0;
            }
            land[x][y] = -1;
            int res = 1;
            for (int dx = -1; dx <= 1; dx++) {
                for (int dy = -1; dy <= 1; dy++) {
                    if (dx == 0 && dy == 0) {
                        continue;
                    }
                    res += dfs(x + dx, y + dy);
                }
            }
            return res;
        };

        vector<int> res;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (land[i][j] == 0) {
                    res.push_back(dfs(i, j));
                }
            }
        }
        sort(res.begin(), res.end());
        return res;
    }
};
```

```java
class Solution {
    public int[] pondSizes(int[][] land) {
        int m = land.length, n = land[0].length;
        List<Integer> resList = new ArrayList<Integer>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (land[i][j] == 0) {
                    resList.add(dfs(land, i, j));
                }
            }
        }
        int[] res = new int[resList.size()];
        for (int i = 0; i < resList.size(); i++) {
            res[i] = resList.get(i);
        }
        Arrays.sort(res);
        return res;
    }

    public int dfs(int[][] land, int x, int y) {
        int m = land.length, n = land[0].length;
        if (x < 0 || x >= m || y < 0 || y >= n || land[x][y] != 0) {
            return 0;
        }
        land[x][y] = -1;
        int res = 1;
        for (int dx = -1; dx <= 1; dx++) {
            for (int dy = -1; dy <= 1; dy++) {
                if (dx == 0 && dy == 0) {
                    continue;
                }
                res += dfs(land, x + dx, y + dy);
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int[] PondSizes(int[][] land) {
        int m = land.Length, n = land[0].Length;
        IList<int> resList = new List<int>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (land[i][j] == 0) {
                    resList.Add(DFS(land, i, j));
                }
            }
        }
        int[] res = new int[resList.Count];
        for (int i = 0; i < resList.Count; i++) {
            res[i] = resList[i];
        }
        Array.Sort(res);
        return res;
    }

    public int DFS(int[][] land, int x, int y) {
        int m = land.Length, n = land[0].Length;
        if (x < 0 || x >= m || y < 0 || y >= n || land[x][y] != 0) {
            return 0;
        }
        land[x][y] = -1;
        int res = 1;
        for (int dx = -1; dx <= 1; dx++) {
            for (int dy = -1; dy <= 1; dy++) {
                if (dx == 0 && dy == 0) {
                    continue;
                }
                res += DFS(land, x + dx, y + dy);
            }
        }
        return res;
    }
}
```

```go
func pondSizes(land [][]int) []int {
    m, n := len(land), len(land[0])
    var dfs func(int, int) int
    dfs = func(x, y int) int {
        if x < 0 || x >= m || y < 0 || y >= n || land[x][y] != 0 {
            return 0
        }
        land[x][y] = -1
        res := 1
        for dx := -1; dx <= 1; dx++ {
            for dy := -1; dy <= 1; dy++ {
                if dx == 0 && dy == 0 {
                    continue
                }
                res += dfs(x + dx, y + dy)
            }
        }
        return res
    }
    res := []int{}
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            if land[i][j] == 0 {
                res = append(res, dfs(i, j))
            }
        }
    }
    sort.Ints(res)
    return res
}
```

```python
class Solution:
    def pondSizes(self, land: List[List[int]]) -> List[int]:
        m, n = len(land), len(land[0])

        def dfs(x: int, y: int) -> int:
            if x < 0 or x >= m or y < 0 or y >= n or land[x][y] != 0:
                return 0
            
            land[x][y] = -1
            res = 1
            for dx in [-1, 0, 1]:
                for dy in [-1, 0, 1]:
                    if dx == dy == 0:
                        continue
                    res += dfs(x + dx, y + dy)
            return res
        
        res = list()
        for i in range(m):
            for j in range(n):
                if land[i][j] == 0:
                    res.append(dfs(i, j))
        res.sort()
        return res
```

```c
int dfs(int x, int y, int **land, int m, int n) {
    if (x < 0 || x >= m || y < 0 || y >= n || land[x][y] != 0) {
        return 0;
    }
    land[x][y] = -1;
    int res = 1;
    for (int dx = -1; dx <= 1; dx++) {
        for (int dy = -1; dy <= 1; dy++) {
            if (dx == 0 && dy == 0) {
                continue;
            }
            res += dfs(x + dx, y + dy, land, m, n);
        }
    }
    return res;
}

static int cmp(const void *a, const void *b) {
    return *(int *)a - *(int *)b;
}

int* pondSizes(int** land, int landSize, int* landColSize, int* returnSize) {
    int m = landSize, n = landColSize[0];
    int *res = (int *)calloc(m * n, sizeof(int));
    int pos = 0;
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (land[i][j] == 0) {
                res[pos++] = dfs(i, j, land, m, n);
            }
        }
    }
    qsort(res, pos, sizeof(int), cmp);
    *returnSize = pos;
    return res;
}
```

```javascript
const pondSizes = (land) => {
    const m = land.length;
    const n = land[0].length;
    const resList = [];
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (land[i][j] === 0) {
                resList.push(dfs(land, i, j));
            }
        }
    }
    const res = resList.sort((a, b) => a - b);
    return res;
};

const dfs = (land, x, y) => {
    const m = land.length;
    const n = land[0].length;
    if (x < 0 || x >= m || y < 0 || y >= n || land[x][y] !== 0) {
        return 0;
    }
    land[x][y] = -1;
    let res = 1;
    for (let dx = -1; dx <= 1; dx++) {
        for (let dy = -1; dy <= 1; dy++) {
            if (dx === 0 && dy === 0) {
                continue;
            }
            res += dfs(land, x + dx, y + dy);
        }
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(mn \times \log{mn})$，其中 $m$ 和 $n$ 分别是矩阵 $land$ 的行数和列数。深度优先搜索需要 $O(m \times n)$，在最坏情况下，结果数组 $res$ 的大小为 $mn$ 的量级，排序需要 $O(mn \times \log{mn})$。
-   空间复杂度：$O(m \times n)$。返回值不计入空间复杂度，最坏情况下，深度优先搜索需要 $O(m \times n)$ 的栈空间。

#### [方法二：广度优先搜索](https://leetcode.cn/problems/pond-sizes-lcci/solutions/2313908/shui-yu-da-xiao-by-leetcode-solution-zztm/)

同样也可以使得广度优先搜索统计所有相连接的点的个数。

```cpp
class Solution {
public:
    vector<int> pondSizes(vector<vector<int>>& land) {
        int m = land.size(), n = land[0].size();
        auto bfs = [&](int x, int y) -> int {
            int res = 0;
            queue<pair<int, int>> q;
            q.push({x, y});
            land[x][y] = -1;
            while (!q.empty()) {
                auto [x, y] = q.front();
                q.pop();
                res++;
                for (int dx = -1; dx <= 1; dx++) {
                    for (int dy = -1; dy <= 1; dy++) {
                        if (dx == 0 && dy == 0) {
                            continue;
                        }
                        if (x + dx < 0 || x + dx >= m || y + dy < 0 || y + dy >= n || land[x + dx][y + dy] != 0) {
                            continue;
                        }
                        land[x + dx][y + dy] = -1;
                        q.push({x + dx, y + dy});
                    }
                }
            }
            return res;
        };

        vector<int> res;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (land[i][j] == 0) {
                    res.push_back(bfs(i, j));
                }
            }
        }
        sort(res.begin(), res.end());
        return res;
    }
};
```

```java
class Solution {
    public int[] pondSizes(int[][] land) {
        int m = land.length, n = land[0].length;
        List<Integer> resList = new ArrayList<Integer>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (land[i][j] == 0) {
                    resList.add(bfs(land, i, j));
                }
            }
        }
        int[] res = new int[resList.size()];
        for (int i = 0; i < resList.size(); i++) {
            res[i] = resList.get(i);
        }
        Arrays.sort(res);
        return res;
    }

    public int bfs(int[][] land, int x, int y) {
        int m = land.length, n = land[0].length;
        int res = 0;
        Queue<int[]> queue = new ArrayDeque<int[]>();
        queue.offer(new int[]{x, y});
        land[x][y] = -1;
        while (!queue.isEmpty()) {
            int[] arr = queue.poll();
            int currX = arr[0], currY = arr[1];
            res++;
            for (int dx = -1; dx <= 1; dx++) {
                for (int dy = -1; dy <= 1; dy++) {
                    if (dx == 0 && dy == 0) {
                        continue;
                    }
                    if (currX + dx < 0 || currX + dx >= m || currY + dy < 0 || currY + dy >= n || land[currX + dx][currY + dy] != 0) {
                        continue;
                    }
                    land[currX + dx][currY + dy] = -1;
                    queue.offer(new int[]{currX + dx, currY + dy});
                }
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int[] PondSizes(int[][] land) {
        int m = land.Length, n = land[0].Length;
        IList<int> resList = new List<int>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (land[i][j] == 0) {
                    resList.Add(BFS(land, i, j));
                }
            }
        }
        int[] res = new int[resList.Count];
        for (int i = 0; i < resList.Count; i++) {
            res[i] = resList[i];
        }
        Array.Sort(res);
        return res;
    }

    public int BFS(int[][] land, int x, int y) {
        int m = land.Length, n = land[0].Length;
        int res = 0;
        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(new Tuple<int, int>(x, y));
        land[x][y] = -1;
        while (queue.Count > 0) {
            Tuple<int, int> tuple = queue.Dequeue();
            int currX = tuple.Item1, currY = tuple.Item2;
            res++;
            for (int dx = -1; dx <= 1; dx++) {
                for (int dy = -1; dy <= 1; dy++) {
                    if (dx == 0 && dy == 0) {
                        continue;
                    }
                    if (currX + dx < 0 || currX + dx >= m || currY + dy < 0 || currY + dy >= n || land[currX + dx][currY + dy] != 0) {
                        continue;
                    }
                    land[currX + dx][currY + dy] = -1;
                    queue.Enqueue(new Tuple<int, int>(currX + dx, currY + dy));
                }
            }
        }
        return res;
    }
}
```

```go
func pondSizes(land [][]int) []int {
    m, n := len(land), len(land[0])
    bfs := func(x, y int) int {
        q, res := [][]int{}, 0
        q, land[x][y] = append(q, []int{x, y}), -1
        for len(q) > 0 {
            x, y, q = q[0][0], q[0][1], q[1:]
            res++
            for dx := -1; dx <= 1; dx++ {
                for dy := -1; dy <= 1; dy++ {
                    if dx == 0 && dy == 0 {
                        continue
                    }
                    if x + dx < 0 || x + dx >= m || y + dy < 0 || y + dy >= n || land[x + dx][y + dy] != 0 {
                        continue
                    }
                    land[x + dx][y + dy] = -1
                    q = append(q, []int{x + dx, y + dy})
                }
            }
        }
        return res
    }
    res := []int{}
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            if land[i][j] == 0 {
                res = append(res, bfs(i, j))
            }
        }
    }
    sort.Ints(res)
    return res
}
```

```python
class Solution:
    def pondSizes(self, land: List[List[int]]) -> List[int]:
        m, n = len(land), len(land[0])
        
        def bfs(x: int, y: int) -> int:
            res = 0
            q = deque([(x, y)])
            land[x][y] = -1

            while q:
                x, y = q.popleft()
                res += 1
                for dx in [-1, 0, 1]:
                    for dy in [-1, 0, 1]:
                        if dx == dy == 0:
                            continue
                        if x + dx < 0 or x + dx >= m or y + dy < 0 or y + dy >= n or land[x + dx][y + dy] != 0:
                            continue
                        land[x + dx][y + dy] = -1
                        q.append((x + dx, y + dy))
            return res
        
        res = list()
        for i in range(m):
            for j in range(n):
                if land[i][j] == 0:
                    res.append(bfs(i, j))
        res.sort()
        return res
```

```c
int bfs(int x, int y, int **land, int m, int n) {
    int res = 0;
    int queue[m * n][2];
    int head = 0, tail = 0;
    land[x][y] = -1;
    queue[tail][0] = x;
    queue[tail][1] = y;
    tail++;
    while (head != tail) {
        int x = queue[head][0];
        int y = queue[head][1];
        head++;
        res++;
        for (int dx = -1; dx <= 1; dx++) {
            for (int dy = -1; dy <= 1; dy++) {
                if (dx == 0 && dy == 0) {
                    continue;
                }
                if (x + dx < 0 || x + dx >= m || y + dy < 0 || \
                    y + dy >= n || land[x + dx][y + dy] != 0) {
                    continue;
                }
                land[x + dx][y + dy] = -1;
                queue[tail][0] = x + dx;
                queue[tail][1] = y + dy;
                tail++;
            }
        }
    }
    return res;
}

static int cmp(const void *a, const void *b) {
    return *(int *)a - *(int *)b;
}

int* pondSizes(int** land, int landSize, int* landColSize, int* returnSize) {
    int m = landSize, n = landColSize[0];
    int *res = (int *)calloc(m * n, sizeof(int));
    int pos = 0;
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (land[i][j] == 0) {
                res[pos++] = bfs(i, j, land, m, n);
            }
        }
    }
    qsort(res, pos, sizeof(int), cmp);
    *returnSize = pos;
    return res;
}
```

```javascript
const pondSizes = (land) => {
    const m = land.length;
    const n = land[0].length;
    const resList = [];
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (land[i][j] === 0) {
                resList.push(bfs(land, i, j));
            }
        }
    }
    const res = resList.sort((a, b) => a - b);
    return res;
};

const bfs = (land, x, y) => {
    const m = land.length;
    const n = land[0].length;
    let res = 0;
    const queue = [];
    queue.push([x, y]);
    land[x][y] = -1;
    while (queue.length > 0) {
        const arr = queue.shift();
        const currX = arr[0];
        const currY = arr[1];
        res++;
        for (let dx = -1; dx <= 1; dx++) {
            for (let dy = -1; dy <= 1; dy++) {
                if (dx === 0 && dy === 0) {
                    continue;
                }
                if (
                    currX + dx < 0 ||
                    currX + dx >= m ||
                    currY + dy < 0 ||
                    currY + dy >= n ||
                    land[currX + dx][currY + dy] !== 0
                ) {
                    continue;
                }
                land[currX + dx][currY + dy] = -1;
                queue.push([currX + dx, currY + dy]);
            }
        }
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(mn \times \log{mn})$，其中 $m$ 和 $n$ 分别是矩阵 $land$ 的行数和列数。广度优先搜索需要 $O(m \times n)$，在最坏情况下，结果数组 $res$ 的大小为 $mn$ 的量级，排序需要 $O(mn \times \log{mn})$。
-   空间复杂度：$O(m + n)$。返回值不计入空间复杂度，最坏情况下，广度优先搜索的队列需要 $O(m + n)$ 的空间。
