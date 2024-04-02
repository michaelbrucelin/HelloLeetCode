### [所有可能的真二叉树](https://leetcode.cn/problems/all-possible-full-binary-trees/solutions/2713780/suo-you-ke-neng-de-zhen-er-cha-shu-by-le-1uku/)

#### 方法一：分治

##### 思路与算法

根据题意可知，**真二叉树**中的每个结点的子结点数是 $0$ 或 $2$，此时可以推出**真二叉树**中的结点数 $n$ 为奇数，可以使用数学归纳法证明：

- 当**真二叉树**中只有 $1$ 个结点时，此时 $1$ 为**奇数**，树中唯一的结点是根结点。
- 当**真二叉树**中有 $n$ 个结点时，根据**真二叉树**的定义，此时可将其中一个叶结点增加两个子结点之后仍为**真二叉树**，新的**真二叉树**中有 $n + 2$ 个结点，由于 $n$ 是奇数，此时 $n + 2$ 也是奇数。

由于**真二叉树**中的结点数一定是奇数，因此当给定的节点数 $n$ 是偶数时，此时无法构成**真二叉树**，返回空值即可。当**真二叉树**节点数目 $n$ 大于 $1$ 时，此时**真二叉树**的左子树与右子树也一定为**真二叉树**，则此时左子树的节点数目与右子树的节点数目也一定为**奇数**。

当 $n$ 是奇数时，$n$ 个结点的**真二叉树**满足左子树和右子树的结点数都是奇数，此时左子树和右子树的结点数之和是 $n-1$，假设左子树的数目为 $i$，则左子树的节点数目则为 $n-1-i$，则可以推出左子树与右子树的节点数目序列为：

$$[(1, n - 2), (3, n - 4), (5, n - 6), \cdots, (n - 2, 1)]$$

假设我们分别构节点数目为 $i$ 和节点数目为 $n-1-i$ 的**真二叉树**，即可构造出 $n$ 个结点的**真二叉树**。我们可以利用分治来构造**真二叉树**，分治的终止条件是 $n = 1$。

- 当 $n = 1$ 时，此时只有一个结点的二叉树是**真二叉树**；
- 当 $n > 1$ 时，分别枚举左子树和右子树的根结点数，然后递归地构造左子树和右子树，并返回左子树与右子树的根节点列表。确定左子树与右子树的根节点列表后，分别枚举不同的左子树的根节点与右子树的根节点，从而可以构造出**真二叉树**的根节点。


##### 代码

```c++
class Solution {
public:
    vector<TreeNode*> allPossibleFBT(int n) {
        vector<TreeNode*> fullBinaryTrees;
        if (n % 2 == 0) {
            return fullBinaryTrees;
        }
        if (n == 1) {
            fullBinaryTrees = {new TreeNode(0)};
            return fullBinaryTrees;
        }
        for (int i = 1; i < n; i += 2) {
            vector<TreeNode*> leftSubtrees = allPossibleFBT(i);
            vector<TreeNode*> rightSubtrees = allPossibleFBT(n - 1 - i);
            for (TreeNode* leftSubtree : leftSubtrees) {
                for (TreeNode* rightSubtree : rightSubtrees) {
                    TreeNode *root = new TreeNode(0, leftSubtree, rightSubtree);
                    fullBinaryTrees.emplace_back(root);
                }
            }
        }
        return fullBinaryTrees;
    }
};
```

```java
class Solution {
    public List<TreeNode> allPossibleFBT(int n) {
        List<TreeNode> fullBinaryTrees = new ArrayList<TreeNode>();
        if (n % 2 == 0) {
            return fullBinaryTrees;
        }
        if (n == 1) {
            fullBinaryTrees.add(new TreeNode(0));
            return fullBinaryTrees;
        }
        for (int i = 1; i < n; i += 2) {
            List<TreeNode> leftSubtrees = allPossibleFBT(i);
            List<TreeNode> rightSubtrees = allPossibleFBT(n - 1 - i);
            for (TreeNode leftSubtree : leftSubtrees) {
                for (TreeNode rightSubtree : rightSubtrees) {
                    TreeNode root = new TreeNode(0, leftSubtree, rightSubtree);
                    fullBinaryTrees.add(root);
                }
            }
        }
        return fullBinaryTrees;
    }
}
```

