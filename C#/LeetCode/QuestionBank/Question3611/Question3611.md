### [3611\. 查找超预订员工](https://leetcode.cn/problems/find-overbooked-employees/)

难度：中等

**SQL Schema**

```sql
CREATE TABLE if not exists employees (
    employee_id INT,
    employee_name VARCHAR(255),
    department VARCHAR(100)
)
CREATE TABLE meetings (
    meeting_id INT,
    employee_id INT,
    meeting_date DATE,
    meeting_type VARCHAR(50),
    duration_hours DECIMAL(4, 2)
)
Truncate table employees
insert into employees (employee_id, employee_name, department) values ('1', 'Alice Johnson', 'Engineering')
insert into employees (employee_id, employee_name, department) values ('2', 'Bob Smith', 'Marketing')
insert into employees (employee_id, employee_name, department) values ('3', 'Carol Davis', 'Sales')
insert into employees (employee_id, employee_name, department) values ('4', 'David Wilson', 'Engineering')
insert into employees (employee_id, employee_name, department) values ('5', 'Emma Brown', 'HR')
Truncate table meetings
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('1', '1', '2023-06-05', 'Team', '8.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('2', '1', '2023-06-06', 'Client', '6.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('3', '1', '2023-06-07', 'Training', '7.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('4', '1', '2023-06-12', 'Team', '12.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('5', '1', '2023-06-13', 'Client', '9.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('6', '2', '2023-06-05', 'Team', '15.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('7', '2', '2023-06-06', 'Client', '8.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('8', '2', '2023-06-12', 'Training', '10.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('9', '3', '2023-06-05', 'Team', '4.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('10', '3', '2023-06-06', 'Client', '3.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('11', '4', '2023-06-05', 'Team', '25.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('12', '4', '2023-06-19', 'Client', '22.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('13', '5', '2023-06-05', 'Training', '2.0')
```

**Pandas Schema**

```python
data = [[1, 'Alice Johnson', 'Engineering'], [2, 'Bob Smith', 'Marketing'], [3, 'Carol Davis', 'Sales'], [4, 'David Wilson', 'Engineering'], [5, 'Emma Brown', 'HR']]
employees = pd.DataFrame(columns=['employee_id', 'employee_name', 'department']).astype({'employee_id': 'Int64', 'employee_name': 'string', 'department': 'string'})

data = [[1, 1, '2023-06-05', 'Team', 8.0], [2, 1, '2023-06-06', 'Client', 6.0], [3, 1, '2023-06-07', 'Training', 7.0], [4, 1, '2023-06-12', 'Team', 12.0], [5, 1, '2023-06-13', 'Client', 9.0], [6, 2, '2023-06-05', 'Team', 15.0], [7, 2, '2023-06-06', 'Client', 8.0], [8, 2, '2023-06-12', 'Training', 10.0], [9, 3, '2023-06-05', 'Team', 4.0], [10, 3, '2023-06-06', 'Client', 3.0], [11, 4, '2023-06-05', 'Team', 25.0], [12, 4, '2023-06-19', 'Client', 22.0], [13, 5, '2023-06-05', 'Training', 2.0]]
meetings = pd.DataFrame(columns=['meeting_id', 'employee_id', 'meeting_date', 'meeting_type', 'duration_hours']).astype({'meeting_id': 'Int64', 'employee_id': 'Int64', 'meeting_date': 'datetime64[ns]', 'meeting_type': 'string', 'duration_hours': 'float64'})
```

> 表：`employees`
>
> ```c
> +---------------+---------+
> | Column Name   | Type    |
> +---------------+---------+
> | employee_id   | int     |
> | employee_name | varchar |
> | department    | varchar |
> +---------------+---------+
> ```
>
> employee_id 是这张表的唯一主键。
> 每一行包含一个员工和他们部门的信息。
>
> 表：`meetings`
>
> ```c
> +---------------+---------+
> | Column Name   | Type    |
> +---------------+---------+
> | meeting_id    | int     |
> | employee_id   | int     |
> | meeting_date  | date    |
> | meeting_type  | varchar |
> | duration_hours| decimal |
> +---------------+---------+
> ```
>
> meeting_id 是这张表的唯一主键。
> 每一行表示一位员工参加的会议。meeting_type 可以是 'Team'，'Client' 或 'Training'。

编写一个解决方案来查找会议密集型的员工 -  在任何给定周内，花费超过 `50%` 工作时间在会议上的员工。

- 假定一个标准工作周是 `40` **小时**
- 计算每位员工 **每周**（**周一至周日**）的 **总会议小时数**
- 员工如果每周会议时间超过 `20` 小时（`40` 小时工作时间的 `50%`），则被视为会议密集型。
- 统计每位员工有多少周是会议密集周
- **仅查找 至少** `2` 周会议密集的员工

返回结果表按会议密集周的数量降序排列，然后按员工姓名升序排列。结果格式如下所示。

**示例：**

> **输入：**
>
> employees 表：
>
> ```c
> +-------------+----------------+-------------+
> | employee_id | employee_name  | department  |
> +-------------+----------------+-------------+
> | 1           | Alice Johnson  | Engineering |
> | 2           | Bob Smith      | Marketing   |
> | 3           | Carol Davis    | Sales       |
> | 4           | David Wilson   | Engineering |
> | 5           | Emma Brown     | HR          |
> +-------------+----------------+-------------+
> ```
>
> meetings 表：
>
> ```c
> +------------+-------------+--------------+--------------+----------------+
> | meeting_id | employee_id | meeting_date | meeting_type | duration_hours |
> +------------+-------------+--------------+--------------+----------------+
> | 1          | 1           | 2023-06-05   | Team         | 8.0            |
> | 2          | 1           | 2023-06-06   | Client       | 6.0            |
> | 3          | 1           | 2023-06-07   | Training     | 7.0            |
> | 4          | 1           | 2023-06-12   | Team         | 12.0           |
> | 5          | 1           | 2023-06-13   | Client       | 9.0            |
> | 6          | 2           | 2023-06-05   | Team         | 15.0           |
> | 7          | 2           | 2023-06-06   | Client       | 8.0            |
> | 8          | 2           | 2023-06-12   | Training     | 10.0           |
> | 9          | 3           | 2023-06-05   | Team         | 4.0            |
> | 10         | 3           | 2023-06-06   | Client       | 3.0            |
> | 11         | 4           | 2023-06-05   | Team         | 25.0           |
> | 12         | 4           | 2023-06-19   | Client       | 22.0           |
> | 13         | 5           | 2023-06-05   | Training     | 2.0            |
> +------------+-------------+--------------+--------------+----------------+
> ```
>
> **输出：**
>
> ```c
> +-------------+----------------+-------------+---------------------+
> | employee_id | employee_name  | department  | meeting_heavy_weeks |
> +-------------+----------------+-------------+---------------------+
> | 1           | Alice Johnson  | Engineering | 2                   |
> | 4           | David Wilson   | Engineering | 2                   |
> +-------------+----------------+-------------+---------------------+
> ```
>
> **解释：**
>
> - **Alice Johnson (employee_id = 1):**
>   - 6 月 5 日至 11 日（2023-06-05 至 2023-06-11）：8.0 + 6.0 + 7.0 = 21.0 小时（> 20 小时）
>   - 6 月 12 日至 18 日（2023-06-12 至 2023-06-18）: 12.0 + 9.0 = 21.0 小时（> 20 小时）
>   - 2 周会议密集
> - **David Wilson (employee_id = 4):**
>   - 6 月 5 日至 11 日：25.0 小时（> 20 小时）
>   - 6 月 19 日至 25 日：22.0 小时（> 20 小时）
>   - 2 周会议密集
> - **未包含的员工：**
>   - Bob Smith（employee_id = 2）：6 月 5 日至 11 日：15.0 + 8.0 = 23.0 小时（> 20），6 月 12 日至 18 日：10.0 小时（< 20）。只有 1 个会议密集周。
>   - Carol Davis（employee_id = 3）：6 月 5 日至 11 日：4.0 + 3.0 = 7.0 小时（< 20）。没有会议密集周。
>   - Emma Brown（employee_id = 5）：6 月 5 日至 11 日：2.0 小时（< 20）。没有会议密集周。
>
> 结果表按 meeting_heavy_weeks 降序排列，然后按员工姓名升序排列。
