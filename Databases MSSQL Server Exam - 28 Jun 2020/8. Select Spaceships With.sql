SELECT Name, Manufacturer FROM Spaceships SS
JOIN Journeys AS J ON J.SpaceshipId = SS.Id
JOIN TravelCards AS TC ON TC.JourneyId = J.Id
JOIN Colonists AS C ON C.Id = TC.ColonistId
WHERE TC.JobDuringJourney = 'PILOT'
AND YEAR(C.BirthDate) + 30 > YEAR(GETDATE()) - 2
ORDER BY Name ASC