### [统计所有可行路径](https://leetcode.cn/problems/count-all-possible-routes/solutions/441176/tong-ji-suo-you-ke-xing-lu-jing-by-leetcode-soluti/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：记忆化搜索

**思路与算法**

我们用 $f[pos][rest]$ 表示**当我们当前位于第 $pos$ 个城市，剩余的汽油量为 $rest$ 时，到达终点 $finish$ 的可能的路径总数**。

在进行状态转移时，我们可以枚举下一个到达的城市 $i$，其中 $i\ne pos$。从城市 $pos$ 前往城市 $i$ 消耗的汽油量为 $cost_{pos,i}=\vert locations[pos]-locations[i]\vert $，这个值不能超过当前剩余的汽油量 $rest$。因此我们可以得到状态转移方程：

$$f[pos][rest]=\sum\limits_{i=0}^{n-1}f[i][rest-cost_{pos,i}]\enspace其中\enspace rest>cost_{pos,i}$$

如果我们当前就在终点，即 $pos=finish$，那么我们不再进行移动也是一种可行的方案。此时，我们需要将 $f[pos][rest]$ 额外增加 $1$。

由于状态表示中的第二维 $rest$ 是不断减小的，因此使用自顶向下的记忆化搜索，相较于使用多重循环的动态规划更加方便。

最终的答案即为 $f[start][fuel]$。

**优化**

注意到「两点之间，线段最短」，因此从当前城市 $pos$ 到达终点 $finish$ 的最小汽油消耗量就是 $costpos,finish$。如果这个值大于剩余的汽油量 $rest$，那么我们可以在直接记忆化搜索中记录并返回 $f[pos][rest]=0$。

注意：该优化可以降低运行时间，但不会减少时间复杂度。

**代码**

```C++
class Solution {
private:
    static constexpr int mod = 1000000007;
    vector<vector<int>> f;

public:
    int dfs(const vector<int>& locations, int pos, int finish, int rest) {
        if (f[pos][rest] != -1) {
            return f[pos][rest];
        }

        f[pos][rest] = 0;
        if (abs(locations[pos] - locations[finish]) > rest) {
            return 0;
        }

        int n = locations.size();
        for (int i = 0; i < n; ++i) {
            if (pos != i) {
                if (int cost = abs(locations[pos] - locations[i]); cost <= rest) {
                    f[pos][rest] += dfs(locations, i, finish, rest - cost);
                    f[pos][rest] %= mod;
                }
            }
        }
        if (pos == finish) {
            f[pos][rest] += 1;
            f[pos][rest] %= mod;
        }
        return f[pos][rest];
    }

    int countRoutes(vector<int>& locations, int start, int finish, int fuel) {
        f.assign(locations.size(), vector<int>(fuel + 1, -1));
        return dfs(locations, start, finish, fuel);
    }
};
```

```Java
class Solution {
    static final int MOD = 1000000007;
    int[][] f;

    public int countRoutes(int[] locations, int start, int finish, int fuel) {
        f = new int[locations.length][fuel + 1];
        for (int[] row : f) {
            Arrays.fill(row, -1);
        }
        return dfs(locations, start, finish, fuel);
    }

    public int dfs(int[] locations, int pos, int finish, int rest) {
        if (f[pos][rest] != -1) {
            return f[pos][rest];
        }

        f[pos][rest] = 0;
        if (Math.abs(locations[pos] - locations[finish]) > rest) {
            return 0;
        }

        int n = locations.length;
        for (int i = 0; i < n; ++i) {
            if (pos != i) {
                int cost;
                if ((cost = Math.abs(locations[pos] - locations[i])) <= rest) {
                    f[pos][rest] += dfs(locations, i, finish, rest - cost);
                    f[pos][rest] %= MOD;
                }
            }
        }
        if (pos == finish) {
            f[pos][rest] += 1;
            f[pos][rest] %= MOD;
        }
        return f[pos][rest];
    }
}
```

```Python
class Solution:
    def countRoutes(self, locations: List[int], start: int, finish: int, fuel: int) -> int:
        n = len(locations)

        @lru_cache(None)
        def dfs(pos, rest):
            if abs(locations[pos] - locations[finish]) > rest:
                return 0

            ans = 0
            for i, loc in enumerate(locations):
                if pos != i:
                    cost = abs(locations[pos] - loc)
                    if cost <= rest:
                        ans += dfs(i, rest - cost)
            if pos == finish:
                ans += 1
            return ans % 1000000007

        return dfs(start, fuel)
```

