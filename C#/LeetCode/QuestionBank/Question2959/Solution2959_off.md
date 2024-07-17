### [关闭分部的可行集合数目](https://leetcode.cn/problems/number-of-possible-sets-of-closing-branches/solutions/2844227/guan-bi-fen-bu-de-ke-xing-ji-he-shu-mu-b-85ov/)

#### 方法一：Floyd最短路径算法

**思路与算法**

我们用一个 $n$ 位的 整数 $opened$ 来表示开放的分部集合，对于所有情况我们使用 「$Floyd$ 最短路径」算法，来找到两两分部的最短距离。

然后我们检查剩下的分部之间两两互相可以到达且最远距离不超过 maxDistance ， 如果则增加可行方案数目。

最后返回关闭分部的可行方案数目。

**代码**

```C++
class Solution {
public:
    int numberOfSets(int n, int maxDistance, vector<vector<int>>& roads) {
        int res = 0;
        vector<int> opened(n, 0);
        vector<vector<int>> d(n, vector<int>(n, 1000000));

        for (int mask = 0; mask < (1 << n); ++mask) {
            for (int i = 0; i < n; ++i) {
                opened[i] = mask & (1 << i);
            }
            fill(d.begin(), d.end(), vector<int>(n, 1000000));
            for (const auto& road : roads) {
                int i = road[0], j = road[1], r = road[2];
                if (opened[i] > 0 && opened[j] > 0) {
                    d[i][j] = d[j][i] = min(d[i][j], r);
                }
            }

            // Floyd-Warshall algorithm
            for (int k = 0; k < n; ++k) {
                if (opened[k] > 0) {
                    for (int i = 0; i < n; ++i) {
                        if (opened[i] > 0) {
                            for (int j = i + 1; j < n; ++j) {
                                if (opened[j] > 0) {
                                    d[i][j] = d[j][i] = min(d[i][j], d[i][k] + d[k][j]);
                                }
                            }
                        }
                    }
                }
            }

            // Validate
            int good = 1;
            for (int i = 0; i < n; ++i) {
                if (opened[i] > 0) {
                    for (int j = i + 1; j < n; ++j) {
                        if (opened[j] > 0 && d[i][j] > maxDistance) {
                            good = 0;
                            break;
                        }
                    }
                    if (!good) {
                        break;
                    }
                }
            }

            res += good;
        }
        return res;
    }
};
```

```Java
public class Solution {

    public int numberOfSets(int n, int maxDistance, int[][] roads) {
        int res = 0;
        int[] opened = new int[n];
        int[][] d = new int[n][n];

        for (int mask = 0; mask < (1 << n); mask++) {
            for (int i = 0; i < n; i++) {
                opened[i] = mask & (1 << i);
            }
            for (int[] row : d) {
                Arrays.fill(row, 1000000);
            }
            for (int[] road : roads) {
                int i = road[0], j = road[1], r = road[2];
                if (opened[i] > 0 && opened[j] > 0) {
                    d[i][j] = d[j][i] = Math.min(d[i][j], r);
                }
            }

            // Floyd-Warshall algorithm
            for (int k = 0; k < n; k++) {
                if (opened[k] > 0) {
                    for (int i = 0; i < n; i++) {
                        if (opened[i] > 0) {
                            for (int j = i + 1; j < n; j++) {
                                if (opened[j] > 0) {
                                    d[i][j] = d[j][i] = Math.min(d[i][j], d[i][k] + d[k][j]);
                                }
                            }
                        }
                    }
                }
            }

            // Validate
            int good = 1;
            for (int i = 0; i < n; i++) {
                if (opened[i] > 0) {
                    for (int j = i + 1; j < n; j++) {
                        if (opened[j] > 0) {
                            if (d[i][j] > maxDistance) {
                                good = 0;
                                break;
                            }
                        }
                    }
                    if (good == 0) {
                        break;
                    }
                }
            }
            res += good;
        }
        return res;
    }
}
```

```Python
class Solution:
    def numberOfSets(self, n: int, maxDistance: int, roads: List[List[int]]) -> int:
        res = 0
        opened = [0] * n
        for mask in range(1 << n):
            for i in range(n):
                opened[i] = mask & (1 << i)
            d = [[1000000] * n for i in range(n)]
            for i,j,r in roads:
                if opened[i] > 0 and opened[j] > 0:
                    d[i][j] = d[j][i] = min(d[i][j], r)
            for k in range(n):
                if opened[k] > 0:
                    for i in range(n):
                        if opened[i] > 0:
                            for j in range(i + 1, n):
                                if opened[j] > 0:
                                    d[i][j] = d[j][i] = min(d[i][j], d[i][k] + d[k][j])
            good = 1
            for i in range(n):
                if opened[i] > 0:
                    for j in range(i + 1, n):
                        if opened[j] > 0:
                            if d[i][j] > maxDistance:
                                good = 0
                                break
                if good == 0:
                    break
            res += good
        return res
```

