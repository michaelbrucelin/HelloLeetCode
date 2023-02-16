#### [����һ����ϣ��](https://leetcode.cn/problems/maximum-number-of-pairs-in-array/solutions/2112731/shu-zu-neng-xing-cheng-duo-shao-shu-dui-jq01j/)

**˼·**

����һ�����飬��һ����ϣ����Ԫ�ظ�������ż�ԣ�ż��Ϊ $false$��������Ϊ $true$��ÿ����һ��Ԫ�أ�����ż��ȡ������ȡ�����Ϊż��������������ϴ�ż����֮����������������Ԫ�أ������γ�һ�����ԡ���󷵻�һ�����飬��һ��Ԫ�������������ڶ���Ԫ�������鳤�ȼ�ȥ��������������

**����**

```python
class Solution:
    def numberOfPairs(self, nums: List[int]) -> List[int]:
        cnt = defaultdict(bool)
        res = 0
        for num in nums:
            cnt[num] = not cnt[num]
            if not cnt[num]:
                res += 1
        return [res, len(nums) - 2 * res]
```

```java
class Solution {
    public int[] numberOfPairs(int[] nums) {
        Map<Integer, Boolean> cnt = new HashMap<Integer, Boolean>();
        int res = 0;
        for (int num : nums) {
            cnt.put(num, !cnt.getOrDefault(num, false));
            if (!cnt.get(num)) {
                res++;
            }
        }
        return new int[]{res, nums.length - 2 * res};
    }
}
```

```csharp
public class Solution {
    public int[] NumberOfPairs(int[] nums) {
        IDictionary<int, bool> cnt = new Dictionary<int, bool>();
        int res = 0;
        foreach (int num in nums) {
            if (cnt.ContainsKey(num)) {
                cnt[num] = !cnt[num];
            } else {
                cnt.Add(num, true);
            }
            if (!cnt[num]) {
                res++;
            }
        }
        return new int[]{res, nums.Length - 2 * res};
    }
}
```

```cpp
class Solution {
public:
    vector<int> numberOfPairs(vector<int>& nums) {
        unordered_map<int, bool> cnt;
        int res = 0;
        for (int num : nums) {
            if (cnt.count(num)) {
                cnt[num] = !cnt[num];
            } else {
                cnt[num] = true;
            }
            if (!cnt[num]) {
                res++;
            }
        }
        return {res, (int)nums.size() - 2 * res};
    }
};
```

```c
typedef struct {
    int key;
    bool val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, bool val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, int key, bool val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

bool hashGetItem(HashItem **obj, int key, bool defaultVal) {
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

int* numberOfPairs(int* nums, int numsSize, int* returnSize) {
    HashItem *cnt = NULL;
    int res = 0;
    for (int i = 0; i < numsSize; i++) {
        if (hashFindItem(&cnt, nums[i])) {
            hashSetItem(&cnt, nums[i], !hashGetItem(&cnt, nums[i], false));
        } else {
            hashAddItem(&cnt, nums[i], true);
        }
        if (!hashGetItem(&cnt, nums[i], false)) {
            res++;
        }
    }
    hashFree(&cnt);
    int *ans = (int *)malloc(sizeof(int) * 2);
    ans[0] = res;
    ans[1] = numsSize - 2 * res;
    *returnSize = 2;
    return ans;
}
```

```javascript
var numberOfPairs = function(nums) {
    const cnt = new Map();
    let res = 0;
    for (const num of nums) {
        cnt.set(num, !(cnt.get(num) || false));
        if (!cnt.get(num)) {
            res++;
        }
    }
    return [res, nums.length - 2 * res];
};
```

```go
func numberOfPairs(nums []int) []int {
    cnt := map[int]bool{}
    res := 0
    for _, num := range nums {
        cnt[num] = !cnt[num]
        if !cnt[num] {
            res++
        }
    }
    return []int{res, len(nums) - 2*res}
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ������ĳ��ȡ���Ҫ����һ�����顣
-   �ռ临�Ӷȣ�$O(n)$����ϣ������ౣ�� $n$ ��Ԫ�ء�
