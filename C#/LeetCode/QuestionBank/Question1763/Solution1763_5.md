#### [方法三：滑动窗口](https://leetcode.cn/problems/longest-nice-substring/solutions/1240201/zui-chang-de-mei-hao-zi-zi-fu-chuan-by-l-4l1t/)

**思路**

滑动窗口的解法同样参考「[395\. 至少有K个重复字符的最长子串](https://leetcode-cn.com/problems/longest-substring-with-at-least-k-repeating-characters/)」。 我们枚举最长子串中的字符种类数目，它最小为 $1$，最大为 $\dfrac{|\Sigma|}{2}$，其中同一个字符的大小写形式视为同一种字符。

对于给定的字符种类数量 $typeNum$，我们维护滑动窗口的左右边界 $l,r$、滑动窗口内部大小字符出现的次数 $upperCnt, lowerCnt$，以及滑动窗口内的字符种类数目 $total$。当 $total > typeNum$ 时，我们不断地右移左边界 $l$，并对应地更新 $upperCnt, lowerCnt$ 以及 $total$，直到 $total \le typeNum$ 为止。这样，对于任何一个右边界 $r$，我们都能找到最小的 $l$（记为 $l_{min}$，使得 $s[l_{min}...r]$ 之间的字符种类数目不多于 $typeNum$。

完美字符串定义为所有的字符同时出现大写和小写形式，最长的完美字符串一定出现在某个窗口中。对于任何一组 $l_{min}, r$ 而言，我们需要判断当前 $s[l_{min}...r]$ 是否为完美字符串，检测方法如下：

-   当前字符串中的字符种类数量为 $typeNum$，当前字符串中同时出现大小写的字符的种类数量为 $cnt$，只有满足 $cnt$ 等于 $typeNum$ 时，我们可以判定字符串为完美字符串。
-   遍历 $upperCnt, lowerCnt$ 两个数组，第 $i$ 个字符同时满足 $upperCnt[i] > 0, lowerCnt[i] > 0$ 时，则认为第 $i$ 个字符的大小写形式同时出现。

根据上面的结论，当限定字符种类数目为 $typeNum$ 时，满足题意的最长子串，就一定出自某个 $s[l_{min}...r]$。因此，在滑动窗口的维护过程中，就可以直接得到最长子串的大小。

最后，还剩下一个细节：如何在滑动窗口的同时高效地维护 $total$ 和 $cnt$。

-   右移右边界 $r$ 时，假设 $s[r]$ 对应的字符的索引为 $idx$，当满足 $upperCnt[r] + lowerCnt[r] = 1$ 时，则我们认为此时新增了一种字符，将 $total$ 加 $1$。
-   右移右边界 $r$ 时，假设 $s[r]$ 对应的字符的索引为 $idx$，如果 $s[r]$ 为小写字母，右移右边界后，当满足 $lowerCnt[idx] = 1$ 且 $upperCnt[idx] > 0$ 时，则我们认为此时新增了一种大小写同时存在的字符，将 $cnt$ 加 $1$；如果 $s[r]$ 为大写字母，右移右边界后，当满足 $upperCnt[idx] = 1$ 且 $lowerCnt[idx] > 0$ 时，则我们认为此时新增了一种大小写同时存在的字符，将 $cnt$ 加 $1$。
-   右移左边界 $l$ 时，假设 $s[l]$ 对应的字符的索引为 $idx$，当满足 $upperCnt[idx] + lowerCnt[idx] = 1$ 时，右移左边界后则我们认为此时将减少一种字符，将 $total$ 减 $1$。
-   右移左边界 $l$ 时，假设 $s[l]$ 对应的字符的索引为 $idx$，如果 $s[l]$ 为小写字母，右移左边界后，当满足 $lowerCnt[idx] = 0$ 且 $upperCnt[idx] > 0$ 时，则我们认为此时减少了一种大小写同时存在的字符，将 $cnt$ 减 $1$；如果 $s[l]$ 为大写字母，右移左边界后，当满足 $upperCnt[idx] = 0$ 且 $lowerCnt[idx] > 0$ 时，则我们认为此时减少了一种大小写同时存在的字符，将 $cnt$ 减 $1$。

**代码**

```java
class Solution {
    private int maxPos;
    private int maxLen;

    public String longestNiceSubstring(String s) {
        this.maxPos = 0;
        this.maxLen = 0;
        
        int types = 0;
        for (int i = 0; i < s.length(); ++i) {
            types |= 1 << (Character.toLowerCase(s.charAt(i)) - 'a');
        }
        types = Integer.bitCount(types);
        for (int i = 1; i <= types; ++i) {
            check(s, i);
        }
        return s.substring(maxPos, maxPos + maxLen);
    }

    public void check(String s, int typeNum) {
        int[] lowerCnt = new int[26];
        int[] upperCnt = new int[26]; 
        int cnt = 0;
        for (int l = 0, r = 0, total = 0; r < s.length(); ++r) {
            int idx = Character.toLowerCase(s.charAt(r)) - 'a';
            if (Character.isLowerCase(s.charAt(r))) {
                ++lowerCnt[idx];
                if (lowerCnt[idx] == 1 && upperCnt[idx] > 0) {
                    ++cnt;
                }
            } else {
                ++upperCnt[idx];
                if (upperCnt[idx] == 1 && lowerCnt[idx] > 0) {
                    ++cnt;
                }
            }
            total += (lowerCnt[idx] + upperCnt[idx]) == 1 ? 1 : 0;
            while (total > typeNum) {
                idx = Character.toLowerCase(s.charAt(l)) - 'a';
                total -= (lowerCnt[idx] + upperCnt[idx]) == 1 ? 1 : 0;
                if (Character.isLowerCase(s.charAt(l))) {
                    --lowerCnt[idx];
                    if (lowerCnt[idx] == 0 && upperCnt[idx] > 0) {
                        --cnt;
                    }
                } else {
                    --upperCnt[idx];
                    if (upperCnt[idx] == 0 && lowerCnt[idx] > 0) {
                        --cnt;
                    }
                }
                ++l;
            }
            if (cnt == typeNum && r - l + 1 > maxLen) {
                maxPos = l;
                maxLen = r - l + 1;
            }
        }
    }
}
```

```cpp
class Solution {
public:
    string longestNiceSubstring(string s) {
        int maxPos = 0, maxLen = 0;
        auto check = [&](int typeNum) {
            vector<int> lowerCnt(26);
            vector<int> upperCnt(26);
            int cnt = 0;
            for (int l = 0, r = 0, total = 0; r < s.size(); ++r) {
                int idx = tolower(s[r]) - 'a';
                if (islower(s[r])) {
                    ++lowerCnt[idx];
                    if (lowerCnt[idx] == 1 && upperCnt[idx] > 0) {
                        ++cnt;
                    }
                } else {
                    ++upperCnt[idx];
                    if (upperCnt[idx] == 1 && lowerCnt[idx] > 0) {
                        ++cnt;
                    }
                }
                total += (lowerCnt[idx] + upperCnt[idx]) == 1 ? 1 : 0;

                while (total > typeNum) {
                    idx = tolower(s[l]) - 'a';
                    total -= (lowerCnt[idx] + upperCnt[idx]) == 1 ? 1 : 0;
                    if (islower(s[l])) {
                        --lowerCnt[idx];
                        if (lowerCnt[idx] == 0 && upperCnt[idx] > 0) {
                            --cnt;
                        }
                    } else {
                        --upperCnt[idx];
                        if (upperCnt[idx] == 0 && lowerCnt[idx] > 0) {
                            --cnt;
                        }
                    }
                    ++l;
                }
                if (cnt == typeNum && r - l + 1 > maxLen) {
                    maxPos = l;
                    maxLen = r - l + 1;
                }
            }
        };

        int mask = 0;
        for (char & ch : s) {
            mask |= 1 << (tolower(ch) - 'a');
        }
        int types = __builtin_popcount(mask);
        for (int i = 1; i <= types; ++i) {
            check(i);
        }
        return s.substr(maxPos, maxLen);
    }
};
```

```csharp
public class Solution {
    private int maxPos;
    private int maxLen;

    public string LongestNiceSubstring(string s) {
        this.maxPos = 0;
        this.maxLen = 0;
        
        int types = 0;
        for (int i = 0; i < s.Length; ++i) {
            types |= 1 << (char.ToLower(s[i]) - 'a');
        }
        types = Count((uint) types);
        for (int i = 1; i <= types; ++i) {
            Check(s, i);
        }
        return s.Substring(maxPos, maxLen);
    }

    public void Check(string s, int typeNum) {
        int[] lowerCnt = new int[26];
        int[] upperCnt = new int[26];
        int cnt = 0;
        for (int l = 0, r = 0, total = 0; r < s.Length; ++r) {
            int idx = char.ToLower(s[r]) - 'a';
            if (char.IsLower(s[r])) {
                ++lowerCnt[idx];
                if (lowerCnt[idx] == 1 && upperCnt[idx] > 0) {
                    ++cnt;
                }
            } else {
                ++upperCnt[idx];
                if (upperCnt[idx] == 1 && lowerCnt[idx] > 0) {
                    ++cnt;
                }
            }
            total += (lowerCnt[idx] + upperCnt[idx]) == 1 ? 1 : 0;

            while (total > typeNum) {
                idx = char.ToLower(s[l]) - 'a';
                total -= (lowerCnt[idx] + upperCnt[idx]) == 1 ? 1 : 0;
                if (char.IsLower(s[l])) {
                    --lowerCnt[idx];
                    if (lowerCnt[idx] == 0 && upperCnt[idx] > 0) {
                        --cnt;
                    }
                } else {
                    --upperCnt[idx];
                    if (upperCnt[idx] == 0 && lowerCnt[idx] > 0) {
                        --cnt;
                    }
                }
                ++l;
            }
            if (cnt == typeNum && r - l + 1 > maxLen) {
                maxPos = l;
                maxLen = r - l + 1;
            }
        }
    }

    public static int Count(uint x) {
        x = x - ((x >> 1) & 0x55555555);
        x = (x & 0x33333333) + ((x >> 2) & 0x33333333);
        x = (x + (x >> 4)) & 0x0f0f0f0f;
        x = x + (x >> 8);
        x = x + (x >> 16);
        return (int) x & 0x3f;
    }
}
```

```python
class Solution:
    def longestNiceSubstring(self, s: str) -> str:
        def check(typeNum):
            nonlocal maxPos, maxLen
            lowerCnt = [0] * 26
            upperCnt = [0] * 26
            l, r, total, cnt = 0, 0, 0, 0
            while r < len(s):
                idx = ord(s[r].lower()) - ord('a')
                if s[r].islower():
                    lowerCnt[idx] += 1
                    if lowerCnt[idx] == 1 and upperCnt[idx] > 0:
                        cnt += 1
                else:
                    upperCnt[idx] += 1
                    if upperCnt[idx] == 1 and lowerCnt[idx] > 0:
                        cnt += 1
                if lowerCnt[idx] + upperCnt[idx] == 1:
                    total += 1

                while total > typeNum :
                    idx = ord(s[l].lower()) - ord('a')
                    if lowerCnt[idx] + upperCnt[idx] == 1:
                        total -= 1
                    if s[l].islower():
                        lowerCnt[idx] -= 1
                        if lowerCnt[idx] == 0 and upperCnt[idx] > 0:
                            cnt -= 1
                    else:
                        upperCnt[idx] -= 1
                        if upperCnt[idx] == 0 and lowerCnt[idx] > 0:
                            cnt -= 1
                    l += 1
                if cnt == typeNum and r - l + 1 > maxLen:
                    maxPos, maxLen = l, r - l + 1
                r += 1
        
        maxPos, maxLen = 0, 0
        types = len(set(s.lower()))
        for i in range(1, types + 1):
            check(i)
        return s[maxPos: maxPos + maxLen]
```

```c
void check(const char * s, int typeNum, int * maxPos, int * maxLen) {
    int lowerCnt[26], upperCnt[26];
    memset(lowerCnt, 0, sizeof(lowerCnt));
    memset(upperCnt, 0, sizeof(upperCnt));
    int n = strlen(s);
    int cnt = 0;
    for (int l = 0, r = 0, total = 0; r < n; ++r) {
        int idx = tolower(s[r]) - 'a';
        if (islower(s[r])) {
            ++lowerCnt[idx];
            if (lowerCnt[idx] == 1 && upperCnt[idx] > 0) {
                ++cnt;
            }
        } else {
            ++upperCnt[idx];
            if (upperCnt[idx] == 1 && lowerCnt[idx] > 0) {
                ++cnt;
            }
        }
        total += (lowerCnt[idx] + upperCnt[idx]) == 1 ? 1 : 0;
        
        while (total > typeNum) {
            int idx = tolower(s[l]) - 'a';
            total -= (lowerCnt[idx] + upperCnt[idx]) == 1 ? 1 : 0;
            if (islower(s[l])) {
                --lowerCnt[idx];
                if (lowerCnt[idx] == 0 && upperCnt[idx] > 0) {
                    --cnt;
                }
            } else {
                --upperCnt[idx];
                if (upperCnt[idx] == 0 && lowerCnt[idx] > 0) {
                    --cnt;
                }
            }
            ++l;
        }
        if (cnt == typeNum && r - l + 1 > *maxLen) {
            *maxPos = l;
            *maxLen = r - l + 1;
        }
    }
}

char * longestNiceSubstring(char * s){
    int maxPos = 0, maxLen = 0;
    int mask = 0;
    int n = strlen(s);
    for (int i = 0; i < n; ++i) {
        mask |= 1 << (tolower(s[i]) - 'a');
    }
    int types = __builtin_popcount(mask);
    for (int i = 1; i <= types; ++i) {
        check(s, i, &maxPos, &maxLen);
    }
    s[maxPos + maxLen] = '\0';
    return s + maxPos;
}
```

```javascript
var longestNiceSubstring = function(s) {
    this.maxPos = 0;
    this.maxLen = 0;
    
    let types = 0;
    for (let i = 0; i < s.length; ++i) {
        types |= 1 << (s[i].toLowerCase().charCodeAt() - 'a'.charCodeAt());
    }
    types = bitCount(types);
    for (let i = 1; i <= types; ++i) {
        check(s, i);
    }
    return s.slice(maxPos, maxPos + maxLen);
};

const check = (s, typeNum) => {
    const lowerCnt = new Array(26).fill(0);
    const upperCnt = new Array(26).fill(0);
    let cnt = 0;
    for (let l = 0, r = 0, total = 0; r < s.length; ++r) {
        let idx = s[r].toLowerCase().charCodeAt() - 'a'.charCodeAt();
        if ('a' <= s[r] && s[r] <= 'z') {
            ++lowerCnt[idx];
            if (lowerCnt[idx] === 1 && upperCnt[idx] > 0) {
                ++cnt;
            }
        } else {
            ++upperCnt[idx];
            if (upperCnt[idx] === 1 && lowerCnt[idx] > 0) {
                ++cnt;
            }
        }
        total += (lowerCnt[idx] + upperCnt[idx]) === 1 ? 1 : 0;
        while (total > typeNum) {
            idx = s[l].toLowerCase().charCodeAt() - 'a'.charCodeAt();
            total -= (lowerCnt[idx] + upperCnt[idx]) === 1 ? 1 : 0;
            if ('a' <= s[l] && s[l] <= 'z') {
                --lowerCnt[idx];
                if (lowerCnt[idx] === 0 && upperCnt[idx] > 0) {
                    --cnt;
                }
            } else {
                --upperCnt[idx];
                if (upperCnt[idx] === 0 && lowerCnt[idx] > 0) {
                    --cnt;
                }
            }
            ++l;
        }
        if (cnt === typeNum && r - l + 1 > maxLen) {
            maxPos = l;
            maxLen = r - l + 1;
        }
    }
}

var bitCount = function(n) {
    let ret = 0;
    while (n) {
        n &= n - 1;
        ret++;
    }
    return ret;
};
```

```go
func longestNiceSubstring(s string) (ans string) {
    mask := uint(0)
    for _, ch := range s {
        mask |= 1 << (unicode.ToLower(ch) - 'a')
    }
    maxTypeNum := bits.OnesCount(mask)

    for typeNum := 1; typeNum <= maxTypeNum; typeNum++ {
        var lowerCnt, upperCnt [26]int
        var total, cnt, l int
        for r, ch := range s {
            idx := unicode.ToLower(ch) - 'a'
            if unicode.IsLower(ch) {
                lowerCnt[idx]++
                if lowerCnt[idx] == 1 && upperCnt[idx] > 0 {
                    cnt++
                }
            } else {
                upperCnt[idx]++
                if upperCnt[idx] == 1 && lowerCnt[idx] > 0 {
                    cnt++
                }
            }
            if lowerCnt[idx]+upperCnt[idx] == 1 {
                total++
            }

            for total > typeNum {
                idx := unicode.ToLower(rune(s[l])) - 'a'
                if lowerCnt[idx]+upperCnt[idx] == 1 {
                    total--
                }
                if unicode.IsLower(rune(s[l])) {
                    lowerCnt[idx]--
                    if lowerCnt[idx] == 0 && upperCnt[idx] > 0 {
                        cnt--
                    }
                } else {
                    upperCnt[idx]--
                    if upperCnt[idx] == 0 && lowerCnt[idx] > 0 {
                        cnt--
                    }
                }
                l++
            }

            if cnt == typeNum && r-l+1 > len(ans) {
                ans = s[l : r+1]
            }
        }
    }
    return
}
```

**复杂度分析**

-   时间复杂度：$O(n \cdot |\Sigma|)$，其中 $n$ 为字符串的长度，$|\Sigma|$ 为字符集的大小，本题中字符集限定为大小写英文字母，$|\Sigma| = 52$。我们需要遍历所有可能的字符种类数量，共 $\dfrac{|\Sigma|}{2}$ 种可能性，内层循环中滑动窗口的复杂度为 $O(2N)$，因此总的时间复杂度为 $O(n \cdot |\Sigma|)$ 。
-   空间复杂度：$O(|\Sigma|)$。需要 $O(|\Sigma|)$ 存储所有大小写字母的计数。
