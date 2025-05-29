### [连接两棵树后最大目标节点数目 II](https://leetcode.cn/problems/maximize-the-number-of-target-nodes-after-connecting-trees-ii/solutions/3677384/lian-jie-liang-ke-shu-hou-zui-da-mu-biao-0qy7/)

#### 方法一：深度优先搜索

对于第 $i$ 个查询，将两颗树连接后，查询的结果由两部分组成：

1. 第一颗树中到第一颗树节点 $i$ 的距离为偶数的节点数目
2. 第二颗树中到第一颗树节点 $i$ 的距离为偶数的节点数目

假设一颗树中，节点 $u$ 的目标节点数目为 $count$，并且节点 $v$ 是节点 $u$ 的目标节点，那么节点 $v$ 的目标节点数目也为 $count$。

为了能快速得到某个节点的目标节点数目，我们先通过深度优先搜索对一颗树进行染色，$0$ 表示白色，$1$ 表示黑色，首先对根节点染成白色，然后将与根节点的距离为偶数的节点也染成白色，其余节点染成黑色，同时将白色节点与黑色节点的节点数目都保存下来。显然，对于任一节点，它的目标节点数目都是与它同颜色的节点数目。

我们通过染色法，得到两个一维数组 $color_1$ 和 $color_2$ 分别代表两棵树的染色结果，以及两颗树中白色和黑色节点的数目。那么对于第 $i$ 个查询，查询结果的两部分计算如下：

1. 通过 $color_1[i]$ 找到节点 $i$ 的颜色，那么对应颜色的节点数目即为该部分的结果
2. 不管两颗树如何连接，节点 $i$ 在第二颗树上的目标节点数目显然都只能是一种颜色的，因此该部分的结果便是第二颗树上白色和黑色节点数目的最大值

```C++
class Solution {
public:
    int dfs(int node, int parent, int depth, const vector<vector<int>>& children, vector<int>& color) {
        int res = 1 - depth % 2;
        color[node] = depth % 2;
        for (int child : children[node]) {
            if (child == parent) {
                continue;
            }
            res += dfs(child, node, depth + 1, children, color);
        }
        return res;
    }

    vector<int> build(const vector<vector<int>>& edges, vector<int>& color) {
        int n = edges.size() + 1;
        vector<vector<int>> children(n);
        for (const auto& edge : edges) {
            children[edge[0]].push_back(edge[1]);
            children[edge[1]].push_back(edge[0]);
        }
        int res = dfs(0, -1, 0, children, color);
        return {res, n - res};
    }

    vector<int> maxTargetNodes(vector<vector<int>>& edges1, vector<vector<int>>& edges2) {
        int n = edges1.size() + 1, m = edges2.size() + 1;
        vector<int> color1(n);
        vector<int> color2(m);
        vector<int> count1 = build(edges1, color1);
        vector<int> count2 = build(edges2, color2);
        vector<int> res(edges1.size() + 1);
        for (int i = 0; i < n; i++) {
            res[i] = count1[color1[i]] + max(count2[0], count2[1]);
        }
        return res;
    }
};
```

```Go
func maxTargetNodes(edges1 [][]int, edges2 [][]int) []int {
    var dfs func(node, parent, depth int, children [][]int, color []int) int
    dfs = func(node, parent, depth int, children [][]int, color []int) int {
        res := 1 - depth % 2
        color[node] = depth % 2
        for _, child := range children[node] {
            if child == parent {
                continue
            }
            res += dfs(child, node, depth + 1, children, color)
        }
        return res
    }

    build := func(edges [][]int, color []int) []int {
        n := len(edges) + 1
        children := make([][]int, n)
        for _, edge := range edges {
            u, v := edge[0], edge[1]
            children[u] = append(children[u], v)
            children[v] = append(children[v], u)
        }
        res := dfs(0, -1, 0, children, color)
        return []int{res, n - res}
    }

    n := len(edges1) + 1
    m := len(edges2) + 1
    color1 := make([]int, n)
    color2 := make([]int, m)
    count1 := build(edges1, color1)
    count2 := build(edges2, color2)
    res := make([]int, n)
    for i := 0; i < n; i++ {
        res[i] = count1[color1[i]] + max(count2[0], count2[1])
    }
    return res
}
```

```Python
class Solution:
    def maxTargetNodes(self, edges1: List[List[int]], edges2: List[List[int]]) -> List[int]:
        def dfs(node, parent, depth, children, color):
            res = 1 - depth % 2
            color[node] = depth % 2
            for child in children[node]:
                if child == parent:
                    continue
                res += dfs(child, node, depth + 1, children, color)
            return res

        def build(edges, color):
            n = len(edges) + 1
            children = [[] for _ in range(n)]
            for u, v in edges:
                children[u].append(v)
                children[v].append(u)
            res = dfs(0, -1, 0, children, color)
            return [res, n - res]

        n = len(edges1) + 1
        m = len(edges2) + 1
        color1 = [0] * n
        color2 = [0] * m
        count1 = build(edges1, color1)
        count2 = build(edges2, color2)
        res = [0] * n
        for i in range(n):
            res[i] = count1[color1[i]] + max(count2[0], count2[1])
        return res
```

```Java
class Solution {
    public int[] maxTargetNodes(int[][] edges1, int[][] edges2) {
        int n = edges1.length + 1, m = edges2.length + 1;
        int[] color1 = new int[n];
        int[] color2 = new int[m];
        int[] count1 = build(edges1, color1);
        int[] count2 = build(edges2, color2);
        int[] res = new int[n];
        for (int i = 0; i < n; i++) {
            res[i] = count1[color1[i]] + Math.max(count2[0], count2[1]);
        }
        return res;
    }

    private int[] build(int[][] edges, int[] color) {
        int n = edges.length + 1;
        List<List<Integer>> children = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            children.add(new ArrayList<>());
        }
        for (int[] edge : edges) {
            children.get(edge[0]).add(edge[1]);
            children.get(edge[1]).add(edge[0]);
        }
        int res = dfs(0, -1, 0, children, color);
        return new int[]{res, n - res};
    }

    private int dfs(int node, int parent, int depth, List<List<Integer>> children, int[] color) {
        int res = 1 - depth % 2;
        color[node] = depth % 2;
        for (int child : children.get(node)) {
            if (child == parent) {
                continue;
            }
            res += dfs(child, node, depth + 1, children, color);
        }
        return res;
    }
}
```

```TypeScript
function maxTargetNodes(edges1: number[][], edges2: number[][]): number[] {
    function dfs(node: number, parent: number, depth: number, children: number[][], color: number[]): number {
        let res = 1 - depth % 2;
        color[node] = depth % 2;
        for (let child of children[node]) {
            if (child === parent) {
                continue;
            }
            res += dfs(child, node, depth + 1, children, color);
        }
        return res;
    }

    function build(edges: number[][], color: number[]): number[] {
        const n = edges.length + 1;
        const children: number[][] = Array.from({ length: n }, () => []);
        for (const [u, v] of edges) {
            children[u].push(v);
            children[v].push(u);
        }
        const res = dfs(0, -1, 0, children, color);
        return [res, n - res];
    }

    const n = edges1.length + 1;
    const m = edges2.length + 1;
    const color1: number[] = new Array(n).fill(0);
    const color2: number[] = new Array(m).fill(0);
    const count1 = build(edges1, color1);
    const count2 = build(edges2, color2);
    const res: number[] = new Array(n).fill(0);
    for (let i = 0; i < n; i++) {
        res[i] = count1[color1[i]] + Math.max(count2[0], count2[1]);
    }
    return res;
}
```

```JavaScript
var maxTargetNodes = function(edges1, edges2) {
    function dfs(node, parent, depth, children, color) {
        let res = 1 - depth % 2;
        color[node] = depth % 2;
        for (let child of children[node]) {
            if (child === parent) {
                continue;
            }
            res += dfs(child, node, depth + 1, children, color);
        }
        return res;
    }

    function build(edges, color) {
        const n = edges.length + 1;
        const children = Array.from({ length: n }, () => []);
        for (const [u, v] of edges) {
            children[u].push(v);
            children[v].push(u);
        }
        const res = dfs(0, -1, 0, children, color);
        return [res, n - res];
    }

    const n = edges1.length + 1;
    const m = edges2.length + 1;
    const color1 = new Array(n).fill(0);
    const color2 = new Array(m).fill(0);
    const count1 = build(edges1, color1);
    const count2 = build(edges2, color2);
    const res = new Array(n).fill(0);
    for (let i = 0; i < n; i++) {
        res[i] = count1[color1[i]] + Math.max(count2[0], count2[1]);
    }
    return res;
};
```

```CSharp
public class Solution {
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2) {
        int n = edges1.Length + 1, m = edges2.Length + 1;
        int[] color1 = new int[n];
        int[] color2 = new int[m];
        int[] count1 = Build(edges1, color1);
        int[] count2 = Build(edges2, color2);
        int[] res = new int[n];
        for (int i = 0; i < n; i++) {
            res[i] = count1[color1[i]] + Math.Max(count2[0], count2[1]);
        }
        return res;
    }

    private int[] Build(int[][] edges, int[] color) {
        int n = edges.Length + 1;
        List<int>[] children = new List<int>[n];
        for (int i = 0; i < n; i++) {
            children[i] = new List<int>();
        }
        foreach (var edge in edges) {
            children[edge[0]].Add(edge[1]);
            children[edge[1]].Add(edge[0]);
        }
        int res = Dfs(0, -1, 0, children, color);
        return new int[] { res, n - res };
    }

    private int Dfs(int node, int parent, int depth, List<int>[] children, int[] color) {
        int res = 1 - depth % 2;
        color[node] = depth % 2;
        foreach (int child in children[node]) {
            if (child == parent) {
                continue;
            }
            res += Dfs(child, node, depth + 1, children, color);
        }
        return res;
    }
}
```

```C
int dfs(int node, int parent, int depth, int** children, int* childrenColSize, int* color) {
    int res = 1 - depth % 2;
    color[node] = depth % 2;
    for (int i = 0; i < childrenColSize[node]; i++) {
        int child = children[node][i];
        if (child == parent) continue;
        res += dfs(child, node, depth + 1, children, childrenColSize, color);
    }
    return res;
}

int* build(int** edges, int edgesSize, int* color) {
    int n = edgesSize + 1;
    int** children = (int**)malloc(n * sizeof(int*));
    int* childrenColSize = (int*)calloc(n, sizeof(int));
    for (int i = 0; i < edgesSize; i++) {
        childrenColSize[edges[i][0]]++;
        childrenColSize[edges[i][1]]++;
    }
    for (int i = 0; i < n; i++) {
        children[i] = (int*)malloc(childrenColSize[i] * sizeof(int));
        childrenColSize[i] = 0;
    }
    for (int i = 0; i < edgesSize; i++) {
        int u = edges[i][0], v = edges[i][1];
        children[u][childrenColSize[u]++] = v;
        children[v][childrenColSize[v]++] = u;
    }
    int res = dfs(0, -1, 0, children, childrenColSize, color);
    int* result = (int*)malloc(2 * sizeof(int));
    result[0] = res;
    result[1] = n - res;
    for (int i = 0; i < n; i++) {
        free(children[i]);
    }
    free(children);
    free(childrenColSize);
    return result;
}

int* maxTargetNodes(int** edges1, int edges1Size, int* edges1ColSize, int** edges2, int edges2Size, int* edges2ColSize, int* returnSize) {
    int n = edges1Size + 1;
    int m = edges2Size + 1;
    int* color1 = (int*)calloc(n, sizeof(int));
    int* color2 = (int*)calloc(m, sizeof(int));
    int* count1 = build(edges1, edges1Size, color1);
    int* count2 = build(edges2, edges2Size, color2);
    int* res = (int*)malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) {
        res[i] = count1[color1[i]] + (count2[0] > count2[1] ? count2[0] : count2[1]);
    }
    *returnSize = n;
    free(color1);
    free(color2);
    free(count1);
    free(count2);
    return res;
}
```

```Rust
impl Solution {
    pub fn max_target_nodes(edges1: Vec<Vec<i32>>, edges2: Vec<Vec<i32>>) -> Vec<i32> {
        fn dfs(
            node: usize,
            parent: isize,
            depth: usize,
            children: &Vec<Vec<usize>>,
            color: &mut Vec<usize>,
        ) -> i32 {
            let mut res = 1 - (depth % 2) as i32;
            color[node] = depth % 2;
            for &child in &children[node] {
                if child as isize == parent {
                    continue;
                }
                res += dfs(child, node as isize, depth + 1, children, color);
            }
            res
        }

        fn build(edges: &Vec<Vec<i32>>, color: &mut Vec<usize>) -> Vec<i32> {
            let n = edges.len() + 1;
            let mut children = vec![vec![]; n];
            for edge in edges {
                let u = edge[0] as usize;
                let v = edge[1] as usize;
                children[u].push(v);
                children[v].push(u);
            }
            let res = dfs(0, -1, 0, &children, color);
            vec![res, (n as i32) - res]
        }

        let n = edges1.len() + 1;
        let m = edges2.len() + 1;
        let mut color1 = vec![0; n];
        let mut color2 = vec![0; m];
        let count1 = build(&edges1, &mut color1);
        let count2 = build(&edges2, &mut color2);
        let mut res = vec![0; n];
        for i in 0..n {
            res[i] = count1[color1[i]] + count2[0].max(count2[1]);
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m)$，其中 $n$ 和 $m$ 分别是 $edges_1$ 和 $edges_2$ 对应的无向树的节点数目。
- 空间复杂度：$O(n+m)$。
