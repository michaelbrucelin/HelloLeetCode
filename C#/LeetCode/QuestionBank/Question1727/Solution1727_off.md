### [重新排列后的最大子矩阵](https://leetcode.cn/problems/largest-submatrix-with-rearrangements/solutions/3920146/zhong-xin-pai-lie-hou-de-zui-da-zi-ju-zh-q8r8/)

#### 方法一：排序

**思路与算法**

根据题意可知，给定一个矩阵，允许对矩阵的列进行任意重排，求可能得到的最大全 $1$ 子矩阵的面积。对给定的矩阵 $matrix$ 列可重新排列（列顺序可以任意调换），由于每行无法直接交换，我们可以计算以下标 $(i,j)$ 上方的连续为 $1$ 的长度，对矩阵进行预处理，矩阵中的每个元素更新为该元素向上的最大连续 $1$ 的个数，如下图所示：

![](data:image/svg+xml,%3Csvg height='150' viewBox='0 0 150 150' width='150' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath d='m2465 2286.42347-18.95363-18.92555-50.0112 43.79935-24.62708-24.5906-33.41155 24.5906-22.99654-17.22567v-73.0716c0-2.20914 1.79086-4 4-4h142c2.20914 0 4 1.79086 4 4zm-122-25.59081c5.52285 0 10-4.47052 10-9.98518 0-5.51467-4.47715-9.98519-10-9.98519s-10 4.47052-10 9.98519c0 5.51466 4.47715 9.98518 10 9.98518zm122 40.89296v61.27438c0 2.20914-1.79086 4-4 4h-142c-2.20914 0-4-1.79086-4-4v-53.62625l22.99654 17.22567 33.41155-24.5906 24.62708 24.5906 50.0112-43.79935z' fill='%23eee' fill-rule='evenodd' transform='translate(-2315 -2217)'/%3E%3C/svg%3E)

此时我们枚举以矩阵中的每个位置 $(i,j)$ 做为子矩阵的右下顶点，当 $(i,j)$ 作为子矩阵的右下顶点时，子矩阵的高度最多为 $matrix[i][j]$，同一行中所有上方连续 $1$ 的长度大于等于 $matrix[i][j]$ 列均可移动到其左侧，从而构成高为 $matrix[i][j]$ 且全为 $1$ 的子矩阵。

![](data:image/svg+xml,%3Csvg height='150' viewBox='0 0 150 150' width='150' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath d='m2465 2286.42347-18.95363-18.92555-50.0112 43.79935-24.62708-24.5906-33.41155 24.5906-22.99654-17.22567v-73.0716c0-2.20914 1.79086-4 4-4h142c2.20914 0 4 1.79086 4 4zm-122-25.59081c5.52285 0 10-4.47052 10-9.98518 0-5.51467-4.47715-9.98519-10-9.98519s-10 4.47052-10 9.98519c0 5.51466 4.47715 9.98518 10 9.98518zm122 40.89296v61.27438c0 2.20914-1.79086 4-4 4h-142c-2.20914 0-4-1.79086-4-4v-53.62625l22.99654 17.22567 33.41155-24.5906 24.62708 24.5906 50.0112-43.79935z' fill='%23eee' fill-rule='evenodd' transform='translate(-2315 -2217)'/%3E%3C/svg%3E)

为了得到最大全 $1$ 子矩阵的面积，可以将更新后的矩阵的每一行按照从大到小进行排序，然后对矩阵的每一行顺序遍历，计算以该行为底边的最大全 $1$ 子矩阵面积。当遍历第 $i$ 行，第 $j$ 列时，此时以 $matrix[i][j]$ 为高且全为 $1$ 的子矩阵底边最长为 $j+1$，此时子矩阵的最大面积即为 $matrix[i][j]\cdot (j+1)$。

我们依次遍历更新后的矩阵的每一行，即可得到最大全 $1$ 子矩阵面积。

**代码**

```C++
class Solution {
public:
    int largestSubmatrix(vector<vector<int>>& matrix) {
        int m = matrix.size(), n = matrix[0].size();
        int maxArea = 0;
        for (int i = 1; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] == 1) {
                    matrix[i][j] += matrix[i - 1][j];
                }
            }
        }
        for (int i = 0; i < m; i++) {
            sort(matrix[i].begin(), matrix[i].end(), greater<int>());
            for (int j = 0; j < n; j++) {
                maxArea = max(maxArea, (j + 1) * matrix[i][j]);
            }
        }
        return maxArea;
    }
};
```

```Java
class Solution {
    public int largestSubmatrix(int[][] matrix) {
        int m = matrix.length;
        int n = matrix[0].length;
        int maxArea = 0;

        for (int i = 1; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] == 1) {
                    matrix[i][j] += matrix[i - 1][j];
                }
            }
        }

        for (int i = 0; i < m; i++) {
            Arrays.sort(matrix[i]);
            reverse(matrix[i]);
            for (int j = 0; j < n; j++) {
                maxArea = Math.max(maxArea, (j + 1) * matrix[i][j]);
            }
        }

        return maxArea;
    }

    private void reverse(int[] arr) {
        int left = 0;
        int right = arr.length - 1;
        while (left < right) {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            left++;
            right--;
        }
    }
}
```

```CSharp
public class Solution {
    public int LargestSubmatrix(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        int maxArea = 0;

        for (int i = 1; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] == 1) {
                    matrix[i][j] += matrix[i - 1][j];
                }
            }
        }

        for (int i = 0; i < m; i++) {
            Array.Sort(matrix[i], (a, b) => b.CompareTo(a));
            for (int j = 0; j < n; j++) {
                maxArea = Math.Max(maxArea, (j + 1) * matrix[i][j]);
            }
        }

        return maxArea;
    }
}
```

```Python
class Solution:
    def largestSubmatrix(self, matrix: List[List[int]]) -> int:
        m, n = len(matrix), len(matrix[0])
        max_area = 0

        for i in range(1, m):
            for j in range(n):
                if matrix[i][j] == 1:
                    matrix[i][j] += matrix[i - 1][j]

        for i in range(m):
            matrix[i].sort(reverse=True)
            for j in range(n):
                max_area = max(max_area, (j + 1) * matrix[i][j])

        return max_area
```

```Go
func largestSubmatrix(matrix [][]int) int {
    m, n := len(matrix), len(matrix[0])
    maxArea := 0

    for i := 1; i < m; i++ {
        for j := 0; j < n; j++ {
            if matrix[i][j] == 1 {
                matrix[i][j] += matrix[i-1][j]
            }
        }
    }

    for i := 0; i < m; i++ {
        sort.Slice(matrix[i], func(a, b int) bool {
            return matrix[i][a] > matrix[i][b]
        })
        for j := 0; j < n; j++ {
            maxArea = max(maxArea, (j + 1) * matrix[i][j])
        }
    }

    return maxArea
}
```

```C
int compare(const void* a, const void* b) {
    return (*(int*)b - *(int*)a);
}

int largestSubmatrix(int** matrix, int matrixSize, int* matrixColSize) {
    int m = matrixSize;
    int n = matrixColSize[0];
    int maxArea = 0;

    for (int i = 1; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (matrix[i][j] == 1) {
                matrix[i][j] += matrix[i - 1][j];
            }
        }
    }

    for (int i = 0; i < m; i++) {
        qsort(matrix[i], n, sizeof(int), compare);
        int* row = matrix[i];
        for (int j = 0; j < n; j++) {
            int area = (j + 1) * row[j];
            if (area > maxArea) {
                maxArea = area;
            }
        }

        free(row);
    }

    return maxArea;
}
```

```JavaScript
var largestSubmatrix = function(matrix) {
    const m = matrix.length, n = matrix[0].length;
    let maxArea = 0;

    for (let i = 1; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (matrix[i][j] === 1) {
                matrix[i][j] += matrix[i - 1][j];
            }
        }
    }

    for (let i = 0; i < m; i++) {
        matrix[i].sort((a, b) => b - a);
        for (let j = 0; j < n; j++) {
            maxArea = Math.max(maxArea, (j + 1) * matrix[i][j]);
        }
    }

    return maxArea;
};
```

```TypeScript
function largestSubmatrix(matrix: number[][]): number {
    const m = matrix.length, n = matrix[0].length;
    let maxArea = 0;

    for (let i = 1; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (matrix[i][j] === 1) {
                matrix[i][j] += matrix[i - 1][j];
            }
        }
    }

    for (let i = 0; i < m; i++) {
        matrix[i].sort((a, b) => b - a);
        for (let j = 0; j < n; j++) {
            maxArea = Math.max(maxArea, (j + 1) * matrix[i][j]);
        }
    }

    return maxArea;
}
```

```Rust
impl Solution {
    pub fn largest_submatrix(matrix: Vec<Vec<i32>>) -> i32 {
        let m = matrix.len();
        let n = matrix[0].len();
        let mut matrix = matrix;
        let mut max_area = 0;

        for i in 1..m {
            for j in 0..n {
                if matrix[i][j] == 1 {
                    matrix[i][j] += matrix[i - 1][j];
                }
            }
        }

        for i in 0..m {
            matrix[i].sort_by(|a, b| b.cmp(a));
            for j in 0..n {
                let area = (j as i32 + 1) * matrix[i][j];
                if area > max_area {
                    max_area = area;
                }
            }
        }

        max_area
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn\log n)$，其中 $m,n$ 表示给定矩阵的行数与列数。遍历并更新矩阵需要 $O(mn)$ 的时间，对更新后的矩阵的每一行排序共需要 $O(mn\log n)$ 的时间，计算最大面积需要 $O(mn)$ 的时间，总的时间是 $O(mn\log n)$。
- 空间复杂度：$O(\log n)$，其中 $n$ 表示 $matrix$ 的列数。排序需要的空间为 $(O\log n)$。
