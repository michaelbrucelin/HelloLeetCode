### [最小移动总距离](https://leetcode.cn/problems/minimum-total-distance-traveled/solutions/3942990/zui-xiao-yi-dong-zong-ju-chi-by-leetcode-9ua6/)

#### 方法一：排序 + 动态规划

将机器人和工厂都按位置排序后，最优解中不会出现「交叉」分配（即位置较小的机器人分配到位置更大的工厂，同时位置较大的机器人分配到位置更小的工厂）。证明过程如下：

假设排序后存在两个机器人 $r_1<r_2$ 和两个工厂 $f_1<f_2$，在某个最优方案中 $r_1$ 被分配到 $f_2$，$r_2$ 被分配到 $f_1$（即发生了交叉）。此时的代价为：

$$C_{cross}=\vert r_1-f_2\vert +\vert r_2-f_1\vert$$

如果我们将分配改为不交叉的方案，即 $r_1\rightarrow f_1$，$r_2\rightarrow f_2$，代价变为：

$$C_{no-cross}=\vert r_1-f_1\vert +\vert r_2-f_2\vert$$

已知 $r_1<r_2$，$f_1<f_2$。需证明 $\vert r_1-f_1\vert +\vert r_2-f_2\vert \le \vert r_1-f_2\vert +\vert r_2-f_1\vert$。
等价地，只需证明：

$$D=\vert r_1-f_2\vert +\vert r_2-f_1\vert -\vert r_1-f_1\vert -\vert r_2-f_2\vert \ge 0$$

根据 $r_1,r_2$ 与 $f_1,f_2$ 的位置关系分以下几种情况讨论：

1. $r_1<r_2<f_1<f_2$（两个机器人均在两个工厂左侧），有：$D=(f_2-r_1)+(f_1-r_2)-(f_1-r_1)-(f_2-r_2)=0$。
2. $f_1<f_2<r_1<r_2$（两个机器人均在两个工厂右侧），有：$D=(r_1-f_2)+(r_2-f_1)-(r_1-f_1)-(r_2-f_2)=0$。
3. $f_1<r_1<r_2<f_2$（两个机器人均在两个工厂之间），有：$D=(f_2-r_1)+(r_2-f_1)-(r_1-f_1)-(f_2-r_2)=2(r_2-r_1)>0$。
4. $r_1<f_1<f_2<r_2$（两个机器人分布在两个工厂两侧），有：$D=(f_2-r_1)+(r_2-f_1)-(f_1-r_1)-(r_2-f_2)=2(f_2-f_1)>0$。
5. $r_1<f_1<r_2<f_2$（r_1 在 $f_1$ 左侧，$r_2$ 在两个工厂之间），有：$D=(f_2-r_1)+(r_2-f_1)-(f_1-r_1)-(f_2-r_2)=2(r_2-f_1)>0$。
6. $f_1<r_1<f_2<r_2$（r_1 在两个工厂之间，$r_2$ 在 $f_2$ 右侧），有：$D=(f_2-r_1)+(r_2-f_1)-(r_1-f_1)-(r_2-f_2)=2(f_2-r_1)>0$。

综上所有情况，均有 $D\ge 0$，即不交叉分配的代价不超过交叉分配的代价。

因此 $C_{no-cross}\le C_{cross}$，交换后总代价不增。这说明任何包含交叉分配的方案，都可以通过交换使其变为不交叉方案且代价不变或更优。所以最优解一定可以在排序后的不交叉分配中取到。

定义 $dp[i][j]$ 为用前 $j$ 个工厂修理前 $i$ 个机器人的最小总移动距离。对于第 $j$ 个工厂（下标从 $1$ 开始），枚举它修理的机器人数量 $k$（$0\le k\le min(i,limit_j)$），状态转移方程：

$$dp[i][j]=\min\limits_{0\le k\le min(i,limit_j)}\Bigg(dp[i-k][j-1]+\sum\limits_{t=i-k+1}^{i}\vert robot_t-factory_j\vert\Bigg)$$

初始 $dp[0][j]=0$，其余为 $\infty $，答案为 $dp[n][m]$。

