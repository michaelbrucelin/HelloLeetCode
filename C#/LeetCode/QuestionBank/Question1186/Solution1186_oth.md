### [教你一步步思考动态规划！（Python/Java/C++/Go）](https://leetcode.cn/problems/maximum-subarray-sum-with-one-deletion/solutions/2321829/jiao-ni-yi-bu-bu-si-kao-dong-tai-gui-hua-hzz6/)

#### 前置知识：动态规划入门

详见 [动态规划入门：从记忆化搜索到递推【基础算法精讲 17】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Xj411K7oF%2F)

> APP 用户如果无法打开，可以分享到微信。

#### 一、启发思考：寻找子问题

最暴力的做法是枚举子数组的左右端点，以及要删除的元素。这种做法显然会超时。

保留「枚举子数组的右端点」这一想法，看看有没有可以优化的地方。

对于示例 1 中的数组 \[1,−2,0,3\]\[1,-2,0,3\]\[1,−2,0,3\]，假设元素和最大的连续子数组的右端点是 333。设原问题为：「子数组的右端点是 333，且**至多**删除一个数，子数组元素和的最大值是多少？」

这个原问题可以拆分成两个问题：

1. 子数组的右端点是 333，且**不能**删除数字，子数组元素和的最大值是多少？
    - 如果不选 333 左边的数，那么子数组就是 \[3\]\[3\]\[3\]。
    - 如果选 333 左边的数，那么需要解决的问题为：「子数组的右端点是 000，且不能删除数字，子数组元素和的最大值是多少？」
2. 子数组的右端点是 333，且**必须**删除一个数字，子数组元素和的最大值是多少？
    - 如果不选 333 左边的数，那么必须删除 333，但这违背了题目要求：「（删除后）子数组中至少应当有一个元素」。所以不考虑这种情况。
    - 如果选 333 左边的数：
        - 如果不删除 333，那么需要解决的问题为：「子数组的右端点是 000，且必须删除一个数字，子数组元素和的最大值是多少？」
        - 如果删除 333，那么需要解决的问题为：「子数组的右端点是 000，且不能删除数字，子数组元素和的最大值是多少？」

上面说的三个需要解决的问题，都是**和原问题相似的、规模更小的子问题**，所以可以用递归解决。

> 注 1：从右往左思考，主要是为了方便把递归翻译成递推。从左往右思考也是可以的。
> 注 2：动态规划有「选或不选」和「枚举选哪个」这两种基本思考方式。在做题时，可根据题目要求，选择适合题目的一种来思考。上面用到的是「选或不选」。

#### 二、递归怎么写：状态定义与状态转移方程

根据上面的讨论，递归参数需要一个 iii，表示子数组的右端点是 arr\[i\]\\textit{arr}\[i\]arr\[i\]。此外，需要知道是否可以删除数字，所以递归参数还需要一个 jjj。其中 j=0j=0j\=0 表示不能删除数字，j=1j=1j\=1 表示必须删除一个数。

因此，定义 dfs(i,j)\\textit{dfs}(i,j)dfs(i,j) 表示子数组的右端点是 arr\[i\]\\textit{arr}\[i\]arr\[i\]，不能/必须删除数字的情况下，子数组元素和的最大值。

根据上面讨论出的子问题，可以得到：

- 如果 j=0j=0j\=0（不能删除）：
  - 如果不选 arr\[i\]\\textit{arr}\[i\]arr\[i\] 左边的数，那么 dfs(i,0)=arr\[i\]\\textit{dfs}(i,0)=\\textit{arr}\[i\]dfs(i,0)\=arr\[i\]。
  - 如果选 arr\[i\]\\textit{arr}\[i\]arr\[i\] 左边的数，那么 dfs(i,0)=dfs(i−1,0)+arr\[i\]\\textit{dfs}(i,0)=\\textit{dfs}(i-1,0) + \\textit{arr}\[i\]dfs(i,0)\=dfs(i−1,0)+arr\[i\]。
- 如果 j=1j=1j\=1（必须删除）：
  - 如果不删除 arr\[i\]\\textit{arr}\[i\]arr\[i\]，那么 dfs(i,1)=dfs(i−1,1)+arr\[i\]\\textit{dfs}(i,1)=\\textit{dfs}(i-1,1)+\\textit{arr}\[i\]dfs(i,1)\=dfs(i−1,1)+arr\[i\]。
  - 如果删除 arr\[i\]\\textit{arr}\[i\]arr\[i\]，那么 dfs(i,1)=dfs(i−1,0)\\textit{dfs}(i,1)=\\textit{dfs}(i-1,0)dfs(i,1)\=dfs(i−1,0)。

