;WITH c0 AS(
    SELECT [user_id]
    FROM course_completions
    GROUP BY [user_id]
    HAVING COUNT(course_name) > 4 AND COUNT(course_name) * 4 <= SUM(ISNULL(course_rating,4))
), c1 AS(
    SELECT course_name, LEAD(course_name) OVER(PARTITION BY [user_id] ORDER BY completion_date) AS course_name_lead
    FROM course_completions
    WHERE [user_id] IN (SELECT [user_id] FROM c0)
)
SELECT course_name AS first_course, course_name_lead AS second_course, COUNT(*) AS transition_count
FROM c1
WHERE course_name_lead IS NOT NULL
GROUP BY course_name, course_name_lead
ORDER BY transition_count DESC, first_course, second_course
