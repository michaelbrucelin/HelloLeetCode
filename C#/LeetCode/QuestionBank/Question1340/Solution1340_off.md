### [跳跃游戏 V](https://leetcode.cn/problems/jump-game-v/solutions/130601/tiao-yue-you-xi-v-by-leetcode-solution/)

#### 方法一：记忆化搜索

我们用 $dp[i]$ 表示从位置 $i$ 开始跳跃，最多可以访问的下标个数。我们可以写出如下的状态转移方程：

$$dp[i]=max(dp[j])+1$$

其中 $j$ 需要满足三个条件：

- $0\le j<arr.length$，即 $j$ 必须在数组 $arr$ 的范围内；
- $i-d\le j\le i+d$，即 $j$ 到 $i$ 的距离不能超过给定的 $d$；
- 从 $arr[j]$ 到 $arr[i]$ 的这些元素除了 $arr[i]$ 本身之外，都必须小于 $arr[i]$，这是题目中的要求。

对于任意的位置 $i$，根据第二个条件，我们只需要在其左右两侧最多扫描 $d$ 个元素，就可以找出所有满足条件的位置 $j$。随后我们通过这些 $j$ 的 $dp$ 值对位置 $i$ 进行状态转移，就可以得到 $dp[i]$ 的值。

此时出现了一个需要解决的问题：如何保证在处理到位置 $i$ 时，所有满足条件的位置 $j$ 都已经被处理过了呢？换句话说，如何保证这些位置 $j$ 对应的 $dp[j]$ 都已经计算过了？如果我们用常规的动态规划方法（例如根据位置从小到大或者从大到小进行动态规划），那么并不能保证这一点，因为 $j$ 分布在位置 $i$ 的两侧。

因此我们需要借助记忆化搜索的方法，即当我们需要 $dp[j]$ 的值时，如果我们之前已经计算过，就直接返回这个值（记忆）；如果我们之前没有计算过，就先将 $dp[i]$ 搁在一边，转而去计算 $dp[j]$（搜索），当 $dp[j]$ 计算完成后，再用其对 $dp[i]$ 进行状态转移。

记忆化搜索一定能在有限的时间内停止吗？如果它不能在有限的时间内停止，说明在搜索的过程中出现了环。即当我们需要计算 $dp[i]$ 时，我们发现某个 $dp[j]$ 没有计算过，接着在计算 $dp[j]$ 时，又发现某个 $dp[k]$ 没有计算过，以此类推，直到某次搜索时发现当前位置的 $dp$ 值需要 $dp[i]$ 的值才能得到，这样就出现了环。在本题中，根据第三个条件，$arr[j]$ 是一定小于 $arr[i]$ 的，即我们的搜索每深入一层，就跳到了高度更小的位置。因此在搜索的过程中不会出现环。这样一来，我们通过记忆化搜索，就可以在与常规的动态规划相同的时间复杂度内得到所有的 $dp$ 值。

注意：如果你不太能理解这篇题解在讲什么，请使用搜索引擎，补充「记忆化搜索」的相关知识。记忆化搜索以深度优先搜索为基础，在第一次搜索到某个状态时，会将该状态与其对应的值存储下来，这样在未来的搜索中，如果搜索到相同的状态，就不用再进行重复搜索了。记忆化搜索和动态规划非常相似，大部分的题目如果可以使用动态规划解决，那么一定可以使用记忆化搜索解决，反之亦然。这是因为记忆化搜索要求搜索状态满足拓扑序（即不会出现环），而动态规划同样要求状态满足拓扑序，不然就没法进行状态转移了。

```C++
class Solution {
private:
    vector<int> f;

public:
    void dfs(vector<int>& arr, int id, int d, int n) {
        if (f[id] != -1) {
            return;
        }
        f[id] = 1;
        for (int i = id - 1; i >= 0 && id - i <= d && arr[id] > arr[i]; --i) {
            dfs(arr, i, d, n);
            f[id] = max(f[id], f[i] + 1);
        }
        for (int i = id + 1; i < n && i - id <= d && arr[id] > arr[i]; ++i) {
            dfs(arr, i, d, n);
            f[id] = max(f[id], f[i] + 1);
        }
    }

    int maxJumps(vector<int>& arr, int d) {
        int n = arr.size();
        f.resize(n, -1);
        for (int i = 0; i < n; ++i) {
            dfs(arr, i, d, n);
        }
        return *max_element(f.begin(), f.end());
    }
};
```

