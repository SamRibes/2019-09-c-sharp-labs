--use master
--go

--create database Gym
--go

--use Gym
--go

--create table Members(
--MemberID int not null identity primary key,
--MemberFirstName nvarchar(50) null,
--MemberSurname nvarchar(50) null,
--DateJoined Date null,
--IsOnDirectDebit Bit null,
--MembershipID int null Foreign key references Memberships(MembershipID)
--)
--go

--create table Memberships(
--MembershipID int not null identity primary key,
--MembershipType nvarchar(30)
--)
--go

--insert into Memberships values ('Gold');
--insert into Memberships values ('Silver');
--go

--insert into Members values ('John', 'Doe', getdate(), 1, 2);
--insert into Members values ('Jane', 'Doe', getdate(), 1, 1);
--insert into Members values ('Mary', 'Sue', '2019-06-15', 0, 1);
--insert into Members values ('Gary', 'Stue', '2019-06-15', 0, 2);
--insert into Members values ('Chad', 'Buff', '2019-03-15', 1, 1);
--insert into Members values ('Stacy', 'Lady', '2018-09-22', 0, 2)


select * from Members;
select * from Memberships;

select MemberFirstName, DateJoined, MembershipType, dateadd(DAY,90,DateJoined) as 'MembershipExpiryDate' from members
inner join Memberships on Members.MembershipID = Memberships.MembershipID;