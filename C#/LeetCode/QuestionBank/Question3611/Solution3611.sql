;WITH c0 AS(
    SELECT employee_id, SUM(duration_hours) AS meetime
    FROM meetings
    GROUP BY employee_id, DATEADD(DD, -((DATEPART(WEEKDAY, meeting_date) + 5 + @@DATEFIRST) % 7), meeting_date)
    HAVING SUM(duration_hours) >= 20
), c1 AS(
    SELECT employee_id, COUNT(*) AS meeting_heavy_weeks FROM c0 GROUP BY employee_id HAVING COUNT(*) >= 2
)
SELECT a.employee_id, b.employee_name, b.department, a.meeting_heavy_weeks
FROM c1 AS a
INNER JOIN employees AS b On b.employee_id = a.employee_id
ORDER BY a.meeting_heavy_weeks DESC, b.employee_name
