### [被列覆盖的最多行数](https://leetcode.cn/problems/maximum-rows-covered-by-columns/solutions/2587986/bei-lie-fu-gai-de-zui-duo-xing-shu-by-le-5kb9/)

#### 方法一：二进制枚举

##### 思路与算法

由于题目给定的 $m \times n$ 矩阵 $mat$ 的列数 $n$ 满足 $1 \le n \le 12$，所以我们可以用一个整数 $S$ 来表示当前我们选中列的序号集合：从低位到高位，第 $i$ 位为 $1$ 则表示第 $i$ 列被选择，否则表示第 $i$ 列没被选择，同时使用 $mask$ 数组表示矩阵每一行的排列情况，数组中的元素为该行二进制表示的数。然后我们可以通过枚举选择列的全部情况，得到符合题目要求的情况中被覆盖的最大行数：

- 若选择的列的序号状态 $S$ 中 $1$ 的个数不为 $numSelect$，则该情况不符合题目要求，跳过该情况。
- 否则我们计算 $mask$ 数组的每一个值与序号状态的与，若结果等于数组的值则表示该行被覆盖。计算被覆盖的行数，并全局维护该值的最大值即可。

##### 代码

```c++
class Solution {
public:
    int maximumRows(vector<vector<int>>& matrix, int numSelect) {
        int m = matrix.size();
        int n = matrix[0].size();
        vector<int> mask(m, 0);
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++){
                mask[i] += matrix[i][j] << (n - j - 1);
            }
        }
        int res = 0;
        int cur = 0;
        int limit = (1 << n);
        while ((++cur) < limit) {
            if (__builtin_popcount(cur) != numSelect) {
                continue;
            }
            int t = 0;
            for (int j = 0; j < m; j++) {
                if ((mask[j] & cur) == mask[j]) {
                    ++t;
                }
            }
            res = max(res, t);
        }
        return res;
    }
};
```

```java
class Solution {
    public int maximumRows(int[][] matrix, int numSelect) {
        int m = matrix.length;
        int n = matrix[0].length;
        int[] mask = new int[m];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++){
                mask[i] += matrix[i][j] << (n - j - 1);
            }
        }
        int res = 0;
        int cur = 0;
        int limit = (1 << n);
        while (++cur < limit) {
            if (Integer.bitCount(cur) != numSelect) {
                continue;
            }
            int t = 0;
            for (int j = 0; j < m; j++) {
                if ((mask[j] & cur) == mask[j]) {
                    ++t;
                }
            }
            res = Math.max(res, t);
        }
        return res;
    }
}
```

```go
func maximumRows(matrix [][]int, numSelect int) int {
    m, n := len(matrix), len(matrix[0])
    mask := make([]int, m)
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            mask[i] += matrix[i][j] << (n - j - 1)
        }
    }
    res, limit := 0, 1 << n
    for cur := 1; cur < limit; cur++ {
        if bits.OnesCount(uint(cur)) != numSelect {
            continue
        }
        t := 0
        for j := 0; j < m; j++ {
            if (mask[j] & cur) == mask[j] {
                t++
            }
        }
        res = max(res, t)
    }
    return res
}
```

```c
func maximumRows(matrix [][]int, numSelect int) int {
    m, n := len(matrix), len(matrix[0])
    mask := make([]int, m)
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            mask[i] += matrix[i][j] << (n - j - 1)
        }
    }
    res, limit := 0, 1 << n
    for cur := 1; cur < limit; cur++ {
        if bits.OnesCount(uint(cur)) != numSelect {
            continue
        }
        t := 0
        for j := 0; j < m; j++ {
            if (mask[j] & cur) == mask[j] {
                t++
            }
        }
        res = max(res, t)
    }
    return res
}
```

```python
class Solution:
    def maximumRows(self, matrix: List[List[int]], numSelect: int) -> int:
        m, n = len(matrix), len(matrix[0])
        mask = [sum(v << j for j, v in enumerate(row)) for i, row in enumerate(matrix)]
        res, limit = 0, 1 << n
        for cur in range(1, limit):
            if cur.bit_count() != numSelect:
                continue
            t = sum((mask[j] & cur) == mask[j] for j in range(m))
            res = max(res, t)
        return res
```

```javascript
const countOne = function(n) {
    let res = 0;
    while (n) {
        n &= (n - 1);
        res++;
    }
    return res;
}

var maximumRows = function(matrix, numSelect) {
    let m = matrix.length, n = matrix[0].length;
    const mask = new Array(m).fill(0);
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            mask[i] += matrix[i][j] << (n - 1 - j);
        }
    }
    let res = 0, cur = 0;
    const limit = (1 << n);
    while ((++cur) < limit) {
        if (countOne(cur) != numSelect) {
            continue;
        }
        let t = 0;
        for (let j = 0; j < m; j++) {
            if ((mask[j] & cur) == mask[j]) {
                ++t;
            }
        }
        res = Math.max(res, t);
    }
    return res;
};
```

#### 复杂度分析

- 时间复杂度：$O(m \times 2^n)$，其中 $m$ 和 $n$ 分别为矩阵 $matrix$ 的行数和列数。
- 空间复杂度：$O(m)$，其中 $m$ 为矩阵 $matrix$ 的行数。

#### 方法二：二进制枚举的 Gosper's Hack 优化

##### 思路与算法

