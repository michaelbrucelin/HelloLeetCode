### [分割数组的方案数](https://leetcode.cn/problems/number-of-ways-to-split-array/solutions/1501536/fen-ge-shu-zu-de-fang-an-shu-by-leetcode-3ygv/)

#### 方法一：枚举 + 前缀和

**思路与算法**

我们只需要枚举所有的分割位置，并找出其中的合法分割即可。

具体地，我们用 $left$ 和 $right$ 分别表示分割左侧和右侧的所有元素之和。
初始时，$left=0$，$right$ 的值为给定数组 $nums$ 的所有元素之和。我们从小到大依次枚举每一个分割位置，当枚举到位置 $i$ 时，我们将 $left$ 加上 $nums[i]$，并将 $right$ 减去 $nums[i]$，这样就可以实时正确地维护分割左侧和右侧的元素之和。
如果 $left \ge right$，那么就找出了一个合法分割。

**代码**

```C++
class Solution {
public:
    int waysToSplitArray(vector<int>& nums) {
        int n = nums.size();
        long long left = 0, right = accumulate(nums.begin(), nums.end(), 0LL);
        int ans = 0;
        for (int i = 0; i < n - 1; ++i) {
            left += nums[i];
            right -= nums[i];
            if (left >= right) {
                ++ans;
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def waysToSplitArray(self, nums: List[int]) -> int:
        n, left, right = len(nums), 0, sum(nums)
        ans = 0
        for i in range(n - 1):
            left += nums[i]
            right -= nums[i]
            if left >= right:
                ans += 1
        return ans
```

```C
int waysToSplitArray(int* nums, int numsSize) {
    int n = numsSize;
    long long left = 0, right = 0;
    for (int i = 0; i < n; ++i) {
        right += nums[i];
    }
    int ans = 0;
    for (int i = 0; i < n - 1; ++i) {
        left += nums[i];
        right -= nums[i];
        if (left >= right) {
            ++ans;
        }
    }
    return ans;
}
```

```Go
func waysToSplitArray(nums []int) int {
    n := len(nums)
    left, right := int64(0), int64(0)
    for _, num := range nums {
        right += int64(num)
    }
    ans := 0
    for i := 0; i < n-1; i++ {
        left += int64(nums[i])
        right -= int64(nums[i])
        if left >= right {
            ans++
        }
    }
    return ans
}
```

```Java
class Solution {
    public int waysToSplitArray(int[] nums) {
        int n = nums.length;
        long left = 0, right = 0;
        for (int num : nums) {
            right += num;
        }
        int ans = 0;
        for (int i = 0; i < n - 1; i++) {
            left += nums[i];
            right -= nums[i];
            if (left >= right) {
                ans++;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int WaysToSplitArray(int[] nums) {
        int n = nums.Length;
        long left = 0, right = 0;
        foreach (int num in nums) {
            right += num;
        }
        int ans = 0;
        for (int i = 0; i < n - 1; i++) {
            left += nums[i];
            right -= nums[i];
            if (left >= right) {
                ans++;
            }
        }
        return ans;
    }
}
```

```JavaScript
var waysToSplitArray = function(nums) {
    let n = nums.length;
    let left = 0, right = nums.reduce((a, b) => a + b, 0);
    let ans = 0;
    for (let i = 0; i < n - 1; i++) {
        left += nums[i];
        right -= nums[i];
        if (left >= right) {
            ans++;
        }
    }
    return ans;
};
```

```TypeScript
function waysToSplitArray(nums: number[]): number {
    let n = nums.length;
    let left = 0, right = nums.reduce((a, b) => a + b, 0);
    let ans = 0;
    for (let i = 0; i < n - 1; i++) {
        left += nums[i];
        right -= nums[i];
        if (left >= right) {
            ans++;
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn ways_to_split_array(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut left: i64 = 0;
        let mut right: i64 = nums.iter().map(|&x| x as i64).sum();
        let mut ans = 0;
        for i in 0..n-1 {
            left += nums[i] as i64;
            right -= nums[i] as i64;
            if left >= right {
                ans += 1;
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$。
