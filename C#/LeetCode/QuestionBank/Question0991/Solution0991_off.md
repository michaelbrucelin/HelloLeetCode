### [坏了的计算器](https://leetcode.cn/problems/broken-calculator/solutions/3609/pi-liao-de-ji-suan-qi-by-leetcode/?envType=problem-list-v2&envId=tBJHVASZ)

#### 方法：逆向思维

**思路**

除了对 `X` 执行乘 $2$ 或 减 $1$ 操作之外，我们也可以对 `Y` 执行`除 $2`$（当 `Y` 是偶数时）或者`加 $1`$ 操作。

这样做的动机是我们可以总是贪心地执行除 $2$ 操作：

- 当 `Y` 是偶数，如果先执行 $2$ 次加法操作，再执行 $1$ 次除法操作，我们可以通过先执行 $1$ 次除法操作，再执行 $1$ 次加法操作以使用更少的操作次数得到相同的结果 [`(Y+2) / 2` vs `Y/2 + 1`]。
- 当 `Y` 是奇数，如果先执行 $3$ 次加法操作，再执行 $1$ 次除法操作，我们可以将其替代为顺次执行加法、除法、加法操作以使用更少的操作次数得到相同的结果 [`(Y+3) / 2` vs `(Y+1) / 2 + 1`]。

**算法**

当 `Y` 大于 `X` 时，如果它是奇数，我们执行加法操作，否则执行除法操作。之后，我们需要执行 `X - Y` 次加法操作以得到 `X`。

```Java
class Solution {
    public int brokenCalc(int X, int Y) {
        int ans = 0;
        while (Y > X) {
            ans++;
            if (Y % 2 == 1)
                Y++;
            else
                Y /= 2;
        }

        return ans + X - Y;
    }
}
```

```Python
class Solution(object):
    def brokenCalc(self, X, Y):
        ans = 0
        while Y > X:
            ans += 1
            if Y%2: Y += 1
            else: Y /= 2

        return ans + X-Y
```

**复杂度分析**

- 时间复杂度：$ O(logY)$。
- 空间复杂度：$ O(1)$。
