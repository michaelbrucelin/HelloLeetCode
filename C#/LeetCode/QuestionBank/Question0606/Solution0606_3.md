#### [����һ���ݹ�](https://leetcode.cn/problems/construct-string-from-binary-tree/solutions/1343920/gen-ju-er-cha-shu-chuang-jian-zi-fu-chua-e1af/)

���ǿ���ʹ�õݹ�ķ����õ���������ǰ����������ڵݹ�ʱ���϶�������š�

�������� $4$ �������

-   �����ǰ�ڵ����������ӣ��������ڵݹ�ʱ����Ҫ���������ӵĽ���ⶼ����һ�����ţ�
-   �����ǰ�ڵ�û�к��ӣ������ǲ���Ҫ�ڽڵ��������κ����ţ�

![](./assets/img/Solution0606_3_01.png)

-   �����ǰ�ڵ�ֻ�����ӣ��������ڵݹ�ʱ��ֻ��Ҫ�����ӵĽ�������һ�����ţ�������Ҫ���Һ��Ӽ����κ����ţ�

![](./assets/img/Solution0606_3_02.png)

-   �����ǰ�ڵ�ֻ���Һ��ӣ��������ڵݹ�ʱ����Ҫ�ȼ���һ��յ����� `��()��` ��ʾ����Ϊ�գ��ٶ��Һ��ӽ��еݹ飬���ڽ�������һ�����š�

![](./assets/img/Solution0606_3_03.png)

����������� $4$ ����������ǾͿ��Եõ����յ��ַ�����

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ �Ƕ������еĽڵ���Ŀ��
-   �ռ临�Ӷȣ�$O(n)$���������»�ݹ� $n$ �㣬��Ҫ $O(n)$ ��ջ�ռ䡣
