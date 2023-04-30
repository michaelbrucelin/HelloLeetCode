#### [����һ��ģ��](https://leetcode.cn/problems/masking-personal-information/solutions/?orderBy=hot)

���������ж� $s$ �����仹�ǵ绰���롣��Ȼ����� $s$ �����ַ� $'@'$����ô�������䣬�������ǵ绰���롣

��� $s$ �����䣬���ǽ� $s$ �� $'@'$ ֮ǰ�Ĳ��ֱ�����һ�������һ���ַ����м��� $'*****'$ ���棬���������ַ���ת��ΪСд��

��� $s$ �ǵ绰���룬����ֻ���� $s$ �е��������֡�ʹ�����Ƚ���� $10$ λ���غ����� $'***-***-XXXX'$ ����ʽ�����ж� $s$ ���Ƿ��ж���Ĺ��ʺ��롣����У��򽫹��ʺ���֮ǰ��� $'+'$ �Ų��ӵ����غ������ǰ�ˡ�

-   ����� $10$ λ���֣������ǰ׺λ���ַ�����
-   ����� $11$ λ���֣������ǰ׺ $'+*-'$��
-   ����� $12$ λ���֣��򲻼���ǰ׺ $'+**-'$��
-   ����� $13$ λ���֣��򲻼���ǰ׺ $'+**'$��

```cpp
class Solution {
public:
    vector<string> country = {"", "+*-", "+**-", "+***-"};

    string maskPII(string s) {
        string res;
        int at = s.find("@");
        if (at != string::npos) {
            transform(s.begin(), s.end(), s.begin(), ::tolower);
            return s.substr(0, 1) + "*****" + s.substr(at - 1);
        }
        s = regex_replace(s, regex("[^0-9]"), "");
        return country[s.size() - 10] + "***-***-" + s.substr(s.size() - 4);
    }
};
```

```java
class Solution {
    String[] country = {"", "+*-", "+**-", "+***-"};

    public String maskPII(String s) {
        int at = s.indexOf("@");
        if (at > 0) {
            s = s.toLowerCase();
            return (s.charAt(0) + "*****" + s.substring(at - 1)).toLowerCase();
        }
        s = s.replaceAll("[^0-9]", "");
        return country[s.length() - 10] + "***-***-" + s.substring(s.length() - 4);
    }
}
```

```csharp
public class Solution {
    string[] country = {"", "+*-", "+**-", "+***-"};

    public string MaskPII(string s) {
        int at = s.IndexOf("@");
        if (at > 0) {
            s = s.ToLower();
            return (s[0] + "*****" + s.Substring(at - 1)).ToLower();
        }
        StringBuilder sb = new StringBuilder();
        foreach (char c in s) {
            if (char.IsDigit(c)) {
                sb.Append(c);
            }
        }
        s = sb.ToString();
        return country[s.Length - 10] + "***-***-" + s.Substring(s.Length - 4);
    }
}
```

```python
class Solution:
    def maskPII(self, s: str) -> str:
        at = s.find('@')
        if at >= 0:
            return (s[0] + "*" * 5 + s[at - 1:]).lower()
        s = "".join(i for i in s if i.isdigit())
        return ["", "+*-", "+**-", "+***-"][len(s) - 10] + "***-***-" + s[-4:]
```

```go
func maskPII(s string) string {
    at := strings.Index(s, "@")
    if at > 0 {
        s = strings.ToLower(s)
        return strings.ToLower(string(s[0])) + "*****" + s[at-1:]
    }
    var sb strings.Builder
    for i := 0; i < len(s); i++ {
        c := s[i]
        if unicode.IsDigit(rune(c)) {
            sb.WriteByte(c)
        }
    }
    s = sb.String()
    country := []string{"", "+*-", "+**-", "+***-"}
    return country[len(s)-10] + "***-***-" + s[len(s)-4:]
}
```

```javascript
const country = ["", "+*-", "+**-", "+***-"];

var maskPII = function(s) {
    const at = s.indexOf("@");
        if (at > 0) {
            s = s.toLowerCase();
            return (s[0] + "*****" + s.substring(at - 1)).toLowerCase();
        }
        let sb = "";
        for (let i = 0; i < s.length; i++) {
            const c = s.charAt(i);
            if ('0' <= c && c <= '9') {
                sb += c;
            }
        }
        s = sb.toString();
        return country[s.length - 10] + "***-***-" + s.substring(s.length - 4);
};
```

```c
#define MAX_STR_SIZE 16

const char* country[] = {"", "+*-", "+**-", "+***-"};

char * maskPII(char * s){
    char *at = strchr(s, '@');
    if (at != NULL) {
        for (int i = 0; s[i] != '\0'; i++) {
            s[i] = tolower(s[i]);
        }
        char *res = (char *)calloc(strlen(s) + 8, sizeof(char));
        sprintf(res, "%c%s%s",s[0], "*****", at - 1);
        return res;
    }
    char tmp[MAX_STR_SIZE];
    int pos = 0;
    for (int i = 0; s[i] != '\0'; i++) {
        if (isdigit(s[i])) {
            tmp[pos++] = s[i];
        }
    }
    tmp[pos] = '\0';
    char *res = (char *)calloc(20, sizeof(char));
    sprintf(res, "%s%s%s", country[pos - 10], "***-***-", tmp + pos - 4);
    return res;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ���ַ����ĳ��ȡ�
-   �ռ临�Ӷȣ�$O(n)$������ $n$ ���ַ����ĳ��ȡ�
