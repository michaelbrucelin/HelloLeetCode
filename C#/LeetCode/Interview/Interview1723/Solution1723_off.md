### [最大黑方阵](https://leetcode.cn/problems/max-black-square-lcci/solutions/2260047/zui-da-hei-fang-zhen-by-leetcode-solutio-8129/?envType=problem-list-v2&envId=tBJHVASZ)

#### 方法一：动态规划

**思路与算法**

由于输入中 $0$ 代表黑色相似，因此寻找四条边皆为黑色像素的最大子方阵等价于寻找边界全部由 $0$ 组成的最大正方形子矩阵。

我们假设以 $(x,y)$ 为右下方顶点的最大的正方形边长为 $l$，此时正方形的四个顶点分别为 $(x-l+1,y-l+1),(x,y-l+1),(x-l+1,y),(x,y)$，此时需要保证正方形的四条边上的数字均为 $0$。我们设 $left[x][y]$ 表示以 $(x,y)$ 为起点左侧连续 $0$ 的最大数目，$right[x][y]$ 表示以 $(x,y)$ 为起点右侧连续 $0$ 的最大数目，$up[x][y]$ 表示从 $(x,y)$ 为起点上方连续 $0$ 的最大数目，$down[x][y]$ 表示以 $(x,y)$ 为起点下方连续 $0$ 的最大数目。此时正方形的四条边中以四个顶点为起点的连续 $0$ 的数目分别为：上侧边中以 $(x-l+1,y-l+1)$ 为起点连续 $0$ 数目为 $right[x-l+1][y-l+1]$，左侧边中以 $(x-l+1,y-l+1)$ 为起点连续 $0$ 的数目为 $down[x-l+1][y-l+1]$，右侧边中以 $(x,y)$ 为起点连续 $0$ 的数目为 $up[x][y]$，下侧边中以 $(x,y)$ 为起点连续 $0$ 的数目为 $left[x][y]$。

如果连续 $0$ 的数目大于等于 $l$，则构成一条「合法」的边，如果正方形的四条边均「合法」，此时一定可以构成边界全为 $0$ 且边长为 $l$ 的正方形。

$$\begin{cases}right[x-l+1][y-l+1]\ge l \\ down[x-l+1][y-l+1]\ge l \\ up[x][y]\ge l \\ left[x][y]\ge l\end{cases}$$

我们只需要求出以 $(x,y)$ 为起点四个方向上连续 $0$ 的数目，枚举边长 $l$ 即可求出以 $(x,y)$ 为右下顶点构成的边界为 $0$ 的最大正方形，此时我们可以求出矩阵中边界为 $0$ 的最大正方形。

本题即转换为求矩阵中任意位置 $(x,y)$ 为起点上下左右四个方向连续 $0$ 的最大数目，此时可以利用动态规划：

- 如果当前 $matrix[x][x]=1$，此时四个方向的连续 $0$ 的长度均为 $0$；
- 如果当前 $matrix[x][x]=0$，此时四个方向的连续 $0$ 的最大数目分别等于四个方向上前一个位置的最大数目加 $1$，计算公式如下：

$$\begin{cases}right[x][y]=right[x][y+1]+1 \\ down[x][y]=down[x+1][y]+1 \\ up[x][y]=up[x-1][y]+1 \\ left[x][y]=left[x][y-1]+1\end{cases}$$

在实际计算过程中我们可以进行优化，不必全部计算出四个方向上的最大连续 $0$ 的数目，可以进行如下优化：

- 只需要求出每个位置 $(x,y)$ 为起点左侧连续 $0$ 的最大数目 $left[x][y]$ 与上方连续 $0$ 的最大数目 $up[x][y]$ 即可。假设当前正方形的边长为 $l$，此时只需检测 $up[x][y],left[x][y],left[x-l+1][y],up[x][y-l+1]$ 是否均满足大于等于 $l$ 即可检测正方形的合法性。
- 枚举正方形的边长时可以从大到小进行枚举，我们已经知道以 $(x,y)$ 为起点左侧连续 $0$ 的最大数目 $left[x][y]$ 与上方连续 $0$ 的最大数目 $up[x][y]$，此时能够成正方形的边长的最大值一定不会超过二者中的最小值 $min(left[x][y],up[x][y])$，从大到小枚举直到可以构成「合法」的正方形即可。

