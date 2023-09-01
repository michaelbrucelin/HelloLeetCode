### [买钢笔和铅笔的方案数](https://leetcode.cn/problems/number-of-ways-to-buy-pens-and-pencils/solutions/2359649/mai-gang-bi-he-qian-bi-de-fang-an-shu-by-83nk/?envType=daily-question&envId=2023-09-01)

#### 方法一：枚举

**思路与算法**

现在我们有 $total$ 的钱数，一支钢笔的价格为 $cost_1$，一支铅笔的价格为 $cost_2$，现在我们需要求能购买的钢笔和铅笔的不同方案数目。

假设我们当前买了 $x$ 支钢笔，满足 $cost_1 \times x \le total$，则我们有 $total - cost_1 \times x$ 的钱购买铅笔，则此时能购买的铅笔数可以为 $0, 1, \dots, \Big\lfloor \dfrac{total - cost_1 \times x}{cost_2} \Big\rfloor$，即方案数为 $\Big\lfloor \dfrac{total - cost_1 \times x}{cost_2} \Big\rfloor + 1$ 种。那么我们枚举可以购买的钢笔数，然后对每一种情况分别计算可以购买的铅笔数并求和即为总的方案数目。

在代码实现的过程中，由于钢笔和铅笔的价格相互独立，所以为了降低平均时间复杂度，当 $cost_1 < cost_2$ 时，我们将转换为枚举 $cost_2$ 来减少枚举次数。

**代码**

```python
class Solution:
    def waysToBuyPensPencils(self, total: int, cost1: int, cost2: int) -> int:
        if cost1 < cost2:
            return self.waysToBuyPensPencils(total, cost2, cost1)
        res, cnt = 0, 0
        while cnt * cost1 <= total:
            res += (total - cnt * cost1) // cost2 + 1
            cnt += 1
        return res
```

```java
class Solution {
    public long waysToBuyPensPencils(int total, int cost1, int cost2) {
        if (cost1 < cost2) {
            return waysToBuyPensPencils(total, cost2, cost1);
        }
        long res = 0, cnt = 0;
        while (cnt * cost1 <= total) {
            res += (total - cnt * cost1) / cost2 + 1;
            cnt++;
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public long WaysToBuyPensPencils(int total, int cost1, int cost2) {
        if (cost1 < cost2) {
            return WaysToBuyPensPencils(total, cost2, cost1);
        }
        long res = 0, cnt = 0;
        while (cnt * cost1 <= total) {
            res += (total - cnt * cost1) / cost2 + 1;
            cnt++;
        }
        return res;
    }
}
```

```cpp
class Solution {
public:
    long long waysToBuyPensPencils(int total, int cost1, int cost2) {
        if (cost1 < cost2) {
            return waysToBuyPensPencils(total, cost2, cost1);
        }
        long res = 0, cnt = 0;
        while (cnt * cost1 <= total) {
            res += (total - cnt * cost1) / cost2 + 1;
            cnt++;
        }
        return res;
    }
};
```

```go
func waysToBuyPensPencils(total int, cost1 int, cost2 int) int64 {
    if cost1 < cost2 {
        return waysToBuyPensPencils(total, cost2, cost1)
    }
    var res, cnt int
    for cnt * cost1 <= total {
        res += (total - cnt * cost1) / cost2 + 1
        cnt++
    }
    return int64(res)
}
```

```javascript
var waysToBuyPensPencils = function(total, cost1, cost2) {
    if (cost1 < cost2) {
        return waysToBuyPensPencils(total, cost2, cost1);
    }
    let res = 0, cnt = 0;
    while (cnt * cost1 <= total) {
        res += parseInt((total - cnt * cost1) / cost2) + 1;
        cnt++;
    }
    return res;
};
```

```c
long long waysToBuyPensPencils(int total, int cost1, int cost2){
    if (cost1 < cost2) {
        return waysToBuyPensPencils(total, cost2, cost1);
    }
    long long res = 0, cnt = 0;
    while (cnt * cost1 <= total) {
        res += (total - cnt * cost1) / cost2 + 1;
        cnt++;
    }
    return res;
}
```

**复杂度分析**

-   时间复杂度：$O(\Big\lfloor \dfrac{total}{\max\{cost_1, cost_2\}} \Big\rfloor)$，其中 $total$ 为初始拥有的钱数，$cost_1$ 和 $cost_2$ 分别为一支钢笔和一支铅笔的价格。
-   空间复杂度：$O(1)$。仅使用常量空间。
