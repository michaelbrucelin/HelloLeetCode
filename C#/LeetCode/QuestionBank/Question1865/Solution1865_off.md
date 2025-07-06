### [找出和为指定值的下标对](https://leetcode.cn/problems/finding-pairs-with-a-certain-sum/solutions/779095/zhao-chu-he-wei-zhi-ding-zhi-de-xia-biao-m17s/)

#### 方法一：哈希表

**提示 1**

由于数组 $nums_1$ 的最大长度小于等于 $nums_2$，因此对于 $getPairs(tot)$ 操作，我们可以将 $nums_2$ 中的元素放入哈希映射中，枚举 $nums_1$ 中的元素 $num$，从而在哈希映射中找出键 $tot-num$ 对应的值。这些值的总和即为答案。

**思路与算法**

我们将数组 $num_1$ 和 $nums_2$ 存储下来，并且额外存储一份数组 $nums_2$ 中元素的哈希映射 $cnt$。

对于 $add(index, val)$ 操作，我们将 $cnt[nums_2[index]]$ 减去 $1$，$nums_2[index]$ 加上 $val$，再将更新后的 $cnt[nums_2[index]]$ 加上 $1$。

对于 $getPairs(tot)$ 操作，我们枚举 $nums_1$ 中的元素 $num$，将答案累加 $cnt[tot-num]$，并返回最终的答案。

**代码**

```C++
class FindSumPairs {
private:
    vector<int> nums1, nums2;
    unordered_map<int, int> cnt;

public:
    FindSumPairs(vector<int>& nums1, vector<int>& nums2) {
        this->nums1 = nums1;
        this->nums2 = nums2;
        for (int num: nums2) {
            ++cnt[num];
        }
    }
    
    void add(int index, int val) {
        --cnt[nums2[index]];
        nums2[index] += val;
        ++cnt[nums2[index]];
    }
    
    int count(int tot) {
        int ans = 0;
        for (int num: nums1) {
            int rest = tot - num;
            if (cnt.count(rest)) {
                ans += cnt[rest];
            }
        }
        return ans;
    }
};
```

```Python
class FindSumPairs:

    def __init__(self, nums1: List[int], nums2: List[int]):
        self.nums1 = nums1
        self.nums2 = nums2
        self.cnt = Counter(nums2)

    def add(self, index: int, val: int) -> None:
        _nums2, _cnt = self.nums2, self.cnt

        _cnt[_nums2[index]] -= 1
        _nums2[index] += val
        _cnt[_nums2[index]] += 1

    def count(self, tot: int) -> int:
        _nums1, _cnt = self.nums1, self.cnt

        ans = 0
        for num in _nums1:
            if (rest := tot - num) in _cnt:
                ans += _cnt[rest]
        return ans
```

```Java
class FindSumPairs {
    private int[] nums1;
    private int[] nums2;
    private Map<Integer, Integer> cnt;

    public FindSumPairs(int[] nums1, int[] nums2) {
        this.nums1 = nums1;
        this.nums2 = nums2;
        this.cnt = new HashMap<>();
        for (int num : nums2) {
            cnt.put(num, cnt.getOrDefault(num, 0) + 1);
        }
    }
    
    public void add(int index, int val) {
        int oldVal = nums2[index];
        cnt.put(oldVal, cnt.get(oldVal) - 1);
        nums2[index] += val;
        cnt.put(nums2[index], cnt.getOrDefault(nums2[index], 0) + 1);
    }
    
    public int count(int tot) {
        int ans = 0;
        for (int num : nums1) {
            int rest = tot - num;
            ans += cnt.getOrDefault(rest, 0);
        }
        return ans;
    }
}
```

```CSharp
public class FindSumPairs {
    private int[] nums1;
    private int[] nums2;
    private Dictionary<int, int> cnt;

    public FindSumPairs(int[] nums1, int[] nums2) {
        this.nums1 = nums1;
        this.nums2 = nums2;
        this.cnt = new Dictionary<int, int>();
        foreach (int num in nums2) {
            if (cnt.ContainsKey(num)) {
                cnt[num]++;
            } else {
                cnt[num] = 1;
            }
        }
    }
    
    public void Add(int index, int val) {
        int oldVal = nums2[index];
        cnt[oldVal]--;
        nums2[index] += val;
        if (cnt.ContainsKey(nums2[index])) {
            cnt[nums2[index]]++;
        } else {
            cnt[nums2[index]] = 1;
        }
    }
    
    public int Count(int tot) {
        int ans = 0;
        foreach (int num in nums1) {
            int rest = tot - num;
            if (cnt.ContainsKey(rest)) {
                ans += cnt[rest];
            }
        }
        return ans;
    }
}
```

```Go
type FindSumPairs struct {
    nums1 []int
    nums2 []int
    cnt   map[int]int
}

func Constructor(nums1 []int, nums2 []int) FindSumPairs {
    cnt := make(map[int]int)
    for _, num := range nums2 {
        cnt[num]++
    }
    return FindSumPairs{
        nums1: nums1,
        nums2: nums2,
        cnt:   cnt,
    }
}

func (this *FindSumPairs) Add(index int, val int) {
    oldVal := this.nums2[index]
    this.cnt[oldVal]--
    this.nums2[index] += val
    this.cnt[this.nums2[index]]++
}

func (this *FindSumPairs) Count(tot int) int {
    ans := 0
    for _, num := range this.nums1 {
        rest := tot - num
        ans += this.cnt[rest]
    }
    return ans
}
```

