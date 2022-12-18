SELECT a.[name] AS Customers 
FROM Customers AS a
LEFT JOIN Orders AS b ON b.customerId = a.id
WHERE b.customerId IS NULL
