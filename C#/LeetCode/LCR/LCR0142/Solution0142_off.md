### [训练计划 IV](https://leetcode.cn/problems/he-bing-liang-ge-pai-xu-de-lian-biao-lcof/solutions/1398788/he-bing-liang-ge-pai-xu-de-lian-biao-by-g3z6g/)

#### 方法一：递归

**思路**

我们可以如下递归地定义两个链表里的 `merge` 操作（忽略边界情况，比如空链表等）：

$$\left\{ \begin{array}{ll} list1[0] + merge(list1[1:], list2) & list1[0] < list2[0] \\ list2[0] + merge(list1, list2[1:]) & otherwise \end{array} \right.$$

也就是说，两个链表头部值较小的一个节点与剩下元素的 `merge` 操作结果合并。

**算法**

我们直接将以上递归过程建模，同时需要考虑边界情况。

如果 `l1` 或者 `l2` 一开始就是空链表 ，那么没有任何操作需要合并，所以我们只需要返回非空链表。否则，我们要判断 `l1` 和 `l2` 哪一个链表的头节点的值更小，然后递归地决定下一个添加到结果里的节点。如果两个链表有一个为空，递归结束。

```java
class Solution {
    public ListNode mergeTwoLists(ListNode l1, ListNode l2) {
        if (l1 == null) {
            return l2;
        } else if (l2 == null) {
            return l1;
        } else if (l1.val < l2.val) {
            l1.next = mergeTwoLists(l1.next, l2);
            return l1;
        } else {
            l2.next = mergeTwoLists(l1, l2.next);
            return l2;
        }
    }
}
```

```csharp
public class Solution {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        if (l1 == null) {
            return l2;
        } else if (l2 == null) {
            return l1;
        } else if (l1.val < l2.val) {
            l1.next = MergeTwoLists(l1.next, l2);
            return l1;
        } else {
            l2.next = MergeTwoLists(l1, l2.next);
            return l2;
        }
    }
}
```

```python
class Solution:
    def mergeTwoLists(self, l1: ListNode, l2: ListNode) -> ListNode:
        if l1 is None:
            return l2
        elif l2 is None:
            return l1
        elif l1.val < l2.val:
            l1.next = self.mergeTwoLists(l1.next, l2)
            return l1
        else:
            l2.next = self.mergeTwoLists(l1, l2.next)
            return l2
```

```javascript
var mergeTwoLists = function(l1, l2) {
    if (l1 === null) {
        return l2;
    } else if (l2 === null) {
        return l1;
    } else if (l1.val < l2.val) {
        l1.next = mergeTwoLists(l1.next, l2);
        return l1;
    } else {
        l2.next = mergeTwoLists(l1, l2.next);
        return l2;
    }
};
```

```cpp
class Solution {
public:
    ListNode* mergeTwoLists(ListNode* l1, ListNode* l2) {
        if (l1 == nullptr) {
            return l2;
        } else if (l2 == nullptr) {
            return l1;
        } else if (l1->val < l2->val) {
            l1->next = mergeTwoLists(l1->next, l2);
            return l1;
        } else {
            l2->next = mergeTwoLists(l1, l2->next);
            return l2;
        }
    }
};
```

**复杂度分析**

- 时间复杂度：$O(n + m)$，其中 $n$ 和 $m$ 分别为两个链表的长度。因为每次调用递归都会去掉 `l1` 或者 `l2` 的头节点（直到至少有一个链表为空），函数 `mergeTwoList` 至多只会递归调用每个节点一次。因此，时间复杂度取决于合并后的链表长度，即 $O(n+m)$。
- 空间复杂度：$O(n + m)$，其中 $n$ 和 $m$ 分别为两个链表的长度。递归调用 `mergeTwoLists` 函数时需要消耗栈空间，栈空间的大小取决于递归调用的深度。结束递归调用时 `mergeTwoLists` 函数最多调用 $n+m$ 次，因此空间复杂度为 $O(n+m)$。

#### 方法二：迭代

**思路**

我们可以用迭代的方法来实现上述算法。当 `l1` 和 `l2` 都不是空链表时，判断 `l1` 和 `l2` 哪一个链表的头节点的值更小，将较小值的节点添加到结果里，当一个节点被添加到结果里之后，将对应链表中的节点向后移一位。

**算法**

首先，我们设定一个哨兵节点 `prehead` ，这可以在最后让我们比较容易地返回合并后的链表。我们维护一个 `prev` 指针，我们需要做的是调整它的 `next` 指针。然后，我们重复以下过程，直到 `l1` 或者 `l2` 指向了 `null` ：如果 `l1` 当前节点的值小于等于 `l2` ，我们就把 `l1` 当前的节点接在 `prev` 节点的后面同时将 `l1` 指针往后移一位。否则，我们对 `l2` 做同样的操作。不管我们将哪一个元素接在了后面，我们都需要把 `prev` 向后移一位。

在循环终止的时候， `l1` 和 `l2` 至多有一个是非空的。由于输入的两个链表都是有序的，所以不管哪个链表是非空的，它包含的所有元素都比前面已经合并链表中的所有元素都要大。这意味着我们只需要简单地将非空链表接在合并链表的后面，并返回合并链表即可。

下图展示了 `1->4->5` 和 `1->2->3->6` 两个链表迭代合并的过程：

![](./assets/img/Solution0142_off_2_01.png)
![](./assets/img/Solution0142_off_2_02.png)
![](./assets/img/Solution0142_off_2_03.png)
![](./assets/img/Solution0142_off_2_04.png)
![](./assets/img/Solution0142_off_2_05.png)
![](./assets/img/Solution0142_off_2_06.png)
![](./assets/img/Solution0142_off_2_07.png)
![](./assets/img/Solution0142_off_2_08.png)
![](./assets/img/Solution0142_off_2_09.png)
![](./assets/img/Solution0142_off_2_10.png)
![](./assets/img/Solution0142_off_2_11.png)
![](./assets/img/Solution0142_off_2_12.png)
![](./assets/img/Solution0142_off_2_13.png)
![](./assets/img/Solution0142_off_2_14.png)
![](./assets/img/Solution0142_off_2_15.png)
![](./assets/img/Solution0142_off_2_16.png)
![](./assets/img/Solution0142_off_2_17.png)
![](./assets/img/Solution0142_off_2_18.png)
![](./assets/img/Solution0142_off_2_19.png)
![](./assets/img/Solution0142_off_2_20.png)
![](./assets/img/Solution0142_off_2_21.png)
![](./assets/img/Solution0142_off_2_22.png)
![](./assets/img/Solution0142_off_2_23.png)
![](./assets/img/Solution0142_off_2_24.png)
![](./assets/img/Solution0142_off_2_25.png)
![](./assets/img/Solution0142_off_2_26.png)
![](./assets/img/Solution0142_off_2_27.png)
![](./assets/img/Solution0142_off_2_28.png)
![](./assets/img/Solution0142_off_2_29.png)
![](./assets/img/Solution0142_off_2_30.png)
![](./assets/img/Solution0142_off_2_31.png)
![](./assets/img/Solution0142_off_2_32.png)
![](./assets/img/Solution0142_off_2_33.png)
![](./assets/img/Solution0142_off_2_34.png)
![](./assets/img/Solution0142_off_2_35.png)

```java
class Solution {
    public ListNode mergeTwoLists(ListNode l1, ListNode l2) {
        ListNode prehead = new ListNode(-1);

        ListNode prev = prehead;
        while (l1 != null && l2 != null) {
            if (l1.val <= l2.val) {
                prev.next = l1;
                l1 = l1.next;
            } else {
                prev.next = l2;
                l2 = l2.next;
            }
            prev = prev.next;
        }

        // 合并后 l1 和 l2 最多只有一个还未被合并完，我们直接将链表末尾指向未合并完的链表即可
        prev.next = l1 == null ? l2 : l1;

        return prehead.next;
    }
}
```

```csharp
public class Solution {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        ListNode prehead = new ListNode(-1);

        ListNode prev = prehead;
        while (l1 != null && l2 != null) {
            if (l1.val <= l2.val) {
                prev.next = l1;
                l1 = l1.next;
            } else {
                prev.next = l2;
                l2 = l2.next;
            }
            prev = prev.next;
        }

        // 合并后 l1 和 l2 最多只有一个还未被合并完，我们直接将链表末尾指向未合并完的链表即可
        prev.next = l1 == null ? l2 : l1;

        return prehead.next;
    }
}
```

```python
class Solution:
    def mergeTwoLists(self, l1: ListNode, l2: ListNode) -> ListNode:
        prehead = ListNode(-1)

        prev = prehead
        while l1 and l2:
            if l1.val <= l2.val:
                prev.next = l1
                l1 = l1.next
            else:
                prev.next = l2
                l2 = l2.next
            prev = prev.next

        # 合并后 l1 和 l2 最多只有一个还未被合并完，我们直接将链表末尾指向未合并完的链表即可
        prev.next = l1 if l1 is not None else l2

        return prehead.next
```

```javascript
var mergeTwoLists = function(l1, l2) {
    const prehead = new ListNode(-1);

    let prev = prehead;
    while (l1 != null && l2 != null) {
        if (l1.val <= l2.val) {
            prev.next = l1;
            l1 = l1.next;
        } else {
            prev.next = l2;
            l2 = l2.next;
        }
        prev = prev.next;
    }

    // 合并后 l1 和 l2 最多只有一个还未被合并完，我们直接将链表末尾指向未合并完的链表即可
    prev.next = l1 === null ? l2 : l1;

    return prehead.next;
};
```

```cpp
class Solution {
public:
    ListNode* mergeTwoLists(ListNode* l1, ListNode* l2) {
        ListNode* preHead = new ListNode(-1);

        ListNode* prev = preHead;
        while (l1 != nullptr && l2 != nullptr) {
            if (l1->val < l2->val) {
                prev->next = l1;
                l1 = l1->next;
            } else {
                prev->next = l2;
                l2 = l2->next;
            }
            prev = prev->next;
        }

        // 合并后 l1 和 l2 最多只有一个还未被合并完，我们直接将链表末尾指向未合并完的链表即可
        prev->next = l1 == nullptr ? l2 : l1;

        return preHead->next;
    }
};
```

**复杂度分析**

- 时间复杂度：$O(n + m)$，其中 $n$ 和 $m$ 分别为两个链表的长度。因为每次循环迭代中，`l1` 和 `l2` 只有一个元素会被放进合并链表中， 因此 `while` 循环的次数不会超过两个链表的长度之和。所有其他操作的时间复杂度都是常数级别的，因此总的时间复杂度为 $O(n+m)$。
- 空间复杂度：$O(1)$。我们只需要常数的空间存放若干变量。
