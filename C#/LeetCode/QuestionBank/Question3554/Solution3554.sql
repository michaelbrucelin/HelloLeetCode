;WITH c0 AS(
    SELECT a.category, b.[user_id]
    FROM ProductInfo AS a
    INNER JOIN ProductPurchases AS b ON b.product_id = a.product_id
), c1 AS(
    SELECT a.category AS category1, b.category AS category2, a.[user_id]
    FROM c0 AS a
    INNER JOIN c0 AS b ON b.[user_id] = a.[user_id] AND b.category > a.category
)
SELECT category1, category2, COUNT(DISTINCT [user_id]) AS customer_count
FROM c1
GROUP BY category1, category2
HAVING COUNT(DISTINCT [user_id]) >= 3
ORDER BY customer_count DESC, category1, category2
