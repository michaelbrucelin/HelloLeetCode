### [清理教室的最少移动](https://leetcode.cn/problems/minimum-moves-to-clean-the-classroom/solutions/4018466/qing-li-jiao-shi-de-zui-shao-yi-dong-by-fjd63/)

#### 方法一：广度优先搜索

**思路与算法**

本题是用「广度优先搜索」来计算最短路，但是在基础的位置信息 $x$ 和 $y$ 之外，还需要记录当前位置的能量 energy、已经走过的步数 $steps$ 以及统计当前已经清理了哪些垃圾，统计已经清理的垃圾可以用位运算来处理，每个垃圾预先分配一个从 $0$ 开始的编号。

在搜索过程中，从当前状态 $(x,y,mask,e,steps)$ 向四个方向移动，状态更新为：

- 当前位置：$(nx,ny)$。
- 已经收集的垃圾掩码：如果当前位置为 $‘L’$，那么往 $mask$ 中添加这个垃圾的编号，否则掩码不改变。
- 当前位置如果是 $‘R’$，那么当前位置能量更新为 $energy$，否则更新为 $e-1$。
- 当前位置的 $steps$ 更新为上一步 $steps$ 的加一即可。

「广度优先搜索」的起点为 $(sx,sy,0,energy,0)$，其中 $(sx,sy)$ 是学生的起点位置，终点为 $(nx,ny,fullMask,ne,steps)$，其中 $fullMask$ 表示所有垃圾编号的集合，$steps$ 表示走到终点的步数。

在「广度优先搜索」的过程中，我们可以用 $bestEnergy[x][y][mask]$ 来记录走到当前位置 $(x,y)$ 在不同 $mask$ 下的最大能量值，只有走到 $(x,y)$ 时带着大于 $bestEnergy[x][y][mask]$ 的能量时，这个状态才入队并更新 $bestEnergy[x][y][mask]$。这样做能避免相同 $(x,y,mask)$ 下更小的能量入队，避免诸如在两个位置之间反复横跳的能量消耗。

```C++
class Solution {
    static constexpr int dx[4] = {0, 1, 0, -1};
    static constexpr int dy[4] = {1, 0, -1, 0};

public:
    int minMoves(vector<string>& classroom, int energy) {
        int m = classroom.size();
        int n = classroom[0].size();
        vector id(m, vector<int>(n));
        int sx, sy, cnt = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (classroom[i][j] == 'S') {
                    sx = i;
                    sy = j;
                } else if (classroom[i][j] == 'L') {
                    id[i][j] = 1 << cnt++;
                }
            }
        }

        vector bestEnergy(m, vector(n, vector<int>(1 << cnt, -1)));
        bestEnergy[sx][sy][0] = energy;
        struct Info {
            int x, y, mask, e, steps;
        };
        queue<Info> q;
        q.push({sx, sy, 0, energy, 0});
        while (!q.empty()) {
            Info t = q.front();
            q.pop();
            if (t.mask == (1 << cnt) - 1) {
                return t.steps;
            }
            if (t.e == 0) {
                continue;
            }
            for (int i = 0; i < 4; i++) {
                int nx = t.x + dx[i];
                int ny = t.y + dy[i];

                if (nx < 0 || nx >= m || ny < 0 || ny >= n || classroom[nx][ny] == 'X') {
                    continue;
                }

                int ne = classroom[nx][ny] == 'R' ? energy : t.e - 1;
                int nmask = t.mask | id[nx][ny];

                if (ne > bestEnergy[nx][ny][nmask]) {
                    bestEnergy[nx][ny][nmask] = ne;
                    q.push({nx, ny, nmask, ne, t.steps + 1});
                }
            }
        }
        return -1;
    }
};
```

```Go
func minMoves(classroom []string, energy int) int {
    dx := []int{0, 1, 0, -1}
    dy := []int{1, 0, -1, 0}
    m := len(classroom)
    n := len(classroom[0])
    id := make([][]int, m)
    for i := 0; i < m; i++ {
        id[i] = make([]int, n)
    }
    var sx, sy int
    cnt := 0
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            if classroom[i][j] == 'S' {
                sx = i
                sy = j
            } else if classroom[i][j] == 'L' {
                id[i][j] = 1 << cnt
                cnt++
            }
        }
    }

    full := 1 << cnt
    bestEnergy := make([][][]int, m)
    for i := 0; i < m; i++ {
        bestEnergy[i] = make([][]int, n)
        for j := 0; j < n; j++ {
            bestEnergy[i][j] = make([]int, full)
            for k := 0; k < full; k++ {
                bestEnergy[i][j][k] = -1
            }
        }
    }
    bestEnergy[sx][sy][0] = energy

    type Info struct {
        x, y, mask, e, steps int
    }
    q := make([]Info, 0)
    q = append(q, Info{sx, sy, 0, energy, 0})
    head := 0
    for head < len(q) {
        t := q[head]
        head++
        if t.mask == full-1 {
            return t.steps
        }
        if t.e == 0 {
            continue
        }
        for d := 0; d < 4; d++ {
            nx := t.x + dx[d]
            ny := t.y + dy[d]
            if nx < 0 || nx >= m || ny < 0 || ny >= n || classroom[nx][ny] == 'X' {
                continue
            }
            ne := t.e - 1
            if classroom[nx][ny] == 'R' {
                ne = energy
            }
            nmask := t.mask | id[nx][ny]
            if ne > bestEnergy[nx][ny][nmask] {
                bestEnergy[nx][ny][nmask] = ne
                q = append(q, Info{nx, ny, nmask, ne, t.steps + 1})
            }
        }
    }
    return -1
}
```

```Python
class Solution:
    def minMoves(self, classroom: List[str], energy: int) -> int:
        dx = [0, 1, 0, -1]
        dy = [1, 0, -1, 0]
        m = len(classroom)
        n = len(classroom[0])
        id = [[0] * n for _ in range(m)]
        sx = sy = 0
        cnt = 0
        for i in range(m):
            for j in range(n):
                if classroom[i][j] == "S":
                    sx, sy = i, j
                elif classroom[i][j] == "L":
                    id[i][j] = 1 << cnt
                    cnt += 1

        full = 1 << cnt
        bestEnergy = [[[-1 for _ in range(full)] for _ in range(n)] for _ in range(m)]
        bestEnergy[sx][sy][0] = energy
        Info = collections.deque()
        Info.append((sx, sy, 0, energy, 0))
        while Info:
            x, y, mask, e, steps = Info.popleft()
            if mask == full - 1:
                return steps
            if e == 0:
                continue
            for d in range(4):
                nx = x + dx[d]
                ny = y + dy[d]
                if nx < 0 or nx >= m or ny < 0 or ny >= n or classroom[nx][ny] == "X":
                    continue
                ne = energy if classroom[nx][ny] == "R" else e - 1
                nmask = mask | id[nx][ny]
                if ne > bestEnergy[nx][ny][nmask]:
                    bestEnergy[nx][ny][nmask] = ne
                    Info.append((nx, ny, nmask, ne, steps + 1))
        return -1
```

