### [金字塔转换矩阵](https://leetcode.cn/problems/pyramid-transition-matrix/solutions/3860856/jin-zi-ta-zhuan-huan-ju-zhen-by-leetcode-wx68/)

#### 方法一：状态转换

**算法：**

我们模拟方块可以处于的状态。每个状态都是一个二进制数，如果第 `k` 类型的方块是可能的，则设置第 `k` 位。然后，我们创建一个转换映射 `T[state1][state2] -> state`。它接受左状态和右状态并输出所有可能的父状态。

最后，应用这些转换非常简单。但是，这种方法不正确，因为转换不是独立的。例如，如果我们在一行 `A, {B or C}, A`，并且 `allowed` 中的元组是 `(A, B, D), (C, A, D)`。那么无论选择 `{B or C}`，我们都不能创建金字塔的下一行。

```Python
class Solution(object):
    def pyramidTransition(self, bottom, allowed):
        T = [[0] * (1 << 7) for _ in xrange(1 << 7)]
        for triple in allowed:
            u, v, w = (1 << (ord(x) - ord('A')) for x in triple)
            for b1 in xrange(1 << 7):
                if u & b1:
                    for b2 in xrange(1 << 7):
                        if v & b2:
                            T[b1][b2] |= w

        state = [1 << (ord(x) - ord('A')) for x in bottom]
        while len(state) > 1:
            for i in xrange(len(state) - 1):
                state[i] = T[state[i]][state[i+1]]
            state.pop()
        return bool(state[0])
```

```Java
class Solution {
    public boolean pyramidTransition(String bottom, List<String> allowed) {
        int[][] T = new int[1 << 7][1 << 7];
        for (String triple: allowed) {
            int u = 1 << (triple.charAt(0) - 'A');
            int v = 1 << (triple.charAt(1) - 'A');
            int w = 1 << (triple.charAt(2) - 'A');
            for (int b1 = 0; b1 < (1 << 7); ++b1) if ((u & b1) > 0) {
                for (int b2 = 0; b2 < (1 << 7); ++b2) {
                    if ((v & b2) > 0) {
                        T[b1][b2] |= w;
                    }
                }
            }
        }

        int[] state = new int[bottom.length()];
        int t = 0;
        for (char c: bottom.toCharArray()) {
            state[t++] = 1 << (c - 'A');
        }
        while (t-- > 1) {
            for (int i = 0; i < t; ++i) {
                state[i] = T[state[i]][state[i+1]];
            }
        }
        return state[0] > 0;
    }
}
```

```C++
class Solution {
public:
    bool pyramidTransition(string bottom, vector<string>& allowed) {
        int T[1 << 7][1 << 7] = {{0}};
        for (const string& triple : allowed) {
            int u = 1 << (triple[0] - 'A');
            int v = 1 << (triple[1] - 'A');
            int w = 1 << (triple[2] - 'A');
            for (int b1 = 0; b1 < (1 << 7); ++b1) {
                if (u & b1) {
                    for (int b2 = 0; b2 < (1 << 7); ++b2) {
                        if (v & b2) {
                            T[b1][b2] |= w;
                        }
                    }
                }
            }
        }

        vector<int> state(bottom.size());
        int t = 0;
        for (char c : bottom) {
            state[t++] = 1 << (c - 'A');
        }
        while (t-- > 1) {
            for (int i = 0; i < t; ++i) {
                state[i] = T[state[i]][state[i + 1]];
            }
        }

        return state[0] > 0;
    }
};
```

```CSharp
public class Solution {
    public bool PyramidTransition(string bottom, IList<string> allowed) {
        int[,] T = new int[1 << 7, 1 << 7];

        foreach (string triple in allowed) {
            int u = 1 << (triple[0] - 'A');
            int v = 1 << (triple[1] - 'A');
            int w = 1 << (triple[2] - 'A');

            for (int b1 = 0; b1 < (1 << 7); b1++) {
                if ((u & b1) != 0) {
                    for (int b2 = 0; b2 < (1 << 7); b2++) {
                        if ((v & b2) != 0) {
                            T[b1, b2] |= w;
                        }
                    }
                }
            }
        }

        int[] state = new int[bottom.Length];
        int t = 0;
        foreach (char c in bottom) {
            state[t++] = 1 << (c - 'A');
        }

        while (t-- > 1) {
            for (int i = 0; i < t; i++) {
                state[i] = T[state[i], state[i + 1]];
            }
        }

        return state[0] > 0;
    }
}
```

```Go
func pyramidTransition(bottom string, allowed []string) bool {
    T := make([][]int, 1<<7)
    for i := range T {
        T[i] = make([]int, 1<<7)
    }

    for _, triple := range allowed {
        u := 1 << (triple[0] - 'A')
        v := 1 << (triple[1] - 'A')
        w := 1 << (triple[2] - 'A')

        for b1 := 0; b1 < (1 << 7); b1++ {
            if u & b1 != 0 {
                for b2 := 0; b2 < (1 << 7); b2++ {
                    if v & b2 != 0 {
                        T[b1][b2] |= w
                    }
                }
            }
        }
    }

    state := make([]int, len(bottom))
    t := 0
    for _, c := range bottom {
        state[t] = 1 << (c - 'A')
        t++
    }
    t = len(state)
    for t > 1 {
        for i := 0; i < t-1; i++ {
            state[i] = T[state[i]][state[i + 1]]
        }
        t--
    }

    return state[0] > 0
}
```

```C
bool pyramidTransition(char* bottom, char** allowed, int allowedSize) {
    int T[1 << 7][1 << 7];
    memset(T, 0, sizeof(T));
    for (int i = 0; i < allowedSize; i++) {
        char* triple = allowed[i];
        int u = 1 << (triple[0] - 'A');
        int v = 1 << (triple[1] - 'A');
        int w = 1 << (triple[2] - 'A');

        for (int b1 = 0; b1 < (1 << 7); b1++) {
            if (u & b1) {
                for (int b2 = 0; b2 < (1 << 7); b2++) {
                    if (v & b2) {
                        T[b1][b2] |= w;
                    }
                }
            }
        }
    }

    int len = strlen(bottom);
    int* state = (int*)malloc(len * sizeof(int));
    int t = 0;
    for (int i = 0; i < len; i++) {
        state[t++] = 1 << (bottom[i] - 'A');
    }

    while (t-- > 1) {
        for (int i = 0; i < t; i++) {
            state[i] = T[state[i]][state[i + 1]];
        }
    }

    bool result = state[0] > 0;
    free(state);
    return result;
}
```

```JavaScript
var pyramidTransition = function(bottom, allowed) {
    const T = Array.from({length: 1 << 7}, () => new Array(1 << 7).fill(0));
    for (const triple of allowed) {
        const u = 1 << (triple.charCodeAt(0) - 'A'.charCodeAt(0));
        const v = 1 << (triple.charCodeAt(1) - 'A'.charCodeAt(0));
        const w = 1 << (triple.charCodeAt(2) - 'A'.charCodeAt(0));

        for (let b1 = 0; b1 < (1 << 7); b1++) {
            if (u & b1) {
                for (let b2 = 0; b2 < (1 << 7); b2++) {
                    if (v & b2) {
                        T[b1][b2] |= w;
                    }
                }
            }
        }
    }

    let state = [];
    for (const c of bottom) {
        state.push(1 << (c.charCodeAt(0) - 'A'.charCodeAt(0)));
    }
    let t = state.length;

    while (t-- > 1) {
        for (let i = 0; i < t; i++) {
            state[i] = T[state[i]][state[i + 1]];
        }
    }

    return state[0] > 0;
};
```

```TypeScript
function pyramidTransition(bottom: string, allowed: string[]): boolean {
    const T: number[][] = Array.from({length: 1 << 7}, () => new Array(1 << 7).fill(0));

    for (const triple of allowed) {
        const u = 1 << (triple.charCodeAt(0) - 'A'.charCodeAt(0));
        const v = 1 << (triple.charCodeAt(1) - 'A'.charCodeAt(0));
        const w = 1 << (triple.charCodeAt(2) - 'A'.charCodeAt(0));

        for (let b1 = 0; b1 < (1 << 7); b1++) {
            if (u & b1) {
                for (let b2 = 0; b2 < (1 << 7); b2++) {
                    if (v & b2) {
                        T[b1][b2] |= w;
                    }
                }
            }
        }
    }

    let state: number[] = [];
    for (const c of bottom) {
        state.push(1 << (c.charCodeAt(0) - 'A'.charCodeAt(0)));
    }
    let t = state.length;

    while (t-- > 1) {
        for (let i = 0; i < t; i++) {
            state[i] = T[state[i]][state[i + 1]];
        }
    }

    return state[0] > 0;
}
```

