#### [��������λ����](https://leetcode.cn/problems/greatest-english-letter-in-upper-and-lower-case/solutions/2076006/jian-ju-da-xiao-xie-de-zui-hao-ying-wen-o5u2s/)

�ֱ�ʹ�� $32$ λ���� $lower$ �� $upper$ ��ʾ�ַ��� $s$ ��Сд��ĸ�ʹ�д��ĸ�ĳ�������������ַ��� $s$�����赱ǰ���������ַ�Ϊ $c$����� $c$ ΪСд��ĸ����ô�� $lower$ ��Ӧ��λ�� $1$����� $c$ Ϊ��д��ĸ����ô�� $upper$ ��Ӧ��λ�� $1$��

�Ӵ�Сö��Ӣ����ĸ�����һ��Ӣ����ĸ�� $lower$ �� $upper$ �ж����֣���ôֱ�ӷ��ظ�Ӣ����ĸ��������е�Ӣ����ĸ��������Ҫ����ôֱ�ӷ��ؿ��ַ�����

```cpp
class Solution {
public:
    string greatestLetter(string s) {
        int lower = 0, upper = 0;
        for (auto c : s) {
            if (islower(c)) {
                lower |= 1 << (c - 'a');
            } else {
                upper |= 1 << (c - 'A');
            }
        }
        for (int i = 25; i >= 0; i--) {
            if (lower & upper & (1 << i)) {
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
        int lower = 0, upper = 0;
        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            if (Character.isLowerCase(c)) {
                lower |= 1 << (c - 'a');
            } else {
                upper |= 1 << (c - 'A');
            }
        }
        for (int i = 25; i >= 0; i--) {
            if ((lower & upper & (1 << i)) != 0) {
                return String.valueOf((char) ('A' + i));
            }
        }
        return "";
    }
}
```

```csharp
public class Solution {
    public string GreatestLetter(string s) {
        int lower = 0, upper = 0;
        foreach (char c in s) {
            if (char.IsLower(c)) {
                lower |= 1 << (c - 'a');
            } else {
                upper |= 1 << (c - 'A');
            }
        }
        for (int i = 25; i >= 0; i--) {
            if ((lower & upper & (1 << i)) != 0) {
                return ((char) ('A' + i)).ToString();
            }
        }
        return "";
    }
}
```

```c
char * greatestLetter(char * s) {
    int lower = 0, upper = 0;
    for (int i = 0; s[i] != '\0'; i++) {
        char c = s[i];
        if (islower(c)) {
            lower |= 1 << (c - 'a');
        } else {
            upper |= 1 << (c - 'A');
        }
    }
    for (int i = 25; i >= 0; i--) {
        if (lower & upper & (1 << i)) {
            char *res = (char *)malloc(sizeof(char) * 2);
            res[0] = 'A' + i;
            res[1] = 0;
            return res;
        }
    }
    return "";
}
```

```javascript
var greatestLetter = function(s) {
    let lower = 0, upper = 0;
    for (let i = 0; i < s.length; i++) {
        const c = s[i];
        if ('a' <= c && c <= 'z') {
            lower |= 1 << (c.charCodeAt() - 'a'.charCodeAt());
        } else {
            upper |= 1 << (c.charCodeAt() - 'A'.charCodeAt());
        }
    }
    for (let i = 25; i >= 0; i--) {
        if ((lower & upper & (1 << i)) !== 0) {
            return String.fromCharCode('A'.charCodeAt() + i);
        }
    }
    return "";
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n + |\Sigma|)$������ $n$ ���ַ��� $s$ �ĳ��ȣ�$\Sigma$ ���ַ����������� $|\Sigma| = 26$��
-   �ռ临�Ӷȣ�$O(1)$��
