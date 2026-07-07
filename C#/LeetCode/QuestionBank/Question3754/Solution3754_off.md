### [连接非零数字并乘以其数字和 I](https://leetcode.cn/problems/concatenate-non-zero-digits-and-multiply-by-sum-i/solutions/3988224/lian-jie-fei-ling-shu-zi-bing-cheng-yi-q-p918/)

#### 方法一：从左到右遍历

**思路与算法**

把输入整数 $n$ 转化成字符串 $s$，再依次从左到右遍历每一个字符，按照题意模拟即可。

**代码**

```C++
class Solution {
public:
    long long sumAndMultiply(int n) {
        long long x = 0;
        long long sum = 0;
        string s = to_string(n);
        for (char c : s) {
            int d = c - '0';
            sum += d;
            if (d > 0) {
                x = x * 10 + d;
            }
        }
        return x * sum;
    }
};
```

```Java
class Solution {
    public long sumAndMultiply(int n) {
        long x = 0;
        long sum = 0;
        String s = String.valueOf(n);
        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            int d = c - '0';
            sum += d;
            if (d > 0) {
                x = x * 10 + d;
            }
        }
        return x * sum;
    }
}

```

```Python
class Solution:
    def sumAndMultiply(self, n: int) -> int:
        x = 0
        sum = 0
        for c in str(n):
            d = int(c)
            sum += d
            if d > 0:
                x = x * 10 + d
        return x * sum

```

```JavaScript
var sumAndMultiply = function(n) {
    let x = 0;
    let sum = 0;
    for (let c of String(n)) {
        let d = parseInt(c, 10);
        sum += d;
        if (d > 0) {
            x = x * 10 + d;
        }
    }
    return x * sum;
};
```

```TypeScript
function sumAndMultiply(n: number): number {
    let x: number = 0;
    let sum: number = 0;
    for (let c of String(n)) {
        let d: number = parseInt(c, 10);
        sum += d;
        if (d > 0) {
            x = x * 10 + d;
        }
    }
    return x * sum;
};
```

```Go
func sumAndMultiply(n int) int64 {
    var x int64 = 0
    var sum int64 = 0
    s := strconv.Itoa(n)
    for _, c := range s {
        d := int64(c - '0')
        sum += d
        if d > 0 {
            x = x*10 + d
        }
    }
    return x * sum
}
```

```CSharp
public class Solution {
    public long SumAndMultiply(int n) {
        long x = 0;
        long sum = 0;
        string s = n.ToString();
        foreach (char c in s) {
            int d = c - '0';
            sum += d;
            if (d > 0) {
                x = x * 10 + d;
            }
        }
        return x * sum;
    }
}
```

```C
long long sumAndMultiply(int n) {
    long long x = 0;
    long long sum = 0;
    char s[20];
    sprintf(s, "%d", n);
    for (int i = 0; i < strlen(s); i++) {
        char c = s[i];
        int d = c - '0';
        sum += d;
        if (d > 0) {
            x = x * 10 + d;
        }
    }
    return x * sum;
}
```

```Rust
impl Solution {
    pub fn sum_and_multiply(n: i32) -> i64 {
        let mut x: i64 = 0;
        let mut sum: i64 = 0;
        let s = n.to_string();
        for c in s.chars() {
            let d = c.to_digit(10).unwrap() as i64;
            sum += d;
            if d > 0 {
                x = x * 10 + d;
            }
        }
        x * sum
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\log n)$。
- 空间复杂度：$O(\log n)$。

#### 方法二：从右到左遍历

**思路与算法**

我们使用一个循环，不断对 $n$ 进行除十的操作，从而从右到左依次遍历 $n$ 的每一个数字，同时更新 $x$ 和 $sum$。

同时每次遇见一个非零数字，我们把 $pow10$ 乘以十，这样就更方便更新 $x$ 的下一位左边数字。

**代码**

```C++
class Solution {
public:
    long long sumAndMultiply(int n) {
        long long x = 0, sum = 0, pow10 = 1;
        while (n > 0) {
            int d = n % 10;
            sum += d;
            if (d > 0) {
                x += d * pow10;
                pow10 *= 10;
            }
            n /= 10;
        }
        return x * sum;
    }
};
```

```Java
class Solution {
    public long sumAndMultiply(int n) {
        long x = 0, sum = 0, pow10 = 1;
        while (n > 0) {
            int d = n % 10;
            sum += d;
            if (d > 0) {
                x += d * pow10;
                pow10 *= 10;
            }
            n /= 10;
        }
        return x * sum;
    }
}
```

```Python
class Solution:
    def sumAndMultiply(self, n: int) -> int:
        x, sum, pow10 = 0, 0, 1
        while n > 0:
            d = n % 10
            sum += d
            if d > 0:
                x += d * pow10
                pow10 *= 10
            n //= 10
        return x * sum
```

```JavaScript
var sumAndMultiply = function(n) {
    let x = 0, sum = 0, pow10 = 1;
    while (n > 0) {
        let d = n % 10;
        sum += d;
        if (d > 0) {
            x += d * pow10;
            pow10 *= 10;
        }
        n = Math.floor(n / 10);
    }
    return x * sum;
};
```

```TypeScript
function sumAndMultiply(n: number): number {
    let x: number = 0, sum: number = 0, pow10: number = 1;
    while (n > 0) {
        let d: number = n % 10;
        sum += d;
        if (d > 0) {
            x += d * pow10;
            pow10 *= 10;
        }
        n = Math.floor(n / 10);
    }
    return x * sum;
};
```

```Go
func sumAndMultiply(n int) int64 {
    var x int64 = 0
    var sum int64 = 0
    var pow10 int64 = 1
    for n > 0 {
        d := n % 10
        sum += int64(d)
        if d > 0 {
            x += int64(d) * pow10
            pow10 *= 10
        }
        n /= 10
    }
    return x * sum
}
```

```CSharp
public class Solution {
    public long SumAndMultiply(int n) {
        long x = 0, sum = 0, pow10 = 1;
        while (n > 0) {
            int d = n % 10;
            sum += d;
            if (d > 0) {
                x += d * pow10;
                pow10 *= 10;
            }
            n /= 10;
        }
        return x * sum;
    }
}
```

```C
long long sumAndMultiply(int n) {
    long long x = 0, sum = 0, pow10 = 1;
    while (n > 0) {
        int d = n % 10;
        sum += d;
        if (d > 0) {
            x += d * pow10;
            pow10 *= 10;
        }
        n /= 10;
    }
    return x * sum;
}
```

```Rust
impl Solution {
    pub fn sum_and_multiply(n: i32) -> i64 {
        let mut n = n;
        let mut x: i64 = 0;
        let mut sum: i64 = 0;
        let mut pow10: i64 = 1;
        while n > 0 {
            let d = n % 10;
            sum += d as i64;
            if d > 0 {
                x += (d as i64) * pow10;
                pow10 *= 10;
            }
            n /= 10;
        }
        x * sum
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\log n)$。
- 空间复杂度：$O(1)$。
