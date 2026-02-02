### [设计机械累加器](https://leetcode.cn/problems/qiu-12n-lcof/solutions/271053/qiu-12n-by-leetcode-solution/?envType=problem-list-v2&envId=ySsxoJfz)

#### 前言

首先我们梳理题目要求。题目要求我们不能使用乘除法、`for`、`while`、`if`、`else`、`switch`、`case` 等关键字及条件判断语句，因此我们手里能用的工具很少，列举出来发现只有加减法、赋值、位运算符以及逻辑运算符。

#### 方法一：递归

**思路和算法**

试想一下如果不加限制地使用递归的方法来实现这道题，相信大家都能很容易地给出下面的实现（以 $C++$ 为例）：

```C++
class Solution {
public:
    int mechanicalAccumulator(int target) {
        return target == 0 ? 0 : target + mechanicalAccumulator(target - 1);
    }
};
```

通常实现递归的时候我们都会利用条件判断语句来决定递归的出口，但由于题目的限制我们不能使用条件判断语句，那么我们是否能使用别的办法来确定递归出口呢？答案就是逻辑运算符的短路性质。

以逻辑运算符 `&&` 为例，对于 `A && B` 这个表达式，如果 `A` 表达式返回 $False$，那么 `A && B` 已经确定为 $False$，此时不会去执行表达式 `B`。同理，对于逻辑运算符 `||`， 对于 `A || B` 这个表达式，如果 `A` 表达式返回 $True$，那么 `A || B` 已经确定为 $True$，此时不会去执行表达式 `B`。

利用这一特性，我们可以将判断是否为递归的出口看作 `A && B` 表达式中的 `A` 部分，递归的主体函数看作 `B` 部分。如果不是递归出口，则返回 $True$，并继续执行表达式 `B` 的部分，否则递归结束。当然，你也可以用逻辑运算符 `||` 给出类似的实现，这里我们只提供结合逻辑运算符 `&&` 的递归实现。

```C++
class Solution {
public:
    int mechanicalAccumulator(int target) {
        target && (target += mechanicalAccumulator(target-1));
        return target;
    }
};
```

```Java
class Solution {
    public int mechanicalAccumulator(int target) {
        boolean flag = target > 0 && (target += mechanicalAccumulator(target - 1)) > 0;
        return target;
    }
}
```

```TypeScript
var mechanicalAccumulator = function(target: number): number {
    target && (target += mechanicalAccumulator(target - 1));
    return target;
};
```

```Go
func mechanicalAccumulator(target int) int {
    ans := 0
    var sum func(int) bool
    sum = func(target int) bool {
        ans += target
        return target > 0 && sum(target-1)
    }
    sum(target)
    return ans
}
```

**复杂度分析**

- 时间复杂度：$O(target)$。递归函数递归 $target$ 次，每次递归中计算时间复杂度为 $O(1)$，因此总时间复杂度为 $O(target)$。
- 空间复杂度：$O(target)$。递归函数的空间复杂度取决于递归调用栈的深度，这里递归函数调用栈深度为 $O(target)$，因此空间复杂度为 $O(target)$。

#### 方法二：快速乘

**思路和算法**

考虑 `A` 和 `B` 两数相乘的时候我们如何利用加法和位运算来模拟，其实就是将 `B` 二进制展开，如果 `B` 的二进制表示下第 $i$ 位为 $1$，那么这一位对最后结果的贡献就是 $A\times (1<<i)$，即 $A<<i$。我们遍历 `B` 二进制展开下的每一位，将所有贡献累加起来就是最后的答案，这个方法也被称作「俄罗斯农民乘法」，感兴趣的读者可以自行网上搜索相关资料。这个方法经常被用于两数相乘取模的场景，如果两数相乘已经超过数据范围，但取模后不会超过，我们就可以利用这个方法来拆位取模计算贡献，保证每次运算都在数据范围内。

下面给出这个算法的 $C++$ 实现：

```C++
int quickMulti(int A, int B) {
    int ans = 0;
    for ( ; B; B >>= 1) {
        if (B & 1) {
            ans += A;
        }
        A <<= 1;
    }
    return ans;
}
```

回到本题，由等差数列求和公式我们可以知道 $1+2+\dots +target$ 等价于 $\dfrac{target(target+1)}{2}$，对于除以 $2$ 我们可以用右移操作符来模拟，那么等式变成了 $target(target+1)>>1$，剩下不符合题目要求的部分即为 $target(target+1)$，根据上文提及的快速乘，我们可以将两个数相乘用加法和位运算来模拟，但是可以看到上面的 $C++$ 实现里我们还是需要循环语句，有没有办法去掉这个循环语句呢？答案是有的，那就是自己手动展开，因为题目数据范围 $target$ 为 $[1,10000]$，所以 $target$ 二进制展开最多不会超过 $14$ 位，我们手动展开 $14$ 层代替循环即可，至此满足了题目的要求，具体实现可以参考下面给出的代码。

