SELECT machine_id, CONVERT(DECIMAL(18,3), SUM(CASE WHEN activity_type = 'start' THEN -timestamp ELSE timestamp END)/
                                          SUM(CASE WHEN activity_type = 'start' THEN 1 ELSE 0 END)) AS processing_time
FROM Activity
GROUP BY machine_id
