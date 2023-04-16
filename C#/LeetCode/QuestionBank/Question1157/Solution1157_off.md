#### [方法一：随机化 + 二分查找](https://leetcode.cn/problems/online-majority-element-in-subarray/solutions/2228536/zi-shu-zu-zhong-zhan-jue-da-duo-shu-de-y-k1we/)

**思路与算法**

根据题目的要求，每次询问给定的 $threshold$ 的 $2$ 倍一定严格大于给定区间的长度。因此，我们实际上要找出的是区间的「绝对众数」：即出现次数严格超过区间长度一半的数，并判断该「绝对众数」的出现次数是否至少为 $threshold$。

若区间的「绝对众数」存在，记为 $x$，那么当我们在区间中「随机」选择一个数时，会有至少 $\dfrac{1}{2}$ 的概率选到 $x$。如果我们进行 $k$ 次选择，那么一次都没有选到 $x$ 的概率不会超过 $\left( \dfrac{1}{2} \right)^k$。当 $k$ 的值较大时，例如 $k=20$，$\left( \dfrac{1}{2} \right)^k$ 的数量级在 $10^{-6}$ 左右，我们可以认为 $k$ 次选择中几乎不可能没有选择到 $x$。

当我们选择到一个数 $x'$ 时，我们如何统计它在区间中出现的次数呢？我们可以使用预处理 + 二分查找的方法。我们使用一个哈希表来存储每个数出现的位置，对于哈希表中的每个键值对 $(key, value)$，$key$ 表示一个数，$value$ 是一个数组，按照递增的顺序存储了 $key$ 在数组 $arr$ 中每一次出现的位置。这样一来，我们在哈希表中以 $x'$ 为键得到的数组上，分别二分查找 $left$ 和 $right + 1$，得到的两个下标之间包含的元素个数，就是子区间 $[left, right]$ 中包含 $x'$ 的个数。

我们将「个数」记为 $occ$：

-   如果 $occ \geq threshold$，那么我们就找到了答案 $x'$；
-   如果 $occ < threshold$ 但 $occ$ 至少为区间长度的一半，那么说明 $occ$：
    -   是「绝对众数」，但它出现的次数不够多。由于「绝对众数」只能有一个，因此一定不存在满足要求的元素；
    -   恰好出现了区间长度一半的次数，那么其它的数最多也只会出现区间长度一半的次数，也不够多，因此也不存在满足要求的元素。
-   如果 $occ$ 小于区间长度的一半，那么我们再随机选择一个数并进行二分查找。

当 $k$ 次随机选择都完成，但我们仍然没有找到答案时，就可以认为不存在这样的元素。

**随机化正确性分析**

记询问的次数为 $q$，假设询问之间是独立的，那么我们最后给出的所有答案均正确的概率为：

$$\left( 1 - \left( \frac{1}{2} \right)^k \right)^q \sim 1 - q \cdot \left( \frac{1}{2} \right)^k$$

当 $k=20$，$q = 10^4$ 时，正确的概率约为 $1 - 10^4 \times 10^{-6} = 99\%$，已经是一个非常优秀的随机化算法。如果读者觉得这个概率仍然不够高，可以取 $k=30$，这样正确的概率约为 $1 - 10^4 \times 10^{-9} = 99.999\%$。

**代码**

```cpp
class MajorityChecker {
public:
    MajorityChecker(vector<int>& arr): arr(arr) {
        for (int i = 0; i < arr.size(); ++i) {
            loc[arr[i]].push_back(i);
        }
    }
    
    int query(int left, int right, int threshold) {
        int length = right - left + 1;
        uniform_int_distribution<int> dis(left, right);

        for (int i = 0; i < k; ++i) {
            int x = arr[dis(gen)];
            vector<int>& pos = loc[x];
            int occ = upper_bound(pos.begin(), pos.end(), right) - lower_bound(pos.begin(), pos.end(), left);
            if (occ >= threshold) {
                return x;
            }
            else if (occ * 2 >= length) {
                return -1;
            }
        }

        return -1;
    }

private:
    static constexpr int k = 20;

    const vector<int>& arr;
    unordered_map<int, vector<int>> loc;
    mt19937 gen{random_device{}()};
};
```

