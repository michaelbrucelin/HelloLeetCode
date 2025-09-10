### [需要教语言的最少人数](https://leetcode.cn/problems/minimum-number-of-people-to-teach/solutions/3766885/xu-yao-jiao-yu-yan-de-zui-shao-ren-shu-b-jaf9/)

#### 方法一：贪心

**思路与算法**

题目要求我们选择一种语言，使得所有好友之间都能够相互沟通，在任意一对好友之间会存在两种情况：

1. 这对好友掌握的语言集合有交集，那么他们之间可以相互沟通。
2. 这对好友握的语言集合没有交集，那么他们之间不能相互沟通。

对于第一种情况，我们无需考虑，因为这对好友之间已经可以相互沟通了。对于第二种情况，我们只需要选择一种语言，使得这对好友都掌握这种语言，那么他们之间就可以相互沟通了。

我们的目的是找出需要教语言的最少人数，那么我们首先要找出所有不能相互沟通的好友。

其次，我们只需要找到一种语言，使不能相互沟通的好友都掌握这个语言，就能够保证这些好友之间能够相互沟通。

那么如何找到这种语言呢？我们只需要统计每一种语言被多少人掌握了，然后贪心地选择被最多人掌握的语言当作目标语言即可，这是因为没有掌握该种语言的人数最少。可以证明：选择其他语言，我们需要教的人数一定不会比选择该种语言需要教的人数更少，因此这种贪心策略是正确的。

在算法的实现中，我们使用一个哈希表 $mp$ 来判断当前这对好友是否能够相互沟通，然后使用一个名为 $cncon$ 的集合来存储所有不能相互沟通的好友。使用一个长度为 $n$ 的数组 $cnt$ 来统计每一种语言被多少人掌握了，然后遍历 $cnt$ 数组，找出最大的值 $max\_cnt$，那么需要教的语言的最少人数就是 $cncon$ 集合的大小减去 $max\_cnt$。

**代码**

```C++
class Solution {
public:
    int minimumTeachings(int n, vector<vector<int>>& languages,
                         vector<vector<int>>& friendships) {
        unordered_set<int> cncon;
        for (auto friendship : friendships) {
            unordered_map<int, int> mp;
            bool conm = false;
            for (int lan : languages[friendship[0] - 1]) {
                mp[lan] = 1;
            }
            for (int lan : languages[friendship[1] - 1]) {
                if (mp[lan]) {
                    conm = true;
                    break;
                }
            }
            if (!conm) {
                cncon.insert(friendship[0] - 1);
                cncon.insert(friendship[1] - 1);
            }
        }
        int max_cnt = 0;
        vector<int> cnt(n + 1, 0);
        for (auto friendship : cncon) {
            for (int lan : languages[friendship]){
                cnt[lan]++;
                max_cnt = max(max_cnt, cnt[lan]);
            }
        }
        return cncon.size() - max_cnt;
    }
};
```

```Python
class Solution:
    def minimumTeachings(self, n: int, languages: List[List[int]], friendships: List[List[int]]) -> int:
        cncon = set()
        for friendship in friendships:
            mp = {}
            conm = False
            for lan in languages[friendship[0] - 1]:
                mp[lan] = 1
            for lan in languages[friendship[1] - 1]:
                if lan in mp:
                    conm = True
                    break
            if not conm:
                cncon.add(friendship[0] - 1)
                cncon.add(friendship[1] - 1)

        max_cnt = 0
        cnt = [0] * (n + 1)
        for friendship in cncon:
            for lan in languages[friendship]:
                cnt[lan] += 1
                max_cnt = max(max_cnt, cnt[lan])

        return len(cncon) - max_cnt
```

```Rust
use std::collections::{HashSet, HashMap};

impl Solution {
    pub fn minimum_teachings(n: i32, languages: Vec<Vec<i32>>, friendships: Vec<Vec<i32>>) -> i32 {
        let mut cncon = HashSet::new();
        for friendship in friendships {
            let mut mp = HashSet::new();
            let mut conm = false;
            for &lan in &languages[friendship[0] as usize - 1] {
                mp.insert(lan);
            }
            for &lan in &languages[friendship[1] as usize - 1] {
                if mp.contains(&lan) {
                    conm = true;
                    break;
                }
            }
            
            if !conm {
                cncon.insert(friendship[0] - 1);
                cncon.insert(friendship[1] - 1);
            }
        }
        
        let mut max_cnt = 0;
        let mut cnt = HashMap::new();
        for &person in &cncon {
            for &lan in &languages[person as usize] {
                *cnt.entry(lan).or_insert(0) += 1;
                max_cnt = max_cnt.max(*cnt.get(&lan).unwrap());
            }
        }
        
        cncon.len() as i32 - max_cnt
    }
}
```

```Java
class Solution {
    public int minimumTeachings(int n, int[][] languages, int[][] friendships) {
        Set<Integer> cncon = new HashSet<>();
        for (int[] friendship : friendships) {
            Map<Integer, Integer> mp = new HashMap<>();
            boolean conm = false;
            for (int lan : languages[friendship[0] - 1]) {
                mp.put(lan, 1);
            }
            for (int lan : languages[friendship[1] - 1]) {
                if (mp.containsKey(lan)) {
                    conm = true;
                    break;
                }
            }
            if (!conm) {
                cncon.add(friendship[0] - 1);
                cncon.add(friendship[1] - 1);
            }
        }
        int max_cnt = 0;
        int[] cnt = new int[n + 1];
        for (int friendship : cncon) {
            for (int lan : languages[friendship]) {
                cnt[lan]++;
                max_cnt = Math.max(max_cnt, cnt[lan]);
            }
        }
        return cncon.size() - max_cnt;
    }
}
```

