### [人员站位的方案数 II](https://leetcode.cn/problems/find-the-number-of-ways-to-place-people-ii/solutions/3764851/ren-yuan-zhan-wei-de-fang-an-shu-ii-by-l-5ors/)

前置题目：[「3195. 包含所有 1 的最小矩形面积 I」](https://leetcode.cn/problems/find-the-minimum-area-to-cover-all-ones-i/)，请先确保理解了前置题目的思路和做法。该题是前置题目的数据增强版本。

#### 方法一：排序 + 二重循环枚举

**思路与算法**

简单的三重循环遍历在本题的数据范围下会超时。在朴素的做法中，第三重循环进行了范围判断，那么考虑到此类问题的性质，假如坐标具有一定有序性，是否可以消除这一重额外循环？

让我们首先对 $points$ 进行**横坐标从小到大**的排序，此时进行 $0<i<j<n$ 的有序遍历来选取点对 $A_i=points[i],B_j=points[j]$，其中 $n$ 是 $points$ 的长度。

假设 $A_i$ 就是左上角的点，而 $B_j$ 一定要在 $A_i$ 的右下方，可以列出 $B_j$ 需要满足的初始边界条件：

$$xB_j\in [xA_i,+\infty ),yB_j\in (-\infty ,yA_i]$$

不难发现，由于 $points$ 的横坐标已经从小到大排序，因此 $xB_j$ 的初始约束条件已经天然满足。

同时，在遍历 $B_j$ 的过程中，$xB_j$ 将保证是非递减的，这意味着：设在遍历过程中，上一个满足条件的点对是 $(A_i,B_1)$，下一个满足条件的点对是 $(A_i,B_2)$，有：

$$xB_2\ge xB_1,yB_2\ge yB_1,B_1\ne B_2$$

以上结论非常重要。它表明了每当选取了一个合法的 $B_j$，上面约束中的下边界和左边界会不断地**单调收缩**。即：对于同一个 $A_i$，对应的一组合法 $B_j$ 将会从 $A_i$ 的下方向右上方单调延伸。故可以在选取合法点对的同时维护边界的更新。

易得对于每一个特定的 $xB_j$，只能取到约束范围内**纵坐标最高的那个点**。故在将横坐标作为第一关键字从小到大排序后，若将纵坐标作为第二关键字**从大到小**排序，可以保证在满足边界约束的情况下，第一个遍历到的 $B_j$ 是 $xB_j$ 上 $y$ 最高的一个。此时更新左下边界约束，就可以直接寻找下一个合法的 $B_j$，重复这个过程即可在 $O(n^2)$ 的时间内计算答案。

**代码**

```C++
class Solution {
public:
    int numberOfPairs(vector<vector<int>>& points) {
        int ans = 0;
        sort(points.begin(), points.end(), [](const vector<int>& a, const vector<int>& b) {
            return a[0] < b[0] || (a[0] == b[0] && a[1] > b[1]);
        });

        for (int i = 0; i < points.size() - 1; i++) {
            const auto& pointA = points[i];
            int xMin = pointA[0] - 1;
            int xMax = INT_MAX;
            int yMin = INT_MIN;
            int yMax = pointA[1] + 1;

            for (int j = i + 1; j < points.size(); j++) {
                const auto& pointB = points[j];
                if (pointB[0] > xMin && pointB[0] < xMax &&
                    pointB[1] > yMin && pointB[1] < yMax) {
                    ans++;
                    xMin = pointB[0];
                    yMin = pointB[1];
                }
            }
        }
        return ans;
    }
};
```

```Java
public class Solution {
    public int numberOfPairs(int[][] points) {
        int ans = 0;
        Arrays.sort(points, (a, b) -> a[0] != b[0] ? a[0] - b[0] : b[1] - a[1]);
        for (int i = 0; i < points.length - 1; i++) {
            int[] pointA = points[i];
            int xMin = pointA[0] - 1;
            int xMax = Integer.MAX_VALUE;
            int yMin = Integer.MIN_VALUE;
            int yMax = pointA[1] + 1;

            for (int j = i + 1; j < points.length; j++) {
                int[] pointB = points[j];
                if (pointB[0] > xMin && pointB[0] < xMax &&
                    pointB[1] > yMin && pointB[1] < yMax) {
                    ans++;
                    xMin = pointB[0];
                    yMin = pointB[1];
                }
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int NumberOfPairs(int[][] points) {
        int ans = 0;
        Array.Sort(points, (a, b) => a[0] != b[0] ? a[0].CompareTo(b[0]) : b[1].CompareTo(a[1]));
        for (int i = 0; i < points.Length - 1; i++) {
            int[] pointA = points[i];
            int xMin = pointA[0] - 1;
            int xMax = int.MaxValue;
            int yMin = int.MinValue;
            int yMax = pointA[1] + 1;

            for (int j = i + 1; j < points.Length; j++) {
                int[] pointB = points[j];
                if (pointB[0] > xMin && pointB[0] < xMax &&
                    pointB[1] > yMin && pointB[1] < yMax) {
                    ans++;
                    xMin = pointB[0];
                    yMin = pointB[1];
                }
            }
        }
        return ans;
    }
}
```

```Go
func numberOfPairs(points [][]int) int {
    ans := 0
    sort.Slice(points, func(i, j int) bool {
        if points[i][0] == points[j][0] {
            return points[i][1] > points[j][1]
        }
        return points[i][0] < points[j][0]
    })

    for i := 0; i < len(points)-1; i++ {
        pointA := points[i]
        xMin := pointA[0] - 1
        xMax := math.MaxInt32
        yMin := math.MinInt32
        yMax := pointA[1] + 1

        for j := i + 1; j < len(points); j++ {
            pointB := points[j]
            if pointB[0] > xMin && pointB[0] < xMax &&
                pointB[1] > yMin && pointB[1] < yMax {
                ans++
                xMin = pointB[0]
                yMin = pointB[1]
            }
        }
    }
    return ans
}
```

```Python
class Solution:
    def numberOfPairs(self, points: List[List[int]]) -> int:
        ans = 0
        points.sort(key=lambda x: (x[0], -x[1]))

        for i in range(len(points) - 1):
            pointA = points[i]
            xMin = pointA[0] - 1
            xMax = math.inf
            yMin = -math.inf
            yMax = pointA[1] + 1

            for j in range(i + 1, len(points)):
                pointB = points[j]
                if (pointB[0] > xMin and pointB[0] < xMax and
                    pointB[1] > yMin and pointB[1] < yMax):
                    ans += 1
                    xMin = pointB[0]
                    yMin = pointB[1]

        return ans
```

```C
int compare(const void* a, const void* b) {
    int* pa = *(int**)a;
    int* pb = *(int**)b;
    if (pa[0] != pb[0]) return pa[0] - pb[0];
    return pb[1] - pa[1];
}

int numberOfPairs(int** points, int pointsSize, int* pointsColSize) {
    int ans = 0;
    qsort(points, pointsSize, sizeof(int*), compare);

    for (int i = 0; i < pointsSize - 1; i++) {
        int* pointA = points[i];
        int xMin = pointA[0] - 1;
        int xMax = INT_MAX;
        int yMin = INT_MIN;
        int yMax = pointA[1] + 1;

        for (int j = i + 1; j < pointsSize; j++) {
            int* pointB = points[j];
            if (pointB[0] > xMin && pointB[0] < xMax &&
                pointB[1] > yMin && pointB[1] < yMax) {
                ans++;
                xMin = pointB[0];
                yMin = pointB[1];
            }
        }
    }
    return ans;
}
```

```JavaScript
var numberOfPairs = function (points) {
    let ans = 0;

    points.sort((a, b) => (a[0] - b[0] || b[1] - a[1]));

    for (let i = 0; i < points.length - 1; i++) {
        const pointA = points[i];
        const xRange = [pointA[0] - 1, Infinity];
        const yRange = [-Infinity, pointA[1] + 1];

        for (let j = i + 1; j < points.length; j++) {
            const pointB = points[j];

            if (
                pointB[0] > xRange[0] &&
                pointB[0] < xRange[1] &&
                pointB[1] > yRange[0] &&
                pointB[1] < yRange[1]
            ) {
                ans++;
                xRange[0] = pointB[0];
                yRange[0] = pointB[1];
            }
        }
    }

    return ans;
};
```

```TypeScript
function numberOfPairs(points: number[][]): number {
    let ans = 0;

    points.sort((a, b) => (a[0] - b[0] || b[1] - a[1]));

    for (let i = 0; i < points.length - 1; i++) {
        const pointA = points[i];
        const xRange = [pointA[0] - 1, Infinity];
        const yRange = [-Infinity, pointA[1] + 1];

        for (let j = i + 1; j < points.length; j++) {
            const pointB = points[j];

            if (
                pointB[0] > xRange[0] &&
                pointB[0] < xRange[1] &&
                pointB[1] > yRange[0] &&
                pointB[1] < yRange[1]
            ) {
                ans++;
                xRange[0] = pointB[0];
                yRange[0] = pointB[1];
            }
        }
    }

    return ans;
}
```

```Rust
impl Solution {
    pub fn number_of_pairs(mut points: Vec<Vec<i32>>) -> i32 {
        let mut ans = 0;
        points.sort_by(|a, b| a[0].cmp(&b[0]).then(b[1].cmp(&a[1])));

        for i in 0..points.len() - 1 {
            let point_a = &points[i];
            let mut x_min = point_a[0] - 1;
            let x_max = i32::MAX;
            let mut y_min = i32::MIN;
            let y_max = point_a[1] + 1;

            for j in i + 1..points.len() {
                let point_b = &points[j];

                if point_b[0] > x_min && point_b[0] < x_max &&
                   point_b[1] > y_min && point_b[1] < y_max {
                    ans += 1;
                    x_min = point_b[0];
                    y_min = point_b[1];
                }
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是 $points$ 的长度。排序需 $O(nlogn)$，双重循环遍历需 $O(n^2)$，故总时间复杂度是 $O(n^2)$。
- 空间复杂度：$O(n)$ 若排序需要额外空间，或者 $O(1)$ 若排序过程是就地的。

#### 方法二：二维前缀和 + 离散化

**前置知识**

二维前缀和，该方法假设读者已经了解二维前缀和的思想和原理。

**思路与算法**

仍然考虑在朴素做法的基础上快速判断目标矩形上是否有其他点。

不难想到，这个问题可以使用二维前缀和快速求解。设某个坐标上存在点记为 $1$，没有点记为 $0$，对整个数据范围做二维前缀和，即可快速判断目标矩形内点的数量。若数量是 $2$，易得构成目标矩形的点对（在满足两点不处于主对角线的情况下）是满足题意的。

然而由于坐标的范围是 $[-1e9,1e9]$，无法在这么大的区域上做前缀和，考虑到 $n$ 的规模很小，可以使用离散化解决。离散化的本质思想是**坐标的重映射**，将原来稀疏的整数坐标映射到一个稠密二维数组中，但是又保持每个点的相对位置信息不变，从而支持在这个稠密数组中进行二维前缀和的处理。

**离散化的实现**

实现离散化，首先需要获得所有原坐标系中点的横纵坐标有序集合，然后创建每个坐标在离散化后的二维数组中的坐标映射。让我们以 $[[3,1],[1,3],[1,1]]$ 这一样例为例：

1. 获得原坐标系中所有点的横纵坐标集合：横坐标集合是 ${1,3}$，纵坐标集合是 ${1,3}$。
2. 创建坐标的映射集，横坐标的映射集是 $\{1\mapsto 1,3\mapsto 2\}$，纵坐标同理。
3. 根据坐标的映射集，创建 $points$ 中的坐标到新的稠密二维数组的映射，并将稠密二维数组中的对应位置标为 $1$。该映射为 $\{(3,1)\mapsto (1,2),(3,1)\mapsto (2,1),(1,1)\mapsto (1,1)\}$。重映射的起点从 $1$ 开始是为了方便二维前缀和的边界处理。

最后，在遍历点对前，可选地可以如方法一一样，对 $points$ 进行排序，有序地遍历点对，可以降低一点常数。

**代码**

```C++
struct PairHash {
    size_t operator()(const pair<int, int>& p) const {
        return hash<int>()(p.first) ^ (hash<int>()(p.second) << 1);
    }
};

struct PairEqual {
    bool operator()(const pair<int, int>& lhs, const pair<int, int>& rhs) const {
        return lhs.first == rhs.first && lhs.second == rhs.second;
    }
};

class Solution {
public:
    int numberOfPairs(vector<vector<int>>& points) {
        unordered_map<int, int> col;
        unordered_map<int, int> row;
        unordered_map<pair<int, int>, pair<int, int>, PairHash, PairEqual> coordinatesMap;
        
        for (const auto& point : points) {
            int x = point[0];
            int y = point[1];
            col[x] = 0;
            row[y] = 0;
        }
        
        vector<int> colKeys;
        for (const auto& pair : col) {
            colKeys.push_back(pair.first);
        }
        sort(colKeys.begin(), colKeys.end());
        for (int i = 0; i < colKeys.size(); i++) {
            col[colKeys[i]] = i + 1;
        }
        
        vector<int> rowKeys;
        for (const auto& pair : row) {
            rowKeys.push_back(pair.first);
        }
        sort(rowKeys.begin(), rowKeys.end());
        for (int i = 0; i < rowKeys.size(); i++) {
            row[rowKeys[i]] = i + 1;
        }
        
        int nc = col.size() + 1;
        int nr = row.size() + 1;
        vector<vector<int>> m(nc, vector<int>(nr, 0));
        vector<vector<int>> prefixSum(nc, vector<int>(nr, 0));
        
        for (const auto& point : points) {
            int x = point[0];
            int y = point[1];
            int c = col[x];
            int r = row[y];
            pair<int, int> key = make_pair(x, y);
            coordinatesMap[key] = make_pair(c, r);
            m[c][r] = 1;
        }
        
        for (int i = 1; i < nc; i++) {
            for (int j = 1; j < nr; j++) {
                prefixSum[i][j] = prefixSum[i - 1][j] + prefixSum[i][j - 1] 
                                - prefixSum[i - 1][j - 1] + m[i][j];
            }
        }
        
        int ans = 0;
        sort(points.begin(), points.end(), [](const vector<int>& a, const vector<int>& b) {
            if (a[0] == b[0]) {
                return a[1] > b[1];
            }
            return a[0] < b[0];
        });
        
        int n = points.size();
        for (int i = 0; i < n - 1; i++) {
            for (int j = i + 1; j < n; j++) {
                if (points[i][1] >= points[j][1]) {
                    pair<int, int> key1 = make_pair(points[i][0], points[i][1]);
                    pair<int, int> key2 = make_pair(points[j][0], points[j][1]);
                    pair<int, int> coord1 = coordinatesMap[key1];
                    pair<int, int> coord2 = coordinatesMap[key2];
                    int c1 = coord1.first, r1 = coord1.second;
                    int c2 = coord2.first, r2 = coord2.second;
                    int cnt = prefixSum[c2][r1] - prefixSum[c1 - 1][r1] 
                            - prefixSum[c2][r2 - 1] + prefixSum[c1 - 1][r2 - 1];
                    if (cnt == 2) {
                        ans++;
                    }
                }
            }
        }
        
        return ans;
    }
};
```

```Java
class Solution {
    static class Point {
        int x;
        int y;
        
        Point(int x, int y) {
            this.x = x;
            this.y = y;
        }
        
        @Override
        public boolean equals(Object o) {
            if (this == o) {
                return true;
            }
            if (o == null || getClass() != o.getClass()) {
                return false;
            }
            Point point = (Point) o;
            return x == point.x && y == point.y;
        }
        
        @Override
        public int hashCode() {
            return Objects.hash(x, y);
        }
    }
    
    public int numberOfPairs(int[][] points) {
        Map<Integer, Integer> col = new HashMap<>();
        Map<Integer, Integer> row = new HashMap<>();
        Map<Point, int[]> coordinatesMap = new HashMap<>();
        
        for (int[] point : points) {
            int x = point[0], y = point[1];
            col.put(x, 0);
            row.put(y, 0);
        }
        List<Integer> colKeys = new ArrayList<>(col.keySet());
        Collections.sort(colKeys);
        for (int i = 0; i < colKeys.size(); i++) {
            col.put(colKeys.get(i), i + 1);
        }
        List<Integer> rowKeys = new ArrayList<>(row.keySet());
        Collections.sort(rowKeys);
        for (int i = 0; i < rowKeys.size(); i++) {
            row.put(rowKeys.get(i), i + 1);
        }
        
        int nc = col.size() + 1;
        int nr = row.size() + 1;
        int[][] m = new int[nc][nr];
        int[][] prefixSum = new int[nc][nr];
        
        for (int[] point : points) {
            int x = point[0], y = point[1];
            int c = col.get(x), r = row.get(y);
            Point key = new Point(x, y);
            coordinatesMap.put(key, new int[]{c, r});
            m[c][r] = 1;
        }
        for (int i = 1; i < nc; i++) {
            for (int j = 1; j < nr; j++) {
                prefixSum[i][j] = prefixSum[i - 1][j] + prefixSum[i][j - 1] 
                                - prefixSum[i - 1][j - 1] + m[i][j];
            }
        }
        
        int ans = 0;
        Arrays.sort(points, (a, b) -> {
            if (a[0] == b[0]) {
                return Integer.compare(b[1], a[1]);
            }
            return Integer.compare(a[0], b[0]);
        });
        
        int n = points.length;
        for (int i = 0; i < n - 1; i++) {
            for (int j = i + 1; j < n; j++) {
                if (points[i][1] >= points[j][1]) {
                    Point key1 = new Point(points[i][0], points[i][1]);
                    Point key2 = new Point(points[j][0], points[j][1]);
                    int[] coord1 = coordinatesMap.get(key1);
                    int[] coord2 = coordinatesMap.get(key2);
                    int c1 = coord1[0], r1 = coord1[1];
                    int c2 = coord2[0], r2 = coord2[1];
                    int cnt = prefixSum[c2][r1] - prefixSum[c1 - 1][r1] 
                            - prefixSum[c2][r2 - 1] + prefixSum[c1 - 1][r2 - 1];
                    if (cnt == 2) {
                        ans++;
                    }
                }
            }
        }
        
        return ans;
    }
}
```

```CSharp
public class Point : IEquatable<Point> {
    public int X { get; }
    public int Y { get; }
    
    public Point(int x, int y) {
        X = x;
        Y = y;
    }
    
    public override bool Equals(object obj) {
        return obj is Point other && Equals(other);
    }
    
    public bool Equals(Point other) {
        return X == other.X && Y == other.Y;
    }
    
    public override int GetHashCode() {
        return HashCode.Combine(X, Y);
    }
}

public class Solution {
    public int NumberOfPairs(int[][] points) {
        Dictionary<int, int> col = new Dictionary<int, int>();
        Dictionary<int, int> row = new Dictionary<int, int>();
        Dictionary<Point, Tuple<int, int>> coordinatesMap = new Dictionary<Point, Tuple<int, int>>();
        
        foreach (var point in points) {
            int x = point[0], y = point[1];
            if (!col.ContainsKey(x)) {
                col[x] = 0;
            }
            if (!row.ContainsKey(y)) {
                row[y] = 0;
            }
        }
        
        var colKeys = col.Keys.ToList();
        colKeys.Sort();
        for (int i = 0; i < colKeys.Count; i++) {
            col[colKeys[i]] = i + 1;
        }
        var rowKeys = row.Keys.ToList();
        rowKeys.Sort();
        for (int i = 0; i < rowKeys.Count; i++) {
            row[rowKeys[i]] = i + 1;
        }
        
        int nc = col.Count + 1;
        int nr = row.Count + 1;
        int[,] m = new int[nc, nr];
        int[,] prefixSum = new int[nc, nr];
        
        foreach (var point in points) {
            int x = point[0], y = point[1];
            int c = col[x], r = row[y];
            var key = new Point(x, y);
            coordinatesMap[key] = Tuple.Create(c, r);
            m[c, r] = 1;
        }
        
        for (int i = 1; i < nc; i++) {
            for (int j = 1; j < nr; j++) {
                prefixSum[i, j] = prefixSum[i - 1, j] + prefixSum[i, j - 1] - 
                                 prefixSum[i - 1, j - 1] + m[i, j];
            }
        }
        
        int ans = 0;
        var sortedPoints = points.OrderBy(p => p[0])
                                .ThenByDescending(p => p[1])
                                .ToArray();
        
        int n = sortedPoints.Length;
        for (int i = 0; i < n - 1; i++) {
            for (int j = i + 1; j < n; j++) {
                if (sortedPoints[i][1] >= sortedPoints[j][1]) {
                    var key1 = new Point(sortedPoints[i][0], sortedPoints[i][1]);
                    var key2 = new Point(sortedPoints[j][0], sortedPoints[j][1]);
                    var coord1 = coordinatesMap[key1];
                    var coord2 = coordinatesMap[key2];
                    int c1 = coord1.Item1, r1 = coord1.Item2;
                    int c2 = coord2.Item1, r2 = coord2.Item2;
                    
                    int cnt = prefixSum[c2, r1] - prefixSum[c1 - 1, r1] - 
                              prefixSum[c2, r2 - 1] + prefixSum[c1 - 1, r2 - 1];
                    
                    if (cnt == 2) {
                        ans++;
                    }
                }
            }
        }
        
        return ans;
    }
}
```

```Go
func numberOfPairs(points [][]int) int {
    col := make(map[int]int)
    row := make(map[int]int)
    coordinatesMap := make(map[[2]int][2]int)
    
    for _, point := range points {
        x, y := point[0], point[1]
        col[x] = 0
        row[y] = 0
    }
    
    colKeys := make([]int, 0, len(col))
    for k := range col {
        colKeys = append(colKeys, k)
    }
    sort.Ints(colKeys)
    for i, key := range colKeys {
        col[key] = i + 1
    }
    rowKeys := make([]int, 0, len(row))
    for k := range row {
        rowKeys = append(rowKeys, k)
    }
    sort.Ints(rowKeys)
    for i, key := range rowKeys {
        row[key] = i + 1
    }
    
    nc := len(col) + 1
    nr := len(row) + 1
    
    m := make([][]int, nc)
    prefixSum := make([][]int, nc)
    for i := range m {
        m[i] = make([]int, nr)
        prefixSum[i] = make([]int, nr)
    }
    
    for _, point := range points {
        x, y := point[0], point[1]
        c, r := col[x], row[y]
        key := [2]int{x, y}
        coordinatesMap[key] = [2]int{c, r}
        m[c][r] = 1
    }
    
    for i := 1; i < nc; i++ {
        for j := 1; j < nr; j++ {
            prefixSum[i][j] = prefixSum[i-1][j] + prefixSum[i][j-1] - 
                             prefixSum[i-1][j-1] + m[i][j]
        }
    }
    
    ans := 0
    sort.Slice(points, func(i, j int) bool {
        if points[i][0] == points[j][0] {
            return points[i][1] > points[j][1]
        }
        return points[i][0] < points[j][0]
    })
    
    n := len(points)
    for i := 0; i < n-1; i++ {
        for j := i + 1; j < n; j++ {
            if points[i][1] >= points[j][1] {
                key1 := [2]int{points[i][0], points[i][1]}
                key2 := [2]int{points[j][0], points[j][1]}
                coord1 := coordinatesMap[key1]
                coord2 := coordinatesMap[key2]
                c1, r1 := coord1[0], coord1[1]
                c2, r2 := coord2[0], coord2[1]
                
                cnt := prefixSum[c2][r1] - prefixSum[c1 - 1][r1] - 
                       prefixSum[c2][r2 - 1] + prefixSum[c1 - 1][r2 - 1]
                       
                if cnt == 2 {
                    ans++
                }
            }
        }
    }
    
    return ans
}
```

```Python
class Solution:
    def numberOfPairs(self, points: List[List[int]]) -> int:
        col = {}
        row = {}
        coordinates_map = {}

        for point in points:
            x, y = point
            col[x] = 0
            row[y] = 0

        def map_keys_to_order(m):
            sorted_keys = sorted(m.keys())
            for idx, key in enumerate(sorted_keys):
                m[key] = idx + 1

        map_keys_to_order(col)
        map_keys_to_order(row)
        nc = len(col) + 1
        nr = len(row) + 1
        m = [[0] * nr for _ in range(nc)]
        prefix_sum = [[0] * nr for _ in range(nc)]

        for point in points:
            x, y = point
            c = col[x]
            r = row[y]
            coordinates_map[tuple(point)] = (c, r)
            m[c][r] = 1

        for i in range(1, nc):
            for j in range(1, nr):
                prefix_sum[i][j] = (prefix_sum[i - 1][j] + prefix_sum[i][j - 1]
                                  - prefix_sum[i - 1][j - 1] + m[i][j])

        ans = 0
        points.sort(key=lambda p: (p[0], -p[1]))
        n = len(points)
        for i in range(n - 1):
            for j in range(i + 1, n):
                if points[i][1] >= points[j][1]:
                    c1, r1 = coordinates_map[tuple(points[i])]
                    c2, r2 = coordinates_map[tuple(points[j])]
                    cnt = (prefix_sum[c2][r1] - prefix_sum[c1 - 1][r1]
                          - prefix_sum[c2][r2 - 1] + prefix_sum[c1 - 1][r2 - 1])

                    if cnt == 2:
                        ans += 1

        return ans
```

```JavaScript
var numberOfPairs = function (points) {
    const col = new Map();
    const row = new Map();
    const coordinatesMap = new Map();

    for (const [x, y] of points) {
        col.set(x, 0);
        row.set(y, 0);
    }

    function mapKeysToOrder(m) {
        const sortedKeys = Array.from(m.keys()).sort((a, b) => a - b);
        sortedKeys.forEach((key, index) => {
            m.set(key, index + 1);
        });
    }

    mapKeysToOrder(col);
    mapKeysToOrder(row);

    const nc = col.size + 1;
    const nr = row.size + 1;

    const m = Array.from({ length: nc }, () => new Array(nr).fill(0));

    for (const point of points) {
        const [c, r] = [col.get(point[0]), row.get(point[1])];
        coordinatesMap.set(point, [c, r]);
        m[c][r] = 1;
    }

    const prefixSum = Array.from({ length: nc }, () => new Array(nr).fill(0));

    for (let i = 1; i < nc; i++) {
        for (let j = 1; j < nr; j++) {
            prefixSum[i][j] =
                prefixSum[i - 1][j] +
                prefixSum[i][j - 1] -
                prefixSum[i - 1][j - 1] +
                m[i][j];
        }
    }

    let ans = 0;

    points.sort((a, b) => a[0] - b[0] || b[1] - a[1]);

    for (let i = 0; i < points.length - 1; i++) {
        for (let j = i + 1; j < points.length; j++) {
            if (points[i][1] >= points[j][1]) {
                const [c1, r1] = coordinatesMap.get(points[i]);
                const [c2, r2] = coordinatesMap.get(points[j]);

                const cnt =
                    prefixSum[c2][r1] -
                    prefixSum[c1 - 1][r1] -
                    prefixSum[c2][r2 - 1] +
                    prefixSum[c1 - 1][r2 - 1];

                if (cnt === 2) ans++;
            }
        }
    }

    return ans;
}
```

```TypeScript
function numberOfPairs(points: number[][]): number {
    const col = new Map<number, number>();
    const row = new Map<number, number>();
    const coordinatesMap = new Map<[number, number], [number, number]>();

    for (const [x, y] of points) {
        col.set(x, 0);
        row.set(y, 0);
    }

    function mapKeysToOrder(m: Map<number, number>) {
        const sortedKeys = Array.from(m.keys()).sort((a, b) => a - b);
        sortedKeys.forEach((key, index) => {
            m.set(key, index + 1);
        });
    }

    mapKeysToOrder(col);
    mapKeysToOrder(row);

    const nc = col.size + 1;
    const nr = row.size + 1;

    const m: number[][] = Array.from({ length: nc }, () => new Array(nr).fill(0));

    for (const point of points) {
        const [c, r] = [col.get(point[0])!, row.get(point[1])!];
        coordinatesMap.set(point as [number, number], [c, r]);
        m[c][r] = 1;
    }

    const prefixSum = Array.from({ length: nc }, () => new Array(nr).fill(0));

    for (let i = 1; i < nc; i++) {
        for (let j = 1; j < nr; j++) {
            prefixSum[i][j] =
                prefixSum[i - 1][j] +
                prefixSum[i][j - 1] -
                prefixSum[i - 1][j - 1] +
                m[i][j];
        }
    }

    let ans = 0;

    points.sort((a, b) => a[0] - b[0] || b[1] - a[1]);

    for (let i = 0; i < points.length - 1; i++) {
        for (let j = i + 1; j < points.length; j++) {
            if (points[i][1] >= points[j][1]) {
                const [c1, r1] = coordinatesMap.get(points[i] as [number, number])!;
                const [c2, r2] = coordinatesMap.get(points[j] as [number, number])!;

                const cnt =
                    prefixSum[c2][r1] -
                    prefixSum[c1 - 1][r1] -
                    prefixSum[c2][r2 - 1] +
                    prefixSum[c1 - 1][r2 - 1];

                if (cnt === 2) ans++;
            }
        }
    }

    return ans;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn number_of_pairs(points: Vec<Vec<i32>>) -> i32 {
        let mut col: HashMap<i32, usize> = HashMap::new();
        let mut row: HashMap<i32, usize> = HashMap::new();
        let mut coordinates_map: HashMap<(i32, i32), (usize, usize)> = HashMap::new();
        
        for point in &points {
            let x = point[0];
            let y = point[1];
            col.insert(x, 0);
            row.insert(y, 0);
        }
        
        let mut col_keys: Vec<i32> = col.keys().cloned().collect();
        col_keys.sort();
        for (idx, &key) in col_keys.iter().enumerate() {
            col.insert(key, idx + 1);
        }
        let mut row_keys: Vec<i32> = row.keys().cloned().collect();
        row_keys.sort();
        for (idx, &key) in row_keys.iter().enumerate() {
            row.insert(key, idx + 1);
        }
        
        let nc = col.len() + 1;
        let nr = row.len() + 1;
        let mut m = vec![vec![0; nr]; nc];
        let mut prefix_sum = vec![vec![0; nr]; nc];
        
        for point in &points {
            let x = point[0];
            let y = point[1];
            let c = *col.get(&x).unwrap();
            let r = *row.get(&y).unwrap();
            coordinates_map.insert((x, y), (c, r));
            m[c][r] = 1;
        }
        
        for i in 1..nc {
            for j in 1..nr {
                prefix_sum[i][j] = prefix_sum[i - 1][j] + prefix_sum[i][j - 1] - 
                                   prefix_sum[i - 1][j - 1] + m[i][j];
            }
        }
        
        let mut ans = 0;
        let mut sorted_points = points.clone();
        
        sorted_points.sort_by(|a, b| {
            if a[0] == b[0] {
                b[1].cmp(&a[1]) // 降序
            } else {
                a[0].cmp(&b[0]) // 升序
            }
        });
        
        let n = sorted_points.len();
        for i in 0..n-1 {
            for j in i + 1..n {
                if sorted_points[i][1] >= sorted_points[j][1] {
                    let (x1, y1) = (sorted_points[i][0], sorted_points[i][1]);
                    let (x2, y2) = (sorted_points[j][0], sorted_points[j][1]);
                    let (c1, r1) = coordinates_map[&(x1, y1)];
                    let (c2, r2) = coordinates_map[&(x2, y2)];
                    
                    let cnt = prefix_sum[c2][r1] - prefix_sum[c1 - 1][r1] - 
                              prefix_sum[c2][r2-1] + prefix_sum[c1 - 1][r2 - 1];
                    
                    if cnt == 2 {
                        ans += 1;
                    }
                }
            }
        }
        
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是 $points$ 的长度。离散化和排序 $points$ 需 $O(nlogn)$，前缀和初始化和最终遍历需 $O(n^2)$，哈希表的存取时间是 $O(1)$，故总时间复杂度是 $O(n^2)$。
- 空间复杂度：$O(n)$。