```Rust
impl Solution {
    pub fn pyramid_transition(bottom: String, allowed: Vec<String>) -> bool {
        let mut T = vec![vec![0; 1 << 7]; 1 << 7];

        for triple in allowed {
            let chars: Vec<char> = triple.chars().collect();
            let u = 1 << (chars[0] as usize - 'A' as usize);
            let v = 1 << (chars[1] as usize - 'A' as usize);
            let w = 1 << (chars[2] as usize - 'A' as usize);

            for b1 in 0..(1 << 7) {
                if u & b1 != 0 {
                    for b2 in 0..(1 << 7) {
                        if v & b2 != 0 {
                            T[b1][b2] |= w;
                        }
                    }
                }
            }
        }

        let mut state: Vec<usize> = bottom.chars()
            .map(|c| 1 << (c as usize - 'A' as usize))
            .collect();
        let mut t = state.len();

        while t > 1 {
            for i in 0..t-1 {
                state[i] = T[state[i]][state[i + 1]];
            }
            t -= 1;
        }

        state[0] > 0
    }
}
```

**复杂度分析**

- 时间复杂度：$O(2^{2A}A+N^2)$。其中 $N$ 指的是 `bottom` 的长度，$A$ 指的是 `allowed` 的长度，且 $A$ 指的是字母的大小。
- 空间复杂度：$O(2^{2A})$。

#### 方法二：深度优先搜索

我们详尽的尝试每个方块的组合。

**算法：**

我们需要从三元组列表中创建一个转换映射 `T`。这个映射 `T[x][y] = {set of z}` 将是左孩子 `x` 和右孩子 `y` 所有可能的父块。

然后，为了求解下一行，我们生成下一行所有的可能组合并求解它们。如果这些组合中有任一一行是可解的，则返回 `True`，反之返回 `False`。

```Python
class Solution:
    def pyramidTransition(self, bottom: str, allowed: List[str]) -> bool:
        # 构建转换表，T[i][j] 表示底部为i和j时，顶部可能的字符位掩码
        T = [[0] * 7 for _ in range(7)]
        for a in allowed:
            left = ord(a[0]) - ord('A')
            right = ord(a[1]) - ord('A')
            top = ord(a[2]) - ord('A')
            T[left][right] |= 1 << top

        seen = set()
        N = len(bottom)
        # 金字塔状态数组
        A = [[0] * N for _ in range(N)]
        # 初始化底部行
        for i, c in enumerate(bottom):
            A[N - 1][i] = ord(c) - ord('A')

        def solve(R: int, N: int, i: int) -> bool:
            """
            递归解决金字塔构建问题
            :param R: 当前行的状态编码（用于记忆化）
            :param N: 当前处理的行号
            :param i: 当前行中的位置索引
            :return: 是否可以成功构建金字塔
            """
            # 基本情况：成功构建到金字塔顶部
            if N == 1 and i == 1:
                return True
            # 当前行处理完成，准备处理下一行
            elif i == N:
                # 记忆化检查：如果已经处理过相同的行状态，直接返回失败
                if R in seen:
                    return False
                # 记录当前行状态
                seen.add(R)
                # 递归处理下一行
                return solve(0, N - 1, 0)
            # 处理当前行的当前位置
            else:
                # 获取当前两个底部块对应的可能顶部块位掩码
                w = T[A[N][i]][A[N][i + 1]]
                # 遍历所有可能的顶部块
                for b in range(7):
                    if (w >> b) & 1:
                        # 设置顶部块
                        A[N-1][i] = b
                        # 递归处理下一个位置，更新状态编码
                        # 使用base-8编码来记录当前行的状态
                        if solve(R * 8 + (b + 1), N, i + 1):
                            return True
                return False

        return solve(0, N - 1, 0)
```

