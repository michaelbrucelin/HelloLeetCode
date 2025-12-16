### [分隔长廊的方案数](https://leetcode.cn/problems/number-of-ways-to-divide-a-long-corridor/solutions/1231280/fen-ge-chang-lang-de-fang-an-shu-by-leet-p9wr/)

#### 方法一：乘法原理

**思路与算法**

我们可以按照顺序将座位每两个分成一组。在相邻两组之间，如果有 $x$ 个装饰植物，那么就有 $x+1$ 种放置屏风的方法。根据乘法原理，总方案数就是所有 $x+1$ 的乘积。

因此，我们只需要对数组 $corridor$ 进行一次遍历就可得到答案。在遍历的过程中，我们维护当前的座位总数 $cnt$ 和上一个座位的位置 $prev$。当遍历到 $corridor[i]$ 时，如果它是座位，并且包括它我们遍历到奇数（并且大于等于 $3$）个座位，那么 $corridor[i]$ 就是一个新的座位组的开始，它和上一个组之间就有 $i-prev-1$ 个装饰植物，即 $i-prev$ 种放置屏风的方法。

在遍历完成后，我们需要检查 $cnt$ 是否为偶数并且大于等于 $2$。如果不满足，那么需要返回 $0$。

**代码**

```C++
class Solution {
private:
    static constexpr int mod = 1000000007;
    
public:
    int numberOfWays(string corridor) {
        int n = corridor.size();
        int prev = -1, cnt = 0, ans = 1;
        for (int i = 0; i < n; ++i) {
            if (corridor[i] == 'S') {
                ++cnt;
                if (cnt >= 3 && cnt % 2 == 1) {
                    ans = static_cast<long long>(ans) * (i - prev) % mod;
                }
                prev = i;
            }
        }
        if (cnt < 2 || cnt & 1) {
            ans = 0;
        }
        return ans;
    }
};
```

```Python
class Solution:
    def numberOfWays(self, corridor: str) -> int:
        mod = 10**9 + 7

        prev, cnt, ans = -1, 0, 1
        for i, ch in enumerate(corridor):
            if ch == "S":
                cnt += 1
                if cnt >= 3 and cnt % 2 == 1:
                    ans = ans * (i - prev) % mod
                prev = i
        
        if cnt < 2 or cnt % 2 == 1:
            ans = 0
        
        return ans
```

```Go
func numberOfWays(corridor string) int {
    const mod = 1e9 + 7
    prev, cnt, ans := -1, 0, 1
    for i, ch := range corridor {
        if ch == 'S' {
            cnt += 1
            if (cnt >= 3) && (cnt % 2 == 1) {
                ans = ans * (i - prev) % mod
            }
            prev = i
        }
    }
    if (cnt < 2) || (cnt % 2 == 1) {
        ans = 0
    }
    return ans
}
```

```Java
class Solution {
    private static final int mod = 1000000007;
    
    public int numberOfWays(String corridor) {
        int n = corridor.length();
        int prev = -1, cnt = 0, ans = 1;
        for (int i = 0; i < n; ++i) {
            if (corridor.charAt(i) == 'S') {
                ++cnt;
                if (cnt >= 3 && cnt % 2 == 1) {
                    ans = (int)((long)ans * (i - prev) % mod);
                }
                prev = i;
            }
        }
        if (cnt < 2 || cnt % 2 != 0) {
            ans = 0;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    private const int mod = 1000000007;
    
    public int NumberOfWays(string corridor) {
        int n = corridor.Length;
        int prev = -1, cnt = 0, ans = 1;
        for (int i = 0; i < n; ++i) {
            if (corridor[i] == 'S') {
                ++cnt;
                if (cnt >= 3 && cnt % 2 == 1) {
                    ans = (int)((long)ans * (i - prev) % mod);
                }
                prev = i;
            }
        }
        if (cnt < 2 || cnt % 2 != 0) {
            ans = 0;
        }
        return ans;
    }
}
```

```C
const int mod = 1000000007;

int numberOfWays(char* corridor) {
    int n = strlen(corridor);
    int prev = -1, cnt = 0, ans = 1;
    for (int i = 0; i < n; ++i) {
        if (corridor[i] == 'S') {
            ++cnt;
            if (cnt >= 3 && cnt % 2 == 1) {
                ans = (long long)ans * (i - prev) % mod;
            }
            prev = i;
        }
    }
    if (cnt < 2 || cnt % 2 != 0) {
        ans = 0;
    }
    return ans;
}
```

```JavaScript
var numberOfWays = function(corridor) {
    const mod = 1000000007;
    const n = corridor.length;
    let prev = -1, cnt = 0, ans = 1;
    for (let i = 0; i < n; ++i) {
        if (corridor[i] === 'S') {
            ++cnt;
            if (cnt >= 3 && cnt % 2 === 1) {
                ans = Number((BigInt(ans) * BigInt(i - prev)) % BigInt(mod));
            }
            prev = i;
        }
    }
    if (cnt < 2 || cnt % 2 !== 0) {
        ans = 0;
    }
    return ans;
};
```

```TypeScript
function numberOfWays(corridor: string): number {
    const mod = 1000000007;
    const n = corridor.length;
    let prev = -1, cnt = 0, ans = 1;
    for (let i = 0; i < n; ++i) {
        if (corridor[i] === 'S') {
            ++cnt;
            if (cnt >= 3 && cnt % 2 === 1) {
                ans = Number((BigInt(ans) * BigInt(i - prev)) % BigInt(mod));
            }
            prev = i;
        }
    }
    if (cnt < 2 || cnt % 2 !== 0) {
        ans = 0;
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn number_of_ways(corridor: String) -> i32 {
        const MOD: i32 = 1000000007;
        let n = corridor.len();
        let mut prev = -1;
        let mut cnt = 0;
        let mut ans: i64 = 1;
        
        for (i, ch) in corridor.chars().enumerate() {
            if ch == 'S' {
                cnt += 1;
                if cnt >= 3 && cnt % 2 == 1 {
                    ans = (ans * (i as i64 - prev as i64)) % MOD as i64;
                }
                prev = i as i32;
            }
        }
        
        if cnt < 2 || cnt % 2 != 0 {
            return 0;
        }
        
        ans as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$。
