SELECT a.product_name, SUM(b.unit) AS unit
FROM Products AS a
INNER JOIN Orders AS b ON b.product_id = a.product_id
WHERE YEAR(b.order_date) = 2020 AND MONTH(b.order_date) = 2
GROUP BY a.product_name
HAVING SUM(b.unit) >= 100
