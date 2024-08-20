### [到达第 K 级台阶的方案数](https://leetcode.cn/problems/find-number-of-ways-to-reach-the-k-th-stair/solutions/2885433/dao-da-di-k-ji-tai-jie-de-fang-an-shu-by-6u59/)

#### 方法一：枚举向上走的次数

**思路与算法**

我们称向下走为操作 $1$，向上走为操作 $2$。

由于操作 $1$ 不能连续使用，因此我们可以将每一种方案看成进行了 $n$ 次操作 $2$，其中有 $n+1$ 个间隔（每两次操作 $2$ 之间，第一次操作 $2$ 之前以及最后一次操作 $2$ 之后），每个间隔可以最多 $1$ 次操作 $1$。由于 $n$ 次操作 $2$ 会向上走

$$\sum\limits_{i = 0}^{n-1} 2^i = 2^n-1$$

步，而操作 $1$ 是向下走一步，因此在进行了 $n$ 次操作 $2$ 的情况下，最终向上走的台阶数范围是：

$$[2^n-n-2,2^n-1]$$

由于一开始在第 $1$ 层，那么最终到达的位置范围是：

$$[2^n-n-1,2^n]$$

因此，我们就可以枚举 $n$，当 $k$ 落在上述区间内时，我们需要进行 $2^n-k$ 次操作 $1$，根据组合数，方案数为 $\left(\begin{array}{c}n+1 \\ 2^n-k\end{array}\right)$。

**细节**

在本题中 $k \le 10^9$。当 $n = 30$ 时，$2^n-n-1$ 已经超过 $k$ 的最大值，因此只需要在 $n \in [0,30]$ 的范围内进行枚举，枚举的时间复杂度为 $O(n) = O(logk)$。同时组合数 $\left(\begin{array}{c}n+1 \\ 2^n-k\end{array}\right)$ 也不会很大，可以直接使用定义进行计算，单次时间复杂度同样为 $O(logk)$。

位置范围 $[2^n-n-1,2^n]$ 中的左边界 $2^n-n-1$ 是单调递增的，因此当左边界大于 $k$ 时就可以结束枚举。

当 $n$ 较大时，相邻的两个区间 $[2^n-n-1,2^n]$ 和 $[2^n+1-n,2^n+1]$ 实际上没有交集，因此：

- 对于较小的 $k$，它会落在 $O(1)$ 个区间内；
- 对于较大的 $k$，它最多只会落在某一个区间内。

这使得我们可以将枚举的时间复杂度也降低至 $O(1)$：找到最大的满足 $2^n<k$ 的 $n$，随后从下一个区间开始枚举。但这样做的用处并不大，因为：

- 不是所有语言提供的 API 都可以 $O(1)$ 快速找出上述的 $n$：很多语言提供的 API 的时间复杂度是 $O(logk)$ 或者 $O(loglogk)$ 的；
- 单次计算组合数已经需要 $O(logk)$ 的时间。

因此下面给出的代码只会在左边界大于 $k$ 时结束枚举，由于只需要计算 $O(1)$ 次组合数，因此枚举和组合数计算的时间是独立的，总时间复杂度仍然为 $O(logk)$。

**代码**

```C++
class Solution {
public:
    int waysToReachStair(int k) {
        auto comb = [](int n, int k) -> int {
            long long ans = 1;
            for (int i = n; i >= n - k + 1; --i) {
                ans *= i;
                ans /= n - i + 1;
            }
            return ans;
        };

        int n = 0, npow = 1, ans = 0;
        while (true) {
            if (npow - n - 1 <= k && k <= npow) {
                ans += comb(n + 1, npow - k);
            }
            else if (npow - n - 1 > k) {
                break;
            }
            ++n;
            npow *= 2;
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int waysToReachStair(int k) {
        int n = 0, npow = 1, ans = 0;
        while (true) {
            if (npow - n - 1 <= k && k <= npow) {
                ans += comb(n + 1, npow - k);
            } else if (npow - n - 1 > k) {
                break;
            }
            ++n;
            npow *= 2;
        }
        return ans;
    }

    public int comb(int n, int k) {
        long ans = 1;
        for (int i = n; i >= n - k + 1; --i) {
            ans *= i;
            ans /= n - i + 1;
        }
        return (int) ans;
    }
}
```

```CSharp
public class Solution {
    public int WaysToReachStair(int k) {
        int n = 0, npow = 1, ans = 0;
        while (true) {
            if (npow - n - 1 <= k && k <= npow) {
                ans += Comb(n + 1, npow - k);
            } else if (npow - n - 1 > k) {
                break;
            }
            ++n;
            npow *= 2;
        }
        return ans;
    }

    public int Comb(int n, int k) {
        long ans = 1;
        for (int i = n; i >= n - k + 1; --i) {
            ans *= i;
            ans /= n - i + 1;
        }
        return (int) ans;
    }
}
```

```Python
class Solution:
    def waysToReachStair(self, k: int) -> int:
        n, npow, ans = 0, 1, 0
        while True:
            if npow - n - 1 <= k <= npow:
                ans += comb(n + 1, npow - k)
            elif npow - n - 1 > k:
                break
            n += 1
            npow *= 2
        return ans
```

```C
int comb(int n, int k) {
    long long ans = 1;
    for (int i = n; i >= n - k + 1; --i) {
        ans *= i;
        ans /= n - i + 1;
    }
    return ans;
}

int waysToReachStair(int k) {
    int n = 0, npow = 1, ans = 0;
    while (1) {
        if (npow - n - 1 <= k && k <= npow) {
            ans += comb(n + 1, npow - k);
        }
        else if (npow - n - 1 > k) {
            break;
        }
        ++n;
        npow *= 2;
    }
    return ans;
}
```

```Go
func waysToReachStair(k int) int {
    n, npow, ans := 0, 1, 0
    for {
        if npow - n - 1 <= k && k <= npow {
            ans += comb(n + 1, npow - k)
        } else if npow - n - 1 > k {
            break
        }
        n++
        npow *= 2
    }
    return ans
}

func comb(n, k int) int {
    ans := 1
    for i := n; i >= n-k+1; i-- {
        ans *= i
        ans /= n - i + 1
    }
    return ans
}
```

```JavaScript
var waysToReachStair = function(k) {
    let n = 0, npow = 1, ans = 0;
    while (true) {
        if (npow - n - 1 <= k && k <= npow) {
            ans += comb(n + 1, npow - k);
        } else if (npow - n - 1 > k) {
            break;
        }
        n++;
        npow *= 2;
    }
    return ans;
};

function comb(n, k) {
    let ans = 1;
    for (let i = n; i >= n - k + 1; --i) {
        ans *= i;
        ans /= n - i + 1;
    }
    return ans;
}
```

```TypeScript
function waysToReachStair(k: number): number {
    let n = 0, npow = 1, ans = 0;
    while (true) {
        if (npow - n - 1 <= k && k <= npow) {
            ans += comb(n + 1, npow - k);
        } else if (npow - n - 1 > k) {
            break;
        }
        n++;
        npow *= 2;
    }
    return ans;
};

function comb(n: number, k: number): number {
    let ans = 1;
    for (let i = n; i >= n - k + 1; --i) {
        ans *= i;
        ans /= n - i + 1;
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn ways_to_reach_stair(k: i32) -> i32 {
        let mut n = 0;
        let mut npow = 1;
        let mut ans = 0;
        loop {
            if npow - n - 1 <= k && k <= npow {
                ans += Self::comb(n + 1, npow - k);
            } else if npow - n - 1 > k {
                break;
            }
            n += 1;
            npow *= 2;
        }
        ans
    }

    fn comb(n: i32, k: i32) -> i32 {
        let mut ans: i64 = 1;
        for i in (n - k + 1..=n).rev() {
            ans *= i as i64;
            ans /= (n - i + 1) as i64;
        }
        ans as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(logk)$。
- 空间复杂度：$O(1)$。
