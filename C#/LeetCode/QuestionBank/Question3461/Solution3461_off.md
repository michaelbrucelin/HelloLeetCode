### [判断操作后字符串中的数字是否相等 I](https://leetcode.cn/problems/check-if-digits-are-equal-in-string-after-operations-i/solutions/3801883/pan-duan-cao-zuo-hou-zi-fu-chuan-zhong-d-fc9u/)

#### 方法一：模拟

**思路及解法**

由于本题数据量很小，直接模拟题设操作即可。

由于每操作一次，字符串长度都会减一，且题目要求判断字符串最后剩下两个数字的异同，因此我们一共需要进行 $n-2$ 次操作，其中 $n$ 为字符串长度。

每次操作时，我们可以从字符串的头部开始，将相邻的两个数字（假设这里字符的位置为 $j$ 与 $j+1$）相加并模 $10$，然后将得到的数字存入第 $j$ 个位置即可，既不会影响当前操作的后续部分，同时也能为下一次操作准备好字符串。

**代码**

```C++
class Solution {
public:
    bool hasSameDigits(string s) {
        int n = s.length();
        for (int i = 1; i <= n - 2; i++) {
            for (int j = 0; j <= n - 1 - i; j++) {
                s[j] = ((s[j] - '0') + (s[j + 1] - '0')) % 10 + '0';
            }
        }
        return s[0] == s[1];
    }
};
```

```Java
public class Solution {
    public boolean hasSameDigits(String s) {
        int n = s.length();
        char[] sArray = s.toCharArray();
        for (int i = 1; i <= n - 2; i++) {
            for (int j = 0; j <= n - 1 - i; j++) {
                int digit1 = sArray[j] - '0';
                int digit2 = sArray[j + 1] - '0';
                sArray[j] = (char) (((digit1 + digit2) % 10) + '0');
            }
        }
        return sArray[0] == sArray[1];
    }
}
```

```Python
class Solution:
    def hasSameDigits(self, s: str) -> bool:
        n = len(s)
        s_list = list(s)
        for i in range(1, n - 1):
            for j in range(n - i):
                digit1 = ord(s_list[j]) - ord('0')
                digit2 = ord(s_list[j + 1]) - ord('0')
                s_list[j] = chr(((digit1 + digit2) % 10) + ord('0'))
        return s_list[0] == s_list[1]
```

```CSharp
public class Solution {
    public bool HasSameDigits(string s) {
        int n = s.Length;
        char[] arr = s.ToCharArray();
        for (int i = 1; i <= n - 2; i++) {
            for (int j = 0; j <= n - 1 - i; j++) {
                arr[j] = (char)(((arr[j] - '0') + (arr[j + 1] - '0')) % 10 + '0');
            }
        }
        return arr[0] == arr[1];
    }
}
```

```Go
func hasSameDigits(s string) bool {
    n := len(s)
    arr := []byte(s)
    for i := 1; i <= n - 2; i++ {
        for j := 0; j <= n - 1 - i; j++ {
            arr[j] = byte(((int(arr[j] - '0') + int(arr[j + 1] - '0')) % 10) + '0')
        }
    }
    return arr[0] == arr[1]
}
```

```C
bool hasSameDigits(char* s) {
    int n = strlen(s);
    char* arr = strdup(s);
    for (int i = 1; i <= n - 2; i++) {
        for (int j = 0; j <= n - 1 - i; j++) {
            arr[j] = ((arr[j] - '0') + (arr[j + 1] - '0')) % 10 + '0';
        }
    }
    bool res = arr[0] == arr[1];
    free(arr);
    return res;
}
```

```JavaScript
var hasSameDigits = function(s) {
    let n = s.length;
    let arr = s.split('');
    for (let i = 1; i <= n - 2; i++) {
        for (let j = 0; j <= n - 1 - i; j++) {
            arr[j] = String((parseInt(arr[j]) + parseInt(arr[j + 1])) % 10);
        }
    }
    return arr[0] === arr[1];
};
```

```TypeScript
function hasSameDigits(s: string): boolean {
    let n = s.length;
    let arr: string[] = s.split('');
    
    for (let i = 1; i <= n - 2; i++) {
        for (let j = 0; j <= n - 1 - i; j++) {
            arr[j] = String((parseInt(arr[j]) + parseInt(arr[j + 1])) % 10);
        }
    }
    return arr[0] === arr[1];
};
```

```Rust
impl Solution {
    pub fn has_same_digits(s: String) -> bool {
        let n = s.len();
        let mut arr: Vec<u8> = s.bytes().collect();
        
        for i in 1..= n - 2 {
            for j in 0..= n - 1 - i {
                let digit1 = (arr[j] - b'0') as u8;
                let digit2 = (arr[j + 1] - b'0') as u8;
                arr[j] = ((digit1 + digit2) % 10) + b'0';
            }
        }
        arr[0] == arr[1]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，一共需要进行 $n-2$ 次操作，每次操作平均时间复杂度为 $O(n)$，因此总体时间复杂度为 $O(n^2)$。
- 空间复杂度：$O(1)$，并未使用额外存储空间。
