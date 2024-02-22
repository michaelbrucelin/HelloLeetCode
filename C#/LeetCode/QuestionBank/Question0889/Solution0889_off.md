### [根据前序和后序遍历构造二叉树](https://leetcode.cn/problems/construct-binary-tree-from-preorder-and-postorder-traversal/solutions/2645281/gen-ju-qian-xu-he-hou-xu-bian-li-gou-zao-6vzt/)

#### 方法一：分治

令 $n$ 为二叉树的节点数目，那么根据前序遍历与后序遍历的定义，$\textit{preorder}[0]$ 与 $\textit{postorder}[n - 1]$ 都对应二叉树的根节点。获取根节点后，我们需要划分根节点的左子树与右子树，考虑两种情况：

- 原二叉树的根节点的左子树不为空，那么 $\textit{preorder}[1]$ 对应左子树的根节点；
- 原二叉树的根节点的左子树为空，那么 $\textit{preorder}[1]$ 对应右子树的根节点。

对于以上两种情况，我们无法区分 $\textit{preorder}[1]$ 到底是哪种情况。但是对于第二种情况，将原二叉树的右子树移到左子树后得到的二叉树的前序遍历数组与后序遍历数组与原二叉树相同，所以我们只需要考虑第一种情况。因为二叉树的值互不相同，我们可以在 $\textit{postorder}$ 中找到 $\textit{postorder}[k] = \textit{preorder}[1]$，那么左子树的节点数目为 $k + 1$。基于此，我们可以对 $\textit{preorder}$ 和 $\textit{postorder}$ 进行分治处理，即将 $\textit{preorder}$ 划分为根节点、左子树节点和右子树节点三个部分，$\textit{postorder}$ 也划分为左子树节点、右子树节点和根节点三个部分。那么问题划分为：

- 根据左子树节点的前序遍历与后序遍历数组构造二叉树；
- 根据右子树节点的前序遍历与后序遍历数组构造二叉树。

同时当节点数目为 $1$ 时，对应构造的二叉树只有一个节点。我们可以递归地对问题进行求解，就可得到构造的二叉树。

```c++
class Solution {
public:
    TreeNode *constructFromPrePost(vector<int> &preorder, vector<int> &postorder) {
        int n = preorder.size();
        unordered_map<int, int> postMap;
        for (int i = 0; i < n; i++) {
            postMap[postorder[i]] = i;
        }
        function<TreeNode *(int, int, int, int)> dfs = [&](int preLeft, int preRight, int postLeft, int postRight) -> TreeNode * {
            if (preLeft > preRight) {
                return nullptr;
            }
            int leftCount = 0;
            if (preLeft < preRight) {
                leftCount = postMap[preorder[preLeft + 1]] - postLeft + 1;
            }
            return new TreeNode(preorder[preLeft],
                dfs(preLeft + 1, preLeft + leftCount, postLeft, postLeft + leftCount - 1),
                dfs(preLeft + leftCount + 1, preRight, postLeft + leftCount, postRight - 1));
        };
        return dfs(0, n - 1, 0, n - 1);
    }
};
```

```java
class Solution {
    public TreeNode constructFromPrePost(int[] preorder, int[] postorder) {
        int n = preorder.length;
        Map<Integer, Integer> postMap = new HashMap<Integer, Integer>();
        for (int i = 0; i < n; i++) {
            postMap.put(postorder[i], i);
        }
        return dfs(preorder, postorder, postMap, 0, n - 1, 0, n - 1);
    }

    public TreeNode dfs(int[] preorder, int[] postorder, Map<Integer, Integer> postMap, int preLeft, int preRight, int postLeft, int postRight) {
        if (preLeft > preRight) {
            return null;
        }
        int leftCount = 0;
        if (preLeft < preRight) {
            leftCount = postMap.get(preorder[preLeft + 1]) - postLeft + 1;
        }
        return new TreeNode(preorder[preLeft],
            dfs(preorder, postorder, postMap, preLeft + 1, preLeft + leftCount, postLeft, postLeft + leftCount - 1),
            dfs(preorder, postorder, postMap, preLeft + leftCount + 1, preRight, postLeft + leftCount, postRight - 1));
    }
}
```

```csharp
public class Solution {
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder) {
        int n = preorder.Length;
        IDictionary<int, int> postDictionary = new Dictionary<int, int>();
        for (int i = 0; i < n; i++) {
            postDictionary.Add(postorder[i], i);
        }
        return DFS(preorder, postorder, postDictionary, 0, n - 1, 0, n - 1);
    }

    public TreeNode DFS(int[] preorder, int[] postorder, IDictionary<int, int> postDictionary, int preLeft, int preRight, int postLeft, int postRight) {
        if (preLeft > preRight) {
            return null;
        }
        int leftCount = 0;
        if (preLeft < preRight) {
            leftCount = postDictionary[preorder[preLeft + 1]] - postLeft + 1;
        }
        return new TreeNode(preorder[preLeft],
            DFS(preorder, postorder, postDictionary, preLeft + 1, preLeft + leftCount, postLeft, postLeft + leftCount - 1),
            DFS(preorder, postorder, postDictionary, preLeft + leftCount + 1, preRight, postLeft + leftCount, postRight - 1));
    }
}
```

