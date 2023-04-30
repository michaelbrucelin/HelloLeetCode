#### [方法一：检查位置](https://leetcode.cn/problems/rectangle-overlap/solutions/154848/ju-xing-zhong-die-by-leetcode-solution/)

**思路**

我们尝试分析在什么情况下，矩形 `rec1` 和 `rec2` 没有重叠。

如果矩形 `rec1` 和 `rec2` 中至少有一个矩形的面积为 $0$，则一定没有重叠。

当矩形 `rec1` 和 `rec2` 的面积都大于 $0$ 时，如果我们在平面中放置一个固定的矩形 `rec2`，那么矩形 `rec1` 必须要出现在 `rec2` 的「四周」，也就是说，矩形 `rec1` 需要满足以下四种情况中的至少一种：

-   矩形 `rec1` 在矩形 `rec2` 的左侧；
-   矩形 `rec1` 在矩形 `rec2` 的右侧；
-   矩形 `rec1` 在矩形 `rec2` 的上方；
-   矩形 `rec1` 在矩形 `rec2` 的下方。

何为「左侧」？如果矩形 `rec1` 在矩形 `rec2` 的左侧，那就表示我们可以找到一条竖直的线（可以与矩形的边重合），使得矩形 `rec1` 和 `rec2` 被分在这条竖线的两侧。对于「右侧」、「上方」以及「下方」，它们的定义与「左侧」是类似的。

**算法**

首先判断矩形 `rec1` 和 `rec2` 的面积是否为 $0$。

-   对于矩形 `rec1` 而言，其面积为 $0$ 当且仅当 `rec1[0] == rec1[2]` 或 `rec1[1] == rec1[3]`；
-   对于矩形 `rec2` 而言，其面积为 $0$ 当且仅当 `rec2[0] == rec2[2]` 或 `rec2[1] == rec2[3]`。

如果至少有一个矩形的面积为 $0$，则一定没有重叠。

如果矩形 `rec1` 和 `rec2` 的面积都大于 $0$，则考虑两个矩形的位置。我们将上述四种情况翻译成代码。具体地，我们用 `(rec[0], rec[1])` 表示矩形的左下角，`(rec[2], rec[3])` 表示矩形的右上角，与题目描述一致。对于「左侧」，即矩形 `rec1` 在 `x` 轴上的最大值不能大于矩形 `rec2` 在 `x` 轴上最小值。对于「右侧」、「上方」以及「下方」同理。因此我们可以翻译成如下的代码：

-   左侧：`rec1[2] <= rec2[0]`；
-   右侧：`rec1[0] >= rec2[2]`；
-   上方：`rec1[1] >= rec2[3]`；
-   下方：`rec1[3] <= rec2[1]`。

```java
class Solution {
    public boolean isRectangleOverlap(int[] rec1, int[] rec2) {
        if (rec1[0] == rec1[2] || rec1[1] == rec1[3] || rec2[0] == rec2[2] || rec2[1] == rec2[3]) {
            return false;
        }
        return !(rec1[2] <= rec2[0] ||   // left
                 rec1[3] <= rec2[1] ||   // bottom
                 rec1[0] >= rec2[2] ||   // right
                 rec1[1] >= rec2[3]);    // top
    }
}
```

```python
class Solution:
    def isRectangleOverlap(self, rec1: List[int], rec2: List[int]) -> bool:
        if rec1[0] == rec1[2] or rec1[1] == rec1[3] or rec2[0] == rec2[2] or rec2[1] == rec2[3]:
            return False
        return not (rec1[2] <= rec2[0] or  # left
                    rec1[3] <= rec2[1] or  # bottom
                    rec1[0] >= rec2[2] or  # right
                    rec1[1] >= rec2[3])    # top
```

```cpp
class Solution {
public:
    bool isRectangleOverlap(vector<int>& rec1, vector<int>& rec2) {
        if (rec1[0] == rec1[2] || rec1[1] == rec1[3] || rec2[0] == rec2[2] || rec2[1] == rec2[3]) {
            return false;
        }
        return !(rec1[2] <= rec2[0] ||   // left
                 rec1[3] <= rec2[1] ||   // bottom
                 rec1[0] >= rec2[2] ||   // right
                 rec1[1] >= rec2[3]);    // top
    }
};
```

**复杂度分析**

-   时间复杂度：$O(1)$。
-   空间复杂度：$O(1)$，不需要额外的空间。
