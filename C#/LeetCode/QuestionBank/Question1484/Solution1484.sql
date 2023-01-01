;WITH c0 AS(
SELECT DISTINCT sell_date, product FROM Activities
), c1 AS(
SELECT sell_date, COUNT(*) AS num_sold
       , (SELECT ','+product FROM c0 AS i WHERE i.sell_date = o.sell_date ORDER BY product FOR XML PATH('')) AS products
FROM c0 AS o
GROUP BY sell_date
)
SELECT sell_date, num_sold, STUFF(products,1,1,'') AS products FROM c1 ORDER BY sell_date

-- OR

;WITH c0 AS(
SELECT DISTINCT sell_date, product FROM Activities
)
SELECT sell_date, COUNT(*) AS num_sold, STRING_AGG(product,',') WITHIN GROUP(ORDER BY product) AS products
FROM c0
GROUP BY sell_date
ORDER BY sell_date
