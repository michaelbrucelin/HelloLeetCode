### [执行操作后字典序最小的字符串](https://leetcode.cn/problems/lexicographically-smallest-string-after-applying-operations/solutions/2176373/zhi-xing-cao-zuo-hou-zi-dian-xu-zui-xiao-4jyr/)

#### 方法一：枚举

**思路与算法**

题目有两种操作：

1. 累加，将 $s$ 的奇数位元素加上 $a$，超过 $9$ 则回到 $0$ 继续加。
2. 轮转，将 $s$ 向右轮转 $b$ 位。

以上操作可以进行无限次，问可以得到的字典序最小的字符串。

注意到条件中 $s$ 的长度是偶数，因此如果 $b$ 是偶数，那么无论轮转多少次，我们都只能给 $s$ 中奇数位的元素做累加操作。但如果 $b$ 是奇数的话，我们可以给 $s$ 中奇数位和偶数位的元素都做加法，并且可以做不同的次数。

从以上可以看出，做累加操作的次数和做轮转操作的次数是互相独立的，做轮转的次数并不会影响到能否对偶数位进行累加。因此我们可以先枚举做轮转的次数，然后再枚举做累加的次数，从而找到字典序最小的答案。

更具体的，我们按照如下步骤进行枚举：

1. 枚举做轮转的次数，然后令 $t$ 为 $s$ 轮转后的字符串。由于轮转最终会产生循环，且至多轮转 $n$ 次（$n$ 为 $s$ 的长度），因此我们用一个数组 $vis$ 来记录每个位置是否被轮转过。如果遇到之前轮转过的位置，则枚举结束。
2. 对于每个 $t$，枚举对 $t$ 的奇数位做累加操作的次数 $j$，再枚举对 $t$ 的偶数位做累加操作的次数 $k$。这里因为元素值范围是 $[0,9]$，因此我们做累加操作的次数上限是 $9$，再多势必会产生循环。特殊的，如果 $b$ 是偶数，则 $k$ 的上限是 $0$，否则是 $9$。

**代码**

```C++
class Solution {
public:
    string findLexSmallestString(string s, int a, int b) {
        int n = s.size();
        vector<int> vis(n);
        string res = s;
        // 将 s 延长一倍，方便截取轮转后的字符串 t
        s = s + s;
        for (int i = 0; vis[i] == 0; i = (i + b) % n) {
            vis[i] = 1;
            for (int j = 0; j < 10; j++) {
                int k_limit = b % 2 == 0 ? 0 : 9;
                for (int k = 0; k <= k_limit; k++) {
                    // 每次进行累加之前，重新截取 t
                    string t = s.substr(i, n);
                    for (int p = 1; p < n; p += 2) {
                        t[p] = '0' + (t[p] - '0' + j * a) % 10;
                    }
                    for (int p = 0; p < n; p += 2) {
                        t[p] = '0' + (t[p] - '0' + k * a) % 10;
                    }
                    res = min(res, t);
                }
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public String findLexSmallestString(String s, int a, int b) {
        int n = s.length();
        boolean[] vis = new boolean[n];
        String res = s;
        // 将 s 延长一倍，方便截取轮转后的字符串 t
        s = s + s;
        for (int i = 0; !vis[i]; i = (i + b) % n) {
            vis[i] = true;
            for (int j = 0; j < 10; j++) {
                int kLimit = b % 2 == 0 ? 0 : 9;
                for (int k = 0; k <= kLimit; k++) {
                    // 每次进行累加之前，重新截取 t
                    char[] t = s.substring(i, i + n).toCharArray();
                    for (int p = 1; p < n; p += 2) {
                        t[p] = (char) ('0' + (t[p] - '0' + j * a) % 10);
                    }
                    for (int p = 0; p < n; p += 2) {
                        t[p] = (char) ('0' + (t[p] - '0' + k * a) % 10);
                    }
                    String tStr = new String(t);
                    if (tStr.compareTo(res) < 0) {
                        res = tStr;
                    }
                }
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public string FindLexSmallestString(string s, int a, int b) {
        int n = s.Length;
        bool[] vis = new bool[n];
        string res = s;
        // 将 s 延长一倍，方便截取轮转后的字符串 t
        s = s + s;
        for (int i = 0; !vis[i]; i = (i + b) % n) {
            vis[i] = true;
            for (int j = 0; j < 10; j++) {
                int kLimit = b % 2 == 0 ? 0 : 9;
                for (int k = 0; k <= kLimit; k++) {
                    // 每次进行累加之前，重新截取 t
                    char[] t = s.Substring(i, n).ToCharArray();
                    for (int p = 1; p < n; p += 2) {
                        t[p] = (char) ('0' + (t[p] - '0' + j * a) % 10);
                    }
                    for (int p = 0; p < n; p += 2) {
                        t[p] = (char) ('0' + (t[p] - '0' + k * a) % 10);
                    }
                    string tStr = new string(t);
                    if (tStr.CompareTo(res) < 0) {
                        res = tStr;
                    }
                }
            }
        }
        return res;
    }
}
```

