### [最大化一张图中的路径价值](https://leetcode.cn/problems/maximum-path-quality-of-a-graph/solutions/1092073/zui-da-hua-yi-zhang-tu-zhong-de-lu-jing-yim5i/)

#### 方法一：枚举所有可能的路径

**思路与算法**

仔细阅读题目描述我们可以发现，$time_j$ 的最小值为 $10$，而 $maxTime$ 的最大值为 $100$。这说明我们**至多**只会经过图上的 $10$ 条边。由于图中每个节点的度数都不超过 $4$，因此我们可以枚举所有从节点 $0$ 开始的路径。

我们可以使用递归 + 回溯的方法进行枚举。递归函数记录当前所在的节点编号，已经过的路径的总时间以及节点的价值之和。如果当前在节点 $u$，我们可以枚举与 $u$ 直接相连的节点 $v$ 进行递归搜索。在搜索的过程中，如果我们回到了节点 $0$，就可以对答案进行更新；如果总时间超过了 $maxTime$，我们需要停止搜索，进行回溯。

**代码**

```C++
class Solution {
public:
    int maximalPathQuality(vector<int>& values, vector<vector<int>>& edges, int maxTime) {
        int n = values.size();
        vector<vector<pair<int, int>>> g(n);
        for (const auto& edge: edges) {
            g[edge[0]].emplace_back(edge[1], edge[2]);
            g[edge[1]].emplace_back(edge[0], edge[2]);
        }
        
        vector<int> visited(n);
        visited[0] = true;
        int ans = 0;
        
        function<void(int, int, int)> dfs = [&](int u, int time, int value) {
            if (u == 0) {
                ans = max(ans, value);
            }
            for (const auto& [v, dist]: g[u]) {
                if (time + dist <= maxTime) {
                    if (!visited[v]) {
                        visited[v] = true;
                        dfs(v, time + dist, value + values[v]);
                        visited[v] = false;
                    }
                    else {
                        dfs(v, time + dist, value);
                    }
                }
            }
        };
        
        dfs(0, 0, values[0]);
        return ans;
    }
};
```

```Java
class Solution {
    int ans = 0;
    int[] values;
    int maxTime;
    List<int[]>[] g;
    boolean[] visited;

    public int maximalPathQuality(int[] values, int[][] edges, int maxTime) {
        this.values = values;
        this.maxTime = maxTime;
        int n = values.length;
        g = new List[n];
        for (int i = 0; i < n; i++) {
            g[i] = new ArrayList<int[]>();
        }
        for (int[] edge : edges) {
            g[edge[0]].add(new int[]{edge[1], edge[2]});
            g[edge[1]].add(new int[]{edge[0], edge[2]});
        }

        visited = new boolean[n];
        visited[0] = true;
        
        dfs(0, 0, values[0]);
        return ans;
    }

    public void dfs(int u, int time, int value) {
        if (u == 0) {
            ans = Math.max(ans, value);
        }
        for (int[] arr : g[u]) {
            int v = arr[0], dist = arr[1];
            if (time + dist <= maxTime) {
                if (!visited[v]) {
                    visited[v] = true;
                    dfs(v, time + dist, value + values[v]);
                    visited[v] = false;
                } else {
                    dfs(v, time + dist, value);
                }
            }
        }
    }
}
```

```CSharp
public class Solution {
    int ans = 0;
    int[] values;
    int maxTime;
    IList<int[]>[] g;
    bool[] visited;

    public int MaximalPathQuality(int[] values, int[][] edges, int maxTime) {
        this.values = values;
        this.maxTime = maxTime;
        int n = values.Length;
        g = new IList<int[]>[n];
        for (int i = 0; i < n; i++) {
            g[i] = new List<int[]>();
        }
        foreach (int[] edge in edges) {
            g[edge[0]].Add(new int[]{edge[1], edge[2]});
            g[edge[1]].Add(new int[]{edge[0], edge[2]});
        }

        visited = new bool[n];
        visited[0] = true;
        
        DFS(0, 0, values[0]);
        return ans;
    }

    public void DFS(int u, int time, int value) {
        if (u == 0) {
            ans = Math.Max(ans, value);
        }
        foreach (int[] arr in g[u]) {
            int v = arr[0], dist = arr[1];
            if (time + dist <= maxTime) {
                if (!visited[v]) {
                    visited[v] = true;
                    DFS(v, time + dist, value + values[v]);
                    visited[v] = false;
                } else {
                    DFS(v, time + dist, value);
                }
            }
        }
    }
}
```

```Python
class Solution:
    def maximalPathQuality(self, values: List[int], edges: List[List[int]], maxTime: int) -> int:
        g = defaultdict(list)
        for x, y, z in edges:
            g[x].append((y, z))
            g[y].append((x, z))
        
        visited = {0}
        ans = 0
        
        def dfs(u: int, time: int, value: int) -> None:
            if u == 0:
                nonlocal ans
                ans = max(ans, value)
            for v, dist in g[u]:
                if time + dist <= maxTime:
                    if v not in visited:
                        visited.add(v)
                        dfs(v, time + dist, value + values[v])
                        visited.discard(v)
                    else:
                        dfs(v, time + dist, value)
        
        dfs(0, 0, values[0])
        return ans
```

```C
typedef struct Element {
    int v;
    int dist;
    struct Element *next;
} Element;

Element *creatElement(int v, int dist) {
    Element *obj = (Element *)malloc(sizeof(Element));
    obj->v = v;
    obj->dist = dist;
    return obj;
}

void dfs(int *ans, int u, int time, int value, Element** g, bool* visited, int *values, int maxTime) {
    if (u == 0) {
        *ans = fmax(*ans, value);
    }
    for (Element *p = g[u]; p; p = p->next) {
        int v = p->v, dist = p->dist;
        if (time + dist <= maxTime) {
            if (!visited[v]) {
                visited[v] = 1;
                dfs(ans, v, time + dist, value + values[v], g, visited, values, maxTime);
                visited[v] = 0;
            } else {
                dfs(ans, v, time + dist, value, g, visited, values, maxTime);
            }
        }
    }
}

void freeList(Element *list) {
    while (list) {
        Element *p = list;
        list = list->next;
        free(p);
    }
}

int maximalPathQuality(int* values, int valuesSize, int** edges, int edgesSize, int* edgesColSize, int maxTime) {
    int n = valuesSize;
    Element **g = (Element **)malloc(sizeof(Element *) * n);
    for (int i = 0; i < n; i++) {
        g[i] = NULL;
    }
    for (int i = 0; i < edgesSize; i++) {
        int x = edges[i][0];
        int y = edges[i][1];
        int cost = edges[i][2];
        Element *ex = creatElement(y, cost);
        ex->next = g[x];
        g[x] = ex;
        Element *ey = creatElement(x, cost);
        ey->next = g[y];
        g[y] = ey;
    }
    int visited[n];
    memset(visited, 0, sizeof(visited));
    visited[0] = 1;
    int ans = 0;
    dfs(&ans, 0, 0, values[0], g, visited, values, maxTime);
    for (int i = 0; i < n; i++) {
        freeList(g[i]);
    }
    free(g);
    return ans;
}
```

```Go
func maximalPathQuality(values []int, edges [][]int, maxTime int) int {
    n := len(values)
    g := make([][][2]int, n)
    for _, edge := range edges {
        g[edge[0]] = append(g[edge[0]], [2]int{edge[1], edge[2]})
        g[edge[1]] = append(g[edge[1]], [2]int{edge[0], edge[2]})
    }

    visited := make([]bool, n)
    visited[0] = true
    ans := 0

    var dfs func(int, int, int)
    dfs = func(u, time, value int) {
        if u == 0 {
            ans = max(ans, value)
        }
        for _, e := range g[u] {
            v, dist := e[0], e[1]
            if time + dist <= maxTime {
                if !visited[v] {
                    visited[v] = true
                    dfs(v, time + dist, value + values[v])
                    visited[v] = false
                } else {
                    dfs(v, time+dist, value)
                }
            }
        }
    }

    dfs(0, 0, values[0])
    return ans
}
```

```JavaScript
var maximalPathQuality = function(values, edges, maxTime) {
    const n = values.length;
    const g = Array.from({ length: n }, () => []);
    for (const edge of edges) {
        g[edge[0]].push([edge[1], edge[2]]);
        g[edge[1]].push([edge[0], edge[2]]);
    }

    const visited = new Array(n).fill(false);
    visited[0] = true;
    let ans = 0;
    const dfs = (u, time, value) => {
        if (u === 0) {
            ans = Math.max(ans, value);
        }
        g[u].forEach(([v, dist]) => {
            if (time + dist <= maxTime) {
                if (!visited[v]) {
                    visited[v] = true;
                    dfs(v, time + dist, value + values[v]);
                    visited[v] = false;
                } else {
                    dfs(v, time + dist, value);
                }
            }
        });
    };

    dfs(0, 0, values[0]);
    return ans;
};
```

```TypeScript
function maximalPathQuality(values: number[], edges: number[][], maxTime: number): number {
    const n = values.length;
    const g: number[][][] = Array.from({ length: n }, () => []);
    for (const edge of edges) {
        g[edge[0]].push([edge[1], edge[2]]);
        g[edge[1]].push([edge[0], edge[2]]);
    }

    const visited = new Array(n).fill(false);
    visited[0] = true;
    let ans = 0;
    const dfs = (u: number, time: number, value: number): void => {
        if (u === 0) {
            ans = Math.max(ans, value);
        }
        for (const [v, dist] of g[u]) {
            if (time + dist <= maxTime) {
                if (!visited[v]) {
                    visited[v] = true;
                    dfs(v, time + dist, value + values[v]);
                    visited[v] = false;
                } else {
                    dfs(v, time + dist, value);
                }
            }
        }
    };

    dfs(0, 0, values[0]);
    return ans;
};
```

```Rust
use std::collections::VecDeque;
use std::cmp::max;

impl Solution {
    pub fn maximal_path_quality(values: Vec<i32>, edges: Vec<Vec<i32>>, max_time: i32) -> i32 {
        let n = values.len();
        let mut g: Vec<Vec<(i32, i32)>> = vec![vec![]; n];
        for edge in edges {
            g[edge[0] as usize].push((edge[1], edge[2]));
            g[edge[1] as usize].push((edge[0], edge[2]));
        }

        let mut visited = vec![false; n];
        visited[0] = true;
        let mut ans = 0;
        fn dfs(u: usize, time: i32, value: i32, ans:&mut i32, g: &Vec<Vec<(i32, i32)>>, visited:&mut Vec<bool>, values: &Vec<i32>, max_time: &i32) {
            if u == 0 {
                *ans = max(*ans, value);
            }
            for (v, dist) in &g[u] {
                if time + dist <= *max_time {
                    if !visited[*v as usize] {
                        visited[*v as usize] = true;
                        dfs(*v as usize, time + dist, value + values[*v as usize], ans, g, visited, values, max_time);
                        visited[*v as usize] = false;
                    } else {
                        dfs(*v as usize, time + dist, value, ans, g, visited, values, max_time);
                    }
                }
            }
        }

        dfs(0, 0, values[0], &mut ans, &g, &mut visited, &values, &max_time);
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m+d^k)$，其中 $m$ 是数组 $edges$ 的长度，$d$ 是图中每个点度数的最大值，$k$ 是最多经过的边的数量，在本题中 $d=4,k=10$。
  - 将 $edges$ 存储成邻接表的形式需要的时间为 $O(n+m)$。
  - 搜索需要的时间为 $O(d^k)$。
- 空间复杂度：$O(n+m+k)$。
  - 邻接表需要的空间为 $O(n+m)$。
  - 记录每个节点是否访问过的数组需要的空间为 $O(n)$。
  - 搜索中栈需要的空间为 $O(k)$。
