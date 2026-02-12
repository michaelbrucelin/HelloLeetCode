### [最长的平衡子串 II](https://leetcode.cn/problems/longest-balanced-substring-ii/solutions/3896558/zui-chang-de-ping-heng-zi-chuan-ii-by-le-0g8o/)

#### 方法一：枚举 $+$ 前缀和 $+$ 哈希表

**思路与算法**

由于题目给定的字符串仅包含 $a, b$ 和 $c$ 三种字符，因此我们可分为三种情况解题：

1. 求解仅包含一种字符的最长平衡子串
2. 求解包含两种字符的最长平衡子串
3. 求解包含三种字符的最长平衡子串

对于第一种情况，也是最简单的情况，我们在从左向右遍历 $s$ 的过程中，维护变量 $last$ 表示连续多少个字符与当前字符相同（包括当前字符）。假设当前遍历到位置 $i$：

- 若 $i>0$ 且 $s[i]$ 等于 $s[i-1]$，则 $last$ 增加 $1$
- 否则，将 $last$ 置为 $1$。

每次使用 $last$ 尝试更新答案。

对于第二种情况，我们首先枚举出来这两种字符，可能是如下三种组合：$(a,b), (b,c), (a,c)$。以 $(a,b)$ 为例，字符串被字符 $c$ 分割成若干个子串，接下来我们将每个子串视作独立的字符串去处理。

我们使用数组 $S_a$ 和 $S_b$ 分别统计前缀（分割后的子串前缀）中 $a$ 和 $b$ 的个数，例如 $S_a[i]$ 表示字符串前 $i$ 个字符有多少个 $a$。因此，若子串 $s[i..j]$ 中字符 $a$ 和 $b$ 的个数相等，应该有：

$$S_a[j]-S_a[i-1]=S_b[j]-S_b[i-1]$$

我们把与 $j$ 相关的移到左边，与 $i$ 相关的移到右边，于是有：

$$S_a[j]-S_b[j]=S_a[i-1]-S_b[i-1]$$

因此，我们在从小到大枚举 $j$ 时，找到令上式相等的最小的 $i$ 即可，若存在这样的 $i$，则使用 $j-i+1$ 更新答案。我们可以使用哈希表记录每个 $S_a[i]-S_b[i]$ 最早出现的位置，加快查询。

对于第三种情况，我们仍然使用 $S_a,S_b,S_c$ 来表示前缀中 $a,b,c$ 的个数，如果某个子串 $s[i..j]$ 是平衡子串，那么有：

$$S_a[j]-S_a[i-1]=S_b[j]-S_b[i-1]$$
$$S_b[j]-S_b[i-1]=S_c[j]-S_c[i-1]$$

即 $a$ 的数量等于 $b$ 的数量，$b$ 的数量等于 $c$ 的数量，有这两个等式可推断出 $a$ 的数量等于 $c$ 的数量。

将与 $j$ 相关的移到左边，与 $i$ 相关的移到右边，于是有：

$$S_a[j]-S_b[j]=S_a[i-1]-S_b[i-1]$$
$$S_b[j]-S_c[j]=S_b[i-1]-S_c[i-1]$$

因此，和第二种情况的处理方法类似，现在我们需要对于每个 $j$ 找到使得上式成立的最小的 $i$，然后使用 $j-i+1$ 更新答案。具体来说，使用哈希表记录每个二元组 $(S_a[i]-S_b[i],S_b[i]-S_c[i])$ 的最早出现位置即可。

**代码**

