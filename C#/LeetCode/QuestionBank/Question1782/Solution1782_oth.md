### [击败 100%！从双指针到终极优化，十万个查询都不怕！（Python/Java/C++/Go/JS）](https://leetcode.cn/problems/count-pairs-of-nodes/solutions/2400682/ji-bai-100cong-shuang-zhi-zhen-dao-zhong-yhze/)

#### 方法一：单独处理每个询问

题目让我们求「与点对中至少一个点相连的边的数目 $cnt$」，如何计算呢？

先来统计与一个点相连的边的数目（度数），记作数组 $deg$。以示例 1 为例，$deg=[3,4,2,1]$（节点编号从 $1$ 开始），例如 $deg[1]=3$ 表示有 $3$ 条边与 $1$ 相连，$deg[2]=4$ 表示有 $4$ 条边与 $2$ 相连。$deg$ 可以通过遍历 $edges$ 中的每条边得到，遍历到边 $x-y$，就把 $deg[x]$ 加一，以及 $deg[y]$ 加一。

看上去 $deg[1]+deg[2]=3+4=7$ 就是点对 $(1,2)$ 的 $cnt$ 值，但这是错的。注意 $1-2$ 这条边既与 $1$ 相连，又与 $2$ 相连，我们**重复统计**了。由于 $edges$ 中有两条 $1-2$ 边，所以多统计了 $2$，因此正确的 $cnt$ 值为 $deg[1]+deg[2]-2=3+4-2=5$。

现在知道怎么算 $cnt$ 了。我们需要统计有多少个点对的 $cnt$ 值严格大于 $queries[j]$，如果暴力枚举所有点对的话，要花 $\mathcal{O}(n^2)$ 的时间，如何优化呢？

暂时不考虑重复统计的事，把问题重新描述下：

从$deg$中选择两个数，使得两数之和严格大于 $queries[j]$ 的方案数。从 $deg$ 中选择两个数，使得两数之和严格大于 $queries[j]$ 的方案数。从$deg$中选择两个数，使得两数之和严格大于 $queries[j]$ 的方案数。

