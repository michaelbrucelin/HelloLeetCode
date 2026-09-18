### [有向图建模+合并区间+无重叠区间（Python/Java/C++/Go）](https://leetcode.cn/problems/maximum-number-of-non-overlapping-substrings/solutions/3077304/you-xiang-tu-jian-mo-he-bing-qu-jian-wu-3reks/)

根据题目的第二个要求，如果子串包含字母 $a$，那么最左边的 $a$ 和最右边的 $a$ 一定要在子串中。把子串的下标区间记作 $A$。

如果子串中还有字母 $b$，那么同理，最左边的 $b$ 和最右边的 $b$ 也一定要在子串中。如果这些 $b$ 的下标在 $A$ 外面，我们就需要扩大 $A$ 的范围。

如果扩大后，又需要包含其他字母呢？

为了方便分析，把上述问题用有向图建模：

- 设最左边的 $a$ 和最右边的 $a$ 对应的下标区间为 $A$。
- 如果区间 $A$ 包含字母 $b$，那么连一条从 $a$ 到 $b$ 的**有向边**。预处理字母的下标列表，在列表中二分查找，可以判断区间是否包含某个字母。
- 为什么不是无向边？例如 $s=aba$，那么 $b$ 对应的区间并没有包含字母 $a$。
- 图中每个节点（字母）额外保存该字母在 $s$ 中的最左边的下标和最右边的下标。

建模后，如果子串要包含第 $i$ 个小写字母，那么最终该子串的下标区间为：

- 从第 $i$ 个小写字母开始，$DFS$ 这个有向图，所有能访问到的点的对应区间的**并集**，即为最终子串的下标区间。

上述过程会得到**至多** $26$ 个区间，问题变成：

- 从这些区间中，最多可以选多少个互不重叠的区间？

