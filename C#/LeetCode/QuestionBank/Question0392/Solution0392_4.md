#### [����������̬�滮](https://leetcode.cn/problems/is-subsequence/solutions/346539/pan-duan-zi-xu-lie-by-leetcode-solution/)

**˼·���㷨**

����ǰ���˫ָ�������������ע�⵽�����д�����ʱ�������� $t$ ���ҵ���һ��ƥ���ַ���

�������ǿ���Ԥ��������� $t$ ��ÿһ��λ�ã��Ӹ�λ�ÿ�ʼ����ÿһ���ַ���һ�γ��ֵ�λ�á�

���ǿ���ʹ�ö�̬�滮�ķ���ʵ��Ԥ������ $f[i][j]$ ��ʾ�ַ��� $t$ �д�λ�� $i$ ��ʼ�����ַ� $j$ ��һ�γ��ֵ�λ�á��ڽ���״̬ת��ʱ����� $t$ ��λ�� $i$ ���ַ����� $j$����ô $f[i][j]=i$������ $j$ ������λ�� $i+1$ ��ʼ���󣬼� $f[i][j]=f[i+1][j]$���������Ҫ���������ж�̬�滮���Ӻ���ǰö�� $i$��

�������ǿ���д��״̬ת�Ʒ��̣�

$$f[i][j]=\begin{cases} i, & t[i]=j \\ f[i+1][j], & t[i] \neq j \end{cases}$$

�ٶ��±�� $0$ ��ʼ����ô $f[i][j]$ ���� $0 \leq i \leq m-1$ �����ڱ߽�״̬ $f[m-1][..]$�������� $f[m][..]$ Ϊ $m$���� $f[m-1][..]$ ��������ת�ơ�������� $f[i][j]=m$�����ʾ��λ�� $i$ ��ʼ���󲻴����ַ� $j$��

���������ǿ������� $f$ ���飬ÿ�� $O(1)$ ����ת����һ��λ�ã�ֱ��λ�ñ�Ϊ $m$ �� $s$ �е�ÿһ���ַ���ƥ��ɹ���

> ͬʱ����ע�⵽���ýⷨ�ж� $t$ �Ĵ����� $s$ �޹أ���Ԥ������ɺ󣬿�������Ԥ�����������Ϣ�����Ե��������һ���ַ��� $s$ �Ƿ�Ϊ $t$ ���Ӵ����������ǾͿ��Խ����������ս������

**����**

```cpp
class Solution {
public:
    bool isSubsequence(string s, string t) {
        int n = s.size(), m = t.size();

        vector<vector<int> > f(m + 1, vector<int>(26, 0));
        for (int i = 0; i < 26; i++) {
            f[m][i] = m;
        }

        for (int i = m - 1; i >= 0; i--) {
            for (int j = 0; j < 26; j++) {
                if (t[i] == j + 'a')
                    f[i][j] = i;
                else
                    f[i][j] = f[i + 1][j];
            }
        }
        int add = 0;
        for (int i = 0; i < n; i++) {
            if (f[add][s[i] - 'a'] == m) {
                return false;
            }
            add = f[add][s[i] - 'a'] + 1;
        }
        return true;
    }
};
```

```java
class Solution {
    public boolean isSubsequence(String s, String t) {
        int n = s.length(), m = t.length();

        int[][] f = new int[m + 1][26];
        for (int i = 0; i < 26; i++) {
            f[m][i] = m;
        }

        for (int i = m - 1; i >= 0; i--) {
            for (int j = 0; j < 26; j++) {
                if (t.charAt(i) == j + 'a')
                    f[i][j] = i;
                else
                    f[i][j] = f[i + 1][j];
            }
        }
        int add = 0;
        for (int i = 0; i < n; i++) {
            if (f[add][s.charAt(i) - 'a'] == m) {
                return false;
            }
            add = f[add][s.charAt(i) - 'a'] + 1;
        }
        return true;
    }
}
```

```python
class Solution:
    def isSubsequence(self, s: str, t: str) -> bool:
        n, m = len(s), len(t)
        f = [[0] * 26 for _ in range(m)]
        f.append([m] * 26)

        for i in range(m - 1, -1, -1):
            for j in range(26):
                f[i][j] = i if ord(t[i]) == j + ord('a') else f[i + 1][j]
        
        add = 0
        for i in range(n):
            if f[add][ord(s[i]) - ord('a')] == m:
                return False
            add = f[add][ord(s[i]) - ord('a')] + 1
        
        return True
```

```go
func isSubsequence(s string, t string) bool {
    n, m := len(s), len(t)
    f := make([][26]int, m + 1)
    for i := 0; i < 26; i++ {
        f[m][i] = m
    }
    for i := m - 1; i >= 0; i-- {
        for j := 0; j < 26; j++ {
            if t[i] == byte(j + 'a') {
                f[i][j] = i
            } else {
                f[i][j] = f[i + 1][j]
            }
        }
    }
    add := 0
    for i := 0; i < n; i++ {
        if f[add][int(s[i] - 'a')] == m {
            return false
        }
        add = f[add][int(s[i] - 'a')] + 1
    }
    return true
}
```

```c
bool isSubsequence(char* s, char* t) {
    int n = strlen(s), m = strlen(t);

    int f[m + 1][26];
    memset(f, 0, sizeof(f));
    for (int i = 0; i < 26; i++) {
        f[m][i] = m;
    }

    for (int i = m - 1; i >= 0; i--) {
        for (int j = 0; j < 26; j++) {
            if (t[i] == j + 'a')
                f[i][j] = i;
            else
                f[i][j] = f[i + 1][j];
        }
    }
    int add = 0;
    for (int i = 0; i < n; i++) {
        if (f[add][s[i] - 'a'] == m) {
            return false;
        }
        add = f[add][s[i] - 'a'] + 1;
    }
    return true;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(m \times |\Sigma| + n)$������ $n$ Ϊ $s$ �ĳ��ȣ�$m$ Ϊ $t$ �ĳ��ȣ�$\Sigma$ Ϊ�ַ������ڱ������ַ���ֻ����Сд��ĸ��$|\Sigma| = 26$��Ԥ����ʱ�临�Ӷ� $O(m)$���ж�������ʱ�临�Ӷ� $O(n)$��
    -   ����Ǽ��� $k$ ��ƽ������Ϊ $n$ ���ַ����Ƿ�Ϊ $t$ �������У���ʱ�临�Ӷ�Ϊ $O(m \times |\Sigma| +k \times n)$��
-   �ռ临�Ӷȣ�$O(m \times |\Sigma|)$��Ϊ��̬�滮����Ŀ�����
