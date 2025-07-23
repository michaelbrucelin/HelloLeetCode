### [删除子字符串的最大得分](https://leetcode.cn/problems/maximum-score-from-removing-substrings/solutions/3731266/shan-chu-zi-zi-fu-chuan-de-zui-da-de-fen-0x3m/)

#### 方法一：贪心

**思路与算法**

为了使得分最大，我们应该先尽可能进行得分高的删除操作，再进行得分低的删除操作。

贪心策略的正确性说明如下：

每次删除操作都会使字符串中$‘a’$和$‘b’$的数量减少一个，且剩余字母的相对位置不变。不妨假设删除$“ab”$，考虑相邻的前后两个字母，可能有以下情况：

1. 前后两个字母相同，即操作前的字符串是$“aaba”$或$“babb”$，删除$“ab”$后会剩余两个相同字母，无法进行删除，因此在删除前后，总删除次数不变。
2. 前后的字母是$“ab”$，即操作前的字符串是$“aabb”$，则在删除$“ab”$后可以再进行一次删除，因此在删除前后，总删除次数不变。
3. 前后的字母是$“ba”$，即操作前的字符串是$“baba”$，则在删除$“ab”$后可以再进行一次删除，因此在删除前后，总删除次数不变。

综上，每次删除任意位置的$“ab”$或$“ba”$后，总删除次数都不变，因此应尽可能进行得分高的删除操作。

为了实现方便，不妨假设 $x\ge y$，此时需要尽可能多地删除 $“ab”$。而对于 $x<y$ 的情况，只需要将 $x$ 和 $y$ 对换，再将字符串中所有的$“a”$换成$“b”$，$“b”$换成$“a”$，就与前一种情况等价，进行的操作也就只需要一种即可。

我们在删除$“ab”$的同时，记录剩余的$“a”$和$“b”$的数量 $cntA$ 和 $cntB$。

- 如果当前字符为$“a”$，由于我们要尽可能多删除$“ab”$，所以此时不删除$“a”$，将 $cntA$ 递增。
- 如果当前字符为$“b”$
  - $cntA$ 不为 $0$，那么就可以用前面的$“a”$与当前字符组合后删去，得分 $x$
  - $cntA$ 为 $0$，此时无法将$“b”$删除，将 $cntB$ 递增。

按照如上策略，保证剩余的$“a”$都位于$“b”$后，因此删除剩余的$“ba”$，删除次数为 $min{cntA,cntB}$，得分 $y\cdot min{cntA,cntB}$。

**代码**

```C++
class Solution {
public:
    int maximumGain(string s, int x, int y) {
        if (x < y) {
            swap(x, y);
            for (int i = 0; i < s.size(); i++) {
                if (s[i] == 'a') {
                    s[i] = 'b';
                }
                else if (s[i] == 'b') {
                    s[i] = 'a';
                }
            }
        }
        int ans = 0;
        for (int i = 0; i < s.size(); i++) {
            int cntA = 0, cntB = 0;
            while (i < s.size() && (s[i] == 'a' || s[i] == 'b')) {
                if (s[i] == 'a') {
                    cntA++;
                } else {
                    if (cntA > 0) {
                        cntA--;
                        ans += x;
                    } else {
                        cntB++;
                    }
                }
                i++;
            }
            ans += min(cntA, cntB) * y;
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int maximumGain(String s, int x, int y) {
        if (x < y) {
            int temp = x;
            x = y;
            y = temp;
            s = s.replace('a', '\0').replace('b', 'a').replace('\0', 'b');
        }
        int ans = 0;
        for (int i = 0; i < s.length(); i++) {
            int cntA = 0, cntB = 0;
            while (i < s.length() && (s.charAt(i) == 'a' || s.charAt(i) == 'b')) {
                char c = s.charAt(i++);
                if (c == 'a'){
                    cntA++;
                }
                else {
                    if (cntA > 0) {
                        cntA--;
                        ans += x;
                    } else {
                        cntB++;
                    }
                }
            }
            ans += Math.min(cntA, cntB) * y;
        }
        return ans;
    }
}
```

```Python
class Solution:
    def maximumGain(self, s: str, x: int, y: int) -> int:
        if x < y:
            x, y = y, x
            s = "".join("b" if c == "a" else "a" if c == "b" else c for c in s)
        ans = i = 0
        while i < len(s):
            cntA = cntB = 0
            while i < len(s) and s[i] in "ab":
                if s[i] == "a":
                    cntA += 1
                else:
                    if cntA > 0:
                        cntA -= 1
                        ans += x
                    else:
                        cntB += 1
                i += 1
            i += 1
            ans += min(cntA, cntB) * y
        return ans

```

```CSharp
using System;

public class Solution {
    public int MaximumGain(string s, int x, int y) {
        if (x < y) {
            (x, y) = (y, x);
            char[] arr = s.ToCharArray();
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] == 'a') {
                    arr[i] = 'b';
                }
                else if (arr[i] == 'b') {
                    arr[i] = 'a';
                }
            }
            s = new string(arr);
        }

        int ans = 0;
        for (int i = 0; i < s.Length; i++) {
            int cntA = 0, cntB = 0;
            while (i < s.Length && (s[i] == 'a' || s[i] == 'b')) {
                if (s[i] == 'a') {
                    cntA++;
                }
                else {
                    if (cntA > 0) {
                        cntA--;
                        ans += x;
                    } else {
                        cntB++;
                    }
                }
                i++;
            }
            ans += Math.Min(cntA, cntB) * y;
        }
        return ans;
    }
}
```

```Go
func maximumGain(s string, x int, y int) int {
    if x < y {
        x, y = y, x
        s2 := []rune(s)
        for i := range s2 {
            if s2[i] == 'a' {
                s2[i] = 'b'
            } else if s2[i] == 'b' {
                s2[i] = 'a'
            }
        }
        s = string(s2)
    }

    ans := 0
    for i:=0; i < len(s); i++ {
        cntA, cntB := 0, 0
        for i < len(s) && (s[i] == 'a' || s[i] == 'b') {
            if s[i] == 'a' {
                cntA++
            } else {
                if cntA > 0 {
                    cntA--
                    ans += x
                } else {
                    cntB++
                }
            }
            i++
        }
        if cntA < cntB {
            ans += cntA * y
        } else {
            ans += cntB * y
        }
    }
    return ans
}
```

```C
int maximumGain(char* s, int x, int y) {
    if (x < y) {
        int tmp = x;
        x = y;
        y = tmp;
        for (int i = 0; s[i]; i++) {
            if (s[i] == 'a'){
                s[i] = 'b';
            }
            else if (s[i] == 'b'){
                s[i] = 'a';
            }
        }
    }

    int ans = 0;
    for (int i = 0; i < strlen(s); i++) {
        int cntA = 0, cntB = 0;
        while (s[i] && (s[i] == 'a' || s[i] == 'b')) {
            if (s[i] == 'a'){
                cntA++;
            }
            else {
                if (cntA > 0) {
                    cntA--;
                    ans += x;
                } else{
                    cntB++;
                }
            }
            i++;
        }
        ans += (cntA < cntB ? cntA : cntB) * y;
    }
    return ans;
}
```

```JavaScript
var maximumGain = function (s, x, y) {
    if (x < y) {
        [x, y] = [y, x];
        s = s.replace(/./g, c => c === 'a' ? 'b' : c === 'b' ? 'a' : c);
    }

    let ans = 0, i = 0;
    while (i < s.length) {
        let cntA = 0, cntB = 0;
        while (i < s.length && (s[i] === 'a' || s[i] === 'b')) {
            if (s[i] === 'a') {
                cntA++;
            }
            else {
                if (cntA > 0) {
                    cntA--;
                    ans += x;
                } else {
                    cntB++;
                }
            }
            i++;
        }
        ans += Math.min(cntA, cntB) * y;
        i++;
    }
    return ans;
};
```

```TypeScript
function maximumGain(s: string, x: number, y: number): number {
    if (x < y) {
        [x, y] = [y, x];
        s = [...s].map(c => c === 'a' ? 'b' : c === 'b' ? 'a' : c).join('');
    }

    let ans = 0, i = 0;
    while (i < s.length) {
        let cntA = 0, cntB = 0;
        while (i < s.length && (s[i] === 'a' || s[i] === 'b')) {
            if (s[i] === 'a') {
                cntA++;
            }
            else {
                if (cntA > 0) {
                    cntA--;
                    ans += x;
                } else {
                    cntB++;
                }
            }
            i++;
        }
        ans += Math.min(cntA, cntB) * y;
        i++;
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn maximum_gain(s: String, mut x: i32, mut y: i32) -> i32 {
        let mut chars: Vec<char> = s.chars().collect();
        if x < y {
            std::mem::swap(&mut x, &mut y);
            for c in chars.iter_mut() {
                if *c == 'a' {
                    *c = 'b';
                } else if *c == 'b' {
                    *c = 'a';
                }
            }
        }

        let mut ans = 0;
        let mut i = 0;
        while i < chars.len() {
            let mut cnt_a = 0;
            let mut cnt_b = 0;
            while i < chars.len() && (chars[i] == 'a' || chars[i] == 'b') {
                if chars[i] == 'a' {
                    cnt_a += 1;
                } else {
                    if cnt_a > 0 {
                        cnt_a -= 1;
                        ans += x;
                    } else {
                        cnt_b += 1;
                    }
                }
                i += 1;
            }
            ans += std::cmp::min(cnt_a, cnt_b) * y;
            i += 1;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。遍历一次字符串即可求解。
- 空间复杂度：$O(1)$。只需要若干额外变量。
