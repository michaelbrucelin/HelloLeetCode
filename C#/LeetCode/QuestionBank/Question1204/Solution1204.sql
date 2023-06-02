;WITH c0 AS(
SELECT person_name, SUM([weight]) OVER(ORDER BY turn) AS weights FROM [Queue]
)
SELECT TOP (1) person_name FROM c0 WHERE weights <= 1000 ORDER BY weights DESC

-- OR

SELECT TOP (1) a.person_name
FROM [Queue] AS a
INNER JOIN [Queue] AS b ON b.turn <= a.turn
GROUP BY a.person_name
HAVING SUM(b.[weight]) <= 1000
ORDER BY SUM(b.[weight]) DESC
