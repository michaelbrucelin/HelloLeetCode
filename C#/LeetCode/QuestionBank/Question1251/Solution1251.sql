SELECT a.product_id,
       CASE WHEN MIN(b.product_id) IS NULL THEN 0 ELSE CONVERT(DECIMAL(18,2), 1.0*SUM(a.price*b.units)/SUM(b.units)) END AS average_price
FROM Prices AS a
LEFT JOIN UnitsSold AS b ON b.product_id = a.product_id AND
                            b.purchase_date >= a.start_date AND b.purchase_date <= a.end_date
GROUP BY a.product_id
