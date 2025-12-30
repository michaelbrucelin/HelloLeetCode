### [矩阵中的幻方](https://leetcode.cn/problems/magic-squares-in-grid/solutions/3862617/ju-zhen-zhong-de-huan-fang-by-leetcode-s-kp0c/)

#### 方法一：暴力法

**算法：**

我们分别检查每 $3\times 3$ 的网格。对于每个网格，所有数字必须不同，并且在 $1$ 到 $9$ 之间；且每一个行，列，对角线的和必须相同。

**额外的加分项：**

我们可以在代码中添加 `if grid[r+1][c+1] != 5: continue`，帮助我们略过一些循环，这是基于以下观察得出：

- 网格的总和是 $45$，因为网格必须是 $1$ 到 $9$ 不同的数字。
- 每一列和行加起来必须是 $15$，乘以 $3$ 则是网格的总和。
- 对角线的和也必须是 $15$，题目中说了对角线与列，行的和相同。
- 将四条穿过中心的线的 $12$ 个值相加（即一行一列两条对角线），这四条线加起来等于 $60$；而整个网格加起来为 $45$。则中心等于 $\dfrac{60-45}{3}=5$。

```Python
class Solution:
    def numMagicSquaresInside(self, grid: List[List[int]]) -> int:
        R, C = len(grid), len(grid[0])

        def magic(a: int, b: int, c: int, d: int, e: int, f: int, g: int, h: int, i: int) -> bool:
            return (
                sorted([a, b, c, d, e, f, g, h, i]) == list(range(1, 10)) and
                (a + b + c == d + e + f == g + h + i ==
                 a + d + g == b + e + h == c + f + i ==
                 a + e + i == c + e + g == 15)
            )

        ans = 0
        for r in range(R - 2):
            for c in range(C - 2):
                if grid[r + 1][c + 1] != 5:
                    continue
                if magic(
                    grid[r][c], grid[r][c + 1], grid[r][c + 2],
                    grid[r + 1][c], grid[r + 1][c + 1], grid[r + 1][c + 2],
                    grid[r + 2][c], grid[r + 2][c + 1], grid[r + 2][c + 2]
                ):
                    ans += 1

        return ans
```

```Java
class Solution {
    public int numMagicSquaresInside(int[][] grid) {
        int rows = grid.length;
        int cols = grid[0].length;
        int count = 0;

        for (int r = 0; r < rows - 2; r++) {
            for (int c = 0; c < cols - 2; c++) {
                if (grid[r + 1][c + 1] != 5) {
                    continue;
                }
                if (isMagicSquare(
                    grid[r][c], grid[r][c + 1], grid[r][c + 2],
                    grid[r + 1][c], grid[r + 1][c + 1], grid[r + 1][c + 2],
                    grid[r + 2][c], grid[r + 2][c + 1], grid[r + 2][c + 2]
                )) {
                    count++;
                }
            }
        }

        return count;
    }


    private boolean isMagicSquare(int... vals) {
        int[] frequency = new int[16];
        for (int value : vals) {
            if (value < 1 || value > 9) {
                return false;
            }
            frequency[value]++;
        }
        for (int num = 1; num <= 9; num++) {
            if (frequency[num] != 1) {
                return false;
            }
        }

        return (vals[0] + vals[1] + vals[2] == 15 && // 第一行
                vals[3] + vals[4] + vals[5] == 15 && // 第二行
                vals[6] + vals[7] + vals[8] == 15 && // 第三行
                vals[0] + vals[3] + vals[6] == 15 && // 第一列
                vals[1] + vals[4] + vals[7] == 15 && // 第二列
                vals[2] + vals[5] + vals[8] == 15 && // 第三列
                vals[0] + vals[4] + vals[8] == 15 && // 主对角线
                vals[2] + vals[4] + vals[6] == 15);  // 副对角线
    }
}
```

```C++
class Solution {
public:
    int numMagicSquaresInside(vector<vector<int>>& grid) {
        int rows = grid.size();
        int cols = grid[0].size();
        int count = 0;
        for (int r = 0; r < rows - 2; r++) {
            for (int c = 0; c < cols - 2; c++) {
                if (grid[r + 1][c + 1] != 5) {
                    continue;
                }
                if (isMagicSquare(
                    grid[r][c], grid[r][c + 1], grid[r][c + 2],
                    grid[r + 1][c], grid[r + 1][c + 1], grid[r + 1][c + 2],
                    grid[r + 2][c], grid[r + 2][c + 1], grid[r + 2][c + 2]
                )) {
                    count++;
                }
            }
        }

        return count;
    }

private:
    bool isMagicSquare(int a, int b, int c, int d, int e, int f, int g, int h, int i) {
        vector<int> vals = {a, b, c, d, e, f, g, h, i};
        vector<int> frequency(16, 0);
        for (int value : vals) {
            if (value < 1 || value > 9) {
                return false;
            }
            frequency[value]++;
        }

        for (int num = 1; num <= 9; num++) {
            if (frequency[num] != 1) {
                return false;
            }
        }

        return (a + b + c == 15 && // 第一行
                d + e + f == 15 && // 第二行
                g + h + i == 15 && // 第三行
                a + d + g == 15 && // 第一列
                b + e + h == 15 && // 第二列
                c + f + i == 15 && // 第三列
                a + e + i == 15 && // 主对角线
                c + e + g == 15);  // 副对角线
    }
};
```

```CSharp
public class Solution {
    public int NumMagicSquaresInside(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int count = 0;

        for (int r = 0; r < rows - 2; r++) {
            for (int c = 0; c < cols - 2; c++) {
                if (grid[r + 1][c + 1] != 5) {
                    continue;
                }
                if (IsMagicSquare(
                    grid[r][c], grid[r][c + 1], grid[r][c + 2],
                    grid[r + 1][c], grid[r + 1][c + 1], grid[r + 1][c + 2],
                    grid[r + 2][c], grid[r + 2][c + 1], grid[r + 2][c + 2]
                )) {
                    count++;
                }
            }
        }

        return count;
    }

    private bool IsMagicSquare(params int[] vals) {
        int[] frequency = new int[16];

        foreach (int value in vals) {
            if (value < 1 || value > 9) {
                return false;
            }
            frequency[value]++;
        }

        for (int num = 1; num <= 9; num++) {
            if (frequency[num] != 1) {
                return false;
            }
        }

        return (vals[0] + vals[1] + vals[2] == 15 && // 第一行
                vals[3] + vals[4] + vals[5] == 15 && // 第二行
                vals[6] + vals[7] + vals[8] == 15 && // 第三行
                vals[0] + vals[3] + vals[6] == 15 && // 第一列
                vals[1] + vals[4] + vals[7] == 15 && // 第二列
                vals[2] + vals[5] + vals[8] == 15 && // 第三列
                vals[0] + vals[4] + vals[8] == 15 && // 主对角线
                vals[2] + vals[4] + vals[6] == 15);  // 副对角线
    }
}
```

```Go
func numMagicSquaresInside(grid [][]int) int {
    rows := len(grid)
    cols := len(grid[0])
    count := 0

    for r := 0; r < rows - 2; r++ {
        for c := 0; c < cols - 2; c++ {
            if grid[r + 1][c + 1] != 5 {
                continue
            }
            if isMagicSquare(
                grid[r][c], grid[r][c + 1], grid[r][c + 2],
                grid[r + 1][c], grid[r + 1][c + 1], grid[r + 1][c + 2],
                grid[r + 2][c], grid[r + 2][c + 1], grid[r + 2][c + 2],
            ) {
                count++
            }
        }
    }

    return count
}

func isMagicSquare(vals ...int) bool {
    frequency := make([]int, 16)
    for _, value := range vals {
        if value < 1 || value > 9 {
            return false
        }
        frequency[value]++
    }
    for num := 1; num <= 9; num++ {
        if frequency[num] != 1 {
            return false
        }
    }
    return vals[0] + vals[1] + vals[2] == 15 && // 第一行
           vals[3] + vals[4] + vals[5] == 15 && // 第二行
           vals[6] + vals[7] + vals[8] == 15 && // 第三行
           vals[0] + vals[3] + vals[6] == 15 && // 第一列
           vals[1] + vals[4] + vals[7] == 15 && // 第二列
           vals[2] + vals[5] + vals[8] == 15 && // 第三列
           vals[0] + vals[4] + vals[8] == 15 && // 主对角线
           vals[2] + vals[4] + vals[6] == 15    // 副对角线
}
```

```C
#include <stdbool.h>

bool isMagicSquare(int a, int b, int c, int d, int e, int f, int g, int h, int i) {
    int vals[9] = {a, b, c, d, e, f, g, h, i};
    int frequency[16] = {0};
    for (int j = 0; j < 9; j++) {
        int value = vals[j];
        if (value < 1 || value > 9) {
            return false;
        }
        frequency[value]++;
    }
    for (int num = 1; num <= 9; num++) {
        if (frequency[num] != 1) {
            return false;
        }
    }

    return (a + b + c == 15 && // 第一行
            d + e + f == 15 && // 第二行
            g + h + i == 15 && // 第三行
            a + d + g == 15 && // 第一列
            b + e + h == 15 && // 第二列
            c + f + i == 15 && // 第三列
            a + e + i == 15 && // 主对角线
            c + e + g == 15);  // 副对角线
}

int numMagicSquaresInside(int** grid, int gridSize, int* gridColSize) {
    int rows = gridSize;
    int cols = gridColSize[0];
    int count = 0;

    for (int r = 0; r < rows - 2; r++) {
        for (int c = 0; c < cols - 2; c++) {
            if (grid[r + 1][c + 1] != 5) {
                continue;
            }
            if (isMagicSquare(
                grid[r][c], grid[r][c + 1], grid[r][c + 2],
                grid[r + 1][c], grid[r + 1][c + 1], grid[r + 1][c + 2],
                grid[r + 2][c], grid[r + 2][c + 1], grid[r + 2][c + 2]
            )) {
                count++;
            }
        }
    }

    return count;
}
```

```JavaScript
var numMagicSquaresInside = function(grid) {
    const rows = grid.length;
    const cols = grid[0].length;
    let count = 0;

    for (let r = 0; r < rows - 2; r++) {
        for (let c = 0; c < cols - 2; c++) {
            if (grid[r + 1][c + 1] !== 5) {
                continue;
            }
            if (isMagicSquare(
                grid[r][c], grid[r][c + 1], grid[r][c + 2],
                grid[r + 1][c], grid[r + 1][c + 1], grid[r + 1][c + 2],
                grid[r + 2][c], grid[r + 2][c + 1], grid[r + 2][c + 2]
            )) {
                count++;
            }
        }
    }

    return count;
};

function isMagicSquare(...vals) {
    const frequency = new Array(16).fill(0);
    for (const value of vals) {
        if (value < 1 || value > 9) {
            return false;
        }
        frequency[value]++;
    }
    for (let num = 1; num <= 9; num++) {
        if (frequency[num] !== 1) {
            return false;
        }
    }

    return (vals[0] + vals[1] + vals[2] === 15 && // 第一行
            vals[3] + vals[4] + vals[5] === 15 && // 第二行
            vals[6] + vals[7] + vals[8] === 15 && // 第三行
            vals[0] + vals[3] + vals[6] === 15 && // 第一列
            vals[1] + vals[4] + vals[7] === 15 && // 第二列
            vals[2] + vals[5] + vals[8] === 15 && // 第三列
            vals[0] + vals[4] + vals[8] === 15 && // 主对角线
            vals[2] + vals[4] + vals[6] === 15);  // 副对角线
}
```

```TypeScript
function numMagicSquaresInside(grid: number[][]): number {
    const rows: number = grid.length;
    const cols: number = grid[0].length;
    let count: number = 0;

    for (let r = 0; r < rows - 2; r++) {
        for (let c = 0; c < cols - 2; c++) {
            if (grid[r + 1][c + 1] !== 5) {
                continue;
            }
            if (isMagicSquare(
                grid[r][c], grid[r][c + 1], grid[r][c + 2],
                grid[r + 1][c], grid[r + 1][c + 1], grid[r + 1][c + 2],
                grid[r + 2][c], grid[r + 2][c + 1], grid[r + 2][c + 2]
            )) {
                count++;
            }
        }
    }

    return count;
}

function isMagicSquare(...vals: number[]): boolean {
    const frequency: number[] = new Array(16).fill(0);

    for (const value of vals) {
        if (value < 1 || value > 9) {
            return false;
        }
        frequency[value]++;
    }
    for (let num = 1; num <= 9; num++) {
        if (frequency[num] !== 1) {
            return false;
        }
    }

    return (vals[0] + vals[1] + vals[2] === 15 && // 第一行
            vals[3] + vals[4] + vals[5] === 15 && // 第二行
            vals[6] + vals[7] + vals[8] === 15 && // 第三行
            vals[0] + vals[3] + vals[6] === 15 && // 第一列
            vals[1] + vals[4] + vals[7] === 15 && // 第二列
            vals[2] + vals[5] + vals[8] === 15 && // 第三列
            vals[0] + vals[4] + vals[8] === 15 && // 主对角线
            vals[2] + vals[4] + vals[6] === 15);  // 副对角线
}
```

```Rust
impl Solution {
    pub fn num_magic_squares_inside(grid: Vec<Vec<i32>>) -> i32 {
        let rows = grid.len();
        let cols = grid[0].len();
        let mut count = 0;
        if rows < 3 || cols < 3 {
            return 0
        }
        for r in 0..rows - 2 {
            for c in 0..cols - 2 {
                if grid[r + 1][c + 1] != 5 {
                    continue;
                }
                if Self::is_magic_square(
                    grid[r][c], grid[r][c + 1], grid[r][c + 2],
                    grid[r + 1][c], grid[r + 1][c + 1], grid[r + 1][c + 2],
                    grid[r + 2][c], grid[r + 2][c + 1], grid[r + 2][c + 2]
                ) {
                    count += 1;
                }
            }
        }

        count
    }

    fn is_magic_square(a: i32, b: i32, c: i32, d: i32, e: i32, f: i32, g: i32, h: i32, i: i32) -> bool {
        let vals = [a, b, c, d, e, f, g, h, i];
        let mut frequency = [0; 16];
        for &value in vals.iter() {
            if value < 1 || value > 9 {
                return false;
            }
            frequency[value as usize] += 1;
        }

        for num in 1..=9 {
            if frequency[num] != 1 {
                return false;
            }
        }

        a + b + c == 15 && // 第一行
        d + e + f == 15 && // 第二行
        g + h + i == 15 && // 第三行
        a + d + g == 15 && // 第一列
        b + e + h == 15 && // 第二列
        c + f + i == 15 && // 第三列
        a + e + i == 15 && // 主对角线
        c + e + g == 15    // 副对角线
    }
}
```

**复杂度分析**

- 时间复杂度：$O(R \times C)$。其中 $R,C$ 指的是给定 $grid$ 的行和列。
- 空间复杂度：$O(1)$。
