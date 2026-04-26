### [二维网格图中探测环](https://leetcode.cn/problems/detect-cycles-in-2d-grid/solutions/409096/er-wei-wang-ge-tu-zhong-tan-ce-huan-by-leetcode-so/)

#### 前言

对于大小为 $m\times n$ 的网格数组 $grid$，如果我们将其中的每个位置看成一个节点，任意两个上下左右相邻且值相同的节点之间有一条无向边，那么 $grid$ 中的一个环就对应着我们构造出的图中的一个环。因此，我们只需要判断图中是否有环即可。

常用的判断无向图中是否有环的方法有深度优先搜索和广度优先搜索，但这里我们会介绍一种基于并查集的判断方法。

#### 方法一：并查集

**思路与算法**

使用并查集判断无向图中是否有环的方法非常简洁且直观：

- 对于图中的任意一条边 $(x,y)$，我们将 $x$ 和 $y$ 对应的集合合并。如果 $x$ 和 $y$ 已经属于同一集合，那么说明 $x$ 和 $y$ 已经连通，在边 $(x,y)$ 的帮助下，图中会形成一个环。

这样一来，我们只要遍历图中的每一条边并进行上述的操作即可。具体的方法是，我们遍历数组 $grid$ 中的每一个位置，如果该位置与其上方或左侧的值相同，那么就有了一条边，并将这两个位置进行合并。这样的方法可以保证每一条边的两个节点只会被合并一次。

由于并查集是一维的数据结构，而数组 $grid$ 是二维的。因此对于数组中的每个位置 $(i,j)$，我们可以用 $i\times n+j$ 将其映射至一维空间中：

- $(i,j)$ 上方的位置对应着 $(i-1)\times n+j$；
- $(i,j)$ 左侧的位置对应着 $i\times n+j-1$。

**代码**

```C++
class UnionFind {
public:
    vector<int> parent;
    vector<int> size;
    int n;
    int setCount;

public:
    UnionFind(int _n): n(_n), setCount(_n), parent(_n), size(_n, 1) {
        iota(parent.begin(), parent.end(), 0);
    }

    int findset(int x) {
        return parent[x] == x ? x : parent[x] = findset(parent[x]);
    }

    void unite(int x, int y) {
        if (size[x] < size[y]) {
            swap(x, y);
        }
        parent[y] = x;
        size[x] += size[y];
        --setCount;
    }

    bool findAndUnite(int x, int y) {
        int parentX = findset(x);
        int parentY = findset(y);
        if (parentX != parentY) {
            unite(parentX, parentY);
            return true;
        }
        return false;
    }
};

class Solution {
public:
    bool containsCycle(vector<vector<char>>& grid) {
        int m = grid.size();
        int n = grid[0].size();
        UnionFind uf(m * n);
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i > 0 && grid[i][j] == grid[i - 1][j]) {
                    if (!uf.findAndUnite(i * n + j, (i - 1) * n + j)) {
                        return true;
                    }
                }
                if (j > 0 && grid[i][j] == grid[i][j - 1]) {
                    if (!uf.findAndUnite(i * n + j, i * n + j - 1)) {
                        return true;
                    }
                }
            }
        }
        return false;
    }
};
```

```Java
class Solution {
    public boolean containsCycle(char[][] grid) {
        int m = grid.length;
        int n = grid[0].length;
        UnionFind uf = new UnionFind(m * n);
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i > 0 && grid[i][j] == grid[i - 1][j]) {
                    if (!uf.findAndUnite(i * n + j, (i - 1) * n + j)) {
                        return true;
                    }
                }
                if (j > 0 && grid[i][j] == grid[i][j - 1]) {
                    if (!uf.findAndUnite(i * n + j, i * n + j - 1)) {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}

class UnionFind {
    int[] parent;
    int[] size;
    int n;
    int setCount;

    public UnionFind(int n) {
        parent = new int[n];
        for (int i = 0; i < n; ++i) {
            parent[i] = i;
        }
        size = new int[n];
        Arrays.fill(size, 1);
        this.n = n;
        setCount = n;
    }

    public int findset(int x) {
        return parent[x] == x ? x : (parent[x] = findset(parent[x]));
    }

    public void unite(int x, int y) {
        if (size[x] < size[y]) {
            int temp = x;
            x = y;
            y = temp;
        }
        parent[y] = x;
        size[x] += size[y];
        --setCount;
    }

    public boolean findAndUnite(int x, int y) {
        int parentX = findset(x);
        int parentY = findset(y);
        if (parentX != parentY) {
            unite(parentX, parentY);
            return true;
        }
        return false;
    }
}
```

