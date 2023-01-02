#### [方法一：深度优先搜索](https://leetcode.cn/problems/binary-tree-paths/solutions/400326/er-cha-shu-de-suo-you-lu-jing-by-leetcode-solution/)

**思路与算法**

最直观的方法是使用深度优先搜索。在深度优先搜索遍历二叉树时，我们需要考虑当前的节点以及它的孩子节点。
-   如果当前节点**不是叶子节点**，则在当前的路径末尾添加该节点，并继续递归遍历该节点的每一个孩子节点。
-   如果当前节点**是叶子节点**，则在当前路径末尾添加该节点后我们就得到了一条从根节点到叶子节点的路径，将该路径加入到答案即可。

如此，当遍历完整棵二叉树以后我们就得到了所有从根节点到叶子节点的路径。当然，深度优先搜索也可以使用非递归的方式实现，这里不再赘述。

**代码**

```cpp
class Solution {
public:
    void construct_paths(TreeNode* root, string path, vector<string>& paths) {
        if (root != nullptr) {
            path += to_string(root->val);
            if (root->left == nullptr && root->right == nullptr) {  // 当前节点是叶子节点
                paths.push_back(path);                              // 把路径加入到答案中
            } else {
                path += "->";  // 当前节点不是叶子节点，继续递归遍历
                construct_paths(root->left, path, paths);
                construct_paths(root->right, path, paths);
            }
        }
    }

    vector<string> binaryTreePaths(TreeNode* root) {
        vector<string> paths;
        construct_paths(root, "", paths);
        return paths;
    }
};
```

```javascript
var binaryTreePaths = function(root) {
    const paths = [];
    const construct_paths = (root, path) => {
        if (root) {
            path += root.val.toString();
            if (root.left === null && root.right === null) { // 当前节点是叶子节点
                paths.push(path); // 把路径加入到答案中
            } else {
                path += "->"; // 当前节点不是叶子节点，继续递归遍历
                construct_paths(root.left, path);
                construct_paths(root.right, path);
            }
        }
    }
    construct_paths(root, "");
    return paths;
};
```

```java
class Solution {
    public List<String> binaryTreePaths(TreeNode root) {
        List<String> paths = new ArrayList<String>();
        constructPaths(root, "", paths);
        return paths;
    }

    public void constructPaths(TreeNode root, String path, List<String> paths) {
        if (root != null) {
            StringBuffer pathSB = new StringBuffer(path);
            pathSB.append(Integer.toString(root.val));
            if (root.left == null && root.right == null) {  // 当前节点是叶子节点
                paths.add(pathSB.toString());  // 把路径加入到答案中
            } else {
                pathSB.append("->");  // 当前节点不是叶子节点，继续递归遍历
                constructPaths(root.left, pathSB.toString(), paths);
                constructPaths(root.right, pathSB.toString(), paths);
            }
        }
    }
}
```

```python
class Solution:
    def binaryTreePaths(self, root):
        """
        :type root: TreeNode
        :rtype: List[str]
        """
        def construct_paths(root, path):
            if root:
                path += str(root.val)
                if not root.left and not root.right:  # 当前节点是叶子节点
                    paths.append(path)  # 把路径加入到答案中
                else:
                    path += '->'  # 当前节点不是叶子节点，继续递归遍历
                    construct_paths(root.left, path)
                    construct_paths(root.right, path)

        paths = []
        construct_paths(root, '')
        return paths
```

```go
var paths []string

func binaryTreePaths(root *TreeNode) []string {
    paths = []string{}
    constructPaths(root, "")
    return paths
}

func constructPaths(root *TreeNode, path string) {
    if root != nil {
        pathSB := path
        pathSB += strconv.Itoa(root.Val)
        if root.Left == nil && root.Right == nil {
            paths = append(paths, pathSB)
        } else {
            pathSB += "->"
            constructPaths(root.Left, pathSB)
            constructPaths(root.Right, pathSB)
        }
    }
}
```

```c
void construct_paths(struct TreeNode* root, char** paths, int* returnSize, int* sta, int top) {
    if (root != NULL) {
        if (root->left == NULL && root->right == NULL) {  // 当前节点是叶子节点
            char* tmp = (char*)malloc(1001);
            int len = 0;
            for (int i = 0; i < top; i++) {
                len += sprintf(tmp + len, "%d->", sta[i]);
            }
            sprintf(tmp + len, "%d", root->val);
            paths[(*returnSize)++] = tmp;  // 把路径加入到答案中
        } else {
            sta[top++] = root->val;  // 当前节点不是叶子节点，继续递归遍历
            construct_paths(root->left, paths, returnSize, sta, top);
            construct_paths(root->right, paths, returnSize, sta, top);
        }
    }
}

char** binaryTreePaths(struct TreeNode* root, int* returnSize) {
    char** paths = (char**)malloc(sizeof(char*) * 1001);
    *returnSize = 0;
    int sta[1001];
    construct_paths(root, paths, returnSize, sta, 0);
    return paths;
}
```

**复杂度分析**

-   时间复杂度：$O(N^2)$，其中 $N$ 表示节点数目。在深度优先搜索中每个节点会被访问一次且只会被访问一次，每一次会对 `path` 变量进行拷贝构造，时间代价为 $O(N)$，故时间复杂度为 $O(N^2)$。
-   空间复杂度：$O(N^2)$，其中 $N$ 表示节点数目。除答案数组外我们需要考虑递归调用的栈空间。在最坏情况下，当二叉树中每个节点只有一个孩子节点时，即整棵二叉树呈一个链状，此时递归的层数为 $N$，此时每一层的 `path` 变量的空间代价的总和为 $O(\sum_{i = 1}^{N} i) = O(N^2)$ 空间复杂度为 $O(N^2)$。最好情况下，当二叉树为平衡二叉树时，它的高度为 $\log N$，此时空间复杂度为 $O((\log {N})^2)$。
