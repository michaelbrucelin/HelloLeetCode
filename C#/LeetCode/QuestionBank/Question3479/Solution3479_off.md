### [水果成篮 III](https://leetcode.cn/problems/fruits-into-baskets-iii/solutions/3737092/shui-guo-cheng-lan-iii-by-leetcode-solut-zlvd/)

#### 方法一：分块

**思路及解法**

本题与 [3477\. 水果成篮 II](https://leetcode.cn/problems/fruits-into-baskets-ii/description/) 类似，区别在于本题数据量更大，因此需要使用分块的方法进行优化。

主要思想为：

将 $baskets$ 数组以 $n=m$ 的大小进行分块，其中 $n$ 为 $baskets$ 数组的长度，$m$ 为分块的大小。

然后维护块上的最大值 $maxV$，表示当前块中最大的篮子容量。

我们枚举 $fruits$ 中的每一种水果，然后遍历每个块，会出现以下两种情况：

1. 遍历到某个块的时候，当前块的最大值 $maxV$ 小于当前水果的容量，那么说明当前块中没有容量大于当前水果数量的篮子，继续遍历下一个块。
2. 遍历到某个块的时候，当前块的最大值 $maxV$ 大于等于当前水果的容量，那么说明当前块中存在容量大于等于当前水果数量的篮子。此时从左到右遍历当前块中的每个篮子，如果当前篮子容量大于等于当前水果数量，那么将当前篮子容量置为 $0$，标记为已被该种水果占用，后续无法再使用。

如果遍历完所有块后，仍然没有找到容量大于等于当前水果数量的篮子，那么计数器 $count$ 加一。

**代码**

```C++
class Solution {
public:
    int numOfUnplacedFruits(vector<int>& fruits, vector<int>& baskets) {
        int n = baskets.size();
        int m = sqrt(n);
        int section = (n + m - 1) / m;
        int count = 0;
        vector<int> maxV(section);
        for (int i = 0; i < n; i++) {
            maxV[i / m] = max(maxV[i / m], baskets[i]);
        }
        for (int fruit : fruits) {
            int sec;
            int unset = 1;
            for (sec = 0; sec < section; sec++) {
                if (maxV[sec] < fruit) {
                    continue;
                }
                int choose = 0;
                maxV[sec] = 0;
                for (int i = 0; i < m; i++) {
                    int pos = sec * m + i;
                    if (pos < n && baskets[pos] >= fruit && !choose) {
                        baskets[pos] = 0;
                        choose = 1;
                    }
                    if (pos < n) {
                        maxV[sec] = max(maxV[sec], baskets[pos]);
                    }
                }
                unset = 0;
                break;
            }
            count += unset;
        }
        return count;
    }
};
```

```Java
class Solution {
    public int numOfUnplacedFruits(int[] fruits, int[] baskets) {
        int n = baskets.length;
        int m = (int) Math.sqrt(n);
        int section = (n + m - 1) / m;
        int count = 0;
        int[] maxV = new int[section];
        Arrays.fill(maxV, 0);

        for (int i = 0; i < n; i++) {
            maxV[i / m] = Math.max(maxV[i / m], baskets[i]);
        }

        for (int fruit : fruits) {
            int sec;
            int unset = 1;
            for (sec = 0; sec < section; sec++) {
                if (maxV[sec] < fruit) {
                    continue;
                }
                int choose = 0;
                maxV[sec] = 0;
                for (int i = 0; i < m; i++) {
                    int pos = sec * m + i;
                    if (pos < n && baskets[pos] >= fruit && choose == 0) {
                        baskets[pos] = 0;
                        choose = 1;
                    }
                    if (pos < n) {
                        maxV[sec] = Math.max(maxV[sec], baskets[pos]);
                    }
                }
                unset = 0;
                break;
            }
            count += unset;
        }
        return count;
    }
}
```

```CSharp
public class Solution {
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets) {
        int n = baskets.Length;
        int m = (int)Math.Sqrt(n);
        int section = (n + m - 1) / m;
        int count = 0;
        int[] maxV = new int[section];
        Array.Fill(maxV, 0);

        for (int i = 0; i < n; i++) {
            maxV[i / m] = Math.Max(maxV[i / m], baskets[i]);
        }

        foreach (int fruit in fruits) {
            int unset = 1;
            for (int sec = 0; sec < section; sec++) {
                if (maxV[sec] < fruit) {
                    continue;
                }
                int choose = 0;
                maxV[sec] = 0;
                for (int i = 0; i < m; i++) {
                    int pos = sec * m + i;
                    if (pos < n && baskets[pos] >= fruit && choose == 0) {
                        baskets[pos] = 0;
                        choose = 1;
                    }
                    if (pos < n) {
                        maxV[sec] = Math.Max(maxV[sec], baskets[pos]);
                    }
                }
                unset = 0;
                break;
            }
            count += unset;
        }
        return count;
    }
}
```

```Go
func numOfUnplacedFruits(fruits []int, baskets []int) int {
    n := len(baskets)
    m := int(math.Sqrt(float64(n)))
    section := (n + m - 1) / m
    count := 0
    maxV := make([]int, section)

    for i := 0; i < n; i++ {
        sec := i / m
        maxV[sec] = max(maxV[sec], baskets[i])
    }

    for _, fruit := range fruits {
        unset := 1
        for sec := 0; sec < section; sec++ {
            if maxV[sec] < fruit {
                continue
            }
            choose := 0
            maxV[sec] = 0
            for i := 0; i < m; i++ {
                pos := sec * m + i
                if pos < n && baskets[pos] >= fruit && choose == 0 {
                    baskets[pos] = 0
                    choose = 1
                }
                if pos < n {
                    maxV[sec] = max(maxV[sec], baskets[pos]);
                }
            }
            unset = 0
            break
        }
        count += unset
    }
    return count
}
```

```Python
class Solution:
    def numOfUnplacedFruits(self, fruits: List[int], baskets: List[int]) -> int:
        n = len(baskets)
        m = int(math.sqrt(n))
        section = (n + m - 1) // m
        count = 0
        maxV = [0] * section

        for i in range(n):
            maxV[i // m] = max(maxV[i // m], baskets[i])

        for fruit in fruits:
            unset = 1
            for sec in range(section):
                if maxV[sec] < fruit:
                    continue
                choose = 0
                maxV[sec] = 0
                for i in range(m):
                    pos = sec * m + i
                    if pos < n and baskets[pos] >= fruit and not choose:
                        baskets[pos] = 0
                        choose = 1
                    if pos < n:
                        maxV[sec] = max(maxV[sec], baskets[pos])
                unset = 0
                break
            count += unset
        return count
```

```C
int numOfUnplacedFruits(int* fruits, int fruitsSize, int* baskets, int basketsSize) {
    int n = basketsSize;
    int m = (int)sqrt(n);
    int section = (n + m - 1) / m;
    int count = 0;
    int* maxV = (int*)calloc(section, sizeof(int));

    for (int i = 0; i < n; i++) {
        int block = i / m;
        maxV[block] = maxV[block] > baskets[i] ? maxV[block] : baskets[i];
    }

    for (int j = 0; j < fruitsSize; j++) {
        int fruit = fruits[j];
        int unset = 1;
        for (int sec = 0; sec < section; sec++) {
            if (maxV[sec] < fruit) {
                continue;
            }
            int choose = 0;
            maxV[sec] = 0;
            for (int i = 0; i < m; i++) {
                int pos = sec * m + i;
                if (pos < n && baskets[pos] >= fruit && !choose) {
                    baskets[pos] = 0;
                    choose = 1;
                }
                if (pos < n) {
                    maxV[sec] = maxV[sec] > baskets[pos] ? maxV[sec] : baskets[pos];
                }
            }
            unset = 0;
            break;
        }
        count += unset;
    }

    free(maxV);
    return count;
}
```

```JavaScript
var numOfUnplacedFruits = function(fruits, baskets) {
    const n = baskets.length;
    const m = Math.floor(Math.sqrt(n));
    const section = Math.ceil(n / m);
    let count = 0;
    const maxV = new Array(section).fill(0);

    for (let i = 0; i < n; i++) {
        const sec = Math.floor(i / m);
        maxV[sec] = Math.max(maxV[sec], baskets[i]);
    }

    for (const fruit of fruits) {
        let unset = 1;
        for (let sec = 0; sec < section; sec++) {
            if (maxV[sec] < fruit) {
                continue;
            }
            let choose = 0;
            maxV[sec] = 0;
            for (let i = 0; i < m; i++) {
                const pos = sec * m + i;
                if (pos < n && baskets[pos] >= fruit && !choose) {
                    baskets[pos] = 0;
                    choose = 1;
                }
                if (pos < n) {
                    maxV[sec] = Math.max(maxV[sec], baskets[pos]);
                }
            }
            unset = 0;
            break;
        }
        count += unset;
    }
    return count;
}
```

```TypeScript
function numOfUnplacedFruits(fruits: number[], baskets: number[]): number {
    const n = baskets.length;
    const m = Math.floor(Math.sqrt(n));
    const section = Math.ceil(n / m);
    let count = 0;
    const maxV: number[] = new Array(section).fill(0);

    for (let i = 0; i < n; i++) {
        const sec = Math.floor(i / m);
        maxV[sec] = Math.max(maxV[sec], baskets[i]);
    }

    for (const fruit of fruits) {
        let unset = 1;
        for (let sec = 0; sec < section; sec++) {
            if (maxV[sec] < fruit) {
                continue;
            }
            let choose = 0;
            maxV[sec] = 0;
            for (let i = 0; i < m; i++) {
                const pos = sec * m + i;
                if (pos < n && baskets[pos] >= fruit && !choose) {
                    baskets[pos] = 0;
                    choose = 1;
                }
                if (pos < n) {
                    maxV[sec] = Math.max(maxV[sec], baskets[pos]);
                }
            }
            unset = 0;
            break;
        }
        count += unset;
    }
    return count;
}
```

```Rust
use std::cmp::max;

impl Solution {
    pub fn num_of_unplaced_fruits(fruits: Vec<i32>, baskets: Vec<i32>) -> i32 {
        let n = baskets.len();
        let mut baskets = baskets;
        let m = (n as f64).sqrt() as usize;
        let section = (n + m - 1) / m;
        let mut count = 0;
        let mut max_v = vec![0; section];

        for i in 0..n {
            let sec = i / m;
            max_v[sec] = max(max_v[sec], baskets[i])
        }

        for &fruit in &fruits {
            let mut unset = 1;
            for sec in 0..section {
                if max_v[sec] < fruit {
                    continue;
                }

                let mut choose = false;
                max_v[sec] = 0;
                for i in 0..m {
                    let pos = sec * m + i;
                    if pos < n && baskets[pos] >= fruit && !choose {
                        baskets[pos] = 0;
                        choose = true;
                    }
                    if pos < n {
                        max_v[sec] = max(max_v[sec], baskets[pos]);
                    }
                }
                unset = 0;
                break;
            }
            count += unset;
        }
        count
    }
}
```


**复杂度分析**

- 时间复杂度：$O(n\times n)=O(n^{\frac{3}{2}})$，其中 $n$ 是数组 $baskets$ 的长度，枚举 $fruits$ 中的水果需要 $O(n)$ 的时间复杂度，遍历每个块需要 $O(n)$ 的时间复杂度。
- 空间复杂度：$O(n)$，其中 $n$ 是数组 $baskets$ 的长度，维护每个块中篮子容量的最大值。

#### 方法二：线段树 $+$ 二分

**思路及解法**

本题是一道线段树的模板题，我们可以使用线段树维护 $baskets$ 数组的区间最大值，然后使用二分查找找到第一个满足条件的篮子，具体做法如下：

1. 首先建树，初始化时维护的内容为区间最大值。
2. 然后枚举 $fruits$ 中的水果，在二分查找过程中使用线段树查找区间最大值来找到第一个满足条件的篮子，如果找到，使用线段树单点修改该篮子的值，将这个篮子置为 $0$，否则计数器 $count$ 加一。
3. 二分的过程为；如果左区间最大值大于当前水果数量，则在左区间继续二分；如果左区间最大值小于当前水果数量，且右区间最大值大于等于当前水果数量，则在右区间继续二分；否则，当前区间没有满足条件的篮子。

**代码**

```C++
class Solution {
public:
    int segTree[400007];
    vector<int> baskets;

    void build(int p, int l, int r) {
        if (l == r) {
            segTree[p] = baskets[l];
            return;
        }
        int mid = (l + r) >> 1;
        build(p << 1, l, mid);
        build(p << 1 | 1, mid + 1, r);
        segTree[p] = max(segTree[p << 1], segTree[p << 1 | 1]);
    }

    int query(int p, int l, int r, int ql, int qr) {
        if (ql > r || qr < l) {
            return INT_MIN;
        }
        if (ql <= l && r <= qr) {
            return segTree[p];
        }
        int mid = (l + r) >> 1;
        return max(query(p << 1, l, mid, ql, qr),
                   query(p << 1 | 1, mid + 1, r, ql, qr));
    }

    void update(int p, int l, int r, int pos, int val) {
        if (l == r) {
            segTree[p] = val;
            return;
        }
        int mid = (l + r) >> 1;
        if (pos <= mid) {
            update(p << 1, l, mid, pos, val);
        } else {
            update(p << 1 | 1, mid + 1, r, pos, val);
        }
        segTree[p] = max(segTree[p << 1], segTree[p << 1 | 1]);
    }

    int numOfUnplacedFruits(vector<int>& fruits, vector<int>& baskets) {
        this->baskets = baskets;
        int m = baskets.size();
        int count = 0;
        if (m == 0) {
            return fruits.size();
        }
        build(1, 0, m - 1);
        for (int i = 0; i < m; i++) {
            int l = 0, r = m - 1, res = -1;
            while (l <= r) {
                int mid = (l + r) >> 1;
                if (query(1, 0, m - 1, 0, mid) >= fruits[i]) {
                    res = mid;
                    r = mid - 1;
                } else {
                    l = mid + 1;
                }
            }
            if (res != -1 && baskets[res] >= fruits[i]) {
                update(1, 0, m - 1, res, INT_MIN);
            } else {
                count++;
            }
        }
        return count;
    }
};
```

```Java
class Solution {
    private int[] segTree = new int[400007];
    private int[] baskets;

    private void build(int p, int l, int r) {
        if (l == r) {
            segTree[p] = baskets[l];
            return;
        }
        int mid = (l + r) >> 1;
        build(p << 1, l, mid);
        build(p << 1 | 1, mid + 1, r);
        segTree[p] = Math.max(segTree[p << 1], segTree[p << 1 | 1]);
    }

    private int query(int p, int l, int r, int ql, int qr) {
        if (ql > r || qr < l) {
            return Integer.MIN_VALUE;
        }
        if (ql <= l && r <= qr) {
            return segTree[p];
        }
        int mid = (l + r) >> 1;
        return Math.max(query(p << 1, l, mid, ql, qr),
                       query(p << 1 | 1, mid + 1, r, ql, qr));
    }

    private void update(int p, int l, int r, int pos, int val) {
        if (l == r) {
            segTree[p] = val;
            return;
        }
        int mid = (l + r) >> 1;
        if (pos <= mid) {
            update(p << 1, l, mid, pos, val);
        } else {
            update(p << 1 | 1, mid + 1, r, pos, val);
        }
        segTree[p] = Math.max(segTree[p << 1], segTree[p << 1 | 1]);
    }

    public int numOfUnplacedFruits(int[] fruits, int[] baskets) {
        this.baskets = baskets;
        int m = baskets.length;
        int count = 0;
        if (m == 0) {
            return fruits.length;
        }
        Arrays.fill(segTree, Integer.MIN_VALUE);
        build(1, 0, m - 1);
        for (int i = 0; i < fruits.length; i++) {
            int l = 0, r = m - 1, res = -1;
            while (l <= r) {
                int mid = (l + r) >> 1;
                if (query(1, 0, m - 1, 0, mid) >= fruits[i]) {
                    res = mid;
                    r = mid - 1;
                } else {
                    l = mid + 1;
                }
            }
            if (res != -1 && baskets[res] >= fruits[i]) {
                update(1, 0, m - 1, res, Integer.MIN_VALUE);
            } else {
                count++;
            }
        }
        return count;
    }
}
```

```CSharp
public class Solution {
    private int[] segTree = new int[400007];
    private int[] baskets;

    private void Build(int p, int l, int r) {
        if (l == r) {
            segTree[p] = baskets[l];
            return;
        }
        int mid = (l + r) >> 1;
        Build(p << 1, l, mid);
        Build(p << 1 | 1, mid + 1, r);
        segTree[p] = Math.Max(segTree[p << 1], segTree[p << 1 | 1]);
    }

    private int Query(int p, int l, int r, int ql, int qr) {
        if (ql > r || qr < l) {
            return int.MinValue;
        }
        if (ql <= l && r <= qr) {
            return segTree[p];
        }
        int mid = (l + r) >> 1;
        return Math.Max(Query(p << 1, l, mid, ql, qr),
                       Query(p << 1 | 1, mid + 1, r, ql, qr));
    }

    private void Update(int p, int l, int r, int pos, int val) {
        if (l == r) {
            segTree[p] = val;
            return;
        }
        int mid = (l + r) >> 1;
        if (pos <= mid) {
            Update(p << 1, l, mid, pos, val);
        } else {
            Update(p << 1 | 1, mid + 1, r, pos, val);
        }
        segTree[p] = Math.Max(segTree[p << 1], segTree[p << 1 | 1]);
    }

    public int NumOfUnplacedFruits(int[] fruits, int[] baskets) {
        this.baskets = baskets;
        int m = baskets.Length;
        int count = 0;
        if (m == 0) {
            return fruits.Length;
        }
        Array.Fill(segTree, int.MinValue);
        Build(1, 0, m - 1);
        for (int i = 0; i < fruits.Length; i++) {
            int l = 0, r = m - 1, res = -1;
            while (l <= r) {
                int mid = (l + r) >> 1;
                if (Query(1, 0, m - 1, 0, mid) >= fruits[i]) {
                    res = mid;
                    r = mid - 1;
                } else {
                    l = mid + 1;
                }
            }
            if (res != -1 && baskets[res] >= fruits[i]) {
                Update(1, 0, m - 1, res, int.MinValue);
            } else {
                count++;
            }
        }
        return count;
    }
}
```

```Go
const (
    INT_MIN = math.MinInt32
)

type SegTree struct {
    segNode []int
    baskets []int
}

func (this *SegTree) build(p, l, r int) {
    if l == r {
        this.segNode[p] = this.baskets[l]
        return
    }
    mid := (l + r) >> 1
    this.build(p << 1, l, mid)
    this.build(p << 1 | 1, mid + 1, r)
    this.segNode[p] = max(this.segNode[p << 1], this.segNode[p << 1 | 1])
}

func (this *SegTree) query(p, l, r, ql, qr int) int {
    if ql > r || qr < l {
        return INT_MIN
    }
    if ql <= l && r <= qr {
        return this.segNode[p]
    }
    mid := (l + r) >> 1
    return max(this.query(p << 1, l, mid, ql, qr),
        this.query(p << 1 | 1, mid + 1, r, ql, qr))
}

func (this *SegTree) update(p, l, r, pos, val int) {
    if l == r {
        this.segNode[p] = val
        return
    }
    mid := (l + r) >> 1
    if pos <= mid {
        this.update(p << 1, l, mid, pos, val)
    } else {
        this.update(p << 1 | 1, mid + 1, r, pos, val)
    }
    this.segNode[p] = max(this.segNode[p << 1], this.segNode[p << 1 | 1])
}

func numOfUnplacedFruits(fruits []int, baskets []int) int {
    m := len(baskets)
    if m == 0 {
        return len(fruits)
    }

    tree := SegTree{
        segNode: make([]int, 4 * m + 7),
        baskets: baskets,
    }
    tree.build(1, 0, m - 1)

    count := 0
    for i := 0; i < len(fruits); i++ {
        l, r, res := 0, m - 1, -1
        for l <= r {
            mid := (l + r) >> 1
            if tree.query(1, 0, m-1, 0, mid) >= fruits[i] {
                res = mid
                r = mid - 1
            } else {
                l = mid + 1
            }
        }
        if res != -1 && tree.baskets[res] >= fruits[i] {
            tree.update(1, 0, m - 1, res, INT_MIN)
        } else {
            count++
        }
    }

    return count
}
```

```Python
class SegTree:
    def __init__(self, baskets):
        self.n = len(baskets)
        size = 2 << (self.n - 1).bit_length()
        self.seg = [0] * size
        self._build(baskets, 1, 0, self.n - 1)

    def _maintain(self, o):
        self.seg[o] = max(self.seg[o * 2], self.seg[o * 2 + 1])

    def _build(self, a, o, l, r):
        if l == r:
            self.seg[o] = a[l]
            return
        m = (l + r) // 2
        self._build(a, o * 2, l, m)
        self._build(a, o * 2 + 1, m + 1, r)
        self._maintain(o)

    def find_first_and_update(self, o, l, r, x):
        if self.seg[o] < x:
            return -1
        if l == r:
            self.seg[o] = -1
            return l
        m = (l + r) // 2
        i = self.find_first_and_update(o * 2, l, m, x)
        if i == -1:
            i = self.find_first_and_update(o * 2 + 1, m + 1, r, x)
        self._maintain(o)
        return i


class Solution:
    def numOfUnplacedFruits(self, fruits: List[int], baskets: List[int]) -> int:
        m = len(baskets)
        if m == 0:
            return len(fruits)

        tree = SegTree(baskets)
        count = 0

        for fruit in fruits:
            if tree.find_first_and_update(1, 0, m - 1, fruit) == -1:
                count += 1

        return count
```

```C
#define MAX_SIZE 400007

int segTree[MAX_SIZE];
int* baskets;

int max(int a, int b) {
    return a > b ? a : b;
}

void build(int p, int l, int r) {
    if (l == r) {
        segTree[p] = baskets[l];
        return;
    }
    int mid = (l + r) >> 1;
    build(p << 1, l, mid);
    build(p << 1 | 1, mid + 1, r);
    segTree[p] = max(segTree[p << 1], segTree[p << 1 | 1]);
}

int query(int p, int l, int r, int ql, int qr) {
    if (ql > r || qr < l) {
        return INT_MIN;
    }
    if (ql <= l && r <= qr) {
        return segTree[p];
    }
    int mid = (l + r) >> 1;
    return max(query(p << 1, l, mid, ql, qr),
               query(p << 1 | 1, mid + 1, r, ql, qr));
}

void update(int p, int l, int r, int pos, int val) {
    if (l == r) {
        segTree[p] = val;
        return;
    }
    int mid = (l + r) >> 1;
    if (pos <= mid) {
        update(p << 1, l, mid, pos, val);
    } else {
        update(p << 1 | 1, mid + 1, r, pos, val);
    }
    segTree[p] = max(segTree[p << 1], segTree[p << 1 | 1]);
}

int numOfUnplacedFruits(int* fruits, int fruitsSize, int* basketsArr, int basketsSize) {
    baskets = basketsArr;
    int m = basketsSize;
    int count = 0;
    if (m == 0) {
        return fruitsSize;
    }
    for (int i = 0; i < MAX_SIZE; i++) {
        segTree[i] = INT_MIN;
    }
    build(1, 0, m - 1);
    for (int i = 0; i < fruitsSize; i++) {
        int l = 0, r = m - 1, res = -1;
        while (l <= r) {
            int mid = (l + r) >> 1;
            if (query(1, 0, m - 1, 0, mid) >= fruits[i]) {
                res = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        if (res != -1 && baskets[res] >= fruits[i]) {
            update(1, 0, m - 1, res, INT_MIN);
        } else {
            count++;
        }
    }
    return count;
}
```

```JavaScript
class SegTree {
    constructor(baskets) {
        this.baskets = baskets;
        this.n = baskets.length;
        this.segNode = new Array(4 * this.n).fill(0);
        this.build(1, 0, this.n - 1);
    }

    build(p, l, r) {
        if (l === r) {
            this.segNode[p] = this.baskets[l];
            return;
        }
        const mid = Math.floor((l + r) / 2);
        this.build(p * 2, l, mid);
        this.build(p * 2 + 1, mid + 1, r);
        this.segNode[p] = Math.max(this.segNode[p * 2], this.segNode[p * 2 + 1]);
    }

    query(p, l, r, ql, qr) {
        if (ql > r || qr < l) {
            return Number.MIN_SAFE_INTEGER;
        }
        if (ql <= l && r <= qr) {
            return this.segNode[p];
        }
        const mid = Math.floor((l + r) / 2);
        return Math.max(
            this.query(p * 2, l, mid, ql, qr),
            this.query(p * 2 + 1, mid + 1, r, ql, qr)
        );
    }

    update(p, l, r, pos, val) {
        if (l === r) {
            this.segNode[p] = val;
            return;
        }
        const mid = Math.floor((l + r) / 2);
        if (pos <= mid) {
            this.update(p * 2, l, mid, pos, val);
        } else {
            this.update(p * 2 + 1, mid + 1, r, pos, val);
        }
        this.segNode[p] = Math.max(this.segNode[p * 2], this.segNode[p * 2 + 1]);
    }
}

var numOfUnplacedFruits = function(fruits, baskets) {
    const m = baskets.length;
    if (m === 0) {
        return fruits.length;
    }
    const tree = new SegTree(baskets);
    let count = 0;

    for (const fruit of fruits) {
        let l = 0, r = m - 1, res = -1;
        while (l <= r) {
            const mid = Math.floor((l + r) / 2);
            if (tree.query(1, 0, m - 1, 0, mid) >= fruit) {
                res = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }

        if (res !== -1 && tree.baskets[res] >= fruit) {
            tree.update(1, 0, m - 1, res, Number.MIN_SAFE_INTEGER);
        } else {
            count++;
        }
    }

    return count;
}
```

```TypeScript
class SegTree {
    private segNode: number[];
    public baskets: number[];
    private n: number;

    constructor(baskets: number[]) {
        this.baskets = baskets;
        this.n = baskets.length;
        this.segNode = new Array(4 * this.n + 7).fill(0);
        this.build(1, 0, this.n - 1);
    }

    private build(p: number, l: number, r: number): void {
        if (l === r) {
            this.segNode[p] = this.baskets[l];
            return;
        }
        const mid = Math.floor((l + r) / 2);
        this.build(p * 2, l, mid);
        this.build(p * 2 + 1, mid + 1, r);
        this.segNode[p] = Math.max(this.segNode[p * 2], this.segNode[p * 2 + 1]);
    }

    query(p: number, l: number, r: number, ql: number, qr: number): number {
        if (ql > r || qr < l) {
            return Number.MIN_SAFE_INTEGER;
        }
        if (ql <= l && r <= qr) {
            return this.segNode[p];
        }
        const mid = Math.floor((l + r) / 2);
        return Math.max(
            this.query(p * 2, l, mid, ql, qr),
            this.query(p * 2 + 1, mid + 1, r, ql, qr)
        );
    }

    update(p: number, l: number, r: number, pos: number, val: number): void {
        if (l === r) {
            this.segNode[p] = val;
            return;
        }
        const mid = Math.floor((l + r) / 2);
        if (pos <= mid) {
            this.update(p * 2, l, mid, pos, val);
        } else {
            this.update(p * 2 + 1, mid + 1, r, pos, val);
        }
        this.segNode[p] = Math.max(this.segNode[p * 2], this.segNode[p * 2 + 1]);
    }
}

function numOfUnplacedFruits(fruits: number[], baskets: number[]): number {
    const m = baskets.length;
    if (m === 0) {
        return fruits.length;
    }
    const tree = new SegTree(baskets);
    let count = 0;

    for (const fruit of fruits) {
        let l = 0, r = m - 1, res = -1;
        while (l <= r) {
            const mid = Math.floor((l + r) / 2);
            if (tree.query(1, 0, m - 1, 0, mid) >= fruit) {
                res = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }

        if (res !== -1 && tree.baskets[res] >= fruit) {
            tree.update(1, 0, m - 1, res, Number.MIN_SAFE_INTEGER);
        } else {
            count++;
        }
    }

    return count;
}
```

```Rust
struct SegTree {
    seg_node: Vec<i32>,
    baskets: Vec<i32>,
}

impl SegTree {
    fn new(baskets: Vec<i32>) -> Self {
        let n = baskets.len();
        let mut tree = SegTree {
            seg_node: vec![0; 4 * n + 7],
            baskets,
        };
        tree.build(1, 0, n - 1);
        tree
    }

    fn build(&mut self, p: usize, l: usize, r: usize) {
        if l == r {
            self.seg_node[p] = self.baskets[l];
            return;
        }
        let mid = (l + r) / 2;
        self.build(p * 2, l, mid);
        self.build(p * 2 + 1, mid + 1, r);
        self.seg_node[p] = self.seg_node[p * 2].max(self.seg_node[p * 2 + 1]);
    }

    fn query(&self, p: usize, l: usize, r: usize, ql: usize, qr: usize) -> i32 {
        if ql > r || qr < l {
            return i32::MIN;
        }
        if ql <= l && r <= qr {
            return self.seg_node[p];
        }
        let mid = (l + r) / 2;
        self.query(p * 2, l, mid, ql, qr)
            .max(self.query(p * 2 + 1, mid + 1, r, ql, qr))
    }

    fn update(&mut self, p: usize, l: usize, r: usize, pos: usize, val: i32) {
        if l == r {
            self.seg_node[p] = val;
            return;
        }
        let mid = (l + r) / 2;
        if pos <= mid {
            self.update(p * 2, l, mid, pos, val);
        } else {
            self.update(p * 2 + 1, mid + 1, r, pos, val);
        }
        self.seg_node[p] = self.seg_node[p * 2].max(self.seg_node[p * 2 + 1]);
    }
}

impl Solution {
    pub fn num_of_unplaced_fruits(fruits: Vec<i32>, baskets: Vec<i32>) -> i32 {
        let m = baskets.len();
        if m == 0 {
            return fruits.len() as i32;
        }

        let mut tree = SegTree::new(baskets);
        let mut count = 0;
        for fruit in fruits {
            let (mut l, mut r, mut res) = (0 as i32, (m - 1) as i32, None);
            while l <= r {
                let mid = (l + r) / 2;
                if tree.query(1, 0, m - 1, 0, mid as usize) >= fruit {
                    res = Some(mid);
                    r = mid - 1;
                } else {
                    l = mid + 1;
                }
            }

            if let Some(pos) = res {
                if tree.baskets[pos as usize] >= fruit {
                    tree.update(1, 0, m - 1, pos as usize, i32::MIN);
                    continue;
                }
            }
            count += 1;
        }

        count
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 是数组 $baskets$ 的长度，构造线段树的时间复杂度为 $O(n)$，枚举 $fruits$ 中的水果需要 $O(n)$ 的时间复杂度，二分查找和线段树查询以及修改需要 $O(\log n)$ 的时间复杂度。
- 空间复杂度：$O(n)$，其中 $n$ 是数组 $baskets$ 的长度，需要 $O(n)$ 的空间存储线段树。