```C++
class Solution {
    int case2Helper(string &s, char x, char y) {
        int n = s.size();
        int res = 0;
        unordered_map<int, int> h;
        for (int i = 0; i < n; i++) {
            if (s[i] != x && s[i] != y) {
                continue;
            }

            h.clear();
            // 分割后的子串开头，两种字符出现次数之差为 0，需要提前存放至哈希表中
            h[0] = i - 1;
            int diff = 0;
            while (i < n && (s[i] == x || s[i] == y)) {
                diff += (s[i] == x) ? 1 : -1;
                if (h.contains(diff)) {
                    res = max(res, i - h[diff]);
                } else {
                    h[diff] = i;
                }
                i++;
            }
        }
        return res;
    }
public:
    int longestBalanced(string s) {
        int n = s.size();
        int res = 0;

        // 情况一，仅包括一种字符
        int last = 0;
        for (int i = 0; i < s.size(); i++) {
            if (i > 0 && s[i] == s[i - 1]) {
                last++;
            } else {
                last = 1;
            }
            res = max(res, last);
        }

        // 情况二，包含两种字符
        res = max(res, case2Helper(s, 'a', 'b'));
        res = max(res, case2Helper(s, 'b', 'c'));
        res = max(res, case2Helper(s, 'a', 'c'));

        // 情况三，包含三种字符

        // 将二元组压缩成长整型，方便作为键值存放至哈希表
        // 由于前缀和之差存在负数，所以统一增加 n
        auto getId = [&](int x, int y) -> long long {
            return 1ll * (x + n) << 32 | (y + n);
        };

        // 字符串开头，位置为 -1 的地方，键值为 getId(0, 0)
        unordered_map<long long, int> h = {{getId(0, 0), -1}};
        int pre[3] = {0, 0, 0};
        for (int i = 0; i < n; i++) {
            pre[s[i] - 'a']++;
            long long id = getId(pre[1] - pre[0], pre[1] - pre[2]);
            if (h.contains(id)) {
                res = max(res, i - h[id]);
            } else {
                h[id] = i;
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def longestBalanced(self, s: str) -> int:
        n = len(s)
        res = 0

        # 情况一：仅包含一种字符
        last = 0
        for i in range(n):
            last = last + 1 if i > 0 and s[i] == s[i-1] else 1
            res = max(res, last)

        # 情况二：包含两种字符
        def helper(x: str, y: str) -> int:
            ans = 0
            i = 0
            while i < n:
                if s[i] != x and s[i] != y:
                    i += 1
                    continue
                h = {0: i-1}
                diff = 0
                while i < n and (s[i] == x or s[i] == y):
                    diff += 1 if s[i] == x else -1
                    if diff in h:
                        ans = max(ans, i - h[diff])
                    else:
                        h[diff] = i
                    i += 1
                i += 1
            return ans

        res = max(res, helper('a', 'b'), helper('b', 'c'), helper('a', 'c'))

        # 情况三：包含三种字符
        pre = [0, 0, 0]
        h = {(0, 0): -1}
        for i, ch in enumerate(s):
            pre[ord(ch) - 97] += 1
            key = (pre[0] - pre[1], pre[1] - pre[2])
            if key in h:
                res = max(res, i - h[key])
            else:
                h[key] = i
        return res
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn longest_balanced(s: String) -> i32 {
        let n = s.len();
        let mut res = 0;
        let bytes = s.as_bytes();

        // 情况一：仅包含一种字符
        let mut last = 0;
        for i in 0..n {
            last = if i > 0 && bytes[i] == bytes[i-1] { last + 1 } else { 1 };
            res = res.max(last as i32);
        }

        // 情况二：包含两种字符
        let helper = |x: u8, y: u8| -> i32 {
            let mut ans = 0;
            let mut i = 0;
            while i < n {
                if bytes[i] != x && bytes[i] != y {
                    i += 1;
                    continue;
                }

                let mut h = HashMap::new();
                h.insert(0, i as i32 - 1);
                let mut diff = 0;

                while i < n && (bytes[i] == x || bytes[i] == y) {
                    diff += if bytes[i] == x { 1 } else { -1 };
                    match h.get(&diff) {
                        Some(&pos) => ans = ans.max(i as i32 - pos),
                        None => { h.insert(diff, i as i32); }
                    }
                    i += 1;
                }
                i += 1;
            }
            ans
        };

        res = res.max(helper(b'a', b'b'));
        res = res.max(helper(b'b', b'c'));
        res = res.max(helper(b'a', b'c'));

        // 情况三：包含三种字符

        let mut pre = [0; 3];
        let mut h = HashMap::new();
        h.insert((0, 0), -1);

        for (i, &ch) in bytes.iter().enumerate() {
            pre[(ch - b'a') as usize] += 1;
            let key = (pre[1] - pre[0], pre[1] - pre[2]);

            match h.get(&key) {
                Some(&pos) => res = res.max(i as i32 - pos),
                None => { h.insert(key, i as i32); }
            }
        }

        res
    }
}
```

```Java
class Solution {
    private int case2Helper(String s, char x, char y) {
        int n = s.length();
        int res = 0;

        for (int i = 0; i < n; i++) {
            if (s.charAt(i) != x && s.charAt(i) != y) {
                continue;
            }

            Map<Integer, Integer> h = new HashMap<>();
            h.put(0, i - 1);
            int diff = 0;
            int j = i;
            while (j < n && (s.charAt(j) == x || s.charAt(j) == y)) {
                diff += (s.charAt(j) == x) ? 1 : -1;
                Integer prev = h.get(diff);
                if (prev != null) {
                    res = Math.max(res, j - prev);
                } else {
                    h.put(diff, j);
                }
                j++;
            }
            i = j - 1;
        }
        return res;
    }

    public int longestBalanced(String s) {
        int n = s.length();
        int res = 0;

        // 情况一，仅包括一种字符
        int last = 0;
        for (int i = 0; i < n; i++) {
            if (i > 0 && s.charAt(i) == s.charAt(i - 1)) {
                last++;
            } else {
                last = 1;
            }
            res = Math.max(res, last);
        }

        // 情况二，包含两种字符
        res = Math.max(res, case2Helper(s, 'a', 'b'));
        res = Math.max(res, case2Helper(s, 'b', 'c'));
        res = Math.max(res, case2Helper(s, 'a', 'c'));

        // 情况三，包含三种字符 - 优化：使用自定义键对象
        class Key {
            final int x, y;
            Key(int x, int y) {
                this.x = x;
                this.y = y;
            }
            @Override
            public boolean equals(Object o) {
                if (this == o) return true;
                if (o == null || getClass() != o.getClass()) return false;
                Key key = (Key) o;
                return x == key.x && y == key.y;
            }
            @Override
            public int hashCode() {
                return 31 * x + y;
            }
        }

        Map<Key, Integer> h = new HashMap<>();
        h.put(new Key(n, n), -1);

        int diffAB = 0;
        int diffBC = 0;
        for (int i = 0; i < n; i++) {
            char c = s.charAt(i);
            if (c == 'a') {
                diffAB--;
            } else if (c == 'b') {
                diffAB++;
                diffBC++;
            } else {
                diffBC--;
            }

            Key key = new Key(diffAB + n, diffBC + n);
            Integer prev = h.get(key);
            if (prev != null) {
                res = Math.max(res, i - prev);
            } else {
                h.put(key, i);
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    private int Case2Helper(string s, char x, char y) {
        int n = s.Length;
        int res = 0;
        Dictionary<int, int> h = new Dictionary<int, int>();

        for (int i = 0; i < n; i++) {
            if (s[i] != x && s[i] != y) {
                continue;
            }

            h.Clear();
            // 分割后的子串开头，两种字符出现次数之差为 0，需要提前存放至哈希表中
            h[0] = i - 1;
            int diff = 0;
            while (i < n && (s[i] == x || s[i] == y)) {
                diff += (s[i] == x) ? 1 : -1;
                if (h.ContainsKey(diff)) {
                    res = Math.Max(res, i - h[diff]);
                } else {
                    h[diff] = i;
                }
                i++;
            }
        }
        return res;
    }

    public int LongestBalanced(string s) {
        int n = s.Length;
        int res = 0;

        // 情况一，仅包括一种字符
        int last = 0;
        for (int i = 0; i < n; i++) {
            if (i > 0 && s[i] == s[i - 1]) {
                last++;
            } else {
                last = 1;
            }
            res = Math.Max(res, last);
        }

        // 情况二，包含两种字符
        res = Math.Max(res, Case2Helper(s, 'a', 'b'));
        res = Math.Max(res, Case2Helper(s, 'b', 'c'));
        res = Math.Max(res, Case2Helper(s, 'a', 'c'));

        // 情况三，包含三种字符
        Dictionary<string, int> h = new Dictionary<string, int>();
        // 字符串开头，位置为 -1 的地方，键值为 getId(0, 0)
        h[GetId(0, 0, n)] = -1;

        int[] pre = new int[3];
        for (int i = 0; i < n; i++) {
            pre[s[i] - 'a']++;
            string id = GetId(pre[1] - pre[0], pre[1] - pre[2], n);
            if (h.ContainsKey(id)) {
                res = Math.Max(res, i - h[id]);
            } else {
                h[id] = i;
            }
        }
        return res;
    }

    private string GetId(int x, int y, int n) {
        return (x + n) + "_" + (y + n);
    }
}
```

