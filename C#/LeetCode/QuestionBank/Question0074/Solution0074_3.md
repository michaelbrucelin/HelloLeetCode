#### [方法一：两次二分查找](https://leetcode.cn/problems/search-a-2d-matrix/solutions/688117/sou-suo-er-wei-ju-zhen-by-leetcode-solut-vxui/)

**思路**

由于每行的第一个元素大于前一行的最后一个元素，且每行元素是升序的，所以每行的第一个元素大于前一行的第一个元素，因此矩阵第一列的元素是升序的。

我们可以对矩阵的第一列的元素二分查找，找到最后一个不大于目标值的元素，然后在该元素所在行中二分查找目标值是否存在。

**代码**

```cpp
class Solution {
public:
    bool searchMatrix(vector<vector<int>> matrix, int target) {
        auto row = upper_bound(matrix.begin(), matrix.end(), target, [](const int b, const vector<int> &a) {
            return b < a[0];
        });
        if (row == matrix.begin()) {
            return false;
        }
        --row;
        return binary_search(row->begin(), row->end(), target);
    }
};
```

```java
class Solution {
    public boolean searchMatrix(int[][] matrix, int target) {
        int rowIndex = binarySearchFirstColumn(matrix, target);
        if (rowIndex < 0) {
            return false;
        }
        return binarySearchRow(matrix[rowIndex], target);
    }

    public int binarySearchFirstColumn(int[][] matrix, int target) {
        int low = -1, high = matrix.length - 1;
        while (low < high) {
            int mid = (high - low + 1) / 2 + low;
            if (matrix[mid][0] <= target) {
                low = mid;
            } else {
                high = mid - 1;
            }
        }
        return low;
    }

    public boolean binarySearchRow(int[] row, int target) {
        int low = 0, high = row.length - 1;
        while (low <= high) {
            int mid = (high - low) / 2 + low;
            if (row[mid] == target) {
                return true;
            } else if (row[mid] > target) {
                high = mid - 1;
            } else {
                low = mid + 1;
            }
        }
        return false;
    }
}
```

```go
func searchMatrix(matrix [][]int, target int) bool {
    row := sort.Search(len(matrix), func(i int) bool { return matrix[i][0] > target }) - 1
    if row < 0 {
        return false
    }
    col := sort.SearchInts(matrix[row], target)
    return col < len(matrix[row]) && matrix[row][col] == target
}
```

```javascript
var searchMatrix = function(matrix, target) {
    const rowIndex = binarySearchFirstColumn(matrix, target);
    if (rowIndex < 0) {
        return false;
    }
    return binarySearchRow(matrix[rowIndex], target);
};

const binarySearchFirstColumn = (matrix, target) => {
    let low = -1, high = matrix.length - 1;
    while (low < high) {
        const mid = Math.floor((high - low + 1) / 2) + low;
        if (matrix[mid][0] <= target) {
            low = mid;
        } else {
            high = mid - 1;
        }
    }
    return low;
}

const binarySearchRow = (row, target) => {
    let low = 0, high = row.length - 1;
    while (low <= high) {
        const mid = Math.floor((high - low) / 2) + low;
        if (row[mid] == target) {
            return true;
        } else if (row[mid] > target) {
            high = mid - 1;
        } else {
            low = mid + 1;
        }
    }
    return false;
}
```

```c
int binarySearchFirstColumn(int** matrix, int matrixSize, int target) {
    int low = -1, high = matrixSize - 1;
    while (low < high) {
        int mid = (high - low + 1) / 2 + low;
        if (matrix[mid][0] <= target) {
            low = mid;
        } else {
            high = mid - 1;
        }
    }
    return low;
}

bool binarySearchRow(int* row, int rowSize, int target) {
    int low = 0, high = rowSize - 1;
    while (low <= high) {
        int mid = (high - low) / 2 + low;
        if (row[mid] == target) {
            return true;
        } else if (row[mid] > target) {
            high = mid - 1;
        } else {
            low = mid + 1;
        }
    }
    return false;
}

bool searchMatrix(int** matrix, int matrixSize, int* matrixColSize, int target) {
    int rowIndex = binarySearchFirstColumn(matrix, matrixSize, target);
    if (rowIndex < 0) {
        return false;
    }
    return binarySearchRow(matrix[rowIndex], matrixColSize[rowIndex], target);
}
```

**复杂度分析**

-   时间复杂度：$O(\log m+\log n)=O(\log mn)$，其中 $m$ 和 $n$ 分别是矩阵的行数和列数。
-   空间复杂度：$O(1)$。
