CREATE PROCEDURE dbo.InsertDetails
	@FirstName varchar(20), 
    @LastName varchar(20),
	@Address varchar(100),
	@City varchar(20),
	@StateName varchar(25),
	@ZipCode int,
	@PhoneNum bigint,
	@EmailId varchar(20),
	@AddressBookName varchar(50),
	@RelationType varchar(20)
AS
BEGIN
insert into Address_Book (FirstName,LastName,address,City,StateName,ZipCode,Phonenum,EmailId,AddressBookName,RelationType) values(@FirstName,@LastName,@Address,@City,@StateName,@ZipCode,@PhoneNum,@EmailId,@AddressBookName,@RelationType)
END