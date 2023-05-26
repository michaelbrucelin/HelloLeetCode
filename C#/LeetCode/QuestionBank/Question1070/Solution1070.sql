;WITH c0 AS(
SELECT product_id, MIN(year) AS min_yesr FROM Sales GROUP BY product_id
)
SELECT a.product_id, a.[year] AS first_year, a.quantity, a.price
FROM Sales AS a
INNER JOIN c0 ON c0.product_id = a.product_id AND c0.min_yesr = a.[year]

-- OR

