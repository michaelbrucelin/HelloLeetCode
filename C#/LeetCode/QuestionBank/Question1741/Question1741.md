#### [1741. ����ÿ��Ա�����ѵ���ʱ��](https://leetcode.cn/problems/find-total-time-spent-by-each-employee/)

�Ѷȣ���

SQL Schema
```sql
Create table If Not Exists Employees(emp_id int, event_day date, in_time int, out_time int)
Truncate table Employees
insert into Employees (emp_id, event_day, in_time, out_time) values ('1', '2020-11-28', '4', '32')
insert into Employees (emp_id, event_day, in_time, out_time) values ('1', '2020-11-28', '55', '200')
insert into Employees (emp_id, event_day, in_time, out_time) values ('1', '2020-12-3', '1', '42')
insert into Employees (emp_id, event_day, in_time, out_time) values ('2', '2020-11-28', '3', '33')
insert into Employees (emp_id, event_day, in_time, out_time) values ('2', '2020-12-9', '47', '74')
```
___

��: `Employees`

```
+-------------+------+
| Column Name | Type |
+-------------+------+
| emp_id      | int  |
| event_day   | date |
| in_time     | int  |
| out_time    | int  |
+-------------+------+
(emp_id, event_day, in_time) ��������������
�ñ���ʾ��Ա���ڰ칫�ҵĳ��������
event_day �Ǵ��¼����������ڣ�in_time ��Ա������칫�ҵ�ʱ�䣬�� out_time �������뿪�칫�ҵ�ʱ�䡣
in_time �� out_time ��ȡֵ��1��1440֮�䡣
��Ŀ��֤ͬһ��û�������¼���ʱ�������ཻ�ģ����ұ�֤ in_time С�� out_time��
```

��дһ��SQL��ѯ�Լ���ÿλԱ��ÿ���ڰ칫�һ��ѵ���ʱ�䣨�Է���Ϊ��λ���� ��ע�⣬��һ��֮�ڣ�ͬһԱ���ǿ��Զ�ν�����뿪�칫�ҵġ� �ڰ칫����һ�ν��������ѵ�ʱ��Ϊout\_time ��ȥ in\_time��

���ؽ������˳����Ҫ��  
��ѯ����ĸ�ʽ���£�

```
Employees table:
+--------+------------+---------+----------+
| emp_id | event_day  | in_time | out_time |
+--------+------------+---------+----------+
| 1      | 2020-11-28 | 4       | 32       |
| 1      | 2020-11-28 | 55      | 200      |
| 1      | 2020-12-03 | 1       | 42       |
| 2      | 2020-11-28 | 3       | 33       |
| 2      | 2020-12-09 | 47      | 74       |
+--------+------------+---------+----------+
Result table:
+------------+--------+------------+
| day        | emp_id | total_time |
+------------+--------+------------+
| 2020-11-28 | 1      | 173        |
| 2020-11-28 | 2      | 30         |
| 2020-12-03 | 1      | 41         |
| 2020-12-09 | 2      | 27         |
+------------+--------+------------+
��Ա 1 �����ν���: �����η����� 2020-11-28 ���ѵ�ʱ��Ϊ (32 - 4) + (200 - 55) = 173, ��һ�η����� 2020-12-03 ���ѵ�ʱ��Ϊ (42 - 1) = 41��
��Ա 2 �����ν���: ��һ�η����� 2020-11-28 ���ѵ�ʱ��Ϊ (33 - 3) = 30,  ��һ�η����� 2020-12-09 ���ѵ�ʱ��Ϊ (74 - 47) = 27��
```
