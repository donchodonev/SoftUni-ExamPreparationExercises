CREATE PROC usp_ChangeJourneyPurpose (@JourneyId INT, @NewPurpose VARCHAR(11))

AS

DECLARE @journeyIdInDb INT;
SET @journeyIdInDb = (SELECT Id FROM Journeys WHERE Id = @JourneyId)

BEGIN
IF @journeyIdInDb IS NULL
THROW 51000, 'The journey does not exist!', 1;
END

DECLARE @existingJourneyPurpose VARCHAR(11)
SET @existingJourneyPurpose = (SELECT Purpose FROM Journeys WHERE Id = 1)

BEGIN
IF(@existingJourneyPurpose = @NewPurpose)
THROW 51000, 'You cannot change the purpose!', 1;
END

UPDATE Journeys
SET Purpose = @NewPurpose
WHERE Id = @JourneyId