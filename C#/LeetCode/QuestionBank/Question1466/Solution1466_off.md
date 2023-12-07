### [重新规划路线](https://leetcode.cn/problems/reorder-routes-to-make-all-paths-lead-to-the-city-zero/solutions/2553195/zhong-xin-gui-hua-lu-xian-by-leetcode-so-psl6/)

#### 方法一：深度优先搜索

**思路与算法**

题目给定一张由 $n$ 个点（使用 $0$ 到 $n-1$ 编号），$n-1$ 条边构成的有向图，如果忽略边的方向，就变成了一棵树。我们需要改变某些边的方向使得每个点都可以访问到 $0$ 号点。

如果忽略边的方向，将每条有向边以及其反向边加入到图中，那么从任意一点出发都能到达 $0$ 号点。路径上可能会经过反向边，我们需要变更与之对应的原边的方向。需要变更的次数即为答案。

以每个点为起点进行搜索的代价会很大，因此我们考虑从 $0$ 出发去遍历其他点（可以使用深度优先搜索或者广度优先搜索，本题解使用深度优先搜索），原来我们需要统计反向边的数量，现在需要统计原方向边的数量。

具体而言，我们使用 $1$ 标记原方向的边，使用 $0$ 标记反向边。然后从 $0$ 号点开始遍历，访问到某个新的点时，所经过的边被 $1$ 标记，就令答案加 $1$。最终统计得到的答案就是我们需要变更方向的最小路线数。

**代码**

```cpp
class Solution {
public:
    int dfs(int x, int parent, vector<vector<pair<int, int>>>& e) {
        int res = 0;
        for (auto &edge : e[x]) {
            if (edge.first == parent) {
                continue;
            }
            res += edge.second + dfs(edge.first, x, e);
        }
        return res;
    }

    int minReorder(int n, vector<vector<int>>& connections) {
        vector<vector<pair<int, int>>> e(n);
        for (auto edge : connections) {
            e[edge[0]].push_back(make_pair(edge[1], 1));
            e[edge[1]].push_back(make_pair(edge[0], 0));
        }
        return dfs(0, -1, e);
    }
};
```

```java
class Solution {
    public int minReorder(int n, int[][] connections) {
        List<int[]>[] e = new List[n];
        for (int i = 0; i < n; i++) {
            e[i] = new ArrayList<int[]>();
        }
        for (int[] edge : connections) {
            e[edge[0]].add(new int[]{edge[1], 1});
            e[edge[1]].add(new int[]{edge[0], 0});
        }
        return dfs(0, -1, e);
    }

    public int dfs(int x, int parent, List<int[]>[] e) {
        int res = 0;
        for (int[] edge : e[x]) {
            if (edge[0] == parent) {
                continue;
            }
            res += edge[1] + dfs(edge[0], x, e);
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int MinReorder(int n, int[][] connections) {
        IList<Tuple<int, int>>[] e = new IList<Tuple<int, int>>[n];
        for (int i = 0; i < n; i++) {
            e[i] = new List<Tuple<int, int>>();
        }
        foreach (int[] edge in connections) {
            e[edge[0]].Add(new Tuple<int, int>(edge[1], 1));
            e[edge[1]].Add(new Tuple<int, int>(edge[0], 0));
        }
        return DFS(0, -1, e);
    }

    public int DFS(int x, int parent, IList<Tuple<int, int>>[] e) {
        int res = 0;
        foreach (Tuple<int, int> edge in e[x]) {
            if (edge.Item1 == parent) {
                continue;
            }
            res += edge.Item2 + DFS(edge.Item1, x, e);
        }
        return res;
    }
}
```

```go
func dfs(x, parent int, e [][][]int) int {
    res := 0
    for _, edge := range e[x] {
        if edge[0] == parent {
            continue
        }
        res += edge[1] + dfs(edge[0], x, e)
    }
    return res
}

func minReorder(n int, connections [][]int) int {
    e := make([][][]int, n)
    for _, edge := range connections {
        e[edge[0]] = append(e[edge[0]], []int{edge[1], 1})
        e[edge[1]] = append(e[edge[1]], []int{edge[0], 0})
    }
    return dfs(0, -1, e)
}
```

```python
class Solution:
    def dfs(self, x: int, parent: int, e: List[List[List[int]]]) -> int:
        res = 0
        for edge in e[x]:
            if edge[0] == parent:
                continue
            res += edge[1] + self.dfs(edge[0], x, e)
        return res

    def minReorder(self, n: int, connections: List[List[int]]) -> int:
        e = [[] for _ in range(n)]
        for edge in connections:
            e[edge[0]].append([edge[1], 1])
            e[edge[1]].append([edge[0], 0])
        return self.dfs(0, -1, e)
```

```javascript
var minReorder = function(n, connections) {
    const e = new Array(n).fill(0).map(() => new Array());
    for (const edge of connections) {
        e[edge[0]].push([edge[1], 1]);
        e[edge[1]].push([edge[0], 0]);
    }

    const dfs = function(x, parent) {
        let res = 0;
        for (const edge of e[x]) {
            if (edge[0] == parent) {
                continue;
            }
            res += edge[1] + dfs(edge[0], x);
        }
        return res;
    }
    return dfs(0, -1, e);
};
```

```c
typedef struct Node {
    int city;
    int direction;
    struct Node *next;
} Node;

Node *createNode(int city, int direction) {
    Node *obj = (Node *)malloc(sizeof(Node));
    obj->city = city;
    obj->direction = direction;
    obj->next = NULL;
    return obj;
}

void freeList(Node *list) {
    while (list) {
        Node *cur = list;
        list = list->next;
        free(cur);
    }
}

int dfs(int x, int parent, const Node **e) {
    int res = 0;
    for (Node *node = e[x]; node; node = node->next) {
        if (node->city == parent) {
            continue;
        }
        res += node->direction + dfs(node->city, x, e);
    }
    return res;
}

int minReorder(int n, int** connections, int connectionsSize, int* connectionsColSize) {
    Node **e = (Node **)calloc(n, sizeof(Node *));
    for (int i = 0; i < connectionsSize; i++) {
        int x = connections[i][0];
        int y = connections[i][1];
        Node *nodex = createNode(x, 0);
        Node *nodey = createNode(y, 1);
        nodex->next = e[y];
        e[y] = nodex;
        nodey->next = e[x];
        e[x] = nodey;
    }
    int ret = dfs(0, -1, e);
    for (int i = 0; i < n; i++) {
        freeList(e[i]);
    }
    free(e);
    return ret;
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是点的数量。建树的时间复杂度为 $O(n)$，从 $0$ 号点出发进行深度优先搜索的时间复杂度为 $O(n)$，因此总的时间复杂度为 $O(n)$。
-   空间复杂度：$O(n)$。建树的空间复杂度为 $O(n)$，递归所需要的栈空间为 $O(n)$，因此总的空间复杂度为 $O(n)$。
