#### [前言](https://leetcode.cn/problems/check-if-it-is-a-good-array/solutions/2110763/jian-cha-hao-shu-zu-by-leetcode-solution-qg2h/)

本题解涉及到数论中的「裴蜀定理」（具体证明可参考[「裴蜀定理」百度百科](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E8%A3%B4%E8%9C%80%E5%AE%9A%E7%90%86%2F5186593)）。

「裴蜀定理」的内容为：对于不全为零的任意整数 $a$ 和 $b$，记 $g = \gcd(a,b)$，其中 $\gcd(a, b)$ 为 $a$ 和 $b$ 的最大公约数，则对于任意整数 $x$ 和 $y$ 都满足 $a \times x + b \times y$ 是 $g$ 的倍数，特别地，存在整数 $x$ 和 $y$ 满足 $a \times x + b \times y = g$。

「裴蜀定理」也可以推广到多个整数的情况。对于不全为零的任意 $n$ 个整数 $a_1, a_2, \dots a_n$，记这 $n$ 个数的最大公约数为 $g$，则对于任意 $n$ 个整数 $x_1, x_2, \dots x_n$ 都满足 $\sum_{i = 1}^n a_i \times x_i$ 是 $g$ 的倍数。一个重要的推论是：正整数 $a_1$ 到 $a_n$ 的最大公约数是 $1$ 的充分必要条件是存在 $n$ 个整数 $x_1$ 到 $x_n$ 满足 $\sum_{i = 1}^n a_i \times x_i = 1$。

#### [方法一：数论](https://leetcode.cn/problems/check-if-it-is-a-good-array/solutions/2110763/jian-cha-hao-shu-zu-by-leetcode-solution-qg2h/)

**思路与算法**

题目给出一个正整数数组 $nums$，现在我们需要从中任选一些子集，然后将子集中的每一个数都乘以一个任意整数并求出他们的和，如果该和的结果为 $1$，那么原数组就是一个「好数组」。现在我们需要判断数组 $nums$ 是否是一个「好数组」。由「裴蜀定理」可得，题目等价于求 $nums$ 中的全部数字的最大公约数是否等于 $1$，若等于 $1$ 则原数组为「好数组」，否则不是。

求 $nums$ 中全部数字的最大公约数的方法为，我们设初始为 $x=nums[0]$，然后对于每一个数 $nums[i]$，$0 < i < n$，我们更新 $x = \gcd(x, nums[i])$。遍历完全部数字后，$x$ 即为数组 $nums$ 中全部的元素的最大公约数。然后判断其是否等于 $1$ 即可。在实现过程中我们也可以进一步做优化：如果遍历过程中出现最大公约数等于 $1$ 的情况，则由于 $1$ 和任何正整数的最大公约数都是 $1$，此时可以提前结束遍历。

**代码**

```python
class Solution:
    def isGoodArray(self, nums: List[int]) -> bool:
        return reduce(gcd, nums) == 1
```

```java
class Solution {
    public boolean isGoodArray(int[] nums) {
        int divisor = nums[0];
        for (int num : nums) {
            divisor = gcd(divisor, num);
            if (divisor == 1) {
                break;
            }
        }
        return divisor == 1;
    }

    public int gcd(int num1, int num2) {
        while (num2 != 0) {
            int temp = num1;
            num1 = num2;
            num2 = temp % num2;
        }
        return num1;
    }
}
```

```csharp
public class Solution {
    public bool IsGoodArray(int[] nums) {
        int divisor = nums[0];
        foreach (int num in nums) {
            divisor = GCD(divisor, num);
            if (divisor == 1) {
                break;
            }
        }
        return divisor == 1;
    }

    public int GCD(int num1, int num2) {
        while (num2 != 0) {
            int temp = num1;
            num1 = num2;
            num2 = temp % num2;
        }
        return num1;
    }
}
```

```cpp
class Solution {
public:
    bool isGoodArray(vector<int>& nums) {
        int divisor = nums[0];
        for (int num : nums) {
            divisor = gcd(divisor, num);
            if (divisor == 1) {
                break;
            }
        }
        return divisor == 1;
    }
};
```

```c
int gcd(int num1, int num2) {
    while (num2 != 0) {
        int temp = num1;
        num1 = num2;
        num2 = temp % num2;
    }
    return num1;
}

bool isGoodArray(int* nums, int numsSize) {
    int divisor = nums[0];
    for (int i = 0; i < numsSize; i++) {
        divisor = gcd(divisor, nums[i]);
        if (divisor == 1) {
            break;
        }
    }
    return divisor == 1;
}
```

```javascript
var isGoodArray = function(nums) {
    let divisor = nums[0];
    for (const num of nums) {
        divisor = gcd(divisor, num);
        if (divisor === 1) {
            break;
        }
    }
    return divisor === 1;
}

const gcd = (num1, num2) => {
    while (num2 !== 0) {
        const temp = num1;
        num1 = num2;
        num2 = temp % num2;
    }
    return num1;
};
```

```go
func isGoodArray(nums []int) bool {
    g := 0
    for _, x := range nums {
        g = gcd(g, x)
        if g == 1 {
            return true
        }
    }
    return false
}

func gcd(a, b int) int {
    for a != 0 {
        a, b = b%a, a
    }
    return b
}
```

**复杂度分析**

-   时间复杂度：$O(n + \log m)$，其中 $n$ 为数组 $nums$ 的长度，$m$ 为数组 $nums$ 中的最大数，其中求单次最大公约数的时间复杂度为 $O(\log ⁡m)$，由于在每次求两个数的最大公约数时其中一个数保持单调不增，所以求总的公约数的时间复杂度为 $O(\log ⁡m)$。
-   空间复杂度：$O(1)$。仅使用常量空间。
