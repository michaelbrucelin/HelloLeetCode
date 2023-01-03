#### [����һ��ֱ�ӱ���](https://leetcode.cn/problems/check-if-numbers-are-ascending-in-a-sentence/solutions/2041564/jian-cha-ju-zi-zhong-de-shu-zi-shi-fou-d-uhaf/)

**˼·���㷨**

��ĿҪ����������ַ��� $s$ �� $token$ Ϊ����ʱ�Ƿ�������ϸ���������������֪���ڵ� $token$ ֮���ɿո�ָ���ǰ���Ҫ������ȡ���ַ����е�ÿ�� $token$�������ǰ�� $token$ ��������ɣ����� $token$ ת��Ϊʮ������ $cur$����ǰһ������ $token$ ת��������� $pre$�������������:
-   ��� $cur$ ���� $pre$������Ϊ��ǰ�� $token$ �������Ҫ�󣬸��� $pre$ Ϊ $cur$���������һ������ $token$ �Ƿ����������
-   ��� $cur$ С�ڻ��ߵ��� $pre$������Ϊ���������Ҫ�󣬷��� $false$��

������Ŀ�е�ÿ������ $token$ ת�����ʮ��������Ϊ��������С�� $100$��������ǿ��Գ�ʼ�� $pre$ ���� $0$���������μ��ÿ��Ϊ���ֵ� $token$ �Ƿ�������ĿҪ�󼴿ɡ�

**����**

```python
class Solution:
    def areNumbersAscending(self, s: str) -> bool:
        pre = i = 0
        while i < len(s):
            if s[i].isdigit():
                cur = 0
                while i < len(s) and s[i].isdigit():
                    cur = cur * 10 + int(s[i])
                    i += 1
                if cur <= pre:
                    return False
                pre = cur
            else:
                i += 1
        return True
```

```cpp
class Solution {
public:
    bool areNumbersAscending(string s) {
        int pre = 0, pos = 0;
        while (pos < s.size()) {
            if (isdigit(s[pos])) {
                int cur = 0;
                while (pos < s.size() && isdigit(s[pos])) {
                    cur = cur * 10 + s[pos] - '0';
                    pos++;
                }
                if (cur <= pre) {
                    return false;
                }
                pre = cur;
            } else {
                pos++;
            }
        }
        return true;
    }
};
```

```java
class Solution {
    public boolean areNumbersAscending(String s) {
        int pre = 0, pos = 0;
        while (pos < s.length()) {
            if (Character.isDigit(s.charAt(pos))) {
                int cur = 0;
                while (pos < s.length() && Character.isDigit(s.charAt(pos))) {
                    cur = cur * 10 + s.charAt(pos) - '0';
                    pos++;
                }
                if (cur <= pre) {
                    return false;
                }
                pre = cur;
            } else {
                pos++;
            }
        }
        return true;
    }
}
```

```csharp
public class Solution {
    public bool AreNumbersAscending(string s) {
        int pre = 0, pos = 0;
        while (pos < s.Length) {
            if (char.IsDigit(s[pos])) {
                int cur = 0;
                while (pos < s.Length && char.IsDigit(s[pos])) {
                    cur = cur * 10 + s[pos] - '0';
                    pos++;
                }
                if (cur <= pre) {
                    return false;
                }
                pre = cur;
            } else {
                pos++;
            }
        }
        return true;
    }
}
```

```c
bool areNumbersAscending(char * s) {
    int pre = 0, pos = 0;
    while (s[pos] != '\0') {
        if (isdigit(s[pos])) {
            int cur = 0;
            while (s[pos] != '\0' && isdigit(s[pos])) {
                cur = cur * 10 + s[pos] - '0';
                pos++;
            }
            if (cur <= pre) {
                return false;
            }
            pre = cur;
        } else {
            pos++;
        }
    }
    return true;
}
```

```javascript
var areNumbersAscending = function(s) {
    let pre = 0, pos = 0;
    while (pos < s.length) {
        if (isDigit(s[pos])) {
            let cur = 0;
            while (pos < s.length && isDigit(s[pos])) {
                cur = cur * 10 + s[pos].charCodeAt() - '0'.charCodeAt();
                pos++;
            }
            if (cur <= pre) {
                return false;
            }
            pre = cur;
        } else {
            pos++;
        }
    }
    return true;
};

const isDigit = (ch) => {
    return parseFloat(ch).toString() === "NaN" ? false : true;
}
```

```go
func areNumbersAscending(s string) bool {
    pre, i := 0, 0
    for i < len(s) {
        if unicode.IsDigit(rune(s[i])) {
            cur := 0
            for i < len(s) && unicode.IsDigit(rune(s[i])) {
                cur = cur*10 + int(s[i]-'0')
                i++
            }
            if cur <= pre {
                return false
            }
            pre = cur
        } else {
            i++
        }
    }
    return true
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ��ʾ�ַ����ĳ��ȡ�����ֻ�����һ���ַ������ɡ�
-   �ռ临�Ӷȣ�$O(1)$�����õ����ɶ��������
