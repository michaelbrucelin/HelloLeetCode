#### 方法一：动态规划

**思路与算法**

本题目为经典问题，本题中我们可以将水龙头的覆盖区域看做为一个小区间，本题即转换为求选择最少的区间数目可以覆盖连续区间 $[0,n]$。在力扣平台中有一些类似的题目，本质也是上述的模型，例如「[45\. 跳跃游戏 II](https://leetcode.cn/problems/jump-game-ii/)」和「[1024\. 视频拼接](https://leetcode.cn/problems/video-stitching/)」。

对于位置为 $i$ 的水龙头，已知它可以灌溉的区间为 $[i - ranges[i], i + ranges[i]]$。由于整个花园的区间为 $[0, n]$，我们将灌溉的区间约束在 $[0, n]$ 的范围内即可，超出的区间范围可以丢弃掉。我们将约束后的区间记为 $[start_i, end_i]$，即：
$$start_i = \max(i - ranges[i], 0) \\ end_i = \min(i + ranges[i], n) \\$$

那么我们需要在 $[start_0, end_0], [start_1, end_1], ..., [start_n, end_n]$ 中选出最少数目的区间，使得它们可以覆盖 $[0, n]$。

我们设 $dp[i]$ 表示覆盖区间 $[0,i]$ 所需要的最少的区间数目，那么如何进行状态转移呢？我们假设当前第 $j$ 个区间 $[start_j, end_j]$ 覆盖了区间 $[0,i]$ 的最右边的部分区域 $[start_j, i]$，即此时满足 $start_j \le i \le end_j$。假设我们选择了区间 $[start_j, end_j]$，此时我们只需知道区间 $[0,start_j]$ 区间的最少覆盖数目即可得到递推公式 $dp[i] = \min(dp[i], 1 + dp[start_j])$。自然想到将所有的区间按照从左到右进行排序，当我们遍历当前子区间 $[start_j, end_j]$ 时，从而保证区间的左侧 $[0,start_j]$ 的最终状态已经全部计算出来，此时我们即可利用上述的状态转移方程。

假设当前新加入的区间为 $[start_j, end_j]$，此时我们需要更新计算状态 $dp[start_j + 1],dp[start_j + 2],dp[start_j + \cdots], dp[end_j]$，此时 $dp[k] = \min(dp[k], dp[start_j] + 1),k\in[start_j, end_j]$。根据上述递推公式我们最终计算出 $dp[n]$ 即可得到区间 $[0,n]$ 的最小覆盖数目。

最后，我们还需要考虑不合法的情况。我们可以用 $⁡dp[i] = \inf$ 表示花园子区间 $[0, i]$ 无法被覆盖，其中 $\inf$ 表示一个很大的整数。在进行状态转移时，如果 $dp[start_j] = \inf$，则表示花园子区间 $[0,start_j]$ 无法完成覆盖，此时我们直接返回 $-1$。

**代码**

```python
class Solution:
    def minTaps(self, n: int, ranges: List[int]) -> int:
        intervals = []
        for i, r in enumerate(ranges):
            start = max(0, i - r)
            end = min(n, i + r)
            intervals.append((start, end))
        intervals.sort()

        dp = [inf] * (n + 1)
        dp[0] = 0
        for start, end in intervals:
            if dp[start] == inf:
                return -1
            for j in range(start, end + 1):
                dp[j] = min(dp[j], dp[start] + 1)
        return dp[n]
```

```cpp
class Solution {
public:
    int minTaps(int n, vector<int>& ranges) {
        vector<pair<int, int>> intervals;
        for (int i = 0; i <= n; i++) {
            int start = max(0, i - ranges[i]);
            int end = min(n, i + ranges[i]);
            intervals.emplace_back(start, end);
        }
        sort(intervals.begin(), intervals.end());
        vector<int> dp(n + 1, INT_MAX);
        dp[0] = 0;
        for (auto [start, end] : intervals) {
            if (dp[start] == INT_MAX) {
                return -1;
            }
            for (int j = start; j <= end; j++) {
                dp[j] = min(dp[j], dp[start] + 1);
            }
        }
        return dp[n];
    }
};
```

```java
class Solution {
    public int minTaps(int n, int[] ranges) {
        int[][] intervals = new int[n + 1][];
        for (int i = 0; i <= n; i++) {
            int start = Math.max(0, i - ranges[i]);
            int end = Math.min(n, i + ranges[i]);
            intervals[i] = new int[]{start, end};
        }
        Arrays.sort(intervals, (a, b) -> a[0] - b[0]);
        int[] dp = new int[n + 1];
        Arrays.fill(dp, Integer.MAX_VALUE);
        dp[0] = 0;
        for (int[] interval : intervals) {
            int start = interval[0], end = interval[1];
            if (dp[start] == Integer.MAX_VALUE) {
                return -1;
            }
            for (int j = start; j <= end; j++) {
                dp[j] = Math.min(dp[j], dp[start] + 1);
            }
        }
        return dp[n];
    }
}
```

```csharp
public class Solution {
    public int MinTaps(int n, int[] ranges) {
        int[][] intervals = new int[n + 1][];
        for (int i = 0; i <= n; i++) {
            int start = Math.Max(0, i - ranges[i]);
            int end = Math.Min(n, i + ranges[i]);
            intervals[i] = new int[]{start, end};
        }
        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        int[] dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;
        foreach (int[] interval in intervals) {
            int start = interval[0], end = interval[1];
            if (dp[start] == int.MaxValue) {
                return -1;
            }
            for (int j = start; j <= end; j++) {
                dp[j] = Math.Min(dp[j], dp[start] + 1);
            }
        }
        return dp[n];
    }
}
```

```c
#define MIN(a, b) ((a) < (b) ? (a) : (b))
#define MAX(a, b) ((a) > (b) ? (a) : (b))

const int INF = 0x3f3f3f3f;

static int cmp(const void *pa, const void *pb) {
    int la = ((int *)pa)[0], ra = ((int *)pa)[1];
    int lb = ((int *)pb)[0], rb = ((int *)pb)[1];
    if (la == lb) {
        return ra - rb;
    }
    return la - lb;
}

int minTaps(int n, int* ranges, int rangesSize) {
    int seglines[n + 1][2];
    for (int i = 0; i <= n; i++) {
        seglines[i][0] = MAX(0, i - ranges[i]);
        seglines[i][1] = MIN(n, i + ranges[i]);
    }
    qsort(seglines, n + 1, sizeof(seglines[0]), cmp);
    int dp[n + 1];
    memset(dp, 0x3f, sizeof(dp));
    dp[0] = 0;
    for (int i = 0; i <= n; i++) {
        int start = seglines[i][0];
        int end = seglines[i][1];
        if (dp[start] == INF) {
            return -1;
        }
        for (int j = start; j <= end; j++) {
            dp[j] = MIN(dp[j], dp[start] + 1);
        }
    }
    return dp[n];
}
```

```javascript
var minTaps = function(n, ranges) {
    const intervals = new Array(n + 1).fill(new Array());
    for (let i = 0; i <= n; i++) {
        const start = Math.max(0, i - ranges[i]);
        const end = Math.min(n, i + ranges[i]);
        intervals[i] = [start, end];
    }
    intervals.sort((a, b) => a[0] - b[0]);
    const dp = new Array(n + 1).fill(Number.MAX_VALUE);
    dp[0] = 0;
    for (const interval of intervals) {
        let start = interval[0], end = interval[1];
        if (dp[start] === Number.MAX_VALUE) {
            return -1;
        }
        for (let j = start; j <= end; j++) {
            dp[j] = Math.min(dp[j], dp[start] + 1);
        }
    }
    return dp[n];
};
```

```go
func minTaps(n int, ranges []int) int {
    intervals := [][2]int{}
    for i, r := range ranges {
        start := max(0, i-r)
        end := min(n, i+r)
        intervals = append(intervals, [2]int{start, end})
    }
    sort.Slice(intervals, func(i, j int) bool {
        a, b := intervals[i], intervals[j]
        return a[0] < b[0]
    })

    dp := make([]int, n+1)
    for i := range dp {
        dp[i] = math.MaxInt
    }
    dp[0] = 0
    for _, p := range intervals {
        start, end := p[0], p[1]
        if dp[start] == math.MaxInt {
            return -1
        }
        for j := start; j <= end; j++ {
            dp[j] = min(dp[j], dp[start]+1)
        }
    }
    return dp[n]
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}

func max(a, b int) int {
    if b > a {
        return b
    }
    return a
}
```

**复杂度分析**

-   时间复杂度：$O(n \times (\log n + \max(ranges)))$，其中 $n$ 表示给定的数字 $n$，$\max⁡(ranges)$ 表示数组 $ranges$ 中的最大元素。对所有的线段进行排序需要的时间为 $O(n \log n)$；求线段中的每个点的左侧最小覆盖数目需要的时间为 $O(\max(ranges))$，一共有 $n+1$ 个线段，因此需要的总的时间复杂度为 $O(n \times (\log n + \max(ranges)))$。
-   空间复杂度：$O(n)$，其中 $n$ 表示给定的数字 $n$。我们需要保存每个线段的起始位置，需要的空间的为 $O(n)$，线段排序需要的空间为 $O(\log n)$，保存每个位置左侧的最小覆盖数目需要的空间为 $O(n)$，因此总的空间复杂度为 $O(n)$。
