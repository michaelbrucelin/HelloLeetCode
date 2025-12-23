### [3626\. 查找库存不平衡的店铺](https://leetcode.cn/problems/find-stores-with-inventory-imbalance/)

难度：中等

**SQL Schema**

```sql
CREATE TABLE if not exists stores (
    store_id INT,
    store_name VARCHAR(255),
    location VARCHAR(255)
)
CREATE TABLE if not exists inventory (
    inventory_id INT,
    store_id INT,
    product_name VARCHAR(255),
    quantity INT,
    price DECIMAL(10, 2)
)
Truncate table stores
insert into stores (store_id, store_name, location) values ('1', 'Downtown Tech', 'New York')
insert into stores (store_id, store_name, location) values ('2', 'Suburb Mall', 'Chicago')
insert into stores (store_id, store_name, location) values ('3', 'City Center', 'Los Angeles')
insert into stores (store_id, store_name, location) values ('4', 'Corner Shop', 'Miami')
insert into stores (store_id, store_name, location) values ('5', 'Plaza Store', 'Seattle')
Truncate table inventory
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('1', '1', 'Laptop', '5', '999.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('2', '1', 'Mouse', '50', '19.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('3', '1', 'Keyboard', '25', '79.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('4', '1', 'Monitor', '15', '299.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('5', '2', 'Phone', '3', '699.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('6', '2', 'Charger', '100', '25.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('7', '2', 'Case', '75', '15.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('8', '2', 'Headphones', '20', '149.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('9', '3', 'Tablet', '2', '499.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('10', '3', 'Stylus', '80', '29.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('11', '3', 'Cover', '60', '39.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('12', '4', 'Watch', '10', '299.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('13', '4', 'Band', '25', '49.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('14', '5', 'Camera', '8', '599.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('15', '5', 'Lens', '12', '199.99')
```

**Pandas Schema**

```python
data = [[1, 'Downtown Tech', 'New York'], [2, 'Suburb Mall', 'Chicago'], [3, 'City Center', 'Los Angeles'], [4, 'Corner Shop', 'Miami'], [5, 'Plaza Store', 'Seattle']]
stores = pd.DataFrame(data, columns=['store_id', 'store_name', 'location']).astype({'store_id': 'int64', 'store_name': 'string', 'location': 'string'})

data = [[1, 1, 'Laptop', 5, 999.99], [2, 1, 'Mouse', 50, 19.99], [3, 1, 'Keyboard', 25, 79.99], [4, 1, 'Monitor', 15, 299.99], [5, 2, 'Phone', 3, 699.99], [6, 2, 'Charger', 100, 25.99], [7, 2, 'Case', 75, 15.99], [8, 2, 'Headphones', 20, 149.99], [9, 3, 'Tablet', 2, 499.99], [10, 3, 'Stylus', 80, 29.99], [11, 3, 'Cover', 60, 39.99], [12, 4, 'Watch', 10, 299.99], [13, 4, 'Band', 25, 49.99], [14, 5, 'Camera', 8, 599.99], [15, 5, 'Lens', 12, 199.99]]
inventory = pd.DataFrame(data, columns=['inventory_id', 'store_id', 'product_name', 'quantity', 'price']).astype({'inventory_id': 'int64', 'store_id': 'int64', 'product_name': 'string', 'quantity': 'int64', 'price': 'float64'})
```

> 表：`stores`
>
> ```c
> +-------------+---------+
> | Column Name | Type    |
> +-------------+---------+
> | store_id    | int     |
> | store_name  | varchar |
> | location    | varchar |
> +-------------+---------+
> ```
>
> store_id 是这张表的唯一主键。
> 每一行包含有关商店及其位置的信息。
>
> 表：`inventory`
>
> ```c
> +-------------+---------+
> | Column Name | Type    |
> +-------------+---------+
> | inventory_id| int     |
> | store_id    | int     |
> | product_name| varchar |
> | quantity    | int     |
> | price       | decimal |
> +-------------+---------+
> ```
>
> inventory_id 是这张表的唯一主键。
> 每一行代表特定商店中某一特定产品的库存情况。

编写一个解决方案来查找库存不平衡的商店 - 即最贵商品的库存比最便宜商品少的商店。

