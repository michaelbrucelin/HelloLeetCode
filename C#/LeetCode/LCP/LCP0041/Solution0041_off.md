#### [方法一：广度优先搜索](https://leetcode.cn/problems/fHi6rV/solutions/2314858/hei-bai-fan-zhuan-qi-by-leetcode-solutio-1gl9/)

**思路与算法**

题目给出一个大小为 $n \times m$ 的黑白棋盘 $chessboard$，其中黑棋用 $'X'$ 表示，白棋用 $'O'$ 表示，空余位置用 $'.'$ 表示。现在我们可以在棋盘中的一个空余位置下一个黑棋，现在我们称「翻转操作」为：若存在在放置黑棋的位置的行、列或者对角线有另一颗黑棋能完全包围（中间不存在空白位置）白棋，那么我们可以翻转这些白棋，使其变为黑棋，并且这些翻转后得到的新黑棋同样可以进行「翻转操作」。现在我们需要求在放置一次黑棋的情况下最多能翻转多少颗白棋。

我们可以用「广度优先搜索」来解决这个问题，我们对每一个空余位置尝试黑棋放置，用一个队列来存储正在进行「翻转操作」的黑棋位置，若队列非空，我们从队列中取出队首元素，进行行、列和对角线 $8$ 个方向判断是否有可以翻转的白棋——判断沿着方向是否是连续的一段白棋并以另一颗黑棋结尾。若有可以翻转的白棋，则将这些白旗进行翻转，并加入队列中。直至队列为空表示一次放置黑棋结束。

初始可以放置黑棋的全部位置中可以翻转的白棋个数最大值即为最后的答案。

**代码**

```cpp
class Solution {
public:
    const int dirs[8][2] = {
        {1, 0}, {-1, 0}, {0, 1}, {0, -1}, {1, 1}, {1, -1}, {-1, 1}, {-1, -1}
    };

    bool judge(const vector<string>& chessboard, int x, int y, int dx, int dy) {
        x += dx;
        y += dy;
        while (0 <= x && x < chessboard.size() && 0 <= y && y < chessboard[0].size()) {
            if (chessboard[x][y] == 'X') {
                return true;
            } else if (chessboard[x][y] == '.') {
                return false;
            }
            x += dx;
            y += dy;
        }
        return false;
    }

    int bfs(vector<string> chessboard, int px, int py) {
        int cnt = 0;
        queue<pair<int, int>> q;
        q.emplace(px, py);
        chessboard[px][py] = 'X';
        while (!q.empty()) {
            pair<int, int> t = q.front();
            q.pop();
            for (int i = 0; i < 8; ++i) {
                if (judge(chessboard, t.first, t.second, dirs[i][0], dirs[i][1])) {
                    int x = t.first + dirs[i][0], y = t.second + dirs[i][1];
                    while (chessboard[x][y] != 'X') {
                        q.emplace(x, y);
                        chessboard[x][y] = 'X';
                        x += dirs[i][0];
                        y += dirs[i][1];
                        ++cnt;
                    }
                }
            }
        }
        return cnt;
    }

    int flipChess(vector<string>& chessboard) {
        int res = 0;
        for (int i = 0; i < chessboard.size(); ++i) {
            for (int j = 0; j < chessboard[0].size(); ++j) {
                if (chessboard[i][j] == '.') {
                    res = max(res, bfs(chessboard, i, j));
                }
            }
        }
        return res;
    }
};
```

```java
class Solution {
    static int[][] dirs = {
        {1, 0}, {-1, 0}, {0, 1}, {0, -1}, {1, 1}, {1, -1}, {-1, 1}, {-1, -1}
    };

    public int flipChess(String[] chessboard) {
        int res = 0;
        for (int i = 0; i < chessboard.length; ++i) {
            for (int j = 0; j < chessboard[0].length(); ++j) {
                if (chessboard[i].charAt(j) == '.') {
                    res = Math.max(res, bfs(chessboard, i, j));
                }
            }
        }
        return res;
    }

    public int bfs(String[] chessboard, int px, int py) {
        char[][] board = new char[chessboard.length][chessboard[0].length()];
        for (int i = 0; i < chessboard.length; ++i) {
            for (int j = 0; j < chessboard[0].length(); ++j) {
                board[i][j] = chessboard[i].charAt(j);
            }
        }
        int cnt = 0;
        Queue<int[]> queue = new ArrayDeque<int[]>();
        queue.offer(new int[]{px, py});
        board[px][py] = 'X';
        while (!queue.isEmpty()) {
            int[] t = queue.poll();
            for (int i = 0; i < 8; ++i) {
                if (judge(board, t[0], t[1], dirs[i][0], dirs[i][1])) {
                    int x = t[0] + dirs[i][0], y = t[1] + dirs[i][1];
                    while (board[x][y] != 'X') {
                        queue.offer(new int[]{x, y});
                        board[x][y] = 'X';
                        x += dirs[i][0];
                        y += dirs[i][1];
                        ++cnt;
                    }
                }
            }
        }
        return cnt;
    }

    public boolean judge(char[][] board, int x, int y, int dx, int dy) {
        x += dx;
        y += dy;
        while (0 <= x && x < board.length && 0 <= y && y < board[0].length) {
            if (board[x][y] == 'X') {
                return true;
            } else if (board[x][y] == '.') {
                return false;
            }
            x += dx;
            y += dy;
        }
        return false;
    }
}
```

```csharp
public class Solution {
    static int[][] dirs = {
        new int[]{1, 0}, new int[]{-1, 0}, new int[]{0, 1}, new int[]{0, -1}, new int[]{1, 1}, new int[]{1, -1}, new int[]{-1, 1}, new int[]{-1, -1}
    };

    public int FlipChess(string[] chessboard) {
        int res = 0;
        for (int i = 0; i < chessboard.Length; ++i) {
            for (int j = 0; j < chessboard[0].Length; ++j) {
                if (chessboard[i][j] == '.') {
                    res = Math.Max(res, Bfs(chessboard, i, j));
                }
            }
        }
        return res;
    }

    public int Bfs(string[] chessboard, int px, int py) {
        char[][] board = new char[chessboard.Length][];
        for (int i = 0; i < chessboard.Length; ++i) {
            board[i] = new char[chessboard[0].Length];
            for (int j = 0; j < chessboard[0].Length; ++j) {
                board[i][j] = chessboard[i][j];
            }
        }
        int cnt = 0;
        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(new Tuple<int, int>(px, py));
        board[px][py] = 'X';
        while (queue.Count > 0) {
            Tuple<int, int> t = queue.Dequeue();
            for (int i = 0; i < 8; ++i) {
                if (Judge(board, t.Item1, t.Item2, dirs[i][0], dirs[i][1])) {
                    int x = t.Item1 + dirs[i][0], y = t.Item2 + dirs[i][1];
                    while (board[x][y] != 'X') {
                        queue.Enqueue(new Tuple<int, int>(x, y));
                        board[x][y] = 'X';
                        x += dirs[i][0];
                        y += dirs[i][1];
                        ++cnt;
                    }
                }
            }
        }
        return cnt;
    }

    public bool Judge(char[][] board, int x, int y, int dx, int dy) {
        x += dx;
        y += dy;
        while (0 <= x && x < board.Length && 0 <= y && y < board[0].Length) {
            if (board[x][y] == 'X') {
                return true;
            } else if (board[x][y] == '.') {
                return false;
            }
            x += dx;
            y += dy;
        }
        return false;
    }
}
```

```c
const int dirs[8][2] = {
    {1, 0}, {-1, 0}, {0, 1}, {0, -1}, {1, 1}, {1, -1}, {-1, 1}, {-1, -1}
};

bool judge(const char **chessboard, int chessboardSize, int chessboardColSize, int x, int y, int dx, int dy) {
    x += dx;
    y += dy;
    while (0 <= x && x < chessboardSize && 0 <= y && y < chessboardColSize) {
        if (chessboard[x][y] == 'X') {
            return true;
        } else if (chessboard[x][y] == '.') {
            return false;
        }
        x += dx;
        y += dy;
    }
    return false;
}

int bfs(char **chessboard, int chessboardSize, int chessboardColSize, int px, int py) {
    int cnt = 0;
    int tot = chessboardSize * chessboardColSize;
    int queue[tot][2];
    int head = 0, tail = 0;
    queue[tail][0] = px;
    queue[tail][1] = py;
    tail++;
    chessboard[px][py] = 'X';
    while (head != tail) {
        int x = queue[head][0], y = queue[head][1];
        head++;
        printf("x = %d, y = %d\n", x, y);
        for (int i = 0; i < 8; ++i) {
            if (judge(chessboard, chessboardSize, chessboardColSize, x, y, dirs[i][0], dirs[i][1])) {
                int nx = x + dirs[i][0], ny = y + dirs[i][1];
                while (chessboard[nx][ny] != 'X') {
                    queue[tail][0] = nx;
                    queue[tail][1] = ny;
                    tail++;
                    chessboard[nx][ny] = 'X';
                    nx += dirs[i][0];
                    ny += dirs[i][1];
                    ++cnt;
                }
            }
        }
    }
    return cnt;
}

#define MAX(a, b) ((a) > (b) ? (a) : (b))

int flipChess(char** chessboard, int chessboardSize){
    int res = 0;
    int chessboardColSize = strlen(chessboard[0]);
    char* board[chessboardSize];
    for (int k = 0; k < chessboardSize; k++) {
        board[k] = (char *)calloc(chessboardColSize + 1, sizeof(char));
    }
    for (int i = 0; i < chessboardSize; ++i) {
        for (int j = 0; j < chessboardColSize; ++j) {
            if (chessboard[i][j] == '.') {
                for (int k = 0; k < chessboardSize; k++) {
                    strcpy(board[k], chessboard[k]);
                }
                int curr = bfs(board, chessboardSize, chessboardColSize, i, j);
                res = MAX(res, curr);
            }
        }
    }
    for (int k = 0; k < chessboardSize; k++) {
        free(board[k]);
    }
    return res;
}
```

```python
class Solution:
    def flipChess(self, chessboard: List[str]) -> int:
        def judge(chessboard: List[List[str]], x: int, y: int, dx: int, dy: int) -> bool:
            x += dx
            y += dy
            while 0 <= x < len(chessboard) and 0 <= y < len(chessboard[0]):
                if chessboard[x][y] == "X":
                    return True
                elif chessboard[x][y] == ".":
                    return False
                x += dx
                y += dy
            return False
        
        def bfs(chessboard: List[str], px: int, py: int) -> int:
            chessboard = [list(row) for row in chessboard]
            cnt = 0
            q = deque([(px, py)])
            chessboard[px][py] = "X"

            while q:
                tx, ty = q.popleft()
                for dx in [-1, 0, 1]:
                    for dy in [-1, 0, 1]:
                        if dx == dy == 0:
                            continue
                        if judge(chessboard, tx, ty, dx, dy):
                            x, y = tx + dx, ty + dy
                            while chessboard[x][y] != "X":
                                q.append((x, y))
                                chessboard[x][y] = "X"
                                x += dx
                                y += dy
                                cnt += 1
            return cnt

        res = 0
        for i in range(len(chessboard)):
            for j in range(len(chessboard[0])):
                if chessboard[i][j] == ".":
                    res = max(res, bfs(chessboard, i, j))
        return res
```

```javascript
const dirs = [
    [1, 0], [-1, 0], [0, 1], [0, -1], [1, 1], [1, -1], [-1, 1], [-1, -1]
];

function flipChess(chessboard) {
    let res = 0;
    for (let i = 0; i < chessboard.length; ++i) {
        for (let j = 0; j < chessboard[0].length; ++j) {
            if (chessboard[i][j] === '.') {
                res = Math.max(res, bfs(chessboard, i, j));
            }
        }
    }
    return res;
}

function bfs(chessboard, px, py) {
    const board = [];
    for (let i = 0; i < chessboard.length; ++i) {
        board[i] = chessboard[i].split('');
    }
    let cnt = 0;
    const queue = [];
    queue.push([px, py]);
    board[px][py] = 'X';
    const dirs = [[-1, 0], [1, 0], [0, -1], [0, 1], [-1, -1], [-1, 1], [1, -1], [1, 1]];
    while (queue.length > 0) {
        const t = queue.shift();
        for (let i = 0; i < 8; ++i) {
            if (judge(board, t[0], t[1], dirs[i][0], dirs[i][1])) {
                let x = t[0] + dirs[i][0], y = t[1] + dirs[i][1];
                while (board[x][y] !== 'X') {
                    queue.push([x, y]);
                    board[x][y] = 'X';
                    x += dirs[i][0];
                    y += dirs[i][1];
                    ++cnt;
                }
            }
        }
    }
    return cnt;
}

function judge(board, x, y, dx, dy) {
    x += dx;
    y += dy;
    while (0 <= x && x < board.length && 0 <= y && y < board[0].length) {
        if (board[x][y] === 'X') {
            return true;
        } else if (board[x][y] === '.') {
            return false;
        }
        x += dx;
        y += dy;
    }
    return false;
}
```

**复杂度分析**

-   时间复杂度：$O(n^2 \times m^2 \times \max\{n, m\})$，其中 $n$，$m$ 为给定棋盘的行列数。最多有 $n \times m$ 个初始放置黑棋的位置，每一个位置往 $8$ 个方向进行判断是否能翻转白棋的时间复杂度为 $O(\max\{n, m\})$，所以放置初始黑棋后进行「广度优先搜索」的时间复杂度为 $O(n \times m \times \max\{n, m\})$。
-   空间复杂度：$O(n^2 \times m^2)$，其中 $n$，$m$ 为给定棋盘的行列数。主要为每次「广度优先搜索」对初始棋盘进行复制和队列的空间开销。
