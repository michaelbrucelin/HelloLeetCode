#### [����������̬�滮 + �Ż�](https://leetcode.cn/problems/smallest-sufficient-team/solutions/2213332/zui-xiao-de-bi-yao-tuan-dui-by-leetcode-2mbmz/)

**˼·���㷨** �ڷ���һ�У������� $dp[i]$ ����ʾ״̬��״̬���������㼼�ܼ���Ϊ $i$ ����С���������飬ÿһ��״̬���������¼�˾������Ա��š���������˷Ѻܶ�ռ�ȥ��������Ҳ�����˺ܶ�ʱ��ȥ�������顣 ʵ��������ֻȥҪ��¼��ÿ��״̬�Ĳ�����Դ���Ϳ��԰���ԭÿ��״̬�ľ�����Ա��ŵ����顣

�����ã�

-   $dp[i]$ ����ʾ�����㼼�ܼ���Ϊ $i$ ����С���������Ʒ���һ�У����ǳ�ʼ�� $dp[0] = 0$������ $dp[i]$ ��ʼΪ���ֵ $m$��
-   $prev\_skill[i]$ ����ʾ��ǰ�ļ��ܼ��ϣ����ܼ��� $i$ �Ǵ� $prev\_skill[i]$ ת�����ġ�
-   $prev\_people[i]$ ����ʾһ�����¼����Ա�������ܼ��� $i$ ��ͨ������Ա�� $prev\_people[i]$ ��ת�����ġ�

ͨ��������ʽ�����Ǿͼ�¼��ÿһ��״̬��ת����Դ��

������м��ܵļ����� $(1 << n) - 1$ ����ʾ������ $n$ �� $req\_skills$ �ĳ��ȡ�������Ҫ��ԭһ�����ܼ��� $i$ ��ʱ�����ǿ����ҵ����һ��Ա�� $prev\_people[i]$, �����������У�Ȼ��ֵ $i$ Ϊ $prev\_skill[i]$�������ظ�������̣�ֱ�� $i = 0$����ʾ�������ҵ���Ҫ���ܼ��ϵ�����Ա����

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(m \times 2^{n})$������ $n$ �� $req\_skills$ �ĳ��ȣ�$m$ �� $peoples$ �ĳ��ȡ�
-   �ռ临�Ӷȣ�$O(2^{n})$������ $n$ �� $req\_skills$ �ĳ��ȡ�
