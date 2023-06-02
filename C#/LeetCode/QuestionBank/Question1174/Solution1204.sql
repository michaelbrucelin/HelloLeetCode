;WITH c0 AS(
SELECT customer_id, MIN(order_date) AS order_date, MIN(customer_pref_delivery_date) AS customer_pref_delivery_date FROM Delivery GROUP BY customer_id
)
SELECT CONVERT(DECIMAL(18,2), 100.0*(SELECT COUNT(*) FROM c0 WHERE order_date = customer_pref_delivery_date)/(SELECT COUNT(*) FROM c0)) AS immediate_percentage

-- OR

;WITH c0 AS(
SELECT customer_id, MIN(order_date) AS order_date FROM Delivery GROUP BY customer_id
), c1 AS(
SELECT a.* FROM Delivery AS a INNER JOIN c0 ON a.customer_id = c0.customer_id AND a.order_date = c0.order_date
)
SELECT CONVERT(DECIMAL(18,2), 100.0*(SELECT COUNT(*) FROM c1 WHERE order_date = customer_pref_delivery_date)/(SELECT COUNT(*) FROM c1)) AS immediate_percentage
