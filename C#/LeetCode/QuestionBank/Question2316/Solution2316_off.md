### [统计无向图中无法互相到达点对数](https://leetcode.cn/problems/count-unreachable-pairs-of-nodes-in-an-undirected-graph/solutions/2487673/tong-ji-wu-xiang-tu-zhong-wu-fa-hu-xiang-q5eh/)

#### 方法一：并查集

**思路**

部分点通过 $edges$ 连接，可以组成连通分量。同属于同一个连通分量的两个点可以互相到达，不属于同一个连通分量的点一定无法互相到达。我们可以利用并查集，找到图中所有的连通分量和每个连通分量的点数 $size$。再遍历每个点，并查询它所在的连通分量的点数 $size$，而 $n - size$ 就是与这个点无法互相到达的点数。对每个点进行这样的计算后求和，但这样的方法计算，每个点对会被计算两次，因此最后结果需要除以 $2$。

在使用并查集时，为了提高效率，我们可以使用路径压缩的方法。因为计算点对数目的时候我们需要用到连通分量的点数，我们也可以使用按点数大小合并的优化。

**代码**

```python
class Solution:
    def countPairs(self, n: int, edges: List[List[int]]) -> int:
        uf = UnionFind(n)
        for x, y in edges:
            uf.union(x, y)
        res = 0
        for i in range(n):
            res += n - uf.getSize(uf.find(i))
        return res // 2

class UnionFind:
    def __init__(self, n: int):
        self.parents = [i for i in range(n)]
        self.sizes = [1] * n

    def find(self, x: int) -> int:
        if self.parents[x] == x:
            return x
        else:
            self.parents[x] = self.find(self.parents[x])
            return self.parents[x]

    def union(self, x: int, y: int):
        rx = self.find(x)
        ry = self.find(y)
        if rx != ry:
            if self.sizes[rx] > self.sizes[ry]:
                self.parents[ry] = rx
                self.sizes[rx] += self.sizes[ry]
            else:
                self.parents[rx] = ry
                self.sizes[ry] += self.sizes[rx]

    def getSize(self, x: int) -> int:
        return self.sizes[x]
```

```java
class Solution {
    public long countPairs(int n, int[][] edges) {
        UnionFind uf = new UnionFind(n);
        for (int[] edge : edges) {
            int x = edge[0], y = edge[1];
            uf.union(x, y);
        }
        long res = 0;
        for (int i = 0; i < n; i++) {
            res += n - uf.getSize(uf.find(i));
        }
        return res / 2;
    }
}

class UnionFind {
    int[] parents;
    int[] sizes;

    public UnionFind(int n) {
        parents = new int[n];
        for (int i = 0; i < n; i++) {
            parents[i] = i;
        }
        sizes = new int[n];
        Arrays.fill(sizes, 1);
    }

    public int find(int x) {
        if (parents[x] == x) {
            return x;
        } else {
            parents[x] = find(parents[x]);
            return parents[x];
        }
    }

    public void union(int x, int y) {
        int rx = find(x), ry = find(y);
        if (rx != ry) {
            if (sizes[rx] > sizes[ry]) {
                parents[ry] = rx;
                sizes[rx] += sizes[ry];
            } else {
                parents[rx] = ry;
                sizes[ry] += sizes[rx];
            }
        }
    }

    public int getSize(int x) {
        return sizes[x];
    }
}
```

```csharp
public class Solution {
    public long CountPairs(int n, int[][] edges) {
        UnionFind uf = new UnionFind(n);
        foreach (int[] edge in edges) {
            int x = edge[0], y = edge[1];
            uf.Union(x, y);
        }
        long res = 0;
        for (int i = 0; i < n; i++) {
            res += n - uf.GetSize(uf.Find(i));
        }
        return res / 2;
    }
}

class UnionFind {
    int[] parents;
    int[] sizes;

    public UnionFind(int n) {
        parents = new int[n];
        for (int i = 0; i < n; i++) {
            parents[i] = i;
        }
        sizes = new int[n];
        Array.Fill(sizes, 1);
    }

    public int Find(int x) {
        if (parents[x] == x) {
            return x;
        } else {
            parents[x] = Find(parents[x]);
            return parents[x];
        }
    }

    public void Union(int x, int y) {
        int rx = Find(x), ry = Find(y);
        if (rx != ry) {
            if (sizes[rx] > sizes[ry]) {
                parents[ry] = rx;
                sizes[rx] += sizes[ry];
            } else {
                parents[rx] = ry;
                sizes[ry] += sizes[rx];
            }
        }
    }

    public int GetSize(int x) {
        return sizes[x];
    }
}
```

