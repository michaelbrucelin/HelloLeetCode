#### 数学题

换一个思路求解，思路与Solution1802.md有些相似。

首先，将数组初始化，每一项都初始化为1，此时其和是$n$；

1. 如果$maxSum < n$，无解；
2. 如果$maxSum = n$，有解，解为$1$；
3. 如果$maxSum > n$，有解，下面求其解，假定$maxSum - n = k$，显然$k \ge 1$
    1. 将$k$分配给以$index$为中心的$m$个元素；
        1. 可能的最小结果：这些元素的值为：$[1, 2, ..., (max-1), max, (max-1), ..., 2, 1]$，相比较数组的初始情况，和增加了$1 + 2 + ... + (x-1) + x + (x-1) + ... + 2 + 1 = x^2$，所以，$x \le \sqrt{k}$；
        2. 可能的最大结果：这些元素的值为：$[max-(n-1), max-(n-2), ... max-1, max]$，相比较数组的初始情况，和增加了$x-(n-1) + x-(n-2) + ... (x-1) + x = \dfrac{1}{2}n(2x-n+1)$，所以，$x \le \dfrac{1}{2}(\dfrac{2k}{n}+n-1)$；
    2. 令解为$x$，则
        1. $\sqrt{k}+1 \le x \le \dfrac{1}{2}(\dfrac{2k}{n}+n+1)$；
        2. 以$index$为中心，向两边递减，直到递减到$1$或者数组边界，增加的值小于等于$maxSum$；
            - 如果$x \le index+2$，左侧增加$\dfrac{1}{2}x(x-1)$，否则，左侧增加$\dfrac{1}{2}(2x-index-2)(index+1)$；
            - 如果$x \le n-index+1$，右侧增加$\dfrac{1}{2}x(x-1)$，否则，右侧增加$\dfrac{1}{2}(n-index)(2x+index-n-1)$；
            - 所以：
            - 如果$x \le index+2$ 且 $x \le n-index+1$，总共增加$x(x-1)-(x-1) = (x-1)^2$；
            - 如果$x \gt index+2$ 且 $x \le n-index+1$，总共增加$\dfrac{1}{2}((2x-index-2)(index+1)+x(x-1))-(x-1) \\ = \dfrac{1}{2}((2x-index-2)(index+1)+(x-2)(x-1))$；
            - 如果$x \le index+2$ 且 $x \gt n-index+1$，总共增加$\dfrac{1}{2}((n-index)(2x+index-n-1)+x(x-1))-(x-1) \\ = \dfrac{1}{2}((n-index)(2x+index-n-1)+(x-2)(x-1))$；
            - 如果$x \gt index+2$ 且 $x \gt n-index+1$，总共增加$\dfrac{1}{2}((2x-index-2)(index+1)+(n-index)(2x+index-n-1))-(x-1)$；
        3. 由以上两点即可通过二分法找出解；
