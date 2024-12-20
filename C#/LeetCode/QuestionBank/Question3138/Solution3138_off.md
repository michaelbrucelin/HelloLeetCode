### [同位字符串连接的最小长度](https://leetcode.cn/problems/minimum-length-of-anagram-concatenation/solutions/3014840/tong-wei-zi-fu-chuan-lian-jie-de-zui-xia-74z1/)

#### 方法一：枚举

由题意可知，字符串 $t$ 的长度一定为字符串 $s$ 的长度 $n$ 的因数，因此我们可以从小到大枚举 $n$ 的因数作为 $t$ 的长度。令当前枚举的因数为 $i$，我们将字符串 $s$ 切分为若干个长度为 $i$ 的子字符串，用 $count_0$​ 统计前一子字符串的字符出现次数，用 $count_1$​ 统计后一子字符串的出现次数，如果 $count_0$​ 不等于 $count_1$​，那么说明 $i$ 不符合题意；否则说明所有子字符串的字符出现次数都相等，那么返回 $i$ 作为 $t$ 的最小可能长度。

```C++
class Solution {
public:
    int minAnagramLength(string s) {
        int n = s.size();
        auto check = [&](int m) -> bool {
            vector<int> count0(26);
            for (int j = 0; j < n; j += m) {
                vector<int> count1(26);
                for (int k = j; k < j + m; k++) {
                    count1[s[k] - 'a']++;
                }
                if (j > 0 && count0 != count1) {
                    return false;
                }
                count0.swap(count1);
            }
            return true;
        };
        for (int i = 1; i < n; i++) {
            if (n % i != 0) {
                continue;
            }
            if (check(i)) {
                return i;
            }
        }
        return n;
    }
};
```

```C
bool check(char *s, int m) {
    int n = strlen(s), count0[26] = {0};
    for (int j = 0; j < n; j += m) {
        int count1[26] = {0};
        for (int k = j; k < j + m; k++) {
            count1[s[k] - 'a']++;
        }
        if (j > 0 && memcmp(count0, count1, sizeof(int) * 26) != 0) {
            return false;
        }
        memcpy(count0, count1, sizeof(int) * 26);
    }
    return true;
}

int minAnagramLength(char *s) {
    int n = strlen(s);
    for (int i = 1; i < n; i++) {
        if (n % i != 0) {
            continue;
        }
        if(check(s, i)) {
            return i;
        }
    }
    return n;
}
```

```Go
func minAnagramLength(s string) int {
    n := len(s)
    check := func(m int) bool {
        var count0 [26]int
        for j := 0; j < n; j += m {
            var count1 [26]int
            for k := j; k < j + m; k++ {
                count1[s[k] - 'a']++
            }
            if j > 0 && count0 != count1 {
                return false
            }
            count0 = count1
        }
        return true
    }
    for i := 1; i < n; i++ {
        if n % i != 0 {
            continue
        }
        if check(i) {
            return i
        }
    }
    return n
}
```

```Python
class Solution:
    def minAnagramLength(self, s: str) -> int:
        n = len(s)
        def check(m: int) -> bool:
            for j in range(m, n, m):
                if Counter(s[:m]) != Counter(s[j:j+m]):
                    return False
            return True
        for i in range(1, n):
            if n % i != 0:
                continue
            if check(i):
                return i
        return n
```

```Java
class Solution {
    public int minAnagramLength(String s) {
        int n = s.length();
        for (int i = 1; i < n; i++) {
            if (n % i != 0) {
                continue;
            }
            if (check(s, i)) {
                return i;
            }
        }
        return n;
    }

    public boolean check(String s, int m) {
        int[] count0 = new int[26];
        for (int j = 0; j < s.length(); j += m) {
            int[] count1 = new int[26];
            for (int k = j; k < j + m; k++) {
                count1[s.charAt(k) - 'a']++;
            }
            if (j > 0 && !Arrays.equals(count0, count1)) {
                return false;
            }
            count0 = count1;
        }
        return true;
    }
}
```

```CSharp
public class Solution {
    public int MinAnagramLength(string s) {
        int n = s.Length;
        for (int i = 1; i < n; i++) {
            if (n % i != 0) {
                continue;
            }
            if (check(s, i)) {
                return i;
            }
        }
        return n;
    }

    public bool check(string s, int m) {
        int[] count0 = new int[26];
        for (int j = 0; j < s.Length; j += m) {
            int[] count1 = new int[26];
            for (int k = j; k < j + m; k++) {
                count1[s[k] - 'a']++;
            }
            if (j > 0 && !count0.SequenceEqual(count1)) {
                return false;
            }
            count0 = count1;
        }
        return true;
    }
}
```

```JavaScript
var check = function(s, m) {
    let count0 = new Array(26).fill(0);
    for (let j = 0; j < s.length; j += m) {
        let count1 = new Array(26).fill(0);
        for (let k = j; k < j + m; k++) {
            count1[s.charCodeAt(k) - 'a'.charCodeAt(0)]++;
        }
        if (j > 0 && !count0.every((val, index) => val === count1[index])) {
            return false;
        }
        count0 = count1.slice();
    }
    return true;
}

var minAnagramLength = function(s) {
    let n = s.length;
    for (let i = 1; i < n; i++) {
        if (n % i !== 0) {
            continue;
        }
        if (check(s, i)) {
            return i;
        }
    }
    return n;
}
```

```TypeScript
function minAnagramLength(s: string): number {
    let n = s.length;
    for (let i = 1; i < n; i++) {
        if (n % i !== 0) {
            continue;
        }
        if (check(s, i)) {
            return i;
        }
    }
    return n;
};

function check(s: string, m: number): boolean {
    let count0 = new Array(26).fill(0);
    for (let j = 0; j < s.length; j += m) {
        let count1 = new Array(26).fill(0);
        for (let k = j; k < j + m; k++) {
            count1[s.charCodeAt(k) - 'a'.charCodeAt(0)]++;
        }
        if (j > 0 && !count0.every((val, index) => val === count1[index])) {
            return false;
        }
        count0 = count1.slice();
    }
    return true;
};
```

```Rust
impl Solution {
    pub fn min_anagram_length(s: String) -> i32 {
        let n = s.len();
        let check = |m: usize| -> bool {
            let mut count0 = vec![0; 26];
            for j in (0..n).step_by(m) {
                let mut count1 = vec![0; 26];
                for k in j..j + m {
                    count1[s.as_bytes()[k] as usize - b'a' as usize] += 1;
                }
                if j > 0 && count0 != count1 {
                    return false;
                }
                count0 = count1;
            }
            true
        };
        for i in 1..n {
            if n % i != 0 {
                continue;
            }
            if check(i) {
                return i as i32;
            }
        }
        n as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \times T)$，其中 $n$ 是字符串 $s$ 的长度，$T$ 是 $n$ 的因数数目。
- 空间复杂度：$O(\vert \sum \vert)$，其中 $\vert \sum \vert = 26$ 表示字符集的大小。
