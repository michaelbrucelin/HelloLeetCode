SELECT [session_id], MIN([user_id]) AS [user_id], DATEDIFF(MI,MIN(event_timestamp),MAX(event_timestamp)) AS session_duration_minutes
       , SUM(CASE WHEN event_type = 'scroll' THEN 1 ELSE 0 END) AS scroll_count
FROM app_events
GROUP BY [session_id]
HAVING     DATEDIFF(MI,MIN(event_timestamp),MAX(event_timestamp)) > 30
       AND SUM(CASE WHEN event_type = 'purchase' THEN 1 ELSE 0 END) = 0
       AND SUM(CASE WHEN event_type = 'scroll'   THEN 1 ELSE 0 END) > 4
       AND SUM(CASE WHEN event_type = 'click'    THEN 1 ELSE 0 END) * 5 < SUM(CASE WHEN event_type = 'scroll'   THEN 1 ELSE 0 END)
ORDER BY scroll_count DESC, [session_id]
