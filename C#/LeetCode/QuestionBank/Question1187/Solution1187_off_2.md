#### [方法二：动态规划二](https://leetcode.cn/problems/make-array-strictly-increasing/solutions/2235513/shi-shu-zu-yan-ge-di-zeng-by-leetcode-so-6p94/)

**思路与算法**

根据方法一的提示，我们可以变换一种动态规划的思路。我们可以观察到实际在替换时，假设当前数组 $arr_1$ 前 $i$ 个元素最少经过 $j$ 次替换成为严格递增数组，实际情况替换如下：

-   前 $i-1$ 个元素进行了 $j$ 次替换，此时 $arr_1[i]$ 保留；
-   前 $i-1$ 个元素进行了 $j-1$ 次替换，此时 $arr_1[i]$ 被替换；

根据以上想法，定义 $dp[i]$ 为使数组 $arr_1[i]$ 的前 $i$ 项递增，且保留 $arr_1[i]$ 的情况下的最小替换次数。

> 为什么只考虑不替换 $arr1[i]$ 的状态，因为如果替该元素，那么到底替换成哪个元素，此时需要另加一个状态维护。根据上述分析由于数组 $arr_1$ 中的每个元素都可能被替换，$arr_1$ 的最后一项也可能被替换，此时我们可以在数组最后增加一个非常大的数，而保证这个数不替换即可，这样即可保证当前的子状态中一定包含最优解。

首先为了方便计算我们对数组进行预处理，对于数组 $arr_2$ 来说，可以不需要考虑数组中的重复元素，可以预处理去除 $arr_2$ 的重复元素，假设数组 $arr_1$ 的长度为 $n$，数组 $arr_2$ 的长度为 $m$，此时可以知道最多可以替换的次数为 $\min(n,m)$。

**状态转移**

> 对于第 $i$ 个元素考虑 $dp[i]$，由于我们不能替换 $arr1[i]$，假设 $i$ 之前上一个被保留的元素为 $arr_1[k]$，则此时 $[k+1,i-1]$ 之间的元素均被替换，即此时 $arr_1[k+1],arr_1[k+2],\cdots,arr_1[i]$ 连续的 $i-k-1$ 个元素均被替换，此时需要的最小的替换次数可能为 $dp[k] + i - k + 1$。由于可能存在 $i$ 之前所有的元素均被替换的情形，此时我们可以在数组前面增加一个非常小的数，而保证这个数一定不被替换。

根据以上分析可知，我们需要尝试替换 $i$ 之前的连续 $j$ 个元素，分为以下两种情形讨论:

-   $arr1[i]$ 之前替换的元素为 $0$ 个，即此时保留 $arr_1[i-1]$。如果要保留 $arr_1[i-1]$，则此时一定满足 $arr_1[i-1] < arr_1[i]$，此时递推公式为：
$$dp[i] = \min(dp[i],dp[i-1])$$
-   $arr1[i]$ 之前替换的元素为 $j$ 个，此时 $j > 0$，此时 $arr_1[i]，arr_1[i-j-1]$ 均被保留，此时 $arr_1[i-j],arr_1[i-j+1],\cdots,arr_1[i-1]$ 连续的 $j$ 个元素被替换。如何上述替换才能一定能成立呢？此时最优选择肯定是我们在 $arr_2$ 中也找到连续的 $j$ 个元素来替换他们即可。假设替换的 $j$ 个元素为 $arr_2[k],arr_2[k+1],\cdots,arr_2[k+j-1]$，由于 $arr_2$ 已经是有序的，此时一定满足 $arr_2[k] < arr_2[k+1] < \cdots < arr_2[k+j-1]$，则这 $j$ 个元素需要满足如下条件即可进行替换：
    -   最小的元素 $arr_2[k]$ 一定需要大于 $arr_1[i-j-1]$；
    -   最大的元素 $arr_2[k+j-1]$ 一定需要小于 $arr1[i]$；
    -   上述情形下的此时递推公式即为：
$$\begin{aligned} dp[i] &= \min(dp[i],dp[i-j+1] + j) \\ & \mathbf{if \ exist} \ arr_2[k] > arr_1[i-j-1], arr_2[k+j-1] < arr_1[i] \end{aligned}$$

