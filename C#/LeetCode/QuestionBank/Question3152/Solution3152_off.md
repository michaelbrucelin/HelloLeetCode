### [特殊数组 II](https://leetcode.cn/problems/special-array-ii/solutions/2877223/te-shu-shu-zu-ii-by-leetcode-solution-ozu1/)

#### 方法一：动态规划

**思路与算法**

最直接的办法则是分别计算每个查询区间 $[i,j],i \le j$ 是否为**特殊数组**，此时需要的时间复杂度则为 $O(n^2)$，需要进行优化。我们知道对于任意的**特殊数组** $nums[i \ldots j]$，则该数组的任意连续子数组也一定也是**特殊数组**，因此我们只需要检测以 $j$ 为结尾的最长**特殊子数组**是否可以覆盖区间 $[i,j]$。假设我们已知以索引 $j$ 为结尾的最长**特殊数组**的长度 $dp[j]$，此时只需要判断 $dp[j]$ 是否大于等于区间 $[i,j]$ 的长度即可，即此时是否满足 $dp[j] \ge j-i+1$，如果满足，则此时 $nums[i \ldots j]$ 一定为**特殊子数组**。

根据题意可以知，对于每个索引 $i$ 的最长**特殊数组**的长度 $dp[i]$ 计算方法如下：

- 如果 $nums[i]$ 与左边相邻的元素 $nums[i-1]$ 奇偶性相同，则此时 $dp[i]=1$;
- 如果 $nums[i]$ 与左边相邻的元素 $nums[i-1]$ 奇偶性不同，则此时 $nums[i]$ 可以追加到以 $nums[i-1]$ 为结尾的最长**特殊数组**的后面，则 $dp[i]=dp[i-1]+1$;
- 在判断两个元素奇偶性是否相同时，可以利用位运算来实现，对于给定的元素 $a,b$，当满足 $(a \oplus b)\&1=1$ 时，则 $a,b$ 的奇偶性不同，否则奇偶性相同；

根据上述方法依次检测每个查询区间是否满足**特殊数组**要求，并返回结果即可。

**代码**

```C++
class Solution {
public:
    vector<bool> isArraySpecial(vector<int>& nums, vector<vector<int>>& queries) {
        int n = nums.size();
        vector<int> dp(n, 1);
        for (int i = 1; i < n; i++) {
            if ((nums[i] ^ nums[i - 1]) & 1) {
                dp[i] = dp[i - 1] + 1;
            }
        }
        
        vector<bool> res;
        for (auto &q : queries) {
            int x = q[0], y = q[1];
            res.emplace_back(dp[y] >= y - x + 1);
        }
        return res;
    }
};
```

```Java
class Solution {
    public boolean[] isArraySpecial(int[] nums, int[][] queries) {
        int n = nums.length;
        int[] dp = new int[n];
        Arrays.fill(dp, 1);
        for (int i = 1; i < n; i++) {
            if (((nums[i] ^ nums[i - 1]) & 1) != 0) {
                dp[i] = dp[i - 1] + 1;
            }
        }
        
        boolean[] res = new boolean[queries.length];
        for (int i = 0; i < queries.length; i++) {
            int x = queries[i][0], y = queries[i][1];
            res[i] = dp[y] >= y - x + 1;
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public bool[] IsArraySpecial(int[] nums, int[][] queries) {
        int n = nums.Length;
        int[] dp = new int[n];
        Array.Fill(dp, 1);
        for (int i = 1; i < n; i++) {
            if (((nums[i] ^ nums[i - 1]) & 1) != 0) {
                dp[i] = dp[i - 1] + 1;
            }
        }

        bool[] res = new bool[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            int x = queries[i][0], y = queries[i][1];
            res[i] = dp[y] >= y - x + 1;
        }
        return res;
    }
}
```

```Go
func isArraySpecial(nums []int, queries [][]int) []bool {
    n := len(nums)
    dp := make([]int, n)
    for i := 0; i < n; i++ {
        dp[i] = 1
    }
    for i := 1; i < n; i++ {
        if (nums[i] ^ nums[i - 1]) & 1 == 1 {
            dp[i] = dp[i - 1] + 1
        }
    }

    res := make([]bool, len(queries))
    for i, q := range queries {
        x, y := q[0], q[1]
        res[i] = dp[y] >= y- x + 1
    }
    return res
}
```

```Python
class Solution:
    def isArraySpecial(self, nums: List[int], queries: List[List[int]]) -> List[bool]:
        n = len(nums)
        dp = [1] * n
        for i in range(1, n):
            if (nums[i] ^ nums[i - 1]) & 1 == 1:
                dp[i] = dp[i - 1] + 1
        return [dp[y] >= y - x + 1 for x, y in queries]

```

```C
bool* isArraySpecial(int* nums, int numsSize, int** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    int* dp = (int*)malloc(numsSize * sizeof(int));
    for (int i = 0; i < numsSize; i++) {
        dp[i] = 1;
    }
    for (int i = 1; i < numsSize; i++) {
        if ((nums[i] ^ nums[i - 1]) & 1) {
            dp[i] = dp[i - 1] + 1;
        }
    }

    bool* res = (bool*)malloc(queriesSize * sizeof(bool));
    for (int i = 0; i < queriesSize; i++) {
        int x = queries[i][0], y = queries[i][1];
        res[i] = dp[y] >= y - x + 1;
    }
    free(dp);
    *returnSize = queriesSize;
    return res;
}
```

```JavaScript
var isArraySpecial = function(nums, queries) {
    const n = nums.length;
    const dp = new Array(n).fill(1);
    for (let i = 1; i < n; i++) {
        if ((nums[i] ^ nums[i - 1]) & 1) {
            dp[i] = dp[i - 1] + 1;
        }
    }

    const res = [];
    for (const [x, y] of queries) {
        res.push(dp[y] >= y - x + 1);
    }
    return res;
};
```

```TypeScript
function isArraySpecial(nums: number[], queries: number[][]): boolean[] {
    const n = nums.length;
    const dp: number[] = new Array(n).fill(1);
    for (let i = 1; i < n; i++) {
        if ((nums[i] ^ nums[i - 1]) & 1) {
            dp[i] = dp[i - 1] + 1;
        }
    }

    const res: boolean[] = [];
    for (const [x, y] of queries) {
        res.push(dp[y] >= y - x + 1);
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn is_array_special(nums: Vec<i32>, queries: Vec<Vec<i32>>) -> Vec<bool> {
        let n = nums.len();
        let mut dp = vec![1; n];
        for i in 1..n {
            if (nums[i] ^ nums[i - 1]) & 1 != 0 {
                dp[i] = dp[i - 1] + 1;
            }
        }

        let mut res = Vec::with_capacity(queries.len());
        for q in queries {
            let x = q[0] as usize;
            let y = q[1] as usize;
            res.push(dp[y] >= y - x + 1);
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m)$，其中 $n$ 表示给定数组 $nums$ 的长度，$m$ 表示给定的查询数组 $queries$ 的长度。
- 空间复杂度：$O(n)$，其中 $n$ 表示给定数组 $nums$ 的长度。我们需要空间来保存每个索引的最长特殊数组的长度。
