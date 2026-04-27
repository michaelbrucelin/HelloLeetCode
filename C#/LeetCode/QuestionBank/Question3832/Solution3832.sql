;WITH c0 AS(
    SELECT [user_id], [action], action_date
           , ROW_NUMBER() OVER(PARTITION BY [user_id] ORDER BY action_date) AS rid
    	   , LAG([action], 1) OVER(PARTITION BY [user_id] ORDER BY action_date) AS _action
    	   , LAG(action_date, 1) OVER(PARTITION BY [user_id] ORDER BY action_date) AS _action_date
    FROM activity
), c1 AS(
    SELECT [user_id], [action], action_date
           , CASE WHEN _action_date is NULL THEN 1 ELSE DATEDIFF(DD,_action_date,action_date) END AS date_seq
    	   , CASE WHEN _action IS NULL OR _action = [action] THEN 0 ELSE 1 END AS action_seq
    FROM c0
)
SELECT [user_id], [action], COUNT(*) AS streak_length, MIN(action_date) AS [start_date], MAX(action_date) AS end_date
FROM c1
WHERE (date_seq = 1 AND action_seq = 0) OR (date_seq > 1 AND action_seq <> 0)
GROUP BY [user_id], [action]
HAVING COUNT(*) >= 5
ORDER BY streak_length DESC, [user_id]