```Java
class Solution {
    int[][] T;
    Set<Long> seen;

    public boolean pyramidTransition(String bottom, List<String> allowed) {
        T = new int[7][7];
        // 构建转换表，T[i][j] 表示底部为i和j时，顶部可能的字符位掩码
        for (String a : allowed) {
            int left = a.charAt(0) - 'A';
            int right = a.charAt(1) - 'A';
            int top = a.charAt(2) - 'A';
            T[left][right] |= 1 << top;
        }

        seen = new HashSet<>();
        int N = bottom.length();
        int[][] A = new int[N][N];  // 金字塔状态数组
        int t = 0;
        // 初始化底部行
        for (char c : bottom.toCharArray()) {
            A[N - 1][t++] = c - 'A';
        }
        return solve(A, 0, N - 1, 0);
    }

    /**
     * 递归解决金字塔构建问题
     * @param A 金字塔状态数组
     * @param R 当前行的状态编码（用于记忆化）
     * @param N 当前处理的行号
     * @param i 当前行中的位置索引
     * @return 是否可以成功构建金字塔
     */
    public boolean solve(int[][] A, long R, int N, int i) {
        // 基本情况：成功构建到金字塔顶部
        if (N == 1 && i == 1) {
            return true;
        } else if (i == N) { // 当前行处理完成，准备处理下一行
            // 记忆化检查：如果已经处理过相同的行状态，直接返回失败
            if (seen.contains(R)) {
                return false;
            }
            // 记录当前行状态
            seen.add(R);
            // 递归处理下一行
            return solve(A, 0, N - 1, 0);
        } else { // 处理当前行的当前位置
            // 获取当前两个底部块对应的可能顶部块位掩码
            int w = T[A[N][i]][A[N][i + 1]];
            // 遍历所有可能的顶部块
            for (int b = 0; b < 7; ++b) {
                if (((w >> b) & 1) != 0) {
                    // 设置顶部块
                    A[N - 1][i] = b;
                    // 递归处理下一个位置，更新状态编码
                    // 使用base-8编码来记录当前行的状态
                    if (solve(A, R * 8 + (b + 1), N, i + 1)) {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
```

```C++
class Solution {
public:
    vector<vector<int>> T;
    unordered_set<long> seen;
    vector<vector<int>> A;

    bool pyramidTransition(string bottom, vector<string>& allowed) {
        // 构建转换表，T[i][j] 表示底部为i和j时，顶部可能的字符位掩码
        T = vector<vector<int>>(7, vector<int>(7, 0));
        for (const string& a : allowed) {
            int left = a[0] - 'A';
            int right = a[1] - 'A';
            int top = a[2] - 'A';
            T[left][right] |= 1 << top;
        }

        seen.clear();
        int N = bottom.size();
        // 金字塔状态数组
        A = vector<vector<int>>(N, vector<int>(N, 0));
        // 初始化底部行
        for (int i = 0; i < N; i++) {
            A[N-1][i] = bottom[i] - 'A';
        }
        return solve(0, N-1, 0);
    }

    /**
     * 递归解决金字塔构建问题
     * @param R 当前行的状态编码（用于记忆化）
     * @param N 当前处理的行号
     * @param i 当前行中的位置索引
     * @return 是否可以成功构建金字塔
     */
    bool solve(long R, int N, int i) {
        // 基本情况：成功构建到金字塔顶部
        if (N == 1 && i == 1) {
            return true;
        } else if (i == N) { // 当前行处理完成，准备处理下一行
            // 记忆化检查：如果已经处理过相同的行状态，直接返回失败
            if (seen.find(R) != seen.end()) {
                return false;
            }
            // 记录当前行状态
            seen.insert(R);
            // 递归处理下一行
            return solve(0, N-1, 0);
        } else { // 处理当前行的当前位置
            // 获取当前两个底部块对应的可能顶部块位掩码
            int w = T[A[N][i]][A[N][i+1]];
            // 遍历所有可能的顶部块
            for (int b = 0; b < 7; ++b) {
                if ((w >> b) & 1) {
                    // 设置顶部块
                    A[N-1][i] = b;
                    // 递归处理下一个位置，更新状态编码
                    // 使用base-8编码来记录当前行的状态
                    if (solve(R * 8 + (b + 1), N, i + 1)) {
                        return true;
                    }
                }
            }
            return false;
        }
    }
};
```

```CSharp
public class Solution {
    private int[,] T;
    private HashSet<long> seen;
    private int[][] A;

    public bool PyramidTransition(string bottom, IList<string> allowed) {
        // 构建转换表，T[i][j] 表示底部为i和j时，顶部可能的字符位掩码
        T = new int[7, 7];
        foreach (string a in allowed) {
            int left = a[0] - 'A';
            int right = a[1] - 'A';
            int top = a[2] - 'A';
            T[left, right] |= 1 << top;
        }

        seen = new HashSet<long>();
        int N = bottom.Length;
        // 金字塔状态数组
        A = new int[N][];
        for (int i = 0; i < N; i++) {
            A[i] = new int[N];
        }
        // 初始化底部行
        for (int i = 0; i < N; i++) {
            A[N - 1][i] = bottom[i] - 'A';
        }
        return Solve(0, N-1, 0);
    }

    /**
     * 递归解决金字塔构建问题
     * @param R 当前行的状态编码（用于记忆化）
     * @param N 当前处理的行号
     * @param i 当前行中的位置索引
     * @return 是否可以成功构建金字塔
     */
    private bool Solve(long R, int N, int i) {
        // 基本情况：成功构建到金字塔顶部
        if (N == 1 && i == 1) {
            return true;
        } else if (i == N) { // 当前行处理完成，准备处理下一行
            // 记忆化检查：如果已经处理过相同的行状态，直接返回失败
            if (seen.Contains(R)) {
                return false;
            }
            // 记录当前行状态
            seen.Add(R);
            // 递归处理下一行
            return Solve(0, N-1, 0);
        } else { // 处理当前行的当前位置
            // 获取当前两个底部块对应的可能顶部块位掩码
            int w = T[A[N][i], A[N][i+1]];
            // 遍历所有可能的顶部块
            for (int b = 0; b < 7; ++b) {
                if (((w >> b) & 1) != 0) {
                    // 设置顶部块
                    A[N-1][i] = b;
                    // 递归处理下一个位置，更新状态编码
                    // 使用base-8编码来记录当前行的状态
                    if (Solve(R * 8 + (b + 1), N, i + 1)) {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
```

```Go
func pyramidTransition(bottom string, allowed []string) bool {
    // 构建转换表，T[i][j] 表示底部为i和j时，顶部可能的字符位掩码
    T := [7][7]int{}
    for _, a := range allowed {
        left := int(a[0] - 'A')
        right := int(a[1] - 'A')
        top := int(a[2] - 'A')
        T[left][right] |= 1 << top
    }

    seen := make(map[uint64]bool)
    n := len(bottom)
    // 金字塔状态数组
    A := make([][]int, n)
    for i := range A {
        A[i] = make([]int, n)
    }
    // 初始化底部行
    for i := 0; i < n; i++ {
        A[n - 1][i] = int(bottom[i] - 'A')
    }

    var solve func(uint64, int, int) bool
    solve = func(R uint64, N int, i int) bool {
        // 基本情况：成功构建到金字塔顶部
        if N == 1 && i == 1 {
            return true
        } else if i == N { // 当前行处理完成，准备处理下一行
            // 记忆化检查：如果已经处理过相同的行状态，直接返回失败
            if seen[R] {
                return false
            }
            // 记录当前行状态
            seen[R] = true
            // 递归处理下一行
            return solve(0, N - 1, 0)
        } else { // 处理当前行的当前位置
            // 获取当前两个底部块对应的可能顶部块位掩码
            w := T[A[N][i]][A[N][i + 1]]
            // 遍历所有可能的顶部块
            for b := 0; b < 7; b++ {
                if (w >> b) & 1 != 0 {
                    // 设置顶部块
                    A[N-1][i] = b
                    // 递归处理下一个位置，更新状态编码
                    // 使用base-8编码来记录当前行的状态
                    if solve(R * 8 + uint64(b + 1), N, i + 1) {
                        return true
                    }
                }
            }
            return false
        }
    }

    return solve(0, n - 1, 0)
}
```

```C
typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem;

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr);
    }
}

bool solve(int T[7][7], int** A, HashItem* seen, unsigned long long R, int N, int i);

bool pyramidTransition(char* bottom, char** allowed, int allowedSize) {
    // 构建转换表，T[i][j] 表示底部为i和j时，顶部可能的字符位掩码
    int T[7][7] = {0};

    for (int k = 0; k < allowedSize; k++) {
        char* a = allowed[k];
        int left = a[0] - 'A';
        int right = a[1] - 'A';
        int top = a[2] - 'A';
        T[left][right] |= 1 << top;
    }

    HashItem *seen = NULL;
    int n = strlen(bottom);

    int** A = (int**)malloc(n * sizeof(int*));
    for (int i = 0; i < n; i++) {
        A[i] = (int*)malloc(n * sizeof(int));
        memset(A[i], 0, n * sizeof(int));
    }
    for (int i = 0; i < n; i++) {
        A[n - 1][i] = bottom[i] - 'A';
    }
    bool result = solve(T, A, seen, 0, n-1, 0);
    for (int i = 0; i < n; i++) {
        free(A[i]);
    }
    free(A);
    hashFree(&seen);

    return result;
}

bool solve(int T[7][7], int** A, HashItem* seen, unsigned long long R, int N, int i) {
    // 基本情况：成功构建到金字塔顶部
    if (N == 1 && i == 1) {
        return true;
    } else if (i == N) { // 当前行处理完成，准备处理下一行
        // 记忆化检查：如果已经处理过相同的行状态，直接返回失败
        if (hashFindItem(&seen, R)) {
            return false;
        }
        // 记录当前行状态
        hashAddItem(&seen, R);
        // 递归处理下一行
        return solve(T, A, seen, 0, N - 1, 0);
    } else { // 处理当前行的当前位置
        // 获取当前两个底部块对应的可能顶部块位掩码
        int w = T[A[N][i]][A[N][i + 1]];
        // 遍历所有可能的顶部块
        for (int b = 0; b < 7; b++) {
            if ((w >> b) & 1) {
                // 设置顶部块
                A[N - 1][i] = b;
                // 递归处理下一个位置，更新状态编码
                // 使用base-8编码来记录当前行的状态
                if (solve(T, A, seen, R * 8 + (b + 1), N, i + 1)) {
                    return true;
                }
            }
        }

        return false;
    }
}
```

```JavaScript
var pyramidTransition = function(bottom, allowed) {
    // 构建转换表，T[i][j] 表示底部为i和j时，顶部可能的字符位掩码
    const T = Array.from({length: 7}, () => new Array(7).fill(0));
    for (const a of allowed) {
        const left = a.charCodeAt(0) - 'A'.charCodeAt(0);
        const right = a.charCodeAt(1) - 'A'.charCodeAt(0);
        const top = a.charCodeAt(2) - 'A'.charCodeAt(0);
        T[left][right] |= 1 << top;
    }

    const seen = new Set();
    const N = bottom.length;
    // 金字塔状态数组
    const A = Array.from({length: N}, () => new Array(N).fill(0));
    // 初始化底部行
    for (let i = 0; i < N; i++) {
        A[N-1][i] = bottom.charCodeAt(i) - 'A'.charCodeAt(0);
    }

    /**
     * 递归解决金字塔构建问题
     * @param {number} R 当前行的状态编码（用于记忆化）
     * @param {number} N 当前处理的行号
     * @param {number} i 当前行中的位置索引
     * @return {boolean} 是否可以成功构建金字塔
     */
    const solve = (R, N, i) => {
        // 基本情况：成功构建到金字塔顶部
        if (N === 1 && i === 1) {
            return true;
        } else if (i === N) { // 当前行处理完成，准备处理下一行
            // 记忆化检查：如果已经处理过相同的行状态，直接返回失败
            if (seen.has(R)) {
                return false;
            }
            // 记录当前行状态
            seen.add(R);
            // 递归处理下一行
            return solve(0, N-1, 0);
        } else { // 处理当前行的当前位置
            // 获取当前两个底部块对应的可能顶部块位掩码
            const w = T[A[N][i]][A[N][i+1]];
            // 遍历所有可能的顶部块
            for (let b = 0; b < 7; b++) {
                if ((w >> b) & 1) {
                    // 设置顶部块
                    A[N-1][i] = b;
                    // 递归处理下一个位置，更新状态编码
                    // 使用base-8编码来记录当前行的状态
                    if (solve(R * 8 + (b + 1), N, i + 1)) {
                        return true;
                    }
                }
            }
            return false;
        }
    };

    return solve(0, N-1, 0);
};
```

