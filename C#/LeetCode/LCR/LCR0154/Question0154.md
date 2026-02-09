### [LCR 154. 复杂链表的复制](https://leetcode.cn/problems/fu-za-lian-biao-de-fu-zhi-lcof/)

难度：中等

请实现 `copyRandomList` 函数，复制一个复杂链表。在复杂链表中，每个节点除了有一个 `next` 指针指向下一个节点，还有一个 `random` 指针指向链表中的任意节点或者 `null`。

**示例 1：**

> ![](./assets/img/Question0154_01.png)
>
> **输入：** head = \[[7,null],[13,0],[11,4],[10,2],[1,0]]
> **输出：** \[[7,null],[13,0],[11,4],[10,2],[1,0]]

**示例 2：**

> ![](./assets/img/Question0154_02.png)
>
> **输入：** head = \[[1,1],[2,1]]
> **输出：** \[[1,1],[2,1]]

**示例 3：**

> ![](./assets/img/Question0154_03.png)
>
> **输入：** head = \[[3,null],[3,0],[3,null]]
> **输出：** \[[3,null],[3,0],[3,null]]

**示例 4：**

> **输入：** head = []
> **输出：** []
> **解释：** 给定的链表为空（空指针），因此返回 null。

**提示：**

- `-10000 <= Node.val <= 10000`
- `Node.random` 为空（null）或指向链表中的节点。
- 节点数目不超过 1000。

**注意：** 本题与主站 138 题相同：[https://leetcode.cn/problems/copy-list-with-random-pointer/](https://leetcode.cn/problems/copy-list-with-random-pointer/)
