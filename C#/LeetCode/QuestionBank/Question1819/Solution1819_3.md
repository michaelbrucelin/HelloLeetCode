﻿#### [击败100%！枚举GCD+循环优化（Python/Java/C++/Go）](https://leetcode.cn/problems/number-of-different-subsequences-gcds/solutions/2061079/ji-bai-100mei-ju-gcdxun-huan-you-hua-pyt-get7/)

#### 横看成岭侧成峰。

由于非空子序列的数量高达 $2^n-1$，直接回溯枚举是会超时的。不妨换一个视角，考虑值域。

多个数的最大公约数等于 $g$，也反过来说明这些数都是 $g$ 的倍数。例如 $[8,12,6]$ 的最大公约数是 $2$，这些数都是 $2$ 的倍数。

#### 【值域】【倍数】

那么，能不能反过来，枚举 $g$ 的倍数呢？

-   $1,2,3,\cdots$
-   $2,4,6,\cdots$
-   $3,6,9,\cdots$

看上去运行时间是个平方级别的，会超时。

#### 先别急着否定，这里得来点数学。

设 $U=\max(nums)$，那么 $1$ 的倍数需要枚举 $\left\lfloor\dfrac{U}{1}\right\rfloor$ 个，$2$ 的倍数需要枚举 $\left\lfloor\dfrac{U}{2}\right\rfloor$ 个，……，把这些加起来，去掉下取整，有
$\left\lfloor\dfrac{U}{1}\right\rfloor + \left\lfloor\dfrac{U}{2}\right\rfloor +\cdots + \left\lfloor\dfrac{U}{U}\right\rfloor \le U\cdot\left(\dfrac{1}{1} + \dfrac{1}{2} + \cdots + \dfrac{1}{U}\right)$

右边括号中的叫做 [调和级数部分和](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E8%B0%83%E5%92%8C%E7%BA%A7%E6%95%B0%2F8019971%3Ffr%3Daladdin%233)，可以看成是 $O(\log U)$ 的，因此枚举倍数的时间复杂度为 $O(U \log ⁡U)$，不会超时。

那么就枚举 $i=1,2,\cdots,U$ 及其倍数，当作子序列中的数。

#### 子序列中的数越多，$g$ 就可能越小，就越可能等于 $i$。

例如，如果枚举 $i=2$ 的倍数，其中 $8$ 和 $12$ 是在 $nums$ 中的，但由于 $8$ 和 $12$ 的最大公约数等于 $4$，所以无法找到一个子序列，其最大公约数为 $i$。但如果还有 $6$ 也在 $nums$ 中，那么最大公约数等于 $2$，这样 $i$ 就可以是一个子序列的最大公约数了。

代码实现时，需要用哈希表或者数组，记录每个数是否在 $nums$ 中，从而加快判断。数组的效率会更高一些。

```python
class Solution:
    def countDifferentSubsequenceGCDs(self, nums: List[int]) -> int:
        ans, mx = 0, max(nums)
        has = [False] * (mx + 1)
        for x in nums: has[x] = True
        for i in range(1, mx + 1):
            g = 0  # 0 和任何数 x 的最大公约数都是 x
            for j in range(i, mx + 1, i):  # 枚举 i 的倍数 j
                if has[j]:  # 如果 j 在 nums 中
                    g = gcd(g, j)  # 更新最大公约数
                    if g == i:  # 找到一个答案（g 无法继续减小）
                        ans += 1
                        break  # 提前退出循环
        return ans
```

```java
class Solution {
    public int countDifferentSubsequenceGCDs(int[] nums) {
        int ans = 0, mx = 0;
        for (int x : nums) mx = Math.max(mx, x);
        var has = new boolean[mx + 1];
        for (int x : nums) has[x] = true;
        for (int i = 1; i <= mx; ++i) {
            int g = 0; // 0 和任何数 x 的最大公约数都是 x
            for (int j = i; j <= mx && g != i; j += i) // 枚举 i 的倍数 j
                if (has[j]) // 如果 j 在 nums 中
                    g = gcd(g, j); // 更新最大公约数
            if (g == i) ++ans; // 找到一个答案
        }
        return ans;
    }

    private int gcd(int a, int b) {
        while (a != 0) {
            int tmp = a;
            a = b % a;
            b = tmp;
        }
        return b;
    }
}
```

```cpp
class Solution {
public:
    int countDifferentSubsequenceGCDs(vector<int> &nums) {
        int ans = 0, mx = *max_element(nums.begin(), nums.end());
        bool has[mx + 1]; memset(has, 0, sizeof(has));
        for (int x : nums) has[x] = true;
        for (int i = 1; i <= mx; ++i) {
            int g = 0; // 0 和任何数 x 的最大公约数都是 x
            for (int j = i; j <= mx && g != i; j += i) // 枚举 i 的倍数 j
                if (has[j]) // 如果 j 在 nums 中
                    g = gcd(g, j); // 更新最大公约数
            if (g == i) ++ans; // 找到一个答案
        }
        return ans;
    }
};
```

```go
func countDifferentSubsequenceGCDs(nums []int) (ans int) {
    mx := 0
    for _, x := range nums {
        if x > mx {
            mx = x
        }
    }
    has := make([]bool, mx+1)
    for _, x := range nums {
        has[x] = true
    }
    for i := 1; i <= mx; i++ {
        g := 0 // 0 和任何数 x 的最大公约数都是 x
        for j := i; j <= mx && g != i; j += i { // 枚举 i 的倍数 j
            if has[j] { // 如果 j 在 nums 中
                g = gcd(g, j) // 更新最大公约数
            }
        }
        if g == i { // 找到一个答案
            ans++
        }
    }
    return
}

func gcd(a, b int) int {
    for a != 0 {
        a, b = b%a, a
    }
    return b
}
```

#### 优化

答案可以由两部分组成：

-   子序列的长度为 $1$，此时最大公约数等于 $nums[i]$，这部分可以给答案贡献 $m$ 个，这里 $m$ 为 $nums$ 中不同元素的个数。
-   子序列的长度至少为 $2$，为了避免重复统计，此时最大公约数 $i$ 必须不在 $nums$ 中。此外，要想使最大公约数为 $i$，$nums$ 中**最小**要有 $2i$ 和 $3i$ 这两个数，这样最大公约数才能是 $i$。因此，**$i$ 只需要枚举到 $\left\lfloor\dfrac{U}{3}\right\rfloor$**。

凭借这个优化，下面的代码可以在时间上击败 $100\%$（截至本文发布时）。

```python
class Solution:
    def countDifferentSubsequenceGCDs(self, nums: List[int]) -> int:
        ans, mx = 0, max(nums)
        has = [False] * (mx + 1)
        for x in nums:
            if not has[x]:
                has[x] = True
                ans += 1  # 单独一个数也算
        for i in range(1, mx // 3 + 1):  # 优化循环上界
            if has[i]: continue
            g = 0  # 0 和任何数 x 的最大公约数都是 x
            for j in range(i * 2, mx + 1, i):  # 枚举 i 的倍数 j
                if has[j]:  # 如果 j 在 nums 中
                    g = gcd(g, j)  # 更新最大公约数
                    if g == i:  # 找到一个答案（g 无法继续减小）
                        ans += 1
                        break  # 提前退出循环
        return ans
```

```java
class Solution {
    public int countDifferentSubsequenceGCDs(int[] nums) {
        int ans = 0, mx = 0;
        for (int x : nums) mx = Math.max(mx, x);
        var has = new boolean[mx + 1];
        for (int x : nums)
            if (!has[x]) {
                has[x] = true;
                ++ans; // 单独一个数也算
            }
        for (int i = 1; i <= mx / 3; ++i) { // 优化循环上界
            if (has[i]) continue;
            int g = 0; // 0 和任何数 x 的最大公约数都是 x
            for (int j = i * 2; j <= mx && g != i; j += i) // 枚举 i 的倍数 j
                if (has[j]) // 如果 j 在 nums 中
                    g = gcd(g, j); // 更新最大公约数
            if (g == i) ++ans; // 找到一个答案
        }
        return ans;
    }

    private int gcd(int a, int b) {
        while (a != 0) {
            int tmp = a;
            a = b % a;
            b = tmp;
        }
        return b;
    }
}
```

```cpp
class Solution {
public:
    int countDifferentSubsequenceGCDs(vector<int> &nums) {
        int ans = 0, mx = *max_element(nums.begin(), nums.end());
        bool has[mx + 1]; memset(has, 0, sizeof(has));
        for (int x : nums)
            if (!has[x]) {
                has[x] = true;
                ++ans; // 单独一个数也算
            }
        for (int i = 1; i <= mx / 3; ++i) { // 优化循环上界
            if (has[i]) continue;
            int g = 0; // 0 和任何数 x 的最大公约数都是 x
            for (int j = i * 2; j <= mx && g != i; j += i) // 枚举 i 的倍数 j
                if (has[j]) // 如果 j 在 nums 中
                    g = gcd(g, j); // 更新最大公约数
            if (g == i) ++ans; // 找到一个答案
        }
        return ans;
    }
};
```

```go
func countDifferentSubsequenceGCDs(nums []int) (ans int) {
    mx := 0
    for _, x := range nums {
        if x > mx {
            mx = x
        }
    }
    has := make([]bool, mx+1)
    for _, x := range nums {
        if !has[x] {
            has[x] = true
            ans++
        }
    }
    for i := 1; i <= mx/3; i++ {
        if has[i] {
            continue
        }
        g := 0 // 0 和任何数 x 的最大公约数都是 x
        for j := i * 2; j <= mx && g != i; j += i { // 枚举 i 的倍数 j
            if has[j] { // 如果 j 在 nums 中
                g = gcd(g, j) // 更新最大公约数
            }
        }
        if g == i { // 找到一个答案
            ans++
        }
    }
    return
}

func gcd(a, b int) int {
    for a != 0 {
        a, b = b%a, a
    }
    return b
}
```

#### 复杂度分析

-   时间复杂度：$O(n+U\log U)$，其中 $n$ 为 $nums$ 的长度，$U=\max(nums)$。二重循环的时间复杂度分两部分，第一部分是**二重循环的次数**，根据 [调和级数部分和](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E8%B0%83%E5%92%8C%E7%BA%A7%E6%95%B0%2F8019971%3Ffr%3Daladdin%233)，循环次数为 $O(U\log U)$；第二部分是**计算 $g$ 的总时间**，由于 $g$ 每次计算要么不变，要么至少减半，所以实际上 $g$ 在内层循环中至多减半 $O(\log U)$ 次，计算 $g$ 的时间对于每个 $i$ 都是 $O(\log U)$ 的，因此这部分的时间复杂度也为 $O(U\log U)$。最后，加上遍历 $nums$ 的 $O(n)$ 时间，总的时间复杂度为 $O(n+U\log U)$。
-   空间复杂度：$O(U)$。
