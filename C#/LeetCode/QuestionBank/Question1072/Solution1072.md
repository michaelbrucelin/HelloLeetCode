#### 逐列增加

**<span style='color:red'>代码逻辑与此文档的描述不一致，此文档是错误的，懒得改了。</span>**

可以采用类似于DP的方式，假定一开始只有一列，然后一列一列向上加的方式来获取结果。

首先，先明确一下几点：

1. 所有列都翻转与所有列都不翻转，结果是一样的
    - 所以至少有一列不需要翻转
    - 无论哪一列不翻转都可以，所以就假定第一列不需要翻转
        - 如果最终结果第一列翻转了，那么再将所有列翻转一下，结果不变，第一列相当于没有翻转
2. 如果当前有$N$列，翻转部分列之后最多有$R$行相同，那么第$N+1$列加入后，只有可能把原先相同的行变得不同，而不会让原先不同的行变得相同
    - 第$N+1$只有$2$中选择：**翻转**与**不翻转**，而且无论翻不翻转，最终的结果一定$\le R$
    - 只需要考虑前$N$列相同的行即可，不同的行永远不会相同了

##### 代码逻辑

假定$matrix$有$m$行，$n$列，使用$list = List<int[]>$与$dic = SortedDictionary<int, List<int[]>>$做缓存

1. 最开始只有一列，所有行都满足要求，$list$中只有一项：${0, 1, 2,...m-1}$
2. 假设已经完成了$N$列，$list$中缓存了多个索引数组，长度相等（假定为$R$），即前$N$列可能的最多的相同的行的索引
3. 第$N+1$列加入，遍历$list$中的每一个索引数组，检查第$N+1$列对应位置与第一列对应位置的是否相同，记相同的数目是$R_1$，则不相同的为$R-R_1$，取$R-1$与$R-R_1$中比较大的，将其对应的的值加入到$dic$中
    然后$list$更新为$dic.Last$，$dic.Clear()$