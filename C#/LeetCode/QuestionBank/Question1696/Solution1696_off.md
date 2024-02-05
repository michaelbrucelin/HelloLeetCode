### [跳跃游戏 VI](https://leetcode.cn/problems/jump-game-vi/solutions/2627601/tiao-yue-you-xi-vi-by-leetcode-solution-fdpb/)

#### 方法一：动态规划 + 双端队列

##### 思路与算法

每一个位置的最大值取决于前面 $k$ 步的最大得分，再加上当前位置的得分，由此我们想到可以使用动态规划来解决这个问题。

用 $\textit{dp}[i]$ 来表示到达位置 $i$ 的最大得分。初始状态 $\textit{dp}[0] = \textit{nums}[0]$，表示位置 $0$ 的得分是它本身的得分。状态转移方程是

$$\textit{dp}[i] = \max\{\textit{dp}[j]\}$$

其中 $\max(0, i - k) \leq j < i$。

其中前 $k$ 步的最大值，使用优先队列可以达到 $O(n\times\log{n})$ 的时间复杂度，使用双端队列可以达到 $O(n)$ 的时间复杂度。具体解释，可以参考下题解[「239. 滑动窗口最大值」](https://leetcode.cn/problems/sliding-window-maximum/solutions/543426/hua-dong-chuang-kou-zui-da-zhi-by-leetco-ki6m/)。

本题解采用双端队列来解决。

##### 代码

```c++
class Solution {
public:
    int maxResult(vector<int>& nums, int k) {
        int n = nums.size();
        vector<int> dp(n);
        dp[0] = nums[0];
        deque<int> queue;
        queue.push_back(0);
        for (int i = 1; i < n; i++) {
            while (!queue.empty() && queue.front() < i - k) {
                queue.pop_front();
            }
            dp[i] = dp[queue.front()] + nums[i];
            while (!queue.empty() && dp[queue.back()] <= dp[i]) {
                queue.pop_back();
            }
            queue.push_back(i);
        }
        return dp[n - 1];
    }
};
```

```java
class Solution {
    public int maxResult(int[] nums, int k) {
        int n = nums.length;
        int[] dp = new int[n];
        dp[0] = nums[0];
        Deque<Integer> queue = new ArrayDeque<>();
        queue.offerLast(0);
        for (int i = 1; i < n; i++) {
            while (queue.peekFirst() < i - k) {
                queue.pollFirst();
            }
            dp[i] = dp[queue.peekFirst()] + nums[i];
            while (!queue.isEmpty() && dp[queue.peekLast()] <= dp[i]) {
                queue.pollLast();
            }
            queue.offerLast(i);
        }
        return dp[n - 1];
    }
}
```

```python
class Solution:
    def maxResult(self, nums: List[int], k: int) -> int:
        n = len(nums)
        dp = [0] * n
        dp[0] = nums[0]
        queue = deque([0])
        for i in range(1, n):
            while queue and queue[0] < i - k:
                queue.popleft()
            dp[i] = dp[queue[0]] + nums[i]
            while queue and dp[queue[-1]] <= dp[i]:
                queue.pop()
            queue.append(i)
        return dp[n - 1]
```

```javascript
var maxResult = function(nums, k) {
    const n = nums.length;
    const dp = new Array(n).fill(0);
    dp[0] = nums[0];
    const queue = [];
    queue.push(0);
    for (let i = 1; i < n; i++) {
        while (queue.length > 0 && queue[0] < i - k) {
            queue.shift();
        }
        dp[i] = dp[queue[0]] + nums[i];
        while (queue.length > 0 && dp[queue[queue.length - 1]] <= dp[i]) {
            queue.pop();
        }
        queue.push(i);
    }
    return dp[n - 1];
};
```

```go
func maxResult(nums []int, k int) int {
    n := len(nums)
    dp := make([]int, n)
    dp[0] = nums[0]
    queue := make([]int, n) // 模拟双端队列
    qi, qj := 0, 1
    for i := 1; i < n; i++ {
        for qi < qj && queue[qi] < i - k {
            qi++
        }
        dp[i] = dp[queue[qi]] + nums[i]
        for qi < qj && dp[queue[qj - 1]] <= dp[i] {
            qj--
        }
        queue[qj] = i
        qj++
    }
    return dp[n - 1]
}
```

```c
int maxResult(int *nums, int n, int k) {
    int *dp = calloc(n, sizeof(int));
    dp[0] = nums[0];
    int *queue = calloc(n, sizeof(int));
    int head = 0, tail = 0;
    queue[tail++] = 0; // 模拟双端队列
    for (int i = 1; i < n; i++) {
        while (head < tail && queue[head] < i - k) {
            head++;
        }
        dp[i] = dp[queue[head]] + nums[i];
        while (head < tail && dp[queue[tail - 1]] <= dp[i]) {
            tail--;
        }
        queue[tail++] = i;
    }
    int result = dp[n - 1];
    free(queue);
    free(dp);
    return result;
}
```

```typescript
function maxResult(nums: number[], k: number): number {
    const n = nums.length;
    const dp: number[] = new Array(n).fill(0);
    dp[0] = nums[0];
    const queue: number[] = [];
    queue.push(0);
    for (let i = 1; i < n; i++) {
        while (queue.length > 0 && queue[0] < i - k) {
            queue.shift();
        }
        dp[i] = dp[queue[0]] + nums[i];
        while (queue.length > 0 && dp[queue[queue.length - 1]] <= dp[i]) {
            queue.pop();
        }
        queue.push(i);
    }
    return dp[n - 1];
};
```

复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(n)$，其中 $n$ 是数组的长度。
