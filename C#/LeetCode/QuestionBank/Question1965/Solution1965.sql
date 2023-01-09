SELECT ISNULL(a.employee_id, b.employee_id) AS employee_id
FROM Employees AS a
FULL JOIN Salaries AS b ON b.employee_id = a.employee_id
WHERE a.[name] IS NULL OR b.salary IS NULL
ORDER BY employee_id
