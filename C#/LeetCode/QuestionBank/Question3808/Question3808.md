### [3808\. 寻找情绪一致的用户](https://leetcode.cn/problems/find-emotionally-consistent-users/)

难度：中等

**SQL Schema**

```sql
CREATE TABLE reactions (
    user_id INT,
    content_id INT,
    reaction VARCHAR(255)
)

Truncate table reactions
insert into reactions (user_id, content_id, reaction) values ('1', '101', 'like')
insert into reactions (user_id, content_id, reaction) values ('1', '102', 'like')
insert into reactions (user_id, content_id, reaction) values ('1', '103', 'like')
insert into reactions (user_id, content_id, reaction) values ('1', '104', 'wow')
insert into reactions (user_id, content_id, reaction) values ('1', '105', 'like')
insert into reactions (user_id, content_id, reaction) values ('2', '201', 'like')
insert into reactions (user_id, content_id, reaction) values ('2', '202', 'wow')
insert into reactions (user_id, content_id, reaction) values ('2', '203', 'sad')
insert into reactions (user_id, content_id, reaction) values ('2', '204', 'like')
insert into reactions (user_id, content_id, reaction) values ('2', '205', 'wow')
insert into reactions (user_id, content_id, reaction) values ('3', '301', 'love')
insert into reactions (user_id, content_id, reaction) values ('3', '302', 'love')
insert into reactions (user_id, content_id, reaction) values ('3', '303', 'love')
insert into reactions (user_id, content_id, reaction) values ('3', '304', 'love')
insert into reactions (user_id, content_id, reaction) values ('3', '305', 'love')
```

**Pandas Schema**

```python
data = [[1, 101, 'like'], [1, 102, 'like'], [1, 103, 'like'], [1, 104, 'wow'], [1, 105, 'like'], [2, 201, 'like'], [2, 202, 'wow'], [2, 203, 'sad'], [2, 204, 'like'], [2, 205, 'wow'], [3, 301, 'love'], [3, 302, 'love'], [3, 303, 'love'], [3, 304, 'love'], [3, 305, 'love']]
reactions = pd.DataFrame({
    "user_id": pd.Series(dtype="int"),
    "content_id": pd.Series(dtype="int"),
    "reaction": pd.Series(dtype="string")
})
```

> 表：`reactions`
>
> ```c
> +--------------+---------+
> | Column Name  | Type    |
> +--------------+---------+
> | user_id      | int     |
> | content_id   | int     |
> | reaction     | varchar |
> +--------------+---------+
> ```
>
> (user_id, content_id) 是这张表的主键（值互不相同）。
> 每一行代表用户对某条内容的反应。

根据以下要求编写一个解决方案，以识别 **情绪一致的用户**：

- 为每个用户统计他们发送的总反应次数。
- 仅包含 **至少对** `5` **个不同内容项** 作出反应的用户。
- 如果用户 **至少** `60%` 的反应属于 **同一种类型**，则认为其 **情绪一致**。

返回结果表按 `reaction_ratio` **降序** 排序，然后按 `user_id` **升序** 排序。

**注意：**

- `reaction_ratio` 应该舍入到 `2` 位小数

结果格式如下所示。

**示例：**

> **输入：**
>
> reactions 表：
>
> ```c
> +---------+------------+----------+
> | user_id | content_id | reaction |
> +---------+------------+----------+
> | 1       | 101        | like     |
> | 1       | 102        | like     |
> | 1       | 103        | like     |
> | 1       | 104        | wow      |
> | 1       | 105        | like     |
> | 2       | 201        | like     |
> | 2       | 202        | wow      |
> | 2       | 203        | sad      |
> | 2       | 204        | like     |
> | 2       | 205        | wow      |
> | 3       | 301        | love     |
> | 3       | 302        | love     |
> | 3       | 303        | love     |
> | 3       | 304        | love     |
> | 3       | 305        | love     |
> +---------+------------+----------+
> ```
>
> **输出：**
>
> ```c
> +---------+-------------------+----------------+
> | user_id | dominant_reaction | reaction_ratio |
> +---------+-------------------+----------------+
> | 3       | love              | 1.00           |
> | 1       | like              | 0.80           |
> +---------+-------------------+----------------+
> ```
>
> **解释：**
>
> - **用户 1：**
>   - 总反应数 = 5
>   - 'like' 出现了 4 次
>   - reaction_ratio = 4 / 5 = 0.80
>   - 满足 60% 一致的要求
> - **用户 2：**
>   - 总反应数 = 5
>   - 出现最多的反应只出现了 2 次
>   - reaction_ratio = 2 / 5 = 0.40
>   - 不满足一致的要求
> - **用户 3：**
>   - 总反应数 = 5
>   - 'love' 出现了 5 次
>   - reaction_ratio = 5 / 5 = 1.00
>   - 满足一致的要求
>
> 结果表按 reaction_ratio 降序排序，然后按 user_id 升序排序。
