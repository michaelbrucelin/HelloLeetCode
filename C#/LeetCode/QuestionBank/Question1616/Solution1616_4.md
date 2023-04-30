#### [û�����ף�һ��ͼ�붮����Python/Java/C++/Go��](https://leetcode.cn/problems/split-two-strings-to-make-palindrome/solutions/2175393/mei-xiang-ming-bai-yi-zhang-tu-miao-dong-imvy/)

![](./assets/img/Solution1616_4_01.png)

ע�⣬˫ָ��ǰ��׺ƥ�����������ָ��ָ���λ��ǡ�þ��ǽ�����Ҫ�жϵĻ��Ĵ������ұ߽磬��������������߼������޷�Խӡ�

```python
class Solution:
    def checkPalindromeFormation(self, a: str, b: str) -> bool:
        # ��� a_prefix + b_suffix ���Թ��ɻ��Ĵ��򷵻� True�����򷵻� False
        def check(a: str, b: str) -> bool:
            i, j = 0, len(a) - 1  # ����˫ָ��
            while i < j and a[i] == b[j]:  # ǰ��׺����ƥ��
                i += 1
                j -= 1
            s, t = a[i: j + 1], b[i: j + 1]  # �м�ʣ�ಿ��
            return s == s[::-1] or t == t[::-1]  # �ж��Ƿ�Ϊ���Ĵ�
        return check(a, b) or check(b, a)
```

```java
class Solution {
    public boolean checkPalindromeFormation(String a, String b) {
        return check(a, b) || check(b, a);
    }

    // ��� a_prefix + b_suffix ���Թ��ɻ��Ĵ��򷵻� true�����򷵻� false
    private boolean check(String a, String b) {
        int i = 0, j = a.length() - 1; // ����˫ָ��
        while (i < j && a.charAt(i) == b.charAt(j)) { // ǰ��׺����ƥ��
            ++i;
            --j;
        }
        return isPalindrome(a, i, j) || isPalindrome(b, i, j);
    }

    // ����� s[i] �� s[j] �ǻ��Ĵ��򷵻� true�����򷵻� false
    private boolean isPalindrome(String s, int i, int j) {
        while (i < j && s.charAt(i) == s.charAt(j)) {
            ++i;
            --j;
        }
        return i >= j;
    }
}
```

```cpp
class Solution {
    // ����� s[i] �� s[j] �ǻ��Ĵ��򷵻� true�����򷵻� false
    bool isPalindrome(string &s, int i, int j) {
        while (i < j && s[i] == s[j])
            ++i, --j;
        return i >= j;
    }

    // ��� a_prefix + b_suffix ���Թ��ɻ��Ĵ��򷵻� true�����򷵻� false
    bool check(string &a, string &b) {
        int i = 0, j = a.length() - 1; // ����˫ָ��
        while (i < j && a[i] == b[j]) // ǰ��׺����ƥ��
            ++i, --j;
        return isPalindrome(a, i, j) || isPalindrome(b, i, j);
    }

public:
    bool checkPalindromeFormation(string &a, string &b) {
        return check(a, b) || check(b, a);
    }
};
```

```go
// ����� s[i] �� s[j] �ǻ��Ĵ��򷵻� true�����򷵻� false
func isPalindrome(s string, i, j int) bool {
    for i < j && s[i] == s[j] {
        i++
        j--
    }
    return i >= j
}

// ��� a_prefix + b_suffix ���Թ��ɻ��Ĵ��򷵻� true�����򷵻� false
func check(a, b string) bool {
    i, j := 0, len(a)-1 // ����˫ָ��
    for i < j && a[i] == b[j] { // ǰ��׺����ƥ��
        i++
        j--
    }
    return isPalindrome(a, i, j) || isPalindrome(b, i, j)
}

func checkPalindromeFormation(a, b string) bool {
    return check(a, b) || check(b, a)
}
```

#### ���Ӷȷ���

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ Ϊ $a$ �ĳ��ȡ�
-   �ռ临�Ӷȣ�$O(1)$�����õ����ɶ��������

> ע��Python Ҳ�������������������ֶ��жϻ��ģ��Ӷ�������Ƭ�����Ķ���ռ䡣
