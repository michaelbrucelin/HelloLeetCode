### [可以攻击国王的皇后](https://leetcode.cn/problems/queens-that-can-attack-the-king/solutions/2436786/ke-yi-gong-ji-guo-wang-de-huang-hou-by-l-dbm7/?envType=daily-question&envId=2023-09-14)

#### 方法一：从国王出发

**思路与算法**

我们可以依次枚举八个方向，并从国王出发，其遇到的第一个皇后就可以攻击到它。

记国王的位置为 $(k_x, k_y)$，枚举的方向为 $(d_x, d_y)$，那么我们不断地将 $k_x$ 加上 $d_x$，将 $k_y$ 加上 $d_y$，直到遇到皇后或者走出边界位置。为了记录皇后的位置，我们可以使用一个 $8 \times 8$ 的二维数组，也可以使用一个哈希表，这样就可以在 $O(1)$ 的时间内判断某一个位置是否有皇后。

**代码**

```cpp
class Solution {
public:
    vector<vector<int>> queensAttacktheKing(vector<vector<int>>& queens, vector<int>& king) {
        unordered_set<int> queen_pos;
        for (const auto& queen: queens) {
            int x = queen[0], y = queen[1];
            queen_pos.insert(x * 8 + y);
        }

        vector<vector<int>> ans;
        for (int dx = -1; dx <= 1; ++dx) {
            for (int dy = -1; dy <= 1; ++dy) {
                if (dx == 0 && dy == 0) {
                    continue;
                }
                int kx = king[0] + dx, ky = king[1] + dy;
                while (kx >= 0 && kx < 8 && ky >= 0 && ky < 8) {
                    int pos = kx * 8 + ky;
                    if (queen_pos.count(pos)) {
                        ans.push_back({kx, ky});
                        break;
                    }
                    kx += dx;
                    ky += dy;
                }
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public List<List<Integer>> queensAttacktheKing(int[][] queens, int[] king) {
        Set<Integer> queenPos = new HashSet<Integer>();
        for (int[] queen : queens) {
            int x = queen[0], y = queen[1];
            queenPos.add(x * 8 + y);
        }

        List<List<Integer>> ans = new ArrayList<List<Integer>>();
        for (int dx = -1; dx <= 1; ++dx) {
            for (int dy = -1; dy <= 1; ++dy) {
                if (dx == 0 && dy == 0) {
                    continue;
                }
                int kx = king[0] + dx, ky = king[1] + dy;
                while (kx >= 0 && kx < 8 && ky >= 0 && ky < 8) {
                    int pos = kx * 8 + ky;
                    if (queenPos.contains(pos)) {
                        List<Integer> posList = new ArrayList<Integer>();
                        posList.add(kx);
                        posList.add(ky);
                        ans.add(posList);
                        break;
                    }
                    kx += dx;
                    ky += dy;
                }
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king) {
        ISet<int> queenPos = new HashSet<int>();
        foreach (int[] queen in queens) {
            int x = queen[0], y = queen[1];
            queenPos.Add(x * 8 + y);
        }

        IList<IList<int>> ans = new List<IList<int>>();
        for (int dx = -1; dx <= 1; ++dx) {
            for (int dy = -1; dy <= 1; ++dy) {
                if (dx == 0 && dy == 0) {
                    continue;
                }
                int kx = king[0] + dx, ky = king[1] + dy;
                while (kx >= 0 && kx < 8 && ky >= 0 && ky < 8) {
                    int pos = kx * 8 + ky;
                    if (queenPos.Contains(pos)) {
                        IList<int> posList = new List<int>();
                        posList.Add(kx);
                        posList.Add(ky);
                        ans.Add(posList);
                        break;
                    }
                    kx += dx;
                    ky += dy;
                }
            }
        }
        return ans;
    }
}
```

