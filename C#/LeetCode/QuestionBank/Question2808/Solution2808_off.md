### [使循环数组所有元素相等的最少秒数](https://leetcode.cn/problems/minimum-seconds-to-equalize-a-circular-array/solutions/2614614/shi-xun-huan-shu-zu-suo-you-yuan-su-xian-1bfa/)

#### 方法一：哈希表

##### 思路与算法

我们首先用哈希表，统计 $\textit{nums}$ 中相同的数所出现的位置，$\textit{mp}[x]$ 表示 $x$ 所出现的位置。

然后我们研究，使得数组全部变为 $x$ 所需要的时间，这个时间取决于 $\textit{nums}$ 中，相邻 $x$ 的最大距离。我们依次枚举所有相邻（包括头尾）$x$ 的索引值，找到最大的距离。最大距离除以二并向下取整，就是使得数组全部变为 $x$ 所需要的时间。

最后我们对所有 $\textit{nums}$ 中 的数，都找到所需的时间，返回其中的最小值即可。

##### 代码

```c++
class Solution {
public:
    int minimumSeconds(vector<int>& nums) {
        unordered_map<int, vector<int>> mp;
        int n = nums.size(), res = n;
        for (int i = 0; i < n; ++i) {
            mp[nums[i]].push_back(i);
        }
        for (auto& pos : mp) {
            int mx = pos.second[0] + n - pos.second.back();
            for (int i = 1; i < pos.second.size(); ++i) {
                mx = max(mx, pos.second[i] - pos.second[i - 1]);
            }
            res = min(res, mx / 2);
        }
        return res;
    }
};
```

```java
class Solution {
    public int minimumSeconds(List<Integer> nums) {
        HashMap<Integer, List<Integer>> mp = new HashMap<>();
        int n = nums.size(), res = n;
        for (int i = 0; i < n; ++i) {
            mp.computeIfAbsent(nums.get(i), k -> new ArrayList<>()).add(i);
        }
        for (List<Integer> positions : mp.values()) {
            int mx = positions.get(0) + n - positions.get(positions.size() - 1);
            for (int i = 1; i < positions.size(); ++i) {
                mx = Math.max(mx, positions.get(i) - positions.get(i - 1));
            }
            res = Math.min(res, mx / 2);
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int MinimumSeconds(IList<int> nums) {
        IDictionary<int, IList<int>> dic = new Dictionary<int, IList<int>>();
        int n = nums.Count, res = n;
        for (int i = 0; i < n; ++i) {
            dic.TryAdd(nums[i], new List<int>());
            dic[nums[i]].Add(i);
        }
        foreach (IList<int> positions in dic.Values) {
            int mx = positions[0] + n - positions[positions.Count - 1];
            for (int i = 1; i < positions.Count; ++i) {
                mx = Math.Max(mx, positions[i] - positions[i - 1]);
            }
            res = Math.Min(res, mx / 2);
        }
        return res;
    }
}
```

```python
class Solution:
    def minimumSeconds(self, nums: List[int]) -> int:
        mp = defaultdict(list)
        res = n = len(nums)
        for i,a in enumerate(nums):
            mp[a].append(i)
        for pos in mp.values():
            mx = pos[0] + n - pos[-1]
            for i in range(len(pos)):
                mx = max(mx, pos[i] - pos[i - 1])
            res = min(res, mx // 2)
        return res
```

```javascript
var minimumSeconds = function(nums) {
    const mp = new Map();
    let n = nums.length, res = n;
    for (let i = 0; i < n; ++i) {
        if (!mp.has(nums[i])) {
            mp.set(nums[i], []);
        }
        mp.get(nums[i]).push(i);
    }
    for (const pos of mp.values()) {
        let mx = pos[0] + n - pos[pos.length - 1];
        for (let i = 1; i < pos.length; ++i) {
            mx = Math.max(mx, pos[i] - pos[i - 1]);
        }
        res = Math.min(res, Math.floor(mx / 2));
    }
    return res;
};
```

```go
func minimumSeconds(nums []int) int {
    mp := make(map[int][]int)
    n := len(nums)
    res := n
    for i, num := range nums {
        mp[num] = append(mp[num], i)
    }
    for _, pos := range mp {
        mx := pos[0] + n - pos[len(pos) - 1]
        for i := 1; i < len(pos); i++ {
            mx = max(mx, pos[i] - pos[i - 1])
        }
        res = min(res, mx / 2)
    }
    return res
}

func max(a, b int) int {
    if a > b {
        return a
    }
    return b
}

func min(a, b int) int {
    if a < b {
        return a
    }
    return b
}
```

```c
typedef struct {
    int key;
    struct ListNode *val;
    UT_hash_handle hh;
} HashItem; 

struct ListNode *createListNode(int val) {
    struct ListNode *obj = (struct ListNode *)malloc(sizeof(struct ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

void freeList(struct ListNode *list) {
    while (list) {
        struct ListNode *cur = list;
        list = list->next;
        free(cur);
    }
}

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddVal(HashItem **obj, int key, int val) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    if (pEntry) {
        struct ListNode *node = createListNode(val);
        node->next = pEntry->val;
        pEntry->val = node;
    } else {
        HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
        pEntry->key = key;
        pEntry->val = createListNode(val);
        HASH_ADD_INT(*obj, key, pEntry);
    }
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        freeList(curr->val);
        free(curr);
    }
}

int minimumSeconds(int* nums, int numsSize) {
    HashItem *mp = NULL;
    int res = numsSize;
    for (int i = 0; i < numsSize; ++i) {
        hashAddVal(&mp, nums[i], i);
    }
    for (HashItem *pEntry = mp; pEntry; pEntry = pEntry->hh.next) {
        struct ListNode *pre = pEntry->val;
        int first = pre->val;     
        int mx = 0;
        if (pre->next == NULL) {
            mx = numsSize;
        }
        for (struct ListNode *cur = pre->next; cur; cur = cur->next) {
            mx = fmax(mx, pre->val - cur->val);
            pre = cur;
            if (cur->next == NULL) {
                mx = fmax(mx, numsSize + cur->val - first);
            }
        }
        res = fmin(res, mx / 2);
    }
    hashFree(&mp);
    return res;
}
```

```typescript
function minimumSeconds(nums: number[]): number {
    const mp: Map<number, number[]> = new Map();
    let n: number = nums.length, res: number = n;

    for (let i: number = 0; i < n; ++i) {
        if (!mp.has(nums[i])) {
            mp.set(nums[i], []);
        }
        mp.get(nums[i])!.push(i);
    }
    for (const pos of mp.values()) {
        let mx: number = pos[0] + n - pos[pos.length - 1];
        for (let i: number = 1; i < pos.length; ++i) {
            mx = Math.max(mx, pos[i] - pos[i - 1]);
        }
        res = Math.min(res, Math.floor(mx / 2));
    }
    return res;
};
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是输入数组的长度。
- 空间复杂度：$O(n)$，其中 $n$ 是输入数组的长度。
