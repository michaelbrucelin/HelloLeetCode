### [反转链表 II](https://leetcode.cn/problems/reverse-linked-list-ii/solutions/634701/fan-zhuan-lian-biao-ii-by-leetcode-solut-teyq/?envType=problem-list-v2&envId=tBJHVASZ)

#### 前言

链表的操作问题，一般而言面试（机试）的时候不允许我们修改节点的值，而只能修改节点的指向操作。

思路通常都不难，技巧就是一定要先想清楚思路，并且在草稿纸上画图，然后编码。

#### 方法一：穿针引线

我们以下图中黄色区域的链表反转为例。

![](./assets/img/Solution0092_off_1_01.png)

使用「[206\. 反转链表](https://leetcode.cn/problems/reverse-linked-list/)」的解法，反转 `left` 到 `right` 部分以后，再拼接起来。我们还需要记录 `left` 的前一个节点，和 `right` 的后一个节点。如图所示：

![](./assets/img/Solution0092_off_1_02.png)

**算法步骤：**

- 第 $1$ 步：先将待反转的区域反转；
- 第 $2$ 步：把 `pre` 的 `next` 指针指向反转以后的链表头节点，把反转以后的链表的尾节点的 `next` 指针指向 `succ`。

![](./assets/img/Solution0092_off_1_03.png)

**说明**：编码细节我们不在题解中介绍了，请见下方代码。思路想明白以后，编码不是一件很难的事情。这里要提醒大家的是，链接什么时候切断，什么时候补上去，先后顺序一定要想清楚，如果想不清楚，可以在纸上模拟，让思路清晰。

**代码**

```C++
class Solution {
private:
    void reverseLinkedList(ListNode *head) {
        // 也可以使用递归反转一个链表
        ListNode *pre = nullptr;
        ListNode *cur = head;

        while (cur != nullptr) {
            ListNode *next = cur->next;
            cur->next = pre;
            pre = cur;
            cur = next;
        }
    }

public:
    ListNode *reverseBetween(ListNode *head, int left, int right) {
        // 因为头节点有可能发生变化，使用虚拟头节点可以避免复杂的分类讨论
        ListNode *dummyNode = new ListNode(-1);
        dummyNode->next = head;

        ListNode *pre = dummyNode;
        // 第 1 步：从虚拟头节点走 left - 1 步，来到 left 节点的前一个节点
        // 建议写在 for 循环里，语义清晰
        for (int i = 0; i < left - 1; i++) {
            pre = pre->next;
        }

        // 第 2 步：从 pre 再走 right - left + 1 步，来到 right 节点
        ListNode *rightNode = pre;
        for (int i = 0; i < right - left + 1; i++) {
            rightNode = rightNode->next;
        }

        // 第 3 步：切断出一个子链表（截取链表）
        ListNode *leftNode = pre->next;
        ListNode *curr = rightNode->next;

        // 注意：切断链接
        pre->next = nullptr;
        rightNode->next = nullptr;

        // 第 4 步：同第 206 题，反转链表的子区间
        reverseLinkedList(leftNode);

        // 第 5 步：接回到原来的链表中
        pre->next = rightNode;
        leftNode->next = curr;
        return dummyNode->next;
    }
};
```

```Java
class Solution {
    public ListNode reverseBetween(ListNode head, int left, int right) {
        // 因为头节点有可能发生变化，使用虚拟头节点可以避免复杂的分类讨论
        ListNode dummyNode = new ListNode(-1);
        dummyNode.next = head;

        ListNode pre = dummyNode;
        // 第 1 步：从虚拟头节点走 left - 1 步，来到 left 节点的前一个节点
        // 建议写在 for 循环里，语义清晰
        for (int i = 0; i < left - 1; i++) {
            pre = pre.next;
        }

        // 第 2 步：从 pre 再走 right - left + 1 步，来到 right 节点
        ListNode rightNode = pre;
        for (int i = 0; i < right - left + 1; i++) {
            rightNode = rightNode.next;
        }

        // 第 3 步：切断出一个子链表（截取链表）
        ListNode leftNode = pre.next;
        ListNode curr = rightNode.next;

        // 注意：切断链接
        pre.next = null;
        rightNode.next = null;

        // 第 4 步：同第 206 题，反转链表的子区间
        reverseLinkedList(leftNode);

        // 第 5 步：接回到原来的链表中
        pre.next = rightNode;
        leftNode.next = curr;
        return dummyNode.next;
    }

    private void reverseLinkedList(ListNode head) {
        // 也可以使用递归反转一个链表
        ListNode pre = null;
        ListNode cur = head;

        while (cur != null) {
            ListNode next = cur.next;
            cur.next = pre;
            pre = cur;
            cur = next;
        }
    }
}
```

```Python
class Solution:
    def reverseBetween(self, head: ListNode, left: int, right: int) -> ListNode:
        def reverse_linked_list(head: ListNode):
            # 也可以使用递归反转一个链表
            pre = None
            cur = head
            while cur:
                next = cur.next
                cur.next = pre
                pre = cur
                cur = next

        # 因为头节点有可能发生变化，使用虚拟头节点可以避免复杂的分类讨论
        dummy_node = ListNode(-1)
        dummy_node.next = head
        pre = dummy_node
        # 第 1 步：从虚拟头节点走 left - 1 步，来到 left 节点的前一个节点
        # 建议写在 for 循环里，语义清晰
        for _ in range(left - 1):
            pre = pre.next

        # 第 2 步：从 pre 再走 right - left + 1 步，来到 right 节点
        right_node = pre
        for _ in range(right - left + 1):
            right_node = right_node.next
        # 第 3 步：切断出一个子链表（截取链表）
        left_node = pre.next
        curr = right_node.next

        # 注意：切断链接
        pre.next = None
        right_node.next = None

        # 第 4 步：同第 206 题，反转链表的子区间
        reverse_linked_list(left_node)
        # 第 5 步：接回到原来的链表中
        pre.next = right_node
        left_node.next = curr
        return dummy_node.next
```

```Go
func reverseLinkedList(head *ListNode) {
    var pre *ListNode
    cur := head
    for cur != nil {
        next := cur.Next
        cur.Next = pre
        pre = cur
        cur = next
    }
}

func reverseBetween(head *ListNode, left, right int) *ListNode {
    // 因为头节点有可能发生变化，使用虚拟头节点可以避免复杂的分类讨论
    dummyNode := &ListNode{Val: -1}
    dummyNode.Next = head

    pre := dummyNode
    // 第 1 步：从虚拟头节点走 left - 1 步，来到 left 节点的前一个节点
    // 建议写在 for 循环里，语义清晰
    for i := 0; i < left-1; i++ {
        pre = pre.Next
    }

    // 第 2 步：从 pre 再走 right - left + 1 步，来到 right 节点
    rightNode := pre
    for i := 0; i < right-left+1; i++ {
        rightNode = rightNode.Next
    }

    // 第 3 步：切断出一个子链表（截取链表）
    leftNode := pre.Next
    curr := rightNode.Next

    // 注意：切断链接
    pre.Next = nil
    rightNode.Next = nil

    // 第 4 步：同第 206 题，反转链表的子区间
    reverseLinkedList(leftNode)

    // 第 5 步：接回到原来的链表中
    pre.Next = rightNode
    leftNode.Next = curr
    return dummyNode.Next
}
```

```C
void reverseLinkedList(struct ListNode *head) {
    // 也可以使用递归反转一个链表
    struct ListNode *pre = NULL;
    struct ListNode *cur = head;

    while (cur != NULL) {
        struct ListNode *next = cur->next;
        cur->next = pre;
        pre = cur;
        cur = next;
    }
}

struct ListNode *reverseBetween(struct ListNode *head, int left, int right) {
    // 因为头节点有可能发生变化，使用虚拟头节点可以避免复杂的分类讨论
    struct ListNode *dummyNode = malloc(sizeof(struct ListNode));
    dummyNode->val = -1;
    dummyNode->next = head;

    struct ListNode *pre = dummyNode;
    // 第 1 步：从虚拟头节点走 left - 1 步，来到 left 节点的前一个节点
    // 建议写在 for 循环里，语义清晰
    for (int i = 0; i < left - 1; i++) {
        pre = pre->next;
    }

    // 第 2 步：从 pre 再走 right - left + 1 步，来到 right 节点
    struct ListNode *rightNode = pre;
    for (int i = 0; i < right - left + 1; i++) {
        rightNode = rightNode->next;
    }

    // 第 3 步：切断出一个子链表（截取链表）
    struct ListNode *leftNode = pre->next;
    struct ListNode *curr = rightNode->next;

    // 注意：切断链接
    pre->next = NULL;
    rightNode->next = NULL;

    // 第 4 步：同第 206 题，反转链表的子区间
    reverseLinkedList(leftNode);

    // 第 5 步：接回到原来的链表中
    pre->next = rightNode;
    leftNode->next = curr;
    return dummyNode->next;
}
```

```JavaScript
var reverseBetween = function(head, left, right) {
    // 因为头节点有可能发生变化，使用虚拟头节点可以避免复杂的分类讨论
    const dummyNode = new ListNode(-1);
    dummyNode.next = head;

    let pre = dummyNode;
    // 第 1 步：从虚拟头节点走 left - 1 步，来到 left 节点的前一个节点
    // 建议写在 for 循环里，语义清晰
    for (let i = 0; i < left - 1; i++) {
        pre = pre.next;
    }

    // 第 2 步：从 pre 再走 right - left + 1 步，来到 right 节点
    let rightNode = pre;
    for (let i = 0; i < right - left + 1; i++) {
        rightNode = rightNode.next;
    }

    // 第 3 步：切断出一个子链表（截取链表）
    let leftNode = pre.next;
    let curr = rightNode.next;

    // 注意：切断链接
    pre.next = null;
    rightNode.next = null;

    // 第 4 步：同第 206 题，反转链表的子区间
    reverseLinkedList(leftNode);

    // 第 5 步：接回到原来的链表中
    pre.next = rightNode;
    leftNode.next = curr;
    return dummyNode.next;
};

const reverseLinkedList = (head) => {
    let pre = null;
    let cur = head;

    while (cur) {
        const next = cur.next;
        cur.next = pre;
        pre = cur;
        cur = next;
    }
}
```

**复杂度分析**

- 时间复杂度：$O(N)$，其中 $N$ 是链表总节点数。最坏情况下，需要遍历整个链表。
- 空间复杂度：$O(1)$。只使用到常数个变量。

#### 方法二：一次遍历「穿针引线」反转链表

方法一的缺点是：如果 `left` 和 `right` 的区域很大，恰好是链表的头节点和尾节点时，找到 `left` 和 `right` 需要遍历一次，反转它们之间的链表还需要遍历一次，虽然总的时间复杂度为 $O(N)$，但遍历了链表 $2$ 次，可不可以只遍历一次呢？答案是可以的。我们依然画图进行说明。

我们依然以方法一的示例为例进行说明。

![](./assets/img/Solution0092_off_2_01.png)

整理思想是：在需要反转的区间里，每遍历到一个节点，让这个新节点来到反转部分的起始位置。下面的图展示了整个流程。

![](./assets/img/Solution0092_off_2_02.png)

下面我们具体解释如何实现。使用三个指针变量 `pre`、`curr`、`next` 来记录反转的过程中需要的变量，它们的意义如下：

- `curr`：指向待反转区域的第一个节点 `left`；
- `next`：永远指向 `curr` 的下一个节点，循环过程中，`curr` 变化以后 `next` 会变化；
- `pre`：永远指向待反转区域的第一个节点 `left` 的前一个节点，在循环过程中不变。

第 $1$ 步，我们使用 ①、②、③ 标注「穿针引线」的步骤。

![](./assets/img/Solution0092_off_2_03.png)

**操作步骤**：

- 先将 `curr` 的下一个节点记录为 `next`；
- 执行操作 ①：把 `curr` 的下一个节点指向 `next` 的下一个节点；
- 执行操作 ②：把 `next` 的下一个节点指向 `pre` 的下一个节点；
- 执行操作 ③：把 `pre` 的下一个节点指向 `next`。

第 $1$ 步完成以后「拉直」的效果如下：

![](./assets/img/Solution0092_off_2_04.png)

第 $2$ 步，同理。同样需要注意 **「穿针引线」操作的先后顺序**。

![](./assets/img/Solution0092_off_2_05.png)

第 $2$ 步完成以后「拉直」的效果如下：

![](./assets/img/Solution0092_off_2_06.png)

第 $3$ 步，同理。

![](./assets/img/Solution0092_off_2_07.png)

第 $3$ 步完成以后「拉直」的效果如下：

![](./assets/img/Solution0092_off_2_08.png)

**代码**

```C++
class Solution {
public:
    ListNode *reverseBetween(ListNode *head, int left, int right) {
        // 设置 dummyNode 是这一类问题的一般做法
        ListNode *dummyNode = new ListNode(-1);
        dummyNode->next = head;
        ListNode *pre = dummyNode;
        for (int i = 0; i < left - 1; i++) {
            pre = pre->next;
        }
        ListNode *cur = pre->next;
        ListNode *next;
        for (int i = 0; i < right - left; i++) {
            next = cur->next;
            cur->next = next->next;
            next->next = pre->next;
            pre->next = next;
        }
        return dummyNode->next;
    }
};
```

```Java
class Solution {
    public ListNode reverseBetween(ListNode head, int left, int right) {
        // 设置 dummyNode 是这一类问题的一般做法
        ListNode dummyNode = new ListNode(-1);
        dummyNode.next = head;
        ListNode pre = dummyNode;
        for (int i = 0; i < left - 1; i++) {
            pre = pre.next;
        }
        ListNode cur = pre.next;
        ListNode next;
        for (int i = 0; i < right - left; i++) {
            next = cur.next;
            cur.next = next.next;
            next.next = pre.next;
            pre.next = next;
        }
        return dummyNode.next;
    }
}
```

```Python
class Solution:
    def reverseBetween(self, head: ListNode, left: int, right: int) -> ListNode:
        # 设置 dummyNode 是这一类问题的一般做法
        dummy_node = ListNode(-1)
        dummy_node.next = head
        pre = dummy_node
        for _ in range(left - 1):
            pre = pre.next

        cur = pre.next
        for _ in range(right - left):
            next = cur.next
            cur.next = next.next
            next.next = pre.next
            pre.next = next
        return dummy_node.next
```

```Go
func reverseBetween(head *ListNode, left, right int) *ListNode {
    // 设置 dummyNode 是这一类问题的一般做法
    dummyNode := &ListNode{Val: -1}
    dummyNode.Next = head
    pre := dummyNode
    for i := 0; i < left-1; i++ {
        pre = pre.Next
    }
    cur := pre.Next
    for i := 0; i < right-left; i++ {
        next := cur.Next
        cur.Next = next.Next
        next.Next = pre.Next
        pre.Next = next
    }
    return dummyNode.Next
}
```

```C
struct ListNode *reverseBetween(struct ListNode *head, int left, int right) {
    // 因为头节点有可能发生变化，使用虚拟头节点可以避免复杂的分类讨论
    struct ListNode *dummyNode = malloc(sizeof(struct ListNode));
    dummyNode->val = -1;
    dummyNode->next = head;

    struct ListNode *pre = dummyNode;
    for (int i = 0; i < left - 1; i++) {
        pre = pre->next;
    }
    struct ListNode *cur = pre->next;
    struct ListNode *next;
    for (int i = 0; i < right - left; i++) {
        next = cur->next;
        cur->next = next->next;
        next->next = pre->next;
        pre->next = next;
    }
    return dummyNode->next;
}
```

```JavaScript
var reverseBetween = function(head, left, right) {
    // 设置 dummyNode 是这一类问题的一般做法
    const dummy_node = new ListNode(-1);
    dummy_node.next = head;
    let pre = dummy_node;
    for (let i = 0; i < left - 1; ++i) {
        pre = pre.next;
    }

    let cur = pre.next;
    for (let i = 0; i < right - left; ++i) {
        const next = cur.next;
        cur.next = next.next;
        next.next = pre.next;
        pre.next = next;
    }
    return dummy_node.next;
};
```

**复杂度分析**：

- 时间复杂度：$O(N)$，其中 $N$ 是链表总节点数。最多只遍历了链表一次，就完成了反转。
- 空间复杂度：$O(1)$。只使用到常数个变量。
