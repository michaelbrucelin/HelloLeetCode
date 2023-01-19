#### [方法一：将值复制到数组中后用双指针法](https://leetcode.cn/problems/palindrome-linked-list/solutions/457059/hui-wen-lian-biao-by-leetcode-solution/)

**思路**

如果你还不太熟悉链表，下面有关于列表的概要讲述。

有两种常用的列表实现，分别为数组列表和链表。如果我们想在列表中存储值，它们是如何实现的呢？

-   数组列表底层是使用数组存储值，我们可以通过索引在 $O(1)$ 的时间访问列表任何位置的值，这是由基于内存寻址的方式。
-   链表存储的是称为节点的对象，每个节点保存一个值和指向下一个节点的指针。访问某个特定索引的节点需要 $O(n)$ 的时间，因为要通过指针获取到下一个位置的节点。

确定数组列表是否回文很简单，我们可以使用双指针法来比较两端的元素，并向中间移动。一个指针从起点向中间移动，另一个指针从终点向中间移动。这需要 $O(n)$ 的时间，因为访问每个元素的时间是 $O(1)$，而有 $n$ 个元素要访问。

然而同样的方法在链表上操作并不简单，因为不论是正向访问还是反向访问都不是 $O(1)$。而将链表的值复制到数组列表中是 $O(n)$，因此最简单的方法就是将链表的值复制到数组列表中，再使用双指针法判断。

**算法**

一共为两个步骤：

1.  复制链表值到数组列表中。
2.  使用双指针法判断是否为回文。

第一步，我们需要遍历链表将值复制到数组列表中。我们用 `currentNode` 指向当前节点。每次迭代向数组添加 `currentNode.val`，并更新 `currentNode = currentNode.next`，当 `currentNode = null` 时停止循环。

执行第二步的最佳方法取决于你使用的语言。在 Python 中，很容易构造一个列表的反向副本，也很容易比较两个列表。而在其他语言中，就没有那么简单。因此最好使用双指针法来检查是否为回文。我们在起点放置一个指针，在结尾放置一个指针，每一次迭代判断两个指针指向的元素是否相同，若不同，返回 `false`；相同则将两个指针向内移动，并继续判断，直到两个指针相遇。

在编码的过程中，注意我们比较的是节点值的大小，而不是节点本身。正确的比较方式是：`node_1.val == node_2.val`，而 `node_1 == node_2` 是错误的。

**代码**

```python
class Solution:
    def isPalindrome(self, head: ListNode) -> bool:
        vals = []
        current_node = head
        while current_node is not None:
            vals.append(current_node.val)
            current_node = current_node.next
        return vals == vals[::-1]
```

```java
class Solution {
    public boolean isPalindrome(ListNode head) {
        List<Integer> vals = new ArrayList<Integer>();

        // 将链表的值复制到数组中
        ListNode currentNode = head;
        while (currentNode != null) {
            vals.add(currentNode.val);
            currentNode = currentNode.next;
        }

        // 使用双指针判断是否回文
        int front = 0;
        int back = vals.size() - 1;
        while (front < back) {
            if (!vals.get(front).equals(vals.get(back))) {
                return false;
            }
            front++;
            back--;
        }
        return true;
    }
}
```

```cpp
class Solution {
public:
    bool isPalindrome(ListNode* head) {
        vector<int> vals;
        while (head != nullptr) {
            vals.emplace_back(head->val);
            head = head->next;
        }
        for (int i = 0, j = (int)vals.size() - 1; i < j; ++i, --j) {
            if (vals[i] != vals[j]) {
                return false;
            }
        }
        return true;
    }
};
```

```javascript
var isPalindrome = function(head) {
    const vals = [];
    while (head !== null) {
        vals.push(head.val);
        head = head.next;
    }
    for (let i = 0, j = vals.length - 1; i < j; ++i, --j) {
        if (vals[i] !== vals[j]) {
            return false;
        }
    }
    return true;
};
```

```go
func isPalindrome(head *ListNode) bool {
    vals := []int{}
    for ; head != nil; head = head.Next {
        vals = append(vals, head.Val)
    }
    n := len(vals)
    for i, v := range vals[:n/2] {
        if v != vals[n-1-i] {
            return false
        }
    }
    return true
}
```

```c
bool isPalindrome(struct ListNode* head) {
    int vals[50001], vals_num = 0;
    while (head != NULL) {
        vals[vals_num++] = head->val;
        head = head->next;
    }
    for (int i = 0, j = vals_num - 1; i < j; ++i, --j) {
        if (vals[i] != vals[j]) {
            return false;
        }
    }
    return true;
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 指的是链表的元素个数。
    -   第一步： 遍历链表并将值复制到数组中，$O(n)$。
    -   第二步：双指针判断是否为回文，执行了 $O(n/2)$ 次的判断，即 $O(n)$。
    -   总的时间复杂度：$O(2n) = O(n)$。
-   空间复杂度：$O(n)$，其中 $n$ 指的是链表的元素个数，我们使用了一个数组列表存放链表的元素值。
