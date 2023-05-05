﻿#### [滑动窗口，简洁写法（Python/Java/C++/Go）](https://leetcode.cn/problems/maximum-fruits-harvested-after-at-most-k-steps/solutions/2254860/hua-dong-chuang-kou-jian-ji-xie-fa-pytho-1c2d/)

#### 前置知识

[同向双指针（滑动窗口）【基础算法精讲 01】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1hd4y1r7Gq%2F)

[二分查找【基础算法精讲 04】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1AP41137w7%2F)

> APP 用户如果无法打开，可以分享到微信。

#### 思路

由于只能一步步地走，人移动的范围必然是一段连续的区间。

如果反复左右移动，会白白浪费移动次数，所以最优方案要么先向右再向左，要么先向左再向右（或者向一个方向走到底）。

设向左走最远可以到达 $fruits[left][0]$，这可以用枚举或者二分查找得出，其中 $left$ 是最小的满足

$$fruits[left][0] \ge startPos - k$$

的下标。

假设位置不超过 $startPos$ 的最近水果在 $fruits[right][0]$，那么当 $right$ 增加时，$left$ 不可能减少，有单调性，因此可以用同向双指针（滑动窗口）解决。不了解的同学可以先看上面的视频讲解。

如何判断 $left$ 是否需要增加呢？

如果先向右再向左，那么移动距离为

$$(fruits[right][0] - startPos) + (fruits[right][0] - fruits[left][0])$$

如果先向左再向右，那么移动距离为

$$(startPos - fruits[left][0]) + (fruits[right][0] - fruits[left][0])$$

如果上面两个式子均大于 $k$，就说明 $fruits[left][0]$ 太远了，需要增加 $left$。

对于 $right$，它必须小于 $n$，且满足

$$fruits[right][0] \le startPos + k$$

移动 $left$ 和 $right$ 的同时，维护窗口内的水果数量 $s$，同时用 $s$ 更新答案的最大值。

```python
class Solution:
    def maxTotalFruits(self, fruits: List[List[int]], startPos: int, k: int) -> int:
        left = bisect_left(fruits, [startPos - k])  # 向左最远能到 fruits[left][0]
        right = bisect_left(fruits, [startPos + 1])  # startPos 右边最近水果（因为下面求的是左闭右开区间）
        ans = s = sum(c for _, c in fruits[left:right])  # 从 fruits[left][0] 到 startPos 的水果数
        while right < len(fruits) and fruits[right][0] <= startPos + k:
            s += fruits[right][1]  # 枚举最右位置为 fruits[right][0]
            while fruits[right][0] * 2 - fruits[left][0] - startPos > k and \
                  fruits[right][0] - fruits[left][0] * 2 + startPos > k:
                s -= fruits[left][1]  # fruits[left][0] 无法到达
                left += 1
            ans = max(ans, s)  # 更新答案最大值
            right += 1  # 继续枚举下一个最右位置
        return ans
```

```java
class Solution {
    public int maxTotalFruits(int[][] fruits, int startPos, int k) {
        int left = lowerBound(fruits, startPos - k); // 向左最远能到 fruits[left][0]
        int right = left, s = 0, n = fruits.length;
        for (; right < n && fruits[right][0] <= startPos; right++)
            s += fruits[right][1]; // 从 fruits[left][0] 到 startPos 的水果数
        int ans = s;
        for (; right < n && fruits[right][0] <= startPos + k; right++) {
            s += fruits[right][1]; // 枚举最右位置为 fruits[right][0]
            while (fruits[right][0] * 2 - fruits[left][0] - startPos > k &&
                   fruits[right][0] - fruits[left][0] * 2 + startPos > k)
                s -= fruits[left++][1]; // fruits[left][0] 无法到达
            ans = Math.max(ans, s); // 更新答案最大值
        }
        return ans;
    }

    // 见 https://www.bilibili.com/video/BV1AP41137w7/
    private int lowerBound(int[][] fruits, int target) {
        int left = -1, right = fruits.length; // 开区间 (left, right)
        while (left + 1 < right) { // 开区间不为空
            // 循环不变量：
            // fruits[left][0] < target
            // fruits[right][0] >= target
            int mid = (left + right) >>> 1;
            if (fruits[mid][0] < target)
                left = mid; // 范围缩小到 (mid, right)
            else
                right = mid; // 范围缩小到 (left, mid)
        }
        return right;
    }
}
```

