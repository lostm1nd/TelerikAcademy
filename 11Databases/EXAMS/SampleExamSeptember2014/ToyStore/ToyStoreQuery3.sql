SELECT t.Name, t.Price, t.Color
FROM Toys t
	INNER JOIN ToysCategories tc
		ON t.ToyId = tc.ToyId
	INNER JOIN Categories c
		ON tc.CategoryId = c.CategoryId
WHERE c.Name = 'boys'