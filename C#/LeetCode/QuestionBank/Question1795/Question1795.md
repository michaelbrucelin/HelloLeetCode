#### [1795. ÿ����Ʒ�ڲ�ͬ�̵�ļ۸�](https://leetcode.cn/problems/rearrange-products-table/)

�Ѷȣ���

SQL Schema
```sql
Create table If Not Exists Products (product_id int, store1 int, store2 int, store3 int)
Truncate table Products
insert into Products (product_id, store1, store2, store3) values ('0', '95', '100', '105')
insert into Products (product_id, store1, store2, store3) values ('1', '70', 'None', '80')
```
___

��`Products`

```
+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| product_id  | int     |
| store1      | int     |
| store2      | int     |
| store3      | int     |
+-------------+---------+
���ű��������product_id����ƷId����
ÿ�д洢����һ��Ʒ�ڲ�ͬ�̵�store1, store2, store3�ļ۸�
�����һ��Ʒ���̵���û�г��ۣ���ֵ��Ϊnull��
```

�����ع� `Products` ����ѯÿ����Ʒ�ڲ�ͬ�̵�ļ۸�ʹ������ĸ�ʽ��Ϊ`(product_id, store, price)` �������һ��Ʒ���̵���û�г��ۣ��������һ�С�

���������е� **˳����Ҫ��** ��

��ѯ�����ʽ��ο�����ʾ����

**ʾ�� 1��**

```
���룺
Products table:
+------------+--------+--------+--------+
| product_id | store1 | store2 | store3 |
+------------+--------+--------+--------+
| 0          | 95     | 100    | 105    |
| 1          | 70     | null   | 80     |
+------------+--------+--------+--------+
�����
+------------+--------+-------+
| product_id | store  | price |
+------------+--------+-------+
| 0          | store1 | 95    |
| 0          | store2 | 100   |
| 0          | store3 | 105   |
| 1          | store1 | 70    |
| 1          | store3 | 80    |
+------------+--------+-------+
���ͣ�
��Ʒ0��store1��store2,store3�ļ۸�ֱ�Ϊ95,100,105��
��Ʒ1��store1��store3�ļ۸�ֱ�Ϊ70,80����store2�޷��򵽡�
```
