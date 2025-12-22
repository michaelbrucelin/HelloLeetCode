-- 拆分 + 聚合
;WITH c0 AS(
    SELECT a.content_id, a.content_text, s1.[value], s1.ordinal
    FROM user_content AS a
    CROSS APPLY(SELECT [value], ordinal FROM STRING_SPLIT(LOWER(a.content_text), ' ', 1)) AS s1
), c1 AS(
    SELECT c0.content_id, c0.content_text, c0.[value] AS value1, c0.ordinal AS ordinal1, UPPER(LEFT(s2.[value],1))+SUBSTRING(s2.[value],2,LEN(s2.[value])) AS value2, s2.ordinal AS ordinal2
    FROM c0
    CROSS APPLY(SELECT [value], ordinal FROM STRING_SPLIT(c0.[value], '-', 1)) AS s2
), c2 AS(
    SELECT content_id, content_text, ordinal1, STRING_AGG(value2, '-') WITHIN GROUP(ORDER BY ordinal2) AS [value]
    FROM c1
    GROUP BY content_id, content_text, value1, ordinal1
)
SELECT content_id, content_text AS original_text, STRING_AGG([value], ' ') WITHIN GROUP(ORDER BY ordinal1) AS converted_text
FROM c2
GROUP BY content_id, content_text
ORDER BY content_id
-- 提交语法错误，LEETCODE内部的MS SQL SERVER版本是2017，而STRING_SPLIT()支持有序，即支持第3个参数是2022版本开始的
-- [42000] [Microsoft][ODBC Driver 17 for SQL Server][SQL Server]Procedure or function STRING_SPLIT has too many arguments specified. (8144) (SQLExecDirectW)

-- SQL Server 2017兼容
;WITH c0 AS (
    SELECT a.content_id, a.content_text, Split.a.value('.', 'varchar(100)') AS [value], ROW_NUMBER() OVER (PARTITION BY a.content_id ORDER BY (SELECT NULL)) AS ordinal
    FROM user_content AS a
    CROSS APPLY (SELECT CAST('<x>' + REPLACE(LOWER(a.content_text), ' ', '</x><x>') + '</x>' AS XML) AS Data) AS t
    CROSS APPLY t.Data.nodes('/x') AS Split(a)
), c1 AS (
    SELECT c0.content_id, c0.content_text, c0.[value] AS value1, c0.ordinal AS ordinal1, UPPER(LEFT(s2.[value],1)) + SUBSTRING(s2.[value],2,LEN(s2.[value])) AS value2, s2.ordinal AS ordinal2
    FROM c0
    CROSS APPLY (SELECT Split2.a.value('.', 'varchar(100)') AS [value], ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS ordinal
                 FROM (SELECT CAST('<x>' + REPLACE(c0.[value], '-', '</x><x>') + '</x>' AS XML) AS Data) AS t2
    CROSS APPLY t2.Data.nodes('/x') AS Split2(a)
) AS s2
), c2 AS (
    SELECT content_id, content_text, ordinal1, STRING_AGG(value2, '-') WITHIN GROUP (ORDER BY ordinal2) AS [value]
    FROM c1
    GROUP BY content_id, content_text, value1, ordinal1
)
SELECT content_id, content_text AS original_text, STRING_AGG([value], ' ') WITHIN GROUP (ORDER BY ordinal1) AS converted_text
FROM c2
GROUP BY content_id, content_text
ORDER BY content_id