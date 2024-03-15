### [卖木头块](https://leetcode.cn/problems/selling-pieces-of-wood/solutions/1630619/mai-mu-tou-kuai-by-leetcode-solution-gflg/?envType=daily-question&envId=2024-03-15)

#### 方法一：动态规划 / 记忆化搜索

##### 思路与算法

我们可以使用动态规划来解决本题。

我们用 $f(x, y)$ 表示当木块的高和宽分别是 $x$ 和 $y$ 时，可以得到的最多钱数。我们需要考虑三种情况：

- 如果数组 $\textit{prices}$ 中存在 $(x, y, \textit{price})$ 这一三元组，那么我们可以将木块以 $\textit{prices}$ 的价格卖出。为了快速判断存在性，我们可以使用一个哈希映射来进行存储，即哈希映射的键为 $(h_i, w_i)$，值为 $\textit{price}_i$，这样我们就可以根据木块的高和宽，在 $O(1)$ 的时间得到对应的价格。这种情况的状态转移方程为：
$$f(x, y) = \textit{price}$$
- 如果 $x>1$，那么我们可以沿水平方向将木块切成两部分，它们的高分别是 $i~(1 \leq i < x)$ 和 $x-i$，宽均为 $y$。因此我们可以得到状态转移方程：
$$f(x, y) = \max_{1 \leq i < x} \big\{ f(i, y) + f(x-i, y) \big\}$$
- 如果 $y>1$，那么我们可以沿垂直方向将木块切成两部分，它们的宽分别是 $j~(1 \leq j < y)$ 和 $y-j$，高均为 $x$。因此我们可以得到状态转移方程：
$$f(x, y) = \max_{1 \leq j < y} \big\{ f(x, j) + f(x, y-j) \big\}$$

当有多种情况满足时，我们需要选择它们中的较大值。最终的答案即为 $f(m,n)$。

##### 细节

本题使用记忆化搜索进行编码更加简洁方便。

##### 代码

```c++
class Solution {
public:
    long long sellingWood(int m, int n, vector<vector<int>>& prices) {
        auto pair_hash = [fn = hash<int>()](const pair<int, int>& o) -> size_t {
            return (fn(o.first) << 16) ^ fn(o.second);
        };
        unordered_map<pair<int, int>, int, decltype(pair_hash)> value(0, pair_hash);

        vector<vector<long long>> memo(m + 1, vector<long long>(n + 1, -1));

        function<long long(int, int)> dfs = [&](int x, int y) -> long long {
            if (memo[x][y] != -1) {
                return memo[x][y];
            }

            long long ret = value.count({x, y}) ? value[{x, y}] : 0;
            if (x > 1) {
                for (int i = 1; i < x; ++i) {
                    ret = max(ret, dfs(i, y) + dfs(x - i, y));
                }
            }
            if (y > 1) {
                for (int j = 1; j < y; ++j) {
                    ret = max(ret, dfs(x, j) + dfs(x, y - j));
                }
            }
            return memo[x][y] = ret;
        };

        for (int i = 0; i < prices.size(); ++i) {
            value[{prices[i][0], prices[i][1]}] = prices[i][2];
        }
        return dfs(m, n);
    }
};
```

```python
class Solution:
    def sellingWood(self, m: int, n: int, prices: List[List[int]]) -> int:
        value = dict()

        @cache
        def dfs(x: int, y: int) -> int:
            ret = value.get((x, y), 0)

            if x > 1:
                for i in range(1, x):
                    ret = max(ret, dfs(i, y) + dfs(x - i, y))
            
            if y > 1:
                for j in range(1, y):
                    ret = max(ret, dfs(x, j) + dfs(x, y - j))
            
            return ret
        
        for (h, w, price) in prices:
            value[(h, w)] = price
        
        ans = dfs(m, n)
        dfs.cache_clear()
        return ans
```