```C
char * findLexSmallestString(char * s, int a, int b) {
    int n = strlen(s);
    int vis[n];
    memset(vis, 0, sizeof(vis));
    char *res = (char *)calloc(sizeof(char), n + 1);
    strcpy(res, s);
    // 将 s 延长一倍，方便截取轮转后的字符串 t
    char str[2 * n + 1];
    sprintf(str, "%s%s", s, s);
    for (int i = 0; vis[i] == 0; i = (i + b) % n) {
        vis[i] = 1;
        for (int j = 0; j < 10; j++) {
            int k_limit = b % 2 == 0 ? 0 : 9;
            for (int k = 0; k <= k_limit; k++) {
                // 每次进行累加之前，重新截取 t
                char t[n + 1];
                strncpy(t, str + i, n);
                t[n] = '\0';
                for (int p = 1; p < n; p += 2) {
                    t[p] = '0' + (t[p] - '0' + j * a) % 10;
                }
                for (int p = 0; p < n; p += 2) {
                    t[p] = '0' + (t[p] - '0' + k * a) % 10;
                }
                if (strcmp(t, res) < 0) {
                    strcpy(res, t);
                }
            }
        }
    }
    return res;
}
```

```JavaScript
var findLexSmallestString = function(s, a, b) {
    const n = s.length;
    const vis = new Array(n).fill(false);
    let res = s;
    // 将 s 延长一倍，方便截取轮转后的字符串 t
    s = s + s;
    for (let i = 0; !vis[i]; i = (i + b) % n) {
        vis[i] = true;
        for (let j = 0; j < 10; j++) {
            let kLimit = b % 2 === 0 ? 0 : 9;
            for (let k = 0; k <= kLimit; k++) {
                // 每次进行累加之前，重新截取 t
                const t = [...s.slice(i, i + n)];
                for (let p = 1; p < n; p += 2) {
                    t[p] = String.fromCharCode('0'.charCodeAt() + (t[p].charCodeAt() - '0'.charCodeAt() + j * a) % 10);
                }
                for (let p = 0; p < n; p += 2) {
                    t[p] = String.fromCharCode('0'.charCodeAt() + (t[p].charCodeAt() - '0'.charCodeAt() + k * a) % 10);
                }
                const tStr = t.join('');
                if (tStr < res) {
                    res = tStr;
                }
            }
        }
    }
    return res;
};
```

```Go
func findLexSmallestString(s string, a int, b int) string {
    n := len(s)
    vis := make([]bool, n)
    res := s
    // 将 s 延长一倍，方便截取轮转后的字符串 t
    s = s + s
    for i := 0; !vis[i]; i = (i + b) % n {
        vis[i] = true
        for j := 0; j < 10; j++ {
            kLimit := 0
            if b % 2 != 0 {
                kLimit = 9
            }
            for k := 0; k <= kLimit; k++ {
                // 每次进行累加之前，重新截取 t
                t := []byte(s[i : i+n])
                for p := 1; p < n; p += 2 {
                    t[p] = '0' + byte((int(t[p] - '0') + j * a) % 10)
                }
                for p := 0; p < n; p += 2 {
                    t[p] = '0' + byte((int(t[p] - '0') + k * a) % 10)
                }
                tStr := string(t)
                if tStr < res {
                    res = tStr
                }
            }
        }
    }
    return res
}
```

