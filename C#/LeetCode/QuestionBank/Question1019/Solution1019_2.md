#### [【图解单调栈】两种方法，两张图秒懂！附题单（Python/Java/C++/Go）](https://leetcode.cn/problems/next-greater-node-in-linked-list/solutions/2217563/tu-jie-dan-diao-zhan-liang-chong-fang-fa-v9ab/)

#### 方法一：对每个数，寻找它下一个更大元素

![](./assets/img/Solution1019_2_01.png)

对于链表来说，我们可以从头节点开始递归，在「归」的过程中，就相当于是从右到左遍历链表了。

```python
class Solution:
    def nextLargerNodes(self, head: Optional[ListNode]) -> List[int]:
        ans = []
        st = []  # 单调栈（节点值）
        def f(node: Optional[ListNode], i: int) -> None:
            if node is None:
                nonlocal ans
                ans = [0] * i  # i 就是链表长度
                return
            f(node.next, i + 1)
            while st and st[-1] <= node.val:
                st.pop()  # 弹出无用数据
            if st:
                ans[i] = st[-1]  # 栈顶就是第 i 个节点的下一个更大元素
            st.append(node.val)
        f(head, 0)
        return ans
```

```java
class Solution {
    private int[] ans;
    private final Deque<Integer> st = new ArrayDeque<>(); // 单调栈（节点值）

    public int[] nextLargerNodes(ListNode head) {
        f(head, 0);
        return ans;
    }

    private void f(ListNode node, int i) {
        if (node == null) {
            ans = new int[i]; // i 就是链表长度
            return;
        }
        f(node.next, i + 1);
        while (!st.isEmpty() && st.peek() <= node.val)
            st.pop(); // 弹出无用数据
        if (!st.isEmpty())
            ans[i] = st.peek(); // 栈顶就是第 i 个节点的下一个更大元素
        st.push(node.val);
    }
}
```

```cpp
class Solution {
    vector<int> ans;
    stack<int> st; // 单调栈（节点值）

    void f(ListNode *node, int i) {
        if (node == nullptr) {
            ans.resize(i); // i 就是链表长度
            return;
        }
        f(node->next, i + 1);
        while (!st.empty() && st.top() <= node->val)
            st.pop(); // 弹出无用数据
        if (!st.empty())
            ans[i] = st.top(); // 栈顶就是第 i 个节点的下一个更大元素
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
    st := []int{} // 单调栈（节点值）
    var f func(*ListNode, int)
    f = func(node *ListNode, i int) {
        if node == nil {
            ans = make([]int, i) // i 就是链表长度
            return
        }
        f(node.Next, i+1)
        for len(st) > 0 && st[len(st)-1] <= node.Val {
            st = st[:len(st)-1] // 弹出无用数据
        }
        if len(st) > 0 {
            ans[i] = st[len(st)-1] // 栈顶就是第 i 个节点的下一个更大元素
        }
        st = append(st, node.Val)
    }
    f(head, 0)
    return
}
```

不想写递归？也可以反转链表后，从头节点开始遍历。

如何反转链表？见[【基础算法精讲 06】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1sd4y1x7KN%2F)。

```python
class Solution:
    # 206. 反转链表
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
        st = []  # 单调栈（节点值）
        while head:
            while st and st[-1] <= head.val:
                st.pop()  # 弹出无用数据
            ans.append(st[-1] if st else 0)  # 栈顶就是第 i 个节点的下一个更大元素
            st.append(head.val)
            head = head.next
        return ans[::-1]  # 由于是倒着记录答案的，返回前要把答案反转
```

```java
class Solution {
    private int n;

    public int[] nextLargerNodes(ListNode head) {
        head = reverseList(head);
        var ans = new int[n];
        var st = new ArrayDeque<Integer>(); // 单调栈（节点值）
        for (var cur = head; cur != null; cur = cur.next) {
            while (!st.isEmpty() && st.peek() <= cur.val)
                st.pop(); // 弹出无用数据
            ans[--n] = st.isEmpty() ? 0 : st.peek();
            st.push(cur.val);
        }
        return ans;
    }

    // 206. 反转链表
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
    // 206. 反转链表
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
        stack<int> st; // 单调栈（节点值）
        for (auto cur = head; cur; cur = cur->next) {
            while (!st.empty() && st.top() <= cur->val)
                st.pop(); // 弹出无用数据
            // 栈顶就是第 i 个节点的下一个更大元素
            ans.push_back(st.empty() ? 0 : st.top());
            st.push(cur->val);
        }
        // 由于是倒着记录答案的，返回前要把答案反转
        reverse(ans.begin(), ans.end());
        return ans;
    }
};
```

```go
// 206. 反转链表
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
    st := []int{} // 单调栈（节点值）
    for cur := head; cur != nil; cur = cur.Next {
        for len(st) > 0 && st[len(st)-1] <= cur.Val {
            st = st[:len(st)-1] // 弹出无用数据
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

#### 复杂度分析

-   时间复杂度：$O(n)$，其中 $n$ 为链表的长度。虽然我们写了个二重循环，但站在每个元素的视角看，这个元素在二重循环中最多入栈出栈各一次，因此整个二重循环的时间复杂度为 $O(n)$。
-   空间复杂度：$O(n)$。单调栈中最多有 $O(n)$ 个数。

#### 方法二：用每个数，更新其它数的下一个更大元素

![](./assets/img/Solution1019_2_02.png)

由于记录答案需要元素的下标，所以栈中除了保存元素值以外，还需要保存元素的下标。

```python
class Solution:
    def nextLargerNodes(self, head: Optional[ListNode]) -> List[int]:
        ans = []
        st = []  # 单调栈（节点值，节点下标）
        while head:
            while st and st[-1][0] < head.val:
                ans[st.pop()[1]] = head.val  # 用当前节点值更新答案
            st.append((head.val, len(ans)))  # 当前 ans 的长度就是当前节点的下标
            ans.append(0)  # 占位
            head = head.next
        return ans
