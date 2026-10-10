### [最小差值平方和](https://leetcode.cn/problems/minimum-sum-of-squared-difference/solutions/4036273/zui-xiao-chai-zhi-ping-fang-he-by-leetco-53xg/)

#### 方法一：贪心

**思路与算法**

根据题意，在 $nums_1$ 上进行的加操作能够用在 $nums_2$ 上的加操作或减操作替代，同样的，在 $nums_1$ 上进行的减操作也能够用在 $nums_2$ 上的加操作或减操作替代。因此在 $nums_1$ 上进行的操作本质上和在 $nums_2$ 上进行的操作相同，于是我们最多可以进行 $k=k_1+k_2$ 次操作。

我们要最小化 $nums_1$ 和 $nums_2$ 的差值平方和，即求

$$\mathop{min}\sum\limits_{i=0}^{n-1}(nums_1[i]-nums_2[i])^2$$

定义 $diff[i]$ 为 $\vert nums_1[i]-nums_2[i]\vert $，我们的每次操作都能够使 $diff$ 中的元素减一。那么在直觉上，每次操作将 $diff$ 中最大的元素减一是最佳选择。

于是我们可以将 $diff$ 从大到小排序，然后从左往右遍历 $diff$ 来削减其中的元素值，并更新剩余操作次数 $k$。

在遍历到 $i$ 时如果仍有能够支撑操作的 $k$ 时，削减方式如下：

- 当 $i=1$ 时，将 $diff[0]$ 削减到 $diff[1]$。
- 当 $i>1$ 时，由于 $diff[0\dots i-1]$ 均被削减到 $diff[i-1]$ 了，因此当前步骤的操作量为：

$$cost=(diff[i-1]-diff[i])\times i$$

如果 $k$ 大于 $cost$，说明当前剩余的操作次数能够支撑此次削减，削减后更新 $k=k-cost$ 即可，否则当前剩余的操作次数无法满足将前 $i$ 个元素都削减为 $diff[i]$，于是会导致如下情况：

虽然当前剩余的操作次数无法满足将前 $i$ 个元素都削减为 $diff[i]$，但是仍然能够对部分元素进行削减。于是我们进入收尾操作：

- 由于前 $i$ 个元素值相等，先计算能够将前 $i$ 个元素共同削减的值 $q=\lfloor\dfrac{k}{i}\rfloor$。
- 再计算剩余的操作次数 $r=k\bmod i$ 以及削减后的元素值 $hi=diff[i-1]-q$。
- 然后计算从 $0$ 到 $i-1$ 的差值平方和
    - 对于前 $i-r$ 个元素，其差值平方和为 $hi\times hi\times (i-r)$。
    - 对于后 $r$ 个元素，每个元素能够多削减一次，其差值平方和为 $(hi-1)\times (hi-1)\times r$。
- 最后处理从 $i$ 到 $n-1$ 的差值平方和，即 $\sum_{i}^{n-1}diff[i]\times diff[i]$

我们可以在 $diff$ 的最后插入一个 $0$ 来当做哨兵，避免边界判断。在代码实现中由于 $nums_1$ 能够复用，因此上文中的 $diff$ 在代码中体现为 $nums_1$。

```C++
class Solution {
public:
    long long minSumSquareDiff(vector<int>& nums1, vector<int>& nums2, int k1, int k2) {
        long long k = (long long)k1 + k2;
        int n = nums1.size();
        for (int i = 0; i < n; i++) {
            nums1[i] = abs(nums1[i] - nums2[i]);
        }
        if (accumulate(nums1.begin(), nums1.end(), 0LL) <= k) {
            return 0;
        }
        sort(nums1.begin(), nums1.end(), greater<int>());
        nums1.push_back(0);
        for (int i = 1; i <= n; i++) {
            long long cost = (long long)(nums1[i - 1] - nums1[i]) * i;
            if (cost > k) {
                long long q = k / i, r = k % i;
                long long hi = nums1[i - 1] - q;
                long long ans = hi * hi * (i - r) + (hi - 1) * (hi - 1) * r;
                for (int j = i; j < n; j++) {
                    ans += (long long)nums1[j] * nums1[j];
                }
                return ans;
            }
            k -= cost;
        }
        return 0;
    }
};
```

```Go
func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}

func minSumSquareDiff(nums1 []int, nums2 []int, k1 int, k2 int) int64 {
    k := int64(k1 + k2)
    n := len(nums1)

    sum := int64(0)
    for i := 0; i < n; i++ {
        nums1[i] = abs(nums1[i] - nums2[i])
        sum += int64(nums1[i])
    }
    if sum <= k {
        return 0
    }

    sort.Slice(nums1, func(i, j int) bool { return nums1[i] > nums1[j] })
    nums1 = append(nums1, 0)

    for i := 1; i <= n; i++ {
        cost := int64(nums1[i-1]-nums1[i]) * int64(i)
        if cost > k {
            q, r := k/int64(i), k%int64(i)
            hi := int64(nums1[i-1]) - q
            ans := hi*hi*(int64(i)-r) + (hi-1)*(hi-1)*r
            for _, x := range nums1[i:n] {
                ans += int64(x) * int64(x)
            }
            return ans
        }
        k -= cost
    }
    return 0
}
```

```Python
class Solution:
    def minSumSquareDiff(self, nums1: List[int], nums2: List[int], k1: int, k2: int) -> int:
        k = k1 + k2
        d = [abs(a - b) for a, b in zip(nums1, nums2)]
        if sum(d) <= k:
            return 0

        d.sort(reverse=True)
        d.append(0)
        n = len(nums1)

        for i in range(1, n + 1):
            cost = (d[i - 1] - d[i]) * i
            if cost > k:
                q, r = divmod(k, i)
                hi = d[i - 1] - q
                return hi * hi * (i - r) + (hi - 1) * (hi - 1) * r + sum(x * x for x in d[i:n])
            k -= cost
        return 0
```

```Java
class Solution {
    public long minSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2) {
        long k = (long) k1 + k2;
        int n = nums1.length;

        long sum = 0;
        for (int i = 0; i < n; i++) {
            nums1[i] = Math.abs(nums1[i] - nums2[i]);
            sum += nums1[i];
        }
        if (sum <= k) {
            return 0;
        }

        Arrays.sort(nums1);
        int[] d = new int[n + 1];
        for (int i = 0; i < n; i++) {
            d[i] = nums1[n - 1 - i];
        }

        for (int i = 1; i <= n; i++) {
            long cost = (long) (d[i - 1] - d[i]) * i;
            if (cost > k) {
                long q = k / i, r = k % i, hi = d[i - 1] - q;
                long ans = hi * hi * (i - r) + (hi - 1) * (hi - 1) * r;
                for (int j = i; j < n; j++) {
                    ans += (long) d[j] * d[j];
                }
                return ans;
            }
            k -= cost;
        }
        return 0;
    }
}
```

```CSharp
public class Solution {
    public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2) {
        long k = (long)k1 + k2;
        int n = nums1.Length;

        long sum = 0;
        for (int i = 0; i < n; i++) {
            nums1[i] = Math.Abs(nums1[i] - nums2[i]);
            sum += nums1[i];
        }
        if (sum <= k) {
            return 0;
        }

        Array.Sort(nums1);
        Array.Reverse(nums1);
        Array.Resize(ref nums1, n + 1);

        for (int i = 1; i <= n; i++) {
            long cost = (long)(nums1[i - 1] - nums1[i]) * i;
            if (cost > k) {
                long q = k / i, r = k % i, hi = nums1[i - 1] - q;
                long ans = hi * hi * (i - r) + (hi - 1) * (hi - 1) * r;
                for (int j = i; j < n; j++) {
                    ans += (long)nums1[j] * nums1[j];
                }
                return ans;
            }
            k -= cost;
        }
        return 0;
    }
}
```

```C
int cmpDesc(const void *a, const void *b) {
    return *(const int *)b - *(const int *)a;
}

long long minSumSquareDiff(int *nums1, int nums1Size, int *nums2, int nums2Size, int k1, int k2) {
    long long k = (long long)k1 + k2;
    int n = nums1Size;

    long long sum = 0;
    for (int i = 0; i < n; i++) {
        nums1[i] = abs(nums1[i] - nums2[i]);
        sum += nums1[i];
    }
    if (sum <= k) {
        return 0;
    }

    qsort(nums1, n, sizeof(int), cmpDesc);
    for (int i = 1; i <= n; i++) {
        int next = i < n ? nums1[i] : 0;
        long long cost = (long long)(nums1[i - 1] - next) * i;
        if (cost > k) {
            long long q = k / i, r = k % i, hi = nums1[i - 1] - q;
            long long ans = hi * hi * (i - r) + (hi - 1) * (hi - 1) * r;
            for (int j = i; j < n; j++) {
                ans += (long long)nums1[j] * nums1[j];
            }
            return ans;
        }
        k -= cost;
    }
    return 0;
}
```

```JavaScript
var minSumSquareDiff = function(nums1, nums2, k1, k2) {
    let k = k1 + k2;
    const n = nums1.length;

    let sum = 0;
    for (let i = 0; i < n; i++) {
        nums1[i] = Math.abs(nums1[i] - nums2[i]);
        sum += nums1[i];
    }
    if (sum <= k) {
        return 0;
    }

    nums1.sort((a, b) => b - a);
    nums1.push(0);

    for (let i = 1; i <= n; i++) {
        const cost = (nums1[i - 1] - nums1[i]) * i;
        if (cost > k) {
            const q = Math.floor(k / i), r = k % i, hi = nums1[i - 1] - q;
            let ans = hi * hi * (i - r) + (hi - 1) * (hi - 1) * r;
            for (let j = i; j < n; j++) {
                ans += nums1[j] * nums1[j];
            }
            return ans;
        }
        k -= cost;
    }
    return 0;
};
```

```TypeScript
function minSumSquareDiff(nums1: number[], nums2: number[], k1: number, k2: number): number {
    let k = k1 + k2;
    const n = nums1.length;

    let sum = 0;
    for (let i = 0; i < n; i++) {
        nums1[i] = Math.abs(nums1[i] - nums2[i]);
        sum += nums1[i];
    }
    if (sum <= k) {
        return 0;
    }

    nums1.sort((a, b) => b - a);
    nums1.push(0);

    for (let i = 1; i <= n; i++) {
        const cost = (nums1[i - 1] - nums1[i]) * i;
        if (cost > k) {
            const q = Math.floor(k / i), r = k % i, hi = nums1[i - 1] - q;
            let ans = hi * hi * (i - r) + (hi - 1) * (hi - 1) * r;
            for (let j = i; j < n; j++) {
                ans += nums1[j] * nums1[j];
            }
            return ans;
        }
        k -= cost;
    }
    return 0;
};
```

