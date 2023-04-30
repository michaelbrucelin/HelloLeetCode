#### [方法二：哈希集合](https://leetcode.cn/problems/number-of-arithmetic-triplets/solutions/2200026/suan-zhu-san-yuan-zu-de-shu-mu-by-leetco-ldq4/)

由于给定的数组 $nums$ 是严格递增的，因此数组中不存在重复元素，不存在两个相同的算术三元组。

对于数组 $nums$ 中的元素 $x$，如果 $x + diff$ 和 $x + 2 \times diff$ 都在数组中，则存在一个算术三元组，其中的三个元素分别是 $x$、$x + diff$ 和 $x + 2 \times diff$，因此问题转换成计算数组 $nums$ 中有多少个元素可以作为算术三元组的最小元素。

为了快速判断一个元素是否在数组中，可以使用哈希集合存储数组中的所有元素，然后判断元素是否在哈希集合中。

将数组中的所有元素都加入哈希集合之后，遍历数组并统计满足 $x + diff$ 和 $x + 2 \times diff$ 都在哈希集合中的元素 $x$ 的个数，即为算术三元组的数目。

```java
class Solution {
    public int arithmeticTriplets(int[] nums, int diff) {
        Set<Integer> set = new HashSet<Integer>();
        for (int x : nums) {
            set.add(x);
        }
        int ans = 0;
        for (int x : nums) {
            if (set.contains(x + diff) && set.contains(x + 2 * diff)) {
                ans++;
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int ArithmeticTriplets(int[] nums, int diff) {
        ISet<int> set = new HashSet<int>();
        foreach (int x in nums) {
            set.Add(x);
        }
        int ans = 0;
        foreach (int x in nums) {
            if (set.Contains(x + diff) && set.Contains(x + 2 * diff)) {
                ans++;
            }
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int arithmeticTriplets(vector<int>& nums, int diff) {
        unordered_set<int> hashSet;
        for (int x : nums) {
            hashSet.emplace(x);
        }
        int ans = 0;
        for (int x : nums) {
            if (hashSet.count(x + diff) && hashSet.count(x + 2 * diff)) {
                ans++;
            }
        }
        return ans;
    }
};
```

```c
typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);             
    }
}

int arithmeticTriplets(int* nums, int numsSize, int diff) {
    HashItem *hashSet = NULL;
    for (int i = 0; i < numsSize; i++) {
        hashAddItem(&hashSet, nums[i]);
    }
    int ans = 0;
    for (int i = 0; i < numsSize; i++) {
        if (hashFindItem(&hashSet, nums[i] + diff) && hashFindItem(&hashSet, nums[i] + 2 * diff)) {
            ans++;
        }
    }
    hashFree(&hashSet);
    return ans;
}
```

```javascript
var arithmeticTriplets = function(nums, diff) {
    const set = new Set();
    for (const x of nums) {
        set.add(x);
    }
    let ans = 0;
    for (const x of nums) {
        if (set.has(x + diff) && set.has(x + 2 * diff)) {
            ans++;
        }
    }
    return ans;
};
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。需要遍历数组两次，每次将元素加入哈希集合与判断元素是否在哈希集合中的时间都是 $O(1)$。
-   空间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。哈希集合需要 $O(n)$ 的空间。
