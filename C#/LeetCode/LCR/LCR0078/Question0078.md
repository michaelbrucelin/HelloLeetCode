### [LCR 078. 合并 K 个升序链表](https://leetcode.cn/problems/vvXgSW/)

难度：困难

给定一个链表数组，每个链表都已经按升序排列。

请将所有链表合并到一个升序链表中，返回合并后的链表。

**示例 1：**

> **输入：** lists = \[[1,4,5],[1,3,4],[2,6]]
> **输出：** [1,1,2,3,4,4,5,6]
> **解释：** 链表数组如下：
>
> ```c
> [
>   1->4->5,
>   1->3->4,
>   2->6
> ]
> ```
>
> 将它们合并到一个有序链表中得到。
> `1->1->2->3->4->4->5->6`

**示例 2：**

> **输入：** lists = []
> **输出：** []

**示例 3：**

> **输入：** lists = \[[]]
> **输出：** []

**提示：**

- `k == lists.length`
- <code>0 <= k <= 10<sup>4</sup></code>
- `0 <= lists[i].length <= 500`
- <code>-10<sup>4</sup> <= lists[i][j] <= 10<sup>4</sup></code>
- `lists[i]` 按 **升序** 排列
- `lists[i].length` 的总和不超过 <code>10<sup>4</sup></code>

注意：本题与主站 23 题相同： [https://leetcode.cn/problems/merge-k-sorted-lists/](https://leetcode.cn/problems/merge-k-sorted-lists/)