```Rust
impl Solution {
    pub fn min_sum_square_diff(mut nums1: Vec<i32>, nums2: Vec<i32>, k1: i32, k2: i32) -> i64 {
        let n = nums1.len();
        let mut k = k1 as i64 + k2 as i64;

        let mut sum = 0i64;
        for i in 0..n {
            nums1[i] = (nums1[i] - nums2[i]).abs();
            sum += nums1[i] as i64;
        }
        if sum <= k {
            return 0;
        }

        nums1.sort_unstable_by(|a, b| b.cmp(a));
        nums1.push(0);

        for i in 1..=n {
            let cost = (nums1[i - 1] - nums1[i]) as i64 * i as i64;
            if cost > k {
                let (q, r) = (k / i as i64, k % i as i64);
                let hi = nums1[i - 1] as i64 - q;
                let mut ans = hi * hi * (i as i64 - r) + (hi - 1) * (hi - 1) * r;
                for &x in &nums1[i..n] {
                    ans += x as i64 * x as i64;
                }
                return ans;
            }
            k -= cost;
        }
        0
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 为 $nums_1$ 和 $nums_2$ 的长度。
- 空间复杂度：$O(1)$。

#### 方法二：二分答案

**思路与算法**

把贪心算法中 $diff$ 的元素想象为高度为 $diff[i]$ 的柱子，那么该题本质上是要找到一个能够最大限度上利用 $k$ 的高度 $h$，每根柱子超过 $h$ 的部分都要消耗 $k$ 来进行削减。

为什么能用二分答案来找这个高度呢？我们知道，$h$ 越大，需要削减的部分越少，对 $k$ 的利用也越少，而 $h$ 越小，需要削减的部分越多，对 $k$ 的利用也越多，这构成了二分答案所需的单调性。

于是我们利用二分答案来找到这个 $h$，在代码中体现为 $res$，然后计算出剩余的 $k$，剩余的 $k$ 能够在最后统计答案时对还没有削减为 $0$ 的元素继续削减。

```C++
class Solution {
public:
    long long minSumSquareDiff(vector<int>& nums1, vector<int>& nums2, int k1, int k2) {
        int n = nums1.size();
        long long ans = 0;
        int k = k1 + k2;
        int maxDif = 0;
        int res = 0;
        for (int i = 0; i < n; i++) {
            nums1[i] = abs(nums1[i] - nums2[i]);
            maxDif = max(maxDif, nums1[i]);
        }
        int l = 0, r = maxDif;
        auto check = [&](int mid) -> bool {
            long long sum = 0;
            for (int num : nums1) {
                sum += num > mid ? num - mid : 0;
            }
            return sum <= k;
        };
        while (l <= r) {
            int mid = (l + r) >> 1;
            if (check(mid)) {
                r = mid - 1;
                res = mid;
            } else {
                l = mid + 1;
            }
        }
        for (int i = 0; i < n; i++) {
            if (nums1[i] > res) {
                k -= (nums1[i] - res);
            }
        }
        sort(nums1.begin(), nums1.end(), greater<int>());
        for (int num : nums1) {
            long long diff = res >= num ? num : res;
            if (k && diff) {
                diff--;
                k--;
            }
            ans += diff * diff;
        }
        return ans;
    }
};
```

```Go
func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}

func minSumSquareDiff(nums1 []int, nums2 []int, k1 int, k2 int) int64 {
    k := k1 + k2
    n := len(nums1)
    maxDif := 0
    for i := 0; i < n; i++ {
        nums1[i] = abs(nums1[i] - nums2[i])
        if nums1[i] > maxDif {
            maxDif = nums1[i]
        }
    }

    l, r, res := 0, maxDif, 0
    for l <= r {
        mid := (l + r) / 2
        sum := 0
        for _, num := range nums1 {
            if num > mid {
                sum += num - mid
            }
        }
        if sum <= k {
            r = mid - 1
            res = mid
        } else {
            l = mid + 1
        }
    }

    for _, num := range nums1 {
        if num > res {
            k -= num - res
        }
    }

    sort.Slice(nums1, func(i, j int) bool { return nums1[i] > nums1[j] })
    ans := int64(0)
    for _, num := range nums1 {
        diff := num
        if res < num {
            diff = res
        }
        if k > 0 && diff > 0 {
            diff--
            k--
        }
        ans += int64(diff) * int64(diff)
    }
    return ans
}
```

```Python
class Solution:
    def minSumSquareDiff(self, nums1: List[int], nums2: List[int], k1: int, k2: int) -> int:
        k = k1 + k2
        n = len(nums1)
        max_dif = 0
        for i in range(n):
            nums1[i] = abs(nums1[i] - nums2[i])
            max_dif = max(max_dif, nums1[i])

        l, r, res = 0, max_dif, 0
        while l <= r:
            mid = (l + r) >> 1
            if sum(num - mid for num in nums1 if num > mid) <= k:
                r = mid - 1
                res = mid
            else:
                l = mid + 1

        for num in nums1:
            if num > res:
                k -= num - res

        nums1.sort(reverse=True)
        ans = 0
        for num in nums1:
            diff = min(num, res)
            if k > 0 and diff > 0:
                diff -= 1
                k -= 1
            ans += diff * diff
        return ans
