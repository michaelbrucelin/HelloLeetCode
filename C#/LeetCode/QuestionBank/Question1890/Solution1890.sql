SELECT [user_id], MAX(time_stamp) AS last_stamp
FROM Logins
WHERE YEAR(time_stamp) = 2020
GROUP BY [user_id]

-- OR

SELECT [user_id], MAX(time_stamp) AS last_stamp
FROM Logins
WHERE DATEDIFF(YY, '2020-01-01', time_stamp) = 0
GROUP BY [user_id]
