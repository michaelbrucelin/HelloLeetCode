#### [332\. ���°����г�](https://leetcode.cn/problems/reconstruct-itinerary/)

�Ѷȣ�����

����һ�ݺ����б� `tickets` ������ `tickets[i] = [from_i, to_i]` ��ʾ�ɻ������ͽ���Ļ����ص㡣����Ը��г̽������¹滮����

������Щ��Ʊ������һ���� `JFK`������Ϲ��ʻ��������������������Ը��г̱���� `JFK` ��ʼ��������ڶ�����Ч���г̣����㰴�ֵ����򷵻���С���г���ϡ�

-   ���磬�г� `["JFK", "LGA"]` �� `["JFK", "LGB"]` ��Ⱦ͸�С���������ǰ��

�ٶ����л�Ʊ���ٴ���һ�ֺ�����г̡������еĻ�Ʊ ���붼��һ�� �� ֻ����һ�Ρ�

**ʾ�� 1��**

![](./assets/img/Question0332_01.jpg)

```
���룺tickets = [["MUC","LHR"],["JFK","MUC"],["SFO","SJC"],["LHR","SFO"]]
�����["JFK","MUC","LHR","SFO","SJC"]
```

**ʾ�� 2��**

![](./assets/img/Question0332_02.jpg)

```
���룺tickets = [["JFK","SFO"],["JFK","ATL"],["SFO","ATL"],["ATL","JFK"],["ATL","SFO"]]
�����["JFK","ATL","JFK","SFO","ATL","SFO"]
���ͣ���һ����Ч���г��� ["JFK","SFO","ATL","JFK","ATL","SFO"] ���������ֵ�������������
```

**��ʾ��**

-   `1 <= tickets.length <= 300`
-   `tickets[i].length == 2`
-   `from_i.length == 3`
-   `to_i.length == 3`
-   `from_i` �� `to_i` �ɴ�дӢ����ĸ���
-   `from_i != to_i`
