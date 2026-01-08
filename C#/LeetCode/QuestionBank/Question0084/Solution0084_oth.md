### [一步步优化：从三次遍历到一次遍历（Python/Java/C++/C/Go/JS/Rust）](https://leetcode.cn/problems/largest-rectangle-in-histogram/solutions/2695467/dan-diao-zhan-fu-ti-dan-pythonjavacgojsr-89s7/)

#### 分析

![](./assets/img/Solution0084_oth.jpg)

首先，面积最大矩形的高度**一定是** $heights$ **中的元素**。这可以用反证法证明：假如高度不在 $heights$ 中，比如 $4$，那我们可以增加高度直到触及某根柱子的顶部，比如增加到 $5$，由于矩形底边长不变，高度增加，我们得到了面积更大的矩形，矛盾，所以面积最大矩形的高度一定是 $heights$ 中的元素。

枚举每个 $h=heights[i]$，作为矩形的高。那么矩形的宽最大是多少？我们需要知道：

- 在 $i$ 左侧的**小于** $h$ 的最近元素的下标 $left$，如果不存在则为 $-1$。求出了 $left$，那么 $left+1$ 就是矩形最左边那根柱子。如果 $left=-1$，那么加一后是 $0$，就是整个 $heights$ 最左边的柱子。
- 在 $i$ 右侧的**小于** $h$ 的最近元素的下标 $right$，如果不存在则为 $n$。求出了 $right$，那么 $right-1$ 就是矩形最右边那根柱子。如果 $right=n$，那么减一后是 $n-1$，就是整个 $heights$ 最右边的柱子。

比如示例 $1$（上图），选择 $i=2$ 这个柱子作为矩形的高，那么左边小于 $heights[2]=5$ 的最近元素的下标为 $left=1$，右边小于 $heights[2]=5$ 的最近元素的下标为 $right=4$。矩形的宽就是 $right-left-1=4-1-1=2$，矩形面积为 $h\cdot (right-left-1)=5\cdot 2=10$。

枚举 $i$，计算对应的矩形面积，更新答案的最大值。

为什么这样做不会漏掉答案？题目本质是计算高\times 宽的最大值，高是我们枚举的，所以只要保证宽尽量大，答案就一定能被我们枚举计算到。

如何快速计算 $left$ 和 right？可以用**单调栈**。原理请看视频：[单调栈【基础算法精讲 26】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1VN411J7S7%2F)，欢迎点赞关注~

#### 答疑

**问**：为什么一定要找「最近」的？

**答**：看上面的图，比如 $5$ 右侧小于 $5$ 的最近高度是 $2$，如果我们找的不是高度 $2$ 而是更远的高度 $3$，那么我们会误认为矩形右边界最远可以是高度 $2$（3 的左边是 $2$），然而这样的矩形已经超出柱状图的范围了，不符合题目要求。

#### 写法一：三次遍历

```Python
class Solution:
    def largestRectangleArea(self, heights: List[int]) -> int:
        n = len(heights)
        left = [-1] * n
        st = []
        for i, h in enumerate(heights):
            while st and heights[st[-1]] >= h:
                st.pop()
            if st:
                left[i] = st[-1]
            st.append(i)

        right = [n] * n
        st.clear()
        for i in range(n - 1, -1, -1):
            h = heights[i]
            while st and heights[st[-1]] >= h:
                st.pop()
            if st:
                right[i] = st[-1]
            st.append(i)

        ans = 0
        for h, l, r in zip(heights, left, right):
            ans = max(ans, h * (r - l - 1))
        return ans
```

```Java
class Solution {
    public int largestRectangleArea(int[] heights) {
        int n = heights.length;
        int[] left = new int[n];
        Deque<Integer> st = new ArrayDeque<>();
        for (int i = 0; i < n; i++) {
            int h = heights[i];
            while (!st.isEmpty() && heights[st.peek()] >= h) {
                st.pop();
            }
            left[i] = st.isEmpty() ? -1 : st.peek();
            st.push(i);
        }

        int[] right = new int[n];
        st.clear();
        for (int i = n - 1; i >= 0; i--) {
            int h = heights[i];
            while (!st.isEmpty() && heights[st.peek()] >= h) {
                st.pop();
            }
            right[i] = st.isEmpty() ? n : st.peek();
            st.push(i);
        }

        int ans = 0;
        for (int i = 0; i < n; i++) {
            ans = Math.max(ans, heights[i] * (right[i] - left[i] - 1));
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    int largestRectangleArea(vector<int> &heights) {
        int n = heights.size();
        vector<int> left(n, -1);
        stack<int> st;
        for (int i = 0; i < n; i++) {
            int h = heights[i];
            while (!st.empty() && heights[st.top()] >= h) {
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
            int h = heights[i];
            while (!st.empty() && heights[st.top()] >= h) {
                st.pop();
            }
            if (!st.empty()) {
                right[i] = st.top();
            }
            st.push(i);
        }

        int ans = 0;
        for (int i = 0; i < n; i++) {
            ans = max(ans, heights[i] * (right[i] - left[i] - 1));
        }
        return ans;
    }
};
```

```C
#define MAX(a, b) ((b) > (a) ? (b) : (a))

int largestRectangleArea(int* heights, int n) {
    int* left = malloc(sizeof(int) * n);
    int* stack = malloc(sizeof(int) * (n + 1));
    int top = -1; // 栈顶下标（-1 表示栈为空）
    for (int i = 0; i < n; i++) {
        int h = heights[i];
        while (top >= 0 && heights[stack[top]] >= h) {
            top--; // 出栈
        }
        left[i] = top < 0 ? -1 : stack[top];
        stack[++top] = i; // 入栈
    }

    int* right = malloc(sizeof(int) * n);
    top = -1; // 清空栈
    for (int i = n - 1; i >= 0; i--) {
        int h = heights[i];
        while (top >= 0 && heights[stack[top]] >= h) {
            top--; // 出栈
        }
        right[i] = top < 0 ? n : stack[top];
        stack[++top] = i; // 入栈
    }

    int ans = 0;
    for (int i = 0; i < n; i++) {
        ans = MAX(ans, heights[i] * (right[i] - left[i] - 1));
    }

    free(left);
    free(right);
    free(stack);
    return ans;
}
```

```Go
func largestRectangleArea(heights []int) (ans int) {
    n := len(heights)
    left := make([]int, n)
    st := []int{-1} // 哨兵，简化 left[i] = ... 的逻辑
    for i, h := range heights {
        for len(st) > 1 && heights[st[len(st)-1]] >= h {
            st = st[:len(st)-1]
        }
        left[i] = st[len(st)-1] // 因为有哨兵，这里不需要判空
        st = append(st, i)
    }

    right := make([]int, n)
    st = st[:1]
    st[0] = n // 哨兵
    for i, h := range slices.Backward(heights) {
        for len(st) > 1 && heights[st[len(st)-1]] >= h {
            st = st[:len(st)-1]
        }
        right[i] = st[len(st)-1]
        st = append(st, i)
    }

    for i, h := range heights {
        ans = max(ans, h*(right[i]-left[i]-1))
    }
    return
}
```

```JavaScript
var largestRectangleArea = function(heights) {
    const n = heights.length;
    const left = Array(n).fill(-1);
    const st = [];
    for (let i = 0; i < n; i++) {
        const h = heights[i];
        while (st.length && heights[st[st.length - 1]] >= h) {
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
        const h = heights[i];
        while (st.length && heights[st[st.length - 1]] >= h) {
            st.pop();
        }
        if (st.length) {
            right[i] = st[st.length - 1];
        }
        st.push(i);
    }

    let ans = 0;
    for (let i = 0; i < n; i++) {
        ans = Math.max(ans, heights[i] * (right[i] - left[i] - 1));
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn largest_rectangle_area(heights: Vec<i32>) -> i32 {
        let n = heights.len();
        let mut left = vec![-1; n];
        let mut st = vec![];
        for (i, &h) in heights.iter().enumerate() {
            while !st.is_empty() && heights[*st.last().unwrap()] >= h {
                st.pop();
            }
            if let Some(&j) = st.last() {
                left[i] = j as i32;
            }
            st.push(i);
        }

        let mut right = vec![n as i32; n];
        st.clear();
        for (i, &h) in heights.iter().enumerate().rev() {
            while !st.is_empty() && heights[*st.last().unwrap()] >= h {
                st.pop();
            }
            if let Some(&j) = st.last() {
                right[i] = j as i32;
            }
            st.push(i);
        }

        let mut ans = 0;
        for ((h, l), r) in heights.into_iter().zip(left).zip(right) {
            ans = ans.max(h * (r - l - 1));
        }
        ans
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 为 $heights$ 的长度。每个元素入栈出栈各至多一次，所以二重循环是 $O(n)$ 的。
- 空间复杂度：$O(n)$。

#### 写法二：两次遍历

为了做到两次遍历，以及写法三的一次遍历，首先，把 $right[i]$ 的定义略作修改，调整为：在 $i$ 右侧的**小于或等于** $h=heights[i]$ 的最近元素的下标。

如果 $heights$ 中没有相同的元素，这样修改不影响 $right[i]$。

如果 $heights$ 中有相同的元素呢？比如 $heights=[1,3,4,3,2]$，左边那个 $3$ 的 $right[i]$ 会变小，导致矩形面积变小，这是否会导致计算错误？

不会。注意在这种情况下，这两个高为 $3$ 的柱子，对应的矩形面积（在写法一中）是一样大的，虽然（在写法二中）左边那个 $3$ 的矩形面积变小了，但右边那个 $3$ 的矩形面积是不变的，所以我们**不会错过正确答案**。

修改 $right[i]$ 的定义后，我们可以把 $left$ 和 $right$ 合在一起计算，从而减少一次遍历：

- 在计算 $left$ 的过程中，如果栈顶元素 $\ge heights[i]$，那么 $i$ 就是栈顶元素的 $right$。

```Python
class Solution:
    def largestRectangleArea(self, heights: List[int]) -> int:
        n = len(heights)
        left = [-1] * n
        right = [n] * n
        st = []
        for i, h in enumerate(heights):
            while st and heights[st[-1]] >= h:
                right[st.pop()] = i
            if st:
                left[i] = st[-1]
            st.append(i)

        ans = 0
        for h, l, r in zip(heights, left, right):
            ans = max(ans, h * (r - l - 1))
        return ans
