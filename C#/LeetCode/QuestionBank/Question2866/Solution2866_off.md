### [美丽塔 II](https://leetcode.cn/problems/beautiful-towers-ii/solutions/2563770/mei-li-ta-ii-by-leetcode-solution-2j4s/)

#### 方法一：单调栈

##### 思路与算法

根据题意可以知道，假设数组的长度为 $n$，对于**山状数组** $heights$ 定义如下：

- 假设 $heights[i]$ 为数组中的最大值，则 $i$ 左边的值均小于等于 $heights[i]$，$i$ 右边的值均小于等于 $heights[i]$；
- $i$ 的左侧，从 $0$ 开始到 $i$ 为**非递减**关系，即 $j \in [1, i]$ 时，均满足 $heights[j-1] \le heights[j]$;
- $i$ 的右侧，从 $i$ 开始到 $n-1$ 为**非递增**关系，即 $j \in [i, n-2]$ 时，均满足 $heights[j+1] \le heights[j]$;

题目给定了**山状数组**数组中每个元素的上限，即 $heights[i] \le maxHeights[i]$，题目要求返回的**山状数组**所有元素之和的最大值。根据以上分析可知：

- 对于 $j \in [0,i-1]$ 时，此时 $\max(heights[j]) = \min(heights[j + 1], maxHeights[j])$；
- 对于 $j \in [i + 1,n-1]$ 时，此时 $\max(heights[j]) = \min(heights[j - 1], maxHeights[j])$；
- 假设此时**山状数组**的**山顶**为 $heights[i]$，此时整个**山状数组**的所有元素的最大值即可确定，此时数组元素和的最大值也可确定；
- 对于数组中的每个元素尽量取最大值使得整个数组元素之和最大；

根据以上分析，我们依次枚举以 $maxHeights[i]$ 为**山顶**的**山状数组**元素之和即可求出最大的高度和。最直接的办法就是两层循环，外层循环依次枚举 $maxHeights[i]$ 为**山顶**，在内层循环中分别求出 $i$ 的左侧元素与右侧的元素，即可求出所有元素之和，此时需要的时间复杂度为 $O(n^2)$，按照题目给定的数量级会存在超时，需要进一步优化。

对于每个索引 $i$，可以将数组分为两部分处理，即保证数组的左侧构成**非递减**，右侧构成**非递增**。为了使得数组元素尽可能大，此时 $heights[i]$ 应取值为 $maxHeights[i]$，设区间 $[0,i]$ 构成的**非递减**数组元素和最大值为 $prefix[i]$，区间 $[i,n-1]$ 构成的**非递增**数组元素和最大值为 $suffix[i]$，此时构成的**山状数组**的元素之和即为$prefix[i] + suffix[i] - maxHeights[i]$。

如何使得数组成为递增或递减，此时我们想到「[单调栈](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fds%2Fmonotonous-stack%2F)」，「[单调栈](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fds%2Fmonotonous-stack%2F)」可以保证栈中数据的单调性，利用单调栈将连续子数组变为非递减或非递减。

- 对于左侧的**非递减**：将 $maxHeights$ 依次入栈，对于第 $i$ 个元素来说，不断从栈顶弹出元素，直到栈顶元素小于等于 $maxHeights[i]$。假设此时栈顶元素为 $maxHeights[j]$，则区间 $[j+1,i-1]$ 中的元素最多只能取到 $maxHeights[i]$，则 $prefix[i] = prefix[j] + (i - j) \times maxHeights[i]$；
- 对于右侧的**非递减**：将 $maxHeights$ 依次入栈，对于第 $i$ 个元素来说，不断从栈顶弹出元素，直到栈顶元素小于等于 $maxHeights[i]$。假设此时栈顶元素为 $maxHeights[j]$，则区间 $[i+1,j-1]$ 中的元素最多只能取到 $maxHeights[i]$，则 $suffix[i] = suffix[j] + (j - i) \times maxHeights[i]$；

我们按照上述规则枚举每个位置 $i$，并计算出以 $i$ 为**山顶**的数组之和，此时**山状数组**的最大值即为 $\max(prefix[i] + suffix[i] - maxHeights[i])$。

代码

```c++
class Solution {
public:
    long long maximumSumOfHeights(vector<int>& maxHeights) {
        int n = maxHeights.size();
        long long res = 0;
        vector<long long> prefix(n), suffix(n);
        stack<int> stack1, stack2;

        for (int i = 0; i < n; i++) {
            while (!stack1.empty() && maxHeights[i] < maxHeights[stack1.top()]) {
                stack1.pop();
            }
            if (stack1.empty()) {
                prefix[i] = (long long)(i + 1) * maxHeights[i];
            } else {
                prefix[i] = prefix[stack1.top()] + (long long)(i - stack1.top()) * maxHeights[i];
            }
            stack1.emplace(i);
        }
        for (int i = n - 1; i >= 0; i--) {
            while (!stack2.empty() && maxHeights[i] < maxHeights[stack2.top()]) {
                stack2.pop();
            }
            if (stack2.empty()) {
                suffix[i] = (long long)(n - i) * maxHeights[i];
            } else {
                suffix[i] = suffix[stack2.top()] + (long long)(stack2.top() - i) * maxHeights[i];
            }
            stack2.emplace(i);
            res = max(res, prefix[i] + suffix[i] - maxHeights[i]);
        }
        return res;
    }
};
```

```java
class Solution {
    public long maximumSumOfHeights(List<Integer> maxHeights) {
        int n = maxHeights.size();
        long res = 0;
        long[] prefix = new long[n];
        long[] suffix = new long[n];
        Deque<Integer> stack1 = new ArrayDeque<Integer>();
        Deque<Integer> stack2 = new ArrayDeque<Integer>();

        for (int i = 0; i < n; i++) {
            while (!stack1.isEmpty() && maxHeights.get(i) < maxHeights.get(stack1.peek())) {
                stack1.pop();
            }
            if (stack1.isEmpty()) {
                prefix[i] = (long) (i + 1) * maxHeights.get(i);
            } else {
                prefix[i] = prefix[stack1.peek()] + (long) (i - stack1.peek()) * maxHeights.get(i);
            }
            stack1.push(i);
        }
        for (int i = n - 1; i >= 0; i--) {
            while (!stack2.isEmpty() && maxHeights.get(i) < maxHeights.get(stack2.peek())) {
                stack2.pop();
            }
            if (stack2.isEmpty()) {
                suffix[i] = (long) (n - i) * maxHeights.get(i);
            } else {
                suffix[i] = suffix[stack2.peek()] + (long) (stack2.peek() - i) * maxHeights.get(i);
            }
            stack2.push(i);
            res = Math.max(res, prefix[i] + suffix[i] - maxHeights.get(i));
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public long MaximumSumOfHeights(IList<int> maxHeights) {
        int n = maxHeights.Count;
        long res = 0;
        long[] prefix = new long[n];
        long[] suffix = new long[n];
        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();

        for (int i = 0; i < n; i++) {
            while (stack1.Count > 0 && maxHeights[i] < maxHeights[stack1.Peek()]) {
                stack1.Pop();
            }
            if (stack1.Count == 0) {
                prefix[i] = (long) (i + 1) * maxHeights[i];
            } else {
                prefix[i] = prefix[stack1.Peek()] + (long) (i - stack1.Peek()) * maxHeights[i];
            }
            stack1.Push(i);
        }
        for (int i = n - 1; i >= 0; i--) {
            while (stack2.Count > 0 && maxHeights[i] < maxHeights[stack2.Peek()]) {
                stack2.Pop();
            }
            if (stack2.Count == 0) {
                suffix[i] = (long) (n - i) * maxHeights[i];
            } else {
                suffix[i] = suffix[stack2.Peek()] + (long) (stack2.Peek() - i) * maxHeights[i];
            }
            stack2.Push(i);
            res = Math.Max(res, prefix[i] + suffix[i] - maxHeights[i]);
        }
        return res;
    }
}
```

```c
long long maximumSumOfHeights(int* maxHeights, int maxHeightsSize) {
    int n = maxHeightsSize;
    long long res = 0;
    long long prefix[n], suffix[n];
    int stack1[n], stack2[n];
    int top1 = 0, top2 = 0;
    for (int i = 0; i < n; i++) {
        while (top1 > 0 && maxHeights[i] < maxHeights[stack1[top1 - 1]]) {
            top1--;
        }
        if (top1 == 0) {
            prefix[i] = (long long)(i + 1) * maxHeights[i];
        } else {
            prefix[i] = prefix[stack1[top1 - 1]] + (long long)(i - stack1[top1 - 1]) * maxHeights[i];
        }
        stack1[top1++] = i;
    }
    for (int i = n - 1; i >= 0; i--) {
        while (top2 > 0 && maxHeights[i] < maxHeights[stack2[top2 - 1]]) {
            top2--;
        }
        if (top2 == 0) {
            suffix[i] = (long long)(n - i) * maxHeights[i];
        } else {
            suffix[i] = suffix[stack2[top2 - 1]] + (long long)(stack2[top2 - 1] - i) * maxHeights[i];
        }
        stack2[top2++] = i;
        res = fmax(res, prefix[i] + suffix[i] - maxHeights[i]);
    }
    return res;
}
```