```C
typedef struct {
    int key;
    int val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetItem(HashItem **obj, int key, int defaultVal) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

typedef struct {
    int *nums1, *nums2;
    int nums1Size, nums2Size;
    HashItem *cnt;
} FindSumPairs;


FindSumPairs* findSumPairsCreate(int* nums1, int nums1Size, int* nums2, int nums2Size) {
    FindSumPairs *obj = (FindSumPairs *)malloc(sizeof(FindSumPairs));
    obj->nums1 = nums1;
    obj->nums1Size = nums1Size;
    obj->nums2 = nums2;
    obj->nums2Size = nums2Size;
    obj->cnt = NULL;
    for (int i = 0; i < nums2Size; i++) {
        hashSetItem(&obj->cnt, nums2[i], hashGetItem(&obj->cnt, nums2[i], 0) + 1);
    }
    return obj;
}

void findSumPairsAdd(FindSumPairs* obj, int index, int val) {
    hashSetItem(&obj->cnt, obj->nums2[index], hashGetItem(&obj->cnt, obj->nums2[index], 0) - 1);
    obj->nums2[index] += val;
    hashSetItem(&obj->cnt, obj->nums2[index], hashGetItem(&obj->cnt, obj->nums2[index], 0) + 1);
}

int findSumPairsCount(FindSumPairs* obj, int tot) {
    int ans = 0;
    for (int i = 0; i < obj->nums1Size; i++) {
        int rest = tot - obj->nums1[i];
        if (hashFindItem(&obj->cnt, rest)) {
            ans += hashGetItem(&obj->cnt, rest, 0);
        }
    }
    return ans;
}

void findSumPairsFree(FindSumPairs* obj) {
    hashFree(&obj->cnt);
    free(obj);
}
```

```JavaScript
var FindSumPairs = function(nums1, nums2) {
    this.nums1 = nums1;
    this.nums2 = nums2;
    this.cnt = new Map();
    for (const num of nums2) {
        this.cnt.set(num, (this.cnt.get(num) || 0) + 1);
    }
};

FindSumPairs.prototype.add = function(index, val) {
    const oldVal = this.nums2[index];
    this.cnt.set(oldVal, (this.cnt.get(oldVal) || 0) - 1);
    this.nums2[index] += val;
    const newVal = this.nums2[index];
    this.cnt.set(newVal, (this.cnt.get(newVal) || 0) + 1);
};

FindSumPairs.prototype.count = function(tot) {
    let ans = 0;
    for (const num of this.nums1) {
        const rest = tot - num;
        ans += this.cnt.get(rest) || 0;
    }
    return ans;
};
```

```TypeScript
class FindSumPairs {
    private nums1: number[];
    private nums2: number[];
    private cnt: Map<number, number>;

    constructor(nums1: number[], nums2: number[]) {
        this.nums1 = nums1;
        this.nums2 = nums2;
        this.cnt = new Map();
        for (const num of nums2) {
            this.cnt.set(num, (this.cnt.get(num) || 0) + 1);
        }
    }

    add(index: number, val: number): void {
        const oldVal = this.nums2[index];
        this.cnt.set(oldVal, (this.cnt.get(oldVal) || 0) - 1);
        this.nums2[index] += val;
        const newVal = this.nums2[index];
        this.cnt.set(newVal, (this.cnt.get(newVal) || 0) + 1);
    }

    count(tot: number): number {
        let ans = 0;
        for (const num of this.nums1) {
            const rest = tot - num;
            ans += this.cnt.get(rest) || 0;
        }
        return ans;
    }
}
```

```Rust
use std::collections::HashMap;

struct FindSumPairs {
    nums1: Vec<i32>,
    nums2: Vec<i32>,
    cnt: HashMap<i32, i32>,
}

impl FindSumPairs {
    fn new(nums1: Vec<i32>, nums2: Vec<i32>) -> Self {
        let mut cnt = HashMap::new();
        for &num in &nums2 {
            *cnt.entry(num).or_insert(0) += 1;
        }
        FindSumPairs { nums1, nums2, cnt }
    }
    
    fn add(&mut self, index: i32, val: i32) {
        let index = index as usize;
        let old_val = self.nums2[index];
        *self.cnt.entry(old_val).or_insert(0) -= 1;
        self.nums2[index] += val;
        *self.cnt.entry(self.nums2[index]).or_insert(0) += 1;
    }
    
    fn count(&self, tot: i32) -> i32 {
        let mut ans = 0;
        for &num in &self.nums1 {
            let rest = tot - num;
            ans += self.cnt.get(&rest).unwrap_or(&0);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+q_1+(q_2+1)m)$，其中 $n$ 和 $m$ 分别是数组 $nums_1$ 和 $nums_2$ 的长度，$q_1$ 和 $q_2$ 分别是 $add(index, val)$ 和 $getPairs(tot)$ 操作的次数。
    - 初始化需要的时间为 $O(n+m)$；
    - 单次 $add(index, val)$ 操作需要的时间为 $O(1)$；
    - 单次 $getPairs(tot)$ 操作需要的时间为 $O(m)$。
    将它们分别乘以操作次数再相加即可得到总时间复杂度。
- 空间复杂度：$O(n+m+q_1)$。数组 $nums_1$ 和 $nums_2$ 分别需要 $O(n)$ 和 $O(m)$ 的空间，哈希映射初始时需要 $O(m)$ 的空间，每一次 $add(index, val)$ 操作需要额外的 $O(1)$ 空间。
    这里也可以选择在 $add(index, val)$ 操作时将值减为 $0$ 的键值对删除，使得哈希映射的空间恒定为 $O(m)$ 而与 $q_1$ 无关。
