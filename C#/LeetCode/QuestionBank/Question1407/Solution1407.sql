SELECT a.[name], SUM(ISNULL(b.distance,0)) AS travelled_distance
FROM Users AS a LEFT JOIN Rides AS b ON b.[user_id] = a.id
GROUP BY a.id, a.[name]
ORDER BY travelled_distance DESC, [name] ASC
