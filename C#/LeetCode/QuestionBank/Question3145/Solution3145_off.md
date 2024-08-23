### [大数组元素的乘积](https://leetcode.cn/problems/find-products-of-elements-of-big-array/solutions/2886821/da-shu-zu-yuan-su-de-cheng-ji-by-leetcod-o0nf/)

#### 方法一：二分查找 + 计数

**思路与算法**

根据题意可知，大数组由升序的正整数组成。那么对于 $query$ 中的 $from$ 与 $to$，希望能找出分别属于哪一个数字。记 $l_1$ 与 $l_2$ 分别表示数字 $l$ 贡献出的序列的左端点以及右端点，假设 $from$ 实际对应整数 $l$ 贡献出的序列中，那么有 $l_1 \le from \le l_2$。同理可得到 $r_1 \le to \le r_2$。不难发现答案可以分为三部分统计：

- $[from \ldots l_2]$
- $[l_2+1 \ldots r_1-1]$
- $[r_1 \ldots to]$

其中 $[from \ldots l_2]$ 与 $[r_1 \ldots to]$ 部分可以直接暴力求解，因为一个整数 $x$ 最多能贡献 $logx$ 个数字到大数组中。而 $[l_2+1 \ldots r_1-1]$ 恰好就是整数 $l+1 \ldots r-1$ 之间所贡献出的数字。在此之前，我们先讨论如何找到 $from$ 所处的整数。

由于整数 $[1 \ldots x]$ 所贡献出的序列长度随着 $x$ 增大有单调性，可以采用二分查找。然后对于 $[1 \ldots x]$ 所贡献出的序列长度，转化为求小于等于 $x$ 的所有数字数位中 $1$ 的个数之和，可以采用类似数位 $DP$ 的方式进行计数。从高位开始枚举 $x$ 的二进制，并假设目前是一直受到数字的上界限制的，如果这一位 $i$ 为 $1$，那么此时有两种方案可以枚举：

- 枚举这一位为 $1$，继续遍历。
- 枚举这一位为 $0$，因为不满足上界了所以后面的数位可以任意选择。此时答案有两部分，对于小于 $i$ 的数位，每一位都可以贡献出 $2^{i-1}$ 个 $1$，一共有 $i$ 个数位，故此部分贡献为 $i \times 2^{i-1}$。而对于数位 $i$ 前面的部分，记枚举过来一共有 $sum$ 个 $1$，可贡献 $sum \times 2^i$ 个 $1$。

所以我们只需要在枚举 $x$ 中二进制为 $1$ 的时候，统计下答案即可。

以数字 $12$，二进制为 $1100$ 进行举例。第一位为 $1$，此时先计算假设第一位为 $0$ 时的答案，此时还剩 $3$ 个数位可以任意填，当每个数位试填为 $1$ 时，有 $2^{3-1} = 4$ 种方案，故三个数位一共有 $12$ 次贡献。然后继续以第一位为 $1$ 进行后续枚举，第二位也为 $1$，假设第二位为 $0$，还剩下 $2$ 个数位可以任意填一共可以有 $4$ 次贡献，并且需要加上此时的前缀 $10$ 有一个 $1$ 并且能出现 $4$ 次。继续以第二位为 $1$ 继续枚举，此时没有数位 $1$ 了，直接枚举到结束，再加上 $1100$ 中包含的两个 $1$。综上所述，小于等于 $12$ 的所有整数的数位中含有 $12+4+4+2 = 22$ 个 $1$。

继续讨论 $[l_2+1 \ldots r_1-1]$ 这部分，由于 $2^a \times 2^b = 2^{a+b}$，在计算这部分的乘积时，我们将其转化为用 $2$ 的幂次进行表示，然后把幂加起来，最后再进行幂运算，从而把问题转化为求整数 $[l+1 \ldots r-1]$ 之间所有数位之和。比如数字 $6$ 的二进制为 $110$，在此题中的数位之和为 $1+2 = 3$，有 $4 \times 2 = 2^{1+2}$。而 $[l+1 \ldots r-1]$ 可转化为求 $[1 \ldots r-1]-[1 \ldots l]$，我们同样可以采用类似数位 $DP$ 的方法进行计数，与上述讨论类似，只不过每次贡献不是 $1$ 而是其相应的数位了。这里不做赘述，详情参考代码中 $countPow$ 函数。

