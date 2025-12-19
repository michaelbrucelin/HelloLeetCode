### [找出知晓秘密的所有专家](https://leetcode.cn/problems/find-all-people-with-secret/solutions/1127118/zhao-chu-zhi-xiao-mi-mi-de-suo-you-zhuan-fzxf/)

#### 方法一：广度优先搜索

**思路与算法**

我们用布尔数组 $secret[i]$ 表示第 $i$ 个人是否知道秘密。初始时，$secret[0]$ 和 $secret[firstPerson]$ 均为 $True$，其余的元素为 $False$。

我们将数组 $meetings$ 中的所有会议按照时间升序排序，这样在我们对 $meetings$ 进行遍历的过程中，就可以保证按照顺序地处理所有会议。根据题目要求，由于秘密共享是「瞬时发生」的，所以我们还需要将时间相同的一批会议进行「统一」处理。

我们可以把每一个时间发生的一批会议抽象成如下的一个图论模型：

- 我们将每一个专家看成图中的一个节点；
- 如果两个专家之间进行了一场会议，那么这两个专家在图中对应的节点之间存在一条无向边。

而我们需要解决的问题转变为：

- 对于任意一个专家，如果存在另一个**已经知道秘密的专家**，它们在图中对应的节点之间是**连通的**，那么这个专家就会知道秘密。

因此，我们可以使用广度优先搜索的方法解决该问题。我们将所有已经知道秘密的专家对应的节点（如果存在）放入队列，在广度优先搜索的每一步中，我们取出队首的节点 $u$，并枚举与 $u$ 相邻的节点 $v$，如果 $v$ 对应的专家还不知道秘密，就将 $v$ 放入队列中以待后续的搜索。当广度优先搜索完成后，我们就将所有在当前时间知道了秘密的专家进行了更新。

最后我们只需要遍历数组 $secret$，将元素值为 $True$ 的下标加入答案即可。

**细节**

上述问题本质上是「静态连通性问题」，因此同样可以使用深度优先搜索或者并查集解决，这里不再赘述。

**代码**

```C++
class Solution {
public:
    vector<int> findAllPeople(int n, vector<vector<int>>& meetings, int firstPerson) {
        int m = meetings.size();
        sort(meetings.begin(), meetings.end(), [&](const auto& x, const auto& y) {
            return x[2] < y[2];
        });

        vector<int> secret(n);
        secret[0] = secret[firstPerson] = true;

        unordered_set<int> vertices;
        unordered_map<int, vector<int>> edges;

        for (int i = 0; i < m;) {
            // meetings[i .. j] 为同一时间
            int j = i;
            while (j + 1 < m && meetings[j + 1][2] == meetings[i][2]) {
                ++j;
            }

            vertices.clear();
            edges.clear();
            for (int k = i; k <= j; ++k) {
                int x = meetings[k][0], y = meetings[k][1];
                vertices.insert(x);
                vertices.insert(y);
                edges[x].push_back(y);
                edges[y].push_back(x);
            }
            
            queue<int> q;
            for (int u: vertices) {
                if (secret[u]) {
                    q.push(u);
                }
            }
            while (!q.empty()) {
                int u = q.front();
                q.pop();
                for (int v: edges[u]) {
                    if (!secret[v]) {
                        secret[v] = true;
                        q.push(v);
                    }
                }
            }

            i = j + 1;
        }
        
        vector<int> ans;
        for (int i = 0; i < n; ++i) {
            if (secret[i]) {
                ans.push_back(i);
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def findAllPeople(self, n: int, meetings: List[List[int]], firstPerson: int) -> List[int]:
        m = len(meetings)
        meetings.sort(key=lambda x: x[2])

        secret = [False] * n
        secret[0] = secret[firstPerson] = True

        i = 0
        while i < m:
            # meetings[i .. j] 为同一时间
            j = i
            while j + 1 < m and meetings[j + 1][2] == meetings[i][2]:
                j += 1

            vertices = set()
            edges = defaultdict(list)
            for k in range(i, j + 1):
                x, y = meetings[k][0], meetings[k][1]
                vertices.update([x, y])
                edges[x].append(y)
                edges[y].append(x)
            
            q = deque([u for u in vertices if secret[u]])
            while q:
                u = q.popleft()
                for v in edges[u]:
                    if not secret[v]:
                        secret[v] = True
                        q.append(v)
            
            i = j + 1
        
        ans = [i for i in range(n) if secret[i]]
        return ans
```

