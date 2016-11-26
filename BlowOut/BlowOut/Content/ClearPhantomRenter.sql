SELECT Instrument.ClientID, Client.ClientID
FROM Instrument
LEFT JOIN Client ON Instrument.ClientID = Client.ClientID
WHERE (Instrument.ClientID IS NOT NULL);

UPDATE Instrument
SET ClientID = NULL
WHERE ClientID NOT IN 
	(SELECT ClientID
	FROM Client);