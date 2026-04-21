### [执行交换操作后的最小汉明距离](https://leetcode.cn/problems/minimize-hamming-distance-after-swap-operations/solutions/3950418/zhi-xing-jiao-huan-cao-zuo-hou-de-zui-xi-n5av/)

#### 方法一：哈希表 + 并查集

对于 $allowedSwaps$ 中的每一对下标，不论这一对下标对应的元素是什么，都可以将元素进行交换，并且我们可以按照任意次序（$allowedSwaps$ 中的次序），进行任意次数的交换，那么可以使用并查集（使用路径压缩以及按秩合并进行优化）进行预处理来记录不同的集合，每一个集合代表了能够交换元素的所有下标。除此之外，我们还需要使用哈希表来记录每一个集合中各个元素的数量。

然后我们只需要遍历 $target$ 数组，对于其中的每一个元素，其下标一定属于某一个集合，这个集合中如果存在对应于 $target$ 当前下标的元素，那么将这个元素的数量减一，否则汉明距离加一。遍历完 $target$ 数组后返回答案即可。

```C++
class Solution {
private:
    vector<int> fa;
    vector<int> rank;
    // 路径压缩
    int find(int x) {
        if (fa[x] != x) {
            fa[x] = find(fa[x]);
        }
        return fa[x];
    }

    void Union(int x, int y) {
        x = find(x);
        y = find(y);
        if (x == y) return;
        // 按秩合并
        if (rank[x] < rank[y]) {
            swap(x, y);
        }
        fa[y] = x;
        if (rank[x] == rank[y]) {
            rank[x]++;
        }
    }

public:
    int minimumHammingDistance(vector<int>& source, vector<int>& target, vector<vector<int>>& allowedSwaps) {
        int n = source.size();
        fa.resize(n);
        rank.resize(n, 0);
        for (int i = 0; i < n; i++) {
            fa[i] = i;
        }
        for (auto& pair : allowedSwaps) {
            Union(pair[0], pair[1]);
        }
        unordered_map<int, unordered_map<int, int>> sets;
        for (int i = 0; i < n; i++) {
            int f = find(i);
            sets[f][source[i]]++;
        }
        int ans = 0;
        for (int i = 0; i < n; i++) {
            int f = find(i);
            if (sets[f][target[i]] > 0) {
                sets[f][target[i]]--;
            } else {
                ans++;
            }
        }
        return ans;
    }
};
```

```Go
type UnionFind struct {
    fa   []int
    rank []int
}

func NewUnionFind(n int) *UnionFind {
    fa := make([]int, n)
    rank := make([]int, n)
    for i := 0; i < n; i++ {
        fa[i] = i
    }
    return &UnionFind{fa: fa, rank: rank}
}

func (uf *UnionFind) find(x int) int {
    if uf.fa[x] != x {
        uf.fa[x] = uf.find(uf.fa[x])
    }
    return uf.fa[x]
}

func (uf *UnionFind) union(x, y int) {
    x = uf.find(x)
    y = uf.find(y)
    if x == y {
        return
    }
    if uf.rank[x] < uf.rank[y] {
        x, y = y, x
    }
    uf.fa[y] = x
    if uf.rank[x] == uf.rank[y] {
        uf.rank[x]++
    }
}

func minimumHammingDistance(source []int, target []int, allowedSwaps [][]int) int {
    n := len(source)
    uf := NewUnionFind(n)
    for _, pair := range allowedSwaps {
        uf.union(pair[0], pair[1])
    }

    sets := make(map[int]map[int]int)
    for i := 0; i < n; i++ {
        f := uf.find(i)
        if sets[f] == nil {
            sets[f] = make(map[int]int)
        }
        sets[f][source[i]]++
    }

    ans := 0
    for i := 0; i < n; i++ {
        f := uf.find(i)
        if sets[f][target[i]] > 0 {
            sets[f][target[i]]--
        } else {
            ans++
        }
    }
    return ans
}
```

