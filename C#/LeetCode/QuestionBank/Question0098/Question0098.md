### [98\. 验证二叉搜索树](https://leetcode.cn/problems/validate-binary-search-tree/)

难度：中等

给你一个二叉树的根节点 `root`，判断其是否是一个有效的二叉搜索树。

**有效** 二叉搜索树定义如下：

- 节点的左_子树[^1]_只包含 **小于** 当前节点的数。
- 节点的右子树只包含 **大于** 当前节点的数。
- 所有左子树和右子树自身必须也是二叉搜索树。

**示例 1：**

![](./assets/img/Question0098_01.jpg)

> **输入：** root = [2,1,3]
> **输出：** true

**示例 2：**

![](./assets/img/Question0098_02.jpg)

> **输入：** root = [5,1,4,null,null,3,6]
> **输出：** false
> **解释：** 根节点的值是 5，但是右子节点的值是 4。

**提示：**

- 树中节点数目范围在 <code>[1, 10<sup>4</sup>]</code> 内
- <code>-2<sup>31</sup> <= Node.val <= 2<sup>31</sup> - 1</code>

[^1]: `treeName` 树中的一个节点及其所有子孙节点所构成的树称为 `treeName` 的 **子树**。
