### [3642\. 查找有两极分化观点的书籍](https://leetcode.cn/problems/find-books-with-polarized-opinions/)

难度：简单

**SQL Schema**

```sql
CREATE TABLE books (
    book_id INT,
    title VARCHAR(255),
    author VARCHAR(255),
    genre VARCHAR(100),
    pages INT
)
CREATE TABLE reading_sessions (
    session_id INT,
    book_id INT,
    reader_name VARCHAR(255),
    pages_read INT,
    session_rating INT
)
Truncate table books
insert into books (book_id, title, author, genre, pages) values ('1', 'The Great Gatsby', 'F. Scott', 'Fiction', '180')
insert into books (book_id, title, author, genre, pages) values ('2', 'To Kill a Mockingbird', 'Harper Lee', 'Fiction', '281')
insert into books (book_id, title, author, genre, pages) values ('3', '1984', 'George Orwell', 'Dystopian', '328')
insert into books (book_id, title, author, genre, pages) values ('4', 'Pride and Prejudice', 'Jane Austen', 'Romance', '432')
insert into books (book_id, title, author, genre, pages) values ('5', 'The Catcher in the Rye', 'J.D. Salinger', 'Fiction', '277')
Truncate table reading_sessions
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('1', '1', 'Alice', '50', '5')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('2', '1', 'Bob', '60', '1')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('3', '1', 'Carol', '40', '4')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('4', '1', 'David', '30', '2')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('5', '1', 'Emma', '45', '5')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('6', '2', 'Frank', '80', '4')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('7', '2', 'Grace', '70', '4')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('8', '2', 'Henry', '90', '5')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('9', '2', 'Ivy', '60', '4')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('10', '2', 'Jack', '75', '4')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('11', '3', 'Kate', '100', '2')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('12', '3', 'Liam', '120', '1')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('13', '3', 'Mia', '80', '2')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('14', '3', 'Noah', '90', '1')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('15', '3', 'Olivia', '110', '4')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('16', '3', 'Paul', '95', '5')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('17', '4', 'Quinn', '150', '3')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('18', '4', 'Ruby', '140', '3')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('19', '5', 'Sam', '80', '1')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('20', '5', 'Tara', '70', '2')
```

**Pandas Schema**

```python
data = [[1, 'The Great Gatsby', 'F. Scott', 'Fiction', 180], [2, 'To Kill a Mockingbird', 'Harper Lee', 'Fiction', 281], [3, '1984', 'George Orwell', 'Dystopian', 328], [4, 'Pride and Prejudice', 'Jane Austen', 'Romance', 432], [5, 'The Catcher in the Rye', 'J.D. Salinger', 'Fiction', 277]]
books = pd.DataFrame({
    "book_id": pd.Series(dtype="int64"),      # SERIAL -> int64
    "title": pd.Series(dtype="string"),       # VARCHAR -> string dtype
    "author": pd.Series(dtype="string"),      # VARCHAR -> string dtype
    "genre": pd.Series(dtype="string"),       # VARCHAR -> string dtype
    "pages": pd.Series(dtype="int64")         # INTEGER -> int64
})
data = [[1, 1, 'Alice', 50, 5], [2, 1, 'Bob', 60, 1], [3, 1, 'Carol', 40, 4], [4, 1, 'David', 30, 2], [5, 1, 'Emma', 45, 5], [6, 2, 'Frank', 80, 4], [7, 2, 'Grace', 70, 4], [8, 2, 'Henry', 90, 5], [9, 2, 'Ivy', 60, 4], [10, 2, 'Jack', 75, 4], [11, 3, 'Kate', 100, 2], [12, 3, 'Liam', 120, 1], [13, 3, 'Mia', 80, 2], [14, 3, 'Noah', 90, 1], [15, 3, 'Olivia', 110, 4], [16, 3, 'Paul', 95, 5], [17, 4, 'Quinn', 150, 3], [18, 4, 'Ruby', 140, 3], [19, 5, 'Sam', 80, 1], [20, 5, 'Tara', 70, 2]]
reading_sessions = pd.DataFrame({
    "session_id": pd.Series(dtype="int64"),       # NUMBER -> int64
    "book_id": pd.Series(dtype="int64"),          # NUMBER -> int64
    "reader_name": pd.Series(dtype="string"),     # VARCHAR2 -> string dtype
    "pages_read": pd.Series(dtype="int64"),       # NUMBER -> int64
    "session_rating": pd.Series(dtype="int64")    # NUMBER -> int64
})
```

> 表：`books`
>
> ```c
> +-------------+---------+
> | Column Name | Type    |
> +-------------+---------+
> | book_id     | int     |
> | title       | varchar |
> | author      | varchar |
> | genre       | varchar |
> | pages       | int     |
> +-------------+---------+
> ```
>
> book_id 是这张表的唯一主键。
> 每一行包含关于一本书的信息，包括其类型和页数。
>
> 表：`reading_sessions`
>
> ```c
> +----------------+---------+
> | Column Name    | Type    |
> +----------------+---------+
> | session_id     | int     |
> | book_id        | int     |
> | reader_name    | varchar |
> | pages_read     | int     |
> | session_rating | int     |
> +----------------+---------+
> ```
>
> session_id 是这张表的唯一主键。
> 每一行代表一次阅读事件，有人阅读了书籍的一部分。session_rating 在 1-5 的范围内。