```python
class Solution:
    def maximumSumOfHeights(self, maxHeights: List[int]) -> int:
        n = len(maxHeights)
        res = 0
        prefix, suffix = [0] * n, [0] * n
        stack1, stack2 = [], []

        for i in range(n):
            while len(stack1) > 0 and maxHeights[i] < maxHeights[stack1[-1]]:
                stack1.pop()
            if len(stack1) == 0:
                prefix[i] = (i + 1) * maxHeights[i]
            else:
                prefix[i] = prefix[stack1[-1]] + (i - stack1[-1]) * maxHeights[i]
            stack1.append(i)
        for i in range(n - 1, -1, -1):
            while len(stack2) > 0 and maxHeights[i] < maxHeights[stack2[-1]]:
                stack2.pop()
            if len(stack2) == 0:
                suffix[i] = (n - i) * maxHeights[i]
            else:
                suffix[i] = suffix[stack2[-1]] + (stack2[-1] - i) * maxHeights[i]
            stack2.append(i)
            res = max(res, prefix[i] + suffix[i] - maxHeights[i])
        return res
```

```go
func maximumSumOfHeights(maxHeights []int) int64 {
    n := len(maxHeights)
    prefix := make([]int, n)
    suffix := make([]int, n)
    stack1, stack2 := []int{}, []int{}

    for i := 0; i < n; i++ {
        for len(stack1) > 0 && maxHeights[i] < maxHeights[stack1[len(stack1) - 1]] {
            stack1 = stack1[:len(stack1) - 1]
        }
        if len(stack1) == 0 {
            prefix[i] = (i + 1) * maxHeights[i]
        } else {
            last := stack1[len(stack1) - 1]
            prefix[i] = prefix[last] + (i - last) * maxHeights[i]
        }
        stack1 = append(stack1, i)
    }

    res := 0
    for i := n - 1; i >= 0; i-- {
        for len(stack2) > 0 && maxHeights[i] < maxHeights[stack2[len(stack2) - 1]] {
            stack2 = stack2[:len(stack2) - 1]
        }
        if len(stack2) == 0 {
            suffix[i] = (n - i) * maxHeights[i]
        } else {
            last := stack2[len(stack2) - 1]
            suffix[i] = suffix[last] + (last - i) * maxHeights[i]
        }
        stack2 = append(stack2, i)
        res = max(res, prefix[i] + suffix[i] - maxHeights[i])
    }                
    return int64(res)
}
```

```javascript
var maximumSumOfHeights = function(maxHeights) {
    const n = maxHeights.length;
    const prefix = new Array(n).fill(0);
    const suffix = new Array(n).fill(0);
    const stack1 = [];
    const stack2 = [];
    for (let i = 0; i < n; i++) {
        while (stack1.length > 0 && maxHeights[i] < maxHeights[stack1[stack1.length - 1]]) {
            stack1.pop();
        }
        if (stack1.length == 0) {
            prefix[i] = (i + 1) * maxHeights[i];
        } else {
            let last = stack1[stack1.length - 1];
            prefix[i] = prefix[last] + (i - last) * maxHeights[i]
        }
        stack1.push(i);
    }
    

    let res = 0;
    for (let i = n - 1; i >= 0; i--) {
        while (stack2.length && maxHeights[i] < maxHeights[stack2[stack2.length - 1]]) {
            stack2.pop();
        }
        if (stack2.length == 0) {
            suffix[i] = (n - i) * maxHeights[i];
        } else {
            last = stack2[stack2.length - 1];
            suffix[i] = suffix[last] + (last - i) * maxHeights[i];
        }
        stack2.push(i);
        res = Math.max(res, prefix[i] + suffix[i] - maxHeights[i])
    }                
    return res
};
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 表示给定数组的长度。利用单调栈求解该问题时，只需遍历数组两遍即可，需要的时间为 $O(n)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示给定数组的长度。需要保存前缀和与后缀和，同时利用单调栈保存上一个更小的元素，需要的空间均为 $O(n)$。
