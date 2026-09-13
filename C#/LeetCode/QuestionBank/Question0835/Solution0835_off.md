### [图像重叠](https://leetcode.cn/problems/image-overlap/solutions/4020763/tu-xiang-zhong-die-by-leetcode-solution-6bcf/)

#### 方法一：枚举偏移量并计数

我们用二元组 $(x,y)$ 表示对 $A$ 的偏移量 $\Delta$，其中 $x$ 表示向左（负数）或向右（正数），$y$ 表示向上（负数）或向下（正数）。在枚举偏移量时，我们可以分别枚举 $A$ 和 $B$ 中的一个 $1$，此时 $\Delta$ 即为 $A$ 中的 $1$ 到 $B$ 中的 $1$ 的偏移量。枚举偏移量的时间复杂度为 $O(N^4)$。随后，我们对于 $A$ 中的每个位置，判断它经过偏移后在 $B$ 中的位置是否为 $1$。这一步的时间复杂度为 $O(N^2)$。

为了方便维护偏移量 $\Delta$，我们可以用 $Java$ 中的 `java.awt.Point` 或者 $Python$ 中的 `complex` 来表示偏移量。在优化方面，我们可以在枚举了 $\Delta$ 之后进行记录，如果下一次枚举到了同样的 $\Delta$，就可以跳过并减少一次 $O(N^2)$ 的判断计算。这样做可以减少一定的运行时间，但不会降低时间复杂度。

```Java
import java.awt.Point;

class Solution {
    public int largestOverlap(int[][] A, int[][] B) {
        int N = A.length;
        List<Point> A2 = new ArrayList(), B2 = new ArrayList();
        for (int i = 0; i < N*N; ++i) {
            if (A[i/N][i%N] == 1) {
                A2.add(new Point(i/N, i%N));
            }
            if (B[i/N][i%N] == 1) {
                B2.add(new Point(i/N, i%N));
            }
        }

        Set<Point> Bset = new HashSet(B2);

        int ans = 0;
        Set<Point> seen = new HashSet();
        for (Point a: A2) for (Point b: B2) {
            Point delta = new Point(b.x - a.x, b.y - a.y);
            if (!seen.contains(delta)) {
                seen.add(delta);
                int cand = 0;
                for (Point p: A2)
                    if (Bset.contains(new Point(p.x + delta.x, p.y + delta.y)))
                        cand++;
                ans = Math.max(ans, cand);
            }
        }

        return ans;
    }
}
```

```Python
class Solution(object):
    def largestOverlap(self, A, B):
        N = len(A)
        A2 = [complex(r, c) for r, row in enumerate(A)
              for c, v in enumerate(row) if v]
        B2 = [complex(r, c) for r, row in enumerate(B)
              for c, v in enumerate(row) if v]
        Bset = set(B2)
        seen = set()
        ans = 0
        for a in A2:
            for b in B2:
                d = b-a
                if d not in seen:
                    seen.add(d)
                    ans = max(ans, sum(x+d in Bset for x in A2))
        return ans
```

```C++
class Solution {
public:
    int largestOverlap(vector<vector<int>>& A, vector<vector<int>>& B) {
        int N = A.size();
        vector<pair<int, int>> A2, B2;

        for (int r = 0; r < N; ++r) {
            for (int c = 0; c < N; ++c) {
                if (A[r][c]) {
                    A2.emplace_back(r, c);
                }
                if (B[r][c]) {
                    B2.emplace_back(r, c);
                }
            }
        }

        auto pairHash = [](const pair<int, int>& p) {
            return hash<int>()(p.first) ^ (hash<int>()(p.second) << 1);
        };

        unordered_set<pair<int, int>, decltype(pairHash)> Bset(0, pairHash);
        unordered_set<pair<int, int>, decltype(pairHash)> seen(0, pairHash);

        for (const auto& p : B2) {
            Bset.insert(p);
        }

        int ans = 0;

        for (const auto& a : A2) {
            for (const auto& b : B2) {
                auto d = make_pair(b.first - a.first, b.second - a.second);
                if (seen.find(d) == seen.end()) {
                    seen.insert(d);
                    int count = 0;
                    for (const auto& x : A2) {
                        auto p = make_pair(x.first + d.first, x.second + d.second);
                        if (Bset.find(p) != Bset.end()) {
                            ++count;
                        }
                    }
                    ans = max(ans, count);
                }
            }
        }

        return ans;
    }
};
```

