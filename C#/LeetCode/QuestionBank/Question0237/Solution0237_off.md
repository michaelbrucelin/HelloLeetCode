### [删除链表中的节点](https://leetcode.cn/problems/delete-node-in-a-linked-list/solutions/1077517/shan-chu-lian-biao-zhong-de-jie-dian-by-x656s/?envType=problem-list-v2&envId=tBJHVASZ)

#### 方法一：和下一个节点交换

删除链表中的节点的常见的方法是定位到待删除节点的上一个节点，修改上一个节点的 $next$ 指针，使其指向待删除节点的下一个节点，即可完成删除操作。

这道题中，传入的参数 $node$ 为要被删除的节点，无法定位到该节点的上一个节点。注意到要被删除的节点不是链表的末尾节点，因此 $node.next$ 不为空，可以通过对 $node$ 和 $node.next$ 进行操作实现删除节点。

在给定节点 $node$ 的情况下，可以通过修改 $node$ 的 $next$ 指针的指向，删除 $node$ 的下一个节点。但是题目要求删除 $node$，为了达到删除 $node$ 的效果，只要在删除节点之前，将 $node$ 的节点值修改为 $node.next$ 的节点值即可。

例如，给定链表 $4\rightarrow 5\rightarrow 1\rightarrow 9$，要被删除的节点是 $5$，即链表中的第 $2$ 个节点。可以通过如下两步操作实现删除节点的操作。

1. 将第 $2$ 个节点的值修改为第 $3$ 个节点的值，即将节点 $5$ 的值修改为 $1$，此时链表如下：
    $$4\rightarrow 1\rightarrow 1\rightarrow 9$$
2. 删除第 $3$ 个节点，此时链表如下：
    $$4\rightarrow 1\rightarrow 9$$

达到删除节点 $5$ 的效果。

```Java
class Solution {
    public void deleteNode(ListNode node) {
        node.val = node.next.val;
        node.next = node.next.next;
    }
}
```

```CSharp
public class Solution {
    public void DeleteNode(ListNode node) {
        node.val = node.next.val;
        node.next = node.next.next;
    }
}
```

```C++
class Solution {
public:
    void deleteNode(ListNode* node) {
        node->val = node->next->val;
        node->next = node->next->next;
    }
};
```

```JavaScript
var deleteNode = function(node) {
    node.val = node.next.val;
    node.next = node.next.next;
};
```

```TypeScript
function deleteNode(root: ListNode | null): void {
    root.val = root.next.val;
    root.next = root.next.next;
};
```

```Python
class Solution:
    def deleteNode(self, node):
        node.val = node.next.val
        node.next = node.next.next
```

```Go
func deleteNode(node *ListNode) {
    node.Val = node.Next.Val
    node.Next = node.Next.Next
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