```TypeScript
function pyramidTransition(bottom: string, allowed: string[]): boolean {
    // 构建转换表，T[i][j] 表示底部为i和j时，顶部可能的字符位掩码
    const T: number[][] = Array.from({length: 7}, () => new Array(7).fill(0));
    for (const a of allowed) {
        const left = a.charCodeAt(0) - 'A'.charCodeAt(0);
        const right = a.charCodeAt(1) - 'A'.charCodeAt(0);
        const top = a.charCodeAt(2) - 'A'.charCodeAt(0);
        T[left][right] |= 1 << top;
    }

    const seen = new Set<number>();
    const N = bottom.length;
    // 金字塔状态数组
    const A: number[][] = Array.from({length: N}, () => new Array(N).fill(0));
    // 初始化底部行
    for (let i = 0; i < N; i++) {
        A[N-1][i] = bottom.charCodeAt(i) - 'A'.charCodeAt(0);
    }

    /**
     * 递归解决金字塔构建问题
     * @param R 当前行的状态编码（用于记忆化）
     * @param N 当前处理的行号
     * @param i 当前行中的位置索引
     * @return 是否可以成功构建金字塔
     */
    const solve = (R: number, N: number, i: number): boolean => {
        // 基本情况：成功构建到金字塔顶部
        if (N === 1 && i === 1) {
            return true;
        } else if (i === N) { // 当前行处理完成，准备处理下一行
            // 记忆化检查：如果已经处理过相同的行状态，直接返回失败
            if (seen.has(R)) {
                return false;
            }
            // 记录当前行状态
            seen.add(R);
            // 递归处理下一行
            return solve(0, N - 1, 0);
        } else { // 处理当前行的当前位置
            // 获取当前两个底部块对应的可能顶部块位掩码
            const w = T[A[N][i]][A[N][i + 1]];
            // 遍历所有可能的顶部块
            for (let b = 0; b < 7; b++) {
                if ((w >> b) & 1) {
                    // 设置顶部块
                    A[N-1][i] = b;
                    // 递归处理下一个位置，更新状态编码
                    // 使用base-8编码来记录当前行的状态
                    if (solve(R * 8 + (b + 1), N, i + 1)) {
                        return true;
                    }
                }
            }
            return false;
        }
    };

    return solve(0, N - 1, 0);
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn pyramid_transition(bottom: String, allowed: Vec<String>) -> bool {
        let mut t = [[0u8; 7]; 7];

        for a in allowed {
            let chars: Vec<char> = a.chars().collect();
            let left = (chars[0] as u8 - b'A') as usize;
            let right = (chars[1] as u8 - b'A') as usize;
            let top = (chars[2] as u8 - b'A') as usize;
            t[left][right] |= 1 << top;
        }

        let n = bottom.len();
        let mut a = vec![vec![0u8; n]; n];

        for (i, c) in bottom.chars().enumerate() {
            a[n-1][i] = (c as u8 - b'A') as u8;
        }

        let mut seen = HashSet::new();

        fn solve(
            t: &[[u8; 7]],
            a: &mut Vec<Vec<u8>>,
            seen: &mut HashSet<u64>,
            r: u64,
            n: usize,
            i: usize
        ) -> bool {
            if n == 1 && i == 1 {
                return true;
            } else if i == n {
                if seen.contains(&r) {
                    return false;
                }
                seen.insert(r);
                return solve(t, a, seen, 0, n - 1, 0);
            } else {
                let w = t[a[n][i] as usize][a[n][i + 1] as usize];
                for b in 0..7 {
                    if (w >> b) & 1 != 0 {
                        a[n - 1][i] = b as u8;
                        if solve(t, a, seen, r * 8 + (b as u64 + 1), n, i + 1) {
                            return true;
                        }
                    }
                }
                false
            }
        }

        solve(&t, &mut a, &mut seen, 0, n - 1, 0)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(A^N)$，其中 $N$ 指的是 `bottom` 的长度，$A$ 指的是字母的大小。
- 空间复杂度：$O(N^2)$。
