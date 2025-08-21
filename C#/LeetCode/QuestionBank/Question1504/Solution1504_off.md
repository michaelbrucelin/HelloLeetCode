### [统计全 1 子矩形](https://leetcode.cn/problems/count-submatrices-with-all-ones/solutions/336410/tong-ji-quan-1-zi-ju-xing-by-leetcode-solution/)

#### 方法一：枚举

**思路与算法**

首先很直观的想法，我们可以枚举矩阵中的每个位置 $(i,j)$，统计以其作为右下角时，有多少个元素全部都是 $1$ 的子矩形，那么我们就能不重不漏地统计出满足条件的子矩形个数。那么枚举以后，我们怎么统计满足条件的子矩形个数呢？

我们预处理 $row$ 数组，其中 $row[i][j]$ 代表矩阵中 $(i,j)$ 向左延伸连续 $1$ 的个数，容易得出递推式：

$$row[i][j]=\begin{cases}0, & mat[i][j]=0\\ row[i][j-1]+1, & mat[i][j]=1\end{cases}$$

有了 $row$ 数组以后，如果要统计以 $(i,j)$ 为右下角满足条件的子矩形，我们就可以枚举子矩形的高，看当前高度有多少满足条件的子矩形。我们从第 $i$ 行开始自下而上枚举。第 $i$ 行，满足条件的子矩形有 $row[i][j]$ 个；第 $i-1$ 行，满足条件的子矩形有 $min(row[i][j],row[i-1][j])$ 个，因为得这两行全为 $1$ 才满足条件。再往上也是一样，得一直取最小值才能满足条件。因此，我们才自下而上枚举，可以在常数时间内算出最小值。

根据这个思路，对于每个右下角点 $(i,j)$，可以在线性时间复杂度内算出满足条件的子矩形个数。遍历完所有点后，可以算出所有满足条件的子矩形个数。

```Python
class Solution:
    def numSubmat(self, mat: List[List[int]]) -> int:
        m, n = len(mat), len(mat[0])
        res = 0
        row = [[0] * n for _ in range(m)]
        for i in range(m):
            for j in range(n):
                if j == 0:
                    row[i][j] = mat[i][j]
                else:
                    row[i][j] = 0 if mat[i][j] == 0 else row[i][j - 1] + 1
                cur = row[i][j]
                for k in range(i, -1, -1):
                    cur = min(cur, row[k][j])
                    if cur == 0:
                        break
                    res += cur
        return res
```

```C++
class Solution {
public:
    int numSubmat(vector<vector<int>>& mat) {
        int m = mat.size(), n = mat[0].size();
        int res = 0;
        vector<vector<int>> row(m, vector<int>(n, 0));
        
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (j == 0) {
                    row[i][j] = mat[i][j];
                } else {
                    row[i][j] = (mat[i][j] == 0) ? 0 : row[i][j - 1] + 1;
                }
                int cur = row[i][j];
                for (int k = i; k >= 0; --k) {
                    cur = min(cur, row[k][j]);
                    if (cur == 0) {
                        break;
                    }
                    res += cur;
                }
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int numSubmat(int[][] mat) {
        int m = mat.length, n = mat[0].length;
        int res = 0;
        int[][] row = new int[m][n];
        
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (j == 0) {
                    row[i][j] = mat[i][j];
                } else {
                    row[i][j] = mat[i][j] == 0 ? 0 : row[i][j - 1] + 1;
                }
                int cur = row[i][j];
                for (int k = i; k >= 0; k--) {
                    cur = Math.min(cur, row[k][j]);
                    if (cur == 0) {
                        break;
                    }
                    res += cur;
                }
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int NumSubmat(int[][] mat) {
        int m = mat.Length, n = mat[0].Length;
        int res = 0;
        int[][] row = new int[m][];
        for (int i = 0; i < m; i++) {
            row[i] = new int[n];
        }
        
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (j == 0) {
                    row[i][j] = mat[i][j];
                } else {
                    row[i][j] = mat[i][j] == 0 ? 0 : row[i][j - 1] + 1;
                }
                int cur = row[i][j];
                for (int k = i; k >= 0; k--) {
                    cur = Math.Min(cur, row[k][j]);
                    if (cur == 0) {
                        break;
                    }
                    res += cur;
                }
            }
        }
        return res;
    }
}
```

