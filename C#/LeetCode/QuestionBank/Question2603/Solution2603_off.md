### [收集树中金币](https://leetcode.cn/problems/collect-coins-in-a-tree/solutions/2451073/shou-ji-shu-zhong-jin-bi-by-leetcode-sol-kaah/)

#### 方法一：两次拓扑排序

**思路与算法**

对于给定无根树中度数为 $1$ 的节点，我们称其为「叶节点」。可以发现，对于每一个「叶节点」$l$，如果 $l$ 上没有金币，那么我们就没有必要走到 $l$。这是因为对于 $l$ 唯一相邻的那个节点 $l'$，它可以收集到在 $l$ 可以收集到的所有金币，那么：

-   如果我们从 $l$ 开始出发，那么可以改成从 $l'$ 开始出发，经过的边数一定减少；
-   如果我们不从 $l$ 开始出发，那么到达 $l'$ 之后不必再走向 $l$，经过的边数一定减少。

因此，我们可以不断地移除给定无根树中没有金币的「叶节点」。当某个「叶节点」被移除后，它唯一相邻的那条边也需要被移除，这样可能会有新的节点变为「叶节点」。我们不断迭代地重复这个过程，直到所有的「叶节点」上都有金币为止。

> 这一步可以使用基于广度优先搜索的拓扑排序解决。我们首先将所有「叶节点」加入队列中，随后不断从队列中取出节点，将它标记为删除，并判断其唯一相邻的节点是否变为「叶节点」。如果是，就将相邻的节点也加入队列中。

