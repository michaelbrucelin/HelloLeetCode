### [检测相邻递增子数组 II](https://leetcode.cn/problems/adjacent-increasing-subarrays-detection-ii/solutions/3801866/jian-ce-xiang-lin-di-zeng-zi-shu-zu-ii-b-0gen/)

#### 方法一：一次遍历

**思路与算法**

我们对数组 $nums$ 进行一次遍历，在遍历的过程中，用 $cnt$ 和 $precnt$ 分别记录到当前位置严格递增的子数组的长度，以及上一个严格递增子数组的长度。

初始时，$cnt$ 的值为 $1$，$precnt$ 的值为 $0$。当遍历到 $nums[i]$ 时，如果大于 $nums[i-1]$，则 $cnt$ 自增 $1$；否则子数组不再递增，将 $cnt$ 的值赋予 $precnt$，并将 $cnt$ 置为 $1$。

满足题目要求的两个相邻子数组有两种情况：

1. 前一个子数组属于 $precnt$，后一个子数组属于 $cnt$，k 值为 $min(precnt,cnt)$。
2. 两个子数组都属于 $cnt$，k 值为 $\lfloor\dfrac{cnt}{2}\rfloor $，其中 $\lfloor \cdot \rfloor $ 表示向下取整。

根据这两种情况，不断更新 $k$ 的最大值即可。

**代码**

```C++
class Solution {
public:
    int maxIncreasingSubarrays(vector<int>& nums) {
        int n = nums.size();
        int cnt = 1, precnt = 0, ans = 0;
        for (int i = 1; i < n; ++i) {
            if (nums[i] > nums[i - 1]) {
                ++cnt;
            }
            else {
                precnt = cnt;
                cnt = 1;
            }
            ans = max(ans, min(precnt, cnt));
            ans = max(ans, cnt / 2);
        }
        return ans;
    }
};
```

```Python
class Solution:
    def maxIncreasingSubarrays(self, nums: List[int]) -> int:
        n = len(nums)
        cnt, precnt, ans = 1, 0, 0
        for i in range(1, n):
            if nums[i] > nums[i - 1]:
                cnt += 1
            else:
                precnt, cnt = cnt, 1
            ans = max(ans, min(precnt, cnt))
            ans = max(ans, cnt // 2)
        return ans
```

```CSharp
public class Solution {
    public int MaxIncreasingSubarrays(IList<int> nums) {
        int n = nums.Count;
        int cnt = 1, precnt = 0, ans = 0;
        for (int i = 1; i < n; ++i) {
            if (nums[i] > nums[i - 1]) {
                ++cnt;
            } else {
                precnt = cnt;
                cnt = 1;
            }
            ans = Math.Max(ans, Math.Min(precnt, cnt));
            ans = Math.Max(ans, cnt / 2);
        }
        return ans;
    }
}
```

```Go
func maxIncreasingSubarrays(nums []int) int {
    n := len(nums)
    cnt, precnt, ans := 1, 0, 0
    for i := 1; i < n; i++ {
        if nums[i] > nums[i-1] {
            cnt++
        } else {
            precnt = cnt
            cnt = 1
        }
        ans = max(ans, min(precnt, cnt))
        ans = max(ans, cnt/2)
    }
    return ans
}
```

```Python
class Solution:
    def maxIncreasingSubarrays(self, nums: List[int]) -> int:
        n = len(nums)
        cnt, precnt, ans = 1, 0, 0
        for i in range(1, n):
            if nums[i] > nums[i - 1]:
                cnt += 1
            else:
                precnt = cnt
                cnt = 1
            ans = max(ans, min(precnt, cnt))
            ans = max(ans, cnt // 2)
        return ans
```

```C
int maxIncreasingSubarrays(int* nums, int numsSize) {
    int cnt = 1, precnt = 0, ans = 0;
    for (int i = 1; i < numsSize; ++i) {
        if (nums[i] > nums[i - 1]) {
            ++cnt;
        } else {
            precnt = cnt;
            cnt = 1;
        }
        int min_val = precnt < cnt ? precnt : cnt;
        ans = ans > min_val ? ans : min_val;
        ans = ans > cnt / 2 ? ans : cnt / 2;
    }
    return ans;
}
```

```JavaScript
var maxIncreasingSubarrays = function(nums) {
    const n = nums.length;
    let cnt = 1, precnt = 0, ans = 0;
    for (let i = 1; i < n; ++i) {
        if (nums[i] > nums[i - 1]) {
            ++cnt;
        } else {
            precnt = cnt;
            cnt = 1;
        }
        ans = Math.max(ans, Math.min(precnt, cnt));
        ans = Math.max(ans, Math.floor(cnt / 2));
    }
    return ans;
};
```

```TypeScript
function maxIncreasingSubarrays(nums: number[]): number {
    const n = nums.length;
    let cnt = 1, precnt = 0, ans = 0;
    for (let i = 1; i < n; ++i) {
        if (nums[i] > nums[i - 1]) {
            ++cnt;
        } else {
            precnt = cnt;
            cnt = 1;
        }
        ans = Math.max(ans, Math.min(precnt, cnt));
        ans = Math.max(ans, Math.floor(cnt / 2));
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn max_increasing_subarrays(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut cnt = 1;
        let mut precnt = 0;
        let mut ans = 0;
        
        for i in 1..n {
            if nums[i] > nums[i - 1] {
                cnt += 1;
            } else {
                precnt = cnt;
                cnt = 1;
            }
            ans = ans.max(precnt.min(cnt));
            ans = ans.max(cnt / 2);
        }
        
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$。
