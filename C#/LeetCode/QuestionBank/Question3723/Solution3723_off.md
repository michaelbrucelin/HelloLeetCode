### [最大化数字的平方和](https://leetcode.cn/problems/maximize-sum-of-squares-of-digits/solutions/4042246/zui-da-hua-shu-zi-de-ping-fang-he-by-lee-zdva/)

#### 方法一：贪心

**思路与算法**

恰好 $num$ 位的整数，数位和最大为 $9\times num$。若 $sum>9\times num$，则不存在这样的好整数，直接返回空字符串。

由于平方函数是凸函数，在数位总和固定的约束下，把数值尽量集中到少数数位上能获得更大的平方和。例如，$9^2$ 大于 $4^2+5^2$。因此，我们尽可能地在高数位填充 $9$，总共可以填充 $\Big\lfloor\dfrac{sum}{9}\Big\rfloor$ 个 $9$。如果 $sum\bmod 9>0$，那么再填充一个 $sum\bmod 9$。最后，剩余的位（如果有）都填充 $0$ 即可。

**代码**

```C++
class Solution {
public:
    string maxSumOfSquares(int num, int sum) {
        if (sum > 9 * num) {
            return "";
        }
        int r = sum % 9;
        string ans(sum / 9, '9');
        if (r > 0) {
            ans.push_back('0' + r);
        }
        ans.append(num - (int)ans.size(), '0');
        return ans;
    }
};
```

```Python
class Solution:
    def maxSumOfSquares(self, num: int, sum: int) -> str:
        if sum > 9 * num:
            return ""
        q, r = divmod(sum, 9)
        ans = "9" * q
        if r > 0:
            ans += str(r)
        ans += "0" * (num - len(ans))
        return ans
```

```Rust
impl Solution {
    pub fn max_sum_of_squares(num: i32, sum: i32) -> String {
        if sum > 9 * num {
            return String::new();
        }
        let q = sum / 9;
        let r = sum % 9;
        let mut ans = "9".repeat(q as usize);
        if r > 0 {
            ans.push((b'0' + r as u8) as char);
        }
        ans.push_str(&"0".repeat(num as usize - ans.len()));
        ans
    }
}
```

```Java
class Solution {
    public String maxSumOfSquares(int num, int sum) {
        if (sum > 9 * num) {
            return "";
        }
        int r = sum % 9;
        StringBuilder ans = new StringBuilder();
        int nines = sum / 9;
        for (int i = 0; i < nines; i++) {
            ans.append('9');
        }
        if (r > 0) {
            ans.append((char) ('0' + r));
        }
        int zeros = num - ans.length();
        for (int i = 0; i < zeros; i++) {
            ans.append('0');
        }
        return ans.toString();
    }
}
```

```CSharp
public class Solution {
    public string MaxSumOfSquares(int num, int sum) {
        if (sum > 9 * num) {
            return "";
        }
        int r = sum % 9;
        var ans = new System.Text.StringBuilder();
        ans.Append('9', sum / 9);
        if (r > 0) {
            ans.Append((char)('0' + r));
        }
        ans.Append('0', num - ans.Length);
        return ans.ToString();
    }
}
```

```Go
func maxSumOfSquares(num int, sum int) string {
    if sum > 9*num {
        return ""
    }
    r := sum % 9
    ans := make([]byte, 0, num)
    for i := 0; i < sum/9; i++ {
        ans = append(ans, '9')
    }
    if r > 0 {
        ans = append(ans, byte('0'+r))
    }
    zeros := num - len(ans)
    for i := 0; i < zeros; i++ {
        ans = append(ans, '0')
    }
    return string(ans)
}
```

```C
char* maxSumOfSquares(int num, int sum) {
    if (sum > 9 * num) {
        char* empty = (char*)malloc(1);
        empty[0] = '\0';
        return empty;
    }
    int r = sum % 9;
    char* ans = (char*)malloc(num + 1);
    int idx = 0;
    int nines = sum / 9;
    for (int i = 0; i < nines; i++) {
        ans[idx++] = '9';
    }
    if (r > 0) {
        ans[idx++] = '0' + r;
    }
    while (idx < num) {
        ans[idx++] = '0';
    }
    ans[idx] = '\0';
    return ans;
}
```

```JavaScript
var maxSumOfSquares = function(num, sum) {
    if (sum > 9 * num) {
        return "";
    }
    let r = sum % 9;
    let ans = '9'.repeat(Math.floor(sum / 9));
    if (r > 0) {
        ans += String.fromCharCode('0'.charCodeAt(0) + r);
    }
    ans += '0'.repeat(num - ans.length);
    return ans;
};
```

```TypeScript
function maxSumOfSquares(num: number, sum: number): string {
    if (sum > 9 * num) {
        return "";
    }
    const r = sum % 9;
    let ans = '9'.repeat(Math.floor(sum / 9));
    if (r > 0) {
        ans += String.fromCharCode('0'.charCodeAt(0) + r);
    }
    ans += '0'.repeat(num - ans.length);
    return ans;
};
```

**复杂度分析**

- 时间复杂度：$O(num)$，需要构造长度为 $num$ 的答案字符串。
- 空间复杂度：$O(1)$ 或者 $O(num)$。不考虑返回值的空间复杂度，部分语言（例如 $C$ 和 $C++$）为 $O(1)$，其他语言使用了中间变量，为 $O(num)$。
