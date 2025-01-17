### [或值至少为 K 的最短子数组 II](https://leetcode.cn/problems/shortest-subarray-with-or-at-least-k-ii/solutions/3040101/huo-zhi-zhi-shao-wei-k-de-zui-duan-zi-sh-rzf8/)

#### 方法一：滑动窗口

**思路与算法**

根据**或**运算的性质可以知道，给定的元素 $A$ 与任意元素 $B$ 进行**或**运算的结果一定满足 $A \vert B \ge A$，由此可以知道对于任意子数组的长度增加元素后按位**或**运算的结果一定大于等于增加前的结果，满足单调性。由此可知当每次固定数组的右端点时，我们可以使用**二分查找**或者**滑动窗口**来找到**最短**特别子数组的长度。

我们每次用 $[left,right]$ 表示滑动窗口，每次固定右端点 $right$，如果当前窗口内子数组按位**或**的结果大于等于 $k$，此时向右移动左端点 $left$ 直到窗口内子数组的值按位**或**的结果刚好满足小于 $k$ 为止，此时以 $right$ 为右端点的**最短**特别子数组长度即为 $right-left+1$。

为了实时计算当前窗口中子数组**或**运算的结果，我们需要维护二进制位每一位中 $1$ 出现的次数，如果当前位中 $1$ 的出现的次数为 $0$，则按位**或**运算后该位为 $0$，否则该位则为 $1$。由于给定数组 $nums$ 中的元素大小不超过 $10^9$，因此最多需要考虑二进制表示的前 $30$ 位。我们需要维护一个长度为 $30$ 的数组 $bits$，其中 $bits[i]$ 表示滑动窗口中满足二进制表示的从低到高第 $i$ 位的值为 $1$ 的元素个数。

具体计算过程如下：

- 初始时 $left=right=0$。每次将滑动窗口的右端点 $right$ 向右移动一位，并更新 $bits$ 数组，通过计算 $bits$ 数组，如果当前窗口内子数组按位**或**的结果大于等于 $k$ 时，窗口内的子数组一定为**特别**子数组，则尝试应向右移动左端点 $right$，并更新 $bits$ 数组。
- 向右移动左端点直到当窗口内子数组按位**或**的结果小于 $k$ 或者 $left > right$ 时，此时不再移动左端点 $left$。在移动窗口的过程中，我们同时更新**最短**特别子数组长度的长度。
- 由于可能存在整个数组中所有元素按位**或**的结果小于 $k$，此时不存在**特别**子数组，此时应返回 $-1$。

**代码**

```C++
class Solution {
public:
    int minimumSubarrayLength(vector<int>& nums, int k) {
        int n = nums.size();
        vector<int> bits(30);
        auto calc = [](vector<int> &bits) -> int {
            int ans = 0;
            for (int i = 0; i < bits.size(); i++) {
                if (bits[i] > 0) {
                    ans |= 1 << i;
                }
            }
            return ans;
        };

        int res = INT_MAX;
        for (int left = 0, right = 0; right < n; right++) {
            for (int i = 0; i < 30; i++) {
                bits[i] += (nums[right] >> i) & 1;
            }
            while (left <= right && calc(bits) >= k) {
                res = min(res, right - left + 1);
                for (int i = 0; i < 30; i++) {
                    bits[i] -= (nums[left] >> i) & 1;
                }
                left++;
            }
        }
        
        return res == INT_MAX ? -1: res;
    }
};
```

```Java
class Solution {
    public int minimumSubarrayLength(int[] nums, int k) {
        int n = nums.length;
        int[] bits = new int[30];
        int res = Integer.MAX_VALUE;
        for (int left = 0, right = 0; right < n; right++) {
            for (int i = 0; i < 30; i++) {
                bits[i] += (nums[right] >> i) & 1;
            }
            while (left <= right && calc(bits) >= k) {
                res = Math.min(res, right - left + 1);
                for (int i = 0; i < 30; i++) {
                    bits[i] -= (nums[left] >> i) & 1;
                }
                left++;
            }
        }

        return res == Integer.MAX_VALUE ? -1 : res;
    }

    private int calc(int[] bits) {
        int ans = 0;
        for (int i = 0; i < bits.length; i++) {
            if (bits[i] > 0) {
                ans |= 1 << i;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MinimumSubarrayLength(int[] nums, int k) {
        int n = nums.Length;
        int[] bits = new int[30];
        int res = int.MaxValue;

        for (int left = 0, right = 0; right < n; right++) {
            for (int i = 0; i < 30; i++) {
                bits[i] += (nums[right] >> i) & 1;
            }
            while (left <= right && Calc(bits) >= k) {
                res = Math.Min(res, right - left + 1);
                for (int i = 0; i < 30; i++) {
                    bits[i] -= (nums[left] >> i) & 1;
                }
                left++;
            }
        }

        return res == int.MaxValue ? -1 : res;
    }

    private int Calc(int[] bits) {
        int ans = 0;
        for (int i = 0; i < bits.Length; i++) {
            if (bits[i] > 0) {
                ans |= 1 << i;
            }
        }
        return ans;
    }
}
```

```Go
func minimumSubarrayLength(nums []int, k int) int {
    n := len(nums)
    bits := make([]int, 30)
    res := math.MaxInt32

    for left, right := 0, 0; right < n; right++ {
        for i := 0; i < 30; i++ {
            bits[i] += (nums[right] >> i) & 1
        }
        for left <= right && calc(bits) >= k {
            res = min(res, right - left + 1)
            for i := 0; i < 30; i++ {
                bits[i] -= (nums[left] >> i) & 1
            }
            left++
        }
    }

    if res == math.MaxInt32 {
        return -1
    }
    return res
}

func calc(bits []int) int {
    ans := 0
    for i := 0; i < len(bits); i++ {
        if bits[i] > 0 {
            ans |= 1 << i
        }
    }
    return ans
}
```

```Python
class Solution:
    def minimumSubarrayLength(self, nums: List[int], k: int) -> int:
        n = len(nums)
        bits = [0] * 30
        res = inf
        def calc(bits):
            return sum(1 << i for i in range(30) if bits[i] > 0)

        left = 0
        for right in range(n):
            for i in range(30):
                bits[i] += (nums[right] >> i) & 1
            while left <= right and calc(bits) >= k:
                res = min(res, right - left + 1)
                for i in range(30):
                    bits[i] -= (nums[left] >> i) & 1
                left += 1

        return -1 if res == inf else res
```

```C
int calc(int* bits) {
    int ans = 0;
    for (int i = 0; i < 30; i++) {
        if (bits[i] > 0) {
            ans |= 1 << i;
        }
    }
    return ans;
}

int minimumSubarrayLength(int* nums, int numsSize, int k) {
    int bits[30] = {0};
    int res = INT_MAX;

    for (int left = 0, right = 0; right < numsSize; right++) {
        for (int i = 0; i < 30; i++) {
            bits[i] += (nums[right] >> i) & 1;
        }
        while (left <= right && calc(bits) >= k) {
            res = fmin(res, right - left + 1);
            for (int i = 0; i < 30; i++) {
                bits[i] -= (nums[left] >> i) & 1;
            }
            left++;
        }
    }

    return res == INT_MAX ? -1 : res;
}
```

```JavaScript
var minimumSubarrayLength = function(nums, k) {
    const n = nums.length;
    const bits = new Array(30).fill(0);
    let res = Number.MAX_SAFE_INTEGER;;

    const calc = (bits) => {
        let ans = 0;
        for (let i = 0; i < bits.length; i++) {
            if (bits[i] > 0) {
                ans |= 1 << i;
            }
        }
        return ans;
    };

    let left = 0;
    for (let right = 0; right < n; right++) {
        for (let i = 0; i < 30; i++) {
            bits[i] += (nums[right] >> i) & 1;
        }
        while (left <= right && calc(bits) >= k) {
            res = Math.min(res, right - left + 1);
            for (let i = 0; i < 30; i++) {
                bits[i] -= (nums[left] >> i) & 1;
            }
            left++;
        }
    }

    return res === Number.MAX_SAFE_INTEGER ? -1 : res;
};
```

```TypeScript
function minimumSubarrayLength(nums: number[], k: number): number {
    const n = nums.length;
    const bits = new Array(30).fill(0);
    let res = Infinity;

    const calc = (bits: number[]): number => {
        let ans = 0;
        for (let i = 0; i < bits.length; i++) {
            if (bits[i] > 0) {
                ans |= 1 << i;
            }
        }
        return ans;
    };

    let left = 0;
    for (let right = 0; right < n; right++) {
        for (let i = 0; i < 30; i++) {
            bits[i] += (nums[right] >> i) & 1;
        }
        while (left <= right && calc(bits) >= k) {
            res = Math.min(res, right - left + 1);
            for (let i = 0; i < 30; i++) {
                bits[i] -= (nums[left] >> i) & 1;
            }
            left++;
        }
    }

    return res === Infinity ? -1 : res;
};
```

```Rust
impl Solution {
    pub fn minimum_subarray_length(nums: Vec<i32>, k: i32) -> i32 {
        let n = nums.len();
        let mut bits = [0; 30];
        let mut res = i32::MAX;

        let calc = |bits: &[i32]| -> i32 {
            let mut ans = 0;
            for i in 0..30 {
                if bits[i] > 0 {
                    ans |= 1 << i;
                }
            }
            ans
        };

        let mut left = 0;
        for right in 0..n {
            for i in 0..30 {
                bits[i] += (nums[right] >> i) & 1;
            }
            while left <= right && calc(&bits) >= k {
                res = res.min((right - left + 1) as i32);
                for i in 0..30 {
                    bits[i] -= (nums[left] >> i) & 1;
                }
                left += 1;
            }
        }

        if res == i32::MAX {
            -1
        } else {
            res
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \log U)$，其中 $n$ 表示给定数组 $nums$ 的长度，$U$ 表示数组中的最大的元素。由于使用滑动窗口遍历需要的时间为 $O(n)$，每次更新窗口元素时需要实时计算当前子数组按位**或**的值需要的时间为 $O( \log U)$，此时需要的总时间即为 $O(n \log U)$。
- 空间复杂度：$O( \log U)$。计算时需要存储当前子数组中每一个二进制位中的统计情况，最多有 $ \log U$ 位需要记录，因此需要的空间为 $ \log U$。
