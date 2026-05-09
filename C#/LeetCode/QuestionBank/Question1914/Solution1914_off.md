### [循环轮转矩阵](https://leetcode.cn/problems/cyclically-rotating-a-grid/solutions/847036/xun-huan-lun-zhuan-ju-zhen-by-leetcode-s-n9o9/)

#### 方法一：枚举每一层

**思路与算法**

对于一个 $m\times n$ 的矩阵 $grid$，它的层数为 $min(m/2,n/2)$。我们可以从外向内枚举矩阵的每一层模拟循环轮转操作。

为了方便模拟，我们从左上角起按照逆时针方向遍历每一层的元素。在本文中，我们将遍历过程分为四个部分，每个部分按顺序遍历每条边除了最后一个元素以外的所有元素。

我们将这些元素的行坐标、列坐标与数值保存在对应的数组 $r,c,val$ 中，并计算元素总数，即数组的长度 $total$。此时，如果对该层元素进行 $total$ 次循环轮转操作，那么该层元素不会改变。因此，实际的循环轮转操作数量即为 $kk=k%total$。

那么，这一层中遍历到的第 $i$ 个位置在轮转操作后存放的值对应 $val$ 数组中下标为 $(i-kk+total)%total$ 的值。此处在取模时加上 $total$ 是为了避免出现负数。

我们遍历行列坐标数组，并在 $grid$ 中更新每个坐标对应的轮转操作后的取值。当枚举并更新完所有层后，$grid$ 即为轮转操作后的矩阵。

**代码**

```C++
class Solution {
public:
    vector<vector<int>> rotateGrid(vector<vector<int>>& grid, int k) {
        int m = grid.size();
        int n = grid[0].size();
        int nlayer = min(m / 2, n / 2);   // 层数
        // 从左上角起逆时针枚举每一层
        for (int layer = 0; layer < nlayer; ++layer){
            vector<int> r, c, val;   // 每个元素的行下标，列下标与数值
            for (int i = layer; i < m - layer - 1; ++i){   // 左
                r.push_back(i);
                c.push_back(layer);
                val.push_back(grid[i][layer]);
            }
            for (int j = layer; j < n - layer - 1; ++j){   // 下
                r.push_back(m - layer - 1);
                c.push_back(j);
                val.push_back(grid[m-layer-1][j]);
            }
            for (int i = m - layer - 1; i > layer; --i){   // 右
                r.push_back(i);
                c.push_back(n - layer - 1);
                val.push_back(grid[i][n-layer-1]);
            }
            for (int j = n - layer - 1; j > layer; --j){   // 上
                r.push_back(layer);
                c.push_back(j);
                val.push_back(grid[layer][j]);
            }
            int total = val.size();   // 每一层的元素总数
            int kk = k % total;   // 等效轮转次数
            // 找到每个下标对应的轮转后的取值
            for (int i = 0; i < total; ++i){
                int idx = (i + total - kk) % total;   // 轮转后取值对应的下标
                grid[r[i]][c[i]] = val[idx];
            }
        }
        return grid;
    }
};
```

```Python
class Solution:
    def rotateGrid(self, grid: List[List[int]], k: int) -> List[List[int]]:
        m, n = len(grid), len(grid[0])
        nlayer = min(m // 2, n // 2)   # 层数
        # 从左上角起逆时针枚举每一层
        for layer in range(nlayer):
            r = []   # 每个元素的行下标
            c = []   # 每个元素的列下标
            val = []   # 每个元素的数值
            for i in range(layer, m - layer - 1):   # 左
                r.append(i)
                c.append(layer)
                val.append(grid[i][layer])
            for j in range(layer, n - layer - 1):   # 下
                r.append(m - layer - 1)
                c.append(j)
                val.append(grid[m-layer-1][j])
            for i in range(m - layer - 1, layer, -1):   # 右
                r.append(i)
                c.append(n - layer - 1)
                val.append(grid[i][n-layer-1])
            for j in range(n - layer - 1, layer, -1):   # 上
                r.append(layer)
                c.append(j)
                val.append(grid[layer][j])
            total = len(val)   # 每一层的元素总数
            kk = k % total   # 等效轮转次数
            # 找到每个下标对应的轮转后的取值
            for i in range(total):
                idx = (i + total - kk) % total   # 轮转后取值对应的下标
                grid[r[i]][c[i]] = val[idx]
        return grid
```

```Java
class Solution {
    public int[][] rotateGrid(int[][] grid, int k) {
        int m = grid.length;
        int n = grid[0].length;
        int nlayer = Math.min(m / 2, n / 2);   // 层数
        // 从左上角起逆时针枚举每一层
        for (int layer = 0; layer < nlayer; ++layer){
            List<Integer> r = new ArrayList<>();
            List<Integer> c = new ArrayList<>();
            List<Integer> val = new ArrayList<>();   // 每个元素的行下标，列下标与数值
            for (int i = layer; i < m - layer - 1; ++i){   // 左
                r.add(i);
                c.add(layer);
                val.add(grid[i][layer]);
            }
            for (int j = layer; j < n - layer - 1; ++j){   // 下
                r.add(m - layer - 1);
                c.add(j);
                val.add(grid[m - layer - 1][j]);
            }
            for (int i = m - layer - 1; i > layer; --i){   // 右
                r.add(i);
                c.add(n - layer - 1);
                val.add(grid[i][n - layer - 1]);
            }
            for (int j = n - layer - 1; j > layer; --j){   // 上
                r.add(layer);
                c.add(j);
                val.add(grid[layer][j]);
            }
            int total = val.size();   // 每一层的元素总数
            int kk = k % total;   // 等效轮转次数
            // 找到每个下标对应的轮转后的取值
            for (int i = 0; i < total; ++i){
                int idx = (i + total - kk) % total;   // 轮转后取值对应的下标
                grid[r.get(i)][c.get(i)] = val.get(idx);
            }
        }
        return grid;
    }
}
```

```CSharp
public class Solution {
    public int[][] RotateGrid(int[][] grid, int k) {
        int m = grid.Length;
        int n = grid[0].Length;
        int nlayer = Math.Min(m / 2, n / 2);   // 层数
        // 从左上角起逆时针枚举每一层
        for (int layer = 0; layer < nlayer; ++layer){
            List<int> r = new List<int>();
            List<int> c = new List<int>();
            List<int> val = new List<int>();   // 每个元素的行下标，列下标与数值
            for (int i = layer; i < m - layer - 1; ++i){   // 左
                r.Add(i);
                c.Add(layer);
                val.Add(grid[i][layer]);
            }
            for (int j = layer; j < n - layer - 1; ++j){   // 下
                r.Add(m - layer - 1);
                c.Add(j);
                val.Add(grid[m - layer - 1][j]);
            }
            for (int i = m - layer - 1; i > layer; --i){   // 右
                r.Add(i);
                c.Add(n - layer - 1);
                val.Add(grid[i][n - layer - 1]);
            }
            for (int j = n - layer - 1; j > layer; --j){   // 上
                r.Add(layer);
                c.Add(j);
                val.Add(grid[layer][j]);
            }
            int total = val.Count;   // 每一层的元素总数
            int kk = k % total;   // 等效轮转次数
            // 找到每个下标对应的轮转后的取值
            for (int i = 0; i < total; ++i){
                int idx = (i + total - kk) % total;   // 轮转后取值对应的下标
                grid[r[i]][c[i]] = val[idx];
            }
        }
        return grid;
    }
}
```

