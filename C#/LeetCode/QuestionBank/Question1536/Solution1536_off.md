### [排布二进制网格的最少交换次数](https://leetcode.cn/problems/minimum-swaps-to-arrange-a-binary-grid/solutions/371355/pai-bu-er-jin-zhi-wang-ge-de-zui-shao-jiao-huan-ci/)

#### 方法一：贪心

**思路与算法**

我们从上到下逐行确定，假设当前考虑到第 $i$ 行，第 $0\dots i-1$ 行都已经确定好。按题意第 $i$ 行满足的条件为末尾连续零的个数大于等于 $n-i-1$，那么我们考虑将 $[i\dots n-1]$ 中的哪一行逐行交换到第 $i$ 行。假设当前有多行都满足第 $i$ 行的条件，我们应该选择哪一行交换到第 $i$ 行呢？为了令最后交换次数最少，我们贪心地选择**离第 $i$ 行最近的那一行**即可。

你可能会在想这样是否一定正确。我们可以考虑假设当前有若干行都能满足第 $i$ 行，那么这些行一定都满足第 $i+1\dots n-1$ 的限制条件，也就是说能交换到第 $i$ 行的那些行一定也能交换到后面几行，因为随着行数的增加，限制条件越来越宽松。因此不会存在贪心地选择后，后面出现无法放置的情况。

最后来看实现。为了避免每次判断当前行是否满足末尾连续零的个数的限制条件的时候都要从后往前遍历当前行，造成不必要的时间消耗，我们需要先用 $O(n^2)$ 的操作**预处理出每一行最后一个 $1$ 所在的位置**，记为 $pos[i]$。这样我们就可以按照我们的策略模拟，从上到下逐行确定，对于第 $i$ 行，只要找到第 $i\dots n-1$ 行中使得 $pos[j]\le i$ 成立的最近的那一行 $j$，我们将这一行交换到第 $i$ 行即可，它对答案的贡献为 $j-i$。

**代码**

```C++
class Solution {
public:
    int minSwaps(vector<vector<int>>& grid) {
        int n = grid.size();
        vector<int> pos(n, -1);
        for (int i = 0; i < n; ++i) {
            for (int j = n - 1; j >= 0; --j) {
                if (grid[i][j] == 1) {
                    pos[i] = j;
                    break;
                }
            }
        }
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            int k = -1;
            for (int j = i; j < n; ++j) {
                if (pos[j] <= i) {
                    ans += j - i;
                    k = j;
                    break;
                }
            }
            if (~k) {
                for (int j = k; j > i; --j) {
                    swap(pos[j], pos[j - 1]);
                }
            } else {
                return -1;
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int minSwaps(int[][] grid) {
        int n = grid.length;
        int[] pos = new int[n];
        Arrays.fill(pos, -1);
        for (int i = 0; i < n; ++i) {
            for (int j = n - 1; j >= 0; --j) {
                if (grid[i][j] == 1) {
                    pos[i] = j;
                    break;
                }
            }
        }
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            int k = -1;
            for (int j = i; j < n; ++j) {
                if (pos[j] <= i) {
                    ans += j - i;
                    k = j;
                    break;
                }
            }
            if (k >= 0) {
                for (int j = k; j > i; --j) {
                    int temp = pos[j];
                    pos[j] = pos[j - 1];
                    pos[j - 1] = temp;
                }
            } else {
                return -1;
            }
        }
        return ans;
    }
}
```

```JavaScript
var minSwaps = function(grid) {
    const n = grid.length;
    const pos = new Array(n).fill(-1);
    for (let i = 0; i < n; ++i) {
        for (let j = n - 1; j >= 0; --j) {
            if (grid[i][j] == 1) {
                pos[i] = j;
                break;
            }
        }
    }
    let ans = 0;
    for (let i = 0; i < n; ++i) {
        let k = -1;
        for (let j = i; j < n; ++j) {
            if (pos[j] <= i) {
                ans += j - i;
                k = j;
                break;
            }
        }
        if (~k) {
            for (let j = k; j > i; --j) {
                const temp = pos[j];
                pos[j] = pos[j - 1];
                pos[j - 1] = temp;
            }
        } else {
            return -1;
        }
    }
    return ans;
};
```

```Python
class Solution:
    def minSwaps(self, grid: List[List[int]]) -> int:
        n = len(grid)
        pos = [-1] * n
        for i in range(n):
            for j in range(n - 1, -1, -1):
                if grid[i][j] == 1:
                    pos[i] = j
                    break

        ans = 0
        for i in range(n):
            k = -1
            for j in range(i, n):
                if pos[j] <= i:
                    ans += j - i
                    k = j
                    break

            if k != -1:
                for j in range(k, i, -1):
                    pos[j], pos[j - 1] = pos[j - 1], pos[j]
            else:
                return -1

        return ans
```

