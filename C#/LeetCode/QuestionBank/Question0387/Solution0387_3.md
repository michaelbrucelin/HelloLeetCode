#### [方法二：使用哈希表存储索引](https://leetcode.cn/problems/first-unique-character-in-a-string/solutions/531740/zi-fu-chuan-zhong-de-di-yi-ge-wei-yi-zi-x9rok/)

**思路与算法**

我们可以对方法一进行修改，使得第二次遍历的对象从字符串变为哈希映射。

具体地，对于哈希映射中的每一个键值对，键表示一个字符，值表示它的首次出现的索引（如果该字符只出现一次）或者 $-1$（如果该字符出现多次）。当我们第一次遍历字符串时，设当前遍历到的字符为 $c$，如果 $c$ 不在哈希映射中，我们就将 $c$ 与它的索引作为一个键值对加入哈希映射中，否则我们将 $c$ 在哈希映射中对应的值修改为 $-1$。

在第一次遍历结束后，我们只需要再遍历一次哈希映射中的所有值，找出其中不为 $-1$ 的最小值，即为第一个不重复字符的索引。如果哈希映射中的所有值均为 $-1$，我们就返回 $-1$。

**代码**

```cpp
class Solution {
public:
    int firstUniqChar(string s) {
        unordered_map<int, int> position;
        int n = s.size();
        for (int i = 0; i < n; ++i) {
            if (position.count(s[i])) {
                position[s[i]] = -1;
            }
            else {
                position[s[i]] = i;
            }
        }
        int first = n;
        for (auto [_, pos]: position) {
            if (pos != -1 && pos < first) {
                first = pos;
            }
        }
        if (first == n) {
            first = -1;
        }
        return first;
    }
};
```

```java
class Solution {
    public int firstUniqChar(String s) {
        Map<Character, Integer> position = new HashMap<Character, Integer>();
        int n = s.length();
        for (int i = 0; i < n; ++i) {
            char ch = s.charAt(i);
            if (position.containsKey(ch)) {
                position.put(ch, -1);
            } else {
                position.put(ch, i);
            }
        }
        int first = n;
        for (Map.Entry<Character, Integer> entry : position.entrySet()) {
            int pos = entry.getValue();
            if (pos != -1 && pos < first) {
                first = pos;
            }
        }
        if (first == n) {
            first = -1;
        }
        return first;
    }
}
```

```python
class Solution:
    def firstUniqChar(self, s: str) -> int:
        position = dict()
        n = len(s)
        for i, ch in enumerate(s):
            if ch in position:
                position[ch] = -1
            else:
                position[ch] = i
        first = n
        for pos in position.values():
            if pos != -1 and pos < first:
                first = pos
        if first == n:
            first = -1
        return first
```

```javascript
var firstUniqChar = function(s) {
    const position = new Map();
    const n = s.length;
    for (let [i, ch] of Array.from(s).entries()) {
        if (position.has(ch)) {
            position.set(ch, -1);
        } else {
            position.set(ch, i);
        }
    }
    let first = n;
    for (let pos of position.values()) {
        if (pos !== -1 && pos < first) {
            first = pos;
        }
    }
    if (first === n) {
        first = -1;
    }
    return first;
};
```

```go
func firstUniqChar(s string) int {
    n := len(s)
    pos := [26]int{}
    for i := range pos[:] {
        pos[i] = n
    }
    for i, ch := range s {
        ch -= 'a'
        if pos[ch] == n {
            pos[ch] = i
        } else {
            pos[ch] = n + 1
        }
    }
    ans := n
    for _, p := range pos[:] {
        if p < ans {
            ans = p
        }
    }
    if ans < n {
        return ans
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
    struct hashTable* position = NULL;
    int n = strlen(s);
    for (int i = 0; i < n; ++i) {
        int ikey = s[i];
        struct hashTable* tmp;
        HASH_FIND_INT(position, &ikey, tmp);
        if (tmp != NULL) {
            tmp->val = -1;
        } else {
            tmp = malloc(sizeof(struct hashTable));
            tmp->key = ikey;
            tmp->val = i;
            HASH_ADD_INT(position, key, tmp);
        }
    }

    int first = n;
    struct hashTable *iter, *tmp;
    HASH_ITER(hh, position, iter, tmp) {
        int pos = iter->val;
        if (pos != -1 && pos < first) {
            first = pos;
        }
    }
    if (first == n) {
        first = -1;
    }
    return first;
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。第一次遍历字符串的时间复杂度为 $O(n)$，第二次遍历哈希映射的时间复杂度为 $O(|\Sigma|)$，由于 $s$ 包含的字符种类数一定小于 $s$ 的长度，因此 $O(|\Sigma|)$ 在渐进意义下小于 $O(n)$，可以忽略。
-   空间复杂度：$O(|\Sigma|)$，其中 $\Sigma$ 是字符集，在本题中 $s$ 只包含小写字母，因此 $|\Sigma| \leq 26$。我们需要 $O(|\Sigma|)$ 的空间存储哈希映射。
