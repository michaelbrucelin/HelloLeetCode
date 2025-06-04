### [找到离给定两个节点最近的节点](https://leetcode.cn/problems/find-closest-node-to-given-two-nodes/solutions/3677387/zhao-dao-chi-gei-ding-liang-ge-jie-dian-8f8gp/)

#### 方法一：循环计算可达性 + 一次遍历

**思路与算法**

题目给定一个 $n$ 个节点的有向图，每个节点至多有一个出边。因此，我们从某个点（设为 $x$）出发不断地沿着出边（最多一条）遍历，得到 $x$ 可以到达的所有点，以及距离。这一过程可以用循环来实现，直到某个点无出边或者这个点已被遍历过时停止。

分别对 $node1$​ 和 $node2$​ 按照上述步骤计算后，遍历所有点，筛选出 $node1$​ 和 $node2$​ 都可以到达的点，并从中选出离 $node1$​ 和 $node2$​ 最远距离最小的点即可。

**代码**

```C++
class Solution {
public:
    int closestMeetingNode(vector<int>& edges, int node1, int node2) {
        int n = edges.size();
        auto get = [&](int x) {
            vector<int> d(n, -1);
            int p = x;
            int dis = 0;
            while (p != -1 && d[p] == -1) {
                d[p] = dis;
                p = edges[p];
                dis++;
            }
            return d;
        };
        auto d1 = get(node1);
        auto d2 = get(node2);
        int res = -1;
        for (int i = 0; i < n; i++) {
            if (d1[i] != -1 && d2[i] != -1 && (res == -1 || max(d1[res], d2[res]) > max(d1[i], d2[i]))) {
                res = i;
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def closestMeetingNode(self, edges: List[int], node1: int, node2: int) -> int:
        n = len(edges)
        def get(x):
            d = [-1] * n
            p = x
            dis = 0
            while p != -1 and d[p] == -1:
                d[p] = dis
                p = edges[p]
                dis += 1
            return d
        d1 = get(node1)
        d2 = get(node2)
        res = -1
        for i in range(n):
            if d1[i] != -1 and d2[i] != -1 and (res == -1 or max(d1[res], d2[res]) > max(d1[i], d2[i])):
                res = i
        return res
```

```Rust
impl Solution {
    pub fn closest_meeting_node(edges: Vec<i32>, node1: i32, node2: i32) -> i32 {
        let n = edges.len();
        let get = |x| {
            let mut d = vec![-1; n];
            let mut p = x;
            let mut dis = 0;
            while p != -1 && d[p as usize] == -1 {
                d[p as usize] = dis;
                p = edges[p as usize];
                dis += 1;
            }
            d
        };
        let d1 = get(node1);
        let d2 = get(node2);
        let mut res = -1;
        for i in 0..n {
            if d1[i] != -1 && d2[i] != -1 && (res == -1 || d1[res as usize].max(d2[res as usize]) > d1[i].max(d2[i])) {
                res = i as i32;
            }
        }
        res
    }
}
```

```Java
class Solution {
    public int closestMeetingNode(int[] edges, int node1, int node2) {
        int n = edges.length;
        int[] d1 = get(edges, node1);
        int[] d2 = get(edges, node2);
        
        int res = -1;
        for (int i = 0; i < n; i++) {
            if (d1[i] != -1 && d2[i] != -1) {
                if (res == -1 || Math.max(d1[res], d2[res]) > Math.max(d1[i], d2[i])) {
                    res = i;
                }
            }
        }
        return res;
    }
    
    private int[] get(int[] edges, int node) {
        int n = edges.length;
        int[] dist = new int[n];
        Arrays.fill(dist, -1);
        int distance = 0;
        while (node != -1 && dist[node] == -1) {
            dist[node] = distance++;
            node = edges[node];
        }
        return dist;
    }
}
```

