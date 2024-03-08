### [找出美丽数组的最小和](https://leetcode.cn/problems/find-the-minimum-possible-sum-of-a-beautiful-array/solutions/2668273/zhao-chu-mei-li-shu-zu-de-zui-xiao-he-by-20h1/)

#### 方法一：贪心

##### 思路与算法

根据题意，我们需要构造一个大小为 $n$ 的正整数数组，该数组由不同的数字组成，并且没有任意两个数字的和等于 $\textit{target}$，在满足这样的前提下，要保证数组的和最小。

为了让数组之和最小，我们按照 $1,2,3,\cdots$ 的顺序考虑，但添加了 $x$ 之后，就不能添加 $\textit{target} - x$，因此最大可以添加到 $\lfloor\textit{target} / 2\rfloor$，如果个数还不够 $n$ 个，就继续从 $\textit{target}, \textit{target} + 1, \textit{target} + 2, \cdots$ 依次添加。由于添加的数字是连续的，所以可以用等差数列求和公式快速求解。

令 $m = \lfloor\textit{target} / 2\rfloor$，然后可以分情况求解：

- 若 $n \le m$，最小数组和为 $\dfrac{(1 + n) \times n}{2}$。
- 否则 $n \gt m$，最小数组和为 $\dfrac{(1 + m) \times m}{2} + \dfrac{(\textit{target} + (\textit{target} + (n - m) - 1)) \times (n - m)}{2}$。

##### 代码

```c++
class Solution {
public:
    int minimumPossibleSum(int n, int target) {
        const int mod = 1e9 + 7;
        int m = target / 2;
        if (n <= m) {
            return (long long) (1 + n) * n / 2 % mod;
        }
        return ((long long) (1 + m) * m / 2 + 
                ((long long) target + target + (n - m) - 1) * (n - m) / 2) % mod;
    }
};
```

```java
class Solution {
    public int minimumPossibleSum(int n, int target) {
        final int MOD = (int) 1e9 + 7;
        int m = target / 2;
        if (n <= m) {
            return (int) ((long) (1 + n) * n / 2 % MOD);
        }
        return (int) (((long) (1 + m) * m / 2 + 
                ((long) target + target + (n - m) - 1) * (n - m) / 2) % MOD);
    }
}
```

```csharp
public class Solution {
    public int MinimumPossibleSum(int n, int target) {
        const int MOD = (int) 1e9 + 7;
        int m = target / 2;
        if (n <= m) {
            return (int) ((long) (1 + n) * n / 2 % MOD);
        }
        return (int) (((long) (1 + m) * m / 2 + 
                ((long) target + target + (n - m) - 1) * (n - m) / 2) % MOD);
    }
}
```

```c
int minimumPossibleSum(int n, int target){
    const int mod = 1e9 + 7;
    int m = target / 2;
    if (n <= m) {
        return ((long long)(1 + n) * n / 2) % mod;
    }
    return ((long long) (1 + m) * m / 2 + \
           ((long long) target + target + (n - m) - 1) * (n - m) / 2) % mod;
}
```

```python
class Solution:
    def minimumPossibleSum(self, n: int, target: int) -> int:
        mod = 10**9 + 7
        m = target // 2
        if n <= m:
            return ((1 + n) * n // 2) % mod
        return ((1 + m) * m // 2 + (target * 2 + (n - m) - 1) * (n - m) // 2) % mod
```

```go
func minimumPossibleSum(n int, target int) int {
    const mod = 1000000007
    m := target / 2
    if n <= m {
        return ((1 + n) * n / 2) % mod
    }
    return (((1 + m) * m / 2) + (((target + target + (n - m) - 1) * (n - m) / 2))) % mod
}
```

```javascript
var minimumPossibleSum = function(n, target) {
    const mod = 1000000007;
    const m = Math.floor(target / 2);
    if (n <= m) {
        return ((1 + n) * n / 2) % mod;
    }
    return (((1 + m) * m / 2) + (((target + target + (n - m) - 1) * (n - m) / 2))) % mod;
};
```

```typescript
function minimumPossibleSum(n: number, target: number): number {
    const mod: number = 1000000007;
    const m: number = Math.floor(target / 2);
    if (n <= m) {
        return ((1 + n) * n / 2) % mod;
    }
    return (((1 + m) * m / 2) + (((target + target + (n - m) - 1) * (n - m) / 2))) % mod;
};
```

```rust
impl Solution {
    pub fn minimum_possible_sum(n: i32, target: i32) -> i32 {
        const MOD: i64 = 1_000_000_007;
        let n: i64 = n as i64;
        let target: i64 = target as i64;
        let m: i64 = target / 2;
        if n <= m {
            return (((1 + n) * n / 2) % MOD) as i32
        }
        return ((((1 + m) * m / 2) + (((target + target + (n - m) - 1) * (n - m) / 2))) % MOD) as i32;
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
