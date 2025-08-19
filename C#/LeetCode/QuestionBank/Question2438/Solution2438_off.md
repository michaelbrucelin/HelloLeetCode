### [二的幂数组中查询范围内的乘积](https://leetcode.cn/problems/range-product-queries-of-powers/solutions/3741778/er-de-mi-shu-zu-zhong-cha-xun-fan-wei-ne-ygou/)

#### 方法一：二进制分解 $+$ 直接计算

**思路与算法**

根据题目描述，我们需要将 $n$ 分解成最少数目的 $2$ 的幂，这就提示我们将 $n$ 写成二进制表示，如果从低到高的第 $k (k\ge 0)$ 个二进制位为 $1$，那么分解中就包括 $2^k$。

> 例如 $n=11$，它的二进制表示为 $(1011)_2$，从低到高的第 $0,1,3$ 个二进制位为 $1$，因此分解为 $[2^0,2^1,2^3]=[1,2,8]$。

在得到 $n$ 的分解后，由于题目中保证 $n\ge 10^9<2^{30}-1$，因此分解的数组中不会超过 $29$ 个元素。对于每一个询问 $[left,right]$，可以直接遍历分解数组中对应的所有元素，并计算答案，单次询问的时间复杂度为 $O(log n)$。

同样地，不同的询问总数不会超过 $\dfrac{29\times 28}{2}+29=435$ 个，因此也可以使用预处理的方式，提前计算出每一种询问的答案，时间复杂度为 $O(log^2 n)$，之后单次询问的时间复杂度减少至 $O(1)$。

方法一给出的是使用遍历直接计算的方法。

**代码**

```C++
class Solution {
public:
    vector<int> productQueries(int n, vector<vector<int>>& queries) {
        vector<int> bins;
        int rep = 1;
        while (n) {
            if (n % 2 == 1) {
                bins.push_back(rep);
            }
            n /= 2;
            rep *= 2;
        }

        vector<int> ans;
        for (const auto& query: queries) {
            int cur = 1;
            for (int i = query[0]; i <= query[1]; ++i) {
                cur = static_cast<long long>(cur) * bins[i] % mod;
            }
            ans.push_back(cur);
        }
        return ans;
    }

private:
    static constexpr int mod = 1000000007;
};
```

```Python
class Solution:
    def productQueries(self, n: int, queries: List[List[int]]) -> List[int]:
        mod = 10**9 + 7

        bins, rep = [], 1
        while n > 0:
            if n % 2 == 1:
                bins.append(rep)
            n //= 2
            rep *= 2

        ans = []
        for left, right in queries:
            cur = 1
            for i in range(left, right + 1):
                cur = cur * bins[i] % mod
            ans.append(cur)
        return ans
```

```Java
class Solution {
    private static final int MOD = 1000000007;

    public int[] productQueries(int n, int[][] queries) {
        List<Integer> bins = new ArrayList<>();
        int rep = 1;
        while (n > 0) {
            if (n % 2 == 1) {
                bins.add(rep);
            }
            n /= 2;
            rep *= 2;
        }

        int[] ans = new int[queries.length];
        for (int i = 0; i < queries.length; i++) {
            long cur = 1;
            int start = queries[i][0];
            int end = queries[i][1];
            for (int j = start; j <= end; j++) {
                cur = (cur * bins.get(j)) % MOD;
            }
            ans[i] = (int) cur;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    private const int MOD = 1000000007;

    public int[] ProductQueries(int n, int[][] queries) {
        var bins = new List<int>();
        int rep = 1;
        while (n > 0) {
            if (n % 2 == 1) {
                bins.Add(rep);
            }
            n /= 2;
            rep *= 2;
        }

        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            long cur = 1;
            int start = queries[i][0];
            int end = queries[i][1];
            for (int j = start; j <= end; ++j) {
                cur = (cur * bins[j]) % MOD;
            }
            ans[i] = (int)cur;
        }
        return ans;
    }
}
```

```Go
func productQueries(n int, queries [][]int) []int {
    const mod = 1000000007
    var bins []int
    rep := 1
    for n > 0 {
        if n % 2 == 1 {
            bins = append(bins, rep)
        }
        n /= 2
        rep *= 2
    }

    ans := make([]int, 0, len(queries))
    for _, query := range queries {
        cur := 1
        for i := query[0]; i <= query[1]; i++ {
            cur = (cur * bins[i]) % mod
        }
        ans = append(ans, cur)
    }
    return ans
}
```

```C
int* productQueries(int n, int** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    const int mod = 1000000007;
    int* bins = (int*)malloc(32 * sizeof(int));
    int binsSize = 0;
    int rep = 1;
    while (n > 0) {
        if (n % 2 == 1) {
            bins[binsSize++] = rep;
        }
        n /= 2;
        rep *= 2;
    }

    int* ans = (int*)malloc(queriesSize * sizeof(int));
    *returnSize = queriesSize;
    for (int i = 0; i < queriesSize; i++) {
        long long cur = 1;
        for (int j = queries[i][0]; j <= queries[i][1]; j++) {
            cur = (cur * bins[j]) % mod;
        }
        ans[i] = (int)cur;
    }
    free(bins);
    return ans;
}
```

```JavaScript
var productQueries = function(n, queries) {
    const mod = 1000000007;
    const bins = [];
    let rep = 1;
    while (n > 0) {
        if (n % 2 === 1) {
            bins.push(rep);
        }
        n = Math.floor(n / 2);
        rep *= 2;
    }

    const ans = [];
    for (const [start, end] of queries) {
        let cur = 1;
        for (let i = start; i <= end; i++) {
            cur = (cur * bins[i]) % mod;
        }
        ans.push(cur);
    }
    return ans;
};
```

```TypeScript
function productQueries(n: number, queries: number[][]): number[] {
    const mod: number = 1000000007;
    const bins: number[] = [];
    let rep = 1;
    while (n > 0) {
        if (n % 2 === 1) {
            bins.push(rep);
        }
        n = Math.floor(n / 2);
        rep *= 2;
    }

    const ans: number[] = [];
    for (const [start, end] of queries) {
        let cur = 1;
        for (let i = start; i <= end; i++) {
            cur = (cur * bins[i]) % mod;
        }
        ans.push(cur);
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn product_queries(n: i32, queries: Vec<Vec<i32>>) -> Vec<i32> {
        const MOD: i64 = 1_000_000_007;
        let mut bins = Vec::new();
        let mut n = n;
        let mut rep = 1;
        while n > 0 {
            if n % 2 == 1 {
                bins.push(rep);
            }
            n /= 2;
            rep *= 2;
        }

        queries.iter().map(|query| {
            let mut cur: i64 = 1;
            for i in query[0]..=query[1] {
                cur = (cur * bins[i as usize]) % MOD;
            }
            cur as i32
        }).collect()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(q\times log n)$，其中 $q$ 是数组 $queries$ 的长度。
- 空间复杂度：$O(log n)$，即为存储 $n$ 的二进制分解需要使用的空间。

#### 方法二：二进制分解 $+$ 预处理

**思路与算法**

方法二给出的是使用预处理方式的代码。

**代码**

```C++
class Solution {
public:
    vector<int> productQueries(int n, vector<vector<int>>& queries) {
        vector<int> bins;
        int rep = 1;
        while (n) {
            if (n % 2 == 1) {
                bins.push_back(rep);
            }
            n /= 2;
            rep *= 2;
        }

        int m = bins.size();
        vector<vector<int>> results(m, vector<int>(m));
        for (int i = 0; i < m; ++i) {
            int cur = 1;
            for (int j = i; j < m; ++j) {
                cur = static_cast<long long>(cur) * bins[j] % mod;
                results[i][j] = cur;
            }
        }

        vector<int> ans;
        for (const auto& query: queries) {
            ans.push_back(results[query[0]][query[1]]);
        }
        return ans;
    }

private:
    static constexpr int mod = 1000000007;
};
```

```Python
class Solution:
    def productQueries(self, n: int, queries: List[List[int]]) -> List[int]:
        mod = 10**9 + 7

        bins, rep = [], 1
        while n > 0:
            if n % 2 == 1:
                bins.append(rep)
            n //= 2
            rep *= 2
        
        m = len(bins)
        results = [[0] * m for _ in range(m)]
        for i in range(m):
            cur = 1
            for j in range(i, m):
                cur = cur * bins[j] % mod
                results[i][j] = cur

        ans = []
        for left, right in queries:
            ans.append(results[left][right])
        return ans
```

```Java
class Solution {
    private static final int MOD = 1000000007;

    public int[] productQueries(int n, int[][] queries) {
        List<Integer> bins = new ArrayList<>();
        int rep = 1;
        while (n > 0) {
            if (n % 2 == 1) {
                bins.add(rep);
            }
            n /= 2;
            rep *= 2;
        }

        int m = bins.size();
        int[][] results = new int[m][m];
        for (int i = 0; i < m; i++) {
            long cur = 1;
            for (int j = i; j < m; j++) {
                cur = (cur * bins.get(j)) % MOD;
                results[i][j] = (int) cur;
            }
        }

        int[] ans = new int[queries.length];
        for (int i = 0; i < queries.length; i++) {
            ans[i] = results[queries[i][0]][queries[i][1]];
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    private const int MOD = 1000000007;

    public int[] ProductQueries(int n, int[][] queries) {
        var bins = new List<int>();
        int rep = 1;
        while (n > 0) {
            if (n % 2 == 1) {
                bins.Add(rep);
            }
            n /= 2;
            rep *= 2;
        }

        int m = bins.Count;
        int[,] results = new int[m, m];
        for (int i = 0; i < m; i++) {
            long cur = 1;
            for (int j = i; j < m; j++) {
                cur = (cur * bins[j]) % MOD;
                results[i, j] = (int) cur;
            }
        }

        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            ans[i] = results[queries[i][0], queries[i][1]];
        }
        return ans;
    }
}
```

```Go
func productQueries(n int, queries [][]int) []int {
    const mod = 1000000007
    var bins []int
    rep := 1
    for n > 0 {
        if n % 2 == 1 {
            bins = append(bins, rep)
        }
        n /= 2
        rep *= 2
    }

    m := len(bins)
    results := make([][]int, m)
    for i := range results {
        results[i] = make([]int, m)
        cur := 1
        for j := i; j < m; j++ {
            cur = (cur * bins[j]) % mod
            results[i][j] = cur
        }
    }

    ans := make([]int, len(queries))
    for i, query := range queries {
        ans[i] = results[query[0]][query[1]]
    }
    return ans
}
```

```C
int* productQueries(int n, int** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    const int mod = 1000000007;
    int bins[32];
    int binsSize = 0;
    int rep = 1;
    while (n > 0) {
        if (n % 2 == 1) {
            bins[binsSize++] = rep;
        }
        n /= 2;
        rep *= 2;
    }

    int** results = (int**)malloc(binsSize * sizeof(int*));
    for (int i = 0; i < binsSize; i++) {
        results[i] = (int*)malloc(binsSize * sizeof(int));
        long long cur = 1;
        for (int j = i; j < binsSize; j++) {
            cur = (cur * bins[j]) % mod;
            results[i][j] = (int)cur;
        }
    }

    int* ans = (int*)malloc(queriesSize * sizeof(int));
    *returnSize = queriesSize;
    for (int i = 0; i < queriesSize; i++) {
        ans[i] = results[queries[i][0]][queries[i][1]];
    }

    for (int i = 0; i < binsSize; i++) {
        free(results[i]);
    }
    free(results);
    return ans;
}
```

```JavaScript
var productQueries = function(n, queries) {
   const mod = 1000000007;
    const bins = [];
    let rep = 1;
    while (n > 0) {
        if (n % 2 === 1) {
            bins.push(rep);
        }
        n = Math.floor(n / 2);
        rep *= 2;
    }

    const m = bins.length;
    const results = Array.from({ length: m }, () => new Array(m));
    for (let i = 0; i < m; i++) {
        let cur = 1;
        for (let j = i; j < m; j++) {
            cur = (cur * bins[j]) % mod;
            results[i][j] = cur;
        }
    }

    const ans = [];
    for (const [start, end] of queries) {
        ans.push(results[start][end]);
    }
    return ans;
};
```

```TypeScript
function productQueries(n: number, queries: number[][]): number[] {
    const mod: number = 1000000007;
    const bins: number[] = [];
    let rep = 1;
    while (n > 0) {
        if (n % 2 === 1) {
            bins.push(rep);
        }
        n = Math.floor(n / 2);
        rep *= 2;
    }

    const m = bins.length;
    const results: number[][] = Array.from({ length: m }, () => new Array(m));
    for (let i = 0; i < m; i++) {
        let cur = 1;
        for (let j = i; j < m; j++) {
            cur = (cur * bins[j]) % mod;
            results[i][j] = cur;
        }
    }

    const ans: number[] = [];
    for (const [start, end] of queries) {
        ans.push(results[start][end]);
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn product_queries(n: i32, queries: Vec<Vec<i32>>) -> Vec<i32> {
        const MOD: i64 = 1_000_000_007;
        let mut bins = Vec::new();
        let mut n = n;
        let mut rep = 1;
        while n > 0 {
            if n % 2 == 1 {
                bins.push(rep);
            }
            n /= 2;
            rep *= 2;
        }

        let m = bins.len();
        let mut results = vec![vec![0; m]; m];
        for i in 0..m {
            let mut cur: i64 = 1;
            for j in i..m {
                cur = (cur * bins[j]) % MOD;
                results[i][j] = cur as i32;
            }
        }

        queries.iter().map(|query| results[query[0] as usize][query[1] as usize]).collect()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(log^2 n+q)$，其中 $q$ 是数组 $queries$ 的长度。
- 空间复杂度：$O(log^2 n)$，即为存储预处理结果需要使用的空间。
