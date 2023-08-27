### [构造矩形](https://leetcode.cn/problems/construct-the-rectangle/solutions/1060660/gou-zao-ju-xing-by-leetcode-solution-dest/)

#### 方法一：数学

根据题目给出的三个要求，可知：

1.  $L \cdot W=area$，这也意味着 $area$ 可以被 $W$ 整除；
2.  $L\ge W$，结合要求 $1$ 可得 $W \cdot W \le L \cdot W=area$，从而有 $W \le \lfloor \sqrt{area} \rfloor$；
3.  这意味着 $W$ 应取满足 $area$ 可以被 $W$ 整除且 $W \le \lfloor \sqrt{area} \rfloor$ 的最大值。

我们可以初始化 $W= \lfloor \sqrt{area} \rfloor$，不断循环判断 $area$ 能否被 $W$ 整除，如果可以则跳出循环，否则将 $W$ 减一后继续循环。

循环结束后我们就找到了答案，长为 $\dfrac{area}{W}$，宽为 $W$。

```python
class Solution:
    def constructRectangle(self, area: int) -> List[int]:
        w = int(sqrt(area))
        while area % w:
            w -= 1
        return [area // w, w]
```

```cpp
class Solution {
public:
    vector<int> constructRectangle(int area) {
        int w = sqrt(1.0 * area);
        while (area % w) {
            --w;
        }
        return {area / w, w};
    }
};
```

```java
class Solution {
    public int[] constructRectangle(int area) {
        int w = (int) Math.sqrt(area);
        while (area % w != 0) {
            --w;
        }
        return new int[]{area / w, w};
    }
}
```

```csharp
public class Solution {
    public int[] ConstructRectangle(int area) {
        int w = (int) Math.Sqrt(area);
        while (area % w != 0) {
            --w;
        }
        return new int[]{area / w, w};
    }
}
```

```go
func constructRectangle(area int) []int {
    w := int(math.Sqrt(float64(area)))
    for area%w > 0 {
        w--
    }
    return []int{area / w, w}
}
```

```javascript
var constructRectangle = function(area) {
    let w = Math.floor(Math.sqrt(area));
    while (area % w !== 0) {
        --w;
    }
    return [Math.floor(area / w), w];
};
```

**复杂度分析**

-   时间复杂度：$O(\sqrt{area})$。当 $area$ 为质数时为最坏情况。
-   空间复杂度：$O(1)$。
