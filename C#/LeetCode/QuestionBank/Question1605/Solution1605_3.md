#### [没有思路？一个动画秒懂！附优化写法（Python/Java/C++/Go）](https://leetcode.cn/problems/find-valid-matrix-given-row-and-column-sums/solutions/2166773/mei-you-si-lu-yi-ge-dong-hua-miao-dong-f-eezj/)

用示例 2 来演示：

![](./assets/img/Solution1605_3_01.png)
![](./assets/img/Solution1605_3_02.png)
![](./assets/img/Solution1605_3_03.png)
![](./assets/img/Solution1605_3_04.png)
![](./assets/img/Solution1605_3_05.png)
![](./assets/img/Solution1605_3_06.png)
![](./assets/img/Solution1605_3_07.png)
![](./assets/img/Solution1605_3_08.png)
![](./assets/img/Solution1605_3_09.png)
![](./assets/img/Solution1605_3_10.png)

#### 答疑

**问**：如何证明该构造方案一定能得到满足题目要求的矩阵？

**答**：设生成的矩阵为 $mat$。对于只有 $1$ 行的情况，构造 $mat[0][j] = colSum[j]$，由于题目保证 `sum(rowSum) == sum(colSum)`，所以只有 $1$ 行的 $mat$ 是满足题目要求的。 假设 $m-1$ 行的 $mat$ 是满足题目要求的，上述构造方案可以满足 $mat$ 第一行的 $rowSum$，且构造的数字不超过相应的 $colSum$，从而转换成一个 $m-1$ 行的子问题。只要 $m-1$ 行的 $mat$ 是满足题目要求的，那么 $m$ 行的 $mat$ 也是满足题目要求的。 根据数学归纳法，$m$ 行的 $mat$ 是满足题目要求的。

```python
class Solution:
    def restoreMatrix(self, rowSum: List[int], colSum: List[int]) -> List[List[int]]:
        m, n = len(rowSum), len(colSum)
        mat = [[0] * n for _ in range(m)]
        for i, rs in enumerate(rowSum):
            for j, cs in enumerate(colSum):
                mat[i][j] = x = min(rs, cs)
                rs -= x
                colSum[j] -= x
        return mat
```

```java
class Solution {
    public int[][] restoreMatrix(int[] rowSum, int[] colSum) {
        int m = rowSum.length, n = colSum.length;
        var mat = new int[m][n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                mat[i][j] = Math.min(rowSum[i], colSum[j]);
                rowSum[i] -= mat[i][j];
                colSum[j] -= mat[i][j];
            }
        }
        return mat;
    }
}
```

```cpp
class Solution {
public:
    vector<vector<int>> restoreMatrix(vector<int> &rowSum, vector<int> &colSum) {
        int m = rowSum.size(), n = colSum.size();
        vector<vector<int>> mat(m, vector<int>(n));
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                mat[i][j] = min(rowSum[i], colSum[j]);
                rowSum[i] -= mat[i][j];
                colSum[j] -= mat[i][j];
            }
        }
        return mat;
    }
};
```

```go
func restoreMatrix(rowSum, colSum []int) [][]int {
    mat := make([][]int, len(rowSum))
    for i, rs := range rowSum {
        mat[i] = make([]int, len(colSum))
        for j, cs := range colSum {
            mat[i][j] = min(rs, cs)
            rs -= mat[i][j]
            colSum[j] -= mat[i][j]
        }
    }
    return mat
}

func min(a, b int) int { if a > b { return b }; return a }
```

#### 优化

![](./assets/img/Solution1605_3_11.png)

也可以这样理解：从左上角出发，每次要么去掉一行，要么去掉一列。同样根据数学归纳法，可以证明该做法的正确性。

```python
class Solution:
    def restoreMatrix(self, rowSum: List[int], colSum: List[int]) -> List[List[int]]:
        m, n = len(rowSum), len(colSum)
        mat = [[0] * n for _ in range(m)]
        i = j = 0  # 从左上角出发
        while i < m and j < n:
            rs, cs = rowSum[i], colSum[j]
            if rs < cs:
                mat[i][j] = rs  # 去掉第 i 行
                colSum[j] -= rs
                i += 1  # 往下走
            else:
                mat[i][j] = cs  # 去掉第 j 列
                rowSum[i] -= cs
                j += 1  # 往右走
        return mat
```

```java
class Solution {
    public int[][] restoreMatrix(int[] rowSum, int[] colSum) {
        int m = rowSum.length, n = colSum.length;
        var mat = new int[m][n];
        for (int i = 0, j = 0; i < m && j < n; ) {
            int rs = rowSum[i], cs = colSum[j];
            if (rs < cs) { // 去掉第 i 行，往下走
                colSum[j] -= rs;
                mat[i++][j] = rs;
            } else { // 去掉第 j 列，往右走
                rowSum[i] -= cs;
                mat[i][j++] = cs;
            }
        }
        return mat;
    }
}
```

```cpp
class Solution {
public:
    vector<vector<int>> restoreMatrix(vector<int> &rowSum, vector<int> &colSum) {
        int m = rowSum.size(), n = colSum.size();
        vector<vector<int>> mat(m, vector<int>(n));
        for (int i = 0, j = 0; i < m && j < n; ) {
            int rs = rowSum[i], cs = colSum[j];
            if (rs < cs) { // 去掉第 i 行，往下走
                colSum[j] -= rs;
                mat[i++][j] = rs;
            } else { // 去掉第 j 列，往右走
                rowSum[i] -= cs;
                mat[i][j++] = cs;
            }
        }
        return mat;
    }
};
```

```go
func restoreMatrix(rowSum, colSum []int) [][]int {
    m, n := len(rowSum), len(colSum)
    mat := make([][]int, m)
    for i := range mat {
        mat[i] = make([]int, n)
    }
    for i, j := 0, 0; i < m && j < n; {
        rs, cs := rowSum[i], colSum[j]
        if rs < cs {
            mat[i][j] = rs // 去掉第 i 行
            colSum[j] -= rs
            i++ // 往下走
        } else {
            mat[i][j] = cs // 去掉第 j 列
            rowSum[i] -= cs
            j++ // 往右走
        }
    }
    return mat
}
```

#### 复杂度分析

-   时间复杂度：$O(mn)$，其中 $m$ 为矩阵行数，即 $rowSum$ 的长度；$n$ 为矩阵列数，即 $colSum$ 的长度。如果忽略创建二维数组的时间，时间复杂度为 $O(m+n)$。
-   空间复杂度：$O(1)$。返回值不计入。