```java
class MajorityChecker {
    public static final int K = 20;
    private int[] arr;
    private Map<Integer, List<Integer>> loc;
    private Random random;

    public MajorityChecker(int[] arr) {
        this.arr = arr;
        this.loc = new HashMap<Integer, List<Integer>>();
        for (int i = 0; i < arr.length; ++i) {
            loc.putIfAbsent(arr[i], new ArrayList<Integer>());
            loc.get(arr[i]).add(i);
        }
        this.random = new Random();
    }

    public int query(int left, int right, int threshold) {
        int length = right - left + 1;

        for (int i = 0; i < K; ++i) {
            int x = arr[left + random.nextInt(length)];
            List<Integer> pos = loc.get(x);
            int occ = searchEnd(pos, right) - searchStart(pos, left);
            if (occ >= threshold) {
                return x;
            } else if (occ * 2 >= length) {
                return -1;
            }
        }

        return -1;
    }

    private int searchStart(List<Integer> pos, int target) {
        int low = 0, high = pos.size();
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (pos.get(mid) >= target) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }

    private int searchEnd(List<Integer> pos, int target) {
        int low = 0, high = pos.size();
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (pos.get(mid) > target) {
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
public class MajorityChecker {
    public const int K = 20;
    private int[] arr;
    private IDictionary<int, IList<int>> loc;
    private Random random;

    public MajorityChecker(int[] arr) {
        this.arr = arr;
        this.loc = new Dictionary<int, IList<int>>();
        for (int i = 0; i < arr.Length; ++i) {
            loc.TryAdd(arr[i], new List<int>());
            loc[arr[i]].Add(i);
        }
        this.random = new Random();
    }

    public int Query(int left, int right, int threshold) {
        int length = right - left + 1;

        for (int i = 0; i < K; ++i) {
            int x = arr[left + random.Next(length)];
            IList<int> pos = loc[x];
            int occ = SearchEnd(pos, right) - SearchStart(pos, left);
            if (occ >= threshold) {
                return x;
            } else if (occ * 2 >= length) {
                return -1;
            }
        }

        return -1;
    }

    private int SearchStart(IList<int> pos, int target) {
        int low = 0, high = pos.Count;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (pos[mid] >= target) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }

    private int SearchEnd(IList<int> pos, int target) {
        int low = 0, high = pos.Count;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (pos[mid] > target) {
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
class MajorityChecker:
    k = 20

    def __init__(self, arr: List[int]):
        self.arr = arr
        self.loc = defaultdict(list)

        for i, val in enumerate(arr):
            self.loc[val].append(i)

    def query(self, left: int, right: int, threshold: int) -> int:
        arr_ = self.arr
        loc_ = self.loc
        
        length = right - left + 1
        for i in range(MajorityChecker.k):
            x = arr_[randint(left, right)]
            pos = loc_[x]
            occ = bisect_right(pos, right) - bisect_left(pos, left)
            if occ >= threshold:
                return x
            elif occ * 2 >= length:
                return -1

        return -1
```

```go
type MajorityChecker struct {
    arr []int
    loc map[int][]int
}

func Constructor(arr []int) MajorityChecker {
    rand.Seed(time.Now().UnixNano())
    loc := map[int][]int{}
    for i, x := range arr {
        loc[x] = append(loc[x], i)
    }
    return MajorityChecker{arr, loc}
}

func (mc *MajorityChecker) Query(left, right, threshold int) int {
    length := right - left + 1
    for i := 0; i < 20; i++ {
        x := mc.arr[rand.Intn(right-left+1)+left]
        pos := mc.loc[x]
        occ := sort.SearchInts(pos, right+1) - sort.SearchInts(pos, left)
        if occ >= threshold {
            return x
        }
        if occ*2 >= length {
            break
        }
    }
    return -1
}
```

