### [根据描述创建二叉树](https://leetcode.cn/problems/create-binary-tree-from-descriptions/solutions/1365049/gen-ju-miao-shu-chuang-jian-er-cha-shu-b-sqrk/)

#### 方法一：哈希表

**思路与算法**

由于数组 $descriptions$ 中用节点的数值表示对应节点，因此为了方便查找，我们用哈希表 $nodes$ 来维护数值到对应节点的映射。

我们可以遍历数组 $descriptions$ 来创建二叉树。具体地，当我们遍历到三元组 $[p,c,left]$ 时，我们首先判断 $nodes$ 中是否存在 $p$ 与 $c$ 对应的树节点，如果没有则我们新建一个数值为对应值的节点。随后，我们根据 $left$ 的真假将 $p$ 对应的节点的左或右子节点设为 $c$ 对应的节点。当遍历完成后，我们就重建出了目标二叉树。

除此之外，我们还需要寻找二叉树的根节点。这个过程也可以在遍历和建树的过程中完成。我们可以同样用一个哈希表 $isRoot$ 维护数值与是否为根节点的映射。在遍历时，我们需要将 $isRoot[c]$ 设为 $false$（因为该节点有父节点）；而如果 $p$ 在 $isRoot$ 中不存在，则说明 $p$ **暂时**没有父节点，我们可以将 $isRoot[c]$ 设为 $true$。最终在遍历完成后，一定**有且仅有一个**元素 $root$ 在 $isRoot$ 中的数值为 $true$，此时对应的 $node[i]$ 为二叉树的根节点，我们返回该节点作为答案。

**代码**

```C++
class Solution {
public:
    TreeNode* createBinaryTree(vector<vector<int>>& descriptions) {
        unordered_map<int, bool> isRoot;   // 数值对应的节点是否为根节点的哈希表
        unordered_map<int, TreeNode*> nodes;   // 数值与对应节点的哈希表
        for (const auto& d: descriptions) {
            int p = d[0];
            int c = d[1];
            bool left = d[2];
            if (!isRoot.count(p)) {
                isRoot[p] = true;
            }
            isRoot[c] = false;
            // 创建或更新节点
            if (!nodes.count(p)) {
                nodes[p] = new TreeNode(p);
            }
            if (!nodes.count(c)) {
                nodes[c] = new TreeNode(c);
            }
            if (left) {
                nodes[p]->left = nodes[c];
            } else {
                nodes[p]->right = nodes[c];
            }
        }
        // 寻找根节点
        int root = -1;
        for (const auto& [val, r]: isRoot) {
            if (r) {
                root = val;
                break;
            }
        }
        return nodes[root];
    }
};
```

```Python
class Solution:
    def createBinaryTree(self, descriptions: List[List[int]]) -> Optional[TreeNode]:
        isRoot = {}   # 数值对应的节点是否为根节点的哈希表
        nodes = {}   # 数值与对应节点的哈希表
        for p, c, left in descriptions:
            if p not in isRoot:
                isRoot[p] = True
            isRoot[c] = False
            # 创建或更新节点
            if p not in nodes:
                nodes[p] = TreeNode(p)
            if c not in nodes:
                nodes[c] = TreeNode(c)
            if left:
                nodes[p].left = nodes[c]
            else:
                nodes[p].right = nodes[c]
        # 寻找根节点
        root = -1
        for val, r in isRoot.items():
            if r:
                root = val
                break
        return nodes[root]
```

```Java
class Solution {
    public TreeNode createBinaryTree(int[][] descriptions) {
        Map<Integer, Boolean> isRoot = new HashMap<>();  // 数值对应的节点是否为根节点的哈希表
        Map<Integer, TreeNode> nodes = new HashMap<>();  // 数值与对应节点的哈希表

        for (int[] d : descriptions) {
            int p = d[0];
            int c = d[1];
            boolean left = d[2] == 1;

            if (!isRoot.containsKey(p)) {
                isRoot.put(p, true);
            }
            isRoot.put(c, false);

            // 创建或更新节点
            if (!nodes.containsKey(p)) {
                nodes.put(p, new TreeNode(p));
            }
            if (!nodes.containsKey(c)) {
                nodes.put(c, new TreeNode(c));
            }

            if (left) {
                nodes.get(p).left = nodes.get(c);
            } else {
                nodes.get(p).right = nodes.get(c);
            }
        }

        // 寻找根节点
        int root = -1;
        for (Map.Entry<Integer, Boolean> entry : isRoot.entrySet()) {
            if (entry.getValue()) {
                root = entry.getKey();
                break;
            }
        }

        return nodes.get(root);
    }
}
```