```Java
class Solution {
    static final int[] dx = {0, 1, 0, -1};
    static final int[] dy = {1, 0, -1, 0};

    public int minMoves(String[] classroom, int energy) {
        int m = classroom.length;
        int n = classroom[0].length();
        int[][] id = new int[m][n];
        int sx = 0, sy = 0, cnt = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                char c = classroom[i].charAt(j);
                if (c == 'S') {
                    sx = i;
                    sy = j;
                } else if (c == 'L') {
                    id[i][j] = 1 << cnt;
                    cnt++;
                }
            }
        }
        int full = 1 << cnt;
        int[][][] bestEnergy = new int[m][n][full];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                Arrays.fill(bestEnergy[i][j], -1);
            }
        }

        bestEnergy[sx][sy][0] = energy;

        class Info {
            int x, y, mask, e, steps;

            Info(int x, int y, int mask, int e, int steps) {
                this.x = x;
                this.y = y;
                this.mask = mask;
                this.e = e;
                this.steps = steps;
            }
        }
        Deque<Info> q = new ArrayDeque<>();
        q.addLast(new Info(sx, sy, 0, energy, 0));
        while (!q.isEmpty()) {
            Info t = q.removeFirst();
            if (t.mask == full - 1) {
                return t.steps;
            }
            if (t.e == 0) {
                continue;
            }
            for (int d = 0; d < 4; d++) {
                int nx = t.x + dx[d];
                int ny = t.y + dy[d];
                if (nx < 0 || nx >= m || ny < 0 || ny >= n || classroom[nx].charAt(ny) == 'X') {
                    continue;
                }
                int ne = (classroom[nx].charAt(ny) == 'R') ? energy : t.e - 1;
                int nmask = t.mask | id[nx][ny];
                if (ne > bestEnergy[nx][ny][nmask]) {
                    bestEnergy[nx][ny][nmask] = ne;
                    q.addLast(new Info(nx, ny, nmask, ne, t.steps + 1));
                }
            }
        }
        return -1;
    }
}
```

```CSharp
public class Solution {
    static readonly int[] dx = new int[]{0, 1, 0, -1};
    static readonly int[] dy = new int[]{1, 0, -1, 0};

    public int MinMoves(string[] classroom, int energy) {
        int m = classroom.Length;
        int n = classroom[0].Length;
        int[,] id = new int[m, n];
        int sx = 0, sy = 0, cnt = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                char c = classroom[i][j];
                if (c == 'S') {
                    sx = i;
                    sy = j;
                } else if (c == 'L') {
                    id[i, j] = 1 << cnt;
                    cnt++;
                }
            }
        }
        int full = 1 << cnt;
        int[,,] bestEnergy = new int[m, n, full];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < full; k++) {
                    bestEnergy[i, j, k] = -1;
                }
            }
        }
        bestEnergy[sx, sy, 0] = energy;

        var q = new Queue<(int x, int y, int mask, int e, int steps)>();
        q.Enqueue((sx , sy, 0, energy, 0));
        while(q.Count > 0){
            var t = q.Dequeue();
            if (t.mask == full-1) {
                return t.steps;
            }
            if (t.e == 0) {
                continue;
            }
            for (int d = 0; d < 4; d++){
                int nx = t.x + dx[d];
                int ny = t.y + dy[d];
                if (nx < 0 || nx >= m || ny < 0 || ny >= n || classroom[nx][ny] == 'X') {
                    continue;
                }
                int ne = classroom[nx][ny]=='R' ? energy : t.e - 1;
                int nmask = t.mask | id[nx,ny];
                if (ne > bestEnergy[nx, ny, nmask]){
                    bestEnergy[nx, ny, nmask] = ne;
                    q.Enqueue((nx, ny, nmask, ne, t.steps+1));
                }
            }
        }
        return -1;
    }
}
```

```C
typedef struct {
    int x, y, mask, e, steps;
} Info;

int minMoves(char** classroom, int classroomSize, int energy) {
    static const int dx[4] = {0, 1, 0, -1};
    static const int dy[4] = {1, 0, -1, 0};

    int m = classroomSize;
    int n = (int)strlen(classroom[0]);

    int sx = 0, sy = 0, cnt = 0;
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (classroom[i][j] == 'S') {
                sx = i;
                sy = j;
            } else if (classroom[i][j] == 'L') {
                cnt++;
            }
        }
    }

    int totalStates = 1 << cnt;

    int* id = calloc(m * n, sizeof(int));
    {
        int c = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (classroom[i][j] == 'L') {
                    id[i * n + j] = 1 << c++;
                }
            }
        }
    }

    int totalEntries = m * n * totalStates;
    int* bestEnergy = malloc(totalEntries * sizeof(int));
    memset(bestEnergy, -1, totalEntries * sizeof(int));

    bestEnergy[sx * n * totalStates + sy * totalStates + 0] = energy;

    int qCap = 4096;
    Info* q = malloc(qCap * sizeof(Info));
    int qHead = 0, qTail = 0;

    q[qTail++] = (Info){sx, sy, 0, energy, 0};

    while (qHead < qTail) {
        Info t = q[qHead++];

        if (t.mask == totalStates - 1) {
            free(id);
            free(bestEnergy);
            free(q);
            return t.steps;
        }

        if (t.e == 0) {
            continue;
        }

        for (int i = 0; i < 4; i++) {
            int nx = t.x + dx[i];
            int ny = t.y + dy[i];

            if (nx < 0 || nx >= m || ny < 0 || ny >= n ||
                classroom[nx][ny] == 'X') {
                continue;
            }

            int ne = classroom[nx][ny] == 'R' ? energy : t.e - 1;
            int nmask = t.mask | id[nx * n + ny];
            int idx = ((nx * n) + ny) * totalStates + nmask;

            if (ne > bestEnergy[idx]) {
                bestEnergy[idx] = ne;
                if (qTail >= qCap) {
                    qCap *= 2;
                    q = realloc(q, qCap * sizeof(Info));
                }
                q[qTail++] = (Info){nx, ny, nmask, ne, t.steps + 1};
            }
        }
    }

    free(id);
    free(bestEnergy);
    free(q);

    return -1;
}
```

```JavaScript
function minMoves(classroom, energy) {
    const dx = [0, 1, 0, -1];
    const dy = [1, 0, -1, 0];
    const m = classroom.length;
    const n = classroom[0].length;
    const id = Array.from({length: m}, () => Array(n).fill(0));
    let sx = 0, sy = 0, cnt = 0;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            const c = classroom[i][j];
            if (c === 'S') {
                sx = i; sy = j;
            } else if (c === 'L') {
                id[i][j] = 1 << cnt; cnt++;
            }
        }
    }
    const full = 1 << cnt;
    const bestEnergy = Array.from({length: m}, () => Array.from({length: n}, () => Array(full).fill(-1)));
    bestEnergy[sx][sy][0] = energy;
    const q = [];
    q.push({x: sx, y: sy, mask: 0, e: energy, steps: 0});
    let head = 0;
    while (head < q.length) {
        const t = q[head++];
        if (t.mask === full - 1) {
            return t.steps;
        }
        if (t.e === 0) {
            continue;
        }
        for (let d = 0; d < 4; d++) {
            const nx = t.x + dx[d];
            const ny = t.y + dy[d];
            if (nx < 0 || nx >= m || ny < 0 || ny >= n) {
                continue;
            }
            const c = classroom[nx][ny];
            if (c === 'X') {
                continue;
            }
            const ne = c === 'R' ? energy : t.e - 1;
            const nmask = t.mask | id[nx][ny];
            if (ne > bestEnergy[nx][ny][nmask]) {
                bestEnergy[nx][ny][nmask] = ne;
                q.push({x: nx, y: ny, mask: nmask, e: ne, steps: t.steps + 1});
            }
        }
    }
    return -1;
}
```

```TypeScript
function minMoves(classroom: string[], energy: number): number {
    const dx = [0, 1, 0, -1];
    const dy = [1, 0, -1, 0];
    const m = classroom.length;
    const n = classroom[0].length;
    const id: number[][] = Array.from({length: m}, () => Array(n).fill(0));
    let sx = 0, sy = 0, cnt = 0;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            const c = classroom[i][j];
            if (c === 'S') {
                sx = i; sy = j;
            } else if (c === 'L') {
                id[i][j] = 1 << cnt; cnt++;
            }
        }
    }
    const full = 1 << cnt;
    const bestEnergy = Array.from({length: m}, () => Array.from({length: n}, () => Array(full).fill(-1)));
    bestEnergy[sx][sy][0] = energy;
    const q: {x: number, y: number, mask: number, e: number, steps: number}[] = [];
    q.push({x: sx, y: sy, mask: 0, e: energy, steps: 0});
    let head = 0;
    while (head < q.length) {
        const t = q[head++];
        if (t.mask === full - 1) {
            return t.steps;
        }
        if (t.e === 0) {
            continue;
        }
        for (let d = 0; d < 4; d++) {
            const nx = t.x + dx[d];
            const ny = t.y + dy[d];
            if (nx < 0 || nx >= m || ny < 0 || ny >= n) {
                continue;
            }
            const c = classroom[nx][ny];
            if (c === 'X') {
                continue;
            }
            const ne = c === 'R' ? energy : t.e - 1;
            const nmask = t.mask | id[nx][ny];
            if (ne > bestEnergy[nx][ny][nmask]) {
                bestEnergy[nx][ny][nmask] = ne;
                q.push({x: nx, y: ny, mask: nmask, e: ne, steps: t.steps + 1});
            }
        }
    }
    return -1;
}
```

```Rust
impl Solution {
    pub fn min_moves(classroom: Vec<String>, energy: i32) -> i32 {
        let dx = [0, 1, 0, -1];
        let dy = [1, 0, -1, 0];
        let m = classroom.len();
        let n = classroom[0].len();
        let mut id = vec![vec![0; n]; m];
        let mut sx = 0usize; let mut sy = 0usize; let mut cnt = 0;
        for i in 0..m {
            for j in 0..n {
                let c = classroom[i].as_bytes()[j] as char;
                if c=='S' {
                    sx = i; sy = j;
                } else if c=='L' {
                    id[i][j] = 1<<cnt; cnt += 1;
                }
            }
        }
        let full = 1<<cnt;
        let mut bestEnergy = vec![vec![vec![-1; full]; n]; m];
        bestEnergy[sx][sy][0] = energy;
        #[derive(Clone)]
        struct Info {x: usize, y: usize, mask: usize, e: i32, steps: i32}
        let mut q: Vec<Info> = Vec::new();
        q.push(Info{x:sx, y:sy, mask:0, e:energy, steps:0});
        let mut head: usize = 0;
        while head < q.len() {
            let t = q[head].clone(); head += 1;
            if t.mask == full-1 {
                return t.steps;
            }
            if t.e == 0 {
                continue;
            }
            for d in 0..4 {
                let nx_i = t.x as i32 + dx[d];
                let ny_i = t.y as i32 + dy[d];
                if nx_i < 0 || nx_i >= m as i32 || ny_i < 0 || ny_i >= n as i32 {
                    continue;
                }
                let nx = nx_i as usize; let ny = ny_i as usize;
                let c = classroom[nx].as_bytes()[ny] as char;
                if c == 'X' {
                    continue;
                }
                let ne = if c == 'R' {
                    energy
                } else {
                    t.e - 1
                };
                let nmask = t.mask | id[nx][ny] as usize;
                if ne > bestEnergy[nx][ny][nmask] {
                    bestEnergy[nx][ny][nmask] = ne;
                    q.push(Info{x: nx, y: ny, mask: nmask, e: ne, steps: t.steps+1});
                }
            }
        }
        -1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn\cdot energy\cdot 2^k)$，其中 $m$ 和 $n$ 分别是矩阵的行数和列数，$energy$ 为总能量，$k$ 为矩阵中 $‘L’$ 的个数，状态由位置和二进制掩码决定，同一位置同一掩码对应的能量 $bestEnergy[x][y][mask]$ 可能取到 $energy$ 种。
- 空间复杂度：$O(mn\cdot energy\cdot 2^k)$，其中 $m$ 和 $n$ 分别是矩阵的行数和列数，$energy$ 为总能量，$k$ 为矩阵中 $‘L’$ 的个数，这是队列需要的空间。
