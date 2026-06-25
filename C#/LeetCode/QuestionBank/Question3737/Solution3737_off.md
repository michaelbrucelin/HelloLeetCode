### [统计主要元素子数组数目 I](https://leetcode.cn/problems/count-subarrays-with-majority-element-i/solutions/3984748/tong-ji-zhu-yao-yuan-su-zi-shu-zu-shu-mu-vj11/)

#### 方法一：枚举

**思路与算法**

我们枚举所有子数组的左端点 $i$，然后向右扩展右端点 $j$。在扩展的过程中，维护计数器 $cnt$：若 $nums[j]=target$，则 $cnt$ 加 $1$，否则减 $1$。

当 $cnt>0$ 时，$target$ 的出现次数严格超过子数组长度的一半，即 $target$ 是该子数组的主要元素，将答案加 $1$。

**代码**

```C++
class Solution {
public:
    int countMajoritySubarrays(vector<int>& nums, int target) {
        int n = nums.size();
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            int cnt = 0;
            for (int j = i; j < n; ++j) {
                cnt += (nums[j] == target ? 1 : -1);
                if (cnt > 0) {
                    ++ans;
                }
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def countMajoritySubarrays(self, nums: List[int], target: int) -> int:
        n = len(nums)
        ans = 0
        for i in range(n):
            cnt = 0
            for j in range(i, n):
                cnt += (1 if nums[j] == target else -1)
                if cnt > 0:
                    ans += 1
        return ans
```

```Java
class Solution {
    public int countMajoritySubarrays(int[] nums, int target) {
        int n = nums.length;
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            int cnt = 0;
            for (int j = i; j < n; ++j) {
                cnt += (nums[j] == target ? 1 : -1);
                if (cnt > 0) {
                    ++ans;
                }
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int CountMajoritySubarrays(int[] nums, int target) {
        int n = nums.Length;
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            int cnt = 0;
            for (int j = i; j < n; ++j) {
                cnt += (nums[j] == target ? 1 : -1);
                if (cnt > 0) {
                    ++ans;
                }
            }
        }
        return ans;
    }
}
```

```Go
func countMajoritySubarrays(nums []int, target int) int {
    n := len(nums)
    ans := 0
    for i := 0; i < n; i++ {
        cnt := 0
        for j := i; j < n; j++ {
            if nums[j] == target {
                cnt++
            } else {
                cnt--
            }
            if cnt > 0 {
                ans++
            }
        }
    }
    return ans
}
```

```C
int countMajoritySubarrays(int* nums, int numsSize, int target) {
    int ans = 0;
    for (int i = 0; i < numsSize; ++i) {
        int cnt = 0;
        for (int j = i; j < numsSize; ++j) {
            cnt += (nums[j] == target ? 1 : -1);
            if (cnt > 0) {
                ++ans;
            }
        }
    }
    return ans;
}
```

```JavaScript
var countMajoritySubarrays = function(nums, target) {
    const n = nums.length;
    let ans = 0;
    for (let i = 0; i < n; ++i) {
        let cnt = 0;
        for (let j = i; j < n; ++j) {
            cnt += (nums[j] === target ? 1 : -1);
            if (cnt > 0) {
                ++ans;
            }
        }
    }
    return ans;
};
```

```TypeScript
function countMajoritySubarrays(nums: number[], target: number): number {
    const n = nums.length;
    let ans = 0;
    for (let i = 0; i < n; ++i) {
        let cnt = 0;
        for (let j = i; j < n; ++j) {
            cnt += (nums[j] === target ? 1 : -1);
            if (cnt > 0) {
                ++ans;
            }
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn count_majority_subarrays(nums: Vec<i32>, target: i32) -> i32 {
        let n = nums.len();
        let mut ans = 0;
        for i in 0..n {
            let mut cnt = 0;
            for j in i..n {
                cnt += if nums[j] == target { 1 } else { -1 };
                if cnt > 0 {
                    ans += 1;
                }
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是数组 $nums$ 的长度。枚举所有子数组需要两重循环。
- 空间复杂度：$O(1)$。
