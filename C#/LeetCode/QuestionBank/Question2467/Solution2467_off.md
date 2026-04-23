### [等值距离和](https://leetcode.cn/problems/sum-of-distances/solutions/3950426/deng-zhi-ju-chi-he-by-leetcode-solution-8bun/)

#### 方法一：分组 + 前缀和

对于每个下标 $i$，我们需要计算所有与 $nums[i]$ 相等的下标 $j$ 的 $\vert i-j\vert$ 之和。

首先，将所有相同值的下标分到同一组中（使用哈希表）。对于某一组下标 $a_0<a_1<\dots <a_{m-1}$，考虑如何快速计算每个 $a_i$ 对应的答案。

对 $a_i$ 而言：

$$res[a_i]=\sum\limits_{j=0}^{m-1}\vert a_i-a_j\vert$$

由于组内下标已排序，可以拆成两部分：

$$res[a_i]=\sum\limits_{j=0}^{i-1}(a_i-a_j)+\sum\limits_{j=i+1}^{m-1}(a_j-a_i)$$

设 $S$ 为组内所有下标之和，$P_i=\sum\limits_{j=0}^{i-1}a_j$ 为前缀和（即 $a_0+\dots +a_{i-1}$）。下面把两个和式分别拆开再合并。

**左边**（$j<i$，共 $i$ 项）：

$$\sum\limits_{j=0}^{i-1}(a_i-a_j)=\sum\limits_{j=0}^{i-1}a_i-\sum\limits_{j=0}^{i-1}a_j=i\times a_i-P_i$$

**右边**（$j>i$，共 $m-i-1$ 项）。$\sum\limits_{j=i+1}^{m-1}a_j$ 等于全体和 $S$ 去掉下标 $\le i$ 的部分，即 $S-P_i-a_i$；每一项都减去 $a_i$，故再减去 $(m-i-1)\times a_i$：

$$\sum\limits_{j=i+1}^{m-1}(a_j-a_i)=(S-P_i-a_i)-(m-i-1)\times a_i$$

**合并**左右两边：

$$\begin{array}{rcl}res[a_i] & = & (i\times a_i-P_i)+((S-P_i-a_i)-(m-i-1)\times a_i) \\ & = & S-2P_i+a_i\times (2i-m)\end{array}$$

遍历每组，维护前缀和 $P_i$ 即可在 $O(m)$ 时间内计算该组所有答案。所有组的大小之和为 $n$，因此总时间为 $O(n)$。

```C++
class Solution {
public:
    vector<long long> distance(vector<int>& nums) {
        int n = nums.size();
        unordered_map<int, vector<int>> groups;
        for (int i = 0; i < n; i++) {
            groups[nums[i]].push_back(i);
        }
        vector<long long> res(n);
        for (const auto& p : groups) {
            const auto& group = p.second;
            long long total = accumulate(group.begin(), group.end(), 0LL);
            long long prefixTotal = 0;
            for (int i = 0; i < group.size(); i++) {
                res[group[i]] = total - prefixTotal * 2 + group[i] * (2 * i - group.size());
                prefixTotal += group[i];
            }
        }
        return res;
    }
};
```

```Go
func distance(nums []int) []int64 {
    n := len(nums)
    groups := make(map[int][]int)
    for i := 0; i < n; i++ {
        groups[nums[i]] = append(groups[nums[i]], i)
    }
    res := make([]int64, n)
    for _, group := range groups {
        var total int64
        for _, idx := range group {
            total += int64(idx)
        }
        var prefixTotal int64
        for i, idx := range group {
            res[idx] = total - prefixTotal * 2 + int64(idx) * int64(2 * i - len(group))
            prefixTotal += int64(idx)
        }
    }
    return res
}
```

```Python
class Solution:
    def distance(self, nums: list[int]) -> list[int]:
        n = len(nums)
        groups = defaultdict(list)
        for i, v in enumerate(nums):
            groups[v].append(i)
        res = [0] * n
        for group in groups.values():
            total = sum(group)
            prefix_total = 0
            sz = len(group)
            for i, idx in enumerate(group):
                res[idx] = total - prefix_total * 2 + idx * (2 * i - sz)
                prefix_total += idx
        return res
```

```Java
class Solution {
    public long[] distance(int[] nums) {
        int n = nums.length;
        Map<Integer, List<Integer>> groups = new HashMap<>();
        for (int i = 0; i < n; i++) {
            groups.computeIfAbsent(nums[i], k -> new ArrayList<>()).add(i);
        }
        long[] res = new long[n];
        for (List<Integer> group : groups.values()) {
            long total = 0;
            for (int idx : group) {
                total += idx;
            }
            long prefixTotal = 0;
            int sz = group.size();
            for (int i = 0; i < sz; i++) {
                int idx = group.get(i);
                res[idx] = total - prefixTotal * 2 + (long) idx * (2 * i - sz);
                prefixTotal += idx;
            }
        }
        return res;
    }
}
```

