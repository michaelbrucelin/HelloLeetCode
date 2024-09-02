### [所有数对中数位不同之和](https://leetcode.cn/problems/sum-of-digit-differences-of-all-pairs/solutions/2895363/suo-you-shu-dui-zhong-shu-wei-bu-tong-zh-qde1/)

#### 方法一：依次计算每一数位上数位不同的次数

**思路**

依次计算每一位数位上，所有整数对中，数位不同的次数。然后对所有数位的次数求和。我们从最低位开始，最低位的数字是 $num[i]\%10$。用一个长度为 $10$ 的数组 $cnt$ 统计每个数字出现的次数。那么，这一位上数位不同的次数即为 $(\sum_{i=0}^9(n-cnt[i]) \times cnt[i])/2$，其中 $n$ 是数组 $num$ 的长度。举例说明，该数位上，$0$ 出现了 $cnt[0]$ 次，那么其他数字就会出现 $n-cnt[0]$ 次，那么数位不同的次数中，包含 $0$ 的情况就有 $cnt[0] \times (n-cnt[0])$ 次。但是这个次数，会在计算其他数字时也被计算一次，所以最后结果要除以 $2$。

同时我们将 $num[i]$ 更新为 $num[i]/10$，方便计算下一数位，直到所有 $num[i] 变为 0$。

**代码**

```Python
class Solution:
    def sumDigitDifferences(self, nums: List[int]) -> int:
        res = 0
        n = len(nums)
        while nums[0] > 0:
            cnt = [0] * 10
            for i in range(n):
                cnt[nums[i] % 10] += 1
                nums[i] = nums[i] // 10
            for i in range(10):
                res += (n - cnt[i]) * cnt[i]
        return res // 2
```

```Java
class Solution {
    public long sumDigitDifferences(int[] nums) {
        long res = 0;
        int n = nums.length;
        while (nums[0] > 0) {
            int[] cnt = new int[10];
            for (int i = 0; i < n; i++) {
                cnt[nums[i] % 10]++;
                nums[i] /= 10;
            }
            for (int i = 0; i < 10; i++) {
                res += (long) (n - cnt[i]) * cnt[i];
            }
        }
        return res / 2;
    }
}
```

```CSharp
public class Solution {
    public long SumDigitDifferences(int[] nums) {
        long res = 0;
        int n = nums.Length;
        while (nums[0] > 0) {
            int[] cnt = new int[10];
            for (int i = 0; i < n; i++) {
                cnt[nums[i] % 10]++;
                nums[i] /= 10;
            }
            for (int i = 0; i < 10; i++) {
                res += (long) (n - cnt[i]) * cnt[i];
            }
        }
        return res / 2;
    }
}
```

```C++
class Solution {
public:
    long long sumDigitDifferences(vector<int>& nums) {
        long long res = 0;
        int n = nums.size();
        while (nums[0] > 0) {
            vector<int> cnt(10);
            for (int i = 0; i < n; i++) {
                cnt[nums[i] % 10]++;
                nums[i] /= 10;
            }
            for (int i = 0; i < 10; i++) {
                res += (long long) (n - cnt[i]) * cnt[i];
            }
        }
        return res / 2;
    }
};
```

```C
long long sumDigitDifferences(int* nums, int numsSize) {
    long long res = 0;
    while (nums[0] > 0) {
        int cnt[10] = {0};
        for (int i = 0; i < numsSize; i++) {
            cnt[nums[i] % 10]++;
            nums[i] /= 10;
        }
        for (int i = 0; i < 10; i++) {
            res += (long long) (numsSize - cnt[i]) * cnt[i];
        }
    }
    return res / 2;
}
```

```Go
func sumDigitDifferences(nums []int) int64 {
    res := int64(0)
    for nums[0] > 0 {
        cnt := make([]int, 10)
        for i := 0; i < len(nums); i++ {
            cnt[nums[i] % 10]++
            nums[i] /= 10
        }
        for i := 0; i < 10; i++ {
            res += int64(len(nums) - cnt[i]) * int64(cnt[i]);
        }
    }
    return res / 2;
}
```

```JavaScript
var sumDigitDifferences = function(nums) {
    let res = 0n;
    let n = nums.length;
    while (nums[0] > 0) {
        const cnt = new Array(10).fill(0);
        for (let i = 0; i < n; i++) {
            cnt[nums[i] % 10]++;
            nums[i] = Math.floor(nums[i] / 10);
        }
        for (let i = 0; i < 10; i++) {
            res += BigInt(n - cnt[i]) * BigInt(cnt[i]);
        }
    }
    return Number(res >> 1n);
};
```

```TypeScript
function sumDigitDifferences(nums: number[]): number {
    let res = 0n;
    let n = nums.length;
    while (nums[0] > 0) {
        const cnt = new Array(10).fill(0);
        for (let i = 0; i < n; i++) {
            cnt[nums[i] % 10]++;
            nums[i] = Math.floor(nums[i] / 10);
        }
        for (let i = 0; i < 10; i++) {
            res += BigInt(n - cnt[i]) * BigInt(cnt[i]);
        }
    }
    return Number(res >> 1n);
};
```

```Rust
impl Solution {
    pub fn sum_digit_differences(nums: Vec<i32>) -> i64 {
        let mut nums = nums.clone();
        let mut res: i64 = 0;
        let n = nums.len();
        while (nums[0] > 0) {
            let mut cnt = vec![0; 10];
            for i in 0..n {
                cnt[nums[i] as usize % 10] += 1;
                nums[i] /= 10;
            }
            for i in 0..10 {
                res += (n - cnt[i]) as i64 * (cnt[i]) as i64;
            }
        }
        return res / 2;
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m \times (n+C))$。$m$ 为 $nums$ 元素的数位长度，最多为 $5$，$n$ 是 $nums$ 的长度，$C$ 为 $10$。
- 空间复杂度：$O(C)$。
