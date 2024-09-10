### [统计上升四元组](https://leetcode.cn/problems/count-increasing-quadruplets/solutions/2909099/tong-ji-shang-sheng-si-yuan-zu-by-leetco-0g7g/)

#### 方法一：枚举四元组的中间两项

**思路与算法**

我们可以枚举四元组 $(i,j,k,l)$ 中的 $j$ 和 $k$，它们恰好是不等式的中间两项：这样一来，我们只需要统计：

1. 满足 $i<j$ 并且 $nums[i]<nums[k]$ 的 $i$ 的个数；
2. 满足 $k<l$ 并且 $nums[j]<nums[l]$ 的 $l$ 的个数。

根据乘法原理，将它们相乘，即可得到满足要求的四元组的个数。

我们不妨在外层循环递增枚举 $j$，在内层循环枚举 $k$。在内层循环中，$j$ 为**定值**，上述两个需要统计的量：

1. 满足 $i<j$ 的元素集合是固定不变的，变化的仅是 $nums[k]$。由于题目规定了数组 $nums$ 一定是 $1 \sim n$ 的一个排列（其中 $n$ 是数组 $nums$ 的长度），那么我们使用一个数组 $pre$，其中 $pre[x]$ 表示 $nums[0]$ 到 $nums[j-1]$ 中小于 $x$ 的元素个数。这样一来，我们通过 $pre[nums[k]]$，就可以在 $O(1)$ 的时间得到需要的统计量，并且当内层循环结束，$j$ 即将发生变化时，我们只需要把所有满足 $x>nums[j]$ 的 $pre[x]$ 都增加 1，就可以在 $O(n)$ 的时间更新这个数组。
2. 满足 $k<l$ 的元素集合是随着 $k$ 而变化的。要想变化尽可能要，我们应该按照递增或者递减的顺序枚举 $k$。由于 $nums[j]$ 是定值，因此按照递减的顺序枚举 $k$ 是比较方便的，这样我们只需要使用一个变量 $suf$ 记录需要的统计量。初始时，它的值为 $0$，每当 $k$ 即将发生变化时，如果 $nums[j]<nums[k]$，就将 $suf$ 增加 $1$ 即可。

需要注意只有当 $nums[j]>nums[k]$ 时，才将 $pre[nums[k]] \times suf$ 累加入答案。

**代码**

```C++
class Solution {
public:
    long long countQuadruplets(vector<int>& nums) {
        int n = nums.size();
        vector<int> pre(n + 1);
        long long ans = 0;
        for (int j = 0; j < n; ++j) {
            int suf = 0;
            for (int k = n - 1; k > j; --k) {
                if (nums[j] > nums[k]) {
                    ans += static_cast<long long>(pre[nums[k]]) * suf;
                }
                else {
                    ++suf;
                }
            }
            for (int x = nums[j] + 1; x <= n; ++x) {
                ++pre[x];
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public long countQuadruplets(int[] nums) {
        int n = nums.length;
        int[] pre = new int[n + 1];
        long ans = 0;
        for (int j = 0; j < n; ++j) {
            int suf = 0;
            for (int k = n - 1; k > j; --k) {
                if (nums[j] > nums[k]) {
                    ans += (long) pre[nums[k]] * suf;
                } else {
                    ++suf;
                }
            }
            for (int x = nums[j] + 1; x <= n; ++x) {
                ++pre[x];
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public long CountQuadruplets(int[] nums) {
        int n = nums.Length;
        int[] pre = new int[n + 1];
        long ans = 0;
        for (int j = 0; j < n; ++j) {
            int suf = 0;
            for (int k = n - 1; k > j; --k) {
                if (nums[j] > nums[k]) {
                    ans += (long) pre[nums[k]] * suf;
                } else {
                    ++suf;
                }
            }
            for (int x = nums[j] + 1; x <= n; ++x) {
                ++pre[x];
            }
        }
        return ans;
    }
}
```

```Python
class Solution:
    def countQuadruplets(self, nums: List[int]) -> int:
        n = len(nums)
        pre = [0] * (n + 1)
        ans = 0
        for j in range(n):
            suf = 0
            for k in range(n - 1, j, -1):
                if nums[j] > nums[k]:
                    ans += pre[nums[k]] * suf
                else:
                    suf += 1
            for x in range(nums[j] + 1, n + 1):
                pre[x] += 1
        return ans
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(n)$，即为数组 $pre$ 需要使用的空间。