```java
class Solution {
    public long sellingWood(int m, int n, int[][] prices) {
        Map<Long, Integer> value = new HashMap<>();
        for (int[] price : prices) {
            value.put(pairHash(price[0], price[1]), price[2]);
        }

        long[][] memo = new long[m + 1][n + 1];
        for (long[] row : memo) {
            Arrays.fill(row, -1);
        }
        return dfs(m, n, value, memo);
    }

    public long dfs(int x, int y, Map<Long, Integer> value, long[][] memo) {
        if (memo[x][y] != -1) {
            return memo[x][y];
        }

        long key = pairHash(x, y);
        long ret = value.containsKey(key) ? value.get(key) : 0;
        if (x > 1) {
            for (int i = 1; i < x; i++) {
                ret = Math.max(ret, dfs(i, y, value, memo) + dfs(x - i, y, value, memo));
            }
        }
        if (y > 1) {
            for (int j = 1; j < y; j++) {
                ret = Math.max(ret, dfs(x, j, value, memo) + dfs(x, y - j, value, memo));
            }
        }
        memo[x][y] = ret;
        return ret;
    }

    public long pairHash(int x, int y) {
        return (long) x << 16 ^ y;
    }
}
```

```csharp
public class Solution {
    public long SellingWood(int m, int n, int[][] prices) {
        Dictionary<long, int> value = new Dictionary<long, int>();
        foreach (int[] price in prices) {
            value[PairHash(price[0], price[1])] = price[2];
        }

        long[,] memo = new long[m + 1, n + 1];
        for (int i = 0; i <= m; i++) {
            for (int j = 0; j <= n; j++) {
                memo[i, j] = -1;
            }
        }
        return Dfs(m, n, value, memo);
    }

     public long Dfs(int x, int y, Dictionary<long, int> value, long[,] memo) {
        if (memo[x, y] != -1) {
            return memo[x, y];
        }

        long key = PairHash(x, y);
        long ret = value.ContainsKey(key) ? value[key] : 0;
        if (x > 1) {
            for (int i = 1; i < x; i++) {
                ret = Math.Max(ret, Dfs(i, y, value, memo) + Dfs(x - i, y, value, memo));
            }
        }
        if (y > 1) {
            for (int j = 1; j < y; j++) {
                ret = Math.Max(ret, Dfs(x, j, value, memo) + Dfs(x, y - j, value, memo));
            }
        }
        memo[x, y] = ret;
        return ret;
    }

    public long PairHash(int x, int y) {
        return ((long)x << 16) ^ y;
    }
}
```

```c
typedef struct {
    long long key;
    long long val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, long long key) {
    HashItem *pEntry = NULL;
    HASH_FIND(hh, *obj, &key, sizeof(long long), pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, long long key, long long val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD(hh, *obj, key, sizeof(key), pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, long long key, long long val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetItem(HashItem **obj, long long key, long long defaultVal) {
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

long long pairHash(int x, int y) {
    return ((long long) x << 16) ^ y;
}

long long dfs(int x, int y, long long **memo, HashItem **val) {
    if (memo[x][y] != -1) {
        return memo[x][y];
    }

    long long ret = hashGetItem(val, pairHash(x, y), 0LL);
    if (x > 1) {
        for (int i = 1; i < x; ++i) {
            ret = fmax(ret, dfs(i, y, memo, val) + dfs(x - i, y, memo, val));
        }
    }
    if (y > 1) {
        for (int j = 1; j < y; ++j) {
            ret = fmax(ret, dfs(x, j, memo, val) + dfs(x, y - j, memo, val));
        }
    }
    return memo[x][y] = ret;
};

long long sellingWood(int m, int n, int** prices, int pricesSize, int* pricesColSize) {
    HashItem *value = NULL;
    long long *memo[m + 1];
    for (int i = 0; i <= m; i++) {
        memo[i] = (long long *)malloc(sizeof(long long) * (n + 1));
        for (int j = 0; j <= n; j++) {
            memo[i][j] = -1;
        }
    }
    for (int i = 0; i < pricesSize; ++i) {
        hashAddItem(&value, pairHash(prices[i][0], prices[i][1]), prices[i][2]);
    }
    long long ret = dfs(m, n, memo, &value);
    for (int i = 0; i <= m; i++) {
        free(memo[i]);
    }
    hashFree(&value);
    return ret;
}
```

```go
func sellingWood(m int, n int, prices [][]int) int64 {
    value := make(map[[2]int]int, 0)
    memo := make([][]int64, m + 1)
    for i := range memo {
        memo[i] = make([]int64, n+1)
        for j := range memo[i] {
            memo[i][j] = -1
        }
    }

    var dfs func(int, int) int64
    dfs = func(x, y int) int64 {
        if memo[x][y] != -1 {
            return memo[x][y]
        }

        var ret int64
        if val, ok := value[[2]int{x, y}]; ok {
            ret = int64(val)
        }
        if x > 1 {
            for i := 1; i < x; i++ {
                ret = max(ret, dfs(i, y) + dfs(x - i, y))
            }
        }
        if y > 1 {
            for j := 1; j < y; j++ {
                ret = max(ret, dfs(x, j) + dfs(x, y - j))
            }
        }
        memo[x][y] = ret
        return ret
    }

    for _, price := range prices {
        value[[2]int{price[0], price[1]}] = price[2]
    }
    return dfs(m, n)
}
```

```javascript
var sellingWood = function(m, n, prices) {
     const pairHash = (x, y) => {
        return (x << 16) ^ y;
    };

    const value = new Map();
    const memo = [];
    for (let i = 0; i <= m; i++) {
        memo[i] = new Array(n + 1).fill(-1);
    }

    const dfs = (x, y) => {
        if (memo[x][y] !== -1) {
            return memo[x][y];
        }
        
        let ret = value.has(pairHash(x, y)) ? value.get(pairHash(x, y)) : 0;
        if (x > 1) {
            for (let i = 1; i < x; i++) {
                ret = Math.max(ret, dfs(i, y) + dfs(x - i, y));
            }
        }
        if (y > 1) {
            for (let j = 1; j < y; j++) {
                ret = Math.max(ret, dfs(x, j) + dfs(x, y - j));
            }
        }
        memo[x][y] = ret;
        return ret;
    };

    for (const price of prices) {
        value.set(pairHash(price[0], price[1]), price[2]);
    }
    return dfs(m, n);
};
```

```typescript
function sellingWood(m: number, n: number, prices: number[][]): number {
    const pairHash = (x: number, y: number): number => {
        return (x << 16) ^ y;
    };

    const value: Map<number, number> = new Map();
    const memo: number[][] = [];
    for (let i = 0; i <= m; i++) {
        memo[i] = new Array<number>(n + 1).fill(-1);
    }

    const dfs = (x: number, y: number): number => {
        if (memo[x][y] !== -1) {
            return memo[x][y];
        }
        
        let ret: number = value.has(pairHash(x, y)) ? value.get(pairHash(x, y))! : 0;
        if (x > 1) {
            for (let i = 1; i < x; i++) {
                ret = Math.max(ret, dfs(i, y) + dfs(x - i, y));
            }
        }
        if (y > 1) {
            for (let j = 1; j < y; j++) {
                ret = Math.max(ret, dfs(x, j) + dfs(x, y - j));
            }
        }
        memo[x][y] = ret;
        return ret;
    };

    for (const price of prices) {
        value.set(pairHash(price[0], price[1]), price[2]);
    }
    return dfs(m, n);
};
```

```rust
use std::collections::HashMap;

impl Solution {
    pub fn selling_wood(m: i32, n: i32, prices: Vec<Vec<i32>>) -> i64 {
        let mut value: HashMap<(i32, i32), i32> = HashMap::new();
        let mut memo: Vec<Vec<i64>> = vec![vec![-1; (n + 1) as usize]; (m + 1) as usize];

        fn dfs(x: i32, y: i32, memo: &mut Vec<Vec<i64>>, value: &HashMap<(i32, i32), i32>) -> i64 {
            if memo[x as usize][y as usize] != -1 {
                return memo[x as usize][y as usize];
            }
            let mut ret = if value.contains_key(&(x, y)) {
                value[&(x, y)] as i64
            } else {
                0
            };

            if x > 1 {
                for i in 1..x {
                    ret = ret.max(dfs(i, y, memo, value) + dfs(x - i, y, memo, value));
                }
            }
            if y > 1 {
                for j in 1..y {
                    ret = ret.max(dfs(x, j, memo, value) + dfs(x, y - j, memo, value));
                }
            }
            memo[x as usize][y as usize] = ret;
            ret
        };

        for price in prices {
            value.insert((price[0], price[1]), price[2]);
        }
        dfs(m, n, &mut memo, &value)
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(mn(m+n)+p)$，其中 $p$ 是数组 $\textit{prices}$ 的长度。
- 空间复杂度：$O(mn+p)$，即为哈希映射和动态规划的数组需要使用的空间。
