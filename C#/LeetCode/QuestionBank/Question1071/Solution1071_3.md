#### [方法二：枚举优化](https://leetcode.cn/problems/greatest-common-divisor-of-strings/solutions/143956/zi-fu-chuan-de-zui-da-gong-yin-zi-by-leetcode-solu/)

**思路**

注意到一个性质：**如果存在一个符合要求的字符串 `X`，那么也一定存在一个符合要求的字符串 `X'`，它的长度为 `str1` 和 `str2` 长度的最大公约数**。

简单来说，方法一中我们已经知道符合条件的长度出现在 $gcd(len_1,len_2)$ 的所有约数中，我们假设其中一个满足条件的约数为 $len_x$，该长度为 $len_x$ 的前缀串 $X$ 能经过若干次拼接后得到 `str1` 和 `str2`。拿 `str1` 举例，$X$ 经过 $\dfrac{len_1}{len_x}$ 次拼接后得到了 `str1`，而 $X$ 又能经过 $\dfrac{gcd(len_1,len_2)}{len_x}$ 次拼接后得到长度为 $gcd(len_1,len_2)$ 的前缀串 $X'$ ，所以我们可以每次取出 $\dfrac{gcd(len_1,len_2)}{len_x}$ 个 $X$ 来用 $X'$ 完成替换，最后 `str1` 会被替换成 $\dfrac{len_1}{gcd(len_1,len_2)}$ 个 $X'$ ，`str2` 同理可得。因此如果存在一个符合要求的字符串 $X$，那么也一定存在一个符合要求的字符串 $X'$，它的长度为 `str1` 和 `str2` 长度的最大公约数。我们只需要判断长度为 $gcd(len_1,len_2)$ 的前缀串是否满足要求即可。

**算法**

由上述性质我们可以先用辗转相除法求得两个字符串长度的最大公约数 $gcd(len_1,len_2)$，取出该长度的前缀串，判断一下它是否能经过若干次拼接得到 `str1` 和 `str2` 即可。

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
        string T = str1.substr(0, __gcd(len1,len2)); // __gcd() 为c++自带的求最大公约数的函数
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

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是两个字符串的长度范围，即 $len_1 + len_2$。判断最大公约数长度的前缀串是否符合条件需要 $O(n)$ 的时间复杂度，求两个字符串长度的最大公约数需要 $O(\log n)$ 的时间复杂度，所以总时间复杂度为 $O(n+\log n)=O(n)$ 。
-   空间复杂度：$O(n)$，比较的过程中需要创建一个长度创建长度为 $O(n)$ 的临时字符串变量，所以需要额外 $O(n)$ 的空间。
