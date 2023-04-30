#### 数学

对于$target$，$i~(i<target)$，如果存在$j~(j>i)$使得$i+(i+1)+\dots+(j-1)+j = target$，那么此时的$j$是可以直接解出来的。

$$\begin{aligned}
& \sum_{n=i}^{n=j}n & = & target \\
\leftrightarrow & \frac{(i+j)(j-i+1)}{2} & = & target \\
\leftrightarrow & (i+j)(j-i+1) & = & 2target \\
\leftrightarrow & j^{2} + j - i^{2} + i & = & 2target \\
\leftrightarrow & j^{2} + j + \frac{1}{4} & = & 2target + i^{2} - i + \frac{1}{4} \\
\leftrightarrow & (j + \frac{1}{2})^{2} & = & 2target + (i - \frac{1}{2})^{2} \\
\leftrightarrow & j & = & \sqrt{2target + (i - \frac{1}{2})^{2}} - \frac{1}{2}
\end{aligned}$$

然后验证结果是不是整数即可。
