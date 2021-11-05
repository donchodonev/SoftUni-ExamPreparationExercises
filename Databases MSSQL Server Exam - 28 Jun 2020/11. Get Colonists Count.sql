CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
RETURN (SELECT COUNT(TC.ColonistId) AS Count FROM Journeys AS J
JOIN Spaceports AS SP ON SP.Id = J.DestinationSpaceportId
JOIN Planets AS P ON P.Id = SP.PlanetId
JOIN TravelCards AS TC ON TC.JourneyId = J.Id
WHERE P.NAME = @PlanetName )
END