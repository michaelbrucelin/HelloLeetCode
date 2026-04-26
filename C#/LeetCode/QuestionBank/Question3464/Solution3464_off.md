### [正方形上的点之间的最大距离](https://leetcode.cn/problems/maximize-the-distance-between-points-on-a-square/solutions/3957467/zheng-fang-xing-shang-de-dian-zhi-jian-d-vqlb/)

#### 方法一：二分查找

**思路与算法**

这道题要求在正方形边界上选择 $k$ 个点，使得选中的点集中任意两点之间的**最小距离最大化**，经典的**最大化最小值**或**最小化最大值**问题一般都可以尝试使用二分查找。由于 $k$ 个点分布在正方形的边界上，题目给定 $k$ 的范围为: $k\ge 4$，此时可知选中的 $k$ 个点之间的**最小**曼哈顿距离一定不会超过 $side$，原因分析如下：

- 假设当 $k>4$ 时，此时 $k$ 个点无论如何分布，总会有两个点在同一条边上，此时同一条边上两个点的曼哈顿距离一定小于等于 $side$；
- 假设当 $k=4$ 时，如果 $k$ 个点刚好处于正方形的四个顶点上时，此时最小的曼哈顿距离等于 $side$，其他情况下依然会有两个点在同一条边上，此时同一条边上的两个点的曼哈顿距离一定小于等于 $side$；

综上，因此 $k$ 个点之间的**最小**曼哈顿距离一定不会超过 $side$。

我们直接计算 $k$ 个点的所有曼哈顿距离似乎比较麻烦，但注意到题目要求**最小**曼哈顿距离**最大化**，因此只需要找到k 个点的**最小曼哈顿**距离即可，而不必求出所有点的曼哈顿距离。我们注意到在选中的 $k$ 个点集中，**最小曼哈顿距离**的两个点一定在同一条边上或者相邻的边上，如果两点出现在对边（左右、上下）上，此时两点的曼哈顿距离一定大于等于 $side$，此时可以忽略。为了计算方便，在寻找 $k$ 个点的最小曼哈顿时，可将正方形进行按照左、上、右、下顺时针方向进行折叠展开，此时四条边可以按照顺序展开的原因如下：

- 答案一定不超过 $side$；
- 如果两个点原来在同一条边上或者相邻的边上，展开之后它们的距离等于原先的曼哈顿距离；
- 如果两个点原来在对边上，折叠之后它们的距离大于原先的曼哈顿距离，但原先处于对边上两点的曼哈顿距离至少为 $side$，不影响答案；

我们将 $k$ 个点转换为一维，此时最小曼哈顿距离一定在展开后的一维相邻（考虑循环）两个点之间，可以用反证法来证明，在此不再详述。

假设给定的 $side=2$，此时给定的 $k$ 个点为：$[[0,0],[0,1],[0,2],[1,2],[2,0],[2,2],[2,1]]$，此时在正方形上分为如下：

![](./assets/img/Solution3464_off_01.png)

如上图所示，我们可以将正方形的边按照左、上、右、下顺时针方向进行展开，将二维正方形边界上的点映射到一维数轴上，展开规则如下：

- 左边 $(x=0)$，距离 $= y$；
- 上边 $(y=side):$ 距离 $= side+x$；
- 右边 $(x=side):$ 距离 $= 3\cdot side-y$；
- 下边 $(y=0):$ 距离 $= 4\cdot side-x$；

展开后如下：

![](./assets/img/Solution3464_off_02.png)

上图展开后的一维坐标为：$[0,1,2,3,4,5,6]$。如果我们将所有的点转换为一维，假定给定的距离为 $x$，则此时问题转化为：

- 能否在一维数组 $arr$ 中选 $k$ 个数，且满足任意两个相邻元素相差至少为 $x$，且最后一个数和第一个数相差至多 $side\cdot 4-x$；
- 相差 $side\cdot 4-x$ 是因为 $arr$ 是个环形数组，设数组第一个点为 $a$，数组最后一个点为 $b$。对于第一个点 $a$ 来说，$b$ 在循环数组中可以视作负方向上的 $b-side\cdot 4$，此时要求 $a-(b-side\cdot 4)\ge x$，解得 $b-a\le side\cdot 4-x$。

我们利用二分查找，来找到**最小距离的最大值**，此时二分查找的下限为 $1$，根据前述推论，二分查找上限可设为 $side$，实际算法过程如下：

