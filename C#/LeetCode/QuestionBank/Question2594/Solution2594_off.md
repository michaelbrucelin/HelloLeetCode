### [修车的最少时间](https://leetcode.cn/problems/minimum-time-to-repair-cars/solutions/2425409/xiu-che-de-zui-shao-shi-jian-by-leetcode-if20/?envType=daily-question&envId=2023-09-07)

#### 方法一：二分查找

**思路与算法**

题目要求解修理汽车所需的最少时间，故先考虑二分是否可行，若解的值域范围内有单调性，就可以使用二分：

-   假设 $t$ 分钟内可以将所有汽车都修理完，那么大于等于 $t$ 分钟内都可以将所有汽车修理完。
-   假设 $t$ 分钟内不能够将所有汽车都修理完，那么小于等于 $t$ 分钟内也不能够将所有汽车修理完。

因此，存在单调性。我们枚举一个时间 $t$，那么能力值为 $r$ 的工人可以修完 $\lfloor \sqrt{\frac{t}{r}} \rfloor$ 辆汽车。若所有工人可以修完的汽车数量之和大于等于 $cars$，那么调整右边界为 $t$，否则调整左边界为 $t + 1$。

二分的上界可以取正无穷，也可以取任意一个工人修完所有车辆所需要的时间。

**代码**

```cpp
class Solution {
public:
    using ll = long long;
    long long repairCars(vector<int>& ranks, int cars) {
        ll l = 1, r = 1ll * ranks[0] * cars * cars;
        auto check = [&](ll m) {
            ll cnt = 0;
            for (auto x : ranks) {
                cnt += sqrt(m / x);
            }
            return cnt >= cars;
        };
        while (l < r) {
            ll m = l + r >> 1;
            if (check(m)) {
                r = m;
            } else {
                l = m + 1;
            }
        }
        return l;
    }
};
```

```java
class Solution {
    public long repairCars(int[] ranks, int cars) {
        long l = 1, r = 1l * ranks[0] * cars * cars;
        while (l < r) {
            long m = l + r >> 1;
            if (check(ranks, cars, m)) {
                r = m;
            } else {
                l = m + 1;
            }
        }
        return l;
    }

    public boolean check(int[] ranks, int cars, long m) {
        long cnt = 0;
        for (int x : ranks) {
            cnt += (long) Math.sqrt(m / x);
        }
        return cnt >= cars;
    }
}
```

```csharp
public class Solution {
    public long RepairCars(int[] ranks, int cars) {
        long l = 1, r = 1l * ranks[0] * cars * cars;
        while (l < r) {
            long m = l + r >> 1;
            if (Check(ranks, cars, m)) {
                r = m;
            } else {
                l = m + 1;
            }
        }
        return l;
    }

    public bool Check(int[] ranks, int cars, long m) {
        long cnt = 0;
        foreach (int x in ranks) {
            cnt += (long) Math.Sqrt(m / x);
        }
        return cnt >= cars;
    }
}
```

```c
typedef long long ll;

static bool check(ll m, int* ranks, int ranksSize, int cars) {
    ll cnt = 0;
    for (int i = 0; i < ranksSize; i++) {
        int x = ranks[i];
        cnt += sqrt(m / x);
    }
    return cnt >= cars;
}

long long repairCars(int* ranks, int ranksSize, int cars) {
    ll l = 1, r = 1ll * ranks[0] * cars * cars;
    while (l < r) {
        ll m = l + r >> 1;
        if (check(m, ranks, ranksSize, cars)) {
            r = m;
        } else {
            l = m + 1;
        }
    }
    return l;
}
```

```python
class Solution:
    def repairCars(self, ranks: List[int], cars: int) -> int:
        l , r = 1, ranks[0] * cars * cars
        def check(m: int) -> bool:
            return sum([floor(sqrt(m // x)) for x in ranks]) >= cars
        while l < r:
            m = l + r >> 1
            if check(m):
                r = m
            else:
                l = m + 1
        return l
```

```go
func repairCars(ranks []int, cars int) int64 {
    l , r := 1, ranks[0] * cars * cars
    var check = func(m int) bool {
        cnt := 0
        for _, x := range ranks {
            cnt += int(math.Sqrt(float64(m / x)))
        }
        return cnt >= cars
    }
        
    for l < r {
        m := (l + r) >> 1
        if check(m) {
            r = m
        } else {
            l = m + 1
        }
    }
    return int64(l)
}
```

```javascript
var repairCars = function(ranks, cars) {
    let l = 1;
    let r = ranks[0] * cars * cars;
    const check = (m) => {
        let cnt = 0;
        for (const x of ranks) {
            cnt += Math.floor(Math.sqrt(m / x));
        }
        return cnt >= cars;
    }
        
    while (l < r) {
        const m = (l + r) >> 1;
        if (check(m)) {
            r = m;
        } else {
            l = m + 1;
        }
    }
    return l;
};
```

**复杂度分析**

-   时间复杂度：$O(n\log(L))$，其中 $n$ 为 $ranks$ 的长度，$L$ 为二分的上界。
-   空间复杂度：$O(1)$。过程中仅用到常数个变量。