```Go
func rotateGrid(grid [][]int, k int) [][]int {
    m := len(grid)
    n := len(grid[0])
    nlayer := min(m / 2, n / 2)   // 层数
    // 从左上角起逆时针枚举每一层
    for layer := 0; layer < nlayer; layer++ {
        r := make([]int, 0)
        c := make([]int, 0)
        val := make([]int, 0)   // 每个元素的行下标，列下标与数值
        for i := layer; i < m - layer - 1; i++ {   // 左
            r = append(r, i)
            c = append(c, layer)
            val = append(val, grid[i][layer])
        }
        for j := layer; j < n - layer - 1; j++ {   // 下
            r = append(r, m - layer - 1)
            c = append(c, j)
            val = append(val, grid[m-layer - 1][j])
        }
        for i := m - layer - 1; i > layer; i-- {   // 右
            r = append(r, i)
            c = append(c, n - layer - 1)
            val = append(val, grid[i][n - layer - 1])
        }
        for j := n - layer - 1; j > layer; j-- {   // 上
            r = append(r, layer)
            c = append(c, j)
            val = append(val, grid[layer][j])
        }
        total := len(val)   // 每一层的元素总数
        kk := k % total   // 等效轮转次数
        // 找到每个下标对应的轮转后的取值
        for i := 0; i < total; i++ {
            idx := (i + total - kk) % total   // 轮转后取值对应的下标
            grid[r[i]][c[i]] = val[idx]
        }
    }
    return grid
}
```

```C
int** rotateGrid(int** grid, int gridSize, int* gridColSize, int k, int* returnSize, int** returnColumnSizes) {
    int m = gridSize;
    int n = gridColSize[0];
    *returnSize = m;
    *returnColumnSizes = (int*)malloc(m * sizeof(int));
    for (int i = 0; i < m; i++) {
        (*returnColumnSizes)[i] = n;
    }

    int nlayer = fmin(m / 2, n / 2);   // 层数
    // 从左上角起逆时针枚举每一层
    for (int layer = 0; layer < nlayer; ++layer) {
        int maxSize = 2 * (m + n - 4 * layer - 2);
        int* r = (int*)malloc(maxSize * sizeof(int));
        int* c = (int*)malloc(maxSize * sizeof(int));
        int* val = (int*)malloc(maxSize * sizeof(int));   // 每个元素的行下标，列下标与数值
        int idx = 0;

        for (int i = layer; i < m - layer - 1; ++i) {   // 左
            r[idx] = i;
            c[idx] = layer;
            val[idx] = grid[i][layer];
            idx++;
        }
        for (int j = layer; j < n - layer - 1; ++j) {   // 下
            r[idx] = m - layer - 1;
            c[idx] = j;
            val[idx] = grid[m - layer - 1][j];
            idx++;
        }
        for (int i = m - layer - 1; i > layer; --i) {   // 右
            r[idx] = i;
            c[idx] = n - layer - 1;
            val[idx] = grid[i][n - layer - 1];
            idx++;
        }
        for (int j = n - layer - 1; j > layer; --j) {   // 上
            r[idx] = layer;
            c[idx] = j;
            val[idx] = grid[layer][j];
            idx++;
        }

        int total = idx;   // 每一层的元素总数
        int kk = k % total;   // 等效轮转次数
        // 找到每个下标对应的轮转后的取值
        for (int i = 0; i < total; ++i) {
            int pos = (i + total - kk) % total;   // 轮转后取值对应的下标
            grid[r[i]][c[i]] = val[pos];
        }

        free(r);
        free(c);
        free(val);
    }
    return grid;
}
```

```JavaScript
var rotateGrid = function(grid, k) {
    const m = grid.length;
    const n = grid[0].length;
    const nlayer = Math.min(Math.floor(m / 2), Math.floor(n / 2));   // 层数
    // 从左上角起逆时针枚举每一层
    for (let layer = 0; layer < nlayer; ++layer) {
        const r = [];
        const c = [];
        const val = [];   // 每个元素的行下标，列下标与数值
        for (let i = layer; i < m - layer - 1; ++i) {   // 左
            r.push(i);
            c.push(layer);
            val.push(grid[i][layer]);
        }
        for (let j = layer; j < n - layer - 1; ++j) {   // 下
            r.push(m - layer - 1);
            c.push(j);
            val.push(grid[m - layer - 1][j]);
        }
        for (let i = m - layer - 1; i > layer; --i) {   // 右
            r.push(i);
            c.push(n - layer - 1);
            val.push(grid[i][n - layer - 1]);
        }
        for (let j = n - layer - 1; j > layer; --j) {   // 上
            r.push(layer);
            c.push(j);
            val.push(grid[layer][j]);
        }
        const total = val.length;   // 每一层的元素总数
        const kk = k % total;   // 等效轮转次数
        // 找到每个下标对应的轮转后的取值
        for (let i = 0; i < total; ++i) {
            const idx = (i + total - kk) % total;   // 轮转后取值对应的下标
            grid[r[i]][c[i]] = val[idx];
        }
    }
    return grid;
};
```

