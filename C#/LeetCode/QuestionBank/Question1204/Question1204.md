#### [1204\. 最后一个能进入电梯的人](https://leetcode.cn/problems/last-person-to-fit-in-the-bus/)

难度：中等

SQL架构
```sql
Create table If Not Exists Queue (person_id int, person_name varchar(30), weight int, turn int)
Truncate table Queue
insert into Queue (person_id, person_name, weight, turn) values ('5', 'Alice', '250', '1')
insert into Queue (person_id, person_name, weight, turn) values ('4', 'Bob', '175', '5')
insert into Queue (person_id, person_name, weight, turn) values ('3', 'Alex', '350', '2')
insert into Queue (person_id, person_name, weight, turn) values ('6', 'John Cena', '400', '3')
insert into Queue (person_id, person_name, weight, turn) values ('1', 'Winston', '500', '6')
insert into Queue (person_id, person_name, weight, turn) values ('2', 'Marie', '200', '4')
```

表: `Queue`

```
+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| person_id   | int     |
| person_name | varchar |
| weight      | int     |
| turn        | int     |
+-------------+---------+
person_id 是这个表的主键。
该表展示了所有等待电梯的人的信息。
表中 person_id 和 turn 列将包含从 1 到 n 的所有数字，其中 n 是表中的行数。
```

有一群人在等着上公共汽车。然而，巴士有`1000` 公斤的重量限制，所以可能会有一些人不能上。

写一条 SQL 查询语句查找 **最后一个** 能进入电梯且不超过重量限制的 `person_name` 。题目确保队列中第一位的人可以进入电梯，不会超重。

查询结果如下所示。

**示例 1:**

```
输入：
Queue 表
+-----------+-------------------+--------+------+
| person_id | person_name       | weight | turn |
+-----------+-------------------+--------+------+
| 5         | George Washington | 250    | 1    |
| 3         | John Adams        | 350    | 2    |
| 6         | Thomas Jefferson  | 400    | 3    |
| 2         | Will Johnliams    | 200    | 4    |
| 4         | Thomas Jefferson  | 175    | 5    |
| 1         | James Elephant    | 500    | 6    |
+-----------+-------------------+--------+------+
输出：
+-------------------+
| person_name       |
+-------------------+
| Thomas Jefferson  |
+-------------------+
解释：
为了简化，Queue 表按 turn 列由小到大排序。
上例中 George Washington(id 5), John Adams(id 3) 和 Thomas Jefferson(id 6) 将可以进入电梯,因为他们的体重和为 250 + 350 + 400 = 1000。
Thomas Jefferson(id 6) 是最后一个体重合适并进入电梯的人。
```
