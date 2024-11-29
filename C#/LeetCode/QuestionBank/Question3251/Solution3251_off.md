### [单调数组对的数目 II](https://leetcode.cn/problems/find-the-count-of-monotonic-pairs-ii/solutions/2992036/dan-diao-shu-zu-dui-de-shu-mu-ii-by-leet-puww/)

#### 方法一：动态规划

**思路与算法**

我们使用动态规划来解决本题目，定义 $dp[i][j]$ 表示当 $arr1[i]=j$ 时，前 $i+1$ 个元素组成的单调数组的数目。

因为 $arr1[0]$ 可以为 $0$ 到 $nums[0]$ 之间的任意数，初始化 $dp[0][j]=1$，其中 $j$ 小于 $nums[0]$，其它初始化为零。

我们遍历数据，并且枚举 $arr1$ 中之前和现在的值，按照题目要求的检查单调性，可得到转移方程 $dp[i][v_2]= \sum dp[i-1][v_1]$。

其中满足 $v_1 \le v_2$ 和 $nums[i-1]-v_1 \ge nums[i]-v_2 \ge 0$。

上述方法的代码，可参考题目「[单调数组对的数目 I](https://leetcode.cn/problems/find-the-count-of-monotonic-pairs-i)」的题解。

在上面动态规划的转移方程中，我们观察 $dp[i][j]$ 的公式，可以发现它是 $dp[i-1]$ 的子数组的和。其中 $dp[i][j]$ 和 $dp[i][j-1]$，类似于前缀和数组中相邻的两项，并且由 $nums[i-1]-v_1 \ge nums[i]-v_2 \ge 0$ 的限制条件，我们可以推导出 $v_2 \ge nums[i]-nums[i-1]+v_1$。

再结合 $v_2 \ge v_1$，我们可以得到 $v_2 \ge v_1+d$，其中 $d=max(0,nums[i]-nums[i-1])$。

通过上面的观察和推导，我们可以得到 $dp[i][j]$ 和 $dp[i][j-1]$ 的关系：$dp[i][j]=dp[i][j-1]+dp[i-1][j-d]$。

由此我们得到新的动态转移方程，优化之前算法的复杂度。最后，我们返回 $dp[n-1]$ 的和即为结果。

**代码**

```C++
class Solution {
public:
    int countOfPairs(vector<int>& nums) {
        int n = nums.size(), m = 0, mod = 1e9 + 7;
        for (int num : nums) {
            m = max(m, num);
        }
        vector<vector<int>> dp(n, vector<int>(m + 1, 0));
        for (int a = 0; a <= nums[0]; a++) {
            dp[0][a] = 1;
        }
        for (int i = 1; i < n; i++) {
            int d = max(0, nums[i] - nums[i - 1]);
            for (int j = d; j <= nums[i]; j++) {
                if (j == 0) {
                    dp[i][j] = dp[i - 1][j - d];
                } else {
                    dp[i][j] = (dp[i][j - 1] + dp[i - 1][j - d]) % mod;
                }
            }
        }
        int res = 0;
        for (int num : dp[n - 1]) {
            res = (res + num) % mod;
        }
        return res;
    }
};
```

```Java
class Solution {
    public int countOfPairs(int[] nums) {
        int n = nums.length, m = 0, mod = 1000000007;
        for (int num : nums) {
            m = Math.max(m, num);
        }
        int[][] dp = new int[n][m + 1];
        for (int a = 0; a <= nums[0]; a++) {
            dp[0][a] = 1;
        }
        for (int i = 1; i < n; i++) {
            int d = Math.max(0, nums[i] - nums[i - 1]);
            for (int j = d; j <= nums[i]; j++) {
                if (j == 0) {
                    dp[i][j] = dp[i - 1][j - d];
                } else {
                    dp[i][j] = (dp[i][j - 1] + dp[i - 1][j - d]) % mod;
                }
            }
        }
        int res = 0;
        for (int num : dp[n - 1]) {
            res = (res + num) % mod;
        }
        return res;
    }
}
```

```Python
class Solution:
    def countOfPairs(self, nums: List[int]) -> int:
        mod = 10 ** 9 + 7
        n, m = len(nums), max(nums)
        dp = [[0] * (m + 1) for _ in range(n)]
        for a in range(nums[0] + 1):
            dp[0][a] = 1
        for i in range(1, n):
            d = max(0, nums[i] - nums[i - 1])
            for j in range(d, nums[i] + 1):
                if j == 0:
                    dp[i][j] = dp[i - 1][j - d]
                else:
                    dp[i][j] = (dp[i][j - 1] + dp[i - 1][j - d]) % mod
        return sum(dp[n - 1]) % mod
```

```JavaScript
var countOfPairs = function(nums) {
    const n = nums.length;
    const m = Math.max(...nums);
    const mod = 1e9 + 7;
    const dp = Array(n).fill(0).map(() => Array(m + 1).fill(0));
    for (let a = 0; a <= nums[0]; a++) {
        dp[0][a] = 1;
    }
    for (let i = 1; i < n; i++) {
        const d = Math.max(0, nums[i] - nums[i - 1]);
        for (let j = d; j <= nums[i]; j++) {
            if (j == 0) {
                dp[i][j] = dp[i - 1][j - d];
            } else {
                dp[i][j] = (dp[i][j - 1] + dp[i - 1][j - d]) % mod;
            }
        }
    }
    let res = 0;
    for (let num of dp[n - 1]) {
        res = (res + num) % mod;
    }
    return res;
};
```

```TypeScript
function countOfPairs(nums: number[]): number {
    const n = nums.length;
    const m = Math.max(...nums);
    const mod = 1e9 + 7;
    const dp = Array(n).fill(0).map(() => Array(m + 1).fill(0));
    for (let a = 0; a <= nums[0]; a++) {
        dp[0][a] = 1;
    }
    for (let i = 1; i < n; i++) {
        const d = Math.max(0, nums[i] - nums[i - 1]);
        for (let j = d; j <= nums[i]; j++) {
            if (j == 0) {
                dp[i][j] = dp[i - 1][j - d];
            } else {
                dp[i][j] = (dp[i][j - 1] + dp[i - 1][j - d]) % mod;
            }
        }
    }
    let res = 0;
    for (let num of dp[n - 1]) {
        res = (res + num) % mod;
    }
    return res;
};
```

```Go
func countOfPairs(nums []int) int {
    n := len(nums)
    m := 0
    for _, num := range nums {
        if num > m {
            m = num
        }
    }
    mod := int(1e9 + 7)
    dp := make([][]int, n)
    for i := range dp {
        dp[i] = make([]int, m+1)
    }
    for a := 0; a <= nums[0]; a++ {
        dp[0][a] = 1
    }
    for i := 1; i < n; i++ {
        d := max(0, nums[i]-nums[i-1])
        for j := d; j <= nums[i]; j++ {
            if j == 0 {
                dp[i][j] = dp[i-1][j-d]
            } else {
                dp[i][j] = (dp[i][j-1] + dp[i-1][j-d]) % mod
            }
        }
    }
    res := 0
    for _, num := range dp[n-1] {
        res = (res + num) % mod
    }
    return res
}

func max(a, b int) int {
    if a > b {
        return a
    }
    return b
}
```

```CSharp
public class Solution {
    public int CountOfPairs(int[] nums) {
        int n = nums.Length;
        int m = nums.Max();
        int mod = (int)(1e9 + 7);
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++) {
            dp[i] = new int[m + 1];
        }
        for (int a = 0; a <= nums[0]; a++) {
            dp[0][a] = 1;
        }
        for (int i = 1; i < n; i++) {
            int d = Math.Max(0, nums[i] - nums[i - 1]);
            for (int j = d; j <= nums[i]; j++) {
                if (j == 0) {
                    dp[i][j] = dp[i - 1][j - d];
                } else {
                    dp[i][j] = (dp[i][j - 1] + dp[i - 1][j - d]) % mod;
                }
            }
        }
        int res = 0;
        for (int num in dp[n - 1]) {
            res = (res + num) % mod;
        }
        return res;
    }
}
```

```C
int countOfPairs(int* nums, int numsSize) {
    int n = numsSize, m = 0;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] > m) {
            m = nums[i];
        }
    }
    int mod = 1e9 + 7;
    int **dp = (int **)malloc(n * sizeof(int *));
    for (int i = 0; i < n; i++) {
        dp[i] = (int *)malloc((m + 1) * sizeof(int));
        for (int j = 0; j <= m; j++) {
            dp[i][j] = 0;
        }
    }
    for (int a = 0; a <= nums[0]; a++) {
        dp[0][a] = 1;
    }
    for (int i = 1; i < n; i++) {
        int d = (nums[i] - nums[i - 1]) > 0 ? (nums[i] - nums[i - 1]) : 0;
        for (int j = d; j <= nums[i]; j++) {
            if (j == 0) {
                dp[i][j] = dp[i - 1][j - d];
            } else {
                dp[i][j] = (dp[i][j - 1] + dp[i - 1][j - d]) % mod;
            }
        }
    }
    int res = 0;
    for (int j = 0; j <= m; j++) {
        res = (res + dp[n - 1][j]) % mod;
    }
    for (int i = 0; i < n; i++) {
        free(dp[i]);
    }
    free(dp);
    return res;
}
```

```Rust
impl Solution {
    pub fn count_of_pairs(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let m = *nums.iter().max().unwrap();
        let mod_val = 1000000007;
        let mut dp = vec![vec![0; (m + 1) as usize]; n];
        for a in 0..=nums[0] {
            dp[0][a as usize] = 1;
        }
        for i in 1..n {
            let d = std::cmp::max(0, nums[i] - nums[i - 1]);
            for j in d..=nums[i] {
                if j == 0 {
                    dp[i][j as usize] = dp[i - 1][(j - d) as usize];
                } else {
                    dp[i][j as usize] = (dp[i][(j - 1) as usize] + dp[i - 1][(j - d) as usize]) % mod_val;
                }
            }
        }
        dp[n - 1].iter().fold(0, |acc, &x| (acc + x) % mod_val)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nm)$，其中 $n$ 是数组的长度，$m$ 是数组的最大值。
- 空间复杂度：$O(nm)$，其中 $n$ 是数组的长度，$m$ 是数组的最大值，可以优化到一维空间 $O(m)$。
