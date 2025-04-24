### [统计完全子数组的数目](https://leetcode.cn/problems/count-complete-subarrays-in-an-array/solutions/3650491/tong-ji-wan-quan-zi-shu-zu-de-shu-mu-by-ysvhb/)

#### 方法一：滑动窗口

**思路**

我们固定左边界 $left$，并用 $cnt$ 哈希表统计窗口中每个元素出现的次数。当窗口中不同元素的个数小于 $distinct$ 时，我们不断右移 $right$ 来扩大窗口；一旦窗口中不同元素个数等于 $distinct$，说明当前窗口 $[left,right)$ 是一个 **完全子数组**。此时，由于继续增加 $right$ 不会减少窗口中的不同元素个数，所以从 $right$ 到数组末尾的所有子数组也都是合法的 **完全子数组**，因此我们可以一次性计入这些解，即加上 $n-right+1$。

每次移动 $cnt$ 时，需要在哈希表中移除 $nums[textitleft]-1$ 的计数，如果次数减到 $0$，则从哈希表中删除该元素。

最后返回累加的结果即可。

**代码**

```Python
class Solution:
    def countCompleteSubarrays(self, nums: List[int]) -> int:
        res = 0
        cnt = {}
        n = len(nums)
        right = 0
        distinct = len(set(nums))
        for left in range(n):
            if left > 0:
                remove = nums[left - 1]
                cnt[remove] -= 1
                if cnt[remove] == 0:
                    cnt.pop(remove)
            while right < n and len(cnt) < distinct:
                add = nums[right]
                cnt[add] = cnt.get(add, 0) + 1
                right += 1
            if len(cnt) == distinct:
                res += (n - right + 1)
        return res
```

```Java
class Solution {
    public int countCompleteSubarrays(int[] nums) {
        int res = 0;
        Map<Integer, Integer> cnt = new HashMap<>();
        int n = nums.length;
        int right = 0;
        int distinct = new HashSet<>(Arrays.asList(Arrays.stream(nums).boxed().toArray(Integer[]::new))).size();
        
        for (int left = 0; left < n; left++) {
            if (left > 0) {
                int remove = nums[left - 1];
                cnt.put(remove, cnt.get(remove) - 1);
                if (cnt.get(remove) == 0) {
                    cnt.remove(remove);
                }
            }
            while (right < n && cnt.size() < distinct) {
                int add = nums[right];
                cnt.put(add, cnt.getOrDefault(add, 0) + 1);
                right++;
            }
            if (cnt.size() == distinct) {
                res += (n - right + 1);
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int CountCompleteSubarrays(int[] nums) {
        int res = 0;
        Dictionary<int, int> cnt = new Dictionary<int, int>();
        int n = nums.Length;
        int right = 0;
        int distinct = new HashSet<int>(nums).Count;
        
        for (int left = 0; left < n; left++) {
            if (left > 0) {
                int remove = nums[left - 1];
                cnt[remove]--;
                if (cnt[remove] == 0) {
                    cnt.Remove(remove);
                }
            }
            while (right < n && cnt.Count < distinct) {
                int add = nums[right];
                if (!cnt.ContainsKey(add)) {
                    cnt[add] = 0;
                }
                cnt[add]++;
                right++;
            }
            if (cnt.Count == distinct) {
                res += (n - right + 1);
            }
        }
        return res;
    }
}
```

```C++
class Solution {
public:
    int countCompleteSubarrays(vector<int>& nums) {
        int res = 0;
        unordered_map<int, int> cnt;
        int n = nums.size();
        int right = 0;
        unordered_set<int> distinct(nums.begin(), nums.end());
        int distinct_count = distinct.size();
        
        for (int left = 0; left < n; left++) {
            if (left > 0) {
                int remove = nums[left - 1];
                cnt[remove]--;
                if (cnt[remove] == 0) {
                    cnt.erase(remove);
                }
            }
            while (right < n && cnt.size() < distinct_count) {
                int add = nums[right];
                cnt[add]++;
                right++;
            }
            if (cnt.size() == distinct_count) {
                res += (n - right + 1);
            }
        }
        return res;
    }
};
```