```TypeScript
function rotateGrid(grid: number[][], k: number): number[][] {
    const m: number = grid.length;
    const n: number = grid[0].length;
    const nlayer: number = Math.min(Math.floor(m / 2), Math.floor(n / 2));   // 层数
    // 从左上角起逆时针枚举每一层
    for (let layer = 0; layer < nlayer; ++layer) {
        const r: number[] = [];
        const c: number[] = [];
        const val: number[] = [];   // 每个元素的行下标，列下标与数值
        for (let i = layer; i < m - layer - 1; ++i) {   // 左
            r.push(i);
            c.push(layer);
            val.push(grid[i][layer]);
        }
        for (let j = layer; j < n - layer - 1; ++j) {   // 下
            r.push(m - layer - 1);
            c.push(j);
            val.push(grid[m - layer - 1][j]);
        }
        for (let i = m - layer - 1; i > layer; --i) {   // 右
            r.push(i);
            c.push(n - layer - 1);
            val.push(grid[i][n - layer - 1]);
        }
        for (let j = n - layer - 1; j > layer; --j) {   // 上
            r.push(layer);
            c.push(j);
            val.push(grid[layer][j]);
        }
        const total: number = val.length;   // 每一层的元素总数
        const kk: number = k % total;   // 等效轮转次数
        // 找到每个下标对应的轮转后的取值
        for (let i = 0; i < total; ++i) {
            const idx: number = (i + total - kk) % total;   // 轮转后取值对应的下标
            grid[r[i]][c[i]] = val[idx];
        }
    }
    return grid;
}
```

```Rust
impl Solution {
    pub fn rotate_grid(mut grid: Vec<Vec<i32>>, k: i32) -> Vec<Vec<i32>> {
        let m = grid.len();
        let n = grid[0].len();
        let nlayer = (m / 2).min(n / 2);   // 层数
        let k = k as usize;
        // 从左上角起逆时针枚举每一层
        for layer in 0..nlayer {
            let mut r = Vec::new();
            let mut c = Vec::new();
            let mut val = Vec::new();   // 每个元素的行下标，列下标与数值
            for i in layer..m - layer - 1 {   // 左
                r.push(i);
                c.push(layer);
                val.push(grid[i][layer]);
            }
            for j in layer..n - layer - 1 {   // 下
                r.push(m - layer - 1);
                c.push(j);
                val.push(grid[m - layer - 1][j]);
            }
            for i in (layer + 1..=m - layer - 1).rev() {   // 右
                r.push(i);
                c.push(n - layer - 1);
                val.push(grid[i][n - layer - 1]);
            }
            for j in (layer + 1..=n - layer - 1).rev() {   // 上
                r.push(layer);
                c.push(j);
                val.push(grid[layer][j]);
            }
            let total = val.len();   // 每一层的元素总数
            let kk = k % total;   // 等效轮转次数
            // 找到每个下标对应的轮转后的取值
            for i in 0..total {
                let idx = (i + total - kk) % total;   // 轮转后取值对应的下标
                grid[r[i]][c[i]] = val[idx];
            }
        }
        grid
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m$ 和 $n$ 分别为 $grid$ 的行数和列数。即为遍历 $grid$ 并进行旋转的时间复杂度。
- 空间复杂度：$O(m+n)$，即为存储每一层行列与数值的辅助数组大小。事实上，我们可以利用原地旋转将空间复杂度优化至 $O(1)$，但这样写出的代码并不直观，因此本题解中不给出空间复杂度最优的写法。