```Python
class Solution:
    def findLexSmallestString(self, s: str, a: int, b: int) -> str:
        n = len(s)
        vis = [False] * n
        res = s
        # 将 s 延长一倍，方便截取轮转后的字符串 t
        s = s + s
        i = 0
        while not vis[i]:
            vis[i] = True
            for j in range(10):
                k_limit = 0 if b % 2 == 0 else 9
                for k in range(k_limit + 1):
                    # 每次进行累加之前，重新截取 t
                    t = list(s[i:i + n])
                    for p in range(1, n, 2):
                        t[p] = str((int(t[p]) + j * a) % 10)
                    for p in range(0, n, 2):
                        t[p] = str((int(t[p]) + k * a) % 10)
                    t_str = ''.join(t)
                    if t_str < res:
                        res = t_str
            i = (i + b) % n
        return res
```

```TypeScript
function findLexSmallestString(s: string, a: number, b: number): string {
    const n = s.length;
    const vis = new Array(n).fill(false);
    let res = s;
    // 将 s 延长一倍，方便截取轮转后的字符串 t
    s = s + s;
    for (let i = 0; !vis[i]; i = (i + b) % n) {
        vis[i] = true;
        for (let j = 0; j < 10; j++) {
            let kLimit = b % 2 === 0 ? 0 : 9;
            for (let k = 0; k <= kLimit; k++) {
                // 每次进行累加之前，重新截取 t
                const t = [...s.slice(i, i + n)];
                for (let p = 1; p < n; p += 2) {
                    t[p] = String.fromCharCode('0'.charCodeAt(0) + (t[p].charCodeAt(0) - '0'.charCodeAt(0) + j * a) % 10);
                }
                for (let p = 0; p < n; p += 2) {
                    t[p] = String.fromCharCode('0'.charCodeAt(0) + (t[p].charCodeAt(0) - '0'.charCodeAt(0) + k * a) % 10);
                }
                const tStr = t.join('');
                if (tStr < res) {
                    res = tStr;
                }
            }
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn find_lex_smallest_string(s: String, a: i32, b: i32) -> String {
        let n = s.len();
        let mut vis = vec![false; n];
        let mut res = s.clone();
        // 将 s 延长一倍，方便截取轮转后的字符串 t
        let s = s.repeat(2);
        let mut i = 0;
        while !vis[i] {
            vis[i] = true;
            for j in 0..10 {
                let k_limit = if b % 2 == 0 { 0 } else { 9 };
                for k in 0..=k_limit {
                    // 每次进行累加之前，重新截取 t
                    let mut t: Vec<char> = s[i..i+n].chars().collect();
                    for p in (1..n).step_by(2) {
                        let digit = t[p].to_digit(10).unwrap() as i32;
                        t[p] = std::char::from_digit(((digit + j * a) % 10) as u32, 10).unwrap();
                    }
                    for p in (0..n).step_by(2) {
                        let digit = t[p].to_digit(10).unwrap() as i32;
                        t[p] = std::char::from_digit(((digit + k * a) % 10) as u32, 10).unwrap();
                    }
                    let t_str: String = t.into_iter().collect();
                    if t_str < res {
                        res = t_str;
                    }
                }
            }
            i = (i + b as usize) % n;
        }
        res
    }
}
```

枚举轮转次数过程中，我们依次考虑了如下位置：$0\times b(modn), 1\times b(modn), 2\times b(modn),\dots ,x\times b(modn)$。我们可以用一个表达式来计算最终到达的位置：

xb-yn=z

其中 $x$ 是轮转次数，$y$ 是取模过程减去 $n$ 的次数，而 $z$ 是最终到达的位置。

根据[裴蜀定理](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fmath%2Fnumber-theory%2Fbezouts%2F)可知 $z$ 一定是 $gcd(b,n)$ 的倍数，因此我们只需要枚举 $[0,n)$ 中 $gcd(b,n)$ 的倍数即可。

```C++
class Solution {
public:
    string findLexSmallestString(string s, int a, int b) {
        int n = s.size();
        string res = s;
        s = s + s;
        int g = gcd(b, n);
        for (int i = 0; i < n; i += g) {
            for (int j = 0; j < 10; j++) {
                int k_limit = b % 2 == 0 ? 0 : 9;
                for (int k = 0; k <= k_limit; k++) {
                    string t = s.substr(i, n);
                    for (int p = 1; p < n; p += 2) {
                        t[p] = '0' + (t[p] - '0' + j * a) % 10;
                    }
                    for (int p = 0; p < n; p += 2) {
                        t[p] = '0' + (t[p] - '0' + k * a) % 10;
                    }
                    res = min(res, t);
                }
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public String findLexSmallestString(String s, int a, int b) {
        int n = s.length();
        String res = s;
        s = s + s;
        int g = gcd(b, n);
        for (int i = 0; i < n; i += g) {
            for (int j = 0; j < 10; j++) {
                int kLimit = b % 2 == 0 ? 0 : 9;
                for (int k = 0; k <= kLimit; k++) {
                    char[] t = s.substring(i, i + n).toCharArray();
                    for (int p = 1; p < n; p += 2) {
                        t[p] = (char) ('0' + (t[p] - '0' + j * a) % 10);
                    }
                    for (int p = 0; p < n; p += 2) {
                        t[p] = (char) ('0' + (t[p] - '0' + k * a) % 10);
                    }
                    String tStr = new String(t);
                    if (tStr.compareTo(res) < 0) {
                        res = tStr;
                    }
                }
            }
        }
        return res;
    }

    public int gcd(int num1, int num2) {
        while (num2 != 0) {
            int temp = num1;
            num1 = num2;
            num2 = temp % num2;
        }
        return num1;
    }
}
```

```CSharp
public class Solution {
    public string FindLexSmallestString(string s, int a, int b) {
        int n = s.Length;
        string res = s;
        s = s + s;
        int g = GCD(b, n);
        for (int i = 0; i < n; i += g) {
            for (int j = 0; j < 10; j++) {
                int kLimit = b % 2 == 0 ? 0 : 9;
                for (int k = 0; k <= kLimit; k++) {
                    char[] t = s.Substring(i, n).ToCharArray();
                    for (int p = 1; p < n; p += 2) {
                        t[p] = (char) ('0' + (t[p] - '0' + j * a) % 10);
                    }
                    for (int p = 0; p < n; p += 2) {
                        t[p] = (char) ('0' + (t[p] - '0' + k * a) % 10);
                    }
                    string tStr = new string(t);
                    if (tStr.CompareTo(res) < 0) {
                        res = tStr;
                    }
                }
            }
        }
        return res;
    }

    public int GCD(int num1, int num2) {
        while (num2 != 0) {
            int temp = num1;
            num1 = num2;
            num2 = temp % num2;
        }
        return num1;
    }
}
```

```C
int gcd(int num1, int num2) {
    while (num2 != 0) {
        int temp = num1;
        num1 = num2;
        num2 = temp % num2;
    }
    return num1;
}

char * findLexSmallestString(char * s, int a, int b) {
    int n = strlen(s);
    int vis[n];
    memset(vis, 0, sizeof(vis));
    char *res = (char *)calloc(sizeof(char), n + 1);
    strcpy(res, s);
    // 将 s 延长一倍，方便截取轮转后的字符串 t
    char str[2 * n + 1];
    sprintf(str, "%s%s", s, s);
    int g = gcd(b, n);
    for (int i = 0; i < n; i += g) {
        vis[i] = 1;
        for (int j = 0; j < 10; j++) {
            int k_limit = b % 2 == 0 ? 0 : 9;
            for (int k = 0; k <= k_limit; k++) {
                // 每次进行累加之前，重新截取 t
                char t[n + 1];
                strncpy(t, str + i, n);
                t[n] = '\0';
                for (int p = 1; p < n; p += 2) {
                    t[p] = '0' + (t[p] - '0' + j * a) % 10;
                }
                for (int p = 0; p < n; p += 2) {
                    t[p] = '0' + (t[p] - '0' + k * a) % 10;
                }
                if (strcmp(t, res) < 0) {
                    strcpy(res, t);
                }
            }
        }
    }
    return res;
}
```