```JavaScript
function numberOfSets(n, maxDistance, roads) {
    let res = 0;
    let opened = new Array(n).fill(0);

    for (let mask = 0; mask < (1 << n); mask++) {
        for (let i = 0; i < n; i++) {
            opened[i] = mask & (1 << i);
        }
        let d = new Array(n).fill(0).map(() => new Array(n).fill(1000000));

        for (let [i, j, r] of roads) {
            if (opened[i] > 0 && opened[j] > 0) {
                d[i][j] = d[j][i] = Math.min(d[i][j], r);
            }
        }

        // Floyd-Warshall algorithm
        for (let k = 0; k < n; k++) {
            if (opened[k] > 0) {
                for (let i = 0; i < n; i++) {
                    if (opened[i] > 0) {
                        for (let j = i + 1; j < n; j++) {
                            if (opened[j] > 0) {
                                d[i][j] = d[j][i] = Math.min(d[i][j], d[i][k] + d[k][j]);
                            }
                        }
                    }
                }
            }
        }

        // Validate
        let good = 1;
        for (let i = 0; i < n; i++) {
            if (opened[i] > 0) {
                for (let j = i + 1; j < n; j++) {
                    if (opened[j] > 0 && d[i][j] > maxDistance) {
                        good = 0;
                        break;
                    }
                }
                if (good == 0) {
                    break;
                }
            }
        }
        res += good;
    }
    return res;
}
```

```TypeScript
function numberOfSets(n: number, maxDistance: number, roads: number[][]): number {
    let res = 0;
    let opened = new Array(n).fill(0);

    for (let mask = 0; mask < (1 << n); mask++) {
        for (let i = 0; i < n; i++) {
            opened[i] = mask & (1 << i);
        }
        let d = new Array(n).fill(0).map(() => new Array(n).fill(1000000));

        for (let [i, j, r] of roads) {
            if (opened[i] > 0 && opened[j] > 0) {
                d[i][j] = d[j][i] = Math.min(d[i][j], r);
            }
        }

        // Floyd-Warshall algorithm
        for (let k = 0; k < n; k++) {
            if (opened[k] > 0) {
                for (let i = 0; i < n; i++) {
                    if (opened[i] > 0) {
                        for (let j = i + 1; j < n; j++) {
                            if (opened[j] > 0) {
                                d[i][j] = d[j][i] = Math.min(d[i][j], d[i][k] + d[k][j]);
                            }
                        }
                    }
                }
            }
        }

        // Validate
        let good = 1;
        for (let i = 0; i < n; i++) {
            if (opened[i] > 0) {
                for (let j = i + 1; j < n; j++) {
                    if (opened[j] > 0 && d[i][j] > maxDistance) {
                        good = 0;
                        break;
                    }
                }
                if (good == 0) {
                    break;
                }
            }
        }
        res += good;
    }
    return res;
};
```

```Go
func numberOfSets(n int, maxDistance int, roads [][]int) int {
    res := 0
    opened := make([]int, n)
    d := make([][]int, n)

    for mask := 0; mask < (1 << n); mask++ {
        for i := 0; i < n; i++ {
            opened[i] = mask & (1 << i)
        }
        for i := range d {
            d[i] = make([]int, n)
            for j := range d[i] {
                d[i][j] = 1000000
            }
        }
        for _, road := range roads {
            i, j, r := road[0], road[1], road[2]
            if opened[i] > 0 && opened[j] > 0 {
                if r < d[i][j] {
                    d[i][j] = r
                    d[j][i] = r
                }
            }
        }

        // Floyd-Warshall algorithm
        for k := 0; k < n; k++ {
            if opened[k] > 0 {
                for i := 0; i < n; i++ {
                    if opened[i] > 0 {
                        for j := i + 1; j < n; j++ {
                            if opened[j] > 0 {
                                if d[i][k]+d[k][j] < d[i][j] {
                                    d[i][j] = d[i][k] + d[k][j]
                                    d[j][i] = d[i][j] // Ensure symmetry
                                }
                            }
                        }
                    }
                }
            }
        }

        // Validate
        good := 1
        for i := 0; i < n; i++ {
            if opened[i] > 0 {
                for j := i + 1; j < n; j++ {
                    if opened[j] > 0 && d[i][j] > maxDistance {
                        good = 0
                        break
                    }
                }
                if good == 0 {
                    break
                }
            }
        }
        res += good
    }
    return res
}
```

