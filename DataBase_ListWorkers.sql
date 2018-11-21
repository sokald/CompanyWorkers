-- create database 
--CREATE DATABASE ListWorkers

/*
--create table with Company
CREATE TABLE Company(
	IdCompany int IDENTITY(1,1) PRIMARY KEY,
	NameComapny CHAR(30) NOT NULL,
	DateCreation date NOT NULL
);
*/

/*
--create table with workers
CREATE TABLE Worker(
	IdWorker int IDENTITY(1,1) PRIMARY KEY,
	IdCompany int FOREIGN KEY REFERENCES Company(IdCompany),
	FirstName CHAR(50) NOT NULL,
	LastName CHAR(50) NOT NULL,
	DateOfBirth date NOT NULL,
	Position CHAR(50) NOT NULL CHECK (Position IN('Administrator', 'Developer', 'Architect', 'Manager'))
);
*/

/*
-- insert example data in the table Company
INSERT INTO Company ( NameComapny, DateCreation)
VALUES ('Volux', '01-01-2000'); 
*/

/*
-- insert example data in the table Company
INSERT INTO Worker (IdCompany, FirstName, LastName, DateOfBirth, Position)
VALUES ('1', 'Adam', 'Mickiewicz', '02-02-2002', 'Administrator'); 

INSERT INTO Worker (IdCompany, FirstName, LastName, DateOfBirth, Position)
VALUES ('1', 'Dorota', 'Ostrowska', '03-03-2003', 'Developer'); 
*/

--show table with company
SELECT * FROM Company;

--show table with Worker
SELECT * FROM Worker;

--SELECT * FROM Worker WHERE IdCompany = 2;

/*
-- create procedure to insert data in table Company
Create Procedure [dbo].[InsertCompany]  
(  
@NameComapny CHAR(30),  
@DateCreation date
)  
as  
begin    
INSERT INTO [dbo].[Company]  
           ([NameComapny],
           [DateCreation]  
		   )  
     VALUES  
           (  
           @NameComapny,  
           @DateCreation
          )  
End 
*/ 

/*
-- create procedure to update table
Create procedure UpdateCompany      
(      
   @IdCompany INTEGER ,    
   @NameComapny VARCHAR(50),     
   @DateCreation date    
)      
as      
begin      
   Update Company       
   set NameComapny=@NameComapny,      
   DateCreation=@DateCreation
   where IdCompany=@IdCompany      
End
*/

/*
--delete company
Create procedure DeleteCompany 
(      
   @NameComapny int      
)      
as       
begin      
   Delete from Company where NameComapny=@NameComapny      
End
*/

/*
--view all 
Create procedure GetAllCompany    
as    
Begin    
    select *    
    from Company    
End
*/