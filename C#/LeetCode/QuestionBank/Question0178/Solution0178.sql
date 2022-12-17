SELECT score, DENSE_RANK() OVER(ORDER BY score DESC) AS [rank] FROM Scores

-- OR
SELECT o.score, (SELECT COUNT(DISTINCT score)+1 FROM Scores AS i WHERE i.score > o.score) AS [rank]
FROM Scores AS o
ORDER BY o.score DESC
