### [字符串中最大的 3 位相同数字](https://leetcode.cn/problems/largest-3-same-digit-number-in-string/solutions/1538493/zi-fu-chuan-zhong-zui-da-de-3-wei-xiang-isykz/)

#### 方法一：枚举

**思路与算法**

为了找到最大的优质整数，我们可以枚举字符串 $num$ 中所有长度为 $3$ 的子串，并记录符合要求且对应数值最大的子串。

具体地，我们用初值为空的字符串 $res$ 来维护数值最大的符合要求子串，同时从左至右遍历长度为 $3$ 子串的**起始下标** $i$，每遍历到一个新的下标 $i$，我们判断以子串 $num[i \dots i+2]$ 是否由相同的字符构成：如果是则该子串符合要求，我们将 $res$ 更新为 $res$ 和该子串的较大值（此处字符串字典序的大小关系与对应整数的大小关系一致）；如果不是则不进行任何操作。

最终，如果存在符合要求的子串，则 $res$ 即为对应数值最大的子串；如果不存在，则 $res$ 为空字符串。因此我们返回 $res$ 作为答案。

**代码**

```C++
class Solution {
public:
    string largestGoodInteger(string num) {
        int n = num.size();
        string res;
        for (int i = 0; i < n - 2; ++i) {
            if (num[i] == num[i+1] && num[i+1] == num[i+2]) {
                res = max(res, num.substr(i, 3));
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def largestGoodInteger(self, num: str) -> str:
        n = len(num)
        res = ""
        for i in range(n - 2):
            if num[i] == num[i+1] == num[i+2]:
                res = max(res, num[i:i+3])
        return res
```

```C
char* largestGoodInteger(char* num) {
    int n = strlen(num);
    char* res = NULL;
    for (int i = 0; i < n - 2; ++i) {
        if (num[i] == num[i + 1] && num[i + 1] == num[i + 2]) {
            if (res == NULL || strncmp(&num[i], res, 3) > 0) {
                res = &num[i];
            }
        }
    }
    char* res2 = (char *)malloc(4);
    memset(res2, 0, 4);
    if (res == NULL) {
        return res2;
    }
    strncpy(res2, res, 3);
    return res2;
}
```

```Go
func largestGoodInteger(num string) string {
    n := len(num)
    var res string
    for i := 0; i < n - 2; i++ {
        if num[i] == num[i + 1] && num[i + 1] == num[i + 2] {
            res = max(res, num[i : i + 3])
        }
    }
    return res
}
```

```Java
public class Solution {
    public String largestGoodInteger(String num) {
        int n = num.length();
        String res = "";
        for (int i = 0; i < n - 2; i++) {
            if (num.charAt(i) == num.charAt(i + 1) && num.charAt(i + 1) == num.charAt(i + 2)) {
                String current = num.substring(i, i + 3);
                if (res.compareTo(current) < 0) {
                    res = current;
                }
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public string LargestGoodInteger(string num) {
        int n = num.Length;
        string res = "";
        for (int i = 0; i < n - 2; i++) {
            if (num[i] == num[i + 1] && num[i + 1] == num[i + 2]) {
                string current = num.Substring(i, 3);
                if (string.Compare(current, res) > 0) {
                    res = current;
                }
            }
        }
        return res;
    }
}
```

```JavaScript
var largestGoodInteger = function(num) {
    let res = "";
    for (let i = 0; i < num.length - 2; i++) {
        if (num[i] === num[i + 1] && num[i + 1] === num[i + 2]) {
            let current = num.substring(i, i + 3);
            if (current > res) {
                res = current;
            }
        }
    }
    return res;
};
```

```TypeScript
function largestGoodInteger(num: string): string {
    let res = "";
    for (let i = 0; i < num.length - 2; i++) {
        if (num[i] === num[i + 1] && num[i + 1] === num[i + 2]) {
            let current = num.substring(i, i + 3);
            if (current > res) {
                res = current;
            }
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn largest_good_integer(num: String) -> String {
        let mut res = String::new();
        let n = num.len();
        for i in 0..n-2 {
            if num[i..i+1] == num[i+1..i+2] && num[i+1..i+2] == num[i+2..i+3] {
                let current = &num[i..i+3];
                if res.is_empty() || current > &res {
                    res = current.to_string();
                }
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $num$ 的长度。即为枚举所有长度为 $3$ 子串的时间复杂度。
- 空间复杂度：$O(1)$。
