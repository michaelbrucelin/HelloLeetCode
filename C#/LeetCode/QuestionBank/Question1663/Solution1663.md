#### 数学分析

**结论：** 结果必然前缀全是`a`，后缀全是`z`，中间至多有一个非`a`，`z`的字符。
**证明：**
1. 如果有两个非`a`，`z`的字符（小的再前面，小的在后面可以交换过来）
    - 那么前面的减`1`后面的加`1`，`k`值不变，而且字典序更小
    - 反复操作可以将其中一个变为`a`或`z`，或者同时变成`a`和`z`

所以，前面描述的结论是正确的。

**求解：**
1. 如果结果不含非`a`，`z`的字符，假设有`x`个`a`，`y`个`z`，则
$$\left\{\begin{array}{lr}x+26y=k\\x+y=n\\x \ge 0,y \ge 0\end{array}\right.$$
得出解
$$\left\{\begin{array}{lr}x=n-\dfrac{k-n}{25}\\y=\dfrac{k-n}{25}\end{array}\right.$$
2. 如果结果含非`a`，`z`的字符，假设有`x`个`a`，`y`个`z`，中间的字符为`z`，则
$$\left\{\begin{array}{lr}x+26y+z=k\\x+y+1=n\\x \ge 0, y \ge 0, 1 \lt z \lt 26\end{array}\right.$$
得出解
$$\left\{\begin{array}{lr}x=(n-1)-\dfrac{k-z-(n-1)}{25}\\y=\dfrac{k-z-(n-1)}{25}\\x \ge 0, y \ge 0, 1 \lt z \lt 26\end{array}\right.$$

**更方便的解：鸡兔同笼**
假设整个字符串全是`a`，那么值是`a`，离`k`差`k-a`，从后向前向前调整，每把一个`a`调整为`z`，值增长`25`，所以... ...。