```C++
class Solution {
public:
    long long minimumTotalDistance(vector<int>& robot, vector<vector<int>>& factory) {
        sort(robot.begin(), robot.end());
        sort(factory.begin(), factory.end());
        int n = robot.size(), m = factory.size();
        vector<vector<long long>> dp(n + 1, vector<long long>(m + 1, LONG_LONG_MAX / 2));
        for (int j = 0; j <= m; j++) {
            dp[0][j] = 0;
        }
        for (int j = 1; j <= m; j++) {
            for (int i = 1; i <= n; i++) {
                dp[i][j] = dp[i][j - 1];
                long long cost = 0;
                for (int k = 1; k <= min(i, factory[j - 1][1]); k++) {
                    cost += abs((long long)robot[i - k] - factory[j - 1][0]);
                    dp[i][j] = min(dp[i][j], dp[i - k][j - 1] + cost);
                }
            }
        }
        return dp[n][m];
    }
};
```

```Go
func abs(x int64) int64 {
    if x < 0 {
        return -x
    }
    return x
}

func minimumTotalDistance(robot []int, factory [][]int) int64 {
	sort.Ints(robot)
	sort.Slice(factory, func(i, j int) bool { return factory[i][0] < factory[j][0] })
	n, m := len(robot), len(factory)
	dp := make([][]int64, n + 1)
	for i := range dp {
		dp[i] = make([]int64, m+1)
        if i == 0 {
            continue
        }
		for j := range dp[i] {
			dp[i][j] = math.MaxInt64 / 2
		}
	}
	for j := 1; j <= m; j++ {
		for i := 1; i <= n; i++ {
			dp[i][j] = dp[i][j-1]
			cost := int64(0)
			for k := 1; k <= min(i, factory[j-1][1]); k++ {
			    cost += abs(int64(robot[i - k] - factory[j - 1][0]))
                dp[i][j] = min(dp[i][j], dp[i - k][j - 1] + cost)
			}
		}
	}
	return dp[n][m]
}
```

```Python
class Solution:
    def minimumTotalDistance(self, robot: List[int], factory: List[List[int]]) -> int:
        robot.sort()
        factory.sort()
        n, m = len(robot), len(factory)
        dp = [[2**62 for _ in range(m + 1)] for _ in range(n + 1)]
        for j in range(m + 1):
            dp[0][j] = 0
        for j in range(1, m + 1):
            for i in range(1, n + 1):
                dp[i][j] = dp[i][j - 1]
                cost = 0
                for k in range(1, min(i, factory[j - 1][1]) + 1):
                    cost += abs(robot[i - k] - factory[j - 1][0])
                    dp[i][j] = min(dp[i][j], dp[i - k][j - 1] + cost)
        return dp[n][m]
```

```Java
class Solution {
    public long minimumTotalDistance(List<Integer> robot, int[][] factory) {
        Collections.sort(robot);
        Arrays.sort(factory, (a, b) -> a[0] - b[0]);
        int n = robot.size(), m = factory.length;
        long[][] dp = new long[n + 1][m + 1];
        for (int i = 1; i <= n; i++) {
            Arrays.fill(dp[i], Long.MAX_VALUE / 2);
        }
        for (int j = 1; j <= m; j++) {
            for (int i = 1; i <= n; i++) {
                dp[i][j] = dp[i][j - 1];
                long cost = 0;
                for (int k = 1; k <= Math.min(i, factory[j - 1][1]); k++) {
                    cost += Math.abs((long) robot.get(i - k) - factory[j - 1][0]);
                    dp[i][j] = Math.min(dp[i][j], dp[i - k][j - 1] + cost);
                }
            }
        }
        return dp[n][m];
    }
}
```

```TypeScript
function minimumTotalDistance(robot: number[], factory: number[][]): number {
    robot.sort((a, b) => a - b);
    factory.sort((a, b) => a[0] - b[0]);
    const n = robot.length, m = factory.length;
    const dp: number[][] = Array.from({length: n + 1}, () => Array(m + 1).fill(Number.MAX_SAFE_INTEGER / 2));
    for (let j = 0; j <= m; j++) {
        dp[0][j] = 0;
    }
    for (let j = 1; j <= m; j++) {
        for (let i = 1; i <= n; i++) {
            dp[i][j] = dp[i][j - 1];
            let cost = 0;
            for (let k = 1; k <= Math.min(i, factory[j - 1][1]); k++) {
                cost += Math.abs(robot[i - k] - factory[j - 1][0]);
                dp[i][j] = Math.min(dp[i][j], dp[i - k][j - 1] + cost);
            }
        }
    }
    return dp[n][m];
}
```

