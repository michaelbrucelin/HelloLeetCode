### [特殊元素平方和](https://leetcode.cn/problems/sum-of-squares-of-special-elements/solutions/4039936/te-shu-yuan-su-ping-fang-he-by-leetcode-99hrd/)

#### 方法一：枚举

**思路与算法**

我们枚举所有下标，将特殊元素的平方累加即可。

在代码实现中，数组下标从 $0$ 开始，因此当下标为 $i$ 时，需要判断 $n$ 是否能被 $i+1$ 整除。

**代码**

```C++
class Solution {
public:
    int sumOfSquares(vector<int>& nums) {
        int n = nums.size();
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            if (n % (i + 1) == 0) {
                ans += nums[i] * nums[i];
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def sumOfSquares(self, nums: List[int]) -> int:
        n = len(nums)
        ans = 0
        for i in range(n):
            if n % (i + 1) == 0:
                ans += nums[i] ** 2
        return ans
```

```Java
class Solution {
    public int sumOfSquares(int[] nums) {
        int n = nums.length;
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            if (n % (i + 1) == 0) {
                ans += nums[i] * nums[i];
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int SumOfSquares(int[] nums) {
        int n = nums.Length;
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            if (n % (i + 1) == 0) {
                ans += nums[i] * nums[i];
            }
        }
        return ans;
    }
}
```

```Go
func sumOfSquares(nums []int) int {
    n := len(nums)
    ans := 0
    for i := 0; i < n; i++ {
        if n%(i+1) == 0 {
            ans += nums[i] * nums[i]
        }
    }
    return ans
}
```

```C
int sumOfSquares(int* nums, int numsSize) {
    int n = numsSize;
    int ans = 0;
    for (int i = 0; i < n; ++i) {
        if (n % (i + 1) == 0) {
            ans += nums[i] * nums[i];
        }
    }
    return ans;
}
```

```JavaScript
var sumOfSquares = function(nums) {
    const n = nums.length;
    let ans = 0;
    for (let i = 0; i < n; ++i) {
        if (n % (i + 1) === 0) {
            ans += nums[i] * nums[i];
        }
    }
    return ans;
};
```

```TypeScript
function sumOfSquares(nums: number[]): number {
    const n: number = nums.length;
    let ans: number = 0;
    for (let i = 0; i < n; ++i) {
        if (n % (i + 1) === 0) {
            ans += nums[i] * nums[i];
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn sum_of_squares(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut ans = 0;
        for i in 0..n {
            if n % (i + 1) == 0 {
                ans += nums[i] * nums[i];
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(1)$。

#### 方法二：枚举因数

**思路与算法**

由于只有 $n$ 的因数对应的元素是特殊元素，我们可以只枚举这些因数。

枚举 $i=1,2,\dots ,\lfloor\sqrt{n}\rfloor $。若 $i$ 整除 $n$，则 $i$ 与 $\dfrac{n}{i}$ 都是 $n$ 的因数，将 $nums[i-1]$ 与 $nums[\dfrac{n}{i}-1]$ 的平方加入答案。

当 $i^2=n$ 时，两个因数相同，只计算一次。

**代码**

```C++
class Solution {
public:
    int sumOfSquares(vector<int>& nums) {
        int n = nums.size();
        int ans = 0;
        for (int i = 1; i * i <= n; ++i) {
            if (n % i == 0) {
                ans += nums[i - 1] * nums[i - 1];
                if (i * i != n) {
                    ans += nums[n / i - 1] * nums[n / i - 1];
                }
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def sumOfSquares(self, nums: List[int]) -> int:
        n = len(nums)
        ans = 0
        i = 1
        while i * i <= n:
            if n % i == 0:
                ans += nums[i - 1] * nums[i - 1]
                if i * i != n:
                    ans += nums[n // i - 1] ** 2
            i += 1
        return ans
```

```Java
class Solution {
    public int sumOfSquares(int[] nums) {
        int n = nums.length;
        int ans = 0;
        for (int i = 1; i * i <= n; ++i) {
            if (n % i == 0) {
                ans += nums[i - 1] * nums[i - 1];
                if (i * i != n) {
                    ans += nums[n / i - 1] * nums[n / i - 1];
                }
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int SumOfSquares(int[] nums) {
        int n = nums.Length;
        int ans = 0;
        for (int i = 1; i * i <= n; ++i) {
            if (n % i == 0) {
                ans += nums[i - 1] * nums[i - 1];
                if (i * i != n) {
                    ans += nums[n / i - 1] * nums[n / i - 1];
                }
            }
        }
        return ans;
    }
}
```

```Go
func sumOfSquares(nums []int) int {
    n := len(nums)
    ans := 0
    for i := 1; i*i <= n; i++ {
        if n%i == 0 {
            ans += nums[i-1] * nums[i-1]
            if i*i != n {
                ans += nums[n/i-1] * nums[n/i-1]
            }
        }
    }
    return ans
}
```

```C
int sumOfSquares(int* nums, int numsSize) {
    int n = numsSize;
    int ans = 0;
    for (int i = 1; i * i <= n; ++i) {
        if (n % i == 0) {
            ans += nums[i - 1] * nums[i - 1];
            if (i * i != n) {
                ans += nums[n / i - 1] * nums[n / i - 1];
            }
        }
    }
    return ans;
}
```

```JavaScript
var sumOfSquares = function(nums) {
    const n = nums.length;
    let ans = 0;
    for (let i = 1; i * i <= n; ++i) {
        if (n % i === 0) {
            ans += nums[i - 1] * nums[i - 1];
            if (i * i !== n) {
                ans += nums[n / i - 1] * nums[n / i - 1];
            }
        }
    }
    return ans;
};
```

```TypeScript
function sumOfSquares(nums: number[]): number {
    const n: number = nums.length;
    let ans: number = 0;
    for (let i = 1; i * i <= n; ++i) {
        if (n % i === 0) {
            ans += nums[i - 1] * nums[i - 1];
            if (i * i !== n) {
                ans += nums[n / i - 1] * nums[n / i - 1];
            }
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn sum_of_squares(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut ans = 0;
        let mut i = 1;
        while i * i <= n {
            if n % i == 0 {
                ans += nums[i - 1] * nums[i - 1];
                if i * i != n {
                    let j = n / i;
                    ans += nums[j - 1] * nums[j - 1];
                }
            }
            i += 1;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\sqrt{n})$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(1)$。
