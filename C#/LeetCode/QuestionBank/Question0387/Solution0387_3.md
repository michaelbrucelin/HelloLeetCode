#### [��������ʹ�ù�ϣ��洢����](https://leetcode.cn/problems/first-unique-character-in-a-string/solutions/531740/zi-fu-chuan-zhong-de-di-yi-ge-wei-yi-zi-x9rok/)

**˼·���㷨**

���ǿ��ԶԷ���һ�����޸ģ�ʹ�õڶ��α����Ķ�����ַ�����Ϊ��ϣӳ�䡣

����أ����ڹ�ϣӳ���е�ÿһ����ֵ�ԣ�����ʾһ���ַ���ֵ��ʾ�����״γ��ֵ�������������ַ�ֻ����һ�Σ����� $-1$��������ַ����ֶ�Σ��������ǵ�һ�α����ַ���ʱ���赱ǰ���������ַ�Ϊ $c$����� $c$ ���ڹ�ϣӳ���У����Ǿͽ� $c$ ������������Ϊһ����ֵ�Լ����ϣӳ���У��������ǽ� $c$ �ڹ�ϣӳ���ж�Ӧ��ֵ�޸�Ϊ $-1$��

�ڵ�һ�α�������������ֻ��Ҫ�ٱ���һ�ι�ϣӳ���е�����ֵ���ҳ����в�Ϊ $-1$ ����Сֵ����Ϊ��һ�����ظ��ַ��������������ϣӳ���е�����ֵ��Ϊ $-1$�����Ǿͷ��� $-1$��

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ���ַ��� $s$ �ĳ��ȡ���һ�α����ַ�����ʱ�临�Ӷ�Ϊ $O(n)$���ڶ��α�����ϣӳ���ʱ�临�Ӷ�Ϊ $O(|\Sigma|)$������ $s$ �������ַ�������һ��С�� $s$ �ĳ��ȣ���� $O(|\Sigma|)$ �ڽ���������С�� $O(n)$�����Ժ��ԡ�
-   �ռ临�Ӷȣ�$O(|\Sigma|)$������ $\Sigma$ ���ַ������ڱ����� $s$ ֻ����Сд��ĸ����� $|\Sigma| \leq 26$��������Ҫ $O(|\Sigma|)$ �Ŀռ�洢��ϣӳ�䡣
