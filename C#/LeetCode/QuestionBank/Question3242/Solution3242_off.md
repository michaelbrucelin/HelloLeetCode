### [设计相邻元素求和服务](https://leetcode.cn/problems/design-neighbor-sum-service/solutions/2977803/she-ji-xiang-lin-yuan-su-qiu-he-fu-wu-by-po0u/)

#### 方法一：将每个元素的位置放入哈希表

**思路与算法**

由于询问时给定的是元素而不是元素在二维数组中的位置，因此在初始化时，我们可以使用一个哈希表 $pos$ 存储每一个元素所在的位置：$pos$ 中的每个键表示一个元素，对应的值是一个二元组，表示其在二维数组中的位置。

同时，在初始化时，我们存储给定的二维数组 $grid$ 的一份拷贝。这样一来，在查询操作 $adjacentSum(value)$ 和 $diagonalSum(value)$ 中，我们首先通过 $pos$ 获取 $value$ 的位置，随后根据查询的类型，返回四个相邻元素的和即可。

**细节**

为了防止重复编写代码，可以使用一个辅助函数 $getSum(value,idx)$，其中 $idx=0$ 表示相邻，$idx=1$ 表示对角线相邻。

**代码**

```C++
class NeighborSum {
public:
    NeighborSum(vector<vector<int>>& grid) {
        for (int i = 0; i < grid.size(); ++i) {
            for (int j = 0; j < grid[0].size(); ++j) {
                pos[grid[i][j]] = {i, j};
            }
        }
        this->grid = move(grid);
    }

    int adjacentSum(int value) {
        return getSum(value, 0);
    }

    int diagonalSum(int value) {
        return getSum(value, 1);
    }

    int getSum(int value, int idx) {
        auto [x, y] = pos[value];
        int ans = 0;
        for (int d = 0; d < 4; ++d) {
            int nx = x + dirs[idx][d][0];
            int ny = y + dirs[idx][d][1];
            if (0 <= nx && nx < grid.size() && 0 <= ny && ny < grid[0].size()) {
                ans += grid[nx][ny];
            }
        }
        return ans;
    }

private:
    vector<vector<int>> grid;
    unordered_map<int, pair<int, int>> pos;
    static constexpr int dirs[2][4][2] = {
        {{-1, 0}, {1, 0}, {0, -1}, {0, 1}},
        {{-1, -1}, {-1, 1}, {1, -1}, {1, 1}}
    };
};
```

```Python
class NeighborSum:
    dirs = [
        [(-1, 0), (1, 0), (0, -1), (0, 1)],
        [(-1, -1), (-1, 1), (1, -1), (1, 1)],
    ]

    def __init__(self, grid: List[List[int]]):
        self.pos = dict()
        for i in range(len(grid)):
            for j in range(len(grid[0])):
                self.pos[grid[i][j]] = (i, j)
        self.grid = grid

    def adjacentSum(self, value: int) -> int:
        return self.getSum(value, 0)

    def diagonalSum(self, value: int) -> int:
        return self.getSum(value, 1)

    def getSum(self, value: int, idx: int) -> int:
        x, y = self.pos[value]
        ans = 0
        for (dx, dy) in NeighborSum.dirs[idx]:
            nx, ny = x + dx, y + dy
            if 0 <= nx < len(self.grid) and 0 <= ny < len(self.grid[0]):
                ans += self.grid[nx][ny]
        return ans
```

```Java
class NeighborSum {
    private int[][] grid;
    private Map<Integer, int[]> pos;
    private final int[][][] dirs = {
        {{-1, 0}, {1, 0}, {0, -1}, {0, 1}},
        {{-1, -1}, {-1, 1}, {1, -1}, {1, 1}}
    };

    public NeighborSum(int[][] grid) {
        this.grid = grid;
        this.pos = new HashMap<>();
        for (int i = 0; i < grid.length; i++) {
            for (int j = 0; j < grid[0].length; j++) {
                pos.put(grid[i][j], new int[]{i, j});
            }
        }
    }

    public int adjacentSum(int value) {
        return getSum(value, 0);
    }

    public int diagonalSum(int value) {
        return getSum(value, 1);
    }

    public int getSum(int value, int idx) {
        int[] p = pos.get(value);
        int x = p[0], y = p[1];
        int sum = 0;
        for (int[] dir : dirs[idx]) {
            int nx = x + dir[0];
            int ny = y + dir[1];
            if (nx >= 0 && nx < grid.length && ny >= 0 && ny < grid[0].length) {
                sum += grid[nx][ny];
            }
        }
        return sum;
    }
}
```

```CSharp
public class NeighborSum {
    private readonly int[][] grid;
    private readonly Dictionary<int, (int, int)> pos;
    private static int[,,] dirs = new int[2, 4, 2] {
        { {-1, 0}, {1, 0}, {0, -1}, {0, 1} },
        { {-1, -1}, {-1, 1}, {1, -1}, {1, 1} }
    };

    public NeighborSum(int[][] grid) {
        this.grid = grid;
        this.pos = new Dictionary<int, (int, int)>();
        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid[0].Length; ++j) {
                pos[grid[i][j]] = (i, j);
            }
        }
    }

    public int AdjacentSum(int value) {
        return GetSum(value, 0);
    }

    public int DiagonalSum(int value) {
        return GetSum(value, 1);
    }

    private int GetSum(int value, int idx) {
        if (!pos.TryGetValue(value, out var position)) {
            return 0;
        }
        int x = position.Item1;
        int y = position.Item2;
        int sum = 0;
        for (int d = 0; d < 4; ++d) {
            int nx = x + dirs[idx, d, 0];
            int ny = y + dirs[idx, d, 1];
            if (nx >= 0 && nx < grid.Length && ny >= 0 && ny < grid[0].Length) {
                sum += grid[nx][ny];
            }
        }
        return sum;
    }
}
```

```Go
type NeighborSum struct {
    grid [][]int
    pos  map[int][2]int
}

var dirs = [2][4][2]int{
    {{-1, 0}, {1, 0}, {0, -1}, {0, 1}},
    {{-1, -1}, {-1, 1}, {1, -1}, {1, 1}},
}

func Constructor(grid [][]int) NeighborSum {
    this := NeighborSum {
        grid: grid,
        pos:  make(map[int][2]int),
    }
    for i := range grid {
        for j := range grid[0] {
            this.pos[grid[i][j]] = [2]int{i, j}
        }
    }

    return this
}

func (this *NeighborSum) AdjacentSum(value int) int {
    return this.getSum(value, 0)
}

func (this *NeighborSum) DiagonalSum(value int) int {
    return this.getSum(value, 1)
}

func (this *NeighborSum) getSum(value, idx int) int {
    pos := this.pos[value]
    x, y := pos[0], pos[1]
    sum := 0
    for _, dir := range dirs[idx] {
        nx, ny := x + dir[0], y + dir[1]
        if nx >= 0 && nx < len(this.grid) && ny >= 0 && ny < len(this.grid[0]) {
            sum += this.grid[nx][ny]
        }
    }
    return sum
}
```

```C
int dirs[2][4][2] = {
    {{-1, 0}, {1, 0}, {0, -1}, {0, 1}},
    {{-1, -1}, {-1, 1}, {1, -1}, {1, 1}}
};

typedef struct {
    int **grid;
    int rows;
    int cols;
    int **positions;
} NeighborSum;

NeighborSum* neighborSumCreate(int** grid, int gridSize, int* gridColSize) {
    NeighborSum* obj = (NeighborSum*)malloc(sizeof(NeighborSum));
    obj->grid = grid;
    obj->rows = gridSize;
    obj->cols = gridColSize[0];
    obj->positions = (int**)malloc(obj->rows * obj->cols * sizeof(int*));
    for (int i = 0; i < obj->rows; i++) {
        for (int j = 0; j < obj->cols; j++) {
            obj->positions[grid[i][j]] = (int *)malloc(sizeof(int) * 2);
            obj->positions[grid[i][j]][0] = i;
            obj->positions[grid[i][j]][1] = j;
        }
    }
    return obj;
}

int NeighborSumGetSum(NeighborSum* obj, int value, int idx) {
    int *p = obj->positions[value];
    int x = p[0], y = p[1];
    int sum = 0;
    for (int i = 0; i < 4; i++) {
        int nx = x + dirs[idx][i][0];
        int ny = y + dirs[idx][i][1];
        if (nx >= 0 && nx < obj->rows && ny >= 0 && ny < obj->cols) {
            sum += obj->grid[nx][ny];
        }
    }
    return sum;
}

int neighborSumAdjacentSum(NeighborSum* obj, int value) {
    return NeighborSumGetSum(obj, value, 0);
}

int neighborSumDiagonalSum(NeighborSum* obj, int value) {
    return NeighborSumGetSum(obj, value, 1);
}

void neighborSumFree(NeighborSum* obj) {
    for (int i = 0; i < obj->rows * obj->cols; i++) {
        free(obj->positions[i]);
    }
    free(obj->positions);
    free(obj);
}
```