把 $deg$ 排序后，可以使用**相向双指针**解决该问题。做法和 [167\. 两数之和 II - 输入有序数组](https://leetcode.cn/problems/two-sum-ii-input-array-is-sorted/) 是类似的。

相向双指针的思路如下：

-   初始化左右指针 $left=1,right=n$。
-   如果 $deg[left]+deg[right] \le queries[j]$，由于数组是有序的，$deg[left]$ 与下标 $i$ 在 $[left+1,right]$ 中的任何 $deg[i]$ 相加，都是 $\le queries[j]$ 的，因此后面无需考虑 $deg[left]$，将 $left$ 加一。
-   如果 $deg[left]+deg[right] > queries[j]$，由于数组是有序的，$deg[right]$ 与下标 $i$ 在 $[left,right-1]$ 中的任何 $deg[i]$ 相加，都是 $>queries[j]$ 的，因此直接找到了 $right-left$ 个合法方案，加到答案 $ans[j]$ 中，然后将 $right$ 减一。
-   重复上述过程直到 $left \ge right$ 为止（题目要求点对 $(a,b)$ 满足 $a<b$）。

然后考虑重复统计的事情。遍历每条边，设边 $x-y$ 在 $edges$ 中出现 $c$ 次，如果 $deg[x]+deg[y]> queries[j]$ 且 $deg[x]+deg[y]-c \le queries[j]$，这意味着我们把原本不满足要求的点对 $(x,y)$ 当成了满足要求的，所以将 $ans[j]$ 减一。

如何知道一条边在 $edges$ 中的出现次数？用哈希表统计，请看代码。

```python
class Solution:
    def countPairs(self, n: int, edges: List[List[int]], queries: List[int]) -> List[int]:
        # deg[i] 表示与点 i 相连的边的数目
        deg = [0] * (n + 1)  # 节点编号从 1 到 n
        for x, y in edges:
            deg[x] += 1
            deg[y] += 1
        # 统计每条边的出现次数，注意 1-2 和 2-1 算同一条边
        cnt_e = Counter(tuple(sorted(e)) for e in edges)

        ans = [0] * len(queries)
        sorted_deg = sorted(deg)  # 排序，为了双指针
        for j, q in enumerate(queries):
            left, right = 1, n  # 相向双指针
            while left < right:
                if sorted_deg[left] + sorted_deg[right] <= q:
                    left += 1
                else:
                    ans[j] += right - left
                    right -= 1
            for (x, y), c in cnt_e.items():
                if q < deg[x] + deg[y] <= q + c:
                    ans[j] -= 1
        return ans
```

```java
class Solution {
    public int[] countPairs(int n, int[][] edges, int[] queries) {
        // deg[i] 表示与点 i 相连的边的数目
        var deg = new int[n + 1]; // 节点编号从 1 到 n
        var cntE = new HashMap<Integer, Integer>();
        for (var e : edges) {
            int x = e[0], y = e[1];
            if (x > y) {
                // 交换 x 和 y，因为 1-2 和 2-1 算同一条边
                int tmp = x;
                x = y;
                y = tmp;
            }
            deg[x]++;
            deg[y]++;
            // 统计每条边的出现次数
            // 用一个 int 存储两个不超过 65535 的数
            cntE.merge(x << 16 | y, 1, Integer::sum); // cntE[x<<16|y]++
        }

        var ans = new int[queries.length];
        var sortedDeg = deg.clone();
        Arrays.sort(sortedDeg); // 排序，为了双指针
        for (int j = 0; j < queries.length; j++) {
            int q = queries[j];
            int left = 1, right = n; // 相向双指针
            while (left < right) {
                if (sortedDeg[left] + sortedDeg[right] <= q) {
                    left++;
                } else {
                    ans[j] += right - left;
                    right--;
                }
            }
            for (var e : cntE.entrySet()) {
                int k = e.getKey(), c = e.getValue();
                int s = deg[k >> 16] + deg[k & 0xffff]; // 取出 k 的高 16 位和低 16 位
                if (s > q && s - c <= q) {
                    ans[j]--;
                }
            }
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    vector<int> countPairs(int n, vector<vector<int>> &edges, vector<int> &queries) {
        // deg[i] 表示与点 i 相连的边的数目
        vector<int> deg(n + 1); // 节点编号从 1 到 n
        unordered_map<int, int> cnt_e;
        for (auto &e: edges) {
            int x = e[0], y = e[1];
            if (x > y) swap(x, y); // 注意 1-2 和 2-1 算同一条边
            deg[x]++;
            deg[y]++;
            // 统计每条边的出现次数
            cnt_e[x << 16 | y]++; // 用一个 int 存储两个不超过 65535 的数
        }

        vector<int> ans(queries.size());
        vector<int> sorted_deg = deg;
        sort(sorted_deg.begin(), sorted_deg.end()); // 排序，为了双指针
        for (int j = 0; j < queries.size(); j++) {
            int q = queries[j];
            int left = 1, right = n; // 相向双指针
            while (left < right) {
                if (sorted_deg[left] + sorted_deg[right] <= q) {
                    left++;
                } else {
                    ans[j] += right - left;
                    right--;
                }
            }
            for (auto [k, c]: cnt_e) {
                int s = deg[k >> 16] + deg[k & 0xffff]; // 取出 k 的高 16 位和低 16 位
                if (s > q && s - c <= q) {
                    ans[j]--;
                }
            }
        }
        return ans;
    }
};
```

```go
func countPairs(n int, edges [][]int, queries []int) []int {
    // deg[i] 表示与点 i 相连的边的数目
    deg := make([]int, n+1) // 节点编号从 1 到 n
    type edge struct{ x, y int }
    cntE := map[edge]int{}
    for _, e := range edges {
        x, y := e[0], e[1]
        if x > y {
            x, y = y, x
        }
        deg[x]++
        deg[y]++
        // 统计每条边的出现次数，注意 1-2 和 2-1 算同一条边
        cntE[edge{x, y}]++
    }

    ans := make([]int, len(queries))
    sortedDeg := append([]int(nil), deg...)
    sort.Ints(sortedDeg) // 排序，为了双指针
    for j, q := range queries {
        left, right := 1, n // 相向双指针
        for left < right {
            if sortedDeg[left]+sortedDeg[right] <= q {
                left++
            } else {
                ans[j] += right - left
                right--
            }
        }
        for e, c := range cntE {
            s := deg[e.x] + deg[e.y]
            if s > q && s-c <= q {
                ans[j]--
            }
        }
    }
    return ans
}
```

```javascript
var countPairs = function (n, edges, queries) {
    // deg[i] 表示与点 i 相连的边的数目
    const deg = new Array(n + 1).fill(0); // 节点编号从 1 到 n
    const cntE = new Map();
    for (let [x, y] of edges) {
        if (x > y) [x, y] = [y, x]; // 注意 1-2 和 2-1 算同一条边
        deg[x]++;
        deg[y]++;
        // 统计每条边的出现次数
        cntE.set(x << 16 | y, (cntE.get(x << 16 | y) ?? 0) + 1);
    }

    const ans = new Array(queries.length).fill(0);
    const sortedDeg = deg.slice().sort((a, b) => a - b); // 排序，为了双指针
    for (let j = 0; j < queries.length; j++) {
        const q = queries[j];
        let left = 1, right = n; // 相向双指针
        while (left < right) {
            if (sortedDeg[left] + sortedDeg[right] <= q) {
                left++;
            } else {
                ans[j] += right - left;
                right--;
            }
        }
        for (const [k, c] of cntE.entries()) {
            const s = deg[k >> 16] + deg[k & 0xffff]; // 取出 k 的高 16 位和低 16 位
            if (s > q && s - c <= q) {
                ans[j]--;
            }
        }
    }
    return ans;
};
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(n\log n + q(n+m))$，其中 $m$ 为 $edges$ 的长度，$q$ 为 $queries$ 的长度。
-   空间复杂度：$\mathcal{O}(n+m)$。返回值不计入。

#### 方法二：终极优化

##### 1)

如果能把所有 $cnt=0,1,2,3,\cdots$ 的点对个数都求出来，记到一个数组 $cnts$ 中，那么从后往前累加 $cnts$ 中的元素（后缀和），就可以知道满足 $cnt>queries[j]$ 的点对个数了。

例如 $cnts=[2,0,2,3]$，那么满足 $cnt>1$ 的点对个数就是 $cnts[2]+cnts[3]=2+3=5$。

如何求出 $cnts[i]$？也就是满足 $cnt$ 恰好等于 $i$ 的点对个数。

##### 2)

像方法一那样，我们先暂时不考虑重复统计的事，现在要计算的是：

从$deg$中选择两个数，使得两数之和恰好等于 $i$ 的方案数。从 $deg$ 中选择两个数，使得两数之和恰好等于 $i$ 的方案数。从$deg$中选择两个数，使得两数之和恰好等于 $i$ 的方案数。

暴力枚举？太慢了。

像方法一那样双指针？还是太慢了，因为我们要把所有 $cnts[0],cnts[1],\cdots$ 都算出来。

考虑这个例子：$deg=[2,2,2,3,3,3]$，选两个数相加等于 $5$ 的方案数有多少？

在这个例子中，只有 $2$ 和 $3$ 相加能得到 $5$，根据 [乘法原理](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E4%B9%98%E6%B3%95%E5%8E%9F%E7%90%86%2F7538447)，方案数就是 $2$ 的个数乘上 $3$ 的个数，即 $3 \cdot 3 = 9$。

这有什么用呢？统计每个 $deg[i]$ 的出现次数，再两两枚举？如果 $deg$ 中的数字各不相同，那和暴力岂不是没有区别？

真的没有区别？由于一条边可以让两个 $deg$ 各增加一，所以 $deg$ 的元素和等于 $2m$。想一想，如果你有 $2m$ 个相同的积木，你最多能搭多少个**高度不同**的积木塔？

考虑这些积木塔的高度从 $1$ 到 $x$，则有

$1+2+\cdots+x = \dfrac{x(x+1)}{2} \le 2m$

上式表明，$x$ 的上界约为 $\sqrt{4m}$。

这意味着，$deg$ 中至多有 $\mathcal{O}(\sqrt{m})$ 个不同的数字！这样就可以直接暴力枚举了：

1.  统计 $deg$ 中的元素的出现次数，记到一个哈希表 $cntDeg$ 中。
2.  写个二重循环，遍历 $cntDeg$ 中的每对元素 $deg_1$ 和 $deg_2$，设 $c_1 = cntDeg[deg_1], c_2 = cntDeg[deg_2]$，由于 $(deg_1 ,deg_2)$ 和 $(deg_2 ,deg_1)$ 是一样的，为了避免统计两次，我们规定 $deg_1\le deg_2$。
3.  如果 $deg_1< deg_2$，那么 $cnts[deg_1 + deg_2]$ 增加 $c_1 \cdot c_2$。
4.  如果 $deg_1= deg_2$，那么 $cnts[deg_1 + deg_2]$ 增加 $\dfrac{c_1(c_1-1)}{2}$，也就是从 $c_1$ 个数中选 $2$ 个数的组合数。

> 注：这里有一些贡献法的思想，与其考虑每个 $cnts[i]$ 要怎么算，不如考虑每对 $(deg_1 ,deg_2)$ 对 $cnts$ 的贡献。

##### 3)

然后考虑重复统计的事。

以示例 1 为例，$deg=[3,4,2,1]$，按照上面的算法，计算出来的是

$cnts = [0, 0, 0, 1, 1, 2, 1, 1]$

其中 $cnts[7]=1$ 来源于点对 $(1,2)$。但由于 $edges$ 中有两条 $1-2$ 边，我们多统计了 $2$，所以把 $cnts[7]$ 减掉 $1$，再把 $cnts[7-2]$ 加上 $1$。

具体来说，遍历 $cntE$ 中的每条边 $x-y$ 及其出现次数 $c$，设 $s=deg[x]+deg[y]$，那么把 $cnts[s]$ 减一，把 $cnts[s-c]$ 加一，这样就把点对 $(x,y)$ 的正确的 $cnt$ 值算到 $cnts$ 中了。

遍历完成后，得到的就是正确的 $cnts$ 数组了。

##### 4)

最后，计算 $cnts$ 的后缀和 $suf$，表示 $cnt$ 值大于等于 $i$ 的点对个数为 $suf[i]$。注意这里是大于等于，要回答的询问是严格大于。对于整数来说，$a>b$ 等价于 $a\ge b+1$，所以对于询问 $queries[j]$，答案就是

$suf[queries[j]+1]$

如果 $queries[j]+1$ 下标越界，那么答案为 $0$。

代码实现时：

1.  直接用 $queries$ 数组当作 $ans$ 数组。
2.  无需创建 $suf$ 数组，直接在 $cnts$ 上计算后缀和。
3.  在二重循环中，最大的度数加上最大的度数是 $\max(deg) \cdot 2$，所以 $cnts$ 数组的大小至少是 $\max(deg) \cdot 2 + 1$。为了方便处理询问，我们还可以在末尾添加一个 $0$，表示数组越界，所以 $cnts$ 数组实际的大小是 $k = \max(deg) \cdot 2 + 2$。修改后，询问的答案为

$suf[\min(queries[j]+1, k-1)]$

```python
class Solution:
    def countPairs(self, n: int, edges: List[List[int]], queries: List[int]) -> List[int]:
        deg = [0] * (n + 1)
        cnt_e = dict()  # 比 Counter 快一点
        for x, y in edges:
            if x > y: x, y = y, x
            deg[x] += 1
            deg[y] += 1
            cnt_e[(x, y)] = cnt_e.get((x, y), 0) + 1
        cnt_deg = Counter(deg[1:])

        # 2)
        cnts = [0] * (max(deg) * 2 + 2)
        for deg1, c1 in cnt_deg.items():
            for deg2, c2 in cnt_deg.items():
                if deg1 < deg2:
                    cnts[deg1 + deg2] += c1 * c2
                elif deg1 == deg2:
                    cnts[deg1 + deg2] += c1 * (c1 - 1) // 2

        # 3)
        for (x, y), c in cnt_e.items():
            s = deg[x] + deg[y]
            cnts[s] -= 1
            cnts[s - c] += 1

        # 4) 计算 cnts 的后缀和
        for i in range(len(cnts) - 1, 0, -1):
            cnts[i - 1] += cnts[i]

        for i, q in enumerate(queries):
            queries[i] = cnts[min(q + 1, len(cnts) - 1)]
        return queries
```

```java
class Solution {
    public int[] countPairs(int n, int[][] edges, int[] queries) {
        var deg = new int[n + 1];
        var cntE = new HashMap<Integer, Integer>();
        for (var e : edges) {
            int x = e[0], y = e[1];
            if (x > y) {
                int tmp = x;
                x = y;
                y = tmp;
            }
            deg[x]++;
            deg[y]++;
            cntE.merge(x << 16 | y, 1, Integer::sum);
        }

        // 统计 deg 中元素的出现次数
        var cntDeg = new HashMap<Integer, Integer>();
        int maxDeg = 0;
        for (int i = 1; i <= n; i++) {
            cntDeg.merge(deg[i], 1, Integer::sum); // cntDeg[deg[i]]++
            maxDeg = Math.max(maxDeg, deg[i]);
        }

        // 2)
        var cnts = new int[maxDeg * 2 + 2];
        for (var e1 : cntDeg.entrySet()) {
            int deg1 = e1.getKey(), c1 = e1.getValue();
            for (var e2 : cntDeg.entrySet()) {
                int deg2 = e2.getKey(), c2 = e2.getValue();
                if (deg1 < deg2)
                    cnts[deg1 + deg2] += c1 * c2;
                else if (deg1 == deg2)
                    cnts[deg1 + deg2] += c1 * (c1 - 1) / 2;
            }
        }

        // 3)
        for (var e : cntE.entrySet()) {
            int k = e.getKey(), c = e.getValue();
            int s = deg[k >> 16] + deg[k & 0xffff];
            cnts[s]--;
            cnts[s - c]++;
        }

        // 4) 计算 cnts 的后缀和
        for (int i = cnts.length - 1; i > 0; i--)
            cnts[i - 1] += cnts[i];

        for (int i = 0; i < queries.length; i++)
            queries[i] = cnts[Math.min(queries[i] + 1, cnts.length - 1)];
        return queries;
    }
}
```

```cpp
class Solution {
public:
    vector<int> countPairs(int n, vector<vector<int>> &edges, vector<int> &queries) {
        vector<int> deg(n + 1);
        unordered_map<int, int> cnt_e;
        for (auto &e: edges) {
            int x = e[0], y = e[1];
            if (x > y) swap(x, y);
            deg[x]++;
            deg[y]++;
            cnt_e[x << 16 | y]++;
        }

        // 统计 deg 中元素的出现次数
        unordered_map<int, int> cnt_deg;
        for (int i = 1; i <= n; i++)
            cnt_deg[deg[i]]++;

        // 2)
        int max_deg = *max_element(deg.begin() + 1, deg.end());
        int k = max_deg * 2 + 2;
        vector<int> cnts(k);
        for (auto [deg1, c1]: cnt_deg) {
            for (auto [deg2, c2]: cnt_deg) {
                if (deg1 < deg2) {
                    cnts[deg1 + deg2] += c1 * c2;
                } else if (deg1 == deg2) {
                    cnts[deg1 + deg2] += c1 * (c1 - 1) / 2;
                }
            }
        }

        // 3)
        for (auto [key, c]: cnt_e) {
            int s = deg[key >> 16] + deg[key & 0xffff];
            cnts[s]--;
            cnts[s - c]++;
        }

        // 4) 计算 cnts 的后缀和
        for (int i = k - 1; i > 0; i--)
            cnts[i - 1] += cnts[i];

        for (int &q: queries)
            q = cnts[min(q + 1, k - 1)];
        return queries;
    }
};
```

```go
func countPairs(n int, edges [][]int, queries []int) []int {
    deg := make([]int, n+1)
    type edge struct{ x, y int }
    cntE := map[edge]int{}
    for _, e := range edges {
        x, y := e[0], e[1]
        if x > y {
            x, y = y, x
        }
        deg[x]++
        deg[y]++
        cntE[edge{x, y}]++
    }

    // 统计 deg 中元素的出现次数
    cntDeg := map[int]int{}
    maxDeg := 0
    for _, d := range deg[1:] {
        cntDeg[d]++
        maxDeg = max(maxDeg, d)
    }

    // 2)
    k := maxDeg*2 + 2
    cnts := make([]int, k)
    for deg1, c1 := range cntDeg {
        for deg2, c2 := range cntDeg {
            if deg1 < deg2 {
                cnts[deg1+deg2] += c1 * c2
            } else if deg1 == deg2 {
                cnts[deg1+deg2] += c1 * (c1 - 1) / 2
            }
        }
    }

    // 3)
    for e, c := range cntE {
        s := deg[e.x] + deg[e.y]
        cnts[s]--
        cnts[s-c]++
    }

    // 4) 计算 cnts 的后缀和
    for i := k - 1; i > 0; i-- {
        cnts[i-1] += cnts[i]
    }

    for i, q := range queries {
        queries[i] = cnts[min(q+1, k-1)]
    }
    return queries
}

func min(a, b int) int { if b < a { return b }; return a }
func max(a, b int) int { if b > a { return b }; return a }
```

```javascript
var countPairs = function (n, edges, queries) {
    const deg = new Array(n + 1).fill(0);
    const cntE = new Map();
    for (let [x, y] of edges) {
        if (x > y) [x, y] = [y, x];
        deg[x]++;
        deg[y]++;
        cntE.set(x << 16 | y, (cntE.get(x << 16 | y) ?? 0) + 1);
    }

    // 统计 deg 中元素的出现次数
    const cntDeg = new Map();
    for (let i = 1; i <= n; i++)
        cntDeg.set(deg[i], (cntDeg.get(deg[i]) ?? 0) + 1);

    // 2)
    const cnts = new Array(_.max(deg) * 2 + 2).fill(0);
    for (const [deg1, c1] of cntDeg.entries()) {
        for (const [deg2, c2] of cntDeg.entries()) {
            if (deg1 < deg2) {
                cnts[deg1 + deg2] += c1 * c2;
            } else if (deg1 === deg2) {
                cnts[deg1 + deg2] += c1 * (c1 - 1) >> 1;
            }
        }
    }

    // 3)
    for (const [k, c] of cntE) {
        const s = deg[k >> 16] + deg[k & 0xffff];
        cnts[s]--;
        cnts[s - c]++;
    }

    // 4) 计算 cnts 的后缀和
    for (let i = cnts.length - 1; i > 0; i--)
        cnts[i - 1] += cnts[i];

    for (let i = 0; i < queries.length; i++)
        queries[i] = cnts[Math.min(queries[i] + 1, cnts.length - 1)];
    return queries;
};
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(n+m+q)$，其中 $m$ 为 $edges$ 的长度，$q$ 为 $queries$ 的长度。代码中有一个对 $cntDeg$ 的二重循环，但由于 $deg$ 至多有 $\mathcal{O}(\sqrt{m})$ 个不同的数，所以 $cntDeg$ 的大小也至多为 $\mathcal{O}(\sqrt{m})$，所以二重循环的时间复杂度为 $\mathcal{O}(\sqrt{m}\cdot \sqrt{m}) = \mathcal{O}(m)$。
-   空间复杂度：$\mathcal{O}(n+m)$。
