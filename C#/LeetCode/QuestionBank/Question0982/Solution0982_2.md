#### [方法一：枚举](https://leetcode.cn/problems/triples-with-bitwise-and-equal-to-zero/solutions/2144239/an-wei-yu-wei-ling-de-san-yuan-zu-by-lee-gjud/)

**思路与算法**

最容易想到的做法是使用三重循环枚举三元组 $(i,j,k)$，再判断 $nums[i] ~\&~ nums[j] ~\&~ nums[k]$ 的值是否为 $0$。但这样做的时间复杂度是 $O(n^3)$，其中 $n$ 是数组 $nums$ 的长度，会超出时间限制。

注意到题目中给定了一个限制：数组 $nums$ 的元素不会超过 $2^{16}$。这说明，$nums[i] ~\&~ nums[j]$ 的值也不会超过 $2^{16}$。因此，我们可以首先使用二重循环枚举 $i$ 和 $j$，并使用一个长度为 $2^{16}$ 的数组（或哈希表）存储每一种 $nums[i] ~\&~ nums[j]$ 以及它出现的次数。随后，我们再使用二重循环，其中的一重枚举记录频数的数组，另一重枚举 $k$，这样就可以将时间复杂度从 $O(n^3)$ 降低至 $O(n^2 + 2^{16} \cdot n)$。

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
            for (int mask = 0; mask < (1 << 16); ++mask) {
                if ((x & mask) == 0) {
                    ans += cnt[mask];
                }
            }
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
            for (int mask = 0; mask < (1 << 16); ++mask) {
                if ((x & mask) == 0) {
                    ans += cnt[mask];
                }
            }
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
            for (int mask = 0; mask < (1 << 16); ++mask) {
                if ((x & mask) == 0) {
                    ans += cnt[mask];
                }
            }
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
            for mask, freq in cnt.items():
                if (x & mask) == 0:
                    ans += freq
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
        int x = nums[i];
        for (int mask = 0; mask < (1 << 16); ++mask) {
            if ((x & mask) == 0) {
                ans += cnt[mask];
            }
        }
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
    for (const x of nums) {
        for (let mask = 0; mask < (1 << 16); ++mask) {
            if ((x & mask) === 0) {
                ans += cnt[mask];
            }
        }
    }
    return ans;
};
```

```go
func countTriplets(nums []int) int {
    cnt := make(map[int]int)
    for i := range nums {
        for j := range nums {
            cnt[nums[i]&nums[j]]++
        }
    }
    res := 0
    for i := range nums {
        for k, v := range cnt {
            if k&nums[i] == 0 {
                res += v
            }
        }
    }
    return res
}
```

**复杂度分析**

-   时间复杂度：$O(n^2 + C \cdot n)$，其中 $n$ 是数组 $nums$ 的长度，$C$ 是数组 $nums$ 中的元素范围，在本题中 $C = 2^{16}$。
-   空间复杂度：$O(C)$，即为数组（或哈希表）需要使用的空间。
