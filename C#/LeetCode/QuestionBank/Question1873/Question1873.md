#### [1873. �������⽱��](https://leetcode.cn/problems/calculate-special-bonus/)

�Ѷȣ���

SQL Schema
```sql
Create table If Not Exists Employees (employee_id int, name varchar(30), salary int)
Truncate table Employees
insert into Employees (employee_id, name, salary) values ('2', 'Meir', '3000')
insert into Employees (employee_id, name, salary) values ('3', 'Michael', '3800')
insert into Employees (employee_id, name, salary) values ('7', 'Addilyn', '7400')
insert into Employees (employee_id, name, salary) values ('8', 'Juan', '6100')
insert into Employees (employee_id, name, salary) values ('9', 'Kannon', '7700')
```
___

��: `Employees`

```
+-------------+---------+
| ����        | ����     |
+-------------+---------+
| employee_id | int     |
| name        | varchar |
| salary      | int     |
+-------------+---------+
employee_id ��������������
�˱��ÿһ�и����˹�Աid �����ֺ�нˮ��

```

д��һ��SQL ��ѯ��䣬����ÿ����Ա�Ľ������һ����Ա��id�����������������ֲ�����'M'��ͷ����ô���Ľ����������ʵ�100%�����򽱽�Ϊ0��

Return the result table ordered by `employee_id`.

���صĽ�����밴��`employee_id`����

��ѯ�����ʽ�������������ʾ��

**ʾ�� 1:**

```
���룺
Employees ��:
+-------------+---------+--------+
| employee_id | name    | salary |
+-------------+---------+--------+
| 2           | Meir    | 3000   |
| 3           | Michael | 3800   |
| 7           | Addilyn | 7400   |
| 8           | Juan    | 6100   |
| 9           | Kannon  | 7700   |
+-------------+---------+--------+
�����
+-------------+-------+
| employee_id | bonus |
+-------------+-------+
| 2           | 0     |
| 3           | 0     |
| 7           | 7400  |
| 8           | 0     |
| 9           | 7700  |
+-------------+-------+
���ͣ�
��Ϊ��Աid��ż�������Թ�Աid ��2��8��������Ա�õ��Ľ�����0��
��ԱidΪ3����Ϊ����������'M'��ͷ�����ԣ�������0��
�����Ĺ�Ա�õ��˰ٷ�֮�ٵĽ���
```
