CREATE PROC SpGetAllMembers
AS
SELECT * FROM employee_payroll
GO;

create proc SpAddEmployeeDetails
(
	@name varchar(20),
	@Gender char(20),
	@start_date date,
	@phone varchar(20),
	@address varchar(225),
	@deduction float ,
	@taxable_pay float,
	@incomeTax float,
	@net_pay float,
	@basic_pay int,
	@department varchar(225)
	
)
as
begin
	insert into employee_payroll values
(
	@name,
	@Gender,
	@start_date,
	@phone,
	@address,
	@deduction,
	@taxable_pay,
	@incomeTax,
	@net_pay,
	@basic_pay,
	@department
	
)
end;

CREATE PROCEDURE SpUpdateSalary
	@name varchar(255),
	@basic_pay float,
	@id int
AS
BEGIN
	 Update employee_payroll set name =@name, basic_pay = @basic_pay where id = @id 
END