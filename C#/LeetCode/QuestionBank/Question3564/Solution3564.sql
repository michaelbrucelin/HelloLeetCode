;WITH c0 AS(
    SELECT (MONTH(a.sale_date)+9)%12/3 AS season, b.category, SUM(a.quantity) AS total_quantity, SUM(a.price*a.quantity) AS total_revenue
    FROM sales AS a
    INNER JOIN products AS b ON b.product_id = a.product_id
    GROUP BY (MONTH(a.sale_date)+9)%12/3, b.category
), c1 AS(
SELECT b.season, a.category, a.total_quantity, a.total_revenue
       , ROW_NUMBER() OVER(PARTITION BY b.season ORDER BY a.total_quantity DESC, a.total_revenue DESC) AS rid
FROM c0 AS a
INNER JOIN (values(0,'Spring'),(1,'Summer'),(2,'Fall'),(3,'Winter')) AS b(season_id,season) ON b.season_id = a.season
)
SELECT season, category, total_quantity, total_revenue FROM c1 WHERE rid = 1 ORDER BY season
