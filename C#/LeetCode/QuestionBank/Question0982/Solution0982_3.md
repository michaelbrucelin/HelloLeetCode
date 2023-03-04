#### [方法二：枚举 + 子集优化](https://leetcode.cn/problems/triples-with-bitwise-and-equal-to-zero/solutions/2144239/an-wei-yu-wei-ling-de-san-yuan-zu-by-lee-gjud/)

**思路与算法**

在方法一的第二个二重循环中，我们需要枚举 $[0, 2^{16})$ 中的所有整数。即使我们使用哈希表代替数组，在数据随机的情况下，$nums[i] ~\&~ nums[j]$ 也会覆盖 $[0, 2^{16})$ 中的大部分整数，使得哈希表不会有明显更好的表现。

这里我们介绍另一个常数级别的优化。当我们在第二个二重循环中枚举 $k$ 时，我们希望统计出所有与 $nums[k]$ 按位与为 $0$ 的二元组数量。也就是说：

> 如果 $nums[k]$ 的第 $t$ 个二进制位是 $0$，那么二元组的第 $t$ 个二进制位才可以是 $1$，否则**一定不能**是 $1$。

因此，我们可以将 $nums[k]$ 与 $2^{16}-1$（即二进制表示下的 $16$ 个 $1$）进行按位异或运算。这样一来，满足要求的二元组的二进制表示中包含的 $1$ 必须是该数的**子集**，例如该数是 $(100111)_2$，那么满足要求的二元组可以是 $(100010)_2$ 或者 $(000110)_2$，但不能是 $(010001)_2$。

此时，要想得到所有该数的**子集**，我们可以使用「二进制枚举子集」的技巧。这里给出对应的步骤：

-   记该数为 $x$。我们用 $sub$ 表示当前枚举到的子集。初始时 $sub = x$，因为 $x$ 也是本身的子集；
-   我们不断地令 $sub = (sub - 1) ~\&~ x$，其中 $\&$ 表示按位与运算。这样我们就可以从大到小枚举 $x$ 的所有子集。当 $sub = 0$ 时枚举结束。

我们可以粗略估计这样做可以优化的时间复杂度：当数据随机时，$x$ 的二进制表示中期望有 $16/2=8$ 个 $1$，那么「二进制枚举子集」需要枚举 $2^8$ 次。在优化前，我们需要枚举 $2^{16}$ 次，因此常数项就缩减到原来的 $\dfrac{1}{2^8}$。但在最坏情况下，$x$ 的二进制表示有 $16$ 个 $1$，两种方法的表现没有区别。

**代码**

```cpp
class Solution {
public:
    int countTriplets(vector<int>& nums) {
        vector<int> cnt(1 << 16);
        for (int x: nums) {
            for (int y: nums) {
                ++cnt[x & y];
            }
        }
        int ans = 0;
        for (int x: nums) {
            x = x ^ 0xffff;
            for (int sub = x; sub; sub = (sub - 1) & x) {
                ans += cnt[sub];
            }
            ans += cnt[0];
        }
        return ans;
    }
};
```

```java
class Solution {
    public int countTriplets(int[] nums) {
        int[] cnt = new int[1 << 16];
        for (int x : nums) {
            for (int y : nums) {
                ++cnt[x & y];
            }
        }
        int ans = 0;
        for (int x : nums) {
            x = x ^ 0xffff;
            for (int sub = x; sub != 0; sub = (sub - 1) & x) {
                ans += cnt[sub];
            }
            ans += cnt[0];
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int CountTriplets(int[] nums) {
        int[] cnt = new int[1 << 16];
        foreach (int x in nums) {
            foreach (int y in nums) {
                ++cnt[x & y];
            }
        }
        int ans = 0;
        foreach (int x in nums) {
            int y = x ^ 0xffff;
            for (int sub = y; sub != 0; sub = (sub - 1) & y) {
                ans += cnt[sub];
            }
            ans += cnt[0];
        }
        return ans;
    }
}
```

```python
class Solution:
    def countTriplets(self, nums: List[int]) -> int:
        cnt = Counter((x & y) for x in nums for y in nums)
        
        ans = 0
        for x in nums:
            sub = x = x ^ 0xffff
            while True:
                if sub in cnt:
                    ans += cnt[sub]
                if sub == 0:
                    break
                sub = (sub - 1) & x
        
        return ans
```

```c
int countTriplets(int* nums, int numsSize) {
    int *cnt = (int *)calloc(sizeof(int), 1 << 16);
    for (int i = 0; i < numsSize; i++) {
        int x = nums[i];
        for (int j = 0; j < numsSize; j++) {
            int y = nums[j];
            ++cnt[x & y];
        }
    }
    int ans = 0;
    for (int i = 0; i < numsSize; i++) {
        int x = nums[i] ^ 0xffff;
        for (int sub = x; sub; sub = (sub - 1) & x) {
            ans += cnt[sub];
        }
        ans += cnt[0];
    }
    free(cnt);
    return ans;
}
```

```javascript
var countTriplets = function(nums) {
    const cnt = new Array(1 << 16).fill(0);
    for (const x of nums) {
        for (const y of nums) {
            ++cnt[x & y];
        }
    }
    let ans = 0;
    for (let x of nums) {
        x = x ^ 0xffff;
        for (let sub = x; sub !== 0; sub = (sub - 1) & x) {
            ans += cnt[sub];
        }
        ans += cnt[0];
    }
    return ans;
};
```

```go
func countTriplets(nums []int) int {
    var cnt [1 << 16]int
    for i := range nums {
        for j := range nums {
            cnt[nums[i]&nums[j]]++
        }
    }
    res := 0
    for i := range nums {
        x := nums[i] ^ 0xffff
        for sub := x; sub > 0; sub = (sub - 1) & x {
            res += cnt[sub]
        }
        res += cnt[0]
    }
    return res
}
```

**复杂度分析**

-   时间复杂度：$O(n^2 + C \cdot n)$，其中 $n$ 是数组 $nums$ 的长度，$C$ 是数组 $nums$ 中的元素范围，在本题中 $C = 2^{16}$。
-   空间复杂度：$O(C)$，即为数组（或哈希表）需要使用的空间。
