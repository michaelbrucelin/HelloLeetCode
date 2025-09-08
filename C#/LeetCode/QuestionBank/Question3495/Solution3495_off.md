### [使数组元素都变为零的最少操作次数](https://leetcode.cn/problems/minimum-operations-to-make-array-elements-zero/solutions/3764859/shi-shu-zu-yuan-su-du-bian-wei-ling-de-z-11m3/)

#### 方法一：找规律 + 位运算统计

**思路与算法**

题目给定了一组区间，每个区间表示为 $[l,r]$，我们需要把区间内的每个数字都变成 $0$，每次操作可以选择其中两个数字将其除以 $4$ 并向下取整。问所有区间所需的最少操作次数之和。

对一个数字除以 $4$ 等同于二进制运算中将其右移 $2$ 位。例如 $11(1011_2)$ 除以 $4$ 变为 $2(10_2)$。尝试列出一些数字需要变成 $0$ 的操作次数：

- $1,2,3$ 仅需操作 $1$ 次，这些数字的二进制长度为 $1$ 和 $2$
- $4,5,\dots ,15$ 仅需操作 $2$ 次，这些数字的二进制长度为 $3$ 和 $4$
- $16,17,\dots ,63$ 仅需操作 $3$ 次，这些数字的二进制长度为 $5$ 和 $6$

因此，对于长度为 $x$ 的二进制，仅需操作 $\lceil dfrac{x}{2} \rceil $ 次，我们容易算出这个区间范围内的所有操作次数。因此，通过遍历所有二进制长度，我们能得到 $1$ 到 $r$ 范围内的所有操作次数，也能得到 $1$ 到 $l-1$ 范围内的操作次数，两者的差就是 $[l,r]$ 范围内的操作次数，不过这里的操作指的是对单个数字除以 $4$，与题意还略有些区别。

既然能得到对所有单个数字的操作次数，那么每次挑选两个数字进行操作的次数也能轻易得出，即所有的操作次数之和除以 $2$ 并上取整。取整的意义在于当和是奇数时，我们不得不在最后一次操作选择一个 $0$ 来与另一个非 $0$ 数字一起操作。

**代码**

```C++
class Solution {
    using ll = long long;
public:
    ll get(int num) {
        int i = 1;
        int base = 1;
        ll cnt = 0;
        while (base <= num) {
            cnt += 1ll * (i + 1) / 2 * (min(base * 2 - 1, num) - base + 1);
            i++;
            base *= 2;
        }
        return cnt;
    }
    long long minOperations(vector<vector<int>>& queries) {
        ll res = 0;
        for (auto &q : queries) {
            res += (get(q[1]) - get(q[0] - 1) + 1) / 2;
        }
        return res;
    }
};
```

```Python
class Solution:
    def get(self, num: int) -> int:
        i = 1
        base = 1
        cnt = 0
        while base <= num:
            cnt += ((i + 1) // 2) * (min(base * 2 - 1, num) - base + 1)
            i += 1
            base *= 2
        return cnt

    def minOperations(self, queries: List[List[int]]) -> int:
        res = 0
        for q in queries:
            res += (self.get(q[1]) - self.get(q[0] - 1) + 1) // 2
        return res
```

```Rust
impl Solution {
    pub fn get(num: i32) -> i64 {
        let mut i: i64 = 1;
        let mut base: i64 = 1;
        let mut cnt: i64 = 0;
        let num = num as i64;
        while base <= num {
            cnt += ((i + 1) / 2) * (std::cmp::min(base * 2 - 1, num) - base + 1);
            i += 1;
            base *= 2;
        }
        cnt
    }

    pub fn min_operations(queries: Vec<Vec<i32>>) -> i64 {
        let mut res: i64 = 0;
        for q in queries.iter() {
            let left = q[0] as i32;
            let right = q[1] as i32;
            res += (Self::get(right) - Self::get(left - 1) + 1) / 2;
        }
        res
    }
}
```

