SELECT a.[user_id], CONVERT(DECIMAL(18,2),1.0*SUM(a.activity_duration)/COUNT(*)) AS trial_avg_duration
                  , CONVERT(DECIMAL(18,2),1.0*SUM(b.activity_duration)/COUNT(*)) AS paid_avg_duration
FROM UserActivity AS a
INNER JOIN UserActivity AS b ON b.[user_id] = a.[user_id]
WHERE a.activity_type = 'free_trial' AND b.activity_type = 'paid'
GROUP BY a.[user_id]
