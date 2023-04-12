#### [��ͼ�⡿̰��������һͼ�붮����Python/Java/C++/Go��](https://leetcode.cn/problems/longest-chunked-palindrome-decomposition/solutions/2221544/tu-jie-tan-xin-zuo-fa-yi-tu-miao-dong-py-huik/)

![]()

#### �ݹ�д��

```python
class Solution:
    def longestDecomposition(self, s: str) -> int:
        if s == "":
            return 0
        for i in range(1, len(s) // 2 + 1):  # ö��ǰ��׺����
            if s[:i] == s[-i:]:  # ���̷ָ�
                return 2 + self.longestDecomposition(s[i:-i])
        return 1  # �޷��ָ�
```

```java
class Solution {
    public int longestDecomposition(String s) {
        if (s.isEmpty())
            return 0;
        for (int i = 1, n = s.length(); i <= n / 2; ++i) // ö��ǰ��׺����
            if (s.substring(0, i).equals(s.substring(n - i))) // ���̷ָ�
                return 2 + longestDecomposition(s.substring(i, n - i));
        return 1; // �޷��ָ�
    }
}
```

```cpp
class Solution {
public:
    int longestDecomposition(string s) {
        if (s.empty())
            return 0;
        for (int i = 1, n = s.length(); i <= n / 2; ++i) // ö��ǰ��׺����
            if (s.substr(0, i) == s.substr(n - i)) // ���̷ָ�
                return 2 + longestDecomposition(s.substr(i, n - i * 2));
        return 1; // �޷��ָ�
    }
};
```

```go
func longestDecomposition(s string) int {
    if s == "" {
        return 0
    }
    for i, n := 1, len(s); i <= n/2; i++ { // ö��ǰ��׺����
        if s[:i] == s[n-i:] { // ���̷ָ�
            return 2 + longestDecomposition(s[i:n-i])
        }
    }
    return 1 // �޷��ָ�
}
```

#### ����д��

```python
class Solution:
    def longestDecomposition(self, s: str) -> int:
        ans = 0
        while s:
            i = 1
            while i <= len(s) // 2 and s[:i] != s[-i:]:  # ö��ǰ��׺
                i += 1
            if i > len(s) // 2:  # �޷��ָ�
                ans += 1
                break
            ans += 2  # �ָ�� s[:i] �� s[-i:]
            s = s[i:-i]
        return ans
```

```java
class Solution {
    public int longestDecomposition(String s) {
        int ans = 0;
        while (!s.isEmpty()) {
            int i = 1, n = s.length();
            while (i <= n / 2 && !s.substring(0, i).equals(s.substring(n - i))) // ö��ǰ��׺
                ++i;
            if (i > n / 2) { // �޷��ָ�
                ++ans;
                break;
            }
            ans += 2; // �ָ�� s[:i] �� s[n-i:]
            s = s.substring(i, n - i);
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int longestDecomposition(string s) {
        int ans = 0;
        while (!s.empty()) {
            int i = 1, n = s.length();
            while (i <= n / 2 && s.substr(0, i) != s.substr(n - i)) // ö��ǰ��׺
                ++i;
            if (i > n / 2) { // �޷��ָ�
                ++ans;
                break;
            }
            ans += 2; // �ָ�� s[:i] �� s[n-i:]
            s = s.substr(i, n - i * 2);
        }
        return ans;
    }
};
```

```go
func longestDecomposition(s string) (ans int) {
    for s != "" {
        i, n := 1, len(s)
        for i <= n/2 && s[:i] != s[n-i:] { // ö��ǰ��׺
            i++
        }
        if i > n/2 { // �޷��ָ�
            ans++
            break
        }
        ans += 2 // �ָ�� s[:i] �� s[n-i:]
        s = s[i : n-i]
    }
    return
}
```

#### ���Ӷȷ���

-   ʱ�临�Ӷȣ�$O(n^2)$������ $n$ Ϊ�ַ����ĳ��ȡ��������޷��ָ��Ҫִ�� $O(n)$ �γ�Ϊ $O(n)$ ���ַ����Ƚϣ�����ʱ�临�Ӷ�Ϊ $O(n^2)$��
-   �ռ临�Ӷȣ�$O(n)$ �� $O(1)$��Go ������Ƭ�����п��������Կռ临�Ӷ�Ϊ $O(1)$����Ȼ��Ҳ�����ֶ��Ƚ��ַ������������������Ӵ���
