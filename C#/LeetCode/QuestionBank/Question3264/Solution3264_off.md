### [K 次乘运算后的最终数组 I](https://leetcode.cn/problems/final-array-state-after-k-multiplication-operations-i/solutions/3014792/k-ci-cheng-yun-suan-hou-de-zui-zhong-shu-8i7p/)

#### 方法一：模拟

根据题意，对 $nums$ 进行模拟操作，每次操作先找到 $nums$ 的最前面的最小值，然后将该元素替换成乘以 $multiplier$ 后的值，最后返回 $k$ 次模拟操作后的数组 $nums$。

```C++
class Solution {
public:
    vector<int> getFinalState(vector<int>& nums, int k, int multiplier) {
        while (k--) {
            auto iter = min_element(nums.begin(), nums.end());
            *iter *= multiplier;
        }
        return nums;
    }
};
```

```Python
class Solution:
    def getFinalState(self, nums: List[int], k: int, multiplier: int) -> List[int]:
        for _ in range(k):
            i = nums.index(min(nums))
            nums[i] *= multiplier
        return nums
```

```C
int* getFinalState(int* nums, int numsSize, int k, int multiplier, int* returnSize) {
    int *ret = (int *)malloc(sizeof(int) * numsSize);
    memcpy(ret, nums, sizeof(int) * numsSize);
    while (k--) {
        int m = 0;
        for (int j = 0; j < numsSize; j++) {
            if (ret[j] < ret[m]) {
                m = j;
            }
        }
        ret[m] *= multiplier;
    }
    *returnSize = numsSize;
    return ret;
}
```

```Go
func getFinalState(nums []int, k int, multiplier int) []int {
    for i := 0; i < k; i++ {
        m := 0
        for j := range nums {
            if nums[j] < nums[m] {
                m = j
            }
        }
        nums[m] *= multiplier
    }
    return nums
}
```

```Java
class Solution {
    public int[] getFinalState(int[] nums, int k, int multiplier) {
        for (int i = 0; i < k; i++) {
            int m = 0;
            for (int j = 0; j < nums.length; j++) {
                if (nums[j] < nums[m]) {
                    m = j;
                }
            }
            nums[m] *= multiplier;
        }
        return nums;
    }
}
```

```CSharp
public class Solution {
    public int[] GetFinalState(int[] nums, int k, int multiplier) {
        for (int i = 0; i < k; i++) {
            int m = 0;
            for (int j = 0; j < nums.Length; j++) {
                if (nums[j] < nums[m]) {
                    m = j;
                }
            }
            nums[m] *= multiplier;
        }
        return nums;
    }
}
```

```JavaScript
var getFinalState = function(nums, k, multiplier) {
    for (let i = 0; i < k; i++) {
        let m = 0;
        for (let j = 0; j < nums.length; j++) {
            if (nums[j] < nums[m]) {
                m = j;
            }
        }
        nums[m] *= multiplier;
    }
    return nums;
};
```

```TypeScript
function getFinalState(nums: number[], k: number, multiplier: number): number[] {
    for (let i = 0; i < k; i++) {
        let m = 0;
        for (let j = 0; j < nums.length; j++) {
            if (nums[j] < nums[m]) {
                m = j;
            }
        }
        nums[m] *= multiplier;
    }
    return nums;
};
```

