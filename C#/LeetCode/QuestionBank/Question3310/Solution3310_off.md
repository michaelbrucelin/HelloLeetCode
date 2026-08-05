### [移除可疑的方法](https://leetcode.cn/problems/remove-methods-from-project/solutions/4001246/yi-chu-ke-yi-de-fang-fa-by-leetcode-solu-o81q/)

#### 方法一：搜索

**思路与算法**

给定的 $invocations$ 数组实际上定义了一个有向图。给定节点 $k$，将这个图中的节点 $k$ 自身以及通过节点 $k$ 能到达的节点称为「可疑方法」。按题意，我们实际上需要判断是否存在调用了「可疑方法」的普通方法。也就是说，是否**不存在**从普通节点连向「可疑方法」的边，只有满足这个条件时，才能移除所有「可疑方法」。

首先，我们需要找出所有的「可疑方法」。以节点 $k$ 作为起点，使用深度优先搜索或广度优先搜索，在图上不重复地遍历即可。

然后我们需要判断是否还有其他节点可以到达这些节点，此时有两种思路：

- 统计每个节点的入度，在遍历的时候将目标节点的入度减一，相当于移除这次遍历所用的边。等找到所有的「可疑方法」后，节点的入度就代表连向该节点的普通节点数量。此时遍历所有的「可疑方法」，如果某个节点的入度不为 $0$，说明还有外部的节点可以到达「可疑方法」。
- 遍历 $invocations$，如果存在从某个普通节点指向「可疑方法」的边，则说明存在能到达「可疑方法」的其他节点。我们可以使用哈希表来快速判断节点是否属于「可疑方法」集合。

最后按题意，分为两种情况处理：

- 如果没有其他任何节点能达到这些「可疑方法」，那么就返回移除这些节点后剩余的节点。
- 否则就返回全部节点。

**代码**

```C++
constexpr int MAXN = 100005;

class Solution {
public:
    vector<int> remainingMethods(int n, int k, vector<vector<int>>& invocations) {
        vector<vector<int>> edges(n);
        vector<int> inDegree(n, 0);

        bitset<MAXN> suspicious;

        for (const auto& inv : invocations) {
            edges[inv[0]].push_back(inv[1]);
            inDegree[inv[1]]++;
        }

        queue<int> q;
        q.push(k);

        suspicious.set(k);

        while (!q.empty()) {
            int u = q.front();
            q.pop();
            for (int v : edges[u]) {
                inDegree[v]--;

                if (!suspicious.test(v)) {
                    q.push(v);
                    suspicious.set(v);
                }
            }
        }

        bool canRemoveAll = true;
        vector<int> remaining;

        for (int i = 0; i < n; i++) {
            if (suspicious.test(i) && inDegree[i] > 0) {
                canRemoveAll = false;
                break;
            } else if (!suspicious.test(i)) {
                remaining.push_back(i);
            }
        }

        if (!canRemoveAll) {
            vector<int> allNodes(n);
            iota(allNodes.begin(), allNodes.end(), 0);
            return allNodes;
        }

        return remaining;
    }
};
```

```Java
class Solution {
    public List<Integer> remainingMethods(int n, int k, int[][] invocations) {
        List<Integer>[] edges = new ArrayList[n];
        for (int i = 0; i < n; i++) {
            edges[i] = new ArrayList<>();
        }
        int[] inDegree = new int[n];

        for (int[] inv : invocations) {
            edges[inv[0]].add(inv[1]);
            inDegree[inv[1]]++;
        }

        Queue<Integer> queue = new ArrayDeque<>();
        queue.offer(k);
        boolean[] suspicious = new boolean[n];
        suspicious[k] = true;


        while (!queue.isEmpty()) {
            int u = queue.poll();
            for (int v : edges[u]) {
                inDegree[v]--;

                if (!suspicious[v]) {
                    queue.offer(v);
                    suspicious[v] = true;
                }
            }
        }

        boolean canRemoveAll = true;
        List<Integer> remaining = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            if (suspicious[i] && inDegree[i] > 0) {
                canRemoveAll = false;
                break;
            } else if (!suspicious[i]) {
                remaining.add(i);
            }
        }

        if (!canRemoveAll) {
            List<Integer> allNodes = new ArrayList<>(n);
            for (int i = 0; i < n; i++) {
                allNodes.add(i);
            }
            return allNodes;
        }

        return remaining;
    }
}
```

```CSharp
public class Solution {
    public IList<int> RemainingMethods(int n, int k, int[][] invocations) {
        List<int>[] edges = new List<int>[n];
        for (int i = 0; i < n; i++) {
            edges[i] = new List<int>();
        }
        int[] inDegree = new int[n];

        foreach (var inv in invocations) {
            edges[inv[0]].Add(inv[1]);
            inDegree[inv[1]]++;
        }

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(k);
        bool[] suspicious = new bool[n];
        suspicious[k] = true;

        while (queue.Count > 0) {
            int u = queue.Dequeue();
            foreach (int v in edges[u]) {
                inDegree[v]--;

                if (!suspicious[v]) {
                    queue.Enqueue(v);
                    suspicious[v] = true;
                }
            }
        }

        bool canRemoveAll = true;
        List<int> remaining = new List<int>();

        for (int i = 0; i < n; i++) {
            if (suspicious[i] && inDegree[i] > 0) {
                canRemoveAll = false;
                break;
            } else if (!suspicious[i]) {
                remaining.Add(i);
            }
        }

        if (!canRemoveAll) {
            List<int> allNodes = new List<int>(n);
            for (int i = 0; i < n; i++) {
                allNodes.Add(i);
            }
            return allNodes;
        }

        return remaining;
    }
}
```

