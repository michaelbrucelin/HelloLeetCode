### [统计有序矩阵中的负数](https://leetcode.cn/problems/count-negative-numbers-in-a-sorted-matrix/solutions/101204/tong-ji-you-xu-ju-zhen-zhong-de-fu-shu-by-leetcode/)

#### 方法一：暴力

观察数据范围注意到矩阵大小不会超过 $100\times 100=10^4$，所以我们可以遍历矩阵所有数，统计负数的个数。

```C++
class Solution {
public:
    int countNegatives(vector<vector<int>>& grid) {
        int num = 0;
        for (int x : grid) {
            for (int y : x) {
                if (y < 0) {
                    num++;
                }
            }
        }
        return num;
    }
};
```

```Java
class Solution {
    public int countNegatives(int[][] grid) {
        int num = 0;
        for (int[] row : grid) {
            for (int value : row) {
                if (value < 0) {
                    num++;
                }
            }
        }
        return num;
    }
}
```

```CSharp
public class Solution {
    public int CountNegatives(int[][] grid) {
        int num = 0;
        foreach (int[] row in grid) {
            foreach (int value in row) {
                if (value < 0) {
                    num++;
                }
            }
        }
        return num;
    }
}
```

```Go
func countNegatives(grid [][]int) int {
    num := 0
    for _, row := range grid {
        for _, value := range row {
            if value < 0 {
                num++
            }
        }
    }
    return num
}
```

```Python
class Solution:
    def countNegatives(self, grid: List[List[int]]) -> int:
        num = 0
        for row in grid:
            for value in row:
                if value < 0:
                    num += 1
        return num
```

```C
int countNegatives(int** grid, int gridSize, int* gridColSize) {
    int num = 0;
    for (int i = 0; i < gridSize; i++) {
        for (int j = 0; j < gridColSize[i]; j++) {
            if (grid[i][j] < 0) {
                num++;
            }
        }
    }
    return num;
}
```

```JavaScript
var countNegatives = function(grid) {
    let num = 0;
    for (const row of grid) {
        for (const value of row) {
            if (value < 0) {
                num++;
            }
        }
    }
    return num;
};
```

```TypeScript
function countNegatives(grid: number[][]): number {
    let num = 0;
    for (const row of grid) {
        for (const value of row) {
            if (value < 0) {
                num++;
            }
        }
    }
    return num;
};
```

