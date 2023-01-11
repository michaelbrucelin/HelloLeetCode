#### [方法一：哈希表](https://leetcode.cn/problems/single-number-ii/solutions/746993/zhi-chu-xian-yi-ci-de-shu-zi-ii-by-leetc-23t6/?orderBy=hot)

**思路与算法**

我们可以使用哈希映射统计数组中每个元素的出现次数。对于哈希映射中的每个键值对，键表示一个元素，值表示其出现的次数。

在统计完成后，我们遍历哈希映射即可找出只出现一次的元素。

**代码**

```cpp
class Solution {
public:
    int singleNumber(vector<int>& nums) {
        unordered_map<int, int> freq;
        for (int num: nums) {
            ++freq[num];
        }
        int ans = 0;
        for (auto [num, occ]: freq) {
            if (occ == 1) {
                ans = num;
                break;
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int singleNumber(int[] nums) {
        Map<Integer, Integer> freq = new HashMap<Integer, Integer>();
        for (int num : nums) {
            freq.put(num, freq.getOrDefault(num, 0) + 1);
        }
        int ans = 0;
        for (Map.Entry<Integer, Integer> entry : freq.entrySet()) {
            int num = entry.getKey(), occ = entry.getValue();
            if (occ == 1) {
                ans = num;
                break;
            }
        }
        return ans;
    }
}
```

```python
class Solution:
    def singleNumber(self, nums: List[int]) -> int:
        freq = collections.Counter(nums)
        ans = [num for num, occ in freq.items() if occ == 1][0]
        return ans
```

```javascript
var singleNumber = function(nums) {
    const freq = new Map();
    for (const num of nums) {
        freq.set(num, (freq.get(num) || 0) + 1);
    }
    let ans = 0;
    for (const [num, occ] of freq.entries()) {
        if (occ === 1) {
            ans = num;
            break;
        }
    }
    return ans;
};
```

```go
func singleNumber(nums []int) int {
    freq := map[int]int{}
    for _, v := range nums {
        freq[v]++
    }
    for num, occ := range freq {
        if occ == 1 {
            return num
        }
    }
    return 0 // 不会发生，数据保证有一个元素仅出现一次
}
```

```c
struct HashTable {
    int key, val;
    UT_hash_handle hh;
};

int singleNumber(int *nums, int numsSize) {
    struct HashTable *hashTable = NULL;
    for (int i = 0; i < numsSize; i++) {
        struct HashTable *tmp;
        HASH_FIND_INT(hashTable, &nums[i], tmp);
        if (tmp == NULL) {
            tmp = malloc(sizeof(struct HashTable));
            tmp->key = nums[i];
            tmp->val = 1;
            HASH_ADD_INT(hashTable, key, tmp);
        } else {
            tmp->val++;
        }
    }
    int ans = 0;
    struct HashTable *iter, *tmp;
    HASH_ITER(hh, hashTable, iter, tmp) {
        if (iter->val == 1) {
            ans = iter->key;
            break;
        }
    }
    return ans;
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是数组的长度。
-   空间复杂度：$O(n)$。哈希映射中包含最多 $\lfloor n/3 \rfloor + 1$ 个元素，即需要的空间为 $O(n)$。
