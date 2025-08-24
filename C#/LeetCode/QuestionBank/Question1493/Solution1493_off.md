### [删掉一个元素以后全为 $1$ 的最长子数组](https://leetcode.cn/problems/longest-subarray-of-1s-after-deleting-one-element/solutions/327132/shan-diao-yi-ge-yuan-su-yi-hou-quan-wei-1-de-zui-c/)

#### 方法一：递推

**思路**

在删掉元素的结果数组中，最长的且只包含 $1$ 的非空子数组存在两种情况：

- 这个子数组在原数组中本身就是连续的，无论删或者不删其他的元素，它都是最长的且只包含 $1$ 的非空子数组；
- 这个子数组原本不连续，而是两个连续的全 $1$ 子数组，中间夹着一个 $0$，把这个 $0$ 删掉以后，左右两个子数组组合成一个最长的且只包含 $1$ 的非空子数组。

我们可以枚举被删除的位置，假设下标为 $i$，我们希望知道「以第 $i-1$ 位结尾的最长连续全 $1$ 子数组」和「以第 $i+1$ 位开头的最长连续全 $1$ 子数组」的长度分别是多少，这两个量的和就是删除第 $i$ 位之后最长的且只包含 $1$ 的非空子数组的长度。假设我们可以得到这两个量，我们只要枚举所有的 $i$，就可以得到最终的答案。

我们可以这样维护「以第 $i-1$ 位结尾的最长连续全 $1$ 子数组」和「以第 $i+1$ 位开头的最长连续全 $1$ 子数组」的长度：

- 记原数组为 $a$
- 记 $pre(i)$ 为「以第 $i$ 位结尾的最长连续全 $1$ 子数组」，那么
    $$pre(i)=\begin{cases}0, & a_i=0 \\ pre(i-1)+1, & a_i=1\end{cases}$$
- 记 $suf(i)$ 为「以第 $i$ 位开头的最长连续全 $1$ 子数组」，那么
    $$suf(i)=\begin{cases}0, & a_i=0 \\ suf(i+1)+1, & a_i=1\end{cases}$$

我们可以对原数组做一次正向遍历，预处理出 $pre$，再做一次反向遍历，预处理出 $suf$。最后我们枚举所有的元素作为待删除的元素，计算出删除这些元素之后最长的且只包含 $1$ 的非空子数组的长度，比较并取最大值。

代码如下。

**算法**

```C++
class Solution {
public:
    int longestSubarray(vector<int>& nums) {
        int n = nums.size();

        vector<int> pre(n), suf(n);

        pre[0] = nums[0];
        for (int i = 1; i < n; ++i) {
            pre[i] = nums[i] ? pre[i - 1] + 1 : 0; 
        }

        suf[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; --i) {
            suf[i] = nums[i] ? suf[i + 1] + 1 : 0;
        }

        int ans = 0;
        for (int i = 0; i < n; ++i) {
            int preSum = i == 0 ? 0 : pre[i - 1];
            int sufSum = i == n - 1 ? 0 : suf[i + 1];
            ans = max(ans, preSum + sufSum);
        }

        return ans;
    }
};
```

```Java
class Solution {
    public int longestSubarray(int[] nums) {
        int n = nums.length;

        int[] pre = new int[n];
        int[] suf = new int[n];

        pre[0] = nums[0];
        for (int i = 1; i < n; ++i) {
            pre[i] = nums[i] != 0 ? pre[i - 1] + 1 : 0; 
        }

        suf[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; --i) {
            suf[i] = nums[i] != 0 ? suf[i + 1] + 1 : 0;
        }

        int ans = 0;
        for (int i = 0; i < n; ++i) {
            int preSum = i == 0 ? 0 : pre[i - 1];
            int sufSum = i == n - 1 ? 0 : suf[i + 1];
            ans = Math.max(ans, preSum + sufSum);
        }

        return ans;
    }
}
```

```Python
class Solution:
    def longestSubarray(self, nums: List[int]) -> int:
        n = len(nums)
        pre = [0] * n
        suf = [0] * n
        pre[0] = nums[0]
        for i in range(1, n):
            pre[i] = pre[i - 1] + 1 if nums[i] else 0
        suf[-1] = nums[-1]
        for i in range(n - 2, -1, -1):
            suf[i] = suf[i + 1] + 1 if nums[i] else 0

        ans = 0
        for i in range(n):
            pre_sum = pre[i - 1] if i > 0 else 0
            suf_sum = suf[i + 1] if i < n - 1 else 0
            ans = max(ans, pre_sum + suf_sum)

        return ans
```

```CSharp
public class Solution {
    public int LongestSubarray(int[] nums) {
        int n = nums.Length;
        int[] pre = new int[n];
        int[] suf = new int[n];
        pre[0] = nums[0];
        for (int i = 1; i < n; ++i) {
            pre[i] = nums[i] != 0 ? pre[i - 1] + 1 : 0;
        }
        suf[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; --i) {
            suf[i] = nums[i] != 0 ? suf[i + 1] + 1 : 0;
        }
        
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            int preSum = i == 0 ? 0 : pre[i - 1];
            int sufSum = i == n - 1 ? 0 : suf[i + 1];
            ans = Math.Max(ans, preSum + sufSum);
        }
        return ans;
    }
}
```

