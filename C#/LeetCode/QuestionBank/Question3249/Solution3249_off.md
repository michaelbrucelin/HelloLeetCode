### [统计好节点的数目](https://leetcode.cn/problems/count-the-number-of-good-nodes/solutions/2977809/tong-ji-hao-jie-dian-de-shu-mu-by-leetco-4q70/)

#### 方法一：深度优先搜索

**思路**

首先根据边数组 $edges$ 构建邻接表 $g$。在树中，边的数量为节点数量减 $1$。因此，$n$ 为 $edges$ 的长度加 $1$。再构造深度优先搜索，输入为当前遍历的节点 $node$ 和其父节点 $parent$，返回值为以 $node$ 为根节点的树的节点数量。需要递归调用 $node$ 的所有子节点。因为 $g$ 中存的是邻接关系，所以要跳过节点 $parent$。在计算节点数量和的同时，需要判断 $node$ 的所有子节点是否拥有相同的节点数。如果是的话，将结果加 $1$。最后调用 $dfs(0,-1)$ 并返回结果。

**代码**

```Python
class Solution:
    def countGoodNodes(self, edges: List[List[int]]) -> int:
        n = len(edges) + 1
        g = [[] for _ in range(n)]
        for x, y in edges:
            g[x].append(y)
            g[y].append(x)

        self.res = 0

        def dfs(node: int, parent: int) -> int:
            valid = True
            treeSize = 0
            subTreeSize = 0
            for child in g[node]:
                if child != parent:
                    size = dfs(child, node)
                    if subTreeSize == 0:
                        subTreeSize = size
                    elif size != subTreeSize:
                        valid = False
                    treeSize += size
            if valid:
                self.res += 1
            return treeSize + 1

        dfs(0, -1)
        return self.res
```

```Java
class Solution {
    int res = 0;
    List<Integer>[] g;

    public int countGoodNodes(int[][] edges) {
        int n = edges.length + 1;
        g = new List[n];
        for (int i = 0; i < n; i++) {
            g[i] = new ArrayList<Integer>();
        }
        for (int[] edge : edges) {
            g[edge[0]].add(edge[1]);
            g[edge[1]].add(edge[0]);
        }
        dfs(0, -1);
        return res;
    }

    public int dfs(int node, int parent) {
        boolean valid = true;
        int treeSize = 0;
        int subTreeSize = 0;
        for (int child : g[node]) {
            if (child != parent) {
                int size = dfs(child, node);
                if (subTreeSize == 0) {
                    subTreeSize = size;
                } else if (size != subTreeSize) {
                    valid = false;
                }
                treeSize += size;
            }
        }
        if (valid) {
            res++;
        }
        return treeSize + 1;
    }
}
```

```CSharp
public class Solution {
    int res = 0;
    IList<int>[] g;

    public int CountGoodNodes(int[][] edges) {
        int n = edges.Length + 1;
        g = new IList<int>[n];
        for (int i = 0; i < n; i++) {
            g[i] = new List<int>();
        }
        foreach (int[] edge in edges) {
            g[edge[0]].Add(edge[1]);
            g[edge[1]].Add(edge[0]);
        }
        DFS(0, -1);
        return res;
    }

    public int DFS(int node, int parent) {
        bool valid = true;
        int treeSize = 0;
        int subTreeSize = 0;
        foreach (int child in g[node]) {
            if (child != parent) {
                int size = DFS(child, node);
                if (subTreeSize == 0) {
                    subTreeSize = size;
                } else if (size != subTreeSize) {
                    valid = false;
                }
                treeSize += size;
            }
        }
        if (valid) {
            res++;
        }
        return treeSize + 1;
    }
}
```

```C++
class Solution {
public:
    int countGoodNodes(vector<vector<int>>& edges) {
        int n = edges.size() + 1;
        int res = 0;
        vector<vector<int>> g(n);
        for (const auto& edge : edges) {
            g[edge[0]].push_back(edge[1]);
            g[edge[1]].push_back(edge[0]);
        }

        function<int(int, int)> dfs = [&](int node, int parent) -> int {
            bool valid = true;
            int treeSize = 0;
            int subTreeSize = 0;

            for (int child : g[node]) {
                if (child != parent) {
                    int size = dfs(child, node);
                    if (subTreeSize == 0) {
                        subTreeSize = size;
                    } else if (size != subTreeSize) {
                        valid = false;
                    }
                    treeSize += size;
                }
            }
            if (valid) {
                res++;
            }
            return treeSize + 1;
        };

        dfs(0, -1);
        return res;
    }
};
```

