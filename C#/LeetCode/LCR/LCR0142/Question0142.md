### [LCR 142. 训练计划 IV](https://leetcode.cn/problems/he-bing-liang-ge-pai-xu-de-lian-biao-lcof/)

难度：简单

给定两个以 **有序链表** 形式记录的训练计划 `l1`、`l2`，分别记录了两套核心肌群训练项目编号，请合并这两个训练计划，按训练项目编号 **升序** 记录于链表并返回。

**注意**：新链表是通过拼接给定的两个链表的所有节点组成的。

**示例 1：**

> **输入：** l1 = [1,2,4], l2 = [1,3,4]
> **输出：** [1,1,2,3,4,4]

**示例 2：**

> **输入：** l1 = [], l2 = []
> **输出：** []

**示例 3：**

> **输入：** l1 = [], l2 = [0]
> **输出：** [0]

**提示：**

`0 <= 链表长度 <= 1000`

注意：本题与主站 21 题相同：[https://leetcode-cn.com/problems/merge-two-sorted-lists/](https://leetcode-cn.com/problems/merge-two-sorted-lists/)
