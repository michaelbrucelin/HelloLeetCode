#### [�����㷨���1�ĸ���](https://leetcode.cn/problems/number-of-1-bits/solutions/142876/fen-zhi-suan-fa-qiu-jie-1de-ge-shu-by-orzyt/)

����һ�ֻ��ڡ����Ρ����㷨��ͳ��"1"�ĸ�����

#### ˼·

������������Ҫͳ��`1001 1011 0101 0010 1001 1111 0001 0010`�С�1���ĸ�����

![](./assets/img/Solution0191_4_01.png)

���ڷ��ε�˼�룬������ͳ�Ƴ�ÿ`2`λ�ж��ٸ�1����ͼ�еڢٲ���ʾ��

��ÿ`2`λ�Ľ���ϲ���ͳ�Ƴ�ÿ`4`λ�ж��ٸ�1����ͼ�еڢڲ���ʾ��

�ٽ�ÿ`4`λ�Ľ���ϲ���ͳ�Ƴ�ÿ`8`λ�ж��ٸ�1����ͼ�еڢ۲���ʾ��

���Ž�ÿ`8`λ�Ľ���ϲ���ͳ�Ƴ�ÿ`16`λ�ж��ٸ�1����ͼ�еڢܲ���ʾ��

���ÿ`16`λ�Ľ���ϲ���ͳ�Ƴ�ÿ`32`λ�ж��ٸ�1����ͼ�еڢݲ���ʾ�����ɵõ��𰸡�

---

���ˣ�����һ��ֱ�۵ĸ��ܺ����ڿ������ʵ�ֺϲ��Ĺ��̡�

��ʼ��nnnΪ�� `1001 1011 0101 0010 1001 1111 0001 0010`��

�ڢٲ�Ľ��Ϊ��`0101 0110 0101 0001 0101 1010 0001 0001`�������ô�õ���?

һ����伴�ɸ㶨��

`n = (n & (0x55555555)) + ((n >> 1) & (0x55555555));`

��������ľ�У�������������һ������������ʲô��

---

���ȣ�ʮ�����Ƶĳ���`0x55555555`ת��Ϊ��������`0101 0101 0101 0101 0101 0101 0101 0101 0101`��

��ô��`n & 0x55555555`�Ϳ�����ȡnnnż��λ�ϵ�1��

![](./assets/img/Solution0191_4_02.png)

`(n >> 1) & 0x55555555`�Ϳ�����ȡnnn����λ�ϵ�1��

![](./assets/img/Solution0191_4_03.png)

���`n = (n & (0x55555555)) + ((n >> 1) & (0x55555555))`�������������ӣ����ɵõ�ÿ��λ�ϡ�1���ĸ�����

![](./assets/img/Solution0191_4_04.png)

��͵õ��ڢٲ�Ľ������

![](./assets/img/Solution0191_4_05.png)

---

���ڿ�����ô�õ��ڢڲ�Ľ����

��Ȼ�õ�ÿ2λ�Ľ����ͨ������`0101 0101 0101 0101 0101 0101 0101 0101`����`0x55555555`�õ��ġ�

��ô���һ�£�ÿ4λ��Ӧ����ͨ������`0011 0011 0011 0011 0011 0011 0011 0011`����`0x3333333`�õ���

������һ�㣬��ʱnnn����Ϊ`0101 0110 0101 0001 0101 1010 0001 0001`��

��ô��`n & 0x33333333`�͵��ڣ�

![](./assets/img/Solution0191_4_06.png)

`(n >> 2) & 0x33333333` ��ע�⣬����Ҫ������λ���͵��ڣ�

![](./assets/img/Solution0191_4_07.png)

���`n = (n & (0x33333333)) + ((n >> 2) & (0x33333333));`��Ӽ��ɵõ�ÿ��λ�ϡ�1���ĸ�����

![](./assets/img/Solution0191_4_08.png)

��͵õ��ڢڲ�Ľ������

![](./assets/img/Solution0191_4_09.png)

---

�Դ�����...

�ϲ�ÿ4λ���õ�ÿ8λ�Ľ��������Ϊ��`0000 1111 0000 1111 0000 1111 0000 1111`����`0x0F0F0F0F`��

�����`n = (n & (0x0F0F0F0F)) + ((n >> 4) & (0x0F0F0F0F));`

![](./assets/img/Solution0191_4_10.png)

---

�ϲ�ÿ8λ���õ�ÿ16λ�Ľ��������Ϊ��`0000 0000 1111 1111 0000 0000 1111 1111`����`0x00FF00FF`��

�����`n = (n & (0x00FF00FF)) + ((n >> 8) & (0x00FF00FF));`

![](./assets/img/Solution0191_4_11.png)

---

�ϲ�ÿ16λ���õ�ÿ32λ�Ľ��������Ϊ��`0000 0000 0000 0000 1111 1111 1111 1111`����`0x0000FFFF`��

�����`n = (n & (0x0x0000FFFF)) + ((n >> 16) & (0x0x0000FFFF));`

![](./assets/img/Solution0191_4_12.png)

���õ� `n = 16`�����ʼ�����32λ��`1001 1011 0101 0010 1001 1111 0001 0010`����16����1����

#### ����

```cpp
class Solution {
public:
    int hammingWeight(uint32_t n) {
        n = (n & (0x55555555)) + ((n >> 1) & (0x55555555));
        n = (n & (0x33333333)) + ((n >> 2) & (0x33333333));
        n = (n & (0x0F0F0F0F)) + ((n >> 4) & (0x0F0F0F0F));
        n = (n & (0x00FF00FF)) + ((n >> 8) & (0x00FF00FF));
        n = (n & (0x0000FFFF)) + ((n >> 16) & (0x0000FFFF));
        return n;
    }
};
```