综上所述，将三部分答案统计即可。

**代码**

```C++
class Solution {
public:
    // 计算 <= x 所有数的数位1的和
    long long countOne(long long x) {
        long long res = 0;
        int sum = 0;

        for (int i = 60; i >= 0; i--) {
            if (1LL << i & x) {
                res += 1LL * sum * (1LL << i);
                sum += 1;
                
                if (i > 0) {
                    res += 1LL * i * (1LL << (i - 1));
                }
            }
        }
        res += sum;
        return res;
    }

    // 计算 <= x 所有数的数位对幂的贡献之和
    long long countPow(long long x) {
        long long res = 0;
        int sum = 0;

        for (int i = 60; i >= 0; i--) {
            if (1LL << i & x) {
                res += 1LL * sum * (1LL << i);
                sum += i;
                
                if (i > 0) {
                    res += 1LL * i * (i - 1) / 2 * (1LL << (i - 1));
                }
            }
        }
        res += sum;
        return res;
    }

    int pow_mod(long long x, long long y, int mod) {
        int res = 1;
        while (y) {
            if (y & 1) {
                res = res * x % mod;
            }
            x = x * x % mod;
            y >>= 1;
        }
        return res;
    }

    long long mid_check(long long x) {
        long long l = 1, r = 1e15;
        while (l < r) {
            long long mid = (l + r) >> 1;
            if (countOne(mid) >= x) {
                r = mid;
            } else {
                l = mid + 1;
            }
        }
        return r;
    }

    vector<int> findProductsOfElements(vector<vector<long long>>& queries) {
        vector<int> ans;

        for (int i = 0; i < queries.size(); i++) {
            // 偏移让数组下标从1开始
            queries[i][0]++;
            queries[i][1]++;
            long long l = mid_check(queries[i][0]);
            long long r = mid_check(queries[i][1]);
            int mod = queries[i][2];

            long long res = 1;
            long long pre = countOne(l - 1);
            for (int j = 0; j < 60; j++) {
                if (1LL << j & l) {
                    pre++;
                    if (pre >= queries[i][0] && pre <= queries[i][1]) {
                        res = res * (1LL << j) % mod;
                    }
                }
            }

            if (r > l) {
                long long bac = countOne(r - 1);
                for (int j = 0; j < 60; j++) {
                    if (1LL << j & r) {
                        bac++;
                        if (bac >= queries[i][0] && bac <= queries[i][1]) {
                            res = res * (1LL << j) % mod;
                        }
                    }
                }
            }

            if (r - l > 1) {
                long long xs = countPow(r - 1) - countPow(l);
                res = res * pow_mod(2LL, xs, mod) % mod;
            }
            ans.push_back(res);
        }

        return ans;
    }
};
```

