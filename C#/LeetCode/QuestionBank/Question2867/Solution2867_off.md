### [统计树中的合法路径数目](https://leetcode.cn/problems/count-valid-paths-in-a-tree/solutions/2654126/tong-ji-shu-zhong-de-he-fa-lu-jing-shu-m-yyuw/)

#### 方法一：埃氏筛 + 深度优先搜索

##### 思路与算法

根据题意，我们需要知道一个数是不是质数，可以采用「埃氏筛」来找出范围内所有的质数。关于质数筛选，可以参考题解[204. 计数质数](https://leetcode.cn/problems/count-primes/solutions/507273/ji-shu-zhi-shu-by-leetcode-solution/)。

然后我们分别以质数节点为根，用「深度优先搜索」的方式，递归搜索所有的非质数的子树，并求出所有子树的大小，搜索过程中只搜索非质数节点。任何两个来自不同子树的节点，其路径都通过质数根节点，路径上恰好只有根节点一个质数节点，根据题意路径是合法的。我们只需要把所子树大小，两两相乘并求和，就可以得到包含根节点的所有合法路径。

遍历所有质数节点，并且重复上述过程，便可以得到所有合法路径的数目，返回为最终结果。

##### 代码

```c++
const int N = 100001;
bool isPrime[N];
int init = []() {
    // 埃氏筛
    fill(begin(isPrime), end(isPrime), true);
    isPrime[1] = false;
    for (int i = 2; i * i < N; i++) {
        if (isPrime[i]) {
            for (int j = i * i; j < N; j += i) {
                isPrime[j] = false;
            }
        }
    }
    return 0;
}();

class Solution {
private:
    void dfs(const vector<vector<int>>& G, vector<int>& seen, int i, int pre) {
        seen.push_back(i);
        for (int j : G[i]) {
            if (j != pre && !isPrime[j]) {
                dfs(G, seen, j, i);
            }
        }
    }
public:
    long long countPaths(int n, const vector<vector<int>>& edges) {
        fill(begin(isPrime), end(isPrime), true);
        isPrime[1] = false;
        for (int i = 2; i * i <= n; i++) {
            if (isPrime[i]) {
                for (int j = i * i; j <= n; j += i) {
                    isPrime[j] = false;
                }
            }
        }

        vector<vector<int>> G(n + 1);
        for (const auto& edge : edges) {
            int i = edge[0];
            int j = edge[1];
            G[i].push_back(j);
            G[j].push_back(i);
        }

        vector<int> seen;
        long long res = 0;
        vector<long long> count(n + 1, 0);
        for (int i = 1; i <= n; i++) {
            if (!isPrime[i]) {
                continue;
            }
            long long cur = 0;
            for (int j : G[i]) {
                if (isPrime[j]) {
                    continue;
                }
                if (count[j] == 0) {
                    seen.clear();
                    dfs(G, seen, j, 0);
                    long long cnt = seen.size();
                    for (int k : seen) {
                        count[k] = cnt;
                    }
                }
                res += count[j] * cur;
                cur += count[j];
            }
            res += cur;
        }
        return res;
    }
};
```

```java
public class Solution {
    // 埃氏筛
    private static final int N = 100001;
    private static boolean[] isPrime = new boolean[N];
    static {
        Arrays.fill(isPrime, true);
        isPrime[1] = false;
        for (int i = 2; i * i < N; i++) {
            if (isPrime[i]) {
                for (int j = i * i; j < N; j += i) {
                    isPrime[j] = false;
                }
            }
        }
    }

    public long countPaths(int n, int[][] edges) {
        List<Integer>[] G = new ArrayList[n + 1];
        for (int i = 0; i <= n; i++) {
            G[i] = new ArrayList<>();
        }

        for (int[] edge : edges) {
            int i = edge[0], j = edge[1];
            G[i].add(j);
            G[j].add(i);
        }

        List<Integer> seen = new ArrayList<>();
        long res = 0;
        long[] count = new long[n + 1];
        for (int i = 1; i <= n; i++) {
            if (!isPrime[i]) {
                continue;
            }
            long cur = 0;
            for (int j : G[i]) {
                if (isPrime[j]) {
                    continue;
                }
                if (count[j] == 0) {
                    seen.clear();
                    dfs(G, seen, j, 0);
                    long cnt = seen.size();
                    for (int k : seen) {
                        count[k] = cnt;
                    }
                }
                res += count[j] * cur;
                cur += count[j];
            }
            res += cur;
        }
        return res;
    }

    private void dfs(List<Integer>[] G, List<Integer> seen, int i, int pre) {
        seen.add(i);
        for (int j : G[i]) {
            if (j != pre && !isPrime[j]) {
                dfs(G, seen, j, i);
            }
        }
    }
}
```

```csharp
public class Solution {
    private const int N = 100001;
    private static bool[] isPrime;

    public long CountPaths(int n, int[][] edges) {
        // 埃氏筛
        if (isPrime == null) {
            isPrime = new bool[N];
            Array.Fill(isPrime, true);
            isPrime[1] = false;
            for (int i = 2; i * i < N; i++) {
                if (isPrime[i]) {
                    for (int j = i * i; j < N; j += i) {
                        isPrime[j] = false;
                    }
                }
            }
        }

        IList<int>[] G = new IList<int>[n + 1];
        for (int i = 0; i <= n; i++) {
            G[i] = new List<int>();
        }

        foreach (int[] edge in edges) {
            int i = edge[0], j = edge[1];
            G[i].Add(j);
            G[j].Add(i);
        }

        IList<int> seen = new List<int>();
        long res = 0;
        long[] count = new long[n + 1];
        for (int i = 1; i <= n; i++) {
            if (!isPrime[i]) {
                continue;
            }
            long cur = 0;
            foreach (int j in G[i]) {
                if (isPrime[j]) {
                    continue;
                }
                if (count[j] == 0) {
                    seen.Clear();
                    DFS(G, seen, j, 0);
                    long cnt = seen.Count;
                    foreach (int k in seen) {
                        count[k] = cnt;
                    }
                }
                res += count[j] * cur;
                cur += count[j];
            }
            res += cur;
        }
        return res;
    }

    private void DFS(IList<int>[] G, IList<int> seen, int i, int pre) {
        seen.Add(i);
        foreach (int j in G[i]) {
            if (j != pre && !isPrime[j]) {
                DFS(G, seen, j, i);
            }
        }
    }
}
```

```python
# 埃氏筛
N = 10001
is_prime = [True] * N
is_prime[1] = False
for i in range(2, N):
    if is_prime[i]:
        for j in range(i * i, N, i):
            is_prime[j] = False

class Solution:
    def countPaths(self, n: int, edges: List[List[int]]) -> int:
        G = [[] for _ in range(n + 1)]
        for i, j in edges:
            G[i].append(j)
            G[j].append(i)

        def dfs(i, pre):
            seen.append(i)
            for j in G[i]:
                if j != pre and not is_prime[j]:
                    dfs(j, i)

        res = 0
        count = [0] * (n + 1)
        for i in range(1, n + 1):
            if not is_prime[i]:
                continue
            cur = 0
            for j in G[i]:
                if is_prime[j]:
                    continue
                if count[j] == 0:
                    seen = []
                    dfs(j, 0)
                    for k in seen:
                        count[k] = len(seen)
                res += count[j] * cur
                cur += count[j]
            res += cur
        return res
```

```javascript
// 埃氏筛
const N = 100001;
let isPrime = new Array(N).fill(true);
isPrime[1] = false;
for (let i = 2; i * i < N; i++) {
    if (isPrime[i]) {
        for (let j = i * i; j < N; j += i) {
            isPrime[j] = false;
        }
    }
}

var countPaths = function(n, edges) {
    let G = new Array(n + 1).fill(null).map(() => []);
    for (const [i, j] of edges) {
        G[i].push(j);
        G[j].push(i);
    }

    function dfs(i, pre) {
        seen.push(i);
        for (const j of G[i]) {
            if (j !== pre && !isPrime[j]) {
                dfs(j, i);
            }
        }
    }

    let seen = [];
    let res = 0;
    let count = new Array(n + 1).fill(0);
    for (let i = 1; i <= n; i++) {
        if (!isPrime[i]) {
            continue;
        }
        let cur = 0;
        for (const j of G[i]) {
            if (isPrime[j]) {
                continue;
            }
            if (count[j] === 0) {
                seen = [];
                dfs(j, 0);
                let cnt = seen.length;
                for (const k of seen) {
                    count[k] = cnt;
                }
            }
            res += count[j] * cur;
            cur += count[j];
        }
        res += cur;
    }
    return res;
}
```

```typescript
// 埃氏筛
const N = 100001;
let isPrime = new Array(N).fill(true);
isPrime[1] = false;
for (let i = 2; i * i < N; i++) {
    if (isPrime[i]) {
        for (let j = i * i; j < N; j += i) {
            isPrime[j] = false;
        }
    }
}

function countPaths(n: number, edges: number[][]): number {
    let G = new Array(n + 1).fill(null).map(() => []);
    for (const [i, j] of edges) {
        G[i].push(j);
        G[j].push(i);
    }

    function dfs(i, pre) {
        seen.push(i);
        for (const j of G[i]) {
            if (j !== pre && !isPrime[j]) {
                dfs(j, i);
            }
        }
    }

    let seen = [];
    let res = 0;
    let count = new Array(n + 1).fill(0);
    for (let i = 1; i <= n; i++) {
        if (!isPrime[i]) {
            continue;
        }
        let cur = 0;
        for (const j of G[i]) {
            if (isPrime[j]) {
                continue;
            }
            if (count[j] === 0) {
                seen = [];
                dfs(j, 0);
                let cnt = seen.length;
                for (const k of seen) {
                    count[k] = cnt;
                }
            }
            res += count[j] * cur;
            cur += count[j];
        }
        res += cur;
    }
    return res;
}
```

```go
// 埃氏筛
const N = 100001
var is_prime [N]bool
func init() {
    for i := 0; i < N; i++ {
        is_prime[i] = true
    }
    is_prime[1] = false
    for i := 2; i*i < N; i++ {
        if is_prime[i] {
            for j := i * i; j < N; j += i {
                is_prime[j] = false
            }
        }
    }
}

func countPaths(n int, edges [][]int) int64 {
    G := make([][]int, n + 1)
    for _, edge := range edges {
        i, j := edge[0], edge[1]
        G[i] = append(G[i], j)
        G[j] = append(G[j], i)
    }

    var dfs func(int, int)
    var seen []int
    dfs = func(i, pre int) {
        seen = append(seen, i)
        for _, j := range G[i] {
            if j != pre && !is_prime[j] {
                dfs(j, i)
            }
        }
    }
    res := int64(0)
    count := make([]int64, n+1)
    for i := 1; i <= n; i++ {
        if !is_prime[i] {
            continue
        }
        cur := int64(0)
        for _, j := range G[i] {
            if is_prime[j] {
                continue
            }
            if count[j] == 0 {
                seen = []int{}
                dfs(j, 0)
                cnt := int64(len(seen))
                for _, k := range seen {
                    count[k] = cnt
                }
            }
            res += count[j] * cur
            cur += count[j]
        }
        res += cur
    }
    return res
}
```

```c
#define N 100001
bool isPrime[N];

typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem;

HashItem *hashFindItem(HashItem **obj, long long key) {
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

struct ListNode *createListNode(int val) {
    struct ListNode *obj = (struct ListNode *)malloc(sizeof(struct ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

void freeList(struct ListNode *list) {
    while(list) {
        struct ListNode *p = list;
        list = list->next;
        free(p);
    }
}

void dfs(struct ListNode **G, HashItem **seen, int i, int pre) {
    hashAddItem(seen, i);
    for (struct ListNode *p = G[i]; p; p = p->next) {
        int j = p->val;
        if (j != pre && !isPrime[j]) {
            dfs(G, seen, j, i);
        }
    }
}

long long countPaths(int n, int** edges, int edgesSize, int* edgesColSize) {
    // 埃氏筛
    memset(isPrime, 1, sizeof(isPrime));
    isPrime[1] = false;
    for (int i = 2; i * i <= n; i++) {
        if (isPrime[i]) {
            for (int j = i * i; j <= n; j += i) {
                isPrime[j] = false;
            }
        }
    }

    struct ListNode *G[n + 1];
    for (int i = 0; i <= n; i++) {
        G[i] = NULL;
    }
    for (int i = 0; i < edgesSize; i++) {
        int x = edges[i][0], y = edges[i][1];
        struct ListNode *nodex = createListNode(x);
        nodex->next = G[y];
        G[y] = nodex;
        struct ListNode *nodey = createListNode(y);
        nodey->next = G[x];
        G[x] = nodey;
    }

    HashItem *seen = NULL;
    long long res = 0;
    long long count[n + 1];
    memset(count, 0, sizeof(count));
    for (int i = 1; i <= n; i++) {
        if (!isPrime[i]) {
            continue;
        }
        long long cur = 0;
        for (struct ListNode *p = G[i]; p; p = p->next) {
            int j = p->val;
            if (isPrime[j]) {
                continue;
            }
            if (count[j] == 0) {
                hashFree(&seen);
                seen = NULL;
                dfs(G, &seen, j, 0);
                long long cnt = HASH_COUNT(seen);
                for (HashItem *pEntry = seen; pEntry; pEntry = pEntry->hh.next) {
                    int k = pEntry->key;
                    count[k] = cnt;
                }
            }
            res += count[j] * cur;
            cur += count[j];
        }
        res += cur;
    }
    for (int i = 0; i <= n; i++) {
        free(G[i]);
    }
    hashFree(&seen);
    return res;
}
```

#### 复杂度分析

对于埃氏筛

- 时间复杂度：$O(n\times\log\log n)$，其中 $n$ 是要筛查的数字范围。
- 空间复杂度：$O(n)$，其中 $n$ 是要筛查的数字范围。

对于其余算法部分

- 时间复杂度：$O(n)$，其中 $n$ 是树的大小。
- 空间复杂度：$O(n)$，其中 $n$ 是树的大小。
