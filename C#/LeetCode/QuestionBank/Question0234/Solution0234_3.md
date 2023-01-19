#### [����һ����ֵ���Ƶ������к���˫ָ�뷨](https://leetcode.cn/problems/palindrome-linked-list/solutions/457059/hui-wen-lian-biao-by-leetcode-solution/)

**˼·**

����㻹��̫��Ϥ���������й����б�ĸ�Ҫ������

�����ֳ��õ��б�ʵ�֣��ֱ�Ϊ�����б������������������б��д洢ֵ�����������ʵ�ֵ��أ�

-   �����б�ײ���ʹ������洢ֵ�����ǿ���ͨ�������� $O(1)$ ��ʱ������б��κ�λ�õ�ֵ�������ɻ����ڴ�Ѱַ�ķ�ʽ��
-   ����洢���ǳ�Ϊ�ڵ�Ķ���ÿ���ڵ㱣��һ��ֵ��ָ����һ���ڵ��ָ�롣����ĳ���ض������Ľڵ���Ҫ $O(n)$ ��ʱ�䣬��ΪҪͨ��ָ���ȡ����һ��λ�õĽڵ㡣

ȷ�������б��Ƿ���ĺܼ򵥣����ǿ���ʹ��˫ָ�뷨���Ƚ����˵�Ԫ�أ������м��ƶ���һ��ָ���������м��ƶ�����һ��ָ����յ����м��ƶ�������Ҫ $O(n)$ ��ʱ�䣬��Ϊ����ÿ��Ԫ�ص�ʱ���� $O(1)$������ $n$ ��Ԫ��Ҫ���ʡ�

Ȼ��ͬ���ķ����������ϲ��������򵥣���Ϊ������������ʻ��Ƿ�����ʶ����� $O(1)$�����������ֵ���Ƶ������б����� $O(n)$�������򵥵ķ������ǽ������ֵ���Ƶ������б��У���ʹ��˫ָ�뷨�жϡ�

**�㷨**

һ��Ϊ�������裺

1.  ��������ֵ�������б��С�
2.  ʹ��˫ָ�뷨�ж��Ƿ�Ϊ���ġ�

��һ����������Ҫ��������ֵ���Ƶ������б��С������� `currentNode` ָ��ǰ�ڵ㡣ÿ�ε������������ `currentNode.val`�������� `currentNode = currentNode.next`���� `currentNode = null` ʱֹͣѭ����

ִ�еڶ�������ѷ���ȡ������ʹ�õ����ԡ��� Python �У������׹���һ���б�ķ��򸱱���Ҳ�����ױȽ������б��������������У���û����ô�򵥡�������ʹ��˫ָ�뷨������Ƿ�Ϊ���ġ�������������һ��ָ�룬�ڽ�β����һ��ָ�룬ÿһ�ε����ж�����ָ��ָ���Ԫ���Ƿ���ͬ������ͬ������ `false`����ͬ������ָ�������ƶ����������жϣ�ֱ������ָ��������

�ڱ���Ĺ����У�ע�����ǱȽϵ��ǽڵ�ֵ�Ĵ�С�������ǽڵ㱾����ȷ�ıȽϷ�ʽ�ǣ�`node_1.val == node_2.val`���� `node_1 == node_2` �Ǵ���ġ�

**����**

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

        // �������ֵ���Ƶ�������
        ListNode currentNode = head;
        while (currentNode != null) {
            vals.add(currentNode.val);
            currentNode = currentNode.next;
        }

        // ʹ��˫ָ���ж��Ƿ����
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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ָ���������Ԫ�ظ�����
    -   ��һ���� ����������ֵ���Ƶ������У�$O(n)$��
    -   �ڶ�����˫ָ���ж��Ƿ�Ϊ���ģ�ִ���� $O(n/2)$ �ε��жϣ��� $O(n)$��
    -   �ܵ�ʱ�临�Ӷȣ�$O(2n) = O(n)$��
-   �ռ临�Ӷȣ�$O(n)$������ $n$ ָ���������Ԫ�ظ���������ʹ����һ�������б��������Ԫ��ֵ��
