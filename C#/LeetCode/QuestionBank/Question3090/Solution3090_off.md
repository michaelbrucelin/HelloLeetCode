### [每个字符最多出现两次的最长子字符串](https://leetcode.cn/problems/maximum-length-substring-with-two-occurrences/solutions/4007024/mei-ge-zi-fu-zui-duo-chu-xian-liang-ci-d-a8qs/)

#### 方法一：枚举左端点

**思路与算法**

我们可以枚举所有的子字符串，然后判断每个子字符串所包含的相同字符的次数是否超过 $2$，对于不超过 $2$ 的子字符串，找到其中长度最长的作为答案。

具体的，可以枚举子字符串的左端点 $left$，然后不断向右扩展右端点 $right$。在扩展过程中，使用一个计数数组记录当前子字符串中每个字符出现的次数：

- 如果加入 $s[right]$ 后，该字符出现次数不超过 $2$，说明当前子字符串仍然合法；
- 如果某个字符出现次数变成了 $3$，说明当前子字符串已经不合法。

由于继续向右扩展并不会让这个字符的出现次数减少，因此可以直接结束当前左端点的枚举。

**代码**

```C++
class Solution {
public:
    int maximumLengthSubstring(string s) {
        int n = s.size();
        int res = 0;
        for (int left = 0; left < n; ++left) {
            array<int, 26> count{};
            for (int right = left; right < n; ++right) {
                const int index = s[right] - 'a';
                ++count[index];
                if (count[index] > 2) {
                    break;
                }
                res = max(res, right - left + 1);
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def maximumLengthSubstring(self, s: str) -> int:
        n = len(s)
        res = 0
        for left in range(n):
            count = [0] * 26
            for right in range(left, n):
                ch = ord(s[right]) - ord("a")
                count[ch] += 1
                if count[ch] > 2:
                    break
                res = max(res, right - left + 1)
        return res
```

```Rust
impl Solution {
    pub fn maximum_length_substring(s: String) -> i32 {
        let bytes = s.as_bytes();
        let n = bytes.len();
        let mut res = 0usize;
        for left in 0..n {
            let mut count = [0usize; 26];
            for right in left..n {
                let ch = (bytes[right] - b'a') as usize;
                count[ch] += 1;
                if count[ch] > 2 {
                    break;
                }
                res = res.max(right - left + 1);
            }
        }
        res as i32
    }
}
```

```Java
class Solution {
    public int maximumLengthSubstring(String s) {
        int n = s.length();
        int res = 0;
        for (int left = 0; left < n; left++) {
            int[] count = new int[26];
            for (int right = left; right < n; right++) {
                int ch = s.charAt(right) - 'a';
                count[ch]++;
                if (count[ch] > 2) {
                    break;
                }
                res = Math.max(res, right - left + 1);
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int MaximumLengthSubstring(string s) {
        int n = s.Length;
        int res = 0;
        for (int left = 0; left < n; left++) {
            int[] count = new int[26];
            for (int right = left; right < n; right++) {
                int ch = s[right] - 'a';
                count[ch]++;
                if (count[ch] > 2) {
                    break;
                }
                res = Math.Max(res, right - left + 1);
            }
        }
        return res;
    }
}
```

```Go
func maximumLengthSubstring(s string) int {
    n := len(s)
    res := 0
    for left := 0; left < n; left++ {
        count := make([]int, 26)
        for right := left; right < n; right++ {
            ch := s[right] - 'a'
            count[ch]++
            if count[ch] > 2 {
                break
            }
            length := right - left + 1
            if length > res {
                res = length
            }
        }
    }
    return res
}
```

```C
int maximumLengthSubstring(char* s) {
    int n = strlen(s);
    int res = 0;
    for (int left = 0; left < n; left++) {
        int count[26] = {0};
        for (int right = left; right < n; right++) {
            int ch = s[right] - 'a';
            count[ch]++;
            if (count[ch] > 2) {
                break;
            }
            int length = right - left + 1;
            if (length > res) {
                res = length;
            }
        }
    }
    return res;
}
```

```JavaScript
var maximumLengthSubstring = function(s) {
    const n = s.length;
    let res = 0;
    for (let left = 0; left < n; left++) {
        const count = new Array(26).fill(0);
        for (let right = left; right < n; right++) {
            const ch = s.charCodeAt(right) - 97;
            count[ch]++;
            if (count[ch] > 2) {
                break;
            }
            res = Math.max(res, right - left + 1);
        }
    }
    return res;
};
```

```TypeScript
function maximumLengthSubstring(s: string): number {
    const n: number = s.length;
    let res: number = 0;
    for (let left = 0; left < n; left++) {
        const count: number[] = new Array(26).fill(0);
        for (let right = left; right < n; right++) {
            const ch: number = s.charCodeAt(right) - 97;
            count[ch]++;
            if (count[ch] > 2) {
                break;
            }
            res = Math.max(res, right - left + 1);
        }
    }
    return res;
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是 $s$ 的长度。
- 空间复杂度：$O(1)$。过程中使用了常数个变量。

#### 方法二: 滑动窗口

**思路与算法**

在方法一中，不同左端点对应的子字符串存在大量重复计算。例如，在统计完 $s[left...right]$ 后，将左端点移动到 $left+1$ 时，没有必要重新统计整个区间。我们只需要：

1. 删除窗口最左侧的字符；
2. 更新对应字符的出现次数；
3. 继续向右扩展窗口。

因此，可以使用滑动窗口维护一个始终满足条件的区间：$[left,right]$。右端点 $right$ 不断向右移动，并将新字符加入窗口。如果新加入的字符在窗口中出现了三次，则移动左端点 $left$，直到该字符的出现次数重新变为 $2$。

**代码**

```C++
class Solution {
public:
    int maximumLengthSubstring(string s) {
        array<int, 26> count{};
        int left = 0;
        int res = 0;
        for (int right = 0; right < s.length(); ++right) {
            int ch = s[right] - 'a';
            ++count[ch];
            while (count[ch] > 2) {
                const int ch2 = s[left] - 'a';
                --count[ch2];
                ++left;
            }
            res = max(res, right - left + 1);
        }
        return res;
    }
};
```

```Python
class Solution:
    def maximumLengthSubstring(self, s: str) -> int:
        count = [0] * 26
        left = 0
        res = 0
        for right, c in enumerate(s):
            ch = ord(c) - ord("a")
            count[ch] += 1
            while count[ch] > 2:
                ch2 = ord(s[left]) - ord("a")
                count[ch2] -= 1
                left += 1
            res = max(res, right - left + 1)
        return res
```

```Rust
impl Solution {
    pub fn maximum_length_substring(s: String) -> i32 {
        let bytes = s.as_bytes();
        let mut count = [0usize; 26];
        let mut left = 0usize;
        let mut res = 0usize;

        for right in 0..bytes.len() {
            let ch = (bytes[right] - b'a') as usize;
            count[ch] += 1;

            while count[ch] > 2 {
                let ch2 = (bytes[left] - b'a') as usize;
                count[ch2] -= 1;
                left += 1;
            }

            res = res.max(right - left + 1);
        }

        res as i32
    }
}
```

```Java
class Solution {
    public int maximumLengthSubstring(String s) {
        int[] count = new int[26];
        int left = 0;
        int res = 0;
        for (int right = 0; right < s.length(); right++) {
            int ch = s.charAt(right) - 'a';
            count[ch]++;
            while (count[ch] > 2) {
                int ch2 = s.charAt(left) - 'a';
                count[ch2]--;
                left++;
            }
            res = Math.max(res, right - left + 1);
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int MaximumLengthSubstring(string s) {
        int[] count = new int[26];
        int left = 0;
        int res = 0;
        for (int right = 0; right < s.Length; right++) {
            int ch = s[right] - 'a';
            count[ch]++;
            while (count[ch] > 2) {
                int ch2 = s[left] - 'a';
                count[ch2]--;
                left++;
            }
            res = Math.Max(res, right - left + 1);
        }
        return res;
    }
}
```

```Go
func maximumLengthSubstring(s string) int {
    count := make([]int, 26)
    left := 0
    res := 0
    for right := 0; right < len(s); right++ {
        ch := s[right] - 'a'
        count[ch]++
        for count[ch] > 2 {
            ch2 := s[left] - 'a'
            count[ch2]--
            left++
        }
        length := right - left + 1
        if length > res {
            res = length
        }
    }
    return res
}
```

```C
int maximumLengthSubstring(char* s) {
    int count[26] = {0};
    int left = 0;
    int res = 0;
    int n = strlen(s);

    for (int right = 0; right < n; right++) {
        int ch = s[right] - 'a';
        count[ch]++;
        while (count[ch] > 2) {
            int ch2 = s[left] - 'a';
            count[ch2]--;
            left++;
        }
        int length = right - left + 1;
        if (length > res) {
            res = length;
        }
    }
    return res;
}
```

```JavaScript
var maximumLengthSubstring = function(s) {
    const count = new Array(26).fill(0);
    let left = 0;
    let res = 0;

    for (let right = 0; right < s.length; right++) {
        const ch = s.charCodeAt(right) - 97;
        count[ch]++;

        while (count[ch] > 2) {
            const ch2 = s.charCodeAt(left) - 97;
            count[ch2]--;
            left++;
        }

        res = Math.max(res, right - left + 1);
    }
    return res;
};
```

```TypeScript
function maximumLengthSubstring(s: string): number {
    const count: number[] = new Array(26).fill(0);
    let left: number = 0;
    let res: number = 0;

    for (let right = 0; right < s.length; right++) {
        const ch: number = s.charCodeAt(right) - 97;
        count[ch]++;

        while (count[ch] > 2) {
            const ch2: number = s.charCodeAt(left) - 97;
            count[ch2]--;
            left++;
        }

        res = Math.max(res, right - left + 1);
    }
    return res;
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $s$ 的长度。由于每个字符最多被加入窗口一次、移出窗口一次，因此总体时间复杂度为 $O(n)$。
- 空间复杂度：$O(1)$。过程中使用了常数个变量。
