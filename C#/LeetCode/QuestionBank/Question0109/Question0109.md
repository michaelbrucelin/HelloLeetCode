### [109\. 有序链表转换二叉搜索树](https://leetcode.cn/problems/convert-sorted-list-to-binary-search-tree/)

难度：中等

给定一个单链表的头节点 `head`，其中的元素 **按升序排序**，将其转换为 _平衡[^1]_ 二叉搜索树。

**示例 1:**

![](./assets/img/Question0109.jpg)

> **输入:** head = [-10,-3,0,5,9]
> **输出:** [0,-3,9,-10,null,5]
> **解释:** 一个可能的答案是[0，-3,9，-10,null,5]，它表示所示的高度平衡的二叉搜索树。

**示例 2:**

> **输入:** head = []
> **输出:** []

**提示:**

- `head` 中的节点数在<code>[0, 2 &times; 10<sup>4</sup>]</code> 范围内
- <code>-10<sup>5</sup> <= Node.val <= 10<sup>5</sup></code>

[^1]: **平衡二叉树** 是指该树所有节点的左右子树的高度相差不超过 1。
