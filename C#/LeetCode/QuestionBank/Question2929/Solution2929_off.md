### [给小朋友们分糖果 II](https://leetcode.cn/problems/distribute-candies-among-children-ii/solutions/2791756/gei-xiao-peng-you-men-fen-tang-guo-ii-by-1jj9/)

#### 方法一：枚举

**思路**

枚举第一个小朋友分得 $x$ 颗糖果，那么还剩下 $n-x$ 颗糖果，此时有两种情况：

- $n-x > limit \times 2$，至少有一个小朋友会分得大于 $limit$ 颗糖果，此时不存在合法方案。
- $n-x \le limit \times 2$，对于第二个小朋友来说，至少得分得 $max(0,n-x-limit)$ 颗糖果，才能保证第三个小朋友分得的糖果不超过 $limit$ 颗。同时至多能拿到 $min(limit,n-x)$ 颗糖果。

对于第二种情况计算出所有的合法方案即可。

**代码**

```C++
class Solution {
public:
    long long distributeCandies(int n, int limit) {
        long long ans = 0;
        for (int i = 0; i <= min(limit, n); i++) {
            if (n - i > 2 * limit) {
                continue;
            }
            ans += min(n - i, limit) - max(0, n - i - limit) + 1;
        }
        return ans;
    }
};
```

```Java
class Solution {
    public long distributeCandies(int n, int limit) {
        long ans = 0;
        for (int i = 0; i <= Math.min(limit, n); i++) {
            if (n - i > 2 * limit) {
                continue;
            }
            ans += Math.min(n - i, limit) - Math.max(0, n - i - limit) + 1;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public long DistributeCandies(int n, int limit) {
        long ans = 0;
        for (int i = 0; i <= Math.Min(limit, n); i++) {
            if (n - i > 2 * limit) {
                continue;
            }
            ans += Math.Min(n - i, limit) - Math.Max(0, n - i - limit) + 1;
        }
        return ans;
    }
}
```

```Go
func distributeCandies(n int, limit int) int64 {
    ans := int64(0)
    for i := 0; i <= min(limit, n); i++ {
        if n - i > 2 * limit {
            continue
        }
        ans += int64(min(n - i, limit) - max(0, n - i - limit) + 1)
    }
    return ans
}
```

```C
long long distributeCandies(int n, int limit) {
    long long ans = 0;
    for (int i = 0; i <= fmin(limit, n); i++) {
        if (n - i > 2 * limit) {
            continue;
        }
        ans += fmin(n - i, limit) - fmax(0, n - i - limit) + 1;
    }
    return ans;
}
```

```Python
class Solution:
    def distributeCandies(self, n: int, limit: int) -> int:
        ans = 0
        for i in range(min(limit, n) + 1):
            if n - i > 2 * limit:
                continue
            ans += min(n - i, limit) - max(0, n - i - limit) + 1
        return ans
```

```JavaScript
var distributeCandies = function(n, limit) {
    let ans = 0;
    for (let i = 0; i <= Math.min(limit, n); i++) {
        if (n - i > 2 * limit) {
            continue;
        }
        ans += Math.min(n - i, limit) - Math.max(0, n - i - limit) + 1;
    }
    return ans;
};
```

```TypeScript
function distributeCandies(n: number, limit: number): number {
    let ans = 0;
    for (let i = 0; i <= Math.min(limit, n); i++) {
        if (n - i > 2 * limit) {
            continue;
        }
        ans += Math.min(n - i, limit) - Math.max(0, n - i - limit) + 1;
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn distribute_candies(n: i32, limit: i32) -> i64 {
        let mut ans: i64 = 0;
        for i in 0..=std::cmp::min(limit, n) {
            if n - i > 2 * limit {
                continue;
            }
            ans += std::cmp::min(n - i, limit) as i64 - std::cmp::max(0, n - i - limit) as i64 + 1;
        }

        return ans;
    }
}
```

**复杂度分析**

- 时间复杂度：$O(min(limit,n))$。
- 空间复杂度：$O(1)$。

#### 方法二：容斥

也可以采用常规计数的思想，用所有方案减去不合法的方案。使用组合数学的容斥原理，用所有的方案数减去至少有一个小朋友分得超过 $limit$ 颗糖果。但会重复计算至少有两个小朋友分得超过 $limit$ 颗糖果，因此把这部分加回来。计算这部分的时候又会重复计算三个小朋友都分得超过 $limit$ 颗糖果的方案，因此再减去这部分方案数。