```csharp
public class Solution {
    public IList<TreeNode> AllPossibleFBT(int n) {
        IList<TreeNode> fullBinaryTrees = new List<TreeNode>();
        if (n % 2 == 0) {
            return fullBinaryTrees;
        }
        if (n == 1) {
            fullBinaryTrees.Add(new TreeNode(0));
            return fullBinaryTrees;
        }
        for (int i = 1; i < n; i += 2) {
            IList<TreeNode> leftSubtrees = AllPossibleFBT(i);
            IList<TreeNode> rightSubtrees = AllPossibleFBT(n - 1 - i);
            foreach (TreeNode leftSubtree in leftSubtrees) {
                foreach (TreeNode rightSubtree in rightSubtrees) {
                    TreeNode root = new TreeNode(0, leftSubtree, rightSubtree);
                    fullBinaryTrees.Add(root);
                }
            }
        }
        return fullBinaryTrees;
    }
}
```

```c
typedef struct Node {
    struct TreeNode* val;
    struct Node *next;
} Node;

struct TreeNode* createTreeNode(int val, struct TreeNode* pLeft, struct TreeNode* pRight) {
    struct TreeNode* obj = (struct TreeNode*)malloc(sizeof(struct TreeNode));
    obj->val = val;
    obj->left = pLeft;
    obj->right = pRight;
    return obj;
}

Node *createNode(struct TreeNode* val) {
    Node *obj = (Node *)malloc(sizeof(Node));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

void freeList(Node *list) {
    while (list) {
        Node *p = list;
        list = list->next;
        free(p);
    }
}

struct TreeNode** allPossibleFBT(int n, int* returnSize) {
    struct TreeNode** fullBinaryTrees = NULL;
    if (n % 2 == 0) {
        *returnSize = 0;
        return fullBinaryTrees;
    }
    if (n == 1) {
        fullBinaryTrees = (struct TreeNode**)malloc(sizeof(struct TreeNode*) * 1);
        fullBinaryTrees[0] = createTreeNode(0, NULL, NULL);
        *returnSize = 1;
        return fullBinaryTrees;
    }

    Node *list = NULL, *node = NULL;
    int len = 0;
    for (int i = 1; i < n; i += 2) {
        int leftCount = 0, rightCount = 0;
        struct TreeNode** leftSubtrees = allPossibleFBT(i, &leftCount);
        struct TreeNode** rightSubtrees = allPossibleFBT(n - 1 - i, &rightCount);
        for (int j = 0; j < leftCount; j++) {
            for (int k = 0; k < rightCount; k++) {
                struct TreeNode *leftSubtree = leftSubtrees[j];
                struct TreeNode *rightSubtree = rightSubtrees[k];
                struct TreeNode *root = createTreeNode(0, leftSubtree, rightSubtree);
                node = createNode(root);
                node->next = list;
                list = node;
                len++;
            }
        }
    }

    fullBinaryTrees = (struct TreeNode **)malloc(sizeof(struct TreeNode *) * len);
    int pos = 0;
    *returnSize = len;
    for (node = list; node != NULL; node = node->next) {
        fullBinaryTrees[pos++] = node->val;
    }
    freeList(list);
    return fullBinaryTrees;
}
```

```python
class Solution:
    def allPossibleFBT(self, n: int) -> List[Optional[TreeNode]]:
        full_binary_trees = []
        if n % 2 == 0:
            return full_binary_trees
        if n == 1:
            full_binary_trees.append(TreeNode(0))
            return full_binary_trees
        for i in range(1, n, 2):
            left_subtrees = self.allPossibleFBT(i)
            right_subtrees = self.allPossibleFBT(n - 1 - i)
            for left_subtree in left_subtrees:
                for right_subtree in right_subtrees:
                    root = TreeNode(0, left_subtree, right_subtree)
                    full_binary_trees.append(root)
        return full_binary_trees

```

```go
func allPossibleFBT(n int) []*TreeNode {
    var fullBinaryTrees []*TreeNode
    if n%2 == 0 {
        return fullBinaryTrees
    }
    if n == 1 {
        fullBinaryTrees = append(fullBinaryTrees, &TreeNode{Val: 0})
        return fullBinaryTrees
    }
    for i := 1; i < n; i += 2 {
        leftSubtrees := allPossibleFBT(i)
        rightSubtrees := allPossibleFBT(n - 1 - i)
        for _, leftSubtree := range leftSubtrees {
            for _, rightSubtree := range rightSubtrees {
                root := &TreeNode{Val: 0, Left: leftSubtree, Right: rightSubtree}
                fullBinaryTrees = append(fullBinaryTrees, root)
            }
        }
    }
    return fullBinaryTrees
}
```