```

```Java
class Solution {
    public int largestRectangleArea(int[] heights) {
        int n = heights.length;
        int[] left = new int[n];
        int[] right = new int[n];
        Arrays.fill(right, n);
        Deque<Integer> st = new ArrayDeque<>();
        for (int i = 0; i < n; i++) {
            int h = heights[i];
            while (!st.isEmpty() && heights[st.peek()] >= h) {
                right[st.pop()] = i;
            }
            left[i] = st.isEmpty() ? -1 : st.peek();
            st.push(i);
        }

        int ans = 0;
        for (int i = 0; i < n; i++) {
            ans = Math.max(ans, heights[i] * (right[i] - left[i] - 1));
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    int largestRectangleArea(vector<int> &heights) {
        int n = heights.size();
        vector<int> left(n, -1);
        vector<int> right(n, n);
        stack<int> st;
        for (int i = 0; i < n; i++) {
            int h = heights[i];
            while (!st.empty() && heights[st.top()] >= h) {
                right[st.top()] = i;
                st.pop();
            }
            if (!st.empty()) {
                left[i] = st.top();
            }
            st.push(i);
        }

        int ans = 0;
        for (int i = 0; i < n; i++) {
            ans = max(ans, heights[i] * (right[i] - left[i] - 1));
        }
        return ans;
    }
};
```

```C
#define MAX(a, b) ((b) > (a) ? (b) : (a))

int largestRectangleArea(int* heights, int n) {
    int* left = malloc(sizeof(int) * n);
    int* right = malloc(sizeof(int) * n);
    int* stack = malloc(sizeof(int) * (n + 1));
    int top = -1; // 栈顶下标（-1 表示栈为空）
    for (int i = 0; i < n; i++) {
        int h = heights[i];
        while (top >= 0 && heights[stack[top]] >= h) {
            right[stack[top--]] = i;
        }
        left[i] = top < 0 ? -1 : stack[top];
        stack[++top] = i; // 入栈
    }

    // 栈中剩余元素的 right 都是 n
    for (int i = 0; i <= top; i++) {
        right[stack[i]] = n;
    }

    int ans = 0;
    for (int i = 0; i < n; i++) {
        ans = MAX(ans, heights[i] * (right[i] - left[i] - 1));
    }

    free(left);
    free(right);
    free(stack);
    return ans;
}
```

```Go
func largestRectangleArea(heights []int) (ans int) {
    n := len(heights)
    left := make([]int, n)
    right := make([]int, n)
    st := []int{-1} // 哨兵，简化 left[i] = ... 的逻辑
    for i, h := range heights {
        for len(st) > 1 && heights[st[len(st)-1]] >= h {
            right[st[len(st)-1]] = i
            st = st[:len(st)-1]
        }
        left[i] = st[len(st)-1] // 因为有哨兵，这里不需要判空
        st = append(st, i)
    }

    // 栈中剩余元素的 right 都是 n
    for _, i := range st[1:] {
        right[i] = n
    }

    for i, h := range heights {
        ans = max(ans, h*(right[i]-left[i]-1))
    }
    return
}
```

```JavaScript
var largestRectangleArea = function(heights) {
    const n = heights.length;
    const left = Array(n).fill(-1);
    const right = Array(n).fill(n);
    const st = [];
    for (let i = 0; i < n; i++) {
        const h = heights[i];
        while (st.length && heights[st[st.length - 1]] >= h) {
            right[st.pop()] = i;
        }
        if (st.length) {
            left[i] = st[st.length - 1];
        }
        st.push(i);
    }

    let ans = 0;
    for (let i = 0; i < n; i++) {
        ans = Math.max(ans, heights[i] * (right[i] - left[i] - 1));
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn largest_rectangle_area(heights: Vec<i32>) -> i32 {
        let n = heights.len();
        let mut left = vec![-1; n];
        let mut right = vec![n as i32; n];
        let mut st = vec![];
        for (i, &h) in heights.iter().enumerate() {
            while !st.is_empty() && heights[*st.last().unwrap()] >= h {
                right[st.pop().unwrap()] = i as i32;
            }
            if let Some(&j) = st.last() {
                left[i] = j as i32;
            }
            st.push(i);
        }

        let mut ans = 0;
        for ((h, l), r) in heights.into_iter().zip(left).zip(right) {
            ans = ans.max(h * (r - l - 1));
        }
        ans
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 为 $heights$ 的长度。每个元素入栈出栈各至多一次，所以二重循环是 $O(n)$ 的。
- 空间复杂度：$O(n)$。

#### 写法三：一次遍历

写法二告诉我们，栈顶出栈时，当前下标就是栈顶的 $right$。

如果此刻能顺带求出栈顶的 $left$，那不就能一步到位，一次遍历就搞定了？

想一想，栈顶的 $left$ 在哪？

由于单调栈是底小顶大的，栈顶下面那个柱子的高度一定比栈顶小，所以栈顶下面的值就是 $left$。

为简化代码逻辑，可以在一开始把 $-1$ 入栈，当作哨兵。当栈中只有一个数的时候，栈顶下面那个数刚好就是 $-1$，对应 $left[i]=-1$ 的情况。

此外，循环结束的时候，栈中还有数据，这些数据也要计算矩形面积。处理这种情况可以再写一个循环，但更简单的办法是，往 $heights$ 的末尾加一个 $-1$（或者任意 $\le min(heights)$ 的数），从而保证循环结束的时候，栈一定是空的（不包括哨兵）。

```Python
class Solution:
    def largestRectangleArea(self, heights: List[int]) -> int:
        heights.append(-1)  # 最后大火收汁，用 -1 把栈清空
        st = [-1]  # 在栈中只有一个数的时候，栈顶的「下面那个数」是 -1，对应 left[i] = -1 的情况
        ans = 0
        for right, h in enumerate(heights):
            while len(st) > 1 and heights[st[-1]] >= h:
                i = st.pop()  # 矩形的高（的下标）
                left = st[-1]  # 栈顶下面那个数就是 left
                ans = max(ans, heights[i] * (right - left - 1))
            st.append(right)
        return ans
```

```Java
class Solution {
    public int largestRectangleArea(int[] heights) {
        int n = heights.length;
        Deque<Integer> st = new ArrayDeque<>();
        st.push(-1); // 在栈中只有一个数的时候，栈顶的「下面那个数」是 -1，对应 left[i] = -1 的情况
        int ans = 0;
        for (int right = 0; right <= n; right++) {
            int h = right < n ? heights[right] : -1;
            while (st.size() > 1 && heights[st.peek()] >= h) {
                int i = st.pop(); // 矩形的高（的下标）
                int left = st.peek(); // 栈顶下面那个数就是 left
                ans = Math.max(ans, heights[i] * (right - left - 1));
            }
            st.push(right);
        }
        return ans;
    }
}
```

```Java
// Java 数组
class Solution {
    public int largestRectangleArea(int[] heights) {
        int n = heights.length;
        int[] st = new int[n + 1];
        int top = -1; // 栈顶下标
        st[++top] = -1; // 在栈中只有一个数的时候，栈顶的「下面那个数」是 -1，对应 left[i] = -1 的情况
        int ans = 0;
        for (int right = 0; right <= n; right++) {
            int h = right < n ? heights[right] : -1;
            while (top > 0 && heights[st[top]] >= h) {
                int i = st[top--]; // 矩形的高（的下标）
                int left = st[top]; // 栈顶下面那个数就是 left
                ans = Math.max(ans, heights[i] * (right - left - 1));
            }
            st[++top] = right;
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    int largestRectangleArea(vector<int>& heights) {
        heights.push_back(-1); // 最后大火收汁，用 -1 把栈清空
        stack<int> st;
        st.push(-1); // 在栈中只有一个数的时候，栈顶的「下面那个数」是 -1，对应 left[i] = -1 的情况
        int ans = 0;
        for (int right = 0; right < heights.size(); right++) {
            int h = heights[right];
            while (st.size() > 1 && heights[st.top()] >= h) {
                int i = st.top(); // 矩形的高（的下标）
                st.pop();
                int left = st.top(); // 栈顶下面那个数就是 left
                ans = max(ans, heights[i] * (right - left - 1));
            }
            st.push(right);
        }
        return ans;
    }
};
```

```C
#define MAX(a, b) ((b) > (a) ? (b) : (a))

int largestRectangleArea(int* heights, int n) {
    int* stack = malloc((n + 1) * sizeof(int));
    int top = -1; // 栈顶下标
    stack[++top] = -1; // 在栈中只有一个数的时候，栈顶的「下面那个数」是 -1，对应 left[i] = -1 的情况
    int ans = 0;

    for (int right = 0; right <= n; right++) {
        int h = right < n ? heights[right] : -1;
        while (top > 0 && heights[stack[top]] >= h) {
            int i = stack[top--]; // 矩形的高（的下标）
            int left = stack[top]; // 栈顶下面那个数就是 left
            ans = MAX(ans, heights[i] * (right - left - 1));
        }
        stack[++top] = right;
    }

    free(stack);
    return ans;
}
```

```Go
func largestRectangleArea(heights []int) (ans int) {
    heights = append(heights, -1) // 最后大火收汁，用 -1 把栈清空
    st := []int{-1} // 在栈中只有一个数的时候，栈顶的「下面那个数」是 -1，对应 left[i] = -1 的情况
    for right, h := range heights {
        for len(st) > 1 && heights[st[len(st)-1]] >= h {
            i := st[len(st)-1] // 矩形的高（的下标）
            st = st[:len(st)-1]
            left := st[len(st)-1] // 栈顶下面那个数就是 left
            ans = max(ans, heights[i]*(right-left-1))
        }
        st = append(st, right)
    }
    return
}
```

```JavaScript
var largestRectangleArea = function(heights) {
    heights.push(-1); // 最后大火收汁，用 -1 把栈清空
    const st = [-1]; // 在栈中只有一个数的时候，栈顶的「下面那个数」是 -1，对应 left[i] = -1 的情况
    let ans = 0;
    for (let right = 0; right < heights.length; right++) {
        const h = heights[right];
        while (st.length > 1 && heights[st[st.length - 1]] >= h) {
            const i = st.pop(); // 矩形的高（的下标）
            const left = st[st.length - 1]; // 栈顶下面那个数就是 left
            ans = Math.max(ans, heights[i] * (right - left - 1));
        }
        st.push(right);
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn largest_rectangle_area(mut heights: Vec<i32>) -> i32 {
        heights.push(-1); // 最后大火收汁，用 -1 把栈清空
        let mut st = vec![-1]; // 在栈中只有一个数的时候，栈顶的「下面那个数」是 -1，对应 left[i] = -1 的情况
        let mut ans = 0;
        for (right, &h) in heights.iter().enumerate() {
            let right = right as i32;
            while st.len() > 1 && heights[*st.last().unwrap() as usize] >= h {
                let i = st.pop().unwrap() as usize; // 矩形的高（的下标）
                let left = *st.last().unwrap(); // 栈顶下面那个数就是 left
                ans = ans.max(heights[i] * (right - left - 1));
            }
            st.push(right);
        }
        ans
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 为 $heights$ 的长度。每个元素入栈出栈各至多一次，所以二重循环是 $O(n)$ 的。
- 空间复杂度：$O(min(n,U))$。其中 $U$ 为 $heights$ 中的不同元素个数。注意栈中没有重复元素。

#### 专题训练

见下面单调栈题单的「**二、矩形**」。

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
