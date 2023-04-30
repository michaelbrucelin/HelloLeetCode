#### [方法一：递归](https://leetcode.cn/problems/construct-string-from-binary-tree/solutions/1343920/gen-ju-er-cha-shu-chuang-jian-zi-fu-chua-e1af/)

我们可以使用递归的方法得到二叉树的前序遍历，并在递归时加上额外的括号。

会有以下 $4$ 种情况：

-   如果当前节点有两个孩子，那我们在递归时，需要在两个孩子的结果外都加上一层括号；
-   如果当前节点没有孩子，那我们不需要在节点后面加上任何括号；

![](./assets/img/Solution0606_3_01.png)

-   如果当前节点只有左孩子，那我们在递归时，只需要在左孩子的结果外加上一层括号，而不需要给右孩子加上任何括号；

![](./assets/img/Solution0606_3_02.png)

-   如果当前节点只有右孩子，那我们在递归时，需要先加上一层空的括号 `‘()’` 表示左孩子为空，再对右孩子进行递归，并在结果外加上一层括号。

![](./assets/img/Solution0606_3_03.png)

考虑完上面的 $4$ 种情况，我们就可以得到最终的字符串。

```python
class Solution:
    def tree2str(self, root: Optional[TreeNode]) -> str:
        if root is None:
            return ""
        if root.left is None and root.right is None:
            return str(root.val)
        if root.right is None:
            return f"{root.val}({self.tree2str(root.left)})"
        return f"{root.val}({self.tree2str(root.left)})({self.tree2str(root.right)})"
```

```cpp
class Solution {
public:
    string tree2str(TreeNode *root) {
        if (root == nullptr) {
            return "";
        }
        if (root->left == nullptr && root->right == nullptr) {
            return to_string(root->val);
        }
        if (root->right == nullptr) {
            return to_string(root->val) + "(" + tree2str(root->left) + ")";
        }
        return to_string(root->val) + "(" + tree2str(root->left) + ")(" + tree2str(root->right) + ")";
    }
};
```

```java
class Solution {
    public String tree2str(TreeNode root) {
        if (root == null) {
            return "";
        }
        if (root.left == null && root.right == null) {
            return Integer.toString(root.val);
        }
        if (root.right == null) {
            return new StringBuffer().append(root.val).append("(").append(tree2str(root.left)).append(")").toString();
        }
        return new StringBuffer().append(root.val).append("(").append(tree2str(root.left)).append(")(").append(tree2str(root.right)).append(")").toString();
    }
}
```

```csharp
public class Solution {
    public string Tree2str(TreeNode root) {
        if (root == null) {
            return "";
        }
        if (root.left == null && root.right == null) {
            return root.val.ToString();
        }
        if (root.right == null) {
            return new StringBuilder().Append(root.val).Append("(").Append(Tree2str(root.left)).Append(")").ToString();
        }
        return new StringBuilder().Append(root.val).Append("(").Append(Tree2str(root.left)).Append(")(").Append(Tree2str(root.right)).Append(")").ToString();
    }
}
```

```go
func tree2str(root *TreeNode) string {
    switch {
    case root == nil:
        return ""
    case root.Left == nil && root.Right == nil:
        return strconv.Itoa(root.Val)
    case root.Right == nil:
        return fmt.Sprintf("%d(%s)", root.Val, tree2str(root.Left))
    default:
        return fmt.Sprintf("%d(%s)(%s)", root.Val, tree2str(root.Left), tree2str(root.Right))
    }
}
```

```c
#define MAX_STR_LEN 100000

void helper(struct TreeNode* root, char * str, int * pos) {
    if (root == NULL) {
        return;
    }
    if (root->left == NULL && root->right == NULL) {
        *pos += sprintf(str + *pos, "%d", root->val);
        return;
    }
    if (root->right == NULL) {
        *pos += sprintf(str + *pos, "%d", root->val);
        str[(*pos)++] = '(';
        helper(root->left, str, pos);
        str[(*pos)++] = ')';
    } else {
        *pos += sprintf(str + *pos, "%d", root->val);
        str[(*pos)++] = '(';
        helper(root->left, str, pos);
        str[(*pos)++] = ')';
        str[(*pos)++] = '(';
        helper(root->right, str, pos);
        str[(*pos)++] = ')';
    } 
}

char * tree2str(struct TreeNode* root) {
    char * res = (char *)malloc(sizeof(char) * MAX_STR_LEN);
    int pos = 0;
    helper(root, res, &pos);
    res[pos] = '\0';
    return res;
}
```

```javascript
var tree2str = function(root) {
    if (!root) {
        return "";
    }
    if (!root.left && !root.right) {
        return '' + root.val;
    }
    if (!root.right) {
        return root.val + '(' + tree2str(root.left) + ')';
    }
    return root.val + '(' + tree2str(root.left) + ')(' + tree2str(root.right) + ')';
};
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是二叉树中的节点数目。
-   空间复杂度：$O(n)$。在最坏情况下会递归 $n$ 层，需要 $O(n)$ 的栈空间。