```

```Java
class Solution {
    public long minSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2) {
        int n = nums1.length;
        int k = k1 + k2;
        int maxDif = 0;
        for (int i = 0; i < n; i++) {
            nums1[i] = Math.abs(nums1[i] - nums2[i]);
            maxDif = Math.max(maxDif, nums1[i]);
        }

        int l = 0, r = maxDif, res = 0;
        while (l <= r) {
            int mid = (l + r) >>> 1;
            long sum = 0;
            for (int num : nums1) {
                sum += num > mid ? num - mid : 0;
            }
            if (sum <= k) {
                r = mid - 1;
                res = mid;
            } else {
                l = mid + 1;
            }
        }

        for (int num : nums1) {
            if (num > res) {
                k -= num - res;
            }
        }

        Arrays.sort(nums1);
        long ans = 0;
        for (int i = n - 1; i >= 0; i--) {
            long diff = Math.min(nums1[i], res);
            if (k > 0 && diff > 0) {
                diff--;
                k--;
            }
            ans += diff * diff;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2) {
        int n = nums1.Length;
        int k = k1 + k2;
        int maxDif = 0;
        for (int i = 0; i < n; i++) {
            nums1[i] = Math.Abs(nums1[i] - nums2[i]);
            maxDif = Math.Max(maxDif, nums1[i]);
        }

        int l = 0, r = maxDif, res = 0;
        while (l <= r) {
            int mid = (l + r) / 2;
            long sum = 0;
            foreach (int num in nums1) {
                sum += num > mid ? num - mid : 0;
            }
            if (sum <= k) {
                r = mid - 1;
                res = mid;
            } else {
                l = mid + 1;
            }
        }

        foreach (int num in nums1) {
            if (num > res) {
                k -= num - res;
            }
        }

        Array.Sort(nums1);
        long ans = 0;
        for (int i = n - 1; i >= 0; i--) {
            long diff = Math.Min(nums1[i], res);
            if (k > 0 && diff > 0) {
                diff--;
                k--;
            }
            ans += diff * diff;
        }
        return ans;
    }
}
```

```C
int cmpDesc(const void *a, const void *b) {
    return *(const int *)b - *(const int *)a;
}