```Go
func case2Helper(s string, x, y byte) int {
    n := len(s)
    res := 0

    for i := 0; i < n; i++ {
        if s[i] != x && s[i] != y {
            continue
        }

        h := make(map[int]int)
        h[0] = i - 1
        diff := 0
        j := i
        for j < n && (s[j] == x || s[j] == y) {
            if s[j] == x {
                diff++
            } else {
                diff--
            }

            if prev, exists := h[diff]; exists {
                if j-prev > res {
                    res = j - prev
                }
            } else {
                h[diff] = j
            }
            j++
        }
        i = j - 1
    }
    return res
}

func longestBalanced(s string) int {
    n := len(s)
    res := 0

    // 情况一，仅包括一种字符
    last := 0
    for i := 0; i < n; i++ {
        if i > 0 && s[i] == s[i - 1] {
            last++
        } else {
            last = 1
        }
        if last > res {
            res = last
        }
    }

    // 情况二，包含两种字符
    res = max(res, case2Helper(s, 'a', 'b'))
    res = max(res, case2Helper(s, 'b', 'c'))
    res = max(res, case2Helper(s, 'a', 'c'))

    // 情况三，包含三种字符
    type Key struct {
        x, y int
    }
    h := make(map[Key]int)
    h[Key{n, n}] = -1

    diffAB := 0
    diffBC := 0
    for i := 0; i < n; i++ {
        c := s[i]
        switch c {
            case 'a':
                diffAB--
            case 'b':
                diffAB++
                diffBC++
            case 'c':
                diffBC--
        }

        key := Key{diffAB + n, diffBC + n}
        if prev, exists := h[key]; exists {
            res = max(res, i - prev)
        } else {
            h[key] = i
        }
    }
    return res
}
```

```C
typedef struct {
    long long key;
    int val;
    UT_hash_handle hh;
} HashItem;


HashItem* hashFindItem(HashItem** obj, long long key) {
    HashItem* pEntry = NULL;
    HASH_FIND(hh, *obj, &key, sizeof(long long), pEntry);
    return pEntry;
}

bool hashAddItem(HashItem** obj, long long key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem* pEntry = (HashItem*)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_KEYPTR(hh, *obj, &pEntry->key, sizeof(long long), pEntry);
    return true;
}

bool hashSetItem(HashItem** obj, long long key, int val) {
    HashItem* pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetItem(HashItem** obj, long long key, int defaultVal) {
    HashItem* pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

void hashFree(HashItem** obj) {
    HashItem* curr = NULL;
    HashItem* tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr);
    }
}

// 情况二的辅助函数
int case2Helper(char* s, char x, char y) {
    int n = strlen(s);
    int res = 0;

    for (int i = 0; i < n; i++) {
        if (s[i] != x && s[i] != y) {
            continue;
        }

        HashItem* h = NULL;
        hashAddItem(&h, 0, i - 1);
        int diff = 0;
        int j = i;

        while (j < n && (s[j] == x || s[j] == y)) {
            diff += (s[j] == x) ? 1 : -1;
            HashItem* prevEntry = hashFindItem(&h, diff);
            if (prevEntry != NULL) {
                int length = j - prevEntry->val;
                if (length > res) {
                    res = length;
                }
            } else {
                hashAddItem(&h, diff, j);
            }
            j++;
        }

        hashFree(&h);
        i = j - 1;
    }

    return res;
}

int longestBalanced(char* s) {
    int n = strlen(s);
    int res = 0;

    // 情况一：仅包括一种字符
    int last = 0;
    for (int i = 0; i < n; i++) {
        if (i > 0 && s[i] == s[i - 1]) {
            last++;
        } else {
            last = 1;
        }
        if (last > res) {
            res = last;
        }
    }

    // 情况二：包含两种字符
    res = fmax(res, case2Helper(s, 'a', 'b'));
    res = fmax(res, case2Helper(s, 'b', 'c'));
    res = fmax(res, case2Helper(s, 'a', 'c'));

    // 情况三：包含三种字符
    HashItem* h = NULL;
    long long initKey = ((long long)n << 32) | n;
    hashAddItem(&h, initKey, -1);
    int diffAB = 0;
    int diffBC = 0;

    for (int i = 0; i < n; i++) {
        char c = s[i];
        switch (c) {
            case 'a':
                diffAB--;
                break;
            case 'b':
                diffAB++;
                diffBC++;
                break;
            case 'c':
                diffBC--;
                break;
        }

        long long key = ((long long)(diffAB + n) << 32) | (diffBC + n);
        HashItem* prevEntry = hashFindItem(&h, key);
        if (prevEntry != NULL) {
            int length = i - prevEntry->val;
            if (length > res) {
                res = length;
            }
        } else {
            hashAddItem(&h, key, i);
        }
    }

    hashFree(&h);
    return res;
}
```

```JavaScript
var longestBalanced = function(s) {
    const case2Helper = (s, x, y) => {
        const n = s.length;
        let res = 0;
        let h = new Map();

        for (let i = 0; i < n; i++) {
            if (s[i] !== x && s[i] !== y) {
                continue;
            }

            h.clear();
            // 分割后的子串开头，两种字符出现次数之差为 0，需要提前存放至哈希表中
            h.set(0, i - 1);
            let diff = 0;
            while (i < n && (s[i] === x || s[i] === y)) {
                diff += (s[i] === x) ? 1 : -1;
                if (h.has(diff)) {
                    res = Math.max(res, i - h.get(diff));
                } else {
                    h.set(diff, i);
                }
                i++;
            }
        }
        return res;
    };

    const n = s.length;
    let res = 0;

    // 情况一，仅包括一种字符
    let last = 0;
    for (let i = 0; i < n; i++) {
        if (i > 0 && s[i] === s[i - 1]) {
            last++;
        } else {
            last = 1;
        }
        res = Math.max(res, last);
    }

    // 情况二，包含两种字符
    res = Math.max(res, case2Helper(s, 'a', 'b'));
    res = Math.max(res, case2Helper(s, 'b', 'c'));
    res = Math.max(res, case2Helper(s, 'a', 'c'));

    // 情况三，包含三种字符
    const getId = (x, y) => {
        return `${x + n}_${y + n}`;
    };

    const h = new Map();
    // 字符串开头，位置为 -1 的地方，键值为 getId(0, 0)
    h.set(getId(0, 0), -1);

    const pre = [0, 0, 0];
    for (let i = 0; i < n; i++) {
        pre[s.charCodeAt(i) - 97]++; // 'a'.charCodeAt(0) = 97
        const id = getId(pre[1] - pre[0], pre[1] - pre[2]);
        if (h.has(id)) {
            res = Math.max(res, i - h.get(id));
        } else {
            h.set(id, i);
        }
    }
    return res;
}
```

```TypeScript
function longestBalanced(s: string): number {
    const case2Helper = (s: string, x: string, y: string): number => {
        const n = s.length;
        let res = 0;
        let h = new Map<number, number>();

        for (let i = 0; i < n; i++) {
            if (s[i] !== x && s[i] !== y) {
                continue;
            }

            h.clear();
            // 分割后的子串开头，两种字符出现次数之差为 0，需要提前存放至哈希表中
            h.set(0, i - 1);
            let diff = 0;
            while (i < n && (s[i] === x || s[i] === y)) {
                diff += (s[i] === x) ? 1 : -1;
                if (h.has(diff)) {
                    res = Math.max(res, i - h.get(diff)!);
                } else {
                    h.set(diff, i);
                }
                i++;
            }
        }
        return res;
    };

    const n = s.length;
    let res = 0;

    // 情况一，仅包括一种字符
    let last = 0;
    for (let i = 0; i < n; i++) {
        if (i > 0 && s[i] === s[i - 1]) {
            last++;
        } else {
            last = 1;
        }
        res = Math.max(res, last);
    }

    // 情况二，包含两种字符
    res = Math.max(res, case2Helper(s, 'a', 'b'));
    res = Math.max(res, case2Helper(s, 'b', 'c'));
    res = Math.max(res, case2Helper(s, 'a', 'c'));

    // 情况三，包含三种字符
    const getId = (x: number, y: number): string => {
        return `${x + n}_${y + n}`;
    };

    const h = new Map<string, number>();
    // 字符串开头，位置为 -1 的地方，键值为 getId(0, 0)
    h.set(getId(0, 0), -1);

    const pre = [0, 0, 0];
    for (let i = 0; i < n; i++) {
        pre[s.charCodeAt(i) - 97]++; // 'a'.charCodeAt(0) = 97
        const id = getId(pre[1] - pre[0], pre[1] - pre[2]);
        if (h.has(id)) {
            res = Math.max(res, i - h.get(id)!);
        } else {
            h.set(id, i);
        }
    }
    return res;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn longest_balanced(s: String) -> i32 {
        fn case2_helper(s: &str, x: char, y: char) -> i32 {
            let n = s.len();
            let mut res = 0;
            let mut h = HashMap::new();
            let chars: Vec<char> = s.chars().collect();

            let mut i = 0;
            while i < n {
                if chars[i] != x && chars[i] != y {
                    i += 1;
                    continue;
                }

                h.clear();
                // 分割后的子串开头，两种字符出现次数之差为 0，需要提前存放至哈希表中
                h.insert(0, i as i32 - 1);
                let mut diff = 0;
                while i < n && (chars[i] == x || chars[i] == y) {
                    if chars[i] == x {
                        diff += 1;
                    } else {
                        diff -= 1;
                    }
                    if let Some(&prev) = h.get(&diff) {
                        res = res.max(i as i32 - prev);
                    } else {
                        h.insert(diff, i as i32);
                    }
                    i += 1;
                }
            }
            res
        }

        let n = s.len();
        let mut res = 0;

        // 情况一，仅包括一种字符
        let mut last = 0;
        let chars: Vec<char> = s.chars().collect();
        for i in 0..n {
            if i > 0 && chars[i] == chars[i - 1] {
                last += 1;
            } else {
                last = 1;
            }
            res = res.max(last);
        }

        // 情况二，包含两种字符
        res = res.max(case2_helper(&s, 'a', 'b'));
        res = res.max(case2_helper(&s, 'b', 'c'));
        res = res.max(case2_helper(&s, 'a', 'c'));

        // 情况三，包含三种字符
        let get_id = |x: i32, y: i32| -> (i32, i32) {
            (x + n as i32, y + n as i32)
        };

        let mut h = HashMap::new();
        // 字符串开头，位置为 -1 的地方
        h.insert(get_id(0, 0), -1);

        let mut pre = [0; 3];
        for i in 0..n {
            pre[(chars[i] as u8 - b'a') as usize] += 1;
            let id = get_id(pre[1] - pre[0], pre[1] - pre[2]);
            if let Some(&prev) = h.get(&id) {
                res = res.max(i as i32 - prev);
            } else {
                h.insert(id, i as i32);
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。三种情况的处理过程我们都只使用了一次遍历，并且访问哈希表、将值存入哈希表的时间复杂度均为 $O(1)$，因此总体时间复杂度为 $O(n)$。
- 空间复杂度：$O(n)$。使用哈希表的空间复杂度为 $O(n)$。
