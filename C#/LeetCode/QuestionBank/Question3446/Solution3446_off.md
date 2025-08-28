### [按对角线进行矩阵排序](https://leetcode.cn/problems/sort-matrix-by-diagonals/solutions/3756283/an-dui-jiao-xian-jin-xing-ju-zhen-pai-xu-86ki/)

#### 方法一：模拟

**思路与算法**

这道题要求我们将矩阵中左下角三角形（包括对角线）的对角线元素按非递增顺序排序，并将右上角三角形的对角线元素按非递减顺序排序。

我们可以直接进行模拟，逐对角线取出元素进行排序，再将排序后的元素放回矩阵中。因此，我们只需要知道如何按对角线遍历元素。我们令第 $i$ 行 $j$ 列的元素为 $grid[i][j]$。

首先考虑左下角三角形。从左上角开始往右下角看，随着行数 $i$ 的增加，列数 $j$ 也增加。由于对角线从左上到右下，每次 $j$ 都是从 $0$ 开始，我们可以逐列进行遍历，行数 $i$ 则会跟着 $j$ 进行变化。因此，左下角三角形每一条对角线上的元素是 $grid[i+j][j]$。

接着考虑右上角三角形。依然从左上角开始往右下角看，随着列数 $j$ 的增加，行数 $i$ 也增加。由于右上角三角形所有对角线上的元素都是从第 $0$ 行开始，我们可以逐行进行遍历，列数 $j$ 则会跟着 $i$ 进行变化。因此，右上角三角形每一条对角线上的元素是 $grid[i][j+i]$。

同时，对于每条对角线来说，最后一个元素都满足 $i+j=n-1$，由此我们就可以不重不漏不越界地遍历所有的对角线上的元素。

**代码**

```C++
class Solution {
public:
    vector<vector<int>> sortMatrix(vector<vector<int>>& grid) {
        int n = grid.size();
        for (int i = 0; i < n; i++) {
            vector<int> tmp;
            for (int j = 0; i + j < n; j++) {
                tmp.push_back(grid[i + j][j]);
            }
            sort(tmp.begin(), tmp.end(), greater<int>());
            for (int j = 0; i + j < n; j++) {
                grid[i + j][j] = tmp[j];
            }
        }
        for (int j = 1; j < n; j++) {
            vector<int> tmp;
            for (int i = 0; j + i < n; i++) {
                tmp.push_back(grid[i][j + i]);
            }
            sort(tmp.begin(), tmp.end());
            for (int i = 0; j + i < n; i++) {
                grid[i][j + i] = tmp[i];
            }
        }
        return grid;
    }
};
```

```Java
class Solution {
    public int[][] sortMatrix(int[][] grid) {
        int n = grid.length;

        for (int i = 0; i < n; i++) {
            List<Integer> tmp = new ArrayList<>();
            for (int j = 0; i + j < n; j++) {
                tmp.add(grid[i + j][j]);
            }
            tmp.sort(Collections.reverseOrder());
            for (int j = 0; i + j < n; j++) {
                grid[i + j][j] = tmp.get(j);
            }
        }

        for (int j = 1; j < n; j++) {
            List<Integer> tmp = new ArrayList<>();
            for (int i = 0; j + i < n; i++) {
                tmp.add(grid[i][j + i]);
            }
            Collections.sort(tmp);
            for (int i = 0; j + i < n; i++) {
                grid[i][j + i] = tmp.get(i);
            }
        }

        return grid;
    }
}
```

```Python
class Solution:
    def sortMatrix(self, grid: List[List[int]]) -> List[List[int]]:
        n = len(grid)

        for i in range(n):
            tmp = [grid[i + j][j] for j in range(n - i)]
            tmp.sort(reverse=True)
            for j in range(n - i):
                grid[i + j][j] = tmp[j]

        for j in range(1, n):
            tmp = [grid[i][j + i] for i in range(n - j)]
            tmp.sort()
            for i in range(n - j):
                grid[i][j + i] = tmp[i]

        return grid

```

```C
int cmp_desc(const void *a, const void *b) {
    return (*(int*)b - *(int*)a);
}
int cmp_asc(const void *a, const void *b) {
    return (*(int*)a - *(int*)b);
}

int** sortMatrix(int** grid, int gridSize, int* gridColSize, int* returnSize, int** returnColumnSizes) {
    int n = gridSize;
    
    int** res = (int**)malloc(sizeof(int*) * n);
    *returnColumnSizes = (int*)malloc(sizeof(int) * n);
    for (int i = 0; i < n; i++) {
        res[i] = (int*)malloc(sizeof(int) * n);
        (*returnColumnSizes)[i] = n;
        for (int j = 0; j < n; j++) {
            res[i][j] = grid[i][j];
        }
    }
    
    for (int i = 0; i < n; i++) {
        int tmp[15], len = 0;
        for (int j = 0; i + j < n; j++) {
            tmp[len++] = res[i + j][j];
        }
        qsort(tmp, len, sizeof(int), cmp_desc);
        for (int j = 0; i + j < n; j++) {
            res[i + j][j] = tmp[j];
        }
    }
    
    for (int j = 1; j < n; j++) {
        int tmp[15], len = 0;
        for (int i = 0; j + i < n; i++) {
            tmp[len++] = res[i][j + i];
        }
        qsort(tmp, len, sizeof(int), cmp_asc);
        for (int i = 0; j + i < n; i++) {
            res[i][j + i] = tmp[i];
        }
    }
    
    *returnSize = n;
    return res;
}
```

