### [统计好子数组的数目](https://leetcode.cn/problems/count-the-number-of-good-subarrays/solutions/3643775/tong-ji-hao-zi-shu-zu-de-shu-mu-by-leetc-uvcm/)

#### 方法一：双指针

**思路与算法**

根据题目中对于**好数组**的定义，如果 $nums[i..j]$ 是一个好数组，那么对于所有满足 $j′>j$ 的 $j′$，$nums[i..j′]$ 中相同的值不会更少，所以 $nums[i..j′]$ 也一定是一个好数组。

这就提示我们可以使用双指针的方法解决本题。我们枚举左指针 $left$ 表示子数组的左边界，它的初始值为 $0$，同时用右指针 $right$ 表示子数组的右边界，它的初始值为 $-1$。对于当前枚举到的 $left$，我们需要不断向右移动 $right$，直到 $nums[left..right]$ 是一个好数组。

在移动 $right$ 的过程中，我们可以增量计算相同元素的数量：我们可以使用一个哈希映射 $cnt$ 记录每一个子数组中的每一个元素，以及它出现的次数。让 $right$ 向右移动时，相同元素的数量增加了 $cnt[right]$，随后需要将 $cnt[right]$ 增加 $1$。待 $right$ 移动完成后，根据上面的推论，以 $left$ 为左边界的好子数组的数量即为 $n-right$，其中 $n$ 是数组 $nums$ 的长度。我们将这个值累加入最终的答案。

在这之后，当前的左边界 $left$ 枚举完成，相同的元素数量会减少 $cnt[left]-1$，随后也需要将 $cnt[left]$ 减少 $1$。

当所有的左边界都枚举完成后，即可得到最终的答案。

**代码**

```C++
class Solution {
public:
    long long countGood(vector<int>& nums, int k) {
        int n = nums.size();
        int same = 0, right = -1;
        unordered_map<int, int> cnt;
        long long ans = 0;
        for (int left = 0; left < n; ++left) {
            while (same < k && right + 1 < n) {
                ++right;
                same += cnt[nums[right]];
                ++cnt[nums[right]];
            }
            if (same >= k) {
                ans += n - right;
            }
            --cnt[nums[left]];
            same -= cnt[nums[left]];
        }
        return ans;
    }
};
```

```Python
class Solution:
    def countGood(self, nums: List[int], k: int) -> int:
        n = len(nums)
        same, right = 0, -1
        cnt = Counter()
        ans = 0
        for left in range(n):
            while same < k and right + 1 < n:
                right += 1
                same += cnt[nums[right]]
                cnt[nums[right]] += 1
            if same >= k:
                ans += n - right
            cnt[nums[left]] -= 1
            same -= cnt[nums[left]]
        return ans
```

```Java
class Solution {
    public long countGood(int[] nums, int k) {
        int n = nums.length;
        int same = 0, right = -1;
        HashMap<Integer, Integer> cnt = new HashMap<>();
        long ans = 0;
        for (int left = 0; left < n; ++left) {
            while (same < k && right + 1 < n) {
                ++right;
                same += cnt.getOrDefault(nums[right], 0);
                cnt.put(nums[right], cnt.getOrDefault(nums[right], 0) + 1);
            }
            if (same >= k) {
                ans += n - right;
            }
            cnt.put(nums[left], cnt.get(nums[left]) - 1);
            same -= cnt.get(nums[left]);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public long CountGood(int[] nums, int k) {
        int n = nums.Length;
        int same = 0, right = -1;
        Dictionary<int, int> cnt = new Dictionary<int, int>();
        long ans = 0;
        for (int left = 0; left < n; ++left) {
            while (same < k && right + 1 < n) {
                ++right;
                cnt.TryGetValue(nums[right], out int current);
                same += current;
                cnt[nums[right]] = current + 1;
            }
            if (same >= k) {
                ans += n - right;
            }
            cnt[nums[left]] = cnt[nums[left]] - 1;
            same -= cnt[nums[left]];
        }
        return ans;
    }
}
```

```Go
func countGood(nums []int, k int) int64 {
    n := len(nums)
    same, right := 0, -1
    cnt := make(map[int]int)
    var ans int64 = 0
    for left := 0; left < n; left++ {
        for same < k && right + 1 < n {
            right++
            same += cnt[nums[right]]
            cnt[nums[right]]++
        }
        if same >= k {
            ans += int64(n - right)
        }
        cnt[nums[left]]--
        same -= cnt[nums[left]]
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

long long countGood(int* nums, int numsSize, int k) {
    int n = numsSize;
    int same = 0, right = -1;
    HashItem *cnt = NULL;
    long long ans = 0;
    for (int left = 0; left < n; ++left) {
        while (same < k && right + 1 < n) {
            ++right;
            same += hashGetItem(&cnt, nums[right], 0);
            hashSetItem(&cnt, nums[right], hashGetItem(&cnt, nums[right], 0) + 1);
        }
        if (same >= k) {
            ans += n - right;
        }
        hashSetItem(&cnt, nums[left], hashGetItem(&cnt, nums[left], 0) - 1);
        same -= hashGetItem(&cnt, nums[left], 0);
    }
    hashFree(&cnt);
    return ans;
}
```

```JavaScript
var countGood = function(nums, k) {
    const n = nums.length;
    let same = 0, right = -1;
    const cnt = new Map();
    let ans = 0;
    for (let left = 0; left < n; ++left) {
        while (same < k && right + 1 < n) {
            ++right;
            same += cnt.get(nums[right]) || 0;
            cnt.set(nums[right], (cnt.get(nums[right]) || 0) + 1);
        }
        if (same >= k) {
            ans += n - right;
        }
        cnt.set(nums[left], cnt.get(nums[left]) - 1);
        same -= cnt.get(nums[left]);
    }
    return ans;
};
```

```TypeScript
function countGood(nums: number[], k: number): number {
    const n = nums.length;
    let same = 0, right = -1;
    const cnt = new Map<number, number>();
    let ans = 0;
    for (let left = 0; left < n; ++left) {
        while (same < k && right + 1 < n) {
            ++right;
            same += cnt.get(nums[right]) || 0;
            cnt.set(nums[right], (cnt.get(nums[right]) || 0) + 1);
        }
        if (same >= k) {
            ans += n - right;
        }
        cnt.set(nums[left], (cnt.get(nums[left]) || 0) - 1);
        same -= cnt.get(nums[left]) || 0;
    }
    return ans;
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn count_good(nums: Vec<i32>, k: i32) -> i64 {
        let n = nums.len();
        let mut same = 0;
        let mut right = -1;
        let mut cnt = HashMap::new();
        let mut ans = 0i64;
        for left in 0..n {
            while same < k && right + 1 < n as i32 {
                right += 1;
                let num = nums[right as usize];
                same += *cnt.get(&num).unwrap_or(&0);
                *cnt.entry(num).or_insert(0) += 1;
            }
            if same >= k {
                ans += (n as i64) - (right as i64);
            }
            let num = nums[left];
            *cnt.entry(num).or_insert(0) -= 1;
            same -= *cnt.get(&num).unwrap_or(&0);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。双指针 $left$ 和 $right$ 各会对数组进行一次遍历。
- 空间复杂度：$O(n)$，即为哈希表 $cnt$ 需要使用的空间。
