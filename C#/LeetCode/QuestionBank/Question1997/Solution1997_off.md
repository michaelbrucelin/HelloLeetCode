### [访问完所有房间的第一天](https://leetcode.cn/problems/first-day-where-you-have-been-in-all-the-rooms/solutions/2710218/fang-wen-wan-suo-you-fang-jian-de-di-yi-p7fc2/)

#### 方法一：动态规划

##### 思路

分析题意发现 $\textit{nextVisit}[i]$ 的范围属于 $[0,i]$，意味着当你首次到达房间 $i$ 时会回退到房间 $\textit{nextVisit}[i]$。而只有访问过该房间偶数次时才会到达下一个房间，进而推断出到达 $i$ 时，$[0,i)$ 的房间已经被访问过偶数次。

定义 $\textit{f}[i]$ 表示从奇数次到房间 $i$，到奇数次到达房间 $i+1$ 所需要的天数。以下用 $to$ 代表 $\textit{nextVisit}[i]$，回退到房间 $to$ 时是奇数次访问，又需要花费 $\textit{f}[to]$ 才会到达房间 $to + 1$。从 $i$ 访问 $to$ 和 $i+1$ 又分别需要花费一天，所以有转移方程:

$$\textit{f}[i] = \sum_{j=to}^{i-1}\textit{f}[j] + 2$$

但这样做时间复杂度是 $O(n^2)$，考虑到求和可以用前缀和预处理达到 $O(1)$ 转移。定义 $\textit{dp}[i]$ 表示从 $0$ 号房间出发首次到 $i+1$ 花费的天数，经化简有转移方程:

$$\textit{dp}[i] = \textit{dp}[i - 1] - \textit{dp}[to] + 2$$

$\textit{dp}[n-1]$ 就是第一次到达 $n$ 号房间花费的天数。

##### 代码

```c++
class Solution {
public:
    int firstDayBeenInAllRooms(vector<int>& nextVisit) {
        int mod = 1e9 + 7;
        int len = nextVisit.size();
        vector<int> dp(len);

        dp[0] = 2; //初始化原地待一天 + 访问下一个房间一天
        for (int i = 1; i < len; i++) {
            int to = nextVisit[i];
            dp[i] = 2 + dp[i - 1];
            
            if (to != 0) {
                dp[i] = (dp[i] - dp[to - 1] + mod) % mod; //避免负数
            }
            dp[i] = (dp[i] + dp[i - 1]) % mod;
        }
        return dp[len - 2]; //题目保证n >= 2
    }
};
```

```java
class Solution {
    public int firstDayBeenInAllRooms(int[] nextVisit) {
        int mod = 1000000007;
        int len = nextVisit.length;
        int[] dp = new int[len];

        dp[0] = 2; //初始化原地待一天 + 访问下一个房间一天
        for (int i = 1; i < len; i++) {
            int to = nextVisit[i];
            dp[i] = 2 + dp[i - 1];
            if (to != 0) {
                dp[i] = (dp[i] - dp[to - 1] + mod) % mod; //避免负数
            }

            dp[i] = (dp[i] + dp[i - 1]) % mod;
        }
        return dp[len - 2]; //题目保证n >= 2
    }
}
```

```csharp
public class Solution {
    public int FirstDayBeenInAllRooms(int[] nextVisit) {
        int mod = 1000000007;
        int len = nextVisit.Length;
        int[] dp = new int[len];

        dp[0] = 2; //初始化原地待一天 + 访问下一个房间一天
        for (int i = 1; i < len; i++) {
            int to = nextVisit[i];
            dp[i] = 2 + dp[i - 1];
            if (to != 0) {
                dp[i] = (dp[i] - dp[to - 1] + mod) % mod; //避免负数
            }

            dp[i] = (dp[i] + dp[i - 1]) % mod;
        }
        return dp[len - 2]; //题目保证n >= 2
    }
}
```

```go
func firstDayBeenInAllRooms(nextVisit []int) int {
    mod := 1000000007
    dp := make([]int, len(nextVisit))

    dp[0] = 2 //初始化原地待一天 + 访问下一个房间一天
    for i := 1; i < len(nextVisit); i++ {
        to := nextVisit[i]
        dp[i] = dp[i - 1] + 2
        if to != 0 {
            dp[i] = (dp[i] - dp[to - 1] + mod) % mod //避免负数
        }
        dp[i] = (dp[i] + dp[i - 1]) % mod; //题目保证n >= 2
    }

    return dp[len(nextVisit) - 2]
}
```

```c
const int MOD = 1e9 + 7;

int firstDayBeenInAllRooms(int* nextVisit, int nextVisitSize) {
    int dp[nextVisitSize ];
    memset(dp, 0, sizeof(dp));

    // 初始化原地待一天+访问下一个房间一天
    dp[0] = 2; 
    for (int i = 1; i < nextVisitSize; i++) {
        int to = nextVisit[i];
        dp[i] = 2 + dp[i - 1];
        if (to) {
            // 避免负数
            dp[i] = (dp[i] - dp[to - 1] + MOD) % MOD;
        }
        dp[i] = (dp[i] + dp[i - 1]) % MOD;
    }
    return dp[nextVisitSize - 2]; //题目保证n >= 2
}
```

```python
class Solution:
    def firstDayBeenInAllRooms(self, nextVisit: List[int]) -> int:
        mod = 10**9 + 7
        dp = [0] * (len(nextVisit))

        #初始化原地待一天+访问下一个房间一天
        dp[0] = 2 
        for i in range(1, len(nextVisit)):
            to = nextVisit[i]
            dp[i] = 2 + dp[i - 1] 
            if to != 0:
                dp[i] = (dp[i] - dp[to - 1]) % mod 
            dp[i] = (dp[i] + dp[i - 1]) % mod
        return dp[len(nextVisit) - 2] # 题目保证n >= 2
```

```javascript
var firstDayBeenInAllRooms = function(nextVisit) {
    const mod = 1e9 + 7;
    const len = nextVisit.length;
    const dp = new Array(len).fill(0);

    // 初始化原地待一天 + 访问下一个房间一天
    dp[0] = 2; 
    for (let i = 1; i < len; i++) {
        const to = nextVisit[i];
        dp[i] = 2 + dp[i - 1];
        if (to) {
            // 避免负数
            dp[i] = (dp[i] - dp[to - 1] + mod) % mod;
        }
        dp[i] = (dp[i] + dp[i - 1]) % mod;
    }
    return dp[len - 2]; //题目保证n >= 2
};
```

```typescript
function firstDayBeenInAllRooms(nextVisit: number[]): number {
    const mod = 1e9 + 7;
    const len = nextVisit.length;
    const dp = new Array(len).fill(0);

    // 初始化原地待一天+访问下一个房间一天
    dp[0] = 2; 
    for (let i = 1; i < len; i++) {
        const to = nextVisit[i];
        dp[i] = 2 + dp[i - 1];
        if (to) {
            // 避免负数
            dp[i] = (dp[i] - dp[to - 1] + mod) % mod;
        }
        dp[i] = (dp[i] + dp[i - 1]) % mod;
    }
    return dp[len - 2]; //题目保证n >= 2
};
```

```rust
impl Solution {
    pub fn first_day_been_in_all_rooms(next_visit: Vec<i32>) -> i32 {
        const MOD: i32 = 1_000_000_007;
        let mut dp: Vec<i32> = vec![0; next_visit.len()];

        // 初始化原地待一天+访问下一个房间一天
        dp[0] = 2; 
        for i in 1..next_visit.len() {
            let to = next_visit[i] as usize;
            dp[i] = 2 + dp[i - 1];
            if to != 0 {
                // 避免负数
                dp[i] = (dp[i] - dp[to - 1] + MOD) % MOD;
            }
            dp[i] = (dp[i] + dp[i - 1]) % MOD;
        }
        return dp[next_visit.len() - 2]; //题目保证n >= 2
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 为数组的长度。
- 空间复杂度：$O(C = n_{max})$，其中 $n$ 为申请 $\textit{dp}$ 数组的长度。
