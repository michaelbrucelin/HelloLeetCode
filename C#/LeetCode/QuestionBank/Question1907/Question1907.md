#### [1907\. 按分类统计薪水](https://leetcode.cn/problems/count-salary-categories/)

难度：中等

SQL架构
```sql
Create table If Not Exists Accounts (account_id int, income int)
Truncate table Accounts
insert into Accounts (account_id, income) values ('3', '108939')
insert into Accounts (account_id, income) values ('2', '12747')
insert into Accounts (account_id, income) values ('8', '87709')
insert into Accounts (account_id, income) values ('6', '91796')
```

Pandas 架构
```python
Accounts = pd.DataFrame([], columns=['account_id', 'income']).astype({'account_id':'Int64', 'income':'Int64'})
```

表: `Accounts`

```
+-------------+------+
| 列名        | 类型  |
+-------------+------+
| account_id  | int  |
| income      | int  |
+-------------+------+
在 SQL 中，account_id 是这个表的主键。
每一行都包含一个银行帐户的月收入的信息。
```

查询每个工资类别的银行账户数量。 工资类别如下：

-   `"Low Salary"`：所有工资 **严格低于** `20000` 美元。
-   `"Average Salary"`： **包含** 范围内的所有工资 `[$20000, $50000]` 。
-   `"High Salary"`：所有工资 **严格大于** `50000` 美元。

结果表 **必须** 包含所有三个类别。 如果某个类别中没有帐户，则报告 `0` 。

按 **任意顺序** 返回结果表。

查询结果格式如下示例。

**示例 1：**

```
输入：
Accounts 表:
+------------+--------+
| account_id | income |
+------------+--------+
| 3          | 108939 |
| 2          | 12747  |
| 8          | 87709  |
| 6          | 91796  |
+------------+--------+
输出：
+----------------+----------------+
| category       | accounts_count |
+----------------+----------------+
| Low Salary     | 1              |
| Average Salary | 0              |
| High Salary    | 3              |
+----------------+----------------+
解释：
低薪: 数量为 2.
中等薪水: 没有.
高薪: 有三个账户，他们是 3, 6和 8.
```
