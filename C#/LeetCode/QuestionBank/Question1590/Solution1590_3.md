﻿#### [【套路】前缀和+哈希表（Python/Java/C++/Go）](https://leetcode.cn/problems/make-sum-divisible-by-p/solutions/2158435/tao-lu-qian-zhui-he-ha-xi-biao-pythonjav-rzl0/)

#### 前置知识：前缀和

对于数组 $nums$，定义它的前缀和 $s[0]=0$，$s[i+1] = \sum\limits_{j=0}^{i}nums[j]$。

例如 $nums=[1,2,-1,2]$，对应的前缀和数组为 $s=[0,1,3,2,4]$。

通过前缀和，我们可以把**子数组的元素和转换成两个前缀和的差**，即

$$\sum_{j=left}^{right}nums[j] = \sum\limits_{j=0}^{right}nums[j] - \sum\limits_{j=0}^{left-1}nums[j] = s[right+1] - s[left]$$

例如 $nums$ 的子数组 $[2,-1,2]$ 的和就可以用 $s[4]-s[1]=4-1=3$ 算出来。

> 注：为方便计算，常用左闭右开区间 $[left,right)$ 来表示从 $nums[left]$ 到 $nums[right-1]$ 的子数组，此时子数组的和为 $s[right] - s[left]$，子数组的长度为 $right-left$。
> 
> 注 2：$s[0]=0$ 表示一个空数组的元素和。为什么要额外定义它？想一想，如果要计算的子数组恰好是一个前缀（从 $nums[0]$ 开始），你要用 $s[right]$ 减去谁呢？通过定义 $s[0]=0$，任意子数组（包括前缀）都可以表示为两个前缀和的差。

#### 前置知识：同余

两个数 $x$ 和 $y$，如果 $(x-y) \bmod p = 0$，则称 $x$ 与 $y$ 对模 $p$ 同余，记作

$$x\equiv y \pmod p$$

例如 $42\equiv 12 \pmod {10}$，$-17\equiv 3 \pmod {10}$。

#### 前置知识：处理取模的小技巧

如果 $x$ 和 $y$ 均为非负数，则 $x\equiv y \pmod p$ 相当于

$$x\bmod p = y\bmod p$$

如果 $x<0$，$y \ge 0$，则 $x \equiv y \pmod p$ 相当于

$$x\bmod p + p = y\bmod p$$

例如 $-17\bmod 10 +10 = -7+10=3$。

为了避免判断 $x$ 是否为负数，等号左边可以写成

$$(x\bmod p + p) \bmod p$$

这样无论 $x$ 是否为负数，最终都会落在区间 $[0,p)$ 中。

> 注：Python 用户可以忽略，取模运算会保证结果非负。

#### 提示 1

例如 $nums=[11,2,5,7,8,9]$，$p=10$，那么把 $[5,7]$ 去掉，剩余的数字相加等于 $30$，可以被 $p$ 整除。

所有元素的和 $42\bmod 10=2$，而 $(5+7)\bmod 10$ 也等于 $2$。

设所有元素的和为 $x$，去掉的元素和为 $y$。要使 $x-y$ 能被 $p$ 整除，这等价于满足

$$y \equiv x \pmod p$$

#### 提示 2

通过前缀和，问题转换成：在前缀和数组上找到两个数 $s[left]$ 和 $s[right]$，满足 $right-left$ 最小且

$$s[right]-s[left]\equiv x \pmod p$$

移项得

$$s[right]-x \equiv s[left]\pmod p$$

例如 $[11,2,5,7,8,9]$ 的前缀和 $s=[0,11,13,18,25,33,42]$，其中 $25-13\equiv 2 \pmod {10}$，$25-2\equiv 13 \pmod {10}$。

根据「处理取模的小技巧」，上式相当于

$$((s[right]-x)\bmod p+p)\bmod p= s[left]\bmod p$$

也可以写成

$$(s[right]\bmod p-x\bmod p+p)\bmod p= s[left]\bmod p$$

#### 提示 3

遍历 $s$ 的同时，用哈希表 $last$ 记录 $s[i]\bmod p$ 最近一次出现的下标，如果 $last$ 中包含 $(s[i]\bmod p-x\bmod p+p)\bmod p$，设其对应的下标为 $j$，那么 $[j,i)$ 是一个符合题目要求的子数组。

枚举所有 $i$，计算符合要求的子数组长度的最小值，就是答案。如果没有符合要求的子数组，则返回 $-1$。

代码实现时，可以把答案初始化成 $nums$ 的长度 $n$。如果最后答案等于 $n$，则表示没有符合要求的子数组，因为题目不允许将整个数组都移除。

#### 答疑

**问**：为什么不能用双指针做？

**答**：使用双指针需要满足单调性，但是 $s[i]\bmod p$ 并不是单调的，所以不能用双指针。具体请看[【基础算法精讲 01】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1hd4y1r7Gq%2F)。

```python
class Solution:
    def minSubarray(self, nums: List[int], p: int) -> int:
        s = list(accumulate(nums, initial=0))
        x = s[-1] % p
        if x == 0: return 0  # 移除空子数组（这行可以不要）

        ans = n = len(nums)
        last = {}
        for i, v in enumerate(s):
            last[v % p] = i
            j = last.get((v - x) % p, -n)  # 如果不存在，-n 可以保证 i-j >= n
            ans = min(ans, i - j)
        return ans if ans < n else -1
```

