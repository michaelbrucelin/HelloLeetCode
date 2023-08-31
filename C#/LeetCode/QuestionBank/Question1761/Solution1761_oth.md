### [给无向图定向](https://leetcode.cn/problems/minimum-degree-of-a-connected-trio-in-a-graph/solutions/603198/gei-wu-xiang-tu-ding-xiang-by-lucifer100-c72d/)

### 方法一：暴力

数据范围$N\leq400$是一个典型的$\mathcal{O}(N^3)$范围，所以直接暴力枚举三元组即可。

为了快速判断连通性，可以先把边集转为邻接矩阵。同时我们统计每个点的度数，方便最后计算总度数（对于一个连通三元组，总度数为三个点的总度数减去它们内部的度数，也就是$2 \times 3=6$）。

-   时间复杂度$\mathcal{O}(N^3)$。
-   空间复杂度$\mathcal{O}(N^2)$。

```cpp
class Solution {
public:
    int minTrioDegree(int n, vector<vector<int>>& edges) {
        vector<vector<bool>> d(n, vector<bool>(n));
        vector<int> deg(n);
        for (auto &e : edges) {
            d[e[0] - 1][e[1] - 1] = d[e[1] - 1][e[0] - 1] = true;
            deg[e[0] - 1]++;
            deg[e[1] - 1]++;
        }
        int ans = INT_MAX;
        for (int i = 0; i < n; ++i)
            for (int j = i + 1; j < n; ++j) {
                if (!d[i][j])
                    continue;
                for (int k = j + 1; k < n; ++k) {
                    if (d[i][k] && d[j][k]) 
                        ans = min(ans, deg[i] + deg[j] + deg[k] - 6);
                }
            }
        return ans == INT_MAX ? -1 : ans;
    }
};
```

### 方法二：给无向图定向

考虑更大的数据范围$N \leq 2\times10^5,M\leq\min(\frac{N(N-1)}{2},2\times10^5)$。此时上面的暴力解法显然不再成立。

一个可行的做法是给无向图定向。这里需要用到一些推导。

-   我们把所有边的方向定为从度数小的点连向度数大的点（如果度数相等则可以任意连接，下面的参考代码中是从标号小的连向标号大的）。
-   可以证明，此时任意点的出度不会超过$\sqrt{2M}$。因为如果一个点的出度超过了$\sqrt{2M}$，则由于我们上面的规则，可知这些点的度数也都大于$\sqrt{2M}$，从而这些点的总度数将超过$2M$，而这是不可能的。

有了这一保证，我们就可以逐个枚举第一个点$u$，枚举其所有相邻点$v$，然后枚举$v$的所有相邻点$w$，检查$u,v,w$是否能构成连通三元组，然后更新答案。

总复杂度是多少呢？枚举$u$和$v$的时间复杂度是$\mathcal{O}(M)$；而对于每一对$(u,v)$，由于$v$的出度不超过$\sqrt{2M}$，所以枚举$w$的时间复杂度是$\mathcal{O}(\sqrt{M})$。

-   时间复杂度$\mathcal{O}(M^{\frac{3}{2}})$。
-   空间复杂度$\mathcal{O}(N+M)$。

```cpp
class Solution {
public:
    int minTrioDegree(int n, vector<vector<int>>& edges) {
        vector<unordered_set<int>> d(n);
        for (auto &e : edges) {
            int u = e[0] - 1, v = e[1] - 1;
            d[u].insert(v), d[v].insert(u);
        }
        
        vector<vector<int>> adj(n);
        for (auto &e : edges) {
            int u = e[0] - 1, v = e[1] - 1;
            if (d[u].size() < d[v].size() || (d[u].size() == d[v].size() && u < v))
                adj[u].emplace_back(v);
            else
                adj[v].emplace_back(u);
        }

        int ans = INT_MAX;
        for (int u = 0; u < n; ++u)
            for (int v : adj[u])
                for (int w : adj[v])
                    if (d[u].count(w))
                        ans = min(ans, (int)(d[u].size() + d[v].size() + d[w].size() - 6));
        
        return ans == INT_MAX ? -1 : ans;
    }
};
```
