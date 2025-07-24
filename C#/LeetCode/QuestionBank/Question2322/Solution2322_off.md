### [从树中删除边的最小分数](https://leetcode.cn/problems/minimum-score-after-removals-on-a-tree/solutions/3726042/cong-shu-zhong-shan-chu-bian-de-zui-xiao-mrrc/)

#### 方法一：双重 $DFS$ 划分连通块

**思路与算法**

题目要求我们删除树上的两条边，然后计算分成的三个连通块中每个连通块的异或值，并按照一个算法来计算最小分数。

我们首先使用深度优先搜索（$DFS$）来遍历整棵树，假设遍历到了节点 $x$，将 $x$ 与其父节点 $f$ 所连的边删除后，子树 $x$ 就是最终三部分的一个部分。接着我们将 $f$ 作为根再去重新 $DFS$ 剩余的部分。在剩余的部分中，再枚举一条删除的边后，就可以得到切分后的三个部分了。那么三个部分的异或值该如何计算？

1. 对于第一个部分，第一次 $DFS$ 时，以 $x$ 为根的子树的异或值可以在回溯时顺便统计。
2. 对于第二个部分，第二次 $DFS$ 时，我们是以 $f$ 为根去遍历的，假设遍历到了节点 $x′$，那么子树 $x′$ 的异或值也可以在回溯时统计。
3. 对于第三个部分，整个树的异或值异或第一个部分和第二个部分后，即可得到。

枚举所有的删除边方案，找到分数的最小值。

**代码**

```C++
class Solution {
public:
    int calc(int part1, int part2, int part3) {
        return max(part1, max(part2, part3)) - min(part1, min(part2, part3));
    }

    int minimumScore(vector<int>& nums, vector<vector<int>>& edges) {
        int n = nums.size();
        vector<vector<int>> e(n);
        for (auto &v : edges) {
            e[v[0]].push_back(v[1]);
            e[v[1]].push_back(v[0]);
        }

        int sum = 0;
        for (int x : nums) {
            sum ^= x;
        }
        
        int res = INT_MAX;
        function<int(int, int, int, int)> dfs2 = [&](int x, int f, int oth, int anc) {
            int son = nums[x];
            for(auto &y : e[x]) {
                if(y == f) {
                    continue;
                }
                son ^= dfs2(y, x, oth, anc);
            }
            if(f == anc) {
                return son;
            }
            res = min(res, calc(oth, son, sum ^ oth ^ son));
            return son;
        };
        
        function<int(int, int)> dfs = [&](int x, int f) {
            int son = nums[x];
            for(auto &y : e[x]) {
                if(y == f) {
                    continue;
                }
                son ^= dfs(y, x);
            }

            for(auto &y : e[x]) {
                if(y == f) {
                    dfs2(y, x, son, x);
                }
            }
            return son;
        };
        
        dfs(0, -1);
        return res;
    }
};
```

```Python
class Solution:
    def calc(self, part1: int, part2: int, part3: int) -> int:
        return max(part1, part2, part3) - min(part1, part2, part3)

    def minimumScore(self, nums: List[int], edges: List[List[int]]) -> int:
        n = len(nums)
        e = [[] for _ in range(n)]
        for u, v in edges:
            e[u].append(v)
            e[v].append(u)

        total = 0
        for x in nums:
            total ^= x

        res = float('inf')

        def dfs2(x: int, f: int, oth: int, anc: int) -> int:
            son = nums[x]
            for y in e[x]:
                if y == f:
                    continue
                son ^= dfs2(y, x, oth, anc)
            if f == anc:
                return son
            nonlocal res
            res = min(res, self.calc(oth, son, total ^ oth ^ son))
            return son

        def dfs(x: int, f: int) -> int:
            son = nums[x]
            for y in e[x]:
                if y == f:
                    continue
                son ^= dfs(y, x)
            for y in e[x]:
                if y == f:
                    dfs2(y, x, son, x)
            return son

        dfs(0, -1)
        return res
```

