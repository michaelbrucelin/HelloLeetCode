### [尽量减少恶意软件的传播](https://leetcode.cn/problems/minimize-malware-spread/solutions/2735960/jin-liang-jian-shao-e-yi-ruan-jian-de-ch-lwmp/)

#### 方法一：枚举每一个连通分量

##### 思路与算法

我们可以分别考虑每一个连通分量：

- 如果其中没有感染节点，那么无需考虑；
- 如果其中恰好有一个感染节点，移除该节点可以使得最终感染的节点数减少，减少的值即为该连通分量的大小；
- 如果其中有超过一个感染节点，那么无论移除哪一个节点，剩下的那个（那些）节点总会感染连通分量中的所有节点，同样无需考虑。

因此，我们可以首先使用深度优先搜索 / 广度优先搜索 / 并查集的方法求解出所有的连通分量，需要记录的值为：

- 每一个节点所在的连通分量的编号，以及；
- 每一个连通分量的大小。

随后，我们遍历所有的感染节点，并使用一个哈希表记录每个连通分量中感染节点的数目。

最后，我们就可以依次考虑每一个连通分量了。注意到当有多个节点满足条件时，我们需要返回**索引最小的节点**。这里可能会出现所有的感染节点都没有任何作用的情况，因此在枚举每一个连通分量时，相比于通过编号进行枚举，更好的方法是通过遍历所有的感染节点进行枚举。我们维护答案 $\textit{ans}$ 以及其可以减少的感染数 $\textit{ans}_\textit{removed}$，初始时它们的值分别为 $n+1$（只要大于 $n$ 即可）和 $0$。当我们枚举到感染节点 $u$ 时：

- 我们计算出移除 $u$ 可以减少的感染数 $\textit{removed}$：如果 $u$ 所在的连通分量中有超过一个感染节点，那么值 $0$，否则通过上面记录的连通分量的大小得到可以减少的感染数；
- 如果 $(\textit{removed}, u)$ 的组合在题目描述中优于 $(\textit{ans}_\textit{removed}, \textit{ans})$，那么就对答案进行更新。

这样就可以兼顾「某些连通分量中恰好有一个感染节点」以及「没有连通分量中恰好有一个感染节点」这两种情况。

下面的代码使用广度优先搜索的方法得到所有的连通分量。

##### 代码

```c++
class Solution {
public:
    int minMalwareSpread(vector<vector<int>>& graph, vector<int>& initial) {
        int n = graph.size();
        vector<int> ids(n);
        unordered_map<int, int> id_to_size;
        int id = 0;
        for (int i = 0; i < n; ++i) {
            if (!ids[i]) {
                ++id;
                int size = 1;
                queue<int> q;
                q.push(i);
                ids[i] = id;
                while (!q.empty()) {
                    int u = q.front();
                    q.pop();
                    for (int v = 0; v < n; ++v) {
                        if (!ids[v] && graph[u][v] == 1) {
                            ++size;
                            q.push(v);
                            ids[v] = id;
                        }
                    }
                }
                id_to_size[id] = size;
            }
        }
        unordered_map<int, int> id_to_initials;
        for (int u: initial) {
            ++id_to_initials[ids[u]];
        }
        int ans = n + 1, ans_removed = 0;
        for (int u: initial) {
            int removed = (id_to_initials[ids[u]] == 1 ? id_to_size[ids[u]] : 0);
            if (removed > ans_removed || (removed == ans_removed && u < ans)) {
                ans = u;
                ans_removed = removed;
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int minMalwareSpread(int[][] graph, int[] initial) {
        int n = graph.length;
        int[] ids = new int[n];
        Map<Integer, Integer> idToSize = new HashMap<Integer, Integer>();
        int id = 0;
        for (int i = 0; i < n; ++i) {
            if (ids[i] == 0) {
                ++id;
                int size = 1;
                Queue<Integer> queue = new ArrayDeque<Integer>();
                queue.offer(i);
                ids[i] = id;
                while (!queue.isEmpty()) {
                    int u = queue.poll();
                    for (int v = 0; v < n; ++v) {
                        if (ids[v] == 0 && graph[u][v] == 1) {
                            ++size;
                            queue.offer(v);
                            ids[v] = id;
                        }
                    }
                }
                idToSize.put(id, size);
            }
        }
        Map<Integer, Integer> idToInitials = new HashMap<Integer, Integer>();
        for (int u : initial) {
            idToInitials.put(ids[u], idToInitials.getOrDefault(ids[u], 0) + 1);
        }
        int ans = n + 1, ansRemoved = 0;
        for (int u : initial) {
            int removed = (idToInitials.get(ids[u]) == 1 ? idToSize.get(ids[u]) : 0);
            if (removed > ansRemoved || (removed == ansRemoved && u < ans)) {
                ans = u;
                ansRemoved = removed;
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int MinMalwareSpread(int[][] graph, int[] initial) {
        int n = graph.Length;
        int[] ids = new int[n];
        IDictionary<int, int> idToSize = new Dictionary<int, int>();
        int id = 0;
        for (int i = 0; i < n; ++i) {
            if (ids[i] == 0) {
                ++id;
                int size = 1;
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(i);
                ids[i] = id;
                while (queue.Count > 0) {
                    int u = queue.Dequeue();
                    for (int v = 0; v < n; ++v) {
                        if (ids[v] == 0 && graph[u][v] == 1) {
                            ++size;
                            queue.Enqueue(v);
                            ids[v] = id;
                        }
                    }
                }
                idToSize.Add(id, size);
            }
        }
        IDictionary<int, int> idToInitials = new Dictionary<int, int>();
        foreach (int u in initial) {
            idToInitials.TryAdd(ids[u], 0);
            idToInitials[ids[u]]++;
        }
        int ans = n + 1, ansRemoved = 0;
        foreach (int u in initial) {
            int removed = (idToInitials[ids[u]] == 1 ? idToSize[ids[u]] : 0);
            if (removed > ansRemoved || (removed == ansRemoved && u < ans)) {
                ans = u;
                ansRemoved = removed;
            }
        }
        return ans;
    }
}
```

