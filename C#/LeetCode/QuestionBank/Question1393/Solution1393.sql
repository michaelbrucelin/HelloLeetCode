SELECT stock_name, SUM(CASE WHEN operation = 'Buy' THEN -1*price ELSE price END) AS capital_gain_loss
FROM Stocks
GROUP BY stock_name
