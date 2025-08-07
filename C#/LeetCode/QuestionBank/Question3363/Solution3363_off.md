### [最多可收集的水果数目](https://leetcode.cn/problems/find-the-maximum-number-of-fruits-collected/solutions/3737099/zui-duo-ke-shou-ji-de-shui-guo-shu-mu-by-zybm/)

#### 方法一：动态规划

**思路与算法**

首先，由于从左上角 $(0,0)$ 出发的小朋友只能移动 $n-1$ 次，所以他只能走主对角线。那么，我们只需要计算剩下两个小朋友收集水果总数的最大值即可。

对于从右上角 $(0,n-1)$ 出发的小朋友，不难发现他只能走主对角线的上面，而不能够越过主对角线，否则在 $n-1$ 次移动后无法到达右下角。而对于另一个从左下角 $(n-1,0)$ 出发的小朋友，情况是一致的。同时由于三人不可能走进同一个房间，我们只需要考虑其中一种情况。我们可以使用动态规划计算其中一条路径，然后按主对角线翻转矩阵并复用相同的逻辑来计算得到另一条路径的结果。那么，问题转化为：

- 从右上角 $(0,n-1)$ 出发，不经过主对角线，走到最后一个收集水果的房间 $(n-2,n-1)$ 所能收集到的水果总数的最大值。

这个问题可以使用动态规划解决。令 $dp[i][j]$ 表示一个小朋友到达房间 $(i,j)$ 时最多能够收集到的水果数量。对于 $1\le i<n-1$ 且 $1<j<n$，$dp[i][j]=max(dp[i-1][j-1],dp[i-1][j],dp[i-1][j+1])+fruits[i][j]$。同时由于终点是 $(n-2,n-1)$，即使每前一步都是从左上角走过来的，$j$ 也始终大于 $i$，所以 $j$ 可以从 $max(n-1-i,i+1)$ 开始枚举。

**代码**

```C++
class Solution {
public:
    int maxCollectedFruits(vector<vector<int>>& fruits) {
        int n = fruits.size();
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            ans += fruits[i][i];
        }

        auto dp = [&]() -> int {
            vector<int> prev(n, INT_MIN), curr(n, INT_MIN);
            prev[n - 1] = fruits[0][n - 1];
            for (int i = 1; i < n - 1; ++i) {
                for (int j = max(n - 1 - i, i + 1); j < n; ++j) {
                    int best = prev[j];
                    if (j - 1 >= 0) {
                        best = max(best, prev[j - 1]);
                    }
                    if (j + 1 < n) {
                        best = max(best, prev[j + 1]);
                    }
                    curr[j] = best + fruits[i][j];
                }
                swap(prev, curr);
            }
            return prev[n - 1];
        };

        ans += dp();

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < i; ++j) {
                swap(fruits[j][i], fruits[i][j]);
            }
        }

        ans += dp();
        return ans;
    }
};
```

```Java
class Solution {
    public int maxCollectedFruits(int[][] fruits) {
        int n = fruits.length;
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            ans += fruits[i][i];
        }

        java.util.function.Supplier<Integer> dp = () -> {
            int[] prev = new int[n];
            int[] curr = new int[n];
            java.util.Arrays.fill(prev, Integer.MIN_VALUE);
            java.util.Arrays.fill(curr, Integer.MIN_VALUE);
            prev[n - 1] = fruits[0][n - 1];
            for (int i = 1; i < n - 1; ++i) {
                for (int j = Math.max(n - 1 - i, i + 1); j < n; ++j) {
                    int best = prev[j];
                    if (j - 1 >= 0)
                        best = Math.max(best, prev[j - 1]);
                    if (j + 1 < n)
                        best = Math.max(best, prev[j + 1]);
                    curr[j] = best + fruits[i][j];
                }
                int[] temp = prev;
                prev = curr;
                curr = temp;
            }
            return prev[n - 1];
        };

        ans += dp.get();

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < i; ++j) {
                int temp = fruits[j][i];
                fruits[j][i] = fruits[i][j];
                fruits[i][j] = temp;
            }
        }

        ans += dp.get();
        return ans;
    }
}
```

