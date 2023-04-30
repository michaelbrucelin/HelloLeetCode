#### [��ͼ�ⵥ��ջ�����ַ���������ͼ�붮�����ⵥ��Python/Java/C++/Go��](https://leetcode.cn/problems/next-greater-node-in-linked-list/solutions/2217563/tu-jie-dan-diao-zhan-liang-chong-fang-fa-v9ab/)

#### ����һ����ÿ������Ѱ������һ������Ԫ��

![](./assets/img/Solution1019_2_01.png)

����������˵�����ǿ��Դ�ͷ�ڵ㿪ʼ�ݹ飬�ڡ��项�Ĺ����У����൱���Ǵ��ҵ�����������ˡ�

```python
class Solution:
    def nextLargerNodes(self, head: Optional[ListNode]) -> List[int]:
        ans = []
        st = []  # ����ջ���ڵ�ֵ��
        def f(node: Optional[ListNode], i: int) -> None:
            if node is None:
                nonlocal ans
                ans = [0] * i  # i ����������
                return
            f(node.next, i + 1)
            while st and st[-1] <= node.val:
                st.pop()  # ������������
            if st:
                ans[i] = st[-1]  # ջ�����ǵ� i ���ڵ����һ������Ԫ��
            st.append(node.val)
        f(head, 0)
        return ans
```

```java
class Solution {
    private int[] ans;
    private final Deque<Integer> st = new ArrayDeque<>(); // ����ջ���ڵ�ֵ��

    public int[] nextLargerNodes(ListNode head) {
        f(head, 0);
        return ans;
    }

    private void f(ListNode node, int i) {
        if (node == null) {
            ans = new int[i]; // i ����������
            return;
        }
        f(node.next, i + 1);
        while (!st.isEmpty() && st.peek() <= node.val)
            st.pop(); // ������������
        if (!st.isEmpty())
            ans[i] = st.peek(); // ջ�����ǵ� i ���ڵ����һ������Ԫ��
        st.push(node.val);
    }
}
```

```cpp
class Solution {
    vector<int> ans;
    stack<int> st; // ����ջ���ڵ�ֵ��

    void f(ListNode *node, int i) {
        if (node == nullptr) {
            ans.resize(i); // i ����������
            return;
        }
        f(node->next, i + 1);
        while (!st.empty() && st.top() <= node->val)
            st.pop(); // ������������
        if (!st.empty())
            ans[i] = st.top(); // ջ�����ǵ� i ���ڵ����һ������Ԫ��
        st.push(node->val);
    }

public:
    vector<int> nextLargerNodes(ListNode *head) {
        f(head, 0);
        return ans;
    }
};
```

```go
func nextLargerNodes(head *ListNode) (ans []int) {
    st := []int{} // ����ջ���ڵ�ֵ��
    var f func(*ListNode, int)
    f = func(node *ListNode, i int) {
        if node == nil {
            ans = make([]int, i) // i ����������
            return
        }
        f(node.Next, i+1)
        for len(st) > 0 && st[len(st)-1] <= node.Val {
            st = st[:len(st)-1] // ������������
        }
        if len(st) > 0 {
            ans[i] = st[len(st)-1] // ջ�����ǵ� i ���ڵ����һ������Ԫ��
        }
        st = append(st, node.Val)
    }
    f(head, 0)
    return
}
```

����д�ݹ飿Ҳ���Է�ת����󣬴�ͷ�ڵ㿪ʼ������

��η�ת������[�������㷨���� 06��](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1sd4y1x7KN%2F)��

```python
class Solution:
    # 206. ��ת����
    def reverseList(self, head: Optional[ListNode]) -> Optional[ListNode]:
        pre = None
        cur = head
        while cur:
            nxt = cur.next
            cur.next = pre
            pre = cur
            cur = nxt
        return pre

    def nextLargerNodes(self, head: Optional[ListNode]) -> List[int]:
        head = self.reverseList(head)
        ans = []
        st = []  # ����ջ���ڵ�ֵ��
        while head:
            while st and st[-1] <= head.val:
                st.pop()  # ������������
            ans.append(st[-1] if st else 0)  # ջ�����ǵ� i ���ڵ����һ������Ԫ��
            st.append(head.val)
            head = head.next
        return ans[::-1]  # �����ǵ��ż�¼�𰸵ģ�����ǰҪ�Ѵ𰸷�ת
```

```java
class Solution {
    private int n;

    public int[] nextLargerNodes(ListNode head) {
        head = reverseList(head);
        var ans = new int[n];
        var st = new ArrayDeque<Integer>(); // ����ջ���ڵ�ֵ��
        for (var cur = head; cur != null; cur = cur.next) {
            while (!st.isEmpty() && st.peek() <= cur.val)
                st.pop(); // ������������
            ans[--n] = st.isEmpty() ? 0 : st.peek();
            st.push(cur.val);
        }
        return ans;
    }

    // 206. ��ת����
    public ListNode reverseList(ListNode head) {
        ListNode pre = null, cur = head;
        while (cur != null) {
            ListNode nxt = cur.next;
            cur.next = pre;
            pre = cur;
            cur = nxt;
            ++n;
        }
        return pre;
    }
}
```

```cpp
class Solution {
    // 206. ��ת����
    ListNode *reverseList(ListNode *head) {
        ListNode *pre = nullptr, *cur = head;
        while (cur) {
            ListNode *nxt = cur->next;
            cur->next = pre;
            pre = cur;
            cur = nxt;
        }
        return pre;
    }

public:
    vector<int> nextLargerNodes(ListNode *head) {
        head = reverseList(head);
        vector<int> ans;
        stack<int> st; // ����ջ���ڵ�ֵ��
        for (auto cur = head; cur; cur = cur->next) {
            while (!st.empty() && st.top() <= cur->val)
                st.pop(); // ������������
            // ջ�����ǵ� i ���ڵ����һ������Ԫ��
            ans.push_back(st.empty() ? 0 : st.top());
            st.push(cur->val);
        }
        // �����ǵ��ż�¼�𰸵ģ�����ǰҪ�Ѵ𰸷�ת
        reverse(ans.begin(), ans.end());
        return ans;
    }
};
```

```go
// 206. ��ת����
func reverseList(head *ListNode) (pre *ListNode, n int) {
    for cur := head; cur != nil; n++ {
        nxt := cur.Next
        cur.Next = pre
        pre = cur
        cur = nxt
    }
    return
}

func nextLargerNodes(head *ListNode) []int {
    head, n := reverseList(head)
    ans := make([]int, n)
    st := []int{} // ����ջ���ڵ�ֵ��
    for cur := head; cur != nil; cur = cur.Next {
        for len(st) > 0 && st[len(st)-1] <= cur.Val {
            st = st[:len(st)-1] // ������������
        }
        n--
        if len(st) > 0 {
            ans[n] = st[len(st)-1]
        }
        st = append(st, cur.Val)
    }
    return ans
}
```

#### ���Ӷȷ���

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ Ϊ����ĳ��ȡ���Ȼ����д�˸�����ѭ������վ��ÿ��Ԫ�ص��ӽǿ������Ԫ���ڶ���ѭ���������ջ��ջ��һ�Σ������������ѭ����ʱ�临�Ӷ�Ϊ $O(n)$��
-   �ռ临�Ӷȣ�$O(n)$������ջ������� $O(n)$ ������

#### ����������ÿ��������������������һ������Ԫ��

![](./assets/img/Solution1019_2_02.png)

���ڼ�¼����ҪԪ�ص��±꣬����ջ�г��˱���Ԫ��ֵ���⣬����Ҫ����Ԫ�ص��±ꡣ

```python
class Solution:
    def nextLargerNodes(self, head: Optional[ListNode]) -> List[int]:
        ans = []
        st = []  # ����ջ���ڵ�ֵ���ڵ��±꣩
        while head:
            while st and st[-1][0] < head.val:
                ans[st.pop()[1]] = head.val  # �õ�ǰ�ڵ�ֵ���´�
            st.append((head.val, len(ans)))  # ��ǰ ans �ĳ��Ⱦ��ǵ�ǰ�ڵ���±�
            ans.append(0)  # ռλ
            head = head.next
        return ans
```

