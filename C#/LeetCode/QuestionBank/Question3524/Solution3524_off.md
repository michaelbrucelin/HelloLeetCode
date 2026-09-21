### [求出数组的 X 值 I](https://leetcode.cn/problems/find-x-value-of-array-i/solutions/4023773/qiu-chu-shu-zu-de-x-zhi-i-by-leetcode-so-xxir/)

#### 方法一：动态规划

**思路与算法**

在本文中，我们用 $nums[i,j]$ 来表示 $[nums[i],nums[i+1],\dots ,nums[j]]$ 这一段子数组。特别地，当 $i>j$ 时，规定子数组为空。

根据题意，在一次操作中，我们可以移除 $nums$ 任意不重叠的前缀和后缀，使得 $nums$ 仍然非空。

不难发现，经过一次操作后，剩下的将会是 $nums$ 的一个**非空子数组** $nums[i,j]$。

进一步地，不同的子数组 $nums[i,j]$ 与不同的合法操作之间存在着**一一对应**的关系。具体来说，为了得到 $nums[i,j]$，我们只能执行以下操作：

- 移除 $nums$ 的前缀 $nums[0,i-1]$ 以及后缀 $nums[j+1,n-1]$。

因此，题目实际上要求我们统计 $nums$ 中满足子数组元素乘积除以 $k$ 后余数为 $x$ 的子数组个数。

我们可以通过动态规划解决这个问题。

定义 $dp[i][r]$ 表示以 $i$ 为右端点的所有非空子数组中，子数组元素乘积除以 $k$ 后余数为 $r$ 的子数组个数。初始时，所有状态均为 $0$。

考虑下标 $i$ 时，以 $i$ 为右端点的所有非空子数组有两种来源：

- 仅包含元素 $nums[i]$ 的长度为 $1$ 的子数组；
- 在所有以 $i-1$ 为右端点的非空子数组末尾追加元素 $nums[i]$ 得到的新子数组。

对于第一种情况，子数组元素乘积对 $k$ 取模后的结果为

$$r=nums[i]\bmod k,$$

因此有

$$dp[i][r]+=1.$$

对于第二种情况，设某个以 $i-1$ 为右端点的子数组乘积对 $k$ 取模后的结果为 $r$，则追加元素 $nums[i]$ 后，新子数组乘积对 $k$ 取模后的结果变为

$$(r\times nums[i])\bmod k.$$

因此可以得到状态转移方程

$$dp[i][(r\times nums[i])\bmod k]+=dp[i-1][r],0\le r<k.$$

遍历所有下标 $i$，按照上述规则完成状态转移后，再将每个位置的 $dp[i]$ 累加到答案数组中即可，即

$$result[x]=\sum\limits_{i=0}^{n-1}dp[i][x].$$

上述动态规划的空间复杂度为 $O(nk)$，其中 $n$ 是 $nums$ 长度。由于状态转移仅依赖于上一层状态，因此可以采用滚动数组进行空间优化，将空间复杂度进一步降至 $O(k)$，具体见下方的代码实现。

**代码**

```C++
class Solution {
public:
    vector<long long> resultArray(vector<int>& nums, int k) {
        int n = nums.size();
        vector<long long> result(k);
        vector<long long> dp(k);  // 初始状态，表示尚未处理任何元素，因此不存在非空子数组

        for (int i = 0; i < n; i++) {
            vector<long long> ndp(k);  // 当前层状态（滚动数组）

            ndp[nums[i] % k]++;

            for (int r = 0; r < k; r++) {
                ndp[(long long)r * nums[i] % k] += dp[r];
            }

            dp = move(ndp);  // 更新状态

            // 累加答案
            for (int r = 0; r < k; r++) {
                result[r] += dp[r];
            }
        }

        return result;
    }
};
```

```Python
class Solution:
    def resultArray(self, nums: List[int], k: int) -> List[int]:
        n = len(nums)
        result = [0] * k
        dp = [0] *  k # 初始状态，表示尚未处理任何元素，因此不存在非空子数组

        for i in range(n):
            ndp = [0] * k # 当前层状态（滚动数组）

            ndp[nums[i] % k] += 1

            for r in range(k):
                ndp[(r * nums[i]) % k] += dp[r]

            dp = ndp # 更新状态

            # 累加答案
            for r in range(k):
                result[r] += dp[r]
        return result
```

```Java
class Solution {
    public long[] resultArray(int[] nums, int k) {
        int n = nums.length;
        long[] result = new long[k];
        long[] dp = new long[k];  // 初始状态，表示尚未处理任何元素，因此不存在非空子数组

        for (int i = 0; i < n; i++) {
            long[] ndp = new long[k];  // 当前层状态（滚动数组）
            ndp[nums[i] % k]++;
            for (int r = 0; r < k; r++) {
                ndp[(int)(((long)r * nums[i]) % k)] += dp[r];
            }
            dp = ndp;  // 更新状态
            // 累加答案
            for (int r = 0; r < k; r++) {
                result[r] += dp[r];
            }
        }

        return result;
    }
}
```

