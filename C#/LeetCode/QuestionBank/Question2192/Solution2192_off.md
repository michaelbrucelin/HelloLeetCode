### [有向无环图中一个节点的所有祖先](https://leetcode.cn/problems/all-ancestors-of-a-node-in-a-directed-acyclic-graph/solutions/1364674/you-xiang-wu-huan-tu-zhong-yi-ge-jie-dia-6ed5/)

#### 方法一：拓扑排序

##### 提示 $1$

有向无环图中，每个节点的所有祖先节点集合即为该节点所有父节点（即有一条**直接**指向该节点的有向边的节点）的**本身及其祖先节点**组成集合的**并集**。

##### 思路与算法

根据 **提示 $1$**，如果我们按照拓扑排序的顺序来遍历每个节点并计算祖先节点集合，那么遍历到某个节点时，其所有父节点的祖先节点集合都已计算完成，我们就可以直接对这些集合加上父节点本身取并集得到该节点的所有祖先节点。这一「取并集」的过程等价于在拓扑排序的过程中用每个节点的祖先集合更新每个节点所有子节点的祖先集合。

具体地，我们用哈希表数组 $\textit{anc}$ 来表示每个节点的祖先节点集合，用 $E$ 以**邻接表**形式存储每个节点的所有**出边**，并用数组 $\textit{indeg}$ 来计算每个结点的入度。

我们可以用广度优先搜索的方法求解拓扑排序。首先我们遍历 $\textit{edges}$ 数组预处理邻接表 $E$ 和入度表 $\textit{indeg}$，并将所有入度为 $0$ 的节点加入广度优先搜索队列 qqq。此时队列里的元素对应的祖先节点集合均为空集，且都已经更新完成。

在遍历到节点 $u$ 时，我们首先遍历所有通过出边相邻的子节点 $v$，此时根据定义 $u$ 一定是 $v$ 的父节点，且根据拓扑序，$u$ 的祖先节点集合 $\textit{anc}[u]$ 已经更新完毕。因此我们将 $\textit{anc}[u]$ 的所有元素和 $u$ 加入至 $\textit{anc}[v]$ 中，并将 $v$ 的入度 $\textit{indeg}[v]$ 减去 $1$。此时，如果 $\textit{indeg}[v] = 0$，则说明 $\textit{anc}[v]$ 已经更新完成，此时我们将 $v$ 加入队列。

最终，我们需要利用嵌套数组 $\textit{res}$ 将 $\textit{anc}$ 中的每个哈希集合对应地转化为升序排序后的数组，此时 $\textit{res}$ 即为待求的升序排序的每个节点的所有祖先。我们返回 $\textit{res}$ 作为答案即可。

##### 代码

```c++
class Solution {
public:
    vector<vector<int>> getAncestors(int n, vector<vector<int>>& edges) {
        vector<unordered_set<int>> anc(n);   // 存储每个节点祖先的辅助数组
        vector<vector<int>> e(n);   // 邻接表
        vector<int> indeg(n);   // 入度表
        // 预处理
        for (const auto& edge: edges) {
            e[edge[0]].push_back(edge[1]);
            ++indeg[edge[1]];
        }
        // 广度优先搜索求解拓扑排序
        queue<int> q;
        for (int i = 0; i < n; ++i) {
            if (!indeg[i]) {
                q.push(i);
            }
        }
        while (!q.empty()) {
            int u = q.front();
            q.pop();
            for (int v: e[u]) {
                // 更新子节点的祖先哈希表
                anc[v].insert(u);
                for (int i: anc[u]) {
                    anc[v].insert(i);
                }
                --indeg[v];
                if (!indeg[v]) {
                    q.push(v);
                }
            }
        }
        // 转化为答案数组
        vector<vector<int>> res(n);
        for (int i = 0; i < n; ++i) {
            for (int j: anc[i]) {
                res[i].push_back(j);
            }
            sort(res[i].begin(), res[i].end());
        }
        return res;
    }
};
```

