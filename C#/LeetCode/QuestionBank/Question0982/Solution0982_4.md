#### [有技巧的枚举 + 常数优化（Python/Java/C++/Go）](https://leetcode.cn/problems/triples-with-bitwise-and-equal-to-zero/solutions/2145654/you-ji-qiao-de-mei-ju-chang-shu-you-hua-daxit/)

暴力枚举 $i,j,k$ 的话，时间复杂度是 $O(n^3)$ 的，如何优化呢？

对于 $num[k]$ 来说，其实它只需要知道它 $AND$ 一个数的结果是否等于 $0$，至于这个数具体是由哪些 $num[i] \ AND \ num[j]$ 得到的，并不重要。

因此，可以先写一个 $O(n^2)$ 的枚举，预处理所有 $num[i] \ AND \ num[j]$ 的出现次数，存到一个哈希表（或者数组）$cnt$ 中。然后枚举 $num[k]$ 和 $x$，如果 $num[k] \ AND \ x$ 等于 $0$，那就把 $cnt[x]$ 加到答案中。

枚举哪些 $x$ 呢？第一种做法是直接枚举。

用哈希表实现的 $cnt$ 要枚举所有 key；用数组实现的 $cnt$ 要枚举区间 $[0,2^{16})$ 内的所有数（根据题目的数据范围得出）。

```python
class Solution:
    def countTriplets(self, nums: List[int]) -> int:
        cnt = Counter(x & y for x in nums for y in nums)
        return sum(c for x, c in cnt.items() for y in nums if x & y == 0)
```

```java
class Solution {
    public int countTriplets(int[] nums) {
        int[] cnt = new int[1 << 16];
        for (int x : nums)
            for (int y : nums)
                ++cnt[x & y];
        int ans = 0;
        for (int x : nums)
            for (int y = 0; y < 1 << 16; ++y)
                if ((x & y) == 0)
                    ans += cnt[y];
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int countTriplets(vector<int> &nums) {
        int cnt[1 << 16]{};
        for (int x : nums)
            for (int y : nums)
                ++cnt[x & y];
        int ans = 0;
        for (int x : nums)
            for (int y = 0; y < 1 << 16; ++y)
                if ((x & y) == 0)
                    ans += cnt[y];
        return ans;
    }
};
```

```go
func countTriplets(nums []int) (ans int) {
    cnt := [1 << 16]int{}
    for _, x := range nums {
        for _, y := range nums {
            cnt[x&y]++
        }
    }
    for x, c := range cnt {
        for _, y := range nums {
            if x&y == 0 {
                ans += c
            }
        }
    }
    return
}
```

如果把二进制数看成集合的话，二进制从低到高第 $i$ 位为 $1$ 表示 $i$ 在集合中，为 $0$ 表示 $i$ 不在集合中，例如 $a=1101_{(2)}$ 表示集合 $A=\{0,2,3\}$。

那么 $a \ AND \ b = 0$ 相当于集合 $A$ 和集合 $B$ 没有交集，也可以理解成 $B$ 是 $\complement_{U}A$ 的子集，这里 $U=\{0,1,2,\cdots,15\}$，对应的数字就是 $0xffff$。一个数异或 $0xffff$ 就可以得到这个数的补集了。

因此，上面的代码可以优化成枚举 $m=num[k] \oplus 0xffff$ 的子集。

怎么枚举 $m$ 的子集 $s$ 呢？可以从 $m$ 不断减一，直到 $0$，如果 $s \ AND \ m = s$ 就表示 $s$ 是 $m$ 的子集。

更高效的做法是直接「跳到」下一个子集，即 $s$ 更新为 $(s-1) \ AND \ m$。这样做的正确性在于，$s-1$ 仅仅把 $s$ 最低位的 $1$ 改成了 $0$，比这个 $1$ 更低的 $0$ 全部改成了 $1$，因此下一个子集一定是 $s-1$ 的子集，直接 $AND \ m$，就能得到下一个子集了。

最后，当 $s=0$ 时，由于 $-1$ 的二进制全为 $1$，所以 $(s-1) \ AND \ m = m$，因此我们可以通过判断下一个子集是否又回到 $m$，来判断是否要退出循环。

> 注：这一技巧经常用于子集状压 DP 中。

```python
class Solution:
    def countTriplets(self, nums: List[int]) -> int:
        cnt = [0] * (1 << 16)
        for x in nums:
            for y in nums:
                cnt[x & y] += 1
        ans = 0
        for m in nums:
            m ^= 0xffff
            s = m
            while True:  # 枚举 m 的子集（包括空集）
                ans += cnt[s]
                s = (s - 1) & m
                if s == m: break
        return ans
```

```java
class Solution {
    public int countTriplets(int[] nums) {
        int[] cnt = new int[1 << 16];
        for (int x : nums)
            for (int y : nums)
                ++cnt[x & y];
        int ans = 0;
        for (int m : nums) {
            m ^= 0xffff;
            int s = m;
            do { // 枚举 m 的子集（包括空集）
                ans += cnt[s];
                s = (s - 1) & m;
            } while (s != m);
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int countTriplets(vector<int> &nums) {
        int cnt[1 << 16]{};
        for (int x : nums)
            for (int y : nums)
                ++cnt[x & y];
        int ans = 0;
        for (int m : nums) {
            m ^= 0xffff;
            int s = m;
            do { // 枚举 m 的子集（包括空集）
                ans += cnt[s];
                s = (s - 1) & m;
            } while (s != m);
        }
        return ans;
    }
};
```

```go
func countTriplets(nums []int) (ans int) {
    cnt := [1 << 16]int{}
    for _, x := range nums {
        for _, y := range nums {
            cnt[x&y]++
        }
    }
    for _, m := range nums {
        m ^= 0xffff
        s := m
        for { // 枚举 m 的子集（包括空集）
            ans += cnt[s]
            s = (s - 1) & m
            if s == m {
                break
            }
        }
    }
    return
}
```

还可以预处理每个 $num[k]$ 的补集的子集的出现次数 $cnt$，最后累加 $cnt[num[i] \ AND \ num[j]]$。

```python
class Solution:
    def countTriplets(self, nums: List[int]) -> int:
        cnt = [0] * (1 << 16)
        cnt[0] = len(nums)  # 直接统计空集
        for m in nums:
            m ^= 0xffff
            s = m
            while s:  # 枚举 m 的非空子集
                cnt[s] += 1
                s = (s - 1) & m
        return sum(cnt[x & y] for x in nums for y in nums)
```

```java
class Solution {
    public int countTriplets(int[] nums) {
        int[] cnt = new int[1 << 16];
        cnt[0] = nums.length; // 直接统计空集
        for (int m : nums) {
            m ^= 0xffff;
            for (int s = m; s > 0; s = (s - 1) & m) // 枚举 m 的非空子集
                ++cnt[s];
        }
        int ans = 0;
        for (int x : nums)
            for (int y : nums)
                ans += cnt[x & y];
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int countTriplets(vector<int> &nums) {
        int cnt[1 << 16]{};
        cnt[0] = nums.size(); // 直接统计空集
        for (int m : nums) {
            m ^= 0xffff;
            for (int s = m; s; s = (s - 1) & m) // 枚举 m 的非空子集
                ++cnt[s];
        }
        int ans = 0;
        for (int x : nums)
            for (int y : nums)
                ans += cnt[x & y];
        return ans;
    }
};
```

```go
func countTriplets(nums []int) (ans int) {
    cnt := [1 << 16]int{len(nums)} // 直接统计空集
    for _, m := range nums {
        m ^= 0xffff
        for s := m; s > 0; s = (s - 1) & m { // 枚举 m 的非空子集
            cnt[s]++
        }
    }
    for _, x := range nums {
        for _, y := range nums {
            ans += cnt[x&y]
        }
    }
    return
}
```

再快点：仔细计算 $cnt$ 的实际大小 $u$。相应的全集就是 $u-1$。

```python
class Solution:
    def countTriplets(self, nums: List[int]) -> int:
        u = 1
        for x in nums:
            while u <= x:
                u <<= 1
        cnt = [0] * u
        cnt[0] = len(nums)  # 直接统计空集
        for m in nums:
            m ^= u - 1
            s = m
            while s:  # 枚举 m 的非空子集
                cnt[s] += 1
                s = (s - 1) & m
        return sum(cnt[x & y] for x in nums for y in nums)
```

```java
class Solution {
    public int countTriplets(int[] nums) {
        int u = 1;
        for (int x : nums)
            while (u <= x)
                u <<= 1;
        int[] cnt = new int[u];
        cnt[0] = nums.length; // 直接统计空集
        for (int m : nums) {
            m ^= u - 1;
            for (int s = m; s > 0; s = (s - 1) & m) // 枚举 m 的非空子集
                ++cnt[s];
        }
        int ans = 0;
        for (int x : nums)
            for (int y : nums)
                ans += cnt[x & y];
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int countTriplets(vector<int> &nums) {
        int u = 1;
        for (int x : nums)
            while (u <= x)
                u <<= 1;
        int cnt[u]; memset(cnt, 0, sizeof(cnt));
        cnt[0] = nums.size(); // 直接统计空集
        for (int m : nums) {
            m ^= u - 1;
            for (int s = m; s > 0; s = (s - 1) & m) // 枚举 m 的非空子集
                ++cnt[s];
        }
        int ans = 0;
        for (int x : nums)
            for (int y : nums)
                ans += cnt[x & y];
        return ans;
    }
};
```

```go
func countTriplets(nums []int) (ans int) {
    u := 1
    for _, x := range nums {
        for u <= x {
            u <<= 1
        }
    }
    cnt := make([]int, u)
    cnt[0] = len(nums) // 直接统计空集
    for _, m := range nums {
        m ^= u - 1
        for s := m; s > 0; s = (s - 1) & m { // 枚举 m 的非空子集
            cnt[s]++
        }
    }
    for _, x := range nums {
        for _, y := range nums {
            ans += cnt[x&y]
        }
    }
    return
}
```

#### 复杂度分析

-   时间复杂度：$O(n(n+U))$，其中 $n$ 为 $num$ 的长度，$U=\max(num)$。
-   空间复杂度：$O(U)$。

---

补充解释枚举子集中的 `(s-1) & m`。

枚举子集相当于一个「压缩版」的二进制减法，比如 10101 -> 10100 -> 10001 -> 10000 -> 00101 -> ...

比如 10100 -> 10001 这一步，普通的二进制减法会把最低位的 1 变成 0，这个 1 右边的 0 变成 1，即 10100 -> 10011，对于压缩版也是类似的，但它只保留在 10101 中的 1，即 10100 -> 10001。怎么保留？`& 10101` 就行。
