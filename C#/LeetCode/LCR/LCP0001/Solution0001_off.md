### [整数除法](https://leetcode.cn/problems/xoh6Oh/solutions/1398952/zheng-shu-chu-fa-by-leetcode-solution-3572/)

#### 前言

由于题目规定了「只能存储 $32$ 位整数」，本题解的正文部分和代码中都不会使用任何 $64$ 位整数。**诚然，使用 $64$ 位整数可以极大地方便我们的编码，但这是违反题目规则的。**

如果除法结果溢出，那么我们需要返回 $2^{31} - 1$ 作为答案。因此在编码之前，我们可以首先对于溢出或者容易出错的边界情况进行讨论：

- 当被除数为 $32$ 位有符号整数的最小值 $-2^{31}$ 时：
  - 如果除数为 $1$，那么我们可以直接返回答案 $-2^{31}$；
  - 如果除数为 $-1$，那么答案为 $2^{31}$，产生了溢出。此时我们需要返回 $2^{31} - 1$。
- 当除数为 $32$ 位有符号整数的最小值 $-2^{31}$ 时：
  - 如果被除数同样为 $-2^{31}$，那么我们可以直接返回答案 $1$；
  - 对于其余的情况，我们返回答案 $0$。
- 当被除数为 $0$ 时，我们可以直接返回答案 $0$。

对于一般的情况，根据除数和被除数的符号，我们需要考虑 $4$ 种不同的可能性。因此，为了方便编码，我们可以将被除数或者除数取相反数，使得它们符号相同。

如果我们将被除数和除数都变为正数，那么可能会导致溢出。例如当被除数为 $-2^{31}$ 时，它的相反数 $2^{31}$ 产生了溢出。因此，我们可以考虑将被除数和除数都变为负数，这样就不会有溢出的问题，在编码时只需要考虑 $1$ 种情况了。

如果我们将被除数和除数的其中（恰好）一个变为了正数，那么在返回答案之前，我们需要对答案也取相反数。

#### 方法一：二分查找

##### 思路与算法

根据「前言」部分的讨论，我们记被除数为 $X$，除数为 $Y$，并且 $X$ 和 $Y$ 都是负数。我们需要找出 $X/Y$ 的结果 $Z$。$Z$ 一定是正数或 $0$。

根据除法以及余数的定义，我们可以将其改成乘法的等价形式，即：

$$Z \times Y \leq X < (Z+1) \times Y$$

因此，我们可以使用二分查找的方法得到 $Z$，即找出**最大**的 $Z$ 使得 $Z \times Y \geq X$ 成立。

由于我们不能使用乘法运算符，因此我们需要使用「快速乘」算法得到 $Z \times Y$ 的值。「快速乘」算法与「快速幂」类似，前者通过加法实现乘法，后者通过乘法实现幂运算。「快速幂」算法可以参考[「50. Pow(x, n)」的官方题解](https://leetcode-cn.com/problems/powx-n/solution/powx-n-by-leetcode-solution/)，「快速乘」算法只需要在「快速幂」算法的基础上，将乘法运算改成加法运算即可。

##### 细节

由于我们只能使用 $32$ 位整数，因此二分查找中会有很多细节。

首先，二分查找的下界为 $1$，上界为 $2^{31} - 1$。唯一可能出现的答案为 $2^{31}$ 的情况已经被我们在「前言」部分进行了特殊处理，因此答案的最大值为 $2^{31} - 1$。如果二分查找失败，那么答案一定为 $0$。

在实现「快速乘」时，我们需要使用加法运算，然而较大的 $Z$ 也会导致加法运算溢出。例如我们要判断 $A + B$ 是否小于 $C$ 时（其中 $A, B, C$ 均为负数），$A + B$ 可能会产生溢出，因此我们必须将判断改为 $A < C - B$ 是否成立。由于任意两个负数的差一定在 $[-2^{31} + 1, 2^{31} - 1]$ 范围内，这样就不会产生溢出。

读者可以阅读下面的代码和注释，理解如何避免使用乘法和除法，以及正确处理溢出问题。

##### 代码

```c++
class Solution {
public:
    int divide(int a, int b) {
        // 考虑被除数为最小值的情况
        if (a == INT_MIN) {
            if (b == 1) {
                return INT_MIN;
            }
            if (b == -1) {
                return INT_MAX;
            }
        }
        // 考虑除数为最小值的情况
        if (b == INT_MIN) {
            return a == INT_MIN ? 1 : 0;
        }
        // 考虑被除数为 0 的情况
        if (a == 0) {
            return 0;
        }
        
        // 一般情况，使用二分查找
        // 将所有的正数取相反数，这样就只需要考虑一种情况
        bool rev = false;
        if (a > 0) {
            a = -a;
            rev = !rev;
        }
        if (b > 0) {
            b = -b;
            rev = !rev;
        }

        // 快速乘
        auto quickAdd = [](int y, int z, int x) {
            // x 和 y 是负数，z 是正数
            // 需要判断 z * y >= x 是否成立
            int result = 0, add = y;
            while (z) {
                if (z & 1) {
                    // 需要保证 result + add >= x
                    if (result < x - add) {
                        return false;
                    }
                    result += add;
                }
                if (z != 1) {
                    // 需要保证 add + add >= x
                    if (add < x - add) {
                        return false;
                    }
                    add += add;
                }
                // 不能使用除法
                z >>= 1;
            }
            return true;
        };
        
        int left = 1, right = INT_MAX, ans = 0;
        while (left <= right) {
            // 注意溢出，并且不能使用除法
            int mid = left + ((right - left) >> 1);
            bool check = quickAdd(b, mid, a);
            if (check) {
                ans = mid;
                // 注意溢出
                if (mid == INT_MAX) {
                    break;
                }
                left = mid + 1;
            }
            else {
                right = mid - 1;
            }
        }

        return rev ? -ans : ans;
    }
};
```

```java
class Solution {
    public int divide(int a, int b) {
        // 考虑被除数为最小值的情况
        if (a == Integer.MIN_VALUE) {
            if (b == 1) {
                return Integer.MIN_VALUE;
            }
            if (b == -1) {
                return Integer.MAX_VALUE;
            }
        }
        // 考虑除数为最小值的情况
        if (b == Integer.MIN_VALUE) {
            return a == Integer.MIN_VALUE ? 1 : 0;
        }
        // 考虑被除数为 0 的情况
        if (a == 0) {
            return 0;
        }
        
        // 一般情况，使用二分查找
        // 将所有的正数取相反数，这样就只需要考虑一种情况
        boolean rev = false;
        if (a > 0) {
            a = -a;
            rev = !rev;
        }
        if (b > 0) {
            b = -b;
            rev = !rev;
        }
        
        int left = 1, right = Integer.MAX_VALUE, ans = 0;
        while (left <= right) {
            // 注意溢出，并且不能使用除法
            int mid = left + ((right - left) >> 1);
            boolean check = quickAdd(b, mid, a);
            if (check) {
                ans = mid;
                // 注意溢出
                if (mid == Integer.MAX_VALUE) {
                    break;
                }
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return rev ? -ans : ans;
    }

    // 快速乘
    public boolean quickAdd(int y, int z, int x) {
        // x 和 y 是负数，z 是正数
        // 需要判断 z * y >= x 是否成立
        int result = 0, add = y;
        while (z != 0) {
            if ((z & 1) != 0) {
                // 需要保证 result + add >= x
                if (result < x - add) {
                    return false;
                }
                result += add;
            }
            if (z != 1) {
                // 需要保证 add + add >= x
                if (add < x - add) {
                    return false;
                }
                add += add;
            }
            // 不能使用除法
            z >>= 1;
        }
        return true;
    }
}
```

```csharp
public class Solution {
    public int Divide(int a, int b) {
        // 考虑被除数为最小值的情况
        if (a == int.MinValue) {
            if (b == 1) {
                return int.MinValue;
            }
            if (b == -1) {
                return int.MaxValue;
            }
        }
        // 考虑除数为最小值的情况
        if (b == int.MinValue) {
            return a == int.MinValue ? 1 : 0;
        }
        // 考虑被除数为 0 的情况
        if (a == 0) {
            return 0;
        }
        
        // 一般情况，使用二分查找
        // 将所有的正数取相反数，这样就只需要考虑一种情况
        bool rev = false;
        if (a > 0) {
            a = -a;
            rev = !rev;
        }
        if (b > 0) {
            b = -b;
            rev = !rev;
        }
        
        int left = 1, right = int.MaxValue, ans = 0;
        while (left <= right) {
            // 注意溢出，并且不能使用除法
            int mid = left + ((right - left) >> 1);
            bool check = quickAdd(b, mid, a);
            if (check) {
                ans = mid;
                // 注意溢出
                if (mid == int.MaxValue) {
                    break;
                }
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return rev ? -ans : ans;
    }

    // 快速乘
    public bool quickAdd(int y, int z, int x) {
        // x 和 y 是负数，z 是正数
        // 需要判断 z * y >= x 是否成立
        int result = 0, add = y;
        while (z != 0) {
            if ((z & 1) != 0) {
                // 需要保证 result + add >= x
                if (result < x - add) {
                    return false;
                }
                result += add;
            }
            if (z != 1) {
                // 需要保证 add + add >= x
                if (add < x - add) {
                    return false;
                }
                add += add;
            }
            // 不能使用除法
            z >>= 1;
        }
        return true;
    }
}
```

```python
class Solution:
    def divide(self, a: int, b: int) -> int:
        INT_MIN, INT_MAX = -2**31, 2**31 - 1

        # 考虑被除数为最小值的情况
        if a == INT_MIN:
            if b == 1:
                return INT_MIN
            if b == -1:
                return INT_MAX
        
        # 考虑除数为最小值的情况
        if b == INT_MIN:
            return 1 if a == INT_MIN else 0
        # 考虑被除数为 0 的情况
        if a == 0:
            return 0
        
        # 一般情况，使用二分查找
        # 将所有的正数取相反数，这样就只需要考虑一种情况
        rev = False
        if a > 0:
            a = -a
            rev = not rev
        if b > 0:
            b = -b
            rev = not rev

        # 快速乘
        def quickAdd(y: int, z: int, x: int) -> bool:
            # x 和 y 是负数，z 是正数
            # 需要判断 z * y >= x 是否成立
            result, add = 0, y
            while z > 0:
                if (z & 1) == 1:
                    # 需要保证 result + add >= x
                    if result < x - add:
                        return False
                    result += add
                if z != 1:
                    # 需要保证 add + add >= x
                    if add < x - add:
                        return False
                    add += add
                # 不能使用除法
                z >>= 1
            return True
        
        left, right, ans = 1, INT_MAX, 0
        while left <= right:
            # 注意溢出，并且不能使用除法
            mid = left + ((right - left) >> 1)
            check = quickAdd(b, mid, a)
            if check:
                ans = mid
                # 注意溢出
                if mid == INT_MAX:
                    break
                left = mid + 1
            else:
                right = mid - 1

        return -ans if rev else ans
```

```go
// 快速乘
// x 和 y 是负数，z 是正数
// 判断 z * y >= x 是否成立
func quickAdd(y, z, x int) bool {
    for result, add := 0, y; z > 0; z >>= 1 { // 不能使用除法
        if z&1 > 0 {
            // 需要保证 result + add >= x
            if result < x-add {
                return false
            }
            result += add
        }
        if z != 1 {
            // 需要保证 add + add >= x
            if add < x-add {
                return false
            }
            add += add
        }
    }
    return true
}

func divide(a, b int) int {
    if a == math.MinInt32 { // 考虑被除数为最小值的情况
        if b == 1 {
            return math.MinInt32
        }
        if b == -1 {
            return math.MaxInt32
        }
    }
    if b == math.MinInt32 { // 考虑除数为最小值的情况
        if a == math.MinInt32 {
            return 1
        }
        return 0
    }
    if a == 0 { // 考虑被除数为 0 的情况
        return 0
    }

    // 一般情况，使用二分查找
    // 将所有的正数取相反数，这样就只需要考虑一种情况
    rev := false
    if a > 0 {
        a = -a
        rev = !rev
    }
    if b > 0 {
        b = -b
        rev = !rev
    }

    ans := 0
    left, right := 1, math.MaxInt32
    for left <= right {
        mid := left + (right-left)>>1 // 注意溢出，并且不能使用除法
        if quickAdd(b, mid, a) {
            ans = mid
            if mid == math.MaxInt32 { // 注意溢出
                break
            }
            left = mid + 1
        } else {
            right = mid - 1
        }
    }
    if rev {
        return -ans
    }
    return ans
}
```

```javascript
var divide = function(a, b) {
    const MAX_VALUE = 2 ** 31 - 1, MIN_VALUE = -(2 ** 31);
    // 考虑被除数为最小值的情况
    if (a === MIN_VALUE) {
        if (b === 1) {
            return MIN_VALUE;
        }
        if (b === -1) {
            return MAX_VALUE;
        }
    }
    // 考虑除数为最小值的情况
    if (b === MIN_VALUE) {
        return a === MIN_VALUE ? 1 : 0;
    }
    // 考虑被除数为 0 的情况
    if (a === 0) {
        return 0;
    }
    
    // 一般情况，使用二分查找
    // 将所有的正数取相反数，这样就只需要考虑一种情况
    let rev = false;
    if (a > 0) {
        a = -a;
        rev = !rev;
    }
    if (b > 0) {
        b = -b;
        rev = !rev;
    }
    
    let left = 1, right = MAX_VALUE, ans = 0;
    while (left <= right) {
        // 注意溢出，并且不能使用除法
        const mid = left + ((right - left) >> 1);
        const check = quickAdd(b, mid, a);
        if (check) {
            ans = mid;
            // 注意溢出
            if (mid === MAX_VALUE) {
                break;
            }
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }

    return rev ? -ans : ans;
}

// 快速乘
const quickAdd = (y, z, x) => {
    // x 和 y 是负数，z 是正数
    // 需要判断 z * y >= x 是否成立
    let result = 0, add = y;
    while (z !== 0) {
        if ((z & 1) !== 0) {
            // 需要保证 result + add >= x
            if (result < x - add) {
                return false;
            }
            result += add;
        }
        if (z !== 1) {
            // 需要保证 add + add >= x
            if (add < x - add) {
                return false;
            }
            add += add;
        }
        // 不能使用除法
        z >>= 1;
    }
    return true;
};
```

#### 复杂度分析

- 时间复杂度：$O(\log^2 C)$，其中 $C$ 表示 $32$ 位整数的范围。二分查找的次数为 $O(\log C)$，其中的每一步我们都需要 $O(\log C)$ 使用「快速乘」算法判断 $Z \times Y \geq X$ 是否成立，因此总时间复杂度为 $O(\log^2 C)$。
- 空间复杂度：$O(1)$。

#### 方法二：类二分查找

##### 前言

常规意义下的二分查找为：给定区间 $[l, r]$，取该区间的中点 $\textit{mid} = \lfloor \dfrac{l+r}{2} \rfloor$，根据 $\textit{mid}$ 处是否满足某一条件，来决定移动左边界 $l$ 还是右边界 $r$。

我们也可以考虑另一种二分查找的方法：

- 记 $k$ 为满足 $2^k \leq r-l < 2^{k+1}$ 的 $k$ 值。
- 二分查找会进行 $k+1$ 次。在第 $i ~ (1 \leq i \leq k+1)$ 次二分查找时，设区间为 $[l_i, r_i]$，我们取 $\textit{mid} = l_i + 2^{k+1-i}$：
- 如果 $\textit{mid}$ 不在 $[l_i, r_i]$ 的范围内，那么我们直接忽略这次二分查找；
- 如果 $\textit{mid}$ 在 $[l_i, r_i]$ 的范围内，并且 $\textit{mid}$ 处满足某一条件，我们就将 $l_i$ 更新为 $\textit{mid}$，否则同样忽略这次二分查找。

最终 $l_i$ 即为二分查找的结果。这样做的正确性在于：

> 设在常规意义下的二分查找的答案为 $\textit{ans}$，记 $\delta$ 为 $\textit{ans}$ 与左边界的差值 $\textit{ans} - l$。$\delta$ 不会大于 $r-l$，并且 $\delta$ 一定可以用 $2^k, 2^{k-1}, 2^{k-2}, \cdots, 2^1, 2^0$ 中的若干个元素之和表示（考虑 $\delta$ 的二进制表示的意义即可）。因此上述二分查找是正确的。

##### 思路与算法

基于上述的二分查找的方法，我们可以设计出如下的算法：

- 我们首先不断地将 $Y$ 乘以 $2$（通过加法运算实现），并将这些结果放入数组中，其中数组的第 $i$ 项就等于 $Y \times 2^i$。这一过程直到 $Y$ 的两倍严格小于 $X$ 为止。
- 我们对数组进行逆序遍历。当遍历到第 $i$ 项时，如果其大于等于 $X$，我们就将答案增加 $2^i$，并且将 $X$ 中减去这一项的值。

本质上，上述的逆序遍历就模拟了二分查找的过程。

##### 代码

```c++
class Solution {
public:
    int divide(int a, int b) {
        // 考虑被除数为最小值的情况
        if (a == INT_MIN) {
            if (b == 1) {
                return INT_MIN;
            }
            if (b == -1) {
                return INT_MAX;
            }
        }
        // 考虑除数为最小值的情况
        if (b == INT_MIN) {
            return a == INT_MIN ? 1 : 0;
        }
        // 考虑被除数为 0 的情况
        if (a == 0) {
            return 0;
        }
        
        // 一般情况，使用类二分查找
        // 将所有的正数取相反数，这样就只需要考虑一种情况
        bool rev = false;
        if (a > 0) {
            a = -a;
            rev = !rev;
        }
        if (b > 0) {
            b = -b;
            rev = !rev;
        }

        vector<int> candidates = {b};
        // 注意溢出
        while (candidates.back() >= a - candidates.back()) {
            candidates.push_back(candidates.back() + candidates.back());
        }
        int ans = 0;
        for (int i = candidates.size() - 1; i >= 0; --i) {
            if (candidates[i] >= a) {
                ans += (1 << i);
                a -= candidates[i];
            }
        }

        return rev ? -ans : ans;
    }
};
```

```java
class Solution {
    public int divide(int a, int b) {
        // 考虑被除数为最小值的情况
        if (a == Integer.MIN_VALUE) {
            if (b == 1) {
                return Integer.MIN_VALUE;
            }
            if (b == -1) {
                return Integer.MAX_VALUE;
            }
        }
        // 考虑除数为最小值的情况
        if (b == Integer.MIN_VALUE) {
            return a == Integer.MIN_VALUE ? 1 : 0;
        }
        // 考虑被除数为 0 的情况
        if (a == 0) {
            return 0;
        }
        
        // 一般情况，使用类二分查找
        // 将所有的正数取相反数，这样就只需要考虑一种情况
        boolean rev = false;
        if (a > 0) {
            a = -a;
            rev = !rev;
        }
        if (b > 0) {
            b = -b;
            rev = !rev;
        }

        List<Integer> candidates = new ArrayList<Integer>();
        candidates.add(b);
        int index = 0;
        // 注意溢出
        while (candidates.get(index) >= a - candidates.get(index)) {
            candidates.add(candidates.get(index) + candidates.get(index));
            ++index;
        }
        int ans = 0;
        for (int i = candidates.size() - 1; i >= 0; --i) {
            if (candidates.get(i) >= a) {
                ans += 1 << i;
                a -= candidates.get(i);
            }
        }

        return rev ? -ans : ans;
    }
}
```

```csharp
public class Solution {
    public int Divide(int a, int b) {
        // 考虑被除数为最小值的情况
        if (a == int.MinValue) {
            if (b == 1) {
                return int.MinValue;
            }
            if (b == -1) {
                return int.MaxValue;
            }
        }
        // 考虑除数为最小值的情况
        if (b == int.MinValue) {
            return a == int.MinValue ? 1 : 0;
        }
        // 考虑被除数为 0 的情况
        if (a == 0) {
            return 0;
        }
        
        // 一般情况，使用类二分查找
        // 将所有的正数取相反数，这样就只需要考虑一种情况
        bool rev = false;
        if (a > 0) {
            a = -a;
            rev = !rev;
        }
        if (b > 0) {
            b = -b;
            rev = !rev;
        }

        IList<int> candidates = new List<int>();
        candidates.Add(b);
        int index = 0;
        // 注意溢出
        while (candidates[index] >= a - candidates[index]) {
            candidates.Add(candidates[index] + candidates[index]);
            ++index;
        }
        int ans = 0;
        for (int i = candidates.Count - 1; i >= 0; --i) {
            if (candidates[i] >= a) {
                ans += 1 << i;
                a -= candidates[i];
            }
        }

        return rev ? -ans : ans;
    }
}
```

```python
class Solution:
    def divide(self, a: int, b: int) -> int:
        INT_MIN, INT_MAX = -2**31, 2**31 - 1

        # 考虑被除数为最小值的情况
        if a == INT_MIN:
            if b == 1:
                return INT_MIN
            if b == -1:
                return INT_MAX
        
        # 考虑除数为最小值的情况
        if b == INT_MIN:
            return 1 if a == INT_MIN else 0
        # 考虑被除数为 0 的情况
        if a == 0:
            return 0
        
        # 一般情况，使用类二分查找
        # 将所有的正数取相反数，这样就只需要考虑一种情况
        rev = False
        if a > 0:
            a = -a
            rev = not rev
        if b > 0:
            b = -b
            rev = not rev
        
        candidates = [b]
        # 注意溢出
        while candidates[-1] >= a - candidates[-1]:
            candidates.append(candidates[-1] + candidates[-1])
        
        ans = 0
        for i in range(len(candidates) - 1, -1, -1):
            if candidates[i] >= a:
                ans += (1 << i)
                a -= candidates[i]

        return -ans if rev else ans
```

```go
func divide(a, b int) int {
    if a == math.MinInt32 { // 考虑被除数为最小值的情况
        if b == 1 {
            return math.MinInt32
        }
        if b == -1 {
            return math.MaxInt32
        }
    }
    if b == math.MinInt32 { // 考虑除数为最小值的情况
        if a == math.MinInt32 {
            return 1
        }
        return 0
    }
    if a == 0 { // 考虑被除数为 0 的情况
        return 0
    }

    // 一般情况，使用二分查找
    // 将所有的正数取相反数，这样就只需要考虑一种情况
    rev := false
    if a > 0 {
        a = -a
        rev = !rev
    }
    if b > 0 {
        b = -b
        rev = !rev
    }

    candidates := []int{b}
    for y := b; y >= a-y; { // 注意溢出
        y += y
        candidates = append(candidates, y)
    }

    ans := 0
    for i := len(candidates) - 1; i >= 0; i-- {
        if candidates[i] >= a {
            ans |= 1 << i
            a -= candidates[i]
        }
    }
    if rev {
        return -ans
    }
    return ans
}
```

```javascript
var divide = function(a, b) {
    const MAX_VALUE = 2 ** 31 - 1, MIN_VALUE = -(2 ** 31);
    // 考虑被除数为最小值的情况
    if (a === MIN_VALUE) {
        if (b === 1) {
            return MIN_VALUE;
        }
        if (b === -1) {
            return MAX_VALUE;
        }
    }
    // 考虑除数为最小值的情况
    if (b === MIN_VALUE) {
        return a === MIN_VALUE ? 1 : 0;
    }
    // 考虑被除数为 0 的情况
    if (a === 0) {
        return 0;
    }
    
    // 一般情况，使用类二分查找
    // 将所有的正数取相反数，这样就只需要考虑一种情况
    let rev = false;
    if (a > 0) {
        a = -a;
        rev = !rev;
    }
    if (b > 0) {
        b = -b;
        rev = !rev;
    }

    const candidates = [b];
    let index = 0;
    // 注意溢出
    while (candidates[index] >= a - candidates[index]) {
        candidates.push(candidates[index] + candidates[index]);
        ++index;
    }
    let ans = 0;
    for (let i = candidates.length - 1; i >= 0; --i) {
        if (candidates[i] >= a) {
            ans += 1 << i;
            a -= candidates[i];
        }
    }

    return rev ? -ans : ans;
};
```

#### 复杂度分析

- 时间复杂度：$O(\log C)$，即为二分查找需要的时间。方法二时间复杂度优于方法一的原因是：方法一的每一步二分查找都需要重新计算 $Z \times Y$ 的值，需要 $O(\log C)$ 的时间复杂度；而方法二的每一步的权重都是 $2$ 的幂，在二分查找开始前就都是已知的值，因此我们可以在 $O(\log C)$ 的时间内，一次性将它们全部预处理出来。
- 空间复杂度：$O(\log C)$，即为需要存储的 $Y \times 2^i$ 的数量。
