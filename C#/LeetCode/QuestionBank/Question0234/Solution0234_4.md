#### [���������ݹ�](https://leetcode.cn/problems/palindrome-linked-list/solutions/457059/hui-wen-lian-biao-by-leetcode-solution/)

**˼·**

Ϊ�����ʹ�ÿռ临�Ӷ�Ϊ O(1)O(1)O(1) ���㷨����������ʹ�õݹ����������������Ȼ��Ҫ O(n)O(n)O(n) �Ŀռ临�Ӷȡ�

�ݹ�Ϊ�����ṩ��һ�����ŵķ�ʽ����������ڵ㡣

```javascript
function print_values_in_reverse(ListNode head)
    if head is NOT null
        print_values_in_reverse(head.next)
        print head.val
```

���ʹ�õݹ鷴������ڵ㣬ͬʱʹ�õݹ麯����ı�����ǰ�������Ϳ����ж������Ƿ�Ϊ���ġ�

**�㷨** `currentNode` ָ�����ȵ�β�ڵ㣬���ڵݹ�������ٴӺ���ǰ���бȽϡ�`frontPointer` �ǵݹ麯�����ָ�롣�� `currentNode.val != frontPointer.val` �򷵻� `false`����֮��`frontPointer` ��ǰ�ƶ������� `true`��

�㷨����ȷ�����ڵݹ鴦��ڵ��˳�����෴�ģ��ع������ӡ���㷨�����������ں������ּ�¼��һ����������˴ӱ����ϣ�����ͬʱ��������������ƥ�䡣

����Ķ���չʾ���㷨�Ĺ���ԭ�����Ƕ���ݹ麯������Ϊ `recursively_check`��ÿ���ڵ㶼�������˱�ʶ������ `$1`���Ա���õؽ������ǡ�������ڵݹ�Ĺ����н�ʹ�ö�ջ�Ŀռ䣬�����Ϊʲô�ݹ鲢���� O(1)O(1)O(1) �Ŀռ临�Ӷȡ�

![](./assets/img/Solution0234_4_01.png)
![](./assets/img/Solution0234_4_02.png)
![](./assets/img/Solution0234_4_03.png)
![](./assets/img/Solution0234_4_04.png)
![](./assets/img/Solution0234_4_05.png)
![](./assets/img/Solution0234_4_06.png)
![](./assets/img/Solution0234_4_07.png)
![](./assets/img/Solution0234_4_08.png)
![](./assets/img/Solution0234_4_09.png)
![](./assets/img/Solution0234_4_10.png)
![](./assets/img/Solution0234_4_11.png)
![](./assets/img/Solution0234_4_12.png)
![](./assets/img/Solution0234_4_13.png)
![](./assets/img/Solution0234_4_14.png)
![](./assets/img/Solution0234_4_15.png)
![](./assets/img/Solution0234_4_16.png)
![](./assets/img/Solution0234_4_17.png)
![](./assets/img/Solution0234_4_18.png)
![](./assets/img/Solution0234_4_19.png)
![](./assets/img/Solution0234_4_20.png)
![](./assets/img/Solution0234_4_21.png)
![](./assets/img/Solution0234_4_22.png)
![](./assets/img/Solution0234_4_23.png)
![](./assets/img/Solution0234_4_24.png)
![](./assets/img/Solution0234_4_25.png)
![](./assets/img/Solution0234_4_26.png)
![](./assets/img/Solution0234_4_27.png)
![](./assets/img/Solution0234_4_28.png)
![](./assets/img/Solution0234_4_29.png)
![](./assets/img/Solution0234_4_30.png)
![](./assets/img/Solution0234_4_31.png)
![](./assets/img/Solution0234_4_32.png)
![](./assets/img/Solution0234_4_33.png)
![](./assets/img/Solution0234_4_34.png)

**����**

