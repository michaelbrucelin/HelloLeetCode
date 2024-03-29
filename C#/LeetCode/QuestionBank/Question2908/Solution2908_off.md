### [元素和最小的山形三元组 I](https://leetcode.cn/problems/minimum-sum-of-mountain-triplets-i/solutions/2708392/yuan-su-he-zui-xiao-de-shan-xing-san-yua-82ab/)

#### 方法一：枚举

##### 思路与算法

我们直接按照题目的要求进行模拟，枚举所有三元组即可。

##### 代码

```c++
class Solution {
public:
    int minimumSum(vector<int>& nums) {
        int n = nums.size(), res = 1000;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                for (int k = j + 1; k < n; k++) {
                    if (nums[i] < nums[j] && nums[k] < nums[j]) {
                        res = min(res, nums[i] + nums[j] + nums[k]);
                    }
                }
            }
        }
        return res < 1000 ? res : -1;
    }
};
```

```java
class Solution {
    public int minimumSum(int[] nums) {
        int n = nums.length, res = 1000;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                for (int k = j + 1; k < n; k++) {
                    if (nums[i] < nums[j] && nums[k] < nums[j]) {
                        res = Math.min(res, nums[i] + nums[j] + nums[k]);
                    }
                }
            }
        }
        return res < 1000 ? res : -1;
    }
}
```

```csharp
public class Solution {
    public int MinimumSum(int[] nums) {
        int n = nums.Length, res = 1000;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                for (int k = j + 1; k < n; k++) {
                    if (nums[i] < nums[j] && nums[k] < nums[j]) {
                        res = Math.Min(res, nums[i] + nums[j] + nums[k]);
                    }
                }
            }
        }
        return res < 1000 ? res : -1;
    }
}
```

```python
class Solution:
    def minimumSum(self, nums: List[int]) -> int:
        n = len(nums)
        res = 1000
        for i in range(n):
            for j in range(i + 1, n):
                for k in range(j + 1, n):
                    if nums[i] < nums[j] and nums[k] < nums[j]:
                        res = min(res, nums[i] + nums[j] + nums[k])
        return res if res < 1000 else -1
```

```javascript
var minimumSum = function(nums) {
    const n = nums.length;
    let res = 1000;
    for (let i = 0; i < n; i++) {
        for (let j = i + 1; j < n; j++) {
            for (let k = j + 1; k < n; k++) {
                if (nums[i] < nums[j] && nums[k] < nums[j]) {
                    res = Math.min(res, nums[i] + nums[j] + nums[k]);
                }
            }
        }
    }
    return res < 1000 ? res : -1;
};
```

```typescript
function minimumSum(nums: number[]): number {
    const n = nums.length;
    let res = 1000;
    for (let i = 0; i < n; i++) {
        for (let j = i + 1; j < n; j++) {
            for (let k = j + 1; k < n; k++) {
                if (nums[i] < nums[j] && nums[k] < nums[j]) {
                    res = Math.min(res, nums[i] + nums[j] + nums[k]);
                }
            }
        }
    }
    return res < 1000 ? res : -1;
};
```

```go
func min(a, b int) int {
    if (a < b) {
        return a
    }
    return b
}

func minimumSum(nums []int) int {
    n := len(nums)
    res := 1000
    for i := 0; i < n; i++ {
        for j := i + 1; j < n; j++ {
            for k := j + 1; k < n; k++ {
                if nums[i] < nums[j] && nums[k] < nums[j] {
                    res = min(res, nums[i] + nums[j] + nums[k])
                }
            }
        }
    }
    if res < 1000 {
        return res
    }
    return -1
}
```

```c
int minimumSum(int* nums, int numsSize) {
    int res = 1000;
    for (int i = 0; i < numsSize; i++) {
        for (int j = i + 1; j < numsSize; j++) {
            for (int k = j + 1; k < numsSize; k++) {
                if (nums[i] < nums[j] && nums[k] < nums[j]) {
                    int sum = nums[i] + nums[j] + nums[k];
                    res = res < sum ? res : sum;
                }
            }
        }
    }
    return res < 1000 ? res : -1;
}
```

```rust
impl Solution {
    pub fn minimum_sum(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut res = 1000;
        for i in 0..n {
            for j in i + 1..n {
                for k in j + 1..n {
                    if nums[i] < nums[j] && nums[k] < nums[j] {
                        res = res.min(nums[i] + nums[j] + nums[k]);
                    }
                }
            }
        }
        if res < 1000 {
            res
        } else {
            -1
        }
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n^3)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(1)$。

#### 方法二：数组

##### 思路与算法

我们从左到右遍历，来求出前缀数组中的最小值，用 $\textit{left}[i]$ 来表示前 $i$ 个数字的最小值。

然后我们从右到左遍历，用 $\textit{right}$ 来表示当前数字右边的最小值。
如果一个数比左右两边最小值大时，说明找到一个山形三元组，并更新当前山形三元组的最小元素和。

最后我们返回最小元素和即可。

##### 代码

```c++
class Solution {
public:
    int minimumSum(vector<int>& nums) {
        int n = nums.size(), res = 1000, mn = 1000;
        vector<int> left(n);
        for (int i = 1; i < n; i++) {
            left[i] = mn = min(nums[i - 1], mn);
        }

        int right = nums[n - 1];
        for (int i = n - 2; i > 0; i--) {
            if (left[i] < nums[i] && nums[i] > right) {
                res = min(res, left[i] + nums[i] + right);
            }
            right = min(right, nums[i]);
        }

        return res < 1000 ? res : -1;
    }
};