```java
class Solution {
    public int minSubarray(int[] nums, int p) {
        int n = nums.length, ans = n;
        var s = new int[n + 1];
        for (int i = 0; i < n; ++i)
            s[i + 1] = (s[i] + nums[i]) % p;
        int x = s[n];
        if (x == 0) return 0; // 移除空子数组（这行可以不要）

        var last = new HashMap<Integer, Integer>();
        for (int i = 0; i <= n; ++i) {
            last.put(s[i], i);
            // 如果不存在，-n 可以保证 i-j >= n
            int j = last.getOrDefault((s[i] - x + p) % p, -n);
            ans = Math.min(ans, i - j);
        }
        return ans < n ? ans : -1;
    }
}
```

```cpp
class Solution {
public:
    int minSubarray(vector<int> &nums, int p) {
        int n = nums.size(), ans = n, s[n + 1];
        s[0] = 0;
        for (int i = 0; i < n; ++i)
            s[i + 1] = (s[i] + nums[i]) % p;
        int x = s[n];
        if (x == 0) return 0; // 移除空子数组（这行可以不要）

        unordered_map<int, int> last;
        for (int i = 0; i <= n; ++i) {
            last[s[i]] = i;
            auto it = last.find((s[i] - x + p) % p);
            if (it != last.end())
                ans = min(ans, i - it->second);
        }
        return ans < n ? ans : -1;
    }
};
```

```go
func minSubarray(nums []int, p int) int {
    n := len(nums)
    s := make([]int, n+1)
    for i, v := range nums {
        s[i+1] = (s[i] + v) % p
    }
    x := s[n]
    if x == 0 {
        return 0 // 移除空子数组（这个 if 可以不要）
    }

    ans := n
    last := map[int]int{}
    for i, v := range s {
        last[v] = i
        if j, ok := last[(v-x+p)%p]; ok {
            ans = min(ans, i-j)
        }
    }
    if ans < n {
        return ans
    }
    return -1
}

func min(a, b int) int { if b < a { return b }; return a }
```

也可以不用前缀和数组，一边遍历 $nums$ 一边计算前缀和。

```python
class Solution:
    def minSubarray(self, nums: List[int], p: int) -> int:
        x = sum(nums) % p
        if x == 0: return 0  # 移除空子数组（这行可以不要）

        ans = n = len(nums)
        s = 0
        last = {s: -1}  # 由于下面 i 是从 0 开始的，前缀和下标就要从 -1 开始了
        for i, v in enumerate(nums):
            s += v
            last[s % p] = i
            j = last.get((s - x) % p, -n)  # 如果不存在，-n 可以保证 i-j >= n
            ans = min(ans, i - j)  # 改成手写 min 会再快一些
        return ans if ans < n else -1
```

```java
class Solution {
    public int minSubarray(int[] nums, int p) {
        long t = 0;
        for (int v : nums) t += v;
        int x = (int) (t % p);
        if (x == 0) return 0; // 移除空子数组（这行可以不要）

        int n = nums.length, ans = n, s = 0;
        var last = new HashMap<Integer, Integer>(); // 注：填入 n+1 可以加速
        last.put(s, -1); // 由于下面 i 是从 0 开始的，前缀和下标就要从 -1 开始了
        for (int i = 0; i < n; ++i) {
            s = (s + nums[i]) % p;
            last.put(s, i);
            // 如果不存在，-n 可以保证 i-j >= n
            int j = last.getOrDefault((s - x + p) % p, -n);
            ans = Math.min(ans, i - j);
        }
        return ans < n ? ans : -1;
    }
}
```

```cpp
class Solution {
public:
    int minSubarray(vector<int> &nums, int p) {
        int x = accumulate(nums.begin(), nums.end(), 0LL) % p;
        if (x == 0) return 0; // 移除空子数组（这行可以不要）

        int n = nums.size(), ans = n, s = 0;
         // 由于下面 i 是从 0 开始的，前缀和下标就要从 -1 开始了
        unordered_map<int, int> last{{s, -1}};
        for (int i = 0; i < n; ++i) {
            s = (s + nums[i]) % p;
            last[s] = i;
            auto it = last.find((s - x + p) % p);
            if (it != last.end())
                ans = min(ans, i - it->second);
        }
        return ans < n ? ans : -1;
    }
};
```

```go
func minSubarray(nums []int, p int) int {
    x := 0
    for _, v := range nums {
        x += v
    }
    x %= p
    if x == 0 {
        return 0 // 移除空子数组（这个 if 可以不要）
    }

    n := len(nums)
    ans, s := n, 0
    // 由于下面 i 是从 0 开始的，前缀和下标就要从 -1 开始了
    last := map[int]int{s: -1}
    for i, v := range nums {
        s += v
        last[s%p] = i
        if j, ok := last[(s-x+p)%p]; ok {
            ans = min(ans, i-j)
        }
    }
    if ans < n {
        return ans
    }
    return -1
}

func min(a, b int) int { if b < a { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$O(n)$，其中 $n$ 为 $nums$ 的长度。
-   空间复杂度：$O(n)$。

#### 相似题目（前缀和+哈希表）

推荐按照顺序完成。

-   [560\. 和为 K 的子数组](https://leetcode.cn/problems/subarray-sum-equals-k/)
-   [974\. 和可被 K 整除的子数组](https://leetcode.cn/problems/subarray-sums-divisible-by-k/)
-   [523\. 连续的子数组和](https://leetcode.cn/problems/continuous-subarray-sum/)
-   [525\. 连续数组](https://leetcode.cn/problems/contiguous-array/)