```Go
func longestSubarray(nums []int) int {
    n := len(nums)
    pre := make([]int, n)
    suf := make([]int, n)
    pre[0] = nums[0]
    for i := 1; i < n; i++ {
        if nums[i] != 0 {
            pre[i] = pre[i - 1] + 1
        } else {
            pre[i] = 0
        }
    }
    suf[n - 1] = nums[n - 1]
    for i := n - 2; i >= 0; i-- {
        if nums[i] != 0 {
            suf[i] = suf[i + 1] + 1
        } else {
            suf[i] = 0
        }
    }

    ans := 0
    for i := 0; i < n; i++ {
        preSum := 0
        if i != 0 {
            preSum = pre[i - 1]
        }
        sufSum := 0
        if i != n - 1 {
            sufSum = suf[i + 1]
        }
        if preSum + sufSum > ans {
            ans = preSum + sufSum
        }
    }

    return ans
}
```

```C
int longestSubarray(int* nums, int numsSize) {
    int* pre = (int*)malloc(numsSize * sizeof(int));
    int* suf = (int*)malloc(numsSize * sizeof(int));
    pre[0] = nums[0];
    for (int i = 1; i < numsSize; ++i) {
        pre[i] = nums[i] ? pre[i - 1] + 1 : 0;
    }
    suf[numsSize - 1] = nums[numsSize - 1];
    for (int i = numsSize - 2; i >= 0; --i) {
        suf[i] = nums[i] ? suf[i + 1] + 1 : 0;
    }

    int ans = 0;
    for (int i = 0; i < numsSize; ++i) {
        int preSum = i == 0 ? 0 : pre[i - 1];
        int sufSum = i == numsSize - 1 ? 0 : suf[i + 1];
        ans = fmax(ans, preSum + sufSum);
    }
    free(pre);
    free(suf);

    return ans;
}
```

```JavaScript
var longestSubarray = function(nums) {
    const n = nums.length;
    const pre = new Array(n);
    const suf = new Array(n);
    pre[0] = nums[0];
    for (let i = 1; i < n; ++i) {
        pre[i] = nums[i] ? pre[i - 1] + 1 : 0;
    }
    suf[n - 1] = nums[n - 1];
    for (let i = n - 2; i >= 0; --i) {
        suf[i] = nums[i] ? suf[i + 1] + 1 : 0;
    }

    let ans = 0;
    for (let i = 0; i < n; ++i) {
        const preSum = i === 0 ? 0 : pre[i - 1];
        const sufSum = i === n - 1 ? 0 : suf[i + 1];
        ans = Math.max(ans, preSum + sufSum);
    }

    return ans;
};
```

```TypeScript
function longestSubarray(nums: number[]): number {
    const n = nums.length;
    const pre: number[] = new Array(n);
    const suf: number[] = new Array(n);
    pre[0] = nums[0];
    for (let i = 1; i < n; ++i) {
        pre[i] = nums[i] ? pre[i - 1] + 1 : 0;
    }
    suf[n - 1] = nums[n - 1];
    for (let i = n - 2; i >= 0; --i) {
        suf[i] = nums[i] ? suf[i + 1] + 1 : 0;
    }

    let ans = 0;
    for (let i = 0; i < n; ++i) {
        const preSum = i === 0 ? 0 : pre[i - 1];
        const sufSum = i === n - 1 ? 0 : suf[i + 1];
        ans = Math.max(ans, preSum + sufSum);
    }

    return ans;
}
```

```Rust
impl Solution {
    pub fn longest_subarray(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut pre = vec![0; n];
        let mut suf = vec![0; n];
        pre[0] = nums[0];
        for i in 1..n {
            pre[i] = if nums[i] != 0 { pre[i - 1] + 1 } else { 0 };
        }
        suf[n - 1] = nums[n - 1];
        for i in (0..n - 1).rev() {
            suf[i] = if nums[i] != 0 { suf[i + 1] + 1 } else { 0 };
        }
        
        let mut ans = 0;
        for i in 0..n {
            let pre_sum = if i == 0 { 0 } else { pre[i - 1] };
            let suf_sum = if i == n - 1 { 0 } else { suf[i + 1] };
            ans = ans.max(pre_sum + suf_sum);
        }

        ans
    }
}
```

**复杂度**

假设原数组长度为 $n$。

- 时间复杂度：$O(n)$。这里对原数组进行三次遍历，每次时间代价为 $O(n)$，故渐进时间复杂度为 $O(n)$。
- 空间复杂度：$O(n)$。这里预处理 $pre$ 和 $suf$ 需要两个长度为 $n$ 的数组。

#### 方法二：递推优化

**思路**

我们也可以修改递推的方式使用一次就可以得到答案。

记 $p_0(i)$ 为「以第 $i$ 位结尾的最长连续全 $1$ 子数组」，与方法一中的 $pre(i)$ 相同，递推式为：

$$p_0(i)=\begin{cases}0, & a_i=0 \\ p_0(i-1)+1, & a_i=1\end{cases}$$

