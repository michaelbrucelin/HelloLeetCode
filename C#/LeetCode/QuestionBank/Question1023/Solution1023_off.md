#### [����һ��˫ָ��](https://leetcode.cn/problems/camelcase-matching/solutions/2224532/tuo-feng-shi-pi-pei-by-leetcode-solution-pwq7/)

**˼·���㷨**

��������ַ����� $queries[i]$����� $pattern$ �� $queries[i]$ �������У�����ȥ�� $pattern$ ֮�� $queries[i]$ ��ʣ�ಿ�ֶ���Сд��ĸ���ɣ���ô $queries[i]$ ���� $pattern$ ƥ�䡣

������˵������ά��һ���±� $p$���������� $pattern$��Ȼ����� $queries[i]$ �е�ÿ���ַ� $c$��

1.  ��� $p < pattern.length$������ $pattern[p] = c$����ô�� $p$ �� $1$��
2.  ���򣬿��� $c$ �Ƿ���һ����д��ĸ������ǣ���ƥ��ʧ�ܣ�������ǣ����Сд��ĸ���Բ��� $pattern$ ���� $queries[i]$ ƥ�䣬��ˣ����ǿ��Լ���������һ���ַ���

$queries[i]$ ������������� $p < pattern.length$�����ʾ $pattern$ �л����ַ�δ��ƥ�䣬$queries[i]$ �� $pattern$ ƥ��ʧ�ܡ�������� $pattern$ ƥ����ϣ�ƥ��ɹ���

**����**

```cpp
class Solution {
public:
    vector<bool> camelMatch(vector<string>& queries, string pattern) {
        int n = queries.size();
        vector<bool> res(n, true);
        for (int i = 0; i < n; i++) {
            int p = 0;
            for (auto c : queries[i]) {
                if (p < pattern.size() && pattern[p] == c) {
                    p++;
                } else if (isupper(c)) {
                    res[i] = false;
                    break;
                }
            }
            if (p < pattern.size()) {
                res[i] = false;
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public List<Boolean> camelMatch(String[] queries, String pattern) {
        int n = queries.length;
        List<Boolean> res = new ArrayList<Boolean>();
        for (int i = 0; i < n; i++) {
            boolean flag = true;
            int p = 0;
            for (int j = 0; j < queries[i].length(); j++) {
                char c = queries[i].charAt(j);
                if (p < pattern.length() && pattern.charAt(p) == c) {
                    p++;
                } else if (Character.isUpperCase(c)) {
                    flag = false;
                    break;
                }
            }
            if (p < pattern.length()) {
                flag = false;
            }
            res.add(flag);
        }
        return res;
    }
}
```

```python
class Solution:
    def camelMatch(self, queries: List[str], pattern: str) -> List[bool]:
        n = len(queries)
        res = [True] * n
        for i in range(n):
            p = 0
            for c in queries[i]:
                if p < len(pattern) and pattern[p] == c:
                    p += 1
                elif c.isupper():
                    res[i] = False
                    break
            if p < len(pattern):
                res[i] = False
        return res
```

```go
func camelMatch(queries []string, pattern string) []bool {
    n := len(queries)
    res := make([]bool, n)
    for i := 0; i < n; i++ {
        res[i] = true
        p := 0
        for _, c := range queries[i] {
            if p < len(pattern) && pattern[p] == byte(c) {
                p++
            } else if unicode.IsUpper(c) {
                res[i] = false
                break
            }
        }
        if p < len(pattern) {
            res[i] = false
        }
    }
    return res
}
```

```javascript
var camelMatch = function(queries, pattern) {
    let n = queries.length
    let res = new Array(n)
    for (let i = 0; i < n; i++) {
        res[i] = true
        let p = 0
        for (let j = 0; j < queries[i].length; j++) {
            let c = queries[i][j]
            if (p < pattern.length && pattern[p] === c) {
                p++
            } else if (c.toUpperCase() === c) {
                res[i] = false
                break
            }
        }
        if (p < pattern.length) {
            res[i] = false
        }
    }
    return res
};
```

```csharp
public class Solution {
    public IList<bool> CamelMatch(string[] queries, string pattern) {
        int n = queries.Length;
        IList<bool> res = new List<bool>();
        for (int i = 0; i < n; i++) {
            bool flag = true;
            int p = 0;
            foreach (char c in queries[i]) {
                if (p < pattern.Length && pattern[p] == c) {
                    p++;
                } else if (char.IsUpper(c)) {
                    flag = false;
                    break;
                }
            }
            if (p < pattern.Length) {
                flag = false;
            }
            res.Add(flag);
        }
        return res;
    }
}
```

```c
bool* camelMatch(char ** queries, int queriesSize, char * pattern, int* returnSize) {
    int n = queriesSize;
    int m = strlen(pattern);
    bool *res = (bool *)calloc(n, sizeof(bool));
    for (int i = 0; i < n; i++) {
        res[i] = true;
        int p = 0;
        for (int j = 0; queries[i][j] != '\0'; j++) {
            if (p < m && pattern[p] == queries[i][j]) {
                p++;
            } else if (isupper(queries[i][j])) {
                res[i] = false;
                break;
            }
        }
        if (p < m) {
            res[i] = false;
        }
    }
    *returnSize = n;
    return res;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(nm)$������ $n$ �� $queries$ �ĳ��ȣ�$m$ �� $queries[i]$ �ĳ��ȡ�
-   �ռ临�Ӷȣ�$O(1)$�����Ǻ��Է���ֵ�Ŀռ临�Ӷȣ�������ֻʹ���˳�����������
