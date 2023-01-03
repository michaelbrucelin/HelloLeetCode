SELECT a.[name], SUM(b.amount) AS balance
FROM Users AS a INNER JOIN Transactions AS b ON b.account = a.account
GROUP BY a.[name]
HAVING SUM(b.amount) > 10000
