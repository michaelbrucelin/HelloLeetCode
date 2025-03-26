### [k-avoiding 数组的最小总和](https://leetcode.cn/problems/determine-the-minimum-sum-of-a-k-avoiding-array/solutions/3609167/k-avoiding-shu-zu-de-zui-xiao-zong-he-by-qgul/)

#### 方法一：贪心 + 等差数列求和

**思路**

根据题目要求，在 $k$ 是奇数的情况下，如果某个正整数 $a$ 在数组中，那么 $k-a$ 肯定不能在数组中。反过来也一样。但是题目要求总和最小，因此我们肯定是将这两个数字中小的放入数组，并且从 $1$ 开始挑选数字放入数组，直到 $\Bigl\lceil \dfrac{k}{2} \Bigr\rceil$ 为止。这之后的数字到 $k-1$ 为止，都不能放入数组。如果这时数字还没到到达 $n$ 个，我们需要从 $k$ 开始，再挑选连续的 $k - \Bigl\lceil \dfrac{k}{2} \Bigr\rceil$ 个数字加入数组。因此最后的数组和是一段或者两段等差数列求和。

我们可以自己构造一个等差数列求和的函数，并按照两种情况返回结果。

**代码**

```Java
class Solution {
    public int minimumSum(int n, int k) {
        if (n <= k / 2) {
            return arithmeticSeriesSum(1, 1, n);
        } else {
            return arithmeticSeriesSum(1, 1, k / 2) + arithmeticSeriesSum(k, 1, n - k / 2);
        }
    }

    private int arithmeticSeriesSum(int a1, int d, int n) {
        return (a1 + a1 + (n - 1) * d) * n / 2;
    }
}
```

```CSharp
public class Solution {
    public int MinimumSum(int n, int k) {
        if (n <= k / 2) {
            return ArithmeticSeriesSum(1, 1, n);
        } else {
            return ArithmeticSeriesSum(1, 1, k / 2) + ArithmeticSeriesSum(k, 1, n - k / 2);
        }
    }

    private int ArithmeticSeriesSum(int a1, int d, int n) {
        return (a1 + a1 + (n - 1) * d) * n / 2;
    }
}
```

```C++
class Solution {
public:
    int minimumSum(int n, int k) {
        if (n <= k / 2) {
            return arithmeticSeriesSum(1, 1, n);
        } else {
            return arithmeticSeriesSum(1, 1, k / 2) + arithmeticSeriesSum(k, 1, n - k / 2);
        }
    }

private:
    int arithmeticSeriesSum(int a1, int d, int n) {
        return (a1 + a1 + (n - 1) * d) * n / 2;
    }
};
```

```Go
func minimumSum(n int, k int) int {
    if n <= k / 2 {
        return arithmeticSeriesSum(1, 1, n)
    } else {
        return arithmeticSeriesSum(1, 1, k / 2) + arithmeticSeriesSum(k, 1, n - k / 2)
    }
}

func arithmeticSeriesSum(a1 int, d int, n int) int {
    return (a1 + a1 + (n - 1) * d) * n / 2
}
```

```Python
class Solution:
    def minimumSum(self, n: int, k: int) -> int:
        if n <= k // 2:
            return self.arithmeticSeriesSum(1, 1, n)
        else:
            return self.arithmeticSeriesSum(1, 1, k // 2) + self.arithmeticSeriesSum(k, 1, n - k // 2)

    def arithmeticSeriesSum(self, a1: int, d: int, n: int) -> int:
        return (a1 + a1 + (n - 1) * d) * n // 2
```

```C
int arithmeticSeriesSum(int a1, int d, int n) {
    return (a1 + a1 + (n - 1) * d) * n / 2;
}

int minimumSum(int n, int k) {
    if (n <= k / 2) {
        return arithmeticSeriesSum(1, 1, n);
    } else {
        return arithmeticSeriesSum(1, 1, k / 2) + arithmeticSeriesSum(k, 1, n - k / 2);
    }
}
```

```JavaScript
var minimumSum = function(n, k) {
    if (n <= Math.floor(k / 2)) {
        return arithmeticSeriesSum(1, 1, n);
    } else {
        return arithmeticSeriesSum(1, 1, Math.floor(k / 2)) + arithmeticSeriesSum(k, 1, n - Math.floor(k / 2));
    }
};

function arithmeticSeriesSum(a1, d, n) {
    return (a1 + a1 + (n - 1) * d) * n / 2;
};
```

```TypeScript
function minimumSum(n: number, k: number): number {
    if (n <= Math.floor(k / 2)) {
        return arithmeticSeriesSum(1, 1, n);
    } else {
        return arithmeticSeriesSum(1, 1, Math.floor(k / 2)) + arithmeticSeriesSum(k, 1, n - Math.floor(k / 2));
    }
};

function arithmeticSeriesSum(a1: number, d: number, n: number): number {
    return (a1 + a1 + (n - 1) * d) * n / 2;
};
```

```Rust
impl Solution {
    pub fn minimum_sum(n: i32, k: i32) -> i32 {
        if n <= k / 2 {
            Self::arithmetic_series_sum(1, 1, n)
        } else {
            Self::arithmetic_series_sum(1, 1, k / 2) + Self::arithmetic_series_sum(k, 1, n - k / 2)
        }
    }

    fn arithmetic_series_sum(a1: i32, d: i32, n: i32) -> i32 {
        (a1 + a1 + (n - 1) * d) * n / 2
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
