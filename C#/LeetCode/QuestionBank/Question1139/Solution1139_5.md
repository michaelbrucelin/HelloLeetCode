#### [˼·](https://leetcode.cn/problems/largest-1-bordered-square/solutions/345335/java-dong-tai-gui-hua-by-resolmi/)

���ȶ���DP����

```
dp[i][j][0]: i,j���������1�ĸ�������������
dp[i][j][1]: i,j�ϱ�������1�ĸ�������������
```

Ȼ�����Ԥ������һ����

Java

```java
int[][][] dp = new int[m+1][n+1][2];
for (int i = 1; i <= m; i++) {
    for (int j = 1; j <= n; j++) {
        if (grid[i-1][j-1] == 1){
            dp[i][j][0] = 1 + dp[i][j-1][0];
            dp[i][j][1] = 1 + dp[i-1][j][1];
        }
    }
}
```

�򵥻��˸�ͼ����ʵ�ʴ�����һ����룬ʵ�ʴ���Ϊ�˷����ʼ����`dp[i][j]`�������ʵ��`grid[i-1][j-1]`��

![](./assets/img/Solution1139_5_01.png)

����ĳ����Ϊ���½ǵ������Σ��������ǿ��������Ϊ���½ǿ��ܹ��ɵ���������α߳��Ƕ��

������Ӧ���Ǹõ���ߺ��ϱ�����1������**��Сֵ**������ͼ�ģ�6��5���㣬���Ŀ��ܱ߳���Ӧ����6��Ȼ������ö�����е�С�ڵ���6���ڵ���1�ı߳�`side`����֤`side`�ܷ񹹳�������

��֤`side`�Ƿ�Ϸ�Ҳ�����ף�����ͼ������ֻ��Ҫ���ǣ�6��5��**�ϱ�**����Ϊ`side`�ĵ��**���**����1�ĸ����Ƿ���ڵ���`side`��`dp[i-side+1][j][0] >= side`�����Լ�**���**����Ϊ`side`�ĵ��**�ϱ�**������1�ĸ����Ƿ���ڵ���`side`��`dp[i][j-side+1][1] >= side`������������ڵ���`side`��ô��`side`���ǺϷ��ģ�����ͳ����Щ�Ϸ���`side`�����ֵ��ok��

#### Code

Java

```java
public int largest1BorderedSquare(int[][] grid) {
    int m = grid.length;
    int n = grid[0].length;
    //dp[i][j][0]: i,j���������1�ĸ���
    //dp[i][j][1]: i,j�ϱ�������1�ĸ���
    int[][][] dp = new int[m+1][n+1][2];
    for (int i = 1; i <= m; i++) {
        for (int j = 1; j <= n; j++) {
            if (grid[i-1][j-1] == 1){
                dp[i][j][0] = 1 + dp[i][j-1][0];
                dp[i][j][1] = 1 + dp[i-1][j][1];
            }
        }
    }
    int res = 0;
    for (int i = 1; i <= m; i++) {
        for (int j = 1; j <= n; j++) {
            //��̵������߲�һ���ǺϷ��ı߳�������ñ߳����Ϸ�����Ҫ�����߳���ֱ���ҵ��Ϸ���
            for (int side = Math.min(dp[i][j][0], dp[i][j][1]); side >= 1; side--){
                if (dp[i][j-side+1][1] >= side && dp[i-side+1][j][0] >= side){
                    res = Math.max(res, side);
                    break; //���̵ľ�û��Ҫ������
                }
            }
        }
    }
    return res * res;
}
```