```Python
class Solution:
    def maxJumps(self, arr: List[int], d: int) -> int:
        seen = dict()

        def dfs(pos):
            if pos in seen:
                return
            seen[pos] = 1

            i = pos - 1
            while i >= 0 and pos - i <= d and arr[pos] > arr[i]:
                dfs(i)
                seen[pos] = max(seen[pos], seen[i] + 1)
                i -= 1
            i = pos + 1
            while i < len(arr) and i - pos <= d and arr[pos] > arr[i]:
                dfs(i)
                seen[pos] = max(seen[pos], seen[i] + 1)
                i += 1

        for i in range(len(arr)):
            dfs(i)

        return max(seen.values())
```

```Java
class Solution {
    private int[] f;

    private void dfs(int[] arr, int id, int d, int n) {
        if (f[id] != -1) {
            return;
        }
        f[id] = 1;
        for (int i = id - 1; i >= 0 && id - i <= d && arr[id] > arr[i]; --i) {
            dfs(arr, i, d, n);
            f[id] = Math.max(f[id], f[i] + 1);
        }
        for (int i = id + 1; i < n && i - id <= d && arr[id] > arr[i]; ++i) {
            dfs(arr, i, d, n);
            f[id] = Math.max(f[id], f[i] + 1);
        }
    }

    public int maxJumps(int[] arr, int d) {
        int n = arr.length;
        f = new int[n];
        Arrays.fill(f, -1);
        for (int i = 0; i < n; ++i) {
            dfs(arr, i, d, n);
        }
        int ans = 0;
        for (int val : f) {
            ans = Math.max(ans, val);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    private int[] f;

    private void Dfs(int[] arr, int id, int d, int n) {
        if (f[id] != -1) {
            return;
        }
        f[id] = 1;
        for (int i = id - 1; i >= 0 && id - i <= d && arr[id] > arr[i]; --i) {
            Dfs(arr, i, d, n);
            f[id] = Math.Max(f[id], f[i] + 1);
        }
        for (int i = id + 1; i < n && i - id <= d && arr[id] > arr[i]; ++i) {
            Dfs(arr, i, d, n);
            f[id] = Math.Max(f[id], f[i] + 1);
        }
    }

    public int MaxJumps(int[] arr, int d) {
        int n = arr.Length;
        f = new int[n];
        Array.Fill(f, -1);
        for (int i = 0; i < n; ++i) {
            Dfs(arr, i, d, n);
        }
        return f.Max();
    }
}
```

```Go
func maxJumps(arr []int, d int) int {
    n := len(arr)
    f := make([]int, n)
    for i := range f {
        f[i] = -1
    }

    var dfs func(int)
    dfs = func(id int) {
        if f[id] != -1 {
            return
        }
        f[id] = 1
        for i := id - 1; i >= 0 && id-i <= d && arr[id] > arr[i]; i-- {
            dfs(i)
            if f[i]+1 > f[id] {
                f[id] = f[i] + 1
            }
        }
        for i := id + 1; i < n && i-id <= d && arr[id] > arr[i]; i++ {
            dfs(i)
            if f[i]+1 > f[id] {
                f[id] = f[i] + 1
            }
        }
    }

    for i := 0; i < n; i++ {
        dfs(i)
    }

    ans := 0
    for _, val := range f {
        if val > ans {
            ans = val
        }
    }
    return ans
}
```

