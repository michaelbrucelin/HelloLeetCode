### [参加考试的最大学生数](https://leetcode.cn/problems/maximum-students-taking-exam/solutions/101748/can-jia-kao-shi-de-zui-da-xue-sheng-shu-by-leetcod/?envType=daily-question&envId=2023-12-26)

#### 方法一：记忆化搜索 + 状态压缩

##### 思路

学生在选择座位时，必须满足四个指定的位置都没有人坐，而这四个位置，要不位于当前排，要不位于前一排。因此，某一排的座位上，学生可以选择的座位取决于上一排的落座情况。这提醒我们可以以排为单位来进行动态规划。同时，每一个座位，学生可以选择坐或者不坐，我们可以用一个长为 $n$ 的二进制数字来表示某一排的落座情况，从低到高的第 $j$ 位，如果为 $1$ 则表示这一排的第 $j$ 个位置有人落座，为 $0$ 则表示无人落座。

构造函数 $dp(row, status)$，用来表示当第 $row$ 排学生落座情况为 $status$ 时，第 $row$ 排及其之前所有座位能够容纳最多的学生数。首先判断第 $row$ 排的落座情况是否可能为 $status$ 时，我们可以构造一个函数 $isSingleRowCompliant$ 来辅助判断，主要是判断是否有学生坐了坏的位置和是否有两个学生挨着坐。如果第 $row$ 排的落座情况不可能为 $status$，返回一个极小的负值。接下来需要对前一排的落座情况进行遍历，即求出所有的 $dp(row-1, upperRowStatus)$，并且在这相邻两排的落座情况不会产生作弊的情况下，求出最大的学生数后进行返回。

最后我们调用 $dp$，求出最后一排所有状态下的最大学生数量。因为求解过程中会多次求解同一个状态，所以对动态规划进行记忆化的处理来降低时间复杂度。

##### 代码

```python
class Solution:
    def maxStudents(self, seats: List[List[str]]) -> int:

        def isSingleRowCompliant(status: int, row: int) -> bool:
            for j in range(n):
                if ((status >> j) & 1) == 1:
                    if seats[row][j] == '#':
                        return False
                    if j > 0 and ((status >> (j - 1)) & 1) == 1:
                        return False
            return True

        def isCrossRowsCompliant(status: int, upperRowStatus: int) -> bool:
            for j in range(n):
                if ((status >> j) & 1) == 1:
                    if j > 0 and ((upperRowStatus >> (j - 1)) & 1) == 1:
                        return False
                    if j < n - 1 and ((upperRowStatus >> (j + 1)) & 1) == 1:
                        return False
            return True

        @cache
        def dp(row: int, status: int) -> int:
            if not isSingleRowCompliant(status, row):
                return -inf
            students = bin(status).count('1')
            if row == 0:
                return students
            mx = 0
            for upperRowStatus in range(2 ** n):
                if isCrossRowsCompliant(status, upperRowStatus):
                    mx = max(mx, dp(row - 1, upperRowStatus))
            return students + mx

        m, n = len(seats), len(seats[0])
        mx = 0
        for i in range(2 ** n):
            mx = max(mx, dp(m - 1, i))
        return mx
```