```Python
class UnionFind:
    def __init__(self, n):
        self.fa = list(range(n))
        self.rank = [0] * n

    def find(self, x):
        if self.fa[x] != x:
            self.fa[x] = self.find(self.fa[x])
        return self.fa[x]

    def union(self, x, y):
        x = self.find(x)
        y = self.find(y)
        if x == y:
            return
        if self.rank[x] < self.rank[y]:
            x, y = y, x
        self.fa[y] = x
        if self.rank[x] == self.rank[y]:
            self.rank[x] += 1

class Solution:
    def minimumHammingDistance(self, source: List[int], target: List[int], allowedSwaps: List[List[int]]) -> int:
        n = len(source)
        uf = UnionFind(n)
        for a, b in allowedSwaps:
            uf.union(a, b)

        sets = defaultdict(lambda: defaultdict(int))
        for i in range(n):
            f = uf.find(i)
            sets[f][source[i]] += 1

        ans = 0
        for i in range(n):
            f = uf.find(i)
            if sets[f][target[i]] > 0:
                sets[f][target[i]] -= 1
            else:
                ans += 1
        return ans
```

```Java
class Solution {
    private int[] fa;
    private int[] rank;

    private int find(int x) {
        if (fa[x] != x) {
            fa[x] = find(fa[x]);
        }
        return fa[x];
    }

    private void union(int x, int y) {
        x = find(x);
        y = find(y);
        if (x == y) return;
        if (rank[x] < rank[y]) {
            int temp = x;
            x = y;
            y = temp;
        }
        fa[y] = x;
        if (rank[x] == rank[y]) {
            rank[x]++;
        }
    }

    public int minimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps) {
        int n = source.length;
        fa = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++) {
            fa[i] = i;
        }

        for (int[] pair : allowedSwaps) {
            union(pair[0], pair[1]);
        }

        Map<Integer, Map<Integer, Integer>> sets = new HashMap<>();
        for (int i = 0; i < n; i++) {
            int f = find(i);
            sets.putIfAbsent(f, new HashMap<>());
            Map<Integer, Integer> cnt = sets.get(f);
            cnt.put(source[i], cnt.getOrDefault(source[i], 0) + 1);
        }

        int ans = 0;
        for (int i = 0; i < n; i++) {
            int f = find(i);
            Map<Integer, Integer> cnt = sets.get(f);
            if (cnt.getOrDefault(target[i], 0) > 0) {
                cnt.put(target[i], cnt.get(target[i]) - 1);
            } else {
                ans++;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    private int[] fa;
    private int[] rank;

    private int Find(int x) {
        if (fa[x] != x) {
            fa[x] = Find(fa[x]);
        }
        return fa[x];
    }

    private void Union(int x, int y) {
        x = Find(x);
        y = Find(y);
        if (x == y) return;
        if (rank[x] < rank[y]) {
            int temp = x;
            x = y;
            y = temp;
        }
        fa[y] = x;
        if (rank[x] == rank[y]) {
            rank[x]++;
        }
    }

    public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps) {
        int n = source.Length;
        fa = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++) {
            fa[i] = i;
        }

        foreach (int[] pair in allowedSwaps) {
            Union(pair[0], pair[1]);
        }

        Dictionary<int, Dictionary<int, int>> sets = new Dictionary<int, Dictionary<int, int>>();
        for (int i = 0; i < n; i++) {
            int f = Find(i);
            if (!sets.ContainsKey(f)) {
                sets[f] = new Dictionary<int, int>();
            }
            if (!sets[f].ContainsKey(source[i])) {
                sets[f][source[i]] = 0;
            }
            sets[f][source[i]]++;
        }

        int ans = 0;
        for (int i = 0; i < n; i++) {
            int f = Find(i);
            if (sets[f].ContainsKey(target[i]) && sets[f][target[i]] > 0) {
                sets[f][target[i]]--;
            } else {
                ans++;
            }
        }
        return ans;
    }
}
```

```C
typedef struct {
    int key;
    int value;
    UT_hash_handle hh;
} HashItem;

typedef struct {
    int* fa;
    int* rank;
    int size;
} UnionFind;

UnionFind* createUnionFind(int n) {
    UnionFind* uf = (UnionFind*)malloc(sizeof(UnionFind));
    uf->fa = (int*)malloc(n * sizeof(int));
    uf->rank = (int*)malloc(n * sizeof(int));
    uf->size = n;
    for (int i = 0; i < n; i++) {
        uf->fa[i] = i;
        uf->rank[i] = 0;
    }
    return uf;
}

int find(UnionFind* uf, int x) {
    if (uf->fa[x] != x) {
        uf->fa[x] = find(uf, uf->fa[x]);
    }
    return uf->fa[x];
}

void unionSet(UnionFind* uf, int x, int y) {
    x = find(uf, x);
    y = find(uf, y);
    if (x == y) return;
    if (uf->rank[x] < uf->rank[y]) {
        int temp = x;
        x = y;
        y = temp;
    }
    uf->fa[y] = x;
    if (uf->rank[x] == uf->rank[y]) {
        uf->rank[x]++;
    }
}

void freeUnionFind(UnionFind* uf) {
    free(uf->fa);
    free(uf->rank);
    free(uf);
}

int minimumHammingDistance(int* source, int sourceSize, int* target, int targetSize, int** allowedSwaps, int allowedSwapsSize, int* allowedSwapsColSize) {
    int n = sourceSize;
    UnionFind* uf = createUnionFind(n);

    for (int i = 0; i < allowedSwapsSize; i++) {
        unionSet(uf, allowedSwaps[i][0], allowedSwaps[i][1]);
    }

    HashItem** sets = (HashItem**)calloc(n, sizeof(HashItem*));
    for (int i = 0; i < n; i++) {
        int f = find(uf, i);
        HashItem* entry = NULL;
        HASH_FIND_INT(sets[f], &source[i], entry);
        if (entry == NULL) {
            entry = (HashItem*)malloc(sizeof(HashItem));
            entry->key = source[i];
            entry->value = 1;
            HASH_ADD_INT(sets[f], key, entry);
        } else {
            entry->value++;
        }
    }

    int ans = 0;
    for (int i = 0; i < n; i++) {
        int f = find(uf, i);
        HashItem* entry = NULL;
        HASH_FIND_INT(sets[f], &target[i], entry);
        if (entry != NULL && entry->value > 0) {
            entry->value--;
        } else {
            ans++;
        }
    }

    for (int i = 0; i < n; i++) {
        HashItem* current, *tmp;
        HASH_ITER(hh, sets[i], current, tmp) {
            HASH_DEL(sets[i], current);
            free(current);
        }
    }
    free(sets);
    freeUnionFind(uf);

    return ans;
}
```

```JavaScript
class UnionFind {
    constructor(n) {
        this.fa = new Array(n);
        this.rank = new Array(n).fill(0);
        for (let i = 0; i < n; i++) {
            this.fa[i] = i;
        }
    }

    find(x) {
        if (this.fa[x] !== x) {
            this.fa[x] = this.find(this.fa[x]);
        }
        return this.fa[x];
    }

    union(x, y) {
        x = this.find(x);
        y = this.find(y);
        if (x === y) return;
        if (this.rank[x] < this.rank[y]) {
            [x, y] = [y, x];
        }
        this.fa[y] = x;
        if (this.rank[x] === this.rank[y]) {
            this.rank[x]++;
        }
    }
}

var minimumHammingDistance = function(source, target, allowedSwaps) {
    const n = source.length;
    const uf = new UnionFind(n);

    for (const [a, b] of allowedSwaps) {
        uf.union(a, b);
    }

    const sets = new Map();
    for (let i = 0; i < n; i++) {
        const f = uf.find(i);
        if (!sets.has(f)) {
            sets.set(f, new Map());
        }
        const cnt = sets.get(f);
        cnt.set(source[i], (cnt.get(source[i]) || 0) + 1);
    }

    let ans = 0;
    for (let i = 0; i < n; i++) {
        const f = uf.find(i);
        const cnt = sets.get(f);
        const count = cnt.get(target[i]) || 0;
        if (count > 0) {
            cnt.set(target[i], count - 1);
        } else {
            ans++;
        }
    }
    return ans;
};
```