```Go
func countCompleteSubarrays(nums []int) int {
    res := 0
    cnt := make(map[int]int)
    n := len(nums)
    right := 0
    distinct := make(map[int]bool)
    for _, num := range nums {
        distinct[num] = true
    }
    distinctCount := len(distinct)
    for left := 0; left < n; left++ {
        if left > 0 {
            remove := nums[left-1]
            cnt[remove]--
            if cnt[remove] == 0 {
                delete(cnt, remove)
            }
        }
        for right < n && len(cnt) < distinctCount {
            add := nums[right]
            cnt[add]++
            right++
        }
        if len(cnt) == distinctCount {
            res += (n - right + 1)
        }
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

void hashEraseItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    HASH_DEL(*obj, pEntry);
    free(pEntry);      
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

int countCompleteSubarrays(int* nums, int numsSize) {
    int res = 0;
    HashItem *cnt = NULL;
    int n = numsSize;
    int right = 0;
    HashItem *distinct = NULL;
    for (int i = 0; i < numsSize; i++) {
        hashAddItem(&distinct, nums[i], 1);
    }
    int distinct_count = HASH_COUNT(distinct);
    
    for (int left = 0; left < n; left++) {
        if (left > 0) {
            int remove = nums[left - 1];
            hashSetItem(&cnt, remove, hashGetItem(&cnt, remove, 0) - 1);
            if (hashGetItem(&cnt, remove, 0) == 0) {
                hashEraseItem(&cnt, remove);
            }
        }
        while (right < n && HASH_COUNT(cnt) < distinct_count) {
            int add = nums[right];
            hashSetItem(&cnt, add, hashGetItem(&cnt, add, 0) + 1);
            right++;
        }
        if (HASH_COUNT(cnt) == distinct_count) {
            res += (n - right + 1);
        }
    }
    hashFree(&cnt);
    return res;
}
```

```JavaScript
var countCompleteSubarrays = function(nums) {
    let res = 0;
    let cnt = new Map();
    const n = nums.length;
    let right = 0;
    const distinct = new Set(nums).size;
    
    for (let left = 0; left < n; left++) {
        if (left > 0) {
            const remove = nums[left - 1];
            cnt.set(remove, cnt.get(remove) - 1);
            if (cnt.get(remove) === 0) {
                cnt.delete(remove);
            }
        }
        while (right < n && cnt.size < distinct) {
            const add = nums[right];
            cnt.set(add, (cnt.get(add) || 0) + 1);
            right++;
        }
        if (cnt.size === distinct) {
            res += (n - right + 1);
        }
    }
    return res;
}
```

```TypeScript
function countCompleteSubarrays(nums: number[]): number {
    let res = 0;
    let cnt = new Map<number, number>();
    const n = nums.length;
    let right = 0;
    const distinct = new Set(nums).size;
    
    for (let left = 0; left < n; left++) {
        if (left > 0) {
            const remove = nums[left - 1];
            cnt.set(remove, cnt.get(remove)! - 1);
            if (cnt.get(remove) === 0) {
                cnt.delete(remove);
            }
        }
        while (right < n && cnt.size < distinct) {
            const add = nums[right];
            cnt.set(add, (cnt.get(add) || 0) + 1);
            right++;
        }
        if (cnt.size === distinct) {
            res += (n - right + 1);
        }
    }
    return res;
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn count_complete_subarrays(nums: Vec<i32>) -> i32 {
        let mut res = 0;
        let mut cnt = HashMap::new();
        let n = nums.len();
        let mut right = 0;
        let distinct = nums.iter().collect::<std::collections::HashSet<_>>().len();
        
        for left in 0..n {
            if left > 0 {
                let remove = nums[left - 1];
                *cnt.get_mut(&remove).unwrap() -= 1;
                if cnt[&remove] == 0 {
                    cnt.remove(&remove);
                }
            }
            while right < n && cnt.len() < distinct {
                let add = nums[right];
                *cnt.entry(add).or_insert(0) += 1;
                right += 1;
            }
            if cnt.len() == distinct {
                res += (n - right + 1) as i32;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。双指针 $left$ 和 $right$ 各会对数组进行一次遍历。
- 空间复杂度：$O(n)$，即为哈希表 $cnt$ 需要使用的空间。
