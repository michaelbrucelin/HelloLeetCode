#### [414\. ���������](https://leetcode.cn/problems/third-maximum-number/)

�Ѷȣ���

����һ���ǿ����飬���ش������� **���������** ����������ڣ��򷵻���������������

**ʾ�� 1��**

```
���룺[3, 2, 1]
�����1
���ͣ������������ 1 ��
```

**ʾ�� 2��**

```
���룺[1, 2]
�����2
���ͣ����������������, ���Է��������� 2 ��
```

**ʾ�� 3��**

```
���룺[2, 2, 3, 1]
�����1
���ͣ�ע�⣬Ҫ�󷵻ص������������ָ�����в�ͬ�������ŵ����������
�����д�������ֵΪ 2 ���������Ƕ��ŵڶ��������в�ͬ�������ŵ��������Ϊ 1 ��
```

**��ʾ��**

-   `1 <= nums.length <= 10^4`
-   `-2^31 <= nums[i] <= 2^31 - 1`

**���ף�** �������һ��ʱ�临�Ӷ� `O(n)` �Ľ��������