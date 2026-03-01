### [十-二进制数的最少数目](https://leetcode.cn/problems/partitioning-into-minimum-number-of-deci-binary-numbers/solutions/3907201/shi-er-jin-zhi-shu-de-zui-shao-shu-mu-by-prpo/)

#### 方法一：遍历

对于十进制整数字符串 $n$，如果某一位的数字为 $x$，那么至少需要 $x$ 个十-二进制数，才能使该位上的和等于 $x$。因此我们遍历十进制整数字符串 $n$，返回所有位上的数字最大值即可。

```C++
class Solution {
public:
    int minPartitions(string n) {
        int res = 0;
        for(char c : n) {
            res = max(res, c - '0');
        }
        return res;
    }
};
```

```Go
func minPartitions(n string) int {
    res := 0
    for _, c := range n {
        res = max(res, int(c - '0'))
    }
    return res
}
```

```Python
class Solution:
    def minPartitions(self, n: str) -> int:
        res = 0
        for c in n:
            res = max(res, ord(c) - ord('0'))
        return res
```

```Java
class Solution {
    public int minPartitions(String n) {
        int res = 0;
        for (char c : n.toCharArray()) {
            res = Math.max(res, c - '0');
        }
        return res;
    }
}
```

```TypeScript
function minPartitions(n: string): number {
    let res = 0;
    for (const c of n) {
        res = Math.max(res, c.charCodeAt(0) - '0'.charCodeAt(0));
    }
    return res;
}
```

```JavaScript
var minPartitions = function(n) {
    let res = 0;
    for (const c of n) {
        res = Math.max(res, c.charCodeAt(0) - '0'.charCodeAt(0));
    }
    return res;
};
```

```CSharp
public class Solution {
    public int MinPartitions(string n) {
        int res = 0;
        foreach (char c in n) {
            res = Math.Max(res, c - '0');
        }
        return res;
    }
}
```

```C
int minPartitions(char* n) {
    int res = 0;
    for (int i = 0; n[i] != '\0'; i++) {
        res = fmax(res, n[i] - '0');
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn min_partitions(n: String) -> i32 {
        let mut res = 0;
        for c in n.chars() {
            res = res.max(c as i32 - '0' as i32);
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m)$，其中 $m$ 是字符串 $n$ 的长度。
- 空间复杂度：$O(1)$。
