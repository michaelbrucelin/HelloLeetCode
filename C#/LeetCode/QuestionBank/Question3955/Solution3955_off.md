### [石子游戏 III](https://leetcode.cn/problems/stone-game-iii/solutions/327144/shi-zi-you-xi-iii-by-leetcode-solution/?envType=daily-question&envId=2026-08-03)

#### 方法一：动态规划

对于这种两个玩家、分先后手、博弈类型的题目，我们一般可以使用动态规划来解决。

由于玩家只能拿走前面的石子，因此我们考虑使用状态 $f[i]$ 表示还剩下第 $i,i+1,\dots ,n-1$ 堆石子时，**当前玩家**（也就是当前准备拿石子的那一名玩家）的某一个状态。这个「某一个状态」具体是什么状态，我们暂且不表，这里带着大家一步一步来分析这个状态。

根据题目描述，当前玩家有三种策略可以选择，即取走前 1、2 或 $3$ 堆石子，那么留给 **下一位玩家（也就是下一个准备拿石子的那一名玩家）** 的状态为 $f[i+1]$、$f[i+2]$ 或 $f[i+3]$。设想一下，假如你是当前玩家，你希望 $f[i]$ 表示什么，才可以帮助你选择自己的 **最优策略** 呢？

一个聪明的读者会说：**我希望 $f[i]$ 表示还剩下第 $i,i+1,\dots ,n-1$ 堆石子时，当前玩家最多能从剩下的石子中拿到的石子数目（这个「剩下」的意义是，如果 $i,i+1,\dots n-1$ 堆石子的总数是 $t$，Alice 拿走了 $x$，Bob 就拿走了 $t-x$，也就是我们只讨论 $i,i+1,\dots n-1$ 堆石子，而不讨论对 $0,1,\dots ,i-1$ 堆石子 $Alice$ 和 $Bob$ 作出了怎样的决策）**。这样以来：

- 如果当前玩家选择了一堆石子，那么留给下一位玩家的状态为 $f[i+1]$，表示他可以最多拿到 $f[i+1]$ 数量的石子。
  - 咦？我们之前的定义中，$f[i+1]$ 是表示当前玩家最多能拿到的石子数目，为什么这里变成了下一位玩家呢？仔细想想，「当前玩家」和「下一位玩家」的概念其实是相对的。在「当前玩家」拿完石子后，「下一位玩家」就成了此时的「当前玩家」）。
    由于下一位玩家可以拿 $f[i+1]$ 数量的石子，如果我们用 $sum(l,r)$ 表示第 $l,l+1,\dots ,r$ 堆石子的的数量之和，那么当前玩家就可以拿到 $sum(i+1,n-1)-f[i+1]$ 数量的石子。加上当前玩家选择了一堆石子，它一共可以拿到 $sum(i,i)+sum(i+1,n-1)-f[i+1]$ 数量的石子。可以发现，它可以化简为 $sum(i,n-1)-f[i+1]$；
- 同理，如果当前玩家选择了两堆石子，那么留给下一位玩家的状态为 $f[i+2]$，当前玩家一共可以拿到 $sum(i,n-1)-f[i+2]$ 数量的石子；
- 同理，如果当前玩家选择了三堆石子，那么留给下一位玩家的状态为 $f[i+3]$，当前玩家一共可以拿到 $sum(i,n-1)-f[i+3]$ 数量的石子。

这样以来，当前玩家只要选择上面三种情况中能拿到最多数量的石子的方案，就是他的最优策略。

因此，我们就可以用动态规划来解决这个问题了。我们首先处理出表示石子数量的数组 $values$ 的后缀和，方便我们快速地求出 $sum(l,r)$。随后，我们就可以倒序地进行动态规划（因为在计算 $f[i]$ 的值的时候，需要已经求出 $f[i+1]$，f[i+2] 和 $f[i+3]$ 的值），状态转移方程为：

$$\begin{array}{rcl}f[i] & = & max(sum(i,n-1)-f[j]) \\ & = & sum(i,n-1)-min(f[j]),j\in [i+1,i+3]\end{array}$$

最后的 $f[0]$ 就表示 $Alice$ 最多可以获得的石子数量。我们根据 $f[0]$ 与 $sum(0,n-1)$ 的关系，就可以得到最终的获胜者。

```C++
class Solution {
public:
    string stoneGameIII(vector<int>& stoneValue) {
        int n = stoneValue.size();

        vector<int> suffix_sum(n);
        suffix_sum[n - 1] = stoneValue[n - 1];
        for (int i = n - 2; i >= 0; --i) {
            suffix_sum[i] = suffix_sum[i + 1] + stoneValue[i];
        }

        vector<int> f(n + 1);
        // 边界情况，当没有石子时，分数为 0
        // 为了代码的可读性，显式声明
        f[n] = 0;
        for (int i = n - 1; i >= 0; --i) {
            int bestj = f[i + 1];
            for (int j = i + 2; j <= i + 3 && j <= n; ++j) {
                bestj = min(bestj, f[j]);
            }
            f[i] = suffix_sum[i] - bestj;
        }

        int total = accumulate(stoneValue.begin(), stoneValue.end(), 0);
        if (f[0] * 2 == total) {
            return "Tie";
        }
        else {
            return f[0] * 2 > total ? "Alice" : "Bob";
        }
    }
};
```

```C++
// C++17
class Solution {
public:
    string stoneGameIII(vector<int>& stoneValue) {
        int n = stoneValue.size();

        vector<int> suffix_sum(n);
        suffix_sum[n - 1] = stoneValue[n - 1];
        for (int i = n - 2; i >= 0; --i) {
            suffix_sum[i] = suffix_sum[i + 1] + stoneValue[i];
        }

        vector<int> f(n + 1);
        // 边界情况，当没有石子时，分数为 0
        // 为了代码的可读性，显式声明
        f[n] = 0;
        for (int i = n - 1; i >= 0; --i) {
            int bestj = f[i + 1];
            for (int j = i + 2; j <= i + 3 && j <= n; ++j) {
                bestj = min(bestj, f[j]);
            }
            f[i] = suffix_sum[i] - bestj;
        }

        if (int total = accumulate(stoneValue.begin(), stoneValue.end(), 0); f[0] * 2 == total) {
            return "Tie";
        }
        else {
            return f[0] * 2 > total ? "Alice" : "Bob";
        }
    }
};
```

```Python
class Solution:
    def stoneGameIII(self, stoneValue: List[int]) -> str:
        n = len(stoneValue)

        suffix_sum = [0] * (n - 1) + [stoneValue[-1]]
        for i in range(n - 2, -1, -1):
            suffix_sum[i] = suffix_sum[i + 1] + stoneValue[i]

        # 边界情况，当没有石子时，分数为 0
        # 为了代码的可读性，显式声明
        f = [0] * n + [0]
        for i in range(n - 1, -1, -1):
            f[i] = suffix_sum[i] - min(f[i+1:i+4])

        total = sum(stoneValue)
        if f[0] * 2 == total:
            return "Tie"
        else:
            return "Alice" if f[0] * 2 > total else "Bob"
```

```Java
class Solution {
    public String stoneGameIII(int[] stoneValue) {
        int n = stoneValue.length;
        int[] suffixSum = new int[n];
        suffixSum[n - 1] = stoneValue[n - 1];
        for (int i = n - 2; i >= 0; --i) {
            suffixSum[i] = suffixSum[i + 1] + stoneValue[i];
        }
        int[] f = new int[n + 1];
        // 边界情况，当没有石子时，分数为 0
        // 为了代码的可读性，显式声明
        f[n] = 0;
        for (int i = n - 1; i >= 0; --i) {
            int bestj = f[i + 1];
            for (int j = i + 2; j <= i + 3 && j <= n; ++j) {
                bestj = Math.min(bestj, f[j]);
            }
            f[i] = suffixSum[i] - bestj;
        }
        int total = 0;
        for (int value : stoneValue) {
            total += value;
        }
        if (f[0] * 2 == total) {
            return "Tie";
        } else {
            return f[0] * 2 > total ? "Alice" : "Bob";
        }
    }
}
```

```CSharp
public class Solution {
    public string StoneGameIII(int[] stoneValue) {
        int n = stoneValue.Length;
        int[] suffixSum = new int[n];
        suffixSum[n - 1] = stoneValue[n - 1];
        for (int i = n - 2; i >= 0; --i) {
            suffixSum[i] = suffixSum[i + 1] + stoneValue[i];
        }
        int[] f = new int[n + 1];
        // 边界情况，当没有石子时，分数为 0
        // 为了代码的可读性，显式声明
        f[n] = 0;
        for (int i = n - 1; i >= 0; --i) {
            int bestj = f[i + 1];
            for (int j = i + 2; j <= i + 3 && j <= n; ++j) {
                bestj = Math.Min(bestj, f[j]);
            }
            f[i] = suffixSum[i] - bestj;
        }
        int total = 0;
        foreach (int value in stoneValue) {
            total += value;
        }
        if (f[0] * 2 == total) {
            return "Tie";
        } else {
            return f[0] * 2 > total ? "Alice" : "Bob";
        }
    }
}
```