```Python
class Solution:
    def maxCollectedFruits(self, fruits):
        n = len(fruits)
        ans = sum(fruits[i][i] for i in range(n))

        def dp():
            prev = [float('-inf')] * n
            curr = [float('-inf')] * n
            prev[n - 1] = fruits[0][n - 1]
            for i in range(1, n - 1):
                for j in range(max(n - 1 - i, i + 1), n):
                    best = prev[j]
                    if j - 1 >= 0:
                        best = max(best, prev[j - 1])
                    if j + 1 < n:
                        best = max(best, prev[j + 1])
                    curr[j] = best + fruits[i][j]
                prev, curr = curr, prev
            return prev[n - 1]

        ans += dp()

        for i in range(n):
            for j in range(i):
                fruits[i][j], fruits[j][i] = fruits[j][i], fruits[i][j]

        ans += dp()
        return ans

```

```CSharp
public class Solution {
    public int MaxCollectedFruits(int[][] fruits) {
        int n = fruits.Length;
        int ans = 0;
        for (int i = 0; i < n; ++i) ans += fruits[i][i];

        int dp() {
            int[] prev = Enumerable.Repeat(int.MinValue, n).ToArray();
            int[] curr = new int[n];
            prev[n - 1] = fruits[0][n - 1];
            for (int i = 1; i < n - 1; ++i) {
                Array.Fill(curr, int.MinValue);
                for (int j = Math.Max(n - 1 - i, i + 1); j < n; ++j) {
                    int best = prev[j];
                    if (j - 1 >= 0) {
                        best = Math.Max(best, prev[j - 1]);
                    }
                    if (j + 1 < n) {
                        best = Math.Max(best, prev[j + 1]);
                    }
                    curr[j] = best + fruits[i][j];
                }
                var temp = prev; 
                prev = curr; 
                curr = temp;
            }
            return prev[n - 1];
        }

        ans += dp();

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < i; ++j) {
                var temp = fruits[j][i]; 
                fruits[j][i] = fruits[i][j]; 
                fruits[i][j]=temp;
            }
        }

        ans += dp();
        return ans;
    }
}
```

```Go
func maxCollectedFruits(fruits [][]int) int {
    n := len(fruits)
    ans := 0
    for i := 0; i < n; i++ {
        ans += fruits[i][i]
    }

    dp := func() int {
        prev := make([]int, n)
        curr := make([]int, n)
        for i := range prev {
            prev[i] = math.MinInt
        }
        prev[n-1] = fruits[0][n-1]
        for i := 1; i < n-1; i++ {
            for j := range curr {
                curr[j] = math.MinInt
            }
            for j := max(n-1-i, i+1); j < n; j++ {
                best := prev[j]
                if j-1 >= 0 {
                    best = max(best, prev[j-1])
                }
                if j+1 < n {
                    best = max(best, prev[j+1])
                }
                curr[j] = best + fruits[i][j]
            }
            prev, curr = curr, prev
        }
        return prev[n-1]
    }

    ans += dp()
    for i := 0; i < n; i++ {
        for j := 0; j < i; j++ {
            fruits[i][j], fruits[j][i] = fruits[j][i], fruits[i][j]
        }
    }
    ans += dp()
    return ans
}

```

```C
int maxCollectedFruits(int** fruits, int fruitsSize, int* fruitsColSize) {
    int ans = 0;
    int n = fruitsSize;
    for (int i = 0; i < n; ++i)
        ans += fruits[i][i];

    int dp() {
        int* prev = malloc(sizeof(int) * n);
        int* curr = malloc(sizeof(int) * n);
        for (int i = 0; i < n; ++i) prev[i] = INT_MIN;
        prev[n - 1] = fruits[0][n - 1];

        for (int i = 1; i < n - 1; ++i) {
            for (int j = 0; j < n; ++j) curr[j] = INT_MIN;
            for (int j = (n - 1 - i > i + 1 ? n - 1 - i : i + 1); j < n; ++j) {
                int best = prev[j];
                if (j - 1 >= 0) {
                    best = best > prev[j - 1] ? best : prev[j - 1];
                }
                if (j + 1 < n) {
                    best = best > prev[j + 1] ? best : prev[j + 1];
                }
                curr[j] = best + fruits[i][j];
            }
            int* tmp = prev; 
            prev = curr; 
            curr = tmp;
        }

        int result = prev[n - 1];
        free(prev); free(curr);
        return result;
    }

    ans += dp();

    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < i; ++j) {
            int temp = fruits[j][i]; 
            fruits[j][i] = fruits[i][j]; 
            fruits[i][j]=temp;
        }
    }

    ans += dp();
    return ans;
}
```

```JavaScript
var maxCollectedFruits = function(fruits) {
    const n = fruits.length;
    let ans = 0;
    for (let i = 0; i < n; ++i) ans += fruits[i][i];

    function dp() {
        let prev = Array(n).fill(-Infinity);
        let curr = Array(n).fill(-Infinity);
        prev[n - 1] = fruits[0][n - 1];

        for (let i = 1; i < n - 1; ++i) {
            for (let j = Math.max(n - 1 - i, i + 1); j < n; ++j) {
                let best = prev[j];
                if (j - 1 >= 0) {
                    best = Math.max(best, prev[j - 1]);
                }
                if (j + 1 < n) {
                    best = Math.max(best, prev[j + 1]);
                }
                curr[j] = best + fruits[i][j];
            }
            [prev, curr] = [curr, prev];
        }
        return prev[n - 1];
    }

    ans += dp();
    for (let i = 0; i < n; ++i){
        for (let j = 0; j < i; ++j){
            [fruits[i][j], fruits[j][i]] = [fruits[j][i], fruits[i][j]];
        }
    }

    ans += dp();
    return ans;
};
```

```TypeScript
function maxCollectedFruits(fruits: number[][]): number {
    const n = fruits.length;
    let ans = 0;
    for (let i = 0; i < n; ++i) ans += fruits[i][i];

    const dp = (): number => {
        let prev: number[] = Array(n).fill(Number.MIN_SAFE_INTEGER);
        let curr: number[] = Array(n).fill(Number.MIN_SAFE_INTEGER);
        prev[n - 1] = fruits[0][n - 1];

        for (let i = 1; i < n - 1; ++i) {
            for (let j = Math.max(n - 1 - i, i + 1); j < n; ++j) {
                let best = prev[j];
                if (j - 1 >= 0) {
                    best = Math.max(best, prev[j - 1]);
                }
                if (j + 1 < n) {
                    best = Math.max(best, prev[j + 1]);
                }
                curr[j] = best + fruits[i][j];
            }
            [prev, curr] = [curr, prev];
        }

        return prev[n - 1];
    };

    ans += dp();
    for (let i = 0; i < n; ++i){
        for (let j = 0; j < i; ++j){
            [fruits[i][j], fruits[j][i]] = [fruits[j][i], fruits[i][j]];
        }
    }
    ans += dp();
    return ans;
};
```

```Rust
fn dp(fruits: &Vec<Vec<i32>>, n: usize) -> i32 {
    let mut prev = vec![i32::MIN; n];
    let mut curr = vec![i32::MIN; n];

    prev[n - 1] = fruits[0][n - 1];
    for i in 1..n - 1 {
        for j in (n - 1 - i).max(i + 1)..n {
            let mut best = prev[j];
            if j > 0 {
                best = best.max(prev[j - 1]);
            }
            if j + 1 < n {
                best = best.max(prev[j + 1]);
            }
            curr[j] = best + fruits[i][j];
        }
        std::mem::swap(&mut prev, &mut curr);
    }
    prev[n - 1]
}

impl Solution {
    pub fn max_collected_fruits(mut fruits: Vec<Vec<i32>>) -> i32 {
        let n = fruits.len();
        let mut ans = (0..n).map(|i| fruits[i][i]).sum::<i32>();

        ans += dp(&fruits, n);
        for i in 0..n {
            for j in 0..i {
                let tmp = fruits[i][j];
                fruits[i][j] = fruits[j][i];
                fruits[j][i] = tmp;
            }
        }
        ans += dp(&fruits, n);
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是 $fruits$ 的长度。计算上三角区域贡献的动态规划需要 $O(n^2)$。
- 空间复杂度：$O(n)$。我们使用滚动数组将空间复杂度从 $O(n^2)$ 优化到 $O(n)$。
