SELECT a.[user_id] AS buyer_id, a.join_date
       , SUM(CASE WHEN YEAR(b.order_date) = 2019 THEN 1 ELSE 0 END) AS orders_in_2019
FROM Users AS a
LEFT JOIN Orders AS b ON b.buyer_id = a.[user_id]
GROUP BY a.[user_id], a.join_date
