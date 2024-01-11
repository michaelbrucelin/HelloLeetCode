;WITH c0 AS(
SELECT a.user_id, COUNT(b.user_id) AS total, SUM(CASE WHEN b.action = 'confirmed' THEN 1 ELSE 0 END) AS confirm
FROM Signups AS a
LEFT JOIN Confirmations AS b ON b.user_id = a.user_id
GROUP BY a.user_id
)
SELECT user_id, CASE WHEN total = 0 THEN 0 ELSE CONVERT(DECIMAL(18,2), 1.0*confirm/total) END AS confirmation_rate FROM c0
