#### [两种写法：哈希表（数组）/位运算（Python/Java/C++/Go）](https://leetcode.cn/problems/flower-planting-with-no-adjacent/solutions/2227318/liang-chong-xie-fa-ha-xi-biao-shu-zu-wei-7hm8/)

出题人可能是受到 [四色定理](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E5%9B%9B%E8%89%B2%E5%AE%9A%E7%90%86%2F805159) 的启发出的题。

问题相当于用 $4$ 种颜色给图中的每个节点染色，要求相邻节点颜色不同。而「所有花园最多有 $3$ 条路径可以进入或离开」，这相当于图中每个点的度数至多为 $3$，那么只要选一个和邻居不同的颜色即可。

#### 哈希表（数组）实现

```python
class Solution:
    def gardenNoAdj(self, n: int, paths: List[List[int]]) -> List[int]:
        g = [[] for _ in range(n)]
        for u, v in paths:
            g[u - 1].append(v - 1)
            g[v - 1].append(u - 1)  # 建图
        color = [0] * n
        for i, nodes in enumerate(g):
            color[i] = (set(range(1, 5)) - {color[j] for j in nodes}).pop()
        return color
```

```java
class Solution {
    public int[] gardenNoAdj(int n, int[][] paths) {
        List<Integer> g[] = new ArrayList[n];
        Arrays.setAll(g, e -> new ArrayList<>());
        for (var e : paths) {
            int x = e[0] - 1, y = e[1] - 1; // 编号改从 0 开始
            g[x].add(y);
            g[y].add(x); // 建图
        }
        var color = new int[n];
        for (int i = 0; i < n; ++i) {
            var used = new boolean[5];
            for (var j : g[i])
                used[color[j]] = true;
            while (used[++color[i]]);
        }
        return color;
    }
}
```

```cpp
class Solution {
public:
    vector<int> gardenNoAdj(int n, vector<vector<int>> &paths) {
        vector<vector<int>> g(n);
        for (auto &e: paths) {
            int x = e[0] - 1, y = e[1] - 1; // 编号改从 0 开始
            g[x].push_back(y);
            g[y].push_back(x); // 建图
        }
        vector<int> color(n);
        for (int i = 0; i < n; ++i) {
            bool used[5]{};
            for (int j: g[i])
                used[color[j]] = true;
            while (used[++color[i]]);
        }
        return color;
    }
};
```

```go
func gardenNoAdj(n int, paths [][]int) []int {
    g := make([][]int, n)
    for _, e := range paths {
        x, y := e[0]-1, e[1]-1 // 编号改从 0 开始
        g[x] = append(g[x], y)
        g[y] = append(g[y], x) // 建图
    }
    color := make([]int, n)
    for i, nodes := range g {
        used := [5]bool{}
        for _, j := range nodes {
            used[color[j]] = true
        }
        for color[i]++; used[color[i]]; color[i]++ {
        }
    }
    return color
}
```

#### 位运算实现

集合（或者布尔数组）可以用二进制表示，二进制从低到高第 $i$ 位为 $1$ 表示 $i$ 在集合中，为 $0$ 表示 $i$ 不在集合中。例如集合 ${0,2,3}$ 对应的二进制数为 $1101_{(2)}$。

下面代码用到的位运算技巧：

1.  把 $x$ 添加到 $mask$ 中：将 `mask` 更新为 `mask | (1 << x)`。
2.  找到 $mask$ 从低到高第一个 $0$ 的位置：计算 $mask$ 取反后的尾零个数。例如 $mask=10111_{(2)}$，取反后变为 $1000_{(2)}$（实际前导零也取反了，但不影响计算），尾零个数为 $3$，这恰好就是从低到高第一个 $0$ 的位置。

```python
class Solution:
    def gardenNoAdj(self, n: int, paths: List[List[int]]) -> List[int]:
        g = [[] for _ in range(n)]
        for u, v in paths:
            g[u - 1].append(v - 1)
            g[v - 1].append(u - 1)  # 建图
        color = [0] * n
        for i, nodes in enumerate(g):
            mask = 1  # 由于颜色是 1~4，把 0 加入 mask 保证下面不会算出 0
            for j in g[i]:
                mask |= 1 << color[j]
            mask = ~mask
            # Python 没有统计尾零的库函数，可以枚举，或者求 lowbit 的二进制长度减一
            color[i] = (mask & -mask).bit_length() - 1
        return color
```

```java
class Solution {
    public int[] gardenNoAdj(int n, int[][] paths) {
        List<Integer> g[] = new ArrayList[n];
        Arrays.setAll(g, e -> new ArrayList<>());
        for (var e : paths) {
            int x = e[0] - 1, y = e[1] - 1; // 编号改从 0 开始
            g[x].add(y);
            g[y].add(x); // 建图
        }
        var color = new int[n];
        for (int i = 0; i < n; ++i) {
            int mask = 1; // 由于颜色是 1~4，把 0 加入 mask 保证下面不会算出 0
            for (var j : g[i])
                mask |= 1 << color[j];
            color[i] = Integer.numberOfTrailingZeros(~mask);
        }
        return color;
    }
}
```

```cpp
class Solution {
public:
    vector<int> gardenNoAdj(int n, vector<vector<int>> &paths) {
        vector<vector<int>> g(n);
        for (auto &e: paths) {
            int x = e[0] - 1, y = e[1] - 1; // 编号改从 0 开始
            g[x].push_back(y);
            g[y].push_back(x); // 建图
        }
        vector<int> color(n);
        for (int i = 0; i < n; ++i) {
            int mask = 1; // 由于颜色是 1~4，把 0 加入 mask 保证下面不会算出 0
            for (int j: g[i])
                mask |= 1 << color[j];
            color[i] = __builtin_ctz(~mask);
        }
        return color;
    }
};
```

```go
func gardenNoAdj(n int, paths [][]int) []int {
    g := make([][]int, n)
    for _, e := range paths {
        x, y := e[0]-1, e[1]-1 // 编号改从 0 开始
        g[x] = append(g[x], y)
        g[y] = append(g[y], x) // 建图
    }
    color := make([]int, n)
    for i, nodes := range g {
        mask := uint8(1) // 由于颜色是 1~4，把 0 加入 mask 保证下面不会算出 0
        for _, j := range nodes {
            mask |= 1 << color[j]
        }
        color[i] = bits.TrailingZeros8(^mask)
    }
    return color
}
```

#### 复杂度分析

-   时间复杂度：$O(n+m)$，其中 $m$ 为 $paths$ 的长度。
-   空间复杂度：$O(n+m)$。
