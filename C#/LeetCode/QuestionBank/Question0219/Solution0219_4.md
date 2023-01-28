#### [方法一：哈希表](https://leetcode.cn/problems/contains-duplicate-ii/solutions/1218075/cun-zai-zhong-fu-yuan-su-ii-by-leetcode-kluvk/)

从左到右遍历数组 $nums$，当遍历到下标 $i$ 时，如果存在下标 $j < i$ 使得 $nums[i] = nums[j]$，则当 $i - j \le k$ 时即找到了两个符合要求的下标 $j$ 和 $i$。

如果在下标 $i$ 之前存在多个元素都和 $nums[i]$ 相等，为了判断是否存在满足 $nums[i] = nums[j]$ 且 $i - j \le k$ 的下标 $j$，应该在这些元素中寻找下标最大的元素，将最大下标记为 $j$，判断 $i - j \le k$ 是否成立。

如果 $i - j \le k$，则找到了两个符合要求的下标 $j$ 和 $i$；如果 $i - j > k$，则在下标 $i$ 之前不存在任何元素满足与 $nums[i]$ 相等且下标差的绝对值不超过 $k$，理由如下。

> 假设存在下标 $j'$ 满足 $j' < j < i$ 且 $nums[j'] = nums[j] = nums[i]$，则 $i - j' > i - j$，由于 $i - j > k$，因此必有 $i - j' > k$。

因此，当遍历到下标 $i$ 时，如果在下标 $i$ 之前存在与 $nums[i]$ 相等的元素，应该在这些元素中寻找最大的下标 $j$，判断 $i - j \le k$ 是否成立。

可以使用哈希表记录每个元素的最大下标。从左到右遍历数组 $nums$，当遍历到下标 $i$ 时，进行如下操作：

1.  如果哈希表中已经存在和 $nums[i]$ 相等的元素且该元素在哈希表中记录的下标 $j$ 满足 $i - j \le k$，返回 $true$；
2.  将 $nums[i]$ 和下标 $i$ 存入哈希表，此时 $i$ 是 $nums[i]$ 的最大下标。

上述两步操作的顺序不能改变，因为当遍历到下标 $i$ 时，只能在下标 $i$ 之前的元素中寻找与当前元素相等的元素及该元素的最大下标。

当遍历结束时，如果没有遇到两个相等元素的下标差的绝对值不超过 $k$，返回 $false$。

```java
class Solution {
    public boolean containsNearbyDuplicate(int[] nums, int k) {
        Map<Integer, Integer> map = new HashMap<Integer, Integer>();
        int length = nums.length;
        for (int i = 0; i < length; i++) {
            int num = nums[i];
            if (map.containsKey(num) && i - map.get(num) <= k) {
                return true;
            }
            map.put(num, i);
        }
        return false;
    }
}
```

```csharp
public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        int length = nums.Length;
        for (int i = 0; i < length; i++) {
            int num = nums[i];
            if (dictionary.ContainsKey(num) && i - dictionary[num] <= k) {
                return true;
            }
            if (dictionary.ContainsKey(num)) {
                dictionary[num] = i;
            } else {
                dictionary.Add(num, i);
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
        unordered_map<int, int> dictionary;
        int length = nums.size();
        for (int i = 0; i < length; i++) {
            int num = nums[i];
            if (dictionary.count(num) && i - dictionary[num] <= k) {
                return true;
            }
            dictionary[num] = i;
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
    struct HashEntry *dictionary = NULL;
    for (int i = 0; i < numsSize; i++) {
        struct HashEntry * pEntry = hashFindItem(&dictionary, nums[i]);
        if (NULL != pEntry && i - pEntry->val <= k) {
            hashFreeAll(&dictionary);
            return true;
        }
        hashAddItem(&dictionary, nums[i], i);
    }
    hashFreeAll(&dictionary);
    return false;
}
```

```python
class Solution:
    def containsNearbyDuplicate(self, nums: List[int], k: int) -> bool:
        pos = {}
        for i, num in enumerate(nums):
            if num in pos and i - pos[num] <= k:
                return True
            pos[num] = i
        return False
```

```go
func containsNearbyDuplicate(nums []int, k int) bool {
    pos := map[int]int{}
    for i, num := range nums {
        if p, ok := pos[num]; ok && i-p <= k {
            return true
        }
        pos[num] = i
    }
    return false
}
```

```javascript
var containsNearbyDuplicate = function(nums, k) {
    const map = new Map();
    const length = nums.length;
    for (let i = 0; i < length; i++) {
        const num = nums[i];
        if (map.has(num) && i - map.get(num) <= k) {
            return true;
        }
        map.set(num, i);
    }
    return false;
};
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。需要遍历数组一次，对于每个元素，哈希表的操作时间都是 $O(1)$。
-   空间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。需要使用哈希表记录每个元素的最大下标，哈希表中的元素个数不会超过 $n$。
