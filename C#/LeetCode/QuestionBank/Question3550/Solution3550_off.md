### [数位和等于下标的最小下标](https://leetcode.cn/problems/smallest-index-with-digit-sum-equal-to-index/solutions/4028487/shu-wei-he-deng-yu-xia-biao-de-zui-xiao-mzrh2/)

#### 方法一：遍历

**思路与算法**

按题意，我们需要在 $nums$ 中从左到右找出第一个满足 $nums[i]$ 的数位和等于 $i$ 的下标。

直接从左到右遍历 $nums$，求出 $nums[i]$ 的数位和并判断是否满足条件即可。

**代码**

```C++
class Solution {
public:
    int smallestIndex(const std::vector<int>& nums) {
        auto getDigitSum = [](int num) {
            int sum = 0;

            while (num > 0) {
                sum += num % 10;
                num /= 10;
            }

            return sum;
        };

        for (int i = 0; i < static_cast<int>(nums.size()); ++i) {
            if (getDigitSum(nums[i]) == i) {
                return i;
            }
        }

        return -1;
    }
};
```

```Java
class Solution {
    public int smallestIndex(int[] nums) {
        for (int i = 0; i < nums.length; i++) {
            int num = nums[i];
            int digitSum = 0;

            while (num > 0) {
                digitSum += num % 10;
                num /= 10;
            }

            if (digitSum == i) {
                return i;
            }
        }

        return -1;
    }
}
```

```Python
class Solution:
    def smallestIndex(self, nums: list[int]) -> int:
        def get_digit_sum(num: int) -> int:
            total = 0

            while num:
                num, digit = divmod(num, 10)
                total += digit

            return total

        for i, num in enumerate(nums):
            if get_digit_sum(num) == i:
                return i

        return -1
```

```JavaScript
var smallestIndex = function(nums) {
    const getDigitSum = (num) => {
        let sum = 0;

        while (num > 0) {
            sum += num % 10;
            num = Math.floor(num / 10);
        }

        return sum;
    };

    for (let i = 0; i < nums.length; i++) {
        if (getDigitSum(nums[i]) === i) {
            return i;
        }
    }

    return -1;
};
```

```TypeScript
function smallestIndex(nums: number[]): number {
    const getDigitSum = (num: number) => {
        let sum = 0;
        while (num > 0) {
            sum += num % 10;
            num = Math.floor(num / 10);
        }
        return sum;
    }

    for (let i = 0; i < nums.length; i++) {
        if (getDigitSum(nums[i]) === i) {
            return i;
        }
    }
    return -1;
};
```

```Go
func smallestIndex(nums []int) int {
	for i, num := range nums {
		digitSum := 0

		for num > 0 {
			digitSum += num % 10
			num /= 10
		}

		if digitSum == i {
			return i
		}
	}

	return -1
}
```

```CSharp
public class Solution {
    public int SmallestIndex(int[] nums) {
        for (int i = 0; i < nums.Length; i++) {
            int num = nums[i];
            int digitSum = 0;

            while (num > 0) {
                digitSum += num % 10;
                num /= 10;
            }

            if (digitSum == i) {
                return i;
            }
        }

        return -1;
    }
}
```

```C
int smallestIndex(const int* nums, int numsSize) {
    for (int i = 0; i < numsSize; ++i) {
        int num = nums[i];
        int digitSum = 0;

        while (num > 0) {
            digitSum += num % 10;
            num /= 10;
        }

        if (digitSum == i) {
            return i;
        }
    }

    return -1;
}
```

```Rust
impl Solution {
    pub fn smallest_index(nums: Vec<i32>) -> i32 {
        for (i, &num) in nums.iter().enumerate() {
            let mut num = num;
            let mut digit_sum = 0;

            while num > 0 {
                digit_sum += num % 10;
                num /= 10;
            }

            if digit_sum == i as i32 {
                return i as i32;
            }
        }

        -1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log m)$，其中 $n$ 是 $nums$ 的长度，$m$ 是 $nums$ 中最大的数。使用移位法求数位和需要 $O(\log m)$ 的时间。
- 空间复杂度：$O(1)$。
