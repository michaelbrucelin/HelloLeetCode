这是一道经典的动态规划问题。我们可以使用动态规划来解决这个问题。我们可以定义一个二维数组dp，其中dp[i][j]表示将第i堆石头到第j堆石头合并为一堆的最小成本。我们可以使用以下递推公式来计算dp数组：

dp[i][j] = min(dp[i][k] + dp[k+1][j] + sum(stones[i]...stones[j])) (i <= k < j)

其中sum(stones[i]...stones[j])表示第i堆石头到第j堆石头的总数。

最后，我们可以返回dp[0][n-1]，其中n是石头的数量。

以下是C#代码的实现：
```csharp
public int MergeStones(int[] stones, int K) {
    int n = stones.Length;
    if ((n - 1) % (K - 1) != 0) {
        return -1;
    }
    int[] prefixSum = new int[n + 1];
    for (int i = 0; i < n; i++) {
        prefixSum[i + 1] = prefixSum[i] + stones[i];
    }
    int[,] dp = new int[n, n];
    for (int len = K; len <= n; len++) {
        for (int i = 0; i + len <= n; i++) {
            int j = i + len - 1;
            dp[i,j] = int.MaxValue;
            for (int k = i; k < j; k += K - 1) {
                dp[i,j] = Math.Min(dp[i,j], dp[i,k] + dp[k+1,j]);
            }
            if ((j - i) % (K - 1) == 0) {
                dp[i,j] += prefixSum[j+1] - prefixSum[i];
            }
        }
    }
    return dp[0,n-1];
}
```
希望这可以帮助你解决问题！

Source: Conversation with Bing, 2023/4/4(1) [GitHub] 75+的 C# 数据结构和算法实现 - 知乎. https://zhuanlan.zhihu.com/p/135161115 Accessed 2023/4/4.
(2) C#经典算法实践，回顾往生，更是致敬《算法导论》 - 知乎. https://zhuanlan.zhihu.com/p/168795996 Accessed 2023/4/4.
(3) C#：算法大全（百分之九十九的程序员都掌握算法诠释！！！）_c# 算法_肖尘的博客-CSDN博客. https://blog.csdn.net/weixin_50642897/article/details/111590080 Accessed 2023/4/4.
