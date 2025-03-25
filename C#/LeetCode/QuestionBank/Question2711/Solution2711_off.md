### [对角线上不同值的数量差](https://leetcode.cn/problems/difference-of-number-of-distinct-values-on-diagonals/solutions/3607529/dui-jiao-xian-shang-bu-tong-zhi-de-shu-l-c186/)

#### 方法一：模拟

**思路与算法**

直接模拟，对于二维矩阵中每一个单元格，用哈希表分别统计，左上角和右下角对角线上不同值的数量。

**代码**

```C++
class Solution {
public:
    vector<vector<int>> differenceOfDistinctValues(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        vector<vector<int>> res(m, vector<int>(n, 0));
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                set<int> s1;
                int x = i + 1, y = j + 1;
                while (x < m && y < n) {
                    s1.insert(grid[x][y]);
                    x += 1;
                    y += 1;
                }
                set<int> s2;
                x = i - 1, y = j - 1;
                while (x >= 0 && y >= 0) {
                    s2.insert(grid[x][y]);
                    x -= 1;
                    y -= 1;
                }
                res[i][j] = abs((int)s1.size() - (int)s2.size());
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int[][] differenceOfDistinctValues(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        int[][] res = new int[m][n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                Set<Integer> s1 = new HashSet<>();
                int x = i + 1, y = j + 1;
                while (x < m && y < n) {
                    s1.add(grid[x][y]);
                    x += 1;
                    y += 1;
                }
                Set<Integer> s2 = new HashSet<>();
                x = i - 1; y = j - 1;
                while (x >= 0 && y >= 0) {
                    s2.add(grid[x][y]);
                    x -= 1;
                    y -= 1;
                }
                res[i][j] = Math.abs(s1.size() - s2.size());
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    def differenceOfDistinctValues(self, grid: List[List[int]]) -> List[List[int]]:
        m, n = len(grid), len(grid[0])
        res = [[0] * n for _ in range(m)]
        for i in range(m):
            for j in range(n):
                s1 = set()
                x, y = i + 1, j + 1
                while x < m and y < n:
                    s1.add(grid[x][y])
                    x += 1
                    y += 1
                s2 = set()
                x, y = i - 1, j - 1
                while x >= 0 and y >= 0:
                    s2.add(grid[x][y])
                    x -= 1
                    y -= 1
                res[i][j] = abs(len(s1) - len(s2))
        return res
```

```JavaScript
var differenceOfDistinctValues = function(grid) {
    const m = grid.length, n = grid[0].length;
    const res = Array(m).fill(null).map(() => Array(n).fill(0));
    for (let i = 0; i < m; ++i) {
        for (let j = 0; j < n; ++j) {
            const s1 = new Set();
            let x = i + 1, y = j + 1;
            while (x < m && y < n) {
                s1.add(grid[x][y]);
                x += 1;
                y += 1;
            }
            const s2 = new Set();
            x = i - 1, y = j - 1;
            while (x >= 0 && y >= 0) {
                s2.add(grid[x][y]);
                x -= 1;
                y -= 1;
            }
            res[i][j] = Math.abs(s1.size - s2.size);
        }
    }
    return res;
};
```

```TypeScript
function differenceOfDistinctValues(grid: number[][]): number[][] {
    const m = grid.length, n = grid[0].length;
    const res = Array(m).fill(null).map(() => Array(n).fill(0));
    for (let i = 0; i < m; ++i) {
        for (let j = 0; j < n; ++j) {
            const s1 = new Set();
            let x = i + 1, y = j + 1;
            while (x < m && y < n) {
                s1.add(grid[x][y]);
                x += 1;
                y += 1;
            }
            const s2 = new Set();
            x = i - 1, y = j - 1;
            while (x >= 0 && y >= 0) {
                s2.add(grid[x][y]);
                x -= 1;
                y -= 1;
            }
            res[i][j] = Math.abs(s1.size - s2.size);
        }
    }
    return res;
};
```

