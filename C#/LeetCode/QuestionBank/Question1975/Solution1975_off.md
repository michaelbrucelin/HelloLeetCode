### [最大方阵和]()

#### 方法一：贪心

**提示 1**

为了使得操作后方阵总和最大，我们需要使得负数元素的**总和尽可能大**。

对于方阵中的两个负数元素，一定存在一系列的操作使得这两个负数元素均变为正数，且其余元素不变。

对于方阵中的一个正数元素和一个负数元素，一定存在一系列的操作使得这两个元素交换正负，且其余元素不变。

**提示 1 解释**

第一部分是显然的。

对于第二部分，我们可以任意选择一条连接两个负数元素的**有向**路径，按顺序对路径上（除终点以外）的每个元素和它对应的下一个元素都执行一次操作。最终路径上除了两个端点以外的其他元素都被执行了两次操作，因此数值不变；两个端点元素都被执行了一次操作二变为正数。

由于方阵是网格，因此上述路径一定存在。

对于第三部分，将第二部分中的一个负数更改为正数即可证明。

**提示 2**

如果方阵中存在一个元素为 $0$，另一个元素为负数。那么一定存在一系列的操作使得负数元素变为正数，且其余元素不变。

**提示 $2$ 解释**

类似 **提示 1**，将一个负数元素更改为 $0$ 即可证明。

**提示 3**

如果方阵中存在 $0$，那么一定可以通过一系列的操作使得方阵中所有元素**均为非负数**;

如果方阵中不存在 $0$，那么：

- 如果方阵中有奇数个负数元素，那么一定可以通过一系列的操作使得方阵中只有一个负数元素，且该负数元素可以在任何位置。同时，无论如何操作，方阵中必定存在负数元素。
- 如果方阵中有偶数个负数元素，那么一定可以通过一系列的操作使得方阵中不存在负数元素。

**提示 $3$ 解释**

对于第一部分，反复对 $0$ 和负数元素进行 **提示 2** 的操作即可。

对于第二部分，我们首先可以证明如果方阵**不存在** $0$，那么负数元素**数量**的**奇偶性不会改变**。然后，我们可以根据 **提示 1** 构造出一系列操作从而达到对应的要求。

**思路与算法**

根据 **提示 3**，我们可以按照方阵的元素分为以下几种情况：

- 方阵中有 $0$，那么最大方阵和即为所有元素的绝对值之和；
- 方阵中没有 $0$，且负数元素数量为偶数，那么最大方阵和即为所有元素的绝对值之和；
- 方阵中没有 $0$，且负数元素数量为奇数，那么最大方阵和即为所有元素的绝对值之和减去所有元素最小绝对值的两倍。

其中，第一种情况也可以按照负数元素数量的奇偶性划入后两种情况中（此时最小绝对值一定为 $0$）。

我们遍历方阵，维护负数元素的数量、元素的最小绝对值以及所有元素的绝对值之和。随后，我们按照负数元素数量的奇偶性计算对应的最大元素和并返回。

最后，矩阵所有元素绝对值之和可能超过 $32$ 位整数的上限，因此对于 $C++$ 等语言，需要使用 $64$ 位整数来维护。

**代码**

```C++
class Solution {
public:
    long long maxMatrixSum(vector<vector<int>>& matrix) {
        int n = matrix.size();
        int cnt = 0;   // 负数元素的数量
        long long total = 0;   // 所有元素的绝对值之和
        int mn = INT_MAX;   // 方阵元素的最小绝对值
        for (int i = 0; i < n; ++i){
            for (int j = 0; j < n; ++j){
                mn = min(mn, abs(matrix[i][j]));
                if (matrix[i][j] < 0){
                    ++cnt;
                }
                total += abs(matrix[i][j]);
            }
        }
        // 按照负数元素的数量的奇偶性讨论
        if (cnt % 2 == 0){
            return total;
        }
        else{
            return total - 2 * mn;
        }
    }
};
```

```Python
class Solution:
    def maxMatrixSum(self, matrix: List[List[int]]) -> int:
        n = len(matrix)
        cnt = 0   # 负数元素的数量
        total = 0   # 所有元素的绝对值之和
        mn = float("INF")   # 方阵元素的最小绝对值
        for i in range(n):
            for j in range(n):
                mn = min(mn, abs(matrix[i][j]))
                if matrix[i][j] < 0:
                    cnt += 1
                total += abs(matrix[i][j])
        # 按照负数元素的数量的奇偶性讨论
        if cnt % 2 == 0:
            return total
        else:
            return total - 2 * mn
```

