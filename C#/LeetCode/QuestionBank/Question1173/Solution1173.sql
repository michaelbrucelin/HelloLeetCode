;WITH c0 AS(
SELECT CASE WHEN customer_pref_delivery_date = order_date THEN 1 ELSE 0 END AS is_im FROM Delivery
), c1 AS(
SELECT is_im, COUNT(*) AS cnt FROM c0 GROUP BY is_im
)
SELECT ISNULL(CONVERT(DECIMAL(18,2), 100.0*(SELECT TOP(1) cnt FROM c1 WHERE is_im = 1)/
                                           (SELECT SUM(cnt) FROM c1)),0) AS immediate_percentage

-- OR

SELECT CONVERT(DECIMAL(18,2), 100*AVG(CASE WHEN customer_pref_delivery_date = order_date THEN 1.0 ELSE 0.0 END)) AS immediate_percentage FROM Delivery
