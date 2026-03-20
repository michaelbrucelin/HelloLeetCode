;WITH c0 AS(
SELECT store_id, product_name, quantity
       , COUNT(*) OVER(PARTITION BY store_id) AS cnt
       , ROW_NUMBER() OVER(PARTITION BY store_id ORDER BY price DESC, quantity DESC) AS rid1
	   , ROW_NUMBER() OVER(PARTITION BY store_id ORDER BY price  ASC, quantity DESC) AS rid2
FROM inventory
), c1 AS(
    SELECT store_id
           , MAX(CASE WHEN rid1 = 1 THEN product_name ELSE '' END) AS most_exp_product
    	   , MAX(CASE WHEN rid2 = 1 THEN product_name ELSE '' END) AS cheapest_product
    	   , MAX(CASE WHEN rid1 = 1 THEN quantity ELSE 0 END) AS most_exp_cnt
    	   , MAX(CASE WHEN rid2 = 1 THEN quantity ELSE 0 END) AS cheapest_cnt
    FROM c0
    WHERE cnt >= 3 AND (rid1 = 1 OR rid2 = 1)
    GROUP BY store_id
)
SELECT a.store_id, b.store_name, b.[location], a.most_exp_product, a.cheapest_product, CONVERT(DECIMAL(18,2), 1.0*a.cheapest_cnt/a.most_exp_cnt) AS imbalance_ratio
FROM c1 AS a
INNER JOIN stores AS b ON b.store_id = a.store_id
WHERE a.most_exp_cnt < a.cheapest_cnt
ORDER BY imbalance_ratio DESC, store_name
