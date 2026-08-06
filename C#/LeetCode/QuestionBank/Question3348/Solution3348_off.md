### [最小可整除数位乘积 II](https://leetcode.cn/problems/smallest-divisible-digit-product-ii/solutions/4002402/zui-xiao-ke-zheng-chu-shu-wei-cheng-ji-i-3g9f/)

#### 方法一：从右往左枚举字符串

首先能确定的是，$t$ 中的质因子只能包括 $2,3,5,7$，因为数位中的质因子只有 $2,3,5,7$，如果 $t$ 中包含其他质因子，那么可以直接返回 $-1$，否则答案一定存在。

那么现在考虑如何进行填数：

首先，题目要求我们找到的数要比题干给出的 $num$ 大。假设我们拿到一个 $num=111$，在构造字符串的最高位填 $1$ 的情况下，第二位是不可以填小于当前数位的数的，不然就比 $num$ 小了；在最高位填的数大于 $1$ 的情况下，第二位以及后面的位数都可以任意选择 $[1,9]$ 中的数字了。

其次，如何判断填出来的数能够整除 $t$ 呢？

我们可以用每一个数位对 $t$ 做提取最大公因数，假设当前数位的数是 $x$，那么其余数位上的数要满足乘积是 $\dfrac{t}{GCD(t,x)}$ 的倍数。

那么，定义 $rem$ 数组，$rem[i]$ 表示从 $i$ 到 $n-1$，我们构造的字符串各数位乘积要是 $rem[i]$ 的倍数，这里 $rem[0]=t$。其中：

$$rem[i+1]=\dfrac{rem[i]}{GCD(rem[i],num[i])}$$

有了这个数组就能够让我们在从右往左枚举时方便地知道当前位置对应的 $t$ 是多少了（$t$ 相当于一个标记，用来标记从当前的位置到字符串结尾对应数位乘积需要是某个数的倍数，这个数就是 $t$）。

如果 $rem[n]=1$，就说明当前字符串 $num$ 的各数位乘积正好是 $t$ 的倍数，不需要修改，直接返回 $num$ 即可。

如果 $rem[n]\ne 1$，那么就需要构造一个能够整除 $t$ 的数字。

假设 $num$ 中不包含 $0$，那么从 $i=n-1$ 开始枚举：

- 增加 $num[n-1]$ 的值，并计算当前的 $tNow=\dfrac{rem[n-1]}{GCD(rem[n-1],num[n-1])}$，如果 $tNow=1$，说明增加 $num[n-1]$ 的值后，当前的 $num$ 能够整除 $t$，返回 $num$ 即可。
- 如果 $num[n-1]$ 增加到 $9$ 了还没有找到答案，那么结束增加 $num[n-1]$，开始增加 $num[n-2]$。
- 增加 $num[n-2]$ 的值，并计算当前的 $tNow=\dfrac{rem[n-2]}{GCD(rem[n-2],num[n-2])}$，那么此时的 $num[n-1]$ 是可以随便选择的，我们可以从 $9$ 枚举到 $1$，在枚举的过程中如果发现 $num[n-1]$ 能够被 $tNow$ 整除，则在 $num[n-1]$ 上填入当前枚举到的数字，并将 $tNow$ 修改为 $\dfrac{tNow}{num[n-1]}$，如果 $tNow=1$，则返回 $num$。

按上述过程进行枚举。首先从右到左枚举 $i$ 来增加 $num[i]$，并计算 $tNow=\dfrac{rem[i]}{GCD(rem[i],num[i])}$。然后我们尝试构造 $tNow$，因为 $num[i]$ 已经增加，所以后续位置我们可以填入任意数位。而为了保证构造出来的数字尽可能小，我们要让靠前数位的数字尽可能小，所以靠后数位的数字要尽可能大，因此可以贪心地从 $n-1$ 到 $i+1$ 倒着枚举 $j$，然后从 $9$ 到 $1$ 枚举填入 $num[j]$ 的数字，如果发现 $num[j]$ 能够被 $tNow$ 整除，则更新 $tNow$ 为 $\dfrac{tNow}{num[j]}$，然后继续枚举下一个 $num[j]$，直到成功构造 $tNow$，若无解则继续遍历下一个 $num[i]$。

如果 $i$ 枚举到 $0$ 了还没有找到答案，说明答案一定比 $num$ 长，我们按照上述思路从低位到高位，从 $9$ 到 $2$ 提取 $t$ 的所有因子，再往前填充 $1$，即可构造出一个答案。

