### [访问数组中的位置使分数最大](https://leetcode.cn/problems/visit-array-positions-to-maximize-score/solutions/2806895/fang-wen-shu-zu-zhong-de-wei-zhi-shi-fen-jyjg/)

#### 方法一：动态规划

**思路**

我们从左往右遍历数组，遍历到一个元素时，如果选择移动到这个位置，那么移动到这个位置所能获得的最大分数，只取决于之前的位置中：

- 最后移动的元素为偶数时得分的最大值
- 最后移动的元素为奇数时得分的最大值

只要知道这两个值，我们可以选择从偶数值位置移动过来，也可以从奇数值位置移动过来，得分加上当前数组值。当与当前位置的数组值奇偶性不同时，得分需要额外减去 $x$。两者的最大值就是移动到当前位置可以获得的最大得分。

我们可以用一个长度为 $2$ 的数组 $\textit{dp}$ 来保存刚才提到的两个值。在求出当前位置可以获得的最大得分后，更新 $\textit{dp}$。最后返回所有位置最大得分的最大值即可。

**代码**

```Python
class Solution:
    def maxScore(self, nums: List[int], x: int) -> int:
        res = nums[0]
        dp = [-inf, -inf]
        dp[nums[0] % 2] = nums[0]
        for i in range(1, len(nums)):
            parity = nums[i] % 2
            cur = max(dp[parity] + nums[i], dp[1 - parity] - x + nums[i])
            res = max(res, cur)
            dp[parity] = max(dp[parity], cur)
        return res
```

```Java
class Solution {
    public long maxScore(int[] nums, int x) {
        long res = nums[0];
        long[] dp = {Integer.MIN_VALUE, Integer.MIN_VALUE};
        dp[nums[0] % 2] = nums[0];
        for (int i = 1; i < nums.length; i++) {
            int parity = (int) (nums[i] % 2);
            long cur = Math.max(dp[parity] + nums[i], dp[1 - parity] - x + nums[i]);
            res = Math.max(res, cur);
            dp[parity] = Math.max(dp[parity], cur);
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public long MaxScore(int[] nums, int x) {
        long res = nums[0];
        long[] dp = {int.MinValue, int.MinValue};
        dp[nums[0] % 2] = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            int parity = (int) (nums[i] % 2);
            long cur = Math.Max(dp[parity] + nums[i], dp[1 - parity] - x + nums[i]);
            res = Math.Max(res, cur);
            dp[parity] = Math.Max(dp[parity], cur);
        }
        return res;
    }
}
```

```C++
class Solution {
public:
    long long maxScore(vector<int>& nums, int x) {
        long long res = nums[0];
        vector<long long> dp(2, INT_MIN);
        dp[nums[0] % 2] = nums[0];
        for (int i = 1; i < nums.size(); i++) {
            int parity = nums[i] % 2;
            long long cur = max(dp[parity] + nums[i], dp[1 - parity] - x + nums[i]);
            res = max(res, cur);
            dp[parity] = max(dp[parity], cur);
        }
        return res;
    }
};
```

```C
long long maxScore(int* nums, int numsSize, int x){
    long long res = nums[0];
    long long dp[2] = {INT_MIN, INT_MIN};
    dp[nums[0] % 2] = nums[0];
    for (int i = 1; i < numsSize; i++) {
        int parity = nums[i] % 2;
        long long cur = fmax(dp[parity] + nums[i], dp[1 - parity] - x + nums[i]);
        res = fmax(res, cur);
        dp[parity] = fmax(dp[parity], cur);
    }
    return res;
}
```

```Go
func maxScore(nums []int, x int) int64 {
    res := int64(nums[0])
    dp := [2]int64{math.MinInt32, math.MinInt32}
    dp[nums[0] % 2] = int64(nums[0])
    for i := 1; i < len(nums); i++ {
        parity := nums[i] % 2
        cur := max(dp[parity] + int64(nums[i]), dp[1 - parity] - int64(x) + int64(nums[i]))
        res = max(res, cur)
        dp[parity] = max(dp[parity], cur)
    }
    return res
}
```

```JavaScript
var maxScore = function(nums, x) {
    let res = nums[0];
    let dp = [-Infinity, -Infinity];
    dp[nums[0] % 2] = nums[0];
    for (let i = 1; i < nums.length; i++) {
        let parity = nums[i] % 2;
        let cur = Math.max(dp[parity] + nums[i], dp[1 - parity] - x + nums[i]);
        res = Math.max(res, cur);
        dp[parity] = Math.max(dp[parity], cur);
    }
    return res;
};
```

```TypeScript
function maxScore(nums: number[], x: number): number {
    let res = nums[0];
    let dp = [-Infinity, -Infinity];
    dp[nums[0] % 2] = nums[0];
    for (let i = 1; i < nums.length; i++) {
        let parity = nums[i] % 2;
        let cur = Math.max(dp[parity] + nums[i], dp[1 - parity] - x + nums[i]);
        res = Math.max(res, cur);
        dp[parity] = Math.max(dp[parity], cur);
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn max_score(nums: Vec<i32>, x: i32) -> i64 {
        let mut res = nums[0] as i64;
        let mut dp: Vec<i64> = vec![i32::MIN as i64, i32::MIN as i64];
        dp[(nums[0] % 2) as usize] = nums[0] as i64;
        for i in 1..nums.len() {
            let parity = (nums[i] % 2) as usize;
            let cur = (dp[parity] + nums[i] as i64).max(dp[1 - parity] - x as i64 + nums[i] as i64);
            res = res.max(cur);
            dp[parity] = dp[parity].max(cur);
        }
        return res;
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $\textit{nums}$ 的长度。
- 空间复杂度：$O(1)$。
