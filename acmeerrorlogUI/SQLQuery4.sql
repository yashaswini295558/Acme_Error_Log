CREATE PROCEDURE usp_InsertUser(@email_id varchar(50), @password varchar(50))
AS
BEGIN
BEGIN TRY
IF @email_id IS NOT NULL
BEGIN
	IF @password IS NOT NULL
	BEGIN

		INSERT INTO USERS([email_id],[password]) VALUES (@email_id,@password)
		RETURN 1
	END
	ELSE
		RETURN -2
	END
	ELSE
		RETURN -1
END TRY
BEGIN CATCH
	RETURN -99
END CATCH
END