```python
class Solution:
    def isPalindrome(self, head: ListNode) -> bool:

        self.front_pointer = head

        def recursively_check(current_node=head):
            if current_node is not None:
                if not recursively_check(current_node.next):
                    return False
                if self.front_pointer.val != current_node.val:
                    return False
                self.front_pointer = self.front_pointer.next
            return True

        return recursively_check()
```

```java
class Solution {
    private ListNode frontPointer;

    private boolean recursivelyCheck(ListNode currentNode) {
        if (currentNode != null) {
            if (!recursivelyCheck(currentNode.next)) {
                return false;
            }
            if (currentNode.val != frontPointer.val) {
                return false;
            }
            frontPointer = frontPointer.next;
        }
        return true;
    }

    public boolean isPalindrome(ListNode head) {
        frontPointer = head;
        return recursivelyCheck(head);
    }
}
```

```cpp
class Solution {
    ListNode* frontPointer;
public:
    bool recursivelyCheck(ListNode* currentNode) {
        if (currentNode != nullptr) {
            if (!recursivelyCheck(currentNode->next)) {
                return false;
            }
            if (currentNode->val != frontPointer->val) {
                return false;
            }
            frontPointer = frontPointer->next;
        }
        return true;
    }

    bool isPalindrome(ListNode* head) {
        frontPointer = head;
        return recursivelyCheck(head);
    }
};
```

```javascript
let frontPointer;

const recursivelyCheck = (currentNode) => {
    if (currentNode !== null) {
        if (!recursivelyCheck(currentNode.next)) {
            return false;
        }
        if (currentNode.val !== frontPointer.val) {
            return false;
        }
        frontPointer = frontPointer.next;
    }
    return true;
}

var isPalindrome = function(head) {
    frontPointer = head;
    return recursivelyCheck(head);
};
```

```go
func isPalindrome(head *ListNode) bool {
    frontPointer := head
    var recursivelyCheck func(*ListNode) bool
    recursivelyCheck = func(curNode *ListNode) bool {
        if curNode != nil {
            if !recursivelyCheck(curNode.Next) {
                return false
            }
            if curNode.Val != frontPointer.Val {
                return false
            }
            frontPointer = frontPointer.Next
        }
        return true
    }
    return recursivelyCheck(head)
}
```

```c
struct ListNode* frontPointer;

bool recursivelyCheck(struct ListNode* currentNode) {
    if (currentNode != NULL) {
        if (!recursivelyCheck(currentNode->next)) {
            return false;
        }
        if (currentNode->val != frontPointer->val) {
            return false;
        }
        frontPointer = frontPointer->next;
    }
    return true;
}

bool isPalindrome(struct ListNode* head) {
    frontPointer = head;
    return recursivelyCheck(head);
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ָ��������Ĵ�С��
-   �ռ临�Ӷȣ�$O(n)$������ $n$ ָ��������Ĵ�С������Ҫ�������������еݹ麯������һ�������е���һ������ʱ���������Ҫ�ڽ��뱻���ú���֮ǰ�������ڵ�ǰ�����е�λ�ã��Լ��κξֲ�������ֵ����ͨ������ʱ����ڶ�ջ����ʵ�֣���ջ֡�����ڶ�ջ�д�ź������ݺ�Ϳ��Խ��뱻���õĺ���������ɱ����ú���֮�����ᵯ����ջ����Ԫ�أ��Իָ��ڽ��к�������֮ǰ���ڵĺ������ڽ��л��ļ��֮ǰ���ݹ麯�����ڶ�ջ�д��� $n$ ����ջ֡�������������������д���������ʹ�õݹ�ʱ�ռ临�Ӷ�Ҫ���Ƕ�ջ��ʹ�������

���ַ�������ʹ���� $O(n)$ �Ŀռ䣬�ұȵ�һ�ַ��������Ϊ����������У���ջ֡�Ŀ����ܴ��� Python����������������ʱ��ջ���Ϊ 1000���������ӣ������п��ܵ��µײ���ͳ����ڴ������Ϊÿ���ڵ㴴����ջ֡������������㷨�ܹ��������������С��
