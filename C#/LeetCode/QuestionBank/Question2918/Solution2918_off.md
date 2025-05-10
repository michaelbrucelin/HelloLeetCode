### [数组的最小相等和](https://leetcode.cn/problems/minimum-equal-sum-of-two-arrays-after-replacing-zeros/solutions/3665133/shu-zu-de-zui-xiao-xiang-deng-he-by-leet-5cam/)

#### 方法一：分类讨论

**思路与算法**

题目要求我们将两个数组中所有的 $0$ 替换为正整数，且使它们的和相等。不难想到，将数组中的所有 $0$ 变为 $1$ 能够使该数组所有元素的和最小。

记 $nums_1,nums_2$ 的和分别是 $sum_1,sum_2$，数组中 $0$ 的数量分别是 $zero_1,zero_2$，则两个数组可达的最小和分别是 $sum_1+zero_1,sum_2+zero_2$。当两个数组中都存在至少一个 $0$ 时，一定存在答案，且答案为 $max(sum_1+zero_1,sum_2+zero_2)$。当某个数组中不存在 $0$ 时，如果另一个数组可达的最小和大于此数组的和，由于没有办法使此数组的和变大来使两个数组和相等，返回 $-1$。

**代码**

```C++
class Solution {
public:
    long long minSum(vector<int>& nums1, vector<int>& nums2) {
        long long sum1 = 0, sum2 = 0;
        long long zero1 = 0, zero2 = 0;
        for (int i : nums1) {
            sum1 += i;
            if (i == 0) {
                sum1++;
                zero1++;
            }
        }
        for (int i : nums2) {
            sum2 += i;
            if (i == 0) {
                sum2++;
                zero2++;
            }
        }
        if (!zero1 && sum2 > sum1 || !zero2 && sum1 > sum2) {
            return -1;
        }
        return max(sum1, sum2);
    }
};
```

```Java
class Solution {
    public long minSum(int[] nums1, int[] nums2) {
        long sum1 = 0, sum2 = 0;
        long zero1 = 0, zero2 = 0;

        for (int i : nums1) {
            sum1 += i;
            if (i == 0) {
                sum1++;
                zero1++;
            }
        }

        for (int i : nums2) {
            sum2 += i;
            if (i == 0) {
                sum2++;
                zero2++;
            }
        }

        if ((zero1 == 0 && sum2 > sum1) || (zero2 == 0 && sum1 > sum2)) {
            return -1;
        }

        return Math.max(sum1, sum2);
    }
}
```

```CSharp
public class Solution {
    public long MinSum(int[] nums1, int[] nums2) {
        long sum1 = 0, sum2 = 0;
        long zero1 = 0, zero2 = 0;

        foreach (int i in nums1) {
            sum1 += i;
            if (i == 0) {
                sum1++;
                zero1++;
            }
        }

        foreach (int i in nums2) {
            sum2 += i;
            if (i == 0) {
                sum2++;
                zero2++;
            }
        }

        if ((zero1 == 0 && sum2 > sum1) || (zero2 == 0 && sum1 > sum2)) {
            return -1;
        }

        return Math.Max(sum1, sum2);
    }
}
```

```Go
func minSum(nums1 []int, nums2 []int) int64 {
    var sum1, sum2 int64
    var zero1, zero2 int

    for _, num := range nums1 {
        sum1 += int64(num)
        if num == 0 {
            sum1++
            zero1++
        }
    }

    for _, num := range nums2 {
        sum2 += int64(num)
        if num == 0 {
            sum2++
            zero2++
        }
    }

    if (zero1 == 0 && sum2 > sum1) || (zero2 == 0 && sum1 > sum2) {
        return -1
    }

    if sum1 > sum2 {
        return sum1
    }
    return sum2
}
```

```Python
class Solution:
    def minSum(self, nums1: List[int], nums2: List[int]) -> int:
        sum1 = sum2 = 0
        zero1 = zero2 = 0

        for i in nums1:
            sum1 += i
            if i == 0:
                sum1 += 1
                zero1 += 1

        for i in nums2:
            sum2 += i
            if i == 0:
                sum2 += 1
                zero2 += 1

        if (zero1 == 0 and sum2 > sum1) or (zero2 == 0 and sum1 > sum2):
            return -1

        return max(sum1, sum2)

```

```C
long long minSum(int* nums1, int nums1Size, int* nums2, int nums2Size) {
    long long sum1 = 0, sum2 = 0;
    int zero1 = 0, zero2 = 0;

    for (int i = 0; i < nums1Size; i++) {
        sum1 += nums1[i];
        if (nums1[i] == 0) {
            sum1 += 1;
            zero1++;
        }
    }

    for (int i = 0; i < nums2Size; i++) {
        sum2 += nums2[i];
        if (nums2[i] == 0) {
            sum2 += 1;
            zero2++;
        }
    }

    if ((zero1 == 0 && sum2 > sum1) || (zero2 == 0 && sum1 > sum2)) {
        return -1;
    }

    return sum1 > sum2 ? sum1 : sum2;
}
```

```JavaScript
var minSum = function (nums1, nums2) {
    let sum1 = 0, sum2 = 0;
    let zero1 = 0, zero2 = 0;

    for (let i of nums1) {
        sum1 += i;
        if (i === 0) {
            sum1++;
            zero1++;
        }
    }

    for (let i of nums2) {
        sum2 += i;
        if (i === 0) {
            sum2++;
            zero2++;
        }
    }

    if ((zero1 === 0 && sum2 > sum1) || (zero2 === 0 && sum1 > sum2)) {
        return -1;
    }

    return Math.max(sum1, sum2);
};
```

```TypeScript
function minSum(nums1: number[], nums2: number[]): number {
    let sum1 = 0, sum2 = 0;
    let zero1 = 0, zero2 = 0;

    for (let i of nums1) {
        sum1 += i;
        if (i === 0) {
            sum1++;
            zero1++;
        }
    }

    for (let i of nums2) {
        sum2 += i;
        if (i === 0) {
            sum2++;
            zero2++;
        }
    }

    if ((zero1 === 0 && sum2 > sum1) || (zero2 === 0 && sum1 > sum2)) {
        return -1;
    }

    return Math.max(sum1, sum2);
}
```

```Rust
impl Solution {
    pub fn min_sum(nums1: Vec<i32>, nums2: Vec<i32>) -> i64 {
        let mut sum1: i64 = 0;
        let mut sum2: i64 = 0;
        let mut zero1 = 0;
        let mut zero2 = 0;

        for &x in &nums1 {
            sum1 += x as i64;
            if x == 0 {
                sum1 += 1;
                zero1 += 1;
            }
        }

        for &x in &nums2 {
            sum2 += x as i64;
            if x == 0 {
                sum2 += 1;
                zero2 += 1;
            }
        }

        if (zero1 == 0 && sum2 > sum1) || (zero2 == 0 && sum1 > sum2) {
            return -1;
        }

        sum1.max(sum2)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m)$，其中 $n,m$ 分别是 $nums_1,nums_2$ 的长度。
- 空间复杂度：$O(1)$。