```Java
class Solution {
    public int[] findProductsOfElements(long[][] queries) {
        int[] ans = new int[queries.length];

        for (int i = 0; i < queries.length; i++) {
            // 偏移让数组下标从1开始
            queries[i][0]++;
            queries[i][1]++;
            long l = midCheck(queries[i][0]);
            long r = midCheck(queries[i][1]);
            int mod = (int) queries[i][2];

            long res = 1;
            long pre = countOne(l - 1);
            for (int j = 0; j < 60; j++) {
                if ((1L << j & l) != 0) {
                    pre++;
                    if (pre >= queries[i][0] && pre <= queries[i][1]) {
                        res = res * (1L << j) % mod;
                    }
                }
            }

            if (r > l) {
                long bac = countOne(r - 1);
                for (int j = 0; j < 60; j++) {
                    if ((1L << j & r) != 0) {
                        bac++;
                        if (bac >= queries[i][0] && bac <= queries[i][1]) {
                            res = res * (1L << j) % mod;
                        }
                    }
                }
            }

            if (r - l > 1) {
                long xs = countPow(r - 1) - countPow(l);
                res = res * powMod(2L, xs, mod) % mod;
            }
            ans[i] = (int) res;
        }

        return ans;
    }

    public long midCheck(long x) {
        long l = 1, r = (long) 1e15;
        while (l < r) {
            long mid = (l + r) >> 1;
            if (countOne(mid) >= x) {
                r = mid;
            } else {
                l = mid + 1;
            }
        }
        return r;
    }

    // 计算 <= x 所有数的数位1的和
    public long countOne(long x) {
        long res = 0;
        int sum = 0;

        for (int i = 60; i >= 0; i--) {
            if ((1L << i & x) != 0) {
                res += 1L * sum * (1L << i);
                sum += 1;
                
                if (i > 0) {
                    res += 1L * i * (1L << (i - 1));
                }
            }
        }
        res += sum;
        return res;
    }

    // 计算 <= x 所有数的数位对幂的贡献之和
    public long countPow(long x) {
        long res = 0;
        int sum = 0;

        for (int i = 60; i >= 0; i--) {
            if ((1L << i & x) != 0) {
                res += 1L * sum * (1L << i);
                sum += i;
                
                if (i > 0) {
                    res += 1L * i * (i - 1) / 2 * (1L << (i - 1));
                }
            }
        }
        res += sum;
        return res;
    }

    public int powMod(long x, long y, int mod) {
        long res = 1;
        while (y != 0) {
            if ((y & 1) != 0) {
                res = res * x % mod;
            }
            x = x * x % mod;
            y >>= 1;
        }
        return (int) res;
    }
}
```

```CSharp
public class Solution {
    public int[] FindProductsOfElements(long[][] queries) {
        int[] ans = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++) {
            // 偏移让数组下标从1开始
            queries[i][0]++;
            queries[i][1]++;
            long l = MidCheck(queries[i][0]);
            long r = MidCheck(queries[i][1]);
            int mod = (int) queries[i][2];

            long res = 1;
            long pre = CountOne(l - 1);
            for (int j = 0; j < 60; j++) {
                if ((1L << j & l) != 0) {
                    pre++;
                    if (pre >= queries[i][0] && pre <= queries[i][1]) {
                        res = res * (1L << j) % mod;
                    }
                }
            }

            if (r > l) {
                long bac = CountOne(r - 1);
                for (int j = 0; j < 60; j++) {
                    if ((1L << j & r) != 0) {
                        bac++;
                        if (bac >= queries[i][0] && bac <= queries[i][1]) {
                            res = res * (1L << j) % mod;
                        }
                    }
                }
            }

            if (r - l > 1) {
                long xs = CountPow(r - 1) - CountPow(l);
                res = res * PowMod(2L, xs, mod) % mod;
            }
            ans[i] = (int) res;
        }

        return ans;
    }

    public long MidCheck(long x) {
        long l = 1, r = (long) 1e15;
        while (l < r) {
            long mid = (l + r) >> 1;
            if (CountOne(mid) >= x) {
                r = mid;
            } else {
                l = mid + 1;
            }
        }
        return r;
    }

    // 计算 <= x 所有数的数位1的和
    public long CountOne(long x) {
        long res = 0;
        int sum = 0;

        for (int i = 60; i >= 0; i--) {
            if ((1L << i & x) != 0) {
                res += 1L * sum * (1L << i);
                sum += 1;
                
                if (i > 0) {
                    res += 1L * i * (1L << (i - 1));
                }
            }
        }
        res += sum;
        return res;
    }

    // 计算 <= x 所有数的数位对幂的贡献之和
    public long CountPow(long x) {
        long res = 0;
        int sum = 0;

        for (int i = 60; i >= 0; i--) {
            if ((1L << i & x) != 0) {
                res += 1L * sum * (1L << i);
                sum += i;
                
                if (i > 0) {
                    res += 1L * i * (i - 1) / 2 * (1L << (i - 1));
                }
            }
        }
        res += sum;
        return res;
    }

    public int PowMod(long x, long y, int mod) {
        long res = 1;
        while (y != 0) {
            if ((y & 1) != 0) {
                res = res * x % mod;
            }
            x = x * x % mod;
            y >>= 1;
        }
        return (int) res;
    }
}
```