```go
func constructFromPrePost(preorder []int, postorder []int) *TreeNode {
    postMap := map[int]int{}
    for i, v := range postorder {
        postMap[v] = i
    }
    var dfs func(int, int, int, int) *TreeNode
    dfs = func (preLeft, preRight, postLeft, postRight int) *TreeNode {
        if preLeft > preRight {
            return nil
        }
        leftCount := 0
        if preLeft < preRight {
            leftCount = postMap[preorder[preLeft + 1]] - postLeft + 1
        }
        return &TreeNode{
            Val: preorder[preLeft],
            Left: dfs(preLeft + 1, preLeft + leftCount, postLeft, postLeft + leftCount - 1),
            Right: dfs(preLeft + leftCount + 1, preRight, postLeft + leftCount, postRight - 1),
        }
    }
    return dfs(0, len(preorder) - 1, 0, len(postorder) - 1)
}
```

```python
class Solution:
    def constructFromPrePost(self, preorder: List[int], postorder: List[int]) -> Optional[TreeNode]:
        postMap = {x: i for i, x in enumerate(postorder)}
        def dfs(preLeft, preRight, postLeft, postRight):
            if preLeft > preRight:
                return None
            leftCount = 0
            if preLeft < preRight:
                leftCount = postMap[preorder[preLeft + 1]] - postLeft + 1
            return TreeNode(preorder[preLeft],
                dfs(preLeft + 1, preLeft + leftCount, postLeft, postLeft + leftCount - 1),
                dfs(preLeft + leftCount + 1, preRight, postLeft + leftCount, postRight - 1))
        
        return dfs(0, len(preorder) - 1, 0, len(postorder) - 1)
```

```c
typedef struct {
    int key;
    int val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

int hashGetItem(HashItem **obj, int key, int defaultVal) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

struct TreeNode *createTreeNode(int val, struct TreeNode *left, struct TreeNode *right) {
    struct TreeNode *obj = (struct TreeNode *)malloc(sizeof(struct TreeNode));
    obj->val = val;
    obj->left = left;
    obj->right = right;
    return obj;
}

struct TreeNode* dfs(int preLeft, int preRight, int postLeft, int postRight, int* preorder, HashItem *postMap) {
    if (preLeft > preRight) {
        return NULL;
    }
    int leftCount = 0;
    if (preLeft < preRight) {
        leftCount = hashGetItem(&postMap, preorder[preLeft + 1], 0) - postLeft + 1;
    }
    return createTreeNode(preorder[preLeft], \
        dfs(preLeft + 1, preLeft + leftCount, postLeft, postLeft + leftCount - 1, preorder, postMap), \
        dfs(preLeft + leftCount + 1, preRight, postLeft + leftCount, postRight - 1, preorder, postMap));
}

struct TreeNode* constructFromPrePost(int* preorder, int preorderSize, int* postorder, int postorderSize) {
    int n = postorderSize;
    HashItem *postMap = NULL;
    for (int i = 0; i < n; i++) {
        hashAddItem(&postMap, postorder[i], i);
    }
    struct TreeNode* root = dfs(0, n - 1, 0, n - 1, preorder, postMap);
    hashFree(&postMap);
    return root;
}
```

```javascript
var constructFromPrePost = function(preorder, postorder) {
    const postMap = {};
    for (let i = 0; i < postorder.length; i++) {
        postMap[postorder[i]] = i;
    }

    const dfs = (preLeft, preRight, postLeft, postRight) => {
        if (preLeft > preRight) {
            return null;
        }

        let leftCount = 0;
        if (preLeft < preRight) {
            leftCount = postMap[preorder[preLeft + 1]] - postLeft + 1;
        }

        return new TreeNode(
            preorder[preLeft],
            dfs(preLeft + 1, preLeft + leftCount, postLeft, postLeft + leftCount - 1),
            dfs(preLeft + leftCount + 1, preRight, postLeft + leftCount, postRight - 1)
        );
    };

    return dfs(0, preorder.length - 1, 0, postorder.length - 1);
};
```

```typescript
function constructFromPrePost(preorder: number[], postorder: number[]): TreeNode | null {
    const postMap: { [key: number]: number } = {};
    for (let i = 0; i < postorder.length; i++) {
        postMap[postorder[i]] = i;
    }

    const dfs = (preLeft: number, preRight: number, postLeft: number, postRight: number): TreeNode | null => {
        if (preLeft > preRight) {
            return null;
        }

        let leftCount = 0;
        if (preLeft < preRight) {
            leftCount = postMap[preorder[preLeft + 1]] - postLeft + 1;
        }

        return new TreeNode(
            preorder[preLeft],
            dfs(preLeft + 1, preLeft + leftCount, postLeft, postLeft + leftCount - 1),
            dfs(preLeft + leftCount + 1, preRight, postLeft + leftCount, postRight - 1)
        );
    };

    return dfs(0, preorder.length - 1, 0, postorder.length - 1);
};
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是二叉树的节点数目。深度优先搜索的时间复杂度为 $O(n)$。
- 空间复杂度：$O(n)$。保存哈希表 $\textit{postMap}$ 需要 $O(n)$ 的空间，深度优先搜索需要的栈空间也为 $O(n)$。