```Java
class Solution {
    private long get(int num) {
        long cnt = 0;
        int i = 1;
        int base = 1;
        while (base <= num) {
            int end = Math.min(base * 2 - 1, num);
            cnt += (long) ((i + 1) / 2) * (end - base + 1);
            i++;
            base *= 2;
        }
        return cnt;
    }

    public long minOperations(int[][] queries) {
        long res = 0;
        for (int[] q : queries) {
            long count1 = get(q[1]);
            long count2 = get(q[0] - 1);
            res += (count1 - count2 + 1) / 2;
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    private long Get(int num) {
        long cnt = 0;
        int i = 1;
        int baseVal = 1;

        while (baseVal <= num) {
            int end = Math.Min(baseVal * 2 - 1, num);
            cnt += (long)((i + 1) / 2) * (end - baseVal + 1);
            i++;
            baseVal *= 2;
        }
        return cnt;
    }

    public long MinOperations(int[][] queries) {
        long res = 0;
        foreach (var q in queries) {
            long count1 = Get(q[1]);
            long count2 = Get(q[0] - 1);
            res += (count1 - count2 + 1) / 2;
        }
        return res;
    }
}
```

```Go
func get(num int) int64 {
    var cnt int64
    i := 1
    base := 1

    for base <= num {
        end := base * 2 - 1
        if end > num {
            end = num
        }
        cnt += int64((i + 1) / 2) * int64(end - base + 1)
        i++
        base *= 2
    }
    return cnt
}

func minOperations(queries [][]int) int64 {
    var res int64
    for _, q := range queries {
        count1 := get(q[1])
        count2 := get(q[0] - 1)
        res += (count1 - count2 + 1) / 2
    }
    return res
}
```

```C
long long get(int num) {
    long long cnt = 0;
    int i = 1;
    int base = 1;

    while (base <= num) {
        int end = (base * 2 - 1 < num) ? base * 2 - 1 : num;
        cnt += (long long)((i + 1) / 2) * (end - base + 1);
        i++;
        base *= 2;
    }
    return cnt;
}

long long minOperations(int** queries, int queriesSize, int* queriesColSize) {
    long long res = 0;
    for (int i = 0; i < queriesSize; i++) {
        long long count1 = get(queries[i][1]);
        long long count2 = get(queries[i][0] - 1);
        res += (count1 - count2 + 1) / 2;
    }
    return res;
}
```

```JavaScript
var minOperations = function(queries) {
    let res = 0n;
    for (const q of queries) {
        const count1 = get(q[1]);
        const count2 = get(q[0] - 1);
        res += (count1 - count2 + 1n) / 2n;
    }
    return Number(res);
};

const get = (num) => {
    let cnt = 0n;
    let i = 1;
    let base = 1;

    while (base <= num) {
        const end = Math.min(base * 2 - 1, num);
        cnt += BigInt(Math.floor((i + 1) / 2)) * BigInt(end - base + 1);
        i++;
        base *= 2;
    }
    return cnt;
}
```

```TypeScript
function minOperations(queries: number[][]): number {
    let res = 0n;
    for (const q of queries) {
        const count1 = get(q[1]);
        const count2 = get(q[0] - 1);
        res += (count1 - count2 + 1n) / 2n;
    }
    return Number(res);
};

function get(num: number): bigint {
    let cnt = 0n;
    let i = 1;
    let base = 1;

    while (base <= num) {
        const end = Math.min(base * 2 - 1, num);
        cnt += BigInt(Math.floor((i + 1) / 2)) * BigInt(end - base + 1);
        i++;
        base *= 2;
    }
    return cnt;
}
```

**复杂度分析**

- 时间复杂度：$O(n \log R)$，其中 $n$ 是 $queries$ 的长度，$R$ 是 $r$ 的最大值。
- 空间复杂度：$O(1)$。
