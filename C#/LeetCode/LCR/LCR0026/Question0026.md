### [LCR 026. 重排链表](https://leetcode.cn/problems/LGjMqU/)

难度：中等

给定一个单链表 `L` 的头节点 `head`，单链表 `L` 表示为：

 <code>L<sub>0&nbsp;</sub> &rightarrow; L<sub>1&nbsp;</sub> &rightarrow; ... &rightarrow; L<sub>n-1&nbsp;</sub> &rightarrow; L<sub>n&nbsp;</sub></code>
请将其重新排列后变为：

<code>L<sub>0&nbsp;</sub> &rightarrow; L<sub>n&nbsp;</sub> &rightarrow; L<sub>1&nbsp;</sub> &rightarrow; L<sub>n-1&nbsp;</sub> &rightarrow; L<sub>2&nbsp;</sub> &rightarrow; L<sub>n-2&nbsp;</sub> &rightarrow; ... </code>

不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。

**示例 1：**

> ![](./assets/img/Question0026_01.png)
>
> **输入:** head = [1,2,3,4]
> **输出:** [1,4,2,3]

**示例 2：**

> ![](./assets/img/Question0026_02.png)
>
> **输入:** head = [1,2,3,4,5]
> **输出:** [1,5,2,4,3]

**提示：**

- 链表的长度范围为 <code>[1, 5 &times; 10<sup>4</sup>]</code>
- `1 <= node.val <= 1000`

**注意：** 本题与主站 143 题相同：[https://leetcode.cn/problems/reorder-list/](https://leetcode.cn/problems/reorder-list/)
