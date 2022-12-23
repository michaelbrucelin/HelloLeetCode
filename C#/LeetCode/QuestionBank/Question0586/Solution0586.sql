SELECT TOP (1) customer_number FROM orders GROUP BY customer_number ORDER BY COUNT(*) DESC

-- OR

;WITH c0 AS(
SELECT customer_number, COUNT(*) as cnt FROM orders GROUP BY customer_number
)
SELECT TOP (1) customer_number FROM c0 ORDER BY cnt DESC
