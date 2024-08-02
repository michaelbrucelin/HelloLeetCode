### [3220\. 奇数和偶数交易](https://leetcode.cn/problems/odd-and-even-transactions/)

难度：中等

SQL Schema

```sql
Create table if not exists transactions ( transaction_id int, amount int, transaction_date date)
Truncate table transactions
insert into transactions (transaction_id, amount, transaction_date) values ('1', '150', '2024-07-01')
insert into transactions (transaction_id, amount, transaction_date) values ('2', '200', '2024-07-01')
insert into transactions (transaction_id, amount, transaction_date) values ('3', '75', '2024-07-01')
insert into transactions (transaction_id, amount, transaction_date) values ('4', '300', '2024-07-02')
insert into transactions (transaction_id, amount, transaction_date) values ('5', '50', '2024-07-02')
insert into transactions (transaction_id, amount, transaction_date) values ('6', '120', '2024-07-03')
```

Pandas Schema

```python
data = [[1, 150, '2024-07-01'], [2, 200, '2024-07-01'], [3, 75, '2024-07-01'], [4, 300, '2024-07-02'], [5, 50, '2024-07-02'], [6, 120, '2024-07-03']]
transactions = pd.DataFrame(
    columns=["transaction_id", "amount", "transaction_date"],
    dtype={
        "transaction_id": "int",
        "amount": "int",
        "transaction_date": "datetime64[ns]",
    },
)
```

表：`transactions`

> ```
> +------------------+------+
> | Column Name      | Type |
> +------------------+------+
> | transaction_id   | int  |
> | amount           | int  |
> | transaction_date | date |
> +------------------+------+
> ```
> transactions_id 列唯一标识了表中的每一行。
> 这张表的每一行包含交易 id，金额总和和交易日期。

编写一个解决方案来查找每天 **奇数** 交易金额和 **偶数** 交易金额的 **总和**。如果某天没有奇数或偶数交易，显示为 `0`。

返回结果表以 `transaction_date` **升序** 排序。

结果格式如下所示。

**示例：**

> **输入：**
> `transactions` 表：
> ```
> +----------------+--------+------------------+
> | transaction_id | amount | transaction_date |
> +----------------+--------+------------------+
> | 1              | 150    | 2024-07-01       |
> | 2              | 200    | 2024-07-01       |
> | 3              | 75     | 2024-07-01       |
> | 4              | 300    | 2024-07-02       |
> | 5              | 50     | 2024-07-02       |
> | 6              | 120    | 2024-07-03       |
> +----------------+--------+------------------+
> ```
>
> **输出：**
> ```
> +------------------+---------+----------+
> | transaction_date | odd_sum | even_sum |
> +------------------+---------+----------+
> | 2024-07-01       | 75      | 350      |
> | 2024-07-02       | 0       | 350      |
> | 2024-07-03       | 0       | 120      |
> +------------------+---------+----------+
> ```
>
> **解释：**
> - 对于交易日期：
>     - 2024-07-01:
>         - 奇数交易金额总和：75
>         - 偶数交易金额总和：150 + 200 = 350
>     - 2024-07-02:
>         - 奇数交易金额总和：0
>         - 偶数交易金额总和：300 + 50 = 350
>     - 2024-07-03:
>         - 奇数交易金额总和：0
>         - 偶数交易金额总和：120
>
> **注意：**输出表以 `transaction_date` 升序排序。
