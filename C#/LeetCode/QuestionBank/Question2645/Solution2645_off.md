### [构造有效字符串的最小插入数](https://leetcode.cn/problems/minimum-additions-to-make-valid-string/solutions/2590673/gou-zao-you-xiao-zi-fu-chuan-de-zui-xiao-vfaf/)

#### 方法一：动态规划

##### 思路与算法

定义状态 $d[i]$ 为将前 $i$ 个字符（为了方便编码，下标从 $1$ 开始）拼凑成若干个 $abc$ 所需要的最小插入数。那么初始状态 $d[0] = 0$，最终要求解 $d[n]$，其中 $n$ 为 $word$ 的长度。

转移过程有以下几种情况：

1. $word[i]$ 单独存在于一组 $abc$ 中，$d[i] = d[i - 1] + 2$。
2. 如果 $word[i] \gt word[i - 1]$，那么 $word[i]$ 可以和 $word[i - 1]$ 在同一组 $abc$ 中，$d[i] = d[i - 1] - 1$。
$d[i]$ 取以上情况的最小值。在本题中，每个字符总是尽可能的与前面的字符去组合，因此情况 $2$ 优于情况 $1$（从动态转移方程中也可以发现此规律），按照顺序依次更新 $d[i]$ 即可，并不需要取最小值。

##### 代码

```c++
class Solution {
public:
    int addMinimum(string word) {
        int n = word.size();
        vector<int> d(n + 1);
        for (int i = 1; i <= n; i++) {
            d[i] = d[i - 1] + 2;
            if (i > 1 && word[i - 1] > word[i - 2]) {
                d[i] = d[i - 1] - 1;
            }
        }
        return d[n];
    }
};
```

```java
class Solution {
    public int addMinimum(String word) {
        int n = word.length();
        int[] d = new int[n + 1];
        for (int i = 1; i <= n; i++) {
            d[i] = d[i - 1] + 2;
            if (i > 1 && word.charAt(i - 1) > word.charAt(i - 2)) {
                d[i] = d[i - 1] - 1;
            }
        }
        return d[n];
    }
}
```

```csharp
public class Solution {
    public int AddMinimum(string word) {
        int n = word.Length;
        int[] d = new int[n + 1];
        for (int i = 1; i <= n; i++) {
            d[i] = d[i - 1] + 2;
            if (i > 1 && word[i - 1] > word[i - 2]) {
                d[i] = d[i - 1] - 1;
            }
        }
        return d[n];
    }
}
```

```go
func addMinimum(word string) int {
    n := len(word)
    d := make([]int, n + 1)
    for i := 1; i <= n; i++ {
        d[i] = d[i - 1] + 2
        if i > 1 && word[i - 1] > word[i - 2] {
            d[i] = d[i - 1] - 1
        }
    }
    return d[n]
}
```

```python
class Solution:
    def addMinimum(self, word: str) -> int:
        n = len(word)
        d = [0] * (n + 1)
        for i in range(1, n + 1):
            d[i] = d[i - 1] + 2
            if i > 1 and word[i - 1] > word[i - 2]:
                d[i] = d[i - 1] - 1
        return d[n]
```

```c
int addMinimum(char * word) {
    int n = strlen(word);
    int d[n + 1];
    memset(d, 0, sizeof(d));
    for (int i = 1; i <= n; i++) {
        d[i] = d[i - 1] + 2;
        if (i > 1 && word[i - 1] > word[i - 2]) {
            d[i] = d[i - 1] - 1;
        }
    }
    return d[n];
}
```

```javascript
var addMinimum = function(word) {
    const n = word.length;
    const d = new Array(n + 1).fill(0);
    for (let i = 1; i <= n; i++) {
        d[i] = d[i - 1] + 2;
        if (i > 1 && word[i - 1] > word[i - 2]) {
            d[i] = d[i - 1] - 1;
        }
    }
    return d[n];
};
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 为 $word$ 的长度。
- 空间复杂度：$O(n)$。状态转移时，最多只会依赖前一个状态 $d[i - 1]$，因此使用滚动数组优化可以使得空间复杂度降至 $O(1)$。

#### 方法二：直接拼接

##### 思路与算法

方法一中提到，每个字符总是尽可能的与前面的字符去组合，如果当前字符大于前面字符（例如 $c$ 前面是 $a$，或者 $c$ 前面是 $b$），则很易于处理（中间添置一个 $b$，或者什么也不做)。相反，如果当前字符小于等于前面字符呢？

其实也很好处理，当前字符小于等于前面字符说明它们一定不在同一组 $abc$ 中，只需要添置若干字符过渡这两者即可。例如 $b$ 前面是 $c$，则需要在中间添置 $a$，又例如 $b$ 前面是 $b$，则需要在中间添置 $ca$。

以上两种情况可以用一个模型来表示，设当前字符是 $x$，前面字符是 $y$，那么需要添置的字符个数为 $(x - y - 1 + 3) \mod 3$。其中 $+3$ 再对 $3$ 取模，可以应对 $x$ 小于等于 $y$ 的情况。

最后还需要处理头尾两个字符，$word[0]$ 前面添置 $word[0] - 'a'$ 个字符，$word[n - 1]$ 后面添置 $'c' - word[n - 1]$ 个字符。两个可以合并为 $word[0] - word[n - 1] + 2$。

##### 代码

```c++
class Solution {
public:
    int addMinimum(string word) {
        int n = word.size();
        int res = word[0] - word[n - 1] + 2;
        for (int i = 1; i < n; i++) {
            res += (word[i] - word[i - 1] + 2) % 3;
        }
        return res;
    }
};
```

```java
class Solution {
    public int addMinimum(String word) {
        int n = word.length();
        int res = word.charAt(0) - word.charAt(n - 1) + 2;
        for (int i = 1; i < n; i++) {
            res += (word.charAt(i) - word.charAt(i - 1) + 2) % 3;
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int AddMinimum(string word) {
        int n = word.Length;
        int res = word[0] - word[n - 1] + 2;
        for (int i = 1; i < n; i++) {
            res += (word[i] - word[i - 1] + 2) % 3;
        }
        return res;
    }
}
```

```go
func addMinimum(word string) int {
    n := len(word)
    res := int(word[0] - word[n - 1] + 2)
    for i := 1; i < n; i++ {
        res += int(word[i] - word[i - 1] + 2) % 3
    }
    return res
}
```

```python
class Solution:
    def addMinimum(self, word: str) -> int:
        n = len(word)
        res = ord(word[0]) - ord(word[n - 1]) + 2
        for i in range (1, n):
            res += (ord(word[i]) - ord(word[i - 1]) + 2) % 3
        return res
```

```c
int addMinimum(char * word) {
    int n = strlen(word);
    int res = word[0] - word[n - 1] + 2;
    for (int i = 1; i < n; i++) {
        res += (word[i] - word[i - 1] + 2) % 3;
    }
    return res;
}
```

```javascript
var addMinimum = function(word) {
    const n = word.length;
    let res = word.charCodeAt(0) - word.charCodeAt(n - 1) + 2;
    for (let i = 1; i < n; i++) {
        res += (word.charCodeAt(i) - word.charCodeAt(i - 1) + 2) % 3;
    }
    return res;
};
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 为 $word$ 的长度。
- 空间复杂度：$O(1)$。

#### 方法三：计算组数

##### 思路与算法

方法二中提到，如果当前字符小于等于前面字符说明它们一定不在同一组中，反之则一定在同一组中。因此如果我们知道了最终的组数，就可以直接计算需要添加的字符数量。而最终的组数，就等于所有满足后者字符小于等于前者字符的情况数再加 $1$。

##### 代码

```c++
class Solution {
public:
    int addMinimum(string word) {
        int n = word.size(), cnt = 1;
        for (int i = 1; i < n; i++) {
            if (word[i] <= word[i - 1]) {
                cnt++;
            }
        }
        return cnt * 3 - n;
    }
};
```

```java
class Solution {
    public int addMinimum(String word) {
        int n = word.length(), cnt = 1;
        for (int i = 1; i < n; i++) {
            if (word.charAt(i) <= word.charAt(i - 1)) {
                cnt++;
            }
        }
        return cnt * 3 - n;
    }
}
```

```csharp
public class Solution {
    public int AddMinimum(string word) {
        int n = word.Length, cnt = 1;
        for (int i = 1; i < n; i++) {
            if (word[i] <= word[i - 1]) {
                cnt++;
            }
        }
        return cnt * 3 - n;
    }
}
```

```go
func addMinimum(word string) int {
    n, cnt := len(word), 1
    for i := 1; i < n; i++ {
        if word[i] <= word[i - 1] {
            cnt++
        }
    }
    return cnt * 3 - n
}
```

```python
class Solution:
    def addMinimum(self, word: str) -> int:
        n, cnt = len(word), 1
        for i in range(1, n):
            if word[i] <= word[i - 1]:
                cnt += 1
        return cnt * 3 - n
```

```c
int addMinimum(char * word) {
    int n = strlen(word), cnt = 1;
    for (int i = 1; i < n; i++) {
        if (word[i] <= word[i - 1]) {
            cnt++;
        }
    }
    return cnt * 3 - n;
}
```

```javascript
var addMinimum = function(word) {
    const n = word.length;
    let cnt = 1;
    for (let i = 1; i < n; i++) {
        if (word[i] <= word[i - 1]) {
            cnt++;
        }
    }
    return cnt * 3 - n;
};
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 为 $word$ 的长度。
- 空间复杂度：$O(1)$。
