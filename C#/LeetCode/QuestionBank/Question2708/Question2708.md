### [2708\. 一个小组的最大实力值](https://leetcode.cn/problems/maximum-strength-of-a-group/)

难度：中等

给你一个下标从 **0** 开始的整数数组 `nums` ，它表示一个班级中所有学生在一次考试中的成绩。老师想选出一部分同学组成一个 **非空** 小组，且这个小组的 **实力值** 最大，如果这个小组里的学生下标为 <code>i<sub>0</sub></code>, <code>i<sub>1</sub></code>, <code>i<sub>2</sub></code>, ... , <code>i<sub>k</sub></code> ，那么这个小组的实力值定义为 <code>nums[i<sub>0</sub>] &times; nums[i<sub>1</sub>] &times; nums[i<sub>2</sub>] &times; ... &times; nums[i<sub>k</sub>]</code>。

请你返回老师创建的小组能得到的最大实力值为多少。

**示例 1：**

> **输入：** nums = [3,-1,-5,2,5,-9]
> **输出：** 1350
> **解释：** 一种构成最大实力值小组的方案是选择下标为 [0,2,3,4,5] 的学生。实力值为 3 &times; (-5) &times; 2 &times; 5 &times; (-9) = 1350 ，这是可以得到的最大实力值。

**示例 2：**

> **输入：** nums = [-4,-5,-4]
> **输出：** 20
> **解释：** 选择下标为 [0, 1] 的学生。得到的实力值为 20 。我们没法得到更大的实力值。

**提示：**

- `1 <= nums.length <= 13`
- `-9 <= nums[i] <= 9`
