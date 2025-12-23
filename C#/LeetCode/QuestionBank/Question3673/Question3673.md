### [3673\. 查找僵尸会话](https://leetcode.cn/problems/find-zombie-sessions/)

难度：困难

**SQL Schema**

```sql
CREATE TABLE app_events (
    event_id INT,
    user_id INT,
    event_timestamp DATETIME,
    event_type VARCHAR(20),
    session_id VARCHAR(10),
    event_value INT
)
Truncate table app_events
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('1', '201', '2024-03-01 10:00:00', 'app_open', 'S001', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('2', '201', '2024-03-01 10:05:00', 'scroll', 'S001', '500')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('3', '201', '2024-03-01 10:10:00', 'scroll', 'S001', '750')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('4', '201', '2024-03-01 10:15:00', 'scroll', 'S001', '600')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('5', '201', '2024-03-01 10:20:00', 'scroll', 'S001', '800')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('6', '201', '2024-03-01 10:25:00', 'scroll', 'S001', '550')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('7', '201', '2024-03-01 10:30:00', 'scroll', 'S001', '900')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('8', '201', '2024-03-01 10:35:00', 'app_close', 'S001', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('9', '202', '2024-03-01 11:00:00', 'app_open', 'S002', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('10', '202', '2024-03-01 11:02:00', 'click', 'S002', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('11', '202', '2024-03-01 11:05:00', 'scroll', 'S002', '400')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('12', '202', '2024-03-01 11:08:00', 'click', 'S002', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('13', '202', '2024-03-01 11:10:00', 'scroll', 'S002', '350')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('14', '202', '2024-03-01 11:15:00', 'purchase', 'S002', '50')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('15', '202', '2024-03-01 11:20:00', 'app_close', 'S002', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('16', '203', '2024-03-01 12:00:00', 'app_open', 'S003', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('17', '203', '2024-03-01 12:10:00', 'scroll', 'S003', '1000')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('18', '203', '2024-03-01 12:20:00', 'scroll', 'S003', '1200')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('19', '203', '2024-03-01 12:25:00', 'click', 'S003', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('20', '203', '2024-03-01 12:30:00', 'scroll', 'S003', '800')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('21', '203', '2024-03-01 12:40:00', 'scroll', 'S003', '900')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('22', '203', '2024-03-01 12:50:00', 'scroll', 'S003', '1100')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('23', '203', '2024-03-01 13:00:00', 'app_close', 'S003', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('24', '204', '2024-03-01 14:00:00', 'app_open', 'S004', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('25', '204', '2024-03-01 14:05:00', 'scroll', 'S004', '600')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('26', '204', '2024-03-01 14:08:00', 'scroll', 'S004', '700')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('27', '204', '2024-03-01 14:10:00', 'click', 'S004', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('28', '204', '2024-03-01 14:12:00', 'app_close', 'S004', NULL)
```

**Pandas Schema**

```python
data = [[1, 201, '2024-03-01 10:00:00', 'app_open', 'S001', None], [2, 201, '2024-03-01 10:05:00', 'scroll', 'S001', 500], [3, 201, '2024-03-01 10:10:00', 'scroll', 'S001', 750], [4, 201, '2024-03-01 10:15:00', 'scroll', 'S001', 600], [5, 201, '2024-03-01 10:20:00', 'scroll', 'S001', 800], [6, 201, '2024-03-01 10:25:00', 'scroll', 'S001', 550], [7, 201, '2024-03-01 10:30:00', 'scroll', 'S001', 900], [8, 201, '2024-03-01 10:35:00', 'app_close', 'S001', None], [9, 202, '2024-03-01 11:00:00', 'app_open', 'S002', None], [10, 202, '2024-03-01 11:02:00', 'click', 'S002', None], [11, 202, '2024-03-01 11:05:00', 'scroll', 'S002', 400], [12, 202, '2024-03-01 11:08:00', 'click', 'S002', None], [13, 202, '2024-03-01 11:10:00', 'scroll', 'S002', 350], [14, 202, '2024-03-01 11:15:00', 'purchase', 'S002', 50], [15, 202, '2024-03-01 11:20:00', 'app_close', 'S002', None], [16, 203, '2024-03-01 12:00:00', 'app_open', 'S003', None], [17, 203, '2024-03-01 12:10:00', 'scroll', 'S003', 1000], [18, 203, '2024-03-01 12:20:00', 'scroll', 'S003', 1200], [19, 203, '2024-03-01 12:25:00', 'click', 'S003', None], [20, 203, '2024-03-01 12:30:00', 'scroll', 'S003', 800], [21, 203, '2024-03-01 12:40:00', 'scroll', 'S003', 900], [22, 203, '2024-03-01 12:50:00', 'scroll', 'S003', 1100], [23, 203, '2024-03-01 13:00:00', 'app_close', 'S003', None], [24, 204, '2024-03-01 14:00:00', 'app_open', 'S004', None], [25, 204, '2024-03-01 14:05:00', 'scroll', 'S004', 600], [26, 204, '2024-03-01 14:08:00', 'scroll', 'S004', 700], [27, 204, '2024-03-01 14:10:00', 'click', 'S004', None], [28, 204, '2024-03-01 14:12:00', 'app_close', 'S004', None]]
app_events = pd.DataFrame({
    "event_id": pd.Series(dtype="int"),
    "user_id": pd.Series(dtype="int"),
    "event_timestamp": pd.Series(dtype="datetime64[ns]"),
    "event_type": pd.Series(dtype="string"),   # varchar -> string
    "session_id": pd.Series(dtype="string"),   # varchar -> string
    "event_value": pd.Series(dtype="int")
})
```

> 表：`app_events`
>
> ```c
> +------------------+----------+
> | Column Name      | Type     |
> +------------------+----------+
> | event_id         | int      |
> | user_id          | int      |
> | event_timestamp  | datetime |
> | event_type       | varchar  |
> | session_id       | varchar  |
> | event_value      | int      |
> +------------------+----------+
> ```
>
> event_id 是这张表的唯一主键。
> event_type 可以是 app_open，click，scroll，purchase 或 app_close。
> session_id 将事件按同一用户会话分组。
> event_value 表示：对于 purchase - 美元金额，对于 scroll - 滚动的像素数，对于其它 - NULL。

编写一个解决方案来识别 **僵尸会话**，即用户看似活跃但表现出异常行为模式的会话。如果会话满足以下所有条件，则被视为 **僵尸会话**：

- 会话时长 **超过** `30` 分钟。
- 至少有 `5` 次滚动事件。
- 点击滚动比率低于 `0.20`。
- 会话期间 **没有进行任何购买**。

返回结果表按 `scroll_count` **降序** 排序，然后按 `session_id` **升序** 排序。

返回格式如下所示。

**示例：**

> **输入：**
>
> app_events 表：
>
> ```c
> +----------+---------+---------------------+------------+------------+-------------+
> | event_id | user_id | event_timestamp     | event_type | session_id | event_value |
> +----------+---------+---------------------+------------+------------+-------------+
> | 1        | 201     | 2024-03-01 10:00:00 | app_open   | S001       | NULL        |
> | 2        | 201     | 2024-03-01 10:05:00 | scroll     | S001       | 500         |
> | 3        | 201     | 2024-03-01 10:10:00 | scroll     | S001       | 750         |
> | 4        | 201     | 2024-03-01 10:15:00 | scroll     | S001       | 600         |
> | 5        | 201     | 2024-03-01 10:20:00 | scroll     | S001       | 800         |
> | 6        | 201     | 2024-03-01 10:25:00 | scroll     | S001       | 550         |
> | 7        | 201     | 2024-03-01 10:30:00 | scroll     | S001       | 900         |
> | 8        | 201     | 2024-03-01 10:35:00 | app_close  | S001       | NULL        |
> | 9        | 202     | 2024-03-01 11:00:00 | app_open   | S002       | NULL        |
> | 10       | 202     | 2024-03-01 11:02:00 | click      | S002       | NULL        |
> | 11       | 202     | 2024-03-01 11:05:00 | scroll     | S002       | 400         |
> | 12       | 202     | 2024-03-01 11:08:00 | click      | S002       | NULL        |
> | 13       | 202     | 2024-03-01 11:10:00 | scroll     | S002       | 350         |
> | 14       | 202     | 2024-03-01 11:15:00 | purchase   | S002       | 50          |
> | 15       | 202     | 2024-03-01 11:20:00 | app_close  | S002       | NULL        |
> | 16       | 203     | 2024-03-01 12:00:00 | app_open   | S003       | NULL        |
> | 17       | 203     | 2024-03-01 12:10:00 | scroll     | S003       | 1000        |
> | 18       | 203     | 2024-03-01 12:20:00 | scroll     | S003       | 1200        |
> | 19       | 203     | 2024-03-01 12:25:00 | click      | S003       | NULL        |
> | 20       | 203     | 2024-03-01 12:30:00 | scroll     | S003       | 800         |
> | 21       | 203     | 2024-03-01 12:40:00 | scroll     | S003       | 900         |
> | 22       | 203     | 2024-03-01 12:50:00 | scroll     | S003       | 1100        |
> | 23       | 203     | 2024-03-01 13:00:00 | app_close  | S003       | NULL        |
> | 24       | 204     | 2024-03-01 14:00:00 | app_open   | S004       | NULL        |
> | 25       | 204     | 2024-03-01 14:05:00 | scroll     | S004       | 600         |
> | 26       | 204     | 2024-03-01 14:08:00 | scroll     | S004       | 700         |
> | 27       | 204     | 2024-03-01 14:10:00 | click      | S004       | NULL        |
> | 28       | 204     | 2024-03-01 14:12:00 | app_close  | S004       | NULL        |
> +----------+---------+---------------------+------------+------------+-------------+
> ```
>
> **输出：**
>
> ```c
> +------------+---------+--------------------------+--------------+
> | session_id | user_id | session_duration_minutes | scroll_count |
> +------------+---------+--------------------------+--------------+
> | S001       | 201     | 35                       | 6            |
> +------------+---------+--------------------------+--------------+
> ```
>
> **解释：**
>
> - **会话 S001 (User 201)**:
>   - 时长：10:00:00 到 10:35:00 = 35 分钟（大于 30 分钟）
>   - 滚动事件：6（至少 5 次）
>   - 点击事件：0
>   - 点击滚动比率：0/6 = 0.00（少于 0.20）
>   - 购买数：0（没有购买）
>   - S001 是一个僵尸会话（满足所有条件）
> - **会话 S002 (User 202)**:
>   - 时长：11:00:00 到 11:20:00 = 20 分钟（少于 30 分钟）
>   - 有一次购买事件
>   - S002 不是一个僵尸会话
> - **会话 S003 (User 203)**:
>   - 时长：12:00:00 到 13:00:00 = 60 分钟（超过 30 分钟）
>   - 滚动事件：5（至少 5 次）
>   - 点击事件：1
>   - 点击滚动比率：1/5 = 0.20（不少于 0.20）
>   - 购买数：0（没有购买）
>   - S003 不是一个僵尸会话（点击滚动比率等于 0.20，需要更少）。
> - **会话 S004 (User 204)**:
>   - 时长：14:00:00 到 14:12:00 = 12 分钟（少于 30 分钟）
>   - 滚动事件：2（少于 5 次）
>   - S004  不是一个僵尸会话
>
> 结果表按 scroll_count 降序排序，然后按 session_id 升序排序。