```C++
class Solution {
public:
    int mechanicalAccumulator(int target) {
        int ans = 0, A = target, B = target + 1;

        (B & 1) && (ans += A);
        A <<= 1;
        B >>= 1;

        (B & 1) && (ans += A);
        A <<= 1;
        B >>= 1;

        (B & 1) && (ans += A);
        A <<= 1;
        B >>= 1;

        (B & 1) && (ans += A);
        A <<= 1;
        B >>= 1;

        (B & 1) && (ans += A);
        A <<= 1;
        B >>= 1;

        (B & 1) && (ans += A);
        A <<= 1;
        B >>= 1;

        (B & 1) && (ans += A);
        A <<= 1;
        B >>= 1;

        (B & 1) && (ans += A);
        A <<= 1;
        B >>= 1;

        (B & 1) && (ans += A);
        A <<= 1;
        B >>= 1;

        (B & 1) && (ans += A);
        A <<= 1;
        B >>= 1;

        (B & 1) && (ans += A);
        A <<= 1;
        B >>= 1;

        (B & 1) && (ans += A);
        A <<= 1;
        B >>= 1;

        (B & 1) && (ans += A);
        A <<= 1;
        B >>= 1;

        (B & 1) && (ans += A);
        A <<= 1;
        B >>= 1;

        return ans >> 1;
    }
};
```

```Java
class Solution {
    public int mechanicalAccumulator(int target) {
        int ans = 0, A = target, B = target + 1;
        boolean flag;

        flag = ((B & 1) > 0) && (ans += A) > 0;
        A <<= 1;
        B >>= 1;

        flag = ((B & 1) > 0) && (ans += A) > 0;
        A <<= 1;
        B >>= 1;

        flag = ((B & 1) > 0) && (ans += A) > 0;
        A <<= 1;
        B >>= 1;

        flag = ((B & 1) > 0) && (ans += A) > 0;
        A <<= 1;
        B >>= 1;

        flag = ((B & 1) > 0) && (ans += A) > 0;
        A <<= 1;
        B >>= 1;

        flag = ((B & 1) > 0) && (ans += A) > 0;
        A <<= 1;
        B >>= 1;

        flag = ((B & 1) > 0) && (ans += A) > 0;
        A <<= 1;
        B >>= 1;

        flag = ((B & 1) > 0) && (ans += A) > 0;
        A <<= 1;
        B >>= 1;

        flag = ((B & 1) > 0) && (ans += A) > 0;
        A <<= 1;
        B >>= 1;

        flag = ((B & 1) > 0) && (ans += A) > 0;
        A <<= 1;
        B >>= 1;

        flag = ((B & 1) > 0) && (ans += A) > 0;
        A <<= 1;
        B >>= 1;

        flag = ((B & 1) > 0) && (ans += A) > 0;
        A <<= 1;
        B >>= 1;

        flag = ((B & 1) > 0) && (ans += A) > 0;
        A <<= 1;
        B >>= 1;

        flag = ((B & 1) > 0) && (ans += A) > 0;
        A <<= 1;
        B >>= 1;

        return ans >> 1;
    }
}
```

```TypeScript
var mechanicalAccumulator = function(target: number): number {
    let ans: number = 0, A: number = target, B: number = target + 1;

    (B & 1) && (ans += A);
    A <<= 1;
    B >>= 1;

    (B & 1) && (ans += A);
    A <<= 1;
    B >>= 1;

    (B & 1) && (ans += A);
    A <<= 1;
    B >>= 1;

    (B & 1) && (ans += A);
    A <<= 1;
    B >>= 1;

    (B & 1) && (ans += A);
    A <<= 1;
    B >>= 1;

    (B & 1) && (ans += A);
    A <<= 1;
    B >>= 1;

    (B & 1) && (ans += A);
    A <<= 1;
    B >>= 1;

    (B & 1) && (ans += A);
    A <<= 1;
    B >>= 1;

    (B & 1) && (ans += A);
    A <<= 1;
    B >>= 1;

    (B & 1) && (ans += A);
    A <<= 1;
    B >>= 1;

    (B & 1) && (ans += A);
    A <<= 1;
    B >>= 1;

    (B & 1) && (ans += A);
    A <<= 1;
    B >>= 1;

    (B & 1) && (ans += A);
    A <<= 1;
    B >>= 1;

    (B & 1) && (ans += A);
    A <<= 1;
    B >>= 1;

    return ans >> 1;
};
```

```Go
func mechanicalAccumulator(target int) int {
    ans, A, B := 0, target, target + 1
    addGreatZero := func() bool {
        ans += A
        return ans > 0
    }

    _ = ((B & 1) > 0) && addGreatZero()
    A <<= 1
    B >>= 1

    _ = ((B & 1) > 0) && addGreatZero()
    A <<= 1
    B >>= 1

    _ = ((B & 1) > 0) && addGreatZero()
    A <<= 1
    B >>= 1

    _ = ((B & 1) > 0) && addGreatZero()
    A <<= 1
    B >>= 1

    _ = ((B & 1) > 0) && addGreatZero()
    A <<= 1
    B >>= 1

    _ = ((B & 1) > 0) && addGreatZero()
    A <<= 1
    B >>= 1

    _ = ((B & 1) > 0) && addGreatZero()
    A <<= 1
    B >>= 1

    _ = ((B & 1) > 0) && addGreatZero()
    A <<= 1
    B >>= 1

    _ = ((B & 1) > 0) && addGreatZero()
    A <<= 1
    B >>= 1

    _ = ((B & 1) > 0) && addGreatZero()
    A <<= 1
    B >>= 1

    _ = ((B & 1) > 0) && addGreatZero()
    A <<= 1
    B >>= 1

    _ = ((B & 1) > 0) && addGreatZero()
    A <<= 1
    B >>= 1

    _ = ((B & 1) > 0) && addGreatZero()
    A <<= 1
    B >>= 1

    _ = ((B & 1) > 0) && addGreatZero()
    A <<= 1
    B >>= 1
    return ans >> 1
}
```

**复杂度分析**

- 时间复杂度：$O(\log target)$。快速乘需要的时间复杂度为 $O(\log target)$。
- 空间复杂度：$O(1)$。只需要常数空间存放若干变量。
