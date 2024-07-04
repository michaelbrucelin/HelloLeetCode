### [拾起 K 个 $1$ 需要的最少行动次数](https://leetcode.cn/problems/minimum-moves-to-pick-k-ones/solutions/2827546/shi-qi-k-ge-1-xu-yao-de-zui-shao-xing-do-1c7m/)

#### 方法一：贪心 + 二分

考虑 Alice 拾起 $1$ 的两种情况：

- 情况一：先将 $aliceIndex$ 邻近的数字设置为 $1$，然后交换数字，只需要两次行动就可以拾起一个 $1$。
- 情况二：令 $nums[x]=1$，那么需要 $∣x-aliceIndex∣$ 次行动才可以拾起一个 $1$，根据 $x$ 的取值，又可以区分成两种类型：
    - $x∈[aliceIndex-1,aliceIndex+1]$，那么最多需要 $1$ 次行动就可以拾起一个 $1$。
    - $x∈/[aliceIndex-1,aliceIndex+1]$，那么最少需要 $2$ 次行动才可以拾起一个 $1$。

令 f(aliceIndex) 表示数组 $nums$ 在区间 [aliceIndex-1,aliceIndex+1] 内的元素之和。

如果 $f(aliceIndex)+maxChanges \ le k$，那么最少行动次数肯定是先将区间 $[aliceIndex-1,aliceIndex+1]$ 内的所有 $1$ 拾起，然后剩余的 $1$ 根据情况一来拾起。

如果 $f(aliceIndex)+maxChanges \lt k$，那么可以贪心地先拾起情况一的所有 1，剩余 $k-maxChanges$ 个 $1$ 根据情况二拾起。我们使用 $indexSum[i]$ 记录数组 $nums$ 在区间 $[0,i)$ 内所有值为 $1$ 的元素下标之和，使用 $sum[i]$ 记录数组 $nums$ 在区间 $[0,i)$ 所有元素之和。要使情况二的行动次数之和最少，那么拾起的 $1$ 距离 $aliceIndex$ 需要尽量近。我们使用二分算法来搜索最短距离 $d$，使得区间 $[aliceIndex-d,aliceIndex+d]$ 内的 $1$ 数目大于等于 $k-maxChanges$。记选择的区间为 $[i_2, i_2]$，那么最少行动次数为：

$$indexSum[i_2 +1]-indexSum[aliceIndex+1]-aliceIndex \times (sum[i_2 +1]-sum[i+1])+aliceIndex \times (sum[aliceIndex+1]-sum[i_2 ])-(indexSum[aliceIndex+1]-indexSum[i_2 ])+2 \times maxChanges$$

我们可以枚举 $aliceIndex$，然后取所有结果的最小值。

```C++
class Solution {
public:
    long long minimumMoves(vector<int>& nums, int k, int maxChanges) {
        int n = nums.size();
        auto f = [&](int i) -> int {
            int x = nums[i];
            if (i - 1 >= 0) {
                x += nums[i - 1];
            }
            if (i + 1 < n) {
                x += nums[i + 1];
            }
            return x;
        };

        vector<long long> indexSum(n + 1), sum(n + 1);
        for (int i = 0; i < n; i++) {
            indexSum[i + 1] = indexSum[i] + nums[i] * i;
            sum[i + 1] = sum[i] + nums[i];
        }
        long long res = LONG_LONG_MAX;
        for (int i = 0; i < n; i++) {
            if (f(i) + maxChanges >= k) {
                if (k <= f(i)) {
                    res = min(res, (long long)k - nums[i]);
                } else {
                    res = min(res, (long long)2 * k - f(i) - nums[i]);
                }
                continue;
            }
            int left = 0, right = n;
            while (left <= right) {
                int mid = (left + right) / 2;
                int i1 = max(i - mid, 0), i2 = min(i + mid, n - 1);
                if (sum[i2 + 1] - sum[i1] >= k - maxChanges) {
                    right = mid - 1;
                } else {
                    left = mid + 1;
                }
            }
            int i1 = max(i - left, 0), i2 = min(i + left, n - 1);
            if (sum[i2 + 1] - sum[i1] > k - maxChanges) {
                i1++;
            }
            long long count1 = sum[i + 1] - sum[i1], count2 = sum[i2 + 1] - sum[i + 1];
            res = min(res, indexSum[i2 + 1] - indexSum[i + 1] - i * count2 + i * count1 - (indexSum[i + 1] - indexSum[i1]) + 2 * maxChanges);
        }
        return res;
    }
};
```

```Go
func minimumMoves(nums []int, k int, maxChanges int) int64 {
    n := len(nums)
    f := func(i int) int {
        x := nums[i]
        if i - 1 >= 0 {
            x += nums[i - 1]
        }
        if i + 1 < n {
            x += nums[i + 1]
        }
        return x
    }

    indexSum, sum := make([]int64, n + 1), make([]int64, n + 1)
    for i := 0; i < n; i++ {
        indexSum[i + 1] = indexSum[i] + int64(nums[i]) * int64(i)
        sum[i + 1] = sum[i] + int64(nums[i])
    }
    var res int64 = math.MaxInt64
    for i := 0; i < n; i++ {
        if f(i) + maxChanges >= k {
            if k <= f(i) {
                res = min(res, int64(k - nums[i]))
            } else {
                res = min(res, int64(2 * k - f(i) - nums[i]))
            }
            continue
        }
        left, right := 0, n
        for left <= right {
            mid := (left + right) / 2
            i1, i2 := max(i - mid, 0), min(i + mid, n - 1)
            if sum[i2 + 1] - sum[i1] >= int64(k - maxChanges) {
                right = mid - 1
            } else {
                left = mid + 1
            }
        }
        i1, i2 := max(i - left, 0), min(i + left, n - 1)
        if sum[i2 + 1] - sum[i1] > int64(k - maxChanges) {
            i1++
        }
        count1, count2 := sum[i + 1] - sum[i1], sum[i2 + 1] - sum[i + 1]
        res = min(res, indexSum[i2 + 1] - indexSum[i + 1] - int64(i) * count2 + int64(i) * count1 - (indexSum[i + 1] - indexSum[i1]) + 2 * int64(maxChanges))
    }
    return res
}
```

```Python
class Solution:
    def minimumMoves(self, nums: List[int], k: int, maxChanges: int) -> int:
        n = len(nums)
        def f(i: int) -> int:
            return sum(nums[max(i - 1, 0):min(i + 2, n)])

        indexSum, count = [0] * (n + 1), [0] * (n + 1)
        for i in range(n):
            indexSum[i + 1], count[i + 1] = indexSum[i] + nums[i] * i, count[i] + nums[i]
        res = inf
        for i in range(n):
            if f(i) + maxChanges >= k:
                if k <= f(i):
                    res = min(res, k - nums[i])
                else:
                    res = min(res, 2 * k - f(i) - nums[i])
            left, right = 0, n
            while left <= right:
                mid = (left + right) // 2
                i1, i2 = max(i - mid, 0), min(i + mid, n - 1)
                if count[i2 + 1] - count[i1] >= k - maxChanges:
                    right = mid - 1
                else:
                    left = mid + 1
            i1, i2 = max(i - left, 0), min(i + left, n - 1)
            if count[i2 + 1] - count[i1] > k - maxChanges:
                i1 += 1
            count1, count2 = count[i + 1] - count[i1], count[i2 + 1] - count[i + 1]
            res = min(res, indexSum[i2 + 1] - indexSum[i + 1] - i * count2 + i * count1 - (indexSum[i + 1] - indexSum[i1]) + 2 * maxChanges)
        return res
```

```C
int f(int i, int *nums, int numsSize) {
    int x = nums[i];
    if (i - 1 >= 0) {
        x += nums[i - 1];
    }
    if (i + 1 < numsSize) {
        x += nums[i + 1];
    }
    return x;
}

long long minimumMoves(int* nums, int numsSize, int k, int maxChanges) {
    int n = numsSize;

    long long *indexSum = (long long *)malloc(sizeof(long long) * (n + 1)), *sum = (long long *)malloc(sizeof(long long) * (n + 1));
    for (int i = 0; i < n; i++) {
        indexSum[i + 1] = indexSum[i] + nums[i] * i;
        sum[i + 1] = sum[i] + nums[i];
    }
    long long res = LLONG_MAX;
    for (int i = 0; i < n; i++) {
        if (f(i, nums, n) + maxChanges >= k) {
            if (k <= f(i, nums, n)) {
                res = fmin(res, (long long)k - nums[i]);
            } else {
                res = fmin(res, (long long)2 * k - f(i, nums, n) - nums[i]);
            }
            continue;
        }
        int left = 0, right = n;
        while (left <= right) {
            int mid = (left + right) / 2;
            int i1 = fmax(i - mid, 0), i2 = fmin(i + mid, n - 1);
            if (sum[i2 + 1] - sum[i1] >= k - maxChanges) {
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        int i1 = fmax(i - left, 0), i2 = fmin(i + left, n - 1);
        if (sum[i2 + 1] - sum[i1] > k - maxChanges) {
            i1++;
        }
        long long count1 = sum[i + 1] - sum[i1], count2 = sum[i2 + 1] - sum[i + 1];
        res = fmin(res, indexSum[i2 + 1] - indexSum[i + 1] - i * count2 + i * count1 - (indexSum[i + 1] - indexSum[i1]) + 2 * maxChanges);
    }
    free(indexSum);
    free(sum);
    return res;
}
```

```Java
class Solution {
    public long minimumMoves(int[] nums, int k, int maxChanges) {
        int n = nums.length;

        long[] indexSum = new long[n + 1], sum = new long[n + 1];
        for (int i = 0; i < n; i++) {
            indexSum[i + 1] = indexSum[i] + nums[i] * i;
            sum[i + 1] = sum[i] + nums[i];
        }
        long res = Long.MAX_VALUE;
        for (int i = 0; i < n; i++) {
            if (f(i, nums) + maxChanges >= k) {
                if (k <= f(i, nums)) {
                    res = Math.min(res, (long)k - nums[i]);
                } else {
                    res = Math.min(res, (long)2 * k - f(i, nums) - nums[i]);
                }
                continue;
            }
            int left = 0, right = n;
            while (left <= right) {
                int mid = (left + right) / 2;
                int i1 = Math.max(i - mid, 0), i2 = Math.min(i + mid, n - 1);
                if (sum[i2 + 1] - sum[i1] >= k - maxChanges) {
                    right = mid - 1;
                } else {
                    left = mid + 1;
                }
            }
            int i1 = Math.max(i - left, 0), i2 = Math.min(i + left, n - 1);
            if (sum[i2 + 1] - sum[i1] > k - maxChanges) {
                i1++;
            }
            long count1 = sum[i + 1] - sum[i1], count2 = sum[i2 + 1] - sum[i + 1];
            res = Math.min(res, indexSum[i2 + 1] - indexSum[i + 1] - i * count2 + i * count1 - (indexSum[i + 1] - indexSum[i1]) + 2 * maxChanges);
        }
        return res;
    }

    public int f(int i, int[] nums) {
        int x = nums[i];
        if (i - 1 >= 0) {
            x += nums[i - 1];
        }
        if (i + 1 < nums.length) {
            x += nums[i + 1];
        }
        return x;
    }
}
```

```CSharp
public class Solution {
    public long MinimumMoves(int[] nums, int k, int maxChanges) {
        int n = nums.Length;

        long[] indexSum = new long[n + 1], sum = new long[n + 1];
        for (int i = 0; i < n; i++) {
            indexSum[i + 1] = indexSum[i] + nums[i] * i;
            sum[i + 1] = sum[i] + nums[i];
        }
        long res = long.MaxValue;
        for (int i = 0; i < n; i++) {
            if (F(i, nums) + maxChanges >= k) {
                if (k <= F(i, nums)) {
                    res = Math.Min(res, (long)k - nums[i]);
                } else {
                    res = Math.Min(res, (long)2 * k - F(i, nums) - nums[i]);
                }
                continue;
            }
            int left = 0, right = n;
            while (left <= right) {
                int mid = (left + right) / 2;
                int idx1 = Math.Max(i - mid, 0), idx2 = Math.Min(i + mid, n - 1);
                if (sum[idx2 + 1] - sum[idx1] >= k - maxChanges) {
                    right = mid - 1;
                } else {
                    left = mid + 1;
                }
            }
            int i1 = Math.Max(i - left, 0), i2 = Math.Min(i + left, n - 1);
            if (sum[i2 + 1] - sum[i1] > k - maxChanges) {
                i1++;
            }
            long count1 = sum[i + 1] - sum[i1], count2 = sum[i2 + 1] - sum[i + 1];
            res = Math.Min(res, indexSum[i2 + 1] - indexSum[i + 1] - i * count2 + i * count1 - (indexSum[i + 1] - indexSum[i1]) + 2 * maxChanges);
        }
        return res;
    }

    public int F(int i, int[] nums) {
        int x = nums[i];
        if (i - 1 >= 0) {
            x += nums[i - 1];
        }
        if (i + 1 < nums.Length) {
            x += nums[i + 1];
        }
        return x;
    }
}
```

```JavaScript
var f = function(i, nums) {
    let x = nums[i];
    if (i - 1 >= 0) {
        x += nums[i - 1];
    }
    if (i + 1 < nums.length) {
        x += nums[i + 1];
    }
    return x;
};

var minimumMoves = function(nums, k, maxChanges) {
    let n = nums.length;

    let indexSum = new Array(n + 1).fill(0), sum = new Array(n + 1).fill(0);
    for (let i = 0; i < n; i++) {
        indexSum[i + 1] = indexSum[i] + nums[i] * i;
        sum[i + 1] = sum[i] + nums[i];
    }
    let res = Infinity;
    for (let i = 0; i < n; i++) {
        if (f(i, nums) + maxChanges >= k) {
            if (k <= f(i, nums)) {
                res = Math.min(res, k - nums[i]);
            } else {
                res = Math.min(res, 2 * k - f(i, nums) - nums[i]);
            }
            continue;
        }
        let left = 0, right = n;
        while (left <= right) {
            let mid = Math.floor((left + right) / 2);
            let i1 = Math.max(i - mid, 0), i2 = Math.min(i + mid, n - 1);
            if (sum[i2 + 1] - sum[i1] >= k - maxChanges) {
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        let i1 = Math.max(i - left, 0), i2 = Math.min(i + left, n - 1);
        if (sum[i2 + 1] - sum[i1] > k - maxChanges) {
            i1++;
        }
        let count1 = sum[i + 1] - sum[i1], count2 = sum[i2 + 1] - sum[i + 1];
        res = Math.min(res, indexSum[i2 + 1] - indexSum[i + 1] - i * count2 + i * count1 - (indexSum[i + 1] - indexSum[i1]) + 2 * maxChanges);
    }
    return res;
};
```