```JavaScript
var findLexSmallestString = function(s, a, b) {
    const n = s.length;
    let res = s;
    s = s + s;
    const g = gcd(b, n);
    for (let i = 0; i < n; i += g) {
        for (let j = 0; j < 10; j++) {
            const kLimit = b % 2 === 0 ? 0 : 9;
            for (let k = 0; k <= kLimit; k++) {
                const t = [...s.slice(i, i + n)];
                for (let p = 1; p < n; p += 2) {
                    t[p] = String.fromCharCode('0'.charCodeAt() + (t[p].charCodeAt() - '0'.charCodeAt() + j * a) % 10);
                }
                for (let p = 0; p < n; p += 2) {
                    t[p] = String.fromCharCode('0'.charCodeAt() + (t[p].charCodeAt() - '0'.charCodeAt() + k * a) % 10);
                }
                const tStr = t.join('');
                if (tStr < res) {
                    res = tStr;
                }
            }
        }
    }
    return res;
}

const gcd = (num1, num2) => {
    while (num2 !== 0) {
        const temp = num1;
        num1 = num2;
        num2 = temp % num2;
    }
    return num1;
};
```

```Go
func findLexSmallestString(s string, a int, b int) string {
    n := len(s)
    res := s
    s = s + s
    g := gcd(b, n)
    for i := 0; i < n; i += g {
        for j := 0; j < 10; j++ {
            kLimit := 0
            if b % 2 != 0 {
                kLimit = 9
            }
            for k := 0; k <= kLimit; k++ {
                t := []byte(s[i : i + n])
                for p := 1; p < n; p += 2 {
                    t[p] = byte('0' + (int(t[p] - '0') + j * a) % 10)
                }
                for p := 0; p < n; p += 2 {
                    t[p] = byte('0' + (int(t[p] - '0') + k * a) % 10)
                }
                tStr := string(t)
                if tStr < res {
                    res = tStr
                }
            }
        }
    }
    return res
}

func gcd(a, b int) int {
    for b != 0 {
        a, b = b, a % b
    }
    return a
}
```

```Python
class Solution:
    def findLexSmallestString(self, s: str, a: int, b: int) -> str:
        n = len(s)
        res = s
        s = s + s
        g = math.gcd(b, n)
        for i in range(0, n, g):
            for j in range(10):
                k_limit = 0 if b % 2 == 0 else 9
                for k in range(k_limit + 1):
                    t = list(s[i:i + n])
                    for p in range(1, n, 2):
                        t[p] = str((int(t[p]) + j * a) % 10)
                    for p in range(0, n, 2):
                        t[p] = str((int(t[p]) + k * a) % 10)
                    t_str = ''.join(t)
                    if t_str < res:
                        res = t_str
        return res
```

```TypeScript
function findLexSmallestString(s: string, a: number, b: number): string {
    const n = s.length;
    let res = s;
    s = s + s;
    const g = gcd(b, n);
    for (let i = 0; i < n; i += g) {
        for (let j = 0; j < 10; j++) {
            const kLimit = b % 2 === 0 ? 0 : 9;
            for (let k = 0; k <= kLimit; k++) {
                const t = s.substr(i, n).split('');
                for (let p = 1; p < n; p += 2) {
                    t[p] = String.fromCharCode('0'.charCodeAt(0) + 
                            (t[p].charCodeAt(0) - '0'.charCodeAt(0) + j * a) % 10);
                }
                for (let p = 0; p < n; p += 2) {
                    t[p] = String.fromCharCode('0'.charCodeAt(0) + 
                            (t[p].charCodeAt(0) - '0'.charCodeAt(0) + k * a) % 10);
                }
                const tStr = t.join('');
                if (tStr < res) {
                    res = tStr;
                }
            }
        }
    }
    return res;
}

function gcd(a: number, b: number): number {
    while (b !== 0) {
        [a, b] = [b, a % b];
    }
    return a;
}
```

```Rust
impl Solution {
    pub fn find_lex_smallest_string(s: String, a: i32, b: i32) -> String {
        fn gcd(a: usize, b: usize) -> usize {
            let mut a = a;
            let mut b = b;
            while b != 0 {
                let temp = b;
                b = a % b;
                a = temp;
            }
            a
        }

        let n = s.len();
        let mut res = s.clone();
        let doubled = s.repeat(2);
        let g = gcd(b as usize, n);
        let s_chars: Vec<char> = doubled.chars().collect();
        
        for i in (0..n).step_by(g) {
            for j in 0..10 {
                let k_limit = if b % 2 == 0 { 0 } else { 9 };
                for k in 0..=k_limit {
                    let mut t: Vec<char> = s_chars[i..i+n].to_vec();
                    for p in (1..n).step_by(2) {
                        let digit = t[p].to_digit(10).unwrap() as i32;
                        t[p] = std::char::from_digit(((digit + j * a) % 10) as u32, 10).unwrap();
                    }
                    for p in (0..n).step_by(2) {
                        let digit = t[p].to_digit(10).unwrap() as i32;
                        t[p] = std::char::from_digit(((digit + k * a) % 10) as u32, 10).unwrap();
                    }
                    let t_str: String = t.into_iter().collect();
                    if t_str < res {
                        res = t_str;
                    }
                }
            }
        }
        res
    }
}
```

枚举累加次数的过程中，我们的目的是让字符串的字典序更小，由于奇偶位两组互相独立，组内累加次数相同，因此我们只需考虑 $t[0]$ 和 $t[1]$ 即可。

我们先要找到使得 $t[1]$ 最小的轮转次数，对奇数位进行累加。如果 $b$ 是奇数，我们还要找到让 $t[0]$ 最小的轮转次数，对偶数位进行累加。

```C++
class Solution {
public:
    string findLexSmallestString(string s, int a, int b) {
        int n = s.size();
        string res = s;
        s = s + s;
        int g = gcd(b, n);
        
        auto add = [&](string& t, int start) {
            int minVal = 10, times = 0;
            for (int i = 0; i < 10; i++) {
                int added = ((t[start] - '0') + i * a) % 10;
                if (added < minVal) {
                    minVal = added;
                    times = i;
                }
            }
            for (int i = start; i < n; i += 2) {
                t[i] = '0' + ((t[i] - '0') + times * a) % 10;
            }
        };

        for (int i = 0; i < n; i += g) {
            string t = s.substr(i, n);
            add(t, 1);
            if (b % 2) {
                add(t, 0);
            }
            res = min(res, t);
        }
        return res;
    }
};
```

```Java
class Solution {
    public String findLexSmallestString(String s, int a, int b) {
        int n = s.length();
        String res = s;
        s = s + s;
        int g = gcd(b, n);

        for (int i = 0; i < n; i += g) {
            char[] t = s.substring(i, i + n).toCharArray();
            add(t, n, a, 1);
            if (b % 2 != 0) {
                add(t, n, a, 0);
            }
            String tStr = new String(t);
            if (tStr.compareTo(res) < 0) {
                res = tStr;
            }
        }
        return res;
    }

    public void add(char[] t, int n, int a, int start) {
        int minVal = 10, times = 0;
        for (int i = 0; i < 10; i++) {
            int added = ((t[start] - '0') + i * a) % 10;
            if (added < minVal) {
                minVal = added;
                times = i;
            }
        }
        for (int i = start; i < n; i += 2) {
            t[i] = (char) ('0' + ((t[i] - '0') + times * a) % 10);
        }
    }

    public int gcd(int num1, int num2) {
        while (num2 != 0) {
            int temp = num1;
            num1 = num2;
            num2 = temp % num2;
        }
        return num1;
    }
}
```