```C
void dfs(int* arr, int id, int d, int n, int *f) {
    if (f[id] != -1) {
        return;
    }
    f[id] = 1;
    for (int i = id - 1; i >= 0 && id - i <= d && arr[id] > arr[i]; --i) {
        dfs(arr, i, d, n, f);
        if (f[i] + 1 > f[id]) {
            f[id] = f[i] + 1;
        }
    }
    for (int i = id + 1; i < n && i - id <= d && arr[id] > arr[i]; ++i) {
        dfs(arr, i, d, n, f);
        if (f[i] + 1 > f[id]) {
            f[id] = f[i] + 1;
        }
    }
}

int maxJumps(int* arr, int arrSize, int d) {
    int n = arrSize;
    int *f = (int*)malloc(n * sizeof(int));
    for (int i = 0; i < n; ++i) {
        f[i] = -1;
    }

    for (int i = 0; i < n; ++i) {
        dfs(arr, i, d, n, f);
    }

    int ans = 0;
    for (int i = 0; i < n; ++i) {
        if (f[i] > ans) {
            ans = f[i];
        }
    }

    free(f);
    return ans;
}
```

```JavaScript
var maxJumps = function(arr, d) {
    const n = arr.length;
    const f = new Array(n).fill(-1);

    const dfs = (id) => {
        if (f[id] !== -1) {
            return;
        }
        f[id] = 1;
        for (let i = id - 1; i >= 0 && id - i <= d && arr[id] > arr[i]; --i) {
            dfs(i);
            f[id] = Math.max(f[id], f[i] + 1);
        }
        for (let i = id + 1; i < n && i - id <= d && arr[id] > arr[i]; ++i) {
            dfs(i);
            f[id] = Math.max(f[id], f[i] + 1);
        }
    };

    for (let i = 0; i < n; ++i) {
        dfs(i);
    }

    return Math.max(...f);
};
```

```TypeScript
function maxJumps(arr: number[], d: number): number {
    const n = arr.length;
    const f: number[] = new Array(n).fill(-1);

    const dfs = (id: number): void => {
        if (f[id] !== -1) {
            return;
        }
        f[id] = 1;
        for (let i = id - 1; i >= 0 && id - i <= d && arr[id] > arr[i]; --i) {
            dfs(i);
            f[id] = Math.max(f[id], f[i] + 1);
        }
        for (let i = id + 1; i < n && i - id <= d && arr[id] > arr[i]; ++i) {
            dfs(i);
            f[id] = Math.max(f[id], f[i] + 1);
        }
    };

    for (let i = 0; i < n; ++i) {
        dfs(i);
    }

    return Math.max(...f);
}
```

```Rust
impl Solution {
    pub fn max_jumps(arr: Vec<i32>, d: i32) -> i32 {
        let n = arr.len();
        let mut f = vec![-1; n];
        let d = d as usize;

        fn dfs(arr: &Vec<i32>, f: &mut Vec<i32>, id: usize, d: usize, n: usize) {
            if f[id] != -1 {
                return;
            }
            f[id] = 1;

            let mut i = id as i32 - 1;
            while i >= 0 && (id as i32 - i) <= d as i32 && arr[id] > arr[i as usize] {
                let i_idx = i as usize;
                dfs(arr, f, i_idx, d, n);
                f[id] = f[id].max(f[i_idx] + 1);
                i -= 1;
            }

            for i in id + 1..n {
                if i - id <= d && arr[id] > arr[i] {
                    dfs(arr, f, i, d, n);
                    f[id] = f[id].max(f[i] + 1);
                } else {
                    break;
                }
            }
        }

        for i in 0..n {
            dfs(&arr, &mut f, i, d, n);
        }

        *f.iter().max().unwrap()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(ND)$，其中 $N$ 是数组 `arr` 的长度。
- 空间复杂度：$O(N)$。

**思考**

上面我们提到：大部分的题目如果可以使用动态规划解决，那么一定可以使用记忆化搜索解决，反之亦然。那么本题如何使用动态规划解决呢？

由于我们已经得到了状态转移方程，因此重点在于动态规划的顺序。可以发现，如果我们将所有的位置按照高度进行升序排序，并按照该顺序计算状态转移方程，那么就可以完成动态规划。这是因为在第三个条件中，`arr[j] < arr[i]` 一定成立，因此对于位置 `i`，如果我们在此之前计算出了所有高度小于 `arr[i]` 的位置的 `dp` 值，那么在对位置 `i` 进行状态转移时，所有满足条件的 `j` 的 `dp` 值就已经全部计算完成了，因此我们可以通过该顺序完成动态规划。
