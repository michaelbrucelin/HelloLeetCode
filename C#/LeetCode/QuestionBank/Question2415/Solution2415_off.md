### [反转二叉树的奇数层](https://leetcode.cn/problems/reverse-odd-levels-of-binary-tree/solutions/2562073/fan-zhuan-er-cha-shu-de-qi-shu-ceng-by-l-n034/)

#### 方法一：广度优先搜索

##### 思路与算法

我们直接按照层次遍历该二叉树，然后将奇数层中的值进行反转。二叉树按照层次遍历是一个基本的广度优先搜索问题，可以参考[「树的层序遍历」](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgraph%2Ftree-basic%2F%23%E6%A0%91%E4%B8%8A-bfs)。在遍历的同时，对每一层进行标记，如果当前该层为奇数层，则将该层中的节点用数组保存起来，然后将该层所有节点的值进行反转即可。

##### 代码

```c++
class Solution {
public:
    TreeNode* reverseOddLevels(TreeNode* root) {
        queue<TreeNode *> qu;
        qu.emplace(root);
        bool isOdd = false;
        while (!qu.empty()) {
            int sz = qu.size();
            vector<TreeNode *> arr;
            for (int i = 0; i < sz; i++) {
                TreeNode *node = qu.front();
                qu.pop();
                if (isOdd) {
                    arr.emplace_back(node);
                }
                if (node->left) {
                    qu.emplace(node->left);
                    qu.emplace(node->right);
                }
            }
            if (isOdd) {
                for (int l = 0, r = sz - 1; l < r; l++, r--) {
                    swap(arr[l]->val, arr[r]->val);
                }
            }            
            isOdd ^= true;
        }
        return root;
    }
};
```

```java
class Solution {
    public TreeNode reverseOddLevels(TreeNode root) {
        Queue<TreeNode> queue = new ArrayDeque<TreeNode>();
        queue.offer(root);
        boolean isOdd = false;
        while (!queue.isEmpty()) {
            int sz = queue.size();
            List<TreeNode> arr = new ArrayList<TreeNode>();
            for (int i = 0; i < sz; i++) {
                TreeNode node = queue.poll();
                if (isOdd) {
                    arr.add(node);
                }
                if (node.left != null) {
                    queue.offer(node.left);
                    queue.offer(node.right);
                }
            }
            if (isOdd) {
                for (int l = 0, r = sz - 1; l < r; l++, r--) {
                    int temp = arr.get(l).val;
                    arr.get(l).val = arr.get(r).val;
                    arr.get(r).val = temp;
                }
            }            
            isOdd ^= true;
        }
        return root;
    }
}
```

```csharp
public class Solution {
    public TreeNode ReverseOddLevels(TreeNode root) {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        bool isOdd = false;
        while (queue.Count > 0) {
            int sz = queue.Count;
            IList<TreeNode> arr = new List<TreeNode>();
            for (int i = 0; i < sz; i++) {
                TreeNode node = queue.Dequeue();
                if (isOdd) {
                    arr.Add(node);
                }
                if (node.left != null) {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
            if (isOdd) {
                for (int l = 0, r = sz - 1; l < r; l++, r--) {
                    int temp = arr[l].val;
                    arr[l].val = arr[r].val;
                    arr[r].val = temp;
                }
            }            
            isOdd ^= true;
        }
        return root;
    }
}
```

```c
const int MAX_NODE_SIZE = 16384;

struct TreeNode* reverseOddLevels(struct TreeNode* root) {
    struct TreeNode* queue[MAX_NODE_SIZE];
    struct TreeNode* arr[MAX_NODE_SIZE];
    int arrSize = 0;
    int head = 0, tail = 0;
    bool isOdd = false;

    queue[tail++] = root;
    while (head != tail) {
        int sz = tail - head;
        int arrSize = 0;
        for (int i = 0; i < sz; i++) {
            struct TreeNode *node = queue[head++];
            if (isOdd) {
                arr[i] = node;
            }
            if (node->left) {
                queue[tail++] = node->left;
                queue[tail++] = node->right;
            }
        }
        if (isOdd) {
            for (int l = 0, r = sz - 1; l < r; l++, r--) {
                int tmp = arr[l]->val;
                arr[l]->val = arr[r]->val;
                arr[r]->val = tmp;
            }
        }            
        isOdd ^= true;
    }
    return root;
}
```

