#### [����һ���ҵ�ÿһ������ + ģ��](https://leetcode.cn/problems/goat-latin/solutions/1432725/shan-yang-la-ding-wen-by-leetcode-soluti-1l55/)

**˼·���㷨**

���ǿ��ԶԸ������ַ��� $sentence$ ����һ�α������ҳ����е�ÿһ�����ʣ���������Ŀ��Ҫ����в�����

��Ѱ�ҵ���ʱ�����ǿ���ʹ�������Դ��� $split()$ ���������ո���Ϊ�ָ��ַ����õ����еĵ��ʡ�Ϊ�˽�ʡ�ռ䣬����Ҳ����ֱ�ӽ��б�����ÿ�����Ǳ�����һ���ո���ߵ��� $sentence$ ��ĩβʱ�����Ǿ��ҵ���һ�����ʡ�

�����ǵõ�һ������ $w$ ������������Ҫ�ж� $w$ ������ĸ�Ƿ�ΪԪ����ĸ�����ǿ���ʹ��һ����ϣ���� $vowels$ �洢���е�Ԫ����ĸ $aeiouAEIOU$������ֻ��Ҫ�ж� $w$ ������ĸ�Ƿ��� $vowels$ �С������Ԫ����ĸ����ô���ʱ����ֲ��䣻����Ǹ�����ĸ����ô��Ҫ����ĸ�Ƶ�ĩβ������ʹ�������Դ����ַ�����Ƭ�������ɡ�����֮��������Ҫ��ĩβ��� $m$ �Լ����ɸ� $a$����˿���ʹ��һ������ $cnt$ ��¼��Ҫ��ӵ� $a$ �ĸ��������ĳ�ʼֵΪ $1$��ÿ�����ǵõ�һ�����ʣ��ͽ�����ֵ���� $1$��

**����**

```cpp
class Solution {
public:
    string toGoatLatin(string sentence) {
        unordered_set<char> vowels = {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};

        int n = sentence.size();
        int i = 0, cnt = 1;
        string ans;

        while (i < n) {
            int j = i;
            while (j < n && sentence[j] != ' ') {
                ++j;
            }

            ++cnt;
            if (cnt != 2) {
                ans += ' ';
            }
            if (vowels.count(sentence[i])) {
                ans += sentence.substr(i, j - i) + 'm' + string(cnt, 'a');
            }
            else {
                ans += sentence.substr(i + 1, j - i - 1) + sentence[i] + 'm' + string(cnt, 'a');
            }

            i = j + 1;
        }

        return ans;
    }
};
```

```java
class Solution {
    public String toGoatLatin(String sentence) {
        Set<Character> vowels = new HashSet<Character>() {{
            add('a');
            add('e');
            add('i');
            add('o');
            add('u');
            add('A');
            add('E');
            add('I');
            add('O');
            add('U');
        }};

        int n = sentence.length();
        int i = 0, cnt = 1;
        StringBuffer ans = new StringBuffer();

        while (i < n) {
            int j = i;
            while (j < n && sentence.charAt(j) != ' ') {
                ++j;
            }

            ++cnt;
            if (cnt != 2) {
                ans.append(' ');
            }
            if (vowels.contains(sentence.charAt(i))) {
                ans.append(sentence.substring(i, j));
            } else {
                ans.append(sentence.substring(i + 1, j));
                ans.append(sentence.charAt(i));
            }
            ans.append('m');
            for (int k = 0; k < cnt; ++k) {
                ans.append('a');
            }

            i = j + 1;
        }

        return ans.toString();
    }
}
```

```csharp
public class Solution {
    public string ToGoatLatin(string sentence) {
        ISet<char> vowels = new HashSet<char>();
        vowels.Add('a');
        vowels.Add('e');
        vowels.Add('i');
        vowels.Add('o');
        vowels.Add('u');
        vowels.Add('A');
        vowels.Add('E');
        vowels.Add('I');
        vowels.Add('O');
        vowels.Add('U');

        int n = sentence.Length;
        int i = 0, cnt = 1;
        StringBuilder ans = new StringBuilder();

        while (i < n) {
            int j = i;
            while (j < n && sentence[j] != ' ') {
                ++j;
            }

            ++cnt;
            if (cnt != 2) {
                ans.Append(' ');
            }
            if (vowels.Contains(sentence[i])) {
                ans.Append(sentence.Substring(i, j - i));
            } else {
                ans.Append(sentence.Substring(i + 1, j - i - 1));
                ans.Append(sentence[i]);
            }
            ans.Append('m');
            for (int k = 0; k < cnt; ++k) {
                ans.Append('a');
            }

            i = j + 1;
        }

        return ans.ToString();
    }
}
```

