### [可以被 K 整除连通块的最大数目](https://leetcode.cn/problems/maximum-number-of-k-divisible-components/solutions/3835599/ke-yi-bei-k-zheng-chu-lian-tong-kuai-de-rq9y1/)

#### 方法一：深度优先搜索

**思路与算法**

题目要求我们将给定的树分割成若干个部分，每个部分中节点值之和都可以被 $k$ 整除，要求分割的部分数量最多。

由于数据保证 $values$ 之和，即所有节点的权值和，能够被 $k$ 整除。因此，合法分割的方案一定存在。若一条边可以被删除，则它所连接的两个部分各自都能被 $k$ 整除。我们可以使用深度优先搜索计算以每个节点为根结点的子树的节点权值的总和。由于所有权值和是 $k$ 的倍数，只需要子树的权值和能够被 $k$ 整除，它就可以与父节点分割成两个部分。

**代码**

```C++
class Solution {
public:
    int maxKDivisibleComponents(int n, vector<vector<int>>& edges, vector<int>& values, int k) {
        vector<vector<int>> graph(n);
        for (auto& edge : edges) {
            int u = edge[0], v = edge[1];
            graph[u].push_back(v);
            graph[v].push_back(u);
        }

        int result = 0;
        function<long long(int, int)> dfs = [&](int node, int parent) -> long long {
            long long sum = values[node];
            for (int neighbor : graph[node]) {
                if (neighbor != parent) {
                    sum += dfs(neighbor, node);
                }
            }
            if (sum % k == 0) {
                ++result;
            }
            return sum;
        };
        dfs(0, -1);
        return result;
    }
};
```

```Python
class Solution:
    def maxKDivisibleComponents(self, n: int, edges: List[List[int]], values: List[int], k: int) -> int:
        graph = [[] for _ in range(n)]
        for u, v in edges:
            graph[u].append(v)
            graph[v].append(u)
        result = 0

        def dfs(node, parent):
            nonlocal result
            total = values[node]
            for neighbor in graph[node]:
                if neighbor != parent:
                    total += dfs(neighbor, node)
            if total % k == 0:
                result += 1
            return total

        dfs(0, -1)
        return result
```

```Java
class Solution {
    public int maxKDivisibleComponents(int n, int[][] edges, int[] values, int k) {
        List<Integer>[] graph = new ArrayList[n];
        for (int i = 0; i < n; ++i) {
            graph[i] = new ArrayList<>();
        }
        for (int[] edge : edges) {
            int u = edge[0], v = edge[1];
            graph[u].add(v);
            graph[v].add(u);
        }
        this.graph = graph;
        this.values = values;
        this.divisor = k;
        this.answer = 0;
        dfs(0, -1);
        return answer;
    }

    private List<Integer>[] graph;
    private int[] values;
    private int divisor;
    private int answer;

    private long dfs(int node, int parent) {
        long sum = values[node];
        for (int neighbor : graph[node]) {
            if (neighbor != parent) {
                sum += dfs(neighbor, node);
            }
        }
        if (sum % divisor == 0) {
            answer++;
        }
        return sum;
    }
}
```

```Go
func maxKDivisibleComponents(n int, edges [][]int, values []int, k int) int {
    graph := make([][]int, n)
    for _, edge := range edges {
        u, v := edge[0], edge[1]
        graph[u] = append(graph[u], v)
        graph[v] = append(graph[v], u)
    }
    result := 0
    var dfs func(int, int) int64
    dfs = func(node, parent int) int64 {
        sum := int64(values[node])
        for _, neighbor := range graph[node] {
            if neighbor != parent {
                sum += dfs(neighbor, node)
            }
        }
        if sum%int64(k) == 0 {
            result++
        }
        return sum
    }
    dfs(0, -1)
    return result
}
```

```C
typedef struct EdgeNode {
    int to;
    struct EdgeNode* next;
} EdgeNode;

static EdgeNode** graphC;
static int divisorC;
static int resultC;
static int* valuesC;

static void addEdge(int u, int v) {
    EdgeNode* node = (EdgeNode*)malloc(sizeof(EdgeNode));
    node->to = v;
    node->next = graphC[u];
    graphC[u] = node;
}

static long long dfs(int node, int parent) {
    long long sum = valuesC[node];
    for (EdgeNode* edge = graphC[node]; edge != NULL; edge = edge->next) {
        int neighbor = edge->to;
        if (neighbor != parent) {
            sum += dfs(neighbor, node);
        }
    }
    if (sum % divisorC == 0) {
        resultC++;
    }
    return sum;
}

int maxKDivisibleComponents(int n, int** edges, int edgesSize, int* edgesColSize, int* values, int valuesSize, int k) {
    (void)edgesColSize;
    (void)valuesSize;
    graphC = (EdgeNode**)calloc(n, sizeof(EdgeNode*));
    for (int i = 0; i < edgesSize; ++i) {
        int u = edges[i][0];
        int v = edges[i][1];
        addEdge(u, v);
        addEdge(v, u);
    }
    valuesC = values;
    divisorC = k;
    resultC = 0;
    dfs(0, -1);
    for (int i = 0; i < n; ++i) {
        EdgeNode* current = graphC[i];
        while (current != NULL) {
            EdgeNode* next = current->next;
            free(current);
            current = next;
        }
    }
    free(graphC);
    return resultC;
}
```

```CSharp
public class Solution {
    public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k) {
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; ++i) {
            graph[i] = new List<int>();
        }
        foreach (var edge in edges) {
            int u = edge[0], v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }

        int result = 0;

        long Dfs(int node, int parent) {
            long sum = values[node];
            foreach (int neighbor in graph[node]) {
                if (neighbor != parent) {
                    sum += Dfs(neighbor, node);
                }
            }
            if (sum % k == 0) {
                result++;
            }
            return sum;
        }

        Dfs(0, -1);
        return result;
    }
}
```

```JavaScript
var maxKDivisibleComponents = function(n, edges, values, k) {
    const graph = Array.from({ length: n }, () => []);
    for (const edge of edges) {
        const u = edge[0], v = edge[1];
        graph[u].push(v);
        graph[v].push(u);
    }
    let result = 0;
    function dfs(node, parent) {
        let sum = values[node];
        for (const neighbor of graph[node]) {
            if (neighbor !== parent) {
                sum += dfs(neighbor, node);
            }
        }
        if (sum % k === 0) {
            result++;
        }
        return sum;
    }
    dfs(0, -1);
    return result;
};
```

```TypeScript
function maxKDivisibleComponents(n: number, edges: number[][], values: number[], k: number): number {
    const graph: number[][] = Array.from({ length: n }, () => []);
    for (const edge of edges) {
        const u = edge[0], v = edge[1];
        graph[u].push(v);
        graph[v].push(u);
    }
    let result = 0;
    function dfs(node: number, parent: number): number {
        let sum = values[node];
        for (const neighbor of graph[node]) {
            if (neighbor !== parent) {
                sum += dfs(neighbor, node);
            }
        }
        if (sum % k === 0) {
            result++;
        }
        return sum;
    }
    dfs(0, -1);
    return result;
}
```

```Rust
impl Solution {
    pub fn max_k_divisible_components(n: i32, edges: Vec<Vec<i32>>, values: Vec<i32>, k: i32) -> i32 {
        let n = n as usize;
        let mut graph = vec![Vec::new(); n];
        for edge in edges {
            let u = edge[0] as usize;
            let v = edge[1] as usize;
            graph[u].push(v);
            graph[v].push(u);
        }
        let mut result = 0;
        fn dfs(node: usize, parent: i32, graph: &Vec<Vec<usize>>, values: &Vec<i32>, k: i32, result: &mut i32) -> i64 {
            let mut sum = values[node] as i64;
            for &neighbor in &graph[node] {
                if neighbor as i32 != parent {
                    sum += dfs(neighbor, node as i32, graph, values, k, result);
                }
            }
            if sum % (k as i64) == 0 {
                *result += 1;
            }
            sum
        }
        dfs(0, -1, &graph, &values, k, &mut result);
        result
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是树中的节点数。树中的每个节点都会被遍历一次。
- 空间复杂度：$O(n)$。
