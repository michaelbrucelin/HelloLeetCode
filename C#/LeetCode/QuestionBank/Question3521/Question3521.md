### [3521\. 查找推荐产品对](https://leetcode.cn/problems/find-product-recommendation-pairs/)

难度：中等

**SQL Schema**

```sql
CREATE TABLE if not exists ProductPurchases (
    user_id INT,
    product_id INT,
    quantity INT
)
CREATE TABLE  if not exists ProductInfo (
    product_id INT,
    category VARCHAR(100),
    price DECIMAL(10, 2)
)
Truncate table ProductPurchases
insert into ProductPurchases (user_id, product_id, quantity) values ('1', '101', '2')
insert into ProductPurchases (user_id, product_id, quantity) values ('1', '102', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('1', '103', '3')
insert into ProductPurchases (user_id, product_id, quantity) values ('2', '101', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('2', '102', '5')
insert into ProductPurchases (user_id, product_id, quantity) values ('2', '104', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('3', '101', '2')
insert into ProductPurchases (user_id, product_id, quantity) values ('3', '103', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('3', '105', '4')
insert into ProductPurchases (user_id, product_id, quantity) values ('4', '101', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('4', '102', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('4', '103', '2')
insert into ProductPurchases (user_id, product_id, quantity) values ('4', '104', '3')
insert into ProductPurchases (user_id, product_id, quantity) values ('5', '102', '2')
insert into ProductPurchases (user_id, product_id, quantity) values ('5', '104', '1')
Truncate table ProductInfo
insert into ProductInfo (product_id, category, price) values ('101', 'Electronics', '100')
insert into ProductInfo (product_id, category, price) values ('102', 'Books', '20')
insert into ProductInfo (product_id, category, price) values ('103', 'Clothing', '35')
insert into ProductInfo (product_id, category, price) values ('104', 'Kitchen', '50')
insert into ProductInfo (product_id, category, price) values ('105', 'Sports', '75')
```

**Pandas Schema**

```python
data = [[1, 101, 2], [1, 102, 1], [1, 103, 3], [2, 101, 1], [2, 102, 5], [2, 104, 1], [3, 101, 2], [3, 103, 1], [3, 105, 4], [4, 101, 1], [4, 102, 1], [4, 103, 2], [4, 104, 3], [5, 102, 2], [5, 104, 1]]
product_purchases = pd.DataFrame({
    "user_id": pd.Series(dtype='int64'),
    "product_id": pd.Series(dtype='int64'),
    "quantity": pd.Series(dtype='int64')
})
data = [[101, 'Electronics', 100], [102, 'Books', 20], [103, 'Clothing', 35], [104, 'Kitchen', 50], [105, 'Sports', 75]]
product_info= pd.DataFrame({
    "product_id": pd.Series(dtype='int64'),
    "category": pd.Series(dtype='string'),
    "price": pd.Series(dtype='float64')  # Reflects NUMBER(10, 2)
})
```

> 表：`ProductPurchases`
>
> ```c
> +-------------+------+
> | Column Name | Type |
> +-------------+------+
> | user_id     | int  |
> | product_id  | int  |
> | quantity    | int  |
> +-------------+------+
> ```
>
> (user_id, product_id) 是这张表的唯一主键。
> 每一行代表用户以特定数量购买的产品。
>
> 表：`ProductInfo`
>
> ```c
> +-------------+---------+
> | Column Name | Type    |
> +-------------+---------+
> | product_id  | int     |
> | category    | varchar |
> | price       | decimal |
> +-------------+---------+
> ```
>
> product_id 是这张表的唯一主键。
> 每一行表示一个产品的类别和价格。

亚马逊希望根据 **共同购买模式** 实现 “**购买此商品的用户还购买了...**” 功能。编写一个解决方案以实现：

1. 识别 **被同一客户一起频繁购买的** **不同** 产品对（其中 `product1_id` < `product2_id`）
2. 对于 **每个产品对**，确定有多少客户购买了这两种产品

如果 **至少有** `3` **位不同的** 客户同时购买了这两种产品，则认为该 **产品对** 适合推荐。

返回结果表以 **customer_count**  **降序** 排序，并且为了避免排序持平，以 `product1_id` **升序** 排序，并以 `product2_id` **升序** 排序。

结果格式如下所示。

**示例：**

> **输入：**
>
> ProductPurchases 表：
>
> ```c
> +---------+------------+----------+
> | user_id | product_id | quantity |
> +---------+------------+----------+
> | 1       | 101        | 2        |
> | 1       | 102        | 1        |
> | 1       | 103        | 3        |
> | 2       | 101        | 1        |
> | 2       | 102        | 5        |
> | 2       | 104        | 1        |
> | 3       | 101        | 2        |
> | 3       | 103        | 1        |
> | 3       | 105        | 4        |
> | 4       | 101        | 1        |
> | 4       | 102        | 1        |
> | 4       | 103        | 2        |
> | 4       | 104        | 3        |
> | 5       | 102        | 2        |
> | 5       | 104        | 1        |
> +---------+------------+----------+
> ```
>
> ProductInfo 表：
>
> ```c
> +------------+-------------+-------+
> | product_id | category    | price |
> +------------+-------------+-------+
> | 101        | Electronics | 100   |
> | 102        | Books       | 20    |
> | 103        | Clothing    | 35    |
> | 104        | Kitchen     | 50    |
> | 105        | Sports      | 75    |
> +------------+-------------+-------+
> ```
>
> **输出：**
>
> ```c
> +-------------+-------------+-------------------+-------------------+----------------+
> | product1_id | product2_id | product1_category | product2_category | customer_count |
> +-------------+-------------+-------------------+-------------------+----------------+
> | 101         | 102         | Electronics       | Books             | 3              |
> | 101         | 103         | Electronics       | Clothing          | 3              |
> | 102         | 104         | Books             | Kitchen           | 3              |
> +-------------+-------------+-------------------+-------------------+----------------+
> ```
>
> **解释：**
>
> - **产品对 (101, 102)：**
>   - 被用户 1，2 和 4 购买（3 个消费者）
>   - 产品 101 属于电子商品类别
>   - 产品 102 属于图书类别
> - **产品对 (101, 103)：**
>   - 被用户 1，3 和 4 购买（3 个消费者）
>   - 产品 101 属于电子商品类别
>   - 产品 103 属于服装类别
> - **产品对 (102, 104)：**
>   - 被用户 2，4 和 5 购买（3 个消费者）
>   - 产品 102 属于图书类别
>   - 产品 104 属于厨房用品类别
>
> 结果以 customer_count 降序排序。对于有相同 customer_count 的产品对，将它们以 product1_id 升序排序，然后以 product2_id 升序排序。
