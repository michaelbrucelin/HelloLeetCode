### [达到末尾下标所需的最大跳跃次数](https://leetcode.cn/problems/maximum-number-of-jumps-to-reach-the-last-index/solutions/3963819/da-dao-mo-wei-xia-biao-suo-xu-de-zui-da-jfcqa/)

#### 方法一：记忆化搜索

**思路与算法**

设给定数组 $nums$ 的长度是 $n$。根据题意可知当位于下标 $i$ 时，如果存在下标 $j$ 满足 $i<j$ 且 $\vert nums[j]-nums[i]\vert \le target$，则可以从下标 $i$ 跳跃到下标 $j$，因此可以使用记忆化搜索或者动态规划计算到达每个下标的最大跳跃次数。在这里我们自顶向下的记忆化搜索，设 $dfs(j)$ 表示从下标 $j$ 跳跃到下标 $n-1$ 处的最大跳跃次数，如果 $i$ 可以跳跃到 $j$ 处，此时 $dfs(i)=dfs(j)+1$。我们枚举取所有可能的 $j$，找到最大的 $dfs(j)+1$，即为 $dfs(i)$。如果不存在合法的 $j$，那么此时 $dfs(i)=-\infty $。

- 初始化：所有子状态 $dfs(i)$ 全部初始为 $-\infty$；
- 递归边界：$dfs(n-1)=0;$
- 递归入口：$dfs(0)$，此时 $dfs(0)$ 即为答案，如果答案为负数则返回 $-1$。

**代码**

```C++
class Solution {
public:
    int maximumJumps(vector<int>& nums, int target) {
        int n = nums.size();
        vector<int> memo(n, INT_MIN);

        function<int(int)> dfs = [&](int i) -> int {
            if (i == n - 1) {
                return 0;
            }
            if (memo[i] != INT_MIN) {
                return memo[i];
            }
            int res = INT_MIN;
            for (int j = i + 1; j < n; j++) {
                if (abs(nums[i] - nums[j]) <= target) {
                    res = max(res, dfs(j) + 1);
                }
            }
            return memo[i] = res;
        };

        int ans = dfs(0);
        return ans < 0 ? -1 : ans;
    }
};
```

```Java
class Solution {
    public int maximumJumps(int[] nums, int target) {
        int n = nums.length;
        int[] memo = new int[n];
        Arrays.fill(memo, Integer.MIN_VALUE);

        int ans = dfs(0, nums, target, memo);
        return ans < 0 ? -1 : ans;
    }

    private int dfs(int i, int[] nums, int target, int[] memo) {
        int n = nums.length;
        if (i == n - 1) {
            return 0;
        }
        if (memo[i] != Integer.MIN_VALUE) {
            return memo[i];
        }
        int res = Integer.MIN_VALUE;
        for (int j = i + 1; j < n; j++) {
            if (Math.abs(nums[i] - nums[j]) <= target) {
                res = Math.max(res, dfs(j, nums, target, memo) + 1);
            }
        }
        return memo[i] = res;
    }
}
```

```CSharp
public class Solution {
    public int MaximumJumps(int[] nums, int target) {
        int n = nums.Length;
        int[] memo = new int[n];
        Array.Fill(memo, int.MinValue);

        Func<int, int> dfs = null;
        dfs = (i) => {
            if (i == n - 1) {
                return 0;
            }
            if (memo[i] != int.MinValue) {
                return memo[i];
            }
            int res = int.MinValue;
            for (int j = i + 1; j < n; j++) {
                if (Math.Abs(nums[i] - nums[j]) <= target) {
                    res = Math.Max(res, dfs(j) + 1);
                }
            }
            return memo[i] = res;
        };

        int ans = dfs(0);
        return ans < 0 ? -1 : ans;
    }
}
```

```Go
func maximumJumps(nums []int, target int) int {
    n := len(nums)
    memo := make([]int, n)
    for i := range memo {
        memo[i] = math.MinInt32
    }

    var dfs func(int) int
    dfs = func(i int) int {
        if i == n-1 {
            return 0
        }
        if memo[i] != math.MinInt32 {
            return memo[i]
        }

        res := math.MinInt32
        for j := i + 1; j < n; j++ {
            if abs(nums[i]-nums[j]) <= target {
                res = max(res, dfs(j) + 1)
            }
        }
        memo[i] = res
        return res
    }

    ans := dfs(0)
    if ans < 0 {
        return -1
    }
    return ans
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

```Python
class Solution:
    def maximumJumps(self, nums: List[int], target: int) -> int:
        @cache
        def dfs(i: int):
            if i == len(nums) - 1:
                return 0

            res = -inf
            for j in range(i + 1, len(nums)):
                if abs(nums[i] - nums[j]) <= target:
                    res = max(res, dfs(j) + 1)
            return res

        ans = dfs(0)
        return -1 if ans < 0 else ans
```

```C
int dfs(int i, int* nums, int n, int target, int* memo) {
    if (i == n - 1) {
        return 0;
    }
    if (memo[i] != INT_MIN) {
        return memo[i];
    }

    int res = INT_MIN;
    for (int j = i + 1; j < n; j++) {
        if (abs(nums[i] - nums[j]) <= target) {
            res = fmax(res, dfs(j, nums, n, target, memo) + 1);
        }
    }
    memo[i] = res;
    return res;
}

int maximumJumps(int* nums, int numsSize, int target) {
    int* memo = (int*)malloc(numsSize * sizeof(int));
    for (int i = 0; i < numsSize; i++) {
        memo[i] = INT_MIN;
    }

    int ans = dfs(0, nums, numsSize, target, memo);
    free(memo);
    return ans < 0 ? -1 : ans;
}
```

```JavaScript
var maximumJumps = function(nums, target) {
    const n = nums.length;
    const memo = new Array(n).fill(Number.MIN_SAFE_INTEGER);

    const dfs = (i) => {
        if (i === n - 1) {
            return 0;
        }
        if (memo[i] !== Number.MIN_SAFE_INTEGER) {
            return memo[i];
        }

        let res = Number.MIN_SAFE_INTEGER;
        for (let j = i + 1; j < n; j++) {
            if (Math.abs(nums[i] - nums[j]) <= target) {
                res = Math.max(res, dfs(j) + 1);
            }
        }
        memo[i] = res;
        return res;
    };

    const ans = dfs(0);
    return ans < 0 ? -1 : ans;
};
```

```TypeScript
function maximumJumps(nums: number[], target: number): number {
    const n: number = nums.length;
    const memo: number[] = new Array(n).fill(Number.MIN_SAFE_INTEGER);

    const dfs = (i: number): number => {
        if (i === n - 1) {
            return 0;
        }
        if (memo[i] !== Number.MIN_SAFE_INTEGER) {
            return memo[i];
        }

        let res: number = Number.MIN_SAFE_INTEGER;
        for (let j: number = i + 1; j < n; j++) {
            if (Math.abs(nums[i] - nums[j]) <= target) {
                res = Math.max(res, dfs(j) + 1);
            }
        }
        memo[i] = res;
        return res;
    };

    const ans: number = dfs(0);
    return ans < 0 ? -1 : ans;
}
```

```Rust
impl Solution {
    pub fn maximum_jumps(nums: Vec<i32>, target: i32) -> i32 {
        let n = nums.len();
        let mut memo = vec![i32::MIN; n];

        fn dfs(i: usize, nums: &Vec<i32>, target: i32, memo: &mut Vec<i32>) -> i32 {
            let n = nums.len();
            if i == n - 1 {
                return 0;
            }
            if memo[i] != i32::MIN {
                return memo[i];
            }

            let mut res = i32::MIN;
            for j in i + 1..n {
                if (nums[i] - nums[j]).abs() <= target {
                    res = res.max(dfs(j, nums, target, memo) + 1);
                }
            }
            memo[i] = res;
            res
        }

        let ans = dfs(0, &nums, target, &mut memo);
        if ans < 0 { -1 } else { ans }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是数组 $nums$ 长度。对于每个状态 $dfs(i)$ 需要遍历 $n$ 次，因此总的时间复杂度为 $O(n^2)$。
- 空间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 长度。一共有 $n$ 个子状态需要存储。

#### 方法二：动态规划

**思路与算法**

同样我们可以使用自底向上的动态规划，我们用 $dp[i]$ 表示从下标 $0$ 到达下标 $i$ 的最大跳跃次数，如果不能到达下标 $i$ 则 $dp[i]=-\infty $。初始时将 $dp$ 中的所有状态值设为 $-\infty$。

- 当 $i=0$ 时，到达下标 $0$ 的跳跃次数是 $0$，此时动态规划的边界是 $dp[0]=0$。
- 当 $i>0$ 时，对于满足 $0\le j<i$ 且满足 $\vert nums[j]-nums[i]\vert \le target$ 的任意下标 $j$，有 $dp[i]\ge dp[j]+1$，为了使 $dp[i]$ 最大化，应寻找符合要求的最大的 $dp[j]$，此时 $dp[i]=max{dp[j]}+1$。因此动态规划的转移方程为：

$$dp[i]=max{dp[j]}+1\enspace if\enspace 0\le j<i\enspace\&\enspace\vert nums[j]-nums[i]\vert \le target$$

我们从小到大遍历每个 $i$ 并计算 $dp[i]$。计算得到 $dp[n-1]$ 即为到达下标 $n-1$ 的最大跳跃次数。

**代码**

```C++
class Solution {
public:
    int maximumJumps(vector<int>& nums, int target) {
        int n = nums.size();
        vector<int> dp(n, INT_MIN);
        dp[0] = 0;
        for (int i = 1; i < n; i++) {
            for (int j = 0; j < i; j++) {
                if (abs(nums[j] - nums[i]) <= target) {
                    dp[i] = max(dp[i], dp[j] + 1);
                }
            }
        }

        return dp[n - 1] < 0 ? -1 : dp[n - 1];
    }
};
```

```Java
class Solution {
    public int maximumJumps(int[] nums, int target) {
        int n = nums.length;
        int[] dp = new int[n];
        Arrays.fill(dp, Integer.MIN_VALUE);
        dp[0] = 0;

        for (int i = 1; i < n; i++) {
            for (int j = 0; j < i; j++) {
                if (Math.abs(nums[j] - nums[i]) <= target) {
                    dp[i] = Math.max(dp[i], dp[j] + 1);
                }
            }
        }

        return dp[n - 1] < 0 ? -1 : dp[n - 1];
    }
}
```

```CSharp
public class Solution {
    public int MaximumJumps(int[] nums, int target) {
        int n = nums.Length;
        int[] dp = new int[n];
        Array.Fill(dp, int.MinValue);
        dp[0] = 0;

        for (int i = 1; i < n; i++) {
            for (int j = 0; j < i; j++) {
                if (Math.Abs(nums[j] - nums[i]) <= target) {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        return dp[n - 1] < 0 ? -1 : dp[n - 1];
    }
}
```

```Go
func maximumJumps(nums []int, target int) int {
    n := len(nums)
    dp := make([]int, n)
    for i := range dp {
        dp[i] = math.MinInt32
    }
    dp[0] = 0

    for i := 1; i < n; i++ {
        for j := 0; j < i; j++ {
            if abs(nums[j] - nums[i]) <= target {
                dp[i] = max(dp[i], dp[j] + 1)
            }
        }
    }

    if dp[n - 1] < 0 {
        return -1
    }
    return dp[n - 1]
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

```Python
from typing import List

class Solution:
    def maximumJumps(self, nums: List[int], target: int) -> int:
        n = len(nums)
        dp = [float('-inf')] * n
        dp[0] = 0

        for i in range(1, n):
            for j in range(i):
                if abs(nums[j] - nums[i]) <= target:
                    dp[i] = max(dp[i], dp[j] + 1)

        return -1 if dp[n - 1] < 0 else dp[n - 1]
```

```C
int maximumJumps(int* nums, int numsSize, int target) {
    int* dp = (int*)malloc(numsSize * sizeof(int));
    for (int i = 0; i < numsSize; i++) {
        dp[i] = INT_MIN;
    }
    dp[0] = 0;

    for (int i = 1; i < numsSize; i++) {
        for (int j = 0; j < i; j++) {
            if (abs(nums[j] - nums[i]) <= target) {
                if (dp[j] != INT_MIN) {
                    dp[i] = fmax(dp[i], dp[j] + 1);
                }
            }
        }
    }

    int result = dp[numsSize - 1] < 0 ? -1 : dp[numsSize - 1];
    free(dp);
    return result;
}
```

```JavaScript
var maximumJumps = function(nums, target) {
    const n = nums.length;
    const dp = new Array(n).fill(Number.MIN_SAFE_INTEGER);
    dp[0] = 0;

    for (let i = 1; i < n; i++) {
        for (let j = 0; j < i; j++) {
            if (Math.abs(nums[j] - nums[i]) <= target) {
                dp[i] = Math.max(dp[i], dp[j] + 1);
            }
        }
    }

    return dp[n - 1] < 0 ? -1 : dp[n - 1];
};
```

```TypeScript
function maximumJumps(nums: number[], target: number): number {
    const n: number = nums.length;
    const dp: number[] = new Array(n).fill(Number.MIN_SAFE_INTEGER);
    dp[0] = 0;

    for (let i: number = 1; i < n; i++) {
        for (let j: number = 0; j < i; j++) {
            if (Math.abs(nums[j] - nums[i]) <= target) {
                dp[i] = Math.max(dp[i], dp[j] + 1);
            }
        }
    }

    return dp[n - 1] < 0 ? -1 : dp[n - 1];
}
```

```Rust
impl Solution {
    pub fn maximum_jumps(nums: Vec<i32>, target: i32) -> i32 {
        let n = nums.len();
        let mut dp = vec![i32::MIN; n];
        dp[0] = 0;

        for i in 1..n {
            for j in 0..i {
                if (nums[j] - nums[i]).abs() <= target {
                    dp[i] = dp[i].max(dp[j] + 1);
                }
            }
        }

        if dp[n - 1] < 0 { -1 } else { dp[n - 1] }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是数组 $nums$ 长度。需要两层循环遍历所有索引对，因此总的时间复杂度为 $O(n^2)$。
- 空间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 长度。一共有 $n$ 个子状态需要存储。