```CSharp
public class Solution {
    public long[] ResultArray(int[] nums, int k) {
        int n = nums.Length;
        long[] result = new long[k];
        long[] dp = new long[k];  // 初始状态，表示尚未处理任何元素，因此不存在非空子数组

        for (int i = 0; i < n; i++) {
            long[] ndp = new long[k];  // 当前层状态（滚动数组）
            ndp[nums[i] % k]++;

            for (int r = 0; r < k; r++) {
                ndp[(int)(((long)r * nums[i]) % k)] += dp[r];
            }

            dp = ndp;  // 更新状态

            // 累加答案
            for (int r = 0; r < k; r++) {
                result[r] += dp[r];
            }
        }

        return result;
    }
}
```

```Go
func resultArray(nums []int, k int) []int64 {
    n := len(nums)
    result := make([]int64, k)
    dp := make([]int64, k)  // 初始状态，表示尚未处理任何元素，因此不存在非空子数组

    for i := 0; i < n; i++ {
        ndp := make([]int64, k)  // 当前层状态（滚动数组）
        ndp[nums[i] % k]++
        for r := 0; r < k; r++ {
            ndp[(int64(r) * int64(nums[i])) % int64(k)] += dp[r]
        }

        dp = ndp  // 更新状态

        // 累加答案
        for r := 0; r < k; r++ {
            result[r] += dp[r]
        }
    }

    return result
}
```

```C
long long* resultArray(int* nums, int numsSize, int k, int* returnSize) {
    long long* result = (long long*)calloc(k, sizeof(long long));
    long long* dp = (long long*)calloc(k, sizeof(long long));  // 初始状态，表示尚未处理任何元素，因此不存在非空子数组
    long long* ndp = (long long*)malloc(k * sizeof(long long));

    for (int i = 0; i < numsSize; i++) {
        memset(ndp, 0, k * sizeof(long long));  // 当前层状态（滚动数组）
        ndp[nums[i] % k]++;
        for (int r = 0; r < k; r++) {
            ndp[(int)(((long long)r * nums[i]) % k)] += dp[r];
        }
        memcpy(dp, ndp, k * sizeof(long long));  // 更新状态

        // 累加答案
        for (int r = 0; r < k; r++) {
            result[r] += dp[r];
        }
    }

    free(dp);
    free(ndp);
    *returnSize = k;
    return result;
}
```

```JavaScript
var resultArray = function(nums, k) {
    const n = nums.length;
    const result = new Array(k).fill(0);
    let dp = new Array(k).fill(0);  // 初始状态，表示尚未处理任何元素，因此不存在非空子数组

    for (let i = 0; i < n; i++) {
        const ndp = new Array(k).fill(0);  // 当前层状态（滚动数组）

        ndp[nums[i] % k]++;

        for (let r = 0; r < k; r++) {
            ndp[(r * nums[i]) % k] += dp[r];
        }

        dp = ndp;  // 更新状态

        // 累加答案
        for (let r = 0; r < k; r++) {
            result[r] += dp[r];
        }
    }

    return result;
};
```

```TypeScript
function resultArray(nums: number[], k: number): number[] {
    const n: number = nums.length;
    const result: number[] = new Array(k).fill(0);
    let dp: number[] = new Array(k).fill(0);  // 初始状态，表示尚未处理任何元素，因此不存在非空子数组

    for (let i: number = 0; i < n; i++) {
        const ndp: number[] = new Array(k).fill(0);  // 当前层状态（滚动数组）

        ndp[nums[i] % k]++;

        for (let r: number = 0; r < k; r++) {
            ndp[(r * nums[i]) % k] += dp[r];
        }

        dp = ndp;  // 更新状态

        // 累加答案
        for (let r: number = 0; r < k; r++) {
            result[r] += dp[r];
        }
    }

    return result;
}
```

```Rust
impl Solution {
    pub fn result_array(nums: Vec<i32>, k: i32) -> Vec<i64> {
        let n = nums.len();
        let k_usize = k as usize;
        let mut result = vec![0i64; k_usize];
        let mut dp = vec![0i64; k_usize];  // 初始状态，表示尚未处理任何元素，因此不存在非空子数组

        for i in 0..n {
            let mut ndp = vec![0i64; k_usize];  // 当前层状态（滚动数组）
            ndp[(nums[i] as usize) % k_usize] += 1;
            for r in 0..k_usize {
                ndp[((r as i64 * nums[i] as i64) % k as i64) as usize] += dp[r];
            }

            dp = ndp;  // 更新状态
            // 累加答案
            for r in 0..k_usize {
                result[r] += dp[r];
            }
        }

        result
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nk)$，其中 $n$ 是 $nums$ 的长度。对于数组的每一个下标，需要枚举 $k$ 种余数进行状态转移。
- 空间复杂度：$O(k)$。
