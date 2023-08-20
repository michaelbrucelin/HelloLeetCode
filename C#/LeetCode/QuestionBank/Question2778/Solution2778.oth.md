### [两种方法：遍历/枚举因子](https://leetcode.cn/problems/sum-of-squares-of-special-elements/solutions/2345815/bian-li-by-endlesscheng-kst7/)

[视频讲解](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1DM4y1x7bR%2F)

#### 算法一：遍历

按照题目要求计算即可。

```python
class Solution:
    def sumOfSquares(self, nums: List[int]) -> int:
        return sum(x * x for i, x in enumerate(nums, 1)
                         if len(nums) % i == 0)
```

```java
class Solution {
    public int sumOfSquares(int[] nums) {
        int ans = 0, n = nums.length;
        for (int i = 1; i <= n; i++) {
            if (n % i == 0) {
                ans += nums[i - 1] * nums[i - 1];
            }
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int sumOfSquares(vector<int> &nums) {
        int ans = 0, n = nums.size();
        for (int i = 1; i <= n; i++) {
            if (n % i == 0) {
                ans += nums[i - 1] * nums[i - 1];
            }
        }
        return ans;
    }
};
```

```go
func sumOfSquares(nums []int) (ans int) {
    for i, x := range nums {
        if len(nums)%(i+1) == 0 {
            ans += x * x
        }
    }
    return
}
```

```javascript
var sumOfSquares = function (nums) {
    const n = nums.length;
    let ans = 0;
    for (let i = 1; i <= n; i++) {
        if (n % i === 0) {
            ans += nums[i - 1] * nums[i - 1];
        }
    }
    return ans;
};
```

#### 复杂度分析

-   时间复杂度：O(n)\\mathcal{O}(n)O(n)，其中 nnn 为 nums\\textit{nums}nums 的长度。
-   空间复杂度：O(1)\\mathcal{O}(1)O(1)。仅用到若干额外变量。

#### 算法二：枚举

根据题意，iii 是 nnn 的因子，此时 ni\\dfrac{n}{i}in 也是 nnn 的因子，那么只需要枚举 n\\sqrt{n}n 以内的 iii，就可以得到大于 n\\sqrt{n}n 的另一个因子了。

```python
class Solution:
    def sumOfSquares(self, nums: List[int]) -> int:
        ans, n = 0, len(nums)
        for i in range(1, isqrt(n) + 1):
            if n % i == 0:
                ans += nums[i - 1] ** 2  # 注意数组的下标还是从 0 开始的
                if i * i < n:  # 避免重复统计
                    ans += nums[n // i - 1] ** 2
        return ans
```

```java
class Solution {
    public int sumOfSquares(int[] nums) {
        int ans = 0, n = nums.length;
        for (int i = 1; i * i <= n; i++) {
            if (n % i == 0) {
                ans += nums[i - 1] * nums[i - 1]; // 注意数组的下标还是从 0 开始的
                if (i * i < n) { // 避免重复统计
                    ans += nums[n / i - 1] * nums[n / i - 1];
                }
            }
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int sumOfSquares(vector<int> &nums) {
        int ans = 0, n = nums.size();
        for (int i = 1; i * i <= n; i++) {
            if (n % i == 0) {
                ans += nums[i - 1] * nums[i - 1]; // 注意数组的下标还是从 0 开始的
                if (i * i < n) { // 避免重复统计
                    ans += nums[n / i - 1] * nums[n / i - 1];
                }
            }
        }
        return ans;
    }
};
```

```go
func sumOfSquares(nums []int) (ans int) {
    n := len(nums)
    for i := 1; i*i <= n; i++ {
        if n%i == 0 {
            ans += nums[i-1] * nums[i-1] // 注意数组的下标还是从 0 开始的
            if i*i < n { // 避免重复统计
                ans += nums[n/i-1] * nums[n/i-1]
            }
        }
    }
    return
}
```

```javascript
var sumOfSquares = function (nums) {
    const n = nums.length;
    let ans = 0;
    for (let i = 1; i * i <= n; i++) {
        if (n % i === 0) {
            ans += nums[i - 1] * nums[i - 1]; // 注意数组的下标还是从 0 开始的
            if (i * i < n) { // 避免重复统计
                ans += nums[n / i - 1] * nums[n / i - 1];
            }
        }
    }
    return ans;
};
```

#### 复杂度分析

-   时间复杂度：O(n)\\mathcal{O}(\\sqrt{n})O(n)，其中 nnn 为 nums\\textit{nums}nums 的长度。
-   空间复杂度：O(1)\\mathcal{O}(1)O(1)。仅用到若干额外变量。
