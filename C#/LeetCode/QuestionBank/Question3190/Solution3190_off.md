### [使所有元素都可以被 3 整除的最少操作数](https://leetcode.cn/problems/find-minimum-operations-to-make-all-elements-divisible-by-three/solutions/3833850/shi-suo-you-yuan-su-du-ke-yi-bei-3-zheng-e8d2/)

#### 方法一：遍历

**思路与算法**

对于任意整数 $x$，要使其被 $3$ 整除，可以有两种操作方案：

1. 将 $x$ 增加至下一个最近的 $3$ 的倍数，所需要的操作次数是 $3-x \mod 3$。
2. 将 $x$ 减少至 $3$ 的倍数，所需要的操作次数是 $x \mod 3$。

选择操作次数较少的方案作为结果即可。

对于 $nums$ 中的每个数，计算最小操作次数并累计，即为所求结果。

**代码**

```C++
class Solution {
public:
    int minimumOperations(vector<int>& nums) {
        return std::accumulate(nums.begin(), nums.end(), 0, [](int acc, int v) {
            return acc + std::min(v % 3, 3 - v % 3);
        });
    }
};
```

```Python
class Solution:
    def minimumOperations(self, nums: List[int]) -> int:
        return sum(min(x % 3, 3 - x % 3) for x in nums)
```

```CSharp
public class Solution {
    public int MinimumOperations(int[] nums) {
        return nums
            .Select(x => {
                return Math.Min(x % 3, 3 - x % 3);
            })
            .Sum();
    }
}
```

```Java
class Solution {
    public int minimumOperations(int[] nums) {
        return Arrays.stream(nums)
                .map(x -> Math.min(x % 3, 3 - x % 3))
                .sum();
    }
}
```

```Go
func minimumOperations(nums []int) int {
    sum := 0
    for _, x := range nums {
        remainder := x % 3
        sum += min(remainder, 3 - remainder)
    }
    return sum
}
```

```C
int minimumOperations(int* nums, int numsSize) {
    int sum = 0;
    for (int i = 0; i < numsSize; i++) {
        int remainder = nums[i] % 3;
        sum += (remainder < 3 - remainder) ? remainder : (3 - remainder);
    }
    return sum;
}
```

```JavaScript
var minimumOperations = function (nums) {
    return nums.reduce((pre, v) => pre += Math.min(3 - v % 3, v % 3), 0);
};
```

```TypeScript
function minimumOperations(nums: number[]): number {
    return nums.reduce((pre,v) => pre += Math.min(3 - v % 3, v % 3), 0);
};
```

```Rust
impl Solution {
    pub fn minimum_operations(nums: Vec<i32>) -> i32 {
        nums
        .iter()
        .map(|&x| {
            let r = x % 3;
            r.min(3 - r)
        })
        .sum()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。
- 空间复杂度：$O(1)$。
