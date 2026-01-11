### [O(n) 换座位，通过例子理解算法思想（Python/Java/C++/C/Go/JS/Rust）](https://leetcode.cn/problems/first-missing-positive/solutions/3655377/huan-zuo-wei-tong-guo-li-zi-li-jie-suan-qa94e/)

#### 思路

想象有一间教室，座位从左到右编号为 $1$ 到 $n$。

有 $n$ 个学生坐在教室的座位上，把 $nums[i]$ 当作坐在第 $i$ 个座位上的学生的学号。我们要做的事情，就是让学号在 $1$ 到 $n$ 中的学生，都坐到编号与自己学号相同的座位上（学号与座位编号匹配）。学号不在 $[1,n]$ 中的学生可以忽略。

学生们交换座位后，从左往右看，第一个学号与座位编号不匹配的学生，其座位编号就是答案。

特别地，如果所有学生都坐在正确的座位上，那么答案是 $n+1$。

##### 第一个例子

为方便描述思路，假设数组的下标是从 $1$ 开始的。

假设 $nums=[2,3,1]$。

1. 从 $nums[1]$ 开始。这个座位上的学生，学号是 $2$，他应当坐在 $nums[2]$ 上，所以他和 $nums[2]$ 交换。交换后 $nums=[3,2,1]$。
2. 仍然看 $nums[1]$，这个座位上的学生，学号是 $3$，他应当坐在 $nums[3]$ 上，所以他和 $nums[3]$ 交换。交换后 $nums=[1,2,3]$。
3. 仍然看 $nums[1]$，这个座位上的学生，学号是 $1$，他坐在正确的座位上。
4. 向后遍历，$nums[2]=2$，他坐在正确的座位上。
5. 向后遍历，$nums[3]=3$，他坐在正确的座位上。
6. 换座位过程结束。
7. 再次遍历 $nums$，发现 $nums[i]=i$ 都满足，说明数组中 $1,2,3$ 都有，所以缺失的第一个正数是 $4$。

##### 第二个例子

假设 $nums=[3,4,-1,1]$，这是题目中的示例 $2$。

1. 从 $nums[1]$ 开始。这个座位上的学生，学号是 $3$，他应当坐在 $nums[3]$ 上，所以他和 $nums[3]$ 交换。交换后 $nums=[-1,4,3,1]$。
2. 仍然看 $nums[1]$，这个座位上的学生，学号是 $-1$，忽略。
3. 向后遍历，$nums[2]=4$，他应当坐在 $nums[4]$ 上，所以他和 $nums[4]$ 交换。交换后 $nums=[-1,1,3,4]$。
4. 仍然看 $nums[2]=1$，他应当坐在 $nums[1]$ 上，所以他和 $nums[1]$ 交换。交换后 $nums=[1,-1,3,4]$。
5. 仍然看 $nums[2]$，这个座位上的学生，学号是 $-1$，忽略。
6. 向后遍历，$nums[3]=3$，他坐在正确的座位上。
7. 向后遍历，$nums[4]=4$，他坐在正确的座位上。
8. 换座位过程结束。
9. 再次遍历 $nums$，发现 $nums[2]=-1\ne 2$，说明教室中没有学号为 $2$ 的学生（否则他会坐在 $nums[2]$ 上），所以答案是 $2$。

##### 第三个例子

注意 $nums$ 中可能有重复元素。在这种情况下，算法仍然是正确的吗？

假设 $nums=[1,1,2]$。

1. 从 $nums[1]$ 开始。这个座位上的学生坐在正确的座位上。
2. 继续遍历，$nums[2]=1$，这是 $1$ 号学生的影分身。由于 $1$ 号学生的真身已经坐在正确的座位上，**我们可以在第二次遍历中知道「数组中有 1」这个信息**，所以可以忽略 $nums[2]$，向后遍历。
3. $nums[3]=2$，他应当坐在 $nums[2]$ 上，所以他和 $nums[2]$ 交换。交换后 $nums=[1,2,1]$。
4. 仍然看 $nums[3]=1$，同样地，由于 $1$ 号学生已经坐在正确的座位上，所以可以忽略 $nums[3]$。
5. 换座位过程结束。
6. 再次遍历 $nums$，发现 $nums[3]=1\ne 3$，说明教室中没有学号为 $3$ 的学生，所以答案是 $3$。

