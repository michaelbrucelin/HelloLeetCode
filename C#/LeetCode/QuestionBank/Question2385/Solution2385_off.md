### [感染二叉树需要的总时间](https://leetcode.cn/problems/amount-of-time-for-binary-tree-to-be-infected/solutions/2750528/gan-ran-er-cha-shu-xu-yao-de-zong-shi-ji-awgp/)

#### 方法一：深度优先搜索建图 + 广度优先搜索求感染时间

##### 思路

根据题意，需求出值为 $\textit{start}$ 的节点到其他节点最远的距离。树中的最远距离可以用广度优先搜索来求解。但是 $\textit{start}$ 不一定为根节点，我们需要先将树的结构用深度优先搜索解析成无向图，再用广度优先搜索来求最长距离。代码中 $\textit{graph}$ 即为邻接表，用一个哈希表来表示。哈希表的键为节点值，值为其相邻节点的值组成的列表。建完表后用广度优先搜索求最长距离。

##### 代码

```python
class Solution:
    def amountOfTime(self, root: Optional[TreeNode], start: int) -> int:
        graph = defaultdict(list)
        def dfs(node: TreeNode) -> None:
            for child in [node.left, node.right]:
                if child:
                    graph[node.val].append(child.val)
                    graph[child.val].append(node.val)
                    dfs(child)
        dfs(root)

        q = deque([[start, 0]])
        visited = set([start])
        time = 0
        while q:
            nodeVal, time = q.popleft()
            for childVal in graph[nodeVal]:
                if childVal not in visited:
                    q.append([childVal, time + 1])
                    visited.add(childVal)
        return time
```

```java
class Solution {
    public int amountOfTime(TreeNode root, int start) {
        Map<Integer, List<Integer>> graph = new HashMap<Integer, List<Integer>>();
        dfs(graph, root);
        Queue<int[]> queue = new ArrayDeque<int[]>();
        queue.offer(new int[]{start, 0});
        Set<Integer> visited = new HashSet<Integer>();
        visited.add(start);
        int time = 0;
        while (!queue.isEmpty()) {
            int[] arr = queue.poll();
            int nodeVal = arr[0];
            time = arr[1];
            for (int childVal : graph.get(nodeVal)) {
                if (visited.add(childVal)) {
                    queue.offer(new int[]{childVal, time + 1});
                }
            }
        }
        return time;
    }

    public void dfs(Map<Integer, List<Integer>> graph, TreeNode node) {
        graph.putIfAbsent(node.val, new ArrayList<Integer>());
        for (TreeNode child : Arrays.asList(node.left, node.right)) {
            if (child != null) {
                graph.get(node.val).add(child.val);
                graph.putIfAbsent(child.val, new ArrayList<Integer>());
                graph.get(child.val).add(node.val);
                dfs(graph, child);
            }
        }
    }
}
```

```c++
class Solution {
public:
    int amountOfTime(TreeNode *root, int start) {
        unordered_map<int, vector<int>> graph;
        function<void(TreeNode *)> dfs = [&](TreeNode *node) {
            for (TreeNode *child : vector<TreeNode *>{node->left, node->right}) {
                if (child != nullptr) {
                    graph[node->val].push_back(child->val);
                    graph[child->val].push_back(node->val);
                    dfs(child);
                }
            }
        };
        dfs(root);
        queue<vector<int>> q;
        q.push({start, 0});
        unordered_set<int> visited;
        visited.insert(start);
        int time = 0;
        while (!q.empty()) {
            auto arr = q.front();
            q.pop();
            int nodeVal = arr[0];
            time = arr[1];
            for (int childVal: graph[nodeVal]) {
                if (!visited.count(childVal)) {
                    q.push({childVal, time + 1});
                    visited.insert(childVal);
                }
            }
        }
        return time;
    }
};
```

