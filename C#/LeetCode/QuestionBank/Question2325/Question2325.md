#### [2325\. ������Ϣ](https://leetcode.cn/problems/decode-the-message/)

�Ѷȣ���

�����ַ��� `key` �� `message` ���ֱ��ʾһ��������Կ��һ�μ�����Ϣ������ `message` �Ĳ������£�

1.  ʹ�� `key` �� 26 ��Ӣ��Сд��ĸ��һ�γ��ֵ�˳����Ϊ�滻���е���ĸ **˳��** ��
2.  ���滻������ͨӢ����ĸ����룬�γɶ��ձ�
3.  ���ն��ձ� **�滻** `message` �е�ÿ����ĸ��
4.  �ո� `' '` ���ֲ��䡣

-   ���磬`key = "`_**`hap`**_`p`_**`y bo`**_`y"`��ʵ�ʵļ�����Կ�������ĸ����ÿ����ĸ **����һ��**�����ݴˣ����Եõ����ֶ��ձ�`'h' -> 'a'`��`'a' -> 'b'`��`'p' -> 'c'`��`'y' -> 'd'`��`'b' -> 'e'`��`'o' -> 'f'`����

���ؽ��ܺ����Ϣ��

**ʾ�� 1��**

![](./assets/img/Question2325_01.jpg)

```
���룺key = "the quick brown fox jumps over the lazy dog", message = "vkbs bs t suepuv"
�����"this is a secret"
���ͣ����ձ�����ͼ��ʾ��
��ȡ "the quick brown fox jumps over the lazy dog" ��ÿ����ĸ���״γ��ֿ��Եõ��滻��
```

**ʾ�� 2��**

![](./assets/img/Question2325_02.jpg)

```
���룺key = "eljuxhpwnyrdgtqkviszcfmabo", message = "zwx hnfx lqantp mnoeius ycgk vcnjrdb"
�����"the five boxing wizards jump quickly"
���ͣ����ձ�����ͼ��ʾ��
��ȡ "eljuxhpwnyrdgtqkviszcfmabo" ��ÿ����ĸ���״γ��ֿ��Եõ��滻��
```

**��ʾ��**

-   `26 <= key.length <= 2000`
-   `key` ��СдӢ����ĸ�� `' '` ���
-   `key` ����Ӣ����ĸ����ÿ���ַ���`'a'` �� `'z'`��**����һ��**
-   `1 <= message.length <= 2000`
-   `message` ��СдӢ����ĸ�� `' '` ���
