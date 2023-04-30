#### [��������ö���Ż�](https://leetcode.cn/problems/greatest-common-divisor-of-strings/solutions/143956/zi-fu-chuan-de-zui-da-gong-yin-zi-by-leetcode-solu/)

**˼·**

ע�⵽һ�����ʣ�**�������һ������Ҫ����ַ��� `X`����ôҲһ������һ������Ҫ����ַ��� `X'`�����ĳ���Ϊ `str1` �� `str2` ���ȵ����Լ��**��

����˵������һ�������Ѿ�֪�����������ĳ��ȳ����� $gcd(len_1,len_2)$ ������Լ���У����Ǽ�������һ������������Լ��Ϊ $len_x$���ó���Ϊ $len_x$ ��ǰ׺�� $X$ �ܾ������ɴ�ƴ�Ӻ�õ� `str1` �� `str2`���� `str1` ������$X$ ���� $\dfrac{len_1}{len_x}$ ��ƴ�Ӻ�õ��� `str1`���� $X$ ���ܾ��� $\dfrac{gcd(len_1,len_2)}{len_x}$ ��ƴ�Ӻ�õ�����Ϊ $gcd(len_1,len_2)$ ��ǰ׺�� $X'$ ���������ǿ���ÿ��ȡ�� $\dfrac{gcd(len_1,len_2)}{len_x}$ �� $X$ ���� $X'$ ����滻����� `str1` �ᱻ�滻�� $\dfrac{len_1}{gcd(len_1,len_2)}$ �� $X'$ ��`str2` ͬ��ɵá�����������һ������Ҫ����ַ��� $X$����ôҲһ������һ������Ҫ����ַ��� $X'$�����ĳ���Ϊ `str1` �� `str2` ���ȵ����Լ��������ֻ��Ҫ�жϳ���Ϊ $gcd(len_1,len_2)$ ��ǰ׺���Ƿ�����Ҫ�󼴿ɡ�

**�㷨**

�������������ǿ�������շת�������������ַ������ȵ����Լ�� $gcd(len_1,len_2)$��ȡ���ó��ȵ�ǰ׺�����ж�һ�����Ƿ��ܾ������ɴ�ƴ�ӵõ� `str1` �� `str2` ���ɡ�

```cpp
class Solution {
    bool check(string t,string s){
        int lenx = (int)s.length() / (int)t.length();
        string ans = "";
        for (int i = 1; i <= lenx; ++i){
            ans = ans + t;
        }
        return ans == s;
    }
public:
    string gcdOfStrings(string str1, string str2) {
        int len1 = (int)str1.length(), len2 = (int)str2.length();
        string T = str1.substr(0, __gcd(len1,len2)); // __gcd() Ϊc++�Դ��������Լ���ĺ���
        if (check(T, str1) && check(T, str2)) return T;
        return "";
    }
};
```

```java
class Solution {
    public String gcdOfStrings(String str1, String str2) {
        int len1 = str1.length(), len2 = str2.length();
        String T = str1.substring(0, gcd(len1, len2));
        if (check(T, str1) && check(T, str2)) {
            return T;
        }
        return "";
    }

    public boolean check(String t, String s) {
        int lenx = s.length() / t.length();
        StringBuffer ans = new StringBuffer();
        for (int i = 1; i <= lenx; ++i) {
            ans.append(t);
        }
        return ans.toString().equals(s);
    }

    public int gcd(int a, int b) {
        int remainder = a % b;
        while (remainder != 0) {
            a = b;
            b = remainder;
            remainder = a % b;
        }
        return b;
    }
}
```

```python
class Solution:
    def gcdOfStrings(self, str1: str, str2: str) -> str:
        candidate_len = math.gcd(len(str1), len(str2))
        candidate = str1[: candidate_len]
        if candidate * (len(str1) // candidate_len) == str1 and candidate * (len(str2) // candidate_len) == str2:
            return candidate
        return ''
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ �������ַ����ĳ��ȷ�Χ���� $len_1 + len_2$���ж����Լ�����ȵ�ǰ׺���Ƿ����������Ҫ $O(n)$ ��ʱ�临�Ӷȣ��������ַ������ȵ����Լ����Ҫ $O(\log n)$ ��ʱ�临�Ӷȣ�������ʱ�临�Ӷ�Ϊ $O(n+\log n)=O(n)$ ��
-   �ռ临�Ӷȣ�$O(n)$���ȽϵĹ�������Ҫ����һ�����ȴ�������Ϊ $O(n)$ ����ʱ�ַ���������������Ҫ���� $O(n)$ �Ŀռ䡣
