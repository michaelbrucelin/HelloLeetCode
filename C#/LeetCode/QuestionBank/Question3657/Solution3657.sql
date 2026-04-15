SELECT customer_id
FROM customer_transactions
GROUP BY customer_id
HAVING     COUNT(*) >= 3 
       AND DATEDIFF(DD,MIN(transaction_date),MAX(transaction_date)) >= 30
	   AND 1.0*SUM(CASE transaction_type WHEN 'refund' THEN 1 ELSE 0 END)/COUNT(*) < 0.2
ORDER BY customer_id
