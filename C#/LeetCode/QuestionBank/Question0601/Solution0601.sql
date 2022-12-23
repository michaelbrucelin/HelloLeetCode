;WITH c0 AS(
SELECT id, visit_date, people, CASE WHEN people>=100 THEN 'True' ELSE 'False-'+CONVERT(VARCHAR(32),id) END AS Flag
FROM Stadium
), c1 AS(
SELECT id, visit_date, people, CASE WHEN Flag <> LAG(Flag,1,'Null') OVER(ORDER BY id) THEN 1 ELSE 0 END AS Flag FROM c0
), c2 AS(
SELECT id, visit_date, people, SUM(Flag) OVER(ORDER BY id) AS gid FROM c1
), c3 AS(
SELECT id, visit_date, people, COUNT(*) OVER(PARTITION BY gid) as gcnt FROM c2
)
SELECT id, visit_date, people FROM c3 WHERE gcnt >= 3

-- OR

-- 与上面的解法思路一致，不过更好的利用了id的连续性
;WITH c0 AS(
SELECT id, visit_date, people, id-ROW_NUMBER() OVER(ORDER BY id) gid
FROM Stadium  
WHERE people > 99
), c1 AS(
SELECT id, visit_date, people, COUNT(*) OVER(PARTITION BY gid) AS gid FROM c0
)
SELECT id, visit_date, people FROM c1 WHERE gid >= 3

-- OR

;WITH c0 AS(
SELECT id, visit_date, people
       , LAG(people,1,0) OVER(ORDER BY id) AS lag1
       , LAG(people,2,0) OVER(ORDER BY id) AS lag2
       , LEAD(people,1,0) OVER(ORDER BY id) AS lead1
       , LEAD(people,2,0) OVER(ORDER BY id) AS lead2
FROM Stadium
)
SELECT id, visit_date, people FROM c0
WHERE people >= 100 AND((lag1>=100 AND lag2>=100) OR (lead1>=100 AND lead2>=100) OR (lag1>=100 AND lead1>=100))

-- OR

-- 这个解法大表会死掉，这里写着玩玩
SELECT DISTINCT t1.id, t1.visit_date, t1.people
FROM Stadium AS t1 CROSS JOIN Stadium AS t2 CROSS JOIN Stadium AS t3
WHERE t1.people >= 100 AND t2.people >= 100 AND t3.people >= 100
AND(   (t1.id - t2.id = 1 AND t1.id - t3.id = 2 AND t2.id - t3.id = 1)  -- t1, t2, t3
    OR (t2.id - t1.id = 1 AND t2.id - t3.id = 2 AND t1.id - t3.id = 1)  -- t2, t1, t3
    OR (t3.id - t2.id = 1 AND t2.id - t1.id = 1 AND t3.id - t1.id = 2)  -- t3, t2, t1
)
ORDER BY t1.id
