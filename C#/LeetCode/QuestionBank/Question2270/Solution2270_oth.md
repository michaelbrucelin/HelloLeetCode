### [两次遍历（Python/Java/C++/C/Go/JS/Rust）](https://leetcode.cn/problems/number-of-ways-to-split-array/solutions/1496445/by-endlesscheng-nufi/)

设 $nums$ 的元素之和为 $total$。

设 $s=nums[0]+nums[1]+ \dots +nums[i]$。其余元素之和为 $total-s$。

题目要求 $s \ge total-s$，即

$$2s \ge total$$

也就是

$$s \ge \Bigl\lceil\dfrac{total}{2}\Bigr\rceil = \Bigl\lfloor\dfrac{total+1}{2}\Bigr\rfloor$$

从左到右遍历数组，一边遍历，一边累加元素更新 $s$，检查是否满足上式，满足则把答案加一。

注意题目要求 $i$ 右边至少有一个元素，所以 $i$ 至多遍历到 $n-2$ 为止。

```Python
class Solution:
    def waysToSplitArray(self, nums: List[int]) -> int:
        t = (sum(nums) + 1) // 2
        return sum(s >= t for s in accumulate(nums[:-1]))
```

```Java
class Solution {
    public int waysToSplitArray(int[] nums) {
        long total = 0;
        for (int x : nums) {
            total += x;
        }

        int ans = 0;
        long s = 0;
        for (int i = 0; i < nums.length - 1; i++) {
            s += nums[i];
            if (s * 2 >= total) {
                ans++;
            }
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    int waysToSplitArray(vector<int>& nums) {
        long long total = reduce(nums.begin(), nums.end(), 0LL);
        int ans = 0;
        long long s = 0;
        for (int i = 0; i + 1 < nums.size(); i++) {
            s += nums[i];
            if (s * 2 >= total) {
                ans++;
            }
        }
        return ans;
    }
};
```

```C
int waysToSplitArray(int* nums, int numsSize) {
    long long total = 0;
    for (int i = 0; i < numsSize; i++) {
        total += nums[i];
    }

    int ans = 0;
    long long s = 0;
    for (int i = 0; i < numsSize - 1; i++) {
        s += nums[i];
        if (s * 2 >= total) {
            ans++;
        }
    }
    return ans;
}
```

```Go
func waysToSplitArray(nums []int) (ans int) {
    total := 0
    for _, x := range nums {
        total += x
    }

    s := 0
    for _, x := range nums[:len(nums)-1] {
        s += x
        if s*2 >= total {
            ans++
        }
    }
    return
}
```

```JavaScript
var waysToSplitArray = function(nums) {
    let total = 0;
    for (const x of nums) {
        total += x;
    }
    const t = Math.ceil(total / 2);

    let ans = 0;
    let s = 0;
    for (let i = 0; i < nums.length - 1; i++) {
        s += nums[i];
        if (s >= t) {
            ans++;
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn ways_to_split_array(nums: Vec<i32>) -> i32 {
        let total = nums.iter().map(|&x| x as i64).sum();
        let mut ans = 0;
        let mut s = 0;
        for &x in &nums[..nums.len() - 1] {
            s += x as i64;
            if s * 2 >= total {
                ans += 1;
            }
        }
        ans
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。
- 空间复杂度：$O(1)$。

更多相似题目，见下面动态规划题单中的「**专题：前后缀分解**」。

#### 分类题单

[如何科学刷题？](https://leetcode.cn/circle/discuss/RvFUtj/)

1. [滑动窗口与双指针（定长/不定长/单序列/双序列/三指针/分组循环）](https://leetcode.cn/circle/discuss/0viNMK/)
2. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
3. [单调栈（基础/矩形面积/贡献法/最小字典序）](https://leetcode.cn/circle/discuss/9oZFK9/)
4. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
5. [位运算（基础/性质/拆位/试填/恒等式/思维）](https://leetcode.cn/circle/discuss/dHn9Vk/)
6. [图论算法（DFS/BFS/拓扑排序/最短路/最小生成树/二分图/基环树/欧拉路径）](https://leetcode.cn/circle/discuss/01LUak/)
7. [动态规划（入门/背包/状态机/划分/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
8. [常用数据结构（前缀和/差分/栈/队列/堆/字典树/并查集/树状数组/线段树）](https://leetcode.cn/circle/discuss/mOr1u6/)
9. [数学算法（数论/组合/概率期望/博弈/计算几何/随机算法）](https://leetcode.cn/circle/discuss/IYT3ss/)
10. [贪心与思维（基本贪心策略/反悔/区间/字典序/数学/思维/脑筋急转弯/构造）](https://leetcode.cn/circle/discuss/g6KTKL/)
11. [链表、二叉树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA/一般树）](https://leetcode.cn/circle/discuss/K0n2gO/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/circle/discuss/SJFwQI/)
