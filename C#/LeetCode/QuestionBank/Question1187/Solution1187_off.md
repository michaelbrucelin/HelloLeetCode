#### [方法一：动态规划](https://leetcode.cn/problems/make-array-strictly-increasing/solutions/2235513/shi-shu-zu-yan-ge-di-zeng-by-leetcode-so-6p94/)

**思路与算法**

此题为经典的「[300\. 最长递增子序列](https://leetcode.cn/problems/longest-increasing-subsequence/description/)」问题的变形题目，我们可以参考类似的题目解法。首先我们思考一下，由于要求数组严格递增，因此数组中不可能存在相同的元素，对于数组 $arr_2$ 来说，可以不需要考虑数组中的重复元素，可以预处理去除 $arr_2$ 的重复元素，假设数组 $arr_1$ 的长度为 $n$，数组 $arr_2$ 的长度为 $m$，此时可以知道最多可以替换的次数为 $\min(n,m)$。如何才能定义动态规划的递推公式，这就需要进行思考。我们设 $dp[i][j]$ 表示数组 $arr_1$ 中的前 $i$ 个元素进行了 $j$ 次替换后组成严格递增子数组末尾元素的最小值。当我们遍历 $arr_1$ 的第 $i$ 个元素时，此时 $arr1[i]$ 要么进行替换，要么进行保留，实际可以分类进行讨论:

-   此时如果 $arr1[i]$ 需要进行保留，则 $arr1[i]$ 一定严格大于前 $i-1$ 个元素替换后组成的严格递增子数组最末尾的元素。假设前 $i-1$ 个元素经过了 $j$ 次变换后得到的递增子数组的末尾元素的最小值为 $dp[i-1][j]$，如果满足 $arr_1[i] > dp[i-1][j]$，则此时 $arr1[i]$ 可以保留加入到该子数组中且构成的数组严格递增；
-   此时如果 $arr1[i]$ 需要进行替换，则替换后的元素一定严格大于前 $i-1$ 个元素替换后组成的严格递增子数组最末尾的元素。假设前 $i-1$ 个元素经过了 $j-1$ 次变换后得到的递增子数组的末尾元素的最小值为 $dp[i-1][j-1]$，此时我们从 $arr_2$ 找到严格大于 $dp[i-1][j-1]$ 的最小元素 $arr_2[k]$，则此时将 $arr_2[k]$ 加入到该子数组中且构成数组严格递增；
-   综上可知，每个元素在替换时只有两种选择，要么选择保留当前元素 $arr_1$，要么从 $arr_2$ 中选择一个满足条件的最小元素加入到数组中，最少替换方案一定包含在上述替换方法中。我们可以得到以下递推关系：

$$\begin{cases} dp[i][j] = \min(dp[i][j],arr_1[i]), \quad & \textbf{if} \ arr_1[i] > dp[i-1][j] \\ dp[i][j] = \min(dp[i][j],arr_2[k]), \quad & \textbf{if} \ arr_2[k] > dp[i-1][j-1] \end{cases}$$

为了便于计算，我们将 $dp[i][j]$ 的初始值都设为 $\infty$，为了便于计算在最开始加一个哨兵，此时令 $dp[0][0] = -1$ 表示最小值。实际计算过程如下:

-   为了方便计算，需要对 $arr_2$ 进行预处理，去掉其中的重复元素，为了快速找到数组 $arr_2$ 中的最小元素，还需要对 $arr_2$ 进行排序；
-   依次尝试计算前 $i$ 个元素在满足 $j$ 次替换时的最小元素：
    -   如果当前元素 $arr1[i]$ 大于 $dp[i][j-1]$，此时可以尝试将 $arr1[i]$ 替换为 $dp[i][j]$，即此时 $dp[i][j] = \min(dp[i][j],arr_1[i])$。
    -   如果前 $i-1$ 个元素可以满足 $j-1$ 次替换后成为严格递增数组，即满足 $dp[i-1][j-1] \neq \infty$，可以尝试在第 $j$ 次替换掉 $arr1[i]$，此时根据贪心原则，利用二分查找可以快速的找到严格大于 $dp[i-1][j-1]$ 的最小值进行替换即可。
-   设当前数组 $arr1[i]$ 的长度为 $n$，如果前 $n$ 个元素满足 $j$ 次替换后成为严格递增数组，此时我们找到最小的 $j$ 返回即可。

**代码**

```cpp
constexpr int INF = 0x3f3f3f3f;

class Solution {
public:
    int makeArrayIncreasing(vector<int>& arr1, vector<int>& arr2) {
        sort(arr2.begin(), arr2.end());
        arr2.erase(unique(arr2.begin(), arr2.end()), arr2.end());
        int n = arr1.size();
        int m = arr2.size();
        vector<vector<int>> dp(n + 1, vector<int>(min(m, n) + 1, INF));
        dp[0][0] = -1;
        for (int i = 1; i <= n; i++) {
            for (int j = 0; j <= min(i, m); j++) {
                /* 如果当前元素大于序列的最后一个元素 */
                if (arr1[i - 1] > dp[i - 1][j]) {
                    dp[i][j] = arr1[i - 1];
                }
                if (j > 0 && dp[i - 1][j - 1] != INF) {
                    /* 查找严格大于 dp[i - 1][j - 1] 的最小元素 */
                    auto it = upper_bound(arr2.begin() + j - 1, arr2.end(), dp[i - 1][j - 1]);
                    if (it != arr2.end()) {
                        dp[i][j] = min(dp[i][j], *it);
                    }
                }
                if (i == n && dp[i][j] != INF) {
                    return j;
                }
            }
        }
        return -1;
    }
};
```

```java
class Solution {
    static final int INF = 0x3f3f3f3f;

    public int makeArrayIncreasing(int[] arr1, int[] arr2) {
        Arrays.sort(arr2);
        List<Integer> list = new ArrayList<Integer>();
        int prev = -1;
        for (int num : arr2) {
            if (num != prev) {
                list.add(num);
                prev = num;
            }
        }
        int n = arr1.length;
        int m = list.size();
        int[][] dp = new int[n + 1][Math.min(m, n) + 1];
        for (int i = 0; i <= n; i++) {
            Arrays.fill(dp[i], INF);
        }
        dp[0][0] = -1;
        for (int i = 1; i <= n; i++) {
            for (int j = 0; j <= Math.min(i, m); j++) {
                /* 如果当前元素大于序列的最后一个元素 */
                if (arr1[i - 1] > dp[i - 1][j]) {
                    dp[i][j] = arr1[i - 1];
                }
                if (j > 0 && dp[i - 1][j - 1] != INF) {
                    /* 查找严格大于 dp[i - 1][j - 1] 的最小元素 */
                    int idx = binarySearch(list, j - 1, dp[i - 1][j - 1]);
                    if (idx != list.size()) {
                        dp[i][j] = Math.min(dp[i][j], list.get(idx));
                    }
                }
                if (i == n && dp[i][j] != INF) {
                    return j;
                }
            }
        }
        return -1;
    }

    public int binarySearch(List<Integer> list, int low, int target) {
        int high = list.size();
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (list.get(mid) > target) {
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
    const int INF = 0x3f3f3f3f;

    public int MakeArrayIncreasing(int[] arr1, int[] arr2) {
        Array.Sort(arr2);
        IList<int> list = new List<int>();
        int prev = -1;
        foreach (int num in arr2) {
            if (num != prev) {
                list.Add(num);
                prev = num;
            }
        }
        int n = arr1.Length;
        int m = list.Count;
        int[][] dp = new int[n + 1][];
        for (int i = 0; i <= n; i++) {
            dp[i] = new int[Math.Min(m, n) + 1];
            Array.Fill(dp[i], INF);
        }
        dp[0][0] = -1;
        for (int i = 1; i <= n; i++) {
            for (int j = 0; j <= Math.Min(i, m); j++) {
                /* 如果当前元素大于序列的最后一个元素 */
                if (arr1[i - 1] > dp[i - 1][j]) {
                    dp[i][j] = arr1[i - 1];
                }
                if (j > 0 && dp[i - 1][j - 1] != INF) {
                    /* 查找严格大于 dp[i - 1][j - 1] 的最小元素 */
                    int idx = BinarySearch(list, j - 1, dp[i - 1][j - 1]);
                    if (idx != list.Count) {
                        dp[i][j] = Math.Min(dp[i][j], list[idx]);
                    }
                }
                if (i == n && dp[i][j] != INF) {
                    return j;
                }
            }
        }
        return -1;
    }

    public int BinarySearch(IList<int> list, int low, int target) {
        int high = list.Count;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (list[mid] > target) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}
```

```python
class Solution:
    def makeArrayIncreasing(self, arr1: List[int], arr2: List[int]) -> int:
        arr2 = sorted(set(arr2))
        n = len(arr1)
        m = len(arr2)
        dp = [[inf] *(min(m, n)+1) for _ in range(n + 1)]
        dp[0][0] = -1
        for i in range(1, n + 1):
            for j in range(min(i, m) + 1):
                if arr1[i - 1] > dp[i - 1][j]:
                    dp[i][j] = arr1[i - 1]
                if j and dp[i - 1][j - 1] != inf:
                    k = bisect_right(arr2, dp[i - 1][j - 1], j - 1)
                    if k < m:
                        dp[i][j] = min(dp[i][j], arr2[k])
                if i == n and dp[i][j] != inf:
                    return j
        return -1
```

```c
#define MIN(a, b) ((a) < (b) ? (a) : (b))

const int INF = 0x3f3f3f3f;

static int cmp(const void *pa, const void *pb) {
    return *(int *)pa - *(int *)pb;
}

int binarySearch(int *arr, int left, int right, int val) {
    int ret = right + 1;
    while (left <= right) {
        int mid = left + (right - left) / 2;
        if (arr[mid] > val) {
            ret = mid;
            right = mid - 1;
        } else {
            left = mid + 1;
        }
    }
    return ret;
}

int min(int a, int b) {
    return a < b ? a : b;
}

int makeArrayIncreasing(int* arr1, int arr1Size, int* arr2, int arr2Size) {
    qsort(arr2, arr2Size, sizeof(int), cmp);
    int m = 0;
    for (int i = 0; i < arr2Size; i++) {
        if (i == 0 || arr2[i] != arr2[i - 1]) {
            arr2[m++] = arr2[i];
        }
    }
    int n = arr1Size;
    int dp[n + 1][min(n, m) + 1];
    memset(dp, 0x3f, sizeof(dp));
    dp[0][0] = -1;
    for (int i = 1; i <= n; i++) {
        for (int j = 0; j <= min(i, m); j++) {
            /* 如果当前元素大于序列的最后一个元素 */
            if (arr1[i - 1] > dp[i - 1][j]) {
                dp[i][j] = arr1[i - 1];
            }
            if (j > 0 && dp[i - 1][j - 1] != INF) {
                /* 二分查找严格大于 dp[i - 1][j - 1] 的最小元素 */
                int index = binarySearch(arr2, j - 1, m - 1, dp[i - 1][j - 1]);
                if (index != m) {
                    dp[i][j] = MIN(dp[i][j], arr2[index]);
                }
            }  
            if (i == n && dp[i][j] != INF) {
                return j;
            }
        }
    }
    return -1;
}
```

```javascript
const INF = 0x3f3f3f3f;
var makeArrayIncreasing = function(arr1, arr2) {
    arr2.sort((a, b) => a - b);
    const list = [];
    let prev = -1;
    for (const num of arr2) {
        if (num !== prev) {
            list.push(num);
            prev = num;
        }
    }
    const n = arr1.length;
    const m = list.length;
    const dp = new Array(n + 1).fill(0).map(() => new Array(Math.min(m, n) + 1).fill(INF));
    dp[0][0] = -1;
    for (let i = 1; i <= n; i++) {
        for (let j = 0; j <= Math.min(i, m); j++) {
            /* 如果当前元素大于序列的最后一个元素 */
            if (arr1[i - 1] > dp[i - 1][j]) {
                dp[i][j] = arr1[i - 1];
            }
            if (j > 0 && dp[i - 1][j - 1] !== INF) {
                /* 查找严格大于 dp[i - 1][j - 1] 的最小元素 */
                const idx = binarySearch(list, j - 1, dp[i - 1][j - 1]);
                if (idx !== list.length) {
                    dp[i][j] = Math.min(dp[i][j], list[idx]);
                }
            }
            if (i === n && dp[i][j] !== INF) {
                return j;
            }
        }
    }
    return -1;
}

const binarySearch = (list, low, target) => {
    let high = list.length;
    while (low < high) {
        const mid = low + Math.floor((high - low) / 2);
        if (list[mid] > target) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
};
```

```go
func makeArrayIncreasing(arr1 []int, arr2 []int) int {
    sort.Ints(arr2)
    n := len(arr1)
    m := len(arr2)
    dp := make([][]int, n+1)
    for i := range dp {
        dp[i] = make([]int, min(m, n)+1)
        for j := range dp[i] {
            dp[i][j] = math.MaxInt
        }
    }
    dp[0][0] = -1
    for i := 1; i <= len(arr1); i++ {
        for j := 0; j <= min(i, m); j++ {
            if arr1[i-1] > dp[i-1][j] {
                dp[i][j] = arr1[i-1]
            }
            if j > 0 && dp[i-1][j-1] != math.MaxInt {
                k := j - 1 + sort.SearchInts(arr2[j-1:], dp[i-1][j-1]+1)
                if k < m {
                    dp[i][j] = min(dp[i][j], arr2[k])
                }
            }
            if i == n && dp[i][j] != math.MaxInt {
                return j
            }
        }
    }
    return -1
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}
```

**复杂度分析**

-   时间复杂度：$O(n \times \min(m,n) \times \log m)$，其中 $n$ 表示数组 $arr_1$ 的长度，$m$ 表示数组 $arr_2$ 的长度。每次替换时，我们都需利用二分查找找到最小的元素，此时需要的时间为 $O(\log m)$，最多需要尝试 $n \times \min(m,n)$ 种替换方案，因此总的时间复杂度为 $O(n \times \min(m,n) \times \log m)$。
-   空间复杂度：$O(n \times \min(m,n))$，其中 $n$ 表示数组 $arr_1$ 的长度，$m$ 表示数组 $arr_2$ 的长度。我们需要保存每个子数组中替换次数下的末尾元素的最大值，一共最多有 $n$ 个子数组，每个子数组替换替换的次数最多为 $\min(n,m)$ 次数，因此空间复杂度为 $O(n \times \min(m,n))$。
