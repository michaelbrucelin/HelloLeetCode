### [两个数字的最大乘积](https://leetcode.cn/problems/maximum-product-of-two-digits/solutions/3998921/liang-ge-shu-zi-de-zui-da-cheng-ji-by-le-he6q/)

#### 方法一：逐位比较

**思路与算法**

我们可以迭代遍历数字 $n$ 的每一位十进制数字，并用两个数字 $first$ 和 $second$ 分别维护最大值和次大值，最后将它们的乘积作为答案返回。

**代码**

```C++
class Solution {
public:
    int maxProduct(int n) {
        int first = 0, second = 0;
        while (n > 0) {
            int x = n % 10;
            if (x > first) {
                second = first;
                first = x;
            } else if (x > second) {
                second = x;
            }
            n /= 10;
        }
        return first * second;
    }
};
```

```Python
class Solution:
    def maxProduct(self, n: int) -> int:
        first, second = 0, 0
        while n > 0:
            x = n % 10
            if x > first:
                first, second = x, first
            elif x > second:
                second = x
            n //= 10
        return first * second
```

```Rust
impl Solution {
    pub fn max_product(n: i32) -> i32 {
        let mut first = 0;
        let mut second = 0;
        let mut num = n;

        while num > 0 {
            let x = num % 10;
            if x > first {
                second = first;
                first = x;
            } else if x > second {
                second = x;
            }
            num /= 10;
        }

        first * second
    }
}
```

```Java
class Solution {
    public int maxProduct(int n) {
        int first = 0, second = 0;
        while (n > 0) {
            int x = n % 10;
            if (x > first) {
                second = first;
                first = x;
            } else if (x > second) {
                second = x;
            }
            n /= 10;
        }
        return first * second;
    }
}
```

```CSharp
public class Solution {
    public int MaxProduct(int n) {
        int first = 0, second = 0;
        while (n > 0) {
            int x = n % 10;
            if (x > first) {
                second = first;
                first = x;
            } else if (x > second) {
                second = x;
            }
            n /= 10;
        }
        return first * second;
    }
}
```

```Go
func maxProduct(n int) int {
    first, second := 0, 0
    for n > 0 {
        x := n % 10
        if x > first {
            second = first
            first = x
        } else if x > second {
            second = x
        }
        n /= 10
    }
    return first * second
}
```

```C
int maxProduct(int n) {
    int first = 0, second = 0;
    while (n > 0) {
        int x = n % 10;
        if (x > first) {
            second = first;
            first = x;
        } else if (x > second) {
            second = x;
        }
        n /= 10;
    }
    return first * second;
}
```

```JavaScript
var maxProduct = function(n) {
    let first = 0, second = 0;
    while (n > 0) {
        let x = n % 10;
        if (x > first) {
            second = first;
            first = x;
        } else if (x > second) {
            second = x;
        }
        n = Math.floor(n / 10);
    }
    return first * second;
}
```

```TypeScript
function maxProduct(n: number): number {
    let first: number = 0, second: number = 0;
    while (n > 0) {
        let x: number = n % 10;
        if (x > first) {
            second = first;
            first = x;
        } else if (x > second) {
            second = x;
        }
        n = Math.floor(n / 10);
    }
    return first * second;
}
```

**复杂度分析**

- 时间复杂度：$O(\log n)$。
- 空间复杂度：$O(1)$。
