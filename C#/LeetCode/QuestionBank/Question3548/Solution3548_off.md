### [等和矩阵分割 II](https://leetcode.cn/problems/equal-sum-grid-partition-ii/solutions/3926925/deng-he-ju-zhen-fen-ge-ii-by-leetcode-so-a7zq/)

#### 方法一：旋转矩阵 + 哈希表 + 枚举上半矩阵之和

**思路与算法**

本题是「[等和矩阵分割 I](https://leetcode.cn/problems/equal-sum-grid-partition-i/description/)」的增强版，在这一题的基础上，添加了 **删除至多一个单元格** 并且 **删除后剩余部分必须保持连通** 的条件。

那么需要进行删除的时候，我们需要考虑两条分割线的选取以及删除分割线哪一边的元素，为了简化思路，假设我们只判断是否存在水平分割线，并且进行删除操作时只删除水平分割线以上的元素。

能够发现，我们将矩阵进行 $3$ 次 $90$ 度的旋转，每次旋转后进行如上述所说的简化操作，就能够覆盖枚举分割线以及枚举删除元素的位置所带来的 $4$ 种不同情况。

接下来分析如何判断：

1. 假设当前 $grid$ 上半矩阵之和为 $sum$，整个矩阵 $grid$ 之和为 $total$，那么 $grid$ 下半矩阵之和为 $total-sum$。
2. 假设我们要删除的元素为 $x$，那么需要满足 $sum-x==total-sum$，于是有：$x==sum\times 2-total$。
3. 因此在枚举完每一行之后只需要判断是否存在 $grid[i][j]$ 满足 $grid[i][j]==sum\times 2-total$ 即可。

我们可以使用一个集合来保存出现过的元素，便于判断是否存在满足题目要求的元素，集合中可以预存一个 $0$，这样可以将删除元素与不删除元素合并为一种情况。

特殊情况处理：

1. 矩阵 $grid$ 在遍历第一行的情况：
  在遍历第一行时能够删除的元素只有第一行的首尾元素，因此在统计完第一行的和之后需要判断 $grid[0][0]$ 或者 $grid[0][n-1]$ 或者 $0$ 是否满足题目要求。
2. 矩阵 $grid$ 只有一列的情况：
  $grid$ 只有一列时能够删除的元素只有首行以及尾行的元素，需要在遍历第 $i$ 行后判断 $grid[0][0]$ 或者 $grid[i][0]$ 或者 $0$ 是否满足题目要求。
3. 当矩阵 $grid$ 只有一行时可以跳过，因为无法进行水平分割。

其他情况中 $grid$ 上半矩阵中所有的元素均可被删除。

在 $3$ 次旋转后就能够将所有情况覆盖到。

**代码**

```C++
class Solution {
public:
    vector<vector<int>> rotation(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        vector tmp(n, vector<int>(m));
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                tmp[j][m - 1 - i] = grid[i][j];
            }
        }
        return tmp;
    }
    bool canPartitionGrid(vector<vector<int>>& grid) {
        long long total = 0;
        long long sum;
        long long tag;
        int m = grid.size();
        int n = grid[0].size();
        unordered_set<long long> exist;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                total += grid[i][j];
            }
        }
        for (int k = 0; k < 4; k++) {
            exist.clear();
            exist.insert(0);
            sum = 0;
            m = grid.size();
            n = grid[0].size();
            if (m < 2) {
                grid = rotation(grid);
                continue;
            }
            if(n == 1){
                for(int i = 0; i < m - 1; i++){
                    sum += grid[i][0];
                    tag = sum * 2 - total;
                    if(tag == 0 || tag == grid[0][0] || tag == grid[i][0]){
                        return true;
                    }
                }
                grid = rotation(grid);
                continue;
            }
            for (int i = 0; i < m - 1; i++) {
                for(int j = 0; j < n; j++){
                    exist.insert(grid[i][j]);
                    sum += grid[i][j];
                }
                tag = sum * 2 - total;
                if(i == 0){
                    if(tag == 0 || tag == grid[0][0] || tag == grid[0][n - 1]){
                        return true;
                    }
                    continue;
                }
                if(exist.contains(tag)){
                    return true;
                }
            }
            grid = rotation(grid);
        }
        return false;
    }
};
```

```JavaScript
var canPartitionGrid = function(grid) {
    let total = 0;
    let m = grid.length;
    let n = grid[0].length;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            total += grid[i][j];
        }
    }
    for (let k = 0; k < 4; k++) {
        const exist = new Set();
        exist.add(0);
        let sum = 0;
        m = grid.length;
        n = grid[0].length;
        if (m < 2) {
            grid = rotation(grid);
            continue;
        }
        if (n == 1) {
            for (let i = 0; i < m - 1; i++) {
                sum += grid[i][0];
                let tag = sum * 2 - total;
                if (tag == 0 || tag == grid[0][0] || tag == grid[i][0]) {
                    return true;
                }
            }
            grid = rotation(grid);
            continue;
        }
        for (let i = 0; i < m - 1; i++) {
            for (let j = 0; j < n; j++) {
                exist.add(grid[i][j]);
                sum += grid[i][j];
            }
            let tag = sum * 2 - total;
            if (i == 0) {
                if (tag == 0 || tag == grid[0][0] || tag == grid[0][n - 1]) {
                    return true;
                }
                continue;
            }
            if (exist.has(tag)) {
                return true;
            }
        }
        grid = rotation(grid);
    }
    return false;
};

function rotation(grid) {
    const m = grid.length, n = grid[0].length;
    const tmp = Array.from({ length: n }, () => Array(m).fill(0));
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            tmp[j][m - 1 - i] = grid[i][j];
        }
    }
    return tmp;
}
```

```TypeScript
function canPartitionGrid(grid: number[][]): boolean {
    let total = 0;
    let m = grid.length;
    let n = grid[0].length;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            total += grid[i][j];
        }
    }
    for (let k = 0; k < 4; k++) {
        const exist = new Set<number>();
        exist.add(0);
        let sum = 0;
        m = grid.length;
        n = grid[0].length;
        if (m < 2) {
            grid = rotation(grid);
            continue;
        }
        if (n == 1) {
            for (let i = 0; i < m - 1; i++) {
                sum += grid[i][0];
                let tag = sum * 2 - total;
                if (tag == 0 || tag == grid[0][0] || tag == grid[i][0]) {
                    return true;
                }
            }
            grid = rotation(grid);
            continue;
        }
        for (let i = 0; i < m - 1; i++) {
            for (let j = 0; j < n; j++) {
                exist.add(grid[i][j]);
                sum += grid[i][j];
            }
            let tag = sum * 2 - total;
            if (i == 0) {
                if (tag == 0 || tag == grid[0][0] || tag == grid[0][n - 1]) {
                    return true;
                }
                continue;
            }
            if (exist.has(tag)) {
                return true;
            }
        }
        grid = rotation(grid);
    }
    return false;
}

function rotation(grid: number[][]): number[][] {
    const m = grid.length, n = grid[0].length;
    const tmp: number[][] = Array.from({ length: n }, () => Array(m).fill(0));
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            tmp[j][m - 1 - i] = grid[i][j];
        }
    }
    return tmp;
}
```

```Java
class Solution {
    public boolean canPartitionGrid(int[][] grid) {
        long total = 0;
        int m = grid.length;
        int n = grid[0].length;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                total += grid[i][j];
            }
        }
        for (int k = 0; k < 4; k++) {
            Set<Long> exist = new HashSet<>();
            exist.add(0L);
            long sum = 0;
            m = grid.length;
            n = grid[0].length;
            if (m < 2) {
                grid = rotation(grid);
                continue;
            }
            if (n == 1) {
                for (int i = 0; i < m - 1; i++) {
                    sum += grid[i][0];
                    long tag = sum * 2 - total;
                    if (tag == 0 || tag == grid[0][0] || tag == grid[i][0]) {
                        return true;
                    }
                }
                grid = rotation(grid);
                continue;
            }
            for (int i = 0; i < m - 1; i++) {
                for (int j = 0; j < n; j++) {
                    exist.add((long) grid[i][j]);
                    sum += grid[i][j];
                }
                long tag = sum * 2 - total;
                if (i == 0) {
                    if (tag == 0 || tag == grid[0][0] || tag == grid[0][n - 1]) {
                        return true;
                    }
                    continue;
                }
                if (exist.contains(tag)) {
                    return true;
                }
            }
            grid = rotation(grid);
        }
        return false;
    }

    public int[][] rotation(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        int[][] tmp = new int[n][m];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                tmp[j][m - 1 - i] = grid[i][j];
            }
        }
        return tmp;
    }
}
```

```CSharp
public class Solution {
    public bool CanPartitionGrid(int[][] grid) {
        long total = 0;
        int m = grid.Length;
        int n = grid[0].Length;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                total += grid[i][j];
            }
        }
        for (int k = 0; k < 4; k++) {
            HashSet<long> exist = new HashSet<long>();
            exist.Add(0);
            long sum = 0;
            m = grid.Length;
            n = grid[0].Length;
            if (m < 2) {
                grid = Rotation(grid);
                continue;
            }
            if (n == 1) {
                for (int i = 0; i < m - 1; i++) {
                    sum += grid[i][0];
                    long tag = sum * 2 - total;
                    if (tag == 0 || tag == grid[0][0] || tag == grid[i][0]) {
                        return true;
                    }
                }
                grid = Rotation(grid);
                continue;
            }
            for (int i = 0; i < m - 1; i++) {
                for (int j = 0; j < n; j++) {
                    exist.Add(grid[i][j]);
                    sum += grid[i][j];
                }
                long tag = sum * 2 - total;
                if (i == 0) {
                    if (tag == 0 || tag == grid[0][0] || tag == grid[0][n - 1]) {
                        return true;
                    }
                    continue;
                }
                if (exist.Contains(tag)) {
                    return true;
                }
            }
            grid = Rotation(grid);
        }
        return false;
    }

    public int[][] Rotation(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[][] tmp = new int[n][];
        for (int i = 0; i < n; i++) {
            tmp[i] = new int[m];
        }
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                tmp[j][m - 1 - i] = grid[i][j];
            }
        }
        return tmp;
    }
}
```

```Go
func canPartitionGrid(grid [][]int) bool {
    var total int64 = 0
    m, n := len(grid), len(grid[0])
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            total += int64(grid[i][j])
        }
    }
    for k := 0; k < 4; k++ {
        exist := make(map[int64]bool)
        exist[0] = true
        var sum int64 = 0
        m, n = len(grid), len(grid[0])
        if m < 2 {
            grid = rotation(grid)
            continue
        }
        if n == 1 {
            for i := 0; i < m-1; i++ {
                sum += int64(grid[i][0])
                tag := sum*2 - total
                if tag == 0 || tag == int64(grid[0][0]) || tag == int64(grid[i][0]) {
                    return true
                }
            }
            grid = rotation(grid)
            continue
        }
        for i := 0; i < m-1; i++ {
            for j := 0; j < n; j++ {
                exist[int64(grid[i][j])] = true
                sum += int64(grid[i][j])
            }
            tag := sum*2 - total
            if i == 0 {
                if tag == 0 || tag == int64(grid[0][0]) || tag == int64(grid[0][n-1]) {
                    return true
                }
                continue
            }
            if exist[tag] {
                return true
            }
        }
        grid = rotation(grid)
    }
    return false
}

func rotation(grid [][]int) [][]int {
    m, n := len(grid), len(grid[0])
    tmp := make([][]int, n)
    for i := range tmp {
        tmp[i] = make([]int, m)
    }
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            tmp[j][m-1-i] = grid[i][j]
        }
    }
    return tmp
}
```

```Python
class Solution:
    def canPartitionGrid(self, grid: List[List[int]]) -> bool:
        total = 0
        m = len(grid)
        n = len(grid[0])
        for i in range(m):
            for j in range(n):
                total += grid[i][j]
        for _ in range(4):
            exist = set()
            exist.add(0)
            sum_val = 0
            m = len(grid)
            n = len(grid[0])
            if m < 2:
                grid = self.rotation(grid)
                continue
            if n == 1:
                for i in range(m - 1):
                    sum_val += grid[i][0]
                    tag = sum_val * 2 - total
                    if tag == 0 or tag == grid[0][0] or tag == grid[i][0]:
                        return True
                grid = self.rotation(grid)
                continue
            for i in range(m - 1):
                for j in range(n):
                    exist.add(grid[i][j])
                    sum_val += grid[i][j]
                tag = sum_val * 2 - total
                if i == 0:
                    if tag == 0 or tag == grid[0][0] or tag == grid[0][n - 1]:
                        return True
                    continue
                if tag in exist:
                    return True
            grid = self.rotation(grid)
        return False

    def rotation(self, grid: List[List[int]]) -> List[List[int]]:
        m = len(grid)
        n = len(grid[0])
        tmp = [[0] * m for _ in range(n)]
        for i in range(m):
            for j in range(n):
                tmp[j][m - 1 - i] = grid[i][j]
        return tmp
```

```C
typedef struct {
    long long key;
    UT_hash_handle hh;
} HashItem;

static inline HashItem* hashFindItem(HashItem **obj, long long key) {
    HashItem *pEntry = NULL;
    HASH_FIND(hh, *obj, &key, sizeof(key), pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, long long key) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = malloc(sizeof(HashItem));
    if (!pEntry) return false;
    pEntry->key = key;
    HASH_ADD(hh, *obj, key, sizeof(key), pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr, *tmp;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr);
    }
    *obj = NULL;
}


int** rotation(int** grid, int m, int n, int* newM, int* newN) {
    *newM = n;
    *newN = m;
    int** tmp = malloc(n * sizeof(int*));
    int* data = malloc(n * m * sizeof(int));
    if (!tmp || !data) {
        free(tmp);
        free(data);
        return NULL;
    }
    for (int i = 0; i < n; i++) {
        tmp[i] = data + i * m;
    }
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            tmp[j][m - 1 - i] = grid[i][j];
        }
    }
    return tmp;
}

void freeGrid(int** grid, int rows) {
    if (grid && grid[0]) {
        free(grid[0]);
    }
    free(grid);
}

static inline bool checkAndReturnTrue(HashItem **exist, int** currentGrid, int currentM, int** originalGrid) {
    hashFree(exist);
    if (currentGrid != originalGrid) {
        freeGrid(currentGrid, currentM);
    }
    return true;
}

static inline void rotateAndUpdate(int** *currentGrid, int *currentM, int *currentN, int** originalGrid) {
    int newM, newN;
    int** newGrid = rotation(*currentGrid, *currentM, *currentN, &newM, &newN);
    if (*currentGrid != originalGrid) {
        freeGrid(*currentGrid, *currentM);
    }
    *currentGrid = newGrid;
    *currentM = newM;
    *currentN = newN;
}

bool canPartitionGrid(int** grid, int gridSize, int* gridColSize) {
    const int m = gridSize;
    const int n = gridColSize[0];
    long long total = 0;

    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            total += grid[i][j];
        }
    }
    int currentM = m, currentN = n;
    int** currentGrid = grid;

    for (int k = 0; k < 4; k++) {
        HashItem* exist = NULL;
        hashAddItem(&exist, 0LL);
        long long sum = 0;
        if (currentM < 2 || currentN == 1) {
            if (currentN == 1 && currentM >= 2) {
                for (int i = 0; i < currentM - 1; i++) {
                    sum += currentGrid[i][0];
                    long long tag = sum * 2 - total;
                    if (tag == 0 || tag == currentGrid[0][0] || tag == currentGrid[i][0]) {
                        return checkAndReturnTrue(&exist, currentGrid, currentM, grid);
                    }
                }
            }
            rotateAndUpdate(&currentGrid, &currentM, &currentN, grid);
            hashFree(&exist);
            continue;
        }

        for (int i = 0; i < currentM - 1; i++) {
            for (int j = 0; j < currentN; j++) {
                hashAddItem(&exist, (long long)currentGrid[i][j]);
                sum += currentGrid[i][j];
            }
            long long tag = sum * 2 - total;
            if (i == 0) {
                if (tag == 0 || tag == currentGrid[0][0] || tag == currentGrid[0][currentN - 1]) {
                    return checkAndReturnTrue(&exist, currentGrid, currentM, grid);
                }
                continue;
            }
            if (hashFindItem(&exist, tag)) {
                return checkAndReturnTrue(&exist, currentGrid, currentM, grid);
            }
        }

        rotateAndUpdate(&currentGrid, &currentM, &currentN, grid);
        hashFree(&exist);
    }

    if (currentGrid != grid) {
        freeGrid(currentGrid, currentM);
    }

    return false;
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    fn rotation(grid: &Vec<Vec<i32>>) -> Vec<Vec<i32>> {
        let m = grid.len();
        let n = grid[0].len();
        let mut tmp = vec![vec![0; m]; n];

        for i in 0..m {
            for j in 0..n {
                tmp[j][m - 1 - i] = grid[i][j];
            }
        }
        tmp
    }

    pub fn can_partition_grid(grid: Vec<Vec<i32>>) -> bool {
        let mut grid = grid;
        let mut total: i64 = 0;
        let mut sum: i64;
        let mut tag: i64;
        let mut m = grid.len();
        let mut n = grid[0].len();
        for i in 0..m {
            for j in 0..n {
                total += grid[i][j] as i64;
            }
        }

        let mut exist = HashSet::new();

        for _ in 0..4 {
            exist.clear();
            exist.insert(0);
            sum = 0;
            m = grid.len();
            n = grid[0].len();
            if m < 2 {
                grid = Self::rotation(&grid);
                continue;
            }
            if n == 1 {
                for i in 0..m - 1 {
                    sum += grid[i][0] as i64;
                    tag = sum * 2 - total;
                    if tag == 0 || tag == grid[0][0] as i64 || tag == grid[i][0] as i64 {
                        return true;
                    }
                }
                grid = Self::rotation(&grid);
                continue;
            }

            for i in 0..m - 1 {
                for j in 0..n {
                    exist.insert(grid[i][j] as i64);
                    sum += grid[i][j] as i64;
                }

                tag = sum * 2 - total;

                if i == 0 {
                    if tag == 0 || tag == grid[0][0] as i64 || tag == grid[0][n - 1] as i64 {
                        return true;
                    }
                    continue;
                }

                if exist.contains(&tag) {
                    return true;
                }
            }

            grid = Self::rotation(&grid);
        }

        false
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m$ 为 $grid$ 矩阵的行数，$n$ 为 $grid$ 矩阵的列数。
- 空间复杂度：$O(mn)$，其中 $m$ 为 $grid$ 矩阵的行数，$n$ 为 $grid$ 矩阵的列数。
