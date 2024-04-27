### [查询网格图中每一列的宽度](https://leetcode.cn/problems/find-the-width-of-columns-of-a-grid/solutions/2751971/cha-xun-wang-ge-tu-zhong-mei-yi-lie-de-k-fm4d/)

#### 方法一：一次遍历

##### 思路与算法

遍历 $\textit{grid}$ 的每一列，求出将数字视为字符串时长度的最大值。

计算长度时，可以手动计算，也可以将数字转为字符串直接获取其长度。

##### 代码

以下是手动计算长度的代码

```c++
class Solution {
public:
    vector<int> findColumnWidth(vector<vector<int>>& grid) {
        int n = grid.size(), m = grid[0].size();
        vector<int> res(m);
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                int x = grid[i][j];
                int length = 0;
                if (x <= 0) {
                    length = 1;
                }
                while (x != 0) {
                    length += 1;
                    x /= 10;
                }
                res[j] = max(res[j], length);
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int[] findColumnWidth(int[][] grid) {
        int n = grid.length, m = grid[0].length;
        int[] res = new int[m];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                int x = grid[i][j];
                int length = 0;
                if (x <= 0) {
                    length = 1;
                }
                while (x != 0) {
                    length += 1;
                    x /= 10;
                }
                res[j] = Math.max(res[j], length);
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int[] FindColumnWidth(int[][] grid) {
        int n = grid.Length, m = grid[0].Length;
        int[] res = new int[m];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                int x = grid[i][j];
                int length = 0;
                if (x <= 0) {
                    length = 1;
                }
                while (x != 0) {
                    length += 1;
                    x /= 10;
                }
                res[j] = Math.Max(res[j], length);
            }
        }
        return res;
    }
}
```

```go
func findColumnWidth(grid [][]int) []int {
    n, m := len(grid), len(grid[0])
    res := make([]int, m)
    for i := 0; i < n; i++ {
        for j := 0; j < m; j++ {
            x, length := grid[i][j], 0
            if x <= 0 {
                length = 1
            }
            for x != 0 {
                length, x = length + 1, x / 10
            }
            res[j] = max(res[j], length)
        }
    }
    return res
}
```

```python
class Solution:
    def findColumnWidth(self, grid: List[List[int]]) -> List[int]:
        n, m = len(grid), len(grid[0])
        res = [0] * m
        for i in range(n):
            for j in range(m):
                x, length = grid[i][j], 0
                if x <= 0:
                    length, x = 1, -x
                while x != 0:
                    length, x = length + 1, x // 10
                res[j] = max(res[j], length)
        return res
```

```c
int* findColumnWidth(int** grid, int gridSize, int* gridColSize, int* returnSize) {
    int n = gridSize, m = gridColSize[0];
    int *res = (int *)malloc(sizeof(int) * m);
    *returnSize = m;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            int x = grid[i][j];
            int length = 0;
            if (x <= 0) {
                length = 1;
            }
            while (x != 0) {
                length += 1;
                x /= 10;
            }
            res[j] = fmax(res[j], length);
        }
    }
    return res;
}
```

```javascript
var findColumnWidth = function(grid) {
    const n = grid.length, m = grid[0].length;
    const res = new Array(m).fill(0);
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            let x = grid[i][j];
            let length = 0;
            if (x <= 0) {
                length = 1;
            }
            x = Math.abs(x);
            while (x != 0) {
                length += 1;
                x = Math.floor(x / 10);
            }
            res[j] = Math.max(res[j], length);
        }
    }
    return res;
};
```

```typescript
function findColumnWidth(grid: number[][]): number[] {
    const n = grid.length, m = grid[0].length;
    const res: number[] = new Array(m).fill(0);
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            let x = grid[i][j];
            let length = 0;
            if (x <= 0) {
                length = 1;
            }
            x = Math.abs(x);
            while (x != 0) {
                length += 1;
                x = Math.floor(x / 10);
            }
            res[j] = Math.max(res[j], length);
        }
    }
    return res;
};
```

```rust
impl Solution {
    pub fn find_column_width(grid: Vec<Vec<i32>>) -> Vec<i32> {
        let n = grid.len();
        let m = grid[0].len();
        let mut res = vec![0; m];
        for i in 0..n {
            for j in 0..m {
                let mut x = grid[i][j];
                let mut length = 0;
                if (x <= 0) {
                    length = 1;
                }
                while (x != 0) {
                    length += 1;
                    x /= 10;
                }
                res[j] = res[j].max(length);
            }
        }
        return res;
    }
}
```

以下是转为字符串后直接获取长度的代码

```c++
class Solution {
public:
    vector<int> findColumnWidth(vector<vector<int>>& grid) {
        int n = grid.size(), m = grid[0].size();
        vector<int> res(m);
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                res[j] = max(res[j], (int) to_string(grid[i][j]).size());
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int[] findColumnWidth(int[][] grid) {
        int n = grid.length, m = grid[0].length;
        int[] res = new int[m];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                res[j] = Math.max(res[j], String.valueOf(grid[i][j]).length());
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int[] FindColumnWidth(int[][] grid) {
        int n = grid.Length, m = grid[0].Length;
        int[] res = new int[m];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                res[j] = Math.Max(res[j], grid[i][j].ToString().Length);
            }
        }
        return res;
    }
}
```

```go
func findColumnWidth(grid [][]int) []int {
    n, m := len(grid), len(grid[0])
    res := make([]int, m)
    for i := 0; i < n; i++ {
        for j := 0; j < m; j++ {
            res[j] = max(res[j], len(strconv.Itoa(grid[i][j])))
        }
    }
    return res
}
```

```python
class Solution:
    def findColumnWidth(self, grid: List[List[int]]) -> List[int]:
        n, m = len(grid), len(grid[0])
        res = [0] * m
        for i in range(n):
            for j in range(m):
                res[j] = max(res[j], len(str(grid[i][j])))
        return res
```

```c
int* findColumnWidth(int** grid, int gridSize, int* gridColSize, int* returnSize) {
    int n = gridSize, m = gridColSize[0];
    char str[32];
    int *res = (int *)calloc(m, sizeof(int));
    *returnSize = m;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            sprintf(str, "%d", grid[i][j]);
            res[j] = fmax(res[j], strlen(str));
        }
    }
    return res;
}
```

```javascript
var findColumnWidth = function(grid) {
    const n = grid.length;
    const m = grid[0].length;
    const res = new Array(m).fill(0);
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            res[j] = Math.max(res[j], grid[i][j].toString().length);
        }
    }
    return res;
};
```

```typescript
function findColumnWidth(grid: number[][]): number[] {
    const n = grid.length;
    const m = grid[0].length;
    const res: number[] = new Array(m).fill(0);
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            res[j] = Math.max(res[j], grid[i][j].toString().length);
        }
    }
    return res;
};
```

```rust
impl Solution {
    pub fn find_column_width(grid: Vec<Vec<i32>>) -> Vec<i32> {
        let n = grid.len();
        let m = grid[0].len();
        let mut res = vec![0; m];
        for i in 0..n {
            for j in 0..m {
                let len = grid[i][j].to_string().chars().count();
                res[j] = res[j].max(len as i32);
            }
        }
        res
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(nm)$，其中 $n$ 是 $\textit{grid}$ 的行数，$m$ 是 $\textit{grid}$ 的列数。
- 空间复杂度：$O(1)$。除去返回值，只用到若干个变量。
