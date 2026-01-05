;WITH c0 AS(
    SELECT patient_id, MIN(test_date) AS posi_date FROM covid_tests WHERE result = 'Positive' GROUP BY patient_id
), c1 AS(
    SELECT a.patient_id, DATEDIFF(DD, a.posi_date, MIN(b.test_date)) AS recovery_time
    FROM c0 AS a
    INNER JOIN covid_tests AS b ON b.patient_id = a.patient_id
    WHERE b.test_date > a.posi_date AND b.result = 'Negative'
    GROUP BY a.patient_id, a.posi_date
)
SELECT a.patient_id, b.patient_name, b.age, a.recovery_time
FROM c1 AS a
INNER JOIN patients AS b ON b.patient_id = a.patient_id
ORDER BY recovery_time, patient_name

;WITH c0 AS(
    SELECT patient_id, MIN(test_date) AS posi_date FROM covid_tests WHERE result = 'Positive' GROUP BY patient_id
), c1 AS(
    SELECT a.patient_id, MIN(DATEDIFF(DD, a.posi_date, b.test_date)) AS recovery_time
    FROM c0 AS a
    INNER JOIN covid_tests AS b ON b.patient_id = a.patient_id
    WHERE b.test_date > a.posi_date AND b.result = 'Negative'
    GROUP BY a.patient_id
)
SELECT a.patient_id, b.patient_name, b.age, a.recovery_time
FROM c1 AS a
INNER JOIN patients AS b ON b.patient_id = a.patient_id
ORDER BY recovery_time, patient_name
