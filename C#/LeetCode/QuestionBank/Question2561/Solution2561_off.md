### [重排水果](https://leetcode.cn/problems/rearranging-fruits/solutions/3729209/zhong-pai-shui-guo-by-leetcode-solution-9z2g/)

#### 方法一：贪心

根据题意，任一水果的成本 $x$ 在两个果篮的总出现次数必定是偶数，否则无法将成本 $x$ 均分到两个果篮。为了获取两个果篮之间水果成本的差异，我们可以使用两个哈希表 $count_1$ 和 $count_2$ 分别统计两个果篮 $basket_1$ 和 $basket_2$ 的水果成本出现次数。对于水果成本 $x$：

1. 如果 $count_1[x]+count_2[x]$ 不为偶数，直接返回 $-1$。
2. 如果 $count_1[x]>count_2[x]$，那么果篮 $basket_1$ 中成本为 $x$ 的水果需要交换其中的 $\dfrac{count_1[x]-count_2[x]}{2}$ 个到果篮 $basket_2$，反之亦然。

根据第 $2$ 点，我们枚举所有成本 $x$，并将成本 $x$ 以待交换的数量放置到列表 $merge$ 中，然后对 $merge$ 从小到大进行排序。根据贪心配对的思想，将前一半与后一半进行交换可以最小化交换成本，两个成本 $x_1$ 和 $x_2$ 的交换方案有两种（$x_1<x_2$）：

1. 直接交换，交换成本为 $x_1$
2. 间接交换，即 $x_1$ 先与两个果篮中成本最小值 $m$ 交换，然后 $x_2$ 再与 $m$ 交换，交换成本为 $2\times m$

我们依次遍历列表 $merge$ 的前一半元素，令当前元素为 $x$，累计 $min(x,2\times m)$ 到最终交换成本。

```C++
class Solution {
public:
    long long minCost(vector<int>& basket1, vector<int>& basket2) {
        int m = INT_MAX;
        unordered_map<int, int> frequency_map;
        for (int b1 : basket1) {
            frequency_map[b1]++;
            m = min(m, b1);
        }
        for (int b2 : basket2) {
            frequency_map[b2]--;
            m = min(m, b2);
        }
        vector<int> merge;
        for (auto [k, c] : frequency_map) {
            if (c % 2 != 0) {
                return -1;
            }
            for (int i = 0; i < abs(c) / 2; ++i) {
                merge.push_back(k);
            }
        }
        nth_element(merge.begin(), merge.begin() + merge.size() / 2, merge.end());
        return accumulate(merge.begin(), merge.begin() + merge.size() / 2, 0ll,
            [&](long long res, int x) -> long long {
                return res + min(2 * m, x);
            }
        );
    }
};
```

```Go
func minCost(basket1 []int, basket2 []int) int64 {
    freq := map[int]int{}
    m := math.MaxInt
    for _, b := range basket1 {
        freq[b]++
        if b < m {
            m = b
        }
    }
    for _, b := range basket2 {
        freq[b]--
        if b < m {
            m = b
        }
    }

    var merge []int
    for k, c := range freq {
        if c%2 != 0 {
            return -1
        }
        for i := 0; i < abs(c)/2; i++ {
            merge = append(merge, k)
        }
    }

    sort.Ints(merge)
    var res int64
    for i := 0; i < len(merge)/2; i++ {
        if 2*m < merge[i] {
            res += int64(2 * m)
        } else {
            res += int64(merge[i])
        }
    }
    return res
}

func abs(a int) int {
    if a < 0 {
        return -a
    }
    return a
}
```

```Python
class Solution:
    def minCost(self, basket1: List[int], basket2: List[int]) -> int:
        freq = Counter()
        m = float('inf')
        for b1 in basket1:
            freq[b1] += 1
            m = min(m, b1)
        for b2 in basket2:
            freq[b2] -= 1
            m = min(m, b2)

        merge = []
        for k, c in freq.items():
            if c % 2 != 0:
                return -1
            merge.extend([k] * (abs(c) // 2))

        if not merge:
            return 0
        merge.sort()
        return sum(min(2 * m, x) for x in merge[:len(merge) // 2])
```

```Java
class Solution {
    public long minCost(int[] basket1, int[] basket2) {
        TreeMap<Integer, Integer> freq = new TreeMap<>();
        int m = Integer.MAX_VALUE;
        for (int b1 : basket1) {
            freq.put(b1, freq.getOrDefault(b1, 0) + 1);
            m = Math.min(m, b1);
        }
        for (int b2 : basket2) {
            freq.put(b2, freq.getOrDefault(b2, 0) - 1);
            m = Math.min(m, b2);
        }

        List<Integer> merge = new ArrayList<>();
        for (var entry : freq.entrySet()) {
            int count = entry.getValue();
            if (count % 2 != 0) return -1;
            for (int i = 0; i < Math.abs(count) / 2; i++) {
                merge.add(entry.getKey());
            }
        }

        Collections.sort(merge);
        long res = 0;
        for (int i = 0; i < merge.size() / 2; i++) {
            res += Math.min(2 * m, merge.get(i));
        }
        return res;
    }
}
```

```TypeScript
function minCost(basket1: number[], basket2: number[]): number {
    const freq = new Map<number, number>();
    let m = Infinity;

    for (const b of basket1) {
        freq.set(b, (freq.get(b) || 0) + 1);
        m = Math.min(m, b);
    }
    for (const b of basket2) {
        freq.set(b, (freq.get(b) || 0) - 1);
        m = Math.min(m, b);
    }

    const merge: number[] = [];
    for (const [k, c] of freq.entries()) {
        if (c % 2 !== 0) return -1;
        for (let i = 0; i < Math.abs(c) / 2; i++) {
            merge.push(k);
        }
    }

    merge.sort((a, b) => a - b);
    let res = 0;
    for (let i = 0; i < merge.length / 2; i++) {
        res += Math.min(2 * m, merge[i]);
    }
    return res;
};
```

```JavaScript
var minCost = function(basket1, basket2) {
    const freq = new Map();
    let m = Infinity;

    for (const b of basket1) {
        freq.set(b, (freq.get(b) || 0) + 1);
        m = Math.min(m, b);
    }
    for (const b of basket2) {
        freq.set(b, (freq.get(b) || 0) - 1);
        m = Math.min(m, b);
    }

    const merge = [];
    for (const [k, c] of freq.entries()) {
        if (c % 2 !== 0) return -1;
        for (let i = 0; i < Math.abs(c) / 2; i++) {
            merge.push(k);
        }
    }

    merge.sort((a, b) => a - b);
    let res = 0;
    for (let i = 0; i < merge.length / 2; i++) {
        res += Math.min(2 * m, merge[i]);
    }
    return res;
};
```

```CSharp
public class Solution {
    public long MinCost(int[] basket1, int[] basket2) {
        var freq = new Dictionary<int, int>();
        int m = int.MaxValue;

        foreach (var b in basket1) {
            if (!freq.ContainsKey(b)) freq[b] = 0;
            freq[b]++;
            m = Math.Min(m, b);
        }
        foreach (var b in basket2) {
            if (!freq.ContainsKey(b)) freq[b] = 0;
            freq[b]--;
            m = Math.Min(m, b);
        }

        var merge = new List<int>();
        foreach (var kv in freq) {
            int c = kv.Value;
            if (c % 2 != 0) return -1;
            for (int i = 0; i < Math.Abs(c) / 2; i++) {
                merge.Add(kv.Key);
            }
        }

        merge.Sort();
        long res = 0;
        for (int i = 0; i < merge.Count / 2; i++) {
            res += Math.Min(2 * m, merge[i]);
        }
        return res;
    }
}
```

```C
typedef struct {
    int key;
    int count;
    UT_hash_handle hh;
} Hash;

void add(Hash **map, int key, int delta) {
    Hash *entry;
    HASH_FIND_INT(*map, &key, entry);
    if (!entry) {
        entry = (Hash *)malloc(sizeof(Hash));
        entry->key = key;
        entry->count = 0;
        HASH_ADD_INT(*map, key, entry);
    }
    entry->count += delta;
}

void free_map(Hash **map) {
    Hash *e, *tmp;
    HASH_ITER(hh, *map, e, tmp) {
        HASH_DEL(*map, e);
        free(e);
    }
}

int cmp(const void *a, const void *b) {
    return *(int *)a - *(int *)b;
}

long long minCost(int *basket1, int basket1Size, int *basket2, int basket2Size) {
    int m = INT_MAX;
    Hash *frequency_map = NULL;
    for (int i = 0; i < basket1Size; i++) {
        add(&frequency_map, basket1[i], 1);
        if (basket1[i] < m) m = basket1[i];
    }
    for (int i = 0; i < basket2Size; i++) {
        add(&frequency_map, basket2[i], -1);
        if (basket2[i] < m) m = basket2[i];
    }

    int *merge = (int *)malloc(sizeof(int) * (basket1Size + basket2Size));
    int mergeSize = 0;
    Hash *e, *tmp;
    HASH_ITER(hh, frequency_map, e, tmp) {
        int c = e->count;
        if (c % 2 != 0) {
            free(merge);
            free_map(&frequency_map);
            return -1;
        }
        for (int i = 0; i < abs(c) / 2; i++) {
            merge[mergeSize++] = e->key;
        }
    }

    if (mergeSize == 0) {
        free(merge);
        free_map(&frequency_map);
        return 0;
    }

    qsort(merge, mergeSize, sizeof(int), cmp);

    long long res = 0;
    for (int i = 0; i < mergeSize / 2; i++) {
        res += fmin(merge[i], m * 2);
    }

    free(merge);
    free_map(&frequency_map);
    return res;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn min_cost(basket1: Vec<i32>, basket2: Vec<i32>) -> i64 {
        let mut freq = HashMap::new();
        let mut m = i32::MAX;
        for &b in &basket1 {
            *freq.entry(b).or_insert(0) += 1;
            m = m.min(b);
        }
        for &b in &basket2 {
            *freq.entry(b).or_insert(0) -= 1;
            m = m.min(b);
        }

        let mut merge = vec![];
        for (&k, &v) in freq.iter() {
            if v % 2 != 0 {
                return -1;
            }
            for _ in 0..((v as i32).abs() / 2) {
                merge.push(k);
            }
        }

        merge.sort_unstable();
        let res: i64 = merge.iter().take(merge.len() / 2).map(|&x| i64::from(x.min(2 * m))).sum();
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \log n)$。
- 空间复杂度：$O(n)$。