```java
class Solution {
    Map<Integer, Integer> memo = new HashMap<Integer, Integer>();

    public int maxStudents(char[][] seats) {
        int m = seats.length, n = seats[0].length;
        int mx = 0;
        for (int i = 0; i < 1 << n; i++) {
            mx = Math.max(mx, dp(seats, m - 1, i));
        }
        return mx;
    }

    public int dp(char[][] seats, int row, int status) {
        int n = seats[0].length;
        int key = (row << n) + status;
        if (!memo.containsKey(key)) {
            if (!isSingleRowCompliant(seats, status, n, row)) {
                memo.put(key, Integer.MIN_VALUE);
                return Integer.MIN_VALUE;
            }
            int students = Integer.bitCount(status);
            if (row == 0) {
                memo.put(key, students);
                return students;
            }
            int mx = 0;
            for (int upperRowStatus = 0; upperRowStatus < 1 << n; upperRowStatus++) {
                if (isCrossRowsCompliant(status, upperRowStatus, n)) {
                    mx = Math.max(mx, dp(seats, row - 1, upperRowStatus));
                }
            }
            memo.put(key, students + mx);
        }
        return memo.get(key);
    }

    public boolean isSingleRowCompliant(char[][] seats, int status, int n, int row) {
        for (int j = 0; j < n; j++) {
            if (((status >> j) & 1) == 1) {
                if (seats[row][j] == '#') {
                    return false;
                }
                if (j > 0 && ((status >> (j - 1)) & 1) == 1) {
                    return false;
                }
            }
        }
        return true;
    }

    public boolean isCrossRowsCompliant(int status, int upperRowStatus, int n) {
        for (int j = 0; j < n; j++) {
            if (((status >> j) & 1) == 1) {
                if (j > 0 && ((upperRowStatus >> (j - 1)) & 1) == 1) {
                    return false;
                }
                if (j < n - 1 && ((upperRowStatus >> (j + 1)) & 1) == 1) {
                    return false;
                }
            }
        }
        return true;
    }
}
```

```csharp
public class Solution {
    IDictionary<int, int> memo = new Dictionary<int, int>();

    public int MaxStudents(char[][] seats) {
        int m = seats.Length, n = seats[0].Length;
        int mx = 0;
        for (int i = 0; i < 1 << n; i++) {
            mx = Math.Max(mx, DP(seats, m - 1, i));
        }
        return mx;
    }

    public int DP(char[][] seats, int row, int status) {
        int n = seats[0].Length;
        int key = (row << n) + status;
        if (!memo.ContainsKey(key)) {
            if (!IsSingleRowCompliant(seats, status, n, row)) {
                memo.Add(key, int.MinValue);
                return int.MinValue;
            }
            int students = BitCount(status);
            if (row == 0) {
                memo.Add(key, students);
                return students;
            }
            int mx = 0;
            for (int upperRowStatus = 0; upperRowStatus < 1 << n; upperRowStatus++) {
                if (IsCrossRowsCompliant(status, upperRowStatus, n)) {
                    mx = Math.Max(mx, DP(seats, row - 1, upperRowStatus));
                }
            }
            memo.Add(key, students + mx);
        }
        return memo[key];
    }

    public bool IsSingleRowCompliant(char[][] seats, int status, int n, int row) {
        for (int j = 0; j < n; j++) {
            if (((status >> j) & 1) == 1) {
                if (seats[row][j] == '#') {
                    return false;
                }
                if (j > 0 && ((status >> (j - 1)) & 1) == 1) {
                    return false;
                }
            }
        }
        return true;
    }

    public bool IsCrossRowsCompliant(int status, int upperRowStatus, int n) {
        for (int j = 0; j < n; j++) {
            if (((status >> j) & 1) == 1) {
                if (j > 0 && ((upperRowStatus >> (j - 1)) & 1) == 1) {
                    return false;
                }
                if (j < n - 1 && ((upperRowStatus >> (j + 1)) & 1) == 1) {
                    return false;
                }
            }
        }
        return true;
    }

    public int BitCount(int num) {
        uint bits = (uint) num;
        bits = bits - ((bits >> 1) & 0x55555555);
        bits = (bits & 0x33333333) + ((bits >> 2) & 0x33333333);
        bits = (bits + (bits >> 4)) & 0x0f0f0f0f;
        bits = (bits + (bits >> 8)) & 0x00ff00ff;
        bits = (bits + (bits >> 16)) & 0x0000ffff;
        return (int) bits;
    }
}
```

