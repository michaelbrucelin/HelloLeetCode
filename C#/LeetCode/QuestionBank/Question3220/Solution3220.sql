SELECT transaction_date, SUM(CASE amount & 1 WHEN 1 THEN amount ELSE 0 END) AS odd_sum, 
                         SUM(CASE amount & 1 WHEN 0 THEN amount ELSE 0 END) AS even_sum
FROM transactions
GROUP BY transaction_date
ORDER BY transaction_date
