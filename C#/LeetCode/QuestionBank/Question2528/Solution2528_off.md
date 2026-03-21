### [最大化城市的最小电量](https://leetcode.cn/problems/maximize-the-minimum-powered-city/solutions/3813498/zui-da-hua-cheng-shi-de-zui-xiao-dian-li-94lq/)

#### 方法一：二分查找 + 差分数组

**思路与算法**

根据题意可知，题目要求求出最小电量的最大值，很容易想到可以使用二分查找来确定所有城市最小电量的最大值。关键在于如何检验给定的电量 $x$ 一定可以满足题目要求，即如何判断在增加 $k$ 个供电站的前提下每个城市电量都能满足大于等于 $x$。

根据题意可知，由于第 $i$ 座城市的供电站可以覆盖的范围为 $[i-r,i+r]$，此时我们可以利用差分数组来快速计算每个城市的电量，关键在于如何确定增加的 $k$ 个供电站应该放置在什么位置，可以采用**贪心策略**来确定。假定当前每个城市的最小电量为 $x$，我们从左到右遍历每个城市：

- 如果当前下标 $i$ 的电量满足大于等于 $x$，则我们遍历下标 $i+1$ 的城市；
- 如果当前下标 $i$ 的电量不足 $x$，此时理论上我们应该在区间 $[i-r,i+r]$ 中的任意位置增加供电站。由于我们是按顺序遍历每个城市，当遍历到下标 $i$ 的城市时，所有下标小于 $i$ 的城市的电量均已满足大于等于 $x$，此时下标小于 $i$ 的城市再增加供电站就没有太大意义，因此应该考虑给 $i$ 之后的城市增加尽可能多的电量，如果在 $i+r$ 处增加额外的供电站，增加的供电站的覆盖范围为 $[i,i+2r]$，此时这些增加的供电站可为 $i$ 后面尽可能多的城市增加供电，因此最优选择是在 $i+r$ 处增加供电站。

实际计算过程如下：

- 为了方便计算，根据给定的数组 $stations$，提前计算差分数组 $diff$。利用二分查找来确定最大值，根据题意可知此时二分查找的下限可以从 $stations$ 最小值 $lo=min(stations)$ 开始，上限可以设置为 $hi=sum(stations)+k$，此时无论如何每个城市的最大电量均无法超过 $hi$，接着用二分枚举尝试给定的值 $mid$；
- 每次检验给定的值 $mid$ 时，从左到右计算差分数组的前缀和 $sum$，当遍历到下标 $i$ 时，如果当前 $sum$ 小于 $mid$ 时，则表示当前城市的电量小于 $mid$，此时需要在 $i+r$ 处增加 $add=mid-sum$ 个电站，使得 $i$ 处电量大于等于 $mid$，当前总的电量 $sum$ 需要增加 $add$，同时剩余可以建造的电站数量需要减少 $add$，同时更新差分数组 $diff$，直到所有城市遍历完，则表示当前可以满足所有城市电量大于等于 $mid$，此时可以继续增加 $mid$。如果当前剩余可以建造的电站数量少于 $add$ 时，则表示当前无法满足所有城市的电量均大于等于 $mid$，则此时需要缩小 $mid$；
- 二分查找的目标值即为答案。

**代码**

```C++
class Solution {
public:
    long long maxPower(vector<int>& stations, int r, int k) {
        int n = stations.size();
        vector<long long> cnt(n + 1);
        for (int i = 0; i < n; i++) {
            int left = max(0, i - r);
            int right = min(n, i + r + 1);
            cnt[left] += stations[i];
            cnt[right] -= stations[i];
        }

        auto check = [&](long long val) -> bool {
            vector<long long> diff = cnt;
            long long sum = 0;
            long long remaining = k;

            for (int i = 0; i < n; i++) {
                sum += diff[i];
                if (sum < val) {
                    long long add = val - sum;
                    if (remaining < add) {
                        return false;
                    }
                    remaining -= add;
                    int end = min(n, i + 2 * r + 1);
                    diff[end] -= add;
                    sum += add;
                }
            }
            return true;
        };

        long long lo = ranges::min(stations);
        long long hi = accumulate(stations.begin(), stations.end(), 0LL) + k;
        long long res = 0;
        while (lo <= hi) {
            long long mid = lo + (hi - lo) / 2;
            if (check(mid)) {
                res = mid;
                lo = mid + 1;
            } else {
                hi = mid - 1;
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public long maxPower(int[] stations, int r, int k) {
        int n = stations.length;
        long[] cnt = new long[n + 1];

        for (int i = 0; i < n; i++) {
            int left = Math.max(0, i - r);
            int right = Math.min(n, i + r + 1);
            cnt[left] += stations[i];
            cnt[right] -= stations[i];
        }

        long lo = Arrays.stream(stations).min().getAsInt();
        long hi = Arrays.stream(stations).asLongStream().sum() + k;
        long res = 0;

        while (lo <= hi) {
            long mid = lo + (hi - lo) / 2;
            if (check(cnt, mid, r, k)) {
                res = mid;
                lo = mid + 1;
            } else {
                hi = mid - 1;
            }
        }
        return res;
    }

    private boolean check(long[] cnt, long val, int r, int k) {
        int n = cnt.length - 1;
        long[] diff = cnt.clone();
        long sum = 0;
        long remaining = k;

        for (int i = 0; i < n; i++) {
            sum += diff[i];
            if (sum < val) {
                long add = val - sum;
                if (remaining < add) {
                    return false;
                }
                remaining -= add;
                int end = Math.min(n, i + 2 * r + 1);
                diff[end] -= add;
                sum += add;
            }
        }
        return true;
    }
}
```

```CSharp
public class Solution {
    public long MaxPower(int[] stations, int r, int k) {
        int n = stations.Length;
        long[] cnt = new long[n + 1];

        for (int i = 0; i < n; i++) {
            int left = Math.Max(0, i - r);
            int right = Math.Min(n, i + r + 1);
            cnt[left] += stations[i];
            cnt[right] -= stations[i];
        }

        long lo = stations.Min();
        long hi = stations.Sum(x => (long)x) + k;
        long res = 0;

        while (lo <= hi) {
            long mid = lo + (hi - lo) / 2;
            if (Check(cnt, mid, r, k)) {
                res = mid;
                lo = mid + 1;
            } else {
                hi = mid - 1;
            }
        }
        return res;
    }

    private bool Check(long[] cnt, long val, int r, int k) {
        int n = cnt.Length - 1;
        long[] diff = (long[])cnt.Clone();
        long sum = 0;
        long remaining = k;

        for (int i = 0; i < n; i++) {
            sum += diff[i];
            if (sum < val) {
                long add = val - sum;
                if (remaining < add) {
                    return false;
                }
                remaining -= add;
                int end = Math.Min(n, i + 2 * r + 1);
                diff[end] -= add;
                sum += add;
            }
        }
        return true;
    }
}
```

```Go
func maxPower(stations []int, r int, k int) int64 {
    n := len(stations)
    cnt := make([]int64, n + 1)
    for i := 0; i < n; i++ {
        left := max(0, i - r)
        right := min(n, i + r + 1)
        cnt[left] += int64(stations[i])
        cnt[right] -= int64(stations[i])
    }

    minVal := int64(stations[0])
    sumTotal := int64(0)
    for _, s := range stations {
        if int64(s) < minVal {
            minVal = int64(s)
        }
        sumTotal += int64(s)
    }

    lo, hi := minVal, sumTotal + int64(k)
    var res int64 = 0

    for lo <= hi {
        mid := lo + (hi - lo) / 2
        if check(cnt, mid, r, k) {
            res = mid
            lo = mid + 1
        } else {
            hi = mid - 1
        }
    }
    return res
}

func check(cnt []int64, val int64, r int, k int) bool {
    n := len(cnt) - 1
    diff := make([]int64, len(cnt))
    copy(diff, cnt)
    var sum int64 = 0
    remaining := int64(k)

    for i := 0; i < n; i++ {
        sum += diff[i]
        if sum < val {
            add := val - sum
            if remaining < add {
                return false
            }
            remaining -= add
            end := min(n, i + 2 * r + 1)
            diff[end] -= add
            sum += add
        }
    }

    return true
}
```

```Python
class Solution:
    def maxPower(self, stations: List[int], r: int, k: int) -> int:
        n = len(stations)
        cnt = [0] * (n + 1)

        for i in range(n):
            left = max(0, i - r)
            right = min(n, i + r + 1)
            cnt[left] += stations[i]
            cnt[right] -= stations[i]

        def check(val: int) -> bool:
            diff = cnt.copy()
            total = 0
            remaining = k

            for i in range(n):
                total += diff[i]
                if total < val:
                    add = val - total
                    if remaining < add:
                        return False
                    remaining -= add
                    end = min(n, i + 2 * r + 1)
                    diff[end] -= add
                    total += add
            return True

        lo, hi = min(stations), sum(stations) + k
        res = 0
        while lo <= hi:
            mid = (lo + hi) // 2
            if check(mid):
                res = mid
                lo = mid + 1
            else:
                hi = mid - 1
        return res
```

```C
bool check(long long* cnt, int r, long long k, long long val, int n) {
    long long* diff = (long long*)malloc((n + 1) * sizeof(long long));
    memcpy(diff, cnt, (n + 1) * sizeof(long long));

    long long sum = 0;
    long long remaining = k;

    for (int i = 0; i < n; i++) {
        sum += diff[i];
        if (sum < val) {
            long long add = val - sum;
            if (remaining < add) {
                free(diff);
                return false;
            }
            remaining -= add;
            int end = fmin(n, i + 2 * r + 1);
            diff[end] -= add;
            sum += add;
        }
    }
    free(diff);
    return true;
}

long long maxPower(int* stations, int stationsSize, int r, int k) {
    int n = stationsSize;
    long long* cnt = (long long*)calloc(n + 1, sizeof(long long));

    for (int i = 0; i < n; i++) {
        int left = fmax(0, i - r);
        int right = fmin(n, i + r + 1);
        cnt[left] += stations[i];
        cnt[right] -= stations[i];
    }

    long long minStation = LLONG_MAX;
    for (int i = 0; i < n; i++) {
        if (stations[i] < minStation) {
            minStation = stations[i];
        }
    }

    long long minVal = LLONG_MAX;
    long long sumTotal = 0;
    for (int i = 0; i < n; i++) {
        if (stations[i] < minVal) {
            minVal = stations[i];
        }
        sumTotal += stations[i];
    }
    long long hi = sumTotal + k;
    long long lo = minVal;
    long long res = 0;

    while (lo <= hi) {
        long long mid = lo + (hi - lo) / 2;
        if (check(cnt, r, k, mid, n)) {
            res = mid;
            lo = mid + 1;
        } else {
            hi = mid - 1;
        }
    }

    free(cnt);
    return res;
}
```

