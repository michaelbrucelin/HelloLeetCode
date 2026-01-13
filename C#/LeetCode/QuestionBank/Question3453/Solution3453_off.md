### [分割正方形 I](https://leetcode.cn/problems/separate-squares-i/solutions/3875568/fen-ge-zheng-fang-x_ing-i-by-leetcode-sol-aq2x/)

#### 方法一：二分查找

**思路与算法**

设数组 $squares$ 的长度为 $n$，数组中的每个元素为 $(x_i,y_i,l_i)$，此时所有正方形的面积之和则为:

$$totalArea=\sum\limits_{i=0}^{n-1}l_i^2$$

根据题目要求，我们需要找到一个分割线 $y$，使得所有在 $y$ 以上的正方形的面积之和等于所有在 $y$ 以下的正方形的面积之和。设 $y$ 以下的正方形面积为 $area_y$，此时需要满足：

$$area_y\cdot 2=totalArea$$

随着分割线 $y$ 的增大，$area_y$ 单调不减，因此可以使用二分查找。具体地，我们可以二分查找找到最小的 $y$ 的值，使得在 $y$ 以下的正方形的面积满足：

$$area_y\cdot 2\ge totalArea$$

假设给定的 $y$ 的值，如果给定正方形 $(x_i,y_i,l_i)$，满足 $y_i<y$，那么这个正方形在 $y$ 以下，否则在 $y$ 以上。此时该正方形在 $y$ 以下的面积则为：

$$area=l_i\cdot min(y-y_i,l_i)$$

我们可以根据这个性质来计算在 $y$ 以下的所有正方形的面积之和：

$$area_y=\sum\limits_{i=0}^{n-1}l_i\cdot max(0,min(y-y_i,l_i))$$

由于计算面积时存在精度问题，题目要求与实际答案的误差在 $10^{-5}$ 以内。我们需要在二分查找时使用 $10^{-5}$ 作为精度，即可以使用上限与下限的差距不超过 $10^{-5}$ 作为二分查找的终止条件:

$$hi-lo\le 10^{-5}$$

我们通过二分查找找到最小的 $y$ 值即为答案。

**细节**

我们可以分析二分查找的次数上限，设初始二分区间长度为 $L$，每二分一次，二分区间长度减半。要至少减半到 $10^{-5}$ 才能满足题目的误差要求。设循环次数为 $k$，我们有：

$$\dfrac{L}{2^k}\le 10^{-5}$$

解得：

$$k\ge \log_2(L\cdot 10^5)$$

在本题的数据范围下，$0\le L\le 10^9$，此时 $k\ge \log_2(L\cdot 10^5)\ge \log_2(10^{14})=14\log_2(10)\approx 46.506993328423076$。二分查找的次数上限为 $47$ 次。

**代码**

```C++
class Solution {
public:
    double separateSquares(vector<vector<int>>& squares) {
        double max_y = 0, total_area = 0;
        for (auto& sq : squares) {
            int y = sq[1], l = sq[2];
            total_area += (double)l * l;
            max_y = max(max_y, (double)(y + l));
        }

        auto check = [&](double limit_y) -> bool {
            double area = 0;
            for (auto& sq : squares) {
                int y = sq[1], l = sq[2];
                if (y < limit_y) {
                    area += l * min(limit_y - y, (double)l);
                }
            }
            return area >= total_area / 2;
        };

        double lo = 0, hi = max_y;
        double eps = 1e-5;
        while (abs(hi - lo) > eps) {
            double mid = (hi + lo) / 2;
            if (check(mid)) {
                hi = mid;
            } else {
                lo = mid;
            }
        }
        return hi;
    }
};
```

```Java
class Solution {
    public double separateSquares(int[][] squares) {
        double max_y = 0, total_area = 0;
        for (int[] sq : squares) {
            int y = sq[1], l = sq[2];
            total_area += (double)l * l;
            max_y = Math.max(max_y, (double)(y + l));
        }

        double lo = 0, hi = max_y;
        double eps = 1e-5;
        while (Math.abs(hi - lo) > eps) {
            double mid = (hi + lo) / 2;
            if (check(mid, squares, total_area)) {
                hi = mid;
            } else {
                lo = mid;
            }
        }

        return hi;
    }

    private Boolean check(double limit_y, int[][] squares, double total_area) {
        double area = 0;
        for (int[] sq : squares) {
            int y = sq[1], l = sq[2];
            if (y < limit_y) {
                area += (double)l * Math.min(limit_y - y, (double)l);
            }
        }
        return area >= total_area / 2;
    }
}
```

```CSharp
public class Solution {
    public double SeparateSquares(int[][] squares) {
        double max_y = 0, total_area = 0;
        foreach (int[] sq in squares) {
            int y = sq[1], l = sq[2];
            total_area += (double)l * l;
            max_y = Math.Max(max_y, (double)(y + l));
        }

        double lo = 0, hi = max_y;
        double eps = 1e-5;
        while (Math.Abs(hi - lo) > eps) {
            double mid = (hi + lo) / 2;
            if (Check(mid, squares, total_area)) {
                hi = mid;
            } else {
                lo = mid;
            }
        }

        return hi;
    }

    private bool Check(double limit_y, int[][] squares, double total_area) {
        double area = 0;
        foreach (int[] sq in squares) {
            int y = sq[1], l = sq[2];
            if (y < limit_y) {
                area += (double)l * Math.Min(limit_y - y, (double)l);
            }
        }
        return area >= total_area / 2;
    }
}
```

```Go
func separateSquares(squares [][]int) float64 {
    max_y, total_area := 0.0, 0.0
    for _, sq := range squares {
        y, l := sq[1], sq[2]
        total_area += float64(l * l)
        if float64(y + l) > max_y {
            max_y = float64(y + l)
        }
    }

    check := func(limit_y float64) bool {
        area := 0.0
        for _, sq := range squares {
            y, l := sq[1], sq[2]
            if float64(y) < limit_y {
                overlap := math.Min(limit_y-float64(y), float64(l))
                area += float64(l) * overlap
            }
        }

        return area >= total_area / 2.0
    }

    lo, hi := 0.0, max_y
    eps := 1e-5
    for math.Abs(hi-lo) > eps {
        mid := (hi + lo) / 2.0
        if check(mid) {
            hi = mid
        } else {
            lo = mid
        }
    }
    return hi
}
```

```Python
class Solution:
    def separateSquares(self, squares: List[List[int]]) -> float:
        max_y, total_area = 0, 0
        for x, y, l in squares:
            total_area += l ** 2
            max_y = max(max_y, y + l)

        def check(limit_y):
            area = 0
            for x, y, l in squares:
                if y < limit_y:
                    area += l * min(limit_y - y, l)
            return area >= total_area / 2

        lo, hi = 0, max_y
        eps = 1e-5
        while abs(hi - lo) > eps:
            mid = (hi + lo) / 2
            if check(mid):
                hi = mid
            else:
                lo = mid

        return hi
```

```C
bool check(double limit_y, int** squares, int squaresSize, double total_area) {
    double area = 0.0;

    for (int i = 0; i < squaresSize; i++) {
        int y = squares[i][1];
        int l = squares[i][2];
        if (y < limit_y) {
            area += (double)l * fmin(l, limit_y - y);
        }
    }

    return area >= total_area / 2.0;
}

double separateSquares(int** squares, int squaresSize, int* squaresColSize) {
    double max_y = 0.0, total_area = 0.0;
    for (int i = 0; i < squaresSize; i++) {
        int y = squares[i][1];
        int l = squares[i][2];
        total_area += (double)l * l;
        if (y + l > max_y) {
            max_y = y + l;
        }
    }

    double lo = 0.0, hi = max_y;
    double eps = 1e-5;
    while (fabs(hi - lo) > eps) {
        double mid = (hi + lo) / 2.0;
        if (check(mid, squares, squaresSize, total_area)) {
            hi = mid;
        } else {
            lo = mid;
        }
    }
    return hi;
}
```

```JavaScript
var separateSquares = function(squares) {
    let max_y = 0, total_area = 0;
    for (const [x, y, l] of squares) {
        total_area += l * l;
        max_y = Math.max(max_y, y + l);
    }

    const check = (limit_y) => {
        let area = 0;
        for (const [x, y, l] of squares) {
            if (y < limit_y) {
                area += l * Math.min(limit_y - y, l);
            }
        }
        return area >= total_area / 2;
    };

    let lo = 0, hi = max_y;
    const eps = 1e-5;
    while (Math.abs(hi - lo) > eps) {
        const mid = (hi + lo) / 2;
        if (check(mid)) {
            hi = mid;
        } else {
            lo = mid;
        }
    }
    return hi;
};
```

```TypeScript
function separateSquares(squares: number[][]): number {
    let max_y = 0, total_area = 0;
    for (const [x, y, l] of squares) {
        total_area += l * l;
        max_y = Math.max(max_y, y + l);
    }

    const check = (limit_y: number): boolean => {
        let area = 0;
        for (const [x, y, l] of squares) {
            if (y < limit_y) {
                area += l * Math.min(limit_y - y, l);
            }
        }
        return area >= total_area / 2;
    };

    let lo = 0, hi = max_y;
    const eps = 1e-5;
    while (Math.abs(hi - lo) > eps) {
        const mid = (hi + lo) / 2;
        if (check(mid)) {
            hi = mid;
        } else {
            lo = mid;
        }
    }
    return hi;
}
```

