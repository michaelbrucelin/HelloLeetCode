### [转换成小写字母](https://leetcode.cn/problems/to-lower-case/solutions/1151839/zhuan-huan-cheng-xiao-xie-zi-mu-by-leetc-5e29/)

#### 方法一：使用语言 API

**思路与算法**

我们可以使用语言自带的大写字母转小写字母的 API。

**代码**

```cpp
class Solution {
public:
    string toLowerCase(string s) {
        for (char& ch: s) {
            ch = tolower(ch);
        }
        return s;
    }
};
```

```java
class Solution {
    public String toLowerCase(String s) {
        return s.toLowerCase();
    }
}
```

```csharp
public class Solution {
    public string ToLowerCase(string s) {
        return s.ToLower();
    }
}
```

```python
class Solution:
    def toLowerCase(self, s: str) -> str:
        return s.lower()
```

```c
char * toLowerCase(char * s){
    int len = strlen(s);
    for (int i = 0; i < len; ++i) {
        s[i] = tolower(s[i]);
    }
    return s;
}
```

```go
func toLowerCase(s string) string {
    return strings.ToLower(s)
}
```

```javascript
var toLowerCase = function(s) {
    return s.toLowerCase();
};
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。
-   空间复杂度：$O(1)$，不考虑返回值的空间占用。

#### 方法二：自行实现该 API

**思路与算法**

方法二的主要目的是，带领读者一步一步设计一个高效的大写字母转小写字母的 API。

我们可以想到的最简单的方法是使用一个哈希映射，哈希映射中包含 $26$ 个键值对 $(A, a), (B, b), \cdots, (Z, z)$。对于每个待转换的字符 $ch$，如果它出现在是哈希映射中（即 $ch$ 是哈希映射中的一个键），那么 $ch$ 是大写字母，我们获取 $ch$ 在哈希映射中的值即可得到对应的小写字母；如果它没有出现在哈希映射中，那么 $ch$ 是其它字符，我们无需进行转换。

然而这种方法需要一定量的辅助空间，不够简洁。一种更好的方法是观察小写字母和大写字母的 $ASCII$ 码表示：

-   大写字母 $A - Z$ 的 $ASCII$ 码范围为 $[65, 90]$：
-   小写字母 $a - z$ 的 $ASCII$ 码范围为 $[97, 122]$。

因此，如果我们发现 $ch$ 的 $ASCII$ 码在 $[65, 90]$ 的范围内，那么我们将它的 $ASCII$ 码增加 $32$，即可得到对应的小写字母。

近而我们可以发现，由于 $[65, 90]$ 对应的二进制表示为 $[(01000001)_2, (01011010)_2]$，$32$ 对应的二进制表示为 $(00100000)_2$，而对于 $[(01000001)_2, (01011010)_2]$ 内的所有数，表示 $32$ 的那个二进制位都是 $0$，因此可以对 $ch$ 的 $ASCII$ 码与 $32$ 做按位或运算，替代与 $32$ 的加法运算。

**代码**

```cpp
class Solution {
public:
    string toLowerCase(string s) {
        for (char& ch: s) {
            if (ch >= 65 && ch <= 90) {
                ch |= 32;
            }
        }
        return s;
    }
};
```

```java
class Solution {
    public String toLowerCase(String s) {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.length(); ++i) {
            char ch = s.charAt(i);
            if (ch >= 65 && ch <= 90) {
                ch |= 32;
            }
            sb.append(ch);
        }
        return sb.toString();
    }
}
```

```csharp
public class Solution {
    public string ToLowerCase(string s) {
        StringBuilder sb = new StringBuilder();
        foreach (char ch in s) {
            char chNew = (int) ch >= 65 && (int) ch <= 90 ? (char) (ch | 32) : (char) ch;
            sb.Append(chNew);
        }
        return sb.ToString();
    }
}
```

```python
class Solution:
    def toLowerCase(self, s: str) -> str:
        return "".join(chr(asc | 32) if 65 <= (asc := ord(ch)) <= 90 else ch for ch in s)
```

```c
char * toLowerCase(char * s){
    int len = strlen(s);
    for (int i = 0; i < len; ++i) {
        if (s[i] >= 65 && s[i] <= 90) {
            s[i] |= 32;
        }
    }
    return s;
}
```

```go
func toLowerCase(s string) string {
    lower := &strings.Builder{}
    lower.Grow(len(s))
    for _, ch := range s {
        if 65 <= ch && ch <= 90 {
            ch |= 32
        }
        lower.WriteRune(ch)
    }
    return lower.String()
}
```

```javascript
var toLowerCase = function(s) {
    const sb = [];
    for (let ch of s) {
        if (ch.charCodeAt() >= 65 && ch.charCodeAt() <= 90) {
            ch = String.fromCharCode(ch.charCodeAt() | 32);
        }
        sb.push(ch);
    }
    return sb.join('');
};
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。
-   空间复杂度：$O(1)$，不考虑返回值的空间占用。