根据以上分析可以知道题目难点在于如何找到连续替换的元素，给定 $arr_1$ 的第 $i$ 个元素，此时需要替换 $arr_1$ 前面的 $j$ 个元素，是否可以在 $arr_2$ 中找到连续的 $j$ 个元素，其中最小的元素满足大于 $arr_1[i-j-1]$，最大的元素满足小于 $arr_1[i]$，此时根据贪心原则，我们可以用以下两种办法均可：

-   查找替换元素的左侧起点：通过二分查找可以在 $O(\log m)$ 时间复杂度内找到严格大于 $arr_1[i-j-1]$ 的最小元素 $arr_2[k]$。由于我们需要替换 $j$ 个元素，再检测替换的最大元素 $arr_2[k + i - j]$ 是否小于 $arr1[i]$ 即可；
-   查找替换元素的右侧终点：通过二分查找可以在 $O(\log m)$ 时间复杂度内找到严格小于 $arr1[i]$ 的最大元素 $arr_2[k]$。由于我们需要替换 $j$ 个元素，再检测替换的最小元素 $arr_2[k - j + 1]$ 是否大于 $arr_1[i-j-1]$ 即可；

由于数组 $arr1[i]$ 起点与终点的「哨兵」一定不会被替换的，因此添加「哨兵」不影响最终结果，最终返回 $dp[n]$ 即可。

**代码**

