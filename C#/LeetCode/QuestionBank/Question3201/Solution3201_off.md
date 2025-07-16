### [找出有效子序列的最大长度 I](https://leetcode.cn/problems/find-the-maximum-length-of-valid-subsequence-i/solutions/3717152/zhao-chu-you-xiao-zi-xu-lie-de-zui-da-ch-1n3j/)

#### 方法一：枚举元素的奇偶性

**思路**

根据有效子序列的定义，可以发现，子序列中所有奇数下标的元素奇偶性相同，所有偶数下标的元素奇偶性相同。因此对于这个子序列，元素的奇偶性，一共有 $4$ 种可能，全为奇数，全为偶数，奇数下标为奇数且偶数下标为偶数，以及奇数下标为偶数且偶数下标为奇数。

我们可以枚举这四种可能性，对于每一种可能性，都遍历整个 $nums$ 数组，并计算这种可能性下，子序列的最大长度。计算时，如果当前下标的数字满足奇偶性要求，我们就贪心地将子序列长度增加 $1$。最后返回所有可能性下子序列长度的最大值。

**代码**

```Python
class Solution:
    def maximumLength(self, nums: List[int]) -> int:
        res = 0
        for pattern in [[0, 0], [0, 1], [1, 0], [1, 1]]:
            cnt = 0
            for num in nums:
                if num % 2 == pattern[cnt % 2]:
                    cnt += 1
            res = max(res, cnt)
        return res
```

```C++
class Solution {
public:
    int maximumLength(vector<int>& nums) {
        int res = 0;
        vector<vector<int>> patterns = {{0, 0}, {0, 1}, {1, 0}, {1, 1}};
        for (auto& pattern : patterns) {
            int cnt = 0;
            for (int num : nums) {
                if (num % 2 == pattern[cnt % 2]) {
                    cnt++;
                }
            }
            res = max(res, cnt);
        }
        return res;
    }
};
```

```Java
class Solution {
    public int maximumLength(int[] nums) {
        int res = 0;
        int[][] patterns = {{0, 0}, {0, 1}, {1, 0}, {1, 1}};
        for (int[] pattern : patterns) {
            int cnt = 0;
            for (int num : nums) {
                if (num % 2 == pattern[cnt % 2]) {
                    cnt++;
                }
            }
            res = Math.max(res, cnt);
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int MaximumLength(int[] nums) {
        int res = 0;
        int[,] patterns = new int[4,2]{{0, 0}, {0, 1}, {1, 0}, {1, 1}};
        for (int i = 0; i < 4; i++) {
            int cnt = 0;
            foreach (int num in nums) {
                if (num % 2 == patterns[i, cnt % 2]) {
                    cnt++;
                }
            }
            res = Math.Max(res, cnt);
        }
        return res;
    }
}
```

```Go
func maximumLength(nums []int) int {
    res := 0
    patterns := [][]int{{0, 0}, {0, 1}, {1, 0}, {1, 1}}
    for _, pattern := range patterns {
        cnt := 0
        for _, num := range nums {
            if num % 2 == pattern[cnt % 2] {
                cnt++
            }
        }
        res = max(res, cnt)
    }
    return res
}
```

```C
int maximumLength(int* nums, int numsSize) {
    int res = 0;
    int patterns[4][2] = {{0, 0}, {0, 1}, {1, 0}, {1, 1}};
    for (int i = 0; i < 4; i++) {
        int cnt = 0;
        for (int j = 0; j < numsSize; j++) {
            if (nums[j] % 2 == patterns[i][cnt % 2]) {
                cnt++;
            }
        }
        if (cnt > res) {
            res = cnt;
        }
    }
    return res;
}
```

```JavaScript
var maximumLength = function(nums) {
    let res = 0;
    const patterns = [[0, 0], [0, 1], [1, 0], [1, 1]];
    for (const pattern of patterns) {
        let cnt = 0;
        for (const num of nums) {
            if (num % 2 === pattern[cnt % 2]) {
                cnt++;
            }
        }
        res = Math.max(res, cnt);
    }
    return res;
};
```

```TypeScript
function maximumLength(nums: number[]): number {
    let res = 0;
    const patterns = [[0, 0], [0, 1], [1, 0], [1, 1]] as const;
    for (const pattern of patterns) {
        let cnt = 0;
        for (const num of nums) {
            if (num % 2 === pattern[cnt % 2]) {
                cnt++;
            }
        }
        res = Math.max(res, cnt);
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn maximum_length(nums: Vec<i32>) -> i32 {
        let mut res = 0;
        let patterns = vec![vec![0, 0], vec![0, 1], vec![1, 0], vec![1, 1]];
        for pattern in patterns {
            let mut cnt = 0;
            for num in &nums {
                if num % 2 == pattern[cnt % 2] {
                    cnt += 1;
                }
            }
            res = res.max(cnt);
        }
        res as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(1)$。
