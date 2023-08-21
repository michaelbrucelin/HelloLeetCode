#### 模拟

自左向右遍历$start$与$target$，当遍历到$i$处时，假定$start[id]==target[id], ~ id < i$，

- $start[i] ==  L ~ \&\& ~ target[i] ==  R$，返回$false$
- $start[i] ==  R ~ \&\& ~ target[i] ==  L$，返回$false$
- $start[i] ==  L ~ \&\& ~ target[i] == \_$，返回$false$
- $start[i] == \_ ~ \&\& ~ target[i] ==  L$
  - $start$向右找到第一个$L$（忽略$\_$），然后交换，如果第一个非$\_$的字符是$R$，返回$false$
- $start[i] ==  R ~ \&\& ~ target[i] == \_$，
  - $start$向右找到第一个$\_$（忽略$R$），然后交换，如果第一个非$R$的字符是$L$，返回$false$
- $start[i] == \_ ~ \&\& ~ target[i] ==  R$，返回$false$
