### [最长奇偶子数组](https://leetcode.cn/problems/longest-even-odd-subarray-with-threshold/solutions/2515227/zui-chang-qi-ou-zi-shu-zu-by-leetcode-so-n97f/)

#### 方法一：枚举

令 $n$ 为整数数组 $nums$ 的长度，枚举所有子数组 $[l, r]$，其中 $0 \le l \le r \lt n$，如果子数组 $[l, r]$ 满足以下条件：

-   $nums[l] \bmod 2 = 0$
-   对于所有 $i \in [l, r - 1]$，有 $nums[i] \bmod 2 \ne nums[i + 1] \bmod 2$
-   对于所有 $i \in [l, r]$，有 $nums[i] \le threshold$

那么该子数组就是满足题目要求的奇偶子数组，取所有满足条件的子数组长度 $r - l + 1$ 的最大值。

```c++
class Solution {
public:
    bool isSatisfied(vector<int> &nums, int l, int r, int threshold) {
        if (nums[l] % 2 != 0) {
            return false;
        }
        for (int i = l; i <= r; i++) {
            if (nums[i] > threshold || (i < r && nums[i] % 2 == nums[i + 1] % 2)) {
                return false;
            }
        }
        return true;
    }

    int longestAlternatingSubarray(vector<int>& nums, int threshold) {
        int res = 0, n = nums.size();
        for (int l = 0; l < n; l++) {
            for (int r = l; r < n; r++) {
                if (isSatisfied(nums, l, r, threshold)) {
                    res = max(res, r - l + 1);
                }
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int longestAlternatingSubarray(int[] nums, int threshold) {
        int res = 0, n = nums.length;
        for (int l = 0; l < n; l++) {
            for (int r = l; r < n; r++) {
                if (isSatisfied(nums, l, r, threshold)) {
                    res = Math.max(res, r - l + 1);
                }
            }
        }
        return res;
    }

    public boolean isSatisfied(int[] nums, int l, int r, int threshold) {
        if (nums[l] % 2 != 0) {
            return false;
        }
        for (int i = l; i <= r; i++) {
            if (nums[i] > threshold || (i < r && nums[i] % 2 == nums[i + 1] % 2)) {
                return false;
            }
        }
        return true;
    }
}
```

```csharp
public class Solution {
    public int LongestAlternatingSubarray(int[] nums, int threshold) {
        int res = 0, n = nums.Length;
        for (int l = 0; l < n; l++) {
            for (int r = l; r < n; r++) {
                if (IsSatisfied(nums, l, r, threshold)) {
                    res = Math.Max(res, r - l + 1);
                }
            }
        }
        return res;
    }

    public bool IsSatisfied(int[] nums, int l, int r, int threshold) {
        if (nums[l] % 2 != 0) {
            return false;
        }
        for (int i = l; i <= r; i++) {
            if (nums[i] > threshold || (i < r && nums[i] % 2 == nums[i + 1] % 2)) {
                return false;
            }
        }
        return true;
    }
}
```

```go
func isSatisfied(nums []int, threshold int) bool {
    if nums[0] % 2 != 0 {
        return false
    }
    for i := 0; i < len(nums); i++ {
        if nums[i] > threshold || (i + 1 < len(nums) && nums[i] % 2 == nums[i + 1] % 2) {
            return false
        }
    }
    return true
}

func longestAlternatingSubarray(nums []int, threshold int) int {
    var res int
    for l := 0; l < len(nums); l++ {
        for r := l; r < len(nums); r++ {
            if isSatisfied(nums[l:r+1], threshold) && res < r - l + 1 {
                res = r - l + 1
            } 
        }
    }
    return res
}
```

```c
bool isSatisfied(int* nums, int l, int r, int threshold) {
    if (nums[l] % 2 != 0) {
        return false;
    }
    for (int i = l; i <= r; i++) {
        if (nums[i] > threshold || (i < r && nums[i] % 2 == nums[i + 1] % 2)) {
            return false;
        }
    }
    return true;
}

int longestAlternatingSubarray(int* nums, int numsSize, int threshold){
    int res = 0;
    for (int l = 0; l < numsSize; l++) {
        for (int r = l; r < numsSize; r++) {
            if (isSatisfied(nums, l, r, threshold) && res < r - l + 1) {
                res = r - l + 1;
            }
        }
    }
    return res;
}
```

```python
class Solution:
    def isSatisfied(self, nums: List[int], l: int, r: int, threshold: int) -> bool:
        if nums[l] % 2 != 0:
            return False
        for i in range(l, r + 1):
            if nums[i] > threshold or (i < r and nums[i] % 2 == nums[i + 1] % 2):
                return False
        return True

    def longestAlternatingSubarray(self, nums: List[int], threshold: int) -> int:
        res = 0
        for l in range(0, len(nums)):
            for r in range(l, len(nums)):
                if self.isSatisfied(nums, l, r, threshold):
                    res = max(res, r - l + 1)
        return res
```