long long minSumSquareDiff(int *nums1, int nums1Size, int *nums2, int nums2Size, int k1, int k2) {
    int n = nums1Size;
    int k = k1 + k2;
    int maxDif = 0;
    for (int i = 0; i < n; i++) {
        nums1[i] = abs(nums1[i] - nums2[i]);
        if (nums1[i] > maxDif) {
            maxDif = nums1[i];
        }
    }

    int l = 0, r = maxDif, res = 0;
    while (l <= r) {
        int mid = (l + r) >> 1;
        long long sum = 0;
        for (int i = 0; i < n; i++) {
            sum += nums1[i] > mid ? nums1[i] - mid : 0;
        }
        if (sum <= k) {
            r = mid - 1;
            res = mid;
        } else {
            l = mid + 1;
        }
    }

    for (int i = 0; i < n; i++) {
        if (nums1[i] > res) {
            k -= nums1[i] - res;
        }
    }

    qsort(nums1, n, sizeof(int), cmpDesc);
    long long ans = 0;
    for (int i = 0; i < n; i++) {
        long long diff = nums1[i] < res ? nums1[i] : res;
        if (k > 0 && diff > 0) {
            diff--;
            k--;
        }
        ans += diff * diff;
    }
    return ans;
}
```

```JavaScript
var minSumSquareDiff = function(nums1, nums2, k1, k2) {
    let k = k1 + k2;
    const n = nums1.length;
    let maxDif = 0;
    for (let i = 0; i < n; i++) {
        nums1[i] = Math.abs(nums1[i] - nums2[i]);
        maxDif = Math.max(maxDif, nums1[i]);
    }

    let l = 0, r = maxDif, res = 0;
    while (l <= r) {
        const mid = (l + r) >> 1;
        let sum = 0;
        for (const num of nums1) {
            sum += num > mid ? num - mid : 0;
        }
        if (sum <= k) {
            r = mid - 1;
            res = mid;
        } else {
            l = mid + 1;
        }
    }

    for (const num of nums1) {
        if (num > res) {
            k -= num - res;
        }
    }

    nums1.sort((a, b) => b - a);
    let ans = 0;
    for (const num of nums1) {
        let diff = Math.min(num, res);
        if (k > 0 && diff > 0) {
            diff--;
            k--;
        }
        ans += diff * diff;
    }
    return ans;
};
```

```TypeScript
function minSumSquareDiff(nums1: number[], nums2: number[], k1: number, k2: number): number {
    let k = k1 + k2;
    const n = nums1.length;
    let maxDif = 0;
    for (let i = 0; i < n; i++) {
        nums1[i] = Math.abs(nums1[i] - nums2[i]);
        maxDif = Math.max(maxDif, nums1[i]);
    }

    let l = 0, r = maxDif, res = 0;
    while (l <= r) {
        const mid = (l + r) >> 1;
        let sum = 0;
        for (const num of nums1) {
            sum += num > mid ? num - mid : 0;
        }
        if (sum <= k) {
            r = mid - 1;
            res = mid;
        } else {
            l = mid + 1;
        }
    }

    for (const num of nums1) {
        if (num > res) {
            k -= num - res;
        }
    }

    nums1.sort((a, b) => b - a);
    let ans = 0;
    for (const num of nums1) {
        let diff = Math.min(num, res);
        if (k > 0 && diff > 0) {
            diff--;
            k--;
        }
        ans += diff * diff;
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn min_sum_square_diff(mut nums1: Vec<i32>, nums2: Vec<i32>, k1: i32, k2: i32) -> i64 {
        let n = nums1.len();
        let mut k = k1 + k2;
        let mut max_dif = 0;
        for i in 0..n {
            nums1[i] = (nums1[i] - nums2[i]).abs();
            max_dif = max_dif.max(nums1[i]);
        }

        let (mut l, mut r, mut res) = (0, max_dif, 0);
        while l <= r {
            let mid = (l + r) >> 1;
            let sum: i64 = nums1.iter().map(|&num| (num.max(mid) - mid) as i64).sum();
            if sum <= k as i64 {
                r = mid - 1;
                res = mid;
            } else {
                l = mid + 1;
            }
        }

        for &num in &nums1 {
            if num > res {
                k -= num - res;
            }
        }

        nums1.sort_unstable_by(|a, b| b.cmp(a));
        let mut ans = 0i64;
        for &num in &nums1 {
            let mut diff = num.min(res) as i64;
            if k > 0 && diff > 0 {
                diff -= 1;
                k -= 1;
            }
            ans += diff * diff;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n(\log n+\log m))$，其中 $n$ 为 $nums_1$ 和 $nums_2$ 的长度，$m$ 为 $nums_1$ 与 $nums_2$ 各元素差值的最大值，复杂度瓶颈在排序以及二分答案上。
- 空间复杂度：$O(1)$。
