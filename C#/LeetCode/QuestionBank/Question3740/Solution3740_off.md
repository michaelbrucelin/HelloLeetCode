### [三个相等元素之间的最小距离 I](https://leetcode.cn/problems/minimum-distance-between-three-equal-elements-i/solutions/3941270/san-ge-xiang-deng-yuan-su-zhi-jian-de-zu-8zfg/)

#### 方法一：暴力

**思路与算法**

本题是[「3741. 三个相等元素之间的最小距离 II」](https://leetcode.cn/problems/minimum-distance-between-three-equal-elements-ii/)的数据简化版，由于数据范围较小，可以直接使用暴力求解。

首先观察要求的绝对值距离之和计算公式：可以发现实际上这就是一个广义三角形的三边之和，不管选取的三个点顺序如何，长度一定等于两倍的端点构成的线段的长度；换而言之，设最右侧点的下标是 $k$，最左侧点的下标是 $i$，所求的距离就是 $2\times (k-i)$。

故使用三重循环暴力枚举所有不同的**顺序**三元组，若 $nums$ 中对应位置的元素相同，则根据上述分析计算距离，最后取全局最小值即为所求。

**代码**

```C++
class Solution {
public:
    int minimumDistance(vector<int>& nums) {
        int n = nums.size();
        int ans = n + 1;

        for (int i = 0; i < n - 2; i++) {
            for (int j = i + 1; j < n - 1; j++) {
                if (nums[i] != nums[j]) {
                    continue;
                }
                for (int k = j + 1; k < n; k++) {
                    if (nums[j] == nums[k]) {
                        ans = std::min(ans, k - i);
                        break;
                    }
                }
            }
        }

        return ans == n + 1 ? -1 : ans * 2;
    }
};
```

```JavaScript
var minimumDistance = function (nums) {
    let ans = nums.length + 1;

    for (let i = 0; i < nums.length - 2; i++) {
        for (let j = i + 1; j < nums.length - 1; j++) {
            if (nums[i] !== nums[j]) {
                continue;
            }
            for (let k = j + 1; k < nums.length; k++) {
                if (nums[j] === nums[k]) {
                    ans = Math.min(ans, k - i);
                    break;
                }
            }
        }
    }

    if (ans === nums.length + 1) {
        return -1;
    } else {
        return ans * 2;
    }
};
```

```TypeScript
function minimumDistance(nums: number[]): number {
    let ans = nums.length + 1;
    for (let i = 0; i < nums.length - 2; i++) {
        for (let j = i + 1; j < nums.length - 1; j++) {
            if (nums[i] !== nums[j]) {
                continue;
            }
            for (let k = j + 1; k < nums.length; k++) {
                if (nums[j] === nums[k]) {
                    ans = Math.min(ans, k - i);
                    break;
                }
            }
        }
    }

    if (ans === nums.length + 1) {
        return -1;
    } else {
        return ans * 2;
    }
}
```

```Java
class Solution {
    public int minimumDistance(int[] nums) {
        int n = nums.length;
        int ans = n + 1;

        for (int i = 0; i < n - 2; i++) {
            for (int j = i + 1; j < n - 1; j++) {
                if (nums[i] != nums[j]) {
                    continue;
                }
                for (int k = j + 1; k < n; k++) {
                    if (nums[j] == nums[k]) {
                        ans = Math.min(ans, k - i);
                        break;
                    }
                }
            }
        }

        return ans == n + 1 ? -1 : ans * 2;
    }
}
```

```CSharp
public class Solution {
    public int MinimumDistance(int[] nums) {
        int n = nums.Length;
        int ans = n + 1;

        for (int i = 0; i < n - 2; i++) {
            for (int j = i + 1; j < n - 1; j++) {
                if (nums[i] != nums[j]) {
                    continue;
                }
                for (int k = j + 1; k < n; k++) {
                    if (nums[j] == nums[k]) {
                        ans = Math.Min(ans, k - i);
                        break;
                    }
                }
            }
        }

        return ans == n + 1 ? -1 : ans * 2;
    }
}
```

```Go
func minimumDistance(nums []int) int {
    n := len(nums)
    ans := n + 1

    for i := 0; i < n-2; i++ {
        for j := i + 1; j < n-1; j++ {
            if nums[i] != nums[j] {
                continue
            }
            for k := j + 1; k < n; k++ {
                if nums[j] == nums[k] {
                    if dist := k - i; dist < ans {
                        ans = dist
                    }
                    break
                }
            }
        }
    }

    if ans == n+1 {
        return -1
    }
    return ans * 2
}
```

```Python
class Solution:
    def minimumDistance(self, nums: List[int]) -> int:
        n = len(nums)
        ans = n + 1

        for i in range(n - 2):
            for j in range(i + 1, n - 1):
                if nums[i] != nums[j]:
                    continue
                for k in range(j + 1, n):
                    if nums[j] == nums[k]:
                        ans = min(ans, k - i)
                        break

        return -1 if ans == n + 1 else ans * 2
```

```C
int minimumDistance(int* nums, int numsSize) {
    int ans = numsSize + 1;

    for (int i = 0; i < numsSize - 2; i++) {
        for (int j = i + 1; j < numsSize - 1; j++) {
            if (nums[i] != nums[j]) {
                continue;
            }
            for (int k = j + 1; k < numsSize; k++) {
                if (nums[j] == nums[k]) {
                    if (k - i < ans) {
                        ans = k - i;
                    }
                    break;
                }
            }
        }
    }

    return ans == numsSize + 1 ? -1 : ans * 2;
}
```

```Rust
impl Solution {
    pub fn minimum_distance(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut ans = n + 1;

        if n < 3 {
           return -1;
        }

        for i in 0..n - 2 {
            for j in i + 1..n - 1 {
                if nums[i] != nums[j] {
                    continue;
                }
                for k in j + 1..n {
                    if nums[j] == nums[k] {
                        ans = ans.min(k - i);
                        break;
                    }
                }
            }
        }

        if ans == n + 1 {
            -1
        } else {
            (ans * 2) as i32
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^3)$，其中 $n$ 是 $nums$ 的长度，求解用到三重循环，每重循环需要 $O(n)$，故总时间复杂度是 $O(n^3)$。
- 空间复杂度：$O(1)$，只声明了常数个变量。
