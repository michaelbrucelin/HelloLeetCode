### [统计数组中相等且可以被整除的数对](https://leetcode.cn/problems/count-equal-and-divisible-pairs-in-an-array/solutions/1300992/tong-ji-shu-zu-zhong-xiang-deng-qie-ke-y-tc4p/)

#### 方法一：遍历数对

**思路与算法**

我们用 $n$ 表示数组 $nums$ 的长度。为了统计符合要求数对数量，我们可以使用两层循环遍历所有满足 $0 \le i < j < n$ 的数对 $(i,j)$，并逐个检查 $i \times j \mod k$ 是否等于 $0$，且 $nums[i]$ 是否等于 $nums[j]$。

与此同时，我们用 $res$ 统计符合要求的数对数量，如果某个数对 $(i,j)$ 符合要求，则我们将 $res$ 加上 $1$。最终，我们返回 $res$ 作为符合要求的数对个数。

**代码**

```C++
class Solution {
public:
    int countPairs(vector<int>& nums, int k) {
        int n = nums.size();
        int res = 0;   // 符合要求数对个数
        for (int i = 0; i < n - 1; ++i) {
            for (int j = i + 1; j < n; ++j) {
                if ((i * j) % k == 0 && nums[i] == nums[j]) {
                    ++res;
                }
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def countPairs(self, nums: List[int], k: int) -> int:
        n = len(nums)
        res = 0   # 符合要求数对个数
        for i in range(n - 1):
            for j in range(i + 1, n):
                if (i * j) % k == 0 and nums[i] == nums[j]:
                    res += 1
        return res
```

```Java
class Solution {
    public int countPairs(int[] nums, int k) {
        int n = nums.length;
        int res = 0;   // 符合要求数对个数
        for (int i = 0; i < n - 1; ++i) {
            for (int j = i + 1; j < n; ++j) {
                if ((i * j) % k == 0 && nums[i] == nums[j]) {
                    ++res;
                }
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int CountPairs(int[] nums, int k) {
        int n = nums.Length;
        int res = 0;   // 符合要求数对个数
        for (int i = 0; i < n - 1; ++i) {
            for (int j = i + 1; j < n; ++j) {
                if ((i * j) % k == 0 && nums[i] == nums[j]) {
                    ++res;
                }
            }
        }
        return res;
    }
}
```

```Go
func countPairs(nums []int, k int) int {
    n := len(nums)
    res := 0   // 符合要求数对个数
    for i := 0; i < n - 1; i++ {
        for j := i + 1; j < n; j++ {
            if (i * j) % k == 0 && nums[i] == nums[j] {
                res++
            }
        }
    }
    return res
}
```

```C
int countPairs(int* nums, int numsSize, int k) {
    int res = 0;   // 符合要求数对个数
    for (int i = 0; i < numsSize - 1; ++i) {
        for (int j = i + 1; j < numsSize; ++j) {
            if ((i * j) % k == 0 && nums[i] == nums[j]) {
                ++res;
            }
        }
    }
    return res;
}
```

```JavaScript
var countPairs = function(nums, k) {
    let n = nums.length;
    let res = 0;   // 符合要求数对个数
    for (let i = 0; i < n - 1; ++i) {
        for (let j = i + 1; j < n; ++j) {
            if ((i * j) % k === 0 && nums[i] === nums[j]) {
                ++res;
            }
        }
    }
    return res;
};
```

```TypeScript
function countPairs(nums: number[], k: number): number {
    let n = nums.length;
    let res = 0;   // 符合要求数对个数
    for (let i = 0; i < n - 1; ++i) {
        for (let j = i + 1; j < n; ++j) {
            if ((i * j) % k === 0 && nums[i] === nums[j]) {
                ++res;
            }
        }
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn count_pairs(nums: Vec<i32>, k: i32) -> i32 {
        let n = nums.len();
        let mut res = 0;   // 符合要求数对个数
        for i in 0..n - 1 {
            for j in i + 1..n {
                if (i * j) % k as usize == 0 && nums[i] == nums[j] {
                    res += 1;
                }
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 为 $nums$ 数组的长度。即为遍历数对并统计符合要求个数的时间复杂度。
- 空间复杂度：$O(1)$。
