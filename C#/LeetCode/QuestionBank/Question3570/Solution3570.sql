SELECT a.book_id, MIN(b.title) AS title, MIN(b.author) AS author, MIN(b.genre) AS genre, MIN(b.publication_year) AS publication_year, COUNT(*) AS current_borrowers
FROM borrowing_records AS a
INNER JOIN library_books AS b On b.book_id = a.book_id
WHERE a.return_date IS NULL
GROUP BY a.book_id
HAVING COUNT(*) = MIN(b.total_copies)
ORDER BY current_borrowers DESC, title

-- OR

;WITH c0 AS(
	SELECT book_id, COUNT(*) AS cnt FROM borrowing_records WHERE return_date IS NULL GROUP BY book_id
)
SELECT a.book_id, a.title, a.author, a.genre, a.publication_year, b.cnt AS current_borrowers
FROM library_books AS a
INNER JOIN c0 AS b ON b.book_id = a.book_id and b.cnt = a.total_copies
ORDER BY current_borrowers DESC, title
