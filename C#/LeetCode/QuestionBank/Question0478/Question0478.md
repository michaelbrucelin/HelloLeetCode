### [478\. 在圆内随机生成点](https://leetcode.cn/problems/generate-random-point-in-a-circle/)

难度：中等

给定圆的半径和圆心的位置，实现函数 `randPoint`，在圆中产生均匀随机点。

实现 `Solution` 类:

- `Solution(double radius, double x_center, double y_center)` 用圆的半径 `radius` 和圆心的位置 `(x_center, y_center)` 初始化对象
- `randPoint()` 返回圆内的一个随机点。圆周上的一点被认为在圆内。答案作为数组返回 `[x, y]`。

**示例 1：**

> **输入:**
> ["Solution","randPoint","randPoint","randPoint"]
> \[[1.0, 0.0, 0.0], [], [], []]
> **输出:** [null, [-0.02493, -0.38077], [0.82314, 0.38945], [0.36572, 0.17248]]
> **解释:**
>
> ```c
> Solution solution = new Solution(1.0, 0.0, 0.0);
> solution.randPoint ();  //返回[-0.02493，-0.38077]
> solution.randPoint ();  //返回[0.82314,0.38945]
> solution.randPoint ();  //返回[0.36572,0.17248]
> ```

**提示：**

- <code>0 < radius <= 10<sup>8</sup></code>
- <code>-10<sup>7</sup> <= x_center, y_center <= 10<sup>7</sup></code>
- `randPoint` 最多被调用 <code>3 &times; 10<sup>4</sup></code> 次
