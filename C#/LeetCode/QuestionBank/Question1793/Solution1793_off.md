### [好子数组的最大分数](https://leetcode.cn/problems/maximum-score-of-a-good-subarray/solutions/2688286/hao-zi-shu-zu-de-zui-da-fen-shu-by-leetc-94gx/)

#### 方法一：双指针

由于好子数组必须要包含 $\textit{nums}[k]$，那么我们可以使用两个指针 $\textit{left}$ 和 $\textit{right}$ 表示选择的子数组为 $(\textit{left}, \textit{right})$（左开右开），且 $\textit{left}$ 和 $\textit{right}$ 的初始值为 $k-1$ 和 $k+1$。

随后我们可以枚举子数组分数定义中 $\min \{ \cdots \}$ 部分的值。它的最大值为 $\textit{nums}[k]$，最小值为数组 $\textit{nums}$ 中的最小值。随后我们从大到小进行枚举，当枚举到 $i$ 时，我们可以不断向左移动 $\textit{left}$，或者向右移动 $\textit{right}$，直到：

1. 指针超出数组的边界，或者
1. 指针指向的元素小于 $i$，分数定义中的 $\min\{ \cdots \}$ 的值发生了变化。

当移动完成后，$(\textit{left}, \textit{right})$ 就是最小值**大于等于** $i$ 的一个子数组，它的分数**至少**为：

$$(\textit{right} - \textit{left} - 1) \times i$$

当 $i$ 恰好是 $(\textit{left}, \textit{right})$ 的最小值时，上式就是它对应的分数。当 $i$ 继续减少但指针没有移动时，上式计算出的分数会比正确的分数要低，但一定不会更高。因此，只要我们在枚举的过程中维护上式的最大值，就可以得到正确的答案。

当两个指针都超出数组的边界时，就可以结束枚举并返回答案。

##### 代码

```c++
class Solution {
public:
    int maximumScore(vector<int>& nums, int k) {
        int n = nums.size();
        int left = k - 1, right = k + 1;
        int ans = 0;
        for (int i = nums[k];; --i) {
            while (left >= 0 && nums[left] >= i) {
                --left;
            }
            while (right < n && nums[right] >= i) {
                ++right;
            }
            ans = max(ans, (right - left - 1) * i);
            if (left == -1 && right == n) {
                break;
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int maximumScore(int[] nums, int k) {
        int n = nums.length;
        int left = k - 1, right = k + 1;
        int ans = 0;
        for (int i = nums[k];; --i) {
            while (left >= 0 && nums[left] >= i) {
                --left;
            }
            while (right < n && nums[right] >= i) {
                ++right;
            }
            ans = Math.max(ans, (right - left - 1) * i);
            if (left == -1 && right == n) {
                break;
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int MaximumScore(int[] nums, int k) {
        int n = nums.Length;
        int left = k - 1, right = k + 1;
        int ans = 0;
        for (int i = nums[k];; --i) {
            while (left >= 0 && nums[left] >= i) {
                --left;
            }
            while (right < n && nums[right] >= i) {
                ++right;
            }
            ans = Math.Max(ans, (right - left - 1) * i);
            if (left == -1 && right == n) {
                break;
            }
        }
        return ans;
    }
}
```

```python
class Solution:
    def maximumScore(self, nums: List[int], k: int) -> int:
        n = len(nums)
        left, right = k - 1, k + 1
        ans = 0
        for i in range(nums[k], 0, -1):
            while left >= 0 and nums[left] >= i:
                left -= 1
            while right < n and nums[right] >= i:
                right += 1
            ans = max(ans, (right - left - 1) * i)
        return ans
```

```go
func maximumScore(nums []int, k int) int {
    n := len(nums)
    left, right := k - 1, k + 1
    ans := 0
    for i := nums[k]; ; i-- {
        for left >= 0 && nums[left] >= i {
            left--
        }
        for right < n && nums[right] >= i {
            right++
        }
        ans = max(ans, (right - left - 1) * i)
        if left == -1 && right == n {
            break
        }
    }
    return ans
}
```

```c
int maximumScore(int* nums, int numsSize, int k) {
    int left = k - 1, right = k + 1;
    int ans = 0;
    for (int i = nums[k];; --i) {
        while (left >= 0 && nums[left] >= i) {
            --left;
        }
        while (right < numsSize && nums[right] >= i) {
            ++right;
        }
        ans = fmax(ans, (right - left - 1) * i);
        if (left == -1 && right == numsSize) {
            break;
        }
    }
    return ans;
}
```

```javascript
var maximumScore = function(nums, k) {
    let n = nums.length;
    let left = k - 1, right = k + 1;
    let ans = 0;
    for (let i = nums[k];; --i) {
        while (left >= 0 && nums[left] >= i) {
            --left;
        }
        while (right < n && nums[right] >= i) {
            ++right;
        }
        ans = Math.max(ans, (right - left - 1) * i);
        if (left === -1 && right === n) {
            break;
        }
    }
    return ans;
};
```

```typescript
function maximumScore(nums: number[], k: number): number {
    let n = nums.length;
    let left = k - 1, right = k + 1;
    let ans = 0;
    for (let i = nums[k];; --i) {
        while (left >= 0 && nums[left] >= i) {
            --left;
        }
        while (right < n && nums[right] >= i) {
            ++right;
        }
        ans = Math.max(ans, (right - left - 1) * i);
        if (left === -1 && right === n) {
            break;
        }
    }
    return ans;
};
```

```rust
impl Solution {
    pub fn maximum_score(nums: Vec<i32>, k: i32) -> i32 {
        let n = nums.len() as i32;
        let mut left = k  - 1;
        let mut right = k  + 1;
        let mut ans = 0;
        for i in (0..= nums[k as usize]).rev() {
            while left >= 0 && left < n && nums[left as usize] >= i {
                left -= 1;
            }
            while right < n && nums[right as usize] >= i {
                right += 1;
            }
            ans = ans.max((right - left - 1) as i32 * i);
            if left == -1 && right == n {
                break;
            }
        }
        ans
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n + C)$，其中 $n$ 是数组 $\textit{nums}$ 的长度，$C$ 是数组 $\textit{nums}$ 中元素的范围。
- 空间复杂度：$O(1)$。

#### 方法二：优化的双指针

##### 思路与算法

我们可以对方法一中的代码进行优化。

方法一效率较低的原因是在 $i$ 比 $(\textit{left}, \textit{right})$ 中的最小值更小，但指针没有移动时，计算出的分数是没有意义的。指针没有移动的原因是 $\textit{nums}[\textit{left}]$ 和 $\textit{nums}[\textit{right}]$ 都小于 $i$，因此我们应当直接把 $i$ 减少至二者的较大值，而不是每次减少 $1$，这样就可以保证每一次循环中都至少会移动一次指针，就可以将 $C$ 从时间复杂度中移除。

##### 细节

在减少 $i$ 时，需要注意指针已经超出数组边界的情况。

##### 代码

```c++
class Solution {
public:
    int maximumScore(vector<int>& nums, int k) {
        int n = nums.size();
        int left = k - 1, right = k + 1;
        int ans = 0;
        for (int i = nums[k];;) {
            while (left >= 0 && nums[left] >= i) {
                --left;
            }
            while (right < n && nums[right] >= i) {
                ++right;
            }
            ans = max(ans, (right - left - 1) * i);
            if (left == -1 && right == n) {
                break;
            }
            i = max((left == -1 ? -1 : nums[left]), (right == n ? -1 : nums[right]));
            if (i == -1) {
                break;
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int maximumScore(int[] nums, int k) {
        int n = nums.length;
        int left = k - 1, right = k + 1;
        int ans = 0;
        for (int i = nums[k];;) {
            while (left >= 0 && nums[left] >= i) {
                --left;
            }
            while (right < n && nums[right] >= i) {
                ++right;
            }
            ans = Math.max(ans, (right - left - 1) * i);
            if (left == -1 && right == n) {
                break;
            }
            i = Math.max((left == -1 ? -1 : nums[left]), (right == n ? -1 : nums[right]));
            if (i == -1) {
                break;
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int MaximumScore(int[] nums, int k) {
        int n = nums.Length;
        int left = k - 1, right = k + 1;
        int ans = 0;
        for (int i = nums[k];;) {
            while (left >= 0 && nums[left] >= i) {
                --left;
            }
            while (right < n && nums[right] >= i) {
                ++right;
            }
            ans = Math.Max(ans, (right - left - 1) * i);
            if (left == -1 && right == n) {
                break;
            }
            i = Math.Max((left == -1 ? -1 : nums[left]), (right == n ? -1 : nums[right]));
            if (i == -1) {
                break;
            }
        }
        return ans;
    }
}
```

```python
class Solution:
    def maximumScore(self, nums: List[int], k: int) -> int:
        n = len(nums)
        left, right, i = k - 1, k + 1, nums[k]
        ans = 0
        while True:
            while left >= 0 and nums[left] >= i:
                left -= 1
            while right < n and nums[right] >= i:
                right += 1
            ans = max(ans, (right - left - 1) * i)
            i = max((-1 if left == -1 else nums[left]), (-1 if right == n else nums[right]))
            if i == -1:
                break
        return ans
```

```c
int maximumScore(int* nums, int numsSize, int k) {
    int left = k - 1, right = k + 1;
    int ans = 0;
    for (int i = nums[k];;) {
        while (left >= 0 && nums[left] >= i) {
            --left;
        }
        while (right < numsSize && nums[right] >= i) {
            ++right;
        }
        ans = fmax(ans, (right - left - 1) * i);
        if (left == -1 && right == numsSize) {
            break;
        }
        i = fmax((left == -1 ? -1 : nums[left]), (right == numsSize ? -1 : nums[right]));
        if (i == -1) {
            break;
        }
    }
    return ans;
}
```

```go
func maximumScore(nums []int, k int) int {
    n := len(nums)
    left, right := k - 1, k + 1
    ans := nums[k]
    for i := nums[k];; {
        for left >= 0 && nums[left] >= i {
            left--
        }
        for right < n && nums[right] >= i {
            right++
        }
        ans = max(ans, (right - left - 1) * i)
        if left == -1 && right == n {
            break
        }
        lval, rval := -1, -1
        if left != -1 {
            lval = nums[left]
        }
        if right != n {
            rval = nums[right]
        }
        i = max(lval, rval)
        if i == -1 {
            break
        }
    }
    return ans
}
```

```javascript
var maximumScore = function(nums, k) {
    let n = nums.length;
    let left = k - 1, right = k + 1;
    let ans = 0;
    for (let i = nums[k]; ;) {
        while (left >= 0 && nums[left] >= i) {
            --left;
        }
        while (right < n && nums[right] >= i) {
            ++right;
        }
        ans = Math.max(ans, (right - left - 1) * i);
        if (left === -1 && right === n) {
            break;
        }
        i = Math.max(left === -1 ? -1 : nums[left], right === n ? -1 : nums[right]);
        if (i === -1) {
            break;
        }
    }
    return ans;
};
```

```typescript
function maximumScore(nums: number[], k: number): number {
    let n = nums.length;
    let left = k - 1, right = k + 1;
    let ans = 0;
    for (let i = nums[k]; ;) {
        while (left >= 0 && nums[left] >= i) {
            --left;
        }
        while (right < n && nums[right] >= i) {
            ++right;
        }
        ans = Math.max(ans, (right - left - 1) * i);
        if (left === -1 && right === n) {
            break;
        }
        i = Math.max(left === -1 ? -1 : nums[left], right === n ? -1 : nums[right]);
        if (i === -1) {
            break;
        }
    }
    return ans;
};
```

```rust
use core::cmp::max;

impl Solution {
    pub fn maximum_score(nums: Vec<i32>, k: i32) -> i32 {
        let n = nums.len() as i32;
        let mut left = k as i32 - 1;
        let mut right = k + 1;
        let mut ans = 0;
        let mut i = nums[k as usize];
        while true {
            while left >= 0 && left < n && nums[left as usize] >= i {
                left -= 1;
            }
            while right < n && nums[right as usize] >= i {
                right += 1;
            }
            ans = ans.max((right - left - 1) * i);
            if left == -1 && right == n {
                break;
            }
            let lval = if left == -1 { -1 } else { nums[left as usize]};
            let rval = if right == n { -1 } else { nums[right as usize]};
            i = lval.max(rval);
            if i == -1 {
                break;
            }
        }
        ans
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $\textit{nums}$ 的长度。
- 空间复杂度：$O(1)$。
