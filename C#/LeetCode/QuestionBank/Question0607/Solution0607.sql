SELECT [name]
FROM SalesPerson WHERE sales_id NOT IN(
    SELECT b.sales_id
    FROM Company AS a INNER JOIN Orders AS b ON b.com_id = a.com_id
    WHERE a.[name] = 'RED'
)