```Rust
impl Solution {
    pub fn get_final_state(mut nums: Vec<i32>, k: i32, multiplier: i32) -> Vec<i32> {
        for _ in 0..k {
            let mut m = 0;
            for j in 1..nums.len() {
                if nums[j] < nums[m] {
                    m = j;
                }
            }
            nums[m] *= multiplier;
        }
        nums
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nk)$，其中 $n$ 是数组 $nums$ 的长度，$k$ 是操作次数。
- 空间复杂度：$O(1)$。返回值不计入空间复杂度。

#### 方法二：优先队列

假设初始时，数组 $nums$ 的最大值为 $mx$。首先将数组的所有元素及对应的下标都放到优先队列（最小堆，排序规则按照元素值、下标升序）中，然后不断从优先队列中取出元素，执行乘 $multiplier$ 操作后，再放回优先队列中。那么有以下两种情况：

- **情况一**
    每次取出的元素 $x$，都有 $x \times multiplier < mx$，直到 $k=0$ 成立。对于这类情况，数组后续无需执行任何操作，我们直接返回操作后的数组。
- **情况二**
    如果对于堆顶元素 $x$，有 $x \ge mx$，我们直接终止以上操作。那么对于优先队列中的任一元素值 $y$，都有 $mx \times multiplier > y \ge mx$（假设 $mx \times multiplier \le y$，那么执行操作前 $y$ 对应的元素值为 $\dfrac{y}{multiplier} \ge mx$，矛盾）。
    此时按照规则，优先队列中值最小同时下标最小的堆顶元素是下一次操作要选择的元素，我们对它执行操作后，后续需要对其余所有元素都恰好执行一次操作后，才会再次对它执行操作。
    这里简单论证一下，当我们对堆顶元素执行操作后，它的值变成 $multiplier \times mx$，是大于任一其余元素的，所以必须对其余所有元素执行至少一次操作后，才会再次对它执行操作；然后对于任一其余元素 $y$，执行操作后，有 $y \times multiplier \ge multiplier \times mx$，当且仅当 $y$ 的下标大于堆顶元素的下标时，等号成立，所以元素 $y$ 最多执行一次操作，得证。
    根据以上推导，后续的操作可以先批量对数组整体执行 $\lfloor \dfrac{k}{n} \rfloor$ 次操作，然后再按照规则单个执行 $kmodn$ 次操作，具体实现为快速幂算法 $+$ 排序。

```C++
class Solution {
public:
    long long quickMul(long long x, long long y, long long m) {
        long long res = 1;
        while (y) {
            if (y & 1) {
                res = (res * x) % m;
            }
            y >>= 1;
            x = (x * x) % m;
        }
        return res;
    }

    vector<int> getFinalState(vector<int>& nums, int k, int multiplier) {
        if (multiplier == 1) {
            return nums;
        }
        long long n = nums.size(), m = 1e9 + 7;
        long long mx = *max_element(nums.begin(), nums.end());
        vector<pair<long long, int>> v(n);
        for (int i = 0; i < n; i++) {
            v[i] = {nums[i], i};
        }
        make_heap(v.begin(), v.end(), greater<>());
        for (; v[0].first < mx && k; k--) {
            pop_heap(v.begin(), v.end(), greater<>());
            v.back().first *= multiplier;
            push_heap(v.begin(), v.end(), greater<>());
        }
        sort(v.begin(), v.end());
        for (int i = 0; i < n; i++) {
            int t = k / n + (i < k % n);
            nums[v[i].second] = ((v[i].first % m) * quickMul(multiplier, t, m)) % m;
        }
        return nums;
    }
};
```

```Python
class Solution:
    def getFinalState(self, nums: List[int], k: int, multiplier: int) -> List[int]:
        if multiplier == 1:
            return nums
        n, m = len(nums), int(1e9 + 7)
        mx = max(nums)
        v = [(num, i) for i, num in enumerate(nums)]
        heapify(v)
        while v[0][0] < mx and k:
            k -= 1
            num, i = heappop(v)
            heappush(v, (num * multiplier, i))
        v.sort()
        for i in range(n):
            t = k // n + (i < k % n)
            nums[v[i][1]] = ((v[i][0] % m) * pow(multiplier, t, m)) % m
        return nums
```

```Go
func quickMul(x, y, m int64) int64 {
    res := int64(1)
    for y > 0 {
        if (y & 1) == 1 {
            res = (res * x) % m
        }
        y >>= 1
        x = (x * x) % m
    }
    return res
}

func getFinalState(nums []int, k int, multiplier int) []int {
    if multiplier == 1 {
        return nums
    }
    n, m := len(nums), int64(1e9+7)
    mx := 0
    var v minHeap
    for i, num := range nums {
        mx = max(mx, num)
        v = append(v, pair{int64(num), i})
    }
    heap.Init(&v)
    for ; v[0].first < int64(mx) && k > 0; k-- {
        x := heap.Pop(&v).(pair)
        x.first *= int64(multiplier)
        heap.Push(&v, x)
    }
    sort.Slice(v, func(i, j int) bool {
        return v[i].first < v[j].first || v[i].first == v[j].first && v[i].second < v[j].second
    })
    for i := 0; i < n; i++ {
        t := k / n
        if i < k % n {
            t++
        }
        nums[v[i].second] = int((v[i].first % m) * quickMul(int64(multiplier), int64(t), m) % m)
    }
    return nums
}

