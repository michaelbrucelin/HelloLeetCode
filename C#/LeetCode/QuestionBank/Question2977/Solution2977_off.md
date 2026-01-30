### [转换字符串的最小成本 II](https://leetcode.cn/problems/minimum-cost-to-convert-string-ii/solutions/3889117/zhuan-huan-zi-fu-chuan-de-zui-xiao-cheng-fdp8/)

#### 方法一：字典树 + Floyd 算法 + 动态规划

**思路与算法**

我们需要得到字符串 $source$ 转换为 $target$ 的最小成本，但允许将字符串分割成 $source$ 若干个部分，每一部分进行若干次转换，并最后拼接得到 $target$。

因此，这提示我们使用动态规划。记 $f[i] (0\le i<n)$ 表示将 $source$ 到下标 $i$ 为止的前缀部分转换为 $target$ 对应部分的最小成本，其中 $n$ 是字符串 $source$ 的长度。我们有两种状态转移：

- 如果 $source[i]=target[i]$，那么无需进行转换，可以直接有：
  f[i]\leftarrow f[i-1]
- 此外，对于一般情况，我们取任意长度的后缀，记 $x=source[j+1..i]$（左开右闭）转换为 $y=target[j+1..i]$ 的最小成本为 $G(x,y)$，那么有：
  f[i]\leftarrow f[j]+G(x,y)

在状态转移时，我们维护 $f[i]$ 的最小值，边界条件为 $f[-1]=0$，最终的答案即为 $f[n-1]$。

接下来我们需要考虑怎么快速得到 $G(x,y)$，这里可以沿用「[2976\. 转换字符串的最小成本 I](https://leetcode.cn/problems/minimum-cost-to-convert-string-i/)」中的 $Floyd$ 算法：

- 对于 $original$ 和 $changed$ 中的每一个字符串，我们赋予唯一的编号，最后一共可以得到 $p (1\le p\le 2m)$ 个编号，其中 $m$ 是数组 $original$ 的长度；
- 我们将这 $p$ 个字符串看成图 $G$ 上的 $p$ 个节点。对于每一组 $(original[i],changed[i],cost[i])$，我们在 $G$ 中从 $original[i]$ 向 $changed[i]$ 建边，边权为 $cost[i]$；
- 这样一来，当我们需要计算 $x=source[j+1..i]$（左开右闭）转换为 $y=target[j+1..i]$ 的最小成本时，首先判断 $x$ 和 $y$ 是否有对应的节点，如果有，那么最小成本即为图 $G$ 上对应节点之间的最短路径。

在分配编号时，如果我们使用传统的哈希表，考虑到动态规划本身已经有 $O(n^2)$ 的时间复杂度，基于字符串的哈希表有需要 $O(n)$ 的时间进行单次操作，总时间复杂度为 $O(n^3)$，会超出时间限制。这里有两种可以优化的方法：

- 使用字符串的滚动哈希，在 $O(1)$ 的时间计算出任意子字符串的哈希值，并根据哈希值得到对应的编号；
- 使用字典树，当动态规划中 $i$ 增加且 $j$ 不变时，对应的后缀每一次会多出一个字符，这正好对应着在字典树上往子节点的遍历操作。这样只需要在动态规划中先遍历 $j$ 再遍历 $i$，就可以在 $O(1)$ 的时间在字典树上进行移动，得到对应的编号。

下面给出第二种方法对应的代码。

**代码**

```C++
struct Trie {
    Trie* child[26];
    int id;

    Trie() {
        for (int i = 0; i < 26; ++i) {
            child[i] = nullptr;
        }
        id = -1;
    }
};

int add(Trie* node, const string& word, int& index) {
    for (char ch: word) {
        int i = ch - 'a';
        if (!node->child[i]) {
            node->child[i] = new Trie();
        }
        node = node->child[i];
    }
    if (node->id == -1) {
        node->id = ++index;
    }
    return node->id;
}

void update(long long& x, long long y) {
    if (x == -1 || y < x) {
        x = y;
    }
}

class Solution {
public:
    long long minimumCost(string source, string target, vector<string>& original, vector<string>& changed, vector<int>& cost) {
        int n = source.size();
        int m = original.size();
        Trie* root = new Trie();

        int p = -1;
        vector<vector<int>> G(m * 2, vector<int>(m * 2, inf));
        for (int i = 0; i < m * 2; ++i) {
            G[i][i] = 0;
        }
        for (int i = 0; i < m; ++i) {
            int x = add(root, original[i], p);
            int y = add(root, changed[i], p);
            G[x][y] = min(G[x][y], cost[i]);
        }

        for (int k = 0; k <= p; ++k) {
            for (int i = 0; i <= p; ++i) {
                for (int j = 0; j <= p; ++j) {
                    G[i][j] = min(G[i][j], G[i][k] + G[k][j]);
                }
            }
        }

        vector<long long> f(n, -1);
        for (int j = 0; j < n; ++j) {
            if (j > 0 && f[j - 1] == -1) {
                continue;
            }
            long long base = (j == 0 ? 0 : f[j - 1]);
            if (source[j] == target[j]) {
                update(f[j], base);
            }
            Trie* u = root;
            Trie* v = root;
            for (int i = j; i < n; ++i) {
                u = u->child[source[i] - 'a'];
                v = v->child[target[i] - 'a'];
                if (!u || !v) {
                    break;
                }
                if (u->id != -1 && v->id != -1 && G[u->id][v->id] != inf) {
                    update(f[i], base + G[u->id][v->id]);
                }
            }
        }
        return f[n - 1];
    }

private:
    static constexpr int inf = INT_MAX / 2;
};
```

```Python
class Trie:
    def __init__(self):
        self.child = [None] * 26
        self.id = -1

def add(node: Trie, word: str, index: List[int]) -> int:
    for ch in word:
        i = ord(ch) - ord("a")
        if node.child[i] is None:
            node.child[i] = Trie()
        node = node.child[i]
    if node.id == -1:
        index[0] += 1
        node.id = index[0]
    return node.id

def update(x: int, y: int) -> int:
    if x == -1 or y < x:
        return y
    return x

class Solution:
    def minimumCost(self, source: str, target: str, original: List[str], changed: List[str], cost: List[int]) -> int:
        n, m = len(source), len(original)
        root = Trie()

        p = [-1]
        G = [[inf] * (m * 2) for _ in range(m * 2)]
        for i in range(m * 2):
            G[i][i] = 0

        for i in range(m):
            x = add(root, original[i], p)
            y = add(root, changed[i], p)
            G[x][y] = min(G[x][y], cost[i])

        for k in range(p[0] + 1):
            for i in range(p[0] + 1):
                for j in range(p[0] + 1):
                   G[i][j] = min(G[i][j], G[i][k] + G[k][j])

        f = [-1] * n
        for j in range(n):
            if j > 0 and f[j - 1] == -1:
                continue

            base = 0 if j == 0 else f[j - 1]
            if source[j] == target[j]:
                f[j] = update(f[j], base)

            u = v = root
            for i in range(j, n):
                u = u.child[ord(source[i]) - ord("a")]
                v = v.child[ord(target[i]) - ord("a")]
                if u is None or v is None:
                    break
                if u.id != -1 and v.id != -1 and G[u.id][v.id] != inf:
                    f[i] = update(f[i], base + G[u.id][v.id])

        return f[n - 1]
```

```Java
class Trie {
    Trie[] child = new Trie[26];
    int id = -1;
}

class Solution {
    private static final int INF = Integer.MAX_VALUE / 2;

    private int add(Trie node, String word, int[] index) {
        for (char ch : word.toCharArray()) {
            int i = ch - 'a';
            if (node.child[i] == null) {
                node.child[i] = new Trie();
            }
            node = node.child[i];
        }
        if (node.id == -1) {
            node.id = ++index[0];
        }
        return node.id;
    }

    private void update(long[] x, long y) {
        if (x[0] == -1 || y < x[0]) {
            x[0] = y;
        }
    }

    public long minimumCost(String source, String target, String[] original, String[] changed, int[] cost) {
        int n = source.length();
        int m = original.length;
        Trie root = new Trie();

        int[] p = {-1};
        int[][] G = new int[m * 2][m * 2];

        for (int i = 0; i < m * 2; i++) {
            Arrays.fill(G[i], INF);
            G[i][i] = 0;
        }

        for (int i = 0; i < m; i++) {
            int x = add(root, original[i], p);
            int y = add(root, changed[i], p);
            G[x][y] = Math.min(G[x][y], cost[i]);
        }

        int size = p[0] + 1;
        for (int k = 0; k < size; k++) {
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    G[i][j] = Math.min(G[i][j], G[i][k] + G[k][j]);
                }
            }
        }

        long[] f = new long[n];
        Arrays.fill(f, -1);
        for (int j = 0; j < n; j++) {
            if (j > 0 && f[j - 1] == -1) {
                continue;
            }
            long base = (j == 0 ? 0 : f[j - 1]);
            if (source.charAt(j) == target.charAt(j)) {
                f[j] = f[j] == -1 ? base : Math.min(f[j], base);
            }

            Trie u = root;
            Trie v = root;
            for (int i = j; i < n; i++) {
                u = u.child[source.charAt(i) - 'a'];
                v = v.child[target.charAt(i) - 'a'];
                if (u == null || v == null) {
                    break;
                }
                if (u.id != -1 && v.id != -1 && G[u.id][v.id] != INF) {
                    long newVal = base + G[u.id][v.id];
                    if (f[i] == -1 || newVal < f[i]) {
                        f[i] = newVal;
                    }
                }
            }
        }

        return f[n - 1];
    }
}
```

```CSharp
public class Trie {
    public Trie[] child = new Trie[26];
    public int id = -1;
}

public class Solution {
    private const int INF = int.MaxValue / 2;

    private int Add(Trie node, string word, ref int index) {
        foreach (char ch in word) {
            int i = ch - 'a';
            if (node.child[i] == null) {
                node.child[i] = new Trie();
            }
            node = node.child[i];
        }
        if (node.id == -1) {
            node.id = ++index;
        }
        return node.id;
    }

    private void Update(ref long x, long y) {
        if (x == -1 || y < x) {
            x = y;
        }
    }

    public long MinimumCost(string source, string target, string[] original, string[] changed, int[] cost) {
        int n = source.Length;
        int m = original.Length;
        Trie root = new Trie();

        int p = -1;
        int[,] G = new int[m * 2, m * 2];

        for (int i = 0; i < m * 2; i++) {
            for (int j = 0; j < m * 2; j++) {
                G[i, j] = INF;
            }
            G[i, i] = 0;
        }

        for (int i = 0; i < m; i++) {
            int x = Add(root, original[i], ref p);
            int y = Add(root, changed[i], ref p);
            G[x, y] = Math.Min(G[x, y], cost[i]);
        }

        int size = p + 1;
        for (int k = 0; k < size; k++) {
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    G[i, j] = Math.Min(G[i, j], G[i, k] + G[k, j]);
                }
            }
        }

        long[] f = new long[n];
        Array.Fill(f, -1);
        for (int j = 0; j < n; j++) {
            if (j > 0 && f[j - 1] == -1) {
                continue;
            }
            long baseVal = (j == 0 ? 0 : f[j - 1]);
            if (source[j] == target[j]) {
                Update(ref f[j], baseVal);
            }

            Trie u = root;
            Trie v = root;
            for (int i = j; i < n; i++) {
                u = u.child[source[i] - 'a'];
                v = v.child[target[i] - 'a'];
                if (u == null || v == null) {
                    break;
                }
                if (u.id != -1 && v.id != -1 && G[u.id, v.id] != INF) {
                    long newVal = baseVal + G[u.id, v.id];
                    Update(ref f[i], newVal);
                }
            }
        }

        return f[n - 1];
    }
}
```

```Go
type Trie struct {
    child [26]*Trie
    id    int
}

func newTrie() *Trie {
    return &Trie{id: -1}
}

func add(node *Trie, word string, index *int) int {
    for _, ch := range word {
        i := ch - 'a'
        if node.child[i] == nil {
            node.child[i] = newTrie()
        }
        node = node.child[i]
    }
    if node.id == -1 {
        *index++
        node.id = *index
    }
    return node.id
}

func update(x *int64, y int64) {
    if *x == -1 || y < *x {
        *x = y
    }
}

func minimumCost(source string, target string, original []string, changed []string, cost []int) int64 {
    n := len(source)
    m := len(original)
    root := newTrie()

    p := -1
    nodeCount := m * 2
    G := make([][]int, nodeCount)
    for i := range G {
        G[i] = make([]int, nodeCount)
        for j := range G[i] {
            G[i][j] = math.MaxInt32 / 2
        }
        G[i][i] = 0
    }

    for i := 0; i < m; i++ {
        x := add(root, original[i], &p)
        y := add(root, changed[i], &p)
        G[x][y] = min(G[x][y], cost[i])
    }

    size := p + 1
    for k := 0; k < size; k++ {
        for i := 0; i < size; i++ {
            for j := 0; j < size; j++ {
                G[i][j] = min(G[i][j], G[i][k] + G[k][j])
            }
        }
    }

    f := make([]int64, n)
    for i := range f {
        f[i] = -1
    }

    for j := 0; j < n; j++ {
        if j > 0 && f[j - 1] == -1 {
            continue
        }

        var base int64
        if j == 0 {
            base = 0
        } else {
            base = f[j-1]
        }

        if source[j] == target[j] {
            update(&f[j], base)
        }

        u, v := root, root
        for i := j; i < n; i++ {
            u = u.child[source[i] - 'a']
            v = v.child[target[i] - 'a']
            if u == nil || v == nil {
                break
            }
            if u.id != -1 && v.id != -1 && G[u.id][v.id] != math.MaxInt32/2 {
                newVal := base + int64(G[u.id][v.id])
                update(&f[i], newVal)
            }
        }
    }

    return f[n - 1]
}
```

```C
#define INF (INT_MAX / 2)

typedef struct Trie {
    struct Trie* child[26];
    int id;
} Trie;

Trie* createTrie() {
    Trie* node = (Trie*)malloc(sizeof(Trie));
    for (int i = 0; i < 26; i++) {
        node->child[i] = NULL;
    }
    node->id = -1;
    return node;
}

int add(Trie* node, const char* word, int* index) {
    for (int i = 0; word[i]; i++) {
        int ch = word[i] - 'a';
        if (!node->child[ch]) {
            node->child[ch] = createTrie();
        }
        node = node->child[ch];
    }
    if (node->id == -1) {
        node->id = ++(*index);
    }
    return node->id;
}

void update(long long* x, long long y) {
    if (*x == -1 || y < *x) {
        *x = y;
    }
}

long long minimumCost(char* source, char* target, char** original, int originalSize,
                     char** changed, int changedSize, int* cost, int costSize) {
    int n = strlen(source);
    int m = originalSize;
    Trie* root = createTrie();

    int p = -1;
    int nodeCount = m * 2;
    int** G = (int**)malloc(nodeCount * sizeof(int*));
    for (int i = 0; i < nodeCount; i++) {
        G[i] = (int*)malloc(nodeCount * sizeof(int));
        for (int j = 0; j < nodeCount; j++) {
            G[i][j] = INF;
        }
        G[i][i] = 0;
    }

    for (int i = 0; i < m; i++) {
        int x = add(root, original[i], &p);
        int y = add(root, changed[i], &p);
        G[x][y] = fmin(G[x][y], cost[i]);
    }

    for (int k = 0; k <= p; k++) {
        for (int i = 0; i <= p; i++) {
            for (int j = 0; j <= p; j++) {
                G[i][j] = fmin(G[i][j], G[i][k] + G[k][j]);
            }
        }
    }

    long long* f = (long long*)malloc(n * sizeof(long long));
    for (int i = 0; i < n; i++) {
        f[i] = -1;
    }
    for (int j = 0; j < n; j++) {
        if (j > 0 && f[j - 1] == -1) {
            continue;
        }

        long long base = (j == 0 ? 0 : f[j - 1]);
        if (source[j] == target[j]) {
            update(&f[j], base);
        }

        Trie* u = root;
        Trie* v = root;
        for (int i = j; i < n; i++) {
            u = u->child[source[i] - 'a'];
            v = v->child[target[i] - 'a'];
            if (!u || !v) {
                break;
            }
            if (u->id != -1 && v->id != -1 && G[u->id][v->id] != INF) {
                update(&f[i], base + G[u->id][v->id]);
            }
        }
    }

    long long result = f[n - 1];
    for (int i = 0; i < nodeCount; i++) {
        free(G[i]);
    }
    free(G);
    free(f);

    return result;
}
```

```JavaScript
class Trie {
    constructor() {
        this.child = new Array(26).fill(null);
        this.id = -1;
    }
}

function minimumCost(source, target, original, changed, cost) {
    const INF = Number.MAX_SAFE_INTEGER / 2;

    function add(node, word, index) {
        for (const ch of word) {
            const i = ch.charCodeAt(0) - 'a'.charCodeAt(0);
            if (!node.child[i]) {
                node.child[i] = new Trie();
            }
            node = node.child[i];
        }
        if (node.id === -1) {
            node.id = ++index.value;
        }
        return node.id;
    }

    const n = source.length;
    const m = original.length;
    const root = new Trie();

    const p = { value: -1 };
    const nodeCount = m * 2;
    const G = Array.from({ length: nodeCount }, () => Array(nodeCount).fill(INF));
    for (let i = 0; i < nodeCount; i++) {
        G[i][i] = 0;
    }
    for (let i = 0; i < m; i++) {
        const x = add(root, original[i], p);
        const y = add(root, changed[i], p);
        G[x][y] = Math.min(G[x][y], cost[i]);
    }

    const size = p.value + 1;
    for (let k = 0; k < size; k++) {
        for (let i = 0; i < size; i++) {
            for (let j = 0; j < size; j++) {
                G[i][j] = Math.min(G[i][j], G[i][k] + G[k][j]);
            }
        }
    }

    const f = new Array(n).fill(-1);
    for (let j = 0; j < n; j++) {
        if (j > 0 && f[j - 1] === -1) {
            continue;
        }
        const base = j === 0 ? 0 : f[j - 1];
        if (source[j] === target[j]) {
            if (f[j] === -1 || base < f[j]) {
                f[j] = base;
            }
        }

        let u = root;
        let v = root;
        for (let i = j; i < n; i++) {
            u = u.child[source.charCodeAt(i) - 'a'.charCodeAt(0)];
            v = v.child[target.charCodeAt(i) - 'a'.charCodeAt(0)];
            if (!u || !v) {
                break;
            }
            if (u.id !== -1 && v.id !== -1 && G[u.id][v.id] !== INF) {
                const newVal = base + G[u.id][v.id];
                if (f[i] === -1 || newVal < f[i]) {
                    f[i] = newVal;
                }
            }
        }
    }

    return f[n - 1];
}
```

```TypeScript
class Trie {
    child: (Trie | null)[];
    id: number;

    constructor() {
        this.child = new Array(26).fill(null);
        this.id = -1;
    }
}

function minimumCost(source: string, target: string, original: string[], changed: string[], cost: number[]): number {
    const INF: number = Number.MAX_SAFE_INTEGER / 2;

    function add(node: Trie, word: string, index: { value: number }): number {
        for (const ch of word) {
            const i = ch.charCodeAt(0) - 'a'.charCodeAt(0);
            if (!node.child[i]) {
                node.child[i] = new Trie();
            }
            node = node.child[i]!;
        }
        if (node.id === -1) {
            node.id = ++index.value;
        }
        return node.id;
    }

    const n: number = source.length;
    const m: number = original.length;
    const root: Trie = new Trie();

    const p = { value: -1 };
    const nodeCount: number = m * 2;
    const G: number[][] = Array.from({ length: nodeCount }, () => Array(nodeCount).fill(INF));
    for (let i = 0; i < nodeCount; i++) {
        G[i][i] = 0;
    }

    for (let i = 0; i < m; i++) {
        const x: number = add(root, original[i], p);
        const y: number = add(root, changed[i], p);
        G[x][y] = Math.min(G[x][y], cost[i]);
    }

    const size: number = p.value + 1;
    for (let k = 0; k < size; k++) {
        for (let i = 0; i < size; i++) {
            for (let j = 0; j < size; j++) {
                G[i][j] = Math.min(G[i][j], G[i][k] + G[k][j]);
            }
        }
    }

    const f: number[] = new Array(n).fill(-1);
    for (let j = 0; j < n; j++) {
        if (j > 0 && f[j - 1] === -1) {
            continue;
        }
        const base: number = j === 0 ? 0 : f[j - 1];
        if (source[j] === target[j]) {
            if (f[j] === -1 || base < f[j]) {
                f[j] = base;
            }
        }

        let u: Trie | null = root;
        let v: Trie | null = root;
        for (let i = j; i < n; i++) {
            u = u?.child[source.charCodeAt(i) - 'a'.charCodeAt(0)] ?? null;
            v = v?.child[target.charCodeAt(i) - 'a'.charCodeAt(0)] ?? null;
            if (!u || !v) {
                break;
            }
            if (u.id !== -1 && v.id !== -1 && G[u.id][v.id] !== INF) {
                const newVal: number = base + G[u.id][v.id];
                if (f[i] === -1 || newVal < f[i]) {
                    f[i] = newVal;
                }
            }
        }
    }

    return f[n - 1];
}
```

```Rust
use std::collections::HashMap;

const INF: i32 = i32::MAX / 2;

struct TrieNode {
    child: [Option<Box<TrieNode>>; 26],
    id: i32,
}

impl TrieNode {
    fn new() -> Self {
        Self {
            child: Default::default(),
            id: -1,
        }
    }

    fn add(node: &mut Box<TrieNode>, word: &str, index: &mut i32) -> i32 {
        let mut current = node;
        for ch in word.chars() {
            let i = (ch as u8 - b'a') as usize;
            if current.child[i].is_none() {
                current.child[i] = Some(Box::new(TrieNode::new()));
            }
            current = current.child[i].as_mut().unwrap();
        }
        if current.id == -1 {
            *index += 1;
            current.id = *index;
        }
        current.id
    }
}

impl Solution {
    pub fn minimum_cost(source: String, target: String, original: Vec<String>, changed: Vec<String>, cost: Vec<i32>) -> i64 {
        let n = source.len();
        let m = original.len();
        let mut root = Box::new(TrieNode::new());

        let mut p = -1;
        let node_count = m * 2;
        let mut g = vec![vec![INF; node_count]; node_count];
        for i in 0..node_count {
            g[i][i] = 0;
        }

        for i in 0..m {
            let x = TrieNode::add(&mut root, &original[i], &mut p);
            let y = TrieNode::add(&mut root, &changed[i], &mut p);
            g[x as usize][y as usize] = g[x as usize][y as usize].min(cost[i]);
        }

        let size = (p + 1) as usize;
        for k in 0..size {
            for i in 0..size {
                for j in 0..size {
                    g[i][j] = g[i][j].min(g[i][k] + g[k][j]);
                }
            }
        }

        let mut f = vec![-1i64; n];
        let source_chars: Vec<char> = source.chars().collect();
        let target_chars: Vec<char> = target.chars().collect();
        for j in 0..n {
            if j > 0 && f[j - 1] == -1 {
                continue;
            }
            let base = if j == 0 { 0 } else { f[j - 1] };
            if source_chars[j] == target_chars[j] {
                if f[j] == -1 || base < f[j] {
                    f[j] = base;
                }
            }

            let mut u = &root;
            let mut v = &root;
            for i in j..n {
                let u_idx = (source_chars[i] as u8 - b'a') as usize;
                let v_idx = (target_chars[i] as u8 - b'a') as usize;

                u = match u.child[u_idx].as_ref() {
                    Some(node) => node,
                    None => break,
                };
                v = match v.child[v_idx].as_ref() {
                    Some(node) => node,
                    None => break,
                };

                if u.id != -1 && v.id != -1 && g[u.id as usize][v.id as usize] != INF {
                    let new_val = base + g[u.id as usize][v.id as usize] as i64;
                    if f[i] == -1 || new_val < f[i] {
                        f[i] = new_val;
                    }
                }
            }
        }

        f[n - 1]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2+m^3+mL)$，其中 $n$ 是数组 $source$ 和 $target$ 的长度，$m$ 是数组 original、changed 和 $cost$ 的长度，$L$ 是数组 $original$ 和 $changed$ 中字符串的平均长度。构造字典树的时间复杂度为 $O(mL)$，计算最短路的时间复杂度为 $O(m^3)$，动态规划的时间复杂度为 $O(n^2)$。
- 空间复杂度：$O(n+m^2+mL)$。字典树需要的空间为 $O(mL)$，图 $G$ 需要的空间为 $O(m^2)$，动态规划需要的空间为 $O(n)$。
