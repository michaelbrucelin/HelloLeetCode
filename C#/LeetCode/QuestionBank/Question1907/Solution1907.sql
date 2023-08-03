SELECT 'Low Salary' AS category, (SELECT COUNT(account_id) FROM Accounts WHERE income < 20000) AS accounts_count
UNION ALL
SELECT 'Average Salary', (SELECT COUNT(account_id) FROM Accounts WHERE income >= 20000 AND income <= 50000)
UNION ALL
SELECT 'High Salary', (SELECT COUNT(account_id) FROM Accounts WHERE income > 50000)

-- OR

;WITH c0 AS(
SELECT CASE WHEN income < 20000 then 'Low Salary' WHEN income > 50000 then 'High Salary' ELSE 'Average Salary' END AS category FROM Accounts
UNION ALL SELECT 'Low Salary' UNION ALL SELECT 'High Salary' UNION ALL SELECT 'Average Salary'
)
SELECT category, COUNT(*) - 1 AS accounts_count FROM c0 GROUP BY category

-- OR

;WITH c0 AS(
SELECT CASE WHEN income < 20000 then 'Low Salary' WHEN income > 50000 then 'High Salary' ELSE 'Average Salary' END AS category, COUNT(account_id) AS accounts_count
FROM Accounts
GROUP BY CASE WHEN income < 20000 then 'Low Salary' WHEN income > 50000 then 'High Salary' ELSE 'Average Salary' END
)
SELECT t.category, ISNULL(c0.accounts_count, t.accounts_count) AS accounts_count
FROM c0 RIGHT JOIN (VALUES ('Low Salary', 0), ('High Salary', 0), ('Average Salary', 0)) AS t(category, accounts_count) ON t.category = c0.category