```TypeScript
function distance(nums: number[]): number[] {
    const n = nums.length;
    const groups = new Map<number, number[]>();
    for (let i = 0; i < n; i++) {
        if (!groups.has(nums[i])) {
            groups.set(nums[i], []);
        }
        groups.get(nums[i])!.push(i);
    }
    const res = new Array(n).fill(0);
    for (const group of groups.values()) {
        let total = 0;
        for (const idx of group) {
            total += idx;
        }
        let prefixTotal = 0;
        const sz = group.length;
        for (let i = 0; i < sz; i++) {
            const idx = group[i];
            res[idx] = total - prefixTotal * 2 + idx * (2 * i - sz);
            prefixTotal += idx;
        }
    }
    return res;
}
```

```JavaScript
var distance = function(nums) {
    const n = nums.length;
    const groups = new Map();
    for (let i = 0; i < n; i++) {
        if (!groups.has(nums[i])) {
            groups.set(nums[i], []);
        }
        groups.get(nums[i]).push(i);
    }
    const res = new Array(n).fill(0);
    for (const group of groups.values()) {
        let total = 0;
        for (const idx of group) {
            total += idx;
        }
        let prefixTotal = 0;
        const sz = group.length;
        for (let i = 0; i < sz; i++) {
            const idx = group[i];
            res[idx] = total - prefixTotal * 2 + idx * (2 * i - sz);
            prefixTotal += idx;
        }
    }
    return res;
};
```

```CSharp
public class Solution {
    public long[] Distance(int[] nums) {
        int n = nums.Length;
        var groups = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++) {
            if (!groups.ContainsKey(nums[i])) {
                groups[nums[i]] = new List<int>();
            }
            groups[nums[i]].Add(i);
        }
        long[] res = new long[n];
        foreach (var group in groups.Values) {
            long total = 0;
            foreach (int idx in group) {
                total += idx;
            }
            long prefixTotal = 0;
            int sz = group.Count;
            for (int i = 0; i < sz; i++) {
                int idx = group[i];
                res[idx] = total - prefixTotal * 2 + (long)idx * (2 * i - sz);
                prefixTotal += idx;
            }
        }
        return res;
    }
}
```

```C
typedef struct {
    int key;
    int* indices;
    int count;
    int capacity;
    UT_hash_handle hh;
} Group;

long long* distance(int* nums, int numsSize, int* returnSize) {
    *returnSize = numsSize;
    long long* res = (long long*)calloc(numsSize, sizeof(long long));
    Group* map = NULL;

    for (int i = 0; i < numsSize; i++) {
        Group* g = NULL;
        HASH_FIND_INT(map, &nums[i], g);
        if (!g) {
            g = (Group*)malloc(sizeof(Group));
            g->key = nums[i];
            g->capacity = 16;
            g->indices = (int*)malloc(g->capacity * sizeof(int));
            g->count = 0;
            HASH_ADD_INT(map, key, g);
        }
        if (g->count == g->capacity) {
            g->capacity *= 2;
            g->indices = (int*)realloc(g->indices, g->capacity * sizeof(int));
        }
        g->indices[g->count++] = i;
    }

    Group *g, *tmp;
    HASH_ITER(hh, map, g, tmp) {
        long long total = 0;
        for (int j = 0; j < g->count; j++) {
            total += g->indices[j];
        }
        long long prefixTotal = 0;
        for (int j = 0; j < g->count; j++) {
            int idx = g->indices[j];
            res[idx] = total - prefixTotal * 2 + (long long)idx * (2 * j - g->count);
            prefixTotal += idx;
        }
        HASH_DEL(map, g);
        free(g->indices);
        free(g);
    }

    return res;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn distance(nums: Vec<i32>) -> Vec<i64> {
        let n = nums.len();
        let mut groups: HashMap<i32, Vec<usize>> = HashMap::new();
        for (i, &v) in nums.iter().enumerate() {
            groups.entry(v).or_default().push(i);
        }
        let mut res = vec![0i64; n];
        for group in groups.values() {
            let total: i64 = group.iter().map(|&x| x as i64).sum();
            let mut prefix_total: i64 = 0;
            let sz = group.len() as i64;
            for (i, &idx) in group.iter().enumerate() {
                res[idx] = total - prefix_total * 2 + idx as i64 * (2 * i as i64 - sz);
                prefix_total += idx as i64;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为数组 $nums$ 的长度。分组遍历一次，计算答案遍历一次，总计 $O(n)$。
- 空间复杂度：$O(n)$。哈希表存储所有下标需要 $O(n)$ 的空间。
