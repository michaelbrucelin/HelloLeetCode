#### [预备知识](https://leetcode.cn/problems/greatest-common-divisor-of-strings/solutions/143956/zi-fu-chuan-de-zui-da-gong-yin-zi-by-leetcode-solu/)

-   约数，最大公约数
-   辗转相除法

#### [方法一：枚举](https://leetcode.cn/problems/greatest-common-divisor-of-strings/solutions/143956/zi-fu-chuan-de-zui-da-gong-yin-zi-by-leetcode-solu/)

**思路和算法**

首先答案肯定是字符串的某个前缀，然后简单直观的想法就是枚举所有的前缀来判断，我们设这个前缀串长度为 $len_x$，`str1` 的长度为 $len_1$，`str2` 的长度为 $len_2$，则我们知道前缀串的长度必然要是两个字符串长度的约数才能满足条件，否则无法经过若干次拼接后得到长度相等的字符串，公式化来说，即

$$len_1 \mod len_x == 0$$

$$len_2 \mod len_x == 0$$

所以我们可以枚举符合长度条件的前缀串，再去判断这个前缀串拼接若干次以后是否等于 `str1` 和 `str2` 即可。

由于题目要求最长的符合要求的字符串 `X`，所以可以按长度从大到小枚举前缀串，这样碰到第一个满足条件的前缀串返回即可。

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
        for (int i = min(len1, len2); i >= 1; --i){ // 从长度大的开始枚举
            if (len1 % i == 0 && len2 % i == 0){
                string X = str1.substr(0, i);
                if (check(X, str1) && check(X, str2)) return X;
            }
        }
        return "";
    }
};
```

```java
class Solution {
    public String gcdOfStrings(String str1, String str2) {
        int len1 = str1.length(), len2 = str2.length();
        for (int i = Math.min(len1, len2); i >= 1; --i) { // 从长度大的开始枚举
            if (len1 % i == 0 && len2 % i == 0) {
                String X = str1.substring(0, i);
                if (check(X, str1) && check(X, str2)) {
                    return X;
                }
            }
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
}
```

```python
class Solution:
    def gcdOfStrings(self, str1: str, str2: str) -> str:
        for i in range(min(len(str1), len(str2)), 0, -1):
            if (len(str1) % i) == 0 and (len(str2) % i) == 0:
                if str1[: i] * (len(str1) // i) == str1 and str1[: i] * (len(str2) // i) == str2:
                    return str1[: i]
        return ''
```

**复杂度分析**

-   时间复杂度：$O((len_1+len_2)\sigma(gcd(len_1,len_2)))$，其中 $\sigma(n)$ 表示 $n$ 的约数个数，$gcd(a,b)$ 表示 $a$ 和 $b$ 的的最大公约数。我们需要线性的时间来两两比较拼接后的字符串和被比较的串是否相等，而之前提到符合条件的长度 $len_x$ 一定是 $len_1$ 和 $len_2$ 的公约数，所以符合条件的 $len_x$ 的个数即为 $len_1$ 和 $len_2$ 的公约数个数（即最大公约数的约数个数）$\sigma(gcd(len_1,len_2))$，最坏情况下所有符合条件的 $len_x$ 均要被判断一次，再算上之前提及的判断是否符合的时间复杂度，最后时间复杂度即为 $O((len_1+len_2)\sigma(gcd(len_1,len_2)))$。
-   空间复杂度：$O(len_1+len_2)$，每次枚举比较的过程中需要创建长度为 $len_1$ 和 $len_2$ 的临时字符串变量，所以需要额外 $O(len_1+len_2)$ 的空间。
