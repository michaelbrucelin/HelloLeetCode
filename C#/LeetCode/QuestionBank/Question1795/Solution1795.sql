SELECT product_id, 'store1' AS store, store1 AS price FROM Products WHERE store1 IS NOT NULL
UNION ALL
SELECT product_id, 'store2', store2 FROM Products WHERE store2 IS NOT NULL
UNION ALL
SELECT product_id, 'store3', store3 FROM Products WHERE store3 IS NOT NULL

-- OR

;WITH cte AS(
SELECT a.product_id, b.store
       , CASE b.store WHEN 'store1' THEN a.store1 WHEN 'store2' THEN a.store2 WHEN 'store3' THEN a.store3 END AS price
FROM Products AS a
CROSS JOIN (VALUES('store1'),('store2'),('store3')) AS b(store)
)
SELECT * FROM cte WHERE price IS NOT NULL

-- OR

SELECT product_id, store, price
FROM Products UNPIVOT(price FOR store IN (store1,store2,store3)) AS unpt
