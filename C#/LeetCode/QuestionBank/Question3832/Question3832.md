### [3832\. 查找具有持续行为模式的用户](https://leetcode.cn/problems/find-users-with-persistent-behavior-patterns/)

难度：困难

**SQL Schema**

```sql
CREATE TABLE if not exists activity (
    user_id INT,
    action_date DATE,
    action VARCHAR(255)
)
Truncate table activity
insert into activity (user_id, action_date, action) values ('1', '2024-01-01', 'login')
insert into activity (user_id, action_date, action) values ('1', '2024-01-02', 'login')
insert into activity (user_id, action_date, action) values ('1', '2024-01-03', 'login')
insert into activity (user_id, action_date, action) values ('1', '2024-01-04', 'login')
insert into activity (user_id, action_date, action) values ('1', '2024-01-05', 'login')
insert into activity (user_id, action_date, action) values ('1', '2024-01-06', 'logout')
insert into activity (user_id, action_date, action) values ('2', '2024-01-01', 'click')
insert into activity (user_id, action_date, action) values ('2', '2024-01-02', 'click')
insert into activity (user_id, action_date, action) values ('2', '2024-01-03', 'click')
insert into activity (user_id, action_date, action) values ('2', '2024-01-04', 'click')
insert into activity (user_id, action_date, action) values ('3', '2024-01-01', 'view')
insert into activity (user_id, action_date, action) values ('3', '2024-01-02', 'view')
insert into activity (user_id, action_date, action) values ('3', '2024-01-03', 'view')
insert into activity (user_id, action_date, action) values ('3', '2024-01-04', 'view')
insert into activity (user_id, action_date, action) values ('3', '2024-01-05', 'view')
insert into activity (user_id, action_date, action) values ('3', '2024-01-06', 'view')
insert into activity (user_id, action_date, action) values ('3', '2024-01-07', 'view')
```

**Pandas Schema**

```python
data = [[1, '2024-01-01', 'login'], [1, '2024-01-02', 'login'], [1, '2024-01-03', 'login'], [1, '2024-01-04', 'login'], [1, '2024-01-05', 'login'], [1, '2024-01-06', 'logout'], [2, '2024-01-01', 'click'], [2, '2024-01-02', 'click'], [2, '2024-01-03', 'click'], [2, '2024-01-04', 'click'], [3, '2024-01-01', 'view'], [3, '2024-01-02', 'view'], [3, '2024-01-03', 'view'], [3, '2024-01-04', 'view'], [3, '2024-01-05', 'view'], [3, '2024-01-06', 'view'], [3, '2024-01-07', 'view']]
activity = pd.DataFrame({
    "user_id": pd.Series(dtype="int"),
    "action_date": pd.Series(dtype="datetime64[ns]"),
    "action": pd.Series(dtype="string")
})
```

> 表：`activity`
>
> ```c
> +--------------+---------+
> | Column Name  | Type    |
> +--------------+---------+
> | user_id      | int     |
> | action_date  | date    |
> | action       | varchar |
> +--------------+---------+
> ```
>
> (user_id, action_date, action) 是这张表的主键（值互不相同）。
> 每一行代表一个用户在特定日期执行的具体操作。

根据以下定义，编写一个解决方案来识别 **行为稳定的用户**：

- 一个用户如果存在一个 **连续至少** `5` 天的行为序列满足以下条件，则认为他是 **行为稳定** 的：
  - 该用户在该期间 **每天只执行了一个操作**。
  - 这些连续的日子里，**操作都是相同的**。
- 如果一个用户有多个符合条件的序列，只考虑 **最长** 的那条序列。

返回结果表按 `streak_length` **降序** 排序，然后按 `user_id` **升序** 排序。

结果格式如下所示。

**示例：**

> **输入：**
>
> activity 表：
>
> ```c
> +---------+-------------+--------+
> | user_id | action_date | action |
> +---------+-------------+--------+
> | 1       | 2024-01-01  | login  |
> | 1       | 2024-01-02  | login  |
> | 1       | 2024-01-03  | login  |
> | 1       | 2024-01-04  | login  |
> | 1       | 2024-01-05  | login  |
> | 1       | 2024-01-06  | logout |
> | 2       | 2024-01-01  | click  |
> | 2       | 2024-01-02  | click  |
> | 2       | 2024-01-03  | click  |
> | 2       | 2024-01-04  | click  |
> | 3       | 2024-01-01  | view   |
> | 3       | 2024-01-02  | view   |
> | 3       | 2024-01-03  | view   |
> | 3       | 2024-01-04  | view   |
> | 3       | 2024-01-05  | view   |
> | 3       | 2024-01-06  | view   |
> | 3       | 2024-01-07  | view   |
> +---------+-------------+--------+
> ```
>
> **输出：**
>
> ```c
> +---------+--------+---------------+------------+------------+
> | user_id | action | streak_length | start_date | end_date   |
> +---------+--------+---------------+------------+------------+
> | 3       | view   | 7             | 2024-01-01 | 2024-01-07 |
> | 1       | login  | 5             | 2024-01-01 | 2024-01-05 |
> +---------+--------+---------------+------------+------------+
> ```
>
> **解释：**
>
> - **用户 1：**
>   - 从 2024 年 1 月 1 日至 2024 年 1 月 5 日连续五天执行 `login` 操作
>   - 每一天都恰好有一个操作，且操作相同
>   - 连续长度 = 5（满足最小要求）
>   - 行动在 2024-01-06 发生变化，结束连续计数
> - **用户 2：**
>   - 只连续执行了 4 天 `click` 操作
>   - 不满足最小连续计数 5 天的要求
>   - 从结果排除
> - **用户 3：**
>   - 连续 7 天执行了 `view` 操作
>   - 这是此用户的最长有效序列
>   - 包含在结果中
>
> 结果表按 streak_length 降序排序，然后按 user_id 升序排序。
