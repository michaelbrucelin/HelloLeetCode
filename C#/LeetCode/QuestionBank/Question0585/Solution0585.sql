SELECT CONVERT(DECIMAL(18,2), SUM(o.tiv_2016)) AS TIV_2016
FROM Insurance AS o
WHERE         EXISTS (SELECT * FROM Insurance AS i WHERE i.pid <> o.pid AND i.tiv_2015 = o.tiv_2015)
      AND NOT EXISTS (SELECT * FROM Insurance AS i WHERE i.pid <> o.pid AND i.lat = o.lat AND i.lon = o.lon)
