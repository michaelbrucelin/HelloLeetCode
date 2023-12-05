### [到达首都的最少油耗](https://leetcode.cn/problems/minimum-fuel-cost-to-report-to-the-capital/solutions/2553190/dao-da-shou-du-de-zui-shao-you-hao-by-le-v013/)

#### 方法一：贪心 + 深度优先搜索

**思路与算法**

题目等价于给出了一棵以节点 $0$ 为根结点的树，并且初始树上的每一个节点上都有一个人，现在所有人都需要通过「车子」向结点 $0$ 移动。

对于某一个节点 $x$，$x \neq 0$，其父节点为 $y$。因为以节点 $x$ 为根结点的子树上的人都需要通过边 $x \rightarrow y$ 向节点 $0$ 移动，所以为了使这条边上的「车子」利用率最高，我们贪心的让 $x$ 的全部子节点上的人到了节点 $x$ 后再一起坐车向上移动，我们不妨设以节点 $x$ 为根节点的子树大小为 $cnt_x$，那么我们至少需要「车子」的数量为 $\lceil \frac{cnt_x}{seats} \rceil$，其中 $seats$ 为一辆车的给定座位数。

那么我们可以通过从根结点 $0$ 往下进行「深度优先搜索」，每一条边上「车子」的数目即为该条边上汽油的开销，统计全部边上汽油的开销即为最终答案。

**代码**

```python
class Solution:
    def minimumFuelCost(self, roads: List[List[int]], seats: int) -> int:
        g = [[] for i in range(len(roads) + 1)]
        for e in roads:
            g[e[0]].append(e[1])
            g[e[1]].append(e[0])
        res = 0
        def dfs(cur, fa):
            nonlocal res
            peopleSum = 1 
            for ne in g[cur]:
                if ne != fa:
                    peopleCnt = dfs(ne, cur)
                    peopleSum += peopleCnt
                    res += (peopleCnt + seats - 1) // seats
            return peopleSum
        dfs(0, -1)
        return res
```

```c++
class Solution {
public:
    long long minimumFuelCost(vector<vector<int>>& roads, int seats) {
        int n = roads.size();
        vector<vector<int>> g(n + 1);
        for (auto &e : roads) {
            g[e[0]].push_back(e[1]);
            g[e[1]].push_back(e[0]);
        }
        long long res = 0;
        function<int(int, int)> dfs = [&](int cur, int fa) -> int {
            int peopleSum = 1;
            for (auto ne : g[cur]) {
                if (ne != fa) {
                    int peopleCnt = dfs(ne, cur);
                    peopleSum += peopleCnt;
                    res += (peopleCnt + seats - 1) / seats;
                }
            }
            return peopleSum;
        };
        dfs(0, -1);
        return res;
    }
};
```

```java
class Solution {
    long res = 0;

    public long minimumFuelCost(int[][] roads, int seats) {
        int n = roads.length;
        List<Integer>[] g = new List[n + 1];
        for (int i = 0; i <= n; i++) {
            g[i] = new ArrayList<Integer>();
        }
        for (int[] e : roads) {
            g[e[0]].add(e[1]);
            g[e[1]].add(e[0]);
        }
        dfs(0, -1, seats, g);
        return res;
    }

    public int dfs(int cur, int fa, int seats, List<Integer>[] g) {
        int peopleSum = 1;
        for (int ne : g[cur]) {
            if (ne != fa) {
                int peopleCnt = dfs(ne, cur, seats, g);
                peopleSum += peopleCnt;
                res += (peopleCnt + seats - 1) / seats;
            }
        }
        return peopleSum;
    }
}
```

```csharp
public class Solution {
    long res = 0;

    public long MinimumFuelCost(int[][] roads, int seats) {
        int n = roads.Length;
        IList<int>[] g = new IList<int>[n + 1];
        for (int i = 0; i <= n; i++) {
            g[i] = new List<int>();
        }
        foreach (int[] e in roads) {
            g[e[0]].Add(e[1]);
            g[e[1]].Add(e[0]);
        }
        DFS(0, -1, seats, g);
        return res;
    }

    public int DFS(int cur, int fa, int seats, IList<int>[] g) {
        int peopleSum = 1;
        foreach (int ne in g[cur]) {
            if (ne != fa) {
                int peopleCnt = DFS(ne, cur, seats, g);
                peopleSum += peopleCnt;
                res += (peopleCnt + seats - 1) / seats;
            }
        }
        return peopleSum;
    }
}
```

```go
func minimumFuelCost(roads [][]int, seats int) int64 {
    g := make([][]int, len(roads) + 1)
    for _, e := range roads {
        g[e[0]] = append(g[e[0]], e[1])
        g[e[1]] = append(g[e[1]], e[0])
    }
    var res int64
    var dfs func(int, int) int
    dfs = func(cur, fa int) int {
        peopleSum := 1
        for _, ne := range g[cur] {
            if ne != fa {
                peopleCnt := dfs(ne, cur)
                peopleSum, res = peopleSum + peopleCnt, res + int64((peopleCnt + seats - 1) / seats)
            }
        }
        return peopleSum
    }
    dfs(0, -1)
    return res
}
```

```c
typedef struct ListNode ListNode;

ListNode *createListNode(int val) {
    ListNode *obj = (ListNode *)malloc(sizeof(ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

void freeList(ListNode *list) {
    while (list) {
        ListNode *cur = list;
        list = list->next;
        free(cur);
    }
}

int dfs(int cur, int fa, int seats, long long *res, const ListNode **g) {
    int peopleSum = 1;
    for (ListNode *node = g[cur]; node; node = node->next) {
        int ne = node->val;
        if (ne != fa) {
            int peopleCnt = dfs(ne, cur, seats, res, g);
            peopleSum += peopleCnt;
            *res += (peopleCnt + seats - 1) / seats;
        }
    }
    return peopleSum;
}

long long minimumFuelCost(int** roads, int roadsSize, int* roadsColSize, int seats) {
    ListNode **g = (ListNode **)calloc(roadsSize + 1, sizeof(ListNode *));
    memset(g, 0, sizeof(ListNode *) * (roadsSize + 1));
    for (int i = 0; i < roadsSize; i++) {
        int x = roads[i][0];
        int y = roads[i][1];
        ListNode *nodex = createListNode(x);
        ListNode *nodey = createListNode(y);
        nodex->next = g[y];
        g[y] = nodex;
        nodey->next = g[x];
        g[x] = nodey;
    }
   
    long long res = 0;
    dfs(0, -1, seats, &res, g);
    for (int i = 0; i <= roadsSize; i++) {
        freeList(g[i]);
    }
    free(g);
    return res;
}
```

```javascript
var minimumFuelCost = function(roads, seats) {
    const n = roads.length;
    const g = new Array(n + 1).fill(0).map(() => new Array());
    for (const e of roads) {
        g[e[0]].push(e[1]);
        g[e[1]].push(e[0]);
    }
    let res = 0;
    var dfs = function(cur, fa) {
        let peopleSum = 1;
        for (const ne of g[cur]) {
            if (ne != fa) {
                const peopleCnt = dfs(ne, cur);
                peopleSum += peopleCnt;
                res += Math.floor((peopleCnt + seats - 1) / seats);
            }
        }
        return peopleSum;
    }
    dfs(0, -1);
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 为数组 $roads$ 的长度。
-   空间复杂度：$O(n)$，其中 $n$ 为数组 $roads$ 的长度，主要为递归所需要的空间开销。
