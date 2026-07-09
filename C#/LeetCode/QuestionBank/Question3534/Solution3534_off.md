### [针对图的路径存在性查询 II](https://leetcode.cn/problems/path-existence-queries-in-a-graph-ii/solutions/3992176/zhen-dui-tu-de-lu-jing-cun-zai-xing-cha-6n2f4/)

#### 方法一：双指针 + 倍增

**思路与算法**

「[3532\. 针对图的路径存在性查询 I](https://leetcode.cn/problems/path-existence-queries-in-a-graph-i/)」是本题的基础版本（前置题）。在本题中 $nums$ 无序的，并且每次查询需要求出两个节点之间的最短距离。

为了方便描述，我们约定 $n$ 是 $nums$ 的长度，若节点 $x$ 和 节点 $y$ 之间存在路径，则认为 $x$ 和 $y$ 是互相连通的。

由前置题可知，在排好序的 $nums$ 中，若两个节点 $x$ 和 $y$ 互相连通并且距离小于等于 $1$，那么 $x$ 和 $y$ 一定在一个下标连续的区间内，我们称这个区间为临近区间。基于这一性质，我们可以使用双指针算法求出与每个节点的临近区间的左端点。因此我们先将 $nums$ 排好序，$pos[i]$ 表示排好序后 $nums[i]$ 的位置，$idx[i]$ 表示排好序后第 $i$ 个数字在 $nums$ 中的下标。这两个数组成相互映射关系。每次查询两个节点 $x$ 和 $y$，它们对应排好序后的位置就是 $pos[x]$ 和 $pos[y]$。

我们不妨假设在排好序的数组中，节点 $x$ 总是在节点 $y$ 的左侧（若不是，可以交换），基于求出来的每个节点的临近区间的左端点，我们可以将节点 $y$ 不断的向左跳跃，直到覆盖到节点 $x$，这样可以求出来两点之间的最短距离。但如果查询次数太多，暴力跳跃会超时，我们可以采用倍增的方法。定义 $f[x][i]$ 为节点 $x$ 向左跳 $2^i$ 步后的节点，$0\le i\le \log n$。然后对于每次查询，从高位枚举二进制位 $i$，若右侧的节点向左跳 $2^i$ 步后仍然在 $x$ 右侧，那么 $y$ 就向左跳 $2^i$ 步，否则不跳。若 $x$ 和 $y$ 是连通的，那么最终 $y$ 会恰好只剩下一步到达 $x$；若不连通，则 $y$ 此刻的临近区间的左端点就是它自己，无法到达 $x$。需要注意对于 $x$ 和 $y$ 一开始就相等的情况，需要输出 $0$。

**代码**

```C++
class Solution {
public:
    vector<int> pathExistenceQueries(int n, vector<int>& nums, int maxDiff, vector<vector<int>>& queries) {
        vector<int> idx(n), pos(n), res;
        iota(idx.begin(), idx.end(), 0);
        sort(idx.begin(), idx.end(), [&](int a, int b) { return nums[a] < nums[b]; });
        for (int i = 0; i < n; i++) {
            pos[idx[i]] = i;
        }

        int m = 32 - __builtin_clz(n);
        vector<vector<int>> f(n, vector<int>(m));

        for (int i = 0, left = 0; i < n; i++) {
            while (nums[idx[i]] - nums[idx[left]] > maxDiff) left++;
            f[i][0] = left;
        }

        for (int j = 1; j < m; j++) {
            for (int i = 0; i < n; i++) {
                f[i][j] = f[f[i][j-1]][j-1];
            }
        }

        for (auto& q : queries) {
            auto [x, y] = pair(pos[q[0]], pos[q[1]]);
            if (x > y) {
                swap(x, y);
            }
            if (x == y) {
                res.push_back(0);
                continue;
            }

            int step = 0;
            for (int i = m - 1; i >= 0; i--) {
                if (f[y][i] > x) {
                    y = f[y][i];
                    step += 1 << i;
                }
            }

            res.push_back(f[y][0] <= x ? step + 1 : -1);
        }
        return res;
    }
};
```

```Python
class Solution:
    def pathExistenceQueries(self, n: int, nums: List[int], maxDiff: int, queries: List[List[int]]) -> List[int]:
        idx = sorted(range(n), key=lambda i: nums[i])
        pos = [0] * n
        for i, v in enumerate(idx):
            pos[v] = i


        m = n.bit_length()
        f = [[0] * m for _ in range(n)]

        left = 0
        for i in range(n):
            while left < i and nums[idx[i]] - nums[idx[left]] > maxDiff:
                left += 1
            f[i][0] = left

        for j in range(1, m):
            for i in range(n):
                f[i][j] = f[f[i][j-1]][j-1]

        res = []
        for query in queries:
            x, y = pos[query[0]], pos[query[1]]
            if x > y:
                x, y = y, x

            if x == y:
                res.append(0)
                continue

            step = 0
            for i in range(m-1, -1, -1):
                if f[y][i] > x:
                    y = f[y][i]
                    step += 1 << i

            if f[y][0] <= x:
                res.append(step + 1)
            else:
                res.append(-1)

        return res
```

```Rust
impl Solution {
    pub fn path_existence_queries(n: i32, nums: Vec<i32>, max_diff: i32, queries: Vec<Vec<i32>>) -> Vec<i32> {
        let n = n as usize;

        let mut idx: Vec<usize> = (0..n).collect();
        idx.sort_by_key(|&i| nums[i]);

        let mut pos = vec![0; n];
        for (i, &v) in idx.iter().enumerate() {
            pos[v] = i;
        }

        let m = (n as f64).log2().ceil() as usize + 1;
        let mut f = vec![vec![0; m]; n];

        let mut left = 0;
        for i in 0..n {
            while left < i && nums[idx[i]] - nums[idx[left]] > max_diff {
                left += 1;
            }
            f[i][0] = left;
        }

        for j in 1..m {
            for i in 0..n {
                f[i][j] = f[f[i][j-1]][j-1];
            }
        }

        let mut res = Vec::new();
        for query in queries {
            let mut x = pos[query[0] as usize];
            let mut y = pos[query[1] as usize];

            if x == y {
                res.push(0);
                continue;
            }

            if x > y {
                std::mem::swap(&mut x, &mut y);
            }

            let mut step = 0;
            for i in (0..m).rev() {
                if f[y][i] > x {
                    y = f[y][i];
                    step += 1 << i;
                }
            }

            if f[y][0] <= x {
                res.push(step + 1);
            } else {
                res.push(-1);
            }
        }

        res
    }
}
```

```Java
class Solution {
    public int[] pathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries) {
        int[] idx = new int[n];
        int[] pos = new int[n];

        for (int i = 0; i < n; i++) {
            idx[i] = i;
        }

        Integer[] ord = new Integer[n];
        for (int i = 0; i < n; i++) {
            ord[i] = i;
        }

        Arrays.sort(ord, (a, b) -> Integer.compare(nums[a], nums[b]));

        for (int i = 0; i < n; i++) {
            idx[i] = ord[i];
            pos[idx[i]] = i;
        }

        int m = 32 - Integer.numberOfLeadingZeros(n);

        int[][] f = new int[n][m];

        int left = 0;
        for (int i = 0; i < n; i++) {
            while (left < i && nums[idx[i]] - nums[idx[left]] > maxDiff) {
                left++;
            }
            f[i][0] = left;
        }

        for (int j = 1; j < m; j++) {
            for (int i = 0; i < n; i++) {
                f[i][j] = f[f[i][j - 1]][j - 1];
            }
        }

        int[] ans = new int[queries.length];

        for (int k = 0; k < queries.length; k++) {
            int x = pos[queries[k][0]];
            int y = pos[queries[k][1]];

            if (x > y) {
                int t = x;
                x = y;
                y = t;
            }

            if (x == y) {
                ans[k] = 0;
                continue;
            }

            int step = 0;

            for (int i = m - 1; i >= 0; i--) {
                if (f[y][i] > x) {
                    y = f[y][i];
                    step += 1 << i;
                }
            }

            ans[k] = f[y][0] <= x ? step + 1 : -1;
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public int[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries) {
        int[] idx = new int[n];
        for (int i = 0; i < n; i++) {
            idx[i] = i;
        }

        Array.Sort(idx, (a, b) => nums[a].CompareTo(nums[b]));

        int[] pos = new int[n];
        for (int i = 0; i < n; i++) {
            pos[idx[i]] = i;
        }

        int m = (int)Math.Ceiling(Math.Log2(n)) + 1;
        int[][] f = new int[n][];
        for (int i = 0; i < n; i++) {
            f[i] = new int[m];
        }

        int left = 0;
        for (int i = 0; i < n; i++) {
            while (left < i && nums[idx[i]] - nums[idx[left]] > maxDiff) {
                left++;
            }
            f[i][0] = left;
        }

        for (int j = 1; j < m; j++) {
            for (int i = 0; i < n; i++) {
                f[i][j] = f[f[i][j - 1]][j - 1];
            }
        }

        int[] res = new int[queries.Length];
        for (int q = 0; q < queries.Length; q++) {
            int x = pos[queries[q][0]];
            int y = pos[queries[q][1]];

            if (x == y) {
                res[q] = 0;
                continue;
            }

            if (x > y) {
                int temp = x;
                x = y;
                y = temp;
            }

            int step = 0;
            for (int i = m - 1; i >= 0; i--) {
                if (f[y][i] > x) {
                    y = f[y][i];
                    step += 1 << i;
                }
            }

            if (f[y][0] <= x) {
                res[q] = step + 1;
            } else {
                res[q] = -1;
            }
        }

        return res;
    }
}
```

```Go
func pathExistenceQueries(n int, nums []int, maxDiff int, queries [][]int) []int {
    idx := make([]int, n)
    pos := make([]int, n)

    for i := 0; i < n; i++ {
        idx[i] = i
    }

    sort.Slice(idx, func(i, j int) bool {
        return nums[idx[i]] < nums[idx[j]]
    })

    for i := 0; i < n; i++ {
        pos[idx[i]] = i
    }

    m := 0
    for t := n; t > 0; t >>= 1 {
        m++
    }

    f := make([][]int, n)
    for i := range f {
        f[i] = make([]int, m)
    }

    left := 0

    for i := 0; i < n; i++ {
        for left < i &&
            nums[idx[i]]-nums[idx[left]] > maxDiff {
            left++
        }

        f[i][0] = left
    }

    for j := 1; j < m; j++ {
        for i := 0; i < n; i++ {
            f[i][j] = f[f[i][j-1]][j-1]
        }
    }

    res := make([]int, 0, len(queries))

    for _, q := range queries {

        x := pos[q[0]]
        y := pos[q[1]]

        if x > y {
            x, y = y, x
        }

        if x == y {
            res = append(res, 0)
            continue
        }

        step := 0

        for i := m - 1; i >= 0; i-- {
            if f[y][i] > x {
                y = f[y][i]
                step += 1 << i
            }
        }

        if f[y][0] <= x {
            res = append(res, step+1)
        } else {
            res = append(res, -1)
        }
    }

    return res
}
```

```C
static int *g_nums;

static int cmp(const void *a, const void *b)
{
    int x = *(const int *)a;
    int y = *(const int *)b;
    return g_nums[x] - g_nums[y];
}

int* pathExistenceQueries(int n, int* nums, int numsSize, int maxDiff, int** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    g_nums = nums;

    int* idx = (int*)malloc(sizeof(int) * n);
    int* pos = (int*)malloc(sizeof(int) * n);

    for (int i = 0; i < n; i++) idx[i] = i;

    qsort(idx, n, sizeof(int), cmp);

    for (int i = 0; i < n; i++) {
        pos[idx[i]] = i;
    }

    int m = 0;
    while ((1 << m) <= n) {
        m++;
    }

    int** f = (int**)malloc(sizeof(int*) * n);
    for (int i = 0; i < n; i++) {
        f[i] = (int*)calloc(m, sizeof(int));
    }

    int left = 0;
    for (int i = 0; i < n; i++) {
        while (nums[idx[i]] - nums[idx[left]] > maxDiff) {
            left++;
        }

        f[i][0] = left;
    }

    for (int j = 1; j < m; j++) {
        for (int i = 0; i < n; i++) {
            f[i][j] = f[f[i][j - 1]][j - 1];
        }
    }

    int* res = (int*)malloc(sizeof(int) * queriesSize);

    for (int k = 0; k < queriesSize; k++) {
        int x = pos[queries[k][0]];
        int y = pos[queries[k][1]];

        if (x > y) {
            int t = x;
            x = y;
            y = t;
        }

        if (x == y) {
            res[k] = 0;
            continue;
        }

        int step = 0;

        for (int i = m - 1; i >= 0; i--) {
            if (f[y][i] > x) {
                y = f[y][i];
                step += (1 << i);
            }
        }

        res[k] = (f[y][0] <= x) ? step + 1 : -1;
    }

    *returnSize = queriesSize;

    return res;
}
```

```JavaScript
var pathExistenceQueries = function (n, nums, maxDiff, queries) {
    const idx = Array.from({ length: n }, (_, i) => i);
    const pos = Array(n);
    const res = [];

    idx.sort((a, b) => nums[a] - nums[b]);

    for (let i = 0; i < n; i++) {
        pos[idx[i]] = i;
    }

    let m = 0;
    while ((1 << m) <= n) {
        m++;
    }

    const f = Array.from({ length: n }, () => Array(m).fill(0));
    let left = 0;

    for (let i = 0; i < n; i++) {
        while (nums[idx[i]] - nums[idx[left]] > maxDiff) {
            left++;
        }
        f[i][0] = left;
    }

    for (let j = 1; j < m; j++) {
        for (let i = 0; i < n; i++) {
            f[i][j] = f[f[i][j - 1]][j - 1];
        }
    }

    for (const q of queries) {
        let x = pos[q[0]];
        let y = pos[q[1]];

        if (x > y) [x, y] = [y, x];

        if (x === y) {
            res.push(0);
            continue;
        }

        let step = 0;

        for (let i = m - 1; i >= 0; i--) {
            if (f[y][i] > x) {
                y = f[y][i];
                step += 1 << i;
            }
        }

        res.push(f[y][0] <= x ? step + 1 : -1);
    }

    return res;
};
```

```TypeScript
function pathExistenceQueries(n: number, nums: number[], maxDiff: number, queries: number[][]): number[] {
    const idx: number[] = Array.from({ length: n }, (_, i) => i);

    idx.sort((a, b) => nums[a] - nums[b]);

    const pos: number[] = new Array(n);

    for (let i = 0; i < n; i++) {
        pos[idx[i]] = i;
    }

    const m = n.toString(2).length;

    const f: number[][] = Array.from(
        { length: n },
        () => Array(m).fill(0)
    );

    let left = 0;

    for (let i = 0; i < n; i++) {
        while (
            left < i &&
            nums[idx[i]] - nums[idx[left]] > maxDiff
        ) {
            left++;
        }

        f[i][0] = left;
    }

    for (let j = 1; j < m; j++) {
        for (let i = 0; i < n; i++) {
            f[i][j] = f[f[i][j - 1]][j - 1];
        }
    }

    const res: number[] = [];

    for (const [a, b] of queries) {
        let x = pos[a];
        let y = pos[b];

        if (x > y) {
            [x, y] = [y, x];
        }

        if (x === y) {
            res.push(0);
            continue;
        }

        let step = 0;

        for (let i = m - 1; i >= 0; i--) {
            if (f[y][i] > x) {
                y = f[y][i];
                step += 1 << i;
            }
        }

        res.push(f[y][0] <= x ? step + 1 : -1);
    }

    return res;
};
```

**复杂度分析**

- 时间复杂度：$O(n\log n+q\log n)$，其中 $n$ 是 $nums$ 的长度，$q$ 是查询次数。
- 空间复杂度：$O(n\log n)$。
