### [1比特与2比特字符](https://leetcode.cn/problems/1-bit-and-2-bit-characters/solutions/1264760/1bi-te-yu-2bi-te-zi-fu-by-leetcode-solut-rhrh/)

#### 方法一：正序遍历

根据题意，第一种字符一定以 $0$ 开头，第二种字符一定以 $1$ 开头。

我们可以对 $bits$ 数组从左到右遍历。当遍历到 $bits[i]$ 时，如果 $bits[i]=0$，说明遇到了第一种字符，将 $i$ 的值增加 $1$；如果 $bits[i]=1$，说明遇到了第二种字符，可以跳过 $bits[i+1]$（注意题目保证 $bits$ 一定以 $0$ 结尾，所以 $bits[i]$ 一定不是末尾比特，因此 $bits[i+1]$ 必然存在），将 $i$ 的值增加 $2$。

上述流程也说明 $bits$ 的编码方式是唯一确定的，因此若遍历到 $i=n-1$，那么说明最后一个字符一定是第一种字符。

```Python
class Solution:
    def isOneBitCharacter(self, bits: List[int]) -> bool:
        i, n = 0, len(bits)
        while i < n - 1:
            i += bits[i] + 1
        return i == n - 1
```

```C++
class Solution {
public:
    bool isOneBitCharacter(vector<int> &bits) {
        int n = bits.size(), i = 0;
        while (i < n - 1) {
            i += bits[i] + 1;
        }
        return i == n - 1;
    }
};
```

```Java
class Solution {
    public boolean isOneBitCharacter(int[] bits) {
        int n = bits.length, i = 0;
        while (i < n - 1) {
            i += bits[i] + 1;
        }
        return i == n - 1;
    }
}
```

```CSharp
public class Solution {
    public bool IsOneBitCharacter(int[] bits) {
        int n = bits.Length, i = 0;
        while (i < n - 1) {
            i += bits[i] + 1;
        }
        return i == n - 1;
    }
}
```

```Go
func isOneBitCharacter(bits []int) bool {
    i, n := 0, len(bits)
    for i < n-1 {
        i += bits[i] + 1
    }
    return i == n-1
}
```

```JavaScript
var isOneBitCharacter = function(bits) {
    let i = 0, n = bits.length;
    while (i < n - 1) {
        i += bits[i] + 1;
    }
    return i === n - 1;
};
```

```C
bool isOneBitCharacter(int* bits, int bitsSize){
    int i = 0;
    while (i < bitsSize - 1) {
        i += bits[i] + 1;
    }
    return i == bitsSize - 1;
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $bits$ 的长度。
- 空间复杂度：$O(1)$。

#### 方法二：倒序遍历

根据题意，$0$ 一定是一个字符的结尾。

我们可以找到 $bits$ 的倒数第二个 $0$ 的位置，记作 $i$（不存在时定义为 $-1$），那么 $bits[i+1]$ 一定是一个字符的开头，且从 $bits[i+1]$ 到 $bits[n-2]$ 的这 $n-2-i$ 个比特均为 $1$。

- 如果 $n-2-i$ 为偶数，则这些比特 $1$ 组成了 $\dfrac{n-2-i}{2}$ 个第二种字符，所以 $bits$ 的最后一个比特 $0$ 一定组成了第一种字符。
- 如果 $n-2-i$ 为奇数，则这些比特 $1$ 的前 $n-3-i$ 个比特组成了 $\dfrac{n-3-i}{2}$ 个第二种字符，多出的一个比特 $1$ 和 $bits$ 的最后一个比特 $0$ 组成第二种字符。

由于 $n-i$ 和 $n-2-i$ 的奇偶性相同，我们可以通过判断 $n-i$ 是否为偶数来判断最后一个字符是否为第一种字符，若为偶数则返回 $true$，否则返回 $false$。

```Python
class Solution:
    def isOneBitCharacter(self, bits: List[int]) -> bool:
        n = len(bits)
        i = n - 2
        while i >= 0 and bits[i]:
            i -= 1
        return (n - i) % 2 == 0
```

```C++
class Solution {
public:
    bool isOneBitCharacter(vector<int> &bits) {
        int n = bits.size(), i = n - 2;
        while (i >= 0 and bits[i]) {
            --i;
        }
        return (n - i) % 2 == 0;
    }
};
```

```Java
class Solution {
    public boolean isOneBitCharacter(int[] bits) {
        int n = bits.length, i = n - 2;
        while (i >= 0 && bits[i] == 1) {
            --i;
        }
        return (n - i) % 2 == 0;
    }
}
```

```CSharp
public class Solution {
    public bool IsOneBitCharacter(int[] bits) {
        int n = bits.Length, i = n - 2;
        while (i >= 0 && bits[i] == 1) {
            --i;
        }
        return (n - i) % 2 == 0;
    }
}
```

```Go
func isOneBitCharacter(bits []int) bool {
    n := len(bits)
    i := n - 2
    for i >= 0 && bits[i] == 1 {
        i--
    }
    return (n-i)%2 == 0
}
```

```JavaScript
var isOneBitCharacter = function(bits) {
    const n = bits.length;
    let i = n - 2;
    while (i >= 0 && bits[i]) {
        i--;
    }
    return (n - i) % 2 === 0;
};
```

```C
bool isOneBitCharacter(int* bits, int bitsSize){
    int i = bitsSize - 2;
    while (i >= 0 && bits[i]) {
        --i;
    }
    return (bitsSize - i) % 2 == 0;
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $bits$ 的长度。
- 空间复杂度：$O(1)$。
