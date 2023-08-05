SELECT ISNULL(b.unique_id, NULL) AS unique_id, a.[name]
FROM Employees AS a
LEFT JOIN EmployeeUNI AS b ON b.id = a.id
