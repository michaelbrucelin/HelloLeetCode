### [2196\. 根据描述创建二叉树](https://leetcode.cn/problems/create-binary-tree-from-descriptions/)

难度：中等

给你一个二维整数数组 `descriptions`，其中 <code>descriptions[i] = [parent<sub>i</sub>, child<sub>i</sub>, isLeft<sub>i</sub>]</code> 表示 <code>parent<sub>i</sub></code> 是 <code>child<sub>i</sub></code> 在 **二叉树** 中的 **父节点**，二叉树中各节点的值 **互不相同**。此外：

- 如果 <code>isLeft<sub>i</sub> == 1</code>，那么 <code>child<sub>i</sub></code> 就是 <code>parent<sub>i</sub></code> 的左子节点。
- 如果 <code>isLeft<sub>i</sub> == 0</code>，那么 <code>child<sub>i</sub></code> 就是 <code>parent<sub>i</sub></code> 的右子节点。

请你根据 `descriptions` 的描述来构造二叉树并返回其 **根节点**。

测试用例会保证可以构造出 **有效** 的二叉树。

**示例 1：**

> ![](./assets/img/Question2196_01.png)
>
> **输入：** descriptions = \[[20,15,1],[20,17,0],[50,20,1],[50,80,0],[80,19,1]]
> **输出：** [50,20,80,15,17,19]
> **解释：** 根节点是值为 50 的节点，因为它没有父节点。
> 结果二叉树如上图所示。

**示例 2：**

> ![](./assets/img/Question2196_02.png)
>
> **输入：** descriptions = \[[1,2,1],[2,3,0],[3,4,1]]
> **输出：** [1,2,null,null,3,4]
> **解释：** 根节点是值为 1 的节点，因为它没有父节点。
> 结果二叉树如上图所示。

**提示：**

- <code>1 <= descriptions.length <= 10<sup>4</sup></code>
- `descriptions[i].length == 3`
- <code>1 <= parent<sub>i</sub>, child<sub>i</sub> <= 10<sup>5</sup></code>
- <code>0 <= isLeft<sub>i</sub> <= 1</code>
- `descriptions` 所描述的二叉树是一棵有效二叉树
