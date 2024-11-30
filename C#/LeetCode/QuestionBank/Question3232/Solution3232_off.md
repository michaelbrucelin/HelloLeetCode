### [判断是否可以赢得数字游戏](https://leetcode.cn/problems/find-if-digit-game-can-be-won/solutions/2992039/pan-duan-shi-fou-ke-yi-ying-de-shu-zi-yo-pgv8/)

#### 方法一：求和

**思路与算法**

由于 $nums$ 中的数字都大于等于 $0$ 且小于等于 $99$，因此我们对 $nums$ 中的个位数和两位数分别进行求和，若两者的和不相等，则表明 $Alice$ 总能选出更大的那个获胜，否则 $Alice$ 不能获胜。

**代码**

```C++
class Solution {
public:
    bool canAliceWin(vector<int>& nums) {
        int single_digit_sum = 0;
        int double_digit_sum = 0;
        for (auto num : nums) {
            if (num < 10) {
                single_digit_sum += num;
            } else {
                double_digit_sum += num;
            }
        }
        return single_digit_sum != double_digit_sum;
    }
};
```

```Java
class Solution {
    public boolean canAliceWin(int[] nums) {
        int singleDigitSum = 0;
        int doubleDigitSum = 0;
        for (int num : nums) {
            if (num < 10) {
                singleDigitSum += num;
            } else {
                doubleDigitSum += num;
            }
        }
        return singleDigitSum != doubleDigitSum;
    }
}
```

```CSharp
public class Solution {
    public bool CanAliceWin(int[] nums) {
        int singleDigitSum = 0;
        int doubleDigitSum = 0;
        foreach (int num in nums) {
            if (num < 10) {
                singleDigitSum += num;
            } else {
                doubleDigitSum += num;
            }
        }
        return singleDigitSum != doubleDigitSum;
    }
}
```

```Python
class Solution:
    def canAliceWin(self, nums: List[int]) -> bool:
        single_digit_sum = 0
        double_digit_sum = 0
        for num in nums:
            if num < 10:
                single_digit_sum += num
            else:
                double_digit_sum += num
        return single_digit_sum != double_digit_sum
```

```Go
func canAliceWin(nums []int) bool {
    singleDigitSum := 0
    doubleDigitSum := 0

    for _, num := range nums {
        if num < 10 {
            singleDigitSum += num
        } else {
            doubleDigitSum += num
        }
    }

    return singleDigitSum != doubleDigitSum
}
```

```Rust
impl Solution {
    pub fn can_alice_win(nums: Vec<i32>) -> bool {
        let mut single_digit_sum : i32 = 0;
        let mut double_digit_sum : i32 = 0;
        for &num in &nums {
            if num < 10 {
                single_digit_sum += num;
            } else {
                double_digit_sum += num;
            }
        }
        (single_digit_sum != double_digit_sum) as bool
    }
}
```

```C
bool canAliceWin(int* nums, int numsSize) {
    int single_digit_sum = 0;
    int double_digit_sum = 0;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] < 10) {
            single_digit_sum += nums[i];
        } else {
            double_digit_sum += nums[i];
        }
    }
    return single_digit_sum != double_digit_sum;
}
```

```JavaScript
var canAliceWin = function(nums) {
    let single_digit_sum = 0;
    let double_digit_sum = 0;
    for (const num of nums) {
        if (num < 10) {
            single_digit_sum += num;
        } else {
            double_digit_sum += num;
        }
    }
    return single_digit_sum != double_digit_sum;
};
```

```TypeScript
function canAliceWin(nums: number[]): boolean {
    let single_digit_sum = 0;
    let double_digit_sum = 0;
    for (const num of nums) {
        if (num < 10) {
            single_digit_sum += num;
        } else {
            double_digit_sum += num;
        }
    }
    return single_digit_sum != double_digit_sum;
};
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。
- 空间复杂度：$O(1)$。