取最大值，就得到了 dfs(i,j)\\textit{dfs}(i,j)dfs(i,j)。写成式子就是

dfs(i,0)=max⁡(dfs(i−1,0),0)+arr\[i\]dfs(i,1)=max⁡(dfs(i−1,1)+arr\[i\],dfs(i−1,0)) \\begin{aligned} &\\textit{dfs}(i,0) = \\max(\\textit{dfs}(i-1,0), 0) + \\textit{arr}\[i\] \\\\ &\\textit{dfs}(i,1) = \\max(\\textit{dfs}(i-1,1) + \\textit{arr}\[i\], \\textit{dfs}(i-1,0)) \\end{aligned} dfs(i,0)\=max(dfs(i−1,0),0)+arr\[i\]dfs(i,1)\=max(dfs(i−1,1)+arr\[i\],dfs(i−1,0))

递归边界：dfs(−1,j)=−∞\\textit{dfs}(-1,j)=-\\inftydfs(−1,j)\=−∞。这里 −1-1−1 表示子数组中「没有数字」，但题目要求子数组不能为空，所以这种情况不合法，用 −∞-\\infty−∞ 表示，这样取 max⁡\\maxmax 的时候就自然会取到合法的情况。

递归入口：dfs(i,j)\\textit{dfs}(i,j)dfs(i,j)。枚举子数组右端点 iii，以及是否需要删除数字 j=0,1j=0,1j\=0,1，取所有结果的最大值，作为答案。

#### 三、递归 + 记录返回值 = 记忆化搜索

以 \[1,−2,0,3\]\[1,-2,0,3\]\[1,−2,0,3\] 为例。在计算 dfs(3,1)\\textit{dfs}(3,1)dfs(3,1) 时，「删除 333，保留 000」和「保留 333，删除 000」，都会递归到 dfs(1,0)\\textit{dfs}(1,0)dfs(1,0)。

一叶知秋，整个递归中有大量重复递归调用（递归入参相同）。由于递归函数没有副作用，同样的入参无论计算多少次，算出来的结果都是一样的，因此可以用**记忆化搜索**来优化：

- 如果一个状态（递归入参）是第一次遇到，那么可以在返回前，把状态及其结果记到一个 memo\\textit{memo}memo 数组（或哈希表）中。
- 如果一个状态不是第一次遇到，那么直接返回 memo\\textit{memo}memo 中保存的结果。

```py
class Solution:
    def maximumSum(self, arr: List[int]) -> int:
        @cache  # 记忆化搜索
        def dfs(i: int, j: int) -> int:
            if i < 0: return -inf  # 子数组至少要有一个数，不合法
            if j == 0: return max(dfs(i - 1, 0), 0) + arr[i]
            return max(dfs(i - 1, 1) + arr[i], dfs(i - 1, 0))
        return max(max(dfs(i, 0), dfs(i, 1)) for i in range(len(arr)))
```

```java
class Solution {
    private int[] arr;
    private int[][] memo;

    public int maximumSum(int[] arr) {
        this.arr = arr;
        int ans = Integer.MIN_VALUE, n = arr.length;
        memo = new int[n][2];
        for (int i = 0; i < n; i++)
            Arrays.fill(memo[i], Integer.MIN_VALUE);
        for (int i = 0; i < n; i++)
            ans = Math.max(ans, Math.max(dfs(i, 0), dfs(i, 1)));
        return ans;
    }

    private int dfs(int i, int j) {
        if (i < 0) return Integer.MIN_VALUE / 2; // 除 2 防止负数相加溢出
        if (memo[i][j] != Integer.MIN_VALUE) return memo[i][j]; // 之前计算过
        if (j == 0) return memo[i][j] = Math.max(dfs(i - 1, 0), 0) + arr[i];
        return memo[i][j] = Math.max(dfs(i - 1, 1) + arr[i], dfs(i - 1, 0));
    }
}
```

