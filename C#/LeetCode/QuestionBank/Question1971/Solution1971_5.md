#### [�����������鼯](https://leetcode.cn/problems/find-if-path-exists-in-graph/solutions/2024085/xun-zhao-tu-zhong-shi-fou-cun-zai-lu-jin-d0q0/)

**˼·���㷨**

���ǽ�ͼ�е�ÿ��ǿ��ͨ������Ϊһ�����ϣ�ǿ��ͨ����������������ɴ��������� $source$ �� $destination$ ����ͬһ��ǿ��ͨ�����У�������һ������ͨ�������ͨ���������ʹ�ò��鼯�����

���鼯��ʼ��ʱ��$n$ ������ֱ����� $n$ ����ͬ�ļ��ϣ�ÿ������ֻ����һ�����㡣��ʼ��֮�����ÿ���ߣ�����ͼ�е�ÿ���߾�Ϊ˫��ߣ���˽�ͬһ�������ӵ������������ڵļ������ϲ���

�������еı�֮���ж϶��� $source$ �Ͷ��� $destination$ �Ƿ���ͬһ�������У��������������ͬһ������������������ͨ����������������ڵļ��ϲ�ͬ���������㲻��ͨ��

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n + m \times \alpha(m))$������ $n$ ��ͼ�еĶ�������$m$ ��ͼ�бߵ���Ŀ��$\alpha$ �Ƿ����������������鼯�ĳ�ʼ����Ҫ $O(n)$ ��ʱ�䣬Ȼ����� $m$ ���߲�ִ�� $m$ �κϲ����������� $source$ �� $destination$ ִ��һ�β�ѯ��������ѯ��ϲ��ĵ��β���ʱ�临�Ӷ��� $O(\alpha(m))$����˺ϲ����ѯ��ʱ�临�Ӷ��� $O(m \times \alpha(m))$����ʱ�临�Ӷ��� $O(n + m \times \alpha(m))$��
-   �ռ临�Ӷȣ�$O(n)$������ $n$ ��ͼ�еĶ����������鼯��Ҫ $O(n)$ �Ŀռ䡣