对于所有的方案数，因为允许小朋友分得 $0$ 颗糖果，问题可转化为在 $n+3$ 颗糖果中插两块板，使得每位小朋友至少分得一颗糖果。在 $n+3$ 颗糖果中有 $n+2$ 个空位，故方案数为 $C_{n+2}^2$，这里使用 $C$ 来表示组合数。

至少有一个小朋友分得超过 $limit$ 颗糖果的方案数，可以先给任意一个小朋友分得 $limit+1$ 颗糖果，此时问题转化为将 $n-limit-1$ 颗糖果分给三个小朋友，故方案数为 $C_3^1 \times C_{n-(limit+1)+2}^2$。

至少有两个小朋友分得超过 $limit$ 颗糖果的方案数，可以先给任意两个小朋友分得 $limit+1$ 颗糖果，此时问题转化为将 $n-(limit+1) \times 2$ 颗糖果分给三个小朋友，故方案数为 $C_3^2 \times C_{n-(limit+1) \times 2+2}^2$。

至少有三个小朋友分得超过 $limit$ 颗糖果的方案数，可以先给三个小朋友分得 $limit+1$ 颗糖果，此时问题转化为将 $n-(limit+1) \times 3$ 颗糖果分给三个小朋友，故方案数为 $C_{n-(limit+1) \times 3+2}^2$。

最后整理方案数为 $C_{n+2}^2-C_3^1 \times C_{n-(limit+1)+2}^2+C_3^2 \times C_{n-(limit+1) \times 2+2}^2-C_{n-(limit+1) \times 3+2}^2$。

**代码**

```C++
class Solution {
public:
    long long cal(int x) {
        if (x < 0) {
            return 0;
        }
        return (long) x * (x - 1) / 2;
    }

    long long distributeCandies(int n, int limit) {
        return cal(n + 2) - 3 * cal(n - limit + 1) + 3 * cal(n - (limit + 1) * 2 + 2) - cal(n - 3 * (limit + 1) + 2);
    }
};
```

```Java
class Solution {
    public long distributeCandies(int n, int limit) {
        return cal(n + 2) - 3 * cal(n - limit + 1) + 3 * cal(n - (limit + 1) * 2 + 2) - cal(n - 3 * (limit + 1) + 2);
    }

    public long cal(int x) {
        if (x < 0) {
            return 0;
        }
        return (long) x * (x - 1) / 2;
    }
}
```

```CSharp
public class Solution {
    public long DistributeCandies(int n, int limit) {
        return Cal(n + 2) - 3 * Cal(n - limit + 1) + 3 * Cal(n - (limit + 1) * 2 + 2) - Cal(n - 3 * (limit + 1) + 2);
    }

    public long Cal(int x) {
        if (x < 0) {
            return 0;
        }
        return (long) x * (x - 1) / 2;
    }
}
```

```Go
func cal(x int) int64 {
    if x < 0 {
        return 0
    }
    return int64(x) * int64(x - 1) / 2
}

func distributeCandies(n int, limit int) int64 {
    return cal(n + 2) - 3 * cal(n - limit + 1) + 3 * cal(n - (limit + 1) * 2 + 2) - cal(n - 3 * (limit + 1) + 2)
}
```

```C
long long cal(int x) {
    if (x < 0) {
        return 0;
    }
    return (long long) x * (x - 1) / 2;
}

long long distributeCandies(int n, int limit) {
    return cal(n + 2) - 3 * cal(n - limit + 1) + 3 * cal(n - (limit + 1) * 2 + 2) - cal(n - 3 * (limit + 1) + 2);
}
```

```Python
def cal(x):
    if x < 0:
        return 0
    return x * (x - 1) // 2 
    
class Solution:
    def distributeCandies(self, n: int, limit: int) -> int:
        return cal(n + 2) - 3 * cal(n - limit + 1) + 3 * cal(n - (limit + 1) * 2 + 2) - cal(n - 3 * (limit + 1) + 2)
```

```Rust
impl Solution {
    pub fn distribute_candies(n: i32, limit: i32) -> i64 {
        Self::cal(n + 2) - 3 * Self::cal(n - limit + 1) + 3 * Self::cal(n - (limit + 1) * 2 + 2) - Self::cal(n - 3 * (limit + 1) + 2)
    }

    fn cal(x: i32) -> i64 {
        if x < 0 {
            0
        } else {
            x as i64 * (x - 1) as i64 / 2
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
