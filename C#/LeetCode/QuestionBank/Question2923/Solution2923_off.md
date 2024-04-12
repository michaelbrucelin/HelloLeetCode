### [找到冠军 I](https://leetcode.cn/problems/find-champion-i/solutions/2729340/zhao-dao-guan-jun-i-by-leetcode-solution-of98/)

#### 方法一：每行求和

##### 思路

矩阵每一行 $\textit{grid}[i]$ 表示队伍 $i$ 与其他队伍的强弱情况。如果队伍 $i$ 是冠军，那么对于所有 $j != i$，均有 $\textit{grid}[i][j] = 1$，而 $\textit{grid}[i][i] = 0$。因此如果队伍 $i$ 是冠军，则有 $\textit{sum}(\textit{grid}[i])=n-1$。队伍的强弱关系具有传递性，不能成环，所以一定存在冠军。又因为任何两个队伍，存在强弱关系。基于以上两点，有且只有一个冠军。只要遍历 $i$，找到第一个满足 $\textit{sum}(\textit{grid}[i])=n-1$ 的 $i$ 即可。

##### 代码

```python
class Solution:
    def findChampion(self, grid: List[List[int]]) -> int:
        n = len(grid)
        for i, line in enumerate(grid):
            if sum(line) == n - 1:
                return i
```

```java
class Solution {
    public int findChampion(int[][] grid) {
        int n = grid.length;
        for (int i = 0; i < n; i++) {
            int[] line = grid[i];
            int sum = 0;
            for (int num : line) {
                sum += num;
            }
            if (sum == n - 1) {
                return i;
            }
        }
        return -1;
    }
}
```

```csharp
public class Solution {
    public int FindChampion(int[][] grid) {
        int n = grid.Length;
        for (int i = 0; i < n; i++) {
            int[] line = grid[i];
            int sum = line.Sum();
            if (sum == n - 1) {
                return i;
            }
        }
        return -1;
    }
}
```

```c++
class Solution {
public:
    int findChampion(vector<vector<int>>& grid) {
        int n = grid.size();
        for (int i = 0; i < n; i++) {
            if (accumulate(grid[i].begin(), grid[i].end(), 0) == n - 1) {
                return i;
            }
        }
        return -1;
    }
};
```

```c
int findChampion(int** grid, int gridSize, int* gridColSize) {
    for (int i = 0; i < gridSize; i++) {
        int sum = 0;
        for (int j = 0; j < gridSize; j++) {
            sum += grid[i][j];
        }
        if (sum == gridSize - 1) {
            return i;
        }
    }
    return -1; 
}
```

```go
func findChampion(grid [][]int) int {
    n := len(grid)
    for i := 0; i < n; i++ {
        sum := 0
        for _, val := range grid[i] {
            sum += val
        }
        if sum == n-1 {
            return i
        }
    }
    return -1 
}
```

```javascript
var findChampion = function(grid) {
    const n = grid.length;
    for (let i = 0; i < n; i++) {
        const sum = grid[i].reduce((acc, val) => acc + val, 0);
        if (sum === n - 1) {
            return i;
        }
    }
    return -1;
};
```

```typescript
function findChampion(grid: number[][]): number {
    const n: number = grid.length;
    for (let i = 0; i < n; i++) {
        const sum: number = grid[i].reduce((acc, val) => acc + val, 0);
        if (sum === n - 1) {
            return i;
        }
    }
    return -1;
};
```

```rust
impl Solution {
    pub fn find_champion(grid: Vec<Vec<i32>>) -> i32 {
        let n = grid.len();
        for i in 0..n {
            let sum: i32 = grid[i].iter().sum();
            if sum == n as i32 - 1 {
                return i as i32;
            }
        }
        -1 
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n^2)$，需要对每一行求和。
- 时间复杂度：$O(1)$。
