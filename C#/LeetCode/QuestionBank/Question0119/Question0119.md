#### [119\. 杨辉三角 II](https://leetcode.cn/problems/pascals-triangle-ii/)

难度：简单

给定一个非负索引 `rowIndex`，返回「杨辉三角」的第 `rowIndex` 行。

在「杨辉三角」中，每个数是它左上方和右上方的数的和。

![](./assets/img/Question0119_01.gif)

**示例 1:**

```
输入: rowIndex = 3
输出: [1,3,3,1]
```

**示例 2:**

```
输入: rowIndex = 0
输出: [1]
```

**示例 3:**

```
输入: rowIndex = 1
输出: [1,1]
```

**提示:**

-   `0 <= rowIndex <= 33`

**进阶：**

你可以优化你的算法到 _`O(rowIndex)`_ 空间复杂度吗？
