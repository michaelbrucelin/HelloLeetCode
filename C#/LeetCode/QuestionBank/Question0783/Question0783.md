### [783\. 二叉搜索树节点最小距离](https://leetcode.cn/problems/minimum-distance-between-bst-nodes/description/)

难度：简单

给你一个二叉搜索树的根节点 `root` ，返回 **树中任意两不同节点值之间的最小差值** 。

差值是一个正数，其数值等于两值之差的绝对值。

**示例 1：**

![](./assets/img/Question0783_01.jpg)

```
输入：root = [4,2,6,1,3]
输出：1
```

**示例 2：**

![](./assets/img/Question0783_02.jpg)

```
输入：root = [1,0,48,null,null,12,49]
输出：1
```

**提示：**

-   树中节点的数目范围是 `[2, 100]`
-   `0 <= Node.val <= 10^5`

**注意：** 本题与 530：[https://leetcode-cn.com/problems/minimum-absolute-difference-in-bst/](https://leetcode-cn.com/problems/minimum-absolute-difference-in-bst/) 相同
