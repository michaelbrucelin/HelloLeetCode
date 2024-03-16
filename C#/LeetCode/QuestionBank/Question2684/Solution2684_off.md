### [矩阵中移动的最大次数](https://leetcode.cn/problems/maximum-number-of-moves-in-a-grid/solutions/2684036/ju-zhen-zhong-yi-dong-de-zui-da-ci-shu-b-b7jx/)

#### 方法一：广度优先搜索

##### 思路与算法

我们首先把所有行坐标加入到集合中，作为出发点。然后对其依次遍历，对每一个单元格，找到下一个列的相邻单元格，并判断是否严格大于当前单元格。
如果是，说明可以移动到达。把所有可到达的单元格行坐标加到集合中，并用于下一轮的搜索。

当到达最后一列或者集合为空，搜索结束，返回矩阵中移动的最大次数。

##### 代码

```c++
class Solution {
public:
    int maxMoves(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        unordered_set<int> q, q2;
        for (int i = 0; i < m; i++) {
            q.insert(i);
        }
        for (int j = 1; j < n; j++) {
            q2.clear();
            for (int i : q) {
                for (int i2 = i - 1; i2 <= i + 1; i2++) {
                    if (0 <= i2 && i2 < m && grid[i][j - 1] < grid[i2][j]) {
                        q2.insert(i2);
                    }
                }
            }
            swap(q, q2);
            if (q.empty()) {
                return j - 1;
            }
        }
        return n - 1;
    }
};
```

```java
class Solution {
    public int maxMoves(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        Set<Integer> q = new HashSet<>();
        for (int i = 0; i < m; i++) {
            q.add(i);
        }
        for (int j = 1; j < n; j++) {
            Set<Integer> q2 = new HashSet<>();
            for (int i : q) {
                for (int i2 = i - 1; i2 <= i + 1; i2++) {
                    if (0 <= i2 && i2 < m && grid[i][j - 1] < grid[i2][j]) {
                        q2.add(i2);
                    }
                }
            }
            q = q2;
            if (q.isEmpty()) {
                return j - 1;
            }
        }
        return n - 1;
    }
}
```

```csharp
public class Solution {
    public int MaxMoves(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        ISet<int> q = new HashSet<int>();
        for (int i = 0; i < m; i++) {
            q.Add(i);
        }
        for (int j = 1; j < n; j++) {
            ISet<int> q2 = new HashSet<int>();
            foreach (int i in q) {
                for (int i2 = i - 1; i2 <= i + 1; i2++) {
                    if (0 <= i2 && i2 < m && grid[i][j - 1] < grid[i2][j]) {
                        q2.Add(i2);
                    }
                }
            }
            q = q2;
            if (q.Count == 0) {
                return j - 1;
            }
        }
        return n - 1;
    }
}
```

```python
class Solution:
    def maxMoves(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        q = set(range(m))
        for j in range(1, n):
            q2 = set()
            for i in q:
                for i2 in [i - 1, i, i + 1]:
                    if 0 <= i2 < m and grid[i][j - 1] < grid[i2][j]:
                        q2.add(i2)
            q = q2
            if not q:
                return j - 1
        return n - 1
```

```javascript
var maxMoves = function(grid) {
    const m = grid.length, n = grid[0].length;
    let q = new Set();
    for (let i = 0; i < m; i++) {
        q.add(i);
    }
    for (let j = 1; j < n; j++) {
        const q2 = new Set();
        for (const i of q) {
            for (let i2 = i - 1; i2 <= i + 1; i2++) {
                if (0 <= i2 && i2 < m && grid[i][j - 1] < grid[i2][j]) {
                    q2.add(i2);
                }
            }
        }
        q = q2;
        if (q.size === 0) {
            return j - 1;
        }
    }
    return n - 1;
};
```

```typescript
function maxMoves(grid: number[][]): number {
    const m = grid.length, n = grid[0].length;
    let q: Set<number> = new Set();
    for (let i = 0; i < m; i++) {
        q.add(i);
    }
    for (let j = 1; j < n; j++) {
        const q2: Set<number> = new Set();
        for (const i of q) {
            for (let i2 = i - 1; i2 <= i + 1; i2++) {
                if (0 <= i2 && i2 < m && grid[i][j - 1] < grid[i2][j]) {
                    q2.add(i2);
                }
            }
        }
        q = q2;
        if (q.size === 0) {
            return j - 1;
        }
    }
    return n - 1;
};
```

```rust
use std::collections::HashSet;

impl Solution {
    pub fn max_moves(grid: Vec<Vec<i32>>) -> i32 {
        let m = grid.len();
        let n = grid[0].len();
        let mut q: HashSet<usize> = HashSet::new();
        for i in 0..m {
            q.insert(i);
        }
        for j in 1..n {
            let mut q2: HashSet<usize> = HashSet::new();
            for &i in q.iter() {
                for i2 in i.saturating_sub(1)..=i + 1 {
                    if i2 < m && grid[i][j - 1] < grid[i2][j] {
                        q2.insert(i2);
                    }
                }
            }
            q = q2;
            if q.is_empty() {
                return (j - 1) as i32;
            }
        }
        (n - 1) as i32
    }
}
```

```c
typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
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

int maxMoves(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize, n = gridColSize[0];
    HashItem *q = NULL;
    for (int i = 0; i < m; i++) {
        hashAddItem(&q, i);
    }
    for (int j = 1; j < n; j++) {
        HashItem *q2 = NULL;
        for (HashItem *pEntry = q; pEntry; pEntry = pEntry->hh.next) {
            int i = pEntry->key;
            for (int i2 = i - 1; i2 <= i + 1; i2++) {
                if (0 <= i2 && i2 < m && grid[i][j - 1] < grid[i2][j]) {
                    hashAddItem(&q2, i2);
                }
            }
        }
        hashFree(&q);
        q = q2;
        if (HASH_COUNT(q) == 0) {
            return j - 1;
        }
    }
    hashFree(&q);
    return n - 1;
}
```

```go
func maxMoves(grid [][]int) int {
    m, n := len(grid), len(grid[0])
    q := make(map[int]bool)
    q2 := make(map[int]bool)

    for i := 0; i < m; i++ {
        q[i] = true
    }
    for j := 1; j < n; j++ {
        q2 = make(map[int]bool)
        for i := range q {
            for i2 := i - 1; i2 <= i+1; i2++ {
                if 0 <= i2 && i2 < m && grid[i][j-1] < grid[i2][j] {
                    q2[i2] = true
                }
            }
        }
        q = q2
        if len(q) == 0 {
            return j - 1
        }
    }
    return n - 1
}
```

##### 复杂度分析

- 时间复杂度：$O(mn)$，其中 $m$ 是行数，$n$ 是列数。
- 空间复杂度：$O(n)$，其中 $n$ 是列数。
