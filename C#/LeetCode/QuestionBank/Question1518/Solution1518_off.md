#### [前言](https://leetcode.cn/problems/water-bottles/solutions/339339/huan-jiu-wen-ti-by-leetcode-solution/)

记一开始有 $b$ 瓶酒，$e$ 个空瓶换一瓶酒。

#### [方法一：模拟](https://leetcode.cn/problems/water-bottles/solutions/339339/huan-jiu-wen-ti-by-leetcode-solution/)

**思路与算法**

首先我们一定可以喝到 $b$ 瓶酒，剩下 $b$ 个空瓶。接下来我们可以拿瓶子换酒，每次拿出 $e$ 个瓶子换一瓶酒，然后再喝完这瓶酒，得到一个空瓶。以此类推，我们可以统计得到答案。

**代码**

```cpp
class Solution {
public:
    int numWaterBottles(int numBottles, int numExchange) {
        int bottle = numBottles, ans = numBottles;
        while (bottle >= numExchange) {
            bottle -= numExchange;
            ++ans;
            ++bottle;
        }
        return ans;
    }
};
```

```java
class Solution {
    public int numWaterBottles(int numBottles, int numExchange) {
        int bottle = numBottles, ans = numBottles;
        while (bottle >= numExchange) {
            bottle -= numExchange;
            ++ans;
            ++bottle;
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int NumWaterBottles(int numBottles, int numExchange) {
        int bottle = numBottles, ans = numBottles;
        while (bottle >= numExchange) {
            bottle -= numExchange;
            ++ans;
            ++bottle;
        }
        return ans;
    }
}
```

```python
class Solution:
    def numWaterBottles(self, numBottles: int, numExchange: int) -> int:
        bottle, ans = numBottles, numBottles
        while bottle >= numExchange:
            bottle -= numExchange
            ans += 1
            bottle += 1
        return ans
```

```c
int numWaterBottles(int numBottles, int numExchange){
    int bottle = numBottles, ans = numBottles;
    while (bottle >= numExchange) {
        bottle -= numExchange;
        ++ans;
        ++bottle;
    }
    return ans;
}
```

```go
func numWaterBottles(numBottles int, numExchange int) int {
    bottle, ans := numBottles, numBottles
    for bottle >= numExchange {
        bottle = bottle - numExchange
        ans++
        bottle++
    }
    return ans
}
```

```javascript
var numWaterBottles = function(numBottles, numExchange) {
    let bottle = numBottles, ans = numBottles;
    while (bottle >= numExchange) {
        bottle -= numExchange;
        ++ans;
        ++bottle;
    }
    return ans;
};
```

**复杂度分析**

-   时间复杂度：$O\Big(\dfrac{b}{e}\Big)$。因为 $e \geq 2$，而循环迭代时，每次 $b$ 的变化为 $e - 1$，故这里的渐进上界为 $O\Big(\dfrac{b}{e}\Big)$。
-   空间复杂度：$O(1)$。
