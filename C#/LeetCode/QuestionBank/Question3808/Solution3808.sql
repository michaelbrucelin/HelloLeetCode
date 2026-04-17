;WITH c0 AS(
    SELECT [user_id], reaction, COUNT(*) AS cnt
    FROM reactions
    GROUP BY GROUPING SETS(([user_id]),([user_id], reaction))
), c1 AS(
    SELECT [user_id], reaction, cnt, ROW_NUMBER() OVER(PARTITION BY [user_id] ORDER BY cnt DESC, reaction) AS rid
    FROM c0
), c3 AS(
    SELECT [user_id]
           , MAX(CASE rid WHEN 1 THEN cnt ELSE 0 END) AS total
           , MAX(CASE rid WHEN 2 THEN cnt ELSE 0 END) AS mcnt
	       , MAX(CASE rid WHEN 2 THEN reaction ELSE '' END) AS reaction
    FROM c1
    GROUP BY [user_id]
)
SELECT [user_id], reaction AS dominant_reaction, CONVERT(DECIMAL(18,2), 1.0*mcnt/total) AS reaction_ratio
FROM c3
WHERE total >= 5 AND 1.0*mcnt/total >= 0.6
ORDER BY reaction_ratio DESC, [user_id]
