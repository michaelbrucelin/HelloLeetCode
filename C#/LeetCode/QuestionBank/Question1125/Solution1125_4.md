#### [方法二：动态规划 + 优化](https://leetcode.cn/problems/smallest-sufficient-team/solutions/2213332/zui-xiao-de-bi-yao-tuan-dui-by-leetcode-2mbmz/)

**思路与算法** 在方法一中，我们用 $dp[i]$ 来表示状态，状态含义是满足技能集合为 $i$ 的最小人数的数组，每一个状态都用数组记录了具体的人员编号。这个过程浪费很多空间去储存结果，也消耗了很多时间去生成数组。 实际上我们只去要记录下每个状态的产生来源，就可以按序还原每个状态的具体人员编号的数组。

我们用：

-   $dp[i]$ 来表示，满足技能集合为 $i$ 的最小人数。类似方法一中，我们初始化 $dp[0] = 0$，其它 $dp[i]$ 初始为最大值 $m$。
-   $prev\_skill[i]$ 来表示先前的技能集合，技能集合 $i$ 是从 $prev\_skill[i]$ 转移来的。
-   $prev\_people[i]$ 来表示一个最新加入的员工，技能集合 $i$ 是通过加入员工 $prev\_people[i]$ 而转移来的。

通过这样方式，我们就记录了每一个状态的转移来源。

最后，所有技能的集合用 $(1 << n) - 1$ 来表示，其中 $n$ 是 $req\_skills$ 的长度。当我们要复原一个技能集合 $i$ 的时候，我们可以找到最后一个员工 $prev\_people[i]$, 把它加入结果中，然后赋值 $i$ 为 $prev\_skill[i]$。不断重复这个过程，直到 $i = 0$，表示我们已找到需要技能集合的最少员工。

**代码**

```java
class Solution {
    public int[] smallestSufficientTeam(String[] req_skills, List<List<String>> people) {
        int n = req_skills.length, m = people.size();
        HashMap<String, Integer> skill_index = new HashMap<>();
        for (int i = 0; i < n; ++i) {
            skill_index.put(req_skills[i], i);
        }
        int[] dp = new int[1 << n];
        Arrays.fill(dp, m);
        dp[0] = 0;
        int[] prev_skill = new int[1 << n];
        int[] prev_people = new int[1 << n];
        for (int i = 0; i < m; i++) {
            List<String> p = people.get(i);
            int cur_skill = 0;
            for (String s : p) {
                cur_skill |= 1 << skill_index.get(s);
            }
            for (int prev = 0; prev < (1 << n); prev++) {
                int comb = prev | cur_skill;
                if (dp[comb] > dp[prev] + 1) {
                    dp[comb] = dp[prev] + 1;
                    prev_skill[comb] = prev;
                    prev_people[comb] = i;
                }
            }
        }
        List<Integer> res = new ArrayList<>();
        int i = (1 << n) - 1;
        while (i > 0) {
            res.add(prev_people[i]);
            i = prev_skill[i];
        }
        return res.stream().mapToInt(j -> j).toArray();
    }
}
```

```cpp
class Solution {
public:
    vector<int> smallestSufficientTeam(vector<string>& req_skills, vector<vector<string>>& people) {
        int n = req_skills.size(), m = people.size();
        unordered_map<string, int> skill_index;
        for (int i = 0; i < n; ++i) {
            skill_index[req_skills[i]] = i;
        }
        vector<int> dp(1 << n, m);
        dp[0] = 0;
        vector<int> prev_skill(1 << n, 0);
        vector<int> prev_people(1 << n, 0);
        for (int i = 0; i < m; ++i) {
            int cur_skill = 0;
            for (string& skill : people[i]) {
                cur_skill |= 1 << skill_index[skill];
            }
            for (int prev = 0; prev < (1 << n); prev++) {
                int comb = prev | cur_skill;
                if (dp[comb] > dp[prev] + 1) {
                    dp[comb] = dp[prev] + 1;
                    prev_skill[comb] = prev;
                    prev_people[comb] = i;
                }
            }
        }
        vector<int> res;
        int i = (1 << n) - 1;
        while (i > 0) {
            res.push_back(prev_people[i]);
            i = prev_skill[i];
        }
        return res;
    }
};
```

```csharp
public class Solution {
    public int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people) {
        int n = req_skills.Length, m = people.Count;
        IDictionary<string, int> skill_index = new Dictionary<string, int>();
        for (int i = 0; i < n; ++i) {
            skill_index.Add(req_skills[i], i);
        }
        int[] dp = new int[1 << n];
        for (int i = 0; i < dp.Length; i++) {
            dp[i] = m;
        }
        dp[0] = 0;
        int[] prev_skill = new int[1 << n];
        int[] prev_people = new int[1 << n];
        for (int i = 0; i < m; ++i) {
            int cur_skill = 0;
            foreach (string s in people[i]) {
                cur_skill |= 1 << skill_index[s];
            }
            for (int prev = 0; prev < dp.Length; prev++) {
                int comb = prev | cur_skill;
                if (dp[comb] > dp[prev] + 1) {
                    dp[comb] = dp[prev] + 1;
                    prev_skill[comb] = prev;
                    prev_people[comb] = i;
                }
            }
        }
        List<int> res = new List<int>();
        int skills = (1 << n) - 1;
        while (skills > 0) {
            res.Add(prev_people[skills]);
            skills = prev_skill[skills];
        }
        return res.ToArray();
    }
}
```

```python
class Solution:
    def smallestSufficientTeam(self, req_skills: List[str], people: List[List[str]]) -> List[int]:
        n, m = len(req_skills), len(people)
        skill_index = {v: i for i, v in enumerate(req_skills)}
        dp = [m] * (1 << n)
        dp[0] = 0
        prev_skill = [0] * (1 << n)
        prev_people = [0] * (1 << n)
        for i, p in enumerate(people):
            cur_skill = 0
            for s in p:
                cur_skill |= 1 << skill_index[s]
            for prev in range(1 << n):
                comb = prev | cur_skill
                if dp[comb] > dp[prev] + 1:
                    dp[comb] = dp[prev] + 1
                    prev_skill[comb] = prev
                    prev_people[comb] = i
        res = []
        i = (1 << n) - 1
        while i > 0:
            res.append(prev_people[i])
            i = prev_skill[i]
        return res
```

```go
func smallestSufficientTeam(req_skills []string, people [][]string) []int {
    n, m := len(req_skills), len(people)
    skill_index := make(map[string]int)
    for i, skill := range req_skills {
        skill_index[skill] = i
    }
    dp := make([]int, 1 << n)
    for i := range dp {
        dp[i] = m
    }
    dp[0] = 0
    prev_skill := make([]int, 1 << n)
    prev_people := make([]int, 1 << n)
    for i := 0; i < m; i++ {
        cur_skill := 0
        for _, s := range people[i] {
            cur_skill |= 1 << skill_index[s]
        }
        for prev := 0; prev < (1 << n); prev++ {
            comb := prev | cur_skill
            if dp[comb] > dp[prev]+1 {
                dp[comb] = dp[prev] + 1
                prev_skill[comb] = prev
                prev_people[comb] = i
            }
        }
    }
    res := []int{}
    i := (1 << n) - 1
    for i > 0 {
        res = append(res, prev_people[i])
        i = prev_skill[i]
    }
    return res
}
```

```javascript
var smallestSufficientTeam = function(req_skills, people) {
    const n = req_skills.length;
    const m = people.length;
    let skillIndex = new Map();
    for (let i = 0; i < n; i++) {
        skillIndex.set(req_skills[i], i);
    }
    let dp = new Array(1 << n).fill(m);
    dp[0] = 0;
    let prev_skill = new Array(1 << n);
    let prev_people = new Array(1 << n);
    for (let i = 0; i < m; i++) {
        let cur_skill = 0;
        for (let s of people[i]) {
            cur_skill |= 1 << skillIndex.get(s);
        }
        for (let prev = 0; prev < (1 << n); prev++) {
            let comb = prev | cur_skill;
            if (dp[comb] > dp[prev] + 1) {
                dp[comb] = dp[prev] + 1;
                prev_skill[comb] = prev;
                prev_people[comb] = i;
            }
        }
    }
    let res = [];
    let skills = (1 << n) - 1;
    while (skills > 0) {
        res.push(prev_people[skills]);
        skills = prev_skill[skills];
    }
    return res;
};
```

```c
typedef struct {
    char *key;
    int val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, char *key) {
    HashItem *pEntry = NULL;
    HASH_FIND_STR(*obj, key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, char *key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_STR(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, char *key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetItem(HashItem **obj, char *key, int defaultVal) {
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

int* smallestSufficientTeam(char ** req_skills, int req_skillsSize, char *** people, int peopleSize, int* peopleColSize, int* returnSize) {
    int n = req_skillsSize, m = peopleSize;
    HashItem *skill_index = NULL;
    for (int i = 0; i < n; ++i) {
        hashAddItem(&skill_index, req_skills[i], i);
    }

    int dp[1 << n];
    int prev_skill[1 << n], prev_people[1 << n];
    memset(prev_skill, 0, sizeof(prev_skill));
    memset(prev_people, 0, sizeof(prev_people));
    dp[0] = 0;
    for (int i = 1; i < (1 << n); i++) {
        dp[i] = m;
    }
    for (int i = 0; i < m; ++i) {
        int cur_skill = 0;
        for (int j = 0; j < peopleColSize[i]; j++) {
            cur_skill |= 1 << hashGetItem(&skill_index, people[i][j], 0);
        }
        for (int prev = 0; prev < (1 << n); prev++) {
            int comb = prev | cur_skill;
            if (dp[comb] > dp[prev] + 1) {
                dp[comb] = dp[prev] + 1;
                prev_skill[comb] = prev;
                prev_people[comb] = i;
            }
        }
    }

    hashFree(&skill_index);
    int *res = (int *)calloc(m, sizeof(int));
    int i = (1 << n) - 1;
    int pos = 0;
    while (i > 0) {
        res[pos++] = prev_people[i];
        i = prev_skill[i];
    }
    *returnSize = pos;
    return res;
}
```

**复杂度分析**

-   时间复杂度：$O(m \times 2^{n})$，其中 $n$ 是 $req\_skills$ 的长度，$m$ 是 $peoples$ 的长度。
-   空间复杂度：$O(2^{n})$，其中 $n$ 是 $req\_skills$ 的长度。
