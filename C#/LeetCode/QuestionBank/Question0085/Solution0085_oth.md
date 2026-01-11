### [直接调用 84 题代码解决（Python/Java/C++/C/Go/JS/Rust）](https://leetcode.cn/problems/maximal-rectangle/solutions/3704011/zhi-jie-diao-yong-84-ti-dai-ma-jie-jue-p-49at/)

回顾一下，这是 [84\. 柱状图中最大的矩形](https://leetcode.cn/problems/largest-rectangle-in-histogram/) 的图：

![](./assets/img/Solution0085_oth_01.jpg)

对于本题，设 $matrix$ 有 $m$ 行，我们可以枚举矩形的底边，做 $m$ 次 $84$ 题。

![](./assets/img/Solution0085_oth_02.png)

- 以第一行为底的柱子高度为 $[1,0,1,0,0]$，最大矩形面积为 $1$。
- 以第二行为底的柱子高度为 $[2,0,2,1,1]$，最大矩形面积为 $3$。
- 以第三行为底的柱子高度为 $[3,1,3,2,2]$，最大矩形面积为 $6$。
- 以第四行为底的柱子高度为 $[4,0,0,3,0]$，最大矩形面积为 $4$。
- 答案为 $max(1,3,6,4)=6$。

由于我们枚举的是矩形的底边，如果 $matrix[i][j]=0$，那么没有柱子，高度等于 $0$。否则，在上一行柱子的基础上，把柱子高度增加 $1$。形象地说，就是在柱子下面垫一块石头，把柱子抬高。

```Python
class Solution:
    # 84. 柱状图中最大的矩形
    def largestRectangleArea(self, heights: List[int]) -> int:
        st = [-1]  # 在栈中只有一个数的时候，栈顶的「下面那个数」是 -1，对应 left[i] = -1 的情况
        ans = 0
        for right, h in enumerate(heights):
            while len(st) > 1 and heights[st[-1]] >= h:
                i = st.pop()  # 矩形的高（的下标）
                left = st[-1]  # 栈顶下面那个数就是 left
                ans = max(ans, heights[i] * (right - left - 1))
            st.append(right)
        return ans

    def maximalRectangle(self, matrix: List[List[str]]) -> int:
        n = len(matrix[0])
        heights = [0] * (n + 1)  # 末尾多一个 0，理由见我 84 题题解
        ans = 0
        for row in matrix:
            # 计算底边为 row 的柱子高度
            for j, c in enumerate(row):
                if c == '0':
                    heights[j] = 0  # 柱子高度为 0
                else:
                    heights[j] += 1  # 柱子高度加一
            ans = max(ans, self.largestRectangleArea(heights))  # 调用 84 题代码
        return ans
```

```Java
class Solution {
    int maximalRectangle(char[][] matrix) {
        int n = matrix[0].length;
        int[] heights = new int[n + 1]; // 末尾多一个 0，理由见我 84 题题解
        int ans = 0;
        for (char[] row : matrix) {
            // 计算底边为 row 的柱子高度
            for (int j = 0; j < n; j++) {
                if (row[j] == '0') {
                    heights[j] = 0; // 柱子高度为 0
                } else {
                    heights[j]++; // 柱子高度加一
                }
            }
            ans = Math.max(ans, largestRectangleArea(heights)); // 调用 84 题代码
        }
        return ans;
    }

    // 84. 柱状图中最大的矩形
    private int largestRectangleArea(int[] heights) {
        int n = heights.length;
        int[] st = new int[n]; // 用数组模拟栈
        int top = -1; // 栈顶下标
        st[++top] = -1; // 在栈中只有一个数的时候，栈顶的「下面那个数」是 -1，对应 left[i] = -1 的情况
        int ans = 0;
        for (int right = 0; right < n; right++) {
            int h = heights[right];
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
    // 84. 柱状图中最大的矩形
    int largestRectangleArea(vector<int>& heights) {
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

public:
    int maximalRectangle(vector<vector<char>>& matrix) {
        int n = matrix[0].size();
        vector<int> heights(n + 1); // 末尾多一个 0，理由见我 84 题题解
        int ans = 0;
        for (auto& row : matrix) {
            // 计算底边为 row 的柱子高度
            for (int j = 0; j < n; j++) {
                if (row[j] == '0') {
                    heights[j] = 0; // 柱子高度为 0
                } else {
                    heights[j]++; // 柱子高度加一
                }
            }
            ans = max(ans, largestRectangleArea(heights)); // 调用 84 题代码
        }
        return ans;
    }
};
```

```C
#define MAX(a, b) ((b) > (a) ? (b) : (a))

// 84. 柱状图中最大的矩形
int largestRectangleArea(int* heights, int n) {
    int* stack = malloc(n * sizeof(int));
    int top = -1; // 栈顶下标
    stack[++top] = -1; // 在栈中只有一个数的时候，栈顶的「下面那个数」是 -1，对应 left[i] = -1 的情况
    int ans = 0;
    for (int right = 0; right < n; right++) {
        int h = heights[right];
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

int maximalRectangle(char** matrix, int matrixSize, int* matrixColSize) {
    int n = matrixColSize[0];
    int* heights = calloc(n + 1, sizeof(int)); // 末尾多一个 0，理由见我 84 题题解
    int ans = 0;
    for (int i = 0; i < matrixSize; i++) {
        char* row = matrix[i];
        // 计算底边为 row 的柱子高度
        for (int j = 0; j < n; j++) {
            if (row[j] == '0') {
                heights[j] = 0; // 柱子高度为 0
            } else {
                heights[j]++; // 柱子高度加一
            }
        }
        ans = MAX(ans, largestRectangleArea(heights, n + 1)); // 调用 84 题代码，注意传入的是 n+1
    }
    free(heights);
    return ans;
}
```

```Go
// 84. 柱状图中最大的矩形
func largestRectangleArea(heights []int) (ans int) {
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

func maximalRectangle(matrix [][]byte) (ans int) {
    heights := make([]int, len(matrix[0])+1) // 末尾多一个 0，理由见我 84 题题解
    for _, row := range matrix {
        // 计算底边为 row 的柱子高度
        for j, c := range row {
            if c == '0' {
                heights[j] = 0 // 柱子高度为 0
            } else {
                heights[j]++ // 柱子高度加一
            }
        }
        ans = max(ans, largestRectangleArea(heights)) // 调用 84 题代码
    }
    return
}
```

```JavaScript
// 84. 柱状图中最大的矩形
var largestRectangleArea = function(heights) {
    const st = [-1]; // 在栈中只有一个数的时候，栈顶的「下面那个数」是 -1，对应 left[i] = -1 的情况
    let ans = 0;
    for (let right = 0; right < heights.length; right++) {
        const h = heights[right]
        while (st.length > 1 && heights[st[st.length - 1]] >= h) {
            const i = st.pop(); // 矩形的高（的下标）
            const left = st[st.length - 1]; // 栈顶下面那个数就是 left
            ans = Math.max(ans, heights[i] * (right - left - 1));
        }
        st.push(right);
    }
    return ans;
};

var maximalRectangle = function(matrix) {
    const n = matrix[0].length;
    let heights = Array(n + 1).fill(0); // 末尾多一个 0，理由见我 84 题题解
    let ans = 0;
    for (const row of matrix) {
        // 计算底边为 row 的柱子高度
        for (let j = 0; j < n; j++) {
            if (row[j] === '0') {
                heights[j] = 0; // 柱子高度为 0
            } else {
                heights[j]++; // 柱子高度加一
            }
        }
        ans = Math.max(ans, largestRectangleArea(heights)); // 调用 84 题代码
    }
    return ans;
};
```

```Rust
impl Solution {
    // 84. 柱状图中最大的矩形
    fn largest_rectangle_area(heights: &[i32]) -> i32 {
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

    pub fn maximal_rectangle(matrix: Vec<Vec<char>>) -> i32 {
        let n = matrix[0].len();
        let mut heights = vec![0; n + 1]; // 末尾多一个 0，理由见我 84 题题解
        let mut ans = 0;
        for row in matrix {
            // 计算底边为 row 的柱子高度
            for (j, c) in row.into_iter().enumerate() {
                if c == '0' {
                    heights[j] = 0; // 柱子高度为 0
                } else {
                    heights[j] += 1; // 柱子高度加一
                }
            }
            ans = ans.max(Self::largest_rectangle_area(&heights)); // 调用 84 题代码
        }
        ans
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(mn)$，其中 $m$ 和 $n$ 分别为 $matrix$ 的行数和列数。做 $m$ 次 $84$ 题，每次 $O(n)$。
- 空间复杂度：$O(n)$。

#### 相似题目

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