```C
int mod = 1000000007;

int f[101][201];

int dfs(int* locations, int locationsSize, int pos, int finish, int rest) {
    if (f[pos][rest] != -1) {
        return f[pos][rest];
    }

    f[pos][rest] = 0;
    if (abs(locations[pos] - locations[finish]) > rest) {
        return 0;
    }

    for (int i = 0; i < locationsSize; ++i) {
        if (pos != i) {
            int cost = abs(locations[pos] - locations[i]);
            if (cost <= rest) {
                f[pos][rest] += dfs(locations, locationsSize, i, finish, rest - cost);
                f[pos][rest] %= mod;
            }
        }
    }
    if (pos == finish) {
        f[pos][rest] += 1;
        f[pos][rest] %= mod;
    }
    return f[pos][rest];
}

int countRoutes(int* locations, int locationsSize, int start, int finish, int fuel) {
    memset(f, -1, sizeof(f));
    return dfs(locations, locationsSize, start, finish, fuel);
}
```

**复杂度分析**

- 时间复杂度：$O(n^2\cdot fuel)$，其中 $n$ 是数组 $locations$ 的长度。状态的数量为 $O(n\cdot fuel)$，对于每个状态，我们需要 $O(n)$ 的时间进行转移，相乘即可得到时间复杂度。
- 空间复杂度：$O(n\cdot fuel)$，即为状态的数量。

#### 方法二：优化的动态规划

**说明**

本方法为进阶方法，有较高的思维难度。

**思路与算法**

我们可以将所有城市看成数轴上的 $n$ 个点，这样每一条从起点到终点的路径就可以看成是如下的形式：

- 我们从起点开始沿着某个方向（数轴的正方向或负方向均可）移动到另一个点；
- 随后我们改变方向（折返），移动到另一个点；
- 重复上述的折返若干次，当到达终点时结束。

也就是说，对于每一条路径，我们可以看作是**从起点到终点的若干次折返**。因此我么可以考虑这样定义状态：令 $dp_L[city][used]$ 表示**从起点到达城市 $city$，消耗的汽油量为 $used$ 并且最后一次折返的方向是数轴的负方向，满足要求的路径数目**；同样地，令 $dp_R[city][used]$ 表示**从起点到达城市 $city$，消耗的汽油量为 $used$，并且最后一次折返的方向是数轴的正方向，满足要求的路径数目**。

那么我们如何进行转移呢？我们考虑 $dp_L[city][used]$，由于最后一次折返的方向是数轴的负方向，因此上一个到达的城市 $city^′$ 的位置一定在 $city$ 的右侧，那么 $dp_L[city][used]$ 会从所有满足 $locations[city^′]>locations[city]$ 且 $dist(city,city^′)\le used$ 的 $dp_R[city][used-dist(city,city^′)]$ 转移而来，其中 $dist(city,city^′)$ 表示两个城市之间的距离。为了方便进行转移，我们不如将数组 $locations$ 进行升序排序，并且将起点和终点重新进行编号，这样所有满足 $locations[city^′]>locations[city]$ 的城市 $city^′$ 就是数组中在 $city$ 右侧的城市。

在转移时，考虑从 $dp_R[city][used-dist(city,city^′)]$ 转移到 $dp_L[city][used]$，我们从城市 city^′ 向数轴负方向到达城市 $city$，途中的城市个数为 $city-city^′-1$，每个城市我们可以选择停留或者不停留，满足要求的路径数为

$$2^{city^′-city-1}$$

根据乘法原理，因此我们可以得到状态转移方程：

$$dp_L[city][used]=\sum\limits_{city^′=city+1}^{n-1}dp_R[city^′][used-dist(city,city^′)]\times 2^{city^′-city-1}$$

同理，根据对偶性，我们可以得到 $dp_R$ 的状态转移方程：

$$dp_R[city][used]=\sum\limits_{city^′=0}^{city-1}dp_L[city^′][used-dist(city,city^′)]\times 2^{city-city^′-1}$$

状态的数目为 $O(n\cdot fuel)$，转移的时间复杂度为 $O(n)$，因此总时间复杂度为 $O(n^2\cdot fuel)$，与方法一相同。然而我们可以对该方法进行优化，考虑将上述 $dp_L$ 的状态转移方程提出第一项：

$$\begin{array}{rcl}dp_L[city][used] & = & dp_R[city+1][used-dist(city,city+1)]\\ & + & \sum\limits_{city^′=city+2}^{n-1}dp_R[city^′][used-dist(city,city^′)]\times 2^{city^′-city-1}\end{array}$$

这里需要满足 $city\ne n-1$。当 $city=n-1$ 且 $used\ne 0$ 时，$dp_L[city][used]=0$ 恒成立，我们不需要进行任何处理。

观察剩余的项，它和原状态转移方程很相似，即

