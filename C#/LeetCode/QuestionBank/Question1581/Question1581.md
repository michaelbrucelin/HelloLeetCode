#### [1581. ����ȴδ���й����׵Ĺ˿�](https://leetcode.cn/problems/customer-who-visited-but-did-not-make-any-transactions/)

�Ѷȣ���

SQL Schema
```sql
Create table If Not Exists Visits(visit_id int, customer_id int)
Create table If Not Exists Transactions(transaction_id int, visit_id int, amount int)
Truncate table Visits
insert into Visits (visit_id, customer_id) values ('1', '23')
insert into Visits (visit_id, customer_id) values ('2', '9')
insert into Visits (visit_id, customer_id) values ('4', '30')
insert into Visits (visit_id, customer_id) values ('5', '54')
insert into Visits (visit_id, customer_id) values ('6', '96')
insert into Visits (visit_id, customer_id) values ('7', '54')
insert into Visits (visit_id, customer_id) values ('8', '54')
Truncate table Transactions
insert into Transactions (transaction_id, visit_id, amount) values ('2', '5', '310')
insert into Transactions (transaction_id, visit_id, amount) values ('3', '5', '300')
insert into Transactions (transaction_id, visit_id, amount) values ('9', '5', '200')
insert into Transactions (transaction_id, visit_id, amount) values ('12', '1', '910')
insert into Transactions (transaction_id, visit_id, amount) values ('13', '2', '970')
```
___

��`Visits`

```
+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| visit_id    | int     |
| customer_id | int     |
+-------------+---------+
visit_id �Ǹñ��������
�ñ�����йع��ٹ��������ĵĹ˿͵���Ϣ��
```

��`Transactions`

```
+----------------+---------+
| Column Name    | Type    |
+----------------+---------+
| transaction_id | int     |
| visit_id       | int     |
| amount         | int     |
+----------------+---------+
transaction_id �Ǵ˱��������
�˱���� visit_id �ڼ���еĽ��׵���Ϣ��
```

��һЩ�˿Ϳ��ܹ���˹������ĵ�û�н��н��ס������дһ�� SQL ��ѯ����������Щ�˿͵� ID ���Լ�����ֻ��˲����׵Ĵ�����

������ **�κ�˳��** ����Ľ����

��ѯ�����ʽ��������ʾ��

**ʾ�� 1��**

```
����:
Visits
+----------+-------------+
| visit_id | customer_id |
+----------+-------------+
| 1        | 23          |
| 2        | 9           |
| 4        | 30          |
| 5        | 54          |
| 6        | 96          |
| 7        | 54          |
| 8        | 54          |
+----------+-------------+
Transactions
+----------------+----------+--------+
| transaction_id | visit_id | amount |
+----------------+----------+--------+
| 2              | 5        | 310    |
| 3              | 5        | 300    |
| 9              | 5        | 200    |
| 12             | 1        | 910    |
| 13             | 2        | 970    |
+----------------+----------+--------+
���:
+-------------+----------------+
| customer_id | count_no_trans |
+-------------+----------------+
| 54          | 2              |
| 30          | 1              |
| 96          | 1              |
+-------------+----------------+
����:
ID = 23 �Ĺ˿��������һ�ι������ģ����� ID = 12 �ķ����ڼ������һ�ʽ��ס�
ID = 9 �Ĺ˿��������һ�ι������ģ����� ID = 13 �ķ����ڼ������һ�ʽ��ס�
ID = 30 �Ĺ˿�����ȥ���������ģ�����û�н����κν��ס�
ID = 54 �Ĺ˿���������˹������ġ��� 2 �η����У�����û�н����κν��ף��� 1 �η����У����ǽ����� 3 �ν��ס�
ID = 96 �Ĺ˿�����ȥ���������ģ�����û�н����κν��ס�
������������ID Ϊ 30 �� 96 �Ĺ˿�һ��û�н����κν��׾�ȥ�˹������ġ��˿� 54 Ҳ���η����˹������Ĳ���û�н����κν��ס�
```
