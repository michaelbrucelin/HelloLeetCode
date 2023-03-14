#### [������������](https://leetcode.cn/problems/construct-string-from-binary-tree/solutions/1343920/gen-ju-er-cha-shu-chuang-jian-zi-fu-chua-e1af/)

����Ҳ����ʹ�õ����ķ����õ���������ǰ����������ڵ���ʱ���϶�������š�

��һ��ջ���洢���е�һЩ�ڵ㣬����ջ����Ԫ��Ϊ��ǰ�������Ľڵ㣬��ջ�׵�ջ���Ľڵ�Ϊ�Ӹ�����ǰ�ڵ��Ψһ·���ϵĽڵ㡣�͵����õ�ǰ������ķ������в�ͬ������������Ҫ�����������ţ�������ǻ���Ҫ��һ�����ϴ洢���б������Ľڵ㣬���ɼ����ġ�

�������ǰѸ��ڵ���ջ�����ڵ�ǰջ����Ԫ�أ������û�б���������ô�Ͱ������뵽�����У�����ʼ������Ϊ������������ǰ��������������ڴ�ĩβ���һ�� `��(��`����ʾһ���ڵ�Ŀ�ʼ��Ȼ���жϸýڵ���ӽڵ������

�ͷ���һ��ͬ�������������������

-   �����ǰ�ڵ����������ӣ���ô�����Ƚ��Һ�����ջ���ٽ�������ջ���Ӷ���֤ǰ�������˳��
-   �����ǰ�ڵ�û�к��ӣ�����ʲô��������
-   �����ǰ�ڵ�ֻ�����ӣ���ô���ǽ�������ջ��
-   �����ǰ�ڵ�ֻ���Һ��ӣ���ô��Ҫ�ڴ�ĩβ���һ�� `��()��` ��ʾ�յ����ӣ��ٽ��Һ�����ջ��

ע������������У����Ƕ����Ὣ��ǰ�ڵ��ջ��ԭ��������һ��ʼ����� `��(��` ��ʾ�ڵ�Ŀ�ʼ�����Ե�ǰ�ڵ�Ϊ�������������нڵ�������֮�����ǲŻ��ڴ�ĩβ��� `��)��` ��ʾ�ڵ�Ľ��������������Ҫ�������ᵽ�ļ������洢�������Ľڵ㣬�����ǰջ����Ԫ�ر���������ô����Ҫ�ڴ�ĩβ��� `��)��` ����������ڵ��ջ��

![](./assets/img/Solution0606_3_01.png)
![](./assets/img/Solution0606_3_02.png)
![](./assets/img/Solution0606_3_03.png)
![](./assets/img/Solution0606_3_04.png)
![](./assets/img/Solution0606_3_05.png)
![](./assets/img/Solution0606_3_06.png)
![](./assets/img/Solution0606_3_07.png)
![](./assets/img/Solution0606_3_08.png)
![](./assets/img/Solution0606_3_09.png)
![](./assets/img/Solution0606_3_10.png)
![](./assets/img/Solution0606_3_11.png)
![](./assets/img/Solution0606_3_12.png)
![](./assets/img/Solution0606_3_13.png)

```python
class Solution:
    def tree2str(self, root: Optional[TreeNode]) -> str:
        ans = ""
        st = [root]
        vis = set()
        while st:
            node = st[-1]
            if node in vis:
                if node != root:
                    ans += ")"
                st.pop()
            else:
                vis.add(node)
                if node != root:
                    ans += "("
                ans += str(node.val)
                if node.left is None and node.right:
                    ans += "()"
                if node.right:
                    st.append(node.right)
                if node.left:
                    st.append(node.left)
        return ans
```

```cpp
class Solution {
public:
    string tree2str(TreeNode *root) {
        string ans = "";
        stack<TreeNode *> st;
        st.push(root);
        unordered_set<TreeNode *> vis;
        while (!st.empty()) {
            auto node = st.top();
            if (vis.count(node)) {
                if (node != root) {
                    ans += ")";
                }
                st.pop();
            } else {
                vis.insert(node);
                if (node != root) {
                    ans += "(";
                }
                ans += to_string(node->val);
                if (node->left == nullptr && node->right != nullptr) {
                    ans += "()";
                }
                if (node->right != nullptr) {
                    st.push(node->right);
                }
                if (node->left != nullptr) {
                    st.push(node->left);
                }
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public String tree2str(TreeNode root) {
        StringBuffer ans = new StringBuffer();
        Deque<TreeNode> stack = new ArrayDeque<TreeNode>();
        stack.push(root);
        Set<TreeNode> visited = new HashSet<TreeNode>();
        while (!stack.isEmpty()) {
            TreeNode node = stack.peek();
            if (!visited.add(node)) {
                if (node != root) {
                    ans.append(")");
                }
                stack.pop();
            } else {
                if (node != root) {
                    ans.append("(");
                }
                ans.append(node.val);
                if (node.left == null && node.right != null) {
                    ans.append("()");
                }
                if (node.right != null) {
                    stack.push(node.right);
                }
                if (node.left != null) {
                    stack.push(node.left);
                }
            }
        }
        return ans.toString();
    }
}
```

```csharp
public class Solution {
    public string Tree2str(TreeNode root) {
        StringBuilder ans = new StringBuilder();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        ISet<TreeNode> visited = new HashSet<TreeNode>();
        while (stack.Count > 0) {
            TreeNode node = stack.Peek();
            if (!visited.Add(node)) {
                if (node != root) {
                    ans.Append(")");
                }
                stack.Pop();
            } else {
                if (node != root) {
                    ans.Append("(");
                }
                ans.Append(node.val);
                if (node.left == null && node.right != null) {
                    ans.Append("()");
                }
                if (node.right != null) {
                    stack.Push(node.right);
                }
                if (node.left != null) {
                    stack.Push(node.left);
                }
            }
        }
        return ans.ToString();
    }
}
```

```go
func tree2str(root *TreeNode) string {
    ans := &strings.Builder{}
    st := []*TreeNode{root}
    vis := map[*TreeNode]bool{}
    for len(st) > 0 {
        node := st[len(st)-1]
        if vis[node] {
            if (node != root) {
                ans.WriteByte(')')
            }
            st = st[:len(st)-1]
        } else {
            vis[node] = true
            if (node != root) {
                ans.WriteByte('(')
            }
            ans.WriteString(strconv.Itoa(node.Val))
            if node.Left == nil && node.Right != nil {
                ans.WriteString("()")
            }
            if node.Right != nil {
                st = append(st, node.Right)
            }
            if node.Left != nil {
                st = append(st, node.Left)
            }
        }
    }
    return ans.String()
}
```

```c
#define MAX_STR_LEN 100000
#define MAX_NODE_SIZE 100000

typedef struct {
    struct TreeNode * key;
    UT_hash_handle hh; 
} HashItem;

char * tree2str(struct TreeNode* root){
    char * ans = (char *)malloc(sizeof(char) * MAX_STR_LEN);
    int pos = 0;
    struct TreeNode ** st = (struct TreeNode **)malloc(sizeof(struct TreeNode *) * MAX_NODE_SIZE);
    HashItem * vis = NULL;
    int top = 0;
    st[top++] = root;

    while (top > 0) {
        struct TreeNode * node = st[top - 1];
        HashItem * pEntry = NULL;
        HASH_FIND_PTR(vis, &node, pEntry);
        if (pEntry != NULL) {
            if (node != root) {
                ans[pos++] = ')';
            }
            top--;
        } else {
            pEntry = (HashItem *)malloc(sizeof(HashItem));
            pEntry->key = node;
            HASH_ADD_PTR(vis, key, pEntry);
            if (node != root) {
                ans[pos++] = '(';
            }
            pos += sprintf(ans + pos, "%d", node->val);
            if (node->left == NULL && node->right != NULL) {
                pos += sprintf(ans + pos, "()");
            }
            if (node->right != NULL) {
                st[top++] = node->right;
            }
            if (node->left != NULL) {
                st[top++] = node->left;
            }
        }        
    }
    ans[pos] = '\0';
    free(st);
    HashItem * curr, * next;
    HASH_ITER(hh, vis, curr, next) {
        HASH_DEL(vis, curr);  
        free(curr);            
    }
    return ans;
}
```

```javascript
var tree2str = function(root) {
    let ans = '';
    const st = [root];
    const vis = new Set();
    while (st.length) {
        const node = st[st.length - 1];
        if (vis.has(node)) {
            if (node !== root) {
                ans += ')';
            }
            st.pop();
        } else {
            vis.add(node);
            if (node !== root) {
                ans += '(';
            }
            ans += '' + node.val;
            if (!node.left && node.right) {
                ans += '()';
            }
            if (node.right) {
                st.push(node.right);
            }
            if (node.left) {
                st.push(node.left);
            }
        }
    }
    return ans;
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ �Ƕ������еĽڵ���Ŀ��
-   �ռ临�Ӷȣ�$O(n)$����ϣ���ջ��Ҫ $O(n)$ �Ŀռ䡣
