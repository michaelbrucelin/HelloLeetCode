#### [����һ����ϣ��](https://leetcode.cn/problems/isomorphic-strings/solutions/536521/tong-gou-zi-fu-chuan-by-leetcode-solutio-s6fd/)

�����ǡ�[290\. ���ʹ���](https://leetcode-cn.com/problems/word-pattern/)���ļ򻯰棬��Ҫ�����ж� $s$ �� $t$ ÿ��λ���ϵ��ַ��Ƿ�һһ��Ӧ���� $s$ ������һ���ַ��� $t$ ��Ψһ���ַ���Ӧ��ͬʱ $t$ ������һ���ַ��� $s$ ��Ψһ���ַ���Ӧ����Ҳ����Ϊ��˫�䡹�Ĺ�ϵ��

��ʾ�� $2$ Ϊ����$t$ �е��ַ� $a$ �� $r$ ��Ȼ��Ψһ��ӳ�� $o$�������� $s$ �е��ַ� $o$ ��˵���������ӳ�� $\{a,r\}$���ʲ�����������

��ˣ�����ά�����Ź�ϣ����һ�Ź�ϣ�� $s2t$ �� $s$ ���ַ�Ϊ����ӳ���� $t$ ���ַ�Ϊֵ���ڶ��Ź�ϣ�� $t2s$ �� $t$ ���ַ�Ϊ����ӳ���� $s$ ���ַ�Ϊֵ���������ұ��������ַ������ַ������ϸ������Ź�ϣ��������ֳ�ͻ������ǰ�±� $index$ ��Ӧ���ַ� $s[index]$ �Ѿ�����ӳ���Ҳ�Ϊ $t[index]$ ��ǰ�±� $index$ ��Ӧ���ַ� $t[index]$ �Ѿ�����ӳ���Ҳ�Ϊ $s[index]$��ʱ˵�������ַ����޷�����ͬ�������� $\rm false$��

�����������û�г��ֳ�ͻ������������ַ�����ͬ���ģ����� $\rm true$ ���ɡ�

```cpp
class Solution {
public:
    bool isIsomorphic(string s, string t) {
        unordered_map<char, char> s2t;
        unordered_map<char, char> t2s;
        int len = s.length();
        for (int i = 0; i < len; ++i) {
            char x = s[i], y = t[i];
            if ((s2t.count(x) && s2t[x] != y) || (t2s.count(y) && t2s[y] != x)) {
                return false;
            }
            s2t[x] = y;
            t2s[y] = x;
        }
        return true;
    }
};
```

```java
class Solution {
    public boolean isIsomorphic(String s, String t) {
        Map<Character, Character> s2t = new HashMap<Character, Character>();
        Map<Character, Character> t2s = new HashMap<Character, Character>();
        int len = s.length();
        for (int i = 0; i < len; ++i) {
            char x = s.charAt(i), y = t.charAt(i);
            if ((s2t.containsKey(x) && s2t.get(x) != y) || (t2s.containsKey(y) && t2s.get(y) != x)) {
                return false;
            }
            s2t.put(x, y);
            t2s.put(y, x);
        }
        return true;
    }
}
```

```javascript
var isIsomorphic = function(s, t) {
    const s2t = {};
    const t2s = {};
    const len = s.length;
    for (let i = 0; i < len; ++i) {
        const x = s[i], y = t[i];
        if ((s2t[x] && s2t[x] !== y) || (t2s[y] && t2s[y] !== x)) {
            return false;
        }
        s2t[x] = y;
        t2s[y] = x;
    }
    return true;
};
```

```go
func isIsomorphic(s, t string) bool {
    s2t := map[byte]byte{}
    t2s := map[byte]byte{}
    for i := range s {
        x, y := s[i], t[i]
        if s2t[x] > 0 && s2t[x] != y || t2s[y] > 0 && t2s[y] != x {
            return false
        }
        s2t[x] = y
        t2s[y] = x
    }
    return true
}
```

```c
struct HashTable {
    char key;
    char val;
    UT_hash_handle hh;
};

bool isIsomorphic(char* s, char* t) {
    struct HashTable* s2t = NULL;
    struct HashTable* t2s = NULL;
    int len = strlen(s);
    for (int i = 0; i < len; ++i) {
        char x = s[i], y = t[i];
        struct HashTable *tmp1, *tmp2;
        HASH_FIND(hh, s2t, &x, sizeof(char), tmp1);
        HASH_FIND(hh, t2s, &y, sizeof(char), tmp2);
        if (tmp1 != NULL) {
            if (tmp1->val != y) {
                return false;
            }
        } else {
            tmp1 = malloc(sizeof(struct HashTable));
            tmp1->key = x;
            tmp1->val = y;
            HASH_ADD(hh, s2t, key, sizeof(char), tmp1);
        }
        if (tmp2 != NULL) {
            if (tmp2->val != x) {
                return false;
            }
        } else {
            tmp2 = malloc(sizeof(struct HashTable));
            tmp2->key = y;
            tmp2->val = x;
            HASH_ADD(hh, t2s, key, sizeof(char), tmp2);
        }
    }
    return true;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ Ϊ�ַ����ĳ��ȡ�����ֻ��ͬʱ����һ���ַ��� $s$ �� $t$ ���ɡ�
-   �ռ临�Ӷȣ�$O(|\Sigma|)$������ $\Sigma$ ���ַ������ַ�������ϣ��洢�ַ��Ŀռ�ȡ�����ַ������ַ�����С��������ÿ���ַ�������ͬ����Ҫ $O(|\Sigma|)$ �Ŀռ䡣
