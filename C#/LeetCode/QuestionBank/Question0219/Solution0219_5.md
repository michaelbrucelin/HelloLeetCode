#### [方法二：滑动窗口](https://leetcode.cn/problems/contains-duplicate-ii/solutions/1218075/cun-zai-zhong-fu-yuan-su-ii-by-leetcode-kluvk/)

考虑数组 $nums$ 中的每个长度不超过 $k + 1$ 的滑动窗口，同一个滑动窗口中的任意两个下标差的绝对值不超过 $k$。如果存在一个滑动窗口，其中有重复元素，则存在两个不同的下标 $i$ 和 $j$ 满足 $nums[i] = nums[j]$ 且 ∣$|i - j| \le k$。如果所有滑动窗口中都没有重复元素，则不存在符合要求的下标。因此，只要遍历每个滑动窗口，判断滑动窗口中是否有重复元素即可。

如果一个滑动窗口的结束下标是 $i$，则该滑动窗口的开始下标是 $\max(0, i - k)$。可以使用哈希集合存储滑动窗口中的元素。从左到右遍历数组 $nums$，当遍历到下标 $i$ 时，具体操作如下：

1.  如果 $i > k$，则下标 $i - k - 1$ 处的元素被移出滑动窗口，因此将 $nums[i−k−1]$ 从哈希集合中删除；
2.  判断 $nums[i]$ 是否在哈希集合中，如果在哈希集合中则在同一个滑动窗口中有重复元素，返回 $true$，如果不在哈希集合中则将其加入哈希集合。

当遍历结束时，如果所有滑动窗口中都没有重复元素，返回 $false$。

```java
class Solution {
    public boolean containsNearbyDuplicate(int[] nums, int k) {
        Set<Integer> set = new HashSet<Integer>();
        int length = nums.length;
        for (int i = 0; i < length; i++) {
            if (i > k) {
                set.remove(nums[i - k - 1]);
            }
            if (!set.add(nums[i])) {
                return true;
            }
        }
        return false;
    }
}
```

```csharp
public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        ISet<int> set = new HashSet<int>();
        int length = nums.Length;
        for (int i = 0; i < length; i++) {
            if (i > k) {
                set.Remove(nums[i - k - 1]);
            }
            if (!set.Add(nums[i])) {
                return true;
            }
        }
        return false;
    }
}
```

```cpp
class Solution {
public:
    bool containsNearbyDuplicate(vector<int>& nums, int k) {
        unordered_set<int> s;
        int length = nums.size();
        for (int i = 0; i < length; i++) {
            if (i > k) {
                s.erase(nums[i - k - 1]);
            }
            if (s.count(nums[i])) {
                return true;
            }
            s.emplace(nums[i]);
        }
        return false;
    }
};
```

```c
struct HashEntry {
    int key;
    int val;
    UT_hash_handle hh;
};

void hashAddItem(struct HashEntry **obj, int key, int val) {
    struct HashEntry *pEntry;
    pEntry = malloc(sizeof(struct HashEntry));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
} 

struct HashEntry *hashFindItem(const struct HashEntry **obj, int key)
{
    struct HashEntry *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

void hashEraseItem(struct HashEntry **obj, int key)
{   
    struct HashEntry *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    if (NULL != pEntry) {
        HASH_DEL(*obj, pEntry);
        free(pEntry);
    }
}

void hashFreeAll(struct HashEntry **obj)
{
    struct HashEntry *curr, *next;
    HASH_ITER(hh, *obj, curr, next)
    {
        HASH_DEL(*obj,curr);  
        free(curr);      
    }
}

bool containsNearbyDuplicate(int* nums, int numsSize, int k){
    struct HashEntry *cnt = NULL;
    for (int i = 0; i < numsSize; i++) {
        if (i > k) {
            hashEraseItem(&cnt, nums[i - k - 1]);
        }
        struct HashEntry * pEntry = hashFindItem(&cnt, nums[i]);
        if (NULL != pEntry) {
            return true;
        }
        hashAddItem(&cnt, nums[i], 1);
    }
    hashFreeAll(&cnt);
    return false;
}
```

```python
class Solution:
    def containsNearbyDuplicate(self, nums: List[int], k: int) -> bool:
        s = set()
        for i, num in enumerate(nums):
            if i > k:
                s.remove(nums[i - k - 1])
            if num in s:
                return True
            s.add(num)
        return False
```

```go
func containsNearbyDuplicate(nums []int, k int) bool {
    set := map[int]struct{}{}
    for i, num := range nums {
        if i > k {
            delete(set, nums[i-k-1])
        }
        if _, ok := set[num]; ok {
            return true
        }
        set[num] = struct{}{}
    }
    return false
}
```

```javascript
var containsNearbyDuplicate = function(nums, k) {
    const set = new Set();
    const length = nums.length;
    for (let i = 0; i < length; i++) {
        if (i > k) {
            set.delete(nums[i - k - 1]);
        }
        if (set.has(nums[i])) {
            return true;
        }
        set.add(nums[i])
    }
    return false;
};
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。需要遍历数组一次，对于每个元素，哈希集合的操作时间都是 $O(1)$。
-   空间复杂度：$O(k)$，其中 $k$ 是判断重复元素时允许的下标差的绝对值的最大值。需要使用哈希集合存储滑动窗口中的元素，任意时刻滑动窗口中的元素个数最多为 $k + 1$ 个。
