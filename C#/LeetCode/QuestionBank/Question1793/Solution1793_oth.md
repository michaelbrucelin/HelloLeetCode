### [两种方法：单调栈/双指针（Python/Java/C++/Go/JS/Rust）](https://leetcode.cn/problems/maximum-score-of-a-good-subarray/solutions/2695415/liang-chong-fang-fa-dan-diao-zhan-shuang-24zl/)

#### 方法一：单调栈

本题要计算的分数，和 [84. 柱状图中最大的矩形](https://leetcode.cn/problems/largest-rectangle-in-histogram/) 是一样的，计算的是最大矩形**面积**。只不过多了一个约束：矩形必须包含下标 $k$。

![](./assets/img/Solution1793_oth.jpg)

假设 $h=\textit{nums}[p]$ 是矩形的高度，那么矩形的宽度是多少？我们需要知道：

- 在 $p$ 左侧的小于 $h$ 的最近元素的下标 $\textit{left}$
- 在 $p$ 右侧的小于 $h$ 的最近元素的下标 $\textit{right}$

这可以用单调栈求出。原理请看视频：[单调栈【基础算法精讲 26】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1VN411J7S7%2F)，欢迎点赞关注~

那么矩形的宽度就是 $\textit{right}-\textit{left}-1$，矩形面积为 $h \cdot (\textit{right}-\textit{left}-1)$。

对于本题，如果下标 $k$ 在开区间 $(\textit{left}, \textit{right})$ 中，就说明矩形包含下标 $k$，用矩形面积更新答案的最大值。

##### 代码

```python
class Solution:
    def maximumScore(self, nums: List[int], k: int) -> int:
        n = len(nums)
        left = [-1] * n
        st = []
        for i, x in enumerate(nums):
            while st and x <= nums[st[-1]]:
                st.pop()
            if st:
                left[i] = st[-1]
            st.append(i)

        right = [n] * n
        st.clear()
        for i in range(n - 1, -1, -1):
            x = nums[i]
            while st and x <= nums[st[-1]]:
                st.pop()
            if st:
                right[i] = st[-1]
            st.append(i)

        ans = 0
        for h, l, r in zip(nums, left, right):
            if l < k < r:  # 相比 84 题多了这一行
                ans = max(ans, h * (r - l - 1))
        return ans
```

```java
class Solution {
    public int maximumScore(int[] nums, int k) {
        int n = nums.length;
        int[] left = new int[n];
        Deque<Integer> st = new ArrayDeque<>();
        for (int i = 0; i < n; i++) {
            int x = nums[i];
            while (!st.isEmpty() && x <= nums[st.peek()]) {
                st.pop();
            }
            left[i] = st.isEmpty() ? -1 : st.peek();
            st.push(i);
        }

        int[] right = new int[n];
        st.clear();
        for (int i = n - 1; i >= 0; i--) {
            int x = nums[i];
            while (!st.isEmpty() && x <= nums[st.peek()]) {
                st.pop();
            }
            right[i] = st.isEmpty() ? n : st.peek();
            st.push(i);
        }

        int ans = 0;
        for (int i = 0; i < n; i++) {
            int h = nums[i];
            int l = left[i];
            int r = right[i];
            if (l < k && k < r) { // 相比 84 题多了个 if 判断
                ans = Math.max(ans, h * (r - l - 1));
            }
        }
        return ans;
    }
}
```

```c++
class Solution {
public:
    int maximumScore(vector<int> &nums, int k) {
        int n = nums.size();
        vector<int> left(n, -1);
        stack<int> st;
        for (int i = 0; i < n; i++) {
            while (!st.empty() && nums[i] <= nums[st.top()]) {
                st.pop();
            }
            if (!st.empty()) {
                left[i] = st.top();
            }
            st.push(i);
        }

        vector<int> right(n, n);
        st = stack<int>();
        for (int i = n - 1; i >= 0; i--) {
            while (!st.empty() && nums[i] <= nums[st.top()]) {
                st.pop();
            }
            if (!st.empty()) {
                right[i] = st.top();
            }
            st.push(i);
        }

        int ans = 0;
        for (int i = 0; i < n; i++) {
            int h = nums[i], l = left[i], r = right[i];
            if (l < k && k < r) { // 相比 84 题多了个 if 判断
                ans = max(ans, h * (r - l - 1));
            }
        }
        return ans;
    }
};
```

```go
func maximumScore(nums []int, k int) (ans int) {
    n := len(nums)
    left := make([]int, n)
    st := []int{}
    for i, x := range nums {
        for len(st) > 0 && x <= nums[st[len(st)-1]] {
            st = st[:len(st)-1]
        }
        if len(st) > 0 {
            left[i] = st[len(st)-1]
        } else {
            left[i] = -1
        }
        st = append(st, i)
    }

    right := make([]int, n)
    st = st[:0]
    for i := n - 1; i >= 0; i-- {
        for len(st) > 0 && nums[i] <= nums[st[len(st)-1]] {
            st = st[:len(st)-1]
        }
        if len(st) > 0 {
            right[i] = st[len(st)-1]
        } else {
            right[i] = n
        }
        st = append(st, i)
    }

    for i, h := range nums {
        l, r := left[i], right[i]
        if l < k && k < r { // 相比 84 题多了个 if 判断
            ans = max(ans, h*(r-l-1))
        }
    }
    return ans
}
```

```javascript
var maximumScore = function (nums, k) {
    const n = nums.length;
    const left = Array(n).fill(-1);
    const st = [];
    for (let i = 0; i < n; i++) {
        const x = nums[i];
        while (st.length && x <= nums[st[st.length - 1]]) {
            st.pop();
        }
        if (st.length) {
            left[i] = st[st.length - 1];
        }
        st.push(i);
    }

    const right = Array(n).fill(n);
    st.length = 0;
    for (let i = n - 1; i >= 0; i--) {
        const x = nums[i];
        while (st.length && x <= nums[st[st.length - 1]]) {
            st.pop();
        }
        if (st.length) {
            right[i] = st[st.length - 1];
        }
        st.push(i);
    }

    let ans = 0;
    for (let i = 0; i < n; i++) {
        const h = nums[i], l = left[i], r = right[i];
        if (l < k && k < r) { // 相比 84 题多了个 if 判断
            ans = Math.max(ans, h * (r - l - 1));
        }
    }
    return ans;
};
```

```rust
impl Solution {
    pub fn maximum_score(nums: Vec<i32>, k: i32) -> i32 {
        let n = nums.len();
        let mut left = vec![-1; n];
        let mut st = Vec::new();
        for (i, &x) in nums.iter().enumerate() {
            while !st.is_empty() && x <= nums[*st.last().unwrap()] {
                st.pop();
            }
            if let Some(&j) = st.last() {
                left[i] = j as i32;
            }
            st.push(i);
        }

        let mut right = vec![n as i32; n];
        st.clear();
        for (i, &x) in nums.iter().enumerate().rev() {
            while !st.is_empty() && x <= nums[*st.last().unwrap()] {
                st.pop();
            }
            if let Some(&j) = st.last() {
                right[i] = j as i32;
            }
            st.push(i);
        }

        let mut ans = 0;
        for i in 0..n {
            let h = nums[i];
            let l = left[i];
            let r = right[i];
            if l < k && k < r { // 相比 84 题多了个 if 判断
                ans = ans.max(h * (r - l - 1));
            }
        }
        ans
    }
}
```

##### 复杂度分析

- 时间复杂度：$\mathcal{O}(n)$，其中 $n$ 为 $\textit{nums}$ 的长度。
- 空间复杂度：$\mathcal{O}(n)$。

#### 方法二：双指针

例如 $\textit{nums}=[1,9,7,8,8,1],\ k=3$。

其中面积最大的矩形，左边界下标 $L=1$，右边界下标 $R=4$。

我们尝试从 $i=k,\ j=k$ 出发，通过不断移动指针来找到最大矩形。比较 $\textit{nums}[i-1]$ 和 $\textit{nums}[j+1]$ 的大小，谁大就移动谁（一样大移动哪个都可以）。

**定理：** 按照这种移动方式，一定会在某个时刻恰好满足 $i=L$ 且 $j=R$。

**证明：** 如果 $i$ 先到达 $L$，那么此时 $j<R$。设 $L$ 到 $R$ 之间的最小元素为 $m$，在方法一中我们知道 $\textit{nums}[L-1]<m$，由于 $\textit{nums}[i-1]=\textit{nums}[L-1]<m\le\textit{nums}[j+1]$，那么后续一定是 $j$ 一直向右移动到 $R$。对于 $j$ 先到达 $R$ 的情况也同理。所以一定会在某个时刻恰好满足 $i=L$ 且 $j=R$。

在移动过程中，不断用 $\textit{nums}[i]$ 和 $\textit{nums}[j]$ 更新矩形高度的最小值 $\textit{minH}$，同时用 $\textit{minH}\cdot(j-i+1)$ 更新答案的最大值。

##### 代码

```python
class Solution:
    def maximumScore(self, nums: List[int], k: int) -> int:
        n = len(nums)
        ans = min_h = nums[k]
        i = j = k
        for _ in range(n - 1):
            if j == n - 1 or i and nums[i - 1] > nums[j + 1]:
                i -= 1
                min_h = min(min_h, nums[i])
            else:
                j += 1
                min_h = min(min_h, nums[j])
            ans = max(ans, min_h * (j - i + 1))
        return ans
```

```java
class Solution {
    public int maximumScore(int[] nums, int k) {
        int n = nums.length;
        int ans = nums[k], minH = nums[k];
        int i = k, j = k;
        for (int t = 0; t < n - 1; t++) { // 循环 n-1 次
            if (j == n - 1 || i > 0 && nums[i - 1] > nums[j + 1]) {
                minH = Math.min(minH, nums[--i]);
            } else {
                minH = Math.min(minH, nums[++j]);
            }
            ans = Math.max(ans, minH * (j - i + 1));
        }
        return ans;
    }
}
```

```c++
class Solution {
public:
    int maximumScore(vector<int> &nums, int k) {
        int n = nums.size();
        int ans = nums[k], min_h = nums[k];
        int i = k, j = k;
        for (int t = 0; t < n - 1; t++) { // 循环 n-1 次
            if (j == n - 1 || i && nums[i - 1] > nums[j + 1]) {
                min_h = min(min_h, nums[--i]);
            } else {
                min_h = min(min_h, nums[++j]);
            }
            ans = max(ans, min_h * (j - i + 1));
        }
        return ans;
    }
};
```

```go
func maximumScore(nums []int, k int) int {
    n := len(nums)
    ans, minH := nums[k], nums[k]
    i, j := k, k
    for t := 0; t < n-1; t++ { // 循环 n-1 次
        if j == n-1 || i > 0 && nums[i-1] > nums[j+1] {
            i--
            minH = min(minH, nums[i])
        } else {
            j++
            minH = min(minH, nums[j])
        }
        ans = max(ans, minH*(j-i+1))
    }
    return ans
}
```

```javascript
var maximumScore = function(nums, k) {
    const n = nums.length;
    let ans = nums[k], minH = nums[k];
    let i = k, j = k;
    for (let t = 0; t < n - 1; t++) { // 循环 n-1 次
        if (j === n - 1 || i > 0 && nums[i - 1] > nums[j + 1]) {
            minH = Math.min(minH, nums[--i]);
        } else {
            minH = Math.min(minH, nums[++j]);
        }
        ans = Math.max(ans, minH * (j - i + 1));
    }
    return ans;
};
```

```rust
impl Solution {
    pub fn maximum_score(nums: Vec<i32>, k: i32) -> i32 {
        let n = nums.len();
        let k = k as usize;
        let mut ans = nums[k];
        let mut min_h = nums[k];
        let mut i = k;
        let mut j = k;
        for _ in 0..n - 1 {
            if j == n - 1 || i > 0 && nums[i - 1] > nums[j + 1] {
                i -= 1;
                min_h = min_h.min(nums[i]);
            } else {
                j += 1;
                min_h = min_h.min(nums[j]);
            }
            ans = ans.max(min_h * (j - i + 1) as i32);
        }
        ans
    }
}
```

##### 复杂度分析

- 时间复杂度：$\mathcal{O}(n)$，其中 $n$ 为 $\textit{nums}$ 的长度。
- 空间复杂度：$\mathcal{O}(1)$。仅用到若干额外变量。

#### 题单：单调栈

- [单调栈（矩形系列/字典序最小/贡献法）](https://leetcode.cn/circle/discuss/9oZFK9/)
