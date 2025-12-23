;WITH c0 AS(
    SELECT [user_id], email, CHARINDEX('@',email) AS p1, CHARINDEX('.',email) AS p2
    FROM Users
    WHERE LEN(email) - LEN(REPLACE(email,'@','')) = 1 AND LEN(email) - LEN(REPLACE(email,'.','')) = 1 AND RIGHT(email,4) = '.com'
), c1 AS(
    SELECT [user_id], email, LEFT(email,p1-1) AS [user], SUBSTRING(email,p1+1,p2-p1-1) AS domain
    FROM c0
)
SELECT [user_id], email
FROM c1
WHERE [user] NOT LIKE '%[^a-zA-Z0-9_]%' AND domain NOT LIKE '%[^a-zA-Z]%'
ORDER BY [user_id]