```Java
class Solution {
    public long maxMatrixSum(int[][] matrix) {
        int n = matrix.length;
        int cnt = 0;   // 负数元素的数量
        long total = 0;   // 所有元素的绝对值之和
        int mn = Integer.MAX_VALUE;   // 方阵元素的最小绝对值
        for (int i = 0; i < n; ++i){
            for (int j = 0; j < n; ++j){
                mn = Math.min(mn, Math.abs(matrix[i][j]));
                if (matrix[i][j] < 0){
                    ++cnt;
                }
                total += Math.abs(matrix[i][j]);
            }
        }
        // 按照负数元素的数量的奇偶性讨论
        if (cnt % 2 == 0){
            return total;
        } else {
            return total - 2 * mn;
        }
    }
}
```

```CSharp
public class Solution {
    public long MaxMatrixSum(int[][] matrix) {
        int n = matrix.Length;
        int cnt = 0;   // 负数元素的数量
        long total = 0;   // 所有元素的绝对值之和
        int mn = int.MaxValue;   // 方阵元素的最小绝对值
        for (int i = 0; i < n; ++i){
            for (int j = 0; j < n; ++j){
                mn = Math.Min(mn, Math.Abs(matrix[i][j]));
                if (matrix[i][j] < 0){
                    ++cnt;
                }
                total += Math.Abs(matrix[i][j]);
            }
        }
        // 按照负数元素的数量的奇偶性讨论
        if (cnt % 2 == 0){
            return total;
        } else{
            return total - 2 * mn;
        }
    }
}
```

```Go
func maxMatrixSum(matrix [][]int) int64 {
    n := len(matrix)
    cnt := 0   // 负数元素的数量
    total := int64(0)   // 所有元素的绝对值之和
    mn := 1 << 30   // 方阵元素的最小绝对值
    for i := 0; i < n; i++ {
        for j := 0; j < n; j++ {
            mn = min(mn, abs(matrix[i][j]))
            if matrix[i][j] < 0 {
                cnt++
            }
            total += int64(abs(matrix[i][j]))
        }
    }
    // 按照负数元素的数量的奇偶性讨论
    if cnt % 2 == 0 {
        return total
    } else {
        return total - int64(2 * mn)
    }
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

```C
long long maxMatrixSum(int** matrix, int matrixSize, int* matrixColSize) {
    int n = matrixSize;
    int cnt = 0;   // 负数元素的数量
    long long total = 0;   // 所有元素的绝对值之和
    int mn = INT_MAX;   // 方阵元素的最小绝对值
    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j) {
            int abs_val = abs(matrix[i][j]);
            if (abs_val < mn) {
                mn = abs_val;
            }
            if (matrix[i][j] < 0) {
                ++cnt;
            }
            total += abs_val;
        }
    }
    // 按照负数元素的数量的奇偶性讨论
    if (cnt % 2 == 0) {
        return total;
    } else {
        return total - 2 * mn;
    }
}
```

```JavaScript
var maxMatrixSum = function(matrix) {
    const n = matrix.length;
    let cnt = 0;   // 负数元素的数量
    let total = 0;   // 所有元素的绝对值之和
    let mn = Number.MAX_SAFE_INTEGER;   // 方阵元素的最小绝对值
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            const absVal = Math.abs(matrix[i][j]);
            mn = Math.min(mn, absVal);
            if (matrix[i][j] < 0) {
                cnt++;
            }
            total += absVal;
        }
    }
    // 按照负数元素的数量的奇偶性讨论
    if (cnt % 2 === 0) {
        return total;
    } else {
        return total - 2 * mn;
    }
};
```

```TypeScript
function maxMatrixSum(matrix: number[][]): number {
    const n = matrix.length;
    let cnt = 0;   // 负数元素的数量
    let total = 0;   // 所有元素的绝对值之和
    let mn = Number.MAX_SAFE_INTEGER;   // 方阵元素的最小绝对值
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            const absVal = Math.abs(matrix[i][j]);
            mn = Math.min(mn, absVal);
            if (matrix[i][j] < 0) {
                cnt++;
            }
            total += absVal;
        }
    }
    // 按照负数元素的数量的奇偶性讨论
    if (cnt % 2 === 0) {
        return total;
    } else {
        return total - 2 * mn;
    }
}
```

```Rust
impl Solution {
    pub fn max_matrix_sum(matrix: Vec<Vec<i32>>) -> i64 {
        let n = matrix.len();
        let mut cnt = 0;   // 负数元素的数量
        let mut total: i64 = 0;   // 所有元素的绝对值之和
        let mut mn = i32::MAX;   // 方阵元素的最小绝对值
        for i in 0..n {
            for j in 0..n {
                let abs_val = matrix[i][j].abs();
                mn = mn.min(abs_val);
                if matrix[i][j] < 0 {
                    cnt += 1;
                }
                total += abs_val as i64;
            }
        }
        // 按照负数元素的数量的奇偶性讨论
        if cnt % 2 == 0 {
            total
        } else {
            total - 2 * mn as i64
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m$ 为 $matrix$ 的行数，$n$ 为 $matrix$ 的列数。
- 空间复杂度：$O(1)$。
