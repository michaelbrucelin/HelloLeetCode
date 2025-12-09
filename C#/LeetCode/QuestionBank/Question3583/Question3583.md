### [3583\. 统计特殊三元组](https://leetcode.cn/problems/count-special-triplets/)

难度：中等

给你一个整数数组 `nums`。

**特殊三元组** 定义为满足以下条件的下标三元组 `(i, j, k)`：

- `0 <= i < j < k < n`，其中 `n = nums.length`
- <code>nums[i] == nums[j] &times; 2</code>
- <code>nums[k] == nums[j] &times; 2</code>

返回数组中 **特殊三元组** 的总数。

由于答案可能非常大，请返回结果对 <code>10<sup>9</sup> + 7</code> 取余数后的值。

**示例 1：**

> **输入：** nums = [6,3,6]
> **输出：** 1
> **解释：**
> 唯一的特殊三元组是 `(i, j, k) = (0, 1, 2)`，其中：
>
> - `nums[0] = 6`, `nums[1] = 3`, `nums[2] = 6`
> - <code>nums[0] = nums[1] &times; 2 = 3 &times; 2 = 6</code>
> - <code>nums[2] = nums[1] &times; 2 = 3 &times; 2 = 6</code>

**示例 2：**

> **输入：** nums = [0,1,0,0]
> **输出：** 1
> **解释：**
> 唯一的特殊三元组是 `(i, j, k) = (0, 2, 3)`，其中：
>
> - `nums[0] = 0`, `nums[2] = 0`, `nums[3] = 0`
> - <code>nums[0] = nums[2] &times; 2 = 0 &times; 2 = 0</code>
> - <code>nums[3] = nums[2] &times; 2 = 0 &times; 2 = 0</code>

**示例 3：**

> **输入：** nums = [8,4,2,8,4]
> **输出：** 2
> **解释：**
> 共有两个特殊三元组：
>
> - `(i, j, k) = (0, 1, 3)`
>   - `nums[0] = 8`, `nums[1] = 4`, `nums[3] = 8`
>   - <code>nums[0] = nums[1] &times; 2 = 4 &times; 2 = 8</code>
>   - <code>nums[3] = nums[1] &times; 2 = 4 &times; 2 = 8</code>
> - `(i, j, k) = (1, 2, 4)`
>   - `nums[1] = 4`, `nums[2] = 2`, `nums[4] = 4`
>   - <code>nums[1] = nums[2] &times; 2 = 2 &times; 2 = 4</code>
>   - <code>nums[4] = nums[2] &times; 2 = 2 &times; 2 = 4</code>

**提示：**

- <code>3 <= n == nums.length <= 10<sup>5</sup></code>
- <code>0 <= nums[i] <= 10<sup>5</sup></code>
