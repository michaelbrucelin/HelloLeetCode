### [收集巧克力](https://leetcode.cn/problems/collecting-chocolates/solutions/2580148/shou-ji-qiao-ke-li-by-leetcode-solution-bjyp/)

#### 前言

本题的题目描述中有歧义，本文根据如下的题意撰写：

- 我们有类型为 $0, 1, \cdots, n-1$ 的巧克力各一个；
- 进行 $k$ 次操作后，初始类型为 $i$ 的巧克力需要 $nums[(i + k) \bmod n]$ 的成本来收集；
- 我们希望得到收集所有 $n$ 个巧克力的最小成本。

#### 方法一：枚举收集的次数

##### 思路与算法

对于初始类型为 $i$ 的巧克力，如果我们一共进行了 $k$ 次操作，相当于我们可以用：

$$nums[i], nums[(i+1) \bmod n], \cdots, nums[(i+k) \bmod n] \tag{1}$$

中的任意成本去购买它。由于我们希望成本最小，那么我们一定选择上述 $k+1$ 个成本中的最小值。同时我们发现，当进行了第 $n$ 次操作后，它的价格又会回到 $nums[i]$ 并继续开始循环，因此操作的次数不会超过 $n-1$。

这样一来，我们就可以枚举操作次数了，它的范围为 $[0, n-1]$。当操作次数为 $k$ 时，初始类型为 $i$ 的巧克力需要的成本就是 $(1)$ 中的最小值，我们就可以使用一个二维数组 $f(i, k)$ 记录该值，它有如下的递推式：

$$\begin{cases} f(i, 0) = nums[i] \\ f(i, k) = \min \big\{ f(i, k-1), nums[(i+k) \bmod n] \big\} \end{cases}$$

即 $f(i, k)$ 相较于 $f(i, k-1)$，多了一个 $nums[(i+k) \bmod n]$ 的选择。此时，操作次数为 $k$ 时的最小成本即为：

$$k \cdot x + \sum_{i=0}^{n-1} f(i, k) \tag{2}$$

最终的答案即为所有 $k \in [0, n-1]$ 中式 $(2)$ 的最小值。

##### 细节

注意到 $f(i, k)$ 只与 $f(i, k-1)$ 有关，那么我们可以省去 $k$ 的这一维度，减少空间复杂度。

##### 代码

```c++
class Solution {
public:
    long long minCost(vector<int>& nums, int x) {
        int n = nums.size();
        vector<int> f(nums);
        long long ans = accumulate(f.begin(), f.end(), 0LL);
        for (int k = 1; k < n; ++k) {
            for (int i = 0; i < n; ++i) {
                f[i] = min(f[i], nums[(i + k) % n]);
            }
            ans = min(ans, static_cast<long long>(k) * x + accumulate(f.begin(), f.end(), 0LL));
        }
        return ans;
    }
};
```

```java
class Solution {
    public long minCost(int[] nums, int x) {
        int n = nums.length;
        int[] f = new int[n];
        System.arraycopy(nums, 0, f, 0, n);
        long ans = getSum(f);
        for (int k = 1; k < n; ++k) {
            for (int i = 0; i < n; ++i) {
                f[i] = Math.min(f[i], nums[(i + k) % n]);
            }
            ans = Math.min(ans, (long) k * x + getSum(f));
        }
        return ans;
    }

    public long getSum(int[] f) {
        long sum = 0;
        for (int num : f) {
            sum += num;
        }
        return sum;
    }
}
```

```csharp
public class Solution {
    public long MinCost(int[] nums, int x) {
        int n = nums.Length;
        int[] f = new int[n];
        Array.Copy(nums, 0, f, 0, n);
        long ans = GetSum(f);
        for (int k = 1; k < n; ++k) {
            for (int i = 0; i < n; ++i) {
                f[i] = Math.Min(f[i], nums[(i + k) % n]);
            }
            ans = Math.Min(ans, (long) k * x + GetSum(f));
        }
        return ans;
    }

    public long GetSum(int[] f) {
        long sum = 0;
        foreach (int num in f) {
            sum += num;
        }
        return sum;
    }
}
```

```python
class Solution:
    def minCost(self, nums: List[int], x: int) -> int:
        n = len(nums)
        f = nums[:]
        ans = sum(f)

        for k in range(1, n):
            for i in range(n):
                f[i] = min(f[i], nums[(i + k) % n])
            ans = min(ans, k * x + sum(f))
        
        return ans
```

```go
func sum(arr []int) int64 {
    ans := int64(0)
    for _, a := range arr {
        ans += int64(a)
    }
    return ans
}

func minCost(nums []int, x int) int64 {
    n := len(nums)
    f := make([]int, n)
    copy(f, nums)
    ans := sum(f)
    for k := 1; k < n; k++ {
        for i := 0; i < n; i++ {
            f[i] = min(f[i], nums[(i + k) % n])
        }
        ans = min(ans, int64(k) * int64(x) + sum(f))
    }
    return ans
}
```

```c
long long sum(int *f, int n) {
    long long ans = 0;
    for (int i = 0; i < n; i++) {
        ans += f[i];
    }
    return ans;
}

long long minCost(int *nums, int numsSize, int x){
    int n = numsSize;
    int *f = (int *)malloc(sizeof(int) * n);
    memcpy(f, nums, sizeof(int) * n);
    long long ans = sum(f, n);
    for (int k = 1; k < n; k++) {
        for (int i = 0; i < n; i++) {
            f[i] = fmin(f[i], nums[(i + k) % n]);
        }
        ans = fmin(ans, (long long)k * x + sum(f, n));
    }
    free(f);
    return ans;
}
```

```javascript
var minCost = function(nums, x) {
    let n = nums.length;
    const f = [...nums];
    let ans = nums.reduce((accumulator, currentValue) => accumulator + currentValue, 0);

    for (let k = 1; k < n; k++) {
        for (let i = 0; i < n; i++) {
            f[i] = Math.min(f[i], nums[(i + k) % n])
        }
        sum = f.reduce((accumulator, currentValue) => accumulator + currentValue, 0);
        ans = Math.min(ans, k * x + sum);
    }    
    return ans;
};
```

#### 复杂度分析

- 时间复杂度：$O(n^2)$。
- 空间复杂度：$O(n)$。

#### 方法二：二次差分

##### 前言

本方法难度较大，读者需要熟练掌握单调栈和差分的技巧，下文不会讲解关于这两者的基础知识。

为了叙述方便，下文省略所有数组 $nums$ 下标的加减操作中对 $n$ 取模（$\bmod~n$）的表述。

##### 思路与算法

我们假设数组 $nums$ 中的元素均不相同，然后使用逆向思维考虑这个问题：对于每一个 $nums[i]$，它在什么时候会成为某个巧克力的最小成本？

记 $L[i]$ 表示 $nums[i]$ 左侧大于 $nums[i]$ 的元素个数，$R[i]$ 表示 $nums[i]$ 右侧大于 $nums[i]$ 的元素个数。当操作次数为 $k$ 时，根据方法一中的 $(1)$ 式，某个巧克力最小成本实际上就是一个在数组 $nums$ 上长度为 $k+1$ 的滑动窗口中的最小值。当这个滑动窗口恰好落在 $[i - L[i], i + R[i]]$ 的范围内，且包含下标 $i$ 时，其中的最小值即为 $nums[i]$。

> 这里的 $L[i]$ 具体指的是：$nums[i-1], nums[i-2], \cdots, nums[i-L[i]]$ 都大于 $nums[i]$，而 $nums[i-L[i]-1]$ 小于 $nums[i]$。$R[i]$ 同理。
> 
> 当 $nums[i-1] < nums[i]$ 时，$L[i] = 0$。
> 当 $nums[i]$ 为整个数组中的最小值时，视为特殊情况，下文会进行说明，无需考虑 $L[i]$ 的值。

对于区间 $[i - L[i], i + R[i]]$ 以及长度为 $k+1$ 的滑动窗口：

- 当 $k \leq \min\{ L[i], R[i] \}$ 时，下标 $i$ 可以作为滑动窗口中的任一位置，满足要求的窗口数量为 $k + 1$；
- 当 $\min\{ L[i], R[i] \} < k \leq \max\{ L[i], R[i] \}$ 时，$L[i]$ 和 $R[i]$ 中值更小的那一侧中的任一位置可以作为滑动窗口的起始位置，满足要求的窗口数量为 $\min\{ L[i], R[i] \} + 1$；
- 当 $\max\{ L[i], R[i] \} < k \leq L[i] + R[i]$ 时，落在 $[i - L[i], i + R[i]]$ 的范围内任一滑动窗口都包含下标 $i$，满足要求的窗口数量为 $L[i] + R[i] - k + 1$；
- 当 $k > L[i] + R[i]$ 时，滑动窗口比区间 $[i - L[i], i + R[i]]$ 更长，因此不存在满足要求的窗口。

因此当操作次数为 $k$ 时，我们先判断 $nums[i]$ 属于上述四种情况中的哪一种，得到满足要求的窗口数量，乘以 $nums[i]$ 并累加入答案。当我们枚举了所有的 $nums[i]$ 后，就可以得到在操作次数为 $k$ 时的最小成本。

然后这样做的时间复杂度仍然为 $O(n^2)$，我们需要进行优化。可以发现，四种情况中的窗口数量均是**常函数或者是关于 $k$ 的一次函数**。记 $F[k]$ 表示操作次数为 $k$ 时的最小成本：

- 如果是常函数，相当于我们需要某一段连续的 $F[l .. r]$ 增加一个常值 $C$，可以使用差分的方法，将 $F'[l]$ 增加 $C$ 并将 $F'[r+1]$ 减少 $C$，这样数组 $F'$ 的前缀和就是数组 $F$；
- 如果是一次函数，相当于我们需要某一段连续的 $F[l .. r]$ 增加一个初始值为常数 $P$，增量为常数 $C$ 的值，可以使用二次差分的方法，首先进行一次差分，将 $F'[l]$ 增加 $P$，$F'[l+1 .. r]$ 增加 $C$，$F'[r+1]$ 减少 $P+(r-l)C$，这样数组 $F'$ 的前缀和就是数组 $F$。随后再进行一次差分即可。

使用二次差分的方法就可以让我们在 $O(1)$ 的时间处理每一个 $nums[i]$，时间复杂度降低至 $O(n)$。

##### 细节

$L[i]$ 和 $R[i]$ 可以使用单调栈，找出两侧第一个更小的元素来求出。由于数组是循环的，需要进行一些特殊判断，编码较为复杂。但我们可以发现，将数组 $nums$ 进行左移/右移操作并不会影响最终的答案，因此可以找出数组 $nums$ 中最小的元素 $nums[i]$，并将数组变为 $nums[i], nums[i+1], \cdots, nums[i+n-1]$，这样新的数组中，除了首元素外，所有元素一定能在左侧找到一个更小的元素（即首元素）；并且如果某个元素右侧没有更小的元素，那么循环来看，首元素就是右侧第一个更小的元素。这样就可以很方便地求出 $L[i]$ 和 $R[i]$。

当 $nums[i]$ 是数组中最小的元素时，满足要求的长度为 $k + 1$ 的滑动窗口总是有 $k + 1$ 个，可以对应到上文的第一种情况 $k \leq \min\{ L[i], R[i] \}$，我们只需要令 $L[i] = R[i] = n - 1$ 就能让所有的 $k$ 都落在第一种情况中。

当数组 $nums$ 中有相同的元素时，使用下标作为第二关键字进行比较即可。

##### 代码

```c++
class Solution {
public:
    long long minCost(vector<int>& nums, int x) {
        int n = nums.size();
        // 找出 nums 中最小的元素，并用其为首元素构造一个新的数组
        int min_idx = min_element(nums.begin(), nums.end()) - nums.begin();
        vector<int> tmp;
        for (int i = 0; i < n; ++i) {
            tmp.push_back(nums[(min_idx + i) % n]);
        }
        nums = move(tmp);

        vector<int> L(n), R(n);
        L[0] = n - 1;
        // 循环来看，右侧 nums[0] 是更小的元素，但不一定是第一个更小的元素，需要用单调栈计算得到
        for (int i = 0; i < n; ++i) {
            R[i] = n - i - 1;
        }
        stack<int> s;
        s.push(0);
        for (int i = 1; i < n; ++i) {
            while (!s.empty() && nums[i] < nums[s.top()]) {
                R[s.top()] = i - s.top() - 1;
                s.pop();
            }
            L[i] = i - s.top() - 1;
            s.push(i);
        }

        vector<long long> F(n);
        // 辅助函数，一次差分，将 F[l..r] 都增加 d
        auto diff_once = [&](int l, int r, long long d) {
            if (l > r) {
                return;
            }
            if (l < n) {
                F[l] += d;
            }
            if (r + 1 < n) {
                F[r + 1] -= d;
            }
        };
        // 辅助函数，二次差分，将 F[l..r] 增加 ki + b，i 是下标
        auto diff_twice = [&](int l, int r, long long k, long long b) {
            if (l > r) {
                return;
            }
            diff_once(l, l, k * l + b);
            diff_once(l + 1, r, k);
            diff_once(r + 1, r + 1, -(k * r + b));
        };

        // 进行操作需要的成本
        diff_twice(0, n - 1, x, 0);

        for (int i = 0; i < n; ++i) {
            int minv = min(L[i], R[i]);
            int maxv = max(L[i], R[i]);
            // 第一种情况，窗口数量 k+1，总和 nums[i] * k + nums[i]
            diff_twice(0, minv, nums[i], nums[i]);
            // 第二种情况，窗口数量 minv+1，总和 0 * k + nums[i] * (minv + 1)
            diff_twice(minv + 1, maxv, 0, static_cast<long long>(nums[i]) * (minv + 1));
            // 第三种情况，窗口数量 L[i]+R[i]-k+1，总和 -nums[i] * k + nums[i] * (L[i] + R[i] + 1)
            diff_twice(maxv + 1, L[i] + R[i], -nums[i], static_cast<long long>(nums[i]) * (L[i] + R[i] + 1));
        }

        // 计算两次前缀和
        for (int i = 0; i < 2; ++i) {
            vector<long long> G(n);
            partial_sum(F.begin(), F.end(), G.begin());
            F = move(G);
        }

        return *min_element(F.begin(), F.end());
    }
};
```

```java
class Solution {
    public long minCost(int[] nums, int x) {
        int n = nums.length;
        // 找出 nums 中最小的元素，并用其为首元素构造一个新的数组
        int minIdx = 0;
        for (int i = 1; i < n; ++i) {
            if (nums[i] < nums[minIdx]) {
                minIdx = i;
            }
        }
        int[] tmp = new int[n];
        for (int i = 0; i < n; ++i) {
            tmp[i] = nums[(minIdx + i) % n];
        }
        System.arraycopy(tmp, 0, nums, 0, n);

        int[] L = new int[n];
        int[] R = new int[n];
        L[0] = n - 1;
        // 循环来看，右侧 nums[0] 是更小的元素，但不一定是第一个更小的元素，需要用单调栈计算得到
        for (int i = 0; i < n; ++i) {
            R[i] = n - i - 1;
        }
        Deque<Integer> stack = new ArrayDeque<Integer>();
        stack.push(0);
        for (int i = 1; i < n; ++i) {
            while (!stack.isEmpty() && nums[i] < nums[stack.peek()]) {
                R[stack.peek()] = i - stack.peek() - 1;
                stack.pop();
            }
            L[i] = i - stack.peek() - 1;
            stack.push(i);
        }

        long[] F = new long[n];

        // 进行操作需要的成本
        diffTwice(F, 0, n - 1, x, 0);

        for (int i = 0; i < n; ++i) {
            int minv = Math.min(L[i], R[i]);
            int maxv = Math.max(L[i], R[i]);
            // 第一种情况，窗口数量 k+1，总和 nums[i] * k + nums[i]
            diffTwice(F, 0, minv, nums[i], nums[i]);
            // 第二种情况，窗口数量 minv+1，总和 0 * k + nums[i] * (minv + 1)
            diffTwice(F, minv + 1, maxv, 0, (long) nums[i] * (minv + 1));
            // 第三种情况，窗口数量 L[i]+R[i]-k+1，总和 -nums[i] * k + nums[i] * (L[i] + R[i] + 1)
            diffTwice(F, maxv + 1, L[i] + R[i], -nums[i], (long) nums[i] * (L[i] + R[i] + 1));
        }

        // 计算两次前缀和
        for (int i = 0; i < 2; ++i) {
            long[] G = new long[n];
            G[0] = F[0];
            for (int j = 1; j < n; ++j) {
                G[j] = G[j - 1] + F[j];
            }
            System.arraycopy(G, 0, F, 0, n);
        }

        long minimum = Long.MAX_VALUE;
        for (long num : F) {
            minimum = Math.min(minimum, num);
        }
        return minimum;
    }

    // 辅助函数，一次差分，将 F[l..r] 都增加 d
    public void diffOnce(long[] F, int l, int r, long d) {
        if (l > r) {
            return;
        }
        int n = F.length;
        if (l < n) {
            F[l] += d;
        }
        if (r + 1 < n) {
            F[r + 1] -= d;
        }
    }

    
    // 辅助函数，二次差分，将 F[l..r] 增加 ki + b，i 是下标
    public void diffTwice(long[] F, int l, int r, long k, long b) {
        if (l > r) {
            return;
        }
        diffOnce(F, l, l, k * l + b);
        diffOnce(F, l + 1, r, k);
        diffOnce(F, r + 1, r + 1, -(k * r + b));
    }
}
```

