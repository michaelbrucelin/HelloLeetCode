### [3764\. 最常见的课程组合](https://leetcode.cn/problems/most-common-course-pairs/)

难度：困难

**SQL Schema**

```sql
CREATE TABLE course_completions (
    user_id INT,
    course_id INT,
    course_name VARCHAR(100),
    completion_date DATE,
    course_rating INT
)
Truncate table course_completions
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('1', '101', 'Python Basics', '2024-01-05', '5')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('1', '102', 'SQL Fundamentals', '2024-02-10', '4')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('1', '103', 'JavaScript', '2024-03-15', '5')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('1', '104', 'React Basics', '2024-04-20', '4')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('1', '105', 'Node.js', '2024-05-25', '5')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('1', '106', 'Docker', '2024-06-30', '4')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('2', '101', 'Python Basics', '2024-01-08', '4')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('2', '104', 'React Basics', '2024-02-14', '5')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('2', '105', 'Node.js', '2024-03-20', '4')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('2', '106', 'Docker', '2024-04-25', '5')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('2', '107', 'AWS Fundamentals', '2024-05-30', '4')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('3', '101', 'Python Basics', '2024-01-10', '3')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('3', '102', 'SQL Fundamentals', '2024-02-12', '3')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('3', '103', 'JavaScript', '2024-03-18', '3')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('3', '104', 'React Basics', '2024-04-22', '2')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('3', '105', 'Node.js', '2024-05-28', '3')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('4', '101', 'Python Basics', '2024-01-12', '5')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('4', '108', 'Data Science', '2024-02-16', '5')
insert into course_completions (user_id, course_id, course_name, completion_date, course_rating) values ('4', '109', 'Machine Learning', '2024-03-22', '5')
```

**Pandas Schema**

```python
data = [[1, 101, 'Python Basics', '2024-01-05', 5], [1, 102, 'SQL Fundamentals', '2024-02-10', 4], [1, 103, 'JavaScript', '2024-03-15', 5], [1, 104, 'React Basics', '2024-04-20', 4], [1, 105, 'Node.js', '2024-05-25', 5], [1, 106, 'Docker', '2024-06-30', 4], [2, 101, 'Python Basics', '2024-01-08', 4], [2, 104, 'React Basics', '2024-02-14', 5], [2, 105, 'Node.js', '2024-03-20', 4], [2, 106, 'Docker', '2024-04-25', 5], [2, 107, 'AWS Fundamentals', '2024-05-30', 4], [3, 101, 'Python Basics', '2024-01-10', 3], [3, 102, 'SQL Fundamentals', '2024-02-12', 3], [3, 103, 'JavaScript', '2024-03-18', 3], [3, 104, 'React Basics', '2024-04-22', 2], [3, 105, 'Node.js', '2024-05-28', 3], [4, 101, 'Python Basics', '2024-01-12', 5], [4, 108, 'Data Science', '2024-02-16', 5], [4, 109, 'Machine Learning', '2024-03-22', 5]]
course_completions = pd.DataFrame({
    "user_id": pd.Series(dtype="int"),
    "course_id": pd.Series(dtype="int"),
    "course_name": pd.Series(dtype="string"),              # corresponds to SQL VARCHAR
    "completion_date": pd.Series(dtype="datetime64[ns]"),  # corresponds to SQL DATE
    "course_rating": pd.Series(dtype="Int64")              # corresponds to SQL INT (nullable)
})
```

> 表：`course_completions`
>
> ```c
> +-------------------+---------+
> | Column Name       | Type    |
> +-------------------+---------+
> | user_id           | int     |
> | course_id         | int     |
> | course_name       | varchar |
> | completion_date   | date    |
> | course_rating     | int     |
> +-------------------+---------+
> ```
>
> (user_id, course_id) 是此表中具有不同值的列的组合。
> 每一行代表一个用户完成的课程及其评分（1-5 分）。

编写一个解决方案，通过分析顶尖学生完成课程的序列来识别 **课程路径**：

- 只考虑 **顶尖学生**（完成 **至少** `5` **门课程且平均评分** `4` **分或以上** 的人）。
- 对每个顶尖学生，确定他们按时间顺序完成的 **课程序列**。
- 找出这些学生所学的所有 **连续课程对** （`课程 A &rarr; 课程 B`）。
- 返回课程对的频率，确定顶尖学生中最常见的课程路径。

返回结果表，按课程对频率 **降序** 排列，若频率相同则按第一课程名称和第二课程名称 **升序** 排列。

结果格式如下所示。

**示例：**

> **输入：**
>
> course_completions 表：
>
> ```c
> +---------+-----------+------------------+-----------------+---------------+
> | user_id | course_id | course_name      | completion_date | course_rating |
> +---------+-----------+------------------+-----------------+---------------+
> | 1       | 101       | Python Basics    | 2024-01-05      | 5             |
> | 1       | 102       | SQL Fundamentals | 2024-02-10      | 4             |
> | 1       | 103       | JavaScript       | 2024-03-15      | 5             |
> | 1       | 104       | React Basics     | 2024-04-20      | 4             |
> | 1       | 105       | Node.js          | 2024-05-25      | 5             |
> | 1       | 106       | Docker           | 2024-06-30      | 4             |
> | 2       | 101       | Python Basics    | 2024-01-08      | 4             |
> | 2       | 104       | React Basics     | 2024-02-14      | 5             |
> | 2       | 105       | Node.js          | 2024-03-20      | 4             |
> | 2       | 106       | Docker           | 2024-04-25      | 5             |
> | 2       | 107       | AWS Fundamentals | 2024-05-30      | 4             |
> | 3       | 101       | Python Basics    | 2024-01-10      | 3             |
> | 3       | 102       | SQL Fundamentals | 2024-02-12      | 3             |
> | 3       | 103       | JavaScript       | 2024-03-18      | 3             |
> | 3       | 104       | React Basics     | 2024-04-22      | 2             |
> | 3       | 105       | Node.js          | 2024-05-28      | 3             |
> | 4       | 101       | Python Basics    | 2024-01-12      | 5             |
> | 4       | 108       | Data Science     | 2024-02-16      | 5             |
> | 4       | 109       | Machine Learning | 2024-03-22      | 5             |
> +---------+-----------+------------------+-----------------+---------------+
> ```
>
> **输出：**
>
> ```c
> +------------------+------------------+------------------+
> | first_course     | second_course    | transition_count |
> +------------------+------------------+------------------+
> | Node.js          | Docker           | 2                |
> | React Basics     | Node.js          | 2                |
> | Docker           | AWS Fundamentals | 1                |
> | JavaScript       | React Basics     | 1                |
> | Python Basics    | React Basics     | 1                |
> | Python Basics    | SQL Fundamentals | 1                |
> | SQL Fundamentals | JavaScript       | 1                |
> +------------------+------------------+------------------+
> ```
>
> **解释：**
>
> - **用户 1：** 完成了 6 门课程，平均分为 4.5（满足顶尖学生）
> - **用户 2：** 完成了 5 门课程，平均分为 4.4（满足顶尖学生）
> - **用户 3：** 完成了 5 门课程但平均得分为 2.8（不满足资格）
> - **用户 4：** 只完成了 3 门课程（不满足资格）
> - **顶尖学生的课程对：**
>   - 用户 1：Python Basics &rarr; SQL Fundamentals &rarr; JavaScript &rarr; React Basics &rarr; Node.js &rarr; Docker
>   - 用户 2：Python Basics &rarr; React Basics &rarr; Node.js &rarr; Docker &rarr; AWS Fundamentals
>   - 最常见的路径：Node.js &rarr; Docker (2 次)，React Basics &rarr; Node.js (2 次)
>
> 结果按 transition_count 降序排列，然后按 first_course 升序排列，再按 second_course 升序排列。
