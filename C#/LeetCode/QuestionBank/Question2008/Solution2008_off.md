### [出租车的最大盈利](https://leetcode.cn/problems/maximum-earnings-from-taxi/solutions/2555814/chu-zu-che-de-zui-da-ying-li-by-leetcode-ol41/)

#### 方法一：动态规划 + 二分查找

将 $rides$ 按照 $end_i$ 从小到大进行排序，记 $m$ 为 $rides$ 的大小，$dp_{i+1}$ 表示只接区间 $[0, i]$ 内的乘客的最大盈利，显然 $dp_0 = 0$，而对于 $i \in [0, m]$，有两种情况：

1.  对第 $i$ 位乘客接单，由于前面已经对 $rides$ 进行排序，因此我们可以通过二分查找来找到满足 $end_j \le start_i$ 最大的 $j$，那么 $dp_{i + 1} = dp_j + end_i - start_i + tip_i$。
2.  对第 $i$ 位乘客不接单，那么有 $dp_{i + 1} = dp_i$。

根据以上情况，对于 $i \in [0, m]$，有转移方程为：

$$dp_{i + 1} = \max (dp_i, dp_j + end_i - start_i + tip_i)$$

其中 $j$ 为满足 $end_j \le start_i$ 最大的 $j$，那么 $dp[m]$ 即为结果。

```cpp
class Solution {
public:
    long long maxTaxiEarnings(int n, vector<vector<int>>& rides) {
        sort(rides.begin(), rides.end(), [&](const vector<int> &r1, const vector<int> &r2) -> bool {
            return r1[1] < r2[1];
        });
        int m = rides.size();
        vector<long long> dp(m + 1);
        for (int i = 0; i < m; i++) {
            int j = upper_bound(rides.begin(), rides.begin() + i, rides[i][0], [](int x, const vector<int> &r) -> bool {
                return x < r[1];
            }) - rides.begin();
            dp[i + 1] = max(dp[i], dp[j] + rides[i][1] - rides[i][0] + rides[i][2]);
        }
        return dp[m];
    }
};
```

```java
class Solution {
    public long maxTaxiEarnings(int n, int[][] rides) {
        Arrays.sort(rides, (a, b) -> a[1] - b[1]);
        int m = rides.length;
        long[] dp = new long[m + 1];
        for (int i = 0; i < m; i++) {
            int j = binarySearch(rides, i, rides[i][0]);
            dp[i + 1] = Math.max(dp[i], dp[j] + rides[i][1] - rides[i][0] + rides[i][2]);
        }
        return dp[m];
    }

    public int binarySearch(int[][] rides, int high, int target) {
        int low = 0;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (rides[mid][1] > target) {
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
    public long MaxTaxiEarnings(int n, int[][] rides) {
        Array.Sort(rides, (a, b) => a[1] - b[1]);
        int m = rides.Length;
        long[] dp = new long[m + 1];
        for (int i = 0; i < m; i++) {
            int j = BinarySearch(rides, i, rides[i][0]);
            dp[i + 1] = Math.Max(dp[i], dp[j] + rides[i][1] - rides[i][0] + rides[i][2]);
        }
        return dp[m];
    }

    public int BinarySearch(int[][] rides, int high, int target) {
        int low = 0;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (rides[mid][1] > target) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}
```

```go
func maxTaxiEarnings(n int, rides [][]int) int64 {
    sort.Slice(rides, func(i, j int) bool {
        return rides[i][1] < rides[j][1]
    })
    m := len(rides)
    dp := make([]int64, m + 1)
    for i := 0; i < m; i++ {
        j := sort.Search(i + 1, func(k int) bool {
            return rides[k][1] > rides[i][0]
        })
        dp[i + 1] = max(dp[i], dp[j] + int64(rides[i][1] - rides[i][0] + rides[i][2]))
    }
    return dp[m]
}
```

```python
class Solution:
    def maxTaxiEarnings(self, n: int, rides: List[List[int]]) -> int:
        rides.sort(key=lambda r: r[1])
        m = len(rides)
        dp = [0] * (m + 1)
        for i in range(m):
            j = bisect_right(rides, rides[i][0], hi=i, key=lambda r:r[1])
            dp[i + 1] = max(dp[i], dp[j] + rides[i][1] - rides[i][0] + rides[i][2])
        return dp[m]
```

```c
static int cmp(const void *a, const void *b) {
    return (*(int **)a)[1] - (*(int **)b)[1];
}

int binarySearch(int **rides, int high, int target) {
    int low = 0;
    while (low < high) {
        int mid = low + (high - low) / 2;
        if (rides[mid][1] > target) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}

long long maxTaxiEarnings(int n, int** rides, int ridesSize, int* ridesColSize) {
    qsort(rides, ridesSize, sizeof(rides[0]), cmp);
    int m = ridesSize;
    long long dp[m + 1];
    memset(dp, 0, sizeof(dp));
    for (int i = 0; i < m; i++) {
        int j = binarySearch(rides, i, rides[i][0]);
        dp[i + 1] = fmax(dp[i], dp[j] + rides[i][1] - rides[i][0] + rides[i][2]);
    }
    return dp[m];
}
```

```javascript
const binarySearch = function(arr, high, target) {
    let low = 0;
    while (low < high) {
        let mid = low + Math.floor((high - low) / 2);
        if (arr[mid][1] > target) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}

var maxTaxiEarnings = function(n, rides) {
    rides.sort((a, b) => a[1] - b[1]);
    const m = rides.length;
    const dp = new Array(m + 1).fill(0);
    for (let i = 0; i < m; i++) {
        let j = binarySearch(rides, i, rides[i][0]);
        dp[i + 1] = Math.max(dp[i], dp[j] + rides[i][1] - rides[i][0] + rides[i][2]);
    }
    return dp[m];
};
```

**复杂度分析**

-   时间复杂度：$O(m \log m)$，其中 $m$ 是 $rides$ 的长度。二分查找需要 $O(\log m)$，总共执行 $m$ 次二分查找。
-   空间复杂度：$O(m)$。动态规划需要保存 $O(m)$ 个状态。

#### 方法二：动态规划 + 哈希表

使用哈希表 $rideMap[end]$ 记录终点为 $end$ 的所有乘客信息。不同于方法一，我们使用 $dp_{i}$ 表示到达第 $i$ 个地点时，能获取的最大盈利，显然有 $dp_0 = 0$，而对于 $i \in [1, n]$，有两种情况：

1.  选择一个终点为第 $i$ 个地点的乘客 $j$，那么最大盈利为 $dp_i = dp_{start_j} + end_j - start_j + tip_j$。
2.  没有乘客在第 $i$ 个地点下车，那么 $dp_i = dp_{i - 1}$。

根据以上情况，对于 $i \in [1, n]$，有转移方程为：

$$dp_i = \max(dp_{i - 1}, \max_{j \in T_i}(dp_{start_j} + end_j - start_j + tip_j))$$

其中 $T_i$ 表示终点为第 $i$ 个地点的所有乘客，此时 $dp[n]$ 即为结果。

```cpp
class Solution {
public:
    long long maxTaxiEarnings(int n, vector<vector<int>> &rides) {
        vector<long long> dp(n + 1);
        unordered_map<int, vector<vector<int>>> rideMap;
        for (const auto &ride : rides) {
            rideMap[ride[1]].push_back(ride);
        }
        for (int i = 1; i <= n; i++) {
            dp[i] = dp[i - 1];
            for (const auto &ride : rideMap[i]) {
                dp[i] = max(dp[i], dp[ride[0]] + ride[1] - ride[0] + ride[2]);
            }
        }
        return dp[n];
    }
};
```

```java
class Solution {
    public long maxTaxiEarnings(int n, int[][] rides) {
        long[] dp = new long[n + 1];
        Map<Integer, List<int[]>> rideMap = new HashMap<Integer, List<int[]>>();
        for (int[] ride : rides) {
            rideMap.putIfAbsent(ride[1], new ArrayList<int[]>());
            rideMap.get(ride[1]).add(ride);
        }
        for (int i = 1; i <= n; i++) {
            dp[i] = dp[i - 1];
            for (int[] ride : rideMap.getOrDefault(i, new ArrayList<int[]>())) {
                dp[i] = Math.max(dp[i], dp[ride[0]] + ride[1] - ride[0] + ride[2]);
            }
        }
        return dp[n];
    }
}
```

```csharp
public class Solution {
    public long MaxTaxiEarnings(int n, int[][] rides) {
        long[] dp = new long[n + 1];
        IDictionary<int, IList<int[]>> rideDictionary = new Dictionary<int, IList<int[]>>();
        foreach (int[] ride in rides) {
            rideDictionary.TryAdd(ride[1], new List<int[]>());
            rideDictionary[ride[1]].Add(ride);
        }
        for (int i = 1; i <= n; i++) {
            dp[i] = dp[i - 1];
            IList<int[]> list = rideDictionary.ContainsKey(i) ? rideDictionary[i] : new List<int[]>();
            foreach (int[] ride in list) {
                dp[i] = Math.Max(dp[i], dp[ride[0]] + ride[1] - ride[0] + ride[2]);
            }
        }
        return dp[n];
    }
}
```

```go
func maxTaxiEarnings(n int, rides [][]int) int64 {
    dp := make([]int64, n + 1)
    rideMap := map[int][][]int{}
    for _, ride := range rides {
        rideMap[ride[1]] = append(rideMap[ride[1]], ride)
    }
    for i := 1; i <= n; i++ {
        dp[i] = dp[i - 1]
        for _, ride := range rideMap[i] {
            dp[i] = max(dp[i], dp[ride[0]] + int64(ride[1] - ride[0] + ride[2]))
        }
    }
    return dp[n]
}
```

```python
class Solution:
    def maxTaxiEarnings(self, n: int, rides: List[List[int]]) -> int:
        dp = [0] * (n + 1)
        rideMap = {}
        for ride in rides:
            if ride[1] not in rideMap:
                rideMap[ride[1]] = []
            rideMap[ride[1]].append(ride)
        for i in range(1, n + 1):
            dp[i] = dp[i - 1]
            if i not in rideMap:
                continue
            for ride in rideMap[i]:
                dp[i] = max(dp[i], dp[ride[0]] + ride[1] - ride[0] + ride[2])
        return dp[n]
```

```c
typedef struct Node {
    int *arr;
    struct Node *next;
} Node;

Node *creatNode(int *val) {
    Node *obj = (Node *)malloc(sizeof(Node));
    obj->arr = val;
    obj->next = NULL;
    return obj;
}

void freeList(Node *list) {
    while (list) {
        Node *cur = list;
        list = list->next;
    }
    free(list);
}


long long maxTaxiEarnings(int n, int** rides, int ridesSize, int* ridesColSize) {
    long long dp[n + 1];
    Node *rideMap[n + 1];
    memset(dp, 0, sizeof(dp));
    memset(rideMap, 0, sizeof(rideMap));
    for (int i = 0; i < ridesSize; i++) {
        int *ride = rides[i];
        Node *node = creatNode(ride);
        node->next = rideMap[ride[1]];
        rideMap[ride[1]] = node;
    }
    for (int i = 1; i <= n; i++) {
        dp[i] = dp[i - 1];
        for (Node *node = rideMap[i]; node; node = node->next) {
            int *ride = node->arr;
            dp[i] = fmax(dp[i], dp[ride[0]] + ride[1] - ride[0] + ride[2]);
        }
    }
    for (int i = 0; i <= n; i++) {
        freeList(rideMap[i]);
    }
    return dp[n];
}
```

```javascript
var maxTaxiEarnings = function(n, rides) {
    const dp = new Array(n + 1).fill(0);
    const rideMap = new Map();
    for (const ride of rides) {
        if (rideMap.has(ride[1])) {
            rideMap.set(ride[1], [...rideMap.get(ride[1]), ride])
        } else {
            rideMap.set(ride[1], [ride]);
        }
    }
    for (let i = 1; i <= n; i++) {
        dp[i] = dp[i - 1];
        if (rideMap.has(i)) {
            for (const ride of rideMap.get(i)) {
                dp[i] = Math.max(dp[i], dp[ride[0]] + ride[1] - ride[0] + ride[2]);
            }
        }
    }
    return dp[n];
};
```

**复杂度分析**

-   时间复杂度：$O(m + n)$，其中 $m$ 是 $rides$ 的长度，$n$ 是地点数目。动态规划转移需要 $O(n)$ 的时间，查询乘客信息需要 $O(m)$ 的时间。
-   空间复杂度：$O(m + n)$。动态规划需要保存 $n$ 个状态，哈希表需要保存 $m$ 个乘客信息。
