#### 数学

逻辑与Solution2337.md中描述的一样，只是抽象为数学计算。

自左向右遍历$start$与$target$，找到各自的第$k$个非$\_$字符：

- $start[i] <> target[j]$，返回$false$
- $start[i] == target[j] == L$，如果$i \ge j$继续遍历，否则返回$false$
- $start[i] == target[j] == R$，如果$i \le j$继续遍历，否则返回$false$

证明略。
