### [1018\. 可被 5 整除的二进制前缀](https://leetcode.cn/problems/binary-prefix-divisible-by-5/)

难度：简单

给定一个二进制数组 `nums` ( **索引从0开始** )。

我们将<code>x<sub>i</sup></code> 定义为其二进制表示形式为子数组 `nums[0..i]` (从最高有效位到最低有效位)。

- 例如，如果 `nums =[1,0,1]`，那么 <code>x<sub>0</sub> = 1</code>, <code>x<sub>1</sub> = 2</code>, 和 <code>x<sub>2</sub> = 5</code>。

返回布尔值列表 `answer`，只有当 <code>x<sub>i</sup></code> 可以被 `5` 整除时，答案 `answer[i]` 为 `true`，否则为 `false`。

**示例 1：**

> **输入：** nums = [0,1,1]
> **输出：** [true,false,false]
> **解释：**
> 输入数字为 0, 01, 011；也就是十进制中的 0, 1, 3。只有第一个数可以被 5 整除，因此 answer[0] 为 true。

**示例 2：**

> **输入：** nums = [1,1,1]
> **输出：** [false,false,false]

**提示：**

- <code>1 <= nums.length <= 10<sup>5</sup></code>
- `nums[i]` 仅为 `0` 或 `1`
