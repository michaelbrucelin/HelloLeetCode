SELECT b.product_name, a.[year], a.price
FROM Sales AS a
INNER JOIN Product AS b ON b.product_id = a.product_id