```CSharp
public class Solution {
    public string FindLexSmallestString(string s, int a, int b) {
        int n = s.Length;
        string res = s;
        s = s + s;
        int g = GCD(b, n);

        for (int i = 0; i < n; i += g) {
            char[] t = s.Substring(i, n).ToCharArray();
            Add(t, n, a, 1);
            if (b % 2 != 0) {
                Add(t, n, a, 0);
            }
            string tStr = new string(t);
            if (tStr.CompareTo(res) < 0) {
                res = tStr;
            }
        }
        return res;
    }

    public void Add(char[] t, int n, int a, int start) {
        int minVal = 10, times = 0;
        for (int i = 0; i < 10; i++) {
            int added = ((t[start] - '0') + i * a) % 10;
            if (added < minVal) {
                minVal = added;
                times = i;
            }
        }
        for (int i = start; i < n; i += 2) {
            t[i] = (char) ('0' + ((t[i] - '0') + times * a) % 10);
        }
    }

    public int GCD(int num1, int num2) {
        while (num2 != 0) {
            int temp = num1;
            num1 = num2;
            num2 = temp % num2;
        }
        return num1;
    }
}
```

```C
int gcd(int num1, int num2) {
    while (num2 != 0) {
        int temp = num1;
        num1 = num2;
        num2 = temp % num2;
    }
    return num1;
}

void add(char *t, int n, int a, int start) {
    int minVal = 10, times = 0;
    for (int i = 0; i < 10; i++) {
        int added = ((t[start] - '0') + i * a) % 10;
        if (added < minVal) {
            minVal = added;
            times = i;
        }
    }
    for (int i = start; i < n; i += 2) {
        t[i] = '0' + ((t[i] - '0') + times * a) % 10;
    }
};

char * findLexSmallestString(char * s, int a, int b) {
    int n = strlen(s);
    int vis[n];
    memset(vis, 0, sizeof(vis));
    char *res = (char *)calloc(sizeof(char), n + 1);
    strcpy(res, s);
    // 将 s 延长一倍，方便截取轮转后的字符串 t
    char str[2 * n + 1];
    sprintf(str, "%s%s", s, s);
    int g = gcd(b, n);
    for (int i = 0; i < n; i += g) {
        char t[n + 1];
        strncpy(t, str + i, n);
        t[n] = '\0';
        add(t, n, a, 1);
        if (b % 2 != 0) {
            add(t, n, a, 0);
        }
        if (strcmp(t, res) < 0) {
            strcpy(res, t);
        }
    }
    return res;
}
```

```JavaScript
var findLexSmallestString = function(s, a, b) {
    const n = s.length;
    let res = s;
    s = s + s;
    const g = gcd(b, n);

    for (let i = 0; i < n; i += g) {
        const t = [...s.slice(i, i + n)];
        add(t, n, a, 1);
        if (b % 2 !== 0) {
            add(t, n, a, 0);
        }
        const tStr = t.join('');
        if (tStr < res) {
            res = tStr;
        }
    }
    return res;
}

const add = (t, n, a, start) => {
    let minVal = 10, times = 0;
    for (let i = 0; i < 10; i++) {
        const added = ((t[start].charCodeAt() - '0'.charCodeAt()) + i * a) % 10;
        if (added < minVal) {
            minVal = added;
            times = i;
        }
    }
    for (let i = start; i < n; i += 2) {
        t[i] = String.fromCharCode('0'.charCodeAt() + ((t[i].charCodeAt() - '0'.charCodeAt()) + times * a) % 10);
    }
}

const gcd = (num1, num2) => {
    while (num2 !== 0) {
        const temp = num1;
        num1 = num2;
        num2 = temp % num2;
    }
    return num1;
};
```

