### [左右元素和的差值](https://leetcode.cn/problems/left-and-right-sum-differences/solutions/3976320/zuo-you-yuan-su-he-de-chai-zhi-by-leetco-9aez/)

#### 方法一：前缀和

**思路与算法**

我们用两次遍历来求解。第一次从左到右遍历数组，维护变量 $leftSum$ 表示当前位置左侧所有元素之和，并将其存入答案数组 $ans[i]$，然后将 $nums[i]$ 累加到 $leftSum$ 中。

第二次从右到左遍历数组，维护变量 $rightSum$ 表示当前位置右侧所有元素之和。此时 $ans[i]$ 中已经存储了位置 $i$ 左侧所有元素之和，因此直接将 $ans[i]$ 更新为 $\vert ans[i]-rightSum\vert $，然后将 $nums[i]$ 累加到 $rightSum$ 中即可。

**代码**

```C++
class Solution {
public:
    vector<int> leftRightDifference(vector<int>& nums) {
        int n = nums.size();
        vector<int> ans(n);

        int leftSum = 0;
        for (int i = 0; i < n; ++i) {
            ans[i] = leftSum;
            leftSum += nums[i];
        }

        int rightSum = 0;
        for (int i = n - 1; i >= 0; --i) {
            ans[i] = abs(ans[i] - rightSum);
            rightSum += nums[i];
        }

        return ans;
    }
};
```

```Python
class Solution:
    def leftRightDifference(self, nums: List[int]) -> List[int]:
        n = len(nums)
        ans = [0] * n

        left_sum = 0
        for i in range(n):
            ans[i] = left_sum
            left_sum += nums[i]

        right_sum = 0
        for i in range(n - 1, -1, -1):
            ans[i] = abs(ans[i] - right_sum)
            right_sum += nums[i]

        return ans
```

```Java
class Solution {
    public int[] leftRightDifference(int[] nums) {
        int n = nums.length;
        int[] ans = new int[n];

        int leftSum = 0;
        for (int i = 0; i < n; ++i) {
            ans[i] = leftSum;
            leftSum += nums[i];
        }

        int rightSum = 0;
        for (int i = n - 1; i >= 0; --i) {
            ans[i] = Math.abs(ans[i] - rightSum);
            rightSum += nums[i];
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public int[] LeftRightDifference(int[] nums) {
        int n = nums.Length;
        int[] ans = new int[n];

        int leftSum = 0;
        for (int i = 0; i < n; ++i) {
            ans[i] = leftSum;
            leftSum += nums[i];
        }

        int rightSum = 0;
        for (int i = n - 1; i >= 0; --i) {
            ans[i] = Math.Abs(ans[i] - rightSum);
            rightSum += nums[i];
        }

        return ans;
    }
}
```

```Go
func leftRightDifference(nums []int) []int {
    n := len(nums)
    ans := make([]int, n)

    leftSum := 0
    for i := 0; i < n; i++ {
        ans[i] = leftSum
        leftSum += nums[i]
    }

    rightSum := 0
    for i := n - 1; i >= 0; i-- {
        ans[i] = abs(ans[i] - rightSum)
        rightSum += nums[i]
    }

    return ans
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

```C
int* leftRightDifference(int* nums, int numsSize, int* returnSize) {
    *returnSize = numsSize;
    int* ans = (int*)malloc(numsSize * sizeof(int));

    int leftSum = 0;
    for (int i = 0; i < numsSize; ++i) {
        ans[i] = leftSum;
        leftSum += nums[i];
    }

    int rightSum = 0;
    for (int i = numsSize - 1; i >= 0; --i) {
        ans[i] = abs(ans[i] - rightSum);
        rightSum += nums[i];
    }

    return ans;
}
```

```JavaScript
var leftRightDifference = function(nums) {
    const n = nums.length;
    const ans = new Array(n);

    let leftSum = 0;
    for (let i = 0; i < n; ++i) {
        ans[i] = leftSum;
        leftSum += nums[i];
    }

    let rightSum = 0;
    for (let i = n - 1; i >= 0; --i) {
        ans[i] = Math.abs(ans[i] - rightSum);
        rightSum += nums[i];
    }

    return ans;
};
```

```TypeScript
function leftRightDifference(nums: number[]): number[] {
    const n = nums.length;
    const ans: number[] = new Array(n);

    let leftSum = 0;
    for (let i = 0; i < n; ++i) {
        ans[i] = leftSum;
        leftSum += nums[i];
    }

    let rightSum = 0;
    for (let i = n - 1; i >= 0; --i) {
        ans[i] = Math.abs(ans[i] - rightSum);
        rightSum += nums[i];
    }

    return ans;
}
```

```Rust
impl Solution {
    pub fn left_right_difference(nums: Vec<i32>) -> Vec<i32> {
        let n = nums.len();
        let mut ans = vec![0; n];

        let mut left_sum = 0;
        for i in 0..n {
            ans[i] = left_sum;
            left_sum += nums[i];
        }

        let mut right_sum = 0;
        for i in (0..n).rev() {
            ans[i] = (ans[i] - right_sum).abs();
            right_sum += nums[i];
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(1)$。这里不计入返回值所占用的空间。