```javascript
var allPossibleFBT = function(n) {
    let fullBinaryTrees = [];
    if (n % 2 === 0) {
        return fullBinaryTrees;
    }
    if (n === 1) {
        fullBinaryTrees.push(new TreeNode(0));
        return fullBinaryTrees;
    }
    for (let i = 1; i < n; i += 2) {
        let leftSubtrees = allPossibleFBT(i);
        let rightSubtrees = allPossibleFBT(n - 1 - i);
        for (let leftSubtree of leftSubtrees) {
            for (let rightSubtree of rightSubtrees) {
                let root = new TreeNode(0, leftSubtree, rightSubtree);
                fullBinaryTrees.push(root);
            }
        }
    }
    return fullBinaryTrees;
};
```

```typescript
function allPossibleFBT(n: number): Array<TreeNode | null> {
    let fullBinaryTrees: TreeNode[] = [];
    if (n % 2 === 0) {
        return fullBinaryTrees;
    }
    if (n === 1) {
        fullBinaryTrees.push(new TreeNode(0));
        return fullBinaryTrees;
    }
    for (let i = 1; i < n; i += 2) {
        let leftSubtrees = allPossibleFBT(i);
        let rightSubtrees = allPossibleFBT(n - 1 - i);
        for (let leftSubtree of leftSubtrees) {
            for (let rightSubtree of rightSubtrees) {
                let root = new TreeNode(0, leftSubtree, rightSubtree);
                fullBinaryTrees.push(root);
            }
        }
    }
    return fullBinaryTrees;
};
```

