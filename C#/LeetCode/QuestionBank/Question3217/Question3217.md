### [3217\. 从链表中移除在数组中存在的节点](https://leetcode.cn/problems/delete-nodes-from-linked-list-present-in-array/)

难度：中等

给你一个整数数组 `nums` 和一个链表的头节点 `head`。从链表中**移除**所有存在于 `nums` 中的节点后，返回修改后的链表的头节点。

**示例 1：**

> **输入：** nums = [1,2,3], head = [1,2,3,4,5]
> **输出：** [4,5]
> **解释：**
> ![](./assets/img/Question3217_01.png)
> 移除数值为 1, 2 和 3 的节点。

**示例 2：**

> **输入：** nums = [1], head = [1,2,1,2,1,2]
> **输出：** [2,2,2]
> **解释：**
> ![](./assets/img/Question3217_02.png)
> 移除数值为 1 的节点。

**示例 3：**

> **输入：** nums = [5], head = [1,2,3,4]
> **输出：** [1,2,3,4]
> **解释：**
> ![](./assets/img/Question3217_03.png)
> 链表中不存在值为 5 的节点。

**提示：**

- <code>1 <= nums.length <= 10<sup>5</sup></code>
- <code>1 <= nums[i] <= 10<sup>5</sup></code>
- `nums` 中的所有元素都是唯一的。
- 链表中的节点数在 <code>[1, 10<sup>5</sup>]</code> 的范围内。
- <code>1 <= Node.val <= 10<sup>5</sup></code>
- 输入保证链表中至少有一个值没有在 `nums` 中出现过。