```Python
class UnionFind:
    def __init__(self, n: int):
        self.n = n
        self.setCount = n
        self.parent = list(range(n))
        self.size = [1] * n

    def findset(self, x: int) -> int:
        if self.parent[x] == x:
            return x
        self.parent[x] = self.findset(self.parent[x])
        return self.parent[x]

    def unite(self, x: int, y: int):
        if self.size[x] < self.size[y]:
            x, y = y, x
        self.parent[y] = x
        self.size[x] += self.size[y]
        self.setCount -= 1

    def findAndUnite(self, x: int, y: int) -> bool:
        parentX, parentY = self.findset(x), self.findset(y)
        if parentX != parentY:
            self.unite(parentX, parentY)
            return True
        return False

class Solution:
    def containsCycle(self, grid: List[List[str]]) -> bool:
        m, n = len(grid), len(grid[0])
        uf = UnionFind(m * n)
        for i in range(m):
            for j in range(n):
                if i > 0 and grid[i][j] == grid[i - 1][j]:
                    if not uf.findAndUnite(i * n + j, (i - 1) * n + j):
                        return True
                if j > 0 and grid[i][j] == grid[i][j - 1]:
                    if not uf.findAndUnite(i * n + j, i * n + j - 1):
                        return True
        return False
```

```CSharp
public class Solution {
    public bool ContainsCycle(char[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        UnionFind uf = new UnionFind(m * n);

        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i > 0 && grid[i][j] == grid[i - 1][j]) {
                    if (!uf.FindAndUnite(i * n + j, (i - 1) * n + j)) {
                        return true;
                    }
                }
                if (j > 0 && grid[i][j] == grid[i][j - 1]) {
                    if (!uf.FindAndUnite(i * n + j, i * n + j - 1)) {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}

public class UnionFind {
    private int[] parent;
    private int[] size;
    private int setCount;

    public UnionFind(int n) {
        parent = new int[n];
        size = new int[n];
        setCount = n;

        for (int i = 0; i < n; ++i) {
            parent[i] = i;
            size[i] = 1;
        }
    }

    public int FindSet(int x) {
        return parent[x] == x ? x : (parent[x] = FindSet(parent[x]));
    }

    private void Unite(int x, int y) {
        if (size[x] < size[y]) {
            int temp = x;
            x = y;
            y = temp;
        }
        parent[y] = x;
        size[x] += size[y];
        --setCount;
    }

    public bool FindAndUnite(int x, int y) {
        int parentX = FindSet(x);
        int parentY = FindSet(y);
        if (parentX != parentY) {
            Unite(parentX, parentY);
            return true;
        }
        return false;
    }
}
```

```Go
func containsCycle(grid [][]byte) bool {
    m, n := len(grid), len(grid[0])
    uf := NewUnionFind(m * n)

    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            if i > 0 && grid[i][j] == grid[i - 1][j] {
                if !uf.FindAndUnite(i * n + j, (i - 1) * n + j) {
                    return true
                }
            }
            if j > 0 && grid[i][j] == grid[i][j - 1] {
                if !uf.FindAndUnite(i * n + j, i * n + j - 1) {
                    return true
                }
            }
        }
    }
    return false
}

type UnionFind struct {
    parent []int
    size   []int
}

func NewUnionFind(n int) *UnionFind {
    parent := make([]int, n)
    size := make([]int, n)
    for i := 0; i < n; i++ {
        parent[i] = i
        size[i] = 1
    }
    return &UnionFind{parent: parent, size: size}
}

func (uf *UnionFind) FindSet(x int) int {
    if uf.parent[x] != x {
        uf.parent[x] = uf.FindSet(uf.parent[x])
    }
    return uf.parent[x]
}

func (uf *UnionFind) Unite(x, y int) {
    if uf.size[x] < uf.size[y] {
        x, y = y, x
    }
    uf.parent[y] = x
    uf.size[x] += uf.size[y]
}

func (uf *UnionFind) FindAndUnite(x, y int) bool {
    parentX := uf.FindSet(x)
    parentY := uf.FindSet(y)
    if parentX != parentY {
        uf.Unite(parentX, parentY)
        return true
    }
    return false
}
```

```C
typedef struct {
    int* parent;
    int* size;
} UnionFind;

UnionFind* createUnionFind(int n) {
    UnionFind* uf = (UnionFind*)malloc(sizeof(UnionFind));
    uf->parent = (int*)malloc(n * sizeof(int));
    uf->size = (int*)malloc(n * sizeof(int));

    for (int i = 0; i < n; i++) {
        uf->parent[i] = i;
        uf->size[i] = 1;
    }
    return uf;
}

int findSet(UnionFind* uf, int x) {
    if (uf->parent[x] != x) {
        uf->parent[x] = findSet(uf, uf->parent[x]);
    }
    return uf->parent[x];
}

void unite(UnionFind* uf, int x, int y) {
    if (uf->size[x] < uf->size[y]) {
        int temp = x;
        x = y;
        y = temp;
    }
    uf->parent[y] = x;
    uf->size[x] += uf->size[y];
}

bool findAndUnite(UnionFind* uf, int x, int y) {
    int parentX = findSet(uf, x);
    int parentY = findSet(uf, y);
    if (parentX != parentY) {
        unite(uf, parentX, parentY);
        return true;
    }
    return false;
}

void freeUnionFind(UnionFind* uf) {
    free(uf->parent);
    free(uf->size);
    free(uf);
}

bool containsCycle(char** grid, int gridSize, int* gridColSize) {
    int m = gridSize;
    int n = gridColSize[0];
    UnionFind* uf = createUnionFind(m * n);

    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < n; ++j) {
            if (i > 0 && grid[i][j] == grid[i - 1][j]) {
                if (!findAndUnite(uf, i * n + j, (i - 1) * n + j)) {
                    freeUnionFind(uf);
                    return true;
                }
            }
            if (j > 0 && grid[i][j] == grid[i][j - 1]) {
                if (!findAndUnite(uf, i * n + j, i * n + j - 1)) {
                    freeUnionFind(uf);
                    return true;
                }
            }
        }
    }
    freeUnionFind(uf);
    return false;
}
```

```JavaScript
var containsCycle = function(grid) {
    const m = grid.length;
    const n = grid[0].length;
    const uf = new UnionFind(m * n);

    for (let i = 0; i < m; ++i) {
        for (let j = 0; j < n; ++j) {
            if (i > 0 && grid[i][j] === grid[i - 1][j]) {
                if (!uf.findAndUnite(i * n + j, (i - 1) * n + j)) {
                    return true;
                }
            }
            if (j > 0 && grid[i][j] === grid[i][j - 1]) {
                if (!uf.findAndUnite(i * n + j, i * n + j - 1)) {
                    return true;
                }
            }
        }
    }
    return false;
};


class UnionFind {
    constructor(n) {
        this.parent = new Array(n);
        this.size = new Array(n).fill(1);
        for (let i = 0; i < n; ++i) {
            this.parent[i] = i;
        }
    }

    findSet(x) {
        if (this.parent[x] !== x) {
            this.parent[x] = this.findSet(this.parent[x]);
        }
        return this.parent[x];
    }

    unite(x, y) {
        if (this.size[x] < this.size[y]) {
            [x, y] = [y, x];
        }
        this.parent[y] = x;
        this.size[x] += this.size[y];
    }

    findAndUnite(x, y) {
        const parentX = this.findSet(x);
        const parentY = this.findSet(y);
        if (parentX !== parentY) {
            this.unite(parentX, parentY);
            return true;
        }
        return false;
    }
}
```

