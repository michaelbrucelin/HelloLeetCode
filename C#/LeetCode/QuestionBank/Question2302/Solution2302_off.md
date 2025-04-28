### [统计得分小于 K 的子数组数目](https://leetcode.cn/problems/count-subarrays-with-score-less-than-k/solutions/3646778/tong-ji-de-fen-xiao-yu-k-de-zi-shu-zu-sh-guvj/)

#### 方法一：滑动窗口

根据题目对数组分数的定义，以及 $nums$ 是正整数数组这一条件，对于子数组 $[i,j]$，当右端点 $j$ 固定时，随着左端点 $i$ 增加，子数组的和会减少，长度也会缩短，因此子数组的分数会单调递减。如果子数组 $[i,j]$ 的分数小于 $k$，由于分数单调递减，那么子数组 $[p,j],i<p \le j$ 的分数也小于 $k$。

基于以上性质，我们可以使用滑动窗口的方法求解。从 $j=0$ 开始枚举子数组的右端点，并维护一个左端点 $i$（初始值为 $0$）。对于每个 $j$：

- 扩展窗口：将 $nums[j]$ 加入当前窗口对应的子数组和 $total$。
- 收缩窗口：如果当前窗口对应的子数组分数 $total \times (j-i+1)$ 大于等于 $k$，说明子数组不符合要求，因此需要向右移动左端点 $i$，直到分数小于 $k$ 为止。
- 计算子数组数量：此时，以 $j$ 为右端点且分数小于 $k$ 的子数组的数量为 $j-i+1$，累加到最终结果 $res$。

枚举结束后，返回最终结果 $res$。

```C++
class Solution {
public:
    long long countSubarrays(vector<int>& nums, long long k) {
        int n = nums.size();
        long long res = 0, total = 0;
        for (int i = 0, j = 0; j < n; j++) {
            total += nums[j];
            while (i <= j && total * (j - i + 1) >= k) {
                total -= nums[i];
                i++;
            }
            res += j - i + 1;
        }
        return res;
    }
};
```

```Go
func countSubarrays(nums []int, k int64) int64 {
    n := len(nums)
    res, total := int64(0), int64(0)
    for i, j := 0, 0; j < n; j++ {
        total += int64(nums[j])
        for i <= j && total * int64(j - i + 1) >= k {
            total -= int64(nums[i])
            i++
        }
        res += int64(j - i + 1)
    }
    return res
}
```

```Python
class Solution:
    def countSubarrays(self, nums: List[int], k: int) -> int:
        n = len(nums)
        res, total = 0, 0
        i = 0
        for j in range(n):
            total += nums[j]
            while i <= j and total * (j - i + 1) >= k:
                total -= nums[i]
                i += 1
            res += j - i + 1
        return res
```

```Java
class Solution {
    public long countSubarrays(int[] nums, long k) {
        int n = nums.length;
        long res = 0, total = 0;
        for (int i = 0, j = 0; j < n; j++) {
            total += nums[j];
            while (i <= j && total * (j - i + 1) >= k) {
                total -= nums[i];
                i++;
            }
            res += j - i + 1;
        }
        return res;
    }
}
```

```JavaScript
var countSubarrays = function(nums, k) {
    let n = nums.length;
    let res = 0, total = 0;
    for (let i = 0, j = 0; j < n; j++) {
        total += nums[j];
        while (i <= j && total * (j - i + 1) >= k) {
            total -= nums[i];
            i++;
        }
        res += j - i + 1;
    }
    return res;
};
```

```TypeScript
function countSubarrays(nums: number[], k: number): number {
    let n = nums.length;
    let res = 0, total = 0;
    for (let i = 0, j = 0; j < n; j++) {
        total += nums[j];
        while (i <= j && total * (j - i + 1) >= k) {
            total -= nums[i];
            i++;
        }
        res += j - i + 1;
    }
    return res;
}
```

```CSharp
public class Solution {
    public long CountSubarrays(int[] nums, long k) {
        int n = nums.Length;
        long res = 0, total = 0;
        for (int i = 0, j = 0; j < n; j++) {
            total += nums[j];
            while (i <= j && total * (j - i + 1) >= k) {
                total -= nums[i];
                i++;
            }
            res += j - i + 1;
        }
        return res;
    }
}
```

```C
long long countSubarrays(int *nums, int numsSize, long long k) {
    int n = numsSize;
    long long res = 0, total = 0;
    for (int i = 0, j = 0; j < n; j++) {
        total += nums[j];
        while (i <= j && total * (j - i + 1) >= k) {
            total -= nums[i];
            i++;
        }
        res += j - i + 1;
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn count_subarrays(nums: Vec<i32>, k: i64) -> i64 {
        let n = nums.len();
        let mut res = 0;
        let mut total = 0;
        let mut i = 0;
        for j in 0..n {
            total += nums[j] as i64;
            while i <= j && total * (j - i + 1) as i64 >= k {
                total -= nums[i] as i64;
                i += 1;
            }
            res += j - i + 1;
        }
        res as i64
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(1)$。
