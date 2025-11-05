### [计算子数组的 x-sum II](https://leetcode.cn/problems/find-x-sum-of-all-k-long-subarrays-ii/solutions/3822640/ji-suan-zi-shu-zu-de-x-sum-ii-by-leetcod-s0uq/)

#### 方法一：哈希表 $+$ 有序集合

**思路与算法**

当我们计算完以 $nums[i]$ 开头的子数组的 $x-sum$，再去计算 $nums[i+1]$ 开头的子数组的 $x-sum$ 时，后者比前者多了 $nums[i+k]$，少了 $nums[i]$。因此，我们需要设计一种数据结构，支持下面的三种操作：

- 添加一个元素；
- 删除一个元素；
- 计算当前所有元素的 $x-sum$。

根据题目描述，$x-sum$ 是出现次数最多的 $x$ 种元素的总和，这就提示我们可以使用有序集合来维护这些元素以及它们出现的次数：我们有一个有序集合 $large$，用来维护出现次数最多的 $x$ 种元素，以及另一个有序集合 $small$，维护剩余的元素。有序集合中的每个项是一个二元组 $(occ,num)$，表示元素 $num$ 以及它出现的次数 $occ$。有序集合均按照 $occ$ 为第一关键字升序，$num$ 为第二关键字升序进行维护。

当我们需要添加一个元素 $num$ 时，我们获取它出现的次数 $occ$，如果 $occ>0$，将 $(occ,num)$ 从有序集合中移除，并将 $(occ+1,num)$ 加入有序集合。

当我们需要删除一个元素 $num$ 时，我们获取它出现的次数 $occ$，将 $(occ,num)$ 从有序集合中移除，如果 $occ>1$，并将 $(occ-1,num)$ 加入有序集合。

对于有序集合中加入 $(occ,num)$ 的操作：

- 如果 $large$ 中的二元组个数小于 $x$，则将 $(occ,num)$ 加入 $large$；
- 如果 $(occ,num)$ 比 $large$ 中最小的二元组还要小，则将 $(occ,num)$ 加入 $small$；
- 否则，将 $large$ 中最小的二元组移除并加入 $small$，并将 $(occ,num)$ 加入 $large$。

对于有序集合中移除 $(occ,num)$ 的操作：

- 如果 $(occ,num)$ 比 $large$ 中最小的二元组还要小，则它在 $small$ 中，从 $small$ 中移除；
- 否则，它在 $large$ 中，从 $large$ 中移除。此时如果 $small$ 不为空，则将 $small$ 中最大的二元组移除并加入 $large$。

occ 可以额外使用一个哈希表进行维护。当有任何二元组加入 $large$，或者从 $large$ 中移除时，我们对应将答案增加或减少 $occ\times num$，这样就可以快速获取任意时刻的 $x-sum$。

**代码**

```C++
class Helper {
public:
    Helper(int x) {
        this->x = x;
        this->result = 0;
    }

    void insert(int num) {
        if (occ[num]) {
            internalRemove({occ[num], num});
        }
        ++occ[num];
        internalInsert({occ[num], num});
    }

    void remove(int num) {
        internalRemove({occ[num], num});
        --occ[num];
        if (occ[num]) {
            internalInsert({occ[num], num});
        }
    }

    long long get() {
        return result;
    }

private:
    void internalInsert(const pair<int, int>& p) {
        if (large.size() < x || p > *large.begin()) {
            result += static_cast<long long>(p.first) * p.second;
            large.insert(p);
            if (large.size() > x) {
                result -= static_cast<long long>(large.begin()->first) * large.begin()->second;
                auto transfer = *large.begin();
                large.erase(transfer);
                small.insert(transfer);
            }
        }
        else {
            small.insert(p);
        }
    }

    void internalRemove(const pair<int, int>& p) {
        if (p >= *large.begin()) {
            result -= static_cast<long long>(p.first) * p.second;
            large.erase(p);
            if (!small.empty()) {
                result += static_cast<long long>(small.rbegin()->first) * small.rbegin()->second;
                auto transfer = *small.rbegin();
                small.erase(transfer);
                large.insert(transfer);
            }
        }
        else {
            small.erase(p);
        }
    }

private:
    int x;
    long long result;
    set<pair<int, int>> large, small;
    unordered_map<int, int> occ;
};

class Solution {
public:
    vector<long long> findXSum(vector<int>& nums, int k, int x) {
        Helper helper(x);

        vector<long long> ans;
        for (int i = 0; i < nums.size(); ++i) {
            helper.insert(nums[i]);
            if (i >= k) {
                helper.remove(nums[i - k]);
            }
            if (i >= k - 1) {
                ans.push_back(helper.get());
            }
        }
        return ans;
    }
};
```

```Java
class Helper {
    private int x;
    private long result;
    private TreeSet<Pair> large, small;
    private Map<Integer, Integer> occ;
    
    private static class Pair implements Comparable<Pair> {
        int first;
        int second;
        
        Pair(int first, int second) {
            this.first = first;
            this.second = second;
        }
        
        @Override
        public int compareTo(Pair other) {
            if (this.first != other.first) {
                return Integer.compare(this.first, other.first);
            }
            return Integer.compare(this.second, other.second);
        }
        
        @Override
        public boolean equals(Object obj) {
            if (this == obj) return true;
            if (obj == null || getClass() != obj.getClass()) return false;
            Pair pair = (Pair) obj;
            return first == pair.first && second == pair.second;
        }
        
        @Override
        public int hashCode() {
            return Objects.hash(first, second);
        }
    }
    
    public Helper(int x) {
        this.x = x;
        this.result = 0;
        this.large = new TreeSet<>();
        this.small = new TreeSet<>();
        this.occ = new HashMap<>();
    }
    
    public void insert(int num) {
        if (occ.containsKey(num) && occ.get(num) > 0) {
            internalRemove(new Pair(occ.get(num), num));
        }
        occ.put(num, occ.getOrDefault(num, 0) + 1);
        internalInsert(new Pair(occ.get(num), num));
    }
    
    public void remove(int num) {
        internalRemove(new Pair(occ.get(num), num));
        occ.put(num, occ.get(num) - 1);
        if (occ.get(num) > 0) {
            internalInsert(new Pair(occ.get(num), num));
        }
    }
    
    public long get() {
        return result;
    }
    
    private void internalInsert(Pair p) {
        if (large.size() < x || p.compareTo(large.first()) > 0) {
            result += (long) p.first * p.second;
            large.add(p);
            if (large.size() > x) {
                Pair toRemove = large.first();
                result -= (long) toRemove.first * toRemove.second;
                large.remove(toRemove);
                small.add(toRemove);
            }
        } else {
            small.add(p);
        }
    }
    
    private void internalRemove(Pair p) {
        if (p.compareTo(large.first()) >= 0) {
            result -= (long) p.first * p.second;
            large.remove(p);
            if (!small.isEmpty()) {
                Pair toAdd = small.last();
                result += (long) toAdd.first * toAdd.second;
                small.remove(toAdd);
                large.add(toAdd);
            }
        } else {
            small.remove(p);
        }
    }
}

class Solution {
    public long[] findXSum(int[] nums, int k, int x) {
        Helper helper = new Helper(x);
        List<Long> ans = new ArrayList<>();
        
        for (int i = 0; i < nums.length; i++) {
            helper.insert(nums[i]);
            if (i >= k) {
                helper.remove(nums[i - k]);
            }
            if (i >= k - 1) {
                ans.add(helper.get());
            }
        }
        
        return ans.stream().mapToLong(Long::longValue).toArray();
    }
}
```

```CSharp
public class Helper {
    private int x;
    private long result;
    private SortedSet<(int, int)> large, small;
    private Dictionary<int, int> occ;
    
    public Helper(int x) {
        this.x = x;
        this.result = 0;
        this.large = new SortedSet<(int, int)>();
        this.small = new SortedSet<(int, int)>();
        this.occ = new Dictionary<int, int>();
    }
    
    public void Insert(int num) {
        if (occ.ContainsKey(num) && occ[num] > 0) {
            InternalRemove((occ[num], num));
        }
        occ[num] = occ.GetValueOrDefault(num, 0) + 1;
        InternalInsert((occ[num], num));
    }
    
    public void Remove(int num) {
        InternalRemove((occ[num], num));
        occ[num]--;
        if (occ[num] > 0) {
            InternalInsert((occ[num], num));
        }
    }
    
    public long Get() {
        return result;
    }
    
    private void InternalInsert((int, int) p) {
        if (large.Count < x || Compare(p, large.Min) > 0) {
            result += (long)p.Item1 * p.Item2;
            large.Add(p);
            if (large.Count > x) {
                var toRemove = large.Min;
                result -= (long)toRemove.Item1 * toRemove.Item2;
                large.Remove(toRemove);
                small.Add(toRemove);
            }
        } else {
            small.Add(p);
        }
    }
    
    private void InternalRemove((int, int) p) {
        if (Compare(p, large.Min) >= 0) {
            result -= (long)p.Item1 * p.Item2;
            large.Remove(p);
            if (small.Count > 0) {
                var toAdd = small.Max;
                result += (long)toAdd.Item1 * toAdd.Item2;
                small.Remove(toAdd);
                large.Add(toAdd);
            }
        } else {
            small.Remove(p);
        }
    }
    
    private int Compare((int, int) a, (int, int) b) {
        if (a.Item1 != b.Item1) return a.Item1.CompareTo(b.Item1);
        return a.Item2.CompareTo(b.Item2);
    }
}

public class Solution {
    public long[] FindXSum(int[] nums, int k, int x) {
        Helper helper = new Helper(x);
        List<long> ans = new List<long>();
        
        for (int i = 0; i < nums.Length; i++) {
            helper.Insert(nums[i]);
            if (i >= k) {
                helper.Remove(nums[i - k]);
            }
            if (i >= k - 1) {
                ans.Add(helper.Get());
            }
        }
        
        return ans.ToArray();
    }
}
```

```Python
class Helper:
    def __init__(self, x):
        self.x = x
        self.result = 0
        self.large = SortedList()
        self.small = SortedList()
        self.occ = defaultdict(int)

    def insert(self, num):
        if self.occ[num] > 0:
            self.internal_remove((self.occ[num], num))
        self.occ[num] += 1
        self.internal_insert((self.occ[num], num))

    def remove(self, num):
        self.internal_remove((self.occ[num], num))
        self.occ[num] -= 1
        if self.occ[num] > 0:
            self.internal_insert((self.occ[num], num))

    def get(self):
        return self.result

    def internal_insert(self, p):
        if len(self.large) < self.x or p > self.large[0]:
            self.result += p[0] * p[1]
            self.large.add(p)
            if len(self.large) > self.x:
                to_remove = self.large[0]
                self.result -= to_remove[0] * to_remove[1]
                self.large.remove(to_remove)
                self.small.add(to_remove)
        else:
            self.small.add(p)

    def internal_remove(self, p):
        if p >= self.large[0]:
            self.result -= p[0] * p[1]
            self.large.remove(p)
            if self.small:
                to_add = self.small[-1]
                self.result += to_add[0] * to_add[1]
                self.small.remove(to_add)
                self.large.add(to_add)
        else:
            self.small.remove(p)

class Solution:
    def findXSum(self, nums, k, x):
        helper = Helper(x)
        ans = []

        for i in range(len(nums)):
            helper.insert(nums[i])
            if i >= k:
                helper.remove(nums[i - k])
            if i >= k - 1:
                ans.append(helper.get())

        return ans
```

```Go
import (
    "github.com/emirpasic/gods/v2/trees/redblacktree"
)

func findXSum(nums []int, k int, x int) []int64 {
    helper := NewHelper(x)
    ans := []int64{}
    
    for i := 0; i < len(nums); i++ {
        helper.Insert(nums[i])
        if i >= k {
            helper.Remove(nums[i-k])
        }
        if i >= k-1 {
            ans = append(ans, helper.Get())
        }
    }
    
    return ans
}

type Helper struct {
    x         int
    result    int64
    large     *redblacktree.Tree[pair, struct{}]
    small     *redblacktree.Tree[pair, struct{}]
    occ       map[int]int
}

type pair struct {
    freq int
    num  int
}

func pairComparator(a, b pair) int {
    if a.freq != b.freq {
        return a.freq - b.freq
    }
    return a.num - b.num
}

func NewHelper(x int) *Helper {
    return &Helper{
        x:      x,
        result: 0,
        large:  redblacktree.NewWith[pair, struct{}](pairComparator),
        small:  redblacktree.NewWith[pair, struct{}](pairComparator),
        occ:    make(map[int]int),
    }
}

func (h *Helper) Insert(num int) {
    if h.occ[num] > 0 {
        h.internalRemove(pair{freq: h.occ[num], num: num})
    }
    h.occ[num]++
    h.internalInsert(pair{freq: h.occ[num], num: num})
}

func (h *Helper) Remove(num int) {
    h.internalRemove(pair{freq: h.occ[num], num: num})
    h.occ[num]--
    if h.occ[num] > 0 {
        h.internalInsert(pair{freq: h.occ[num], num: num})
    }
}

func (h *Helper) Get() int64 {
    return h.result
}

func (h *Helper) internalInsert(p pair) {
    if h.large.Size() < h.x {
        h.result += int64(p.freq) * int64(p.num)
        h.large.Put(p, struct{}{})
    } else {
        minLarge := h.large.Left().Key
        if pairComparator(p, minLarge) > 0 {
            h.result += int64(p.freq) * int64(p.num)
            h.large.Put(p, struct{}{})
            toRemove := h.large.Left().Key
            h.result -= int64(toRemove.freq) * int64(toRemove.num)
            h.large.Remove(toRemove)
            h.small.Put(toRemove, struct{}{})
        } else {
            h.small.Put(p, struct{}{})
        }
    }
}

func (h *Helper) internalRemove(p pair) {
    if _, found := h.large.Get(p); found {
        h.result -= int64(p.freq) * int64(p.num)
        h.large.Remove(p)
        
        if h.small.Size() > 0 {
            maxSmall := h.small.Right().Key
            h.result += int64(maxSmall.freq) * int64(maxSmall.num)
            h.small.Remove(maxSmall)
            h.large.Put(maxSmall, struct{}{})
        }
    } else if _, found := h.small.Get(p); found {
        h.small.Remove(p)
    }
}
```

```JavaScript
const {
  AvlTree,
} = require('datastructures-js');

class Helper {
    constructor(x) {
        this.x = x;
        this.result = 0n;
        
        const comparator = (a, b) => {
            if (a[0] !== b[0]) {
                return a[0] - b[0];
            }
            return a[1] - b[1];
        };
        
        this.large = new AvlTree(comparator);
        this.small = new AvlTree(comparator);
        this.occ = new Map();
    }

    insert(num) {
        const currentFreq = this.occ.get(num) || 0;
        if (currentFreq > 0) {
            this.internalRemove([currentFreq, num]);
        }
        
        const newFreq = currentFreq + 1;
        this.occ.set(num, newFreq);
        this.internalInsert([newFreq, num]);
    }

    remove(num) {
        const currentFreq = this.occ.get(num);
        if (currentFreq === undefined || currentFreq === 0) {
            return;
        }
        this.internalRemove([currentFreq, num]);
        const newFreq = currentFreq - 1;
        if (newFreq > 0) {
            this.occ.set(num, newFreq);
            this.internalInsert([newFreq, num]);
        } else {
            this.occ.delete(num);
        }
    }

    get() {
        return Number(this.result);
    }

    internalInsert(p) {
        const [freq, value] = p;        
        const minLarge = this.large.min();
        if (this.large.count() < this.x || (minLarge && this.comparePairs(p, minLarge.getValue()) > 0)) {
            this.result += BigInt(freq) * BigInt(value);
            this.large.insert(p);
            if (this.large.count() > this.x) {
                const smallestLarge = this.large.min();
                if (smallestLarge) {
                    const value = smallestLarge.getValue();
                    this.result -= BigInt(value[0]) * BigInt(value[1]);
                    this.large.remove(value);
                    this.small.insert(value);
                }
            }
        } else {
            this.small.insert(p);
        }
    }

    internalRemove(p) {
        const [freq, value] = p;
        if (this.large.has(p)) {
            this.result -= BigInt(freq) * BigInt(value);
            this.large.remove(p);
            if (this.small.count() > 0) {
                const largestSmall = this.small.max();
                if (largestSmall) {
                    const value = largestSmall.getValue();
                    this.result += BigInt(value[0]) * BigInt(value[1]);
                    this.small.remove(value);
                    this.large.insert(value);
                }
            }
        } else {
            this.small.remove(p);
        }
    }

    comparePairs(a, b) {
        if (a[0] !== b[0]) {
            return a[0] - b[0];
        }
        return a[1] - b[1];
    }
}

var findXSum = function(nums, k, x) {
    const helper = new Helper(x);
    const ans = [];
    for (let i = 0; i < nums.length; i++) {
        helper.insert(nums[i]);
        if (i >= k) {
            helper.remove(nums[i - k]);
        }
        if (i >= k - 1) {
            ans.push(helper.get());
        }
    }
    
    return ans;
};
```

