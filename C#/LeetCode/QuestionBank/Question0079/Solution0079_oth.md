### [极致优化！代码击败接近 100%！（Python/Java/C++/C/Go/JS/Rust）](https://leetcode.cn/problems/word-search/solutions/2927294/liang-ge-you-hua-rang-dai-ma-ji-bai-jie-g3mmm/?envType=problem-list-v2&envId=tBJHVASZ)

#### 前置知识

做本题前，你需要有一些网格图 $DFS$ 的经验和回溯的经验。

- 关于网格图 $DFS$，可以做做 [200\. 岛屿数量](https://leetcode.cn/problems/number-of-islands/)。
- 关于回溯，可以看[【基础算法精讲 14】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1mG4y1A7Gu%2F)。

#### 基本思路（优化前）

枚举 $i=0,1,2,\dots ,m-1$ 和 $j=0,1,2,\dots ,n-1$，以 $(i,j)$ 为起点开始搜索。

同时，我们还需要知道当前匹配到了 $word$ 的第几个字母，所以还需要一个参数 $k$。

定义 $dfs(i,j,k)$ 表示当前在 $board[i][j]$ 这个格子，要匹配 $word[k]$，返回在这个状态下最终能否匹配成功（搜索成功）。

分类讨论：

- 如果 $board[i][j]\ne word[k]$，匹配失败，返回 $false$。
- 否则，如果 $k=len(word)-1$，匹配成功，返回 $true$。
- 否则，枚举 $(i,j)$ 周围的四个相邻格子 $(x,y)$，如果 $(x,y)$ 没有出界，则递归 $dfs(x,y,k+1)$，如果其返回 $true$，则 $dfs(i,j,k)$ 也返回 $true$。
- 如果递归周围的四个相邻格子都没有返回 $true$，则最后返回 $false$，表示没有搜到。

细节：

- 递归过程中，为了避免重复访问同一个格子，可以用 $vis$ 数组标记。更简单的做法是，直接修改 $board[i][j]$，将其置为空（或者 $0$），返回 $false$ 前再恢复成原来的值（恢复现场）。注意返回 $true$ 的时候就不用恢复现场了，因为已经成功搜到 $word$ 了。

```Python
class Solution:
    def exist(self, board: List[List[str]], word: str) -> bool:
        m, n = len(board), len(board[0])
        def dfs(i: int, j: int, k: int) -> bool:
            if board[i][j] != word[k]:  # 匹配失败
                return False
            if k == len(word) - 1:  # 匹配成功！
                return True
            board[i][j] = ''  # 标记访问过
            for x, y in (i, j - 1), (i, j + 1), (i - 1, j), (i + 1, j):  # 相邻格子
                if 0 <= x < m and 0 <= y < n and dfs(x, y, k + 1):
                    return True  # 搜到了！
            board[i][j] = word[k]  # 恢复现场
            return False  # 没搜到
        return any(dfs(i, j, 0) for i in range(m) for j in range(n))
```

```Java
class Solution {
    private static final int[][] DIRS = {{0, -1}, {0, 1}, {-1, 0}, {1, 0}};

    public boolean exist(char[][] board, String word) {
        char[] w = word.toCharArray();
        for (int i = 0; i < board.length; i++) {
            for (int j = 0; j < board[i].length; j++) {
                if (dfs(i, j, 0, board, w)) {
                    return true; // 搜到了！
                }
            }
        }
        return false; // 没搜到
    }

    private boolean dfs(int i, int j, int k, char[][] board, char[] word) {
        if (board[i][j] != word[k]) { // 匹配失败
            return false;
        }
        if (k == word.length - 1) { // 匹配成功！
            return true;
        }
        board[i][j] = 0; // 标记访问过
        for (int[] d : DIRS) {
            int x = i + d[0];
            int y = j + d[1]; // 相邻格子
            if (0 <= x && x < board.length && 0 <= y && y < board[x].length && dfs(x, y, k + 1, board, word)) {
                return true; // 搜到了！
            }
        }
        board[i][j] = word[k]; // 恢复现场
        return false; // 没搜到
    }
}
```

```C++
class Solution {
    static constexpr int DIRS[4][2] = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};
public:
    bool exist(vector<vector<char>>& board, string word) {
        int m = board.size(), n = board[0].size();
        auto dfs = [&](this auto&& dfs, int i, int j, int k) -> bool {
            if (board[i][j] != word[k]) { // 匹配失败
                return false;
            }
            if (k + 1 == word.length()) { // 匹配成功！
                return true;
            }
            board[i][j] = 0; // 标记访问过
            for (auto& [dx, dy] : DIRS) {
                int x = i + dx, y = j + dy; // 相邻格子
                if (0 <= x && x < m && 0 <= y && y < n && dfs(x, y, k + 1)) { // 没超过边界，并且后续字母都成功匹配
                    return true;
                }
            }
            board[i][j] = word[k]; // 恢复现场
            return false; // 没搜到
        };
        // 每个格子都可以作为起点
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (dfs(i, j, 0)) {
                    return true; // 搜到了！
                }
            }
        }
        return false; // 没搜到
    }
};
```

```C
int DIRS[4][2] = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};

bool dfs(char** board, char* word, int m, int n, int i, int j, int k) {
    if (board[i][j] != word[k]) {
        return false; // 匹配失败
    }
    if (word[k + 1] == '\0') {
        return true; // 匹配成功！
    }
    board[i][j] = 0; // 标记访问过
    for (int d = 0; d < 4; d++) {
        int x = i + DIRS[d][0], y = j + DIRS[d][1]; // 相邻格子
        if (0 <= x && x < m && 0 <= y && y < n && dfs(board, word, m, n, x, y, k + 1)) {
            return true; // 搜到了！
        }
    }
    board[i][j] = word[k]; // 恢复现场
    return false; // 没搜到
}

bool exist(char** board, int boardSize, int* boardColSize, char* word) {
    int m = boardSize, n = boardColSize[0];
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (dfs(board, word, m, n, i, j, 0)) {
                return true; // 搜到了！
            }
        }
    }
    return false; // 没搜到
}
```

```Go
var dirs = []struct{ x, y int }{{0, -1}, {0, 1}, {-1, 0}, {1, 0}}

func exist(board [][]byte, word string) bool {
    m, n := len(board), len(board[0])
    var dfs func(int, int, int) bool
    dfs = func(i, j, k int) bool {
        if board[i][j] != word[k] { // 匹配失败
            return false
        }
        if k == len(word)-1 { // 匹配成功
            return true
        }
        board[i][j] = 0 // 标记访问过
        for _, d := range dirs {
            x, y := i+d.x, j+d.y // 相邻格子
            if 0 <= x && x < m && 0 <= y && y < n && dfs(x, y, k+1) {
                return true // 搜到了！
            }
        }
        board[i][j] = word[k] // 恢复现场
        return false // 没搜到
    }
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            if dfs(i, j, 0) {
                return true // 搜到了！
            }
        }
    }
    return false // 没搜到
}
```

```JavaScript
var exist = function(board, word) {
    const m = board.length, n = board[0].length;
    function dfs(i, j, k) {
        if (board[i][j] !== word[k]) {
            return false; // 匹配失败
        }
        if (k + 1 === word.length) {
            return true; // 匹配成功！
        }
        board[i][j] = 0; // 标记访问过
        for (const [x, y] of [[i, j - 1], [i, j + 1], [i - 1, j], [i + 1, j]]) { // 相邻格子
            if (0 <= x && x < m && 0 <= y && y < n && dfs(x, y, k + 1)) {
                return true; // 搜到了！
            }
        }
        board[i][j] = word[k]; // 恢复现场
        return false; // 没搜到
    }
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (dfs(i, j, 0)) {
                return true; // 搜到了！
            }
        }
    }
    return false; // 没搜到
};
```

```Rust
impl Solution {
    pub fn exist(mut board: Vec<Vec<char>>, word: String) -> bool {
        fn dfs(board: &mut Vec<Vec<char>>, word: &[u8], i: usize, j: usize, k: usize, m: usize, n: usize) -> bool {
            if board[i][j] != word[k] as char {
                return false; // 匹配失败
            }
            if k + 1 == word.len() {
                return true; // 匹配成功！
            }
            board[i][j] = '\0'; // 标记访问过
            for (x, y) in [(i, j - 1), (i, j + 1), (i - 1, j), (i + 1, j)] {
                if x < m && y < n && dfs(board, word, x, y, k + 1, m, n) {
                    return true; // 搜到了！
                }
            }
            board[i][j] = word[k] as char; // 恢复现场
            false // 没搜到
        }
        let m = board.len();
        let n = board[0].len();
        for i in 0..m {
            for j in 0..n {
                if dfs(&mut board, word.as_bytes(), i, j, 0, m, n) {
                    return true; // 搜到了！
                }
            }
        }
        false // 没搜到
    }
}
```

#### 第一个优化

![](./assets/img/Solution0079_oth.jpg)

比如示例 $3$，$word=ABCB$，其中字母 $B$ 出现了 $2$ 次，但 $board$ 中只有 $1$ 个字母 $B$，所以肯定搜不到 $word$，直接返回 $false$。

一般地，如果 $word$ 的某个字母的出现次数，比 $board$ 中的这个字母的出现次数还要多，可以直接返回 $false$。

#### 第二个优化

**启发**：如果 $word=abcd$ 但 $board$ 中的 $a$ 很多，$d$ 很少（比如只有一个），那么从 $d$ 开始搜索，能更快地找到答案。（即使我们肉眼去找，这种方法也是更快的）

设 $word$ 的第一个字母在 $board$ 中出现了 $x$ 次，$word$ 的最后一个字母在 $board$ 中出现了 $y$ 次。

如果 $y<x$，我们可以把 $word$ 反转，相当于从 $word$ 的最后一个字母开始搜索，这样更容易在一开始就满足 `board[i][j] != word[k]`，不会往下递归，递归的总次数更少。

加上这两个优化，就可以击败接近 $100%$ 了！其中 Java、C++、Go 和 $Rust$ 都可以跑到 $0ms$。

```Python
class Solution:
    def exist(self, board: List[List[str]], word: str) -> bool:
        cnt = Counter(c for row in board for c in row)
        if not cnt >= Counter(word):  # 优化一
            return False
        if cnt[word[-1]] < cnt[word[0]]:  # 优化二
            word = word[::-1]

        m, n = len(board), len(board[0])
        def dfs(i: int, j: int, k: int) -> bool:
            if board[i][j] != word[k]:  # 匹配失败
                return False
            if k == len(word) - 1:  # 匹配成功！
                return True
            board[i][j] = ''  # 标记访问过
            for x, y in (i, j - 1), (i, j + 1), (i - 1, j), (i + 1, j):  # 相邻格子
                if 0 <= x < m and 0 <= y < n and dfs(x, y, k + 1):
                    return True  # 搜到了！
            board[i][j] = word[k]  # 恢复现场
            return False  # 没搜到
        return any(dfs(i, j, 0) for i in range(m) for j in range(n))
```

```Java
class Solution {
    private static final int[][] DIRS = {{0, -1}, {0, 1}, {-1, 0}, {1, 0}};

    public boolean exist(char[][] board, String word) {
        // 为了方便，直接用数组代替哈希表
        int[] cnt = new int[128];
        for (char[] row : board) {
            for (char c : row) {
                cnt[c]++;
            }
        }

        // 优化一
        char[] w = word.toCharArray();
        int[] wordCnt = new int[128];
        for (char c : w) {
            if (++wordCnt[c] > cnt[c]) {
                return false;
            }
        }

        // 优化二
        if (cnt[w[w.length - 1]] < cnt[w[0]]) {
            w = new StringBuilder(word).reverse().toString().toCharArray();
        }

        for (int i = 0; i < board.length; i++) {
            for (int j = 0; j < board[i].length; j++) {
                if (dfs(i, j, 0, board, w)) {
                    return true; // 搜到了！
                }
            }
        }
        return false; // 没搜到
    }

    private boolean dfs(int i, int j, int k, char[][] board, char[] word) {
        if (board[i][j] != word[k]) { // 匹配失败
            return false;
        }
        if (k == word.length - 1) { // 匹配成功！
            return true;
        }
        board[i][j] = 0; // 标记访问过
        for (int[] d : DIRS) {
            int x = i + d[0];
            int y = j + d[1]; // 相邻格子
            if (0 <= x && x < board.length && 0 <= y && y < board[x].length && dfs(x, y, k + 1, board, word)) {
                return true; // 搜到了！
            }
        }
        board[i][j] = word[k]; // 恢复现场
        return false; // 没搜到
    }
}
```

```C++
class Solution {
    static constexpr int DIRS[4][2] = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};
public:
    bool exist(vector<vector<char>>& board, string word) {
        unordered_map<char, int> cnt;
        for (auto& row : board) {
            for (char c : row) {
                cnt[c]++;
            }
        }

        // 优化一
        unordered_map<char, int> word_cnt;
        for (char c : word) {
            if (++word_cnt[c] > cnt[c]) {
                return false;
            }
        }

        // 优化二
        if (cnt[word.back()] < cnt[word[0]]) {
            ranges::reverse(word);
        }

        int m = board.size(), n = board[0].size();
        auto dfs = [&](this auto&& dfs, int i, int j, int k) -> bool {
            if (board[i][j] != word[k]) { // 匹配失败
                return false;
            }
            if (k + 1 == word.length()) { // 匹配成功！
                return true;
            }
            board[i][j] = 0; // 标记访问过
            for (auto& [dx, dy] : DIRS) {
                int x = i + dx, y = j + dy; // 相邻格子
                if (0 <= x && x < m && 0 <= y && y < n && dfs(x, y, k + 1)) {
                    return true; // 搜到了！
                }
            }
            board[i][j] = word[k]; // 恢复现场
            return false; // 没搜到
        };
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (dfs(i, j, 0)) {
                    return true; // 搜到了！
                }
            }
        }
        return false; // 没搜到
    }
};
```

```C
int DIRS[4][2] = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};

bool dfs(char** board, char* word, int m, int n, int i, int j, int k) {
    if (board[i][j] != word[k]) {
        return false; // 匹配失败
    }
    if (word[k + 1] == '\0') {
        return true; // 匹配成功！
    }
    board[i][j] = 0; // 标记访问过
    for (int d = 0; d < 4; d++) {
        int x = i + DIRS[d][0], y = j + DIRS[d][1]; // 相邻格子
        if (0 <= x && x < m && 0 <= y && y < n && dfs(board, word, m, n, x, y, k + 1)) {
            return true; // 搜到了！
        }
    }
    board[i][j] = word[k]; // 恢复现场
    return false; // 没搜到
}

bool exist(char** board, int boardSize, int* boardColSize, char* word) {
    int m = boardSize, n = boardColSize[0];
    // 为了方便，用数组代替哈希表
    int cnt[128] = {};
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            cnt[board[i][j]]++;
        }
    }

    // 优化一
    int word_cnt[128] = {};
    int k = 0;
    for (; word[k]; k++) {
        if (++word_cnt[word[k]] > cnt[word[k]]) {
            return false;
        }
    }

    // 优化二
    if (cnt[word[k - 1]] < cnt[word[0]]) {
        // 反转 word
        for (int i = 0; i < k / 2; i++) {
            char tmp = word[i];
            word[i] = word[k - i - 1];
            word[k - i - 1] = tmp;
        }
    }

    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (dfs(board, word, m, n, i, j, 0)) {
                return true; // 搜到了！
            }
        }
    }
    return false; // 没搜到
}
```

```Go
var dirs = []struct{ x, y int }{{0, -1}, {0, 1}, {-1, 0}, {1, 0}}

func exist(board [][]byte, word string) bool {
    cnt := map[byte]int{}
    for _, row := range board {
        for _, c := range row {
            cnt[c]++
        }
    }

    // 优化一
    w := []byte(word)
    wordCnt := map[byte]int{}
    for _, c := range w {
        wordCnt[c]++
        if wordCnt[c] > cnt[c] {
            return false
        }
    }

    // 优化二
    if cnt[w[len(w)-1]] < cnt[w[0]] {
        slices.Reverse(w)
    }

    m, n := len(board), len(board[0])
    var dfs func(int, int, int) bool
    dfs = func(i, j, k int) bool {
        if board[i][j] != w[k] { // 匹配失败
            return false
        }
        if k == len(w)-1 { // 匹配成功
            return true
        }
        board[i][j] = 0 // 标记访问过
        for _, d := range dirs {
            x, y := i+d.x, j+d.y // 相邻格子
            if 0 <= x && x < m && 0 <= y && y < n && dfs(x, y, k+1) {
                return true // 搜到了！
            }
        }
        board[i][j] = w[k] // 恢复现场
        return false // 没搜到
    }
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            if dfs(i, j, 0) {
                return true // 搜到了！
            }
        }
    }
    return false // 没搜到
}
```

```JavaScript
var exist = function(board, word) {
    const cnt = new Map();
    for (const row of board) {
        for (const c of row) {
            cnt.set(c, (cnt.get(c) ?? 0) + 1);
        }
    }

    // 优化一
    const wordCnt = new Map();
    for (const c of word) {
        wordCnt.set(c, (wordCnt.get(c) ?? 0) + 1);
        if (wordCnt.get(c) > (cnt.get(c) ?? 0)) {
            return false;
        }
    }

    // 优化二
    if ((cnt.get(word[word.length - 1]) ?? 0) < (cnt.get(word[0]) ?? 0)) {
        word = word.split('').reverse();
    }

    const m = board.length, n = board[0].length;
    function dfs(i, j, k) {
        if (board[i][j] !== word[k]) {
            return false; // 匹配失败
        }
        if (k + 1 === word.length) {
            return true; // 匹配成功！
        }
        board[i][j] = 0; // 标记访问过
        for (const [x, y] of [[i, j - 1], [i, j + 1], [i - 1, j], [i + 1, j]]) { // 相邻格子
            if (0 <= x && x < m && 0 <= y && y < n && dfs(x, y, k + 1)) {
                return true; // 搜到了！
            }
        }
        board[i][j] = word[k]; // 恢复现场
        return false; // 没搜到
    }
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (dfs(i, j, 0)) {
                return true; // 搜到了！
            }
        }
    }
    return false; // 没搜到
};
```

```Rust
impl Solution {
    pub fn exist(mut board: Vec<Vec<char>>, mut word: String) -> bool {
        // 为了方便，直接用数组代替哈希表
        let mut cnt = [0; 128];
        for row in &board {
            for &c in row {
                cnt[c as usize] += 1;
            }
        }

        // 优化一
        let w = word.as_bytes();
        let mut word_cnt = [0; 128];
        for &c in w {
            let c = c as usize;
            word_cnt[c] += 1;
            if word_cnt[c] > cnt[c] {
                return false;
            }
        }

        // 优化二
        if cnt[w[w.len() - 1] as usize] < cnt[w[0] as usize] {
            word = word.chars().rev().collect();
        }

        fn dfs(board: &mut Vec<Vec<char>>, word: &[u8], i: usize, j: usize, k: usize, m: usize, n: usize) -> bool {
            if board[i][j] != word[k] as char {
                return false; // 匹配失败
            }
            if k + 1 == word.len() {
                return true; // 匹配成功！
            }
            board[i][j] = '\0'; // 标记访问过
            for (x, y) in [(i, j - 1), (i, j + 1), (i - 1, j), (i + 1, j)] { // 相邻格子
                if x < m && y < n && dfs(board, word, x, y, k + 1, m, n) {
                    return true; // 搜到了！
                }
            }
            board[i][j] = word[k] as char; // 恢复现场
            false // 没搜到
        }
        let m = board.len();
        let n = board[0].len();
        for i in 0..m {
            for j in 0..n {
                if dfs(&mut board, word.as_bytes(), i, j, 0, m, n) {
                    return true; // 搜到了！
                }
            }
        }
        false // 没搜到
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(mn3^k)$，其中 $m$ 和 $n$ 分别为 $grid$ 的行数和列数，$k$ 是 $word$ 的长度。除了递归入口，其余递归至多有 $3$ 个分支（因为至少有一个方向是之前走过的），所以每次递归（回溯）的时间复杂度为 $O(3^k)$，一共回溯 $O(mn)$ 次，所以时间复杂度为 $O(mn3^k)$。
- 空间复杂度：$O(\vert \sum \vert +k)$。其中 $\vert \sum \vert =52$ 是字符集合的大小。递归需要 $O(k)$ 的栈空间。部分语言用的数组代替哈希表，可以视作 $\vert \sum \vert =128$。

#### 分类题单

[如何科学刷题？](https://leetcode.cn/circle/discuss/RvFUtj/)

1. [滑动窗口与双指针（定长/不定长/单序列/双序列/三指针/分组循环）](https://leetcode.cn/circle/discuss/0viNMK/)
2. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
3. [单调栈（基础/矩形面积/贡献法/最小字典序）](https://leetcode.cn/circle/discuss/9oZFK9/)
4. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
5. [位运算（基础/性质/拆位/试填/恒等式/思维）](https://leetcode.cn/circle/discuss/dHn9Vk/)
6. [图论算法（DFS/BFS/拓扑排序/最短路/最小生成树/二分图/基环树/欧拉路径）](https://leetcode.cn/circle/discuss/01LUak/)
7. [动态规划（入门/背包/状态机/划分/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
8. [常用数据结构（前缀和/差分/栈/队列/堆/字典树/并查集/树状数组/线段树）](https://leetcode.cn/circle/discuss/mOr1u6/)
9. [数学算法（数论/组合/概率期望/博弈/计算几何/随机算法）](https://leetcode.cn/circle/discuss/IYT3ss/)
10. [贪心与思维（基本贪心策略/反悔/区间/字典序/数学/思维/脑筋急转弯/构造）](https://leetcode.cn/circle/discuss/g6KTKL/)
11. [链表、二叉树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA/一般树）](https://leetcode.cn/circle/discuss/K0n2gO/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/circle/discuss/SJFwQI/)
