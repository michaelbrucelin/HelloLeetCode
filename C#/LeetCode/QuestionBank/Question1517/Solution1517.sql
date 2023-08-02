SELECT [user_id], [name], [mail]
FROM Users
WHERE     [mail] LIKE '[a-zA-Z]%' AND [mail] LIKE '%@leetcode.com'
      AND LEN([mail]) - LEN(REPLACE([mail],'@','')) = 1
      AND SUBSTRING([mail],1,CHARINDEX('@',[mail])-1) NOT LIKE '%[^a-zA-Z0-9_.-]%'
