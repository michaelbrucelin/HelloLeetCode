### [同积元组](https://leetcode.cn/problems/tuple-with-same-product/solutions/2470655/tong-ji-yuan-zu-by-leetcode-solution-7yyy/?envType=daily-question&envId=2023-10-19)

#### 方法一：哈希统计

**思路与算法**

假设当前给定元组 $(a,b,c,d)$ 满足 $a \times b = c \times d$，且此时满足 $a < b < c < d$，则可以知道该元组可以按照不同顺序组合，组成 $8$ 个不同的元组，且这个 $8$ 个元组均满足题目要求：

-   $(a, b, c, d),(a, b, d, c)$；
-   $(a, b, c, d),(b, a, c, d)$；
-   $(c, d, a, b),(c, d, b, a)$；
-   $(d, c, a, b),(d, c, b, a)$；

由于数组 $nums$ 由**不同**正整数组成，这就意味着数组中不存在相同的两个元素。题目要求找**两个元素乘积相同**的 $4$ 元组，我们可以统计数组中所有不同元素的乘积组合数目，设元素 $a,b$ 的乘积 $a \times b$ 出现的次数为 $cnt(a \times b)$，且满足 $a \neq b$，如果此时数组中出现另一对数组 $c,d$，满足 $c \times d = a \times b$，由于数组中不存在相同的数所以一定满足 $a \neq b，c \neq d$，已知 $a \neq b \neq c$，则此时一定满足 $a \neq b \neq c \neq d$。根据上述分析，我们只需要在满足**乘积**相同的 **数对** 中，任意选择 $2$ 个两不同的数对一定可以满构成 $8$ 个不同的**同积元组**。根据排列组合可以知道，对于有 $cnt(a \times b)$ 个**数对**，则此时可以有 $C_{cnt(a \times b)}^2$ 种不同的数对组合，即此时可以构成的**同积元组**的数目为: $\dfrac{cnt(a \times b) \times (cnt(a \times b) -1)}{2} \times 8 = {cnt(a \times b) \times (cnt(a \times b) -1)} \times 4$

根据上述推论，我们统计数组中所有不同元素的乘积组合数目，然后计算在相同乘积的**数对**可以构成**同积元组**的数目，并求和即可得到最终的结果。

**代码**

```cpp
class Solution {
public:
    int tupleSameProduct(vector<int>& nums) {
        int n = nums.size();
        int ans = 0;
        unordered_map<int, int> cnt;
        for (int i = 0; i < n; i++) {
            for(int j = i + 1; j < n; j++) {
                cnt[nums[i] * nums[j]]++;
            }
        }
        for (auto &[k, v] : cnt) {
            ans += v * (v - 1) * 4;
        }
        return ans;
    }
};
```

```c
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

int tupleSameProduct(int* nums, int numsSize) {
    int ans = 0;
    HashItem *cnt = NULL;
    for (int i = 0; i < numsSize; i++) {
        for(int j = i + 1; j < numsSize; j++) {
            hashSetItem(&cnt, nums[i] * nums[j], hashGetItem(&cnt, nums[i] * nums[j], 0) + 1);
        }
    }
    for (HashItem *pEntry = cnt; pEntry; pEntry = pEntry->hh.next) {
        int val = pEntry->val;
        ans += val * (val - 1) * 4;
    }
    hashFree(&cnt);
    return ans;
}
```

```java
class Solution {
    public int tupleSameProduct(int[] nums) {
        int n = nums.length;
        Map<Integer, Integer> cnt = new HashMap<>();
        for (int i = 0; i < n; i++) {
            for(int j = i + 1; j < n; j++) {
                int key = nums[i] * nums[j];
                cnt.put(key, cnt.getOrDefault(key, 0) + 1);
            }
        }
        int ans = 0;
        for (Integer v : cnt.values()) {
            ans += v * (v - 1) * 4;
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int TupleSameProduct(int[] nums) {
        int n = nums.Length;
        IDictionary<int, int> cnt = new Dictionary<int, int>();
        for (int i = 0; i < n; i++) {
            for(int j = i + 1; j < n; j++) {
                int key = nums[i] * nums[j];
                cnt.TryAdd(key, 0);
                cnt[key]++;
            }
        }
        int ans = 0;
        foreach (KeyValuePair<int, int> pair in cnt) {
            int v = pair.Value;
            ans += v * (v - 1) * 4;
        }
        return ans;
    }
}
```

```python
class Solution:
    def tupleSameProduct(self, nums: List[int]) -> int:
        n = len(nums)
        cnt = Counter([nums[i] * nums[j] for i in range(n) for j in range(i + 1, n)])
        ans = 0
        for _, v in cnt.items():
            ans += v * (v - 1) * 4
        return ans
```

```go
func tupleSameProduct(nums []int) int {
    n := len(nums)
    cnt := make(map[int]int)
    for i := 0; i < n; i++ {
        for j := i + 1; j < n; j++ {
            cnt[nums[i] * nums[j]]++
        }
    }
    ans := 0
    for _, v := range cnt {
        ans += v * (v - 1) * 4
    }
    return ans
}
```

```javascript
var tupleSameProduct = function(nums) {
    const n = nums.length
    const cnt = new Map();
    for (let i = 0; i < n; i++) {
        for (let j = i + 1; j < n; j++) {
            const key = nums[i] * nums[j];
            cnt.set(key, (cnt.get(key) || 0) + 1);
        }
    }
    let ans = 0;
    for (const v of cnt.values()) {
        ans += v * (v - 1) * 4;
    }
    return ans
};
```

**复杂度分析**

-   时间复杂度：$O(n^2)$，其中 $n$ 表示数组的长度。求数组中任意两个元素之积以及遍历所有同的两数之积，需要的时间均为 $O(n^2)$，因此总的时间复杂度为 $O(n^2)$。
-   空间复杂度：$O(n^2)$，其中 $n$ 表示数组的长度。统计数组中任意两个元素之积，最多有 $n^2$ 种不同的计算结果，因此需要的空间为 $O(n^2)$。
