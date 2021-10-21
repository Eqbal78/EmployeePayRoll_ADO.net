create database payroll_service
use payroll_service

create table employee_payroll
(
 id int identity(1,1) primary key,
 name varchar(100) not null,
 salary int not null,
 start_date date not null
);

insert into employee_payroll values
('Bill',100000.0,'2018-01-03'),
('Terisa',200000.0,'2019-11-13'),
('Charlie',300000.0,'2021-05-21')

select * from employee_payroll

select salary from employee_payroll where name = 'Bill'

select * from employee_payroll
where start_date between cast('2019-11-13' As date) and GETDATE()

ALTER TABLE employee_payroll
ADD Gender char(2)

update employee_payroll set Gender = 'M' where name = 'Bill' or name = 'Charlie';
update employee_payroll set Gender = 'F' where name = 'Terisa';

select sum(salary) from employee_payroll where Gender='M' group by Gender;
select sum(salary) from employee_payroll  group by Gender;
select sum(salary) as 'totalSalary',Gender from employee_payroll group by Gender;
select avg(salary) as 'averageSalary',Gender from employee_payroll group by Gender;
select min(salary) as 'minimumSalary',Gender from employee_payroll group by Gender;
select max(salary) as 'maximumSalary',Gender from employee_payroll group by Gender;
select count(Gender) as 'male' from employee_payroll where Gender='M' 
select count(Gender) as 'female' from employee_payroll where Gender='F'

alter table employee_payroll add 
phone varchar(13),
department varchar(100) not null default 'B.E',
address varchar(250) not null default 'Banglore'
select * from employee_payroll

sp_rename 'employee_payroll.salary' , 'basic_pay'

alter table employee_payroll add
deduction float ,
taxable_pay float,
incomeTax float,
net_pay float;

insert into employee_payroll values
('Terisa',700000.0,'2020-08-14','F','8734586245','sales','india',100.0,12000.0,2000.0,1233.0)

update employee_payroll set taxable_pay=12000.00, department='marketing',incomeTax=2000.00, net_pay=1233 where id=2;
select * from employee_payroll where name='Terisa'

create table Employee
(
emp_id int identity primary key,
name varchar(50),
startdate date,
gender char(1),
phone varchar(13),
address varchar(50),
);
select * from Employee

create table Department
(
dept_id int identity primary key,
rooms int,
emp_id int FOREIGN KEY REFERENCES employee(emp_id)
);
select * from Department

create table Payroll
(
emp_id int FOREIGN KEY REFERENCES employee(emp_id),
basicpay money,
deduction money,
taxable_pay money,
income_tax money,
net_pay money,
);

select * from Payroll

create table Company
(
emp_id int foreign key references employee(emp_id),
company_name varchar(50),
);

create table Employee_Department
(
emp_id int foreign key references employee(emp_id),
dept_id int foreign key references Department(dept_id),
);

use payroll_service
SELECT  p.basicpay, e.name FROM Payroll p inner join Employee e on p.emp_id=e.emp_id where e.name='Bill';