```Go
func stoneGameIII(stoneValue []int) string {
    n := len(stoneValue)
    suffixSum := make([]int, n)
    suffixSum[n-1] = stoneValue[n-1]
    for i := n - 2; i >= 0; i-- {
        suffixSum[i] = suffixSum[i+1] + stoneValue[i]
    }
    f := make([]int, n+1)
    // 边界情况，当没有石子时，分数为 0
    // 为了代码的可读性，显式声明
    f[n] = 0
    for i := n - 1; i >= 0; i-- {
        bestj := f[i+1]
        for j := i + 2; j <= i+3 && j <= n; j++ {
            if f[j] < bestj {
                bestj = f[j]
            }
        }
        f[i] = suffixSum[i] - bestj
    }
    total := 0
    for _, value := range stoneValue {
        total += value
    }
    if f[0]*2 == total {
        return "Tie"
    } else if f[0]*2 > total {
        return "Alice"
    } else {
        return "Bob"
    }
}
```

```C
char* stoneGameIII(int* stoneValue, int stoneValueSize) {
    int n = stoneValueSize;
    int* suffixSum = (int*)malloc(sizeof(int) * n);
    suffixSum[n - 1] = stoneValue[n - 1];
    for (int i = n - 2; i >= 0; --i) {
        suffixSum[i] = suffixSum[i + 1] + stoneValue[i];
    }
    int* f = (int*)malloc(sizeof(int) * (n + 1));
    // 边界情况，当没有石子时，分数为 0
    // 为了代码的可读性，显式声明
    f[n] = 0;
    for (int i = n - 1; i >= 0; --i) {
        int bestj = f[i + 1];
        for (int j = i + 2; j <= i + 3 && j <= n; ++j) {
            if (f[j] < bestj) {
                bestj = f[j];
            }
        }
        f[i] = suffixSum[i] - bestj;
    }
    int total = 0;
    for (int i = 0; i < n; ++i) {
        total += stoneValue[i];
    }
    char* result = (char*)malloc(sizeof(char) * 10);
    if (f[0] * 2 == total) {
        strcpy(result, "Tie");
    } else if (f[0] * 2 > total) {
        strcpy(result, "Alice");
    } else {
        strcpy(result, "Bob");
    }
    free(suffixSum);
    free(f);

    return result;
}
```

```JavaScript
var stoneGameIII = function(stoneValue) {
    const n = stoneValue.length;
    const suffixSum = new Array(n);
    suffixSum[n - 1] = stoneValue[n - 1];
    for (let i = n - 2; i >= 0; --i) {
        suffixSum[i] = suffixSum[i + 1] + stoneValue[i];
    }
    const f = new Array(n + 1);
    // 边界情况，当没有石子时，分数为 0
    // 为了代码的可读性，显式声明
    f[n] = 0;
    for (let i = n - 1; i >= 0; --i) {
        let bestj = f[i + 1];
        for (let j = i + 2; j <= i + 3 && j <= n; ++j) {
            bestj = Math.min(bestj, f[j]);
        }
        f[i] = suffixSum[i] - bestj;
    }
    let total = 0;
    for (const value of stoneValue) {
        total += value;
    }
    if (f[0] * 2 === total) {
        return "Tie";
    } else {
        return f[0] * 2 > total ? "Alice" : "Bob";
    }
};
```

```TypeScript
function stoneGameIII(stoneValue: number[]): string {
    const n = stoneValue.length;
    const suffixSum: number[] = new Array(n);
    suffixSum[n - 1] = stoneValue[n - 1];
    for (let i = n - 2; i >= 0; --i) {
        suffixSum[i] = suffixSum[i + 1] + stoneValue[i];
    }
    const f: number[] = new Array(n + 1);
    // 边界情况，当没有石子时，分数为 0
    // 为了代码的可读性，显式声明
    f[n] = 0;
    for (let i = n - 1; i >= 0; --i) {
        let bestj = f[i + 1];
        for (let j = i + 2; j <= i + 3 && j <= n; ++j) {
            bestj = Math.min(bestj, f[j]);
        }
        f[i] = suffixSum[i] - bestj;
    }
    let total = 0;
    for (const value of stoneValue) {
        total += value;
    }
    if (f[0] * 2 === total) {
        return "Tie";
    } else {
        return f[0] * 2 > total ? "Alice" : "Bob";
    }
};
```

