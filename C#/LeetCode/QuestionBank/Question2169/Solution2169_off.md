### [得到 0 的操作数](https://leetcode.cn/problems/count-operations-to-obtain-zero/solutions/1270345/de-dao-0-de-cao-zuo-shu-by-leetcode-solu-d8kh/)

#### 方法一：辗转相除

**思路与算法**

我们可以按要求模拟两数比较后相减的操作，但在两数差距十分悬殊时，会有大量连续且相同的相减操作，因此我们可以对模拟的过程进行优化。

不妨假设 $num_1\ge num_2$，则我们需要用 $num_1$ 减 $num_2$，直到 $num_1<num_2$ 为止。当上述一系列操作结束之后，$num_1$ 的新数值即为 $num_1\mod num_2$，在这期间进行了 $\lfloor num_1/num_2\rfloor $ 次相减操作，其中 $\lfloor \dots \rfloor $ 代表向下取整。

容易发现，题目中的过程即为求两个数最大公约数的「辗转相减」方法，而我们需要将它优化为时间复杂度更低的「辗转相除」法，同时利用前文的方法统计对应相减操作的次数。

具体而言，在模拟的过程中，我们用 $res$ 来统计相减操作的次数。在每一步模拟开始前，我们需要保证 $num_1\ge num_2$；在每一步中，两个数 $(num_1,num_2)$ 变为 $(num_1\mod num_2,num_2)$，同时我们将 $res$ 加上该步中相减操作的次数 $\lfloor num_1/num_2\rfloor $；最后，我们还需要交换 $num_1$ 与 $num_2$ 的数值，以保证下一步模拟的初始条件。当 $num_1$ 或 $num_2$ 中至少有一个数字为零时，循环结束，我们返回 $res$ 作为答案。

**细节**

在第一步模拟（进入循环）之前，我们事实上不需要保证 $num_1\ge num_2$，因为我们可以通过额外的一步模拟将 $(num_1,num_2)$ 变为 $(num_2,num_1)$，而这一步贡献的相减次数为 $0$。

**代码**

```C++
class Solution {
public:
    int countOperations(int num1, int num2) {
        int res = 0;   // 相减操作的总次数
        while (num1 && num2) {
            // 每一步辗转相除操作
            res += num1 / num2;
            num1 %= num2;
            swap(num1, num2);
        }
        return res;
    }
};
```

```Python
class Solution:
    def countOperations(self, num1: int, num2: int) -> int:
        res = 0   # 相减操作的总次数
        while num1 and num2:
            # 每一步辗转相除操作
            res += num1 // num2
            num1 %= num2
            num1, num2 = num2, num1
        return res
```

```Java
class Solution {
    public int countOperations(int num1, int num2) {
        int res = 0;   // 相减操作的总次数
        while (num1 != 0 && num2 != 0) {
            // 每一步辗转相除操作
            res += num1 / num2;
            num1 %= num2;
            // 交换两个数
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int CountOperations(int num1, int num2) {
        int res = 0;   // 相减操作的总次数
        while (num1 != 0 && num2 != 0) {
            // 每一步辗转相除操作
            res += num1 / num2;
            num1 %= num2;
            // 交换两个数
            (num1, num2) = (num2, num1);
        }
        return res;
    }
}
```

```Go
func countOperations(num1 int, num2 int) int {
    res := 0   // 相减操作的总次数
    for num1 != 0 && num2 != 0 {
        // 每一步辗转相除操作
        res += num1 / num2
        num1 %= num2
        // 交换两个数
        num1, num2 = num2, num1
    }
    return res
}
```

```C
int countOperations(int num1, int num2) {
    int res = 0;   // 相减操作的总次数
    while (num1 && num2) {
        // 每一步辗转相除操作
        res += num1 / num2;
        num1 %= num2;
        // 交换两个数
        int temp = num1;
        num1 = num2;
        num2 = temp;
    }
    return res;
}
```

```JavaScript
var countOperations = function(num1, num2) {
    let res = 0;   // 相减操作的总次数
    while (num1 && num2) {
        // 每一步辗转相除操作
        res += Math.floor(num1 / num2);
        num1 %= num2;
        // 交换两个数
        [num1, num2] = [num2, num1];
    }
    return res;
};
```

```TypeScript
function countOperations(num1: number, num2: number): number {
    let res = 0;   // 相减操作的总次数
    while (num1 && num2) {
        // 每一步辗转相除操作
        res += Math.floor(num1 / num2);
        num1 %= num2;
        // 交换两个数
        [num1, num2] = [num2, num1];
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn count_operations(mut num1: i32, mut num2: i32) -> i32 {
        let mut res = 0;   // 相减操作的总次数
        while num1 != 0 && num2 != 0 {
            // 每一步辗转相除操作
            res += num1 / num2;
            num1 %= num2;
            // 交换两个数
            std::mem::swap(&mut num1, &mut num2);
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\log max(num_1,num_2))$。即为模拟辗转相除并统计操作次数的时间复杂度。
- 空间复杂度：$O(1)$。
