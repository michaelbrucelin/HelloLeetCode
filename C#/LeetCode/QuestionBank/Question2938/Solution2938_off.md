### [区分黑球与白球](https://leetcode.cn/problems/separate-black-and-white-balls/solutions/2799043/qu-fen-hei-qiu-yu-bai-qiu-by-leetcode-so-f7jm/)

#### 方法一：贪心

**思路**

交换完后的最终状态一定是形如 $00001111$，那么遍历字符串的时候每碰到一个 $0$ 就贪心的将其往左交换直到它最终的位置。在遍历到这个 $0$ 时，因为它左边的 $0$ 已经都交换到最终位置了，所以它的左边是一串连续的 $1$，那么只要加上遍历时碰到 $1$ 的个数即可。

**代码**

```C++
class Solution {
public:
    long long minimumSteps(string s) {
        long long ans = 0;
        int sum = 0;
        for (int i = 0; i < s.size(); i++) {
            if (s[i] == '1') {
                sum++;
            } else {
                ans += sum;
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public long minimumSteps(String s) {
        long ans = 0;
        int sum = 0;
        for (int i = 0; i < s.length(); i++) {
            if (s.charAt(i) == '1') {
                sum++;
            } else {
                ans += sum;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public long MinimumSteps(string s) {
        long ans = 0;
        int sum = 0;
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '1') {
                sum++;
            } else {
                ans += sum;
            }
        }
        return ans;
    }
}
```

```Go
func minimumSteps(s string) int64 {
    ans := int64(0)
    sum := 0
    for i := 0; i < len(s); i++ {
        if s[i] == '1' {
            sum++
        } else {
        ans += int64(sum)
        }
    }
    return ans
}
```

```C
long long minimumSteps(char *s) {
    long long ans = 0;
    int sum = 0;
    for (int i = 0; i < strlen(s); i++) {
        if (s[i] == '1') {
            sum++;
        } else {
            ans += sum;
        }
    }
    return ans;
}
```

```Python
class Solution:
    def minimumSteps(self, s):
        ans, sum = 0, 0
        for i in range(len(s)):
            if s[i] == '1':
                sum += 1
            else:
                ans += sum
        return ans
```

```JavaScript
var minimumSteps = function(s) {
    var ans = 0;
    var sum = 0;
    for (var i = 0; i < s.length; i++) {
        if (s[i] === '1') {
            sum++;
        } else {
            ans += sum;
        }
    }
    return ans;
};
```

```TypeScript
function minimumSteps(s: string): number {
    let ans: number = 0;
    let sum: number = 0;
    for (let i: number = 0; i < s.length; i++) {
        if (s[i] === '1') {
            sum++;
        } else {
            ans += sum;
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn minimum_steps(s: String) -> i64 {
        let mut ans = 0i64;
        let mut sum = 0i64;
        for &item in s.chars().collect::<Vec<_>>().iter() {
            if item == '1' {
                sum += 1;
            } else {
                ans += sum;
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为字符串的长度。
- 空间复杂度：$O(1)$。