```Go
func remainingMethods(n int, k int, invocations [][]int) []int {
	edges := make([][]int, n)
	inDegree := make([]int, n)

	for _, inv := range invocations {
		u, v := inv[0], inv[1]
		edges[u] = append(edges[u], v)
		inDegree[v]++
	}

	queue := []int{k}
	suspicious := make([]bool, n)
	suspicious[k] = true

	for len(queue) > 0 {
		u := queue[0]
		queue = queue[1:]
		for _, v := range edges[u] {
			inDegree[v]--

			if !suspicious[v] {
				queue = append(queue, v)
				suspicious[v] = true
			}
		}
	}

	canRemoveAll := true
	remaining := []int{}

	for i := 0; i < n; i++ {
		if suspicious[i] && inDegree[i] > 0 {
			canRemoveAll = false
			break
		} else if !suspicious[i] {
			remaining = append(remaining, i)
		}
	}

	if !canRemoveAll {
		allNodes := make([]int, n)
		for i := 0; i < n; i++ {
			allNodes[i] = i
		}
		return allNodes
	}

	return remaining
}
```

```Python
class Solution:
    def remainingMethods(self, n: int, k: int, invocations: list[list[int]]) -> list[int]:
        edges = [[] for _ in range(n)]
        in_degree = [0] * n

        for u, v in invocations:
            edges[u].append(v)
            in_degree[v] += 1

        queue = collections.deque([k])
        suspicious = bytearray(n)
        suspicious[k] = 1

        while queue:
            u = queue.popleft()
            for v in edges[u]:
                in_degree[v] -= 1

                if suspicious[v] == 0:
                    queue.append(v)
                    suspicious[v] = 1

        can_remove_all = True
        for i in range(n):
            if suspicious[i] == 1 and in_degree[i] > 0:
                can_remove_all = False
                break

        if not can_remove_all:
            return list(range(n))

        return [i for i in range(n) if suspicious[i] == 0]

```

```C
typedef struct EdgeNode {
    int vertex;
    struct EdgeNode* next;
} EdgeNode;

typedef struct QueueNode {
    int data;
    struct QueueNode* next;
} QueueNode;

typedef struct {
    QueueNode* front;
    QueueNode* rear;
} Queue;

Queue* createQueue() {
    Queue* q = (Queue*)malloc(sizeof(Queue));
    q->front = q->rear = NULL;
    return q;
}

void push(Queue* q, int value) {
    QueueNode* newNode = (QueueNode*)malloc(sizeof(QueueNode));
    newNode->data = value;
    newNode->next = NULL;

    if (q->rear == NULL) {
        q->front = q->rear = newNode;
    } else {
        q->rear->next = newNode;
        q->rear = newNode;
    }
}

int pop(Queue* q) {
    if (q->front == NULL) {
        return -1;
    }
    QueueNode* temp = q->front;
    int value = temp->data;
    q->front = q->front->next;
    if (q->front == NULL) {
        q->rear = NULL;
    }

    free(temp);
    return value;
}

bool isEmpty(Queue* q) {
    return q->front == NULL;
}

void freeQueue(Queue* q) {
    while (!isEmpty(q)) {
        pop(q);
    }
    free(q);
}

void addEdge(EdgeNode** edges, int u, int v) {
    EdgeNode* newNode = (EdgeNode*)malloc(sizeof(EdgeNode));
    newNode->vertex = v;
    newNode->next = edges[u];
    edges[u] = newNode;
}

void freeEdges(EdgeNode** edges, int n) {
    for (int i = 0; i < n; i++) {
        EdgeNode* curr = edges[i];
        while (curr != NULL) {
            EdgeNode* temp = curr;
            curr = curr->next;
            free(temp);
        }
    }
    free(edges);
}

int* remainingMethods(int n, int k, int** invocations, int invocationsSize, int* invocationsColSize, int* returnSize) {
    EdgeNode** edges = (EdgeNode**)calloc(n, sizeof(EdgeNode*));
    int* inDegree = (int*)calloc(n, sizeof(int));

    for (int i = 0; i < invocationsSize; i++) {
        int u = invocations[i][0];
        int v = invocations[i][1];
        addEdge(edges, u, v);
        inDegree[v]++;
    }

    Queue* queue = createQueue();
    push(queue, k);
    unsigned char* suspicious = (unsigned char*)calloc(n, sizeof(unsigned char));
    suspicious[k] = 1;

    while (!isEmpty(queue)) {
        int u = pop(queue);
        EdgeNode* curr = edges[u];
        while (curr != NULL) {
            int v = curr->vertex;
            inDegree[v]--;

            if (suspicious[v] == 0) {
                push(queue, v);
                suspicious[v] = 1;
            }
            curr = curr->next;
        }
    }

    freeQueue(queue);
    bool canRemoveAll = true;
    int* remaining = (int*)malloc(sizeof(int) * n);
    int count = 0;

    for (int i = 0; i < n; i++) {
        if (suspicious[i] == 1 && inDegree[i] > 0) {
            canRemoveAll = false;
            break;
        } else if (suspicious[i] == 0) {
            remaining[count++] = i;
        }
    }

    if (!canRemoveAll) {
        free(remaining);
        remaining = (int*)malloc(sizeof(int) * n);
        for (int i = 0; i < n; i++) {
            remaining[i] = i;
        }
        *returnSize = n;
    } else {
        *returnSize = count;
    }

    freeEdges(edges, n);
    free(inDegree);
    free(suspicious);

    return remaining;
}
```

