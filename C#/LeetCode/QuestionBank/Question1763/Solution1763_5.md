#### [����������������](https://leetcode.cn/problems/longest-nice-substring/solutions/1240201/zui-chang-de-mei-hao-zi-zi-fu-chuan-by-l-4l1t/)

**˼·**

�������ڵĽⷨͬ���ο���[395\. ������K���ظ��ַ�����Ӵ�](https://leetcode-cn.com/problems/longest-substring-with-at-least-k-repeating-characters/)���� ����ö����Ӵ��е��ַ�������Ŀ������СΪ $1$�����Ϊ $\dfrac{|\Sigma|}{2}$������ͬһ���ַ��Ĵ�Сд��ʽ��Ϊͬһ���ַ���

���ڸ������ַ��������� $typeNum$������ά���������ڵ����ұ߽� $l,r$�����������ڲ���С�ַ����ֵĴ��� $upperCnt, lowerCnt$���Լ����������ڵ��ַ�������Ŀ $total$���� $total > typeNum$ ʱ�����ǲ��ϵ�������߽� $l$������Ӧ�ظ��� $upperCnt, lowerCnt$ �Լ� $total$��ֱ�� $total \le typeNum$ Ϊֹ�������������κ�һ���ұ߽� $r$�����Ƕ����ҵ���С�� $l$����Ϊ $l_{min}$��ʹ�� $s[l_{min}...r]$ ֮����ַ�������Ŀ������ $typeNum$��

�����ַ�������Ϊ���е��ַ�ͬʱ���ִ�д��Сд��ʽ����������ַ���һ��������ĳ�������С������κ�һ�� $l_{min}, r$ ���ԣ�������Ҫ�жϵ�ǰ $s[l_{min}...r]$ �Ƿ�Ϊ�����ַ�������ⷽ�����£�

-   ��ǰ�ַ����е��ַ���������Ϊ $typeNum$����ǰ�ַ�����ͬʱ���ִ�Сд���ַ�����������Ϊ $cnt$��ֻ������ $cnt$ ���� $typeNum$ ʱ�����ǿ����ж��ַ���Ϊ�����ַ�����
-   ���� $upperCnt, lowerCnt$ �������飬�� $i$ ���ַ�ͬʱ���� $upperCnt[i] > 0, lowerCnt[i] > 0$ ʱ������Ϊ�� $i$ ���ַ��Ĵ�Сд��ʽͬʱ���֡�

��������Ľ��ۣ����޶��ַ�������ĿΪ $typeNum$ ʱ�������������Ӵ�����һ������ĳ�� $s[l_{min}...r]$����ˣ��ڻ������ڵ�ά�������У��Ϳ���ֱ�ӵõ���Ӵ��Ĵ�С��

��󣬻�ʣ��һ��ϸ�ڣ�����ڻ������ڵ�ͬʱ��Ч��ά�� $total$ �� $cnt$��

-   �����ұ߽� $r$ ʱ������ $s[r]$ ��Ӧ���ַ�������Ϊ $idx$�������� $upperCnt[r] + lowerCnt[r] = 1$ ʱ����������Ϊ��ʱ������һ���ַ����� $total$ �� $1$��
-   �����ұ߽� $r$ ʱ������ $s[r]$ ��Ӧ���ַ�������Ϊ $idx$����� $s[r]$ ΪСд��ĸ�������ұ߽�󣬵����� $lowerCnt[idx] = 1$ �� $upperCnt[idx] > 0$ ʱ����������Ϊ��ʱ������һ�ִ�Сдͬʱ���ڵ��ַ����� $cnt$ �� $1$����� $s[r]$ Ϊ��д��ĸ�������ұ߽�󣬵����� $upperCnt[idx] = 1$ �� $lowerCnt[idx] > 0$ ʱ����������Ϊ��ʱ������һ�ִ�Сдͬʱ���ڵ��ַ����� $cnt$ �� $1$��
-   ������߽� $l$ ʱ������ $s[l]$ ��Ӧ���ַ�������Ϊ $idx$�������� $upperCnt[idx] + lowerCnt[idx] = 1$ ʱ��������߽����������Ϊ��ʱ������һ���ַ����� $total$ �� $1$��
-   ������߽� $l$ ʱ������ $s[l]$ ��Ӧ���ַ�������Ϊ $idx$����� $s[l]$ ΪСд��ĸ��������߽�󣬵����� $lowerCnt[idx] = 0$ �� $upperCnt[idx] > 0$ ʱ����������Ϊ��ʱ������һ�ִ�Сдͬʱ���ڵ��ַ����� $cnt$ �� $1$����� $s[l]$ Ϊ��д��ĸ��������߽�󣬵����� $upperCnt[idx] = 0$ �� $lowerCnt[idx] > 0$ ʱ����������Ϊ��ʱ������һ�ִ�Сдͬʱ���ڵ��ַ����� $cnt$ �� $1$��

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n \cdot |\Sigma|)$������ $n$ Ϊ�ַ����ĳ��ȣ�$|\Sigma|$ Ϊ�ַ����Ĵ�С���������ַ����޶�Ϊ��СдӢ����ĸ��$|\Sigma| = 52$��������Ҫ�������п��ܵ��ַ������������� $\dfrac{|\Sigma|}{2}$ �ֿ����ԣ��ڲ�ѭ���л������ڵĸ��Ӷ�Ϊ $O(2N)$������ܵ�ʱ�临�Ӷ�Ϊ $O(n \cdot |\Sigma|)$ ��
-   �ռ临�Ӷȣ�$O(|\Sigma|)$����Ҫ $O(|\Sigma|)$ �洢���д�Сд��ĸ�ļ�����
