### [统计范围内的逗号 II](https://leetcode.cn/problems/count-commas-in-range-ii/solutions/4020363/tong-ji-fan-wei-nei-de-dou-hao-ii-by-lee-1khd/)

#### 方法一：按位贡献法

**思路与算法**

根据逗号的标准书写格式，每三位数字需要插入一个逗号。我们可以换个角度，计算每个逗号对最终答案的“贡献”：

- 大于等于 $10^3$ 的数，都会包含至少 $1$ 个逗号，这一部分总共贡献 $n-10^3+1$ 个逗号。
- 大于等于 $10^6$ 的数，会包含至少 $2$ 个逗号（即在前一步的基础上，每个数额外多贡献 $1$ 个逗号），总共额外贡献 $n-10^6+1$ 个。
- 以此类推，我们只需通过变量 `p` 每次乘以 $1000$，并累加当前段的贡献值 $n-p+1$ 即可。

**代码**

```C++
class Solution {
public:
    long long countCommas(long long n) {
        long long p = 1000, res = 0;
        while (p <= n) {
            res += n - p + 1;
            p *= 1000;
        }
        return res;
    }
};
```

```Java
class Solution {
    public long countCommas(long n) {
        long p = 1000, res = 0;
        while (p <= n) {
            res += n - p + 1;
            p *= 1000;
        }
        return res;
    }
}
```

```Python
class Solution:
    def countCommas(self, n: int) -> int:
        p = 1000
        res = 0
        while p <= n:
            res += n - p + 1
            p *= 1000
        return res
```

```JavaScript
var countCommas = function(n) {
    let p = 1000, res = 0;
    while (p <= n) {
        res += n - p + 1;
        p *= 1000;
    }
    return res;
};
```

```TypeScript
function countCommas(n: number): number {
    let p: number = 1000, res: number = 0;
    while (p <= n) {
        res += n - p + 1;
        p *= 1000;
    }
    return res;
}
```

```Go
func countCommas(n int64) int64 {
    var p int64 = 1000
    var res int64 = 0
    for p <= n {
        res += n - p + 1
        p *= 1000
    }
    return res
}
```

```CSharp
public class Solution {
    public long CountCommas(long n) {
        long p = 1000, res = 0;
        while (p <= n) {
            res += n - p + 1;
            p *= 1000;
        }
        return res;
    }
}
```

```C
long long countCommas(long long n) {
    long long p = 1000, res = 0;
    while (p <= n) {
        res += n - p + 1;
        p *= 1000;
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn count_commas(n: i64) -> i64 {
        let mut p: i64 = 1000;
        let mut res: i64 = 0;
        while p <= n {
            res += n - p + 1;
            p *= 1000;
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\log n)$。
- 空间复杂度：$O(1)$。
