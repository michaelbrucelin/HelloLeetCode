DECLARE @DAY_START AS DATETIME
SELECT @DAY_START = DATEADD(DD,6,MIN(visited_on)) FROM Customer
;WITH c0 AS(
SELECT DISTINCT visited_on FROM Customer WHERE visited_on >= @DAY_START
)
SELECT a.visited_on, SUM(b.amount) AS amount, CONVERT(DECIMAL(18,2), 1.0*SUM(b.amount)/7) AS average_amount
FROM c0 AS a INNER JOIN Customer AS b ON b.visited_on <= a.visited_on AND DATEADD(DD,7,b.visited_on) > a.visited_on
GROUP BY a.visited_on
ORDER BY visited_on

-- OR

-- 这个解是错误的，题目并没有保证没有都会有客人
;WITH c0 AS(
SELECT visited_on, SUM(amount) AS amount FROM #Customer GROUP BY visited_on
), c1 AS(
SELECT visited_on, SUM(amount) OVER(ORDER BY visited_on ROWS BETWEEN 6 PRECEDING AND CURRENT ROW) AS amount FROM c0
)
SELECT visited_on, amount, CONVERT(DECIMAL(18,2),1.0*amount/7) AS average_amount
FROM c1
ORDER BY visited_on
OFFSET 6 ROWS
