### [构造相同颜色的正方形](https://leetcode.cn/problems/make-a-square-with-the-same-color/solutions/2892989/gou-zao-xiang-tong-yan-se-de-zheng-fang-qhll8/)

#### 方法一：枚举

枚举矩阵 $grid$ 内所有 $2 \times 2$ 的正方形，如果存在一个正方形黑色和白色的数目都不等于 $2$，那么该正方形可以被改变成颜色完全相同的正方形，返回 $true$，否则返回 $false$。

```C++
class Solution {
public:
    bool canMakeSquare(vector<vector<char>>& grid) {
        for (int i = 0; i <= 1; i++) {
            for (int j = 0; j <= 1; j++) {
                if (check(grid, i, j)) {
                    return true;
                }
            }
        }
        return false;
    }
    bool check(vector<vector<char>> &grid, int x, int y) {
        int count = 0;
        for (int i = 0; i <= 1; i++) {
            for (int j = 0; j <= 1; j++) {
                count += (grid[x + i][y + j] == 'B');
            }
        }
        return count != 2;
    }
};
```

```Go
func canMakeSquare(grid [][]byte) bool {
    for i := 0; i <= 1; i++ {
        for j := 0; j <= 1; j++ {
            if check(grid, i, j) {
                return true
            }
        }
    }
    return false
}
func check(grid[][]byte, x, y int) bool {
    count := 0
    for i := 0; i <= 1; i++ {
        for j := 0; j <= 1; j++ {
            if grid[x + i][y + j] == 'B' {
                count++
            }
        }
    }
    return count != 2
}
```

```Java
class Solution {
    public boolean canMakeSquare(char[][] grid) {
        for (int i = 0; i <= 1; i++) {
            for (int j = 0; j <= 1; j++) {
                if (check(grid, i, j)) {
                    return true;
                }
            }
        }
        return false;
    }

    public boolean check(char[][] grid, int x, int y) {
        int count = 0;
        for (int i = 0; i <= 1; i++) {
            for (int j = 0; j <= 1; j++) {
                if (grid[x + i][y + j] == 'B') {
                    count++;
                }
            }
        }
        return count != 2;
    }
}
```

```CSharp
public class Solution {
    public bool CanMakeSquare(char[][] grid) {
        for (int i = 0; i <= 1; i++) {
            for (int j = 0; j <= 1; j++) {
                if (Check(grid, i, j)) {
                    return true;
                }
            }
        }
        return false;
    }

    public bool Check(char[][] grid, int x, int y) {
        int count = 0;
        for (int i = 0; i <= 1; i++) {
            for (int j = 0; j <= 1; j++) {
                if (grid[x + i][y + j] == 'B') {
                    count++;
                }
            }
        }
        return count != 2;
    }
}
```

```Python
class Solution:
    def canMakeSquare(self, grid: List[List[str]]) -> bool:
        for i in range(2):
            for j in range(2):
                if self.check(grid, i, j):
                    return True
        return False

    def check(self, grid: List[List[str]], x: int, y: int) -> bool:
        count = 0
        for i in range(2):
            for j in range(2):
                count += (grid[x + i][y + j] == 'B')
        return count != 2
```

```C
bool check(char** grid, int x, int y) {
    int count = 0;
    for (int i = 0; i <= 1; i++) {
        for (int j = 0; j <= 1; j++) {
            count += (grid[x + i][y + j] == 'B');
        }
    }
    return count != 2;
}

bool canMakeSquare(char** grid, int gridSize, int* gridColSize) {
    for (int i = 0; i <= 1; i++) {
        for (int j = 0; j <= 1; j++) {
            if (check(grid, i, j)) {
                return true;
            }
        }
    }
    return false;
}
```

```JavaScript
var canMakeSquare = function(grid) {
    for (let i = 0; i <= 1; i++) {
        for (let j = 0; j <= 1; j++) {
            if (check(grid, i, j)) {
                return true;
            }
        }
    }
    return false;
};

var check = function(grid, x, y) {
    let count = 0;
    for (let i = 0; i <= 1; i++) {
        for (let j = 0; j <= 1; j++) {
            if (grid[x + i][y + j] == 'B') {
                count++;
            }
        }
    }
    return count != 2;
};
```

```TypeScript
function canMakeSquare(grid: string[][]): boolean {
    for (let i = 0; i <= 1; i++) {
        for (let j = 0; j <= 1; j++) {
            if (check(grid, i, j)) {
                return true;
            }
        }
    }
    return false;
};

var check = function(grid: string[][], x, y): boolean {
    let count = 0;
    for (let i = 0; i <= 1; i++) {
        for (let j = 0; j <= 1; j++) {
            if (grid[x + i][y + j] == 'B') {
                count++;
            }
        }
    }
    return count != 2;
};
```

```Rust
impl Solution {
    pub fn check(grid: &Vec<Vec<char>>, x: i32, y: i32) -> bool {
        let mut count = 0;
        for i in 0..2 {
            for j in 0..2 {
                if grid[(x + i) as usize][(y + j) as usize] == 'B' {
                    count += 1;
                }
            }
        }
        count != 2
    }
    pub fn can_make_square(mut grid: Vec<Vec<char>>) -> bool {
        for i in 0..2 {
            for j in 0..2 {
                if Self::check(&grid, i, j) {
                    return true
                }
            }
        }
        false
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