当所有的「叶节点」上都有金币时，我们应该如何解决给定的问题呢？我们可以先思考，如果操作变为「收集距离当前节点距离为 $0$ 以内的所有金币」该如何解决。当距离为 $0$ 时，我们必须要走到对应的节点上才能收集金币，而每个「叶节点」上都有金币，因此我们必须**遍历到所有的「叶节点」**，这也意味着我们**遍历了整颗树**。从任一节点出发，遍历整颗树并返回原节点，会经过树上的每条边一次，而树的边数等于点数减一，因此答案为 $2(n'-1)$，其中 $n'$ 时经过上文移除后，无根树中节点的数量。

如果操作变为「收集距离当前节点距离为 $1$ 以内的所有金币」呢？我们可以进一步思考得到：当我们即将遍历到「叶节点」时，可以直接返回，因为此时我们与「叶节点」的距离为 $1$，可以直接收集到金币，不需要走到「叶节点」。因此，我们遍历的范围，就是**将树中所有叶节点以及它们唯一相邻的那条边移除后的新树**。在新树中的金币可以通过遍历获得到，而不在新树中的金币会在遍历到与其距离为 $1$ 的某个节点时获取到。

因此，当操作变为「收集距离当前节点距离为 $2$ 以内的所有金币」时，我们的方法仍然是类似的，我们只需要将**新树**中所有的「叶节点」以及它们唯一相邻的那条边移除，得到的**新新树**就是需要遍历的范围。

> 这一步同样可以使用基于广度优先搜索的拓扑排序解决。我们进行 $2$ 次如下的操作：首先将所有「叶节点」加入初始队列中，随后不断从初始队列中取出节点，将它标记为删除。

**细节**

如果**新新树**中没有任何节点，说明在初始的无根树中，存在一个节点可以直接获取到所有金币，答案为 $0$，否则答案为 $2 \times (\textbf{新新树}中的节点数量 -1)$。

**代码**

```cpp
class Solution {
public:
    int collectTheCoins(vector<int>& coins, vector<vector<int>>& edges) {
        int n = coins.size();
        vector<vector<int>> g(n);
        vector<int> degree(n);
        for (const auto& edge: edges) {
            int x = edge[0], y = edge[1];
            g[x].push_back(y);
            g[y].push_back(x);
            ++degree[x];
            ++degree[y];
        }

        int rest = n;
        {
            /* 删除树中所有无金币的叶子节点，直到树中所有的叶子节点都是含有金币的 */
            queue<int> q;
            for (int i = 0; i < n; ++i) {
                if (degree[i] == 1 && !coins[i]) {
                    q.push(i);
                }
            }
            while (!q.empty()) {
                int u = q.front();
                --degree[u];
                q.pop();
                --rest;
                for (int v: g[u]) {
                    --degree[v];
                    if (degree[v] == 1 && !coins[v]) {
                        q.push(v);
                    }
                }
            }
        }
        {
            /* 删除树中所有的叶子节点, 连续删除2次 */
            for (int _ = 0; _ < 2; ++_) {
                queue<int> q;
                for (int i = 0; i < n; ++i) {
                    if (degree[i] == 1) {
                        q.push(i);
                    }
                }
                while (!q.empty()) {
                    int u = q.front();
                    --degree[u];
                    q.pop();
                    --rest;
                    for (int v: g[u]) {
                        --degree[v];
                    }
                }
            }
        }

        return rest == 0 ? 0 : (rest - 1) * 2;
    }
};
```

```java
class Solution {
    public int collectTheCoins(int[] coins, int[][] edges) {
        int n = coins.length;
        List<Integer>[] g = new List[n];
        for (int i = 0; i < n; ++i) {
            g[i] = new ArrayList<Integer>();
        }
        int[] degree = new int[n];
        for (int[] edge : edges) {
            int x = edge[0], y = edge[1];
            g[x].add(y);
            g[y].add(x);
            ++degree[x];
            ++degree[y];
        }

        int rest = n;
        /* 删除树中所有无金币的叶子节点，直到树中所有的叶子节点都是含有金币的 */
        Queue<Integer> queue = new ArrayDeque<Integer>();
        for (int i = 0; i < n; ++i) {
            if (degree[i] == 1 && coins[i] == 0) {
                queue.offer(i);
            }
        }
        while (!queue.isEmpty()) {
            int u = queue.poll();
            --degree[u];
            --rest;
            for (int v : g[u]) {
                --degree[v];
                if (degree[v] == 1 && coins[v] == 0) {
                    queue.offer(v);
                }
            }
        }
        /* 删除树中所有的叶子节点, 连续删除2次 */
        for (int x = 0; x < 2; ++x) {
            queue = new ArrayDeque<Integer>();
            for (int i = 0; i < n; ++i) {
                if (degree[i] == 1) {
                    queue.offer(i);
                }
            }
            while (!queue.isEmpty()) {
                int u = queue.poll();
                --degree[u];
                --rest;
                for (int v : g[u]) {
                    --degree[v];
                }
            }
        }

        return rest == 0 ? 0 : (rest - 1) * 2;
    }
}
```

```csharp
public class Solution {
    public int CollectTheCoins(int[] coins, int[][] edges) {
        int n = coins.Length;
        IList<int>[] g = new IList<int>[n];
        for (int i = 0; i < n; ++i) {
            g[i] = new List<int>();
        }
        int[] degree = new int[n];
        foreach (int[] edge in edges) {
            int x = edge[0], y = edge[1];
            g[x].Add(y);
            g[y].Add(x);
            ++degree[x];
            ++degree[y];
        }

        int rest = n;
        /* 删除树中所有无金币的叶子节点，直到树中所有的叶子节点都是含有金币的 */
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < n; ++i) {
            if (degree[i] == 1 && coins[i] == 0) {
                queue.Enqueue(i);
            }
        }
        while (queue.Count > 0) {
            int u = queue.Dequeue();
            --degree[u];
            --rest;
            foreach (int v in g[u]) {
                --degree[v];
                if (degree[v] == 1 && coins[v] == 0) {
                    queue.Enqueue(v);
                }
            }
        }
        /* 删除树中所有的叶子节点, 连续删除2次 */
        for (int x = 0; x < 2; ++x) {
            queue = new Queue<int>();
            for (int i = 0; i < n; ++i) {
                if (degree[i] == 1) {
                    queue.Enqueue(i);
                }
            }
            while (queue.Count > 0) {
                int u = queue.Dequeue();
                --degree[u];
                --rest;
                foreach (int v in g[u]) {
                    --degree[v];
                }
            }
        }

        return rest == 0 ? 0 : (rest - 1) * 2;
    }
}
```

```python
class Solution:
    def collectTheCoins(self, coins: List[int], edges: List[List[int]]) -> int:
        n = len(coins)
        g = defaultdict(list)
        degree = [0] * n

        for x, y in edges:
            g[x].append(y)
            g[y].append(x)
            degree[x] += 1
            degree[y] += 1
        
        rest = n
        # 删除树中所有无金币的叶子节点，直到树中所有的叶子节点都是含有金币的
        q = deque(i for i in range(n) if degree[i] == 1 and coins[i] == 0)
        while q:
            u = q.popleft()
            degree[u] -= 1
            rest -= 1
            for v in g[u]:
                degree[v] -= 1
                if degree[v] == 1 and coins[v] == 0:
                    q.append(v)
        
        # 删除树中所有的叶子节点, 连续删除2次
        for _ in range(2):
            q = deque(i for i in range(n) if degree[i] == 1)
            while q:
                u = q.popleft()
                degree[u] -= 1
                rest -= 1
                for v in g[u]:
                    degree[v] -= 1
        
        return 0 if rest == 0 else (rest - 1) * 2
```

```c
struct ListNode *createListNode(int val) {
    struct ListNode *obj = (struct ListNode*)malloc(sizeof(struct ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

void freeList(struct ListNode *list) {
    while (list) {
        struct ListNode *cur = list;
        list = list->next;
        free(cur);
    }
}

int collectTheCoins(int* coins, int coinsSize, int** edges, int edgesSize, int* edgesColSize) {
    int n = coinsSize;
    struct ListNode *g[n];
    int degree[n];
    memset(g, 0, sizeof(g));
    memset(degree, 0, sizeof(degree));
    for (int i = 0; i < edgesSize; i++) {
        int x = edges[i][0], y = edges[i][1];
        struct ListNode *nodex = createListNode(x);
        struct ListNode *nodey = createListNode(y);
        nodex->next = g[y];
        nodey->next = g[x];
        g[y] = nodex;
        g[x] = nodey;
        ++degree[x];
        ++degree[y];
    }

    int rest = n;
    int queue[n];
    int head = 0, tail = 0;
    /* 删除树中所有无金币的叶子节点，直到树中所有的叶子节点都是含有金币的 */
    for (int i = 0; i < n; ++i) {
        if (degree[i] == 1 && !coins[i]) {
            queue[tail++] = i;
        }
    }
    while (head != tail) {
        int u = queue[head++];
        --degree[u];
        --rest;
        for (struct ListNode *node = g[u]; node; node = node->next) {
            int v = node->val;
            --degree[v];
            if (degree[v] == 1 && !coins[v]) {
                queue[tail++] = v;
            }
        }
    }

    /* 删除树中所有的叶子节点, 连续删除2次 */
    for (int j = 0; j < 2; ++j) {
        head = tail = 0;
        for (int i = 0; i < n; ++i) {
            if (degree[i] == 1) {
                queue[tail++] = i;
            }
        }
        while (head != tail) {
            int u = queue[head++];
            --degree[u];
            --rest;
            for (struct ListNode *node = g[u]; node; node = node->next) {
                int v = node->val;
                --degree[v];
            }
        }
    }
    for (int i = 0; i < n; i++) {
        freeList(g[i]);
    }


    return rest == 0 ? 0 : (rest - 1) * 2;
}
```

```go
func collectTheCoins(coins []int, edges [][]int) int {
    n := len(coins)
    g := make([][]int, n)
    degree := make([]int, n)
    for _, edge := range edges {
        x, y := edge[0], edge[1]
        g[x] = append(g[x], y)
        g[y] = append(g[y], x)
        degree[x]++
        degree[y]++
    }

    rest := n
    // 删除树中所有无金币的叶子节点，直到树中所有的叶子节点都是含有金币的 
    q := []int{}
    for i := 0; i < n; i++ {
        if degree[i] == 1 && coins[i] == 0 {
            q = append(q, i)
        }
    }
    for len(q) > 0 {
        u := q[0]
        q = q[1:]
        degree[u]--
        rest--
        for _, v := range g[u] {
            degree[v]--
            if degree[v] == 1 && coins[v] == 0 {
                q = append(q, v)
            }
        }
    }

    // 删除树中所有的叶子节点, 连续删除2次
    for j := 0; j < 2; j++ {
        q := []int{}
        for i := 0; i < n; i++ {
            if degree[i] == 1 {
                q = append(q, i)
            }
        }
        for len(q) > 0 {
            u := q[0]
            q = q[1:]
            degree[u]--
            rest--
            for _, v := range g[u] {
                degree[v]--
            }
        }
    }

    if rest == 0 {
        return 0
    }
    return (rest - 1) * 2
}
```

```javascript
var collectTheCoins = function(coins, edges) {
    n = coins.length
    g = new Array(n).fill(0).map(() => new Array());
    degree = new Array(n).fill(0);
    for (const edge of edges) {
        let x = edge[0], y = edge[1];
        g[x].push(y);
        g[y].push(x);
        degree[x]++;
        degree[y]++;
    }
    
    let rest = n;
    let q = [];
    // 删除树中所有无金币的叶子节点，直到树中所有的叶子节点都是含有金币的 
    for (let i = 0; i < n; i++) {
        if (degree[i] == 1 && coins[i] == 0) {
            q.push(i);
        }
    }
    while (q.length > 0) {
        const u = q.shift();
        degree[u]--;
        rest--;
        for (const v of g[u]) {
            degree[v]--;
            if (degree[v] == 1 && coins[v] == 0) {
                q.push(v)
            }
        }
    }

    // 删除树中所有的叶子节点, 连续删除2次
    for (let j = 0; j < 2; j++) {
        let q = [];
        for (let i = 0; i < n; i++) {
            if (degree[i] == 1) {
                q.push(i);
            }
        }
        while (q.length > 0) {
            u = q.shift();
            degree[u]--;
            rest--;
            for (const v of g[u]) {
                degree[v]--;
            }
        }
    }

    return rest == 0 ? 0 : (rest - 1) * 2;
};
```

**复杂度分析**

-   时间复杂度：$O(n)$。构造图的邻接表，度数数组以及拓扑排序都需要 $O(n)$ 的时间。
-   空间复杂度：$O(n)$。即为图的邻接表，度数数组以及拓扑排序中的队列需要使用的空间。
