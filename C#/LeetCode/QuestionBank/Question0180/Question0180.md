#### [180\. 连续出现的数字](https://leetcode.cn/problems/consecutive-numbers/)

难度：中等

SQL Schema
```sql
Create table If Not Exists Logs (id int, num int)
Truncate table Logs
insert into Logs (id, num) values ('1', '1')
insert into Logs (id, num) values ('2', '1')
insert into Logs (id, num) values ('3', '1')
insert into Logs (id, num) values ('4', '2')
insert into Logs (id, num) values ('5', '1')
insert into Logs (id, num) values ('6', '2')
insert into Logs (id, num) values ('7', '2')
```
___

表：`Logs`

```
+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| id          | int     |
| num         | varchar |
+-------------+---------+
id 是这个表的主键。
```

编写一个 SQL 查询，查找所有至少连续出现三次的数字。

返回的结果表中的数据可以按 **任意顺序** 排列。

查询结果格式如下面的例子所示：

**示例 1:**

```
输入：
Logs 表：
+----+-----+
| Id | Num |
+----+-----+
| 1  | 1   |
| 2  | 1   |
| 3  | 1   |
| 4  | 2   |
| 5  | 1   |
| 6  | 2   |
| 7  | 2   |
+----+-----+
输出：
Result 表：
+-----------------+
| ConsecutiveNums |
+-----------------+
| 1               |
+-----------------+
解释：1 是唯一连续出现至少三次的数字。
```
