#### [����һ����ϣ��](https://leetcode.cn/problems/evaluate-the-bracket-pairs-of-a-string/solutions/2055952/ti-huan-zi-fu-chuan-zhong-de-gua-hao-nei-y8d3/)

Ϊ�˷�����ң����ǽ� $knowledge$ ���浽��ϣ�� $dict$ �С��ַ��� $s$ �����������͵��ַ���

-   �ַ� $��(��$
-   �ַ� $��)��$
-   ���������ڵ�Сд��ĸ
-   �������ڵ�Сд��ĸ

����ʹ�� $key$ ���������ڵļ���$addKey$ ��ʾ��ǰСд��ĸ�Ƿ�Ϊ�������ڵ�Сд��ĸ�������ַ��� $s$�����赱ǰ�ַ�Ϊ $c$��

-   ��� $c$ ���� $��(��$
    ˵��֮���Сд��ĸ���������ڵģ��� $addKey=true$��
-   ��� $c$ ���� $��)��$
    ˵�� $key$ �Ѿ���������� $key$ �� $dict$ �У����ǽ� $dict[key]$ ���ӵ�����ַ����У������ַ� $��?��$ ���ӵ�����ַ����С�����ַ��� $key$���� $addKey=false$��
-   ��� $c$ ��Сд��ĸ
    ���� $addKey$ �����ַ� $c$ Ӧ����ӵ������� $addKey$ Ϊ�棬��ô���ַ� $c$ ׷�ӵ� $key$ �У������ַ� $c$ ׷�ӵ�����ַ����С�

```python
class Solution:
    def evaluate(self, s: str, knowledge: List[List[str]]) -> str:
        d = dict(knowledge)
        ans, start = [], -1
        for i, c in enumerate(s):
            if c == '(':
                start = i
            elif c == ')':
                ans.append(d.get(s[start + 1: i], '?'))
                start = -1
            elif start < 0:
                ans.append(c)
        return "".join(ans)
```

```cpp
class Solution {
public:
    string evaluate(string s, vector<vector<string>>& knowledge) {
        unordered_map<string, string> dict;
        for (auto &kd : knowledge) {
            dict[kd[0]] = kd[1];
        }
        bool addKey = false;
        string key, res;
        for (char c : s) {
            if (c == '(') {
                addKey = true;
            } else if (c == ')') {
                if (dict.count(key) > 0) {
                    res += dict[key];
                } else {
                    res.push_back('?');
                }
                addKey = false;
                key.clear();
            } else {
                if (addKey) {
                    key.push_back(c);
                } else {
                    res.push_back(c);
                }
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public String evaluate(String s, List<List<String>> knowledge) {
        Map<String, String> dict = new HashMap<String, String>();
        for (List<String> kd : knowledge) {
            dict.put(kd.get(0), kd.get(1));
        }
        boolean addKey = false;
        StringBuilder key = new StringBuilder();
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            if (c == '(') {
                addKey = true;
            } else if (c == ')') {
                if (dict.containsKey(key.toString())) {
                    res.append(dict.get(key.toString()));
                } else {
                    res.append('?');
                }
                addKey = false;
                key.setLength(0);
            } else {
                if (addKey) {
                    key.append(c);
                } else {
                    res.append(c);
                }
            }
        }
        return res.toString();
    }
}
```

```csharp
public class Solution {
    public string Evaluate(string s, IList<IList<string>> knowledge) {
        IDictionary<string, string> dict = new Dictionary<string, string>();
        foreach (IList<string> kd in knowledge) {
            dict.Add(kd[0], kd[1]);
        }
        bool addKey = false;
        StringBuilder key = new StringBuilder();
        StringBuilder res = new StringBuilder();
        foreach (char c in s) {
            if (c == '(') {
                addKey = true;
            } else if (c == ')') {
                if (dict.ContainsKey(key.ToString())) {
                    res.Append(dict[key.ToString()]);
                } else {
                    res.Append('?');
                }
                addKey = false;
                key.Length = 0;
            } else {
                if (addKey) {
                    key.Append(c);
                } else {
                    res.Append(c);
                }
            }
        }
        return res.ToString();
    }
}
```

```c
typedef struct {
    char *key;
    char *val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, const char *key) {
    HashItem *pEntry = NULL;
    HASH_FIND_STR(*obj, key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, char *key, char *val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_STR(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);             
    }
}

char * evaluate(char * s, char *** knowledge, int knowledgeSize, int* knowledgeColSize) {
    HashItem *dict = NULL;
    for (int i = 0; i < knowledgeSize; i++) {
        hashAddItem(&dict, knowledge[i][0], knowledge[i][1]);
    }
    bool addKey = false;
    int len = strlen(s);
    char key[16], *res = (char *)malloc(sizeof(char) * (len + 1));
    int keySize = 0, resSize = 0;
    memset(key, 0, sizeof(key));
    memset(res, 0, sizeof(char) * (len + 1));
    for (int i = 0; s[i] != '\0'; i++) {
        char c = s[i];
        if (c == '(') {
            addKey = true;
        } else if (c == ')') {
            HashItem *pEntry = hashFindItem(&dict, key);
            if (pEntry) {
                resSize += sprintf(res + resSize, "%s", pEntry->val);
            } else {
                res[resSize++] = '?';
            }
            addKey = false;
            keySize = 0;
        } else {
            if (addKey) {
                key[keySize++] = c;
                key[keySize] = '\0';
            } else {
                res[resSize++] = c;
            }
        }
    }
    hashFree(&dict);
    return res;
}
```

```javascript
var evaluate = function(s, knowledge) {
    const dict = new Map();
    for (const kd of knowledge) {
        dict.set(kd[0], kd[1]);
    }
    let addKey = false;
    let key = '';
    let res = '';
    for (let i = 0; i < s.length; i++) {
        const c = s[i];
        if (c === '(') {
            addKey = true;
        } else if (c === ')') {
            if (dict.has(key)) {
                res += dict.get(key);
            } else {
                res += '?';
            }
            addKey = false;
            key = '';
        } else {
            if (addKey) {
                key += c;
            } else {
                res += c;
            }
        }
    }
    return res;
};
```

```go
func evaluate(s string, knowledge [][]string) string {
    dict := map[string]string{}
    for _, kd := range knowledge {
        dict[kd[0]] = kd[1]
    }
    ans := &strings.Builder{}
    start := -1
    for i, c := range s {
        if c == '(' {
            start = i
        } else if c == ')' {
            if t, ok := dict[s[start+1:i]]; ok {
                ans.WriteString(t)
            } else {
                ans.WriteByte('?')
            }
            start = -1
        } else if start < 0 {
            ans.WriteRune(c)
        }
    }
    return ans.String()
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n + k)$������ $n$ ���ַ��� $s$ �ĳ��ȣ�$k$ ���ַ������� $knowledge$ �������ַ����ĳ���֮�͡�
-   �ռ临�Ӷȣ�$O(n + k)$������ $n$ ���ַ��� $s$ �ĳ��ȣ�$k$ ���ַ������� $knowledge$ �������ַ����ĳ���֮�͡������ϣ�� $dict$ �� $key$ �ֱ���Ҫ $O(k)$ �� $O(n)$��
