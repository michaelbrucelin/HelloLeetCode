SELECT a.id
FROM Weather AS a
INNER JOIN Weather AS b ON DATEADD(DD,1,b.recordDate) = a.recordDate
WHERE a.temperature > b.temperature

-- OR

;WITH cte AS(
SELECT *, LAG(recordDate, 1,NULL) OVER(ORDER BY recordDate) as lastDate
        , LAG(temperature,1,NULL) OVER(ORDER BY recordDate) as lastTemp
FROM Weather
)
SELECT id
FROM cte
WHERE temperature > lastTemp and recordDate = DATEADD(DD,1,lastDate)
