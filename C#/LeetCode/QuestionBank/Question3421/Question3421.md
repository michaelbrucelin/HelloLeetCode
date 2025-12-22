### [3421\. 查找进步的学生](https://leetcode.cn/problems/find-students-who-improved/)

难度：中等

**SQL Schema**

```sql
CREATE TABLE Scores (
    student_id INT,
    subject VARCHAR(50),
    score INT,
    exam_date VARCHAR(10)
)
Truncate table Scores
insert into Scores (student_id, subject, score, exam_date) values ('101', 'Math', '70', '2023-01-15')
insert into Scores (student_id, subject, score, exam_date) values ('101', 'Math', '85', '2023-02-15')
insert into Scores (student_id, subject, score, exam_date) values ('101', 'Physics', '65', '2023-01-15')
insert into Scores (student_id, subject, score, exam_date) values ('101', 'Physics', '60', '2023-02-15')
insert into Scores (student_id, subject, score, exam_date) values ('102', 'Math', '80', '2023-01-15')
insert into Scores (student_id, subject, score, exam_date) values ('102', 'Math', '85', '2023-02-15')
insert into Scores (student_id, subject, score, exam_date) values ('103', 'Math', '90', '2023-01-15')
insert into Scores (student_id, subject, score, exam_date) values ('104', 'Physics', '75', '2023-01-15')
insert into Scores (student_id, subject, score, exam_date) values ('104', 'Physics', '85', '2023-02-15')
```

**Pandas Schema**

```python
data = [[101, 'Math', 70, '2023-01-15'], [101, 'Math', 85, '2023-02-15'], [101, 'Physics', 65, '2023-01-15'], [101, 'Physics', 60, '2023-02-15'], [102, 'Math', 80, '2023-01-15'], [102, 'Math', 85, '2023-02-15'], [103, 'Math', 90, '2023-01-15'], [104, 'Physics', 75, '2023-01-15'], [104, 'Physics', 85, '2023-02-15']]
scores = pd.DataFrame({"student_id": pd.Series(dtype="int"),
                          "subject": pd.Series(dtype="str"),
                          "score": pd.Series(dtype="int"),
                          "exam_date": pd.Series(dtype="str")})
```

> 表：`Scores`
> ```c
> +-------------+---------+
> | Column Name | Type    |
> +-------------+---------+
> | student_id  | int     |
> | subject     | varchar |
> | score       | int     |
> | exam_date   | varchar |
> +-------------+---------+
> ```
> (student_id, subject, exam_date) 是这张表的主键。
> 每一行包含有关学生在特定考试日期特定科目成绩的信息。分数范围从 0 到 100（包括边界）。

编写一个解决方案来查找 **进步的学生**。如果 **同时** 满足以下两个条件，则该学生被认为是进步的：

- 在 **同一科目** 至少参加过两个不同日期的考试。
- 他们在该学科 **最近的分数** 比他们 第一次该学科考试的分数更高。

返回结果表以 `student_id`，`subject` **升序** 排序。

结果格式如下所示。

**示例：**

> **输入：**
> Scores 表：
> ```c
> +------------+----------+-------+------------+
> | student_id | subject  | score | exam_date  |
> +------------+----------+-------+------------+
> | 101        | Math     | 70    | 2023-01-15 |
> | 101        | Math     | 85    | 2023-02-15 |
> | 101        | Physics  | 65    | 2023-01-15 |
> | 101        | Physics  | 60    | 2023-02-15 |
> | 102        | Math     | 80    | 2023-01-15 |
> | 102        | Math     | 85    | 2023-02-15 |
> | 103        | Math     | 90    | 2023-01-15 |
> | 104        | Physics  | 75    | 2023-01-15 |
> | 104        | Physics  | 85    | 2023-02-15 |
> +------------+----------+-------+------------+
> ```
>
> **输出：**
> ```c
> +------------+----------+-------------+--------------+
> | student_id | subject  | first_score | latest_score |
> +------------+----------+-------------+--------------+
> | 101        | Math     | 70          | 85           |
> | 102        | Math     | 80          | 85           |
> | 104        | Physics  | 75          | 85           |
> +------------+----------+-------------+--------------+
> ```
>
> **解释：**
>
> - 学生 101 的数学：从 70 分进步到 85 分。
> - 学生 101 的物理：没有进步（从 65 分退步到 60分）
> - 学生 102 的数学：从 80 进步到 85 分。
> - 学生 103 的数学：只有一次考试，不符合资格。
> - 学生 104 的物理：从 75 分进步到 85 分。
>
> 结果表以 student_id，subject 升序排序。