```python
class Solution:
    def queensAttacktheKing(self, queens: List[List[int]], king: List[int]) -> List[List[int]]:
        queen_pos = set((x, y) for x, y in queens)

        ans = list()
        for dx in [-1, 0, 1]:
            for dy in [-1, 0, 1]:
                if dx == dy == 0:
                    continue
                
                kx, ky = king[0] + dx, king[1] + dy
                while 0 <= kx < 8 and 0 <= ky < 8:
                    if (kx, ky) in queen_pos:
                        ans.append([kx, ky])
                        break
                    kx += dx
                    ky += dy
        
        return ans
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

int** queensAttacktheKing(int** queens, int queensSize, int* queensColSize, int* king, int kingSize, int* returnSize, int** returnColumnSizes) {
    HashItem *queen_pos = NULL;
    for (int i = 0; i < queensSize; i++) {
        int x = queens[i][0], y = queens[i][1];
        hashAddItem(&queen_pos, x * 8 + y);
    }

    int **ans = (int **)malloc(sizeof(int *) * queensSize);
    int curr_pos = 0;
    for (int dx = -1; dx <= 1; ++dx) {
        for (int dy = -1; dy <= 1; ++dy) {
            if (dx == 0 && dy == 0) {
                continue;
            }
            int kx = king[0] + dx, ky = king[1] + dy;
            while (kx >= 0 && kx < 8 && ky >= 0 && ky < 8) {
                int pos = kx * 8 + ky;
                if (hashFindItem(&queen_pos, pos)) {
                    ans[curr_pos] = (int *)malloc(sizeof(int) * 2);
                    ans[curr_pos][0] = kx;
                    ans[curr_pos][1] = ky;
                    curr_pos++;
                    break;
                }
                kx += dx;
                ky += dy;
            }
        }
    }
    *returnColumnSizes = (int *)malloc(sizeof(int) * curr_pos);
    for (int i = 0; i < curr_pos; i++) {
        (*returnColumnSizes)[i] = 2;
    }
    *returnSize = curr_pos;
    hashFree(&queen_pos);
    return ans;
}
```

```go
func queensAttacktheKing(queens [][]int, king []int) [][]int {
    queen_pos := make(map[int]bool)
    for _, queen := range queens {
        x, y := queen[0], queen[1]
        queen_pos[x * 8 + y] = true
    }
        
    ans := [][]int{}
    for dx := -1; dx <= 1; dx++ {
        for dy := -1; dy <= 1; dy++ {
            if dx == 0 && dy == 0 {
                continue
            }
            kx, ky := king[0] + dx, king[1] + dy
            for kx >= 0 && kx < 8 && ky >= 0 && ky < 8 {
                pos := kx * 8 + ky
                if _, ok := queen_pos[pos]; ok {
                    ans = append(ans, []int{kx, ky})
                    break
                }
                kx += dx
                ky += dy
            }
        }
    }
    return ans
}
```

```javascript
var queensAttacktheKing = function(queens, king) {
    queen_pos = new Set();
    for (const queen of queens) {
        let x = queen[0], y = queen[1];
        queen_pos.add(x * 8 + y);
    }

    const ans = [];
    for (let dx = -1; dx <= 1; ++dx) {
        for (let dy = -1; dy <= 1; ++dy) {
            if (dx == 0 && dy == 0) {
                continue;
            }
            let kx = king[0] + dx, ky = king[1] + dy;
            while (kx >= 0 && kx < 8 && ky >= 0 && ky < 8) {
                let pos = kx * 8 + ky;
                if (queen_pos.has(pos)) {
                    ans.push([kx, ky]);
                    break;
                }
                kx += dx;
                ky += dy;
            }
        }
    }
    return ans;
};
```

**复杂度分析**

-   时间复杂度：$O(n + C)$，其中 $n$ 是数组 $queens$ 的长度，$C$ 是棋盘的大小，在本题中 $C = 8$。我们需要 $O(n)$ 的时间将所有皇后放入哈希表中，后续的枚举部分一共有 $8$ 个方向，每两个对称的方向最多会遍历 $C$ 个位置，因此一共最多遍历 $4C = O(C)$ 个位置。
-   空间复杂度：$O(n)$，即为哈希表需要使用的空间。

#### 方法二：从皇后出发

**思路与算法**

我们枚举每个皇后，判断它是否在国王的八个方向上。如果在，说明皇后可以攻击到国王。

记国王的位置为 $(k_x, k_y)$，皇后的位置为 $(q_x, q_y)$，那么皇后相对于国王的位置为 $(x, y) = (q_x - k_x, q_y - k_y)$，显然当 $x = 0$ 或 $y = 0$ 或 $|x| = |y|$ 时，皇后可以攻击到国王，方向为 $(sgn(x), sgn(y))$，其中 $sgn(x)$ 为符号函数，当 $x > 0$ 时为 $1$，$x < 0$ 时为 $-1$，$x = 0$ 时为 $0$。

