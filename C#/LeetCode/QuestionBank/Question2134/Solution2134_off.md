### [最少交换次数来组合所有的 1 II](https://leetcode.cn/problems/minimum-swaps-to-group-all-1s-together-ii/solutions/1202043/zui-shao-jiao-huan-ci-shu-lai-zu-he-suo-iaghf/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：转化为统计区间内 0 的个数

**思路与算法**

我们首先统计出数组 $nums$ 中 $1$ 的个数，记为 $cnt$。这样一来，如果我们枚举交换完成之后连续 $1$ 的起始位置 $i$，那么结束位置即为 $(i+cnt-1)\bmod n$，其中 $n$ 是数组 $nums$ 的长度。

可以发现，从位置 $i$ 开始到位置 $(i+cnt-1)\bmod n$ 结束的这一段区间内，$0$ 的个数即为需要交换的次数。这是因为我们每一次交换都需要把区间内的一个 $0$ 与区间外的 $1$ 进行交换。因此最少的交换次数即为区间内 $0$ 的个数的最小值。$ $

我们有两种方法可以计算出这一段区间内 $0$ 的个数：

- 第一种方法是使用前缀和数组。我们使用数组 $pre$ 表示数组 $nums$ 中 $0$ 的个数的前缀和，即 $pre[i]$ 表示 $nums[0..i]$ 中 $0$ 的个数。那么：
    - 如果 $i<(i+cnt-1)\bmod n$，那么区间内 $0$ 的个数即为：
    $$pre[(i+cnt-1)\bmod n]-pre[i-1]$$
    - 如果 $i>(i+cnt-1)\bmod n$，那么区间内 $0$ 的个数即为：
    $$pre[(i+cnt-1)\bmod n]+(pre[n-1]-pre[i-1])$$
- 第二种方法是递增地枚举 $i$ 并实时维护区间内 $0$ 的个数。我们首先统计 $i=0$ 时区间 $[0,cnt)$ 内 $0$ 的个数，随后从 $1$ 开始递增地枚举 $i$。当起始位置从 $i-1$ 增加到 $i$ 时，$nums[i-1]$ 被从区间内移除，而 $nums[(i+cnt-1)\bmod n]$ 被加入区间内。因此如果前者为 $0$，就将 $0$ 的个数减少 $1$；如果后者为 $0$，就将 $0$ 的个数增加 $1$。

下面的代码给出的是第二种方法的实现。

**代码**

```C++
class Solution {
public:
    int minSwaps(vector<int>& nums) {
        int n = nums.size();
        int cnt = accumulate(nums.begin(), nums.end(), 0);
        if (cnt == 0) {
            return 0;
        }

        int cur = 0;
        for (int i = 0; i < cnt; ++i) {
            cur += (1 - nums[i]);
        }
        int ans = cur;
        for (int i = 1; i < n; ++i) {
            if (nums[i - 1] == 0) {
                --cur;
            }
            if (nums[(i + cnt - 1) % n] == 0) {
                ++cur;
            }
            ans = min(ans, cur);
        }
        return ans;
    }
};
```

```Python
class Solution:
    def minSwaps(self, nums: List[int]) -> int:
        n = len(nums)
        cnt = sum(nums)
        if cnt == 0:
            return 0

        cur = 0
        for i in range(cnt):
            cur += (1 - nums[i])

        ans = cur
        for i in range(1, n):
            if nums[i - 1] == 0:
                cur -= 1
            if nums[(i + cnt - 1) % n] == 0:
                cur += 1
            ans = min(ans, cur)
        return ans
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(1)$。
