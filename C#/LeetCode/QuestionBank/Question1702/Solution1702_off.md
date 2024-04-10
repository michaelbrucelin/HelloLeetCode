### [修改后的最大二进制字符串](https://leetcode.cn/problems/maximum-binary-string-after-change/solutions/2726979/xiu-gai-hou-de-zui-da-er-jin-zhi-zi-fu-c-put3/)

#### 方法一：模拟 + 贪心

##### 思路与算法

我们从字符串左边第一位开始依次遍历，如果是 $1$ 则不用改变，如果是 $0$，我们则想办法将其变成 $1$。

我们会找到下一位出现的 $0$，利用操作 $2$ 我们可以使得这两个 $0$ 相邻，再使用操作 $1$ 使得 $00$ 变成 $10$。

我们依次执行这个操作，直到字符串中没有第二个 $0$，或者达到字符串结尾。


##### 代码

```c++
class Solution {
public:
    string maximumBinaryString(string binary) {
        int n = binary.size();
        int j = 0;
        for (int i = 0; i < n; i++) {
            if (binary[i] == '0') {
                while (j <= i || (j < n && binary[j] == '1')) {
                    j++;
                }
                if (j < n) {
                    binary[j] = '1';
                    binary[i] = '1';
                    binary[i + 1] = '0';
                }
            }
        }
        return binary;
    }
};
```

```java
class Solution {
    public String maximumBinaryString(String binary) {
        int n = binary.length();
        char[] s = binary.toCharArray();
        int j = 0;
        for (int i = 0; i < n; i++) {
            if (s[i] == '0') {
                while (j <= i || (j < n && s[j] == '1')) {
                    j++;
                }
                if (j < n) {
                    s[j] = '1';
                    s[i] = '1';
                    s[i + 1] = '0';
                }
            }
        }
        return new String(s);
    }
}
```

```csharp
public class Solution {
    public string MaximumBinaryString(string binary) {
        int n = binary.Length;
        char[] s = binary.ToCharArray();
        int j = 0;
        for (int i = 0; i < n; i++) {
            if (s[i] == '0') {
                while (j <= i || (j < n && s[j] == '1')) {
                    j++;
                }
                if (j < n) {
                    s[j] = '1';
                    s[i] = '1';
                    s[i + 1] = '0';
                }
            }
        }
        return new string(s);
    }
}
```

```python
class Solution:
    def maximumBinaryString(self, binary: str) -> str:
        n = len(binary)
        s = list(binary)
        j = 0
        for i in range(n):
            if s[i] == '0':
                while j <= i or (j < n and s[j] == '1'):
                    j += 1
                if j < n:
                    s[j] = '1'
                    s[i] = '1'
                    s[i + 1] = '0'
        return ''.join(s)
```

```javascript
var maximumBinaryString = function(binary) {
    const n = binary.length;
    const s = binary.split('');
    let j = 0;
    for (let i = 0; i < n; i++) {
        if (s[i] === '0') {
            while (j <= i || (j < n && s[j] === '1')) {
                j++;
            }
            if (j < n) {
                s[j] = '1';
                s[i] = '1';
                s[i + 1] = '0';
            }
        }
    }
    return s.join('');
};
```

```typescript
function maximumBinaryString(binary: string): string {
    const n = binary.length;
    const s = binary.split('');
    let j = 0;
    for (let i = 0; i < n; i++) {
        if (s[i] === '0') {
            while (j <= i || (j < n && s[j] === '1')) {
                j++;
            }
            if (j < n) {
                s[j] = '1';
                s[i] = '1';
                s[i + 1] = '0';
            }
        }
    }
    return s.join('');
};
```

```go
func maximumBinaryString(binary string) string {
    n := len(binary)
    s := []rune(binary)
    j := 0
    for i := 0; i < n; i++ {
        if s[i] == '0' {
            for j <= i || (j < n && s[j] == '1') {
                j++
            }
            if j < n {
                s[j] = '1'
                s[i] = '1'
                s[i+1] = '0'
            }
        }
    }
    return string(s)
}
```

```rust
impl Solution {
    pub fn maximum_binary_string(binary: String) -> String {
        let n = binary.len();
        let mut s: Vec<char> = binary.chars().collect();
        let mut j = 0;
        for i in 0..n {
            if s[i] == '0' {
                while j <= i || (j < n && s[j] == '1') {
                    j += 1;
                }
                if j < n {
                    s[j] = '1';
                    s[i] = '1';
                    s[i + 1] = '0';
                }
            }
        }
        s.iter().collect()
    }
}
```

```c
char* maximumBinaryString(char* binary) {
    int n = strlen(binary);
    char *s = malloc(n + 1);
    strcpy(s, binary);
    int j = 0;
    for (int i = 0; i < n; i++) {
        if (s[i] == '0') {
            while (j <= i || (j < n && s[j] == '1')) {
                j++;
            }
            if (j < n) {
                s[j] = '1';
                s[i] = '1';
                s[i + 1] = '0';
            }
        }
    }
    return s;
}
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $\textit{binary}$ 的长度。
- 空间复杂度：$O(n)$，其中 $n$ 是字符串 $\textit{binary}$ 的长度。空间用于输出字符串和其中间变量。

#### 方法二：直接构造

##### 思路与算法

我们注意到最终结果，至多有一个 $0$。如果输入字符串中没有 $0$，则直接返回结果。如果有 $0$，结果中 $0$ 的位置取决于字符串第一个 $0$ 的位置，之后每多一个 $0$ 便可以向后移动一位。

所以我们只需要求出字符串中第一个 $0$ 的下标，以及 $0$ 的出现的个数，即可直接构造结果。

##### 代码

```c++
class Solution {
public:
    string maximumBinaryString(string binary) {
        int n = binary.size(), i = binary.find('0');
        if (i == string::npos) {
            return binary;
        }
        int zeros = count(binary.begin(), binary.end(), '0');
        string s(n, '1');
        s[i + zeros - 1] = '0';
        return s;
    }
};
```

```java
class Solution {
    public String maximumBinaryString(String binary) {
        int n = binary.length(), i = binary.indexOf('0');
        if (i < 0) {
            return binary;
        }
        int zeros = 0;
        StringBuilder s = new StringBuilder();
        for (int j = 0; j < n; j++) {
            if (binary.charAt(j) == '0') {
                zeros++;
            }
            s.append('1');
        }
        s.setCharAt(i + zeros - 1, '0');
        return s.toString();
    }
}
```

```csharp
public class Solution {
    public string MaximumBinaryString(string binary) {
        int n = binary.Length, i = binary.IndexOf('0');
        if (i < 0) {
            return binary;
        }
        int zeros = 0;
        StringBuilder s = new StringBuilder();
        foreach (char c in binary) {
            if (c == '0') {
                zeros++;
            }
            s.Append('1');
        }
        s[i + zeros - 1] = '0';
        return s.ToString();
    }
}
```

```python
class Solution:
    def maximumBinaryString(self, binary: str) -> str:
        n = len(binary)
        i = binary.find("0")
        if i < 0:
            return binary
        zeros = binary.count('0')
        s = ['1'] * n
        s[i + zeros - 1] = '0'
        return ''.join(s)
```

```javascript
var maximumBinaryString = function(binary) {
    const n = binary.length;
    const i = binary.indexOf('0');
    if (i < 0) {
        return binary;
    }
    const zeros = binary.split('0').length - 1;
    const s = Array(n).fill('1');
    s[i + zeros - 1] = '0';
    return s.join('');
};
```

```typescript
function maximumBinaryString(binary: string): string {
    const n = binary.length;
    const i = binary.indexOf('0');
    if (i < 0) {
        return binary;
    }
    const zeros = binary.split('0').length - 1;
    const s = Array(n).fill('1');
    s[i + zeros - 1] = '0';
    return s.join('');
};
```

```go
func maximumBinaryString(binary string) string {
    n := len(binary)
    i := strings.Index(binary, "0")
    if i < 0 {
        return binary
    }
    zeros := strings.Count(binary, "0")
    s := []rune(strings.Repeat("1", n))
    s[i + zeros - 1] = '0'
    return string(s)
}
```

```rust
impl Solution {
    pub fn maximum_binary_string(binary: String) -> String {
        let n = binary.len();
        let mut s: Vec<char> = binary.chars().collect();
        let mut i = n;
        let mut zeros = 0;
        for j in 0..n {
            if s[j] == '0' {
                if (i == n) {
                    i = j;
                }
                zeros += 1;
            }
            s[j] = '1'
        }
        if zeros == 0 {
            return binary;
        }
        s[i as usize + zeros - 1] = '0';
        s.iter().collect()
    }
}
```

```c
char* maximumBinaryString(char* binary) {
    int n = strlen(binary);
    int i;
    for (i = 0; i < n && binary[i] != '0'; i++);
    if (i == n) {
        return binary;
    }
    char *s = malloc(n + 1);
    int zeros = 0;
    for (int j = 0; j < n; j++) {
        s[j] = '1';
        if (binary[j] == '0') {
            zeros++;
        }
    }
    s[i + zeros - 1] = '0';
    s[n] = '\0';
    return s;
}
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $\textit{binary}$ 的长度。
- 空间复杂度：$O(n)$，其中 $n$ 是字符串 $\textit{binary}$ 的长度。空间用于输出字符串和其中间变量。