```python
class Solution:
    def reverseOddLevels(self, root: Optional[TreeNode]) -> Optional[TreeNode]:
        q = [root]
        isOdd = False
        while len(q) > 0:
            if isOdd:
                for i in range (len(q) // 2):
                    nodex, nodey = q[i], q[len(q) - 1 - i]
                    nodex.val, nodey.val = nodey.val, nodex.val
            tmp = q
            q = []
            for node in tmp:
                if node.left is not None:
                    q.append(node.left)
                    q.append(node.right)                           
            isOdd ^= True
        return root
```

```go
func reverseOddLevels(root *TreeNode) *TreeNode {
    q := []*TreeNode{root}
    isOdd := 0
    for len(q) > 0 {
        if isOdd != 0 {
            n := len(q)
            for i := 0; i < n / 2; i++ {
                nodex, nodey := q[i], q[n - 1 - i]
                nodex.Val, nodey.Val = nodey.Val, nodex.Val
            }  
        }
        tmp := make([]*TreeNode, 0, len(q) * 2)
        for _, node := range(q) {
            if node.Left != nil {
                tmp = append(tmp, node.Left, node.Right)
            }
        }
        q = tmp
        isOdd ^= 1
    }
    return root
}
```

```javascript
var reverseOddLevels = function(root) {
    let q = [root];
    let isOdd = false;
    while (q.length) {
        if (isOdd) {
            const n = q.length;
            for (let i = 0; i < n / 2; i++) {
                [q[i].val, q[n - 1 - i].val] = [q[n - 1 - i].val, q[i].val];
            }
        }
        const tmp = [...q];
        q = [];
        for (const node of tmp) {
            if (node.left) {
                q.push(node.left);
            }
            if (node.right) {
                q.push(node.right);
            }
        }
        isOdd ^= true;
    }
    return root;
};
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 表示树中节点的数目。利用广度优先搜索遍历二叉树的每一个节点，需要的时间为 $O(n)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示树中节点的数目。利用广度优先搜索遍历二叉树的每一层，每一层最多有 $\lceil \frac{n}{2} \rceil$ 个节点，队列中最多存在 $\lceil \frac{n}{2} \rceil$ 个节点，因此需要的空间为 $O(n)$。

#### 方法二：深度优先搜索

##### 思路与算法

同样的方法我们还可以使用深度优先搜索来遍历该二叉树，对奇数层进行反转。遍历过程如下：

- 由于该二叉树是**完美二叉树**，因此我们可以知道对于**根**节点来说，它的孩子节点为第一层节点，此时左孩子需要与右孩子需要进行反转；
- 当遍历每一层时，由于 $root_1,root_2$  分别指向该层两个可能需要进行值交换的节点。根据**完美二叉树**的层次反转规则，即左边排第一的元素与倒数第一元素进行交换，第二个元素与倒数二个元素交换，此时 $root_1$  的左孩子与 $root_2$  的右孩子可能需要进行交换，$root_1$  的右孩子与 $root_2$  的左孩子可能需要进行交换。在遍历的同时按照上述规则，将配对的节点进行递归传递到下一层；
- 我们用 $isOdd$ 来标记当前层次是否为奇数层，由于偶数层不需要进行交换，当 $isOdd$ 为 $true$ 时，表明当前需要交换，我们直接交换两个节点 $root_1,root_2$  的值；
- 由于**完美二叉树**来说，第 $i$ 的节点数目要么为 $2^i$ 个，要么为 $0$ 个，因此如果最左边的节点 $root_1$  为空时，则可以直接返回。

##### 代码

```c++
class Solution {
public:
    TreeNode* reverseOddLevels(TreeNode* root) {
        dfs(root->left, root->right, true);
        return root;
    }

    void dfs(TreeNode *root1, TreeNode *root2, bool isOdd) {
        if (root1 == nullptr) {
            return;
        }
        if (isOdd) {
            swap(root1->val, root2->val);
        }
        dfs(root1->left, root2->right, !isOdd);
        dfs(root1->right, root2->left, !isOdd);
    }
};
```

```java
class Solution {
    public TreeNode reverseOddLevels(TreeNode root) {
        dfs(root.left, root.right, true);
        return root;
    }

    public void dfs(TreeNode root1, TreeNode root2, boolean isOdd) {
        if (root1 == null) {
            return;
        }
        if (isOdd) {
            int temp = root1.val;
            root1.val = root2.val;
            root2.val = temp;
        }
        dfs(root1.left, root2.right, !isOdd);
        dfs(root1.right, root2.left, !isOdd);
    }
}
```

```csharp
public class Solution {
    public TreeNode ReverseOddLevels(TreeNode root) {
        DFS(root.left, root.right, true);
        return root;
    }

    public void DFS(TreeNode root1, TreeNode root2, bool isOdd) {
        if (root1 == null) {
            return;
        }
        if (isOdd) {
            int temp = root1.val;
            root1.val = root2.val;
            root2.val = temp;
        }
        DFS(root1.left, root2.right, !isOdd);
        DFS(root1.right, root2.left, !isOdd);
    }
}
```

```c
void dfs(struct TreeNode *root1, struct TreeNode *root2, bool isOdd) {
    if (!root1) {
        return;
    }
    if (isOdd) {
        int tmp = root1->val;
        root1->val = root2->val;
        root2->val = tmp;
    }
    dfs(root1->left, root2->right, !isOdd);
    dfs(root1->right, root2->left, !isOdd);
}

struct TreeNode* reverseOddLevels(struct TreeNode* root) {
    dfs(root->left, root->right, true);
    return root;
}
```

```python
class Solution:
    def reverseOddLevels(self, root: Optional[TreeNode]) -> Optional[TreeNode]:
        def dfs(root1: Optional[TreeNode], root2 : Optional[TreeNode], isOdd : bool) -> None:
            if root1 is None:
                return
            if isOdd:
                root1.val, root2.val = root2.val, root1.val
            dfs(root1.left, root2.right, not isOdd)
            dfs(root1.right, root2.left, not isOdd)
        dfs(root.left, root.right, True)
        return root
```

```go
func dfs(root1 *TreeNode, root2 *TreeNode, isOdd bool) {
    if root1 == nil {
        return
    }
    if isOdd {
        root1.Val, root2.Val = root2.Val, root1.Val
    }
    dfs(root1.Left, root2.Right, !isOdd)
    dfs(root1.Right, root2.Left, !isOdd)
}

func reverseOddLevels(root *TreeNode) *TreeNode {
    dfs(root.Left, root.Right, true)
    return root
}
```

```javascript
var reverseOddLevels = function(root) {
    const dfs = function(root1, root2, isOdd) {
        if (root1 == null) {
            return;
        }
        if (isOdd) {
            [root1.val, root2.val] = [root2.val, root1.val];
        }
        dfs(root1.left, root2.right, !isOdd);
        dfs(root1.right, root2.left, !isOdd);
    };
    dfs(root.left, root.right, true);
    return root;
};
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 表示树中节点的数目。利用深度优先搜索遍历二叉树的每一个节点，需要的时间为 $O(n)$。
- 空间复杂度：$O(\log n)$，其中 $n$ 表示树中节点的数目。利用深度优先搜索遍历整个二叉树，由于二叉树为完美二叉树，因此整个树的深度为 $\log n$，递归深度最大为 $\log n$，因此需要的空间为 $O(\log n)$。