```Go
func countGoodNodes(edges [][]int) int {
    n := len(edges) + 1
    g := make([][]int, n)
    for _, edge := range edges {
        x, y := edge[0], edge[1]
        g[x] = append(g[x], y)
        g[y] = append(g[y], x)
    }
    res := 0
    var dfs func(node, parent int) int
    dfs = func(node, parent int) int {
        valid := true
        treeSize := 0
        subTreeSize := 0

        for _, child := range g[node] {
            if child != parent {
                size := dfs(child, node)
                if subTreeSize == 0 {
                    subTreeSize = size
                } else if size != subTreeSize {
                    valid = false
                }
                treeSize += size
            }
        }
        if valid {
            res++
        }
        return treeSize + 1
    }

    dfs(0, -1)
    return res
}
```

```C
typedef struct {
    int *data;
    int size;
    int capacity;
} Vector;

Vector* createVector(int capacity) {
    Vector* arr = (Vector*)malloc(sizeof(Vector));
    arr->data = (int*)malloc(capacity * sizeof(int));
    arr->size = 0;
    arr->capacity = capacity;
    return arr;
}

void append(Vector* arr, int value) {
    if (arr->size == arr->capacity) {
        arr->capacity *= 2;
        arr->data = (int*)realloc(arr->data, arr->capacity * sizeof(int));
    }
    arr->data[arr->size++] = value;
}

void freeVector(Vector* arr) {
    free(arr->data);
    free(arr);
}

int dfs(int node, int parent, int *res, int *counts, Vector** g) {
    int valid = 1;
    int treeSize = 0;
    int subTreeSize = 0;
    for (int i = 0; i < counts[node]; i++) {
        int child = g[node]->data[i];
        if (child != parent) {
            int size = dfs(child, node, res, counts, g);
            if (subTreeSize == 0) {
                subTreeSize = size;
            } else if (size != subTreeSize) {
                valid = 0;
            }
            treeSize += size;
        }
    }

    if (valid) {
        (*res)++;
    }
    return treeSize + 1;
}

int countGoodNodes(int** edges, int edgesSize, int* edgesColSize) {
    int n = edgesSize + 1;
    int *counts = (int *)calloc(n, sizeof(int));
    int res = 0;
    Vector* g[n];
    for (int i = 0; i < n; i++) {
        g[i] = createVector(2);
    }
    for (int i = 0; i < edgesSize; i++) {
        int x = edges[i][0];
        int y = edges[i][1];
        counts[x]++;
        counts[y]++;
        append(g[x], y);
        append(g[y], x);
    }

    dfs(0, -1, &res, counts, g);
    for (int i = 0; i < n; i++) {
        freeVector(g[i]);
    }
    return res;
}
```

```JavaScript
var countGoodNodes = function(edges) {
    const n = edges.length + 1;
    const g = Array.from({ length: n }, () => []);
    for (const [x, y] of edges) {
        g[x].push(y);
        g[y].push(x);
    }
    let res = 0;
    const dfs = (node, parent) => {
        let valid = true;
        let treeSize = 0;
        let subTreeSize = 0;
        for (const child of g[node]) {
            if (child !== parent) {
                const size = dfs(child, node);
                if (subTreeSize === 0) {
                    subTreeSize = size;
                } else if (size !== subTreeSize) {
                    valid = false;
                }
                treeSize += size;
            }
        }
        if (valid) {
            res++;
        }
        return treeSize + 1;
    };

    dfs(0, -1);
    return res;
};
```

```TypeScript
function countGoodNodes(edges: number[][]): number {
    const n = edges.length + 1;
    const g: number[][] = Array.from({ length: n }, () => []);
    for (const [x, y] of edges) {
        g[x].push(y);
        g[y].push(x);
    }
    let res = 0;
    const dfs = (node: number, parent: number): number => {
        let valid = true;
        let treeSize = 0;
        let subTreeSize = 0;

        for (const child of g[node]) {
            if (child !== parent) {
                const size = dfs(child, node);
                if (subTreeSize === 0) {
                    subTreeSize = size;
                } else if (size !== subTreeSize) {
                    valid = false;
                }
                treeSize += size;
            }
        }
        if (valid) {
            res++;
        }
        return treeSize + 1;
    };
    dfs(0, -1);
    return res;
};
```

```Rust
impl Solution {
    pub fn count_good_nodes(edges: Vec<Vec<i32>>) -> i32 {
        let n = edges.len() + 1;
        let mut g = vec![vec![]; n];
        let mut res = 0;
        for edge in edges {
            let (x, y) = (edge[0] as usize, edge[1] as usize);
            g[x].push(y);
            g[y].push(x);
        }

        fn dfs(node: usize, parent: isize, g: &Vec<Vec<usize>>, res: &mut i32) -> usize {
            let mut valid = true;
            let mut tree_size = 0;
            let mut sub_tree_size = 0;

            for &child in &g[node] {
                if child != parent as usize {
                    let size = dfs(child, node as isize, g, res);
                    if sub_tree_size == 0 {
                        sub_tree_size = size;
                    } else if size != sub_tree_size {
                        valid = false;
                    }
                    tree_size += size;
                }
            }
            if valid {
                *res += 1;
            }
            tree_size + 1
        }

        dfs(0, -1, &g, &mut res);
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(n)$。
