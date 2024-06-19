### [矩阵中严格递增的单元格数](https://leetcode.cn/problems/maximum-strictly-increasing-cells-in-a-matrix/solutions/2809597/ju-zhen-zhong-yan-ge-di-zeng-de-dan-yuan-ff4v/)

#### 方法一：动态规划

**思路与算法**

设 $d[i][j]$ 为移动到单元格 $(i, j)$ 的最大步数，其中 $(i, j)$ 可以作为起始单元格，也可以是从其他单元格移动而来。那么我们会考虑从第 $i$ 行以及第 $j$ 列上矩阵数值小于 $\textit{mat}[i][j]$ 的位置进行转移，即取以下数值中的最大值：

- 第 $i$ 行：$\max(d[i][j'] + 1)$，其中 $\textit{mat}[i][j'] < \textit{mat}[i][j]$；
- 第 $j$ 列：$\max(d[i'][j] + 1)$，其中 $\textit{mat}[i'][j] < \textit{mat}[i][j]$。

因此，整个状态空间在进行转移时是有序的，我们可以对 $\textit{mat}$ 进行排序，从小到大进行转移。但在转移时，每个状态都要扫描一遍对应的行和列，时间复杂度为 $O(n + m)$，而整体求解的时间复杂度为 $O(nm(n+m))$，可能会超时，因此需要进行优化。

考虑到所有的 $d[i][j]$ 在更新时，值只会越来越大，而转移过程中我们只考虑对应行和对应列上 $d$ 的最大值（由于大于 $\textit{mat}[i][j]$ 的位置还未遍历到，它们的状态还未更新，可设置为 000）。因此，设置长度为 $m$ 的数组 $\textit{row}$ 来维护每一行 $d$ 的最大值，设置长度为 $n$ 的数组 $\textit{col}$ 来维护每一列的最大值，这样一来：

$$d[i][j] = \max(\textit{row}[i], \textit{col}[j]) + 1$$

在每次更新了 $d[i][j]$ 后，需要更新 $\textit{row}[i]$ 和 $\textit{col}[j]$。另外需要注意的是，由于 $\textit{mat}$ 中可能包含相同数字，我们需要同时更新它们的 $d$ 值，然后再同时更新它们对应的 $\textit{row}$ 和 $\textit{col}$。

**代码**

```Python
class Solution:
    def maxIncreasingCells(self, mat: List[List[int]]) -> int:
        m, n = len(mat), len(mat[0])
        mp = defaultdict(list)
        row = [0] * m
        col = [0] * n

        for i in range(m):
            for j in range(n):
                mp[mat[i][j]].append((i, j))
        for _, pos in sorted(mp.items(), key=lambda k:k[0]):
            # 存放相同数值的答案，便于后续更新 row 和 col
            res = [max(row[i], col[j]) + 1 for i, j in pos]
            for (i, j), d in zip(pos, res):
                row[i] = max(row[i], d)
                col[j] = max(col[j], d)
        return max(row)
```

```Java
class Solution {
    public int maxIncreasingCells(int[][] mat) {
        int m = mat.length, n = mat[0].length;
        Map<Integer, List<int[]>> mp = new HashMap<Integer, List<int[]>>();
        int[] row = new int[m];
        int[] col = new int[n];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                mp.putIfAbsent(mat[i][j], new ArrayList<int[]>());
                mp.get(mat[i][j]).add(new int[]{i, j});
            }
        }
        List<Integer> keys = new ArrayList<Integer>(mp.keySet());
        Collections.sort(keys);
        for (int key : keys) {
            List<int[]> pos = mp.get(key);
            List<Integer> res = new ArrayList<Integer>(); // 存放相同数值的答案，便于后续更新 row 和 col
            for (int[] arr : pos) {
                res.add(Math.max(row[arr[0]], col[arr[1]]) + 1);
            }
            for (int i = 0; i < pos.size(); i++) {
                int[] arr = pos.get(i);
                int d = res.get(i);
                row[arr[0]] = Math.max(row[arr[0]], d);
                col[arr[1]] = Math.max(col[arr[1]], d);
            }
        }
        return Arrays.stream(row).max().getAsInt();
    }
}
```

```CSharp
public class Solution {
    public int MaxIncreasingCells(int[][] mat) {
        int m = mat.Length, n = mat[0].Length;
        IDictionary<int, IList<int[]>> dic = new Dictionary<int, IList<int[]>>();
        int[] row = new int[m];
        int[] col = new int[n];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                dic.TryAdd(mat[i][j], new List<int[]>());
                dic[mat[i][j]].Add(new int[]{i, j});
            }
        }
        IList<int> keys = new List<int>(dic.Keys);
        ((List<int>) keys).Sort();
        foreach (int key in keys) {
            IList<int[]> pos = dic[key];
            IList<int> res = new List<int>(); // 存放相同数值的答案，便于后续更新 row 和 col
            foreach (int[] arr in pos) {
                res.Add(Math.Max(row[arr[0]], col[arr[1]]) + 1);
            }
            for (int i = 0; i < pos.Count; i++) {
                int[] arr = pos[i];
                int d = res[i];
                row[arr[0]] = Math.Max(row[arr[0]], d);
                col[arr[1]] = Math.Max(col[arr[1]], d);
            }
        }
        return row.Max();
    }
}
```

```C++
class Solution {
public:
    int maxIncreasingCells(vector<vector<int>>& mat) {
        int m = mat.size(), n = mat[0].size();
        map<int, vector<pair<int, int>>> mp;
        vector<int> row(m), col(n);
        
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                mp[mat[i][j]].push_back({i, j});
            }
        }

        vector<int> res; // 存放相同数值的答案，便于后续更新 row 和 col
        for (auto &[_, pos] : mp) {
            res.clear();
            for (auto &[x, y] : pos) {
                res.push_back(max(row[x], col[y]) + 1);
            }
            for (int i = 0; i < pos.size(); i++) {
                auto &[x, y] = pos[i];
                row[x] = max(row[x], res[i]);
                col[y] = max(col[y], res[i]);
            }
        }

        return *max_element(row.begin(), row.end());
    }
};
```

```Go
func maxIncreasingCells(mat [][]int) int {
    m, n := len(mat), len(mat[0])
    mp := make(map[int][][2]int)
    row := make([]int, m)
    col := make([]int, n)
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            mp[mat[i][j]] = append(mp[mat[i][j]], [2]int{i, j})
        }
    }
    keys := []int{}
    for key, _ := range mp {
        keys = append(keys, key)
    }
    sort.Ints(keys)

    for _, key := range keys {
        pos := mp[key]
        res := []int{} // 存放相同数值的答案，便于后续更新 row 和 col
        for _, arr := range pos {
            res = append(res, max(row[arr[0]], col[arr[1]]) + 1);
        }
        for i := 0; i < len(pos); i++ {
            arr, d := pos[i], res[i]
            row[arr[0]] = max(row[arr[0]], d)
            col[arr[1]] = max(col[arr[1]], d)
        }
    }
    
    return maxSlice(row)
}

func maxSlice(slice []int) int {
    maxVal := slice[0]
    for _, val := range slice {
        if val > maxVal {
            maxVal = val
        }
    }
    return maxVal
}
```

```C
typedef struct Element {
    int x;
    int y;
    struct Element *next;
} Element;

typedef struct {
    int key;
    Element *val;
    UT_hash_handle hh;
} HashItem; 

Element *createElement(int x, int y) {
    Element *obj = (Element *)malloc(sizeof(Element));
    obj->x = x;
    obj->y = y;
    obj->next = NULL;
    return obj;
}

void freeList(Element *list) {
    while (list) {
        Element *p = list;
        list = list->next;
        free(p);
    }
}

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int x, int y) {
    HashItem *pEntry = hashFindItem(obj, key);
    Element *p = createElement(x, y);
    if (pEntry) {
        p->next = pEntry->val;
        pEntry->val = p;
    } else {
        HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
        pEntry->key = key;
        pEntry->val = p;
        HASH_ADD_INT(*obj, key, pEntry);
    }

    return true;
}

Element* hashGetItem(HashItem **obj, int key, Element *defaultVal) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr->val);
        free(curr);
    }
}

static int cmp(const void *a, const void *b) {
    return *(int *)a - *(int *)b;
}

int maxIncreasingCells(int** mat, int matSize, int* matColSize){
    int m = matSize, n = matColSize[0];
    HashItem *mp = NULL;
    int row[m], col[n];
    memset(row, 0, sizeof(row));
    memset(col, 0, sizeof(col));
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            hashAddItem(&mp, mat[i][j], i, j);
        }
    }
    
    int len = HASH_COUNT(mp);
    int sortedKeys[len]; 
    int pos = 0;
    for (HashItem *pEntry = mp; pEntry; pEntry = pEntry->hh.next) {
        sortedKeys[pos++] = pEntry->key;
    }
    qsort(sortedKeys, len, sizeof(int), cmp);
    int res[m * n]; // 存放相同数值的答案，便于后续更新 row 和 col
    for (int i = 0; i < pos; i++) {
        Element *pos = hashGetItem(&mp, sortedKeys[i], NULL);
        int k = 0;
        for (Element *p = pos; p; p = p->next) {
            int x = p->x;
            int y = p->y;
            res[k++] = fmax(row[x], col[y]) + 1;
        }
        int j = 0;
        for (Element *p = pos; p; p = p->next) {
            int x = p->x;
            int y = p->y;
            row[x] = fmax(row[x], res[j]);
            col[y] = fmax(col[y], res[j]);
            j++;
        }
    }

    int maxVal = 0;
    for (int i = 0; i < m; i++) {
        maxVal = fmax(maxVal, row[i]);
    }
    hashFree(&mp);
    return maxVal;
}
```

```JavaScript
var maxIncreasingCells = function(mat) {
    const m = mat.length;
    const n = mat[0].length;
    const mp = new Map();
    const row = new Array(m).fill(0);
    const col = new Array(n).fill(0);

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (!mp.has(mat[i][j])) {
                mp.set(mat[i][j], []);
            }
            mp.get(mat[i][j]).push([i, j]);
        }
    }
    const sortedMap = new Map([...mp.entries()].sort((a, b) => a[0] - b[0]));
    for (const [_, pos] of sortedMap) {
        const res = pos.map(([i, j]) => Math.max(row[i], col[j]) + 1); // 存放相同数值的答案，便于后续更新 row 和 col
        for (let k = 0; k < pos.length; k++) {
            const [i, j] = pos[k];
            const d = res[k];
            row[i] = Math.max(row[i], d);
            col[j] = Math.max(col[j], d);
        }
    }
    return Math.max(...row);
};
```

```TypeScript
function maxIncreasingCells(mat: number[][]): number {
    const m: number = mat.length;
    const n: number = mat[0].length;
    const mp: Map<number, [number, number][]> = new Map();
    const row: number[] = new Array(m).fill(0);
    const col: number[] = new Array(n).fill(0);

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (!mp.has(mat[i][j])) {
                mp.set(mat[i][j], []);
            }
            mp.get(mat[i][j])!.push([i, j]);
        }
    }
    const sortedMap: Map<number, [number, number][]> = new Map([...mp.entries()].sort((a, b) => a[0] - b[0]));
    for (const [_, pos] of sortedMap) {
        const res: number[] = pos.map(([i, j]) => Math.max(row[i], col[j]) + 1); // 存放相同数值的答案，便于后续更新 row 和 col
        for (let k = 0; k < pos.length; k++) {
            const [i, j] = pos[k];
            const d = res[k];
            row[i] = Math.max(row[i], d);
            col[j] = Math.max(col[j], d);
        }
    }
    return Math.max(...row);
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn max_increasing_cells(mat: Vec<Vec<i32>>) -> i32 {
        let m = mat.len();
        let n = mat[0].len();
        let mut mp: HashMap<i32, Vec<(usize, usize)>> = HashMap::new();
        let mut row = vec![0; m];
        let mut col = vec![0; n];

        for i in 0..m {
            for j in 0..n {
                mp.entry(mat[i][j]).or_insert(Vec::new()).push((i, j));
            }
        }
        let mut sorted_map: Vec<_> = mp.iter().collect();
        sorted_map.sort_by(|a, b| a.0.cmp(b.0));
        for (_, pos) in sorted_map {
            let res: Vec<_> = pos.iter().map(|&(i, j)| row[i].max(col[j]) + 1).collect(); // 存放相同数值的答案，便于后续更新 row 和 col
            for (&(i, j), &d) in pos.iter().zip(res.iter()) {
                row[i] = row[i].max(d);
                col[j] = col[j].max(d);
            }
        }
        *row.iter().max().unwrap()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn\log (mn))$，其中 $m$ 是 $\textit{mat}$ 的行数，$n$ 是 $\textit{mat}$ 的列数。从小到大进行状态转移之前，需要对 $\textit{mat}$ 进行排序，这部分时间复杂度为 $O(mn\log (mn))$。每个状态转移的时间复杂度为 $O(1)$，所有状态转移的时间复杂度为 $O(mn)$。因此总体时间复杂度为 $O(mn\log (mn))$。
- 空间复杂度：$O(mn)$。
