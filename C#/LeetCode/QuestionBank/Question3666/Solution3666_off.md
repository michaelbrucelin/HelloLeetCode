### [使二进制字符串全为 1 的最少操作次数](https://leetcode.cn/problems/minimum-operations-to-equalize-binary-string/solutions/3906195/shi-er-jin-zhi-zi-fu-chuan-quan-wei-1-de-2z1u/)

#### 方法一：广度优先搜索

根据题意可知，题目定义的操作与 $s$ 的字符所在下标无关，因此我们可以使用字符串中 $'0'$ 的数目 $m$ 来表示每次操作后得到的翻转结果。

令 $n$ 为字符串 $s$ 的长度。对于 $m$，在一次操作中，我们可以选择 $c$ 个 $'0'$ 和 $k-c$ 个 $'1'$ 进行翻转，那么 $c$ 的取值需要满足以下约束：

1. 最多取 $min(m,k)$ 个 $'0'$，即
    $$0\le c\le min(m,k)$$
2. 最多取 $n-m$ 个 $'1'$，即
    $$k-c\le n-m$$

将以上范围汇总，有：

$$max(k-n+m,0)\le c\le min(m,k)$$

令 $c_1=max(k-n+m,0)$ 和 $c_2=min(m,k)$，那么一次操作后字符串 $m$ 可以得到的翻转结果为：

$$m+k-2\times c,c\in [c_1,c_2]$$

观察可知 $m$ 一次操作得到的翻转结果为奇数连续区间或偶数连续区间。因此我们可以基于广度优先搜索来计算使字符串中所有字符都等于 $'1'$ 所需的最少操作次数。同时根据以上定义，翻转结果取值范围为 $[0,n]$，我们使用两个有序集合分别保存还没计算出最少操作次数的奇数翻转结果和偶数翻转结果，使用数组 $dist$ 记录初始字符串 $s$ 到每个翻转结果的最少操作次数，将初始字符串对应的翻转结果放到队列中，并从对应有序集合中移除：

1. 从队列中获取元素 $m$，那么一次操作后 $m$ 可以得到的最小翻转结果为 $lnode=m+k-2\times c_2$，最大翻转结果为 $rnode=m+k-2\times c_1$
2. 根据 $lnode$ 的奇偶性，选择对应的有序集合
3. 不断查找有序集合，找到满足 $lnode\le m_2\le rnode$ 的元素 $m_2$，那么有 $dist[m_2]=dist[m]+1$，将 $m_2$ 放到队列，并从有序集合删除
4. 队列为空时，直接终止流程

执行完广度优先搜索后，如果操作后能得到翻转结果 $0$，那么返回 $dist[0]$，否则返回 $-1$。

```C++
class Solution {
public:
    int minOperations(string s, int k) {
        int n = s.size(), m = 0;
        vector<int> dist(n + 1, INT_MAX);
        vector<set<int>> nodeSets(2);
        for (int i = 0; i <= n; i++) {
            nodeSets[i % 2].insert(i);
            if (i < n && s[i] == '0') {
                m++;
            }
        }
        queue<int> q;
        q.push(m);
        dist[m] = 0;
        nodeSets[m % 2].erase(m);
        while (!q.empty()) {
            m = q.front();
            q.pop();
            int c1 = max(k - n + m, 0), c2 = min(m, k);
            int lnode = m + k - 2 * c2, rnode = m + k - 2 * c1;
            auto& nodeSet = nodeSets[lnode % 2];
            for (auto iter = nodeSet.lower_bound(lnode); iter != nodeSet.end() && *iter <= rnode;) {
                int m2 = *iter;
                dist[m2] = dist[m] + 1;
                q.push(m2);
                iter = next(iter);
                nodeSet.erase(m2);
            }
        }
        return dist[0] == INT_MAX ? -1 : dist[0];
    }
};
```

```Go
func minOperations(s string, k int) int {
	n, m := len(s), 0
	dist := make([]int, n+1)
	for i := range dist {
		dist[i] = math.MaxInt32
	}
	nodeSets := make([]*redblacktree.Tree, 2)
	nodeSets[0] = redblacktree.NewWithIntComparator()
	nodeSets[1] = redblacktree.NewWithIntComparator()
	for i := 0; i <= n; i++ {
		nodeSets[i % 2].Put(i, struct{}{})
		if i < n && s[i] == '0' {
			m++
		}
	}
	q := []int{m}
	dist[m] = 0
	nodeSets[m % 2].Remove(m)
	for len(q) > 0 {
		m := q[0]
        q = q[1:]
		c1, c2 := max(k - n + m, 0), min(k, m)
		lnode, rnode := m + k - 2 * c2, m + k - 2 * c1
		nodeSet := nodeSets[lnode % 2]
		for m2, found := nodeSet.Ceiling(lnode); found && m2.Key.(int) <= rnode; m2, found = nodeSet.Ceiling(lnode) {
			dist[m2.Key.(int)] = dist[m] + 1
            q = append(q, m2.Key.(int))
			nodeSet.Remove(m2.Key.(int))
		}
	}
	if dist[0] == math.MaxInt32 {
		return -1
	}
	return dist[0]
}
```

```Python
class Solution:
    def minOperations(self, s: str, k: int) -> int:
        n, m = len(s), s.count('0')
        dist = [math.inf] * (n + 1)
        nodeSets = [
            SortedList(range(0, n + 1, 2)),
            SortedList(range(1, n + 1, 2))
        ]
        q = deque([m])
        dist[m] = 0
        nodeSets[m % 2].remove(m)
        while q:
            m = q.popleft()
            c1, c2 = max(k - n + m, 0), min(m, k)
            lnode, rnode = m + k - 2 * c2, m + k - 2 * c1
            nodeSet = nodeSets[lnode % 2]
            idx = nodeSet.bisect_left(lnode)
            while idx < len(nodeSet) and nodeSet[idx] <= rnode:
                m2 = nodeSet[idx]
                dist[m2] = dist[m] + 1
                q.append(m2)
                nodeSet.pop(idx)
        return -1 if dist[0] == math.inf else dist[0]
```

```Java
class Solution {
    public int minOperations(String s, int k) {
        int n = s.length(), m = 0;
        int[] dist = new int[n + 1];
        Arrays.fill(dist, Integer.MAX_VALUE);
        List<TreeSet<Integer>> nodeSets = new ArrayList<>();
        nodeSets.add(new TreeSet<>());
        nodeSets.add(new TreeSet<>());
        for (int i = 0; i <= n; i++) {
            nodeSets.get(i % 2).add(i);
            if (i < n && s.charAt(i) == '0') {
                m++;
            }
        }
        Queue<Integer> q = new ArrayDeque<>();
        q.offer(m);
        dist[m] = 0;
        nodeSets.get(m % 2).remove(m);
        while (!q.isEmpty()) {
            m = q.poll();
            int c1 = Math.max(k - n + m, 0), c2 = Math.min(m, k);
            int lnode = m + k - 2 * c2, rnode = m + k - 2 * c1;
            TreeSet<Integer> nodeSet = nodeSets.get(lnode % 2);
            for (Integer m2 = nodeSet.ceiling(lnode); m2 != null && m2 <= rnode; m2 = nodeSet.ceiling(lnode)) {
                dist[m2] = dist[m] + 1;
                q.offer(m2);
                nodeSet.remove(m2);
            }
        }
        return dist[0] == Integer.MAX_VALUE ? -1 : dist[0];
    }
}
```

```CSharp
public class Solution {
    public int MinOperations(string s, int k) {
        int n = s.Length, m = 0;
        int[] dist = new int[n + 1];
        for (int i = 0; i <= n; i++) dist[i] = int.MaxValue;

        List<SortedSet<int>> nodeSets = new List<SortedSet<int>>();
        nodeSets.Add(new SortedSet<int>());
        nodeSets.Add(new SortedSet<int>());
        for (int i = 0; i <= n; i++) {
            nodeSets[i % 2].Add(i);
            if (i < n && s[i] == '0') {
                m++;
            }
        }

        Queue<int> q = new Queue<int>();
        q.Enqueue(m);
        dist[m] = 0;
        nodeSets[m % 2].Remove(m);
        while (q.Count > 0) {
            m = q.Dequeue();
            int c1 = Math.Max(k - n + m, 0);
            int c2 = Math.Min(m, k);
            int lnode = m + k - 2 * c2;
            int rnode = m + k - 2 * c1;

            var nodeSet = nodeSets[lnode % 2];
            var toRemove = new List<int>();
            var view = nodeSet.GetViewBetween(lnode, rnode);
            foreach (var val in view) {
                toRemove.Add(val);
            }
            foreach (int m2 in toRemove) {
                dist[m2] = dist[m] + 1;
                q.Enqueue(m2);
                nodeSet.Remove(m2);
            }
        }

        return dist[0] == int.MaxValue ? -1 : dist[0];
    }
}
```

```C
typedef struct AVLNode {
    int val;
    struct AVLNode* left;
    struct AVLNode* right;
    int height;
} AVLNode;

typedef struct {
    AVLNode* root;
    int size;
} AVLTree;

typedef struct {
    int* data;
    int front;
    int rear;
    int capacity;
} Queue;

int getHeight(AVLNode* node) {
    return node ? node->height : 0;
}

int max(int a, int b) {
    return a > b ? a : b;
}

AVLNode* createAVLNode(int val) {
    AVLNode* node = (AVLNode*)malloc(sizeof(AVLNode));
    node->val = val;
    node->left = NULL;
    node->right = NULL;
    node->height = 1;
    return node;
}

AVLNode* rotateRight(AVLNode* y) {
    AVLNode* x = y->left;
    AVLNode* T2 = x->right;
    x->right = y;
    y->left = T2;
    y->height = max(getHeight(y->left), getHeight(y->right)) + 1;
    x->height = max(getHeight(x->left), getHeight(x->right)) + 1;

    return x;
}

AVLNode* rotateLeft(AVLNode* x) {
    AVLNode* y = x->right;
    AVLNode* T2 = y->left;

    y->left = x;
    x->right = T2;
    x->height = max(getHeight(x->left), getHeight(x->right)) + 1;
    y->height = max(getHeight(y->left), getHeight(y->right)) + 1;

    return y;
}

int getBalance(AVLNode* node) {
    if (!node) return 0;
    return getHeight(node->left) - getHeight(node->right);
}

AVLNode* insertNode(AVLNode* node, int val) {
    if (!node) {
        return createAVLNode(val);
    }
    if (val < node->val) {
        node->left = insertNode(node->left, val);
    } else if (val > node->val) {
        node->right = insertNode(node->right, val);
    } else {
        return node;
    }

    node->height = 1 + max(getHeight(node->left), getHeight(node->right));
    int balance = getBalance(node);
    if (balance > 1 && val < node->left->val) {
        return rotateRight(node);
    }
    if (balance < -1 && val > node->right->val) {
        return rotateLeft(node);
    }
    if (balance > 1 && val > node->left->val) {
        node->left = rotateLeft(node->left);
        return rotateRight(node);
    }
    if (balance < -1 && val < node->right->val) {
        node->right = rotateRight(node->right);
        return rotateLeft(node);
    }

    return node;
}

AVLNode* minValueNode(AVLNode* node) {
    AVLNode* current = node;
    while (current && current->left) {
        current = current->left;
    }
    return current;
}

AVLNode* deleteNode(AVLNode* root, int val) {
    if (!root) {
        return NULL;
    }
    if (val < root->val) {
        root->left = deleteNode(root->left, val);
    } else if (val > root->val) {
        root->right = deleteNode(root->right, val);
    } else {
        if (!root->left || !root->right) {
            AVLNode* temp = root->left ? root->left : root->right;
            if (!temp) {
                free(root);
                return NULL;
            } else {
                AVLNode* child = temp;
                *root = *child;
                free(child);
            }
        } else {
            AVLNode* temp = minValueNode(root->right);
            root->val = temp->val;
            root->right = deleteNode(root->right, temp->val);
        }
    }

    if (!root) {
        return NULL;
    }

    root->height = 1 + max(getHeight(root->left), getHeight(root->right));
    int balance = getBalance(root);
    if (balance > 1 && getBalance(root->left) >= 0) {
        return rotateRight(root);
    }
    if (balance > 1 && getBalance(root->left) < 0) {
        root->left = rotateLeft(root->left);
        return rotateRight(root);
    }
    if (balance < -1 && getBalance(root->right) <= 0) {
        return rotateLeft(root);
    }
    if (balance < -1 && getBalance(root->right) > 0) {
        root->right = rotateRight(root->right);
        return rotateLeft(root);
    }

    return root;
}

int lowerBound(AVLNode* root, int val) {
    int result = -1;
    AVLNode* current = root;

    while (current) {
        if (current->val >= val) {
            result = current->val;
            current = current->left;
        } else {
            current = current->right;
        }
    }

    return result;
}

AVLTree* createAVLTree() {
    AVLTree* tree = (AVLTree*)malloc(sizeof(AVLTree));
    tree->root = NULL;
    tree->size = 0;
    return tree;
}

void avlInsert(AVLTree* tree, int val) {
    tree->root = insertNode(tree->root, val);
    tree->size++;
}

void avlRemove(AVLTree* tree, int val) {
    tree->root = deleteNode(tree->root, val);
    tree->size--;
}

Queue* createQueue(int capacity) {
    Queue* q = (Queue*)malloc(sizeof(Queue));
    q->data = (int*)malloc(capacity * sizeof(int));
    q->front = 0;
    q->rear = 0;
    q->capacity = capacity;
    return q;
}

void enqueue(Queue* q, int val) {
    if (q->rear < q->capacity) {
        q->data[q->rear++] = val;
    }
}

int dequeue(Queue* q) {
    if (q->front < q->rear) {
        return q->data[q->front++];
    }
    return -1;
}

int isQueueEmpty(Queue* q) {
    return q->front >= q->rear;
}

void freeQueue(Queue* q) {
    if (q) {
        free(q->data);
        free(q);
    }
}

void freeAVLNode(AVLNode* node) {
    if (node) {
        freeAVLNode(node->left);
        freeAVLNode(node->right);
        free(node);
    }
}

void freeAVLTree(AVLTree* tree) {
    if (tree) {
        freeAVLNode(tree->root);
        free(tree);
    }
}

int minOperations(char* s, int k) {
    int n = strlen(s);
    int m = 0;

    int* dist = (int*)malloc((n + 1) * sizeof(int));
    for (int i = 0; i <= n; i++) {
        dist[i] = INT_MAX;
    }

    AVLTree* trees[2];
    trees[0] = createAVLTree();
    trees[1] = createAVLTree();
    for (int i = 0; i <= n; i++) {
        avlInsert(trees[i % 2], i);
        if (i < n && s[i] == '0') {
            m++;
        }
    }

    Queue* q = createQueue(n + 1);
    enqueue(q, m);
    dist[m] = 0;
    avlRemove(trees[m % 2], m);

    while (!isQueueEmpty(q)) {
        m = dequeue(q);
        int c1 = (k - n + m) > 0 ? (k - n + m) : 0;
        int c2 = m < k ? m : k;
        int lnode = m + k - 2 * c2;
        int rnode = m + k - 2 * c1;

        AVLTree* currentTree = trees[lnode % 2];
        while (true) {
            int nodeVal = lowerBound(currentTree->root, lnode);
            if (nodeVal == -1 || nodeVal > rnode) {
                break;
            }
            dist[nodeVal] = dist[m] + 1;
            enqueue(q, nodeVal);
            avlRemove(currentTree, nodeVal);
            lnode = nodeVal + 1;
        }
    }

    int result = dist[0] == INT_MAX ? -1 : dist[0];
    free(dist);
    freeQueue(q);
    freeAVLTree(trees[0]);
    freeAVLTree(trees[1]);

    return result;
}
```

