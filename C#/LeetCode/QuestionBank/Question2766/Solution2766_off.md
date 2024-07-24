### [重新放置石块](https://leetcode.cn/problems/relocate-marbles/solutions/2849789/zhong-xin-fang-zhi-shi-kuai-by-leetcode-4n7ct/)

#### 方法一：哈希表

**思路* *

用一个哈希表 $mp$ 来记录某个坐标是否有石块，然后根据 $moveFrom$ 与 $moveTo$ 模拟操作即可。

**代码**

```C++
class Solution {
public:
    vector<int> relocateMarbles(vector<int>& nums, vector<int>& moveFrom, vector<int>& moveTo) {
        vector<int> ans;
        unordered_map<int, bool> mp;

        for (int i = 0; i < nums.size(); i++) {
            mp[nums[i]] = true;
        }

        for (int i = 0; i < moveFrom.size(); i++) {
            mp.erase(moveFrom[i]);
            mp[moveTo[i]] = true;
        }

        for (const auto& pair : mp) {
            ans.push_back(pair.first);
        }
        sort(ans.begin(), ans.end());
        return ans;
    }
};
```

```Java
class Solution {
    public List<Integer> relocateMarbles(int[] nums, int[] moveFrom, int[] moveTo) {
        List<Integer> ans = new ArrayList<Integer>();
        Map<Integer, Boolean> mp = new HashMap<Integer, Boolean>();

        for (int i = 0; i < nums.length; i++) {
            mp.put(nums[i], true);
        }

        for (int i = 0; i < moveFrom.length; i++) {
            mp.remove(moveFrom[i]);
            mp.put(moveTo[i], true);
        }

        for (Map.Entry<Integer, Boolean> entry : mp.entrySet()) {
            ans.add(entry.getKey());
        }
        Collections.sort(ans);
        return ans;
    }
}
```

```CSharp
public class Solution {
    public IList<int> RelocateMarbles(int[] nums, int[] moveFrom, int[] moveTo) {
        IList<int> ans = new List<int>();
        IDictionary<int, bool> mp = new Dictionary<int, bool>();

        for (int i = 0; i < nums.Length; i++) {
            mp.TryAdd(nums[i], true);
        }

        for (int i = 0; i < moveFrom.Length; i++) {
            mp.Remove(moveFrom[i]);
            mp.TryAdd(moveTo[i], true);
        }

        foreach (KeyValuePair<int, bool> pair in mp) {
            ans.Add(pair.Key);
        }
        ((List<int>) ans).Sort();
        return ans;
    }
}
```

```C
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

int cmp(const void *a, const void *b) {
    return *(int *)a - *(int *)b;
}

int* relocateMarbles(int* nums, int numsSize, int* moveFrom, int moveFromSize, int* moveTo, int moveToSize, int* returnSize){
    int *ans = (int *)malloc(sizeof(int) * numsSize);
    HashItem *mp = NULL;
    for (int i = 0; i < numsSize; i++) {
        hashAddItem(&mp, nums[i]);
    }
    for (int i = 0; i < moveFromSize; i++) {
        hashEraseItem(&mp, moveFrom[i]);
        hashAddItem(&mp, moveTo[i]);
    }

    int pos = 0;
    for (HashItem *pEntry = mp; pEntry; pEntry = pEntry->hh.next) {
        ans[pos++] = pEntry->key;
    }
    hashFree(&mp);
    qsort(ans, pos, sizeof(int), cmp);
    *returnSize = pos;
    return ans;
}
```

```Go
func relocateMarbles(nums []int, moveFrom []int, moveTo []int) []int {
    mp := make(map[int]bool)
    var ans []int

    for _, num := range nums {
        mp[num] = true
    }
    for i := range moveFrom {
        delete(mp, moveFrom[i])
        mp[moveTo[i]] = true
    }
    for key := range mp {
        ans = append(ans, key)
    }
    sort.Ints(ans)
    return ans
}
```

```Python
class Solution:
    def relocateMarbles(self, nums: List[int], moveFrom: List[int], moveTo: List[int]) -> List[int]:
        mp = {}
        ans = []
        for num in nums:
            mp[num] = True
        for i in range(len(moveFrom)):
            if moveFrom[i] in mp:
                del mp[moveFrom[i]]
            mp[moveTo[i]] = True
        ans = list(mp.keys())
        ans.sort()
        return ans
```

```JavaScript
var relocateMarbles = function(nums, moveFrom, moveTo) {
    let mp = new Map();
    let ans = [];

    nums.forEach(num => mp.set(num, true));
    for (let i = 0; i < moveFrom.length; i++) {
        mp.delete(moveFrom[i]);
        mp.set(moveTo[i], true);
    }
    mp.forEach((_, key) => ans.push(key));
    ans.sort((a, b) => a - b);
    return ans;
};
```

```TypeScript
function relocateMarbles(nums: number[], moveFrom: number[], moveTo: number[]): number[] {
    let mp: Map<number, boolean> = new Map();
    let ans: number[] = [];
    nums.forEach(num => mp.set(num, true));
    for (let i = 0; i < moveFrom.length; i++) {
        mp.delete(moveFrom[i]);
        mp.set(moveTo[i], true);
    }
    mp.forEach((_, key) => ans.push(key));
    ans.sort((a, b) => a - b);
    return ans;
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn relocate_marbles(nums: Vec<i32>, move_from: Vec<i32>, move_to: Vec<i32>) -> Vec<i32> {
        let mut mp = HashMap::new();
        let mut ans = Vec::new();
        for &num in &nums {
            mp.insert(num, true);
        }
        for i in 0..move_from.len() {
            mp.remove(&move_from[i]);
            mp.insert(move_to[i], true);
        }
        for (&key, _) in &mp {
            ans.push(key);
        }
        ans.sort();
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nlogn + m)$，其中 $n$ 表示 $nums$ 数组的长度，$m$ 表示 $moveFrom$ 数组的长度。时间复杂度瓶颈在于对答案的排序。
- 空间复杂度：$O(n)$，其中 $n$ 表示 $nums$ 数组的长度。为哈希表需要开辟的空间。
