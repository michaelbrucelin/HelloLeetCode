#### [180\. �������ֵ�����](https://leetcode.cn/problems/consecutive-numbers/)

�Ѷȣ��е�

SQL Schema
```sql
Create table If Not Exists Logs (id int, num int)
Truncate table Logs
insert into Logs (id, num) values ('1', '1')
insert into Logs (id, num) values ('2', '1')
insert into Logs (id, num) values ('3', '1')
insert into Logs (id, num) values ('4', '2')
insert into Logs (id, num) values ('5', '1')
insert into Logs (id, num) values ('6', '2')
insert into Logs (id, num) values ('7', '2')
```
___

��`Logs`

```
+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| id          | int     |
| num         | varchar |
+-------------+---------+
id ��������������
```

��дһ�� SQL ��ѯ�������������������������ε����֡�

���صĽ�����е����ݿ��԰� **����˳��** ���С�

��ѯ�����ʽ�������������ʾ��

**ʾ�� 1:**

```
���룺
Logs ��
+----+-----+
| Id | Num |
+----+-----+
| 1  | 1   |
| 2  | 1   |
| 3  | 1   |
| 4  | 2   |
| 5  | 1   |
| 6  | 2   |
| 7  | 2   |
+----+-----+
�����
Result ��
+-----------------+
| ConsecutiveNums |
+-----------------+
| 1               |
+-----------------+
���ͣ�1 ��Ψһ���������������ε����֡�
```