```Rust
impl Solution {
    pub fn count_negatives(grid: Vec<Vec<i32>>) -> i32 {
        let mut num = 0;
        for row in grid {
            for value in row {
                if value < 0 {
                    num += 1;
                }
            }
        }
        num
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nm)$，即矩阵元素的总个数。
- 空间复杂度：$O(1)$。

#### 方法二：二分查找

注意到题目中给了一个性质，即**矩阵中的元素无论是按行还是按列，都以非递增顺序排列**，可以考虑把这个性质利用起来优化暴力。已知这个性质告诉了我们每一行的数都是有序的，所以我们通过二分查找可以找到每一行中从前往后的第一个负数，那么这个位置之后到这一行的末尾里所有的数必然是负数了，可以直接统计。

1. 遍历矩阵的每一行。
2. 二分查找到该行从前往后的第一个负数，考虑第 $i$ 行，我们记这个位置为 $pos_i$，那么第 $i$ 行 $[pos_i,m-1]$ 中的所有数都是负数，所以这一行对答案的贡献就是 $m-1-pos_i+1=m-pos_i$。
3. 最后的答案就是 $\sum_{i=0}^{n-1}(m-pos_i)$。

```C++
class Solution {
public:
    int countNegatives(vector<vector<int>>& grid) {
        int num = 0;
        for (auto x : grid) {
            int l = 0, r = (int)x.size() - 1, pos = -1;
            while (l <= r) {
                int mid = l + ((r - l) >> 1);
                if (x[mid] < 0) {
                    pos = mid;
                    r = mid - 1;
                } else {
                    l = mid + 1;
                }
            }

            if (~pos) {  // pos != -1 表示这一行存在负数
                num += (int)x.size() - pos;
            }
        }
        return num;
    }
};
```

```Java
class Solution {
    public int countNegatives(int[][] grid) {
        int num = 0;
        for (int[] row : grid) {
            int l = 0, r = row.length - 1, pos = -1;
            while (l <= r) {
                int mid = l + (r - l) / 2;
                if (row[mid] < 0) {
                    pos = mid;
                    r = mid - 1;
                } else {
                    l = mid + 1;
                }
            }
            if (pos != -1) {
                num += row.length - pos;
            }
        }
        return num;
    }
}
```

```CSharp
public class Solution {
    public int CountNegatives(int[][] grid) {
        int num = 0;
        foreach (int[] row in grid) {
            int l = 0, r = row.Length - 1, pos = -1;
            while (l <= r) {
                int mid = l + (r - l) / 2;
                if (row[mid] < 0) {
                    pos = mid;
                    r = mid - 1;
                } else {
                    l = mid + 1;
                }
            }
            if (pos != -1) {
                num += row.Length - pos;
            }
        }
        return num;
    }
}
```

```Go
func countNegatives(grid [][]int) int {
    num := 0
    for _, row := range grid {
        l, r, pos := 0, len(row) - 1, -1
        for l <= r {
            mid := l + (r - l) / 2
            if row[mid] < 0 {
                pos = mid
                r = mid - 1
            } else {
                l = mid + 1
            }
        }
        if pos != -1 {
            num += len(row) - pos
        }
    }
    return num
}
```

```Python
class Solution:
    def countNegatives(self, grid: List[List[int]]) -> int:
        num = 0
        for row in grid:
            l, r, pos = 0, len(row) - 1, -1
            while l <= r:
                mid = l + (r - l) // 2
                if row[mid] < 0:
                    pos = mid
                    r = mid - 1
                else:
                    l = mid + 1
            if pos != -1:
                num += len(row) - pos
        return num
