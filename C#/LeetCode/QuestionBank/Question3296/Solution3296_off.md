### [移山所需的最少秒数](https://leetcode.cn/problems/minimum-number-of-seconds-to-make-mountain-height-zero/solutions/3911462/yi-shan-suo-xu-de-zui-shao-miao-shu-by-l-ikvv/)

#### 方法一：二分答案

**思路与算法**

根据题目描述，如果 $t$ 秒可以使山的高度降低到 $0$，那么任何大于 $t$ 的秒数也可以。因此答案具有单调性，我们可以使用二分查找来解决本题。

对于二分查找的每一步，假设当前猜测的秒数为 $mid$，我们需要判断所有工人在 $mid$ 秒内能否将山的高度降低 $H=mountainHeight$。对于第 $i$ 个工人，他将山的高度降低 $k$ 所需的时间为：

$$workerTimes[i]\cdot (1+2+\dots +k)=workerTimes[i]\cdot\dfrac{k(k+1)}{2}$$

因此在 $mid$ 秒内，第 $i$ 个工人 $i$ 最多能将山降低的高度，是满足

$$workerTimes[i]\cdot\dfrac{k(k+1)}{2}\le mid$$

的最大正整数 $k$。

令 $work=\lfloor\dfrac{mid}{workerTimes[i]}\rfloor $，其中 $\lfloor \cdot \rfloor $ 表示下取整，则需要满足 $\dfrac{k(k+1)}{2}\le work$，利用求一元二次方程求根公式可得：

$$k=\lfloor\dfrac{-1+\sqrt{1+8\cdot work}}{2}\rfloor$$

我们将所有工人计算得到的 $k$ 值相加，如果总和大于等于 $H$，则说明 $mid$ 秒可以完成任务，应当尝试更少的时间，否则尝试更多的时间。

二分查找的下界为 $1$，上界为 $max(workerTimes)\cdot\dfrac{H(H+1)}{2}$，即最慢的工人独自完成所有工作所需的时间。

**代码**

```C++
class Solution {
public:
    long long minNumberOfSeconds(int mountainHeight, vector<int>& workerTimes) {
        int maxWorkerTimes = *max_element(workerTimes.begin(), workerTimes.end());
        long long l = 1, r = static_cast<long long>(maxWorkerTimes) * mountainHeight * (mountainHeight + 1) / 2;
        long long ans = 0;

        while (l <= r) {
            long long mid = (l + r) / 2;
            long long cnt = 0;
            for (int t: workerTimes) {
                long long work = mid / t;
                // 求最大的 k 满足 1+2+...+k <= work
                long long k = (-1.0 + sqrt(1 + work * 8)) / 2 + eps;
                cnt += k;
            }
            if (cnt >= mountainHeight) {
                ans = mid;
                r = mid - 1;
            }
            else {
                l = mid + 1;
            }
        }

        return ans;
    }

private:
    static constexpr double eps = 1e-7;
};
```

```Python
class Solution:
    def minNumberOfSeconds(self, mountainHeight: int, workerTimes: List[int]) -> int:
        maxWorkerTimes = max(workerTimes)
        l, r, ans = 1, maxWorkerTimes * mountainHeight * (mountainHeight + 1) // 2, 0
        eps = 1e-7

        while l <= r:
            mid = (l + r) // 2
            cnt = 0
            for t in workerTimes:
                work = mid // t
                # 求最大的 k 满足 1+2+...+k <= work
                k = int((-1 + ((1 + work * 8) ** 0.5)) / 2 + eps)
                cnt += k
            if cnt >= mountainHeight:
                ans = mid
                r = mid - 1
            else:
                l = mid + 1

        return ans
```

```Java
class Solution {
    private static final double EPS = 1e-7;

    public long minNumberOfSeconds(int mountainHeight, int[] workerTimes) {
        int maxWorkerTimes = 0;
        for (int t : workerTimes) {
            maxWorkerTimes = Math.max(maxWorkerTimes, t);
        }

        long l = 1;
        long r = (long) maxWorkerTimes * mountainHeight * (mountainHeight + 1) / 2;
        long ans = 0;

        while (l <= r) {
            long mid = (l + r) / 2;
            long cnt = 0;
            for (int t : workerTimes) {
                long work = mid / t;
                // 求最大的 k 满足 1+2+...+k <= work
                long k = (long)((-1.0 + Math.sqrt(1 + work * 8)) / 2 + EPS);
                cnt += k;
            }

            if (cnt >= mountainHeight) {
                ans = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }

        return ans;
    }
}
```

```CSharp
class Solution {
    private const double EPS = 1e-7;

    public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes) {
        int maxWorkerTimes = 0;
        foreach (int t in workerTimes) {
            maxWorkerTimes = Math.Max(maxWorkerTimes, t);
        }

        long l = 1;
        long r = (long)maxWorkerTimes * mountainHeight * (mountainHeight + 1) / 2;
        long ans = 0;

        while (l <= r) {
            long mid = (l + r) / 2;
            long cnt = 0;

            foreach (int t in workerTimes) {
                long work = mid / t;
                // 求最大的 k 满足 1+2+...+k <= work
                long k = (long)((-1.0 + Math.Sqrt(1 + work * 8)) / 2 + EPS);
                cnt += k;
            }

            if (cnt >= mountainHeight) {
                ans = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }

        return ans;
    }
}
```