```JavaScript
var maxPower = function(stations, r, k) {
    const n = stations.length;
    const cnt = new Array(n + 1).fill(0);

    for (let i = 0; i < n; i++) {
        const left = Math.max(0, i - r);
        const right = Math.min(n, i + r + 1);
        cnt[left] += stations[i];
        cnt[right] -= stations[i];
    }

    const check = (val) => {
        const diff = [...cnt];
        let sum = 0;
        let remaining = k;

        for (let i = 0; i < n; i++) {
            sum += diff[i];
            if (sum < val) {
                const add = val - sum;
                if (remaining < add) {
                    return false;
                }
                remaining -= add;
                const end = Math.min(n, i + 2 * r + 1);
                diff[end] -= add;
                sum += add;
            }
        }
        return true;
    };

    let lo = Math.min(...stations);
    let hi = stations.reduce((a, b) => a + b, 0) + k;
    let res = 0;

    while (lo <= hi) {
        const mid = Math.floor(lo + (hi - lo) / 2);
        if (check(mid)) {
            res = mid;
            lo = mid + 1;
        } else {
            hi = mid - 1;
        }
    }
    return res;
};
```

```TypeScript
function maxPower(stations: number[], r: number, k: number): number {
    const n: number = stations.length;
    const cnt: number[] = new Array(n + 1).fill(0);

    for (let i = 0; i < n; i++) {
        const left: number = Math.max(0, i - r);
        const right: number = Math.min(n, i + r + 1);
        cnt[left] += stations[i];
        cnt[right] -= stations[i];
    }

    const check = (val: number): boolean => {
        const diff: number[] = [...cnt];
        let sum: number = 0;
        let remaining: number = k;

        for (let i = 0; i < n; i++) {
            sum += diff[i];
            if (sum < val) {
                const add: number = val - sum;
                if (remaining < add) {
                    return false;
                }
                remaining -= add;
                const end: number = Math.min(n, i + 2 * r + 1);
                diff[end] -= add;
                sum += add;
            }
        }
        return true;
    };

    let lo: number = Math.min(...stations);
    let hi: number = stations.reduce((a, b) => a + b, 0) + k;
    let res: number = 0;

    while (lo <= hi) {
        const mid: number = Math.floor(lo + (hi - lo) / 2);
        if (check(mid)) {
            res = mid;
            lo = mid + 1;
        } else {
            hi = mid - 1;
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn max_power(stations: Vec<i32>, r: i32, k: i32) -> i64 {
        let n = stations.len();
        let mut cnt = vec![0i64; n + 1];

        for i in 0..n {
            let left = (0).max(i as i32 - r) as usize;
            let right = (n as i32).min(i as i32 + r + 1) as usize;
            cnt[left] += stations[i] as i64;
            cnt[right] -= stations[i] as i64;
        }

        let min_val = *stations.iter().min().unwrap() as i64;
        let sum_total = stations.iter().map(|&x| x as i64).sum::<i64>();
        let mut hi = sum_total + k as i64;
        let mut lo = min_val;
        let mut res = 0;

        while lo <= hi {
            let mid = lo + (hi - lo) / 2;
            if Self::check(&cnt, mid, r, k as i64) {
                res = mid;
                lo = mid + 1;
            } else {
                hi = mid - 1;
            }
        }
        res
    }

    fn check(cnt: &[i64], val: i64, r: i32, k: i64) -> bool {
        let n = cnt.len() - 1;
        let mut diff = cnt.to_vec();
        let mut sum = 0i64;
        let mut remaining = k;

        for i in 0..n {
            sum += diff[i];
            if sum < val {
                let add = val - sum;
                if remaining < add {
                    return false;
                }
                remaining -= add;
                let end = (n as i32).min(i as i32 + 2 * r + 1) as usize;
                diff[end] -= add;
                sum += add;
            }
        }
        true
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log D)$，其中 $n$ 为数组 $stations$ 的长度，$D=sum(stations)+k$。计算差分数组需要的时间为 $O(n)$，二分查找最小电量的最大值的上限即为 $D=sum(stations)+k$，二分查找每次检测需要的时间为 $O(n)$，因此总的时间复杂度即为 $O(n\log D)$。
- 空间复杂度：$O(n)$，其中 $n$ 为数组 $stations$ 的长度。计算差分数组需要的空间为 $O(n)$。