```python
class Solution:
    def minMalwareSpread(self, graph: List[List[int]], initial: List[int]) -> int:
        n = len(graph)
        ids = [0] * n
        id_to_size = dict()
        idx = 0

        for i in range(n):
            if ids[i] == 0:
                idx += 1
                size = 1
                q = deque([i])
                ids[i] = idx
                while q:
                    u = q.popleft()
                    for v in range(n):
                        if ids[v] == 0 and graph[u][v] == 1:
                            size += 1
                            q.append(v)
                            ids[v] = idx
                id_to_size[idx] = size
        
        id_to_initials = defaultdict(int)
        for u in initial:
            id_to_initials[ids[u]] += 1
        
        ans, ans_removed = n + 1, 0
        for u in initial:
            removed = (id_to_size[ids[u]] if id_to_initials[ids[u]] == 1 else 0)
            if removed > ans_removed or (removed == ans_removed and u < ans):
                ans, ans_removed = u, removed
        
        return ans
```

```c
int minMalwareSpread(int** graph, int graphSize, int* graphColSize, int* initial, int initialSize) {
    int n = graphSize;
    int ids[n + 1], idToSize[n + 1];
    memset(ids, 0, sizeof(ids));
    memset(idToSize, 0, sizeof(idToSize));
    int id = 0;
    for (int i = 0; i < n; ++i) {
        if (!ids[i]) {
            id++;
            ids[i] = id;
            int size = 1;
            int q[n];
            int front = 0, rear = 0;
            q[rear++] = i;
            while (front < rear) {
                int u = q[front++];
                for (int v = 0; v < n; ++v) {
                    if (!ids[v] && graph[u][v] == 1) {
                        size++;
                        ids[v] = id;
                        q[rear++] = v;
                    }
                }
            }
            idToSize[id] = size;
        }
    }

    int idToInitials[n + 1];
    memset(idToInitials, 0, sizeof(idToInitials));
    for (int i = 0; i < initialSize; i++) {
        int u = initial[i];
        idToInitials[ids[u]]++;
    }
    int ans = n + 1, ansRemoved = 0;
    for (int i = 0; i < initialSize; i++) {
        int u = initial[i];
        int removed = idToInitials[ids[u]] == 1 ? idToSize[ids[u]] : 0;
        if (removed > ansRemoved || (removed == ansRemoved && u < ans)) {
            ans = u;
            ansRemoved = removed;
        }
    }
    return ans;
}
```

```go
func minMalwareSpread(graph [][]int, initial []int) int {
    n := len(graph)
    ids := make([]int, n)
    idToSize := make(map[int]int)
    id := 0
    for i := range ids {
        if ids[i] == 0 {
            id++
            ids[i] = id
            size := 1
            q := []int{i}
            for len(q) > 0 {
                u := q[0]
                q = q[1:]
                for v := range graph[u] {
                    if ids[v] == 0 && graph[u][v] == 1 {
                        size++
                        q = append(q, v)
                        ids[v] = id
                    }
                }
            }
            idToSize[id] = size
        }
    }
    idToInitials := make(map[int]int)
    for _, u := range initial {
        idToInitials[ids[u]]++
    }
    ans := n + 1
    ansRemoved := 0
    for _, u := range initial {
        removed := 0
        if idToInitials[ids[u]] == 1 {
            removed = idToSize[ids[u]]
        }
        if removed > ansRemoved || (removed == ansRemoved && u < ans) {
            ans, ansRemoved = u, removed
        }
    }
    return ans
}
```

