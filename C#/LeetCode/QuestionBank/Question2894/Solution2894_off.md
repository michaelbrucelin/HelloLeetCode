### [分类求和并作差](https://leetcode.cn/problems/divisible-and-non-divisible-sums-difference/solutions/3676585/fen-lei-qiu-he-bing-zuo-chai-by-leetcode-xok4/)

#### 方法一：遍历

**思路及解法**

已知:

$num_1$ 是 $[1,n]$ 中无法被 $m$ 整除的整数之和。

$num_2$ 是 $[1,n]$ 中可以被 $m$ 整除的整数之和。

于是我们可以定义一个整型数据 $ans$ 来保存结果。

在遍历 $[1,n]$ 中整数的过程中，遇见无法被 $m$ 整除的整数时便使 $ans$ 加上这个整数，反之使 $ans$ 减去这个整数。

最终得到的 $ans$ 就是题目所要求的。

**代码**

```C++
class Solution {
public:
    int differenceOfSums(int n, int m) {
        int ans = 0;
        for (int i = 1; i <= n; i++) {
            if (i % m == 0) {
                ans -= i;
            } else {
                ans += i;
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def differenceOfSums(self, n: int, m: int) -> int:
        return sum(x if x % m != 0 else -x for x in range(1, n + 1))
```

```Java
class Solution {
    public int differenceOfSums(int n, int m) {
        int ans = 0;
        for (int i = 1; i <= n; i++) {
            if (i % m == 0) {
                ans -= i;
            } else {
                ans += i;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int DifferenceOfSums(int n, int m) {
        int ans = 0;
        for (int i = 1; i <= n; i++) {
            if (i % m == 0) {
                ans -= i;
            } else {
                ans += i;
            }
        }
        return ans;
    }
}
```

```Go
func differenceOfSums(n int, m int) int {
    ans := 0
    for i := 1; i <= n; i++ {
        if i % m == 0 {
            ans -= i
        } else {
            ans += i
        }
    }
    return ans
}
```

```C
int differenceOfSums(int n, int m) {
    int ans = 0;
    for (int i = 1; i <= n; i++) {
        if (i % m == 0) {
            ans -= i;
        } else {
            ans += i;
        }
    }
    return ans;
}
```

```JavaScript
var differenceOfSums = function(n, m) {
    let ans = 0;
    for (let i = 1; i <= n; i++) {
        if (i % m === 0) {
            ans -= i;
        } else {
            ans += i;
        }
    }
    return ans;
}
```

```TypeScript
function differenceOfSums(n: number, m: number): number {
    let ans = 0;
    for (let i = 1; i <= n; i++) {
        if (i % m === 0) {
            ans -= i;
        } else {
            ans += i;
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn difference_of_sums(n: i32, m: i32) -> i32 {
        let mut ans = 0;
        for i in 1..=n {
            if i % m == 0 {
                ans -= i;
            } else {
                ans += i;
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为给定数字。
- 空间复杂度：$O(1)$，申请了一个整型数据 $ans$。

#### 方法二：数学推导

**思路及解法**

对于 $num_2$，有：

$$\begin{array}{rcl} num_2 & = & m+2 \times m+\dots+k \times m \\ & = & (1+2+\dots+k) \times m \\ & = & \dfrac{k \times (k+1)}{2} \times m \end{array}$$

其中：

$$k=\dfrac{n}{m}$$

而对于 $num_1$，有：

$$\begin{array}{rcl}num_1 & = & (1+2+\dots+n)-num_2 \\ & = & \dfrac{n \times (n+1)}{2}-num_2\end{array}$$

由此可知：

$$\begin{array}{rcl}num_1-num_2 & = & \dfrac{n \times (n+1)}{2}-2 \times num_2 \\ & = & \dfrac{n \times (n+1)}{2}-k \times (k+1) \times m\end{array}$$

**代码**

```C++
class Solution {
public:
    int differenceOfSums(int n, int m) {
        int k = n / m;
        return n * (n + 1) / 2 - k * (k + 1) * m;
    }
};
```

```Python
class Solution:
    def differenceOfSums(self, n: int, m: int) -> int:
        k = n // m
        return n * (n + 1) // 2 - k * (k + 1) * m
```

```Java
class Solution {
    public int differenceOfSums(int n, int m) {
        int k = n / m;
        return n * (n + 1) / 2 - k * (k + 1) * m;
    }
}
```

```CSharp
public class Solution {
    public int DifferenceOfSums(int n, int m) {
        int k = n / m;
        return n * (n + 1) / 2 - k * (k + 1) * m;
    }
}
```

```Go
func differenceOfSums(n int, m int) int {
    k := n / m
    return n * (n + 1) / 2 - k * (k + 1) * m
}
```

```C
int differenceOfSums(int n, int m) {
    int k = n / m;
    return n * (n + 1) / 2 - k * (k + 1) * m;
}
```

```JavaScript
var differenceOfSums = function(n, m) {
    const k = Math.floor(n / m);
    return n * (n + 1) / 2 - k * (k + 1) * m;
}
```

```TypeScript
function differenceOfSums(n: number, m: number): number {
    const k = Math.floor(n / m);
    return n * (n + 1) / 2 - k * (k + 1) * m;
};
```

```Rust
impl Solution {
    pub fn difference_of_sums(n: i32, m: i32) -> i32 {
        let k = n / m;
        n * (n + 1) / 2 - k * (k + 1) * m
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$，申请了一个整型数据 $k$。
