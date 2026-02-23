### [检查一个字符串是否包含所有长度为 $K$ 的二进制子串]()

#### 方法一：哈希表

我们遍历字符串 $s$，并用一个哈希集合（$HashSet$）存储所有长度为 $k$ 的子串。在遍历完成后，只需要判断哈希集合中是否有 $2^k$ 项即可，这是因为长度为 $k$ 的二进制串的数量为 $2^k$。

注意到如果 $s$ 包含 $2^k$ 个长度为 $k$ 的二进制串，那么它的长度至少为 $2^k+k-1$。因此我们可以在遍历前判断 $s$ 是否足够长。

```C++
class Solution {
public:
    bool hasAllCodes(string s, int k) {
        if (s.size() < (1 << k) + k - 1) {
            return false;
        }

        unordered_set<string> exists;
        for (int i = 0; i + k <= s.size(); ++i) {
            exists.insert(move(s.substr(i, k)));
        }
        return exists.size() == (1 << k);
    }
};
```

```C++
// C++17
class Solution {
public:
    bool hasAllCodes(string s, int k) {
        if (s.size() < (1 << k) + k - 1) {
            return false;
        }

        string_view sv(s);
        unordered_set<string_view> exists;
        for (int i = 0; i + k <= s.size(); ++i) {
            exists.insert(sv.substr(i, k));
        }
        return exists.size() == (1 << k);
    }
};
```

```Python
class Solution:
    def hasAllCodes(self, s: str, k: int) -> bool:
        if len(s) < (1 << k) + k - 1:
            return False

        exists = set(s[i:i+k] for i in range(len(s) - k + 1))
        return len(exists) == (1 << k)
```

```Java
class Solution {
    public boolean hasAllCodes(String s, int k) {
        if (s.length() < (1 << k) + k - 1) {
            return false;
        }

        Set<String> exists = new HashSet<String>();
        for (int i = 0; i + k <= s.length(); ++i) {
            exists.add(s.substring(i, i + k));
        }
        return exists.size() == (1 << k);
    }
}
```

```CSharp
public class Solution {
    public bool HasAllCodes(string s, int k) {
        if (s.Length < (1 << k) + k - 1) {
            return false;
        }

        HashSet<string> exists = new HashSet<string>();
        for (int i = 0; i + k <= s.Length; ++i) {
            exists.Add(s.Substring(i, k));
        }
        return exists.Count == (1 << k);
    }
}
```

```Go
func hasAllCodes(s string, k int) bool {
    if len(s) < (1 << k) + k - 1 {
        return false
    }

    exists := make(map[string]bool)
    for i := 0; i + k <= len(s); i++ {
        substring := s[i:i+k]
        exists[substring] = true
    }
    return len(exists) == (1 << k)
}
```

```C

typedef struct {
    char *key;
    UT_hash_handle hh;
} HashItem;

HashItem *hashFindItem(HashItem **obj, char *key) {
    HashItem *pEntry = NULL;
    HASH_FIND_STR(*obj, key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, char *key) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = strdup(key);
    HASH_ADD_STR(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr->key);
        free(curr);
    }
}

bool hasAllCodes(char* s, int k) {
    int len = strlen(s);
    int total = 1 << k;
    if (len < total + k - 1) {
        return false;
    }

    HashItem *exists = NULL;
    for (int i = 0; i + k <= len; ++i) {
        char tmp[k + 1];
        strncpy(tmp, s + i, k);
        tmp[k] = '\0';
        hashAddItem(&exists, tmp);
    }

    bool ret = HASH_COUNT(exists) == (1 << k);
    hashFree(&exists);
    return ret;
}
```

```JavaScript
var hasAllCodes = function(s, k) {
    if (s.length < (1 << k) + k - 1) {
        return false;
    }

    const exists = new Set();
    for (let i = 0; i + k <= s.length; ++i) {
        exists.add(s.substring(i, i + k));
    }
    return exists.size === (1 << k);
};
```

