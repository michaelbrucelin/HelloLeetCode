### [将一个字符串排序的最小操作次数](https://leetcode.cn/problems/minimum-operations-to-sort-a-string/solutions/4039941/jiang-yi-ge-zi-fu-chuan-pai-xu-de-zui-xi-kllb/)

#### 方法一：分类讨论

**思路与算法**

首先分析题目条件：

- 可以对 $s$ 的任意子串（不能是整个字符串）进行非降序排序，一次排序算作一次操作。
- 求将 $s$ 整体按照非降序排序所需的最小操作次数，如果无法做到则返回 $-1$。

我们对可能出现的情况进行如下分类：

1. $s$ 初始已经按照非降序排序，不需要进行任何操作，返回 $0$。
2. $s$ 的长度为 $2$ 并且没有按照非降序排序，我们无法通过操作改变 $s$，返回 $-1$。
3. $s$ 的首字符为 $s$ 中最小的字符
    1. 由于首字符已经在正确的位置上了，我们将子串 $s[1\dots n-1]$ 进行操作即可将 $s$ 排好序，总共需要一次操作。
    2. 反过来，$s$ 的尾字符为 $s$ 中最大的字符时也能够等效于上述情况，总共需要一次操作。
4. $s$ 中最大的字符仅出现在首字符上并且 $s$ 中最小的字符仅出现在最后一个字符
    1. 我们可以将子串 $s[0\dots n-2]$ 排好序，这样最大的字符就来到 $n-2$ 的位置上了。
    2. 然后再将子串 $s[n-2,n-1]$ 排序，这样最大的字符就在 $s$ 的尾字符上了，处于正确的位置，等效于情况 $3$。
    3. 总共需要三次操作。
5. 其他情况下
    1. 只需要将子串 $s[1\dots n-1]$ 排序，就一定能转化为情况 $3$。
    2. 总共需要两次操作。

```C++
class Solution {
public:
    int minOperations(string s) {
        char mx = 'a', mn = 'z';
        int n = s.length();
        for (int i = 0; i < n; i++) {
            mx = max(mx, s[i]);
            mn = min(mn, s[i]);
        }
        if (ranges::is_sorted(s)) {
            return 0;
        }
        if (n == 2) {
            return -1;
        }
        if (s[0] == mn || s[n - 1] == mx) {
            return 1;
        }
        for (int i = 1; i < n - 1; i++) {
            if (s[i] == mn || s[i] == mx) {
                return 2;
            }
        }
        return 3;
    }
};
```

```Go
func minOperations(s string) int {
    n := len(s)
    mx, mn := byte('a'), byte('z')
    sorted := true
    for i := 0; i < n; i++ {
        if s[i] > mx {
            mx = s[i]
        }
        if s[i] < mn {
            mn = s[i]
        }
        if i > 0 && s[i-1] > s[i] {
            sorted = false
        }
    }
    if sorted {
        return 0
    }
    if n == 2 {
        return -1
    }
    if s[0] == mn || s[n-1] == mx {
        return 1
    }
    for i := 1; i < n-1; i++ {
        if s[i] == mn || s[i] == mx {
            return 2
        }
    }
    return 3
}
```

```Python
class Solution:
    def minOperations(self, s: str) -> int:
        n = len(s)
        mx, mn = max(s), min(s)
        if all(a <= b for a, b in zip(s, s[1:])):
            return 0
        if n == 2:
            return -1
        if s[0] == mn or s[-1] == mx:
            return 1
        for i in range(1, n - 1):
            if s[i] == mn or s[i] == mx:
                return 2
        return 3
```

```Java
class Solution {
    public int minOperations(String s) {
        int n = s.length();
        char mx = 'a', mn = 'z';
        boolean sorted = true;
        for (int i = 0; i < n; i++) {
            mx = (char) Math.max(mx, s.charAt(i));
            mn = (char) Math.min(mn, s.charAt(i));
            if (i > 0 && s.charAt(i - 1) > s.charAt(i)) {
                sorted = false;
            }
        }
        if (sorted) {
            return 0;
        }
        if (n == 2) {
            return -1;
        }
        if (s.charAt(0) == mn || s.charAt(n - 1) == mx) {
            return 1;
        }
        for (int i = 1; i < n - 1; i++) {
            if (s.charAt(i) == mn || s.charAt(i) == mx) {
                return 2;
            }
        }
        return 3;
    }
}
```