需要注意的是，如果在 $num$ 中存在 $0$，那么这些 $0$ 就必须要修改，我们在计算 $rem$ 的过程中可以把 $num$ 中最左边 $0$ 的位置 $pos$ 找出来，然后 $i$ 直接从 $pos$ 开始枚举，按照上述生成答案的方式能够保证所有的 $0$ 都被修改。

**思路与算法**

```C++
class Solution {
public:
    string smallestNumber(string num, long long t) {
        long long temp = t;
        for (int i = 2; i <= 9; i++) {
            while(temp % i == 0) {
                temp /= i;
            }
        }
        if (temp > 1) {
            return "-1";
        }
        int n = num.length();
        vector<long long> rem(n + 1);
        rem[0] = t;
        int pos = n - 1;
        for (int i = 0; i < n; i++) {
            if (num[i] == '0') {
                pos = i;`
                break;
            }
            rem[i + 1] = rem[i] / gcd(rem[i], num[i] - '0');
        }
        if (rem[n] == 1) {
            return num;
        }

        for (int i = pos; i >= 0; i--) {
            while (++num[i] <= '9') {
                long long tNow = rem[i] / gcd(rem[i], num[i] - '0');
                int k = 9;
                for (int j = n - 1; j > i; j--) {
                    while (tNow % k) {
                        k--;
                    }
                    tNow /= k;
                    num[j] = '0' + k;
                }
                if (tNow == 1) {
                    return num;
                }
            }
        }

        string ans;
        for (int i = 9; i > 1; i--) {
            while (t % i == 0) {
                ans += '0' + i;
                t /= i;
            }
        }
        ans += string(max(n + 1 - (int) ans.length(), 0), '1');
        ranges::reverse(ans);
        return ans;
    }
};
```

```Go
func smallestNumber(num string, t int64) string {
    temp := t
    for i := int64(2); i <= 9; i++ {
        for temp%i == 0 {
            temp /= i
        }
    }
    if temp > 1 {
        return "-1"
    }

    n := len(num)
    rem := make([]int64, n+1)
    rem[0] = t
    pos := n - 1

    numBytes := []byte(num)
    for i := 0; i < n; i++ {
        if numBytes[i] == '0' {
            pos = i
            break
        }
        rem[i+1] = rem[i] / gcd(rem[i], int64(numBytes[i]-'0'))
    }

    if rem[n] == 1 {
        return num
    }

    for i := pos; i >= 0; i-- {
        for {
            numBytes[i]++
            if numBytes[i] > '9' {
                break
            }
            tNow := rem[i] / gcd(rem[i], int64(numBytes[i]-'0'))
            k := 9
            for j := n - 1; j > i; j-- {
                for tNow%int64(k) != 0 {
                    k--
                }
                tNow /= int64(k)
                numBytes[j] = byte('0' + k)
            }
            if tNow == 1 {
                return string(numBytes)
            }
        }
    }

    var ans strings.Builder
    t = t
    for i := 9; i > 1; i-- {
        for t%int64(i) == 0 {
            ans.WriteByte(byte('0' + i))
            t /= int64(i)
        }
    }

    ansStr := ans.String()
    padding := max(n+1-len(ansStr), 0)
    ansStr += strings.Repeat("1", padding)
    runes := []rune(ansStr)
    for i, j := 0, len(runes)-1; i < j; i, j = i+1, j-1 {
        runes[i], runes[j] = runes[j], runes[i]
    }

    return string(runes)
}

func gcd(a, b int64) int64 {
    for b != 0 {
        a, b = b, a%b
    }
    return a
}

func max(a, b int) int {
    if a > b {
        return a
    }
    return b
}
```

```Python
class Solution:
    def smallestNumber(self, num: str, t: int) -> str:
        temp = t
        for i in range(2, 10):
            while temp % i == 0:
                temp //= i

        if temp > 1:
            return "-1"

        n = len(num)
        rem = [0] * (n + 1)
        rem[0] = t
        pos = n - 1

        num_list = list(num)
        for i in range(n):
            if num_list[i] == '0':
                pos = i
                break
            rem[i + 1] = rem[i] // math.gcd(rem[i], int(num_list[i]))

        if rem[n] == 1:
            return num

        for i in range(pos, -1, -1):
            while True:
                num_list[i] = chr(ord(num_list[i]) + 1)
                if num_list[i] > '9':
                    break

                t_now = rem[i] // math.gcd(rem[i], int(num_list[i]))
                k = 9

                for j in range(n - 1, i, -1):
                    while t_now % k != 0:
                        k -= 1
                    t_now //= k
                    num_list[j] = str(k)

                if t_now == 1:
                    return ''.join(num_list)

        ans = []
        original_t = t
        for i in range(9, 1, -1):
            while original_t % i == 0:
                ans.append(str(i))
                original_t //= i

        ans_str = ''.join(ans)
        padding = max(n + 1 - len(ans_str), 0)
        ans_str += '1' * padding

        return ans_str[::-1]
```

```Java
class Solution {
    public String smallestNumber(String num, long t) {
        long temp = t;
        for (int i = 2; i <= 9; i++) {
            while (temp % i == 0) {
                temp /= i;
            }
        }
        if (temp > 1) {
            return "-1";
        }

        int n = num.length();
        long[] rem = new long[n + 1];
        rem[0] = t;
        int pos = n - 1;

        char[] numChars = num.toCharArray();
        for (int i = 0; i < n; i++) {
            if (numChars[i] == '0') {
                pos = i;
                break;
            }
            rem[i + 1] = rem[i] / gcd(rem[i], numChars[i] - '0');
        }

        if (rem[n] == 1) {
            return num;
        }

        for (int i = pos; i >= 0; i--) {
            while (++numChars[i] <= '9') {
                long tNow = rem[i] / gcd(rem[i], numChars[i] - '0');
                int k = 9;

                for (int j = n - 1; j > i; j--) {
                    while (tNow % k != 0) {
                        k--;
                    }
                    tNow /= k;
                    numChars[j] = (char)('0' + k);
                }

                if (tNow == 1) {
                    return new String(numChars);
                }
            }
        }

        StringBuilder ans = new StringBuilder();
        long originalT = t;
        for (int i = 9; i > 1; i--) {
            while (originalT % i == 0) {
                ans.append((char)('0' + i));
                originalT /= i;
            }
        }

        int padding = Math.max(n + 1 - ans.length(), 0);
        for (int i = 0; i < padding; i++) {
            ans.append('1');
        }

        return ans.reverse().toString();
    }

