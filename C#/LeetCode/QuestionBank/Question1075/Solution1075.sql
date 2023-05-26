SELECT a.project_id, CONVERT(DECIMAL(18,2), 1.0*SUM(b.experience_years)/COUNT(*)) AS average_years
FROM Project AS a
INNER JOIN Employee AS b ON b.employee_id = a.employee_id
GROUP BY a.project_id