```cpp
constexpr int INF = 0x3f3f3f3f;

class Solution {
public:
    int makeArrayIncreasing(vector<int>& arr1, vector<int>& arr2) {
        sort(arr2.begin(), arr2.end());
        arr2.erase(unique(arr2.begin(), arr2.end()), arr2.end());
        /* 右侧哨兵 inf */
        arr1.push_back(INF); 
        /* 左侧哨兵 -1 */
        arr1.insert(arr1.begin(), -1); 
        int n = arr1.size();
        int m = arr2.size();

        vector<int> dp(n, INF);
        dp[0] = 0;
        for (int i = 1; i < n; i++) {
            /* arr1[i] 左侧的元素不进行替换 */
            if (arr1[i - 1] < arr1[i]) {
                dp[i] = min(dp[i], dp[i - 1]);
            }
            /* 替换 arr1[i] 左边的连续 j 个元素 */
            for (int j = 1; j < i; j++) { 
                /* arr2 的最优替换的起点为大于 arr1[i - j - 1] 的最小元素 */
                int k = upper_bound(arr2.begin(), arr2.end(), arr1[i - j - 1]) - arr2.begin();
                /* arr2 的最优替换的终点必须满足小于 arr1[i] */
                if (k + j - 1 < m && arr2[k + j - 1] < arr1[i]) {
                    dp[i] = min(dp[i], dp[i - j - 1] + j);
                }
            }
            
        }
        return dp[n - 1] == INF ? -1 : dp[n - 1];
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
        int[] temp = new int[arr1.length + 2];
        System.arraycopy(arr1, 0, temp, 1, arr1.length);
        /* 右侧哨兵 inf */
        temp[arr1.length + 1] = INF;
        /* 左侧哨兵 -1 */
        temp[0] = -1;
        arr1 = temp;
        int n = arr1.length;
        int m = list.size();

        int[] dp = new int[n];
        Arrays.fill(dp, INF);
        dp[0] = 0;
        for (int i = 1; i < n; i++) {
            /* arr1[i] 左侧的元素不进行替换 */
            if (arr1[i - 1] < arr1[i]) {
                dp[i] = Math.min(dp[i], dp[i - 1]);
            }
            /* 替换 arr1[i] 左边的连续 j 个元素 */
            for (int j = 1; j < i; j++) { 
                /* arr2 的最优替换的起点为大于 arr1[i - j - 1] 的最小元素 */
                int k = binarySearch(list, arr1[i - j - 1]);
                /* arr2 的最优替换的终点必须满足小于 arr1[i] */
                if (k + j - 1 < m && list.get(k + j - 1) < arr1[i]) {
                    dp[i] = Math.min(dp[i], dp[i - j - 1] + j);
                }
            }
            
        }
        return dp[n - 1] == INF ? -1 : dp[n - 1];
    }

    public int binarySearch(List<Integer> list, int target) {
        int low = 0, high = list.size();
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
        int[] temp = new int[arr1.Length + 2];
        Array.Copy(arr1, 0, temp, 1, arr1.Length);
        /* 右侧哨兵 inf */
        temp[arr1.Length + 1] = INF;
        /* 左侧哨兵 -1 */
        temp[0] = -1;
        arr1 = temp;
        int n = arr1.Length;
        int m = list.Count;

        int[] dp = new int[n];
        Array.Fill(dp, INF);
        dp[0] = 0;
        for (int i = 1; i < n; i++) {
            /* arr1[i] 左侧的元素不进行替换 */
            if (arr1[i - 1] < arr1[i]) {
                dp[i] = Math.Min(dp[i], dp[i - 1]);
            }
            /* 替换 arr1[i] 左边的连续 j 个元素 */
            for (int j = 1; j < i; j++) { 
                /* arr2 的最优替换的起点为大于 arr1[i - j - 1] 的最小元素 */
                int k = BinarySearch(list, arr1[i - j - 1]);
                /* arr2 的最优替换的终点必须满足小于 arr1[i] */
                if (k + j - 1 < m && list[k + j - 1] < arr1[i]) {
                    dp[i] = Math.Min(dp[i], dp[i - j - 1] + j);
                }
            }
            
        }
        return dp[n - 1] == INF ? -1 : dp[n - 1];
    }

    public int BinarySearch(IList<int> list, int target) {
        int low = 0, high = list.Count;
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

int makeArrayIncreasing(int* arr1, int arr1Size, int* arr2, int arr2Size) {
    int n = arr1Size + 2;
    int arr[n];
    memcpy(arr + 1, arr1, sizeof(int) * arr1Size);
    arr1 = arr;
    /* 左侧哨兵 -1 */
    arr1[0] = -1; 
    /* 右侧哨兵 */
    arr1[arr1Size + 1] = INF; 
    qsort(arr2, arr2Size, sizeof(int), cmp);
    int m = 0;
    for (int i = 0, j = 0; i < arr2Size; i++) {
        if (i == 0 || arr2[i] != arr2[i - 1]) {
            arr2[m++] = arr2[i];
        }
    }
    
    int dp[n];
    memset(dp, 0x3f, sizeof(dp));
    dp[0] = 0;
    for (int i = 1; i < n; i++) {
        /* arr1[i] 左侧的元素不进行替换 */
        if (arr1[i - 1] < arr1[i]) {
            dp[i] = MIN(dp[i], dp[i - 1]);
        }
        /* 替换 arr1[i] 左边的连续 j 个元素 */
        for (int j = 1; j < i; j++) { 
            /* arr2 的最优替换的起点为大于 arr1[i - j - 1] 的最小元素 */
            int k = binarySearch(arr2, 0, m - 1, arr1[i - j - 1]);
            /* arr2 的最优替换的终点必须满足小于 arr1[i] */
            if (k + j - 1 < m && arr2[k + j - 1] < arr1[i]) {
                dp[i] = MIN(dp[i], dp[i - j - 1] + j);
            }
        }
    }
    return dp[n - 1] == INF ? -1 : dp[n - 1];
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
    const temp = new Array(arr1.length + 2).fill(0);
    temp.splice(1, arr1.length, ...arr1);
    /* 右侧哨兵 inf */
    temp[arr1.length + 1] = INF;
    /* 左侧哨兵 -1 */
    temp[0] = -1;
    arr1 = temp;
    const n = arr1.length;
    const m = list.length;

    const dp = new Array(n).fill(INF);
    dp[0] = 0;
    for (let i = 1; i < n; i++) {
        /* arr1[i] 左侧的元素不进行替换 */
        if (arr1[i - 1] < arr1[i]) {
            dp[i] = Math.min(dp[i], dp[i - 1]);
        }
        /* 替换 arr1[i] 左边的连续 j 个元素 */
        for (let j = 1; j < i; j++) {
            /* arr2 的最优替换的起点为大于 arr1[i - j - 1] 的最小元素 */
            const k = binarySearch(list, arr1[i - j - 1]);
            /* arr2 的最优替换的终点必须满足小于 arr1[i] */
            if (k + j - 1 < m && list[k + j - 1] < arr1[i]) {
                dp[i] = Math.min(dp[i], dp[i - j - 1] + j);
            }
        }

    }
    return dp[n - 1] === INF ? -1 : dp[n - 1];
}

const binarySearch = (list, target) => {
    let low = 0, high = list.length;
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

上述方法我们可以进行进一步优化，首先可以利用二分查找找到替换元素的右侧终点，利用二分查找找到严格小于 $arr1[i]$ 的最大元素 $arr_2[k]$，然后从 $k$ 起始依次向前枚举连续替换元素的个数 $j$，即 $[arr_1[i-j],arr_1[i-j+1],\cdots,arr_1[i-1]]$ 连续 $j$ 个元素被替换，此时只需要检测 $arr_2[k-j] > arr_1[i-j-1]$ 即可，时间复杂度可以进一步优化。

```cpp
constexpr int INF = 0x3f3f3f3f;