这道题的返回值除了最大黑方阵的边长以外，还包括最大黑方阵的左上角行列下标。可以在动态规划的计算过程中维护最大黑方阵的左上角的行列下标，当一个方阵的右下角行列下标和边长确定时，即可计算得到该方阵的左上角行列下标。计算结束之后，如果最大边长大于 $0$ 则返回最大黑方阵的左上角行列下标和边长，如果最大边长等于 $0$ 则表示没有黑方阵，返回空数组。

由于动态规划的计算顺序为从上到下和从左到右，因此如果有多个最大黑方阵，返回的最大黑方阵一定满足左上角行下标最小，当存在左上角行下标并列最小的情况时时满足左上角列下标最小。

**代码**

```Python
class Solution:
    def findSquare(self, matrix: List[List[int]]) -> List[int]:
        n = len(matrix)
        left = [[0] * (n + 1) for _ in range(n + 1)]
        up = [[0] * (n + 1) for _ in range(n + 1)]
        r, c, size = 0, 0, 0
        for i in range(1, n + 1):
            for j in range(1, n + 1):
                if matrix[i - 1][j - 1] == 0:
                    left[i][j] = left[i][j - 1] + 1
                    up[i][j] = up[i - 1][j] + 1
                    border = min(left[i][j], up[i][j])
                    while left[i - border + 1][j] < border or up[i][j - border + 1] < border:
                        border -= 1
                    if border > size:
                        r = i - border
                        c = j - border
                        size = border
        return [r, c, size] if size > 0 else []
```

```C++
class Solution {
public:
    vector<int> findSquare(vector<vector<int>>& matrix) {
        int n = matrix.size();
        vector<vector<int>> left(n + 1, vector<int>(n + 1));
        vector<vector<int>> up(n + 1, vector<int>(n + 1));
        int r = 0, c = 0, size = 0;
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                if (matrix[i - 1][j - 1] == 0) {
                    left[i][j] = left[i][j - 1] + 1;
                    up[i][j] = up[i - 1][j] + 1;
                    int border = min(left[i][j], up[i][j]);
                    while (left[i - border + 1][j] < border || up[i][j - border + 1] < border) {
                        border--;
                    }
                    if (border > size) {
                        r = i - border;
                        c = j - border;
                        size = border;
                    }
                }
            }
        }
        if (size > 0) {
            return {r, c, size};
        } else {
            return {};
        }
    }
};
```

```Java
class Solution {
    public int[] findSquare(int[][] matrix) {
        int n = matrix.length;
        int[][] left = new int[n + 1][n + 1];
        int[][] up = new int[n + 1][n + 1];
        int r = 0, c = 0, size = 0;
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                if (matrix[i - 1][j - 1] == 0) {
                    left[i][j] = left[i][j - 1] + 1;
                    up[i][j] = up[i - 1][j] + 1;
                    int border = Math.min(left[i][j], up[i][j]);
                    while (left[i - border + 1][j] < border || up[i][j - border + 1] < border) {
                        border--;
                    }
                    if (border > size) {
                        r = i - border;
                        c = j - border;
                        size = border;
                    }
                }
            }
        }
        return size > 0 ? new int[]{r, c, size} : new int[0];
    }
}
```

