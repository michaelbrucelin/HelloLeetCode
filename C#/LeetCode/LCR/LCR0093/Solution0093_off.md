### [最长斐波那契数列](https://leetcode.cn/problems/Q91FMA/solutions/1654337/zui-chang-fei-bo-na-qi-shu-lie-by-leetco-0pft/)

#### 方法一：动态规划

如果数组 $arr$ 中存在三个下标 $i$、$j$、$k$ 满足 $arr[i]>arr[j]>arr[k]$ 且 $arr[k]+arr[j]=arr[i]$，则 arr[k]、arr[j] 和 $arr[i]$ 三个元素组成一个斐波那契式子序列。由于数组 $arr$ 严格递增，因此 $arr[i]>arr[j]>arr[k]$ 等价于 $i>j>k$。

当下标 $i$ 确定时，任何小于下标 $i$ 的下标 $j$ 都可能满足 $arr[j]$ 是某个斐波那契式子序列中 $arr[i]$ 前面的一个数字，因此只有当确定斐波那契式子序列的最后两个数字时，才能确定整个斐波那契式子序列。

定义二维数组 $dp$ 表示以每个下标对的元素作为最后两个数字的斐波那契式子序列的最大长度。当 $i>j$ 时，$dp[j][i]$ 表示以 $arr[j]$ 和 $arr[i]$ 作为最后两个数字的斐波那契式子序列的最大长度。初始时 $dp$ 中的所有值都是 $0$。

为了计算 $dp[j][i]$ 的值，需要得到该斐波那契序列中位于 $arr[j]$ 前面的数字，该数字是 $arr[i]-arr[j]$。如果 $arr[i]-arr[j]$ 存在于数组 $arr$ 中，且该数字小于 $arr[j]$，则用 $k$ 表示其下标，有 $arr[k]+arr[j]=arr[i]$。因此在以 $arr[k]$ 和 $arr[j]$ 作为最后两个数字的斐波那契式子序列的后面添加 $arr[i]$，即可得到以 $arr[j]$ 和 $arr[i]$ 作为最后两个数字的斐波那契式子序列。

根据斐波那契式子序列的定义可知，斐波那契式子序列的长度至少为 $3$。当 $dp[k][j]\ge 3$ 时，$dp[j][i]=dp[k][j]+1$。当 $dp[k][j]<3$ 时，以 $arr[k]$ 和 $arr[j]$ 作为最后两个数字的斐波那契式子序列并不存在，但是以 $arr[j]$ 和 $arr[i]$ 作为最后两个数字的斐波那契式子序列存在，此时有 $dp[j][i]=3$。

假设当 $arr[i]-arr[j]$ 不存在于数组中时，$k<0$，则完整的状态转移方程如下：

$$dp[j][i]=\begin{cases}max(dp[k][j]+1,3), & 0\le k<j \\ 0, & k<0\enspace or\enspace k\ge j\end{cases}$$

实现方面可以利用数组 $arr$ 的单调性优化。由于数组 $arr$ 是严格单调递增的，因此在确定下标 $i$ 的情况下可以反向遍历下标 $j$，计算 $dp[j][i]$ 的值，只有当 $arr[j]\times 2>arr[i]$ 时才满足 $arr[k]<arr[j]$，当 $arr[j]\times 2\le arr[i]$ 时不需要对当前下标 $i$ 继续遍历更小的下标 $j$。

```Python
class Solution:
    def lenLongestFibSubseq(self, arr: List[int]) -> int:
        indices = {x: i for i, x in enumerate(arr)}
        ans, n = 0, len(arr)
        dp = [[0] * n for _ in range(n)]
        for i, x in enumerate(arr):
            for j in range(n - 1, -1, -1):
                if arr[j] * 2 <= x:
                    break
                if x - arr[j] in indices:
                    k = indices[x - arr[j]]
                    dp[j][i] = max(dp[k][j] + 1, 3)
                    ans = max(ans, dp[j][i])
        return ans
```

```Java
class Solution {
    public int lenLongestFibSubseq(int[] arr) {
        Map<Integer, Integer> indices = new HashMap<Integer, Integer>();
        int n = arr.length;
        for (int i = 0; i < n; i++) {
            indices.put(arr[i], i);
        }
        int[][] dp = new int[n][n];
        int ans = 0;
        for (int i = 0; i < n; i++) {
            for (int j = i - 1; j >= 0 && arr[j] * 2 > arr[i]; j--) {
                int k = indices.getOrDefault(arr[i] - arr[j], -1);
                if (k >= 0) {
                    dp[j][i] = Math.max(dp[k][j] + 1, 3);
                }
                ans = Math.max(ans, dp[j][i]);
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int LenLongestFibSubseq(int[] arr) {
        Dictionary<int, int> indices = new Dictionary<int, int>();
        int n = arr.Length;
        for (int i = 0; i < n; i++) {
            indices.Add(arr[i], i);
        }
        int[,] dp = new int[n, n];
        int ans = 0;
        for (int i = 0; i < n; i++) {
            for (int j = i - 1; j >= 0 && arr[j] * 2 > arr[i]; j--) {
                int k = indices.ContainsKey(arr[i] - arr[j]) ? indices[arr[i] - arr[j]] : -1;
                if (k >= 0) {
                    dp[j, i] = Math.Max(dp[k, j] + 1, 3);
                }
                ans = Math.Max(ans, dp[j, i]);
            }
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    int lenLongestFibSubseq(vector<int>& arr) {
        unordered_map<int, int> indices;
        int n = arr.size();
        for (int i = 0; i < n; i++) {
            indices[arr[i]] = i;
        }
        vector<vector<int>> dp(n, vector<int>(n));
        int ans = 0;
        for (int i = 0; i < n; i++) {
            for (int j = i - 1; j >= 0 && arr[j] * 2 > arr[i]; j--) {
                int k = -1;
                if (indices.count(arr[i] - arr[j])) {
                    k = indices[arr[i] - arr[j]];
                }
                if (k >= 0) {
                    dp[j][i] = max(dp[k][j] + 1, 3);
                }
                ans = max(ans, dp[j][i]);
            }
        }
        return ans;
    }
};
```

```C
typedef struct {
    int key;
    int val;
    UT_hash_handle hh;
} HashItem;

#define MAX(a, b) ((a) > (b) ? (a) : (b))

int lenLongestFibSubseq(int* arr, int arrSize){
    HashItem *indices = NULL, *pEntry = NULL;
    for (int i = 0; i < arrSize; i++) {
        pEntry = (HashItem *)malloc(sizeof(HashItem));
        pEntry->key = arr[i];
        pEntry->val = i;
        HASH_ADD_INT(indices, key, pEntry);
    }
    int **dp = (int **)malloc(sizeof(int *) * arrSize);
    int ans = 0;
    for (int i = 0; i < arrSize; i++) {
        dp[i] = (int *)malloc(sizeof(int) * arrSize);
        memset(dp[i], 0, sizeof(int) * arrSize);
    }
    for (int i = 0; i < arrSize; i++) {
        for (int j = i - 1; j >= 0 && arr[j] * 2 > arr[i]; j--) {
            int k = -1;
            int target = arr[i] - arr[j];
            pEntry = NULL;
            HASH_FIND_INT(indices, &target, pEntry);
            if (pEntry) {
                k = pEntry->val;
            }
            if (k >= 0) {
                dp[j][i] = MAX(dp[k][j] + 1, 3);
            }
            ans = MAX(ans, dp[j][i]);
        }
    }
    for (int i = 0; i < arrSize; i++) {
        free(dp[i]);
    }
    free(dp);
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, indices, curr, tmp) {
        HASH_DEL(indices, curr);
        free(curr);
    }
    return ans;
}
```

```Go
func lenLongestFibSubseq(arr []int) (ans int) {
    n := len(arr)
    indices := make(map[int]int, n)
    for i, x := range arr {
        indices[x] = i
    }
    dp := make([][]int, n)
    for i := range dp {
        dp[i] = make([]int, n)
    }
    for i, x := range arr {
        for j := n - 1; j >= 0 && arr[j]*2 > x; j-- {
            if k, ok := indices[x-arr[j]]; ok {
                dp[j][i] = max(dp[k][j]+1, 3)
                ans = max(ans, dp[j][i])
            }
        }
    }
    return
}

func max(a, b int) int {
    if b > a {
        return b
    }
    return a
}
```

```JavaScript
var lenLongestFibSubseq = function(arr) {
    const indices = new Map();
    const n = arr.length;
    for (let i = 0; i < n; i++) {
        indices.set(arr[i], i);
    }
    const dp = new Array(n).fill(0).map(() => new Array(n).fill(0));
    let ans = 0;
    for (let i = 0; i < n; i++) {
        for (let j = n - 1; j >= 0; j--) {
            if (arr[j] * 2 <= arr[i]) {
                break;
            }
            if (indices.has(arr[i] - arr[j])) {
                const k = indices.get(arr[i] - arr[j]);
                dp[j][i] = Math.max(dp[k][j] + 1, 3);
                ans = Math.max(ans, dp[j][i]);
            }
        }
    }
    return ans;
};
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是数组 $arr$ 的长度。动态规划的状态数是 $O(n^2)$，每个状态的计算时间都是 $O(1)$。
- 空间复杂度：$O(n^2)$，其中 $n$ 是数组 $arr$ 的长度。需要创建二维数组 $dp$，空间是 $O(n^2)$。
