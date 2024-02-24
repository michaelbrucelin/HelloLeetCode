### [二叉搜索树最近节点查询](https://leetcode.cn/problems/closest-nodes-queries-in-a-binary-search-tree/solutions/2645284/er-cha-sou-suo-shu-zui-jin-jie-dian-cha-vp6p2/)

#### 方法一：二分查找

##### 思路与算法

根据题意要求给定查询的值 $\textit{queries}_i$，需要在二叉搜索中找到 $\textit{min}_i, \textit{max}_i$：

- $\textit{min}_i$ 是树中小于等于 $\textit{queries}_i$ 的**最大值**。如果不存在这样的值，则使用 $-1$ 代替。
- $\textit{max}_i$ 是树中大于等于 $\textit{queries}_i$ 的**最小值**。如果不存在这样的值，则使用 $-1$ 代替。

由于该二叉搜索树并不是平衡的，则最坏情况该树可能形成一条链，直接在树上查找可能存在超时。我们可以保存树中所有的节点值，并将其排序，每次给定查询值 $\textit{val}$ 时，利用二分查找直接在树中找到大于等于 $\textit{val}$ 的最小值与小于等于 $\textit{val}$ 的最小值。由于给定的二叉树为**二叉搜索树**，因此按照**中序**遍历该树的结果即为升序，我们直接用数组 $\textit{arr}$ 保存二叉树的中序遍历结果，并使用二分查找在索引中找到大于等于 $\textit{val}$ 最左侧的索引 $\textit{index}$，此时分析如下：

- 如果索引 $\textit{index}$ 合法存在，则此时大于等于 $\textit{val}$ 的最小元素即为 $\textit{arr}[\textit{index}]$，否则则为 $-1$，如果此时 $\textit{arr}[\textit{index}] = \textit{val}$，则小于等于 $\textit{val}$ 的最大元素也为 $\textit{arr}[\textit{index}]$。
- 如果索引 $\textit{index}$ 大于 $0$，则此时小于等于 $\textit{val}$ 的最大元素即为 $\textit{arr}[\textit{index} -1]$，否则则为 $-1$。

我们按照题目要求返回查询结果即可。

##### 代码

```c++
class Solution {
public:
    vector<vector<int>> closestNodes(TreeNode* root, vector<int>& queries) {
        vector<int> arr;
        function<void(TreeNode*)> dfs = [&](TreeNode *root) {
            if (!root) {
                return;
            }    
            dfs(root->left);
            arr.emplace_back(root->val);
            dfs(root->right);
        };
        dfs(root);

        vector<vector<int>> res;
        for (int val : queries) {
            int maxVal = -1, minVal = -1;
            auto it = lower_bound(arr.begin(), arr.end(), val);
            if (it != arr.end()) {
                maxVal = *it;
                if (*it == val) {
                    minVal = *it;
                    res.push_back({minVal, maxVal});
                    continue;
                }
            }
            if (it != arr.begin()) {
                minVal = *(--it);
            }
            res.push_back({minVal, maxVal});
        }
        return res;
    }
};
```

```java
class Solution {
    public List<List<Integer>> closestNodes(TreeNode root, List<Integer> queries) {
        List<Integer> arr = new ArrayList<Integer>();
        dfs(root, arr);

        List<List<Integer>> res = new ArrayList<List<Integer>>();
        for (int val : queries) {
            int maxVal = -1, minVal = -1;
            int idx = binarySearch(arr, val);
            if (idx != arr.size()) {
                maxVal = arr.get(idx);
                if (arr.get(idx) == val) {
                    minVal = val;
                    List<Integer> list = new ArrayList<Integer>();
                    list.add(minVal);
                    list.add(maxVal);
                    res.add(list);
                    continue;
                }
            }
            if (idx > 0) {
                minVal = arr.get(idx - 1);
            }
            List<Integer> list2 = new ArrayList<Integer>();
            list2.add(minVal);
            list2.add(maxVal);
            res.add(list2);
        }
        return res;
    }

    public void dfs(TreeNode root, List<Integer> arr) {
        if (root == null) {
            return;
        }    
        dfs(root.left, arr);
        arr.add(root.val);
        dfs(root.right, arr);
    }

    public int binarySearch(List<Integer> arr, int target) {
        int low = 0, high = arr.size();
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (arr.get(mid) >= target) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}
```