```Rust
use std::cmp::{max, min};
use std::collections::VecDeque;

impl Solution {
    fn calc(a: i32, b: i32, c: i32) -> i32 {
        max(a, max(b, c)) - min(a, min(b, c))
    }

    pub fn minimum_score(nums: Vec<i32>, edges: Vec<Vec<i32>>) -> i32 {
        let n = nums.len();
        let mut e = vec![vec![]; n];
        for v in edges.iter() {
            e[v[0] as usize].push(v[1] as usize);
            e[v[1] as usize].push(v[0] as usize);
        }

        let mut total = 0;
        for &x in nums.iter() {
            total ^= x;
        }

        let mut res = i32::MAX;

        fn dfs2(
            x: usize,
            f: usize,
            oth: i32,
            anc: usize,
            nums: &Vec<i32>,
            e: &Vec<Vec<usize>>,
            res: &mut i32,
            total: i32,
        ) -> i32 {
            let mut son = nums[x];
            for &y in &e[x] {
                if y == f {
                    continue;
                }
                son ^= dfs2(y, x, oth, anc, nums, e, res, total);
            }
            if f == anc {
                return son;
            }
            *res = min(*res, Solution::calc(oth, son, total ^ oth ^ son));
            son
        }

        fn dfs(
            x: usize,
            f: usize,
            nums: &Vec<i32>,
            e: &Vec<Vec<usize>>,
            res: &mut i32,
            total: i32,
        ) -> i32 {
            let mut son = nums[x];
            for &y in &e[x] {
                if y == f {
                    continue;
                }
                son ^= dfs(y, x, nums, e, res, total);
            }
            for &y in &e[x] {
                if y == f {
                    dfs2(y, x, son, x, nums, e, res, total);
                }
            }
            son
        }

        dfs(0, usize::MAX, &nums, &e, &mut res, total);
        res
    }
}
```

```Java
class Solution {
    int res = Integer.MAX_VALUE;

    public int minimumScore(int[] nums, int[][] edges) {
        int n = nums.length;
        List<List<Integer>> e = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            e.add(new ArrayList<>());
        }
        for (int[] v : edges) {
            e.get(v[0]).add(v[1]);
            e.get(v[1]).add(v[0]);
        }

        int sum = 0;
        for (int x : nums) {
            sum ^= x;
        }

        dfs(0, -1, nums, e, sum);
        return res;
    }

    private int calc(int part1, int part2, int part3) {
        return Math.max(part1, Math.max(part2, part3)) - Math.min(part1, Math.min(part2, part3));
    }

    private int dfs(int x, int f, int[] nums, List<List<Integer>> e, int sum) {
        int son = nums[x];
        for (int y : e.get(x)) {
            if (y == f) {
                continue;
            }
            son ^= dfs(y, x, nums, e, sum);
        }

        for (int y : e.get(x)) {
            if (y == f) {
                dfs2(y, x, son, x, nums, e, sum);
            }
        }
        return son;
    }

    private int dfs2(int x, int f, int oth, int anc, int[] nums, List<List<Integer>> e, int sum) {
        int son = nums[x];
        for (int y : e.get(x)) {
            if (y == f) {
                continue;
            }
            son ^= dfs2(y, x, oth, anc, nums, e, sum);
        }
        if (f == anc) {
            return son;
        }
        res = Math.min(res, calc(oth, son, sum ^ oth ^ son));
        return son;
    }
}
```

```CSharp
public class Solution {
    public int MinimumScore(int[] nums, int[][] edges) {
        int n = nums.Length;
        List<List<int>> e = new List<List<int>>();
        for (int i = 0; i < n; i++) {
            e.Add(new List<int>());
        }
        foreach (var v in edges) {
            e[v[0]].Add(v[1]);
            e[v[1]].Add(v[0]);
        }

        int sum = 0;
        foreach (int x in nums) {
            sum ^= x;
        }

        int res = int.MaxValue;
        Func<int, int, int> dfs = null;
        Func<int, int, int, int, int> dfs2 = null;

        dfs2 = (x, f, oth, anc) => {
            int son = nums[x];
            foreach (int y in e[x]) {
                if (y == f) continue;
                son ^= dfs2(y, x, oth, anc);
            }
            if (f == anc) {
                return son;
            }
            res = Math.Min(res, Calc(oth, son, sum ^ oth ^ son));
            return son;
        };

        dfs = (x, f) => {
            int son = nums[x];
            foreach (int y in e[x]) {
                if (y == f) {
                    continue;
                }
                son ^= dfs(y, x);
            }

            foreach (int y in e[x]) {
                if (y == f) {
                    dfs2(y, x, son, x);
                }
            }
            return son;
        };

        dfs(0, -1);
        return res;
    }

    public int Calc(int part1, int part2, int part3) {
        return Math.Max(part1, Math.Max(part2, part3)) - Math.Min(part1, Math.Min(part2, part3));
    }
}
```

```Go
func minimumScore(nums []int, edges [][]int) int {
    n := len(nums)
    e := make([][]int, n)
    for _, v := range edges {
        e[v[0]] = append(e[v[0]], v[1])
        e[v[1]] = append(e[v[1]], v[0])
    }

    sum := 0
    for _, x := range nums {
        sum ^= x
    }

    res := math.MaxInt32
    var dfs2 func(int, int, int, int) int
    dfs2 = func(x, f, oth, anc int) int {
        son := nums[x]
        for _, y := range e[x] {
            if y == f {
                continue
            }
            son ^= dfs2(y, x, oth, anc)
        }
        if f == anc {
            return son
        }

        res = min(res, calc(oth, son, sum^oth^son))
        return son
    }

    var dfs func(int, int) int
    dfs = func(x, f int) int {
        son := nums[x]
        for _, y := range e[x] {
            if y == f {
                continue
            }
            son ^= dfs(y, x)
        }

        for _, y := range e[x] {
            if y == f {
                dfs2(y, x, son, x)
            }
        }
        return son
    }

    dfs(0, -1)
    return res
}

func calc(part1, part2, part3 int) int {
    return max(part1, max(part2, part3)) - min(part1, min(part2, part3))
}
```

```C
struct ListNode *createListNode(int val) {
    struct ListNode *obj = (struct ListNode *)malloc(sizeof(struct ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

void freeList(struct ListNode *list) {
    while (list) {
        struct ListNode *p = list;
        list = list->next;
        free(p);
    }
}

int calc(int part1, int part2, int part3) {
    return fmax(part1, fmax(part2, part3)) - fmin(part1, fmin(part2, part3));
}

int dfs2(int x, int f, int oth, int anc, int* nums, struct ListNode **adj, int sum, int* res) {
    int son = nums[x];
    for (struct ListNode *p = adj[x]; p != NULL; p = p->next) {
        int y = p->val;
        if (y == f) {
            continue;
        }
        son ^= dfs2(y, x, oth, anc, nums, adj, sum, res);
    }
    if (f == anc) {
        return son;
    }

    *res = fmin(*res, calc(oth, son, sum ^ oth ^ son));
    return son;
}

int dfs(int x, int f, int* nums, struct ListNode **adj, int sum, int* res) {
    int son = nums[x];
    for (struct ListNode *p = adj[x]; p != NULL; p = p->next) {
        int y = p->val;
        if (y == f) {
            continue;
        }
        son ^= dfs(y, x, nums, adj, sum, res);
    }
    for (struct ListNode *p = adj[x]; p != NULL; p = p->next) {
        int y = p->val;
        if (y == f) {
            dfs2(y, x, son, x, nums, adj, sum, res);
        }
    }
    return son;
}

int minimumScore(int* nums, int numsSize, int** edges, int edgesSize, int* edgesColSize) {
    struct ListNode *adj[numsSize];
    for (int i = 0; i < numsSize; i++) {
        adj[i] = NULL;
    }
    for (int i = 0; i < edgesSize; i++) {
        int u = edges[i][0];
        int v = edges[i][1];
        struct ListNode *nodeu = createListNode(u);
        nodeu->next = adj[v];
        adj[v] = nodeu;
        struct ListNode *nodev = createListNode(v);
        nodev->next = adj[u];
        adj[u] = nodev;
    }
    int sum = 0;
    for (int i = 0; i < numsSize; i++) {
        sum ^= nums[i];
    }
    int res = INT_MAX;
    dfs(0, -1, nums, adj, sum, &res);
    for (int i = 0; i < numsSize; i++) {
        freeList(adj[i]);
    }

    return res;
}
```

