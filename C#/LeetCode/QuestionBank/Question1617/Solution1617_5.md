#### [����һ��ö���Ӽ�+����ֱ��](https://leetcode.cn/problems/count-subtrees-with-max-distance-between-cities/solutions/2162612/tu-jie-on3-mei-ju-zhi-jing-duan-dian-che-am2n/)

##### ǰ��֪ʶ���Ӽ��ͻ���

�� [78\. �Ӽ�](https://leetcode.cn/problems/subsets/)��

�����[�������㷨���� 14��](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1mG4y1A7Gu%2F)��

> APP �û����Է��� wx ������ӡ�

##### ǰ��֪ʶ����������ֱ��

�� [543\. ��������ֱ��](https://leetcode.cn/problems/diameter-of-binary-tree/)��

�Ƽ������⿪ʼѧϰ���� DP��

����˵����ö�ٴ� $x$ ��������ߵ���������Ҷ����ߵ�����������������ܻ����ֱ����ö�����е���Ϊ $x$ �����ҵ��𰸡�

ÿ���ڵ㶼��Ҫ���ء������ߵ�������Ⱥ������ߵ�������ȵ����ֵ�������ڵ㣬�������ڵ��֪��������ߵ�����ĳ����Ƕ��١�

##### ǰ��֪ʶ������ֱ��

�� [1245\. ����ֱ��](https://leetcode.cn/problems/tree-diameter/)��

���ǵ�������Ҫ��Ա������������Щ������Ŀ��

-   [2246\. �����ַ���ͬ���·��](https://leetcode.cn/problems/longest-path-with-different-adjacent-characters/)
-   [2538\. ����ֵ������С��ֵ�͵Ĳ�ֵ](https://leetcode.cn/problems/difference-between-maximum-and-minimum-price-sum/)

����ֱ������������ DFS �������� DP������ [���� 328](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1QT41127kJ%2F) �ĵ����⽲������ DP ���������ڶ�����ֱ���Ļ����������޸ġ�

##### ˼·

�������� 78 ��� 1245 �⣺ö�ٳ��е��Ӽ����������������������ֱ����

��Ҫע����ǣ�ö�ٵ��Ӽ���һ����һ������������ɭ�֣�������������ͨ�飩�����ǿ����ڼ������� DP ��ͬʱȥͳ�Ʒ��ʹ��ĵ㣬�����Ƿ����Ӽ���ȣ�ֻ����Ȳ���һ������

```python
class Solution:
    def countSubgraphsForEachDiameter(self, n: int, edges: List[List[int]]) -> List[int]:
        # ����
        g = [[] for _ in range(n)]
        for x, y in edges:
            g[x - 1].append(y - 1)
            g[y - 1].append(x - 1)  # ��Ÿ�Ϊ�� 0 ��ʼ

        ans = [0] * (n - 1)
        in_set = [False] * n
        def f(i: int) -> None:
            if i == n:
                vis = [False] * n
                diameter = 0
                for v, b in enumerate(in_set):
                    if not b: continue
                    # ������ֱ��
                    def dfs(x: int) -> int:
                        nonlocal diameter
                        vis[x] = True
                        max_len = 0
                        for y in g[x]:
                            if not vis[y] and in_set[y]:
                                ml = dfs(y) + 1
                                diameter = max(diameter, max_len + ml)
                                max_len = max(max_len, ml)
                        return max_len
                    dfs(v)
                    break
                if diameter and vis == in_set:
                    ans[diameter - 1] += 1
                return
            
            # ��ѡ���� i
            f(i + 1)

            # ѡ����  i
            in_set[i] = True
            f(i + 1)
            in_set[i] = False  # �ָ��ֳ�
        f(0)
        return ans
```

```java
class Solution {
    private List<Integer>[] g;
    private boolean[] inSet, vis;
    private int[] ans;
    private int n, diameter;

    public int[] countSubgraphsForEachDiameter(int n, int[][] edges) {
        this.n = n;
        g = new ArrayList[n];
        Arrays.setAll(g, e -> new ArrayList<>());
        for (var e : edges) {
            int x = e[0] - 1, y = e[1] - 1; // ��Ÿ�Ϊ�� 0 ��ʼ
            g[x].add(y);
            g[y].add(x); // ����
        }

        ans = new int[n - 1];
        inSet = new boolean[n];
        f(0);
        return ans;
    }

    private void f(int i) {
        if (i == n) {
            for (int v = 0; v < n; ++v)
                if (inSet[v]) {
                    vis = new boolean[n];
                    diameter = 0;
                    dfs(v);
                    break;
                }
            if (diameter > 0 && Arrays.equals(vis, inSet))
                ++ans[diameter - 1];
            return;
        }

        // ��ѡ���� i
        f(i + 1);

        // ѡ���� i
        inSet[i] = true;
        f(i + 1);
        inSet[i] = false; // �ָ��ֳ�
    }

    // ������ֱ��
    private int dfs(int x) {
        vis[x] = true;
        int maxLen = 0;
        for (int y : g[x])
            if (!vis[y] && inSet[y]) {
                int ml = dfs(y) + 1;
                diameter = Math.max(diameter, maxLen + ml);
                maxLen = Math.max(maxLen, ml);
            }
        return maxLen;
    }
}
```

```cpp
class Solution {
public:
    vector<int> countSubgraphsForEachDiameter(int n, vector<vector<int>> &edges) {
        vector<vector<int>> g(n);
        for (auto &e : edges) {
            int x = e[0] - 1, y = e[1] - 1; // ��Ÿ�Ϊ�� 0 ��ʼ
            g[x].push_back(y);
            g[y].push_back(x); // ����
        }

        vector<int> ans(n - 1), in_set(n), vis(n);
        int diameter = 0;

        // ������ֱ��
        function<int(int)> dfs = [&](int x) -> int {
            vis[x] = true;
            int max_len = 0;
            for (int y : g[x])
                if (!vis[y] && in_set[y]) {
                    int ml = dfs(y) + 1;
                    diameter = max(diameter, max_len + ml);
                    max_len = max(max_len, ml);
                }
            return max_len;
        };

        function<void(int)> f = [&](int i) {
            if (i == n) {
                for (int v = 0; v < n; ++v)
                    if (in_set[v]) {
                        fill(vis.begin(), vis.end(), 0);
                        diameter = 0;
                        dfs(v);
                        break;
                    }
                if (diameter && vis == in_set)
                    ++ans[diameter - 1];
                return;
            }

            // ��ѡ���� i
            f(i + 1);

            // ѡ���� i
            in_set[i] = true;
            f(i + 1);
            in_set[i] = false; // �ָ��ֳ�
        };
        f(0);
        return ans;
    }
};
```

```go
func countSubgraphsForEachDiameter(n int, edges [][]int) []int {
    // ����
    g := make([][]int, n)
    for _, e := range edges {
        x, y := e[0]-1, e[1]-1 // ��Ÿ�Ϊ�� 0 ��ʼ
        g[x] = append(g[x], y)
        g[y] = append(g[y], x)
    }

    // ������ֱ��
    var inSet, vis [15]bool
    var diameter int
    var dfs func(int) int
    dfs = func(x int) (maxLen int) {
        vis[x] = true
        for _, y := range g[x] {
            if !vis[y] && inSet[y] {
                ml := dfs(y) + 1
                diameter = max(diameter, maxLen+ml)
                maxLen = max(maxLen, ml)
            }
        }
        return
    }

    ans := make([]int, n-1)
    var f func(int)
    f = func(i int) {
        if i == n {
            for v, b := range inSet {
                if b {
                    vis, diameter = [15]bool{}, 0
                    dfs(v)
                    break
                }
            }
            if diameter > 0 && vis == inSet {
                ans[diameter-1]++
            }
            return
        }

        // ��ѡ���� i
        f(i + 1)

        // ѡ���� i
        inSet[i] = true
        f(i + 1)
        inSet[i] = false // �ָ��ֳ�
    }
    f(0)
    return ans
}

func max(a, b int) int { if a < b { return b }; return a }
```

##### ���Ӷȷ���

-   ʱ�临�Ӷȣ�$O(n2^n)$��$O(2^n)$ ö���Ӽ���$O(n)$ ��ֱ��������ʱ�临�Ӷ�Ϊ $O(n2^n)$��
-   �ռ临�Ӷȣ�$O(n)$��

#### [��������������ö��](https://leetcode.cn/problems/count-subtrees-with-max-distance-between-cities/solutions/2162612/tu-jie-on3-mei-ju-zhi-jing-duan-dian-che-am2n/)

��������൱�ڶԷ���һ���Ż���

����/������������ö����Ʊ�ʾ�������ƴӵ͵��ߵ� $i$ λΪ 111 ��ʾ $i$ �ڼ����У�Ϊ 000 ��ʾ $i$ ���ڼ����У����缯�� {0,2,3}\\{0,2,3\\}{0,2,3} ��Ӧ�Ķ�������Ϊ 1101(2)1101\_{(2)}1101(2)��

```python
class Solution:
    def countSubgraphsForEachDiameter(self, n: int, edges: List[List[int]]) -> List[int]:
        # ����
        g = [[] for _ in range(n)]
        for x, y in edges:
            g[x - 1].append(y - 1)
            g[y - 1].append(x - 1)  # ��Ÿ�Ϊ�� 0 ��ʼ

        ans = [0] * (n - 1)
        #  ������ö��
        for mask in range(3, 1 << n):
            if (mask & (mask - 1)) == 0:  # ��Ҫ����������
                continue
            # ������ֱ��
            vis = diameter = 0
            def dfs(x: int) -> int:
                nonlocal vis, diameter
                vis |= 1 << x  # ��� x ���ʹ�
                max_len = 0
                for y in g[x]:
                    if (vis >> y & 1) == 0 and mask >> y & 1:  # y û�з��ʹ����� mask ��
                        ml = dfs(y) + 1
                        diameter = max(diameter, max_len + ml)
                        max_len = max(max_len, ml)
                return max_len
            dfs(mask.bit_length() - 1)  # ��һ���� mask �еĵ㿪ʼ�ݹ�
            if vis == mask:
                ans[diameter - 1] += 1
        return ans
```

```java
class Solution {
    private List<Integer>[] g;
    private int mask, vis, diameter;

    public int[] countSubgraphsForEachDiameter(int n, int[][] edges) {
        g = new ArrayList[n];
        Arrays.setAll(g, e -> new ArrayList<>());
        for (var e : edges) {
            int x = e[0] - 1, y = e[1] - 1; // ��Ÿ�Ϊ�� 0 ��ʼ
            g[x].add(y);
            g[y].add(x); // ����
        }

        var ans = new int[n - 1];
        // ������ö��
        for (mask = 3; mask < 1 << n; ++mask) {
            if ((mask & (mask - 1)) == 0) continue; // ��Ҫ����������
            vis = diameter = 0;
            dfs(Integer.numberOfTrailingZeros(mask)); // ��һ���� mask �еĵ㿪ʼ�ݹ�
            if (vis == mask)
                ++ans[diameter - 1];
        }
        return ans;
    }

    // ������ֱ��
    private int dfs(int x) {
        vis |= 1 << x; // ��� x ���ʹ�
        int maxLen = 0;
        for (int y : g[x])
            if ((vis >> y & 1) == 0 && (mask >> y & 1) == 1) { // y û�з��ʹ����� mask ��
                int ml = dfs(y) + 1;
                diameter = Math.max(diameter, maxLen + ml);
                maxLen = Math.max(maxLen, ml);
            }
        return maxLen;
    }
}
```

```cpp
class Solution {
public:
    vector<int> countSubgraphsForEachDiameter(int n, vector<vector<int>> &edges) {
        vector<vector<int>> g(n);
        for (auto &e : edges) {
            int x = e[0] - 1, y = e[1] - 1; // ��Ÿ�Ϊ�� 0 ��ʼ
            g[x].push_back(y);
            g[y].push_back(x); // ����
        }

        vector<int> ans(n - 1);
        // ������ö��
        for (int mask = 3; mask < 1 << n; ++mask) {
            if ((mask & (mask - 1)) == 0) continue; // ��Ҫ����������
            // ������ֱ��
            int vis = 0, diameter = 0;
            function<int(int)> dfs = [&](int x) -> int {
                vis |= 1 << x; // ��� x ���ʹ�
                int max_len = 0;
                for (int y : g[x])
                    if ((vis >> y & 1) == 0 && mask >> y & 1) { // y û�з��ʹ����� mask ��
                        int ml = dfs(y) + 1;
                        diameter = max(diameter, max_len + ml);
                        max_len = max(max_len, ml);
                    }
                return max_len;
            };
            dfs(__builtin_ctz(mask)); // ��һ���� mask �еĵ㿪ʼ�ݹ�
            if (vis == mask)
                ++ans[diameter - 1];
        }
        return ans;
    }
};
```

```go
func countSubgraphsForEachDiameter(n int, edges [][]int) []int {
    // ����
    g := make([][]int, n)
    for _, e := range edges {
        x, y := e[0]-1, e[1]-1 // ��Ÿ�Ϊ�� 0 ��ʼ
        g[x] = append(g[x], y)
        g[y] = append(g[y], x)
    }

    ans := make([]int, n-1)
    // ������ö��
    for mask := 3; mask < 1<<n; mask++ {
        if mask&(mask-1) == 0 { // ��Ҫ����������
            continue
        }
        // ������ֱ��
        vis, diameter := 0, 0
        var dfs func(int) int
        dfs = func(x int) (maxLen int) {
            vis |= 1 << x // ��� x ���ʹ�
            for _, y := range g[x] {
                if vis>>y&1 == 0 && mask>>y&1 > 0 { // y û�з��ʹ����� mask ��
                    ml := dfs(y) + 1
                    diameter = max(diameter, maxLen+ml)
                    maxLen = max(maxLen, ml)
                }
            }
            return
        }
        dfs(bits.TrailingZeros(uint(mask))) // ��һ���� mask �еĵ㿪ʼ�ݹ�
        if vis == mask {
            ans[diameter-1]++
        }
    }
    return ans
}

func max(a, b int) int { if a < b { return b }; return a }
```

##### ���Ӷȷ���

-   ʱ�临�Ӷȣ�$O(n2^n)$��$O(2^n)$ ö���Ӽ���$O(n)$ ��ֱ��������ʱ�临�Ӷ�Ϊ $O(n2^n)$��
-   �ռ临�Ӷȣ�$O(n)$��

#### [��������ö��ֱ���˵�+�˷�ԭ��](https://leetcode.cn/problems/count-subtrees-with-max-distance-between-cities/solutions/2162612/tu-jie-on3-mei-ju-zhi-jing-duan-dian-che-am2n/)

##### ǰ��֪ʶ���������

��[�������㷨���� 09��](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1UD4y1Y769%2F)��

##### ǰ��֪ʶ���˷�ԭ��

�� [�˷�ԭ��](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E4%B9%98%E6%B3%95%E5%8E%9F%E7%90%86%2F7538447)��

##### ˼·

����ö�� $i$ �� $j$ ��Ϊֱ���������˵� ����ô�� $i$ �� $j$ ��������·����ֱ�����������ÿ���㶼����ѡ��

������Щ���ǿ���ѡ�ģ�

![](./assets/img/Solution1617_5_01.png)

Ϊ�˼���������������ľ��� $dis$��ö�� $i$ ��Ϊ���ĸ������� $i$ �������ľ��롣��ͨ���� BFS ���������Ƕ�������˵����������ļ�·����Ψһ�ģ����� DFS Ҳ���ԡ�

��ôͨ�� $n$ �� DFS���Ϳ��Եõ�������������ľ����ˡ�

##### ����

**��**���������Ƶġ���Ҫ�����ظ�ͳ�ơ�����Ŀ��

**��**������ [15\. ����֮��](https://leetcode.cn/problems/3sum/)��[90\. �Ӽ� II](https://leetcode.cn/problems/subsets-ii/) �ȡ�

```python
class Solution:
    def countSubgraphsForEachDiameter(self, n: int, edges: List[List[int]]) -> List[int]:
        # ����
        g = [[] for _ in range(n)]
        for x, y in edges:
            g[x - 1].append(y - 1)
            g[y - 1].append(x - 1)  # ��Ÿ�Ϊ�� 0 ��ʼ

        # ����������������ľ���
        dis = [[0] * n for _ in range(n)]
        def dfs(x: int, fa: int) -> None:
            for y in g[x]:
                if y != fa:
                    dis[i][y] = dis[i][x] + 1  # �Զ�����
                    dfs(y, x)
        for i in range(n):
            dfs(i, -1)  # ���� i �������ľ���

        def dfs2(x: int, fa: int) -> int:
            # �ܵݹ鵽�⣬˵�� x ����ѡ
            cnt = 1  # ѡ x
            for y in g[x]:
                if y != fa and \
                   (di[y] < d or di[y] == d and y > j) and \
                   (dj[y] < d or dj[y] == d and y > i):  # ������Щ�����Ϳ���ѡ
                    cnt *= dfs2(y, x)  # ÿ������������������ó˷�ԭ��
            if di[x] + dj[x] > d:  # x �ǿ�ѡ��
                cnt += 1  # ��ѡ x
            return cnt
        ans = [0] * (n - 1)
        for i, di in enumerate(dis):
            for j in range(i + 1, n):
                dj = dis[j]
                d = di[j]
                ans[d - 1] += dfs2(i, -1)
        return ans
```

```java
class Solution {
    private List<Integer>[] g;
    private int[][] dis;

    public int[] countSubgraphsForEachDiameter(int n, int[][] edges) {
        g = new ArrayList[n];
        Arrays.setAll(g, e -> new ArrayList<>());
        for (var e : edges) {
            int x = e[0] - 1, y = e[1] - 1; // ��Ÿ�Ϊ�� 0 ��ʼ
            g[x].add(y);
            g[y].add(x); // ����
        }

        dis = new int[n][n];
        for (int i = 0; i < n; ++i)
            dfs(i, i, -1); // ���� i �������ľ���

        var ans = new int[n - 1];
        for (int i = 0; i < n; ++i)
            for (int j = i + 1; j < n; ++j)
                ans[dis[i][j] - 1] += dfs2(i, j, dis[i][j], i, -1);
        return ans;
    }

    private void dfs(int i, int x, int fa) {
        for (int y : g[x])
            if (y != fa) {
                dis[i][y] = dis[i][x] + 1; // �Զ�����
                dfs(i, y, x);
            }
    }

    private int dfs2(int i, int j, int d, int x, int fa) {
        // �ܵݹ鵽�⣬˵�� x ����ѡ
        int cnt = 1; // ѡ x
        for (int y : g[x])
            if (y != fa &&
               (dis[i][y] < d || dis[i][y] == d && y > j) &&
               (dis[j][y] < d || dis[j][y] == d && y > i)) // ������Щ�����Ϳ���ѡ
                cnt *= dfs2(i, j, d, y, x); // ÿ������������������ó˷�ԭ��
        if (dis[i][x] + dis[j][x] > d)  // x �ǿ�ѡ��
            ++cnt; // ��ѡ x
        return cnt;
    }
}
```

```cpp
class Solution {
public:
    vector<int> countSubgraphsForEachDiameter(int n, vector<vector<int>> &edges) {
        vector<vector<int>> g(n);
        for (auto &e : edges) {
            int x = e[0] - 1, y = e[1] - 1; // ��Ÿ�Ϊ�� 0 ��ʼ
            g[x].push_back(y);
            g[y].push_back(x); // ����
        }

        int dis[n][n]; memset(dis, 0, sizeof(dis));
        function<void(int, int, int)> dfs = [&](int i, int x, int fa) {
            for (int y : g[x])
                if (y != fa) {
                    dis[i][y] = dis[i][x] + 1; // �Զ�����
                    dfs(i, y, x);
                }
        };
        for (int i = 0; i < n; ++i)
            dfs(i, i, -1); // ���� i �������ľ���

        function<int(int, int, int, int, int)> dfs2 = [&](int i, int j, int d, int x, int fa) {
            // �ܵݹ鵽�⣬˵�� x ����ѡ
            int cnt = 1; // ѡ x
            for (int y : g[x])
                if (y != fa &&
                   (dis[i][y] < d || dis[i][y] == d && y > j) &&
                   (dis[j][y] < d || dis[j][y] == d && y > i)) // ������Щ�����Ϳ���ѡ
                    cnt *= dfs2(i, j, d, y, x); // ÿ������������������ó˷�ԭ��
            if (dis[i][x] + dis[j][x] > d)  // x �ǿ�ѡ��
                ++cnt; // ��ѡ x
            return cnt;
        };
        vector<int> ans(n - 1);
        for (int i = 0; i < n; ++i)
            for (int j = i + 1; j < n; ++j)
                ans[dis[i][j] - 1] += dfs2(i, j, dis[i][j], i, -1);
        return ans;
    }
};
```

```go
func countSubgraphsForEachDiameter(n int, edges [][]int) []int {
    // ����
    g := make([][]int, n)
    for _, e := range edges {
        x, y := e[0]-1, e[1]-1 // ��Ÿ�Ϊ�� 0 ��ʼ
        g[x] = append(g[x], y)
        g[y] = append(g[y], x)
    }

    // ����������������ľ���
    dis := make([][]int, n)
    for i := range dis {
        // ���� i �������ľ���
        dis[i] = make([]int, n)
        var dfs func(int, int)
        dfs = func(x, fa int) {
            for _, y := range g[x] {
                if y != fa {
                    dis[i][y] = dis[i][x] + 1 // �Զ�����
                    dfs(y, x)
                }
            }
        }
        dfs(i, -1)
    }

    ans := make([]int, n-1)
    for i, di := range dis {
        for j := i + 1; j < n; j++ {
            dj := dis[j]
            d := di[j]
            var dfs func(int, int) int
            dfs = func(x, fa int) int {
                // �ܵݹ鵽�⣬˵�� x ����ѡ
                cnt := 1 // ѡ x
                for _, y := range g[x] {
                    if y != fa &&
                       (di[y] < d || di[y] == d && y > j) &&
                       (dj[y] < d || dj[y] == d && y > i) { // ������Щ�����Ϳ���ѡ
                        cnt *= dfs(y, x) // ÿ������������������ó˷�ԭ��
                    }
                }
                if di[x]+dj[x] > d { // x �ǿ�ѡ��
                    cnt++ // ��ѡ x
                }
                return cnt
            }
            ans[d-1] += dfs(i, -1)
        }
    }
    return ans
}
```

##### ���Ӷȷ���

-   ʱ�临�Ӷȣ�$O(n^3)$��$O(n^2)$ ö��ֱ���˵㣬$O(n)$ ���㷽����������ʱ�临�Ӷ�Ϊ $O(n^3)$��
-   �ռ临�Ӷȣ�$O(n^2)$��
