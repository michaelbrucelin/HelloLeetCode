#### [位运算实现大小比较](https://leetcode.cn/problems/maximum-lcci/solutions/95319/ji-yu-wei-yun-suan-shi-xian-da-xiao-bi-jiao-by-dex/)

##### 解释

> 既然题目提到：**不得使用if-else或其他比较运算符**，那么我们也尽可能回避abs、max这些函数，因为其内部可能调用比较了运算符。

##### 思路

本质是**平均值法**： `max(a, b) = ((a + b) + abs(a - b)) / 2`。

##### 绝对值的位运算

> 为了回避`abs`，利用位运算实现绝对值功能。 以`int8_t`为例：分析运算：`(var ^ (var >> 7)) - (var >> 7)`

-   **var >= 0:** `var >> 7 => 0x00`，即：`(var ^ 0x00) - 0x00`，异或结果为`var`
-   **var < 0:** `var >> 7 => 0xFF`，即：`(var ^ 0xFF) - 0xFF`，`var ^ 0xFF`是在对var的全部位取反，`-0xFF <=> +1`, 对`signed int`取反加一就是取其**相反数**。

举个栗子🌰：`var = -3 <=> 0xFD`，`(var ^ 0xFF) - 0xFF= 0x02 - 0xff= 0x03`

> 基于上述分析：
> 
> | 类型 | 绝对值位运算 |
> | -- | -- |
> | `int8_t`  | `(var ^ (var >> 7))  - (var >> 7)` |
> | `int16_t` | `(var ^ (var >> 15)) - (var >> 15)` |
> | `int32_t` | `(var ^ (var >> 31)) - (var >> 31)` |
> | `int64_t` | `(var ^ (var >> 63)) - (var >> 63)` |

代码中`(_diff ^ (_diff >> 63)) - (_diff >> 63)`就是在求取`long (int64_t)`的绝对值。

##### 代码

```java
class Solution {
public:
    int maximum(int a, int b) {
        long _sum = long(a) + long(b);
        long _diff = long(a) - long(b);
        long _abs_diff = (_diff ^ (_diff >> 63)) - (_diff >> 63);
        return (_sum + _abs_diff) / 2;
    }
};
```
