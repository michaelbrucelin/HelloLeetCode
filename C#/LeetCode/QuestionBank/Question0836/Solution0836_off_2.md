#### [方法二：检查区域](https://leetcode.cn/problems/rectangle-overlap/solutions/154848/ju-xing-zhong-die-by-leetcode-solution/)

**思路**

如果两个矩形重叠，那么它们重叠的区域一定也是一个矩形，那么这代表了两个矩形与 $x$ 轴平行的边（水平边）投影到 $x$ 轴上时会有交集，与 $y$ 轴平行的边（竖直边）投影到 $y$ 轴上时也会有交集。因此，我们可以将问题看作一维线段是否有交集的问题。

**算法**

矩形 `rec1` 和 `rec2` 的水平边投影到 $x$ 轴上的线段分别为 `(rec1[0], rec1[2])` 和 `(rec2[0], rec2[2])`。根据数学知识我们可以知道，当 `min(rec1[2], rec2[2]) > max(rec1[0], rec2[0])` 时，这两条线段有交集。对于矩形 `rec1` 和 `rec2` 的竖直边投影到 $y$ 轴上的线段，同理可以得到，当 `min(rec1[3], rec2[3]) > max(rec1[1], rec2[1])` 时，这两条线段有交集。

```java
class Solution {
    public boolean isRectangleOverlap(int[] rec1, int[] rec2) {
        return (Math.min(rec1[2], rec2[2]) > Math.max(rec1[0], rec2[0]) &&
                Math.min(rec1[3], rec2[3]) > Math.max(rec1[1], rec2[1]));
    }
}
```

```python
class Solution:
    def isRectangleOverlap(self, rec1: List[int], rec2: List[int]) -> bool:
        def intersect(p_left, p_right, q_left, q_right):
            return min(p_right, q_right) > max(p_left, q_left)
        return (intersect(rec1[0], rec1[2], rec2[0], rec2[2]) and
                intersect(rec1[1], rec1[3], rec2[1], rec2[3]))
```

```cpp
class Solution {
public:
    bool isRectangleOverlap(vector<int>& rec1, vector<int>& rec2) {
        return (min(rec1[2], rec2[2]) > max(rec1[0], rec2[0]) &&
                min(rec1[3], rec2[3]) > max(rec1[1], rec2[1]));
    }
};
```

**复杂度分析**

-   时间复杂度：$O(1)$。
-   空间复杂度：$O(1)$，不需要额外的空间。
