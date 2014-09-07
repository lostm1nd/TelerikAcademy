SELECT m.Name, COUNT(t.ToyId) AS ToysCount
FROM Manufacturers m
	INNER JOIN Toys t
		ON t.ManufacturerId = m.ManufacturerId
	INNER JOIN AgeRanges ar
		ON t.AgeRangeId = ar.AgeRangeId
WHERE ar.MinimumAge >= 5 AND ar.MaximumAge <= 10
GROUP BY m.Name
