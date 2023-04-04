����һ������Ķ�̬�滮���⡣���ǿ���ʹ�ö�̬�滮�����������⡣���ǿ��Զ���һ����ά����dp������dp[i][j]��ʾ����i��ʯͷ����j��ʯͷ�ϲ�Ϊһ�ѵ���С�ɱ������ǿ���ʹ�����µ��ƹ�ʽ������dp���飺

dp[i][j] = min(dp[i][k] + dp[k+1][j] + sum(stones[i]...stones[j])) (i <= k < j)

����sum(stones[i]...stones[j])��ʾ��i��ʯͷ����j��ʯͷ��������

������ǿ��Է���dp[0][n-1]������n��ʯͷ��������

������C#�����ʵ�֣�
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
ϣ������԰����������⣡

Source: Conversation with Bing, 2023/4/4(1) [GitHub] 75+�� C# ���ݽṹ���㷨ʵ�� - ֪��. https://zhuanlan.zhihu.com/p/135161115 Accessed 2023/4/4.
(2) C#�����㷨ʵ�����ع������������¾����㷨���ۡ� - ֪��. https://zhuanlan.zhihu.com/p/168795996 Accessed 2023/4/4.
(3) C#���㷨��ȫ���ٷ�֮��ʮ�ŵĳ���Ա�������㷨ڹ�ͣ�������_c# �㷨_Ф���Ĳ���-CSDN����. https://blog.csdn.net/weixin_50642897/article/details/111590080 Accessed 2023/4/4.
