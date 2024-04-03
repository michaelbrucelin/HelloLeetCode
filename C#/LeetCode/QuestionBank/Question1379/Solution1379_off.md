### [找出克隆二叉树中的相同节点](https://leetcode.cn/problems/find-a-corresponding-node-of-a-binary-tree-in-a-clone-of-that-tree/solutions/2720175/zhao-chu-ke-long-er-cha-shu-zhong-de-xia-vx4v/)

#### 方法一：深度优先搜索

同时对二叉树 $\textit{original}$ 与 $\textit{cloned}$ 进行深度优先搜索，如果 $\textit{original}$ 当前搜索的节点的引用等于 $\textit{target}$ 节点的引用，那么对应地返回 $\textit{cloned}$ 当前搜索的节点，否则继续对各自的左右节点同时进行搜索。

##### 代码

```c++
class Solution {
public:
    TreeNode *getTargetCopy(TreeNode *original, TreeNode *cloned, TreeNode *target) {
        if (original == nullptr) {
            return nullptr;
        }
        if (original == target) {
            return cloned;
        }
        TreeNode *left = getTargetCopy(original->left, cloned->left, target);
        if (left != nullptr) {
            return left;
        }
        return getTargetCopy(original->right, cloned->right, target);
    }
};
```

```java
class Solution {
    public final TreeNode getTargetCopy(final TreeNode original, final TreeNode cloned, final TreeNode target) {
        if (original == null) {
            return null;
        }
        if (original == target) {
            return cloned;
        }
        TreeNode left = getTargetCopy(original.left, cloned.left, target);
        if (left != null) {
            return left;
        }
        return getTargetCopy(original.right, cloned.right, target);
    }
}
```

```csharp
public class Solution {
    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target) {
        if (original == null) {
            return null;
        }
        if (cloned == target) {
            return cloned;
        }
        TreeNode left = GetTargetCopy(original.left, cloned.left, target);
        if (left != null) {
            return left;
        }
        return GetTargetCopy(original.right, cloned.right, target);
    }
}
```

```python
class Solution:
    def getTargetCopy(self, original: TreeNode, cloned: TreeNode, target: TreeNode) -> TreeNode:
        if original is None:
            return None
        if original == target:
            return cloned
        left = self.getTargetCopy(original.left, cloned.left, target)
        if left is not None:
            return left
        return self.getTargetCopy(original.right, cloned.right, target)
```

```javascript
var getTargetCopy = function(original, cloned, target) {
    if (original == null) {
        return null;
    }
    if (original == target) {
        return cloned;
    }
    const left = getTargetCopy(original.left, cloned.left, target);
    if (left != null) {
        return left;
    }
    return getTargetCopy(original.right, cloned.right, target);
};
```

