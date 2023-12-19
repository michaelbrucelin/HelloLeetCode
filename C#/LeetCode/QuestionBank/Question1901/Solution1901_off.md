### [寻找峰值 II](https://leetcode.cn/problems/find-a-peak-element-ii/solutions/2566062/xun-zhao-feng-zhi-ii-by-leetcode-solutio-y57g/)

#### 方法一：二分查找

令 $m$ 和 $n$ 分别为 $mat$ 的行数和列数。首先对于一维数组，因为任意两个相邻的格子的值都不相同，所以它的最大值必定是该一维数组的峰值。基于这一点，我们可以只考虑每一行的最大值，记第 $i$ 行的最大值为第 $j_i$ 列元素，如果 $mat[i][j_i] \gt mat[i - 1][j_i]$ 且 $mat[i][j_i] \gt mat[i + 1][j_i]$（对于数组越界的情况，取 $-1$ 值），那么 $(i, j_i)$ 即为结果。

对于题目给定的条件，是否一定存在峰值呢？答案是肯定的。证明可以采用反证法：

> 如果不存在峰值，根据题目给定的条件，我们知道第 $0$ 行的最大值比它上面的格子（值为 $-1$）大，那么初始时有 $i = 0$ 行的最大值满足比上面格子大的条件。如果第 $i$ 行的最大值满足比它上面的格子大这一条件，那么根据不存在峰值的前提，我们有 $mat[i][j_i] \lt mat[i + 1][j_i]$，而 $mat[i + 1][j_{i + 1}] \ge mat[i + 1][j_i] \gt mat[i][j_i] \ge mat[i][j_{i+1}]$，从而我们有 $mat[i + 1][j_{i + 1}] \gt mat[i][j_{i+1}]$，即 $i + 1$ 也满足条件。基于以上推导，使用数学归纳法，当 $i = m - 1$ 时，有 $mat[m - 1][j_{m - 1}] \gt mat[m - 2][j_{m - 1}]$，而下面的格子值为 $-1$，显然 $(m - 1, j_{m - 1})$ 为峰值，与不存在峰值矛盾。

根据以上证明，我们也可以得出这样一个结论，即如果 $i_1$  行的最大值比它上面的格子大，$i_2$  行比它下面的格子大，且 $i_1 \le i_2$ ，那么 $[i_1, i_2]$ 之间一定存在峰值。基于这个结论，我们可以使用二分法来求解问题，初始时 $low = 0$，$high = m - 1$:

1. 令 $i = \lfloor \frac{low + high}{2} \rfloor$，第 $i$ 行的最大值为第 $j$ 列。
2. 如果 $mat[i][j] \lt mat[i - 1][j]$，那么令 $high = i - 1$，继续步骤 $1$。
3. 如果 $mat[i][j] \lt mat[i + 1][j]$，那么令 $low = i + 1$，继续步骤 $1$。
4. 返回 $(i, j)$ 为结果。

> 类似地，我们也可以只考虑每一列的最大值，读者可以思考一下类似的求解过程，时间复杂度为 $O(m \log n)$。

```c++
class Solution {
public:
    vector<int> findPeakGrid(vector<vector<int>>& mat) {
        int m = mat.size();
        int low = 0, high = m - 1;
        while (low <= high) {
            int i = (low + high) / 2;
            int j = max_element(mat[i].begin(), mat[i].end()) - mat[i].begin();
            if (i - 1 >= 0 && mat[i][j] < mat[i - 1][j]) {
                high = i - 1;
                continue;
            }
            if (i + 1 < m && mat[i][j] < mat[i + 1][j]) {
                low = i + 1;
                continue;
            }
            return {i, j};
        }
        return {}; // impossible
    }
};
```

```java
class Solution {
    public int[] findPeakGrid(int[][] mat) {
        int m = mat.length, n = mat[0].length;
        int low = 0, high = m - 1;
        while (low <= high) {
            int i = (low + high) / 2;
            int j = -1, maxElement = -1;
            for (int k = 0; k < n; k++) {
                if (mat[i][k] > maxElement) {
                    j = k;
                    maxElement = mat[i][k];
                }
            }
            if (i - 1 >= 0 && mat[i][j] < mat[i - 1][j]) {
                high = i - 1;
                continue;
            }
            if (i + 1 < m && mat[i][j] < mat[i + 1][j]) {
                low = i + 1;
                continue;
            }
            return new int[]{i, j};
        }
        return new int[0]; // impossible
    }
}
```