```CSharp
public class Solution {
    public TreeNode CreateBinaryTree(int[][] descriptions) {
        Dictionary<int, bool> isRoot = new Dictionary<int, bool>();  // 数值对应的节点是否为根节点的哈希表
        Dictionary<int, TreeNode> nodes = new Dictionary<int, TreeNode>();  // 数值与对应节点的哈希表

        foreach (int[] d in descriptions) {
            int p = d[0];
            int c = d[1];
            bool left = d[2] == 1;

            if (!isRoot.ContainsKey(p)) {
                isRoot[p] = true;
            }
            isRoot[c] = false;

            // 创建或更新节点
            if (!nodes.ContainsKey(p)) {
                nodes[p] = new TreeNode(p);
            }
            if (!nodes.ContainsKey(c)) {
                nodes[c] = new TreeNode(c);
            }

            if (left) {
                nodes[p].left = nodes[c];
            } else {
                nodes[p].right = nodes[c];
            }
        }

        // 寻找根节点
        int root = -1;
        foreach (var entry in isRoot) {
            if (entry.Value) {
                root = entry.Key;
                break;
            }
        }

        return nodes[root];
    }
}
```

```Go
func createBinaryTree(descriptions [][]int) *TreeNode {
    isRoot := make(map[int]bool)  // 数值对应的节点是否为根节点的哈希表
    nodes := make(map[int]*TreeNode)  // 数值与对应节点的哈希表

    for _, d := range descriptions {
        p := d[0]
        c := d[1]
        left := d[2] == 1

        if _, exists := isRoot[p]; !exists {
            isRoot[p] = true
        }
        isRoot[c] = false

        // 创建或更新节点
        if _, exists := nodes[p]; !exists {
            nodes[p] = &TreeNode{Val: p}
        }
        if _, exists := nodes[c]; !exists {
            nodes[c] = &TreeNode{Val: c}
        }

        if left {
            nodes[p].Left = nodes[c]
        } else {
            nodes[p].Right = nodes[c]
        }
    }

    // 寻找根节点
    root := -1
    for val, isRootNode := range isRoot {
        if isRootNode {
            root = val
            break
        }
    }

    return nodes[root]
}
```

```C
typedef struct {
    int key;
    struct TreeNode *val;
    UT_hash_handle hh;
} NodeHashItem;

typedef struct {
    int key;
    bool val;
    UT_hash_handle hh;
} RootHashItem;

NodeHashItem *nodeHashFindItem(NodeHashItem **obj, int key) {
    NodeHashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool nodeHashAddItem(NodeHashItem **obj, int key, struct TreeNode *val) {
    if (nodeHashFindItem(obj, key)) {
        return false;
    }
    NodeHashItem *pEntry = (NodeHashItem *)malloc(sizeof(NodeHashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

struct TreeNode *nodeHashGetItem(NodeHashItem **obj, int key, struct TreeNode *defaultVal) {
    NodeHashItem *pEntry = nodeHashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

void nodeHashFree(NodeHashItem **obj) {
    NodeHashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr);
    }
}

RootHashItem *rootHashFindItem(RootHashItem **obj, int key) {
    RootHashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool rootHashSetItem(RootHashItem **obj, int key, bool val) {
    RootHashItem *pEntry = rootHashFindItem(obj, key);
    if (!pEntry) {
        pEntry = (RootHashItem *)malloc(sizeof(RootHashItem));
        pEntry->key = key;
        pEntry->val = val;
        HASH_ADD_INT(*obj, key, pEntry);
    } else {
        pEntry->val = val;
    }
    return true;
}

bool rootHashGetItem(RootHashItem **obj, int key, bool defaultVal) {
    RootHashItem *pEntry = rootHashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

void rootHashFree(RootHashItem **obj) {
    RootHashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr);
    }
}

struct TreeNode* createTreeNode(int val) {
    struct TreeNode* node = (struct TreeNode*)malloc(sizeof(struct TreeNode));
    node->val = val;
    node->left = NULL;
    node->right = NULL;
    return node;
}

struct TreeNode* createBinaryTree(int** descriptions, int descriptionsSize, int* descriptionsColSize) {
    NodeHashItem *nodes = NULL; // 数值对应的节点是否为根节点的哈希表
    RootHashItem *isRoot = NULL; // 数值与对应节点的哈希表

    for (int i = 0; i < descriptionsSize; i++) {
        int p = descriptions[i][0];
        int c = descriptions[i][1];
        bool left = descriptions[i][2] == 1;
        RootHashItem *parentRootEntry = rootHashFindItem(&isRoot, p);
        if (!parentRootEntry) {
            rootHashSetItem(&isRoot, p, true);
        }

        rootHashSetItem(&isRoot, c, false);
        struct TreeNode *parent = nodeHashGetItem(&nodes, p, NULL);
        if (!parent) {
            parent = createTreeNode(p);
            nodeHashAddItem(&nodes, p, parent);
        }

        // 创建或获取子节点
        struct TreeNode *child = nodeHashGetItem(&nodes, c, NULL);
        if (!child) {
            child = createTreeNode(c);
            nodeHashAddItem(&nodes, c, child);
        }

        // 建立连接
        if (left) {
            parent->left = child;
        } else {
            parent->right = child;
        }
    }

    // 寻找根节点
    int rootVal = -1;
    RootHashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, isRoot, curr, tmp) {
        if (curr->val) {
            rootVal = curr->key;
            break;
        }
    }

    struct TreeNode *root = nodeHashGetItem(&nodes, rootVal, NULL);
    nodeHashFree(&nodes);
    rootHashFree(&isRoot);

    return root;
}
```

```JavaScript
var createBinaryTree = function(descriptions) {
    const isRoot = new Map();  // 数值对应的节点是否为根节点的哈希表
    const nodes = new Map();   // 数值与对应节点的哈希表

    for (const d of descriptions) {
        const p = d[0];
        const c = d[1];
        const left = d[2] === 1;

        if (!isRoot.has(p)) {
            isRoot.set(p, true);
        }
        isRoot.set(c, false);

        // 创建或更新节点
        if (!nodes.has(p)) {
            nodes.set(p, new TreeNode(p));
        }
        if (!nodes.has(c)) {
            nodes.set(c, new TreeNode(c));
        }

        if (left) {
            nodes.get(p).left = nodes.get(c);
        } else {
            nodes.get(p).right = nodes.get(c);
        }
    }

    // 寻找根节点
    let root = -1;
    for (const [val, isRootNode] of isRoot.entries()) {
        if (isRootNode) {
            root = val;
            break;
        }
    }

    return nodes.get(root);
};
```

```TypeScript
function createBinaryTree(descriptions: number[][]): TreeNode | null {
    const isRoot = new Map<number, boolean>();  // 数值对应的节点是否为根节点的哈希表
    const nodes = new Map<number, TreeNode>();  // 数值与对应节点的哈希表

    for (const d of descriptions) {
        const p = d[0];
        const c = d[1];
        const left = d[2] === 1;

        if (!isRoot.has(p)) {
            isRoot.set(p, true);
        }
        isRoot.set(c, false);

        // 创建或更新节点
        if (!nodes.has(p)) {
            nodes.set(p, new TreeNode(p));
        }
        if (!nodes.has(c)) {
            nodes.set(c, new TreeNode(c));
        }

        if (left) {
            nodes.get(p)!.left = nodes.get(c)!;
        } else {
            nodes.get(p)!.right = nodes.get(c)!;
        }
    }

    // 寻找根节点
    let root = -1;
    for (const [val, isRootNode] of isRoot.entries()) {
        if (isRootNode) {
            root = val;
            break;
        }
    }

    return nodes.get(root) || null;
}
```

```Rust
use std::cell::RefCell;
use std::collections::HashMap;
use std::rc::Rc;

impl Solution {
    pub fn create_binary_tree(descriptions: Vec<Vec<i32>>) -> Option<Rc<RefCell<TreeNode>>> {
        let mut is_root: HashMap<i32, bool> = HashMap::new();  // 数值对应的节点是否为根节点的哈希表
        let mut nodes: HashMap<i32, Rc<RefCell<TreeNode>>> = HashMap::new();  // 数值与对应节点的哈希表

        for d in descriptions {
            let p = d[0];
            let c = d[1];
            let left = d[2] == 1;

            if !is_root.contains_key(&p) {
                is_root.insert(p, true);
            }
            is_root.insert(c, false);

            // 创建或更新节点
            if !nodes.contains_key(&p) {
                nodes.insert(p, Rc::new(RefCell::new(TreeNode::new(p))));
            }
            if !nodes.contains_key(&c) {
                nodes.insert(c, Rc::new(RefCell::new(TreeNode::new(c))));
            }

            let parent = nodes.get(&p).unwrap().clone();
            let child = nodes.get(&c).unwrap().clone();

            if left {
                parent.borrow_mut().left = Some(child);
            } else {
                parent.borrow_mut().right = Some(child);
            }
        }

        // 寻找根节点
        let mut root_val = -1;
        for (val, is_root_node) in is_root {
            if is_root_node {
                root_val = val;
                break;
            }
        }

        nodes.get(&root_val).cloned()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为数组 $descriptions$ 的长度。即为遍历构造二叉树并寻找根节点的时间复杂度。
- 空间复杂度：$O(n)$，即为哈希表的空间开销。
