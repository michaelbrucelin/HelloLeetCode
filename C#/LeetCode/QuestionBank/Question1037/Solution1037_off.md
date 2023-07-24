#### [方法一：向量叉乘](https://leetcode.cn/problems/valid-boomerang/solutions/1540033/you-xiao-de-hui-xuan-biao-by-leetcode-so-yqby/)

计算从 $points[0]$ 开始，分别指向 $points[1]$ 和 $points[2]$ 的向量 $\vec{v}_1$ 和 $\vec{v}_2$。「三点各不相同且不在一条直线上」等价于「这两个向量的叉乘结果不为零」：

$$\vec{v}_1 \times \vec{v}_2 \ne \vec{0}$$

```python
class Solution:
    def isBoomerang(self, points: List[List[int]]) -> bool:
        v1 = (points[1][0] - points[0][0], points[1][1] - points[0][1])
        v2 = (points[2][0] - points[0][0], points[2][1] - points[0][1])
        return v1[0] * v2[1] - v1[1] * v2[0] != 0
```

```cpp
class Solution {
public:
    bool isBoomerang(vector<vector<int>>& points) {
        vector<int> v1 = {points[1][0] - points[0][0], points[1][1] - points[0][1]};
        vector<int> v2 = {points[2][0] - points[0][0], points[2][1] - points[0][1]};
        return v1[0] * v2[1] - v1[1] * v2[0] != 0;
    }
};
```

```java
class Solution {
    public boolean isBoomerang(int[][] points) {
        int[] v1 = {points[1][0] - points[0][0], points[1][1] - points[0][1]};
        int[] v2 = {points[2][0] - points[0][0], points[2][1] - points[0][1]};
        return v1[0] * v2[1] - v1[1] * v2[0] != 0;
    }
}
```

```csharp
public class Solution {
    public bool IsBoomerang(int[][] points) {
        int[] v1 = {points[1][0] - points[0][0], points[1][1] - points[0][1]};
        int[] v2 = {points[2][0] - points[0][0], points[2][1] - points[0][1]};
        return v1[0] * v2[1] - v1[1] * v2[0] != 0;
    }
}
```

```c
bool isBoomerang(int** points, int pointsSize, int* pointsColSize){
    int v1[2] = {points[1][0] - points[0][0], points[1][1] - points[0][1]};
    int v2[2] = {points[2][0] - points[0][0], points[2][1] - points[0][1]};
    return v1[0] * v2[1] - v1[1] * v2[0] != 0;
}
```

```go
func isBoomerang(points [][]int) bool {
    v1 := [2]int{points[1][0] - points[0][0], points[1][1] - points[0][1]}
    v2 := [2]int{points[2][0] - points[0][0], points[2][1] - points[0][1]}
    return v1[0]*v2[1]-v1[1]*v2[0] != 0
}
```

```javascript
var isBoomerang = function(points) {
    const v1 = [points[1][0] - points[0][0], points[1][1] - points[0][1]];
    const v2 = [points[2][0] - points[0][0], points[2][1] - points[0][1]];
    return v1[0] * v2[1] - v1[1] * v2[0] != 0;
};
```

**复杂度分析**

-   时间复杂度：$O(1)$。
-   空间复杂度：$O(1)$。