```JavaScript
var remainingMethods = function(n, k, invocations) {
    const edges = Array.from({ length: n }, () => []);
    const inDegree = new Array(n).fill(0);

    for (const [u, v] of invocations) {
        edges[u].push(v);
        inDegree[v]++;
    }

    const queue = new Queue([k]);
    const suspicious = new Uint8Array(n);
    suspicious[k] = 1;

    while (!queue.isEmpty()) {
        const u = queue.pop();
        for (let i = 0; i < edges[u].length; i++) {
            const v = edges[u][i];
            inDegree[v]--;

            if (suspicious[v] === 0) {
                queue.push(v);
                suspicious[v] = 1;
            }
        }
    }

    let canRemoveAll = true;
    const remaining = [];

    for (let i = 0; i < n; i++) {
        if (suspicious[i] === 1 && inDegree[i] > 0) {
            canRemoveAll = false;
            break;
        } else if (suspicious[i] === 0) {
            remaining.push(i);
        }
    }

    if (!canRemoveAll) {
        return Array.from({ length: n }, (_, i) => i);
    }

    return remaining;
}
```

```TypeScript
function remainingMethods(n: number, k: number, invocations: number[][]): number[] {
    const edges = Array.from({ length: n }, () => [] as number[]);
    const inDegree = new Array<number>(n).fill(0);

    for (const [u, v] of invocations) {
        edges[u].push(v);
        inDegree[v]++;
    }

    const queue = new Queue<number>([k]);
    const suspicious = new Array<boolean>(n).fill(false);
    suspicious[k] = true;

    while (!queue.isEmpty()) {
        const u = queue.pop();
        for (const v of edges[u]) {
            inDegree[v]--;

            if (!suspicious[v]) {
                queue.push(v);
                suspicious[v] = true;
            }
        }
    }

    let canRemoveAll = true;
    const remaining: number[] = [];

    for (let i = 0; i < n; i++) {
        if (suspicious[i] === true && inDegree[i] > 0) {
            canRemoveAll = false;
            break;
        } else if (suspicious[i] === false) {
            remaining.push(i);
        }
    }

    if (!canRemoveAll) {
        return Array.from({ length: n }, (_, i) => i);
    }

    return remaining;
}
```

```Rust
use std::collections::VecDeque;

impl Solution {
    pub fn remaining_methods(n: i32, k: i32, invocations: Vec<Vec<i32>>) -> Vec<i32> {
        let n_usize = n as usize;
        let k_usize = k as usize;
        let mut edges = vec![Vec::new(); n_usize];
        let mut in_degree = vec![0; n_usize];

        for inv in &invocations {
            let (u, v) = (inv[0] as usize, inv[1] as usize);
            edges[u].push(v);
            in_degree[v] += 1;
        }

        let mut queue = VecDeque::new();
        queue.push_back(k_usize);
        let mut suspicious = vec![false; n_usize];
        suspicious[k_usize] = true;

        while let Some(u) = queue.pop_front() {
            for &v in &edges[u] {
                in_degree[v] -= 1;

                if !suspicious[v] {
                    queue.push_back(v);
                    suspicious[v] = true;
                }
            }
        }

        let mut can_remove_all = true;
        let mut remaining = Vec::new();

        for i in 0..n_usize {
            if suspicious[i] && in_degree[i] > 0 {
                can_remove_all = false;
                break;
            } else if !suspicious[i] {
                remaining.push(i as i32);
            }
        }

        if !can_remove_all {
            return (0..n).collect();
        }

        remaining
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m)$，其中 $n$ 是节点数，$m$ 是边数（即 $invocations$ 的长度）。初始化各个辅助数组需要 $O(n)$ 的时间；搜索时，每个节点最多遍历一次，搜索整个图需要 $O(n+m)$ 的时间；构建结果需要 $O(n)$ 的时间。总共需要 $O(n+m)$ 的时间。
- 空间复杂度：$O(n+m)$。邻接表存图需要 $O(n+m)$，其余辅助数组均需要 $O(n)$ 的空间。
