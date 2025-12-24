;WITH c0 AS(
    SELECT student_id FROM study_sessions GROUP BY student_id HAVING COUNT([subject]) >= 6 AND COUNT(DISTINCT [subject]) >= 3
), c1 AS(
    SELECT student_id, DATEDIFF(DD,LAG(session_date,1,session_date) OVER(PARTITION BY student_id ORDER BY session_date),session_date) AS span
    FROM study_sessions
    WHERE student_id IN (SELECT student_id FROM c0)
), c2 AS(
    SELECT student_id FROM c1 GROUP BY student_id HAVING SUM(CASE WHEN span <= 2 THEN 0 ELSE 1 END) = 0
), c3 AS(
    SELECT student_id, [subject]
           , ROW_NUMBER() OVER (PARTITION BY student_id ORDER BY session_date) AS row_id
           , COUNT(1) OVER (PARTITION BY student_id) AS gcnt
           , FIRST_VALUE([subject]) OVER (PARTITION BY student_id ORDER BY session_date) AS first_subject
    FROM study_sessions
    WHERE student_id IN (SELECT student_id FROM c2)
), c4 AS(
    SELECT student_id, MIN(row_id)-1 AS offset
    FROM c3
    WHERE row_id > 1 AND [subject] = first_subject
    GROUP BY student_id
    HAVING MIN(gcnt) % (MIN(row_id)-1) = 0
), c5 AS(
    SELECT a.student_id, a.[subject], b.offset, LAG(a.[subject],b.offset) OVER (PARTITION BY a.student_id ORDER BY a.session_date) AS lag_subject
    FROM study_sessions AS a
    INNER JOIN c4 AS b on b.student_id = a.student_id
    WHERE a.student_id IN (SELECT student_id FROM c2)
), c6 AS(
    SELECT student_id, MIN(offset) as cycle_length
    FROM c5
    GROUP BY student_id
    HAVING SUM(CASE WHEN lag_subject IS NULL OR lag_subject = [subject] THEN 0 ELSE 1 END) = 0
), c7 AS(
    SELECT a.student_id, MIN(b.cycle_length) AS cycle_length, SUM(a.hours_studied) AS total_study_hours
    FROM study_sessions AS a
    INNER JOIN c6 AS b ON b.student_id = a.student_id
    GROUP BY a.student_id
)
SELECT a.student_id, b.student_name, b.major, a.cycle_length, a.total_study_hours
FROM c7 AS a
INNER JOIN students AS b ON b.student_id = a.student_id
ORDER BY cycle_length DESC, total_study_hours DESC
