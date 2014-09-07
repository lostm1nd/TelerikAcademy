SELECT t.Name, t.Price
FROM Toys t
	INNER JOIN ToysCategories tc
		ON t.ToyId = tc.ToyId
	INNER JOIN Categories c
		ON tc.CategoryId = c.CategoryId
WHERE c.Name = 'puzzle' AND t.Price > 10
ORDER BY t.Price