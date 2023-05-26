;WITH c0 AS(
SELECT product_id, MIN(year) AS min_yesr FROM Sales GROUP BY product_id
)
SELECT a.product_id, a.[year] AS first_year, a.quantity, a.price
FROM Sales AS a
INNER JOIN c0 ON c0.product_id = a.product_id AND c0.min_yesr = a.[year]

-- OR

-- 提交超时
;WITH c0 AS(
SELECT product_id, [year], quantity, price
       , RANK() OVER(PARTITION BY product_id ORDER BY [year]) AS rid
FROM Sales
)
SELECT product_id, [year] AS first_year, quantity, price
FROM c0 WHERE rid = 1
