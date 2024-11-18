### [【宫水三叶】一题双解 :「模拟」&「前缀和」](https://leetcode.cn/problems/image-smoother/solutions/1363215/by-ac_oier-nn3v/)

#### 朴素解法

为了方便，我们称每个单元格及其八连通方向单元格所组成的连通块为一个 `item`。

数据范围只有 $200$，我们可以直接对每个 `item` 进行遍历模拟。

代码：

```java
class Solution {
    public int[][] imageSmoother(int[][] img) {
        int m = img.length, n = img[0].length;
        int[][] ans = new int[m][n];
        int[][] dirs = new int[][]{{0,0},{1,0},{-1,0},{0,1},{0,-1},{-1,-1},{-1,1},{1,-1},{1,1}};
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                int tot = 0, cnt = 0;
                for (int[] di : dirs) {
                    int nx = i + di[0], ny = j + di[1];
                    if (nx < 0 || nx >= m || ny < 0 || ny >= n) continue;
                    tot += img[nx][ny]; cnt++;
                }
                ans[i][j] = tot / cnt;
            }
        }
        return ans;
    }
}
```

```python
dirs = list(product(*[[-1,0,1]] * 2))
class Solution:
    def imageSmoother(self, img: List[List[int]]) -> List[List[int]]:
        m, n = len(img), len(img[0])
        ans = [[0] * n for _ in range(m)]
        for i, j in product(range(m), range(n)):
            tot, cnt = 0, 0
            for di in dirs:
                if 0 <= (nx := i + di[0]) < m and 0 <= (ny := j + di[1]) < n:
                    tot += img[nx][ny]
                    cnt += 1
            ans[i][j] = tot // cnt
        return ans
```

- 时间复杂度：$O(m \times n \times C)$，其中 $C$ 为灰度单位所包含的单元格数量，固定为 $9$
- 空间复杂度：$O(m \times n)$
___

#### 前缀和

在朴素解法中，对于每个 $ans[i][j]$ 我们都不可避免的遍历 $8$ 联通方向，而利用「前缀和」我们可以对该操作进行优化。

> 不了解「二维前缀和」的同学可以看前置 🧀： [二维前缀和模板如何记忆](https://leetcode-cn.com/problems/range-sum-query-2d-immutable/solution/xia-ci-ru-he-zai-30-miao-nei-zuo-chu-lai-ptlo/)

对于某个 $ans[i][j]$ 而言，我们可以直接计算出其所在 `item` 的左上角 $(a, b) = (i - 1, j - 1)$ 以及其右下角 $(c, d) = (i + 1, j + 1)$，同时为了防止超出原矩阵，我们需要将 $(a, b)$ 与 $(c, d)$ 对边界分别取 `max` 和 `min`。

当有了合法的 $(a, b)$ 和 $(c, d)$ 后，我们可以直接计算出 `item` 的单元格数量（所包含的行列乘积）及 `item` 的单元格之和（前缀和查询），从而算得 $ans[i][j]$。

代码：

```java
class Solution {
    public int[][] imageSmoother(int[][] img) {
        int m = img.length, n = img[0].length;
        int[][] sum = new int[m + 10][n + 10];
        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                sum[i][j] = sum[i - 1][j] + sum[i][j - 1] - sum[i - 1][j - 1] + img[i - 1][j - 1];
            }
        }
        int[][] ans = new int[m][n];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                int a = Math.max(0, i - 1), b = Math.max(0, j - 1);
                int c = Math.min(m - 1, i + 1), d = Math.min(n - 1, j + 1);
                int cnt = (c - a + 1) * (d - b + 1);
                int tot = sum[c + 1][d + 1] - sum[a][d + 1] - sum[c + 1][b] + sum[a][b];
                ans[i][j] = tot / cnt;
            }
        }
        return ans;
    }
}
```

```python
class Solution:
    def imageSmoother(self, img: List[List[int]]) -> List[List[int]]:
        m, n = len(img), len(img[0])
        sum = [[0] * (n + 10) for _ in range(m + 10)]
        for i, j in product(range(1, m + 1), range(1, n + 1)):
            sum[i][j] = sum[i - 1][j] + sum[i][j - 1] - sum[i - 1][j - 1] + img[i - 1][j - 1]
        ans = [[0] * n for _ in range(m)]
        for i, j in product(range(m), range(n)):
            a, b = max(0, i - 1), max(0, j - 1)
            c, d = min(m - 1, i + 1), min(n - 1, j + 1)
            cnt = (c - a + 1) * (d - b + 1)
            tot = sum[c + 1][d + 1] - sum[a][d + 1] - sum[c + 1][b] + sum[a][b]
            ans[i][j] = tot // cnt
        return ans
```

- 时间复杂度：$O(m \times n)$
- 空间复杂度：$O(m \times n)$
