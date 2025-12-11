### [统计被覆盖的建筑](https://leetcode.cn/problems/count-covered-buildings/solutions/3843942/tong-ji-bei-fu-gai-de-jian-zhu-by-leetco-x6q3/)

#### 方法一：模拟

**思路与算法**

根据题意可知，给定二维数组 $buildings$，需要统计**被覆盖**的建筑数量。根据**被覆盖**的定义可知，该建筑的坐标在四个方向（左、右、上、下）中每个方向上都至少存在一个其他的坐标则称该建筑满足**被覆盖**。如果将这些散落的二维坐标看作一个区域，即需要统计没有处在**区域边缘**的坐标数量。

根据题意可知，所有的坐标均处于 $n\times n$ 的区域，二维坐标 $(x,y)$ 的取值范围 $x\in [0,n),y\in [0,n)$，我们可以关注哪些坐标是处于**区域边缘**，可以在行坐标与列坐标上分别判断：

- 如果一个坐标处在当前行的最左侧，由于所有的坐标均为**唯一**，那么它的左边没有其他坐标；如果一个坐标处在当前行的最右侧，由于所有的坐标均为**唯一**，那么它的右边没有其他坐标；
- 如果一个坐标处在当前列的最上侧，由于所有的坐标均为**唯一**，那么它的上边没有其他坐标；如果一个坐标处在当前列的最下侧，由于所有的坐标均为**唯一**，那么它的下边没有其他坐标；
- 如果一个坐标在既不在当前行的最左侧也不在最右侧，同时这个坐标也不在当前列的最上侧也不在当前列的最下侧，则该坐标在四个方向（左、右、上、下）中每个方向上都有其他坐标；

根据上述结论，实际计算过程如下：

- 我们遍历每个建筑的坐标，并统计每一行的最大值 $maxRow$ 和最小值 $minRow$，同时统计每一列的最大值 $maxCol$ 和最小值 $minCol$；
- 给定坐标 $(x,y)$，如果 $x$ 处于当前行的最小值和最大值之间（不能相等），同时y 也处于当前列的最小值和最大值之间（不能相等），则当前坐标符合**被覆盖**，答案 ans加 $1$；

最终返回结果 $ans$ 即可。

**代码**

```C++
class Solution {
public:
    int countCoveredBuildings(int n, vector<vector<int>>& buildings) {
        vector<int> maxRow(n + 1);
        vector<int> minRow(n + 1, n + 1);
        vector<int> maxCol(n + 1);
        vector<int> minCol(n + 1, n + 1);

        for (auto &p : buildings) {
            int x = p[0], y = p[1];
            maxRow[y] = max(maxRow[y], x);
            minRow[y] = min(minRow[y], x);
            maxCol[x] = max(maxCol[x], y);
            minCol[x] = min(minCol[x], y);
        }
        
        int res = 0;
        for (auto &p : buildings) {
            int x = p[0], y = p[1];
            if (x > minRow[y] && x < maxRow[y] && y > minCol[x] && y < maxCol[x]) {
                res++;
            }
        }

        return res;
    }
};
```

```Java
class Solution {
    public int countCoveredBuildings(int n, int[][] buildings) {
        int[] maxRow = new int[n + 1];
        int[] minRow = new int[n + 1];
        int[] maxCol = new int[n + 1];
        int[] minCol = new int[n + 1];
        
        Arrays.fill(minRow, n + 1);
        Arrays.fill(minCol, n + 1);

        for (int[] p : buildings) {
            int x = p[0], y = p[1];
            maxRow[y] = Math.max(maxRow[y], x);
            minRow[y] = Math.min(minRow[y], x);
            maxCol[x] = Math.max(maxCol[x], y);
            minCol[x] = Math.min(minCol[x], y);
        }
        
        int res = 0;
        for (int[] p : buildings) {
            int x = p[0], y = p[1];
            if (x > minRow[y] && x < maxRow[y] && 
                y > minCol[x] && y < maxCol[x]) {
                res++;
            }
        }
        
        return res;
    }
}
```

```CSharp
public class Solution {
    public int CountCoveredBuildings(int n, int[][] buildings) {
        int[] maxRow = new int[n + 1];
        int[] minRow = new int[n + 1];
        int[] maxCol = new int[n + 1];
        int[] minCol = new int[n + 1];
        
        Array.Fill(minRow, n + 1);
        Array.Fill(minCol, n + 1);
        foreach (var p in buildings) {
            int x = p[0], y = p[1];
            maxRow[y] = Math.Max(maxRow[y], x);
            minRow[y] = Math.Min(minRow[y], x);
            maxCol[x] = Math.Max(maxCol[x], y);
            minCol[x] = Math.Min(minCol[x], y);
        }
        
        int res = 0;
        foreach (var p in buildings) {
            int x = p[0], y = p[1];
            if (x > minRow[y] && x < maxRow[y] && 
                y > minCol[x] && y < maxCol[x]) {
                res++;
            }
        }
        
        return res;
    }
}
```

```Go
func countCoveredBuildings(n int, buildings [][]int) int {
    maxRow := make([]int, n + 1)
    minRow := make([]int, n + 1)
    maxCol := make([]int, n + 1)
    minCol := make([]int, n + 1)
    
    for i := range minRow {
        minRow[i] = n + 1
        minCol[i] = n + 1
    }
    
    for _, p := range buildings {
        x, y := p[0], p[1]
         maxRow[y] = max(maxRow[y], x)
        minRow[y] = min(minRow[y], x)
        maxCol[x] = max(maxCol[x], y)
        minCol[x] = min(minCol[x], y)
    }
    
    res := 0
    for _, p := range buildings {
        x, y := p[0], p[1]
        if x > minRow[y] && x < maxRow[y] && 
           y > minCol[x] && y < maxCol[x] {
            res++
        }
    }
    
    return res
}
```