```java
class Solution {
    public List<List<Integer>> getAncestors(int n, int[][] edges) {
        Set<Integer>[] anc = new Set[n];   // 存储每个节点祖先的辅助数组
        for (int i = 0; i < n; ++i) {
            anc[i] = new HashSet<Integer>();
        }
        List<Integer>[] e = new List[n];   // 邻接表
        for (int i = 0; i < n; ++i) {
            e[i] = new ArrayList<Integer>();
        }
        int[] indeg = new int[n];   // 入度表
        // 预处理
        for (int[] edge : edges) {
            e[edge[0]].add(edge[1]);
            ++indeg[edge[1]];
        }
        // 广度优先搜索求解拓扑排序
        Queue<Integer> q = new ArrayDeque<Integer>();
        for (int i = 0; i < n; ++i) {
            if (indeg[i] == 0) {
                q.offer(i);
            }
        }
        while (!q.isEmpty()) {
            int u = q.poll();
            for (int v : e[u]) {
                // 更新子节点的祖先哈希表
                anc[v].add(u);
                for (int i : anc[u]) {
                    anc[v].add(i);
                }
                --indeg[v];
                if (indeg[v] == 0) {
                    q.offer(v);
                }
            }
        }
        // 转化为答案数组
        List<List<Integer>> res = new ArrayList<List<Integer>>();
        for (int i = 0; i < n; ++i) {
            res.add(new ArrayList<Integer>());
            for (int j : anc[i]) {
                res.get(i).add(j);
            }
            Collections.sort(res.get(i));
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public IList<IList<int>> GetAncestors(int n, int[][] edges) {
        ISet<int>[] anc = new ISet<int>[n];   // 存储每个节点祖先的辅助数组
        for (int i = 0; i < n; ++i) {
            anc[i] = new HashSet<int>();
        }
        IList<int>[] e = new IList<int>[n];   // 邻接表
        for (int i = 0; i < n; ++i) {
            e[i] = new List<int>();
        }
        int[] indeg = new int[n];   // 入度表
        // 预处理
        foreach (int[] edge in edges) {
            e[edge[0]].Add(edge[1]);
            ++indeg[edge[1]];
        }
        // 广度优先搜索求解拓扑排序
        Queue<int> q = new Queue<int>();
        for (int i = 0; i < n; ++i) {
            if (indeg[i] == 0) {
                q.Enqueue(i);
            }
        }
        while (q.Count > 0) {
            int u = q.Dequeue();
            foreach (int v in e[u]) {
                // 更新子节点的祖先哈希表
                anc[v].Add(u);
                foreach (int i in anc[u]) {
                    anc[v].Add(i);
                }
                --indeg[v];
                if (indeg[v] == 0) {
                    q.Enqueue(v);
                }
            }
        }
        // 转化为答案数组
        IList<IList<int>> res = new List<IList<int>>();
        for (int i = 0; i < n; ++i) {
            res.Add(new List<int>());
            foreach (int j in anc[i]) {
                res[i].Add(j);
            }
            ((List<int>) res[i]).Sort();
        }
        return res;
    }
}
```

```python
class Solution:
    def getAncestors(self, n: int, edges: List[List[int]]) -> List[List[int]]:
        anc = [set() for _ in range(n)]   # 存储每个节点祖先的辅助数组
        e = [[] for _ in range(n)] # 邻接表
        indeg = [0] * n   # 入度表
        # 预处理
        for u, v in edges:
            e[u].append(v)
            indeg[v] += 1
        # 广度优先搜索求解拓扑排序
        q = deque()
        for i in range(n):
            if indeg[i] == 0:
                q.append(i)
        while q:
            u = q.popleft()
            for v in e[u]:
                # 更新子节点的祖先哈希表
                anc[v].add(u)
                anc[v].update(anc[u])
                indeg[v] -= 1
                if indeg[v] == 0:
                    q.append(v)
        # 转化为答案数组
        res = [sorted(anc[i]) for i in range(n)]        
        return res
```

