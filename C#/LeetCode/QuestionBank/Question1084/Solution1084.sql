SELECT DISTINCT a.product_id, a.product_name
FROM Product AS a INNER JOIN Sales AS b ON b.product_id  = a.product_id
WHERE DATEDIFF(DD, '2019-01-01', b.sale_date) >= 0 AND DATEDIFF(DD, '2019-03-31', b.sale_date) <= 0
EXCEPT
SELECT a.product_id, a.product_name
FROM Product AS a INNER JOIN Sales AS b ON b.product_id  = a.product_id
WHERE DATEDIFF(DD, '2019-01-01', b.sale_date) <  0 OR  DATEDIFF(DD, '2019-03-31', b.sale_date) >  0

-- OR

SELECT product_id, product_name FROM Product WHERE product_id IN(
    SELECT DISTINCT product_id FROM Sales WHERE DATEDIFF(DD, '2019-01-01', sale_date) >= 0 AND DATEDIFF(DD, '2019-03-31', sale_date) <= 0
    EXCEPT
    SELECT          product_id FROM Sales WHERE DATEDIFF(DD, '2019-01-01', sale_date) <  0 OR  DATEDIFF(DD, '2019-03-31', sale_date) >  0
)
