SELECT [name]
FROM Employee AS o
WHERE (SELECT COUNT(*) FROM Employee AS i WHERE i.managerId = o.id) >= 5

-- OR

SELECT o.[name] AS [name]
FROM Employee AS o
INNER JOIN Employee AS i ON i.managerId = o.id
GROUP BY o.[name]
HAVING COUNT(*) >= 5