```Go
func differenceOfDistinctValues(grid [][]int) [][]int {
    m, n := len(grid), len(grid[0])
    res := make([][]int, m)
    for i := 0; i < m; i++ {
        res[i] = make([]int, n)
    }
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            s1 := make(map[int]bool)
            x, y := i+1, j+1
            for x < m && y < n {
                s1[grid[x][y]] = true
                x++
                y++
            }
            s2 := make(map[int]bool)
            x, y = i-1, j-1
            for x >= 0 && y >= 0 {
                s2[grid[x][y]] = true
                x--
                y--
            }
            res[i][j] = abs(len(s1) - len(s2))
        }
    }
    return res
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

```CSharp
public class Solution {
    public int[][] DifferenceOfDistinctValues(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[][] res = new int[m][];
        for (int i = 0; i < m; ++i) {
            res[i] = new int[n];
            for (int j = 0; j < n; ++j) {
                HashSet<int> s1 = new HashSet<int>();
                int x = i + 1, y = j + 1;
                while (x < m && y < n) {
                    s1.Add(grid[x][y]);
                    x += 1;
                    y += 1;
                }
                HashSet<int> s2 = new HashSet<int>();
                x = i - 1; y = j - 1;
                while (x >= 0 && y >= 0) {
                    s2.Add(grid[x][y]);
                    x -= 1;
                    y -= 1;
                }
                res[i][j] = Math.Abs(s1.Count - s2.Count);
            }
        }
        return res;
    }
}
```

```C
int** differenceOfDistinctValues(int** grid, int gridSize, int* gridColSize, int* returnSize, int** returnColumnSizes) {
    int m = gridSize, n = *gridColSize;
    int** res = (int**)malloc(m * sizeof(int*));
    *returnColumnSizes = (int*)malloc(m * sizeof(int));
    *returnSize = m;
    for (int i = 0; i < m; ++i) {
        res[i] = (int*)malloc(n * sizeof(int));
        (*returnColumnSizes)[i] = n;
    }
    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < n; ++j) {
            bool s1[51] = {false};
            int count1 = 0;
            int x = i + 1, y = j + 1;
            while (x < m && y < n) {
                if (!s1[grid[x][y]]) {
                    s1[grid[x][y]] = true;
                    count1++;
                }
                x += 1;
                y += 1;
            }
            bool s2[51] = {false};
            int count2 = 0;
            x = i - 1, y = j - 1;
            while (x >= 0 && y >= 0) {
                if (!s2[grid[x][y]]) {
                    s2[grid[x][y]] = true;
                    count2++;
                }
                x -= 1;
                y -= 1;
            }
            res[i][j] = abs(count1 - count2);
        }
    }
    return res;
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn difference_of_distinct_values(grid: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
        let m = grid.len();
        let n = grid[0].len();
        let mut res = vec![vec![0; n]; m];
        for i in 0..m {
            for j in 0..n {
                let mut s1 = HashSet::new();
                let mut x = i + 1;
                let mut y = j + 1;
                while x < m && y < n {
                    s1.insert(grid[x][y]);
                    x += 1;
                    y += 1;
                }

                let mut s2 = HashSet::new();
                let mut x = i as i32 - 1;
                let mut y = j as i32 - 1;
                while x >= 0 && y >= 0 {
                    s2.insert(grid[x as usize][y as usize]);
                    x -= 1;
                    y -= 1;
                }

                res[i][j] = (s1.len() as i32 - s2.len() as i32).abs();
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m \times n \times min(m,n))$。
- 空间复杂度：$O(min(m,n))$。

#### 方法二：前缀和

**思路与算法**

观察到在同一个对角线上的不同单元格，它们的某一个方向上的对角线会高度重合。我们利用「前缀和」的思路，可以优化方法一。

我们从第一行和第一列，向右下方向出发，用哈希表记录不同元素，这样就可以得到这些单元格，左上角对角线上不同值数量。
同理我们可以从最后一行和最后一列出发，向左上方向出发，用哈希表记录不同元素，这样就可以得到这些单元格，右下角对角线上不同值数量。

最后我们对每个单元格求差值的绝对值，就得到最后的答案。

**代码**

```C++
class Solution {
public:
    vector<vector<int>> differenceOfDistinctValues(vector<vector<int>>& grid) {
        int m = grid.size();
        int n = grid[0].size();
        vector<vector<int>> res(m, vector<int>(n, 0));

        for (int i = 0; i < m; ++i) {
            int x = i, y = 0;
            set<int> s;
            while (x < m && y < n) {
                res[x][y] += s.size();
                s.insert(grid[x][y]);
                x += 1;
                y += 1;
            }
        }

        for (int j = 1; j < n; ++j) {
            int x = 0, y = j;
            set<int> s;
            while (x < m && y < n) {
                res[x][y] += s.size();
                s.insert(grid[x][y]);
                x += 1;
                y += 1;
            }
        }

        for (int i = 0; i < m; ++i) {
            int x = i, y = n - 1;
            set<int> s;
            while (x >= 0 && y >= 0) {
                res[x][y] -= s.size();
                res[x][y] = abs(res[x][y]);
                s.insert(grid[x][y]);
                x -= 1;
                y -= 1;
            }
        }

        for (int j = n - 2; j >= 0; --j) {
            int x = m - 1, y = j;
            set<int> s;
            while (x >= 0 && y >= 0) {
                res[x][y] -= s.size();
                res[x][y] = abs(res[x][y]);
                s.insert(grid[x][y]);
                x -= 1;
                y -= 1;
            }
        }

        return res;
    }
};
```

```Java
class Solution {
    public int[][] differenceOfDistinctValues(int[][] grid) {
        int m = grid.length;
        int n = grid[0].length;
        int[][] res = new int[m][n];

        for (int i = 0; i < m; ++i) {
            int x = i, y = 0;
            Set<Integer> s = new HashSet<>();
            while (x < m && y < n) {
                res[x][y] += s.size();
                s.add(grid[x][y]);
                x += 1;
                y += 1;
            }
        }

        for (int j = 1; j < n; ++j) {
            int x = 0, y = j;
            Set<Integer> s = new HashSet<>();
            while (x < m && y < n) {
                res[x][y] += s.size();
                s.add(grid[x][y]);
                x += 1;
                y += 1;
            }
        }

        for (int i = 0; i < m; ++i) {
            int x = i, y = n - 1;
            Set<Integer> s = new HashSet<>();
            while (x >= 0 && y >= 0) {
                res[x][y] -= s.size();
                res[x][y] = Math.abs(res[x][y]);
                s.add(grid[x][y]);
                x -= 1;
                y -= 1;
            }
        }

        for (int j = n - 2; j >= 0; --j) {
            int x = m - 1, y = j;
            Set<Integer> s = new HashSet<>();
            while (x >= 0 && y >= 0) {
                res[x][y] -= s.size();
                res[x][y] = Math.abs(res[x][y]);
                s.add(grid[x][y]);
                x -= 1;
                y -= 1;
            }
        }

        return res;
    }
}
```

```Python
class Solution:
    def differenceOfDistinctValues(self, grid: List[List[int]]) -> List[List[int]]:
        m, n = len(grid), len(grid[0])
        res = [[0] * n for i in range(m)]
        for i in range(m):
            x, y = i, 0
            s = set()
            while x < m and y < n:
                res[x][y] += len(s)
                s.add(grid[x][y])
                x += 1
                y += 1
        for j in range(1, n):
            x, y = 0, j
            s = set()
            while x < m and y < n:
                res[x][y] += len(s)
                s.add(grid[x][y])
                x += 1
                y += 1
        for i in range(m):
            x, y = i, n - 1
            s = set()
            while x >= 0 and y >= 0:
                res[x][y] -= len(s)
                res[x][y] = abs(res[x][y])
                s.add(grid[x][y])
                x -= 1
                y -= 1
        for j in range(n - 1):
            x, y = m - 1, j
            s = set()
            while x >= 0 and y >= 0:
                res[x][y] -= len(s)
                res[x][y] = abs(res[x][y])
                s.add(grid[x][y])
                x -= 1
                y -= 1
        return res

```

```JavaScript
var differenceOfDistinctValues = function(grid) {
    const m = grid.length;
    const n = grid[0].length;
    const res = Array(m).fill(null).map(() => Array(n).fill(0));

    for (let i = 0; i < m; ++i) {
        let x = i, y = 0;
        const s = new Set();
        while (x < m && y < n) {
            res[x][y] += s.size;
            s.add(grid[x][y]);
            x += 1;
            y += 1;
        }
    }

    for (let j = 1; j < n; ++j) {
        let x = 0, y = j;
        const s = new Set();
        while (x < m && y < n) {
            res[x][y] += s.size;
            s.add(grid[x][y]);
            x += 1;
            y += 1;
        }
    }

    for (let i = 0; i < m; ++i) {
        let x = i, y = n - 1;
        const s = new Set();
        while (x >= 0 && y >= 0) {
            res[x][y] -= s.size;
            res[x][y] = Math.abs(res[x][y]);
            s.add(grid[x][y]);
            x -= 1;
            y -= 1;
        }
    }

    for (let j = n - 2; j >= 0; --j) {
        let x = m - 1, y = j;
        const s = new Set();
        while (x >= 0 && y >= 0) {
            res[x][y] -= s.size;
            res[x][y] = Math.abs(res[x][y]);
            s.add(grid[x][y]);
            x -= 1;
            y -= 1;
        }
    }

    return res;
};
```

```TypeScript
function differenceOfDistinctValues(grid: number[][]): number[][] {
    const m = grid.length;
    const n = grid[0].length;
    const res = Array(m).fill(null).map(() => Array(n).fill(0));

    for (let i = 0; i < m; ++i) {
        let x = i, y = 0;
        const s = new Set();
        while (x < m && y < n) {
            res[x][y] += s.size;
            s.add(grid[x][y]);
            x += 1;
            y += 1;
        }
    }

    for (let j = 1; j < n; ++j) {
        let x = 0, y = j;
        const s = new Set();
        while (x < m && y < n) {
            res[x][y] += s.size;
            s.add(grid[x][y]);
            x += 1;
            y += 1;
        }
    }

    for (let i = 0; i < m; ++i) {
        let x = i, y = n - 1;
        const s = new Set();
        while (x >= 0 && y >= 0) {
            res[x][y] -= s.size;
            res[x][y] = Math.abs(res[x][y]);
            s.add(grid[x][y]);
            x -= 1;
            y -= 1;
        }
    }

    for (let j = n - 2; j >= 0; --j) {
        let x = m - 1, y = j;
        const s = new Set();
        while (x >= 0 && y >= 0) {
            res[x][y] -= s.size;
            res[x][y] = Math.abs(res[x][y]);
            s.add(grid[x][y]);
            x -= 1;
            y -= 1;
        }
    }

    return res;
};
```

```Go
func differenceOfDistinctValues(grid [][]int) [][]int {
    m := len(grid)
    n := len(grid[0])
    res := make([][]int, m)
    for i := range res {
        res[i] = make([]int, n)
    }

    for i := 0; i < m; i++ {
        x, y := i, 0
        s := make(map[int]bool)
        for x < m && y < n {
            res[x][y] += len(s)
            s[grid[x][y]] = true
            x++
            y++
        }
    }

    for j := 1; j < n; j++ {
        x, y := 0, j
        s := make(map[int]bool)
        for x < m && y < n {
            res[x][y] += len(s)
            s[grid[x][y]] = true
            x++
            y++
        }
    }

    for i := 0; i < m; i++ {
        x, y := i, n-1
        s := make(map[int]bool)
        for x >= 0 && y >= 0 {
            res[x][y] -= len(s)
            res[x][y] = abs(res[x][y])
            s[grid[x][y]] = true
            x--
            y--
        }
    }

    for j := n - 2; j >= 0; j-- {
        x, y := m - 1, j
        s := make(map[int]bool)
        for x >= 0 && y >= 0 {
            res[x][y] -= len(s)
            res[x][y] = abs(res[x][y])
            s[grid[x][y]] = true
            x--
            y--
        }
    }

    return res
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

```CSharp
public class Solution {
    public int[][] DifferenceOfDistinctValues(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] res = new int[m][];
        for (int i = 0; i < m; ++i) {
            res[i] = new int[n];
        }

        for (int i = 0; i < m; ++i) {
            int x = i, y = 0;
            HashSet<int> s = new HashSet<int>();
            while (x < m && y < n) {
                res[x][y] += s.Count;
                s.Add(grid[x][y]);
                x += 1;
                y += 1;
            }
        }

        for (int j = 1; j < n; ++j) {
            int x = 0, y = j;
            HashSet<int> s = new HashSet<int>();
            while (x < m && y < n) {
                res[x][y] += s.Count;
                s.Add(grid[x][y]);
                x += 1;
                y += 1;
            }
        }

        for (int i = 0; i < m; ++i) {
            int x = i, y = n - 1;
            HashSet<int> s = new HashSet<int>();
            while (x >= 0 && y >= 0) {
                res[x][y] -= s.Count;
                res[x][y] = Math.Abs(res[x][y]);
                s.Add(grid[x][y]);
                x -= 1;
                y -= 1;
            }
        }

        for (int j = n - 2; j >= 0; --j) {
            int x = m - 1, y = j;
            HashSet<int> s = new HashSet<int>();
            while (x >= 0 && y >= 0) {
                res[x][y] -= s.Count;
                res[x][y] = Math.Abs(res[x][y]);
                s.Add(grid[x][y]);
                x -= 1;
                y -= 1;
            }
        }

        return res;
    }
}
```

```C
int** differenceOfDistinctValues(int** grid, int gridSize, int* gridColSize, int* returnSize, int** returnColumnSizes) {
    int m = gridSize;
    int n = gridColSize[0];

    int** res = (int**)malloc(m * sizeof(int*));
    *returnColumnSizes = (int*)malloc(m * sizeof(int));
    *returnSize = m;

    for (int i = 0; i < m; ++i) {
        res[i] = (int*)malloc(n * sizeof(int));
        (*returnColumnSizes)[i] = n;
        for (int j = 0; j < n; ++j) {
            res[i][j] = 0;
        }
    }

    for (int i = 0; i < m; ++i) {
        int x = i, y = 0;
        bool s[51] = {false};
        int count = 0;
        while (x < m && y < n) {
            res[x][y] += count;
            if (!s[grid[x][y]]) {
                s[grid[x][y]] = true;
                count++;
            }
            x += 1;
            y += 1;
        }
    }

    for (int j = 1; j < n; ++j) {
        int x = 0, y = j;
        bool s[51] = {false};
        int count = 0;
        while (x < m && y < n) {
            res[x][y] += count;
            if (!s[grid[x][y]]) {
                s[grid[x][y]] = true;
                count++;
            }
            x += 1;
            y += 1;
        }
    }

    for (int i = 0; i < m; ++i) {
        int x = i, y = n - 1;
        bool s[51] = {false};
        int count = 0;
        while (x >= 0 && y >= 0) {
            res[x][y] -= count;
            res[x][y] = abs(res[x][y]);
            if (!s[grid[x][y]]) {
                s[grid[x][y]] = true;
                count++;
            }
            x -= 1;
            y -= 1;
        }
    }

    for (int j = n - 2; j >= 0; --j) {
        int x = m - 1, y = j;
        bool s[51] = {false};
        int count = 0;
        while (x >= 0 && y >= 0) {
            res[x][y] -= count;
            res[x][y] = abs(res[x][y]);
            if (!s[grid[x][y]]) {
                s[grid[x][y]] = true;
                count++;
            }
            x -= 1;
            y -= 1;
        }
    }

    return res;
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn difference_of_distinct_values(grid: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
        let m = grid.len();
        let n = grid[0].len();
        let mut res = vec![vec![0; n]; m];

        for i in 0..m {
            let mut x = i as i32;
            let mut y = 0;
            let mut s = HashSet::new();
            while x < m as i32 && y < n as i32 {
                res[x as usize][y as usize] += s.len() as i32;
                s.insert(grid[x as usize][y as usize]);
                x += 1;
                y += 1;
            }
        }

        for j in 1..n {
            let mut x = 0;
            let mut y = j as i32;
            let mut s = HashSet::new();
            while x < m as i32 && y < n as i32 {
                res[x as usize][y as usize] += s.len() as i32;
                s.insert(grid[x as usize][y as usize]);
                x += 1;
                y += 1;
            }
        }

        for i in 0..m {
            let mut x = i as i32;
            let mut y = n as i32 - 1;
            let mut s = HashSet::new();
            while x >= 0 && y >= 0 {
                res[x as usize][y as usize] -= s.len() as i32;
                res[x as usize][y as usize] = (res[x as usize][y as usize]).abs();
                s.insert(grid[x as usize][y as usize]);
                x -= 1;
                y -= 1;
            }
        }

        for j in (0..n - 1).rev() {
            let mut x = m as i32 - 1;
            let mut y = j as i32;
            let mut s = HashSet::new();
            while x >= 0 && y >= 0 {
                res[x as usize][y as usize] -= s.len() as i32;
                res[x as usize][y as usize] = (res[x as usize][y as usize]).abs();
                s.insert(grid[x as usize][y as usize]);
                x -= 1;
                y -= 1;
            }
        }

        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m \times n)$。
- 空间复杂度：$O(min(m,n))$。
