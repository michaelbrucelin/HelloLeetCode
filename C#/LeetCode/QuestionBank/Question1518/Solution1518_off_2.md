#### [方法二：数学](https://leetcode.cn/problems/water-bottles/solutions/339339/huan-jiu-wen-ti-by-leetcode-solution/)

**思路与算法**

第一步，首先我们一定可以喝到 $b$ 瓶酒，剩下 $b$ 个空瓶。

第二步，接下来我们来考虑空瓶换酒，换完再喝，喝完再换的过程——每次换到一瓶酒就意味着多一个空瓶，所以每次损失的瓶子的数量为 $e - 1$，我们要知道这个过程能得到多少瓶酒，即希望知道第一个打破下面这个条件的 $n$ 是多少：

$$b - n(e - 1) \geq e$$

即我们要找到最小的 $n$ 使得：

$$b - n(e - 1) < e$$

我们得到 $n_{\min} = \lfloor \dfrac{b - e}{e - 1} + 1\rfloor$。

当然我们要特别注意这里的前提条件是 $b \geq e$，试想如果 $b < e$，没有足够的瓶子再换酒了，就不能进行第二步了。

**代码**

```cpp
class Solution {
public:
    int numWaterBottles(int numBottles, int numExchange) {
        return numBottles >= numExchange ? (numBottles - numExchange) / (numExchange - 1) + 1 + numBottles : numBottles;
    }
};
```

```java
class Solution {
    public int numWaterBottles(int numBottles, int numExchange) {
        return numBottles >= numExchange ? (numBottles - numExchange) / (numExchange - 1) + 1 + numBottles : numBottles;
    }
}
```

```csharp
public class Solution {
    public int NumWaterBottles(int numBottles, int numExchange) {
        return numBottles >= numExchange ? (numBottles - numExchange) / (numExchange - 1) + 1 + numBottles : numBottles;
    }
}
```

```python
class Solution:
    def numWaterBottles(self, numBottles: int, numExchange: int) -> int:
        return (numBottles - numExchange) // (numExchange - 1) + 1 + numBottles if numBottles >= numExchange else numBottles
```

```c
int numWaterBottles(int numBottles, int numExchange){
    return numBottles >= numExchange ? (numBottles - numExchange) / (numExchange - 1) + 1 + numBottles : numBottles;
}
```

```go
func numWaterBottles(numBottles int, numExchange int) int {
    if numBottles < numExchange {
        return numBottles
    }
    return (numBottles - numExchange) / (numExchange - 1) + 1 + numBottles
}
```

```javascript
var numWaterBottles = function(numBottles, numExchange) {
    return numBottles >= numExchange ? Math.floor((numBottles - numExchange) / (numExchange - 1)) + 1 + numBottles : numBottles;
};
```

**复杂度分析**

-   时间复杂度：$O(1)$。
-   空间复杂度：$O(1)$。