```csharp
public class Solution {
    public long MinCost(int[] nums, int x) {
        int n = nums.Length;
        // 找出 nums 中最小的元素，并用其为首元素构造一个新的数组
        int minIdx = 0;
        for (int i = 1; i < n; ++i) {
            if (nums[i] < nums[minIdx]) {
                minIdx = i;
            }
        }
        int[] tmp = new int[n];
        for (int i = 0; i < n; ++i) {
            tmp[i] = nums[(minIdx + i) % n];
        }
        Array.Copy(tmp, 0, nums, 0, n);

        int[] L = new int[n];
        int[] R = new int[n];
        L[0] = n - 1;
        // 循环来看，右侧 nums[0] 是更小的元素，但不一定是第一个更小的元素，需要用单调栈计算得到
        for (int i = 0; i < n; ++i) {
            R[i] = n - i - 1;
        }
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        for (int i = 1; i < n; ++i) {
            while (stack.Count > 0 && nums[i] < nums[stack.Peek()]) {
                R[stack.Peek()] = i - stack.Peek() - 1;
                stack.Pop();
            }
            L[i] = i - stack.Peek() - 1;
            stack.Push(i);
        }

        long[] F = new long[n];

        // 进行操作需要的成本
        DiffTwice(F, 0, n - 1, x, 0);

        for (int i = 0; i < n; ++i) {
            int minv = Math.Min(L[i], R[i]);
            int maxv = Math.Max(L[i], R[i]);
            // 第一种情况，窗口数量 k+1，总和 nums[i] * k + nums[i]
            DiffTwice(F, 0, minv, nums[i], nums[i]);
            // 第二种情况，窗口数量 minv+1，总和 0 * k + nums[i] * (minv + 1)
            DiffTwice(F, minv + 1, maxv, 0, (long) nums[i] * (minv + 1));
            // 第三种情况，窗口数量 L[i]+R[i]-k+1，总和 -nums[i] * k + nums[i] * (L[i] + R[i] + 1)
            DiffTwice(F, maxv + 1, L[i] + R[i], -nums[i], (long) nums[i] * (L[i] + R[i] + 1));
        }

        // 计算两次前缀和
        for (int i = 0; i < 2; ++i) {
            long[] G = new long[n];
            G[0] = F[0];
            for (int j = 1; j < n; ++j) {
                G[j] = G[j - 1] + F[j];
            }
            Array.Copy(G, 0, F, 0, n);
        }

        long minimum = long.MaxValue;
        foreach (long num in F) {
            minimum = Math.Min(minimum, num);
        }
        return minimum;
    }

    // 辅助函数，一次差分，将 F[l..r] 都增加 d
    public void DiffOnce(long[] F, int l, int r, long d) {
        if (l > r) {
            return;
        }
        int n = F.Length;
        if (l < n) {
            F[l] += d;
        }
        if (r + 1 < n) {
            F[r + 1] -= d;
        }
    }

    
    // 辅助函数，二次差分，将 F[l..r] 增加 ki + b，i 是下标
    public void DiffTwice(long[] F, int l, int r, long k, long b) {
        if (l > r) {
            return;
        }
        DiffOnce(F, l, l, k * l + b);
        DiffOnce(F, l + 1, r, k);
        DiffOnce(F, r + 1, r + 1, -(k * r + b));
    }
}
```

```python
class Solution:
    def minCost(self, nums: List[int], x: int) -> int:
        n = len(nums)
        # 找出 nums 中最小的元素，并用其为首元素构造一个新的数组
        min_idx = nums.index(min(nums))
        nums = nums[min_idx:] + nums[:min_idx]

        L = [n - 1] + [0] * (n - 1)
        # 循环来看，右侧 nums[0] 是更小的元素，但不一定是第一个更小的元素，需要用单调栈计算得到
        R = [n - i - 1 for i in range(n)]

        s = [0]
        for i in range(1, n):
            while s and nums[i] < nums[s[-1]]:
                R[s[-1]] = i - s[-1] - 1
                s.pop()
            L[i] = i - s[-1] - 1
            s.append(i)
        
        F = [0] * n
        # 辅助函数，一次差分，将 F[l..r] 都增加 d
        def diff_once(l: int, r: int, d: int) -> None:
            if l > r:
                return
            if l < n:
                F[l] += d
            if r + 1 < n:
                F[r + 1] -= d
        
        # 辅助函数，二次差分，将 F[l..r] 增加 ki + b，i 是下标
        def diff_twice(l: int, r: int, k: int, b: int) -> None:
            if l > r:
                return
            diff_once(l, l, k * l + b)
            diff_once(l + 1, r, k)
            diff_once(r + 1, r + 1, -(k * r + b))

        # 进行操作需要的成本
        diff_twice(0, n - 1, x, 0)

        for i in range(n):
            minv, maxv = min(L[i], R[i]), max(L[i], R[i])
            # 第一种情况，窗口数量 k+1，总和 nums[i] * k + nums[i]
            diff_twice(0, minv, nums[i], nums[i])
            # 第二种情况，窗口数量 minv+1，总和 0 * k + nums[i] * (minv + 1)
            diff_twice(minv + 1, maxv, 0, nums[i] * (minv + 1))
            # 第三种情况，窗口数量 L[i]+R[i]-k+1，总和 -nums[i] * k + nums[i] * (L[i] + R[i] + 1)
            diff_twice(maxv + 1, L[i] + R[i], -nums[i], nums[i] * (L[i] + R[i] + 1))

        # 计算两次前缀和
        return min(accumulate(accumulate(F)))
```

```go
func minElement(nums []int) int {
    k := 0
    for i := range nums {
        if nums[k] > nums[i] {
            k = i
        }
    }
    return k
}

func minElementInt64(nums []int64) int {
    k := 0
    for i := range nums {
        if nums[k] > nums[i] {
            k = i
        }
    }
    return k
}

func partialSum(F []int64) {
    for i := 1; i < len(F); i++ {
        F[i] += F[i - 1]
    }
}

func minCost(nums []int, x int) int64 {
    n := len(nums)
    // 找出 nums 中最小的元素，并用其为首元素构造一个新的数组
    minIdx := minElement(nums)
    var tmp []int
    for i := 0; i < n; i++ {
        tmp = append(tmp, nums[(minIdx + i) % n])
    }
    nums = tmp

    L, R := make([]int, n), make([]int, n)
    L[0] = n - 1
    // 循环来看，右侧 nums[0] 是更小的元素，但不一定是第一个更小的元素，需要用单调栈计算得到
    for i := 0; i < n; i++ {
        R[i] = n - i - 1
    }
    s := []int{0}
    for i := 1; i < n; i++ {
        for len(s) > 0 && nums[i] < nums[s[len(s) - 1]] {
            R[s[len(s) - 1]] = i - s[len(s) - 1] - 1
            s = s[:len(s) - 1]
        }
        L[i] = i - s[len(s) - 1] - 1
        s = append(s, i)
    }

    F := make([]int64, n)
    // 辅助函数，一次差分，将 F[l..r] 都增加 d
    diffOnce := func(l, r int, d int64) {
        if l > r {
            return
        }
        if l < n {
            F[l] += d
        }
        if r + 1 < n {
            F[r + 1] -= d
        }
    }
    // 辅助函数，二次差分，将 F[l..r] 增加 ki + b，i 是下标
    diffTwice := func(l, r int, k, b int64) {
        if l > r {
            return
        }
        diffOnce(l, l, k * int64(l) + b)
        diffOnce(l + 1, r, k)
        diffOnce(r + 1, r + 1, -(k * int64(r) + b))
    }

    // 进行操作需要的成本
    diffTwice(0, n - 1, int64(x), 0)

    for i := 0; i < n; i++ {
        minV := min(L[i], R[i])
        maxV := max(L[i], R[i])
        // 第一种情况，窗口数量 k+1，总和 nums[i] * k + nums[i]
        diffTwice(0, minV, int64(nums[i]), int64(nums[i]))
        // 第二种情况，窗口数量 minV+1，总和 0 * k + nums[i] * (minV + 1)
        diffTwice(minV + 1, maxV, 0, int64(nums[i]) * int64(minV + 1))
        // 第三种情况，窗口数量 L[i]+R[i]-k+1，总和 -nums[i] * k + nums[i] * (L[i] + R[i] + 1)
        diffTwice(maxV + 1, L[i] + R[i], -int64(nums[i]), int64(nums[i]) * int64(L[i] + R[i] + 1))
    }

    // 计算两次前缀和
    for i := 0; i < 2; i++ {
        partialSum(F)
    }
    return F[minElementInt64(F)]
}
```

```c
int minElement(int *nums, int n) {
    int k = 0;
    for (int i = 0; i < n; i++) {
        if (nums[k] > nums[i]) {
            k = i;
        }
    }
    return k;
}

int minElement2(long long *nums, int n) {
    int k = 0;
    for (int i = 0; i < n; i++) {
        if (nums[k] > nums[i]) {
            k = i;
        }
    }
    return k;
}


// 辅助函数，一次差分，将 F[l..r] 都增加 d
void diffOnce(long long *F, int n, int l, int r, long long d) {
    if (l > r) {
        return;
    }
    if (l < n) {
        F[l] += d;
    }
    if (r + 1 < n) {
        F[r + 1] -= d;
    }
}

// 辅助函数，二次差分，将 F[l..r] 增加 ki + b，i 是下标
void diffTwice(long long *F, int n, int l, int r, long long k, long long b) {
    if (l > r) {
        return;
    }
    diffOnce(F, n, l, l, k * l + b);
    diffOnce(F, n, l + 1, r, k);
    diffOnce(F, n, r + 1, r + 1, -(k * r + b));
}

long long minCost(int *nums, int numsSize, int x) {
    int n = numsSize;
    // 找出 nums 中最小的元素，并用其为首元素构造一个新的数组
    int minIdx = minElement(nums, n);
    int *tmp = (int *)malloc(sizeof(int) * n);
    for (int i = 0; i < n; ++i) {
        tmp[i] = nums[(minIdx + i) % n];
    }
    memcpy(nums, tmp, sizeof(int) * n);
    free(tmp);
    tmp = NULL;

    int *L = (int *)malloc(sizeof(int) * n);
    int *R = (int *)malloc(sizeof(int) * n);
    L[0] = n - 1;
    // 循环来看，右侧 nums[0] 是更小的元素，但不一定是第一个更小的元素，需要用单调栈计算得到
    for (int i = 0; i < n; ++i) {
        R[i] = n - i - 1;
    }
    int *s = (int *)malloc(sizeof(int) * n);
    int t = -1;
    s[++t] = 0;
    for (int i = 1; i < n; ++i) {
        while (t > 0 && nums[i] < nums[s[t]]) {
            R[s[t]] = i - s[t] - 1;
            t--;
        }
        L[i] = i - s[t] - 1;
        s[++t] = i;
    }
    free(s);
    s = NULL;

    long long *F = malloc(sizeof(long long) * n);
    memset(F, 0, sizeof(long long) * n);

    // 进行操作需要的成本
    diffTwice(F, n, 0, n - 1, x, 0);

    for (int i = 0; i < n; ++i) {
        int minv = fmin(L[i], R[i]);
        int maxv = fmax(L[i], R[i]);
        // 第一种情况，窗口数量 k+1，总和 nums[i] * k + nums[i]
        diffTwice(F, n, 0, minv, nums[i], nums[i]);
        // 第二种情况，窗口数量 minv+1，总和 0 * k + nums[i] * (minv + 1)
        diffTwice(F, n, minv + 1, maxv, 0, (long long)nums[i] * (minv + 1));
        // 第三种情况，窗口数量 L[i]+R[i]-k+1，总和 -nums[i] * k + nums[i] * (L[i] + R[i] + 1)
        diffTwice(F, n, maxv + 1, L[i] + R[i], -nums[i], (long long)nums[i] * (L[i] + R[i] + 1));
    }

    // 计算两次前缀和
    for (int i = 0; i < 2; ++i) {
        for (int i = 1; i < n; i++) {
            F[i] += F[i - 1];
        }
    }

    long long ans = F[minElement2(F, n)];
    free(F);
    free(L);
    free(R);

    return ans;
}
```

```javascript
var minCost = function(nums, x) {
    const n = nums.length;
    // 找出 nums 中最小的元素，并用其为首元素构造一个新的数组
    const min_idx = nums.indexOf(Math.min(...nums));
    let tmp = [];
    for (let i = 0; i < n; ++i) {
        tmp.push(nums[(min_idx + i) % n]);
    }
    nums = tmp;

    const L = new Array(n).fill(0);
    const R = new Array(n).fill(0);
    L[0] = n - 1;
    // 循环来看，右侧 nums[0] 是更小的元素，但不一定是第一个更小的元素，需要用单调栈计算得到
    for (let i = 0; i < n; i++) {
        R[i] = n - i - 1;
    }

    let s = [0];
    for (let i = 1; i < n; i++) {
        while (s.length > 0 && nums[i] < nums[s[s.length - 1]]) {
            R[s[s.length - 1]] = i - s[s.length - 1] - 1;
            s.pop();
        }
        L[i] = i - s[s.length - 1] - 1;
        s.push(i);
    }
    
    let F = new Array(n).fill(0);
    // 辅助函数，一次差分，将 F[l..r] 都增加 d
    const diff_once = function(l, r, d) {
        if (l > r) {
            return;
        }
        if (l < n) {
            F[l] += d;
        }
        if (r + 1 < n) {
            F[r + 1] -= d;
        }
    }
    
    // 辅助函数，二次差分，将 F[l..r] 增加 ki + b，i 是下标
    const diff_twice = function(l, r, k, b) {
        if (l > r) {
            return;
        }
        diff_once(l, l, k * l + b);
        diff_once(l + 1, r, k);
        diff_once(r + 1, r + 1, -(k * r + b));
    }

    // 进行操作需要的成本
    diff_twice(0, n - 1, x, 0);
    for (let i = 0; i < n; i++) {
        let minv = Math.min(L[i], R[i]);
        let maxv = Math.max(L[i], R[i]);
        // 第一种情况，窗口数量 k+1，总和 nums[i] * k + nums[i]
        diff_twice(0, minv, nums[i], nums[i]);
        // 第二种情况，窗口数量 minv+1，总和 0 * k + nums[i] * (minv + 1)
        diff_twice(minv + 1, maxv, 0, nums[i] * (minv + 1));
        // 第三种情况，窗口数量 L[i]+R[i]-k+1，总和 -nums[i] * k + nums[i] * (L[i] + R[i] + 1)
        diff_twice(maxv + 1, L[i] + R[i], -nums[i], nums[i] * (L[i] + R[i] + 1));
    }

    // 计算两次前缀和
    for (let i = 0; i < 2; i++) {
        let G = new Array(n).fill(0);
        G[0] = F[0];
        for (let j = 1; j < n; j++) {
            G[j] = G[j - 1] + F[j];
        }
        F = G;
    }
    return Math.min(...F);
};
```

#### 复杂度分析

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(n)$。