```

```java
class Solution {
    public int[] nextLargerNodes(ListNode head) {
        int n = 0;
        for (var cur = head; cur != null; cur = cur.next)
            ++n; // 确定返回值的长度
        var ans = new int[n];
        var st = new ArrayDeque<int[]>(); // 单调栈（节点值，节点下标）
        int i = 0;
        for (var cur = head; cur != null; cur = cur.next) {
            while (!st.isEmpty() && st.peek()[0] < cur.val)
                ans[st.pop()[1]] = cur.val; // 用当前节点值更新答案
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
        stack<pair<int, int>> st; // 单调栈（节点值，节点下标）
        for (auto cur = head; cur; cur = cur->next) {
            while (!st.empty() && st.top().first < cur->val) {
                ans[st.top().second] = cur->val; // 用当前节点值更新答案
                st.pop();
            }
            // 当前 ans 的长度就是当前节点的下标
            st.emplace(cur->val, ans.size());
            ans.push_back(0); // 占位
        }
        return ans;
    }
};
```

```go
func nextLargerNodes(head *ListNode) (ans []int) {
    type pair struct{ x, i int }
    st := []pair{} // 单调栈（节点值，节点下标）
    for cur := head; cur != nil; cur = cur.Next {
        x := cur.Val
        for len(st) > 0 && st[len(st)-1].x < x {
            ans[st[len(st)-1].i] = x // 用当前节点值更新答案
            st = st[:len(st)-1]
        }
        // 当前 ans 的长度就是当前节点的下标
        st = append(st, pair{x, len(ans)})
        ans = append(ans, 0) // 占位
    }
    return ans
}
```

#### 优化

把第 iii 个节点的值记录到 ans\[i\]\\textit{ans}\[i\]ans\[i\]，这样栈中就可以只保存下标了。

在循环结束后，栈中下标对应元素是没有下一个更大元素的，所以要把栈中的下标对应的 ans\\textit{ans}ans 置为 000。

```python
class Solution:
    def nextLargerNodes(self, head: Optional[ListNode]) -> List[int]:
        ans = []
        st = []  # 单调栈（节点下标）
        while head:
            while st and ans[st[-1]] < head.val:
                ans[st.pop()] = head.val  # ans[st.pop()] 后面不会再访问到了
            st.append(len(ans))  # 当前 ans 的长度就是当前节点的下标
            ans.append(head.val)
            head = head.next
        for i in st:
            ans[i] = 0  # 没有下一个更大元素
        return ans
```

```java
class Solution {
    public int[] nextLargerNodes(ListNode head) {
        int n = 0;
        for (var cur = head; cur != null; cur = cur.next)
            ++n; // 确定返回值的长度
        var ans = new int[n];
        var st = new ArrayDeque<Integer>(); // 单调栈（节点下标）
        int i = 0;
        for (var cur = head; cur != null; cur = cur.next) {
            while (!st.isEmpty() && ans[st.peek()] < cur.val)
                ans[st.pop()] = cur.val; // ans[st.pop()] 后面不会再访问到了
            st.push(i);
            ans[i++] = cur.val;
        }
        for (var idx : st)
            ans[idx] = 0; // 没有下一个更大元素
        return ans;
    }
}
```

```cpp
class Solution {
public:
    vector<int> nextLargerNodes(ListNode *head) {
        vector<int> ans;
        stack<int> st; // 单调栈（只存下标）
        for (auto cur = head; cur; cur = cur->next) {
            while (!st.empty() && ans[st.top()] < cur->val) {
                ans[st.top()] = cur->val; // ans[st.top()] 后面不会再访问到了
                st.pop();
            }
            st.push(ans.size()); // 当前 ans 的长度就是当前节点的下标
            ans.push_back(cur->val);
        }
        while (!st.empty()) {
            ans[st.top()] = 0; // 没有下一个更大元素
            st.pop();
        }
        return ans;
    }
};
```

```go
func nextLargerNodes(head *ListNode) (ans []int) {
    st := []int{} // 单调栈（节点下标）
    for cur := head; cur != nil; cur = cur.Next {
        x := cur.Val
        for len(st) > 0 && ans[st[len(st)-1]] < x {
            ans[st[len(st)-1]] = x // ans[st[len(st)-1]] 后面不会再访问到了
            st = st[:len(st)-1]
        }
        st = append(st, len(ans)) // 当前 ans 的长度就是当前节点的下标
        ans = append(ans, x)
    }
    for _, i := range st {
        ans[i] = 0 // 没有下一个更大元素
    }
    return ans
}
```

#### 复杂度分析

-   时间复杂度：$O(n)$，其中 $n$ 为链表的长度。虽然我们写了个二重循环，但站在每个元素的视角看，这个元素在二重循环中最多入栈出栈各一次，因此整个二重循环的时间复杂度为 $O(n)$。
-   空间复杂度：$O(n)$。单调栈中最多有 $O(n)$ 个数。

#### 强化训练

另外附一些单调栈/单调队列的题目。

做题时，无论题目变成什么样，请记住一个核心原则：**及时移除无用数据，保证栈/队列的有序性**。

#### 单调栈

-   [496\. 下一个更大元素 I](https://leetcode.cn/problems/next-greater-element-i/)（单调栈模板题）
-   [503\. 下一个更大元素 II](https://leetcode.cn/problems/next-greater-element-ii/)
-   [2454\. 下一个更大元素 IV](https://leetcode.cn/problems/next-greater-element-iv/)
-   [456\. 132 模式](https://leetcode.cn/problems/132-pattern/)
-   [739\. 每日温度](https://leetcode.cn/problems/daily-temperatures/)
-   [901\. 股票价格跨度](https://leetcode.cn/problems/online-stock-span/)
-   [1019\. 链表中的下一个更大节点](https://leetcode.cn/problems/next-greater-node-in-linked-list/)
-   [1124\. 表现良好的最长时间段](https://leetcode.cn/problems/longest-well-performing-interval/)
-   [1475\. 商品折扣后的最终价格](https://leetcode.cn/problems/final-prices-with-a-special-discount-in-a-shop/)
-   [2289\. 使数组按非递减顺序排列](https://leetcode.cn/problems/steps-to-make-array-non-decreasing/)

#### 矩形系列

-   [84\. 柱状图中最大的矩形](https://leetcode.cn/problems/largest-rectangle-in-histogram/)
-   [85\. 最大矩形](https://leetcode.cn/problems/maximal-rectangle/)
-   [1504\. 统计全 1 子矩形](https://leetcode.cn/problems/count-submatrices-with-all-ones/)

#### 字典序最小

-   [316\. 去除重复字母](https://leetcode.cn/problems/remove-duplicate-letters/)
-   [316 扩展：重复个数不超过一个定值](https://leetcode.cn/contest/tianchi2022/problems/ev2bru/)
-   [402\. 移掉 K 位数字](https://leetcode.cn/problems/remove-k-digits/)
-   [321\. 拼接最大数](https://leetcode.cn/problems/create-maximum-number/)

#### 贡献法

-   [907\. 子数组的最小值之和](https://leetcode.cn/problems/sum-of-subarray-minimums/)
-   [1856\. 子数组最小乘积的最大值](https://leetcode.cn/problems/maximum-subarray-min-product/)
-   [2104\. 子数组范围和](https://leetcode.cn/problems/sum-of-subarray-ranges/)
-   [2281\. 巫师的总力量和](https://leetcode.cn/problems/sum-of-total-strength-of-wizards/)

#### 单调队列

原理见 [两张图秒懂单调队列](https://leetcode.cn/problems/shortest-subarray-with-sum-at-least-k/solution/liang-zhang-tu-miao-dong-dan-diao-dui-li-9fvh/)。

-   [面试题 59-II. 队列的最大值](https://leetcode.cn/problems/dui-lie-de-zui-da-zhi-lcof/)（单调队列模板题）
-   [239\. 滑动窗口最大值](https://leetcode.cn/problems/sliding-window-maximum/)
-   [862\. 和至少为 K 的最短子数组](https://leetcode.cn/problems/shortest-subarray-with-sum-at-least-k/)
-   [1438\. 绝对差不超过限制的最长连续子数组](https://leetcode.cn/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/)