```TypeScript
import {
  AvlTree
} from '@datastructures-js/binary-search-tree';

type FrequencyPair = [number, number];

class Helper {
    private x: number;
    private result: bigint;
    private large: AvlTree<FrequencyPair>;
    private small: AvlTree<FrequencyPair>;
    private occ: Map<number, number>;

    constructor(x: number) {
        this.x = x;
        this.result = 0n;
        
        const comparator = (a: FrequencyPair, b: FrequencyPair): number => {
            if (a[0] !== b[0]) {
                return a[0] - b[0];
            }
            return a[1] - b[1];
        };
        
        this.large = new AvlTree<FrequencyPair>(comparator);
        this.small = new AvlTree<FrequencyPair>(comparator);
        this.occ = new Map<number, number>();
    }

    insert(num: number): void {
        const currentFreq = this.occ.get(num) || 0;
        if (currentFreq > 0) {
            this.internalRemove([currentFreq, num]);
        }
        
        const newFreq = currentFreq + 1;
        this.occ.set(num, newFreq);
        this.internalInsert([newFreq, num]);
    }

    remove(num: number): void {
        const currentFreq = this.occ.get(num);
        if (currentFreq === undefined || currentFreq === 0) {
            return;
        }
        this.internalRemove([currentFreq, num]);
        const newFreq = currentFreq - 1;
        if (newFreq > 0) {
            this.occ.set(num, newFreq);
            this.internalInsert([newFreq, num]);
        } else {
            this.occ.delete(num);
        }
    }

    get(): number {
        return Number(this.result);
    }

    private internalInsert(p: FrequencyPair): void {
        const [freq, value] = p;        
        const minLarge = this.large.min();
        if (this.large.count() < this.x || (minLarge && this.comparePairs(p, minLarge.getValue()) > 0)) {
            this.result += BigInt(freq) * BigInt(value);
            this.large.insert(p);
            if (this.large.count() > this.x) {
                const smallestLarge = this.large.min();
                if (smallestLarge) {
                    const value = smallestLarge.getValue();
                    this.result -= BigInt(value[0]) * BigInt(value[1]);
                    this.large.remove(value);
                    this.small.insert(value);
                }
            }
        } else {
            this.small.insert(p);
        }
    }

    private internalRemove(p: FrequencyPair): void {
        const [freq, value] = p;
        
        if (this.large.has(p)) {
            this.result -= BigInt(freq) * BigInt(value);
            this.large.remove(p);
            if (this.small.count() > 0) {
                const largestSmall = this.small.max();
                if (largestSmall) {
                    const value = largestSmall.getValue();
                    this.result += BigInt(value[0]) * BigInt(value[1]);
                    this.small.remove(value);
                    this.large.insert(value);
                }
            }
        } else {
            this.small.remove(p);
        }
    }

    private comparePairs(a: FrequencyPair, b: FrequencyPair): number {
        if (a[0] !== b[0]) {
            return a[0] - b[0];
        }
        return a[1] - b[1];
    }
}

function findXSum(nums: number[], k: number, x: number): number[] {
    const helper = new Helper(x);
    const ans: number[] = [];

    for (let i = 0; i < nums.length; i++) {
        helper.insert(nums[i]);
        
        if (i >= k) {
            helper.remove(nums[i - k]);
        }
        
        if (i >= k - 1) {
            ans.push(helper.get());
        }
    }
    
    return ans;
}
```

