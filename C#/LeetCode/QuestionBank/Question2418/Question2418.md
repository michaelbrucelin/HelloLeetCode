#### [2418\. ���������](https://leetcode.cn/problems/sort-the-people/)

�Ѷȣ���

����һ���ַ������� `names` ����һ���� **������ͬ** ����������ɵ����� `heights` ����������ĳ��Ⱦ�Ϊ `n` ��

����ÿ���±� `i`��`names[i]` �� `heights[i]` ��ʾ�� `i` ���˵����ֺ���ߡ�

�밴��� **����** ˳�򷵻ض�Ӧ���������� `names` ��

**ʾ�� 1��**

```
���룺names = ["Mary","John","Emma"], heights = [180,165,170]
�����["Mary","Emma","John"]
���ͣ�Mary ��ߣ������� Emma �� John ��
```

**ʾ�� 2��**

```
���룺names = ["Alice","Bob","Bob"], heights = [155,185,150]
�����["Bob","Alice","Bob"]
���ͣ���һ�� Bob ��ߣ�Ȼ���� Alice �͵ڶ��� Bob ��
```

**��ʾ��**

-   `n == names.length == heights.length`
-   `1 <= n <= 10^3`
-   `1 <= names[i].length <= 20`
-   `1 <= heights[i] <= 10^5`
-   `names[i]` �ɴ�СдӢ����ĸ���
-   `heights` �е�����ֵ������ͬ
