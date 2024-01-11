### [1731\. 每位经理的下属员工数量](https://leetcode.cn/problems/the-number-of-employees-which-report-to-each-employee/)

难度：简单

SQL Schema

```sql
Create table If Not Exists Employees(employee_id int, name varchar(20), reports_to int, age int)
Truncate table Employees
insert into Employees (employee_id, name, reports_to, age) values ('9', 'Hercy', 'None', '43')
insert into Employees (employee_id, name, reports_to, age) values ('6', 'Alice', '9', '41')
insert into Employees (employee_id, name, reports_to, age) values ('4', 'Bob', '9', '36')
insert into Employees (employee_id, name, reports_to, age) values ('2', 'Winston', 'None', '37')
```

Pandas Schema

```python
data = [[9, 'Hercy', None, 43], [6, 'Alice', 9, 41], [4, 'Bob', 9, 36], [2, 'Winston', None, 37]]
employees = pd.DataFrame(data, columns=['employee_id', 'name', 'reports_to', 'age']).astype({'employee_id':'Int64', 'name':'object', 'reports_to':'Int64', 'age':'Int64'})
```

Table: `Employees`

> ```
> +-------------+----------+
> | Column Name | Type     |
> +-------------+----------+
> | employee_id | int      |
> | name        | varchar  |
> | reports_to  | int      |
> | age         | int      |
> +-------------+----------+
> employee_id 是这个表的主键.
> 该表包含员工以及需要听取他们汇报的上级经理的ID的信息。 有些员工不需要向任何人汇报（reports_to 为空）。
> ```

对于此问题，我们将至少有一个其他员工需要向他汇报的员工，视为一个经理。

编写SQL查询需要听取汇报的所有经理的ID、名称、直接向该经理汇报的员工人数，以及这些员工的平均年龄，其中该平均年龄需要四舍五入到最接近的整数。

返回的结果集需要按照 `employee_id` 进行排序。

查询结果的格式如下：

> ```
> Employees table:
> +-------------+---------+------------+-----+
> | employee_id | name    | reports_to | age |
> +-------------+---------+------------+-----+
> | 9           | Hercy   | null       | 43  |
> | 6           | Alice   | 9          | 41  |
> | 4           | Bob     | 9          | 36  |
> | 2           | Winston | null       | 37  |
> +-------------+---------+------------+-----+
> 
> Result table:
> +-------------+-------+---------------+-------------+
> | employee_id | name  | reports_count | average_age |
> +-------------+-------+---------------+-------------+
> | 9           | Hercy | 2             | 39          |
> +-------------+-------+---------------+-------------+
> Hercy 有两个需要向他汇报的员工, 他们是 Alice and Bob. 他们的平均年龄是 (41+36)/2 = 38.5, 四舍五入的结果是 39.
> ```
