#### [LCP 02. ��ʽ����](https://leetcode.cn/problems/deep-dark-fraction/)

�Ѷȣ���115�ղط����л�ΪӢ�Ľ��ն�̬����

��һ��ͬѧ��ѧϰ��ʽ������Ҫ��һ�����������������������ܰ�������

![](./assets/img/Question0002_01.jpg)

��������������ͼ�ķ�ʽ���ڱ����У�����ϵ�����Ǵ��ڵ���0��������

�����`cont`������������ϵ����`cont[0]`������ͼ��`a<sub>0</sub>`���Դ����ƣ�������һ������Ϊ2������`[n, m]`��ʹ����������ֵ����`n / m`����`n, m`���Լ��Ϊ1��

**ʾ�� 1��**

```
���룺cont = [3, 2, 0, 2]
�����[13, 4]
���ͣ�ԭ�������ȼ���3 + (1 / (2 + (1 / (0 + 1 / 2))))��ע��[26, 8], [-13, -4]��������ȷ�𰸡�
```

**ʾ�� 2��**

```
���룺cont = [0, 0, 3]
�����[3, 1]
���ͣ�����������������ĸΪ1���ɡ�
```

**���ƣ�**

1.  `cont[i] >= 0`
2.  `1 <= cont�ĳ��� <= 10`
3.  `cont`���һ��Ԫ�ز�����0
4.  �𰸵�`n, m`��ȡֵ���ܱ�32λint���ʹ��£���������`2 ^ 31 - 1`����