### [找出出现至少三次的最长特殊子字符串 II](https://leetcode.cn/problems/find-longest-special-substring-that-occurs-thrice-ii/solutions/2792836/zhao-chu-chu-xian-zhi-shao-san-ci-de-zui-pdem/)

#### 方法一：二分查找

**思路与算法**

根据题意可以知道所谓的**特殊**字符串即字符串中所有的字符均相等，题目要求至少**出现三次**的**最长特殊**子字符串的长度。假设当前**特殊**字符串的长度为 $l$，则该字符串中长度为 $k$ 的**特殊**子字符串的次数为 $\max(0, l - k + 1)$ 次。例如 $\text{''aaaaaaa''}$ 中出现 $\text{''aaa''}$ 次数即为 $5$ 次，出现 $\text{''aaaaaaaa''}$ 的次数为 $0$ 次。

由于**特殊**字符串只含有一种字符，因此我们单独考虑每种字符，找到每种字符在字符串中出现的连续长度。假设字符 $a$ 在字符串 $s$ 中出现的连续长度分别为 $l_0,l_1, l_2, \cdots, l_m$，此时出现长度为 $k$ 的子字符串数目为 $C = \sum_{i=0}^{m} \max(l_i - k + 1, 0)$ 次。根据推论可知，如果长度 $k_1$ 出现的次数 $3$ 次，则出现长度 $k_2$ 且满足 $k_2 < k_1$ 的次数也一定大于等于 $3$ 次；如果长度 $k_1$ 出现的次数不足 $3$ 次，则长度 $k_2$ 且满足 $k_2 > k_1$ 的次数也一定不足 $3$ 次，此时满足单调性，我们可以用二分查找来找到最大的长度。对于给定的长度 $l$，如果出现长度大于等于 $l$ 的次数大于 $3$ 次，则增加 $l$，否则则减小 $l$，直到找到最大满足要求的 $l$ 返回即可。

**代码**

```C++
class Solution {
public:
    int maximumLength(string s) {
        int n = s.size();
        unordered_map<char, vector<int>> cnt;
        for (int i = 0, j = 0; i < s.size(); i = j) {
            while (j < s.size() && s[j] == s[i]) {
                j++;
            }
            cnt[s[i]].emplace_back(j - i);
        }
        
        int res = -1;
        for (auto &[_, vec] : cnt) {
            int lo = 1, hi = n - 2;
            while (lo <= hi) {
                int mid = (lo + hi) >> 1;
                int count = 0;
                for (int x : vec) {
                    if (x >= mid) {
                        count += x - mid + 1;
                    }
                }
                if (count >= 3) {
                    res = max(res, mid);
                    lo = mid + 1;
                } else {
                    hi = mid - 1;
                }
            }
        }
        return res;
    }
};
```

```C
struct ListNode *createListNode(int val) {
    struct ListNode *obj = (struct ListNode *)malloc(sizeof(struct ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

void freeList(struct ListNode *list) {
    while (list) {
        struct ListNode *p = list;
        list = list->next;
    }
}

int maximumLength(char* s) {
    int n = strlen(s);
    struct ListNode *cnt[26];
    for (int i = 0; i < 26; i++) {
        cnt[i] = NULL;
    }
    for (int i = 0, j = 0; i < n; i = j) {
        while (j < n && s[j] == s[i]) {
            j++;
        }
        struct ListNode *node = createListNode(j - i);
        node->next = cnt[s[i] - 'a'];
        cnt[s[i] - 'a'] = node;
    }
    
    int res = -1;
    for (int i = 0; i < 26; i++) {
        int lo = 1, hi = n - 2;
        while (lo <= hi) {
            int mid = (lo + hi) >> 1;
            int count = 0;
            for (struct ListNode *p = cnt[i]; p; p = p->next) {
                if (p->val >= mid) {
                    count += p->val - mid + 1;
                }
            }
            if (count >= 3) {
                res = fmax(res, mid);
                lo = mid + 1;
            } else {
                hi = mid - 1;
            }
        }
    }

    for (int i = 0; i < 26; i++) {
        free(cnt[i]);
    }
    return res;
}
```

```Java
class Solution {
    public int maximumLength(String s) {
        int n = s.length();
        Map<Character, List<Integer>> cnt = new HashMap<>();
        
        for (int i = 0, j = 0; i < n; i = j) {
            while (j < n && s.charAt(j) == s.charAt(i)) {
                j++;
            }
            cnt.computeIfAbsent(s.charAt(i), k -> new ArrayList<>()).add(j - i);
        }

        int res = -1;
        for (List<Integer> vec : cnt.values()) {
            int lo = 1, hi = n - 2;
            while (lo <= hi) {
                int mid = (lo + hi) >> 1;
                int count = 0;
                for (int x : vec) {
                    if (x >= mid) {
                        count += x - mid + 1;
                    }
                }
                if (count >= 3) {
                    res = Math.max(res, mid);
                    lo = mid + 1;
                } else {
                    hi = mid - 1;
                }
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int MaximumLength(string s) {
        int n = s.Length;
        IDictionary<char, IList<int>> cnt = new Dictionary<char, IList<int>>();

        for (int i = 0, j = 0; i < n; i = j) {
            while (j < n && s[j] == s[i]) {
                j++;
            }
            cnt.TryAdd(s[i], new List<int>());
            cnt[s[i]].Add(j - i);
        }

        int res = -1;
        foreach (IList<int> vec in cnt.Values) {
            int lo = 1, hi = n - 2;
            while (lo <= hi) {
                int mid = (lo + hi) >> 1;
                int count = 0;
                foreach (int x in vec) {
                    if (x >= mid) {
                        count += x - mid + 1;
                    }
                }
                if (count >= 3) {
                    res = Math.Max(res, mid);
                    lo = mid + 1;
                } else {
                    hi = mid - 1;
                }
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    def maximumLength(self, s: str) -> int:
        n = len(s)
        cnt = {}

        i = 0
        while i < n:
            j = i
            while j < n and s[j] == s[i]:
                j += 1
            if s[i] not in cnt:
                cnt[s[i]] = []
            cnt[s[i]].append(j - i)
            i = j
            
        res = -1
        for vec in cnt.values():
            lo, hi = 1, n - 2
            while lo <= hi:
                mid = (lo + hi) // 2
                count = 0
                for x in vec:
                    if x >= mid:
                        count += x - mid + 1
                if count >= 3:
                    res = max(res, mid)
                    lo = mid + 1
                else:
                    hi = mid - 1
        return res
```

```Go
func maximumLength(s string) int {
    n := len(s)
    cnt := make(map[byte][]int)
    for i, j := 0, 0; i < n; i = j {
        for j < n && s[j] == s[i] {
            j++
        }
        cnt[s[i]] = append(cnt[s[i]], j - i)
    }
    
    res := -1
    for _, vec := range cnt {
        lo, hi := 1, n - 2
        for lo <= hi {
            mid := (lo + hi) >> 1
            count := 0
            for _, x := range vec {
                if x >= mid {
                    count += x - mid + 1
                }
            }
            if count >= 3 {
                if mid > res {
                    res = mid
                }
                lo = mid + 1
            } else {
                hi = mid - 1
            }
        }
    }
    return res
}
```

```JavaScript
var maximumLength = function(s) {
    const n = s.length;
    const cnt = new Map();
    
    for (let i = 0, j = 0; i < n; i = j) {
        while (j < n && s[j] === s[i]) {
            j++;
        }
        const len = j - i;
        if (!cnt.has(s[i])) {
            cnt.set(s[i], []);
        }
        cnt.get(s[i]).push(len);
    }
    
    let res = -1;
    for (const vec of cnt.values()) {
        let lo = 1, hi = n - 2;
        while (lo <= hi) {
            const mid = (lo + hi) >> 1;
            let count = 0;
            for (const x of vec) {
                if (x >= mid) {
                    count += x - mid + 1;
                }
            }
            if (count >= 3) {
                res = Math.max(res, mid);
                lo = mid + 1;
            } else {
                hi = mid - 1;
            }
        }
    }
    return res;
};
```

```Typescript
function maximumLength(s: string): number {
    const n = s.length;
    const cnt = new Map<string, number[]>();
    
    for (let i = 0, j = 0; i < n; i = j) {
        while (j < n && s[j] === s[i]) {
            j++;
        }
        const len = j - i;
        if (!cnt.has(s[i])) {
            cnt.set(s[i], []);
        }
        cnt.get(s[i])!.push(len);
    }
    
    let res = -1;
    for (const vec of cnt.values()) {
        let lo = 1, hi = n - 2;
        while (lo <= hi) {
            const mid = (lo + hi) >> 1;
            let count = 0;
            for (const x of vec) {
                if (x >= mid) {
                    count += x - mid + 1;
                }
            }
            if (count >= 3) {
                res = Math.max(res, mid);
                lo = mid + 1;
            } else {
                hi = mid - 1;
            }
        }
    }
    return res;
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn maximum_length(s: String) -> i32 {
        let n = s.len();
        let mut cnt = HashMap::new();
        let s_bytes = s.as_bytes();
        
        let mut i = 0;
        while i < n {
            let mut j = i;
            while j < n && s_bytes[j] == s_bytes[i] {
                j += 1;
            }
            cnt.entry(s_bytes[i])
                .or_insert_with(Vec::new)
                .push((j - i) as i32);
            i = j;
        }
        
        let mut res = -1;
        for vec in cnt.values() {
            let mut lo = 1;
            let mut hi = (n as i32) - 2;
            while lo <= hi {
                let mid = (lo + hi) / 2;
                let mut count = 0;
                for &x in vec {
                    if x >= mid {
                        count += x - mid + 1;
                    }
                }
                if count >= 3 {
                    res = res.max(mid);
                    lo = mid + 1;
                } else {
                    hi = mid - 1;
                }
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \log n)$，其中 $n$ 表示字符串的长度。对每种字符进行二分查找，每次二分查找需要的时间为 $O(n \log n)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示字符串的长度。需要存储每种字符字符串中连续相同字符的长度，需要的存储空间最多为 $O(n)$。

#### 方法二：一次遍历

**思路与算法**

当然我们可以进一步进行优化，由于题目只要求出现次数大于等于 $3$ 次即可，实际我们只需要找到每种字符的最长的 $3$ 个长度即可，从这 $3$ 个长度一定可以找到出现次数大于等于 $3$ 的最长**子字符串**。

假设字符 $c$ 的最大三个长度分别为 $l_0, l_1, l_2$，此时有以几种情形：

- 从最长的 $l_0$ 种取三个长度为 $l_0 - 2$ 的子串；
- 从最大的 $l_0$ 与次长的 $l_1$ 中取三个子串：
  - 如果 $l_0 = l_1$，此时可以取三个长度为 $l_0-1$ 的子串；
  - 如果 $l_0 > l_1$，此时可以从 $l_0$ 中取 $2$ 个长度 $l_1$ 的子串，从 $l_1$ 中取一个长度为 $l_1$ 的子串；
  - 上述两种情况合并为至少可以取三个长度为 $\min(l_0-1,l_1)$ 的子串;
- 从最长、次长、第三长的子串中分别取长度为 $l_2$ 的子串；

上述三种情况取最大值即可得到: $l = \max(l_0-2,\min(l_0-1,l_1), l_2)$ 
此时字符 $c$ 构成的最长**子字符串**的长度即为 $l$，对所有的字符求其可取的长度，并返回最大值即可。如果求的最大值为 $0$ 时，此时需按照题目要求返回 $-1$。

**代码**

```C++
class Solution {
public:
    int maximumLength(string s) {
        int n = s.size();
        vector<vector<int>> cnt(26, vector<int>(3));
        for (int i = 0, j = 0; i < s.size(); i = j) {
            while (j < s.size() && s[j] == s[i]) {
                j++;
            }
            int index = s[i] - 'a';
            int len = j - i;
            if (len > cnt[index][0]) {
                cnt[index][2] = cnt[index][1];
                cnt[index][1] = cnt[index][0];
                cnt[index][0] = len;
            } else if (len > cnt[index][1]) {
                cnt[index][2] = cnt[index][1];
                cnt[index][1] = len;
            } else if (len > cnt[index][2]) {
                cnt[index][2] = len;
            }
        }
        
        int res = 0;
        for (auto vec : cnt) {
            res = max({res, vec[0] - 2, min(vec[0] - 1, vec[1]), vec[2]});
        }
        return res ? res : -1;
    }
};
```

```C
int maximumLength(char* s) {
    int n = strlen(s);
    int cnt[26][3] = {0};

    for (int i = 0, j = 0; i < n; i = j) {
        while (j < n && s[j] == s[i]) {
            j++;
        }
        int index = s[i] - 'a';
        int len = j - i;
        if (len > cnt[index][0]) {
            cnt[index][2] = cnt[index][1];
            cnt[index][1] = cnt[index][0];
            cnt[index][0] = len;
        } else if (len > cnt[index][1]) {
            cnt[index][2] = cnt[index][1];
            cnt[index][1] = len;
        } else if (len > cnt[index][2]) {
            cnt[index][2] = len;
        }
    }

    int res = 0;
    for (int i = 0; i < 26; i++) {
        res = fmax(res, fmax(cnt[i][0] - 2, fmin(cnt[i][0] - 1, cnt[i][1])));
        res = fmax(res, cnt[i][2]);
    }
    return res != 0 ? res : -1;
}
```

```Java
class Solution {
    public int maximumLength(String s) {
        int n = s.length();
        int[][] cnt = new int[26][3];
        
        for (int i = 0, j = 0; i < s.length(); i = j) {
            while (j < s.length() && s.charAt(j) == s.charAt(i)) {
                j++;
            }
            int index = s.charAt(i) - 'a';
            int len = j - i;
            if (len > cnt[index][0]) {
                cnt[index][2] = cnt[index][1];
                cnt[index][1] = cnt[index][0];
                cnt[index][0] = len;
            } else if (len > cnt[index][1]) {
                cnt[index][2] = cnt[index][1];
                cnt[index][1] = len;
            } else if (len > cnt[index][2]) {
                cnt[index][2] = len;
            }
        }
        
        int res = 0;
        for (int[] vec : cnt) {
            res = Math.max(res, Math.max(vec[0] - 2, Math.min(vec[0] - 1, vec[1])));
            res = Math.max(res, vec[2]);
        }
        return res != 0 ? res : -1;
    }
}
```

```CSharp
public class Solution {
    public int MaximumLength(string s) {
        int n = s.Length;
        var cnt = new int[26, 3]; 
        for (int i = 0, j = 0; i < n; i = j) {
            while (j < n && s[j] == s[i]) {
                j++;
            }
            int index = s[i] - 'a';
            int len = j - i;
            if (len > cnt[index, 0]) {
                cnt[index, 2] = cnt[index, 1];
                cnt[index, 1] = cnt[index, 0];
                cnt[index, 0] = len;
            } else if (len > cnt[index, 1]) {
                cnt[index, 2] = cnt[index, 1];
                cnt[index, 1] = len;
            } else if (len > cnt[index, 2]) {
                cnt[index, 2] = len;
            }
        }

        int res = 0;
        for (int k = 0; k < 26; k++) {
            res = Math.Max(res, cnt[k, 0] - 2);
            res = Math.Max(res, Math.Min(cnt[k, 0] - 1, cnt[k, 1]));
            res = Math.Max(res, cnt[k, 2]);
        }
        return res != 0 ? res : -1;
    }
}
```

```Python
class Solution:
    def maximumLength(self, s: str) -> int:
        n = len(s)
        cnt = [[0] * 3 for _ in range(26)]
        
        i = 0
        while i < n:
            j = i
            while j < n and s[j] == s[i]:
                j += 1
            index = ord(s[i]) - ord('a')
            length = j - i
            if length > cnt[index][0]:
                cnt[index][0], cnt[index][1], cnt[index][2] = length, cnt[index][0], cnt[index][1]
            elif length > cnt[index][1]:
                cnt[index][1], cnt[index][2] = length, cnt[index][1]
            elif length > cnt[index][2]:
                cnt[index][2] = length
            i = j

        res = 0
        for vec in cnt:
            res = max(res, vec[0] - 2, min(vec[0] - 1, vec[1]), vec[2])
        return res if res != 0 else -1
