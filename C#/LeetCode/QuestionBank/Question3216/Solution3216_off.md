### [交换后字典序最小的字符串](https://leetcode.cn/problems/lexicographically-smallest-string-after-a-swap/solutions/2964922/jiao-huan-hou-zi-dian-xu-zui-xiao-de-zi-gngnj/)

#### 方法一：枚举

**思路与算法**

题目要求我们最多交换一次相邻字符，并且满足交换的两个字符所表示的数字奇偶性相同，使得最终得到的字符串字典序最小。

我们知道，若两个字符串长度相同，则拥有首个不同字符中较小那个的字符串字典序更小，因此我们在枚举相邻两个字符交换时需要尽早的交换，并且交换之前后面的字符要小于前面的字符。

**代码**

```C++
class Solution {
public:
    string getSmallestString(string s) {
        for (int i = 0; i + 1 < s.size(); i++) {
            if (s[i] > s[i + 1] && s[i] % 2 == s[i + 1] % 2) {
                swap(s[i], s[i + 1]);
                break;
            }
        }
        return s;
    }
};
```

```Java
class Solution {
    public String getSmallestString(String s) {
        char[] arr = s.toCharArray();
        for (int i = 0; i + 1 < arr.length; i++) {
            if (arr[i] > arr[i + 1] && arr[i] % 2 == arr[i + 1] % 2) {
                char temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
                break;
            }
        }
        return new String(arr);
    }
}
```

```CSharp
public class Solution {
    public string GetSmallestString(string s) {
        char[] arr = s.ToCharArray();
        for (int i = 0; i + 1 < arr.Length; i++) {
            if (arr[i] > arr[i + 1] && arr[i] % 2 == arr[i + 1] % 2) {
                char temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
                break;
            }
        }
        return new string(arr);
    }
}
```

```Python
class Solution:
    def getSmallestString(self, s: str) -> str:
        s = list(s)
        for i in range(0, len(s) - 1):
            if s[i] > s[i + 1] and ord(s[i]) % 2 == ord(s[i + 1]) % 2:
                s[i], s[i + 1] = s[i + 1], s[i]
                break
        return ''.join(s)
```

```C
char* getSmallestString(char* s) {
    int len = strlen(s);
    for (int i = 0; i + 1 < len; i++) {
        // 如果相邻字符满足条件，交换它们的位置
        if (s[i] > s[i + 1] && (s[i] % 2 == s[i + 1] % 2)) {
            char tmp = s[i];
            s[i] = s[i + 1];
            s[i + 1] = tmp;
            break;
        }
    }
    return s;
}
```

```Go
func getSmallestString(s string) string {
    r := []rune(s)

    for i := 0; i+1 < len(r); i++ {
        if r[i] > r[i+1] && r[i]%2 == r[i+1]%2 {
            r[i], r[i+1] = r[i+1], r[i]
            break
        }
    }
    return string(r)
}
```

```JavaScript
var getSmallestString = function(s) {
    let arr = s.split('');
    for (let i = 0; i + 1 < arr.length; i++) {
        if (arr[i] > arr[i + 1] && arr[i].charCodeAt(0) % 2 === arr[i + 1].charCodeAt(0) % 2) {
            [arr[i], arr[i + 1]] = [arr[i + 1], arr[i]];
            break;
        }
    }
    return arr.join('');
};
```

```TypeScript
function getSmallestString(s: string): string {
    let arr: string[] = s.split('');
    for (let i = 0; i + 1 < arr.length; i++) {
        if (arr[i] > arr[i + 1] && arr[i].charCodeAt(0) % 2 === arr[i + 1].charCodeAt(0) % 2) {
            [arr[i], arr[i + 1]] = [arr[i + 1], arr[i]];
            break;
        }
    }
    return arr.join('');
};
```

```Rust
impl Solution {
    pub fn get_smallest_string(s: String) -> String {
        let mut arr: Vec<char> = s.chars().collect();
        for i in 0..arr.len() - 1 {
            if arr[i] > arr[i + 1] && (arr[i] as u32) % 2 == (arr[i + 1] as u32) % 2 {
                arr.swap(i, i + 1);
                break;
            }
        }
        arr.iter().collect()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $s$ 的长度。整个过程我们只遍历一次字符串，并且最多只交换一次相邻字符。
- 空间复杂度：$O(1)$。过程中只使用了若干个变量。对于字符串不可修改的类型，需要先转换成列表进行处理，此时空间复杂度为 $O(n)$。