```CSharp
public class Solution {
    public int LargestOverlap(int[][] A, int[][] B) {
        int N = A.Length;
        var A2 = new List<(int, int)>();
        var B2 = new List<(int, int)>();

        for (int r = 0; r < N; r++) {
            for (int c = 0; c < N; c++) {
                if (A[r][c] == 1) {
                    A2.Add((r, c));
                }
                if (B[r][c] == 1) {
                    B2.Add((r, c));
                }
            }
        }

        var Bset = new HashSet<(int, int)>(B2);
        var seen = new HashSet<(int, int)>();
        int ans = 0;

        foreach (var a in A2) {
            foreach (var b in B2) {
                var d = (b.Item1 - a.Item1, b.Item2 - a.Item2);
                if (!seen.Contains(d)) {
                    seen.Add(d);
                    int count = 0;
                    foreach (var x in A2) {
                        if (Bset.Contains((x.Item1 + d.Item1, x.Item2 + d.Item2))) {
                            count++;
                        }
                    }
                    ans = Math.Max(ans, count);
                }
            }
        }

        return ans;
    }
}
```

```C
type Point struct {
    r, c int
}

func largestOverlap(A [][]int, B [][]int) int {
    N := len(A)
    var A2, B2 []Point

    for r := 0; r < N; r++ {
        for c := 0; c < N; c++ {
            if A[r][c] == 1 {
                A2 = append(A2, Point{r, c})
            }
            if B[r][c] == 1 {
                B2 = append(B2, Point{r, c})
            }
        }
    }

    Bset := make(map[Point]bool)
    for _, b := range B2 {
        Bset[b] = true
    }

    seen := make(map[Point]bool)
    ans := 0

    for _, a := range A2 {
        for _, b := range B2 {
            d := Point{b.r - a.r, b.c - a.c}
            if !seen[d] {
                seen[d] = true
                count := 0
                for _, x := range A2 {
                    if Bset[Point{x.r + d.r, x.c + d.c}] {
                        count++
                    }
                }
                if count > ans {
                    ans = count
                }
            }
        }
    }

    return ans
}
```

```C
typedef struct {
    int key;
    UT_hash_handle hh;
} PointSet;

typedef struct {
    int key;
    UT_hash_handle hh;
} OffsetSet;

PointSet *hashFindPoint(PointSet **obj, int key) {
    PointSet *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

void hashAddPoint(PointSet **obj, int key) {
    if (hashFindPoint(obj, key)) {
        return;
    }
    PointSet *pEntry = (PointSet *)malloc(sizeof(PointSet));
    pEntry->key = key;
    HASH_ADD_INT(*obj, key, pEntry);
}

bool hashHasPoint(PointSet **obj, int key) {
    return hashFindPoint(obj, key) != NULL;
}

void hashFreePoint(PointSet **obj) {
    PointSet *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr);
    }
}

OffsetSet *hashFindOffset(OffsetSet **obj, int key) {
    OffsetSet *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

void hashAddOffset(OffsetSet **obj, int key) {
    if (hashFindOffset(obj, key)) {
        return;
    }
    OffsetSet *pEntry = (OffsetSet *)malloc(sizeof(OffsetSet));
    pEntry->key = key;
    HASH_ADD_INT(*obj, key, pEntry);
}

bool hashHasOffset(OffsetSet **obj, int key) {
    return hashFindOffset(obj, key) != NULL;
}

void hashFreeOffset(OffsetSet **obj) {
    OffsetSet *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr);
    }
}

int largestOverlap(int** A, int ASize, int* AColSize,
                   int** B, int BSize, int* BColSize) {
    int N = ASize;

    int *A2_r = (int*)malloc(N * N * sizeof(int));
    int *A2_c = (int*)malloc(N * N * sizeof(int));
    int A2_size = 0;

    int *B2_r = (int*)malloc(N * N * sizeof(int));
    int *B2_c = (int*)malloc(N * N * sizeof(int));
    int B2_size = 0;

    for (int r = 0; r < N; r++) {
        for (int c = 0; c < N; c++) {
            if (A[r][c]) {
                A2_r[A2_size] = r;
                A2_c[A2_size] = c;
                A2_size++;
            }
            if (B[r][c]) {
                B2_r[B2_size] = r;
                B2_c[B2_size] = c;
                B2_size++;
            }
        }
    }

    PointSet *Bset = NULL;
    for (int i = 0; i < B2_size; i++) {
        int key = B2_r[i] * 100 + B2_c[i];
        hashAddPoint(&Bset, key);
    }

    OffsetSet *seen = NULL;
    int ans = 0;

    for (int i = 0; i < A2_size; i++) {
        for (int j = 0; j < B2_size; j++) {
            int dr = B2_r[j] - A2_r[i];
            int dc = B2_c[j] - A2_c[i];
            int dKey = (dr + N) * 100 + (dc + N);

            if (!hashHasOffset(&seen, dKey)) {
                hashAddOffset(&seen, dKey);
                int count = 0;

                for (int k = 0; k < A2_size; k++) {
                    int pr = A2_r[k] + dr;
                    int pc = A2_c[k] + dc;
                    int pKey = pr * 100 + pc;

                    if (hashHasPoint(&Bset, pKey)) {
                        count++;
                    }
                }

                if (count > ans) {
                    ans = count;
                }
            }
        }
    }

    free(A2_r);
    free(A2_c);
    free(B2_r);
    free(B2_c);
    hashFreePoint(&Bset);
    hashFreeOffset(&seen);

    return ans;
}
```

```JavaScript
var largestOverlap = function(A, B) {
    const N = A.length;
    const A2 = [], B2 = [];

    for (let r = 0; r < N; r++) {
        for (let c = 0; c < N; c++) {
            if (A[r][c]) {
                A2.push([r, c]);
            }
            if (B[r][c]) {
                B2.push([r, c]);
            }
        }
    }

    const Bset = new Set(B2.map(p => p.toString()));
    const seen = new Set();
    let ans = 0;

    for (const a of A2) {
        for (const b of B2) {
            const d = [b[0] - a[0], b[1] - a[1]];
            const dKey = d.toString();
            if (!seen.has(dKey)) {
                seen.add(dKey);
                let count = 0;
                for (const x of A2) {
                    const p = [x[0] + d[0], x[1] + d[1]];
                    if (Bset.has(p.toString())) count++;
                }
                ans = Math.max(ans, count);
            }
        }
    }

    return ans;
};
```

```TypeScript
function largestOverlap(A: number[][], B: number[][]): number {
    const N = A.length;
    const A2: [number, number][] = [];
    const B2: [number, number][] = [];

    for (let r = 0; r < N; r++) {
        for (let c = 0; c < N; c++) {
            if (A[r][c]) {
                A2.push([r, c]);
            }
            if (B[r][c]) {
                B2.push([r, c]);
            }
        }
    }

    const Bset = new Set(B2.map(p => `${p[0]},${p[1]}`));
    const seen = new Set<string>();
    let ans = 0;

    for (const a of A2) {
        for (const b of B2) {
            const d: [number, number] = [b[0] - a[0], b[1] - a[1]];
            const dKey = `${d[0]},${d[1]}`;
            if (!seen.has(dKey)) {
                seen.add(dKey);
                let count = 0;
                for (const x of A2) {
                    const p = `${x[0] + d[0]},${x[1] + d[1]}`;
                    if (Bset.has(p)) count++;
                }
                ans = Math.max(ans, count);
            }
        }
    }

    return ans;
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn largest_overlap(a: Vec<Vec<i32>>, b: Vec<Vec<i32>>) -> i32 {
        let n = a.len();
        let mut a2 = Vec::new();
        let mut b2 = Vec::new();

        for r in 0..n {
            for c in 0..n {
                if a[r][c] == 1 {
                    a2.push((r as i32, c as i32));
                }
                if b[r][c] == 1 {
                    b2.push((r as i32, c as i32));
                }
            }
        }

        let bset: HashSet<(i32, i32)> = b2.iter().cloned().collect();
        let mut seen = HashSet::new();
        let mut ans = 0;

        for &a_point in &a2 {
            for &b_point in &b2 {
                let d = (b_point.0 - a_point.0, b_point.1 - a_point.1);
                if !seen.contains(&d) {
                    seen.insert(d);
                    let mut count = 0;
                    for &x in &a2 {
                        let p = (x.0 + d.0, x.1 + d.1);
                        if bset.contains(&p) {
                            count += 1;
                        }
                    }
                    ans = ans.max(count);
                }
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(N^6)$，其中 $N$ 是数组 `A` 和 `B` 的边长。
- 空间复杂度：$O(N^2)$。

#### 方法二：直接对偏移量计数

我们反向思考方法一，就可以得到一种新的方法。我们分别枚举 $A$ 和 $B$ 中的一个 $1$，计算出偏移量 $\Delta$ 并放入计数器中。对于每一个 $\Delta$，如果它在计数器中出现了 $k$ 次，那么偏移量为 $\Delta$ 时，$A$ 和 $B$ 重合的 $1$ 的数目就为 $k$。

```Java
class Solution {
    public int largestOverlap(int[][] A, int[][] B) {
        int N = A.length;
        int[][] count = new int[2 * N + 1][2 * N + 1];

        for (int i = 0; i < N; ++i) {
            for (int j = 0; j < N; ++j) {
                if (A[i][j] == 1) {
                    for (int i2 = 0; i2 < N; ++i2) {
                        for (int j2 = 0; j2 < N; ++j2) {
                            if (B[i2][j2] == 1) {
                                count[i - i2 + N][j - j2 + N] += 1;
                            }
                        }
                    }
                }
            }
        }

        int ans = 0;
        for (int[] row : count) {
            for (int v : row) {
                ans = Math.max(ans, v);
            }
        }

        return ans;
    }
}
```

```Python
class Solution(object):
    def largestOverlap(self, A, B):
        N = len(A)
        count = collections.Counter()
        for i, row in enumerate(A):
            for j, v in enumerate(row):
                if v:
                    for i2, row2 in enumerate(B):
                        for j2, v2 in enumerate(row2):
                            if v2:
                                count[i-i2, j-j2] += 1
        return max(count.values() or [0])
```

```C++
class Solution {
public:
    int largestOverlap(vector<vector<int>>& A, vector<vector<int>>& B) {
        int N = A.size();
        vector<vector<int>> count(2 * N + 1, vector<int>(2 * N + 1, 0));

        for (int i = 0; i < N; ++i) {
            for (int j = 0; j < N; ++j) {
                if (A[i][j] == 1) {
                    for (int i2 = 0; i2 < N; ++i2) {
                        for (int j2 = 0; j2 < N; ++j2) {
                            if (B[i2][j2] == 1) {
                                count[i - i2 + N][j - j2 + N] += 1;
                            }
                        }
                    }
                }
            }
        }

        int ans = 0;
        for (const auto& row : count) {
            for (int v : row) {
                ans = std::max(ans, v);
            }
        }

        return ans;
    }
};
```

```CSharp
public class Solution {
    public int LargestOverlap(int[][] A, int[][] B) {
        int N = A.Length;
        int[,] count = new int[2 * N + 1, 2 * N + 1];

        for (int i = 0; i < N; ++i) {
            for (int j = 0; j < N; ++j) {
                if (A[i][j] == 1) {
                    for (int i2 = 0; i2 < N; ++i2) {
                        for (int j2 = 0; j2 < N; ++j2) {
                            if (B[i2][j2] == 1) {
                                count[i - i2 + N, j - j2 + N] += 1;
                            }
                        }
                    }
                }
            }
        }

        int ans = 0;
        for (int i = 0; i < 2 * N + 1; ++i) {
            for (int j = 0; j < 2 * N + 1; ++j) {
                ans = Math.Max(ans, count[i, j]);
            }
        }

        return ans;
    }
}
```

```C
func largestOverlap(A [][]int, B [][]int) int {
    N := len(A)
    count := make([][]int, 2*N+1)
    for i := range count {
        count[i] = make([]int, 2*N+1)
    }

    for i := 0; i < N; i++ {
        for j := 0; j < N; j++ {
            if A[i][j] == 1 {
                for i2 := 0; i2 < N; i2++ {
                    for j2 := 0; j2 < N; j2++ {
                        if B[i2][j2] == 1 {
                            count[i-i2+N][j-j2+N]++
                        }
                    }
                }
            }
        }
    }

    ans := 0
    for i := 0; i < 2*N+1; i++ {
        for j := 0; j < 2*N+1; j++ {
            if count[i][j] > ans {
                ans = count[i][j]
            }
        }
    }

    return ans
}
```

```C
int largestOverlap(int** A, int ASize, int* AColSize,
                   int** B, int BSize, int* BColSize) {
    int N = ASize;
    int size = 2 * N + 1;

    int** count = (int**)malloc(size * sizeof(int*));
    for (int i = 0; i < size; i++) {
        count[i] = (int*)calloc(size, sizeof(int));
    }

    for (int i = 0; i < N; i++) {
        for (int j = 0; j < N; j++) {
            if (A[i][j] == 1) {
                for (int i2 = 0; i2 < N; i2++) {
                    for (int j2 = 0; j2 < N; j2++) {
                        if (B[i2][j2] == 1) {
                            count[i - i2 + N][j - j2 + N] += 1;
                        }
                    }
                }
            }
        }
    }

    int ans = 0;
    for (int i = 0; i < size; i++) {
        for (int j = 0; j < size; j++) {
            if (count[i][j] > ans) {
                ans = count[i][j];
            }
        }
    }

    for (int i = 0; i < size; i++) {
        free(count[i]);
    }
    free(count);

    return ans;
}
```

```JavaScript
var largestOverlap = function(A, B) {
    const N = A.length;
    const size = 2 * N + 1;
    const count = Array.from({ length: size }, () => new Array(size).fill(0));

    for (let i = 0; i < N; ++i) {
        for (let j = 0; j < N; ++j) {
            if (A[i][j] === 1) {
                for (let i2 = 0; i2 < N; ++i2) {
                    for (let j2 = 0; j2 < N; ++j2) {
                        if (B[i2][j2] === 1) {
                            count[i - i2 + N][j - j2 + N] += 1;
                        }
                    }
                }
            }
        }
    }

    let ans = 0;
    for (let i = 0; i < size; ++i) {
        for (let j = 0; j < size; ++j) {
            ans = Math.max(ans, count[i][j]);
        }
    }

    return ans;
};
```

```TypeScript
function largestOverlap(A: number[][], B: number[][]): number {
    const N = A.length;
    const size = 2 * N + 1;
    const count: number[][] = Array.from({ length: size }, () => new Array(size).fill(0));

    for (let i = 0; i < N; ++i) {
        for (let j = 0; j < N; ++j) {
            if (A[i][j] === 1) {
                for (let i2 = 0; i2 < N; ++i2) {
                    for (let j2 = 0; j2 < N; ++j2) {
                        if (B[i2][j2] === 1) {
                            count[i - i2 + N][j - j2 + N] += 1;
                        }
                    }
                }
            }
        }
    }

    let ans = 0;
    for (let i = 0; i < size; ++i) {
        for (let j = 0; j < size; ++j) {
            ans = Math.max(ans, count[i][j]);
        }
    }

    return ans;
}
```

```Rust
impl Solution {
    pub fn largest_overlap(a: Vec<Vec<i32>>, b: Vec<Vec<i32>>) -> i32 {
        let n = a.len();
        let size = 2 * n + 1;
        let mut count = vec![vec![0; size]; size];

        for i in 0..n {
            for j in 0..n {
                if a[i][j] == 1 {
                    for i2 in 0..n {
                        for j2 in 0..n {
                            if b[i2][j2] == 1 {
                                count[i - i2 + n][j - j2 + n] += 1;
                            }
                        }
                    }
                }
            }
        }

        let mut ans = 0;
        for row in &count {
            for &v in row {
                ans = ans.max(v);
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(N^4)$，其中 $N$ 是数组 `A` 和 `B` 的边长。
- 空间复杂度：$O(N^2)$。
