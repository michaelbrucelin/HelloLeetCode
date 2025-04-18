### [统计坏数对的数目](https://leetcode.cn/problems/count-number-of-bad-pairs/solutions/3638890/tong-ji-pi-shu-dui-de-shu-mu-by-leetcode-04ya/)

#### 方法一：哈希表

**思路与算法**

题目中定义数组 $nums$ 的坏数对为两个下标不相同的整数 $nums[i]$ 和 $nums[j]$ 满足：

- $i<j$
- $j-i =nums[j]-nums[i]$

直接枚举所有数对的时间复杂度为 $O(n^2)$，其中 $n$ 是 $nums$ 的长度，容易超时。我们稍微观察一下条件，$j-i =nums[j]-nums[i]$ 可以移动不等式左右两边，将与 $i$ 相关的挪到一边，并将与 $j$ 相关的挪到另一边，即可得到：

$$nums[i]-i =nums[j]-j$$

因此，我们用哈希表去统计每一个 $nums[i]-i$ 的个数，并在从左到右遍历 $i$ 的过程中计算与之不同的个数，将其累加到答案中。遍历结束后可得题目所求。

**代码**

```C++
class Solution {
public:
    using ll = long long;
    long long countBadPairs(vector<int>& nums) {
        unordered_map<int, int> mp;
        ll res = 0;
        for (int i = 0; i < nums.size(); i++) {
            res += i - mp[nums[i] - i];
            mp[nums[i] - i]++;
        }
        return res;
    }
};
```

```Python
class Solution:
    def countBadPairs(self, nums: List[int]) -> int:
        mp = defaultdict(int)
        res = 0
        for i, x in enumerate(nums):
            res += i - mp[x - i]
            mp[x - i] += 1
        return res
```

```Rust
use std::collections::HashMap;
impl Solution {
    pub fn count_bad_pairs(nums: Vec<i32>) -> i64 {
        let mut h = HashMap::new();
        let mut res = 0 as i64;
        for (i, x) in nums.iter().enumerate() {
            let key = x - i as i32;
            res += i as i64 - *h.get(&key).unwrap_or(&0);
            *h.entry(key).or_default() += 1;
        }
        res
    }
}
```

```Java
class Solution {
    public long countBadPairs(int[] nums) {
        HashMap<Integer, Integer> mp = new HashMap<>();
        long res = 0;
        for (int i = 0; i < nums.length; i++) {
            int key = nums[i] - i;
            res += i - mp.getOrDefault(key, 0);
            mp.put(key, mp.getOrDefault(key, 0) + 1);
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public long CountBadPairs(int[] nums) {
        Dictionary<int, int> mp = new Dictionary<int, int>();
        long res = 0;
        for (int i = 0; i < nums.Length; i++) {
            int key = nums[i] - i;
            mp.TryGetValue(key, out int count);
            res += i - count;
            mp[key] = count + 1;
        }
        return res;
    }
}
```

```Go
func countBadPairs(nums []int) int64 {
    mp := make(map[int]int)
    var res int64 = 0
    for i := 0; i < len(nums); i++ {
        key := nums[i] - i
        res += int64(i - mp[key])
        mp[key]++
    }
    return res
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

long long countBadPairs(int* nums, int numsSize) {
    HashItem *mp = NULL;
    long long res = 0;
    for (int i = 0; i < numsSize; i++) {
        int val = hashGetItem(&mp, nums[i] - i, 0);
        res += i - val;
        hashSetItem(&mp, nums[i] - i, val + 1);
    }
    hashFree(&mp);
    return res;
}
```

```JavaScript
var countBadPairs = function(nums) {
    const mp = new Map();
    let res = 0;
    for (let i = 0; i < nums.length; i++) {
        const key = nums[i] - i;
        res += i - (mp.get(key) || 0);
        mp.set(key, (mp.get(key) || 0) + 1);
    }
    return res;
};
```

```TypeScript
function countBadPairs(nums: number[]): number {
    const mp = new Map<number, number>();
    let res = 0;
    for (let i = 0; i < nums.length; i++) {
        const key = nums[i] - i;
        res += i - (mp.get(key) || 0);
        mp.set(key, (mp.get(key) || 0) + 1);
    }
    return res;
};
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。使用哈希表插入和查询的时间复杂度是 $O(1)$，总共遍历 $n$ 个元素，因此时间复杂度为 $O(n)$。
- 空间复杂度：$O(n)$。哈希表的空间复杂度是 $O(n)$。