```Java
class Solution {
    public List<Integer> findAllPeople(int n, int[][] meetings, int firstPerson) {
        int m = meetings.length;
        Arrays.sort(meetings, (x, y) -> Integer.compare(x[2], y[2]));
        boolean[] secret = new boolean[n];
        secret[0] = true;
        secret[firstPerson] = true;
        
        for (int i = 0; i < m;) {
            // meetings[i .. j] 为同一时间
            int j = i;
            while (j + 1 < m && meetings[j + 1][2] == meetings[i][2]) {
                ++j;
            }
            
            Set<Integer> vertices = new HashSet<>();
            Map<Integer, List<Integer>> edges = new HashMap<>();
            for (int k = i; k <= j; ++k) {
                int x = meetings[k][0], y = meetings[k][1];
                vertices.add(x);
                vertices.add(y);
                edges.computeIfAbsent(x, key -> new ArrayList<>()).add(y);
                edges.computeIfAbsent(y, key -> new ArrayList<>()).add(x);
            }
            
            Queue<Integer> q = new LinkedList<>();
            for (int u : vertices) {
                if (secret[u]) {
                    q.offer(u);
                }
            }
            while (!q.isEmpty()) {
                int u = q.poll();
                if (edges.containsKey(u)) {
                    for (int v : edges.get(u)) {
                        if (!secret[v]) {
                            secret[v] = true;
                            q.offer(v);
                        }
                    }
                }
            }
            
            i = j + 1;
        }
        
        List<Integer> ans = new ArrayList<>();
        for (int i = 0; i < n; ++i) {
            if (secret[i]) {
                ans.add(i);
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson) {
        int m = meetings.Length;
        Array.Sort(meetings, (x, y) => x[2].CompareTo(y[2]));
        bool[] secret = new bool[n];
        secret[0] = true;
        secret[firstPerson] = true;
        HashSet<int> vertices = new HashSet<int>();
        Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();
        
        for (int i = 0; i < m;) {
            // meetings[i .. j] 为同一时间
            int j = i;
            while (j + 1 < m && meetings[j + 1][2] == meetings[i][2]) {
                ++j;
            }
            
            vertices.Clear();
            edges.Clear();
            for (int k = i; k <= j; ++k) {
                int x = meetings[k][0], y = meetings[k][1];
                vertices.Add(x);
                vertices.Add(y);
                if (!edges.ContainsKey(x)) {
                    edges[x] = new List<int>();
                }
                if (!edges.ContainsKey(y)) {
                    edges[y] = new List<int>();
                }
                edges[x].Add(y);
                edges[y].Add(x);
            }
            
            Queue<int> q = new Queue<int>();
            foreach (int u in vertices) {
                if (secret[u]) {
                    q.Enqueue(u);
                }
            }
            while (q.Count > 0) {
                int u = q.Dequeue();
                if (edges.ContainsKey(u)) {
                    foreach (int v in edges[u]) {
                        if (!secret[v]) {
                            secret[v] = true;
                            q.Enqueue(v);
                        }
                    }
                }
            }
            
            i = j + 1;
        }
        
        List<int> ans = new List<int>();
        for (int i = 0; i < n; ++i) {
            if (secret[i]) {
                ans.Add(i);
            }
        }
        return ans;
    }
}
```

```Go
func findAllPeople(n int, meetings [][]int, firstPerson int) []int {
    m := len(meetings)
    sort.Slice(meetings, func(i, j int) bool {
        return meetings[i][2] < meetings[j][2]
    })
    secret := make([]bool, n)
    secret[0] = true
    secret[firstPerson] = true
    
    for i := 0; i < m; {
        // meetings[i .. j] 为同一时间
        j := i
        for j+1 < m && meetings[j + 1][2] == meetings[i][2] {
            j++
        }
        
        vertices := make(map[int]bool)
        edges := make(map[int][]int)
        for k := i; k <= j; k++ {
            x, y := meetings[k][0], meetings[k][1]
            vertices[x] = true
            vertices[y] = true
            edges[x] = append(edges[x], y)
            edges[y] = append(edges[y], x)
        }
        
        q := []int{}
        for u := range vertices {
            if secret[u] {
                q = append(q, u)
            }
        }
        for len(q) > 0 {
            u := q[0]
            q = q[1:]
            for _, v := range edges[u] {
                if !secret[v] {
                    secret[v] = true
                    q = append(q, v)
                }
            }
        }
        
        i = j + 1
    }
    
    ans := []int{}
    for i := 0; i < n; i++ {
        if secret[i] {
            ans = append(ans, i)
        }
    }
    return ans
}
```

```C
typedef struct {
    int size;
    int capacity;
    int* data;
} IntVector;

typedef struct {
    int key;
    IntVector* val;
    UT_hash_handle hh;
} HashItem;

IntVector* createIntVector() {
    IntVector* vec = (IntVector*)malloc(sizeof(IntVector));
    vec->size = 0;
    vec->capacity = 64;
    vec->data = (int*)malloc(vec->capacity * sizeof(int));
    return vec;
}

void pushBack(IntVector* vec, int value) {
    if (vec->size == vec->capacity) {
        vec->capacity *= 2;
        vec->data = (int*)realloc(vec->data, vec->capacity * sizeof(int));
    }
    vec->data[vec->size++] = value;
}

void freeIntVector(IntVector *vec) {
    free(vec->data);
    free(vec);
} 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    if (pEntry != NULL) {
        pushBack(pEntry->val, val);
    } else {
        pEntry = (HashItem *)malloc(sizeof(HashItem));
        pEntry->key = key;
        pEntry->val = createIntVector();
        pushBack(pEntry->val, val);
        HASH_ADD_INT(*obj, key, pEntry);
    }

    return true;
}

IntVector* hashGetItem(HashItem **obj, int key) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return NULL;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        freeIntVector(curr->val);
        free(curr);
    }
    *obj = NULL;
}

typedef struct {
    int key;
    UT_hash_handle hh;
} HashSetItem;

HashSetItem *hashSetFindItem(HashSetItem **obj, int key) {
    HashSetItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashSetAddItem(HashSetItem **obj, int key) {
    if (hashSetFindItem(obj, key)) {
        return false;
    }
    HashSetItem *pEntry = (HashSetItem *)malloc(sizeof(HashSetItem));
    pEntry->key = key;
    HASH_ADD_INT(*obj, key, pEntry);

    return true;
}

void hashSetFree(HashSetItem **obj) {
    HashSetItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
    *obj = NULL;
}

int compare(const void* a, const void* b) {
    int* meetingA = *(int**)a;
    int* meetingB = *(int**)b;
    return meetingA[2] - meetingB[2];
}

int* findAllPeople(int n, int** meetings, int meetingsSize, int* meetingsColSize, int firstPerson, int* returnSize) {
    // 排序会议
    qsort(meetings, meetingsSize, sizeof(int*), compare);
    bool* secret = (bool*)calloc(n, sizeof(bool));
    secret[0] = secret[firstPerson] = true;
    HashSetItem *vertices = NULL;
    HashItem* edges = NULL;
    int* queue = (int*)malloc(n * sizeof(int));
    
    for (int i = 0; i < meetingsSize;) {
        // meetings[i .. j] 为同一时间
        int j = i;
        while (j + 1 < meetingsSize && meetings[j + 1][2] == meetings[i][2]) {
            ++j;
        }
        
        hashFree(&edges);
        hashSetFree(&vertices);
        edges = NULL;
        for (int k = i; k <= j; ++k) {
            int x = meetings[k][0], y = meetings[k][1];
            hashSetAddItem(&vertices, x);
            hashSetAddItem(&vertices, y);
            hashAddItem(&edges, x, y);
            hashAddItem(&edges, y, x);
        }
        
        int front = 0, rear = 0;
        for (HashSetItem *pEntry = vertices; pEntry != NULL; pEntry = pEntry->hh.next) {
            int u = pEntry->key;
            if (secret[u]) {
                queue[rear++] = u;
            }
        }
        
        while (front < rear) {
            int u = queue[front++];
            IntVector* neighbors = hashGetItem(&edges, u);
            if (neighbors != NULL) {
                for (int idx = 0; idx < neighbors->size; ++idx) {
                    int v = neighbors->data[idx];
                    if (!secret[v]) {
                        secret[v] = true;
                        queue[rear++] = v;
                    }
                }
            }
        }
        i = j + 1;
    }
    
    int pos = 0;
    int* ans = (int*)malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) {
        if (secret[i]) {
            ans[pos++] = i;
        }
    }
    
    *returnSize = pos;
    free(vertices);
    free(queue);
    hashFree(&edges);
    
    return ans;
}
```

```JavaScript
var findAllPeople = function(n, meetings, firstPerson) {
    const m = meetings.length;
    meetings.sort((x, y) => x[2] - y[2]);
    const secret = new Array(n).fill(false);
    secret[0] = true;
    secret[firstPerson] = true;
    let vertices = new Set();
    const edges = new Map();
    
    for (let i = 0; i < m;) {
        // meetings[i .. j] 为同一时间
        let j = i;
        while (j + 1 < m && meetings[j + 1][2] === meetings[i][2]) {
            ++j;
        }
        
        vertices.clear();
        edges.clear();
        for (let k = i; k <= j; ++k) {
            const x = meetings[k][0], y = meetings[k][1];
            vertices.add(x);
            vertices.add(y);
            if (!edges.has(x)) {
                edges.set(x, []);
            }
            if (!edges.has(y)) {
                edges.set(y, []);
            }
            edges.get(x).push(y);
            edges.get(y).push(x);
        }
        
        const q = new Queue();
        for (const u of vertices) {
            if (secret[u]) {
                q.enqueue(u);
            }
        }
        
        while (!q.isEmpty()) {
            const u = q.dequeue();
            if (edges.has(u)) {
                for (const v of edges.get(u)) {
                    if (!secret[v]) {
                        secret[v] = true;
                        q.enqueue(v);
                    }
                }
            }
        }
        
        i = j + 1;
    }
    
    const ans = [];
    for (let i = 0; i < n; ++i) {
        if (secret[i]) {
            ans.push(i);
        }
    }
    return ans;
};
```

