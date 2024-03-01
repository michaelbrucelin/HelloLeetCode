### [检查数组是否存在有效划分](https://leetcode.cn/problems/check-if-there-is-a-valid-partition-for-the-array/solutions/2654315/jian-cha-shu-zu-shi-fou-cun-zai-you-xiao-8597/)

#### 方法一：动态规划

##### 思路

设数组 $\textit{nums}$ 的长度为 $n$，它至少存在一个有效划分的充要条件为：

- 前 $(n-2)$ 个元素组成的数组至少存在一个有效划分，且后两个元素相等。或
- 前 $(n-3)$ 个元素组成的数组至少存在一个有效划分，且
  - 后三个元素相等。或
  - 后三个元素连续递增，且差值为 $1$。

这样的判断可以用动态规划来解决，用一个长度为 $(n+1)$ 的数组来记录 $\textit{nums}$ 是否存在有效划分，$\textit{dp}[i]$ 表示前 $i$ 个元素组成的数组是否至少存在一个有效划分。边界情况 $dp[0]$ 恒为 $\texttt{true}$，而 $dp[n]$ 即为结果。

同时，定义两个辅助函数，$\textit{validTwo}(\textit{num}_1, \textit{nums}_2)$ 用来判断长度为 $2$ 的子数组是否满足题目的条件 $1$。$\textit{validThree}(\textit{num}_1, \textit{nums}_2, \textit{nums}_3)$ 用来判断长度为 $3$ 的子数组是否满足题目的条件 $2$ 或 $3$。

这样，动态规划的公式即为

$$\begin{aligned} \textit{dp}[i] = & (\textit{dp}[i - 2]\wedge\textit{validTwo}(\textit{nums}[i - 2], \textit{nums}[i - 1])) \vee\\&(\textit{dp}[i - 3]\wedge\textit{validThree}(\textit{nums}[i - 3], \textit{nums}[i - 2], \textit{nums}[i - 1])) \end{aligned}$$

。推导的时候需要注意下标是否越界。

##### 代码

```python
class Solution:
    def validPartition(self, nums: List[int]) -> bool:
        n = len(nums)
        dp = [False] * (n + 1)
        dp[0] = True
        for i in range(1, n + 1):
            if i >= 2:
                dp[i] = dp[i - 2] and self.validTwo(nums[i - 2], nums[i - 1])
            if i >= 3:
                dp[i] = dp[i] or (dp[i - 3] and self.validThree(nums[i - 3], nums[i - 2], nums[i - 1]))
        return dp[-1]
    
    def validTwo(self, num1: int, num2: int) -> bool:
        return num1 == num2
    
    def validThree(self, num1: int, num2: int, num3: int) -> bool:
        return (num1 == num2 == num3) or (num1 + 2 == num2 + 1 == num3)
```

```java
class Solution {
    public boolean validPartition(int[] nums) {
        int n = nums.length;
        boolean[] dp = new boolean[n + 1];
        dp[0] = true;
        for (int i = 1; i <= n; i++) {
            if (i >= 2) {
                dp[i] = dp[i - 2] && validTwo(nums[i - 2], nums[i - 1]);
            }
            if (i >= 3) {
                dp[i] = dp[i] || (dp[i - 3] && validThree(nums[i - 3], nums[i - 2], nums[i - 1]));
            }
        }
        return dp[n];
    }
    
    public boolean validTwo(int num1, int num2) {
        return num1 == num2;
    }
    
    public boolean validThree(int num1, int num2, int num3) {
        return (num1 == num2 && num1 == num3) || (num1 + 1 == num2 && num2 + 1 == num3);
    }
}
```

```chsarp
public class Solution {
    public bool ValidPartition(int[] nums) {
        int n = nums.Length;
        bool[] dp = new bool[n + 1];
        dp[0] = true;
        for (int i = 1; i <= n; i++) {
            if (i >= 2) {
                dp[i] = dp[i - 2] && validTwo(nums[i - 2], nums[i - 1]);
            }
            if (i >= 3) {
                dp[i] = dp[i] || (dp[i - 3] && validThree(nums[i - 3], nums[i - 2], nums[i - 1]));
            }
        }
        return dp[n];
    }
    
    public bool validTwo(int num1, int num2) {
        return num1 == num2;
    }
    
    public bool validThree(int num1, int num2, int num3) {
        return (num1 == num2 && num1 == num3) || (num1 + 1 == num2 && num2 + 1 == num3);
    }
}
```

```c++
class Solution {
public:
    bool validPartition(vector<int>& nums) {
        int n = nums.size();
        vector<int> dp(n + 1, false);
        dp[0] = true;
        for (int i = 1; i <= n; i++) {
            if (i >= 2) {
                dp[i] = dp[i - 2] && validTwo(nums[i - 2], nums[i - 1]);
            }
            if (i >= 3) {
                dp[i] = dp[i] || (dp[i - 3] && validThree(nums[i - 3], nums[i - 2], nums[i - 1]));
            }
        }  
        return dp[n];
    }

    bool validTwo(int num1, int num2) {
        return num1 == num2;
    }

    bool validThree(int num1, int num2, int num3) {
        return (num1 == num2 && num1 == num3) || (num1 + 1 == num2 && num2 + 1 == num3);
    }
};        
```

```c
bool validTwo(int num1, int num2) {
    return num1 == num2;
}

bool validThree(int num1, int num2, int num3) {
    return (num1 == num2 && num1 == num3) || (num1 + 1 == num2 && num2 + 1 == num3);
}

bool validPartition(int* nums, int numsSize) {
    int dp[numsSize + 1];
    memset(dp, 0, sizeof(dp));
    dp[0] = true;
    for (int i = 1; i <= numsSize; i++) {
        if (i >= 2) {
            dp[i] = dp[i - 2] && validTwo(nums[i - 2], nums[i - 1]);
        }
        if (i >= 3) {
            dp[i] = dp[i] || (dp[i - 3] && validThree(nums[i - 3], nums[i - 2], nums[i - 1]));
        }
    }  
    return dp[numsSize];
}
```

```go
func validPartition(nums []int) bool {
    n := len(nums)
    dp := make([]bool, n+1)
    dp[0] = true
    for i := 1; i <= n; i++ {
        if i >= 2 {
            dp[i] = dp[i - 2] && validTwo(nums[i - 2], nums[i - 1])
        }
        if i >= 3 {
            dp[i] = dp[i] || (dp[i - 3] && validThree(nums[i - 3], nums[i - 2], nums[i - 1]))
        }
    }
    return dp[n]
}

func validTwo(num1, num2 int) bool {
    return num1 == num2
}

func validThree(num1, num2, num3 int) bool {
    return (num1 == num2 && num1 == num3) || (num1+1 == num2 && num2+1 == num3)
}
```

```javascript
var validPartition = function(nums) {
    const n = nums.length;
    const dp = new Array(n + 1).fill(false);
    dp[0] = true;
    for (let i = 1; i <= n; i++) {
        if (i >= 2) {
            dp[i] = dp[i - 2] && validTwo(nums[i - 2], nums[i - 1]);
        }
        if (i >= 3) {
            dp[i] = dp[i] || (dp[i - 3] && validThree(nums[i - 3], nums[i - 2], nums[i - 1]));
        }
    }
    return dp[n];
};

function validTwo(num1, num2) {
    return num1 === num2;
}

function validThree(num1, num2, num3) {
    return (num1 === num2 && num1 === num3) || (num1 + 1 === num2 && num2 + 1 === num3);
}
```

```typescript
function validPartition(nums: number[]): boolean {
    const n: number = nums.length;
    const dp: boolean[] = new Array(n + 1).fill(false);
    dp[0] = true;
    for (let i = 1; i <= n; i++) {
        if (i >= 2) {
            dp[i] = dp[i - 2] && validTwo(nums[i - 2], nums[i - 1]);
        }
        if (i >= 3) {
            dp[i] = dp[i] || (dp[i - 3] && validThree(nums[i - 3], nums[i - 2], nums[i - 1]));
        }
    }
    return dp[n];
};

function validTwo(num1: number, num2: number): boolean {
    return num1 === num2;
}

function validThree(num1: number, num2: number, num3: number): boolean {
    return (num1 === num2 && num1 === num3) || (num1 + 1 === num2 && num2 + 1 === num3);
}
```

```rust
impl Solution {
    pub fn valid_partition(nums: Vec<i32>) -> bool {
        let n = nums.len();
        let mut dp = vec![false; n + 1];
        dp[0] = true;
        for i in 1..=n {
            if i >= 2 {
                dp[i] = dp[i - 2] && valid_two(nums[i - 2], nums[i - 1]);
            }
            if i >= 3 {
                dp[i] = dp[i] || (dp[i - 3] && valid_three(nums[i - 3], nums[i - 2], nums[i - 1]));
            }
        }
        dp[n]
    }
}

fn valid_two(num1: i32, num2: i32) -> bool {
    num1 == num2
}

fn valid_three(num1: i32, num2: i32, num3: i32) -> bool {
    (num1 == num2 && num1 == num3) || (num1 + 1 == num2 && num2 + 1 == num3)
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $\textit{nums}$ 的长度。我们仅遍历一次 $\textit{nums}$。
- 时间复杂度：$O(n)$。数组 $\textit{dp}$ 消耗 $O(n)$。
