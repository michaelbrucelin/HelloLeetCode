#### [����һ���ع��ַ���](https://leetcode.cn/problems/backspace-string-compare/solutions/451606/bi-jiao-han-tui-ge-de-zi-fu-chuan-by-leetcode-solu/)

**˼·���㷨**

�������뵽�ķ����ǽ��������ַ����е��˸����Ӧ����ɾ�����ַ���ȥ������ԭ�����ַ�����һ����ʽ��Ȼ��ֱ�ӱȽ����ַ����Ƿ���ȼ��ɡ�

����أ�������ջ����������̣�ÿ�����Ǳ�����һ���ַ���

-   ��������˸������ô���ǽ�ջ��������
-   ���������ͨ�ַ�����ô���ǽ���ѹ��ջ�С�

**����**

```cpp
class Solution {
public:
    bool backspaceCompare(string S, string T) {
        return build(S) == build(T);
    }

    string build(string str) {
        string ret;
        for (char ch : str) {
            if (ch != '#') {
                ret.push_back(ch);
            } else if (!ret.empty()) {
                ret.pop_back();
            }
        }
        return ret;
    }
};
```

```java
class Solution {
    public boolean backspaceCompare(String S, String T) {
        return build(S).equals(build(T));
    }

    public String build(String str) {
        StringBuffer ret = new StringBuffer();
        int length = str.length();
        for (int i = 0; i < length; ++i) {
            char ch = str.charAt(i);
            if (ch != '#') {
                ret.append(ch);
            } else {
                if (ret.length() > 0) {
                    ret.deleteCharAt(ret.length() - 1);
                }
            }
        }
        return ret.toString();
    }
}
```

```go
func build(str string) string {
    s := []byte{}
    for i := range str {
        if str[i] != '#' {
            s = append(s, str[i])
        } else if len(s) > 0 {
            s = s[:len(s)-1]
        }
    }
    return string(s)
}

func backspaceCompare(s, t string) bool {
    return build(s) == build(t)
}
```

```python
class Solution:
    def backspaceCompare(self, S: str, T: str) -> bool:
        def build(s: str) -> str:
            ret = list()
            for ch in s:
                if ch != "#":
                    ret.append(ch)
                elif ret:
                    ret.pop()
            return "".join(ret)
        
        return build(S) == build(T)
```

```c
char* build(char* str) {
    int n = strlen(str), len = 0;
    char* ret = malloc(sizeof(char) * (n + 1));
    for (int i = 0; i < n; i++) {
        if (str[i] != '#') {
            ret[len++] = str[i];
        } else if (len > 0) {
            len--;
        }
    }
    ret[len] = '\0';
    return ret;
}

bool backspaceCompare(char* S, char* T) {
    return strcmp(build(S), build(T)) == 0;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(N+M)$������ $N$ �� $M$ �ֱ�Ϊ�ַ��� $S$ �� $T$ �ĳ��ȡ�������Ҫ�������ַ�����һ�Ρ�
-   �ռ临�Ӷȣ�$O(N+M)$������ $N$ �� $M$ �ֱ�Ϊ�ַ��� $S$ �� $T$ �ĳ��ȡ���ҪΪ��ԭ�����ַ����Ŀ�����
