### [3465\. 查找具有有效序列号的产品](https://leetcode.cn/problems/find-products-with-valid-serial-numbers/)

难度：简单

**SQL Schema**

```sql
CREATE TABLE If not exists products (
    product_id INT,
    product_name VARCHAR(255),
    description VARCHAR(255)
)

Truncate table products
insert into products (product_id, product_name, description) values ('1', 'Widget A', 'This is a sample product with SN1234-5678')
insert into products (product_id, product_name, description) values ('2', 'Widget B', 'A product with serial SN9876-1234 in the description')
insert into products (product_id, product_name, description) values ('3', 'Widget C', 'Product SN1234-56789 is available now')
insert into products (product_id, product_name, description) values ('4', 'Widget D', 'No serial number here')
insert into products (product_id, product_name, description) values ('5', 'Widget E', 'Check out SN4321-8765 in this description')
```

**Pandas Schema**

```python
data = [[1, 'Widget A', 'This is a sample product with SN1234-5678'], [2, 'Widget B', 'A product with serial SN9876-1234 in the description'], [3, 'Widget C', 'Product SN1234-56789 is available now'], [4, 'Widget D', 'No serial number here'], [5, 'Widget E', 'Check out SN4321-8765 in this description']]
products = pd.DataFrame(columns=['product_id', 'product_name', 'description']).astype({'product_id': 'int32', 'product_name': 'string', 'description': 'string'})
```

> 表：`products`
>
> ```c
> +--------------+------------+
> | Column Name  | Type       |
> +--------------+------------+
> | product_id   | int        |
> | product_name | varchar    |
> | description  | varchar    |
> +--------------+------------+
> ```
>
> (product_id) 是这张表的唯一主键。
> 这张表的每一行表示一个产品的唯一 ID，名字和描述。

编写一个解决方案来找到所有描述中 **包含一个有效序列号** 模式的产品。一个有效序列号符合下述规则：

- 以 **SN** 字母开头（区分大小写）。
- 后面有恰好 `4` 位数字。
- 接着是一个短横（-）， 短横后面还有另一组 `4` **位数字**
- 序列号必须在描述内（可能不在描述的开头）

返回结果表以 `product_id` **升序** 排序。

结果格式如下所示。

**示例：**

> **输入：**
>
> products 表：
>
> ```c
> +------------+--------------+------------------------------------------------------+
> | product_id | product_name | description                                          |
> +------------+--------------+------------------------------------------------------+
> | 1          | Widget A     | This is a sample product with SN1234-5678            |
> | 2          | Widget B     | A product with serial SN9876-1234 in the description |
> | 3          | Widget C     | Product SN1234-56789 is available now                |
> | 4          | Widget D     | No serial number here                                |
> | 5          | Widget E     | Check out SN4321-8765 in this description            |
> +------------+--------------+------------------------------------------------------+
> ```
>
> **输出：**
>
> ```c
> +------------+--------------+------------------------------------------------------+
> | product_id | product_name | description                                          |
> +------------+--------------+------------------------------------------------------+
> | 1          | Widget A     | This is a sample product with SN1234-5678            |
> | 2          | Widget B     | A product with serial SN9876-1234 in the description |
> | 5          | Widget E     | Check out SN4321-8765 in this description            |
> +------------+--------------+------------------------------------------------------+
> ```
>
> **解释：**
>
> - **产品 1：** 有效的序列号 SN1234-5678
> - **产品 2：** 有效的序列号 SN9876-1234
> - **产品 3：** 无效的序列号 SN1234-56789（短横后包含 5 位数字）
> - **产品 4：** 描述中没有序列号
> - **产品 5：** 有效的序列号 SN4321-8765
>
> 结果表以 product_id 升序排序。
