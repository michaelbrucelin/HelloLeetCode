#### [【三种方法】3进制枚举 / 回溯 / 动态规划](https://leetcode.cn/problems/closest-dessert-cost/solutions/2004842/san-chong-fang-fa-3jin-zhi-mei-ju-hui-su-r8re/)

> Problem: [1774\. 最接近目标价格的甜点成本](https://leetcode.cn/problems/closest-dessert-cost/description/)

1.  [方法一：三进制枚举](https://leetcode.cn/problems/closest-dessert-cost/solutions/2004842/san-chong-fang-fa-3jin-zhi-mei-ju-hui-su-r8re//#%E6%96%B9%E6%B3%95%E4%B8%80%E4%B8%89%E8%BF%9B%E5%88%B6%E6%9E%9A%E4%B8%BE)    
    1.  [思路](https://leetcode.cn/problems/closest-dessert-cost/solutions/2004842/san-chong-fang-fa-3jin-zhi-mei-ju-hui-su-r8re//#%E6%80%9D%E8%B7%AF)
    2.  [Code](https://leetcode.cn/problems/closest-dessert-cost/solutions/2004842/san-chong-fang-fa-3jin-zhi-mei-ju-hui-su-r8re//#code)
2.  [方法二：回溯](https://leetcode.cn/problems/closest-dessert-cost/solutions/2004842/san-chong-fang-fa-3jin-zhi-mei-ju-hui-su-r8re//#%E6%96%B9%E6%B3%95%E4%BA%8C%E5%9B%9E%E6%BA%AF)    
    1.  [思路](https://leetcode.cn/problems/closest-dessert-cost/solutions/2004842/san-chong-fang-fa-3jin-zhi-mei-ju-hui-su-r8re//#%E6%80%9D%E8%B7%AF-1)
    2.  [Code](https://leetcode.cn/problems/closest-dessert-cost/solutions/2004842/san-chong-fang-fa-3jin-zhi-mei-ju-hui-su-r8re//#code-1)
3.  [方法三：动态规划](https://leetcode.cn/problems/closest-dessert-cost/solutions/2004842/san-chong-fang-fa-3jin-zhi-mei-ju-hui-su-r8re//#%E6%96%B9%E6%B3%95%E4%B8%89%E5%8A%A8%E6%80%81%E8%A7%84%E5%88%92)
    1.  [思路](https://leetcode.cn/problems/closest-dessert-cost/solutions/2004842/san-chong-fang-fa-3jin-zhi-mei-ju-hui-su-r8re//#%E6%80%9D%E8%B7%AF-2)
    2.  [Code](https://leetcode.cn/problems/closest-dessert-cost/solutions/2004842/san-chong-fang-fa-3jin-zhi-mei-ju-hui-su-r8re//#code-2)

#### 方法一：三进制枚举

##### 思路

> 3进制枚举，类似二进制枚举

##### Code

```c
int closestCost(int* baseCosts, int baseCostsSize, int* toppingCosts, int toppingCostsSize, int target){
    int i, j, k, t, cost, ans = 0x3f3f3f3f, n = pow(3, toppingCostsSize);

    for (i = 0; i < baseCostsSize; i++) {
        for (j = 0; j < n; j++) {
            cost = baseCosts[i];
            for (k = 0, t = j; k < toppingCostsSize; k++) {
                cost += (t % 3) * toppingCosts[k];
                t /= 3;
            }
            if ((abs(cost - target) < abs(ans - target)) || ((abs(cost - target) == abs(ans - target)) && (cost < ans)))
                ans = cost;
        }
    }
    return ans;
}
```

#### 方法二：回溯

##### 思路

> 回溯法，每一份配料都有三种选择，选0份，选1份，选2份，依次选择每种配料的每种选择。

##### Code

```c
#define INF 0X3f3f3f3f
int ans;
void dfs(int s, int* toppingCosts, int toppingCostsSize, int target, int idx)
{
    int i;

    if (idx == toppingCostsSize) {
        if (abs(s - target) < abs(ans - target) || abs(s - target) == abs(ans - target) && ans > s)
            ans = s;
        return;
    }

    for (i = 0; i < 3; i++) {
        s += i * toppingCosts[idx];
        dfs(s, toppingCosts, toppingCostsSize, target, idx + 1);
        s -= i * toppingCosts[idx];
    }
}
int closestCost(int* baseCosts, int baseCostsSize, int* toppingCosts, int toppingCostsSize, int target){
    int i;

    for (ans = INF, i = 0; i < baseCostsSize; i++)
        dfs(baseCosts[i], toppingCosts, toppingCostsSize, target, 0);
    return ans;
}
```

#### 方法三：动态规划

##### 思路

> 因为每种辅料最多可以用两次，所以直接把每种辅料变成两个。基料必须且只能选一种，可以首先处理好。

##### Code

```c
#define MIN(a, b) ((a) < (b) ? (a) : (b))

int closestCost(int* baseCosts, int baseCostsSize, int* toppingCosts, int toppingCostsSize, int target) {
    int x = INT_MAX;
    bool dp[target + 1];
    
    for (int i = 0; i < baseCostsSize; i++)
        x = MIN(x, baseCosts[i]);
    if (x >= target)
        return x;
    memset(dp, 0, sizeof(dp));
    int res = 2 * target - x;
    for (int i = 0; i < baseCostsSize; i++) {
        if (baseCosts[i] <= target)
            dp[baseCosts[i]] = true;
        else
            res = MIN(res, baseCosts[i]);
    }
    for (int j = 0; j < toppingCostsSize; j++) {
        for (int count = 0; count < 2; ++count) {
            for (int i = target; i > 0; --i) {
                if (dp[i] && i + toppingCosts[j] > target)
                    res = MIN(res, i + toppingCosts[j]);
                if (i - toppingCosts[j] > 0)
                    dp[i] = dp[i] | dp[i - toppingCosts[j]];
            }
        }
    }
    for (int i = 0; i <= res - target; ++i) {
        if (dp[target - i])
            return target - i;
    }
    return res;
}
```