```Rust
impl Solution {
    pub fn separate_squares(squares: Vec<Vec<i32>>) -> f64 {
        let mut max_y: f64 = 0.0;
        let mut total_area: f64 = 0.0;

        for sq in &squares {
            let l = sq[2] as f64;
            total_area += l * l;
            max_y = max_y.max((sq[1] + sq[2]) as f64);
        }

        let mut lo = 0.0;
        let mut hi = max_y;
        let eps = 1e-5;
        while (hi - lo).abs() > eps {
            let mid = (hi + lo) / 2.0;
            if Self::check(mid, &squares, total_area) {
                hi = mid;
            } else {
                lo = mid;
            }
        }

        hi
    }

    fn check(limit_y: f64, squares: &Vec<Vec<i32>>, total_area: f64) -> bool {
        let mut area = 0.0;

        for sq in squares {
            let y = sq[1] as f64;
            let l = sq[2] as f64;
            if y < limit_y {
                let overlap = (limit_y - y).min(l);
                area += l * overlap;
            }
        }

        area >= total_area / 2.0
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log (LU))$，其中 $n$ 是数组 $squares$ 的长度，设数组中的每个元素为 $(x_i,y_i,l_i)$，此时 $U=max(y_i+l_i)$，$L=10^5$。二分查找每次校验的时间复杂度度为 $O(n)$，二分查找的次数为 $O(\log (LU))$，因此总时间复杂度为 $O(n\log (LU))$。
- 空间复杂度：$O(1)$。

#### 方法二：扫描线

**思路与算法**

我们可以参考「[扫描线](https://leetcode.cn/l_ink/?target=https%3A%2F%2Foi-wiki.org%2Fgeometry%2Fscanning%2F)」的解法。首先可以计算出所有正方形的总面积 $totalArea$，接着我们从下往上进行扫描，设扫描线 $y=y^′$ 下方的覆盖的面积和为 $area$，那么扫描线上方的面积和为 $totalArea-area$。

题目要求 $y=y^′$ 下面的面积与上方的面积相等，即:

$$area=totalArea-area$$

即：

$$area=\dfrac{totalArea}{2}$$

设当前经过正方形上/下边界的扫描线为 $y=y^′$，此时扫面线以下的覆盖面积为 $area$；向上移动时下一个需要经过的正方形上/下边界的扫描线为 $y=y^{′′}$，此时被正方形覆盖的底边长之和为 $width$，则此时在扫面线 $y=y^{′′}$ 以下覆盖的面积之和为:

$$area+width\cdot (y^{′′}-y^′)$$

此时当满足：

$$area<\dfrac{totalArea}{2} \\ area+width\cdot (y^{′′}-y^′)\ge \dfrac{totalArea}{2}$$

时，则可以知道目标值 $y$ 一定处于区间 $[y^′,y^{′′}]$。 $ $
由于两个扫面线之间的被覆盖区域中所有的矩形的高度相同，扫面线在区间 $[y^′,y^{′′}]$ 移动长度为 $\Delta $ 时，此时被覆盖区域的面积变化即为 $\Delta \cdot width$，此时被覆盖的面积只需增加 $\dfrac{totalArea}{2}-area$，即可满足上下面积相等，此时我们可以直接求出目标值 $y$ 即为：

$$y=y^′+\dfrac{\dfrac{totalArea}{2}-area}{width}=y^′+\dfrac{totalArea-2\cdot area}{2\cdot width}$$

我们依次遍历每个正方形上/下边界的扫面线，找到目标值返回即可。

**代码**

```C++
class Solution {
public:
    double separateSquares(vector<vector<int>>& squares) {
        long long total_area = 0;
        vector<tuple<int, int, int>> events;
        for (const auto& sq : squares) {
            int y = sq[1], l = sq[2];
            total_area += (long long)l * l;
            events.emplace_back(y, l, 1);
            events.emplace_back(y + l, l, -1);
        }
        // 按照 y 坐标进行排序
        sort(events.begin(), events.end(), [](const auto& a, const auto& b) {
            return get<0>(a) < get<0>(b);
        });

        double covered_width = 0;  // 当前扫描线下所有底边之和
        double curr_area = 0;       // 当前累计面积
        double prev_height = 0;     // 前一个扫描线的高度
        for (const auto &[y, l, delta] : events) {
            int diff = y - prev_height;
            // 两条扫面线之间新增的面积
            double area = covered_width * diff;
            // 如果加上这部分面积超过总面积的一半
            if (2LL * (curr_area + area) >= total_area) {
                return prev_height + (total_area - 2.0 * curr_area) / (2.0 * covered_width);
            }
            // 更新宽度：开始事件加宽度，结束事件减宽度
            covered_width += delta * l;
            curr_area += area;
            prev_height = y;
        }

        return 0.0;
    }
};
```

```Java
class Solution {
    public double separateSquares(int[][] squares) {
        long totalArea = 0;
        List<int[]> events = new ArrayList<>();

        for (int[] sq : squares) {
            int y = sq[1], l = sq[2];
            totalArea += (long) l * l;
            events.add(new int[]{y, l, 1});
            events.add(new int[]{y + l, l, -1});
        }

        // 按y坐标排序
        events.sort((a, b) -> Integer.compare(a[0], b[0]));
        double coveredWidth = 0;  // 当前扫描线下所有底边之和
        double currArea = 0;      // 当前累计面积
        double prevHeight = 0;    // 前一个扫描线的高度

        for (int[] event : events) {
            int y = event[0];
            int l = event[1];
            int delta = event[2];

            int diff = y - (int) prevHeight;
            // 两条扫描线之间新增的面积
            double area = coveredWidth * diff;
            // 如果加上这部分面积超过总面积的一半
            if (2L * (currArea + area) >= totalArea) {
                return prevHeight + (totalArea - 2.0 * currArea) / (2.0 * coveredWidth);
            }
            // 更新宽度：开始事件加宽度，结束事件减宽度
            coveredWidth += delta * l;
            currArea += area;
            prevHeight = y;
        }

        return 0.0;
    }
}
```

```CSharp
public class Solution {
    public double SeparateSquares(int[][] squares) {
        long totalArea = 0;
        List<int[]> events = new List<int[]>();

        foreach (var sq in squares) {
            int y = sq[1], l = sq[2];
            totalArea += (long)l * l;
            events.Add(new int[] { y, l, 1 });
            events.Add(new int[] { y + l, l, -1 });
        }

        // 按y坐标排序
        events.Sort((a, b) => a[0].CompareTo(b[0]));

        double coveredWidth = 0;  // 当前扫描线下所有底边之和
        double currArea = 0;      // 当前累计面积
        double prevHeight = 0;    // 前一个扫描线的高度

        foreach (var eventItem in events) {
            int y = eventItem[0];
            int l = eventItem[1];
            int delta = eventItem[2];

            int diff = y - (int)prevHeight;
            // 两条扫描线之间新增的面积
            double area = coveredWidth * diff;
            // 如果加上这部分面积超过总面积的一半
            if (2L * (currArea + area) >= totalArea) {
                return prevHeight + (totalArea - 2.0 * currArea) / (2.0 * coveredWidth);
            }
            // 更新宽度：开始事件加宽度，结束事件减宽度
            coveredWidth += delta * l;
            currArea += area;
            prevHeight = y;
        }

        return 0.0;
    }
}
```

```Go
func separateSquares(squares [][]int) float64 {
    var totalArea int64 = 0
    type Event struct {
        y     int
        l     int
        delta int
    }
    events := make([]Event, 0, len(squares)*2)

    for _, sq := range squares {
        y, l := sq[1], sq[2]
        totalArea += int64(l) * int64(l)
        events = append(events, Event{y, l, 1})
        events = append(events, Event{y + l, l, -1})
    }

    // 按y坐标排序
    sort.Slice(events, func(i, j int) bool {
        return events[i].y < events[j].y
    })

    coveredWidth := 0.0  // 当前扫描线下所有底边之和
    currArea := 0.0      // 当前累计面积
    prevHeight := 0.0    // 前一个扫描线的高度

    for _, event := range events {
        y, l, delta := event.y, event.l, event.delta
        diff := float64(y) - prevHeight
        // 两条扫描线之间新增的面积
        area := coveredWidth * diff
        // 如果加上这部分面积超过总面积的一半
        if 2.0*(currArea+area) >= float64(totalArea) {
            return prevHeight + (float64(totalArea) - 2.0*currArea) / (2.0 * coveredWidth)
        }
        // 更新宽度：开始事件加宽度，结束事件减宽度
        coveredWidth += float64(delta * l)
        currArea += area
        prevHeight = float64(y)
    }

    return 0.0
}
```

```Python
class Solution:
    def separateSquares(self, squares: List[List[int]]) -> float:
        total_area = 0
        events = []

        for sq in squares:
            y, l = sq[1], sq[2]
            total_area += l * l
            events.append((y, l, 1))
            events.append((y + l, l, -1))

        # 按y坐标排序
        events.sort(key=lambda x: x[0])

        covered_width = 0.0  # 当前扫描线下所有底边之和
        curr_area = 0.0      # 当前累计面积
        prev_height = 0.0    # 前一个扫描线的高度

        for y, l, delta in events:
            diff = y - prev_height
            # 两条扫描线之间新增的面积
            area = covered_width * diff
            # 如果加上这部分面积超过总面积的一半
            if 2 * (curr_area + area) >= total_area:
                return prev_height + (total_area - 2 * curr_area) / (2 * covered_width)
            # 更新宽度：开始事件加宽度，结束事件减宽度
            covered_width += delta * l
            curr_area += area
            prev_height = y

        return 0.0
