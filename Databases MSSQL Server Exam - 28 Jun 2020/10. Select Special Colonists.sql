SELECT * FROM 
(SELECT TC.JobDuringJourney,
C.FirstName+ ' ' + C.LastName as FullName,
DENSE_RANK () OVER (PARTITION BY TC.JobDuringJourney ORDER BY C.BirthDate ASC) AS Rank
FROM Colonists AS C
JOIN TravelCards AS TC ON TC.ColonistId = C.Id)
as SEL
WHERE SEL.Rank = 2
