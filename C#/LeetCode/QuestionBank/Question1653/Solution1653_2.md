﻿#### [方法一：枚举](https://leetcode.cn/problems/minimum-deletions-to-make-string-balanced/solutions/2147032/shi-zi-fu-chuan-ping-heng-de-zui-shao-sh-l5lk/)

**思路**

通过删除部分字符串，使得字符串达到下列三种情况之一，即为平衡状态：

1.  字符串全为 $"a"$；
2.  字符串全为 $"b"$；
3.  字符串既有 $"a"$ 也有 $"b"$，且所有 $"a"$ 都在所有 $"a"$ 左侧。

其中，为了达到第 $1$ 种情况，最少需要删除所有的 $"b"$。为了达到第 $2$ 种情况，最少需要删除所有的 $"a"$。而第 $3$ 种情况，可以在原字符串相邻的两个字符之间划一条间隔，删除间隔左侧所有的 $"b"$ 和间隔右侧所有的 $"a"$ 即可达到。用 $leftb$ 表示间隔左侧的 $"b"$ 的数目，$righta$ 表示间隔左侧的 $"a"$ 的数目，$leftb+righta$ 即为当前划分的间隔下最少需要删除的字符数。这样的间隔一共有 $n-1$ 种，其中 $n$ 是 $s$ 的长度。遍历字符串 $s$，即可以遍历 $n-1$ 种间隔，同时更新 $leftb$ 和 $righta$ 的数目。而上文讨论的前两种情况，其实就是间隔位于首字符前和末字符后的两种特殊情况，可以加入第 $3$ 种情况一并计算。

**代码**

```python
class Solution:
    def minimumDeletions(self, s: str) -> int:
        leftb, righta = 0, s.count('a')
        res = righta
        for c in s:
            if c == 'a':
                righta -= 1
            else:
                leftb += 1
            res = min(res, leftb + righta)
        return res
```

```java
class Solution {
    public int minimumDeletions(String s) {
        int leftb = 0, righta = 0;
        for (int i = 0; i < s.length(); i++) {
            if (s.charAt(i) == 'a') {
                righta++;
            }
        }
        int res = righta;
        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            if (c == 'a') {
                righta--;
            } else {
                leftb++;
            }
            res = Math.min(res, leftb + righta);
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int MinimumDeletions(string s) {
        int leftb = 0, righta = 0;
        foreach (char c in s) {
            if (c == 'a') {
                righta++;
            }
        }
        int res = righta;
        foreach (char c in s) {
            if (c == 'a') {
                righta--;
            } else {
                leftb++;
            }
            res = Math.Min(res, leftb + righta);
        }
        return res;
    }
}
```

```cpp
class Solution {
public:
    int minimumDeletions(string s) {
        int leftb = 0, righta = 0;
        for (int i = 0; i < s.size(); i++) {
            if (s[i] == 'a') {
                righta++;
            }
        }
        int res = righta;
        for (int i = 0; i < s.size(); i++) {
            char c = s[i];
            if (c == 'a') {
                righta--;
            } else {
                leftb++;
            }
            res = min(res, leftb + righta);
        }
        return res;
    }
};
```

```c
#define MIN(a, b) ((a) < (b) ? (a) : (b))

int minimumDeletions(char * s) {
    int len = strlen(s);
    int leftb = 0, righta = 0;
    for (int i = 0; i < len; i++) {
        if (s[i] == 'a') {
            righta++;
        }
    }
    int res = righta;
    for (int i = 0; i < len; i++) {
        char c = s[i];
        if (c == 'a') {
            righta--;
        } else {
            leftb++;
        }
        res = MIN(res, leftb + righta);
    }
    return res;
}
```

```javascript
var minimumDeletions = function(s) {
    let leftb = 0, righta = 0;
    for (let i = 0; i < s.length; i++) {
        if (s[i] === 'a') {
            righta++;
        }
    }
    let res = righta;
    for (let i = 0; i < s.length; i++) {
        const c = s[i];
        if (c === 'a') {
            righta--;
        } else {
            leftb++;
        }
        res = Math.min(res, leftb + righta);
    }
    return res;
};
```

```go
func minimumDeletions(s string) int {
    leftb := 0
    righta := 0
    for _, c := range s {
        if c == 'a' {
            righta++
        }
    }
    res := righta
    for _, c := range s {
        if c == 'a' {
            righta--
        } else {
            leftb++
        }
        res = min(res, leftb+righta)
    }
    return res
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是 $s$ 的长度。需要遍历两遍 $s$，第一遍计算出 $s$ 中 $"a"$ 的数量，第二遍遍历所有的间隔，求出最小需要删除的字符数。
-   空间复杂度：$O(1)$，只需要常数空间。