type pair struct {
    first  int64
    second int
}

type minHeap []pair

func (h minHeap) Len() int{
    return len(h)
}
func (h minHeap) Less(i, j int) bool {
    return h[i].first < h[j].first || h[i].first == h[j].first && h[i].second < h[j].second
}
func (h minHeap) Swap(i, j int) {
    h[i], h[j] = h[j], h[i]
}

func (h *minHeap) Push(x interface{}) {
    *h = append(*h, x.(pair))
}

func (h *minHeap) Pop() interface{} {
    n := len(*h)
    res := (*h)[n - 1]
    *h = (*h)[0 : n - 1]
    return res
}
```

```Java
class Solution {
    private long quickMul(long x, long y, long m) {
        long res = 1;
        while (y > 0) {
            if ((y & 1) == 1) {
                res = (res * x) % m;
            }
            y >>= 1;
            x = (x * x) % m;
        }
        return res;
    }

    public int[] getFinalState(int[] nums, int k, int multiplier) {
        if (multiplier == 1) {
            return nums;
        }
        int n = nums.length, mx = 0;
        long m = 1000000007L;
        PriorityQueue<long[]> v = new PriorityQueue<>((x, y) -> {
            if (x[0] != y[0]) {
                return Long.compare(x[0], y[0]);
            } else {
                return Long.compare(x[1], y[1]);
            }
        });
        for (int i = 0; i < n; i++) {
            mx = Math.max(mx, nums[i]);
            v.offer(new long[]{nums[i], i});
        }
        for (; v.peek()[0] < mx && k > 0; k--) {
            long[] x = v.poll();
            x[0] *= multiplier;
            v.offer(x);
        }
        for (int i = 0; i < n; i++) {
            long[] x = v.poll();
            int t = k / n + (i < k % n ? 1 : 0);
            nums[(int)x[1]] = (int)((x[0] % m) * quickMul(multiplier, t, m) % m);
        }
        return nums;
    }
}
```

```CSharp
public class Solution {
    private long QuickMul(long x, long y, long m) {
        long res = 1;
        while (y > 0) {
            if ((y & 1) == 1) {
                res = (res * x) % m;
            }
            y >>= 1;
            x = (x * x) % m;
        }
        return res;
    }

