using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class mg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_assignments",
                columns: table => new
                {
                    assi_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assi_name = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    assi_description = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    assi_startdate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    assi_enddate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_assi__732E81F69C2F545A", x => x.assi_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_departement",
                columns: table => new
                {
                    dep_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departement = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_depa__BB4CBBE0FF4BAB93", x => x.dep_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_previouseExameDetails",
                columns: table => new
                {
                    pre_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    university = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    enrolmentNo = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    center = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    stream = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    field = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    marks_secured = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    out_of_marks = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    class_obtained = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_prev__E0CFC265DCA6DE81", x => x.pre_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_specializesubject",
                columns: table => new
                {
                    ss_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ss_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_spec__A444DACA3F8E0BC4", x => x.ss_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_status",
                columns: table => new
                {
                    sta_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(unicode: false, maxLength: 25, nullable: true, defaultValueSql: "('Pending')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_stat__A0970018DB1145FC", x => x.sta_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_timetable",
                columns: table => new
                {
                    tt_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tt_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_time__1B53DCFEDC058EF2", x => x.tt_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_year",
                columns: table => new
                {
                    y_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_year__801BC5755717B225", x => x.y_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Course",
                columns: table => new
                {
                    c_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    c_createdate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    dep_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_Cour__2135C96C9564E85E", x => x.c_Id);
                    table.ForeignKey(
                        name: "FK__tbl_Cours__dep_i__3C69FB99",
                        column: x => x.dep_id,
                        principalTable: "tbl_departement",
                        principalColumn: "dep_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_facilities",
                columns: table => new
                {
                    f_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    facility = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    dep_id = table.Column<int>(nullable: true),
                    image_facility = table.Column<string>(maxLength: 250, nullable: true),
                    description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_faci__2911CBEDF1A181E2", x => x.f_id);
                    table.ForeignKey(
                        name: "FK__tbl_facil__dep_i__38996AB5",
                        column: x => x.dep_id,
                        principalTable: "tbl_departement",
                        principalColumn: "dep_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_faculties",
                columns: table => new
                {
                    f_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    dateofBirth = table.Column<DateTime>(type: "date", nullable: true),
                    ageby_dob = table.Column<DateTime>(type: "date", nullable: true),
                    fac_image = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    dep_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_facu__2911CBED767041A9", x => x.f_id);
                    table.ForeignKey(
                        name: "FK__tbl_facul__dep_i__4E88ABD4",
                        column: x => x.dep_id,
                        principalTable: "tbl_departement",
                        principalColumn: "dep_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_optionalsubjects",
                columns: table => new
                {
                    os_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    optinalSubject = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    y_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_opti__374FA4B5B21EB858", x => x.os_id);
                    table.ForeignKey(
                        name: "FK_tbl_optionalsubjects_tbl_year_y_id",
                        column: x => x.y_id,
                        principalTable: "tbl_year",
                        principalColumn: "y_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_student",
                columns: table => new
                {
                    stu_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stu_name = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    stu_fathername = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    stu_mothername = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    stu_image = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    stu_dateofBirth = table.Column<DateTime>(type: "date", nullable: true),
                    stu_parementaddress = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    stu_residentialaddress = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    course_id = table.Column<int>(nullable: true),
                    stu_previousExeme_Id = table.Column<int>(nullable: true),
                    status_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_stud__E53BAF1990DF80F1", x => x.stu_Id);
                    table.ForeignKey(
                        name: "FK__tbl_stude__cours__440B1D61",
                        column: x => x.course_id,
                        principalTable: "tbl_Course",
                        principalColumn: "c_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_stude__statu__45F365D3",
                        column: x => x.status_id,
                        principalTable: "tbl_status",
                        principalColumn: "sta_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_stude__stu_p__44FF419A",
                        column: x => x.stu_previousExeme_Id,
                        principalTable: "tbl_previouseExameDetails",
                        principalColumn: "pre_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_subjects",
                columns: table => new
                {
                    sub_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject = table.Column<string>(unicode: false, nullable: true),
                    c_id = table.Column<int>(nullable: true),
                    y_id = table.Column<int>(nullable: true),
                    ss_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_subj__694106B0EC031F2C", x => x.sub_id);
                    table.ForeignKey(
                        name: "FK_tbl_subjects_tbl_Course_c_id",
                        column: x => x.c_id,
                        principalTable: "tbl_Course",
                        principalColumn: "c_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_subjects_tbl_specializesubject_ss_id",
                        column: x => x.ss_id,
                        principalTable: "tbl_specializesubject",
                        principalColumn: "ss_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_subjec__y_id__59063A47",
                        column: x => x.y_id,
                        principalTable: "tbl_year",
                        principalColumn: "y_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_facilityImages",
                columns: table => new
                {
                    faci_img_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    faci_Images = table.Column<string>(nullable: true),
                    facility_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_facilityImages", x => x.faci_img_id);
                    table.ForeignKey(
                        name: "FK_tbl_facilityImages_tbl_facilities_facility_id",
                        column: x => x.facility_id,
                        principalTable: "tbl_facilities",
                        principalColumn: "f_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_activities",
                columns: table => new
                {
                    act_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stud_id = table.Column<int>(nullable: true),
                    assign_id = table.Column<int>(nullable: true),
                    timetable_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_acti__EBC83095877A0604", x => x.act_id);
                    table.ForeignKey(
                        name: "FK__tbl_activ__assig__6A30C649",
                        column: x => x.assign_id,
                        principalTable: "tbl_assignments",
                        principalColumn: "assi_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_activ__stud___693CA210",
                        column: x => x.stud_id,
                        principalTable: "tbl_student",
                        principalColumn: "stu_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_activ__timet__6B24EA82",
                        column: x => x.timetable_id,
                        principalTable: "tbl_timetable",
                        principalColumn: "tt_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_enrolement",
                columns: table => new
                {
                    enr_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stu_id = table.Column<int>(nullable: true),
                    specializesubject_id = table.Column<int>(nullable: true),
                    optionalsubject_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_enro__6DB87936DCC82119", x => x.enr_Id);
                    table.ForeignKey(
                        name: "FK__tbl_enrol__optio__619B8048",
                        column: x => x.optionalsubject_id,
                        principalTable: "tbl_optionalsubjects",
                        principalColumn: "os_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_enrol__speci__60A75C0F",
                        column: x => x.specializesubject_id,
                        principalTable: "tbl_specializesubject",
                        principalColumn: "ss_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_enrol__stu_i__5FB337D6",
                        column: x => x.stu_id,
                        principalTable: "tbl_student",
                        principalColumn: "stu_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_student_teacher",
                columns: table => new
                {
                    s_t_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<int>(nullable: true),
                    faculity_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_stud__44FB5F56C47613BB", x => x.s_t_id);
                    table.ForeignKey(
                        name: "FK__tbl_stude__facul__52593CB8",
                        column: x => x.faculity_id,
                        principalTable: "tbl_faculties",
                        principalColumn: "f_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_stude__stude__5165187F",
                        column: x => x.student_id,
                        principalTable: "tbl_student",
                        principalColumn: "stu_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_activities_assign_id",
                table: "tbl_activities",
                column: "assign_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_activities_stud_id",
                table: "tbl_activities",
                column: "stud_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_activities_timetable_id",
                table: "tbl_activities",
                column: "timetable_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Course_dep_id",
                table: "tbl_Course",
                column: "dep_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_enrolement_optionalsubject_id",
                table: "tbl_enrolement",
                column: "optionalsubject_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_enrolement_specializesubject_id",
                table: "tbl_enrolement",
                column: "specializesubject_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_enrolement_stu_id",
                table: "tbl_enrolement",
                column: "stu_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_facilities_dep_id",
                table: "tbl_facilities",
                column: "dep_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_facilityImages_facility_id",
                table: "tbl_facilityImages",
                column: "facility_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_faculties_dep_id",
                table: "tbl_faculties",
                column: "dep_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_optionalsubjects_y_id",
                table: "tbl_optionalsubjects",
                column: "y_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_student_course_id",
                table: "tbl_student",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_student_status_id",
                table: "tbl_student",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_student_stu_previousExeme_Id",
                table: "tbl_student",
                column: "stu_previousExeme_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_student_teacher_faculity_id",
                table: "tbl_student_teacher",
                column: "faculity_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_student_teacher_student_id",
                table: "tbl_student_teacher",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_subjects_c_id",
                table: "tbl_subjects",
                column: "c_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_subjects_ss_id",
                table: "tbl_subjects",
                column: "ss_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_subjects_y_id",
                table: "tbl_subjects",
                column: "y_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_activities");

            migrationBuilder.DropTable(
                name: "tbl_enrolement");

            migrationBuilder.DropTable(
                name: "tbl_facilityImages");

            migrationBuilder.DropTable(
                name: "tbl_student_teacher");

            migrationBuilder.DropTable(
                name: "tbl_subjects");

            migrationBuilder.DropTable(
                name: "tbl_assignments");

            migrationBuilder.DropTable(
                name: "tbl_timetable");

            migrationBuilder.DropTable(
                name: "tbl_optionalsubjects");

            migrationBuilder.DropTable(
                name: "tbl_facilities");

            migrationBuilder.DropTable(
                name: "tbl_faculties");

            migrationBuilder.DropTable(
                name: "tbl_student");

            migrationBuilder.DropTable(
                name: "tbl_specializesubject");

            migrationBuilder.DropTable(
                name: "tbl_year");

            migrationBuilder.DropTable(
                name: "tbl_Course");

            migrationBuilder.DropTable(
                name: "tbl_status");

            migrationBuilder.DropTable(
                name: "tbl_previouseExameDetails");

            migrationBuilder.DropTable(
                name: "tbl_departement");
        }
    }
}
