### [区间内查询数字的频率](https://leetcode.cn/problems/range-frequency-queries/solutions/1115337/qu-jian-nei-cha-xun-shu-zi-de-pin-lu-by-wh4ez/)

#### 方法一：哈希表 + 二分查找

**思路与算法**

我们假设数组 $arr$ 的长度为 $n$。对于单次查询，一种朴素的方法是遍历数组下标在闭区间 $[left,right]$ 内的所有数，维护目标数 $value$ 的出现次数，但这样的时间复杂度为 $O(n)$，假设查询总数为 $q$，则总时间复杂度为 $O(nq)$，这样的复杂度无法通过本题。因此我们需要优化单次查询的时间复杂度。

我们可以将单次查询分解为两个部分：

- 第一步，得到目标数 $value$ 在数组 $arr$ 中出现的所有下标；
- 第二步，在这些下标中计算位于闭区间 $[left,right]$ 的下标个数并返回。

对于第一步，由于在本题中数组 $arr$ 在生成后**不会发生改变**，因此我们可以预处理数组中每个数的出现下标，并对于每个数用相应**数组**维护。同时，为了优化查询每个数对应下标的时间复杂度，我们可以用数值为键，对应下标数组为值的**哈希表**来维护。这样，我们可以在 $RangeFreqQuery$ 类初始化时，以 $O(n)$ 的时间复杂度完成哈希表的初始化，并在每次查询时以 $O(1)$ 的时间复杂度查询到该数值对应的（如有）下标数组。

对于第二步，只要我们可以保证下标数组的**有序性**，就可以利用两次二分查找，$O(\log n)$ 的时间复杂度下计算出位于闭区间 $[left,right]$ 的下标个数。事实上，只需要我们在第一步中提到的初始化过程中，**顺序遍历**数组 $arr$，并始终将新的下标放入对应下标数组的末尾，那么哈希表中所有的下标数组都可以保证有序。

根据上文的分析，我们首先在 $RangeFreqQuery$ 类初始化时建立以数值为键，对应出现下标数组为值的哈希表 $occurence$，随后顺序遍历数组 $arr$，将数值与对应下标加入哈希表。具体地：

- 如果该数值不存在，我们在哈希表 $occurence$ 中建立该数值为键，空数组为值的键值对，并将当前下标加入该空数组末尾；
- 如果该数值存在，我们直接将当前下标加入该数值在 $occurence$ 中对应的下标数组的末尾。

处理每次查询时，我们首先检查目标数 $value$ 是否存在于哈希表中：如果不存在，则出现次数为 $0$；如果存在，则我们通过两次二分查找寻找到数组中**第一个大于等于** $left$ 的位置 $l$ 与**第一个大于** $right$ 的位置 $r$，此时 $r-l$ 即为符合要求的下标个数（子数组中目标数的出现次数），我们返回该数作为答案。

**代码**

```C++
class RangeFreqQuery {
private:
    // 数值为键，出现下标数组为值的哈希表
    unordered_map<int, vector<int>> occurence;

public:
    RangeFreqQuery(vector<int>& arr) {
        // 顺序遍历数组初始化哈希表
        int n = arr.size();
        for (int i = 0; i < n; ++i){
            occurence[arr[i]].push_back(i);
        }
    }

    int query(int left, int right, int value) {
        // 查找对应的出现下标数组，不存在则为空
        const vector<int>& pos = occurence[value];
        // 两次二分查找计算子数组内出现次数
        auto l = lower_bound(pos.begin(), pos.end(), left);
        auto r = upper_bound(pos.begin(), pos.end(), right);
        return r - l;
    }
};
```

```Python
class RangeFreqQuery:

    def __init__(self, arr: List[int]):
        # 数值为键，出现下标数组为值的哈希表
        self.occurence = defaultdict(list)
        # 顺序遍历数组初始化哈希表
        n = len(arr)
        for i in range(n):
            self.occurence[arr[i]].append(i)

    def query(self, left: int, right: int, value: int) -> int:
        # 查找对应的出现下标数组，不存在则为空
        pos = self.occurence[value]
        # 两次二分查找计算子数组内出现次数
        l = bisect_left(pos, left)
        r = bisect_right(pos, right)
        return r - l
```

```Java
class RangeFreqQuery {
    // 数值为键，出现下标数组为值的哈希表
    private Map<Integer, List<Integer>> occurrence;

    public RangeFreqQuery(int[] arr) {
        occurrence = new HashMap<>();
        // 顺序遍历数组初始化哈希表
        for (int i = 0; i < arr.length; ++i) {
            occurrence.putIfAbsent(arr[i], new ArrayList<>());
            occurrence.get(arr[i]).add(i);
        }
    }

    public int query(int left, int right, int value) {
        // 查找对应的出现下标数组，不存在则为空
        List<Integer> pos = occurrence.getOrDefault(value, new ArrayList<>());
        // 两次二分查找计算子数组内出现次数
        int l = lowerBound(pos, left);
        int r = upperBound(pos, right);
        return r - l;
    }

    private int lowerBound(List<Integer> pos, int target) {
        int low = 0, high = pos.size() - 1;
        while (low <= high) {
            int mid = low + (high - low) / 2;
            if (pos.get(mid) < target) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        return low;
    }

    private int upperBound(List<Integer> pos, int target) {
        int low = 0, high = pos.size() - 1;
        while (low <= high) {
            int mid = low + (high - low) / 2;
            if (pos.get(mid) <= target) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        return low;
    }
}
```

```CSharp
public class RangeFreqQuery {
    // 数值为键，出现下标数组为值的哈希表
    private Dictionary<int, List<int>> occurrence;

    public RangeFreqQuery(int[] arr) {
        occurrence = new Dictionary<int, List<int>>();
        // 顺序遍历数组初始化哈希表
        for (int i = 0; i < arr.Length; ++i) {
            if (!occurrence.ContainsKey(arr[i])) {
                occurrence[arr[i]] = new List<int>();
            }
            occurrence[arr[i]].Add(i);
        }
    }

    public int Query(int left, int right, int value) {
        // 查找对应的出现下标数组，不存在则为空
        if (!occurrence.TryGetValue(value, out var pos)) {
            pos = new List<int>();
        }
        // 两次二分查找计算子数组内出现次数
        int l = LowerBound(pos, left);
        int r = UpperBound(pos, right);
        return r - l;
    }

    private int LowerBound(List<int> pos, int target) {
        int low = 0, high = pos.Count - 1;
        while (low <= high) {
            int mid = low + (high - low) / 2;
            if (pos[mid] < target) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        return low;
    }

    private int UpperBound(List<int> pos, int target) {
        int low = 0, high = pos.Count - 1;
        while (low <= high) {
            int mid = low + (high - low) / 2;
            if (pos[mid] <= target) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        return low;
    }
}
```

```Go
type RangeFreqQuery struct {
    // 数值为键，出现下标数组为值的哈希表
    occurrence map[int][]int
}


func Constructor(arr []int) RangeFreqQuery {
    occurrence := make(map[int][]int)
    // 顺序遍历数组初始化哈希表
    for i, v := range arr {
        occurrence[v] = append(occurrence[v], i)
    }
    return RangeFreqQuery{occurrence: occurrence}
}

func (this *RangeFreqQuery) Query(left int, right int, value int) int {
    // 查找对应的出现下标数组，不存在则为空
    pos, exists := this.occurrence[value]
    if !exists {
        return 0
    }
    // 两次二分查找计算子数组内出现次数
    l := lowerBound(pos, left)
    r := upperBound(pos, right)
    return r - l
}

func lowerBound(pos []int, target int) int {
    low, high := 0, len(pos)-1
    for low <= high {
        mid := low + (high-low)/2
        if pos[mid] < target {
            low = mid + 1
        } else {
            high = mid - 1
        }
    }
    return low
}

func upperBound(pos []int, target int) int {
    low, high := 0, len(pos)-1
    for low <= high {
        mid := low + (high-low)/2
        if pos[mid] <= target {
            low = mid + 1
        } else {
            high = mid - 1
        }
    }
    return low
}
```

```C
#define MIN_SIZE 64

typedef struct {
    int value;
    int *indices;
    int size;
    int capbility;
    UT_hash_handle hh;
} Occurrence;

typedef struct {
    Occurrence *occurrence_map;  // 哈希表
    int
} RangeFreqQuery;

// 查找下界
int lower_bound(int* arr, int size, int target) {
    int low = 0, high = size - 1;
    while (low <= high) {
        int mid = low + (high - low) / 2;
        if (arr[mid] < target) {
            low = mid + 1;
        } else {
            high = mid - 1;
        }
    }
    return low;
}

// 查找上界
int upper_bound(int* arr, int size, int target) {
    int low = 0, high = size - 1;
    while (low <= high) {
        int mid = low + (high - low) / 2;
        if (arr[mid] <= target) {
            low = mid + 1;
        } else {
            high = mid - 1;
        }
    }
    return low;
}

RangeFreqQuery* rangeFreqQueryCreate(int* arr, int arrSize) {
    RangeFreqQuery* query = (RangeFreqQuery*)malloc(sizeof(RangeFreqQuery));
    query->occurrence_map = NULL;

    // 顺序遍历数组初始化哈希表
    for (int i = 0; i < arrSize; ++i) {
        int value = arr[i];
        Occurrence *occ;
        // 查找是否已有该数字的条目
        HASH_FIND_INT(query->occurrence_map, &value, occ);
        if (!occ) {
            // 如果没有该条目，则创建一个新的
            occ = (Occurrence*)malloc(sizeof(Occurrence));
            occ->value = value;
            occ->size = 0;
            occ->capbility = MIN_SIZE;
            occ->indices = (int*)malloc(occ->capbility * sizeof(int));
            HASH_ADD_INT(query->occurrence_map, value, occ);
        }
        // 将当前的下标加入到对应数字的下标数组中
        if (occ->size >= occ->capbility) {
            occ->capbility *= 2;
            occ->indices = (int*)realloc(occ->indices, occ->capbility * sizeof(int));
        }
        occ->indices[occ->size] = i;
        occ->size++;
    }

    return query;
}

int rangeFreqQueryQuery(RangeFreqQuery* obj, int left, int right, int value) {
    Occurrence* occ;
    HASH_FIND_INT(obj->occurrence_map, &value, occ);
    if (!occ || occ->size == 0) {
        return 0;  // 没有该值
    }

    // 两次二分查找计算子数组内出现次数
    int l = lower_bound(occ->indices, occ->size, left);
    int r = upper_bound(occ->indices, occ->size, right);
    return r - l;
}

void rangeFreqQueryFree(RangeFreqQuery* obj) {
    Occurrence *current, *tmp;
    HASH_ITER(hh, obj->occurrence_map, current, tmp) {
        free(current->indices);
        HASH_DEL(obj->occurrence_map, current);
        free(current);
    }
    free(obj);
}
```

