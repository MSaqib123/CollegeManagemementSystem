using System;
using CMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMS.Data
{
    public partial class cms_06GContext : IdentityDbContext<ApplicationUser>
    {
        public cms_06GContext()
        {

        }

        public cms_06GContext(DbContextOptions<cms_06GContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblActivities> TblActivities { get; set; }
        public virtual DbSet<TblAssignments> TblAssignments { get; set; }
        public virtual DbSet<TblCourse> TblCourse { get; set; }
        public virtual DbSet<TblDepartement> TblDepartement { get; set; }
        public virtual DbSet<TblEnrolement> TblEnrolement { get; set; }
        public virtual DbSet<TblFacilities> TblFacilities { get; set; }
        public virtual DbSet<TblFaculties> TblFaculties { get; set; }
        public virtual DbSet<TblOptionalsubjects> TblOptionalsubjects { get; set; }
        public virtual DbSet<TblPreviouseExameDetails> TblPreviouseExameDetails { get; set; }
        public virtual DbSet<TblSpecializesubject> TblSpecializesubject { get; set; }
        public virtual DbSet<TblStatus> TblStatus { get; set; }
        public virtual DbSet<TblStudent> TblStudent { get; set; }
        public virtual DbSet<TblStudentTeacher> TblStudentTeacher { get; set; }
        public virtual DbSet<TblSubjects> TblSubjects { get; set; }
        public virtual DbSet<TblTimetable> TblTimetable { get; set; }
        public virtual DbSet<TblYear> TblYear { get; set; }
        public virtual DbSet<TblFacilityImages> TblFacilityImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = SAQIB\\SAQIB;Initial catalog=cms_06G;Trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TblActivities>(entity =>
            {
                entity.HasKey(e => e.ActId)
                    .HasName("PK__tbl_acti__EBC83095877A0604");

                entity.HasOne(d => d.Assign)
                    .WithMany(p => p.TblActivities)
                    .HasForeignKey(d => d.AssignId)
                    .HasConstraintName("FK__tbl_activ__assig__6A30C649");

                entity.HasOne(d => d.Stud)
                    .WithMany(p => p.TblActivities)
                    .HasForeignKey(d => d.StudId)
                    .HasConstraintName("FK__tbl_activ__stud___693CA210");

                entity.HasOne(d => d.Timetable)
                    .WithMany(p => p.TblActivities)
                    .HasForeignKey(d => d.TimetableId)
                    .HasConstraintName("FK__tbl_activ__timet__6B24EA82");
            });

            modelBuilder.Entity<TblAssignments>(entity =>
            {
                entity.HasKey(e => e.AssiId)
                    .HasName("PK__tbl_assi__732E81F69C2F545A");

                entity.Property(e => e.AssiDescription).IsUnicode(false);

                entity.Property(e => e.AssiName).IsUnicode(false);

                entity.Property(e => e.AssiStartdate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblCourse>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__tbl_Cour__2135C96C9564E85E");

                entity.Property(e => e.CCreatedate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Course).IsUnicode(false);

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.TblCourse)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK__tbl_Cours__dep_i__3C69FB99");
            });

            modelBuilder.Entity<TblDepartement>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PK__tbl_depa__BB4CBBE0FF4BAB93");

                entity.Property(e => e.Departement).IsUnicode(false);
            });

            modelBuilder.Entity<TblEnrolement>(entity =>
            {
                entity.HasKey(e => e.EnrId)
                    .HasName("PK__tbl_enro__6DB87936DCC82119");

                entity.HasOne(d => d.Optionalsubject)
                    .WithMany(p => p.TblEnrolement)
                    .HasForeignKey(d => d.OptionalsubjectId)
                    .HasConstraintName("FK__tbl_enrol__optio__619B8048");

                entity.HasOne(d => d.Specializesubject)
                    .WithMany(p => p.TblEnrolement)
                    .HasForeignKey(d => d.SpecializesubjectId)
                    .HasConstraintName("FK__tbl_enrol__speci__60A75C0F");

                entity.HasOne(d => d.Stu)
                    .WithMany(p => p.TblEnrolement)
                    .HasForeignKey(d => d.StuId)
                    .HasConstraintName("FK__tbl_enrol__stu_i__5FB337D6");
            });

            modelBuilder.Entity<TblFacilities>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PK__tbl_faci__2911CBEDF1A181E2");

                entity.Property(e => e.Facility).IsUnicode(false);

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.TblFacilities)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK__tbl_facil__dep_i__38996AB5");
            });

            modelBuilder.Entity<TblFaculties>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PK__tbl_facu__2911CBED767041A9");

                entity.Property(e => e.FacImage).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.TblFaculties)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK__tbl_facul__dep_i__4E88ABD4");
            });

            modelBuilder.Entity<TblOptionalsubjects>(entity =>
            {
                entity.HasKey(e => e.OsId)
                    .HasName("PK__tbl_opti__374FA4B5B21EB858");

                entity.Property(e => e.OptinalSubject).IsUnicode(false);
            });

            modelBuilder.Entity<TblPreviouseExameDetails>(entity =>
            {
                entity.HasKey(e => e.PreId)
                    .HasName("PK__tbl_prev__E0CFC265DCA6DE81");

                entity.Property(e => e.Center).IsUnicode(false);

                entity.Property(e => e.ClassObtained).IsUnicode(false);

                entity.Property(e => e.EnrolmentNo).IsUnicode(false);

                entity.Property(e => e.Field).IsUnicode(false);

                entity.Property(e => e.MarksSecured).IsUnicode(false);

                entity.Property(e => e.OutOfMarks).IsUnicode(false);

                entity.Property(e => e.Stream).IsUnicode(false);

                entity.Property(e => e.University).IsUnicode(false);
            });

            modelBuilder.Entity<TblSpecializesubject>(entity =>
            {
                entity.HasKey(e => e.SsId)
                    .HasName("PK__tbl_spec__A444DACA3F8E0BC4");

            });

            modelBuilder.Entity<TblStatus>(entity =>
            {
                entity.HasKey(e => e.StaId)
                    .HasName("PK__tbl_stat__A0970018DB1145FC");

                entity.Property(e => e.Status)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Pending')");
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.HasKey(e => e.StuId)
                    .HasName("PK__tbl_stud__E53BAF1990DF80F1");

                entity.Property(e => e.StuFathername).IsUnicode(false);

                entity.Property(e => e.StuImage).IsUnicode(false);

                entity.Property(e => e.StuMothername).IsUnicode(false);

                entity.Property(e => e.StuName).IsUnicode(false);

                entity.Property(e => e.StuParementaddress).IsUnicode(false);

                entity.Property(e => e.StuResidentialaddress).IsUnicode(false);

                //__________ forign key ____________
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TblStudent)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__tbl_stude__cours__440B1D61");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.TblStudent)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__tbl_stude__statu__45F365D3");

                entity.HasOne(d => d.StuPreviousExeme)
                    .WithMany(p => p.tblStudent)
                    .HasForeignKey(d => d.StuPreviousExemeId)
                    .HasConstraintName("FK__tbl_stude__stu_p__44FF419A");
            });

            modelBuilder.Entity<TblStudentTeacher>(entity =>
            {
                entity.HasKey(e => e.STId)
                    .HasName("PK__tbl_stud__44FB5F56C47613BB");

                entity.HasOne(d => d.Faculity)
                    .WithMany(p => p.TblStudentTeacher)
                    .HasForeignKey(d => d.FaculityId)
                    .HasConstraintName("FK__tbl_stude__facul__52593CB8");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TblStudentTeacher)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__tbl_stude__stude__5165187F");
            });

            modelBuilder.Entity<TblSubjects>(entity =>
            {
                entity.HasKey(e => e.SubId)
                    .HasName("PK__tbl_subj__694106B0EC031F2C");

                entity.Property(e => e.Subject).IsUnicode(false);

                entity.HasOne(d => d.Y)
                    .WithMany(p => p.TblSubjects)
                    .HasForeignKey(d => d.YId)
                    .HasConstraintName("FK__tbl_subjec__y_id__59063A47");
            });

            modelBuilder.Entity<TblTimetable>(entity =>
            {
                entity.HasKey(e => e.TtId)
                    .HasName("PK__tbl_time__1B53DCFEDC058EF2");

                entity.Property(e => e.TtName).IsUnicode(false);
            });

            modelBuilder.Entity<TblYear>(entity =>
            {
                entity.HasKey(e => e.YId)
                    .HasName("PK__tbl_year__801BC5755717B225");

                entity.Property(e => e.Year).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
