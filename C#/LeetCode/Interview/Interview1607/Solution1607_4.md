#### [震惊，这道题竟可以这样做！（也许是完美解法）](https://leetcode.cn/problems/maximum-lcci/solutions/1060008/zhen-liang-zhe-dao-ti-jing-ke-yi-zhe-yan-vj0s/)

请原谅我的震惊体的标题：），但我真心希望我的解法可以给你带来启发。

关于这道题已有很多解法，大概有以下几种：

1.  使用 `max`，`abs` 之类的库函数。这种真的不要骗自己，就是作弊方法；
2.  使用位运算，但申请了更大的类型避免溢出。这种没有作弊，但是我觉得还可以改进，因为如果入参就已经是系统支持的最大类型，那么这类解法就无效了；
3.  使用位运算，同时没有申请更大的类型。这种已经很完美了，但是我没有看到 C/C++ 的 Solution，可能 C/C++ 面对溢出问题会报错（Java 不会），处理起来更困难一些。

回到问题中，我们现在来一步一步思考。首先，如果没有限制条件，那么非常简单：

```cpp
class Solution {
public:
    int maximum(int a, int b) {
        if (a < b)
            return b;
        else
            return a;

        // 或者使用三目运算符
        return a < b ? b : a;
    }
};
```

但是，我们不能使用 if-else 或者比较运算符，所以我们需要构思如何去返回结果，这里不妨构造一个计算公式：

```cpp
class Solution {
public:
    int maximum(int a, int b) {
        return a * k + b * (k ^ 1);
    }
};
```

这里 k 的值应该为 1 或 0，且我们应使其：

-   当 a < b 时，k = 0，则 k ^ 1 = 1。此时计算结果等于 b；
-   当 a > b 是，k = 1，则 k ^ 1 = 0。此时计算结果等于 a。

那么如何让 k 满足我们的要求的呢？这里可以用算术运算+位运算操作：判断 a - b 的最高位（符号位），即：

-   当 a - b < 0 时，a - b 的最高位为 1，此时，k 应该为 0；
-   当 a - b > 0 时，a - b 的最高位为 0，此时，k 应该为 1；

发现了吗？k 的值和 a - b 的最高位恰好相反，这里很自然的再引入异或运算，可以得到代码：

```cpp
class Solution {
public:
    int maximum(int a, int b) {
        int bitlen = sizeof(a) * 8;
        // C/C++ 中负数右移最高位会补 1，因此需要转成无符号类型后再右移
        // 将 a-b 的符号位移动到最左边，再与 1 异或取反，得到 k 的值
        int k = static_cast<unsigned>(a - b) >> (bitlen - 1) ^ 1;
        return a * k + b * (k ^ 1);
    }
};
```

这样我们就返回了正确结果。但是需要注意 a - b 可能会导致溢出问题，一种简单的解决方式是用更大的类型（例如 long long）保存中间结果，但如果入参已经是系统支持的最大类型，那这种解法就失效了，所以并不完美。因此，我们来思考一下如何在给定的类型范围内解决这个问题。这里，我们需要分情况考虑：

-   当 a 和 b 同号时，a - b 不会溢出，使用上面的代码即可；
-   当 a 和 b 异号时，a - b 可能溢出，需要额外处理；

第一种情况我们已经解决了，现在来考虑第二种情况。我们可以使用 a 的符号位异或 b 的符号位，当结果为 1 时，说明异号；结果为 0 时，说明同号。当异号时，我们应该直接返回正数，避免 a - b 的运算。那么当两数异号时，我们如何确定 k 的值呢？当 a 为负数时，a 的符号位为 1，此时 k 应该为 0；当 a 为正数时，a 的符号位为 0，k 应该为 1。总结规律可以发现，k 的值应该等于 a 的符号位异或 1。现在来实现第二种情况的代码：

```cpp
class Solution {
public:
    int maximum(int a, int b) {
        int bitlen = sizeof(a) * 8;
        int asign = static_cast<unsigned>(a) >> (bitlen - 1);
        int k = asign ^ 1;
        return a * k + b * (k ^ 1);
    }
};
```

现在我们已经实现了两种不同情况下的代码，针对两数同号或异号的场景分别处理，以避免溢出问题，最后我们只需要将其组合起来。由于不能使用 if-else 语句，需要我们用一点 trick，见下：

```cpp
class Solution {
public:
    int maximum(int a, int b) {
        // 计算 int 类型的位数，避免不同系统下长度不同
        int bitlen = sizeof(a) * 8;

        // 计算 a 的符号位，b 的符号位
        // C/C++ 中负数右移最高位会补 1，因此需要转成无符号类型后再右移
        int asign = static_cast<unsigned>(a) >> (bitlen - 1);
        int bsign = static_cast<unsigned>(b) >> (bitlen - 1);
        // 假设 a 与 b 异号，计算 k 的值
        int k = asign ^ 1;

        // 当 a 和 b 异号时，asign ^ bsign ^ 1 为 0，由于 逻辑与运算 的短路性，将不再计算后半行代码，避免溢出
        // 当 a 和 b 同号时，asign ^ bsign ^ 1 为 1，此时会执行后半行代码，重新对 k 赋值
        int temp_cond = (asign ^ bsign ^ 1) && (k = static_cast<unsigned>(a - b) >> (bitlen - 1) ^ 1);
        return a * k + b * (k ^ 1);
    }
};
```

至此，我们就完成了这道题。

___

写在最后，我想说说关于这道题的看法。我在评论区看到一些高赞的评论认为这种题没有意义，对此我不太认同。很多时候，我们其实是在各种限制条件下去求解问题，从这个角度看，这道题亦是如此。
