; WITH c0 AS(
    SELECT book_id, MAX(session_rating) - MIN(session_rating) AS rating_spread
           , CONVERT(DECIMAL(18,2), 1.0 * SUM(CASE WHEN session_rating >= 4 OR session_rating <= 2 THEN 1 ELSE 0 END) / COUNT(*)) AS polarization_score
    FROM reading_sessions
    GROUP BY book_id
    HAVING COUNT(*) >= 5 AND MAX(session_rating) >= 4 AND MIN(session_rating) <= 2
)
SELECT a.book_id, a.title, a.author, a.genre, a.pages, b.rating_spread, b.polarization_score
FROM books AS a
INNER JOIN c0 AS b ON b.book_id = a.book_id
WHERE b.polarization_score >= 0.6
ORDER BY b.polarization_score DESC, a.title DESC
