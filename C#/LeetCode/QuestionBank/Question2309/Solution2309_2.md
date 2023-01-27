#### [����һ����ϣ��](https://leetcode.cn/problems/greatest-english-letter-in-upper-and-lower-case/solutions/2076006/jian-ju-da-xiao-xie-de-zui-hao-ying-wen-o5u2s/)

ʹ�ù�ϣ�� $ht$ �����ַ��� $s$ ���ֹ����ַ��������ַ��� $s$������ǰ�ַ� $c$ ���뵽��ϣ�� $ht$ �С�

�Ӵ�Сö��Ӣ����ĸ�����һ��Ӣ����ĸ�Ĵ�д��ʽ��Сд��ʽ�������ڹ�ϣ�� $ht$ �У���ôֱ�ӷ��ظ�Ӣ����ĸ��������е�Ӣ����ĸ��������Ҫ����ôֱ�ӷ��ؿ��ַ�����

```python
class Solution:
    def greatestLetter(self, s: str) -> str:
        s = set(s)
        for lower, upper in zip(reversed(ascii_lowercase), reversed(ascii_uppercase)):
            if lower in s and upper in s:
                return upper
        return ""
```

```cpp
class Solution {
public:
    string greatestLetter(string s) {
        unordered_set<char> ht(s.begin(), s.end());
        for (int i = 25; i >= 0; i--) {
            if (ht.count('a' + i) > 0 && ht.count('A' + i) > 0) {
                return string(1, 'A' + i);
            }
        }
        return "";
    }
};
```

```java
class Solution {
    public String greatestLetter(String s) {
        Set<Character> ht = new HashSet<Character>();
        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            ht.add(c);
        }
        for (int i = 25; i >= 0; i--) {
            if (ht.contains((char) ('a' + i)) && ht.contains((char) ('A' + i))) {
                return String.valueOf((char) ('A' + i));
            }
        }
        return "";
    }
}
```

```c#
public class Solution {
    public string GreatestLetter(string s) {
        ISet<char> ht = new HashSet<char>();
        foreach (char c in s) {
            ht.Add(c);
        }
        for (int i = 25; i >= 0; i--) {
            if (ht.Contains((char) ('a' + i)) && ht.Contains((char) ('A' + i))) {
                return ((char) ('A' + i)).ToString();
            }
        }
        return "";
    }
}
```

```c
char * greatestLetter(char * s) {
    int ht[52];
    memset(ht, 0, sizeof(ht));
    for (int i = 0; s[i] != '\0'; i++) {
        if (islower(s[i])) {
            ht[s[i] - 'a'] = 1;
        } else {
            ht[s[i] - 'A' + 26] = 1;
        }
    }
    for (int i = 25; i >= 0; i--) {
        if (ht[i] > 0 && ht[26 + i] > 0) {
            char *res = (char *)malloc(sizeof(char) * 2);
            res[0] = 'A' + i;
            res[1] = '\0';
            return res;
        }
    }
    return "";
}
```

```javascript
var greatestLetter = function(s) {
    const ht = new Set();
    for (let i = 0; i < s.length; i++) {
        const c = s[i];
        ht.add(c);
    }
    for (let i = 25; i >= 0; i--) {
        if (ht.has(String.fromCharCode('a'.charCodeAt() + i)) && ht.has(String.fromCharCode('A'.charCodeAt() + i))) {
            return String.fromCharCode('A'.charCodeAt() + i);
        }
    }
    return "";
};
```

```go
func greatestLetter(s string) string {
    set := map[rune]bool{}
    for _, c := range s {
        set[c] = true
    }
    for i := 'Z'; i >= 'A'; i-- {
        if set[i] && set[unicode.ToLower(i)] {
            return string(i)
        }
    }
    return ""
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n + |\Sigma|)$������ $n$ ���ַ��� $s$ �ĳ��ȣ�$\Sigma$ ���ַ����������� $|\Sigma| = 26$��
-   �ռ临�Ӷȣ�$O(|\Sigma|)$������ $\Sigma$ ���ַ����������� $|\Sigma| = 26$��
