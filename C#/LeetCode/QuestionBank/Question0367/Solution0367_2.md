#### [数学](https://leetcode.cn/problems/valid-perfect-square/solutions/1082926/gong-shui-san-xie-yi-ti-shuang-jie-er-fe-g5el/)

我们知道对于一个完全平方数而言，可以写成如下形式：

$$num = n^2 = 1 + 3 + 5 + ... + (2 \times n - 1)$$

因此另外一种做法是对 $num$ 进行不断的奇数试减，如果最终能够减到 $0$，说明 $num$ 可展开成如 $1+3+5+\ldots+(2 \times n-1)$ 的形式，$num$ 为完全平方数。

代码：

```java
class Solution {
    public boolean isPerfectSquare(int num) {
        int x = 1;
        while (num > 0) {
            num -= x;
            x += 2;
        }
        return num == 0;
    }
}
```

-   时间复杂度：$O(\sqrt{n})$
-   空间复杂度：$O(1)$
