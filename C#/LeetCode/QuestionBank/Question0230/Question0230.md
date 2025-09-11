### [230\. 二叉搜索树中第 K 小的元素](https://leetcode.cn/problems/kth-smallest-element-in-a-bst/)

难度：中等

给定一个二叉搜索树的根节点 `root`，和一个整数 `k`，请你设计一个算法查找其中第 `k` 小的元素（从 $1$ 开始计数）。

**示例 1：**

![](./assets/img/Question0230_01.jpg)

> **输入：** root = [3,1,4,null,2], k = 1
> **输出：** 1

**示例 2：**

![](./assets/img/Question0230_02.jpg)

> **输入：** root = [5,3,6,2,4,null,null,1], k = 3
> **输出：** 3

**提示：**

- 树中的节点数为 `n`。
- <code>1 <= k <= n <= 10<sup>4</sup></code>
- <code>0 <= Node.val <= 10<sup>4</sup></code>

**进阶：** 如果二叉搜索树经常被修改（插入/删除操作）并且你需要频繁地查找第 `k` 小的值，你将如何优化算法？
