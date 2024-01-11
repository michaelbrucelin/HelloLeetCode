SELECT employee_id
FROM Employees as o
WHERE o.salary < 30000 AND o.manager_id IS NOT NULL
      AND NOT EXISTS(SELECT * FROM Employees AS i WHERE i.employee_id = o.manager_id)
ORDER BY employee_id

-- OR

SELECT a.employee_id
FROM Employees as a
LEFT JOIN Employees AS b on b.employee_id = a.manager_id
WHERE a.salary < 30000 AND a.manager_id IS NOT NULL AND b.employee_id IS NULL
ORDER BY employee_id