```c++
class Solution {
public:
    int maxStudents(vector<vector<char>>& seats) {
        int m = seats.size(), n = seats[0].size();
        unordered_map<int, int> memo;

        auto isSingleRowCompliant = [&](int status, int row) -> bool {
            for (int j = 0; j < n; j++) {
                if ((status >> j) & 1) {
                    if (seats[row][j] == '#') {
                        return false;
                    }
                    if (j > 0 && ((status >> (j - 1)) & 1)) {
                        return false;
                    }
                }
            }
            return true;
        };
        
        auto isCrossRowsCompliant = [&](int status, int upperRowStatus) -> bool {
            for (int j = 0; j < n; j++) {
                if ((status >> j) & 1) {
                    if (j > 0 && ((upperRowStatus >> (j - 1)) & 1)) {
                        return false;
                    }
                    if (j < n - 1 && ((upperRowStatus >> (j + 1)) & 1)) {
                        return false;
                    }
                }
            }
            return true;
        };

        function<int(int, int)> dp = [&](int row, int status) -> int {
            int key = (row << n) + status;
            if (!memo.count(key)) {
                if (!isSingleRowCompliant(status, row)) {
                    memo[key] = INT_MIN;
                    return INT_MIN;
                }
                int students = __builtin_popcount(status);
                if (row == 0) {
                    memo[key] = students;
                    return students;
                }
                int mx = 0;
                for (int upperRowStatus = 0; upperRowStatus < 1 << n; upperRowStatus++) {
                    if (isCrossRowsCompliant(status, upperRowStatus)) {
                        mx = max(mx, dp(row - 1, upperRowStatus));
                    }
                }
                memo[key] = students + mx;
            }
            return memo[key];
        };
        
        int mx = 0;
        for (int i = 0; i < (1 << n); i++) {
            mx = max(mx, dp(m - 1, i));
        }
        return mx;
    }
};
```

```c
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

bool isSingleRowCompliant(char **seats, int status, int row, int n) {
    for (int j = 0; j < n; j++) {

        if ((status >> j) & 1) {
            if (seats[row][j] == '#') {
                return false;
            }
            if (j > 0 && ((status >> (j - 1)) & 1)) {
                return false;
            }
        }
    }
    return true;
};

bool isCrossRowsCompliant(int status, int upperRowStatus, int n) {
    for (int j = 0; j < n; j++) {
        if ((status >> j) & 1) {
            if (j > 0 && ((upperRowStatus >> (j - 1)) & 1)) {
                return false;
            }
            if (j < n - 1 && ((upperRowStatus >> (j + 1)) & 1)) {
                return false;
            }
        }
    }
    return true;
};

int dp(char **seats, HashItem **memo, int row, int status, int n) {
    int key = (row << n) + status;
    if (!hashFindItem(memo, key)) {
        if (!isSingleRowCompliant(seats, status, row, n)) {
            hashAddItem(memo, key, INT_MIN);
            return INT_MIN;
        }
        int students = __builtin_popcount(status);
        if (row == 0) {
            hashAddItem(memo, key, students);
            return students;
        }
        int mx = 0;
        for (int upperRowStatus = 0; upperRowStatus < 1 << n; upperRowStatus++) {
            if (isCrossRowsCompliant(status, upperRowStatus, n)) {
                mx = fmax(mx, dp(seats, memo, row - 1, upperRowStatus, n));
            }
        }
        hashAddItem(memo, key, students + mx);
    }
    return hashGetItem(memo, key, 0);
};

int maxStudents(char** seats, int seatsSize, int* seatsColSize) {
    int m = seatsSize, n = seatsColSize[0];
    HashItem *memo = NULL;
    int mx = 0;
    for (int i = 0; i < (1 << n); i++) {
        mx = fmax(mx, dp(seats, &memo, m - 1, i, n));
    }
    hashFree(&memo);
    return mx;
}
```

```go
func maxStudents(seats [][]byte) int {
    m, n := len(seats), len(seats[0])
    memo := make(map[int]int)

    isSingleRowCompliant := func(status, row int) bool {
        n := len(seats[0])
        for j := 0; j < n; j++ {
            if (status >> j) & 1 == 1 {
                if seats[row][j] == '#' {
                    return false
                }
                if j > 0 && (status >> (j - 1)) & 1 == 1 {
                    return false
                }
            }
        }
        return true
    }

    isCrossRowsCompliant := func(status, upperRowStatus int) bool {
        n := len(seats[0])
        for j := 0; j < n; j++ {
            if (status >> j) & 1 == 1 {
                if j > 0 && (upperRowStatus >> (j - 1)) & 1 == 1 {
                    return false
                }
                if j < n - 1 && (upperRowStatus >> (j + 1)) & 1 == 1 {
                    return false
                }
            }
        }
        return true
    }

    var dp func(int, int) int
    dp = func(row, status int) int {
        n := len(seats[0])
        key := (row << n) + status
        if _, ok := memo[key]; !ok {
            if !isSingleRowCompliant(status, row) {
                memo[key] = math.MinInt32
                return math.MinInt32
            }
            students := bits.OnesCount(uint(status))
            if row == 0 {
                memo[key] = students
                return students
            }
            mx := 0
            for upperRowStatus := 0; upperRowStatus < 1 << n; upperRowStatus++ {
                if isCrossRowsCompliant(status, upperRowStatus) {
                    mx = max(mx, dp(row - 1, upperRowStatus))
                }
            }
            memo[key] = students + mx
        }
        return memo[key]
    }

    mx := 0
    for i := 0; i < (1 << n); i++ {
        mx = max(mx, dp(m - 1, i))
    }
    return mx
}
```

```javascript
var maxStudents = function(seats) {
    const m = seats.length, n = seats[0].length;
    const memo = new Map();

    const isSingleRowCompliant = function(status, row) {
        for (let j = 0; j < n; j++) {
            if ((status >> j) & 1) {
                if (seats[row][j] == '#') {
                    return false;
                }
                if (j > 0 && ((status >> (j - 1)) & 1)) {
                    return false;
                }
            }
        }
        return true;
    };
    
    const isCrossRowsCompliant = function(status, upperRowStatus) {
        for (let j = 0; j < n; j++) {
            if ((status >> j) & 1) {
                if (j > 0 && ((upperRowStatus >> (j - 1)) & 1)) {
                    return false;
                }
                if (j < n - 1 && ((upperRowStatus >> (j + 1)) & 1)) {
                    return false;
                }
            }
        }
        return true;
    };

    const dp = function(row, status) {
        const key = (row << n) + status;
        if (!memo.has(key)) {
            if (!isSingleRowCompliant(status, row)) {
                memo.set(key, -Infinity);
                return -Infinity;
            }
            let students = bitCount(status);
            if (row == 0) {
                memo.set(key, students);
                return students;
            }
            let mx = 0;
            for (let upperRowStatus = 0; upperRowStatus < 1 << n; upperRowStatus++) {
                if (isCrossRowsCompliant(status, upperRowStatus)) {
                    mx = Math.max(mx, dp(row - 1, upperRowStatus));
                }
            }
            memo.set(key, students + mx);
        }
        return memo.get(key);
    };
    
    let mx = 0;
    for (let i = 0; i < (1 << n); i++) {
        mx = Math.max(mx, dp(m - 1, i));
    }
    return mx;
};

var bitCount = function(num) {
    let bits = num;
    bits = bits - ((bits >> 1) & 0x55555555);
    bits = (bits & 0x33333333) + ((bits >> 2) & 0x33333333);
    bits = (bits + (bits >> 4)) & 0x0f0f0f0f;
    bits = (bits + (bits >> 8)) & 0x00ff00ff;
    bits = (bits + (bits >> 16)) & 0x0000ffff;
    return bits;
}
```

#### 复杂度分析

- 时间复杂度：$O(m\times{n}\times2^{2n})$, 状态数量共有 $m \times 2^n$ 种，计算一个状态需要消耗 $O(n\times2^n)$ 的时间。可以通过预计算所有 $isCrossRowsCompliant$ 的结果来降低时间复杂度到 $O((m+n)\times 2^{2n})$。
- 空间复杂度：$O(n \times 2^n)$。
