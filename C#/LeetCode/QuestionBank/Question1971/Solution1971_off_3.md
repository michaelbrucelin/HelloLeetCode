#### [方法三：并查集](https://leetcode.cn/problems/find-if-path-exists-in-graph/solutions/2024085/xun-zhao-tu-zhong-shi-fou-cun-zai-lu-jin-d0q0/)

**思路与算法**

我们将图中的每个强连通分量视为一个集合，强连通分量中任意两点均可达，如果两个点 $source$ 和 $destination$ 处在同一个强连通分量中，则两点一定可连通，因此连通性问题可以使用并查集解决。

并查集初始化时，$n$ 个顶点分别属于 $n$ 个不同的集合，每个集合只包含一个顶点。初始化之后遍历每条边，由于图中的每条边均为双向边，因此将同一条边连接的两个顶点所在的集合做合并。

遍历所有的边之后，判断顶点 $source$ 和顶点 $destination$ 是否在同一个集合中，如果两个顶点在同一个集合则两个顶点连通，如果两个顶点所在的集合不同则两个顶点不连通。

**代码**

```cpp
class UnionFind {
public:
    UnionFind(int n) {
        parent = vector<int>(n);
        rank = vector<int>(n);
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
    }

    void uni(int x, int y) {
        int rootx = find(x);
        int rooty = find(y);
        if (rootx != rooty) {
            if (rank[rootx] > rank[rooty]) {
                parent[rooty] = rootx;
            } else if (rank[rootx] < rank[rooty]) {
                parent[rootx] = rooty;
            } else {
                parent[rooty] = rootx;
                rank[rootx]++;
            }
        }
    }

    int find(int x) {
        if (parent[x] != x) {
            parent[x] = find(parent[x]);
        }
        return parent[x];
    }

    bool connect(int x, int y) {
        return find(x) == find(y);
    }
private:
    vector<int> parent;
    vector<int> rank;
};

class Solution {
public:
    bool validPath(int n, vector<vector<int>>& edges, int source, int destination) {
        if (source == destination) {
            return true;
        }
        UnionFind uf(n);
        for (auto edge : edges) {
            uf.uni(edge[0], edge[1]);
        }
        return uf.connect(source, destination);
    }
};
```

```java
class Solution {
    public boolean validPath(int n, int[][] edges, int source, int destination) {
        if (source == destination) {
            return true;
        }
        UnionFind uf = new UnionFind(n);
        for (int[] edge : edges) {
            uf.uni(edge[0], edge[1]);
        }
        return uf.connect(source, destination);
    }
}

class UnionFind {
    private int[] parent;
    private int[] rank;

    public UnionFind(int n) {
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
    }

    public void uni(int x, int y) {
        int rootx = find(x);
        int rooty = find(y);
        if (rootx != rooty) {
            if (rank[rootx] > rank[rooty]) {
                parent[rooty] = rootx;
            } else if (rank[rootx] < rank[rooty]) {
                parent[rootx] = rooty;
            } else {
                parent[rooty] = rootx;
                rank[rootx]++;
            }
        }
    }

    public int find(int x) {
        if (parent[x] != x) {
            parent[x] = find(parent[x]);
        }
        return parent[x];
    }

    public boolean connect(int x, int y) {
        return find(x) == find(y);
    }
}
```

```csharp
public class Solution {
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        if (source == destination) {
            return true;
        }
        UnionFind uf = new UnionFind(n);
        foreach (int[] edge in edges) {
            uf.Uni(edge[0], edge[1]);
        }
        return uf.Connect(source, destination);
    }
}

class UnionFind {
    private int[] parent;
    private int[] rank;

    public UnionFind(int n) {
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
    }

    public void Uni(int x, int y) {
        int rootx = Find(x);
        int rooty = Find(y);
        if (rootx != rooty) {
            if (rank[rootx] > rank[rooty]) {
                parent[rooty] = rootx;
            } else if (rank[rootx] < rank[rooty]) {
                parent[rootx] = rooty;
            } else {
                parent[rooty] = rootx;
                rank[rootx]++;
            }
        }
    }

    public int Find(int x) {
        if (parent[x] != x) {
            parent[x] = Find(parent[x]);
        }
        return parent[x];
    }

    public bool Connect(int x, int y) {
        return Find(x) == Find(y);
    }
}
```

