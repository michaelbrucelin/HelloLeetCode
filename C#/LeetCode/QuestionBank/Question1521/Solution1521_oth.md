### [两种方法：LogTrick/滑动窗口+栈（Python/Java/C++/Go）](https://leetcode.cn/problems/find-a-value-of-a-mysterious-function-closest-to-target/solutions/2798247/li-yong-and-de-xing-zhi-pythonjavacgo-by-mjx7/?envType=problem-list-v2&envId=04xjKEs9)

本题和 [3171\. 找到按位或最接近 $K$ 的子数组](https://leetcode.cn/problems/find-subarray-with-bitwise-or-closest-to-k/) 几乎一样，仅仅是把 $OR$ 改成了 $AND$。本文只留代码，具体原理请看 [我的题解](https://leetcode.cn/problems/find-subarray-with-bitwise-or-closest-to-k/solutions/2798206/li-yong-and-de-xing-zhi-pythonjavacgo-by-gg4d/)，两种方法都有讲解。

#### 方法一：LogTrick

```Python
class Solution:
    def closestToTarget(self, arr: List[int], k: int) -> int:
        ans = inf
        for i, x in enumerate(arr):
            ans = min(ans, abs(x - k))
            for j in range(i - 1, -1, -1):
                if arr[j] & x == arr[j]:
                    break
                arr[j] &= x
                ans = min(ans, abs(arr[j] - k))
        return ans
```

```Java
class Solution {
    public int closestToTarget(int[] arr, int k) {
        int ans = Integer.MAX_VALUE;
        for (int i = 0; i < arr.length; i++) {
            int x = arr[i];
            ans = Math.min(ans, Math.abs(x - k));
            for (int j = i - 1; j >= 0 && (arr[j] & x) != arr[j]; j--) {
                arr[j] &= x;
                ans = Math.min(ans, Math.abs(arr[j] - k));
            }
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    int closestToTarget(vector<int>& arr, int k) {
        int ans = INT_MAX;
        for (int i = 0; i < arr.size(); i++) {
            int x = arr[i];
            ans = min(ans, abs(x - k));
            for (int j = i - 1; j >= 0 && (arr[j] & x) != arr[j]; j--) {
                arr[j] &= x;
                ans = min(ans, abs(arr[j] - k));
            }
        }
        return ans;
    }
};
```

```Go
func closestToTarget(arr []int, k int) int {
    ans := math.MaxInt
    for i, x := range arr {
        ans = min(ans, abs(x-k))
        for j := i - 1; j >= 0 && arr[j]&x != arr[j]; j-- {
            arr[j] &= x
            ans = min(ans, abs(arr[j]-k))
        }
    }
    return ans
}

func abs(x int) int { if x < 0 { return -x }; return x }
```

#### 复杂度分析

- 时间复杂度：$O(n\log U)$，其中 $n$ 是 $arr$ 的长度，$U=max(arr)$。由于 $10^6<2^{20}-1$，二进制数对应集合的大小不会超过 $19$，因此在与运算下，每个数字至多可以减少 $19$ 次。总体上看，二重循环的总循环次数等于每个数字可以减少的次数之和，即 $O(n\log U)$。
- 空间复杂度：$O(1)$。

#### 方法二：滑动窗口+栈

**注**：$-1$ 的二进制全为 $1$，与任何数 $x$ 的 $AND$ 结果都等于 $x$，适合作为初始值。

```Python
class Solution:
    def closestToTarget(self, arr: List[int], k: int) -> int:
        ans = inf
        left = bottom = 0
        right_and = -1
        for right, x in enumerate(arr):
            right_and &= x
            while left <= right and arr[left] & right_and < k:
                ans = min(ans, k - (arr[left] & right_and))
                left += 1
                if bottom < left:
                    # 重新构建一个栈
                    for i in range(right - 1, left - 1, -1):
                        arr[i] &= arr[i + 1]
                    bottom = right
                    right_and = -1
            if left <= right:
                ans = min(ans, (arr[left] & right_and) - k)
        return ans
```

```Java
class Solution {
    public int closestToTarget(int[] arr, int k) {
        int ans = Integer.MAX_VALUE;
        int left = 0;
        int bottom = 0;
        int rightAnd = -1;
        for (int right = 0; right < arr.length; right++) {
            rightAnd &= arr[right];
            while (left <= right && (arr[left] & rightAnd) < k) {
                ans = Math.min(ans, k - (arr[left] & rightAnd));
                left++;
                if (bottom < left) {
                    // 重新构建一个栈
                    for (int i = right - 1; i >= left; i--) {
                        arr[i] &= arr[i + 1];
                    }
                    bottom = right;
                    rightAnd = -1;
                }
            }
            if (left <= right) {
                ans = Math.min(ans, (arr[left] & rightAnd) - k);
            }
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    int closestToTarget(vector<int>& arr, int k) {
        int ans = INT_MAX, left = 0, bottom = 0, right_and = -1;
        for (int right = 0; right < arr.size(); right++) {
            right_and &= arr[right];
            while (left <= right && (arr[left] & right_and) < k) {
                ans = min(ans, k - (arr[left] & right_and));
                left++;
                if (bottom < left) {
                    // 重新构建一个栈
                    for (int i = right - 1; i >= left; i--) {
                        arr[i] &= arr[i + 1];
                    }
                    bottom = right;
                    right_and = -1;
                }
            }
            if (left <= right) {
                ans = min(ans, (arr[left] & right_and) - k);
            }
        }
        return ans;
    }
};
```

```Go
func closestToTarget(arr []int, k int) int {
    ans := math.MaxInt
    left, bottom, rightAnd := 0, 0, -1
    for right, x := range arr {
        rightAnd &= x
        for left <= right && arr[left]&rightAnd < k {
            ans = min(ans, k-(arr[left]&rightAnd))
            left++
            if bottom < left {
                // 重新构建一个栈
                for i := right - 1; i >= left; i-- {
                    arr[i] &= arr[i+1]
                }
                bottom = right
                rightAnd = -1
            }
        }
        if left <= right {
            ans = min(ans, (arr[left]&rightAnd)-k)
        }
    }
    return ans
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是 $arr$ 的长度。虽然我们写了个三重循环，但每个元素至多入栈出栈各一次，所以三重循环的**总**循环次数是 $O(n)$ 的，所以时间复杂度是 $O(n)$。
- 空间复杂度：$O(1)$。

更多相似题目，见位运算题单中的「**LogTrick**」。

#### 分类题单

[如何科学刷题？](https://leetcode.cn/circle/discuss/RvFUtj/)

1. [滑动窗口与双指针（定长/不定长/单序列/双序列/三指针/分组循环）](https://leetcode.cn/circle/discuss/0viNMK/)
2. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
3. [单调栈（基础/矩形面积/贡献法/最小字典序）](https://leetcode.cn/circle/discuss/9oZFK9/)
4. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
5. [位运算（基础/性质/拆位/试填/恒等式/思维）](https://leetcode.cn/circle/discuss/dHn9Vk/)
6. [图论算法（DFS/BFS/拓扑排序/基环树/最短路/最小生成树/网络流）](https://leetcode.cn/circle/discuss/01LUak/)
7. [动态规划（入门/背包/划分/状态机/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
8. [常用数据结构（前缀和/差分/栈/队列/堆/字典树/并查集/树状数组/线段树）](https://leetcode.cn/circle/discuss/mOr1u6/)
9. [数学算法（数论/组合/概率期望/博弈/计算几何/随机算法）](https://leetcode.cn/circle/discuss/IYT3ss/)
10. [贪心与思维（基本贪心策略/反悔/区间/字典序/数学/思维/脑筋急转弯/构造）](https://leetcode.cn/circle/discuss/g6KTKL/)
11. [链表、二叉树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA/一般树）](https://leetcode.cn/circle/discuss/K0n2gO/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/circle/discuss/SJFwQI/)
