#### [500\. ������](https://leetcode.cn/problems/keyboard-row/)

�Ѷȣ���

����һ���ַ������� `words` ��ֻ���ؿ���ʹ���� **��ʽ����** ͬһ�е���ĸ��ӡ�����ĵ��ʡ���������ͼ��ʾ��

**��ʽ����** �У�

-   ��һ�����ַ� `"qwertyuiop"` ��ɡ�
-   �ڶ������ַ� `"asdfghjkl"` ��ɡ�
-   ���������ַ� `"zxcvbnm"` ��ɡ�

![](./assets/img/Question0500_01.png)

**ʾ�� 1��**

```
���룺words = ["Hello","Alaska","Dad","Peace"]
�����["Alaska","Dad"]
```

**ʾ�� 2��**

```
���룺words = ["omk"]
�����[]
```

**ʾ�� 3��**

```
���룺words = ["adsdf","sfd"]
�����["adsdf","sfd"]
```

**��ʾ��**

-   `1 <= words.length <= 20`
-   `1 <= words[i].length <= 100`
-   `words[i]` ��Ӣ����ĸ��Сд�ʹ�д��ĸ�����
