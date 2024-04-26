### [快照数组](https://leetcode.cn/problems/snapshot-array/solutions/2751969/kuai-zhao-shu-zu-by-leetcode-solution-x2j0/)

#### 方法一：二分查找

##### 思路与算法

我们对数组中的每个位置 $i$ 维护一个数组 $\textit{data}[i]$，其中存储了若干二元组，按照时间顺序记录了每一次对位置 $i$ 的修改操作。

对于操作 $\text{set(i, val)}$，记当前的快照编号（这里指下一次调用 $\text{snap()}$ 操作会返回的编号）为 $\textit{snap}_\textit{cnt}$，那么我们在 $\textit{data}[i]$ 的末尾放入二元组 $(\textit{snap}_\textit{cnt}, \textit{val})$ 即可。

这样一来，对于 $\text{get(i, snap\_id)}$ 操作，我们就可以通过在 $\textit{data}[i]$ 上进行二分查找，得到第 $\textit{snap}_\textit{id}$ 个快照对应的值。具体地，对于 $\textit{data}[i]$ 中的二元组 $(\textit{snap}_\textit{cnt}, \textit{val})$，我们需要找到**最后一个出现的**，并且满足 $\textit{snap}_\textit{cnt} \leq \textit{snap}_\textit{id}$ 的二元组，此时它的 $\textit{val}$ 即为答案。如果不存在这样的二元组，说明在第 $\textit{snap}_\textit{id}$ 个快照时，它的值没有被修改过，此时答案为 $0$。

##### 细节

对于一些自带二分查找 API 的语言，它们一般会提供「查找第一个大于等于 $x$ 的元素」和「查找第一个严格大于 $x$ 的元素」这两种 API。对于本题而言，我们需要查找的是「最后一个小于等于 $(\textit{snap}_\textit{id}, +\infty)$ 的元素」，可以转化为查找「第一个严格大于 $(\textit{snap}_\textit{id} + 1, -\infty)$ 的元素」，就可以使用 API 方便地进行查找，它的上一个元素即为我们需要查找到的元素。

在本题中，快照的编号从 $0$ 开始，因此可以使用 $-1$ 替换上面的 $-\infty$。

##### 代码

```c++
class SnapshotArray {
public:
    SnapshotArray(int length): snap_cnt(0), data(length) {}
    
    void set(int index, int val) {
        data[index].emplace_back(snap_cnt, val);
    }
    
    int snap() {
        return snap_cnt++;
    }
    
    int get(int index, int snap_id) {
        auto x = upper_bound(data[index].begin(), data[index].end(), pair{snap_id + 1, -1});
        return x == data[index].begin() ? 0 : prev(x)->second;
    }

private:
    int snap_cnt;
    vector<vector<pair<int, int>>> data;
};
```

```java
class SnapshotArray {
    private int snap_cnt;
    private List<int[]>[] data;

    public SnapshotArray(int length) {
        snap_cnt = 0;
        data = new List[length];
        for (int i = 0; i < length; i++) {
            data[i] = new ArrayList<int[]>();
        }
    }

    public void set(int index, int val) {
        data[index].add(new int[]{snap_cnt, val});
    }

    public int snap() {
        return snap_cnt++;
    }

    public int get(int index, int snap_id) {
        int x = binarySearch(index, snap_id);
        return x == 0 ? 0 : data[index].get(x - 1)[1];
    }

    private int binarySearch(int index, int snap_id) {
        int low = 0, high = data[index].size();
        while (low < high) {
            int mid = low + (high - low) / 2;
            int[] pair = data[index].get(mid);
            if (pair[0] > snap_id + 1 || (pair[0] == snap_id + 1 && pair[1] >= 0)) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}
```

```csharp
public class SnapshotArray {
    private int snap_cnt;
    private IList<Tuple<int, int>>[] data;

    public SnapshotArray(int length) {
        snap_cnt = 0;
        data = new IList<Tuple<int, int>>[length];
        for (int i = 0; i < length; i++) {
            data[i] = new List<Tuple<int, int>>();
        }
    }

    public void Set(int index, int val) {
        data[index].Add(new Tuple<int, int>(snap_cnt, val));
    }

    public int Snap() {
        return snap_cnt++;
    }

    public int Get(int index, int snap_id) {
        int x = BinarySearch(index, snap_id);
        return x == 0 ? 0 : data[index][x - 1].Item2;
    }

    private int BinarySearch(int index, int snap_id) {
        int low = 0, high = data[index].Count;
        while (low < high) {
            int mid = low + (high - low) / 2;
            Tuple<int, int> pair = data[index][mid];
            if (pair.Item1 > snap_id + 1 || (pair.Item1 == snap_id + 1 && pair.Item2 >= 0)) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}
```

```python
class SnapshotArray:
    def __init__(self, length: int):
        self.snap_cnt = 0
        self.data = [[] for _ in range(length)]

    def set(self, index: int, val: int) -> None:
        self.data[index].append((self.snap_cnt, val))

    def snap(self) -> int:
        ans = self.snap_cnt
        self.snap_cnt += 1
        return ans

    def get(self, index: int, snap_id: int) -> int:
        x = bisect_right(self.data[index], (snap_id + 1, -1))
        return 0 if x == 0 else self.data[index][x - 1][1]
```

```go
type SnapshotArray struct {
    snapCnt int
    data [][][2]int
}

func Constructor(length int) SnapshotArray {
    return SnapshotArray {
        snapCnt: 0,
        data: make([][][2]int, length),
    }
}

func (this *SnapshotArray) Set(index int, val int)  {
    this.data[index] = append(this.data[index], [2]int{this.snapCnt, val})
}

func (this *SnapshotArray) Snap() int {
    this.snapCnt++
    return this.snapCnt - 1
}

func (this *SnapshotArray) Get(index int, snapId int) int {
    x := sort.Search(len(this.data[index]), func(i int) bool {
        return this.data[index][i][0] > snapId
    })
    if x == 0 {
        return 0
    }
    return this.data[index][x - 1][1]
}
```

```c
typedef struct {
    int first;
    int second;
} Element;

typedef struct {
    int snap_cnt;
    int length;
    int *colSize;
    int *capability;
    Element **data;
} SnapshotArray;

#define MIN_ARRAY_SIZE 64

SnapshotArray* snapshotArrayCreate(int length) {
    SnapshotArray *obj = (SnapshotArray *)malloc(sizeof(SnapshotArray));
    obj->snap_cnt = 0;
    obj->length = length;
    obj->data = (Element **)malloc(sizeof(Element *) * length);
    obj->colSize = (int *)malloc(sizeof(int) * length);
    obj->capability = (int *)malloc(sizeof(int) * length);
    for (int i = 0; i < length; i++) {
        obj->data[i] = NULL;
        obj->colSize[i] = 0;
        obj->capability[i] = MIN_ARRAY_SIZE;
    }
    return obj;
}

void snapshotArraySet(SnapshotArray* obj, int index, int val) {
    if (obj->colSize[index] == 0) {
        obj->data[index] = (Element *)malloc(sizeof(Element) * obj->capability[index]);
    } else if (obj->colSize[index] == obj->capability[index]) {
        obj->capability[index] *= 2;
        Element *arr = (Element *)malloc(sizeof(Element) * obj->capability[index]);
        memcpy(arr, obj->data[index], sizeof(Element) * obj->colSize[index]);
        free(obj->data[index]);
        obj->data[index] = arr;
    }
    obj->data[index][obj->colSize[index]].first = obj->snap_cnt;
    obj->data[index][obj->colSize[index]].second = val;
    obj->colSize[index]++;
}

int snapshotArraySnap(SnapshotArray* obj) {
    return obj->snap_cnt++;
}

int binarySearch(int index, int snap_id, SnapshotArray* obj) {
    int low = 0, high = obj->colSize[index];
    while (low < high) {
        int mid = low + (high - low) / 2;
        int x = obj->data[index][mid].first;
        int y = obj->data[index][mid].second;
        if (x > snap_id + 1 || (x == snap_id + 1 && y >= 0)) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}

int snapshotArrayGet(SnapshotArray* obj, int index, int snap_id) {
    int x = binarySearch(index, snap_id, obj);
    return x == 0 ? 0 : obj->data[index][x - 1].second;
}

void snapshotArrayFree(SnapshotArray* obj) {
    for (int i = 0; i < obj->length; i++) {
        free(obj->data[i]);
    }
    free(obj->data);
    free(obj->colSize);
    free(obj->capability);
    free(obj);
}
```