```JavaScript
var minimumTotalDistance = function(robot, factory) {
    robot.sort((a, b) => a - b);
    factory.sort((a, b) => a[0] - b[0]);
    const n = robot.length, m = factory.length;
    const dp = Array.from({length: n + 1}, () => Array(m + 1).fill(Number.MAX_SAFE_INTEGER / 2));
    for (let j = 0; j <= m; j++) {
        dp[0][j] = 0;
    }
    for (let j = 1; j <= m; j++) {
        for (let i = 1; i <= n; i++) {
            dp[i][j] = dp[i][j - 1];
            let cost = 0;
            for (let k = 1; k <= Math.min(i, factory[j - 1][1]); k++) {
                cost += Math.abs(robot[i - k] - factory[j - 1][0]);
                dp[i][j] = Math.min(dp[i][j], dp[i - k][j - 1] + cost);
            }
        }
    }
    return dp[n][m];
};
```

```CSharp
public class Solution {
    public long MinimumTotalDistance(IList<int> robot, int[][] factory) {
        var r = robot.ToList();
        r.Sort();
        Array.Sort(factory, (a, b) => a[0].CompareTo(b[0]));
        int n = r.Count, m = factory.Length;
        long[][] dp = new long[n + 1][];
        for (int i = 0; i <= n; i++) {
            dp[i] = new long[m + 1];
            if (i > 0) {
                Array.Fill(dp[i], long.MaxValue / 2);
            }
        }
        for (int j = 0; j <= m; j++) dp[0][j] = 0;
        for (int j = 1; j <= m; j++) {
            for (int i = 1; i <= n; i++) {
                dp[i][j] = dp[i][j - 1];
                long cost = 0;
                for (int k = 1; k <= Math.Min(i, factory[j - 1][1]); k++) {
                    cost += Math.Abs((long)r[i - k] - factory[j - 1][0]);
                    dp[i][j] = Math.Min(dp[i][j], dp[i - k][j - 1] + cost);
                }
            }
        }
        return dp[n][m];
    }
}
```

```C
int cmpInt(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

int cmpFactory(const void* a, const void* b) {
    return ((*(int**)a)[0] - (*(int**)b)[0]);
}

long long minimumTotalDistance(int* robot, int robotSize, int** factory, int factorySize, int* factoryColSize) {
    qsort(robot, robotSize, sizeof(int), cmpInt);
    qsort(factory, factorySize, sizeof(int*), cmpFactory);
    int n = robotSize, m = factorySize;
    long long** dp = (long long**)malloc((n + 1) * sizeof(long long*));
    for (int i = 0; i <= n; i++) {
        dp[i] = (long long*)malloc((m + 1) * sizeof(long long));
        for (int j = 0; j <= m; j++) {
            dp[i][j] = i == 0 ? 0 : LLONG_MAX / 2;
        }
    }
    for (int j = 1; j <= m; j++) {
        for (int i = 1; i <= n; i++) {
            dp[i][j] = dp[i][j - 1];
            long long cost = 0;
            int lim = i < factory[j - 1][1] ? i : factory[j - 1][1];
            for (int k = 1; k <= lim; k++) {
                long long d = (long long)robot[i - k] - factory[j - 1][0];
                cost += llabs(d);
                if (dp[i - k][j - 1] + cost < dp[i][j]) {
                    dp[i][j] = dp[i - k][j - 1] + cost;
                }
            }
        }
    }
    long long ans = dp[n][m];
    for (int i = 0; i <= n; i++) {
        free(dp[i]);
    }
    free(dp);
    return ans;
}
```

```Rust
impl Solution {
    pub fn minimum_total_distance(mut robot: Vec<i32>, mut factory: Vec<Vec<i32>>) -> i64 {
        robot.sort();
        factory.sort();
        let n = robot.len();
        let m = factory.len();
        let mut dp = vec![vec![i64::MAX / 2; m + 1]; n + 1];
        for j in 0..=m {
            dp[0][j] = 0;
        }
        for j in 1..=m {
            for i in 1..=n {
                dp[i][j] = dp[i][j - 1];
                let mut cost: i64 = 0;
                let lim = i.min(factory[j - 1][1] as usize);
                for k in 1..=lim {
                    cost += (robot[i - k] as i64 - factory[j - 1][0] as i64).abs();
                    dp[i][j] = dp[i][j].min(dp[i - k][j - 1] + cost);
                }
            }
        }
        dp[n][m]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\times m\times L+n\log n+m\log m)$，其中 $n$ 是机器人数量，$m$ 是工厂数量，$L$ 是单个工厂的最大修理上限。
- 空间复杂度：$O(n\times m)$，用于存储动态规划结果数组。
