### [删列造序 III](https://leetcode.cn/problems/delete-columns-to-make-sorted-iii/solutions/3849394/shan-lie-zao-xu-iii-by-leetcode-solution-4id0/)

#### 方法一：动态规划

**想法和算法**

这是一个复杂的问题，很难抽象出解题思路。

首先，找出需要保留的列数，而不是需要删除的列数。最后，可以相减得到答案。

假设我们一定保存第一列 `C`，那么保存的下一列 `D` 就必须保证每行都是字典有序的，也就是 `C[i] <= D[i]`。那么我们就可以删除 `C` 和 `D` 之间的所有列。

我们可以用动态规划来解决这个问题，让 `dp[k]` 表示在输入为 `[row[k:] for row in A]` 时保存的列数，那么 `dp[k]` 的递推式显而易见。

```Java
class Solution {
    public int minDeletionSize(String[] A) {
        int W = A[0].length();
        int[] dp = new int[W];
        Arrays.fill(dp, 1);
        for (int i = W-2; i >= 0; --i)
            search: for (int j = i+1; j < W; ++j) {
                for (String row: A) {
                    if (row.charAt(i) > row.charAt(j)) {
                        continue search;
                    }
                }
                dp[i] = Math.max(dp[i], 1 + dp[j]);
            }

        int kept = 0;
        for (int x: dp) {
            kept = Math.max(kept, x);
        }
        return W - kept;
    }
}
```

```Python
class Solution:
    def minDeletionSize(self, strs: List[str]) -> int:
        n = len(strs[0])
        dp = [1] * n
        for i in range(n - 2, -1, -1):
            for j in range(i + 1, n):
                if all(row[i] <= row[j] for row in strs):
                    dp[i] = max(dp[i], 1 + dp[j])

        return n - max(dp)
```

```C++
class Solution {
public:
    int minDeletionSize(vector<string>& strs) {
        int n = strs[0].size();
        vector<int> dp(n, 1);

        for (int i = n - 2; i >= 0; i--) {
            for (int j = i + 1; j < n; j++) {
                bool valid = true;
                for (const auto& row : strs) {
                    if (row[i] > row[j]) {
                        valid = false;
                        break;
                    }
                }
                if (valid) {
                    dp[i] = max(dp[i], 1 + dp[j]);
                }
            }
        }

        return n - *max_element(dp.begin(), dp.end());
    }
};
```

```CSharp
public class Solution {
    public int MinDeletionSize(string[] strs) {
        int n = strs[0].Length;
        int[] dp = new int[n];
        Array.Fill(dp, 1);

        for (int i = n - 2; i >= 0; i--) {
            for (int j = i + 1; j < n; j++) {
                bool valid = true;
                foreach (string row in strs) {
                    if (row[i] > row[j]) {
                        valid = false;
                        break;
                    }
                }
                if (valid) {
                    dp[i] = Math.Max(dp[i], 1 + dp[j]);
                }
            }
        }

        return n - dp.Max();
    }
}
```

```Go
func minDeletionSize(strs []string) int {
    n := len(strs[0])
    dp := make([]int, n)
    for i := range dp {
        dp[i] = 1
    }

    for i := n - 2; i >= 0; i-- {
        for j := i + 1; j < n; j++ {
            valid := true
            for _, row := range strs {
                if row[i] > row[j] {
                    valid = false
                    break
                }
            }
            if valid {
                if dp[i] < 1 + dp[j] {
                    dp[i] = 1 + dp[j]
                }
            }
        }
    }

    maxVal := 0
    for _, val := range dp {
        maxVal = max(maxVal, val)
    }

    return n - maxVal
}
```

```C
int minDeletionSize(char** strs, int strsSize) {
    int n = strlen(strs[0]);
    int* dp = (int*)malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) {
        dp[i] = 1;
    }

    for (int i = n - 2; i >= 0; i--) {
        for (int j = i + 1; j < n; j++) {
            int valid = 1;
            for (int k = 0; k < strsSize; k++) {
                if (strs[k][i] > strs[k][j]) {
                    valid = 0;
                    break;
                }
            }
            if (valid) {
                if (dp[i] < 1 + dp[j]) {
                    dp[i] = 1 + dp[j];
                }
            }
        }
    }

    int maxDP = 0;
    for (int i = 0; i < n; i++) {
        if (dp[i] > maxDP) {
            maxDP = dp[i];
        }
    }

    free(dp);
    return n - maxDP;
}
```

```JavaScript
var minDeletionSize = function(strs) {
    const n = strs[0].length;
    const dp = new Array(n).fill(1);

    for (let i = n - 2; i >= 0; i--) {
        for (let j = i + 1; j < n; j++) {
            let valid = true;
            for (const row of strs) {
                if (row[i] > row[j]) {
                    valid = false;
                    break;
                }
            }
            if (valid) {
                dp[i] = Math.max(dp[i], 1 + dp[j]);
            }
        }
    }

    return n - Math.max(...dp);
};
```

```TypeScript
function minDeletionSize(strs: string[]): number {
    const n = strs[0].length;
    const dp: number[] = new Array(n).fill(1);

    for (let i = n - 2; i >= 0; i--) {
        for (let j = i + 1; j < n; j++) {
            let valid = true;
            for (const row of strs) {
                if (row[i] > row[j]) {
                    valid = false;
                    break;
                }
            }
            if (valid) {
                dp[i] = Math.max(dp[i], 1 + dp[j]);
            }
        }
    }

    return n - Math.max(...dp);
};
```

```Rust
impl Solution {
    pub fn min_deletion_size(strs: Vec<String>) -> i32 {
        let n = strs[0].len();
        let mut dp = vec![1; n];

        for i in (0..n-1).rev() {
            for j in i+1..n {
                let mut valid = true;
                for row in &strs {
                    let char_i = row.chars().nth(i).unwrap();
                    let char_j = row.chars().nth(j).unwrap();
                    if char_i > char_j {
                        valid = false;
                        break;
                    }
                }
                if valid {
                    dp[i] = dp[i].max(1 + dp[j]);
                }
            }
        }

        let max_dp = dp.iter().max().unwrap();
        (n - max_dp) as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(N \times W^2)$，其中 $N$ 是 `A` 的长度，$W$ 是 `A` 中每个单词的长度。
- 空间复杂度：$O(W)$。
