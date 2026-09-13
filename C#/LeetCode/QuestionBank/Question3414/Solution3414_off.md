### [不重叠区间的最大得分](https://leetcode.cn/problems/maximum-score-of-non-overlapping-intervals/solutions/4022619/bu-zhong-die-qu-jian-de-zui-da-de-fen-by-nn4g/)

#### 方法一：动态规划 + 二分查找

**思路与算法**

本题与「[1751\. 最多可以选择的区间数目 II](https://leetcode.cn/problems/maximum-number-of-events-that-can-be-attended-ii/description/)」基本类似，唯一不同的是该题在 $1751$ 题的基础上要求计算下标的字典序最小的选择方案。由于本题最多只能选择 $4$ 个不重叠的区间，因此等价于 $1751$ 题中取 $k=4$ 的情况。

选择第 $i$ 个区间的得分为 $weight_i$，题目要求选择至多包含 $4$ 个**互不重叠**且满足**得分最大**、**字典序最小**的区间。由于题目要求选择的区间**互不重叠**，本质即为**背包问题**，因此我们可以使用动态规划来解决该问题。

首先需要对所有区间 $intervals$ 按照右终点大小顺序进行排序。定义 $dp[i][j]$ 表示在前 $i$ 个区间中**至多**选择 $j$ 个不重叠区间的最大得分和，其中 $i$ 的范围是 $[0,n]$，j 的范围是 $[0,4]$。同时使用 $indices[i][j]$ 记录对应的下标集合，用于在权重相等时比较字典序。此时可以得到递推公式如下：

- 如果第 $i$ 个区间不选择，此时前 $i$ 个区间选择 $j$ 个**互不重叠**的区间最大得分即等于前 $i-1$ 个区间选择 $j$ 个**互不重叠**的区间最大得分，此时得到递推公式：
    $$dp[i][j]=dp[i-1][j]$$
- 如果第 $i$ 个区间选择，此时可以在 $[1,l_i)$ 区间范围内选择 $j-1$ 个**互不重叠**的区间，此时第 $i$ 个区间 $[l_i,ri]$ 被选中，假设在区间范围 $[1,l_i)$ 有 $p$ 个区间可以选择，此时可以得到递推公式：
    $$dp[i][j]=dp[p][j-1]+weight_i$$
- 综上，我们可以得到递推公式：
    $$dp[i][j]=max(dp[i-1][j], dp[p][j-1]+weight_i);$$

由于所有的区间均是按照右终点进行排序的，给定起点 $l_i$，可以通过**二分查找**找到右终点小于 $l_i$ 的区间数目。我们从小到大依次枚举 $(i,j)$，在计算子状态 $dp[i][j]$ 时，同时记录当前选择的区间下标集合 $indices[i][j]$。当两种选择的权重和相等时，需要选择字典序更小的下标集合。具体做法如下：

- 维护每个状态的索引列表；
- 当得分相等时，比较两个索引列表的字典序，选择字典序更小的那个；

枚举完成后，此时最大得分即为 $dp[n][4]$，下标数组即为 $indices[n][4]$。

**代码**

```C++
class Solution {
public:
    vector<int> maximumWeight(vector<vector<int>>& intervals) {
        int n = intervals.size();
        vector<tuple<int, int, int, int>> arr;
        for (int i = 0; i < n; i++) {
            int l = intervals[i][0], r = intervals[i][1], weight = intervals[i][2];
            arr.emplace_back(l, r, weight, i);
        }
        // 按照右端点大小进行排序
        sort(arr.begin(), arr.end(), [](auto &&a, auto &&b) {
            return get<1>(a) < get<1>(b);
        });

        vector<vector<long long>> dp(n + 1, vector<long long>(5));
        vector<vector<vector<int>>> indices(n + 1, vector<vector<int>>(5));
        for (int i = 0; i < n; i++) {
            auto [l, r, weight, idx] = arr[i];
            // 二分查找找到小于 l 的区间
            int k = lower_bound(arr.begin(), arr.begin() + i, l,
            [](const tuple<int, int, int, int>& t, int val) {
                return get<1>(t) < val;
            }) - arr.begin();

            for (int j = 1; j < 5; j++) {
                long long s1 = dp[i][j];
                long long s2 = dp[k][j - 1] + weight;
                if (s1 > s2) {
                    dp[i + 1][j] = dp[i][j];
                    indices[i + 1][j] = indices[i][j];
                    continue;
                }

                vector<int> newIndex = indices[k][j - 1];
                newIndex.push_back(idx);
                sort(newIndex.begin(), newIndex.end());
                if (s1 == s2 && indices[i][j] < newIndex) {
                    newIndex = indices[i][j];
                }
                dp[i + 1][j] = s2;
                indices[i + 1][j] = newIndex;
            }
        }

        return indices[n][4];
    }
};
```

```Java
class Solution {
    public int[] maximumWeight(List<List<Integer>> intervals) {
        int n = intervals.size();
        int[][] arr = new int[n][4];
        for (int i = 0; i < n; i++) {
            arr[i][0] = intervals.get(i).get(0);
            arr[i][1] = intervals.get(i).get(1);
            arr[i][2] = intervals.get(i).get(2);
            arr[i][3] = i;
        }
        // 按照右端点大小进行排序
        Arrays.sort(arr, (a, b) -> Integer.compare(a[1], b[1]));

        long[][] dp = new long[n + 1][5];
        List<Integer>[][] indices = new List[n + 1][5];
        for (int i = 0; i <= n; i++) {
            for (int j = 0; j < 5; j++) {
                indices[i][j] = new ArrayList<>();
            }
        }

        for (int i = 0; i < n; i++) {
            int l = arr[i][0], weight = arr[i][2], idx = arr[i][3];
            // 二分查找找到小于 l 的区间
            int k = binarySearch(arr, i, l);

            for (int j = 1; j < 5; j++) {
                long s1 = dp[i][j];
                long s2 = dp[k][j - 1] + weight;
                if (s1 > s2) {
                    dp[i + 1][j] = dp[i][j];
                    indices[i + 1][j] = new ArrayList<>(indices[i][j]);
                    continue;
                }

                List<Integer> newIndex = new ArrayList<>(indices[k][j - 1]);
                newIndex.add(idx);
                Collections.sort(newIndex);
                if (s1 == s2 && compareLists(indices[i][j], newIndex) < 0) {
                    newIndex = new ArrayList<>(indices[i][j]);
                }
                dp[i + 1][j] = s2;
                indices[i + 1][j] = newIndex;
            }
        }

        List<Integer> result = indices[n][4];
        int[] ans = new int[result.size()];
        for (int i = 0; i < result.size(); i++) {
            ans[i] = result.get(i);
        }
        return ans;
    }

    private int binarySearch(int[][] arr, int end, int target) {
        int left = 0, right = end;
        while (left < right) {
            int mid = (left + right) / 2;
            if (arr[mid][1] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }

    private int compareLists(List<Integer> a, List<Integer> b) {
        int minLen = Math.min(a.size(), b.size());
        for (int i = 0; i < minLen; i++) {
            if (!a.get(i).equals(b.get(i))) {
                return Integer.compare(a.get(i), b.get(i));
            }
        }
        return Integer.compare(a.size(), b.size());
    }
}
```

```CSharp
public class Solution {
    public int[] MaximumWeight(IList<IList<int>> intervals) {
        int n = intervals.Count;
        int[][] arr = new int[n][];
        for (int i = 0; i < n; i++) {
            arr[i] = new int[] { intervals[i][0], intervals[i][1], intervals[i][2], i };
        }
        // 按照右端点大小进行排序
        Array.Sort(arr, (a, b) => a[1].CompareTo(b[1]));

        long[][] dp = new long[n + 1][];
        List<int>[][] indices = new List<int>[n + 1][];
        for (int i = 0; i <= n; i++) {
            dp[i] = new long[5];
            indices[i] = new List<int>[5];
            for (int j = 0; j < 5; j++) {
                indices[i][j] = new List<int>();
            }
        }

        for (int i = 0; i < n; i++) {
            int l = arr[i][0], weight = arr[i][2], idx = arr[i][3];
            // 二分查找找到小于 l 的区间
            int k = BinarySearch(arr, i, l);

            for (int j = 1; j < 5; j++) {
                long s1 = dp[i][j];
                long s2 = dp[k][j - 1] + weight;
                if (s1 > s2) {
                    dp[i + 1][j] = dp[i][j];
                    indices[i + 1][j] = new List<int>(indices[i][j]);
                    continue;
                }

                List<int> newIndex = new List<int>(indices[k][j - 1]);
                newIndex.Add(idx);
                newIndex.Sort();
                if (s1 == s2 && CompareLists(indices[i][j], newIndex) < 0) {
                    newIndex = new List<int>(indices[i][j]);
                }
                dp[i + 1][j] = s2;
                indices[i + 1][j] = newIndex;
            }
        }

        return indices[n][4].ToArray();
    }

    private int BinarySearch(int[][] arr, int end, int target) {
        int left = 0, right = end;
        while (left < right) {
            int mid = (left + right) / 2;
            if (arr[mid][1] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }

    private int CompareLists(List<int> a, List<int> b) {
        int minLen = Math.Min(a.Count, b.Count);
        for (int i = 0; i < minLen; i++) {
            if (a[i] != b[i]) {
                return a[i].CompareTo(b[i]);
            }
        }
        return a.Count.CompareTo(b.Count);
    }
}
```

```Go
func maximumWeight(intervals [][]int) []int {
    n := len(intervals)
    type Interval struct {
        l, r, weight, idx int
    }
    arr := make([]Interval, n)
    for i := 0; i < n; i++ {
        arr[i] = Interval{intervals[i][0], intervals[i][1], intervals[i][2], i}
    }
    // 按照右端点大小进行排序
    sort.Slice(arr, func(i, j int) bool {
        return arr[i].r < arr[j].r
    })

    dp := make([][]int64, n+1)
    indices := make([][][]int, n+1)
    for i := 0; i <= n; i++ {
        dp[i] = make([]int64, 5)
        indices[i] = make([][]int, 5)
        for j := 0; j < 5; j++ {
            indices[i][j] = []int{}
        }
    }

    for i := 0; i < n; i++ {
        l, weight, idx := arr[i].l, arr[i].weight, arr[i].idx
        // 二分查找找到小于 l 的区间
        k := sort.Search(i, func(pos int) bool {
            return arr[pos].r >= l
        })

        for j := 1; j < 5; j++ {
            s1 := dp[i][j]
            s2 := dp[k][j-1] + int64(weight)
            if s1 > s2 {
                dp[i+1][j] = dp[i][j]
                indices[i+1][j] = append([]int{}, indices[i][j]...)
                continue
            }

            newIndex := append([]int{}, indices[k][j-1]...)
            newIndex = append(newIndex, idx)
            sort.Ints(newIndex)
            if s1 == s2 && compareSlices(indices[i][j], newIndex) < 0 {
                newIndex = append([]int{}, indices[i][j]...)
            }
            dp[i+1][j] = s2
            indices[i+1][j] = newIndex
        }
    }

    return indices[n][4]
}

func compareSlices(a, b []int) int {
    minLen := len(a)
    if len(b) < minLen {
        minLen = len(b)
    }
    for i := 0; i < minLen; i++ {
        if a[i] != b[i] {
            return a[i] - b[i]
        }
    }
    return len(a) - len(b)
}
```

```Python
class Solution:
    def maximumWeight(self, intervals: List[List[int]]) -> List[int]:
        n = len(intervals)
        arr = [(intervals[i][1], intervals[i][0], intervals[i][2], i) for i in range(n)]
        # 按照右端点大小进行排序
        arr.sort(key=lambda x: x[0])

        dp = [[0] * 5 for _ in range(n + 1)]
        indices = [[[] for _ in range(5)] for _ in range(n + 1)]

        for i in range(n):
            r, l, weight, idx = arr[i]
            # 二分查找找到右端点小于 l 的区间
            k = bisect_left(arr, (l,), hi=i)

            for j in range(1, 5):
                s1 = dp[i][j]
                s2 = dp[k][j - 1] + weight
                if s1 > s2:
                    dp[i + 1][j] = dp[i][j]
                    indices[i + 1][j] = indices[i][j].copy()
                    continue

                new_index = indices[k][j - 1].copy()
                new_index.append(idx)
                new_index.sort()
                if s1 == s2 and indices[i][j] < new_index:
                    new_index = indices[i][j].copy()
                dp[i + 1][j] = s2
                indices[i + 1][j] = new_index

        return indices[n][4]
```

```C
typedef struct {
    int l, r, weight, idx;
} Interval;

int compareInterval(const void* a, const void* b) {
    return ((Interval*)a)->r - ((Interval*)b)->r;
}

int compareInt(const void* a, const void* b) {
    return (*(int*)a) - (*(int*)b);
}

int binarySearch(Interval* arr, int end, int target) {
    int left = 0, right = end;
    while (left < right) {
        int mid = (left + right) / 2;
        if (arr[mid].r < target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

int compareArrays(int* a, int lenA, int* b, int lenB) {
    int minLen = lenA < lenB ? lenA : lenB;
    for (int i = 0; i < minLen; i++) {
        if (a[i] != b[i]) {
            return a[i] - b[i];
        }
    }
    return lenA - lenB;
}

int* maximumWeight(int** intervals, int intervalsSize, int* intervalsColSize, int* returnSize) {
    int n = intervalsSize;
    Interval* arr = (Interval*)malloc(n * sizeof(Interval));
    for (int i = 0; i < n; i++) {
        arr[i].l = intervals[i][0];
        arr[i].r = intervals[i][1];
        arr[i].weight = intervals[i][2];
        arr[i].idx = i;
    }
    // 按照右端点大小进行排序
    qsort(arr, n, sizeof(Interval), compareInterval);

    long long** dp = (long long**)malloc((n + 1) * sizeof(long long*));
    int*** indices = (int***)malloc((n + 1) * sizeof(int**));
    int** indicesSize = (int**)malloc((n + 1) * sizeof(int*));
    for (int i = 0; i <= n; i++) {
        dp[i] = (long long*)calloc(5, sizeof(long long));
        indices[i] = (int**)malloc(5 * sizeof(int*));
        indicesSize[i] = (int*)calloc(5, sizeof(int));
        for (int j = 0; j < 5; j++) {
            indices[i][j] = NULL;
        }
    }

    for (int i = 0; i < n; i++) {
        int l = arr[i].l, weight = arr[i].weight, idx = arr[i].idx;
        // 二分查找找到小于 l 的区间
        int k = binarySearch(arr, i, l);

        for (int j = 1; j < 5; j++) {
            long long s1 = dp[i][j];
            long long s2 = dp[k][j - 1] + weight;
            if (s1 > s2) {
                dp[i + 1][j] = dp[i][j];
                if (indices[i + 1][j]) free(indices[i + 1][j]);
                indices[i + 1][j] = (int*)malloc(indicesSize[i][j] * sizeof(int));
                memcpy(indices[i + 1][j], indices[i][j], indicesSize[i][j] * sizeof(int));
                indicesSize[i + 1][j] = indicesSize[i][j];
                continue;
            }

            int newSize = indicesSize[k][j - 1] + 1;
            int* newIndex = (int*)malloc(newSize * sizeof(int));
            if (indicesSize[k][j - 1] > 0) {
                memcpy(newIndex, indices[k][j - 1], indicesSize[k][j - 1] * sizeof(int));
            }
            newIndex[indicesSize[k][j - 1]] = idx;
            qsort(newIndex, newSize, sizeof(int), compareInt);

            if (s1 == s2 && compareArrays(indices[i][j], indicesSize[i][j], newIndex, newSize) < 0) {
                free(newIndex);
                newIndex = (int*)malloc(indicesSize[i][j] * sizeof(int));
                memcpy(newIndex, indices[i][j], indicesSize[i][j] * sizeof(int));
                newSize = indicesSize[i][j];
            }

            dp[i + 1][j] = s2;
            if (indices[i + 1][j]) {
                free(indices[i + 1][j]);
            }
            indices[i + 1][j] = newIndex;
            indicesSize[i + 1][j] = newSize;
        }
    }

    *returnSize = indicesSize[n][4];
    int* result = (int*)malloc(*returnSize * sizeof(int));
    memcpy(result, indices[n][4], *returnSize * sizeof(int));

    for (int i = 0; i <= n; i++) {
        free(dp[i]);
        for (int j = 0; j < 5; j++) {
            if (indices[i][j]) {
                free(indices[i][j]);
            }
        }
        free(indices[i]);
        free(indicesSize[i]);
    }
    free(dp);
    free(indices);
    free(indicesSize);
    free(arr);

    return result;
}
```

```JavaScript
var maximumWeight = function(intervals) {
    const n = intervals.length;
    const arr = intervals.map((interval, i) => ({
        l: interval[0],
        r: interval[1],
        weight: interval[2],
        idx: i
    }));
    // 按照右端点大小进行排序
    arr.sort((a, b) => a.r - b.r);

    const dp = Array.from({ length: n + 1 }, () => Array(5).fill(0));
    const indices = Array.from({ length: n + 1 }, () =>
        Array.from({ length: 5 }, () => [])
    );

    for (let i = 0; i < n; i++) {
        const { l, r, weight, idx } = arr[i];
        // 二分查找找到小于 l 的区间
        let left = 0, right = i;
        while (left < right) {
            const mid = Math.floor((left + right) / 2);
            if (arr[mid].r < l) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        const k = left;

        for (let j = 1; j < 5; j++) {
            const s1 = dp[i][j];
            const s2 = dp[k][j - 1] + weight;
            if (s1 > s2) {
                dp[i + 1][j] = dp[i][j];
                indices[i + 1][j] = [...indices[i][j]];
                continue;
            }

            const newIndex = [...indices[k][j - 1], idx].sort((a, b) => a - b);
            if (s1 === s2 && compareArrays(indices[i][j], newIndex) < 0) {
                dp[i + 1][j] = s2;
                indices[i + 1][j] = [...indices[i][j]];
            } else {
                dp[i + 1][j] = s2;
                indices[i + 1][j] = newIndex;
            }
        }
    }

    return indices[n][4];
};

function compareArrays(a, b) {
    const minLen = Math.min(a.length, b.length);
    for (let i = 0; i < minLen; i++) {
        if (a[i] !== b[i]) {
            return a[i] - b[i];
        }
    }
    return a.length - b.length;
}
```

```TypeScript
function maximumWeight(intervals: number[][]): number[] {
    const n = intervals.length;
    const arr = intervals.map((interval, i) => ({
        l: interval[0],
        r: interval[1],
        weight: interval[2],
        idx: i
    }));
    // 按照右端点大小进行排序
    arr.sort((a, b) => a.r - b.r);

    const dp: number[][] = Array.from({ length: n + 1 }, () => Array(5).fill(0));
    const indices: number[][][] = Array.from({ length: n + 1 }, () =>
        Array.from({ length: 5 }, () => [])
    );

    for (let i = 0; i < n; i++) {
        const { l, r, weight, idx } = arr[i];
        // 二分查找找到小于 l 的区间
        let left = 0, right = i;
        while (left < right) {
            const mid = Math.floor((left + right) / 2);
            if (arr[mid].r < l) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        const k = left;

        for (let j = 1; j < 5; j++) {
            const s1 = dp[i][j];
            const s2 = dp[k][j - 1] + weight;
            if (s1 > s2) {
                dp[i + 1][j] = dp[i][j];
                indices[i + 1][j] = [...indices[i][j]];
                continue;
            }

            const newIndex = [...indices[k][j - 1], idx].sort((a, b) => a - b);
            if (s1 === s2 && compareArrays(indices[i][j], newIndex) < 0) {
                dp[i + 1][j] = s2;
                indices[i + 1][j] = [...indices[i][j]];
            } else {
                dp[i + 1][j] = s2;
                indices[i + 1][j] = newIndex;
            }
        }
    }

    return indices[n][4];
}

function compareArrays(a: number[], b: number[]): number {
    const minLen = Math.min(a.length, b.length);
    for (let i = 0; i < minLen; i++) {
        if (a[i] !== b[i]) {
            return a[i] - b[i];
        }
    }
    return a.length - b.length;
}
```

```Rust
impl Solution {
    pub fn maximum_weight(intervals: Vec<Vec<i32>>) -> Vec<i32> {
        let n = intervals.len();
        let mut arr: Vec<(i32, i32, i64, usize)> = intervals
            .iter()
            .enumerate()
            .map(|(i, interval)| (interval[1], interval[0], interval[2] as i64, i))
            .collect();
        // 按照右端点大小进行排序
        arr.sort_by_key(|x| x.0);

        let mut dp = vec![vec![0i64; 5]; n + 1];
        let mut indices: Vec<Vec<Vec<i32>>> = vec![vec![Vec::new(); 5]; n + 1];

        for i in 0..n {
            let (r, l, weight, idx) = arr[i];
            // 二分查找找到右端点小于 l 的区间
            let k = arr[..i].partition_point(|x| x.0 < l);

            for j in 1..5 {
                let s1 = dp[i][j];
                let s2 = dp[k][j - 1] + weight;

                if s1 > s2 {
                    dp[i + 1][j] = dp[i][j];
                    indices[i + 1][j] = indices[i][j].clone();
                    continue;
                }

                let mut new_index = indices[k][j - 1].clone();
                new_index.push(idx as i32);
                new_index.sort();

                if s1 == s2 && compare_slices(&indices[i][j], &new_index) < 0 {
                    new_index = indices[i][j].clone();
                }

                dp[i + 1][j] = s2;
                indices[i + 1][j] = new_index;
            }
        }

        indices[n][4].clone()
    }
}

fn compare_slices(a: &[i32], b: &[i32]) -> i32 {
    let min_len = a.len().min(b.len());
    for i in 0..min_len {
        if a[i] != b[i] {
            return a[i] - b[i];
        }
    }
    a.len() as i32 - b.len() as i32
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n+nk^2)$，其中 $n$ 表示给定数组 $intervals$ 的长度，本题中 $k=4$。对数组进行排序需要的时间为 $O(n\log n)$，动态规划一共有 $O(nk)$ 个状态，动态规划需要的时间为 $O(n\log n+nk^2)$，因此总的时间复杂度为 $O(n\log n+nk^2)$。
- 空间复杂度：$O(nk^2)$，其中 $n$ 表示给定数组 $intervals$ 的长度，本题中 $k=4$。需要创建长度为 $O(n)$ 的数组保存排序结果，动态规划一共有 $O(nk)$ 个状态，每个状态需要 $O(k)$ 的空间保存下标列表，因此总的空间复杂度为 $O(nk^2)$。
