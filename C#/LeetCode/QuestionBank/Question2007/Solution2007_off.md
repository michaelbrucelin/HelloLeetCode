### [从双倍数组中还原原数组](https://leetcode.cn/problems/find-original-array-from-doubled-array/solutions/2740671/cong-shuang-bei-shu-zu-zhong-huan-yuan-y-0vgc/)

#### 方法一：排序

##### 思路与算法

首先把 $\textit{changed}$ 排序，并且统计所有元素出现的频数。

然后我们从小到大依次遍历数组，如果对于一个元素，它的频数大于零，并且它的两倍数也还在数组中，我们则可以把它加入到答案中。

如果对于一个数找不到它两倍数，即两倍数的频数等于零，则说明无法找到原数组，返回空数组即可。

##### 代码

```c++
class Solution {
public:
    vector<int> findOriginalArray(vector<int>& changed) {
        sort(changed.begin(), changed.end());
        unordered_map<int, int> count;
        for (int a : changed) {
            count[a]++;
        }
        vector<int> res;
        for (int a : changed) {
            if (count[a] == 0) {
                continue;
            }
            count[a]--;
            if (count[a * 2] == 0) {
                return {};
            }
            count[a * 2]--;
            res.push_back(a);
        }
        return res;
    }
};
```

```java
class Solution {
    public int[] findOriginalArray(int[] changed) {
        Arrays.sort(changed);
        Map<Integer, Integer> count = new HashMap<>();
        for (int a : changed) {
            count.put(a, count.getOrDefault(a, 0) + 1);
        }
        int[] res = new int[changed.length / 2];
        int i = 0;
        for (int a : changed) {
            if (count.get(a) == 0) {
                continue;
            }
            count.put(a, count.get(a) - 1);
            if (count.getOrDefault(a * 2, 0) == 0) {
                return new int[0];
            }
            count.put(a * 2, count.get(a * 2) - 1);
            res[i++] = a;
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int[] FindOriginalArray(int[] changed) {
        Array.Sort(changed);
        IDictionary<int, int> count = new Dictionary<int, int>();
        foreach (int a in changed) {
            count.TryAdd(a, 0);
            count[a]++;
        }
        int[] res = new int[changed.Length / 2];
        int i = 0;
        foreach (int a in changed) {
            if (count[a] == 0) {
                continue;
            }
            count[a]--;
            if (!count.ContainsKey(a * 2) || count[a * 2] == 0) {
                return new int[0];
            }
            count[a * 2]--;
            res[i++] = a;
        }
        return res;
    }
}
```

```python
class Solution:
    def findOriginalArray(self, changed: List[int]) -> List[int]:
        changed.sort()
        count = Counter(changed)
        res = []
        for a in changed:
            if count[a] == 0:
                continue
            count[a] -= 1
            if count[a * 2] == 0:
                return []
            count[a * 2] -= 1
            res.append(a)
        return res
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

static int cmp(const void *a, const void *b) {
    return *(int *)a - *(int *)b;
}

int* findOriginalArray(int* changed, int changedSize, int* returnSize) {
    qsort(changed, changedSize, sizeof(int), cmp);
    HashItem *count = NULL;
    for (int i = 0; i < changedSize; i++) {
        int a = changed[i];
        hashSetItem(&count, a, hashGetItem(&count, a, 0) + 1);
    }
    
    int *res = (int *)malloc(sizeof(int) * changedSize);
    int pos = 0;
    for (int i = 0; i < changedSize; i++) {
        int a = changed[i];
        if (hashGetItem(&count, a, 0) == 0) {
            continue;
        }
        hashSetItem(&count, a, hashGetItem(&count, a, 0) - 1);
        if (hashGetItem(&count, 2 * a, 0) == 0) {
            hashFree(&count);
            *returnSize = 0;
            return NULL;
        }
        hashSetItem(&count, a * 2, hashGetItem(&count, a * 2, 0) - 1);
        res[pos++] = a;
    }
    *returnSize = pos;
    hashFree(&count);
    return res;
}
```

```javascript
var findOriginalArray = function(changed) {
    changed.sort((a, b) => a - b);
    const count = {};
    for (const num of changed) {
        count[num] = (count[num] || 0) + 1;
    }
    const res = [];
    for (const a of changed) {
        if (count[a] === 0) {
            continue;
        }
        count[a]--;
        if (!count[a * 2]) {
            return [];
        }
        count[a * 2]--;
        res.push(a);
    }
    return res;
};
```

```typescript
function findOriginalArray(changed: number[]): number[] {
    changed.sort((a, b) => a - b);
    const count = {};
    for (const num of changed) {
        count[num] = (count[num] || 0) + 1;
    }
    const res = [];
    for (const a of changed) {
        if (count[a] === 0) {
            continue;
        }
        count[a]--;
        if (!count[a * 2]) {
            return [];
        }
        count[a * 2]--;
        res.push(a);
    }
    return res;
};
```

```go
func findOriginalArray(changed []int) []int {
    sort.Ints(changed)
    count := make(map[int]int)
    for _, num := range changed {
        count[num]++
    }
    res := []int{}
    for _, a := range changed {
        if count[a] == 0 {
            continue
        }
        count[a]--

        if count[a*2] == 0 {
            return []int{}
        }
        count[a*2]--

        res = append(res, a)
    }
    return res
}
```

```csharp
public class Solution {
    public int[] FindOriginalArray(int[] changed) {
        Array.Sort(changed);
        var count = new Dictionary<int, int>();
        foreach (var a in changed) {
            if (!count.ContainsKey(a)) {
                count[a] = 0;
            }
            count[a]++;
        }
        int[] res = new int[changed.Length / 2];
        int i = 0;
        foreach (var a in changed) {
            if (count[a] == 0) {
                continue;
            }
            count[a]--;
            if (!count.ContainsKey(a * 2) || count[a * 2] == 0) {
                return new int[0];
            }
            count[a * 2]--;
            res[i++] = a;
        }
        return res;
    }
}
```

```rust
use std::collections::HashMap;

impl Solution {
    pub fn find_original_array(mut changed: Vec<i32>) -> Vec<i32> {
        changed.sort_unstable();
        let mut count = HashMap::new();
        for num in &changed {
            *count.entry(*num).or_insert(0) += 1;
        }
        let mut res = Vec::new();
        for a in changed {
            if *count.get(&a).unwrap_or(&0) == 0 {
                continue;
            }
            *count.get_mut(&a).unwrap() -= 1;

            if *count.get(&(a * 2)).unwrap_or(&0) == 0 {
                return vec![];
            }
            *count.get_mut(&(a * 2)).unwrap() -= 1;
            res.push(a);
        }
        res
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n\log n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(n)$，其中 $n$ 是数组的长度。