```Go
func findProductsOfElements(queries [][]int64) []int {
    ans := make([]int, 0)
    for _, query := range queries {
        // 偏移让数组下标从1开始
        query[0]++
        query[1]++
        l := midCheck(query[0])
        r := midCheck(query[1])
        mod := int(query[2])

        res := int64(1)
        pre := countOne(l - 1)
        for j := 0; j < 60; j++ {
            if (1 << j) & l != 0 {
                pre++
                if pre >= query[0] && pre <= query[1] {
                    res = res * (1 << j) % int64(mod)
                }
            }
        }

        if r > l {
            bac := countOne(r - 1)
            for j := 0; j < 60; j++ {
                if (1 << j) & r != 0 {
                    bac++
                    if bac >= query[0] && bac <= query[1] {
                        res = res * (1 << j) % int64(mod)
                    }
                }
            }
        }
        if r - l > 1 {
            xs := countPow(r - 1) - countPow(l)
            res = res * int64(powMod(2, xs, mod)) % int64(mod)
        }
        ans = append(ans, int(res))
    }

    return ans
}

// 计算 <= x 所有数的数位1的和
func countOne(x int64) int64 {
    var res int64 = 0
    sum := 0

    for i := 60; i >= 0; i-- {
        if (1 << i) & x != 0 {
            res += int64(sum) * (1 << i)
            sum++
            
            if i > 0 {
                res += int64(i) * (1 << (i - 1))
            }
        }
    }
    res += int64(sum)
    return res
}

// 计算 <= x 所有数的数位对幂的贡献之和
func countPow(x int64) int64 {
    var res int64 = 0
    sum := 0

    for i := 60; i >= 0; i-- {
        if (1 << i) & x != 0 {
            res += int64(sum) * (1 << i)
            sum += i
            
            if i > 0 {
                res += int64(i) * (int64(i) - 1) / 2 * (1 << (i - 1))
            }
        }
    }
    res += int64(sum)
    return res
}

func powMod(x int64, y int64, mod int) int {
    res := 1
    for y > 0 {
        if y & 1 != 0 {
            res = res * int(x) % mod
        }
        x = x * x % int64(mod)
        y >>= 1
    }
    return res
}

func midCheck(x int64) int64 {
    l, r := int64(1), int64(1e15)
    for l < r {
        mid := (l + r) >> 1
        if countOne(mid) >= x {
            r = mid
        } else {
            l = mid + 1
        }
    }
    return r
}
```

```Python
# 计算 <= x 所有数的数位1的和
def count_one(x):
    res = 0
    sum = 0

    for i in range(60, -1, -1):
        if (1 << i) & x:
            res += sum * (1 << i)
            sum += 1

            if i > 0:
                res += i * (1 << (i - 1))
    
    res += sum
    return res

# 计算 <= x 所有数的数位对幂的贡献之和
def count_pow(x):
    res = 0
    sum = 0

    for i in range(60, -1, -1):
        if (1 << i) & x:
            res += sum * (1 << i)
            sum += i

            if i > 0:
                res += i * (i - 1) // 2 * (1 << (i - 1))
    
    res += sum
    return res

def pow_mod(x, y, mod):
    res = 1
    while y:
        if y & 1:
            res = res * x % mod
        x = x * x % mod
        y >>= 1
    return res

def mid_check(x):
    l, r = 1, int(1e15)
    while l < r:
        mid = (l + r) >> 1
        if count_one(mid) >= x:
            r = mid
        else:
            l = mid + 1
    return r

class Solution:
    def findProductsOfElements(self, queries: List[List[int]]) -> List[int]:
        ans = []
        for query in queries:
            # 偏移让数组下标从1开始
            query[0] += 1
            query[1] += 1
            l = mid_check(query[0])
            r = mid_check(query[1])
            mod = query[2]

            res = 1
            pre = count_one(l - 1)
            for j in range(60):
                if (1 << j) & l:
                    pre += 1
                    if query[0] <= pre <= query[1]:
                        res = res * (1 << j) % mod

            if r > l:
                bac = count_one(r - 1)
                for j in range(60):
                    if (1 << j) & r:
                        bac += 1
                        if query[0] <= bac <= query[1]:
                            res = res * (1 << j) % mod

            if r - l > 1:
                xs = count_pow(r - 1) - count_pow(l)
                res = res * pow_mod(2, xs, mod) % mod
            
            ans.append(res)

        return ans
```

