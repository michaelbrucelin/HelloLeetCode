### [移除字符串中的尾随零](https://leetcode.cn/problems/remove-trailing-zeros-from-a-string/solutions/2820549/yi-chu-zi-fu-chuan-zhong-de-wei-sui-ling-g7b3/)

#### 方法一：模拟

**思路与算法**

根据题目要求，从右向左找到第一个不为 $0$ 的位置 $i$，返回 $num$ 从 $0$ 到 $i$ 构成的子字符串即可。

**代码**

```C++
class Solution {
public:
    string removeTrailingZeros(string num) {
        return num.substr(0, num.find_last_not_of('0') + 1);
    }
};
```

```C
char * removeTrailingZeros(char * num){
    int len = strlen(num);
    while (len > 0 && num[len - 1] == '0') {
        num[--len] = '\0';
    }
    return num;
}
```

```Java
class Solution {
    public String removeTrailingZeros(String num) {
        int len = num.length();
        while (len > 0 && num.charAt(len - 1) == '0') {
            len--;
        }
        return num.substring(0, len);
    }
}
```

```CSharp
public class Solution {
    public string RemoveTrailingZeros(string num) {
        int len = num.Length;
        while (len > 0 && num[len - 1] == '0') {
            len--;
        }
        return num.Substring(0, len);
    }
}
```

```Python
class Solution:
    def removeTrailingZeros(self, num: str) -> str:
        n = len(num)
        while n > 0 and num[n - 1] == '0':
            n -= 1
        return num[0 : n]
```

```Go
func removeTrailingZeros(num string) string {
    n := len(num)
    for n > 0 && num[n - 1] == '0' {
        n--
    }
    return num[0 : n]
}
```

```JavaScript
var removeTrailingZeros = function(num) {
    let len = num.length;
    while (len > 0 && num[len - 1] == '0') {
        len--;
    }
    return num.slice(0, len);
};
```

```TypeScript
function removeTrailingZeros(num: string): string {
    let len = num.length;
    while (len > 0 && num[len - 1] == '0') {
        len--;
    }
    return num.slice(0, len);
};
```

```Rust
impl Solution {
    pub fn remove_trailing_zeros(num: String) -> String {
        let mut num = num;
        while num.ends_with('0') {
            num.pop();
        }
        num
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 表示字符串的长度。只需遍历整个字符串即可，需要的时间为 $O(n)$。
- 空间复杂度：$O(1)$。除返回值外，不需要额外的空间。
