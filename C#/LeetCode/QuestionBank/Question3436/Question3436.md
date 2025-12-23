### [3436\. 查找合法邮箱](https://leetcode.cn/problems/find-valid-emails/)

难度：简单

**SQL Schema**

```sql
CREATE TABLE If not Exists Users (
    user_id INT,
    email VARCHAR(255)
)
Truncate table Users
insert into Users (user_id, email) values ('1', 'alice@example.com')
insert into Users (user_id, email) values ('2', 'bob_at_example.com')
insert into Users (user_id, email) values ('3', 'charlie@example.net')
insert into Users (user_id, email) values ('4', 'david@domain.com')
insert into Users (user_id, email) values ('5', 'eve@invalid')
```

**Pandas Schema**

```python
data = [[1, 'alice@example.com'], [2, 'bob_at_example.com'], [3, 'charlie@example.net'], [4, 'david@domain.com'], [5, 'eve@invalid']]
users = pd.DataFrame(columns=["user_id", "email"]).astype({"user_id": "int32", "email": "string"})
```

> 表：`Users`
>
> ```c
> +-----------------+---------+
> | Column Name     | Type    |
> +-----------------+---------+
> | user_id         | int     |
> | email           | varchar |
> +-----------------+---------+
> ```
>
> (user_id) 是这张表的唯一主键。
> 每一行包含用户的唯一 ID 和邮箱地址。

编写一个解决方案来查找所有 **合法邮箱地址**。一个合法的邮箱地址符合下述条件：

- 只包含一个 `@` 符号。
- 以 `.com` 结尾。
- `@` 符号前面的部分只包含 **字母数字** 字符和 **下划线**。
- `@` 符号后面与 `.com` 前面的部分 包含 **只有字母** 的域名。

返回结果表以 `user_id` **升序** 排序。

**示例：**

> **输入：**
> Users 表：
>
> ```c
> +---------+---------------------+
> | user_id | email               |
> +---------+---------------------+
> | 1       | alice@example.com   |
> | 2       | bob_at_example.com  |
> | 3       | charlie@example.net |
> | 4       | david@domain.com    |
> | 5       | eve@invalid         |
> +---------+---------------------+
> ```
>
> **输出：**
>
> ```c
> +---------+-------------------+
> | user_id | email             |
> +---------+-------------------+
> | 1       | alice@example.com |
> | 4       | david@domain.com  |
> +---------+-------------------+
> ```
>
> **解释：**
>
> - **alice@example.com** 是合法的因为它包含一个 `@`，alice 是只有字母数字的，并且 example.com 以字母开始并以 .com 结束。
> - **bob_at_example.com** 是不合法的因为它包含下划线但没有 `@`。
> - **charlie@example.net** 是不合法的因为域名没有以 `.com` 结尾。
> - **david@domain.com** 是合法的因为它满足所有条件。
> - **eve@invalid** 是不合法的因为域名没有以 `.com` 结尾。
>
> 结果表以 user_id 升序排序。
