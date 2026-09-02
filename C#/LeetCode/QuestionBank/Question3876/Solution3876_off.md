### [构造奇偶一致的数组 II](https://leetcode.cn/problems/construct-uniform-parity-array-ii/solutions/4019000/gou-zao-qi-ou-yi-zhi-de-shu-zu-ii-by-lee-un2z/)

#### 方法一：分类讨论

**思路与算法**

本题与「[3875\. 构造奇偶一致的数组 I](https://leetcode.cn/problems/construct-uniform-parity-array-i/)」类似，但增加了一个限制条件：使用第二种操作时，必须满足 $nums_1[i]-nums_1[j]\ge 1$，即被减数必须严格大于减数。

由于只有减去奇数才会改变奇偶性（偶数减奇数得奇数，奇数减奇数得偶数），因此我们只需要关注数组中奇数的最小值。

记 $nums_1$ 的长度为 $n$，数组中的最小值为 $mn$。由于最小值无法通过减去一个更小的数来改变自身，因此 $mn$ 的奇偶性决定了 $nums_2$ 的目标奇偶性。

我们对 $nums_1$ 进行分类讨论：

1. $nums_1$ 全为偶数：此时直接令每个 $nums_2[i]=nums_1[i]$（使用第一种操作），得到的 $nums_2$ 全为偶数，满足条件。
2. $nums_1$ 全为奇数：同理，直接令每个 $nums_2[i]=nums_1[i]$，得到的 $nums_2$ 全为奇数，满足条件。
3. $nums_1$ 中既有奇数也有偶数：
    - 若 $mn$ 为奇数：我们可以将数组构造为全奇数。对于奇数位置，直接使用第一种操作；对于偶数位置，让偶数减去 $mn$（一个更小的奇数），由于偶数减奇数得奇数，且 $mn$ 是最小值，所以任何偶数减去 $mn$ 的结果都 $\ge 1$，满足题目要求。
    - 若 $mn$ 为偶数：此时无法构造出合法的 $nums_2$。因为：
        - 若目标是全偶数：奇数必须减去一个奇数才能变成偶数。但最小的那个奇数无法找到比它更小的奇数来减，因此无法改变奇偶性。
        - 若目标是全奇数：偶数 $mn$ 必须减去一个奇数才能变成奇数。但 $mn$ 是最小值，无法找到比它更小的数来减。
        两种情况均不可行，因此返回 $false$。

综上所述，我们只需要遍历一遍数组，找到最小值 $mn$，并记录是否存在奇数：

- 如果 $mn$ 是奇数，直接返回 $true$。
- 如果 $mn$ 是偶数，则只有当数组中不存在奇数时才返回 $true$，否则返回 $false$。

**代码**

```C++
class Solution {
public:
    bool uniformArray(vector<int>& nums1) {
        int mn = nums1[0];
        bool hasOdd = false;
        for (int v : nums1) {
            if (v < mn) {
                mn = v;
            }
            if (v & 1) {
                hasOdd = true;
            }
        }
        if (mn & 1) {
            return true;
        }
        return !hasOdd;
    }
};
```

```Go
func uniformArray(nums1 []int) bool {
    mn := nums1[0]
    hasOdd := false
    for _, v := range nums1 {
        if v < mn {
            mn = v
        }
        if v % 2 == 1 {
            hasOdd = true
        }
    }
    if mn % 2 == 1 {
        return true
    }
    return !hasOdd
}
```

```Python
class Solution:
    def uniformArray(self, nums1: list[int]) -> bool:
        mn = nums1[0]
        hasOdd = False
        for v in nums1:
            if v < mn:
                mn = v
            if v & 1:
                hasOdd = True
        if mn & 1:
            return True
        return not hasOdd
```

```Java
class Solution {
    public boolean uniformArray(int[] nums1) {
        int mn = nums1[0];
        boolean hasOdd = false;
        for (int v : nums1) {
            if (v < mn) {
                mn = v;
            }
            if ((v & 1) == 1) {
                hasOdd = true;
            }
        }
        if ((mn & 1) == 1) {
            return true;
        }
        return !hasOdd;
    }
}
```

```TypeScript
function uniformArray(nums1: number[]): boolean {
    let mn = nums1[0];
    let hasOdd = false;
    for (const v of nums1) {
        if (v < mn) {
            mn = v;
        }
        if (v & 1) {
            hasOdd = true;
        }
    }
    if (mn & 1) {
        return true;
    }
    return !hasOdd;
}
```

```JavaScript
var uniformArray = function(nums1) {
    let mn = nums1[0];
    let hasOdd = false;
    for (const v of nums1) {
        if (v < mn) {
            mn = v;
        }
        if (v & 1) {
            hasOdd = true;
        }
    }
    if (mn & 1) {
        return true;
    }
    return !hasOdd;
};
```

```CSharp
public class Solution {
    public bool UniformArray(int[] nums1) {
        int mn = nums1[0];
        bool hasOdd = false;
        foreach (int v in nums1) {
            if (v < mn) {
                mn = v;
            }
            if ((v & 1) == 1) {
                hasOdd = true;
            }
        }
        if ((mn & 1) == 1) {
            return true;
        }
        return !hasOdd;
    }
}
```

```C
bool uniformArray(int* nums1, int nums1Size) {
    int mn = nums1[0];
    bool hasOdd = false;
    for (int i = 0; i < nums1Size; i++) {
        int v = nums1[i];
        if (v < mn) {
            mn = v;
        }
        if (v & 1) {
            hasOdd = true;
        }
    }
    if (mn & 1) {
        return true;
    }
    return !hasOdd;
}
```

```Rust
impl Solution {
    pub fn uniform_array(nums1: Vec<i32>) -> bool {
        let mut mn = nums1[0];
        let mut has_odd = false;
        for &v in &nums1 {
            if v < mn {
                mn = v;
            }
            if (v & 1) == 1 {
                has_odd = true;
            }
        }
        if (mn & 1) == 1 {
            return true;
        }
        return !has_odd;
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums_1$ 的长度。我们只需要遍历数组一次，找到最小值和判断是否存在奇数。
- 空间复杂度：$O(1)$。仅使用常数级额外空间。
