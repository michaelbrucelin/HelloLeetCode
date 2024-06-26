### [斐波那契数列](https://leetcode.cn/problems/fei-bo-na-qi-shu-lie-lcof/solutions/976888/fei-bo-na-qi-shu-lie-by-leetcode-solutio-hbss/)

#### 方法一：动态规划

斐波那契数的边界条件是 $F(0)=0$ 和 $F(1)=1$。当 $n>1$ 时，每一项的和都等于前两项的和，因此有如下递推关系：

$$F(n)=F(n-1)+F(n-2)$$

由于斐波那契数存在递推关系，因此可以使用动态规划求解。动态规划的状态转移方程即为上述递推关系，边界条件为 $F(0)$ 和 $F(1)$。

根据状态转移方程和边界条件，可以得到时间复杂度和空间复杂度都是 $O(n)$ 的实现。由于 $F(n)$ 只和 $F(n-1)$ 与 $F(n-2)$ 有关，因此可以使用「滚动数组思想」把空间复杂度优化成 $O(1)$。**如下的代码中给出的就是这种实现。**

计算过程中，答案需要取模 $\text{e}9+7$。

![](./assets/img/Solution0126_off.gif)

##### 代码

```java
class Solution {
    public int fib(int n) {
        final int MOD = 1000000007;
        if (n < 2) {
            return n;
        }
        int p = 0, q = 0, r = 1;
        for (int i = 2; i <= n; ++i) {
            p = q; 
            q = r; 
            r = (p + q) % MOD;
        }
        return r;
    }
}
```

```csharp
public class Solution {
    public int Fib(int n) {
        const int MOD = 1000000007;
        if (n < 2) {
            return n;
        }
        int p = 0, q = 0, r = 1;
        for (int i = 2; i <= n; ++i) {
            p = q; 
            q = r; 
            r = (p + q) % MOD;
        }
        return r;
    }
}
```

```c++
class Solution {
public:
    int fib(int n) {
        int MOD = 1000000007;
        if (n < 2) {
            return n;
        }
        int p = 0, q = 0, r = 1;
        for (int i = 2; i <= n; ++i) {
            p = q; 
            q = r; 
            r = (p + q)%MOD;
        }
        return r;
    }
};
```

```javascript
var fib = function(n) {
    const MOD = 1000000007;
    if (n < 2) {
        return n;
    }
    let p = 0, q = 0, r = 1;
    for (let i = 2; i <= n; ++i) {
        p = q; 
        q = r; 
        r = (p + q) % MOD;
    }
    return r;
};
```

```go
func fib(n int) int {
    const mod int = 1e9 + 7
    if n < 2 {
        return n
    }
    p, q, r := 0, 0, 1
    for i := 2; i <= n; i++ {
        p = q
        q = r
        r = (p + q) % mod
    }
    return r
}
```

```python
class Solution:
    def fib(self, n: int) -> int:
        MOD = 10 ** 9 + 7
        if n < 2:
            return n
        p, q, r = 0, 0, 1
        for i in range(2, n + 1):
            p = q
            q = r
            r = (p + q) % MOD
        return r
```

##### 复杂度分析

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$。

#### 方法二：矩阵快速幂

方法一的时间复杂度是 $O(n)$。使用矩阵快速幂的方法可以降低时间复杂度。

首先我们可以构建这样一个递推关系：

$$\left[ \begin{matrix} 1 & 1 \\ 1 & 0 \end{matrix} \right] \left[ \begin{matrix} F(n)\\ F(n - 1) \end{matrix} \right] = \left[ \begin{matrix} F(n) + F(n - 1)\\ F(n) \end{matrix} \right] = \left[ \begin{matrix} F(n + 1)\\ F(n) \end{matrix} \right]$$

因此：

$$\left[ \begin{matrix} F(n + 1)\\ F(n) \end{matrix} \right] = \left[ \begin{matrix} 1 & 1 \\ 1 & 0 \end{matrix} \right] ^n \left[ \begin{matrix} F(1)\\ F(0) \end{matrix} \right]$$

令：

$$M = \left[ \begin{matrix} 1 & 1 \\ 1 & 0 \end{matrix} \right]$$

因此只要我们能快速计算矩阵 $M$ 的 $n$ 次幂，就可以得到 $F(n)$ 的值。如果直接求取 $M^n$，时间复杂度是 $O(n)$，可以定义矩阵乘法，然后用快速幂算法来加速这里 $M^n$ 的求取。

计算过程中，答案需要取模 $\text{e}9+7$。

##### 代码

```java
class Solution {
    static final int MOD = 1000000007;

    public int fib(int n) {
        if (n < 2) {
            return n;
        }
        int[][] q = {{1, 1}, {1, 0}};
        int[][] res = pow(q, n - 1);
        return res[0][0];
    }

    public int[][] pow(int[][] a, int n) {
        int[][] ret = {{1, 0}, {0, 1}};
        while (n > 0) {
            if ((n & 1) == 1) {
                ret = multiply(ret, a);
            }
            n >>= 1;
            a = multiply(a, a);
        }
        return ret;
    }

    public int[][] multiply(int[][] a, int[][] b) {
        int[][] c = new int[2][2];
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 2; j++) {
                c[i][j] = (int) (((long) a[i][0] * b[0][j] + (long) a[i][1] * b[1][j]) % MOD);
            }
        }
        return c;
    }
}
```

```csharp
public class Solution {
    const int MOD = 1000000007;

    public int Fib(int n) {
        if (n < 2) {
            return n;
        }
        int[,] q = {{1, 1}, {1, 0}};
        int[,] res = Pow(q, n - 1);
        return res[0, 0];
    }

    public int[,] Pow(int[,] a, int n) {
        int[,] ret = {{1, 0}, {0, 1}};
        while (n > 0) {
            if ((n & 1) == 1) {
                ret = Multiply(ret, a);
            }
            n >>= 1;
            a = Multiply(a, a);
        }
        return ret;
    }

    public int[,] Multiply(int[,] a, int[,] b) {
        int[,] c = new int[2, 2];
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 2; j++) {
                c[i, j] = (int) (((long) a[i, 0] * b[0, j] + (long) a[i, 1] * b[1, j]) % MOD);
            }
        }
        return c;
    }
}
```

```c++
class Solution {
public:
    const int MOD = 1000000007;

    int fib(int n) {
        if (n < 2) {
            return n;
        }
        vector<vector<long>> q{{1, 1}, {1, 0}};
        vector<vector<long>> res = pow(q, n - 1);
        return res[0][0];
    }

    vector<vector<long>> pow(vector<vector<long>>& a, int n) {
        vector<vector<long>> ret{{1, 0}, {0, 1}};
        while (n > 0) {
            if (n & 1) {
                ret = multiply(ret, a);
            }
            n >>= 1;
            a = multiply(a, a);
        }
        return ret;
    }

    vector<vector<long>> multiply(vector<vector<long>>& a, vector<vector<long>>& b) {
        vector<vector<long>> c{{0, 0}, {0, 0}};
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 2; j++) {
                c[i][j] = (a[i][0] * b[0][j] + a[i][1] * b[1][j]) % MOD;
            }
        }
        return c;
    }
};
```

```javascript
var fib = function(n) {
    if (n < 2) {
        return n;
    }
    const q = [[1, 1], [1, 0]];
    const res = pow(q, n - 1);
    return res[0][0];
};

const pow = (a, n) => {
    let ret = [[1, 0], [0, 1]];
    while (n > 0) {
        if ((n & 1) === 1) {
            ret = multiply(ret, a);
        }
        n >>= 1;
        a = multiply(a, a);
    }
    return ret;
}

const multiply = (a, b) => {
    const c = new Array(2).fill(0).map(() => new Array(2).fill(0));
    for (let i = 0; i < 2; i++) {
        for (let j = 0; j < 2; j++) {
            c[i][j] = (BigInt(a[i][0]) * BigInt(b[0][j]) + BigInt(a[i][1]) * BigInt(b[1][j])) % BigInt(1000000007);
        }
    }
    return c;
}
```

```go
const mod int = 1e9 + 7

type matrix [2][2]int

func multiply(a, b matrix) (c matrix) {
    for i := 0; i < 2; i++ {
        for j := 0; j < 2; j++ {
            c[i][j] = (a[i][0]*b[0][j] + a[i][1]*b[1][j]) % mod
        }
    }
    return
}

func pow(a matrix, n int) matrix {
    ret := matrix{{1, 0}, {0, 1}}
    for ; n > 0; n >>= 1 {
        if n&1 == 1 {
            ret = multiply(ret, a)
        }
        a = multiply(a, a)
    }
    return ret
}

func fib(n int) int {
    if n < 2 {
        return n
    }
    res := pow(matrix{{1, 1}, {1, 0}}, n-1)
    return res[0][0]
}
```

```python
class Solution:
    def fib(self, n: int) -> int:
        MOD = 10 ** 9 + 7
        if n < 2:
            return n

        def multiply(a: List[List[int]], b: List[List[int]]) -> List[List[int]]:
            c = [[0, 0], [0, 0]]
            for i in range(2):
                for j in range(2):
                    c[i][j] = (a[i][0] * b[0][j] + a[i][1] * b[1][j]) % MOD
            return c

        def matrix_pow(a: List[List[int]], n: int) -> List[List[int]]:
            ret = [[1, 0], [0, 1]]
            while n > 0:
                if n & 1:
                    ret = multiply(ret, a)
                n >>= 1
                a = multiply(a, a)
            return ret

        res = matrix_pow([[1, 1], [1, 0]], n - 1)
        return res[0][0]
```

##### 复杂度分析

- 时间复杂度：$O(\log n)$。
- 空间复杂度：$O(1)$。
