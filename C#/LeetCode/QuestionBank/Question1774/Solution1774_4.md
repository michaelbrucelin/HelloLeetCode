#### [转化为0-1背包求解](https://leetcode.cn/problems/closest-dessert-cost/solutions/625722/zhuan-hua-wei-0-1bei-bao-qiu-jie-by-luci-o5yt/)

本题数据范围很小，暴力枚举辅料组合就可以通过，但时间复杂度为指数级。

把问题转化为背包问题，可以将时间复杂度降低到多项式级别。

-   因为每种辅料最多可以用两次，所以直接把每种辅料变成两个。
-   基料必须且只能选一种，可以首先处理好。

之后就按照0-1背包问题的一般做法，依次枚举辅料即可。

-   时间复杂度$\mathcal{O}(N + M\cdot MAXC)$。其中$MAXC$为背包的最大容量。本题中$MAXC=20000$，因为答案不可能超过$20000$。
-   空间复杂度$\mathcal{O}(MAXC)$。

```cpp
class Solution {
public:
    int closestCost(vector<int>& baseCosts, vector<int>& toppingCosts, int target) {
        vector<bool> can(20001);
        for (int base : baseCosts)
            can[base] = true;
        toppingCosts.insert(toppingCosts.end(), toppingCosts.begin(), toppingCosts.end());
        for (int topping : toppingCosts) {
            for (int i = 20000; i >= topping; --i)
                can[i] = can[i] || can[i - topping];
        }
        int min_gap = INT_MAX, ans = 0;
        for (int i = 1; i <= 20000; ++i)
            if (can[i] && abs(i - target) < min_gap) {
                ans = i;
                min_gap = abs(i - target);
            }
        return ans;
    }
};
```
