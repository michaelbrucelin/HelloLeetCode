### [检测相邻递增子数组 I](https://leetcode.cn/problems/adjacent-increasing-subarrays-detection-i/solutions/3801862/jian-ce-xiang-lin-di-zeng-zi-shu-zu-i-by-njbb/)

#### 方法一：一次遍历

**思路与算法**

如果存在两个相邻且长度为 $k$ 的严格递增子数组，那么也会存在两个相邻且长度为 $k-1$ 的严格递增子数组（去掉首尾两个元素）。因此，我们只需要找到最大的满足要求的值 $k′$，如果 $k\le k′$，那么返回 $true$，否则返回 $false$。

我们对数组 $nums$ 进行一次遍历，在遍历的过程中，用 $cnt$ 和 $precnt$ 分别记录到当前位置严格递增的子数组的长度，以及上一个严格递增子数组的长度。

初始时，$cnt$ 的值为 $1$，$precnt$ 的值为 $0$。当遍历到 $nums[i]$ 时，如果大于 $nums[i-1]$，则 $cnt$ 自增 $1$；否则子数组不再递增，将 $cnt$ 的值赋予 $precnt$，并将 $cnt$ 置为 $1$。

满足题目要求的两个相邻子数组有两种情况：

1. 前一个子数组属于 $precnt$，后一个子数组属于 $cnt$，$k′$ 值为 $min(precnt,cnt)$。
2. 两个子数组都属于 $cnt$，$k′$ 值为 $\lfloor\dfrac{cnt}{2}\rfloor$，其中 $\lfloor \cdot \rfloor$ 表示向下取整。

根据这两种情况，不断更新 $k′$ 的最大值即可。遍历完成之后，判断 $k\le k′$ 是否成立。

**代码**

```C++
class Solution {
public:
    bool hasIncreasingSubarrays(vector<int>& nums, int k) {
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
        return ans >= k;
    }
};
```

```Python
class Solution:
    def hasIncreasingSubarrays(self, nums: List[int], k: int) -> bool:
        n = len(nums)
        cnt, precnt, ans = 1, 0, 0
        for i in range(1, n):
            if nums[i] > nums[i - 1]:
                cnt += 1
            else:
                precnt, cnt = cnt, 1
            ans = max(ans, min(precnt, cnt))
            ans = max(ans, cnt // 2)
        return ans >= k
```

```CSharp
public class Solution {
    public bool HasIncreasingSubarrays(IList<int> nums, int k) {
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
        return ans >= k;
    }
}
```

```Go
func hasIncreasingSubarrays(nums []int, k int) bool {
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
    return ans >= k
}
```

```Python
class Solution:
    def hasIncreasingSubarrays(self, nums: List[int], k: int) -> bool:
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
        return ans >= k
```

```C
bool hasIncreasingSubarrays(int* nums, int numsSize, int k) {
    int cnt = 1, precnt = 0, ans = 0;
    for (int i = 1; i < numsSize; ++i) {
        if (nums[i] > nums[i - 1]) {
            ++cnt;
        } else {
            precnt = cnt;
            cnt = 1;
        }
        ans = fmax(ans, fmin(precnt, cnt));
        ans = fmax(ans, cnt / 2);
    }
    return ans >= k;
}
```

```JavaScript
var hasIncreasingSubarrays = function(nums, k) {
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
    return ans >= k;
};
```

```TypeScript
function hasIncreasingSubarrays(nums: number[], k: number): boolean {
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
    return ans >= k;
}
```

```Rust
impl Solution {
    pub fn has_increasing_subarrays(nums: Vec<i32>, k: i32) -> bool {
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
        
        ans >= k
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$。