「方法一」的实现中我们枚举了列的全部选择情况，其中包括很多不符合要求的情况（即选择列的数目不等于 $numSelect$），我们可以通过使用 $\text{Gosper's Hack}$ 算法进行优化（由于该算法**通常不在面试考察范围**，所以在本文中仅给出代码实现，感兴趣的读者可以通过 [链接](https://leetcode.cn/link/?target=http%3A%2F%2Fprogrammingforinsomniacs.blogspot.com%2F2018%2F03%2Fgospers-hack-explained.html) 进行学习）。通过该算法就可以在 $O(1)$ 的时间内找到下一个选中列的个数为 $numSelect$ 的集合。

##### 代码

```c++
class Solution {
public:
    int maximumRows(vector<vector<int>>& matrix, int numSelect) {
        int m = matrix.size();
        int n = matrix[0].size();
        vector<int> mask(m, 0);
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++){
                mask[i] += matrix[i][j] << (n - j - 1);
            }
        }
        int res = 0;
        int cur = (1 << numSelect) - 1;
        int limit = (1 << n);
        while (cur < limit) {
            int t = 0;
            for (int j = 0; j < m; j++) {
                if ((mask[j] & cur) == mask[j]) {
                    ++t;
                }
            }
            res = max(res, t);
            int lb = cur & -cur;
            int r = cur + lb;
            cur = ((r ^ cur) >> __builtin_ctz(lb) + 2) | r;
        }
        return res;
    }
};
```

```java
class Solution {
    public int maximumRows(int[][] matrix, int numSelect) {
        int m = matrix.length;
        int n = matrix[0].length;
        int[] mask = new int[m];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++){
                mask[i] += matrix[i][j] << (n - j - 1);
            }
        }
        int res = 0;
        int cur = (1 << numSelect) - 1;
        int limit = (1 << n);
        while (cur < limit) {
            int t = 0;
            for (int j = 0; j < m; j++) {
                if ((mask[j] & cur) == mask[j]) {
                    ++t;
                }
            }
            res = Math.max(res, t);
            int lb = cur & -cur;
            int r = cur + lb;
            cur = ((r ^ cur) >> Integer.numberOfTrailingZeros(lb) + 2) | r;
        }
        return res;
    }
}
```

```go
func maximumRows(matrix [][]int, numSelect int) int {
    m, n := len(matrix), len(matrix[0])
    mask := make([]int, m)
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            mask[i] += matrix[i][j] << (n - j - 1)
        }
    }
    res, limit := 0, 1 << n
    for cur := (1 << numSelect) - 1; cur < limit; {
        t := 0
        for j := 0; j < m; j++ {
            if (mask[j] & cur) == mask[j] {
                t++
            }
        }
        res = max(res, t)
        lb := cur & -cur
        r := cur + lb
        cur = ((r ^ cur) >> (bits.TrailingZeros(uint(lb)) + 2)) | r
    }
    return res
}
```

```c
int maximumRows(int **matrix, int matrixSize, int *matrixColSize, int numSelect) {
    int m = matrixSize, n = matrixColSize[0];
    int *mask = (int *)malloc(sizeof(int) * m);
    for (int i = 0; i < m; i++) {
        mask[i] = 0;
        for (int j = 0; j < n; j++) {
            mask[i] += matrix[i][j] << (n - 1 - j);
        }
    }
    int res = 0, limit = 1 << n;
    for (int cur = (1 << numSelect) - 1; cur < limit;) {
        int t = 0;
        for (int j = 0; j < m; j++) {
            if ((mask[j] & cur) == mask[j]) {
                t++;
            }
        }
        res = res > t ? res : t;
        int lb = cur & -cur, r = cur + lb;
        cur = ((r ^ cur) >> (__builtin_ctz(lb) + 2)) | r;
    }
    free(mask);
    return res;
}
```

```python
def count_trailing_zeros(x):
    return (x & -x).bit_length() - 1

class Solution:
    def maximumRows(self, matrix: List[List[int]], numSelect: int) -> int:
        m, n = len(matrix), len(matrix[0])
        mask = [sum(v << j for j, v in enumerate(row)) for i, row in enumerate(matrix)]
        res, cur = 0, (1 << numSelect) - 1
        limit = 1 << n
        while cur < limit:
            t = sum((mask[j] & cur) == mask[j] for j in range(m))
            res = max(res, t)
            lb = cur & -cur
            r = cur + lb
            cur = ((r ^ cur) >> count_trailing_zeros(lb) + 2) | r
        return res
```

```javascript
const countOnes = function(n) {
    let res = 0;
    while (n) {
        n &= (n - 1);
        res++;
    }
    return res;
}

const bitLength = function(n) {
    let res = 0;
    while (n) {
        n >>= 1;
        res++;
    }
    return res;
}

const countTrailingZeros = function(n) {
    return bitLength(n & -n) - 1;
}

var maximumRows = function(matrix, numSelect) {
    let m = matrix.length, n = matrix[0].length;
    const mask = new Array(m).fill(0);
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            mask[i] += matrix[i][j] << (n - 1 - j);
        }
    }
    let res = 0, cur = (1 << numSelect) - 1;
    const limit = (1 << n);
    while (cur < limit) {
        let t = 0;
        for (let j = 0; j < m; j++) {
            if ((mask[j] & cur) == mask[j]) {
                ++t;
            }
        }
        res = Math.max(res, t);
        let lb = cur & -cur;
        let r = cur + lb;
        cur = ((r ^ cur) >> countTrailingZeros(lb) + 2) | r;
    }
    return res;
};
```

#### 复杂度分析

- 时间复杂度：$O(m \times C_m^{numSelect})$，其中 $m$ 和 $n$ 分别为矩阵 $mat$ 的行数和列数, $numSelect$ 为题目要求选择的列的个数。
- 空间复杂度：$O(m)$，其中 $m$ 为矩阵 $matrix$ 的行数。
