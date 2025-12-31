;WITH c0 AS(
    SELECT employee_id, rating
           , ROW_NUMBER() OVER(PARTITION BY employee_id ORDER BY review_date DESC) AS rid
           , LEAD(rating,1) OVER(PARTITION BY employee_id ORDER BY review_date DESC) AS next1
           , LEAD(rating,2) OVER(PARTITION BY employee_id ORDER BY review_date DESC) AS next2
           , COUNT(*) OVER(PARTITION BY employee_id) AS cnt
    FROM performance_reviews
), c1 AS(
    SELECT employee_id, rating, next1, next2 FROM c0 WHERE cnt >= 3 AND rid = 1
)
SELECT a.employee_id, b.[name], a.rating-a.next2 AS improvement_score
FROM c1 AS a
INNER JOIN employees AS b ON b.employee_id = a.employee_id
WHERE a.rating > a.next1 AND a.next1 > a.next2
ORDER BY improvement_score DESC, b.[name]
