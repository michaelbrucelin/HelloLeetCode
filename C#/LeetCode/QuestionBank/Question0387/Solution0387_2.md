#### [方法一：使用哈希表存储频数](https://leetcode.cn/problems/first-unique-character-in-a-string/solutions/531740/zi-fu-chuan-zhong-de-di-yi-ge-wei-yi-zi-x9rok/)

**思路与算法**

我们可以对字符串进行两次遍历。

在第一次遍历时，我们使用哈希映射统计出字符串中每个字符出现的次数。在第二次遍历时，我们只要遍历到了一个只出现一次的字符，那么就返回它的索引，否则在遍历结束后返回 $-1$。

**代码**

```cpp
class Solution {
public:
    int firstUniqChar(string s) {
        unordered_map<int, int> frequency;
        for (char ch: s) {
            ++frequency[ch];
        }
        for (int i = 0; i < s.size(); ++i) {
            if (frequency[s[i]] == 1) {
                return i;
            }
        }
        return -1;
    }
};
```

```java
class Solution {
    public int firstUniqChar(String s) {
        Map<Character, Integer> frequency = new HashMap<Character, Integer>();
        for (int i = 0; i < s.length(); ++i) {
            char ch = s.charAt(i);
            frequency.put(ch, frequency.getOrDefault(ch, 0) + 1);
        }
        for (int i = 0; i < s.length(); ++i) {
            if (frequency.get(s.charAt(i)) == 1) {
                return i;
            }
        }
        return -1;
    }
}
```

```python
class Solution:
    def firstUniqChar(self, s: str) -> int:
        frequency = collections.Counter(s)
        for i, ch in enumerate(s):
            if frequency[ch] == 1:
                return i
        return -1
```

```javascript
var firstUniqChar = function(s) {
    const frequency = _.countBy(s);
    for (const [i, ch] of Array.from(s).entries()) {
        if (frequency[ch] === 1) {
            return i;
        }
    }
    return -1;
};
```

```go
func firstUniqChar(s string) int {
    cnt := [26]int{}
    for _, ch := range s {
        cnt[ch-'a']++
    }
    for i, ch := range s {
        if cnt[ch-'a'] == 1 {
            return i
        }
    }
    return -1
}
```

```c
struct hashTable {
    int key;
    int val;
    UT_hash_handle hh;
};

int firstUniqChar(char* s) {
    struct hashTable* frequency = NULL;
    int n = strlen(s);
    for (int i = 0; i < n; i++) {
        int ikey = s[i];
        struct hashTable* tmp;
        HASH_FIND_INT(frequency, &ikey, tmp);
        if (tmp == NULL) {
            tmp = malloc(sizeof(struct hashTable));
            tmp->key = ikey;
            tmp->val = 1;
            HASH_ADD_INT(frequency, key, tmp);
        } else {
            tmp->val++;
        }
    }
    for (int i = 0; i < n; i++) {
        int ikey = s[i];
        struct hashTable* tmp;
        HASH_FIND_INT(frequency, &ikey, tmp);
        if (tmp != NULL && tmp->val == 1) {
            return i;
        }
    }
    return -1;
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。我们需要进行两次遍历。
-   空间复杂度：$O(|\Sigma|)$，其中 $\Sigma$ 是字符集，在本题中 $s$ 只包含小写字母，因此 $|\Sigma| \leq 26$。我们需要 $O(|\Sigma|)$ 的空间存储哈希映射。
