#### [力扣在逐渐把 ACM 模板题搬上来，这个问题是 Binary Lifting](https://leetcode.cn/problems/kth-ancestor-of-a-tree-node/solutions/287974/li-kou-zai-zhu-jian-ba-acm-mo-ban-ti-ban-shang-lai/)

因为力扣的数据还是有些弱的，所以这个问题我看到一些相对“暴力”的解也能过。但是这个问题的“正规解”应该是 Binary Lifting。

Binary Lifting 的本质其实是 dp。`dp[node][j]` 存储的是 node 节点距离为 $2^j$ 的祖先是谁。

根据定义，`dp[node][0]` 就是 `parent[node]`，即 node 的距离为 1 的祖先是 `parent[node]`。

状态转移是： `dp[node][j] = dp[dp[node][j - 1]][j - 1]`。

意思是：要想找到 node 的距离 $2^j$ 的祖先，先找到 node 的距离 $2^{(j - 1)}$ 的祖先，然后，再找这个祖先的距离 $2^{(j - 1)}$ 的祖先。两步得到 node 的距离为 $2^j$ 的祖先。

所以，我们要找到每一个 node 的距离为 1, 2, 4, 8, 16, 32, ... 的祖先，直到达到树的最大的高度。树的最大的高度是 logn 级别的。

这样做，状态总数是 O(nlogn)，可以使用 O(nlogn) 的时间做预处理。

之后，根据预处理的结果，可以在 O(logn) 的时间里完成每次查询：对于每一个查询 k，把 k 拆解成二进制表示，然后根据二进制表示中 1 的位置，累计向上查询。

我的参考代码（C++）：

```cpp
class TreeAncestor {

private:
    vector<vector<int>> dp;

public:
    TreeAncestor(int n, vector<int>& parent) : dp(n) {

        for(int i = 0; i < n; i ++)
            dp[i].push_back(parent[i]);

        for(int j = 1; ; j ++){
            bool allneg = true;
            for(int i = 0; i < n; i ++){
                int t = dp[i][j - 1] != -1 ? dp[dp[i][j - 1]][j - 1] : -1;
                dp[i].push_back(t);
                if(t != -1) allneg = false;
            }
            if(allneg) break; // 所有的节点的 2^j 的祖先都是 -1 了，就不用再计算了
        }
    }

    int getKthAncestor(int node, int k) {

        if(k == 0 || node== -1) return node;

        int pos = ffs(k) - 1; // C++ 语言中 ffs(k) 求解出 k 的最右侧第一个 1 的位置（1-based）

        return pos < dp[node].size() ? getKthAncestor(dp[node][pos], k - (1 << pos)) : -1;
    }
};
```

上面的 query 使用递归写法，再提供一个非递归写法，可能对有些同学来说更清晰：

```cpp
    int getKthAncestor(int node, int k) {

        int res = node, pos = 0;
        while(k && res != -1){
            if(pos >= dp[res].size()) return -1;
            if(k & 1) res = dp[res][pos];
            k >>= 1, pos ++;
        }
        return res;
    }
```
