### [访问所有点的最小时间](https://leetcode.cn/problems/minimum-time-visiting-all-points/solutions/101816/fang-wen-suo-you-dian-de-zui-xiao-shi-jian-by-le-2/)

#### 方法一：切比雪夫距离

对于平面上的两个点 `x = (x0, x1)` 和 `y = (y0, y1)`，设它们横坐标距离之差为 `dx = |x0 - y0|`，纵坐标距离之差为 `dy = |x1 - y1|`，对于以下三种情况，我们可以分别计算出从 `x` 移动到 `y` 的最少次数：

- `dx < dy`：沿对角线移动 `dx` 次，再竖直移动 `dy - dx` 次，总计 `dx + (dy - dx) = dy` 次；
- `dx == dy`：沿对角线移动 `dx` 次；
- `dx > dy`：沿对角线移动 `dy` 次，再水平移动 `dx - dy` 次，总计 `dy + (dx - dy) = dx` 次。

可以发现，对于任意一种情况，从 `x` 移动到 `y` 的最少次数为 `dx` 和 `dy` 中的较大值 `max(dx, dy)`，这也被称作 `x` 和 `y` 之间的 [切比雪夫距离](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E5%88%87%E6%AF%94%E9%9B%AA%E5%A4%AB%E8%B7%9D%E7%A6%BB)。

由于题目要求，需要按照数组中出现的顺序来访问这些点。因此我们遍历整个数组，对于数组中的相邻两个点，计算出它们的切比雪夫距离，所有的距离之和即为答案。

```C++
class Solution {
public:
    int minTimeToVisitAllPoints(vector<vector<int>>& points) {
        int x0 = points[0][0], x1 = points[0][1];
        int ans = 0;
        for (int i = 1; i < points.size(); ++i) {
            int y0 = points[i][0], y1 = points[i][1];
            ans += max(abs(x0 - y0), abs(x1 - y1));
            x0 = y0;
            x1 = y1;
        }
        return ans;
    }
};
```

```Python
class Solution:
    def minTimeToVisitAllPoints(self, points: List[List[int]]) -> int:
        x0, x1 = points[0]
        ans = 0
        for i in range(1, len(points)):
            y0, y1 = points[i]
            ans += max(abs(x0 - y0), abs(x1 - y1))
            x0, x1 = points[i]
        return ans
```

```Java
class Solution {
    public int minTimeToVisitAllPoints(int[][] points) {
        int x0 = points[0][0], y0 = points[0][1];
        int ans = 0;
        for (int i = 1; i < points.length; ++i) {
            int x1 = points[i][0], y1 = points[i][1];
            ans += Math.max(Math.abs(x0 - x1), Math.abs(y0 - y1));
            x0 = x1;
            y0 = y1;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MinTimeToVisitAllPoints(int[][] points) {
        int x0 = points[0][0], y0 = points[0][1];
        int ans = 0;
        for (int i = 1; i < points.Length; ++i) {
            int x1 = points[i][0], y1 = points[i][1];
            ans += Math.Max(Math.Abs(x0 - x1), Math.Abs(y0 - y1));
            x0 = x1;
            y0 = y1;
        }
        return ans;
    }
}
```

```Go
func minTimeToVisitAllPoints(points [][]int) int {
    x0, y0 := points[0][0], points[0][1]
    ans := 0
    for i := 1; i < len(points); i++ {
        x1, y1 := points[i][0], points[i][1]
        dx := abs(x0 - x1)
        dy := abs(y0 - y1)
        if dx > dy {
            ans += dx
        } else {
            ans += dy
        }
        x0, y0 = x1, y1
    }
    return ans
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

```C
#include <stdlib.h>

int minTimeToVisitAllPoints(int** points, int pointsSize, int* pointsColSize) {
    int x0 = points[0][0], y0 = points[0][1];
    int ans = 0;
    for (int i = 1; i < pointsSize; ++i) {
        int x1 = points[i][0], y1 = points[i][1];
        int dx = abs(x0 - x1);
        int dy = abs(y0 - y1);
        ans += (dx > dy) ? dx : dy;
        x0 = x1;
        y0 = y1;
    }
    return ans;
}
```

```JavaScript
var minTimeToVisitAllPoints = function(points) {
    let x0 = points[0][0], y0 = points[0][1];
    let ans = 0;
    for (let i = 1; i < points.length; ++i) {
        let x1 = points[i][0], y1 = points[i][1];
        ans += Math.max(Math.abs(x0 - x1), Math.abs(y0 - y1));
        x0 = x1;
        y0 = y1;
    }
    return ans;
};
```

```TypeScript
function minTimeToVisitAllPoints(points: number[][]): number {
    let x0 = points[0][0], y0 = points[0][1];
    let ans = 0;
    for (let i = 1; i < points.length; ++i) {
        let x1 = points[i][0], y1 = points[i][1];
        ans += Math.max(Math.abs(x0 - x1), Math.abs(y0 - y1));
        x0 = x1;
        y0 = y1;
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn min_time_to_visit_all_points(points: Vec<Vec<i32>>) -> i32 {
        let mut x0 = points[0][0];
        let mut y0 = points[0][1];
        let mut ans = 0;

        for i in 1..points.len() {
            let x1 = points[i][0];
            let y1 = points[i][1];
            ans += (x0 - x1).abs().max((y0 - y1).abs());
            x0 = x1;
            y0 = y1;
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(N)$，其中 $N$ 是数组的长度。
- 空间复杂度：$O(1)$。
