### [求交集区域内的最大正方形面积](https://leetcode.cn/problems/find-the-largest-area-of-square-inside-two-rectangles/solutions/3878877/qiu-jiao-ji-qu-yu-nei-de-zui-da-zheng-fa-90ch/)

#### 方法一：遍历 + 计算几何

**思路与算法**

首先注意，本题要求的是所有矩形**两两重叠**区域内的最大正方形面积，而不是所有矩形重叠区域内的最大正方形面积。

故考虑二重循环遍历矩形，由于矩形的重叠区域只能是矩形，故重叠区域的最大正方形边长等于重叠区域长和宽中的较小值。在遍历时不断更新全局最优解，最后解的平方即为所求。

遍历每个矩形对，分别计算重叠区域的长宽。以计算重叠区域的宽度为例，将两个矩形投影到 $x$ 轴上得到两条水平线段，这两条线段交集的长度应为右端点的较小值减去左端点的较大值。若两条线段不重叠，则这样计算出的值小于零。同理可得，重叠区域的高度应为两条线段上端点的较小值减去下端点的较大值。

在实现时，可以提前将待更新的最大边长设为 $0$。由于不相交时重叠区域长宽中的较小值一定是负数，不会更新答案，因此可以省去不相交情形下的特判处理。

**代码**

```C++
class Solution {
public:
    long long largestSquareArea(vector<vector<int>>& bottomLeft, vector<vector<int>>& topRight) {
        int n = bottomLeft.size();
        int maxSide = 0;

        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int w = min(topRight[i][0], topRight[j][0]) -
                        max(bottomLeft[i][0], bottomLeft[j][0]);
                int h = min(topRight[i][1], topRight[j][1]) -
                        max(bottomLeft[i][1], bottomLeft[j][1]);

                maxSide = max(maxSide, min(w, h));
            }
        }

        return 1LL * maxSide * maxSide;
    }
};
```

```Python
class Solution:
    def largestSquareArea(self, bottomLeft: List[List[int]], topRight: List[List[int]]) -> int:
        max_size = 0

        for (bottom_left_i, top_right_i), (bottom_left_j, top_right_j) in combinations(zip(bottomLeft, topRight), 2):
            w = min(top_right_i[0], top_right_j[0]) - max(bottom_left_i[0], bottom_left_j[0])
            h = min(top_right_i[1], top_right_j[1]) - max(bottom_left_i[1], bottom_left_j[1])

            max_size = max(max_size, min(w, h))

        return max_size * max_size
```

```Java
class Solution {
    public long largestSquareArea(int[][] bottomLeft, int[][] topRight) {
        int n = bottomLeft.length;
        long maxSide = 0;

        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int w = Math.min(topRight[i][0], topRight[j][0]) -
                        Math.max(bottomLeft[i][0], bottomLeft[j][0]);
                int h = Math.min(topRight[i][1], topRight[j][1]) -
                        Math.max(bottomLeft[i][1], bottomLeft[j][1]);
                int side = Math.min(w, h);

                maxSide = Math.max(maxSide, side);
            }
        }

        return maxSide * maxSide;
    }
}
```

```CSharp
public class Solution {
    public long LargestSquareArea(int[][] bottomLeft, int[][] topRight) {
        int n = bottomLeft.Length;
        long maxSide = 0;

        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int w = Math.Min(topRight[i][0], topRight[j][0]) - Math.Max(bottomLeft[i][0], bottomLeft[j][0]);
                int h = Math.Min(topRight[i][1], topRight[j][1]) - Math.Max(bottomLeft[i][1], bottomLeft[j][1]);

                maxSide = Math.Max(maxSide, Math.Min(w, h));
            }
        }

        return maxSide * maxSide;
    }
}
```

```Go
func largestSquareArea(bottomLeft [][]int, topRight [][]int) int64 {
    n := len(bottomLeft)
    var maxSide int64 = 0

    for i := 0; i < n; i++ {
        for j := i + 1; j < n; j++ {
            w := min(topRight[i][0], topRight[j][0]) - max(bottomLeft[i][0], bottomLeft[j][0])
            h := min(topRight[i][1], topRight[j][1]) - max(bottomLeft[i][1], bottomLeft[j][1])

            if w > 0 && h > 0 {
                side := min(w, h)
                if int64(side) > maxSide {
                    maxSide = int64(side)
                }
            }
        }
    }

    return maxSide * maxSide
}
```

```C
long long largestSquareArea(int** bottomLeft, int bottomLeftSize, int* bottomLeftColSize, int** topRight, int topRightSize, int* topRightColSize) {
    int n = bottomLeftSize;
    long long maxSide = 0;

    for (int i = 0; i < n; i++) {
        for (int j = i + 1; j < n; j++) {
            int w = fmin(topRight[i][0], topRight[j][0]) - fmax(bottomLeft[i][0], bottomLeft[j][0]);
            int h = fmin(topRight[i][1], topRight[j][1]) - fmax(bottomLeft[i][1], bottomLeft[j][1]);
            if (w > 0 && h > 0) {
                int side = fmin(w, h);
                if ((long long)side > maxSide) {
                    maxSide = (long long)side;
                }
            }
        }
    }

    return maxSide * maxSide;
}
```

```JavaScript
var largestSquareArea = function (bottomLeft, topRight) {
    const n = bottomLeft.length;
    let maxSide = 0;

    for (let i = 0; i < n; i++) {
        for (let j = i + 1; j < n; j++) {
            const w = Math.min(topRight[i][0], topRight[j][0]) - Math.max(bottomLeft[i][0], bottomLeft[j][0]);
            const h = Math.min(topRight[i][1], topRight[j][1]) - Math.max(bottomLeft[i][1], bottomLeft[j][1]);

            maxSide = Math.max(maxSide, Math.min(w, h));
        }
    }

    return maxSide * maxSide;
};
```

```TypeScript
function largestSquareArea(bottomLeft: number[][], topRight: number[][]): number {
    const n = bottomLeft.length;
    let maxSide = 0;

    for (let i = 0; i < n; i++) {
        for (let j = i + 1; j < n; j++) {
            const w = Math.min(topRight[i][0], topRight[j][0]) - Math.max(bottomLeft[i][0], bottomLeft[j][0]);
            const h = Math.min(topRight[i][1], topRight[j][1]) - Math.max(bottomLeft[i][1], bottomLeft[j][1]);

            maxSide = Math.max(maxSide, Math.min(w, h));
        }
    }

    return maxSide * maxSide;
};
```

```Rust
use cmp::{max, min};

impl Solution {
    pub fn largest_square_area(bottom_left: Vec<Vec<i32>>, top_right: Vec<Vec<i32>>) -> i64 {
        let n = bottom_left.len();
        let mut max_side = 0;

        for i in 0..n {
            for j in i + 1..n {
                let w = min(top_right[i][0], top_right[j][0]) - max(bottom_left[i][0], bottom_left[j][0]);
                let h = min(top_right[i][1], top_right[j][1]) - max(bottom_left[i][1], bottom_left[j][1]);

                max_side = max(max_side, min(w, h));
            }
        }

        (max_side as i64) * (max_side as i64)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，进行了量级为 $n$ 的二重遍历。
- 空间复杂度：$O(1)$，只使用了常数个变量。
