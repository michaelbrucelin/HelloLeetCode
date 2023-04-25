#### [图解：将矩形重叠问题转化为区间重叠问题（C++/Java/Python）](https://leetcode.cn/problems/rectangle-overlap/solutions/155825/tu-jie-jiang-ju-xing-zhong-die-wen-ti-zhuan-hua-we/)

矩形重叠要考虑的情况很多，两个矩形的重叠可能有好多种不同的形态。这道题如果用蛮力做的话，很容易遗漏掉某些情况，导致出错。

矩形重叠是二维的问题，所以情况很多，比较复杂。为了简化问题，我们可以考虑将二维问题转化为一维问题。既然题目中的矩形都是平行于坐标轴的，我们将矩形投影到坐标轴上：

![](./assets/img/Solution0836_oth_01.jpg)

矩形投影到坐标轴上，就变成了**区间**。稍加思考，我们发现：**两个互相重叠的矩形，它们在 xxx 轴和 yyy 轴上投影出的区间也是互相重叠的**。这样，我们就将矩形重叠问题转化成了区间重叠问题。

区间重叠是一维的问题，比二维问题简单很多。我们可以穷举出两个区间所有可能的 6 种关系：

![](./assets/img/Solution0836_oth_02.jpg)

可以看到，区间的 6 种关系中，不重叠只有两种情况，判断不重叠更简单。假设两个区间分别是 `[s1, e1]` 和 `[s2, e2]` 的话，区间不重叠的两种情况就是 `e1 <= s2` 和 `e2 <= s1`。

![](./assets/img/Solution0836_oth_03.jpg)

我们就得到区间不重叠的条件：`e1 <= s2 || e2 <= s1`。将条件取反即为区间重叠的条件。

这样，我们就可以写出判断矩形重叠的代码了：

```cpp
bool isRectangleOverlap(vector<int>& rec1, vector<int>& rec2) {
    bool x_overlap = !(rec1[2] <= rec2[0] || rec2[2] <= rec1[0]);
    bool y_overlap = !(rec1[3] <= rec2[1] || rec2[3] <= rec1[1]);
    return x_overlap && y_overlap;
}
```

```java
public boolean isRectangleOverlap(int[] rec1, int[] rec2) {
    boolean x_overlap = !(rec1[2] <= rec2[0] || rec2[2] <= rec1[0]);
    boolean y_overlap = !(rec1[3] <= rec2[1] || rec2[3] <= rec1[1]);
    return x_overlap && y_overlap;
}
```

```python
def isRectangleOverlap(self, rec1: List[int], rec2: List[int]) -> bool:
    x_overlap = not(rec1[2] <= rec2[0] or rec2[2] <= rec1[0])
    y_overlap = not(rec1[3] <= rec2[1] or rec2[3] <= rec1[1])
    return x_overlap and y_overlap
```
