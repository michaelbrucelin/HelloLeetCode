### [长度为 K 的子数组的能量值 I](https://leetcode.cn/problems/find-the-power-of-k-size-subarrays-i/solutions/2973321/chang-du-wei-k-de-zi-shu-zu-de-neng-lian-vxim/?envType=daily-question&envId=2024-11-06)

#### 方法一：枚举

根据题意可知，我们需要找到长度为 $k$ 且满足**连续上升**的子数组中的最大元素，此时直接枚举数组中所有长度为 $k$ 的子数组，并判断该数组是否满足**连续**且**上升**即可。子数组满足**连续上升**，此时子数组中相邻元素的差值一定为 $1$，即满足 $nums[j]-nums[j-1]=1$。如果子数组满足**连续上升**，此时最大值即为子数组中的最后一个元素，**能量值**即为子数组的最后一个元素；如果不满足，则此时能量值为 $-1$，按照上述描述依次枚举并返回**能量值**即可。

**思路与算法**

**代码**

```C++
class Solution {
public:
    vector<int> resultsArray(vector<int>& nums, int k) {
        int n = nums.size();
        int cnt = 0;
        vector<int> ans(n - k + 1, -1);
        for (int i = 0; i <= n - k; i++) {
            bool valid = true;
            for (int j = i + 1; j < i + k; j++) {
                if (nums[j] - nums[j - 1] != 1) {
                    valid = false;
                    break;
                }
            }
            if (valid) {
                ans[i] = nums[i + k - 1];
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int[] resultsArray(int[] nums, int k) {
        int n = nums.length;
        int[] ans = new int[n - k + 1];
        Arrays.fill(ans, -1);
        for (int i = 0; i <= n - k; i++) {
            boolean valid = true;
            for (int j = i + 1; j < i + k; j++) {
                if (nums[j] - nums[j - 1] != 1) {
                    valid = false;
                    break;
                }
            }
            if (valid) {
                ans[i] = nums[i + k - 1];
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int[] ResultsArray(int[] nums, int k) {
        int n = nums.Length;
        int[] ans = new int[n - k + 1];
        Array.Fill(ans, -1);
        for (int i = 0; i <= n - k; i++) {
            bool valid = true;
            for (int j = i + 1; j < i + k; j++) {
                if (nums[j] - nums[j - 1] != 1) {
                    valid = false;
                    break;
                }
            }
            if (valid) {
                ans[i] = nums[i + k - 1];
            }
        }
        return ans;
    }
}
```

```Go
func resultsArray(nums []int, k int) []int {
    n := len(nums)
    ans := make([]int, n - k + 1)
    for i := range ans {
        ans[i] = -1
    }
    for i := 0; i <= n-k; i++ {
        valid := true
        for j := i + 1; j < i + k; j++ {
            if nums[j] - nums[j - 1] != 1 {
                valid = false
                break
            }
        }
        if valid {
            ans[i] = nums[i + k - 1]
        }
    }
    return ans
}
```

```Python
class Solution:
    def resultsArray(self, nums: List[int], k: int) -> List[int]:
        n = len(nums)
        ans = [-1] * (n - k + 1)
        for i in range(n - k + 1):
            valid = True
            for j in range(i + 1, i + k):
                if nums[j] - nums[j - 1] != 1:
                    valid = False
                    break
            if valid:
                ans[i] = nums[i + k - 1]
                
        return ans
```

```C
int* resultsArray(int* nums, int numsSize, int k, int* returnSize) {
    int n = numsSize;
    *returnSize = n - k + 1;
    int* ans = (int*)malloc(*returnSize * sizeof(int));
    for (int i = 0; i < *returnSize; i++) {
        ans[i] = -1;
    }
    for (int i = 0; i <= n - k; i++) {
        bool valid = true;
        for (int j = i + 1; j < i + k; j++) {
            if (nums[j] - nums[j - 1] != 1) {
                valid = false;
                break;
            }
        }
        if (valid) {
            ans[i] = nums[i + k - 1];
        }
    }
    return ans;
}
```

```JavaScript
var resultsArray = function(nums, k) {
    const n = nums.length;
    const ans = new Array(n - k + 1).fill(-1);
    for (let i = 0; i <= n - k; i++) {
        let valid = true;
        for (let j = i + 1; j < i + k; j++) {
            if (nums[j] - nums[j - 1] !== 1) {
                valid = false;
                break;
            }
        }
        if (valid) {
            ans[i] = nums[i + k - 1];
        }
    }
    return ans;
};
```

```TypeScript
function resultsArray(nums: number[], k: number): number[] {
    const n = nums.length;
    const ans: number[] = new Array(n - k + 1).fill(-1);
    for (let i = 0; i <= n - k; i++) {
        let valid = true;
        for (let j = i + 1; j < i + k; j++) {
            if (nums[j] - nums[j - 1] !== 1) {
                valid = false;
                break;
            }
        }
        if (valid) {
            ans[i] = nums[i + k - 1];
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn results_array(nums: Vec<i32>, k: i32) -> Vec<i32> {
        let n = nums.len();
        let mut ans = vec![-1; n - k as usize + 1];
        for i in 0..= n - k as usize {
            let mut valid = true;
            for j in i + 1..i + k as usize {
                if nums[j] - nums[j - 1] != 1 {
                    valid = false;
                    break;
                }
            }
            if valid {
                ans[i] = nums[i + k as usize - 1];
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \times k)$，$n$ 表示给定数组的长度，$k$ 表示给定的数字。我们需要枚举每个长度为 $k$ 的连续子数组，一共存在 $n-k+1$ 个长度为 $k$ 的连续子数组，对于每个长度为 $k$ 的子数组都需要判断是否满足**连续上升**，需要的时间复杂度为 $O(k)$，总的时间复杂度为 $O(n \times k)$。
- 空间复杂度：$O(1)$，除返回值外，不需要额外的空间。

#### 方法二：统计长度

**思路与算法**

实际我们不必枚举所有的子数组，根据题意可知，由于子数组如果满足**连续上升**，此时相邻元素的差值一定为 $1$，此时我们在遍历数组的同时，用一个计数器 $cnt$ 统计以当前索引 $i$ 为结尾时**连续上升**的元素个数，初始化 $cnt=0$，此时：

- 如果满足 $i=0$ 或者 $nums[i]-nums[i-1]=1$ 时，此时 $cnt=cnt+1$，即在 $nums[i-1]$ 末尾可以追加元素 $nums[i]$ 仍然满足**连续上升**；
- $nums[i]-nums[i-1]=1$ 时，此时 $cnt$ 重新置为 $1$，即在 $nums[i-1]$ 末尾无法追加 $nums[i]$；

在计算的同时，此时如果以 $nums[i]$ 为结尾的**连续上升**的元素数组如果大于等于 $k$，则当前一定存在长度为 $k$ 且以 $nums[i]$ 为结尾的**连续上升**的子数组，此时能量值即为 $nums[i]$；如果不满足，则无法构成长度为 $k$ 且**连续上升**的子数组，则当前能量值为 $-1$，返回最终统计的能量值即可。

**代码**

```C++
class Solution {
public:
    vector<int> resultsArray(vector<int>& nums, int k) {
        int n = nums.size();
        int cnt = 0;
        vector<int> ans(n - k + 1, -1);
        for (int i = 0; i < n; i++) {
            cnt = i == 0 || nums[i] - nums[i - 1] != 1 ? 1 : cnt + 1;
            if (cnt >= k) {
                ans[i - k + 1] = nums[i];
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int[] resultsArray(int[] nums, int k) {
        int n = nums.length;
        int[] ans = new int[n - k + 1];
        Arrays.fill(ans, -1);
        int cnt = 0;
        for (int i = 0; i < n; i++) {
            cnt = i == 0 || nums[i] - nums[i - 1] != 1 ? 1 : cnt + 1;
            if (cnt >= k) {
                ans[i - k + 1] = nums[i];
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int[] ResultsArray(int[] nums, int k) {
        int n = nums.Length;
        int[] ans = new int[n - k + 1];
        Array.Fill(ans, -1);
        int cnt = 0;
        for (int i = 0; i < n; i++) {
            cnt = (i == 0 || nums[i] - nums[i - 1] != 1) ? 1 : cnt + 1;
            if (cnt >= k) {
                ans[i - k + 1] = nums[i];
            }
        }
        return ans;
    }
}
```

```Go
func resultsArray(nums []int, k int) []int {
    n := len(nums)
    cnt := 0
    ans := make([]int, n - k + 1)
    for i := 0; i < n; i++ {
        if i == 0 || nums[i] - nums[i - 1] != 1 {
            cnt = 1
        } else {
            cnt++
        }
        if cnt >= k {
            ans[i - k + 1] = nums[i]
        } else if i - k + 1 >= 0 {
            ans[i - k + 1] = -1
        }
    }
    return ans
}
```

```Python
class Solution:
    def resultsArray(self, nums: List[int], k: int) -> List[int]:
        n = len(nums)
        cnt = 0
        ans = [-1] * (n - k + 1)
        for i in range(n):
            cnt = 1 if i == 0 or nums[i] - nums[i - 1] != 1 else cnt + 1
            if cnt >= k:
                ans[i - k + 1] = nums[i]
        return ans
```

```C
int* resultsArray(int* nums, int numsSize, int k, int* returnSize) {
    *returnSize = numsSize - k + 1;
    int* ans = (int*)malloc((*returnSize) * sizeof(int));
    int cnt = 0;
    for (int i = 0; i < *returnSize; i++) {
        ans[i] = -1;
    }
    for (int i = 0; i < numsSize; i++) {
        cnt = (i == 0 || nums[i] - nums[i - 1] != 1) ? 1 : cnt + 1;
        if (cnt >= k) {
            ans[i - k + 1] = nums[i];
        }
    }
    return ans;
}
```

```JavaScript
var resultsArray = function(nums, k) {
    const n = nums.length;
    let cnt = 0;
    const ans = new Array(n - k + 1).fill(-1);
    for (let i = 0; i < n; i++) {
        cnt = (i === 0 || nums[i] - nums[i - 1] !== 1) ? 1 : cnt + 1;
        if (cnt >= k) {
            ans[i - k + 1] = nums[i];
        }
    }
    return ans;
};
```

```TypeScript
function resultsArray(nums: number[], k: number): number[] {
    const n = nums.length;
    let cnt = 0;
    const ans: number[] = Array(n - k + 1).fill(-1);
    for (let i = 0; i < n; i++) {
        cnt = (i === 0 || nums[i] - nums[i - 1] !== 1) ? 1 : cnt + 1;
        if (cnt >= k) {
            ans[i - k + 1] = nums[i];
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn results_array(nums: Vec<i32>, k: i32) -> Vec<i32> {
        let n = nums.len();
        let mut cnt = 0;
        let mut ans = vec![-1; n - k as usize + 1];

        for i in 0..n {
            cnt = if i == 0 || nums[i] - nums[i - 1] != 1 { 1 } else { cnt + 1 };
            if cnt >= k {
                ans[i - k as usize + 1] = nums[i];
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，$n$ 表示给定数组的长度。只需遍历一遍数组即可。
- 空间复杂度：$O(1)$，除返回值外，不需要额外的空间。
