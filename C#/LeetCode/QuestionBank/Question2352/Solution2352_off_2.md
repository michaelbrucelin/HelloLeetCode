#### [方法二：哈希表](https://leetcode.cn/problems/equal-row-and-column-pairs/solutions/2293933/xiang-deng-xing-lie-dui-by-leetcode-solu-gvcg/)

**思路**

首先将矩阵的行放入哈希表中统计次数，哈希表的键可以是将行拼接后的字符串，也可以用各语言内置的数据结构，然后分别统计每一列相等的行有多少，求和即可。

**代码**

```python
class Solution:
    def equalPairs(self, grid: List[List[int]]) -> int:
        res, n = 0, len(grid)
        cnt = Counter(tuple(row) for row in grid)
        res = 0
        for j in range(n):
            res += cnt[tuple([grid[i][j] for i in range(n)])]
        return res
```

```cpp
class Solution {
public:
    int equalPairs(vector<vector<int>>& grid) {
        int n = grid.size();
        map<vector<int>, int> cnt;
        for (auto row : grid) {
            cnt[row]++;
        }

        int res = 0;
        for (int j = 0; j < n; j++) {
            vector<int> arr;
            for (int i = 0; i < n; i++) {
                arr.emplace_back(grid[i][j]);
            }
            if (cnt.find(arr) != cnt.end()) {
                res += cnt[arr];
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int equalPairs(int[][] grid) {
        int n = grid.length;
        Map<List<Integer>, Integer> cnt = new HashMap<List<Integer>, Integer>();
        for (int[] row : grid) {
            List<Integer> arr = new ArrayList<Integer>();
            for (int num : row) {
                arr.add(num);
            }
            cnt.put(arr, cnt.getOrDefault(arr, 0) + 1);
        }

        int res = 0;
        for (int j = 0; j < n; j++) {
            List<Integer> arr = new ArrayList<Integer>();
            for (int i = 0; i < n; i++) {
                arr.add(grid[i][j]);
            }
            if (cnt.containsKey(arr)) {
                res += cnt.get(arr);
            }
        }
        return res;
    }
}
```

```go
func equalPairs(grid [][]int) int {
    n := len(grid)
    cnt := make(map[string]int)
    for _, row := range grid {
        cnt[fmt.Sprint(row)]++
    }
    res := 0
    for j := 0; j < n; j++ {
        var arr []int
        for i := 0; i < n; i++ {
            arr = append(arr, grid[i][j])
        }
        if val, ok := cnt[fmt.Sprint(arr)]; ok {
            res += val
        }
    }

    return res
}
```

```javascript
var equalPairs = function(grid) {
    const n = grid.length;
    const cnt = {};

    for (const row of grid) {
        const rowStr = row.toString();
        cnt[rowStr] = (cnt[rowStr] || 0) + 1;
    }

    let res = 0;
    for (let j = 0; j < n; j++) {
        const arr = [];
        for (let i = 0; i < n; i++) {
            arr.push(grid[i][j]);
        }
        const arrStr = arr.toString();
        if (cnt[arrStr]) {
            res += cnt[arrStr];
        }
    }

    return res;
};
```

```c
typedef struct {
    long long key;
    int val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, long long key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, long long key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, long long key, int val) {
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

const long long base = 1000003;
const long long mod = 1e9 + 7;

int equalPairs(int** grid, int gridSize, int* gridColSize) {
    int n = gridSize;
    HashItem *cnt = NULL;
    for (int i = 0; i < n; i++) {
        long long key = 0;
        for (int j = 0; j < n; j++) {
            key = (key * base + grid[i][j]) % mod;
        }
        hashSetItem(&cnt, key, hashGetItem(&cnt, key, 0) + 1);
    }

    int res = 0;
    for (int j = 0; j < n; j++) {
        long long key = 0;
        for (int i = 0; i < n; i++) {
            key = (key * base + grid[i][j]) % mod;
        }
        res += hashGetItem(&cnt, key, 0);
    }
    hashFree(&cnt);
    return res;
}
```

**复杂度分析**

-   时间复杂度：$O(n^2)$，将行放入哈希表中消耗 $O(n^2)$，读所有列的哈希表中的次数也消耗 $O(n^2)$。
-   空间复杂度：$O(n^2)$，哈希表的空间复杂度为 $O(n^2)$。
