#### [������������������� + ������� + ˫ָ��](https://leetcode.cn/problems/two-sum-iv-input-is-a-bst/solutions/1347526/liang-shu-zhi-he-iv-shu-ru-bst-by-leetco-b4nl/)

**˼·���㷨**

ע�⵽����������������������������еģ����ǿ��Խ��ö�������������������Ľ����¼�������õ�һ���������顣

���������⼴ת��Ϊ��[167\. ����֮�� II - ������������](https://leetcode-cn.com/problems/two-sum-ii-input-array-is-sorted/)�������ǿ���ʹ��˫ָ��������

����أ�����ʹ������ָ��ֱ�ָ�������ͷβ��������ָ��ָ���Ԫ��֮��С�� $k$ ʱ������ָ�����ƣ�������ָ��ָ���Ԫ��֮�ʹ��� $k$ ʱ������ָ�����ƣ�������ָ��ָ���Ԫ��֮�͵��� $k$ ʱ������ $True$��

���գ�����ָ�����ָ���غ�ʱ�����ϲ�����������Ϊ $k$ �Ľڵ㣬���� $False$��

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ Ϊ�����������Ĵ�С��������Ҫ����������һ�Σ����Եõ�����������ʹ��˫ָ�������
-   �ռ临�Ӷȣ�$O(n)$������ $n$ Ϊ�����������Ĵ�С����ҪΪ��������Ŀ�����
