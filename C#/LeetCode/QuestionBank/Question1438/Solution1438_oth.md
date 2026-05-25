### [O(n) 做法：滑动窗口 + 单调队列（Python/Java/C++/C/Go/JS/Rust）](https://leetcode.cn/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/solutions/3707019/on-zuo-fa-hua-dong-chuang-kou-dan-diao-d-g45r/?envType=problem-list-v2&envId=ySsxoJfz)

子数组越长，子数组的最大值越大，最小值越小，最大值与最小值的差值越大，越不能满足题目 $\le limit$ 的要求。反之，子数组越短，越满足要求。

有这样的性质，就可以用**滑动窗口**解决，原理见 [滑动窗口【基础算法精讲 03】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1hd4y1r7Gq%2F)。

现在问题变成计算 [239\. 滑动窗口最大值](https://leetcode.cn/problems/sliding-window-maximum/) 和滑动窗口最小值，这可以用 [单调队列【基础算法精讲 27】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1bM411X72E%2F)解决。

#### 答疑

**问**：为什么双端队列中保存的是下标而不是元素值？

**答**：我们需要根据下标判断队首是否在窗口外面。

**问**：为什么出队的逻辑写的是 $if$ 而不是 while？

**答**：每次把 $left$ 加一后就立刻检查队首是否出队，由于双端队列中没有重复的下标，所以每次 $left$ 加一后，至多出队一个元素。

```Python
class Solution:
    def longestSubarray(self, nums: List[int], limit: int) -> int:
        min_q = deque()
        max_q = deque()
        ans = left = 0

        for i, x in enumerate(nums):
            # 1. 右边入
            while min_q and x <= nums[min_q[-1]]:
                min_q.pop()
            min_q.append(i)

            while max_q and x >= nums[max_q[-1]]:
                max_q.pop()
            max_q.append(i)

            # 2. 左边出
            while nums[max_q[0]] - nums[min_q[0]] > limit:
                left += 1
                if min_q[0] < left:  # 队首不在窗口中
                    min_q.popleft()
                if max_q[0] < left:  # 队首不在窗口中
                    max_q.popleft()

            # 3. 更新答案
            ans = max(ans, i - left + 1)

        return ans
```

```Java
class Solution {
    public int longestSubarray(int[] nums, int limit) {
        Deque<Integer> minQ = new ArrayDeque<>(); // 更快的写法见【Java 数组】
        Deque<Integer> maxQ = new ArrayDeque<>();
        int ans = 0;
        int left = 0;

        for (int i = 0; i < nums.length; i++) {
            int x = nums[i];

            // 1. 右边入
            while (!minQ.isEmpty() && x <= nums[minQ.peekLast()]) {
                minQ.pollLast();
            }
            minQ.addLast(i);

            while (!maxQ.isEmpty() && x >= nums[maxQ.peekLast()]) {
                maxQ.pollLast();
            }
            maxQ.addLast(i);

            // 2. 左边出
            while (nums[maxQ.peekFirst()] - nums[minQ.peekFirst()] > limit) {
                left++;
                if (minQ.peekFirst() < left) { // 队首不在窗口中
                    minQ.pollFirst();
                }
                if (maxQ.peekFirst() < left) { // 队首不在窗口中
                    maxQ.pollFirst();
                }
            }

            // 3. 更新答案
            ans = Math.max(ans, i - left + 1);
        }

        return ans;
    }
}
```

```Java
// 数组
class Solution {
    public int longestSubarray(int[] nums, int limit) {
        int n = nums.length;
        int[] minQ = new int[n];
        int[] maxQ = new int[n];
        int minHead = 0, minTail = -1;
        int maxHead = 0, maxTail = -1;
        int ans = 0;
        int left = 0;

        for (int i = 0; i < n; i++) {
            int x = nums[i];

            // 1. 右边入
            while (minHead <= minTail && x <= nums[minQ[minTail]]) {
                minTail--; // 右边出队
            }
            minQ[++minTail] = i; // 右边入队

            while (maxHead <= maxTail && x >= nums[maxQ[maxTail]]) {
                maxTail--;
            }
            maxQ[++maxTail] = i;

            // 2. 左边出
            while (nums[maxQ[maxHead]] - nums[minQ[minHead]] > limit) {
                left++;
                if (minQ[minHead] < left) { // 队首不在窗口中
                    minHead++; // 左边出队
                }
                if (maxQ[maxHead] < left) { // 队首不在窗口中
                    maxHead++;
                }
            }

            // 3. 更新答案
            ans = Math.max(ans, i - left + 1);
        }

        return ans;
    }
}
```

```C++
class Solution {
public:
    int longestSubarray(vector<int>& nums, int limit) {
        deque<int> min_q, max_q;
        int ans = 0, left = 0;

        for (int i = 0; i < nums.size(); i++) {
            int x = nums[i];

            // 1. 右边入
            while (!min_q.empty() && x <= nums[min_q.back()]) {
                min_q.pop_back();
            }
            min_q.push_back(i);

            while (!max_q.empty() && x >= nums[max_q.back()]) {
                max_q.pop_back();
            }
            max_q.push_back(i);

            // 2. 左边出
            while (nums[max_q.front()] - nums[min_q.front()] > limit) {
                left++;
                if (min_q.front() < left) { // 队首不在窗口中
                    min_q.pop_front();
                }
                if (max_q.front() < left) { // 队首不在窗口中
                    max_q.pop_front();
                }
            }

            // 3. 更新答案
            ans = max(ans, i - left + 1);
        }

        return ans;
    }
};
```

```C
#define MAX(a, b) ((b) > (a) ? (b) : (a))

int longestSubarray(int* nums, int numsSize, int limit) {
    int* min_q = malloc(sizeof(int) * numsSize);
    int* max_q = malloc(sizeof(int) * numsSize);
    int min_head = 0, min_tail = -1;
    int max_head = 0, max_tail = -1;
    int ans = 0, left = 0;

    for (int i = 0; i < numsSize; i++) {
        int x = nums[i];

        // 1. 右边入
        while (min_head <= min_tail && x <= nums[min_q[min_tail]]) {
            min_tail--; // 右边出队
        }
        min_q[++min_tail] = i; // 右边入队

        while (max_head <= max_tail && x >= nums[max_q[max_tail]]) {
            max_tail--;
        }
        max_q[++max_tail] = i;

        // 2. 左边出
        while (nums[max_q[max_head]] - nums[min_q[min_head]] > limit) {
            left++;
            if (min_q[min_head] < left) { // 队首不在窗口中
                min_head++; // 左边出队
            }
            if (max_q[max_head] < left) { // 队首不在窗口中
                max_head++;
            }
        }

        // 3. 更新答案
        ans = MAX(ans, i - left + 1);
    }

    free(min_q);
    free(max_q);
    return ans;
}
```

```Go
func longestSubarray(nums []int, limit int) (ans int) {
    var minQ, maxQ []int
    left := 0
    for i, x := range nums {
        // 1. 右边入
        for len(minQ) > 0 && x <= nums[minQ[len(minQ)-1]] {
            minQ = minQ[:len(minQ)-1]
        }
        minQ = append(minQ, i)

        for len(maxQ) > 0 && x >= nums[maxQ[len(maxQ)-1]] {
            maxQ = maxQ[:len(maxQ)-1]
        }
        maxQ = append(maxQ, i)

        // 2. 左边出
        for nums[maxQ[0]]-nums[minQ[0]] > limit {
            left++
            if minQ[0] < left { // 队首不在窗口中
                minQ = minQ[1:]
            }
            if maxQ[0] < left { // 队首不在窗口中
                maxQ = maxQ[1:]
            }
        }

        // 3. 更新答案
        ans = max(ans, i-left+1)
    }
    return
}
```

```JavaScript
var longestSubarray = function(nums, limit) {
    const minQ = new Deque(); // datastructures-js/deque
    const maxQ = new Deque();
    let ans = 0, left = 0;

    for (let i = 0; i < nums.length; i++) {
        const x = nums[i];

        // 1. 右边入
        while (!minQ.isEmpty() && x <= nums[minQ.back()]) {
            minQ.popBack();
        }
        minQ.pushBack(i);

        while (!maxQ.isEmpty() && x >= nums[maxQ.back()]) {
            maxQ.popBack();
        }
        maxQ.pushBack(i);

        // 2. 左边出
        while (nums[maxQ.front()] - nums[minQ.front()] > limit) {
            left++;
            if (minQ.front() < left) { // 队首不在窗口中
                minQ.popFront();
            }
            if (maxQ.front() < left) { // 队首不在窗口中
                maxQ.popFront();
            }
        }

        // 3. 更新答案
        ans = Math.max(ans, i - left + 1);
    }

    return ans;
};
```

```Rust
use std::collections::VecDeque;

impl Solution {
    pub fn longest_subarray(nums: Vec<i32>, limit: i32) -> i32 {
        let mut min_q = VecDeque::new();
        let mut max_q = VecDeque::new();
        let mut ans = 0;
        let mut left = 0;

        for (i, &x) in nums.iter().enumerate() {
            // 1. 右边入
            while !min_q.is_empty() && x <= nums[*min_q.back().unwrap()] {
                min_q.pop_back();
            }
            min_q.push_back(i);

            while !max_q.is_empty() && x >= nums[*max_q.back().unwrap()] {
                max_q.pop_back();
            }
            max_q.push_back(i);

            // 2. 左边出
            while nums[*max_q.front().unwrap()] - nums[*min_q.front().unwrap()] > limit {
                left += 1;
                if *min_q.front().unwrap() < left { // 队首不在窗口中
                    min_q.pop_front();
                }
                if *max_q.front().unwrap() < left { // 队首不在窗口中
                    max_q.pop_front();
                }
            }

            // 3. 更新答案
            ans = ans.max(i - left + 1);
        }

        ans as _
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。虽然我们写了个二重循环，但站在每个元素的视角看，这个元素在二重循环中最多入队出队各两次（有两个队列），因此整个二重循环的循环次数是 $O(n)$ 的。
- 空间复杂度：$O(n)$。

#### 相似题目

见下面数据结构题单的「**§4.4 单调队列**」。

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
