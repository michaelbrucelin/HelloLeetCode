### [子数组不同元素数目的平方和 I](https://leetcode.cn/problems/subarrays-distinct-element-sum-of-squares-i/solutions/4043174/zi-shu-zu-bu-tong-yuan-su-shu-mu-de-ping-w809/)

#### 方法一：模拟

**思路与算法**

题目要求计算所有连续子数组中不同元素的数目平方和。由于数组长度 $n$ 最大只有 $100$，我们可以直接使用两层循环来枚举所有的连续子数组。

我们用外层循环变量 $i$ 枚举子数组的起点。在每一次确定起点后，初始化一个空的哈希集合 $s$ 用于存储当前子数组内出现过的不同元素。然后用内层循环变量 $j$ 从 $i$ 向后枚举子数组的终点。每次将新元素 $nums[j]$ 加入集合 $s$ 中，此时集合的大小即为当前子数组中不同元素的数目。我们将其平方并累加到结果中。遍历结束后，返回结果即可。

**代码**

```C++
class Solution {
public:
    int sumCounts(vector<int>& nums) {
        int n = nums.size(), res = 0;
        for (int i = 0; i < n; i++) {
            unordered_set<int> s;
            for (int j = i; j < n; j++) {
                s.insert(nums[j]);
                res += s.size() * s.size();
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int sumCounts(List<Integer> nums) {
        int n = nums.size(), res = 0;
        for (int i = 0; i < n; i++) {
            Set<Integer> s = new HashSet<>();
            for (int j = i; j < n; j++) {
                s.add(nums.get(j));
                res += s.size() * s.size();
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    def sumCounts(self, nums: List[int]) -> int:
        n = len(nums)
        res = 0
        for i in range(n):
            s = set()
            for j in range(i, n):
                s.add(nums[j])
                res += len(s) * len(s)
        return res
```

```JavaScript
var sumCounts = function(nums) {
    let n = nums.length;
    let res = 0;
    for (let i = 0; i < n; i++) {
        let s = new Set();
        for (let j = i; j < n; j++) {
            s.add(nums[j]);
            res += s.size * s.size;
        }
    }
    return res;
};
```

```TypeScript
function sumCounts(nums: number[]): number {
    let n = nums.length;
    let res = 0;
    for (let i = 0; i < n; i++) {
        let s = new Set<number>();
        for (let j = i; j < n; j++) {
            s.add(nums[j]);
            res += s.size * s.size;
        }
    }
    return res;
}
```

```Go
func sumCounts(nums []int) int {
    n := len(nums)
    res := 0
    for i := 0; i < n; i++ {
        s := make(map[int]struct{})
        for j := i; j < n; j++ {
            s[nums[j]] = struct{}{}
            res += len(s) * len(s)
        }
    }
    return res
}
```

```CSharp
public class Solution {
    public int SumCounts(IList<int> nums) {
        int n = nums.Count;
        int res = 0;
        for (int i = 0; i < n; i++) {
            HashSet<int> s = new HashSet<int>();
            for (int j = i; j < n; j++) {
                s.Add(nums[j]);
                res += s.Count * s.Count;
            }
        }
        return res;
    }
}
```

