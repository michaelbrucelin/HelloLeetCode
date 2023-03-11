﻿#### [【套路】前缀和+哈希表，消除分支的技巧（Python/Java/C++/Go）](https://leetcode.cn/problems/find-longest-subarray-lcci/solutions/2160308/tao-lu-qian-zhui-he-ha-xi-biao-xiao-chu-3mb11/)

#### 前置知识：前缀和

对于数组 $nums$，定义它的前缀和 $s[0]=0$，$s[i+1] = \sum\limits_{j=0}^{i}nums[j]$。

根据这个定义，有 $s[i+1]=s[i]+nums[i]$。

例如 $nums=[1,2,-1,2]$，对应的前缀和数组为 $s=[0,1,3,2,4]$。

通过前缀和，我们可以把**子数组的元素和转换成两个前缀和的差**，即

$$\sum_{j=left}^{right}nums[j] = \sum\limits_{j=0}^{right}nums[j] - \sum\limits_{j=0}^{left-1}nums[j] = s[right+1] - s[left]$$

例如 $nums$ 的子数组 $[2,-1,2]$ 的和就可以用 $s[4]-s[1]=4-1=3$ 算出来。

> 注：为方便计算，常用左闭右开区间 $[left,right)$ 来表示从 $nums[left]$ 到 $nums[right-1]$ 的子数组，此时子数组的和为 $s[right] - s[left]$，子数组的长度为 $right-left$。
> 
> 注 2：$s[0]=0$ 表示一个空数组的元素和。为什么要额外定义它？想一想，如果要计算的子数组恰好是一个前缀（从 $nums[0]$ 开始），你要用 $s[right]$ 减去谁呢？通过定义 $s[0]=0$，任意子数组（包括前缀）都可以表示为两个前缀和的差。

#### 提示 1

「字母和数字的个数相同」等价于「字母的个数减去数字的个数等于 $0$」。

#### 提示 2

如果 $array[i][0]$ 是字母，则把 $array[i]$ 视作 $1$；如果是数字，则视作 $-1$。

这样转换后，问题变成「找到一个最长子数组，其元素和等于 $0$」。

#### 提示 3

用前缀和处理元素和，「元素和等于 $0$」等价于「两个前缀和之差等于 $0$」，进而等价于「两个前缀和相同」。

转换后，完整的表述为：从前缀和 $s$ 中找到两个相同的数 $s[right]$ 和 $s[left]$，计算 $right-left$ 的最大值。

#### 提示 4

遍历前缀和 $s$ 的同时，用一个数组或哈希表 $first$ 记录 $s[i]$ 首次出现的下标，我们需要计算的就是 $i-first[s[i]]$ 的最大值。

例如 $[1,-1,1,1,1,-1,-1]$ 的前缀和 $s=[0, 1, 0, 1, 2, 3, 2, 1]$，其中 $s[0]=0$ 和 $s[2]=0$ 就对应着一段和为 $0$ 的子数组 $[1,-1]$；$s[1]=1$ 和 $s[7]=1$ 就对应着一段和为 $0$ 的子数组 $[-1,1,1,1,-1,-1]$。

#### 答疑

**问**：为什么不能用双指针做？

**答**：使用双指针需要满足单调性，但是 $s[i]$ 并不是单调的，所以不能用双指针。具体请看[【基础算法精讲 01】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1hd4y1r7Gq%2F)。

**问**：`(c >> 6 & 1) * 2 - 1`是什么意思？

**答**：对于任意小写/大写英文字母字符，其 ASCII 码的二进制都形如 $01xxxxxx$；对于任意数字字符，其 ASCII 码的二进制都形如 $0011xxxx$。

根据这一特点，可以根据二进制从低到高第 $6$ 位（设二进制最低位是第 $0$ 位）是 $0$ 还是 $1$ 来判断：如果是 $1$ 就是小写/大写英文字母字符，如果是 $0$ 就是数字字符。把字符的二进制右移 $6$ 位再 $AND 1$ 就可以得到这个比特值。然后再通过 $\times 2-1$ 的操作，把 $1$ 转换成 $1$，$0$ 转换成 $-1$。

**问**：为什么把判断字母/数字的 `if-else` 写成 `(c >> 6 & 1) * 2 - 1` 会快一些？（在 Java 上比较明显）

**答**：CPU 在遇到分支（条件跳转指令）时会预测代码要执行哪个分支，如果预测正确，CPU 就会继续按照预测的路径执行程序。但如果预测失败，CPU 就需要回滚之前的指令并加载正确的指令，以确保程序执行的正确性。

对于本题的数据，字母/数字可以认为是随机出现的，在这种情况下分支预测就会有 $50\%$ 的概率失败。失败导致的回滚和加载操作需要消耗额外的 CPU 周期，如果能用较小的代价去掉分支，对于本题的情况必然可以带来效率上的提升。

注意：这种优化方法往往会降低可读性，最好不要在业务代码中使用。

```python
class Solution:
    def findLongestSubarray(self, array: List[str]) -> List[str]:
        s = list(accumulate((-1 if v[0].isdigit() else 1 for v in array), initial=0))
        begin = end = 0  # 符合要求的子数组 [begin,end)
        first = {}
        for i, v in enumerate(s):
            j = first.get(v, -1)
            if j < 0:  # 首次遇到 s[i]
                first[v] = i
            elif i - j > end - begin:  # 更长的子数组
                begin, end = j, i
        return array[begin:end]
```

```java
class Solution {
    public String[] findLongestSubarray(String[] array) {
        int n = array.length;
        var s = new int[n + 1]; // 前缀和
        for (int i = 0; i < n; ++i)
            s[i + 1] = s[i] + (array[i].charAt(0) >> 6 & 1) * 2 - 1;

        int begin = 0, end = 0; // 符合要求的子数组 [begin,end)
        var first = new HashMap<Integer, Integer>();
        for (int i = 0; i <= n; ++i) {
            int j = first.getOrDefault(s[i], -1);
            if (j < 0) // 首次遇到 s[i]
                first.put(s[i], i);
            else if (i - j > end - begin) { // 更长的子数组
                begin = j;
                end = i;
            }
        }

        var sub = new String[end - begin];
        System.arraycopy(array, begin, sub, 0, sub.length);
        return sub;
    }
}
```

```cpp
class Solution {
public:
    vector<string> findLongestSubarray(vector<string> &array) {
        int n = array.size(), s[n + 1]; // 前缀和
        s[0] = 0;
        for (int i = 0; i < n; ++i)
            s[i + 1] = s[i] + (array[i][0] >> 6 & 1) * 2 - 1;

        int begin = 0, end = 0; // 符合要求的子数组 [begin,end)
        unordered_map<int, int> first;
        for (int i = 0; i <= n; ++i) {
            auto it = first.find(s[i]);
            if (it == first.end()) // 首次遇到 s[i]
                first[s[i]] = i;
            else if (i - it->second > end - begin) // 更长的子数组
                begin = it->second, end = i;
        }
        return {array.begin() + begin, array.begin() + end};
    }
};
```

```go
func findLongestSubarray(array []string) []string {
    s := make([]int, len(array)+1) // 前缀和
    for i, v := range array {
        s[i+1] = s[i] + int(v[0])>>6&1*2 - 1
    }

    begin, end := 0, 0 // 符合要求的子数组 [begin,end)
    first := map[int]int{}
    for i, v := range s {
        if j, ok := first[v]; !ok { // 首次遇到 s[i]
            first[v] = i
        } else if i-j > end-begin { // 更长的子数组
            begin, end = j, i
        }
    }
    return array[begin:end]
}
```

#### 优化

前缀和数组可以简化成一个整数变量 $s$，一边遍历 $array$ 一边计算 $s$。

同时注意到 $s$ 不会超过 [−n,n][-n,n][−n,n] 的范围，哈希表可以用一个长为 2n+12n+12n+1 的数组代替（数组比哈希表快）。数组可以初始化成 −1-1−1，表示相应的值没有遇到过。此外，为避免出现负数下标，$s$ 应初始化成 $n$。

```python
class Solution:
    def findLongestSubarray(self, array: List[str]) -> List[str]:
        begin = end = 0
        s = n = len(array)
        first = [-1] * (n * 2 + 1)
        first[s] = 0  # s[0] = 0
        for i, v in enumerate(array, 1):
            s += -1 if v[0].isdigit() else 1
            j = first[s]
            if j < 0:
                first[s] = i
            elif i - j > end - begin:
                begin, end = j, i
        return array[begin:end]
```

```java
class Solution {
    public String[] findLongestSubarray(String[] array) {
        int n = array.length, begin = 0, end = 0, s = n;
        var first = new int[n * 2 + 1];
        Arrays.fill(first, -1); // 注：去掉可以再快 1ms（需要 s 下标改从 1 开始）
        first[s] = 0; // s[0] = 0
        for (int i = 1; i <= n; ++i) {
            s += (array[i - 1].charAt(0) >> 6 & 1) * 2 - 1;
            int j = first[s];
            if (j < 0)
                first[s] = i;
            else if (i - j > end - begin) {
                begin = j;
                end = i;
            }
        }
        var sub = new String[end - begin];
        System.arraycopy(array, begin, sub, 0, sub.length);
        return sub;
    }
}
```

```cpp
class Solution {
public:
    vector<string> findLongestSubarray(vector<string> &array) {
        int n = array.size(), begin = 0, end = 0, s = n, first[n * 2 + 1];
        memset(first, -1, sizeof(first));
        first[s] = 0; // s[0] = 0
        for (int i = 1; i <= n; ++i) {
            s += (array[i - 1][0] >> 6 & 1) * 2 - 1;
            int j = first[s];
            if (j < 0)
                first[s] = i;
            else if (i - j > end - begin)
                begin = j, end = i;
        }
        return {array.begin() + begin, array.begin() + end};
    }
};
```

```go
func findLongestSubarray(array []string) []string {
    begin, end, n := 0, 0, len(array)
    first := make([]int, n*2+1)
    for i := range first { // 注：去掉可以再快 1ms（需要 s 下标改从 1 开始）
        first[i] = -1
    }
    s := n
    first[s] = 0 // s[0] = 0
    for i := 1; i <= n; i++ {
        s += int(array[i-1][0])>>6&1*2 - 1
        if j := first[s]; j < 0 {
            first[s] = i
        } else if i-j > end-begin {
            begin, end = j, i
        }
    }
    return array[begin:end]
}
```

#### 复杂度分析

-   时间复杂度：$O(n)$，其中 $n$ 为 $array$ 的长度。
-   空间复杂度：$O(n)$。

#### 相似题目（前缀和+哈希表）

推荐按照顺序完成。

-   [560\. 和为 K 的子数组](https://leetcode.cn/problems/subarray-sum-equals-k/)
-   [974\. 和可被 K 整除的子数组](https://leetcode.cn/problems/subarray-sums-divisible-by-k/)
-   [1590\. 使数组和能被 P 整除](https://leetcode.cn/problems/make-sum-divisible-by-p/)
-   [523\. 连续的子数组和](https://leetcode.cn/problems/continuous-subarray-sum/)
-   [525\. 连续数组](https://leetcode.cn/problems/contiguous-array/)
