DECLARE @CNT AS INT
SELECT @CNT = COUNT(*) FROM Users
SELECT contest_id, CONVERT(DECIMAL(18,2), 100.0*COUNT(DISTINCT user_id)/@CNT) AS percentage
FROM Register
GROUP BY contest_id
ORDER BY percentage desc, contest_id
