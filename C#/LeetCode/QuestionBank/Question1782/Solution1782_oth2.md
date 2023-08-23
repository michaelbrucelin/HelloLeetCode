### [【容斥原理】理清思路，逐步优化](https://leetcode.cn/problems/count-pairs-of-nodes/solutions/639709/rong-chi-yuan-li-li-qing-si-lu-zhu-bu-yo-yl38/)

#### 基本思路

设图中的点数为 $n$，边数为 $m$。

根据容斥原理，与点对 $a, b$ 相连的边数等于「与 $a$ 相连的边数加上与 $b$ 相连的边数，再减去同时与 $a, b$ 同时 相连的边数」。我们的目标，就是求出这两个部分，随后二者的差就是相连的边数。

首先来看第一部分。为了求与 $a, b$ 同时相连的边数，不难想到利用一个二维数组来维护。然而，由于 $n$ 的数据范围较大，二维数组的方式会占用过大的空间与时间（**初始化时需要与数组大小等大的时间**）。考虑到 $m$ 只有 $10^5$，因此可以使用哈希表来节省空间占用。

具体而言，对于任意一条边 $(p_1,p_2)$，我们可以将这条边映射到一个唯一的整数。设 $p_{max}=\max\{p_1, p_2\}, p_{min}=\min\{p_1, p_2\}$，则可以将这条边映射到整数 $p_{max}\cdot(n+1) + p_{min}$。其中，要首先取最大值和最小值的原因在于，需要处理重边（如 $(1,2)$ 和 $(2,1)$ 的情况。）

现在来看第二部分。记与点 $i$ 相连的边数为 $deg[i]$，则可以通过一次遍历 $edges$ 数组求出 $deg$ 数组的取值。因此对于任意的点对，我们可以轻松地求出 $deg[a] + deg[b]$ 的值。

目前为止，需要的两个部分都求出来了，看上去我们已经完成这道题了。

#### 进阶优化

**并没有完成！** 由于 $n$ 的数据范围较大，我们不能简单地遍历每个可能的点对。因此，必须寻找一种比暴力枚举更快的方法。

记与 $a, b$ 同时相连的边数为 $overlap[a][b]$（**再次注意：实际实现中要使用哈希表，而不是二维数组！**）。回过头来再看最开始列出的条件，我们需要求出点对 $a, b$ 的数量：使得 $deg[a] + deg[b] - overlap[a][b] > query$。

我们首先求出 $deg[a] + deg[b] > query$ 的数量。如果给 $deg$ 数组排序，则问题等价于在有序数组中，求出所有数字对的数目，使得它们的和大于给定的值。这是一个经典的双指针问题，在这里不再赘述。

随后，我们再求出满足 $deg[a] + deg[b] > query$，但 $deg[a] + deg[b] - overlap[a][b] \le query$ 的数量。此时，我们**无需再遍历所有的点对，因为满足这样条件的点对，一定出现在 $edges$ 数组中**！因此，我们只需再遍历一次 $edges$ 数组即可。这样做的时间复杂度为 $O(m)$，相比于枚举点对的 $O(n^2)$ 要好上不少。

在求出这两部分后，二者的差值即为满足 $deg[a] + deg[b] - overlap[a][b] > query$ 的点对数量。

#### 代码

```cpp
class Solution {
public:
    vector<int> countPairs(int n, vector<vector<int>>& edges, vector<int>& queries) {
        vector<int> deg(n + 1, 0);
        
        int nEdges = edges.size();
        unordered_map<int, int> overlap;
        vector<vector<int>> distinctEdges; // 去除重边后的边数组，这样处理每个 query 时能少遍历几条边
        auto encode = [n](int a, int b) -> int {return max(a, b) * (n + 1) + min(a, b);};
        for (int i = 0; i < nEdges; i++) {
            int p = edges[i][0], q = edges[i][1];
            deg[p]++;
            deg[q]++;
            int idx = encode(p, q);
            if (overlap.find(idx) == overlap.end()) {
                distinctEdges.push_back({p, q});
            }
            overlap[idx]++;
        }

        vector<int> sortedDeg(deg.begin() + 1, deg.end());
        sort(sortedDeg.begin(), sortedDeg.end());
        
        int nQueries = queries.size();
        vector<int> ret(nQueries);
        for (int i = 0; i < nQueries; i++) {
            int l = 0, r = n - 1;
            int cnt = 0;
            while (l < n) {
                while (r > l && sortedDeg[l] + sortedDeg[r] > queries[i]) {
                    r--;
                }
                cnt += (n - max(l, r) - 1);
                l++;
            }

            for (int j = 0; j < distinctEdges.size(); j++) {
                int p = distinctEdges[j][0], q = distinctEdges[j][1];
                int idx = encode(p, q);
                if (deg[p] + deg[q] > queries[i] && deg[p] + deg[q] - overlap[idx] <= queries[i]) {
                    cnt--;
                }
            }
            ret[i] = cnt;
        }
        return ret;
    }
};
```

**复杂度分析**

-   预处理时间复杂度： $O(m + n \log n)$，即遍历一遍 $edges$ 数组，并排序 $deg$ 数组的复杂度。
-   单次查询时间复杂度：$O(n+m)$。首先利用双指针找出第一部分，$O(n)$ 时间；随后遍历 $edges$ 数组求解第二部分，$O(m)$ 时间。
