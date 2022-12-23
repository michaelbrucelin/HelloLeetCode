;WITh cte AS(
SELECT a.request_at
       , SUM(CASE WHEN b.banned = 'No' AND c.banned = 'NO' AND a.[status] <> 'completed' THEN 1 ELSE 0 END) AS cnt
       , SUM(CASE WHEN b.banned = 'No' AND c.banned = 'NO' THEN 1 ELSE 0 END) AS total
FROM Trips AS a
LEFT JOIN Users AS b ON b.[role] = 'client' AND b.users_id = a.client_id
LEFT JOIN Users AS c ON c.[role] = 'driver' AND c.users_id = a.driver_id
WHERE DATEDIFF(DD,request_at,'2013-10-01') <= 0 AND DATEDIFF(DD,request_at,'2013-10-03') >= 0
GROUP BY a.request_at
)
SELECT request_at AS [Day], CONVERT(DECIMAL(18,2), 1.0*ISNULL(cnt,0)/total) AS [Cancellation Rate]
FROM cte
WHERE total > 0

-- OR

;WITH c0 AS(
SELECT a.[status], a.request_at, b.banned AS banned1, c.banned AS banned2
FROM Trips AS a
LEFT JOIN Users AS b ON b.[role] = 'client' AND b.users_id = a.client_id
LEFT JOIN Users AS c ON c.[role] = 'driver' AND c.users_id = a.driver_id
WHERE DATEDIFF(DD,request_at,'2013-10-01') <= 0 AND DATEDIFF(DD,request_at,'2013-10-03') >= 0
), c1 AS(
SELECT request_at, COUNT(*) AS total FROM c0 WHERE banned1 = 'No' AND banned2 = 'NO' GROUP BY request_at
), c2 AS(
SELECT request_at, COUNT(*) AS cnt   FROM c0 WHERE banned1 = 'No' AND banned2 = 'NO' AND [status] <> 'completed' GROUP BY request_at
)
SELECT c1.request_at AS [Day], CONVERT(DECIMAL(18,2), 1.0*ISNULL(c2.cnt,0)/c1.total) AS [Cancellation Rate]
FROM c1 LEFT JOIN c2 ON c2.request_at = c1.request_at
