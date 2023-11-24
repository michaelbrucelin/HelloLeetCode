### [HTML 实体解析器](https://leetcode.cn/problems/html-entity-parser/solutions/2477551/html-shi-ti-jie-xi-qi-by-leetcode-soluti-y851/)

#### 方法一：模拟

**思路与算法**

本题要求把字符串中所有的「字符实体」替换成对应的字符。

「字符实体」都是由 $\&$ 开头的，所以我们只需要遍历一遍字符串，用一个变量 $pos$ 表示当前处理的位置，如果 $text[pos] = '\&'$，就在这个位置进行探测。假设一个「字符实体」为 $e$，对应的字符为 $c$，那么可以通过判断 $pos$ 位置开始，长度和 $e$ 相同的子串是否和 $e$ 相等，如果相等就可以替换。

**代码**

```c++
class Solution {
public:
    using EntityChar = pair <string, char>;

    vector <EntityChar> entityList;

    string entityParser(string text) {
        entityList = vector({
            (EntityChar){"&quot;", '"'},
            (EntityChar){"&apos;", '\''},
            (EntityChar){"&amp;", '&'},
            (EntityChar){"&gt;", '>'},
            (EntityChar){"&lt;", '<'},
            (EntityChar){"&frasl;", '/'}
        });

        string r = "";
        for (int pos = 0; pos < text.size(); ) {
            bool isEntity = false;
            if (text[pos] == '&') {
                for (const auto &[e, c]: entityList) {
                    if (text.substr(pos, e.size()) == e) {
                        r.push_back(c);
                        pos += e.size();
                        isEntity = true;
                        break;
                    }
                }
            }
            if (!isEntity) {
                r.push_back(text[pos++]);
                continue;
            }
        }
        return r;
    }
};
```

```java
class Solution {
    class EntityChar {
        String entity;
        char character;

        public EntityChar(String entity, char character) {
            this.entity = entity;
            this.character = character;
        }
    }

    List<EntityChar> entityList = new ArrayList<EntityChar>();

    public String entityParser(String text) {
        entityList.add(new EntityChar("&quot;", '"'));
        entityList.add(new EntityChar("&apos;", '\''));
        entityList.add(new EntityChar("&amp;", '&'));
        entityList.add(new EntityChar("&gt;", '>'));
        entityList.add(new EntityChar("&lt;", '<'));
        entityList.add(new EntityChar("&frasl;", '/'));
        StringBuffer res = new StringBuffer();
        int length = text.length();
        int pos = 0;
        while (pos < length) {
            boolean isEntity = false;
            if (text.charAt(pos) == '&') {
                for (EntityChar entityChar : entityList) {
                    String e = entityChar.entity;
                    char c = entityChar.character;
                    if (pos + e.length() <= text.length() && text.substring(pos, pos + e.length()).equals(e)) {
                        res.append(c);
                        pos += e.length();
                        isEntity = true;
                        break;
                    }
                }
            }
            if (!isEntity) {
                res.append(text.charAt(pos++));
                continue;
            }
        }
        return res.toString();
    }
}
```

```csharp
public class Solution {
    class EntityChar {
        public string Entity { get; }
        public char Character { get; }

        public EntityChar(string entity, char character) {
            Entity = entity;
            Character = character;
        }
    }

    IList<EntityChar> entityList = new List<EntityChar>();

    public string EntityParser(string text) {
        entityList.Add(new EntityChar("&quot;", '"'));
        entityList.Add(new EntityChar("&apos;", '\''));
        entityList.Add(new EntityChar("&amp;", '&'));
        entityList.Add(new EntityChar("&gt;", '>'));
        entityList.Add(new EntityChar("&lt;", '<'));
        entityList.Add(new EntityChar("&frasl;", '/'));
        StringBuilder res = new StringBuilder();
        int length = text.Length;
        int pos = 0;
        while (pos < length) {
            bool isEntity = false;
            if (text[pos] == '&') {
                foreach (EntityChar entityChar in entityList) {
                    string e = entityChar.Entity;
                    char c = entityChar.Character;
                    if (pos + e.Length <= text.Length && text.Substring(pos, e.Length).Equals(e)) {
                        res.Append(c);
                        pos += e.Length;
                        isEntity = true;
                        break;
                    }
                }
            }
            if (!isEntity) {
                res.Append(text[pos++]);
                continue;
            }
        }
        return res.ToString();
    }
}
```