    private long gcd(long a, long b) {
        while (b != 0) {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
```

```CSharp
public class Solution {
    public string SmallestNumber(string num, long t) {
        long temp = t;
        for (int i = 2; i <= 9; i++) {
            while (temp % i == 0) {
                temp /= i;
            }
        }
        if (temp > 1) {
            return "-1";
        }

        int n = num.Length;
        long[] rem = new long[n + 1];
        rem[0] = t;
        int pos = n - 1;

        char[] numChars = num.ToCharArray();
        for (int i = 0; i < n; i++) {
            if (numChars[i] == '0') {
                pos = i;
                break;
            }
            rem[i + 1] = rem[i] / Gcd(rem[i], numChars[i] - '0');
        }

        if (rem[n] == 1) {
            return num;
        }

        for (int i = pos; i >= 0; i--) {
            while (++numChars[i] <= '9') {
                long tNow = rem[i] / Gcd(rem[i], numChars[i] - '0');
                int k = 9;

                for (int j = n - 1; j > i; j--) {
                    while (tNow % k != 0) {
                        k--;
                    }
                    tNow /= k;
                    numChars[j] = (char)('0' + k);
                }

                if (tNow == 1) {
                    return new string(numChars);
                }
            }
        }

        System.Text.StringBuilder ans = new System.Text.StringBuilder();
        long originalT = t;
        for (int i = 9; i > 1; i--) {
            while (originalT % i == 0) {
                ans.Append((char)('0' + i));
                originalT /= i;
            }
        }

        int padding = Math.Max(n + 1 - ans.Length, 0);
        ans.Append('1', padding);

        char[] charArray = ans.ToString().ToCharArray();
        System.Array.Reverse(charArray);
        return new string(charArray);
    }

    private long Gcd(long a, long b) {
        while (b != 0) {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
```

```C
long long gcd(long long a, long long b) {
    while (b != 0) {
        long long temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

char* smallestNumber(char* num, long long t) {
    long long originalT = t;
    long long temp = t;
    for (int i = 2; i <= 9; i++) {
        while (temp % i == 0) {
            temp /= i;
        }
    }
    if (temp > 1) {
        char* result = (char*)malloc(3 * sizeof(char));
        strcpy(result, "-1");
        return result;
    }

    int n = strlen(num);
    long long* rem = (long long*)malloc((n + 1) * sizeof(long long));
    rem[0] = t;
    int pos = n - 1;

    char* numCopy = (char*)malloc((n + 1) * sizeof(char));
    strcpy(numCopy, num);

    for (int i = 0; i < n; i++) {
        if (numCopy[i] == '0') {
            pos = i;
            break;
        }
        rem[i + 1] = rem[i] / gcd(rem[i], numCopy[i] - '0');
    }

    if (rem[n] == 1) {
        free(rem);
        return numCopy;
    }

    for (int i = pos; i >= 0; i--) {
        while (++numCopy[i] <= '9') {
            long long tNow = rem[i] / gcd(rem[i], numCopy[i] - '0');
            int k = 9;

            for (int j = n - 1; j > i; j--) {
                while (tNow % k != 0) {
                    k--;
                }
                tNow /= k;
                numCopy[j] = '0' + k;
            }

            if (tNow == 1) {
                free(rem);
                return numCopy;
            }
        }
    }
    int factorCount = 0;
    long long tempT = originalT;
    for (int i = 9; i > 1; i--) {
        while (tempT % i == 0) {
            factorCount++;
            tempT /= i;
        }
    }

    int ansLen = factorCount;
    int padding = n + 1 - ansLen;
    if (padding > 0) {
        ansLen += padding;
    }

    char* ans = (char*)malloc((ansLen + 1) * sizeof(char));
    int idx = 0;
    tempT = originalT;

    for (int i = 9; i > 1; i--) {
        while (tempT % i == 0) {
            ans[idx++] = '0' + i;
            tempT /= i;
        }
    }

    for (int i = 0; i < padding; i++) {
        ans[idx++] = '1';
    }

    ans[idx] = '\0';

    for (int i = 0; i < idx / 2; i++) {
        char tempChar = ans[i];
        ans[i] = ans[idx - 1 - i];
        ans[idx - 1 - i] = tempChar;
    }

    free(rem);
    free(numCopy);
    return ans;
}
```

```JavaScript
var smallestNumber = function(num, t) {
    let temp = t;
    for (let i = 2; i <= 9; i++) {
        while (temp % i === 0) {
            temp /= i;
        }
    }
    if (temp > 1) {
        return "-1";
    }

    const n = num.length;
    const rem = new Array(n + 1);
    rem[0] = t;
    let pos = n - 1;

    const numArr = num.split('');
    for (let i = 0; i < n; i++) {
        if (numArr[i] === '0') {
            pos = i;
            break;
        }
        rem[i + 1] = Math.floor(rem[i] / gcd(rem[i], parseInt(numArr[i])));
    }

    if (rem[n] === 1) {
        return num;
    }

    for (let i = pos; i >= 0; i--) {
        while (true) {
            numArr[i] = String.fromCharCode(numArr[i].charCodeAt(0) + 1);
            if (numArr[i] > '9') {
                break;
            }

            let tNow = Math.floor(rem[i] / gcd(rem[i], parseInt(numArr[i])));
            let k = 9;

            for (let j = n - 1; j > i; j--) {
                while (tNow % k !== 0) {
                    k--;
                }
                tNow = Math.floor(tNow / k);
                numArr[j] = String.fromCharCode('0'.charCodeAt(0) + k);
            }

            if (tNow === 1) {
                return numArr.join('');
            }
        }
    }

    let ans = [];
    let originalT = t;
    for (let i = 9; i > 1; i--) {
        while (originalT % i === 0) {
            ans.push(String.fromCharCode('0'.charCodeAt(0) + i));
            originalT = Math.floor(originalT / i);
        }
    }

    const padding = Math.max(n + 1 - ans.length, 0);
    for (let i = 0; i < padding; i++) {
        ans.push('1');
    }

    return ans.reverse().join('');
};

function gcd(a, b) {
    while (b !== 0) {
        const temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}
```

```TypeScript
function smallestNumber(num: string, t: number): string {
    let temp: number = t;
    for (let i: number = 2; i <= 9; i++) {
        while (temp % i === 0) {
            temp /= i;
        }
    }
    if (temp > 1) {
        return "-1";
    }

    const n: number = num.length;
    const rem: number[] = new Array(n + 1);
    rem[0] = t;
    let pos: number = n - 1;

    const numArr: string[] = num.split('');
    for (let i: number = 0; i < n; i++) {
        if (numArr[i] === '0') {
            pos = i;
            break;
        }
        rem[i + 1] = Math.floor(rem[i] / gcd(rem[i], parseInt(numArr[i])));
    }

    if (rem[n] === 1) {
        return num;
    }

    for (let i: number = pos; i >= 0; i--) {
        while (true) {
            numArr[i] = String.fromCharCode(numArr[i].charCodeAt(0) + 1);
            if (numArr[i] > '9') {
                break;
            }

            let tNow: number = Math.floor(rem[i] / gcd(rem[i], parseInt(numArr[i])));
            let k: number = 9;

            for (let j: number = n - 1; j > i; j--) {
                while (tNow % k !== 0) {
                    k--;
                }
                tNow = Math.floor(tNow / k);
                numArr[j] = String.fromCharCode('0'.charCodeAt(0) + k);
            }

            if (tNow === 1) {
                return numArr.join('');
            }
        }
    }

    let ans: string[] = [];
    let originalT: number = t;
    for (let i: number = 9; i > 1; i--) {
        while (originalT % i === 0) {
            ans.push(String.fromCharCode('0'.charCodeAt(0) + i));
            originalT = Math.floor(originalT / i);
        }
    }

    const padding: number = Math.max(n + 1 - ans.length, 0);
    for (let i: number = 0; i < padding; i++) {
        ans.push('1');
    }

    return ans.reverse().join('');
}

function gcd(a: number, b: number): number {
    while (b !== 0) {
        const temp: number = b;
        b = a % b;
        a = temp;
    }
    return a;
}
```

```Rust
impl Solution {
    pub fn smallest_number(num: String, t: i64) -> String {
        let mut temp = t;
        for i in 2..=9 {
            while temp % i == 0 {
                temp /= i;
            }
        }
        if temp > 1 {
            return "-1".to_string();
        }

        let n = num.len();
        let mut rem = vec![0i64; n + 1];
        rem[0] = t;
        let mut pos = n - 1;

        let mut num_chars: Vec<char> = num.chars().collect();

        for i in 0..n {
            if num_chars[i] == '0' {
                pos = i;
                break;
            }
            rem[i + 1] = rem[i] / gcd(rem[i], (num_chars[i] as u8 - b'0') as i64);
        }

        if rem[n] == 1 {
            return num;
        }

        for i in (0..=pos).rev() {
            loop {
                num_chars[i] = ((num_chars[i] as u8) + 1) as char;
                if num_chars[i] > '9' {
                    break;
                }

                let mut t_now = rem[i] / gcd(rem[i], (num_chars[i] as u8 - b'0') as i64);
                let mut k = 9i64;

                for j in (i + 1..n).rev() {
                    while t_now % k != 0 {
                        k -= 1;
                    }
                    t_now /= k;
                    num_chars[j] = (b'0' + k as u8) as char;
                }

                if t_now == 1 {
                    return num_chars.iter().collect();
                }
            }
        }

        let mut ans = Vec::new();
        let mut original_t = t;

        for i in (2..=9).rev() {
            while original_t % i == 0 {
                ans.push((b'0' + i as u8) as char);
                original_t /= i;
            }
        }

        let padding = std::cmp::max(n as i32 + 1 - ans.len() as i32, 0) as usize;
        for _ in 0..padding {
            ans.push('1');
        }

        ans.reverse();
        ans.iter().collect()
    }
}

fn gcd(mut a: i64, mut b: i64) -> i64 {
    while b != 0 {
        let temp = b;
        b = a % b;
        a = temp;
    }
    a
}
```

**复杂度分析**

- 时间复杂度：$O(n+D\log^2 t)$，其中 $n$ 是 $num$ 的长度，$D=9$，质因数分解部分时间复杂度为 $O(\log t)$；预处理 $rem$ 的部分时间复杂度为 $O(n)$；四重循环部分，如果 $i$ 从 $n-1$ 开始循环，那么 $i$ 至多减少 $O(\log t)$ 次，这样一定能够在右边填入 $O(\log t)$ 个数字，因此 $j$ 会循环 $O(\log t)$ 次，复杂度为 $O(D\log^2 t)$，如果 $i$ 从小于 $n-1$ 的位置开始循环，则 $j$ 的循环次数为 $O(n)$，复杂度为 $O(D(\log t+n))$；构造新答案需要时间为 $O(\log t)$。
- 空间复杂度：$O(n)$，其中 $n$ 是 $num$ 的长度。