```

```C
typedef struct {
    int y;
    int l;
    int delta;
} Event;

int compareEvents(const void* a, const void* b) {
    Event* e1 = (Event*)a;
    Event* e2 = (Event*)b;
    return e1->y - e2->y;
}

double separateSquares(int** squares, int squaresSize, int* squaresColSize) {
    long long totalArea = 0;
    Event* events = malloc(2 * squaresSize * sizeof(Event));
    int eventCount = 0;

    for (int i = 0; i < squaresSize; i++) {
        int y = squares[i][1];
        int l = squares[i][2];
        totalArea += (long long)l * l;
        events[eventCount++] = (Event){y, l, 1};
        events[eventCount++] = (Event){y + l, l, -1};
    }

    // 按y坐标排序
    qsort(events, eventCount, sizeof(Event), compareEvents);

    double coveredWidth = 0.0;  // 当前扫描线下所有底边之和
    double currArea = 0.0;      // 当前累计面积
    double prevHeight = 0.0;    // 前一个扫描线的高度

    for (int i = 0; i < eventCount; i++) {
        int y = events[i].y;
        int l = events[i].l;
        int delta = events[i].delta;

        int diff = y - (int)prevHeight;
        // 两条扫描线之间新增的面积
        double area = coveredWidth * diff;
        // 如果加上这部分面积超过总面积的一半
        if (2LL * (currArea + area) >= totalArea) {
            double result = prevHeight + (totalArea - 2.0 * currArea) / (2.0 * coveredWidth);
            free(events);
            return result;
        }
        // 更新宽度：开始事件加宽度，结束事件减宽度
        coveredWidth += delta * l;
        currArea += area;
        prevHeight = y;
    }

    free(events);
    return 0.0;
}
```

```JavaScript
var separateSquares = function(squares) {
    let totalArea = 0n;
    const events = [];

    for (const sq of squares) {
        const y = sq[1], l = sq[2];
        totalArea += BigInt(l) * BigInt(l);
        events.push([y, l, 1]);
        events.push([y + l, l, -1]);
    }

    // 按y坐标排序
    events.sort((a, b) => a[0] - b[0]);

    let coveredWidth = 0;  // 当前扫描线下所有底边之和
    let currArea = 0;      // 当前累计面积
    let prevHeight = 0;    // 前一个扫描线的高度

    for (const [y, l, delta] of events) {
        const diff = y - prevHeight;
        // 两条扫描线之间新增的面积
        const area = coveredWidth * diff;
        // 如果加上这部分面积超过总面积的一半
        if (2n * BigInt(Math.ceil(currArea + area)) >= totalArea) {
            return prevHeight + (Number(totalArea) - 2.0 * currArea) / (2.0 * coveredWidth);
        }
        // 更新宽度：开始事件加宽度，结束事件减宽度
        coveredWidth += delta * l;
        currArea += area;
        prevHeight = y;
    }

    return 0.0;
};
```

```TypeScript
function separateSquares(squares: number[][]): number {
    let totalArea: bigint = 0n;
    const events: [number, number, number][] = [];

    for (const sq of squares) {
        const y = sq[1], l = sq[2];
        totalArea += BigInt(l) * BigInt(l);
        events.push([y, l, 1]);
        events.push([y + l, l, -1]);
    }

    // 按y坐标排序
    events.sort((a, b) => a[0] - b[0]);

    let coveredWidth: number = 0;  // 当前扫描线下所有底边之和
    let currArea: number = 0;      // 当前累计面积
    let prevHeight: number = 0;    // 前一个扫描线的高度

    for (const [y, l, delta] of events) {
        const diff: number = y - prevHeight;
        // 两条扫描线之间新增的面积
        const area: number = coveredWidth * diff;
        // 如果加上这部分面积超过总面积的一半
        if (2n * BigInt(Math.ceil(currArea + area)) >= totalArea) {
            return prevHeight + (Number(totalArea) - 2.0 * currArea) / (2.0 * coveredWidth);
        }
        // 更新宽度：开始事件加宽度，结束事件减宽度
        coveredWidth += delta * l;
        currArea += area;
        prevHeight = y;
    }

    return 0.0;
}
```

```Rust
impl Solution {
    pub fn separate_squares(squares: Vec<Vec<i32>>) -> f64 {
        let mut total_area: i64 = 0;
        let mut events: Vec<(i32, i32, i32)> = Vec::new();

        for sq in &squares {
            let y = sq[1];
            let l = sq[2];
            total_area += l as i64 * l as i64;
            events.push((y, l, 1));
            events.push((y + l, l, -1));
        }

        // 按y坐标排序
        events.sort_by_key(|&(y, _, _)| y);

        let mut covered_width: f64 = 0.0;  // 当前扫描线下所有底边之和
        let mut curr_area: f64 = 0.0;      // 当前累计面积
        let mut prev_height: f64 = 0.0;    // 前一个扫描线的高度

        for (y, l, delta) in events {
            let diff = y as f64 - prev_height;
            // 两条扫描线之间新增的面积
            let area = covered_width * diff;
            // 如果加上这部分面积超过总面积的一半
            if 2.0 * (curr_area + area) >= total_area as f64 {
                return prev_height + (total_area as f64 - 2.0 * curr_area) / (2.0 * covered_width);
            }
            // 更新宽度：开始事件加宽度，结束事件减宽度
            covered_width += (delta * l) as f64;
            curr_area += area;
            prev_height = y as f64;
        }

        0.0
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 是数组 $squares$ 的长度。排序需要的时间复杂度为 $O(n\log n)$。
- 空间复杂度：$O(n)$，其中 $n$ 是数组 $squares$ 的长度。存储扫面线高度，需要的空间为 $O(n)$。