```C
// 计算 <= x 所有数的数位1的和
long long countOne(long long x) {
    long long res = 0;
    int sum = 0;

    for (int i = 60; i >= 0; i--) {
        if ((1LL << i) & x) {
            res += (long long)sum * (1LL << i);
            sum++;
            
            if (i > 0) {
                res += (long long)i * (1LL << (i - 1));
            }
        }
    }
    res += sum;
    return res;
}

// 计算 <= x 所有数的数位对幂的贡献之和
long long countPow(long long x) {
    long long res = 0;
    int sum = 0;

    for (int i = 60; i >= 0; i--) {
        if ((1LL << i) & x) {
            res += (long long)sum * (1LL << i);
            sum += i;
            
            if (i > 0) {
                res += (long long)i * (i - 1) / 2 * (1LL << (i - 1));
            }
        }
    }
    res += sum;
    return res;
}

int pow_mod(long long x, long long y, int mod) {
    int res = 1;
    while (y) {
        if (y & 1) {
            res = res * x % mod;
        }
        x = x * x % mod;
        y >>= 1;
    }
    return res;
}

long long mid_check(long long x) {
    long long l = 1, r = 1e15;
    while (l < r) {
        long long mid = (l + r) >> 1;
        if (countOne(mid) >= x) {
            r = mid;
        } else {
            l = mid + 1;
        }
    }
    return r;
}

int* findProductsOfElements(long long** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    int* ans = (int*)malloc(queriesSize * sizeof(int));
    *returnSize = queriesSize;
    for (int i = 0; i < queriesSize; i++) {
        // 偏移让数组下标从1开始
        queries[i][0]++;
        queries[i][1]++;
        long long l = mid_check(queries[i][0]);
        long long r = mid_check(queries[i][1]);
        int mod = queries[i][2];

        long long res = 1;
        long long pre = countOne(l - 1);
        for (int j = 0; j < 60; j++) {
            if ((1LL << j) & l) {
                pre++;
                if (pre >= queries[i][0] && pre <= queries[i][1]) {
                    res = res * (1LL << j) % mod;
                }
            }
        }

        if (r > l) {
            long long bac = countOne(r - 1);
            for (int j = 0; j < 60; j++) {
                if ((1LL << j) & r) {
                    bac++;
                    if (bac >= queries[i][0] && bac <= queries[i][1]) {
                        res = res * (1LL << j) % mod;
                    }
                }
            }
        }

        if (r - l > 1) {
            long long xs = countPow(r - 1) - countPow(l);
            res = res * pow_mod(2LL, xs, mod) % mod;
        }
        ans[i] = res;
    }

    return ans;
}
```

