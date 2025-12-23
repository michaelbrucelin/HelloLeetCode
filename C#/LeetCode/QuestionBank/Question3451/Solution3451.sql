;WITH c0 AS(
    SELECT [ip] FROM logs WHERE LEN(ip) - LEN(REPLACE(IP,'.','')) <> 3
    UNION ALL
    SELECT a.[ip]
    FROM (SELECT [ip] FROM logs WHERE LEN(ip) - LEN(REPLACE(IP,'.','')) = 3) AS a
    CROSS APPLY(SELECT * FROM STRING_SPLIT(a.ip, '.')) AS b
    WHERE (b.[value] <> '0' AND LEFT(b.[value],1) = '0') OR b.[value] < 0 OR b.[value] > 255
)
SELECT [ip], COUNT(*) AS invalid_count FROM c0 GROUP BY [ip] ORDER BY invalid_count DESC, [ip] DESC
