#### [方法二：哈希表](https://leetcode.cn/problems/longest-well-performing-interval/solutions/2109622/biao-xian-liang-hao-de-zui-chang-shi-jia-rlij/)

**思路与算法**

在方法一中，我们记工作小时数大于 $8$ 的为 $1$ 分，小于等于 $8$ 的为 $-1$ 分，原问题由求解最长的「表现良好的时间段」长度转变为求解分数和大于 $0$ 的最长区间长度。

我们仍然使用前缀和 $s$，对于某个下标 $i$（从 $0$ 开始），我们期待找到最小的 $j~(j < i)$，满足 $s[j] < s[i]$。接下来，我们按照 $s[i]$ 是否大于 $0$ 来分情况讨论：

1.  如果 $s[i] > 0$，那么前 $i + 1$ 项元素之和大于 $0$，表示有一个长度为 $i + 1$ 的大于 $0$ 的区间。
2.  如果 $s[i] < 0$，我们在前面试图寻找一个下标 $j$，满足 $s[j] = s[i] - 1$。如果有，则表示区间 $[j + 1, i]$ 是我们要找的以 $i$ 结尾的最长区间。

为什么第 $2$ 种情况要找 $s[i] - 1$，而不是 $s[i] − 2$ 或更小的一项？因为在本题中分数只有 $1$ 或者 $-1$，如果前缀和数组中在 $i$ 之前要出现小于 $s[i]$ 的元素，它的值一定是 $s[i] - 1$。也就是说当 $s[i] < 0$ 时，我们要找到 $j$ 使得 $s[j] < s[i]$，如果有这样的 $j$ 存在，这个 $j$ 一定满足 $s[j] = s[i] - 1$。

实现过程中，我们可以使用哈希表记录每一个前缀和第一次出现的位置，即可在 $O(1)$ 的时间内判断前缀和等于 $s[i] - 1$ 的位置 $j$ 是否存在。

**代码**

```cpp
class Solution {
public:
    int longestWPI(vector<int>& hours) {
        int n = hours.size();
        unordered_map<int, int> ump;
        int s = 0, res = 0;
        for (int i = 0; i < n; i++) {
            s += hours[i] > 8 ? 1 : -1;
            if (s > 0) {
                res = max(res, i + 1);
            } else {
                if (ump.count(s - 1)) {
                    res = max(res, i - ump[s - 1]);
                }
            }
            if (!ump.count(s)) {
                ump[s] = i;
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int longestWPI(int[] hours) {
        int n = hours.length;
        Map<Integer, Integer> map = new HashMap<Integer, Integer>();
        int s = 0, res = 0;
        for (int i = 0; i < n; i++) {
            s += hours[i] > 8 ? 1 : -1;
            if (s > 0) {
                res = Math.max(res, i + 1);
            } else {
                if (map.containsKey(s - 1)) {
                    res = Math.max(res, i - map.get(s - 1));
                }
            }
            if (!map.containsKey(s)) {
                map.put(s, i);
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int LongestWPI(int[] hours) {
        int n = hours.Length;
        IDictionary<int, int> dictionary = new Dictionary<int, int>();
        int s = 0, res = 0;
        for (int i = 0; i < n; i++) {
            s += hours[i] > 8 ? 1 : -1;
            if (s > 0) {
                res = Math.Max(res, i + 1);
            } else {
                if (dictionary.ContainsKey(s - 1)) {
                    res = Math.Max(res, i - dictionary[s - 1]);
                }
            }
            if (!dictionary.ContainsKey(s)) {
                dictionary.Add(s, i);
            }
        }
        return res;
    }
}
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))

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

int longestWPI(int* hours, int hoursSize) {
    HashItem *ump = NULL;
    int s = 0, res = 0;
    for (int i = 0; i < hoursSize; i++) {
        s += hours[i] > 8 ? 1 : -1;
        if (s > 0) {
            res = MAX(res, i + 1);
        } else {
            if (hashFindItem(&ump, s - 1)) {
                res = MAX(res, i - hashGetItem(&ump, s - 1, 0));
            }
        }
        if (!hashFindItem(&ump, s)) {
            hashAddItem(&ump, s, i);
        }
    }
    hashFree(&ump);
    return res;
}
```

```javascript
var longestWPI = function(hours) {
    const n = hours.length;
    const map = new Map();
    let s = 0, res = 0;
    for (let i = 0; i < n; i++) {
        s += hours[i] > 8 ? 1 : -1;
        if (s > 0) {
            res = Math.max(res, i + 1);
        } else {
            if (map.has(s - 1)) {
                res = Math.max(res, i - map.get(s - 1));
            }
        }
        if (!map.has(s)) {
            map.set(s, i);
        }
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 为 $hours$ 的长度。
-   空间复杂度：$O(n)$，其中 $n$ 为 $hours$ 的长度。
