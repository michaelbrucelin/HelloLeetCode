### Solution1734

#### 推理

假设原排列为：$[x_1, x_2, x_3 \dots x_n]$，
则$encoded$为：$[x_1\oplus x_2, x_2\oplus x_3, x_3\oplus x_4, \dots x_{n-1}\oplus x_n]$
则$encoded$的前缀异或和为：$xors = [x_1\oplus x_2, x_1\oplus x_3, x_1\oplus x_4, \dots x_1\oplus x_n]$
将$xors$与序列$[1,2,3,\dots n]$求异或和为$n-2$个$x_1$的异或值，由于限定的$n$为奇数，所以其结果就是$x_1$
得到了$x_1$，其他值就可以依次计算出来了。
