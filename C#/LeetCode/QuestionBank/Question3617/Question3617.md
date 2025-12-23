### [3617\. 查找具有螺旋学习模式的学生](https://leetcode.cn/problems/find-students-with-study-spiral-pattern/)

难度：困难

**SQL Schema**

```sql
CREATE TABLE if not exists students (
    student_id INT,
    student_name VARCHAR(255),
    major VARCHAR(100)
)
CREATE TABLE study_sessions (
    session_id INT,
    student_id INT,
    subject VARCHAR(100),
    session_date DATE,
    hours_studied DECIMAL(4, 2)
)
Truncate table students
insert into students (student_id, student_name, major) values ('1', 'Alice Chen', 'Computer Science')
insert into students (student_id, student_name, major) values ('2', 'Bob Johnson', 'Mathematics')
insert into students (student_id, student_name, major) values ('3', 'Carol Davis', 'Physics')
insert into students (student_id, student_name, major) values ('4', 'David Wilson', 'Chemistry')
insert into students (student_id, student_name, major) values ('5', 'Emma Brown', 'Biology')
Truncate table study_sessions
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('1', '1', 'Math', '2023-10-01', '2.5')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('2', '1', 'Physics', '2023-10-02', '3.0')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('3', '1', 'Chemistry', '2023-10-03', '2.0')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('4', '1', 'Math', '2023-10-04', '2.5')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('5', '1', 'Physics', '2023-10-05', '3.0')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('6', '1', 'Chemistry', '2023-10-06', '2.0')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('7', '2', 'Algebra', '2023-10-01', '4.0')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('8', '2', 'Calculus', '2023-10-02', '3.5')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('9', '2', 'Statistics', '2023-10-03', '2.5')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('10', '2', 'Geometry', '2023-10-04', '3.0')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('11', '2', 'Algebra', '2023-10-05', '4.0')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('12', '2', 'Calculus', '2023-10-06', '3.5')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('13', '2', 'Statistics', '2023-10-07', '2.5')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('14', '2', 'Geometry', '2023-10-08', '3.0')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('15', '3', 'Biology', '2023-10-01', '2.0')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('16', '3', 'Chemistry', '2023-10-02', '2.5')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('17', '3', 'Biology', '2023-10-03', '2.0')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('18', '3', 'Chemistry', '2023-10-04', '2.5')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('19', '4', 'Organic', '2023-10-01', '3.0')
insert into study_sessions (session_id, student_id, subject, session_date, hours_studied) values ('20', '4', 'Physical', '2023-10-05', '2.5')
```

**Pandas Schema**

```python
data = [[1, 'Alice Chen', 'Computer Science'], [2, 'Bob Johnson', 'Mathematics'], [3, 'Carol Davis', 'Physics'], [4, 'David Wilson', 'Chemistry'], [5, 'Emma Brown', 'Biology']]
students = pd.DataFrame({'student_id': pd.Series(dtype='int'), 'student_name': pd.Series(dtype='str'), 'major': pd.Series(dtype='str')})
data = [[1, 1, 'Math', '2023-10-01', 2.5], [2, 1, 'Physics', '2023-10-02', 3.0], [3, 1, 'Chemistry', '2023-10-03', 2.0], [4, 1, 'Math', '2023-10-04', 2.5], [5, 1, 'Physics', '2023-10-05', 3.0], [6, 1, 'Chemistry', '2023-10-06', 2.0], [7, 2, 'Algebra', '2023-10-01', 4.0], [8, 2, 'Calculus', '2023-10-02', 3.5], [9, 2, 'Statistics', '2023-10-03', 2.5], [10, 2, 'Geometry', '2023-10-04', 3.0], [11, 2, 'Algebra', '2023-10-05', 4.0], [12, 2, 'Calculus', '2023-10-06', 3.5], [13, 2, 'Statistics', '2023-10-07', 2.5], [14, 2, 'Geometry', '2023-10-08', 3.0], [15, 3, 'Biology', '2023-10-01', 2.0], [16, 3, 'Chemistry', '2023-10-02', 2.5], [17, 3, 'Biology', '2023-10-03', 2.0], [18, 3, 'Chemistry', '2023-10-04', 2.5], [19, 4, 'Organic', '2023-10-01', 3.0], [20, 4, 'Physical', '2023-10-05', 2.5]]
study_sessions = pd.DataFrame({'session_id': pd.Series(dtype='int'), 'student_id': pd.Series(dtype='int'), 'subject': pd.Series(dtype='str'), 'session_date': pd.Series(dtype='datetime64[ns]'), 'hours_studied': pd.Series(dtype='float')})
```

> 表：`students`
>
> ```c
> +--------------+---------+
> | Column Name  | Type    |
> +--------------+---------+
> | student_id   | int     |
> | student_name | varchar |
> | major        | varchar |
> +--------------+---------+
> ```
>
> student_id 是这张表的唯一主键。
> 每一行包含有关学生及其学术专业的信息。
>
> 表：`study_sessions`
>
> ```c
> +---------------+---------+
> | Column Name   | Type    |
> +---------------+---------+
> | session_id    | int     |
> | student_id    | int     |
> | subject       | varchar |
> | session_date  | date    |
> | hours_studied | decimal |
> +---------------+---------+
> ```
>
> session_id 是这张表的唯一主键。
> 每一行代表一个学生针对特定学科的学习时段。

编写一个解决方案来找出遵循 **螺旋学习模式** 的学生——即那些持续学习多个学科并按循环周期进行学习的学生。

- 螺旋学习模式意味着学生以重复的顺序学习至少 `3` 个 **不同的学科**。
- 模式必须重复 **至少** `2` **个完整周期**（最少 `6` 次学习记录）。
- 两次学习记录必须是间隔不超过 `2` 天的 **连续日期**。
- 计算 **循环长度**（模式中不同的学科数量）。
- 计算模式中所有学习记录的 **总学习时长**。
- 仅包含循环长度 **至少为**  `3` **门学科** 的学生。

返回结果表按循环长度 **降序** 排序，然后按总学习时间 **降序** 排序。

结果格式如下所示。

**示例：**

> **输入：**
>
> students 表：
>
> ```c
> +------------+--------------+------------------+
> | student_id | student_name | major            |
> +------------+--------------+------------------+
> | 1          | Alice Chen   | Computer Science |
> | 2          | Bob Johnson  | Mathematics      |
> | 3          | Carol Davis  | Physics          |
> | 4          | David Wilson | Chemistry        |
> | 5          | Emma Brown   | Biology          |
> +------------+--------------+------------------+
> ```
>
> study_sessions 表：
>
> ```c
> +------------+------------+------------+--------------+---------------+
> | session_id | student_id | subject    | session_date | hours_studied |
> +------------+------------+------------+--------------+---------------+
> | 1          | 1          | Math       | 2023-10-01   | 2.5           |
> | 2          | 1          | Physics    | 2023-10-02   | 3.0           |
> | 3          | 1          | Chemistry  | 2023-10-03   | 2.0           |
> | 4          | 1          | Math       | 2023-10-04   | 2.5           |
> | 5          | 1          | Physics    | 2023-10-05   | 3.0           |
> | 6          | 1          | Chemistry  | 2023-10-06   | 2.0           |
> | 7          | 2          | Algebra    | 2023-10-01   | 4.0           |
> | 8          | 2          | Calculus   | 2023-10-02   | 3.5           |
> | 9          | 2          | Statistics | 2023-10-03   | 2.5           |
> | 10         | 2          | Geometry   | 2023-10-04   | 3.0           |
> | 11         | 2          | Algebra    | 2023-10-05   | 4.0           |
> | 12         | 2          | Calculus   | 2023-10-06   | 3.5           |
> | 13         | 2          | Statistics | 2023-10-07   | 2.5           |
> | 14         | 2          | Geometry   | 2023-10-08   | 3.0           |
> | 15         | 3          | Biology    | 2023-10-01   | 2.0           |
> | 16         | 3          | Chemistry  | 2023-10-02   | 2.5           |
> | 17         | 3          | Biology    | 2023-10-03   | 2.0           |
> | 18         | 3          | Chemistry  | 2023-10-04   | 2.5           |
> | 19         | 4          | Organic    | 2023-10-01   | 3.0           |
> | 20         | 4          | Physical   | 2023-10-05   | 2.5           |
> +------------+------------+------------+--------------+---------------+
> ```
>
> **输出：**
>
> ```c
> +------------+--------------+------------------+--------------+-------------------+
> | student_id | student_name | major            | cycle_length | total_study_hours |
> +------------+--------------+------------------+--------------+-------------------+
> | 2          | Bob Johnson  | Mathematics      | 4            | 26.0              |
> | 1          | Alice Chen   | Computer Science | 3            | 15.0              |
> +------------+--------------+------------------+--------------+-------------------+
> ```
>
> **解释：**
>
> - **Alice Chen (student_id = 1):**
>   - 学习序列：Math &rarr; Physics &rarr; Chemistry &rarr; Math &rarr; Physics &rarr; Chemistry
>   - 模式：3 门学科（Math，Physics，Chemistry）重复 2 个完整周期
>   - 连续日期：十月 1-6，没有超过 2 天的间隔
>   - 循环长度：3 门学科
>   - 总时间：2.5 + 3.0 + 2.0 + 2.5 + 3.0 + 2.0 = 15.0 小时
> - **Bob Johnson (student_id = 2):**
>   - 学习序列：Algebra &rarr; Calculus &rarr; Statistics &rarr; Geometry &rarr; Algebra &rarr; Calculus &rarr; Statistics &rarr; Geometry
>   - 模式：4 门学科（Algebra，Calculus，Statistics，Geometry）重复 2 个完整周期
>   - 连续日期：十月 1-8，没有超过 2 天的间隔
>   - 循环长度：4 门学科
>   - 总时间：4.0 + 3.5 + 2.5 + 3.0 + 4.0 + 3.5 + 2.5 + 3.0 = 26.0 小时
> - **未包含学生：**
>   - Carol Davis (student_id = 3)：仅 2 门学科（生物，化学）- 未满足至少 3 门学科的要求
>   - David Wilson (student_id = 4)：仅 2 次学习课程，间隔 4 天 - 不符合连续日期要求
>   - Emma Brown (student_id = 5)：没有记录学习课程
>
> 结果表以 cycle_length 降序排序，然后以 total_study_hours 降序排序。
