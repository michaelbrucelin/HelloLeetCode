### [最小可整除数位乘积 I](https://leetcode.cn/problems/smallest-divisible-digit-product-i/solutions/4002401/zui-xiao-ke-zheng-chu-shu-wei-cheng-ji-i-43bu/)

#### 方法一：枚举

暴力枚举大于等于 $n$ 的数即可，在 $10$ 次以内必然会出现个位数为 $0$ 的整数，其数位乘积必然整除 $t$。

**思路与算法**

```C++
class Solution {
public:
    int smallestNumber(int n, int t) {
        auto check = [&](int num) -> bool {
            int product = 1;
            while (num) {
                product *= (num % 10);
                num /= 10;
                if (!product) {
                    break;
                }
            }
            return !(product % t);
        };
        while (!check(n)) {
            n++;
        }
        return n;
    }
};
```

```Go
func smallestNumber(n int, t int) int {
    check := func(num int) bool {
        product := 1
        for num > 0 {
            product *= num % 10
            num /= 10
            if product == 0 {
                break
            }
        }
        return product%t == 0
    }
    for !check(n) {
        n++
    }
    return n
}
```

```Python
class Solution:
    def smallestNumber(self, n: int, t: int) -> int:
        def check(num: int) -> bool:
            product = 1
            while num > 0:
                product *= num % 10
                num //= 10
                if product == 0:
                    break
            return product % t == 0

        while not check(n):
            n += 1
        return n
```

```Java
class Solution {
    public int smallestNumber(int n, int t) {
        while (!check(n, t)) {
            n++;
        }
        return n;
    }

    private boolean check(int num, int t) {
        int product = 1;
        while (num > 0) {
            product *= num % 10;
            num /= 10;
            if (product == 0) {
                break;
            }
        }
        return product % t == 0;
    }
}
```

```CSharp
public class Solution {
    public int SmallestNumber(int n, int t) {
        while (!Check(n, t)) {
            n++;
        }
        return n;
    }

    private bool Check(int num, int t) {
        int product = 1;
        while (num > 0) {
            product *= num % 10;
            num /= 10;
            if (product == 0) {
                break;
            }
        }
        return product % t == 0;
    }
}
```

```C
bool check(int num, int t) {
    int product = 1;
    while (num > 0) {
        product *= num % 10;
        num /= 10;
        if (product == 0) {
            break;
        }
    }
    return product % t == 0;
}

int smallestNumber(int n, int t) {
    while (!check(n, t)) {
        n++;
    }
    return n;
}
```

```JavaScript
function smallestNumber(n, t) {
    const check = (num) => {
        let product = 1;
        while (num > 0) {
            product *= num % 10;
            num = Math.floor(num / 10);
            if (product === 0) {
                break;
            }
        }
        return product % t === 0;
    };

    while (!check(n)) {
        n++;
    }
    return n;
}
```

```TypeScript
function smallestNumber(n: number, t: number): number {
    const check = (num: number): boolean => {
        let product = 1;
        while (num > 0) {
            product *= num % 10;
            num = Math.floor(num / 10);
            if (product === 0) {
                break;
            }
        }
        return product % t === 0;
    };

    while (!check(n)) {
        n++;
    }
    return n;
}
```

```Rust
impl Solution {
    pub fn smallest_number(n: i32, t: i32) -> i32 {
        fn check(num: i32, t: i32) -> bool {
            let mut product = 1;
            let mut x = num;
            while x > 0 {
                product *= x % 10;
                x /= 10;
                if product == 0 {
                    break;
                }
            }
            product % t == 0
        }

        let mut cur = n;
        while !check(cur, t) {
            cur += 1;
        }
        cur
    }
}
```

**复杂度分析**

- 时间复杂度：$O(10\log n)$，其中 $n$ 是题目给出的整数。
- 空间复杂度：$O(1)$。