```csharp
public class Solution {
    public IList<IList<int>> ClosestNodes(TreeNode root, IList<int> queries) {
        IList<int> arr = new List<int>();
        DFS(root, arr);

        IList<IList<int>> res = new List<IList<int>>();
        foreach (int val in queries) {
            int maxVal = -1, minVal = -1;
            int idx = BinarySearch(arr, val);
            if (idx != arr.Count) {
                maxVal = arr[idx];
                if (arr[idx] == val) {
                    minVal = val;
                    IList<int> list = new List<int>();
                    list.Add(minVal);
                    list.Add(maxVal);
                    res.Add(list);
                    continue;
                }
            }
            if (idx > 0) {
                minVal = arr[idx - 1];
            }
            IList<int> list2 = new List<int>();
            list2.Add(minVal);
            list2.Add(maxVal);
            res.Add(list2);
        }
        return res;
    }

    public void DFS(TreeNode root, IList<int> arr) {
        if (root == null) {
            return;
        }    
        DFS(root.left, arr);
        arr.Add(root.val);
        DFS(root.right, arr);
    }

    public int BinarySearch(IList<int> arr, int target) {
        int low = 0, high = arr.Count;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (arr[mid] >= target) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}
```

```c
int count(struct TreeNode* root) {
    if (!root) {
        return 0;
    }
    return 1 + count(root->left) + count(root->right);
}

void dfs(struct TreeNode* root, int *arr, int *pos) {
    if (!root) {
        return;
    }
    dfs(root->left, arr, pos);
    arr[*pos] = root->val;
    (*pos)++;
    dfs(root->right, arr, pos);
}

int binarySearch(const int *arr, int arrSize, int target) {
    int lo = 0, hi = arrSize - 1;
    int ret = arrSize;
    while (lo <= hi) {
        int mid = (lo + hi) >> 1;
        if (arr[mid] >= target) {
            ret = mid;
            hi = mid - 1;
        } else {
            lo = mid + 1;
        }
    }
    return ret;
}

int** closestNodes(struct TreeNode* root, int* queries, int queriesSize, int* returnSize, int** returnColumnSizes) {
    int tot = count(root);
    int *arr = (int *)malloc(sizeof(int) * tot);
    int pos = 0;
    dfs(root, arr, &pos);

    int **res = (int **)malloc(sizeof(int *) * queriesSize);
    *returnColumnSizes = (int *)malloc(sizeof(int) * queriesSize);
    for (int i = 0; i < queriesSize; i++) {
        res[i] = (int *)malloc(sizeof(int) * 2);
        (*returnColumnSizes)[i] = 2;

        int val = queries[i];
        int maxVal = -1, minVal = -1;
        int index = binarySearch(arr, tot,  val);
        if (index != tot) {
            maxVal = arr[index];
            if (arr[index] == val) {
                minVal = arr[index];
                res[i][0] = minVal;
                res[i][1] = maxVal;
                continue;
            }
        }
        if (index != 0) {
            minVal = arr[index - 1];
        }
        res[i][0] = minVal;
        res[i][1] = maxVal;
    }
    *returnSize = queriesSize;
    return res;
}
```

```python
class Solution:
    def closestNodes(self, root: Optional[TreeNode], queries: List[int]) -> List[List[int]]:
        arr = []
        def dfs(root):
            if root is None:
                return
            dfs(root.left)
            arr.append(root.val)
            dfs(root.right)
        
        dfs(root)
        res = []
        for val in  queries:
            maxVal, minVal = -1, -1
            index = bisect_left(arr, val)
            if index != len(arr):
                maxVal = arr[index]
                if arr[index] == val:
                    minVal = arr[index]
                    res.append([minVal, maxVal])
                    continue
            if index != 0:
                minVal = arr[index - 1]
            res.append([minVal, maxVal])
        return res
```

