### [找出输掉零场或一场比赛的玩家](https://leetcode.cn/problems/find-players-with-zero-or-one-losses/solutions/1418074/zhao-chu-shu-diao-ling-chang-huo-yi-chan-fpsj/)

#### 方法一：哈希表

**思路与算法**

我们用一个哈希映射记录每一名玩家输掉比赛的次数。对于其中的每一个键值对，键表示一名玩家，值表示该玩家输掉比赛的次数。

这样一来，我们对数组 $\textit{matches}$ 进行遍历。当我们遍历到第 $i$ 项 $(\textit{winner}_i, \textit{loser}_i)$ 时，我们需要将 $\textit{loser}_i$ 在哈希映射中对应的值增加 $1$（初始值为 $0$），表示玩家 $\textit{loser}_i$ 输掉了一场比赛。此外，如果 $\textit{winner}_i$ 没有在哈希映射中作为键出现过，我们也需要将其加入哈希映射中，并且对应的值为初始值 $0$。这是因为后续我们需要统计「没有输掉任何比赛的玩家」。

在这之后，我们只需要再对哈希表进行一次遍历，「没有输掉任何比赛的玩家」即为所有值为 $0$ 的键，「恰好输掉一场比赛的玩家」即为所有值为 $1$ 的键。在得到了这些玩家后，我们对它们进行递增排序即可。

**代码**

```C++
class Solution {
public:
    vector<vector<int>> findWinners(vector<vector<int>>& matches) {
        unordered_map<int, int> freq;
        for (const auto& match: matches) {
            int winner = match[0], loser = match[1];
            if (!freq.count(winner)) {
                freq[winner] = 0;
            }
            ++freq[loser];
        }

        vector<vector<int>> ans(2);
        for (const auto& [key, value]: freq) {
            if (value < 2) {
                ans[value].push_back(key);
            }
        }

        sort(ans[0].begin(), ans[0].end());
        sort(ans[1].begin(), ans[1].end());
        return ans;
    }
};
```

```Java
class Solution {
    public List<List<Integer>> findWinners(int[][] matches) {
        Map<Integer, Integer> freq = new HashMap<Integer, Integer>();
        for (int[] match : matches) {
            int winner = match[0], loser = match[1];
            freq.putIfAbsent(winner, 0);
            freq.put(loser, freq.getOrDefault(loser, 0) + 1);
        }

        List<List<Integer>> ans = new ArrayList<List<Integer>>();
        for (int i = 0; i < 2; ++i) {
            ans.add(new ArrayList<Integer>());
        }
        for (Map.Entry<Integer, Integer> entry : freq.entrySet()) {
            int key = entry.getKey(), value = entry.getValue();
            if (value < 2) {
                ans.get(value).add(key);
            }
        }

        Collections.sort(ans.get(0));
        Collections.sort(ans.get(1));
        return ans;
    }
}
```

```CSharp
public class Solution {
    public IList<IList<int>> FindWinners(int[][] matches) {
        IDictionary<int, int> freq = new Dictionary<int, int>();
        foreach (int[] match in matches) {
            int winner = match[0], loser = match[1];
            freq.TryAdd(winner, 0);
            freq.TryAdd(loser, 0);
            ++freq[loser];
        }

        IList<IList<int>> ans = new List<IList<int>>();
        for (int i = 0; i < 2; ++i) {
            ans.Add(new List<int>());
        }
        foreach (KeyValuePair<int, int> pair in freq) {
            if (pair.Value < 2) {
                ans[pair.Value].Add(pair.Key);
            }
        }

        ((List<int>) ans[0]).Sort();
        ((List<int>) ans[1]).Sort();
        return ans;
    }
}
```

```Python3
class Solution:
    def findWinners(self, matches: List[List[int]]) -> List[List[int]]:
        freq = Counter()
        for winner, loser in matches:
            if winner not in freq:
                freq[winner] = 0
            freq[loser] += 1
        
        ans = [[], []]
        for key, value in freq.items():
            if value < 2:
                ans[value].append(key)
        
        ans[0].sort()
        ans[1].sort()
        return ans
```

```Go
func findWinners(matches [][]int) [][]int {
    freq := map[int]int{}
    for _, match := range matches {
        winner, loser := match[0], match[1]
        if freq[winner] == 0 {
            freq[winner] = 0
        }
        freq[loser]++
    }
    ans := make([][]int, 2)
    for key, value := range freq {
        if value < 2 {
            ans[value] = append(ans[value], key)
        }
    }
    sort.Ints(ans[0])
    sort.Ints(ans[1])
    return ans
}
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

int** findWinners(int** matches, int matchesSize, int* matchesColSize, int* returnSize, int** returnColumnSizes) {
    HashItem *freq = NULL;
    for (int i = 0; i < matchesSize; i++) {
        int winner = matches[i][0], loser = matches[i][1];
        if (!hashFindItem(&freq, winner)) {
            hashAddItem(&freq, winner, 0);
        }
        hashSetItem(&freq, loser, hashGetItem(&freq, loser, 0) + 1);
    }

    int **ans = (int **)malloc(sizeof(int *) * 2); 
    *returnSize = 2;
    *returnColumnSizes = (int *)malloc(sizeof(int) * 2);
    int pos[2];
    memset(pos, 0, sizeof(pos));
    for (int i = 0; i < 2; i++) {
        ans[i] = (int *)malloc(sizeof(int) * HASH_COUNT(freq));
    }
    for (HashItem *pEntry = freq; pEntry; pEntry = pEntry->hh.next) {
        int key = pEntry->key, value = pEntry->val;
        if (value < 2) {
            ans[value][pos[value]++] = key;
        }
    }
  
    (*returnColumnSizes)[0] = pos[0];
    (*returnColumnSizes)[1] = pos[1];
    qsort(ans[0], pos[0], sizeof(int), cmp);
    qsort(ans[1], pos[1], sizeof(int), cmp);
    hashFree(&freq);
    return ans;
}
```

```JavaScript
var findWinners = function(matches) {
    const freq = new Map();
    for (const [winner, loser] of matches) {
        if (!freq.has(winner)) {
            freq.set(winner, 0);
        }
        freq.set(loser, (freq.get(loser) || 0) + 1);
    }

    const ans = [[], []];
    for (const [key, value] of freq) {
        if (value < 2) {
            ans[value].push(key);
        }
    }
    ans[0].sort((a, b) => a - b);
    ans[1].sort((a, b) => a - b);
    return ans;
};
```

```TypeScript
function findWinners(matches: number[][]): number[][] {
    const freq: Map<number, number> = new Map();
    for (const [winner, loser] of matches) {
        if (!freq.has(winner)) {
            freq.set(winner, 0);
        }
        freq.set(loser, (freq.get(loser) || 0) + 1);
    }

    const ans: number[][] = [[], []];
    for (const [key, value] of freq) {
        if (value < 2) {
            ans[value].push(key);
        }
    }

    ans[0].sort((a, b) => a - b);
    ans[1].sort((a, b) => a - b);
    return ans;
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn find_winners(matches: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
        let mut freq = HashMap::new();
        for match_ in matches {
            let (winner, loser) = (match_[0], match_[1]);
            freq.entry(winner).or_insert(0);
            *freq.entry(loser).or_insert(0) += 1;
        }

        let mut ans = vec![Vec::new(), Vec::new()];
        for (key, value) in freq {
            if value < 2 {
                ans[value as usize].push(key);
            }
        }
        ans[0].sort_unstable();
        ans[1].sort_unstable();
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \log n)$，其中 $n$ 是数组 $\textit{matches}$ 的长度。
- 空间复杂度：$O(n)$，即为哈希映射需要使用的空间。
