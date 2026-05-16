### [LCR 044. 在每个树行中找最大值](https://leetcode.cn/problems/hPov7L/)

难度：中等

给定一棵二叉树的根节点 `root`，请找出该二叉树中每一层的最大值。

**示例 1：**

> **输入:** root = [1,3,2,5,3,null,9]
> **输出:** [1,3,9]
> **解释:**
>
> ```c
>           1
>          / \
>         3   2
>        / \   \
>       5   3   9
> ```

**示例 2：**

> **输入:** root = [1,2,3]
> **输出:** [1,3]
> **解释:**
>
> ```c
>           1
>          / \
>         2   3
> ```

**示例 3：**

> **输入:** root = [1]
> **输出:** [1]

**示例 4：**

> **输入:** root = [1,null,2]
> **输出:** [1,2]
> **解释:**
>
> ```c
>            1
>             \
>              2
> ```

**示例 5：**

> **输入:** root = []
> **输出:** []

**提示：**

- 二叉树的节点个数的范围是 <code>[0,10<sup>4</sup>]</code>
- <code>-2<sup>31</sup> <= Node.val <= 2<sup>31</sup> - 1</code>

**注意：** 本题与主站 515 题相同：[https://leetcode.cn/problems/find-largest-value-in-each-tree-row/](https://leetcode.cn/problems/find-largest-value-in-each-tree-row/)
