### [找出缺失和重复的数字](https://leetcode.cn/problems/find-missing-and-repeated-values/solutions/2792841/zhao-chu-que-shi-he-zhong-fu-de-shu-zi-b-zjw8/)

#### 方法一： 统计频数

**思路与算法**

用一个长度为 $n \times n + 1$ 数组，统计 $\textit{grid}$ 中数字出现的频数。再遍历频数数组，找出重复出现和没有出现的数字。

最后返回结果即可。

**代码**

```C++
class Solution {
public:
    vector<int> findMissingAndRepeatedValues(vector<vector<int>>& grid) {
        int n = grid.size();
        vector<int> count(n * n + 1);
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                count[grid[i][j]]++;
            }
        }

        vector<int> res(2);
        for (int i = 1; i <= n * n; i++) {
            if (count[i] == 2) {
                res[0] = i;
            }
            if (count[i] == 0) {
                res[1] = i;
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int[] findMissingAndRepeatedValues(int[][] grid) {
        int n = grid.length;
        int[] count = new int[n * n + 1];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                count[grid[i][j]]++;
            }
        }

        int[] res = new int[2];
        for (int i = 1; i <= n * n; i++) {
            if (count[i] == 2) {
                res[0] = i;
            }
            if (count[i] == 0) {
                res[1] = i;
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    def findMissingAndRepeatedValues(self, grid: List[List[int]]) -> List[int]:
        n = len(grid)
        count = [0] * (n * n + 1)
        count[0] = -1
        for i in range(n):
            for j in range(n):
                count[grid[i][j]] += 1
        return [count.index(2), count.index(0)]
```

```JavaScript
var findMissingAndRepeatedValues = function(grid) {
    const n = grid.length;
    const count = Array(n * n + 1).fill(0);
    count[0] = -1;
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            count[grid[i][j]]++;
        }
    }
    return [count.indexOf(2), count.indexOf(0)];
};
```

```TypeScript
function findMissingAndRepeatedValues(grid: number[][]): number[] {
    const n = grid.length;
    const count = Array(n * n + 1).fill(0);
    count[0] = -1;
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            count[grid[i][j]]++;
        }
    }
    return [count.indexOf(2), count.indexOf(0)];
};
```

```Go
func findMissingAndRepeatedValues(grid [][]int) []int {
    n := len(grid)
    count := make([]int, n * n + 1)
    for i := 0; i < n; i++ {
        for j := 0; j < n; j++ {
            count[grid[i][j]]++
        }
    }

    res := make([]int, 2)
    for i := 1; i <= n * n; i++ {
        if count[i] == 2 {
            res[0] = i;
        }
        if count[i] == 0 {
            res[1] = i;
        }
    }
    return res
}
```

```CSharp
public class Solution {
    public int[] FindMissingAndRepeatedValues(int[][] grid) {
        int n = grid.Length;
        int[] count = new int[n * n + 1];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                count[grid[i][j]]++;
            }
        }

        int[] res = new int[2];
        for (int i = 1; i <= n * n; i++) {
            if (count[i] == 2) {
                res[0] = i;
            }
            if (count[i] == 0) {
                res[1] = i;
            }
        }
        return res;
    }
}
```

```C
int* findMissingAndRepeatedValues(int** grid, int gridSize, int* gridColSize, int* returnSize) {
    int n = gridSize;
    int* count = (int *)calloc(n * n + 1, sizeof(int));
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            count[grid[i][j]]++;
        }
    }

    *returnSize = 2;
    int *res = (int *)malloc(2 * sizeof(int));
    for (int i = 1; i <= n * n; i++) {
        if (count[i] == 2) {
            res[0] = i;
        }
        if (count[i] == 0) {
            res[1] = i;
        }
    }
    free(count);
    return res;
}
```

```Rust
impl Solution {
    pub fn find_missing_and_repeated_values(grid: Vec<Vec<i32>>) -> Vec<i32> {
        let n = grid.len();
        let mut count = vec![0; n * n + 1];
        for row in grid.iter() {
            for &val in row.iter() {
                count[val as usize] += 1;
            }
        }

        let mut res = vec![0; 2];
        for i in 1..=n * n {
            if count[i as usize] == 2 {
                res[0] = i as i32;
            }
            if count[i as usize] == 0 {
                res[1] = i as i32;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \times n)$。
- 空间复杂度：$O(n \times n)$。