```CSharp
public class Solution {
    public int MinSwaps(int[][] grid) {
        int n = grid.Length;
        int[] pos = new int[n];
        Array.Fill(pos, -1);

        for (int i = 0; i < n; ++i) {
            for (int j = n - 1; j >= 0; --j) {
                if (grid[i][j] == 1) {
                    pos[i] = j;
                    break;
                }
            }
        }

        int ans = 0;
        for (int i = 0; i < n; ++i) {
            int k = -1;
            for (int j = i; j < n; ++j) {
                if (pos[j] <= i) {
                    ans += j - i;
                    k = j;
                    break;
                }
            }

            if (k != -1) {
                for (int j = k; j > i; --j) {
                    (pos[j], pos[j - 1]) = (pos[j - 1], pos[j]);
                }
            } else {
                return -1;
            }
        }
        return ans;
    }
}
```

```Go
func minSwaps(grid [][]int) int {
    n := len(grid)
    pos := make([]int, n)
    for i := range pos {
        pos[i] = -1
    }

    for i := 0; i < n; i++ {
        for j := n - 1; j >= 0; j-- {
            if grid[i][j] == 1 {
                pos[i] = j
                break
            }
        }
    }

    ans := 0
    for i := 0; i < n; i++ {
        k := -1
        for j := i; j < n; j++ {
            if pos[j] <= i {
                ans += j - i
                k = j
                break
            }
        }

        if k != -1 {
            for j := k; j > i; j-- {
                pos[j], pos[j-1] = pos[j-1], pos[j]
            }
        } else {
            return -1
        }
    }
    return ans
}
```

```C
int minSwaps(int** grid, int gridSize, int* gridColSize) {
    int n = gridSize;
    int* pos = (int*)malloc(n * sizeof(int));

    for (int i = 0; i < n; ++i) {
        pos[i] = -1;
        for (int j = n - 1; j >= 0; --j) {
            if (grid[i][j] == 1) {
                pos[i] = j;
                break;
            }
        }
    }

    int ans = 0;
    for (int i = 0; i < n; ++i) {
        int k = -1;
        for (int j = i; j < n; ++j) {
            if (pos[j] <= i) {
                ans += j - i;
                k = j;
                break;
            }
        }

        if (k != -1) {
            for (int j = k; j > i; --j) {
                int temp = pos[j];
                pos[j] = pos[j - 1];
                pos[j - 1] = temp;
            }
        } else {
            free(pos);
            return -1;
        }
    }

    free(pos);
    return ans;
}
```

```TypeScript
function minSwaps(grid: number[][]): number {
    const n: number = grid.length;
    const pos: number[] = new Array(n).fill(-1);

    for (let i = 0; i < n; ++i) {
        for (let j = n - 1; j >= 0; --j) {
            if (grid[i][j] === 1) {
                pos[i] = j;
                break;
            }
        }
    }

    let ans = 0;
    for (let i = 0; i < n; ++i) {
        let k = -1;
        for (let j = i; j < n; ++j) {
            if (pos[j] <= i) {
                ans += j - i;
                k = j;
                break;
            }
        }

        if (k !== -1) {
            for (let j = k; j > i; --j) {
                [pos[j], pos[j - 1]] = [pos[j - 1], pos[j]];
            }
        } else {
            return -1;
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn min_swaps(grid: Vec<Vec<i32>>) -> i32 {
        let n = grid.len();
        let mut pos = vec![-1; n];

        for i in 0..n {
            for j in (0..n).rev() {
                if grid[i][j] == 1 {
                    pos[i] = j as i32;
                    break;
                }
            }
        }

        let mut ans = 0;
        let mut pos = pos;
        for i in 0..n {
            let mut k = -1;
            for j in i..n {
                if pos[j] <= i as i32 {
                    ans += j - i;
                    k = j as i32;
                    break;
                }
            }

            if k != -1 {
                let k = k as usize;
                for j in (i + 1..= k).rev() {
                    pos.swap(j, j - 1);
                }
            } else {
                return -1;
            }
        }
        ans as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 为网格的行数。预处理 $pos$ 数组需要 $O(n^2)$ 的时间复杂度，贪心计算答案需要 $O(n^2)$ 的时间复杂度，因此总时间复杂度为 $O(n^2)$。
- 空间复杂度：$O(n)$。pos 数组需要 $O(n)$ 的空间。