```javascript
var isSatisfied = function(nums, l, r, threshold) {
    if (nums[l] % 2 != 0) {
        return false;
    }
    for (let i = l; i <= r; i++) {
        if (nums[i] > threshold || (i < r && nums[i] % 2 == nums[i + 1] % 2)) {
            return false;
        }
    }
    return true;
};

var longestAlternatingSubarray = function(nums, threshold) {
    let res = 0;
    for (let l = 0; l < nums.length; l++) {
        for (let r = 0; r < nums.length; r++) {
            if (isSatisfied(nums, l, r, threshold)) {
                res = Math.max(res, r - l + 1);
            }
        }
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(n^3)$，其中 $n$ 是 $nums$ 的长度。三重循环需要 $O(n^3)$。
-   空间复杂度：$O(1)$。

#### 方法二：动态规划

可以思考一下，在没有第一个条件 $nums[l] \bmod 2 = 0$ 时，满足剩余条件的子数组之间是什么关系？

假设以下标 $l$ 开头的满足剩余条件的最长子数组长度为 $dp_l$，那么 $dp_l$ 和 $dp_{l+1}$ 的转移关系为：

$$dp_l = \begin{cases} 0 & nums[l] \gt threshold \\ dp_{l + 1} + 1 & nums[l] \le threshold \space \&\& (\space nums[l] \bmod 2 \ne nums[l + 1] \bmod 2) \\ 1 & otherwise \\ \end{cases}$$

初始时 $dp_n = 0$。取所有满足 $nums[l] \bmod 2 = 0$ 的 $dp_l$ 的最大值。

```c++
class Solution {
public:
    int longestAlternatingSubarray(vector<int>& nums, int threshold) {
        int res = 0, dp = 0, n = nums.size();
        for (int l = n - 1; l >= 0; l--) {
            if (nums[l] > threshold) {
                dp = 0;
            } else if (l == n - 1 || nums[l] % 2 != nums[l + 1] % 2) {
                dp++;
            } else {
                dp = 1;
            }
            if (nums[l] % 2 == 0) {
                res = max(res, dp);
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int longestAlternatingSubarray(int[] nums, int threshold) {
        int res = 0, dp = 0;
        for (int l = nums.length - 1; l >= 0; l--) {
            if (nums[l] > threshold) {
                dp = 0;
            } else if (l == nums.length - 1 || nums[l] % 2 != nums[l + 1] % 2) {
                dp++;
            } else {
                dp = 1;
            }
            if (nums[l] % 2 == 0) {
                res = Math.max(res, dp);
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int LongestAlternatingSubarray(int[] nums, int threshold) {
        int res = 0, dp = 0;
        for (int l = nums.Length - 1; l >= 0; l--) {
            if (nums[l] > threshold) {
                dp = 0;
            } else if (l == nums.Length - 1 || nums[l] % 2 != nums[l + 1] % 2) {
                dp++;
            } else {
                dp = 1;
            }
            if (nums[l] % 2 == 0) {
                res = Math.Max(res, dp);
            }
        }
        return res;
    }
}
```

```go
func longestAlternatingSubarray(nums []int, threshold int) int {
    res, dp := 0, 0
    for l := len(nums) - 1; l >= 0; l-- {
        if nums[l] > threshold {
            dp = 0
        } else if l == len(nums) - 1 || nums[l] % 2 != nums[l + 1] % 2 {
            dp++
        } else {
            dp = 1
        }
        if nums[l] % 2 == 0 && dp > res {
            res = dp
        }
    }
    return res
}
```

```c
int longestAlternatingSubarray(int* nums, int numsSize, int threshold){
    int res = 0, dp = 0;
    for (int l = numsSize - 1; l >= 0; l--) {
        if (nums[l] > threshold) {
            dp = 0;
        } else if (l == numsSize - 1 || nums[l] % 2 != nums[l + 1] % 2) {
            dp++;
        } else {
            dp = 1;
        }
        if (nums[l] % 2 == 0 && dp > res) {
            res = dp;
        }
    }
    return res;
}
```

```python
class Solution:
    def longestAlternatingSubarray(self, nums: List[int], threshold: int) -> int:
        res, dp = 0, 0
        for l in range(len(nums) - 1, -1, -1):
            if nums[l] > threshold:
                dp = 0
            elif l == len(nums) - 1 or nums[l] % 2 != nums[l + 1] % 2:
                dp = dp + 1
            else:
                dp = 1
            res = dp if nums[l] % 2 == 0 and dp > res else res
        return res
```

```javascript
var longestAlternatingSubarray = function(nums, threshold) {
    let res = 0, dp = 0;
    for (let l = nums.length - 1; l >= 0; l--) {
        if (nums[l] > threshold) {
            dp = 0;
        } else if (l == nums.length - 1 || nums[l] % 2 != nums[l + 1] % 2) {
            dp++;
        } else {
            dp = 1;
        }
        if (nums[l] % 2 == 0) {
            res = Math.max(res, dp);
        }
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。遍历一次数组需要 $O(n)$。
-   空间复杂度：$O(1)$。