```Go
func findLexSmallestString(s string, a int, b int) string {
    n := len(s)
    res := s
    s = s + s
    g := gcd(b, n)

    add := func(t []byte, start int) {
        minVal, times := 10, 0
        original := int(t[start] - '0')
        for i := 0; i < 10; i++ {
            added := (original + i * a) % 10
            if added < minVal {
                minVal, times = added, i
            }
        }
        for i := start; i < n; i += 2 {
            t[i] = byte('0' + (int(t[i] - '0') + times * a) % 10)
        }
    }

    for i := 0; i < n; i += g {
        t := []byte(s[i : i + n])
        add(t, 1)
        if b % 2 != 0 {
            add(t, 0)
        }
        tStr := string(t)
        if tStr < res {
            res = tStr
        }
    }
    return res
}

func gcd(a, b int) int {
    for b != 0 {
        a, b = b, a % b
    }
    return a
}
```

```Python
class Solution:
    def findLexSmallestString(self, s: str, a: int, b: int) -> str:
        n = len(s)
        res = s
        s = s + s
        g = math.gcd(b, n)
        
        def add(t, start):
            original = int(t[start])
            min_val, times = 10, 0
            for i in range(10):
                added = (original + i * a) % 10
                if added < min_val:
                    min_val = added
                    times = i
            t_list = list(t)
            for i in range(start, n, 2):
                t_list[i] = str((int(t_list[i]) + times * a) % 10)
            return ''.join(t_list)
        
        for i in range(0, n, g):
            t = s[i:i + n]
            t = add(t, 1)
            if b % 2:
                t = add(t, 0)
            if t < res:
                res = t
        return res
```

```TypeScript
function findLexSmallestString(s: string, a: number, b: number): string {
    const n = s.length;
    let res = s;
    s = s + s;
    const g = gcd(b, n);

    const add = (t: string[], start: number) => {
        let minVal = 10, times = 0;
        const original = parseInt(t[start]);
        for (let i = 0; i < 10; i++) {
            const added = (original + i * a) % 10;
            if (added < minVal) {
                minVal = added;
                times = i;
            }
        }
        for (let i = start; i < n; i += 2) {
            t[i] = ((parseInt(t[i]) + times * a) % 10).toString();
        }
    };

    for (let i = 0; i < n; i += g) {
        const t = s.substr(i, n).split('');
        add(t, 1);
        if (b % 2) {
            add(t, 0);
        }
        const tStr = t.join('');
        if (tStr < res) {
            res = tStr;
        }
    }
    return res;
}

function gcd(a: number, b: number): number {
    while (b !== 0) {
        [a, b] = [b, a % b];
    }
    return a;
}
```

```Rust
impl Solution {
    pub fn find_lex_smallest_string(s: String, a: i32, b: i32) -> String {
        fn gcd(a: usize, b: usize) -> usize {
            let mut a = a;
            let mut b = b;
            while b != 0 {
                let temp = b;
                b = a % b;
                a = temp;
            }
            a
        }

        let n = s.len();
        let mut res = s.clone();
        let doubled = s.repeat(2);
        let g = gcd(b as usize, n);

        let mut add = |t: &mut Vec<char>, start: usize| {
            let original = t[start].to_digit(10).unwrap() as i32;
            let (mut min_val, mut times) = (10, 0);
            for i in 0..10 {
                let added = (original + i * a) % 10;
                if added < min_val {
                    min_val = added;
                    times = i;
                }
            }
            for i in (start..n).step_by(2) {
                let digit = t[i].to_digit(10).unwrap() as i32;
                t[i] = std::char::from_digit(((digit + times * a) % 10) as u32, 10).unwrap();
            }
        };

        for i in (0..n).step_by(g) {
            let mut t: Vec<char> = doubled[i..i+n].chars().collect();
            add(&mut t, 1);
            if b % 2 != 0 {
                add(&mut t, 0);
            }
            let t_str: String = t.into_iter().collect();
            if t_str < res {
                res = t_str;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2d^2)$，其中 $n$ 是 $s$ 的长度，$d$ 是枚举累加次数的上限，本题中等于 $10$。优化枚举轮转次数后，算法复杂度常数级别降低，在最坏情况下仍然为 $O(n^2d^2)$。优化枚举累加次数后，时间复杂度降低为 $O(n^2d)$。
- 空间复杂度：$O(n)$，其中 $n$ 是 $s$ 的长度。
