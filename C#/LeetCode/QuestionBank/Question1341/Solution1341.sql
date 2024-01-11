SELECT results FROM(
    SELECT TOP (1) a.name AS results
    FROM Users AS a INNER JOIN MovieRating AS b ON b.user_id = a.user_id
    GROUP BY a.user_id, a.name
    ORDER BY COUNT(*) DESC, a.name
    UNION ALL
    SELECT TOP (1) a.title AS results
    FROM Movies AS a INNER JOIN MovieRating AS b ON b.movie_id = a.movie_id
    WHERE YEAR(b.created_at) = 2020 AND MONTH(b.created_at) = 2
    GROUP BY a.movie_id, a.title
    ORDER BY AVG(1.0*b.rating) DESC, a.title
) AS t
