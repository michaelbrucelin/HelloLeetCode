### [零数组变换 II](https://leetcode.cn/problems/zero-array-transformation-ii/solutions/3674700/ling-shu-zu-bian-huan-ii-by-leetcode-sol-04r9/)

#### 方法一：差分数组 + 二分查找

**思路**

这题中，如果 $k$ 能满足要求，那么 $k+1$ 也能满足要求，我们需要求出能满足要求的最小的 $k$，那么就可以二分答案。将上一题的思路[零数组变换 I](https://leetcode.cn/problems/zero-array-transformation-i/description/)写成二分判断的函数，在它的基础上进行二分判断，返回二分得到的结果即可。

**代码**

```Python
class Solution:
    def minZeroArray(self, nums: List[int], queries: List[List[int]]) -> int:
        left, right = 0, len(queries)
        if not self.check(nums, queries, right):
            return -1
        while left < right:
            k = (left + right) // 2
            if self.check(nums, queries, k):
                right = k
            else:
                left = k + 1
        return left

    def check(self, nums: List[int], queries: List[List[int]], k: int) -> bool:
        deltaArray = [0] * (len(nums) + 1)
        for left, right, value in queries[:k]:
            deltaArray[left] += value
            deltaArray[right + 1] -= value
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
    int minZeroArray(vector<int>& nums, vector<vector<int>>& queries) {
        int left = 0, right = queries.size();
        if (!check(nums, queries, right)) {
            return -1;
        }
        while (left < right) {
            int k = (left + right) / 2;
            if (check(nums, queries, k)) {
                right = k;
            } else {
                left = k + 1;
            }
        }
        return left;
    }

private:
    bool check(vector<int>& nums, vector<vector<int>>& queries, int k) {
        vector<int> deltaArray(nums.size() + 1, 0);
        for (int i = 0; i < k; ++i) {
            int left = queries[i][0];
            int right = queries[i][1];
            int value = queries[i][2];
            deltaArray[left] += value;
            deltaArray[right + 1] -= value;
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
    public int minZeroArray(int[] nums, int[][] queries) {
        int left = 0, right = queries.length;
        if (!check(nums, queries, right)) {
            return -1;
        }
        while (left < right) {
            int k = (left + right) / 2;
            if (check(nums, queries, k)) {
                right = k;
            } else {
                left = k + 1;
            }
        }
        return left;
    }

    private boolean check(int[] nums, int[][] queries, int k) {
        int[] deltaArray = new int[nums.length + 1];
        for (int i = 0; i < k; i++) {
            int left = queries[i][0];
            int right = queries[i][1];
            int value = queries[i][2];
            deltaArray[left] += value;
            deltaArray[right + 1] -= value;
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
    public int MinZeroArray(int[] nums, int[][] queries) {
        int left = 0, right = queries.Length;
        if (!Check(nums, queries, right)) {
            return -1;
        }
        while (left < right) {
            int k = (left + right) / 2;
            if (Check(nums, queries, k)) {
                right = k;
            } else {
                left = k + 1;
            }
        }
        return left;
    }

    private bool Check(int[] nums, int[][] queries, int k) {
        int[] deltaArray = new int[nums.Length + 1];
        for (int i = 0; i < k; i++) {
            int left = queries[i][0];
            int right = queries[i][1];
            int value = queries[i][2];
            deltaArray[left] += value;
            deltaArray[right + 1] -= value;
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
func minZeroArray(nums []int, queries [][]int) int {
    left, right := 0, len(queries)
    if !check(nums, queries, right) {
        return -1
    }
    for left < right {
        k := (left + right) / 2
        if check(nums, queries, k) {
            right = k
        } else {
            left = k + 1
        }
    }
    return left
}

func check(nums []int, queries [][]int, k int) bool {
    deltaArray := make([]int, len(nums) + 1)
    for i := 0; i < k; i++ {
        left := queries[i][0]
        right := queries[i][1]
        value := queries[i][2]
        deltaArray[left] += value
        deltaArray[right + 1] -= value
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
bool check(int* nums, int numsSize, int** queries, int queriesSize, int k) {
    int* deltaArray = calloc(numsSize + 1, sizeof(int));
    for (int i = 0; i < k; i++) {
        int left = queries[i][0];
        int right = queries[i][1];
        int value = queries[i][2];
        deltaArray[left] += value;
        deltaArray[right + 1] -= value;
    }
    int* operationCounts = malloc((numsSize + 1) * sizeof(int));
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

int minZeroArray(int* nums, int numsSize, int** queries, int queriesSize, int* queriesColSize) {
    int left = 0, right = queriesSize;
    if (!check(nums, numsSize, queries, queriesSize, right)) {
        return -1;
    }
    while (left < right) {
        int k = (left + right) / 2;
        if (check(nums, numsSize, queries, queriesSize, k)) {
            right = k;
        } else {
            left = k + 1;
        }
    }
    return left;
}
```

```JavaScript
var minZeroArray = function(nums, queries) {
    let left = 0, right = queries.length;
    if (!check(nums, queries, right)) {
        return -1;
    }
    while (left < right) {
        const k = Math.floor((left + right) / 2);
        if (check(nums, queries, k)) {
            right = k;
        } else {
            left = k + 1;
        }
    }
    return left;
};

const check = (nums, queries, k) => {
    const deltaArray = new Array(nums.length + 1).fill(0);
    for (let i = 0; i < k; i++) {
        const left = queries[i][0];
        const right = queries[i][1];
        const value = queries[i][2];
        deltaArray[left] += value;
        deltaArray[right + 1] -= value;
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
}
```

```TypeScript
function minZeroArray(nums: number[], queries: number[][]): number {
    let left = 0, right = queries.length;
    if (!check(nums, queries, right)) {
        return -1;
    }
    while (left < right) {
        const k = Math.floor((left + right) / 2);
        if (check(nums, queries, k)) {
            right = k;
        } else {
            left = k + 1;
        }
    }
    return left;
};

function check(nums: number[], queries: number[][], k: number): boolean {
    const deltaArray: number[] = new Array(nums.length + 1).fill(0);
    for (let i = 0; i < k; i++) {
        const left = queries[i][0];
        const right = queries[i][1];
        const value = queries[i][2];
        deltaArray[left] += value;
        deltaArray[right + 1] -= value;
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
    pub fn min_zero_array(nums: Vec<i32>, queries: Vec<Vec<i32>>) -> i32 {
        let mut left = 0;
        let mut right = queries.len();
        if !Self::check(&nums, &queries, right) {
            return -1;
        }
        while left < right {
            let k = (left + right) / 2;
            if Self::check(&nums, &queries, k) {
                right = k;
            } else {
                left = k + 1;
            }
        }
        left as i32
    }

    fn check(nums: &[i32], queries: &[Vec<i32>], k: usize) -> bool {
        let mut delta_array = vec![0; nums.len() + 1];
        for i in 0..k {
            let left = queries[i][0] as usize;
            let right = queries[i][1] as usize;
            let value = queries[i][2];
            delta_array[left] += value;
            delta_array[right + 1] -= value;
        }
        let mut operation_counts = Vec::with_capacity(delta_array.len());
        let mut current_operations = 0;
        for &delta in &delta_array {
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

- 时间复杂度：$O((m+n) \times logn)$，其中 $n$ 是 $nums$ 的长度，$m$ 是 $queries$ 的长度。
- 空间复杂度：$O(n)$。

#### 方法二：双指针

**思路**

仍然按照单调的思路，我们先不预计算出整个 $deltaArray$ 数组，而是只在有需要的时候处理一些 $queries$。那什么时候是有需要的时候呢，就是我们从左往右遍历 $nums$ 的时候，发现已经处理过的 $queries$ 不能使当前的 $nums[i]$ 变成 $0$，则需要多考虑一些 $queries$。依次按顺序处理当前没有处理过的 $queries$，并更新前缀和，一满足要求就停止，直到遍历完 $queries$ 或者 $nums$，并返回结果。

**代码**

```Python
class Solution:
    def minZeroArray(self, nums: List[int], queries: List[List[int]]) -> int:
        n = len(nums)
        deltaArray = [0] * (n + 1)
        operations = 0
        k = 0
        for i in range(n):
            num = nums[i]
            operations += deltaArray[i]
            while k < len(queries) and operations < num:
                left, right, value = queries[k]
                deltaArray[left] += value
                deltaArray[right + 1] -= value
                if left <= i <= right:
                    operations += value
                k += 1
            if operations < num:
                return -1
        return k
```

```C++
class Solution {
public:
    int minZeroArray(vector<int>& nums, vector<vector<int>>& queries) {
        int n = nums.size();
        vector<int> deltaArray(n + 1, 0);
        int operations = 0;
        int k = 0;
        for (int i = 0; i < n; ++i) {
            int num = nums[i];
            operations += deltaArray[i];
            while (k < queries.size() && operations < num) {
                int left = queries[k][0];
                int right = queries[k][1];
                int value = queries[k][2];
                deltaArray[left] += value;
                deltaArray[right + 1] -= value;
                if (left <= i && i <= right) {
                    operations += value;
                }
                k++;
            }
            if (operations < num) {
                return -1;
            }
        }
        return k;
    }
};
```

```Java
class Solution {
    public int minZeroArray(int[] nums, int[][] queries) {
        int n = nums.length;
        int[] deltaArray = new int[n + 1];
        int operations = 0;
        int k = 0;
        for (int i = 0; i < n; i++) {
            int num = nums[i];
            operations += deltaArray[i];
            while (k < queries.length && operations < num) {
                int left = queries[k][0];
                int right = queries[k][1];
                int value = queries[k][2];
                deltaArray[left] += value;
                deltaArray[right + 1] -= value;
                if (left <= i && i <= right) {
                    operations += value;
                }
                k++;
            }
            if (operations < num) {
                return -1;
            }
        }
        return k;
    }
}
```

```CSharp
public class Solution {
    public int MinZeroArray(int[] nums, int[][] queries) {
        int n = nums.Length;
        int[] deltaArray = new int[n + 1];
        int operations = 0;
        int k = 0;
        for (int i = 0; i < n; i++) {
            int num = nums[i];
            operations += deltaArray[i];
            while (k < queries.Length && operations < num) {
                int left = queries[k][0];
                int right = queries[k][1];
                int value = queries[k][2];
                deltaArray[left] += value;
                deltaArray[right + 1] -= value;
                if (left <= i && i <= right) {
                    operations += value;
                }
                k++;
            }
            if (operations < num) {
                return -1;
            }
        }
        return k;
    }
}
```

```Go
func minZeroArray(nums []int, queries [][]int) int {
    n := len(nums)
    deltaArray := make([]int, n + 1)
    operations := 0
    k := 0
    for i, num := range nums {
        operations += deltaArray[i]
        for k < len(queries) && operations < num {
            left, right, value := queries[k][0], queries[k][1], queries[k][2]
            deltaArray[left] += value
            deltaArray[right + 1] -= value
            if left <= i && i <= right {
                operations += value
            }
            k++
        }
        if operations < num {
            return -1
        }
    }
    return k
}
```

```C
int minZeroArray(int* nums, int numsSize, int** queries, int queriesSize, int* queriesColSize) {
    int* deltaArray = calloc(numsSize + 1, sizeof(int));
    int operations = 0;
    int k = 0;
    for (int i = 0; i < numsSize; i++) {
        int num = nums[i];
        operations += deltaArray[i];
        while (k < queriesSize && operations < num) {
            int left = queries[k][0];
            int right = queries[k][1];
            int value = queries[k][2];
            deltaArray[left] += value;
            deltaArray[right + 1] -= value;
            if (left <= i && i <= right) {
                operations += value;
            }
            k++;
        }
        if (operations < num) {
            free(deltaArray);
            return -1;
        }
    }
    free(deltaArray);
    return k;
}
```

```JavaScript
var minZeroArray = function(nums, queries) {
    const n = nums.length;
    const deltaArray = new Array(n + 1).fill(0);
    let operations = 0;
    let k = 0;
    for (let i = 0; i < n; i++) {
        const num = nums[i];
        operations += deltaArray[i];
        while (k < queries.length && operations < num) {
            const [left, right, value] = queries[k];
            deltaArray[left] += value;
            deltaArray[right + 1] -= value;
            if (left <= i && i <= right) {
                operations += value;
            }
            k++;
        }
        if (operations < num) {
            return -1;
        }
    }
    return k;
};
```

```TypeScript
function minZeroArray(nums: number[], queries: number[][]): number {
    const n = nums.length;
    const deltaArray: number[] = new Array(n + 1).fill(0);
    let operations = 0;
    let k = 0;
    for (let i = 0; i < n; i++) {
        const num = nums[i];
        operations += deltaArray[i];
        while (k < queries.length && operations < num) {
            const [left, right, value] = queries[k];
            deltaArray[left] += value;
            deltaArray[right + 1] -= value;
            if (left <= i && i <= right) {
                operations += value;
            }
            k++;
        }
        if (operations < num) {
            return -1;
        }
    }
    return k;
};
```

```Rust
impl Solution {
    pub fn min_zero_array(nums: Vec<i32>, queries: Vec<Vec<i32>>) -> i32 {
        let n = nums.len();
        let mut delta_array = vec![0; n + 1];
        let mut operations = 0;
        let mut k = 0;
        for i in 0..n {
            let num = nums[i];
            operations += delta_array[i];
            while k < queries.len() && operations < num {
                let left = queries[k][0] as usize;
                let right = queries[k][1] as usize;
                let value = queries[k][2];
                delta_array[left] += value;
                delta_array[right + 1] -= value;
                if left <= i && i <= right {
                    operations += value;
                }
                k += 1;
            }
            if operations < num {
                return -1;
            }
        }
        k as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m+n)$，其中 $n$ 是 $nums$ 的长度，$m$ 是 $queries$ 的长度。
- 空间复杂度：$O(n)$。