```

```java
class Solution {
    public int minimumSum(int[] nums) {
        int n = nums.length, res = 1000, mn = 1000;
        int[] left = new int[n];
        for (int i = 1; i < n; i++) {
            left[i] = mn = Math.min(nums[i - 1], mn);
        }

        int right = nums[n - 1];
        for (int i = n - 2; i > 0; i--) {
            if (left[i] < nums[i] && nums[i] > right) {
                res = Math.min(res, left[i] + nums[i] + right);
            }
            right = Math.min(right, nums[i]);
        }

        return res < 1000 ? res : -1;
    }
}
```

```csharp
public class Solution {
    public int MinimumSum(int[] nums) {
        int n = nums.Length, res = 1000, mn = 1000;
        int[] left = new int[n];
        for (int i = 1; i < n; i++) {
            left[i] = mn = Math.Min(nums[i - 1], mn);
        }

        int right = nums[n - 1];
        for (int i = n - 2; i > 0; i--) {
            if (left[i] < nums[i] && nums[i] > right) {
                res = Math.Min(res, left[i] + nums[i] + right);
            }
            right = Math.Min(right, nums[i]);
        }

        return res < 1000 ? res : -1;
    }
}
```

```python
class Solution:
    def minimumSum(self, nums: List[int]) -> int:
        n = len(nums)
        res = mn = 1000
        left = [0] * n
        for i in range(1, n):
            left[i] = mn = min(nums[i - 1], mn)
        right = nums[n - 1]
        for i in range(n - 2, 0, -1):
            if left[i] < nums[i] and nums[i] > right:
                res = min(res, left[i] + nums[i] + right)
            right = min(right, nums[i])
        return res if res < 1000 else -1
```

```javascript
var minimumSum = function(nums) {
    let n = nums.length, res = 1000, mn = 1000;
    const left = [0];
    for (let i = 1; i < n; i++) {
        left[i] = mn = Math.min(nums[i - 1], mn);
    }

    let right = nums[n - 1];
    for (let i = n - 2; i > 0; i--) {
        if (left[i] < nums[i] && nums[i] > right) {
            res = Math.min(res, left[i] + nums[i] + right);
        }
        right = Math.min(right, nums[i]);
    }

    return res < 1000 ? res : -1;
};
```

```typescript
function minimumSum(nums: number[]): number {
    let n = nums.length, res = 1000, mn = 1000;
    const left = [0];
    for (let i = 1; i < n; i++) {
        left[i] = mn = Math.min(nums[i - 1], mn);
    }

    let right = nums[n - 1];
    for (let i = n - 2; i > 0; i--) {
        if (left[i] < nums[i] && nums[i] > right) {
            res = Math.min(res, left[i] + nums[i] + right);
        }
        right = Math.min(right, nums[i]);
    }

    return res < 1000 ? res : -1;
};
```

```go
func min(a, b int) int {
    if (a < b) {
        return a
    }
    return b
}

func minimumSum(nums []int) int {
    n := len(nums)
    res := 1000
    mn := 1000
    left := make([]int, n)
    left[0] = 0
    for i := 1; i < n; i++ {
        left[i] = int(math.Min(float64(nums[i - 1]), float64(mn)))
        mn = left[i]
    }

    right := nums[n - 1]
    for i := n - 2; i > 0; i-- {
        if left[i] < nums[i] && nums[i] > right {
            res = min(res, left[i] + nums[i] + right)
        }
        right = min(right, nums[i])
    }

    if res < 1000 {
        return res
    }
    return -1
}
```

```c
int minimumSum(int* nums, int numsSize) {
    int n = numsSize, res = 1000, mn = 1000;
    int left[n];
    for (int i = 1; i < n; i++) {
        left[i] = mn = (nums[i - 1] < mn) ? nums[i - 1] : mn;
    }

    int right = nums[n - 1];
    for (int i = n - 2; i > 0; i--) {
        if (left[i] < nums[i] && nums[i] > right) {
            res = (res < left[i] + nums[i] + right) ? res : left[i] + nums[i] + right;
        }
        right = (right < nums[i]) ? right : nums[i];
    }

    return res < 1000 ? res : -1;
}
```

```rust
impl Solution {
    pub fn minimum_sum(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut res = 1000;
        let mut mn = 1000;
        let mut left = vec![0; n];
        for i in 1..n {
            mn = nums[i - 1].min(mn);
            left[i]  = mn;
        }

        let mut right = nums[n - 1];
        for i in (1..n - 1).rev() {
            if left[i] < nums[i] && nums[i] > right {
                res = res.min(left[i] + nums[i] + right);
            }
            right = right.min(nums[i]);
        }

        if res < 1000 {
            return res
        }
        return -1
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(n)$，其中 $n$ 是数组的长度。
