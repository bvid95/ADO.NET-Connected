USE TSQL2012
GO

CREATE PROC dbo.CustomersInsert 
@name nvarchar(40), @contact nvarchar(30),
@city nvarchar(15), @country nvarchar(15)
AS
SET LOCK_TIMEOUT 3000;
SET NOCOUNT ON;
BEGIN TRY
	
	INSERT INTO dbo.Klijenti 
	(Naziv, Kontakt, Grad, Zemlja)
	VALUES
	(@name, @contact, @city, @country)
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN @@ERROR
END CATCH
GO

CREATE PROC dbo.CustomersUpdate 
@id int, @name nvarchar(40), @contact nvarchar(30),
@city nvarchar(15), @country nvarchar(15)
AS
SET LOCK_TIMEOUT 3000;
SET NOCOUNT ON;
BEGIN TRY
	
	UPDATE dbo.Klijenti 
	SET Naziv=@name , Kontakt=@contact , Grad=@city , Zemlja=@country
	WHERE KlijentId=@id
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN @@ERROR
END CATCH
GO

CREATE PROC dbo.CustomersDelete 
@id int
AS
SET LOCK_TIMEOUT 3000;
SET NOCOUNT ON;
BEGIN TRY
	
	DELETE FROM dbo.Klijenti 
	WHERE KlijentId=@id
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN @@ERROR
END CATCH
GO

CREATE PROC dbo.CustomersSelect
AS
SET LOCK_TIMEOUT 3000;
SET NOCOUNT ON;
BEGIN TRY
	
	SELECT * FROM dbo.Klijenti
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN @@ERROR
END CATCH
GO