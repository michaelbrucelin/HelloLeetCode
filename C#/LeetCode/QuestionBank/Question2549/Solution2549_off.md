### [统计桌面上的不同数字](https://leetcode.cn/problems/count-distinct-numbers-on-board/solutions/2679867/tong-ji-zhuo-mian-shang-de-bu-tong-shu-z-k3ni/)

#### 方法一：模拟

我们使用数组 $\textit{nums}$ 记录桌面上已经出现的正整数，初始时 $\textit{nums}[n] = 1$ 表示桌面上只出现正整数 $n$。

每天都对桌面上已出现的数字进行遍历，对于当前遍历的数字 $x$，枚举正整数 $i \in [1, n]$，如果 $x \bmod i = 1$，那么令 $\textit{nums}[i] = 1$，即将数字 $i$ 放到桌面上。最后统计 $\textit{nums}$ 中值为 $1$ 的元素数目即可。

##### 代码

```c++
class Solution {
public:
    int distinctIntegers(int n) {
        vector<int> nums(n + 1);
        nums[n] = 1;
        for (int k = 0; k < n; k++) {
            for (int x = 1; x <= n; x++) {
                if (nums[x] == 0) {
                    continue;
                }
                for (int i = 1; i <= n; i++) {
                    if (x % i == 1) {
                        nums[i] = 1;
                    }
                }
            }
        }
        return accumulate(nums.begin(), nums.end(), 0);
    }
};
```

```go
func distinctIntegers(n int) int {
    nums := make([]int, n + 1)
    nums[n] = 1
    for k := 0; k < n; k++ {
        for x := 1; x <= n; x++ {
            if nums[x] == 0 {
                continue
            }
            for i := 1; i <= n; i++ {
                if x % i == 1 {
                    nums[i] = 1
                }
            }
        }
    }
    var res int
    for i := 1; i <= n; i++ {
        res += nums[i]
    }
    return res
}
```

```java
class Solution {
    public int distinctIntegers(int n) {
        int[] nums = new int[n + 1];
        nums[n] = 1;
        for (int k = 0; k < n; k++) {
            for (int x = 1; x <= n; x++) {
                if (nums[x] == 0) {
                    continue;
                }
                for (int i = 1; i <= n; i++) {
                    if (x % i == 1) {
                        nums[i] = 1;
                    }
                }
            }
        }
        return Arrays.stream(nums).sum();
    }
}
```

```csharp
public class Solution {
    public int DistinctIntegers(int n) {
        int[] nums = new int[n + 1];
        nums[n] = 1;
        for (int k = 0; k < n; k++) {
            for (int x = 1; x <= n; x++) {
                if (nums[x] == 0) {
                    continue;
                }
                for (int i = 1; i <= n; i++) {
                    if (x % i == 1) {
                        nums[i] = 1;
                    }
                }
            }
        }
        return nums.Sum();
    }
}
```

```python
class Solution:
    def distinctIntegers(self, n: int) -> int:
        nums = [0] * (n + 1)
        nums[n] = 1
        for _ in range(0, n):
            for x in range(1, n + 1):
                if nums[x] == 0:
                    continue
                for i in range(1, n + 1):
                    if x % i == 1:
                        nums[i] = 1
        return sum(nums)
```

```javascript
var distinctIntegers = function(n) {
    let nums = new Array(n + 1).fill(0);
    nums[n] = 1;
    for (let k = 0; k < n; k++) {
        for (let x = 1; x <= n; x++) {
            if (nums[x] == 0) {
                continue;
            }
            for (let i = 1; i <= n; i++) {
                if (x % i == 1) {
                    nums[i] = 1;
                }
            }
        }
    }
    return nums.reduce(function(t, x) {
        return t + x;
    });
};
```

```c
int distinctIntegers(int n) {
    int *nums = malloc(sizeof(int) * (n + 1));
    memset(nums, 0, sizeof(int) * (n + 1));
    nums[n] = 1;
    for (int k = 0; k < n; k++) {
        for (int x = 1; x <= n; x++) {
            if (nums[x] == 0) {
                continue;
            }
            for (int i = 1; i <= n; i++) {
                if (x % i == 1) {
                    nums[i] = 1;
                }
            }
        }
    }
    int res = 0;
    for (int i = 1; i <= n; i++) {
        res += nums[i];
    }
    free(nums);
    return res;
}
```

```typescript
function distinctIntegers(n: number): number {
    let nums = new Array(n + 1).fill(0);
    nums[n] = 1;
    for (let k = 0; k < n; k++) {
        for (let x = 1; x <= n; x++) {
            if (nums[x] == 0) {
                continue;
            }
            for (let i = 1; i <= n; i++) {
                if (x % i == 1) {
                    nums[i] = 1;
                }
            }
        }
    }
    return nums.reduce(function(t, x) {
        return t + x;
    });
};
```

```rust
impl Solution {
    pub fn distinct_integers(n: i32) -> i32 {
        let n = n as usize;
        let mut nums = vec![0; n + 1];
        nums[n] = 1;
        for _k in 0..n {
            for x in 1..=n {
                if nums[x] == 0 {
                    continue;
                }
                for i in 1..=n {
                    if x % i == 1 {
                        nums[i] = 1;
                    }
                }
            }
        }
        nums.iter().sum()
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n^3)$，其中 $n$ 是给定的正整数。最多进行不超过 $n$ 天的模拟，每一天桌面上出现不超过 $n$ 个整数，每个整数进行 $n$ 次枚举，所以时间复杂度为 $O(n^3)$。
- 空间复杂度：$O(n)$。

#### 方法二：数学

如果桌面上存在正整数 $x \gt 2$，因为 $x \bmod (x - 1) = 1$，所以在执行题目的步骤后，$x - 1$ 会出现在桌面上。对 $n$ 进行分类讨论：

- 当 $n \gt 1$ 时，那么经过多次操作后，一定可以将 $n - 1, n - 2, \ldots, 2$ 依次放到桌面上。
- 当 $n = 1$ 时，桌面只有一个数字 $1$。

##### 代码

```c++
class Solution {
public:
    int distinctIntegers(int n) {
        return n == 1 ? 1 : n - 1;
    }
};
```

```go
func distinctIntegers(n int) int {
    return max(n - 1, 1)
}
```

```java
class Solution {
    public int distinctIntegers(int n) {
        return n == 1 ? 1 : n - 1;
    }
}
```

```csharp
public class Solution {
    public int DistinctIntegers(int n) {
        return n == 1 ? 1 : n - 1;
    }
}
```

```python
class Solution:
    def distinctIntegers(self, n: int) -> int:
        return 1 if n == 1 else n - 1
```

```javascript
var distinctIntegers = function(n) {
    return n == 1 ? 1 : n - 1;
};
```

```c
int distinctIntegers(int n) {
    return n == 1 ? 1 : n - 1;
}
```

```typescript
function distinctIntegers(n: number): number {
    return n == 1 ? 1 : n - 1;
};
```

```rust
impl Solution {
    pub fn distinct_integers(n: i32) -> i32 {
        if n == 1 {
            1
        } else {
            n - 1
        }
    }
}
```

复杂度分析

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
