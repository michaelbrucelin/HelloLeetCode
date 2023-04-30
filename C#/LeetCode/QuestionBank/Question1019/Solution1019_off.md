#### [����һ������ջ](https://leetcode.cn/problems/next-greater-node-in-linked-list/solutions/2216789/lian-biao-zhong-de-xia-yi-ge-geng-da-jie-u9yo/)

**˼·���㷨**

�ҳ�����һ�������Ԫ�ء��Ǿ���Ŀ����õ���ջ��������⡣

���Ƕ��������һ�α�����ͬʱά��һ���ڲ�ֵ�����ݼ��������ϸ񵥵��ݼ���������ȣ���ջ��ջ�е�Ԫ�ض�Ӧ��**��û���ҵ���һ�������Ԫ��**����ЩԪ�أ�������ջ�е�˳���������������г��ֵ�˳��һ�¡���Ҳ������Ϊʲôջ�е�ֵ�ǵ����ݼ��ģ����������Ԫ�ز����㵥���ݼ������ƣ���ô��һ��Ԫ�ش���ǰһ��Ԫ�أ��롸��û���ҵ���һ�������Ԫ�ء���ì�ܡ�

�����Ǳ����������е�ֵΪ $val$ �Ľڵ�ʱ��ֻҪ������ջ��Ԫ�ص�ֵ�����ǾͿ��Բ���ȡ��ջ���Ľڵ㣬��ջ���ڵ����һ�������Ԫ�ؾ��� $val$������֮�������ٽ� $val$ ����ջ����Ϊ���ں����ı������ҵ�������һ�������Ԫ�أ�ͬʱҲ��֤��ջ�ĵ����ԡ�

**ϸ��**

������ȡ��ջ����Ԫ��ʱ�������ǲ�֪�����������е�λ�õġ�����ڵ���ջ�У�������Ҫ����洢һ����ʾλ�õı�����

**����**

```cpp
class Solution {
public:
    vector<int> nextLargerNodes(ListNode* head) {
        vector<int> ans;
        stack<pair<int, int>> s;

        ListNode* cur = head;
        int idx = -1;
        while (cur) {
            ++idx;
            ans.push_back(0);
            while (!s.empty() && s.top().first < cur->val) {
                ans[s.top().second] = cur->val;
                s.pop();
            }
            s.emplace(cur->val, idx);
            cur = cur->next;
        }

        return ans;
    }
};
```

```java
class Solution {
    public int[] nextLargerNodes(ListNode head) {
        List<Integer> ans = new ArrayList<Integer>();
        Deque<int[]> stack = new ArrayDeque<int[]>();

        ListNode cur = head;
        int idx = -1;
        while (cur != null) {
            ++idx;
            ans.add(0);
            while (!stack.isEmpty() && stack.peek()[0] < cur.val) {
                ans.set(stack.pop()[1], cur.val);
            }
            stack.push(new int[]{cur.val, idx});
            cur = cur.next;
        }

        int size = ans.size();
        int[] arr = new int[size];
        for (int i = 0; i < size; ++i) {
            arr[i] = ans.get(i);
        }
        return arr;
    }
}
```

```csharp
public class Solution {
    public int[] NextLargerNodes(ListNode head) {
        IList<int> ans = new List<int>();
        Stack<int[]> stack = new Stack<int[]>();

        ListNode cur = head;
        int idx = -1;
        while (cur != null) {
            ++idx;
            ans.Add(0);
            while (stack.Count > 0 && stack.Peek()[0] < cur.val) {
                ans[stack.Pop()[1]] = cur.val;
            }
            stack.Push(new int[]{cur.val, idx});
            cur = cur.next;
        }

        return ans.ToArray();
    }
}
```

```python
class Solution:
    def nextLargerNodes(self, head: Optional[ListNode]) -> List[int]:
        ans = list()
        s = list()

        cur = head
        idx = -1
        while cur:
            idx += 1
            ans.append(0)
            while s and s[-1][0] < cur.val:
                ans[s[-1][1]] = cur.val
                s.pop()
            s.append((cur.val, idx))
            cur = cur.next
        
        return ans
```

```c
typedef struct Pair {
    int first;
    int second;
} Pair;

int* nextLargerNodes(struct ListNode* head, int* returnSize) {
    int len = 0;
    struct ListNode* cur = head;
    while (cur) {
        cur = cur->next;
        len++;
    }
    int* ans = (int *)calloc(len, sizeof(int));
    Pair stack[len];
    int top = 0, pos = 0;

    cur = head;
    int idx = -1;
    while (cur) {
        ++idx;
        ans[pos++] = 0;
        while (top > 0 && stack[top - 1].first < cur->val) {
            ans[stack[top - 1].second] = cur->val;
            top--;
        }
        stack[top].first = cur->val;
        stack[top].second = idx;
        top++;
        cur = cur->next;
    }
    *returnSize = len;
    return ans;
}
```

```go
func nextLargerNodes(head *ListNode) []int {
    var ans []int
    var stack [][]int
    cur := head
    idx := -1
    for cur != nil {
        idx++
        ans = append(ans, 0)
        for len(stack) > 0 && stack[len(stack)-1][0] < cur.Val {
            top := stack[len(stack)-1]
            stack = stack[:len(stack)-1]
            ans[top[1]] = cur.Val
        }
        stack = append(stack, []int{cur.Val, idx})
        cur = cur.Next
    }
    return ans
}
```

```javascript
var nextLargerNodes = function(head) {
    const ans = [];
    const stack = [];

    let cur = head;
    let idx = -1;
    while (cur) {
        ++idx;
        ans.push(0);
        while (stack.length && stack[stack.length - 1][0] < cur.val) {
            ans[stack.pop()[1]] = cur.val;
        }
        stack.push([cur.val, idx]);
        cur = cur.next;
    }

    const size = ans.length;
    const arr = new Array(size);
    for (let i = 0; i < size; ++i) {
        arr[i] = ans[i];
    }
    return arr;
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ������ĳ��ȡ���������б�����Ҫ $O(n)$ ��ʱ�䣬�����е�ÿ��Ԫ��ǡ����ջһ�Σ�����ջһ�Σ���һ���ֵ�ʱ��ҲΪ $O(n)$��
-   �ռ临�Ӷȣ�$O(n)$������ $n$ ������ĳ��ȡ���Ϊ����ջ��Ҫ�Ŀռ䡣