```Go
func sortMatrix(grid [][]int) [][]int {
    n := len(grid)

    for i := 0; i < n; i++ {
        tmp := []int{}
        for j := 0; i+j < n; j++ {
            tmp = append(tmp, grid[i+j][j])
        }
        sort.Sort(sort.Reverse(sort.IntSlice(tmp)))
        for j := 0; i+j < n; j++ {
            grid[i+j][j] = tmp[j]
        }
    }

    for j := 1; j < n; j++ {
        tmp := []int{}
        for i := 0; j+i < n; i++ {
            tmp = append(tmp, grid[i][j+i])
        }
        sort.Ints(tmp)
        for i := 0; j+i < n; i++ {
            grid[i][j+i] = tmp[i]
        }
    }

    return grid
}
```

```CSharp
public class Solution {
    public int[][] SortMatrix(int[][] grid) {
        int n = grid.Length;

        for (int i = 0; i < n; i++) {
            List<int> tmp = new List<int>();
            for (int j = 0; i + j < n; j++) {
                tmp.Add(grid[i + j][j]);
            }
            tmp.Sort((a, b) => b.CompareTo(a));
            for (int j = 0; i + j < n; j++) {
                grid[i + j][j] = tmp[j];
            }
        }

        for (int j = 1; j < n; j++) {
            List<int> tmp = new List<int>();
            for (int i = 0; j + i < n; i++) {
                tmp.Add(grid[i][j + i]);
            }
            tmp.Sort();
            for (int i = 0; j + i < n; i++) {
                grid[i][j + i] = tmp[i];
            }
        }

        return grid;
    }
}
```

```JavaScript
var sortMatrix = function (grid) {
    const n = grid.length;

    for (let i = 0; i < n; i++) {
        let tmp = [];
        for (let j = 0; i + j < n; j++) {
            tmp.push(grid[i + j][j]);
        }
        tmp.sort((a, b) => b - a);
        for (let j = 0; i + j < n; j++) {
            grid[i + j][j] = tmp[j];
        }
    }

    for (let j = 1; j < n; j++) {
        let tmp = [];
        for (let i = 0; j + i < n; i++) {
            tmp.push(grid[i][j + i]);
        }
        tmp.sort((a, b) => a - b);
        for (let i = 0; j + i < n; i++) {
            grid[i][j + i] = tmp[i];
        }
    }

    return grid;
};
```

```TypeScript
function sortMatrix(grid: number[][]): number[][] {
    const n = grid.length;

    for (let i = 0; i < n; i++) {
        let tmp: number[] = [];
        for (let j = 0; i + j < n; j++) {
            tmp.push(grid[i + j][j]);
        }
        tmp.sort((a, b) => b - a);
        for (let j = 0; i + j < n; j++) {
            grid[i + j][j] = tmp[j];
        }
    }

    for (let j = 1; j < n; j++) {
        let tmp: number[] = [];
        for (let i = 0; j + i < n; i++) {
            tmp.push(grid[i][j + i]);
        }
        tmp.sort((a, b) => a - b);
        for (let i = 0; j + i < n; i++) {
            grid[i][j + i] = tmp[i];
        }
    }

    return grid;
};
```

```Rust
impl Solution {
    pub fn sort_matrix(mut grid: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
        let n = grid.len();

        for i in 0..n {
            let mut tmp: Vec<i32> = (0..(n - i)).map(|j| grid[i + j][j]).collect();
            tmp.sort_by(|a, b| b.cmp(a));
            for j in 0..(n - i) {
                grid[i + j][j] = tmp[j];
            }
        }

        for j in 1..n {
            let mut tmp: Vec<i32> = (0..(n - j)).map(|i| grid[i][j + i]).collect();
            tmp.sort();
            for i in 0..(n - j) {
                grid[i][j + i] = tmp[i];
            }
        }

        grid
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2\log n)$，其中 $n$ 是 $grid$ 的行数和列数。遍历矩阵的每个对角线需要 $O(n)$，对对角线的每个元素排序需要 $O(n\log n)$。
- 空间复杂度：$O(n)$。我们用一个数组存储对角线上的元素进行排序。
