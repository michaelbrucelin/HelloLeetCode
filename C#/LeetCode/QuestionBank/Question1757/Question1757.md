#### [1757. �ɻ����ҵ�֬�Ĳ�Ʒ](https://leetcode.cn/problems/recyclable-and-low-fat-products/)

�Ѷȣ���

SQL Schema
```sql
Create table If Not Exists Products (product_id int, low_fats ENUM('Y', 'N'), recyclable ENUM('Y','N'))
Truncate table Products
insert into Products (product_id, low_fats, recyclable) values ('0', 'Y', 'N')
insert into Products (product_id, low_fats, recyclable) values ('1', 'Y', 'Y')
insert into Products (product_id, low_fats, recyclable) values ('2', 'N', 'Y')
insert into Products (product_id, low_fats, recyclable) values ('3', 'Y', 'Y')
insert into Products (product_id, low_fats, recyclable) values ('4', 'N', 'N')
```
___

��`Products`

```
+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| product_id  | int     |
| low_fats    | enum    |
| recyclable  | enum    |
+-------------+---------+
product_id ��������������
low_fats ��ö�����ͣ�ȡֵΪ�������� ('Y', 'N')������ 'Y' ��ʾ�ò�Ʒ�ǵ�֬��Ʒ��'N' ��ʾ���ǵ�֬��Ʒ��
recyclable ��ö�����ͣ�ȡֵΪ�������� ('Y', 'N')������ 'Y' ��ʾ�ò�Ʒ�ɻ��գ��� 'N' ��ʾ���ɻ��ա�
```

д�� SQL ��䣬���Ҽ��ǵ�֬���ǿɻ��յĲ�Ʒ��š�

���ؽ�� **��˳��Ҫ��** ��

��ѯ�����ʽ��������ʾ��

```
Products ��
+-------------+----------+------------+
| product_id  | low_fats | recyclable |
+-------------+----------+------------+
| 0           | Y        | N          |
| 1           | Y        | Y          |
| 2           | N        | Y          |
| 3           | Y        | Y          |
| 4           | N        | N          |
+-------------+----------+------------+
Result ��
+-------------+
| product_id  |
+-------------+
| 1           |
| 3           |
+-------------+
ֻ�в�Ʒ id Ϊ 1 �� 3 �Ĳ�Ʒ�����ǵ�֬���ǿɻ��յĲ�Ʒ��
```