```c
typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

struct ListNode *creatListNode(int val) {
    struct ListNode *obj = (struct ListNode *)malloc(sizeof(struct ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

static int cmp(const void *a, const void *b) {
    return *(int *)a - *(int *)b;
}

void freeList(struct ListNode *list) {
    while (list) {
        struct ListNode *p = list;
        list = list->next;
        free(p);
    }
}

int** getAncestors(int n, int** edges, int edgesSize, int* edgesColSize, int* returnSize, int** returnColumnSizes) {
    HashItem *anc[n]; // 存储每个节点祖先的辅助数组
    struct ListNode *e[n]; // 邻接表
    int indeg[n]; // 入度表

    // 预处理
    for (int i = 0; i < n; i++) {
        anc[i] = NULL;
        e[i] = NULL;
        indeg[i] = 0;
    }
    for (int i = 0; i <edgesSize; i++) {
        int x = edges[i][0], y = edges[i][1];
        struct ListNode *node = creatListNode(y);
        node->next = e[x];
        e[x] = node;
        ++indeg[y];
    }
  
    // 广度优先搜索求解拓扑排序
    int queue[n];
    int head = 0, tail = 0;
    for (int i = 0; i < n; ++i) {
        if (!indeg[i]) {
            queue[tail++] = i;
        }
    }
    while (head != tail) {
        int u = queue[head++];
        for (struct ListNode *p = e[u]; p; p = p->next) {
            int v = p->val;
            // 更新子节点的祖先哈希表
            hashAddItem(&anc[v], u);
            for (HashItem *pEntry = anc[u]; pEntry != NULL; pEntry = pEntry->hh.next) {
                int i = pEntry->key;
                hashAddItem(&anc[v], i);
            }
            --indeg[v];
            if (!indeg[v]) {
                queue[tail++] = v;
            }
        }
    }

    // 转化为答案数组
    *returnSize = n;
    int **res = (int *)malloc(sizeof(int *) * n);
    *returnColumnSizes = (int *)malloc(sizeof(int) * n);
    for (int i = 0; i < n; ++i) {
        int m = HASH_COUNT(anc[i]);
        int pos = 0;
        (*returnColumnSizes)[i] = m;
        res[i] = (int *)malloc(sizeof(int) * m);
        for (HashItem *pEntry = anc[i]; pEntry != NULL; pEntry = pEntry->hh.next) {
            res[i][pos++] = pEntry->key;
        }
        qsort(res[i], m, sizeof(int), cmp);
        hashFree(&anc[i]);
        freeList(e[i]);
    }

    return res;
}
```

```go
func getAncestors(n int, edges [][]int) [][]int {
    anc := make([]map[int]bool, n) // 存储每个节点祖先的辅助数组
    for i := 0; i < n; i++ {
        anc[i] = map[int]bool{}
    }
    e := make([][]int, n) // 邻接表
    indeg := make([]int, n) // 入度表
    // 预处理
    for _, edge := range edges {
        e[edge[0]] = append(e[edge[0]], edge[1])
        indeg[edge[1]]++
    }
    // 广度优先搜索求解拓扑排序
    var q []int
    for i := 0; i < n; i++ {
        if indeg[i] == 0 {
            q = append(q, i)
        }
    }
    for len(q) > 0 {
        u := q[0]
        q = q[1:]
        for _, v := range e[u] {
            // 更新子节点的祖先哈希表
            anc[v][u] = true
            for i := range anc[u] {
                anc[v][i] = true
            }
            indeg[v]--
            if indeg[v] == 0 {
                q = append(q, v)
            }
        }
    }
    // 转化为答案数组
    res := make([][]int, n)
    for i := 0; i < n; i++ {
        for j := range anc[i] {
            res[i] = append(res[i], j)
        }
        sort.Ints(res[i])
    }
    return res
}
```

