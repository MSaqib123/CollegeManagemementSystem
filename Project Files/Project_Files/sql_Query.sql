create database cms_06G
use cms_06G

--_______________ tbl_faculity  ______________
create table tbl_faculties(
	f_id int primary key identity,
	[name] varchar(25),
	dateofBirth date,
	ageby_dob date,
	fac_image varchar(250),
	dep_id int foreign key references tbl_departement(dep_Id)
)

create table tbl_student_teacher(
	s_t_id int primary key identity,
	student_id int foreign key references tbl_student(stu_Id),
	faculity_id int foreign key references tbl_faculties(f_id),
)




--_______________ departement ______________
create table tbl_departement
(
	dep_Id int primary key identity,
	departement varchar(25)
)

--_______________ facilities in College _______________
create table tbl_facilities
(
	f_id int primary key identity,
	facility varchar(25),
	dep_id int foreign key references  tbl_departement(dep_Id)
)

--_________________ Course ___________________
create table tbl_Course
(
	c_Id int primary key identity,
	course varchar(25),
	c_createdate date default getDate(),
	dep_id int foreign key references  tbl_departement(dep_Id)
)

--_________________ tbl_Students  / during Registration --> inserte ___________________
create table tbl_student
(
	stu_Id int primary key identity,
	stu_name varchar(30),
	stu_fathername varchar(30),
	stu_mothername varchar(30),
	stu_image varchar(250),
	stu_dateofBirth date,
	stu_parementaddress varchar(50),
	stu_residentialaddress varchar(50),

	course_id int foreign key references  tbl_Course(c_Id),
	stu_previousExeme_Id int foreign key references tbl_previouseExameDetails(pre_Id),
	status_id int foreign key references  tbl_status(sta_Id)
)

create table tbl_status(
	sta_Id int primary key identity,
	status varchar(25) default 'Pending'
)

create table tbl_previouseExameDetails(
	pre_Id int primary key identity,
	university varchar(30),
	enrolmentNo varchar(15), -- old number
	center varchar(50),
	[stream] varchar(50),
	field varchar(50),
	marks_secured varchar(10),
	out_of_marks varchar(10),
	class_obtained varchar(10)
)








--__________________________________ Proceed ____________________________
create table tbl_enrolement(
    enr_Id int primary key identity,
	stu_id int foreign key references tbl_student(stu_Id),
	specializesubject_id int foreign key references tbl_specializesubject(ss_Id),
	optionalsubject_id int foreign key references tbl_optionalsubjects(os_id),
)


create table tbl_specializesubject(
	ss_Id int primary key identity,
	ss_subject_id int foreign key references tbl_subjects(sub_id),
	ss_course_id int foreign key references tbl_student(stu_Id),
)

create table tbl_subjects(
    sub_id int primary key identity,
	[subject] varchar(25),
	y_id int foreign key references tbl_year(y_Id)
)


create table tbl_year(
	y_Id int primary key identity,
	[year] varchar(25)
)


create table tbl_optionalsubjects(
	os_id int primary key identity,
	optinalSubject varchar(25)
)



--___________________________ Task Exame _____________________________
create table tbl_activities(
	act_id int primary key identity,
	stud_id int foreign key references tbl_Student(stu_Id),
	assign_id int foreign key references tbl_assignments(assi_Id),
	timetable_id int foreign key references tbl_timetable(tt_Id),
)

create table tbl_assignments(
	assi_Id int primary key identity,
	assi_name varchar(25),
	assi_description varchar(150),
	assi_startdate date default getdate(),
	assi_enddate date
)

create table tbl_timetable(
	tt_Id int primary key identity,
	tt_name varchar(50)
)