class Solution {
public:
    int makeArrayIncreasing(vector<int>& arr1, vector<int>& arr2) {
        sort(arr2.begin(), arr2.end());
        arr2.erase(unique(arr2.begin(), arr2.end()), arr2.end());
        /* 右侧哨兵 inf */
        arr1.push_back(INF); 
        /* 左侧哨兵 -1 */
        arr1.insert(arr1.begin(), -1); 
        int n = arr1.size();
        int m = arr2.size();

        vector<int> dp(n, INF);
        dp[0] = 0;
        for (int i = 1; i < n; i++) {
            /* arr1[i] 左侧的元素不进行替换 */
            if (arr1[i - 1] < arr1[i]) {
                dp[i] = min(dp[i], dp[i - 1]);
            }
            /* 固定替换元素的右侧终点 */
            int k = lower_bound(arr2.begin(), arr2.end(), arr1[i]) - arr2.begin();
            /* 枚举从 i 左侧连续替换元素的个数 */
            for (int j = 1; j <= min(i - 1, k); ++j) {
                /* 替换的连续 j 个元素的左侧起点需满足大于 arr1[i - j - 1] */ 
                if (arr1[i - j - 1] < arr2[k - j]) {
                    dp[i] = min(dp[i], dp[i - j - 1] + j);
                }
            }
        }
        return dp[n - 1] == INF ? -1 : dp[n - 1];
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
        int[] temp = new int[arr1.length + 2];
        System.arraycopy(arr1, 0, temp, 1, arr1.length);
        /* 右侧哨兵 inf */
        temp[arr1.length + 1] = INF;
        /* 左侧哨兵 -1 */
        temp[0] = -1;
        arr1 = temp;
        int n = arr1.length;
        int m = list.size();

        int[] dp = new int[n];
        Arrays.fill(dp, INF);
        dp[0] = 0;
        for (int i = 1; i < n; i++) {
            /* arr1[i] 左侧的元素不进行替换 */
            if (arr1[i - 1] < arr1[i]) {
                dp[i] = Math.min(dp[i], dp[i - 1]);
            }
            /* 固定替换元素的右侧终点 */
            int k = binarySearch(list, arr1[i]);
            /* 枚举从 i 左侧连续替换元素的个数 */
            for (int j = 1; j <= Math.min(i - 1, k); ++j) {
                /* 替换的连续 j 个元素的左侧起点需满足大于 arr1[i - j - 1] */ 
                if (arr1[i - j - 1] < list.get(k - j)) {
                    dp[i] = Math.min(dp[i], dp[i - j - 1] + j);
                }
            }
        }
        return dp[n - 1] == INF ? -1 : dp[n - 1];
    }

    public int binarySearch(List<Integer> list, int target) {
        int low = 0, high = list.size();
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (list.get(mid) >= target) {
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
        int[] temp = new int[arr1.Length + 2];
        Array.Copy(arr1, 0, temp, 1, arr1.Length);
        /* 右侧哨兵 inf */
        temp[arr1.Length + 1] = INF;
        /* 左侧哨兵 -1 */
        temp[0] = -1;
        arr1 = temp;
        int n = arr1.Length;
        int m = list.Count;

        int[] dp = new int[n];
        Array.Fill(dp, INF);
        dp[0] = 0;
        for (int i = 1; i < n; i++) {
            /* arr1[i] 左侧的元素不进行替换 */
            if (arr1[i - 1] < arr1[i]) {
                dp[i] = Math.Min(dp[i], dp[i - 1]);
            }
            /* 固定替换元素的右侧终点 */
            int k = BinarySearch(list, arr1[i]);
            /* 枚举从 i 左侧连续替换元素的个数 */
            for (int j = 1; j <= Math.Min(i - 1, k); ++j) {
                /* 替换的连续 j 个元素的左侧起点需满足大于 arr1[i - j - 1] */ 
                if (arr1[i - j - 1] < list[k - j]) {
                    dp[i] = Math.Min(dp[i], dp[i - j - 1] + j);
                }
            }
        }
        return dp[n - 1] == INF ? -1 : dp[n - 1];
    }

    public int BinarySearch(IList<int> list, int target) {
        int low = 0, high = list.Count;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (list[mid] >= target) {
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
#define MIN(a, b) ((a) < (b) ? (a) : (b))

const int INF = 0x3f3f3f3f;

static int cmp(const void *pa, const void *pb) {
    return *(int *)pa - *(int *)pb;
}

int binarySearch(int *arr, int left, int right, int val) {
    int ret = right + 1;
    while (left <= right) {
        int mid = left + (right - left) / 2;
        if (arr[mid] >= val) {
            ret = mid;
            right = mid - 1;
        } else {
            left = mid + 1;
        }
    }
    return ret;
}

int makeArrayIncreasing(int* arr1, int arr1Size, int* arr2, int arr2Size) {
    int n = arr1Size + 2;
    int arr[n];
    memcpy(arr + 1, arr1, sizeof(int) * arr1Size);
    arr1 = arr;
    arr1[0] = -1;
    arr1[arr1Size + 1] = INF;
    qsort(arr2, arr2Size, sizeof(int), cmp);
    int m = 0;
    for (int i = 0, j = 0; i < arr2Size; i++) {
        if (i == 0 || arr2[i] != arr2[i - 1]) {
            arr2[m++] = arr2[i];
        }
    }
    
    int dp[n];
    memset(dp, 0x3f, sizeof(dp));
    dp[0] = 0;
    for (int i = 1; i < n; i++) {
        /* arr1[i] 左侧的元素不进行替换 */
        if (arr1[i - 1] < arr1[i]) {
            dp[i] = MIN(dp[i], dp[i-1]);
        }
        /* 固定替换元素的右侧终点 */
        int k = binarySearch(arr2, 0, m - 1, arr1[i]);
        /* 枚举从 i 左侧连续替换元素的个数 */
        for (int j = 1; j <= MIN(i - 1, k); ++j) {
            /* 替换的连续 j 个元素的左侧起点需满足大于 arr1[i - j - 1] */ 
            if (arr1[i - j - 1] < arr2[k - j]) {
                dp[i] = MIN(dp[i], dp[i - j - 1] + j);
            }
        }
    }
    return dp[n - 1] == INF ? -1 : dp[n - 1];
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
    const temp = new Array(arr1.length + 2).fill(0);
    temp.splice(1, arr1.length, ...arr1);
    /* 右侧哨兵 inf */
    temp[arr1.length + 1] = INF;
    /* 左侧哨兵 -1 */
    temp[0] = -1;
    arr1 = temp;
    const n = arr1.length;
    const m = list.length;

    const dp = new Array(n).fill(INF);
    dp[0] = 0;
    for (let i = 1; i < n; i++) {
        /* arr1[i] 左侧的元素不进行替换 */
        if (arr1[i - 1] < arr1[i]) {
            dp[i] = Math.min(dp[i], dp[i - 1]);
        }
        /* 固定替换元素的右侧终点 */
        const k = binarySearch(list, arr1[i]);
        /* 枚举从 i 左侧连续替换元素的个数 */
        for (let j = 1; j <= Math.min(i - 1, k); ++j) {
            /* 替换的连续 j 个元素的左侧起点需满足大于 arr1[i - j - 1] */
            if (arr1[i - j - 1] < list[k - j]) {
                dp[i] = Math.min(dp[i], dp[i - j - 1] + j);
            }
        }
    }
    return dp[n - 1] === INF ? -1 : dp[n - 1];
}

const binarySearch = (list, target) => {
    let low = 0, high = list.length;
    while (low < high) {
        const mid = low + Math.floor((high - low) / 2);
        if (list[mid] >= target) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
};
```

**复杂度分析**

-   时间复杂度：$O(n \times (\log m + \min(m,n)))$，其中 $n$ 表示数组 $arr_1$ 的长度，$m$ 表示数组 $arr_2$ 的长度。每次对 $i$ 之前的元素替换时，我们都需利用二分查找找到 $arr_2$ 中子数组右侧的终点，需要的时间复杂度为 $O(\log m)$，然后依次枚举子数组的起点，一共最多需要枚举 $\min(m,n)$ 次，因此总的时间复杂度为 $O(n \times (\log m + \min(m,n)))$。
-   空间复杂度：$O(n)$，其中 $n$ 表示数组的长度。根据题目定义最多只有 $n$ 个状态，因此需要的空间为 $O(n)$。
