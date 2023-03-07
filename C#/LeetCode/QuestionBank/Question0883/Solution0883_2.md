﻿#### [方法一：数学](https://leetcode.cn/problems/projection-area-of-3d-shapes/solutions/1444594/san-wei-xing-ti-tou-ying-mian-ji-by-leet-d66y/)

**思路与算法**

根据题意，$x$ 轴对应行，$y$ 轴对应列，$z$ 轴对应网格的数值。

因此：

-   $xy$ 平面的投影面积等于网格上非零数值的数目；
-   $yz$ 平面的投影面积等于网格上每一列最大数值之和；
-   $zx$ 平面的投影面积等于网格上每一行最大数值之和。

返回上述三个投影面积之和。

**代码**

```python
class Solution:
    def projectionArea(self, grid: List[List[int]]) -> int:
        xyArea = sum(v > 0 for row in grid for v in row)
        yzArea = sum(map(max, zip(*grid)))  # 注意这里为 O(n) 空间复杂度，改为下标枚举则可以 O(1)
        zxArea = sum(map(max, grid))
        return xyArea + yzArea + zxArea
```

```cpp
class Solution {
public:
    int projectionArea(vector<vector<int>> &grid) {
        int n = grid.size();
        int xyArea = 0, yzArea = 0, zxArea = 0;
        for (int i = 0; i < n; i++) {
            int yzHeight = 0, zxHeight = 0;
            for (int j = 0; j < n; j++) {
                xyArea += grid[i][j] > 0 ? 1 : 0;
                yzHeight = max(yzHeight, grid[j][i]);
                zxHeight = max(zxHeight, grid[i][j]);
            }
            yzArea += yzHeight;
            zxArea += zxHeight;
        }
        return xyArea + yzArea + zxArea;
    }
};
```

```java
class Solution {
    public int projectionArea(int[][] grid) {
        int n = grid.length;
        int xyArea = 0, yzArea = 0, zxArea = 0;
        for (int i = 0; i < n; i++) {
            int yzHeight = 0, zxHeight = 0;
            for (int j = 0; j < n; j++) {
                xyArea += grid[i][j] > 0 ? 1 : 0;
                yzHeight = Math.max(yzHeight, grid[j][i]);
                zxHeight = Math.max(zxHeight, grid[i][j]);
            }
            yzArea += yzHeight;
            zxArea += zxHeight;
        }
        return xyArea + yzArea + zxArea;
    }
}
```

```csharp
public class Solution {
    public int ProjectionArea(int[][] grid) {
        int n = grid.Length;
        int xyArea = 0, yzArea = 0, zxArea = 0;
        for (int i = 0; i < n; i++) {
            int yzHeight = 0, zxHeight = 0;
            for (int j = 0; j < n; j++) {
                xyArea += grid[i][j] > 0 ? 1 : 0;
                yzHeight = Math.Max(yzHeight, grid[j][i]);
                zxHeight = Math.Max(zxHeight, grid[i][j]);
            }
            yzArea += yzHeight;
            zxArea += zxHeight;
        }
        return xyArea + yzArea + zxArea;
    }
}
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int projectionArea(int** grid, int gridSize, int* gridColSize) {
    int xyArea = 0, yzArea = 0, zxArea = 0;
    for (int i = 0; i < gridSize; i++) {
        int yzHeight = 0, zxHeight = 0;
        for (int j = 0; j < gridSize; j++) {
            xyArea += grid[i][j] > 0 ? 1 : 0;
            yzHeight = MAX(yzHeight, grid[j][i]);
            zxHeight = MAX(zxHeight, grid[i][j]);
        }
        yzArea += yzHeight;
        zxArea += zxHeight;
    }
    return xyArea + yzArea + zxArea;
}
```

```go
func projectionArea(grid [][]int) int {
    var xyArea, yzArea, zxArea int
    for i, row := range grid {
        yzHeight, zxHeight := 0, 0
        for j, v := range row {
            if v > 0 {
                xyArea++
            }
            yzHeight = max(yzHeight, grid[j][i])
            zxHeight = max(zxHeight, v)
        }
        yzArea += yzHeight
        zxArea += zxHeight
    }
    return xyArea + yzArea + zxArea
}

func max(a, b int) int {
    if b > a {
        return b
    }
    return a
}
```

```javascript
var projectionArea = function(grid) {
    const n = grid.length;
    let xyArea = 0, yzArea = 0, zxArea = 0;
    for (let i = 0; i < n; i++) {
        let yzHeight = 0, zxHeight = 0;
        for (let j = 0; j < n; j++) {
            xyArea += grid[i][j] > 0 ? 1 : 0;
            yzHeight = Math.max(yzHeight, grid[j][i]);
            zxHeight = Math.max(zxHeight, grid[i][j]);
        }
        yzArea += yzHeight;
        zxArea += zxHeight;
    }
    return xyArea + yzArea + zxArea;
};
```

**复杂度分析**

-   时间复杂度：$O(n^2)$，其中 $n$ 是网格的行数或列数。
-   空间复杂度：$O(1)$。
