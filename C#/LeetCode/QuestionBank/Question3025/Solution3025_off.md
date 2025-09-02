### [人员站位的方案数 I](https://leetcode.cn/problems/find-the-number-of-ways-to-place-people-i/solutions/3764850/ren-yuan-zhan-wei-de-fang-an-shu-i-by-le-k2er/)

#### 方法一：三重循环枚举

**思路与算法**

考虑数据规模为 $2\le n\le 50,$ 不难想到朴素做法：首先使用二重循环遍历所有点对。对于每对点，若不在其构成的矩形的主对角线上，则遍历判断该矩形内部（含边界）是否不存在其他点。若不存在其他的点，则该点对符合题设条件。

判断一个点是否在某个矩形内，本质上是判断该点的坐标 $(x,y)$ 是否满足矩形的横纵坐标上下限，分开判断 $x$ 和 $y$ 即可。此外注意题目要求的范围包含矩形边界，判断时应该使用闭区间。

输入数据只存在两个点的情况下，由于不会进入第三重循环，因此需要直接特判答案。

**代码**

```C++
class Solution {
public:
    int numberOfPairs(vector<vector<int>>& points) {
        int ans = 0;
        int n = points.size();

        for (int i = 0; i < n; i++) {
            auto &pointA = points[i];
            for (int j = 0; j < n; j++) {
                vector<int> pointB = points[j];
                if (i == j || !(pointA[0] <= pointB[0] && pointA[1] >= pointB[1])) {
                    continue;
                }
                if (n == 2) {
                    ans++;
                    continue;
                }

                bool illegal = false;
                for (int k = 0; k < n; k++) {
                    if (k == i || k == j) {
                        continue;
                    }

                    auto & pointTmp = points[k];
                    bool isXContained = pointTmp[0] >= pointA[0] && pointTmp[0] <= pointB[0];
                    bool isYContained = pointTmp[1] <= pointA[1] && pointTmp[1] >= pointB[1];
                    if (isXContained && isYContained) {
                        illegal = true;
                        break;
                    }
                }
                if (!illegal) {
                    ans++;
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
        int n = points.length;

        for (int i = 0; i < n; i++) {
            int[] pointA = points[i];
            for (int j = 0; j < n; j++) {
                int[] pointB = points[j];
                if (i == j || !(pointA[0] <= pointB[0] && pointA[1] >= pointB[1])) {
                    continue;
                }
                if (n == 2) {
                    ans++;
                    continue;
                }

                boolean illegal = false;
                for (int k = 0; k < n; k++) {
                    if (k == i || k == j) {
                        continue;
                    }

                    int[] pointTmp = points[k];
                    boolean isXContained = pointTmp[0] >= pointA[0] && pointTmp[0] <= pointB[0];
                    boolean isYContained = pointTmp[1] <= pointA[1] && pointTmp[1] >= pointB[1];
                    if (isXContained && isYContained) {
                        illegal = true;
                        break;
                    }
                }
                if (!illegal) {
                    ans++;
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
        int n = points.Length;

        for (int i = 0; i < n; i++) {
            int[] pointA = points[i];
            for (int j = 0; j < n; j++) {
                int[] pointB = points[j];
                if (i == j || !(pointA[0] <= pointB[0] && pointA[1] >= pointB[1])) {
                    continue;
                }
                if (n == 2) {
                    ans++;
                    continue;
                }

                bool illegal = false;
                for (int k = 0; k < n; k++) {
                    if (k == i || k == j) {
                        continue;
                    }

                    int[] pointTmp = points[k];
                    bool isXContained = pointTmp[0] >= pointA[0] && pointTmp[0] <= pointB[0];
                    bool isYContained = pointTmp[1] <= pointA[1] && pointTmp[1] >= pointB[1];
                    if (isXContained && isYContained) {
                        illegal = true;
                        break;
                    }
                }
                if (!illegal) {
                    ans++;
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
    n := len(points)

    for i := 0; i < n; i++ {
        pointA := points[i]
        for j := 0; j < n; j++ {
            pointB := points[j]
            if i == j || !(pointA[0] <= pointB[0] && pointA[1] >= pointB[1]) {
                continue
            }
            if n == 2 {
                ans++
                continue
            }

            illegal := false
            for k := 0; k < n; k++ {
                if k == i || k == j {
                    continue
                }

                pointTmp := points[k]
                isXContained := pointTmp[0] >= pointA[0] && pointTmp[0] <= pointB[0]
                isYContained := pointTmp[1] <= pointA[1] && pointTmp[1] >= pointB[1]
                if isXContained && isYContained {
                    illegal = true
                    break
                }
            }
            if !illegal {
                ans++
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
        n = len(points)

        for i in range(n):
            pointA = points[i]
            for j in range(n):
                pointB = points[j]
                if i == j or not (pointA[0] <= pointB[0] and pointA[1] >= pointB[1]):
                    continue
                if n == 2:
                    ans += 1
                    continue

                illegal = False
                for k in range(n):
                    if k == i or k == j:
                        continue

                    pointTmp = points[k]
                    isXContained = pointTmp[0] >= pointA[0] and pointTmp[0] <= pointB[0]
                    isYContained = pointTmp[1] <= pointA[1] and pointTmp[1] >= pointB[1]
                    if isXContained and isYContained:
                        illegal = True
                        break
                if not illegal:
                    ans += 1
        return ans
```

```C
int numberOfPairs(int** points, int pointsSize, int* pointsColSizes) {
    int ans = 0;

    for (int i = 0; i < pointsSize; i++) {
        int* pointA = points[i];
        for (int j = 0; j < pointsSize; j++) {
            int* pointB = points[j];
            if (i == j || !(pointA[0] <= pointB[0] && pointA[1] >= pointB[1])) {
                continue;
            }
            if (pointsSize == 2) {
                ans++;
                continue;
            }

            int illegal = 0;
            for (int k = 0; k < pointsSize; k++) {
                if (k == i || k == j) {
                    continue;
                }

                int* pointTmp = points[k];
                int isXContained = pointTmp[0] >= pointA[0] && pointTmp[0] <= pointB[0];
                int isYContained = pointTmp[1] <= pointA[1] && pointTmp[1] >= pointB[1];
                if (isXContained && isYContained) {
                    illegal = 1;
                    break;
                }
            }
            if (!illegal) {
                ans++;
            }
        }
    }
    return ans;
}
```

```JavaScript
var numberOfPairs = function (points) {
    let ans = 0;
    let n = points.length;
    for (let i = 0; i < points.length; i++) {
        const pointA = points[i];
        for (let j = 0; j < points.length; j++) {
            const pointB = points[j];
            if (i === j || !(pointA[0] <= pointB[0] && pointA[1] >= pointB[1])) {
                continue;
            }

            if (points.length === 2) {
                ans++;
                continue;
            }

            let illegal = false;

            for (const pointTmp of points) {
                if (pointA === pointTmp || pointB === pointTmp) {
                    continue;
                }

                const isXContained =
                    pointTmp[0] >= pointA[0] && pointTmp[0] <= pointB[0];
                const isYContained =
                    pointTmp[1] <= pointA[1] && pointTmp[1] >= pointB[1];

                illegal = isXContained && isYContained;

                if (illegal) {
                    break;
                }
            }

            if (!illegal) {
                ans++;
            }
        }
    }

    return ans;
};
```

```TypeScript
function numberOfPairs(points: number[][]): number {
    let ans = 0;
    let n = points.length;
    for (let i = 0; i < points.length; i++) {
        const pointA = points[i];
        for (let j = 0; j < points.length; j++) {
            const pointB = points[j];
            if (i === j || !(pointA[0] <= pointB[0] && pointA[1] >= pointB[1])) {
                continue;
            }

            if (points.length === 2) {
                ans++;
                continue;
            }

            let illegal = false;

            for (const pointTmp of points) {
                if (pointA === pointTmp || pointB === pointTmp) {
                    continue;
                }

                const isXContained =
                    pointTmp[0] >= pointA[0] && pointTmp[0] <= pointB[0];
                const isYContained =
                    pointTmp[1] <= pointA[1] && pointTmp[1] >= pointB[1];

                illegal = isXContained && isYContained;

                if (illegal) {
                    break;
                }
            }

            if (!illegal) {
                ans++;
            }
        }
    }

    return ans;
}
```

```Rust
impl Solution {
    pub fn number_of_pairs(points: Vec<Vec<i32>>) -> i32 {
        let mut ans = 0;
        let n = points.len();

        for i in 0..n {
            let pointA = &points[i];
            for j in 0..n {
                let pointB = &points[j];
                if i == j || !(pointA[0] <= pointB[0] && pointA[1] >= pointB[1]) {
                    continue;
                }
                if n == 2 {
                    ans += 1;
                    continue;
                }

                let mut illegal = false;
                for k in 0..n {
                    if k == i || k == j {
                        continue;
                    }

                    let pointTmp = &points[k];
                    let isXContained = pointTmp[0] >= pointA[0] && pointTmp[0] <= pointB[0];
                    let isYContained = pointTmp[1] <= pointA[1] && pointTmp[1] >= pointB[1];
                    if isXContained && isYContained {
                        illegal = true;
                        break;
                    }
                }
                if !illegal {
                    ans += 1;
                }
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^3)$，使用二重循环遍历所有的点对，再使用一重循环遍历所有的点来判断是否处于点对所在的矩形上。其中 $n$ 是 $points$ 的长度。
- 空间复杂度：$O(1)$。
