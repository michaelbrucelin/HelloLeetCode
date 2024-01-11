SELECT a.employee_id, a.name, COUNT(*) AS reports_count, CONVERT(INT,ROUND(AVG(b.age*1.0),0)) AS average_age
FROM Employees AS a
INNER JOIN Employees AS b ON b.reports_to = a.employee_id
GROUP BY a.employee_id, a.name
ORDER BY employee_id