```c
typedef struct Element {
    int *arr;
    int arrSize;
} Element;

typedef struct {
    int key;
    Element *val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

const int k = 20;

bool hashAddItem(HashItem **obj, int key, Element *val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

Element* hashGetItem(HashItem **obj, int key) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return NULL;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr->val->arr);
        free(curr->val);
        free(curr);             
    }
}

typedef struct {
    int *arr;
    int arrSize;
    HashItem *loc;
} MajorityChecker;

static int cmp(const void *pa, const void *pb) {
    int *a = (int *)pa;
    int *b = (int *)pb;
    return a[0] - b[0];
}

int searchStart(const int *pos, int posSize, int target) {
    int low = 0, high = posSize;
    while (low < high) {
        int mid = low + (high - low) / 2;
        if (pos[mid] >= target) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}

int searchEnd(const int *pos, int posSize, int target) {
    int low = 0, high = posSize;
    while (low < high) {
        int mid = low + (high - low) / 2;
        if (pos[mid] > target) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}

MajorityChecker* majorityCheckerCreate(int* arr, int arrSize) {
    MajorityChecker *obj = (MajorityChecker *)malloc(sizeof(MajorityChecker));
    obj->arr = arr;
    obj->arrSize = arrSize;
    obj->loc = NULL;
    int cnt[arrSize][2];
    for (int i = 0; i < arrSize; i++) {
        cnt[i][0] = arr[i];
        cnt[i][1] = i;
    }
    qsort(cnt, arrSize, sizeof(cnt[0]), cmp);
    for (int i = 0, j = 0; i <= arrSize; i++) {
        if (i == arrSize || cnt[i][0] != cnt[j][0]) {
            Element *cur = (Element *)malloc(sizeof(Element));
            cur->arr = (int *)malloc(sizeof(int) * (i - j));
            cur->arrSize = i - j;
            for (int k = 0; k < i - j; k++) {
                cur->arr[k] = cnt[j + k][1];
            }            
            hashAddItem(&obj->loc, cnt[j][0], cur);
            j = i;
        }
    }
    return obj;
}

int majorityCheckerQuery(MajorityChecker* obj, int left, int right, int threshold) {
    int length = right - left + 1;
    srand(time(NULL));

    for (int i = 0; i < k; ++i) {
        int x = obj->arr[rand() % length + left];
        Element *cur = hashGetItem(&obj->loc, x);
        int *pos = cur->arr;
        int posSize = cur->arrSize;
        int occ = searchEnd(pos, posSize, right) - searchStart(pos, posSize, left);
        if (occ >= threshold) {
            return x;
        } else if (occ * 2 >= length) {
            return -1;
        }
    }
    return -1;
}

void majorityCheckerFree(MajorityChecker* obj) {
    hashFree(&obj->loc);
    free(obj);
}
```

```javascript
const K = 20;
var MajorityChecker = function(arr) {
    this.arr = arr;
    this.loc = new Map();
    for (let i = 0; i < arr.length; ++i) {
        if (!this.loc.has(arr[i])) {
            this.loc.set(arr[i], []);
        }
        this.loc.get(arr[i]).push(i);
    }
};

MajorityChecker.prototype.query = function(left, right, threshold) {
    const length = right - left + 1;
    for (let i = 0; i < K; ++i) {
        const x = this.arr[left + Math.floor(Math.random() * length)];
        const pos = this.loc.get(x);
        const occ = searchEnd(pos, right) - searchStart(pos, left);
        if (occ >= threshold) {
            return x;
        } else if (occ * 2 >= length) {
            return -1;
        }
    }

    return -1;
};

const searchStart = (pos, target) => {
    let low = 0, high = pos.length;
    while (low < high) {
        const mid = low + Math.floor((high - low) / 2);
        if (pos[mid] >= target) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}

const searchEnd = (pos, target) => {
    let low = 0, high = pos.length;
    while (low < high) {
        const mid = low + Math.floor((high - low) / 2);
        if (pos[mid] > target) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}
```

**复杂度分析**

-   时间复杂度：$O(n + kq\log n)$，其中 $n$ 是数组 $arr$ 的长度，$q$ 是询问的次数，$k$ 是每次询问随机选择的次数。预处理哈希表需要 $O(n)$ 的时间，单次询问需要 $O(k \log n)$ 的时间。
-   空间复杂度：$O(n)$，即为哈希表需要使用的空间。
