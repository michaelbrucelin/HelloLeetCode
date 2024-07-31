### [覆盖所有点的最少矩形数目](https://leetcode.cn/problems/minimum-rectangles-to-cover-points/solutions/2857796/fu-gai-suo-you-dian-de-zui-shao-ju-x_ing-xduq9/)

#### 方法一：贪心

**思路与算法**

由于用来覆盖的矩形没有高度的限制，因此我们只考虑点的横坐标。由于题目要求矩形的宽度不超过 $w$，为了使得矩形覆盖更可能多的点，矩形的宽度越大越好，此时最好满足 $x_2=x_1+w$。假设当前所有点的最小横坐标是 $x_0$，必须有一个宽度为 $w$ 的矩形来覆盖该横坐标，为了使得矩形尽可能的覆盖多的点，此时矩形左边缘的横坐标为 $x_0$，矩形右边缘的横坐标为 $x_0+w$，此时该矩形可以覆盖所有横坐标处在区间 $[x_0,x_0+w]$ 的点，接着我们考虑剩余点中横坐标最小的点，继续按照上述贪心思路，直到覆盖所有的点。

实际计算过程如下：

- 将所有点的按照横坐标从小到大进行排序；
- 设当前的矩形的右边缘的横坐标为 $bound$，由于所有点的横坐标的取值范围为 $[0,10^9]$，此时为了计算方便，初始化时令 $bound=-1$；
- 按照横坐标从小到大遍历每个点，假设当前点的坐标为 $(x_i,y_i)$，此时如果 $x_i \le bound$，则表明当前的点可以被上一个矩形覆盖；如果 $x_i > bound$，则表明此时需要一个新的宽度为 $w$ 的矩形来覆盖，此时需要的矩形数目加一，同时把右边缘 $bound$ 更新为 $x_i+w$；
- 直到所有的点均被覆盖完成，此时返回矩形数目即可。

**代码**

```C++
class Solution {
public:
    int minRectanglesToCoverPoints(vector<vector<int>>& points, int w) {
        sort(points.begin(), points.end());
        int res = 0;
        int bound = -1;
        for (auto &p : points) {
            if (p[0] > bound) {
                bound = p[0] + w;
                res++;
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int minRectanglesToCoverPoints(int[][] points, int w) {
        Arrays.sort(points, (a, b) -> Integer.compare(a[0], b[0]));
        int res = 0;
        int bound = -1;
        for (int[] p : points) {
            if (p[0] > bound) {
                bound = p[0] + w;
                res++;
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int MinRectanglesToCoverPoints(int[][] points, int w) {
        Array.Sort(points, (a, b) => a[0] - b[0]);
        int res = 0;
        int bound = -1;
        foreach (int[] p in points) {
            if (p[0] > bound) {
                bound = p[0] + w;
                res++;
            }
        }
        return res;
    }
}
```

```Go
func minRectanglesToCoverPoints(points [][]int, w int) int {
    sort.Slice(points, func(i, j int) bool {
        return points[i][0] < points[j][0]
    })
    res := 0
    bound := -1
    for _, p := range points {
        if p[0] > bound {
            bound = p[0] + w
            res++
        }
    }
    return res
}
```

```Python
class Solution:
    def minRectanglesToCoverPoints(self, points: List[List[int]], w: int) -> int:
        points.sort()
        res = 0
        bound = -1
        for p in points:
            if p[0] > bound:
                bound = p[0] + w
                res += 1
        return res
```

```C
int compare(const void* a, const void* b) {
    return (*(int**)a)[0] - (*(int**)b)[0];
}

int minRectanglesToCoverPoints(int** points, int pointsSize, int* pointsColSize, int w) {
    qsort(points, pointsSize, sizeof(int*), compare);
    int res = 0;
    int bound = -1;
    for (int i = 0; i < pointsSize; i++) {
        if (points[i][0] > bound) {
            bound = points[i][0] + w;
            res++;
        }
    }
    return res;
}
```

```JavaScript
var minRectanglesToCoverPoints = function(points, w) {
    points.sort((a, b) => a[0] - b[0]);
    let res = 0;
    let bound = -1;
    for (let p of points) {
        if (p[0] > bound) {
            bound = p[0] + w;
            res++;
        }
    }
    return res;
};
```

```TypeScript
function minRectanglesToCoverPoints(points: number[][], w: number): number {
    points.sort((a, b) => a[0] - b[0]);
    let res = 0;
    let bound = -1;
    for (let p of points) {
        if (p[0] > bound) {
            bound = p[0] + w;
            res++;
        }
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn min_rectangles_to_cover_points(points: Vec<Vec<i32>>, w: i32) -> i32 {
        let mut points = points.clone();
        points.sort_by(|a, b| a[0].cmp(&b[0]));
        let mut res = 0;
        let mut bound = -1;
        for p in points {
            if p[0] > bound {
                bound = p[0] + w;
                res += 1;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nlogn)$，其中 $n$ 表示给定点的数目。需要对所有的点进行排序，需要的时间复杂度为 $O(nlogn)$。
- 空间复杂度：$O(logn)$，其中 $n$ 表示给定点的数目。其中排序需要的空间为 $O(logn)$。