```Go
const eps = 1e-7

func minNumberOfSeconds(mountainHeight int, workerTimes []int) int64 {
    maxWorkerTimes := 0
    for _, t := range workerTimes {
        if t > maxWorkerTimes {
            maxWorkerTimes = t
        }
    }

    l := int64(1)
    r := int64(maxWorkerTimes) * int64(mountainHeight) * int64(mountainHeight + 1) / 2
    var ans int64 = 0

    for l <= r {
        mid := (l + r) / 2
        var cnt int64 = 0

        for _, t := range workerTimes {
            work := mid / int64(t)
            // 求最大的 k 满足 1+2+...+k <= work
            k := int64((-1.0 + math.Sqrt(1 + float64(work) * 8)) / 2 + eps)
            cnt += k
        }
        if cnt >= int64(mountainHeight) {
            ans = mid
            r = mid - 1
        } else {
            l = mid + 1
        }
    }

    return ans
}
```

```C
#define EPS 1e-7

long long minNumberOfSeconds(int mountainHeight, int* workerTimes, int workerTimesSize) {
    int maxWorkerTimes = 0;
    for (int i = 0; i < workerTimesSize; i++) {
        if (workerTimes[i] > maxWorkerTimes) {
            maxWorkerTimes = workerTimes[i];
        }
    }

    long long l = 1;
    long long r = (long long)maxWorkerTimes * mountainHeight * (mountainHeight + 1) / 2;
    long long ans = 0;

    while (l <= r) {
        long long mid = (l + r) / 2;
        long long cnt = 0;
        for (int i = 0; i < workerTimesSize; i++) {
            long long work = mid / workerTimes[i];
            // 求最大的 k 满足 1+2+...+k <= work
            long long k = (long long)((-1.0 + sqrt(1 + work * 8)) / 2 + EPS);
            cnt += k;
        }

        if (cnt >= mountainHeight) {
            ans = mid;
            r = mid - 1;
        } else {
            l = mid + 1;
        }
    }

    return ans;
}
```

```JavaScript
const EPS = 1e-7;

var minNumberOfSeconds = function(mountainHeight, workerTimes) {
    const maxWorkerTimes = Math.max(...workerTimes);
    let l = 1;
    let r = maxWorkerTimes * mountainHeight * (mountainHeight + 1) / 2;
    let ans = 0;

    while (l <= r) {
        const mid = Math.floor((l + r) / 2);
        let cnt = 0;
        for (const t of workerTimes) {
            const work = Math.floor(mid / t);
            // 求最大的 k 满足 1+2+...+k <= work
            const k = Math.floor((-1.0 + Math.sqrt(1 + work * 8)) / 2 + EPS);
            cnt += k;
        }

        if (cnt >= mountainHeight) {
            ans = mid;
            r = mid - 1;
        } else {
            l = mid + 1;
        }
    }

    return ans;
}
```

```TypeScript
const EPS: number = 1e-7;

function minNumberOfSeconds(mountainHeight: number, workerTimes: number[]): number {
    const maxWorkerTimes: number = Math.max(...workerTimes);
    let l: number = 1;
    let r: number = maxWorkerTimes * mountainHeight * (mountainHeight + 1) / 2;
    let ans: number = 0;

    while (l <= r) {
        const mid: number = Math.floor((l + r) / 2);
        let cnt: number = 0;
        for (const t of workerTimes) {
            const work: number = Math.floor(mid / t);
            // 求最大的 k 满足 1+2+...+k <= work
            const k: number = Math.floor((-1.0 + Math.sqrt(1 + work * 8)) / 2 + EPS);
            cnt += k;
        }

        if (cnt >= mountainHeight) {
            ans = mid;
            r = mid - 1;
        } else {
            l = mid + 1;
        }
    }

    return ans;
}
```

```Rust
const EPS: f64 = 1e-7;

impl Solution {
    pub fn min_number_of_seconds(mountain_height: i32, worker_times: Vec<i32>) -> i64 {
        let mountain_height = mountain_height as i64;
        let max_worker_times = *worker_times.iter().max().unwrap_or(&0) as i64;

        let mut l: i64 = 1;
        let mut r: i64 = max_worker_times * mountain_height * (mountain_height + 1) / 2;
        let mut ans: i64 = 0;

        while l <= r {
            let mid = (l + r) / 2;
            let mut cnt: i64 = 0;

            for &t in &worker_times {
                let work = mid / t as i64;
                // 求最大的 k 满足 1+2+...+k <= work
                let k = ((-1.0 + (1.0 + (work as f64) * 8.0).sqrt()) / 2.0 + EPS) as i64;
                cnt += k;
            }

            if cnt >= mountain_height {
                ans = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log (MH^2))$，其中 $n$ 是数组 $workerTimes$ 的长度，$M$ 是数组 $workerTimes$ 中的最大值，$H$ 是 $mountainHeight$。二分查找需要 $O(\log (MH^2))$ 次迭代，每次迭代遍历所有工人，需要 $O(n)$ 的时间。
- 空间复杂度：$O(1)$。