```TypeScript
class UnionFind {
    fa: number[];
    rank: number[];

    constructor(n: number) {
        this.fa = new Array(n);
        this.rank = new Array(n).fill(0);
        for (let i = 0; i < n; i++) {
            this.fa[i] = i;
        }
    }

    find(x: number): number {
        if (this.fa[x] !== x) {
            this.fa[x] = this.find(this.fa[x]);
        }
        return this.fa[x];
    }

    union(x: number, y: number): void {
        x = this.find(x);
        y = this.find(y);
        if (x === y) return;
        if (this.rank[x] < this.rank[y]) {
            [x, y] = [y, x];
        }
        this.fa[y] = x;
        if (this.rank[x] === this.rank[y]) {
            this.rank[x]++;
        }
    }
}

function minimumHammingDistance(source: number[], target: number[], allowedSwaps: number[][]): number {
    const n = source.length;
    const uf = new UnionFind(n);

    for (const [a, b] of allowedSwaps) {
        uf.union(a, b);
    }

    const sets = new Map<number, Map<number, number>>();
    for (let i = 0; i < n; i++) {
        const f = uf.find(i);
        if (!sets.has(f)) {
            sets.set(f, new Map());
        }
        const cnt = sets.get(f)!;
        cnt.set(source[i], (cnt.get(source[i]) || 0) + 1);
    }

    let ans = 0;
    for (let i = 0; i < n; i++) {
        const f = uf.find(i);
        const cnt = sets.get(f)!;
        const count = cnt.get(target[i]) || 0;
        if (count > 0) {
            cnt.set(target[i], count - 1);
        } else {
            ans++;
        }
    }
    return ans;
}
```

```Rust
struct UnionFind {
    fa: Vec<usize>,
    rank: Vec<usize>,
}

impl UnionFind {
    fn new(n: usize) -> Self {
        UnionFind {
            fa: (0..n).collect(),
            rank: vec![0; n],
        }
    }

    fn find(&mut self, x: usize) -> usize {
        if self.fa[x] != x {
            self.fa[x] = self.find(self.fa[x]);
        }
        self.fa[x]
    }

    fn union(&mut self, x: usize, y: usize) {
        let mut x = self.find(x);
        let mut y = self.find(y);
        if x == y {
            return;
        }
        if self.rank[x] < self.rank[y] {
            std::mem::swap(&mut x, &mut y);
        }
        self.fa[y] = x;
        if self.rank[x] == self.rank[y] {
            self.rank[x] += 1;
        }
    }
}

use std::collections::HashMap;

impl Solution {
    pub fn minimum_hamming_distance(source: Vec<i32>, target: Vec<i32>, allowed_swaps: Vec<Vec<i32>>) -> i32 {
        let n = source.len();
        let mut uf = UnionFind::new(n);

        for swap in &allowed_swaps {
            uf.union(swap[0] as usize, swap[1] as usize);
        }

        let mut sets: HashMap<usize, HashMap<i32, i32>> = HashMap::new();
        for i in 0..n {
            let f = uf.find(i);
            *sets.entry(f).or_insert_with(HashMap::new)
                .entry(source[i]).or_insert(0) += 1;
        }

        let mut ans = 0;
        for i in 0..n {
            let f = uf.find(i);
            let cnt = sets.get_mut(&f).unwrap();
            if let Some(v) = cnt.get_mut(&target[i]) {
                if *v > 0 {
                    *v -= 1;
                    continue;
                }
            }
            ans += 1;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m\cdot \alpha (n))$，其中 $n$ 是数组 $source$ 的长度，$m$ 是数组 $allowedSwaps$ 的长度，$\alpha (n)$ 是反阿克曼函数。处理 $m$ 对交换关系，每次并查集操作需要 $O(\alpha (n))$ 时间。
- 空间复杂度：$O(n)$，其中 $n$ 是数组 $source$ 的长度。
