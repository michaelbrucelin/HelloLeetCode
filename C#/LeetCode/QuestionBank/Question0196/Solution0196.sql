DELETE FROM Person
WHERE Id NOT IN (SELECT MIN(Id) FROM Person GROUP BY Email)

-- OR

;WITH cte AS(
SELECT ROW_NUMBER() OVER(PARTITION BY Email ORDER BY Id) AS rid FROM Person
)
DELETE FROM cte WHERE rid <> 1

-- OR

DELETE a
FROM Person AS a
INNER JOIN Person AS b ON b.Email = a.Email
WHERE a.Id > b.Id
