### [长度为 n 的开心字符串中字典序第 k 小的字符串](https://leetcode.cn/problems/the-k-th-lexicographical-string-of-all-happy-strings-of-length-n/solutions/3912772/chang-du-wei-n-de-kai-xin-zi-fu-chuan-zh-sm0s/)

#### 方法一：数学

由题意可知，对于长度为 $n$ 的开心字符串，首个元素有三种填法，剩余的元素有两种填法，因此可能的开心字符串数量为 $3\times 2^{n-1}$。如果 $k>3\times 2^{n-1}$，那么直接返回空字符串。

对于字典序第 $k$ 小的字符串，我们从首个元素开始填字符，可选的字符依次为 $'a'$、$'b'$ 和 $'c'$，并且填完首个元素后，后续对应的开心字符串数量为 $2^{n-1}$。因此填 $'a'$ 为首个元素时，可能的开心字符串的字符序顺序在区间 $[1,2^{n-1}]$ 间，类似的可以分别得到填 $'b'$ 和 $'c'$ 为首个元素的情况，从而通过确定 $k$ 在哪个区间范围，决定填哪个字符。

类似于首个元素，非首个元素可选的字符需要从 $'a'$、$'b'$ 和 $'c'$ 中去除前一个元素对应的字符，然后决定填哪个字符。

```C++
class Solution {
public:
    string getHappyString(int n, int k) {
        vector<char> chs = {'a', 'b', 'c'};
        string res;
        if (k > 3 * (1 << (n - 1))) {
            return res;
        }
        for (int i = 0; i < n; i++) {
            int count = 1 << (n - i - 1);
            for (char c : chs) {
                if (!res.empty() && res.back() == c) {
                    continue;
                }
                if (k <= count) {
                    res.push_back(c);
                    break;
                }
                k -= count;
            }
        }
        return res;
    }
};
```

```Go
func getHappyString(n int, k int) string {
    chs := []byte{'a', 'b', 'c'}
    res := make([]byte, 0, n)
    if k > 3 * (1 << (n - 1)) {
        return string(res)
    }
    for i := 0; i < n; i++ {
        count := 1 << (n - i - 1)
        for _, c := range chs {
            if len(res) > 0 && res[len(res) - 1] == c {
                continue
            }
            if k <= count {
                res = append(res, c)
                break
            }
            k -= count
        }
    }
    return string(res)
}
```

```Python
class Solution:
    def getHappyString(self, n: int, k: int) -> str:
        chs = ['a', 'b', 'c']
        res = []
        if k > 3 * (1 << (n - 1)):
            return "".join(res)
        for i in range(n):
            if len(res) != i:
                break
            count = 1 << (n - i - 1)
            for c in chs:
                if res and res[-1] == c:
                    continue
                if k <= count:
                    res.append(c)
                    break
                k -= count
        return "".join(res)
```

```Java
class Solution {
    public String getHappyString(int n, int k) {
        char[] chs = {'a', 'b', 'c'};
        StringBuilder res = new StringBuilder();
        if (k > 3 * (1 << (n - 1))) {
            return res.toString();
        }
        for (int i = 0; i < n; i++) {
            int count = 1 << (n - i - 1);
            for (char c : chs) {
                if (res.length() > 0 && res.charAt(res.length() - 1) == c) {
                    continue;
                }
                if (k <= count) {
                    res.append(c);
                    break;
                }
                k -= count;
            }
        }
        return res.toString();
    }
}
```

```TypeScript
function getHappyString(n: number, k: number): string {
    const chs: string[] = ['a', 'b', 'c'];
    const res: string[] = [];
    if (k > 3 * (1 << (n - 1))) {
        return res.join("");
    }
    for (let i = 0; i < n; i++) {
        let count = 1 << (n - i - 1);
        for (const c of chs) {
            if (res.length > 0 && res[res.length - 1] === c) {
                continue;
            }
            if (k <= count) {
                res.push(c);
                break;
            }
            k -= count;
        }
    }
    return res.join("");
}
```

```JavaScript
var getHappyString = function(n, k) {
    const chs = ['a', 'b', 'c'];
    let res = [];
    if (k > 3 * (1 << (n - 1))) {
        return res.join("");
    }
    for (let i = 0; i < n; i++) {
        let count = 1 << (n - i - 1);
        for (let c of chs) {
            if (res.length > 0 && res[res.length - 1] === c) {
                continue;
            }
            if (k <= count) {
                res.push(c);
                break;
            }
            k -= count;
        }
    }
    return res.join("");
};
```

```CSharp
public class Solution {
    public string GetHappyString(int n, int k) {
        char[] chs = { 'a', 'b', 'c' };
        StringBuilder res = new StringBuilder();
        if (k > 3 * (1 << (n - 1))) {
            return res.ToString();
        }
        for (int i = 0; i < n; i++) {
            int count = 1 << (n - i - 1);
            foreach (char c in chs) {
                if (res.Length > 0 && res[res.Length - 1] == c) {
                    continue;
                }
                if (k <= count) {
                    res.Append(c);
                    break;
                }
                k -= count;
            }
        }
        return res.ToString();
    }
}
```

```C
char* getHappyString(int n, int k) {
    char chs[3] = {'a', 'b', 'c'};
    char* res = (char*)malloc(n + 1);
    memset(res, 0, n + 1);
    if (k > 3 * (1 << (n - 1))) {
        return res;
    }
    for (int i = 0, len = 0; i < n; i++) {
        int count = 1 << (n - i - 1);
        for (int j = 0; j < 3; j++) {
            char c = chs[j];
            if (len > 0 && res[len - 1] == c) {
                continue;
            }
            if (k <= count) {
                res[len++] = c;
                break;
            }
            k -= count;
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn get_happy_string(n: i32, mut k: i32) -> String {
        let chs = ['a', 'b', 'c'];
        let mut res = String::new();
        if k > 3 * (1 << (n - 1)) {
            return res;
        }
        for i in 0..n {
            if res.len() != i as usize {
                break;
            }
            let count = 1 << (n - i - 1);
            for &c in &chs {
                if !res.is_empty() && res.as_bytes()[res.len() - 1] as char == c {
                    continue;
                }
                if k <= count {
                    res.push(c);
                    break;
                }
                k -= count;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串的长度。
- 空间复杂度：$O(1)$。返回值不计入空间复杂度。
