SELECT [user_id], COUNT(*) AS prompt_count, CONVERT(DECIMAL(18,2),1.0*SUM(tokens)/COUNT(*)) AS avg_tokens
FROM prompts
GROUP BY [user_id]
HAVING COUNT(*) >= 3 AND COUNT(DISTINCT tokens) > 1
ORDER BY avg_tokens DESC, [user_id]
