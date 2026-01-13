### [3454\. 分割正方形 II](https://leetcode.cn/problems/separate-squares-ii/)

难度：困难

给你一个二维整数数组 `squares`，其中 <code>squares[i] = [x<sub>i</sub>, y<sub>i</sub>, l<sub>i</sub>]</code> 表示一个与 x 轴平行的正方形的左下角坐标和正方形的边长。

找到一个**最小的** y 坐标，它对应一条水平线，该线需要满足它以上正方形的总面积 **等于** 该线以下正方形的总面积。

答案如果与实际答案的误差在 <code>10<sup>-5</sup></code> 以内，将视为正确答案。

**注意**：正方形 **可能会** 重叠。重叠区域只 **统计一次**。

**示例 1：**

> **输入：** squares = \[[0,0,1],[2,2,1]]
> **输出：** 1.00000
> **解释：**
> ![](./assets/img/Question3454_01.png)
> 任何在 `y = 1` 和 `y = 2` 之间的水平线都会有 1 平方单位的面积在其上方，1 平方单位的面积在其下方。最小的 y 坐标是 1。

**示例 2：**

> **输入：** squares = \[[0,0,2],[1,1,1]]
> **输出：** 1.00000
> **解释：**
> ![](./assets/img/Question3454_02.png)
> 由于蓝色正方形和红色正方形有重叠区域且重叠区域只统计一次。所以直线 `y = 1` 将正方形分割成两部分且面积相等。

**提示：**

- <code>1 <= squares.length <= 5 &times; 10<sup>4</sup></code>
- <code>squares[i] = [x<sub>i</sub>, y<sub>i</sub>, l<sub>i</sub>]</code>
- `squares[i].length == 3`
- <code>0 <= x<sub>i</sub>, y<sub>i</sub> <= 10<sup>9</sup></code>
- <code>1 <= l<sub>i</sub> <= 10<sup>9</sup></code>
- 所有正方形的总面积不超过 <code>10<sup>15</sup></code>