编写一个解决方案来找到具有 **两极分化观点** 的书 - 同时获得不同读者极高和极低评分的书籍。

- 如果一本书有至少一个大于等于 `4` 的评分和至少一个小于等于 `2` 的评分则是有两极分化观点的书
- 只考虑有至少 `5` 次阅读事件的书籍
- 按 `highest_rating - lowest_rating` 计算评分差幅 **rating spread**
- 按极端评分（评分小于等于 `2` 或大于等于 `4`）的数量除以总阅读事件计算 **极化得分 polarization score**
- **只包含** 极化得分大于等于 `0.6` 的书（至少 `60%` 极端评分）

返回结果表按极化得分 **降序** 排序，然后按标题 **降序** 排序。

返回格式如下所示。

**示例：**

> **输入：**
>
> books 表：
>
> ```c
> +---------+------------------------+---------------+----------+-------+
> | book_id | title                  | author        | genre    | pages |
> +---------+------------------------+---------------+----------+-------+
> | 1       | The Great Gatsby       | F. Scott      | Fiction  | 180   |
> | 2       | To Kill a Mockingbird  | Harper Lee    | Fiction  | 281   |
> | 3       | 1984                   | George Orwell | Dystopian| 328   |
> | 4       | Pride and Prejudice    | Jane Austen   | Romance  | 432   |
> | 5       | The Catcher in the Rye | J.D. Salinger | Fiction  | 277   |
> +---------+------------------------+---------------+----------+-------+
> ```
>
> reading_sessions 表：
>
> ```c
> +------------+---------+-------------+------------+----------------+
> | session_id | book_id | reader_name | pages_read | session_rating |
> +------------+---------+-------------+------------+----------------+
> | 1          | 1       | Alice       | 50         | 5              |
> | 2          | 1       | Bob         | 60         | 1              |
> | 3          | 1       | Carol       | 40         | 4              |
> | 4          | 1       | David       | 30         | 2              |
> | 5          | 1       | Emma        | 45         | 5              |
> | 6          | 2       | Frank       | 80         | 4              |
> | 7          | 2       | Grace       | 70         | 4              |
> | 8          | 2       | Henry       | 90         | 5              |
> | 9          | 2       | Ivy         | 60         | 4              |
> | 10         | 2       | Jack        | 75         | 4              |
> | 11         | 3       | Kate        | 100        | 2              |
> | 12         | 3       | Liam        | 120        | 1              |
> | 13         | 3       | Mia         | 80         | 2              |
> | 14         | 3       | Noah        | 90         | 1              |
> | 15         | 3       | Olivia      | 110        | 4              |
> | 16         | 3       | Paul        | 95         | 5              |
> | 17         | 4       | Quinn       | 150        | 3              |
> | 18         | 4       | Ruby        | 140        | 3              |
> | 19         | 5       | Sam         | 80         | 1              |
> | 20         | 5       | Tara        | 70         | 2              |
> +------------+---------+-------------+------------+----------------+
> ```
>
> **输出：**
>
> ```c
> +---------+------------------+---------------+-----------+-------+---------------+--------------------+
> | book_id | title            | author        | genre     | pages | rating_spread | polarization_score |
> +---------+------------------+---------------+-----------+-------+---------------+--------------------+
> | 1       | The Great Gatsby | F. Scott      | Fiction   | 180   | 4             | 1.00               |
> | 3       | 1984             | George Orwell | Dystopian | 328   | 4             | 1.00               |
> +---------+------------------+---------------+-----------+-------+---------------+--------------------+
> ```
>
> **解释：**
>
> - **了不起的盖茨比（book_id = 1）：**
>   - 有 5 次阅读事件（满足最少要求）
>   - 评分：5, 1, 4, 2, 5
>   - 大于等于 4 的评分：5，4，5（3 次事件）
>   - 小于等于 2 的评分：1，2（2 次事件）
>   - 评分差：5 - 1 = 4
>   - 极端评分（\le 2 或 \ge 4）：所有 5 次事件（5，1，4，2，5）
>   - 极化得分：5/5 = 1.00（\ge  0.6，符合）
> - **1984 (book_id = 3):**
>   - 有 6 次阅读事件（满足最少要求）
>   - 评分：2，1，2，1，4，5
>   - 大于等于 4 的评分：4，5（2 次事件）
>   - 小于等于 2 的评分：2，1，2，1（4 次事件）
>   - 评分差：5 - 1 = 4
>   - 极端评分（\le 2 或 \ge 4）：所有 6 次事件（2，1，2，1，4，5）
>   - 极化得分：6/6 = 1.00 (\ge  0.6，符合）
> - **未包含的书：**
>   - 杀死一只知更鸟（book_id = 2）：所有评分为 4-5，没有低分（\le 2）
>   - 傲慢与偏见（book_id = 4）：只有 2 次事件（< 最少 5 次）
>   - 麦田里的守望者（book_id = 5）：只有 2 次事件（< 最少 5 次）
>
> 结果表按极化得分降序排序，然后按标题降序排序。