```CSharp
public class Solution {
    public int MinOperations(string s) {
        int n = s.Length;
        char mx = 'a', mn = 'z';
        bool sorted = true;
        for (int i = 0; i < n; i++) {
            if (s[i] > mx) {
                mx = s[i];
            }
            if (s[i] < mn) {
                mn = s[i];
            }
            if (i > 0 && s[i - 1] > s[i]) {
                sorted = false;
            }
        }
        if (sorted) {
            return 0;
        }
        if (n == 2) {
            return -1;
        }
        if (s[0] == mn || s[n - 1] == mx) {
            return 1;
        }
        for (int i = 1; i < n - 1; i++) {
            if (s[i] == mn || s[i] == mx) {
                return 2;
            }
        }
        return 3;
    }
}
```

```C
int minOperations(char *s) {
    int n = strlen(s);
    char mx = 'a', mn = 'z';
    int sorted = 1;
    for (int i = 0; i < n; i++) {
        if (s[i] > mx) {
            mx = s[i];
        }
        if (s[i] < mn) {
            mn = s[i];
        }
        if (i > 0 && s[i - 1] > s[i]) {
            sorted = 0;
        }
    }
    if (sorted) {
        return 0;
    }
    if (n == 2) {
        return -1;
    }
    if (s[0] == mn || s[n - 1] == mx) {
        return 1;
    }
    for (int i = 1; i < n - 1; i++) {
        if (s[i] == mn || s[i] == mx) {
            return 2;
        }
    }
    return 3;
}
```

```JavaScript
var minOperations = function(s) {
    const n = s.length;
    let mx = 'a', mn = 'z';
    let sorted = true;
    for (let i = 0; i < n; i++) {
        if (s[i] > mx) {
            mx = s[i];
        }
        if (s[i] < mn) {
            mn = s[i];
        }
        if (i > 0 && s[i - 1] > s[i]) {
            sorted = false;
        }
    }
    if (sorted) {
        return 0;
    }
    if (n === 2) {
        return -1;
    }
    if (s[0] === mn || s[n - 1] === mx) {
        return 1;
    }
    for (let i = 1; i < n - 1; i++) {
        if (s[i] === mn || s[i] === mx) {
            return 2;
        }
    }
    return 3;
};
```

```TypeScript
function minOperations(s: string): number {
    const n = s.length;
    let mx = 'a', mn = 'z';
    let sorted = true;
    for (let i = 0; i < n; i++) {
        if (s[i] > mx) {
            mx = s[i];
        }
        if (s[i] < mn) {
            mn = s[i];
        }
        if (i > 0 && s[i - 1] > s[i]) {
            sorted = false;
        }
    }
    if (sorted) {
        return 0;
    }
    if (n === 2) {
        return -1;
    }
    if (s[0] === mn || s[n - 1] === mx) {
        return 1;
    }
    for (let i = 1; i < n - 1; i++) {
        if (s[i] === mn || s[i] === mx) {
            return 2;
        }
    }
    return 3;
};
```

```Rust
impl Solution {
    pub fn min_operations(s: String) -> i32 {
        let s = s.as_bytes();
        let n = s.len();
        let (mut mx, mut mn) = (b'a', b'z');
        let mut sorted = true;
        for i in 0..n {
            mx = mx.max(s[i]);
            mn = mn.min(s[i]);
            if i > 0 && s[i - 1] > s[i] {
                sorted = false;
            }
        }
        if sorted {
            return 0;
        }
        if n == 2 {
            return -1;
        }
        if s[0] == mn || s[n - 1] == mx {
            return 1;
        }
        for i in 1..n - 1 {
            if s[i] == mn || s[i] == mx {
                return 2;
            }
        }
        3
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为字符串 $s$ 的长度。
- 空间复杂度：$O(1)$
