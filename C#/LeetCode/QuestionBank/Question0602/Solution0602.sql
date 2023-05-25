;WITH c0 AS (
SELECT DISTINCT id, friend FROM (
SELECT requester_id AS id, accepter_id AS friend FROM RequestAccepted
UNION ALL
SELECT accepter_id AS id, requester_id AS friend FROM RequestAccepted
) AS t), c1 AS (
SELECT id, COUNT(*) AS num FROM c0 GROUP BY id
), c2 AS(
SELECT id, num, RANK() OVER(ORDER BY num DESC) AS rid FROM c1
)
SELECT id, num FROM c2 WHERE rid = 1
