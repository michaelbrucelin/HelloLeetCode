#### [朴素解法](https://leetcode.cn/problems/count-special-quadruplets/solutions/1181794/gong-shui-san-xie-yi-ti-si-jie-mei-ju-ha-gmhv/)

利用数据范围只有 $50$，可直接根据题意进行模拟。

代码：

```java
class Solution {
    public int countQuadruplets(int[] nums) {
        int n = nums.length, ans = 0;
        for (int a = 0; a < n; a++) {
            for (int b = a + 1; b < n; b++) {
                for (int c = b + 1; c < n; c++) {
                    for (int d = c + 1; d < n; d++) {
                        if (nums[a] + nums[b] + nums[c] == nums[d]) ans++;
                    }
                }
            }
        }
        return ans;
    }
}
```

-   时间复杂度：$O(n^4)$
-   空间复杂度：$O(1)$

___

#### [哈希表](https://leetcode.cn/problems/count-special-quadruplets/solutions/1181794/gong-shui-san-xie-yi-ti-si-jie-mei-ju-ha-gmhv/)

利用等式关系 $nums[a] + nums[b] + nums[c] = nums[d]$，可以调整枚举 $c$ 的顺序为「逆序」，每次 $c$ 往左移动一个单位，$d$ 的可取下标范围增加一个（即 $c + 1$ 位置)，使用数组代替哈希表对 $nums[d]$ 的个数进行统计，可使复杂度下降到 $O(n^3)$。

代码：

```java
class Solution {
    public int countQuadruplets(int[] nums) {
        int n = nums.length, ans = 0;
        int[] cnt = new int[10010];
        for (int c = n - 2; c >= 2; c--) {
            cnt[nums[c + 1]]++;
            for (int a = 0; a < n; a++) {
                for (int b = a + 1; b < c; b++) {
                    ans += cnt[nums[a] + nums[b] + nums[c]];
                }
            }
        }
        return ans;
    }
}
```

-   时间复杂度：$O(n^3)$
-   空间复杂度：$O(C)$

___

#### [哈希表](https://leetcode.cn/problems/count-special-quadruplets/solutions/1181794/gong-shui-san-xie-yi-ti-si-jie-mei-ju-ha-gmhv/)

更进一步，根据等式关系进行移项可得：$nums[a] + nums[b] = nums[d] - nums[c]$，其中各下标满足 $a < b < c < d$。

我们可在「逆序」枚举 $b$ 时，将新产生的 $c$（即 $b + 1$ 位置）所能产生的新 $nums[d] - nums[c]$ 的值存入哈希表（即 从 $[b + 2, n)$ 范围内枚举 $d$），最后通过枚举 $a$ 来统计答案。

> 一些细节：由于 $nums[d] - nums[c]$ 可能为负，在使用数组代替哈希表时，可利用 $1 <= nums[i] <= 100$ 做一个值偏移。

代码：

```java
class Solution {
    public int countQuadruplets(int[] nums) {
        int n = nums.length, ans = 0;
        int[] cnt = new int[10010];
        for (int b = n - 3; b >= 1; b--) {
            for (int d = b + 2; d < n; d++) cnt[nums[d] - nums[b + 1] + 200]++;
            for (int a = 0; a < b; a++) ans += cnt[nums[a] + nums[b] + 200];
        }
        return ans;
    }
}
```

-   时间复杂度：$O(n^2)$
-   空间复杂度：$O(C)$

___

#### [多维背包](https://leetcode.cn/problems/count-special-quadruplets/solutions/1181794/gong-shui-san-xie-yi-ti-si-jie-mei-ju-ha-gmhv/)

利用等式关系 $nums[a] + nums[b] + nums[c] = nums[d]$，具有明确的「数值」和「个数」关系，可将问题抽象为组合优化问题求方案数。

限制组合个数的维度有两个，均为「恰好」限制，转换为「二维费用背包问题求方案数」问题。

**定义 $f[i][j][k]$ 为考虑前 $i$ 个物品（下标从 $1$ 开始），凑成数值恰好 $j$，使用个数恰好为 $k$ 的方案数。**

最终答案为 $\sum_{i = 3}^{n - 1}(f[i][nums[i]][3])$，起始状态 $f[0][0][0] = 1$ 代表不考虑任何物品时，所用个数为 $0$，凑成数值为 $0$ 的方案数为 $1$。

不失一般性考虑 $f[i][j][k]$ 该如何转移，根据 $nums[i - 1]$ 是否参与组合进行分情况讨论：

-   $nums[i - 1]$ 不参与组成，此时有：$f[i - 1][j][k]$;
-   $nums[i - 1]$ 参与组成，此时有：$f[i - 1][j - t][k - 1]$;

最终 $f[i][j][k]$ 为上述两种情况之和，最终统计 $\sum_{i = 3}^{n - 1}(f[i][nums[i]][3])$ 即是答案。

> 利用 $f[i][j][k]$ 仅依赖于 $f[i - 1][j][k]$ 和 `j` `k` 维度值更小的 $f[i - 1][X][X]$，可进行维度优化，并在转移过程中统计答案。

代码（维度优化见 $P2$）：

```java
class Solution {
    public int countQuadruplets(int[] nums) {
        int n = nums.length;
        int[][][] f = new int[n + 1][110][4];
        f[0][0][0] = 1;
        for (int i = 1; i <= n; i++) {
            int t = nums[i - 1];
            for (int j = 0; j < 110; j++) {
                for (int k = 0; k < 4; k++) {
                    f[i][j][k] += f[i - 1][j][k];
                    if (j - t >= 0 && k - 1 >= 0) f[i][j][k] += f[i - 1][j - t][k - 1];
                }
            }
        }
        int ans = 0;
        for (int i = 3; i < n; i++) ans += f[i][nums[i]][3];
        return ans;
    }
}
```

```java
class Solution {
    public int countQuadruplets(int[] nums) {
        int n = nums.length, ans = 0;
        int[][] f = new int[110][4];
        f[0][0] = 1;
        for (int i = 1; i <= n; i++) {
            int t = nums[i - 1];
            ans += f[t][3];
            for (int j = 109; j >= 0; j--) {
                for (int k = 3; k >= 0; k--) {
                    if (j - t >= 0 && k - 1 >= 0) f[j][k] += f[j - t][k - 1];
                }
            }
        }
        return ans;
    }
}
```

-   时间复杂度：$O(n \times 110 \times 4)$
-   空间复杂度：$O(n \times 110 \times 4)$
