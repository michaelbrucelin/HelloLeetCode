#### [方法二：枚举 + 数学优化](https://leetcode.cn/problems/he-wei-sde-lian-xu-zheng-shu-xu-lie-lcof/solutions/128296/mian-shi-ti-57-ii-he-wei-sde-lian-xu-zheng-shu-x-2/)

方法一在枚举每个正整数为起点判断的时候是暴力从起点开始累加 $sum$ 和判断是否等于 $target$ 。但注意到，如果我们知道起点 $x$ 和终点 $y$ ，那么 $x$ 累加到 $y$ 的和由求和公式可以知道是 $\frac{(x+y) \times (y-x+1)}{2}$ ，那么问题就转化为了是否存在一个正整数 $y(y>x)$ ，满足等式

$$\frac{(x+y) \times (y-x+1)}{2}=target$$

转化一下变成

$$y^2+y-x^2+x-2 \times target=0$$

这是一个关于 $y$ 的一元二次方程，其中 $a=1,b=1,c=-x^2+x-2 \times target$ 直接套用[求根公式](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E4%B8%80%E5%85%83%E4%BA%8C%E6%AC%A1%E6%96%B9%E7%A8%8B%2F7231190%3Ffr%3Daladdin%234)即可 $O(1)$ 解得 $y$ ，判断是否整数解需要满足两个条件：

-   判别式 $b^2-4ac$ 开根需要为整数
-   最后的求根公式的分子需要为偶数，因为分母为 $2$

```cpp
class Solution {
public:
    vector<vector<int>> findContinuousSequence(int target) {
        vector<vector<int>> vec;
        vector<int> res;
        int sum = 0, limit = (target - 1) / 2; // (target - 1) / 2 等效于 target / 2 下取整
        for (int x = 1; x <= limit; ++x) {
            long long delta = 1 - 4 * (x - 1ll * x * x - 2 * target);
            if (delta < 0) {
                continue;
            }
            int delta_sqrt = (int)sqrt(delta + 0.5);
            if (1ll * delta_sqrt * delta_sqrt == delta && (delta_sqrt - 1) % 2 == 0) {
                int y = (-1 + delta_sqrt) / 2; // 另一个解(-1-delta_sqrt)/2必然小于0，不用考虑
                if (x < y) {
                    res.clear();
                    for (int i = x; i <= y; ++i) {
                        res.emplace_back(i);
                    }
                    vec.emplace_back(res);
                }
            }
        }
        return vec;
    }
};
```

```java
class Solution {
    public int[][] findContinuousSequence(int target) {
        List<int[]> vec = new ArrayList<int[]>();
        int sum = 0, limit = (target - 1) / 2; // (target - 1) / 2 等效于 target / 2 下取整
        for (int x = 1; x <= limit; ++x) {
            long delta = 1 - 4 * (x - (long) x * x - 2 * target);
            if (delta < 0) {
                continue;
            }
            int delta_sqrt = (int) Math.sqrt(delta + 0.5);
            if ((long) delta_sqrt * delta_sqrt == delta && (delta_sqrt - 1) % 2 == 0) {
                int y = (-1 + delta_sqrt) / 2; // 另一个解(-1-delta_sqrt)/2必然小于0，不用考虑
                if (x < y) {
                    int[] res = new int[y - x + 1];
                    for (int i = x; i <= y; ++i) {
                        res[i - x] = i;
                    }
                    vec.add(res);
                }
            }
        }
        return vec.toArray(new int[vec.size()][]);
    }
}
```

**复杂度分析**

-   时间复杂度：由于枚举以后只需要 $O(1)$ 的时间判断，所以时间复杂度为枚举起点的复杂度$O(target)$ 。
-   空间复杂度：$O(1)$ ，除了答案数组只需要常数的空间存放若干变量。