    public int[] GetFinalState(int[] nums, int k, int multiplier) {
        if (multiplier == 1) {
            return nums;
        }
        int n = nums.Length, mx = 0;
        long m = 1000000007L;
        var pq = new PriorityQueue<long[], long[]>(Comparer<long[]>.Create((x, y) => {
            if (x[0] != y[0]) {
                return x[0].CompareTo(y[0]);
            } else {
                return x[1].CompareTo(y[1]);
            }
        }));
        for (int i = 0; i < n; i++) {
            mx = Math.Max(mx, nums[i]);
            pq.Enqueue(new long[]{nums[i], i}, new long[]{nums[i], i});
        }
        for (; pq.Peek()[0] < mx && k > 0; k--) {
            var x = pq.Dequeue();
            x[0] *= multiplier;
            pq.Enqueue(x, x);
        }
        for (int i = 0; i < n; i++) {
            var x = pq.Dequeue();
            int t = k / n + (i < k % n ? 1 : 0);
            nums[(int)x[1]] = (int)((x[0] % m) * QuickMul(multiplier, t, m) % m);
        }
        return nums;
    }
}
```

```JavaScript
var getFinalState = function(nums, k, multiplier) {
    const quickMul = (x, y, m) => {
        let res = BigInt(1);
        while (y > 0n) {
            if (y % 2n === 1n) {
                res = (res * x) % m;
            }
            y >>= 1n;
            x = (x * x) % m;
        }
        return res;
    };

    if (multiplier === 1) {
        return nums;
    }
    const n = nums.length;
    const m = 1000000007;
    let mx = 0;
    const pq = new MinPriorityQueue({
        priority: (a) => a.first * 100000 + a.second
    });
    for (let i = 0; i < n; i++) {
        mx = Math.max(mx, nums[i]);
        pq.enqueue({
            first: nums[i],
            second: i
        });
    }
    for (; pq.front().element.first < mx && k > 0; k--) {
        let x = pq.dequeue().element;
        x.first *= multiplier;
        pq.enqueue(x);
    }
    for (let i = 0; i < n; i++) {
        let x = pq.dequeue().element;
        const t = Math.floor(k / n) + (i < k % n ? 1 : 0);
        nums[x.second] = Number(((BigInt(x.first) % BigInt(m)) * quickMul(BigInt(multiplier), BigInt(t), BigInt(m))) % BigInt(m));
    }
    return nums;
};
```

```TypeScript
function getFinalState(nums: number[], k: number, multiplier: number): number[] {
    const quickMul = (x: bigint, y: bigint, m: bigint): bigint => {
        let res = 1n;
        while (y > 0n) {
            if (y % 2n === 1n) {
                res = (res * x) % m;
            }
            y >>= 1n;
            x = (x * x) % m;
        }
        return res;
    };

    if (multiplier === 1) {
        return nums;
    }
    const n = nums.length;
    const m = 1000000007;
    let mx = 0;
    const pq = new MinPriorityQueue({
        priority: (a) => a.first * 100000 + a.second
    });
    for (let i = 0; i < n; i++) {
        mx = Math.max(mx, nums[i]);
        pq.enqueue({
            first: nums[i],
            second: i
        });
    }
    for (; pq.front().element.first < mx && k > 0; k--) {
        let x = pq.dequeue().element;
        x.first *= multiplier;
        pq.enqueue(x);
    }
    for (let i = 0; i < n; i++) {
        let x = pq.dequeue().element;
        const t = Math.floor(k / n) + (i < k % n ? 1 : 0);
        nums[x.second] = Number(((BigInt(x.first) % BigInt(m)) * quickMul(BigInt(multiplier), BigInt(t), BigInt(m))) % BigInt(m));
    }
    return nums;
}
```

```Rust
use std::cmp::Reverse;
use std::collections::BinaryHeap;

impl Solution {
    fn quick_mul(x: i64, y: i64, m: i64) -> i64 {
        let mut res = 1;
        let mut x = x;
        let mut y = y;
        while y > 0 {
            if y % 2 == 1 {
                res = (res * x) % m;
            }
            x = (x * x) % m;
            y /= 2;
        }
        res
    }

    pub fn get_final_state(nums: Vec<i32>, k: i32, multiplier: i32) -> Vec<i32> {
        if multiplier == 1 {
            return nums;
        }
        let n = nums.len();
        let m = 1_000_000_007;
        let mx = *nums.iter().max().unwrap() as i64;
        let mut v: BinaryHeap<Reverse<(i64, usize)>> = nums.into_iter()
            .enumerate()
            .map(|(i, num)| Reverse((num as i64, i)))
            .collect();

        let mut k = k as i64;
        while let Some(Reverse((val, _))) = v.peek() {
            if *val >= mx || k == 0 {
                break;
            }
            let Reverse((mut min_val, idx)) = v.pop().unwrap();
            min_val *= multiplier as i64;
            v.push(Reverse((min_val, idx)));
            k -= 1;
        }

        let mut result = vec![0; n];
        let mut vec_v = v.into_vec();
        vec_v.sort_unstable_by_key(|Reverse((val, idx))| (*val, *idx));

        for (i, Reverse((val, idx))) in vec_v.iter().enumerate() {
            let t = k / n as i64 + if (i as i64) < k % n as i64 { 1 } else { 0 };
            result[*idx] = ((val % m) * Solution::quick_mul(multiplier as i64, t, m) % m) as i32;
        }
        result
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \times (lognlogmx+log\frac{k}{n}))$。其中 $n$ 是数组 $nums$ 的长度，$k$ 是操作次数，$mx$ 是数组 $nums$ 的最大值。优先队列的出队和入队每个元素最多执行的次数为 $O(logmx)$，所以时间复杂度为 $O(nlognlogmx)$；批量执行时，每个元素执行一次的时间复杂度为 $O(log\frac{k}{n})$，所以时间复杂度为 $O(nlog\frac{k}{n})$。
- 空间复杂度：$O(n)$。主要为优先队列需要的空间。
