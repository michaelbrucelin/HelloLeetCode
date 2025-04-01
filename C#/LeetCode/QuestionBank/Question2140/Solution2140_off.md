### [解决智力问题](https://leetcode.cn/problems/solving-questions-with-brainpower/solutions/1233147/jie-jue-zhi-li-wen-ti-by-leetcode-soluti-ieuq/)

#### 方法一：动态规划

**提示 1**

我们可以**尝试**用 $dp[i]$ 来表示解决**前 $i$ 道题目**可以获得的最高分数。根据是否选择解决第 $i$ 道题目，会有以下两种情况：

- 不解决第 $i$ 道题目，此时 $dp[i]=dp[i-1]$；
- 解决第 $i$ 道题目，此时要么前面的题目都未解决，要么上一道解决的题目对应的冷冻期已经结束。具体而言：

$$dp[i]=points[i]+\max(0, \max\limits_{j \in [0,i-1],j+brainpower[j]<i}dp[j]).$$

由于每一道题对应的冷冻期都不一样，因此我们很难在不通过遍历 $[0,i-1]$ 闭区间内的全部下标，以判断对应的冷冻期是否结束的情况下更新 $dp[i]$。我们假设题目的总数为 $n$，这样的时间复杂度为 $O(n^2)$，不符合题目要求。

**提示 2**

我们可以从**无后效性**的角度考虑动态规划「状态」的定义。对于每一道题目，解决与否会影响到**后面**一定数量题目的结果，但不会影响到**前面**题目的解决。因此我们可以考虑从反方向定义「状态」，即考虑解决每道题**本身及以后的题目**可以获得的最高分数。

**思路与算法**

根据**提示 2**，我们用 $dp[i]$ 来表示解决**第 $i$ 道题目及以后的题目**可以获得的最高分数。同时，我们从后往前遍历题目，并更新 $dp$ 数组。类似地，根据是否选择解决第 $i$ 道题目，会有以下两种情况：

- 不解决第 $i$ 道题目，此时 $dp[i]=dp[i+1]$；
- 解决第 $i$ 道题目，我们只能解决下标大于 $i+brainpower[i]$ 的题目，而此时根据 $dp$ 数组的定义，解决这些题目的最高分数为 $dp[i+brainpower[i]+1]$（当 $i \ge n$ 的情况下，我们认为 $dp[i]=0$）。因此，我们有：

$$dp[i]=points[i]+dp[i+brainpower[i]+1].$$

综合上述两种情况，我们就得出了 $dp[i]$ 的状态转移方程：

$$dp[i]=max(dp[i+1],points[i]+dp[i+brainpower[i]+1]).$$

在实际计算中，考虑到 $i \ge n$ 的边界条件，我们在定义 $dp$ 数组时，可以预留 $dp[n]=0$ 用来表示没有做任何题目的分数。那么上面的转移方程变为：

$$dp[i]=max(dp[i+1],points[i]+dp[min(n,i+brainpower[i]+1)]).$$

最终，$dp[0]$ 即为考试中可以获得的最高分数，我们返回该数值作为答案。

**细节**

在计算 $dp$ 数组时，数组元素的大小有可能超过 $32$ 为有符号整数的上界，因此对于 C++ 等语言，我们需要用 $64$ 位整数来存储 $dp$ 数组。

**代码**

```C++
class Solution {
public:
    long long mostPoints(vector<vector<int>>& questions) {
        int n = questions.size();
        vector<long long> dp(n + 1);   // 解决每道题及以后题目的最高分数
        for (int i = n - 1; i >= 0; --i) {
            dp[i] = max(dp[i + 1], questions[i][0] + dp[min(n, i + questions[i][1] + 1)]);
        }
        return dp[0];
    }
};
```

```Python
    def mostPoints(self, questions: List[List[int]]) -> int:
        n = len(questions)
        dp = [0] * (n + 1)   # 解决每道题及以后题目的最高分数
        for i in range(n - 1, -1, -1):
            dp[i] = max(dp[i + 1], questions[i][0] + dp[min(n, i + questions[i][1] + 1)])
        return dp[0]
```

```Java
class Solution {
    public long mostPoints(int[][] questions) {
        int n = questions.length;
        long[] dp = new long[n + 1]; // 解决每道题及以后题目的最高分数
        for (int i = n - 1; i >= 0; i--) {
            dp[i] = Math.max(dp[i + 1], questions[i][0] + dp[Math.min(n, i + questions[i][1] + 1)]);
        }
        return dp[0];
    }
}
```

```CSharp
public class Solution {
    public long MostPoints(int[][] questions) {
        int n = questions.Length;
        long[] dp = new long[n + 1]; // 解决每道题及以后题目的最高分数
        for (int i = n - 1; i >= 0; i--) {
            dp[i] = Math.Max(dp[i + 1], questions[i][0] + dp[Math.Min(n, i + questions[i][1] + 1)]);
        }
        return dp[0];
    }
}
```

```Go
func mostPoints(questions [][]int) int64 {
    n := len(questions)
    dp := make([]int64, n + 1) // 解决每道题及以后题目的最高分数
    for i := n - 1; i >= 0; i-- {
        dp[i] = max(dp[i + 1], int64(questions[i][0]) + dp[min(n, i + questions[i][1] + 1)])
    }
    return dp[0]
}
```

```C
long long max(long long a, long long b) {
    return a > b ? a : b;
}

long long min(long long a, long long b) {
    return a < b ? a : b;
}

long long mostPoints(int** questions, int questionsSize, int* questionsColSize) {
    long long dp[questionsSize + 1]; // 解决每道题及以后题目的最高分数
    memset(dp, 0, sizeof(dp));
    for (int i = questionsSize - 1; i >= 0; --i) {
        dp[i] = max(dp[i + 1], questions[i][0] + dp[min(questionsSize, i + questions[i][1] + 1)]);
    }
    long long result = dp[0];
    return result;
}
```

```JavaScript
var mostPoints = function(questions) {
    const n = questions.length;
    const dp = new Array(n + 1).fill(0); // 解决每道题及以后题目的最高分数
    for (let i = n - 1; i >= 0; i--) {
        dp[i] = Math.max(dp[i + 1], questions[i][0] + dp[Math.min(n, i + questions[i][1] + 1)]);
    }
    return dp[0];
};
```

```JavaScript
function mostPoints(questions: number[][]): number {
    const n = questions.length;
    const dp: number[] = new Array(n + 1).fill(0); // 解决每道题及以后题目的最高分数
    for (let i = n - 1; i >= 0; i--) {
        dp[i] = Math.max(dp[i + 1], questions[i][0] + dp[Math.min(n, i + questions[i][1] + 1)]);
    }
    return dp[0];
};
```

```Rust
impl Solution {
    pub fn most_points(questions: Vec<Vec<i32>>) -> i64 {
        let n = questions.len();
        let mut dp = vec![0i64; n + 1]; // 解决每道题及以后题目的最高分数
        for i in (0..n).rev() {
            dp[i] = dp[i + 1].max(questions[i][0] as i64 + dp[(n).min(i + questions[i][1] as usize + 1)]);
        }
        dp[0]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $questions$ 数组的长度。即为动态规划计算可以获得的最高分数的时间复杂度。
- 空间复杂度：$O(n)$，即为动态规划数组的空间开销。