```rust
use std::rc::Rc;
use std::cell::RefCell;

impl Solution {
    pub fn all_possible_fbt(n: i32) -> Vec<Option<Rc<RefCell<TreeNode>>>> {
        let mut full_binary_trees: Vec<Option<Rc<RefCell<TreeNode>>>> = Vec::new();
        if n % 2 == 0 {
            return full_binary_trees;
        }
        if n == 1 {
            full_binary_trees.push(Some(Rc::new(RefCell::new(TreeNode::new(0)))));
            return full_binary_trees;
        }
        for i in (1..n).step_by(2) {
            let left_subtrees = Self::all_possible_fbt(i);
            let right_subtrees = Self::all_possible_fbt(n - 1 - i);
            for left_subtree in left_subtrees {
                for right_subtree in right_subtrees.clone() {
                    let root = Rc::new(RefCell::new(TreeNode { val: 0, left: left_subtree.clone(), right: right_subtree.clone()}));
                    full_binary_trees.push(Some(root.clone()));
                }
            }
        }
        full_binary_trees
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(\dfrac{2^n}{\sqrt{n}})$，其中 $n$ 是给定的**真二叉树**的结点数。只有当 $n$ 是奇数时才存在**真二叉树**，记 $2k+1$，由 $n$ 个结点组成的**真二叉树**的数量是第 $k$ 个卡特兰数 $\dfrac{C(2k, k)}{k + 1} k+1$，其渐进上界为 $O(\dfrac{4^k}{k \sqrt{k}}) = O(\dfrac{2^n}{n \sqrt{n}})$，对于每个**真二叉树**需要 $O(n)$ 的时间生成和添加到答案中，因此时间复杂度是 $O(\dfrac{2^n}{\sqrt{n}})$。
- 空间复杂度：$O(n)$，其中 $n$ 是**真二叉树**的结点数。由于返回值不计入空间复杂度，此时递归深度最多为 $n$，递归调用栈需要 $O(n)$ 的空间。

#### 方法二：动态规划

##### 思路与算法

上述同样的解题思路，我们还可以使用**自底向上**的动态规划。我们可以先构造节点数量为 $1$ 的子树，然后构造节点数量为 $5$ 的子树，然后依次累加即可构造出含有节点数目为 $n$ 的**真二叉树**。

- 节点数目序列分别为 $[(1,1)]$ 的子树可以构造出节点数目 $3$ 的子树；
- 节点数目序列分别为 $[(1,3),(3,1)]$ 的子树可以构造出节点数目 $5$ 的**真二叉树**；
- 节点数目序列分别为 $[(1,5),(3,3),(5,1)]$ 的子树可以构造出节点数目 $7$ 的**真二叉树**；
- 节点数目序列分别为 $[(1,i-2),(3,i-4),\cdots,(i-2,1)]$ 的子树可以构造出节点数目 $i$ 的**真二叉树**；

如果构造节点数目为 $n$ **真二叉树**，此时可以从节点数目序列为 $[(1,n-2),(3,n-5),\cdots,(n-2,1)]$ 的**真二叉树**中构成，按照所有可能的组合数进行枚举，即可构造成节点数目为 $n$ 的**真二叉树**。

##### 代码

```class Solution {
public:
    vector<TreeNode*> allPossibleFBT(int n) {
        if (n % 2 == 0) {
            return {};
        }
        
        vector<vector<TreeNode*>> dp(n + 1);
        dp[1] = {new TreeNode(0)};
        for (int i = 3; i <= n; i += 2) {
            for (int j = 1; j < i; j += 2) {
                for (TreeNode *leftSubtree : dp[j]) {
                    for (TreeNode *rightSubtrees : dp[i - 1 - j]) {
                        TreeNode *root = new TreeNode(0, leftSubtree, rightSubtrees);
                        dp[i].emplace_back(root);
                    }
                }
            }
        }        
        return dp[n];
    }
};
```

```java
class Solution {
    public List<TreeNode> allPossibleFBT(int n) {
        if (n % 2 == 0) {
            return new ArrayList<TreeNode>();
        }

        List<TreeNode>[] dp = new List[n + 1];
        for (int i = 0; i <= n; i++) {
            dp[i] = new ArrayList<TreeNode>();
        }
        dp[1].add(new TreeNode(0));
        for (int i = 3; i <= n; i += 2) {
            for (int j = 1; j < i; j += 2) {
                for (TreeNode leftSubtree : dp[j]) {
                    for (TreeNode rightSubtrees : dp[i - 1 - j]) {
                        TreeNode root = new TreeNode(0, leftSubtree, rightSubtrees);
                        dp[i].add(root);
                    }
                }
            }
        }        
        return dp[n];
    }
}
```

```csharp
public class Solution {
    public IList<TreeNode> AllPossibleFBT(int n) {
        if (n % 2 == 0) {
            return new List<TreeNode>();
        }

        IList<TreeNode>[] dp = new IList<TreeNode>[n + 1];
        for (int i = 0; i <= n; i++) {
            dp[i] = new List<TreeNode>();
        }
        dp[1].Add(new TreeNode(0));
        for (int i = 3; i <= n; i += 2) {
            for (int j = 1; j < i; j += 2) {
                foreach (TreeNode leftSubtree in dp[j]) {
                    foreach (TreeNode rightSubtrees in dp[i - 1 - j]) {
                        TreeNode root = new TreeNode(0, leftSubtree, rightSubtrees);
                        dp[i].Add(root);
                    }
                }
            }
        }        
        return dp[n];
    }
}
```

```c
typedef struct Node {
    struct TreeNode* val;
    struct Node *next;
} Node;

struct TreeNode* createTreeNode(int val, struct TreeNode* pLeft, struct TreeNode* pRight) {
    struct TreeNode* obj = (struct TreeNode*)malloc(sizeof(struct TreeNode));
    obj->val = val;
    obj->left = pLeft;
    obj->right = pRight;
    return obj;
}

