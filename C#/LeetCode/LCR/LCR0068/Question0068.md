### [LCR 068. 搜索插入位置](https://leetcode.cn/problems/N6YdxV/)

难度：简单

给定一个排序的整数数组 `nums` 和一个整数目标值 `target` ，请在数组中找到 `target` ，并返回其下标。如果目标值不存在于数组中，返回它将会被按顺序插入的位置。

请必须使用时间复杂度为 `O(log n)` 的算法。

**示例 1:**

> **输入:** nums = [1,3,5,6], target = 5
> **输出:** 2

**示例 2:**

> **输入:** nums = [1,3,5,6], target = 2
> **输出:** 1

**示例 3:**

> **输入:** nums = [1,3,5,6], target = 7
> **输出:** 4

**示例 4:**

> **输入:** nums = [1,3,5,6], target = 0
> **输出:** 0

**示例 5:**

> **输入:** nums = [1], target = 0
> **输出:** 0

**提示:**

- `1 <= nums.length <= 10^4`
- `-10^4 <= nums[i] <= 10^4`
- `nums` 为**无重复元素**的**升序**排列数组
- `-10^4 <= target <= 10^4`

**注意：** 本题与主站 35 题相同： [https://leetcode-cn.com/problems/search-insert-position/](https://leetcode-cn.com/problems/search-insert-position/)
