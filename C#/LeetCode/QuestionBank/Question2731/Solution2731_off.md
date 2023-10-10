### [移动机器人](https://leetcode.cn/problems/movement-of-robots/solutions/2470646/yi-dong-ji-qi-ren-by-leetcode-solution-tm4n/)

#### 方法一：脑筋急转弯 + 排序

**思路与算法**

当两个机器人相撞时，它们会沿着原本相反的方向移动。由于机器人之间并没有任何区别，相撞可以看做是穿透，原本左边的机器人相撞后交换为右边的机器人，原本右边的机器人相撞后交换为左边的机器人，这样一来，两个机器人仿佛没有相撞过。因此，我们可以无视相撞，独立计算每个机器人 $d$ 秒后所处的位置。

记第 $i$ 个机器人 $d$ 秒后的位置是 $pos[i]$，对 $pos$ 数组进行排序，然后再计算两两之间的距离。

从小到大枚举 $pos[i]$，此时左边有 $i$ 个数字，右边有 $n - i$ 个数字（算上 $pos[i]$），所以共有 $i \times (n - i)$ 对数字在计算距离时会累加 $pos[i] - pos[i - 1]$。我们依次遍历完 $[1, n - 1]$ 范围内所有的 $pos[i]$，将 $(pos[i] - pos[i - 1]) \times i \times (n - i)$ 累加到答案中即可。

需要注意的是，计算 $pos[i]$ 时不能进行取模，取模会破坏 $pos$ 间的大小关系，导致计算答案时 $i \times (n - i)$ 无法乘上正确的距离。

**代码**

```cpp
class Solution {
public:
    static constexpr int mod = 1e9 + 7;
    int sumDistance(vector<int>& nums, string s, int d) {
        int n = nums.size();
        vector<long long> pos(n);
        for (int i = 0; i < n; i++) {
            if (s[i] == 'L') {
                pos[i] = (long long) nums[i] - d;
            } else {
                pos[i] = (long long) nums[i] + d;
            }
        }
        sort(pos.begin(), pos.end());
        long long res = 0;
        for (int i = 1; i < n; i++) {
            res += 1ll * (pos[i] - pos[i - 1]) * i % mod * (n - i) % mod;
            res %= mod;
        }
        return res;
    }
};
```

```java
class Solution {
    static final int MOD = 1000000007;

    public int sumDistance(int[] nums, String s, int d) {
        int n = nums.length;
        long[] pos = new long[n];
        for (int i = 0; i < n; i++) {
            if (s.charAt(i) == 'L') {
                pos[i] = (long) nums[i] - d;
            } else {
                pos[i] = (long) nums[i] + d;
            }
        }
        Arrays.sort(pos);
        long res = 0;
        for (int i = 1; i < n; i++) {
            res += 1L * (pos[i] - pos[i - 1]) * i % MOD * (n - i) % MOD;
            res %= MOD;
        }
        return (int) res;
    }
}
```

```csharp
public class Solution {
    const int MOD = 1000000007;

    public int SumDistance(int[] nums, string s, int d) {
        int n = nums.Length;
        long[] pos = new long[n];
        for (int i = 0; i < n; i++) {
            if (s[i] == 'L') {
                pos[i] = (long) nums[i] - d;
            } else {
                pos[i] = (long) nums[i] + d;
            }
        }
        Array.Sort(pos);
        long res = 0;
        for (int i = 1; i < n; i++) {
            res += 1L * (pos[i] - pos[i - 1]) * i % MOD * (n - i) % MOD;
            res %= MOD;
        }
        return (int) res;
    }
}
```

```c
const long long mod = 1e9 + 7;

static int cmp(const void *a, const void *b) {
    long long x = *(long long *)a;
    long long y = *(long long *)b;
    return x <= y ? -1 : 1;
}

int sumDistance(int* nums, int numsSize, char * s, int d) {
    int n = numsSize;
    long long pos[n];
    for (int i = 0; i < n; i++) {
        pos[i] = s[i] == 'L' ? (long long) nums[i] - d : (long long) nums[i] + d;
    }
    qsort(pos, n, sizeof(long long), cmp);
    long long res = 0;
    for (int i = 1; i < n; i++) {
        res += 1ll * (pos[i] - pos[i - 1]) * i % mod * (n - i) % mod;
        res %= mod;
    }
    return res;
}
```

```go
func sumDistance(nums []int, s string, d int) int {
    const mod int = 1e9 + 7
    n := len(nums)
    pos := make([]int, n)
    for i, ch := range s {
        if ch == 'L' {
            pos[i] = nums[i] - d
        } else {
            pos[i] = nums[i] + d
        }
    }
    sort.Ints(pos)
    res := 0
    for i := 1; i < n; i++ {
        res += (pos[i] - pos[i - 1]) * i % mod * (n - i) % mod
        res %= mod
    }
    return res
}
```

```python
class Solution:
    def sumDistance(self, nums: List[int], s: str, d: int) -> int:
        mod = 10**9 + 7
        n = len(nums)
        pos = [nums[i] - d if s[i] == 'L' else nums[i] + d for i in range(n)]
        pos.sort()
        return sum([(pos[i] - pos[i - 1]) * i * (n - i) for i in range(1, n)]) % mod
```

```javascript
var sumDistance = function(nums, s, d) {
    const mod = 1e9 + 7;
    n = nums.length;
    pos = new Array(n).fill(0);
    for (let i = 0; i < n; i++) {
        pos[i] = s[i] === 'L' ? nums[i] - d : nums[i] + d;
    }
    pos.sort((a, b) => a - b);
    let res = 0;
    for (let i = 1; i < n; i++) {
        res += (pos[i] - pos[i - 1]) * i % mod * (n - i) % mod;
        res %= mod;
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(n\log n)$，其中 $n$ 为 $nums$ 的长度。对 $pos$ 数组进行排序的时间复杂度为 $O(n\log n)$。
-   空间复杂度：$O(n)$。使用 $pos$ 数组的空间复杂度为 $O(n)$，对其进行排序的空间复杂度为 $O(\log n)$。
