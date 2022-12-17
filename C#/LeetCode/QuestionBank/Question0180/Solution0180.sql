;WITH c0 AS(
SELECT id, num,
       ROW_NUMBER() OVER(ORDER BY id)*
       (CASE WHEN num <> LAG(num, 1, '') OVER(ORDER BY id) THEN 1 ELSE 0 END) AS color_id
FROM Logs
), c1 AS(
SELECT id, num, color_id, SUM(color_id) OVER(ORDER BY id) AS color_gid
FROM c0
)
SELECT DISTINCT num AS ConsecutiveNums
FROM c1
GROUP BY num, color_gid
HAVING COUNT(id) >= 3

-- OR
SELECT DISTINCT l1.Num AS ConsecutiveNums
FROM Logs AS l1
INNER JOIN Logs AS l2 ON l2.Id - 1 = l1.Id
INNER JOIN Logs AS l3 ON l3.Id - 1 = l2.Id
WHERE l1.Num = l2.Num AND l2.Num = l3.Num
