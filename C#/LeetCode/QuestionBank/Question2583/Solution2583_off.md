### [二叉树中的第 K 大层和](https://leetcode.cn/problems/kth-largest-sum-in-a-binary-tree/solutions/2645278/er-cha-shu-zhong-de-di-k-da-ceng-he-by-l-948i/)

#### 方法一：广度优先搜索 + 排序

##### 思路

先使用广度优先搜索计算出树的每一层的节点值的和，保存在数组 $\textit{levelSumArray}$ 中。然后将数组进行排序，返回第 $k$ 大的值。需要考虑数组长度小于 $k$ 的边界情况。也可以使用快速选择的算法快速定位第 $k$ 大的元素。

##### 代码

```python
class Solution:
    def kthLargestLevelSum(self, root: Optional[TreeNode], k: int) -> int:
        q = [root]
        levelSumArray = []
        while q:
            levelNodes = q
            levelSum = 0
            q = []
            for node in levelNodes:
                levelSum += node.val
                if node.left: 
                    q.append(node.left)
                if node.right: 
                    q.append(node.right)
            levelSumArray.append(levelSum)
        if len(levelSumArray) < k:
            return -1
        levelSumArray.sort()
        return levelSumArray[-k]
```

```java
class Solution {
    public long kthLargestLevelSum(TreeNode root, int k) {
        Queue<TreeNode> queue = new ArrayDeque<TreeNode>();
        queue.offer(root);
        List<Long> levelSumArray = new ArrayList<Long>();
        while (!queue.isEmpty()) {
            List<TreeNode> levelNodes = new ArrayList<TreeNode>(queue);
            long levelSum = 0;
            queue.clear();
            for (TreeNode node : levelNodes) {
                levelSum += node.val;
                if (node.left != null) {
                    queue.offer(node.left);
                }
                if (node.right != null) {
                    queue.offer(node.right);
                }
            }
            levelSumArray.add(levelSum);
        }
        if (levelSumArray.size() < k) {
            return -1;
        }
        Collections.sort(levelSumArray);
        return levelSumArray.get(levelSumArray.size() - k);
    }
}
```

```csharp
public class Solution {
    public long KthLargestLevelSum(TreeNode root, int k) {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        IList<long> levelSumArray = new List<long>();
        while (queue.Count > 0) {
            IList<TreeNode> levelNodes = new List<TreeNode>(queue);
            long levelSum = 0;
            queue.Clear();
            foreach (TreeNode node in levelNodes) {
                levelSum += node.val;
                if (node.left != null) {
                    queue.Enqueue(node.left);
                }
                if (node.right != null) {
                    queue.Enqueue(node.right);
                }
            }
            levelSumArray.Add(levelSum);
        }
        if (levelSumArray.Count < k) {
            return -1;
        }
        ((List<long>) levelSumArray).Sort();
        return levelSumArray[levelSumArray.Count - k];
    }
}
```

```c++
class Solution {
public:
    long long kthLargestLevelSum(TreeNode* root, int k) {
        queue<TreeNode *> q;
        q.push(root);
        vector<long long> levelSumArray;
        while (!q.empty()) {
            long long levelSum = 0, size = q.size();
            for (int i = 0; i < size; i++) {
                TreeNode *node = q.front();
                q.pop();
                levelSum += node->val;
                if (node->left) {
                    q.push(node->left);
                }
                if (node->right) {
                    q.push(node->right);
                }
            }
            levelSumArray.push_back(levelSum);
        }
        if (levelSumArray.size() < k) {
            return -1;
        }
        sort(levelSumArray.begin(), levelSumArray.end());
        return *(levelSumArray.end() - k);
    }
};
```

```go
func kthLargestLevelSum(root *TreeNode, k int) int64 {
    q := []*TreeNode{root}
    var levelSumArray []int64
    for len(q) > 0 {
        levelSum, size := int64(0), len(q)
        for i := 0; i < size; i++ {
            node := q[0]
            q = q[1:]
            levelSum += int64(node.Val)
            if node.Left != nil {
                q = append(q, node.Left)
            }
            if node.Right != nil {
                q = append(q, node.Right)
            }
        }
        levelSumArray = append(levelSumArray, levelSum)
    }
    if len(levelSumArray) < k {
        return -1
    }
    sort.Slice(levelSumArray, func(i, j int) bool {
        return levelSumArray[i] < levelSumArray[j]
    })
    return levelSumArray[len(levelSumArray) - k]
}
```

```c
#define MAX_NODE_SIZE 100000

static long long cmp(const void *a, const void *b) {
    long long sub = *(long long *)a - *(long long *)b;
    return sub < 0 ? -1 : 1;
}

long long kthLargestLevelSum(struct TreeNode* root, int k) {
    struct TreeNode **q = (struct TreeNode **)malloc(sizeof(struct TreeNode *) * MAX_NODE_SIZE);
    long long *levelSumArray = (long long *)malloc(sizeof(long long) * MAX_NODE_SIZE);
    int head = 0, tail = 0;
    int pos = 0;
    q[tail++] = root;
    while (head != tail) {
        long long levelSum = 0, size = tail - head;
        for (int i = 0; i < size; i++) {
            struct TreeNode *node = q[head];
            head++;
            levelSum += node->val;
            if (node->left) {
                q[tail++] = node->left;
            }
            if (node->right) {
                q[tail++] = node->right;
            }
        }
        levelSumArray[pos++] = levelSum;
    }
    if (pos < k) {
        return -1;
    }
    qsort(levelSumArray, pos, sizeof(long long), cmp);
    return levelSumArray[pos - k];
}
```

```javascript
var kthLargestLevelSum = function(root, k) {
    let q = [root];
    let levelSumArray = [];
    while (q.length > 0) {
        let levelSum = 0, size = q.length;
        for (let i = 0; i < size; i++) {
            let node = q.shift();
            levelSum += node.val;
            if (node.left) {
                q.push(node.left);
            }
            if (node.right) {
                q.push(node.right);
            }
        }
        levelSumArray.push(levelSum);
    }
    if (levelSumArray.length < k) {
        return -1;
    }
    levelSumArray.sort((a, b) => b - a);
    return levelSumArray[k - 1];
};
```

```typescript
function kthLargestLevelSum(root: TreeNode | null, k: number): number {
    let q: TreeNode[] = [root];
    let levelSumArray: number[] = [];
    while (q.length > 0) {
        let levelSum = 0, size = q.length;
        for (let i = 0; i < size; i++) {
            let node = q.shift()!;
            levelSum += node.val;
            if (node.left) {
                q.push(node.left);
            }
            if (node.right) {
                q.push(node.right);
            }
        }
        levelSumArray.push(levelSum);
    }
    if (levelSumArray.length < k) {
        return -1;
    }
    levelSumArray.sort((a, b) => b - a);
    return levelSumArray[k - 1];
};
```

#### 复杂度分析

- 时间复杂度：$O(n\times\log{n})$，其中 $n$ 是树中的节点数。广度优先搜索消耗 $O(n)$，一次排序消耗 $O(n\times\log{n})$。
- 空间复杂度：$O(n)$，其中 $n$ 是树中的节点数。广度优先搜索消耗 $O(n)$，一次排序消耗 $O(\log{n})$。