同时，我们记 $p_1(i)$ 为「以第 $i$ 位结尾，并且可以在某个位置删除一个 $0$ 的最长连续全 $1$ 子数组」。注意这里我们规定了只删除 $0$，而不是任意一个元素，这是因为只要数组中的元素不全为 $1$，那么删除 $1$ 就没有任何意义。$p_1(i)$ 的递推式为：

$$p_1(i)=\begin{cases}p_0(i-1), & a_i=0 \\ p_1(i-1)+1, & a_i=1\end{cases}$$

当我们遇到 $1$ 时，$p_1(i)$ 的递推式与 $p_0(i)$ 相同；而当我们遇到 $0$ 时，由于 $p_1(i)$ 允许删除一个 $0$，那么我们可以把这个 $0$ 删除，将 $p_0(i-1)$ 的值赋予 $p_1(i)$。

最后的答案即为 $p_1(i)$ 中的最大值。当遇到数组中的元素全为 $1$ 的特殊情况时，我们需要将答案减去 $1$，这是因为在这种情况下，我们不得不删除一个 $1$。注意到递推式中所有的 $p_0(i),p_1(i)$ 只和 $p_0(i-1),p_1(i-1)$ 相关，因此我们可以直接使用两个变量进行递推，减少空间复杂度。

**算法**

```C++
class Solution {
public:
    int longestSubarray(vector<int>& nums) {
        int ans = 0;
        int p0 = 0, p1 = 0;
        for (int num: nums) {
            if (num == 0) {
                p1 = p0;
                p0 = 0;
            }
            else {
                ++p0;
                ++p1;
            }
            ans = max(ans, p1);
        }
        if (ans == nums.size()) {
            --ans;
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int longestSubarray(int[] nums) {
        int ans = 0;
        int p0 = 0, p1 = 0;
        for (int num : nums) {
            if (num == 0) {
                p1 = p0;
                p0 = 0;
            } else {
                ++p0;
                ++p1;
            }
            ans = Math.max(ans, p1);
        }
        if (ans == nums.length) {
            --ans;
        }
        return ans;
    }
}
```

```Python
class Solution:
    def longestSubarray(self, nums: List[int]) -> int:
        ans = 0
        p0 = p1 = 0
        for num in nums:
            if num == 0:
                p1, p0 = p0, 0
            else:
                p0 += 1
                p1 += 1
            ans = max(ans, p1)
        if ans == len(nums):
            ans -= 1
        return ans
```

```CSharp
public class Solution {
    public int LongestSubarray(int[] nums) {
        int ans = 0;
        int p0 = 0, p1 = 0;
        foreach (int num in nums) {
            if (num == 0) {
                p1 = p0;
                p0 = 0;
            }
            else {
                ++p0;
                ++p1;
            }
            ans = Math.Max(ans, p1);
        }
        if (ans == nums.Length) {
            --ans;
        }
        return ans;
    }
}
```

```Go
func longestSubarray(nums []int) int {
    ans := 0
    p0, p1 := 0, 0
    for _, num := range nums {
        if num == 0 {
            p1 = p0
            p0 = 0
        } else {
            p0++
            p1++
        }
        if p1 > ans {
            ans = p1
        }
    }
    if ans == len(nums) {
        ans--
    }
    return ans
}
```

```C
int longestSubarray(int* nums, int numsSize) {
    int ans = 0;
    int p0 = 0, p1 = 0;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] == 0) {
            p1 = p0;
            p0 = 0;
        } else {
            ++p0;
            ++p1;
        }
        ans = fmax(ans, p1);
    }
    if (ans == numsSize) {
        --ans;
    }
    return ans;
}
```

```JavaScript
var longestSubarray = function(nums) {
    let ans = 0;
    let p0 = 0, p1 = 0;
    for (const num of nums) {
        if (num === 0) {
            p1 = p0;
            p0 = 0;
        } else {
            p0++;
            p1++;
        }
        ans = Math.max(ans, p1);
    }
    if (ans === nums.length) {
        ans--;
    }
    return ans;
};
```

```TypeScript
function longestSubarray(nums: number[]): number {
    let ans = 0;
    let p0 = 0, p1 = 0;
    for (const num of nums) {
        if (num === 0) {
            p1 = p0;
            p0 = 0;
        } else {
            p0++;
            p1++;
        }
        ans = Math.max(ans, p1);
    }
    if (ans === nums.length) {
        ans--;
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn longest_subarray(nums: Vec<i32>) -> i32 {
        let mut ans = 0;
        let mut p0 = 0;
        let mut p1 = 0;
        for &num in nums.iter() {
            if num == 0 {
                p1 = p0;
                p0 = 0;
            } else {
                p0 += 1;
                p1 += 1;
            }
            ans = ans.max(p1);
        }
        if ans == nums.len() as i32 {
            ans -= 1;
        }
        ans
    }
}
```

**复杂度**

假设原数组长度为 $n$。

- 时间复杂度：$O(n)$。这里对原数组进行一次遍历，时间代价为 $O(n)$，故渐进时间复杂度为 $O(n)$。
- 空间复杂度：$O(1)$。
