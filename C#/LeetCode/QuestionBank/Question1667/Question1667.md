#### [1667. �޸����е�����](https://leetcode.cn/problems/fix-names-in-a-table/)

�Ѷȣ���

SQL Schema
```sql
Create table If Not Exists Users (user_id int, name varchar(40))
Truncate table Users
insert into Users (user_id, name) values ('1', 'aLice')
insert into Users (user_id, name) values ('2', 'bOB')
```
___

�� `Users`

```
+----------------+---------+
| Column Name    | Type    |
+----------------+---------+
| user_id        | int     |
| name           | varchar |
+----------------+---------+
user_id �Ǹñ��������
�ñ�����û��� ID �����֡����ֽ���Сд�ʹ�д�ַ���ɡ�
```

��дһ�� SQL ��ѯ���޸����֣�ʹ��ֻ�е�һ���ַ��Ǵ�д�ģ����඼��Сд�ġ�

���ذ� `user_id` ����Ľ����

��ѯ�����ʽʾ�����¡�

**ʾ�� 1��**

```
���룺
Users table:
+---------+-------+
| user_id | name  |
+---------+-------+
| 1       | aLice |
| 2       | bOB   |
+---------+-------+
�����
+---------+-------+
| user_id | name  |
+---------+-------+
| 1       | Alice |
| 2       | Bob   |
+---------+-------+
```
