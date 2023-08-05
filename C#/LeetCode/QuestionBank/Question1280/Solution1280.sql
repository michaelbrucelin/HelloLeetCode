SELECT a.student_id, a.student_name, b.subject_name, COUNT(c.student_id) AS attended_exams
FROM Students AS a CROSS JOIN Subjects AS b
LEFT JOIN Examinations AS c ON c.student_id = a.student_id AND c.subject_name = b.subject_name
GROUP BY a.student_id, a.student_name, b.subject_name
ORDER BY student_id, subject_name

--OR

SELECT a.student_id, a.student_name, b.subject_name
      , (SELECT COUNT(*) FROM Examinations AS i 
         WHERE i.student_id = a.student_id AND i.subject_name = b.subject_name) AS attended_exams
FROM Students AS a CROSS JOIN Subjects AS b
ORDER BY student_id, subject_name