```JavaScript
var NeighborSum = function(grid) {
    this.grid = grid;
    this.pos = {};
    for (let i = 0; i < grid.length; i++) {
        for (let j = 0; j < grid[0].length; j++) {
            this.pos[grid[i][j]] = [i, j];
        }
    }
};

const dirs = [
    [[-1, 0], [1, 0], [0, -1], [0, 1]],
    [[-1, -1], [-1, 1], [1, -1], [1, 1]]
];

NeighborSum.prototype.adjacentSum = function(value) {
    return this.getSum(value, 0);
};

NeighborSum.prototype.diagonalSum = function(value) {
    return this.getSum(value, 1);
};

NeighborSum.prototype.getSum = function(value, idx) {
    const [x, y] = this.pos[value];
    let sum = 0;
    for (const [dx, dy] of dirs[idx]) {
        const nx = x + dx;
        const ny = y + dy;
        if (nx >= 0 && nx < this.grid.length && ny >= 0 && ny < this.grid[0].length) {
            sum += this.grid[nx][ny];
        }
    }
    return sum;
}
```

```TypeScript
const dirs = [
    [[-1, 0], [1, 0], [0, -1], [0, 1]],
    [[-1, -1], [-1, 1], [1, -1], [1, 1]]
];

class NeighborSum {
    private grid: number[][];
    private pos: { [key: number]: [number, number] };
    private dirs: [number, number][][];
    constructor(grid: number[][]) {
        this.grid = grid;
        this.pos = {};
        for (let i = 0; i < grid.length; i++) {
            for (let j = 0; j < grid[0].length; j++) {
                this.pos[grid[i][j]] = [i, j];
            }
        }
    }

    adjacentSum(value: number): number {
        return this.getSum(value, 0);
    }

    diagonalSum(value: number): number {
        return this.getSum(value, 1);
    }

    getSum(value: number, idx: number): number {
        const [x, y] = this.pos[value];
        let sum = 0;
        for (const [dx, dy] of dirs[idx]) {
            const nx = x + dx;
            const ny = y + dy;
            if (nx >= 0 && nx < this.grid.length && ny >= 0 && ny < this.grid[0].length) {
                sum += this.grid[nx][ny];
            }
        }
        return sum;
    }
}
```

```Rust
use std::collections::HashMap;

const dirs: [ &[(i32, i32)]; 2] = [
    &[(-1, 0), (1, 0), (0, -1), (0, 1)],
    &[(-1, -1), (-1, 1), (1, -1), (1, 1)],
];

struct NeighborSum {
    grid: Vec<Vec<i32>>,
    pos: HashMap<i32, (usize, usize)>,
}

impl NeighborSum {

    fn new(grid: Vec<Vec<i32>>) -> Self {
        let mut pos = HashMap::new();
        for (i, row) in grid.iter().enumerate() {
            for (j, &val) in row.iter().enumerate() {
                pos.insert(val, (i, j));
            }
        }
        NeighborSum { grid, pos }
    }

    fn adjacent_sum(&self, value: i32) -> i32 {
        self.get_sum(value, 0)
    }

    fn diagonal_sum(&self, value: i32) -> i32 {
        self.get_sum(value, 1)
    }

    fn get_sum(&self, value: i32, idx: usize) -> i32 {
        if let Some(&(x, y)) = self.pos.get(&value) {
            let mut sum = 0;
            for &(dx, dy) in dirs[idx] {
                let nx = x as i32 + dx;
                let ny = y as i32 + dy;
                if nx >= 0 && (nx as usize) < self.grid.len() && ny >= 0 && (ny as usize) < self.grid[0].len() {
                    sum += self.grid[nx as usize][ny as usize];
                }
            }
            sum
        } else {
            0
        }
    }
}
```

**复杂度分析**

- 时间复杂度：初始化需要的时间为 $O(n^2)$，每一次查询操作需要的时间为 $O(1)$。
- 空间复杂度：整个类需要的空间为 $O(n^2)$，其中包含 $O(n^2)$ 的哈希表空间或 $O(n^2)/O(1)$ 的二维数组 $grid$ 的副本的空间。每一次查询操作需要的空间为 $O(1)$。
