-- 子查询 + 连接查询
;WITH c0 AS(
    SELECT student_id, [subject], MIN(exam_date) AS min_date, MAX(exam_date) AS max_date
    FROM Scores
    GROUP BY student_id, [subject]
    HAVING COUNT(exam_date) > 1
)
SELECT c0.student_id, c0.[subject], a.score AS first_score, b.score AS latest_score
FROM c0
INNER JOIN Scores AS a ON a.student_id = c0.student_id AND a.[subject] = c0.[subject] AND a.exam_date = c0.min_date
INNER JOIN Scores AS b ON b.student_id = c0.student_id AND b.[subject] = c0.[subject] AND b.exam_date = c0.max_date
WHERE a.score < b.score
ORDER BY student_id, [subject]

-- 窗口函数
;WITH c0 AS (
    SELECT student_id, [subject], score,
           FIRST_VALUE(score) OVER (PARTITION BY student_id, [subject] ORDER BY exam_date ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING) AS first_score,
           LAST_VALUE(score)  OVER (PARTITION BY student_id, [subject] ORDER BY exam_date ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING) AS latest_score
    FROM Scores
)
SELECT DISTINCT student_id, [subject], first_score, latest_score
FROM c0
WHERE first_score < latest_score
ORDER BY student_id, [subject]