```C
int sumCounts(int* nums, int numsSize) {
    int n = numsSize;
    int res = 0;
    for (int i = 0; i < n; i++) {
        int s_map[105] = {0}; // 使用数组代替哈希表集合
        int s_len = 0;
        for (int j = i; j < n; j++) {
            if (s_map[nums[j]] == 0) {
                s_map[nums[j]] = 1;
                s_len++;
            }
            res += s_len * s_len;
        }
    }
    return res;
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn sum_counts(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut res = 0;
        for i in 0..n {
            let mut s = HashSet::new();
            for j in i..n {
                s.insert(nums[j]);
                res += (s.len() * s.len()) as i32;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(n)$，其中 $n$ 是数组的长度。

#### 方法二：树状数组

**思路与算法**
同题目「2916. 子数组不同元素数目的平方和 II」中的方法，两道题目数据范围不一样，本题中数组长度最大100，所以答案最大不超过1000000。

另外需要注意的是，两道题目输入数据了类型略有不同，本题中的Java和C#使用的是列表。

为了计算所有子数组中不同元素的平方和，我们可以以每个元素所在的位置 $i$ 作为子数组的右端点，动态维护所有可能的左端点（即区间 $[0,i]$）对应的不同元素个数。

假设某个子数组原来有 $x$ 个不同元素，如果新加入一个不同元素，不同元素的个数变为 $x+1$，那么它的平方和增加量为 $(x+1)^2-x^2=2x+1$。

利用这一数学规律，我们可以借助 **支持区间修改和区间查询的树状数组 (Binary Indexed Tree, BIT)** 来优化整个流程：

1. 我们用一个哈希表 $seen$ 来记录每个元素 $a$ 上一次出现的下标。
2. 当遍历到当前元素 $a$ 时，上一次出现的下标之后的区间（即从 $j=seen[a]+1$ 开始，到当前位置 $i$）内对应的所有的子数组的不同元素个数都会加 $1$。
3. 这些子数组平方和的总增加量就是：$2\times \sum x+(i-j+1)$。其中 $\sum x$ 也就是区间内原有的不同元素总数和，可以用树状数组的区间查询功能获取，即 $bit.query(j,i)$。
4. 获取到 $\sum x$ 后，当前位置 $i$ 所有子数组的平方和增量被加到 $cur$ 中，并立即对 $10^9+7$ 取模防止溢出。然后将更新后的 $cur$ 累加到最终结果 $res$ 中同样取模。
5. 最后再用树状数组在对应的区间 $[j,i]$ 加上 $1$（即 $bit.add(j,i,1)$）。

**代码**

```C++
class BIT {
public:
    int size;
    vector<long long> _tree1;
    vector<long long> _tree2;

    BIT(int n) {
        size = n;
        _tree1.assign(n + 2, 0);
        _tree2.assign(n + 2, 0);
    }

    int _lowbit(int index) {
        return index & -index;
    }

    void add(int left, int right, int delta) {
        _add(left, delta);
        _add(right + 1, -delta);
    }

    long long query(int left, int right) {
        return _query(right) - _query(left - 1);
    }

private:
    void _add(int index, int delta) {
        index += 1;
        long long rawIndex = index;
        while (index <= size) {
            _tree1[index] += delta;
            _tree2[index] += rawIndex * delta;
            index += _lowbit(index);
        }
    }

    long long _query(int index) {
        index += 1;
        long long rawIndex = index + 1;
        if (index > size) {
            index = size;
        }
        long long res = 0;
        while (index > 0) {
            res += rawIndex * _tree1[index] - _tree2[index];
            index -= _lowbit(index);
        }
        return res;
    }
};

class Solution {
public:
    int sumCounts(vector<int>& A) {
        int n = A.size();
        long long res = 0, cur = 0;
        BIT bit(n + 10);
        unordered_map<int, int> seen;
        long long mod = 1e9 + 7;
        for (int i = 0; i < n; i++) {
            int a = A[i];
            int j = (seen.count(a) ? seen[a] : -1) + 1;
            long long q = bit.query(j, i);
            cur = (cur + q * 2 + i - j + 1) % mod;
            res = (res + cur) % mod;
            bit.add(j, i, 1);
            seen[a] = i;
        }
        return res;
    }
};
```

```Java
class BIT {
    int size;
    long[] _tree1;
    long[] _tree2;

    public BIT(int n) {
        this.size = n;
        this._tree1 = new long[n + 2];
        this._tree2 = new long[n + 2];
    }

    private int _lowbit(int index) {
        return index & -index;
    }

    public void add(int left, int right, int delta) {
        _add(left, delta);
        _add(right + 1, -delta);
    }

    public long query(int left, int right) {
        return _query(right) - _query(left - 1);
    }

    private void _add(int index, int delta) {
        index += 1;
        long rawIndex = index;
        while (index <= size) {
            _tree1[index] += delta;
            _tree2[index] += rawIndex * delta;
            index += _lowbit(index);
        }
    }

    private long _query(int index) {
        index += 1;
        long rawIndex = index + 1;
        if (index > size) {
            index = size;
        }
        long res = 0;
        while (index > 0) {
            res += rawIndex * _tree1[index] - _tree2[index];
            index -= _lowbit(index);
        }
        return res;
    }
}

class Solution {
    public int sumCounts(List<Integer> A) {
        int n = A.size();
        long res = 0, cur = 0;
        BIT bit = new BIT(n + 10);
        Map<Integer, Integer> seen = new HashMap<>();
        long mod = 1000000007;
        for (int i = 0; i < n; i++) {
            int a = A.get(i);
            int j = seen.getOrDefault(a, -1) + 1;
            long q = bit.query(j, i);
            cur = (cur + q * 2 + i - j + 1) % mod;
            res = (res + cur) % mod;
            bit.add(j, i, 1);
            seen.put(a, i);
        }
        return (int) res;
    }
}
```

```Python
class BIT:
    def __init__(self, n: int):
        self.size = n
        self._tree1 = defaultdict(int)
        self._tree2 = defaultdict(int)

    def _lowbit(self, index: int) -> int:
        return index & -index

    def add(self, left: int, right: int, delta: int) -> None:
        self._add(left, delta)
        self._add(right + 1, -delta)

    def query(self, left: int, right: int) -> int:
        return self._query(right) - self._query(left - 1)

    def _add(self, index: int, delta: int) -> None:
        index += 1
        if index < 0:
            raise ValueError('index 必须是正整数')

        rawIndex = index
        while index <= self.size:
            self._tree1[index] += delta
            self._tree2[index] += (rawIndex - 1) * delta
            index += self._lowbit(index)

    def _query(self, index: int) -> int:
        index += 1
        if index > self.size:
            index = self.size

        rawIndex = index
        res = 0
        while index > 0:
            res += rawIndex * self._tree1[index] - self._tree2[index]
            index -= self._lowbit(index)
        return res

class Solution:
    def sumCounts(self, A: List[int]) -> int:
        n = len(A)
        res = cur = 0
        bit = BIT(n + 10)
        seen = {}
        mod = 10 ** 9 + 7
        for i, a in enumerate(A):
            j = seen.get(a, -1) + 1
            cur += bit.query(j, n) * 2 + i - j + 1
            res += cur
            bit.add(j, i, 1)
            seen[a] = i
        return res % mod
```

```JavaScript
class BIT {
    constructor(n) {
        this.size = n;
        this._tree1 = new Float64Array(n + 2);
        this._tree2 = new Float64Array(n + 2);
    }

    _lowbit(index) {
        return index & -index;
    }

    add(left, right, delta) {
        this._add(left, delta);
        this._add(right + 1, -delta);
    }

    query(left, right) {
        return this._query(right) - this._query(left - 1);
    }

    _add(index, delta) {
        index += 1;
        let rawIndex = index;
        while (index <= this.size) {
            this._tree1[index] += delta;
            this._tree2[index] += rawIndex * delta;
            index += this._lowbit(index);
        }
    }

    _query(index) {
        index += 1;
        let rawIndex = index + 1;
        if (index > this.size) {
            index = this.size;
        }
        let res = 0;
        while (index > 0) {
            res += rawIndex * this._tree1[index] - this._tree2[index];
            index -= this._lowbit(index);
        }
        return res;
    }
}

var sumCounts = function(A) {
    let n = A.length;
    let res = 0n, cur = 0n;
    let bit = new BIT(n + 10);
    let seen = new Map();
    let mod = 1000000007n;
    for (let i = 0; i < n; i++) {
        let a = A[i];
        let j = (seen.has(a) ? seen.get(a) : -1) + 1;
        let q = BigInt(bit.query(j, i));
        cur = (cur + q * 2n + BigInt(i - j + 1)) % mod;
        res = (res + cur) % mod;
        bit.add(j, i, 1);
        seen.set(a, i);
    }
    return Number(res);
};
```

```TypeScript
class BIT {
    size: number;
    _tree1: Float64Array;
    _tree2: Float64Array;

    constructor(n: number) {
        this.size = n;
        this._tree1 = new Float64Array(n + 2);
        this._tree2 = new Float64Array(n + 2);
    }

    _lowbit(index: number): number {
        return index & -index;
    }

    add(left: number, right: number, delta: number): void {
        this._add(left, delta);
        this._add(right + 1, -delta);
    }

    query(left: number, right: number): number {
        return this._query(right) - this._query(left - 1);
    }

    _add(index: number, delta: number): void {
        index += 1;
        let rawIndex = index;
        while (index <= this.size) {
            this._tree1[index] += delta;
            this._tree2[index] += rawIndex * delta;
            index += this._lowbit(index);
        }
    }