```cpp
class Solution {
public:
    int maximumSum(vector<int> &arr) {
        int ans = INT_MIN, n = arr.size();
        vector<vector<int>> memo(n + 1, vector<int>(2, INT_MIN));
        function<int(int, int)> dfs = [&](int i, int j) -> int {
            if (i < 0) return INT_MIN / 2; // 除 2 防止负数相加溢出
            int &res = memo[i][j]; // 注意这里是引用
            if (res != INT_MIN) return res; // 之前计算过
            if (j == 0) return res = max(dfs(i - 1, 0), 0) + arr[i];
            return res = max(dfs(i - 1, 1) + arr[i], dfs(i - 1, 0));
        };
        for (int i = 0; i < n; i++)
            ans = max(ans, max(dfs(i, 0), dfs(i, 1)));
        return ans;
    }
};
```

```go
func maximumSum(arr []int) int {
    memo := make([][2]int, len(arr))
    for i := range memo {
        memo[i] = [2]int{math.MinInt, math.MinInt}
    }
    var dfs func(int, int) int
    dfs = func(i, j int) (res int) {
        if i < 0 {
            return math.MinInt / 2 // 除 2 防止负数相加溢出
        }
        p := &memo[i][j]
        if *p != math.MinInt { // 之前计算过
            return *p
        }
        defer func() { *p = res }() // 记忆化
        if j == 0 {
            return max(dfs(i-1, 0), 0) + arr[i]
        }
        return max(dfs(i-1, 1)+arr[i], dfs(i-1, 0))
    }
    ans := math.MinInt
    for i := range arr {
        ans = max(ans, max(dfs(i, 0), dfs(i, 1)))
    }
    return ans
}

func max(a, b int) int { if b > a { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：O(n)\\mathcal{O}(n)O(n)，其中 nnn 为 arr\\textit{arr}arr 的长度。动态规划的时间复杂度 \==\= 状态个数 ×\\times× 单个状态的计算时间。本题中状态个数等于 O(n)\\mathcal{O}(n)O(n)，单个状态的计算时间为 O(1)\\mathcal{O}(1)O(1)，所以动态规划的时间复杂度为 O(n)\\mathcal{O}(n)O(n)。
-   空间复杂度：O(n)\\mathcal{O}(n)O(n)。

#### 四、1:1 翻译成递推

我们可以去掉递归中的「递」，只保留「归」的部分，即自底向上计算。

做法：

-   dfs\\textit{dfs}dfs 改成 fff 数组。
-   递归改成循环（每个参数都对应一层循环）。这里 jjj 只有 000 和 111，可以直接计算，无需循环 jjj。
-   递归边界改成 fff 数组的初始值。

> 相当于之前是用递归去计算每个状态，现在是（按照某种顺序）枚举并计算每个状态。

具体来说，f\[i\]\[j\]f\[i\]\[j\]f\[i\]\[j\] 的含义和 dfs(i,j)\\textit{dfs}(i,j)dfs(i,j) 的含义是一致的，都表示子数组的右端点是 arr\[i\]\\textit{arr}\[i\]arr\[i\]，不能/必须删除数字的情况下，子数组元素和的最大值。

相应的递推式（状态转移方程）也和 dfs\\textit{dfs}dfs 的一致：

f\[i\]\[0\]=max⁡(f\[i−1\]\[0\],0)+arr\[i\]f\[i\]\[1\]=max⁡(f\[i−1\]\[1\]+arr\[i\],f\[i−1\]\[0\]) \\begin{aligned} &f\[i\]\[0\] = \\max(f\[i-1\]\[0\], 0) + \\textit{arr}\[i\] \\\\ &f\[i\]\[1\] = \\max(f\[i-1\]\[1\] + \\textit{arr}\[i\], f\[i-1\]\[0\]) \\end{aligned} f\[i\]\[0\]\=max(f\[i−1\]\[0\],0)+arr\[i\]f\[i\]\[1\]\=max(f\[i−1\]\[1\]+arr\[i\],f\[i−1\]\[0\])

但是，这种定义方式**没有状态能表示递归边界**，即 i=−1i=-1i\=−1 的情况。

解决办法：把 fff 数组的长度加一，用 f\[0\]\[j\]f\[0\]\[j\]f\[0\]\[j\] 表示 dfs(−1,j)\\textit{dfs}(-1,j)dfs(−1,j)。由于 f\[0\]f\[0\]f\[0\] 被占用，原来的下标 iii 需要全部向右偏移一位，也就是 f\[i\]f\[i\]f\[i\] 改为 f\[i+1\]f\[i+1\]f\[i+1\]，f\[i−1\]f\[i-1\]f\[i−1\] 改为 f\[i\]f\[i\]f\[i\]。

修改后 f\[i+1\]f\[i+1\]f\[i+1\] 表示子数组的右端点是 arr\[i\]\\textit{arr}\[i\]arr\[i\]，不能/必须删除数字的情况下，子数组元素和的最大值。

修改后的递推式为

f\[i+1\]\[0\]=max⁡(f\[i\]\[0\],0)+arr\[i\]f\[i+1\]\[1\]=max⁡(f\[i\]\[1\]+arr\[i\],f\[i\]\[0\]) \\begin{aligned} &f\[i+1\]\[0\] = \\max(f\[i\]\[0\], 0) + \\textit{arr}\[i\] \\\\ &f\[i+1\]\[1\] = \\max(f\[i\]\[1\] + \\textit{arr}\[i\], f\[i\]\[0\]) \\end{aligned} f\[i+1\]\[0\]\=max(f\[i\]\[0\],0)+arr\[i\]f\[i+1\]\[1\]\=max(f\[i\]\[1\]+arr\[i\],f\[i\]\[0\])

> 问：为什么 arr\\textit{arr}arr 的下标不用变？
> 
> 答：既然是把 fff 数组的长度加一，那么就只需要修改和 fff 有关的下标，其余任何逻辑都无需修改。

初始值 f\[0\]\[j\]=−∞f\[0\]\[j\]=-\\inftyf\[0\]\[j\]\=−∞，翻译自 dfs(−1,j)=−∞\\textit{dfs}(-1,j)=-\\inftydfs(−1,j)\=−∞。

答案为所有 f\[i\]\[j\]f\[i\]\[j\]f\[i\]\[j\] 的最大值。

Python3

Java

C++

Go

```py
class Solution:
    def maximumSum(self, arr: List[int]) -> int:
        f = [[-inf] * 2] + [[0, 0] for _ in arr]
        for i, x in enumerate(arr):
            f[i + 1][0] = max(f[i][0], 0) + x
            f[i + 1][1] = max(f[i][1] + x, f[i][0])
        return max(max(r) for r in f)