```Rust
impl Solution {
    pub fn stone_game_iii(stone_value: Vec<i32>) -> String {
        let n = stone_value.len();
        let mut suffix_sum = vec![0; n];
        suffix_sum[n - 1] = stone_value[n - 1];
        for i in (0..n - 1).rev() {
            suffix_sum[i] = suffix_sum[i + 1] + stone_value[i];
        }
        let mut f = vec![0; n + 1];
        // 边界情况，当没有石子时，分数为 0
        // 为了代码的可读性，显式声明
        f[n] = 0;
        for i in (0..n).rev() {
            let mut bestj = f[i + 1];
            for j in (i + 2)..=(i + 3).min(n) {
                bestj = bestj.min(f[j]);
            }
            f[i] = suffix_sum[i] - bestj;
        }
        let total: i32 = stone_value.iter().sum();
        if f[0] * 2 == total {
            "Tie".to_string()
        } else if f[0] * 2 > total {
            "Alice".to_string()
        } else {
            "Bob".to_string()
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(N)$，其中 $N$ 是数组 $values$ 的长度。
- 空间复杂度：$O(N)$。

#### 方法二：另一种状态的设计思路

一个更聪明的读者会说：**我希望 $f[i]$ 表示还剩下第 $i,i+1,\dots ,n-1$ 堆石子时，当前玩家比下一位玩家最多能多拿到的石子数目（注意此时依旧是在剩下的石子中定义的）**。这样以来：

- 如果当前玩家选择了一堆石子，那么留给下一位玩家的状态为 $f[i+1]$，表示下一位玩家最多最多可以比当前玩家多拿到 $f[i+1]$ 数量的石子。那么当前玩家可以比下一位玩家多拿到 $value[i]-f[i+1]$ 数量的石子；
- 同理，如果当前玩家选择了两堆石子，那么留给下一位玩家的状态为 $f[i+2]$，当前玩家可以比下一位玩家多拿到 $value[i]+value[i+1]-f[i+2]$ 数量的石子；
- 同理，如果当前玩家选择了三堆石子，那么留给下一位玩家的状态为 $f[i+3]$，当前玩家可以比下一位玩家多拿到 $value[i]+value[i+1]+value[i+2]-f[i+3]$ 数量的石子；

这样以来，当前玩家只要选择上面三种情况中能比下一位玩家多拿到最多数量的石子的方案，就是他的最优策略。

因此，我们就可以写出使用另一种动态规划的状态转移方程：

$$f[i]=max(sum(i,j-1)-f[j]),j\in [i+1,i+3]$$

最后的 $f[0]$ 就表示 $Alice$ 最多可以比 $Bob$ 多获得的石子数量。我们根据 $f[0]$ 与 $0$ 的关系，就可以得到最终的获胜者。

**注解**

方法二的状态转移方程与方法一实际上是等价的，因为 **A 希望尽可能多地拿到石子** 和 **A 希望进行多地比 $B$ 拿到的石子多** 这两者是等价的。

```C++
class Solution {
public:
    string stoneGameIII(vector<int>& stoneValue) {
        int n = stoneValue.size();

        vector<int> f(n + 1, INT_MIN);
        // 边界情况，当没有石子时，分数为 0
        f[n] = 0;
        for (int i = n - 1; i >= 0; --i) {
            int pre = 0;
            for (int j = i + 1; j <= i + 3 && j <= n; ++j) {
                pre += stoneValue[j - 1];
                f[i] = max(f[i], pre - f[j]);
            }
        }

        if (f[0] == 0) {
            return "Tie";
        }
        else {
            return f[0] > 0 ? "Alice" : "Bob";
        }
    }
};
```

```Python
class Solution:
    def stoneGameIII(self, stoneValue: List[int]) -> str:
        n = len(stoneValue)

        # 边界情况，当没有石子时，分数为 0
        f = [-10**9] * n + [0]
        for i in range(n - 1, -1, -1):
            pre = 0
            for j in range(i + 1, min(i + 3, n) + 1):
                pre += stoneValue[j - 1]
                f[i] = max(f[i], pre - f[j])

        if f[0] == 0:
            return "Tie"
        else:
            return "Alice" if f[0] > 0 else "Bob"
```

```Java
class Solution {
    public String stoneGameIII(int[] stoneValue) {
        int n = stoneValue.length;
        int[] f = new int[n + 1];
        Arrays.fill(f, Integer.MIN_VALUE);
        // 边界情况，当没有石子时，分数为 0
        f[n] = 0;
        for (int i = n - 1; i >= 0; --i) {
            int pre = 0;
            for (int j = i + 1; j <= i + 3 && j <= n; ++j) {
                pre += stoneValue[j - 1];
                f[i] = Math.max(f[i], pre - f[j]);
            }
        }
        if (f[0] == 0) {
            return "Tie";
        } else {
            return f[0] > 0 ? "Alice" : "Bob";
        }
    }
}
```

```CSharp
public class Solution {
    public string StoneGameIII(int[] stoneValue) {
        int n = stoneValue.Length;
        int[] f = new int[n + 1];
        for (int i = 0; i <= n; i++) {
            f[i] = int.MinValue;
        }
        // 边界情况，当没有石子时，分数为 0
        f[n] = 0;
        for (int i = n - 1; i >= 0; --i) {
            int pre = 0;
            for (int j = i + 1; j <= i + 3 && j <= n; ++j) {
                pre += stoneValue[j - 1];
                f[i] = Math.Max(f[i], pre - f[j]);
            }
        }

        if (f[0] == 0) {
            return "Tie";
        } else {
            return f[0] > 0 ? "Alice" : "Bob";
        }
    }
}
```

```Go
func stoneGameIII(stoneValue []int) string {
    n := len(stoneValue)
    f := make([]int, n+1)
    for i := 0; i <= n; i++ {
        f[i] = int(^uint(0) >> 1)
    }
    // 边界情况，当没有石子时，分数为 0
    f[n] = 0
    for i := n - 1; i >= 0; i-- {
        pre := 0
        for j := i + 1; j <= i+3 && j <= n; j++ {
            pre += stoneValue[j-1]
            if pre-f[j] > f[i] {
                f[i] = pre - f[j]
            }
        }
    }

    if f[0] == 0 {
        return "Tie"
    } else if f[0] > 0 {
        return "Alice"
    } else {
        return "Bob"
    }
}
```

```C
char* stoneGameIII(int* stoneValue, int stoneValueSize) {
    int n = stoneValueSize;
    int* f = (int*)malloc(sizeof(int) * (n + 1));
    for (int i = 0; i <= n; i++) {
        f[i] = INT_MIN;
    }
    // 边界情况，当没有石子时，分数为 0
    f[n] = 0;
    for (int i = n - 1; i >= 0; --i) {
        int pre = 0;
        for (int j = i + 1; j <= i + 3 && j <= n; ++j) {
            pre += stoneValue[j - 1];
            if (pre - f[j] > f[i]) {
                f[i] = pre - f[j];
            }
        }
    }

    char* result = (char*)malloc(sizeof(char) * 10);
    if (f[0] == 0) {
        strcpy(result, "Tie");
    } else if (f[0] > 0) {
        strcpy(result, "Alice");
    } else {
        strcpy(result, "Bob");
    }
    free(f);
    return result;
}
```

```JavaScript
var stoneGameIII = function(stoneValue) {
    const n = stoneValue.length;
    const f = new Array(n + 1).fill(-Infinity);
    // 边界情况，当没有石子时，分数为 0
    f[n] = 0;
    for (let i = n - 1; i >= 0; --i) {
        let pre = 0;
        for (let j = i + 1; j <= i + 3 && j <= n; ++j) {
            pre += stoneValue[j - 1];
            f[i] = Math.max(f[i], pre - f[j]);
        }
    }

    if (f[0] === 0) {
        return "Tie";
    } else {
        return f[0] > 0 ? "Alice" : "Bob";
    }
};
```

```TypeScript
function stoneGameIII(stoneValue: number[]): string {
    const n = stoneValue.length;
    const f: number[] = new Array(n + 1).fill(-Infinity);
    // 边界情况，当没有石子时，分数为 0
    f[n] = 0;
    for (let i = n - 1; i >= 0; --i) {
        let pre = 0;
        for (let j = i + 1; j <= i + 3 && j <= n; ++j) {
            pre += stoneValue[j - 1];
            f[i] = Math.max(f[i], pre - f[j]);
        }
    }

    if (f[0] === 0) {
        return "Tie";
    } else {
        return f[0] > 0 ? "Alice" : "Bob";
    }
};
```

```Rust
impl Solution {
    pub fn stone_game_iii(stone_value: Vec<i32>) -> String {
        let n = stone_value.len();
        let mut f = vec![i32::MIN; n + 1];
        // 边界情况，当没有石子时，分数为 0
        f[n] = 0;
        for i in (0..n).rev() {
            let mut pre = 0;
            for j in i + 1..= (i + 3).min(n) {
                pre += stone_value[j - 1];
                f[i] = f[i].max(pre - f[j]);
            }
        }

        if f[0] == 0 {
            "Tie".to_string()
        } else if f[0] > 0 {
            "Alice".to_string()
        } else {
            "Bob".to_string()
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(N)$，其中 $N$ 是数组 $values$ 的长度。
- 空间复杂度：$O(N)$。
