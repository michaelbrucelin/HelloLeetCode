;WITH c0 AS(
    SELECT *, ROW_NUMBER() OVER(PARTITION BY [user_id] ORDER BY event_date DESC) AS rid
    FROM subscription_events
), c1 AS(
    SELECT [user_id]
           , MAX(CASE WHEN rid = 1 AND event_type = 'cancel' THEN 1 ELSE 0 END) AS is_cancel
		   , MAX(CASE WHEN rid = 1 THEN plan_name ELSE '' END) AS current_plan
    	   , MAX(CASE WHEN event_type = 'downgrade' THEN 1 ELSE 0 END) AS is_downgrade
    	   , MAX(CASE WHEN rid = 1 THEN monthly_amount ELSE 0 END) AS current_monthly_amount
		   , MAX(monthly_amount) AS max_historical_amount
    	   , DATEDIFF(DD, MIN(event_date), MAX(event_date)) AS days_as_subscriber
    FROM c0
    GROUP BY [user_id]
)
SELECT [user_id], current_plan, current_monthly_amount, max_historical_amount, days_as_subscriber
FROM c1
WHERE is_cancel = 0 AND is_downgrade = 1 AND current_monthly_amount*2 < max_historical_amount AND days_as_subscriber >= 60
ORDER BY days_as_subscriber DESC, [user_id]
