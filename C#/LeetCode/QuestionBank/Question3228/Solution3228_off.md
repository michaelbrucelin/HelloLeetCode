### [将 1 移动到末尾的最大操作次数](https://leetcode.cn/problems/maximum-number-of-operations-to-move-ones-to-the-end/solutions/3823801/jiang-1-yi-dong-dao-mo-wei-de-zui-da-cao-5myu/)

#### 方法一：贪心 + 计数

**思路及解法**

题目需要我们计算将所有 $1$ 移动到末尾的最大操作次数。首先，我们可以选取一个下一位字符为 $0$ 的 $1$，然后将这个 $1$ 向右移动，直到被下一个 $1$ 挡住或到达字符串末尾。

每个 $1$ 的相对位置不会改变，因此每个 $1$ 在最终得到的字符串中位置是确定的，而每一个 $1$ 在移动过程中被挡住的次数越多，对答案的贡献也就越多。

假设从右往左对每一个 $1$ 进行操作，那么每一个 $1$ 最多只需要操作一次就会抵达最终位置，这样不会有任何 $1$ 被挡住，因此我们要贪心的从左往右进行操作，这样可以使得每一个 $1$ 被挡住的次数更多，从而使得答案更大。

算法逻辑如下：

- 从左往右遍历字符串 $s$，对于每一段连续的 $0$，只在遇到这一段的第一个 $0$ 时，将之前的 $1$ 的数量加到答案中，这是因为之前的所有 $1$ 都需要进行一次操作。
- 如果当前字符为 $1$，则将 $1$ 的数量 $countOne$ 加 $1$，表示被挡住 $1$ 的数量加一。
- 遍历结束后，返回答案。

**代码**

```C++
class Solution {
public:
    int maxOperations(string s) {
        int countOne = 0;
        int ans = 0;
        for (int i = 0; i < s.length(); i++) {
            if (s[i] == '0') {
                while ((i + 1) < s.length() && s[i + 1] == '0') {
                    i++;
                }
                ans += countOne;
            } else {
                countOne++;
            }
        }
        return ans;
    }
};
```

```Java
public class Solution {
    public int maxOperations(String s) {
        int countOne = 0;
        int ans = 0;
        int i = 0;
        while (i < s.length()) {
            if (s.charAt(i) == '0') {
                while (i + 1 < s.length() && s.charAt(i + 1) == '0') {
                    i++;
                }
                ans += countOne;
            } else {
                countOne++;
            }
            i++;
        }
        return ans;
    }
}
```

```Python
class Solution:
    def maxOperations(self, s: str) -> int:
        count_one = 0
        ans = 0
        i = 0
        while i < len(s):
            if s[i] == "0":
                while i + 1 < len(s) and s[i + 1] == "0":
                    i += 1
                ans += count_one
            else:
                count_one += 1
            i += 1
        return ans
```

```CSharp
public class Solution {
    public int MaxOperations(string s) {
        int countOne = 0;
        int ans = 0;
        int i = 0;
        while (i < s.Length) {
            if (s[i] == '0') {
                while (i + 1 < s.Length && s[i + 1] == '0') {
                    i++;
                }
                ans += countOne;
            } else {
                countOne++;
            }
            i++;
        }
        return ans;
    }
}
```

```Go
func maxOperations(s string) int {
    countOne := 0
    ans := 0
    i := 0
    for i < len(s) {
        if s[i] == '0' {
            for i + 1 < len(s) && s[i + 1] == '0' {
                i++
            }
            ans += countOne
        } else {
            countOne++
        }
        i++
    }
    return ans
}
```

```C
int maxOperations(char* s) {
    int countOne = 0;
    int ans = 0;
    int i = 0;
    int len = strlen(s);
    
    while (i < len) {
        if (s[i] == '0') {
            while (i + 1 < len && s[i + 1] == '0') {
                i++;
            }
            ans += countOne;
        } else {
            countOne++;
        }
        i++;
    }
    return ans;
}
```

```JavaScript
var maxOperations = function(s) {
    let countOne = 0;
    let ans = 0;
    let i = 0;
    while (i < s.length) {
        if (s[i] === '0') {
            while (i + 1 < s.length && s[i + 1] === '0') {
                i++;
            }
            ans += countOne;
        } else {
            countOne++;
        }
        i++;
    }
    return ans;
};
```

```TypeScript
function maxOperations(s: string): number {
    let countOne: number = 0;
    let ans: number = 0;
    let i: number = 0;
    while (i < s.length) {
        if (s[i] === '0') {
            while (i + 1 < s.length && s[i + 1] === '0') {
                i++;
            }
            ans += countOne;
        } else {
            countOne++;
        }
        i++;
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn max_operations(s: String) -> i32 {
        let mut count_one = 0;
        let mut ans = 0;
        let mut i = 0;
        let chars: Vec<char> = s.chars().collect();
        let n = chars.len();
        
        while i < n {
            if chars[i] == '0' {
                while i + 1 < n && chars[i + 1] == '0' {
                    i += 1;
                }
                ans += count_one;
            } else {
                count_one += 1;
            }
            i += 1;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，遍历一遍字符串即可。
- 空间复杂度：$O(1)$，申请了常数个变量。
