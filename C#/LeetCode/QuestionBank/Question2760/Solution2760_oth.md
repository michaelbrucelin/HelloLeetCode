### [教你一次性把代码写对！O(n) 分组循环（Python/Java/C++/Go/JS/Rust）](https://leetcode.cn/problems/longest-even-odd-subarray-with-threshold/solutions/2528771/jiao-ni-yi-ci-xing-ba-dai-ma-xie-dui-on-zuspx/)

#### 分组循环

**适用场景**：按照题目要求，数组会被分割成若干组，且每一组的判断/处理逻辑是一样的。

**核心思想**：

-   外层循环负责遍历组之前的准备工作（记录开始位置），和遍历组之后的统计工作（更新答案最大值）。
-   内层循环负责遍历组，找出这一组在哪结束。

这个写法的好处是，各个逻辑块分工明确，也不需要特判最后一组（易错点）。以我的经验，这个写法是所有写法中最不容易出 bug 的，推荐大家记住。

时间复杂度乍一看是 $\mathcal{O}(n^2)$，但注意变量 $i$ 只会增加，不会重置也不会减少。所以二重循环总共循环 $\mathcal{O}(n)$ 次，所以时间复杂度是 $\mathcal{O}(n)$。

```python
class Solution:
    def longestAlternatingSubarray(self, nums: List[int], threshold: int) -> int:
        n = len(nums)
        ans = i = 0
        while i < n:
            if nums[i] > threshold or nums[i] % 2:
                i += 1  # 直接跳过
                continue
            start = i  # 记录这一组的开始位置
            i += 1  # 开始位置已经满足要求，从下一个位置开始判断
            while i < n and nums[i] <= threshold and nums[i] % 2 != nums[i - 1] % 2:
                i += 1
            # 从 start 到 i-1 是满足题目要求的子数组
            ans = max(ans, i - start)
        return ans
```

```java
public class Solution {
    public int longestAlternatingSubarray(int[] nums, int threshold) {
        int n = nums.length;
        int ans = 0, i = 0;
        while (i < n) {
            if (nums[i] > threshold || nums[i] % 2 != 0) {
                i++; // 直接跳过
                continue;
            }
            int start = i; // 记录这一组的开始位置
            i++; // 开始位置已经满足要求，从下一个位置开始判断
            while (i < n && nums[i] <= threshold && nums[i] % 2 != nums[i - 1] % 2) {
                i++;
            }
            // 从 start 到 i-1 是满足题目要求的子数组
            ans = Math.max(ans, i - start);
        }
        return ans;
    }
}
```

```c++
class Solution {
public:
    int longestAlternatingSubarray(vector<int> &nums, int threshold) {
        int n = nums.size();
        int ans = 0, i = 0;
        while (i < n) {
            if (nums[i] > threshold || nums[i] % 2) {
                i++; // 直接跳过
                continue;
            }
            int start = i; // 记录这一组的开始位置
            i++; // 开始位置已经满足要求，从下一个位置开始判断
            while (i < n && nums[i] <= threshold && nums[i] % 2 != nums[i - 1] % 2) {
                i++;
            }
            // 从 start 到 i-1 是满足题目要求的子数组
            ans = max(ans, i - start);
        }
        return ans; 
    }
};
```

```go
func longestAlternatingSubarray(nums []int, threshold int) (ans int) {
    n := len(nums)
    i := 0
    for i < n {
        if nums[i] > threshold || nums[i]%2 != 0 {
            i++ // 直接跳过
            continue
        }
        start := i // 记录这一组的开始位置
        i++ // 开始位置已经满足要求，从下一个位置开始判断
        for i < n && nums[i] <= threshold && nums[i]%2 != nums[i-1]%2 {
            i++
        }
        // 从 start 到 i-1 是满足题目要求的子数组
        ans = max(ans, i-start)
    }
    return ans
}
```

```javascript
var longestAlternatingSubarray = function(nums, threshold) {
    const n = nums.length;
    let ans = 0, i = 0;
    while (i < n) {
        if (nums[i] > threshold || nums[i] % 2 !== 0) {
            i++; // 直接跳过
            continue;
        }
        let start = i; // 记录这一组的开始位置
        i++; // 开始位置已经满足要求，从下一个位置开始判断
        while (i < n && nums[i] <= threshold && nums[i] % 2 !== nums[i - 1] % 2) {
            i++;
        }
        // 从 start 到 i-1 是满足题目要求的子数组
        ans = Math.max(ans, i - start);
    }
    return ans;
};
```

```rust
impl Solution {
    pub fn longest_alternating_subarray(nums: Vec<i32>, threshold: i32) -> i32 {
        let n = nums.len();
        let mut ans = 0;
        let mut i = 0;
        while i < n {
            if nums[i] > threshold || nums[i] % 2 != 0 {
                i += 1; // 直接跳过
                continue;
            }
            let start = i; // 记录这一组的开始位置
            i += 1; // 开始位置已经满足要求，从下一个位置开始判断
            while i < n && nums[i] <= threshold && nums[i] % 2 != nums[i - 1] % 2 {
                i += 1;
            }
            // 从 start 到 i-1 是满足题目要求的子数组
            ans = ans.max(i - start);
        }
        ans as i32
    }
}
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(n)$，其中 $n$ 为 $nums$ 的长度。时间复杂度乍一看是 $\mathcal{O}(n^2)$，但注意变量 $i$ 只会增加，不会重置也不会减少。所以二重循环总共循环 $\mathcal{O}(n)$ 次，所以时间复杂度是 $\mathcal{O}(n)$。
-   空间复杂度：$\mathcal{O}(1)$。仅用到若干额外变量。

#### 练习

一般来说，分组循环的模板如下（可根据题目调整）：

```c
n = len(nums)
i = 0
while i < n:
    start = i
    while i < n and ...:
        i += 1
    # 从 start 到 i-1 是一组
    # 下一组从 i 开始，无需 i += 1
```

学会一个模板是远远不够的，需要大量练习才能灵活运用。

-   [1446\. 连续字符](https://leetcode.cn/problems/consecutive-characters/)
-   [1869\. 哪种连续子字符串更长](https://leetcode.cn/problems/longer-contiguous-segments-of-ones-than-zeros/)
-   [1957\. 删除字符使字符串变好](https://leetcode.cn/problems/delete-characters-to-make-fancy-string/)
-   [2038\. 如果相邻两个颜色均相同则删除当前颜色](https://leetcode.cn/problems/remove-colored-pieces-if-both-neighbors-are-the-same-color/)
-   [1759\. 统计同质子字符串的数目](https://leetcode.cn/problems/count-number-of-homogenous-substrings/)
-   [2110\. 股票平滑下跌阶段的数目](https://leetcode.cn/problems/number-of-smooth-descent-periods-of-a-stock/)
-   [1578\. 使绳子变成彩色的最短时间](https://leetcode.cn/problems/minimum-time-to-make-rope-colorful/)
-   [1839\. 所有元音按顺序排布的最长子字符串](https://leetcode.cn/problems/longest-substring-of-all-vowels-in-order/)
-   [228\. 汇总区间](https://leetcode.cn/problems/summary-ranges/)
-   [2765\. 最长交替子序列](https://leetcode.cn/problems/longest-alternating-subarray/)
