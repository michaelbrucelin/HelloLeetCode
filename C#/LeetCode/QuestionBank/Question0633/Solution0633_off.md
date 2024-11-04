### [平方数之和](https://leetcode.cn/problems/sum-of-square-numbers/solutions/747079/ping-fang-shu-zhi-he-by-leetcode-solutio-8ydl/)

#### 前言

对于给定的非负整数 $c$，需要判断是否存在整数 $a$ 和 $b$，使得 $a^2+b^2=c$。可以枚举 $a$ 和 $b$ 所有可能的情况，时间复杂度为 $O(c^2)$。但是暴力枚举有一些情况是没有必要的。例如：当 $c=20$ 时，当 $a=1$ 的时候，枚举 $b$ 的时候，只需要枚举到 $b=5$ 就可以结束了，这是因为 $1^2+5^2=25>20$。当 $b>5$ 时，一定有 $1^2+b^2>20$。

注意到这一点，可以使用 $sqrt$ 函数或者双指针降低时间复杂度。

#### 方法一：使用 $sqrt$ 函数

在枚举 $a$ 的同时，使用 $sqrt$ 函数找出 $b$。注意：本题 $c$ 的取值范围在 $[0,2^{31}-1]$，因此在计算的过程中可能会发生 $int$ 型溢出的情况，需要使用 $long$ 型避免溢出。

```Java
class Solution {
    public boolean judgeSquareSum(int c) {
        for (long a = 0; a * a <= c; a++) {
            double b = Math.sqrt(c - a * a);
            if (b == (int) b) {
                return true;
            }
        }
        return false;
    }
}
```

```JavaScript
var judgeSquareSum = function(c) {
    for (let a = 0; a * a <= c; a++) {
        const b = Math.sqrt(c - a * a);
        if (b === parseInt(b)) {
            return true;
        }
    }
    return false;
};
```

```Go
func judgeSquareSum(c int) bool {
    for a := 0; a*a <= c; a++ {
        rt := math.Sqrt(float64(c - a*a))
        if rt == math.Floor(rt) {
            return true
        }
    }
    return false
}
```

```C++
class Solution {
public:
    bool judgeSquareSum(int c) {
        for (long a = 0; a * a <= c; a++) {
            double b = sqrt(c - a * a);
            if (b == (int)b) {
                return true;
            }
        }
        return false;
    }
};
```

```C
bool judgeSquareSum(int c) {
    for (long a = 0; a * a <= c; a++) {
        double b = sqrt(c - a * a);
        if (b == (int)b) {
            return true;
        }
    }
    return false;
}
```

```CSharp
public class Solution {
    public bool JudgeSquareSum(int c) {
        for (long a = 0; a * a <= c; a++) {
            int b = (int) Math.Sqrt(c - a * a);
            if (a * a + b * b == c) {
                return true;
            }
        }
        return false;
    }
}
```

```TypeScript
function judgeSquareSum(c: number): boolean {
    for (let a = 0; a * a <= c; a++) {
        const b = Math.sqrt(c - a * a);
        if (b === parseInt(b.toString())) {
            return true;
        }
    }
    return false;
};
```

