#### [�ֵ仺�����Ƿ�](https://leetcode.cn/problems/triples-with-bitwise-and-equal-to-zero/solutions/47170/zi-dian-huan-cun-yu-biao-ji-fa-by-amchor/)

-   �ֵ���䷨
-   ����ʹ���ֵ��¼���������ֵ�Լ����ֵĴ�������ͷ����һ�飬�ҳ�ÿ��Ԫ�ؿ��Եõ�0����Щֵ

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

-   ���ַ�ʽЧ�ʲ����ߣ�������������������������������õ�0����ô��������п��ܺ�ʲô�������룬�õ�0�أ�

������ֿ϶�Ҫ��֮ǰ������1���ڵ�λ�ò�ͬ��0���ڵ�λ�ÿ�����ͬ����ˣ���ÿһ�����֣��ҳ����еĿ�������ĵ�

��ˣ������������Ϊ7��Ҳ����0-7��8�����֣�����5��������Щ��������0�أ�

```txt
5 => 101
0 => 000   ����
1 => 001   ������
2 => 010   ����
3 => 011   ������
4 => 100   ������
5 => 101   ������
6 => 110   ������
7 => 111   ������
```

���Ƿ��֣�ֻҪ������5�У�Ϊ1��λ�õ�����Ϊ0������λ�����ֲ�����1����0�����ܹ�������0

��ˣ����ǽ���Щ���б�ǣ����Ա��`0`������`1`

```python
class Solution:
    def countTriplets(self, A: List[int]) -> int:
        mem = [0] * 65536
        mask = (1 << 16) - 1
        # ��������ܹ�����Щ����������0��Ҳ���Ǳ������е�0���ڵ�λ����ɵ�����
        for num in A:
            mk = mask ^ num
            i = mk
            while i:
                mem[i] += 1
                # ��һ���ǹؼ���λ�����ҳ����е���������������
                i = (i - 1) & mk
            # ����0�϶��ܹ�������0
            mem[0] += 1
        res = 0
        for n1 in A:
            for n2 in A:
                res += mem[n1 & n2]
        return res
```

����Ĵ��볬Խ��`100%`
