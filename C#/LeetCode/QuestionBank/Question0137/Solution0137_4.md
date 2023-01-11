#### [方法三：数字电路设计](https://leetcode.cn/problems/single-number-ii/solutions/746993/zhi-chu-xian-yi-ci-de-shu-zi-ii-by-leetc-23t6/?orderBy=hot)

**说明**

方法三以及后续进行优化的方法四需要读者有一定的数字电路设计的基础。读者需要对以下知识：

-   简单的门电路（例如与门、异或门等）
-   给定数字电路输入和输出（真值表），使用门电路设计出一种满足要求的数字电路结构

有一定的了解。

**门电路表示**

我们将会用到四种门电路，使用的符号如下：

-   非门：我们用 $A'$ 表示输入为 $A$ 的非门的输出；
-   与门：我们用 $AB$ 表示输入为 $A$ 和 $B$ 的与门的输出。由于「与运算」具有结合律，因此如果同时用了多个与门（例如将 $A$ 和 $B$ 进行与运算后，再和 $C$ 进行与运算），我们可以将多个输入写在一起（例如 $ABC$）；
-   或门：我们用 $A+B$ 表示输入为 $A$ 和 $B$ 的或门的输出。同样地，多个或门可以写在一起（例如 $A+B+C$）；
-   异或门：我们用 $A \oplus B$ 表示输入为 $A$ 和 $B$ 的异或门的输出。同样的，多个异或门可以写在一起（例如 $A \oplus B \oplus C$）。

**思路与算法**

在方法二中，我们是依次处理每一个二进制位的，那么时间复杂度中就引入了 O(log⁡C)O(\\log C)O(logC) 这一项。既然我们在对两个整数进行普通的二元运算时，都是将它们看成整体进行处理的，那么我们是否能以普通的二元运算为基础，同时处理所有的二进制位？

答案是可以的。我们可以使用一个「黑盒」存储当前遍历过的所有整数。「黑盒」的第 iii 位为 {0,1,2}\\{ 0, 1, 2 \\}{0,1,2} 三者之一，表示当前遍历过的所有整数的第 iii 位之和除以 333 的余数。但由于二进制表示中只有 000 和 111 而没有 222，因此我们可以考虑在「黑盒」中使用两个整数来进行存储，即：

> 黑盒中存储了两个整数 $a$ 和 $b$，且会有三种情况：
> 
> -   $a$ 的第 $i$ 位为 $0$ 且 $b$ 的第 $i$ 位为 $0$，表示 $0$；
> -   $a$ 的第 $i$ 位为 $0$ 且 $b$ 的第 $i$ 位为 $1$，表示 $1$；
> -   $a$ 的第 $i$ 位为 $1$ 且 $b$ 的第 $i$ 位为 $0$，表示 $2$。
> 
> 为了方便叙述，我们用 (00)(00)(00) 表示 aaa 的第 iii 位为 000 且 bbb 的第 iii 位为 000，其余的情况类似。

当我们遍历到一个新的整数 xxx 时，对于 xxx 的第 iii 位 xix\_ixi，如果 xi=0x\_i=0xi\=0，那么 aaa 和 bbb 的第 iii 位不变；如果 xi=1x\_i=1xi\=1，那么 aaa 和 bbb 的第 iii 位按照 (00)→(01)→(10)→(00)(00)\\to(01)\\to(10)\\to(00)(00)→(01)→(10)→(00) 这一循环进行变化。因此我们可以得出下面的真值表：

| (ai bi)(a\_i ~ b\_i)(ai bi) | xix\_ixi | 新的 (ai bi)(a\_i ~ b\_i)(ai bi) |
| --- | --- | --- |
| 000000 | 000 | 000000 |
| 000000 | 111 | 010101 |
| 010101 | 000 | 010101 |
| 010101 | 111 | 101010 |
| 101010 | 000 | 101010 |
| 101010 | 111 | 000000 |

当我们考虑输出为 aia\_iai 时：

| (ai bi)(a\_i ~ b\_i)(ai bi) | xix\_ixi | 新的 aia\_iai |
| --- | --- | --- |
| 000000 | 000 | 000 |
| 000000 | 111 | 000 |
| 010101 | 000 | 000 |
| 010101 | 111 | 111 |
| 101010 | 000 | 111 |
| 101010 | 111 | 000 |

根据真值表可以设计出电路：

ai=ai′bixi+aibi′xi′ a\_i = a\_i'b\_ix\_i + a\_ib\_i'x\_i' ai\=ai′bixi+aibi′xi′

当我们考虑输出为 bib\_ibi 时：

| (ai bi)(a\_i ~ b\_i)(ai bi) | xix\_ixi | 新的 bib\_ibi |
| --- | --- | --- |
| 000000 | 000 | 000 |
| 000000 | 111 | 111 |
| 010101 | 000 | 111 |
| 010101 | 111 | 000 |
| 101010 | 000 | 000 |
| 101010 | 111 | 000 |

根据真值表可以设计出电路：

bi=ai′bi′xi+ai′bixi′=ai′(bi⊕xi) b\_i = a\_i'b\_i'x\_i + a\_i'b\_ix\_i' = a\_i'(b\_i \\oplus x\_i) bi\=ai′bi′xi+ai′bixi′\=ai′(bi⊕xi)

将上面的电路逻辑运算转换为等价的整数位运算，最终的转换规则即为：

{a = (~a & b & x) | (a & ~b & ~x)b = ~a & (b ˆx) \\begin{cases} \\texttt{a = (\\textasciitilde a \\& b \\& x) | (a \\& \\textasciitilde b \\& \\textasciitilde x)} \\\\ \\texttt{b = \\textasciitilde a \\& (b\\^ x)} \\end{cases} {a = (~a & b & x) | (a & ~b & ~x)b = ~a & (b ˆx)

其中 ~, &, |,  ˆ\\texttt{\\textasciitilde, \\&, |, \\^ }~, &, |,  ˆ 分别表示按位非、与、或、异或运算。

当我们遍历完数组中的所有元素后，(aibi)(a\_i b\_i)(aibi) 要么是 (00)(00)(00)，表示答案的第 iii 位是 000；要么是 (01)(01)(01)，表示答案的第 iii 位是 111。因此我们只需要返回 bbb 作为答案即可。

**细节**

由于电路中的 aia\_iai 和 bib\_ibi 是「同时」得出结果的，因此我们在计算 aaa 和 bbb 时，需要使用临时变量暂存它们之前的值，再使用转换规则进行计算。

**代码**

```cpp
class Solution {
public:
    int singleNumber(vector<int>& nums) {
        int a = 0, b = 0;
        for (int num: nums) {
            tie(a, b) = pair{(~a & b & num) | (a & ~b & ~num), ~a & (b ^ num)};
        }
        return b;
    }
};
```

```java
class Solution {
    public int singleNumber(int[] nums) {
        int a = 0, b = 0;
        for (int num : nums) {
            int aNext = (~a & b & num) | (a & ~b & ~num), bNext = ~a & (b ^ num);
            a = aNext;
            b = bNext;
        }
        return b;
    }
}
```

```python
class Solution:
    def singleNumber(self, nums: List[int]) -> int:
        a = b = 0
        for num in nums:
            a, b = (~a & b & num) | (a & ~b & ~num), ~a & (b ^ num)
        return b
```

```javascript
var singleNumber = function(nums) {
    let a = 0, b = 0;
    for (const num of nums) {
        const aNext = (~a & b & num) | (a & ~b & ~num), bNext = ~a & (b ^ num);
        a = aNext;
        b = bNext;
    }
    return b;
};
```

```go
func singleNumber(nums []int) int {
    a, b := 0, 0
    for _, num := range nums {
        a, b = b&^a&num|a&^b&^num, (b^num)&^a
    }
    return b
}
```

```c
int singleNumber(int *nums, int numsSize) {
    int a = 0, b = 0;
    for (int i = 0; i < numsSize; i++) {
        int tmp_a = (~a & b & nums[i]) | (a & ~b & ~nums[i]);
        int tmp_b = ~a & (b ^ nums[i]);
        a = tmp_a;
        b = tmp_b;
    }
    return b;
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是数组的长度。
-   空间复杂度：$O(1)$。
