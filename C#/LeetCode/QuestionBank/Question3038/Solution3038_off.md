### [相同分数的最大操作数目 I](https://leetcode.cn/problems/maximum-number-of-operations-with-the-same-score-i/solutions/2799053/xiang-tong-fen-shu-de-zui-da-cao-zuo-shu-wb47/)

#### 方法一：遍历

由题意可知，第一次操作的分数 $s$ 是确定的，即 $s = \textit{nums}[0] + \textit{nums}[1]$。令相同分数的操作次数为 $t$，我们从 $i = 1$ 开始，迭代步长为 $2$，对数组 $\textit{nums}$ 进行遍历：如果 $\textit{nums}[i] + \textit{nums}[i - 1] = s$，那么将最大操作次数 $t$ 加一，否则退出循环。那么 $t$ 即为所有操作分数相同的最大操作次数。

```C++
class Solution {
public:
    int maxOperations(vector<int>& nums) {
        int n = nums.size(), t = 0;
        for (int i = 1; i < n; i += 2) {
            if (nums[i] + nums[i - 1] != nums[1] + nums[0]) {
                break;
            }
            t++;
        }
        return t;
    }
};
```

```Go
func maxOperations(nums []int) int {
    n, t := len(nums), 0
    for i := 1; i < n; i += 2 {
        if nums[i] + nums[i - 1] != nums[1] + nums[0] {
            break
        }
        t++
    }
    return t
}
```

```Java
class Solution {
    public int maxOperations(int[] nums) {
        int n = nums.length, t = 0;
        for (int i = 1; i < n; i += 2) {
            if (nums[i] + nums[i - 1] != nums[1] + nums[0]) {
                break;
            }
            t++;
        }
        return t;
    }
}
```

```CSharp
public class Solution {
    public int MaxOperations(int[] nums) {
        int n = nums.Length, t = 0;
        for (int i = 1; i < n; i += 2) {
            if (nums[i] + nums[i - 1] != nums[1] + nums[0]) {
                break;
            }
            t++;
        }
        return t;
    }
}
```

```Python
class Solution:
    def maxOperations(self, nums: List[int]) -> int:
        n, t = len(nums), 0
        for i in range(1, n, 2):
            if nums[i] + nums[i - 1] != nums[1] + nums[0]:
                break
            t += 1
        return t
```

```C
int maxOperations(int* nums, int numsSize) {
    int t = 0;
    for (int i = 1; i < numsSize; i += 2) {
        if (nums[i] + nums[i - 1] != nums[1] + nums[0]) {
            break;
        }
        t++;
    }
    return t;
}
```

```JavaScript
var maxOperations = function(nums) {
    let n = nums.length, t = 0;
    for (let i = 1; i < n; i += 2) {
        if (nums[i] + nums[i - 1] != nums[1] + nums[0]) {
            break;
        }
        t++;
    }
    return t;
};
```

```TypeScript
function maxOperations(nums: number[]): number {
    let n = nums.length, t = 0;
    for (let i = 1; i < n; i += 2) {
        if (nums[i] + nums[i - 1] != nums[1] + nums[0]) {
            break;
        }
        t++;
    }
    return t;
};
```

```Rust
impl Solution {
    pub fn max_operations(nums: Vec<i32>) -> i32 {
        let mut n = nums.len();
        let mut t = 0;
        let mut i = 1;
        while i < n {
            if nums[i] + nums[i - 1] != nums[1] + nums[0] {
                break;
            }
            t += 1;
            i += 2;
        }
        return t;
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $\textit{nums}$ 的长度。
- 空间复杂度：$O(1)$。
