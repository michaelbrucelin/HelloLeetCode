﻿#### [1139\. 最大的以 1 为边界的正方形](https://leetcode.cn/problems/largest-1-bordered-square/)

难度：中等

给你一个由若干 `0` 和 `1` 组成的二维网格 `grid`，请你找出边界全部由 `1` 组成的最大 **正方形** 子网格，并返回该子网格中的元素数量。如果不存在，则返回 `0`。

**示例 1：**

```
输入：grid = [[1,1,1],[1,0,1],[1,1,1]]
输出：9
```

**示例 2：**

```
输入：grid = [[1,1,0,0]]
输出：1
```

**提示：**

-   `1 <= grid.length <= 100`
-   `1 <= grid[0].length <= 100`
-   `grid[i][j]` 为 `0` 或 `1`
