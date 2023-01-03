﻿// <auto-generated />
using System;
using CMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMS.Migrations
{
    [DbContext(typeof(cms_06GContext))]
    [Migration("20221228171848_mg5")]
    partial class mg5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CMS.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CMS.Models.TblActivities", b =>
                {
                    b.Property<int>("ActId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("act_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AssignId")
                        .HasColumnName("assign_id")
                        .HasColumnType("int");

                    b.Property<int?>("StudId")
                        .HasColumnName("stud_id")
                        .HasColumnType("int");

                    b.Property<int?>("TimetableId")
                        .HasColumnName("timetable_id")
                        .HasColumnType("int");

                    b.HasKey("ActId")
                        .HasName("PK__tbl_acti__EBC83095877A0604");

                    b.HasIndex("AssignId");

                    b.HasIndex("StudId");

                    b.HasIndex("TimetableId");

                    b.ToTable("tbl_activities");
                });

            modelBuilder.Entity("CMS.Models.TblAssignments", b =>
                {
                    b.Property<int>("AssiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("assi_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssiDescription")
                        .HasColumnName("assi_description")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<DateTime?>("AssiEnddate")
                        .HasColumnName("assi_enddate")
                        .HasColumnType("date");

                    b.Property<string>("AssiName")
                        .HasColumnName("assi_name")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<DateTime?>("AssiStartdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("assi_startdate")
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("AssiId")
                        .HasName("PK__tbl_assi__732E81F69C2F545A");

                    b.ToTable("tbl_assignments");
                });

            modelBuilder.Entity("CMS.Models.TblCourse", b =>
                {
                    b.Property<int>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("c_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CCreatedate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("c_createdate")
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Course")
                        .HasColumnName("course")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<int?>("DepId")
                        .HasColumnName("dep_id")
                        .HasColumnType("int");

                    b.Property<string>("coImage")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("CId")
                        .HasName("PK__tbl_Cour__2135C96C9564E85E");

                    b.HasIndex("DepId");

                    b.ToTable("tbl_Course");
                });

            modelBuilder.Entity("CMS.Models.TblDepartement", b =>
                {
                    b.Property<int>("DepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("dep_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Departement")
                        .HasColumnName("departement")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("depImage")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("longDescription")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("shortDescription")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("DepId")
                        .HasName("PK__tbl_depa__BB4CBBE0FF4BAB93");

                    b.ToTable("tbl_departement");
                });

            modelBuilder.Entity("CMS.Models.TblEnrolement", b =>
                {
                    b.Property<int>("EnrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("enr_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OptionalsubjectId")
                        .HasColumnName("optionalsubject_id")
                        .HasColumnType("int");

                    b.Property<int?>("SpecializesubjectId")
                        .HasColumnName("specializesubject_id")
                        .HasColumnType("int");

                    b.Property<int?>("StuId")
                        .HasColumnName("stu_id")
                        .HasColumnType("int");

                    b.HasKey("EnrId")
                        .HasName("PK__tbl_enro__6DB87936DCC82119");

                    b.HasIndex("OptionalsubjectId");

                    b.HasIndex("SpecializesubjectId");

                    b.HasIndex("StuId");

                    b.ToTable("tbl_enrolement");
                });

            modelBuilder.Entity("CMS.Models.TblFacilities", b =>
                {
                    b.Property<int>("FId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("f_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepId")
                        .HasColumnName("dep_id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Facility")
                        .HasColumnName("facility")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("ImageFacility")
                        .HasColumnName("image_facility")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("FId")
                        .HasName("PK__tbl_faci__2911CBEDF1A181E2");

                    b.HasIndex("DepId");

                    b.ToTable("tbl_facilities");
                });

            modelBuilder.Entity("CMS.Models.TblFacilityImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("faci_img_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FId")
                        .HasColumnName("facility_id")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnName("faci_Images")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FId");

                    b.ToTable("tbl_facilityImages");
                });

            modelBuilder.Entity("CMS.Models.TblFaculties", b =>
                {
                    b.Property<int>("FId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("f_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AgebyDob")
                        .HasColumnName("ageby_dob")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateofBirth")
                        .HasColumnName("dateofBirth")
                        .HasColumnType("date");

                    b.Property<int?>("DepId")
                        .HasColumnName("dep_id")
                        .HasColumnType("int");

                    b.Property<string>("FacImage")
                        .HasColumnName("fac_image")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.HasKey("FId")
                        .HasName("PK__tbl_facu__2911CBED767041A9");

                    b.HasIndex("DepId");

                    b.ToTable("tbl_faculties");
                });

            modelBuilder.Entity("CMS.Models.TblOptionalsubjects", b =>
                {
                    b.Property<int>("OsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("os_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OptinalSubject")
                        .HasColumnName("optinalSubject")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<int?>("YId")
                        .HasColumnName("y_id")
                        .HasColumnType("int");

                    b.HasKey("OsId")
                        .HasName("PK__tbl_opti__374FA4B5B21EB858");

                    b.HasIndex("YId");

                    b.ToTable("tbl_optionalsubjects");
                });

            modelBuilder.Entity("CMS.Models.TblPreviouseExameDetails", b =>
                {
                    b.Property<int>("PreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("pre_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Center")
                        .HasColumnName("center")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ClassObtained")
                        .HasColumnName("class_obtained")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("EnrolmentNo")
                        .HasColumnName("enrolmentNo")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<string>("Field")
                        .HasColumnName("field")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("MarksSecured")
                        .HasColumnName("marks_secured")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("OutOfMarks")
                        .HasColumnName("out_of_marks")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("Stream")
                        .HasColumnName("stream")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("University")
                        .HasColumnName("university")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("PreId")
                        .HasName("PK__tbl_prev__E0CFC265DCA6DE81");

                    b.ToTable("tbl_previouseExameDetails");
                });

            modelBuilder.Entity("CMS.Models.TblSpecializesubject", b =>
                {
                    b.Property<int>("SsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ss_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SsName")
                        .HasColumnName("ss_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SsId")
                        .HasName("PK__tbl_spec__A444DACA3F8E0BC4");

                    b.ToTable("tbl_specializesubject");
                });

            modelBuilder.Entity("CMS.Models.TblStatus", b =>
                {
                    b.Property<int>("StaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sta_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("status")
                        .HasColumnType("varchar(25)")
                        .HasDefaultValueSql("('Pending')")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.HasKey("StaId")
                        .HasName("PK__tbl_stat__A0970018DB1145FC");

                    b.ToTable("tbl_status");
                });

            modelBuilder.Entity("CMS.Models.TblStudent", b =>
                {
                    b.Property<int>("StuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("stu_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId")
                        .HasColumnName("course_id")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnName("status_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StuDateofBirth")
                        .HasColumnName("stu_dateofBirth")
                        .HasColumnType("date");

                    b.Property<string>("StuFathername")
                        .HasColumnName("stu_fathername")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("StuImage")
                        .HasColumnName("stu_image")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<string>("StuMothername")
                        .HasColumnName("stu_mothername")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("StuName")
                        .HasColumnName("stu_name")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("StuParementaddress")
                        .HasColumnName("stu_parementaddress")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("StuPreviousExemeId")
                        .HasColumnName("stu_previousExeme_Id")
                        .HasColumnType("int");

                    b.Property<string>("StuResidentialaddress")
                        .HasColumnName("stu_residentialaddress")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("StuId")
                        .HasName("PK__tbl_stud__E53BAF1990DF80F1");

                    b.HasIndex("CourseId");

                    b.HasIndex("StatusId");

                    b.HasIndex("StuPreviousExemeId");

                    b.ToTable("tbl_student");
                });

            modelBuilder.Entity("CMS.Models.TblStudentTeacher", b =>
                {
                    b.Property<int>("STId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("s_t_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FaculityId")
                        .HasColumnName("faculity_id")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnName("student_id")
                        .HasColumnType("int");

                    b.HasKey("STId")
                        .HasName("PK__tbl_stud__44FB5F56C47613BB");

                    b.HasIndex("FaculityId");

                    b.HasIndex("StudentId");

                    b.ToTable("tbl_student_teacher");
                });

            modelBuilder.Entity("CMS.Models.TblSubjects", b =>
                {
                    b.Property<int>("SubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sub_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Course_id")
                        .HasColumnName("c_id")
                        .HasColumnType("int");

                    b.Property<int?>("SS_id")
                        .HasColumnName("ss_id")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnName("subject")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<int?>("YId")
                        .HasColumnName("y_id")
                        .HasColumnType("int");

                    b.HasKey("SubId")
                        .HasName("PK__tbl_subj__694106B0EC031F2C");

                    b.HasIndex("Course_id");

                    b.HasIndex("SS_id");

                    b.HasIndex("YId");

                    b.ToTable("tbl_subjects");
                });

            modelBuilder.Entity("CMS.Models.TblTimetable", b =>
                {
                    b.Property<int>("TtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tt_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TtName")
                        .HasColumnName("tt_name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("TtId")
                        .HasName("PK__tbl_time__1B53DCFEDC058EF2");

                    b.ToTable("tbl_timetable");
                });

            modelBuilder.Entity("CMS.Models.TblYear", b =>
                {
                    b.Property<int>("YId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("y_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Year")
                        .HasColumnName("year")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.HasKey("YId")
                        .HasName("PK__tbl_year__801BC5755717B225");

                    b.ToTable("tbl_year");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CMS.Models.TblActivities", b =>
                {
                    b.HasOne("CMS.Models.TblAssignments", "Assign")
                        .WithMany("TblActivities")
                        .HasForeignKey("AssignId")
                        .HasConstraintName("FK__tbl_activ__assig__6A30C649");

                    b.HasOne("CMS.Models.TblStudent", "Stud")
                        .WithMany("TblActivities")
                        .HasForeignKey("StudId")
                        .HasConstraintName("FK__tbl_activ__stud___693CA210");

                    b.HasOne("CMS.Models.TblTimetable", "Timetable")
                        .WithMany("TblActivities")
                        .HasForeignKey("TimetableId")
                        .HasConstraintName("FK__tbl_activ__timet__6B24EA82");
                });

            modelBuilder.Entity("CMS.Models.TblCourse", b =>
                {
                    b.HasOne("CMS.Models.TblDepartement", "Dep")
                        .WithMany("TblCourse")
                        .HasForeignKey("DepId")
                        .HasConstraintName("FK__tbl_Cours__dep_i__3C69FB99");
                });

            modelBuilder.Entity("CMS.Models.TblEnrolement", b =>
                {
                    b.HasOne("CMS.Models.TblOptionalsubjects", "Optionalsubject")
                        .WithMany("TblEnrolement")
                        .HasForeignKey("OptionalsubjectId")
                        .HasConstraintName("FK__tbl_enrol__optio__619B8048");

                    b.HasOne("CMS.Models.TblSpecializesubject", "Specializesubject")
                        .WithMany("TblEnrolement")
                        .HasForeignKey("SpecializesubjectId")
                        .HasConstraintName("FK__tbl_enrol__speci__60A75C0F");

                    b.HasOne("CMS.Models.TblStudent", "Stu")
                        .WithMany("TblEnrolement")
                        .HasForeignKey("StuId")
                        .HasConstraintName("FK__tbl_enrol__stu_i__5FB337D6");
                });

            modelBuilder.Entity("CMS.Models.TblFacilities", b =>
                {
                    b.HasOne("CMS.Models.TblDepartement", "Dep")
                        .WithMany("TblFacilities")
                        .HasForeignKey("DepId")
                        .HasConstraintName("FK__tbl_facil__dep_i__38996AB5");
                });

            modelBuilder.Entity("CMS.Models.TblFacilityImages", b =>
                {
                    b.HasOne("CMS.Models.TblFacilities", "TblFacility")
                        .WithMany("TblFacilityImg")
                        .HasForeignKey("FId");
                });

            modelBuilder.Entity("CMS.Models.TblFaculties", b =>
                {
                    b.HasOne("CMS.Models.TblDepartement", "Dep")
                        .WithMany("TblFaculties")
                        .HasForeignKey("DepId")
                        .HasConstraintName("FK__tbl_facul__dep_i__4E88ABD4");
                });

            modelBuilder.Entity("CMS.Models.TblOptionalsubjects", b =>
                {
                    b.HasOne("CMS.Models.TblYear", "Y")
                        .WithMany("TblOSSubjects")
                        .HasForeignKey("YId");
                });

            modelBuilder.Entity("CMS.Models.TblStudent", b =>
                {
                    b.HasOne("CMS.Models.TblCourse", "Course")
                        .WithMany("TblStudent")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK__tbl_stude__cours__440B1D61");

                    b.HasOne("CMS.Models.TblStatus", "Status")
                        .WithMany("TblStudent")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("FK__tbl_stude__statu__45F365D3");

                    b.HasOne("CMS.Models.TblPreviouseExameDetails", "StuPreviousExeme")
                        .WithMany("TblStudent")
                        .HasForeignKey("StuPreviousExemeId")
                        .HasConstraintName("FK__tbl_stude__stu_p__44FF419A");
                });

            modelBuilder.Entity("CMS.Models.TblStudentTeacher", b =>
                {
                    b.HasOne("CMS.Models.TblFaculties", "Faculity")
                        .WithMany("TblStudentTeacher")
                        .HasForeignKey("FaculityId")
                        .HasConstraintName("FK__tbl_stude__facul__52593CB8");

                    b.HasOne("CMS.Models.TblStudent", "Student")
                        .WithMany("TblStudentTeacher")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK__tbl_stude__stude__5165187F");
                });

            modelBuilder.Entity("CMS.Models.TblSubjects", b =>
                {
                    b.HasOne("CMS.Models.TblCourse", "Course")
                        .WithMany("tblSubjects")
                        .HasForeignKey("Course_id");

                    b.HasOne("CMS.Models.TblSpecializesubject", "SsCourse")
                        .WithMany("tblSubjects")
                        .HasForeignKey("SS_id");

                    b.HasOne("CMS.Models.TblYear", "Y")
                        .WithMany("TblSubjects")
                        .HasForeignKey("YId")
                        .HasConstraintName("FK__tbl_subjec__y_id__59063A47");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CMS.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CMS.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CMS.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CMS.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}