```

```java
class Solution {
    public int maximumSum(int[] arr) {
        int ans = Integer.MIN_VALUE, n = arr.length;
        var f = new int[n + 1][2];
        Arrays.fill(f[0], Integer.MIN_VALUE / 2); // 除 2 防止负数相加溢出
        for (int i = 0; i < n; i++) {
            f[i + 1][0] = Math.max(f[i][0], 0) + arr[i];
            f[i + 1][1] = Math.max(f[i][1] + arr[i], f[i][0]);
            ans = Math.max(ans, Math.max(f[i + 1][0], f[i + 1][1]));
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int maximumSum(vector<int> &arr) {
        int ans = INT_MIN, n = arr.size();
        vector<vector<int>> f(n + 1, vector<int>(2, INT_MIN / 2)); // 除 2 防止负数相加溢出
        for (int i = 0; i < n; i++) {
            f[i + 1][0] = max(f[i][0], 0) + arr[i];
            f[i + 1][1] = max(f[i][1] + arr[i], f[i][0]);
            ans = max(ans, max(f[i + 1][0], f[i + 1][1]));
        }
        return ans;
    }
};
```

```go
func maximumSum(arr []int) int {
    ans := math.MinInt
    f := make([][2]int, len(arr)+1)
    f[0] = [2]int{math.MinInt / 2, math.MinInt / 2} // 除 2 防止负数相加溢出
    for i, x := range arr {
        f[i+1][0] = max(f[i][0], 0) + x
        f[i+1][1] = max(f[i][1]+x, f[i][0])
        ans = max(ans, max(f[i+1][0], f[i+1][1]))
    }
    return ans
}

func max(a, b int) int { if b > a { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：O(n)\\mathcal{O}(n)O(n)，其中 nnn 为 arr\\textit{arr}arr 的长度。动态规划的时间复杂度 \==\= 状态个数 ×\\times× 单个状态的计算时间。本题中状态个数等于 O(n)\\mathcal{O}(n)O(n)，单个状态的计算时间为 O(1)\\mathcal{O}(1)O(1)，所以动态规划的时间复杂度为 O(n)\\mathcal{O}(n)O(n)。
-   空间复杂度：O(n)\\mathcal{O}(n)O(n)。

#### 五、空间优化

观察上面的状态转移方程，在计算 f\[i+1\]f\[i+1\]f\[i+1\] 时，只会用到 f\[i\]f\[i\]f\[i\]，不会用到下标 <i< i<i 的状态。

因此只需要两个状态表示 j=0,1j=0,1j\=0,1。

状态转移方程改为

f\[1\]=max⁡(f\[1\]+arr\[i\],f\[0\])f\[0\]=max⁡(f\[0\],0)+arr\[i\] \\begin{aligned} &f\[1\] = \\max(f\[1\] + \\textit{arr}\[i\], f\[0\])\\\\ &f\[0\] = \\max(f\[0\], 0) + \\textit{arr}\[i\] \\end{aligned} f\[1\]\=max(f\[1\]+arr\[i\],f\[0\])f\[0\]\=max(f\[0\],0)+arr\[i\]

**请注意计算顺序**！必须先算 f\[1\]f\[1\]f\[1\] 再算 f\[0\]f\[0\]f\[0\]。如果先算 f\[0\]f\[0\]f\[0\] 再算 f\[1\]f\[1\]f\[1\]，那么在计算 f\[1\]f\[1\]f\[1\] 时，相当于用到的不是原来的 f\[i\]\[0\]f\[i\]\[0\]f\[i\]\[0\]，而是新算出来的 f\[i+1\]\[0\]f\[i+1\]\[0\]f\[i+1\]\[0\]。

初始值 f\[j\]=−∞f\[j\]=-\\inftyf\[j\]\=−∞。

一边计算，一边维护 f\[j\]f\[j\]f\[j\] 的最大值，作为答案。

Python3

Java

C++

Go

```py
class Solution:
    def maximumSum(self, arr: List[int]) -> int:
        ans = f0 = f1 = -inf
        for x in arr:
            f1 = max(f1 + x, f0)  # 注：改用 if 比大小会更快 
            f0 = max(f0, 0) + x
            ans = max(ans, f0, f1)
        return ans
```

```java
class Solution {
    public int maximumSum(int[] arr) {
        int ans = Integer.MIN_VALUE / 2, f0 = ans, f1 = ans;
        for (int x : arr) {
            f1 = Math.max(f1 + x, f0);
            f0 = Math.max(f0, 0) + x;
            ans = Math.max(ans, Math.max(f0, f1));
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int maximumSum(vector<int> &arr) {
        int ans = INT_MIN / 2, f0 = ans, f1 = ans;
        for (int x: arr) {
            f1 = max(f1 + x, f0);
            f0 = max(f0, 0) + x;
            ans = max(ans, max(f0, f1));
        }
        return ans;
    }
};
```

```go
func maximumSum(arr []int) int {
    ans := math.MinInt / 2
    f0, f1 := ans, ans
    for _, x := range arr {
        f1 = max(f1+x, f0)
        f0 = max(f0, 0) + x
        ans = max(ans, max(f0, f1))
    }
    return ans
}

func max(a, b int) int { if b > a { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：O(n)\\mathcal{O}(n)O(n)，其中 nnn 为 arr\\textit{arr}arr 的长度。动态规划的时间复杂度 \==\= 状态个数 ×\\times× 单个状态的计算时间。本题中状态个数等于 O(n)\\mathcal{O}(n)O(n)，单个状态的计算时间为 O(1)\\mathcal{O}(1)O(1)，所以动态规划的时间复杂度为 O(n)\\mathcal{O}(n)O(n)。
-   空间复杂度：O(1)\\mathcal{O}(1)O(1)。只用到常数级的额外空间。

#### 练习

-   [53\. 最大子数组和](https://leetcode.cn/problems/maximum-subarray/)
-   [2606\. 找到最大开销的子字符串](https://leetcode.cn/problems/find-the-substring-with-maximum-cost/)
-   [918\. 环形子数组的最大和](https://leetcode.cn/problems/maximum-sum-circular-subarray/)
-   [2321\. 拼接数组的最大分数](https://leetcode.cn/problems/maximum-score-of-spliced-array/)