- 首先我们将所有二维坐标的点，按照左、上、右、下顺时针方向进行展开为一维坐标数组 $arr$，arr 按照一维坐标大小进行排序；
- 其次进行二分查找，假设当前给定的距离为 $limit$，判定过程为：数组 $arr$ 从左向右开始枚举第一个数，不断向后二分查找相距至少为 $limit$ 的元素，即在数组中找到 $k$ 个元素，满足相邻元素之间的距离大于等于 $limit$，当查找到数组末尾或满足第一个数和最后一个数相差超过 $side\cdot 4-limit$ 时则停止查找；
- 如果给定的距离 $limit$ 可以满足要求则提高二分查找下限，否则降低上限，直到找到目标答案为止；

**代码**

```C++
class Solution {
public:
    int maxDistance(int side, vector<vector<int>>& points, int k) {
        vector<long long> arr;

        for (auto& p : points) {
            int x = p[0], y = p[1];
            if (x == 0) {
                arr.push_back(y);
            } else if (y == side) {
                arr.push_back(side + x);
            } else if (x == side) {
                arr.push_back(side * 3LL - y);
            } else {
                arr.push_back(side * 4LL - x);
            }
        }
        sort(arr.begin(), arr.end());

        auto check = [&](long long limit) -> bool {
            for (long long start : arr) {
                long long end = start + side * 4LL - limit;
                long long cur = start;
                for (int i = 0; i < k - 1; i++) {
                    auto it = ranges::lower_bound(arr, cur + limit);
                    if (it == arr.end() || *it > end) {
                        cur = -1;
                        break;
                    }
                    cur = *it;
                }
                if (cur >= 0) {
                    return true;
                }
            }
            return false;
        };

        long long lo = 1, hi = side;
        int ans = 0;
        while (lo <= hi) {
            long long mid = (lo + hi) / 2;
            if (check(mid)) {
                lo = mid + 1;
                ans = mid;
            } else {
                hi = mid - 1;
            }
        }

        return ans;
    }
};
```

```Java
class Solution {
    public int maxDistance(int side, int[][] points, int k) {
        List<Long> arr = new ArrayList<>();

        for (int[] p : points) {
            int x = p[0], y = p[1];
            if (x == 0) {
                arr.add((long) y);
            } else if (y == side) {
                arr.add((long) side + x);
            } else if (x == side) {
                arr.add(side * 3L - y);
            } else {
                arr.add(side * 4L - x);
            }
        }
        Collections.sort(arr);

        long lo = 1, hi = side;
        int ans = 0;

        while (lo <= hi) {
            long mid = (lo + hi) / 2;
            if (check(arr, side, k, mid)) {
                lo = mid + 1;
                ans = (int) mid;
            } else {
                hi = mid - 1;
            }
        }
        return ans;
    }

    private boolean check(List<Long> arr, int side, int k, long limit) {
        long perimeter = side * 4L;

        for (long start : arr) {
            long end = start + perimeter - limit;
            long cur = start;

            for (int i = 0; i < k - 1; i++) {
                int idx = lowerBound(arr, cur + limit);
                if (idx == arr.size() || arr.get(idx) > end) {
                    cur = -1;
                    break;
                }
                cur = arr.get(idx);
            }

            if (cur >= 0) {
                return true;
            }
        }
        return false;
    }

    private int lowerBound(List<Long> arr, long target) {
        int left = 0, right = arr.size();
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (arr.get(mid) < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
}
```

```CSharp
public class Solution {
    public int MaxDistance(int side, int[][] points, int k) {
        List<long> arr = new List<long>();

        foreach (var p in points) {
            int x = p[0], y = p[1];
            if (x == 0) {
                arr.Add(y);
            } else if (y == side) {
                arr.Add(side + (long)x);
            } else if (x == side) {
                arr.Add(side * 3L - y);
            } else {
                arr.Add(side * 4L - x);
            }
        }
        arr.Sort();

        long lo = 1, hi = side;
        int ans = 0;

        while (lo <= hi) {
            long mid = (lo + hi) / 2;
            if (Check(arr, side, k, mid)) {
                lo = mid + 1;
                ans = (int)mid;
            } else {
                hi = mid - 1;
            }
        }
        return ans;
    }

    private bool Check(List<long> arr, int side, int k, long limit) {
        long perimeter = side * 4L;

        foreach (long start in arr) {
            long end = start + perimeter - limit;
            long cur = start;

            for (int i = 0; i < k - 1; i++) {
                int idx = LowerBound(arr, cur + limit);
                if (idx == arr.Count || arr[idx] > end) {
                    cur = -1;
                    break;
                }
                cur = arr[idx];
            }

            if (cur >= 0) {
                return true;
            }
        }
        return false;
    }

    private int LowerBound(List<long> arr, long target) {
        int left = 0, right = arr.Count;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
}
```

```Go
func maxDistance(side int, points [][]int, k int) int {
	arr := make([]int64, 0, len(points))

	for _, p := range points {
		x, y := p[0], p[1]
		if x == 0 {
			arr = append(arr, int64(y))
		} else if y == side {
			arr = append(arr, int64(side + x))
		} else if x == side {
			arr = append(arr, int64(side * 3 - y))
		} else {
			arr = append(arr, int64(side * 4 - x))
		}
	}
	sort.Slice(arr, func(i, j int) bool { return arr[i] < arr[j] })

	lo, hi := int64(1), int64(side)
	ans := 0
	for lo <= hi {
		mid := (lo + hi) / 2
		if check(arr, int64(side), k, mid) {
			lo = mid + 1
			ans = int(mid)
		} else {
			hi = mid - 1
		}
	}
	return ans
}

func check(arr []int64, side int64, k int, limit int64) bool {
	perimeter := side * 4

	for _, start := range arr {
		end := start + perimeter - limit
		cur := start

		for i := 0; i < k-1; i++ {
			idx := lowerBound(arr, cur+limit)
			if idx == len(arr) || arr[idx] > end {
				cur = -1
				break
			}
			cur = arr[idx]
		}

		if cur >= 0 {
			return true
		}
	}
	return false
}

func lowerBound(arr []int64, target int64) int {
	left, right := 0, len(arr)
	for left < right {
		mid := left + (right - left) / 2
		if arr[mid] < target {
			left = mid + 1
		} else {
			right = mid
		}
	}
	return left
}
```

```Python
class Solution:
    def maxDistance(self, side: int, points: List[List[int]], k: int) -> int:
        arr = []

        for x, y in points:
            if x == 0:
                arr.append(y)
            elif y == side:
                arr.append(side + x)
            elif x == side:
                arr.append(side * 3 - y)
            else:
                arr.append(side * 4 - x)

        arr.sort()

        def check(limit: int) -> bool:
            perimeter = side * 4
            for start in arr:
                end = start + perimeter - limit
                cur = start
                for _ in range(k - 1):
                    idx = bisect_left(arr, cur + limit)
                    if idx == len(arr) or arr[idx] > end:
                        cur = -1
                        break
                    cur = arr[idx]
                if cur >= 0:
                    return True
            return False

        lo, hi = 1, side
        ans = 0

        while lo <= hi:
            mid = (lo + hi) // 2
            if check(mid):
                lo = mid + 1
                ans = mid
            else:
                hi = mid - 1

        return ans
```

```C
int lower_bound(long long* arr, int size, long long target) {
    int left = 0, right = size;
    while (left < right) {
        int mid = left + (right - left) / 2;
        if (arr[mid] < target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }

    return left;
}

int compare(const void* a, const void* b) {
    long long la = *(const long long*)a;
    long long lb = *(const long long*)b;
    return (la > lb) - (la < lb);
}

int check(long long* arr, int size, int side, int k, long long limit) {
    long long perimeter = side * 4LL;

    for (int i = 0; i < size; i++) {
        long long start = arr[i];
        long long end = start + perimeter - limit;
        long long cur = start;

        for (int j = 0; j < k - 1; j++) {
            int idx = lower_bound(arr, size, cur + limit);
            if (idx == size || arr[idx] > end) {
                cur = -1;
                break;
            }
            cur = arr[idx];
        }

        if (cur >= 0) {
            return 1;
        }
    }
    return 0;
}

int maxDistance(int side, int** points, int pointsSize, int* pointsColSize, int k) {
    long long* arr = (long long*)malloc(pointsSize * sizeof(long long));

    for (int i = 0; i < pointsSize; i++) {
        int x = points[i][0], y = points[i][1];
        if (x == 0) {
            arr[i] = y;
        } else if (y == side) {
            arr[i] = side + (long long)x;
        } else if (x == side) {
            arr[i] = side * 3LL - y;
        } else {
            arr[i] = side * 4LL - x;
        }
    }

    qsort(arr, pointsSize, sizeof(long long), compare);

    long long lo = 1, hi = side;
    int ans = 0;
    while (lo <= hi) {
        long long mid = (lo + hi) / 2;
        if (check(arr, pointsSize, side, k, mid)) {
            lo = mid + 1;
            ans = (int)mid;
        } else {
            hi = mid - 1;
        }
    }

    free(arr);
    return ans;
}
```

