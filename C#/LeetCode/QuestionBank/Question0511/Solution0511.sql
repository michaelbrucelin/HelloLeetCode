SELECT player_id, MIN(event_date) AS first_login
FROM Activity
GROUP BY player_id

-- OR

;WITH cte AS(
SELECT player_id, event_date, ROW_NUMBER() OVER(PARTITION BY player_id ORDER BY event_date) AS rid
FROM Activity
)
SELECT player_id, event_date AS first_login FROM cte WHERE rid = 1

-- OR

SELECT DISTINCT a.player_id, (SELECT MIN(event_date) FROM Activity AS b where b.player_id = a.player_id) AS first_login
FROM Activity AS a
