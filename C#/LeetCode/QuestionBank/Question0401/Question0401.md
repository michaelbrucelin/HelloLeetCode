#### [401\. �������ֱ�](https://leetcode.cn/problems/binary-watch/)

�Ѷȣ���

�������ֱ����� 4 �� LED ���� **Сʱ��0-11��**���ײ��� 6 �� LED ���� **���ӣ�0-59��**��ÿ�� LED ����һ�� 0 �� 1�����λ���Ҳࡣ

-   ���磬����Ķ������ֱ��ȡ `"3:25"` ��

![](./assets/img/Question0401_01.jpg)

_��ͼԴ��[WikiMedia - Binary clock samui moon.jpg](https://commons.m.wikimedia.org/wiki/File:Binary_clock_samui_moon.jpg) �����Э�飺[Attribution-ShareAlike 3.0 Unported (CC BY-SA 3.0)](https://creativecommons.org/licenses/by-sa/3.0/deed.en) ��_

����һ������ `turnedOn` ����ʾ��ǰ���ŵ� LED �����������ض������ֱ���Ա�ʾ�����п���ʱ�䡣����� **������˳��** ���ش𰸡�

Сʱ�������㿪ͷ��

-   ���磬`"01:00"` ����Ч��ʱ�䣬��ȷ��д��Ӧ���� `"1:00"` ��

���ӱ�������λ����ɣ����ܻ����㿪ͷ��

-   ���磬`"10:2"` ����Ч��ʱ�䣬��ȷ��д��Ӧ���� `"10:02"` ��

**ʾ�� 1��**

```
���룺turnedOn = 1
�����["0:01","0:02","0:04","0:08","0:16","0:32","1:00","2:00","4:00","8:00"]
```

**ʾ�� 2��**

```
���룺turnedOn = 9
�����[]
```

**��ʾ��**

-   `0 <= turnedOn <= 10`
