### [不同路径 II](https://leetcode.cn/problems/unique-paths-ii/solutions/316968/bu-tong-lu-jing-ii-by-leetcode-solution-2/)

#### 方法一：动态规划

**思路和算法**

我们用 $f(i,j)$ 来表示从坐标 $(0,0)$ 到坐标 $(i,j)$ 的路径总数，$u(i,j)$ 表示坐标 $(i,j)$ 是否可行，如果坐标 $(i,j)$ 有障碍物，$u(i,j)=0$，否则 $u(i,j)=1$。

因为「机器人每次只能向下或者向右移动一步」，所以从坐标 $(0,0)$ 到坐标 $(i,j)$ 的路径总数的值只取决于从坐标 $(0,0)$ 到坐标 $(i-1,j)$ 的路径总数和从坐标 $(0,0)$ 到坐标 $(i,j-1)$ 的路径总数，即 $f(i,j)$ 只能通过 $f(i-1,j)$ 和 $f(i,j-1)$ 转移得到。当坐标 $(i,j)$ 本身有障碍的时候，任何路径都到到不了 $f(i,j)$，此时 $f(i,j)=0$；下面我们来讨论坐标 $(i,j)$ 没有障碍的情况：如果坐标 $(i-1,j)$ 没有障碍，那么就意味着从坐标 $(i-1,j)$ 可以走到 $(i,j)$，即 $(i-1,j)$ 位置对 $f(i,j)$ 的贡献为 $f(i-1,j)$，同理，当坐标 $(i,j-1)$ 没有障碍的时候，$(i,j-1)$ 位置对 $f(i,j)$ 的贡献为 $f(i,j-1)$。综上所述，我们可以得到这样的动态规划转移方程：

$$f(i,j)=\begin{cases}0, & u(i,j)=0 \\ f(i-1,j)+f(i,j-1), & u(i,j) \ne 0\end{cases}$$

很显然我们可以给出一个时间复杂度 $O(nm)$ 并且空间复杂度也是 $O(nm)$ 的实现，由于这里 $f(i,j)$ 只与 $f(i-1,j)$ 和 $f(i,j-1)$ 相关，我们可以运用「滚动数组思想」把空间复杂度优化称 $O(m)$。**「滚动数组思想」是一种常见的动态规划优化方法，在我们的题目中已经多次使用到，例如「剑指 Offer 46. 把数字翻译成字符串」、「70. 爬楼梯」等，当我们定义的状态在动态规划的转移方程中只和某几个状态相关的时候，就可以考虑这种优化方法，目的是给空间复杂度「降维」。如果你还不知道什么是「滚动数组思想」，一定要查阅相关资料进行学习哦。**

代码中给出了使用「滚动数组思想」优化后的实现。

回顾这道题，其实这类动态规划的题目在题库中也出现过多次，例如「221. 最大正方形」、「1162. 地图分析」等。他们都以二维坐标作为状态，大多数都可以使用滚动数组进行优化。如果我们熟悉这类问题，可以一眼看出这是一个动态规划问题。当我们不熟悉的时候，怎么想到用动态规划来解决这个问题呢？我们需要从问题本身出发，寻找一些有用的信息，例如本题中：

- $(i,j)$ 位置只能从 $(i-1,j)$ 和 $(i,j-1)$ 走到，这样的条件就是在告诉我们这里转移是 **「无后效性」** 的，$f(i,j)$ 和任何的 $f(i′,j′)(i′>i,j′>j)$ 无关。
- 动态规划的题目分为两大类，一种是求最优解类，典型问题是背包问题，另一种就是计数类，比如这里的统计方案数的问题，它们都存在一定的递推性质。前者的递推性质还有一个名字，叫做 **「最优子结构」** ——即当前问题的最优解取决于子问题的最优解，后者类似，当前问题的方案数取决于子问题的方案数。所以在遇到求方案数的问题时，我们可以往动态规划的方向考虑。

通常如果我们察觉到了这两点要素，这个问题八成可以用动态规划来解决。读者可以多多练习，熟能生巧。

**代码**

```C++
class Solution {
public:
    int uniquePathsWithObstacles(vector<vector<int>>& obstacleGrid) {
        int n = obstacleGrid.size(), m = obstacleGrid.at(0).size();
        vector <int> f(m);

        f[0] = (obstacleGrid[0][0] == 0);
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                if (obstacleGrid[i][j] == 1) {
                    f[j] = 0;
                    continue;
                }
                if (j - 1 >= 0 && obstacleGrid[i][j - 1] == 0) {
                    f[j] += f[j - 1];
                }
            }
        }

        return f.back();
    }
};
```

```Java
class Solution {
    public int uniquePathsWithObstacles(int[][] obstacleGrid) {
        int n = obstacleGrid.length, m = obstacleGrid[0].length;
        int[] f = new int[m];

        f[0] = obstacleGrid[0][0] == 0 ? 1 : 0;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                if (obstacleGrid[i][j] == 1) {
                    f[j] = 0;
                    continue;
                }
                if (j - 1 >= 0 && obstacleGrid[i][j - 1] == 0) {
                    f[j] += f[j - 1];
                }
            }
        }
        
        return f[m - 1];
    }
}
```

```Go
func uniquePathsWithObstacles(obstacleGrid [][]int) int {
    n, m := len(obstacleGrid), len(obstacleGrid[0])
    f := make([]int, m)
    if obstacleGrid[0][0] == 0 {
        f[0] = 1
    }
    for i := 0; i < n; i++ {
        for j := 0; j < m; j++ {
            if obstacleGrid[i][j] == 1 {
                f[j] = 0
                continue
            }
            if j - 1 >= 0 && obstacleGrid[i][j-1] == 0 {
                f[j] += f[j-1]
            }
        }
    }
    return f[len(f)-1]
}
```

```C
int uniquePathsWithObstacles(int** obstacleGrid, int obstacleGridSize,
                             int* obstacleGridColSize) {
    int n = obstacleGridSize, m = obstacleGridColSize[0];
    int f[m];
    memset(f, 0, sizeof(f));
    f[0] = (obstacleGrid[0][0] == 0);
    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < m; ++j) {
            if (obstacleGrid[i][j] == 1) {
                f[j] = 0;
                continue;
            }
            if (j - 1 >= 0 && obstacleGrid[i][j - 1] == 0) {
                f[j] += f[j - 1];
            }
        }
    }

    return f[m - 1];
}
```

**复杂度分析**

- 时间复杂度：$O(nm)$，其中 $n$ 为网格的行数，$m$ 为网格的列数。我们只需要遍历所有网格一次即可。
- 空间复杂度：$O(m)$。利用滚动数组优化，我们可以只用 $O(m)$ 大小的空间来记录当前行的 $f$ 值。