```c
typedef struct {
    int *parent;
    int *rank;
} UnionFind;

UnionFind *creatUnionFind(int n) {
    UnionFind *obj = (UnionFind *)malloc(sizeof(UnionFind));
    obj->parent = (int *)malloc(sizeof(int) * n);
    obj->rank = (int *)malloc(sizeof(int) * n);
    memset(obj->rank, 0, sizeof(int) * n);
    for (int i = 0; i < n; i++) {
        obj->parent[i] = i;
    }
    return obj;
}

void uni(UnionFind * obj, int x, int y) {
    int rootx = find(obj, x);
    int rooty = find(obj, y);
    if (rootx != rooty) {
        if (obj->rank[rootx] > obj->rank[rooty]) {
            obj->parent[rooty] = rootx;
        } else if (obj->rank[rootx] < obj->rank[rooty]) {
            obj->parent[rootx] = rooty;
        } else {
            obj->parent[rooty] = rootx;
            obj->rank[rootx]++;
        }
    }
}

int find(const UnionFind * obj, int x) {
    if (obj->parent[x] != x) {
        obj->parent[x] = find(obj, obj->parent[x]);
    }
    return obj->parent[x];
}

bool connect(const UnionFind * obj, int x, int y) {
    return find(obj, x) == find(obj, y);
}

bool validPath(int n, int** edges, int edgesSize, int* edgesColSize, int source, int destination) {
    if (source == destination) {
        return true;
    }
    UnionFind *uf = creatUnionFind(n);
    for (int i = 0; i < edgesSize; i++) {
        uni(uf, edges[i][0], edges[i][1]);
    }
    return connect(uf, source, destination);
}
```

```javascript
var validPath = function(n, edges, source, destination) {
    if (source === destination) {
        return true;
    }
    const uf = new UnionFind(n);
    for (const edge of edges) {
        uf.uni(edge[0], edge[1]);
    }
    return uf.connect(source, destination);
}

class UnionFind {
    constructor(n) {
        this.parent = new Array(n).fill(0).map((_, i) => i) ;
        this.rank = new Array(n).fill(0);
    }

    uni(x, y) {
        const rootx = this.find(x);
        const rooty = this.find(y);
        if (rootx !== rooty) {
            if (this.rank[rootx] > this.rank[rooty]) {
                this.parent[rooty] = rootx;
            } else if (this.rank[rootx] < this.rank[rooty]) {
                this.parent[rootx] = rooty;
            } else {
                this.parent[rooty] = rootx;
                this.rank[rootx]++;
            }
        }
    }

    find(x) {
        if (this.parent[x] !== x) {
            this.parent[x] = this.find(this.parent[x]);
        }
        return this.parent[x];
    }

    connect(x, y) {
        return this.find(x) === this.find(y);
    }
}
```

**复杂度分析**

-   时间复杂度：$O(n + m \times \alpha(m))$，其中 $n$ 是图中的顶点数，$m$ 是图中边的数目，$\alpha$ 是反阿克曼函数。并查集的初始化需要 $O(n)$ 的时间，然后遍历 $m$ 条边并执行 $m$ 次合并操作，最后对 $source$ 和 $destination$ 执行一次查询操作，查询与合并的单次操作时间复杂度是 $O(\alpha(m))$，因此合并与查询的时间复杂度是 $O(m \times \alpha(m))$，总时间复杂度是 $O(n + m \times \alpha(m))$。
-   空间复杂度：$O(n)$，其中 $n$ 是图中的顶点数。并查集需要 $O(n)$ 的空间。