```JavaScript
var minimumScore = function(nums, edges) {
    const n = nums.length;
    const e = Array.from({ length: n }, () => []);
    for (const [u, v] of edges) {
        e[u].push(v);
        e[v].push(u);
    }

    let sum = 0;
    for (const x of nums) {
        sum ^= x;
    }
    let res = Infinity;

    function dfs2(x, f, oth, anc) {
        let son = nums[x];
        for (const y of e[x]) {
            if (y === f) {
                continue;
            }
            son ^= dfs2(y, x, oth, anc);
        }
        if (f === anc) {
            return son;
        }
        res = Math.min(res, calc(oth, son, sum ^ oth ^ son));
        return son;
    }

    function dfs(x, f) {
        let son = nums[x];
        for (const y of e[x]) {
            if (y === f) {
                continue;
            }
            son ^= dfs(y, x);
        }

        for (const y of e[x]) {
            if (y === f) {
                dfs2(y, x, son, x);
            }
        }
        return son;
    }

    dfs(0, -1);
    return res;
}

function calc(part1, part2, part3) {
    return Math.max(part1, Math.max(part2, part3)) - Math.min(part1, Math.min(part2, part3));
}
```

```TypeScript
function minimumScore(nums: number[], edges: number[][]): number {
    const n = nums.length;
    const e: number[][] = Array.from({ length: n }, () => []);
    for (const [u, v] of edges) {
        e[u].push(v);
        e[v].push(u);
    }

    let sum = 0;
    for (const x of nums) {
        sum ^= x;
    }
    let res = Infinity;

    const dfs2 = (x: number, f: number, oth: number, anc: number): number => {
        let son = nums[x];
        for (const y of e[x]) {
            if (y === f) {
                continue;
            }
            son ^= dfs2(y, x, oth, anc);
        }
        if (f === anc) {
            return son;
        }
        res = Math.min(res, calc(oth, son, sum ^ oth ^ son));
        return son;
    }

    const dfs = (x: number, f: number): number => {
        let son = nums[x];
        for (const y of e[x]) {
            if (y === f) {
                continue;
            }
            son ^= dfs(y, x);
        }
        for (const y of e[x]) {
            if (y === f) {
                dfs2(y, x, son, x);
            }
        }
        return son;
    }

    dfs(0, -1);
    return res;
}

function calc(part1: number, part2: number, part3: number): number {
    return Math.max(part1, Math.max(part2, part3)) - Math.min(part1, Math.min(part2, part3));
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是树上的节点个数。第一次 $DFS$ 时的时间复杂度为 $O(n)$，过程中我们对每个节点重新进行了一次 $DFS$，因此总体时间复杂度是 $O(n^2)$。
- 空间复杂度：$O(n)$。存储图和 $DFS$ 算法时占用的空间复杂度是 $O(n)$。

#### 方法二：在 $DFS$ 序上枚举

**思路与算法**

方法一使用双重 $DFS$ 的方法来枚举三个部分的异或值。在方法二中，我们只需要进行一次 $DFS$，$DFS$ 的先序遍历的顺序有一个很好的特点，每个节点的子树一定在该节点被遍历后被立刻遍历，我们使用 $in[x]$ 记录子树 $x$ 开始遍历（包括 $x$ 本身）的序号，使用 $out[x]$ 记录子树 $x$ 结束遍历的序号，那么如果节点 $x$ 是节点 $y$ 的祖先，就一定有 $in[x]<in[y]<out[x]$ 成立。

因此，我们进行一次 $DFS$ 统计出数组 $in$ 和 $out$，并顺便计算出按照每个节点作为根节点时的子树的异或和 $sum$。接着就可以直接在 $DFS$ 序上枚举要删除的边了。

我们枚举任意两个非根（$0$ 号节点）节点 $u$ 和 $v$，接着删除 $u$ 和 $v$ 与其父节点相连的边，根据 $u$ 和 $v$ 的位置关系来计算三个部分的异或值：

1. 若 $u$ 是 $v$ 的祖先，那么三个部分的异或值为 $sum[0]\oplus sum[u], sum[u]\oplus sum[v], sum[v]$
2. 若 $v$ 是 $u$ 的祖先，那么三个部分的异或值为 $sum[0]\oplus sum[v], sum[v]\oplus sum[u], sum[u]$
3. 若 $u$ 和 $v$ 不互相为对方的祖先，那么三个部分的异或值为 $sum[0]\oplus sum[u]\oplus sum[v], sum[u], sum[v]$

**代码**

```C++
class Solution {
public:
    int calc(int part1, int part2, int part3) { 
        return max(part1, max(part2, part3)) - min(part1, min(part2, part3));
    }
    int minimumScore(vector<int>& nums, vector<vector<int>>& edges) {
        int n = nums.size(), cnt = 0;
        vector<int> sum(n), in(n), out(n);
        vector<vector<int>> adj(n);
        for(auto &e : edges) {
            adj[e[0]].push_back(e[1]);
            adj[e[1]].push_back(e[0]);
        }
        function<void(int, int)> dfs = [&](int x, int fa) {
            in[x] = cnt++;
            sum[x] = nums[x];
            for(auto &y : adj[x]) {
                if(y == fa) {
                    continue;
                }
                dfs(y, x);
                sum[x] ^= sum[y];
            }
            out[x] = cnt;
        };

        dfs(0, -1);
        int res = INT_MAX;
        for(int u = 1; u < n; u ++) {
            for(int v = u + 1; v < n; v ++) {
                if(in[v] > in[u] && in[v] < out[u]) {
                    res = min(res, calc(sum[0] ^ sum[u], sum[u] ^ sum[v], sum[v]));
                } else if(in[u] > in[v] && in[u] < out[v]) {
                    res = min(res, calc(sum[0] ^ sum[v], sum[v] ^ sum[u], sum[u]));
                } else {
                    res = min(res, calc(sum[0] ^ sum[u] ^ sum[v], sum[u], sum[v]));
                }
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def calc(self, a: int, b: int, c: int) -> int:
        return max(a, b, c) - min(a, b, c)

    def minimumScore(self, nums: List[int], edges: List[List[int]]) -> int:
        n = len(nums)
        cnt = 0
        sum_xor = [0] * n
        tin = [0] * n
        tout = [0] * n
        adj = [[] for _ in range(n)]

        for u, v in edges:
            adj[u].append(v)
            adj[v].append(u)

        def dfs(x: int, fa: int):
            nonlocal cnt
            tin[x] = cnt
            cnt += 1
            sum_xor[x] = nums[x]
            for y in adj[x]:
                if y == fa:
                    continue
                dfs(y, x)
                sum_xor[x] ^= sum_xor[y]
            tout[x] = cnt

        dfs(0, -1)

        res = float('inf')
        for u in range(1, n):
            for v in range(u + 1, n):
                if tin[v] > tin[u] and tin[v] < tout[u]:
                    res = min(res, self.calc(sum_xor[0] ^ sum_xor[u], sum_xor[u] ^ sum_xor[v], sum_xor[v]))
                elif tin[u] > tin[v] and tin[u] < tout[v]:
                    res = min(res, self.calc(sum_xor[0] ^ sum_xor[v], sum_xor[v] ^ sum_xor[u], sum_xor[u]))
                else:
                    res = min(res, self.calc(sum_xor[0] ^ sum_xor[u] ^ sum_xor[v], sum_xor[u], sum_xor[v]))
        return res
```

```Rust
use std::cmp::{max, min};
impl Solution {
    fn calc(a: i32, b: i32, c: i32) -> i32 {
        max(a, max(b, c)) - min(a, min(b, c))
    }

    pub fn minimum_score(nums: Vec<i32>, edges: Vec<Vec<i32>>) -> i32 {
        let n = nums.len();
        let mut sum = vec![0; n];
        let mut tin = vec![0; n];
        let mut tout = vec![0; n];
        let mut adj = vec![vec![]; n];
        let mut cnt = 0;

        for e in edges {
            let u = e[0];
            let v = e[1];
            adj[u as usize].push(v as usize);
            adj[v as usize].push(u as usize);
        }

        fn dfs(
            x: usize,
            fa: usize,
            cnt: &mut i32,
            nums: &Vec<i32>,
            sum: &mut Vec<i32>,
            tin: &mut Vec<i32>,
            tout: &mut Vec<i32>,
            adj: &Vec<Vec<usize>>,
        ) {
            tin[x] = *cnt;
            *cnt += 1;
            sum[x] = nums[x];
            for &y in &adj[x] {
                if y == fa {
                    continue;
                }
                dfs(y, x, cnt, nums, sum, tin, tout, adj);
                sum[x] ^= sum[y];
            }
            tout[x] = *cnt;
        }

        dfs(0, usize::MAX, &mut cnt, &nums, &mut sum, &mut tin, &mut tout, &adj);

        let mut res = i32::MAX;
        for u in 1..n {
            for v in (u + 1)..n {
                if tin[v] > tin[u] && tin[v] < tout[u] {
                    let a = sum[0] ^ sum[u];
                    let b = sum[u] ^ sum[v];
                    let c = sum[v];
                    res = min(res, Self::calc(a, b, c));
                } else if tin[u] > tin[v] && tin[u] < tout[v] {
                    let a = sum[0] ^ sum[v];
                    let b = sum[v] ^ sum[u];
                    let c = sum[u];
                    res = min(res, Self::calc(a, b, c));
                } else {
                    let a = sum[0] ^ sum[u] ^ sum[v];
                    let b = sum[u];
                    let c = sum[v];
                    res = min(res, Self::calc(a, b, c));
                }
            }
        }

        res
    }
}
```

```Java
class Solution {
    public int minimumScore(int[] nums, int[][] edges) {
        int n = nums.length;
        List<List<Integer>> adj = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            adj.add(new ArrayList<>());
        }
        for (int[] e : edges) {
            adj.get(e[0]).add(e[1]);
            adj.get(e[1]).add(e[0]);
        }

        int[] sum = new int[n];
        int[] in = new int[n];
        int[] out = new int[n];
        int[] cnt = {0};

        dfs(0, -1, nums, adj, sum, in, out, cnt);
        int res = Integer.MAX_VALUE;
        for (int u = 1; u < n; u++) {
            for (int v = u + 1; v < n; v++) {
                if (in[v] > in[u] && in[v] < out[u]) {
                    res = Math.min(res, calc(sum[0] ^ sum[u], sum[u] ^ sum[v], sum[v]));
                } else if (in[u] > in[v] && in[u] < out[v]) {
                    res = Math.min(res, calc(sum[0] ^ sum[v], sum[v] ^ sum[u], sum[u]));
                } else {
                    res = Math.min(res, calc(sum[0] ^ sum[u] ^ sum[v], sum[u], sum[v]));
                }
            }
        }
        return res;
    }

    private int calc(int part1, int part2, int part3) {
        return Math.max(part1, Math.max(part2, part3)) - Math.min(part1, Math.min(part2, part3));
    }

    private void dfs(int x, int fa, int[] nums, List<List<Integer>> adj, int[] sum, int[] in, int[] out, int[] cnt) {
        in[x] = cnt[0]++;
        sum[x] = nums[x];
        for (int y : adj.get(x)) {
            if (y == fa) {
                continue;
            }
            dfs(y, x, nums, adj, sum, in, out, cnt);
            sum[x] ^= sum[y];
        }
        out[x] = cnt[0];
    }
}
```

```CSharp
public class Solution {
    public int MinimumScore(int[] nums, int[][] edges) {
        int n = nums.Length;
        List<List<int>> adj = new List<List<int>>();
        for (int i = 0; i < n; i++) {
            adj.Add(new List<int>());
        }
        foreach (var e in edges) {
            adj[e[0]].Add(e[1]);
            adj[e[1]].Add(e[0]);
        }

        int[] sum = new int[n];
        int[] in_ = new int[n];
        int[] out_ = new int[n];
        int cnt = 0;
        Dfs(0, -1, nums, adj, sum, in_, out_, ref cnt);

        int res = int.MaxValue;
        for (int u = 1; u < n; u++) {
            for (int v = u + 1; v < n; v++) {
                if (in_[v] > in_[u] && in_[v] < out_[u]) {
                    res = Math.Min(res, Calc(sum[0] ^ sum[u], sum[u] ^ sum[v], sum[v]));
                } else if (in_[u] > in_[v] && in_[u] < out_[v]) {
                    res = Math.Min(res, Calc(sum[0] ^ sum[v], sum[v] ^ sum[u], sum[u]));
                } else {
                    res = Math.Min(res, Calc(sum[0] ^ sum[u] ^ sum[v], sum[u], sum[v]));
                }
            }
        }
        return res;
    }

    private int Calc(int part1, int part2, int part3) {
        return Math.Max(part1, Math.Max(part2, part3)) - Math.Min(part1, Math.Min(part2, part3));
    }

    private void Dfs(int x, int fa, int[] nums, List<List<int>> adj, int[] sum, int[] in_, int[] out_, ref int cnt) {
        in_[x] = cnt++;
        sum[x] = nums[x];
        foreach (int y in adj[x]) {
            if (y == fa) {
                continue;
            }
            Dfs(y, x, nums, adj, sum, in_, out_, ref cnt);
            sum[x] ^= sum[y];
        }
        out_[x] = cnt;
    }
}
```

```Go
func minimumScore(nums []int, edges [][]int) int {
    n := len(nums)
    adj := make([][]int, n)
    for _, e := range edges {
        adj[e[0]] = append(adj[e[0]], e[1])
        adj[e[1]] = append(adj[e[1]], e[0])
    }

    sum := make([]int, n)
    in := make([]int, n)
    out := make([]int, n)
    cnt := 0

    var dfs func(int, int)
    dfs = func(x, fa int) {
        in[x] = cnt
        cnt++
        sum[x] = nums[x]
        for _, y := range adj[x] {
            if y == fa {
                continue
            }
            dfs(y, x)
            sum[x] ^= sum[y]
        }
        out[x] = cnt
    }

    dfs(0, -1)

    res := math.MaxInt32
    for u := 1; u < n; u++ {
        for v := u + 1; v < n; v++ {
            if in[v] > in[u] && in[v] < out[u] {
                res = min(res, calc(sum[0]^sum[u], sum[u]^sum[v], sum[v]))
            } else if in[u] > in[v] && in[u] < out[v] {
                res = min(res, calc(sum[0]^sum[v], sum[v]^sum[u], sum[u]))
            } else {
                res = min(res, calc(sum[0]^sum[u]^sum[v], sum[u], sum[v]))
            }
        }
    }
    return res
}

func calc(part1, part2, part3 int) int {
    return max(part1, max(part2, part3)) - min(part1, min(part2, part3))
}
```

```C
struct ListNode *createListNode(int val) {
    struct ListNode *obj = (struct ListNode *)malloc(sizeof(struct ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

void freeList(struct ListNode *list) {
    while (list) {
        struct ListNode *p = list;
        list = list->next;
        free(p);
    }
}

int calc(int part1, int part2, int part3) {
    return fmax(part1, fmax(part2, part3)) - fmin(part1, fmin(part2, part3));
}

void dfs(int x, int fa, int* nums, struct ListNode** adj, int* sum, int* in, int* out, int* cnt) {
    in[x] = (*cnt)++;
    sum[x] = nums[x];
    for (struct ListNode *p = adj[x]; p != NULL; p = p->next) {
        int y = p->val;
        if (y == fa) {
            continue;
        }
        dfs(y, x, nums, adj, sum, in, out, cnt);
        sum[x] ^= sum[y];
    }
    out[x] = *cnt;
}

int minimumScore(int* nums, int numsSize, int** edges, int edgesSize, int* edgesColSize) {
    struct ListNode *adj[numsSize];
    for (int i = 0; i < numsSize; i++) {
        adj[i] = NULL;
    }
    for (int i = 0; i < edgesSize; i++) {
        int u = edges[i][0];
        int v = edges[i][1];
        struct ListNode *nodeu = createListNode(u);
        nodeu->next = adj[v];
        adj[v] = nodeu;
        struct ListNode *nodev = createListNode(v);
        nodev->next = adj[u];
        adj[u] = nodev;
    }

    int* sum = (int*)calloc(numsSize, sizeof(int));
    int* in = (int*)calloc(numsSize, sizeof(int));
    int* out = (int*)calloc(numsSize, sizeof(int));
    int cnt = 0;

    dfs(0, -1, nums, adj, sum, in, out, &cnt);

    int res = INT_MAX;
    for (int u = 1; u < numsSize; u++) {
        for (int v = u + 1; v < numsSize; v++) {
            if (in[v] > in[u] && in[v] < out[u]) {
                res = fmin(res, calc(sum[0] ^ sum[u], sum[u] ^ sum[v], sum[v]));
            } else if (in[u] > in[v] && in[u] < out[v]) {
                res = fmin(res, calc(sum[0] ^ sum[v], sum[v] ^ sum[u], sum[u]));
            } else {
                res = fmin(res, calc(sum[0] ^ sum[u] ^ sum[v], sum[u], sum[v]));
            }
        }
    }

    for (int i = 0; i < numsSize; i++) {
        freeList(adj[i]);
    }
    free(sum);
    free(in);
    free(out);

    return res;
}
```

```JavaScript
var minimumScore = function(nums, edges) {
    const n = nums.length;
    const adj = Array.from({ length: n }, () => []);
    for (const [u, v] of edges) {
        adj[u].push(v);
        adj[v].push(u);
    }

    const sum = new Array(n).fill(0);
    const in_ = new Array(n).fill(0);
    const out = new Array(n).fill(0);
    let cnt = 0;

    function dfs(x, fa) {
        in_[x] = cnt++;
        sum[x] = nums[x];
        for (const y of adj[x]) {
            if (y === fa) continue;
            dfs(y, x);
            sum[x] ^= sum[y];
        }
        out[x] = cnt;
    }

    dfs(0, -1);

    let res = Infinity;
    for (let u = 1; u < n; u++) {
        for (let v = u + 1; v < n; v++) {
            if (in_[v] > in_[u] && in_[v] < out[u]) {
                res = Math.min(res, calc(sum[0] ^ sum[u], sum[u] ^ sum[v], sum[v]));
            } else if (in_[u] > in_[v] && in_[u] < out[v]) {
                res = Math.min(res, calc(sum[0] ^ sum[v], sum[v] ^ sum[u], sum[u]));
            } else {
                res = Math.min(res, calc(sum[0] ^ sum[u] ^ sum[v], sum[u], sum[v]));
            }
        }
    }
    return res;
}

const calc = (part1, part2, part3) => {
    return Math.max(part1, Math.max(part2, part3)) - Math.min(part1, Math.min(part2, part3));
}
```

```TypeScript
function minimumScore(nums: number[], edges: number[][]): number {
    const n = nums.length;
    const adj = Array.from({ length: n }, () => []);
    for (const [u, v] of edges) {
        adj[u].push(v);
        adj[v].push(u);
    }

    const sum = new Array(n).fill(0);
    const in_ = new Array(n).fill(0);
    const out = new Array(n).fill(0);
    let cnt = 0;

    function dfs(x, fa) {
        in_[x] = cnt++;
        sum[x] = nums[x];
        for (const y of adj[x]) {
            if (y === fa) {
                continue;
            }
            dfs(y, x);
            sum[x] ^= sum[y];
        }
        out[x] = cnt;
    }

    dfs(0, -1);

    let res = Infinity;
    for (let u = 1; u < n; u++) {
        for (let v = u + 1; v < n; v++) {
            if (in_[v] > in_[u] && in_[v] < out[u]) {
                res = Math.min(res, calc(sum[0] ^ sum[u], sum[u] ^ sum[v], sum[v]));
            } else if (in_[u] > in_[v] && in_[u] < out[v]) {
                res = Math.min(res, calc(sum[0] ^ sum[v], sum[v] ^ sum[u], sum[u]));
            } else {
                res = Math.min(res, calc(sum[0] ^ sum[u] ^ sum[v], sum[u], sum[v]));
            }
        }
    }
    return res;
}

function calc(part1, part2, part3) {
    return Math.max(part1, Math.max(part2, part3)) - Math.min(part1, Math.min(part2, part3));
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是树上的节点个数。$DFS$ 时的时间复杂度为 $O(n)$，枚举两个点的时间复杂度为 $O(n^2)$，因此总体时间复杂度是 $O(n^2)$。
- 空间复杂度：$O(n)$。存储图和 $DFS$ 算法时占用的空间复杂度是 $O(n)$。
