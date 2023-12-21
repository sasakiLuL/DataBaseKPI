using Microsoft.EntityFrameworkCore;
using RGR.Dal.Models;

namespace RGR.Dal;

public partial class Lab2Context : DbContext
{
    public Lab2Context()
    {
    }

    public Lab2Context(DbContextOptions<Lab2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<ContractsTerm> ContractsTerms { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Gym> Gyms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("classes_pkey");

            entity.ToTable("classes");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Duration)
                .HasColumnType("tsrange")
                .HasColumnName("duration");
            entity.Property(e => e.MaxParticipants).HasColumnName("max_participants");

            entity.HasOne(d => d.Course).WithMany(p => p.Classes)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("classes_course_id_fkey");

            entity.HasMany(d => d.Users).WithMany(p => p.Classes)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassesParticipant",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("classes_participants_user_id_fkey"),
                    l => l.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("classes_participants_class_id_fkey"),
                    j =>
                    {
                        j.HasKey("ClassId", "UserId").HasName("classes_participants_pkey");
                        j.ToTable("classes_participants");
                        j.IndexerProperty<long>("ClassId").HasColumnName("class_id");
                        j.IndexerProperty<long>("UserId").HasColumnName("user_id");
                    });
        });

        modelBuilder.Entity<Coach>(entity =>
        {
            entity.HasKey(e => e.CoachId).HasName("coaches_pkey");

            entity.ToTable("coaches");

            entity.Property(e => e.CoachId).HasColumnName("coach_id");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasColumnName("description");
            entity.Property(e => e.EmploymentDate).HasColumnName("employment_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .HasColumnName("first_name");
            entity.Property(e => e.GymId).HasColumnName("gym_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");

            entity.HasOne(d => d.Gym).WithMany(p => p.Coaches)
                .HasForeignKey(d => d.GymId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("coaches_gym_id_fkey");

            entity.HasMany(d => d.Classes).WithMany(p => p.Coaches)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassesCoach",
                    r => r.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("classes_coaches_class_id_fkey"),
                    l => l.HasOne<Coach>().WithMany()
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("classes_coaches_coach_id_fkey"),
                    j =>
                    {
                        j.HasKey("CoachId", "ClassId").HasName("classes_coaches_pkey");
                        j.ToTable("classes_coaches");
                        j.IndexerProperty<long>("CoachId").HasColumnName("coach_id");
                        j.IndexerProperty<long>("ClassId").HasColumnName("class_id");
                    });
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("contracts_pkey");

            entity.ToTable("contracts");

            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.ContractTermId).HasColumnName("contract_term_id");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(300)
                .HasColumnName("payment_method");
            entity.Property(e => e.TransactionTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("transaction_time");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ContractTerm).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ContractTermId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contracts_contract_term_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contracts_user_id_fkey");
        });

        modelBuilder.Entity<ContractsTerm>(entity =>
        {
            entity.HasKey(e => e.ContractTermsId).HasName("contracts_terms_pkey");

            entity.ToTable("contracts_terms");

            entity.Property(e => e.ContractTermsId).HasColumnName("contract_terms_id");
            entity.Property(e => e.ContractName)
                .HasMaxLength(100)
                .HasColumnName("contract_name");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasColumnName("description");
            entity.Property(e => e.GymId).HasColumnName("gym_id");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");

            entity.HasOne(d => d.Gym).WithMany(p => p.ContractsTerms)
                .HasForeignKey(d => d.GymId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contracts_terms_gym_id_fkey");

            entity.HasMany(d => d.Courses).WithMany(p => p.ContractTerms)
                .UsingEntity<Dictionary<string, object>>(
                    "ContractsCourse",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("contracts_courses_courses_id_fkey"),
                    l => l.HasOne<ContractsTerm>().WithMany()
                        .HasForeignKey("ContractTermsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("contracts_courses_contract_terms_id_fkey"),
                    j =>
                    {
                        j.HasKey("ContractTermsId", "CoursesId").HasName("contracts_courses_pkey");
                        j.ToTable("contracts_courses");
                        j.IndexerProperty<long>("ContractTermsId").HasColumnName("contract_terms_id");
                        j.IndexerProperty<long>("CoursesId").HasColumnName("courses_id");
                    });
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("courses_pkey");

            entity.ToTable("courses");

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .HasColumnName("course_name");
            entity.Property(e => e.GymId).HasColumnName("gym_id");

            entity.HasOne(d => d.Gym).WithMany(p => p.Courses)
                .HasForeignKey(d => d.GymId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("courses_gym_id_fkey");
        });

        modelBuilder.Entity<Gym>(entity =>
        {
            entity.HasKey(e => e.GymId).HasName("gyms_pkey");

            entity.ToTable("gyms");

            entity.Property(e => e.GymId).HasColumnName("gym_id");
            entity.Property(e => e.Address)
                .HasMaxLength(256)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .HasColumnName("email");
            entity.Property(e => e.GymName)
                .HasMaxLength(100)
                .HasColumnName("gym_name");
            entity.Property(e => e.HomePage)
                .HasMaxLength(256)
                .HasColumnName("home_page");
            entity.Property(e => e.Phone)
                .HasMaxLength(16)
                .HasColumnName("phone");

            entity.HasMany(d => d.Users).WithMany(p => p.Gyms)
                .UsingEntity<Dictionary<string, object>>(
                    "GymsParticipant",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("gyms_participants_user_id_fkey"),
                    l => l.HasOne<Gym>().WithMany()
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("gyms_participants_gym_id_fkey"),
                    j =>
                    {
                        j.HasKey("GymId", "UserId").HasName("gyms_participants_pkey");
                        j.ToTable("gyms_participants");
                        j.IndexerProperty<long>("GymId").HasColumnName("gym_id");
                        j.IndexerProperty<long>("UserId").HasColumnName("user_id");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Address)
                .HasMaxLength(256)
                .HasColumnName("address");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(16)
                .HasColumnName("phone");
            entity.Property(e => e.Sex).HasColumnName("sex");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