Node *createNode(struct TreeNode* val) {
    Node *obj = (Node *)malloc(sizeof(Node));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

void freeList(Node *list) {
    while (list) {
        Node *p = list;
        list = list->next;
        free(p);
    }
}

struct TreeNode** allPossibleFBT(int n, int* returnSize) {
    if (n % 2 == 0) {
        *returnSize = 0;
        return NULL;
    }
    
    int count[n + 1];
    Node *dp[n + 1];
    for (int i = 0; i <= n; i++) {
        dp[i] = NULL;
        count[i] = 0;
    }
    count[1] = 1;
    dp[1] = createNode(createTreeNode(0, NULL, NULL));

    for (int i = 3; i <= n; i += 2) {
        for (int j = 1; j < i; j += 2) {
            for (Node* pLeft = dp[j]; pLeft != NULL; pLeft = pLeft->next) {
                struct TreeNode *leftSubtree = pLeft->val;
                for (Node* pRight = dp[i - j - 1]; pRight != NULL; pRight = pRight->next) {
                    struct TreeNode *rightSubtrees = pRight->val;
                    struct TreeNode *root = createTreeNode(0, leftSubtree, rightSubtrees);
                    Node* p = createNode(root);
                    p->next = dp[i];
                    dp[i] = p;
                    count[i]++;
                }
            }
        }
    }        

    *returnSize = count[n];
    struct TreeNode ** fullBinaryTrees = (struct TreeNode **)malloc(sizeof(struct TreeNode *) * count[n]);
    int pos = 0;
    for (Node *node = dp[n]; node != NULL; node = node->next) {
        fullBinaryTrees[pos++] = node->val;
    }
    for (int i = 0; i <= n; i++) {
        freeList(dp[i]);
    }
    return fullBinaryTrees;
}
```

```python
class Solution:
    def allPossibleFBT(self, n: int) -> List[Optional[TreeNode]]:
        if n % 2 == 0:
            return []
    
        dp = [[] for _ in range(n + 1)]
        dp[1] = [TreeNode(0)]
        for i in range(3, n + 1, 2):
            for j in range(1, i, 2):
                for leftSubtree in dp[j]:
                    for rightSubtree in dp[i - 1 - j]:
                        root = TreeNode(0, leftSubtree, rightSubtree)
                        dp[i].append(root)
        return dp[n]
```

```go
func allPossibleFBT(n int) []*TreeNode {
    if n%2 == 0 {
        return []*TreeNode{}
    }

    dp := make([][]*TreeNode, n + 1)
    dp[1] = []*TreeNode{&TreeNode{Val: 0}}
    for i := 3; i <= n; i += 2 {
        for j := 1; j < i; j += 2 {
            for _, leftSubtree := range dp[j] {
                for _, rightSubtree := range dp[i - 1 - j] {
                    root := &TreeNode{Val: 0, Left: leftSubtree, Right: rightSubtree}
                    dp[i] = append(dp[i], root)
                }
            }
        }
    }
    return dp[n]
}
```

```javascript
var allPossibleFBT = function(n) {
    if (n % 2 === 0) {
        return [];
    }
    
    const dp = Array(n + 1).fill().map(() => []);
    dp[1] = [new TreeNode(0)];
    for (let i = 3; i <= n; i += 2) {
        for (let j = 1; j < i; j += 2) {
            for (let leftSubtree of dp[j]) {
                for (let rightSubtree of dp[i - 1 - j]) {
                    const root = new TreeNode(0, leftSubtree, rightSubtree);
                    dp[i].push(root);
                }
            }
        }
    }
    return dp[n];
};
```

```rust
use std::rc::Rc;
use std::cell::RefCell;

impl Solution {
    pub fn all_possible_fbt(n: i32) -> Vec<Option<Rc<RefCell<TreeNode>>>> {
        if n % 2 == 0 {
            return vec![];
        }
        let mut dp: Vec<Vec<Option<Rc<RefCell<TreeNode>>>>> = vec![Vec::new(); (n + 1) as usize];
        dp[1].push(Some(Rc::new(RefCell::new(TreeNode::new(0)))));
        for i in (3..= n).step_by(2) {
            let mut full_binary_trees: Vec<Option<Rc<RefCell<TreeNode>>>> = Vec::new();
            for j in (1..i).step_by(2) {
                for left_subtree in &dp[j as usize] {
                    for right_subtree in &dp[(i - 1 - j) as usize] {
                        let mut root = Rc::new(RefCell::new(TreeNode { val: 0, left: left_subtree.clone(), right: right_subtree.clone()}));
                        full_binary_trees.push(Some(root.clone()));
                    }
                }
            }
            dp[i as usize] = full_binary_trees.clone();
        }
        dp[n as usize].clone()
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(\dfrac{2^n}{\sqrt{n}})$，其中 $n$ 是给定的**真二叉树**的结点数。只有当 $n$ 是奇数时才存在**真二叉树**，记 $2k+1$，由 $n$ 个结点组成的**真二叉树**的数量是第 $k$ 个卡特兰数 $\dfrac{C(2k, k)}{k + 1} k+1$，其渐进上界为 $O(\dfrac{4^k}{k \sqrt{k}}) = O(\dfrac{2^n}{n \sqrt{n}})$，对于每个**真二叉树**至少需要求 $\dfrac{n}{2}$ 次卡特兰数，因此时间复杂度是 $O(\dfrac{2^n}{\sqrt{n}})$。
- 空间复杂度：$O(1)$。返回值不计入空间复杂度。