```csharp
public class Solution {
    public int[] FindPeakGrid(int[][] mat) {
        int m = mat.Length, n = mat[0].Length;
        int low = 0, high = m - 1;
        while (low <= high) {
            int i = (low + high) / 2;
            int j = -1, maxElement = -1;
            for (int k = 0; k < n; k++) {
                if (mat[i][k] > maxElement) {
                    j = k;
                    maxElement = mat[i][k];
                }
            }
            if (i - 1 >= 0 && mat[i][j] < mat[i - 1][j]) {
                high = i - 1;
                continue;
            }
            if (i + 1 < m && mat[i][j] < mat[i + 1][j]) {
                low = i + 1;
                continue;
            }
            return new int[]{i, j};
        }
        return new int[0]; // impossible
    }
}
```

```go
func maxElement(row []int) int {
    i := 0
    for j := range row {
        if row[i] < row[j] {
            i = j
        }
    }
    return i
}

func findPeakGrid(mat [][]int) []int {
    m := len(mat)
    low, high := 0, m - 1
    for low <= high {
        i := (low + high) / 2
        j := maxElement(mat[i])
        if i - 1 >= 0 && mat[i][j] < mat[i - 1][j] {
            high = i - 1
            continue
        }
        if i + 1 < m && mat[i][j] < mat[i + 1][j] {
            low = i + 1
            continue
        }
        return []int{i, j}
    }
    return nil // impossible
}
```

```python
class Solution:
    def findPeakGrid(self, mat: List[List[int]]) -> List[int]:
        m = len(mat)
        low, high = 0, m - 1
        while low <= high:
            i = (low + high) // 2
            j = mat[i].index(max(mat[i]))
            if i - 1 >= 0 and mat[i][j] < mat[i - 1][j]:
                high = i - 1
                continue
            if i + 1 < m and mat[i][j] < mat[i + 1][j]:
                low = i + 1
                continue
            return [i, j]
        return None # impossible
```

```c
int maxElement(int *row, int n) {
    int i = 0;
    for (int j = 0; j < n; j++) {
        if (row[i] < row[j]) {
            i = j;
        }
    }
    return i;
}

int* findPeakGrid(int **mat, int matSize, int *matColSize, int *returnSize) {
    int m = matSize, n = matColSize[0];
    int low = 0, high = m - 1;
    while (low <= high) {
        int i = (low + high) / 2;
        int j = maxElement(mat[i], n);
        if (i - 1 >= 0 && mat[i][j] < mat[i - 1][j]) {
            high = i - 1;
            continue;
        }
        if (i + 1 < m && mat[i][j] < mat[i + 1][j]) {
            low = i + 1;
            continue;
        }
        int *ret = (int *)malloc(sizeof(int) * 2);
        ret[0] = i;
        ret[1] = j;
        *returnSize = 2;
        return ret;
    }
    *returnSize = 0;
    return NULL; // impossible
}
```

```javascript
var maxElement = function(arr) {
    let i = 0;
    for (let j = 0; j < arr.length; j++) {
        if (arr[i] < arr[j]) {
            i = j;
        }
    }
    return i;
}

var findPeakGrid = function(mat) {
    const m = mat.length;
    let low = 0, high = m - 1;
    while (low <= high) {
        let i = Math.floor((low + high) / 2);
        let j = maxElement(mat[i]);
        if (i - 1 >= 0 && mat[i][j] < mat[i - 1][j]) {
            high = i - 1;
            continue;
        }
        if (i + 1 < m && mat[i][j] < mat[i + 1][j]) {
            low = i + 1;
            continue;
        }
        return [i, j];
    }
    return []; // impossible
};
```

#### 复杂度分析

- 时间复杂度：$O(n \log m)$，其中 $m$ 和 $n$ 分别是 $mat$ 的行数和列数。
- 空间复杂度：$O(1)$。