```python
class Solution:
    def entityParser(self, text: str) -> str:
        entityMap = {
            '&quot;': '"',
            '&apos;': "'",
            '&gt;': '>',
            '&lt;': '<',
            '&frasl;': '/',
            '&amp;': '&',
        }

        i = 0
        n = len(text)
        res = []
        while i < n:
            isEntity = False
            if text[i] == '&':
                for e in entityMap:
                    if text[i:i + len(e)] == e:
                        res.append(entityMap[e])
                        isEntity = True
                        i += len(e)
                        break
            if not isEntity:
                res.append(text[i])
                i += 1
        return ''.join(res)
```

```go
func entityParser(text string) string {
    entityMap := map[string]string{
        "&quot;": "\"",
        "&apos;": "'",
        "&gt;": ">",
        "&lt;": "<",
        "&frasl;": "/",
        "&amp;": "&",
    }

    i := 0
    n := len(text)
    res := make([]string, 0)
    for i < n {
        isEntity := false
        if text[i] == '&' {
            for k, v := range entityMap {
                if i + len(k) <= n && text[i : i + len(k)] == k {
                    res = append(res, v)
                    isEntity = true
                    i += len(k)
                    break
                }
            }
        }
        if !isEntity {
            res = append(res, text[i:i+1])
            i++
        }
    }
    return strings.Join(res, "")
}

```

```javascript
var entityParser = function(text) {
    const entityMap = {
        "&quot;": '"',
        "&apos;": "'",
        "&gt;": ">",
        "&lt;": "<",
        "&frasl;": "/",
        "&amp;": "&",
    };

    let i = 0;
    const n = text.length;
    const res = [];

    while (i < n) {
        let isEntity = false;
        if (text[i] === "&") {
            for (const [key, value] of Object.entries(entityMap)) {
                if (text.slice(i, i + key.length) === key) {
                    res.push(value);
                    isEntity = true;
                    i += key.length;
                    break;
                }
            }
        }
        if (!isEntity) {
            res.push(text[i]);
            i += 1;
        }
    }
    return res.join("");
};
```

```c
typedef struct EntityChar {
    char *entity;
    char character;
} EntityChar;

EntityChar entityList[] = {
    {"&quot;", '"'},
    {"&apos;", '\''},
    {"&amp;", '&'},
    {"&gt;", '>'},
    {"&lt;", '<'},
    {"&frasl;", '/'},
};

char *entityParser(char *text) {
    int i, n;
    char *res, *p;

    n = strlen(text);
    res = malloc(n * 2 + 1);
    p = res;

    for (i = 0; i < n;) {
        bool isEntity = false;
        if (text[i] == '&') {
            for (int j = 0; j < sizeof(entityList) / sizeof(entityList[0]); j++) {
                if (strncmp(text + i, entityList[j].entity, strlen(entityList[j].entity)) == 0) {
                    strcpy(p, &entityList[j].character);
                    p += strlen(&entityList[j].character);
                    i += strlen(entityList[j].entity);
                    isEntity = true;
                    break;
                }
            }
        }
        if (!isEntity) {
            *p++ = text[i++];
        }
    }
    *p = '\0';
    return res;
}
```

**复杂度分析**

记字符串的长度为 $n$。

-   时间复杂度：考虑最坏情况，每个位置都是 $\&$，那么每个位置都要进行 $6$ 次探测，探测的总时间代价和「实体字符」的总长度 $k$ 相关，这里 $k = 6 + 6 + 5 + 4 + 4 + 7 = 32$。那么总的时间代价为 $O(k \times n)$。
-   空间复杂度：这里用了 $entityList$ 作为辅助变量，字符总数为 $k + 6$，故渐进空间复杂度为 $O(k + 6) = O(k)$。