这和 [435\. 无重叠区间](https://leetcode.cn/problems/non-overlapping-intervals/) 是一样的，见 [我的题解](https://leetcode.cn/problems/non-overlapping-intervals/solutions/3077218/tan-xin-zheng-ming-pythonjavaccgojsrust-3jx4f/)。

[本题视频讲解](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1pmAGegEcw%2F%3Ft%3D22m45s)，欢迎点赞关注$\sim$

```Python
class Solution:
    def maxNumOfSubstrings(self, s: str) -> List[str]:
        # 记录每种字母的出现位置
        pos = defaultdict(list)
        for i, b in enumerate(s):
            pos[b].append(i)

        # 构建有向图
        g = defaultdict(list)
        for i, p in pos.items():
            l, r = p[0], p[-1]
            for j, q in pos.items():
                if j == i:
                    continue
                k = bisect_left(q, l)
                # [l, r] 包含第 j 个小写字母
                if k < len(q) and q[k] <= r:
                    g[i].append(j)

        # 遍历有向图
        def dfs(x: str) -> None:
            nonlocal l, r
            vis.add(x)
            p = pos[x]
            l = min(l, p[0])  # 合并区间
            r = max(r, p[-1])
            for y in g[x]:
                if y not in vis:
                    dfs(y)

        intervals = []
        for i, p in pos.items():
            # 如果要包含第 i 个小写字母，最终得到的区间是什么？
            vis = set()
            l, r = inf, 0
            dfs(i)
            intervals.append((l, r))

        # 435. 无重叠区间
        # 直接计算所选子串
        ans = []
        intervals.sort(key=lambda x: x[1])
        pre_r = -1
        for l, r in intervals:
            if l > pre_r:
                ans.append(s[l: r + 1])
                pre_r = r
        return ans
```

```Java
class Solution {
    public List<String> maxNumOfSubstrings(String s) {
        int n = s.length();
        // 记录每种字母的出现位置
        List<Integer>[] pos = new ArrayList[26];
        Arrays.setAll(pos, i -> new ArrayList<>());
        for (int i = 0; i < n; i++) {
            pos[s.charAt(i) - 'a'].add(i);
        }

        // 构建有向图
        List<Integer>[] g = new ArrayList[26];
        Arrays.setAll(g, i -> new ArrayList<>());
        for (int i = 0; i < 26; i++) {
            if (pos[i].isEmpty()) {
                continue;
            }
            List<Integer> p = pos[i];
            int l = p.get(0);
            int r = p.get(p.size() - 1);
            for (int j = 0; j < 26; j++) {
                if (j == i) {
                    continue;
                }
                List<Integer> q = pos[j];
                int k = lowerBound(q, l);
                // [l, r] 包含第 j 个小写字母
                if (k < q.size() && q.get(k) <= r) {
                    g[i].add(j);
                }
            }
        }

        // 遍历有向图
        List<int[]> intervals = new ArrayList<>();
        boolean[] vis = new boolean[26];
        for (int i = 0; i < 26; i++) {
            if (pos[i].isEmpty()) {
                continue;
            }
            // 如果要包含第 i 个小写字母，最终得到的区间是什么？
            Arrays.fill(vis, false);
            l = n;
            r = 0;
            dfs(i, pos, g, vis);
            intervals.add(new int[]{l, r});
        }

        // 435. 无重叠区间
        // 直接计算所选子串
        List<String> ans = new ArrayList<>();
        intervals.sort((a, b) -> a[1] - b[1]);
        int preR = -1;
        for (int[] p : intervals) {
            int l = p[0];
            int r = p[1];
            if (l > preR) {
                ans.add(s.substring(l, r + 1));
                preR = r;
            }
        }
        return ans;
    }

    private int l, r;

    private void dfs(int x, List<Integer>[] pos, List<Integer>[] g, boolean[] vis) {
        vis[x] = true;
        List<Integer> p = pos[x];
        l = Math.min(l, p.get(0)); // 合并区间
        r = Math.max(r, p.get(p.size() - 1));
        for (int y : g[x]) {
            if (!vis[y]) {
                dfs(y, pos, g, vis);
            }
        }
    }

    // 开区间写法
    // 请看 https://www.bilibili.com/video/BV1AP41137w7/
    private int lowerBound(List<Integer> a, int target) {
        // 开区间 (left, right)
        int left = -1;
        int right = a.size();
        while (left + 1 < right) { // 区间不为空
            // 循环不变量：
            // a[left] < target
            // a[right] >= target
            int mid = (left + right) >>> 1;
            if (a.get(mid) >= target) {
                right = mid; // 范围缩小到 (left, mid)
            } else {
                left = mid; // 范围缩小到 (mid, right)
            }
        }
        return right; // right 是最小的满足 a[right] >= target 的下标
    }
}
```

```C++
class Solution {
public:
    vector<string> maxNumOfSubstrings(string s) {
        // 记录每种字母的出现位置
        vector<int> pos[26];
        for (int i = 0; i < s.size(); i++) {
            pos[s[i] - 'a'].push_back(i);
        }

        // 构建有向图
        vector<int> g[26];
        for (int i = 0; i < 26; i++) {
            if (pos[i].empty()) {
                continue;
            }
            int l = pos[i][0], r = pos[i].back();
            for (int j = 0; j < 26; j++) {
                if (j == i) {
                    continue;
                }
                auto& q = pos[j];
                int k = ranges::lower_bound(q, l) - q.begin();
                // [l, r] 包含第 j 个小写字母
                if (k < q.size() && q[k] <= r) {
                    g[i].push_back(j);
                }
            }
        }

        // 遍历有向图
        bool vis[26];
        int l, r;
        auto dfs = [&](this auto&& dfs, int x) -> void {
            vis[x] = true;
            l = min(l, pos[x][0]); // 合并区间
            r = max(r, pos[x].back());
            for (int y : g[x]) {
                if (!vis[y]) {
                    dfs(y);
                }
            }
        };

        vector<pair<int, int>> intervals;
        for (int i = 0; i < 26; i++) {
            if (pos[i].empty()) {
                continue;
            }
            // 如果要包含第 i 个小写字母，最终得到的区间是什么？
            ranges::fill(vis, false);
            l = INT_MAX;
            r = 0;
            dfs(i);
            intervals.emplace_back(l, r);
        }

        // 435. 无重叠区间
        // 直接计算所选子串
        vector<string> ans;
        ranges::sort(intervals, {}, &pair<int, int>::second);
        int pre_r = -1;
        for (auto& [l, r] : intervals) {
            if (l > pre_r) {
                ans.push_back(s.substr(l, r - l + 1));
                pre_r = r;
            }
        }
        return ans;
    }
};
```

```Go
func maxNumOfSubstrings(s string) (ans []string) {
    // 记录每种字母的出现位置
    pos := [26][]int{}
    for i, b := range s {
        b -= 'a'
        pos[b] = append(pos[b], i)
    }

    // 构建有向图
    g := [26][]int{}
    for i, p := range pos {
        if p == nil {
            continue
        }
        l, r := p[0], p[len(p)-1]
        for j, q := range pos {
            if j == i {
                continue
            }
            k := sort.SearchInts(q, l)
            // [l,r] 包含第 j 个小写字母
            if k < len(q) && q[k] <= r {
                g[i] = append(g[i], j)
            }
        }
    }

    // 遍历有向图
    vis := [26]bool{}
    var l, r int
    var dfs func(int)
    dfs = func(x int) {
        vis[x] = true
        p := pos[x]
        l = min(l, p[0]) // 合并区间
        r = max(r, p[len(p)-1])
        for _, y := range g[x] {
            if !vis[y] {
                dfs(y)
            }
        }
    }

    type pair struct{ l, r int }
    intervals := []pair{}
    for i, p := range pos {
        if p == nil {
            continue
        }
        // 如果要包含第 i 个小写字母，最终得到的区间是什么？
        vis = [26]bool{}
        l, r = len(s), 0
        dfs(i)
        intervals = append(intervals, pair{l, r})
    }

    // 435. 无重叠区间
    // 直接计算最多能选多少个区间
    slices.SortFunc(intervals, func(a, b pair) int { return a.r - b.r })
    preR := -1
    for _, p := range intervals {
        if p.l > preR {
            ans = append(ans, s[p.l:p.r+1])
            preR = p.r
        }
    }
    return
}
```

#### 复杂度分析

- 时间复杂度：$O(n+\vert \sum \vert^2\log n)$，其中 $n$ 是 $s$ 的长度，$\vert \sum \vert =26$ 是字符集合的大小。
- 空间复杂度：$O(n+\vert \sum \vert^2)$。

更多相似题目，见下面贪心题单中的「**§2.1 不相交区间**」。

#### 分类题单

[如何科学刷题？](https://leetcode.cn/circle/discuss/RvFUtj/)

1. [滑动窗口与双指针（定长/不定长/单序列/双序列/三指针/分组循环）](https://leetcode.cn/circle/discuss/0viNMK/)
2. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
3. [单调栈（基础/矩形面积/贡献法/最小字典序）](https://leetcode.cn/circle/discuss/9oZFK9/)
4. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
5. [位运算（基础/性质/拆位/试填/恒等式/思维）](https://leetcode.cn/circle/discuss/dHn9Vk/)
6. [图论算法（DFS/BFS/拓扑排序/基环树/最短路/最小生成树/网络流）](https://leetcode.cn/circle/discuss/01LUak/)
7. [动态规划（入门/背包/划分/状态机/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
8. [常用数据结构（前缀和/差分/栈/队列/堆/字典树/并查集/树状数组/线段树）](https://leetcode.cn/circle/discuss/mOr1u6/)
9. [数学算法（数论/组合/概率期望/博弈/计算几何/随机算法）](https://leetcode.cn/circle/discuss/IYT3ss/)
10. [贪心与思维（基本贪心策略/反悔/区间/字典序/数学/思维/脑筋急转弯/构造）](https://leetcode.cn/circle/discuss/g6KTKL/)
11. [链表、树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA）](https://leetcode.cn/circle/discuss/K0n2gO/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/circle/discuss/SJFwQI/)