```go
func amountOfTime(root *TreeNode, start int) int {
    graph := map[int][]int{}
    var dfs func(*TreeNode)
    dfs = func(node *TreeNode) {
        for _, child := range []*TreeNode{node.Left, node.Right} {
            if child != nil {
                graph[node.Val] = append(graph[node.Val], child.Val)
                graph[child.Val] = append(graph[child.Val], node.Val)
                dfs(child)
            }
        }
    }
    dfs(root)
    q := [][]int{[]int{start, 0}}
    visited := map[int]bool{}
    visited[start] = true
    time := 0
    for len(q) > 0 {
        arr := q[0]
        q = q[1:]
        nodeVal := arr[0]
        time = arr[1]
        for _, childVal := range graph[nodeVal] {
            if !visited[childVal] {
                q = append(q, []int{childVal, time + 1})
                visited[childVal] = true
            }
        }
    }
    return time
}
```

```c
typedef struct {
    int key;
    struct ListNode *val;
    UT_hash_handle hh;
} HashMapItem; 

typedef struct {
    int key;
    UT_hash_handle hh;
} HashSetItem; 

struct ListNode* creatListNode(int val) {
    struct ListNode *obj = (struct ListNode*)malloc(sizeof(struct ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

HashMapItem *hashMapFindItem(HashMapItem **obj, int key) {
    HashMapItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

struct ListNode* hashMapGetItem(HashMapItem **obj, int key) {
    HashMapItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    if (!pEntry) {
        return NULL;
    } else {
        return pEntry->val;
    }
}

bool hashMapAddItem(HashMapItem **obj, int key, int val) {
    HashMapItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    struct ListNode *node = creatListNode(val);
    if (pEntry) {
        node ->next = pEntry->val;
        pEntry->val = node;
    } else {
        pEntry = (HashMapItem *)malloc(sizeof(HashMapItem));
        pEntry->key = key;
        pEntry->val = node;
        HASH_ADD_INT(*obj, key, pEntry);
    }
    return true;
}

void freeList(struct ListNode *list) {
    while (list) {
        struct ListNode *p = list;
        list = list->next;
        free(p);
    }
}

void hashMapFree(HashMapItem **obj) {
    HashMapItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        freeList(curr->val);
        free(curr);
    }
}

HashSetItem *hashSetFindItem(HashSetItem **obj, int key) {
    HashSetItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
} 

void hashSetAddItem(HashSetItem **obj, int key) {
    HashSetItem *pEntry = hashSetFindItem(obj, key);
    if (!pEntry) {
        pEntry = (HashSetItem *)malloc(sizeof(HashSetItem));
        pEntry->key = key;
        HASH_ADD_INT(*obj, key, pEntry);
    }
}

void hashSetFree(HashSetItem **obj) {
    HashSetItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

void dfs(struct TreeNode *node, HashMapItem **graph) {
    if (node == NULL) {
        return;
    }
    struct TreeNode *arr[2] = {node->left, node->right};
    for (int i = 0; i < 2; i++) {
        if (arr[i] != NULL) {
            hashMapAddItem(graph, node->val, arr[i]->val);
            hashMapAddItem(graph, arr[i]->val, node->val);
            dfs(arr[i], graph);
        }
    }
};

typedef struct Pair {
    int node;
    int time;
} Pair;

int amountOfTime(struct TreeNode *root, int start) {
    HashMapItem *graph = NULL;
    dfs(root, &graph);

    int nodeSize = HASH_COUNT(graph)  + 1;
    Pair q[nodeSize];
    int head = 0, tail = 0;
    q[tail].node = start;
    q[tail].time = 0;
    tail++;

    HashSetItem *visited = NULL;
    hashSetAddItem(&visited, start);
    int time = 0;
    while (head != tail) {
        int nodeVal = q[head].node;
        time = q[head].time;
        head++;
        for (struct ListNode *p = hashMapGetItem(&graph, nodeVal); p != NULL; p = p->next) {
            int childVal = p->val;
            if (!hashSetFindItem(&visited, childVal)) {
                int childVal = p->val;
                q[tail].node = childVal;
                q[tail].time = time + 1;
                tail++;
                hashSetAddItem(&visited, childVal);
            }
        }
    }
    hashMapFree(&graph);
    hashSetFree(&visited);
    return time;
}
```

