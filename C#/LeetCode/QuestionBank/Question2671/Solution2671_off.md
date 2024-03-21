### [频率跟踪器](https://leetcode.cn/problems/frequency-tracker/solutions/2679864/pin-lu-gen-zong-qi-by-leetcode-solution-3d04/)

#### 方法一：哈希表

##### 思路与算法

我们可以用一个哈希表 $\textit{freq}$ 来追踪每个 $\textit{number}$ 的出现频率，并利用另一个哈希表 $\textit{freq\_cnt}$ 来记录各个频率的出现次数。

对于元素 $\textit{number}$ 的添加或删除操作，流程如下：先调整 $\textit{freq}[\textit{number}]$ 在 $\textit{freq\_cnt}$ 中的计数（即先减少），随后更新 $\textit{freq}[\textit{number}]$（增加或减少其频率），最终在 $\textit{freq\_cnt}$ 中更新新的频率计数（即增加）。

在具体实现上，鉴于所有数值范围限定在 $10^5$ 以内，数组足以作为哈希表的有效替代，既简化了代码，也提高了效率。

##### 代码

```c++
class FrequencyTracker {
public:
    FrequencyTracker():freq(N), freq_cnt(N) {
        
    }

    void add(int number) {
        --freq_cnt[freq[number]];
        ++freq[number];
        ++freq_cnt[freq[number]];
    }
    
    void deleteOne(int number) {
        if (freq[number] == 0) {
            return;
        }
        --freq_cnt[freq[number]];
        --freq[number];
        ++freq_cnt[freq[number]];
    }
    
    bool hasFrequency(int frequency) {
        return freq_cnt[frequency];
    }

private:
    static constexpr int N = 100001;
    vector<int> freq;
    vector<int> freq_cnt;
};
```

```java
class FrequencyTracker {
    private static final int N = 100001;
    private int[] freq;
    private int[] freqCnt;

    public FrequencyTracker() {
        freq = new int[N];
        freqCnt = new int[N];
    }

    public void add(int number) {
        --freqCnt[freq[number]];
        ++freq[number];
        ++freqCnt[freq[number]];
    }

    public void deleteOne(int number) {
        if (freq[number] == 0) {
            return;
        }
        --freqCnt[freq[number]];
        --freq[number];
        ++freqCnt[freq[number]];
    }

    public boolean hasFrequency(int frequency) {
        return freqCnt[frequency] > 0;
    }
}
```

```csharp
public class FrequencyTracker {
    private const int N = 100001;
    private int[] freq;
    private int[] freqCnt;

    public FrequencyTracker() {
        freq = new int[N];
        freqCnt = new int[N];
    }

    public void Add(int number) {
        --freqCnt[freq[number]];
        ++freq[number];
        ++freqCnt[freq[number]];
    }

    public void DeleteOne(int number) {
        if (freq[number] == 0) {
            return;
        }
        --freqCnt[freq[number]];
        --freq[number];
        ++freqCnt[freq[number]];
    }

    public bool HasFrequency(int frequency) {
        return freqCnt[frequency] > 0;
    }
}
```

```c
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
    HashItem *freq;
    HashItem *freq_cnt;
} FrequencyTracker;


FrequencyTracker* frequencyTrackerCreate() {
    FrequencyTracker *obj = (FrequencyTracker *)malloc(sizeof(FrequencyTracker));
    obj->freq = NULL;
    obj->freq_cnt = NULL;
    return obj;
}

void frequencyTrackerAdd(FrequencyTracker* obj, int number) {
    int prev = hashGetItem(&obj->freq, number, 0);
    hashSetItem(&obj->freq_cnt, prev, hashGetItem(&obj->freq_cnt, prev, 0) - 1);
    hashSetItem(&obj->freq, number, prev + 1);
    hashSetItem(&obj->freq_cnt, prev + 1, hashGetItem(&obj->freq_cnt, prev + 1, 0) + 1);
}

void frequencyTrackerDeleteOne(FrequencyTracker* obj, int number) {
    int prev = hashGetItem(&obj->freq, number, 0);
    if (prev == 0) {
        return;
    }
    hashSetItem(&obj->freq_cnt, prev, hashGetItem(&obj->freq_cnt, prev, 0) - 1);
    hashSetItem(&obj->freq, number, prev - 1);
    hashSetItem(&obj->freq_cnt, prev - 1, hashGetItem(&obj->freq_cnt, prev - 1, 0) + 1);
}

bool frequencyTrackerHasFrequency(FrequencyTracker* obj, int frequency) {    
    return hashGetItem(&obj->freq_cnt, frequency, 0) > 0;
}

void frequencyTrackerFree(FrequencyTracker* obj) {
    hashFree(&obj->freq);
    hashFree(&obj->freq_cnt);
    free(obj);
}
```

```python
class FrequencyTracker:
    def __init__(self):
        self.freq = Counter()
        self.freq_cnt = Counter()

    def add(self, number: int) -> None:
        self.freq_cnt[self.freq[number]] -= 1
        self.freq[number] += 1
        self.freq_cnt[self.freq[number]] += 1

    def deleteOne(self, number: int) -> None:
        if self.freq[number] == 0:
            return
        self.freq_cnt[self.freq[number]] -= 1
        self.freq[number] -= 1
        self.freq_cnt[self.freq[number]] += 1

    def hasFrequency(self, frequency: int) -> bool:
        return self.freq_cnt[frequency] > 0
```

