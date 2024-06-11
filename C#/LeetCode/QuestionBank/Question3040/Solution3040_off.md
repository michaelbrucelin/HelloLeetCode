### [相同分数的最大操作数目 II](https://leetcode.cn/problems/maximum-number-of-operations-with-the-same-score-ii/solutions/2800309/xiang-tong-fen-shu-de-zui-da-cao-zuo-shu-28c1/)

#### 方法一：记忆化搜索

**思路与算法**

由于题目要求**所有操作分数相同**，我们可以观察到如果第一删除操作时确定了删除的分数，那么后续每次删除的分数都保持不变，因此操作的得分最多只有三种情形，设数组 $\textit{target}$ 的长度为 $n$，则操作分数 nums\textit{nums}nums 只能为以下之一：

- $\textit{nums}[0] + \textit{nums[1]}$；
- $\textit{nums}[0] + \textit{nums[n-1]}$；
- $\textit{nums}[n-2] + \textit{nums[n-1]}$。

假设给定了删除的分数 $\textit{target}$，由于每次只能从两端删除，每次删除区间的长度减 $2$，此时可以利用「[区间动态规划](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fdp%2Finterval%2F)」来解决该问题。每次删除时从两端删除，如果要找到区间 $[i,j]$ 的最优状态，此时只需要找到三个区间 $[i+1,j],[i,j-2],[i+1,j-1]$ 的最优状态即可。

在给定删除分数 $\textit{target}$ 的前提下，定义 $\textit{dfs}(i,j)$ 表示当前剩余元素为 $\textit{nums}[i],\textit{nums}[i+1], \cdots, \textit{nums}[j]$ 时最多可以进行的**删除操作**次数。根据上述分析，接下来有以下情况：

- 如果满足 $\textit{nums}[i] + \textit{nums}[i + 1] = \textit{target}$，此时可以进行 $1$ 次操作，剩余的元素为 $\textit{nums}[i+2],\textit{nums}[i+3], \cdots, \textit{nums}[j]$，此时状态转移为：$\textit{dfs}(i,j) = \max(\textit{dfs}(i,j), 1 + \textit{dfs}(i+2,j))$；
- 如果满足 $\textit{nums}[j-1] + \textit{nums}[j] = \textit{target}$，此时可以进行 $1$ 次操作，剩余的元素为 $\textit{nums}[i],\textit{nums}[i+1], \cdots, \textit{nums}[j-2]$，此时状态转移为：$\textit{dfs}(i,j) = \max(\textit{dfs}(i,j), 1 + \textit{dfs}(i,j-2))$；
- 如果满足 $\textit{nums}[i] + \textit{nums}[j] = \textit{target}$，此时可以进行 $1$ 次操作，剩余的元素为 $\textit{nums}[i + 1],\textit{nums}[i+2], \cdots, \textit{nums}[j-1]$，此时状态转移为：$\textit{dfs}(i,j) = \max(\textit{dfs}(i,j), \textit{dfs}(i+1,j-1))$；
- 如果上述三种方式都不满足，则此时 $\textit{dfs}(i,j) = 0$。

递归开始时，分别枚举三种不同的分数 $\textit{target}$，当 $i \ge j$ 时，此时无法再进行删除操作，递归终止。

**代码**

```C++
class Solution {
public:
    int maxOperations(vector<int>& nums) {
        int n = nums.size();
        int memo[n][n];

        auto helper = [&](int i, int j, int target) -> int {
            memset(memo, -1, sizeof(memo));
            function<int(int, int)> dfs = [&](int i, int j) -> int {
                if (i >= j) {
                    return 0;
                }
                if (memo[i][j] != -1) {
                    return memo[i][j];
                }
                int ans = 0;
                if (nums[i] + nums[i + 1] == target) {
                    ans = max(ans, 1 + dfs(i + 2, j));
                }
                if (nums[j - 1] + nums[j] == target) {
                    ans = max(ans, 1 + dfs(i, j - 2));
                }
                if (nums[i] + nums[j] == target) {
                    ans = max(ans, 1 + dfs(i + 1, j - 1));
                }
                memo[i][j] = ans;
                return ans;
            };
            return dfs(i, j);
        };

        int res = 0;
        res = max(res, helper(0, n - 1, nums[0] + nums[n - 1]));
        res = max(res, helper(0, n - 1, nums[0] + nums[1]));
        res = max(res, helper(0, n - 1, nums[n - 2] + nums[n - 1]));
        return res;
    }
};
```

