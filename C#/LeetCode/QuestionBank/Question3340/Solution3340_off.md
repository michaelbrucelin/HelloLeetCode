### [检查平衡字符串](https://leetcode.cn/problems/check-balanced-string/solutions/3609729/jian-cha-ping-heng-zi-fu-chuan-by-leetco-9e36/)

#### 方法一：模拟

**思路与算法**

遍历字符串中的每一个字符，转换成对应的数字，再计算奇偶数位的数字差。最后返回差是否为零即可。

**代码**

```C++
class Solution {
public:
    bool isBalanced(string num) {
        int diff = 0, sign = 1;
        for (char c : num) {
            int d = c - '0';
            diff += d * sign;
            sign = -sign;
        }
        return diff == 0;
    }
};
```

```Java
class Solution {
    public boolean isBalanced(String num) {
        int diff = 0, sign = 1;
        for (int i = 0; i < num.length(); ++i) {
            int d = num.charAt(i) - '0';
            diff += d * sign;
            sign = -sign;
        }
        return diff == 0;
    }
}
```

```Python
class Solution:
    def isBalanced(self, num: str) -> bool:
        diff = 0
        sign = 1
        for c in num:
            d = int(c)
            diff += d * sign
            sign = -sign
        return diff == 0
```

```JavaScript
var isBalanced = function(num) {
    let diff = 0, sign = 1;
    for (let c of num) {
        let d = parseInt(c);
        diff += d * sign;
        sign = -sign;
    }
    return diff === 0;
};
```

```TypeScript
function isBalanced(num: string): boolean {
    let diff = 0, sign = 1;
    for (let c of num) {
        let d = parseInt(c);
        diff += d * sign;
        sign = -sign;
    }
    return diff === 0;
};
```

```Go
func isBalanced(num string) bool {
    diff := 0
    sign := 1
    for _, c := range num {
        d := int(c - '0')
        diff += d * sign
        sign = -sign
    }
    return diff == 0
}
```

```CSharp
public class Solution {
    public bool IsBalanced(string num) {
        int diff = 0, sign = 1;
        foreach (char c in num) {
            int d = (int)Char.GetNumericValue(c);
            diff += d * sign;
            sign = -sign;
        }
        return diff == 0;
    }
}
```

```C
bool isBalanced(char* num) {
    int diff = 0, sign = 1;
    for (int i = 0; num[i] != '\0'; i++) {
        int d = num[i] - '0';
        diff += d * sign;
        sign = -sign;
    }
    return diff == 0;
}
```

```Rust
impl Solution {
    pub fn is_balanced(num: String) -> bool {
        let mut diff = 0;
        let mut sign = 1;
        for c in num.chars() {
            let d = c.to_digit(10).unwrap() as i32;
            diff += d * sign;
            sign = -sign;
        }
        diff == 0
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串的长度。
- 空间复杂度：$O(1)$。