```go
func closestNodes(root *TreeNode, queries []int) [][]int {
    arr := []int{}
    var dfs func(*TreeNode)
    dfs = func(root *TreeNode) {
        if root == nil {
            return
        }
        dfs(root.Left)
        arr = append(arr, root.Val)
        dfs(root.Right)
    }
    
    dfs(root)
    res := make([][]int, len(queries))
    for i, val := range queries {
        maxVal, minVal := -1, -1
        index := sort.SearchInts(arr, val)
        if index < len(arr) {
            maxVal = arr[index]
            if arr[index] == val {
                minVal = arr[index]
                res[i] = []int{minVal, maxVal}
                continue
            }
        }
        if index != 0 {
            minVal = arr[index - 1]
        }
        res[i] = []int{minVal, maxVal}
    }
    return res
}
```

```javascript
var binarySearch = function(arr, target) {
    let lo = 0, hi = arr.length - 1;
    let ret = arr.length;
    while (lo <= hi) {
        let mid = (lo + hi) >> 1;
        if (arr[mid] >= target) {
            ret = mid;
            hi = mid - 1;
        } else {
            lo = mid + 1;
        }
    }
    return ret;
}   

var closestNodes = function(root, queries) {
    const arr = new Array();
    const dfs = function(root) {
        if (!root) {
            return;
        }
        dfs(root.left);
        arr.push(root.val);
        dfs(root.right);
    }
    dfs(root);
    
    const res = new Array();
    for (const val of queries) {
        let maxVal = -1, minVal = -1;
        let index = binarySearch(arr, val);
        if (index != arr.length) {
            maxVal = arr[index];
            if (arr[index] == val) {
                minVal = arr[index];
                res.push([minVal, maxVal]);
                continue;
            }
        }
        if (index != 0) {
            minVal = arr[index - 1];
        }
        res.push([minVal, maxVal]);
    }
    return res;
};
```

```typescript
const binarySearch = (arr: number[], target: number): number => {
    let lo: number = 0, hi: number = arr.length - 1;
    let ret: number = arr.length;
    while (lo <= hi) {
        let mid: number = (lo + hi) >> 1;
        if (arr[mid] >= target) {
            ret = mid;
            hi = mid - 1;
        } else {
            lo = mid + 1;
        }
    }
    return ret;
}

function closestNodes(root: TreeNode | null, queries: number[]): number[][] {
    const arr: number[] = [];
    const dfs = (node: TreeNode | undefined): void => {
        if (!node) {
            return;
        }
        dfs(node.left);
        arr.push(node.val);
        dfs(node.right);
    }
    dfs(root);
    const res: number[][] = [];
    for (const val of queries) {
        let maxVal: number = -1, minVal: number = -1;
        let index: number = binarySearch(arr, val);
        if (index !== arr.length) {
            maxVal = arr[index];

            if (arr[index] === val) {
                minVal = arr[index];
                res.push([minVal, maxVal]);
                continue;
            }
        }
        if (index !== 0) {
            minVal = arr[index - 1];
        }
        res.push([minVal, maxVal]);
    }

    return res;
};
```

#### 复杂度分析

- 时间复杂度：$O(n + q \log n)$，其中 $n$ 表示给定二叉搜索树中节点的数目，$q$ 表示给定的查询数组的长度。遍历整个二叉树需要的时间为 $O(n)$，每次查询时二分查找需要的时间为 $O(\log n)$，一共需要 $q$ 次二分查找，因此总的时间复杂度为 $O(n + q \log n)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示给定二叉搜索树中节点的数目。查询时，需要用数组保存二叉树中所有节点的值，需要的空间为 $O(n)$。