```Rust
impl Solution {
    pub fn judge_square_sum(c: i32) -> bool {
        for a in 0..=((c as f64).sqrt() as i32) {
            let b_squared = c - a * a;
            if b_squared >= 0 {
                let b = (b_squared as f64).sqrt();
                if b.fract() == 0.0 {
                    return true;
                }
            }
        }
        false
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\sqrt{c}​)$。枚举 $a$ 的时间复杂度为 $O(\sqrt{c}​)$，对于每个 $a$ 的值，可在 $O(1)$ 的时间内寻找 $b$。
- 空间复杂度：$O(1)$。

#### 方法二：双指针

不失一般性，可以假设 $a \le b$。初始时 $a=0$，$b=\sqrt{c}$​，进行如下操作：

- 如果 $a^2+b^2=c$，我们找到了题目要求的一个解，返回 $true$；
- 如果 $a^2+b^2<c$，此时需要将 $a$ 的值加 $1$，继续查找；
- 如果 $a^2+b^2>c$，此时需要将 $b$ 的值减 $1$，继续查找。

当 $a=b$ 时，结束查找，此时如果仍然没有找到整数 $a$ 和 $b$ 满足 $a^2+b^2=c$，则说明不存在题目要求的解，返回 $false$。

```Java
class Solution {
    public boolean judgeSquareSum(int c) {
        long left = 0;
        long right = (long) Math.sqrt(c);
        while (left <= right) {
            long sum = left * left + right * right;
            if (sum == c) {
                return true;
            } else if (sum > c) {
                right--;
            } else {
                left++;
            }
        }
        return false;
    }
}
```

```JavaScript
class Solution {
    public boolean judgeSquareSum(int c) {
        long left = 0;
        long right = (long) Math.sqrt(c);
        while (left <= right) {
            long sum = left * left + right * right;
            if (sum == c) {
                return true;
            } else if (sum > c) {
                right--;
            } else {
                left++;
            }
        }
        return false;
    }
}
```

```Go
func judgeSquareSum(c int) bool {
    left, right := 0, int(math.Sqrt(float64(c)))
    for left <= right {
        sum := left*left + right*right
        if sum == c {
            return true
        } else if sum > c {
            right--
        } else {
            left++
        }
    }
    return false
}
```

```C++
class Solution {
public:
    bool judgeSquareSum(int c) {
        long left = 0;
        long right = (int)sqrt(c);
        while (left <= right) {
            long sum = left * left + right * right;
            if (sum == c) {
                return true;
            } else if (sum > c) {
                right--;
            } else {
                left++;
            }
        }
        return false;
    }
};
```

```C
bool judgeSquareSum(int c) {
    long left = 0;
    long right = (int)sqrt(c);
    while (left <= right) {
        long sum = left * left + right * right;
        if (sum == c) {
            return true;
        } else if (sum > c) {
            right--;
        } else {
            left++;
        }
    }
    return false;
}
```

```CSharp
public class Solution {
    public bool JudgeSquareSum(int c) {
        long left = 0;
        long right = (long)Math.Sqrt(c);
        while (left <= right) {
            long sum = left * left + right * right;
            if (sum == c) {
                return true;
            } else if (sum > c) {
                right--;
            } else {
                left++;
            }
        }
        return false;
    }
}
```

```TypeScript
function judgeSquareSum(c: number): boolean {
    let left = 0;
    let right = Math.floor(Math.sqrt(c));
    while (left <= right) {
        let sum = left * left + right * right;
        if (sum === c) {
            return true;
        } else if (sum > c) {
            right--;
        } else {
            left++;
        }
    }
    return false;
};
```

```Rust
impl Solution {
    pub fn judge_square_sum(c: i32) -> bool {
        let mut left = 0 as i64;
        let mut right = (c as f64).sqrt() as i64;
        while left <= right {
            let sum = (left * left + right * right) as i64;
            if sum == c as i64 {
                return true;
            } else if sum > c as i64 {
                right -= 1;
            } else {
                left += 1;
            }
        }
        false
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\sqrt{c}​)$。最坏情况下 $a$ 和 $b$ 一共枚举了 $0$ 到 $\sqrt{c}$​ 里的所有整数。
- 空间复杂度：$O(1)$。

#### 方法三：数学

费马平方和定理告诉我们：

> 一个非负整数 $c$ 如果能够表示为两个整数的平方和，当且仅当 $c$ 的所有形如 $4k+3$ 的**质因子**的幂均为偶数。

证明请见 [这里](https://leetcode.cn/link/?target=http%3A%2F%2Fwstein.org%2Fedu%2F124%2Flectures%2Flecture21%2Flecture21%2Fnode2.html)。

因此我们需要对 $c$ 进行**质因数分解**，再判断**所有**形如 $4k+3$ 的质因子的幂是否均为偶数即可。

```Java
class Solution {
    public boolean judgeSquareSum(int c) {
        for (int base = 2; base * base <= c; base++) {
            // 如果不是因子，枚举下一个
            if (c % base != 0) {
                continue;
            }

            // 计算 base 的幂
            int exp = 0;
            while (c % base == 0) {
                c /= base;
                exp++;
            }

            // 根据 Sum of two squares theorem 验证
            if (base % 4 == 3 && exp % 2 != 0) {
                return false;
            }
        }

      	// 例如 11 这样的用例，由于上面的 for 循环里 base * base <= c ，base == 11 的时候不会进入循环体
      	// 因此在退出循环以后需要再做一次判断
        return c % 4 != 3;
    }
}
```

```JavaScript
var judgeSquareSum = function(c) {
    for (let base = 2; base * base <= c; base++) {
        // 如果不是因子，枚举下一个
        if (c % base !== 0) {
            continue;
        }

        // 计算 base 的幂
        let exp = 0;
        while (c % base == 0) {
            c /= base;
            exp++;
        }

        // 根据 Sum of two squares theorem 验证
        if (base % 4 === 3 && exp % 2 !== 0) {
            return false;
        }
    }

    // 例如 11 这样的用例，由于上面的 for 循环里 base * base <= c ，base == 11 的时候不会进入循环体
    // 因此在退出循环以后需要再做一次判断
    return c % 4 !== 3;
};
```

```Go
func judgeSquareSum(c int) bool {
    for base := 2; base*base <= c; base++ {
        // 如果不是因子，枚举下一个
        if c%base > 0 {
            continue
        }

        // 计算 base 的幂
        exp := 0
        for ; c%base == 0; c /= base {
            exp++
        }

        // 根据 Sum of two squares theorem 验证
        if base%4 == 3 && exp%2 != 0 {
            return false
        }
    }

    // 例如 11 这样的用例，由于上面的 for 循环里 base * base <= c ，base == 11 的时候不会进入循环体
    // 因此在退出循环以后需要再做一次判断
    return c%4 != 3
}
```

```C++
class Solution {
public:
    bool judgeSquareSum(int c) {
        for (int base = 2; base * base <= c; base++) {
            // 如果不是因子，枚举下一个
            if (c % base != 0) {
                continue;
            }

            // 计算 base 的幂
            int exp = 0;
            while (c % base == 0) {
                c /= base;
                exp++;
            }

            // 根据 Sum of two squares theorem 验证
            if (base % 4 == 3 && exp % 2 != 0) {
                return false;
            }
        }

        // 例如 11 这样的用例，由于上面的 for 循环里 base * base <= c ，base == 11 的时候不会进入循环体
        // 因此在退出循环以后需要再做一次判断
        return c % 4 != 3;
    }
};
```

```C
bool judgeSquareSum(int c) {
    for (int base = 2; base * base <= c; base++) {
        // 如果不是因子，枚举下一个
        if (c % base != 0) {
            continue;
        }

        // 计算 base 的幂
        int exp = 0;
        while (c % base == 0) {
            c /= base;
            exp++;
        }

        // 根据 Sum of two squares theorem 验证
        if (base % 4 == 3 && exp % 2 != 0) {
            return false;
        }
    }

    // 例如 11 这样的用例，由于上面的 for 循环里 base * base <= c ，base == 11 的时候不会进入循环体
    // 因此在退出循环以后需要再做一次判断
    return c % 4 != 3;
}
```

```CSharp
public class Solution {
    public bool JudgeSquareSum(int c) {
        for (int baseNum = 2; baseNum * baseNum <= c; baseNum++) {
            // 如果不是因子，枚举下一个
            if (c % baseNum != 0) {
                continue;
            }
            // 计算 base 的幂
            int exp = 0;
            while (c % baseNum == 0) {
                c /= baseNum;
                exp++;
            }

            // 根据 Sum of two squares theorem 验证
            if (baseNum % 4 == 3 && exp % 2 != 0) {
                return false;
            }
        }

        // 例如 11 这样的用例，由于上面的 for 循环里 base * base <= c ，base == 11 的时候不会进入循环体
        // 因此在退出循环以后需要再做一次判断
        return c % 4 != 3;
    }
}
```

```TypeScript
function judgeSquareSum(c: number): boolean {
    for (let base = 2; base * base <= c; base++) {
        // 如果不是因子，枚举下一个
        if (c % base !== 0) {
            continue;
        }

        // 计算 base 的幂
        let exp = 0;
        while (c % base === 0) {
            c /= base;
            exp++;
        }

        // 根据 Sum of two squares theorem 验证
        if (base % 4 === 3 && exp % 2 !== 0) {
            return false;
        }
    }

    // 例如 11 这样的用例，由于上面的 for 循环里 base * base <= c ，base == 11 的时候不会进入循环体
    // 因此在退出循环以后需要再做一次判断
    return c % 4 !== 3;
};
```

```Rust
impl Solution {
    pub fn judge_square_sum(mut c: i32) -> bool {
        for base in 2..=((c as f64).sqrt() as i32) {
            // 如果不是因子，枚举下一个
            if c % base != 0 {
                continue;
            }

            // 计算 base 的幂
            let mut exp = 0;
            while c % base == 0 {
                c /= base;
                exp += 1;
            }

            // 根据 Sum of two squares theorem 验证
            if base % 4 == 3 && exp % 2 != 0 {
                return false;
            }
        }

        // 例如 11 这样的用例，由于上面的 for 循环里 base * base <= c ，base == 11 的时候不会进入循环体
        // 因此在退出循环以后需要再做一次判断
        c % 4 != 3
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\sqrt{c}​)$。
- 空间复杂度：$O(1)$。
