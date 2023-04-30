#### [前言](https://leetcode.cn/problems/count-subtrees-with-max-distance-between-cities/solutions/2161714/tong-ji-zi-shu-zhong-cheng-shi-zhi-jian-duoq1/)

树上任意两节点之间最长的简单路径即为树的「直径」，可以参考「[树的直径](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgraph%2Ftree-diameter%2F)」、「[二叉树的直径](https://leetcode.cn/problems/diameter-of-binary-tree/solutions/139683/er-cha-shu-de-zhi-jing-by-leetcode-solution/)」等相关解法。一颗树可以有多条直径，但直径的长度都是一样的，计算树的直径长度有常见的两种方法:

-   动态规划：我们记录当 $root$ 为树的根时，每个节点作为子树的根向下，所能延伸的最远距离 $d_1$ 和次远距离 $d_2$，那么直径的长度就是所有 $d_1 + d_2$ 的最大值。
-   深度优先搜索：首先从任意节点 $x$ 开始进行第一次深度优先搜索，到达距离其最远的节点，记为 $y$，然后再从 $y$ 开始做第二次深度优先搜索，到达距离 $y$ 最远的节点，记为 $z$，则 $\delta(y,z)$ 即为树的直径，节点 $y$ 与 节点 $z$ 之间的距离即为直径的长度。

#### [方法一：动态规划](https://leetcode.cn/problems/count-subtrees-with-max-distance-between-cities/solutions/2161714/tong-ji-zi-shu-zhong-cheng-shi-zhi-jian-duoq1/)

**思路与算法**

题目要求找到城市间最大距离恰好为 $d$ 的所有子树数目，子树中的任意两个节点的最大距离即为「[树的直径](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgraph%2Ftree-diameter%2F)」。根据题意可以知道城市是一个含有 $n$ 个节点的无向连通图，且该图中只含有 $n-1$ 条边，最大距离为 $d$ 子树需要满足以下条件：

-   该子树为该无向图中的一个连通单元；
-   该子树的直径长度为 $d$；

根据以上提示，我们只需计算出图中所有连通子树的直径即可。由于图中的节点数 $n$ 的取值范围为 $1 \le n \le 16$，我们采用状态压缩的思想，用二进制掩码 $mask$ 来表示图中的一个子树，枚举所有可能的子树，并检测该子树的连通性。如果该子树为一个连通单元，则计算该子树的直径即可。对于枚举的子树都需要进行如下计算：

-   检测树的连通性：此时可以通过深度优先搜索或者广度优先搜索来检测连通性即可，从任意节点 $root$ 出发，子树中所有的节点均可达；
-   计算树的直径：在此方法中我们采用树形动态规划的方式计算树的直径即可。每次计算以当前节点为根节点形成的子树向下延伸的最远距离 $first$ 与次远距离 $second$，计算所有的 $first + second$ 的最大值即可。

我们统计所有子树的直径的不同计数，并返回结果即可。

**代码**

```cpp
class Solution {
public:      
    vector<int> countSubgraphsForEachDiameter(int n, vector<vector<int>>& edges) {
        vector<vector<int>> adj(n);        
        for (auto &edge : edges) {
            int x = edge[0] - 1;
            int y = edge[1] - 1;
            adj[x].emplace_back(y);
            adj[y].emplace_back(x);
        }
        function<int(int, int&, int&)> dfs = [&](int root, int& mask, int& diameter)->int {
            int first = 0, second = 0;
            mask &= ~(1 << root);
            for (int vertex : adj[root]) {
                if (mask & (1 << vertex)) {
                    mask &= ~(1 << vertex);
                    int distance = 1 + dfs(vertex, mask, diameter);
                    if (distance > first) {
                        second = first;
                        first = distance;
                    } else if (distance > second) {
                        second = distance;
                    }
                }
            }
            diameter = max(diameter, first + second);
            return first;
        };

        vector<int> ans(n - 1);
        for (int i = 1; i < (1 << n); i++) {
            int root = 32 - __builtin_clz(i) - 1;
            int mask = i;
            int diameter = 0;
            dfs(root, mask, diameter);
            if (mask == 0 && diameter > 0) {
                ans[diameter - 1]++;
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    int mask;
    int diameter;

    public int[] countSubgraphsForEachDiameter(int n, int[][] edges) {
        List<Integer>[] adj = new List[n];
        for (int i = 0; i < n; i++) {
            adj[i] = new ArrayList<Integer>();
        }
        for (int[] edge : edges) {
            int x = edge[0] - 1;
            int y = edge[1] - 1;
            adj[x].add(y);
            adj[y].add(x);
        }

        int[] ans = new int[n - 1];
        for (int i = 1; i < (1 << n); i++) {
            int root = 32 - Integer.numberOfLeadingZeros(i) - 1;
            mask = i;
            diameter = 0;
            dfs(root, adj);
            if (mask == 0 && diameter > 0) {
                ans[diameter - 1]++;
            }
        }
        return ans;
    }

    public int dfs(int root, List<Integer>[] adj) {
        int first = 0, second = 0;
        mask &= ~(1 << root);
        for (int vertex : adj[root]) {
            if ((mask & (1 << vertex)) != 0) {
                mask &= ~(1 << vertex);
                int distance = 1 + dfs(vertex, adj);
                if (distance > first) {
                    second = first;
                    first = distance;
                } else if (distance > second) {
                    second = distance;
                }
            }
        }
        diameter = Math.max(diameter, first + second);
        return first;
    }
}
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int dfs(int root, int* mask, int* diameter, int **adj, int *adjColSize) {
    int first = 0, second = 0;
    (*mask) &= ~(1 << root);
    for (int i = 0; i < adjColSize[root]; i++) {
        int vertex = adj[root][i];
        if ((*mask) & (1 << vertex)) {
            (*mask) &= ~(1 << vertex);
            int distance = 1 + dfs(vertex, mask, diameter, adj, adjColSize);
            if (distance > first) {
                second = first;
                first = distance;
            } else if (distance > second) {
                second = distance;
            }
        }
    }
    *diameter = MAX(*diameter, first + second);
    return first;
}

int* countSubgraphsForEachDiameter(int n, int** edges, int edgesSize, int* edgesColSize, int* returnSize) {
    int *adj[n];
    int adjColSize[n];
    for (int i = 0; i < n; i++) {
        adj[i] = (int*)calloc(n, sizeof(int));;
    }
    memset(adjColSize, 0, sizeof(adjColSize));
    for (int i = 0; i < edgesSize; i++) {
        int x = edges[i][0] - 1;
        int y = edges[i][1] - 1;
        adj[x][adjColSize[x]++] = y;
        adj[y][adjColSize[y]++] = x;
    }
    int *ans = (int *)calloc(n - 1, sizeof(int));
    for (int i = 1; i < (1 << n); i++) {
        int root = 32 - __builtin_clz(i) - 1;
        int mask = i;
        int diameter = 0;
        dfs(root, &mask, &diameter, adj, adjColSize);
        if (mask == 0 && diameter > 0) {
            ans[diameter - 1]++;
        }
    }
    for (int i = 0; i < n; i++) {
        free(adj[i]);
    }
    *returnSize = n - 1;
    return ans;
}
```

```javascript
var countSubgraphsForEachDiameter = function(n, edges) {
    const adj = new Array(n).fill(0);
    for (let i = 0; i < n; i++) {
        adj[i] = [];
    }
    for (const edge of edges) {
        const x = edge[0] - 1;
        const y = edge[1] - 1;
        adj[x].push(y);
        adj[y].push(x);
    }

    const ans = new Array(n - 1).fill(0);
    for (let i = 1; i < (1 << n); i++) {
        const root = 32 - numberOfLeadingZeros(i) - 1;
        mask = i;
        diameter = 0;
        dfs(root, adj);
        if (mask === 0 && diameter > 0) {
            ans[diameter - 1]++;
        }
    }
    return ans;
}

const dfs = (root, adj) => {
    let first = 0, second = 0;
    mask &= ~(1 << root);
    for (const vertex of adj[root]) {
        if ((mask & (1 << vertex)) !== 0) {
            mask &= ~(1 << vertex);
            const distance = 1 + dfs(vertex, adj);
            if (distance > first) {
                second = first;
                first = distance;
            } else if (distance > second) {
                second = distance;
            }
        }
    }
    diameter = Math.max(diameter, first + second);
    return first;
};

const numberOfLeadingZeros = (i) => {
    if (i === 0)
        return 32;
    let n = 1;
    if (i >>> 16 === 0) { n += 16; i <<= 16; }
    if (i >>> 24 === 0) { n +=  8; i <<=  8; }
    if (i >>> 28 === 0) { n +=  4; i <<=  4; }
    if (i >>> 30 === 0) { n +=  2; i <<=  2; }
    n -= i >>> 31;
    return n;
}
```

**复杂度分析**

-   时间复杂度：$O(n \times 2^n)$，其中 $n$ 表示给定的城市的数目。我们枚举图中所有可能的子树，一共最多有 $2^n$ 个子树，检测子树的连通性与计算子树的直径需要的时间为 $O(n)$，因此总的时间复杂度为 $O(n \times 2^n)$。
-   空间复杂度：$O(n)$，其中 $n$ 表示给定的城市的数目。我们需要存储图的邻接关系，由于图中只有 $n-1$ 条边，存储图的邻接关系需要的空间为 $O(n)$，每次递归求树的直径中递归的最大深度为 $n$，因此总的空间复杂度为 $O(n)$。
