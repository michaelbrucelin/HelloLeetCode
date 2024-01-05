### [队列中可以看到的人数](https://leetcode.cn/problems/number-of-visible-people-in-a-queue/solutions/896102/dui-lie-zhong-ke-yi-kan-dao-de-ren-shu-b-k442/)

#### 方法一：单调栈

##### 思路

分析图例可以发现，第 $0$ 个人可以看到的三个人的身高是严格递增的。通过分析是可以验证这个规律，如果满足 $i < j$，此时下标为 $j$ 且靠后的人比下标为 $i$ 且靠前的人矮，那么下标为 $j$ 的人无法被下标 $i$ 之前的人看到。根据这个规律，我们可以想到利用单调栈来解决这个问题。从队伍末尾开始，维护一个单调栈，从栈底到栈顶，身高严格递减。

那么，在维护单调栈的过程中，一个下标为 $i$ 的人能看到的人数，是否就是当前栈里面的人数呢？其实不是，再仔细分析，我们能发现，单调栈里的人，对于当前的人的身高 $heights[i]$：

- 那些身高小于 $heights[i]$ 的，都可以被下标为 $i$ 的人看到；
- 第一个身高大于 $heights[i]$ 的，也可以被下标为 $i$ 的人看到；
- 其余的人，都不能被看到的。

而这些人数，正好可以在维护单调栈时的出栈过程中计算。单调栈是严格递减的，栈顶每个小于当前人身高的元素，都会被弹出栈，如果此时栈非空，那么栈顶元素表示下标为 $i$ 的人能看到的最后一个人。最后将当前人的身高 $heights[i]$ 入栈。

从队伍末尾开始，对每个人都进行这个操作，同时要维护这个单调栈，最后返回结果。

##### 代码

```python
class Solution:
    def canSeePersonsCount(self, heights: List[int]) -> List[int]:
        n = len(heights)
        stack = []
        res = [0] * n
        for i in range(n - 1, -1, -1):
            h = heights[i]
            while stack and h > stack[-1]:
                res[i] += 1
                stack.pop()
            if stack:
                res[i] += 1
            stack.append(h)
        return res
```

```java
class Solution {
    public int[] canSeePersonsCount(int[] heights) {
        int n = heights.length;
        Deque<Integer> stack = new ArrayDeque<Integer>();
        int[] res = new int[n];

        for (int i = n - 1; i >= 0; i--) {
            int h = heights[i];
            while (!stack.isEmpty() && stack.peek() < h) {
                stack.pop();
                res[i]++;
            }
            if (!stack.isEmpty()) {
                res[i]++;
            }
            stack.push(h);
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int[] CanSeePersonsCount(int[] heights) {
        int n = heights.Length;
        Stack<int> stack = new Stack<int>();
        int[] res = new int[n];

        for (int i = n - 1; i >= 0; i--) {
            int h = heights[i];
            while (stack.Count > 0 && stack.Peek() < h) {
                stack.Pop();
                res[i]++;
            }
            if (stack.Count > 0) {
                res[i]++;
            }
            stack.Push(h);
        }
        return res;
    }
}
```

```c++
class Solution {
public:
    vector<int> canSeePersonsCount(vector<int>& heights) {
        int n = heights.size();
        vector<int> stack;
        vector<int> res(n, 0);

        for (int i = n - 1; i >= 0; i--) {
            int h = heights[i];
            while (!stack.empty() && stack.back() < h) {
                stack.pop_back();
                res[i] += 1;
            }
            if (!stack.empty()) {
                res[i] += 1;
            }
            stack.push_back(h);
        }
        return res;
    }
};
```

```c
int* canSeePersonsCount(int* heights, int heightsSize, int* returnSize) {
    int n = heightsSize;
    int stackSize = 0;
    int* stack = (int*)malloc(n * sizeof(int));
    int* res = (int*)malloc(n * sizeof(int));
    *returnSize = n;

    for (int i = n - 1; i >= 0; i--) {
        int h = heights[i];
        res[i] = 0;
        while (stackSize > 0 && stack[stackSize - 1] <= h) {
            stackSize--;
            res[i] += 1;
        }
        if (stackSize > 0) {
            res[i] += 1;
        }
        stack[stackSize++] = h;
    }
    free(stack);
    return res;
}
```

```go
func canSeePersonsCount(heights []int) []int {
    n := len(heights)
    stack := make([]int, 0)
    res := make([]int, n)

    for i := n - 1; i >= 0; i-- {
        h := heights[i]
        for len(stack) > 0 && stack[len(stack)-1] <= h {
            stack = stack[:len(stack)-1]
            res[i] += 1;
        }
        if len(stack) > 0 {
            res[i] += 1;
        }
        stack = append(stack, h)
    }
    return res
}
```

```javascript
var canSeePersonsCount = function(heights) {
    const n = heights.length;
    const stack = [];
    const res = new Array(n).fill(0);

    for (let i = n - 1; i >= 0; i--) {
        const h = heights[i];
        while (stack.length > 0 && stack[stack.length - 1] <= h) {
            stack.pop();
            res[i] += 1;
        }
        if (stack.length > 0) {
            res[i] += 1;
        }
        stack.push(h);
    }
    return res;
};
```

##### 复杂度分析

- 时间复杂度：$O(n)$。每个元素最多入栈和出栈各一次。
- 空间复杂度：$O(n)$，单调栈的空间复杂度是 $O(n)$。
