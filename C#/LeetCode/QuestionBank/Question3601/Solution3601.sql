;WITH c0 AS(
    SELECT driver_id, MONTH(trip_date) AS mon, distance_km/fuel_consumed AS eff FROM trips
), c1 AS(
    SELECT driver_id, SUM(CASE WHEN mon <= 6 THEN eff ELSE 0 END) AS eff1, SUM(CASE WHEN mon <= 6 THEN 1 ELSE 0 END) AS cnt1
                    , SUM(CASE WHEN mon >= 7 THEN eff ELSE 0 END) AS eff2, SUM(CASE WHEN mon >= 7 THEN 1 ELSE 0 END) AS cnt2
    FROM c0
    GROUP BY driver_id
), c2 AS(
    SELECT driver_id, CONVERT(DECIMAL(18,2), eff1/NULLIF(cnt1,0)) AS first_half_avg, CONVERT(DECIMAL(18,2), eff2/NULLIF(cnt2,0)) AS second_half_avg
	                , CONVERT(DECIMAL(18,2), eff2/NULLIF(cnt2,0) - eff1/NULLIF(cnt1,0)) AS efficiency_improvement
    FROM c1
    -- WHERE cnt1 > 0 AND cnt2 > 0
)
SELECT a.driver_id, b.driver_name, a.first_half_avg, a.second_half_avg, a.efficiency_improvement
FROM c2 AS a
INNER JOIN drivers AS b ON b.driver_id = a.driver_id
WHERE a.second_half_avg > a.first_half_avg
ORDER BY efficiency_improvement DESC, b.driver_name

-- 注意下面写法是不对的，不符合题意

;WITH c0 AS(
    SELECT driver_id, MONTH(trip_date) AS mon, distance_km/fuel_consumed AS eff FROM trips
), c1 AS(
    SELECT driver_id, SUM(CASE WHEN mon <= 6 THEN eff ELSE 0 END) AS eff1, SUM(CASE WHEN mon <= 6 THEN 1 ELSE 0 END) AS cnt1
                    , SUM(CASE WHEN mon >= 7 THEN eff ELSE 0 END) AS eff2, SUM(CASE WHEN mon >= 7 THEN 1 ELSE 0 END) AS cnt2
    FROM c0
    GROUP BY driver_id
), c2 AS(
    SELECT driver_id, CONVERT(DECIMAL(18,2), eff1/NULLIF(cnt1,0)) AS first_half_avg, CONVERT(DECIMAL(18,2), eff2/NULLIF(cnt2,0)) AS second_half_avg
    FROM c1
    WHERE cnt1 > 0 AND cnt2 > 0
)
SELECT a.driver_id, b.driver_name, a.first_half_avg, a.second_half_avg, a.second_half_avg - a.first_half_avg AS efficiency_improvement
FROM c2 AS a
INNER JOIN drivers AS b ON b.driver_id = a.driver_id
WHERE a.second_half_avg > a.first_half_avg
ORDER BY efficiency_improvement DESC, b.driver_name

-- 下面写法更是错误的，报错“消息 8134，级别 16，状态 1，第 3 行 遇到以零作除数错误。”，注意理解CTE。

;WITH c0 AS(
    SELECT driver_id, MONTH(trip_date) AS mon, distance_km/fuel_consumed AS eff FROM trips
), c1 AS(
    SELECT driver_id, SUM(CASE WHEN mon <= 6 THEN eff ELSE 0 END) AS eff1, SUM(CASE WHEN mon <= 6 THEN 1 ELSE 0 END) AS cnt1
                    , SUM(CASE WHEN mon >= 7 THEN eff ELSE 0 END) AS eff2, SUM(CASE WHEN mon >= 7 THEN 1 ELSE 0 END) AS cnt2
    FROM c0
    GROUP BY driver_id
), c2 AS(
    SELECT driver_id, CONVERT(DECIMAL(18,2), eff1/cnt1) AS first_half_avg, CONVERT(DECIMAL(18,2), eff2/cnt2) AS second_half_avg
	                , CONVERT(DECIMAL(18,2), eff2/cnt2 - eff1/cnt1) AS efficiency_improvement
    FROM c1
    WHERE cnt1 > 0 AND cnt2 > 0
)
SELECT a.driver_id, b.driver_name, a.first_half_avg, a.second_half_avg, a.efficiency_improvement
FROM c2 AS a
INNER JOIN drivers AS b ON b.driver_id = a.driver_id
WHERE a.second_half_avg > a.first_half_avg
ORDER BY efficiency_improvement DESC, b.driver_name