```cpp
class UnionFind {
private:
    vector<int> parents;
    vector<int> sizes;
public:
    UnionFind(int n) : parents(n), sizes(n, 1) {
        iota(parents.begin(), parents.end(), 0);
    }
    int Find(int x) {
        if (parents[x] == x) {
            return x;
        }
        return parents[x] = Find(parents[x]);
    }
    void Union(int x, int y) {
        int rx = Find(x), ry = Find(y);
        if (rx != ry) {
            if (sizes[rx] > sizes[ry]) {
                parents[ry] = rx;
                sizes[rx] += sizes[ry];
            } else {
                parents[rx] = ry;
                sizes[ry] += sizes[rx];
            }
        }
    }
    int GetSize(int x) {
        return sizes[x];
    }
};

class Solution {
public:
    long long countPairs(int n, vector<vector<int>> &edges) {
        UnionFind uf(n);
        for (const auto &edge : edges) {
            uf.Union(edge[0], edge[1]);
        }
        long long res = 0;
        for (int i = 0; i < n; i++) {
            res += n - uf.GetSize(uf.Find(i));
        }
        return res / 2;
    }
};
```

```go
type UnionFind struct {
    parents []int
    sizes   []int
}

func NewUnionFind(n int) *UnionFind {
    parents, sizes := make([]int, n), make([]int, n)
    for i := 0; i < n; i++ {
        parents[i], sizes[i] = i, 1
    }
    return &UnionFind{
        parents: parents,
        sizes:   sizes,
    }
}

func (uf *UnionFind) Find(x int) int {
    if uf.parents[x] == x {
        return x
    }
    uf.parents[x] = uf.Find(uf.parents[x])
    return uf.parents[x]
}

func (uf *UnionFind) Union(x, y int) {
    rx, ry := uf.Find(x), uf.Find(y)
    if rx != ry {
        if uf.sizes[x] > uf.sizes[y] {
            uf.parents[ry], uf.sizes[rx] = rx, uf.sizes[rx]+uf.sizes[ry]
        } else {
            uf.parents[rx], uf.sizes[ry] = ry, uf.sizes[rx]+uf.sizes[ry]
        }
    }
}

func (uf *UnionFind) GetSize(x int) int {
    return uf.sizes[x]
}

func countPairs(n int, edges [][]int) int64 {
    uf := NewUnionFind(n)
    for _, edge := range edges {
        uf.Union(edge[0], edge[1])
    }
    var res int64
    for i := 0; i < n; i++ {
        res += int64(n - uf.GetSize(uf.Find(i)))
    }
    return res / 2
}
```

```c
typedef struct {
    int *parents;
    int *sizes;
} UnionFind;

UnionFind *NewUnionFind(int n) {
    UnionFind *uf = (UnionFind *)malloc(sizeof(UnionFind));
    uf->parents = (int *)malloc(sizeof(int) * n);
    uf->sizes = (int *)malloc(sizeof(int) * n);
    for (int i = 0; i < n; i++) {
        uf->parents[i] = i;
        uf->sizes[i] = 1;
    }
    return uf;
}

void FreeUnionFind(UnionFind *uf) {
    free(uf->parents);
    free(uf->sizes);
    free(uf);
}

int Find(UnionFind *uf, int x) {
    if (uf->parents[x] == x) {
        return x;
    }
    return uf->parents[x] = Find(uf, uf->parents[x]);
}

void Union(UnionFind *uf, int x, int y) {
    int rx = Find(uf, x), ry = Find(uf, y);
    if (rx != ry) {
        if (uf->sizes[rx] > uf->sizes[ry]) {
            uf->parents[ry] = rx;
            uf->sizes[rx] += uf->sizes[ry];
        } else {
            uf->parents[rx] = ry;
            uf->sizes[ry] += uf->sizes[rx];
        }
    }
}

int GetSize(UnionFind *uf, int x) {
    return uf->sizes[x];
}

long long countPairs(int n, int** edges, int edgesSize, int* edgesColSize){
    UnionFind *uf = NewUnionFind(n);
    for (int i = 0; i < edgesSize; i++) {
        Union(uf, edges[i][0], edges[i][1]);
    }
    long long res = 0;
    for (int i = 0; i < n; i++) {
        res += n - GetSize(uf, Find(uf, i));
    }
    FreeUnionFind(uf);
    return res / 2;
}
```

