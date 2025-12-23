### [3482\. 分析组织层级](https://leetcode.cn/problems/analyze-organization-hierarchy/)

难度：困难

**SQL Schema**

```sql
CREATE TABLE if not exists Employees (
    employee_id INT,
    employee_name VARCHAR(100),
    manager_id INT,
    salary INT,
    department VARCHAR(50)
)
Truncate table Employees
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('1', 'Alice', NULL, '12000', 'Executive')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('2', 'Bob', '1', '10000', 'Sales')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('3', 'Charlie', '1', '10000', 'Engineering')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('4', 'David', '2', '7500', 'Sales')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('5', 'Eva', '2', '7500', 'Sales')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('6', 'Frank', '3', '9000', 'Engineering')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('7', 'Grace', '3', '8500', 'Engineering')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('8', 'Hank', '4', '6000', 'Sales')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('9', 'Ivy', '6', '7000', 'Engineering')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('10', 'Judy', '6', '7000', 'Engineering')
```

**Pandas Schema**

```python
data = [[1, 'Alice', None, 12000, 'Executive'], [2, 'Bob', 1, 10000, 'Sales'], [3, 'Charlie', 1, 10000, 'Engineering'], [4, 'David', 2, 7500, 'Sales'], [5, 'Eva', 2, 7500, 'Sales'], [6, 'Frank', 3, 9000, 'Engineering'], [7, 'Grace', 3, 8500, 'Engineering'], [8, 'Hank', 4, 6000, 'Sales'], [9, 'Ivy', 6, 7000, 'Engineering'], [10, 'Judy', 6, 7000, 'Engineering']]
employees = pd.DataFrame(columns=["employee_id", "employee_name", "manager_id", "salary", "department"]).astype({"employee_id": "int", "employee_name": "string", "manager_id": "Int64", "salary": "int", "department": "string"})
```

> 表：`Employees`
>
> ```c
> +----------------+---------+
> | Column Name    | Type    |
> +----------------+---------+
> | employee_id    | int     |
> | employee_name  | varchar |
> | manager_id     | int     |
> | salary         | int     |
> | department     | varchar |
> +----------------+----------+
> ```
>
> employee_id 是这张表的唯一主键。
> 每一行包含关于一名员工的信息，包括他们的 ID，姓名，他们经理的 ID，薪水和部门。
> 顶级经理（CEO）的 manager_id 是空的。

编写一个解决方案来分析组织层级并回答下列问题：

1. **层级：** 对于每名员工，确定他们在组织中的层级（CEO 层级为 `1`，CEO 的直接下属员工层级为 `2`，以此类推）。
2. **团队大小：** 对于每个是经理的员工，计算他们手下的（直接或间接下属）总员工数。
3. **薪资预算：** 对于每个经理，计算他们控制的总薪资预算（所有手下员工的工资总和，包括间接下属，加上自己的工资）。

返回结果表以 **层级** **升序** 排序，然后以预算 **降序** 排序，最后以 **employee_name 升序** 排序。

结果格式如下所示。

**示例：**

> **输入：**
>
> Employees 表：
>
> ```c
> +-------------+---------------+------------+--------+-------------+
> | employee_id | employee_name | manager_id | salary | department  |
> +-------------+---------------+------------+--------+-------------+
> | 1           | Alice         | null       | 12000  | Executive   |
> | 2           | Bob           | 1          | 10000  | Sales       |
> | 3           | Charlie       | 1          | 10000  | Engineering |
> | 4           | David         | 2          | 7500   | Sales       |
> | 5           | Eva           | 2          | 7500   | Sales       |
> | 6           | Frank         | 3          | 9000   | Engineering |
> | 7           | Grace         | 3          | 8500   | Engineering |
> | 8           | Hank          | 4          | 6000   | Sales       |
> | 9           | Ivy           | 6          | 7000   | Engineering |
> | 10          | Judy          | 6          | 7000   | Engineering |
> +-------------+---------------+------------+--------+-------------+
> ```
>
> **输出：**
>
> ```c
> +-------------+---------------+-------+-----------+--------+
> | employee_id | employee_name | level | team_size | budget |
> +-------------+---------------+-------+-----------+--------+
> | 1           | Alice         | 1     | 9         | 84500  |
> | 3           | Charlie       | 2     | 4         | 41500  |
> | 2           | Bob           | 2     | 3         | 31000  |
> | 6           | Frank         | 3     | 2         | 23000  |
> | 4           | David         | 3     | 1         | 13500  |
> | 7           | Grace         | 3     | 0         | 8500   |
> | 5           | Eva           | 3     | 0         | 7500   |
> | 9           | Ivy           | 4     | 0         | 7000   |
> | 10          | Judy          | 4     | 0         | 7000   |
> | 8           | Hank          | 4     | 0         | 6000   |
> +-------------+---------------+-------+-----------+--------+
> ```
>
> **解释：**
>
> - **组织结构：**
>   - Alice（ID：1）是 CEO（层级 1）没有经理。
>   - Bob（ID：2）和 Charlie（ID：3）是 Alice 的直接下属（层级 2）
>   - David（ID：4），Eva（ID：5）从属于 Bob，而 Frank（ID：6）和 Grace（ID：7）从属于 Charlie（层级 3）
>   - Hank（ID：8）从属于 David，而 Ivy（ID：9）和 Judy（ID：10）从属于 Frank（层级 4）
> - **层级计算：**
>   - CEO（Alice）层级为 1
>   - 每个后续的管理层级都会使层级数加 1
> - **团队大小计算：**
>   - Alice 手下有 9 个员工（除她以外的整个公司）
>   - Bob 手下有 3 个员工（David，Eva 和 Hank）
>   - Charlie 手下有 4 个员工（Frank，Grace，Ivy 和 Judy）
>   - David 手下有 1 个员工（Hank）
>   - Frank 手下有 2 个员工（Ivy 和 Judy）
>   - Eva，Grace，Hank，Ivy 和 Judy 没有直接下属（team_size = 0）
> - **预算计算：**
>   - Alice 的预算：她的工资（12000）+ 所有员工的工资（72500）= 84500
>   - Charlie 的预算：他的工资（10000）+ Frank 的预算（23000）+ Grace 的工资（8500）= 41500
>   - Bob 的预算：他的工资 (10000) + David 的预算（13500）+ Eva 的工资（7500）= 31000
>   - Frank 的预算：他的工资 (9000) + Ivy 的工资（7000）+ Judy 的工资（7000）= 23000
>   - David 的预算：他的工资 (7500) + Hank 的工资（6000）= 13500
>   - 没有直接下属的员工的预算等于他们自己的工资。
>
> **注意：**
>
> - 结果先以层级升序排序
> - 在同一层级内，员工按预算降序排序，然后按姓名升序排序
