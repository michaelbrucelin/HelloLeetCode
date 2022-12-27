;WITH c0 AS(
SELECT id, student
       , LAG( student, 1, NULL) OVER(ORDER BY id) AS lag1
       , LEAD(student, 1, NULL) OVER(ORDER BY id) AS lead1
FROM Seat
)
SELECT id, CASE WHEN id%2=1 THEN ISNULL(lead1, student) ELSE lag1 END AS student
FROM c0 ORDER BY id

-- OR

SELECT ROW_NUMBER() OVER(ORDER BY (id+1)^1-1) AS id, student FROM seat;
