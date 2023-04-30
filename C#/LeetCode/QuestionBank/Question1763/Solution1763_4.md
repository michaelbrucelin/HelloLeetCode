#### [������������](https://leetcode.cn/problems/longest-nice-substring/solutions/1240201/zui-chang-de-mei-hao-zi-zi-fu-chuan-by-l-4l1t/)

**˼·**

����˼����Դ�ڡ�[395\. ������K���ظ��ַ�����Ӵ�](https://leetcode-cn.com/problems/longest-substring-with-at-least-k-repeating-characters/)������ϸ�Ľⷨ�������ơ���ĿҪ���ҵ�����������ַ���������ַ��������Ϸ��������ַ�������ʱ��������ַ�����Ϊ�ַ������������ַ����к��в����ַ� $ch$ ֻ���ִ�д����Сд��ʽ������ַ���������Щ�ַ� $ch$ ʱ�������ж����ַ����϶���Ϊ�����ַ�����һ���ַ���Ϊ�����ַ����ı�Ҫ�����ǲ�������Щ�Ƿ��ַ���������ǿ������÷��ε�˼�룬���ַ�������Щ�Ƿ����ַ����зֳ����ɶΣ�������Ҫ�����Ӵ�һ��������ĳ�����зֵĶ��ڣ������ܿ�Խһ�������Ρ�

-   �ݹ�ʱ��$maxPos$ ������¼������ַ�������ʼ������$maxLen$ ������¼������ַ����ĳ��ȡ�
-   ÿ�μ������ $[start, end]$ �е����ַ����Ƿ�Ϊ�����ַ����������ǰ���ַ���Ϊ�Ϸ��������ַ������򽫵�ǰ������ַ����ĳ����� $maxLen$ ���бȽϺ��滻�������������ζԵ�ǰ�ַ��������з֣�Ȼ��ݹ����зֺ���ַ�����

**����**

```java
class Solution {
    private int maxPos;
    private int maxLen;

    public String longestNiceSubstring(String s) {
        this.maxPos = 0;
        this.maxLen = 0;
        dfs(s, 0, s.length() - 1);
        return s.substring(maxPos, maxPos + maxLen);
    }

    public void dfs(String s, int start, int end) {
        if (start >= end) {
            return;
        }
        int lower = 0, upper = 0;
        for (int i = start; i <= end; ++i) {
            if (Character.isLowerCase(s.charAt(i))) {
                lower |= 1 << (s.charAt(i) - 'a');
            } else {
                upper |= 1 << (s.charAt(i) - 'A');
            }
        }
        if (lower == upper) {
            if (end - start + 1 > maxLen) {
                maxPos = start;
                maxLen = end - start + 1;
            }
            return;
        } 
        int valid = lower & upper;
        int pos = start;
        while (pos <= end) {
            start = pos;
            while (pos <= end && (valid & (1 << Character.toLowerCase(s.charAt(pos)) - 'a')) != 0) {
                ++pos;
            }
            dfs(s, start, pos - 1);
            ++pos;
        }
    }
}
```

```cpp
class Solution {
public:
    void dfs(const string & s, int start, int end, int & maxPos, int & maxLen) {
        if (start >= end) {
            return;
        }
        int lower = 0, upper = 0;
        for (int i = start; i <= end; ++i) {
            if (islower(s[i])) {
                lower |= 1 << (s[i] - 'a');
            } else {
                upper |= 1 << (s[i] - 'A');
            }
        }
        if (lower == upper) {
            if (end - start + 1 > maxLen) {
                maxPos = start;
                maxLen = end - start + 1;
            }
            return;
        } 
        int valid = lower & upper;
        int pos = start;
        while (pos <= end) {
            start = pos;
            while (pos <= end && valid & (1 << (tolower(s[pos]) - 'a'))) {
                ++pos;
            }
            dfs(s, start, pos - 1, maxPos, maxLen);
            ++pos;
        }
    }

    string longestNiceSubstring(string s) {
        int maxPos = 0, maxLen = 0;
        dfs(s, 0, s.size() - 1, maxPos, maxLen);
        return s.substr(maxPos, maxLen);
    }
};
```

```csharp
public class Solution {
    private int maxPos;
    private int maxLen;

    public string LongestNiceSubstring(string s) {
        this.maxPos = 0;
        this.maxLen = 0;
        DFS(s, 0, s.Length - 1);
        return s.Substring(maxPos, maxLen);
    }

    public void DFS(String s, int start, int end) {
        if (start >= end) {
            return;
        }
        int lower = 0, upper = 0;
        for (int i = start; i <= end; ++i) {
            if (char.IsLower(s[i])) {
                lower |= 1 << (s[i] - 'a');
            } else {
                upper |= 1 << (s[i] - 'A');
            }
        }
        if (lower == upper) {
            if (end - start + 1 > maxLen) {
                maxPos = start;
                maxLen = end - start + 1;
            }
            return;
        } 
        int valid = lower & upper;
        int pos = start;
        while (pos <= end) {
            start = pos;
            while (pos <= end && (valid & (1 << char.ToLower(s[pos]) - 'a')) != 0) {
                ++pos;
            }
            DFS(s, start, pos - 1);
            ++pos;
        }
    }
}
```

```python
class Solution:
    def longestNiceSubstring(self, s: str) -> str:
        maxPos, maxLen = 0, 0
        def dfs(start, end):
            nonlocal maxPos, maxLen
            if start >= end:
                return
            lower, upper = 0, 0
            for i in range(start, end + 1):
                if s[i].islower():
                    lower|= 1 << (ord(s[i]) - ord('a'))
                else:
                    upper|= 1 << (ord(s[i]) - ord('A'))
            if lower == upper:
                if end - start + 1 > maxLen:
                    maxPos, maxLen = start, end - start + 1
                return
            pos, valid = start, lower & upper
            while pos <= end:
                start = pos
                while pos <= end and valid & (1 << (ord(s[pos].lower()) - ord('a'))):
                    pos += 1
                dfs(start, pos - 1)
                pos += 1
        dfs(0, len(s) - 1)
        return s[maxPos : maxPos + maxLen]
```

```c
void dfs(const char * s, int start, int end, int * maxPos, int * maxLen) {
    if (start >= end) {
        return;
    }
    int lower = 0, upper = 0;
    for (int i = start; i <= end; ++i) {
        if (islower(s[i])) {
            lower |= 1 << (s[i] - 'a');
        } else {
            upper |= 1 << (s[i] - 'A');
        }
    }
    if (lower == upper) {
        if (end - start + 1 > *maxLen ) {
            *maxPos = start;
            *maxLen = end - start + 1;
        }
        return;
    } 
    int valid = lower & upper;
    int pos = start;
    while (pos <= end) {
        start = pos;
        while (pos <= end && valid & (1 << (tolower(s[pos]) - 'a'))) {
            ++pos;
        }
        dfs(s, start, pos - 1, maxPos, maxLen);
        ++pos;
    }
}

char * longestNiceSubstring(char * s){
    int maxPos = 0, maxLen = 0;
    dfs(s, 0, strlen(s) - 1, &maxPos, &maxLen);
    s[maxPos + maxLen] = '\0';
    return s + maxPos;
}
```

```go
func longestNiceSubstring(s string) (ans string) {
    if s == "" {
        return
    }
    lower, upper := 0, 0
    for _, ch := range s {
        if unicode.IsLower(ch) {
            lower |= 1 << (ch - 'a')
        } else {
            upper |= 1 << (ch - 'A')
        }
    }
    if lower == upper {
        return s
    }
    valid := lower & upper
    for i := 0; i < len(s); i++ {
        start := i
        for i < len(s) && valid>>(unicode.ToLower(rune(s[i]))-'a')&1 == 1 {
            i++
        }
        if t := longestNiceSubstring(s[start:i]); len(t) > len(ans) {
            ans = t
        }
    }
    return
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n \cdot |\Sigma|)$������ $n$ Ϊ�ַ����ĳ��ȣ�$|\Sigma|$ Ϊ�ַ����Ĵ�С���������ַ���������Ӣ�Ĵ�Сд��ĸ����� $|\Sigma| = 52$������ʹ���˵ݹ飬�����ַ������ֻ�� $\dfrac{|\Sigma|}{2}$ ����ͬ��Ӣ����ĸ��ÿ�εݹ鶼��ȥ��һ��Ӣ����ĸ�����д�Сд��ʽ����˵ݹ�������Ϊ $\dfrac{|\Sigma|}{2}$��
-   �ռ临�Ӷȣ�$O(|\Sigma|)$�����ڵݹ�������Ϊ $|\Sigma|$�������Ҫʹ�� $O(|\Sigma|)$ �ĵݹ�ջ�ռ䡣
