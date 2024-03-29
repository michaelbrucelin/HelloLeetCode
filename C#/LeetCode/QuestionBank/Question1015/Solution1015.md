#### 模拟乘法

首先，如果$k$是偶数或者以$5$结尾的数，显然一定无解。**如果$k$的结尾是$1$, $3$, $7$, $9$就一定有解吗？怎么证明或找个反例。**

下面构造两个数组：
首先是一个$1$维数组，$map1$

```C
key:   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |
value: | 1 | 0 | 9 | 8 | 7 | 6 | 5 | 4 | 3 | 2 |
```

然后是一个$2$维数组，$map2$

```C
key:   3
value: key:   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |
       value: | 0 | 7 | 4 | 1 | 8 | 5 | 2 | 9 | 6 | 3 |
key:   7
value: key:   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |
       value: | 0 | 3 | 6 | 9 | 2 | 5 | 8 | 1 | 4 | 7 |
key:   9
value: key:   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |
       value: | 0 | 9 | 8 | 7 | 6 | 5 | 4 | 3 | 2 | 1 |
```

下面用一个例子来说明怎样模拟乘法。

假设$k = 7$。

```C
                        7  // k = 7，查询map2[7][1]知道需要乘以3
                     *  3
                      2 1  // 乘以3后结果是21，        2需要处理，查询map2[7][map1[2]]知道需要乘以7

                        7
                   *  7 3
                    5 1 1  // 乘以73后结果是511，      5需要处理，查询map2[7][map1[5]]知道需要乘以8

                        7
                 *  8 7 3
                  6 1 1 1  // 乘以873后结果是6111，    6需要处理，查询map2[7][map1[6]]知道需要乘以5

                        7
               *  5 8 7 3
                4 1 1 1 1  // 乘以5873后结果是41111，  4需要处理，查询map2[7][map1[4]]知道需要乘以1

                        7
             *  1 5 8 7 3
              1 1 1 1 1 1  // 乘以15873后结果是111111，done
```
