### [对数组执行操作使平方和最大](https://leetcode.cn/problems/apply-operations-on-array-to-maximize-sum-of-squares/solutions/4039940/dui-shu-zu-zhi-xing-cao-zuo-shi-ping-fan-tpg2/)

#### 方法一：贪心

**思路与算法**

题目要求从最终数组中选出 $k$ 个元素，使它们的平方和最大，结果对 $10^9+7$ 取模。

关键在于理解「操作」的本质。对任意两个数 $a$ 和 $b$，逐位观察：

| a 的位 | b 的位 | 操作后 a 的位 | 操作后 b 的位 | 该位 1 的总数 |
| -- | -- | -- | -- | -- |
| 0 | 0 | 0 | 0 | 0 $\rightarrow$ 0 |
| 0 | 1 | 0 | 1 | 1 $\rightarrow$ 1 |
| 1 | 0 | 0 | 1 | 1 $\rightarrow$ 1 |
| 1 | 1 | 1 | 1 | 2 $\rightarrow$ 2 |

由此可得：

- 只有当 $a$ 的某位为 1、b 的对应位为 $0$ 时，操作会把该位的 $1$ 从 $a$ 移到 $b$，相当于交换了两者该位的值；
- 每次操作中，$1$ 只会从第一个元素移向第二个元素，因此第一个元素可能变小，第二个元素只会不变或变大；
- 每个二进制位上 $1$ 的总数始终不变，所以所有元素的总和也保持不变。

考虑两个数 $x<y$。若一次操作后 $y$ 增加 $d$，x 减少 $d$，则平方和的变化为：

$(x-d)^2+(y+d)^2-(x^2+y^2)=2d(d+y-x)$

因为 $d>0$ 且 $y>x$，所以平方和一定增大；且 $d$ 越大，增幅越大。因此，最优策略是让大的数尽可能大，小的数尽可能小。

也就是说，我们要通过操作「组装」出尽可能大的数。我们可以选择一种构造最大数的贪心方法是：

- 从高位到低位遍历；
- 若当前位为 $0$，就从其他元素中找一个该位为 $1$ 的元素与当前元素操作，使当前位变成 $1$；
- 由于 $1$ 只能从其他元素移向当前元素，已经处理过的高位不会被破坏。

设 $cnt_i$ 表示第 $i$ 位上 $1$ 的总数。为了选出 $k$ 个元素使平方和最大，就构造 $k$ 个尽量大的数：

1. 遍历所有数，统计每一位上 $1$ 的总数 $cnt_i$；
2. 重复 $k$ 次，每次从高位到低位构造一个数：若 $cnt_j>0$，则当前数第 $j$ 位取 $1$，并令 $cnt_j$ 减 $1$；
3. 将构造出的数的平方累加到答案中；
4. 最终对 $10^9+7$ 取模并返回。

**代码**

```C++
class Solution {
public:
    int maxSum(vector<int>& nums, int k) {
        const int MOD = 1e9 + 7;
        vector<int> cnt(30, 0);

        // 统计每个位上 1 的数量
        for (int num : nums) {
            for (int i = 0; i < 30; i++) {
                if (num & (1 << i)) {
                    cnt[i]++;
                }
            }
        }

        long long res = 0;
        for (int i = 0; i < k; i++) {
            long long cur = 0;
            // 从高位到低位构造当前数字
            for (int j = 29; j >= 0; j--) {
                if (cnt[j] > 0) {
                    cur |= (1LL << j);
                    cnt[j]--;
                }
            }
            res = (res + cur * cur) % MOD;
        }

        return (int)res;
    }
};
```

```Java
class Solution {
    public int maxSum(List<Integer> nums, int k) {
        final int MOD = 1000000007;
        int[] cnt = new int[30];

        // 统计每个位上 1 的数量
        for (int num : nums) {
            for (int i = 0; i < 30; i++) {
                if ((num & (1 << i)) != 0) {
                    cnt[i]++;
                }
            }
        }

        long res = 0;
        for (int i = 0; i < k; i++) {
            long cur = 0;
            // 从高位到低位构造当前数字
            for (int j = 29; j >= 0; j--) {
                if (cnt[j] > 0) {
                    cur |= (1L << j);
                    cnt[j]--;
                }
            }
            res = (res + cur * cur) % MOD;
        }

        return (int)res;
    }
}
```

```CSharp
public class Solution {
    public int MaxSum(IList<int> nums, int k) {
        const int MOD = 1000000007;
        int[] cnt = new int[30];

        // 统计每个位上 1 的数量
        foreach (int num in nums) {
            for (int i = 0; i < 30; i++) {
                if ((num & (1 << i)) != 0) {
                    cnt[i]++;
                }
            }
        }

        long res = 0;
        for (int i = 0; i < k; i++) {
            long cur = 0;
            // 从高位到低位构造当前数字
            for (int j = 29; j >= 0; j--) {
                if (cnt[j] > 0) {
                    cur |= (1L << j);
                    cnt[j]--;
                }
            }
            res = (res + cur * cur) % MOD;
        }

        return (int)res;
    }
}
```

```Go
func maxSum(nums []int, k int) int {
    const MOD = 1000000007
    cnt := make([]int, 30)

    // 统计每个位上 1 的数量
    for _, num := range nums {
        for i := 0; i < 30; i++ {
            if num & (1 << i) != 0 {
                cnt[i]++
            }
        }
    }

    res := int64(0)
    for i := 0; i < k; i++ {
        cur := int64(0)
        // 从高位到低位构造当前数字
        for j := 29; j >= 0; j-- {
            if cnt[j] > 0 {
                cur |= int64(1) << j
                cnt[j]--
            }
        }
        res = (res + cur * cur) % MOD
    }

    return int(res)
}
```

```Python
class Solution:
    def maxSum(self, nums: List[int], k: int) -> int:
        MOD = 10**9 + 7
        cnt = [0] * 30

        # 统计每个位上 1 的数量
        for num in nums:
            for i in range(30):
                if num & (1 << i):
                    cnt[i] += 1

        res = 0
        for _ in range(k):
            cur = 0
            # 从高位到低位构造当前数字
            for j in range(29, -1, -1):
                if cnt[j] > 0:
                    cur |= (1 << j)
                    cnt[j] -= 1
            res = (res + cur * cur) % MOD

        return res
```

```C
int maxSum(int* nums, int numsSize, int k) {
    const long long MOD = 1000000007;
    int cnt[30] = {0};

    // 统计每个位上 1 的数量
    for (int idx = 0; idx < numsSize; idx++) {
        for (int i = 0; i < 30; i++) {
            if (nums[idx] & (1 << i)) {
                cnt[i]++;
            }
        }
    }

    long long res = 0;
    for (int i = 0; i < k; i++) {
        long long cur = 0;
        // 从高位到低位构造当前数字
        for (int j = 29; j >= 0; j--) {
            if (cnt[j] > 0) {
                cur |= (1LL << j);
                cnt[j]--;
            }
        }
        res = (res + cur * cur) % MOD;
    }

    return (int)res;
}
```

```JavaScript
var maxSum = function(nums, k) {
    const MOD = 1000000007;
    const cnt = new Array(30).fill(0);

    // 统计每个位上 1 的数量
    for (const num of nums) {
        for (let i = 0; i < 30; i++) {
            if (num & (1 << i)) {
                cnt[i]++;
            }
        }
    }

    let res = 0;
    for (let i = 0; i < k; i++) {
        let cur = 0;
        // 从高位到低位构造当前数字
        for (let j = 29; j >= 0; j--) {
            if (cnt[j] > 0) {
                cur += Math.pow(2, j);
                cnt[j]--;
            }
        }

        const curBigInt = BigInt(cur);
        res = Number((BigInt(res) + curBigInt * curBigInt) % BigInt(MOD));
    }

    return res;
};
```

```TypeScript
function maxSum(nums: number[], k: number): number {
    const MOD = 1000000007;
    const cnt: number[] = new Array(30).fill(0);

    // 统计每个位上 1 的数量
    for (const num of nums) {
        for (let i = 0; i < 30; i++) {
            if (num & (1 << i)) {
                cnt[i]++;
            }
        }
    }

    let res = 0;
    for (let i = 0; i < k; i++) {
        let cur = 0;
        // 从高位到低位构造当前数字
        for (let j = 29; j >= 0; j--) {
            if (cnt[j] > 0) {
                cur += Math.pow(2, j);
                cnt[j]--;
            }
        }

        const curBigInt = BigInt(cur);
        res = Number((BigInt(res) + curBigInt * curBigInt) % BigInt(MOD));
    }

    return res;
}
```

```Rust
impl Solution {
    pub fn max_sum(nums: Vec<i32>, k: i32) -> i32 {
        const MOD: i64 = 1_000_000_007;
        let mut cnt = vec![0i32; 30];

        // 统计每个位上 1 的数量
        for &num in nums.iter() {
            for i in 0..30 {
                if num & (1 << i) != 0 {
                    cnt[i] += 1;
                }
            }
        }

        let mut res: i64 = 0;
        for _ in 0..k {
            let mut cur: i64 = 0;
            // 从高位到低位构造当前数字
            for j in (0..30).rev() {
                if cnt[j] > 0 {
                    cur |= 1i64 << j;
                    cnt[j] -= 1;
                }
            }
            res = (res + cur * cur) % MOD;
        }

        res as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log M)$，其中 $n$ 是数组 $nums$ 的长度，$M$ 表示数组 $nums$ 中元素的最大值。遍历数组 $nums$ 计算二进制表示的每一位的 $1$ 的个数的时间是 $O(n\log M)$，构造 $k$ 个元素计算最大平方和的时间是 $O(k\log M)$，由于本题中 $k<n$，因此总的时间复杂度是 $O(n\log M)$。
- 空间复杂度：$O(\log M)$，M 表示数组 $nums$ 中元素的最大值。记录二进制表示的每一位的 $1$ 的个数的空间是 $O(\log M)$。
