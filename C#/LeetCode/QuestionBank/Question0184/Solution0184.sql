;WITH c1 AS(
SELECT b.[name] AS Department, a.[name] AS Employee, a.salary AS Salary
       , RANK() OVER(PARTITION BY b.[name] ORDER BY a.salary DESC) AS rid
FROM Employee AS a
INNER JOIN Department AS b ON b.id = a.departmentId
)
SELECT Department, Employee, Salary FROM c1 WHERE rid = 1
