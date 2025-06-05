### [按字典序排列最小的等效字符串](https://leetcode.cn/problems/lexicographically-smallest-equivalent-string/solutions/3687876/an-zi-dian-xu-pai-lie-zui-xiao-de-deng-x-rfy2/)

#### 方法一：并查集

**思路与算法**

等价字符具有自反性、对称性和传递性，因此可以将整个等价字符集看作无向图中的连通块，在同一个连通块中的点（即字符）相互等价，可以相互替换。我们要为 $baseStr$ 中的每个字符找到它所在连通块中字典序最小的字符。

根据题目给定的 $s_1$​ 和 $s_2$​，依次遍历每对字符 $s_1​[i]$ 和 $s_2​[i]$，并将这两个字符所在的连通块进行合并，最后可以得到完整的若干个连通块，就可以进行字符替换了。

维护连通块的合并可以使用「[并查集](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fds%2Fdsu%2F)」，为了能够快速找到每个连通块中字典序最小的字符，我们在合并时可以将字典序更小的字符作为代表字符。

**代码**

```C++
class UnionFind {
    vector<int> f;
    int n;
public:
    UnionFind(int n) : n(n) {
        f.resize(n);
        for (int i = 0; i < n; i++) {
            f[i] = i;
        }
    }
    int find(int x) {
        if (f[x] != x) {
            f[x] = find(f[x]);
        }
        return f[x];
    }
    void unite(int x, int y) {
        x = find(x);
        y = find(y);
        if (x == y) {
            return;
        }
        if(x > y) {
            swap(x, y);
        }
        // 总是让字典序更小的作为集合代表字符
        f[y] = x;
    }
};

class Solution {
public:
    string smallestEquivalentString(string s1, string s2, string baseStr) {
        UnionFind uf(26);
        for(int i = 0; i < s1.size(); i++) {
            int x = s1[i] - 'a';
            int y = s2[i] - 'a';
            uf.unite(x, y);
        }
        for(int i = 0; i < baseStr.size(); i++) {
            baseStr[i] = 'a' + uf.find(baseStr[i] - 'a');
        }
        return baseStr;
    }
};
```

```Python
class UnionFind:
    def __init__(self, n):
        self.f = list(range(n))

    def find(self, x):
        if self.f[x] != x:
            self.f[x] = self.find(self.f[x])
        return self.f[x]

    def unite(self, x, y):
        x = self.find(x)
        y = self.find(y)
        if x == y:
            return
        # 总是让字典序更小的作为集合代表字符
        if x > y:
            x, y = y, x
        self.f[y] = x

class Solution:
    def smallestEquivalentString(self, s1: str, s2: str, baseStr: str) -> str:
        uf = UnionFind(26)
        for a, b in zip(s1, s2):
            uf.unite(ord(a) - ord('a'), ord(b) - ord('a'))
        return ''.join(chr(ord('a') + uf.find(ord(c) - ord('a'))) for c in baseStr)
```

```Rust
struct UnionFind {
    f: Vec<usize>,
}

impl UnionFind {
    fn new(n: usize) -> Self {
        let f = (0..n).collect();
        Self { f }
    }

    fn find(&mut self, x: usize) -> usize {
        if self.f[x] != x {
            self.f[x] = self.find(self.f[x]);
        }
        self.f[x]
    }

    fn unite(&mut self, x: usize, y: usize) {
        let mut x = self.find(x);
        let mut y = self.find(y);
        if x == y {
            return;
        }
        // 总是让字典序更小的作为集合代表字符
        if x > y {
            std::mem::swap(&mut x, &mut y);
        }
        self.f[y] = x;
    }
}

impl Solution {
    pub fn smallest_equivalent_string(s1: String, s2: String, base_str: String) -> String {
        let mut uf = UnionFind::new(26);
        for (a, b) in s1.bytes().zip(s2.bytes()) {
            uf.unite((a - b'a') as usize, (b - b'a') as usize);
        }

        base_str
            .bytes()
            .map(|c| {
                let rep = uf.find((c - b'a') as usize);
                (b'a' + rep as u8) as char
            })
            .collect()
    }
}
```

```Java
class UnionFind {
    int[] parent;

    UnionFind(int n) {
        parent = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
            }
    }

    int find(int x) {
        if (parent[x] != x) {
            parent[x] = find(parent[x]);
        }
        return parent[x];
    }

    void unite(int x, int y) {
        x = find(x);
        y = find(y);
        if (x == y) return;
        if (x > y) {
            int temp = x;
            x = y;
            y = temp;
        }
        // 总是让字典序更小的作为集合代表字符
        parent[y] = x;
    }
}

class Solution {
    public String smallestEquivalentString(String s1, String s2, String baseStr) {
        UnionFind uf = new UnionFind(26);
        for (int i = 0; i < s1.length(); i++) {
            uf.unite(s1.charAt(i) - 'a', s2.charAt(i) - 'a');
        }
        
        StringBuilder sb = new StringBuilder();
        for (char c : baseStr.toCharArray()) {
            sb.append((char) ('a' + uf.find(c - 'a')));
        }
        return sb.toString();
    }
}
```

```CSharp
public class UnionFind {
    private int[] parent;

    public UnionFind(int n) {
        parent = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
    }

    public int Find(int x) {
        if (parent[x] != x) {
            parent[x] = Find(parent[x]);
        }
        return parent[x];
    }

    public void Unite(int x, int y) {
        x = Find(x);
        y = Find(y);
        if (x == y) {
            return;
        }
        if (x > y) {
            int temp = x;
            x = y;
            y = temp;
        }
        // 总是让字典序更小的作为集合代表字符
        parent[y] = x;
    }
}

public class Solution {
    public string SmallestEquivalentString(string s1, string s2, string baseStr) {
        var uf = new UnionFind(26);
        for (int i = 0; i < s1.Length; i++) {
            uf.Unite(s1[i] - 'a', s2[i] - 'a');
        }

        char[] result = new char[baseStr.Length];
        for (int i = 0; i < baseStr.Length; i++) {
            result[i] = (char)('a' + uf.Find(baseStr[i] - 'a'));
        }
        return new string(result);
    }
}
```

```Go
func smallestEquivalentString(s1 string, s2 string, baseStr string) string {
    uf := NewUnionFind(26)
    for i := 0; i < len(s1); i++ {
        uf.Unite(int(s1[i] - 'a'), int(s2[i] - 'a'))
    }

    res := []byte(baseStr)
    for i := range res {
        res[i] = byte('a' + uf.Find(int(res[i] - 'a')))
    }
    return string(res)
}

type UnionFind struct {
    parent []int
}

func NewUnionFind(n int) *UnionFind {
    uf := &UnionFind{parent: make([]int, n)}
    for i := 0; i < n; i++ {
        uf.parent[i] = i
    }
    return uf
}

func (uf *UnionFind) Find(x int) int {
    if uf.parent[x] != x {
        uf.parent[x] = uf.Find(uf.parent[x])
    }
    return uf.parent[x]
}

func (uf *UnionFind) Unite(x, y int) {
    x, y = uf.Find(x), uf.Find(y)
    if x == y {
        return
    }
    if x > y {
        x, y = y, x
    }
    // 总是让字典序更小的作为集合代表字符
    uf.parent[y] = x
}
```

```C
typedef struct {
    int* parent;
} UnionFind;

UnionFind* createUnionFind(int n) {
    UnionFind* uf = malloc(sizeof(UnionFind));
    uf->parent = malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) {
        uf->parent[i] = i;
    }
    return uf;
}

int find(UnionFind* uf, int x) {
    if (uf->parent[x] != x) {
        uf->parent[x] = find(uf, uf->parent[x]);
    }
    return uf->parent[x];
}

void unite(UnionFind* uf, int x, int y) {
    x = find(uf, x);
    y = find(uf, y);
    if (x == y) return;
    if (x > y) {
        int tmp = x; 
        x = y; 
        y = tmp;
    }
    // 总是让字典序更小的作为集合代表字符
    uf->parent[y] = x;
}

void freeUnionFind(UnionFind* uf) {
    free(uf->parent);
    free(uf);
}

char* smallestEquivalentString(char* s1, char* s2, char* baseStr) {
    UnionFind* uf = createUnionFind(26);
    for (int i = 0; s1[i]; i++) {
        unite(uf, s1[i] - 'a', s2[i] - 'a');
    }
    for (int i = 0; baseStr[i]; i++) {
        baseStr[i] = 'a' + find(uf, baseStr[i] - 'a');
    }
    freeUnionFind(uf);
    return baseStr;
}
```

```JavaScript
class UnionFind {
    constructor(n) {
        this.parent = Array.from({ length: n }, (_, i) => i);
    }

    find(x) {
        if (this.parent[x] !== x) {
            this.parent[x] = this.find(this.parent[x]);
        }
        return this.parent[x];
    }

    unite(x, y) {
        x = this.find(x);
        y = this.find(y);
        if (x === y) {
            return;
        }
        if (x > y) {
            [x, y] = [y, x];
        }
        // 总是让字典序更小的作为集合代表字符
        this.parent[y] = x;
    }
}

var smallestEquivalentString = function(s1, s2, baseStr) {
    const uf = new UnionFind(26);
    for (let i = 0; i < s1.length; i++) {
        uf.unite(s1.charCodeAt(i) - 97, s2.charCodeAt(i) - 97);
    }
    return [...baseStr].map(c =>
        String.fromCharCode(uf.find(c.charCodeAt(0) - 97) + 97)
    ).join('');
}
```

```TypeScript
class UnionFind {
    parent: number[];

    constructor(n: number) {
        this.parent = Array.from({ length: n }, (_, i) => i);
    }

    find(x: number): number {
        if (this.parent[x] !== x) {
            this.parent[x] = this.find(this.parent[x]);
        }
        return this.parent[x];
    }

    unite(x: number, y: number): void {
        x = this.find(x);
        y = this.find(y);
        if (x === y) {
            return;
        }
        if (x > y) {
            [x, y] = [y, x];
        }
        // 总是让字典序更小的作为集合代表字符
        this.parent[y] = x;
    }
}

function smallestEquivalentString(s1: string, s2: string, baseStr: string): string {
    const uf = new UnionFind(26);
    for (let i = 0; i < s1.length; i++) {
        uf.unite(s1.charCodeAt(i) - 97, s2.charCodeAt(i) - 97);
    }
    return [...baseStr].map(c =>
        String.fromCharCode(uf.find(c.charCodeAt(0) - 97) + 97)
    ).join('');
}
```

**复杂度分析**

- 时间复杂度：$O((n+m)logC)$。其中 $n$ 是 $s_1$​ 和 $s_2$​ 的长度，$m$ 是 $baseStr$ 的长度，$C$ 是字符集大小，本题中为 $26$。由于并查集使用了路径压缩优化，合并和查找的平均时间复杂度为 $O(\alpha(C))$，其中 $\alpha$ 是反阿克曼函数，最差时间复杂度为 $O(logC)$。
- 空间复杂度：$O(C)$。$C$ 是字符集大小，本题中为 $26$，并查集所需的空间是 $O(C)$。