```Python
class Solution:
    def countCoveredBuildings(self, n: int, buildings: List[List[int]]) -> int:
        max_row = [0] * (n + 1)
        min_row = [n + 1] * (n + 1)
        max_col = [0] * (n + 1)
        min_col = [n + 1] * (n + 1)
        
        for p in buildings:
            x, y = p[0], p[1]
            max_row[y] = max(max_row[y], x)
            min_row[y] = min(min_row[y], x)
            max_col[x] = max(max_col[x], y)
            min_col[x] = min(min_col[x], y)
        
        res = 0
        for p in buildings:
            x, y = p[0], p[1]
            if (x > min_row[y] and x < max_row[y] and 
                y > min_col[x] and y < max_col[x]):
                res += 1
        
        return res
```

```C
int countCoveredBuildings(int n, int** buildings, int buildingsSize, int* buildingsColSize) {
    int* maxRow = (int*)calloc(n + 1, sizeof(int));
    int* minRow = (int*)malloc((n + 1) * sizeof(int));
    int* maxCol = (int*)calloc(n + 1, sizeof(int));
    int* minCol = (int*)malloc((n + 1) * sizeof(int));
    
    for (int i = 0; i <= n; i++) {
        minRow[i] = n + 1;
        minCol[i] = n + 1;
    }
    
    for (int i = 0; i < buildingsSize; i++) {
        int x = buildings[i][0];
        int y = buildings[i][1];
        maxRow[y] = fmax(maxRow[y], x);
        minRow[y] = fmin(minRow[y], x);
        maxCol[x] = fmax(maxCol[x], y);
        minCol[x] = fmin(minCol[x], y);
    }
    
    int res = 0;
    for (int i = 0; i < buildingsSize; i++) {
        int x = buildings[i][0];
        int y = buildings[i][1];
        if (x > minRow[y] && x < maxRow[y] && 
            y > minCol[x] && y < maxCol[x]) {
            res++;
        }
    }
    
    free(maxRow);
    free(minRow);
    free(maxCol);
    free(minCol);
    
    return res;
}
```

```JavaScript
var countCoveredBuildings = function(n, buildings) {
    const maxRow = new Array(n + 1).fill(0);
    const minRow = new Array(n + 1).fill(n + 1);
    const maxCol = new Array(n + 1).fill(0);
    const minCol = new Array(n + 1).fill(n + 1);
    
    for (const p of buildings) {
        const x = p[0], y = p[1];
        maxRow[y] = Math.max(maxRow[y], x);
        minRow[y] = Math.min(minRow[y], x);
        maxCol[x] = Math.max(maxCol[x], y);
        minCol[x] = Math.min(minCol[x], y);
    }
    
    let res = 0;
    for (const p of buildings) {
        const x = p[0], y = p[1];
        if (x > minRow[y] && x < maxRow[y] && 
            y > minCol[x] && y < maxCol[x]) {
            res++;
        }
    }
    
    return res;
};
```

```TypeScript
function countCoveredBuildings(n: number, buildings: number[][]): number {
    const maxRow: number[] = new Array(n + 1).fill(0);
    const minRow: number[] = new Array(n + 1).fill(n + 1);
    const maxCol: number[] = new Array(n + 1).fill(0);
    const minCol: number[] = new Array(n + 1).fill(n + 1);
    
    for (const p of buildings) {
        const x = p[0], y = p[1];
        maxRow[y] = Math.max(maxRow[y], x);
        minRow[y] = Math.min(minRow[y], x);
        maxCol[x] = Math.max(maxCol[x], y);
        minCol[x] = Math.min(minCol[x], y);
    }
    
    let res = 0;
    for (const p of buildings) {
        const x = p[0], y = p[1];
        if (x > minRow[y] && x < maxRow[y] && 
            y > minCol[x] && y < maxCol[x]) {
            res++;
        }
    }
    
    return res;
}
```

```Rust
impl Solution {
    pub fn count_covered_buildings(n: i32, buildings: Vec<Vec<i32>>) -> i32 {
        let n_usize = n as usize;
        let mut max_row = vec![0; n_usize + 1];
        let mut min_row = vec![n + 1; n_usize + 1];
        let mut max_col = vec![0; n_usize + 1];
        let mut min_col = vec![n + 1; n_usize + 1];
        
        for p in &buildings {
            let x = p[0] as usize;
            let y = p[1] as usize;
            
            max_row[y] = max_row[y].max(x as i32);
            min_row[y] = min_row[y].min(x as i32);
            max_col[x] = max_col[x].max(y as i32);
            min_col[x] = min_col[x].min(y as i32);
        }
        
        let mut res = 0;
        for p in &buildings {
            let x = p[0] as usize;
            let y = p[1] as usize;
            
            if (x as i32) > min_row[y] && (x as i32) < max_row[y] && 
               (y as i32) > min_col[x] && (y as i32) < max_col[x] {
                res += 1;
            }
        }
        
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m)$，其中 $m$ 表示给定数组 $buildings$ 的长度。仅需遍历数组两遍即可，总的时间即为 $O(m)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示给定的数字 $n$。 需要保存每行与每列的最大值、最小值，一共需要保存 $n$ 行与 $n$ 列，因此需要的空间即为 $O(n)$。
