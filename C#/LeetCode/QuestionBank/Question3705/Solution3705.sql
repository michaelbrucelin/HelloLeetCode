;WITH c0 AS(
SELECT customer_id, COUNT(*) AS total_orders
       , SUM(CASE WHEN ((order_timestamp >= DATEADD(HH,11,CONVERT(DATETIME,CONVERT(DATE,order_timestamp))) AND order_timestamp <= DATEADD(HH,14,CONVERT(DATETIME,CONVERT(DATE,order_timestamp))) OR
	                   ((order_timestamp >= DATEADD(HH,18,CONVERT(DATETIME,CONVERT(DATE,order_timestamp))) AND order_timestamp <= DATEADD(HH,21,CONVERT(DATETIME,CONVERT(DATE,order_timestamp)))))))
				  THEN 1 ELSE 0 END) AS peak_hout_count
	   , COUNT(order_rating) AS rating_count, SUM(order_rating) AS total_rating
FROM restaurant_orders
GROUP BY customer_id
), c1 AS(
SELECT customer_id, total_orders, rating_count
       , CONVERT(DECIMAL(18,0), 100.*peak_hout_count/total_orders) AS peak_hour_percentage
	   , CONVERT(DECIMAL(18,2), 1.*total_rating/rating_count) AS average_rating
FROM c0
)
SELECT customer_id, total_orders, peak_hour_percentage, average_rating
FROM c1
WHERE total_orders >= 3 AND peak_hour_percentage >= 60 AND average_rating >= 4 AND rating_count * 2 >= total_orders
ORDER BY average_rating DESC, customer_id DESC