```CSharp
public class Solution {
    public int[] FindSquare(int[][] matrix) {
        int n = matrix.Length;
        int[][] left = new int[n + 1][];
        int[][] up = new int[n + 1][];
        for (int i = 0; i <= n; i++) {
            left[i] = new int[n + 1];
            up[i] = new int[n + 1];
        }
        int r = 0, c = 0, size = 0;
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                if (matrix[i - 1][j - 1] == 0) {
                    left[i][j] = left[i][j - 1] + 1;
                    up[i][j] = up[i - 1][j] + 1;
                    int border = Math.Min(left[i][j], up[i][j]);
                    while (left[i - border + 1][j] < border || up[i][j - border + 1] < border) {
                        border--;
                    }
                    if (border > size) {
                        r = i - border;
                        c = j - border;
                        size = border;
                    }
                }
            }
        }
        return size > 0 ? new int[]{r, c, size} : new int[0];
    }
}
```

```C
#define MIN(a, b) ((a) < (b) ? (a) : (b))

int* findSquare(int** matrix, int matrixSize, int* matrixColSize, int* returnSize) {
    int n = matrixSize;
    int left[n + 1][n + 1], up[n + 1][n + 1];
    memset(left, 0, sizeof(left));
    memset(up, 0, sizeof(up));
    int r = 0, c = 0, size = 0;
    for (int i = 1; i <= n; i++) {
        for (int j = 1; j <= n; j++) {
            if (matrix[i - 1][j - 1] == 0) {
                left[i][j] = left[i][j - 1] + 1;
                up[i][j] = up[i - 1][j] + 1;
                int border = MIN(left[i][j], up[i][j]);
                while (left[i - border + 1][j] < border || up[i][j - border + 1] < border) {
                    border--;
                }
                if (border > size) {
                    r = i - border;
                    c = j - border;
                    size = border;
                }
            }
        }
    }
    if (size > 0) {
        *returnSize = 3;
        int* res = (int*) malloc(sizeof(int) * 3);
        res[0] = r;
        res[1] = c;
        res[2] = size;
        return res;
    } else {
        *returnSize = 0;
        return 0;
    }
}
```

```JavaScript
var findSquare = function(matrix) {
    const n = matrix.length;
    const left = new Array(n + 1).fill(0).map(() => new Array(n + 1).fill(0));
    const up = new Array(n + 1).fill(0).map(() => new Array(n + 1).fill(0));
    let r = 0, c = 0, size = 0;
    for (let i = 1; i <= n; i++) {
        for (let j = 1; j <= n; j++) {
            if (matrix[i - 1][j - 1] === 0) {
                left[i][j] = left[i][j - 1] + 1;
                up[i][j] = up[i - 1][j] + 1;
                let border = Math.min(left[i][j], up[i][j]);
                while (left[i - border + 1][j] < border || up[i][j - border + 1] < border) {
                    border--;
                }
                if (border > size) {
                    r = i - border;
                    c = j - border;
                    size = border;
                }
            }
        }
    }
    return size > 0 ? [r, c, size] : [];
};
```

```Go
func findSquare(matrix [][]int) []int {
    n := len(matrix)
    left := make([][]int, n+1)
    up := make([][]int, n+1)
    for i := range left {
        left[i] = make([]int, n+1)
        up[i] = make([]int, n+1)
    }
    r, c, size := 0, 0, 0
    for i := 1; i <= n; i++ {
        for j := 1; j <= n; j++ {
            if matrix[i-1][j-1] == 0 {
                left[i][j] = left[i][j-1] + 1
                up[i][j] = up[i-1][j] + 1
                border := min(left[i][j], up[i][j])
                for left[i-border+1][j] < border || up[i][j-border+1] < border {
                    border--
                }
                if border > size {
                    r = i - border
                    c = j - border
                    size = border
                }
            }
        }
    }
    if size > 0 {
        return []int{r, c, size}
    }
    return []int{}
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}
```

**复杂度分析**

- 时间复杂度：$O(n^3)$，其中 $n$ 表示矩阵的行数和列数。状态数是 $O(n^2)$，每个状态的计算时间为 $O(n)$。
- 空间复杂度：$O(n^2)$，其中 $n$ 表示矩阵的行数和列数。需要保存矩阵中每个位置的最长连续 $0$ 的数目，需要的空间为 $O(n^2)$。
