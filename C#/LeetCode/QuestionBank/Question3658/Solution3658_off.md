### [奇数和与偶数和的最大公约数](https://leetcode.cn/problems/gcd-of-odd-and-even-sums/solutions/3993675/qi-shu-he-yu-ou-shu-he-de-zui-da-gong-yu-f3os/)

#### 方法一：辗转相除法

**思路与算法**

求两个数的最大公约数使用辗转相除法即可。

辗转相除法的核心原理是：两个整数的最大公约数等于**第二个数**与**第一个数除以第二个数所得余数**的最大公约数，其数学表达式如下：

$$gcd(a,b)=gcd(b,a \bmod  b)$$

定义 $gcd(a,0)=gcd(a,a)=a$，因此我们可以使用递归的方式来实现辗转相除法，对于 $gcd(x,y)$，当 $y\ne 0$ 时，$gcd(x,y)=gcd(y,x \bmod  y)$；当 $y=0$ 时，$gcd(x,y)=x$。

对于题目要求的 $sumOdd$ 和 $sumEven$，使用等差数列求和即可。

$$sumOdd=1+3+\dots +(2\times n-1)=n^2 \\ sumEven=2+4+\dots +(2\times n)=n\times (n+1)$$

```C++
class Solution {
public:
    int gcd(int x, int y) {
        return y == 0 ? x : gcd(y, x % y);
    }
    int gcdOfOddEvenSums(int n) {
        return gcd(n * n, n * (n + 1));
    }
};
```

```Go
func gcdOfOddEvenSums(n int) int {
    var gcd func(int, int) int
    gcd = func(x, y int) int {
        if y == 0 {
            return x
        }
        return gcd(y, x%y)
    }
    return gcd(n*n, n*(n+1))
}
```

```Python
class Solution:
    def gcdOfOddEvenSums(self, n: int) -> int:
        def gcd(x: int, y: int) -> int:
            return x if y == 0 else gcd(y, x % y)
        return gcd(n * n, n * (n + 1))
```

```Java
class Solution {
    private int gcd(int x, int y) {
        return y == 0 ? x : gcd(y, x % y);
    }

    public int gcdOfOddEvenSums(int n) {
        return gcd(n * n, n * (n + 1));
    }
}
```

```CSharp
public class Solution {
    private int Gcd(int x, int y) {
        return y == 0 ? x : Gcd(y, x % y);
    }

    public int GcdOfOddEvenSums(int n) {
        return Gcd(n * n, n * (n + 1));
    }
}
```

```C
static int gcd(int x, int y) {
    return y == 0 ? x : gcd(y, x % y);
}

int gcdOfOddEvenSums(int n) {
    return gcd(n * n, n * (n + 1));
}
```

```JavaScript
function gcdOfOddEvenSums(n) {
    const gcd = (x, y) => (y === 0 ? x : gcd(y, x % y));
    return gcd(n * n, n * (n + 1));
}
```

```TypeScript
function gcdOfOddEvenSums(n: number): number {
    const gcd = (x: number, y: number): number => (y === 0 ? x : gcd(y, x % y));
    return gcd(n * n, n * (n + 1));
}
```

```Rust
impl Solution {
    pub fn gcd_of_odd_even_sums(n: i32) -> i32 {
        fn gcd(x: i32, y: i32) -> i32 {
            if y == 0 {
                x
            } else {
                gcd(y, x % y)
            }
        }
        gcd(n * n, n * (n + 1))
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\log n)$，其中 $n$ 是题目给出的整数。
- 空间复杂度：$O(\log n)$，递归栈深度最坏情况下会达到 $O(\log n)$，其中 $n$ 是题目给出的整数。

#### 方法二：数学

**思路与算法**

由于 $gcd(n^2,n\times (n-1))=n\times gcd(n,n+1)$，又 $n$ 与 $n+1$ 互质，因此 $gcd(n,n+1)=1$，故 $gcd(n^2,n\times (n+1))=n$

```C++
class Solution {
public:
    int gcdOfOddEvenSums(int n) {
        return n;
    }
};
```

```Go
func gcdOfOddEvenSums(n int) int {
    return n
}
```

```Python
class Solution:
    def gcdOfOddEvenSums(self, n: int) -> int:
        return n
```

```Java
class Solution {
    public int gcdOfOddEvenSums(int n) {
        return n;
    }
}
```

```CSharp
public class Solution {
    public int GcdOfOddEvenSums(int n) {
        return n;
    }
}
```

```C
int gcdOfOddEvenSums(int n) {
    return n;
}
```

```JavaScript
function gcdOfOddEvenSums(n) {
    return n;
}
```

```TypeScript
function gcdOfOddEvenSums(n: number): number {
    return n;
}
```

```Rust
impl Solution {
    pub fn gcd_of_odd_even_sums(n: i32) -> i32 {
        n
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