```CSharp
public class Solution {
    public int NumberOfSets(int n, int maxDistance, int[][] roads) {
        int res = 0;
        int[] opened = new int[n];
        int[,] d = new int[n, n];

        for (int mask = 0; mask < (1 << n); mask++) {
            for (int i = 0; i < n; i++) {
                opened[i] = mask & (1 << i);
            }
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    d[i, j] = 1000000;
                }
            }
            foreach (int[] road in roads) {
                int i = road[0], j = road[1], r = road[2];
                if (opened[i] > 0 && opened[j] > 0) {
                    d[i, j] = d[j, i] = Math.Min(d[i, j], r);
                }
            }

            // Floyd-Warshall algorithm
            for (int k = 0; k < n; k++) {
                if (opened[k] > 0) {
                    for (int i = 0; i < n; i++) {
                        if (opened[i] > 0) {
                            for (int j = i + 1; j < n; j++) {
                                if (opened[j] > 0) {
                                    d[i, j] = d[j, i] = Math.Min(d[i, j], d[i, k] + d[k, j]);
                                }
                            }
                        }
                    }
                }
            }

            // Validate
            int good = 1;
            for (int i = 0; i < n; i++) {
                if (opened[i] > 0) {
                    for (int j = i + 1; j < n; j++) {
                        if (opened[j] > 0) {
                            if (d[i, j] > maxDistance) {
                                good = 0;
                                break;
                            }
                        }
                    }
                    if (good == 0) {
                        break;
                    }
                }
            }
            res += good;
        }
        return res;
    }
}
```

```C
int numberOfSets(int n, int maxDistance, int** roads, int roadsSize, int* roadsColSize) {
    int res = 0, opened[n], d[n][n];

    for (int mask = 0; mask < (1 << n); mask++) {
        for (int i = 0; i < n; i++) {
            opened[i] = mask & (1 << i);
        }
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                d[i][j] = 1000000;
            }
        }
        for (int k = 0; k < roadsSize; k++) {
            int i = roads[k][0], j = roads[k][1], r = roads[k][2];
            if (opened[i] && opened[j]) {
                d[i][j] = d[j][i] = (d[i][j] < r) ? d[i][j] : r;
            }
        }

        // Floyd-Warshall Algorithm
        for (int k = 0; k < n; k++) {
            if (opened[k]) {
                for (int i = 0; i < n; i++) {
                    if (opened[i]) {
                        for (int j = 0; j < n; j++) {
                            if (opened[j]) {
                                if (d[i][k] + d[k][j] < d[i][j]) {
                                    d[i][j] = d[i][k] + d[k][j];
                                }
                            }
                        }
                    }
                }
            }
        }

        // Validate
        int good = 1;
        for (int i = 0; i < n; i++) {
            if (opened[i]) {
                for (int j = i + 1; j < n; j++) {
                    if (opened[j] && d[i][j] > maxDistance) {
                        good = 0;
                        break;
                    }
                }
                if (!good) {
                    break;
                }
            }
        }
        res += good;
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn number_of_sets(n: i32, max_distance: i32, roads: Vec<Vec<i32>>) -> i32 {
        let n_usize = n as usize;
        let max_distance_usize = max_distance as usize;
        let mut res = 0;
        let mut opened = vec![0; n_usize];

        for mask in 0..(1 << n) {
            for i in 0..n_usize {
                opened[i] = mask & (1 << i);
            }
            let mut d = vec![vec![1000000; n_usize]; n_usize];
            for road in &roads {
                let i = road[0] as usize;
                let j = road[1] as usize;
                let r = road[2] as usize;
                if opened[i] > 0 && opened[j] > 0 {
                    d[i][j] = d[i][j].min(r);
                    d[j][i] = d[j][i].min(r);
                }
            }

            // Floyd-Warshall
            for k in 0..n_usize {
                if opened[k] > 0 {
                    for i in 0..n_usize {
                        if opened[i] > 0 {
                            for j in (i + 1)..n_usize {
                                if opened[j] > 0 {
                                    d[i][j] = d[i][j].min(d[i][k] + d[k][j]);
                                    d[j][i] = d[i][j];
                                }
                            }
                        }
                    }
                }
            }

            // Validate
            let mut good = true;
            for i in 0..n_usize {
                if opened[i] > 0 {
                    for j in (i + 1)..n_usize {
                        if opened[j] > 0 && d[i][j] > max_distance_usize {
                            good = false;
                            break;
                        }
                    }
                    if !good {
                        break;
                    }
                }
            }
            if good {
                res += 1;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(2^n \times n^3)$, $2^n$ 种情况，每个求最短路需要 $n^3$ 时间。
- 空间复杂度：$O(n^2)$。
