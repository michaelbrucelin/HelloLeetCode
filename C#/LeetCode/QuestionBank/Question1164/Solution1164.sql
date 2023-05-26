;WITH c0 AS(
SELECT DISTINCT product_id FROM Products
), c1 AS(
SELECT product_id, MAX(change_date) AS change_date
FROM Products
WHERE change_date <= '2019-08-16'
GROUP BY product_id
), c2 AS(
SELECT a.product_id, a.new_price AS price
FROM Products AS a INNER JOIN c1
    ON c1.product_id = a.product_id AND c1.change_date = a.change_date
)
SELECT c0.product_id, ISNULL(c2.price, 10) AS price
FROM c0 LEFT JOIN c2 ON c2.product_id = c0.product_id