```Java
class Solution {
    int[] nums;
    int[][] memo;

    public int maxOperations(int[] nums) {
        int n = nums.length;
        this.nums = nums;
        this.memo = new int[n][n];
        int res = 0;
        res = Math.max(res, helper(0, n - 1, nums[0] + nums[n - 1]));
        res = Math.max(res, helper(0, n - 1, nums[0] + nums[1]));
        res = Math.max(res, helper(0, n - 1, nums[n - 2] + nums[n - 1]));
        return res;
    }

    public int helper(int i, int j, int target) {
        for (int k = 0; k < nums.length; k++) {
            Arrays.fill(memo[k], -1);
        }
        return dfs(i, j, target);
    }

    public int dfs(int i, int j, int target) {
        if (i >= j) {
            return 0;
        }
        if (memo[i][j] != -1) {
            return memo[i][j];
        }
        int ans = 0;
        if (nums[i] + nums[i + 1] == target) {
            ans = Math.max(ans, dfs(i + 2, j, target) + 1);
        }
        if (nums[j - 1] + nums[j] == target) {
            ans = Math.max(ans, dfs(i, j - 2, target) + 1);
        }
        if (nums[i] + nums[j] == target) {
            ans = Math.max(ans, dfs(i + 1, j - 1, target) + 1);
        }
        memo[i][j] = ans;
        return ans;
    }
}
```

```CSharp
public class Solution {
    int[] nums;
    int[][] memo;

    public int MaxOperations(int[] nums) {
        int n = nums.Length;
        this.nums = nums;
        this.memo = new int[n][];
        for (int i = 0; i < n; i++) {
            memo[i] = new int[n];
        }
        int res = 0;
        res = Math.Max(res, Helper(0, n - 1, nums[0] + nums[n - 1]));
        res = Math.Max(res, Helper(0, n - 1, nums[0] + nums[1]));
        res = Math.Max(res, Helper(0, n - 1, nums[n - 2] + nums[n - 1]));
        return res;
    }

    public int Helper(int i, int j, int target) {
        for (int k = 0; k < nums.Length; k++) {
            Array.Fill(memo[k], -1);
        }
        return DFS(i, j, target);
    }

    public int DFS(int i, int j, int target) {
        if (i >= j) {
            return 0;
        }
        if (memo[i][j] != -1) {
            return memo[i][j];
        }
        int ans = 0;
        if (nums[i] + nums[i + 1] == target) {
            ans = Math.Max(ans, DFS(i + 2, j, target) + 1);
        }
        if (nums[j - 1] + nums[j] == target) {
            ans = Math.Max(ans, DFS(i, j - 2, target) + 1);
        }
        if (nums[i] + nums[j] == target) {
            ans = Math.Max(ans, DFS(i + 1, j - 1, target) + 1);
        }
        memo[i][j] = ans;
        return ans;
    }
}
```

```Go
func maxOperations(nums []int) int {
    n := len(nums)
    memo := make([][]int, n)

    helper := func(i, j, target int) int {
        for i := range memo {
            memo[i] = make([]int, n)
            for j := range memo[i] {
                memo[i][j] = -1
            }
        }

        var dfs func(int, int) int
        dfs = func(i, j int) int {
            if i >= j {
                return 0
            }
            if memo[i][j] != -1 {
                return memo[i][j]
            }

            ans := 0
            if nums[i] + nums[i + 1] == target {
                ans = max(ans, 1 + dfs(i + 2, j))
            }
            if nums[j - 1] + nums[j] == target {
                ans = max(ans, 1 + dfs(i, j - 2))
            }
            if nums[i] + nums[j] == target {
                ans = max(ans, 1 + dfs(i + 1, j - 1))
            }
            memo[i][j] = ans
            return ans
        }
        return dfs(i, j)
    }

    res := 0
    res = max(res, helper(0, n - 1, nums[0] + nums[n - 1]))
    res = max(res, helper(0, n - 1, nums[0] + nums[1]))
    res = max(res, helper(0, n - 1, nums[n - 2] + nums[n - 1]))
    return res
}
```

```Python
class Solution:
    def maxOperations(self, nums: List[int]) -> int:
        n = len(nums)

        @cache
        def dfs(i, j, target):
            if i >= j:
                return 0
            ans = 0
            if nums[i] + nums[i + 1] == target:
                ans = max(ans, 1 + dfs(i + 2, j, target))
            if nums[i] + nums[j] == target:
                ans = max(ans, 1 + dfs(i + 1, j - 1, target))
            if nums[j - 1] + nums[j] == target:
                ans = max(ans, 1 + dfs(i , j - 2, target))
            return ans

        res = 0
        res = max(res, dfs(0, n - 1, nums[0] + nums[1]))
        res = max(res, dfs(0, n - 1, nums[0] + nums[n - 1]))
        res = max(res, dfs(0, n - 1, nums[n - 2] + nums[n - 1]))
        return res
```