```

```C
int countNegatives(int** grid, int gridSize, int* gridColSize) {
    int num = 0;
    for (int i = 0; i < gridSize; i++) {
        int l = 0, r = gridColSize[i] - 1, pos = -1;
        while (l <= r) {
            int mid = l + (r - l) / 2;
            if (grid[i][mid] < 0) {
                pos = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        if (pos != -1) {
            num += gridColSize[i] - pos;
        }
    }
    return num;
}
```

```JavaScript
var countNegatives = function(grid) {
    let num = 0;
    for (const row of grid) {
        let l = 0, r = row.length - 1, pos = -1;
        while (l <= r) {
            const mid = l + Math.floor((r - l) / 2);
            if (row[mid] < 0) {
                pos = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        if (pos !== -1) {
            num += row.length - pos;
        }
    }
    return num;
};
```

```TypeScript
function countNegatives(grid: number[][]): number {
    let num = 0;
    for (const row of grid) {
        let l = 0, r = row.length - 1, pos = -1;
        while (l <= r) {
            const mid = l + Math.floor((r - l) / 2);
            if (row[mid] < 0) {
                pos = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        if (pos !== -1) {
            num += row.length - pos;
        }
    }
    return num;
}
```

```Rust
impl Solution {
    pub fn count_negatives(grid: Vec<Vec<i32>>) -> i32 {
        let mut num = 0;
        for row in grid {
            let (mut l, mut r, mut pos) = (0, row.len() as i32 - 1, -1);
            while l <= r {
                let mid = l + (r - l) / 2;
                if row[mid as usize] < 0 {
                    pos = mid;
                    r = mid - 1;
                } else {
                    l = mid + 1;
                }
            }
            if pos != -1 {
                num += row.len() as i32 - pos;
            }
        }
        num
    }
}
```

**复杂度分析**

- 时间复杂度：二分查找一行的时间复杂度为\log $m$，需要遍历n行，所以总时间复杂度是O(n\log $m)$。
- 空间复杂度：$O(1)$。

#### 方法三：分治

方法二其实只利用了一部分的性质，即每一行是非递增的，但其实整个矩阵是**每行每列均非递增**，这说明了一个更重要的性质：**每一行从前往后第一个负数的位置是不断递减的**，即我们设第 $i$ 行的第一个负数的位置为 $pos_i$，不失一般性，我们把一行全是正数的 $pos$ 设为 $m$，则

$$pos_0>=pos_1>=pos_2>=\dots>=pos_{n-1}$$

所以我们可以依此设计一个分治算法。

我们设计一个函数 $solve(l,r,L,R)$ 表示我们在统计 $[l,r]$ 行的答案，第 $[l,r]$ 行 $pos$ 的位置在 $[L,R]$ 列中，计算 $[l,r]$ 的中间行第 $mid$ 行的的 $pos_{mid}$，算完以后根据之前的方法计算这一行对答案的贡献。然后根据我们之前发现的性质，可以知道 $[l,mid-1]$ 中所有行的 $pos$ 是大于等于 $pos_{mid}$，$[mid+1,r]$ 中所有行的 $pos$ 值是小于等于 $pos_{mid}$ 的，所以可以分成两部分递归下去，即：

$$solve(l,mid-1,pos_{mid},R)$$

和

$$solve(mid+1,r,L,pos_{mid})$$

所以答案就是 $m-pos_{mid}+solve(l,mid-1,pos_{mid},R)+solve(mid+1,r,L,pos_{mid})$。

递归函数入口为 $solve(0,n-1,0,m-1)$。

```C++
class Solution {
public:
    int solve(int l, int r, int L, int R, vector<vector<int>>& grid) {
        if (l > r) {
            return 0;
        }

        int mid = l + ((r - l) >> 1);
        int pos = -1;
        // 在当前行中查找第一个负数
        for (int i = L; i <= R; ++i) {
            if (grid[mid][i] < 0) {
                pos = i;
                break;
            }
        }
        int ans = 0;
        if (pos != -1) {
            // 当前行找到负数，计算当前行的负数个数
            ans += (int)grid[0].size() - pos;
            // 递归处理上半部分（使用更小的列范围）
            ans += solve(l, mid - 1, pos, R, grid);
            // 递归处理下半部分（使用相同的列起始范围）
            ans += solve(mid + 1, r, L, pos, grid);
        } else {
            // 当前行没有负数，只需要递归处理下半部分
            ans += solve(mid + 1, r, L, R, grid);
        }

        return ans;
    }

    int countNegatives(vector<vector<int>>& grid) {
        return solve(0, (int)grid.size() - 1, 0, (int)grid[0].size() - 1, grid);
    }
};
```

```Java
class Solution {
    private int solve(int l, int r, int L, int R, int[][] grid) {
        if (l > r) {
            return 0;
        }

        int mid = l + (r - l) / 2;
        int pos = -1;
        // 在当前行中查找第一个负数
        for (int i = L; i <= R; i++) {
            if (grid[mid][i] < 0) {
                pos = i;
                break;
            }
        }

        int ans = 0;
        if (pos != -1) {
            // 当前行找到负数，计算当前行的负数个数
            ans += grid[0].length - pos;
            // 递归处理上半部分（使用更小的列范围）
            ans += solve(l, mid - 1, pos, R, grid);
            // 递归处理下半部分（使用相同的列起始范围）
            ans += solve(mid + 1, r, L, pos, grid);
        } else {
            // 当前行没有负数，只需要递归处理下半部分
            ans += solve(mid + 1, r, L, R, grid);
        }
        return ans;
    }

    public int countNegatives(int[][] grid) {
        return solve(0, grid.length - 1, 0, grid[0].length - 1, grid);
    }
}
```

```CSharp
public class Solution {
    private int Solve(int l, int r, int L, int R, int[][] grid) {
        if (l > r) {
            return 0;
        }

        int mid = l + (r - l) / 2;
        int pos = -1;
        // 在当前行中查找第一个负数
        for (int i = L; i <= R; i++) {
            if (grid[mid][i] < 0) {
                pos = i;
                break;
            }
        }
        int ans = 0;
        if (pos != -1) {
            // 当前行找到负数，计算当前行的负数个数
            ans += grid[0].Length - pos;
            // 递归处理上半部分（使用更小的列范围）
            ans += Solve(l, mid - 1, pos, R, grid);
            // 递归处理下半部分（使用相同的列起始范围）
            ans += Solve(mid + 1, r, L, pos, grid);
        } else {
            // 当前行没有负数，只需要递归处理下半部分
            ans += Solve(mid + 1, r, L, R, grid);
        }

        return ans;
    }

    public int CountNegatives(int[][] grid) {
        return Solve(0, grid.Length - 1, 0, grid[0].Length - 1, grid);
    }
}
```

```Go
func countNegatives(grid [][]int) int {
    var solve func(l, r, L, R int) int
    solve = func(l, r, L, R int) int {
        if l > r {
            return 0
        }

        mid := l + (r - l) / 2
        pos := -1
        // 在当前行中查找第一个负数
        for i := L; i <= R; i++ {
            if grid[mid][i] < 0 {
                pos = i
                break
            }
        }

        ans := 0
        if pos != -1 {
            // 当前行找到负数，计算当前行的负数个数
            ans += len(grid[0]) - pos
            // 递归处理上半部分（使用更小的列范围）
            ans += solve(l, mid-1, pos, R)
            // 递归处理下半部分（使用相同的列起始范围）
            ans += solve(mid+1, r, L, pos)
        } else {
            // 当前行没有负数，只需要递归处理下半部分
            ans += solve(mid+1, r, L, R)
        }

        return ans
    }

    return solve(0, len(grid)-1, 0, len(grid[0])-1)
}
```

```Python
class Solution:
    def countNegatives(self, grid: List[List[int]]) -> int:
        def solve(l: int, r: int, L: int, R: int) -> int:
            if l > r:
                return 0
            mid = l + (r - l) // 2
            pos = -1
            # 在当前行中查找第一个负数
            for i in range(L, R + 1):
                if grid[mid][i] < 0:
                    pos = i
                    break
            ans = 0
            if pos != -1:
                # 当前行找到负数，计算当前行的负数个数
                ans += len(grid[0]) - pos
                # 递归处理上半部分（使用更小的列范围）
                ans += solve(l, mid - 1, pos, R)
                # 递归处理下半部分（使用相同的列起始范围）
                ans += solve(mid + 1, r, L, pos)
            else:
                # 当前行没有负数，只需要递归处理下半部分
                ans += solve(mid + 1, r, L, R)

            return ans

        return solve(0, len(grid) - 1, 0, len(grid[0]) - 1)
```

```C
int solve(int l, int r, int L, int R, int** grid, int gridSize, int gridColSize) {
    if (l > r) {
        return 0;
    }

    int mid = l + (r - l) / 2;
    int pos = -1;
    // 在当前行中查找第一个负数
    for (int i = L; i <= R; i++) {
        if (grid[mid][i] < 0) {
            pos = i;
            break;
        }
    }

    int ans = 0;
    if (pos != -1) {
        // 当前行找到负数，计算当前行的负数个数
        ans += gridColSize - pos;
        // 递归处理上半部分（使用更小的列范围）
        ans += solve(l, mid - 1, pos, R, grid, gridSize, gridColSize);
        // 递归处理下半部分（使用相同的列起始范围）
        ans += solve(mid + 1, r, L, pos, grid, gridSize, gridColSize);
    } else {
        // 当前行没有负数，只需要递归处理下半部分
        ans += solve(mid + 1, r, L, R, grid, gridSize, gridColSize);
    }

    return ans;
}

int countNegatives(int** grid, int gridSize, int* gridColSize) {
    return solve(0, gridSize - 1, 0, gridColSize[0] - 1, grid, gridSize, gridColSize[0]);
}
```

```JavaScript
var countNegatives = function(grid) {
    const solve = (l, r, L, R) => {
        if (l > r) {
            return 0;
        }

        const mid = l + Math.floor((r - l) / 2);
        let pos = -1;
        // 在当前行中查找第一个负数
        for (let i = L; i <= R; i++) {
            if (grid[mid][i] < 0) {
                pos = i;
                break;
            }
        }

        let ans = 0;
        if (pos !== -1) {
            // 当前行找到负数，计算当前行的负数个数
            ans += grid[0].length - pos;
            // 递归处理上半部分（使用更小的列范围）
            ans += solve(l, mid - 1, pos, R);
            // 递归处理下半部分（使用相同的列起始范围）
            ans += solve(mid + 1, r, L, pos);
        } else {
            // 当前行没有负数，只需要递归处理下半部分
            ans += solve(mid + 1, r, L, R);
        }

        return ans;
    };

    return solve(0, grid.length - 1, 0, grid[0].length - 1);
};
```

```TypeScript
function countNegatives(grid: number[][]): number {
    const solve = (l: number, r: number, L: number, R: number): number => {
        if (l > r) {
            return 0;
        }

        const mid = l + Math.floor((r - l) / 2);
        let pos = -1;
        // 在当前行中查找第一个负数
        for (let i = L; i <= R; i++) {
            if (grid[mid][i] < 0) {
                pos = i;
                break;
            }
        }

        let ans = 0;
        if (pos !== -1) {
            // 当前行找到负数，计算当前行的负数个数
            ans += grid[0].length - pos;
            // 递归处理上半部分（使用更小的列范围）
            ans += solve(l, mid - 1, pos, R);
            // 递归处理下半部分（使用相同的列起始范围）
            ans += solve(mid + 1, r, L, pos);
        } else {
            // 当前行没有负数，只需要递归处理下半部分
            ans += solve(mid + 1, r, L, R);
        }

        return ans;
    };

    return solve(0, grid.length - 1, 0, grid[0].length - 1);
}
```

```Rust
impl Solution {
    pub fn count_negatives(grid: Vec<Vec<i32>>) -> i32 {
        fn solve(l: i32, r: i32, L: i32, R: i32, grid: &Vec<Vec<i32>>) -> i32 {
            if l > r {
                return 0;
            }

            let mid = l + (r - l) / 2;
            let mut pos = -1;
            // 在当前行中查找第一个负数
            for i in L..=R {
                if grid[mid as usize][i as usize] < 0 {
                    pos = i;
                    break;
                }
            }

            let mut ans = 0;
            if pos != -1 {
                // 当前行找到负数，计算当前行的负数个数
                ans += grid[0].len() as i32 - pos;
                // 递归处理上半部分（使用更小的列范围）
                ans += solve(l, mid - 1, pos, R, grid);
                // 递归处理下半部分（使用相同的列起始范围）
                ans += solve(mid + 1, r, L, pos, grid);
            } else {
                // 当前行没有负数，只需要递归处理下半部分
                ans += solve(mid + 1, r, L, R, grid);
            }

            ans
        }

        solve(0, grid.len() as i32 - 1, 0, grid[0].len() as i32 - 1, &grid)
    }
}
```

**复杂度分析**

- 时间复杂度：代码中找第一个负数的位置是直接遍历 $[L,R]$ 找的，再考虑到 $n$ 和 $m$ 同阶，所以每个 $solve$ 函数里需要消耗 $O(n)$ 的时间，由主定理可得时间复杂度为：
  $$T(n)=2T(n/2)+O(n)=O(n\log n)$$
- 空间复杂度：$O(1)$。

#### 方法四：倒序遍历

考虑方法三发现的性质，我们可以设计一个更简单的方法。考虑我们已经算出第 $i$ 行的从前往后第一个负数的位置 $pos_i$，那么第 $i+1$ 行的时候，$pos_i+1$ 的位置肯定是位于 $[0,pos_i]$ 中，所以对于第 $i+1$ 行我们倒着从 $pos_i$ 循环找 $pos_i+1$ 即可，这个循环起始变量是一直在递减的。

```C++
class Solution {
public:
    int countNegatives(vector<vector<int>>& grid) {
        int num = 0;
        int m = (int)grid[0].size();
        int pos = (int)grid[0].size() - 1;

        for (auto& row : grid) {
            int i;
            for (i = pos; i >= 0; --i) {
                if (row[i] >= 0) {
                    if (i + 1 < m) {
                        pos = i + 1;
                        num += m - pos;
                    }
                    break;
                }
            }
            if (i == -1) {
                num += m;
                pos = -1;
            }
        }

        return num;
    }
};
```

```Java
class Solution {
    public int countNegatives(int[][] grid) {
        int num = 0;
        int m = grid[0].length;
        int pos = grid[0].length - 1;

        for (int[] row : grid) {
            int i;
            for (i = pos; i >= 0; i--) {
                if (row[i] >= 0) {
                    if (i + 1 < m) {
                        pos = i + 1;
                        num += m - pos;
                    }
                    break;
                }
            }
            if (i == -1) {
                num += m;
                pos = -1;
            }
        }

        return num;
    }
}
```

```CSharp
public class Solution {
    public int CountNegatives(int[][] grid) {
        int num = 0;
        int m = grid[0].Length;
        int pos = grid[0].Length - 1;

        foreach (int[] row in grid) {
            int i;
            for (i = pos; i >= 0; i--) {
                if (row[i] >= 0) {
                    if (i + 1 < m) {
                        pos = i + 1;
                        num += m - pos;
                    }
                    break;
                }
            }
            if (i == -1) {
                num += m;
                pos = -1;
            }
        }

        return num;
    }
}
```

```Go
func countNegatives(grid [][]int) int {
    num := 0
    m := len(grid[0])
    pos := len(grid[0]) - 1

    for _, row := range grid {
        i := pos
        for ; i >= 0; i-- {
            if row[i] >= 0 {
                if i + 1 < m {
                    pos = i + 1
                    num += m - pos
                }
                break
            }
        }
        if i == -1 {
            num += m
            pos = -1
        }
    }

    return num
}
```

```Python
class Solution:
    def countNegatives(self, grid: List[List[int]]) -> int:
        num = 0
        m = len(grid[0])
        pos = len(grid[0]) - 1

        for row in grid:
            i = pos
            while i >= 0:
                if row[i] >= 0:
                    if i + 1 < m:
                        pos = i + 1
                        num += m - pos
                    break
                i -= 1
            if i == -1:
                num += m
                pos = -1

        return num
```

```C
int countNegatives(int** grid, int gridSize, int* gridColSize) {
    int num = 0;
    int m = gridColSize[0];
    int pos = gridColSize[0] - 1;

    for (int i = 0; i < gridSize; i++) {
        int j;
        for (j = pos; j >= 0; j--) {
            if (grid[i][j] >= 0) {
                if (j + 1 < m) {
                    pos = j + 1;
                    num += m - pos;
                }
                break;
            }
        }
        if (j == -1) {
            num += m;
            pos = -1;
        }
    }

    return num;
}
```

```JavaScript
var countNegatives = function(grid) {
    let num = 0;
    const m = grid[0].length;
    let pos = grid[0].length - 1;

    for (const row of grid) {
        let i;
        for (i = pos; i >= 0; i--) {
            if (row[i] >= 0) {
                if (i + 1 < m) {
                    pos = i + 1;
                    num += m - pos;
                }
                break;
            }
        }
        if (i === -1) {
            num += m;
            pos = -1;
        }
    }

    return num;
};
```

```TypeScript
function countNegatives(grid: number[][]): number {
    let num = 0;
    const m = grid[0].length;
    let pos = grid[0].length - 1;

    for (const row of grid) {
        let i: number;
        for (i = pos; i >= 0; i--) {
            if (row[i] >= 0) {
                if (i + 1 < m) {
                    pos = i + 1;
                    num += m - pos;
                }
                break;
            }
        }
        if (i === -1) {
            num += m;
            pos = -1;
        }
    }

    return num;
}
```

```Rust
impl Solution {
    pub fn count_negatives(grid: Vec<Vec<i32>>) -> i32 {
        let mut num = 0;
        let m = grid[0].len();
        let mut pos = (grid[0].len() - 1) as i32;

        for row in grid {
            let mut i = pos;
            while i >= 0 {
                if row[i as usize] >= 0 {
                    if i + 1 < m as i32 {
                        pos = i + 1;
                        num += (m as i32) - pos;
                    }
                    break;
                }
                i -= 1;
            }
            if i == -1 {
                num += m as i32;
                pos = -1;
            }
        }

        num
    }
}
```

**复杂度分析**

- 时间复杂度：考虑每次循环变量的起始位置是单调不降的，所以起始位置最多移动 $m$ 次，时间复杂度 $O(n+m)$。
- 空间复杂度：$O(1)$。
