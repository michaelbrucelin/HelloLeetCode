#### [方法一：直接查找](https://leetcode.cn/problems/search-a-2d-matrix-ii/solutions/1062538/sou-suo-er-wei-ju-zhen-ii-by-leetcode-so-9hcx/)

**思路与算法**

我们直接遍历整个矩阵 $matrix$，判断 $target$ 是否出现即可。

**代码**

```cpp
class Solution {
public:
    bool searchMatrix(vector<vector<int>>& matrix, int target) {
        for (const auto& row: matrix) {
            for (int element: row) {
                if (element == target) {
                    return true;
                }
            }
        }
        return false;
    }
};
```

```java
class Solution {
    public boolean searchMatrix(int[][] matrix, int target) {
        for (int[] row : matrix) {
            for (int element : row) {
                if (element == target) {
                    return true;
                }
            }
        }
        return false;
    }
}
```

```csharp
public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        foreach (int[] row in matrix) {
            foreach (int element in row) {
                if (element == target) {
                    return true;
                }
            }
        }
        return false;
    }
}
```

```python
class Solution:
    def searchMatrix(self, matrix: List[List[int]], target: int) -> bool:
        for row in matrix:
            for element in row:
                if element == target:
                    return True
        return False
```

```go
func searchMatrix(matrix [][]int, target int) bool {
    for _, row := range matrix {
        for _, v := range row {
            if v == target {
                return true
            }
        }
    }
    return false
}
```

**复杂度分析**

-   时间复杂度：$O(mn)$。
-   空间复杂度：$O(1)$。

#### [方法二：二分查找](https://leetcode.cn/problems/search-a-2d-matrix-ii/solutions/1062538/sou-suo-er-wei-ju-zhen-ii-by-leetcode-so-9hcx/)

**思路与算法**

由于矩阵 $matrix$ 中每一行的元素都是升序排列的，因此我们可以对每一行都使用一次二分查找，判断 $target$ 是否在该行中，从而判断 $target$ 是否出现。

**代码**

```cpp
class Solution {
public:
    bool searchMatrix(vector<vector<int>>& matrix, int target) {
        for (const auto& row: matrix) {
            auto it = lower_bound(row.begin(), row.end(), target);
            if (it != row.end() && *it == target) {
                return true;
            }
        }
        return false;
    }
};
```

```java
class Solution {
    public boolean searchMatrix(int[][] matrix, int target) {
        for (int[] row : matrix) {
            int index = search(row, target);
            if (index >= 0) {
                return true;
            }
        }
        return false;
    }

    public int search(int[] nums, int target) {
        int low = 0, high = nums.length - 1;
        while (low <= high) {
            int mid = (high - low) / 2 + low;
            int num = nums[mid];
            if (num == target) {
                return mid;
            } else if (num > target) {
                high = mid - 1;
            } else {
                low = mid + 1;
            }
        }
        return -1;
    }
}
```

```csharp
public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        foreach (int[] row in matrix) {
            int index = Search(row, target);
            if (index >= 0) {
                return true;
            }
        }
        return false;
    }

    public int Search(int[] nums, int target) {
        int low = 0, high = nums.Length - 1;
        while (low <= high) {
            int mid = (high - low) / 2 + low;
            int num = nums[mid];
            if (num == target) {
                return mid;
            } else if (num > target) {
                high = mid - 1;
            } else {
                low = mid + 1;
            }
        }
        return -1;
    }
}
```

```python
class Solution:
    def searchMatrix(self, matrix: List[List[int]], target: int) -> bool:
        for row in matrix:
            idx = bisect.bisect_left(row, target)
            if idx < len(row) and row[idx] == target:
                return True
        return False
```

```javascript
var searchMatrix = function(matrix, target) {
    for (const row of matrix) {
        const index = search(row, target);
        if (index >= 0) {
            return true;
        }
    }
    return false;
};

const search = (nums, target) => {
    let low = 0, high = nums.length - 1;
    while (low <= high) {
        const mid = Math.floor((high - low) / 2) + low;
        const num = nums[mid];
        if (num === target) {
            return mid;
        } else if (num > target) {
            high = mid - 1;
        } else {
            low = mid + 1;
        }
    }
    return -1;
}
```

```go
func searchMatrix(matrix [][]int, target int) bool {
    for _, row := range matrix {
        i := sort.SearchInts(row, target)
        if i < len(row) && row[i] == target {
            return true
        }
    }
    return false
}
```

**复杂度分析**

-   时间复杂度：$O(m \log n)$。对一行使用二分查找的时间复杂度为 $O(\log n)$，最多需要进行 $m$ 次二分查找。
-   空间复杂度：$O(1)$。
