### [使二进制数组全部等于 1 的最少操作次数 I](https://leetcode.cn/problems/minimum-operations-to-make-binary-array-elements-equal-to-one-i/solutions/2928190/shi-er-jin-zhi-shu-zu-quan-bu-deng-yu-1-lx2nx/)

#### 方法一：模拟

**思路与算法**

给定的数组中的元素要么为 $0$，要么为 $1$，题目要求将数组中所有元素都变为 $1$，由于每次可以**反转**的元素为**连续** $3$ 个元素，此时只能从左到右或者从右到左依次遍历数组中的每个元素，遇到 $0$ 时，则将后续的连续 $3$ 个相邻的元素进行**反转**即可，任意连续的 $3$ 个元素最多只会**反转** $1$ 次，且所有的反转操作都是必要的。

实际操作过程如下：

- 我们依次遍历数组 $nums$ 中的每个元素 $nums[i]$，如果 $nums[i]=1$，则跳过；如果 $nums[i]=0$，则将连续的 $3$ 个元素 $nums[i],nums[i+1],nums[i+2]$ 进行反转，同时反转统计次数加 $1$，直到当前元素后续的元素不足 $3$ 个，此时无法进行反转，如果此时仍然存在 $nums[i]=0$ 的情形，则返回 $−1$，最终返回总的反转次数即可。

**代码**

```C++
class Solution {
public:
    int minOperations(vector<int>& nums) {
        int n = nums.size();
        int ans = 0;
        
        for (int i = 0; i < n; i++) {
            if (nums[i] == 0) {
                if (i > n - 3) {
                    return -1;
                }
                nums[i] ^= 1;
                nums[i + 1] ^= 1;
                nums[i + 2] ^= 1;
                ans++;
            }
        }

        return ans;
    }
};
```

```Java
class Solution {
    public int minOperations(int[] nums) {
        int n = nums.length;
        int ans = 0;
        for (int i = 0; i < n; i++) {
            if (nums[i] == 0) {
                if (i > n - 3) {
                    return -1;
                }
                nums[i] ^= 1;
                nums[i + 1] ^= 1;
                nums[i + 2] ^= 1;
                ans++;
            }
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MinOperations(int[] nums) {
        int n = nums.Length;
        int ans = 0;
        for (int i = 0; i < n; i++) {
            if (nums[i] == 0) {
                if (i > n - 3) {
                    return -1;
                }
                nums[i] ^= 1;
                nums[i + 1] ^= 1;
                nums[i + 2] ^= 1;
                ans++;
            }
        }
        return ans;
    }
}
```

```Go
func minOperations(nums []int) int {
    n := len(nums)
    ans := 0
    for i := 0; i < n; i++ {
        if nums[i] == 0 {
            if i > n - 3 {
                return -1
            }
            nums[i] ^= 1
            nums[i + 1] ^= 1
            nums[i + 2] ^= 1
            ans++
        }
    }
    return ans
}
```

```Python
class Solution:
    def minOperations(self, nums: List[int]) -> int:
        n = len(nums)
        ans = 0
        for i in range(n):
            if nums[i] == 0:
                if i > n - 3:
                    return -1
                nums[i] ^= 1
                nums[i + 1] ^= 1
                nums[i + 2] ^= 1
                ans += 1
        return ans
```

```C
int minOperations(int* nums, int numsSize) {
    int ans = 0;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] == 0) {
            if (i > numsSize - 3) {
                return -1;
            }
            nums[i] ^= 1;
            nums[i + 1] ^= 1;
            nums[i + 2] ^= 1;
            ans++;
        }
    }

    return ans;
}
```

```JavaScript
var minOperations = function(nums) {
    let n = nums.length;
    let ans = 0;
    for (let i = 0; i < n; i++) {
        if (nums[i] === 0) {
            if (i > n - 3) {
                return -1;
            }
            nums[i] ^= 1;
            nums[i + 1] ^= 1;
            nums[i + 2] ^= 1;
            ans++;
        }
    }

    return ans;
};
```

```TypeScript
function minOperations(nums: number[]): number {
    const n = nums.length;
    let ans = 0;
    for (let i = 0; i < n; i++) {
        if (nums[i] === 0) {
            if (i > n - 3) {
                return -1;
            }
            nums[i] ^= 1;
            nums[i + 1] ^= 1;
            nums[i + 2] ^= 1;
            ans++;
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn min_operations(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut ans = 0;
        for i in 0..n {
            if nums[i] == 0 {
                if i > n - 3 {
                    return -1;
                }
                nums[i] ^= 1;
                nums[i + 1] ^= 1;
                nums[i + 2] ^= 1;
                ans += 1;
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 表示给定的数组 $nums$ 的长度。只需遍历一遍数组即可。
- 空间复杂度：$O(1)$。
