### [对角线上的质数](https://leetcode.cn/problems/prime-in-diagonal/solutions/3596904/dui-jiao-xian-shang-de-zhi-shu-by-leetco-0803/)

#### 方法一：模拟 + 判断质数

**思路**

我们遍历二维数组 $nums$ 对角线上的所有元素，并对每个元素进行判断是否为质数。判断是否为质数时，从 $2$ 到其算术平方根内的所有整数进行试除，若余数为 $0$，则不为质数。如果遍历完后发现余数均不为 $0$，则为质数。注意判断 $1$ 的边界情况。最后返回质数中的最大值。

**代码**

```Python
class Solution:
    def diagonalPrime(self, nums: List[List[int]]) -> int:
        n = len(nums)
        res = 0
        for i in range(n):
            if self.isPrime(nums[i][i]):
                res = max(res, nums[i][i])
            if self.isPrime(nums[i][n - i - 1]):
                res = max(res, nums[i][n - i - 1])
        return res
            
    def isPrime(self, num: int) -> bool:
        if num == 1:
            return False
        factor = 2
        while factor * factor <= num:
            if num % factor == 0:
                return False
            factor += 1
        return True
```

```C++
class Solution {
public:
    int diagonalPrime(vector<vector<int>>& nums) {
        int n = nums.size(), res = 0;
        for (int i = 0; i < n; i++) {
            if (isPrime(nums[i][i])) {
                res = max(res, nums[i][i]);
            }
            if (isPrime(nums[i][n - i - 1])) {
                res = max(res, nums[i][n - i - 1]);
            }
        }
        return res;
    }

    bool isPrime(int num) {
        if (num == 1) {
            return false;
        }
        int factor = 2;
        while (factor * factor <= num) {
            if (num % factor == 0) {
                return false;
            }
            factor++;
        }
        return true;
    }
};
```

```Go
func diagonalPrime(nums [][]int) int {
    n, res := len(nums), 0
    for i := 0; i < n; i++ {
        if isPrime(nums[i][i]) {
            res = max(res, nums[i][i])
        }
        if isPrime(nums[i][n - i - 1]) {
            res = max(res, nums[i][n - i - 1])
        }
    }
    return res
}

func isPrime(num int) bool {
    if num == 1 {
        return false
    }
    factor := 2
    for ; factor * factor <= num; factor++ {
        if num % factor == 0 {
            return false
        }
    }
    return true
}
```

```C
bool isPrime(int num) {
    if (num == 1) {
        return false;
    }
    int factor = 2;
    while (factor * factor <= num) {
        if (num % factor == 0) {
            return false;
        }
        factor++;
    }
    return true;
}

int diagonalPrime(int** nums, int numsSize, int* numsColSize) {
    int res = 0;
    for (int i = 0; i < numsSize; i++) {
        if (isPrime(nums[i][i])) {
            res = res > nums[i][i] ? res : nums[i][i];
        }
        if (isPrime(nums[i][numsSize - i - 1])) {
            res = res > nums[i][numsSize - i - 1] ? res : nums[i][numsSize - i - 1];
        }
    }
    return res;
}
```

```Java
class Solution {
    public int diagonalPrime(int[][] nums) {
        int n = nums.length, res = 0;
        for (int i = 0; i < n; i++) {
            if (isPrime(nums[i][i])) {
                res = Math.max(res, nums[i][i]);
            }
            if (isPrime(nums[i][n - i - 1])) {
                res = Math.max(res, nums[i][n - i - 1]);
            }
        }
        return res;
    }

    private boolean isPrime(int num) {
        if (num == 1) {
            return false;
        }
        int factor = 2;
        while (factor * factor <= num) {
            if (num % factor == 0) {
                return false;
            }
            factor++;
        }
        return true;
    }
}
```

```CSharp
public class Solution {
    public int DiagonalPrime(int[][] nums) {
        int n = nums.Length, res = 0;
        for (int i = 0; i < n; i++) {
            if (IsPrime(nums[i][i])) {
                res = Math.Max(res, nums[i][i]);
            }
            if (IsPrime(nums[i][n - i - 1])) {
                res = Math.Max(res, nums[i][n - i - 1]);
            }
        }
        return res;
    }

    private bool IsPrime(int num) {
        if (num == 1) {
            return false;
        }
        int factor = 2;
        while (factor * factor <= num) {
            if (num % factor == 0) {
                return false;
            }
            factor++;
        }
        return true;
    }
}
```

```JavaScript
var diagonalPrime = function(nums) {
    let n = nums.length, res = 0;
    for (let i = 0; i < n; i++) {
        if (isPrime(nums[i][i])) {
            res = Math.max(res, nums[i][i]);
        }
        if (isPrime(nums[i][n - i - 1])) {
            res = Math.max(res, nums[i][n - i - 1]);
        }
    }
    return res;
};

var isPrime = function(num) {
    if (num === 1) {
        return false;
    }
    let factor = 2;
    while (factor * factor <= num) {
        if (num % factor === 0) {
            return false;
        }
        factor++;
    }
    return true;
};
```

```TypeScript
function diagonalPrime(nums: number[][]): number {
    let n = nums.length, res = 0;
    for (let i = 0; i < n; i++) {
        if (isPrime(nums[i][i])) {
            res = Math.max(res, nums[i][i]);
        }
        if (isPrime(nums[i][n - i - 1])) {
            res = Math.max(res, nums[i][n - i - 1]);
        }
    }
    return res;
}

function isPrime(num: number): boolean {
    if (num === 1) {
        return false;
    }
    let factor = 2;
    while (factor * factor <= num) {
        if (num % factor === 0) {
            return false;
        }
        factor++;
    }
    return true;
}
```

```Rust
impl Solution {
    pub fn diagonal_prime(nums: Vec<Vec<i32>>) -> i32 {
        let n = nums.len();
        let mut res = 0;
        for i in 0..n {
            if Self::is_prime(nums[i][i]) {
                res = res.max(nums[i][i]);
            }
            if Self::is_prime(nums[i][n - i - 1]) {
                res = res.max(nums[i][n - i - 1]);
            }
        }
        res
    }

    fn is_prime(num: i32) -> bool {
        if num == 1 {
            return false;
        }
        let mut factor = 2;
        while factor * factor <= num {
            if num % factor == 0 {
                return false;
            }
            factor += 1;
        }
        true
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \times m​)$，其中 $n$ 是二维数组 $nums$ 的长度，$m$ 是 $nums$ 的最大值。
- 空间复杂度：$O(1)$。
