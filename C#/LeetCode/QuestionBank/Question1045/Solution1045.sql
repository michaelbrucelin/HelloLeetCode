SELECT customer_id
FROM Customer AS o
GROUP BY customer_id
HAVING COUNT(DISTINCT product_key) = (SELECT COUNT(*) FROM Product)

-- OR

;WITH c0 AS (
SELECT DISTINCT customer_id FROM Customer
), c1 AS (
SELECT * FROM c0 CROSS JOIN Product
), c2 AS (
SELECT c1.customer_id, a.product_key
FROM c1 LEFT JOIN Customer AS a ON a.customer_id = c1.customer_id AND a.product_key = c1.product_key
)
SELECT customer_id FROM c0
WHERE NOT EXISTS(SELECT * FROM c2 WHERE c2.customer_id = c0.customer_id AND c2.product_key IS NULL)
