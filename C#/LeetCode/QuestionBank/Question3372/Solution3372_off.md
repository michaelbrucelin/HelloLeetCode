### [连接两棵树后最大目标节点数目 I](https://leetcode.cn/problems/maximize-the-number-of-target-nodes-after-connecting-trees-i/solutions/3677383/lian-jie-liang-ke-shu-hou-zui-da-mu-biao-730m/)

#### 方法一：深度优先搜索

根据题意，对于第 $i$ 个查询，使用第一颗树的节点 $i$ 去连接第二颗树的节点时，第二颗树的节点与第一颗树的节点 $i$ 的距离会更小，目标节点也更多。假设连接的第二颗树的节点为 $j$，那么我们需要统计第一颗树中和节点 $i$ 距离小于等于 $k$ 的节点数目 $count_1​[i]$，以及第二颗树中和第一颗树的节点 $i$ 的距离小于等于 $k-1$ 的节点数目 $count_2​[j]$。

注意到 $count_2​[j]$ 的计算与查询无关，因此我们可以使用深度优先搜索预计算第二颗树中与节点 $j$ 的距离小于等于 $k-1$ 的节点数目 $count_2​[j]$，然后枚举节点 $j$，计算 $count_2​[j]$ 的最大值 $maxCount_2$​。

对于第 $i$ 个查询，我们使用深度优先搜索计算 $count_1​[i]$ 的值，然后加上 $maxCount_2$​ 就得到查询的结果。

```C++
class Solution {
public:
    int dfs(int node, int parent, const vector<vector<int>>& children, int k) {
        if (k < 0) {
            return 0;
        }
        int res = 1;
        for (int child : children[node]) {
            if (child == parent) {
                continue;
            }
            res += dfs(child, node, children, k - 1);
        }
        return res;
    }

    vector<int> build(const vector<vector<int>>& edges, int k) {
        int n = edges.size() + 1;
        vector<vector<int>> children(n);
        for (const auto& edge : edges) {
            children[edge[0]].push_back(edge[1]);
            children[edge[1]].push_back(edge[0]);
        }
        vector<int> res(n);
        for (int i = 0; i < n; i++) {
            res[i] = dfs(i, -1, children, k);
        }
        return res;
    }

    vector<int> maxTargetNodes(vector<vector<int>>& edges1, vector<vector<int>>& edges2, int k) {
        int n = edges1.size() + 1, m = edges2.size() + 1;
        vector<int> count1 = build(edges1, k);
        vector<int> count2 = build(edges2, k - 1);
        int maxCount2 = *max_element(count2.begin(), count2.end());
        vector<int> res(n);
        for (int i = 0; i < n; i++) {
            res[i] = count1[i] + maxCount2;
        }
        return res;
    }
};
```

```Go
func maxTargetNodes(edges1 [][]int, edges2 [][]int, k int) []int {
    var dfs func(node, parent int, children [][]int, k int) int
    dfs = func(node, parent int, children [][]int, k int) int {
        if k < 0 {
            return 0
        }
        res := 1
        for _, child := range children[node] {
            if child == parent {
                continue
            }
            res += dfs(child, node, children, k-1)
        }
        return res
    }

    build := func(edges [][]int, k int) []int {
        n := len(edges) + 1
        children := make([][]int, n)
        for _, edge := range edges {
            u, v := edge[0], edge[1]
            children[u] = append(children[u], v)
            children[v] = append(children[v], u)
        }
        res := make([]int, n)
        for i := 0; i < n; i++ {
            res[i] = dfs(i, -1, children, k)
        }
        return res
    }

    n := len(edges1) + 1
    count1 := build(edges1, k)
    count2 := build(edges2, k - 1)
    maxCount2 := 0
    for _, c := range count2 {
        if c > maxCount2 {
            maxCount2 = c
        }
    }
    res := make([]int, n)
    for i := 0; i < n; i++ {
        res[i] = count1[i] + maxCount2
    }
    return res
}
```

```Python
class Solution:
    def maxTargetNodes(self, edges1: List[List[int]], edges2: List[List[int]], k: int) -> List[int]:
        def dfs(node: int, parent: int, children: List[List[int]], k: int) -> int:
            if k < 0:
                return 0
            res = 1
            for child in children[node]:
                if child == parent:
                    continue
                res += dfs(child, node, children, k - 1)
            return res

        def build(edges: List[List[int]], k: int) -> List[int]:
            n = len(edges) + 1
            children = [[] for _ in range(n)]
            for u, v in edges:
                children[u].append(v)
                children[v].append(u)
            res = [0] * n
            for i in range(n):
                res[i] = dfs(i, -1, children, k)
            return res

        n = len(edges1) + 1
        count1 = build(edges1, k)
        count2 = build(edges2, k - 1)
        maxCount2 = max(count2)
        res = [count1[i] + maxCount2 for i in range(n)]
        return res
```

```Java
class Solution {
    public int[] maxTargetNodes(int[][] edges1, int[][] edges2, int k) {
        int n = edges1.length + 1, m = edges2.length + 1;
        int[] count1 = build(edges1, k);
        int[] count2 = build(edges2, k - 1);
        int maxCount2 = 0;
        for (int c : count2) {
            if (c > maxCount2) {
                maxCount2 = c;
            }
        }
        int[] res = new int[n];
        for (int i = 0; i < n; i++) {
            res[i] = count1[i] + maxCount2;
        }
        return res;
    }

    private int[] build(int[][] edges, int k) {
        int n = edges.length + 1;
        List<List<Integer>> children = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            children.add(new ArrayList<>());
        }
        for (int[] edge : edges) {
            children.get(edge[0]).add(edge[1]);
            children.get(edge[1]).add(edge[0]);
        }
        int[] res = new int[n];
        for (int i = 0; i < n; i++) {
            res[i] = dfs(i, -1, children, k);
        }
        return res;
    }

    private int dfs(int node, int parent, List<List<Integer>> children, int k) {
        if (k < 0) {
            return 0;
        }
        int res = 1;
        for (int child : children.get(node)) {
            if (child == parent) {
                continue;
            }
            res += dfs(child, node, children, k - 1);
        }
        return res;
    }
}
```

```TypeScript
function maxTargetNodes(edges1: number[][], edges2: number[][], k: number): number[] {
    function dfs(node: number, parent: number, children: number[][], k: number): number {
        if (k < 0) {
            return 0;
        }
        let res = 1;
        for (const child of children[node]) {
            if (child === parent) {
                continue;
            }
            res += dfs(child, node, children, k - 1);
        }
        return res;
    }

    function build(edges: number[][], k: number): number[] {
        const n = edges.length + 1;
        const children: number[][] = Array.from({ length: n }, () => []);
        for (const [u, v] of edges) {
            children[u].push(v);
            children[v].push(u);
        }
        const res: number[] = Array(n);
        for (let i = 0; i < n; i++) {
            res[i] = dfs(i, -1, children, k);
        }
        return res;
    }

    const n = edges1.length + 1;
    const count1 = build(edges1, k);
    const count2 = build(edges2, k - 1);
    const maxCount2 = Math.max(...count2);
    const res: number[] = Array(n);
    for (let i = 0; i < n; i++) {
        res[i] = count1[i] + maxCount2;
    }
    return res;
}
```

```JavaScript
var maxTargetNodes = function(edges1, edges2, k) {
    const dfs = (node, parent, children, k) => {
        if (k < 0) {
            return 0;
        }
        let res = 1;
        for (const child of children[node]) {
            if (child === parent) {
                continue;
            }
            res += dfs(child, node, children, k - 1);
        }
        return res;
    };

    const build = (edges, k) => {
        const n = edges.length + 1;
        const children = Array.from({ length: n }, () => []);
        for (const [u, v] of edges) {
            children[u].push(v);
            children[v].push(u);
        }
        const res = Array(n);
        for (let i = 0; i < n; i++) {
            res[i] = dfs(i, -1, children, k);
        }
        return res;
    };

    const n = edges1.length + 1;
    const count1 = build(edges1, k);
    const count2 = build(edges2, k - 1);
    const maxCount2 = Math.max(...count2);
    const res = Array(n);
    for (let i = 0; i < n; i++) {
        res[i] = count1[i] + maxCount2;
    }
    return res;
};
```

```CSharp
public class Solution {
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k) {
        int n = edges1.Length + 1, m = edges2.Length + 1;
        int[] count1 = Build(edges1, k);
        int[] count2 = Build(edges2, k - 1);
        int maxCount2 = 0;
        foreach (int c in count2) {
            if (c > maxCount2) {
                maxCount2 = c;
            }
        }
        int[] res = new int[n];
        for (int i = 0; i < n; i++) {
            res[i] = count1[i] + maxCount2;
        }
        return res;
    }

    private int[] Build(int[][] edges, int k) {
        int n = edges.Length + 1;
        List<List<int>> children = new List<List<int>>();
        for (int i = 0; i < n; i++) {
            children.Add(new List<int>());
        }
        foreach (var edge in edges) {
            children[edge[0]].Add(edge[1]);
            children[edge[1]].Add(edge[0]);
        }
        int[] res = new int[n];
        for (int i = 0; i < n; i++) {
            res[i] = Dfs(i, -1, children, k);
        }
        return res;
    }

    private int Dfs(int node, int parent, List<List<int>> children, int k) {
        if (k < 0) {
            return 0;
        }
        int res = 1;
        foreach (int child in children[node]) {
            if (child == parent) {
                continue;
            }
            res += Dfs(child, node, children, k - 1);
        }
        return res;
    }
}
```

```C
int dfs(int node, int parent, int** children, int* childrenColSize, int k) {
    if (k < 0) {
        return 0;
    }
    int res = 1;
    for (int i = 0; i < childrenColSize[node]; i++) {
        int child = children[node][i];
        if (child == parent) {
            continue;
        }
        res += dfs(child, node, children, childrenColSize, k - 1);
    }
    return res;
}

int* build(int** edges, int edgesSize, int k) {
    int n = edgesSize + 1;
    int** children = (int**)malloc(n * sizeof(int*));
    int* childrenColSize = (int*)malloc(n * sizeof(int));
    memset(childrenColSize, 0, n * sizeof(int));
    for (int i = 0; i < edgesSize; i++) {
        childrenColSize[edges[i][0]]++;
        childrenColSize[edges[i][1]]++;
    }
    for (int i = 0; i < n; i++) {
        children[i] = (int *)malloc(childrenColSize[i] * sizeof(int));
        childrenColSize[i] = 0;
    }
    for (int i = 0; i < edgesSize; i++) {
        children[edges[i][0]][childrenColSize[edges[i][0]]++] = edges[i][1];
        children[edges[i][1]][childrenColSize[edges[i][1]]++] = edges[i][0];
    }
    int* res = (int*)malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) {
        res[i] = dfs(i, -1, children, childrenColSize, k);
    }
    for (int i = 0; i < n; i++) {
        free(children[i]);
    }
    free(children);
    free(childrenColSize);
    return res;
}

int* maxTargetNodes(int** edges1, int edges1Size, int* edges1ColSize, int** edges2, int edges2Size, int* edges2ColSize, int k, int* returnSize) {
    int n = edges1Size + 1;
    int* count1 = build(edges1, edges1Size, k);
    int* count2 = build(edges2, edges2Size, k - 1);
    int maxCount = 0;
    for (int i = 0; i < edges2Size + 1; i++) {
        if (count2[i] > maxCount) {
            maxCount = count2[i];
        }
    }
    int* res = (int*)malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) {
        res[i] = count1[i] + maxCount;
    }
    *returnSize = n;
    free(count1);
    free(count2);
    return res;
}
```

```Rust
impl Solution {
    pub fn max_target_nodes(edges1: Vec<Vec<i32>>, edges2: Vec<Vec<i32>>, k: i32) -> Vec<i32> {
        fn dfs(node: usize, parent: i32, children: &Vec<Vec<i32>>, k: i32) -> i32 {
            if k < 0 {
                return 0;
            }
            let mut res = 1;
            for &child in &children[node] {
                if child == parent {
                    continue;
                }
                res += dfs(child as usize, node as i32, children, k - 1);
            }
            res
        }

        fn build(edges: Vec<Vec<i32>>, k: i32) -> Vec<i32> {
            let n = edges.len() + 1;
            let mut children = vec![vec![]; n];
            for edge in edges {
                let u = edge[0] as usize;
                let v = edge[1] as usize;
                children[u].push(v as i32);
                children[v].push(u as i32);
            }
            let mut res = vec![0; n];
            for i in 0..n {
                res[i] = dfs(i, -1, &children, k);
            }
            res
        }

        let n = edges1.len() + 1;
        let count1 = build(edges1, k);
        let count2 = build(edges2, k - 1);
        let max_count2 = *count2.iter().max().unwrap();
        let mut res = vec![0; n];
        for i in 0..n {
            res[i] = count1[i] + max_count2;
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2+m^2)$，其中 $n$ 和 $m$ 分别是 $edges_1$​ 和 $edges_2$​ 对应的无向树的节点数目。
- 空间复杂度：$O(n+m)$。