```java
class Solution {
    public int[] nextLargerNodes(ListNode head) {
        int n = 0;
        for (var cur = head; cur != null; cur = cur.next)
            ++n; // ȷ������ֵ�ĳ���
        var ans = new int[n];
        var st = new ArrayDeque<int[]>(); // ����ջ���ڵ�ֵ���ڵ��±꣩
        int i = 0;
        for (var cur = head; cur != null; cur = cur.next) {
            while (!st.isEmpty() && st.peek()[0] < cur.val)
                ans[st.pop()[1]] = cur.val; // �õ�ǰ�ڵ�ֵ���´�
            st.push(new int[]{cur.val, i++});
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    vector<int> nextLargerNodes(ListNode *head) {
        vector<int> ans;
        stack<pair<int, int>> st; // ����ջ���ڵ�ֵ���ڵ��±꣩
        for (auto cur = head; cur; cur = cur->next) {
            while (!st.empty() && st.top().first < cur->val) {
                ans[st.top().second] = cur->val; // �õ�ǰ�ڵ�ֵ���´�
                st.pop();
            }
            // ��ǰ ans �ĳ��Ⱦ��ǵ�ǰ�ڵ���±�
            st.emplace(cur->val, ans.size());
            ans.push_back(0); // ռλ
        }
        return ans;
    }
};
```

```go
func nextLargerNodes(head *ListNode) (ans []int) {
    type pair struct{ x, i int }
    st := []pair{} // ����ջ���ڵ�ֵ���ڵ��±꣩
    for cur := head; cur != nil; cur = cur.Next {
        x := cur.Val
        for len(st) > 0 && st[len(st)-1].x < x {
            ans[st[len(st)-1].i] = x // �õ�ǰ�ڵ�ֵ���´�
            st = st[:len(st)-1]
        }
        // ��ǰ ans �ĳ��Ⱦ��ǵ�ǰ�ڵ���±�
        st = append(st, pair{x, len(ans)})
        ans = append(ans, 0) // ռλ
    }
    return ans
}
```

#### �Ż�

�ѵ� iii ���ڵ��ֵ��¼�� ans\[i\]\\textit{ans}\[i\]ans\[i\]������ջ�оͿ���ֻ�����±��ˡ�

��ѭ��������ջ���±��ӦԪ����û����һ������Ԫ�صģ�����Ҫ��ջ�е��±��Ӧ�� ans\\textit{ans}ans ��Ϊ 000��

```python
class Solution:
    def nextLargerNodes(self, head: Optional[ListNode]) -> List[int]:
        ans = []
        st = []  # ����ջ���ڵ��±꣩
        while head:
            while st and ans[st[-1]] < head.val:
                ans[st.pop()] = head.val  # ans[st.pop()] ���治���ٷ��ʵ���
            st.append(len(ans))  # ��ǰ ans �ĳ��Ⱦ��ǵ�ǰ�ڵ���±�
            ans.append(head.val)
            head = head.next
        for i in st:
            ans[i] = 0  # û����һ������Ԫ��
        return ans
```

```java
class Solution {
    public int[] nextLargerNodes(ListNode head) {
        int n = 0;
        for (var cur = head; cur != null; cur = cur.next)
            ++n; // ȷ������ֵ�ĳ���
        var ans = new int[n];
        var st = new ArrayDeque<Integer>(); // ����ջ���ڵ��±꣩
        int i = 0;
        for (var cur = head; cur != null; cur = cur.next) {
            while (!st.isEmpty() && ans[st.peek()] < cur.val)
                ans[st.pop()] = cur.val; // ans[st.pop()] ���治���ٷ��ʵ���
            st.push(i);
            ans[i++] = cur.val;
        }
        for (var idx : st)
            ans[idx] = 0; // û����һ������Ԫ��
        return ans;
    }
}
```

```cpp
class Solution {
public:
    vector<int> nextLargerNodes(ListNode *head) {
        vector<int> ans;
        stack<int> st; // ����ջ��ֻ���±꣩
        for (auto cur = head; cur; cur = cur->next) {
            while (!st.empty() && ans[st.top()] < cur->val) {
                ans[st.top()] = cur->val; // ans[st.top()] ���治���ٷ��ʵ���
                st.pop();
            }
            st.push(ans.size()); // ��ǰ ans �ĳ��Ⱦ��ǵ�ǰ�ڵ���±�
            ans.push_back(cur->val);
        }
        while (!st.empty()) {
            ans[st.top()] = 0; // û����һ������Ԫ��
            st.pop();
        }
        return ans;
    }
};
```

