#### [方法四：迭代 + 中序遍历 + 双指针](https://leetcode.cn/problems/two-sum-iv-input-is-a-bst/solutions/1347526/liang-shu-zhi-he-iv-shu-ru-bst-by-leetco-b4nl/)

**思路和算法**

在方法三中，我们是在中序遍历得到的数组上进行双指针，这样需要消耗 $O(n)$ 的空间，实际上我们可以将双指针的移动理解为在树上的遍历过程的一次移动。因为递归方法较难控制移动过程，因此我们使用迭代的方式进行遍历。

具体地，我们对于每个指针新建一个栈。初始，我们让左指针移动到树的最左端点，并将路径保存在栈中，接下来我们可以依据栈来 $O(1)$ 地计算出左指针的下一个位置。右指针也是同理。

计算下一个位置时，我们首先将位于栈顶的当前节点从栈中弹出，此时首先判断当前节点是否存在右子节点，如果存在，那么我们将右子节点的最左子树加入到栈中；否则我们就完成了当前层的遍历，无需进一步修改栈的内容，直接回溯到上一层即可。

**代码**

```python
class Solution:
    def findTarget(self, root: Optional[TreeNode], k: int) -> bool:
        left, right = root, root
        leftStk, rightStk = [left], [right]
        while left.left:
            left = left.left
            leftStk.append(left)
        while right.right:
            right = right.right
            rightStk.append(right)
        while left != right:
            sum = left.val + right.val
            if sum == k:
                return True
            if sum < k:
                left = leftStk.pop()
                node = left.right
                while node:
                    leftStk.append(node)
                    node = node.left
            else:
                right = rightStk.pop()
                node = right.left
                while node:
                    rightStk.append(node)
                    node = node.right
        return False
```

```cpp
class Solution {
public:
    TreeNode *getLeft(stack<TreeNode *> &stk) {
        TreeNode *root = stk.top();
        stk.pop();
        TreeNode *node = root->right;
        while (node != nullptr) {
            stk.push(node);
            node = node->left;
        }
        return root;
    }

    TreeNode *getRight(stack<TreeNode *> &stk) {
        TreeNode *root = stk.top();
        stk.pop();
        TreeNode *node = root->left;
        while (node != nullptr) {
            stk.push(node);
            node = node->right;
        }
        return root;
    }

    bool findTarget(TreeNode *root, int k) {
        TreeNode *left = root, *right = root;
        stack<TreeNode *> leftStack, rightStack;
        leftStack.push(left);
        while (left->left != nullptr) {
            leftStack.push(left->left);
            left = left->left;
        }
        rightStack.push(right);
        while (right->right != nullptr) {
            rightStack.push(right->right);
            right = right->right;
        }
        while (left != right) {
            if (left->val + right->val == k) {
                return true;
            }
            if (left->val + right->val < k) {
                left = getLeft(leftStack);
            } else {
                right = getRight(rightStack);
            }
        }
        return false;
    }
};
```

```java
class Solution {
    public boolean findTarget(TreeNode root, int k) {
        TreeNode left = root, right = root;
        Deque<TreeNode> leftStack = new ArrayDeque<TreeNode>();
        Deque<TreeNode> rightStack = new ArrayDeque<TreeNode>();
        leftStack.push(left);
        while (left.left != null) {
            leftStack.push(left.left);
            left = left.left;
        }
        rightStack.push(right);
        while (right.right != null) {
            rightStack.push(right.right);
            right = right.right;
        }
        while (left != right) {
            if (left.val + right.val == k) {
                return true;
            }
            if (left.val + right.val < k) {
                left = getLeft(leftStack);
            } else {
                right = getRight(rightStack);
            }
        }
        return false;
    }

    public TreeNode getLeft(Deque<TreeNode> stack) {
        TreeNode root = stack.pop();
        TreeNode node = root.right;
        while (node != null) {
            stack.push(node);
            node = node.left;
        }
        return root;
    }

    public TreeNode getRight(Deque<TreeNode> stack) {
        TreeNode root = stack.pop();
        TreeNode node = root.left;
        while (node != null) {
            stack.push(node);
            node = node.right;
        }
        return root;
    }
}
```

```csharp
public class Solution {
    public bool FindTarget(TreeNode root, int k) {
        TreeNode left = root, right = root;
        Stack<TreeNode> leftStack = new Stack<TreeNode>();
        Stack<TreeNode> rightStack = new Stack<TreeNode>();
        leftStack.Push(left);
        while (left.left != null) {
            leftStack.Push(left.left);
            left = left.left;
        }
        rightStack.Push(right);
        while (right.right != null) {
            rightStack.Push(right.right);
            right = right.right;
        }
        while (left != right) {
            if (left.val + right.val == k) {
                return true;
            }
            if (left.val + right.val < k) {
                left = GetLeft(leftStack);
            } else {
                right = GetRight(rightStack);
            }
        }
        return false;
    }

    public TreeNode GetLeft(Stack<TreeNode> stack) {
        TreeNode root = stack.Pop();
        TreeNode node = root.right;
        while (node != null) {
            stack.Push(node);
            node = node.left;
        }
        return root;
    }

    public TreeNode GetRight(Stack<TreeNode> stack) {
        TreeNode root = stack.Pop();
        TreeNode node = root.left;
        while (node != null) {
            stack.Push(node);
            node = node.right;
        }
        return root;
    }
}
```

```c
#define MAX_NODE_SIZE 1e4 

typedef struct {
    struct TreeNode ** stBuf;
    int stTop;
    int stSize;
} Stack;

void init(Stack* obj, int stSize) {
    obj->stBuf = (struct TreeNode **)malloc(sizeof(struct TreeNode *) * stSize);
    obj->stTop = 0;
    obj->stSize = stSize;
}

bool isEmpty(const Stack* obj) {
    return obj->stTop == 0;
}

struct TreeNode * top(const Stack* obj) {
    return obj->stBuf[obj->stTop - 1];
}

bool push(Stack * obj, struct TreeNode* val) {
    if(obj->stTop == obj->stSize) {
        return false;
    }
    obj->stBuf[obj->stTop++] = val;
    return true;
}

void freeStack(Stack * obj) {
    free(obj->stBuf);
}

struct TreeNode * pop(Stack* obj) {
    if(obj->stTop == 0) {
        return NULL;
    }
    struct TreeNode *res = obj->stBuf[obj->stTop - 1];
    obj->stTop--;
    return res;
}

struct TreeNode *getLeft(Stack* stk) {
    struct TreeNode *root = pop(stk);
    struct TreeNode *node = root->right;
    while (node != NULL) {
        push(stk, node);
        node = node->left;
    }
    return root;
}

struct TreeNode *getRight(Stack* stk) {
    struct TreeNode *root = pop(stk);
    struct TreeNode *node = root->left;
    while (node != NULL) {
        push(stk, node);
        node = node->right;
    }
    return root;
}

bool findTarget(struct TreeNode* root, int k){
    struct TreeNode *left = root, *right = root;
    Stack leftStack, rightStack;
    init(&leftStack, MAX_NODE_SIZE);
    init(&rightStack, MAX_NODE_SIZE);
    push(&leftStack, left);
    while (left->left != NULL) {
        push(&leftStack, left->left);
        left = left->left;
    }
    push(&rightStack, right);
    while (right->right != NULL) {
        push(&rightStack, right->right);
        right = right->right;
    }
    while (left != right) {
        if (left->val + right->val == k) {
            freeStack(&leftStack);
            freeStack(&rightStack);
            return true;
        }
        if (left->val + right->val < k) {
            left = getLeft(&leftStack);
        } else {
            right = getRight(&rightStack);
        }
    }
    freeStack(&leftStack);
    freeStack(&rightStack);
    return false;
}
```

```javascript
var findTarget = function(root, k) {
    const getLeft = (stack) => {
        const root = stack.pop();
        let node = root.right;
        while (node) {
            stack.push(node);
            node = node.left;
        }
        return root;
    }

    const getRight = (stack) => {
        const root = stack.pop();
        let node = root.left;
        while (node) {
            stack.push(node);
            node = node.right;
        }
        return root;
    };

    let left = root, right = root;
    const leftStack = [];
    const rightStack = [];
    leftStack.push(left);
    while (left.left) {
        leftStack.push(left.left);
        left = left.left;
    }
    rightStack.push(right);
    while (right.right) {
        rightStack.push(right.right);
        right = right.right;
    }
    while (left !== right) {
        if (left.val + right.val === k) {
            return true;
        }
        if (left.val + right.val < k) {
            left = getLeft(leftStack);
        } else {
            right = getRight(rightStack);
        }
    }
    return false;
}
```

```go
func findTarget(root *TreeNode, k int) bool {
    left, right := root, root
    leftStk := []*TreeNode{left}
    for left.Left != nil {
        leftStk = append(leftStk, left.Left)
        left = left.Left
    }
    rightStk := []*TreeNode{right}
    for right.Right != nil {
        rightStk = append(rightStk, right.Right)
        right = right.Right
    }
    for left != right {
        sum := left.Val + right.Val
        if sum == k {
            return true
        }
        if sum < k {
            left = leftStk[len(leftStk)-1]
            leftStk = leftStk[:len(leftStk)-1]
            for node := left.Right; node != nil; node = node.Left {
                leftStk = append(leftStk, node)
            }
        } else {
            right = rightStk[len(rightStk)-1]
            rightStk = rightStk[:len(rightStk)-1]
            for node := right.Left; node != nil; node = node.Right {
                rightStk = append(rightStk, node)
            }
        }
    }
    return false
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 为二叉搜索树的大小。在双指针的过程中，我们实际上遍历了整棵树一次。
-   空间复杂度：$O(n)$，其中 $n$ 为二叉搜索树的大小。主要为栈的开销，最坏情况下二叉搜索树为一条链，需要 $O(n)$ 的栈空间。
