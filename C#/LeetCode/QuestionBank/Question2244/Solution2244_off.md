### [完成所有任务需要的最少轮数](https://leetcode.cn/problems/minimum-rounds-to-complete-all-tasks/solutions/2773365/wan-cheng-suo-you-ren-wu-xu-yao-de-zui-s-rtfi/)

#### 方法一：贪心

##### 思路

首先统计不同难度级别的任务各自出现的频率，然后对频率（$\ge 1$）进行分类讨论：

- 频率是 $1$，说明这种任务无法完成。
- 频率是 $3\times k$，$k$ 为 $\ge 1$ 的整数。每次完成 $3$ 个，$k$ 轮完成。
- 频率是 $3\times k+2$，$k$ 为 $\ge 0$ 的整数。其中 $3\times k$ 个任务需要 $k$ 轮完成，剩下 $2$ 个任务需要 $1$ 轮完成。
- 频率是 $3\times k+1$，$k$ 为 $\ge 1$ 的整数。其中 $3\times (k-1)$ 个任务需要 $(k-1)$ 轮完成，剩下 $4$ 个任务需要 $2$ 轮完成。

对这些情况进行求和即可。

##### 代码

```python
class Solution:
    def minimumRounds(self, tasks: List[int]) -> int:
        cnt = Counter(tasks)
        res = 0
        for v in cnt.values():
            if v == 1:
                return -1
            if v % 3 == 0:
                res += v // 3
            else:
                res += (1 + v // 3)
        return res
```

```java
class Solution {
    public int minimumRounds(int[] tasks) {
        Map<Integer, Integer> cnt = new HashMap<Integer, Integer>();
        for (int task : tasks) {
            cnt.put(task, cnt.getOrDefault(task, 0) + 1);
        }
        int res = 0;
        for (int v : cnt.values()) {
            if (v == 1) {
                return -1;
            }
            if (v % 3 == 0) {
                res += v / 3;
            } else {
                res += 1 + v / 3;
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int MinimumRounds(int[] tasks) {
        IDictionary<int, int> cnt = new Dictionary<int, int>();
        foreach (int task in tasks) {
            cnt.TryAdd(task, 0);
            cnt[task]++;
        }
        int res = 0;
        foreach (int v in cnt.Values) {
            if (v == 1) {
                return -1;
            }
            if (v % 3 == 0) {
                res += v / 3;
            } else {
                res += 1 + v / 3;
            }
        }
        return res;
    }
}
```

```go
func minimumRounds(tasks []int) int {
    cnt := map[int]int{}
    for _, t := range tasks {
        cnt[t]++
    }
    res := 0
    for _, v := range cnt {
        if v == 1 {
            return -1
        } else if v % 3 == 0 {
            res += v / 3
        } else {
            res += v / 3 + 1
        }
    }
    return res
}
```

```c++
class Solution {
public:
    int minimumRounds(vector<int>& tasks) {
        unordered_map<int, int> cnt;
        for (int t : tasks) {
            cnt[t]++;
        }
        int res = 0;
        for (auto [_, v] : cnt) {
            if (v == 1) {
                return -1;
            } else if (v % 3 == 0) {
                res += v / 3;
            } else {
                res += v / 3 + 1;
            }
        }
        return res;
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

int minimumRounds(int* tasks, int tasksSize) {
    HashItem *cnt = NULL;
    for (int i = 0; i < tasksSize; i++) {
        hashSetItem(&cnt, tasks[i], hashGetItem(&cnt, tasks[i], 0) + 1);
    }
    int res = 0;
    for (HashItem *pEntry = cnt; pEntry; pEntry = pEntry->hh.next) {
        int v = pEntry->val;
        if (v == 1) {
            return -1;
        } else if (v % 3 == 0) {
            res += v / 3;
        } else {
            res += v / 3 + 1;
        }
    }
    hashFree(&cnt);
    return res;
}
```

```javascript
var minimumRounds = function(tasks) {
    const cnt = new Map();
    for (const t of tasks) {
        cnt.set(t, cnt.has(t) ? cnt.get(t) + 1: 1);
    }
    let res = 0;
    for (const [k, v] of cnt) {
        if (v === 1) {
            return -1;
        } else if (v % 3 === 0) {
            res += v / 3;
        } else {
            res += Math.ceil(v / 3);
        }
    }
    return res;
};
```

```typescript
function minimumRounds(tasks: number[]): number {
    const cnt: Map<number, number> = new Map();
    for (const t of tasks) {
        cnt.set(t, cnt.has(t) ? cnt.get(t) + 1 : 1);
    }
    let res: number = 0;
    for (const [k, v] of cnt.entries()) {
        if (v === 1) {
            return -1;
        } else if (v % 3 === 0) {
            res += v / 3;
        } else {
            res += Math.ceil(v / 3);
        }
    }
    return res;
};
```

```rust
use std::collections::HashMap;

impl Solution {
    pub fn minimum_rounds(tasks: Vec<i32>) -> i32 {
        let mut cnt = HashMap::new();
        for &t in &tasks {
            *cnt.entry(t).or_insert(0) += 1;
        }
        let mut res = 0;
        for (&_, &v) in &cnt {
            if v == 1 {
                return -1;
            } else if v % 3 == 0 {
                res += v / 3;
            } else {
                res += v / 3 + 1;
            }
        }
        res
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是数组长度。
- 空间复杂度：$O(n)$。