```Go
func numSubmat(mat [][]int) int {
    m, n := len(mat), len(mat[0])
    res := 0
    row := make([][]int, m)
    for i := range row {
        row[i] = make([]int, n)
    }
    
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            if j == 0 {
                row[i][j] = mat[i][j]
            } else {
                if mat[i][j] == 0 {
                    row[i][j] = 0
                } else {
                    row[i][j] = row[i][j - 1] + 1
                }
            }
            cur := row[i][j]
            for k := i; k >= 0; k-- {
                if row[k][j] < cur {
                    cur = row[k][j]
                }
                if cur == 0 {
                    break
                }
                res += cur
            }
        }
    }
    return res
}
```

```C
int numSubmat(int** mat, int matSize, int* matColSize) {
    int m = matSize, n = matColSize[0];
    int res = 0;
    int** row = (int**)malloc(m * sizeof(int*));
    for (int i = 0; i < m; i++) {
        row[i] = (int*)malloc(n * sizeof(int));
    }
    
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (j == 0) {
                row[i][j] = mat[i][j];
            } else {
                row[i][j] = mat[i][j] == 0 ? 0 : row[i][j - 1] + 1;
            }
            int cur = row[i][j];
            for (int k = i; k >= 0; k--) {
                cur = cur < row[k][j] ? cur : row[k][j];
                if (cur == 0) {
                    break;
                }
                res += cur;
            }
        }
    }
    
    for (int i = 0; i < m; i++) {
        free(row[i]);
    }
    free(row);
    return res;
}
```

```JavaScript
var numSubmat = function(mat) {
    const m = mat.length, n = mat[0].length;
    let res = 0;
    const row = new Array(m);
    for (let i = 0; i < m; i++) {
        row[i] = new Array(n).fill(0);
    }
    
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (j === 0) {
                row[i][j] = mat[i][j];
            } else {
                row[i][j] = mat[i][j] === 0 ? 0 : row[i][j - 1] + 1;
            }
            let cur = row[i][j];
            for (let k = i; k >= 0; k--) {
                cur = Math.min(cur, row[k][j]);
                if (cur === 0) {
                    break;
                }
                res += cur;
            }
        }
    }
    return res;
};
```

```TypeScript
function numSubmat(mat: number[][]): number {
    const m = mat.length, n = mat[0].length;
    let res = 0;
    const row: number[][] = new Array(m);
    for (let i = 0; i < m; i++) {
        row[i] = new Array(n).fill(0);
    }
    
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (j === 0) {
                row[i][j] = mat[i][j];
            } else {
                row[i][j] = mat[i][j] === 0 ? 0 : row[i][j - 1] + 1;
            }
            let cur = row[i][j];
            for (let k = i; k >= 0; k--) {
                cur = Math.min(cur, row[k][j]);
                if (cur === 0) {
                    break;
                }
                res += cur;
            }
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn num_submat(mat: Vec<Vec<i32>>) -> i32 {
        let m = mat.len();
        let n = mat[0].len();
        let mut res = 0;
        let mut row = vec![vec![0; n]; m];
        
        for i in 0..m {
            for j in 0..n {
                row[i][j] = if j == 0 {
                    mat[i][j]
                } else {
                    if mat[i][j] == 0 { 0 } else { row[i][j - 1] + 1 }
                };
                let mut cur = row[i][j];
                for k in (0..=i).rev() {
                    cur = cur.min(row[k][j]);
                    if cur == 0 {
                        break;
                    }
                    res += cur;
                }
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m^2\times n)$，其中 $m$ 为矩阵行数，$n$ 为矩阵列数。代码中涉及三重循环。
- 空间复杂度：$O(m\times n)$。

#### 方法二：单调栈

**思路与算法**

这题的目标是统计矩阵中所有元素全部为1的子矩形的数量。我们可以采用**枚举子矩形右下角**的方法，逐步计算满足条件的子矩形的个数。具体做法如下：

1. 以每一行作为**底边**进行处理
    首先，将矩阵每一行转化为**柱状图**的高度数组 $heights$，表示当前位置连续为 $1$ 的高度。
    例如，在某一行，$heights[j]$ 表示以当前行为底，$j$ 列中自底向上连续 $1$ 的个数。
2. 枚举每一列作为**右边界**
    对于每一行计算完成后，我们可以利用单调栈找到每个 $heights[j]$ 左边第一个比它低的柱子位置。
3. 根据左右边界统计子矩形的数量
    假设在右边界为 $j$ 时，找到左边的最近低柱子位置为 $i$（用单调栈维护）。
    对于这个位置，可以分为两类子矩形：
    左边界小于等于 $i$：在左边界为 $i$ 时已统计完对应的子矩形，扩展到当前 $j$，得到相同数量的子矩形。
    左边界大于 $i$：矩形左边界可以是 $i+1$ 到 $j$，总共 $j-i$ 个位置；每个位置都可以组成目前高度范围内的不同子矩形（高度为 $1$ 到 $heights[j]$，即有 $heights[j]$ 种高度组合），因此一共有 $j-left\times heights[j]$ 个子矩形。
4. 累加总数
    将每个右边界的子矩形数量累加起来，即得到整个矩阵中所有满足元素全为 $1$ 的子矩形数。

```Python
class Solution:
    def numSubmat(self, mat: List[List[int]]) -> int:
        heights = [0] * len(mat[0])
        res = 0
        for row in mat:
            for i, x in enumerate(row):
                heights[i] = 0 if x == 0 else heights[i] + 1    
            stack = [[-1, 0, -1]] 
            for i, h in enumerate(heights):
                while stack[-1][2] >= h:
                    stack.pop()
                j, prev, _ = stack[-1]
                cur = prev + (i - j) * h
                stack.append([i, cur, h])
                res += cur
        return res
```

```C++
class Solution {
public:
    int numSubmat(vector<vector<int>>& mat) {
        int n = mat[0].size();
        vector<int> heights(n, 0);
        int res = 0;
        for (const auto& row : mat) {
            for (int i = 0; i < n; ++i) {
                heights[i] = (row[i] == 0) ? 0 : heights[i] + 1;
            }
            stack<vector<int>> st;
            st.push({-1, 0, -1});
            for (int i = 0; i < n; ++i) {
                int h = heights[i];
                while (st.top()[2] >= h) {
                    st.pop();
                }
                auto& top = st.top();
                int j = top[0];
                int prev = top[1];
                int cur = prev + (i - j) * h;
                st.push({i, cur, h});
                res += cur;
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int numSubmat(int[][] mat) {
        int n = mat[0].length;
        int[] heights = new int[n];
        int res = 0;
        for (int[] row : mat) {
            for (int i = 0; i < n; i++) {
                heights[i] = row[i] == 0 ? 0 : heights[i] + 1;
            }
            Stack<int[]> stack = new Stack<>();
            stack.push(new int[]{-1, 0, -1});
            for (int i = 0; i < n; i++) {
                int h = heights[i];
                while (stack.peek()[2] >= h) {
                    stack.pop();
                }
                int[] top = stack.peek();
                int j = top[0];
                int prev = top[1];
                int cur = prev + (i - j) * h;
                stack.push(new int[]{i, cur, h});
                res += cur;
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int NumSubmat(int[][] mat) {
        int n = mat[0].Length;
        int[] heights = new int[n];
        int res = 0;
        foreach (var row in mat) {
            for (int i = 0; i < n; i++) {
                heights[i] = row[i] == 0 ? 0 : heights[i] + 1;
            }
            var stack = new Stack<int[]>();
            stack.Push(new int[]{-1, 0, -1});
            for (int i = 0; i < n; i++) {
                int h = heights[i];
                while (stack.Peek()[2] >= h) {
                    stack.Pop();
                }
                var top = stack.Peek();
                int j = top[0];
                int prev = top[1];
                int cur = prev + (i - j) * h;
                stack.Push(new int[]{i, cur, h});
                res += cur;
            }
        }
        return res;
    }
}
```

```Go
func numSubmat(mat [][]int) int {
    n := len(mat[0])
    heights := make([]int, n)
    res := 0
    for _, row := range mat {
        for i := 0; i < n; i++ {
            if row[i] == 0 {
                heights[i] = 0
            } else {
                heights[i]++
            }
        }
        stack := [][3]int{{-1, 0, -1}}
        for i, h := range heights {
            for len(stack) > 1 && stack[len(stack) - 1][2] >= h {
                stack = stack[:len(stack) - 1]
            }
            top := stack[len(stack) - 1]
            j, prev := top[0], top[1]
            cur := prev + (i - j) * h
            stack = append(stack, [3]int{i, cur, h})
            res += cur
        }
    }
    return res
}
```

```C
int numSubmat(int** mat, int matSize, int* matColSize) {
    int n = matColSize[0];
    int heights[n];
    int res = 0;
    memset(heights, 0, sizeof(heights));

    int stack[n + 1][3];
    int top = 0;
    for (int r = 0; r < matSize; r++) {
        for (int i = 0; i < n; i++) {
            heights[i] = mat[r][i] == 0 ? 0 : heights[i] + 1;
        }
        top = 0;
        stack[top][0] = -1;
        stack[top][1] = 0;
        stack[top][2] = -1;
        top++;
        for (int i = 0; i < n; i++) {
            int h = heights[i];
            while (top > 0 && stack[top - 1][2] >= h) {
                top--;
            }
            int j = stack[top - 1][0];
            int prev = stack[top - 1][1];
            int cur = prev + (i - j) * h;
            stack[top][0] = i;
            stack[top][1] = cur;
            stack[top][2] = h;
            top++;
            res += cur;
        }
    }
    return res;
}
```

```JavaScript
var numSubmat = function(mat) {
    const n = mat[0].length;
    const heights = new Array(n).fill(0);
    let res = 0;
    for (const row of mat) {
        for (let i = 0; i < n; i++) {
            heights[i] = row[i] === 0 ? 0 : heights[i] + 1;
        }
        const stack = [[-1, 0, -1]];
        for (let i = 0; i < n; i++) {
            const h = heights[i];
            while (stack[stack.length-1][2] >= h) {
                stack.pop();
            }
            const [j, prev] = stack[stack.length-1];
            const cur = prev + (i - j) * h;
            stack.push([i, cur, h]);
            res += cur;
        }
    }
    return res;
};
```

```TypeScript
function numSubmat(mat: number[][]): number {
    const n = mat[0].length;
    const heights: number[] = new Array(n).fill(0);
    let res = 0;
    for (const row of mat) {
        for (let i = 0; i < n; i++) {
            heights[i] = row[i] === 0 ? 0 : heights[i] + 1;
        }
        const stack: [number, number, number][] = [[-1, 0, -1]];
        for (let i = 0; i < n; i++) {
            const h = heights[i];
            while (stack[stack.length-1][2] >= h) {
                stack.pop();
            }
            const [j, prev] = stack[stack.length-1];
            const cur = prev + (i - j) * h;
            stack.push([i, cur, h]);
            res += cur;
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn num_submat(mat: Vec<Vec<i32>>) -> i32 {
        let n = mat[0].len();
        let mut heights = vec![0; n];
        let mut res = 0;
        for row in mat {
            for i in 0..n {
                heights[i] = if row[i] == 0 { 0 } else { heights[i] + 1 };
            }
            let mut stack: Vec<(i32, i32, i32)> = vec![(-1, 0, -1)];
            for (i, &h) in heights.iter().enumerate() {
                let i = i as i32;
                let h = h as i32;
                while stack.last().unwrap().2 >= h {
                    stack.pop();
                }
                let (j, prev) = (stack.last().unwrap().0, stack.last().unwrap().1);
                let cur = prev + (i - j) * h;
                stack.push((i, cur, h));
                res += cur;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m\times n)$，其中 $m$ 为矩阵行数，$n$ 为矩阵列数。每一行需要更新 $heights$ 数组，操作时间为 $O(n)$。因此，逐行处理的总时间为 $O(m\times n)$。在每一行中，我们使用单调栈来找到每个柱子的左右边界。每个元素会入栈和出栈各至多一次，因此，整个过程中每行的单调栈操作为 $O(n)$。所以，整体单调栈操作的时间为 $O(m\times n)$。
- 空间复杂度：$O(n)$。