```Rust
use std::collections::{BTreeSet, HashMap};
use std::cmp::Ordering;

#[derive(Eq, PartialEq, Clone, Debug)]
struct Pair {
    freq: i32,
    num: i32,
}

impl Ord for Pair {
    fn cmp(&self, other: &Self) -> Ordering {
        if self.freq != other.freq {
            self.freq.cmp(&other.freq)
        } else {
            self.num.cmp(&other.num)
        }
    }
}

impl PartialOrd for Pair {
    fn partial_cmp(&self, other: &Self) -> Option<Ordering> {
        Some(self.cmp(other))
    }
}

struct Helper {
    x: usize,
    result: i64,
    large: BTreeSet<Pair>,
    small: BTreeSet<Pair>,
    occ: HashMap<i32, i32>,
}

impl Helper {
    fn new(x: i32) -> Self {
        Helper {
            x: x as usize,
            result: 0,
            large: BTreeSet::new(),
            small: BTreeSet::new(),
            occ: HashMap::new(),
        }
    }

    fn insert(&mut self, num: i32) {
        if let Some(&count) = self.occ.get(&num) {
            if count > 0 {
                self.internal_remove(Pair { freq: count, num });
            }
        }
        *self.occ.entry(num).or_insert(0) += 1;
        let new_count = self.occ[&num];
        self.internal_insert(Pair { freq: new_count, num });
    }

    fn remove(&mut self, num: i32) {
        let count = self.occ[&num];
        self.internal_remove(Pair { freq: count, num });
        *self.occ.get_mut(&num).unwrap() -= 1;
        if self.occ[&num] > 0 {
            let new_count = self.occ[&num];
            self.internal_insert(Pair { freq: new_count, num });
        }
    }

    fn get(&self) -> i64 {
        self.result
    }

    fn internal_insert(&mut self, p: Pair) {
        if self.large.len() < self.x || p > *self.large.iter().next().unwrap() {
            self.result += p.freq as i64 * p.num as i64;
            self.large.insert(p.clone());
            if self.large.len() > self.x {
                let to_remove = self.large.iter().next().unwrap().clone();
                self.result -= to_remove.freq as i64 * to_remove.num as i64;
                self.large.remove(&to_remove);
                self.small.insert(to_remove);
            }
        } else {
            self.small.insert(p);
        }
    }

    fn internal_remove(&mut self, p: Pair) {
        if p >= *self.large.iter().next().unwrap() {
            self.result -= p.freq as i64 * p.num as i64;
            self.large.remove(&p);
            if let Some(to_add) = self.small.iter().next_back().cloned() {
                self.result += to_add.freq as i64 * to_add.num as i64;
                self.small.remove(&to_add);
                self.large.insert(to_add);
            }
        } else {
            self.small.remove(&p);
        }
    }
}

impl Solution {
    pub fn find_x_sum(nums: Vec<i32>, k: i32, x: i32) -> Vec<i64> {
        let mut helper = Helper::new(x);
        let mut ans = Vec::new();
        
        for i in 0..nums.len() {
            helper.insert(nums[i]);
            if i >= k as usize {
                helper.remove(nums[i - k as usize]);
            }
            if i >= (k - 1) as usize {
                ans.push(helper.get());
            }
        }
        
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$。有序集合上的插入和移除操作的单次时间复杂度是 $O(\log n)$，数组 $nums$ 中的每一个元素，都只会触发常数次的插入和移除操作。
- 空间复杂度：$O(n)$，即为有序集合和哈希表需要使用的空间。