```JavaScript
var maxDistance = function(side, points, k) {
    const arr = [];

    for (const [x, y] of points) {
        if (x === 0) {
            arr.push(y);
        } else if (y === side) {
            arr.push(side + x);
        } else if (x === side) {
            arr.push(side * 3 - y);
        } else {
            arr.push(side * 4 - x);
        }
    }

    arr.sort((a, b) => a - b);

    const lowerBound = (target) => {
        let left = 0, right = arr.length;
        while (left < right) {
            const mid = Math.floor((left + right) / 2);
            if (arr[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    };

    const check = (limit) => {
        const perimeter = side * 4;
        for (const start of arr) {
            const end = start + perimeter - limit;
            let cur = start;
            for (let i = 0; i < k - 1; i++) {
                const idx = lowerBound(cur + limit);
                if (idx === arr.length || arr[idx] > end) {
                    cur = -1;
                    break;
                }
                cur = arr[idx];
            }
            if (cur >= 0) return true;
        }
        return false;
    };

    let lo = 1, hi = side;
    let ans = 0;

    while (lo <= hi) {
        const mid = Math.floor((lo + hi) / 2);
        if (check(mid)) {
            lo = mid + 1;
            ans = mid;
        } else {
            hi = mid - 1;
        }
    }

    return ans;
};
```

```TypeScript
function maxDistance(side: number, points: number[][], k: number): number {
    const arr: number[] = [];

    for (const [x, y] of points) {
        if (x === 0) {
            arr.push(y);
        } else if (y === side) {
            arr.push(side + x);
        } else if (x === side) {
            arr.push(side * 3 - y);
        } else {
            arr.push(side * 4 - x);
        }
    }

    arr.sort((a, b) => a - b);

    const lowerBound = (target: number): number => {
        let left = 0, right = arr.length;
        while (left < right) {
            const mid = Math.floor((left + right) / 2);
            if (arr[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    };

    const check = (limit: number): boolean => {
        const perimeter = side * 4;
        for (const start of arr) {
            const end = start + perimeter - limit;
            let cur = start;
            for (let i = 0; i < k - 1; i++) {
                const idx = lowerBound(cur + limit);
                if (idx === arr.length || arr[idx] > end) {
                    cur = -1;
                    break;
                }
                cur = arr[idx];
            }
            if (cur >= 0) return true;
        }
        return false;
    };

    let lo = 1, hi = side;
    let ans = 0;

    while (lo <= hi) {
        const mid = Math.floor((lo + hi) / 2);
        if (check(mid)) {
            lo = mid + 1;
            ans = mid;
        } else {
            hi = mid - 1;
        }
    }

    return ans;
}
```

```Rust
impl Solution {
    pub fn max_distance(side: i32, points: Vec<Vec<i32>>, k: i32) -> i32 {
        let mut arr: Vec<i64> = Vec::new();

        for p in points {
            let x = p[0];
            let y = p[1];
            if x == 0 {
                arr.push(y as i64);
            } else if y == side {
                arr.push(side as i64 + x as i64);
            } else if x == side {
                arr.push(side as i64 * 3 - y as i64);
            } else {
                arr.push(side as i64 * 4 - x as i64);
            }
        }

        arr.sort_unstable();

        let lower_bound = |target: i64| -> usize {
            let mut left = 0;
            let mut right = arr.len();
            while left < right {
                let mid = left + (right - left) / 2;
                if arr[mid] < target {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
            left
        };

        let check = |limit: i64| -> bool {
            let perimeter = side as i64 * 4;
            for &start in &arr {
                let end = start + perimeter - limit;
                let mut cur = start;
                for _ in 0..(k - 1) {
                    let idx = lower_bound(cur + limit);
                    if idx == arr.len() || arr[idx] > end {
                        cur = -1;
                        break;
                    }
                    cur = arr[idx];
                }
                if cur >= 0 {
                    return true;
                }
            }
            false
        };

        let mut lo = 1i64;
        let mut hi = side as i64;
        let mut ans = 0;

        while lo <= hi {
            let mid = (lo + hi) / 2;
            if check(mid) {
                lo = mid + 1;
                ans = mid as i32;
            } else {
                hi = mid - 1;
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nk\cdot \log side\cdot \log n)$，其中 $n$ 表示给定数组 $points$ 的长度，$k$ 表示给定整数 $k$，side 表示正方形的边长。$n$ 个点的排序时间复杂度为 $O(n\log n)$，每次二分查找的时间复杂度为 $O(nk\cdot \log n)$，最多进行 $\log side$ 次二分查找，因此二分查找的总时间复杂度为 $O(nk\cdot \log side\cdot \log n)$，总的时间复杂度为 $O(n\log n+nk\cdot \log side\cdot \log n)=O(nk\cdot \log side\cdot \log n)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示给定数组 $points$ 的长度。存储所有坐标的长度需要 $n$ 的数组。