```javascript
var getAncestors = function(n, edges) {
    // 存储每个节点的祖先节点的辅助数组
    const anc = Array(n).fill().map(() => new Set());
    // 邻接表
    const e = Array(n).fill().map(() => []);
    // 入度表
    const indeg = Array(n).fill(0);

    // 预处理
    for (const edge of edges) {
        e[edge[0]].push(edge[1]);
        indeg[edge[1]]++;
    }

    // 广度优先搜索求解拓扑排序
    const q = [];
    for (let i = 0; i < n; ++i) {
        if (!indeg[i]) {
            q.push(i);
        }
    }
    while (q.length) {
        const u = q.shift();
        for (const v of e[u]) {
            // 更新子节点的祖先节点集合
            anc[v].add(u);
            for (const i of anc[u]) {
                anc[v].add(i);
            }
            indeg[v]--;
            if (!indeg[v]) {
                q.push(v);
            }
        }
    }

    // 转化为答案数组
    const res = [];
    for (let i = 0; i < n; ++i) {
        res[i] = Array.from(anc[i]).sort((a, b) => a - b);
    }

    return res;
};
```

```typescript
function getAncestors(n: number, edges: number[][]): number[][] {
    // 存储每个节点的祖先节点的辅助数组
    const anc: Set<number>[] = Array(n).fill(null).map(() => new Set<number>());
    // 邻接表
    const e: number[][] = Array(n).fill(null).map(() => []);
    // 入度表
    const indeg: number[] = Array(n).fill(0);

    // 预处理
    for (const edge of edges) {
        e[edge[0]].push(edge[1]);
        indeg[edge[1]]++;
    }

    // 广度优先搜索求解拓扑排序
    const q: number[] = [];
    for (let i = 0; i < n; ++i) {
        if (!indeg[i]) {
            q.push(i);
        }
    }
    while (q.length) {
        const u: number = q.shift()!;
        for (const v of e[u]) {
            // 更新子节点的祖先节点集合
            anc[v].add(u);
            for (const i of anc[u]) {
                anc[v].add(i);
            }
            indeg[v]--;
            if (!indeg[v]) {
                q.push(v);
            }
        }
    }

    // 转化为答案数组
    const res: number[][] = [];
    for (let i = 0; i < n; ++i) {
        res[i] = Array.from(anc[i]).sort((a, b) => a - b);
    }

    return res;
};
```

```rust
use std::collections::{HashSet, VecDeque};

impl Solution {
    pub fn get_ancestors(n: i32, edges: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
        let n = n as usize;
        // 存储每个节点的祖先节点的辅助数组
        let mut anc: Vec<HashSet<i32>> = vec![HashSet::new(); n];
        // 邻接表
        let mut e: Vec<Vec<i32>> = vec![Vec::new(); n];
        // 入度表
        let mut indeg: Vec<i32> = vec![0; n];

        // 预处理
        for edge in edges {
            e[edge[0] as usize].push(edge[1]);
            indeg[edge[1] as usize] += 1;
        }

        // 广度优先搜索求解拓扑排序
        let mut q: VecDeque<i32> = VecDeque::new();
        for i in 0..n {
            if indeg[i] == 0 {
                q.push_back(i as i32);
            }
        }
        while let Some(u) = q.pop_front() {
            for v in &e[u as usize] {
                // 复制祖先节点集合，避免同时遍历和修改
                let mut new_ancestors = anc[*v as usize].clone();
                // 更新子节点的祖先节点集合
                new_ancestors.insert(u);
                for i in &anc[u as usize] {
                    new_ancestors.insert(*i);
                }
                anc[*v as usize] = new_ancestors;
                indeg[*v as usize] -= 1;
                if indeg[*v as usize] == 0 {
                    q.push_back(*v);
                }
            }
        }

        // 转化为答案数组
        let mut res: Vec<Vec<i32>> = vec![Vec::new(); n as usize];
        for i in 0..n as usize {
            res[i] = anc[i].iter().cloned().collect::<Vec<i32>>();
            res[i].sort();
        }
        res
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(VE + V^2 \log V)$，其中 $V = n$ 为节点数量；$E$ 为边的数量，即 $\textit{edges}$ 的长度。其中广度优先搜索的时间复杂度为 $O(VE)$，对辅助数组排序生成答案数组的时间复杂度为 $O(V^2 \log V)$。
- 空间复杂度：$O(V^2)$，即为存储每个节点祖先的辅助数组的空间开销。