    _query(index: number): number {
        index += 1;
        let rawIndex = index + 1;
        if (index > this.size) {
            index = this.size;
        }
        let res = 0;
        while (index > 0) {
            res += rawIndex * this._tree1[index] - this._tree2[index];
            index -= this._lowbit(index);
        }
        return res;
    }
}

function sumCounts(A: number[]): number {
    let n = A.length;
    let res = 0n, cur = 0n;
    let bit = new BIT(n + 10);
    let seen = new Map<number, number>();
    let mod = 1000000007n;
    for (let i = 0; i < n; i++) {
        let a = A[i];
        let j = (seen.has(a) ? seen.get(a)! : -1) + 1;
        let q = BigInt(bit.query(j, i));
        cur = (cur + q * 2n + BigInt(i - j + 1)) % mod;
        res = (res + cur) % mod;
        bit.add(j, i, 1);
        seen.set(a, i);
    }
    return Number(res);
}
```

```Go
type BIT struct {
    size   int
    _tree1 []int64
    _tree2 []int64
}

func NewBIT(n int) *BIT {
    return &BIT{
        size:   n,
        _tree1: make([]int64, n+2),
        _tree2: make([]int64, n+2),
    }
}

func (bit *BIT) _lowbit(index int) int {
    return index & -index
}

func (bit *BIT) add(left, right, delta int) {
    bit._add(left, int64(delta))
    bit._add(right+1, int64(-delta))
}

func (bit *BIT) query(left, right int) int64 {
    return bit._query(right) - bit._query(left-1)
}

func (bit *BIT) _add(index int, delta int64) {
    index += 1
    rawIndex := int64(index)
    for index <= bit.size {
        bit._tree1[index] += delta
        bit._tree2[index] += rawIndex * delta
        index += bit._lowbit(index)
    }
}

func (bit *BIT) _query(index int) int64 {
    index += 1
    rawIndex := int64(index + 1)
    if index > bit.size {
        index = bit.size
    }
    var res int64 = 0
    for index > 0 {
        res += rawIndex*bit._tree1[index] - bit._tree2[index]
        index -= bit._lowbit(index)
    }
    return res
}

func sumCounts(A []int) int {
    n := len(A)
    var res, cur int64
    bit := NewBIT(n + 10)
    seen := make(map[int]int)
    var mod int64 = 1000000007

    for i, a := range A {
        j := -1
        if val, ok := seen[a]; ok {
            j = val
        }
        j += 1
        q := bit.query(j, i)
        cur = (cur + q*2 + int64(i-j+1)) % mod
        res = (res + cur) % mod
        bit.add(j, i, 1)
        seen[a] = i
    }
    return int(res)
}
```

```CSharp
public class BIT {
    public int size;
    public long[] _tree1;
    public long[] _tree2;

    public BIT(int n) {
        this.size = n;
        this._tree1 = new long[n + 2];
        this._tree2 = new long[n + 2];
    }

    private int _lowbit(int index) {
        return index & -index;
    }

    public void add(int left, int right, int delta) {
        _add(left, delta);
        _add(right + 1, -delta);
    }

    public long query(int left, int right) {
        return _query(right) - _query(left - 1);
    }

    private void _add(int index, int delta) {
        index += 1;
        long rawIndex = index;
        while (index <= size) {
            _tree1[index] += delta;
            _tree2[index] += rawIndex * delta;
            index += _lowbit(index);
        }
    }

    private long _query(int index) {
        index += 1;
        long rawIndex = index + 1;
        if (index > size) {
            index = size;
        }
        long res = 0;
        while (index > 0) {
            res += rawIndex * _tree1[index] - _tree2[index];
            index -= _lowbit(index);
        }
        return res;
    }
}

public class Solution {
    public int SumCounts(IList<int> A) {
        int n = A.Count;
        long res = 0, cur = 0;
        BIT bit = new BIT(n + 10);
        Dictionary<int, int> seen = new Dictionary<int, int>();
        long mod = 1000000007;
        for (int i = 0; i < n; i++) {
            int a = A[i];
            int j = (seen.ContainsKey(a) ? seen[a] : -1) + 1;
            long q = bit.query(j, i);
            cur = (cur + q * 2 + i - j + 1) % mod;
            res = (res + cur) % mod;
            bit.add(j, i, 1);
            seen[a] = i;
        }
        return (int) res;
    }
}
```

```C
typedef struct {
    int size;
    long long* _tree1;
    long long* _tree2;
} BIT;

BIT* createBIT(int n) {
    BIT* bit = (BIT*)malloc(sizeof(BIT));
    bit->size = n;
    bit->_tree1 = (long long*)calloc(n + 2, sizeof(long long));
    bit->_tree2 = (long long*)calloc(n + 2, sizeof(long long));
    return bit;
}

void freeBIT(BIT* bit) {
    free(bit->_tree1);
    free(bit->_tree2);
    free(bit);
}

int _lowbit(int index) {
    return index & -index;
}

void _add(BIT* bit, int index, int delta) {
    index += 1;
    long long rawIndex = index;
    while (index <= bit->size) {
        bit->_tree1[index] += delta;
        bit->_tree2[index] += rawIndex * delta;
        index += _lowbit(index);
    }
}

long long _query(BIT* bit, int index) {
    index += 1;
    long long rawIndex = index + 1;
    if (index > bit->size) {
        index = bit->size;
    }
    long long res = 0;
    while (index > 0) {
        res += rawIndex * bit->_tree1[index] - bit->_tree2[index];
        index -= _lowbit(index);
    }
    return res;
}

void add(BIT* bit, int left, int right, int delta) {
    _add(bit, left, delta);
    _add(bit, right + 1, -delta);
}

long long query(BIT* bit, int left, int right) {
    return _query(bit, right) - _query(bit, left - 1);
}

int sumCounts(int* A, int ASize) {
    int n = ASize;
    long long res = 0, cur = 0;
    BIT* bit = createBIT(n + 10);

    int seen[100005];
    memset(seen, -1, sizeof(seen));
    long long mod = 1000000007;

    for (int i = 0; i < n; i++) {
        int a = A[i];
        int j = seen[a] + 1;
        long long q = query(bit, j, i);
        cur = (cur + q * 2 + i - j + 1) % mod;
        res = (res + cur) % mod;
        add(bit, j, i, 1);
        seen[a] = i;
    }

    freeBIT(bit);
    return (int) res;
}
```

```Rust
use std::collections::HashMap;

struct BIT {
    size: usize,
    _tree1: Vec<i64>,
    _tree2: Vec<i64>,
}

impl BIT {
    fn new(n: usize) -> Self {
        BIT {
            size: n,
            _tree1: vec![0; n + 2],
            _tree2: vec![0; n + 2],
        }
    }

    fn _lowbit(index: usize) -> usize {
        index & index.wrapping_neg()
    }

    fn add(&mut self, left: usize, right: usize, delta: i64) {
        self._add(left, delta);
        self._add(right + 1, -delta);
    }

    fn query(&self, left: usize, right: usize) -> i64 {
        let left_val = if left == 0 { 0 } else { self._query(left - 1) };
        self._query(right) - left_val
    }

    fn _add(&mut self, mut index: usize, delta: i64) {
        index += 1;
        let raw_index = index as i64;
        while index <= self.size {
            self._tree1[index] += delta;
            self._tree2[index] += raw_index * delta;
            index += Self::_lowbit(index);
        }
    }

    fn _query(&self, mut index: usize) -> i64 {
        index += 1;
        let raw_index = (index + 1) as i64;
        if index > self.size {
            index = self.size;
        }
        let mut res: i64 = 0;
        while index > 0 {
            res += raw_index * self._tree1[index] - self._tree2[index];
            index -= Self::_lowbit(index);
        }
        res
    }
}

impl Solution {
    pub fn sum_counts(A: Vec<i32>) -> i32 {
        let n = A.len();
        let mut res: i64 = 0;
        let mut cur: i64 = 0;
        let mut bit = BIT::new(n + 10);
        let mut seen: HashMap<i32, i32> = HashMap::new();
        let r#mod: i64 = 1_000_000_007;

        for (i, &a) in A.iter().enumerate() {
            let j = seen.get(&a).unwrap_or(&-1) + 1;
            let q = bit.query(j as usize, i);
            cur = (cur + q * 2 + (i as i64) - (j as i64) + 1) % r#mod;
            res = (res + cur) % r#mod;
            bit.add(j as usize, i, 1);
            seen.insert(a, i as i32);
        }

        res as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(n)$，其中 $n$ 是数组的长度。
