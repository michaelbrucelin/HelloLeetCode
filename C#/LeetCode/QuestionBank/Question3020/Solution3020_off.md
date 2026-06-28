### [子集中元素的最大数量](https://leetcode.cn/problems/find-the-maximum-number-of-elements-in-subset/solutions/3984752/zi-ji-zhong-yuan-su-de-zui-da-shu-liang-5w5ze/)

#### 方法一：哈希表 $+$ 枚举

**思路与算法**

题目要求我们在给定的数组中寻找一个元素尽可能多的“山峰子数组”，其遵循先递增后递减的规律，递增过程中下一个元素的次方数是前一个数的 $2$ 倍，递减过程中下一个元素的次方数是前一个数的 $21$ 倍。

由于递增的速度极快，在题目给定的范围下，该山峰子数组的最大长度很小。设给定数组的最大值为 $m$，选出的山峰子数组的第一个元素为 $x$，则其中的第 $p+1$ 个元素为 $x^{2^p}$。当 $x\ge 2$ 时，有 $x^{2^p}\le m$，即 $p\le \log \log m$，p 最多为 $4$。

因此，我们可以枚举数组中的每一个数作为“山峰子数组”的起始元素 $x$，然后查看 $x^2$，$x^4$，$\dots $ 在数组中的数量是否大于等于 $2$。

由于山顶的元素只有 $1$ 个，山峰子数组的长度总是奇数。在我们枚举完所有成对的元素后，如果存在单个的山顶元素，则总长度加 $1$，否则去掉一个成对元素作为山顶，总长度减 $1$。此外，还要特别考虑山峰子数组的所有元素均为 $1$ 的情况。

**实现**

```C++
class Solution {
public:
    int maximumLength(vector<int>& nums) {
        unordered_map<long long, int> cnt;
        for (int num : nums) {
            cnt[num]++;
        }
        int ans = 0;
        // ans 至少是 1 的数量，向下取奇数
        if (cnt[1] % 2 == 0) {
            ans = cnt[1] - 1;
        } else {
            ans = cnt[1];
        }
        cnt.erase(1);
        for (auto& [num, _] : cnt) {
            int res = 0;
            long long x = num;
            for (; cnt.contains(x) && cnt[x] > 1; x *= x) {
                res += 2;
            }
            ans = max(ans, res + (cnt.contains(x) ? 1 : -1));
        }
        return ans;
    }
};
```

```Python
class Solution:
    def maximumLength(self, nums: List[int]) -> int:
        cnt = Counter(nums)

        one_cnt = cnt.get(1, 0)

        # ans 至少是 1 的数量，向下取奇数
        ans = one_cnt if one_cnt % 2 else one_cnt - 1

        cnt.pop(1, None)

        for num in cnt:
            res = 0
            x = num
            while x in cnt and cnt[x] > 1:
                res += 2
                x *= x
            ans = max(ans, res + (1 if x in cnt else -1))

        return ans
```

```Java
class Solution {
    public int maximumLength(int[] nums) {
        Map<Long, Integer> cnt = new HashMap<>();
        for (int num : nums) {
            cnt.merge((long) num, 1, Integer::sum);
        }

        int oneCnt = cnt.getOrDefault(1L, 0);
        // ans 至少是 1 的数量，向下取奇数
        int ans = (oneCnt & 1) == 1 ? oneCnt : oneCnt - 1;

        cnt.remove(1L);

        for (long num : cnt.keySet()) {
            int res = 0;
            long x = num;

            while (cnt.containsKey(x) && cnt.get(x) > 1) {
                res += 2;
                x *= x;
            }

            ans = Math.max(ans, res + (cnt.containsKey(x) ? 1 : -1));
        }

        return ans;
    }
}
```

```Go
func maximumLength(nums []int) int {
    cnt := map[int64]int{}
    for _, num := range nums {
        cnt[int64(num)]++
    }

    // ans 至少是 1 的数量，向下取奇数
    oneCnt := cnt[1]
    ans := oneCnt
    if oneCnt%2 == 0 {
        ans--
    }

    delete(cnt, 1)

    for num := range cnt {
        res := 0
        x := num

        for cnt[x] > 1 {
            res += 2
            x *= x
        }

        if _, ok := cnt[x]; ok {
            ans = max(ans, res+1)
        } else {
            ans = max(ans, res-1)
        }
    }

    return ans
}
```

```C
typedef struct {
    long long key;
    int cnt;
    UT_hash_handle hh;
} HashNode;

static HashNode* find(HashNode* map, long long key) {
    HashNode* p;
    HASH_FIND(hh, map, &key, sizeof(key), p);
    return p;
}

int maximumLength(int* nums, int numsSize) {
    HashNode* map = NULL;

    for (int i = 0; i < numsSize; i++) {
        long long key = nums[i];
        HashNode* p = find(map, key);

        if (p == NULL) {
            p = malloc(sizeof(HashNode));
            p->key = key;
            p->cnt = 1;
            HASH_ADD(hh, map, key, sizeof(key), p);
        } else {
            p->cnt++;
        }
    }

    HashNode* p = find(map, 1);
    // ans 至少是 1 的数量，向下取奇数
    int oneCnt = p ? p->cnt : 0;
    int ans = (oneCnt & 1) ? oneCnt : oneCnt - 1;

    if (p) {
        HASH_DEL(map, p);
        free(p);
    }

    HashNode *cur, *tmp;
    HASH_ITER(hh, map, cur, tmp) {
        int res = 0;
        long long x = cur->key;

        while ((p = find(map, x)) && p->cnt > 1) {
            res += 2;
            x *= x;
        }

        int cand = res + (find(map, x) ? 1 : -1);
        if (cand > ans) {
            ans = cand;
        }
    }

    HASH_ITER(hh, map, cur, tmp) {
        HASH_DEL(map, cur);
        free(cur);
    }

    return ans;
}
```

```CSharp
public class Solution {
    public int MaximumLength(int[] nums) {
        var cnt = new Dictionary<long, int>();

        foreach (int num in nums) {
            cnt.TryGetValue(num, out int c);
            cnt[num] = c + 1;
        }

        // ans 至少是 1 的数量，向下取奇数
        cnt.TryGetValue(1, out int oneCnt);
        int ans = (oneCnt & 1) == 1 ? oneCnt : oneCnt - 1;

        cnt.Remove(1);

        foreach (long num in cnt.Keys) {
            int res = 0;
            long x = num;

            while (cnt.TryGetValue(x, out int c) && c > 1) {
                res += 2;
                x *= x;
            }

            ans = Math.Max(ans, res + (cnt.ContainsKey(x) ? 1 : -1));
        }

        return ans;
    }
}
```

```JavaScript
var maximumLength = function(nums) {
    const cnt = new Map();

    for (const num of nums) {
        cnt.set(num, (cnt.get(num) || 0) + 1);
    }

    // ans 至少是 1 的数量，向下取奇数
    const oneCnt = cnt.get(1) || 0;
    let ans = oneCnt % 2 ? oneCnt : oneCnt - 1;

    cnt.delete(1);

    for (const num of cnt.keys()) {
        let res = 0;
        let x = num;

        while (cnt.has(x) && cnt.get(x) > 1) {
            res += 2;
            x *= x;
        }

        ans = Math.max(ans, res + (cnt.has(x) ? 1 : -1));
    }

    return ans;
};
```

```TypeScript
function maximumLength(nums: number[]): number {
    const cnt = new Map<number, number>();

    for (const num of nums) {
        cnt.set(num, (cnt.get(num) ?? 0) + 1);
    }

    // ans 至少是 1 的数量，向下取奇数
    const oneCnt = cnt.get(1) ?? 0;
    let ans = oneCnt % 2 ? oneCnt : oneCnt - 1;

    cnt.delete(1);

    for (const num of cnt.keys()) {
        let res = 0;
        let x = num;

        while (cnt.has(x) && cnt.get(x)! > 1) {
            res += 2;
            x *= x;
        }

        ans = Math.max(ans, res + (cnt.has(x) ? 1 : -1));
    }

    return ans;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn maximum_length(nums: Vec<i32>) -> i32 {
        let mut cnt: HashMap<i64, i32> = HashMap::new();

        for num in nums {
            *cnt.entry(num as i64).or_insert(0) += 1;
        }

        // ans 至少是 1 的数量，向下取奇数
        let one_cnt = *cnt.get(&1).unwrap_or(&0);
        let mut ans = if one_cnt % 2 == 1 {
            one_cnt
        } else {
            one_cnt - 1
        };

        cnt.remove(&1);

        for &num in cnt.keys() {
            let mut res = 0;
            let mut x = num;

            while matches!(cnt.get(&x), Some(&c) if c > 1) {
                res += 2;
                x *= x;
            }

            ans = ans.max(res + if cnt.contains_key(&x) { 1 } else { -1 });
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log \log M)$，其中 $n$ 是 $nums$ 的长度，$M$ 是 $nums$ 的最大值。我们以数组中的每个元素作为起点枚举子数组，每个子数组的长度最大为 $\log \log M$。
- 空间复杂度：$O(n)$。即为哈希表所占用的空间。
