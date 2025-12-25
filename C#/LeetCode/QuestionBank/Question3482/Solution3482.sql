;WITH c0 AS(
    SELECT employee_id, employee_name, 1 AS [level] FROM Employees WHERE manager_id IS NULL
    UNION ALL
    SELECT a.employee_id, a.employee_name, b.[level]+ 1 AS [level] FROM Employees AS a
    INNER JOIN c0 AS b ON a.manager_id = b.employee_id
), c1 AS(
    SELECT employee_id, employee_name, manager_id, 1 AS team_size, salary AS budget FROM Employees
    UNION ALL
    SELECT a.employee_id, a.employee_name, a.manager_id, b.team_size, b.budget FROM Employees AS a
    INNER JOIN c1 AS b ON b.manager_id = a.employee_id
)
SELECT a.employee_id, a.employee_name, a.[level], SUM(b.team_size)-1 AS team_size, SUM(b.budget) AS budget
FROM c0 AS a
INNER JOIN c1 AS b ON b.employee_id = a.employee_id
GROUP BY a.employee_id, a.employee_name, a.[level]
ORDER BY a.[level], budget DESC, employee_name
