;WITH c0 AS(
SELECT player_id, event_date, ROW_NUMBER() OVER(PARTITION BY player_id ORDER BY event_date) as rid FROM Activity
)
SELECT CONVERT(DECIMAL(18,2), 1.0*COUNT(DISTINCT player_id)/(SELECT COUNT(DISTINCT player_id) FROM c0)) AS fraction
FROM c0 AS o
WHERE o.rid = 1 AND EXISTS (SELECT * FROM c0 AS i where i.player_id = o.player_id AND i.event_date = DATEADD(DD, 1, o.event_date))

-- OR

;WITH c0 AS(
SELECT player_id, event_date, ROW_NUMBER() OVER(PARTITION BY player_id ORDER BY event_date) as rid FROM Activity
)
SELECT CONVERT(DECIMAL(18,2), 1.0*COUNT(DISTINCT o.player_id)/(SELECT COUNT(DISTINCT player_id) FROM c0)) AS fraction
FROM c0 AS o INNER JOIN c0 AS i
    ON i.player_id = o.player_id AND i.event_date = DATEADD(DD, 1, o.event_date)
WHERE o.rid = 1
