SELECT activity_date AS [day], COUNT(DISTINCT [user_id]) AS active_users
FROM Activity
WHERE DATEDIFF(DD, activity_date, '2019-07-27') >= 0 AND DATEDIFF(DD, activity_date, '2019-07-27') < 30
GROUP BY activity_date
