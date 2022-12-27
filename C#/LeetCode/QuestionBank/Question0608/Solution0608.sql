SELECT DISTINCT a.id, CASE WHEN a.p_id IS NULL THEN 'Root' WHEN b.id IS NULL THEN 'Leaf' ELSE 'Inner' END AS [Type]
FROM Tree AS a LEFT JOIN Tree AS b ON b.p_id = a.id
ORDER BY id
