### [带因子的二叉树](https://leetcode.cn/problems/binary-trees-with-factors/solutions/2414616/dai-yin-zi-de-er-cha-shu-by-leetcode-sol-0082/)

#### 方法一：动态规划 + 双指针

因为每个整数 $arr[i]$ 均大于 $1$，因此每个非叶结点的值都大于它的子结点的值。考虑以 $arr[i]$ 为根结点的带因子的二叉树，那么它的所有子孙结点的值都小于 $arr[i]$。我们将 $arr$ 从小到大进行排序，那么对于以 $arr[i]$ 为根结点的带因子的二叉树，它的子孙结点值的下标只能在区间 $[0, i - 1)$ 中。 使用 $dp[i]$ 保存以 $arr[i]$ 为根结点的带因子的二叉树数目。我们从区间 $[0, i - 1)$ 内枚举 $arr[i]$ 的子结点，假设存在 $0 \le left \le right \lt i$，使 $arr[left] \times arr[right] = arr[i]$ 成立，那么 $arr[left]$ 和 $arr[right]$ 可以作为 $arr[i]$ 的两个子结点。同时 $arr[left]$ 和 $arr[right]$ 为根结点的带因子二叉树数目分别为 $dp[left]$ 和 $dp[right]$，不难推导出 $arr[left]$ 和 $arr[right]$ 作为 $arr[i]$ 的两个子结点时，带因子二叉树数目 $s$ 为：

-   $left = right$ 时，$s = dp[left] \times dp[right]$
-   $left \ne right$ 时，因为两个子结点可以交换，所以 $s = dp[left] \times dp[right] \times 2$

当 $arr[i]$ 没有子结点时，对应 $1$ 个带因子二叉树。因此，状态转移方程为：

$$dp[i] = 1 + \sum_{(left, right) \in U} dp[left] \times dp[right] \times (1 + f(left, right))$$

其中 $(left, right) \in U$ 表示所有满足 $0 \le left \le right \lt i$ 且 $arr[left] \times arr[right] = arr[i]$ 的下标对 $(left, right)$，而 $f(left, right)$ 的取值为当 $left = right$ 时，值为 $0$，否则值为 $1$（因为 $left \ne right$ 时，两个子结点可以交换）。

> 找出 $(left, right) \in U$ 的所有 $(left, right)$ 可以使用双指针进行查找。

```cpp
class Solution {
public:
    int numFactoredBinaryTrees(vector<int>& arr) {
        sort(arr.begin(), arr.end());
        int n = arr.size();
        vector<long long> dp(n);
        long long res = 0, mod = 1e9 + 7;
        for (int i = 0; i < n; i++) {
            dp[i] = 1;
            for (int left = 0, right = i - 1; left <= right; left++) {
                while (right >= left && (long long)arr[left] * arr[right] > arr[i]) {
                    right--;
                }
                if (right >= left && (long long)arr[left] * arr[right] == arr[i]) {
                    if (right != left) {
                        dp[i] = (dp[i] + dp[left] * dp[right] * 2) % mod;
                    } else {
                        dp[i] = (dp[i] + dp[left] * dp[right]) % mod;
                    }
                }
            }
            res = (res + dp[i]) % mod;
        }
        return res;
    }
};
```

```java
class Solution {
    public int numFactoredBinaryTrees(int[] arr) {
        Arrays.sort(arr);
        int n = arr.length;
        long[] dp = new long[n];
        long res = 0, mod = 1$0$$0$007;
        for (int i = 0; i < n; i++) {
            dp[i] = 1;
            for (int left = 0, right = i - 1; left <= right; left++) {
                while (right >= left && (long) arr[left] * arr[right] > arr[i]) {
                    right--;
                }
                if (right >= left && (long) arr[left] * arr[right] == arr[i]) {
                    if (right != left) {
                        dp[i] = (dp[i] + dp[left] * dp[right] * 2) % mod;
                    } else {
                        dp[i] = (dp[i] + dp[left] * dp[right]) % mod;
                    }
                }
            }
            res = (res + dp[i]) % mod;
        }
        return (int) res;
    }
}
```

```csharp
public class Solution {
    public int NumFactoredBinaryTrees(int[] arr) {
        Array.Sort(arr);
        int n = arr.Length;
        long[] dp = new long[n];
        long res = 0, mod = 1$0$$0$007;
        for (int i = 0; i < n; i++) {
            dp[i] = 1;
            for (int left = 0, right = i - 1; left <= right; left++) {
                while (right >= left && (long) arr[left] * arr[right] > arr[i]) {
                    right--;
                }
                if (right >= left && (long) arr[left] * arr[right] == arr[i]) {
                    if (right != left) {
                        dp[i] = (dp[i] + dp[left] * dp[right] * 2) % mod;
                    } else {
                        dp[i] = (dp[i] + dp[left] * dp[right]) % mod;
                    }
                }
            }
            res = (res + dp[i]) % mod;
        }
        return (int) res;
    }
}
```

```go
func numFactoredBinaryTrees(arr []int) int {
    sort.Ints(arr)
    dp := make([]int64, len(arr))
    res, mod := int64(0), int64(1e9 + 7)
    for i := 0; i < len(arr); i++ {
        dp[i] = 1
        for left, right := 0, i - 1; left <= right; left++ {
            for left <= right && int64(arr[left]) * int64(arr[right]) > int64(arr[i]) {
                right--
            }
            if left <= right && int64(arr[left]) * int64(arr[right]) == int64(arr[i]) {
                if left == right {
                    dp[i] = (dp[i] + dp[left] * dp[right]) % mod
                } else {
                    dp[i] = (dp[i] + dp[left] * dp[right] * 2) % mod
                }
            }
        }
        res = (res + dp[i]) % mod
    }
    return int(res)
}
```

```c
int cmp(const void *p1, const void *p2) {
    return *(int *)p1 - *(int *)p2;
}

int numFactoredBinaryTrees(int *arr, int arrSize){
    qsort(arr, arrSize, sizeof(int), cmp);
    long long *dp = (long long *)malloc(arrSize * sizeof(long long));
    long long res = 0, mod = 1e9 + 7;
    for (int i = 0; i < arrSize; i++) {
        dp[i] = 1;
        for (int left = 0, right = i - 1; left <= right; left++) {
            while (left <= right && (long long)arr[left] * arr[right] > arr[i]) {
                right--;
            }
            if (left <= right && (long long)arr[left] * arr[right] == arr[i]) {
                if (left == right) {
                    dp[i] = (dp[i] + dp[left] * dp[right]) % mod;
                } else {
                    dp[i] = (dp[i] + dp[left] * dp[right] * 2) % mod;
                }
            }
        }
        res = (res + dp[i]) % mod;
    }
    return res;
}
```

```python
class Solution:
    def numFactoredBinaryTrees(self, arr: List[int]) -> int:
        n = len(arr)
        arr = sorted(arr)
        dp = [1] * n
        res, mod = 0, 10**9 + 7
        for i in range(n):
            left, right = 0, i - 1
            while left <= right:
                while right >= left and arr[left] * arr[right] > arr[i]:
                    right -= 1
                if right >= left and arr[left] * arr[right] == arr[i]:
                    if right != left:
                        dp[i] = (dp[i] + dp[left] * dp[right] * 2) % mod
                    else:
                        dp[i] = (dp[i] + dp[left] * dp[right]) % mod
                left += 1
            res = (res + dp[i]) % mod
        return res
```

```javascript
var numFactoredBinaryTrees = function(arr) {
    const n = arr.length;
    const mod = 1e9 + 7;
    const dp = new Array(n).fill(1)
    arr.sort((a, b) => a - b);
    let res = 0;
    for (let i = 0; i < n; i++) {
        for (let left = 0, right = i - 1; left <= right; left++) {
            while (right >= left && arr[left] * arr[right] > arr[i]) {
                right--;
            }
            if (right >= left && arr[left] * arr[right] == arr[i]) {
                if (right != left) {
                    dp[i] = (dp[i] + dp[left] * dp[right] * 2) % mod;
                } else {
                    dp[i] = (dp[i] + dp[left] * dp[right]) % mod;
                }
            }
        }
        res = (res + dp[i]) % mod;
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(n^2)$，其中 $n$ 是数组 $arr$ 的长度。双指针找两个子结点需要 $O(n)$，总时间复杂度为 $O(n^2)$。
-   空间复杂度：$O(n)$。保存动态规划的状态需要 $O(n)$。
