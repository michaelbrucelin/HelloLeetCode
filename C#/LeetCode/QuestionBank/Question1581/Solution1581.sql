SELECT a.customer_id, COUNT(*) AS count_no_trans
FROM Visits AS a
LEFT JOIN Transactions AS b ON b.visit_id = a.visit_id
WHERE b.visit_id IS NULL
GROUP BY a.customer_id
