using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DroosAcademy.Models
{
    public partial class DroosAcademyContext : DbContext
    {
        public DroosAcademyContext()
        {
        }

        public DroosAcademyContext(DbContextOptions<DroosAcademyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Center> Centers { get; set; }
        public virtual DbSet<Code> Codes { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<ExamQuestion> ExamQuestions { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<LectureFolder> LectureFolders { get; set; }
        public virtual DbSet<LecturePart> LectureParts { get; set; }
        public virtual DbSet<QuestionMcq> QuestionMcqs { get; set; }
        public virtual DbSet<ScholageYear> ScholageYears { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentHaveLecture> StudentHaveLectures { get; set; }
        public virtual DbSet<StudentTeacherBalance> StudentTeacherBalances { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeachingYear> TeachingYears { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BPA20V3\\SQLEXPRESS;Database=mohamedragheb15_SampleDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Center>(entity =>
            {
                entity.ToTable("Center");

                entity.HasIndex(e => e.PhoneNumber, "UQ__Center__4849DA016A46AA53")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(13)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Code>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActivatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("activatedDate");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.Property(e => e.YearId).HasColumnName("yearId");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.Codes)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Codes__LectureId__0E6E26BF");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Codes)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Codes__teacherId__0F624AF8");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Codes)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Codes__yearId__10566F31");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("Exam");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LectureId).HasColumnName("lectureId");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .HasColumnName("name");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("startTime");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.YearId).HasColumnName("yearId");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Exam_Lecture");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Exam__teacherId__1332DBDC");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Exam_ScholageYear");
            });

            modelBuilder.Entity<ExamQuestion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CorrectAnswer).HasColumnName("correctAnswer");

                entity.Property(e => e.ExamId).HasColumnName("examId");

                entity.Property(e => e.Orders).HasColumnName("orders");

                entity.Property(e => e.Question).HasColumnName("question");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.ExamQuestions)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ExamQuestions_Exam");
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.ToTable("Lecture");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Details).HasColumnName("details");

                entity.Property(e => e.Limited).HasColumnName("limited");

                entity.Property(e => e.LimitedHours).HasColumnName("limitedHours");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.PublishedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("publishedDate");

                entity.Property(e => e.SpecialViews).HasColumnName("specialViews");

                entity.Property(e => e.SubjectId).HasColumnName("subjectId");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.Views).HasColumnName("views");

                entity.Property(e => e.Yearid).HasColumnName("yearid");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Lecture_Subject");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Lecture__teacher__02084FDA");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.Yearid)
                    .HasConstraintName("FK_Lecture_ScholageYear");
            });

            modelBuilder.Entity<LectureFolder>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Link).HasColumnName("link");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.LectureFolders)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__LectureFo__Lectu__07C12930");
            });

            modelBuilder.Entity<LecturePart>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmbededCode).HasColumnName("embededCode");

                entity.Property(e => e.Link).HasColumnName("link");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.LectureParts)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__LecturePa__Lectu__04E4BC85");
            });

            modelBuilder.Entity<QuestionMcq>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Orders).HasColumnName("orders");

                entity.Property(e => e.QuestionId).HasColumnName("questionId");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionMcqs)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__QuestionM__quest__17F790F9");
            });

            modelBuilder.Entity<ScholageYear>(entity =>
            {
                entity.ToTable("ScholageYear");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("Seller");

                entity.HasIndex(e => e.PhoneNumber, "UQ__Seller__4849DA0118269591")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Seller__AB6E6164CB9333E9")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CenterId).HasColumnName("centerId");

                entity.Property(e => e.Email)
                    .HasMaxLength(70)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .HasColumnName("fullname");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(13)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Center)
                    .WithMany(p => p.Sellers)
                    .HasForeignKey(d => d.CenterId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Seller__centerId__6477ECF3");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.HasIndex(e => e.PhoneNumber, "UQ__Student__4849DA0102E8B2B0")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Student__AB6E6164D4E88FCA")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.Bonus).HasColumnName("bonus");

                entity.Property(e => e.CurrentYearId).HasColumnName("currentYearId");

                entity.Property(e => e.Email)
                    .HasMaxLength(70)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .HasColumnName("fullname");

                entity.Property(e => e.Governorate)
                    .HasMaxLength(50)
                    .HasColumnName("governorate");

                entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(13)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.School)
                    .HasMaxLength(100)
                    .HasColumnName("school");

                entity.HasOne(d => d.CurrentYear)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CurrentYearId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Student__current__59063A47");
            });

            modelBuilder.Entity<StudentHaveLecture>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.LectureId).HasColumnName("lectureId");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.Property(e => e.Watched).HasColumnName("watched");

                entity.Property(e => e.WatchedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("watchedDate");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.StudentHaveLectures)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__StudentHa__lectu__282DF8C2");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentHaveLectures)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__StudentHa__stude__2739D489");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.StudentHaveLectures)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__StudentHa__teach__2645B050");
            });

            modelBuilder.Entity<StudentTeacherBalance>(entity =>
            {
                entity.ToTable("StudentTeacherBalance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.Property(e => e.YearId).HasColumnName("yearId");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentTeacherBalances)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__StudentTe__stude__787EE5A0");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.StudentTeacherBalances)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__StudentTe__teach__778AC167");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.StudentTeacherBalances)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__StudentTe__yearI__797309D9");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.HasIndex(e => e.PhoneNumber, "UQ__Teacher__4849DA01EF6B569D")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Teacher__AB6E616488C8C568")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BalanceForPlatform).HasColumnName("balanceForPlatform");

                entity.Property(e => e.BalanceForTeacher).HasColumnName("balanceForTeacher");

                entity.Property(e => e.Email)
                    .HasMaxLength(70)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .HasColumnName("fullname");

                entity.Property(e => e.Governorate)
                    .HasMaxLength(50)
                    .HasColumnName("governorate");

                entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Percentage).HasColumnName("percentage");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(13)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.School)
                    .HasMaxLength(100)
                    .HasColumnName("school");

                entity.Property(e => e.SubjectId).HasColumnName("subjectId");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Teacher_Subject");
            });

            modelBuilder.Entity<TeachingYear>(entity =>
            {
                entity.ToTable("teachingYear");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.Property(e => e.YearId).HasColumnName("yearId");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeachingYears)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__teachingY__teach__5BE2A6F2");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.TeachingYears)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__teachingY__yearI__5CD6CB2B");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.SellerId).HasColumnName("sellerId");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("transactionDate");

                entity.Property(e => e.YearId).HasColumnName("yearId");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Transacti__selle__7F2BE32F");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Transacti__stude__7D439ABD");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Transacti__teach__7C4F7684");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Transacti__yearI__7E37BEF6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