```JavaScript
var RangeFreqQuery = function(arr) {
    // 数值为键，出现下标数组为值的哈希表
    this.occurrence = {};
    // 顺序遍历数组初始化哈希表
    for (let i = 0; i < arr.length; ++i) {
        if (!this.occurrence[arr[i]]) {
            this.occurrence[arr[i]] = [];
        }
        this.occurrence[arr[i]].push(i);
    }
};

RangeFreqQuery.prototype.query = function(left, right, value) {
    // 查找对应的出现下标数组，不存在则为空
    const pos = this.occurrence[value] || [];
    // 两次二分查找计算子数组内出现次数
    const l = lowerBound(pos, left);
    const r = upperBound(pos, right);
    return r - l;
};

const lowerBound = (pos, target) => {
    let low = 0, high = pos.length - 1;
    while (low <= high) {
        const mid = low + Math.floor((high - low) / 2);
        if (pos[mid] < target) {
            low = mid + 1;
        } else {
            high = mid - 1;
        }
    }
    return low;
}

const upperBound = (pos, target) => {
    let low = 0, high = pos.length - 1;
    while (low <= high) {
        const mid = low + Math.floor((high - low) / 2);
        if (pos[mid] <= target) {
            low = mid + 1;
        } else {
            high = mid - 1;
        }
    }
    return low;
}
```

```TypeScript
class RangeFreqQuery {
    // 数值为键，出现下标数组为值的哈希表
    private occurrence: { [key: number]: number[] };

    constructor(arr: number[]) {
        this.occurrence = {};
        // 顺序遍历数组初始化哈希表
        for (let i = 0; i < arr.length; ++i) {
            if (!this.occurrence[arr[i]]) {
                this.occurrence[arr[i]] = [];
            }
            this.occurrence[arr[i]].push(i);
        }
    }

    query(left: number, right: number, value: number): number {
        // 查找对应的出现下标数组，不存在则为空
        const pos = this.occurrence[value] || [];
        // 两次二分查找计算子数组内出现次数
        const l = this.lowerBound(pos, left);
        const r = this.upperBound(pos, right);
        return r - l;
    }

    private lowerBound(pos: number[], target: number): number {
        let low = 0, high = pos.length - 1;
        while (low <= high) {
            const mid = low + Math.floor((high - low) / 2);
            if (pos[mid] < target) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        return low;
    }

    private upperBound(pos: number[], target: number): number {
        let low = 0, high = pos.length - 1;
        while (low <= high) {
            const mid = low + Math.floor((high - low) / 2);
            if (pos[mid] <= target) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        return low;
    }
}
```

```Rust
use std::collections::HashMap;

struct RangeFreqQuery {
    // 数值为键，出现下标数组为值的哈希表
    occurrence: HashMap<i32, Vec<usize>>,
}

impl RangeFreqQuery {

    fn new(arr: Vec<i32>) -> Self {
        let mut occurrence = HashMap::new();
        // 顺序遍历数组初始化哈希表
        for (i, &num) in arr.iter().enumerate() {
            occurrence.entry(num).or_insert_with(Vec::new).push(i);
        }
        RangeFreqQuery { occurrence }
    }

    fn query(&self, left: i32, right: i32, value: i32) -> i32 {
        // 查找对应的出现下标数组，不存在则为空
        if let Some(pos) = self.occurrence.get(&value) {
            // 两次二分查找计算子数组内出现次数
            let l = self.lower_bound(pos, left as usize);
            let r = self.upper_bound(pos, right as usize);
            return (r - l) as i32;
        }
        0
    }

    // 查找下界
    fn lower_bound(&self, pos: &Vec<usize>, target: usize) -> usize {
        let mut low = 0 as i32;
        let mut high = pos.len() as i32 - 1;
        while low <= high {
            let mid = low + (high - low) as i32 / 2;
            if pos[mid as usize] < target {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        low as usize
    }

    // 查找上界
    fn upper_bound(&self, pos: &Vec<usize>, target: usize) -> usize {
        let mut low = 0;
        let mut high = pos.len() as i32 - 1;
        while low <= high {
            let mid = low + (high - low) as i32 / 2;
            if pos[mid as usize] <= target {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        low as usize
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+q \log n)$，其中 $n$ 为 $arr$ 的长度，$q$ 为调用 $query$ 的次数。初始化哈希表的时间复杂度为 $O(n)$，每次查询的时间复杂度为 $O(logn)$。
- 空间复杂度：$O(n)$，即为哈希表的空间开销。
