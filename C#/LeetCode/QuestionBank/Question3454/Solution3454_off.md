### [分割正方形 II](https://leetcode.cn/problems/separate-squares-ii/solutions/3878861/fen-ge-zheng-fang-xing-ii-by-leetcode-so-baas/)

#### 方法一：扫描线 $+$ 线段树

**思路与算法**

由于本题中正方形的**重叠区**域只**统计一次**，我们可以参考题解 「[850\. 矩形面积 II](https://leetcode.cn/problems/rectangle-area-ii/solutions/1825859/ju-xing-mian-ji-ii-by-leetcode-solution-ulqz/)」题解中的方法二，涉及使用「[线段树](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fds%2Fseg%2F%3Fquery%3D%E7%BA%BF%E6%AE%B5%E6%A0%91)」比较超纲。

![](./assets/img/Solution3354_off_01.png)

我们可以参考上图，如果此时需要计算上述被覆盖的面积，此时我们只需要求出 $w_1+w_2$，此时覆盖的面积即为 $h\times (w_1+w_2)$。我们可以使用 「[扫描线](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgeometry%2Fscanning%2F)」的算法来求出所有正方形覆盖的面积。把整个矩形分成如图各个颜色不同的小矩形，小矩形的高是扫过的距离，然而矩形的水平宽一直在变化。给每一个矩形的上下边进行标记，下面的边标记为 $1$，上面的边标记为 $-1$。每遇到一个水平边时，让这条边的权值加上这条边的标记。小矩形的宽度就是整个数轴上权值大于 $0$ 的区间总长度。

![](./assets/img/Solution3354_off_02.svg)

具体地，我们可以将正方形的所有横坐标从小到大排序后进行「[离散化](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fmisc%2Fdiscrete%2F)」以维护每条底边，需要使用线段树来维护矩形动态变化的底边长，也就是整个数轴上覆盖次数大于 $0$ 的点。由于扫面线从下往上移动时，每次更新时，会将一个连续区域内的点的权值进行更新，即进行区间更新，此时需要用到懒标记的线段树，但实现似乎较为复杂。我们参考「[二维矩形面积并问题](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgeometry%2Fscanning%2F%23%E4%BA%8C%E7%BB%B4%E7%9F%A9%E5%BD%A2%E9%9D%A2%E7%A7%AF%E5%B9%B6%E9%97%AE%E9%A2%98)」的解法，使用线段树维护每个节点管理区间中**完全覆盖区间的次数**和**区间已覆盖的长度**即可，具体实现细节不再描述，我们很容易求出整个覆盖区域总面积 $totalArea$。

接着我们如何找到最小的 $y$ 使得 $y$ 以下的覆盖面积与 $y$ 以上的覆盖面积相等。此时我们可以进行二次扫描，设扫描线 $y=y^′$ 下方的覆盖的面积和为 $area$，那么扫描线上方的面积和为 $totalArea-area$。

题目要求 $y=y^′$ 下面的面积与上方的面积相等，即:

$$area=totalArea-area$$

即：

$$area=\dfrac{totalArea}{2}$$

设当前经过矩形上/下边界的扫描线为 $y=y^′$，此时扫面线以下的覆盖面积为 $area$；向上移动时下一个需要经过的矩形上/下边界的扫描线为 $y=y^{′′}$，此时被正方形覆盖的底边长之和为 $width$，则此时在扫面线 $y=y^{′′}$ 以下覆盖的面积之和为:

$$area+width\cdot (y^{′′}-y^′)$$

此时当满足：

$$area<\dfrac{totalArea}{2}  \\ area+width\cdot (y^{′′}-y^′)\ge \dfrac{totalArea}{2}$$

时，则可以知道目标值 $y$ 一定处于区间 $[y^′,y^{′′}]$。 $ $
由于两个扫面线之间的被覆盖区域中所有的矩形的高度相同，扫面线在区间 $[y^′,y^{′′}]$ 移动长度为 $\Delta $ 时，此时被覆盖区域的面积变化即为 $\Delta \cdot width$，此时被覆盖的面积只需增加 $\dfrac{totalArea}{2}-area$，即可满足上下面积相等，此时我们可以直接求出目标值 $y$ 即为：

$$y=y^′+\dfrac{\dfrac{totalArea}{2}-area}{width}=y^′+\dfrac{totalArea-2\cdot area}{2\cdot width}$$

实际在计算时，我们可以避免第二次扫描，可在第一次扫描过程中记录每个高度区间对应的覆盖面积和覆盖宽度，随后通过遍历或二分查找确定目标值 $y^′$。

**代码**

```C++
class SegmentTree {
private:
    vector<int> count;
    vector<int> covered;
    vector<int> xs;
    int n;

    void modify(int qleft, int qright, int qval, int left, int right, int pos) {
        if (xs[right + 1] <= qleft || xs[left] >= qright) {
            return;
        }
        if (qleft <= xs[left] && xs[right + 1] <= qright) {
            count[pos] += qval;
        } else {
            int mid = (left + right) / 2;
            modify(qleft, qright, qval, left, mid, pos * 2 + 1);
            modify(qleft, qright, qval, mid + 1, right, pos * 2 + 2);
        }

        if (count[pos] > 0) {
            covered[pos] = xs[right + 1] - xs[left];
        } else {
            if (left == right) {
                covered[pos] = 0;
            } else {
                covered[pos] = covered[pos * 2 + 1] + covered[pos * 2 + 2];
            }
        }
    }

public:
    SegmentTree(vector<int>& xs_) : xs(xs_) {
        n = xs.size() - 1;
        count.resize(4 * n, 0);
        covered.resize(4 * n, 0);
    }

    void update(int qleft, int qright, int qval) {
        modify(qleft, qright, qval, 0, n - 1, 0);
    }

    int query() {
        return covered[0];
    }
};

class Solution {
public:
    double separateSquares(vector<vector<int>>& squares) {
        vector<tuple<int, int, int, int>> events;
        set<int> xsSet;

        for (auto& sq : squares) {
            int x = sq[0], y = sq[1], l = sq[2];
            int xr = x + l;
            events.emplace_back(y, 1, x, xr);
            events.emplace_back(y + l, -1, x, xr);
            xsSet.insert(x);
            xsSet.insert(xr);
        }

        // 按y坐标排序事件
        sort(events.begin(), events.end());
        // 离散化坐标
        vector<int> xs(xsSet.begin(), xsSet.end());
        // 初始化线段树
        SegmentTree segTree(xs);

        vector<double> psum;
        vector<int> widths;
        double total_area = 0.0;
        int prev = get<0>(events[0]);

        // 扫描：计算总面积和记录中间状态
        for (auto& [y, delta, xl, xr] : events) {
            int len = segTree.query();
            total_area += 1LL * len * (y - prev);
            segTree.update(xl, xr, delta);
            // 记录前缀和和宽度
            psum.push_back(total_area);
            widths.push_back(segTree.query());
            prev = y;
        }

        // 计算目标面积（向上取整的一半）
        long long target = (long long)(total_area + 1) / 2;
        // 二分查找第一个大于等于target的位置
        int i = lower_bound(psum.begin(), psum.end(), target) - psum.begin() - 1;
        // 获取对应的面积、宽度和高度
        double area = psum[i];
        int width = widths[i], height = get<0>(events[i]);

        return height + (total_area - area * 2) / (width * 2.0);
    }
};
```

```Java
class SegmentTree {
    private int[] count;
    private int[] covered;
    private int[] xs;
    private int n;

    public SegmentTree(int[] xs_) {
        xs = xs_;
        n = xs.length - 1;
        count = new int[4 * n];
        covered = new int[4 * n];
    }

    private void modify(int qleft, int qright, int qval, int left, int right, int pos) {
        if (xs[right + 1] <= qleft || xs[left] >= qright) {
            return;
        }
        if (qleft <= xs[left] && xs[right + 1] <= qright) {
            count[pos] += qval;
        } else {
            int mid = (left + right) / 2;
            modify(qleft, qright, qval, left, mid, pos * 2 + 1);
            modify(qleft, qright, qval, mid + 1, right, pos * 2 + 2);
        }

        if (count[pos] > 0) {
            covered[pos] = xs[right + 1] - xs[left];
        } else {
            if (left == right) {
                covered[pos] = 0;
            } else {
                covered[pos] = covered[pos * 2 + 1] + covered[pos * 2 + 2];
            }
        }
    }

    public void update(int qleft, int qright, int qval) {
        modify(qleft, qright, qval, 0, n - 1, 0);
    }

    public int query() {
        return covered[0];
    }
}

class Solution {
    public double separateSquares(int[][] squares) {
        // 存储事件: (y坐标, 类型, 左边界, 右边界)
        List<int[]> events = new ArrayList<>();
        Set<Integer> xsSet = new TreeSet<>();

        for (int[] sq : squares) {
            int x = sq[0], y = sq[1], l = sq[2];
            int xr = x + l;
            events.add(new int[]{y, 1, x, xr});
            events.add(new int[]{y + l, -1, x, xr});
            xsSet.add(x);
            xsSet.add(xr);
        }

        // 按y坐标排序事件
        events.sort((a, b) -> Integer.compare(a[0], b[0]));
        // 离散化坐标
        int[] xs = xsSet.stream().mapToInt(i -> i).toArray();
        // 初始化线段树
        SegmentTree segTree = new SegmentTree(xs);

        List<Long> psum = new ArrayList<>();
        List<Integer> widths = new ArrayList<>();
        Long totalArea = 0L;
        int prev = events.get(0)[0];

        // 扫描：计算总面积和记录中间状态
        for (int[] event : events) {
            int y = event[0], delta = event[1], xl = event[2], xr = event[3];
            int len = segTree.query();
            totalArea += (long) len * (y - prev);
            segTree.update(xl, xr, delta);
            // 记录前缀和和宽度
            psum.add(totalArea);
            widths.add(segTree.query());
            prev = y;
        }

        // 计算目标面积（向上取整的一半）
        long target = (long)(totalArea + 1) / 2;
        // 二分查找
        int i = binarySearch(psum, target);
        double area = psum.get(i);
        // 获取对应的面积、宽度和高度
        int width = widths.get(i), height = events.get(i)[0];

        return height + (totalArea - area * 2) / (width * 2.0);
    }

    private int binarySearch(List<Long> list, long target) {
        int left = 0;
        int right = list.size() - 1;
        int result = 0;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (list.get(mid) < target) {
                result = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return result;
    }
}
```

```CSharp
public class SegmentTree {
    private int[] count;
    private int[] covered;
    private int[] xs;
    private int n;

    public SegmentTree(int[] xs_) {
        xs = xs_;
        n = xs.Length - 1;
        count = new int[4 * n];
        covered = new int[4 * n];
    }

    private void Modify(int qleft, int qright, int qval, int left, int right, int pos) {
        if (xs[right + 1] <= qleft || xs[left] >= qright) {
            return;
        }
        if (qleft <= xs[left] && xs[right + 1] <= qright) {
            count[pos] += qval;
        } else {
            int mid = (left + right) / 2;
            Modify(qleft, qright, qval, left, mid, pos * 2 + 1);
            Modify(qleft, qright, qval, mid + 1, right, pos * 2 + 2);
        }

        if (count[pos] > 0) {
            covered[pos] = xs[right + 1] - xs[left];
        } else {
            if (left == right) {
                covered[pos] = 0;
            } else {
                covered[pos] = covered[pos * 2 + 1] + covered[pos * 2 + 2];
            }
        }
    }

    public void Update(int qleft, int qright, int qval) {
        Modify(qleft, qright, qval, 0, n - 1, 0);
    }

    public int Query() {
        return covered[0];
    }
}

public class Solution {
    public double SeparateSquares(int[][] squares) {
        // 存储事件: (y坐标, 类型, 左边界, 右边界)
        List<int[]> events = new List<int[]>();
        SortedSet<int> xsSet = new SortedSet<int>();

        foreach (var sq in squares) {
            int x = sq[0], y = sq[1], l = sq[2];
            int xr = x + l;
            events.Add(new int[]{y, 1, x, xr});
            events.Add(new int[]{y + l, -1, x, xr});
            xsSet.Add(x);
            xsSet.Add(xr);
        }

        // 按y坐标排序事件
        events.Sort((a, b) => a[0].CompareTo(b[0]));
        // 离散化坐标
        int[] xs = xsSet.ToArray();
        // 初始化线段树
        SegmentTree segTree = new SegmentTree(xs);

        List<long> psum = new List<long>();
        List<int> widths = new List<int>();
        long totalArea = 0;
        int prev = events[0][0];

        // 扫描：计算总面积和记录中间状态
        foreach (var eventItem in events) {
            int y = eventItem[0], delta = eventItem[1], xl = eventItem[2], xr = eventItem[3];
            int len = segTree.Query();
            totalArea += (long)len * (y - prev);
            segTree.Update(xl, xr, delta);
            // 记录前缀和和宽度
            psum.Add(totalArea);
            widths.Add(segTree.Query());
            prev = y;
        }

        // 计算目标面积（向上取整的一半）
        long target = (totalArea + 1) / 2;
        // 二分查找第一个大于等于target的位置
        int idx = BinarySearch(psum, target);
        // 获取对应的面积、宽度和高度
        double area = psum[idx];
        int width = widths[idx], height = events[idx][0];

        return height + (totalArea - area * 2) / (width * 2.0);
    }

    private int BinarySearch(List<long> list, long target) {
        int left = 0;
        int right = list.Count - 1;
        int result = 0;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (list[mid] < target) {
                result = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return result;
    }
}
```

```Go
type SegmentTree struct {
	count   []int
	covered []int
	xs      []int
	n       int
}

func NewSegmentTree(xs []int) *SegmentTree {
	n := len(xs) - 1
	return &SegmentTree{
		count:   make([]int, 4*n),
		covered: make([]int, 4*n),
		xs:      xs,
		n:       n,
	}
}

func (st *SegmentTree) modify(qleft, qright, qval, left, right, pos int) {
	if st.xs[right+1] <= qleft || st.xs[left] >= qright {
		return
	}
	if qleft <= st.xs[left] && st.xs[right+1] <= qright {
		st.count[pos] += qval
	} else {
		mid := (left + right) / 2
		st.modify(qleft, qright, qval, left, mid, pos*2+1)
		st.modify(qleft, qright, qval, mid+1, right, pos*2+2)
	}

	if st.count[pos] > 0 {
		st.covered[pos] = st.xs[right+1] - st.xs[left]
	} else {
		if left == right {
			st.covered[pos] = 0
		} else {
			st.covered[pos] = st.covered[pos*2+1] + st.covered[pos*2+2]
		}
	}
}

func (st *SegmentTree) Update(qleft, qright, qval int) {
	st.modify(qleft, qright, qval, 0, st.n-1, 0)
}

func (st *SegmentTree) Query() int {
	return st.covered[0]
}

func separateSquares(squares [][]int) float64 {
	// 存储事件: (y坐标, 类型, 左边界, 右边界)
	type Event struct {
		y, delta, xl, xr int
	}
	events := []Event{}
	xsSet := make(map[int]bool)

	for _, sq := range squares {
		x, y, l := sq[0], sq[1], sq[2]
		xr := x + l
		events = append(events, Event{y, 1, x, xr})
		events = append(events, Event{y + l, -1, x, xr})
		xsSet[x] = true
		xsSet[xr] = true
	}

	// 按y坐标排序事件
	sort.Slice(events, func(i, j int) bool {
		return events[i].y < events[j].y
	})

	// 离散化坐标
	xs := make([]int, 0, len(xsSet))
	for x := range xsSet {
		xs = append(xs, x)
	}
	sort.Ints(xs)

	// 初始化线段树
	segTree := NewSegmentTree(xs)

	psum := []float64{}
	widths := []int{}
	totalArea := 0.0
	prev := events[0].y

	// 扫描：计算总面积和记录中间状态
	for _, event := range events {
		y, delta, xl, xr := event.y, event.delta, event.xl, event.xr
		length := segTree.Query()
		totalArea += float64(length) * float64(y-prev)
		segTree.Update(xl, xr, delta)
		// 记录前缀和和宽度
		psum = append(psum, totalArea)
		widths = append(widths, segTree.Query())
		prev = y
	}

	// 计算目标面积（向上取整的一半）
	target := int64(totalArea + 1) / 2
	// 二分查找第一个大于等于target的位置
	i := sort.Search(len(psum), func(i int) bool {
		return psum[i] >= float64(target)
	})
	i--

	// 获取对应的面积、宽度和高度
	area := psum[i]
	width := widths[i]
	height := events[i].y

	return float64(height) + (totalArea - area * 2) / (float64(width) * 2.0)
}
```

```Python
from typing import List
import bisect

class SegmentTree:
    def __init__(self, xs: List[int]):
        self.xs = xs
        self.n = len(xs) - 1
        self.count = [0] * (4 * self.n)
        self.covered = [0] * (4 * self.n)

    def update(self, qleft, qright, qval, left, right, pos):
        if self.xs[right+1] <= qleft or self.xs[left] >= qright:
            return
        if qleft <= self.xs[left] and self.xs[right+1] <= qright:
            self.count[pos] += qval
        else:
            mid = (left + right) // 2
            self.update(qleft, qright, qval, left, mid, pos*2 + 1)
            self.update(qleft, qright, qval, mid+1, right, pos*2 + 2)

        if self.count[pos] > 0:
            self.covered[pos] = self.xs[right + 1] - self.xs[left]
        else:
            if left == right:
                self.covered[pos] = 0
            else:
                self.covered[pos] = self.covered[pos * 2 + 1] + self.covered[pos * 2 + 2]

    def query(self):
        return self.covered[0]

class Solution:
    def separateSquares(self, squares: List[List[int]]) -> float:
        events = []
        xs_set = set()
        for x, y, l in squares:
            events.append((y, 1, x, x + l))
            events.append((y + l, -1, x, x + l))
            xs_set.update([x, x + l])
        xs = sorted(xs_set)

        seg_tree = SegmentTree(xs)
        events.sort()

        psum = []
        widths = []
        total_area = 0.0
        prev_y = events[0][0]

        # 扫描：计算总面积和记录中间状态
        for y, delta, xl, xr in events:
            length = seg_tree.query()
            total_area += length * (y - prev_y)
            seg_tree.update(xl, xr, delta, 0, seg_tree.n - 1, 0)
            # 记录前缀和和宽度
            psum.append(total_area)
            widths.append(seg_tree.query())
            prev_y = y

        # 计算目标面积（向上取整的一半）
        target = (total_area + 1) // 2
        # 二分查找第一个大于等于target的位置
        i = bisect.bisect_left(psum, target) - 1
        # 获取对应的面积、宽度和高度
        area = psum[i]
        width = widths[i]
        height = events[i][0]

        return height + (total_area - area * 2) / (width * 2.0)
```

```C
typedef struct {
    int *count;
    int *covered;
    int *xs;
    int n;
} SegmentTree;

typedef struct {
    int y;
    int delta;
    int xl;
    int xr;
} Event;

// 创建线段树
SegmentTree* createSegmentTree(int *xs, int xsSize) {
    SegmentTree *st = (SegmentTree*)malloc(sizeof(SegmentTree));
    st->xs = (int*)malloc(sizeof(int) * xsSize);
    memcpy(st->xs, xs, sizeof(int) * xsSize);
    st->n = xsSize - 1;
    int size = 4 * st->n;
    st->count = (int*)calloc(size, sizeof(int));
    st->covered = (int*)calloc(size, sizeof(int));
    return st;
}

void freeSegmentTree(SegmentTree *st) {
    free(st->count);
    free(st->covered);
    free(st->xs);
    free(st);
}

// 修改线段树
void modify(SegmentTree *st, int qleft, int qright, int qval, int left, int right, int pos) {
    if (st->xs[right + 1] <= qleft || st->xs[left] >= qright) {
        return;
    }
    if (qleft <= st->xs[left] && st->xs[right + 1] <= qright) {
        st->count[pos] += qval;
    } else {
        int mid = (left + right) / 2;
        modify(st, qleft, qright, qval, left, mid, pos * 2 + 1);
        modify(st, qleft, qright, qval, mid + 1, right, pos * 2 + 2);
    }

    if (st->count[pos] > 0) {
        st->covered[pos] = st->xs[right + 1] - st->xs[left];
    } else {
        if (left == right) {
            st->covered[pos] = 0;
        } else {
            st->covered[pos] = st->covered[pos * 2 + 1] + st->covered[pos * 2 + 2];
        }
    }
}

// 更新线段树
void updateSegmentTree(SegmentTree *st, int qleft, int qright, int qval) {
    modify(st, qleft, qright, qval, 0, st->n - 1, 0);
}

// 查询线段树
int querySegmentTree(SegmentTree *st) {
    return st->covered[0];
}

// 比较函数
int compareEvents(const void *a, const void *b) {
    Event *e1 = (Event*)a;
    Event *e2 = (Event*)b;
    return e1->y - e2->y;
}

// 比较函数
int compareInts(const void *a, const void *b) {
    return *(int*)a - *(int*)b;
}

// 二分查找 - 在double数组中查找
int binarySearch(long long *arr, int size, long long target) {
    int left = 0, right = size - 1;
    while (left <= right) {
        int mid = left + (right - left) / 2;
        if (arr[mid] < target) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    return left - 1; // 返回小于target的最后一个位置
}

// 去重
int unique(int *arr, int arrSize) {
    if (arrSize <= 1) {
        return arrSize;
    }
    int j = 0;
    for (int i = 1; i < arrSize; i++) {
        if (arr[i] != arr[j]) {
            j++;
            arr[j] = arr[i];
        }
    }
    return j + 1;
}

double separateSquares(int** squares, int squaresSize, int* squaresColSize) {
    Event *events = (Event*)malloc(sizeof(Event) * squaresSize * 2);
    int *xs = (int*)malloc(sizeof(int) * squaresSize * 4);
    int eventsSize = 0, xsSize = 0;

    // 收集所有事件和x坐标
    for (int i = 0; i < squaresSize; i++) {
        int x = squares[i][0];
        int y = squares[i][1];
        int l = squares[i][2];
        int xr = x + l;

        xs[xsSize++] = x;
        xs[xsSize++] = xr;
        events[eventsSize++] = (Event){y, 1, x, xr};
        events[eventsSize++] = (Event){y + l, -1, x, xr};
    }

    // 按y坐标排序事件
    qsort(events, eventsSize, sizeof(Event), compareEvents);
    // 排序并去重x坐标
    qsort(xs, xsSize, sizeof(int), compareInts);
    xsSize = unique(xs, xsSize);

    // 创建线段树
    SegmentTree *segTree = createSegmentTree(xs, xsSize);

    // 存储前缀和和宽度
    long long *psum = (long long*)malloc(sizeof(long long) * eventsSize);
    int *widths = (int*)malloc(sizeof(int) * eventsSize);
    long long totalArea = 0LL;
    int prev = events[0].y;
    int pos = 0;

    // 扫描：计算总面积和记录中间状态
    for (int i = 0; i < eventsSize; i++) {
        int y = events[i].y;
        int delta = events[i].delta;
        int xl = events[i].xl;
        int xr = events[i].xr;

        totalArea += (double)querySegmentTree(segTree) * (y - prev);
        updateSegmentTree(segTree, xl, xr, delta);
        // 记录前缀和和宽度
        psum[i] = totalArea;
        widths[i] = querySegmentTree(segTree);
        prev = y;
    }

    // 计算目标面积（向上取整的一半）
    long long target = (long long)(totalArea + 1) / 2;
    // 二分查找第一个大于等于target的位置
    int idx = binarySearch(psum, eventsSize, (double)target);
    // 获取对应的面积、宽度和高度
    double area = psum[idx];
    int width = widths[idx];
    int height = events[idx].y;

    double result = height + (totalArea - area * 2) / (width * 2.0);

    // 释放内存
    free(events);
    free(xs);
    free(psum);
    free(widths);
    freeSegmentTree(segTree);

    return result;
}
```

```JavaScript
class SegmentTree {
    constructor(xs) {
        this.xs = xs;  // sorted x coordinates
        this.n = xs.length - 1;
        this.count = new Array(4 * this.n).fill(0);
        this.covered = new Array(4 * this.n).fill(0);
    }

    update(qleft, qright, qval, left, right, pos) {
        if (this.xs[right + 1] <= qleft || this.xs[left] >= qright) {
            return;  // no overlap
        }
        if (qleft <= this.xs[left] && this.xs[right + 1] <= qright) {
            this.count[pos] += qval;
        } else {
            const mid = Math.floor((left + right) / 2);
            this.update(qleft, qright, qval, left, mid, pos * 2 + 1);
            this.update(qleft, qright, qval, mid + 1, right, pos * 2 + 2);
        }

        if (this.count[pos] > 0) {
            this.covered[pos] = this.xs[right + 1] - this.xs[left];
        } else {
            if (left === right) {
                this.covered[pos] = 0;
            } else {
                this.covered[pos] = this.covered[pos * 2 + 1] + this.covered[pos * 2 + 2];
            }
        }
    }

    query() {
        return this.covered[0];
    }
}


var separateSquares = function(squares) {
    // 存储事件: [y坐标, 类型, 左边界, 右边界]
    const events = [];
    const xsSet = new Set();

    for (const sq of squares) {
        const [x, y, l] = sq;
        const xr = x + l;
        events.push([y, 1, x, xr]);
        events.push([y + l, -1, x, xr]);
        xsSet.add(x);
        xsSet.add(xr);
    }

    // 按y坐标排序事件
    events.sort((a, b) => a[0] - b[0]);
    // 离散化坐标
    const xs = Array.from(xsSet).sort((a, b) => a - b);
    // 初始化线段树
    const segTree = new SegmentTree(xs);

    const psum = [];
    const widths = [];
    let total_area = 0;
    let prev = events[0][0];

    // 扫描：计算总面积和记录中间状态
    for (const event of events) {
        const [y, delta, xl, xr] = event;
        const length = segTree.query();
        total_area += length * (y - prev);
        segTree.update(xl, xr, delta, 0, segTree.n - 1, 0);
        // 记录前缀和和宽度
        psum.push(total_area);
        widths.push(segTree.query());
        prev = y;
    }

    // 计算目标面积（向上取整的一半）
    const target = Math.floor((total_area + 1) / 2);
    // 二分查找第一个大于等于target的位置
    let left = 0, right = psum.length - 1;
    let i = 0;
    while (left <= right) {
        const mid = Math.floor((left + right) / 2);
        if (psum[mid] < target) {
            i = mid;
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }

    // 获取对应的面积、宽度和高度
    const area = psum[i];
    const width = widths[i];
    const height = events[i][0];

    return height + (total_area - area * 2) / (width * 2.0);
};
```

```TypeScript
class SegmentTree {
    private count: number[];
    private covered: number[];
    private xs: number[];
    private n: number;

    constructor(xs: number[]) {
        this.xs = xs;  // sorted x coordinates
        this.n = xs.length - 1;
        this.count = new Array(4 * this.n).fill(0);
        this.covered = new Array(4 * this.n).fill(0);
    }

    private modify(qleft: number, qright: number, qval: number,
                  left: number, right: number, pos: number): void {
        if (this.xs[right + 1] <= qleft || this.xs[left] >= qright) {
            return;  // no overlap
        }
        if (qleft <= this.xs[left] && this.xs[right + 1] <= qright) {
            this.count[pos] += qval;
        } else {
            const mid = Math.floor((left + right) / 2);
            this.modify(qleft, qright, qval, left, mid, pos * 2 + 1);
            this.modify(qleft, qright, qval, mid + 1, right, pos * 2 + 2);
        }

        if (this.count[pos] > 0) {
            this.covered[pos] = this.xs[right + 1] - this.xs[left];
        } else {
            if (left === right) {
                this.covered[pos] = 0;
            } else {
                this.covered[pos] = this.covered[pos * 2 + 1] + this.covered[pos * 2 + 2];
            }
        }
    }

    public update(qleft: number, qright: number, qval: number): void {
        this.modify(qleft, qright, qval, 0, this.n - 1, 0);
    }

    public query(): number {
        return this.covered[0];
    }
}

function separateSquares(squares: number[][]): number {
    // 存储事件: [y坐标, 类型, 左边界, 右边界]
    const events: [number, number, number, number][] = [];
    const xsSet = new Set<number>();

    for (const sq of squares) {
        const [x, y, l] = sq;
        const xr = x + l;
        events.push([y, 1, x, xr]);
        events.push([y + l, -1, x, xr]);
        xsSet.add(x);
        xsSet.add(xr);
    }

    // 按y坐标排序事件
    events.sort((a, b) => a[0] - b[0]);
    // 离散化坐标
    const xs = Array.from(xsSet).sort((a, b) => a - b);
    // 初始化线段树
    const segTree = new SegmentTree(xs);

    const psum: number[] = [];
    const widths: number[] = [];
    let total_area = 0.0;
    let prev = events[0][0];

    // 扫描：计算总面积和记录中间状态
    for (const event of events) {
        const [y, delta, xl, xr] = event;
        const length = segTree.query();
        total_area += length * (y - prev);
        segTree.update(xl, xr, delta);
        // 记录前缀和和宽度
        psum.push(total_area);
        widths.push(segTree.query());
        prev = y;
    }

    // 计算目标面积（向上取整的一半）
    const target = Math.floor((total_area + 1) / 2);
    // 二分查找第一个大于等于target的位置
    let left = 0, right = psum.length - 1;
    let i = 0;
    while (left <= right) {
        const mid = Math.floor((left + right) / 2);
        if (psum[mid] < target) {
            i = mid;
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }

    // 获取对应的面积、宽度和高度
    const area = psum[i];
    const width = widths[i];
    const height = events[i][0];

    return height + (total_area - area * 2) / (width * 2.0);
}
```

```Rust
struct SegmentTree {
    count: Vec<i32>,
    covered: Vec<i32>,
    xs: Vec<i32>,
    n: usize,
}

impl SegmentTree {
    fn new(xs: Vec<i32>) -> Self {
        let n = xs.len() - 1;
        SegmentTree {
            count: vec![0; 4 * n],
            covered: vec![0; 4 * n],
            xs,
            n,
        }
    }

    fn modify(&mut self, qleft: i32, qright: i32, qval: i32,
              left: usize, right: usize, pos: usize) {
        if self.xs[right + 1] <= qleft || self.xs[left] >= qright {
            return;
        }
        if qleft <= self.xs[left] && self.xs[right + 1] <= qright {
            self.count[pos] += qval;
        } else {
            let mid = (left + right) / 2;
            self.modify(qleft, qright, qval, left, mid, pos * 2 + 1);
            self.modify(qleft, qright, qval, mid + 1, right, pos * 2 + 2);
        }

        if self.count[pos] > 0 {
            self.covered[pos] = self.xs[right + 1] - self.xs[left];
        } else {
            if left == right {
                self.covered[pos] = 0;
            } else {
                self.covered[pos] = self.covered[pos * 2 + 1] + self.covered[pos * 2 + 2];
            }
        }
    }

    fn update(&mut self, qleft: i32, qright: i32, qval: i32) {
        self.modify(qleft, qright, qval, 0, self.n - 1, 0);
    }

    fn query(&self) -> i32 {
        self.covered[0]
    }
}

impl Solution {
    pub fn separate_squares(squares: Vec<Vec<i32>>) -> f64 {
        // 存储事件: (y坐标, 类型, 左边界, 右边界)
        let mut events: Vec<(i32, i32, i32, i32)> = Vec::new();
        let mut xs_set = std::collections::BTreeSet::new();

        for sq in squares {
            let (x, y, l) = (sq[0], sq[1], sq[2]);
            let xr = x + l;
            events.push((y, 1, x, xr));
            events.push((y + l, -1, x, xr));
            xs_set.insert(x);
            xs_set.insert(xr);
        }

        // 按y坐标排序事件
        events.sort_by_key(|&(y, _, _, _)| y);
        // 离散化坐标
        let xs: Vec<i32> = xs_set.into_iter().collect();
        // 初始化线段树
        let mut seg_tree = SegmentTree::new(xs);

        let mut psum: Vec<i64> = Vec::new();
        let mut widths: Vec<i32> = Vec::new();
        let mut total_area = 0;
        let mut prev = events[0].0;

        // 扫描：计算总面积和记录中间状态
        for &(y, delta, xl, xr) in &events {
            let length = seg_tree.query();
            total_area += length as i64 * (y - prev) as i64;
            seg_tree.update(xl, xr, delta);
            // 记录前缀和和宽度
            psum.push(total_area);
            widths.push(seg_tree.query());
            prev = y;
        }

        // 计算目标面积（向上取整的一半）
        let target = ((total_area as f64 + 1.0) / 2.0).floor() as i64;
        // 二分查找第一个大于等于target的位置
        let i = {
            let mut left = 0;
            let mut right = psum.len().saturating_sub(1);
            let mut result = 0;

            while left <= right {
                let mid = left + (right - left) / 2;
                if psum[mid] < target {
                    result = mid;
                    left = mid + 1;
                } else {
                    right = mid.saturating_sub(1);
                }
            }
            result
        };

        // 获取对应的面积、宽度和高度
        let area = psum[i];
        let width = widths[i];
        let height = events[i].0;

        height as f64 + (total_area as f64 - area as f64 * 2.0) / (width as f64 * 2.0)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 是数组 $squares$ 的长度。排序的时间复杂度为 $O(n\log n)$，线段树每次更新和查询的时间复杂度均为 $O(\log n)$，一共需要 $n$ 次查询和更新，因此总的时间复杂度为 $O(n\log n)$。
- 空间复杂度：$O(n)$，其中 $n$ 是数组 $squares$ 的长度。线段树需要的空间为 $O(n)$。