$$dp_L[city+1][used-dist(city,city+1)]\\ \hspace{21em}=\sum\limits_{city^′=city+2}^{n-1}dp_R[city^′][used-dist(city,city^′)]\times 2^{city^′-city-2}$$

因此有

$$\begin{array}{rcl}dp_L[city][used]& =& dp_R[city+1][used-dist(city,city+1)]\\ & + & dp_L[city+1][used-dist(city,city+1)]\times 2\end{array}$$

同理，根据对偶性，我们可以优化 $dp_R$ 的状态转移方程：

$$\begin{array}{rcl}dp_R[city][used] & = & dp_L[city-1][used-dist(city,city-1)]\\ & + & dp_R[city-1][used-dist(city,city-1)]\times 2\end{array}$$

这样转移的时间减少为 $O(1)$，总时间复杂度为 $O(n\cdot fuel)$。

**细节**

处理边界条件需要一些抽象思维

$$dp_L[start][0]=dp_R[start][0]=1$$

也就是说，我们从起点开始，无论最后一步往负方向（为下一步的正方向做铺垫）还是正方向（为下一步的负方向做铺垫）都有基础的 $1$ 条路径。然而这个边界条件会对状态转移带来一些麻烦。观察上述的状态转移方程，$dp_L[city][used]$ 会从 $dp_L[city+1][used-dist(city,city+1)]$ 转移而来，并且乘以系数 $2$，这里我们是希望**我们是沿着负方向经过 $city+1$ 再到达 $city$，并且城市 $city+1$ 可以选择停留或不停留**。如果此时 $city+1=start$ 并且 $used-dist(city,city+1)=0$，这样就会从边界条件转移而来，而实际上**边界条件的方向只是为了下一次折返进行铺垫，而不是真的从那个方向折返**，因此**边界条件对应的状态不能作为系数为 $2$ 的这一项转移而来**。因此，我们的状态转移方程需要写成：

$$dp_L[city][used]=dp_R[city+1][used-dist(city,city+1)]\\ \hspace{15em}+\begin{cases}dp_L[city+1][used-dist(city,city+1)]\times 2, & used>dist(city,city+1)\\ 0, & used=dist(city,city+1)\end{cases}$$

以及

$$dp_R[city][used]=dp_L[city-1][used-dist(city,city-1)]\\ \hspace{15em}+\begin{cases}dp_R[city-1][used-dist(city,city-1)]\times 2, & used>dist(city,city-1)\\ 0, & used=dist(city,city-1)\end{cases}$$

最终的答案即为所有 $dp_L[finish][used]$ 与 $dp_R[finish][used]$ 的和。注意当 $start=finish$ 时，边界条件（即不移动也算一套路径）会被计算 $2$ 次，因此需要将答案减 $1$。

**代码**

```C++
class Solution {
private:
    static constexpr int mod = 1000000007;

public:
    int countRoutes(vector<int>& locations, int start, int finish, int fuel) {
        int n = locations.size();
        int startPos = locations[start];
        int finishPos = locations[finish];
        sort(locations.begin(), locations.end());
        for (int i = 0; i < n; ++i) {
            if (startPos == locations[i]) {
                start = i;
            }
            if (finishPos == locations[i]) {
                finish = i;
            }
        }

        vector<vector<int>> dpL(n, vector<int>(fuel + 1));
        vector<vector<int>> dpR(n, vector<int>(fuel + 1));
        dpL[start][0] = dpR[start][0] = 1;

        for (int used = 0; used <= fuel; ++used) {
            for (int city = n - 2; city >= 0; --city) {
                if (int delta = locations[city + 1] - locations[city]; used >= delta) {
                    dpL[city][used] = ((used == delta ? 0 : dpL[city + 1][used - delta]) * 2 % mod + dpR[city + 1][used - delta]) % mod;
                }
            }
            for (int city = 1; city < n; ++city) {
                if (int delta = locations[city] - locations[city - 1]; used >= delta) {
                    dpR[city][used] = ((used == delta ? 0 : dpR[city - 1][used - delta]) * 2 % mod + dpL[city - 1][used - delta]) % mod;
                }
            }
        }

        int ans = 0;
        for (int used = 0; used <= fuel; ++used) {
            ans += (dpL[finish][used] + dpR[finish][used]) % mod;
            ans %= mod;
        }
        if (start == finish) {
            ans = (ans + mod - 1) % mod;
        }
        return ans;
    }
};
```

