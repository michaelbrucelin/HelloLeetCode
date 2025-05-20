### [零数组变换 I](https://leetcode.cn/problems/zero-array-transformation-i/solutions/3674711/ling-shu-zu-bian-huan-i-by-leetcode-solu-7q94/)

#### 方法一：差分数组

**思路**

我们通过差分数组统计每个位置最多可以被操作的操作的次数。构建差分数组 $deltaArray$ 的长度为 $n+1$，（$n$ 是数组 $nums$ 长度），用于记录每个查询对操作次数的增量影响。对每个查询区间 $[left,right]$，在 $deltaArray[left]$ 处 $+1$，表示从 $left$ 开始操作次数增加；在 $deltaArray[right+1]$ 处 $-1$，表示 $right+1$ 之后的操作次数恢复原状。然后对差分数组 $deltaArray$ 进行前缀和累加，得到每个位置的总操作次数 $currentOperations$，存入 $operationCounts$。遍历数组 $nums$ 和操作次数数组 $operationCounts$，比较每个位置的实际操作次数 $operations$ 是否满足归零所需的最小次数 $target$。若所有位置均满足 $operations \ge target$，则返回 $true$；否则返回 $false$。

**代码**

```Python
class Solution:
    def isZeroArray(self, nums: List[int], queries: List[List[int]]) -> bool:
        deltaArray = [0] * (len(nums) + 1)
        for left, right in queries:
            deltaArray[left] += 1
            deltaArray[right + 1] -= 1
        operationCounts = []
        currentOperations = 0
        for delta in deltaArray:
            currentOperations += delta
            operationCounts.append(currentOperations)
        for operations, target in zip(operationCounts, nums):
            if operations < target:
                return False
        return True
```

```C++
class Solution {
public:
    bool isZeroArray(vector<int>& nums, vector<vector<int>>& queries) {
        vector<int> deltaArray(nums.size() + 1, 0);
        for (const auto& query : queries) {
            int left = query[0];
            int right = query[1];
            deltaArray[left] += 1;
            deltaArray[right + 1] -= 1;
        }
        vector<int> operationCounts;
        int currentOperations = 0;
        for (int delta : deltaArray) {
            currentOperations += delta;
            operationCounts.push_back(currentOperations);
        }
        for (int i = 0; i < nums.size(); ++i) {
            if (operationCounts[i] < nums[i]) {
                return false;
            }
        }
        return true;
    }
};
```

```Java
class Solution {
    public boolean isZeroArray(int[] nums, int[][] queries) {
        int[] deltaArray = new int[nums.length + 1];
        for (int[] query : queries) {
            int left = query[0];
            int right = query[1];
            deltaArray[left] += 1;
            deltaArray[right + 1] -= 1;
        }
        int[] operationCounts = new int[deltaArray.length];
        int currentOperations = 0;
        for (int i = 0; i < deltaArray.length; i++) {
            currentOperations += deltaArray[i];
            operationCounts[i] = currentOperations;
        }
        for (int i = 0; i < nums.length; i++) {
            if (operationCounts[i] < nums[i]) {
                return false;
            }
        }
        return true;
    }
}
```

```CSharp
public class Solution {
    public bool IsZeroArray(int[] nums, int[][] queries) {
        int[] deltaArray = new int[nums.Length + 1];
        foreach (int[] query in queries) {
            int left = query[0];
            int right = query[1];
            deltaArray[left] += 1;
            deltaArray[right + 1] -= 1;
        }
        int[] operationCounts = new int[deltaArray.Length];
        int currentOperations = 0;
        for (int i = 0; i < deltaArray.Length; i++) {
            currentOperations += deltaArray[i];
            operationCounts[i] = currentOperations;
        }
        for (int i = 0; i < nums.Length; i++) {
            if (operationCounts[i] < nums[i]) {
                return false;
            }
        }
        return true;
    }
}
```

```Go
func isZeroArray(nums []int, queries [][]int) bool {
    deltaArray := make([]int, len(nums) + 1)
    for _, query := range queries {
        left := query[0]
        right := query[1]
        deltaArray[left] += 1
        deltaArray[right + 1] -= 1
    }
    operationCounts := make([]int, len(deltaArray))
    currentOperations := 0
    for i, delta := range deltaArray {
        currentOperations += delta
        operationCounts[i] = currentOperations
    }
    for i := 0; i < len(nums); i++ {
        if operationCounts[i] < nums[i] {
            return false
        }
    }
    return true
}
```

```C
bool isZeroArray(int* nums, int numsSize, int** queries, int queriesSize, int* queriesColSize) {
    int* deltaArray = (int*)calloc(numsSize + 1, sizeof(int));
    for (int i = 0; i < queriesSize; i++) {
        int left = queries[i][0];
        int right = queries[i][1];
        deltaArray[left] += 1;
        deltaArray[right + 1] -= 1;
    }
    int* operationCounts = (int*)malloc((numsSize + 1) * sizeof(int));
    int currentOperations = 0;
    for (int i = 0; i < numsSize + 1; i++) {
        currentOperations += deltaArray[i];
        operationCounts[i] = currentOperations;
    }
    for (int i = 0; i < numsSize; i++) {
        if (operationCounts[i] < nums[i]) {
            free(deltaArray);
            free(operationCounts);
            return false;
        }
    }
    free(deltaArray);
    free(operationCounts);
    return true;
}
```

```JavaScript
var isZeroArray = function(nums, queries) {
    const deltaArray = new Array(nums.length + 1).fill(0);
    for (const [left, right] of queries) {
        deltaArray[left] += 1;
        deltaArray[right + 1] -= 1;
    }
    const operationCounts = [];
    let currentOperations = 0;
    for (const delta of deltaArray) {
        currentOperations += delta;
        operationCounts.push(currentOperations);
    }
    for (let i = 0; i < nums.length; i++) {
        if (operationCounts[i] < nums[i]) {
            return false;
        }
    }
    return true;
};
```

```TypeScript
function isZeroArray(nums: number[], queries: number[][]): boolean {
    const deltaArray: number[] = new Array(nums.length + 1).fill(0);
    for (const [left, right] of queries) {
        deltaArray[left] += 1;
        deltaArray[right + 1] -= 1;
    }
    const operationCounts: number[] = [];
    let currentOperations = 0;
    for (const delta of deltaArray) {
        currentOperations += delta;
        operationCounts.push(currentOperations);
    }
    for (let i = 0; i < nums.length; i++) {
        if (operationCounts[i] < nums[i]) {
            return false;
        }
    }
    return true;
};
```

```Rust
impl Solution {
    pub fn is_zero_array(nums: Vec<i32>, queries: Vec<Vec<i32>>) -> bool {
        let mut delta_array = vec![0; nums.len() + 1];
        for query in queries {
            let left = query[0] as usize;
            let right = query[1] as usize;
            delta_array[left] += 1;
            delta_array[right + 1] -= 1;
        }
        let mut operation_counts = Vec::with_capacity(delta_array.len());
        let mut current_operations = 0;
        for delta in delta_array {
            current_operations += delta;
            operation_counts.push(current_operations);
        }
        for i in 0..nums.len() {
            if operation_counts[i] < nums[i] {
                return false;
            }
        }
        true
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m)$，其中 $n$ 是 $nums$ 的长度，$m$ 是 $queries$ 的长度。
- 空间复杂度：$O(n)$。
