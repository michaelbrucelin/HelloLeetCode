#### [1759. ͳ��ͬ�����ַ�������Ŀ](https://leetcode.cn/problems/count-number-of-homogenous-substrings/)

�Ѷȣ��е�

����һ���ַ��� `s` ������ `s` �� **ͬ�����ַ���** ����Ŀ�����ڴ𰸿��ܴܺ�ֻ�践�ض� `10^9 + 7` **ȡ��** ��Ľ����

**ͬ���ַ���** �Ķ���Ϊ�����һ���ַ����е������ַ�����ͬ����ô���ַ�������ͬ���ַ�����

**���ַ���** ���ַ����е�һ�������ַ����С�

**ʾ�� 1��**

```
���룺s = "abbcccaa"
�����13
���ͣ�ͬ�����ַ����������У�
"a"   ���� 3 �Ρ�
"aa"  ���� 1 �Ρ�
"b"   ���� 2 �Ρ�
"bb"  ���� 1 �Ρ�
"c"   ���� 3 �Ρ�
"cc"  ���� 2 �Ρ�
"ccc" ���� 1 �Ρ�
3 + 1 + 2 + 1 + 3 + 2 + 1 = 13
```

**ʾ�� 2��**

```
���룺s = "xy"
�����2
���ͣ�ͬ�����ַ����� "x" �� "y" ��
```

**ʾ�� 3��**

```
���룺s = "zzzzz"
�����15
```

**��ʾ��**

-   `1 <= s.length <= 10^5`
-   `s` ��Сд�ַ������