```cpp
class Solution {
public:
    int maxTotalFruits(vector<vector<int>> &fruits, int startPos, int k) {
        int left = lower_bound(fruits.begin(), fruits.end(), startPos - k, [](const auto &a, int b) {
            return a[0] < b;
        }) - fruits.begin(); // 向左最远能到 fruits[left][0]
        int right = left, s = 0, n = fruits.size();
        for (; right < n && fruits[right][0] <= startPos; ++right)
            s += fruits[right][1]; // 从 fruits[left][0] 到 startPos 的水果数
        int ans = s;
        for (; right < n && fruits[right][0] <= startPos + k; ++right) {
            s += fruits[right][1]; // 枚举最右位置为 fruits[right][0]
            while (fruits[right][0] * 2 - fruits[left][0] - startPos > k &&
                   fruits[right][0] - fruits[left][0] * 2 + startPos > k)
                s -= fruits[left++][1]; // fruits[left][0] 无法到达
            ans = max(ans, s); // 更新答案最大值
        }
        return ans;
    }
};
```

```go
func maxTotalFruits(fruits [][]int, startPos, k int) int {
    n := len(fruits)
    // 向左最远能到 fruits[left][0]
    left := sort.Search(n, func(i int) bool { return fruits[i][0] >= startPos-k })
    right, s := left, 0
    for ; right < n && fruits[right][0] <= startPos; right++ {
        s += fruits[right][1] // 从 fruits[left][0] 到 startPos 的水果数
    }
    ans := s
    for ; right < n && fruits[right][0] <= startPos+k; right++ {
        s += fruits[right][1] // 枚举最右位置为 fruits[right][0]
        for fruits[right][0]*2-fruits[left][0]-startPos > k &&
            fruits[right][0]-fruits[left][0]*2+startPos > k {
            s -= fruits[left][1] // fruits[left][0] 无法到达
            left++
        }
        ans = max(ans, s) // 更新答案最大值
    }
    return ans
}

func max(a, b int) int { if a < b { return b }; return a }
```

上面的代码可以再简化一点，把第一个 for 循环合并到第二个中。

> 注：这会让第一个 for 循环增加一些无效计算，运行速度可能不如上面的写法。

```python
class Solution:
    def maxTotalFruits(self, fruits: List[List[int]], startPos: int, k: int) -> int:
        left = bisect_left(fruits, [startPos - k])  # 向左最远能到 fruits[left][0]
        ans = s = 0
        for pos, amount in fruits[left:]:
            if pos > startPos + k: break
            s += amount
            while pos * 2 - fruits[left][0] - startPos > k and \
                  pos - fruits[left][0] * 2 + startPos > k:
                s -= fruits[left][1]  # fruits[left][0] 无法到达
                left += 1
            ans = max(ans, s)  # 更新答案最大值
        return ans
```

```java
class Solution {
    public int maxTotalFruits(int[][] fruits, int startPos, int k) {
        int left = lowerBound(fruits, startPos - k); // 向左最远能到 fruits[left][0]
        int ans = 0, s = 0, n = fruits.length;
        for (int right = left; right < n && fruits[right][0] <= startPos + k; right++) {
            s += fruits[right][1]; // 枚举最右位置为 fruits[right][0]
            while (fruits[right][0] * 2 - fruits[left][0] - startPos > k &&
                    fruits[right][0] - fruits[left][0] * 2 + startPos > k)
                s -= fruits[left++][1]; // fruits[left][0] 无法到达
            ans = Math.max(ans, s); // 更新答案最大值
        }
        return ans;
    }

    // 见 https://www.bilibili.com/video/BV1AP41137w7/
    private int lowerBound(int[][] fruits, int target) {
        int left = -1, right = fruits.length; // 开区间 (left, right)
        while (left + 1 < right) { // 开区间不为空
            // 循环不变量：
            // fruits[left][0] < target
            // fruits[right][0] >= target
            int mid = (left + right) >>> 1;
            if (fruits[mid][0] < target)
                left = mid; // 范围缩小到 (mid, right)
            else
                right = mid; // 范围缩小到 (left, mid)
        }
        return right;
    }
}
```