```javascript
var amountOfTime = function(root, start) {
    const graph = new Map();
    const dfs = (node) => {
        [node.left, node.right].forEach((child) => {
            if (child !== null) {
                graph.has(node.val) ? graph.get(node.val).push(child.val) : graph.set(node.val, [child.val]);
                graph.has(child.val) ? graph.get(child.val).push(node.val) : graph.set(child.val, [node.val]);
                dfs(child);
            }
        });
    };
   
    dfs(root);
    const q = [[start, 0]];
    visited = new Set([start]);
    let time = 0;
    while (q.length > 0) {
        const [nodeVal, currTime] = q.shift();
        time = currTime;
        if (graph.has(nodeVal)) {
            graph.get(nodeVal).forEach((childVal) => {
                if (!visited.has(childVal)) {
                    q.push([childVal, time + 1]);
                    visited.add(childVal);
                }
            });
        }
    }
    return time;
};
```

```typescript
function amountOfTime(root: TreeNode | null, start: number): number {
    const graph: Map<number, number[]> = new Map();
    const dfs = (node: TreeNode) => {
        [node.left, node.right].forEach((child) => {
            if (child !== null) {
                graph.has(node.val) ? graph.get(node.val).push(child.val) : graph.set(node.val, [child.val]);
                graph.has(child.val) ? graph.get(child.val).push(node.val) : graph.set(child.val, [node.val]);
                dfs(child);
            }
        });
    };
    dfs(root);

    const q = [[start, 0]];
    const visited: Set<number> = new Set([start]);
    let time = 0;
    while (q.length > 0) {
        const [nodeVal, currTime] = q.shift()!;
        time = currTime;
        if (graph.has(nodeVal)) {
            graph.get(nodeVal)!.forEach((childVal) => {
                if (!visited.has(childVal)) {
                    q.push([childVal, time + 1]);
                    visited.add(childVal);
                }
            });
        }
    }
    return time;
};
```

```rust
use std::rc::Rc;
use std::cell::RefCell;
use std::collections::{HashMap, HashSet, VecDeque};

impl Solution {
    pub fn amount_of_time(root: Option<Rc<RefCell<TreeNode>>>, start: i32) -> i32 {
        let mut graph: HashMap<i32, Vec<i32>> = HashMap::new();
        let mut visited: HashSet<i32> = HashSet::new();
        
        fn dfs(node_opt: Option<&Rc<RefCell<TreeNode>>>, graph: &mut HashMap<i32, Vec<i32>>) {
            if let Some(node_ref) = node_opt {
                let node = node_ref.borrow();
                if let Some(ref left) = &node.left {
                    graph.entry(node.val).or_insert_with(Vec::new).push(left.borrow().val);
                    graph.entry(left.borrow().val).or_insert_with(Vec::new).push(node.val);
                    dfs(Some(&left), graph);
                }
                if let Some(ref right) = &node.right {
                    graph.entry(node.val).or_insert_with(Vec::new).push(right.borrow().val);
                    graph.entry(right.borrow().val).or_insert_with(Vec::new).push(node.val);
                    dfs(Some(&right), graph);
                }
            }
        }
        
        if let Some(node) = root.as_ref() {
            dfs(Some(&node), &mut graph);
        }

        let mut q = VecDeque::new();
        let mut time = 0;
        q.push_back((start, 0));
        visited.insert(start);
        while let Some((node_val, curr_time)) = q.pop_front() {
            time = curr_time;
            if let Some(children) = graph.get(&node_val) {
                for &child_val in children {
                    if !visited.contains(&child_val) {
                        q.push_back((child_val, time + 1));
                        visited.insert(child_val);
                    }
                }
            }
        }
        time
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是树的节点个数。
- 空间复杂度：$O(n)$。