```javascript
var countPairs = function(n, edges) {
    const uf = new UnionFind(n);
    for (const edge of edges) {
        x = edge[0], y = edge[1];
        uf.union(x, y);
    }
    let res = 0;
    for (let i = 0; i < n; i++) {
        res += n - uf.getSize(uf.find(i));
    }
    return res / 2;
};

class UnionFind {
    constructor(n) {
        this.sizes = new Array(n).fill(1); 
        this.parents = new Array(n).fill(0).map((ele, index) => index);
    }

    find(x) {
        if (this.parents[x] == x) {
            return x;
        } else {
            this.parents[x] = this.find(this.parents[x]);
            return this.parents[x];
        }
    }

    union(x, y) {
        const rx = this.find(x);
        const ry = this.find(y);
        if (rx != ry) {
            if (this.sizes[rx] > this.sizes[ry]) {
                this.parents[ry] = rx;
                this.sizes[rx] += this.sizes[ry];
            } else {
                this.parents[rx] = ry;
                this.sizes[ry] += this.sizes[rx];
            }
        }
    }

    getSize(x) {
        return this.sizes[x];
    }
}
```

**复杂度分析**

-   时间复杂度：$O((m+n)\times \alpha(n))$，其中 $m$ 是边数，$\alpha$ 表示阿克曼函数的反函数。
-   空间复杂度：$O(n)$。

#### 方法二：深度优先搜索

**思路**

连通分量还可以通过深度优先搜索来划分。首先将输入 $edges$ 构造成临接表 $graph$。然后构造函数 $dfs$，作用为遍历与它在同一个连通分量中并且还未访问过的点，并返回访问的点数。遍历所有点，如果当前点还没有访问过，则说明遇到了一个新的连通分量，通过 $dfs$ 来计算当前连通分量的点数 $count$，这个连通分量中的所有点与这个连通分量中的所有点都无法相互到达，因此这个连通分量中的点对答案的贡献是 $count \times (n-count)$。与方法一类似，每个点对会被计算两次，因此最后结果需要除以 $2$。

**代码**

```python
class Solution:
    def countPairs(self, n: int, edges: List[List[int]]) -> int:
        graph = [[] for _ in range(n)]
        for x, y in edges:
            graph[x].append(y)
            graph[y].append(x) 

        visited = [False] * n
        def dfs(x: int) -> int:
            visited[x] = True 
            count = 1
            for y in graph[x]:
                if not visited[y]:
                    count += dfs(y)
            return count

        res = 0
        for i in range(n):
            if not visited[i]: 
                count = dfs(i)
                res += count * (n - count)
        return res // 2
```

```javascript
var countPairs = function(n, edges) {
    const graph = new Array(n).fill(0).map(() => new Array());
    for (const edge of edges) {
        let x = edge[0], y = edge[1];
        graph[x].push(y);
        graph[y].push(x);
    }
    
    const visited = new Array(n).fill(false);
    const dfs = function(x) {
        visited[x] = true;
        let count = 1;
        for (const y of graph[x]) {
            if (!visited[y]) {
                count += dfs(y);
            }
        }
        return count;
    };
        
    let res = 0;
    for (let i = 0; i < n; i++) {
        if (!visited[i]) {
            let count = dfs(i);
            res += count * (n - count);
        }
    }
    return Math.floor(res / 2);
};
```

**复杂度分析**

-   时间复杂度：$O(m+n)$，其中 $m$ 是边数。构造临接表消耗 $O(m+n)$，$dfs$ 消耗 $O(m+n)$。
-   空间复杂度：$O(m+n)$。