```TypeScript
function hasAllCodes(s: string, k: number): boolean {
    if (s.length < (1 << k) + k - 1) {
        return false;
    }

    const exists = new Set<string>();
    for (let i = 0; i + k <= s.length; ++i) {
        exists.add(s.substring(i, i + k));
    }
    return exists.size === (1 << k);
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn has_all_codes(s: String, k: i32) -> bool {
        let k = k as usize;
        let total = 1 << k;

        if s.len() < total + k - 1 {
            return false;
        }

        let mut exists = HashSet::new();
        for i in 0..=(s.len() - k) {
            exists.insert(&s[i..i + k]);
        }
        exists.len() == total
    }
}
```

**复杂度分析**

- 时间复杂度：$O(k\times \vert s\vert)$，其中 $\vert s\vert$ 是字符串 $s$ 的长度。将长度为 $k$ 的字符串加入哈希集合的时间复杂度为 $O(k)$，即为计算哈希值的时间。
- 空间复杂度：$O(k\times 2^k)$。哈希集合中最多有 $2^k$ 项，每一项是一个长度为 $k$ 的字符串。

#### 方法二：哈希表 $+$ 滑动窗口

我们可以借助滑动窗口，对方法一进行优化。

假设我们当前遍历到的长度为 $k$ 的子串为

$$s_i,s_{i+1},\dots,s_{i+k-1}$$

它的下一个子串为

$$s_{i+1},s_{i+2},\dots,s_{i+k}$$

由于这些子串都是二进制串，我们可以将其表示成对应的十进制整数的形式，即

$$\begin{array}{lll}
    num_i & = & s_i\times 2^{k-1}+s_{i+1}\times 2^{k-2}+\dots +s_{i+k-1}\times 2^0 \\
    num_{i+1} & = & s_{i+1}\times 2^{k-1}+s_{i+2}\times 2^{k-2}+\dots +s_{i+k}\times 2^0
\end{array}$$

那么我们可以将这些十进制整数作为哈希表中的项。由于每一个长度为 $k$ 的二进制串都唯一对应了一个十进制整数，因此这样做与方法一是一致的。与二进制串本身不同的是，我们可以在 $O(1)$ 的时间内通过 $num_i$ 得到 $num_{i+1}$，即：

$$num_{i+1}=(num_i-s_i\times 2^{k-1})\times 2+s_{i+k}$$

这样以来，我们在遍历 $s$ 的过程中只维护子串对应的十进制整数，而不需要对字符串进行操作，从而减少了时间复杂度。

```C++
class Solution {
public:
    bool hasAllCodes(string s, int k) {
        if (s.size() < (1 << k) + k - 1) {
            return false;
        }

        int num = stoi(s.substr(0, k), nullptr, 2);
        unordered_set<int> exists = {num};

        for (int i = 1; i + k <= s.size(); ++i) {
            num = (num - ((s[i - 1] - '0') << (k - 1))) * 2 + (s[i + k - 1] - '0');
            exists.insert(num);
        }
        return exists.size() == (1 << k);
    }
};
```

```Python
class Solution:
    def hasAllCodes(self, s: str, k: int) -> bool:
        if len(s) < (1 << k) + k - 1:
            return False

        num = int(s[:k], base=2)
        exists = set([num])

        for i in range(1, len(s) - k + 1):
            num = (num - ((ord(s[i - 1]) - 48) << (k - 1))) * 2 + (ord(s[i + k - 1]) - 48)
            exists.add(num)

        return len(exists) == (1 << k)
```

```Java
class Solution {
    public boolean hasAllCodes(String s, int k) {
        if (s.length() < (1 << k) + k - 1) {
            return false;
        }

        int num = Integer.parseInt(s.substring(0, k), 2);
        Set<Integer> exists = new HashSet<Integer>();
        exists.add(num);

        for (int i = 1; i + k <= s.length(); ++i) {
            num = (num - ((s.charAt(i - 1) - '0') << (k - 1))) * 2 + (s.charAt(i + k - 1) - '0');
            exists.add(num);
        }
        return exists.size() == (1 << k);
    }
}
```

