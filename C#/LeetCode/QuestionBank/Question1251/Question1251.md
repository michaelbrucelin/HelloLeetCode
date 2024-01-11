### [1251\. 平均售价](https://leetcode.cn/problems/average-selling-price/)

难度：简单

SQL Schema

```sql
Create table If Not Exists Prices (product_id int, start_date date, end_date date, price int)
Create table If Not Exists UnitsSold (product_id int, purchase_date date, units int)
Truncate table Prices
insert into Prices (product_id, start_date, end_date, price) values ('1', '2019-02-17', '2019-02-28', '5')
insert into Prices (product_id, start_date, end_date, price) values ('1', '2019-03-01', '2019-03-22', '20')
insert into Prices (product_id, start_date, end_date, price) values ('2', '2019-02-01', '2019-02-20', '15')
insert into Prices (product_id, start_date, end_date, price) values ('2', '2019-02-21', '2019-03-31', '30')
Truncate table UnitsSold
insert into UnitsSold (product_id, purchase_date, units) values ('1', '2019-02-25', '100')
insert into UnitsSold (product_id, purchase_date, units) values ('1', '2019-03-01', '15')
insert into UnitsSold (product_id, purchase_date, units) values ('2', '2019-02-10', '200')
insert into UnitsSold (product_id, purchase_date, units) values ('2', '2019-03-22', '30')
```

Pandas Schema

```python
data = [[1, '2019-02-17', '2019-02-28', 5], [1, '2019-03-01', '2019-03-22', 20], [2, '2019-02-01', '2019-02-20', 15], [2, '2019-02-21', '2019-03-31', 30]]
prices = pd.DataFrame(data, columns=['product_id', 'start_date', 'end_date', 'price']).astype({'product_id':'Int64', 'start_date':'datetime64[ns]', 'end_date':'datetime64[ns]', 'price':'Int64'})
data = [[1, '2019-02-25', 100], [1, '2019-03-01', 15], [2, '2019-02-10', 200], [2, '2019-03-22', 30]]
units_sold = pd.DataFrame(data, columns=['product_id', 'purchase_date', 'units']).astype({'product_id':'Int64', 'purchase_date':'datetime64[ns]', 'units':'Int64'})
```

表：`Prices`

```
+---------------+---------+
| Column Name   | Type    |
+---------------+---------+
| product_id    | int     |
| start_date    | date    |
| end_date      | date    |
| price         | int     |
+---------------+---------+
(product_id，start_date，end_date) 是 prices 表的主键（具有唯一值的列的组合）。
prices 表的每一行表示的是某个产品在一段时期内的价格。
每个产品的对应时间段是不会重叠的，这也意味着同一个产品的价格时段不会出现交叉。
```

表：`UnitsSold`

```
+---------------+---------+
| Column Name   | Type    |
+---------------+---------+
| product_id    | int     |
| purchase_date | date    |
| units         | int     |
+---------------+---------+
<span style="white-space: pre-wrap;">该表可能包含重复数据</span>。
<span style="white-space: pre-wrap;">该</span>表的每一行表示的是每种产品的出售日期，单位和产品 id。
```

编写解决方案以查找每种产品的平均售价。`average_price` 应该 **四舍五入到小数点后两位**。

返回结果表 **无顺序要求** 。

结果格式如下例所示。

**示例 1：**

> **输入：**
> ```
> Prices table:
> +------------+------------+------------+--------+
> | product_id | start_date | end_date   | price  |
> +------------+------------+------------+--------+
> | 1          | 2019-02-17 | 2019-02-28 | 5      |
> | 1          | 2019-03-01 | 2019-03-22 | 20     |
> | 2          | 2019-02-01 | 2019-02-20 | 15     |
> | 2          | 2019-02-21 | 2019-03-31 | 30     |
> +------------+------------+------------+--------+
> 
> UnitsSold table:
> +------------+---------------+-------+
> | product_id | purchase_date | units |
> +------------+---------------+-------+
> | 1          | 2019-02-25    | 100   |
> | 1          | 2019-03-01    | 15    |
> | 2          | 2019-02-10    | 200   |
> | 2          | 2019-03-22    | 30    |
> +------------+---------------+-------+
> ```
> **输出：**
> ```
> +------------+---------------+
> | product_id | average_price |
> +------------+---------------+
> | 1          | 6.96          |
> | 2          | 16.96         |
> +------------+---------------+
> ```
> **解释：** 
> ```
> 平均售价 = 产品总价 / 销售的产品数量。
> 产品 1 的平均售价 = ((100 * 5)+(15 * 20) )/ 115 = 6.96
> 产品 2 的平均售价 = ((200 * 15)+(30 * 30) )/ 230 = 16.96
> ```