```Java
class Solution {
    static final int MOD = 1000000007;

    public int countRoutes(int[] locations, int start, int finish, int fuel) {
        int n = locations.length;
        int startPos = locations[start];
        int finishPos = locations[finish];
        Arrays.sort(locations);
        for (int i = 0; i < n; ++i) {
            if (startPos == locations[i]) {
                start = i;
            }
            if (finishPos == locations[i]) {
                finish = i;
            }
        }

        int[][] dpL = new int[n][fuel + 1];
        int[][] dpR = new int[n][fuel + 1];
        dpL[start][0] = dpR[start][0] = 1;

        for (int used = 0; used <= fuel; ++used) {
            for (int city = n - 2; city >= 0; --city) {
                int delta = locations[city + 1] - locations[city];
                if (used >= delta) {
                    dpL[city][used] = ((used == delta ? 0 : dpL[city + 1][used - delta]) * 2 % MOD + dpR[city + 1][used - delta]) % MOD;
                }
            }
            for (int city = 1; city < n; ++city) {
                int delta = locations[city] - locations[city - 1];
                if (used >= delta) {
                    dpR[city][used] = ((used == delta ? 0 : dpR[city - 1][used - delta]) * 2 % MOD + dpL[city - 1][used - delta]) % MOD;
                }
            }
        }

        int ans = 0;
        for (int used = 0; used <= fuel; ++used) {
            ans += (dpL[finish][used] + dpR[finish][used]) % MOD;
            ans %= MOD;
        }
        if (start == finish) {
            ans = (ans + MOD - 1) % MOD;
        }
        return ans;
    }
}
```

```Python
class Solution:
    def countRoutes(self, locations: List[int], start: int, finish: int, fuel: int) -> int:
        mod = 10**9 + 7

        n = len(locations)
        startPos = locations[start]
        finishPos = locations[finish]
        locations.sort()
        start = locations.index(startPos)
        finish = locations.index(finishPos)

        dpL = [[0] * (fuel + 1) for _ in range(n)]
        dpR = [[0] * (fuel + 1) for _ in range(n)]
        dpL[start][0] = dpR[start][0] = 1

        for used in range(fuel + 1):
            for city in range(n - 2, -1, -1):
                if (delta := locations[city + 1] - locations[city]) <= used:
                    dpL[city][used] = ((0 if used == delta else dpL[city + 1][used - delta]) * 2 + dpR[city + 1][used - delta]) % mod
            for city in range(1, n):
                if (delta := locations[city] - locations[city - 1]) <= used:
                    dpR[city][used] = ((0 if used == delta else dpR[city - 1][used - delta]) * 2 + dpL[city - 1][used - delta]) % mod

        ans = sum(dpL[finish]) + sum(dpR[finish])
        if start == finish:
            ans -= 1
        return ans % mod
```

```C
int cmp(const void* _a, const void* _b) {
    int *a = (int*)_a, *b = (int*)_b;
    return *a - *b;
}

int countRoutes(int* locations, int locationsSize, int start, int finish, int fuel) {
    int mod = 1000000007;
    int startPos = locations[start];
    int finishPos = locations[finish];
    qsort(locations, locationsSize, sizeof(int), cmp);
    for (int i = 0; i < locationsSize; ++i) {
        if (startPos == locations[i]) {
            start = i;
        }
        if (finishPos == locations[i]) {
            finish = i;
        }
    }

    int dpL[locationsSize][fuel + 1];
    int dpR[locationsSize][fuel + 1];
    memset(dpL, 0, sizeof(dpL));
    memset(dpR, 0, sizeof(dpR));
    dpL[start][0] = dpR[start][0] = 1;

    for (int used = 0; used <= fuel; ++used) {
        for (int city = locationsSize - 2; city >= 0; --city) {
            int delta = locations[city + 1] - locations[city];
            if (used >= delta) {
                dpL[city][used] = ((used == delta ? 0 : dpL[city + 1][used - delta]) * 2 % mod + dpR[city + 1][used - delta]) % mod;
            }
        }
        for (int city = 1; city < locationsSize; ++city) {
            int delta = locations[city] - locations[city - 1];
            if (used >= delta) {
                dpR[city][used] = ((used == delta ? 0 : dpR[city - 1][used - delta]) * 2 % mod + dpL[city - 1][used - delta]) % mod;
            }
        }
    }

    int ans = 0;
    for (int used = 0; used <= fuel; ++used) {
        ans += (dpL[finish][used] + dpR[finish][used]) % mod;
        ans %= mod;
    }
    if (start == finish) {
        ans = (ans + mod - 1) % mod;
    }
    return ans;
}
```

**复杂度分析**

- 时间复杂度：$O(n\cdot fuel)$，其中 $n$ 是数组 $locations$ 的长度。状态的数量为 $O(n\cdot fuel)$，对于每个状态，我们只需要 $O(1)$ 的时间进行转移。
- 空间复杂度：$O(n\cdot fuel)$，即为状态的数量。