```JavaScript
var findProductsOfElements = function(queries) {
    let ans = [];
    for (let query of queries) {
        // 偏移让数组下标从1开始
        query[0]++;
        query[1]++;
        let l = midCheck(BigInt(query[0]));
        let r = midCheck(BigInt(query[1]));
        let mod = query[2];

        let res = 1n;
        let pre = countOne(l - 1n);
        for (let j = 0; j < 60; j++) {
            if ((1n << BigInt(j)) & l) {
                pre++;
                if (pre >= BigInt(query[0]) && pre <= BigInt(query[1])) {
                    res = res * (1n << BigInt(j)) % BigInt(mod);
                }
            }
        }

        if (r > l) {
            let bac = countOne(r - 1n);
            for (let j = 0; j < 60; j++) {
                if ((1n << BigInt(j)) & r) {
                    bac++;
                    if (bac >= BigInt(query[0]) && bac <= BigInt(query[1])) {
                        res = res * (1n << BigInt(j)) % BigInt(mod);
                    }
                }
            }
        }

        if (r - l > 1n) {
            let xs = countPow(r - 1n) - countPow(l);
            res = res * powMod(2n, xs, mod) % BigInt(mod);
        }
        ans.push(Number(res));
    }

    return ans;
};

// 计算 <= x 所有数的数位1的和
function countOne(x) {
    let res = 0n;
    let sum = 0;

    for (let i = 60; i >= 0; i--) {
        if ((1n << BigInt(i)) & x) {
            res += BigInt(sum) * (1n << BigInt(i));
            sum++;

            if (i > 0) {
                res += BigInt(i) * (1n << BigInt(i - 1));
            }
        }
    }
    res += BigInt(sum);
    return res;
}

// 计算 <= x 所有数的数位对幂的贡献之和
function countPow(x) {
    let res = 0n;
    let sum = 0;

    for (let i = 60; i >= 0; i--) {
        if ((1n << BigInt(i)) & x) {
            res += BigInt(sum) * (1n << BigInt(i));
            sum += i;

            if (i > 0) {
                res += BigInt(i) * BigInt(i - 1) / 2n * (1n << BigInt(i - 1));
            }
        }
    }
    res += BigInt(sum);
    return res;
}

function powMod(x, y, mod) {
    let res = 1n;
    while (y) {
        if (y & 1n) {
            res = res * x % BigInt(mod);
        }
        x = x * x % BigInt(mod);
        y >>= 1n;
    }
    return res;
}

function midCheck(x) {
    let l = 1n, r = 1000000000000000n;
    while (l < r) {
        let mid = (l + r) >> 1n;
        if (countOne(mid) >= x) {
            r = mid;
        } else {
            l = mid + 1n;
        }
    }
    return r;
}
```

```TypeScript
function findProductsOfElements(queries: number[][]): number[] {
    let ans: Array<number> = [];
    for (let query of queries) {
        // 偏移让数组下标从1开始
        query[0]++;
        query[1]++;
        let l = midCheck(BigInt(query[0]));
        let r = midCheck(BigInt(query[1]));
        let mod = query[2];

        let res: bigint = 1n;
        let pre = countOne(l - 1n);
        for (let j = 0; j < 60; j++) {
            if ((1n << BigInt(j)) & l) {
                pre++;
                if (pre >= BigInt(query[0]) && pre <= BigInt(query[1])) {
                    res = res * (1n << BigInt(j)) % BigInt(mod);
                }
            }
        }

        if (r > l) {
            let bac = countOne(r - 1n);
            for (let j = 0; j < 60; j++) {
                if ((1n << BigInt(j)) & r) {
                    bac++;
                    if (bac >= BigInt(query[0]) && bac <= BigInt(query[1])) {
                        res = res * (1n << BigInt(j)) % BigInt(mod);
                    }
                }
            }
        }
        if (r - l > 1n) {
            let xs = countPow(r - 1n) - countPow(l);
            res = res * BigInt(powMod(2n, xs, mod)) % BigInt(mod);
        }
        ans.push(Number(res));
    }

    return ans;
};

// 计算 <= x 所有数的数位1的和
function countOne(x: bigint): bigint {
    let res: bigint = 0n;
    let sum = 0;

    for (let i = 60; i >= 0; i--) {
        if ((1n << BigInt(i)) & x) {
            res += BigInt(sum) * (1n << BigInt(i));
            sum++;

            if (i > 0) {
                res += BigInt(i) * (1n << BigInt(i - 1));
            }
        }
    }
    res += BigInt(sum);
    return res;
}

// 计算 <= x 所有数的数位对幂的贡献之和
function countPow(x: bigint): bigint {
    let res: bigint = 0n;
    let sum = 0;

    for (let i = 60; i >= 0; i--) {
        if ((1n << BigInt(i)) & x) {
            res += BigInt(sum) * (1n << BigInt(i));
            sum += i;

            if (i > 0) {
                res += BigInt(i) * BigInt(i - 1) / 2n * (1n << BigInt(i - 1));
            }
        }
    }
    res += BigInt(sum);
    return res;
}

function powMod(x: bigint, y: bigint, mod: number): number {
    let res: bigint = 1n;
    while (y) {
        if (y & 1n) {
            res = res * x % BigInt(mod);
        }
        x = x * x % BigInt(mod);
        y >>= 1n;
    }
    return Number(res);
}

function midCheck(x: bigint): bigint {
    let l: bigint = 1n, r: bigint = 1000000000000000n;
    while (l < r) {
        let mid: bigint = (l + r) >> 1n;
        if (countOne(mid) >= x) {
            r = mid;
        } else {
            l = mid + 1n;
        }
    }
    return r;
}
```

```Rust
impl Solution {
    pub fn find_products_of_elements(queries: Vec<Vec<i64>>) -> Vec<i32> {
        let mut ans = Vec::new();
        for query in queries.iter() {
            // 偏移让数组下标从1开始
            let mut query = query.clone();
            query[0] += 1;
            query[1] += 1;
            let l = Self::mid_check(query[0]);
            let r = Self::mid_check(query[1]);
            let mod_val = query[2];
            let mut res = 1i64;
            let mut pre = Self::count_one(l - 1);
            for j in 0..60 {
                if (1i64 << j) & l != 0 {
                    pre += 1;
                    if pre >= query[0] && pre <= query[1] {
                        res = res * (1i64 << j) % mod_val;
                    }
                }
            }
            if r > l {
                let mut bac = Self::count_one(r - 1);
                for j in 0..60 {
                    if (1i64 << j) & r != 0 {
                        bac += 1;
                        if bac >= query[0] && bac <= query[1] {
                            res = res * (1i64 << j) % mod_val;
                        }
                    }
                }
            }

            if r - l > 1 {
                let xs = Self::count_pow(r - 1) - Self::count_pow(l);
                res = res * Self::pow_mod(2, xs, mod_val) % mod_val;
            }
            ans.push(res as i32);
        }

        ans
    }

    // 计算 <= x 所有数的数位1的和
    fn count_one(mut x: i64) -> i64 {
        let mut res = 0i64;
        let mut sum = 0i64;

        for i in (0..=60).rev() {
            if (1i64 << i) & x != 0 {
                res += sum * (1i64 << i);
                sum += 1;
                if i > 0 {
                    res += i * (1i64 << (i - 1));
                }
            }
        }
        res += sum;
        res
    }

    // 计算 <= x 所有数的数位对幂的贡献之和
    fn count_pow(mut x: i64) -> i64 {
        let mut res = 0i64;
        let mut sum = 0i64;
        for i in (0..=60).rev() {
            if (1i64 << i) & x != 0 {
                res += sum * (1i64 << i);
                sum += i;
                if i > 0 {
                    res += i * (i - 1) / 2 * (1i64 << (i - 1));
                }
            }
        }
        res += sum;
        res
    }

    fn pow_mod(mut x: i64, mut y: i64, mod_val: i64) -> i64 {
        let mut res = 1i64;
        while y != 0 {
            if y & 1 != 0 {
                res = res * x % mod_val;
            }
            x = x * x % mod_val;
            y >>= 1;
        }
        res
    }

    fn mid_check(x: i64) -> i64 {
        let mut l = 1i64;
        let mut r = 1_000_000_000_000_000i64;
        while l < r {
            let mid = (l + r) >> 1;
            if Self::count_one(mid) >= x {
                r = mid;
            } else {
                l = mid + 1;
            }
        }
        r
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m \times lognlogn)$，其中 $m$ 表示查询次数，$n$ 表示查询中的区间下标。$logn$ 为二分的复杂度，同时每次 $check$ 需要花费 $logn$。
- 空间复杂度：$O(1)$。
