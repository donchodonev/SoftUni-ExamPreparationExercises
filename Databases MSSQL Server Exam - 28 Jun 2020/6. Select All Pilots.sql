SELECT C.Id AS id,
FirstName + ' ' + LastName AS full_name
FROM Colonists AS C
JOIN TravelCards AS TC ON TC.ColonistId = C.Id
WHERE TC.JobDuringJourney = 'Pilot'
ORDER BY C.Id ASC