```go
type FrequencyTracker struct {
    freq map[int]int
    freq_cnt map[int]int
}

func Constructor() FrequencyTracker {
    return FrequencyTracker{map[int]int{}, map[int]int{}}
}

func (this *FrequencyTracker) Add(number int)  {
    (*this).freq_cnt[(*this).freq[number]]--
    (*this).freq[number]++
    (*this).freq_cnt[(*this).freq[number]]++
}

func (this *FrequencyTracker) DeleteOne(number int)  {
    if (*this).freq[number] == 0 {
        return
    }
    (*this).freq_cnt[(*this).freq[number]]--
    (*this).freq[number]--
    (*this).freq_cnt[(*this).freq[number]]++
}

func (this *FrequencyTracker) HasFrequency(frequency int) bool {
    return (*this).freq_cnt[frequency] > 0
}
```

```javascript
var FrequencyTracker = function() {
    this.freq = new Map();
    this.freq_cnt = new Map();
};

FrequencyTracker.prototype.add = function(number) {
    if (!this.freq.has(number)) {
        this.freq.set(number, 0);
        this.freq_cnt.set(0, (this.freq_cnt.get(0) || 0) + 1);
    }
    const prev = this.freq.get(number);
    this.freq_cnt.set(prev, (this.freq_cnt.get(prev) || 0) - 1);
    this.freq.set(number, prev + 1);
    this.freq_cnt.set(prev + 1, (this.freq_cnt.get(prev + 1) || 0) + 1);
};

FrequencyTracker.prototype.deleteOne = function(number) {
    if (!this.freq.has(number) || this.freq.get(number) === 0) {
        return;
    }
    let prev = this.freq.get(number);
    this.freq_cnt.set(prev, (this.freq_cnt.get(prev) || 0) - 1);
    this.freq.set(number, prev - 1);
    this.freq_cnt.set(prev - 1, (this.freq_cnt.get(prev - 1) || 0) + 1);
};

FrequencyTracker.prototype.hasFrequency = function(frequency) {
    return this.freq_cnt.get(frequency) > 0;
};
```

```typescript
class FrequencyTracker {
    private freq: Map<number, number>;
    private freq_cnt: Map<number, number>;

    constructor() {
        this.freq = new Map<number, number>();
        this.freq_cnt = new Map<number, number>();
    }

    add(number: number): void {
        if (!this.freq.has(number)) {
            this.freq.set(number, 0);
            this.freq_cnt.set(0, (this.freq_cnt.get(0) || 0) + 1);
        }
        const prev = this.freq.get(number)!;
        this.freq_cnt.set(prev, (this.freq_cnt.get(prev) || 0) - 1);
        this.freq.set(number, prev + 1);
        this.freq_cnt.set(prev + 1, (this.freq_cnt.get(prev + 1) || 0) + 1);
    }

    deleteOne(number: number): void {
        if (!this.freq.has(number) || this.freq.get(number)! === 0) {
            return;
        }
        const prev = this.freq.get(number)!;
        this.freq_cnt.set(prev, (this.freq_cnt.get(prev) || 0) - 1);
        this.freq.set(number, prev - 1);
        this.freq_cnt.set(prev - 1, (this.freq_cnt.get(prev - 1) || 0) + 1);
    }

    hasFrequency(frequency: number): boolean {
        return (this.freq_cnt.get(frequency) || 0) > 0;
    }
}
```

```rust
use std::collections::HashMap;

struct FrequencyTracker {
    freq: HashMap<i32, i32>,
    freq_cnt: HashMap<i32, i32>,
}

impl FrequencyTracker {
    fn new() -> Self {
        FrequencyTracker {
            freq: HashMap::new(),
            freq_cnt: HashMap::new(),
        }
    }
    
    fn add(&mut self, number: i32) {
        let prev = *self.freq.get(&number).unwrap_or(&0);
        *self.freq_cnt.entry(prev).or_insert(0) -= 1;
        *self.freq.entry(number).or_insert(0) += 1;
        *self.freq_cnt.entry(prev + 1).or_insert(0) += 1;
    }
    
    fn delete_one(&mut self, number: i32) {
        if self.freq.get(&number).unwrap_or(&0) == &0 {
            return;
        }
        let prev = *self.freq.get(&number).unwrap();
        *self.freq_cnt.entry(prev).or_insert(0) -= 1;
        *self.freq.entry(number).or_insert(0) -= 1;
        *self.freq_cnt.entry(prev - 1).or_insert(0) += 1;
    }
    
    fn has_frequency(&self, frequency: i32) -> bool {
        self.freq_cnt.get(&frequency).unwrap_or(&0) > &0
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(q)$，其中 $q$ 为查询的次数。所有单次操作的复杂度均为 $O(1)$。
- 空间复杂度：$O(m)$，其中 $m$ 是值域范围，在本题中等于 $10^5$。