- 对于每个商店，识别 **最贵的商品**（最高价格）及其数量，如果有多个最贵的商品则选取数量最多的一个。
- 对于每个商店，识别 **最便宜的商品**（最低价格）及其数量，如果有多个最便宜的物品则选取数量最多的一个。
- 如果最贵商品的数量 **少于** 最便宜商品的数量，则商店存在库存不平衡。
- 按（最便宜商品的数量/最贵商品的数量）计算 **不平衡比**。
- 不平衡比 **舍入到 2 位** 小数
- 结果只包含 **至少有** `3` **个不同商品** 的店铺

返回结果表以不平衡比率降序排列，然后按商店名称升序排列。

结果格式如下所示。

**示例：**

> **输入：**
>
> stores 表：
>
> ```c
> +----------+----------------+-------------+
> | store_id | store_name     | location    |
> +----------+----------------+-------------+
> | 1        | Downtown Tech  | New York    |
> | 2        | Suburb Mall    | Chicago     |
> | 3        | City Center    | Los Angeles |
> | 4        | Corner Shop    | Miami       |
> | 5        | Plaza Store    | Seattle     |
> +----------+----------------+-------------+
> ```
>
> inventory 表：
>
> ```c
> +--------------+----------+--------------+----------+--------+
> | inventory_id | store_id | product_name | quantity | price  |
> +--------------+----------+--------------+----------+--------+
> | 1            | 1        | Laptop       | 5        | 999.99 |
> | 2            | 1        | Mouse        | 50       | 19.99  |
> | 3            | 1        | Keyboard     | 25       | 79.99  |
> | 4            | 1        | Monitor      | 15       | 299.99 |
> | 5            | 2        | Phone        | 3        | 699.99 |
> | 6            | 2        | Charger      | 100      | 25.99  |
> | 7            | 2        | Case         | 75       | 15.99  |
> | 8            | 2        | Headphones   | 20       | 149.99 |
> | 9            | 3        | Tablet       | 2        | 499.99 |
> | 10           | 3        | Stylus       | 80       | 29.99  |
> | 11           | 3        | Cover        | 60       | 39.99  |
> | 12           | 4        | Watch        | 10       | 299.99 |
> | 13           | 4        | Band         | 25       | 49.99  |
> | 14           | 5        | Camera       | 8        | 599.99 |
> | 15           | 5        | Lens         | 12       | 199.99 |
> +--------------+----------+--------------+----------+--------+
> ```
>
> **输出：**
>
> ```c
> +----------+----------------+-------------+------------------+--------------------+------------------+
> | store_id | store_name     | location    | most_exp_product | cheapest_product   | imbalance_ratio  |
> +----------+----------------+-------------+------------------+--------------------+------------------+
> | 3        | City Center    | Los Angeles | Tablet           | Stylus             | 40.00            |
> | 1        | Downtown Tech  | New York    | Laptop           | Mouse              | 10.00            |
> | 2        | Suburb Mall    | Chicago     | Phone            | Case               | 25.00            |
> +----------+----------------+-------------+------------------+--------------------+------------------+
> ```
>
> **解释：**
>
> - **Downtown Tech (store_id = 1)：**
>   - 最贵的商品：笔记本（999.99）数量为 5
>   - 最便宜的商品：鼠标（19.99）数量为 50
>   - 库存不平衡：5 < 50（贵的商品的库存更少）
>   - 不平衡比：50 / 5 = 10.00
>   - 有 4 件商品（\ge  3），所以满足要求
> - **Suburb Mall (store_id = 2)：**
>   - 最贵的商品：手机（699.99）数量为 3
>   - 最便宜的商品：保护壳（15.99）数量为75
>   - 库存不平衡：3 < 75（贵的商品的库存更少）
>   - 不平衡比：75 / 3 = 25.00
>   - 有 4 件商品（\ge  3），所以满足要求
> - **City Center (store_id = 3)：**
>   - 最贵的商品：平板电脑（499.99）数量为 2
>   - 最便宜的商品：触控笔（29.99）数量为 80
>   - 不平衡比：2 < 80（贵的商品的库存更少）
>   - 不平衡比：80 / 2 = 40.00
>   - 有 3 件商品（\ge  3），所以满足要求
> - **未包含的商店：**
>   - Corner Shop（store_id = 4）：只有两件商品（手表，手环）- 不满足最少 3 件商品的要求
>   - Plaza Store（store_id = 5）：只有两件商品（相机，镜头）- 不满足最少 3 件商品的要求
>
> 结果表按不平衡比降序排序，然后以商店名升序排序。