```typescript
function getTargetCopy(original: TreeNode | null, cloned: TreeNode | null, target: TreeNode | null): TreeNode | null {
    if (original == null) {
        return null;
    }
    if (original == target) {
        return cloned;
    }
    const left = getTargetCopy(original.left, cloned.left, target);
    if (left != null) {
        return left;
    }
    return getTargetCopy(original.right, cloned.right, target);
};
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是二叉树的节点数目。
- 空间复杂度：$O(n)$。递归栈需要 $O(n)$ 的空间。

#### 方法二：广度优先搜索

使用队列同时对二叉树 $\textit{original}$ 和 $\textit{cloned}$ 进行广度优先搜索，初始时分别将根节点 $\textit{original}$ 和 $\textit{cloned}$ 压入队列 $q_1$ 和 $q_2$。假设当前搜索的节点分别为 $\textit{node}_1$ 与 $\textit{node}_2$，将 $\textit{node}_1$ 与 $\textit{node}_2$ 分别弹出队列，如果 $\textit{node}_1$ 节点的引用等于 $\textit{target}$ 节点的引用，那么返回 $\textit{node}_2$，否则将分别将 $\textit{node}_1$ 和 $\textit{node}_2$ 的非空子节点压入队列 $q_1$ 和 $q_2$，继续搜索过程。

##### 代码

```c++
class Solution {
public:
    TreeNode *getTargetCopy(TreeNode *original, TreeNode *cloned, TreeNode *target) {
        queue<TreeNode *> q1, q2;
        q1.push(original);
        q2.push(cloned);
        while (!q1.empty()) {
            TreeNode *node1 = q1.front(), *node2 = q2.front();
            q1.pop();
            q2.pop();
            if (node1 == target) {
                return node2;
            }
            if (node1->left != nullptr) {
                q1.push(node1->left);
                q2.push(node2->left);
            }
            if (node1->right != nullptr) {
                q1.push(node1->right);
                q2.push(node2->right);
            }
        }
        return nullptr; // impossible case
    }
};
```

```java
class Solution {
    public final TreeNode getTargetCopy(final TreeNode original, final TreeNode cloned, final TreeNode target) {
        Queue<TreeNode> q1 = new ArrayDeque<TreeNode>(), q2 = new ArrayDeque<TreeNode>();
        q1.offer(original);
        q2.offer(cloned);
        while (q1.size() > 0) {
            TreeNode node1 = q1.poll(), node2 = q2.poll();
            if (node1 == target) {
                return node2;
            }
            if (node1.left != null) {
                q1.offer(node1.left);
                q2.offer(node2.left);
            }
            if (node1.right != null) {
                q1.offer(node1.right);
                q2.offer(node2.right);
            }
        }
        return null; // impossible case
    }
}
```

```csharp
public class Solution {
    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target) {
        Queue<TreeNode> q1 = new Queue<TreeNode>(), q2 = new Queue<TreeNode>();
        q1.Enqueue(original);
        q2.Enqueue(cloned);
        while (q1.Count > 0) {
            TreeNode node1 = q1.Dequeue(), node2 = q2.Dequeue();
            if (node1 == target) {
                return node2;
            }
            if (node1.left != null) {
                q1.Enqueue(node1.left);
                q2.Enqueue(node2.left);
            }
            if (node1.right != null) {
                q1.Enqueue(node1.right);
                q2.Enqueue(node2.right);
            }
        }
        return null; // impossible case
    }
}
```

```python
class Solution:
    def getTargetCopy(self, original: TreeNode, cloned: TreeNode, target: TreeNode) -> TreeNode:
        q1, q2 = [original], [cloned]
        while len(q1) > 0:
            node1, node2 = q1[0], q2[0]
            q1, q2 = q1[1:], q2[1:]
            if node1 == target:
                return node2
            if node1.left is not None:
                q1.append(node1.left)
                q2.append(node2.left)
            if node1.right is not None:
                q1.append(node1.right)
                q2.append(node2.right)
        return None # impossible case
```

```javascript
var getTargetCopy = function(original, cloned, target) {
    const q1 = [original];
    const q2 = [cloned];
    while (q1.length > 0) {
        const node1 = q1[0], node2 = q2[0];
        q1.shift();
        q2.shift();
        if (node1 == target) {
            return node2;
        }
        if (node1.left != null) {
            q1.push(node1.left);
            q2.push(node2.left);
        }
        if (node1.right != null) {
            q1.push(node1.right);
            q2.push(node2.right);
        }
    }
    return null; // impossible case
};
```

```typescript
function getTargetCopy(original: TreeNode | null, cloned: TreeNode | null, target: TreeNode | null): TreeNode | null {
    const q1 = [original];
    const q2 = [cloned];
    while (q1.length > 0) {
        const node1 = q1[0], node2 = q2[0];
        q1.shift();
        q2.shift();
        if (node1 == target) {
            return node2;
        }
        if (node1.left != null) {
            q1.push(node1.left);
            q2.push(node2.left);
        }
        if (node1.right != null) {
            q1.push(node1.right);
            q2.push(node2.right);
        }
    }
    return null; // impossible case
};
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是二叉树的节点数目。
- 空间复杂度：$O(n)$。队列需要 $O(n)$ 的空间。