```TypeScript
function findAllPeople(n: number, meetings: number[][], firstPerson: number): number[] {
    const m = meetings.length;
    meetings.sort((x, y) => x[2] - y[2]);
    const secret: boolean[] = new Array(n).fill(false);
    secret[0] = true;
    secret[firstPerson] = true;
    let vertices: Set<number> = new Set();
    const edges: Map<number, number[]> = new Map();
    
    for (let i = 0; i < m;) {
        // meetings[i .. j] 为同一时间
        let j = i;
        while (j + 1 < m && meetings[j + 1][2] === meetings[i][2]) {
            ++j;
        }
        
        vertices.clear();
        edges.clear();
        for (let k = i; k <= j; ++k) {
            const x = meetings[k][0], y = meetings[k][1];
            vertices.add(x);
            vertices.add(y);
            if (!edges.has(x)) {
                edges.set(x, []);
            }
            if (!edges.has(y)) {
                edges.set(y, []);
            }
            edges.get(x)!.push(y);
            edges.get(y)!.push(x);
        }
        
        const q = new Queue<number>();
        for (const u of vertices) {
            if (secret[u]) {
                q.enqueue(u);
            }
        }
        
        while (!q.isEmpty()) {
            const u = q.dequeue();
            if (edges.has(u)) {
                for (const v of edges.get(u)!) {
                    if (!secret[v]) {
                        secret[v] = true;
                        q.enqueue(v);
                    }
                }
            }
        }
        
        i = j + 1;
    }
    
    const ans: number[] = [];
    for (let i = 0; i < n; ++i) {
        if (secret[i]) {
            ans.push(i);
        }
    }
    return ans;
};
```

```Rust
use std::collections::{VecDeque, HashMap, HashSet};

impl Solution {
    pub fn find_all_people(n: i32, meetings: Vec<Vec<i32>>, first_person: i32) -> Vec<i32> {
        let n = n as usize;
        let mut meetings = meetings;
        meetings.sort_by(|x, y| x[2].cmp(&y[2]));
        let mut secret = vec![false; n];
        secret[0] = true;
        secret[first_person as usize] = true;
        
        let mut vertices = HashSet::new();
        let mut edges: HashMap<i32, Vec<i32>> = HashMap::new();
        let mut i = 0;
        let m = meetings.len();
        while i < m {
            // meetings[i .. j] 为同一时间
            let mut j = i;
            while j + 1 < m && meetings[j + 1][2] == meetings[i][2] {
                j += 1;
            }
            
            vertices.clear();
            edges.clear();
            for k in i..=j {
                let x = meetings[k][0];
                let y = meetings[k][1];
                vertices.insert(x);
                vertices.insert(y);
                edges.entry(x).or_insert_with(Vec::new).push(y);
                edges.entry(y).or_insert_with(Vec::new).push(x);
            }
            
            let mut queue = VecDeque::new();
            for &u in &vertices {
                if secret[u as usize] {
                    queue.push_back(u);
                }
            }
            
            while let Some(u) = queue.pop_front() {
                if let Some(neighbors) = edges.get(&u) {
                    for &v in neighbors {
                        if !secret[v as usize] {
                            secret[v as usize] = true;
                            queue.push_back(v);
                        }
                    }
                }
            }
            
            i = j + 1;
        }
        
        let mut ans = Vec::new();
        for i in 0..n {
            if secret[i] {
                ans.push(i as i32);
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m\log m+n)$。
  - 排序需要的时间为 $O(m\log m)$；
  - 在所有的广度优先搜索中，数组 $meetings$ 的每一个出现的节点（如果出现多次就计入多次）被访问的次数不超过 $1$ 次，总时间复杂度为 $O(m)$；
  - 统计答案需要的时间为 $O(n)$。
- 空间复杂度：$O(n+m)$，记为广度优先搜索需要的空间。这里不计算返回值数组 $ans$ 需要的空间。
