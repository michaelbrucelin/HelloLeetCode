SELECT a.[name], b.bonus
FROM Employee AS a
LEFT JOIN Bonus AS b ON b.empId = a.empId
WHERE b.bonus IS NULL OR b.bonus < 1000
