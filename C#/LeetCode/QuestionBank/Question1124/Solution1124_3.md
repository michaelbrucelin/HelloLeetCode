#### [方法一：贪心](https://leetcode.cn/problems/longest-well-performing-interval/solutions/2109622/biao-xian-liang-hao-de-zui-chang-shi-jia-rlij/)

**思路与算法**

我们记工作小时数大于 $8$ 的为 $1$ 分，否则为 $-1$ 分。那么原问题可以看做求解区间分数和大于 $0$ 的最长区间长度。为了方便计算区间分数和，我们首先预处理分数前缀和 $s$：

1.  令 $s[0]$ 等于 $0$
2.  设 $n$ 为 $hours$ 的长度，从小到大遍历 $i~(1 \le i \le n)$，若 $hours[i - 1] > 8$，则令 $s[i] = s[i - 1] + 1$，否则令 $s[i] = s[i - 1] - 1$。

至此，我们只需求解最长的一段区间 $[l, r]$ 使得 $s[r] - s[l] > 0$，其中 $0 \le l \le r \le n$。我们固定 $r$，目标找到一个最小的 $l$ 使得 $s[l] < s[r]$。倘若有 $l_1 \le l_2$，并且 $s[l_1] \le s[l_2]$，那么 $l_1$ 要比 $l_2$ 更优，$l_2$ 永远不为成为任意一个 $r$ 的候选。

因此，我们维护一个栈 $stk$，栈中元素为 $s[0] \sim s[r-1]$ 的递减项。具体的，我们遍历 $i ~ (0 \le i \le r - 1)$，如果 $stk$ 为空或者栈顶元素大于 $s[i]$，则将 $s[i]$ 入栈。求解 $l$ 时，我们不断的弹出栈顶元素，直到栈顶元素是最后一个小于 $s[r]$ 的元素，此时栈顶元素所在位置即为我们要求的 $l$。

由于过程中弹出的元素值都要比当前栈顶元素值小，因此这些弹出的元素仍然可能成为后面 $r$ 的候选。如果按照从左到右的顺序去遍历 $r$，我们仍需将这些弹出的元素值再次入栈。这样做的代价是昂贵的，我们不妨试试从大到小遍历 $r$，整个求解过程如下：

1.  我们遍历整个 $s$，求出维护递减序列的栈 $stk$，注意它并不是我们通常意义上的单调栈。
2.  倒序遍历 $r$，对于每个 $r$：
    1.  如果当前 $stk$ 不为空并且栈顶元素小于 $s[r]$，我们设栈顶元素在原数组的下标为 $l$，用 $r − l$ 更新答案，再令栈顶元素出栈。该过程不断循环直到条件不被满足。
    2.  否则，继续考虑下一个 $r$。

这样做的正确性在于：

1.  如果有 $r_1 \lt r_2$，并且 $s[r_1] > s[r_2]$，那么 $r_1$ 所匹配的左端点 $l_1$ 和 $r_2$ 所匹配的左端点 $l_2$ 一定有 $l_1 \le l_2$。在 $stk$ 中， $l_2$ 相比 $l_1$ 更靠近栈顶，倘若求解 $l_2$ 的过程中弹出了某些元素，也不会影响 $l_1$ 的求解。对于 $l_1 = l_2$ 的情况，由于此时满足 $r_2 - l_2 > r_1 - l_1$，因此我们将 $l_2$ 弹出栈也不会影响最终答案的求解。
2.  如果有 $r_1 \lt r_2$，并且 $s[r_1] \le s[r_2]$，那么 $r_2$ 永远不会成为最优答案的右端点。

至此，我们通过维护一个栈 $stk$，倒序遍历 $r$ 求解可能成为最优区间的左端点 $l$，在 $O(n)$ 的时间复杂度内得到答案。

**代码**

```cpp
class Solution {
public:
    int longestWPI(vector<int>& hours) {
        int n = hours.size();
        vector<int> s(n + 1);
        stack<int> stk;
        stk.push(0);
        for (int i = 1; i <= n; i++) {
            s[i] = s[i - 1] + (hours[i - 1] > 8 ? 1 : -1);
            if (s[stk.top()] > s[i]) {
                stk.push(i);
            }
        }

        int res = 0;
        for (int r = n; r >= 1; r--) {
            while (stk.size() && s[stk.top()] < s[r]) {
                res = max(res, r - stk.top());
                stk.pop();
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int longestWPI(int[] hours) {
        int n = hours.length;
        int[] s = new int[n + 1];
        Deque<Integer> stk = new ArrayDeque<Integer>();
        stk.push(0);
        for (int i = 1; i <= n; i++) {
            s[i] = s[i - 1] + (hours[i - 1] > 8 ? 1 : -1);
            if (s[stk.peek()] > s[i]) {
                stk.push(i);
            }
        }

        int res = 0;
        for (int r = n; r >= 1; r--) {
            while (!stk.isEmpty() && s[stk.peek()] < s[r]) {
                res = Math.max(res, r - stk.pop());
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int LongestWPI(int[] hours) {
        int n = hours.Length;
        int[] s = new int[n + 1];
        Stack<int> stk = new Stack<int>();
        stk.Push(0);
        for (int i = 1; i <= n; i++) {
            s[i] = s[i - 1] + (hours[i - 1] > 8 ? 1 : -1);
            if (s[stk.Peek()] > s[i]) {
                stk.Push(i);
            }
        }

        int res = 0;
        for (int r = n; r >= 1; r--) {
            while (stk.Count > 0 && s[stk.Peek()] < s[r]) {
                res = Math.Max(res, r - stk.Pop());
            }
        }
        return res;
    }
}
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int longestWPI(int* hours, int hoursSize) {
    int s[hoursSize + 1];
    int stk[hoursSize + 1];
    int top = 0;
    stk[top++] = 0;
    s[0] = 0;
    for (int i = 1; i <= hoursSize; i++) {
        s[i] = s[i - 1] + (hours[i - 1] > 8 ? 1 : -1);
        if (s[stk[top - 1]] > s[i]) {
            stk[top++] = i;
        }
    }

    int res = 0;
    for (int r = hoursSize; r >= 1; r--) {
        while (top && s[stk[top - 1]] < s[r]) {
            res = MAX(res, r - stk[top - 1]);
            top--;
        }
    }
    return res;
}
```

```javascript
var longestWPI = function(hours) {
    const n = hours.length;
    const s = new Array(n + 1).fill(0);
    const stk = [0];
    for (let i = 1; i <= n; i++) {
        s[i] = s[i - 1] + (hours[i - 1] > 8 ? 1 : -1);
        if (s[stk[stk.length - 1]] > s[i]) {
            stk.push(i);
        }
    }

    let res = 0;
    for (let r = n; r >= 1; r--) {
        while (stk.length && s[stk[stk.length - 1]] < s[r]) {
            res = Math.max(res, r - stk.pop());
        }
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 为 $hours$ 的长度。每个元素最多入栈和出栈一次，因此时间复杂度为 $O(n)$。
-   空间复杂度：$O(n)$，其中 $n$ 为 $hours$ 的长度。
