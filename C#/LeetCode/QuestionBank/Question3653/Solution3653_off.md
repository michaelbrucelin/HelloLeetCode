### [区间乘法查询后的异或 I](https://leetcode.cn/problems/xor-after-range-multiplication-queries-i/solutions/3941259/qu-jian-cheng-fa-cha-xun-hou-de-yi-huo-i-o60f/)

#### 方法一：模拟

**思路与算法**

由于本题的数据规模较小，我们直接模拟每个查询的操作。基本流程是：

1. 逐个处理查询，按题意模拟跳跃式乘法更新。
2. 所有查询处理完毕后，遍历数据求所有元素的异或值。

注意乘法过程中要对 $10^9+7$ 取模，防止溢出需要使用长整型。

**代码**

```C++
class Solution {
    static const int mod = 1e9 + 7;
public:
    int xorAfterQueries(vector<int>& nums, vector<vector<int>>& queries) {
        int n = nums.size();
        for (auto q : queries) {
            int l = q[0], r = q[1], k = q[2], v = q[3];
            for (int i = l; i <= r; i += k) {
                nums[i] = 1ll * nums[i] * v % mod;
            }
        }
        int res = 0;
        for (auto x : nums) {
            res ^= x;
        }
        return res;
    }
};
```

```Python
class Solution:
    MOD = 10**9 + 7

    def xorAfterQueries(self, nums: List[int], queries: List[List[int]]) -> int:
        for l, r, k, v in queries:
            for i in range(l, r + 1, k):
                nums[i] = (nums[i] * v) % self.MOD

        res = 0
        for x in nums:
            res ^= x

        return res
```

```Rust
impl Solution {
    const MOD: i64 = 1_000_000_007;

    pub fn xor_after_queries(nums: Vec<i32>, queries: Vec<Vec<i32>>) -> i32 {
        let mut nums = nums.iter().map(|&x| x as i64).collect::<Vec<_>>();

        for q in queries {
            let l = q[0] as usize;
            let r = q[1] as usize;
            let k = q[2] as usize;
            let v = q[3] as i64;

            let mut i = l;
            while i <= r {
                nums[i] = (nums[i] * v) % Self::MOD;
                i += k;
            }
        }

        let mut res = 0;
        for x in nums {
            res ^= x;
        }
        res as i32
    }
}
```

```Java
class Solution {
    private static final int MOD = 1_000_000_007;

    public int xorAfterQueries(int[] nums, int[][] queries) {
        int n = nums.length;
        for (int[] q : queries) {
            int l = q[0], r = q[1], k = q[2], v = q[3];
            for (int i = l; i <= r; i += k) {
                nums[i] = (int)((long)nums[i] * v % MOD);
            }
        }
        int res = 0;
        for (int x : nums) {
            res ^= x;
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    private const int MOD = 1_000_000_007;

    public int XorAfterQueries(int[] nums, int[][] queries) {
        int n = nums.Length;
        foreach (var q in queries) {
            int l = q[0], r = q[1], k = q[2], v = q[3];
            for (int i = l; i <= r; i += k) {
                nums[i] = (int)((long)nums[i] * v % MOD);
            }
        }
        int res = 0;
        foreach (int x in nums) {
            res ^= x;
        }
        return res;
    }
}
```

```Go
func xorAfterQueries(nums []int, queries [][]int) int {
    const mod = 1_000_000_007

    for _, q := range queries {
        l, r, k, v := q[0], q[1], q[2], q[3]
        for i := l; i <= r; i += k {
            nums[i] = int((int64(nums[i]) * int64(v)) % mod)
        }
    }

    res := 0
    for _, x := range nums {
        res ^= x
    }
    return res
}
```

```C
#define MOD 1000000007

int xorAfterQueries(int* nums, int numsSize, int** queries, int queriesSize, int* queriesColSize) {
    for (int idx = 0; idx < queriesSize; idx++) {
        int l = queries[idx][0];
        int r = queries[idx][1];
        int k = queries[idx][2];
        int v = queries[idx][3];

        for (int i = l; i <= r; i += k) {
            nums[i] = (int)((int64_t)nums[i] * v % MOD);
        }
    }

    int res = 0;
    for (int i = 0; i < numsSize; i++) {
        res ^= nums[i];
    }
    return res;
}
```

```JavaScript
var xorAfterQueries = function(nums, queries) {
    const MOD = 1e9 + 7;

    for (const q of queries) {
        const [l, r, k, v] = q;
        for (let i = l; i <= r; i += k) {
            nums[i] = Number((BigInt(nums[i]) * BigInt(v)) % BigInt(MOD));
        }
    }

    let res = 0;
    for (const x of nums) {
        res ^= x;
    }
    return res;
};
```

```TypeScript
function xorAfterQueries(nums: number[], queries: number[][]): number {
    const MOD = 1e9 + 7;
    for (const q of queries) {
        const [l, r, k, v] = q;
        for (let i = l; i <= r; i += k) {
            nums[i] = Number((BigInt(nums[i]) * BigInt(v)) % BigInt(MOD));
        }
    }

    let res = 0;
    for (const x of nums) {
        res ^= x;
    }
    return res;
};
```

**复杂度分析**

- 时间复杂度：$O(nq)$，其中 $n$ 是 $nums$ 的长度，$q$ 是 $queries$ 的个数。
- 空间复杂度：$O(1)$。只使用了常数个额外空间。
