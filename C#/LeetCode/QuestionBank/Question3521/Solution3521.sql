;WITH c0 AS(
    SELECT a.product_id AS product1_id, b.product_id AS product2_id, COUNT(a.[user_id]) AS customer_count
    FROM ProductPurchases AS a
    INNER JOIN ProductPurchases AS b ON b.[user_id] = a.[user_id]
    WHERE a.product_id < b.product_id
    GROUP BY a.product_id, b.product_id
    HAVING COUNT(a.[user_id]) >= 3
)
SELECT a.product1_id, a.product2_id, b.category AS product1_category, c.category AS product2_category, a.customer_count
FROM c0 AS a
INNER JOIN ProductInfo AS b ON b.product_id = a.product1_id
INNER JOIN ProductInfo AS c ON c.product_id = a.product2_id
ORDER BY customer_count DESC, product1_id, product2_id
