SELECT COUNT(*) FROM TravelCards AS TC
GROUP BY JobDuringJourney
HAVING JobDuringJourney = 'Engineer'