```javascript
var minMalwareSpread = function(graph, initial) {
    const n = graph.length;
    let ids = new Array(n).fill(0);
    let idToSize = new Map();
    let id = 0;
    for (let i = 0; i < n; ++i) {
        if (!ids[i]) {
            ++id;
            let size = 1;
            let q = [i];
            ids[i] = id;
            while (q.length > 0) {
                let u = q.shift();
                for (let v = 0; v < n; ++v) {
                    if (!ids[v] && graph[u][v] === 1) {
                        ++size;
                        q.push(v);
                        ids[v] = id;
                    }
                }
            }
            idToSize.set(id, size);
        }
    }
    let idToInitials = new Map();
    for (const u of initial) {
        if (!idToInitials.has(ids[u])) {
            idToInitials.set(ids[u], 0);
        }
        idToInitials.set(ids[u], idToInitials.get(ids[u]) + 1);
    }
    let ans = n + 1, ansRemoved = 0;
    for (const u of initial) {
        let removed = idToInitials.get(ids[u]) === 1 ? idToSize.get(ids[u]) : 0;
        if (removed > ansRemoved || (removed === ansRemoved && u < ans)) {
            ans = u;
            ansRemoved = removed;
        }
    }
    return ans;
};
```

```typescript
function minMalwareSpread(graph: number[][], initial: number[]): number {
    const n = graph.length;
    let ids: number[] = new Array(n).fill(0);
    let idToSize: Map<number, number> = new Map();
    let id = 0;
    for (let i = 0; i < n; ++i) {
        if (!ids[i]) {
            ++id;
            let size = 1;
            let q = [i];
            ids[i] = id;
            while (q.length > 0) {
                let u = q.shift();
                for (let v = 0; v < n; ++v) {
                    if (!ids[v] && graph[u][v] === 1) {
                        ++size;
                        q.push(v);
                        ids[v] = id;
                    }
                }
            }
            idToSize.set(id, size);
        }
    }
    let idToInitials: Map<number, number> = new Map();
    for (const u of initial) {
        if (!idToInitials.has(ids[u])) {
            idToInitials.set(ids[u], 0);
        }
        idToInitials.set(ids[u], idToInitials.get(ids[u]) + 1);
    }
    let ans = n + 1, ansRemoved = 0;
    for (const u of initial) {
        let removed = idToInitials.get(ids[u]) === 1 ? idToSize.get(ids[u]) : 0;
        if (removed > ansRemoved || (removed === ansRemoved && u < ans)) {
            ans = u;
            ansRemoved = removed;
        }
    }
    return ans;
};
```

```rust
use std::collections::{VecDeque, HashMap};

impl Solution {
    pub fn min_malware_spread(graph: Vec<Vec<i32>>, initial: Vec<i32>) -> i32 {
        let n = graph.len();
        let mut ids: Vec<i32> = vec![0; n];
        let mut id_to_size: HashMap<i32, i32> = HashMap::new();
        let mut id = 0;
        for i in 0..n {
            if ids[i] == 0 {
                id += 1;
                let mut q = VecDeque::from([i]);
                ids[i] = id;
                let mut size = 1;
                while let Some(u) = q.pop_front() {
                    for v in 0..n {
                        if graph[u][v] == 1 && ids[v] == 0 {
                            size += 1;
                            q.push_back(v);
                            ids[v] = id;
                        }
                    }
                }
                id_to_size.insert(id, size);
            }
        }
        let mut id_to_initials: HashMap<i32, i32> = HashMap::new();
        for &u in initial.iter() {
            *id_to_initials.entry(ids[u as usize]).or_insert(0) += 1;
        }
        let mut ans = n as i32 + 1;
        let mut ans_removed = 0;
        for &u in initial.iter() {
            let removed = if id_to_initials[&ids[u as usize]] == 1 {id_to_size[&ids[u as usize]]} else {0};
            if removed > ans_removed || (removed == ans_removed && u < ans) {
                ans = u;
                ans_removed = removed;
            }
        }
        ans
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n^2)$。广度优先搜索需要的时间为 $O(n^2)$，随后最多得到 $n$ 个连通分量。后续统计每个连通分量中的感染节点，以及枚举每个连通分量需要的时间之和为 $O(n)$，因此总时间复杂度为 $O(n^2)$。
- 空间复杂度：$O(n)$，即为广度优先搜索以及后续统计中的数组和哈希表需要使用的空间。