```CSharp
public class Solution {
    public bool HasAllCodes(string s, int k) {
        if (s.Length < (1 << k) + k - 1) {
            return false;
        }

        int num = Convert.ToInt32(s.Substring(0, k), 2);
        HashSet<int> exists = new HashSet<int> { num };

        for (int i = 1; i + k <= s.Length; ++i) {
            num = (num - ((s[i - 1] - '0') << (k - 1))) * 2 + (s[i + k - 1] - '0');
            exists.Add(num);
        }
        return exists.Count == (1 << k);
    }
}
```

```Go
func hasAllCodes(s string, k int) bool {
    if len(s) < (1 << k) + k - 1 {
        return false
    }

    num := 0
    for i := 0; i < k; i++ {
        num = num << 1
        if s[i] == '1' {
            num |= 1
        }
    }

    exists := make(map[int]bool)
    exists[num] = true
    for i := 1; i + k <= len(s); i++ {
        num = (num - (int(s[i-1]-'0') << (k-1))) * 2 + int(s[i+k-1]-'0')
        exists[num] = true
    }
    return len(exists) == (1 << k)
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

bool hasAllCodes(char* s, int k) {
    int len = strlen(s);
    int total = 1 << k;
    if (len < total + k - 1) {
        return false;
    }

    int num = 0;
    for (int i = 0; i < k; i++) {
        num = (num << 1) | (s[i] - '0');
    }

    HashItem *exists = NULL;
    hashAddItem(&exists, num);
    for (int i = k; i < len; i++) {
        int mask = (1 << k) - 1;
        num = ((num << 1) | (s[i] - '0')) & mask;
        hashAddItem(&exists, num);
    }

    bool ret = HASH_COUNT(exists) == total;
    hashFree(&exists);
    return ret;
}
```

```JavaScript
var hasAllCodes = function(s, k) {
    if (s.length < (1 << k) + k - 1) {
        return false;
    }

    let num = parseInt(s.substring(0, k), 2);
    const exists = new Set([num]);
    for (let i = 1; i + k <= s.length; ++i) {
        num = (num - (parseInt(s[i - 1]) << (k - 1))) * 2 + parseInt(s[i + k - 1]);
        exists.add(num);
    }
    return exists.size === (1 << k);
};
```

```TypeScript
function hasAllCodes(s: string, k: number): boolean {
    if (s.length < (1 << k) + k - 1) {
        return false;
    }

    let num = parseInt(s.substring(0, k), 2);
    const exists = new Set<number>([num]);
    for (let i = 1; i + k <= s.length; ++i) {
        num = (num - (parseInt(s[i - 1]) << (k - 1))) * 2 + parseInt(s[i + k - 1]);
        exists.add(num);
    }
    return exists.size === (1 << k);
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn has_all_codes(s: String, k: i32) -> bool {
        let k = k as usize;
        let total = 1 << k;

        if s.len() < total + k - 1 {
            return false;
        }

        let bytes = s.as_bytes();
        let mut num = 0;
        for i in 0..k {
            num = (num << 1) | (bytes[i] - b'0') as usize;
        }

        let mut exists = HashSet::new();
        exists.insert(num);
        for i in 1..=bytes.len() - k {
            let high_bit = ((bytes[i - 1] - b'0') as usize) << (k - 1);
            num = (num - high_bit) << 1 | (bytes[i + k - 1] - b'0') as usize;
            exists.insert(num);
        }

        exists.len() == total
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\vert s\vert)$，其中 $\vert s\vert$ 是字符串 $s$ 的长度。
- 空间复杂度：$O(2^k)$。哈希集合中最多有 $2^k$ 项，每一项是一个十进制整数。