```go
func nextLargerNodes(head *ListNode) (ans []int) {
    st := []int{} // ����ջ���ڵ��±꣩
    for cur := head; cur != nil; cur = cur.Next {
        x := cur.Val
        for len(st) > 0 && ans[st[len(st)-1]] < x {
            ans[st[len(st)-1]] = x // ans[st[len(st)-1]] ���治���ٷ��ʵ���
            st = st[:len(st)-1]
        }
        st = append(st, len(ans)) // ��ǰ ans �ĳ��Ⱦ��ǵ�ǰ�ڵ���±�
        ans = append(ans, x)
    }
    for _, i := range st {
        ans[i] = 0 // û����һ������Ԫ��
    }
    return ans
}
```

#### ���Ӷȷ���

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ Ϊ����ĳ��ȡ���Ȼ����д�˸�����ѭ������վ��ÿ��Ԫ�ص��ӽǿ������Ԫ���ڶ���ѭ���������ջ��ջ��һ�Σ������������ѭ����ʱ�临�Ӷ�Ϊ $O(n)$��
-   �ռ临�Ӷȣ�$O(n)$������ջ������� $O(n)$ ������

#### ǿ��ѵ��

���⸽һЩ����ջ/�������е���Ŀ��

����ʱ��������Ŀ���ʲô�������סһ������ԭ��**��ʱ�Ƴ��������ݣ���֤ջ/���е�������**��

#### ����ջ

-   [496\. ��һ������Ԫ�� I](https://leetcode.cn/problems/next-greater-element-i/)������ջģ���⣩
-   [503\. ��һ������Ԫ�� II](https://leetcode.cn/problems/next-greater-element-ii/)
-   [2454\. ��һ������Ԫ�� IV](https://leetcode.cn/problems/next-greater-element-iv/)
-   [456\. 132 ģʽ](https://leetcode.cn/problems/132-pattern/)
-   [739\. ÿ���¶�](https://leetcode.cn/problems/daily-temperatures/)
-   [901\. ��Ʊ�۸���](https://leetcode.cn/problems/online-stock-span/)
-   [1019\. �����е���һ������ڵ�](https://leetcode.cn/problems/next-greater-node-in-linked-list/)
-   [1124\. �������õ��ʱ���](https://leetcode.cn/problems/longest-well-performing-interval/)
-   [1475\. ��Ʒ�ۿۺ�����ռ۸�](https://leetcode.cn/problems/final-prices-with-a-special-discount-in-a-shop/)
-   [2289\. ʹ���鰴�ǵݼ�˳������](https://leetcode.cn/problems/steps-to-make-array-non-decreasing/)

#### ����ϵ��

-   [84\. ��״ͼ�����ľ���](https://leetcode.cn/problems/largest-rectangle-in-histogram/)
-   [85\. ������](https://leetcode.cn/problems/maximal-rectangle/)
-   [1504\. ͳ��ȫ 1 �Ӿ���](https://leetcode.cn/problems/count-submatrices-with-all-ones/)

#### �ֵ�����С

-   [316\. ȥ���ظ���ĸ](https://leetcode.cn/problems/remove-duplicate-letters/)
-   [316 ��չ���ظ�����������һ����ֵ](https://leetcode.cn/contest/tianchi2022/problems/ev2bru/)
-   [402\. �Ƶ� K λ����](https://leetcode.cn/problems/remove-k-digits/)
-   [321\. ƴ�������](https://leetcode.cn/problems/create-maximum-number/)

#### ���׷�

-   [907\. ���������Сֵ֮��](https://leetcode.cn/problems/sum-of-subarray-minimums/)
-   [1856\. ��������С�˻������ֵ](https://leetcode.cn/problems/maximum-subarray-min-product/)
-   [2104\. �����鷶Χ��](https://leetcode.cn/problems/sum-of-subarray-ranges/)
-   [2281\. ��ʦ����������](https://leetcode.cn/problems/sum-of-total-strength-of-wizards/)

#### ��������

ԭ��� [����ͼ�붮��������](https://leetcode.cn/problems/shortest-subarray-with-sum-at-least-k/solution/liang-zhang-tu-miao-dong-dan-diao-dui-li-9fvh/)��

-   [������ 59-II. ���е����ֵ](https://leetcode.cn/problems/dui-lie-de-zui-da-zhi-lcof/)����������ģ���⣩
-   [239\. �����������ֵ](https://leetcode.cn/problems/sliding-window-maximum/)
-   [862\. ������Ϊ K �����������](https://leetcode.cn/problems/shortest-subarray-with-sum-at-least-k/)
-   [1438\. ���Բ�������Ƶ������������](https://leetcode.cn/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/)
