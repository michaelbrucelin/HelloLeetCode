### [统计元素和差值为偶数的分区方案](https://leetcode.cn/problems/count-partitions-with-even-sum-difference/solutions/3843925/tong-ji-yuan-su-he-chai-zhi-wei-ou-shu-d-mruw/)

#### 方法一：数学

令数组 $nums$ 的元素和为 $sum$，划分的两个非空子数组的元素和分别为 $x$ 与 $y$，显然有 $x+y=sum$。

- 如果 $sum$ 为奇数，那么有 $x$ 为奇数、$y$ 为偶数或 $x$ 为偶数、$y$ 为奇数，从而 $x-y$ 为奇数。
- 如果 $sum$ 为偶数，那么有 $x$ 为奇数、$y$ 为奇数或 $x$ 为偶数、$y$ 为偶数，从而 $x-y$ 为偶数。

根据以上推导，令 $n$ 为数组 $nums$ 的元素数目，当 $sum$ 为偶数时，差值为偶数的分区方案为 $n-1$，当 $sum$ 为奇数时，差值为偶数的分区方案为 $0$。

```C++
class Solution {
public:
    int countPartitions(vector<int>& nums) {
        int totalSum = 0;
        for (int x : nums) {
            totalSum += x;
        }
        return totalSum % 2 == 0 ? nums.size() - 1 : 0;
    }
};
```

```Go
func countPartitions(nums []int) int {
    totalSum := 0
    for _, x := range nums {
        totalSum += x
    }
    if totalSum%2 == 0 {
        return len(nums) - 1
    }
    return 0
}
```

```Python
class Solution:
    def countPartitions(self, nums: List[int]) -> int:
        totalSum = sum(nums)
        return len(nums) - 1 if totalSum % 2 == 0 else 0
```

```Java
class Solution {
    public int countPartitions(int[] nums) {
        int totalSum = 0;
        for (int x : nums) {
            totalSum += x;
        }
        return totalSum % 2 == 0 ? nums.length - 1 : 0;
    }
}
```

```TypeScript
function countPartitions(nums: number[]): number {
    const totalSum = nums.reduce((a, b) => a + b, 0);
    return totalSum % 2 === 0 ? nums.length - 1 : 0;
}
```

```JavaScript
function countPartitions(nums) {
    const totalSum = nums.reduce((a, b) => a + b, 0);
    return totalSum % 2 === 0 ? nums.length - 1 : 0;
}
```

```CSharp
public class Solution {
    public int CountPartitions(int[] nums) {
        int totalSum = 0;
        foreach (int x in nums) {
            totalSum += x;
        }
        return totalSum % 2 == 0 ? nums.Length - 1 : 0;
    }
}
```

```C
int countPartitions(int* nums, int numsSize) {
    int totalSum = 0;
    for (int i = 0; i < numsSize; ++i) {
        totalSum += nums[i];
    }
    return totalSum % 2 == 0 ? numsSize - 1 : 0;
}
```

```Rust
impl Solution {
    pub fn count_partitions(nums: Vec<i32>) -> i32 {
        let total_sum: i32 = nums.iter().sum();
        if total_sum % 2 == 0 {
            nums.len() as i32 - 1
        } else {
            0
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。
- 空间复杂度：$O(1)$。
