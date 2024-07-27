### [满足距离约束且字典序最小的字符串](https://leetcode.cn/problems/lexicographically-smallest-string-after-operations-with-constraint/solutions/2854183/man-zu-ju-chi-yue-shu-qie-zi-dian-xu-zui-8duu/)

#### 方法一：贪心算法

**思路与算法**

题意等价于如下描述：

- 我们可以对给定的字符串 $s$ 最多进行 $k$ 次操作；
- 每一次操作，可以选择 $s$ 中的一个字母，变为字典序中前一个或后一个字母。这里规定 $a$ 的前一个字母是 $z$；
- 求可以得到的字典序最小的字符串。

因此我们可以使用贪心算法：要想字典序最小，我们应当优先修改下标小的字符。因此，我们依次遍历 $s$ 中的每一个字符，对于字符 $s[i]$：

- 如果剩余的操作次数足够，我们就将 $s[i]$ 修改为 $a$。这里需要的操作次数为 $s[i]$ 与 $a$ 的距离以及 $s[i]$ 与 $z$ 的距离加一的较小值；
- 如果剩余的操作次数不够，那么我们使用所有的操作次数，将 $s[i]$ 修改得尽可能小，同时结束遍历。

**代码**

```C++
class Solution {
public:
    string getSmallestString(string s, int k) {
        for (int i = 0; i < s.size(); ++i) {
            int dis = min(s[i] - 'a', 'z' - s[i] + 1);
            if (dis <= k) {
                s[i] = 'a';
                k -= dis;
            }
            else {
                s[i] -= k;
                break;
            }
        }
        return s;
    }
}
```

```Java
class Solution {
    public String getSmallestString(String s, int k) {
        char[] ans = s.toCharArray();
        for (int i = 0; i < s.length(); ++i) {
            int dis = Math.min(s.charAt(i) - 'a', 'z' - s.charAt(i) + 1);
            if (dis <= k) {
                ans[i] = 'a';
                k -= dis;
            } else {
                ans[i] -= k;
                break;
            }
        }
        return new String(ans);
    }
}
```

```CSharp
public class Solution {
    public string GetSmallestString(string s, int k) {
        char[] ans = s.ToCharArray();
        for (int i = 0; i < s.Length; ++i) {
            int dis = Math.Min(s[i] - 'a', 'z' - s[i] + 1);
            if (dis <= k) {
                ans[i] = 'a';
                k -= dis;
            } else {
                ans[i] = (char) (ans[i] - k);
                break;
            }
        }
        return new string(ans);
    }
}
```

```Python
class Solution:
    def getSmallestString(self, s: str, k: int) -> str:
        ans = list(s)
        for i, ch in enumerate(s):
            dis = min(ord(s[i]) - ord('a'), ord('z') - ord(s[i]) + 1)
            if dis <= k:
                ans[i] = 'a'
                k -= dis
            else:
                ans[i] = chr(ord(ans[i]) - k)
                break
        return "".join(ans)
```

```C
char* getSmallestString(char* s, int k) {
    int len = strlen(s);
    for (int i = 0; i < len; ++i) {
        int dis = fmin(s[i] - 'a', 'z' - s[i] + 1);
        if (dis <= k) {
            s[i] = 'a';
            k -= dis;
        }
        else {
            s[i] -= k;
            break;
        }
    }
    return s;
}
```

```Go
func getSmallestString(s string, k int) string {
    runes := []rune(s)
    for i := 0; i < len(runes); i++ {
        dis := min(int(runes[i] - 'a'), int('z' - runes[i] + 1))
        if dis <= k {
            runes[i] = 'a'
            k -= dis
        } else {
            runes[i] = rune(int(runes[i]) - k)
            break
        }
    }
    return string(runes)
}
```

```JavaScript
var getSmallestString = function(s, k) {
    s = s.split('');
    for (let i = 0; i < s.length; ++i) {
        let dis = Math.min(s[i].charCodeAt(0) - 'a'.charCodeAt(0), 'z'.charCodeAt(0) - s[i].charCodeAt(0) + 1);
        if (dis <= k) {
            s[i] = 'a';
            k -= dis;
        } else {
            s[i] = String.fromCharCode(s[i].charCodeAt(0) - k);
            break;
        }
    }
    return s.join('');
};
```

```TypeScript
function getSmallestString(s: string, k: number): string {
    let arr = s.split('');
    for (let i = 0; i < arr.length; ++i) {
        let dis = Math.min(arr[i].charCodeAt(0) - 'a'.charCodeAt(0), 'z'.charCodeAt(0) - arr[i].charCodeAt(0) + 1);
        if (dis <= k) {
            arr[i] = 'a';
            k -= dis;
        } else {
            arr[i] = String.fromCharCode(arr[i].charCodeAt(0) - k);
            break;
        }
    }
    return arr.join('');
};
```

```Rust
impl Solution {
    pub fn get_smallest_string(s: String, k: i32) -> String {
        let mut k = k;
        let mut chars: Vec<char> = s.chars().collect();
        for i in 0..chars.len() {
            let dis = std::cmp::min((chars[i] as u8 - 'a' as u8) as i32, ('z' as u8 - chars[i] as u8 + 1) as i32);
            if dis <= k {
                chars[i] = 'a';
                k -= dis;
            } else {
                chars[i] = (chars[i] as u8 - k as u8) as char;
                break;
            }
        }
        chars.into_iter().collect()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。
- 空间复杂度：$O(n)$ 或 $O(1)$，取决于使用的语言是否有可修改的字符串类型。
