#### [203\. �Ƴ�����Ԫ��](https://leetcode.cn/problems/remove-linked-list-elements/)

�Ѷȣ���

����һ��������ͷ�ڵ� `head` ��һ������ `val` ������ɾ���������������� `Node.val == val` �Ľڵ㣬������ **�µ�ͷ�ڵ�** ��

**ʾ�� 1��**

![](./assets/img/Question0203_01.jpg)

```
���룺head = [1,2,6,3,4,5,6], val = 6
�����[1,2,3,4,5]
```

**ʾ�� 2��**

```
���룺head = [], val = 1
�����[]
```

**ʾ�� 3��**

```
���룺head = [7,7,7,7], val = 7
�����[]
```

**��ʾ��**

-   �б��еĽڵ���Ŀ�ڷ�Χ `[0, 10^4]` ��
-   `1 <= Node.val <= 50`
-   `0 <= val <= 50`