#### [字典缓存与标记法](https://leetcode.cn/problems/triples-with-bitwise-and-equal-to-zero/solutions/47170/zi-dian-huan-cun-yu-biao-ji-fa-by-amchor/)

-   字典记忆法
-   首先使用字典记录两两相与的值以及出现的次数，从头遍历一遍，找出每个元素可以得到0的那些值

```python
from collections import defaultdict

class Solution:
    def countTriplets(self, A: List[int]) -> int:
        mem = defaultdict(int)
        for n1 in A:
            for n2 in A:
                mem[n1 & n2] += 1
        ans = 0
        for num in A:
            for key, val in mem.items():
                if num & key == 0:
                    ans += val
        return ans
```

-   这种方式效率不够高，考虑这样的情况，如果两个数字相与得到0，那么这个数字有可能和什么数字相与，得到0呢？

这个数字肯定要和之前的数字1所在的位置不同，0所在的位置可以相同，因此，对每一个数字，找出所有的可能增益的点

因此，假设最大数字为7，也就是0-7的8个数字，数字5可以令那些数字与变成0呢？

```txt
5 => 101
0 => 000   可以
1 => 001   不可以
2 => 010   可以
3 => 011   不可以
4 => 100   不可以
5 => 101   不可以
6 => 110   不可以
7 => 111   不可以
```

我们发现，只要是数字5中，为1的位置的数字为0，其他位的数字不管是1还是0，都能够相与变成0

因此，我们将这些进行标记，可以变成`0`就增加`1`

```python
class Solution:
    def countTriplets(self, A: List[int]) -> int:
        mem = [0] * 65536
        mask = (1 << 16) - 1
        # 标记数字能够令哪些数字相与变成0，也就是遍历所有的0所在的位置组成的数字
        for num in A:
            mk = mask ^ num
            i = mk
            while i:
                mem[i] += 1
                # 这一步是关键，位运算找出所有的满足条件的数字
                i = (i - 1) & mk
            # 数字0肯定能够相与变成0
            mem[0] += 1
        res = 0
        for n1 in A:
            for n2 in A:
                res += mem[n1 & n2]
        return res
```

上面的代码超越了`100%`