```CSharp
public class Solution {
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships) {
        HashSet<int> cncon = new HashSet<int>();
        foreach (var friendship in friendships) {
            HashSet<int> mp = new HashSet<int>();
            bool conm = false;
            foreach (var lan in languages[friendship[0] - 1]) {
                mp.Add(lan);
            }
            foreach (var lan in languages[friendship[1] - 1]) {
                if (mp.Contains(lan)) {
                    conm = true;
                    break;
                }
            }
            if (!conm) {
                cncon.Add(friendship[0] - 1);
                cncon.Add(friendship[1] - 1);
            }
        }
        
        int max_cnt = 0;
        int[] cnt = new int[n + 1];
        foreach (var person in cncon) {
            foreach (var lan in languages[person]) {
                cnt[lan]++;
                max_cnt = Math.Max(max_cnt, cnt[lan]);
            }
        }
        return cncon.Count - max_cnt;
    }
}
```

```Go
func minimumTeachings(n int, languages [][]int, friendships [][]int) int {
    cncon := make(map[int]bool)
    for _, friendship := range friendships {
        mp := make(map[int]bool)
        conm := false
        for _, lan := range languages[friendship[0]-1] {
            mp[lan] = true
        }
        for _, lan := range languages[friendship[1]-1] {
            if mp[lan] {
                conm = true
                break
            }
        }
        if !conm {
            cncon[friendship[0]-1] = true
            cncon[friendship[1]-1] = true
        }
    }
    
    maxCnt := 0
    cnt := make([]int, n+1)
    for person := range cncon {
        for _, lan := range languages[person] {
            cnt[lan]++
            maxCnt = max(maxCnt, cnt[lan])
        }
    }
    
    return len(cncon) - maxCnt
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

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

int minimumTeachings(int n, int** languages, int languagesSize, int* languagesColSize, 
                    int** friendships, int friendshipsSize, int* friendshipsColSize) {
    HashItem *cncon = NULL;
    for (int i = 0; i < friendshipsSize; i++) {
        HashItem *mp = NULL;
        bool conm = false;
        int person1 = friendships[i][0] - 1;
        int person2 = friendships[i][1] - 1;
        for (int j = 0; j < languagesColSize[person1]; j++) {
            hashAddItem(&mp, languages[person1][j]);
        }
        for (int j = 0; j < languagesColSize[person2]; j++) {
            if (hashFindItem(&mp, languages[person2][j])) {
                conm = true;
                break;
            }
        }
        if (!conm) {
            hashAddItem(&cncon, person1);
            hashAddItem(&cncon, person2);
        }
        hashFree(&mp);        
    }
    
    int max_cnt = 0;
    int* cnt = (int*)calloc(n + 1, sizeof(int));
    for (HashItem *pEntry = cncon; pEntry; pEntry = pEntry->hh.next) {
        int person = pEntry->key;
        for (int i = 0; i < languagesColSize[person]; i++) {
            int lan = languages[person][i];
            cnt[lan]++;
            max_cnt = fmax(max_cnt, cnt[lan]);
        }
    }
    
    int ret = HASH_COUNT(cncon) - max_cnt;
    hashFree(&cncon);
    return ret;
}
```

```JavaScript
var minimumTeachings = function(n, languages, friendships) {
    const cncon = new Set();
    for (const friendship of friendships) {
        const mp = new Set();
        let conm = false;
        for (const lan of languages[friendship[0] - 1]) {
            mp.add(lan);
        }
        for (const lan of languages[friendship[1] - 1]) {
            if (mp.has(lan)) {
                conm = true;
                break;
            }
        }
        
        if (!conm) {
            cncon.add(friendship[0] - 1);
            cncon.add(friendship[1] - 1);
        }
    }
    
    let max_cnt = 0;
    const cnt = new Array(n + 1).fill(0);
    for (const person of cncon) {
        for (const lan of languages[person]) {
            cnt[lan]++;
            max_cnt = Math.max(max_cnt, cnt[lan]);
        }
    }
    
    return cncon.size - max_cnt;
};
```

```TypeScript
function minimumTeachings(n: number, languages: number[][], friendships: number[][]): number {
    const cncon: Set<number> = new Set();
    for (const friendship of friendships) {
        const mp: Set<number> = new Set();
        let conm = false;
        for (const lan of languages[friendship[0] - 1]) {
            mp.add(lan);
        }
        for (const lan of languages[friendship[1] - 1]) {
            if (mp.has(lan)) {
                conm = true;
                break;
            }
        }
        
        if (!conm) {
            cncon.add(friendship[0] - 1);
            cncon.add(friendship[1] - 1);
        }
    }
    
    let max_cnt = 0;
    const cnt: number[] = new Array(n + 1).fill(0);
    for (const person of cncon) {
        for (const lan of languages[person]) {
            cnt[lan]++;
            max_cnt = Math.max(max_cnt, cnt[lan]);
        }
    }
    
    return cncon.size - max_cnt;
};
```

**复杂度分析**

- 时间复杂度：$O(m\times n)$，其中 $m$ 是好友对的数量，$n$ 是语言的种类数。我们需要在遍历 $friendships$ 中每对好友的过程中，遍历 $languages$ 中的每个人掌握的语言，因此时间复杂度是 $O(m\times n)$。
- 空间复杂度：$O(m+n)$，其中 $m$ 是好友对的数量，$n$ 是语言的种类数。我们需要使用 $O(m)$ 的空间存储 $cncon$ 集合，使用 $O(n)$ 的空间存储 $cnt$ 数组。
