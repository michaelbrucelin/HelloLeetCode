#### [方法二：二进制表示集合](https://leetcode.cn/problems/check-if-the-sentence-is-pangram/solutions/2017130/pan-duan-ju-zi-shi-fou-wei-quan-zi-mu-ju-xc7a/)

**思路与算法**

使用数组记录每种字符是否出现仍然需要 O(C) 的空间复杂度。由于字符集仅有 26 个，我们可以使用一个长度为 26 的二进制数字来表示字符集合，这个二进制数字使用 32 位带符号整型变量即可。

二进制数字的第 i 位对应字符集中的第 i 个字符，例如 0 对应 a，1 对应 b，23 对应 x 等。

初始化整型变量 exist 为 0，遍历 sentence 中的每个字符 c，如果 c 是字母表中的第 $i~(0 \le i \lt 26)$  个字母，就将 exist 的二进制表示中第 i 位赋值为 1。在实现过程中，将 exist 与 $2^i$ 做或运算，$2^i$ 可以用左移运算实现。

最后，我们需要判断 exist 是否等于 $2^{26} - 1$，这个数字的第 $0 \sim 25$ 位都为 1，其余位为 0。如果等于，返回 true，否则返回 false。

**代码**

```python
class Solution:
    def checkIfPangram(self, sentence: str) -> bool:
        state = 0
        for c in sentence:
            state |= 1 << (ord(c) - ord('a'))
        return state == (1 << 26) - 1
```

```cpp
class Solution {
public:
    bool checkIfPangram(string sentence) {
        int state = 0;
        for (auto c : sentence) {
            state |= 1 << (c - 'a');
        }
        return state == (1 << 26) - 1;
    }
};
```

```java
class Solution {
    public boolean checkIfPangram(String sentence) {
        int state = 0;
        for (int i = 0; i < sentence.length(); i++) {
            char c = sentence.charAt(i);
            state |= 1 << (c - 'a');
        }
        return state == (1 << 26) - 1;
    }
}
```

```c#
public class Solution {
    public bool CheckIfPangram(string sentence) {
        int state = 0;
        foreach (char c in sentence) {
            state |= 1 << (c - 'a');
        }
        return state == (1 << 26) - 1;
    }
}
```

```go
func checkIfPangram(sentence string) bool {
    state := 0
    for _, c := range sentence {
        state |= 1 << (c - 'a')
    }
    return state == 1<<26-1
}
```

```javascript
var checkIfPangram = function(sentence) {
    let state = 0;
    for (let i = 0; i < sentence.length; i++) {
        const c = sentence[i];
        state |= 1 << (c.charCodeAt() - 'a'.charCodeAt());
    }
    return state == (1 << 26) - 1;
};
```

```c
bool checkIfPangram(char * sentence) {
    int state = 0;
    for (int i = 0; sentence[i] != '\0'; i++) {
        state |= 1 << (sentence[i] - 'a');
    }
    return state == (1 << 26) - 1;
}
```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是 sentence 的长度。整个过程只需要遍历一次 sentence。
-   空间复杂度：O(1)。只使用到常数个变量。