```python
class Solution:
    def toGoatLatin(self, sentence: str) -> str:
        vowels = {"a", "e", "i", "o", "u", "A", "E", "I", "O", "U"}

        n = len(sentence)
        i, cnt = 0, 1
        words = list()

        while i < n:
            j = i
            while j < n and sentence[j] != " ":
                j += 1
            
            cnt += 1
            if sentence[i] in vowels:
                words.append(sentence[i:j] + "m" + "a" * cnt)
            else:
                words.append(sentence[i+1:j] + sentence[i] + "m" + "a" * cnt)
            
            i = j + 1
        
        return " ".join(words)
```

```javascript
var toGoatLatin = function(sentence) {
    const vowels = new Set();
    vowels.add('a');
    vowels.add('e');
    vowels.add('i');
    vowels.add('o');
    vowels.add('u');
    vowels.add('A');
    vowels.add('E');
    vowels.add('I');
    vowels.add('O');
    vowels.add('U');

    const n = sentence.length;
    let i = 0, cnt = 1;
    ans = '';

    while (i < n) {
        let j = i;
        while (j < n && sentence[j] !== ' ') {
            ++j;
        }

        ++cnt;
        if (cnt !== 2) {
            ans += ' ';
        }
        if (vowels.has(sentence[i])) {
            ans += sentence.substring(i, j);
        } else {
            ans += sentence.slice(i + 1, j);
            ans += sentence[i];
        }
        ans += 'm';
        for (let k = 0; k < cnt; ++k) {
            ans += 'a';
        }

        i = j + 1;
    }

    return ans;
};
```

```c
#define MAX_LATIN_LEN 2048

char * toGoatLatin(char * sentence){
    int vowels[256];
    memset(vowels, 0, sizeof(vowels));
    vowels['a'] = 1;
    vowels['e'] = 1;
    vowels['i'] = 1;
    vowels['o'] = 1;
    vowels['u'] = 1;
    vowels['A'] = 1;
    vowels['E'] = 1;
    vowels['I'] = 1;
    vowels['O'] = 1;
    vowels['U'] = 1;

    int n = strlen(sentence);
    int i = 0, cnt = 1;
    char * ans = (char *)malloc(sizeof(char) * MAX_LATIN_LEN);
    int pos = 0;

    while (i < n) {
        int j = i;
        while (j < n && sentence[j] != ' ') {
            ++j;
        }

        ++cnt;
        if (cnt != 2) {
            ans[pos++] = ' ';
        }
        if (vowels[sentence[i]]) {
            memcpy(ans + pos, sentence + i, sizeof(char) * (j - i));
            pos += j - i;
            ans[pos++] = 'm';
            memset(ans + pos, 'a', cnt);
            pos += cnt;
        } else {
            memcpy(ans + pos, sentence + i + 1, sizeof(char) * (j - i - 1));
            pos += j - i - 1;
            ans[pos++] = sentence[i];
            ans[pos++] = 'm';
            memset(ans + pos, 'a', cnt);
            pos += cnt;
        }
        i = j + 1;
    }
    ans[pos] = 0;
    return ans;
}
```

```go
var vowels = map[byte]struct{}{'a': {}, 'e': {}, 'i': {}, 'o': {}, 'u': {}, 'A': {}, 'E': {}, 'I': {}, 'O': {}, 'U': {}}

func toGoatLatin(sentence string) string {
    ans := &strings.Builder{}
    for i, cnt, n := 0, 1, len(sentence); i < n; i++ {
        if cnt > 1 {
            ans.WriteByte(' ')
        }
        start := i
        for i++; i < n && sentence[i] != ' '; i++ {}
        cnt++
        if _, ok := vowels[sentence[start]]; ok {
            ans.WriteString(sentence[start:i])
        } else {
            ans.WriteString(sentence[start+1 : i])
            ans.WriteByte(sentence[start])
        }
        ans.WriteByte('m')
        ans.WriteString(strings.Repeat("a", cnt))
    }
    return ans.String()
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n^2)$������ $n$ ���ַ��� $sentence$ �ĳ��ȡ���Ȼ���Ƕ��ַ���ֻ�����˳����α��������Ƿ��ص��ַ������ȵ��������� $O(n^2)$ �ġ��������������ַ��� $sentence$ ���� $75$ ������ $a$����ʱ���ص��ַ����ĳ���Ϊ��
    $$75 + 75 + \sum_{i=2}^{76} i + 74$$
    ���Ĳ��ֱַ�Ϊ������ $a$ �ĳ��ȣ���ӵ� $m$ �ĳ��ȣ���ӵ� $a$ �ĳ��ȣ��ո�ĳ��ȡ�
-   �ռ临�Ӷȣ�$O(n^2)$ �� $O(n)$��ȡ����ʹ�õ����Ե��ַ����Ƿ���޸ġ���������޸ģ�����ֻ��Ҫ $O(n)$ �Ŀռ���ʱ�洢�ַ�����Ƭ������������޸ģ�������Ҫ $O(n^2)$ �Ŀռ���ʱ�洢���е����޸ĺ�Ľ����ע�����ﲻ���뷵���ַ���ʹ�õĿռ䡣