#### 细节

判断「学生是否坐在正确的座位上」，能用 $nums[i]=i$ 判断吗？注意有影分身（重复元素）。

在第三个例子中，虽然 $nums[2]=1\ne 2$，但由于 $nums[nums[2]]=nums[1]=1$，所以 $nums[2]$ 是个影分身，并且其真身坐在了正确的座位上，所以可以忽略 $nums[2]$，向后遍历。注意这种情况是不能交换的，因为 $nums[2]=nums[1]$，交换后 $nums=[1,1,2]$ 是不变的，这会导致**死循环**。

为避免死循环，可以改成判断 $nums[2]$ 和 $nums[nums[2]]$ 是不是一样的。如果一样，就不执行交换，继续向后遍历。

一般地，为了兼容「当前学生是真身，坐在正确的座位上」和「当前学生是影分身，且其真身坐在正确的座位上」两种情况，我们可以把 $i=nums[i]$ 套一层 $nums$，用 $nums[i]=nums[nums[i]]$ 判断。

- 无论「当前学生是真身，坐在正确的座位上」还是「当前学生是影分身，且其真身坐在正确的座位上」，上式都是成立的。
- 如果「当前学生是真身，不坐在正确的座位上」，那么上式左边是当前学生的学号，右边是要交换的学生的学号。
- 如果「当前学生是影分身，且其真身不坐在正确的座位上」，那么上式左边是当前学生的学号，右边是要交换的学生的学号。虽然是用影分身交换的，但交换后，可以认为真身已经坐在了正确的座位上。

代码实现时，由于 $nums$ 的下标是从 $0$ 开始的，通过学号访问下标，要把学号减一。

> **注**：用 $Python$ 的同学请注意，下面代码中的 `nums[i], nums[j] = nums[j], nums[i]` 不能写成 `nums[i], nums[nums[i] - 1] = nums[nums[i] - 1], nums[i]`。这会先更新 `nums[i]` 为 `nums[nums[i] - 1]`，然后再更新 `nums[nums[i] - 1]`，但此时 `nums[i] - 1` 已经不是原来的值了。

```Python
class Solution:
    def firstMissingPositive(self, nums: list[int]) -> int:
        n = len(nums)
        for i in range(n):
            # 如果当前学生的学号在 [1,n] 中，但（真身）没有坐在正确的座位上
            while 1 <= nums[i] <= n and nums[i] != nums[nums[i] - 1]:
                # 那么就交换 nums[i] 和 nums[j]，其中 j 是 i 的学号
                j = nums[i] - 1  # 减一是因为数组下标从 0 开始
                nums[i], nums[j] = nums[j], nums[i]

        # 找第一个学号与座位编号不匹配的学生
        for i in range(n):
            if nums[i] != i + 1:
                return i + 1

        # 所有学生都坐在正确的座位上
        return n + 1
```

```Java
class Solution {
    public int firstMissingPositive(int[] nums) {
        int n = nums.length;
        for (int i = 0; i < n; i++) {
            // 如果当前学生的学号在 [1,n] 中，但（真身）没有坐在正确的座位上
            while (1 <= nums[i] && nums[i] <= n && nums[i] != nums[nums[i] - 1]) {
                // 那么就交换 nums[i] 和 nums[j]，其中 j 是 i 的学号
                int j = nums[i] - 1; // 减一是因为数组下标从 0 开始
                int tmp = nums[i];
                nums[i] = nums[j];
                nums[j] = tmp;
            }
        }

        // 找第一个学号与座位编号不匹配的学生
        for (int i = 0; i < n; i++) {
            if (nums[i] != i + 1) {
                return i + 1;
            }
        }

        // 所有学生都坐在正确的座位上
        return n + 1;
    }
}
```

```C++
class Solution {
public:
    int firstMissingPositive(vector<int>& nums) {
        int n = nums.size();
        for (int i = 0; i < n; i++) {
            // 如果当前学生的学号在 [1,n] 中，但（真身）没有坐在正确的座位上
            while (1 <= nums[i] && nums[i] <= n && nums[i] != nums[nums[i] - 1]) {
                // 那么就交换 nums[i] 和 nums[j]，其中 j 是 i 的学号
                int j = nums[i] - 1; // 减一是因为数组下标从 0 开始
                swap(nums[i], nums[j]);
            }
        }

        // 找第一个学号与座位编号不匹配的学生
        for (int i = 0; i < n; i++) {
            if (nums[i] != i + 1) {
                return i + 1;
            }
        }

        // 所有学生都坐在正确的座位上
        return n + 1;
    }
};
```

```C
int firstMissingPositive(int* nums, int numsSize) {
    for (int i = 0; i < numsSize; i++) {
        // 如果当前学生的学号在 [1,n] 中，但（真身）没有坐在正确的座位上
        while (1 <= nums[i] && nums[i] <= numsSize && nums[i] != nums[nums[i] - 1]) {
            // 那么就交换 nums[i] 和 nums[j]，其中 j 是 i 的学号
            int j = nums[i] - 1; // 减一是因为数组下标从 0 开始
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
    }

    // 找第一个学号与座位编号不匹配的学生
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] != i + 1) {
            return i + 1;
        }
    }

    // 所有学生都坐在正确的座位上
    return numsSize + 1;
}
```

```Go
func firstMissingPositive(nums []int) int {
    n := len(nums)
    for i := range n {
        // 如果当前学生的学号在 [1,n] 中，但（真身）没有坐在正确的座位上
        for 1 <= nums[i] && nums[i] <= n && nums[i] != nums[nums[i]-1] {
            // 那么就交换 nums[i] 和 nums[j]，其中 j 是 i 的学号
            j := nums[i] - 1 // 减一是因为数组下标从 0 开始
            nums[i], nums[j] = nums[j], nums[i]
        }
    }

    // 找第一个学号与座位编号不匹配的学生
    for i := range n {
        if nums[i] != i+1 {
            return i + 1
        }
    }

    // 所有学生都坐在正确的座位上
    return n + 1
}
```

```JavaScript
var firstMissingPositive = function(nums) {
    const n = nums.length;
    for (let i = 0; i < n; i++) {
        // 如果当前学生的学号在 [1,n] 中，但（真身）没有坐在正确的座位上
        while (1 <= nums[i] && nums[i] <= n && nums[i] !== nums[nums[i] - 1]) {
            // 那么就交换 nums[i] 和 nums[j]，其中 j 是 i 的学号
            const j = nums[i] - 1; // 减一是因为数组下标从 0 开始
            [nums[i], nums[j]] = [nums[j], nums[i]];
        }
    }

    // 找第一个学号与座位编号不匹配的学生
    for (let i = 0; i < n; i++) {
        if (nums[i] !== i + 1) {
            return i + 1;
        }
    }

    // 所有学生都坐在正确的座位上
    return n + 1;
};
```

```Rust
impl Solution {
    pub fn first_missing_positive(mut nums: Vec<i32>) -> i32 {
        let n = nums.len();
        for i in 0..n {
            // 如果当前学生的学号在 [1,n] 中，但（真身）没有坐在正确的座位上
            while 1 <= nums[i] && nums[i] as usize <= n && nums[i] != nums[(nums[i] - 1) as usize] {
                // 那么就交换 nums[i] 和 nums[j]，其中 j 是 i 的学号
                let j = (nums[i] - 1) as usize; // 减一是因为数组下标从 0 开始
                nums.swap(i, j);
            }
        }

        // 找第一个学号与座位编号不匹配的学生
        for i in 0..n {
            if nums[i] != (i + 1) as i32 {
                return (i + 1) as _;
            }
        }

        // 所有学生都坐在正确的座位上
        (n + 1) as _
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。虽然我们写了个二重循环，但**每次交换都会把一个学生换到正确的座位上**，所以总交换次数至多为 $n$，所以内层循环的**总**循环次数是 $O(n)$ 的，所以时间复杂度是 $O(n)$。
- 空间复杂度：$O(1)$。

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