```

```Go
func maximumLength(s string) int {
    n := len(s)
    cnt := make([][3]int, 26)
    
    for i, j := 0, 0; i < n; i = j {
        for j < n && s[j] == s[i] {
            j++
        }
        index := s[i] - 'a'
        length := j - i
        if length > cnt[index][0] {
            cnt[index][0], cnt[index][1], cnt[index][2] = length, cnt[index][0], cnt[index][1]
        } else if length > cnt[index][1] {
            cnt[index][1], cnt[index][2] = length, cnt[index][1]
        } else if length > cnt[index][2] {
            cnt[index][2] = length
        }
    }
    
    res := 0
    for _, vec := range cnt {
        res = max(res, max(vec[0] - 2, min(vec[0] - 1, vec[1])))
        res = max(res, vec[2])
    }
    if res != 0 {
        return res
    }
    return -1
}
```

```JavaScript
var maximumLength = function(s) {
    const n = s.length;
    const cnt = Array.from({ length: 26 }, () => Array(3).fill(0));

    let i = 0;
    while (i < n) {
        let j = i;
        while (j < n && s[j] === s[i]) {
            j++;
        }
        const index = s.charCodeAt(i) - 97;
        const len = j - i;
        if (len > cnt[index][0]) {
            [cnt[index][0], cnt[index][1], cnt[index][2]] = [len, cnt[index][0], cnt[index][1]];
        } else if (len > cnt[index][1]) {
            [cnt[index][1], cnt[index][2]] = [len, cnt[index][1]];
        } else if (len > cnt[index][2]) {
            cnt[index][2] = len;
        }
        i = j;
    }

    let res = 0;
    for (const vec of cnt) {
        res = Math.max(...[res, vec[0] - 2, Math.min(vec[0] - 1, vec[1])], vec[2]);
    }
    return res !== 0 ? res : -1;
};
```

```Typescript
function maximumLength(s: string): number {
    const n = s.length;
    const cnt = Array.from({ length: 26 }, () => Array(3).fill(0));

    let i = 0;
    while (i < n) {
        let j = i;
        while (j < n && s[j] === s[i]) {
            j++;
        }
        const index = s.charCodeAt(i) - 97;
        const len = j - i;
        if (len > cnt[index][0]) {
            [cnt[index][0], cnt[index][1], cnt[index][2]] = [len, cnt[index][0], cnt[index][1]];
        } else if (len > cnt[index][1]) {
            [cnt[index][1], cnt[index][2]] = [len, cnt[index][1]];
        } else if (len > cnt[index][2]) {
            cnt[index][2] = len;
        }
        i = j;
    }

    let res = 0;
    for (const vec of cnt) {
        res = Math.max(...[res, vec[0] - 2, Math.min(vec[0] - 1, vec[1])], vec[2]);
    }
    return res !== 0 ? res : -1;
};
```

```Rust
impl Solution {
    pub fn maximum_length(s: String) -> i32 {
        let n = s.len();
        let mut cnt = vec![vec![0; 3]; 26];
        
        let s_bytes = s.as_bytes();
        let mut i = 0;
        while i < n {
            let mut j = i;
            while j < n && s_bytes[j] == s_bytes[i] {
                j += 1;
            }
            let index = (s_bytes[i] - b'a') as usize;
            let len = (j - i) as i32;
            if len > cnt[index][0] {
                cnt[index][2] = cnt[index][1];
                cnt[index][1] = cnt[index][0];
                cnt[index][0] = len;
            } else if len > cnt[index][1] {
                cnt[index][2] = cnt[index][1];
                cnt[index][1] = len;
            } else if len > cnt[index][2] {
                cnt[index][2] = len;
            }
            i = j;
        }

        let mut res = 0;
        for vec in cnt.iter() {
            res = *[res, vec[0] - 2, (vec[0] - 1).min(vec[1]), vec[2]].iter().max().unwrap();
        }
        if res != 0 {
            res
        } else {
            -1
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 表示字符串的长度。只需遍历一遍字符串即可。
- 空间复杂度：$O(|\Sigma|)$，其中 $|\Sigma|$ 表示字符集的大小。需要维护的每种字符最大的三个长度。