```C
int dfs(int i, int j, int target, int **memo, int *nums) {
    if (i >= j) {
        return 0;
    }
    if (memo[i][j] != -1) {
        return memo[i][j];
    }
    int ans = 0;
    if (nums[i] + nums[i + 1] == target) {
        ans = fmax(ans, 1 + dfs(i + 2, j, target, memo, nums));
    }
    if (nums[j - 1] + nums[j] == target) {
        ans = fmax(ans, 1 + dfs(i, j - 2, target, memo, nums));
    }
    if (nums[i] + nums[j] == target) {
        ans = fmax(ans, 1 + dfs(i + 1, j - 1, target, memo, nums));
    }
    memo[i][j] = ans;
    return ans;
}

int helper(int i, int j, int target, int **memo, int *nums, int numsSize) {
    for (int k = 0; k < numsSize; k++) {
        memset(memo[k], -1, sizeof(int) * numsSize);
    }
    return dfs(i, j, target, memo, nums);
}

int maxOperations(int* nums, int numsSize) {
    int *memo[numsSize];
    for (int i = 0; i < numsSize; i++) {
        memo[i] = (int *)malloc(sizeof(int) * numsSize);
    }
    int res = 0;
    res = fmax(res, helper(0, numsSize - 1, nums[0] + nums[numsSize - 1], memo, nums, numsSize));
    res = fmax(res, helper(0, numsSize - 1, nums[0] + nums[1], memo, nums, numsSize));
    res = fmax(res, helper(0, numsSize - 1, nums[numsSize - 2] + nums[numsSize - 1], memo, nums, numsSize));
    for (int i = 0; i < numsSize; i++) {
        free(memo[i]);
    }
    return res;
}
```

```JavaScript
var maxOperations = function(nums) {
    const n = nums.length;
    const helper = (i, j, target) => {
        const memo = Array.from({ length: n }, () => Array(n).fill(-1));
        const dfs = (i, j) => {
            if (i >= j) {
                return 0;
            }
            if (memo[i][j] != -1) {
                return memo[i][j];
            }
            let ans = 0;
            if (nums[i] + nums[i + 1] == target) {
                ans = Math.max(ans, 1 + dfs(i + 2, j));
            }
            if (nums[j - 1] + nums[j] == target) {
                ans = Math.max(ans, 1 + dfs(i, j - 2));
            }
            if (nums[i] + nums[j] == target) {
                ans = Math.max(ans, 1 + dfs(i + 1, j - 1));
            }
            memo[i][j] = ans;
            return ans;
        }
        return dfs(i, j);
    }

    let res = 0;
    res = Math.max(res, helper(0, n - 1, nums[0] + nums[n - 1]));
    res = Math.max(res, helper(0, n - 1, nums[0] + nums[1]));
    res = Math.max(res, helper(0, n - 1, nums[n - 2] + nums[n - 1]));
    return res;
};
```

```TypeScript
function maxOperations(nums: number[]): number {
    const n = nums.length;

    const helper = (i: number, j: number, target: number): number => {
        const memo: number[][] = Array.from({ length: n }, () => Array(n).fill(-1));
        const dfs = (i: number, j: number): number => {
            if (i >= j) {
                return 0;
            }
            if (memo[i][j] !== -1) {
                return memo[i][j];
            }
            let ans = 0;
            if (nums[i] + nums[i + 1] === target) {
                ans = Math.max(ans, 1 + dfs(i + 2, j));
            }
            if (nums[j - 1] + nums[j] === target) {
                ans = Math.max(ans, 1 + dfs(i, j - 2));
            }
            if (nums[i] + nums[j] === target) {
                ans = Math.max(ans, 1 + dfs(i + 1, j - 1));
            }
            memo[i][j] = ans;
            return ans;
        };
        return dfs(i, j);
    };

    let res = 0;
    res = Math.max(res, helper(0, n - 1, nums[0] + nums[n - 1]));
    res = Math.max(res, helper(0, n - 1, nums[0] + nums[1]));
    res = Math.max(res, helper(0, n - 1, nums[n - 2] + nums[n - 1]));
    return res;
};
```

```Rust
impl Solution {
    pub fn max_operations(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let helper = |i: usize, j: usize, target: i32| -> i32 {
            let mut memo = vec![vec![-1; n]; n];
            fn dfs(i: i32, j: i32, nums: &Vec<i32>, memo: &mut Vec<Vec<i32>>, target: i32) -> i32 {
                if i >= j {
                    return 0;
                }
                if memo[i as usize][j as usize] != -1 {
                    return memo[i as usize][j as usize];
                }
                let mut ans = 0;
                if nums[i as usize] + nums[(i + 1) as usize] == target {
                    ans = ans.max(1 + dfs(i + 2, j, nums, memo, target));
                }
                if nums[(j - 1) as usize] + nums[j as usize] == target {
                    ans = ans.max(1 + dfs(i, j - 2, nums, memo, target));
                }
                if nums[i as usize] + nums[j as usize] == target {
                    ans = ans.max(1 + dfs(i + 1, j - 1, nums, memo, target));
                }
                memo[i as usize][j as usize] = ans;
                ans
            }

            dfs(i as i32, j as i32, &nums, &mut memo, target)
        };

        let mut res = 0;
        res = res.max(helper(0, n - 1, nums[0] + nums[n - 1]));
        res = res.max(helper(0, n - 1, nums[0] + nums[1]));
        res = res.max(helper(0, n - 1, nums[n - 2] + nums[n - 1]));
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 表示给定的数组的长度。由于操作的分数最多只有 $3$ 种，在给定每次操作分数的情形下，记忆化搜索最多有 $n^2$ 种子状态，因此所需要的时间为 $O(n^2)$。
- 空间复杂度：$O(n^2)$，其中 $n$ 表示给定的数组的长度。每次尝试最多有 $n^2$ 种子状态，需要存储这些子状态的最优解，需要的空间为 $O(n^2)$。