```TypeScript
var f = function(i, nums) {
    let x = nums[i];
    if (i - 1 >= 0) {
        x += nums[i - 1];
    }
    if (i + 1 < nums.length) {
        x += nums[i + 1];
    }
    return x;
};

var minimumMoves = function(nums, k, maxChanges) {
    let n = nums.length;

    let indexSum = new Array(n + 1).fill(0), sum = new Array(n + 1).fill(0);
    for (let i = 0; i < n; i++) {
        indexSum[i + 1] = indexSum[i] + nums[i] * i;
        sum[i + 1] = sum[i] + nums[i];
    }
    let res = Infinity;
    for (let i = 0; i < n; i++) {
        if (f(i, nums) + maxChanges >= k) {
            if (k <= f(i, nums)) {
                res = Math.min(res, k - nums[i]);
            } else {
                res = Math.min(res, 2 * k - f(i, nums) - nums[i]);
            }
            continue;
        }
        let left = 0, right = n;
        while (left <= right) {
            let mid = Math.floor((left + right) / 2);
            let i1 = Math.max(i - mid, 0), i2 = Math.min(i + mid, n - 1);
            if (sum[i2 + 1] - sum[i1] >= k - maxChanges) {
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        let i1 = Math.max(i - left, 0), i2 = Math.min(i + left, n - 1);
        if (sum[i2 + 1] - sum[i1] > k - maxChanges) {
            i1++;
        }
        let count1 = sum[i + 1] - sum[i1], count2 = sum[i2 + 1] - sum[i + 1];
        res = Math.min(res, indexSum[i2 + 1] - indexSum[i + 1] - i * count2 + i * count1 - (indexSum[i + 1] - indexSum[i1]) + 2 * maxChanges);
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn f(i: i32, nums: &Vec<i32>) -> i32 {
        let mut x = nums[i as usize];
        if i - 1 >= 0 {
            x += nums[(i - 1) as usize];
        }
        if (i + 1) < nums.len() as i32 {
            x += nums[(i + 1) as usize];
        }
        x
    }
    pub fn minimum_moves(nums: Vec<i32>, k: i32, max_changes: i32) -> i64 {
        let mut n = nums.len() as i32;

        let mut indexSum = vec![0 as i64; (n + 1) as usize];
        let mut sum = vec![0 as i64; (n + 1) as usize];
        for i in 0..n {
            indexSum[(i + 1) as usize] = indexSum[i as usize] + (nums[i as usize] as i64) * (i as i64);
            sum[(i + 1) as usize] = sum[i as usize] + (nums[i as usize] as i64);
        }
        let mut res = (((1 as u64) << 63) - 1) as i64;
        for i in 0..n {
            if Self::f(i, &nums) + max_changes >= k {
                if k <= Self::f(i, &nums) {
                    res = std::cmp::min(res, (k - nums[i as usize]) as i64);
                } else {
                    res = std::cmp::min(res, (2 * k - Self::f(i, &nums) - nums[i as usize]) as i64);
                }
                continue;
            }
            let (mut left, mut right) = (0, n);
            while left <= right {
                let mut mid = (left + right) / 2;
                let (mut i1, mut i2) = (std::cmp::max(i - mid, 0), std::cmp::min(i + mid, n - 1));
                if sum[(i2 + 1) as usize] - sum[i1 as usize] >= (k - max_changes) as i64 {
                    right = mid - 1;
                } else {
                    left = mid + 1;
                }
            }
            let (mut i1, mut i2) = (std::cmp::max(i - left, 0), std::cmp::min(i + left, n - 1));
            if sum[(i2 + 1) as usize] - sum[i1 as usize] > (k - max_changes) as i64 {
                i1 += 1;
            }
            let (mut count1, mut count2) = (sum[(i + 1) as usize] - sum[i1 as usize], sum[(i2 + 1) as usize] - sum[(i + 1) as usize]);
            res = std::cmp::min(res, indexSum[(i2 + 1) as usize] - indexSum[(i + 1) as usize] - (i as i64) * count2 + (i as i64) * count1 - (indexSum[(i + 1) as usize] - indexSum[i1 as usize]) + (2 * max_changes as i64));
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nlogn)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(n)$。

#### 方法二：贪心 + 双指针

方法一使用了二分算法选择区间 $[i_2, i_2]$，我们也可以使用双指针来维护 $aliceIndex$ 对应的 $[i_2, i_2]$。

我们从小到大开始枚举 $aliceIndex$，记当前枚举的 $aliceIndex=i$，使用 $left$ 和 $right$ 维护区间的左右端点，$leftCount$ 和 $rightCount$ 维护在区间 $[left,i)$ 和 $[i,right]$ 的元素之和，$leftSum$ 和 $rightSum$ 维护在区间 $[left,i)$ 和 $[i,right]$ 的值为 $1$ 的下标之和。

在枚举过程中，首先尽量保证左右端点到 $i$ 的距离相等且区间内的元素之和大于等于 $k-maxChanges$，然后如果区间内的元素之和大于 $k-maxChanges$，我们需要根据左右端点的距离决定去掉哪些元素，最后最小行动次数为：

$$leftCount \times i - leftSum + rightSum - rightCount \times i + 2 \times maxChanges$$

取枚举过程中的最小行动次数的最小值，返回结果。

```C++
class Solution {
public:
    long long minimumMoves(vector<int>& nums, int k, int maxChanges) {
        int n = nums.size();
        auto f = [&](int i) -> int {
            int x = nums[i];
            if (i - 1 >= 0) {
                x += nums[i - 1];
            }
            if (i + 1 < n) {
                x += nums[i + 1];
            }
            return x;
        };

        int left = 0, right = -1;
        long long leftSum = 0, rightSum = 0;
        long long leftCount = 0, rightCount = 0;
        long long res = LONG_LONG_MAX;
        for (int i = 0; i < n; i++) {
            if (f(i) + maxChanges >= k) {
                if (k <= f(i)) {
                    res = min(res, (long long)k - nums[i]);
                } else {
                    res = min(res, (long long)2 * k - f(i) - nums[i]);
                }
            }
            if (k <= maxChanges) {
                continue;
            }
            while (right + 1 < n && (right - i < i - left || leftCount + rightCount + maxChanges < k)) {
                if (nums[right + 1] == 1) {
                    rightCount++;
                    rightSum += right + 1;
                }
                right++;
            }
            while (leftCount + rightCount + maxChanges > k) {
                if (right - i < i - left || right - i == i - left && nums[left] == 1) {
                    if (nums[left] == 1) {
                        leftCount--;
                        leftSum -= left;
                    }
                    left++;
                } else {
                    if (nums[right] == 1) {
                        rightCount--;
                        rightSum -= right;
                    }
                    right--;
                }
            }
            res = min(res, leftCount * i - leftSum + rightSum - rightCount * i + 2 * maxChanges);
            if (nums[i] == 1) {
                leftCount++;
                leftSum += i;
                rightCount--;
                rightSum -= i;
            }
        }
        return res;
    }
};
```

```Go
func minimumMoves(nums []int, k int, maxChanges int) int64 {
    n := len(nums)
    f := func(i int) int {
        x := nums[i]
        if i - 1 >= 0 {
            x += nums[i - 1]
        }
        if i + 1 < n {
            x += nums[i + 1]
        }
        return x
    }

    left, right := 0, -1
    leftSum, rightSum := int64(0), int64(0)
    leftCount, rightCount := int64(0), int64(0)
    var res int64 = math.MaxInt64
    for i := 0; i < n; i++ {
        if f(i) + maxChanges >= k {
            if k <= f(i) {
                res = min(res, int64(k - nums[i]))
            } else {
                res = min(res, int64(2 * k - f(i) - nums[i]))
            }
        }
        if k <= maxChanges {
            continue
        }
        for right + 1 < n && (right - i < i - left || leftCount + rightCount + int64(maxChanges) < int64(k)) {
            if (nums[right + 1] == 1) {
                rightCount++;
                rightSum += int64(right) + 1;
            }
            right++;
        }
        for leftCount + rightCount + int64(maxChanges) > int64(k) {
            if right - i < i - left || right - i == i - left && nums[left] == 1 {
                if nums[left] == 1 {
                    leftCount--;
                    leftSum -= int64(left);
                }
                left++;
            } else {
                if nums[right] == 1 {
                    rightCount--;
                    rightSum -= int64(right);
                }
                right--;
            }
        }
        res = min(res, leftCount * int64(i) - leftSum + rightSum - rightCount * int64(i) + 2 * int64(maxChanges));
        if nums[i] == 1 {
            leftCount++;
            leftSum += int64(i);
            rightCount--;
            rightSum -= int64(i);
        }
    }
    return res
}
```

```Python
class Solution:
    def minimumMoves(self, nums: List[int], k: int, maxChanges: int) -> int:
        n = len(nums)
        def f(i: int) -> int:
            return sum(nums[max(i - 1, 0):min(i + 2, n)])

        left, right = 0, -1
        leftSum, rightSum = 0, 0
        leftCount, rightCount = 0, 0
        res = inf
        for i in range(n):
            if f(i) + maxChanges >= k:
                if k <= f(i):
                    res = min(res, k - nums[i])
                else:
                    res = min(res, 2 * k - f(i) - nums[i])
            if k <= maxChanges:
                continue
            while right + 1 < n and (right - i < i - left or leftCount + rightCount + maxChanges < k):
                if nums[right + 1] == 1:
                    rightCount += 1
                    rightSum += right + 1
                right += 1
            while leftCount + rightCount + maxChanges > k:
                if right - i < i - left or right - i == i - left and nums[left] == 1:
                    if nums[left] == 1:
                        leftCount -= 1
                        leftSum -= left
                    left += 1
                else:
                    if nums[right] == 1:
                        rightCount -= 1
                        rightSum -= right
                    right -= 1
            res = min(res, leftCount * i - leftSum + rightSum - rightCount * i + 2 * maxChanges)
            if nums[i] == 1:
                leftCount += 1
                leftSum += i
                rightCount -= 1
                rightSum -= i
        return res
```

```C
int f(int i, int *nums, int numsSize) {
    int x = nums[i];
    if (i - 1 >= 0) {
        x += nums[i - 1];
    }
    if (i + 1 < numsSize) {
        x += nums[i + 1];
    }
    return x;
}

long long minimumMoves(int* nums, int numsSize, int k, int maxChanges) {
    int n = numsSize;

    int left = 0, right = -1;
    long long leftSum = 0, rightSum = 0;
    long long leftCount = 0, rightCount = 0;
    long long res = LLONG_MAX;
    for (int i = 0; i < n; i++) {
        if (f(i, nums, n) + maxChanges >= k) {
            if (k <= f(i, nums, n)) {
                res = fmin(res, (long long)k - nums[i]);
            } else {
                res = fmin(res, (long long)2 * k - f(i, nums, n) - nums[i]);
            }
        }
        if (k <= maxChanges) {
            continue;
        }
        while (right + 1 < n && (right - i < i - left || leftCount + rightCount + maxChanges < k)) {
            if (nums[right + 1] == 1) {
                rightCount++;
                rightSum += right + 1;
            }
            right++;
        }
        while (leftCount + rightCount + maxChanges > k) {
            if (right - i < i - left || right - i == i - left && nums[left] == 1) {
                if (nums[left] == 1) {
                    leftCount--;
                    leftSum -= left;
                }
                left++;
            } else {
                if (nums[right] == 1) {
                    rightCount--;
                    rightSum -= right;
                }
                right--;
            }
        }
        res = fmin(res, leftCount * i - leftSum + rightSum - rightCount * i + 2 * maxChanges);
        if (nums[i] == 1) {
            leftCount++;
            leftSum += i;
            rightCount--;
            rightSum -= i;
        }
    }
    return res;
}
```

```Java
class Solution {
    public long minimumMoves(int[] nums, int k, int maxChanges) {
        int n = nums.length;

        int left = 0, right = -1;
        long leftSum = 0, rightSum = 0;
        long leftCount = 0, rightCount = 0;
        long res = Long.MAX_VALUE;
        for (int i = 0; i < n; i++) {
            if (f(i, nums) + maxChanges >= k) {
                if (k <= f(i, nums)) {
                    res = Math.min(res, (long)k - nums[i]);
                } else {
                    res = Math.min(res, (long)2 * k - f(i, nums) - nums[i]);
                }
            }
            if (k <= maxChanges) {
                continue;
            }
            while (right + 1 < n && (right - i < i - left || leftCount + rightCount + maxChanges < k)) {
                if (nums[right + 1] == 1) {
                    rightCount++;
                    rightSum += right + 1;
                }
                right++;
            }
            while (leftCount + rightCount + maxChanges > k) {
                if (right - i < i - left || right - i == i - left && nums[left] == 1) {
                    if (nums[left] == 1) {
                        leftCount--;
                        leftSum -= left;
                    }
                    left++;
                } else {
                    if (nums[right] == 1) {
                        rightCount--;
                        rightSum -= right;
                    }
                    right--;
                }
            }
            res = Math.min(res, leftCount * i - leftSum + rightSum - rightCount * i + 2 * maxChanges);
            if (nums[i] == 1) {
                leftCount++;
                leftSum += i;
                rightCount--;
                rightSum -= i;
            }
        }
        return res;
    }

    public int f(int i, int[] nums) {
        int x = nums[i];
        if (i - 1 >= 0) {
            x += nums[i - 1];
        }
        if (i + 1 < nums.length) {
            x += nums[i + 1];
        }
        return x;
    }
}
```

```CSharp
public class Solution {
    public long MinimumMoves(int[] nums, int k, int maxChanges) {
        int n = nums.Length;

        int left = 0, right = -1;
        long leftSum = 0, rightSum = 0;
        long leftCount = 0, rightCount = 0;
        long res = long.MaxValue;
        for (int i = 0; i < n; i++) {
            if (F(i, nums) + maxChanges >= k) {
                if (k <= F(i, nums)) {
                    res = Math.Min(res, (long)k - nums[i]);
                } else {
                    res = Math.Min(res, (long)2 * k - F(i, nums) - nums[i]);
                }
            }
            if (k <= maxChanges) {
                continue;
            }
            while (right + 1 < n && (right - i < i - left || leftCount + rightCount + maxChanges < k)) {
                if (nums[right + 1] == 1) {
                    rightCount++;
                    rightSum += right + 1;
                }
                right++;
            }
            while (leftCount + rightCount + maxChanges > k) {
                if (right - i < i - left || right - i == i - left && nums[left] == 1) {
                    if (nums[left] == 1) {
                        leftCount--;
                        leftSum -= left;
                    }
                    left++;
                } else {
                    if (nums[right] == 1) {
                        rightCount--;
                        rightSum -= right;
                    }
                    right--;
                }
            }
            res = Math.Min(res, leftCount * i - leftSum + rightSum - rightCount * i + 2 * maxChanges);
            if (nums[i] == 1) {
                leftCount++;
                leftSum += i;
                rightCount--;
                rightSum -= i;
            }
        }
        return res;
    }

    public int F(int i, int[] nums) {
        int x = nums[i];
        if (i - 1 >= 0) {
            x += nums[i - 1];
        }
        if (i + 1 < nums.Length) {
            x += nums[i + 1];
        }
        return x;
    }
}
```

```JavaScript
var f = function(i, nums) {
    let x = nums[i];
    if (i - 1 >= 0) {
        x += nums[i - 1];
    }
    if (i + 1 < nums.length) {
        x += nums[i + 1];
    }
    return x;
};

var minimumMoves = function(nums, k, maxChanges) {
    let n = nums.length;

    let left = 0, right = -1;
    let leftSum = 0, rightSum = 0;
    let leftCount = 0, rightCount = 0;
    let res = Infinity;
    for (let i = 0; i < n; i++) {
        if (f(i, nums) + maxChanges >= k) {
            if (k <= f(i, nums)) {
                res = Math.min(res, k - nums[i]);
            } else {
                res = Math.min(res, 2 * k - f(i, nums) - nums[i]);
            }
        }
        if (k <= maxChanges) {
            continue;
        }
        while (right + 1 < n && (right - i < i - left || leftCount + rightCount + maxChanges < k)) {
            if (nums[right + 1] == 1) {
                rightCount++;
                rightSum += right + 1;
            }
            right++;
        }
        while (leftCount + rightCount + maxChanges > k) {
            if (right - i < i - left || right - i == i - left && nums[left] == 1) {
                if (nums[left] == 1) {
                    leftCount--;
                    leftSum -= left;
                }
                left++;
            } else {
                if (nums[right] == 1) {
                    rightCount--;
                    rightSum -= right;
                }
                right--;
            }
        }
        res = Math.min(res, leftCount * i - leftSum + rightSum - rightCount * i + 2 * maxChanges);
        if (nums[i] == 1) {
            leftCount++;
            leftSum += i;
            rightCount--;
            rightSum -= i;
        }
    }
    return res;
};
```

```TypeScript
var f = function(i, nums) {
    let x = nums[i];
    if (i - 1 >= 0) {
        x += nums[i - 1];
    }
    if (i + 1 < nums.length) {
        x += nums[i + 1];
    }
    return x;
};

var minimumMoves = function(nums, k, maxChanges) {
    let n = nums.length;

    let left = 0, right = -1;
    let leftSum = 0, rightSum = 0;
    let leftCount = 0, rightCount = 0;
    let res = Infinity;
    for (let i = 0; i < n; i++) {
        if (f(i, nums) + maxChanges >= k) {
            if (k <= f(i, nums)) {
                res = Math.min(res, k - nums[i]);
            } else {
                res = Math.min(res, 2 * k - f(i, nums) - nums[i]);
            }
        }
        if (k <= maxChanges) {
            continue;
        }
        while (right + 1 < n && (right - i < i - left || leftCount + rightCount + maxChanges < k)) {
            if (nums[right + 1] == 1) {
                rightCount++;
                rightSum += right + 1;
            }
            right++;
        }
        while (leftCount + rightCount + maxChanges > k) {
            if (right - i < i - left || right - i == i - left && nums[left] == 1) {
                if (nums[left] == 1) {
                    leftCount--;
                    leftSum -= left;
                }
                left++;
            } else {
                if (nums[right] == 1) {
                    rightCount--;
                    rightSum -= right;
                }
                right--;
            }
        }
        res = Math.min(res, leftCount * i - leftSum + rightSum - rightCount * i + 2 * maxChanges);
        if (nums[i] == 1) {
            leftCount++;
            leftSum += i;
            rightCount--;
            rightSum -= i;
        }
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn f(i: i32, nums: &Vec<i32>) -> i32 {
        let mut x = nums[i as usize];
        if i - 1 >= 0 {
            x += nums[(i - 1) as usize];
        }
        if (i + 1) < nums.len() as i32 {
            x += nums[(i + 1) as usize];
        }
        x
    }
    pub fn minimum_moves(nums: Vec<i32>, k: i32, max_changes: i32) -> i64 {
        let mut n = nums.len() as i32;
        let (mut left, mut right) = (0 as i32, -1 as i32);
        let (mut leftSum, mut rightSum) = (0 as i64, 0 as i64);
        let (mut leftCount, mut rightCount) = (0 as i64, 0 as i64);
        let mut res = (((1 as u64) << 63) - 1) as i64;
        for i in 0..n {
            if Self::f(i, &nums) + max_changes >= k {
                if k <= Self::f(i, &nums) {
                    res = std::cmp::min(res, (k - nums[i as usize]) as i64);
                } else {
                    res = std::cmp::min(res, (2 * k - Self::f(i, &nums) - nums[i as usize]) as i64);
                }
            }
            if k <= max_changes {
                continue;
            }
            while right + 1 < n && (right - i < i - left || leftCount + rightCount + (max_changes as i64) < (k as i64)) {
                if nums[right as usize + 1] == 1 {
                    rightCount += 1;
                    rightSum += right as i64 + 1;
                }
                right += 1;
            }
            while leftCount + rightCount + (max_changes as i64) > (k as i64) {
                if right - i < i - left || right - i == i - left && nums[left as usize] == 1 {
                    if nums[left as usize] == 1 {
                        leftCount -= 1;
                        leftSum -= (left as i64);
                    }
                    left += 1;
                } else {
                    if nums[right as usize] == 1 {
                        rightCount -= 1;
                        rightSum -= (right as i64);
                    }
                    right -= 1;
                }
            }
            res = std::cmp::min(res, leftCount * (i as i64) - leftSum + rightSum - rightCount * (i as i64) + 2 * (max_changes as i64));
            if nums[i as usize] == 1 {
                leftCount += 1;
                leftSum += (i as i64);
                rightCount -= 1;
                rightSum -= (i as i64);
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(1)$。