```javascript
var SnapshotArray = function(length) {
    this.snap_cnt = 0;
    this.data = Array.from({length}, () => []);
};

SnapshotArray.prototype.set = function(index, val) {
    this.data[index].push([this.snap_cnt, val]);
};

SnapshotArray.prototype.snap = function() {
    return this.snap_cnt++;
};

SnapshotArray.prototype.get = function(index, snap_id) {
    const idx = binarySearch(index, snap_id, this.data);
    if (idx === 0) {
        return 0;
    }
    return this.data[index][idx - 1][1];
};

const binarySearch = (index, snap_id, data) => {
    let low = 0, high = data[index].length;
    while (low < high) {
        const mid = low + Math.floor((high - low) / 2);
        const [x, y] = data[index][mid];
        if (x > snap_id + 1 || (x == snap_id + 1 && y >= 0)) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}
```

```typescript
class SnapshotArray {
    private snap_cnt: number;
    private data: number[][][];

    constructor(length: number) {
        this.snap_cnt = 0;
        this.data = Array.from({length}, () => []);
    }

    set(index: number, val: number): void {
        this.data[index].push([this.snap_cnt, val]);
    }

    snap(): number {
        return this.snap_cnt++;
    }

    get(index: number, snap_id: number): number {
        const idx = this.binarySearch(index, snap_id);
        if (idx === 0) {
            return 0;
        }
        return this.data[index][idx - 1][1];
    }

    private binarySearch(index: number, snap_id: number): number {
        let low = 0, high = this.data[index].length;
        while (low < high) {
            const mid = low + Math.floor((high - low) / 2);
            const [x, y] = this.data[index][mid];
            if (x > snap_id + 1 || (x === snap_id + 1 && y >= 0)) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}
```

```rust
struct SnapshotArray {
    snap_cnt: i32,
    data: Vec<Vec<(i32, i32)>>,
}

impl SnapshotArray {
    fn new(length: i32) -> Self {
        SnapshotArray {
            snap_cnt: 0,
            data: vec![vec![]; length as usize],
        }
    }
    
    fn set(&mut self, index: i32, val: i32) {
        self.data[index as usize].push((self.snap_cnt, val));
    }
    
    fn snap(&mut self) -> i32 {
        let ans = self.snap_cnt;
        self.snap_cnt += 1;
        ans
    }
    
    fn get(&self, index: i32, snap_id: i32) -> i32 {
        let idx = self.binary_search(index, snap_id);
        if idx == 0 {
            return 0;
        }
        self.data[index as usize][idx - 1].1
    }

    fn binary_search(&self, index: i32, snap_id: i32) -> usize {
        let mut low = 0;
        let mut high = self.data[index as usize].len();
        while low < high {
            let mid = low + ((high - low) / 2);
            let (x, y) = self.data[index as usize][mid];
            if x > snap_id + 1 || (x == snap_id + 1 && y >= 0) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        low
    }
}
```

##### 复杂度分析

- 时间复杂度：
  - $\text{SnapshotArray(length)}$ 的时间复杂度为 $O(\textit{length})$。我们需要 $O(\textit{length})$ 初始化数组 $\textit{data}$。
  - $\text{set(index, val)}$ 的时间复杂度为 $O(1)$。
  - $\text{snap()}$ 的时间复杂度为 $O(1)$。
  - $\text{get(index, snap\_id)}$ 的时间复杂度为 $O(\log S)$，其中 $S$ 是调用 $\text{set(index, val)}$ 的次数。在最坏情况下，所有的 $\text{set(index, val)}$ 操作作用在同一个位置，那么对该位置进行二分查找需要的时间为 $O(\log S)$。
- 空间复杂度：$O(S)$，即为数组 $\textit{data}$ 需要使用的空间。此外，所有非初始化的操作均只需要 $O(1)$ 额外空间。