```cpp
class Solution {
public:
    int maxTotalFruits(vector<vector<int>> &fruits, int startPos, int k) {
        int left = lower_bound(fruits.begin(), fruits.end(), startPos - k, [](const auto &a, int b) {
            return a[0] < b;
        }) - fruits.begin(); // 向左最远能到 fruits[left][0]
        int ans = 0, s = 0, n = fruits.size();
        for (int right = left; right < n && fruits[right][0] <= startPos + k; ++right) {
            s += fruits[right][1]; // 枚举最右位置为 fruits[right][0]
            while (fruits[right][0] * 2 - fruits[left][0] - startPos > k &&
                   fruits[right][0] - fruits[left][0] * 2 + startPos > k)
                s -= fruits[left++][1]; // fruits[left][0] 无法到达
            ans = max(ans, s); // 更新答案最大值
        }
        return ans;
    }
};
```

```go
func maxTotalFruits(fruits [][]int, startPos, k int) (ans int) {
    n := len(fruits)
    // 向左最远能到 fruits[left][0]
    left := sort.Search(n, func(i int) bool { return fruits[i][0] >= startPos-k })
    for right, s := left, 0; right < n && fruits[right][0] <= startPos+k; right++ {
        s += fruits[right][1] // 枚举最右位置为 fruits[right][0]
        for fruits[right][0]*2-fruits[left][0]-startPos > k &&
            fruits[right][0]-fruits[left][0]*2+startPos > k {
            s -= fruits[left][1] // fruits[left][0] 无法到达
            left++
        }
        ans = max(ans, s) // 更新答案最大值
    }
    return
}

func max(a, b int) int { if a < b { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(n)$，其中 $n$ 为 $fruits$ 的长度。虽然写了个二重循环，但是内层循环中对 $left$ 加一的**总**执行次数不会超过 $n$ 次，所以总的时间复杂度为 $\mathcal{O}(n)$。
-   空间复杂度：$\mathcal{O}(1)$。仅用到若干额外变量。

#### 强化训练

-   [3\. 无重复字符的最长子串](https://leetcode.cn/problems/longest-substring-without-repeating-characters/)，[题解](https://leetcode.cn/problems/longest-substring-without-repeating-characters/solutions/1959540/xia-biao-zong-suan-cuo-qing-kan-zhe-by-e-iaks/)
-   [209\. 长度最小的子数组](https://leetcode.cn/problems/minimum-size-subarray-sum/)，[题解](https://leetcode.cn/problems/minimum-size-subarray-sum/solutions/1959532/biao-ti-xia-biao-zong-suan-cuo-qing-kan-k81nh/)
-   [713\. 乘积小于 K 的子数组](https://leetcode.cn/problems/subarray-product-less-than-k/)，[题解](https://leetcode.cn/problems/subarray-product-less-than-k/solutions/1959538/xia-biao-zong-suan-cuo-qing-kan-zhe-by-e-jebq/)
-   [1004\. 最大连续 1 的个数 III](https://leetcode.cn/problems/max-consecutive-ones-iii/)，[题解](https://leetcode.cn/problems/max-consecutive-ones-iii/solution/hua-dong-chuang-kou-yi-ge-shi-pin-jiang-yowmi/)
-   [1234\. 替换子串得到平衡字符串](https://leetcode.cn/problems/replace-the-substring-for-balanced-string/)，[题解](https://leetcode.cn/problems/replace-the-substring-for-balanced-string/solution/tong-xiang-shuang-zhi-zhen-hua-dong-chua-z7tu/)
-   [1658\. 将 x 减到 0 的最小操作数](https://leetcode.cn/problems/minimum-operations-to-reduce-x-to-zero/)，[题解](https://leetcode.cn/problems/minimum-operations-to-reduce-x-to-zero/solution/ni-xiang-si-wei-pythonjavacgo-by-endless-b4jt/)
