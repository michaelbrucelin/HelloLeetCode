#### [884\. ���仰�еĲ���������](https://leetcode.cn/problems/uncommon-words-from-two-sentences/)

�Ѷȣ���

**����** ��һ���ɿո�ָ��ĵ��ʡ�ÿ�� **����** ����Сд��ĸ��ɡ�

���ĳ������������һ��������ǡ�ó���һ�Σ�����һ��������ȴ **û�г���** ����ô������ʾ��� **��������** ��

�������� **����** `s1` �� `s2` ���������� **�����õ���** ���б��������б��е��ʿ��԰� **����˳��** ��֯��

**ʾ�� 1��**

```
���룺s1 = "this apple is sweet", s2 = "this apple is sour"
�����["sweet","sour"]
```

**ʾ�� 2��**

```
���룺s1 = "apple apple", s2 = "banana"
�����["banana"]
```

**��ʾ��**

-   `1 <= s1.length, s2.length <= 200`
-   `s1` �� `s2` ��СдӢ����ĸ�Ϳո����
-   `s1` �� `s2` ������ǰ����β��ո�
-   `s1` �� `s2` �е����е��ʼ���ɵ����ո�ָ