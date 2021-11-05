SELECT P.NAME AS PlanetName, COUNT(P.ID) AS JourneysCount FROM Spaceports AS SS
INNER JOIN Planets AS P ON P.Id = SS.PlanetId
INNER JOIN Journeys AS J ON J.DestinationSpaceportId = SS.Id
GROUP BY P.NAME, P.Id
ORDER BY COUNT(P.ID) DESC, P.NAME ASC