```TypeScript
function containsCycle(grid: string[][]): boolean {
    const m = grid.length;
    const n = grid[0].length;
    const uf = new UnionFind(m * n);

    for (let i = 0; i < m; ++i) {
        for (let j = 0; j < n; ++j) {
            if (i > 0 && grid[i][j] === grid[i - 1][j]) {
                if (!uf.findAndUnite(i * n + j, (i - 1) * n + j)) {
                    return true;
                }
            }
            if (j > 0 && grid[i][j] === grid[i][j - 1]) {
                if (!uf.findAndUnite(i * n + j, i * n + j - 1)) {
                    return true;
                }
            }
        }
    }
    return false;
};

class UnionFind {
    private parent: number[];
    private size: number[];

    constructor(n: number) {
        this.parent = new Array(n);
        this.size = new Array(n).fill(1);
        for (let i = 0; i < n; ++i) {
            this.parent[i] = i;
        }
    }

    private findSet(x: number): number {
        if (this.parent[x] !== x) {
            this.parent[x] = this.findSet(this.parent[x]);
        }
        return this.parent[x];
    }

    private unite(x: number, y: number): void {
        if (this.size[x] < this.size[y]) {
            [x, y] = [y, x];
        }
        this.parent[y] = x;
        this.size[x] += this.size[y];
    }

    findAndUnite(x: number, y: number): boolean {
        const parentX = this.findSet(x);
        const parentY = this.findSet(y);
        if (parentX !== parentY) {
            this.unite(parentX, parentY);
            return true;
        }
        return false;
    }
}
```

```Rust
struct UnionFind {
    parent: Vec<usize>,
    size: Vec<usize>,
}

impl UnionFind {
    fn new(n: usize) -> Self {
        let parent = (0..n).collect();
        let size = vec![1; n];
        UnionFind { parent, size }
    }

    fn find_set(&mut self, x: usize) -> usize {
        if self.parent[x] != x {
            self.parent[x] = self.find_set(self.parent[x]);
        }
        self.parent[x]
    }

    fn unite(&mut self, x: usize, y: usize) {
        let (mut root_x, mut root_y) = (x, y);
        if self.size[root_x] < self.size[root_y] {
            std::mem::swap(&mut root_x, &mut root_y);
        }
        self.parent[root_y] = root_x;
        self.size[root_x] += self.size[root_y];
    }

    fn find_and_unite(&mut self, x: usize, y: usize) -> bool {
        let root_x = self.find_set(x);
        let root_y = self.find_set(y);
        if root_x != root_y {
            self.unite(root_x, root_y);
            true
        } else {
            false
        }
    }
}

impl Solution {
    pub fn contains_cycle(grid: Vec<Vec<char>>) -> bool {
        let m = grid.len();
        let n = grid[0].len();
        let mut uf = UnionFind::new(m * n);

        for i in 0..m {
            for j in 0..n {
                if i > 0 && grid[i][j] == grid[i - 1][j] {
                    let cell1 = i * n + j;
                    let cell2 = (i - 1) * n + j;
                    if !uf.find_and_unite(cell1, cell2) {
                        return true;
                    }
                }
                if j > 0 && grid[i][j] == grid[i][j - 1] {
                    let cell1 = i * n + j;
                    let cell2 = i * n + j - 1;
                    if !uf.find_and_unite(cell1, cell2) {
                        return true;
                    }
                }
            }
        }
        false
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn\cdot \alpha (mn))$。上述代码中的并查集使用了路径压缩（$path compression$）以及按秩合并（$union by size/rank$）优化，单次合并操作的均摊时间复杂度为 $\alpha (mn)$。每一个位置最多进行两次合并操作，因此总时间复杂度为 $O(mn\cdot \alpha (mn))$。
- 空间复杂度：$O(mn)$，即为并查集使用的空间。
