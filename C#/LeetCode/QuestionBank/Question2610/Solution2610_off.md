### [转换二维数组](https://leetcode.cn/problems/convert-an-array-into-a-2d-array-with-conditions/solutions/3600466/zhuan-huan-er-wei-shu-zu-by-leetcode-sol-jp1u/)

#### 方法一：哈希表

**思路与算法**

根据题意可知，需要将给定的数组 $nums$ 按照如下规则进行分组：

- 每个分组**只**包含数组 $nums$ 中的元素；
- 每个分组只能包含**不同**整数；
- 尽可能少的分组；

我们用哈希表统计每个整数在数组中出现的次数，由于每个分组中的元素都不同，此时如果数组中出现次数最多的元素为 $x$，该元素出现的次数为 $cnt[x]$，根据贪心原则，此时最少的分组即为 $cnt[x]$ 个。我们遍历哈希表 $cnt$，并依次将哈希表中存在的元素均加入到一个分组中，同时将哈希表中每个元素的次数减 $1$，然后当元素 x 出现的次数 $cnt[x]=0$ 时，此时将该元素从哈希表中删除，最终返回不同的分组即可。

**代码**

```C++
class Solution {
public:
    vector<vector<int>> findMatrix(vector<int>& nums) {
        unordered_map<int, int> cnt;
        for (int x : nums) {
            cnt[x]++;
        }

        vector<vector<int>> ans;
        while (!cnt.empty()) {
            vector<int> arr;
            for (auto it = cnt.begin(); it != cnt.end(); ) {
                it->second -= 1;
                arr.emplace_back(it->first);
                if (it->second == 0) {
                    it = cnt.erase(it);
                } else {
                    it++;
                }
            }
            ans.push_back(arr);
        }
        
        return ans;
    }
};
```

```Java
class Solution {
    public List<List<Integer>> findMatrix(int[] nums) {
        Map<Integer, Integer> cnt = new HashMap<>();
        for (int x : nums) {
            cnt.put(x, cnt.getOrDefault(x, 0) + 1);
        }
        
        List<List<Integer>> ans = new ArrayList<>();
        while (!cnt.isEmpty()) {
            List<Integer> arr = new ArrayList<>();
            Iterator<Map.Entry<Integer, Integer>> it = cnt.entrySet().iterator();
            while (it.hasNext()) {
                Map.Entry<Integer, Integer> entry = it.next();
                entry.setValue(entry.getValue() - 1);
                arr.add(entry.getKey());
                if (entry.getValue() == 0) {
                    it.remove();
                }
            }
            ans.add(arr);
        }
        
        return ans;
    }
}
```

```CSharp
public class Solution {
    public IList<IList<int>> FindMatrix(int[] nums) {
        Dictionary<int, int> cnt = new Dictionary<int, int>();
        foreach (int x in nums) {
            if (!cnt.ContainsKey(x)) {
                cnt[x] = 0;
            }
            cnt[x]++;
        }

        List<List<int>> ans = new List<List<int>>();
        while (cnt.Count > 0) {
            List<int> arr = new List<int>();
            List<int> keysToRemove = new List<int>();
            foreach (var entry in cnt) {
                cnt[entry.Key]--;
                arr.Add(entry.Key);
                if (cnt[entry.Key] == 0) {
                    keysToRemove.Add(entry.Key);
                }
            }
            foreach (var key in keysToRemove) {
                cnt.Remove(key);
            }
            ans.Add(arr);
        }
        
        return ans.ToArray();
    }
}
```

```Go
func findMatrix(nums []int) [][]int {
    cnt := make(map[int]int)
    for _, x := range nums {
        cnt[x]++
    }

    var ans [][]int
    for len(cnt) > 0 {
        arr := []int{}
        for k, v := range cnt {
            cnt[k] = v - 1
            arr = append(arr, k)
            if cnt[k] == 0 {
                delete(cnt, k)
            }
        }
        ans = append(ans, arr)
    }
    
    return ans
}
```

```Python
class Solution:
    def findMatrix(self, nums: List[int]) -> List[List[int]]:
        cnt = Counter(nums)
        ans = []
        
        while cnt:
            arr = []
            for key in list(cnt.keys()):
                cnt[key] -= 1
                arr.append(key)
                if cnt[key] == 0:
                    del cnt[key]
            ans.append(arr)
        
        return ans
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

int** findMatrix(int* nums, int numsSize, int* returnSize, int** returnColumnSizes) {
    HashItem *cnt = NULL;
    for (int i = 0; i < numsSize; i++) {
        hashSetItem(&cnt, nums[i], hashGetItem(&cnt, nums[i], 0) + 1);
    }

    int **res = (int **)malloc(sizeof(int *) * numsSize);
    *returnColumnSizes = (int *)malloc(sizeof(int) * numsSize);
    int pos = 0;
    while (HASH_COUNT(cnt) > 0) {
        res[pos] = (int *)malloc(sizeof(int) * HASH_COUNT(cnt));
        int i = 0;
        for (HashItem *pEntry = cnt; pEntry;) {
            res[pos][i++] = pEntry->key;
            pEntry->val--;
            if (pEntry->val == 0) {
                int key = pEntry->key;
                pEntry = pEntry->hh.next;
                hashEraseItem(&cnt, key);
            } else {
                pEntry = pEntry->hh.next;
            }
        }
        (*returnColumnSizes)[pos] = i;
        pos++;
    }
    *returnSize = pos;

    return res;
}
```

```JavaScript
var findMatrix = function(nums) {
    let cnt = new Map();
    for (let x of nums) {
        cnt.set(x, (cnt.get(x) || 0) + 1);
    }

    let ans = [];
    while (cnt.size > 0) {
        let arr = [];
        for (let [key, value] of cnt) {
            cnt.set(key, value - 1);
            arr.push(key);
            if (cnt.get(key) === 0) {
                cnt.delete(key);
            }
        }
        ans.push(arr);
    }
    
    return ans;
};
```

```TypeScript
function findMatrix(nums: number[]): number[][] {
    let cnt = new Map<number, number>();
    for (let x of nums) {
        cnt.set(x, (cnt.get(x) || 0) + 1);
    }

    let ans: number[][] = [];
    while (cnt.size > 0) {
        let arr: number[] = [];
        for (let [key, value] of cnt) {
            cnt.set(key, value - 1);
            arr.push(key);
            if (cnt.get(key) === 0) {
                cnt.delete(key);
            }
        }
        ans.push(arr);
    }
    
    return ans;
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn find_matrix(nums: Vec<i32>) -> Vec<Vec<i32>> {
        let mut cnt = HashMap::new();
        for &x in &nums {
            *cnt.entry(x).or_insert(0) += 1;
        }

        let mut ans = Vec::new();
        while !cnt.is_empty() {
            let mut arr = Vec::new();
            let keys: Vec<i32> = cnt.keys().cloned().collect();
            for key in keys {
                if let Some(value) = cnt.get_mut(&key) {
                    *value -= 1;
                    arr.push(key);
                    if *value == 0 {
                        cnt.remove(&key);
                    }
                }
            }
            ans.push(arr);
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 表示给定的数组的长度。我们需要枚举哈希表中每个不同的元素，将数组中所有元素进行分组，每个元素仅访问一次，需要的时间为 $O(n)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示给定的数组的长度。需要用哈希表存储数组中所有元素出现的次数，需要的空间为 $O(n)$。
