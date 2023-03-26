#### [方法三：深度优先搜索 + 中序遍历 + 双指针](https://leetcode.cn/problems/two-sum-iv-input-is-a-bst/solutions/1347526/liang-shu-zhi-he-iv-shu-ru-bst-by-leetco-b4nl/)

**思路和算法**

注意到二叉搜索树的中序遍历是升序排列的，我们可以将该二叉搜索树的中序遍历的结果记录下来，得到一个升序数组。

这样该问题即转化为「[167\. 两数之和 II - 输入有序数组](https://leetcode-cn.com/problems/two-sum-ii-input-array-is-sorted/)」。我们可以使用双指针解决它。

具体地，我们使用两个指针分别指向数组的头尾，当两个指针指向的元素之和小于 $k$ 时，让左指针右移；当两个指针指向的元素之和大于 $k$ 时，让右指针左移；当两个指针指向的元素之和等于 $k$ 时，返回 $True$。

最终，当左指针和右指针重合时，树上不存在两个和为 $k$ 的节点，返回 $False$。

**代码**

```python
class Solution:
    def findTarget(self, root: Optional[TreeNode], k: int) -> bool:
        arr = []
        def inorderTraversal(node: Optional[TreeNode]) -> None:
            if node:
                inorderTraversal(node.left)
                arr.append(node.val)
                inorderTraversal(node.right)
        inorderTraversal(root)

        left, right = 0, len(arr) - 1
        while left < right:
            sum = arr[left] + arr[right]
            if sum == k:
                return True
            if sum < k:
                left += 1
            else:
                right -= 1
        return False
```

```cpp
class Solution {
public:
    vector<int> vec;

    void inorderTraversal(TreeNode *node) {
        if (node == nullptr) {
            return;
        }
        inorderTraversal(node->left);
        vec.push_back(node->val);
        inorderTraversal(node->right);
    }

    bool findTarget(TreeNode *root, int k) {
        inorderTraversal(root);
        int left = 0, right = vec.size() - 1;
        while (left < right) {
            if (vec[left] + vec[right] == k) {
                return true;
            }
            if (vec[left] + vec[right] < k) {
                left++;
            } else {
                right--;
            }
        }
        return false;
    }
};
```

```java
class Solution {
    List<Integer> list = new ArrayList<Integer>();

    public boolean findTarget(TreeNode root, int k) {
        inorderTraversal(root);
        int left = 0, right = list.size() - 1;
        while (left < right) {
            if (list.get(left) + list.get(right) == k) {
                return true;
            }
            if (list.get(left) + list.get(right) < k) {
                left++;
            } else {
                right--;
            }
        }
        return false;
    }

    public void inorderTraversal(TreeNode node) {
        if (node == null) {
            return;
        }
        inorderTraversal(node.left);
        list.add(node.val);
        inorderTraversal(node.right);
    }
}
```

```csharp
public class Solution {
    IList<int> list = new List<int>();

    public bool FindTarget(TreeNode root, int k) {
        InorderTraversal(root);
        int left = 0, right = list.Count - 1;
        while (left < right) {
            if (list[left] + list[right] == k) {
                return true;
            }
            if (list[left] + list[right] < k) {
                left++;
            } else {
                right--;
            }
        }
        return false;
    }

    public void InorderTraversal(TreeNode node) {
        if (node == null) {
            return;
        }
        InorderTraversal(node.left);
        list.Add(node.val);
        InorderTraversal(node.right);
    }
}
```

```c
#define MAX_NODE_SIZE 1e4

void inorderTraversal(const struct TreeNode* node, int* vec, int* pos) {
    if (node == NULL) {
        return;
    }
    inorderTraversal(node->left, vec, pos);
    vec[(*pos)++] = node->val;
    inorderTraversal(node->right, vec, pos);
}

bool findTarget(struct TreeNode* root, int k) {
    int * vec = (int *)malloc(sizeof(int) * MAX_NODE_SIZE);
    int pos = 0;
    inorderTraversal(root, vec, &pos);
    int left = 0, right = pos - 1;
    while (left < right) {
        if (vec[left] + vec[right] == k) {
            return true;
        }
        if (vec[left] + vec[right] < k) {
            left++;
        } else {
            right--;
        }
    }
    free(vec);
    return false;
}
```

```javascript
var findTarget = function(root, k) {
    const list = [];
    const inorderTraversal = (node) => {
        if (!node) {
            return;
        }
        inorderTraversal(node.left);
        list.push(node.val);
        inorderTraversal(node.right);
    }
    inorderTraversal(root);
    let left = 0, right = list.length - 1;
    while (left < right) {
        if (list[left] + list[right] === k) {
            return true;
        }
        if (list[left] + list[right] < k) {
            left++;
        } else {
            right--;
        }
    }
    return false;
};
```

```go
func findTarget(root *TreeNode, k int) bool {
    arr := []int{}
    var inorderTraversal func(*TreeNode)
    inorderTraversal = func(node *TreeNode) {
        if node != nil {
            inorderTraversal(node.Left)
            arr = append(arr, node.Val)
            inorderTraversal(node.Right)
        }
    }
    inorderTraversal(root)

    left, right := 0, len(arr)-1
    for left < right {
        sum := arr[left] + arr[right]
        if sum == k {
            return true
        }
        if sum < k {
            left++
        } else {
            right--
        }
    }
    return false
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 为二叉搜索树的大小。我们需要遍历整棵树一次，并对得到的升序数组使用双指针遍历。
-   空间复杂度：$O(n)$，其中 $n$ 为二叉搜索树的大小。主要为升序数组的开销。
