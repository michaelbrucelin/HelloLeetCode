#### [183\. �Ӳ������Ŀͻ�](https://leetcode.cn/problems/customers-who-never-order/)

�Ѷȣ���

SQL Schema
```sql
Create table If Not Exists Customers (id int, name varchar(255))
Create table If Not Exists Orders (id int, customerId int)
Truncate table Customers
insert into Customers (id, name) values ('1', 'Joe')
insert into Customers (id, name) values ('2', 'Henry')
insert into Customers (id, name) values ('3', 'Sam')
insert into Customers (id, name) values ('4', 'Max')
Truncate table Orders
insert into Orders (id, customerId) values ('1', '3')
insert into Orders (id, customerId) values ('2', '1')
```
___

ĳ��վ����������`Customers` ��� `Orders` ����дһ�� SQL ��ѯ���ҳ����дӲ������κζ����Ŀͻ���

`Customers` ��

```
+----+-------+
| Id | Name  |
+----+-------+
| 1  | Joe   |
| 2  | Henry |
| 3  | Sam   |
| 4  | Max   |
+----+-------+
```

`Orders` ��

```
+----+------------+
| Id | CustomerId |
+----+------------+
| 1  | 3          |
| 2  | 1          |
+----+------------+
```

����������������Ĳ�ѯӦ���أ�

```
+-----------+
| Customers |
+-----------+
| Henry     |
| Max       |
+-----------+
```
