### [找到矩阵中的好子集](https://leetcode.cn/problems/find-a-good-subset-of-the-matrix/solutions/2817195/zhao-dao-ju-zhen-zhong-de-hao-zi-ji-by-l-qldc/)

#### 方法一：分类讨论

**思路**

对所选出来的行数进行分类讨论，有以下几种情况：

- 假设答案至少一行，那么需要这一行满足全为 $0$。
- 假设答案至少两行，那么不存在一列这两行都是 $1$。分别用 $x$ 和 $y$ 表示这两行所表示的数，能推出至少存在两行 $x \& y == 0$。
- 假设答案至少三行，那么这三行每一列加起来的和不超过 $1$。这个条件比两行的情况更严格，如果两行都找不到答案，那么一定没有三行的情况了。
- 假设答案至少四行，那么这四行每一列加起来的和不超过 $2$。如果两行找不到答案，说明任选两行至少存在一列这两行都是 $1$。同时这一列这两行已经都是 $1$ 了，那么这一列的其他两行必须是 $0$ 才满足条件。所以，当答案有四行的情况下，需要满足任选两行这一列都是 $1$ 同时其他两行必须是 $0$ 至少需要 $C\_4^2 = 6$ 列，但题意说矩阵的列数 $n <= 5$，因此这种情况不存在。
- 一般的，对于任意一行，假设答案至少需要选取 $k$ 行。考虑任选两行至少存在一列这两行都是 $1$ 的构造，一共需要 $k-1$ 对构造，当这一列选择了 $1$ 后，其他 $k-1$ 行最多有 $\frac {k} {2} - 1$ 个 $1$，所以最多能贡献 $\frac {k} {2} - 1$ 个构造。因为 $\frac{k-1} {\frac{k} {2} - 1} > 2$， 所以这一行至少需要 $3$ 个 $1$ 才能达到 $k-1$ 个构造，同时因为列数不超过 $5$，所以至多有 $2$ 列是 $0$。因此任意一行 $1$ 的个数比 $0$ 更多，进而推出任选 $k$ 行，$1$ 的总数比 $0$ 更多，无法找到一个合法的构造满足题意。

综上所述，只需要考虑答案小于等于两行的情况。每行二进制所表示的数一共有 $2^n$ 种情况，其中 $n$ 为矩阵的列数。

**代码**

```C++
class Solution {
public:
    vector<int> goodSubsetofBinaryMatrix(vector<vector<int>>& grid) {
        vector<int> ans;
        unordered_map<int, int> mp;
        int m = grid.size();
        int n = grid[0].size();

        for (int j = 0; j < m; j++) {
            int st = 0;
            for (int i = 0; i < n; i++) {
                st |= (grid[j][i] << i);
            }
            mp[st] = j;
        }

        if (mp.count(0)) {
            ans.push_back(mp[0]);
            return ans;
        }

        for (auto [x, i]: mp) {
            for (auto [y, j]: mp) {
                if (!(x & y)) {
                    return {min(i, j), max(i, j)};
                }
            }
        }

        return ans;
    }
};
```

```Java
class Solution {
    public List<Integer> goodSubsetofBinaryMatrix(int[][] grid) {
        List<Integer> ans = new ArrayList<Integer>();
        Map<Integer, Integer> mp = new HashMap<Integer, Integer>();
        int m = grid.length;
        int n = grid[0].length;

        for (int j = 0; j < m; j++) {
            int st = 0;
            for (int i = 0; i < n; i++) {
                st |= (grid[j][i] << i);
            }
            mp.put(st, j);
        }

        if (mp.containsKey(0)) {
            ans.add(mp.get(0));
            return ans;
        }

        for (Map.Entry<Integer, Integer> entry1 : mp.entrySet()) {
            int x = entry1.getKey(), i = entry1.getValue();
            for (Map.Entry<Integer, Integer> entry2 : mp.entrySet()) {
                int y = entry2.getKey(), j = entry2.getValue();
                if ((x & y) == 0) {
                    List<Integer> list = new ArrayList<Integer>();
                    list.add(Math.min(i, j));
                    list.add(Math.max(i, j));
                    return list;
                }
            }
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public IList<int> GoodSubsetofBinaryMatrix(int[][] grid) {
        IList<int> ans = new List<int>();
        IDictionary<int, int> dic = new Dictionary<int, int>();
        int m = grid.Length;
        int n = grid[0].Length;

        for (int j = 0; j < m; j++) {
            int st = 0;
            for (int i = 0; i < n; i++) {
                st |= (grid[j][i] << i);
            }
            if (!dic.ContainsKey(st)) {
                dic.Add(st, j);
            } else {
                dic[st] = j;
            }
        }

        if (dic.ContainsKey(0)) {
            ans.Add(dic[0]);
            return ans;
        }

        foreach (KeyValuePair<int, int> pair1 in dic) {
            int x = pair1.Key, i = pair1.Value;
            foreach (KeyValuePair<int, int> pair2 in dic) {
                int y = pair2.Key, j = pair2.Value;
                if ((x & y) == 0) {
                    IList<int> list = new List<int>();
                    list.Add(Math.Min(i, j));
                    list.Add(Math.Max(i, j));
                    return list;
                }
            }
        }

        return ans;
    }
}
```

```Go
func goodSubsetofBinaryMatrix(grid [][]int) []int {
    ans := []int{}
    mp := make(map[int]int)
    m := len(grid)
    n := len(grid[0])
    for j := 0; j < m; j++ {
        st := 0
        for i := 0; i < n; i++ {
            st |= (grid[j][i] << i)
        }
        mp[st] = j
    }
    if _, ok := mp[0]; ok {
        ans = append(ans, mp[0])
        return ans
    }
    for x, i := range mp {
        for y, j := range mp {
            if x & y == 0 {
                return []int{min(i, j), max(i, j)}
            }
        }
    }
    return ans
}
```

```C
typedef struct {
    int key;
    int val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetItem(HashItem **obj, int key, int defaultVal) {
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
        free(curr);
    }
}

int* goodSubsetofBinaryMatrix(int** grid, int gridSize, int* gridColSize, int* returnSize) {
    int* ans = NULL;
    HashItem *mp = NULL;
    int m = gridSize;
    int n = gridColSize[0];

    for (int j = 0; j < m; j++) {
        int st = 0;
        for (int i = 0; i < n; i++) {
            st |= (grid[j][i] << i);
        }
        hashAddItem(&mp, st, j);
    }
    if (hashFindItem(&mp, 0)) {
        ans = (int *)malloc(sizeof(int));
        ans[0] = hashGetItem(&mp, 0, 0);
        *returnSize = 1;
        hashFree(&mp);
        return ans;
    }

    for (HashItem *pEntry1 = mp; pEntry1 != NULL; pEntry1 = pEntry1->hh.next) {
        int x = pEntry1->key, i = pEntry1->val;
        for (HashItem *pEntry2 = mp; pEntry2 != NULL; pEntry2 = pEntry2->hh.next) {
            int y = pEntry2->key, j = pEntry2->val;
            if (!(x & y)) {
                ans = (int *)malloc(sizeof(int) * 2);
                ans[0] = fmin(i, j);
                ans[1] = fmax(i, j);
                *returnSize = 2;
                hashFree(&mp);
                return ans;
            }
        }
    }
    *returnSize = 0;
    hashFree(&mp);
    return ans;
}
```

```Python
class Solution:
    def goodSubsetofBinaryMatrix(self, grid: List[List[int]]) -> List[int]:
        ans = []
        mp = {}
        m = len(grid)
        n = len(grid[0])

        for j in range(m):
            st = 0
            for i in range(n):
                st |= (grid[j][i] << i)
            mp[st] = j
        if 0 in mp:
            ans.append(mp[0])
            return ans
        for x, i in mp.items():
            for y, j in mp.items():
                if not (x & y):
                    return [min(i, j), max(i, j)]
        return ans
```

```JavaScript
var goodSubsetofBinaryMatrix = function(grid) {
    let ans = [];
    let mp = new Map();
    let m = grid.length;
    let n = grid[0].length;
    for (let j = 0; j < m; j++) {
        let st = 0;
        for (let i = 0; i < n; i++) {
            st |= (grid[j][i] << i);
        }
        mp.set(st, j);
    }

    if (mp.has(0)) {
        ans.push(mp.get(0));
        return ans;
    }

    for (let [x, i] of mp.entries()) {
        for (let [y, j] of mp.entries()) {
            if (!(x & y)) {
                return [Math.min(i, j), Math.max(i, j)];
            }
        }
    }

    return ans;
};
```

```TypeScript
function goodSubsetofBinaryMatrix(grid: number[][]): number[] {
    let ans: number[] = [];
    let mp: Map<number, number> = new Map();
    let m: number = grid.length;
    let n: number = grid[0].length;
    for (let j = 0; j < m; j++) {
        let st: number = 0;
        for (let i = 0; i < n; i++) {
            st |= (grid[j][i] << i);
        }
        mp.set(st, j);
    }

    if (mp.has(0)) {
        ans.push(mp.get(0)!);
        return ans;
    }

    for (let [x, i] of mp) {
        for (let [y, j] of mp) {
            if (!(x & y)) {
                return [Math.min(i, j), Math.max(i, j)];
            }
        }
    }

    return ans;
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn good_subsetof_binary_matrix(grid: Vec<Vec<i32>>) -> Vec<i32> {
        let mut ans: Vec<i32> = vec![];
        let mut mp: HashMap<i32, i32> = HashMap::new();
        let m = grid.len();
        let n = grid[0].len();

        for j in 0..m {
            let mut st = 0;
            for i in 0..n {
                st |= grid[j][i] << i;
            }
            mp.insert(st, j as i32);
        }
        if mp.contains_key(&0) {
            ans.push(*mp.get(&0).unwrap());
            return ans;
        }
        for (&x, &i) in &mp {
            for (&y, &j) in &mp {
                if x & y == 0 {
                    return vec![i.min(j), i.max(j)];
                }
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nm + C^2)$，其中 $m$ 为矩阵的行数，$n$ 为矩阵的列数，$C = 2^n$ 表示每一行所表示数的范围。
- 空间复杂度：$O(2^n)$，其中 $n$ 为矩阵的列数。