```JavaScript
const { AvlTree } = require('@datastructures-js/binary-search-tree');

var minOperations = function(s, k) {
    const n = s.length;
    let m = 0;

    const dist = new Array(n + 1).fill(Infinity);
    const nodeTrees = [new AvlTree(), new AvlTree()];
    for (let i = 0; i <= n; i++) {
        nodeTrees[i % 2].insert(i);
        if (i < n && s[i] === '0') {
            m++;
        }
    }

    const queue = new Array(n + 1);
    let head = 0, tail = 0;
    queue[tail++] = m;

    dist[m] = 0;
    nodeTrees[m % 2].remove(m);

    while (head < tail) {
        const currentM = queue[head++];
        const c1 = Math.max(k - n + currentM, 0);
        const c2 = Math.min(currentM, k);
        const lnode = currentM + k - 2 * c2;
        const rnode = currentM + k - 2 * c1;
        const currentTree = nodeTrees[lnode % 2];
        let node = currentTree.upperBound(lnode, true);

        while (node !== null) {
            const nodeValue = node.getValue();
            if (nodeValue > rnode) {
                break;
            }
            dist[nodeValue] = dist[currentM] + 1;
            queue[tail++] = nodeValue;
            const nextNode = currentTree.upperBound(nodeValue, false);
            currentTree.remove(nodeValue);
            node = nextNode;
        }
    }

    return dist[0] === Infinity ? -1 : dist[0];
}
```

```TypeScript
import { AvlTree, AvlTreeNode } from '@datastructures-js/binary-search-tree';

function minOperations(s: string, k: number): number {
    const n: number = s.length;
    let m: number = 0;
    const dist: number[] = new Array(n + 1).fill(Number.MAX_SAFE_INTEGER);

    const nodeTrees: AvlTree<number>[] = [new AvlTree<number>(), new AvlTree<number>()];
    for (let i = 0; i <= n; i++) {
        nodeTrees[i % 2].insert(i);
        if (i < n && s.charAt(i) === '0') {
            m++;
        }
    }

    const queue: number[] = new Array(n + 1);
    let head: number = 0, tail: number = 0;
    queue[tail++] = m;
    dist[m] = 0;
    nodeTrees[m % 2].remove(m);

    while (head < tail) {
        const currentM: number = queue[head++];
        const c1: number = Math.max(k - n + currentM, 0);
        const c2: number = Math.min(currentM, k);
        const lnode: number = currentM + k - 2 * c2;
        const rnode: number = currentM + k - 2 * c1;
        const currentTree: AvlTree<number> = nodeTrees[lnode % 2];

        let node: AvlTreeNode<number> | null = currentTree.upperBound(lnode, true);
        while (node !== null) {
            const nodeValue: number = node.getValue();
            if (nodeValue > rnode) {
                break;
            }
            dist[nodeValue] = dist[currentM] + 1;
            queue[tail++] = nodeValue;

            const nextNode: AvlTreeNode<number> | null = currentTree.upperBound(nodeValue, false);
            currentTree.remove(nodeValue);
            node = nextNode;
        }
    }

    return dist[0] === Number.MAX_SAFE_INTEGER ? -1 : dist[0];
}
```

```Rust
use std::collections::{VecDeque, BTreeSet};
use std::cmp;

impl Solution {
    pub fn min_operations(s: String, k: i32) -> i32 {
        let k = k as usize;
        let chars: Vec<char> = s.chars().collect();
        let n = chars.len();
        let mut m = 0;
        let mut dist = vec![i32::MAX; n + 1];
        let mut node_sets = [BTreeSet::new(), BTreeSet::new()];

        for i in 0..=n {
            node_sets[i % 2].insert(i);
            if i < n && chars[i] == '0' {
                m += 1;
            }
        }

        let mut q = VecDeque::new();
        q.push_back(m);
        dist[m] = 0;
        node_sets[m % 2].remove(&m);

        while let Some(current_m) = q.pop_front() {
            let c1 = cmp::max(k as i32 - n as i32 + current_m as i32, 0) as usize;
            let c2 = cmp::min(current_m, k);

            let lnode = current_m + k - 2 * c2;
            let rnode = current_m + k - 2 * c1;
            let node_set = &mut node_sets[lnode % 2];
            let range: Vec<usize> = node_set.range(lnode..=rnode).copied().collect();

            for m2 in range {
                dist[m2] = dist[current_m] + 1;
                q.push_back(m2);
                node_set.remove(&m2);
            }
        }

        if dist[0] == i32::MAX { -1 } else { dist[0] }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 是字符串 $s$ 的长度。有序集合查找的时间复杂度为 $O(\log n)$，总共有 $n$ 次查找。
- 空间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。