```CSharp
public class Solution {
    public int ClosestMeetingNode(int[] edges, int node1, int node2) {
        int n = edges.Length;
        int[] d1 = get(edges, node1);
        int[] d2 = get(edges, node2);
        
        int res = -1;
        for (int i = 0; i < n; i++) {
            if (d1[i] != -1 && d2[i] != -1) {
                if (res == -1 || Math.Max(d1[res], d2[res]) > Math.Max(d1[i], d2[i])) {
                    res = i;
                }
            }
        }
        return res;
    }
    
    private int[] get(int[] edges, int node) {
        int n = edges.Length;
        int[] dist = new int[n];
        Array.Fill(dist, -1);
        int distance = 0;
        while (node != -1 && dist[node] == -1) {
            dist[node] = distance++;
            node = edges[node];
        }
        return dist;
    }
}
```

```Go
func closestMeetingNode(edges []int, node1 int, node2 int) int {
    n := len(edges)
    get := func(node int) []int {
        n := len(edges)
        dist := make([]int, n)
        for i := range dist {
            dist[i] = -1
        }
        distance := 0
        for node != -1 && dist[node] == -1 {
            dist[node] = distance
            distance++
            node = edges[node]
        }
        return dist
    }

    d1 := get(node1)
    d2 := get(node2)
    res := -1
    for i := 0; i < n; i++ {
        if d1[i] != -1 && d2[i] != -1 {
            if res == -1 || max(d1[res], d2[res]) > max(d1[i], d2[i]) {
                res = i
            }
        }
    }
    return res
}
```

```C
int* get(int* edges, int edgesSize, int node) {
    int* dist = (int*)malloc(edgesSize * sizeof(int));
    memset(dist, -1, edgesSize * sizeof(int));
    int distance = 0;
    while (node != -1 && dist[node] == -1) {
        dist[node] = distance++;
        node = edges[node];
    }
    return dist;
}

int closestMeetingNode(int* edges, int edgesSize, int node1, int node2) {
    int* d1 = get(edges, edgesSize, node1);
    int* d2 = get(edges, edgesSize, node2);
    int res = -1;
    for (int i = 0; i < edgesSize; i++) {
        if (d1[i] != -1 && d2[i] != -1) {
            if (res == -1 || fmax(d1[res], d2[res]) > fmax(d1[i], d2[i])) {
                res = i;
            }
        }
    }
    free(d1);
    free(d2);
    return res;
}
```

```JavaScript
var closestMeetingNode = function(edges, node1, node2) {
    const n = edges.length;
    const get = (node) => {
        const dist = new Array(n).fill(-1);
        let distance = 0;
        while (node !== -1 && dist[node] === -1) {
            dist[node] = distance++;
            node = edges[node];
        }
        return dist;
    };
    
    const d1 = get(node1);
    const d2 = get(node2);
    
    let res = -1;
    for (let i = 0; i < n; i++) {
        if (d1[i] !== -1 && d2[i] !== -1) {
            if (res === -1 || Math.max(d1[res], d2[res]) > Math.max(d1[i], d2[i])) {
                res = i;
            }
        }
    }
    return res;
};
```

```TypeScript
function closestMeetingNode(edges: number[], node1: number, node2: number): number {
    const n = edges.length;
    const get = (node: number): number[] => {
        const dist = new Array(n).fill(-1);
        let distance = 0;
        while (node !== -1 && dist[node] === -1) {
            dist[node] = distance++;
            node = edges[node];
        }
        return dist;
    };
    
    const d1 = get(node1);
    const d2 = get(node2);
    
    let res = -1;
    for (let i = 0; i < n; i++) {
        if (d1[i] !== -1 && d2[i] !== -1) {
            if (res === -1 || Math.max(d1[res], d2[res]) > Math.max(d1[i], d2[i])) {
                res = i;
            }
        }
    }
    return res;
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是图中点的数量。由于在 $get$ 函数中，每个点最多之后遍历一次，并且最后我们也只遍历所有点一次，因此总体时间复杂度是 $O(n)$。
- 空间复杂度：$O(n)$。我们用两个数组来存储两个点到其他所有点的可达距离，空间复杂度是 $O(n)$。
