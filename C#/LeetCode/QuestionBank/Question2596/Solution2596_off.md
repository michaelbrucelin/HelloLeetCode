### [检查骑士巡视方案](https://leetcode.cn/problems/check-knight-tour-configuration/solutions/2431329/jian-cha-qi-shi-xun-shi-fang-an-by-leetc-iw17/?envType=daily-question&envId=2023-09-13)

#### 方法一：直接模拟

题目要求骑士的移动的每一步均按照「**日**」字形跳跃，假设从位置 $(x_1, y_1)$ 跳跃到 $(x_2, y_2)$，则此时一定满足下面两种情形之一：

-   $|x_1 - x_2| = 1, |y_1 - y_2| = 2$；
-   $|x_1 - x_2| = 2, |y_1 - y_2| = 1$。

设矩阵的长度为 $n$，其中 $grid[row][col]$ 表示单元格 $(row, col)$ 是骑士访问的第 $grid[row][col]$ 个单元格，因此可以知道每个单元格的访问顺序，我们用 $indices$ 存储单元格的访问顺序，其中 $indices[i]$ 表示骑士在经过第 $i-1$ 次跳跃后的位置。由于骑士的行动是从下标 $0$ 开始的，因此一定需要满足 $grid[0][0] = 0$，接下来依次遍历 $indices$ 中的每个元素。由于 $indices[i]$ 是一次跳跃的起点，$indices[i+1]$ 是该次跳跃的终点，则依次检测每一次跳跃的行动路径是否为「**日**」字形，即满足如下条件：

-   $|indices[i][0] - indices[i+1][0]| = 1, |indices[i][1] - indices[i+1][1]| = 2$；
-   $|indices[i][0] - indices[i+1][0]| = 2, |indices[i][1] - indices[i+1][1]| = 1$。

为了方便计算，我们只需检测 $|x_1 - x_2| \times |y_1 - y_2|$ 是否等于 $2$ 即可。如果所有跳跃路径均合法则返回 $true$，否则返回 $false$。

**思路与算法**

**代码**

```cpp
class Solution {
public:
    bool checkValidGrid(vector<vector<int>>& grid) {
        if (grid[0][0] != 0) {
            return false;
        }
        int n = grid.size();
        vector<array<int, 2>> indices(n * n);
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                indices[grid[i][j]] = {i, j};
            }
        }
        for (int i = 1; i < indices.size(); i++) {
            int dx = abs(indices[i][0] - indices[i - 1][0]);
            int dy = abs(indices[i][1] - indices[i - 1][1]);
            if (dx * dy != 2) {
                return false;
            }
        }
        return true;
    }
};
```

```c
bool checkValidGrid(int** grid, int gridSize, int* gridColSize) {
    if (grid[0][0] != 0) {
        return false;
    }
    int n = gridSize;
    int indices[n * n][2];
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            indices[grid[i][j]][0] = i;
            indices[grid[i][j]][1] = j;
        }
    }
    for (int i = 1; i < n * n; i++) {
        int dx = abs(indices[i][0] - indices[i - 1][0]);
        int dy = abs(indices[i][1] - indices[i - 1][1]);
        if (dx * dy != 2) {
            return false;
        }
    }
    return true;
}
```

```java
class Solution {
    public boolean checkValidGrid(int[][] grid) {
        if (grid[0][0] != 0) {
            return false;
        }
        int n = grid.length;
        int[][] indices = new int[n * n][2];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                indices[grid[i][j]][0] = i;
                indices[grid[i][j]][1] = j;
            }
        }
        for (int i = 1; i < n * n; i++) {
            int dx = Math.abs(indices[i][0] - indices[i - 1][0]);
            int dy = Math.abs(indices[i][1] - indices[i - 1][1]);
            if (dx * dy != 2) {
                return false;
            }
        }
        return true;
    }
}
```

```csharp
public class Solution {
    public bool CheckValidGrid(int[][] grid) {
        if (grid[0][0] != 0) {
            return false;
        }
        int n = grid.Length;
        int[][] indices = new int[n * n][];
        for (int i = 0; i < n * n; i++) {
            indices[i] = new int[2];
        }
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                indices[grid[i][j]][0] = i;
                indices[grid[i][j]][1] = j;
            }
        }
        for (int i = 1; i < n * n; i++) {
            int dx = Math.Abs(indices[i][0] - indices[i - 1][0]);
            int dy = Math.Abs(indices[i][1] - indices[i - 1][1]);
            if (dx * dy != 2) {
                return false;
            }
        }
        return true;
    }
}
```

```python
class Solution:
    def checkValidGrid(self, grid: List[List[int]]) -> bool:
        if grid[0][0] != 0:
            return False
        n = len(grid)
        indices = [[] for _ in range(n * n)]
        for i in range(n):
            for j in range(n):
                indices[grid[i][j]] = [i, j]
        for i in range(1, n * n, 1):
            dx = abs(indices[i][0] - indices[i - 1][0])
            dy = abs(indices[i][1] - indices[i - 1][1])
            if dx * dy != 2:
                return False
        return True
```

```go
func checkValidGrid(grid [][]int) bool {
    if grid[0][0] != 0 {
        return false;
    }
    n := len(grid)
    indices := make([][2]int, n * n)
    for i := 0; i < n; i++ {
        for j := 0; j < n; j++ {
            indices[grid[i][j]][0] = i;
            indices[grid[i][j]][1] = j;
        }
    }
    for i := 1; i < n * n; i++ {
        dx := abs(indices[i][0] - indices[i - 1][0])
        dy := abs(indices[i][1] - indices[i - 1][1])
        if dx * dy != 2 {
            return false
        }
    }
    return true
}

func abs(x int) int { 
    if x < 0 { 
        return -x 
    }
    return x 
}
```

```javascript
var checkValidGrid = function(grid) {
    if (grid[0][0] != 0) {
        return false;
    }
    const n = grid.length;
    let indices = Array(n * n).fill().map(() => Array(2));
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            indices[grid[i][j]][0] = i;
            indices[grid[i][j]][1] = j;
        }
    }
    for (let i = 1; i < n * n; i++) {
        let dx = Math.abs(indices[i][0] - indices[i - 1][0]);
        let dy = Math.abs(indices[i][1] - indices[i - 1][1]);
        if (dx * dy != 2) {
            return false;
        }
    }
    return true;
};
```

**复杂度分析**

-   时间复杂度：$O(n^2)$，其中 $n$ 表示二维棋盘边的长度。需要检测棋盘中的每个位置，一共需要检测 $n^2$ 个位置，因此时间复杂度为 $O(n^2)$。
-   空间复杂度：$O(n^2)$，其中 $n$ 表示二维棋盘边的长度。用来需要存放每个位置的访问顺序，一共有 $n^2$ 个位置，需要的空间为 $O(n^2)$。
