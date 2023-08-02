#### [1517\. 查找拥有有效邮箱的用户](https://leetcode.cn/problems/find-users-with-valid-e-mails/)

难度：简单

SQL架构

```sql
Create table If Not Exists Users (user_id int, name varchar(30), mail varchar(50))
Truncate table Users
insert into Users (user_id, name, mail) values ('1', 'Winston', 'winston@leetcode.com')
insert into Users (user_id, name, mail) values ('2', 'Jonathan', 'jonathanisgreat')
insert into Users (user_id, name, mail) values ('3', 'Annabelle', 'bella-@leetcode.com')
insert into Users (user_id, name, mail) values ('4', 'Sally', 'sally.come@leetcode.com')
insert into Users (user_id, name, mail) values ('5', 'Marwan', 'quarz#2020@leetcode.com')
insert into Users (user_id, name, mail) values ('6', 'David', 'david69@gmail.com')
insert into Users (user_id, name, mail) values ('7', 'Shapiro', '.shapo@leetcode.com')
```

Pandas 架构

```python
Users = pd.DataFrame([], columns=['user_id', 'name', 'mail']).astype({'user_id':'int64', 'name':'object', 'mail':'object'})
```

用户表： `Users`

```
+---------------+---------+
| Column Name   | Type    |
+---------------+---------+
| user_id       | int     |
| name          | varchar |
| mail          | varchar | 
+---------------+---------+
在 SQL 中，user_id （用户 ID）是该表的主键。
这个表包含用户在某网站上注册的信息。有些邮箱是无效的。
```

查询拥有**有效邮箱**的用户。

有效的邮箱包含符合下列条件的前缀名和域名：

-   **前缀名**是包含字母（大写或小写）、数字、下划线 `'_'`、句点 `'.'` 和/或横杠 `'-'` 的字符串。前缀名**必须**以字母开头。
-   **域名**是 `'@leetcode.com'` 。

按任意顺序返回结果表。

查询格式如下所示。

**示例 1：**

```
输入：
Users:
+---------+-----------+-------------------------+
| user_id | name      | mail                    |
+---------+-----------+-------------------------+
| 1       | Winston   | winston@leetcode.com    |
| 2       | Jonathan  | jonathanisgreat         |
| 3       | Annabelle | bella-@leetcode.com     |
| 4       | Sally     | sally.come@leetcode.com |
| 5       | Marwan    | quarz#2020@leetcode.com |
| 6       | David     | david69@gmail.com       |
| 7       | Shapiro   | .shapo@leetcode.com     |
+---------+-----------+-------------------------+

输出：
+---------+-----------+-------------------------+
| user_id | name      | mail                    |
+---------+-----------+-------------------------+
| 1       | Winston   | winston@leetcode.com    |
| 3       | Annabelle | bella-@leetcode.com     |
| 4       | Sally     | sally.come@leetcode.com |
+---------+-----------+-------------------------+
解释：
2 号用户的邮箱没有域名。
5 号用户的邮箱包含非法字符 #。
6 号用户的邮箱的域名不是 leetcode。
7 号用户的邮箱以句点（.）开头。
```