同一个方向的皇后可能有多个，我们需要选择距离国王最近的那一个，因此可以使用一个哈希映射，它的键表示某一个方向，值是一个二元组，分别表示当前距离最近的皇后以及对应的距离。当我们枚举到一个新的皇后时，如果它在国王的八个方向上，就与哈希映射中对应的值比较一下大小关系即可。

当枚举完所有皇后，我们就可以从哈希映射值的部分中得到答案。

**代码**

```cpp
class Solution {
public:
    vector<vector<int>> queensAttacktheKing(vector<vector<int>>& queens, vector<int>& king) {
        auto sgn = [](int x) -> int{
            return x > 0 ? 1 : (x == 0 ? 0 : -1);
        };

        unordered_map<int, pair<vector<int>, int>> candidates;
        int kx = king[0], ky = king[1];
        for (const auto& queen: queens) {
            int qx = queen[0], qy = queen[1];
            int x = qx - kx, y = qy - ky;
            if (x == 0 || y == 0 || abs(x) == abs(y)) {
                int dx = sgn(x), dy = sgn(y);
                int key = dx * 10 + dy;
                if (!candidates.count(key) || candidates[key].second > abs(x) + abs(y)) {
                    candidates[key] = {queen, abs(x) + abs(y)};
                }
            }
        }

        vector<vector<int>> ans;
        for (const auto& [_, value]: candidates) {
            ans.push_back(value.first);
        }
        return ans;
    }
};
```

```java
class Solution {
    public List<List<Integer>> queensAttacktheKing(int[][] queens, int[] king) {
        Map<Integer, int[]> candidates = new HashMap<Integer, int[]>();
        int kx = king[0], ky = king[1];
        for (int[] queen : queens) {
            int qx = queen[0], qy = queen[1];
            int x = qx - kx, y = qy - ky;
            if (x == 0 || y == 0 || Math.abs(x) == Math.abs(y)) {
                int dx = sgn(x), dy = sgn(y);
                int key = dx * 10 + dy;
                if (!candidates.containsKey(key) || candidates.get(key)[2] > Math.abs(x) + Math.abs(y)) {
                    candidates.put(key, new int[]{queen[0], queen[1], Math.abs(x) + Math.abs(y)});
                }
            }
        }

        List<List<Integer>> ans = new ArrayList<List<Integer>>();
        for (Map.Entry<Integer, int[]> entry : candidates.entrySet()) {
            int[] value = entry.getValue();
            List<Integer> posList = new ArrayList<Integer>();
            posList.add(value[0]);
            posList.add(value[1]);
            ans.add(posList);
        }
        return ans;
    }

    public int sgn(int x) {
        return x > 0 ? 1 : (x == 0 ? 0 : -1);
    }
}
```

```csharp
public class Solution {
    public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king) {
        IDictionary<int, int[]> candidates = new Dictionary<int, int[]>();
        int kx = king[0], ky = king[1];
        foreach (int[] queen in queens) {
            int qx = queen[0], qy = queen[1];
            int x = qx - kx, y = qy - ky;
            if (x == 0 || y == 0 || Math.Abs(x) == Math.Abs(y)) {
                int dx = Sgn(x), dy = Sgn(y);
                int key = dx * 10 + dy;
                if (!candidates.ContainsKey(key)) {
                    candidates.Add(key, new int[]{queen[0], queen[1], Math.Abs(x) + Math.Abs(y)});
                } else if (candidates[key][2] > Math.Abs(x) + Math.Abs(y)) {
                    candidates[key] = new int[]{queen[0], queen[1], Math.Abs(x) + Math.Abs(y)};
                }
            }
        }

        IList<IList<int>> ans = new List<IList<int>>();
        foreach (KeyValuePair<int, int[]> pair in candidates) {
            int[] value = pair.Value;
            IList<int> posList = new List<int>();
            posList.Add(value[0]);
            posList.Add(value[1]);
            ans.Add(posList);
        }
        return ans;
    }

    public int Sgn(int x) {
        return x > 0 ? 1 : (x == 0 ? 0 : -1);
    }
}
```

```python
class Solution:
    def queensAttacktheKing(self, queens: List[List[int]], king: List[int]) -> List[List[int]]:
        def sgn(x: int) -> int:
            return 1 if x > 0 else (0 if x == 0 else -1)
        
        candidates = defaultdict(lambda: (None, inf))
        kx, ky = king

        for qx, qy in queens:
            x, y = qx - kx, qy - ky
            if x == 0 or y == 0 or abs(x) == abs(y):
                dx, dy = sgn(x), sgn(y)
                if candidates[(dx, dy)][1] > abs(x) + abs(y):
                    candidates[(dx, dy)] = ([qx, qy], abs(x) + abs(y))
        
        ans = [value[0] for value in candidates.values()]
        return ans
```

```c
typedef struct {
    int key;
    int val[3];
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int *arr) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    memcpy(pEntry->val, arr, sizeof(pEntry->val));
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, int key, int *arr) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, arr);
    } else {
        memcpy(pEntry->val, arr, sizeof(pEntry->val));
    }
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

static inline int sgn(int x) {
    return x > 0 ? 1 : (x == 0 ? 0 : -1); 
}

int** queensAttacktheKing(int** queens, int queensSize, int* queensColSize, int* king, int kingSize, int* returnSize, int** returnColumnSizes) {
    HashItem *candidates = NULL;
    int kx = king[0], ky = king[1];
    for (int i = 0; i < queensSize; i++) {
        int qx = queens[i][0], qy = queens[i][1];
        int x = qx - kx, y = qy - ky;
        if (x == 0 || y == 0 || abs(x) == abs(y)) {
            int dx = sgn(x), dy = sgn(y);
            int key = dx * 10 + dy;
            HashItem *pEntry = hashFindItem(&candidates, key);
            if (!pEntry || pEntry->val[2] > abs(x) + abs(y)) {
                int val[3] = {qx, qy, abs(x) + abs(y)};
                hashSetItem(&candidates, key, val);
            }
        }
    }

    int **ans = (int **)malloc(sizeof(int *) * queensSize);
    int pos = 0;
    for (HashItem *pEntry = candidates; pEntry; pEntry = pEntry->hh.next) {
        ans[pos] = (int *)malloc(sizeof(int) * 2);
        ans[pos][0] = pEntry->val[0];
        ans[pos][1] = pEntry->val[1];
        pos++;
    }
    *returnColumnSizes = (int *)malloc(sizeof(int) * pos);
    for (int i = 0; i < pos; i++) {
        (*returnColumnSizes)[i] = 2;
    }
    *returnSize = pos;
    hashFree(&candidates);
    return ans;
}
```

```go
func queensAttacktheKing(queens [][]int, king []int) [][]int {
    var sgn = func(x int) int {
        if x > 0 {
            return 1
        } else if x == 0 {
            return 0
        } else {
            return -1
        }
    }

    var abs = func(x int) int {
        if x < 0 {
            return -x
        }
        return x
    }

    candidates := make(map[int][]int)
    kx, ky := king[0], king[1]
    for _, queen := range queens {
        qx, qy := queen[0], queen[1]
        x, y := qx - kx, qy - ky
        if x == 0 || y == 0 || abs(x) == abs(y) {
            dx, dy := sgn(x), sgn(y)
            key := dx * 10 + dy
            if val, ok := candidates[key]; !ok || val[2] > abs(x) + abs(y) {
                candidates[key] = []int{qx, qy, abs(x) + abs(y)}
            }
        }
    }

    ans := [][]int{}
    for _, value := range candidates {
        ans = append(ans, []int{value[0], value[1]})
    }
    return ans
}
```

```javascript
var queensAttacktheKing = function(queens, king) {
    const sgn = function(x) {
        return x > 0 ? 1 : (x == 0 ? 0 : -1);
    }

    const candidates = new Map();
    const kx = king[0], ky = king[1];
    for (const queen of queens) {
        let qx = queen[0], qy = queen[1];
        let x = qx - kx, y = qy - ky;
        if (x == 0 || y == 0 || Math.abs(x) == Math.abs(y)) {
            let dx = sgn(x), dy = sgn(y);
            const key = dx * 10 + dy;
            if (!candidates.has(key) || candidates.get(key)[2] > Math.abs(x) + Math.abs(y)) {
                candidates.set(key, [qx, qy, Math.abs(x) + Math.abs(y)]);
            }
        }
    }

    const ans = [];
    for (let value of candidates.values()) {
        ans.push([value[0], value[1]]);
    }
    return ans;
};
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是数组 $queens$ 的长度。
-   空间复杂度：$O(1)$。
