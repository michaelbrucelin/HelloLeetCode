### [最小化字符串长度](https://leetcode.cn/problems/minimize-string-length/solutions/3614466/zui-xiao-hua-zi-fu-chuan-chang-du-by-lee-o801/)

#### 方法一：哈希表

**思路与算法**

对于 $s$ 中的任意字母 $c$，都可以通过任意次操作只留下唯一的一个 $c$。因此，答案即为 $s$ 中不同字母的数量。我们可以使用一个哈希表进行去重。

由于一共只有 $26$ 个字母，而一个 $int$ 变量有 $32$ 个二进制位，我们可以用一个整数作为哈希表来存储每个字母是否出现。

**代码**

```C++
class Solution {
public:
    int minimizedStringLength(string s) {
        int mask = 0;
        for (char c : s) {
            mask |= 1 << (c - 'a');
        }
        return __builtin_popcount(mask);
    }
};
```

```C
int minimizedStringLength(char* s) {
    int mask = 0;
    int n = strlen(s);
    for (int i = 0; i < n; i++) {
        mask |= 1 << (s[i] - 'a');
    }
    return __builtin_popcount(mask);
}
```

```Java
class Solution {
    public int minimizedStringLength(String s) {
        int mask = 0;
        for (var c : s.toCharArray()) {
            mask |= 1 << (c - 'a');
        }
        return Integer.bitCount(mask);
    }
}
```

```CSharp
public class Solution {
    public int MinimizedStringLength(string s) {
        int mask = 0;
        foreach (char c in s) {
            mask |= 1 << (c - 'a');
        }
        return BitOperations.PopCount((uint)mask);
    }
}
```

```Go
func minimizedStringLength(s string) int {
    var mask uint
    for _, c := range s {
        mask |= 1 << (c - 'a')
    }
    return bits.OnesCount(mask)
}
```

```Python
class Solution:
    def minimizedStringLength(self, s: str) -> int:
        mask = 0
        for c in s:
            mask |= 1 << (ord(c) - ord('a'))
        return bin(mask).count('1')
```

```JavaScript
var minimizedStringLength = function(s) {
    let mask = 0;
    for (let c of s) {
        mask |= 1 << (c.charCodeAt(0) - 'a'.charCodeAt(0));
    }
    return mask.toString(2).split('0').join('').length;
};
```

```TypeScript
function minimizedStringLength(s: string): number {
    let mask = 0;
    for (let c of s) {
        mask |= 1 << (c.charCodeAt(0) - 'a'.charCodeAt(0));
    }
    return mask.toString(2).split('0').join('').length;
};
```

```Rust
impl Solution {
    pub fn minimized_string_length(s: String) -> i32 {
        let mut mask = 0u32;
        for c in s.chars() {
            mask |= 1 << (c as u8 - b'a');
        }
        mask.count_ones() as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。
- 空间复杂度：$O(1)$。
