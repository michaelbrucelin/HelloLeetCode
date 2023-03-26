#### [方法一：深度优先搜索 + 哈希表](https://leetcode.cn/problems/two-sum-iv-input-is-a-bst/solutions/1347526/liang-shu-zhi-he-iv-shu-ru-bst-by-leetco-b4nl/)

**思路和算法**

我们可以使用深度优先搜索的方式遍历整棵树，用哈希表记录遍历过的节点的值。

对于一个值为 $x$ 的节点，我们检查哈希表中是否存在 $k - x$ 即可。如果存在对应的元素，那么我们就可以在该树上找到两个节点的和为 $k$；否则，我们将 $x$ 放入到哈希表中。

如果遍历完整棵树都不存在对应的元素，那么该树上不存在两个和为 $k$ 的节点。

**代码**

```python
class Solution:
    def __init__(self):
        self.s = set()

    def findTarget(self, root: Optional[TreeNode], k: int) -> bool:
        if root is None:
            return False
        if k - root.val in self.s:
            return True
        self.s.add(root.val)
        return self.findTarget(root.left, k) or self.findTarget(root.right, k)
```

```cpp
class Solution {
public:
    unordered_set<int> hashTable;

    bool findTarget(TreeNode *root, int k) {
        if (root == nullptr) {
            return false;
        }
        if (hashTable.count(k - root->val)) {
            return true;
        }
        hashTable.insert(root->val);
        return findTarget(root->left, k) || findTarget(root->right, k);
    }
};
```

```java
class Solution {
    Set<Integer> set = new HashSet<Integer>();

    public boolean findTarget(TreeNode root, int k) {
        if (root == null) {
            return false;
        }
        if (set.contains(k - root.val)) {
            return true;
        }
        set.add(root.val);
        return findTarget(root.left, k) || findTarget(root.right, k);
    }
}
```

```csharp
public class Solution {
    ISet<int> set = new HashSet<int>();

    public bool FindTarget(TreeNode root, int k) {
        if (root == null) {
            return false;
        }
        if (set.Contains(k - root.val)) {
            return true;
        }
        set.Add(root.val);
        return FindTarget(root.left, k) || FindTarget(root.right, k);
    }
}
```

```c
typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem;

bool helper(const struct TreeNode* root, int k, HashItem ** hashTable) {
    if (root == NULL) {
        return false;
    }
    int key = k - root->val;
    HashItem * pEntry = NULL;
    HASH_FIND_INT(*hashTable, &key, pEntry);
    if (pEntry != NULL) {
        return true;
    }
    pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = root->val;
    HASH_ADD_INT(*hashTable, key, pEntry);
    return helper(root->left, k, hashTable) || helper(root->right, k, hashTable);
}

bool findTarget(struct TreeNode* root, int k){
    HashItem * hashTable = NULL;
    return helper(root, k, &hashTable);
}
```

```javascript
var findTarget = function(root, k) {
    const set = new Set();
    const helper = (root, k) => {
        if (!root) {
            return false;
        }
        if (set.has(k - root.val)) {
            return true;
        }
        set.add(root.val);
        return helper(root.left, k) || helper(root.right, k);
    }
    return helper(root, k);
};
```

```go
func findTarget(root *TreeNode, k int) bool {
    set := map[int]struct{}{}
    var dfs func(*TreeNode) bool
    dfs = func(node *TreeNode) bool {
        if node == nil {
            return false
        }
        if _, ok := set[k-node.Val]; ok {
            return true
        }
        set[node.Val] = struct{}{}
        return dfs(node.Left) || dfs(node.Right)
    }
    return dfs(root)
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 为二叉搜索树的大小。我们需要遍历整棵树一次。
-   空间复杂度：$O(n)$，其中 $n$ 为二叉搜索树的大小。主要为哈希表的开销，最坏情况下我们需要将每个节点加入哈希表一次。
