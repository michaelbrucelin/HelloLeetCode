### [本质是爬楼梯：从记忆化搜索到递推，附题单（Python/Java/C++/C/Go/JS/Rust）](https://leetcode.cn/problems/combination-sum-iv/solutions/2706336/ben-zhi-shi-pa-lou-ti-cong-ji-yi-hua-sou-y52j/)

本题其实就是 [70. 爬楼梯](https://leetcode.cn/problems/climbing-stairs/)，我们每次从 $\textit{nums}$ 中选一个数，作为往上爬的台阶数，问爬 $\textit{target}$ 个台阶有多少种方案。70 那题可以看作 $\textit{nums}=[1,2]$，因为每次只能爬 $1$ 个或 $2$ 个台阶。

下面用到的技巧请看视频 [动态规划入门：从记忆化搜索到递推](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Xj411K7oF%2F)，其中包含如何把记忆化搜索 1:1 翻译成递推的技巧。

#### 一、递归搜索 + 保存递归返回值 = 记忆化搜索

和爬楼梯一样，定义 $\textit{dfs}(i)$ 表示爬 $i$ 个台阶的方案数。

考虑最后一步爬了 $x=\textit{nums}[j]$ 个台阶，那么问题变成爬 $i-x$ 个台阶的方案数，即 dfs(i?x)\textit{dfs}(i-x)dfs(i?x)。

所以有

$$\textit{dfs}(i) = \sum_{j=0}^{n-1} \textit{dfs}(i-\textit{nums}[j])$$

注：如果 $\textit{nums}[j] > i$ 则跳过。

回顾一下，70 那题可以看作 $\textit{nums}=[1,2]$，有

$$\textit{dfs}(i) = \textit{dfs}(i-1) + \textit{dfs}(i-2)$$

递归边界：$\textit{dfs}(0)=1$。爬 $0$ 个台阶的方案数是 $1$。也可以这样理解，我们从 $\textit{target}$ 开始往下爬，刚好爬到底部（递归边界）此时就找到了一个合法的方案，返回 $1$。

递归入口：$\textit{dfs}(\textit{target})$，也就是答案。

按照视频中讲的，用**记忆化搜索**来优化：

- 如果一个状态（递归入参）是第一次遇到，那么可以在返回前，把状态及其结果记到一个 $\textit{memo}$ 数组中。
- 如果一个状态不是第一次遇到（$\textit{memo}$ 中保存的结果不等于 $\textit{memo}$ 的初始值），那么可以直接返回 $\textit{memo}$ 中保存的结果。

**注意：** $\textit{memo}$ 数组的**初始值**一定不能等于要记忆化的值！例如初始值设置为 $0$，并且要记忆化的 $\textit{dfs}(i)$ 也等于 $0$，那就没法判断 $0$ 到底表示第一次遇到这个状态，还是表示之前遇到过了，从而导致记忆化失效。一般把初始值设置为 $-1$。

> Python 用户可以无视上面这段，直接用 `@cache` 装饰器。

##### 代码

```python
class Solution:
    def combinationSum4(self, nums: List[int], target: int) -> int:
        @cache  # 缓存装饰器，避免重复计算 dfs 的结果
        def dfs(i: int) -> int:
            if i == 0:  # 爬完了
                return 1
            return sum(dfs(i - x) for x in nums if x <= i)  # 枚举所有可以爬的台阶数
        return dfs(target)
```

```java
class Solution {
    public int combinationSum4(int[] nums, int target) {
        int[] memo = new int[target + 1];
        Arrays.fill(memo, -1); // -1 表示没有计算过
        return dfs(target, nums, memo);
    }

    private int dfs(int i, int[] nums, int[] memo) {
        if (i == 0) { // 爬完了
            return 1;
        }
        if (memo[i] != -1) { // 之前计算过
            return memo[i];
        }
        int res = 0;
        for (int x : nums) { // 枚举所有可以爬的台阶数
            if (x <= i) {
                res += dfs(i - x, nums, memo);
            }
        }
        return memo[i] = res; // 记忆化
    }
}
```

```c++
class Solution {
    int dfs(int i, vector<int> &nums, vector<int> &memo) {
        if (i == 0) { // 爬完了
            return 1;
        }
        int &res = memo[i]; // 注意这里是引用
        if (res != -1) { // 之前计算过
            return res;
        }
        res = 0;
        for (int x : nums) {
            if (x <= i) {
                res += dfs(i - x, nums, memo);
            }
        }
        return res;
    }

public:
    int combinationSum4(vector<int> &nums, int target) {
        vector<int> memo(target + 1, -1); // -1 表示没有计算过
        return dfs(target, nums, memo);
    }
};
```

```c
int dfs(int i, int* nums, int numsSize, int* memo) {
    if (i == 0) { // 爬完了
        return 1;
    }
    if (memo[i] != -1) { // 之前计算过
        return memo[i];
    }
    int res = 0;
    for (int j = 0; j < numsSize; j++) { // 枚举所有可以爬的台阶数
        int x = nums[j];
        if (x <= i) {
            res += dfs(i - x, nums, numsSize, memo);
        }
    }
    return memo[i] = res; // 记忆化
}

int combinationSum4(int* nums, int numsSize, int target) {
    int* memo = malloc((target + 1) * sizeof(int));
    memset(memo, -1, (target + 1) * sizeof(int)); // -1 表示没有计算过
    int ans = dfs(target, nums, numsSize, memo);
    free(memo);
    return ans;
}
```

```go
func combinationSum4(nums []int, target int) int {
    memo := make([]int, target+1)
    for i := range memo {
        memo[i] = -1 // -1 表示没有计算过
    }
    var dfs func(int) int
    dfs = func(i int) (res int) {
        if i == 0 { // 爬完了
            return 1
        }
        p := &memo[i]
        if *p != -1 { // 之前计算过
            return *p
        }
        for _, x := range nums { // 枚举所有可以爬的台阶数
            if x <= i {
                res += dfs(i - x)
            }
        }
        *p = res // 记忆化
        return
    }
    return dfs(target)
}
```

```javascript
var combinationSum4 = function(nums, target) {
    const memo = Array(target + 1).fill(-1); // -1 表示没有计算过
    function dfs(i) {
        if (i $=$ 0) { // 爬完了
            return 1;
        }
        if (memo[i] !== -1) { // 之前计算过
            return memo[i];
        }
        let res = 0;
        for (const x of nums) { // 枚举所有可以爬的台阶数
            if (x <= i) {
                res += dfs(i - x);
            }
        }
        return memo[i] = res; // 记忆化
    }
    return dfs(target);
};
```

```rust
impl Solution {
    pub fn combination_sum4(nums: Vec<i32>, target: i32) -> i32 {
        fn dfs(i: usize, nums: &Vec<i32>, memo: &mut Vec<i32>) -> i32 {
            if i == 0 { // 爬完了
                return 1;
            }
            if memo[i] != -1 { // 之前计算过
                return memo[i];
            }
            let mut res = 0;
            for &x in nums { // 枚举所有可以爬的台阶数
                let x = x as usize;
                if x <= i {
                    res += dfs(i - x, nums, memo);
                }
            }
            memo[i] = res; // 记忆化
            res
        }
        let t = target as usize;
        let mut memo = vec![-1; t + 1]; // -1 表示没有计算过
        dfs(t, &nums, &mut memo)
    }
}
```

##### 复杂度分析

- 时间复杂度：$\mathcal{O}(\textit{target}\cdot n)$，其中 $n$ 为 $\textit{nums}$ 的长度。由于每个状态只会计算一次，动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。本题状态个数等于 $\mathcal{O}(\textit{target})$，单个状态的计算时间为 $\mathcal{O}(n)$，所以动态规划的时间复杂度为 $\mathcal{O}(\textit{target}\cdot n)$。
- 空间复杂度：$\mathcal{O}(\textit{target})$。有多少个状态，$\textit{memo}$ 数组的大小就是多少。

#### 二、1:1 翻译成递推

我们可以去掉递归中的「递」，只保留「归」的部分，即自底向上计算。

具体来说，$f[i]$ 的定义和 $\textit{dfs}(i)$ 的定义是一样的，都表示表示爬 $i$ 个台阶的方案数。

相应的递推式（状态转移方程）也和 $\textit{dfs}$ 一样：

$$f[i] = \sum_{j=0}^{n-1} f[i-\textit{nums}[j]]$$

注：如果 $\textit{nums}[j] > i$ 则跳过。

回顾一下，70 那题可以看作 $\textit{nums}=[1,2]$，状态转移方程为

$$f[i] = f[i-1] + f[i-2]$$

初始值 $f[0]=1$，翻译自递归边界 $\textit{dfs}(0)=1$。

答案为 $f[\textit{target}]$，翻译自递归入口 $\textit{dfs}(\textit{target})$。

##### 代码

```python
class Solution:
    def combinationSum4(self, nums: List[int], target: int) -> int:
        f = [1] + [0] * target
        for i in range(1, target + 1):
            f[i] = sum(f[i - x] for x in nums if x <= i)
        return f[target]
```

```java
class Solution {
    public int combinationSum4(int[] nums, int target) {
        int[] f = new int[target + 1];
        f[0] = 1;
        for (int i = 1; i <= target; i++) {
            for (int x : nums) {
                if (x <= i) {
                    f[i] += f[i - x];
                }
            }
        }
        return f[target];
    }
}
```

```c++
class Solution {
public:
    int combinationSum4(vector<int> &nums, int target) {
        // 使用 unsigned 可以让溢出不报错
        // 对于溢出的数据，不会影响答案的正确性（题目保证）
        vector<unsigned> f(target + 1);
        f[0] = 1;
        for (int i = 1; i <= target; i++) {
            for (int x : nums) {
                if (x <= i) {
                    f[i] += f[i - x];
                }
            }
        }
        return f[target];
    }
};
```

```c
int combinationSum4(int* nums, int numsSize, int target) {
    // 使用 unsigned 可以让溢出不报错
    // 对于溢出的数据，不会影响答案的正确性（题目保证）
    unsigned* f = calloc(target + 1, sizeof(unsigned));
    f[0] = 1;
    for (int i = 1; i <= target; i++) {
        for (int j = 0; j < numsSize; j++) {
            int x = nums[j];
            if (x <= i) {
                f[i] += f[i - x];
            }
        }
    }
    int ans = f[target];
    free(f);
    return ans;
}
```

```go
func combinationSum4(nums []int, target int) int {
    f := make([]int, target+1)
    f[0] = 1
    for i := 1; i <= target; i++ {
        for _, x := range nums {
            if x <= i {
                f[i] += f[i-x]
            }
        }
    }
    return f[target]
}
```

```javascript
var combinationSum4 = function(nums, target) {
    const f = Array(target + 1).fill(0);
    f[0] = 1;
    for (let i = 1; i <= target; i++) {
        for (const x of nums) {
            if (x <= i) {
                f[i] += f[i - x];
            }
        }
    }
    return f[target];
};
```

```rust
impl Solution {
    pub fn combination_sum4(nums: Vec<i32>, target: i32) -> i32 {
        let t = target as usize;
        let mut f = vec![0; t + 1];
        f[0] = 1;
        for i in 1..=t {
            for &x in &nums {
                let x = x as usize;
                if x <= i {
                    f[i] += f[i - x];
                }
            }
        }
        f[t]
    }
}
```

##### 复杂度分析

- 时间复杂度：$\mathcal{O}(\textit{target}\cdot n)$，其中 $n$ 为 $\textit{nums}$ 的长度。
- 空间复杂度：$\mathcal{O}(\textit{target})$。

#### 进阶

**问：** 如果给定的数组中含有负数会发生什么？问题会产生何种变化？如果允许负数出现，需要向题目中添加哪些限制条件？
**答：** 负数可能会导致有无穷个方案。例如 $\textit{nums}=[1,-1]$，要组成 $1$，只要选的个 $1$ 的个数比 $-1$ 多一个，就可以满足要求，这有无穷种选法。为了不让答案为无穷大，可以限制负数的选择个数上限。

#### 更多 DP 题目

请看 [动态规划（入门/背包/状态机/划分/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)

#### 其它题单

- [滑动窗口（定长/不定长/多指针）](https://leetcode.cn/circle/discuss/0viNMK/)
- [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
- [单调栈（矩形系列/字典序最小/贡献法）](https://leetcode.cn/circle/discuss/9oZFK9/)
- [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
- [位运算（基础/性质/拆位/试填/恒等式/贪心/脑筋急转弯）](https://leetcode.cn/circle/discuss/dHn9Vk/)
- [图论算法（DFS/BFS/拓扑排序/最短路/最小生成树/二分图/基环树/欧拉路径）](https://leetcode.cn/circle/discuss/01LUak/)
